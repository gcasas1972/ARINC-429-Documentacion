
/**
*
*  BTI1553 DRIVER EXAMPLE 9  (06/09/2011)
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
*  This example configures Card Number 0 as a bus controller
*  to transmit a schedule of three messages.  The schedule is
*  created in such a way that the messages are transmitted at
*  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
*  and 40ms, respectively).
*
*  The schedule is also configured to generate an Event Log List
*  entry after each 10ms frame.  An interrupt handler is installed
*  which enables the Event Log List to generate an interrupt when an
*  entry is made to the list.  Upon each interrupt, the data
*  words associated with the 0843H BC-RT message are updated.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include "BTICard.H"
#include "BTI1553.H"

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

#define CMD0		0x0843			/*Command word for first message*/
#define CMD1		0x0821			/*Command word for second message*/
#define RCV_CMD2	0x0821			/*Receive command of an RT-RT transfer*/
#define XMT_CMD2	0x1C21			/*Transmit command of an RT-RT transfer*/

#define	FRAMETIME	10000			/*Frame time in microseconds*/

typedef struct						/*Variables used by the thread*/
{
	BOOL    fWinNT40;				/*Flags whether we are running under Windows NT 4.0*/
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	HCORE	hCore;					/*Handle of core*/
	ULONG   Count;					/*Counting variable*/
	HANDLE  hEvent;					/*Handle of event object*/
	HANDLE  hThread;				/*Handle of thread object*/
	MSGADDR BCMsgs[3];				/*Address of three BC messages*/
	USHORT  Data[3];				/*Data values transmitted by BCMsgs[0]*/
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

	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	pMailbox->fStayAlive = TRUE;
	pMailbox->Count      = 0;

	while(pMailbox->fStayAlive)
	{
		if (WAIT_TIMEOUT == WaitForSingleObject(pMailbox->hEvent,200))
		{
		}
		else
		{
			if (!(pMailbox->fWinNT40))						//Reset event if not Windows NT 4.0
			{												//to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			pMailbox->Count++;								//Increment counter

			//Read entry from Event Log list
			BTICard_EventLogRd(&Type,&Info,NULL,pMailbox->hCore);

			pMailbox->Data[0] += 2;							//Calculate the new data words
			pMailbox->Data[1] += 4;
			pMailbox->Data[2] += 6;

			//Write the new data words
			BTI1553_MsgDataWr(pMailbox->Data,3,pMailbox->BCMsgs[0],pMailbox->hCore);

			BTICard_IntClear(pMailbox->hCore);				//Clear interrupt from card
		}
	}

	return(0);
}

void main(void)
{
	HCARD   hCard;					/*Handle to card*/
	HCORE   hCore;					/*Handle to core*/
	ERRVAL  errval;					/*Error return value*/
	INT     corenum;				/*Core number*/
	INT     channum;				/*Channel number*/

	DWORD ThreadId;
	ThreadMailbox Mailbox;
	BOOL fWinNT40;
	CHAR event_obj_name[64];
	OSVERSIONINFO OSInfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP9  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 9                                                 *");
	printf("\n    *  \"Event Log using Interrupts\"                                      *");
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
*  Find the first MIL-STD-1553 core and channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (channum=0;channum<MAX_CHANNELS;channum++)
			if (BTI1553_ChIs1553(channum,hCore)) break;

		if (channum != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
	{
		printf("\nError:  No MIL-STD-1553 channels present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing MIL-STD-1553 core #%d",corenum);
	printf("\nUsing MIL-STD-1553 channel #%d",channum);
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
			printf("\nError:  Event creation failed");
			printf("\n        GetLastError returned %d",GetLastError());
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
			printf("\nError:  Event creation failed");
			printf("\n        GetLastError returned %d",GetLastError());
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
		printf("\nError:  Thread creation failed");
		printf("\n        GetLastError = %d",GetLastError());
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
		printf("\n        GetLastError returned %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure the channel for bus controller mode.
*
**/

	BTICard_CardReset(hCore);									/*Reset the core*/

	errval = BTI1553_BCConfig(BCCFG1553_DEFAULT,channum,hCore);	/*Configure the core*/

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring bus",errval);
		printf("\n        controller mode on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Create the message records for each of the three messages.
*
**/

	Mailbox.Data[0] = 0;
	Mailbox.Data[1] = 0;
	Mailbox.Data[2] = 0;

	Mailbox.BCMsgs[0] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,CMD0,    0,       Mailbox.Data,hCore);
	Mailbox.BCMsgs[1] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,CMD1,    0,       NULL,        hCore);
	Mailbox.BCMsgs[2] = BTI1553_BCCreateMsg(MSGCRT1553_RTRT,   RCV_CMD2,XMT_CMD2,NULL,        hCore);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.  Also schedule an Event Log after each frame.
*  Note the unique tag value associated with each Event Log
*  that could be used to distinguish unique Events.
*
**/

	BTI1553_BCSchedFrame(FRAMETIME,           channum,hCore);
	BTI1553_BCSchedMsg(Mailbox.BCMsgs[0],     channum,hCore);
	BTI1553_BCSchedMsg(Mailbox.BCMsgs[1],     channum,hCore);
	BTI1553_BCSchedMsg(Mailbox.BCMsgs[2],     channum,hCore);
	BTI1553_BCSchedLog(COND1553_ALWAYS,0x1111,channum,hCore);

	BTI1553_BCSchedFrame(FRAMETIME,           channum,hCore);
	BTI1553_BCSchedMsg(Mailbox.BCMsgs[0],     channum,hCore);
	BTI1553_BCSchedLog(COND1553_ALWAYS,0x2222,channum,hCore);

	BTI1553_BCSchedFrame(FRAMETIME,           channum,hCore);
	BTI1553_BCSchedMsg(Mailbox.BCMsgs[0],     channum,hCore);
	BTI1553_BCSchedMsg(Mailbox.BCMsgs[1],     channum,hCore);
	BTI1553_BCSchedLog(COND1553_ALWAYS,0x3333,channum,hCore);

	BTI1553_BCSchedFrame(FRAMETIME,           channum,hCore);
	BTI1553_BCSchedMsg(Mailbox.BCMsgs[0],     channum,hCore);
	BTI1553_BCSchedLog(COND1553_ALWAYS,0x4444,channum,hCore);

/**
*
*  Configure the Event Log list.
*
**/

	errval = BTICard_EventLogConfig(LOGCFG_ENABLE,1024,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring the",errval);
		printf("\n        Event Log list on on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_IntUninstall(hCard);
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

	printf("\nPress any key to exit....\n\n");

	while (!kbhit())
	{
		printf("\rTransmitting data {%04XH, %04XH, %04XH}",Mailbox.Data[0],Mailbox.Data[1],Mailbox.Data[2]);
	}

/**
*
*  Clear the flag keeping the thread alive and wait for the
*  thread to quit.
*
**/

	printf("\nWaiting for the thread to quit.");

	Mailbox.fStayAlive = FALSE;		//Clear the fStayAlive flag so the thread commits suicide after the next interrupt

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

	BTICard_CardStop(hCore);					/*Stop the card*/

	BTICard_IntUninstall(hCore);
	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);

	BTICard_CardClose(hCard);					/*Close the card*/
}
