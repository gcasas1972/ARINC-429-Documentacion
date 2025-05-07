
#include "c11w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM1553-1 DRIVER EXAMPLE 7  Version 1.0  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP7.C -- Example 7 from Section 4.3.5.
*                      "RT list buffering with Notice II enabled."
*
**/

/**
*
*  This program opens the CM1553-1 card in socket 0 and
*  configures it as an RT with terminal address 3.  Single
*  buffer mode is enabled.  Broadcast and Notice II are also
*  enabled.
*
*  A list buffer is configured for receive subaddress 2. 
*  When the spacebar is pressed, the contents of the list
*  buffer is displayed.  Pressing the ESC key exits the
*  program.
*
**/

void main(void)
{
	HCARD handle;							/*Handle of CM1553-1 card*/
	USHORT data[32];						/*16-bit data words*/
	INT index;								/*Temporary variable*/
	INT count = 7;							/*Size of list buffer*/
	CHAR ch;								/*Key read from keyboard*/

	fprintf(stderr,"\nEXAMP7  Version 1.0  (04/09/1999)");
	fprintf(stderr,"\nCopyright 1997,1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"RT list buffering with Notice II enabled.\"");
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
*  Configure the CM1553-1 card as a remote terminal.  Enable
*  broadcast and Notice II.  The CM1553-1 card will simulate
*  remote terminal address 3.
*
**/

	C11_RTConfig(CONFIG_SINGLEBUF | CONFIG_BCAST | CONFIG_NOTICE2,3,handle);

/**
*
*  Initialize a list buffer for receive subaddress 2.
*
**/

	C11_RTInitList(0x0040,count,handle);

/**
*
*  Activate the CM1553-1 card.  The card will respond to
*  commands with remote terimal address 3.
*
**/
	
	C11_Start(handle);

/**
*
*  When the user presses the space bar, the contents of the
*  list buffer is displayed and the list buffer is
*  emptied.
*
*  To exit the program, press the ESC key.
*
**/

	fprintf(stderr,"\nPress ESC to exit....\n\n");
	
	while(1)
	{
		if (kbhit())					/*If key pressed*/
		{
			ch = getch();				/*Get key from keyboard*/

			if (ch==27) break;			/*Exit if ESC key pressed*/

			if (ch==' ')				/*Display contents of list buffer*/
			{
				printf("\n");

				for (index=1;index<=C11_RTCountList(0x0040,handle);++index)
				{
					C11_RTRdList(0x0040,index,data,handle);
					printf("1 %04X %04X ",data[0],data[1]);	/*Display info & time-tag*/
				}

				for (index=1;index<=C11_RTCountList(0xF840,handle);++index)
				{
					C11_RTRdList(0xF840,index,data,handle);
					printf("2 %04X %04X ",data[0],data[1]);	/*Display info & time-tag*/
				}

				C11_RTRstList(0x0040,handle);	/*Reset list buffer*/
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
