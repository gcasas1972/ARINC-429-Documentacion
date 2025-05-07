
/**
*
*  BTI429 DRIVER EXAMPLE 6  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP6.C -- Asynchronous List Buffer example
*
**/

/**
*
*  This program opens the Card Number 0, finds the first
*  compatible core, and configures an asynchronous transmit
*  list buffer. The program transmits one label synchronously
*  in a schedule, and transmits another label each time the
*  spacebar is hit by the user.
*
**/

#include "BTICard.h"
#include "BTI429.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

void main(void)
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT corenum;
	INT xmtchan;
	INT ch;
	BOOL done;
	BOOL xmtstat;
	INT xmtcount = 0;
	MSGSTRUCT429 xmt_airspeed;
	LISTADDR asynclistaddr;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP6  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI429 Example 6                                                  *");
	printf("\n    *  \"Program for asynchronous list buffer.\"                           *");
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
		printf("\n        an error occurred (%i) opening the card.",hCard);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		exit(1);
	}

	printf("\nUsing ARINC 429 card #%d",CARDNUM);

/**
*
*  Find the first ARINC 429 core with a transmit channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (BTI429_ChIsXmt(xmtchan,hCore))	break;

		if (xmtchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 429 transmit channels present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 429 core #%d",corenum);
	printf("\nUsing transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure xmtchan to transmit at low speed.
*
**/

	BTICard_CardReset(hCore);							/*Reset the card*/

	errval = BTI429_ChConfig(CHCFG429_DEFAULT,xmtchan,hCore);

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
*  Create a message for each of the synchronous labels we are transmitting.
*
**/

	xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT,hCore);

/**
*
*  Create the asynchronous list buffer.
*
**/

	asynclistaddr = BTI429_ListAsyncCreate(LISTCRT429_FIFO,16,xmtchan,hCore);

/**
*
*  Next, a schedule is built by creating explicit message timing.
*  While creating a schedule we can still use the SchedGap() function
*  to create our gap times.  This function will determine that an
*  asynchronous list buffer has been created for the channel, and will
*  internally call the SchedGapList() function with appropriate parameters.
*  Alternatively, we could use the SchedGapList() function directly
*  and specify the address value ourselves. This method is useful if
*  more than one asynchronous list buffer is desired per channel.
*
**/

	BTI429_SchedMsg(xmt_airspeed.addr,xmtchan,hCore);
	BTI429_SchedGap(1218,xmtchan,hCore);						//This line, and
//	BTI429_SchedGapList(1218,asynclistaddr,xmtchan,hCore);		//this line, do the same thing.

/**
*
*  The asynchronous message needs to be initialized.
*
**/

	BTI429_MsgDataWr(0x00000086,xmt_airspeed.addr,hCore);

/**
*
*  Start operation of the card.
*
**/

	errval = BTICard_CardStart(hCore);

/**
*
*  Display data on the screen.
*
**/

	printf("\nPress spacebar to transmit the asynchronous message, press ESC to exit....\n\n");
	printf("\nAsynchronous transmission count: %4u",xmtcount);

	for (done=0;!done;)
	{
		if (kbhit())
		{
			ch = getch();

			if (ch==' ')
			{
				xmtstat = BTI429_ListDataWr(0x0000008A,asynclistaddr,hCore);
				if (xmtstat) xmtcount++;
				printf("\rAsynchronous transmission count: %4u",xmtcount);
			}

			if (ch==27)
			{
				done=1;
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
