
/**
*
*  BTI1553 DRIVER EXAMPLE 19  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP19.C -- BC message skipping and single-shot
*
**/

/**
*
*  This example configures Card Number 0 as a bus controller
*  to transmit a schedule of three messages.  The schedule is
*  created in such a way that the messages are transmitted at
*  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
*  and 40ms, respectively).
*
*  The program uses keyboard keys to control the skip setting
*  of the first message and the single-shot setting on a
*  schedule entry.
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

#ifndef	TRUE
#define	TRUE 1
#endif

#ifndef	FALSE
#define	FALSE 0
#endif

void main(void)
{
	HCARD  hCard;				/*Handle to card*/
	HCORE  hCore;				/*Handle to core*/
	ERRVAL errval;				/*Error return value*/
	INT    corenum;				/*Core number*/
	INT    channum;				/*Channel number*/

	MSGADDR BCMsgs[3];
	USHORT  Data[3] = {0,0,0};
	SCHNDX  schndx0[4];
	SCHNDX  schndx2;
	BOOL    skip;
	BOOL    shot;
	BOOL    trigger;
	BOOL    done;
	char    ch;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP19  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 19                                                *");
	printf("\n    *  \"BC message skipping and single-shot\"                             *");
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
*  Create the message records for each of the three messages.
*
**/

	Data[0] = 0;
	Data[1] = 0;
	Data[2] = 0;

	BCMsgs[0] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,CMD0,    0,       Data,hCore);
	BCMsgs[1] = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,CMD1,    0,       NULL,hCore);
	BCMsgs[2] = BTI1553_BCCreateMsg(MSGCRT1553_RTRT,   RCV_CMD2,XMT_CMD2,NULL,hCore);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	             BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	schndx0[0] = BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);
	             BTI1553_BCSchedMsg(BCMsgs[1],  channum,hCore);
	schndx2    = BTI1553_BCSchedMsg(BCMsgs[2],  channum,hCore);

	             BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	schndx0[1] = BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);

	             BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	schndx0[2] = BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);
	             BTI1553_BCSchedMsg(BCMsgs[1],  channum,hCore);

	             BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	schndx0[3] = BTI1553_BCSchedMsg(BCMsgs[0],  channum,hCore);

/**
*
*  Initialize the state on the card
*
**/

	skip    = FALSE;
	shot    = TRUE;
	trigger = FALSE;

	/*BTI1553_MsgSkipWr(skip, BCMsgs[0], hCore);*/		/* Can skip at the message object only on 4G Devices */

	BTI1553_CmdShotWr(shot, schndx2, channum, hCore);

/**
*
*  Start the card to begin receiving messages.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Change the state when keyboard keys are pressed. Exit when ESC is pressed.
*
**/

	printf("\n\tOPTIONS:");
	printf("\n\tS   = Toggle skip");
	printf("\n\tT   = Trigger Single-Shot");
	printf("\n\tESC = Exit program");
	printf("\n\n");

	for (done=0;!done;)
	{
		printf("\r\tState: BCMsg[0]=%s BCMsg[2]=Single-shot",(skip) ? "Skipped    ":"Not skipped");

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
				case  83:	/* S */
				case 115:	/* s */
				{
					skip = !skip;
					break;
				}
				case  84:	/* T */
				case 116:	/* t */
				{
					trigger = TRUE;
					break;
				}
				default:
				{
					continue;
				}
			}

			/*BTI1553_MsgSkipWr(skip, BCMsgs[0], hCore);*/			/* Can skip at the message object only on 4G Devices */

			BTI1553_CmdSkipWr(skip, schndx0[0], channum, hCore);	/* Set skip in the schedule */
			BTI1553_CmdSkipWr(skip, schndx0[1], channum, hCore);
			BTI1553_CmdSkipWr(skip, schndx0[2], channum, hCore);
			BTI1553_CmdSkipWr(skip, schndx0[3], channum, hCore);

			if (trigger)
			{
				BTI1553_CmdSkipWr(FALSE, schndx2, channum, hCore);	/* Clear skip in the schedule, will be set after the next transmission */
				trigger = FALSE;
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
