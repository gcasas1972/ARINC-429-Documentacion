
/**
*
*  BTI1553 DRIVER EXAMPLE 13  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP13.C -- BC Transmission of Data Using a Ping-Pong Buffer
*
**/

/**
*
*  This example configures Card Number 0 as a bus controller
*  to transmit a schedule of one message.  The message is
*  transmitted at a frequency of 10Hz (or every 100ms).
*
*  A ping-pong buffer is configured for the message.  After
*  the card is started, the program writes new data to the
*  message as fast as possible.  The ping-pong buffer
*  prevents the message from transmitting old data mixed in
*  with new data.
*
**/

#include "BTICard.H"
#include "BTI1553.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

#define CMD 0x0820					/*Command word for message*/

#define	FRAMETIME 100000			/*Frame time in microseconds*/

void main(void)
{
	HCARD   hCard;					/*Handle to card*/
	HCORE   hCore;					/*Handle to core*/
	ERRVAL  errval;					/*Error return value*/
	INT     corenum;				/*Core number*/
	INT     channum;				/*Channel number*/

	MSGADDR BCList;
	USHORT  Data[32];
	INT     j;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP13  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 13                                                *");
	printf("\n    *  \"BC Transmission of Data Using a Ping-Pong Buffer\"                *");
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
		printf("\nError:  No MIL-STD-1553 channels present in card #%d.",CARDNUM);
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
*  Create the Ping-Pong List Buffer
*
**/

	BCList = BTI1553_BCCreateList(
		LISTCRT1553_PINGPONG,		/*List creation flags*/
		0,							/*List size (automatic for Ping-Pong)*/
		MSGCRT1553_DEFAULT,			/*Message creation flags*/
		CMD,						/*Command Word 1*/
		0,							/*Command Word 2*/
		NULL,						/*Initial data (if any)*/
		hCore);						/*Device handle*/

	if (!BCList)
	{
		printf("\nError:  An error was encountered while creating the");
		printf("\n        BC List Buffer on channel #%d on core #%d.",channum,corenum);
		printf("\n        Possibly a device generation issue.");
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedMsg(BCList,     channum,hCore);

/**
*
*  Initialize the data words.
*
**/

	for (j=0;j<32;++j) Data[j]=0;

	BTI1553_ListDataWr(Data,32,BCList,hCore);

/**
*
*  Start the card to begin transmissions.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit....\n\n");

	while (!kbhit())
	{
		for (j=0;j<32;++j) ++Data[j];
		BTI1553_ListDataWr(Data,32,BCList,hCore);
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
