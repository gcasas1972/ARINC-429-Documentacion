
/**
*
*  BTI1553 DRIVER EXAMPLE 25  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP25.C -- Accessing other info in RT message structures
*
**/

/**
*
*  This example configures Card Number 0 as an RT to receive
*  the BC-RT data transmitted by the bus controller in
*  Example 2.
*
*  It continuously receives and displays the data words and
*  other meta data from the RT.
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

#ifndef	TRUE
#define	TRUE 1
#endif

#ifndef	FALSE
#define	FALSE 0
#endif

void main(void)
{
	HCARD  hCard;				/*Handle to card*/
	HCORE  hCore;				/*Handle to core*/
	ERRVAL errval;				/*Error return value*/
	INT    corenum;				/*Core number*/
	INT    channum;				/*Channel number*/
	BOOL   timetagIsBCD;

	MSGADDR RTMsg;
	MSGFIELDS1553 msgfields;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP25  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 25                                                *");
	printf("\n    *  \"Accessing other info in RT message structures\"                   *");
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

	BTICard_CardReset(hCore);

	errval = BTI1553_RTConfig(RTCFG1553_DEFAULT,1,channum,hCore);

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
*  Get the message address for a receive subaddress and enable timetag.
*
**/

	RTMsg = BTI1553_RTCreateMsg(MSGCRT1553_TIMETAG,SUBADDRESS,1,RCV,2,channum,hCore);

/**
*
*  Determine the format of the timetag.
*
**/

	timetagIsBCD = (TIMETAG_FORMAT_BCD == BTICard_TimerStatus(hCore)) ? TRUE : FALSE;

/**
*
*  Start the card to begin responding to transmissions.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit....\n\n");

	while (!_kbhit())
	{
		BTI1553_MsgBlockRd(&msgfields, RTMsg, hCore); /*Read the entire message block from the BC*/

		if (!timetagIsBCD)
		{
			//Convert binary timetag to BCD
			BTICard_IRIGTimeBinToBCD(&msgfields.timetagh,
									 &msgfields.timetag,
									 msgfields.timetagh,
									 msgfields.timetag);
		}

		printf("\rReceived data {%04XH, %04XH, %04XH}\tTimetag {%02u:%02u %02u.%03u.%03u}",
			msgfields.data[0],
			msgfields.data[1],
			msgfields.data[2],
			BTICard_IRIGFieldGetHours(   msgfields.timetagh, msgfields.timetag),
			BTICard_IRIGFieldGetMin(     msgfields.timetagh, msgfields.timetag),
			BTICard_IRIGFieldGetSec(     msgfields.timetagh, msgfields.timetag),
			BTICard_IRIGFieldGetMillisec(msgfields.timetagh, msgfields.timetag),
			BTICard_IRIGFieldGetMicrosec(msgfields.timetagh, msgfields.timetag));
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
