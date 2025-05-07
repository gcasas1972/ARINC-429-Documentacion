
/**
*
*  BTI1553 DRIVER EXAMPLE 15  (06/09/2011)
*  Copyright (c) 2003-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP15.C -- IRIG Timer example (bus monitor).
*
**/

/**
*
*  This example configures Card Number 0 as a Bus Monitor
*  terminal.  It prints the time-tag (in IRIG format),
*  command words (if any), and status words (if any) for each
*  monitor record.
*
**/

#include "BTICard.H"
#include "BTI1553.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <time.h>

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
	HCARD   hCard;					/*Handle to card*/
	HCORE   hCore;					/*Handle to core*/
	ERRVAL  errval;					/*Error return value*/
	INT     corenum;				/*Core number*/
	INT     channum;				/*Channel number*/
	BOOL	timetagIsBCD;

	USHORT seqbuf[2048];
	ULONG  seqcount;
	ULONG  blkcnt;
	LPSEQRECORD1553 pRec1553;
	LPSEQRECORDMORE1553 pRecMore;
	SEQFINDINFO sfinfo;

	BTIIRIGTIME  irigtime;
	struct tm    *curtime;
	time_t       long_time;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP15  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2003-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 15                                                *");
	printf("\n    *  \"IRIG Timer example (bus monitor).\"                               *");
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
*  Configure the IRIG timer. (DEFAULT -> bit rate = IRIGB, internal, slave/receiver)
*  Sequential monitor will store IRIG time in sequential records
*
**/

	errval = BTICard_IRIGConfig(IRIGCFG_DEFAULT,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the IRIG timer on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

	timetagIsBCD = (TIMETAG_FORMAT_BCD == BTICard_TimerStatus(hCore)) ? TRUE : FALSE;

/**
*
*  Synchronize the on core IRIG timer with the computer local time
*
**/
	time( &long_time );								/* Get time as long integer.			*/
	curtime = localtime( &long_time );				/* Convert to local time.				*/

	irigtime.days  = (USHORT)curtime->tm_yday;		/* Day of year (0 - 365; January 1 = 0) */
	irigtime.hours = (USHORT)curtime->tm_hour;		/* Hours after midnight (0 - 23)		*/
	irigtime.min   = (USHORT)curtime->tm_min;		/* Minutes after hour (0 - 59)			*/
	irigtime.sec   = (USHORT)curtime->tm_sec;		/* Seconds after minute (0 - 59)		*/
	irigtime.msec  = 0;					/* The tm structure does not include milliseconds.	*/
 	irigtime.usec  = 0;					/* The tm structure does not include microseconds.	*/

	errval = BTICard_IRIGWr(&irigtime,hCore);
	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while writing",errval);
		printf("\n        the IRIG time on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\n\nStart Time:%02u:%02u %02u.%03u.%03u \n",
			irigtime.hours,
			irigtime.min,
			irigtime.sec,
			irigtime.msec,
			irigtime.usec);

/**
*
*  Start the card to begin receiving messages.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Read the entire contents of the monitor and display the results.
*
**/

	printf("\nPress any key to exit....\n\n");

	while(!kbhit())
	{
		/* Empty entire contents of sequential monitor into a buffer. */
		seqcount = BTICard_SeqBlkRd(seqbuf,2048,&blkcnt,hCore);

		BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

		while(!BTICard_SeqFindNext1553(&pRec1553,&sfinfo))
		{
			/* Get extended data for this record. */
			BTICard_SeqFindMore1553(&pRecMore,pRec1553);

			if (!timetagIsBCD)
			{
				//Convert binary timetag to BCD
				BTICard_IRIGTimeBinToBCD(&(pRecMore->timestamph),
										 &(pRec1553->timestamp),
										 pRecMore->timestamph,
										 pRec1553->timestamp);
			}

			printf("\n");

			printf(" Ch:%02u",(pRec1553->activity & MSGACT1553_CHMASK) >> MSGACT1553_CHSHIFT);
			printf(" Time:%02u:%02u %02u.%03u.%03u    ",
					BTICard_IRIGFieldGetHours(   pRecMore->timestamph, pRec1553->timestamp),
					BTICard_IRIGFieldGetMin(     pRecMore->timestamph, pRec1553->timestamp),
					BTICard_IRIGFieldGetSec(     pRecMore->timestamph, pRec1553->timestamp),
					BTICard_IRIGFieldGetMillisec(pRecMore->timestamph, pRec1553->timestamp),
					BTICard_IRIGFieldGetMicrosec(pRecMore->timestamph, pRec1553->timestamp));

			if (pRec1553->activity & MSGACT1553_RCVCWD1) printf(" Cwd1:%04X",pRec1553->cwd1);
			if (pRec1553->activity & MSGACT1553_RCVCWD2) printf(" Cwd2:%04X",pRec1553->cwd2);
			if (pRec1553->activity & MSGACT1553_RCVSWD1) printf(" Swd1:%04X",pRec1553->swd1);
			if (pRec1553->activity & MSGACT1553_RCVSWD2) printf(" Swd2:%04X",pRec1553->swd2);

			if (pRec1553->error & MSGERR1553_NORESP) printf(" No response!");
			if (pRec1553->error & MSGERR1553_ANYERR) printf(" Error!");
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
