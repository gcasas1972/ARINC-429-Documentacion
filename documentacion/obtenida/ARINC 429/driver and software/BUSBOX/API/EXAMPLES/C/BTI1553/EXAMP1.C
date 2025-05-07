
/**
*
*  BTI1553 DRIVER EXAMPLE 1  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Simulating the BC - Unscheduled Messages
*
**/

/**
*
*  This example configures Card Number 0 as a BC to transmit
*  the receive command 0843H with data words 1234H, 5678H,
*  and 9ABCH.  If the message is completed successfully, it
*  displays the responding RT's status word.  Otherwise it
*  displays the value of any errors.
*
**/

#include "BTICard.h"
#include "BTI1553.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

void main(void)
{
	HCARD  hCard;					/*Handle to card*/
	HCORE  hCore;					/*Handle to core*/
	ERRVAL errval;					/*Error return value*/
	INT    corenum;					/*Core number*/
	INT    channum;					/*Channel number*/

	XMITFIELDS1553 Msg;				/*Message structure*/

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP1  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 1                                                 *");
	printf("\n    *  \"Simulating the BC - Unscheduled Messages\"                        *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
	printf("\n");

/**
*
*  Open the card with the specified card number.
*  An error value is returned which is tested
*  to determine if an error occurred.
*
**/

	errval = BTICard_CardOpen(&hCard,CARDNUM);

	if (errval)
	{
		printf("\nError:  Either card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		exit(1);
	}

	printf("\nUsing BTI1553 card #%d",CARDNUM);

/**
*
*  Find the first MIL-STD-1553 core and channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (channum=0;channum<MAX_CHANNELS;channum++)
			if (BTI1553_ChIs1553(channum,hCore)) break;

		if (channum != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
	{
		printf("\nError:  No MIL-STD-1553 channels present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing MIL-STD-1553 core #%d",corenum);
	printf("\nUsing MIL-STD-1553 channel #%d",channum);
	printf("\n");

/**
*
*  Configure the channel for bus controller mode.
*
**/

	BTICard_CardReset(hCore);									/*Reset the core*/

	errval = BTI1553_BCConfig(BCCFG1553_DEFAULT,channum,hCore);	/*Configure the core*/

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring bus",errval);
		printf("\n        controller mode on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Create an empty frame in the BC Schedule.
*
*  BTI1553_BCTransmitMsg uses an asynchronous Message Record
*  that is transmitted at the end of every frame.  Therefore,
*  even though we aren't scheduling messages, we must still
*  schedule a frame.
*
**/

	BTI1553_BCSchedFrame(1000,channum,hCore);

/**
*
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Initialize the message command and data words, and select
*  a BC-RT transfer.  Then transmit the message.
*
**/

	Msg.ctrlflags = MSGCRT1553_BCRT;					/*Selects BC-RT transfer*/
	Msg.cwd1      = BTI1553_ValPackCWD(1,0,2,3);		/*Receive command word*/
	Msg.data[0]   = 0x1234;								/*Data word 0*/
	Msg.data[1]   = 0x5678;								/*Data word 1*/
	Msg.data[2]   = 0x9ABC;								/*Data word 2*/

	errval = BTI1553_BCTransmitMsg(&Msg,channum,hCore);	/*Transmit the message*/

/**
*
*  Test for any error results.
*
*  Note the distinction between card errors and bus errors.
*  The returned value of BTI1553_BCTransmitMsg is a card error
*  (if any occurred).  Errors related to the RT's response are
*  returned in the (errflags) member of the message
*  structure.
*
**/

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while transmitting the message.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

	if (Msg.errflags & MSGERR1553_NORESP)		/*Was there a response?*/
	{
		printf("\nWarning:  No response was received from the RT.");
		printf("\n          Refer to the documentation for a");
		printf("\n          description of the error flags (%04XH).",Msg.errflags);
		printf("\n");
	}
	else if (Msg.errflags & MSGERR1553_ANYERR)	/*Was there an error?*/
	{
		printf("\nWarning:  An error occurred while receiving the response from the RT.");
		printf("\n          Refer to the documentation for a");
		printf("\n          description of the error flags (%04XH).",Msg.errflags);
		printf("\n");
	}
	else										/*There were no errors*/
	{
		printf("\nSuccess!  The message was completed successfully.");
		printf("\n          The RT returned the status word %04XH.",Msg.swd1);
		printf("\n");
	}

/**
*
*  Stop the card.
*
**/

	BTICard_CardStop(hCore);

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardClose(hCard);
}
