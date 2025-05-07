
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include "p42w32.h"

INT minperiod1[6] = {48,18,18,18,18,18};
INT maxperiod1[6] = {52,22,22,22,22,22};

INT minperiod2[3] = {498,498,498};
INT maxperiod2[3] = {502,502,502};

INT minperiod3[2] = {60,60};
INT maxperiod3[2] = {64,64};

/**
*
*   PC429-1/2 SCHEDULE BUILD SAMPLE PROGRAM  Version 1.0  (03/31/1999)
*   Copyright (c) 1996-1999
*   Ballard Technology, Inc.
*   www.ballardtech.com
*   support@ballardtech.com
*   ALL RIGHTS RESERVED
*
*   NAME:   DEMO5.C -- Schedule Built Sample Program.
*
**/

/**
*
*   This file is the source code for a sample program that
*   demonstrates the PC429_SchedBuild() function.
*
*   To compile this program with the Microsoft C compiler,
*   use the following command line:
*
*   CL DEMO5.C P42W32.LIB
*
*   To compile this program with the Turbo C compiler, use
*   the following command line:
*
*   BCC32 DEMO5.C P42W32.LIB
*
**/

VOID main(VOID)
{
	INT j;
	ERRVAL errval;
	HCARD handleval;

	fprintf(stderr,"DEMO5  Version 1.0  (03/31/1999)\n");
	fprintf(stderr,"Copyright 1996-1999  Ballard Technology, Inc.  Everett, WA, USA.\n");
	fprintf(stderr,"All rights reserved.\n");
	fprintf(stderr,"Go to www.ballardtech.com or email support@ballardtech.com\n\n");

/**
*
*   The following statement checks for the presence of a
*   PC429 card.
*
**/

	handleval = PC429_Check(0xCE00,0x250,2,1);

	if (handleval<0)			/*Check for card*/
	{
		printf("No PC429 card at segment CE00H and port 250H (%i).\n",handleval);
		exit(1);
	}

/**
*
*   The following statement checks for the correct configuration of
*   the PC429 card.
*
**/

	if (!PC429_IsRcv(CH0,handleval)  ||
		!PC429_IsXmit(CH1,handleval) ||
		!PC429_IsXmit(CH2,handleval) ||
		!PC429_IsXmit(CH3,handleval))
	{
		printf("Channel 1 is not a transmit channel, and/or channel 0 is not a receive channel.\n");
		exit(1);
	}

/**
*
*   The following statements clears the card of messages and
*   filters and then inserts the first transmit message.
*
**/

	PC429_Stop(handleval);									/*Stop image*/

	PC429_ClrMsgFilt(handleval);							/*Clear msgs and filt*/

/**
*
*   The following statement builds the transmission schedule. 
*   The schedule contains 5 messages, each transmitted at low
*   speed.  The minimum and maximum periods are specified in
*   separate integer arrays.  If an error occurs, a negative
*   value is returned.  Refer to the header file for the
*   meaning of the error value.
*
**/

	errval = PC429_SchedBuild(6,minperiod1,maxperiod1,1,CH1,handleval);

	if (errval<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while building the schedule.",errval);
		exit(1);
	}

	errval = PC429_SchedBuild(3,minperiod2,maxperiod2,1,CH2,handleval);

	if (errval<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while building the schedule.",errval);
		exit(1);
	}

	errval = PC429_SchedBuild(2,minperiod3,maxperiod3,0,CH3,handleval);

	if (errval<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while building the schedule.",errval);
		exit(1);
	}

/**
*
*  The following loop prints the addresses of the messages
*  being transmitted in the schedule.  This is the same kind
*  of address that is returned by PC429_NameToAddr() and
*  PC429_InsMsg().  Note that the addresses are taken from
*  the array PC429_SchedBuildAddr[].  This array is filled by
*  PC429_SchedBuild() to allow you to save the addresses of
*  the messages so you can update them.
*
**/

	for (j=0;j<5;++j)
	{
		PC429_WrMsg(PC429_SchedBuildAddr[j],j,handleval);
		printf("\nindex=%2u msg=%08lX",j,PC429_SchedBuildAddr[j]);
	}

/**
*
*  The following loop walks through the schedule for the
*  transmit channel and displays each message and gap pair.
*
**/

	for (j=0;j<PC429_GetMsgCnt(CH1,handleval);++j)
	{
		printf("\nindex=%2u msg=%08lX gap=%08lX",j,PC429_GetMsg(j,CH1,handleval),PC429_GetGap(j,CH1,handleval));
	}

	for (j=0;j<PC429_GetMsgCnt(CH2,handleval);++j)
	{
		printf("\nindex=%2u msg=%08lX gap=%08lX",j,PC429_GetMsg(j,CH2,handleval),PC429_GetGap(j,CH2,handleval));
	}

	for (j=0;j<PC429_GetMsgCnt(CH3,handleval);++j)
	{
		printf("\nindex=%2u msg=%08lX gap=%08lX",j,PC429_GetMsg(j,CH3,handleval),PC429_GetGap(j,CH3,handleval));
	}

/**
*
*   The following statements configure the PC429 card.
*
**/

	PC429_Active(CH3 | CH2 | CH1 | CH0,handleval);		/*Both channels active*/
	PC429_HighSpeed(CHNONE,handleval);					/*Both channels low speed*/

/**
*
*   The following starts the operation of the card.
*
**/

	PC429_Start(handleval);						/*Start image*/

/**
*
*   The following wait for a key to be pressed.
*
**/

	printf("\nPress any key to exit....");

	while(!kbhit());									/*Until key pressed*/

/**
*
*   The following statement stops the card.
*
**/

	PC429_Stop(handleval);			/*Stop image*/
}
