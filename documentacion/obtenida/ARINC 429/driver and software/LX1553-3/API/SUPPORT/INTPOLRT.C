
/**
*
*  LP1553-3 DRIVER EXAMPLE 9  Version 1.0  (10/01/2003)
*  Copyright (c) 2003
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   INTPOLRT.C -- Modified Example 9.
*                        "Polled Interrupts"
*
**/

/**
*
*  This example configures the LP1553-3 as RT1.  All subaddresses
*  and mode codes for RT1 are enabled to generate interrupt log
*  list entries.  The program polls the interrupt log list and
*  displays all command words received by RT1.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include "l13c.h"

#define	CARDNUM 0					/*Card number of LP1553-3 card*/

/**
*
*  The following thread is spun off by the main application. 
*  It polls the interrupt log list of the card.
*
**/

void main(void)
{
	HCARD   handleval;
	ERRVAL  errval;
	USHORT  Type;
	USHORT  Info;
	MSGADDR msgaddr;
	INT j;

	BOOL mcflag;
	BOOL trflag;
	INT saval;

	fprintf(stderr,"\nINTPOLRT  Version 1.0  (10/01/2003)");
	fprintf(stderr,"\nCopyright 2003  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 Modified Example 9");
	fprintf(stderr,"\n\"Polling Interrupts\"");
	fprintf(stderr,"\n");

/**
*
*  Open the LP1553-3 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	handleval = L13_CardOpen(CARDNUM);					/*Open the LP1553-3 card*/

	if (handleval < 0)
	{
		printf("\nError:  Either LP1553-3 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",handleval);
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for bus controller mode.
*
**/

	printf("\nResetting card");

	L13_CardReset(handleval);							/*Reset the LP1553-3 card*/

	printf("\nConfiguring RT1");

	errval = L13_RTConfig(RTCFG_DEFAULT,1,handleval);	/*Configure the LP1553-3 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for RT mode.",errval);
		L13_CardClose(handleval);
		exit(1);
	}

/**
*
*  Configure the interrupt log list.
*
**/

	printf("\nConfiguring interrupt log list");

	errval = L13_IntConfig(INTCFG_ENABLE,1024,handleval);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring interrupt log list.",errval);
		L13_CardClose(handleval);
		exit(1);
	}

/**
*
*  Configure all subaddresses and mode codes for RT to generate an interrupt.
*
**/
	for (mcflag=0;mcflag<=1;++mcflag)
	{
		for (trflag=0;trflag<=1;++trflag)
		{
			for (saval=0;saval<=31;++saval)
			{
				printf("\nConfiguring %s%u TR%u",(mcflag) ? "MC":"SA",saval,trflag);

				msgaddr = L13_RTCreateMsg(MSGCRT_INT,mcflag,1,trflag,saval,handleval);

				if (!msgaddr)
				{
					fprintf(stderr,"\nError:  Unable to configure RT message mcflag=%u trflag=%u saval=%u.",mcflag,trflag,saval);
					L13_CardClose(handleval);
					exit(1);
				}
			}
		}
	}

/**
*
*  Start the card to begin transmissions.
*
**/

	printf("\nStarting card");

	L13_CardStart(handleval);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");
	
	while (!kbhit())
	{
		if (L13_IntRd(&Type,&Info,handleval))				//Read entry from interrupt log list
		{
			printf("Type=%04X Info=%04X (Info==CWD1 if Type==1)\n",Type,Info);
		}
	}

/**
*
*  The LP1553-3 card MUST be closed before exiting the program.
*
**/

	printf("\nStopping card");

	L13_CardStop(handleval);					/*Stop the card*/

	printf("\nClosing card");

	L13_CardClose(handleval);					/*Close the card*/
}
