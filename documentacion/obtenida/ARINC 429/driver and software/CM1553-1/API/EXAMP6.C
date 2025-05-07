
#include "c11w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM1553-1 DRIVER EXAMPLE 6  Version 1.0  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP6.C -- Example 6 from Section 4.2.3.
*                      "BC transmission of conditional messages."
*
**/

/**
*
*  This program is identical to Example 3 except that message
*  1 is slightly modified.  If a response error occurs in
*  message 1, a conditional message is transmitted.
*
**/

void main(void)
{
	HCARD handle;							/*Handle of CM1553-1 card*/
	INT errormsg;							/*Index of conditional message*/
	INT msg1;								/*Index of message #1*/
	INT msg2;								/*Index of message #2*/
	INT msg3;								/*Index of message #3*/
	INT frame1;								/*Index of frame #1*/
	INT frame2;								/*Index of frame #2*/
	INT frame3;								/*Index of frame #3*/
	INT temp;								/*Temporary variable*/
	USHORT errorcwd = 0x0C24;				/*Command word for conditional message*/
	USHORT cwd1 = 0x0C21;					/*Command word for message #1*/
	USHORT cwd2 = 0x0C22;					/*Command word for message #2*/
	USHORT cwd3 = 0x0C23;					/*Command word for message #3*/
	USHORT dwd[32];							/*Holds data words read from card*/

	fprintf(stderr,"\nEXAMP6  Version 1.0  (04/09/1999)");
	fprintf(stderr,"\nCopyright 1997,1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"BC transmission of conditional messages.\"");
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
*  Create a conditional message.
*
**/
  
	errormsg = C11_BCDoMsg(BUSA,errorcwd,NULL,handle);
	C11_BCBranchEnd(handle);

/**
*
*  Create 3 frames, each containing one or more messages. 
*  Note that message 1 will perform a branch is a response
*  error occurs.
*
**/

	frame1 = C11_BCFrameStart(10,handle);
	msg1   = C11_BCDoMsg(BUSA,cwd1,NULL,handle);
	C11_BCMsgBranch(msg1,errormsg,COND_RESPERR,handle);
	msg2   = C11_BCDoMsg(BUSA,cwd2,NULL,handle);
	msg3   = C11_BCDoMsg(BUSA,cwd3,NULL,handle);
	C11_BCFrameEnd(handle);
	
	frame2 = C11_BCFrameStart(10,handle);
	C11_BCDoAgain(msg1,handle);
	C11_BCFrameEnd(handle);

	frame3 = C11_BCFrameStart(10,handle);
	C11_BCDoAgain(msg1,handle);
	C11_BCDoAgain(msg2,handle);
	C11_BCFrameEnd(handle);

/**
*
*  Place the frames into the cycle by inserting them in the
*  order they will be transmitted.
*
**/

	C11_BCCallFrame(frame1,handle);
	C11_BCCallFrame(frame2,handle);
	C11_BCCallFrame(frame3,handle);
	C11_BCCallFrame(frame2,handle);

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

		printf(" MSG1:");
		C11_BCRdData(msg1,dwd,1,handle);
		for (temp=0;temp<1;++temp) printf("%04X ",dwd[temp]);

/**
*
*  Read the received data associated with message 2 and
*  display on the screen.
*
**/

		printf(" MSG2:");
		C11_BCRdData(msg2,dwd,2,handle);
		for (temp=0;temp<2;++temp) printf("%04X ",dwd[temp]);

/**
*
*  Read the received data associated with message 3 and
*  display on the screen.
*
**/

		printf(" MSG3:");
		C11_BCRdData(msg3,dwd,3,handle);
		for (temp=0;temp<3;++temp) printf("%04X ",dwd[temp]);

/**
*
*  Read the received data associated with the conditional
*  message and display on the screen.
*
**/

		printf(" ERRORMSG:");
		C11_BCRdData(errormsg,dwd,4,handle);
		for (temp=0;temp<4;++temp) printf("%04X ",dwd[temp]);
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
