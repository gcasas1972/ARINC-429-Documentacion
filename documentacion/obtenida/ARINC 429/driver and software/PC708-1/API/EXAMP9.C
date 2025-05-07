
/**
*
*  PC708-1 DRIVER EXAMPLE 9  Version 1.0  (07/14/2000)
*  Copyright (c) 2000
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP9.C -- Example 9.
*                      "Receiver Sequential Block Read example"
*
**/

/**
*
*  This example configures the PC708-1 to receive messages.  
*  Data is read out of the sequential monitor using the
*  RcvMonBlkRd() function.  The program displays status
*  information about how many blocks it read from the card.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

#include "p71w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	MEMBASE 0xCC00				/*Memory address of PC708-1 card*/
#define IOBASE  0x2C0				/*I/O address of PC708-1 card*/
#define	IRQCHAN 2					/*Interrupt channel of PC708-1 card*/
#define	DMACHAN 1					/*DMA channel of PC708-1 card*/

USHORT MonData[128*109];            /*Data buffer to hold monitor records*/
HCARD Card;							/*Handle of card to access*/

void main(void)
{
	ERRVAL errval;
	ULONG  retcount;
	ULONG  blkcount;
	ULONG  totalcount=0;
	BOOL   monflag;
	
	fprintf(stderr,"\nEXAMP9  Version 1.0  (07/14/2000)");
	fprintf(stderr,"\nCopyright 2000  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC708-1 Example 9");
	fprintf(stderr,"\n\"Receiver Sequential Block Read example\"");
	fprintf(stderr,"\n");

/**
*
*  Open the PC708-1 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = PC708_CardOpen(MEMBASE,IOBASE,IRQCHAN,DMACHAN);	/*Open the PC708-1 card*/

	if (Card < 0)
	{
		printf("\nError:  Either a PC708-1 is not present at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        or an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

	PC708_CardReset(Card);

/**
*
*  Configure the receiver of the PC708-1 card.
*
**/

	errval = PC708_RcvConfig(Card);			/*Configure the PC708-1 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the receiver.",errval);
		PC708_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin receiving.
*
**/

	PC708_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.\n");
	printf("\n");
	
	while (!_kbhit())
	{

/**
*
*  Read records out of the sequential monitor, 
*  then display the status information.  If the
*  input rate exceeds the rate at which we are
*  reading data out of the monitor, then eventually
*  the monitor will become full.  The program checks
*  the monitor status for this overrun condition.
*
**/
		
		monflag = PC708_MonIsRunning(Card);

		retcount = PC708_RcvMonBlkRd(MonData,sizeof(MonData)/sizeof(MonData[0]),&blkcount,Card);

		if (retcount)
		{
			totalcount += blkcount;

			printf("\rBlocks read: %-3d   Total count: %-8d   Monitor Status: %s",
				blkcount,
				totalcount,
				(monflag) ? "OK  " : "FULL");
		}
	}
	printf("\n");

/**
*
*  Stop the card to disable receiver.
*
**/

	PC708_CardStop(Card);						/*Stop the card*/

/**
*
*  The PC708-1 card MUST be closed before exiting the program.
*
**/

	PC708_CardClose(Card);					/*Close the card*/

}
