
/**
*
*  BTIDIO DRIVER EXAMPLE 4  (06/09/2011)
*  Copyright (c) 2005-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4.C -- Event Log using Interrupts
*
**/

/**
*
*  This program opens Card Number 0 and configures the
*  first compatible core to toggle the value of Discrete 0
*  in Bank A when spacebar is pressed.
*
*  Discrete 0 of Bank A also configured to generate an
*  Event Log List entry.  An interrupt handler is installed
*  which enables the Event Log List to generate an interrupt
*  when an entry is made to the list.  When an entry is read
*  from the list, the associated data is read.
*
**/

#include "BTICard.H"
#include "BTIDIO.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>

#define	CARDNUM		     0
#define	MAX_CORES        4
#define	MAX_BANKS        4

typedef struct						/*Variables used by the thread*/
{
	BOOL    fWinNT40;				/*Flags whether we are running under Windows NT 4.0*/
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	HCORE	hCore;					/*Handle of core*/
	ULONG   Count;					/*Counting variable*/
	HANDLE  hEvent;					/*Handle of event object*/
	HANDLE  hThread;				/*Handle of thread object*/
	USHORT  type;					/*Type of Event (edge or fault)*/
	INT		banknum;				/*Bank on which event occurred*/
	ULONG	state;					/*State of Bank right after event*/
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
	USHORT  type;
	INT		banknum;
	ULONG	state;

	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	pMailbox->fStayAlive = TRUE;
	pMailbox->Count      = 0;

	pMailbox->type = 0;
	pMailbox->state = 0;
	pMailbox->banknum = 0;

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
			BTICard_EventLogRd(&type,&state,&banknum,pMailbox->hCore);

			pMailbox->type = type;
			pMailbox->state = state;
			pMailbox->banknum = banknum;

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
	INT corenum;
	INT banknum;
	INT ionum = 0;
	INT ch;
	BOOL value;
	BOOL done;
	ULONG bankcfg;
	ULONG disccfg;

	CHAR event_obj_name[64];

	OSVERSIONINFO OSInfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP4  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTIDIO Example 4                                                  *");
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

	printf("\nUsing DIO card #%d",CARDNUM);

/**
*
*  Find the first core with a DIO bank.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (banknum=0;banknum<MAX_BANKS;banknum++)
		{
			if (BTIDIO_BankIsDIO(banknum,hCore))	break;
		}

		if (banknum != MAX_BANKS) break;
	}

	if (errval || corenum == MAX_CORES || banknum == MAX_BANKS)
	{
		printf("\nError:  No DIO banks present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing DIO core #%d",corenum);
	printf("\nUsing Bank %c",banknum + 'A');
	printf("\nUsing Discrete %d",ionum);
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
*  Configure banknum as a shunt, input bank with inverted input polarity.
*
**/

	BTICard_CardReset(hCore);

	/*
	*  Threshold:   1.4V, TTL levels
	*  Sample Rate: 1ms clock, no divide value --> 1ms sampling
	*  Do not enable Event Logging at the Bank Level
	*/
	bankcfg = BANKCFGDIO_SHUNT | BANKCFGDIO_INPUT | BANKCFGDIO_POLIN_INV;
	errval = BTIDIO_BankConfig(bankcfg,THRESHOLDDIO_10KOHM,SAMPLERATEDIO_MS | 0x0001,banknum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        bank #%d on core #%d.",banknum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\nGetLastError returned %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure ionum as an output with event logging
*
**/

	disccfg = DISCCFGDIO_INOUT | DISCCFGDIO_POLIN_INV | DISCCFGDIO_LOGANYEDGE | DISCCFGDIO_LOGFAULT;
	errval = BTIDIO_DiscreteConfig(disccfg,ionum,banknum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        bank #%d on core #%d.",banknum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\nGetLastError returned %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure the Event Log to handle up to 30 events
*
**/

	errval = BTICard_EventLogConfig(LOGCFG_ENABLE,1024,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the Event Log list on core #%d.",corenum);
		printf("\nGetLastError returned %d",GetLastError());
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
*  Display data on the screen.
*
**/

	printf("\nPress spacebar to toggle discrete %d.  Press escape to exit...\n\n",ionum);

	done = 0;
	while (!done)
	{
		if (kbhit())
		{
			ch = getch();

			/* if escape is pressed, exit loop */
			if (ch == 0x1B)
			{
				done = 1;
			}

			/* if spacebar is pressed, toggle the discrete */
			else if (ch == ' ')
			{
				value = BTIDIO_DiscreteRd(ionum,banknum,hCore);
				BTIDIO_DiscreteWr(!value,ionum,banknum,hCore);
			}

			/* Clear faults on user command */
			else if (ch == 'c' || ch == 'C')
			{
				BTIDIO_BankFaultClr(0x01,banknum,hCore);
			}
		}


		/* Print the last received Event Log */
		if (Mailbox.type == EVENTTYPE_DIOEDGE)
			printf("\rBank %d last received an edge (0x%04X)   ",
					Mailbox.banknum,Mailbox.state);

		else if (Mailbox.type == EVENTTYPE_DIOFAULT)
		 	printf("\rBank %d last received a fault (0x%04X)   ",
					Mailbox.banknum,Mailbox.state);

	}

/**
*
*  Clear the flag keeping the thread alive and wait for the
*  thread to quit.
*
**/

	printf("\nWaiting for the thread to quit.");

	Mailbox.fStayAlive = FALSE;						//Clear the fStayAlive flag so the thread commits suicide after the next interrupt

	WaitForSingleObject(Mailbox.hThread,10000);


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
	BTICard_CardStop(hCore);

	BTICard_IntUninstall(hCore);
	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);

	BTICard_CardClose(hCard);
}
