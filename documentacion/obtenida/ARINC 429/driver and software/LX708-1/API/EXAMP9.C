
/**
*
*  LP708-1 and LC708-1 DRIVER EXAMPLE 9  Version 1.0  (01/19/2001)
*  Copyright (c) 1999-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP9.C -- Example 9.
*                      "Receiver Sequential Block Read example"
*
**/

/**
*
*  This example configures the L71 to receive messages.  
*  Data is read out of the sequential monitor using the
*  RcvMonBlkRd() function.  The program displays status
*  information about how many blocks it read from the card.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

#include "l71w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0                   /*Card number of L71 card*/

USHORT MonData[128*109];            /*Data buffer to hold monitor records*/
HCARD Card;							/*Handle of card to access*/

void main(void)
{
	ERRVAL errval;
	ULONG  retcount;
	ULONG  blkcount;
	ULONG  totalcount=0;
	BOOL   monflag;
	
	fprintf(stderr,"\nEXAMP9  Version 1.0  (01/19/2001)");
	fprintf(stderr,"\nCopyright 1999-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP708-1 and LC708-1 Example 9");
	fprintf(stderr,"\n\"Receiver Sequential Block Read example\"");
	fprintf(stderr,"\n");

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
*  Configure the receiver of the L71 card.
*
**/

	errval = L71_RcvConfig(Card);			/*Configure the L71 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the receiver.",errval);
		L71_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin receiving.
*
**/

	L71_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.\n");
	printf("\n");
	
	while (!_kbhit())
	{

/**
*
*  Read records out of the sequential monitor, 
*  then display the status information.  If the
*  input rate exceeds the rate at which we are
*  reading data out of the monitor, then eventually
*  the monitor will become full.  The program checks
*  the monitor status for this overrun condition.
*
**/
		
		monflag = L71_MonIsRunning(Card);

		retcount = L71_RcvMonBlkRd(MonData,sizeof(MonData)/sizeof(MonData[0]),&blkcount,Card);

		if (retcount)
		{
			totalcount += blkcount;

			printf("\rBlocks read: %-3d   Total count: %-8d   Monitor Status: %s",
				blkcount,
				totalcount,
				(monflag) ? "OK  " : "FULL");
		}
	}
	printf("\n");

/**
*
*  Stop the card to disable receiver.
*
**/

	L71_CardStop(Card);						/*Stop the card*/

/**
*
*  The L71 card MUST be closed before exiting the program.
*
**/

	L71_CardClose(Card);					/*Close the card*/

}
