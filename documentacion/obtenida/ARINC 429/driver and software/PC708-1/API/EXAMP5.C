
/**
*
*  PC708-1 DRIVER EXAMPLE 5  Version 1.1  (07/28/1998)
*  Copyright (c) 1998
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP5.C -- Example 5.
*                      "Receiver Sequential Record example"
*
*  Compiling commands:
*  Microsoft:  cl examp5.c p71w32.lib kernel32.lib
*
**/

/**
*
*  This example configures the PC708-1 to receive messages.  
*  Data is read out of the sequential monitor, and the
*  record information is displayed on the screen.  
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

USHORT Data[110];					/*Data buffer to receive a message*/
USHORT value;						/*Used for return value from monitor*/
HCARD Card;							/*Handle of card to access*/

HANDLE hConsole;
COORD consolepos;

void main(void)
{
	ERRVAL  errval;
	ULONG  j;
	
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
		
	fprintf(stderr,"\nEXAMP5  Version 1.1  (07/28/1998)");
	fprintf(stderr,"\nCopyright 1998  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC708-1 Example 5");
	fprintf(stderr,"\n\"Receiver Sequential Record example\"");
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

	errval = PC708_RcvConfig(Card);			/*Configure the PC708-1 card*/

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

	consolepos.X =  0;
	consolepos.Y =  9;
	SetConsoleCursorPosition(hConsole,consolepos);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\t\t\tPress any key to exit.\n");
	
	while (!_kbhit())
	{

/**
*
*  Read the next record out of the sequential monitor, 
*  then display the different fields on the screen.  
*  The function PC708_RcvMonRd returns a count of the data 
*  it updated in the data buffer.  The count will  be 0
*  meaning the sequential record was empty, or the count will
*  be 109 (9 overhead words, 100 data words).
*
**/
		value=PC708_RcvMonRd(Data,Card);

		printf("Time Stamp: %04X %04X\n",Data[2],Data[1]);
		printf("Error Status: %s\n",(Data[3]) ? "Error":"None ");
		printf("Data Count: %04d\n",Data[5]);

		for (j=9;j<value;++j)
		{
			if (!((j-9)%10))
			{
				printf("\n%4u | ",(j-9));
			}
			printf("%04X ",Data[j]);
		}
		consolepos.X =  0;
		consolepos.Y = 10;
		SetConsoleCursorPosition(hConsole,consolepos);
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
