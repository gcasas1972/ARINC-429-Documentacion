
/**
*
*  BTI429 DRIVER EXAMPLE 9  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP9.C -- Event Log using Interrupts
*
**/

/**
*
*  This program opens Card Number 0, finds the first
*  compatible core, and configures the first receive
*  channel to receive 2 GPS messages into separate
*  Message Records; and receive all other messages
*  into a default Message Record.
*
*  Each of the messages is also configured to generate an
*  Event Log List entry.  An interrupt handler is installed
*  which enables the Event Log List to generate an interrupt
*  when an entry is made to the list.  When an entry is read
*  from the list, the associated data is read.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include "BTICard.H"
#include "BTI429.H"

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

typedef struct						/*Variables used by the thread*/
{
	BOOL    fWinNT40;				/*Flags whether we are running under Windows NT 4.0*/
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	HCORE	hCore;					/*Handle of core*/
	ULONG   Count;					/*Counting variable*/
	HANDLE  hEvent;					/*Handle of event object*/
	HANDLE  hThread;				/*Handle of thread object*/
	MSGSTRUCT429 msgdefault;		/*Default   Message Record*/
	MSGSTRUCT429 latitude;			/*Latitude  Message Record*/
	MSGSTRUCT429 longitude;			/*Longitude Message Record*/
} ThreadMailbox;

/**
*
*  The following thread is spun off by the main application.
*  It waits for the specified thread to be released when the
*  core generates an interrupt.  It then resets the event to
*  allow us to receive more events, reads an entry from the
*  Event Log list, and waits for the next event.
*
**/

DWORD WINAPI EventLogInterruptThread(LPVOID lpParam)
{
	USHORT  Type;
	ULONG   Info;
	MSGADDR msgaddr;

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

			msgaddr = Info;								//Info value is message address

			if (msgaddr == pMailbox->msgdefault.addr)
			{
				pMailbox->msgdefault.data = BTI429_MsgDataRd(msgaddr,pMailbox->hCore);
			}
			else if (msgaddr == pMailbox->latitude.addr)
			{
				pMailbox->latitude.data = BTI429_MsgDataRd(msgaddr,pMailbox->hCore);
			}
			else if (msgaddr == pMailbox->longitude.addr)
			{
				pMailbox->longitude.data = BTI429_MsgDataRd(msgaddr,pMailbox->hCore);
			}

			BTICard_IntClear(pMailbox->hCore);				//Clear interrupt from core
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
	INT    corenum;
	INT    rcvchan;

	CHAR event_obj_name[64];

	OSVERSIONINFO OSInfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP9  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI429 Example 9                                                  *");
	printf("\n    *  \"Program for Event Log using Interrupts.\"                         *");
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
*  An error value is returned, which is tested
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

	printf("\nUsing ARINC 429 card #%d",CARDNUM);

/**
*
*  Find the first ARINC 429 core with a receive channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)	if (BTI429_ChIsRcv(rcvchan,hCore)) break;

		if (rcvchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 429 receive channels present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 429 core #%d",corenum);
	printf("\nUsing receive channel #%d",rcvchan);
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
*  Configure rcvchan for automatic speed detection.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI429_ChConfig(CHCFG429_AUTOSPEED,rcvchan,hCore);   /*Configure channel*/

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Before any messages can be received, filters must be set
*  for the receive channel.  First, the default filter is
*  created.  Then, two filters are set for the two messages
*  of interest.
*
*  Each message is configured to create Event Log list entries.
*
**/

	Mailbox.msgdefault.addr = BTI429_FilterDefault(MSGCRT429_LOG,rcvchan,hCore);
	Mailbox.latitude.addr   = BTI429_FilterSet(MSGCRT429_LOG,0310,SDIALL,rcvchan,hCore);
	Mailbox.longitude.addr  = BTI429_FilterSet(MSGCRT429_LOG,0311,SDIALL,rcvchan,hCore);

/**
*
*  Initialize data values to zero.
*
**/

	Mailbox.msgdefault.data = 0;
	Mailbox.latitude.data   = 0;
	Mailbox.longitude.data  = 0;

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
*  Start the card to begin transmissions.
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
		printf("\r");
		printf("Default=%08lX " ,Mailbox.msgdefault.data);
		printf("Latitude=%08lX ",Mailbox.latitude.data);
		printf("Longitude=%08lX",Mailbox.longitude.data);
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
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardStop(hCore);						/*Stop the card*/

	BTICard_IntUninstall(hCore);
	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);

	BTICard_CardClose(hCard);					/*Close the card*/
}
