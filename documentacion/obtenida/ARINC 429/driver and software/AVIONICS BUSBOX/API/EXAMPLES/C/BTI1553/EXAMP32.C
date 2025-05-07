
/**
*
*  BTI1553 DRIVER EXAMPLE 32  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP32.C -- Alternating BC schedules on a status word bit
*
**/

/**
*
*  This example configures Card Number 0 as a bus controller
*  to transmit a normal schedule of three messages and
*  conditionally a different schedule of two messages.  The
*  normal schedule is created in such a way that the messages
*  are transmitted at frequencies of 100Hz, 50Hz, and 25Hz
*  (or every 10ms, 20ms, and 40ms, respectively). At the end
*  of each schedule a conditional branch is added to switch
*  to a separate schedule when the Service Request bit is set
*  in the RT status word.
*
**/

#include "BTICard.h"
#include "BTI1553.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

#define SRQ_CMD0	0x0F41			/*Command word for SRQ message*/
#define SRQ_CMD1	0x0B41			/*Command word for SRQ message*/

#define CMD0		0x0843			/*Command word for first message*/
#define CMD1		0x0821			/*Command word for second message*/
#define RCV_CMD2	0x0821			/*Receive command of an RT-RT transfer*/
#define XMT_CMD2	0x1C21			/*Transmit command of an RT-RT transfer*/

#define	FRAMETIME	10000			/*Frame time in microseconds*/

void main(void)
{
	HCARD  hCard;				/*Handle to card*/
	HCORE  hCore;				/*Handle to core*/
	ERRVAL errval;				/*Error return value*/
	INT    corenum;				/*Core number*/
	INT    channum;				/*Channel number*/

	MSGADDR BCMsgs[3];
	MSGADDR BCSRQMsgs[2];
	USHORT  Data[3] = {0,0,0};
	SCHNDX  IndexNormal, IndexBranchSRQ, IndexSRQ;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP32  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 32                                                *");
	printf("\n    *  \"Alternating BC schedules on a status word bit\"                   *");
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
*  Configure the channel for bus controller mode.
*
**/

	BTICard_CardReset(hCore);									/*Reset the core*/

	errval = BTI1553_BCConfig(BCCFG1553_DEFAULT,channum,hCore);	/*Configure the core*/

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while configuring bus",errval);
		printf("\n        controller mode on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Create the message records for each message.
*
**/

	Data[0] = 0xFFFF;
	Data[1] = 0;
	Data[2] = 0;

	BCSRQMsgs[0] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,SRQ_CMD0,0,Data,hCore);
	BCSRQMsgs[1] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,SRQ_CMD1,0,Data,hCore);

	BCMsgs[0] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,CMD0,    0,       Data,hCore);
	BCMsgs[1] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,CMD1,    0,       NULL,hCore);
	BCMsgs[2] = BTI1553_BCCreateMsg(MSGCRT1553_RTRT,   RCV_CMD2,XMT_CMD2,NULL,hCore);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	/*Normal Schedule*/
	IndexNormal = BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);
	BTI1553_BCSchedMsg(BCMsgs[1],  channum,hCore);
	BTI1553_BCSchedMsg(BCMsgs[2],  channum,hCore);

	BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);

	BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);
	BTI1553_BCSchedMsg(BCMsgs[1],  channum,hCore);

	BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);
	BTI1553_BCSchedFrameEnd(channum,hCore);

	IndexBranchSRQ = BTI1553_BCSchedBranch(COND1553_SRQ,0,channum,hCore);
	BTI1553_BCSchedBranch(COND1553_ALWAYS,IndexNormal,channum,hCore);

	/*SRQ Schedule*/
	IndexSRQ = BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedMsg(BCSRQMsgs[0],channum,hCore);
	BTI1553_BCSchedMsg(BCSRQMsgs[1],channum,hCore);
	BTI1553_BCSchedFrameEnd(channum,hCore);

	BTI1553_BCSchedBranch(COND1553_SRQ,   IndexSRQ,   channum,hCore);
	BTI1553_BCSchedBranch(COND1553_ALWAYS,IndexNormal,channum,hCore);

	/*Update existing branch location to SRQ start index*/
	BTI1553_BCSchedBranchUpdate(IndexSRQ,IndexBranchSRQ,channum,hCore);

/**
*
*  Start the card to begin transmissions.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit....\n\n");

	while (!_kbhit())
	{
	}

/**
*
*  Stop the card.
*
**/

	BTICard_CardStop(hCore);

/**
*
*  The card MUST be closed before continuing
*
**/

	BTICard_CardClose(hCard);
}
