
/**
*
*  PC-MDM-1 DRIVER EXAMPLE 3  Version 1.0  (09/20/1997)
*  Copyright (c) 1997
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- Example 3.
*                      "RT example using interrupts."
*
**/

/**
*
*  This example operates the PC-MDM-1 as an RT.
*
*  It installs in interrupt handler which gets called after
*  every message transfer.  The interrupt handler counts the
*  number of times it is called, and sets a semaphore to
*  signal the foreground process that a message was
*  processed.
*
*  When the foreground process sees the semaphore set, it
*  tests to see if the message was to or from the BC.  If
*  data was received from the BC, it reads the data words
*  and displays the data.  If data was transmitted to the
*  BC, it increments the data in the transmit buffer so the
*  next transmission will transfer new data.
*
*  It assumes the card is in RT mode.
*
**/

#include <windows.h>
#include "mdmw32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	MEMBASE 0xCC00				/*Memory address of PC-MDM-1 card*/
#define IOBASE  0x2C0				/*I/O address of PC-MDM-1 card*/
#define	IRQCHAN 2					/*Interrupt channel of PC-MDM-1 card*/
#define	DMACHAN 1					/*DMA channel of PC-MDM-1 card*/

typedef struct						/*Variables used by the thread*/
{
	BOOL    fWindows95;				/*Flags whether we are running under Windows 95*/
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	BOOL    fHasQuit;				/*Flag indicating the thread has quit*/
	HCARD   Card;					/*Handle of PC-MDM-1 card*/
	INT     Semaphore;				/*Signals when data transmitted or received*/
	INT     Count;					/*Counting variable*/
	INT     Status;					/*Holds status value after interrupt*/
	HANDLE  hEvent;					/*Handle of event*/
	HANDLE  hThread;				/*Handle of thread*/
} ThreadMailbox;

/**
*
*  The following thread is spun off by the main application. 
*  It waits for the specified thread to be released when the
*  PC-MDM-1 card generates an interrupt.  An interrupt is
*  generated when the RT either receives data or transmits
*  data.  The thread then resets the event to allow us to
*  receive more events, sets the semaphore, reads the status
*  register, and waits for the next event.
*
**/

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	while(pMailbox->fStayAlive)
	{
		WaitForSingleObject(pMailbox->hEvent,INFINITE);		//Wait for event

		if (pMailbox->fWindows95)							//Reset event if Windows 95
		{													//to allow another event
			ResetEvent(pMailbox->hEvent);
		}

		pMailbox->Semaphore++;								//Increment semaphore
		pMailbox->Count++;									//Increment count

		pMailbox->Status = MDM_Status(pMailbox->Card);		//Read status value

		MDM_IntReset(pMailbox->Card);						//Reset interrupt from card
	}

	pMailbox->fHasQuit = TRUE;								//Set flag indicating we have quit

	return(0);
}

ThreadMailbox Mailbox;

VOID main(VOID)
{
	INT j;								/*Counter variable*/
	ERRVAL errval;						/*Error return value*/
	USHORT rcvdwd[32];					/*Receive data word buffer*/
	USHORT xmtdwd[32];					/*Transmit data word buffer*/
	DWORD ThreadId;

	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP3  Version 1.0  (09/20/1997)");
	fprintf(stderr,"\nCopyright 1997  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC-MDM-1 Example 3");
	fprintf(stderr,"\n\"RT example using interrupts\"");
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
		Mailbox.fWindows95 = (VER_PLATFORM_WIN32_WINDOWS == OSInfo.dwPlatformId);
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
*  Open the PC-MDM-1 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Mailbox.Card = MDM_CardOpen(MEMBASE,IOBASE,IRQCHAN,DMACHAN);	/*Open the PC-MDM-1 card*/

	if (Mailbox.Card < 0)
	{
		printf("\nError:  Either a PC-MDM-1 is not present at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        or an error occurred (%i) opening the card.",Mailbox.Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Verify that the card is in RT mode.
*
**/

	if (!MDM_IsRT(Mailbox.Card))
	{
		fprintf(stderr,"\nError:  The PC-MDM-1 card is not in RT mode.");
		MDM_CardClose(Mailbox.Card);
		exit(1);
	}

/**
*
*  Create an event object.
*
**/

	if (Mailbox.fWindows95)
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
			MDM_CardClose(Mailbox.Card);
			exit(1);
		}
	}
	else
	{
		Mailbox.hEvent = OpenEvent(
			SYNCHRONIZE,				//Desired access
			FALSE,						//Inherit flag
			"PCMDMInterrupt");			//Pointer to event-object name  

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			MDM_CardClose(Mailbox.Card);
			exit(1);
		}
	}

/**
*
*  Create a thread.
*
**/

	Mailbox.fStayAlive = TRUE;
	Mailbox.fHasQuit   = FALSE;
	Mailbox.Count      = 0;
	Mailbox.Status     = 0;
	Mailbox.Semaphore  = 0;

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
		MDM_CardClose(Mailbox.Card);
		exit(1);
	}

/**
*
*  Install the interrupt handler.
*
**/

	errval = MDM_IntInstall(Mailbox.hEvent,Mailbox.Card);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while installing interrupt handler.",errval);
		printf("\nGetLastError returned %d",GetLastError());
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		MDM_CardClose(Mailbox.Card);
		exit(1);
	}

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");

	while(!kbhit())
	{
		printf("\rstatus=%02XH count=%04XH",Mailbox.Status,Mailbox.Count);

/**
*
*  When semaphore is non-zero, message was received or transmitted.
*
**/

		if (Mailbox.Semaphore)
		{
			Mailbox.Semaphore=0;						/*Clear semaphore*/

/**
*
*  If the last message was transmit to the BC, change the
*  transmit data words for the next message.
*
**/

			if (Mailbox.Status & STATUS_XMT)			/*If last message was transmit to BC*/
			{
				for (j=0;j<32;++j) ++xmtdwd[j];			/*Modify transmit data*/

				MDM_XmtWr(xmtdwd,32,Mailbox.Card);		/*Write new transmit data to card*/
			}

/**
*
*  If the last message was receive from the BC, read the
*  data words received and possibly do something with them.
*
**/

			if (!(Mailbox.Status & STATUS_XMT))					/*Else last message was receive from BC*/
			{
				MDM_RcvRd(rcvdwd,32,Mailbox.Card);				/*Read the received data words from card*/

				printf("\n");									/*Print them*/
				for (j=0;j<32;++j) printf("%04X ",rcvdwd[j]);	/*Print them*/
			}
		}
	}

/**
*
*  Clear the flag keeping the thread alive and wait for the
*  thread to quit.
*
**/

	printf("\nWaiting for the thread to quit.");
	
	Mailbox.fStayAlive = FALSE;		//Clear the fStayAlive flag so the thread commits suicide after the next interrupt

	if (Mailbox.fWindows95)								//If Windows 95
	{
		for (j=0xFFFFFFFF;j && !Mailbox.fHasQuit;--j);	//Waiting for thread to quit
	}

/**
*
*  Uninstall the interrupt handler.
*
**/

	errval = MDM_IntUninstall(Mailbox.Card);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while uninstalling interrupt handler.",errval);
		printf("\nGetLastError returned %d",GetLastError());
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		MDM_CardClose(Mailbox.Card);
		exit(1);
	}

/**
*
*  The PC-MDM-1 card MUST be closed before exiting the program.
*
**/

	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);

	MDM_CardClose(Mailbox.Card);			/*Close the card*/
}
