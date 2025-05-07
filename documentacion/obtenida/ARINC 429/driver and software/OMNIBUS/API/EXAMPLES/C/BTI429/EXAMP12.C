
/**
*
*  BTI429 DRIVER EXAMPLE 12  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP12.C -- IRIG Timer example.
*
**/

/**
*
*  This program opens Card Number 0, finds the first
*  compatible core, and enable the IRIG timer. A transmit
*  schedule is built using explicit message timing. The
*  self-test wraparound is enabled and filters are set to
*  receive the messages. A time-tag, minimum and maximum elapsed
*  time for each message is converted from the IRIG time and
*  displayed.
*
**/

#include "BTICard.h"
#include "BTI429.h"
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
	INT  corenum;
	INT  rcvchan;
	INT  xmtchan;
	BOOL rcvfound;
	BOOL xmtfound;
	BOOL timetagIsBCD;

	MSGSTRUCT429 xmt_airspeed, rcv_airspeed;
	MSGFIELDS429 airspeed_record;
	BTIIRIGTIME  irigtime;
	struct tm    *curtime;
	time_t       long_time;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP12  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI429 Example 12                                                 *");
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

	printf("\nUsing ARINC 429 card #%d",CARDNUM);

/**
*
*  Find the first ARINC 429 core with both a receive and a transmit channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		rcvfound = 0;
		xmtfound = 0;

		errval = BTICard_CoreOpen(&hCore,corenum,hCard);	/* Open a handle to the core. */
		if (errval) break;

		for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
		{
			rcvfound = BTI429_ChIsRcv(rcvchan,hCore);
			if (rcvfound) break;
		}

		if (rcvfound)
		{
			for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
			{
				xmtfound = BTI429_ChIsXmt(xmtchan,hCore);
				if (xmtfound) break;
			}
		}

		if (rcvfound && xmtfound)	break;
	}

	if (errval || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
	{
		printf("\nError:  No compatible ARINC 429 core present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 429 core #%d",corenum);
	printf("\nUsing receive channel #%d",rcvchan);
	printf("\nUsing transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure rcvchan to receive at low speed with the
*  Min/Max Elapse Time option also enabled.
*  Note that the self-test wraparound is also enabled.
*
*  Configure xmtchan to transmit at low speed.
*  Note that the self-test wraparound is also enabled.
*  The external line drivers are disabled, and xmtchan is
*  connected internally to all the receive channels.
*
**/

	BTICard_CardReset(hCore);                   /*Reset the card*/

	errval = BTI429_ChConfig(CHCFG429_MAXMIN|CHCFG429_SELFTEST,rcvchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

	errval = BTI429_ChConfig(CHCFG429_SELFTEST,xmtchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Before any messages can be received, filters must be set
*  for the receive channel.
*
**/

	rcv_airspeed.addr = BTI429_FilterSet(MSGCRT429_DEFAULT,0206,SDIALL,rcvchan,hCore);

/**
*
*  Create a message for each of the labels we are transmitting.
*
**/

	xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT,hCore);

/**
*
*  Next, a schedule is built by creating explicit message timing.
*
**/

	BTI429_SchedMsg(xmt_airspeed.addr,xmtchan,hCore);
	BTI429_SchedGap(1100,xmtchan,hCore);

/**
*
*  Those messages that are to be transmitted are initialized.
*
**/

	BTI429_MsgDataWr(0x00000086,xmt_airspeed.addr,hCore);

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

	printf("\nPress any key to exit....\n\n");

	while(!kbhit())
	{
		BTI429_MsgBlockRd(&airspeed_record,rcv_airspeed.addr,hCore);

		if (!timetagIsBCD)
		{
			//Convert binary timetag to BCD
			BTICard_IRIGTimeBinToBCD(&airspeed_record.timetagh,
									 &airspeed_record.timetag,
									 airspeed_record.timetagh,
									 airspeed_record.timetag);
		}

		printf("\r");

		printf("TT: %02u:%02u %02u.%03u.%03u    ",
				BTICard_IRIGFieldGetHours(airspeed_record.timetagh,airspeed_record.timetag),
				BTICard_IRIGFieldGetMin(airspeed_record.timetagh,airspeed_record.timetag),
				BTICard_IRIGFieldGetSec(airspeed_record.timetagh,airspeed_record.timetag),
				BTICard_IRIGFieldGetMillisec(airspeed_record.timetagh,airspeed_record.timetag),
				BTICard_IRIGFieldGetMicrosec(airspeed_record.timetagh,airspeed_record.timetag));

		printf("AirSpeed: min/max=%02ums/%02ums ",
				BTICard_IRIGFieldGetMillisec(0x0000, airspeed_record.mintime),
				BTICard_IRIGFieldGetMillisec(0x0000, airspeed_record.maxtime));

		printf("    ");
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
