
/**
*
*  BTI1553 DRIVER EXAMPLE 31  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP31.C -- BC schedule startup frame
*
**/

/**
*
*  This example configures Card Number 0 as a bus controller
*  to transmit a schedule of three messages.  The schedule is
*  created in such a way that the messages are transmitted at
*  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
*  and 40ms, respectively). The schedule contains an
*  initialization block containing a single message and a
*  branch (goto) back to the init block.
*
*  The program watches the 'hit' bit and 'no response' bit
*  associated with the init message.  When a valid response
*  is detected the init branch is updated to allow the
*  schedule to run its normal operation.
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

#define INIT_CMD	0x0F41			/*Command word for RT-Init message*/

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

	MSGADDR BCInitMsg;
	MSGADDR BCMsgs[3];
	ULONG   MsgErrors;
	USHORT  Data[3] = {0,0,0};
	SCHNDX  IndexInit, IndexBranch, IndexRestart;
	BOOL    InitComplete;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP31  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 31                                                *");
	printf("\n    *  \"BC schedule startup frame\"                                       *");
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

	BCInitMsg = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,INIT_CMD,0,       Data,hCore);

	BCMsgs[0] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,CMD0,    0,       Data,hCore);
	BCMsgs[1] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,CMD1,    0,       NULL,hCore);
	BCMsgs[2] = BTI1553_BCCreateMsg(MSGCRT1553_RTRT,   RCV_CMD2,XMT_CMD2,NULL,hCore);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	IndexInit = BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedMsg(BCInitMsg,channum,hCore);
	BTI1553_BCSchedFrameEnd(channum,hCore);

	IndexBranch = BTI1553_BCSchedBranch(COND1553_ALWAYS,IndexInit,channum,hCore);

	IndexRestart = BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
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

	BTI1553_BCSchedBranch(COND1553_ALWAYS,IndexRestart,channum,hCore);

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

	InitComplete = 0;

	printf("\nWaiting for response from RT 1 in the init block");

	while (!_kbhit())
	{
		if (!InitComplete)
		{

/**
*
*  Watch the 'hit' bit of the init message to see if it has
*  been transmitted.  If it has, check for a valid response.
*  Once a valid response is detected change the init branch
*  to point to IndexRestart.
*
**/

			MsgErrors = BTI1553_MsgFieldRd(FIELD1553_ERROR,BCInitMsg,hCore);

			if ( (MsgErrors & MSGERR1553_HIT) && (0==(MsgErrors & MSGERR1553_NORESP)) )
			{
				InitComplete = 1;

				printf("\nRT 1 responded. Continuing with normal schedule.");

				BTI1553_BCSchedBranchUpdate(IndexRestart,IndexBranch,channum,hCore);
			}
			else
			{
				BTI1553_MsgFieldWr(0,FIELD1553_ERROR,BCInitMsg,hCore);		/*Clear the 'hit' bit*/
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
*  The card MUST be closed before continuing
*
**/

	BTICard_CardClose(hCard);
}
