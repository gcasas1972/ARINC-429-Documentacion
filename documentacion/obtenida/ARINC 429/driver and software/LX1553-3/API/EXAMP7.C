
/**
*
*  LP1553-3 and LC1553-3 DRIVER EXAMPLE 7  Version 1.0  (10/29/2001)
*  Copyright (c) 1997-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP7.C -- Example 7 from Section 6.3.
*                      "Errors in BC Transmissions - Scheduled Messages"
*
**/

/**
*
*  This example requires a L13C or higher.  It
*  configures the L13 as a BC and creates a schedule
*  containing a receive command each for terminal address 1
*  and terminal address 2.  Both receive commands send 2 data
*  words to the remote terminal.  The example then alternates
*  a bit count error between the first data word of both
*  commands.
*
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of L13 card*/

#define	FRAMETIME	10000			/*Frame time in microseconds*/

#ifndef	TRUE
#define	TRUE 1
#endif

#ifndef	FALSE
#define	FALSE 0
#endif

void main(void)
{
	HCARD		Card;
	ERRVAL		errval;
	MSGADDR		BCMsgs[2];
	INT			ErrorCount = 0;
	USHORT		InitialData1;
	USHORT		InitialData2;

	fprintf(stderr,"\nEXAMP7  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1997-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Example 7");
	fprintf(stderr,"\n\"Errors in BC Transmissions - Scheduled Messages\"");
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
*  Create the message records.
*
**/

	BCMsgs[0] = L13_BCCreateMsg(MSGCRT_DEFAULT, 0x0842, 0, &InitialData1, Card);
	BCMsgs[1] = L13_BCCreateMsg(MSGCRT_DEFAULT, 0x1042, 0, &InitialData2, Card);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	L13_BCSchedFrame(FRAMETIME, Card);
	L13_BCSchedMsg(BCMsgs[0], Card);
	L13_BCSchedMsg(BCMsgs[1], Card);

/**
*
*  Define the type of error generation.  One of the bus
*  controller messages is tagged to generate errors once.
*
**/

	L13_ErrorDefine(ERRDEF_CNTBIT, 3, 2, 0, 0, Card);
	L13_ErrorTagBC(TRUE, BCMsgs[0], Card);
	L13_ErrorCtrl(ERRCTRL_ONCE | ERRCTRL_TAGMSG, Card);

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

	printf("Press any key to quit.\n");

	while (!kbhit())
	{

/**
*
*  When the error is generated once, tag another message for
*  error generation and enable another single error.
*
**/

		if (L13_ErrorSent(Card) /*AND ANOTHER ERROR DESIRED*/)
		{
			if ((++ErrorCount) & 1)
			{
				L13_ErrorTagBC(FALSE, BCMsgs[0], Card);
				L13_ErrorTagBC(TRUE,  BCMsgs[1], Card);
			}
			else
			{
				L13_ErrorTagBC(TRUE,  BCMsgs[0], Card);
				L13_ErrorTagBC(FALSE, BCMsgs[1], Card);
			}

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
