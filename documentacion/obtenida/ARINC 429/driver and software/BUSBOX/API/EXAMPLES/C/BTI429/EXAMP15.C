
/**
*
*  BTI429 DRIVER EXAMPLE 15  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP15.C -- Print a transmit schedule
*
**/

/**
*
*  This program opens Card Number 0 and configures the
*  first compatible core to build a transmit schedule
*  using transmit interval information, and then prints
*  the schedule to the screen.
*
**/

#include "BTICard.h"
#include "BTI429.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32


/**
*
*  This helper function decodes a command block and
*  prints the details.
*
**/

VOID BTI429_SchedDump(USHORT cmdblk[],HCARD handleval)
{
	MSGADDR      msgaddr;
	MSGFIELDS429 msgfields;

	enum
	{
		OPCODE429_NOP,					//Halt
		OPCODE429_MSG,					//Message
		OPCODE429_GAP,					//Gap
		OPCODE429_LIST,					//Conditional Gap - do list buffer
		OPCODE429_HALT,					//Halt
		OPCODE429_USER,					//User code
		OPCODE429_PULSE0,				//Clear DOUT
		OPCODE429_PULSE1,				//Set DOUT
		OPCODE429_PAUSE,				//Pause
		OPCODE429_RESTART,				//Restart
		OPCODE429_LOGCOND,				//Log event on condition
		OPCODE429_CALLCOND,				//Call conditional
		OPCODE429_RETURN,				//Return from call
		OPCODE429_BRANCHCOND			//Branch on condition
	};

	if ((cmdblk[0] & 0xFF) > OPCODE429_BRANCHCOND) return;

	switch(cmdblk[0] & 0xFF)
	{
		case OPCODE429_NOP:            printf("%-14s ","NOP");         break;	//Nothing
		case OPCODE429_MSG:            printf("%-14s ","MSG");         break;	//Message
		case OPCODE429_GAP:            printf("%-14s ","GAP");         break;	//Gap
		case OPCODE429_LIST:           printf("%-14s ","LIST");        break;	//List
		case OPCODE429_HALT:           printf("%-14s ","HALT");        break;	//Halt
		case OPCODE429_USER:           printf("%-14s ","USER");        break;	//Pause
		case OPCODE429_PULSE0:         printf("%-14s ","PULSE0");      break;	//Clear DIO
		case OPCODE429_PULSE1:         printf("%-14s ","PULSE1");      break;	//Set DIO
		case OPCODE429_PAUSE:          printf("%-14s ","PAUSE");       break;	//Pause
		case OPCODE429_RESTART:        printf("%-14s ","RESTART");     break;	//Restart
		case OPCODE429_LOGCOND:        printf("%-14s ","LOGCOND");     break;	//Event log conditional
		case OPCODE429_CALLCOND:       printf("%-14s ","CALLCOND");    break;	//Call conditional
		case OPCODE429_RETURN:         printf("%-14s ","RETURN");      break;	//Return from call
		case OPCODE429_BRANCHCOND:     printf("%-14s ","BRANCHCOND");  break;	//Branch conditional
			break;
	}

	if (cmdblk[0] & 0x4000) printf("			 ");
	if (cmdblk[0] & 0x2000) printf("SHOT ");

	switch(cmdblk[0] & 0xFF)
	{
		case OPCODE429_MSG:
		{
			printf("msgaddr=%04X%04X gap=%04X",cmdblk[1],cmdblk[2],cmdblk[3]);
			msgaddr = BTICard_MakeLong(cmdblk[1],cmdblk[2]);
			BTI429_MsgBlockRd(&msgfields,msgaddr,handleval);
			printf(" data=%08X opt=%04X",msgfields.msgdata,msgfields.msgopt);
			break;
		}
		case OPCODE429_GAP:        printf("gap=%04X",cmdblk[1]); break;
		case OPCODE429_LIST:       printf("gap=%04X listaddr=%04X%04X ",cmdblk[1],cmdblk[6],cmdblk[7]); break;
		case OPCODE429_CALLCOND:   printf("dest=%04X ",cmdblk[7]); break;
		case OPCODE429_BRANCHCOND: printf("dest=%04X ",cmdblk[7]); break;
	}

	printf("\n");
}

/**
*
*  This helper function loops through all command blocks
*  in a channels schedule and sends them to the
*  BTI429_SchedDump(...) function to be decoded
*
**/

VOID BTI429_SchedDumpAll(INT channum,HCARD handleval)
{
	enum {CMDSIZE=8};			//Size of a command block

	INT j;
	USHORT cmdblk[CMDSIZE];

	INT cmdcount = BTI429_CmdCountRd(channum,handleval);

	printf("\n");

	for (j=0;j<=cmdcount;++j)
	{
		BTI429_CmdRd(cmdblk,BTI429_CmdAddr(j,channum,handleval),handleval);
		BTI429_SchedDump(cmdblk,handleval);
	}
}


void main(void)
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT corenum;
	INT xmtchan;
	MSGSTRUCT429 comp_airspeed, tot_air_temp, altitude_rate;
	MSGADDR msgaddr[3];
	INT	min_intrvls[3];
	INT	max_intrvls[3];

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP15  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI429 Example 15                                                 *");
	printf("\n    *  \"Print a transmit schedule\"                                       *");
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

	printf("\nUsing ARINC 429 card #%d",CARDNUM);

/**
*
*  Find the first 429 core with a transmit channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (BTI429_ChIsXmt(xmtchan,hCore))	break;

		if (xmtchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 429 transmit channels present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 429 core #%d",corenum);
	printf("\nUsing transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure xmtchan to transmit at high speed.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI429_ChConfig(CHCFG429_HIGHSPEED,xmtchan,hCore);

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
*  Create a message for each of the labels we are transmitting.
*
**/

	comp_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT,hCore);
	tot_air_temp.addr  = BTI429_MsgCreate(MSGCRT429_DEFAULT,hCore);
	altitude_rate.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT,hCore);

/**
*
*  Set up the arrays of message addresses; and intervals
*  needed to build the schedule.  Note that the nth element
*  in each array correspond to each other.
*
**/

	msgaddr[0] = comp_airspeed.addr;
	min_intrvls[0] = 250;
	max_intrvls[0] = 500;

	msgaddr[1] = tot_air_temp.addr;
	min_intrvls[1] = 250;
	max_intrvls[1] = 500;

	msgaddr[2] = altitude_rate.addr;
	min_intrvls[2] = 100;
	max_intrvls[2] = 200;

/**
*
*  Next, build a schedule using the minimum and maximum
*  transmit intervals.
*
**/

	errval = BTI429_SchedBuild(3,msgaddr,min_intrvls,max_intrvls,xmtchan,hCore);

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
*  Output the results of the Schedule Build operation
*
**/

	printf("\nARINC 429 schedule for channel #%d",xmtchan);
	printf("\n");
	printf("\nBEGIN");

	BTI429_SchedDumpAll(xmtchan,hCore);

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardClose(hCard);
}
