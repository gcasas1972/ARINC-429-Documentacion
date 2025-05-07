
#include "c11w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM1553-1 DRIVER EXAMPLE 3  Version 1.0  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- Example 3 from Section 3.2.3.
*                      "BC transmission of a message schedule."
*
**/

/**
*
*  This program opens the CM1553-1 card in socket 0 and
*  creates three frames each with a frame time of 10ms.
*  
*  Message 1, message 2, and message 3 are inserted into
*  frame 1.  Message 1 is reinserted into frame 2, and
*  message 1 and message 2 are reinserted into frame 3. 
*  Refer to Section 3.2.3 on the structure of the resulting
*  message schedule.
*
*  Then the program activates the CM1553-1.  While it is
*  repeatedly executing the frame, the received data is
*  displayed on the screen.
*
*  The program exits when a key is pressed.
*
**/

void main(void)
{
	HCARD handle;							/*Handle of CM1553-1 card*/
	INT msg1;								/*Index of message #1*/
	INT msg2;								/*Index of message #2*/
	INT msg3;								/*Index of message #3*/
	INT frame1;								/*Index of frame #1*/
	INT frame2;								/*Index of frame #2*/
	INT frame3;								/*Index of frame #3*/
	INT temp;								/*Temporary variable*/
	USHORT cwd1 = 0x0C21;					/*Command word for message #1*/
	USHORT cwd2 = 0x0C22;					/*Command word for message #2*/
	USHORT cwd3 = 0x0C23;					/*Command word for message #3*/
	USHORT dwd[32];							/*Holds data words read from card*/

	fprintf(stderr,"\nEXAMP3  Version 1.0  (04/09/1999)");
	fprintf(stderr,"\nCopyright 1997,1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"BC transmission of a message schedule.\"");
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
*  Create 3 frames, each containing one or more messages.
*
**/

	frame1 = C11_BCFrameStart(10,handle);			/*Start frame #1*/
	msg1   = C11_BCDoMsg(BUSA,cwd1,NULL,handle);	/*Insert message #1*/
	msg2   = C11_BCDoMsg(BUSA,cwd2,NULL,handle);	/*Insert message #2*/
	msg3   = C11_BCDoMsg(BUSA,cwd3,NULL,handle);	/*Insert message #3*/
	C11_BCFrameEnd(handle);							/*End frame #1*/

	frame2 = C11_BCFrameStart(10,handle);			/*Start frame #2*/
	C11_BCDoAgain(msg1,handle);						/*Insert message #1*/
	C11_BCFrameEnd(handle);							/*End frame #2*/

	frame3 = C11_BCFrameStart(10,handle);			/*Start frame #3*/
	C11_BCDoAgain(msg1,handle);						/*Insert message #1*/
	C11_BCDoAgain(msg2,handle);						/*Insert message #2*/
	C11_BCFrameEnd(handle);							/*End frame #3*/

/**
*
*  Place the frames into the cycle by inserting them in the
*  order they will be transmitted.
*
**/

	C11_BCCallFrame(frame1,handle);					/*Call frame #1*/
	C11_BCCallFrame(frame2,handle);					/*Call frame #2*/
	C11_BCCallFrame(frame3,handle);					/*Call frame #3*/
	C11_BCCallFrame(frame2,handle);					/*Call frame #2*/

/**
*
*  Activate the CM1553-1 card.  The card proceeds to transmit
*  the bus controller schedule.
*
**/

	C11_Start(handle);

/**
*
*  Until a key is pressed by the user, display the data words
*  for each of the three messages on the screen.
*
**/
			
	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		printf("\r");

/**
*
*  Read the received data associated with message 1 and
*  display on the screen.
*
**/

		printf("  MSG1: ");
		C11_BCRdData(msg1,dwd,1,handle);
		for (temp=0;temp<1;++temp) printf("%04X ",dwd[temp]);

/**
*
*  Read the received data associated with message 2 and
*  display on the screen.
*
**/

		printf("  MSG2: ");
		C11_BCRdData(msg2,dwd,2,handle);
		for (temp=0;temp<2;++temp) printf("%04X ",dwd[temp]);

/**
*
*  Read the received data associated with message 3 and
*  display on the screen.
*
**/

		printf("  MSG3: ");
		C11_BCRdData(msg3,dwd,3,handle);
		for (temp=0;temp<3;++temp) printf("%04X ",dwd[temp]);
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
