
/**
*
*  LP1553-3 and LC1553-3 DRIVER EXAMPLE 4  Version 1.0  (10/29/2001)
*  Copyright (c) 1997-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4.C -- Example 4 from Section 4.4.
*                      "Monitoring the bus"
*
**/

/**
*
*  This example configures the L13 as a "snapshot"
*  monitor.  It allows the card's internal buffer to fill
*  before it attempts to download any data.  It then
*  downloads the entire monitor buffer.  It prints the
*  time-tag, command words (if any), and status words (if
*  any).  for each monitor record.
*
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of L13 card*/

void main(void)
{
	HCARD  Card;
	ERRVAL errval;
	USHORT MsgBuffer[MONRD_MAX_COUNT];
	int    CursorFrame = 0;
	char   Cursor[4] = {'|', '/', '-', '\\'};

	fprintf(stderr,"\nEXAMP4  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1997-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Example 4");
	fprintf(stderr,"\n\"Monitoring the bus\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L13 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L13_CardOpen(CARDNUM);					/*Open the L13 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L13 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for monitor mode.
*
**/

	L13_CardReset(Card);

	errval = L13_MonConfig(MONCFG_DEFAULT, Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for monitor mode.",errval);
		L13_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin receiving messages.
*
**/

	L13_CardStart(Card);

/**
*
*  Wait until the monitor is full.
*
**/

	printf("Press any key to quit waiting...\n");

	while (!kbhit() && L13_MonIsRunning(Card))
	{
		printf("\rWaiting for monitor buffer to fill.  %c", Cursor[(++CursorFrame) % 4]);
	}

/**
*
*  Read the entire contents of the monitor and display the results.
*
**/

	while (L13_MonRd(MsgBuffer,Card))
	{
		printf("\n");

		printf(" Time:%lu",((ULONG)MsgBuffer[1]<<0)+((ULONG)MsgBuffer[2]<<16));
		printf(" Err:%04XH",MsgBuffer[3]);

		if (MsgBuffer[3] & 0x0800) printf(" Cwd1:%04X", MsgBuffer[5]);
		if (MsgBuffer[3] & 0x0400) printf(" Cwd2:%04X", MsgBuffer[6]);
		if (MsgBuffer[3] & 0x0200) printf(" Swd1:%04X", MsgBuffer[7]);
		if (MsgBuffer[3] & 0x0100) printf(" Swd2:%04X", MsgBuffer[8]);

		if (MsgBuffer[3] & 0x8000) printf(" No response!");
		if (MsgBuffer[3] & 0x4000) printf(" Error!");
	}

/**
*
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardStop(Card);
	L13_CardClose(Card);
}
