
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 12  Version 1.0  (10/29/2001)
*  Copyright (c) 2000-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP12.C -- Example 12.
*                      "Program for ARINC 717 receiver example"
*
**/

/**
*
*  This program opens the L43 card number 0, and
*  configures the first BiPhase 717 receive channel.
*  After the channel gets in sync, the program displays
*  the first word of each subframe (sync words).
*
**/

#include "l43w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0                               /*Card number of L43 card*/

void main(void)
{
	HCARD Card;                                 /*Handle of L43 card*/
	ERRVAL errval;                              /*Error return value*/
	INT rcvchan;                                /*Channel number*/
	USHORT syncword1,syncword2,syncword3,syncword4;

	fprintf(stderr,"\nEXAMP12  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright (c) 2000-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 12");
	fprintf(stderr,"\n\"Program for ARINC 717 receiver example.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);					/*Open the L43 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L43 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Find the first BiPhase channel.
*
**/

	for (rcvchan=0;rcvchan<8;++rcvchan) if (L43_Is717BiPhaseChan(rcvchan,Card)) break;
	if (rcvchan == 8)
	{
		printf("\nError:  No ARINC 717 BiPhase channels present in L43 cardnum %d.",CARDNUM);
		printf("\n");
		exit(1);
	}

	fprintf(stderr,"\nUsing ARINC 717 BiPhase channel %d",rcvchan);
	fprintf(stderr,"\n");

/**
*
*  Configure receiver channel for auto speed detection.
*
**/

	L43_CardReset(Card);                                  /*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG717_AUTOSPEED,rcvchan,Card);  /*Configure channel*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,rcvchan);
		printf("\n");
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
	fprintf(stderr,"\nSynchronizing to bit stream....");

	while (!L43_SyncTest(rcvchan,Card) && !kbhit());

	if (L43_SyncTest(rcvchan,Card))
	{
		printf("In Sync!\n\n");
		while(!kbhit())
		{
			L43_SubFrmWordRd(&syncword1,1,1,rcvchan,Card);
			L43_SubFrmWordRd(&syncword2,2,1,rcvchan,Card);
			L43_SubFrmWordRd(&syncword3,3,1,rcvchan,Card);
			L43_SubFrmWordRd(&syncword4,4,1,rcvchan,Card);

			printf("\r");
			printf("Sync1=%04o ",syncword1);
			printf("Sync2=%04o ",syncword2);
			printf("Sync3=%04o ",syncword3);
			printf("Sync4=%04o ",syncword4);
			printf("(Octal)");
		}
	}

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

	L43_CardClose(Card);

}
