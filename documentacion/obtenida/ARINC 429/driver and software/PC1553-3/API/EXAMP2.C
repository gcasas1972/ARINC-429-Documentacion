
/**
*
*  PC1553-3 DRIVER EXAMPLE 2  Version 1.0  (02/20/1998)
*  Copyright (c) 1998
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- Example 2 from Section 4.2.
*                      "Simulating the BC - Scheduled Messages"
*
**/

/**
*
*  This example configures the PC1553-3 as a bus controller
*  to transmit a schedule of three messages.  The schedule is
*  created in such a way that the messages are transmitted at
*  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
*  and 40ms, respectively).
*
*  The program watches the 'hit' bit associated with the 0842H
*  BC-RT message.  When the message is transmitted and the
*  bit is set, the program updates the data words.
*
**/

#include "p13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	MEMBASE 0xCC00				/*Memory address of PC1553-3 card*/
#define IOBASE  0x2C0				/*I/O address of PC1553-3 card*/
#define	IRQCHAN 2					/*Interrupt channel of PC1553-3 card*/
#define	DMACHAN 1					/*DMA channel of PC1553-3 card*/

#define CMD0		0x0843			/*Command word for first message*/
#define CMD1		0x0821			/*Command word for second message*/
#define RCV_CMD2	0x0821			/*Receive command of an RT-RT transfer*/
#define XMT_CMD2	0x1C21			/*Transmit command of an RT-RT transfer*/

#define	FRAMETIME	10000			/*Frame time in microseconds*/

void main(void)
{
	HCARD   Card;
	ERRVAL  errval;
	MSGADDR BCMsgs[3];
	USHORT  MsgErrors;
	USHORT  Data[3] = {0,0,0};

	fprintf(stderr,"\nEXAMP2  Version 1.0  (02/20/1998)");
	fprintf(stderr,"\nCopyright 1998  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC1553-3 Example 2");
	fprintf(stderr,"\n\"Simulating the BC - Scheduled Messages\"");
	fprintf(stderr,"\n");

/**
*
*  Open the PC1553-3 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = P13_CardOpen(MEMBASE,IOBASE,IRQCHAN,DMACHAN);	/*Open the PC1553-3 card*/

	if (Card < 0)
	{
		printf("\nError:  Either a PC1553-3 is not present at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for bus controller mode.
*
**/

	P13_CardReset(Card);							/*Reset the PC1553-3 card*/

	errval = P13_BCConfig(BCCFG_DEFAULT,Card);		/*Configure the PC1553-3 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for bus controller mode.",errval);
		P13_CardClose(Card);
		exit(1);
	}

/**
*
*  Create the message records for each of the three messages.
*
**/

	BCMsgs[0] = P13_BCCreateMsg(MSGCRT_DEFAULT,     CMD0,        0, Data, Card);
	BCMsgs[1] = P13_BCCreateMsg(MSGCRT_DEFAULT,     CMD1,        0, NULL, Card);
	BCMsgs[2] = P13_BCCreateMsg(MSGCRT_RTRT,    RCV_CMD2, XMT_CMD2, NULL, Card);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	P13_BCSchedFrame(FRAMETIME, Card);
	P13_BCSchedMsg(BCMsgs[0],   Card);
	P13_BCSchedMsg(BCMsgs[1],   Card);
	P13_BCSchedMsg(BCMsgs[2],   Card);

	P13_BCSchedFrame(FRAMETIME, Card);
	P13_BCSchedMsg(BCMsgs[0],   Card);

	P13_BCSchedFrame(FRAMETIME, Card);
	P13_BCSchedMsg(BCMsgs[0],   Card);
	P13_BCSchedMsg(BCMsgs[1],   Card);

	P13_BCSchedFrame(FRAMETIME, Card);
	P13_BCSchedMsg(BCMsgs[0],   Card);

/**
*
*  Start the card to begin transmissions.
*
**/

	P13_CardStart(Card);

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

		MsgErrors = P13_MsgFieldRd(FIELD_ERROR, BCMsgs[0], Card);

		if (MsgErrors & MSGERR_HIT)
		{
			Data[0] += 2;									/*Calculate the new data words*/
			Data[1] += 4;
			Data[2] += 6;

			P13_MsgDataWr(Data, 3, BCMsgs[0], Card);		/*Write the new data words*/

			P13_MsgFieldWr(0,FIELD_ERROR,BCMsgs[0],Card);	/*Clear the 'hit' bit*/

			printf("\rTransmitting data {%04XH, %04XH, %04XH}",Data[0],Data[1],Data[2]);
		}
	}

/**
*
*  The PC1553-3 card MUST be closed before exiting the program.
*
**/

	P13_CardStop(Card);						/*Stop the card*/
	P13_CardClose(Card);					/*Close the card*/
}
