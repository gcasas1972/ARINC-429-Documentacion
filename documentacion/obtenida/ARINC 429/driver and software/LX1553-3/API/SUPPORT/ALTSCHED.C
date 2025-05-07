
/**
*
*  LP1553-3 and LC1553-3 DRIVER EXAMPLE 2  Version 1.0  (11/18/2002)
*  Copyright (c) 2002
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   ALTSCHED.C -- Modified Example 2 from Section 4.2.
*                        "Alternate schedules"
*
**/

/**
*
*  This example configures the L13 as a bus controller to
*  transmit two schedules each with three messages.  The
*  first schedule transmits the three messages on bus A, and
*  the second schedule transmits the three messages on bus B.
*
*  The schedules are built such that either the first one or the
*  second one is active at any one time.  Pressing a key
*  allows the user to switch between the schedules.
* 
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of L13 card*/

#define CMD0		0x0843			/*Command word for first message*/
#define CMD1		0x0821			/*Command word for second message*/
#define RCV_CMD2	0x0821			/*Receive command of an RT-RT transfer*/
#define XMT_CMD2	0x1C21			/*Transmit command of an RT-RT transfer*/

#define	FRAMETIME	1000000			//10000			/*Frame time in microseconds*/

void main(void)
{
	HCARD   Card;
	ERRVAL  errval;
	MSGADDR BCMsgs[6];
	USHORT  Data[3] = {0,0,0};
	SCHNDX  sched0,sched1;
	SCHNDX  calc_sched0,calc_sched1;
	BOOL    done;
	INT     ch;

	fprintf(stderr,"\nALTSCHED  Version 1.0  (11/18/2002)");
	fprintf(stderr,"\nCopyright 2002  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Example 2");
	fprintf(stderr,"\n\"Alternate schedules\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L13 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L13_CardOpen(CARDNUM);					/*Open the L13 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L13 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for bus controller mode.
*
**/

	L13_CardReset(Card);							/*Reset the L13 card*/

	errval = L13_BCConfig(BCCFG_DEFAULT,Card);		/*Configure the L13 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for bus controller mode.",errval);
		L13_CardClose(Card);
		exit(1);
	}

/**
*
*  Create the message records for each of the three messages
*  in each schedule
*
**/

	BCMsgs[0] = L13_BCCreateMsg(MSGCRT_BUSA,             CMD0,            0, Data, Card);
	BCMsgs[1] = L13_BCCreateMsg(MSGCRT_BUSA,             CMD1,            0, NULL, Card);
	BCMsgs[2] = L13_BCCreateMsg(MSGCRT_BUSA+MSGCRT_RTRT, RCV_CMD2, XMT_CMD2, NULL, Card);

	BCMsgs[3] = L13_BCCreateMsg(MSGCRT_BUSB,             CMD0,            0, Data, Card);
	BCMsgs[4] = L13_BCCreateMsg(MSGCRT_BUSB,             CMD1,            0, NULL, Card);
	BCMsgs[5] = L13_BCCreateMsg(MSGCRT_BUSB+MSGCRT_RTRT, RCV_CMD2, XMT_CMD2, NULL, Card);

/**
*
*  First, we have to predict where the top of each schedule
*  is.  Each BC schedule function returns the index of the
*  scheduled opcode.  We could go back and 'fixup' the
*  addresses, but changing the values below, and recompiling if
*  things change is a lot easier.
*
**/

	sched0 =  1;
	sched1 = 21;

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	calc_sched0 = L13_BCSchedFrame(FRAMETIME,  Card);
	              L13_BCSchedMsg(BCMsgs[0],    Card);
	              L13_BCSchedMsg(BCMsgs[1],    Card);
	              L13_BCSchedMsg(BCMsgs[2],    Card);
	              L13_BCSchedBranchDin1(sched1,Card);	//Branch if we are switching

	              L13_BCSchedFrame(FRAMETIME,  Card);
	              L13_BCSchedMsg(BCMsgs[0],    Card);
	              L13_BCSchedBranchDin1(sched1,Card);	//Branch if we are switching

	              L13_BCSchedFrame(FRAMETIME,  Card);
	              L13_BCSchedMsg(BCMsgs[0],    Card);
	              L13_BCSchedMsg(BCMsgs[1],    Card);
	              L13_BCSchedBranchDin1(sched1,Card);	//Branch if we are switching

	              L13_BCSchedFrame(FRAMETIME,  Card);
	              L13_BCSchedMsg(BCMsgs[0],    Card);
	              L13_BCSchedBranchDin1(sched1,Card);	//Branch if we are switching

	              L13_BCSchedGoto(sched0,      Card);	//Loop back to the top

	calc_sched1 = L13_BCSchedFrame(FRAMETIME,  Card);
	              L13_BCSchedMsg(BCMsgs[3],    Card);
	              L13_BCSchedMsg(BCMsgs[4],    Card);
	              L13_BCSchedMsg(BCMsgs[5],    Card);
	              L13_BCSchedBranchDin0(sched0,Card);	//Branch if we are switching

	              L13_BCSchedFrame(FRAMETIME,  Card);
	              L13_BCSchedMsg(BCMsgs[3],    Card);
	              L13_BCSchedBranchDin0(sched0,Card);	//Branch if we are switching

	              L13_BCSchedFrame(FRAMETIME,  Card);
	              L13_BCSchedMsg(BCMsgs[3],    Card);
	              L13_BCSchedMsg(BCMsgs[4],    Card);
	              L13_BCSchedBranchDin0(sched0,Card);	//Branch if we are switching

	              L13_BCSchedFrame(FRAMETIME,  Card);
	              L13_BCSchedMsg(BCMsgs[3],    Card);
	              L13_BCSchedBranchDin0(sched0,Card);	//Branch if we are switching

	              L13_BCSchedGoto(sched1,      Card);	//Loop back to the top

	if (sched0 != calc_sched0)
	{
		printf("\nError:  Bad schedule 0 index.  Predicted %d, but actually got %u.",sched0,calc_sched0);
		L13_CardClose(Card);
		exit(1);
	}

	if (sched1 != calc_sched1)
	{
		printf("\nError:  Bad schedule 1 index.  Predicted %d, but actually got %u.",sched1,calc_sched1);
		L13_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin transmissions.
*
**/

	L13_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress '0' to switch to schedule 0.");
	printf("\nPress '1' to switch to schedule 1.");
	printf("\nPress ESC to exit.");
	printf("\n");

	for (done=0;!done;)
	{

		if (kbhit())
		{
			ch = getch();

			if (ch==27)
			{
				done=1;
				break;
			}

			if (ch=='0')
			{
				printf("\nSwitching to schedule 0...");
				L13_ExtDinWr(0, Card);
			}

			if (ch=='1')
			{
				printf("\nSwitching to schedule 1...");
				L13_ExtDinWr(1, Card);
			}
		}
	}

/**
*
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardStop(Card);						/*Stop the card*/
	L13_CardClose(Card);					/*Close the card*/
}
