
/**
*
*  PC1553-3 DRIVER EXAMPLE 1  Version 1.0  (02/20/1998)
*  Copyright (c) 1998
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
*  This example configures the PC1553-3 as a BC to transmit
*  the receive command 0843H with data words 1234H, 5678H,
*  and 9ABCH.  If the message is completed successfully, it
*  displays the responding RT's status word.  Otherwise it
*  displays the value of any errors.
*
**/

#include "p13w32.h"
#include <stdio.h>
#include <stdlib.h>

#define	MEMBASE 0xCC00				/*Memory address of PC1553-3 card*/
#define IOBASE  0x2C0				/*I/O address of PC1553-3 card*/
#define	IRQCHAN 2					/*Interrupt channel of PC1553-3 card*/
#define	DMACHAN 1					/*DMA channel of PC1553-3 card*/

void main(void)
{
	HCARD Card;							/*Handle of PC1553-3 card*/
	ERRVAL errval;						/*Error return value*/
	XMITFIELDS Msg;						/*Message structure*/

	fprintf(stderr,"\nEXAMP1  Version 1.0  (02/20/1998)");
	fprintf(stderr,"\nCopyright 1998  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC1553-3 Example 1");
	fprintf(stderr,"\n\"Simulating the BC - Unscheduled Messages\"");
	fprintf(stderr,"\n");

/**
*
*  Open the PC1553-3 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = P13_CardOpen(MEMBASE,IOBASE,IRQCHAN,DMACHAN);	/*Open the PC1553-3 card*/

	if (Card < 0)
	{
		printf("\nError:  Either a PC1553-3 is not present at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for bus controller mode.
*
**/

	P13_CardReset(Card);							/*Reset the PC1553-3 card*/

	errval = P13_BCConfig(BCCFG_DEFAULT,Card);		/*Configure the PC1553-3 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for bus controller mode.",errval);
		P13_CardClose(Card);
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

	errval = P13_BCTransmitMsg(&Msg, Card);		/*Transmit the message*/

/**
*
*  Test for any error results.
*
*  Note the distinction between card errors and bus errors.
*  The returned value of P13_BCTransmitMsg is a card error
*  (if any occurred).  Errors related to the RT's reponse are
*  returned in the (errflags) member of the message
*  structure.
*
**/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while transmitting the message.",errval);
		P13_CardClose(Card);
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
*  The PC1553-3 card MUST be closed before exiting the program.
*
**/

	P13_CardClose(Card);					/*Close the card*/
}
