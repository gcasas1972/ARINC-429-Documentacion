
/**
*
*  BTI1553 DRIVER EXAMPLE 14  (06/09/2011)
*  Copyright (c) 2003-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP14.C -- Multiple Cores - Monitor all channels on all cores
*
**/

/**
*
*  This example configures all 1553 channels on all cores of Card Number 0
*  as Bus Monitor terminals. It prints the channel number, time-tag, command
*  words (if any), and status words (if any) for each monitor record.
*
**/

#include "BTICard.H"
#include "BTI1553.H"
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
	HCARD	hCard;						/*Handle to card*/
	HCORE	hCores[MAX_CORES] = {0};	/*Handle to cores*/
	BOOL	b1553Core[MAX_CORES] = {0}; /*Flag indicating 1553 core*/
	INT		corecount;					/*Number of cores found*/
	ERRVAL	errval;						/*Error return value*/
	INT		channum;					/*Channel number*/

	USHORT seqbuf[2048];
	ULONG  seqcount;
	ULONG  blkcnt;
	LPSEQRECORD1553 pRec1553;
	SEQFINDINFO sfinfo;
	INT	   j;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP14  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2003-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 14                                                *");
	printf("\n    *  \"Multi Core - Monitor all channels on all cores\"                  *");
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

	printf("\nUsing BTI1553 card #%d",CARDNUM);

/**
*
*  Find all MIL-STD-1553 cores.
*
**/
	corecount = 0;

	for (j=0; j<MAX_CORES; j++)
	{
		b1553Core[j] = FALSE;
		errval = BTICard_CoreOpen(&hCores[j],j,hCard);
		if (errval) break;

		for (channum=0;channum<MAX_CHANNELS;channum++)
		{
			if (BTI1553_ChIs1553(channum,hCores[j]))
			{
				b1553Core[j] = TRUE;
				corecount++;
				break;
			}
		}
	}

	if (0==corecount)
	{
		printf("\nError:  No MIL-STD-1553 cores present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing %d MIL-STD-1553 core(s)",corecount);
	printf("\n");

/**
*
*  Configure the sequential record on each 1553 core.
*  Configure all 1553 channels for monitor mode.
*
**/

	for (j=0; j<MAX_CORES; j++)
	{
		if (b1553Core[j])
		{
			BTICard_CardReset(hCores[j]);	/*First reset the core*/

			errval = BTICard_SeqConfig(SEQCFG_DEFAULT,hCores[j]);
			if (errval < 0)
			{
				printf("\nError:  An error was encountered (%i) while configuring",errval);
				printf("\n        the sequential record on core #%d.",j);
				printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
				BTICard_CardClose(hCard);
				exit(1);
			}

			for (channum=0;channum<MAX_CHANNELS;channum++)
			{
				if (BTI1553_ChIs1553(channum,hCores[j]))
				{
					errval = BTI1553_MonConfig(MONCFG1553_DEFAULT,channum,hCores[j]);
					if (errval < 0)
					{
						printf("\nError:  An error was encountered (%i) while configuring for",errval);
						printf("\n        monitor mode on channel #%d on core #%d.",channum,j);
						printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
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
*  Start each 1553 core to begin
*
**/

	for (j=0; j<MAX_CORES; j++)
	{
		if (b1553Core[j])	BTICard_CardStart(hCores[j]);
	}

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit....\n\n");

	while (!kbhit())
	{
		for (j=0; j<MAX_CORES; j++)
		{
			if (b1553Core[j])
			{
				seqcount = BTICard_SeqBlkRd(seqbuf,sizeof(seqbuf)/sizeof(seqbuf[0]),&blkcnt,hCores[j]);

				BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

				while(!BTICard_SeqFindNext1553(&pRec1553,&sfinfo))
				{
					printf("\n");

					printf(" Core:%02d",j);
					printf(" Ch:%02u",(pRec1553->activity & MSGACT1553_CHMASK) >> MSGACT1553_CHSHIFT);
					printf(" Time:%lu",pRec1553->timestamp);

					if (pRec1553->activity & MSGACT1553_RCVCWD1) printf(" Cwd1:%04X",pRec1553->cwd1);
					if (pRec1553->activity & MSGACT1553_RCVCWD2) printf(" Cwd2:%04X",pRec1553->cwd2);
					if (pRec1553->activity & MSGACT1553_RCVSWD1) printf(" Swd1:%04X",pRec1553->swd1);
					if (pRec1553->activity & MSGACT1553_RCVSWD2) printf(" Swd2:%04X",pRec1553->swd2);

					if (pRec1553->error & MSGERR1553_NORESP) printf(" No response!");
					if (pRec1553->error & MSGERR1553_ANYERR) printf(" Error!");
				}
			}
		}
	}

/**
*
*  Stop all cores.
*
**/

	for (j=0; j<MAX_CORES; j++)
	{
		BTICard_CardStop(hCores[j]);
	}

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardClose(hCard);
}
