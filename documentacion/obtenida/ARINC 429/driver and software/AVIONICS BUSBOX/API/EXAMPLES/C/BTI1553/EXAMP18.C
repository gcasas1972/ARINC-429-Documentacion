
/**
*
*  BTI1553 DRIVER EXAMPLE 18  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP18.C -- Engineering Unit Example
*
**/

/**
*
*  This example configures Card Number 0 as a Bus Monitor
*  terminal.  A terminal address filter is applied to only
*  record messages for TA #1. It prints the time-tag,
*  command words (if any), and status words (if any) for
*  each monitor record. An engineering unit conversion is
*  applied to the first data word in messages with Cwd1=0x0843.
*  This program can be used to monitor data from example 2 or
*  example 5.
*
*  The engineering unit conversion scales the unsigned field by the
*  resolution then adds the offset (i.e., unsigned BNR).
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

#define	RESOLUTION	2		/* Field Resolution */
#define OFFSET      0		/* Field Offset */

void main(void)
{
	HCARD   hCard;					/*Handle to card*/
	HCORE   hCore;					/*Handle to core*/
	ERRVAL  errval;					/*Error return value*/
	INT     corenum;				/*Core number*/
	INT     channum;				/*Channel number*/

	USHORT seqbuf[2048];
	ULONG  seqcount;
	ULONG  blkcnt;
	LPSEQRECORD1553 pRec1553;
	SEQFINDINFO sfinfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP18  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 18                                                *");
	printf("\n    *  \"Engineering Unit Example\"                                        *");
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
*  Configure the channel for monitor mode.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI1553_MonConfig(MONCFG1553_DEFAULT,channum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring for",errval);
		printf("\n        monitor mode on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Set the Terminal Address Filter to only monitor TA #1
*
**/

	errval = BTI1553_MonFilterTA(0x00000002, channum, hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while setting monitor",errval);
		printf("\n        filters on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure the sequential record.
*
**/

	errval = BTICard_SeqConfig(SEQCFG_DEFAULT,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the sequential record on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Start the card to begin transmitting, receiving and monitoring messages.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Read the entire contents of the monitor and display the results.
*  The engineering unit conversion is applied to the first data word in the
*  message with Cwd1=0x0843.
*
**/

	printf("\nPress any key to exit....\n\n");

	while(!kbhit())
	{
		seqcount = BTICard_SeqBlkRd(seqbuf,2048,&blkcnt,hCore);

		BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

		while(!BTICard_SeqFindNext1553(&pRec1553,&sfinfo))
		{
			printf("\n");

			printf(" Ch:%02u",(pRec1553->activity & MSGACT1553_CHMASK) >> MSGACT1553_CHSHIFT);
			printf(" Time:%lu",pRec1553->timestamp);

			if (pRec1553->activity & MSGACT1553_RCVCWD1) printf(" Cwd1:%04X",pRec1553->cwd1);
			if (pRec1553->activity & MSGACT1553_RCVCWD2) printf(" Cwd2:%04X",pRec1553->cwd2);
			if (pRec1553->activity & MSGACT1553_RCVSWD1) printf(" Swd1:%04X",pRec1553->swd1);
			if (pRec1553->activity & MSGACT1553_RCVSWD2) printf(" Swd2:%04X",pRec1553->swd2);

			if (pRec1553->error & MSGERR1553_NORESP)		// No Response
			{
				printf(" No response!");
			}
			else if (pRec1553->error & MSGERR1553_ANYERR)	// Error
			{
				printf(" Error!");
			}
			else if (pRec1553->cwd1 == 0x0843)				// Success!
			{
				printf(" Field:%04X", ((USHORT)BTICard_ValGetBits(pRec1553->data[0],0,7) * RESOLUTION) + OFFSET);
			}
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
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardClose(hCard);
}
