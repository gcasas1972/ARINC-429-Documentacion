
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 4  Version 1.0  (10/29/2001)
*  Copyright (c) 1998-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4.C -- Example 4 from Section 4.4.
*                      "Example with explicit message timing."
*
**/

/**
*
*  This program opens the L43 card number 0, and
*  builds a transmit schedule using explicit message timing. 
*  The selftest wrap-around is enabled and filters are set for
*  receive the messages.  The minimum and maximum elapsed
*  time for each message is displayed.
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

	MSGSTRUCT xmt_airspeed, xmt_altitude, rcv_airspeed, rcv_altitude;
	MSGFIELDS airspeed_record, altitude_record;

	fprintf(stderr,"\nEXAMP4  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1998-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 4");
	fprintf(stderr,"\n\"Program for explicit message timing.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);                /*Open the L43 card*/

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
*  Configure rcvchan to receive at low speed with the 
*  Min/Max Elapse Time option also enabled.
*
*  Configure xmtchan to transmit at low speed.  
*  Note that the selftest wrap-around is also enabled. 
*  The external line drivers are disabled, and xmtchan is
*  connected internally to all the receive channels.
*
**/

	L43_CardReset(Card);                   /*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG_MAXMIN,rcvchan,Card);

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
*  for the receive channel.  Two filters are set for the 
*  two messages of interest.
*
**/

	rcv_airspeed.addr = L43_FilterSet(MSGCRT_DEFAULT,0206,SDIALL,rcvchan,Card);
	rcv_altitude.addr = L43_FilterSet(MSGCRT_DEFAULT,0212,SDIALL,rcvchan,Card);

/**
*
*  Create a message for each of the labels we are transmitting.
*
**/

	xmt_airspeed.addr = L43_MsgCreate(MSGCRT_DEFAULT,Card);
	xmt_altitude.addr = L43_MsgCreate(MSGCRT_DEFAULT,Card);

/**
*
*  Next, a schedule is built by creating explicit message timing.
*
**/

	L43_SchedMsg(xmt_altitude.addr,xmtchan,Card);
	L43_SchedMsg(xmt_airspeed.addr,xmtchan,Card);
	L43_SchedGap(495,xmtchan,Card);
	L43_SchedMsg(xmt_altitude.addr,xmtchan,Card);
	L43_SchedGap(531,xmtchan,Card);

/**
*
*  Those messages that are to be transmitted are initialized.
*
**/

	L43_MsgDataWr(0x0000008A,xmt_altitude.addr,Card);
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

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		L43_MsgBlockRd(&airspeed_record,rcv_airspeed.addr,Card);
		L43_MsgBlockRd(&altitude_record,rcv_altitude.addr,Card);

		printf("\r");

		printf("AirSpeed: min/max=%2ums/%2ums ",
		(airspeed_record.mintime / 1000),
		(airspeed_record.maxtime / 1000));

		printf("Altitude: min/max=%2ums/%2ums ",
		(altitude_record.mintime / 1000),
		(altitude_record.maxtime / 1000));

		printf("        ");
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
