
/**
*
*  CM1553-3 DRIVER EXAMPLE 5  Version 1.0  (07/16/2001)
*  Copyright (c) 1999-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5.C -- Example 5 from Section 5.1.
*                      "Simultaneous BC, RT, and monitor simulation"
*
**/

/**
*
*  This example requires a CM1553-3C or higher.  It
*  configures the CM1553-3 as a BC, an RT, and a monitor.
*  The BC transmits one BC-RT message (command word 0843H).
*  The RT is configured with terminal address 1, so the
*  simulated RT receives the simulated BC's transmissions.
*  The data word transmitted by the RT are incremented and
*  displayed.  The data words received by the RT are read and
*  also displayed.
*
**/

#include "c13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of CM1553-3 card*/

#define	FRAMETIME	10000			/*Frame time in microseconds*/

void main(void)
{
	HCARD   Card;
	ERRVAL  errval;
	MSGADDR BCMsg;
	MSGADDR RTMsg;
	USHORT  BCData[3] = {0,0,0};
	USHORT  RTData[3] = {0,0,0};

	fprintf(stderr,"\nEXAMP5  Version 1.0  (07/16/2001)");
	fprintf(stderr,"\nCopyright (c) 1999-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nCM1553-3 Example 5");
	fprintf(stderr,"\n\"Simultaneous BC, RT, and monitor simulation\"");
	fprintf(stderr,"\n");

/**
*
*  Open the CM1553-3 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = C13_CardOpen(CARDNUM);					/*Open the CM1553-3 card*/

	if (Card < 0)
	{
		printf("\nError:  Either CM1553-3 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Check that card supports multi-terminal simulation.
*
**/

	if (!C13_CardGetInfo(INFOTYPE_MULTIMODE,Card))
	{
		printf("\nError:  The CM1553-3 with card number %u",CARDNUM);
		printf("\n        does not support multiterminal simulation.");
		printf("\n");
		exit(1);
	}

/**
*
*  Check that card supports concurrent monitor.
*
**/

	if (!C13_CardGetInfo(INFOTYPE_CONCURMON,Card))
	{
		printf("\nError:  The CM1553-3 with card number %u",CARDNUM);
		printf("\n        does not support a concurrent monitor.");
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for bus controller mode.
*
**/

	C13_CardReset(Card);							/*Reset the CM1553-3 card*/

	errval = C13_BCConfig(BCCFG_DEFAULT,Card);		/*Configure the CM1553-3 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for bus controller mode.",errval);
		C13_CardClose(Card);
		exit(1);
	}

/**
*
*  Create a bus controller message and insert into the bus
*  controller schedule.
*
**/

	BCMsg = C13_BCCreateMsg(MSGCRT_DEFAULT, 0x0843, 0, BCData, Card);

	C13_BCSchedFrame(FRAMETIME, Card);
	C13_BCSchedMsg(BCMsg, Card);

/**
*
*  Configure the card for remote terminal mode as shown in
*  Example 3.
*
**/

	errval = C13_RTConfig(RTCFG_DEFAULT, 1, Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for remote terminal mode.",errval);
		C13_CardClose(Card);
		exit(1);
	}

/**
*
*  Get the message address for a receive subaddress.
*
**/

	RTMsg = C13_RTGetMsg(SUBADDRESS, 1, RCV, 2, Card);

/**
*
*  Configure the card for monitor mode as shown in Example 4.
*
**/

	errval = C13_MonConfig(MONCFG_DEFAULT, Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for monitor mode.",errval);
		C13_CardClose(Card);
		exit(1);
	}

	C13_MonFilterTA(0x00000002, Card);			/*Monitor RT address 1*/

/**
*
*  Start the card to begin transmitting and receiving messages.
*
**/

	C13_CardStart(Card);

/**
*
*  Wait until a key is hit.
*
**/

	printf("Press any key to quit.\n");

	while (!kbhit())
	{
		printf("\r");

		BCData[0] += 2;		/*Update the data that the BC is transmitting*/
		BCData[1] += 4;
		BCData[2] += 6;

		printf("Transmitting data {%04XH, %04XH, %04XH} ",BCData[0],BCData[1],BCData[2]);

		C13_MsgDataWr(BCData, 3, BCMsg, Card);	/*Read the data received by the RT*/
		C13_MsgDataRd(RTData, 3, RTMsg, Card);

		printf("Received data {%04XH, %04XH, %04XH} ",RTData[0],RTData[1],RTData[2]);
	}

/**
*
*  The CM1553-3 card MUST be closed before exiting the program.
*
**/

	C13_CardStop(Card);
	C13_CardClose(Card);
}
