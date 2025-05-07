
/**
*
*  PC1553-3 DRIVER EXAMPLE 4  Version 1.0  (02/20/1998)
*  Copyright (c) 1998
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
*  This example configures the PC1553-3 as a "snapshot"
*  monitor.  It allows the card's internal buffer to fill
*  before it attempts to download any data.  It then
*  downloads the entire monitor buffer.  It prints the
*  time-tag, command words (if any), and status words (if
*  any).  for each monitor record.
*
**/

#include "p13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	MEMBASE 0xCC00				/*Memory address of PC1553-3 card*/
#define IOBASE  0x2C0				/*I/O address of PC1553-3 card*/
#define	IRQCHAN 2					/*Interrupt channel of PC1553-3 card*/
#define	DMACHAN 1					/*DMA channel of PC1553-3 card*/

void main(void)
{
	HCARD  Card;
	ERRVAL errval;
	USHORT MsgBuffer[MONRD_MAX_COUNT];
	int    CursorFrame = 0;
	char   Cursor[4] = {'|', '/', '-', '\\'};

	fprintf(stderr,"\nEXAMP4  Version 1.0  (02/20/1998)");
	fprintf(stderr,"\nCopyright 1998  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC1553-3 Example 4");
	fprintf(stderr,"\n\"Monitoring the bus\"");
	fprintf(stderr,"\n");

/**
*
*  Open the PC1553-3 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = P13_CardOpen(MEMBASE,IOBASE,IRQCHAN,DMACHAN);	/*Open the PC1553-3 card*/

	if (Card < 0)
	{
		printf("\nError:  Either a PC1553-3 is not present at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for monitor mode.
*
**/

	P13_CardReset(Card);

	errval = P13_MonConfig(MONCFG_DEFAULT, Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for monitor mode.",errval);
		P13_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin receiving messages.
*
**/

	P13_CardStart(Card);

/**
*
*  Wait until the monitor is full.
*
**/

	printf("Press any key to quit waiting...\n");

	while (!kbhit() && P13_MonIsRunning(Card))
	{
		printf("\rWaiting for monitor buffer to fill.  %c", Cursor[(++CursorFrame) % 4]);
	}

/**
*
*  Read the entire contents of the monitor and display the results.
*
**/

	while (P13_MonRd(MsgBuffer,Card))
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
*  The PC1553-3 card MUST be closed before exiting the program.
*
**/

	P13_CardStop(Card);
	P13_CardClose(Card);
}
