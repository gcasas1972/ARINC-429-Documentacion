
/**
*
*  BTICSDB DRIVER EXAMPLE 9  (06/09/2011)
*  Copyright (c) 2005-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP9.C -- Asynchronous serial example
*
**/

/**
*
*
**/

#include "BTICard.H"
#include "BTICSDB.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		      0
#define	MAX_CORES         4
#define	MAX_CHANNELS     32

#define BYTESPERBLOCK     1
#define BLOCKSPERFRAME    1
#define FRAMESPERSECOND 200
#define LISTSIZE        100

void main(void)
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT input;
	INT corenum;
	INT rcvchan, xmtchan;
	BOOL rcvfound, xmtfound;
	MSGADDR msgaddr;
	MSGADDR msgdefault;
	BYTE xmtbuf;
	BYTE rcvbuf;
	BOOL done = 0;
	LISTADDR xmtlistaddr,rcvlistaddr;
	INT i,count;
	LPCSTR initstring = "Ballard Technology, OmniBus Serial Module.";


	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP9  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICSDB Example 9                                                 *");
	printf("\n    *  \"Program for Asynchronous serial mode.\"                           *");
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
*  Find the first CSDB core with both a receive and a transmit channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		rcvfound = 0;
		xmtfound = 0;

		errval = BTICard_CoreOpen(&hCore,corenum,hCard);	/* Open a handle to the core. */
		if (errval) break;

		for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
		{
			rcvfound = BTICSDB_ChIsRcv(rcvchan,hCore);
			if (rcvfound) break;
		}

		if (rcvfound)
		{
			for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
			{
				xmtfound = BTICSDB_ChIsXmt(xmtchan,hCore);
				if (xmtfound) break;
			}
		}

		if (rcvfound && xmtfound)	break;
	}

	if (errval || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
	{
		printf("\nError:  No compatible CSDB core present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing CSDB core #%d",corenum);
	printf("\nUsing receive channel #%d",rcvchan);
	printf("\nUsing transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure rcvchan for high speed and general purpose serial (ASYNCMODE).
*  Configure xmtchan to transmit at high speed and general purpose serial (ASYNCMODE).
*
**/

	BTICard_CardReset(hCore);

	errval = BTICSDB_ChConfig(CHCFGCSDB_ASYNCMODE,BITRATECSDB_HIGHSPEED,BYTESPERBLOCK,FRAMESPERSECOND,BLOCKSPERFRAME,rcvchan,hCore); /*Configure rcvchan*/

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

	errval = BTICSDB_ChConfig(CHCFGCSDB_ASYNCMODE,BITRATECSDB_HIGHSPEED,BYTESPERBLOCK,FRAMESPERSECOND,BLOCKSPERFRAME,xmtchan,hCore); /*Configure xmtchan*/

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}


/**
*
*	Create and schedule a non-continuous message.
*
**/
	msgaddr = BTICSDB_MsgCreate(MSGCRTCSDB_NONCONT,hCore);

	errval = BTICSDB_SchedMsg(msgaddr,xmtchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while scheduling the message.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}


/**
*
*	Create a default filter to receive all data.
*
**/
	msgdefault	= BTICSDB_FilterDefault(MSGCRTCSDB_DEFAULT,rcvchan,hCore);


/**
*
*	Create and initialize the transmit list. Create the receive list.
*
**/
	xmtlistaddr = BTICSDB_ListXmtCreate(LISTCRTCSDB_FIFO,LISTSIZE,msgaddr,hCore);

	if (xmtlistaddr == 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring the transmit list.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

	for (i = 0; (initstring[i] != '\0') && (i != LISTSIZE); i++)
	{
		xmtbuf = initstring[i];
		BTICSDB_ListDataWr(&xmtbuf,BYTESPERBLOCK,xmtlistaddr,hCore);
	}

	BTICSDB_MsgValidSet(msgaddr,hCore);

	rcvlistaddr = BTICSDB_ListRcvCreate(LISTCRTCSDB_FIFO,LISTSIZE,msgdefault,hCore);

	if (rcvlistaddr == 0)
	{
		printf("\nError:   An error was encountered (%i) while configuring the transmit list.",errval);
		printf("\n         (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*	Start Device.
*
**/
	BTICard_CardStart(hCore);

	printf("\n\n");

	while (!done)
	{
		count = BTICSDB_ListDataRd(&rcvbuf,BYTESPERBLOCK,rcvlistaddr,hCore);
		if (count)
		{
			if (rcvbuf == 0x0d)		//Carriage Return
			{
				printf("\n");
			}
			else
			{
				printf("%c",rcvbuf);
			}
		}

		if (kbhit())
		{
			input = getch();

			if (input == 0x1B)		// ESC key
			{
				done = 1;
			}
			else if(input == 0xE0)	// Function key
			{
				input = getch();	// Function keys have extra keypress
			}
			else
			{
				xmtbuf = input;
				BTICSDB_ListDataWr(&xmtbuf,BYTESPERBLOCK,xmtlistaddr,hCore);
				BTICSDB_MsgValidSet(msgaddr,hCore);
			}
		}
	}

	BTICard_CardStop(hCore);

	BTICard_CardClose(hCard);
}
