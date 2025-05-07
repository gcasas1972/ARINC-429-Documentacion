
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 8  Version 1.0  (10/29/2001)
*  Copyright (c) 1998-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP8.C -- Example 8.
*                      "Receiver Interrupt example"
*
**/

/**
*
*  This program is example program one written to incoorporate
*  the use of interrupts.  An interrupt serivce thread is created
*  and will check to see if the card has issued an interrupt.
*  The thread will read the interrupt out of the card using the 
*  L43_IntRd function.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include "l43w32.h"

#define	CARDNUM 0                   /*Card number of L43 card*/

typedef struct                      /*Variables used by the thread*/
{
	BOOL      fWindowsNT40;         /*Flags whether we are running under Windows NT 4.0*/
	BOOL      fStayAlive;           /*Flag indicating the thread should stay alive*/
	BOOL      fHasQuit;             /*Flag indicating the thread has quit*/
	HCARD     Card;                 /*Handle of LP429-3 card*/
	ULONG     Hits;                 /*Counting variable*/
	ULONG     Misses;               /*Counting variable*/
	HANDLE    hEvent;               /*Handle of event*/
	HANDLE    hThread;              /*Handle of event*/
	MSGSTRUCT msgdefault;           /*Message*/
	MSGSTRUCT latitude;             /*Message*/
	MSGSTRUCT longitude;            /*Message*/
} ThreadMailbox;

/**
*
*  This is the interrupt service thread.  It will read 
*  data from the interrupt log list using L43_IntRd(), read 
*  the data from the message associated with the interrupt,
*  and then pass that data along to the main application.
*
**/

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	ULONG msgaddr;

	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	while(pMailbox->fStayAlive)
	{
		if (WaitForSingleObject(pMailbox->hEvent,200) == WAIT_TIMEOUT)
		{
			pMailbox->Misses++;               //Increment counter
		}
		else
		{
			if (!(pMailbox->fWindowsNT40))    //Reset event if not Windows NT 4.0
			{                                 //to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			pMailbox->Hits++;                 //Increment counter

			L43_IntRd(NULL,&msgaddr,pMailbox->Card);

			if (msgaddr == pMailbox->msgdefault.addr)
			{
				pMailbox->msgdefault.data = L43_MsgDataRd(msgaddr,pMailbox->Card);
			}
			else if (msgaddr == pMailbox->latitude.addr)
			{
				pMailbox->latitude.data = L43_MsgDataRd(msgaddr,pMailbox->Card);
			}
			else if (msgaddr == pMailbox->longitude.addr)
			{
				pMailbox->longitude.data = L43_MsgDataRd(msgaddr,pMailbox->Card);
			}

			L43_IntReset(pMailbox->Card);
		}
	}

	pMailbox->fHasQuit = TRUE;                //Set flag indicating we have quit

	return(0);
}

void main(void)
{
	DWORD ThreadId;
	ThreadMailbox Mailbox;
	BOOL fWindowsNT40;

	HCARD   Card;
	ERRVAL  errval;
	INT     rcvchan;
	ULONG   j;

	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP8  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1998-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 8");
	fprintf(stderr,"\n\"Receiver interrupt example\"");
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
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);               /*Open the L43 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L43 card number %u is not present, or",CARDNUM);
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
		if (L43_CardGetInfo(INFOTYPE_PLAT,Card) == 'LP')   //Card is LP429-3
		{
			Mailbox.hEvent = OpenEvent(
				SYNCHRONIZE,                //Desired access
				FALSE,                      //Inherit flag
				"LP429Interrupt");          //Pointer to event-object name
		}
		else                                               //Card is LC429-3
		{
			Mailbox.hEvent = OpenEvent(
				SYNCHRONIZE,                //Desired access
				FALSE,                      //Inherit flag
				"LC429Interrupt");          //Pointer to event-object name
		}

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			L43_CardClose(Card);
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
			L43_CardClose(Card);
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
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Install the interrupt handler for the card.
*
**/

	errval = L43_IntInstall(Mailbox.hEvent,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  Unable to install the interrupt handler for the");
		fprintf(stderr,"\n        L43 card number %u.",Card);
		fprintf(stderr,"\n");
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Find the first receive channel.
*
**/

	for (rcvchan=0;rcvchan<8;++rcvchan) if (L43_IsRcvChan(rcvchan,Card)) break;

	if (rcvchan == 8)
	{
		printf("\nError:  No receive channels present in L43 cardnum %d.",CARDNUM);
		printf("\n");
		exit(1);
	}

	fprintf(stderr,"\nUsing receive channel %d",rcvchan);
	fprintf(stderr,"\n");

/**
*
*  Configure rcvchan for auto speed detection.
*
**/

	L43_CardReset(Card);                                /*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG_AUTOSPEED,rcvchan,Card);  /*Configure channel*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,rcvchan);
		L43_IntUninstall(Card);
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Before any messages can be received, filters must be set
*  for the receive channel.  First, the default filter is
*  created.  Then, two filters are set for the two messages
*  of interest.
*
*  Each message is configured to cause an interrupt.
*
**/

	Mailbox.msgdefault.addr = L43_FilterDefault(MSGCRT_INT,rcvchan,Card); 
	Mailbox.latitude.addr   = L43_FilterSet(MSGCRT_INT,0310,SDIALL,rcvchan,Card);
	Mailbox.longitude.addr  = L43_FilterSet(MSGCRT_INT,0311,SDIALL,rcvchan,Card);

/**
*
*  Init data values to zero.
*
**/

	Mailbox.msgdefault.data = 0;
	Mailbox.latitude.data   = 0;
	Mailbox.longitude.data  = 0;

/**
*
*  Configure the interrupt log list.
*
**/

	errval = L43_IntConfig(INTCFG_ENABLE,1024,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring interrupt log list.",errval);
		L43_IntUninstall(Card);
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Start operation of the card.
*
**/

	L43_CardStart(Card);

/**
*
*  Display data on the screen.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		printf("\r");
		printf("Default=%08lX ",Mailbox.msgdefault.data);
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
	
	Mailbox.fStayAlive = FALSE;                     //Clear the fStayAlive flag so the thread commits suicide after the next interrupt

	for (j=0xFFFFFFFF;j && !Mailbox.fHasQuit;--j);  //Waiting for thread to quit

/**
*
*  Stop the L43 card.
*
**/

	L43_CardStop(Card);

/**
*
*  Uninstall the interrupt handler.
*
**/

	errval = L43_IntUninstall(Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while uninstalling interrupt handler.",errval);
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  The L43 card MUST be closed before exiting the program.
*
**/

	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);
	L43_CardClose(Card);
}
