
#include "c41w32.h"
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

/**
*
*  CM429-1 DRIVER EXAMPLE 8  Version 1.0  (05/26/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP8.C -- CM429-1/2R1T/717 ARINC 717 receive channel example.
*                      "Program for ARINC 717 receiver example"
*
**/

/**
*
*  This program opens the CM429-1 card in socket 0, and
*  configures RCH717 to receive the synch word of each subframe.
*
**/

void main(void)
{
	HCARD handle;							/*Handle of CM429-1 card*/
	ERRVAL error;							/*Error result*/
	INT ch;									/*Key press*/
	BOOL done;								/*Done flag*/
	INT listaddr;							/*Address of list buffer*/
	INT addrval;

	USHORT synchword1;							/*Word value for synch1*/
	USHORT synchword2;							/*Word value for synch2*/
	USHORT synchword3;							/*Word value for synch3*/
	USHORT synchword4;							/*Word value for synch4*/

	fprintf(stderr,"\nEXAMP8  Version 1.0  (05/26/1999)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Program for ARINC 717 receiver example.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the CM429-1 card in socket 0.  A handle to the card
*  is returned which is tested to determine if an error
*  occurred.
*
**/

	handle = C41_OpenCard(0);

	if (handle<0)
	{
		printf("\nError:  Either a CM429-1 is not present in socket 0 or");
		printf("\n        an error occurred (%i) opening the card in socket 0.",handle);
		printf("\n");
		exit(1);
	}

	C41_Reset(handle);

/**
*
*  Put the card into ARINC 717 mode.
*
**/

	error = C41_717Boot(handle);

	if (error<0)
	{
		fprintf(stderr,"\a\n\n\n\n\n\nError:  An error was encountered (%i) while booting 717 receive channel.\n\n\a",error);
	}

/**
*
*  Configure channel RCH0 to be active and to receive at low speed.
*
**/

	error = C41_ChConfig(CHCFG717_256WPS,RCH717,handle);		/*Configure RCH717*/

	if (error<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring 717 receive channel.",error);
	}

/**
*
*  Start operation of the card.
*
**/

	C41_Start(handle);

/**
*
*  Wait for synchronization to ARINC 717 databus.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	fprintf(stderr,"\nSynchronizing to bit stream....");

	while (!C41_717SyncTest(RCH717,handle) && !kbhit());		/*Wait until a key is pressed or synch is acheived*/

/**
*
*  Display data on the screen.
*
**/

	while(!kbhit())
	{
		synchword1 = C41_717SubFrmWordRd(1,1,RCH717,handle);	/*Read word one of subframe one*/
		synchword2 = C41_717SubFrmWordRd(2,1,RCH717,handle);	/*Read word one of subframe two*/
		synchword3 = C41_717SubFrmWordRd(3,1,RCH717,handle);	/*Read word one of subframe three*/
		synchword4 = C41_717SubFrmWordRd(4,1,RCH717,handle);	/*Read word one of subframe four*/

		printf("\r");											/*Display values*/
		printf("Synch 1=%04lX ",synchword1);					/*Output value*/
		printf("Synch 2=%04lX ",synchword2);					/*Output value*/
		printf("Synch 3=%04lX ",synchword3);					/*Output value*/
		printf("Synch 4=%04lX ",synchword4);					/*Output value*/
	}

/**
*
*  Stop the CM429-1 card.
*
**/

	C41_Stop(handle);

	C41_CloseCard(handle);
}
