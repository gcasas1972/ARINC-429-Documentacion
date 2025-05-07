
#include "c11w32.h"
#include <stdio.h>
#include <stdlib.h>

/**
*
*  CM1553-1 DRIVER EXAMPLE 1  Version 1.0  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Example 1 from Section 3.2.1.
*                      "BC transmission of one message one time."
*
**/

/**
*
*  This program opens the CM1553-1 card in socket 0, sets up
*  a single BC-RT receive message, transmits it over the
*  MIL-STD-1553 databus, and displays the response.
*
**/

void main(void)
{
	HCARD handle;							/*Handle of CM1553-1 card*/
	INT error;								/*Error result*/
	USHORT command;							/*16-bit command word*/
	USHORT data[32];						/*16-bit data words*/
	USHORT rtstatus;						/*16-bit status words*/
	INT ta,tr,sa,wc;						/*Command word fields*/
	INT temp;								/*Temporary variable*/

	fprintf(stderr,"\nEXAMP1  Version 1.0  (04/09/1999)");
	fprintf(stderr,"\nCopyright 1997,1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"BC transmission of one message one time.\"");
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
*  Create a command word from the value of its fields.  This
*  command transmits 8 random data words to subaddress 1 of
*  terminal address 2.
*
**/

	command = C11_PackCWD(2,0,1,8);

	for (temp=0;temp<32;++temp) data[temp] = rand();

/**
*
*  Transmit the command word and data words on bus A.  It
*  returns the result of the transmission and the status word
*  response from the RT.
*
**/

	error = C11_TransmitMsg(BUSA,command,data,&rtstatus,handle);

/**
*
*  Test the error return value to determine if an error
*  occurred in the transmission.  If there was no error,
*  display the results.
*
**/

	if (error<0)
	{
		printf("\nError:  An error was encountered (%i) in the response from the RT.",error);
		printf("\n");
	}
	else
	{
		C11_UnpackCWD(command,&ta,&tr,&sa,&wc);		/*Unpack command word*/

		printf("\nTransmitted command word %04XH.",command);
		printf("\nCommand word fields are  TA=%i TR=%i SA=%i WC=%i.",ta,tr,sa,wc);
		printf("\nTransmitted data words",rtstatus);

		for (temp=0;temp<wc;++temp)
		{
			printf("   data[%i]=%04XH\n                      ",temp,data[temp]);
		}

		printf("\nReceived RT status word %04XH.",rtstatus);
		printf("\n");
	}

/**
*
*  We are done, so we MUST close the CM1553-1 card using the
*  handle obtained from C11_OpenCard().
*
**/

	C11_CloseCard(handle);
}
