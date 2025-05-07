
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 6  Version 1.0  (10/29/2001)
*  Copyright (c) 1998-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP6.C -- Asynchronous List buffer example
*
**/

/**
*
*  This program opens the L43 card number 0, and
*  configures an asynchronous transmit list buffer.  The 
*  program transmits one label synchronoulsy in a schedule,
*  and transmits another label each time the spacebar is hit
*  by the user.
*  
**/

#include "l43w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0                               /*Card number of L43 card*/

void main(void)
{
	HCARD Card;                                 /*Handle of L43 card*/
	ERRVAL errval;                              /*Error return value*/
	INT xmtchan;                                /*Channel number*/
	INT ch;                                     /*Key press*/
	BOOL done;                                  /*Done flag*/
	BOOL xmtstat;
	INT xmtcount = 0;

	MSGSTRUCT xmt_airspeed;
	LISTADDR asynclistaddr;

	fprintf(stderr,"\nEXAMP6  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1998-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 6");
	fprintf(stderr,"\n\"Program for asynchronous list buffer.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);              /*Open the L43 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L43 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Find the first transmit channel.
*
**/

	for (xmtchan=0;xmtchan<8;++xmtchan) if (L43_IsXmtChan(xmtchan,Card)) break;
	if (xmtchan == 8)
	{
		printf("\nError:  No transmit channels present in L43 cardnum %d.",CARDNUM);
		printf("\n");
		exit(1);
	}

	fprintf(stderr,"\nUsing transmit channel %d",xmtchan);
	fprintf(stderr,"\n");

/**
*
*  Configure xmtchan to transmit at low speed.
*
**/

	L43_CardReset(Card);							/*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG_DEFAULT,xmtchan,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,xmtchan);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Create a message for each the synchronous label we are transmitting.
*
**/

	xmt_airspeed.addr = L43_MsgCreate(MSGCRT_DEFAULT,Card);

/**
*
*  Create the asynchronous list buffer.
*
**/

	asynclistaddr = L43_ListAsyncCreate(LISTCRT_FIFO,16,xmtchan,Card);

/**
*
*  Next, a schedule is built by creating explicit message timing.
*  While creating a schedule we can still use the SchedGap() funciton
*  to create our gap times.  This function will determine that an
*  asynchronous list buffer has been created for the channel, and will
*  internally call the SchedGapList() function with appropriate parameters.
*  Alternatively, we could use the SchedGapList() function directly 
*  and specify the address value ourselves. This method is usefull if 
*  more than one asynchronoous list buffer is desired per channel.
*
**/

	L43_SchedMsg(xmt_airspeed.addr,xmtchan,Card);
	L43_SchedGap(1093,xmtchan,Card);					//This line, and
//	L43_SchedGapList(1093,asynclistaddr,xmtchan,Card);	//this line, do the same thing. 

/**
*
*  The synchronous message needs to be initialized.
*
**/

	L43_MsgDataWr(0x00000086,xmt_airspeed.addr,Card);

/**
*
*  Start operation of the card.
*
**/

	L43_CardStart(Card);

/**
*
*  Display data on the screen.
*
**/

	fprintf(stderr,"\nPress spacebar to transmit the asynchronous message, press ESC to exit....\n\n");

	for (done=0;!done;)
	{
		printf("\rAsynchronous transmission count: %4u",xmtcount);
		
		if (kbhit())
		{
			ch = getch();
			
			if (ch==' ')
			{
				xmtstat = L43_ListDataWr(0x0000008A,asynclistaddr,Card);
				if (xmtstat) xmtcount++;
			}

			if (ch==27)
			{
				done=1;
			}
		}
	}

/**
*
*  Stop the L43 card.
*
**/

	L43_CardStop(Card);

/**
*
*  The L43 card MUST be closed before exiting the program.
*
**/

	L43_CardClose(Card);

}
