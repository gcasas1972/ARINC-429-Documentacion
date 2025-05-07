
#include "c41w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM429-1 DRIVER EXAMPLE 2  Version 1.0  (05/26/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- Example 2 from Section 3.5.
*                      "Program for transmitter example."
*
**/

/**
*
*  This program opens the CM429-1 card in socket 0, builds a
*  transmit schedule using transmit interval information, and
*  then transmits the messages with changing data.
*
**/

#define COMP_AIRSPEED 100		/*Message Record for Computed Airspeed*/
#define TOT_AIR_TEMP  101		/*Message Record for Total Air Temp*/
#define ALTITUDE_RATE 102		/*Message Record for Altitude Rate*/

ULONG init_data_airspeed;	/*Holds initial message values*/
ULONG init_data_temp;
ULONG init_data_altitude;

ULONG new_data_airspeed;	/*Holds new message values*/
ULONG new_data_temp;
ULONG new_data_altitude;

ULONG bnr_data_airspeed;	/*Holds BNR value of message*/
ULONG bnr_data_temp;
ULONG bnr_data_altitude;

void main(void)
{
	HCARD handle;								/*Handle of CM429-1 card*/
	ERRVAL error;								/*Error result*/

	INT Min_Intervals[] = { 63,250,32};		/*Minimum transmit intervals*/
	INT Max_Intervals[] = {125,500,62};		/*Maximum transmit intervals*/

	fprintf(stderr,"\nEXAMP2  Version 1.0  (05/26/1999)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Program for transmitter example.\"");
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

	C41_Reset(handle);					/*Reset card*/

/**
*
*  Configure channel TCH4 to be active and to transmit at low speed.
*
**/

	error = C41_ChConfig(CHCFG_ACTIVE, TCH4, handle);

	if (error<0)
	{
		fprintf(stderr,"Error:  An error was encountered (%i) while configuring receive channel 0.",error);
	}

/**
*
*  Next, build a schedule using the minimum and maximum
*  transmit intervals.  Note that the three Message Records
*  are at consecutive locations.
*
**/

	C41_SchedBuild(COMP_AIRSPEED, 3, Min_Intervals, Max_Intervals, TCH4, handle);

/**
*
*  Initialize the three Message Records.
*
**/

	init_data_airspeed = C41_FldPutLabel(0L,0206);		/*Init label field*/
	init_data_temp     = C41_FldPutLabel(0L,0211);
	init_data_altitude = C41_FldPutLabel(0L,0212);

	init_data_airspeed = C41_BNRPutMant(init_data_airspeed,0L,14,0);	/*Init BNR data*/
	init_data_temp     = C41_BNRPutMant(init_data_temp,    0L,11,0);
	init_data_altitude = C41_BNRPutMant(init_data_altitude,0L,16,0);

	C41_MsgArincWr(init_data_airspeed, COMP_AIRSPEED, handle);	/*Write values*/
	C41_MsgArincWr(init_data_temp    , TOT_AIR_TEMP , handle);	/*to Message*/
	C41_MsgArincWr(init_data_altitude, ALTITUDE_RATE, handle);	/*Records*/

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

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		new_data_airspeed = C41_MsgArincRd(COMP_AIRSPEED, handle);		/*Read messages back*/
		new_data_temp     = C41_MsgArincRd(TOT_AIR_TEMP , handle);
		new_data_altitude = C41_MsgArincRd(ALTITUDE_RATE, handle);

		bnr_data_airspeed = C41_BNRGetMant(new_data_airspeed,14);		/*Extract BNR data*/
		bnr_data_temp     = C41_BNRGetMant(new_data_temp,11);
		bnr_data_altitude = C41_BNRGetMant(new_data_altitude,16);

		++bnr_data_airspeed;		/*Change BNR data*/
		++bnr_data_temp;
		++bnr_data_altitude;

		new_data_airspeed = C41_BNRPutMant(new_data_airspeed,bnr_data_airspeed,14,0);	/*Put BNR data*/
		new_data_temp     = C41_BNRPutMant(new_data_temp,    bnr_data_temp,    11,0);	/*back into*/
		new_data_altitude = C41_BNRPutMant(new_data_altitude,bnr_data_altitude,16,0);	/*messages*/

		C41_MsgArincWr(new_data_airspeed, COMP_AIRSPEED, handle);	/*Write new message values*/
		C41_MsgArincWr(new_data_temp    , TOT_AIR_TEMP , handle);
		C41_MsgArincWr(new_data_altitude, ALTITUDE_RATE, handle);
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
