
/**
*
*  BTI1553 DRIVER EXAMPLE 33  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP33.C -- Skipping a scheduled BC subroutine
*
**/

/**
*
*  This example configures Card Number 0 as a bus controller
*  to transmit a schedule of three messages.  The schedule is
*  created in such a way that the messages are transmitted at
*  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
*  and 40ms, respectively).  A subroutine is created for
*  for each message.  A main schedule is created with calls to
*  each subroutine to produce the desired schedule.  The skip
*  property of each message can be toggled by the user keyboard.
*  A single toggle is needed for each message, even if the
*  message is present multiple times in the schedule.
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
	USHORT  Data[3] = {0,0,0};
	SCHNDX  Subroutine0, Subroutine1, Subroutine2;
	BOOL    SkipMsg0,    SkipMsg1,    SkipMsg2;
	BOOL    done;
	char	ch;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP33  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 33                                                *");
	printf("\n    *  \"Skipping a scheduled BC subroutine\"                              *");
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

	BCMsgs[0] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,CMD0,    0,       Data,hCore);
	BCMsgs[1] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,CMD1,    0,       NULL,hCore);
	BCMsgs[2] = BTI1553_BCCreateMsg(MSGCRT1553_RTRT,   RCV_CMD2,XMT_CMD2,NULL,hCore);

/**
*
*  Create a subroutine for each message
*
**/

	Subroutine0 = BTI1553_BCSchedMsg(BCMsgs[0],channum,hCore);		/* Create subroutine for message 0 */
	BTI1553_BCSchedReturn(channum,hCore);

	Subroutine1 = BTI1553_BCSchedMsg(BCMsgs[1],channum,hCore);		/* Create subroutine for message 1 */
	BTI1553_BCSchedReturn(channum,hCore);

	Subroutine2 = BTI1553_BCSchedMsg(BCMsgs[2],channum,hCore);		/* Create subroutine for message 2 */
	BTI1553_BCSchedReturn(channum,hCore);

/**
*
*  Schedule the subroutine calls to create the desired bus controller
*  schedule.
*
**/

	/* Create Schedule Main */
	BTI1553_BCSchedEntry(channum,hCore);							/* Set entry for main schedule */

	BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedCall(COND1553_ALWAYS,Subroutine0,channum,hCore);
	BTI1553_BCSchedCall(COND1553_ALWAYS,Subroutine1,channum,hCore);
	BTI1553_BCSchedCall(COND1553_ALWAYS,Subroutine2,channum,hCore);

	BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedCall(COND1553_ALWAYS,Subroutine0,channum,hCore);

	BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedCall(COND1553_ALWAYS,Subroutine0,channum,hCore);
	BTI1553_BCSchedCall(COND1553_ALWAYS,Subroutine1,channum,hCore);

	BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedCall(COND1553_ALWAYS,Subroutine0,channum,hCore);

	BTI1553_BCSchedRestart(channum,hCore);							/* A restart marks the end of the main */

/**
*
*  Start the card to begin transmissions.
*
**/

	SkipMsg0 = SkipMsg1 = SkipMsg2 = 0;

	BTICard_CardStart(hCore);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\n\tOPTIONS:");
	printf("\n\t0   = toggle the skip flag on message 0");
	printf("\n\t1   = toggle the skip flag on message 1");
	printf("\n\t2   = toggle the skip flag on message 2");
	printf("\n\tESC = Exit program");
	printf("\n\n");

	for (done=0;!done;)
	{
		printf("\rMsg0:%s  Msg1:%s  Msg2:%s",(SkipMsg0) ? "Skipped    ":"Not Skipped",(SkipMsg1) ? "Skipped    ":"Not Skipped",(SkipMsg2) ? "Skipped    ":"Not Skipped");

		if (_kbhit())
		{
			ch = _getch();

			switch (ch)
			{
				case 27:	/* ESC */
				{
					done=1;
					break;
				}
				case 48:	/* 0 */
				{
					SkipMsg0 = !SkipMsg0;
					BTI1553_CmdSkipWr(SkipMsg0,Subroutine0,channum,hCore);
					break;
				}
				case 49:	/* 1 */
				{
					SkipMsg1 = !SkipMsg1;
					BTI1553_CmdSkipWr(SkipMsg1,Subroutine1,channum,hCore);
					break;
				}
				case 50:	/* 2 */
				{
					SkipMsg2 = !SkipMsg2;
					BTI1553_CmdSkipWr(SkipMsg2,Subroutine2,channum,hCore);
					break;
				}
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
