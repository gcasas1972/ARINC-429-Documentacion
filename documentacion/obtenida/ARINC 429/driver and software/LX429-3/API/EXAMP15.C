
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 15  Version 1.0  (10/29/2001)
*  Copyright (c) 2000-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP15.C -- Example 15.
*                      "Program for ARINC 717 Sequential Record example"
*
**/

/**
*
*  This program opens the L43 card number 0, and
*  configures the first BiPhase 717 channel as a receiver.
*  The second BiPhase 717 channel is configured as a transmitter.
*  The transmit channel is loaded with incrementing data, and
*  various words are configured for entry into the Sequential Record.
*  The program will read out of the Sequential Record and display the data
*  to the screen.
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
	INT rcvchan,xmtchan;                        /*Channel number*/
	INT wps = 256;                              /*Words Per Second*/
	SEQRECORD seqbuf;                           /*Sequential Record structure*/
	INT j;

	fprintf(stderr,"\nEXAMP15  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright (c) 2000-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 15");
	fprintf(stderr,"\n\"Program for ARINC 717 Sequential Record example\"");
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

	for (rcvchan=0;rcvchan<8;++rcvchan) if (L43_Is717BiPhaseChan(rcvchan,Card)) break;
	if (rcvchan == 8)
	{
		printf("\nError:  No ARINC 717 BiPhase channels present in L43 cardnum %d.",CARDNUM);
		printf("\n");
		exit(1);
	}

	fprintf(stderr,"\nUsing ARINC 717 BiPhase channel %d",rcvchan);
	fprintf(stderr,"\n");

/**
*
*  Find the second BiPhase channel.
*
**/

	for (xmtchan=rcvchan+1;xmtchan<8;++xmtchan) if (L43_Is717BiPhaseChan(xmtchan,Card)) break;
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
*  Configure receiver channel for auto speed detection.
*  Use the internal wrap around.
*
**/

	L43_CardReset(Card);                                  /*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG717_AUTOSPEED|CHCFG717_SELFTEST,rcvchan,Card);  /*Configure channel*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,rcvchan);
		printf("\n");
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Configure BiPhase channel as a transmitter.
*  Use the internal wrap around.
*
**/

	if      (wps == 64)		errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_SELFTEST|CHCFG717_64WPS,xmtchan,Card);
	else if (wps == 128)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_SELFTEST|CHCFG717_128WPS,xmtchan,Card);
	else if (wps == 256)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_SELFTEST|CHCFG717_256WPS,xmtchan,Card);
	else if (wps == 512)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_SELFTEST|CHCFG717_512WPS,xmtchan,Card);
	else if (wps == 1024)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_SELFTEST|CHCFG717_1024WPS,xmtchan,Card);
	else if (wps == 2048)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_SELFTEST|CHCFG717_2048WPS,xmtchan,Card);
	else if (wps == 4096)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_SELFTEST|CHCFG717_4096WPS,xmtchan,Card);
	else if (wps == 8192)	errval = L43_ChConfig(CHCFG717_BIPHASEXMT|CHCFG717_SELFTEST|CHCFG717_8192WPS,xmtchan,Card);

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
*  Configure the sequential record.
*
**/

	errval = L43_SeqConfig(SEQCFG_DEFAULT,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the sequential record.",errval);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Configure word options.
*
**/

	L43_SubFrmWordConfig(WRDCFG_SEQ,1,1,rcvchan,Card);
	L43_SubFrmWordConfig(WRDCFG_SEQ,2,1,rcvchan,Card);
	L43_SubFrmWordConfig(WRDCFG_SEQ,3,1,rcvchan,Card);
	L43_SubFrmWordConfig(WRDCFG_SEQ,4,1,rcvchan,Card);

	L43_SubFrmWordConfig(WRDCFG_SEQ,1,1,xmtchan,Card);
	L43_SubFrmWordConfig(WRDCFG_SEQ,2,1,xmtchan,Card);
	L43_SubFrmWordConfig(WRDCFG_SEQ,3,1,xmtchan,Card);
	L43_SubFrmWordConfig(WRDCFG_SEQ,4,1,xmtchan,Card);

/**
*
*  Start operation of the card.
*
**/

	L43_CardStart(Card);

/**
*
*  Read the Sequential Record and dsiplay to screen.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		if(L43_SeqRd(&seqbuf,Card))
		{
			printf("\nCh:%02u SF:%01d Word:%04d Data:%08lX Time Stamp:%04X%04X",
			((seqbuf.activity & 0x0F00) >> 8),
			seqbuf.subframe,
			seqbuf.wordnum,
			seqbuf.data,
			seqbuf.timestamph,
			seqbuf.timestampl);
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
