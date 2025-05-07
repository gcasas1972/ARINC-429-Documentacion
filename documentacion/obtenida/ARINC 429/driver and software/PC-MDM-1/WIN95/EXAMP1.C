
/**
*
*  PC-MDM-1 DRIVER EXAMPLE 1  Version 1.0  (09/20/1997)
*  Copyright (c) 1997
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Example 1.
*                      "BC example transmitting from the BC to the RT."
*
**/

/**
*
*  This example configures the PC-MDM-1 to transmit to the
*  RT.  It assumes the card is in BC mode.
*
**/

#include "mdmw32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	MEMBASE 0xCC00				/*Memory address of PC-MDM-1 card*/
#define IOBASE  0x2C0				/*I/O address of PC-MDM-1 card*/
#define	IRQCHAN 2					/*Interrupt channel of PC-MDM-1 card*/
#define	DMACHAN 1					/*DMA channel of PC-MDM-1 card*/

void main(void)
{
	INT j;								/*Counter variable*/
	HCARD handleval;					/*Handle of PC-MDM-1 card*/
	ERRVAL errval;						/*Error return value*/
	USHORT xmtdwd[32];					/*Data word buffer*/
	INT error;							/*Error results*/

	fprintf(stderr,"\nEXAMP1  Version 1.0  (09/20/1997)");
	fprintf(stderr,"\nCopyright 1997  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC-MDM-1 Example 1");
	fprintf(stderr,"\n\"BC example transmitting from the BC to the RT\"");
	fprintf(stderr,"\n");

/**
*
*  Open the PC-MDM-1 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	handleval = MDM_CardOpen(MEMBASE,IOBASE,IRQCHAN,DMACHAN);	/*Open the PC-MDM-1 card*/

	if (handleval < 0)
	{
		printf("\nError:  Either a PC-MDM-1 is not present at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        or an error occurred (%i) opening the card.",handleval);
		printf("\n");
		exit(1);
	}

/**
*
*  Verify that the card is in BC mode.
*
**/

	if (!MDM_IsBC(handleval))
	{
		fprintf(stderr,"\nError:  The PC-MDM-1 card is not in BC mode.");
		MDM_CardClose(handleval);
		exit(1);
	}

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");

	while(!kbhit())
	{

/**
*
*  Initialize the data to transmit.
*
**/

		for (j=0;j<32;++j) xmtdwd[j]=rand();

		MDM_XmtWr(xmtdwd,32,handleval);

/**
*
*  Transmit 32 data words.
*
**/

		error = MDM_Go(TRANSMIT,32,handleval);

/**
*
*  Test for any error results.
*
**/

		if (error != ERROR_HIT)					/*If more than hit bit set*/
		{
			fprintf(stderr,"\nError:  An error was encountered (%04X) while transmitting the data.",error);
		}
	}

/**
*
*  The PC-MDM-1 card MUST be closed before exiting the program.
*
**/

	MDM_CardClose(handleval);				/*Close the card*/
}
