
/**
*
*  LP708-1 and LC708-1 DRIVER EXAMPLE 1  Version 1.0  (01/19/2001)
*  Copyright (c) 1999-2001
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
*  This example configures the L71 to transmit a schedule
*  of four messages at a rate of 50Hz.  The messages are
*  automatically assigned the numbers 0 through 3.
*
*  An interrupt frequency of 2 messages is also specified. 
*  As a result, message 1 and message 3 generate an
*  interrupt after they are transmitted, but message 0 and
*  message 2 do not.
*
*  An interrupt handler is also installed.  When an interrupt
*  is received from the L71 card, the interrupt handler
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
#include "l71w32.h"

#define	CARDNUM 0                   /*Card number of L71 card*/

#define	FRAMEFREQ	50              /*Frame frequency of 50Hz*/
#define INTFREQ		2               /*Generate an interrupt after every 2nd message*/
#define	FRAMECOUNT	4               /*Transmit a total of 4 messages*/

USHORT Data0[100];                  /*Data to transmit for message 0*/
USHORT Data1[100];                  /*Data to transmit for message 1*/
USHORT Data2[100];                  /*Data to transmit for message 2*/
USHORT Data3[100];                  /*Data to transmit for message 3*/

typedef struct                      /*Variables used by the thread*/
{
	BOOL    fWindowsNT40;           /*Flags whether we are running under Windows NT 4.0*/
	BOOL    fStayAlive;             /*Flag indicating the thread should stay alive*/
	BOOL    fHasQuit;               /*Flag indicating the thread has quit*/
	HCARD   Card;                   /*Handle of L71 card*/
	ULONG   Hits;                   /*Counting variable*/
	ULONG   Misses;                 /*Counting variable*/
	HANDLE  hEvent;                 /*Handle of event*/
	HANDLE  hThread;                /*Handle of event*/
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

	while(pMailbox->fStayAlive)
	{
		if (WaitForSingleObject(pMailbox->hEvent,200) == WAIT_TIMEOUT)
		{
			pMailbox->Misses++;                     /*Increment counter*/
		}
		else
		{
			if (!(pMailbox->fWindowsNT40))          //Reset event if not Windows NT 4.0
			{                                       //to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			pMailbox->Hits++;                       /*Increment counter*/

			L71_IntRd(NULL,&framenum,pMailbox->Card);

			if (framenum==1)
			{
				L71_XmtRd(Data0,0,pMailbox->Card);  /*Read data for message 0*/
				L71_XmtRd(Data1,1,pMailbox->Card);  /*Read data for message 1*/

				for (j=0;j<100;++j)
				{
					Data0[j]+=4;                    /*Modify the data for message 0*/
					Data1[j]+=4;                    /*Modify the data for message 1*/
				}

				L71_XmtWr(Data0,0,pMailbox->Card);  /*Write the data for message 0*/
				L71_XmtWr(Data1,1,pMailbox->Card);  /*Write the data for message 1*/

				L71_IntReset(pMailbox->Card);
			}

			else if (framenum==3)
			{
				L71_XmtRd(Data2,2,pMailbox->Card);  /*Read data for message 2*/
				L71_XmtRd(Data3,3,pMailbox->Card);  /*Read data for message 3*/

				for (j=0;j<100;++j)
				{
					Data2[j]+=4;                    /*Modify the data for message 2*/
					Data3[j]+=4;                    /*Modify the data for message 3*/
				}
	
				L71_XmtWr(Data2,2,pMailbox->Card);  /*Write the data for message 2*/
				L71_XmtWr(Data3,3,pMailbox->Card);  /*Write the data for message 3*/

				L71_IntReset(pMailbox->Card);
			}
		}
	}

	pMailbox->fHasQuit = TRUE;                      //Set flag indicating we have quit

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
	ULONG   j;

	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP1  Version 1.0  (01/19/2001)");
	fprintf(stderr,"\nCopyright 1999-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP708-1 and LC708-1 Example 1");
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
*  Open the L71 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L71_CardOpen(CARDNUM);                     /*Open the L71 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L71 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

	L71_CardReset(Card);

/**
*
*  Create an event object.
*
**/

	if (fWindowsNT40)
	{
		if (L71_CardGetInfo(INFOTYPE_PLAT,Card) == 'LP')    //Card is LP708-1
		{
			Mailbox.hEvent = OpenEvent(
				SYNCHRONIZE,                //Desired access
				FALSE,                      //Inherit flag
				"LP708Interrupt");          //Pointer to event-object name
		}
		else                                                //Card is LC708-1
		{
			Mailbox.hEvent = OpenEvent(
				SYNCHRONIZE,                //Desired access
				FALSE,                      //Inherit flag
				"LC708Interrupt");          //Pointer to event-object name
		}

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			L71_CardClose(Card);
			exit(1);
		}
	}
	else
	{
		Mailbox.hEvent = CreateEvent(
			NULL,
			TRUE,                       //Flag for manual-reset event 
			FALSE,                      //Flag for initial state 
			NULL);                      //Pointer to event-object name  

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			L71_CardClose(Card);
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

	Mailbox.fStayAlive = TRUE;
	Mailbox.fHasQuit   = FALSE;
	Mailbox.Hits      = 0;

	Mailbox.hThread = CreateThread(
		NULL,                   //Use the default security attributes  
		0x10000,                //Initial thread stack size
		InterruptServiceThread, //Pointer to thread function 
		(LPVOID)&Mailbox,       //Argument for new thread 
		0,                      //Creation flags 
		&ThreadId);             //Pointer to returned thread identifier 

	if (Mailbox.hThread == NULL)
	{
		printf("\nThread creation failed");
		printf("\nGetLastError = %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		L71_CardClose(Card);
		exit(1);
	}

/**
*
*  Install the interrupt handler for the card.
*
**/

	errval = L71_IntInstall(Mailbox.hEvent,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while installing interrupt handler.",errval);
		fprintf(stderr,"\nGetLastError returned %d",GetLastError());
		fprintf(stderr,"\n");
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		L71_CardClose(Card);
		exit(1);
	}

/**
*
*  Configure the transmitter of the L71 card.
*
**/

	L71_CardReset(Card);
	
	errval = L71_XmtConfigEx(FRAMEFREQ,INTFREQ,FRAMECOUNT,Card);   /*Configure the L71 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the transmitter.",errval);
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		L71_CardClose(Card);
		exit(1);
	}

/**
*
*  Create the data for the three messages.
*
**/

	for (j=0;j<100;++j)
	{
		Data0[j]=0;                 /*Create data for message 0*/
		Data1[j]=1;                 /*Create data for message 1*/
		Data2[j]=2;                 /*Create data for message 2*/
		Data3[j]=3;                 /*Create data for message 2*/
	}

/**
*
*  Write the data for the three messages.
*
**/

	L71_XmtWr(Data0,0,Card);        /*Write the data for message 0*/
	L71_XmtWr(Data1,1,Card);        /*Write the data for message 1*/
	L71_XmtWr(Data2,2,Card);        /*Write the data for message 2*/
	L71_XmtWr(Data3,3,Card);        /*Write the data for message 3*/

/**
*
*  Start the card to begin transmissions.
*
**/

	L71_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");
	
	while (!kbhit())
	{
		printf("\rInterrupt Count: %-8lu hits, %-8lu misses",Mailbox.Hits,Mailbox.Misses);
	}

/**
*
*  Stop the card to halt transmissions.
*
**/

	L71_CardStop(Card);

/**
*
*  Clear the flag keeping the thread alive and wait for the
*  thread to quit.
*
**/

	printf("\nWaiting for the thread to quit.");
	
	Mailbox.fStayAlive = FALSE;                     //Clear the fStayAlive flag so the thread commits suicide after the next interrupt

	for (j=0xFFFFFFFF;j && !Mailbox.fHasQuit;--j);  //Waiting for thread to quit

/**
*
*  Uninstall the interrupt handler.
*
**/

	errval = L71_IntUninstall(Card);

	if (errval<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while uninstalling interrupt handler.",errval);
		fprintf(stderr,"\n");
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		L71_CardClose(Card);
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
*  The L71 card MUST be closed before exiting the program.
*
**/

	L71_CardClose(Card);
}
