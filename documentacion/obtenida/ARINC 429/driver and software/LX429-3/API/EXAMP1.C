
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 1  Version 1.0  (10/29/2001)
*  Copyright (c) 1998-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Example 1 from Section 3.4.
*                      "Program for receiver example"
*
**/

/**
*
*  This program opens the L43 card number 0, and
*  configures the first receive channel to receive 2 GPS messages into 
*  separate Message Records, and receive all other messages into a
*  default Message Record.
*
**/

#include "l43w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0                               /*Card number of L43 card*/

void main(void)
{
	HCARD Card;                                 /*Handle of L43 card*/
	ERRVAL errval;                              /*Error return value*/
	INT rcvchan;                                /*Channel number*/
	MSGSTRUCT msgdefault, latitude, longitude;  /*Messages*/

	fprintf(stderr,"\nEXAMP1  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1998-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 1");
	fprintf(stderr,"\n\"Program for receiver example.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);					/*Open the L43 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L43 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Find the first receive channel.
*
**/

	for (rcvchan=0;rcvchan<8;++rcvchan) if (L43_IsRcvChan(rcvchan,Card)) break;
	if (rcvchan == 8)
	{
		printf("\nError:  No receive channels present in L43 cardnum %d.",CARDNUM);
		printf("\n");
		exit(1);
	}

	fprintf(stderr,"\nUsing receive channel %d",rcvchan);
	fprintf(stderr,"\n");

/**
*
*  Configure receiver channel for auto speed detection.
*
**/

	L43_CardReset(Card);                                  /*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG_AUTOSPEED,rcvchan,Card);  /*Configure channel*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,rcvchan);
		printf("\n");
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Before any messages can be received, filters must be set
*  for the receive channel.  First, the default filter is
*  created.  Then, two filters are set for the two messages
*  of interest.
*
**/

	msgdefault.addr = L43_FilterDefault(MSGCRT_DEFAULT,rcvchan,Card); 
	latitude.addr   = L43_FilterSet(MSGCRT_DEFAULT,0310,SDIALL,rcvchan,Card);
	longitude.addr  = L43_FilterSet(MSGCRT_DEFAULT,0311,SDIALL,rcvchan,Card);

/**
*
*  Start operation of the card.
*
**/

	L43_CardStart(Card);

/**
*
*  Display data on the screen.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{                                               /*Read message records*/
		msgdefault.data = L43_MsgDataRd(msgdefault.addr,Card);
		latitude.data   = L43_MsgDataRd(latitude.addr,Card);
		longitude.data  = L43_MsgDataRd(longitude.addr,Card);

		printf("\r");                               /*Display values*/
		printf("Default=%08lX ",msgdefault.data);
		printf("Latitude=%08lX ",latitude.data);
		printf("Longitude=%08lX",longitude.data);
	}

/**
*
*  Stop the L43 card.
*
**/

	L43_CardStop(Card);

/**
*
*  The L43 card MUST be closed before exiting the program.
*
**/

	L43_CardClose(Card);

}
