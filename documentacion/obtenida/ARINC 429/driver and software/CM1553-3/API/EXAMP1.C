
/**
*
*  CM1553-3 DRIVER EXAMPLE 1  Version 1.0  (07/16/2001)
*  Copyright (c) 1999-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Example 1 from Section 4.1.
*                      "Simulating the BC - Unscheduled Messages"
*
**/

/**
*
*  This example configures the CM1553-3 as a BC to transmit
*  the receive command 0843H with data words 1234H, 5678H,
*  and 9ABCH.  If the message is completed successfully, it
*  displays the responding RT's status word.  Otherwise it
*  displays the value of any errors.
*
**/

#include "c13w32.h"
#include <stdio.h>
#include <stdlib.h>

#define	CARDNUM 0						/*Card number of CM1553-3 card*/

void main(void)
{
	HCARD Card;							/*Handle of CM1553-3 card*/
	ERRVAL errval;						/*Error return value*/
	XMITFIELDS Msg;						/*Message structure*/

	fprintf(stderr,"\nEXAMP1  Version 1.0  (07/16/2001)");
	fprintf(stderr,"\nCopyright (c) 1999-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nCM1553-3 Example 1");
	fprintf(stderr,"\n\"Simulating the BC - Unscheduled Messages\"");
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
*  a BC-RT transfer.  Then transmit the message.
*
**/

	Msg.ctrlflags = MSGCRT_BCRT;				/*Selects BC-RT transfer*/
	Msg.cwd1      = 0x0843;						/*Receive command word*/
	Msg.data[0]   = 0x1234;						/*Data word 0*/
	Msg.data[1]   = 0x5678;						/*Data word 1*/
	Msg.data[2]   = 0x9ABC;						/*Data word 2*/

	errval = C13_BCTransmitMsg(&Msg, Card);		/*Transmit the message*/

/**
*
*  Test for any error results.
*
*  Note the distinction between card errors and bus errors.
*  The returned value of C13_BCTransmitMsg is a card error
*  (if any occurred).  Errors related to the RT's reponse are
*  returned in the (errflags) member of the message
*  structure.
*
**/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while transmitting the message.",errval);
		C13_CardClose(Card);
		exit(1);
	}

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

	C13_CardClose(Card);					/*Close the card*/
}
