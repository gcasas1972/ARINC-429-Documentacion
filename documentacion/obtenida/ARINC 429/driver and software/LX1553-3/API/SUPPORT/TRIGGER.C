
/**
*
*  LP1553-3 and LC1553-3 DRIVER TRIGGER EXAMPLE  Version 1.0  (10/29/2001)
*  Copyright (c) 1997-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- Trigger Example
*
**/

/**
*
*  This example configures the L13 as a bus controller
*  to transmit a schedule of three messages.  The two receive messages 
*  are scheduled in a single frame.  The RT-RT transfer is scheduled for
*  transmission after a falling edge is detected on the external trigger
*  input pin.  Refer to the appendix of the Lx1553-3 User's Manual on the
*  location of the external trigger input pin.
*
*  The program watches the 'hit' bit associated with the 0842H
*  BC-RT message.  When the message is transmitted and the
*  bit is set, the program updates the data words.
*
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of L13 card*/

#define CMD0		0x0843			/*Command word for first message*/
#define CMD1		0x0822			/*Command word for second message*/
#define RCV_CMD2	0x0821			/*Receive command of an RT-RT transfer*/
#define XMT_CMD2	0x1C21			/*Transmit command of an RT-RT transfer*/

#define	FRAMETIME	10000			/*Frame time in microseconds*/

USHORT usercode[5] =
{
	0xAE5C,		//SPLK #0001H,5CH   ;Write value to temp location
	0x0001,
	0x0C5C,		//OUT  5CH,02C42H   ;Write value at temp location to IO register
	0x2C42,
	0xEF00		//RET               ;Return from subroutine
};

void main(void)
{
	HCARD   Card;
	ERRVAL  errval;
	MSGADDR BCMsgs[3];
	USHORT  MsgErrors;
	USHORT  Data[3] = {0,0,0};
	SCHNDX  schndx1;
	SCHNDX  schndx2;
	USHORT tempval;
	USHORT userlength;		//Length of user code in words
	USHORT useraddr;		//Address of user code
	INT j;

	fprintf(stderr,"\nTRIGGER EXAMPLE  Version 1.0  (06/20/2002)");
	fprintf(stderr,"\nCopyright 2002  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Trigger Example");
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
*  Enable the external trigger input to the card, but into a mode where
*  is simply detects the falling edge on the external trigger input and
*  latches it into a flag that the schedule can use to perform conditional
*  branches.
*
**/

	tempval  = L13_PortRd(IREG_CONFIG,Card);	//Read host configuration register
	tempval |= 0x03;							//Enable external trigger
	L13_PortWr(tempval,IREG_CONFIG,Card);		//Enable external trigger

/**
*
*  Load the user code into a safe location in memory.  This user code, when called
*  from the schedule, clears the flag that is set by the external trigger logic.
*
**/

	userlength = sizeof(usercode)/sizeof(usercode[0]);
	useraddr   = 0x7F00 - userlength;

	for (j=0;j<userlength;++j)
	{
		L13_ProgWrW(usercode[j],useraddr+j,Card);
	}

/**
*
*  Create the message records for each of the three messages.
*
**/

	BCMsgs[0] = L13_BCCreateMsg(MSGCRT_DEFAULT,     CMD0,        0, Data, Card);
	BCMsgs[1] = L13_BCCreateMsg(MSGCRT_DEFAULT,     CMD1,        0, NULL, Card);
	BCMsgs[2] = L13_BCCreateMsg(MSGCRT_RTRT,    RCV_CMD2, XMT_CMD2, NULL, Card);

/**
*
*  Schedule the first subroutine.  This subroutine is branched to when
*  the falling edge of the external trigger is latched.  The RT-RT
*  message is transmitted, and the user code is called to clear the latch.
*  Note that if another external trigger is detected and latched before
*  the previous latch is cleared, the second latch is missed.
*
**/

	schndx1 = L13_BCSchedMsg(BCMsgs[2],   Card);
	L13_BCSchedUser(useraddr, Card);
	L13_BCSchedReturn(Card);

/**
*
*  Schedule the second subroutine.  This subroutine should be called after every message.
*
**/

	schndx2 = L13_BCSchedBranchDin1(schndx1, Card);
	L13_BCSchedReturn(Card);

/**
*
*  Schedule the messages that run in the main schedule.  Notice BCSchedEntry() is called
*  to set the location of the start of the schedule.  This prevents the subroutines from
*  being called on start.
*
*  When the schedule encounters the start of a new frame, the card will wait until the previous
*  frame time has counted down.  This prevents the external trigger from being polled.  If
*  an external trigger were to occur during this waiting period, then the subroutine to service
*  the latch will also have to wait.  This will introduce a large delay between the external trigger,
*  and the transmission of messages in the conditional subroutine.  Be sure to avoid very long frame times.
*
**/

	L13_BCSchedEntry(Card);
	L13_BCSchedFrame(FRAMETIME,   Card);

	L13_BCSchedMsg(BCMsgs[0],     Card);
	L13_BCSchedCall(schndx2,      Card);

	L13_BCSchedMsg(BCMsgs[1],     Card);
	L13_BCSchedCall(schndx2,      Card);

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

	printf("\nPress any key to exit.");
	printf("\n");

	while (!kbhit())
	{

/**
*
*  Watch the 'hit' bit of the first message to see if it has
*  been transmitted.  If it has, update the data words.
*
**/

		MsgErrors = L13_MsgFieldRd(FIELD_ERROR, BCMsgs[0], Card);

		if (MsgErrors & MSGERR_HIT)
		{
			Data[0] += 2;									/*Calculate the new data words*/
			Data[1] += 4;
			Data[2] += 6;

			L13_MsgDataWr(Data, 3, BCMsgs[0], Card);		/*Write the new data words*/

			L13_MsgFieldWr(0,FIELD_ERROR,BCMsgs[0],Card);	/*Clear the 'hit' bit*/

			printf("\rTransmitting data {%04XH, %04XH, %04XH}",Data[0],Data[1],Data[2]);
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
