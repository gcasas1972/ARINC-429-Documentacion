
/**
*
*  PC1553-3 DRIVER EXAMPLE 3  Version 1.0  (02/20/1998)
*  Copyright (c) 1998
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- Example 3 from Section 4.3.
*                      "Simulating an RT"
*
**/

/**
*
*  This example configures the PC1553-3 as an RT to receive
*  the BC-RT data transmitted by the bus controller in
*  Example 2.
*
*  It continuously receives and displays the data words.
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
	HCARD   Card;
	ERRVAL  errval;
	MSGADDR RTMsg;
	USHORT  Data[32];

	fprintf(stderr,"\nEXAMP3  Version 1.0  (02/20/1998)");
	fprintf(stderr,"\nCopyright 1998  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC1553-3 Example 3");
	fprintf(stderr,"\n\"Simulating an RT\"");
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
*  Configure the card for remote terminal mode.
*
**/

	P13_CardReset(Card);

	errval = P13_RTConfig(RTCFG_DEFAULT, 1, Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for remote terminal mode.",errval);
		P13_CardClose(Card);
		exit(1);
	}

/**
*
*  Get the message address for a receive subaddress.
*
**/

	RTMsg = P13_RTGetMsg(SUBADDRESS, 1, RCV, 2, Card);

/**
*
*  Start the card to begin responding to transmissions.
*
**/

	P13_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to quit.");
	printf("\n");

	while (!kbhit())
	{
		P13_MsgDataRd(Data, 3, RTMsg, Card);	/*Read data received from the BC*/

		printf("\rReceived data {%04XH, %04XH, %04XH}",Data[0],Data[1],Data[2]);
	}

/**
*
*  The PC1553-3 card MUST be closed before exiting the program.
*
**/

	P13_CardStop(Card);						/*Stop the card*/
	P13_CardClose(Card);					/*Close the card*/
}
