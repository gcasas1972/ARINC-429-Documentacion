
/**
*
*  BTI1553 DRIVER EXAMPLE 30  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP30.C -- Changing BC or RT data when a message is serviced
*
**/

/**
*
*  This example configures Card Number 0 as an RT to transmit
*  to the BC.  The program watches the hit bit on transmit
*  subaddress 1 and updates the first data word.  The result
*  is an incrementing data word in the transmit subaddress.
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
	HCARD  hCard;				/*Handle to card*/
	HCORE  hCore;				/*Handle to core*/
	ERRVAL errval;				/*Error return value*/
	INT    corenum;				/*Core number*/
	INT    channum;				/*Channel number*/

	MSGADDR RTMsg;
	ULONG   MsgErrors;
	USHORT  RTData[3] = {0,0,0};

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP30  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 30                                                *");
	printf("\n    *  \"Changing BC or RT data when a message is serviced\"               *");
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
*  Configure the channel for remote terminal mode as shown in
*  Example 3.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI1553_RTConfig(RTCFG1553_DEFAULT,2,channum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring for",errval);
		printf("\n        remote terminal mode on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Get the message address for a receive subaddress.
*
**/

	RTMsg = BTI1553_RTGetMsg(SUBADDRESS,2,XMT,1,channum,hCore);

	RTData[0] = 0;
	RTData[1] = 1;
	RTData[2] = 2;

	BTI1553_MsgDataWr(RTData,3,RTMsg,hCore);

/**
*
*  Loop until a key is hit.
*
**/

	BTICard_CardStart(hCore);

	printf("\nPress any key to exit....\n\n");

	printf("\nWaiting for first transmission");

	while(!_kbhit())
	{
/**
*
*  Watch the 'hit' bit of the subaddress to see if it has
*  been transmitted.  If it has, increment the first data word.
*
**/

		MsgErrors = BTI1553_MsgFieldRd(FIELD1553_ERROR,RTMsg,hCore);

		if (MsgErrors & MSGERR1553_HIT)
		{
			RTData[0] += 1;											/*Calculate the new data words*/

			BTI1553_MsgDataWr(RTData,1,RTMsg,hCore);				/*Write the new data words*/

			BTI1553_MsgFieldWr(0,FIELD1553_ERROR,RTMsg,hCore);		/*Clear the 'hit' bit*/

			printf("\rTransmitting data {%04XH, %04XH, %04XH}",RTData[0],RTData[1],RTData[2]);
		}
	}

/**
*
*  Stop the card.
*
**/

	BTICard_CardStop(hCore);

/**
*
*  The card MUST be closed before continuing
*
**/

	BTICard_CardClose(hCard);
}
