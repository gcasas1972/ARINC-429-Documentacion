
/**
*
*  BTI1553 DRIVER EXAMPLE 5  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5.C -- Simultaneous BC, RT, and monitor simulation
*
**/

/**
*
*  This example requires a Ballard 1553 C version Device or higher.
*  It configures Card Number 0 as a BC, an RT, and a Bus Monitor.
*  The BC transmits one BC-RT message (command word 0843H).
*  The RT is configured with terminal address 1, so the
*  simulated RT receives the simulated BC's transmissions.
*  The data words transmitted by the RT are incremented and
*  displayed.  The data words received by the RT are read and
*  also displayed.
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

#define	FRAMETIME	10000			/*Frame time in microseconds*/

void main(void)
{
	HCARD   hCard;					/*Handle to card*/
	HCORE   hCore;					/*Handle to core*/
	ERRVAL  errval;					/*Error return value*/
	INT     corenum;				/*Core number*/
	INT     channum;				/*Channel number*/

	MSGADDR BCMsg;
	MSGADDR RTMsg;
	USHORT  BCData[3] = {0,0,0};
	USHORT  RTData[3] = {0,0,0};

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP5  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI1553 Example 5                                                 *");
	printf("\n    *  \"Simultaneous BC, RT, and monitor simulation example.\"            *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");

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
*  Find the first MIL-STD-1553 core with level M, C or D capability.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (channum=0;channum<MAX_CHANNELS;channum++)
		{
			if ( BTI1553_ChGetInfo(INFO1553_MULTIMODE,channum,hCore) ) break;
		}

		if (channum != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || channum == MAX_CHANNELS)
	{
		printf("\nError:  No MIL-STD-1553 level M, C or D channels present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing MIL-STD-1553 core #%d",corenum);
	printf("\nUsing MIL-STD-1553 channel #%d",channum);
	printf("\n");

/**
*
*  Configure the channel for bus controller mode.
*
**/

	BTICard_CardReset(hCore);									/*Reset the core*/

	errval = BTI1553_BCConfig(BCCFG1553_DEFAULT,channum,hCore);	/*Configure the core*/

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring for",errval);
		printf("\n        bus controller mode on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Create a bus controller message and insert into the bus
*  controller schedule.
*
**/

	BCMsg = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT,0x0843,0,BCData,hCore);

	BTI1553_BCSchedFrame(FRAMETIME,channum,hCore);
	BTI1553_BCSchedMsg(BCMsg,channum,hCore);

/**
*
*  Configure the channel for remote terminal mode as shown in
*  Example 3.
*
**/

	errval = BTI1553_RTConfig(RTCFG1553_DEFAULT,1,channum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring for",errval);
		printf("\n        remote terminal mode on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Get the message address for a receive subaddress.
*
**/

	RTMsg = BTI1553_RTGetMsg(SUBADDRESS,1,RCV,2,channum,hCore);

/**
*
*  Configure the channel for monitor mode as shown in Example 4.
*
**/

	errval = BTI1553_MonConfig(MONCFG1553_DEFAULT,channum,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring for",errval);
		printf("\n        monitor mode on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	errval = BTI1553_MonFilterTA(0x00000002,channum,hCore);	/*Monitor RT address 1*/

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring the",errval);
		printf("\n        monitor filter on channel #%d on core #%d.",channum,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure the sequential record.
*
**/

	errval = BTICard_SeqConfig(SEQCFG_DEFAULT,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring the",errval);
		printf("\n        sequential record on on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Start the card to begin transmitting, receiving and monitoring messages.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit....\n\n");

	while (!kbhit())
	{
		printf("\r");

		BCData[0] += 2;		/*Update the data that the BC is transmitting*/
		BCData[1] += 4;
		BCData[2] += 6;

		printf("Transmitting data {%04XH, %04XH, %04XH} ",BCData[0],BCData[1],BCData[2]);

		BTI1553_MsgDataWr(BCData,3,BCMsg,hCore);

		BTI1553_MsgDataRd(RTData,3,RTMsg,hCore);	/*Read the data received by the RT*/

		printf("Received data {%04XH, %04XH, %04XH} ",RTData[0],RTData[1],RTData[2]);
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
