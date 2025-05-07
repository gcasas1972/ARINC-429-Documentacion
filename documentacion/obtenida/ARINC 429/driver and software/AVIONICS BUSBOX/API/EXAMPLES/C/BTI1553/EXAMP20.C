
/**
*
*  BTI1553 DRIVER EXAMPLE 20  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP20.C -- RT with illegalized subaddresses
*
**/

/**
*
*  This example configures Card Number 0 as an RT to transmit
*  the BC-RT data requested by the bus controller in
*  Example 27. All subaddresses are illegalized except SA
*  number 2. Any message addressed to RT 1 other subaddress 2
*  will return a MESSAGE ERROR in the status word.
*
*  The program watches the 'hit' bit associated with the 0C43H
*  RT-BC message. When the message is transmitted and the
*  bit is set, the program updates the data words.
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
	USHORT  Data[3] = {0,0,0};


	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP20  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 20                                                *");
	printf("\n    *  \"RT with illegalized subaddresses\"                                *");
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
*  Configure the channel for remote terminal mode.  Use the RTCFG1553_NOBUILD
*  flag to illegalize all message structures until created by BTI1553_RTCreateMsg.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI1553_RTConfig(RTCFG1553_NOBUILD,1,channum,hCore);

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
*  Create the the message record for a transmit subaddress. This will legalize the
*  single SA on the RT.
*
**/

	RTMsg = BTI1553_RTCreateMsg(MSGCRT1553_DEFAULT,SUBADDRESS,1,XMT,2,channum,hCore);

/**
*
*  Initialize the data
*
**/

	Data[0] = 0;
	Data[1] = 0;
	Data[2] = 0;

	BTI1553_MsgDataWr(Data,3,RTMsg,hCore);

/**
*
*  Start the card to begin responding.
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

/**
*
*  Watch the 'hit' bit of the subaddress to see if it has
*  been transmitted.  If it has, update the data words.
*
**/

		MsgErrors = BTI1553_MsgFieldRd(FIELD1553_ERROR,RTMsg,hCore);

		if (MsgErrors & MSGERR1553_HIT)
		{
			Data[0] += 2;											/*Calculate the new data words*/
			Data[1] += 4;
			Data[2] += 6;

			BTI1553_MsgDataWr(Data,3,RTMsg,hCore);					/*Write the new data words*/

			BTI1553_MsgFieldWr(0,FIELD1553_ERROR,RTMsg,hCore);		/*Clear the 'hit' bit*/

			printf("\rUpdating data {%04XH, %04XH, %04XH}",Data[0],Data[1],Data[2]);
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
