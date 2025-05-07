
/**
*
*  LP1553-3 and LC1553-3 DRIVER EXAMPLE 9  Version 1.0  (10/29/2001)
*  Copyright (c) 1997-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP9.C -- Example 9.
*                      "Interrupts"
*
**/

/**
*
*  This example configures the L13 as a bus controller
*  to transmit a schedule of three messages.  The schedule is
*  created in such a way that the messages are transmitted at
*  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
*  and 40ms, respectively).
*
*  The schedule is also configured to generate an interrupt
*  after each 10ms frame.  Upon each interrupt, the data
*  words associated with the 0843H BC-RT message is updated.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include "l13w32.h"

#define	CARDNUM 0					/*Card number of L13 card*/

#define CMD0		0x0843			/*Command word for first message*/
#define CMD1		0x0821			/*Command word for second message*/
#define RCV_CMD2	0x0821			/*Receive command of an RT-RT transfer*/
#define XMT_CMD2	0x1C21			/*Transmit command of an RT-RT transfer*/

#define	FRAMETIME	10000			/*Frame time in microseconds*/

typedef struct						/*Variables used by the thread*/
{
	BOOL    fWindowsNT40;			/*Flags whether we are running under Windows 95*/
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	BOOL    fHasQuit;				/*Flag indicating the thread has quit*/
	HCARD   Card;					/*Handle of L13 card*/
	ULONG   Hits;					/*Counting variable*/
	ULONG   Misses;					/*Counting variable*/
	HANDLE  hEvent;					/*Handle of event object*/
	HANDLE  hThread;				/*Handle of thread object*/
	MSGADDR BCMsgs[3];				/*Address of three BC messages*/
	USHORT  Data[3];				/*Data values transmitted by BCMsgs[0]*/
} ThreadMailbox;

/**
*
*  The following thread is spun off by the main application. 
*  It waits for the specified thread to be released when the
*  L13 card generates an interrupt.  It then resets the
*  event to allow us to receive more events, reads an entry
*  from the interrupt log list, and waits for the next event.
*
**/

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	USHORT Type;
	USHORT Info;

	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	while(pMailbox->fStayAlive)
	{
		if (WaitForSingleObject(pMailbox->hEvent,200) == WAIT_TIMEOUT)
		{
			pMailbox->Misses++;								//Increment counter
		}
		else
		{
			if (!(pMailbox->fWindowsNT40))					//Reset event if Windows 95
			{												//to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			pMailbox->Hits++;								//Increment counter

			L13_IntRd(&Type,&Info,pMailbox->Card);			//Read entry from interrupt log list

			pMailbox->Data[0] += 2;							//Calculate the new data words
			pMailbox->Data[1] += 4;
			pMailbox->Data[2] += 6;

			L13_MsgDataWr(pMailbox->Data, 3, pMailbox->BCMsgs[0], pMailbox->Card);	//Write the new data words
			
			L13_IntReset(pMailbox->Card);					//Reset interrupt from card
		}
	}

	pMailbox->fHasQuit = TRUE;								//Set flag indicating we have quit

	return(0);
}

void main(void)
{
	DWORD ThreadId;
	ThreadMailbox Mailbox;
	BOOL fWindowsNT40;

	HCARD   Card;
	ERRVAL  errval;
	USHORT  MsgErrors;

	INT j;

	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP9  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1997-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Example 9");
	fprintf(stderr,"\n\"Interrupts\"");
	fprintf(stderr,"\n");

/**
*
*  Determine which OS we're running.  Interrupt handling is
*  slightly different between NT and 95.
*
**/

	OSInfo.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);

	if (GetVersionEx(&OSInfo))
	{
		fWindowsNT40 = (VER_PLATFORM_WIN32_NT==OSInfo.dwPlatformId && 4>=OSInfo.dwMajorVersion);
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
*  Open the L13 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L13_CardOpen(CARDNUM);					/*Open the L13 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L13 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Create an event object.
*
**/

	if (fWindowsNT40)
	{
		if (L13_CardGetInfo(INFOTYPE_PLAT,Card) == 0x4C50)	//Card is LP1553-3
		{
			Mailbox.hEvent = OpenEvent(
				SYNCHRONIZE,				//Desired access
				FALSE,						//Inherit flag
				"LP1553Interrupt");			//Pointer to event-object name
		}
		else												//Card is LC1553-3
		{
			Mailbox.hEvent = OpenEvent(
				SYNCHRONIZE,				//Desired access
				FALSE,						//Inherit flag
				"LC1553Interrupt");			//Pointer to event-object name
		}

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			L13_CardClose(Card);
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
			L13_CardClose(Card);
			exit(1);
		}
	}

