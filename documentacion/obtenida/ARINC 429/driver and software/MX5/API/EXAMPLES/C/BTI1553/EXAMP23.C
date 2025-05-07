
/**
*
*  BTI1553 DRIVER EXAMPLE 23  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP23.C -- Asynchronous BC messages while running
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
*  The program watches the 'hit' bit associated with the 0842H
*  BC-RT message.  When the message is transmitted and the
*  bit is set, the program updates the data words.
*
*  This program also sends an unscheduled (asynchronous)
*  message each time the space bar is pressed. The message
*  is transmitted at the end of a frame in the Schedule.
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
#define CMD3		0x0862			/*Command word for asynchronous message*/

#define	FRAMETIME	10000			/*Frame time in microseconds*/

void main(void)
{
	HCARD  hCard;				/*Handle to card*/
	HCORE  hCore;				/*Handle to core*/
	ERRVAL errval;				/*Error return value*/
	INT    corenum;				/*Core number*/
	INT    channum;				/*Channel number*/

	MSGADDR BCMsgs[3];
	ULONG   MsgErrors;
	USHORT  Data[3] = {0,0,0};
	INT     txcount;
	BOOL    done;
	char    ch;

	XMITFIELDS1553 Msg;				/*Message structure*/

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP23  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 23                                                *");
	printf("\n    *  \"Asynchronous BC messages while running\"                          *");
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
*  Create the message records for each of the four messages.
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

/**
*
*  Initialize the asynchronous message command and data words,
*  and select a BC-RT transfer.
*
**/

	Msg.ctrlflags = MSGCRT1553_BCRT;					/*Selects BC-RT transfer*/
	Msg.cwd1      = BTI1553_ValPackCWD(1,0,3,2);		/*Receive command word*/
	Msg.data[0]   = 0x1234;								/*Data word 0*/
	Msg.data[1]   = 0x5678;								/*Data word 1*/
	Msg.data[2]   = 0x9ABC;								/*Data word 2*/

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

	printf("\n\tOPTIONS:");
	printf("\n\tSPACE = Send asynchronous message");
	printf("\n\tESC   = Exit program");
	printf("\n\n");

	txcount = 0;

	for (done=0;!done;)
	{
/**
*
*  Watch the 'hit' bit of the first message to see if it has
*  been transmitted.  If it has, update the data words.
*
**/

		MsgErrors = BTI1553_MsgFieldRd(FIELD1553_ERROR,BCMsgs[0],hCore);

		if (MsgErrors & MSGERR1553_HIT)
		{
			Data[0] += 2;											/*Calculate the new data words*/
			Data[1] += 4;
			Data[2] += 6;

			BTI1553_MsgDataWr(Data,3,BCMsgs[0],hCore);				/*Write the new data words*/

			BTI1553_MsgFieldWr(0,FIELD1553_ERROR,BCMsgs[0],hCore);	/*Clear the 'hit' bit*/

			printf("\rTransmitting data {%04XH, %04XH, %04XH}, async-count: %d",Data[0],Data[1],Data[2],txcount);
		}

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
				case 32:	/* SPACE */
				{
					errval = BTI1553_BCTransmitMsg(&Msg,channum,hCore);	/*Transmit the message*/

					if (errval < 0)
					{
						printf("\nError:  An error was encountered (%i) while transmitting the message.",errval);
						printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
						done=1;
						break;
					}

					txcount = txcount + 1;

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
