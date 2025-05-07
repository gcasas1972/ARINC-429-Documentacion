
/**
*
*  BTI1553 DRIVER EXAMPLE 17  (06/09/2011)
*  Copyright (c) 2003-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP17.C -- Parametrics Example
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
*  The program uses the up and down arrow keys to control the
*  frequency output on the bus. The left and right arrow keys
*  are used to control the offset associated with the mid-bit
*  crossing.
*
**/

#include "BTICard.H"
#include "BTI1553.H"
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

#define DAC_HIGH	0x0FFF
#define DAC_LOW		0x0599
#define OFFSET_HIGH 0x0064
#define OFFSET_LOW  0x0000

#ifndef	TRUE
#define	TRUE 1
#endif

#ifndef	FALSE
#define	FALSE 0
#endif

void main(void)
{
	HCARD   hCard;					/*Handle to card*/
	HCORE   hCore;					/*Handle to core*/
	ERRVAL  errval;					/*Error return value*/
	INT     corenum;				/*Core number*/
	INT     channum;				/*Channel number*/

	MSGADDR BCMsgs[3];
	USHORT  Data[3] = {0,0,0};
	USHORT  dacval = 0x0FF0;		/*Amplitude*/
	USHORT  offset = 0x0032;		/*Mid-Bit crossing offset (error)*/
	BOOL    done;
	char    ch;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP17  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2003-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 17                                                *");
	printf("\n    *  \"Parametrics Example\"                                             *");
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
*  Find the first MIL-STD-1553 core and channel that supports parametrics and
*  error generation.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (channum=0;channum<MAX_CHANNELS;channum++)
		{
			if ( BTI1553_ChIs1553(channum,hCore) )
			{
				if (BTI1553_ChGetInfo(INFO1553_PARAM,channum,hCore) &&
					BTI1553_ChGetInfo(INFO1553_ERRORGEN,channum,hCore) )	break;
			}
		}

		if (channum != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
	{
		printf("\nError:  No 1553 channels that support parametrics and");
		printf("\n        error generation in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing MIL-STD-1553 core #%d",corenum);
	printf("\nUsing parametric 1553 channel #%d",channum);
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
*  Configure Parametrics on channum
*
**/

	dacval = (dacval>DAC_HIGH) ? DAC_HIGH:dacval;
	dacval = (dacval<DAC_LOW)  ? DAC_LOW:dacval;

	errval = BTI1553_ParamAmplitudeConfig(PARAMCFG1553_DEFAULT,dacval,channum,hCore);
	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the amplitude on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)\n\n",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Define the type of error generation.  One of the bus
*  controller messages is tagged to generate errors.
*
**/

	offset = (offset>OFFSET_HIGH) ? OFFSET_HIGH:offset;
	offset = (offset<OFFSET_LOW)  ? OFFSET_LOW:offset;

	errval = BTI1553_ErrorDefine(ERRDEF1553_ZEROX2,0,offset,0,0,channum,hCore);
	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while defining",errval);
		printf("\n        the error on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)\n\n",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

	BTI1553_ErrorTagBC(TRUE,BCMsgs[0],channum,hCore);
	BTI1553_ErrorCtrl(ERRCTRL1553_ON | ERRCTRL1553_TAGMSG,channum,hCore);

/**
*
*  Start the card to begin receiving messages.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Change parametric values when arrow keys are pressed. Exit when ESC is pressed.
*
**/

	printf("\n\tOPTIONS:");
	printf("\n\tARROW UP    = Add 16 to dacval");
	printf("\n\tARROW DOWN  = Subtract 16 from dacval");
	printf("\n\tARROW RIGHT = Increment offset");
	printf("\n\tARROW LEFT  = Decrement offset");
	printf("\n\tESC         = Exit program");
	printf("\n\n");

	for (done=0;!done;)
	{
		printf("\r\tDacval: %03X (Hex)   Offset: %03X (Hex)",dacval,offset);

		if (kbhit())
		{
			ch = _getch();

			if (ch==0xE0)	ch=_getch();	/* When reading arrow key _getch() must be called twice. */

			switch (ch)
			{
				case 27:	/* ESC */
				{
					done=1;
					break;
				}
				case 72:	/* UP   */
				case 80:	/* DOWN */
				{
					if (ch==72)	dacval = (dacval+16>DAC_HIGH) ? DAC_HIGH : dacval+16;
					else        dacval = (dacval-16<DAC_LOW)  ? DAC_LOW  : dacval-16;

					BTI1553_ChStop(channum,hCore);

					errval = BTI1553_ParamAmplitudeConfig(PARAMCFG1553_DEFAULT,dacval,channum,hCore);
					if (errval < 0)
					{
						printf("\nError:  An error was encountered (%i) while configuring",errval);
						printf("\n        Amplitude on channel #%d on core #%d.",channum,corenum);
						printf("\n        (%s)\n\n",BTICard_ErrDescStr(errval,hCard));
						done=1;
					}

					BTI1553_ChStart(channum,hCore);

					break;
				}
				case 75:	/* LEFT  */
				case 77:	/* RIGHT */
				{
					if (ch==77)	offset = (offset+1>OFFSET_HIGH) ? OFFSET_HIGH : offset+1;
					else		offset = (offset-1<OFFSET_LOW)  ? OFFSET_LOW  : offset-1;

					BTI1553_ChStop(channum,hCore);

					errval = BTI1553_ErrorDefine(ERRDEF1553_ZEROX2,0,offset,0,0,channum,hCore);
					if (errval < 0)
					{
						printf("\nError:  An error was encountered (%i) while defining",errval);
						printf("\n        the error on channel #%d on core #%d.",channum,corenum);
						printf("\n        (%s)\n\n",BTICard_ErrDescStr(errval,hCard));
						done=1;
					}

					BTI1553_ChStart(channum,hCore);

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
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardClose(hCard);
}
