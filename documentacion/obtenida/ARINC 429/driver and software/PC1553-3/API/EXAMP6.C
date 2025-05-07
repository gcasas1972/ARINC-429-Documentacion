
/**
*
*  PC1553-3 DRIVER EXAMPLE 6  Version 1.0  (02/20/1998)
*  Copyright (c) 1998
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
*  This example requires a PC1553-3C or higher.  It
*  configures the PC1553-3 as a BC and transmits a single
*  receive command containing a parity error in the command
*  word.
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
	HCARD      Card;
	ERRVAL     errval;
	XMITFIELDS Msg;

	fprintf(stderr,"\nEXAMP6  Version 1.0  (02/20/1998)");
	fprintf(stderr,"\nCopyright 1998  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC1553-3 Example 6");
	fprintf(stderr,"\n\"Errors in BC Transmissions - Unscheduled Messages\"");
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
		printf("\n        or an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Check that card supports error generation.
*
**/

	if (!P13_CardGetInfo(INFOTYPE_ERRORGEN,Card))
	{
		printf("\nError:  The PC1553-3 at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        does not support error generation.");
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

	P13_ErrorDefine(ERRDEF_PAR, 0, 0, ERRDEF_CWD1, 0, Card);
	P13_ErrorCtrl(ERRCTRL_ONCE | ERRCTRL_ANYMSG, Card);

/**
*
*  Transmit the message.
*
**/

	errval = P13_BCTransmitMsg(&Msg, Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while transmitting the message.",errval);
		P13_CardClose(Card);
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
*  The PC1553-3 card MUST be closed before exiting the program.
*
**/

	P13_CardClose(Card);
}
