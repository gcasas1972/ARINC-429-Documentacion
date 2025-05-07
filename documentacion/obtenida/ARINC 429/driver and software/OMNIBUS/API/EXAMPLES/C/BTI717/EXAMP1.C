
/**
*
*  BTI717 DRIVER EXAMPLE 1  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Receiver example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first BiPhase channel as a receiver.  After the
*  channel gets in sync, the program displays the first
*  word of each subframe (sync words).
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
	USHORT syncword1,syncword2,syncword3,syncword4;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP1  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI717 Example 1                                                  *");
	printf("\n    *  \"Program for receiver example.\"                                   *");
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
*  Find the first ARINC 717 core with a BiPhase receive channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)
		{
			if (BTI717_ChIsType(CHCFG717_BIPHASERCV, rcvchan, hCore))	break;
		}

		if (rcvchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 717 BiPhase receive channels present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 717 core #%d",corenum);
	printf("\nUsing BiPhase receive channel #%d",rcvchan);
	printf("\n");

/**
*
*  Configure channel for auto speed detection.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI717_ChConfig(CHCFG717_BIPHASERCV | CHCFG717_AUTOSPEED,rcvchan,hCore);

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
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Display data on the screen.
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
			BTI717_SubFrmWordRd(&syncword1,1,1,rcvchan,hCore);
			BTI717_SubFrmWordRd(&syncword2,2,1,rcvchan,hCore);
			BTI717_SubFrmWordRd(&syncword3,3,1,rcvchan,hCore);
			BTI717_SubFrmWordRd(&syncword4,4,1,rcvchan,hCore);

			printf("\r");
			printf("Sync1=%04o ",syncword1);
			printf("Sync2=%04o ",syncword2);
			printf("Sync3=%04o ",syncword3);
			printf("Sync4=%04o ",syncword4);
			printf("(Octal)");
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
