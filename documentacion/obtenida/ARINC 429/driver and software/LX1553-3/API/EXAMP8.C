
/**
*
*  LP1553-3 and LC1553-3 DRIVER EXAMPLE 8  Version 1.0  (10/29/2001)
*  Copyright (c) 1997-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP8.C -- Example 8 from Section 6.4.
*                      "Errors in RT Transmissions"
*
**/

/**
*
*  This example requires a L13C or higher.  It
*  configures the L13 as an RT and configures a response
*  time error for transmit commands for subaddress 2.  Each
*  time the subaddress is accessed, the response time is
*  incremented by .1us.
*
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of L13 card*/

#ifndef	TRUE
#define	TRUE 1
#endif

#ifndef	FALSE
#define	FALSE 0
#endif

void main(void)
{
	HCARD  Card;
	ERRVAL errval;
	USHORT GapLength;				/*Gap in units of 0.1us*/

	fprintf(stderr,"\nEXAMP8  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1997-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Example 8");
	fprintf(stderr,"\n\"Errors in RT Transmissions\"");
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
*  Check that card supports error generation.
*
**/

	if (!L13_CardGetInfo(INFOTYPE_ERRORGEN,Card))
	{
		printf("\nError:  The L13 with card number %u",CARDNUM);
		printf("\n        does not support error generation.");
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for remote terminal mode.
*
**/

	L13_CardReset(Card);

	errval = L13_RTConfig(RTCFG_DEFAULT, 1, Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for remote terminal mode.",errval);
		L13_CardClose(Card);
		exit(1);
	}

/**
*
*  Define the type and location of the gap.
*
**/

	GapLength = 0;					/*Set initial gap length to 12us*/

	L13_ErrorDefine(ERRDEF_GAP, 	/*Generate a gap*/
					GapLength, 		/*Set the length of the gap*/
					0, 				/*Unused parameter*/
					ERRDEF_SWD1,	/*Gap preceeds the status word*/
					0,				/*Unused parameter*/
					Card);

	L13_ErrorTagRT(TRUE, SUBADDRESS, 1, XMT, 2, Card);
	L13_ErrorCtrl(ERRCTRL_ONCE | ERRCTRL_TAGMSG, Card);

/**
*
*  Start the card to begin responding to transmissions.
*
**/

	L13_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("Press any key to quit.\n");

	while (!kbhit())
	{
		if (L13_ErrorSent(Card) /*AND ANOTHER ERROR DESIRED*/)
		{
			L13_ErrorDefine(ERRDEF_GAP, 	/*Change the length of the gap*/
							++GapLength,	/*Set the length of the new gap*/
							0, 				/*Unused parameter*/
							ERRDEF_SWD1,	/*Gap preceeds the status word*/
							0,				/*Unused parameter*/
							Card);

			L13_ErrorCtrl(ERRCTRL_ONCE | ERRCTRL_TAGMSG, Card);
		}
	}

/**
*
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardStop(Card);
	L13_CardClose(Card);
}
