
/**
*
*  BTIDIO DRIVER EXAMPLE 2  (06/09/2011)
*  Copyright (c) 2005-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- Monitor example
*
**/

/**
*
*  This program opens Card Number 0 and configures the
*  first compatible core to monitor the input values of
*  the discretes of Bank A.
*
**/

#include "BTICard.H"
#include "BTIDIO.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		     0
#define	MAX_CORES        4
#define	MAX_BANKS        4

void main(void)
{
	HCARD hCard;
	HCORE hCore;
	INT corenum;
	INT banknum;
	ERRVAL errval;
	USHORT bankcfg;
	USHORT seqbuf[2048];
	ULONG seqcount;
	ULONG blkcnt;
	LPSEQRECORDDIO pRecDIO;
	SEQFINDINFO sfinfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP2  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTIDIO Example 2                                                  *");
	printf("\n    *  \"Program for Monitor example.\"                                    *");
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

	printf("\nUsing DIO card #%d",CARDNUM);

/**
*
*  Find the first core with a DIO bank.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (banknum=0;banknum<MAX_BANKS;banknum++)
		{
			if (BTIDIO_BankIsDIO(banknum,hCore))	break;
		}

		if (banknum != MAX_BANKS) break;
	}

	if (errval || corenum == MAX_CORES || banknum == MAX_BANKS)
	{
		printf("\nError:  No DIO banks present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing DIO core #%d",corenum);
	printf("\nUsing Bank %c",banknum+'A');
	printf("\n");

/**
*
*  Configure banknum as a series, input bank with a sequential monitor on all edges, all discretes.
*
**/

	BTICard_CardReset(hCore);

	/*
	*  Threshold:   1.4V, TTL levels
	*  Sample Rate: 1ms clock, no divide value --> 1ms sampling
	*/
	bankcfg = BANKCFGDIO_SERIES | BANKCFGDIO_INPUT | BANKCFGDIO_SEQALL;
	errval = BTIDIO_BankConfig(bankcfg,THRESHOLDDIO_TTL,SAMPLERATEDIO_MS | 0x0001,banknum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        bank %c on core #%d.",banknum+'A',corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure the Sequential Monitor for fill and halt mode (default).
*
**/

	errval = BTICard_SeqConfig(SEQCFG_DEFAULT,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring the sequential record.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
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

	printf("\nPress any key to exit...");
	printf("\n");
	printf("\n");

	while (!kbhit())
	{
		seqcount = BTICard_SeqBlkRd(seqbuf,sizeof(seqbuf)/sizeof(seqbuf[0]),&blkcnt,hCore);

		/*Initialize Find function*/
		BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

		/*Find DIO records*/
		while(!BTICard_SeqFindNextDIO(&pRecDIO,&sfinfo))
		{
			/*Write to disk, display data, etc. as desired. For example:*/
			printf("\nBank %c:  DIN: ",pRecDIO->bank + 'A');

			printf("%c",(pRecDIO->state & 0x0080) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0040) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0020) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0010) ? '1' : '0');

			printf("%c",(pRecDIO->state & 0x0008) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0004) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0002) ? '1' : '0');
			printf("%c",(pRecDIO->state & 0x0001) ? '1' : '0');

			printf(", Time: %08ld us",pRecDIO->timestamp);



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
