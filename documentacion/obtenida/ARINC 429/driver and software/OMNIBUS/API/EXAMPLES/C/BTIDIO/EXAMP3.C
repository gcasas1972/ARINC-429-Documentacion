
/**
*
*  BTIDIO DRIVER EXAMPLE 3  (06/09/2011)
*  Copyright (c) 2005-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- Polling the Event Log List
*
**/

/**
*
*  This program opens Card Number 0 and configures the
*  first compatible core to log positive edge events
*  of Discrete 0 in Bank A.
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
	ERRVAL errval;
	INT corenum;
	INT banknum;
	INT ionum = 0;
	INT ch;
	USHORT type;
	ULONG info;
	INT event_banknum;
	BOOL done;
	ULONG disccfg;
	ULONG bankcfg;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP3  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTIDIO Example 3                                                  *");
	printf("\n    *  \"Polling the Event Log List.\"                                     *");
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
	printf("\nUsing Bank %c",banknum + 'A');
	printf("\nUsing Discrete %d",ionum);
	printf("\n");

/**
*
*  Configure banknum as a shunt, input bank with inverted input polarity.
*
**/

	BTICard_CardReset(hCore);

	/*
	*  Threshold:   10kOhm switching level
	*  Sample Rate: 1ms clock, no divide value --> 1ms sampling
	*  This example does not enable Event Logging at the Bank Level
	*/
	bankcfg = BANKCFGDIO_SHUNT | BANKCFGDIO_INPUT | BANKCFGDIO_POLIN_INV;
	errval = BTIDIO_BankConfig(bankcfg,THRESHOLDDIO_10KOHM,SAMPLERATEDIO_MS | 0x0001,banknum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        bank #%d on core #%d.",banknum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure ionum as an inout with event logging
*
**/

	disccfg = DISCCFGDIO_INOUT | DISCCFGDIO_POLIN_INV | DISCCFGDIO_LOGPOSEDGE | DISCCFGDIO_LOGFAULT;
	errval = BTIDIO_DiscreteConfig(disccfg,	ionum,banknum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        discrete #%d on bank %c on core %d.",ionum,banknum+'A',corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure the Event Log to handle up to 30 events
*
**/

	errval = BTICard_EventLogConfig(LOGCFG_ENABLE,1024,hCore);

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

	printf("\nPress spacebar to toggle discrete %d.  Press escape to exit...\n\n",ionum);

	done = 0;
	while (!done)
	{
		if (kbhit())
		{
			ch = getch();

			/* if escape is pressed, exit loop */
			if (ch == 0x1B)
			{
				done = 1;
			}

			/* if spacebar is pressed, toggle the discrete */
			else if (ch == ' ')
			{
				BTIDIO_DiscreteWr(!BTIDIO_DiscreteRd(ionum,banknum,hCore),ionum,banknum,hCore);
			}

			/* Clear faults on user command */
			else if (ch == 'c' || ch == 'C')
			{
				BTIDIO_BankFaultClr(0x01,banknum,hCore);
			}
		}

		/* Read the Event Log */
		if (BTICard_EventLogRd(&type,&info,&event_banknum,hCore))
		{
			if (type == EVENTTYPE_DIOEDGE)
			{
				printf("\nBank %c had an edge (0x%04X)",event_banknum+'A',info);
			}
			else if (type == EVENTTYPE_DIOFAULT)
			{
				printf("\nBank %c had a fault (0x%04X)",event_banknum+'A',info);
			}
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
