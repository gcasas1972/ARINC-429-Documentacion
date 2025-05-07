
/**
*
*  BTI708 DRIVER EXAMPLE 10  (06/09/2011)
*  Copyright (c) 2003-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP10.C -- Parametrics example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first transmit channel on the first 708 Core to transmit
*  a sequence of 32 messages at a rate of 200Hz. The messages
*  are automatically assigned the numbers 0 through 31.
*
*  The user can then control the amplitude using the UP and
*  DOWN arrow keys.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

#include "BTICard.H"
#include "BTI708.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		 0
#define	MAX_CORES    4
#define	MAX_CHANNELS 32

#define	FRAMEFREQ	 200            /*Frame frequency of 200Hz*/
#define LOGFREQ		 16             /*Generate a Log Event after every 16th message*/
#define	FRAMECOUNT	 32             /*Transmit a total of 32 messages*/

#define DAC_HIGH	 0x0FFF
#define DAC_LOW		 0x0599

void main(void)
{
	HCARD  hCard;
	HCORE  hCore;
	ERRVAL errval;
	INT    corenum;
	INT    xmtchan;
	INT    j,jj;
	USHORT Data[100];
	USHORT dacval = 0x0FF0;		/* Amplitude */
	INT    count  = 0;
	BOOL   done;
	char   ch;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP10  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2003-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI708 Example 10                                                 *");
	printf("\n    *  \"Parametrics example.\"                                            *");
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

/**
*
*  Find the first ARINC 708 core with a transmit channel that supports parametrics.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)
		{
			if (BTI708_ChIsXmt(xmtchan,hCore) && BTI708_ChGetInfo(INFO708_PARAM,xmtchan,hCore))	break;
		}

		if (xmtchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 708 parametric transmit channels");
		printf("\n        present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\n\tUsing ARINC 708 core #%d",corenum);
	printf("\n\tUsing parametric transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure xmtchan
*
**/

	BTICard_CardReset(hCore);

	errval = BTI708_ChConfig(CHCFG708_DEFAULT,xmtchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Build the transmit channel messages.
*
**/

	errval = BTI708_XmtBuild(MSGCRT708_DEFAULT,FRAMEFREQ,LOGFREQ,FRAMECOUNT,xmtchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while building",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Create and write the data for the messages.
*
**/

	for (j=0;j<FRAMECOUNT;j++)					/*Loop through all the messages*/
	{
		for (jj=0;jj<100;jj++) Data[jj] = j + (count * FRAMECOUNT);
		BTI708_MsgDataWr(Data,j,xmtchan,hCore);	/*Write data to the Device*/
	}
	count++;

/**
*
*  Configure Parametrics on xmtchan.
*
**/

	dacval = (dacval>DAC_HIGH) ? DAC_HIGH:dacval;
	dacval = (dacval<DAC_LOW) ? DAC_LOW:dacval;

	errval = BTI708_ParamAmplitudeConfig(PARAMCFG708_DEFAULT,dacval,xmtchan,hCore);
	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the amplitude on channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)\n\n",BTICard_ErrDescStr(errval,hCard));
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
*  Change parametric values when arrow keys are pressed. Exit when ESC is pressed.
*
**/

	printf("\n\tOPTIONS:");
	printf("\n\tARROW UP    = Add 16 to dacval");
	printf("\n\tARROW DOWN  = Subtract 16 from dacval");
	printf("\n\tESC         = Exit program");
	printf("\n\n");

	for (done=0;!done;)
	{
		printf("\r\tDacval: %03X  ",dacval);

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

					BTI708_ChStop(xmtchan,hCore);

					errval = BTI708_ParamAmplitudeConfig(PARAMCFG708_DEFAULT,dacval,xmtchan,hCore);
					if (errval < 0)
					{
						printf("\nError:  An error was encountered (%i) while configuring",errval);
						printf("\n        the amplitude on channel #%d on core #%d.",xmtchan,corenum);
						printf("\n        (%s)\n\n",BTICard_ErrDescStr(errval,hCard));
						done=1;
					}

					BTI708_ChStart(xmtchan,hCore);

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
