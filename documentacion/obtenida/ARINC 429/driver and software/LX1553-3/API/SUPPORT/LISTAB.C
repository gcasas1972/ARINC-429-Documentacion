
/**
*
*  LP1553-3 and LC1553-3 DRIVER LISTAB EXAMPLE  Version 1.0  (01/29/2002)
*  Copyright (c) 2002
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   LISTAB.C -- List buffer A/B switching example.
*
**/

/**
*
*  This example configures the L13 as a bus controller to
*  transmit a schedule of three messages, each using one of
*  the three types of list buffers.  By pressing a key, each
*  list buffer can be modified to transmit on a different
*  bus.
*
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of L13 card*/

#define CMDPING 0x0C21				/*Command word for message*/
#define CMDFIFO 0x0822				/*Command word for message*/
#define CMDCIRC 0x0823				/*Command word for message*/

#define	FRAMETIME 100000			/*Frame time in microseconds*/

#define BUSA 0						/*Select bus A*/
#define BUSB 1						/*Select bus B*/

ERRVAL L13_ListFieldWrBus(BOOL busab,LISTADDR listaddr,HCARD handleval)
{
	INT j;
	MSGADDR msgaddr;
	ULONG fieldval;

	for (j=0;;++j)
	{
		msgaddr = L13_ListAddr(j,listaddr,handleval);
		if (!msgaddr) return(ERR_NONE);

		fieldval = L13_MsgFieldRd(FIELD_FLAG1,msgaddr,handleval);
		fieldval = (busab) ? fieldval|1L : fieldval&~1L;
		L13_MsgFieldWr(fieldval,FIELD_FLAG1,msgaddr,handleval);
	}

	return(ERR_NONE);
}

void main(void)
{
	HCARD   Card;
	ERRVAL  errval;
	MSGADDR BCListPing;
	MSGADDR BCListFifo;
	MSGADDR BCListCirc;
	INT     Result;
	INT j;
	BOOL done;
	INT ch;

	fprintf(stderr,"\nLISTAB  Version 1.0  (01/29/2002)");
	fprintf(stderr,"\nCopyright 2002  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 ListAB Example");
	fprintf(stderr,"\n\"List buffer A/B switching example\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L13 card with the specified card number.  A
*  handle to the card is returned which is tested to
*  determine if an error occurred.
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
*  Configure the card for bus controller mode.
*
**/

	L13_CardReset(Card);							/*Reset the L13 card*/

	errval = L13_BCConfig(BCCFG_DEFAULT,Card);		/*Configure the L13 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for bus controller mode.",errval);
		L13_CardClose(Card);
		exit(1);
	}

/**
*
*  Create the message records for each of the three messages.
*
**/

	BCListPing = L13_BCCreateList(LISTCRT_PINGPONG,10,MSGCRT_DEFAULT,CMDPING,0,NULL,Card);
	BCListFifo = L13_BCCreateList(LISTCRT_FIFO,    10,MSGCRT_DEFAULT,CMDFIFO,0,NULL,Card);
	BCListCirc = L13_BCCreateList(LISTCRT_CIRCULAR,10,MSGCRT_DEFAULT,CMDCIRC,0,NULL,Card);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	L13_BCSchedFrame(FRAMETIME, Card);
	L13_BCSchedMsg(BCListPing,  Card);
	L13_BCSchedMsg(BCListFifo,  Card);
	L13_BCSchedMsg(BCListCirc,  Card);

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

	printf("\nPress p/P to modify ping-pong buffer to transmit on bus A/B.");
	printf("\nPress f/F to modify FIFO      buffer to transmit on bus A/B.");
	printf("\nPress c/C to modify circular  buffer to transmit on bus A/B.");
	printf("\nPress ESC to exit.");
	printf("\n");

	for (done=0;!done;)
	{
		if (kbhit())
		{
			ch = getch();

			switch(ch)
			{
				case 27:
					done=1;
					break;

				case 'p': printf("\nPingpong on bus A"); L13_ListFieldWrBus(BUSA,BCListPing,Card); break;
				case 'P': printf("\nPingpong on bus B"); L13_ListFieldWrBus(BUSB,BCListPing,Card); break;
				case 'f': printf("\nFifo on bus A");     L13_ListFieldWrBus(BUSA,BCListFifo,Card); break;
				case 'F': printf("\nFifo on bus B");     L13_ListFieldWrBus(BUSB,BCListFifo,Card); break;
				case 'c': printf("\nCircular on bus A"); L13_ListFieldWrBus(BUSA,BCListCirc,Card); break;
				case 'C': printf("\nCircular on bus B"); L13_ListFieldWrBus(BUSB,BCListCirc,Card); break;
			}
		}
	}

/**
*
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardStop(Card);						/*Stop the card*/
	L13_CardClose(Card);					/*Close the card*/
}
