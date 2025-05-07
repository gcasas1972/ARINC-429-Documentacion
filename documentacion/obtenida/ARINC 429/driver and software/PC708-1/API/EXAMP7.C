
/**
*
*  PC708-1 DRIVER EXAMPLE 7  Version 1.0  (03/05/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP7.C -- Example 7.
*                      "Header extraction example"
*
*  Compiling commands:
*  Microsoft:  cl examp7.c p71w32.lib kernel32.lib
*
**/

/**
*
*  This example configures the PC708-1 to receive messages.  
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
#include "p71w32.h"

#define	MEMBASE 0xCC00				/*Memory address of PC708-1 card*/
#define IOBASE  0x2C0				/*I/O address of PC708-1 card*/
#define	IRQCHAN 2					/*Interrupt channel of PC708-1 card*/
#define	DMACHAN 1					/*DMA channel of PC708-1 card*/

USHORT Data[100];					/*Data buffer to receive a message*/

HCARD Card;							/*Handle of card to access*/

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
		
	fprintf(stderr,"\nEXAMP7  Version 1.0  (03/05/1999)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC708-1 Example 7");
	fprintf(stderr,"\n\"Header extraction example\"");
	fprintf(stderr,"\n");

/**
*
*  Open the PC708-1 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = PC708_CardOpen(MEMBASE,IOBASE,IRQCHAN,DMACHAN);	/*Open the PC708-1 card*/

	if (Card < 0)
	{
		printf("\nError:  Either a PC708-1 is not present at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        or an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

	PC708_CardReset(Card);

/**
*
*  Configure the receiver of the PC708-1 card.
*
**/

	errval = PC708_RcvConfigEx(RCVCFG_DEFAULT,intfreq,Card);			/*Configure the PC708-1 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the receiver.",errval);
		PC708_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin receiving.
*
**/

	PC708_CardStart(Card);

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
*  it on the screen.  The function PC708_RcvRd returns 
*  after updating the data buffer with the most current
*  data.
*
*  Note: Interrupts are generated at the frequency "intfreq".
*
**/

		if(PC708_IntStatus(Card) != STAT_EMPTY)
		{
			PC708_IntRd(NULL,&intnum,Card);

			PC708_RcvRd(Data,Card);

			printf("\nLabel:          %02X (Hex)  %o (Oct)",PC708_FieldGetLabel(Data),PC708_FieldGetLabel(Data));
			printf("\nControl Accept: %04X (Hex)",PC708_FieldGetControlAccept(Data));
			printf("\nBits 16-11:     %02X (Hex)",(Data[0] >> 10) & 0x003F);
			printf("\nBits 26-17:     %03X (Hex)",Data[1] & 0x03FF);
			printf("\nMode:           %04X (Hex)",PC708_FieldGetMode(Data));
			printf("\nTilt:           %04X (Hex)  %f (Dec)",PC708_FieldGetTilt(Data),PC708_FieldGetTiltFl(Data));
			printf("\nGain:           %d (Dec)",PC708_FieldGetGain(Data));
			printf("\nRange:          %d (Dec)",PC708_FieldGetRange(Data));
			printf("\nBit 49:         %01X (Hex)",Data[4] & 0x0001);
			printf("\nData Accept:    %04X (Hex)",PC708_FieldGetDataAccept(Data));
			printf("\nScan Angle:     %04X (Hex)  %f (Dec)",PC708_FieldGetAngle(Data),PC708_FieldGetAngleFl(Data));
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

	PC708_CardStop(Card);						/*Stop the card*/

/**
*
*  The PC708-1 card MUST be closed before exiting the program.
*
**/

	PC708_CardClose(Card);					/*Close the card*/

/**
*
*  Move to bottom of screen.
*
**/

	consolepos.X =  0;
	consolepos.Y = 24;
	SetConsoleCursorPosition(hConsole,consolepos);

}
