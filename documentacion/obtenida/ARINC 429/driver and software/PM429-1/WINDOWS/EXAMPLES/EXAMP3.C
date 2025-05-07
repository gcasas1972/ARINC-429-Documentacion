/**
*
*  PM429-1 EXAMPLE 3  Version 1.1  (04/05/2006)
*  Copyright (c) 2001-2006
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- Example 3 
*                      "Program for Digital input/output, Timer, LED example."
*
**/

/**
*
*  This program detects the PM429-1 card at port 0x2C0, and
*  then transmits the messages with changing data.
*
**/

#include "pm41.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

void main(void)
{
	USHORT port;		/* Port setting of PM429-1 card */
	HANDLE hCard;		/* PM429-1 card descriptor */
	USHORT val;			/* Test variable/loop counter */
	USHORT count;		/* Index of DIN SRQ */
	UINT time;			/* Timer value */

	fprintf(stderr,"\nEXAMP3  Version 1.1  (04/05/2006)");
	fprintf(stderr,"\nCopyright 2001-2006 Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Program for Digital input/output, Timer, LED example.\"");
	fprintf(stderr,"\n");

	port = 0x2C0;						/* port setting */

	//
	//	Open the card using the'SymbolicName' from the
	// .INF or .REG file, but with the prefix '\\\\.\\'
	//

	hCard = PM41_CardOpen("\\.\\\\PM429Card", port);

	if (hCard==PM41_INVALID_HANDLE)
	{
		printf("\nFAILED: Could not open card");
		return;
	}

	if (hCard==PM41_ERRMEM_HANDLE)
	{
		printf("\nFAILED: Not enough memory");
		printf("\n        Increase PM41_MAXCARDS");
		return;
	}

	printf("\nOpened card %08lX at %03XH",hCard,port);

	//
	//	Check card
	//

	val = PM41_IsCard(port);			/* Access PM429-1 */

	if (!val)
	{
		printf("\nError:  No PM429-1 present at port %03X", port);
		printf("\n");
		exit(1);
	}
   
	PM41_CardReset(port);				/* Reset card */

	//
	//	Configure DIN/DOUT signals.  We will configure DIN0 to generate 
	//	a service request (SRQ), and use that SRQ to increment a hit counter. 
	//	If service requests are configured within 16 Msec of card reset	and
	//	the digital input is high, a positive edge may be seen due to the 
	//	card coming out of reset.
	//
	//	We will configure DOUT0 to be set and reset via the console, and  
	//	slave DOUT0 to the user LED.  The on-board timer will count at a 1Msec
	//	rate and be displayed on the screen in seconds.
	//

	count = 0;	/* reset counter */

	PM41_DINConfig(DSAMP_DBRES_1MS, 1, port);	 /* Configure DIN sample rate at 1 KHZ */
	
	PM41_DINSRQSet(DINT_SRQ_0P, port);	 /* Configure DIN0 for SRQ on rising edge */

	PM41_TimerConfig(TCTRL_RES_1MS | TCTRL_INCR, port);	/* Configure timer for 1 Ms resolution, free run */
	PM41_TimerStart(port);	/* Start timer */

 	fprintf(stderr,"\nPress a ESC to exit, SPACE to toggle DOUT0 & LED....\n\n");

	while(val != 0x1B)	                 /* Run until the ESC key is pressed */
	{
		if(PM41_SRQIsSet(SRQ_DIN0, port))	
		{
			count++;                     /* Increment SRQ count when SRQ received */
			PM41_SRQClr(SRQ_DIN0, port); /* Clear SRQ */
		}

		if(kbhit())		/* If a key is pressed */
		{
			val = getch();				/* Get last key pressed */			 
		}

		if(val == 0x20)		/* Toggling DOUT0 */	
		{
			if(PM41_DOUTIsSet(DOUT_0, port))	/* Check for DOUT0 set */
			{
				PM41_DOUTClr(DOUT_0, port);	/* Reset DOUT0 */
				PM41_LEDWr(FALSE, port);    /* Reset user LED */
			}
			else
			{
				PM41_DOUTWr(DOUT_0, port);	/* Set DOUT0 */
				PM41_LEDWr(TRUE, port);		/* Set user LED */
			}
			val = 0;						/* reset val */
		}

		time = PM41_TimerRd(port);

		printf("\r");						/* Display count */
		printf("We saw DIN0 pulsed %d times.  Timer has run for %d Sec ",count,(time/1000));
	}

	if(FALSE == PM41_CardClose(port))	/* release the card */
	{
		printf("Error closing card");
	}
}
