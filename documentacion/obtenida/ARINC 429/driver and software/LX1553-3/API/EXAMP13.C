
/**
*
*  LP1553-3 and LC1553-3 DRIVER EXAMPLE 13  Version 1.0  (10/29/2001)
*  Copyright (c) 1997-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP13.C -- Example 13.
*                      "Polled Interrupts"
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
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	BOOL    fHasQuit;				/*Flag indicating the thread has quit*/
	HCARD   Card;					/*Handle of L13 card*/
	ULONG   Count;					/*Counting variable*/
	HANDLE  hThread;				/*Handle of thread object*/
	MSGADDR BCMsgs[3];				/*Address of three BC messages*/
	USHORT  Data[3];				/*Data values transmitted by BCMsgs[0]*/
} ThreadMailbox;

/**
*
*  The following thread is spun off by the main application. 
*  It polls the interrupt log list of the card.
*
**/

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	USHORT Type;
	USHORT Info;

	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	while(pMailbox->fStayAlive)
	{
		if (L13_IntRd(&Type,&Info,pMailbox->Card))		//Read entry from interrupt log list
		{
			pMailbox->Count++;								//Increment counter

			pMailbox->Data[0] += 2;							//Calculate the new data words
			pMailbox->Data[1] += 4;
			pMailbox->Data[2] += 6;

			L13_MsgDataWr(pMailbox->Data, 3, pMailbox->BCMsgs[0], pMailbox->Card);	//Write the new data words
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
	USHORT  MsgErrors;

	INT j;

	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP13  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1997-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Example 13");
	fprintf(stderr,"\n\"Polling Interrupts\"");
	fprintf(stderr,"\n");

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
*  Create a thread.
*
**/

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
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardStop(Card);						/*Stop the card*/

	L13_IntUninstall(Card);
	CloseHandle(Mailbox.hThread);
	L13_CardClose(Card);					/*Close the card*/
}
