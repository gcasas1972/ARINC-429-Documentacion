
/**
*
*  BTI429 DRIVER EXAMPLE 8  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP8.C -- Polling the Event Log List
*
**/

/**
*
*  This program opens Card Number 0, finds the first
*  compatible core, and configures the first receive
*  channel to receive 2 GPS messages into separate
*  Message Records; and receive all other messages
*  into a default Message Record.
*
*  Each of the messages is also configured to generate an
*  Event Log List entry.  When an entry is read from the list,
*  the associated data is read.
*
**/

#include "BTICard.H"
#include "BTI429.H"
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
	ERRVAL  errval;
	INT     corenum;
	INT     rcvchan;
	USHORT  Type;
	ULONG   Info;
	MSGADDR msgaddr;
	MSGSTRUCT429 msgdefault;
	MSGSTRUCT429 latitude;
	MSGSTRUCT429 longitude;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP8  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI429 Example 8                                                  *");
	printf("\n    *  \"Polling the Event Log List.\"                                     *");
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

	printf("\nUsing ARINC 429 card #%d",CARDNUM);

/**
*
*  Find the first ARINC 429 core with a receive channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)	if (BTI429_ChIsRcv(rcvchan,hCore)) break;

		if (rcvchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 429 receive channels present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 429 core #%d",corenum);
	printf("\nUsing receive channel #%d",rcvchan);
	printf("\n");

/**
*
*  Configure rcvchan for automatic speed detection.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI429_ChConfig(CHCFG429_AUTOSPEED,rcvchan,hCore);   /*Configure channel*/

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
*  Each message is configured to create Event Log list entries.
*
**/

	msgdefault.addr = BTI429_FilterDefault(MSGCRT429_LOG,rcvchan,hCore);
	latitude.addr   = BTI429_FilterSet(MSGCRT429_LOG,0310,SDIALL,rcvchan,hCore);
	longitude.addr  = BTI429_FilterSet(MSGCRT429_LOG,0311,SDIALL,rcvchan,hCore);

/**
*
*  Initialize data values to zero.
*
**/

	msgdefault.data = 0;
	latitude.data   = 0;
	longitude.data  = 0;

/**
*
*  Configure the Event Log list.
*
**/

	errval = BTICard_EventLogConfig(LOGCFG_ENABLE,1024,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the event log list on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
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

	while(!kbhit())
	{
		if (BTICard_EventLogRd(&Type,&Info,NULL,hCore))	//Read entry from Event Log list
		{
			msgaddr = Info;								//Info value is message address

			if (msgaddr == msgdefault.addr)
			{
				msgdefault.data = BTI429_MsgDataRd(msgaddr,hCore);
			}
			else if (msgaddr == latitude.addr)
			{
				latitude.data = BTI429_MsgDataRd(msgaddr,hCore);
			}
			else if (msgaddr == longitude.addr)
			{
				longitude.data = BTI429_MsgDataRd(msgaddr,hCore);
			}
		}

		printf("\r");
		printf("Default=%08lX " ,msgdefault.data);
		printf("Latitude=%08lX ",latitude.data);
		printf("Longitude=%08lX",longitude.data);
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
