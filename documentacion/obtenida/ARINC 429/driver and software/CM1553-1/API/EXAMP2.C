
#include "c11w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM1553-1 DRIVER EXAMPLE 2  Version 1.0  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- Example 2 from Section 3.2.1.
*                      "BC periodic transmission of messages."
*
**/

/**
*
*  This program opens the CM1553-1 card in socket 0 and
*  creates a frame with a frame time of 20ms.
*  
*  Two messages are inserted into the frame.  The first
*  message transmits 8 data words to subaddress 1 of terminal
*  address 2.  The second message receives 12 data words from
*  subaddress 1 of terminal address 4.
*
*  Then the program activates the CM1553-1.  While it is
*  repeatedly executing the frame, the transmitted data is
*  randomly updated, and the received data is displayed on
*  the screen.
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
	INT msg1;								/*Index of message 1*/
	INT msg2;								/*Index of message 2*/
	INT msg1count =  8;						/*Message 1 data word count*/
	INT msg2count = 12;						/*Message 2 data word count*/
	INT count;

	fprintf(stderr,"\nEXAMP2  Version 1.0  (04/09/1999)");
	fprintf(stderr,"\nCopyright 1997,1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"BC periodic transmission of messages.\"");
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
*  Configure the CM1553-1 card as a bus controller using the
*  default settings.
*
**/

	C11_BCConfig(CONFIG_DEFAULT,handle);

/**
*
*  Initialize the data words for the two messages with random
*  data.
*
**/

	for (temp=0;temp<msg1count;++temp) dataout[temp] = rand();
	for (temp=0;temp<msg2count;++temp) datain[temp]  = rand();

/**
*
*  Create a frame containing two messages.
*
**/

	C11_BCFrameStart(20,handle);
	msg1 = C11_BCDoMsg(BUSA,0x1028,NULL,handle);
	msg2 = C11_BCDoMsg(BUSA,0x242C,datain, handle);
	C11_BCFrameEnd(handle);

/**
*
*  Activate the CM1553-1 card.  The card proceeds to transmit
*  the frame.
*
**/

	C11_Start(handle);

/**
*
*  Until a key is pressed, update the transmitted data and display
*  the received data.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		printf("\r");

		for (temp=0;temp<msg1count;++temp) dataout[temp] = rand();
		C11_BCWrData(msg1,dataout,msg1count,handle);

		C11_BCRdData(msg2,datain,msg2count,handle);
		for (temp=0;temp<msg2count;++temp) printf("%04X ",datain[temp]);
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
