
#include <windows.h>
#include <stdio.h>
#include "p61w32.h"

/**
*
*   PC629-1 EXAMPLE 1 PROGRAM  Version 1.0  (07/05/2002)
*   Copyright (c) 1999-2002
*   Ballard Technology, Inc.
*   www.ballardtech.com
*   support@ballardtech.com
*   ALL RIGHTS RESERVED
*
*   NAME:   EXAMP1.C -- Cockpit Simulator Program.
*
**/

/**
*
*   This program implements the cockpit simulator described
*   in Section 3.3 of the PC629-1 User's Manual.  It
*   transmits label 134H with one data word representing the
*   position of the lever.  It also receives label 064H with
*   one data word from three different terminals representing
*   three landing gear positions.
*
*   To compile this program with the Microsoft C++ compiler,
*   use the following command line:
*
*   CL EXAMP1.C P61W32.LIB
*
*   To compile this program with the Borland C++ compiler, use
*   the following command line:
*
*   BCC32 EXAMP1.C P61W32.LIB
*
**/

LPCSTR szScriptName = "EXAMP1.ROM";

HCARD handleval;

BOOL Position = TRUE;					//Position of lever

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

	PC629_RamWrW(0,0x444,(Position) ? 0x0001:0x0002,handleval);		//Write lever position

	wLever     = PC629_RamRdW(0,0x444,handleval);			//Read lever position
	wLeftGear  = PC629_RamRdW(0,0x100,handleval);			//Read left gear position
	wRightGear = PC629_RamRdW(0,0x110,handleval);			//Read right gear position
	wNoseGear  = PC629_RamRdW(0,0x120,handleval);			//Read nose gear position

/**
*
*  Display value of the lever, gears, and error register.
*
**/

	printf("\r");
	printf("Pos=%01X ",            Position);
	printf("Lever=%04X ",          wLever);
	printf("Gear=%04X/%04X/%04X ", wLeftGear,wNoseGear,wRightGear);
	printf("Err=%04X ",            PC629_RegRdErr(handleval));
	printf("Status=%02X ",         PC629_RegRdStatus(handleval));
	printf("LWM=%04X ",            PC629_RegRdLWM(handleval));
}

VOID main(VOID)
{
	INT ch;
	ERRVAL errval;
	BOOL done;

	fprintf(stderr,"\nEXAMP1  Version 1.0  (07/05/2002)");
	fprintf(stderr,"\nCopyright 1999-2002  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nExample 1 - Cockpit Simulator Program");
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
*  Load the ROM file GEAR.ROM into the card.
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
*  Display the data.
*
**/

	printf("\nPress 'U' to set the lever position up.");
	printf("\nPress 'D' to set the lever position down.");
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

			if (ch=='u' || ch=='U')
			{
				Position = TRUE;	//Set position of lever up
			}

			if (ch=='d' || ch=='D')
			{
				Position = FALSE;	//Set position of lever down
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