/**
*
*  Create a thread.
*
**/

	Mailbox.fWindowsNT40 = fWindowsNT40;
	Mailbox.Card         = Card;
	Mailbox.fStayAlive   = TRUE;
	Mailbox.fHasQuit     = FALSE;
	Mailbox.Hits         = 0;
	Mailbox.Misses       = 0;

	Mailbox.hThread = CreateThread(
		NULL,					//Use the default security attributes  
		0x10000,				//Initial thread stack size
		InterruptServiceThread,	//Pointer to thread function 
		(LPVOID)&Mailbox,		//Argument for new thread 
		0,						//Creation flags 
		&ThreadId);				//Pointer to returned thread identifier 

	if (Mailbox.hThread == NULL)
	{
		printf("\nThread creation failed");
		printf("\nGetLastError = %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		L13_CardClose(Card);
		exit(1);
	}

/**
*
*  Install the interrupt handler.
*
**/

	errval = L13_IntInstall(Mailbox.hEvent,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while installing interrupt handler.",errval);
		printf("\nGetLastError returned %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		L13_CardClose(Card);
		exit(1);
	}

/**
*
*  Configure the card for bus controller mode.
*
**/

	L13_CardReset(Card);							/*Reset the L13 card*/

	errval = L13_BCConfig(BCCFG_DEFAULT,Card);		/*Configure the L13 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for bus controller mode.",errval);
		L13_IntUninstall(Card);
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		L13_IntUninstall(Card);
		L13_CardClose(Card);
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

	Mailbox.BCMsgs[0] = L13_BCCreateMsg(MSGCRT_DEFAULT,     CMD0,        0, Mailbox.Data, Card);
	Mailbox.BCMsgs[1] = L13_BCCreateMsg(MSGCRT_DEFAULT,     CMD1,        0,         NULL, Card);
	Mailbox.BCMsgs[2] = L13_BCCreateMsg(MSGCRT_RTRT,    RCV_CMD2, XMT_CMD2,         NULL, Card);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.  Also schedule interrupts after each frame. 
*  Note the unique tag value associated with each interrupt
*  that could be used to distinguish each interrupt.
*
**/

	L13_BCSchedFrame(FRAMETIME,       Card);
	L13_BCSchedMsg(Mailbox.BCMsgs[0], Card);
	L13_BCSchedMsg(Mailbox.BCMsgs[1], Card);
	L13_BCSchedMsg(Mailbox.BCMsgs[2], Card);
	L13_BCSchedInt(0x1111,            Card);

	L13_BCSchedFrame(FRAMETIME,       Card);
	L13_BCSchedMsg(Mailbox.BCMsgs[0], Card);
	L13_BCSchedInt(0x2222,            Card);

	L13_BCSchedFrame(FRAMETIME,       Card);
	L13_BCSchedMsg(Mailbox.BCMsgs[0], Card);
	L13_BCSchedMsg(Mailbox.BCMsgs[1], Card);
	L13_BCSchedInt(0x3333,            Card);

	L13_BCSchedFrame(FRAMETIME,       Card);
	L13_BCSchedMsg(Mailbox.BCMsgs[0], Card);
	L13_BCSchedInt(0x4444,            Card);

/**
*
*  Configure the interrupt log list.
*
**/

	errval = L13_IntConfig(INTCFG_ENABLE,1024,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring interrupt log list.",errval);
		L13_IntUninstall(Card);
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		L13_IntUninstall(Card);
		L13_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin transmissions.
*
**/

	L13_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");
	
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
	
	Mailbox.fStayAlive = FALSE;						//Clear the fStayAlive flag so the thread commits suicide after the next interrupt

	for (j=0xFFFFFFFF;j && !Mailbox.fHasQuit;--j);	//Waiting for thread to quit

/**
*
*  Uninstall the interrupt handler.
*
**/

	errval = L13_IntUninstall(Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while uninstalling interrupt handler.",errval);
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		L13_CardClose(Card);
		exit(1);
	}

/**
*
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardStop(Card);						/*Stop the card*/

	L13_IntUninstall(Card);
	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);
	L13_CardClose(Card);					/*Close the card*/
}
