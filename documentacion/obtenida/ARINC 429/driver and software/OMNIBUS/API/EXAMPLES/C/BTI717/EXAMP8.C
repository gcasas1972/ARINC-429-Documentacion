
/**
*
*  BTI717 DRIVER EXAMPLE 8  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP8.C -- IRIG timer example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first BiPhase channel as a receiver.  The second
*  BiPhase channel is configured as a transmitter.  Both
*  channels operate on the self-test bus to electrically connect
*  them. The transmit channel is loaded with incrementing data,
*  and various words are configured for entry into the
*  Sequential Monitor.  The program will read out of the
*  Sequential Record and display the data to the screen using
*  the IRIG timer.
*
**/

#include "BTICard.H"
#include "BTI717.H"
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
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT corenum;
	INT rcvchan;
	INT xmtchan;
	INT wps = 256;
	BOOL timetagIsBCD;
	SUPERFRMADDR superfrmaddr;
	USHORT sfblock[8200];
	INT j,jj;

	USHORT seqbuf[2048];
	ULONG seqcount;
	ULONG blkcnt;
	LPSEQRECORD717 pRec717;
	SEQFINDINFO sfinfo;
	BTIIRIGTIME  irigtime;
	struct tm    *curtime;
	time_t       long_time;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP8  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI717 Example 8                                                  *");
	printf("\n    *  \"Program for IRIG timer example.\"                                 *");
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

	printf("\nUsing ARINC 717 card #%d",CARDNUM);

