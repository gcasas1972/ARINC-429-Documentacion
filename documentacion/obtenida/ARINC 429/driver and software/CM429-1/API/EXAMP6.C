
#include "c41w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM429-1 DRIVER EXAMPLE 6  Version 1.0  (05/26/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP6.C -- Example 6.
*                      "Program for list buffer transmitter example."
*
**/

/**
*
*  This program opens the CM429-1 card in socket 0, builds a
*  transmit schedule using transmit interval information, and
*  then transmits the messages with changing data.
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

	fprintf(stderr,"\nEXAMP6  Version 1.0  (05/26/1999)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Program for list buffer transmitter example.\"");
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

	C41_Reset(handle);

/**
*
*  Configure channel TCH4 to be active and to transmit at high speed.
*
**/

	error = C41_ChConfig(CHCFG_ACTIVE+CHCFG_HIGHSPEED, TCH4, handle);

	if (error<0)
	{
		fprintf(stderr,"Error:  An error was encountered (%i) while configuring transmit channel 4.",error);
	}

/**
*
*  Create a schedule with only a gap.
*
**/

	error = C41_SchedGap(50*13,TCH4,handle);

	if (error<0)
	{
		fprintf(stderr,"Error:  An error was encountered (%i) while creating schedule.",error);
	}

/**
*
*  Create transmit list buffer.
*
**/

	listaddr = C41_ListMakeXmt(11,TCH4,handle);

	if (!listaddr)
	{
		fprintf(stderr,"Error:  Unable to create transmit list buffer.");
	}

	printf("listaddr=%04X",listaddr);

/**
*
*  Start operation of the card.
*
**/

	C41_Start(handle);

/**
*
*  Change data until a key is pressed.
*
**/

	fprintf(stderr,"\nPress spacebar to transmit a word, press ESC to exit....\n\n");

	for (done=0;!done;)
	{
		printf("addrval=%04X head=%04X tail=%04X top=%04X bot=%04X\r",
				addrval,
				C41_MemPeek(listaddr+0,handle),
				C41_MemPeek(listaddr+1,handle),
				C41_MemPeek(listaddr+2,handle),
				C41_MemPeek(listaddr+3,handle));

		if (kbhit())
		{
			ch = getch();
			
			if (ch==' ')
			{
				addrval = C41_ListWr(0,listaddr,handle);
			}

			if (ch==27)
			{
				done=1;
			}
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
