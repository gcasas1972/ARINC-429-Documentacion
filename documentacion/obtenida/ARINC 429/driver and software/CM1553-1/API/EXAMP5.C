
#include "c11w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM1553-1 DRIVER EXAMPLE 5  Version 1.0  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5.C -- Example 5 from Section 3.4.1.
*                      "Monitor Mode."
*
**/

/**
*
*  This program opens the CM1553-1 card in socket 0 and
*  configures it as a monitor which monitors all RT terminal
*  addresses.
*
*  After starting the card, it first waits for the first
*  entry to be written into the monitor buffer.  It displays
*  the first and subsequent entries until 512 messages have
*  been monitored.  Then the program terminates.
*
*  At any time, the user can press a key to exit the program.
*
**/

void main(void)
{
	HCARD handle;							/*Handle of CM1553-1 card*/
	INT index = 0;							/*Current index into monitor buffer*/
	USHORT data[32];						/*16-bit data words*/
	USHORT block[8];						/*16-bit data words*/

	fprintf(stderr,"\nEXAMP5  Version 1.0  (04/09/1999)");
	fprintf(stderr,"\nCopyright 1997,1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Monitor Mode.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the CM1553-1 card in socket 0.  A handle to the card
*  is returned which is tested to determine if an error
*  occurred.
*
**/

	handle = C11_OpenCard(0);

	if (handle==NULL)
	{
		printf("\nError:  Either a CM1553-1 is not present in socket 0 or an");
		printf("\n        error occurred opening the card in socket 0.");
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the CM1553-1 card as a monitor using the default
*  settings.  The card will hold a maximum 512 messages.
*
**/

	C11_MONConfig(CONFIG_DEFAULT,512,handle);

/**
*
*  Activate the CM1553-1 card.  The card will begin to record
*  all bus activity.
*
**/

	C11_Start(handle);


/**
*
*  Wait for the first monitor entry to be written.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit() && C11_MONCount(handle) == 512);

/**
*
*  Until a key is pressed by the user, display all bus
*  traffic on the screen.
*
**/

	while(!kbhit() && index < 512)
	{
		if (index != C11_MONCount(handle))			/*Wait for count to change*/
		{
			C11_MONRd(index+1,block,data,handle);	/*Read monitor information*/

			printf("\nindex=%04X cwd=%04X",index,block[1]);

			++index;								/*Increment index*/
		}
	}

/**
*
*  Stop the CM1553-1 card.
*
**/
 
	C11_Stop(handle);

/**
*
*  We are done, so we MUST close the CM1553-1 card using the
*  handle obtained from C11_OpenCard().
*
**/

	C11_CloseCard(handle);
}
