
/**
*
*  LP1553-3 and LC1553-3 DRIVER EXAMPLE 12  Version 1.0  (10/29/2001)
*  Copyright (c) 1997-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP12.C -- Example 12.
*                      "BC Transmission of Data Using a Ping-Pong Buffer"
*
**/

/**
*
*  This example configures the L13 as a bus controller
*  to transmit a schedule of one message.  The message is
*  transmitted at a frequency of 10Hz (or every 100ms).
*
*  A ping-pong buffer is configured for the message.  After
*  the card is started, the program writes new data to the
*  message as fast as possible.  The ping-pong buffer
*  prevents the message from transmitting old data mixed in
*  with new data.
*
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of L13 card*/

#define CMD 0x0820					/*Command word for message*/

#define	FRAMETIME 100000			/*Frame time in microseconds*/

void main(void)
{
	HCARD   Card;
	ERRVAL  errval;
	MSGADDR BCList;
	USHORT  MsgErrors;
	USHORT  Data[32];
	INT     Result;
	INT j;

	fprintf(stderr,"\nEXAMP12  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1997-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Example 12");
	fprintf(stderr,"\n\"BC Transmission of Data Using a Ping-Pong Buffer\"");
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

	BCList = L13_BCCreateList(LISTCRT_PINGPONG,0,MSGCRT_DEFAULT,CMD,0,NULL,Card);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	L13_BCSchedFrame(FRAMETIME, Card);
	L13_BCSchedMsg(BCList,      Card);

/**
*
*  Initialize the data words.
*
**/

	for (j=0;j<32;++j) Data[j]=0;

	L13_ListDataWr(Data,32,BCList,Card);

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
		for (j=0;j<32;++j) ++Data[j];
		L13_ListDataWr(Data,32,BCList,Card);
	}

/**
*
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardStop(Card);						/*Stop the card*/
	L13_CardClose(Card);					/*Close the card*/
}
