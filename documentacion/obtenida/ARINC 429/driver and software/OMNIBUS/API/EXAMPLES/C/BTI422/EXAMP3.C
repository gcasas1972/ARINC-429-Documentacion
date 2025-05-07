
/**
*
*  BTI422 DRIVER EXAMPLE 3  (06/09/2011)
*  Copyright (c) 2004-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- Event Log using Interrupts
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first serial port at 115,200 bps with 8 bit data,
*  no parity, 1 stop bit.
*
*  An Event Log List is configured and the receive FIFO
*  is enabled to generate an Event Log List entry when
*  there are greater than 64 bytes in the FIFO.  An
*  interrupt handler is installed which enables the Event
*  Log List to generate an interrupt when an entry is
*  made to the list.  When an entry is read from the
*  list, the 64 bytes of data are read.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include "BTICard.H"
#include "BTI422.H"

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_PORTS     16
#define	BUFSIZE       64

typedef struct						/*Variables used by the thread*/
{
	BOOL    fWinNT40;				/*Flags whether we are running under Windows NT 4.0*/
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	HCORE   hCore;					/*Handle to core*/
	ULONG   Count;					/*Counting variable*/
	HANDLE  hEvent;					/*Handle of event object*/
	HANDLE  hThread;				/*Handle of thread object*/
} ThreadMailbox;

/**
*
*  The following thread is spun off by the main application.
*  It waits for the specified thread to be released when the
*  card generates an interrupt.  It then resets the event to
*  allow us to receive more events, reads an entry from the
*  Event Log list, and waits for the next event.
*
**/

DWORD WINAPI EventLogInterruptThread(LPVOID lpParam)
{
	USHORT  Type;
	INT     Port;
	BYTE    databuf[BUFSIZE];

	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	pMailbox->fStayAlive = TRUE;
	pMailbox->Count      = 0;

	while(pMailbox->fStayAlive)
	{
		if (WaitForSingleObject(pMailbox->hEvent,200) == WAIT_TIMEOUT)
		{
		}
		else
		{
			if (!(pMailbox->fWinNT40))					//Reset event if not Windows NT 4.0
			{											//to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			pMailbox->Count++;							//Increment counter

			//Read entry from Event Log list
			BTICard_EventLogRd(&Type,NULL,&Port,pMailbox->hCore);

			if (Type == EVENTTYPE_422RXTHRESHOLD)
			{
				BTI422_FIFODataRd(databuf,BUFSIZE,NULL,Port,pMailbox->hCore);

				// Process received data
			}

			BTICard_IntClear(pMailbox->hCore);			//Clear interrupt from card
		}
	}

	return(0);
}

void main(void)
{
	DWORD ThreadId;
	ThreadMailbox Mailbox;
	BOOL fWinNT40;

	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT corenum;
	INT port;

	CHAR event_obj_name[64];

	OSVERSIONINFO OSInfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP3  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2004-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI422 Example 3                                                  *");
	printf("\n    *  \"Event Log using Interrupts.\"                                     *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
	printf("\n");

/**
*
*  Determine which OS we're running.  Interrupt handling is
*  slightly different between NT 4.0 and 9x/ME/2K/XP.
*
**/

	OSInfo.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);

	if (GetVersionEx(&OSInfo))
	{
		fWinNT40 = (VER_PLATFORM_WIN32_NT==OSInfo.dwPlatformId && 4>=OSInfo.dwMajorVersion);
	}
	else
	{
		printf("\nError:  Unable to determine the operating system");
		printf("\n        we are running on.");
		printf("\n");
		exit(1);
	}

/**
*
*  Open the card with the specified card number.
*  An error value is returned which is tested
*  to determine if an error occurred.
*
**/

	errval = BTICard_CardOpen(&hCard,CARDNUM);

	if (errval)
	{
		printf("\nError:  Either card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		exit(1);
	}

	printf("\nUsing ARINC 422 card #%d",CARDNUM);

/**
*
*  Find the first ARINC 422 core.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (port=0;port<MAX_PORTS;port++)
		{
			if (BTI422_PortIs422(port, hCore))	break;
		}

		if (port != MAX_PORTS) break;
	}

	if (errval || corenum == MAX_CORES || port == MAX_PORTS)
	{
		printf("\nError:  No ARINC 422 ports present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 422 core #%d",corenum);
	printf("\nUsing port #%d",port);
	printf("\n");

/**
*
*  Create an event object.
*
**/

	if (fWinNT40)
	{
		sprintf(event_obj_name,"%sInterrupt",BTICard_CardTypeStr(hCore));

		Mailbox.hEvent = OpenEvent(
			SYNCHRONIZE,				//Desired access
			FALSE,						//Inherit flag
			event_obj_name);			//Pointer to event-object name

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			BTICard_CardClose(hCard);
			exit(1);
		}
	}
	else
	{
		Mailbox.hEvent = CreateEvent(
			NULL,
			TRUE,						//Flag for manual-reset event
			FALSE,						//Flag for initial state
			NULL);						//Pointer to event-object name

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			BTICard_CardClose(hCard);
			exit(1);
		}
	}

/**
*
*  Create a thread.
*
**/

	Mailbox.fWinNT40 = fWinNT40;
	Mailbox.hCore    = hCore;

	Mailbox.hThread = CreateThread(
		NULL,					//Use the default security attributes
		0x10000,				//Initial thread stack size
		EventLogInterruptThread,//Pointer to thread function
		(LPVOID)&Mailbox,		//Argument for new thread
		0,						//Creation flags
		&ThreadId);				//Pointer to returned thread identifier

	if (Mailbox.hThread == NULL)
	{
		printf("\nThread creation failed");
		printf("\nGetLastError = %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Install the interrupt handler.
*
**/

	errval = BTICard_IntInstall(Mailbox.hEvent,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while installing interrupt handler.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\nGetLastError returned %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure port.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI422_PortConfig(PORTCFG422_PARITYNONE,BITRATE422_115200BPS,port,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring port %d.",errval,port);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure the Event Log list.
*
**/

	errval = BTICard_EventLogConfig(LOGCFG_ENABLE,1024,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring the Event Log list.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_IntUninstall(hCore);
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure FIFO Threshold.
*
**/

	//Enable Threshold Event Logging
	BTI422_FIFOConfigRx(FIFOCFG422_RXTHRESHOLD,BUFSIZE,port,hCore);

/**
*
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");

	while (!kbhit())
	{
		printf("\rInterrupt count = %d",Mailbox.Count);
		Sleep(10);
	}

/**
*
*  Clear the flag keeping the thread alive and wait for the
*  thread to quit.
*
**/

	printf("\nWaiting for the thread to quit.");

	Mailbox.fStayAlive = FALSE;						//Clear the fStayAlive flag so the thread commits suicide after the next interrupt

	WaitForSingleObject(Mailbox.hThread, 10000);

/**
*
*  Uninstall the interrupt handler.
*
**/

	errval = BTICard_IntUninstall(hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while uninstalling interrupt handler.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardStop(hCore);						/*Stop the card*/

	BTICard_IntUninstall(hCore);
	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);

	BTICard_CardClose(hCard);					/*Close the card*/
}
