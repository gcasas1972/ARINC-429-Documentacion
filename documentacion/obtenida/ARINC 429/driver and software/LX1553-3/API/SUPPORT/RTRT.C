
/**
*
*  LP1553-3 and LC1553-3 DRIVER RTRT EXAMPLE  Version 1.0  (06/23/2004)
*  Copyright (c) 1997-2004
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   RTRT.C -- RTRT Example.
*
**/

/**
*
*  This example configures the L13 as a BC to transmit
*  an RT-RT message.  RT 1 is the receiving RT, and RT
*  2 is the transmitting RT.  Even though the data is
*  being transferred between RTs and bypassing the BC, the
*  BC can 'peek' into the message and record the data being
*  transferred.
*
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>

#define	CARDNUM 0						/*Card number of L13 card*/

void main(void)
{
	INT j;
	HCARD Card;							/*Handle of L13 card*/
	ERRVAL errval;						/*Error return value*/
	XMITFIELDS Msg;						/*Message structure*/

	fprintf(stderr,"\nRTRT  Version 1.0  (06/23/2004)");
	fprintf(stderr,"\nCopyright 1997-2004  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 RTRT Example");
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
*  Initialize the message command and data words, and select
*  an RT-RT transfer.  
*
*  The first command word is transmitted to the receiving RT.
*  It tells RT 1 to receive 3 data words at subaddress 7.
*
*  The second command word is transmitted to the transmitting RT.
*  It tells RT 2 to transmit 3 data words from subaddress 5.
*
**/

	Msg.ctrlflags = MSGCRT_RTRT;				/*Selects RT-RT transfer*/
	Msg.cwd1      = L13_ValPackCWD(1,0,7,3);	/*Command word to receiving RT*/
	Msg.cwd2      = L13_ValPackCWD(2,1,5,3);	/*Command word to transmitting RT*/

	errval = L13_BCTransmitMsg(&Msg, Card);		/*Transmit the message*/

/**
*
*  Test for any error results.
*
*  Note the distinction between card errors and bus errors.
*  The returned value of L13_BCTransmitMsg is a card error
*  (if any occurred).  Errors related to the RT's reponse are
*  returned in the (errflags) member of the message
*  structure.
*
**/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while transmitting the message.",errval);
		L13_CardClose(Card);
		exit(1);
	}

	if (Msg.errflags & MSGERR_NORESP)		/*Was there a response?*/
	{
		printf("\nWarning:  No response was received from an RT.");
		printf("\n          Refer to the documentation for a");
		printf("\n          description of the error flags (%04XH).",Msg.errflags);
		printf("\n");
	}
	else if (Msg.errflags & MSGERR_ANYERR)	/*Was there an error?*/
	{
		printf("\nWarning:  An error occurred while receiving the response from an RT.");
		printf("\n          Refer to the documentation for a");
		printf("\n          description of the error flags (%04XH).",Msg.errflags);
		printf("\n");
	}
	else									/*There were no errors*/
	{
		printf("\nSuccess!  The message was completed successfully.");
		printf("\n          The transmitting RT returned the status word %04XH.",Msg.swd1);
		printf("\n          The transmitting RT transmitted %u data words.",Msg.datacount);
		printf("\n          The transmitting RT transmitted the following data words:");

		for (j=0;j<Msg.datacount;++j)
		{
			printf("\n          Data word #%u: %04XH",j,Msg.data[j]);
		}

		printf("\n          The receiving RT received the data words and returned the status word %04XH.",Msg.swd2);
		printf("\n");
	}

/**
*
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardClose(Card);					/*Close the card*/
}
