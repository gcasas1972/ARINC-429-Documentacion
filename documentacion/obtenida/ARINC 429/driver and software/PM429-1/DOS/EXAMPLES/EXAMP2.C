/**
*
*  PM429-1 DRIVER EXAMPLE 2  Version 1.0  (10/31/2001)
*  Copyright (c) 2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- Example 2 
*                      "Program for transmitter example using polling."
*
**/

/**
*
*  This program detects the PM429-1 card at port 0x2C0, and
*  then transmits the messages with ramping data.
*
**/


#include "pm41.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>



void main(void)
{
	USHORT port;		/* Port setting of PM429-1 card */
	BOOL val;			/* Test variable */

	UINT airspeed_data;	/* data value */
	UINT airspeed_label;/* label */
	UINT airspeed_sdi;	/* sdi */
	UINT airspeed_ssm;	/* ssm */

	UINT airtemp_data;	/* data value */
	UINT airtemp_label; /* label */
	UINT airtemp_sdi;	/* sdi */
	UINT airtemp_ssm;	/* ssm */


	fprintf(stderr,"\nEXAMP2  Version 1.0  (10/31/2001)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Program for transmitter example using polling.\"");
	fprintf(stderr,"\n");

/**
*
*  Verify the PM429-1 card at 0x2C0.  If no card is found,
*  program exits.
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
*  Configure channel TCH4 to be active and to transmit at low speed.
*  A service request (SRQ) will be set when the transmit FIFO is empty.
*
**/

	PM41_ChConfig(ARINCCTRL_SPEED_LOW, ARINCCTRL_PAR_ODD, FALSE, FALSE, CH4, port);		/*Configure TCH4*/
	PM41_SRQConfig(ASRQ_XMT_EMPT,CH4, port);

/**
*
*  Initialize variables
*
**/

	airspeed_data = 0;			/* set data */
	airspeed_label = PM41_UtilReverseLabel(0210);		/* set label (reverse bit order of octal 210) */
	airspeed_sdi = (0 << 9);	/* set SDI */ 
	airspeed_ssm = (2 << 29);	/* set SSM */ 

	airtemp_data = 0;			/* set data */
	airtemp_label = PM41_UtilReverseLabel(0211);		/* set label (reverse bit order of octal 211) */
	airtemp_sdi = (0 << 9);		/* set SDI */ 
	airtemp_ssm = (2 << 29);	/* set SSM */ 

/**
*
*  Change data until a key is pressed.  The messages will be scheduled such that 
*  the airspeed message will be transmitted every 75ms, and the air temperature
*  message will be transmitted every 150ms. The SDI/SSM/label values are placed into 
*  the proper place in the data word.  The messages will be placed into two 75ms frames.
*
*  See the PM429-1 manual for details of calculating schedule times.
* 
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		
/**
*
*	First frame: Airspeed and air temperature messages are processed.
*
**/

		airspeed_data = ( airspeed_data & 0x1FFFFC00 );	/* filter out SDI/SSM/label */
		airspeed_data = ( airspeed_data >> 10);	/* shift data to LSB position */

		if(airspeed_data > 0x0007FFFE)
		{
			airspeed_data = 0; /* If max value is reached, reset data. */
		}
		else
		{
			airspeed_data++;   /* Increment data */
		}

		airspeed_data = ( airspeed_data << 10);	/* Shift data back to proper position */
		airspeed_data = ( airspeed_data | airspeed_sdi | airspeed_ssm |airspeed_label ); /* OR in SDI/SSM/label */
		
		/* Begin processsing air temp. message */

		airtemp_data = ( airtemp_data & 0x1FFFFC00 );	/* filter out SDI/SSM/label */
		airtemp_data = ( airtemp_data >> 10);	/* shift data to LSB position */

		if(airtemp_data > 0x0007FFFE)
		{
			airtemp_data = 0; /* If max value is reached, reset data. */
		}
		else
		{
			airtemp_data++;   /* Increment data */
		}

		airtemp_data = ( airtemp_data << 10);	/* Shift data back to proper position */
		airtemp_data = ( airtemp_data | airtemp_sdi | airtemp_ssm | airtemp_label ); /* OR in SDI/SSM/label */

		printf("\rAirspeed = %08lX     Airtemp = %08lX", airspeed_data, airtemp_data);

		while(!PM41_SRQIsSet(SRQ_TCH4, port));	/* Wait for complete transmission of second frame*/
		
		PM41_ChDataWr(airspeed_data, CH4, port);	/* write data  to TCH4 */
		PM41_ChDataWr(airtemp_data, CH4, port);		/* write data  to TCH4 */

		PM41_ChGapWr(870, CH4, port);	/* Write gap : this will begin transmission */
/**
*
*	Second frame: Airspeed message is processed.
*
**/
		airspeed_data = ( airspeed_data & 0x1FFFFC00 );	/* filter out SDI/SSM/label */
		airspeed_data = ( airspeed_data >> 10);	/* shift data to LSB position */

		if(airspeed_data > 0x0007FFFE)
		{
			airspeed_data = 0; /* If max value is reached, reset data. */
		}
		else
		{
			airspeed_data++;   /* Increment data */
		}

		airspeed_data = ( airspeed_data << 10);	/* Shift data back to proper position */
		airspeed_data = ( airspeed_data | airspeed_sdi | airspeed_ssm | airspeed_label ); /* OR in SDI/SSM/label */

		printf("\rAirspeed = %08lX     Airtemp = %08lX", airspeed_data, airtemp_data);

		while(!PM41_SRQIsSet(SRQ_TCH4, port));	/* Wait for complete transmission of first frame*/
		
		PM41_ChDataWr(airspeed_data, CH4, port);	/* write data  to TCH4 */
												
		PM41_ChGapWr(905, CH4, port);	/* Write gap */
	
	}
}
