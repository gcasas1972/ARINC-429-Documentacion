
/**
*
*  BTI708 DRIVER EXAMPLE 8  (06/09/2011)
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
*  first compatible core to configure the first receive
*  channel and the first transmit channel to operate on
*  the self-test bus.  The transmitter is configured
*  with 128 messages that are initialized with
*  incrementing data.  The receive channel is configured
*  to record it's data to the Sequential Monitor.
*
*  An Event Log frequency of 0 is specified, which will
*  not generate any Event Log List entries for these channels.
*
*  The program will display the IRIG time and elapsed time from
*  receive message structure 0, until a key is pressed.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <time.h>
#include "BTICard.H"
#include "BTI708.H"

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
	HCARD  hCard;
	HCORE  hCore;
	ERRVAL errval;
	INT    corenum;
	INT    xmtchan;
	INT    rcvchan;
	BOOL   xmtfound;
	BOOL   rcvfound;
	BOOL   timetagIsBCD;
	ULONG  j,jj;
	USHORT Data[100];
	MSGFIELDS708 msgfields;
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
	printf("\n    *  BTI708 Example 8                                                  *");
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

	errval = BTICard_CardOpen(&hCard, CARDNUM);

	if (errval)
	{
		printf("\nError:  Either card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		exit(1);
	}

/**
*
*  Find the first ARINC 708 core with both a receive and a transmit channel.
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
			rcvfound = BTI708_ChIsRcv(rcvchan,hCore);
			if (rcvfound) break;
		}

		if (rcvfound)
		{
			for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
			{
				xmtfound = BTI708_ChIsXmt(xmtchan,hCore);
				if (xmtfound) break;
			}
		}

		if (rcvfound && xmtfound)	break;
	}

	if (errval || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
	{
		printf("\nError:  No compatible ARINC 708 core present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 708 core #%d",corenum);
	printf("\nUsing receive channel #%d",rcvchan);
	printf("\nUsing transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure receive channel.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI708_ChConfig(CHCFG708_ELAPSE|CHCFG708_SELFTEST,rcvchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure transmit channel.
*
**/

	errval = BTI708_ChConfig(CHCFG708_SELFTEST,xmtchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Build the receive channel messages.
*
**/

	errval = BTI708_RcvBuild(MSGCRT708_DEFAULT,0,1,rcvchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while building",errval);
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Build the transmit channel messages.
*
**/

	errval = BTI708_XmtBuild(MSGCRT708_DEFAULT,200,0,128,xmtchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while building",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Create and write the data for the messages.
*
**/

	for (j=0;j<128;j++)							/*Loop through all the messages*/
	{
		for (jj=0;jj<100;jj++) Data[jj] = (j << 8) + jj;
		BTI708_MsgDataWr(Data,j,xmtchan,hCore);	/*Write data to the Device*/
	}

/**
*
*  Configure the IRIG timer. (DEFAULT -> bit rate = IRIGB, internal, slave/reciever)
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
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");
	printf("\n");

	while (!kbhit())
	{
		BTI708_MsgBlockRd(&msgfields, 0, rcvchan, hCore);

		if (!timetagIsBCD)
		{
			//Convert binary timetag to BCD
			BTICard_IRIGTimeBinToBCD(&(msgfields.timetagh),
									 &(msgfields.timetag),
									 msgfields.timetagh,
									 msgfields.timetag);

			//Convert binary elapsetime to BCD
			BTICard_IRIGTimeBinToBCD(NULL,
									 &(msgfields.elapsetime),
									 0x0000,
									 msgfields.elapsetime);
		}

		printf("\r");

		printf("TT: %02u:%02u %02u.%03u.%03u    ",
				BTICard_IRIGFieldGetHours(msgfields.timetagh,msgfields.timetag),
				BTICard_IRIGFieldGetMin(msgfields.timetagh,msgfields.timetag),
				BTICard_IRIGFieldGetSec(msgfields.timetagh,msgfields.timetag),
				BTICard_IRIGFieldGetMillisec(msgfields.timetagh,msgfields.timetag),
				BTICard_IRIGFieldGetMicrosec(msgfields.timetagh,msgfields.timetag));

		printf("Elapse Time: %02ums ",BTICard_IRIGFieldGetMillisec(0x0000, msgfields.elapsetime));

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
