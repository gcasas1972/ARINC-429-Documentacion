
/**
*
*  BTI1553 DRIVER EXAMPLE 21  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP21.C -- RT with subaddress wrapping
*
**/

/**
*
*  This example configures 1 RT with a receive and transmit
*  subaddress to illustrate data pointer manipulation by
*  implementing the RX/TX SA wraparound.
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

	MSGADDR RTComboMsg;
	MSGFIELDS1553 msgfields;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP21  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 21                                                *");
	printf("\n    *  \"RT with subaddress wrapping\"                                     *");
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
*  Configure the channel for remote terminal mode.
*
**/

	BTICard_CardReset(hCore);									/*Reset the core*/

	errval = BTI1553_RTConfig(RTCFG1553_DEFAULT, 1, channum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring RT",errval);
		printf("\n        mode on channel #%d on core #%d RT number %d",channum,corenum, 1);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/***
*
*	Wrap the receive subaddress to the transmit subaddress
*
***/

	RTComboMsg = BTI1553_RTCreateMsg(MSGCRT1553_WRAP, SUBADDRESS, 1, RCV, 1, channum, hCore);

/***
*
*	Start the Ballard hardware. The hardware will run without host intervention until halted.
*
***/

	BTICard_CardStart(hCore);

	printf("\nPress any key to exit....\n\n");

	while(!_kbhit())
	{
		BTI1553_MsgBlockRd(&msgfields, RTComboMsg, hCore); /*Read the entire message block from the RT*/

		printf("\rCWD: %04X\tData {%04XH, %04XH, %04XH}",msgfields.cwd1,msgfields.data[0],msgfields.data[1],msgfields.data[2]);
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
