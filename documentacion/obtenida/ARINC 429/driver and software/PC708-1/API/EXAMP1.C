
/**
*
*  PC708-1 DRIVER EXAMPLE 1  Version 1.1  (07/28/1998)
*  Copyright (c) 1998
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP1.C -- Example 1.
*                      "Transmitter Interrupt example"
*
**/

/**
*
*  This example configures the PC708-1 to transmit a schedule
*  of four messages at a rate of 50Hz.  The messages are
*  automatically assigned the numbers 0 through 3.
*
*  An interrupt frequency of 2 messages is also specified. 
*  As a result, message 1 and message 3 generate interrupt an
*  interrupt after they are transmitted, but message 0 and
*  message 2 do not.
*
*  An interrupt handler is also installed.  When an interrupt
*  is received from the PC708-1 card, the interrupt handler
*  reads the next entry from the interrupt log list.  The
*  entry contains the number of the message that caused the
*  interrupt.  When the interrupt for message 1 is received,
*  both message 0 and message 1 are updated.  When the
*  interrupt for message 3 is received, both message 2 and
*  message 3 are updated.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include "p71w32.h"

#define	MEMBASE 0xCC00				/*Memory address of PC708-1 card*/
#define IOBASE  0x2C0				/*I/O address of PC708-1 card*/
#define	IRQCHAN 2					/*Interrupt channel of PC708-1 card*/
#define	DMACHAN 1					/*DMA channel of PC708-1 card*/

#define	FRAMEFREQ	50				/*Frame frequency of 50Hz*/
#define INTFREQ		2				/*Generate an interrupt after every 2nd message*/
#define	FRAMECOUNT	4				/*Transmit a total of 4 messages*/

USHORT Data0[100];					/*Data to transmit for message 0*/
USHORT Data1[100];					/*Data to transmit for message 1*/
USHORT Data2[100];					/*Data to transmit for message 2*/
USHORT Data3[100];					/*Data to transmit for message 3*/

typedef struct						/*Variables used by the thread*/
{
	BOOL    fWindows95;				/*Flags whether we are running under Windows 95*/
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	BOOL    fHasQuit;				/*Flag indicating the thread has quit*/
	HCARD   Card;					/*Handle of PC708-1 card*/
	ULONG   Count;					/*Counting variable*/
	HANDLE  hEvent;					/*Handle of event*/
	HANDLE  hThread;				/*Handle of event*/
} ThreadMailbox;

/**
*
*  The interrupt handler reads the next entry from the
*  interrupt log list.  The entry contains the number of the
*  message that caused the interrupt.  The configuration of
*  the board is such that message 1 and message 3 will
*  generate interrupts, but message 0 and message 2 will not. 
*  As a result, when we receive the interrupt from message 1,
*  we will update the data for both message 0 and message 1. 
*  When we receive the interrupt from message 3, we will
*  update the data for both message 2 and message 3.
*
**/

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	USHORT j;
	USHORT framenum;

	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	pMailbox->fStayAlive = TRUE;
	pMailbox->fHasQuit   = FALSE;
	pMailbox->Count      = 0;

	while(pMailbox->fStayAlive)
	{
		if (WaitForSingleObject(pMailbox->hEvent,200) == WAIT_TIMEOUT)
		{
		}
		else
		{
			if (pMailbox->fWindows95)							//Reset event if Windows 95
			{													//to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			pMailbox->Count++;									//Increment counter

			PC708_IntRd(NULL,&framenum,pMailbox->Card);

			if (framenum==1)
			{
				PC708_XmtRd(Data0,0,pMailbox->Card);		/*Read data for message 0*/
				PC708_XmtRd(Data1,1,pMailbox->Card);		/*Read data for message 1*/

				for (j=0;j<100;++j)
				{
					Data0[j]+=4;				/*Modify the data for message 0*/
					Data1[j]+=4;				/*Modify the data for message 1*/
				}

				PC708_XmtWr(Data0,0,pMailbox->Card);		/*Write the data for message 0*/
				PC708_XmtWr(Data1,1,pMailbox->Card);		/*Write the data for message 1*/

				PC708_IntReset(pMailbox->Card);
			}

			else if (framenum==3)
			{
				PC708_XmtRd(Data2,2,pMailbox->Card);		/*Read data for message 2*/
				PC708_XmtRd(Data3,3,pMailbox->Card);		/*Read data for message 3*/

				for (j=0;j<100;++j)
				{
					Data2[j]+=4;				/*Modify the data for message 2*/
					Data3[j]+=4;				/*Modify the data for message 3*/
				}
	
				PC708_XmtWr(Data2,2,pMailbox->Card);		/*Write the data for message 2*/
				PC708_XmtWr(Data3,3,pMailbox->Card);		/*Write the data for message 3*/

				PC708_IntReset(pMailbox->Card);
			}
		}
	}

	pMailbox->fHasQuit = TRUE;								//Set flag indicating we have quit

	return(0);
}

