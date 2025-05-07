
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 11  Version 1.0  (10/29/2001)
*  Copyright (c) 2000-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP11.C -- Example 11.
*                      "Receiver Interrupt polling example"
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
*  Unlike Example 8, this program will poll the interrupt log list
*  to determine if an interrupt event has occurred.
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
	BOOL      fStayAlive;           /*Flag indicating the thread should stay alive*/
	BOOL      fHasQuit;             /*Flag indicating the thread has quit*/
	HCARD     Card;                 /*Handle of LP429-3 card*/
	ULONG     Count;                /*Counting variable*/
	HANDLE    hThread;              /*Handle of event*/
	MSGSTRUCT msgdefault;           /*Message*/
	MSGSTRUCT latitude;             /*Message*/
	MSGSTRUCT longitude;            /*Message*/
} ThreadMailbox;

/**
*
*  The following thread is spun off by the main application. 
*  It polls the interrupt log list of the card using L43_IntRd().
*
**/

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	USHORT Type;
	ULONG  Info;
	ULONG  msgaddr;

	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	while(pMailbox->fStayAlive)
	{
		if (L43_IntRd(&Type,&Info,pMailbox->Card))			//Read entry from interrupt log list
		{
			pMailbox->Count++;								//Increment counter

			msgaddr = Info;									//Info value is message address

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
		}
	}

	pMailbox->fHasQuit = TRUE;								//Set flag indicating we have quit

	return(0);
}

void main(void)
{
	DWORD ThreadId;
	ThreadMailbox Mailbox;

	HCARD   Card;
	ERRVAL  errval;
	INT     rcvchan;
	ULONG   j;

	fprintf(stderr,"\nEXAMP11  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright (c) 2000-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 11");
	fprintf(stderr,"\n\"Receiver interrupt polling example\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);                  /*Open the L43 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L43 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Create a thread.
*
**/

	Mailbox.Card       = Card;

	Mailbox.fStayAlive = TRUE;
	Mailbox.fHasQuit   = FALSE;
	Mailbox.Count      = 0;

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

	L43_CardReset(Card);                         /*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG_AUTOSPEED,rcvchan,Card);   /*Configure channel*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,rcvchan);
		CloseHandle(Mailbox.hThread);
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
*  The L43 card MUST be closed before exiting the program.
*
**/

	CloseHandle(Mailbox.hThread);
	L43_CardClose(Card);
}
