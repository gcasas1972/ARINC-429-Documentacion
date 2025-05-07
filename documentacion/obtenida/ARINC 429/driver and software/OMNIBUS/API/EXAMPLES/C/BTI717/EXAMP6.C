
/**
*
*  BTI717 DRIVER EXAMPLE 6  (06/09/2011)
*  Copyright (c) 2003-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP6.C -- Multiple Core Example
*
**/

/**
*
*  This program opens Card Number 0 and configures all
*  ARINC 717 cores to receive on all BiPhase channels.
*  Program reports when each BiPhase channel is in sync.
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

#ifndef	TRUE
#define	TRUE 1
#endif

#ifndef	FALSE
#define	FALSE 0
#endif

void main(void)
{
	HCARD	hCard;						    /*Handle to card*/
	HCORE	hCores[MAX_CORES] = {0};	    /*Handle to cores*/
	BOOL	b717Core[MAX_CORES] = {FALSE};  /*Flag indicating 717 core*/
	INT corecount, corenum, chan;
	ERRVAL errval;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP6  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI717 Example 6                                                  *");
	printf("\n    *  \"Program for multiple core example.\"                              *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
	printf("\n");

/**
*
*  Open the card with the specified card number.
*  An error value is returned, which is tested
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

/**
*
*  Find all ARINC 717 cores on the board with a BiPhase receive channel.
*
**/

	corecount = 0;

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		b717Core[corenum] = FALSE;
		errval = BTICard_CoreOpen(&hCores[corenum],corenum,hCard);
		if (errval) break;

		for (chan=0;chan<MAX_CHANNELS;chan++)
		{
			if (BTI717_ChIsType(CHCFG717_BIPHASERCV, chan, hCores[corenum]))
			{
				b717Core[corenum] = TRUE;
				corecount++;
				break;
			}
		}
	}

	if (!corecount)
	{
		printf("\nError:  Unable to find any ARINC 717 cores on card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing %d ARINC 717 core(s) on card #%d",corecount,CARDNUM);
	printf("\n");

/**
*
*  Configure all receive channels  for auto speed detection.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		if (b717Core[corenum])
		{
			BTICard_CardReset(hCores[corenum]);			/* Reset the core. */

			for (chan=0;chan<MAX_CHANNELS;chan++)
			{
				if (BTI717_ChIsType(CHCFG717_BIPHASERCV, chan, hCores[corenum]))
				{
					errval = BTI717_ChConfig(CHCFG717_BIPHASERCV | CHCFG717_AUTOSPEED,chan,hCores[corenum]);
					if (errval < 0)
					{
						printf("\nError:  An error was encountered (%i) while configuring channel %d.",errval,chan);
						printf("\n        on core %d (%s)",corenum,BTICard_ErrDescStr(errval,hCard));
						printf("\n");
						BTICard_CardClose(hCard);
						exit(1);
					}
				}
			}
		}
	}

/**
*
*   Start each 717 core to begin
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		if (b717Core[corenum])	BTICard_CardStart(hCores[corenum]);
	}

/**
*
*  Display data on the screen.
*
**/

	printf("\nPress any key to exit....\n\n");

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		if (b717Core[corenum])
		{
			for (chan=0;chan<MAX_CHANNELS;chan++)
			{
				if (BTI717_ChIsType(CHCFG717_BIPHASERCV, chan, hCores[corenum]))
				{
					printf("\nSynchronizing channel %d on core %d to bit stream....",chan,corenum);

					while (!BTI717_SyncTest(chan,hCores[corenum]) && !kbhit());

					if (BTI717_SyncTest(chan,hCores[corenum]))	printf("In Sync!\n");
				}
			}
		}
	}

/**
*
*  Stop the card.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		BTICard_CardStop(hCores[corenum]);
	}

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardClose(hCard);
}
