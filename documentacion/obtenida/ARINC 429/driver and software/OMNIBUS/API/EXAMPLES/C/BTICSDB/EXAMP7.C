
/**
*
*  BTICSDB DRIVER EXAMPLE 7  (06/09/2011)
*  Copyright (c) 2005-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP7.C -- Transmit and Receive List Buffer (burst) example
*
**/

/**
*
*  This program opens the Card Number 0, finds the first
*  compatible core, and configures transmit and receive
*  list buffers with burst messages that are triggered
*  by the user.
*
**/

#include "BTICard.h"
#include "BTICSDB.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM          0
#define	MAX_CORES        4
#define	MAX_CHANNELS    32

#define BYTESPERBLOCK    6
#define BLOCKSPERFRAME  18
#define FRAMESPERSECOND 10
#define LISTSIZE        10

void main(void)
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT count;
	INT corenum;
	INT rcvchan, xmtchan;
	BOOL rcvfound, xmtfound;
	INT i,j;
	MSGADDR xmtmsg, rcvmsg, syncmsg;
	LISTADDR xmtlistaddr, rcvlistaddr;
	BYTE xmtbuf[BYTESPERBLOCK];
	BYTE rcvbuf[BYTESPERBLOCK];
	INT input;
	BOOL done=0;
	INT dataval=0;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP7  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICSDB Example 7                                                 *");
	printf("\n    *  \"Program for transmit and receive (burst) list buffers.\"          *");
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
		printf("\n        an error occurred (%i) opening the card.",hCard);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		exit(1);
	}

	printf("\nUsing CSDB card #%d",CARDNUM);

/**
*
*  Find the first CSDB core with both a receive and a transmit channel.
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
			rcvfound = BTICSDB_ChIsRcv(rcvchan,hCore);
			if (rcvfound) break;
		}

		if (rcvfound)
		{
			for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
			{
				xmtfound = BTICSDB_ChIsXmt(xmtchan,hCore);
				if (xmtfound) break;
			}
		}

		if (rcvfound && xmtfound)	break;
	}

	if (errval || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
	{
		printf("\nError:  No compatible CSDB core present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing CSDB core #%d",corenum);
	printf("\nUsing receive channel #%d",rcvchan);
	printf("\nUsing transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure rcvchan at low-speed with the self-test
*  wraparound enabled. Configure xmtchan to transmit
*  at low-speed with the self-test wraparound enabled.
*
**/

	BTICard_CardReset(hCore);            /*Reset the card*/

	errval = BTICSDB_ChConfig(CHCFGCSDB_SELFTEST,BITRATECSDB_LOWSPEED,BYTESPERBLOCK,FRAMESPERSECOND,BLOCKSPERFRAME,rcvchan,hCore); /*Configure rcvchan*/

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

	errval = BTICSDB_ChConfig(CHCFGCSDB_SELFTEST,BITRATECSDB_LOWSPEED,BYTESPERBLOCK,FRAMESPERSECOND,BLOCKSPERFRAME,xmtchan,hCore); /*Configure xmtchan*/

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

	rcvmsg	= BTICSDB_FilterSet(MSGCRTCSDB_DEFAULT,0x01,SIALL,rcvchan,hCore);

/**
*
*  Create a message for each of the labels we are transmitting.
*
**/
	syncmsg	= BTICSDB_MsgCreate(MSGCRTCSDB_WIPESYNC,hCore);	/* Message is initialized to be a sync message */
	xmtmsg	= BTICSDB_MsgCreate(MSGCRTCSDB_DEFAULT | MSGCRTCSDB_BURST,hCore);

/**
*
*  Next, a schedule is built by creating explicit message timing.
*  12.5kbps / 10 frames/second = 1250 bits/frame
*  1250 bits/frame - (2 messages * 6 bytes/block * 11 bits/byte) = 1118 bit-times
*
**/
	BTICSDB_SchedMsg(syncmsg,xmtchan,hCore);
	BTICSDB_SchedMsg(xmtmsg,xmtchan,hCore);
	BTICSDB_SchedGap(1118,xmtchan,hCore);

/**
*
*  Create the transmit and receive list buffers.
*
*  The transmit list buffer will be a FIFO, which will
*  burst data 16 times per message as long as it is fresh.
*
*  The receive list buffer will be a FIFO, which we will
*  read out of and display to the screen.
*
**/
	xmtlistaddr = BTICSDB_ListXmtCreate(LISTCRTCSDB_FIFO,LISTSIZE,xmtmsg,hCore);
	rcvlistaddr = BTICSDB_ListRcvCreate(LISTCRTCSDB_FIFO,LISTSIZE,rcvmsg,hCore);

/**
*
*  Initialize the transmit list buffer.
*
**/

	for (i=0;i<LISTSIZE-1;i++)			//write one less than size of FIFO
	{
		xmtbuf[0] = 0x01;				//set address byte
		for (j=1;j<BYTESPERBLOCK;j++)	//for each data byte in the entry
		{
			xmtbuf[j] = i;
		}

		BTICSDB_ListDataWr(xmtbuf,BYTESPERBLOCK,xmtlistaddr,hCore);
	}

	BTICSDB_MsgValidSet(xmtmsg,hCore);

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

	printf("\nPress escape to exit or any other key to trigger a burst transmission.\n\n");

	while(!done)
	{
		if (kbhit())
		{
			input = getch();
			if (input == 0x1B)
			{
				done = 1;
				break;
			}
			else
			{
				dataval++;
			}

			xmtbuf[0] = 0x01;
			for (j=1;j<BYTESPERBLOCK;j++)
			{
				xmtbuf[j] = dataval;
			}

			BTICSDB_ListDataWr(xmtbuf,BYTESPERBLOCK,xmtlistaddr,hCore);

			BTICSDB_MsgValidSet(xmtmsg,hCore);
		}

		if(BTICSDB_ListStatus(rcvlistaddr,hCore) != STAT_EMPTY)
		{
			count = BTICSDB_ListDataRd(rcvbuf,BYTESPERBLOCK,rcvlistaddr,hCore);
			printf("\nAddress=%02X   Data=%02X   Bytes=%d",rcvbuf[0],rcvbuf[1],count);
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
