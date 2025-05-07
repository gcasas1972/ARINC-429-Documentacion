
#include "c11w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM1553-1 DRIVER EXAMPLE 8  Version 1.0  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP8.C -- Example 8.
*                      "Continuous Monitor Mode."
*
**/

/**
*
*  This program opens the CM1553-1 card in socket 0 and
*  configures it as a monitor which monitors all RT terminal
*  addresses.
*
*  After starting the card, it polls the monitor and
*  retrieves information on all messages received.  Some of
*  the information is displayed on the screen.
*  
*  It also detects when the Summit overruns the monitor
*  buffer and halts the Summit.
*
*  At any time, the user can press a key to exit the program.
*
**/

void main(void)
{
	HCARD handle;							/*Handle of CM1553-1 card*/
	INT previndex;							/*Previous Summit index into monitor buffer*/
	INT currindex;							/*My current index into monitor buffer*/
	INT nextindex;							/*Summit's next index into monitor buffer*/
	volatile INT j;
	volatile ULONG jj;
	USHORT data[32];						/*16-bit data words*/
	USHORT block[8];						/*16-bit data words*/

	fprintf(stderr,"\nEXAMP8  Version 1.0  (04/09/1999)");
	fprintf(stderr,"\nCopyright 1997,1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Continuous Monitor Mode.\"");
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
*  Until a key is pressed by the user, display all bus
*  traffic on the screen.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	nextindex = currindex = 512;		/*Reset variables to empty condition*/

	while(!kbhit())
	{
		previndex = nextindex;						/*Cache Summit's previous index*/

		nextindex = C11_MONCount(handle);			/*Get Summit's next index*/

		if ((previndex<currindex && nextindex>currindex) ||		/*If Summit has overrun*/
			(nextindex<previndex && currindex>previndex) ||
			(currindex<nextindex && previndex>nextindex))
		{
			C11_Stop(handle);						/*Tell it to stop it!*/

			printf("\nThe Summit has been stopped!");

			break;
		}

		if (nextindex != currindex)						/*Wait for count to change*/
		{
			++currindex;								/*Increment index*/

			if (currindex>512) currindex=1;				/*Wrap around*/

			C11_MONRd(currindex,block,data,handle);		/*Read monitor information*/

			printf("\nprevindex=%04X currindex=%04X nextindex=%04X cwd=%04X ",previndex,currindex,nextindex,block[1]);

			for (j=0;j<32;++j)
			{
				printf("%04X ",data[j]);
			}
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
