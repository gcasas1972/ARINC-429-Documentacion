
/**
*
*  BTI1553 DRIVER EXAMPLE 24  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP24.C -- Controlling RT status word bits
*
**/

/**
*
*  This example configures Card Number 0 as an RT.  The
*  user controls bits in the RT status word using the
*  keyboard.
*
**/

#include "BTICard.h"
#include "BTI1553.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define TAVAL		  1
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

#define SW_BUSY		  0x0008
#define SW_SRQ        0x0100

void main(void)
{
	HCARD  hCard;				/*Handle to card*/
	HCORE  hCore;				/*Handle to core*/
	ERRVAL errval;				/*Error return value*/
	INT    corenum;				/*Core number*/
	INT    channum;				/*Channel number*/

	USHORT swdval;				/*MIL-STD-1553 status word*/
	BOOL   busy;
	BOOL   srq;
	BOOL   done;
	char   ch;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP24  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 24                                                *");
	printf("\n    *  \"Controlling RT status word bits\"                                 *");
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
*  Configure the channel for remote terminal mode.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI1553_RTConfig(RTCFG1553_DEFAULT,TAVAL,channum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring for",errval);
		printf("\n        remote terminal mode on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Initialize the status word flags
*
**/

	busy = 0;
	srq = 0;

	swdval = BTI1553_RTSWDRd(TAVAL,channum,hCore);

	swdval = (busy) ? (swdval | SW_BUSY) : (swdval & (~SW_BUSY));
	swdval = (srq)  ? (swdval | SW_SRQ)  : (swdval & (~SW_SRQ));

	errval = BTI1553_RTSWDWr(swdval, TAVAL, channum, hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while writing the",errval);
		printf("\n        status word to remote terminal #%d on channel #%d.",TAVAL,channum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Start the card to begin receiving messages.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Change RT status word bits when keyboard keys are pressed. Exit when ESC is pressed.
*
**/

	printf("\n\tOPTIONS:");
	printf("\n\tB   = toggle the busy bit of the status word");
	printf("\n\tS   = toggle the service request bit of the status word");
	printf("\n\tESC = Exit program");
	printf("\n\n");

	for (done=0;!done;)
	{
		printf("\r\tSWD: %04X\tBusy: %s \tSRQ: %s \t\t",swdval, (busy) ? "Set":"Clear",(srq) ? "Set":"Clear");

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
				case  66:	/* B */
				case  98:	/* b */
				{
					/*BUSY*/
					busy = (busy) ? 0 : 1;
					break;
				}
				case  83:	/* S */
				case 115:	/* s */
				{
					/*SERVICE REQUEST*/
					srq = (srq) ? 0 : 1;
					break;
				}
				default:
				{
					continue;
				}
			}

			swdval = BTI1553_RTSWDRd(TAVAL,channum,hCore);

			swdval = (busy) ? (swdval | SW_BUSY) : (swdval & (~SW_BUSY));
			swdval = (srq)  ? (swdval | SW_SRQ)  : (swdval & (~SW_SRQ));

			errval = BTI1553_RTSWDWr(swdval, TAVAL, channum, hCore);

			if (errval < 0)
			{
				printf("\nError:  An error was encountered (%i) while writing the",errval);
				printf("\n        status word to remote terminal #%d on channel #%d.",TAVAL,channum);
				printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
				printf("\n");
				done=1;
				break;
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
