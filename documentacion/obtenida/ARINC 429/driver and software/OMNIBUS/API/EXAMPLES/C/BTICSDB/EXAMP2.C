
/**
*
*  BTICSDB DRIVER EXAMPLE 2  (06/09/2011)
*  Copyright (c) 2005-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- Receiver example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first compatible core to receive continuous message
*  and a burst message into unique Message Records. All
*  other messages are received into a default Message Record.
*
**/

#include "BTICard.h"
#include "BTICSDB.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		     0
#define	MAX_CORES        4
#define	MAX_CHANNELS    32

#define BLOCKSPERFRAME  18
#define BYTESPERBLOCK    6
#define FRAMESPERSECOND 10

void main(void)
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT corenum;
	INT rcvchan;
	MSGADDR msgdefault;
	MSGADDR msgcont;
	MSGADDR msgburst;
	BYTE datadefault[BYTESPERBLOCK];
	BYTE datacont[BYTESPERBLOCK];
	BYTE databurst[BYTESPERBLOCK];

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP2  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICSDB Example 2                                                 *");
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

	printf("\nUsing CSDB card #%d",CARDNUM);

/**
*
*  Find the first CSDB core with a receive channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)	if (BTICSDB_ChIsRcv(rcvchan,hCore)) break;

		if (rcvchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS)
	{
		printf("\nError:  No CSDB receive channels present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing CSDB core #%d",corenum);
	printf("\nUsing receive channel #%d",rcvchan);
	printf("\n");

/**
*
*  Configure receiver channel for default operation.
*
**/

	BTICard_CardReset(hCore);

	errval = BTICSDB_ChConfig(CHCFGCSDB_DEFAULT,BITRATECSDB_LOWSPEED,BYTESPERBLOCK,FRAMESPERSECOND,BLOCKSPERFRAME,rcvchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Before any messages can be received, filters must be set
*  for the receive channel.  First, the default filter is
*  created.  Then, two filters are set for the two messages
*  of interest.
*
**/

	msgdefault	= BTICSDB_FilterDefault(MSGCRTCSDB_DEFAULT,rcvchan,hCore);
	msgcont		= BTICSDB_FilterSet(MSGCRTCSDB_DEFAULT,0x12,SIALL,rcvchan,hCore);
	msgburst	= BTICSDB_FilterSet(MSGCRTCSDB_DEFAULT,0x31,SIALL,rcvchan,hCore);

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

	while(!kbhit())
	{
		/*Read message records*/
		BTICSDB_MsgDataRd(datadefault,BYTESPERBLOCK,msgdefault,hCore);
		BTICSDB_MsgDataRd(datacont,BYTESPERBLOCK,msgcont,hCore);
		BTICSDB_MsgDataRd(databurst,BYTESPERBLOCK,msgburst,hCore);

		/*Display values*/
		printf("\r");
		printf("Cont: Addr=%08lX, Status=%08lX   ",datacont[0],datacont[1]);
		printf("Burst: Addr=%08lX, Status=%08lX",databurst[0],databurst[1]);
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
