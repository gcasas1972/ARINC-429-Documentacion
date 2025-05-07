
/**
*
*  BTIDIO DRIVER EXAMPLE 5  (06/09/2011)
*  Copyright (c) 2005-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5.C -- IRIG Timer example
*
**/

/**
*
*  This program opens Card Number 0 and configures the
*  first compatible core to monitor the input values of
*  the discretes of Bank A.  A time-tag for each message
*  is converted from the IRIG time and displayed.
*
**/

#include "BTICard.H"
#include "BTIDIO.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <time.h>

#define	CARDNUM		     0
#define	MAX_CORES        4
#define	MAX_BANKS        4

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
	BOOL timetagIsBCD;
	INT banknum;
	ULONG bankcfg;
	USHORT seqbuf[2048];
	ULONG seqcount;
	ULONG blkcnt;
	LPSEQRECORDDIO pRecDIO;
	SEQFINDINFO sfinfo;
	BTIIRIGTIME  irigtime;
	struct tm    *curtime;
	time_t       long_time;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP5  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTIDIO Example 5                                                  *");
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

	printf("\nUsing DIO card #%d",CARDNUM);

/**
*
*  Find the first core with a DIO bank.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (banknum=0;banknum<MAX_BANKS;banknum++)
		{
			if (BTIDIO_BankIsDIO(banknum,hCore))	break;
		}

		if (banknum != MAX_BANKS) break;
	}

	if (errval || corenum == MAX_CORES || banknum == MAX_BANKS)
	{
		printf("\nError:  No DIO banks present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing DIO core #%d",corenum);
	printf("\nUsing Bank %c",banknum + 'A');
	printf("\n");

/**
*
*  Configure banknum as a shunt, input/output bank with
*  Sequential Monitor of all discretes
*
**/

	BTICard_CardReset(hCore);

	/*
	*  Threshold:   1.4V, TTL levels
	*  Sample Rate: 1ms clock, no divide value --> 1ms sampling
	*/
	bankcfg = BANKCFGDIO_SERIES | BANKCFGDIO_INPUT | BANKCFGDIO_SEQALL;
	errval = BTIDIO_BankConfig(bankcfg,THRESHOLDDIO_TTL,SAMPLERATEDIO_MS | 0x0001,banknum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        bank #%d on core #%d.",banknum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure the Sequential Monitor for fill and halt mode (default).
*
**/

	errval = BTICard_SeqConfig(SEQCFG_DEFAULT,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring the sequential record.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
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
*  Display data on the screen.
*
**/

	printf("\nPress any key to exit...");
	printf("\n");
	printf("\n");

	while (!kbhit())
	{

		/* Initialize Seq Find and print the state and timetag of any new records*/
		seqcount = BTICard_SeqBlkRd(seqbuf,sizeof(seqbuf)/sizeof(seqbuf[0]),&blkcnt,hCore);

		BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

		while(!BTICard_SeqFindNextDIO(&pRecDIO,&sfinfo))
		{
 			if (!timetagIsBCD)
			{
				//Convert binary timetag to BCD
				BTICard_IRIGTimeBinToBCD(&(pRecDIO->timestamph),
										 &(pRecDIO->timestamp),
										 pRecDIO->timestamph,
										 pRecDIO->timestamp);
			}

			printf("\nBank %c:  DIN: ",pRecDIO->bank + 'A');

			printf("%c",(pRecDIO->state & 0x0080) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0040) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0020) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0010) ? '1' : '0');

			printf("%c",(pRecDIO->state & 0x0008) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0004) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0002) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0001) ? '1' : '0');

			printf(", Time: %02u:%02u %02u.%03u.%03u      ",
				BTICard_IRIGFieldGetHours(pRecDIO->timestamph,pRecDIO->timestamp),
				BTICard_IRIGFieldGetMin(pRecDIO->timestamph,pRecDIO->timestamp),
				BTICard_IRIGFieldGetSec(pRecDIO->timestamph,pRecDIO->timestamp),
				BTICard_IRIGFieldGetMillisec(pRecDIO->timestamph,pRecDIO->timestamp),
				BTICard_IRIGFieldGetMicrosec(pRecDIO->timestamph,pRecDIO->timestamp)
				);

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
