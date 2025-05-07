
/**
*
*  BTI429 DRIVER EXAMPLE 3  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- Monitor example
*
**/

/**
*
*  This program opens Card Number 0, finds the first
*  compatible core, builds a transmit schedule using
*  transmit interval information, and creates filters
*  for two receive messages.  It also enables the
*  Sequential Monitor to record transmitted and
*  received messages.
*
**/

#include "BTICard.H"
#include "BTI429.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

void main(void)
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT corenum;
	INT rcvchan, xmtchan;
	BOOL rcvfound, xmtfound;
	MSGSTRUCT429 msgdefault, latitude, longitude;
	MSGSTRUCT429 comp_airspeed, tot_air_temp, altitude_rate;
	MSGADDR msgaddr[3];
	INT	min_intrvls[3];
	INT	max_intrvls[3];
	USHORT seqbuf[2048];
	ULONG seqcount;
	ULONG blkcnt;
	LPSEQRECORD429 pRec429;
	SEQFINDINFO sfinfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP3  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI429 Example 3                                                  *");
	printf("\n    *  \"Program for monitor example.\"                                    *");
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
*  Configure rcvchan for automatic speed detection.
*  Configure xmtchan to transmit at low speed.
*
*  Record all of xmtchan data into the Sequential Record.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI429_ChConfig(CHCFG429_AUTOSPEED,rcvchan,hCore);   /*Configure channel*/

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

	errval = BTI429_ChConfig(CHCFG429_SEQALL,xmtchan,hCore);      /*Configure channel*/

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
*  Create a message for each of the labels we are transmitting.
*
**/

	comp_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT,hCore);
	tot_air_temp.addr  = BTI429_MsgCreate(MSGCRT429_DEFAULT,hCore);
	altitude_rate.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT,hCore);

/**
*
*  Set up the arrays of message addresses; and intervals
*  needed to build the schedule.  Note that the nth element
*  in each array correspond to each other.
*
**/

	msgaddr[0] = comp_airspeed.addr;
	min_intrvls[0] = 250;
	max_intrvls[0] = 500;

	msgaddr[1] = tot_air_temp.addr;
	min_intrvls[1] = 250;
	max_intrvls[1] = 500;

	msgaddr[2] = altitude_rate.addr;
	min_intrvls[2] = 100;
	max_intrvls[2] = 200;

/**
*
*  Next, build a schedule using the minimum and maximum
*  transmit intervals.
*
**/

	errval = BTI429_SchedBuild(3,msgaddr,min_intrvls,max_intrvls,xmtchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while building",errval);
		printf("\n        a schedule on channel #%d of core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Initialize the three Message Records.
*
**/

	comp_airspeed.data = BTI429_FldPutLabel(0L,0206);   /*Init label field*/
	tot_air_temp.data  = BTI429_FldPutLabel(0L,0211);
	altitude_rate.data = BTI429_FldPutLabel(0L,0212);

	comp_airspeed.data = BTI429_BNRPutMant(comp_airspeed.data,0L,14,0);   /*Init BNR data*/
	tot_air_temp.data  = BTI429_BNRPutMant(tot_air_temp.data,0L,11,0);
	altitude_rate.data = BTI429_BNRPutMant(altitude_rate.data,0L,16,0);

	BTI429_MsgDataWr(comp_airspeed.data,comp_airspeed.addr,hCore);
	BTI429_MsgDataWr(tot_air_temp.data,tot_air_temp.addr,hCore);
	BTI429_MsgDataWr(altitude_rate.data,altitude_rate.addr,hCore);

/**
*
*  Before any messages can be received, filters must be set
*  for the receive channel.  First, the default filter is
*  created.  Then, two filters are set for the two messages
*  of interest.
*
*  Record the two filtered messages.
*
**/

	msgdefault.addr = BTI429_FilterDefault(MSGCRT429_DEFAULT,rcvchan,hCore);
	latitude.addr   = BTI429_FilterSet(MSGCRT429_SEQ,0310,SDIALL,rcvchan,hCore);
	longitude.addr  = BTI429_FilterSet(MSGCRT429_SEQ,0311,SDIALL,rcvchan,hCore);

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
		seqcount = BTICard_SeqBlkRd(seqbuf,sizeof(seqbuf)/sizeof(seqbuf[0]),&blkcnt,hCore);

		BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

		while(!BTICard_SeqFindNext429(&pRec429,&sfinfo))
		{
			printf("\nCore:%d  Ch:%02u  Data:%08lX  Time Stamp:%08lX",
				   corenum,
				   ((pRec429->activity & MSGACT429_CHMASK) >> MSGACT429_CHSHIFT),
				   pRec429->data,
				   pRec429->timestamp);

			if (BTICard_SeqFindCheckVersion((LPUSHORT)pRec429, SEQVER_1))
			{
				printf("  decgap:%X",pRec429->decgap);
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
