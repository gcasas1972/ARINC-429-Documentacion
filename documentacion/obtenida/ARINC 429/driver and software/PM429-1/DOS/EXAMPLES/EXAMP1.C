/**
*
*  PM429-1 DRIVER EXAMPLE 1  Version 1.0  (10/31/2001)
*  Copyright (c) 2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Example 1 
*                      "Program for receiver example"
*
**/


/**
*
*  This program opens the PM429-1 card at port 0x2C0, and
*  configures RCH0 to receive 2 GPS messages and display 
*  them on the screen.  All other messages are ignored.
*
**/

#include "pm41.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

void main(void)
{
	USHORT port;		/* PM429-1 port setting */ 
	USHORT val;			/* comparison/loop variable */

	UCHAR label[16];	/* array of label filters */ 

	UINT data;			/* received data */
	UINT lon_recv;		/* displayed longitude */
	UINT lat_recv;		/* displayed latitude */

	UCHAR lat_label;
	UCHAR lon_label;

    lat_label = PM41_UtilReverseLabel(0310);	/* label for latitude  */
	lon_label = PM41_UtilReverseLabel(0311);	/* label for longitude  */

	lon_recv = 0;		/* initialize data variables */
	lat_recv = 0;

	fprintf(stderr,"\nEXAMP1  Version 1.0  (10/31/2001)");
	fprintf(stderr,"\nCopyright 2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Program for receiver example.\"");
	fprintf(stderr,"\n");

/**
*
*  Verify the PM429-1 card at 0x2C0.  If no card is found,
*  Program exits.
*
**/
	port = 0x2C0;						/* port setting */

	val = PM41_IsCard(port);			/* Access PM429-1 */

	if (!val)
	{
		printf("\nError:  No PM429-1 present at port %03X", port);
		printf("\n");
		exit(1);
	}

	PM41_CardReset(port);				/* Reset card */


/**
*
*  Set filters on desired labels.  All 16 label positions must be filled,
*  even if less than 16 labels are desired.  Note that label 00 is treated
*  the same as any other label.
*
**/

	label[0]= lat_label;	/* Set first label array position with latitude label. */

	for(val = 1; val <= 15; val++)	/* Fill remaining array with longitude label. */
	{
		label[val] = lon_label;
	}

	PM41_FilterLabelSet(label, CH0, port);	/* Load labels into PM429-1. */

/**
*
*  Set PM429-1 service requests.  A service request (SRQ)
*  will be set for RCH0 when any data is present in the PM429-1.
*
**/

	PM41_SRQConfig(ASRQ_RCV_RDY, CH0, port);	/* Set SRQ */

/**
*
*  Configure channel RCH0 to be active and to receive at low speed.
*
**/

	PM41_ChConfig(ARINCCTRL_SPEED_LOW, ARINCCTRL_PAR_ODD, FALSE, FALSE, CH0, port);		/*Configure RCH0*/

/**
*
*  Display data on the screen.
*
**/


	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		if(PM41_SRQIsSet(SRQ_RCH0, port))	/* check for data in RCH0 */
		{
			data = PM41_ChDataRd(CH0, port);
			if( (data & 0x000000FF) == lat_label)
			{
				lat_recv = data;
			}
			else if( (data & 0x000000FF) == lon_label)
			{
				lon_recv = data;
			}
			else
			{
				printf("\nError: Data %08X was received in error", data);
			}

		}

		printf("\r");										/*Display values*/
		printf("Latitude=%08lX ",lat_recv);
		printf("     Longitude=%08lX",lon_recv);
	}
}
