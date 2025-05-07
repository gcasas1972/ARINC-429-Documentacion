
/**
*
*  BTICSDB DRIVER EXAMPLE 8  (06/09/2011)
*  Copyright (c) 2005-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP8.C -- Polling the Event Log List
*
**/

/**
*
*  This program opens Card Number 0, finds the first
*  compatible core, creates filters for receive messages
*  and builds a transmit schedule. It enables the Event
*  Log and polls for received messages.
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

#define BYTESPERBLOCK    6
#define BLOCKSPERFRAME  18
#define FRAMESPERSECOND 10

void main(void)
{
	HCARD	hCard;
	HCORE	hCore;
	ERRVAL  errval;
	INT     corenum;
	INT     rcvchan;
	INT		xmtchan;
	BOOL	rcvfound,xmtfound;
	USHORT  Type;
	ULONG   Info;
	MSGADDR	xmtsync, xmtmsg1, xmtmsg2;
	MSGADDR msgaddr;
	MSGFIELDSCSDB msgfields;


	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP8  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICSDB Example 8                                                 *");
	printf("\n    *  \"Polling the Event Log List.\"                                     *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
	printf("\n");

/**
*
*  Open the card with the specified card number.
*  An error value is returned, which is tested
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
*  Find the first CSDB core with a receive and transmit channels.
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
*  Configure rcvchan for low-speed.
*  Configure xmtchan to transmit at low-speed.
*
**/

	BTICard_CardReset(hCore);

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
*  for the receive channel.  First, the default filter is
*  created.  Then, two filters are set for the two messages
*  of interest.
*
*  Each message is configured to create Event Log list entries.
*
**/

	BTICSDB_FilterDefault(MSGCRTCSDB_LOG | MSGCRTCSDB_HIT,rcvchan,hCore);
	BTICSDB_FilterSet(MSGCRTCSDB_LOG | MSGCRTCSDB_HIT,0x01,SIALL,rcvchan,hCore);
	BTICSDB_FilterSet(MSGCRTCSDB_LOG | MSGCRTCSDB_HIT,0x02,SIALL,rcvchan,hCore);


/**
*
*  Create a message for each of the addresses we are transmitting.
*
**/
	xmtsync	= BTICSDB_MsgCreate(MSGCRTCSDB_DEFAULT | MSGCRTCSDB_WIPESYNC,hCore);
	xmtmsg1	= BTICSDB_MsgCreate(MSGCRTCSDB_DEFAULT,hCore);
	xmtmsg2	= BTICSDB_MsgCreate(MSGCRTCSDB_DEFAULT,hCore);

/**
*
*  Next, a schedule is built using explicit message timing.
*
**/
	BTICSDB_SchedMsg(xmtsync,xmtchan,hCore);
	BTICSDB_SchedMsg(xmtmsg1,xmtchan,hCore);
	BTICSDB_SchedMsg(xmtmsg2,xmtchan,hCore);
	BTICSDB_SchedGap(1052,xmtchan,hCore);


/**
*
*  Initialize the Message Records.
*
**/
	BTICSDB_MsgDataByteWr(0x01,0,xmtmsg1,hCore);
	BTICSDB_MsgDataByteWr(0x02,0,xmtmsg2,hCore);

/**
*
*  Configure the Event Log list.
*
**/

	errval = BTICard_EventLogConfig(LOGCFG_ENABLE,1024,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the event log list on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
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
		if(BTICard_EventLogStatus(hCore) != STAT_EMPTY)
		{
			BTICard_EventLogRd(&Type,&Info,NULL,hCore);	//Read entry from Event Log list
			msgaddr = Info;

			BTICSDB_MsgBlockRd(&msgfields,msgaddr,hCore);

			printf("\n");
			printf("Msg Addr=%02X   " ,msgfields.data[0]);
			printf("Msg Status=%02X   ",msgfields.data[1]);
			printf("Hit Count=%d",msgfields.hitcount);
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
