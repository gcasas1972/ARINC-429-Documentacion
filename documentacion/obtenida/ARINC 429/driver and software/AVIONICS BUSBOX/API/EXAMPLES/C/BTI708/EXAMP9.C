
/**
*
*  BTI708 DRIVER EXAMPLE 9  (06/09/2011)
*  Copyright (c) 2003-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP9.C -- Multiple Core Example
*
**/

/**
*
*  This program opens Card Number 0 and configures all
*  ARINC 708 cores to transmit, receive, and monitor.
*  All transmit channels and all receive channels are
*  used. It also enables the sequential monitor to record
*  transmitted and received messages.
*
**/

#include "BTICard.H"
#include "BTI708.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

#define	FRAMEFREQ	  200          /*Frame frequency of 200Hz*/
#define LOGFREQ		  16           /*Generate a Log Event after every 16th message*/
#define	FRAMECOUNT	  32           /*Transmit a total of 32 messages*/

void main(void)
{
	HCARD hCard;
	HCORE hCores[MAX_CORES];
	INT corecount, corenum, chan;
	ERRVAL errval;

	INT    count = 0;
	ULONG  j,jj;
	USHORT Data[100];
	USHORT seqbuf[2048];
	ULONG seqcount;
	ULONG blkcnt;
	LPSEQRECORD708 pRec708;
	SEQFINDINFO sfinfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP9  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2003-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI708 Example 9                                                  *");
	printf("\n    *  \"Program for multiple cores example.\"                             *");
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

/**
*
*  Find all ARINC 708 cores on the board
*
**/

	corecount = 0;

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		HCORE hCore;
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (chan=0;chan<MAX_CHANNELS;chan++)
		{
			if (BTI708_ChIs708(chan,hCore))	break;
		}

		if (chan!=MAX_CHANNELS)
		{
			hCores[corecount] = hCore;
			corecount++;
			continue;
		}
	}

	if (!corecount)
	{
		printf("\nError:  Unable to find any ARINC 708 cores on card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing %d ARINC 708 core(s) on card #%d",corecount,CARDNUM);
	printf("\n");

/**
*
*  Configure all transmit channels on all cores to send 32 messages at 200Hz
*  Configure all receive channels on all cores to receive messages in a single message record per core.
*  Configure each cores sequential record.
*
**/

	for (corenum=0;corenum<corecount;corenum++)
	{
		BTICard_CardReset(hCores[corenum]);			/* Reset the core. */

		for (chan=0;chan<MAX_CHANNELS;chan++)
		{
			if (BTI708_ChIsXmt(chan,hCores[corenum]))
			{
				errval = BTI708_ChConfig(CHCFG708_SEQALL,chan,hCores[corenum]);	/*Configure channel*/
				if (errval < 0)
				{
					printf("\nError:  An error was encountered (%i) while configuring",errval);
					printf("\n        transmit channel #%d on core #%d.",chan,corenum);
					printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
					BTICard_CardClose(hCard);
					exit(1);
				}

				errval = BTI708_XmtBuild(MSGCRT708_DEFAULT,FRAMEFREQ,LOGFREQ,FRAMECOUNT,chan,hCores[corenum]);
				if (errval)
				{
					printf("\nError:  An error was encountered (%i) while building",errval);
					printf("\n        transmit channel #%d on core #%d.",chan,corenum);
					printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
					printf("\n");
					BTICard_CardClose(hCard);
					exit(1);
				}

				for (j=0;j<FRAMECOUNT;j++)							/*Loop through all the messages*/
				{
					for (jj=0;jj<100;jj++) Data[jj] = j + (count * FRAMECOUNT);
					BTI708_MsgDataWr(Data,j,chan,hCores[corenum]);	/*Write data to the Device*/
				}
				count++;
			}
			else if (BTI708_ChIsRcv(chan,hCores[corenum]))
			{
				errval = BTI708_ChConfig(CHCFG708_DEFAULT,chan,hCores[corenum]);   /*Configure channel*/
				if (errval < 0)
				{
					printf("\nError:  An error was encountered (%i) while configuring",errval);
					printf("\n        receive channel #%d on core #%d.",chan,corenum);
					printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
					BTICard_CardClose(hCard);
					exit(1);
				}

				errval = BTI708_RcvBuild(MSGCRT708_DEFAULT,0,1,chan,hCores[corenum]);
				if (errval)
				{
					printf("\nError:  An error was encountered (%i) while building",errval);
					printf("\n        receive channel #%d on core #.",chan,corenum);
					printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
					printf("\n");
					BTICard_CardClose(hCard);
					exit(1);
				}
			}
		}

		/* Configure the sequential record on each core for fill and halt mode (default). */
		errval = BTICard_SeqConfig(SEQCFG_DEFAULT,hCores[corenum]);

		if (errval < 0)
		{
			printf("\nError:  An error was encountered (%i) while configuring",errval);
			printf("\n        the sequential record on core #%d.",corenum);
			printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
			BTICard_CardClose(hCard);
			exit(1);
		}
	}

/**
*
*  Start operation of the card.
*
**/

	for (corenum=0;corenum<corecount;corenum++)
	{
		BTICard_CardStart(hCores[corenum]);
	}

/**
*
*  Display data on the screen.
*
**/

	printf("\nPress any key to exit....\n\n");

	while(!kbhit())
	{
		for (corenum=0;corenum<corecount;corenum++)
		{
			seqcount = BTICard_SeqBlkRd(seqbuf,sizeof(seqbuf)/sizeof(seqbuf[0]),&blkcnt,hCores[corenum]);

			BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

			while(!BTICard_SeqFindNext708(&pRec708,&sfinfo))
			{
				printf("\nCore:%d   Ch:%02u   Time Stamp:%08lX",
						corenum,
						((pRec708->activity & MSGACT708_CHMASK) >> MSGACT708_CHSHIFT),
						pRec708->timestamp);
			}
		}
	}

/**
*
*  Stop the card.
*
**/

	for (corenum=0;corenum<corecount;corenum++)
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
