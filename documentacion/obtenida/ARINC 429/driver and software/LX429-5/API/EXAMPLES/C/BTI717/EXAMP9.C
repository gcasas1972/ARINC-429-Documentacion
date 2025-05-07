
/**
*
*  BTI717 DRIVER EXAMPLE 9  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP9.C -- Transmitter with SuperFrame data example
*
**/

/**
*
*  NOTE: This example was previously released as EXAMP2.C
*
*  This program opens Card Number 0, and configures the
*  first BiPhase channel as a receiver.  The second
*  BiPhase channel is configured as a transmitter.  Both
*  channels operate on the self-test bus to electrically connect
*  them. The transmit channel is loaded with incrementing data,
*  and SubFrame 2, Word 10, is defined as SuperFrame data.
*  The SuperFrame data is loaded with incrementing data as well.
*  For this example, the receive channel does not define any
*  words as SuperFrame data.  The program will display the
*  what is received in SubFrame 2, Word 10.
*
**/

#include "BTICard.H"
#include "BTI717.H"
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
	INT rcvchan;
	INT xmtchan;
	INT wps = 256;
	SUPERFRMADDR superfrmaddr;
	USHORT sfblock[8200];
	USHORT data;
	INT j,jj;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP9  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI717 Example 9                                                  *");
	printf("\n    *  \"Program for Transmitter with SuperFrame data example.\"           *");
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

	printf("\nUsing ARINC 717 card #%d",CARDNUM);

/**
*
*  Find the first ARINC 717 core with both BiPhase receive and transmit channels.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		// Search for receive
		for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)
		{
			if (BTI717_ChIsType(CHCFG717_BIPHASERCV, rcvchan, hCore))	break;
		}

		// Search for transmit
		for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)
		{
			if ( xmtchan == rcvchan ) continue;

			if (BTI717_ChIsType(CHCFG717_BIPHASEXMT, xmtchan, hCore))	break;
		}

		if ( (rcvchan != MAX_CHANNELS) && (xmtchan != MAX_CHANNELS) ) break;
	}

	if (errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS || xmtchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 717 BiPhase receive and transmit channel pair present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 717 core #%d",corenum);
	printf("\nUsing BiPhase receive channel #%d",rcvchan);
	printf("\nUsing BiPhase transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure receiver channel for auto speed detection.
*  Use the internal wrap around.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI717_ChConfig(CHCFG717_BIPHASERCV | CHCFG717_AUTOSPEED | CHCFG717_SELFTEST,rcvchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring channel %d.",errval,rcvchan);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure transmitter channel at specified words per second.
*  Use the internal wrap around.
*
**/

	if      (wps == 64)   errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_64WPS,  xmtchan,hCore);
	else if (wps == 128)  errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_128WPS, xmtchan,hCore);
	else if (wps == 256)  errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_256WPS, xmtchan,hCore);
	else if (wps == 512)  errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_512WPS, xmtchan,hCore);
	else if (wps == 1024) errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_1024WPS,xmtchan,hCore);
	else if (wps == 2048) errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_2048WPS,xmtchan,hCore);
	else if (wps == 4096) errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_4096WPS,xmtchan,hCore);
	else if (wps == 8192) errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT | CHCFG717_SELFTEST | CHCFG717_8192WPS,xmtchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring channel %d.",errval,xmtchan);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Init subframe data.
*
**/

	for (j=1;j<=4;j++)
	{
		BTI717_SubFrmBlkRd(sfblock,j,xmtchan,hCore);
		for (jj=2;jj<=wps;jj++) sfblock[jj+7] = ((0x0100*j)+jj) & 0x0FFF;
		BTI717_SubFrmBlkWr(sfblock,j,xmtchan,hCore);
	}

/**
*
*  Create some SuperFrame structures.
*
**/

	BTI717_SuperFrmConfig(10,16,xmtchan,hCore);

/**
*
*  Define SF2, W10 to be SuperFrame Data.
*  Init superframe data.
*
**/

	superfrmaddr = BTI717_SuperFrmDefine(2,10,xmtchan,hCore);
	for (j=1;j<=16;j++) BTI717_SuperFrmWordWr((USHORT)(0x0500+j),j,superfrmaddr,xmtchan,hCore);

/**
*
*  Set superframe counter position.
*
**/

	BTI717_SuperFrmCounterPos(1,wps,xmtchan,hCore);

/**
*
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Display SF2, W10 on screen.
*
**/

	printf("\nPress any key to exit....\n\n");
	printf("\nSynchronizing to bit stream....");

	while (!BTI717_SyncTest(rcvchan,hCore) && !kbhit());

	if (BTI717_SyncTest(rcvchan,hCore))
	{
		printf("In Sync!\n\n");
		while(!kbhit())
		{
			BTI717_SubFrmWordRd(&data,2,10,rcvchan,hCore);

			printf("\rChannel %d (@%d wps) - SuperFrame Data: %04X (Hex)",
				xmtchan,
				wps,
				data);
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
