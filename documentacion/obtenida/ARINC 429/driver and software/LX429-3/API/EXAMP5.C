
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 5  Version 1.0  (10/29/2001)
*  Copyright (c) 1998-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5.C -- Transmit and Receive List buffer example
*
**/

/**
*
*  This program opens the L43 card number 0, and
*  configures transmit and receive list buffers.  The 
*  program transmits one message filled with ramping
*  data in the associated list buffer.  The receive list
*  buffer is read and displays the data to the screen.
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
	INT rcvchan, xmtchan;                       /*Channel numbers*/
	ULONG j;

	MSGSTRUCT xmt_airspeed, rcv_airspeed;
	LISTADDR xmtlistaddr, rcvlistaddr;

	fprintf(stderr,"\nEXAMP5  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1998-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 5");
	fprintf(stderr,"\n\"Program for transmit and receive list buffers.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);          /*Open the L43 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L43 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Find the first receive channel.
*
**/

	for (rcvchan=0;rcvchan<8;++rcvchan) if (L43_IsRcvChan(rcvchan,Card)) break;
	if (rcvchan == 8)
	{
		printf("\nError:  No receive channels present in L43 cardnum %d.",CARDNUM);
		printf("\n");
		exit(1);
	}

	fprintf(stderr,"\nUsing receive channel %d",rcvchan);
	fprintf(stderr,"\n");

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
*  Configure rcvchan for auto speed detection.
*  Configure xmtchan to transmit at low speed with
*  the selftest wrap-around enabled.
*
**/

	L43_CardReset(Card);            /*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG_AUTOSPEED,rcvchan,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,rcvchan);
		L43_CardClose(Card);
		exit(1);
	}

	errval = L43_ChConfig(CHCFG_SELFTEST,xmtchan,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,xmtchan);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Before any messages can be received, filters must be set
*  for the receive channel.
*
**/

	rcv_airspeed.addr = L43_FilterSet(MSGCRT_DEFAULT,0206,SDIALL,rcvchan,Card);

/**
*
*  Create a message for each of the labels we are transmitting.
*
**/

	xmt_airspeed.addr = L43_MsgCreate(MSGCRT_DEFAULT,Card);

/**
*
*  Next, a schedule is built by creating explicit message timing.
*
**/

	L43_SchedMsg(xmt_airspeed.addr,xmtchan,Card);
	L43_SchedGap(1093,xmtchan,Card);

/**
*
*  Create the transmit and receive list buffers.
*
*  The transmit list buffer will be a circular buffer,
*  which means it should be pre-loaded with data, and
*  it will continuously transmit that data.
*
*  The receive list buffer will be a FIFO, which we will
*  read out of and display to the screen.
*
**/

	xmtlistaddr = L43_ListXmtCreate(LISTCRT_CIRCULAR,256,xmt_airspeed.addr,Card);
	rcvlistaddr = L43_ListRcvCreate(LISTCRT_FIFO,16,rcv_airspeed.addr,Card);

/**
*
*  Initialize the transmit list buffer.
*
**/

	for (j=0x00000;j<0x1000000;j+=0x10000)
	{
		L43_ListDataWr((0x00000086 | j),xmtlistaddr,Card);
	}

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

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		rcv_airspeed.data = L43_ListDataRd(rcvlistaddr,Card);

		if (rcv_airspeed.data) printf("\rAirSpeed=%08lX ",rcv_airspeed.data);
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
