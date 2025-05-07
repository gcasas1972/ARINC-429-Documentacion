
/**
*
*  LP708-1 and LC708-1 DRIVER EXAMPLE 7  Version 1.0  (01/19/2001)
*  Copyright (c) 1999-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP7.C -- Example 7.
*                      "Header extraction example"
*
*  Compiling commands:
*  Microsoft:  cl examp7.c l71w32.lib kernel32.lib
*
**/

/**
*
*  This example configures the L71 to receive messages.  
*  The most current message is read out of the card and
*  the header information is broken out and displayed to
*  the screen.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include "l71w32.h"

#define	CARDNUM 0                   /*Card number of L71 card*/

USHORT Data[100];                   /*Data to transmit*/

HCARD Card;                         /*Handle of card to access*/

HANDLE hConsole;
COORD consolepos;

void main(void)
{
	ERRVAL  errval;
	ULONG   j;
	USHORT  intnum;	
	USHORT  intfreq = 1;

/**
*
*  Create a display window.
*
**/

	hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

	consolepos.X =  0;
	consolepos.Y =  0;
	SetConsoleCursorPosition(hConsole,consolepos);

	FillConsoleOutputCharacter(hConsole,' ',2000,consolepos,&j);

	consolepos.X =  0;
	consolepos.Y =  0;
	SetConsoleCursorPosition(hConsole,consolepos);
		
	fprintf(stderr,"\nEXAMP7  Version 1.0  (01/19/2001)");
	fprintf(stderr,"\nCopyright 1999-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP708-1 and LC708-1 Example 7");
	fprintf(stderr,"\n\"Header extraction example\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L71 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L71_CardOpen(CARDNUM);                     /*Open the L71 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L71 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

	L71_CardReset(Card);

/**
*
*  Configure the receiver of the L71 card.
*
**/

	errval = L71_RcvConfigEx(RCVCFG_DEFAULT,intfreq,Card);    /*Configure the L71 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the receiver.",errval);
		L71_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin receiving.
*
**/

	L71_CardStart(Card);

/**
*
*  Move to display window.
*
**/

	consolepos.X = 0;
	consolepos.Y = 8;
	SetConsoleCursorPosition(hConsole,consolepos);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.\n");
	
	while (!_kbhit())
	{

/**
*
*  Poll the interrupt log list until it contains an entry. 
*  Then, read the interrupt log list to clear that entry.
*  Read the most current data out of the card and display
*  it on the screen.  The function L71_RcvRd returns 
*  after updating the data buffer with the most current
*  data.
*
*  Note: Interrupts are generated at the frequency "intfreq".
*
**/

		if(L71_IntStatus(Card) != STAT_EMPTY)
		{
			L71_IntRd(NULL,&intnum,Card);

			L71_RcvRd(Data,Card);

			printf("\nLabel:          %02X (Hex)  %o (Oct)",L71_FieldGetLabel(Data),L71_FieldGetLabel(Data));
			printf("\nControl Accept: %04X (Hex)",L71_FieldGetControlAccept(Data));
			printf("\nBits 16-11:     %02X (Hex)",(Data[0] >> 10) & 0x003F);
			printf("\nBits 26-17:     %03X (Hex)",Data[1] & 0x03FF);
			printf("\nMode:           %04X (Hex)",L71_FieldGetMode(Data));
			printf("\nTilt:           %04X (Hex)  %f (Dec)",L71_FieldGetTilt(Data),L71_FieldGetTiltFl(Data));
			printf("\nGain:           %d (Dec)",L71_FieldGetGain(Data));
			printf("\nRange:          %d (Dec)",L71_FieldGetRange(Data));
			printf("\nBit 49:         %01X (Hex)",Data[4] & 0x0001);
			printf("\nData Accept:    %04X (Hex)",L71_FieldGetDataAccept(Data));
			printf("\nScan Angle:     %04X (Hex)  %f (Dec)",L71_FieldGetAngle(Data),L71_FieldGetAngleFl(Data));
			printf("\nBit 64:         %01X (Hex)",(Data[4] >> 15) & 0x0001);

			printf("\nInterrupt Number: %04X",intnum);
			
			consolepos.X =  0;
			consolepos.Y = 10;
			SetConsoleCursorPosition(hConsole,consolepos);
		}
	}

/**
*
*  Stop the card to disable receiver.
*
**/

	L71_CardStop(Card);

/**
*
*  The L71 card MUST be closed before exiting the program.
*
**/

	L71_CardClose(Card);

/**
*
*  Move to bottom of screen.
*
**/

	consolepos.X =  0;
	consolepos.Y = 24;
	SetConsoleCursorPosition(hConsole,consolepos);

}
