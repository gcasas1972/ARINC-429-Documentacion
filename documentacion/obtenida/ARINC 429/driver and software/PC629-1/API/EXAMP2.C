
#include <windows.h>
#include <stdio.h>
#include "p61w32.h"

/**
*
*   PC629-1 EXAMPLE 2 PROGRAM  Version 1.0  (07/05/2002)
*   Copyright (c) 1999-2002
*   Ballard Technology, Inc.
*   www.ballardtech.com
*   support@ballardtech.com
*   ALL RIGHTS RESERVED
*
*   NAME:   EXAMP2.C -- Landing Gear Simulator Program.
*
**/

/**
*
*   This program implements the landing gear simulator
*   described in Section 3.3 of the PC629-1 User's Manual. 
*   It recevies label 134H with one data word representing
*   the position of the lever.  It then transmits label 064H
*   with one data word simulated from three different
*   terminals.  Each of the three data words represents a
*   landing gear position which it modified depending upon
*   the lever position.
*
*   To compile this program with the Microsoft C++ compiler,
*   use the following command line:
*
*   CL EXAMP2.C P61W32.LIB
*
*   To compile this program with the Borland C++ compiler, use
*   the following command line:
*
*   BCC32 EXAMP2.C P61W32.LIB
*
**/

LPCSTR szScriptName = "EXAMP2.ROM";

HCARD handleval;

/**
*
*  This is the foreground processing thread.  It writes the
*  lever position to RAM and reads the three gear positions
*  from RAM.
*
**/

VOID Foreground()
{
	WORD wLever;
	WORD wLeftGear;
	WORD wRightGear;
	WORD wNoseGear;

	wLever  = PC629_RamRdW(0,0x40,handleval);				//Read lever position

	wLeftGear  = PC629_RamRdW(0,0x60,handleval);			//Read old left gear position
	wRightGear = PC629_RamRdW(0,0x61,handleval);			//Read old right gear position
	wNoseGear  = PC629_RamRdW(0,0x62,handleval);			//Read old nose gear position

	wLeftGear  = (wLeftGear  > 0x80) ? 0x80 : wLeftGear;	//Put position in bounds
	wRightGear = (wRightGear > 0x80) ? 0x80 : wRightGear;	//Put position in bounds
	wNoseGear  = (wNoseGear  > 0x80) ? 0x80 : wNoseGear;	//Put position in bounds

	if (wLever==1)											//If lever in up position
	{
		if (wLeftGear  != 0x00) --wLeftGear;				//Move left gear up
		if (wRightGear != 0x00) --wRightGear;				//Move right gear up
		if (wNoseGear  != 0x00) --wNoseGear;				//Move nose gear up
	}
	else if (wLever==2)										//If lever in down position
	{
		if (wLeftGear  != 0x80) ++wLeftGear;				//Move left gear down
		if (wRightGear != 0x80) ++wRightGear;				//Move right gear down
		if (wNoseGear  != 0x80) ++wNoseGear;				//Move nose gear down
	}

	PC629_RamWrW(0,0x60,wLeftGear, handleval);				//Write left gear position
	PC629_RamWrW(0,0x61,wRightGear,handleval);				//Write right gear position
	PC629_RamWrW(0,0x62,wNoseGear, handleval);				//Write nose gear position

/**
*
*  Display value of the lever, gears, and error register.
*
**/

	printf("\r");
	printf("Lever=%04X ",          wLever);
	printf("Gear=%04X/%04X/%04X ", wLeftGear,wNoseGear,wRightGear);
	printf("Err=%04X ",            PC629_RegRdErr(handleval));
	printf("Status=%02X ",         PC629_RegRdStatus(handleval));
	printf("LWM=%04X ",            PC629_RegRdLWM(handleval));
}

VOID main(VOID)
{
	ERRVAL errval;
	INT ch;
	BOOL done;
	INT j;

	fprintf(stderr,"\nEXAMP2  Version 1.0  (07/05/2002)");
	fprintf(stderr,"\nCopyright 1999-2002  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nExample 2 - Landing Gear Simulator Program");
	fprintf(stderr,"\n");

/**
*
*   The following statement checks for the presence of a
*   PC629-1 card.
*
**/

	handleval = PC629_CardOpenEx(0);

	if (handleval<0)					//Check for card
	{
		printf("\nUnable to open PC629-1 card number %u (%i).",0,handleval);
		exit(1);
	}

/**
*
*   Reset the PC629-1 card.
*
**/

	PC629_Reset(handleval);

/**
*
*  Load the ROM file EXAMP2.ROM into the card.
*
**/

	if (PC629_FileLoad(szScriptName,handleval))
	{
		printf("\nError:  Unable to load the file %s.",szScriptName);
		PC629_CardClose(handleval);
		exit(0);
	}

/**
*
*  Display data.
*
**/

	printf("\nPress 'Q' to quit....");
	printf("\n");
	printf("\n");

	for (done=FALSE;!done;)
	{
		if (kbhit())
		{
			ch = getch();

			if (ch=='q' || ch=='Q')
			{
				done=TRUE;
			}
		}

		Foreground();
	}

/**
*
*   Stop the PC629-1 card.
*
**/

	PC629_Stop(handleval);

/**
*
*   Release the handle to the PC629-1 card.
*
**/

	PC629_CardClose(handleval);
}
