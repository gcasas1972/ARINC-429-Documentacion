
#include "c41w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM429-1 DRIVER EXAMPLE 1  Version 1.0  (05/26/1999)
*  Copyright (c) 1999
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
*  This program opens the CM429-1 card in socket 0, and
*  configures RCH0 to receive 2 GPS messages into separate
*  Message Records, and receive all other messages into the
*  Default Record.
*
**/

#define POS_LAT          6		/*Message Record for Present Pos-Latitude*/
#define POS_LONG        20		/*Message Record for Present Pos-Longitude*/
#define DEFAULT_RECORD 511		/*Default Record for all other messages*/

extern C41W32API USHORT C41_HandleIgnore;

BYTE buf[128];

void main(void)
{
	ULONG ARINC_word_lat;			/*Message value in ARINC form*/
	ULONG ARINC_word_long;			/*Message value in ARINC form*/

	HCARD handle;					/*Handle of CM429-1 card*/
	ERRVAL error;					/*Error result*/

	fprintf(stderr,"\nEXAMP1  Version 1.0  (05/26/1999)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Program for receiver example.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the CM429-1 card in socket 0.  A handle to the card
*  is returned which is tested to determine if an error
*  occurred.
*
**/

	handle = C41_OpenCard(0);			/*Open CM429-1 card in socket 0*/

	if (handle<0)
	{
		printf("\nError:  Either a CM429-1 is not present in socket 0 or");
		printf("\n        an error occurred (%i) opening the card in socket 0.",handle);
		printf("\n");
		exit(1);
	}

	C41_Reset(handle);					/*Reset card*/

/**
*
*  Configure channel RCH0 to be active and to receive at low speed.
*
**/

	error = C41_ChConfig(CHCFG_ACTIVE,RCH0,handle);		/*Configure RCH0*/

	if (error<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring receive channel 0.",error);
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

	C41_FilterDefault(DEFAULT_RECORD,RCH0,handle);			/*Default filter first*/

	C41_FilterSet(0310, SDIALL, POS_LAT , RCH0, handle);	/*Followed by*/
	C41_FilterSet(0311, SDIALL, POS_LONG, RCH0, handle);	/*specific filters*/

/**
*
*  Start operation of the card.
*
**/

	C41_Start(handle);

/**
*
*  Display data on the screen.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		ARINC_word_lat  = C41_MsgArincRd(POS_LAT ,handle);	/*Read message record*/
		ARINC_word_long = C41_MsgArincRd(POS_LONG,handle);	/*Read message record*/

		printf("\r");										/*Display values*/
		printf("ARINC_word_lat=%08lX ",ARINC_word_lat);
		printf("ARINC_word_long=%08lX",ARINC_word_long);
	}

/**
*
*  Stop the CM429-1 card.
*
**/

	C41_Stop(handle);

/**
*
*  The CM429-1 card MUST be closed before exiting the program.
*
**/

	C41_CloseCard(handle);
}
