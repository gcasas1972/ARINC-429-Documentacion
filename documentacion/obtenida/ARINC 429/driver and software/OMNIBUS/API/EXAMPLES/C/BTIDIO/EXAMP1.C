
/**
*
*  BTIDIO DRIVER EXAMPLE 1  (06/09/2011)
*  Copyright (c) 2005-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Input/Output example
*
**/

/**
*
*  This program opens Card Number 0 and configures the
*  first compatible core in shunt mode to query the current input state
*  of Bank A.  The corresponding outputs can be driven by the number keys (0-7).
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
	BYTE input;
	BYTE output = 0;
	CHAR ch;
	BYTE fault_mask;
	BOOL done;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP1  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTIDIO Example 1                                                  *");
	printf("\n    *  \"Program for input/output example.\"                               *");
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
	printf("\n");
	printf("\n");



/**
*
*  Configure banknum as a shunt, input/output bank with logic low
*  on the input interpreted as 1.
*
**/

	BTICard_CardReset(hCore);

	bankcfg = BANKCFGDIO_SHUNT | BANKCFGDIO_INOUT | BANKCFGDIO_POLIN_INV;
	errval = BTIDIO_BankConfig(bankcfg,THRESHOLDDIO_2_5V,SAMPLERATEDIO_MS | 0x0001,0,hCore);

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
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Read and display the current value of the discrete inputs.
*
**/

  	printf("\nPress keys 0-7 to toggle the outputs.  Press escape to exit...");
	printf("\n");
	printf("\n");

	done = 0;
	while (!done)  /* Exit loop if Escape is pressed */
	{
		if (kbhit())
		{
			ch = getch();

			/* Check to see if user pressed Escape */
			if (ch == 0x1B)
				done = 1;

			/* Clear faults on user command */
			else if (ch == 'c' || ch == 'C')
				BTIDIO_BankFaultClr(fault_mask,banknum,hCore);

			/* Toggle Outputs based on user commands */
			if (ch >= '0' && ch <= '7')
			{
				output = output ^ (BYTE)(1 << (ch - '0'));
				BTIDIO_BankWr(output,banknum,hCore);
			}
		}


		/* Check for Faults on the Outputs */
		fault_mask = BTIDIO_BankFaultRd(banknum,hCore);

		/* Read Bank A and Display the State of its Discretes */
		input = BTIDIO_BankRd(banknum,hCore);

		printf("\rBank %c DOUT: ",(char)banknum + 'A');

		printf("%c",((fault_mask & 0x0080) ? 'F' : ((output & 0x0080) ? '1' : '0')));
		printf("%c",((fault_mask & 0x0040) ? 'F' : ((output & 0x0040) ? '1' : '0')));
		printf("%c",((fault_mask & 0x0020) ? 'F' : ((output & 0x0020) ? '1' : '0')));
		printf("%c",((fault_mask & 0x0010) ? 'F' : ((output & 0x0010) ? '1' : '0')));

		printf("%c",((fault_mask & 0x0008) ? 'F' : ((output & 0x0008) ? '1' : '0')));
		printf("%c",((fault_mask & 0x0004) ? 'F' : ((output & 0x0004) ? '1' : '0')));
		printf("%c",((fault_mask & 0x0002) ? 'F' : ((output & 0x0002) ? '1' : '0')));
		printf("%c",((fault_mask & 0x0001) ? 'F' : ((output & 0x0001) ? '1' : '0')));

		printf(", DIN: ");

		printf("%c",(input & 0x0080) ? '1' : '0');
		printf("%c",(input & 0x0040) ? '1' : '0');
		printf("%c",(input & 0x0020) ? '1' : '0');
		printf("%c",(input & 0x0010) ? '1' : '0');

		printf("%c",(input & 0x0008) ? '1' : '0');
		printf("%c",(input & 0x0004) ? '1' : '0');
		printf("%c",(input & 0x0002) ? '1' : '0');
		printf("%c",(input & 0x0001) ? '1' : '0');

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
