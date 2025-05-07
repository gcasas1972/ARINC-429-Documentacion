
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 13  Version 1.0  (10/29/2001)
*  Copyright (c) 2000-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP13.C -- Example 13.
*                      "Program for ARINC 717 transmitter example"
*
**/

/**
*
*  This program opens the L43 card number 0, and
*  configures the first BiPhase 717 transmit channel.
*  The channel is loaded with incrementing data, and
*  the card is started.  The program displays the current
*  subframe and word location.
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
	INT wps = 256;                              /*Words Per Second*/
	USHORT chstatus[4];                         /*Channel Status Array*/
	INT j;

	fprintf(stderr,"\nEXAMP13  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright (c) 2000-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 13");
	fprintf(stderr,"\n\"Program for ARINC 717 transmitter example.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);					/*Open the L43 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L43 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Find the first BiPhase channel.
*
**/

	for (xmtchan=0;xmtchan<8;++xmtchan) if (L43_Is717BiPhaseChan(xmtchan,Card)) break;
	if (xmtchan == 8)
	{
		printf("\nError:  No ARINC 717 BiPhase channels present in L43 cardnum %d.",CARDNUM);
		printf("\n");
		exit(1);
	}

	fprintf(stderr,"\nUsing ARINC 717 BiPhase channel %d",xmtchan);
	fprintf(stderr,"\n");

/**
*
*  Configure BiPhase channel as a transmitter.
*
**/

	L43_CardReset(Card);                                  /*Reset the L43 card*/

	if      (wps == 64)		errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_64WPS,xmtchan,Card);
	else if (wps == 128)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_128WPS,xmtchan,Card);
	else if (wps == 256)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_256WPS,xmtchan,Card);
	else if (wps == 512)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_512WPS,xmtchan,Card);
	else if (wps == 1024)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_1024WPS,xmtchan,Card);
	else if (wps == 2048)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_2048WPS,xmtchan,Card);
	else if (wps == 4096)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_4096WPS,xmtchan,Card);
	else if (wps == 8192)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_8192WPS,xmtchan,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,xmtchan);
		printf("\n");
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Init subframe data.
*
**/

	for (j=2;j<=wps;++j)
	{
		L43_SubFrmWordWr((USHORT)j,1,j,xmtchan,Card);
		L43_SubFrmWordWr((USHORT)j,2,j,xmtchan,Card);
		L43_SubFrmWordWr((USHORT)j,3,j,xmtchan,Card);
		L43_SubFrmWordWr((USHORT)j,4,j,xmtchan,Card);
	}

/**
*
*  Start operation of the card.
*
**/

	L43_CardStart(Card);

/**
*
*  Display current location on screen.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		L43_Ch717Status(chstatus,xmtchan,Card);

		printf("\rChannel %d (@%d wps) - Subframe:%01d Word:%04d",
			xmtchan,
			wps,
			chstatus[2],
			chstatus[1]);
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
