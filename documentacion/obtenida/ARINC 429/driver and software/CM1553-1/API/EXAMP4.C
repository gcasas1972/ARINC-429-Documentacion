
#include "c11w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM1553-1 DRIVER EXAMPLE 4  Version 1.0  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4.C -- Example 4 from Section 3.3.1.
*                      "RT mode."
*
**/

/**
*
*  This program opens the CM1553-1 card in socket 0 and
*  configures it as an RT with terminal address 3.
*
*  Data received at subaddress 1 is displayed on the screen,
*  and data transmitted out of subaddress 1 are constantly
*  updated.
*
*  The program exits when a key is pressed.
*
**/

void main(void)
{
	HCARD handle;							/*Handle of CM1553-1 card*/
	USHORT datain[32];						/*16-bit data words*/
	USHORT dataout[32];						/*16-bit data words*/
	INT temp;								/*Temporary variable*/

	fprintf(stderr,"\nEXAMP4  Version 1.0  (04/09/1999)");
	fprintf(stderr,"\nCopyright 1997,1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"RT mode.\"");
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
*  Configure the CM1553-1 card as a remote terminal using the
*  default settings.  The CM1553-1 card will simulate remote
*  terminal address 3.
*
**/

	C11_RTConfig(CONFIG_DEFAULT,3,handle);

/**
*
*  Initialize the transmit data using the values in
*  dataout[].
*
**/

	C11_RTWrData(0x1C24,dataout,handle);

/**
*
*  Activate the CM1553-1 card.  The card will respond to
*  commands with remote terimal address 3.
*
**/
		
	C11_Start(handle);

/**
*
*  Until a key is pressed by the user, modify the transmitted
*  data and display the received data.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		printf("\r");

/**
*
*  Display the received data by reading the data into datain[]
*  and displaying the values on the screen.
*
**/

		C11_RTRdData(0x1828,datain,handle);
		for (temp=0;temp<8;++temp) printf("%04X ",datain[temp]);

/**
*
*  Modify the transmitted data by reading the current data
*  values into dataout[], modifying each word of dataout[],
*  and writing new values back to the card.
*
**/

		C11_RTRdData(0x1C24,dataout,handle);
		for (temp=0;temp<8;++temp) ++dataout[temp];
		C11_RTWrData(0x1C24,dataout,handle);
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
