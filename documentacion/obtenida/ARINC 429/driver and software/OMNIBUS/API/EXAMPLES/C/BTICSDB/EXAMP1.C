
/**
*
*  BTICSDB DRIVER EXAMPLE 1  (06/09/2011)
*  Copyright (c) 2005-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Transmitter example
*
**/

/**
*
*  This program opens Card Number 0; and configures the
*  first compatible core to build a transmit schedule
*  using transmit frame rate information, and then transmits
*  the messages. The user triggers burst messages.
*
**/

#include "BTICard.H"
#include "BTICSDB.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		     0
#define	MAX_CORES        4
#define	MAX_CHANNELS    32

#define BLOCKSPERFRAME  18
#define BYTESPERBLOCK    6
#define FRAMESPERSECOND 10

void main(void)
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT corenum;
	INT xmtchan;
	MSGADDR msgaddr[3];
	INT	freq[3];
	BYTE bufcont[BYTESPERBLOCK];
	BYTE data = 0;
	BOOL done = 0;
	INT input;


	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP1  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2005-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICSDB Example 1                                                 *");
	printf("\n    *  \"Program for transmitter example.\"                                *");
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
*  Find the first CSDB core with a transmit channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (BTICSDB_ChIsXmt(xmtchan,hCore))	break;

		if (xmtchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	{
		printf("\nError:  No CSDB transmit channels present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing CSDB core #%d",corenum);
	printf("\nUsing transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure xmtchan to transmit at low speed.
*
**/

	BTICard_CardReset(hCore);

	errval = BTICSDB_ChConfig(CHCFGCSDB_DEFAULT,BITRATECSDB_LOWSPEED,BYTESPERBLOCK,FRAMESPERSECOND,BLOCKSPERFRAME,xmtchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Create a message for each of the addresses we are transmitting.
*
**/

	msgaddr[0] = BTICSDB_MsgCreate(MSGCRTCSDB_DEFAULT | MSGCRTCSDB_WIPESYNC,hCore);	/*create sync message*/
	msgaddr[1] = BTICSDB_MsgCreate(MSGCRTCSDB_DEFAULT,hCore);							/*create continuous message*/
	msgaddr[2] = BTICSDB_MsgCreate(MSGCRTCSDB_DEFAULT | MSGCRTCSDB_BURST,hCore);		/*create burst message*/

/**
*
*  Set up the frame rates needed to build the schedule.
*  freq = (Bus Frames/Second) / (Message Updates/Second)
*
**/

	freq[0] = 1;	/*sync message is every frame*/
	freq[1] = 2;	/*every other frame*/
	freq[2] = 1;	/*every frame*/

/**
*
*  Next, build a schedule using the messages and frequencies
*  specified.
*
**/

	errval = BTICSDB_SchedBuild(3,msgaddr,freq,0,0,xmtchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while building",errval);
		printf("\n        a schedule on channel #%d of core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Initialize the Message Records.
*
**/

	//continuous message
	bufcont[0] = 0x12;	/*address byte*/
	bufcont[1] = 0x80;	/*status byte*/
	bufcont[2] = 0x00;	/*data = 121.1MHz*/
	bufcont[3] = 0x10;	/* "" */
	bufcont[4] = 0x21;	/* "" */
	bufcont[5] = 0x00;	/*pad*/
	BTICSDB_MsgDataWr(bufcont,BYTESPERBLOCK,msgaddr[1],hCore);


	//burst message
	BTICSDB_MsgDataByteWr(0x31,0,msgaddr[2],hCore);	/*address byte*/
	BTICSDB_MsgDataByteWr(0xB1,1,msgaddr[2],hCore);	/*status byte*/
	BTICSDB_MsgDataByteWr(0x90,3,msgaddr[2],hCore); /*tune = 118.9MHz*/
	BTICSDB_MsgDataByteWr(0x18,4,msgaddr[2],hCore);	/* "" */


/**
*
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Trigger burst message when a key is pressed.
*
**/

	printf("\nPress any key to trigger burst, escape to exit....\n\n");

	while(!done)
	{
		if (kbhit())
		{
			input = getch();
			if (input == 0x1B)
			{
				done = 1;
			}
			else
			{
				if (BTICSDB_MsgDataByteRd(1,msgaddr[2],hCore) & 0x80)
				{
					BTICSDB_MsgDataByteWr(0x31,1,msgaddr[2],hCore);	/*clear valid bit*/
				}
				else
				{
					BTICSDB_MsgDataByteWr(0xB1,1,msgaddr[2],hCore);	/*set valid bit*/
				}

				BTICSDB_MsgValidSet(msgaddr[2],hCore);					/*set message as valid for transmit*/
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
