
/**
*
*  PC1553-3 DRIVER EXAMPLE 9  Version 1.0  (02/20/1998)
*  Copyright (c) 1998
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
*  This example configures the PC1553-3 as a bus controller
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
#include "p13w32.h"

#define	MEMBASE 0xCC00				/*Memory address of PC1553-3 card*/
#define IOBASE  0x2C0				/*I/O address of PC1553-3 card*/
#define	IRQCHAN 2					/*Interrupt channel of PC1553-3 card*/
#define	DMACHAN 1					/*DMA channel of PC1553-3 card*/

#define CMD0		0x0843			/*Command word for first message*/
#define CMD1		0x0821			/*Command word for second message*/
#define RCV_CMD2	0x0821			/*Receive command of an RT-RT transfer*/
#define XMT_CMD2	0x1C21			/*Transmit command of an RT-RT transfer*/

#define	FRAMETIME	10000			/*Frame time in microseconds*/

typedef struct						/*Variables used by the thread*/
{
	BOOL    fWindowsNT40;			/*Flags whether we are running under Windows NT 4.0*/
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	BOOL    fHasQuit;				/*Flag indicating the thread has quit*/
	HCARD   Card;					/*Handle of PC1553-3 card*/
	ULONG   Hits;					/*Counting variable*/
	ULONG   Misses;					/*Counting variable*/
	HANDLE  hEvent;					/*Handle of event*/
	HANDLE  hThread;				/*Handle of event*/
	MSGADDR BCMsgs[3];				/*Address of three BC messages*/
	USHORT  Data[3];				/*Data values transmitted by BCMsgs[0]*/
} ThreadMailbox;

/**
*
*  The following thread is spun off by the main application. 
*  It waits for the specified thread to be released when the
*  PC1553-3 card generates an interrupt.  It then resets the
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
			if (!(pMailbox->fWindowsNT40))						//Reset event if not Windows NT 4.0
			{													//to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			pMailbox->Hits++;									//Increment counter

			P13_IntRd(&Type,&Info,pMailbox->Card);				//Read entry from interrupt log list

			pMailbox->Data[0] += 2;								//Calculate the new data words
			pMailbox->Data[1] += 4;
			pMailbox->Data[2] += 6;

			P13_MsgDataWr(pMailbox->Data, 3, pMailbox->BCMsgs[0], pMailbox->Card);	//Write the new data words
			
			P13_IntReset(pMailbox->Card);						//Reset interrupt from card
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

	volatile INT j;

	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP9  Version 1.0  (02/20/1998)");
	fprintf(stderr,"\nCopyright 1998  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC1553-3 Example 9");
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
		fWindowsNT40 = ((VER_PLATFORM_WIN32_NT == OSInfo.dwPlatformId) &&
		                (OSInfo.dwMajorVersion <= 4));
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
*  Open the PC1553-3 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = P13_CardOpen(MEMBASE,IOBASE,IRQCHAN,DMACHAN);	/*Open the PC1553-3 card*/

	if (Card < 0)
	{
		printf("\nError:  Either a PC1553-3 is not present at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
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
		Mailbox.hEvent = OpenEvent(
			SYNCHRONIZE,				//Desired access
			FALSE,						//Inherit flag
			"PC1553Interrupt");			//Pointer to event-object name  

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			P13_CardClose(Card);
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
	}

/**
*
*  Install the interrupt handler.
*
**/

	errval = P13_IntInstall(Mailbox.hEvent,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while installing interrupt handler.",errval);
		printf("\nGetLastError returned %d",GetLastError());
		CloseHandle(Mailbox.hThread);
		P13_CardClose(Card);
		exit(1);
	}

/**
*
*  Configure the card for bus controller mode.
*
**/

	P13_CardReset(Card);							/*Reset the PC1553-3 card*/

	errval = P13_BCConfig(BCCFG_DEFAULT,Card);		/*Configure the PC1553-3 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for bus controller mode.",errval);
		CloseHandle(Mailbox.hThread);
		P13_IntUninstall(Card);
		P13_CardClose(Card);
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

	Mailbox.BCMsgs[0] = P13_BCCreateMsg(MSGCRT_DEFAULT,     CMD0,        0, Mailbox.Data, Card);
	Mailbox.BCMsgs[1] = P13_BCCreateMsg(MSGCRT_DEFAULT,     CMD1,        0,         NULL, Card);
	Mailbox.BCMsgs[2] = P13_BCCreateMsg(MSGCRT_RTRT,    RCV_CMD2, XMT_CMD2,         NULL, Card);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.  Also schedule interrupts after each frame. 
*  Note the unique tag value associated with each interrupt
*  that could be used to distinguish each interrupt.
*
**/

	P13_BCSchedFrame(FRAMETIME,       Card);
	P13_BCSchedMsg(Mailbox.BCMsgs[0], Card);
	P13_BCSchedMsg(Mailbox.BCMsgs[1], Card);
	P13_BCSchedMsg(Mailbox.BCMsgs[2], Card);
	P13_BCSchedInt(0x1111,            Card);

	P13_BCSchedFrame(FRAMETIME,       Card);
	P13_BCSchedMsg(Mailbox.BCMsgs[0], Card);
	P13_BCSchedInt(0x2222,            Card);

	P13_BCSchedFrame(FRAMETIME,       Card);
	P13_BCSchedMsg(Mailbox.BCMsgs[0], Card);
	P13_BCSchedMsg(Mailbox.BCMsgs[1], Card);
	P13_BCSchedInt(0x3333,            Card);

	P13_BCSchedFrame(FRAMETIME,       Card);
	P13_BCSchedMsg(Mailbox.BCMsgs[0], Card);
	P13_BCSchedInt(0x4444,            Card);

/**
*
*  Configure the interrupt log list.
*
**/

	errval = P13_IntConfig(INTCFG_ENABLE,1024,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring interrupt log list.",errval);
		CloseHandle(Mailbox.hThread);
		P13_IntUninstall(Card);
		P13_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin transmissions.
*
**/

	for (j=0x1FFFF;j;--j);

	P13_CardStart(Card);

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
	
	Mailbox.fStayAlive = FALSE;		//Clear the fStayAlive flag so the thread commits suicide after the next interrupt

	for (j=0xFFFFFFFF;j && !Mailbox.fHasQuit;--j);	//Waiting for thread to quit

/**
*
*  Uninstall the interrupt handler.
*
**/

	errval = P13_IntUninstall(Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while uninstalling interrupt handler.",errval);
		CloseHandle(Mailbox.hThread);
		P13_IntUninstall(Card);
		P13_CardClose(Card);
		exit(1);
	}

/**
*
*  The PC1553-3 card MUST be closed before exiting the program.
*
**/

	P13_CardStop(Card);						/*Stop the card*/

	P13_IntUninstall(Card);

	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);

	P13_CardClose(Card);					/*Close the card*/
}
