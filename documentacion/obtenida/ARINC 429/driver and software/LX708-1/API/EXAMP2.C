
/**
*
*  LP708-1 and LC708-1 DRIVER EXAMPLE 2  Version 1.0  (01/19/2001)
*  Copyright (c) 1999-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP2.C -- Example 2.
*                      "Transmitter Polling example"
*
**/

/**
*
*  This example configures the L71 to transmit a schedule
*  of four messages at a rate of 50Hz.  The messages are
*  automatically assigned the numbers 0 through 3.
*
*  An interrupt frequency of 2 messages is also specified. 
*  As a result, message 1 and message 3 generate interrupt an
*  interrupt after they are transmitted, but message 0 and
*  message 2 do not.
*
*  No interrupt handler is installed.  Instead, the program
*  polls the interrupt log list to see if an entry is
*  present.  If so, it reads the entry from the interrupt log
*  list containing the number of the message that caused the
*  interrupt.
*  
*  When the interrupt for message 1 is received, both message
*  0 and message 1 are updated.  When the interrupt for
*  message 3 is received, both message 2 and message 3 are
*  updated.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

#include "l71w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0                   /*Card number of L71 card*/

#define	FRAMEFREQ	50              /*Frame frequency of 50Hz*/
#define INTFREQ		2               /*Generate an interrupt after every 2nd message*/
#define	FRAMECOUNT	4               /*Transmit a total of 4 messages*/

USHORT Data0[100];                  /*Data to transmit for message 0*/
USHORT Data1[100];                  /*Data to transmit for message 1*/
USHORT Data2[100];                  /*Data to transmit for message 2*/
USHORT Data3[100];                  /*Data to transmit for message 3*/

void main(void)
{
	HCARD Card;
	USHORT  framenum;
	ERRVAL  errval;
	USHORT  MsgErrors;
	USHORT  j;

	fprintf(stderr,"\nEXAMP2  Version 1.0  (01/19/2001)");
	fprintf(stderr,"\nCopyright 1999-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP708-1 and LC708-1 Example 2");
	fprintf(stderr,"\n\"Transmitter Polling example\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L71 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L71_CardOpen(CARDNUM);                     /*Open the L71 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L71 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

	L71_CardReset(Card);

/**
*
*  Configure the transmitter of the L71 card.
*
**/

	errval = L71_XmtConfigEx(FRAMEFREQ,INTFREQ,FRAMECOUNT,Card);   /*Configure the L71 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the transmitter.",errval);
		L71_CardClose(Card);
		exit(1);
	}

/**
*
*  Create the data for the three messages.
*
**/

	for (j=0;j<100;++j)
	{
		Data0[j]=0;                 /*Create data for message 0*/
		Data1[j]=1;                 /*Create data for message 1*/
		Data2[j]=2;                 /*Create data for message 2*/
		Data3[j]=3;                 /*Create data for message 2*/
	}

/**
*
*  Write the data for the three messages.
*
**/

	L71_XmtWr(Data0,0,Card);        /*Write the data for message 0*/
	L71_XmtWr(Data1,1,Card);        /*Write the data for message 1*/
	L71_XmtWr(Data2,2,Card);        /*Write the data for message 2*/
	L71_XmtWr(Data3,3,Card);        /*Write the data for message 3*/

/**
*
*  Start the card to begin transmissions.
*
**/

	L71_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");
	
	while (!_kbhit())
	{

/**
*
*  Poll the interrupt log list until it contains an entry. 
*  The entry contains the number of the message that caused
*  the interrupt.  When we receive the interrupt from message
*  1, we will update the data for both message 0 and message
*  1.  When we receive the interrupt from message 3, we will
*  update the data for both message 2 and message 3.
*
**/

		if(L71_IntStatus(Card) != STAT_EMPTY)
		{
			L71_IntRd(NULL,&framenum,Card);

			if (framenum==1)
			{
				L71_XmtRd(Data0,0,Card);        /*Read data for message 0*/
				L71_XmtRd(Data1,1,Card);        /*Read data for message 1*/

				for (j=0;j<100;++j)
				{
					Data0[j]+=4;                /*Modify the data for message 0*/
					Data1[j]+=4;                /*Modify the data for message 1*/
				}

				L71_XmtWr(Data0,0,Card);        /*Write the data for message 0*/
				L71_XmtWr(Data1,1,Card);        /*Write the data for message 1*/

				printf("\nUpdated message 0 and 1");
			}

			if (framenum==3)
			{
				L71_XmtRd(Data2,2,Card);        /*Read data for message 2*/
				L71_XmtRd(Data3,3,Card);        /*Read data for message 3*/

				for (j=0;j<100;++j)
				{
					Data2[j]+=4;                /*Modify the data for message 2*/
					Data3[j]+=4;                /*Modify the data for message 3*/
				}

				L71_XmtWr(Data2,2,Card);        /*Write the data for message 2*/
				L71_XmtWr(Data3,3,Card);        /*Write the data for message 3*/

				printf("\nUpdated message 2 and 3");
			}
		}
	}

/**
*
*  Stop the card to halt transmissions.
*
**/

	L71_CardStop(Card);

/**
*
*  The L71 card MUST be closed before exiting the program.
*
**/

	L71_CardClose(Card);
}
