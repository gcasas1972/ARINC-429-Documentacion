
#include "c41w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM429-1 DRIVER EXAMPLE 4  Version 1.0  (05/26/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4.C -- Example 4 from Section 4.4.
*                      "Example with explicit message timing."
*
**/

/**
*
*  This program opens the CM429-1 card in socket 0, and
*  builds a transmit schedule using explicit message timing. 
*  The internal wrap-around is enabled and filters are set to
*  receive the messages.  The minimum and maximum elapsed
*  time for each message is displayed.
*
**/

#define	XMT_AIRSPEED  0		/*Message Record for transmitted Computed Airspeed*/
#define	XMT_ALTITUDE  1		/*Message Record for transmitted Altitude Rate*/
#define	RCV_AIRSPEED 10		/*Message Record for received Computed Airspeed*/
#define	RCV_ALTITUDE 11		/*Message Record for received Altitude Rate*/

USHORT AltitudeRecord[8];	/*Stores Message Record for Altitude Rate*/
USHORT AirSpeedRecord[8];	/*Stores Message Record for Computed Airspeed*/

void main(void)
{
	HCARD handle;								/*Handle of CM429-1 card*/
	ERRVAL error;								/*Error result*/

	fprintf(stderr,"\nEXAMP4  Version 1.0  (05/26/1999)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Example with explicit message timing.\"");
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
*  Reset the card which also resets the Min/Max Elapsed Time
*  counters.
*
**/

	C41_Reset(handle);

/**
*
*  Configure channel RCH0 to be active and to receive at low
*  speed.  The Min/Max Elapse Time option is also enabled.
*
**/

	error = C41_ChConfig(CHCFG_ACTIVE | CHCFG_MAXMIN,RCH0,handle);		/*Configure RCH0*/

	if (error<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring receive channel 0.",error);
	}

/**
*
*  Configure channel TCH4 to be active and to transmit at low
*  speed.  Note that the wrap-around selftest is also enabled. 
*  The external line drivers are disabled, and TCH4 is
*  connected internally to RCH0 and RCH1.  The data received
*  by RCH1 is inverted, but the data received by RCH0 is not.
*
**/

	error = C41_ChConfig(CHCFG_ACTIVE | CHCFG_WRAPTEST, TCH4, handle);

	if (error<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring transmit channel 4.",error);
	}

/**
*
*  Before any messages can be received, filters must be set
*  for the receive channel.  Two filters are set for the two
*  messages of interest.  Note that no default filter is
*  created.
*
**/

	C41_FilterSet(0206, SDIALL, RCV_AIRSPEED, RCH0, handle);
	C41_FilterSet(0212, SDIALL, RCV_ALTITUDE, RCH0, handle);

/**
*
*  Next, a schedule is built by creating explicit message timing.
*
**/

	C41_SchedMsg(XMT_ALTITUDE, TCH4, handle);
	C41_SchedMsg(XMT_AIRSPEED, TCH4, handle);
	C41_SchedGap(495, TCH4, handle);
	C41_SchedMsg(XMT_ALTITUDE, TCH4, handle);
	C41_SchedGap(531, TCH4, handle);

/**
*
*  Those messages that are to be transmitted are initialized.
*
**/

	C41_MsgArincWr(0x0000008A, XMT_ALTITUDE, handle);
	C41_MsgArincWr(0x00000086, XMT_AIRSPEED, handle);

/**
*
*  Start operation of the card.
*
**/

	C41_Start(handle);

/**
*
*  Display data until a key is pressed.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{

/**
*
*  The Message Records containing receive messages are read. 
*  Each Message Record contains 8 16-bit words, of which word
*  4 and 5 contain the Minimum and Maximum Elapsed time
*  respectively.  These values are displayed on the screen
*  as well as the message value received.
*
**/

		C41_MsgBlockRd(AltitudeRecord, RCV_ALTITUDE, handle);
		C41_MsgBlockRd(AirSpeedRecord, RCV_AIRSPEED, handle);

		printf("\r");														/*Display values*/

		printf("AirSpeed=%08lX ",C41_MsgArincRd(RCV_AIRSPEED, handle));		/*Read and display*/
		printf("min/max=%ums/%ums ",AirSpeedRecord[4],AirSpeedRecord[5]);

		printf("Altitude=%08lX ",C41_MsgArincRd(RCV_ALTITUDE, handle));		/*message values*/
		printf("min/max=%ums/%ums ",AltitudeRecord[4],AltitudeRecord[5]);
	}

/**
*
*  Stop the CM429-1 card.
*
**/

	C41_Stop(handle);

/**
*
*  The Message Records containing receive messages are read. 
*  Each Message Record contains 8 16-bit words, of which word
*  4 and 5 contain the Minimum and Maximum Elapsed time
*  respectively.  These values are displayed on the screen.
*
**/

	C41_MsgBlockRd(AltitudeRecord, RCV_ALTITUDE, handle);
	C41_MsgBlockRd(AirSpeedRecord, RCV_AIRSPEED, handle);

	printf("\nMax transmit interval of AirSpeed is %ums.",AirSpeedRecord[4]);
	printf("\nMin transmit interval of AirSpeed is %ums.",AirSpeedRecord[5]);
	printf("\nMax transmit interval of Altitude is %ums.",AltitudeRecord[4]);
	printf("\nMin transmit interval of Altitude is %ums.",AltitudeRecord[5]);

/**
*
*  The CM429-1 card MUST be closed before exiting the program.
*
**/

	C41_CloseCard(handle);
}
