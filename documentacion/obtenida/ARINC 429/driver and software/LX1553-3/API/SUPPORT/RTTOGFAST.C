
/**
*
*  LP1553-3 and LC1553-3 DRIVER EXAMPLE 3  Version 1.0  (10/29/2001)
*  Copyright (c) 1997-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   RTTOGFAST.C -- Toggling RTs - fast
*
**/

/**
*
*  This example configures the L13 to simulate 3 RTs.
*  Each RT can be 'muted' or "unmuted' by pressing the
*  1, 2, or 3 keys for each of the RTs.  The card is not
*  stopped, so the other RTs are not affected.
*
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of L13 card*/

ERRVAL L13_RTMute(BOOL muteflag,INT taval,HCARD handleval)
{
	USHORT rtopt;

	const USHORT RTOPT_SIM=0x8000;		//Set when responding to RT address
	const USHORT RTOPT_MON=0x4000;		//Set when monitoring RT address

	rtopt = L13_BlkOptRd(taval,handleval);

	if (muteflag)
	{
		rtopt &= ~RTOPT_SIM;			//Clear bit
	}
	else
	{
		rtopt |= RTOPT_SIM;				//Set bit
	}

	L13_BlkOptWr(rtopt,taval,handleval);

	return(ERR_NONE);
}

void main(void)
{
	HCARD   handleval;
	ERRVAL  errval;
	BOOL    done;
	INT     ch;
	BOOL    rt1,rt2,rt3;

	fprintf(stderr,"\nRTTOGFAST  Version 1.0  (08/18/2004)");
	fprintf(stderr,"\nCopyright 1997-2004  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Example 3");
	fprintf(stderr,"\n\"Toggling RTs - fast\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L13 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	handleval = L13_CardOpen(CARDNUM);					/*Open the L13 card*/

	if (handleval < 0)
	{
		printf("\nError:  Either L13 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",handleval);
		printf("\n");
		exit(1);
	}

/**
*
*  Configure the card for remote terminal mode.
*
**/

	L13_CardReset(handleval);

	errval = L13_RTConfig(RTCFG_DEFAULT, 1, handleval);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for remote terminal mode.",errval);
		L13_CardClose(handleval);
		exit(1);
	}

	errval = L13_RTConfig(RTCFG_DEFAULT, 2, handleval);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for remote terminal mode.",errval);
		L13_CardClose(handleval);
		exit(1);
	}

	errval = L13_RTConfig(RTCFG_DEFAULT, 3, handleval);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for remote terminal mode.",errval);
		L13_CardClose(handleval);
		exit(1);
	}

/**
*
*  Start the card to begin responding to transmissions.
*
**/

	L13_CardStart(handleval);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress ESC to quit.");
	printf("\nPress '1', '2', or '3' to toggle RT1, RT2, or RT3 respectively");
	printf("\n");
	
	for (rt1=1,rt2=1,rt3=1,done=0;!done;)
	{
		if (kbhit())
		{
			ch = getch();

			switch(ch)
			{
				case 27:
					done=1;
					break;

				case '1':
					if (rt1)
					{
						printf("\nDisabing RT1");
						L13_RTMute(1,1,handleval);
						rt1=0;
					}
					else
					{
						printf("\nEnabling RT1");
						L13_RTMute(0,1,handleval);
						rt1=1;
					}
					break;

				case '2':
					if (rt2)
					{
						printf("\nDisabing RT2");
						L13_RTMute(1,2,handleval);
						rt2=0;
					}
					else
					{
						printf("\nEnabling RT2");
						L13_RTMute(0,2,handleval);
						rt2=1;
					}
					break;

				case '3':
					if (rt3)
					{
						printf("\nDisabing RT3");
						L13_RTMute(1,3,handleval);
						rt3=0;
					}
					else
					{
						printf("\nEnabling RT3");
						L13_RTMute(0,3,handleval);
						rt3=1;
					}
					break;
			}
		}
	}

/**
*
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardStop(handleval);					/*Stop the card*/
	L13_CardClose(handleval);					/*Close the card*/
}
