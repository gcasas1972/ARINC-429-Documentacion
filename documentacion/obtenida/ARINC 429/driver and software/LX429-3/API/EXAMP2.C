
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 2  Version 1.0  (10/29/2001)
*  Copyright (c) 1998-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- Example 2 from Section 3.5.
*                      "Program for transmitter example."
*
**/

/**
*
*  This program opens the L43 card number 0, builds a
*  transmit schedule using transmit interval information, and
*  then transmits the messages with changing data.
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
	MSGSTRUCT comp_airspeed, tot_air_temp, altitude_rate;
	MSGADDR msgaddr[3];
	INT	min_intrvls[3];
	INT	max_intrvls[3];
	ULONG bnr_data[3];

	fprintf(stderr,"\nEXAMP2  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1998-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 2");
	fprintf(stderr,"\n\"Program for transmitter example.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);                   /*Open the L43 card*/

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

	L43_CardReset(Card);                                /*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG_DEFAULT,xmtchan,Card);  /*Configure channel*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,xmtchan);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Create a message for each of the labels we are transmitting.
*
**/

	comp_airspeed.addr = L43_MsgCreate(MSGCRT_DEFAULT,Card);
	tot_air_temp.addr  = L43_MsgCreate(MSGCRT_DEFAULT,Card);
	altitude_rate.addr = L43_MsgCreate(MSGCRT_DEFAULT,Card);

/**
*
*  Setup the arrays of message addresses, and intervals
*  needed to build the schedule.  Note that the nth element
*  in each array correspond to eachother.
*
**/

	msgaddr[0] = comp_airspeed.addr;
	min_intrvls[0] = 250; 
	max_intrvls[0] = 500; 

	msgaddr[1] = tot_air_temp.addr;
	min_intrvls[1] = 250; 
	max_intrvls[1] = 500; 

	msgaddr[2] = altitude_rate.addr;
	min_intrvls[2] = 100;
	max_intrvls[2] = 200;

/**
*
*  Next, build a schedule using the minimum and maximum
*  transmit intervals.
*
**/

	L43_SchedBuild(3,msgaddr,min_intrvls,max_intrvls,xmtchan,Card);

/**
*
*  Initialize the three Message Records.
*
**/

	comp_airspeed.data = L43_FldPutLabel(0L,0206);     /*Init label field*/
	tot_air_temp.data  = L43_FldPutLabel(0L,0211);
	altitude_rate.data = L43_FldPutLabel(0L,0212);

	comp_airspeed.data = L43_BNRPutMant(comp_airspeed.data,0L,14,0);     /*Init BNR data*/
	tot_air_temp.data  = L43_BNRPutMant(tot_air_temp.data,0L,11,0);
	altitude_rate.data = L43_BNRPutMant(altitude_rate.data,0L,16,0);

	L43_MsgDataWr(comp_airspeed.data,comp_airspeed.addr,Card);
	L43_MsgDataWr(tot_air_temp.data,tot_air_temp.addr,Card);
	L43_MsgDataWr(altitude_rate.data,altitude_rate.addr,Card);

/**
*
*  Start operation of the card.
*
**/

	L43_CardStart(Card);

/**
*
*  Change data until a key is pressed.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		comp_airspeed.data = L43_MsgDataRd(comp_airspeed.addr,Card);   /*Read messages back*/
		tot_air_temp.data  = L43_MsgDataRd(tot_air_temp.addr,Card);
		altitude_rate.data = L43_MsgDataRd(altitude_rate.addr,Card);

		bnr_data[0] = L43_BNRGetMant(comp_airspeed.data,14);   /*Extract BNR data*/
		bnr_data[1] = L43_BNRGetMant(tot_air_temp.data,11);
		bnr_data[2] = L43_BNRGetMant(altitude_rate.data,16);

		++bnr_data[0];   /*Change BNR data*/
		++bnr_data[1];
		++bnr_data[2];

		comp_airspeed.data = L43_BNRPutMant(comp_airspeed.data,bnr_data[0],14,0);   /*Put BNR data*/
		tot_air_temp.data  = L43_BNRPutMant(tot_air_temp.data,bnr_data[1],11,0);    /*back into*/
		altitude_rate.data = L43_BNRPutMant(altitude_rate.data,bnr_data[2],16,0);   /*messages*/

		L43_MsgDataWr(comp_airspeed.data,comp_airspeed.addr,Card);   /*Write new message values*/
		L43_MsgDataWr(tot_air_temp.data,tot_air_temp.addr,Card);
		L43_MsgDataWr(altitude_rate.data,altitude_rate.addr,Card);
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