/**
*
*  Find the first ARINC 717 core with both BiPhase receive and transmit channels.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		// Search for receive
		for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)
		{
			if (BTI717_ChIsType(CHCFG717_BIPHASERCV, rcvchan, hCore))	break;
		}

		// Search for transmit
		for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)
		{
			if ( xmtchan == rcvchan ) continue;

			if (BTI717_ChIsType(CHCFG717_BIPHASEXMT, xmtchan, hCore))	break;
		}

		if ( (rcvchan != MAX_CHANNELS) && (xmtchan != MAX_CHANNELS) ) break;
	}

	if (errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS || xmtchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 717 BiPhase receive and transmit channel pair present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 717 core #%d",corenum);
	printf("\nUsing BiPhase receive channel #%d",rcvchan);
	printf("\nUsing BiPhase transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure receiver channel for auto speed detection.
*  Use the internal wrap around.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI717_ChConfig(CHCFG717_BIPHASERCV | CHCFG717_AUTOSPEED | CHCFG717_SELFTEST,rcvchan,hCore);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,rcvchan);
		fprintf(stderr,"\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure transmitter channel at specified words per second.
*  Use the internal wrap around.
*
**/

	if      (wps == 64)   errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_64WPS,  xmtchan,hCore);
	else if (wps == 128)  errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_128WPS, xmtchan,hCore);
	else if (wps == 256)  errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_256WPS, xmtchan,hCore);
	else if (wps == 512)  errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_512WPS, xmtchan,hCore);
	else if (wps == 1024) errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_1024WPS,xmtchan,hCore);
	else if (wps == 2048) errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_2048WPS,xmtchan,hCore);
	else if (wps == 4096) errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_4096WPS,xmtchan,hCore);
	else if (wps == 8192) errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_8192WPS,xmtchan,hCore);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,xmtchan);
		fprintf(stderr,"\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Init subframe data.
*
**/

	for (j=1;j<=4;j++)
	{
		BTI717_SubFrmBlkRd(sfblock,j,xmtchan,hCore);
		for (jj=2;jj<=wps;jj++) sfblock[jj+7] = ((0x0100*j)+jj) & 0x0FFF;
		BTI717_SubFrmBlkWr(sfblock,j,xmtchan,hCore);
	}

/**
*
*  Create some SuperFrame structures.
*
**/

	BTI717_SuperFrmConfig(10,16,xmtchan,hCore);

/**
*
*  Define SF2, W10 to be SuperFrame Data.
*  Init superframe data.
*
**/

	superfrmaddr = BTI717_SuperFrmDefine(2,10,xmtchan,hCore);
	for (j=1;j<=16;j++) BTI717_SuperFrmWordWr((USHORT)(0x0500+j),j,superfrmaddr,xmtchan,hCore);

/**
*
*  Set superframe counter position.
*
**/

	BTI717_SuperFrmCounterPos(1,wps,rcvchan,hCore);
	BTI717_SuperFrmCounterPos(1,wps,xmtchan,hCore);

/**
*
*  Configure the Sequential Monitor.
*
**/

	errval = BTICard_SeqConfig(SEQCFG_DEFAULT,hCore);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the Sequential Monitor.",errval);
		fprintf(stderr,"\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure word options.
*
**/

	//Mark word 1 of SFs 1, 2, 3, and 4 for the Sequential Monitor

	BTI717_SubFrmWordConfig(WRDCFG717_SEQ,1,1,rcvchan,hCore);
	BTI717_SubFrmWordConfig(WRDCFG717_SEQ,2,1,rcvchan,hCore);
	BTI717_SubFrmWordConfig(WRDCFG717_SEQ,3,1,rcvchan,hCore);
	BTI717_SubFrmWordConfig(WRDCFG717_SEQ,4,1,rcvchan,hCore);

	BTI717_SubFrmWordConfig(WRDCFG717_SEQ,1,1,xmtchan,hCore);
	BTI717_SubFrmWordConfig(WRDCFG717_SEQ,2,1,xmtchan,hCore);
	BTI717_SubFrmWordConfig(WRDCFG717_SEQ,3,1,xmtchan,hCore);
	BTI717_SubFrmWordConfig(WRDCFG717_SEQ,4,1,xmtchan,hCore);

	//Mark the word at SPF 4 of our superframe word (word 10, SF 2)
	//for the Sequential Monitor

	BTI717_SuperFrmWordConfig(WRDCFG717_SEQ,4,superfrmaddr,xmtchan,hCore);

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
	irigtime.msec  = 0;			/* The tm structure does not include milliseconds.			*/
 	irigtime.usec  = 0;			/* The tm structure does not include microseconds.			*/

	errval = BTICard_IRIGWr(&irigtime,hCore);
	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while writing",errval);
		printf("\n        the IRIG time on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Read the Sequential Record and display to screen.
*
**/

	printf("\nPress any key to exit....\n\n");

	while(!kbhit())
	{
		seqcount = BTICard_SeqBlkRd(seqbuf,sizeof(seqbuf)/sizeof(seqbuf[0]),&blkcnt,hCore);

		BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

		while(!BTICard_SeqFindNext717(&pRec717,&sfinfo))
		{
			if (!timetagIsBCD)
			{
				//Convert binary timetag to BCD
				BTICard_IRIGTimeBinToBCD(&(pRec717->timestamph),
										 &(pRec717->timestamp),
										 pRec717->timestamph,
										 pRec717->timestamp);
			}

			printf("\nCh:%-2d  Word:%-2d  SF:%-2d  SPF:%-2d  Value:%04o (Octal)",
				(pRec717->activity & MSGACT717_CHMASK) >> MSGACT717_CHSHIFT,
				pRec717->wordnum,
				pRec717->subframe,
				(pRec717->superframe % 16) + 1,
				pRec717->data);

			printf("  TimeStamp:%02u:%02u %02u.%03u.%03u",
				BTICard_IRIGFieldGetHours(pRec717->timestamph,pRec717->timestamp),
				BTICard_IRIGFieldGetMin(pRec717->timestamph,pRec717->timestamp),
				BTICard_IRIGFieldGetSec(pRec717->timestamph,pRec717->timestamp),
				BTICard_IRIGFieldGetMillisec(pRec717->timestamph,pRec717->timestamp),
				BTICard_IRIGFieldGetMicrosec(pRec717->timestamph,pRec717->timestamp));
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
