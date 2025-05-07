
/**
*
*  BTICSDB DRIVER EXAMPLE 3 (06/09/2011)
*  Copyright (c) 2005-2011
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
#include "BTICSDB.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		     0
#define	MAX_CORES        4
#define	MAX_CHANNELS    32

#define BLOCKSPERFRAME  18
#define BYTESPERBLOCK    6
#define FRAMESPERSECOND 10

void main(void)
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	BOOL done = 0;
	INT corenum;
	INT rcvchan, xmtchan;
	BOOL rcvfound, xmtfound;
	MSGADDR msgaddr[2];
	INT	freq[2];
	BYTE bufcont[BYTESPERBLOCK];
	USHORT seqbuf[2048];
	ULONG seqcount;
	ULONG blkcnt;
	LPSEQRECORDCSDB pRecCSDB;
	SEQFINDINFO sfinfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP3  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICSDB Example 3                                                 *");
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
*  Configure rcvchan for low speed and record selective sequential.
*  Configure xmtchan for low speed and record sequential all.
*
**/

	BTICard_CardReset(hCore);

	errval = BTICSDB_ChConfig(CHCFGCSDB_SEQSEL,BITRATECSDB_LOWSPEED,BYTESPERBLOCK,FRAMESPERSECOND,BLOCKSPERFRAME,rcvchan,hCore); /*Configure rcvchan*/

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

	errval = BTICSDB_ChConfig(CHCFGCSDB_SEQALL,BITRATECSDB_LOWSPEED,BYTESPERBLOCK,FRAMESPERSECOND,BLOCKSPERFRAME,xmtchan,hCore); /*Configure xmtchan*/

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
*  Create a message for each of the addresses we are transmitting.
*
**/

	msgaddr[0] = BTICSDB_MsgCreate(MSGCRTCSDB_DEFAULT | MSGCRTCSDB_WIPESYNC,hCore);	/*create sync message*/
	msgaddr[1] = BTICSDB_MsgCreate(MSGCRTCSDB_DEFAULT,hCore);							/*create continuous message*/

/**
*
*  Set up the frame rates needed to build the schedule.
*  freq = (Bus Frames/Second) / (Message Updates/Second)
*
**/

	freq[0] = 1;	/*sync message is every frame*/
	freq[1] = 2;	/*every other frame*/

/**
*
*  Next, build a schedule using the messages and frequencies
*  specified.
*
**/

	errval = BTICSDB_SchedBuild(2,msgaddr,freq,0,0,xmtchan,hCore);

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
*  Initialize the Message Records.
*
**/

	//continuous message
	bufcont[0] = 0x12;	/*address byte*/
	bufcont[1] = 0x80;	/*status byte*/
	bufcont[2] = 0x00;	/*data = 121.1MHz*/
	bufcont[3] = 0x10;	/* "" */
	bufcont[4] = 0x21;	/* "" */
	bufcont[5] = 0x00;	/*pad*/
	BTICSDB_MsgDataWr(bufcont,BYTESPERBLOCK,msgaddr[1],hCore);


/**
*
*  Before any messages can be received, filters must be set
*  for the receive channel. Two filters are set for the two
*  messages of interest.
*
*  Record the two filtered messages to the sequential record.
*
**/

	BTICSDB_FilterSet(MSGCRTCSDB_SEQ,0x12,SIALL,rcvchan,hCore);
	BTICSDB_FilterSet(MSGCRTCSDB_SEQ,0xA5,SIALL,rcvchan,hCore);

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

		while(!BTICard_SeqFindNextCSDB(&pRecCSDB,&sfinfo))
		{
			printf("\nCh:%02u  Addr:%08lX  Bytes:%d  Time:%08lX              ",
				   ((pRecCSDB->activity & MSGACTCSDB_CHMASK) >> MSGACTCSDB_CHSHIFT),
				   pRecCSDB->data[0],
				   pRecCSDB->datacount,
				   pRecCSDB->timestamp);
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
