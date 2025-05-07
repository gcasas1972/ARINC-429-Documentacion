
/**
*
*  CM1553-3 DRIVER EXAMPLE 3  Version 1.0  (07/16/2001)
*  Copyright (c) 1999-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- Example 3 from Section 4.3.
*                      "Simulating an RT"
*
**/

/**
*
*  This example configures the CM1553-3 as an RT to receive
*  the BC-RT data transmitted by the bus controller in
*  Example 2.
*
*  It continuously receives and displays the data words.
*
**/

#include "c13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of CM1553-3 card*/

void main(void)
{
	HCARD   Card;
	ERRVAL  errval;
	MSGADDR RTMsg;
	USHORT  Data[32];

	fprintf(stderr,"\nEXAMP3  Version 1.0  (07/16/2001)");
	fprintf(stderr,"\nCopyright (c) 1999-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nCM1553-3 Example 3");
	fprintf(stderr,"\n\"Simulating an RT\"");
	fprintf(stderr,"\n");

/**
*
*  Open the CM1553-3 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = C13_CardOpen(CARDNUM);					/*Open the CM1553-3 card*/

	if (Card < 0)
	{
		printf("\nError:  Either CM1553-3 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for remote terminal mode.
*
**/

	C13_CardReset(Card);

	errval = C13_RTConfig(RTCFG_DEFAULT, 1, Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for remote terminal mode.",errval);
		C13_CardClose(Card);
		exit(1);
	}

/**
*
*  Get the message address for a receive subaddress.
*
**/

	RTMsg = C13_RTGetMsg(SUBADDRESS, 1, RCV, 2, Card);

/**
*
*  Start the card to begin responding to transmissions.
*
**/

	C13_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to quit.");
	printf("\n");

	while (!kbhit())
	{
		C13_MsgDataRd(Data, 3, RTMsg, Card);	/*Read data received from the BC*/

		printf("\rReceived data {%04XH, %04XH, %04XH}",Data[0],Data[1],Data[2]);
	}

/**
*
*  The CM1553-3 card MUST be closed before exiting the program.
*
**/

	C13_CardStop(Card);						/*Stop the card*/
	C13_CardClose(Card);					/*Close the card*/
}
