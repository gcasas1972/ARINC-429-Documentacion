
#include <windows.h>
#include <stdio.h>
#include "p61w32.h"

/**
*
*   PC629-1 EXAMPLE 6 PROGRAM  Version 1.0  (07/05/2002)
*   Copyright (c) 1999-2002
*   Ballard Technology, Inc.
*   www.ballardtech.com
*   support@ballardtech.com
*   ALL RIGHTS RESERVED
*
*   NAME:   EXAMP6.C -- PROM Dumping Program.
*
**/

/**
*
*   This program dumps the contents of the PROM on the PC629-1
*   card and displays it on the screen.
*
*   To compile this program with the Microsoft C++ compiler,
*   use the following command line:
*
*   CL EXAMP6.C P61W32.LIB
*
*   To compile this program with the Borland C++ compiler, use
*   the following command line:
*
*   BCC32 EXAMP6.C P61W32.LIB
*
**/

VOID main(VOID)
{
	HCARD handleval;
	ERRVAL errval;
	INT ch;
	BOOL done;
	INT j;

	fprintf(stderr,"\nEXAMP6  Version 1.0  (07/05/2002)");
	fprintf(stderr,"\nCopyright 1999-2002  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nExample 6 - PROM Dumping Program");
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
*   Loop through PROM and display data.
*
**/

	for (j=0;j<0x10000 && !kbhit();++j)
	{
		if (!(j%16))
		{
			printf("\n%08lX   ",j);
		}
		printf("%02X ",PC629_PromRdB(j,handleval));
	}

/**
*
*   Release the handle to the PC629-1 card.
*
**/

	PC629_CardClose(handleval);
}