void main(void)
{
	DWORD ThreadId;
	ThreadMailbox Mailbox;
	BOOL fWindows95;

	HCARD   Card;
	ERRVAL  errval;
	USHORT  MsgErrors;
	ULONG   j;

	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP1  Version 1.1  (07/28/1998)");
	fprintf(stderr,"\nCopyright 1998  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC708-1 Example 1");
	fprintf(stderr,"\n\"Transmitter Interrupt example\"");
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
		fWindows95 = (VER_PLATFORM_WIN32_WINDOWS == OSInfo.dwPlatformId);
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
*  Open the PC708-1 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = PC708_CardOpen(MEMBASE,IOBASE,IRQCHAN,DMACHAN);	/*Open the PC708-1 card*/

	if (Card < 0)
	{
		printf("\nError:  Either a PC708-1 is not present at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        or an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

	PC708_CardReset(Card);

/**
*
*  Create an event object.
*
**/

	if (fWindows95)
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
			PC708_CardClose(Card);
			exit(1);
		}
	}
	else
	{
		Mailbox.hEvent = OpenEvent(
			SYNCHRONIZE,				//Desired access
			FALSE,						//Inherit flag
			"PC708Interrupt");			//Pointer to event-object name  

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			PC708_CardClose(Card);
			exit(1);
		}
	}

/**
*
*  Create a thread.
*
**/

	Mailbox.fWindows95 = fWindows95;
	Mailbox.Card       = Card;

	Mailbox.fStayAlive = TRUE;
	Mailbox.fHasQuit   = FALSE;
	Mailbox.Count      = 0;

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
		PC708_CardClose(Card);
		exit(1);
	}

/**
*
*  Install the interrupt handler for the card.
*
**/

	errval = PC708_IntInstall(Mailbox.hEvent,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  Unable to install the interrupt handler for the");
		fprintf(stderr,"\n        PC708-1 card at memory %04XH, I/O %03XH.",MEMBASE,IOBASE);
		fprintf(stderr,"\n");
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		PC708_CardClose(Card);
		exit(1);
	}

/**
*
*  Configure the transmitter of the PC708-1 card.
*
**/

	PC708_CardReset(Card);
	
	errval = PC708_XmtConfigEx(FRAMEFREQ,INTFREQ,FRAMECOUNT,Card);	/*Configure the PC708-1 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the transmitter.",errval);
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		PC708_CardClose(Card);
		exit(1);
	}

/**
*
*  Create the data for the three messages.
*
**/

	for (j=0;j<100;++j)
	{
		Data0[j]=0;					/*Create data for message 0*/
		Data1[j]=1;					/*Create data for message 1*/
		Data2[j]=2;					/*Create data for message 2*/
		Data3[j]=3;					/*Create data for message 2*/
	}

/**
*
*  Write the data for the three messages.
*
**/

	PC708_XmtWr(Data0,0,Card);		/*Write the data for message 0*/
	PC708_XmtWr(Data1,1,Card);		/*Write the data for message 1*/
	PC708_XmtWr(Data2,2,Card);		/*Write the data for message 2*/
	PC708_XmtWr(Data3,3,Card);		/*Write the data for message 3*/

/**
*
*  Start the card to begin transmissions.
*
**/

	PC708_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");
	
	while (!kbhit())
	{
		printf("\rInterrupt Count: %-8lu",Mailbox.Count);
	}

/**
*
*  Stop the card to halt transmissions.
*
**/

	PC708_CardStop(Card);						/*Stop the card*/

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
*  Remove the interrupt handler from memory.
*
**/

	errval = PC708_IntUninstall(Card);

	if (errval<0)
	{
		fprintf(stderr,"\nError:  Unable to uninstall the interrupt handler for the");
		fprintf(stderr,"\n        PC708-1 card at memory %04XH, I/O %03XH.",MEMBASE,IOBASE);
		fprintf(stderr,"\n        Error = %i",errval);
		fprintf(stderr,"\n");
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		PC708_CardClose(Card);
		exit(1);
	}

/**
*
*  Release handles.
*
**/

	if (Mailbox.hThread) CloseHandle(Mailbox.hThread);
	if (Mailbox.hEvent)  CloseHandle(Mailbox.hEvent);

/**
*
*  The PC708-1 card MUST be closed before exiting the program.
*
**/

	PC708_CardClose(Card);					/*Close the card*/
}
