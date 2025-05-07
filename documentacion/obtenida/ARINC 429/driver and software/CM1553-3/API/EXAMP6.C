
/**
*
*  CM1553-3 DRIVER EXAMPLE 6  Version 1.0  (07/16/2001)
*  Copyright (c) 1999-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP6.C -- Example 6 from Section 6.2.
*                      "Errors in BC Transmissions - Unscheduled Messages"
*
**/

/**
*
*  This example requires a CM1553-3C or higher.  It
*  configures the CM1553-3 as a BC and transmits a single
*  receive command containing a parity error in the command
*  word.
*
**/

#include "c13w32.h"
#include <stdio.h>
#include <stdlib.h>

#define	CARDNUM 0					/*Card number of CM1553-3 card*/

void main(void)
{
	HCARD      Card;
	ERRVAL     errval;
	XMITFIELDS Msg;

	fprintf(stderr,"\nEXAMP6  Version 1.0  (07/16/2001)");
	fprintf(stderr,"\nCopyright (c) 1999-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nCM1553-3 Example 6");
	fprintf(stderr,"\n\"Errors in BC Transmissions - Unscheduled Messages\"");
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
*  Check that card supports error generation.
*
**/

	if (!C13_CardGetInfo(INFOTYPE_ERRORGEN,Card))
	{
		printf("\nError:  The CM1553-3 with card number %u",CARDNUM);
		printf("\n        does not support error generation.");
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for bus controller mode.
*
**/

	C13_CardReset(Card);							/*Reset the CM1553-3 card*/

	errval = C13_BCConfig(BCCFG_DEFAULT,Card);		/*Configure the CM1553-3 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for bus controller mode.",errval);
		C13_CardClose(Card);
		exit(1);
	}

/**
*
*  Initialize the message command and data words, and select
*  a BC-RT transfer.
*
**/

	Msg.ctrlflags	= MSGCRT_BCRT;
	Msg.cwd1		= 0x0843;
	Msg.data[0]		= 0x1234;
	Msg.data[1]		= 0x5678;
	Msg.data[2]		= 0x9ABC;

/**
*
*  Define the type of error generation.
*
**/

	C13_ErrorDefine(ERRDEF_PAR, 0, 0, ERRDEF_CWD1, 0, Card);
	C13_ErrorCtrl(ERRCTRL_ONCE | ERRCTRL_ANYMSG, Card);

/**
*
*  Transmit the message.
*
**/

	errval = C13_BCTransmitMsg(&Msg, Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while transmitting the message.",errval);
		C13_CardClose(Card);
		exit(1);
	}

/**
*
*  Test for any error results.
*
**/

	if (Msg.errflags & MSGERR_NORESP)		/*Was there a response?*/
	{
		printf("\nWarning:  No response was received from the RT.");
		printf("\n          Refer to the documentation for a");
		printf("\n          description of the error flags (%04XH).",Msg.errflags);
		printf("\n");
	}
	else if (Msg.errflags & MSGERR_ANYERR)	/*Was there an error?*/
	{
		printf("\nWarning:  An error occurred while receiving the response from the RT.");
		printf("\n          Refer to the documentation for a");
		printf("\n          description of the error flags (%04XH).",Msg.errflags);
		printf("\n");
	}
	else									/*There were no errors*/
	{
		printf("\nSuccess!  The message was completed successfully.");
		printf("\n          The RT returned the status word %04XH.",Msg.swd1);
		printf("\n");
	}

/**
*
*  The CM1553-3 card MUST be closed before exiting the program.
*
**/

	C13_CardClose(Card);
}
