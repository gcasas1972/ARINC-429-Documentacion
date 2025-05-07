
/**
*
*  PC1553-3 DRIVER EXAMPLE 7  Version 1.0  (02/20/1998)
*  Copyright (c) 1998
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP7.C -- Example 7 from Section 6.3.
*                      "Errors in BC Transmissions - Scheduled Messages"
*
**/

/**
*
*  This example requires a PC1553-3C or higher.  It
*  configures the PC1553-3 as a BC and creates a schedule
*  containing a receive command each for terminal address 1
*  and terminal address 3.  Both receive commands send 2 data
*  words to the remote terminal.  The example then alternates
*  a bit count error between the first data word of both
*  commands.
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

#define	FRAMETIME	10000			/*Frame time in microseconds*/

#ifndef	TRUE
#define	TRUE 1
#endif

#ifndef	FALSE
#define	FALSE 0
#endif

void main(void)
{
	HCARD		Card;
	ERRVAL		errval;
	MSGADDR		BCMsgs[2];
	int			ErrorCount = 0;
	USHORT		InitialData1;
	USHORT		InitialData2;

	fprintf(stderr,"\nEXAMP7  Version 1.0  (02/20/1998)");
	fprintf(stderr,"\nCopyright 1998  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC1553-3 Example 7");
	fprintf(stderr,"\n\"Errors in BC Transmissions - Scheduled Messages\"");
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
*  Check that card supports error generation.
*
**/

	if (!P13_CardGetInfo(INFOTYPE_ERRORGEN,Card))
	{
		printf("\nError:  The PC1553-3 at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        does not support error generation.");
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for bus controller mode.
*
**/

	P13_CardReset(Card);							/*Reset the PC1553-3 card*/

	errval = P13_BCConfig(BCCFG_DEFAULT,Card);		/*Configure the PC1553-3 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for bus controller mode.",errval);
		P13_CardClose(Card);
		exit(1);
	}

/**
*
*  Create the message records.
*
**/

	BCMsgs[0] = P13_BCCreateMsg(MSGCRT_DEFAULT, 0x0842, 0, &InitialData1, Card);
	BCMsgs[1] = P13_BCCreateMsg(MSGCRT_DEFAULT, 0x1042, 0, &InitialData2, Card);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	P13_BCSchedFrame(FRAMETIME, Card);
	P13_BCSchedMsg(BCMsgs[0], Card);
	P13_BCSchedMsg(BCMsgs[1], Card);

/**
*
*  Define the type of error generation.  One of the bus
*  controller messages is tagged to generate errors once.
*
**/

	P13_ErrorDefine(ERRDEF_CNTBIT, 3, 2, 0, 0, Card);
	P13_ErrorTagBC(TRUE, BCMsgs[0], Card);
	P13_ErrorCtrl(ERRCTRL_ONCE | ERRCTRL_TAGMSG, Card);

/**
*
*  Start the card to begin transmissions.
*
**/

	P13_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("Press any key to quit.\n");

	while (!kbhit())
	{

/**
*
*  When the error is generated once, tag another message for
*  error generation and enable another single error.
*
**/

		if (P13_ErrorSent(Card) /*AND ANOTHER ERROR DESIRED*/)
		{
			if (++ErrorCount & 1)
			{
				P13_ErrorTagBC(FALSE, BCMsgs[0], Card);
				P13_ErrorTagBC(TRUE,  BCMsgs[1], Card);
			}
			else
			{
				P13_ErrorTagBC(TRUE,  BCMsgs[0], Card);
				P13_ErrorTagBC(FALSE, BCMsgs[1], Card);
			}

			P13_ErrorCtrl(ERRCTRL_ONCE | ERRCTRL_TAGMSG, Card);
		}
	}

/**
*
*  The PC1553-3 card MUST be closed before exiting the program.
*
**/

	P13_CardStop(Card);
	P13_CardClose(Card);
}
