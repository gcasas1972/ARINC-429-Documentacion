
#include "c41w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM429-1 DRIVER EXAMPLE 5  Version 1.0  (05/26/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5.C -- Example 5.
*                      "Auto-filter example."
*
**/

/**
*
*  This program opens the CM429-1 card in socket 0, and
*  creates a Default Record for receive channel 0.  It then
*  monitors the Default Record for receive labels.  For every
*  unique receive label, it creates a new Message Record and
*  displays the label value.  As a result, every label on the
*  ARINC 429 bus is displayed on the screen.
*
**/

#define DEFAULT_RECORD 511		/*Default Record for all other messages*/

INT LabelCount=0;				/*Number of unique labels received*/
INT ServiceCount=0;				/*Last value of Service Counter*/
INT LabelValue;					/*Value of receive label*/

USHORT MessageRecord[8];		/*Stores Message Record info*/

void main(void)
{
	HCARD handle;								/*Handle of CM429-1 card*/
	ERRVAL error;								/*Error result*/

	fprintf(stderr,"\nEXAMP5  Version 1.0  (05/26/1999)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Auto-filter example.\"");
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

/**
*
*  Reset the card which also resets the Service Count in each
*  Message Record.
*
**/

	C41_Reset(handle);

/**
*
*  Configure channel RCH0 to be active and to receive at low
*  speed.  Also, the service counter is enabled.  This
*  counter in each Message Record is incremented whenever the
*  Message Record is serviced.
*
**/

	error = C41_ChConfig(CHCFG_ACTIVE | CHCFG_SERVICE,RCH0,handle);		/*Configure RCH0*/

	if (error<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring receive channel 0.",error);
	}

/**
*
*  The default filter for receive channel 0 is created.
*
**/

	C41_FilterDefault(DEFAULT_RECORD,RCH0,handle);			/*Default filter*/

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
		C41_MsgBlockRd(MessageRecord, DEFAULT_RECORD, handle);	/*Read Message Record*/

		if (MessageRecord[6] != ServiceCount)					/*If Service Count changed*/
		{
			LabelValue = (unsigned)(MessageRecord[0] & 0xFFL);				/*Get label value*/

			printf("\ncount=%-3u label=%02XH",LabelCount,LabelValue);		/*Print values*/

			C41_FilterSet(LabelValue, SDIALL, LabelCount, RCH0, handle);	/*Create filter*/

			ServiceCount  = MessageRecord[6];					/*Record new count*/
			LabelCount   += 1;
		}
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
