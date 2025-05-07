
/**
*
*  BTI708 DRIVER EXAMPLE 7  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP7.C -- Event Log using Interrupts
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first compatible core to configure the first transmit
*  channel to transmit a sequence of 32 messages at a
*  rate of 200Hz.  The messages are automatically assigned
*  the numbers 0 through 31.
*
*  An Event Log frequency of 16 is specified, which will
*  cause the channel to issue an Event Log List entry
*  every 16th message (message numbers 15, and 31).
*  The program uses these events to update he data for
*  the half of messages that were just transmitted.
*
*  An interrupt handler is installed which enables the
*  Event Log List to generate an interrupt when an entry
*  is made to the list.  The interrupt service thread
*  will update the data when the interrupt is issued from
*  the device.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include "BTICard.H"
#include "BTI708.H"

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

#define	FRAMEFREQ	  200          /*Frame frequency of 200Hz*/
#define LOGFREQ		  16           /*Generate a Log Event after every 16th message*/
#define	FRAMECOUNT	  32           /*Transmit a total of 32 messages*/

typedef struct						/*Variables used by the thread*/
{
	BOOL    fWinNT40;				/*Flags whether we are running under Windows NT 4.0*/
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	HCORE   hCore;					/*Handle to core*/
	INT     xmtchan;				/*Transmit channel number*/
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
	USHORT Type;
	ULONG  Info;
	USHORT framenum;
	INT    j,jj;
	USHORT Data[100];

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
			BTICard_EventLogRd(&Type,&Info,NULL,pMailbox->hCore);

			framenum = (USHORT)Info;					//Info value is frame number

			if (framenum == ((FRAMECOUNT/2)-1))			//First half transmitted
			{
				for (j=0;j<=framenum;j++)
				{
					for (jj=0;jj<100;jj++) Data[jj] = j + (pMailbox->Count * FRAMECOUNT);
					BTI708_MsgDataWr(Data,j,pMailbox->xmtchan,pMailbox->hCore);
				}
			}
			else if (framenum == (FRAMECOUNT-1))		//Second half transmitted
			{
				for (j=(FRAMECOUNT/2);j<=framenum;j++)
				{
					for (jj=0;jj<100;jj++) Data[jj] = j + (pMailbox->Count * FRAMECOUNT);
					BTI708_MsgDataWr(Data,j,pMailbox->xmtchan,pMailbox->hCore);
				}
			}

			BTICard_IntClear(pMailbox->hCore);				//Clear interrupt from card
		}
	}

	return(0);
}

void main(void)
{
	DWORD ThreadId;
	ThreadMailbox Mailbox;
	BOOL fWinNT40;

	HCARD  hCard;
	HCORE  hCore;
	ERRVAL errval;
	INT    corenum;
	INT    xmtchan;
	INT    j,jj;
	USHORT Data[100];

	CHAR event_obj_name[64];

	OSVERSIONINFO OSInfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP7  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI708 Example 7                                                  *");
	printf("\n    *  \"Event Log using Interrupts example.\"                             *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
	printf("\n");

/**
*
*  Determine which OS we're running.  Interrupt handling is
*  slightly different between NT 4.0 and 9x/ME/2K.
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

/**
*
*  Find the first ARINC 708 core with a transmit channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (BTI708_ChIsXmt(xmtchan,hCore)) break;

		if (xmtchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 708 transmit channels present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 708 core #%d",corenum);
	printf("\nUsing transmit channel #%d",xmtchan);
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
	Mailbox.xmtchan  = xmtchan;

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
		printf("\nError:  An error was encountered (%i) while installing",errval);
		printf("\n        interrupt handler on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\nGetLastError returned %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure transmit channel.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI708_ChConfig(CHCFG708_DEFAULT,xmtchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Build the transmit channel messages.
*
**/

	errval = BTI708_XmtBuild(MSGCRT708_DEFAULT,FRAMEFREQ,LOGFREQ,FRAMECOUNT,xmtchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while building",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Create and write the data for the messages.
*
**/

	for (j=0;j<FRAMECOUNT;j++)					/*Loop through all the messages*/
	{
		for (jj=0;jj<100;jj++) Data[jj] = j;
		BTI708_MsgDataWr(Data,j,xmtchan,hCore);	/*Write data to the Device*/
	}

/**
*
*  Configure the Event Log list.
*
**/

	errval = BTICard_EventLogConfig(LOGCFG_ENABLE,1024,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the Event Log list on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_IntUninstall(hCore);
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

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

	printf("\nPress any key to exit...");
	printf("\n\n");

	while (!kbhit())
	{
		printf("\rNumber of interrupts %d     ",Mailbox.Count);
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
		printf("\nError:  An error was encountered (%i) while uninstalling",errval);
		printf("\n        interrupt handler on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Stop the card.
*
**/

	BTICard_CardStop(hCore);

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_IntUninstall(hCore);
	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);

	BTICard_CardClose(hCard);
}
