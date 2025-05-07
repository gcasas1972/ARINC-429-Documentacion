
/**
*
*  LP708-1 and LC708-1 DRIVER EXAMPLE 5  Version 1.0  (01/19/2001)
*  Copyright (c) 1999-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP5.C -- Example 5.
*                      "Receiver Sequential Record example"
*
*  Compiling commands:
*  Microsoft:  cl examp5.c l71w32.lib kernel32.lib
*
**/

/**
*
*  This example configures the L71 to receive messages.  
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
#include "l71w32.h"

#define	CARDNUM 0                   /*Card number of L71 card*/

USHORT Data[110];                   /*Data to transmit*/

USHORT value;                       /*Used for return value from monitor*/
HCARD Card;                         /*Handle of card to access*/

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
		
	fprintf(stderr,"\nEXAMP5  Version 1.0  (01/19/2001)");
	fprintf(stderr,"\nCopyright 1999-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP708-1 and LC708-1 Example 5");
	fprintf(stderr,"\n\"Receiver Sequential Record example\"");
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

	errval = L71_RcvConfig(Card);          /*Configure the L71 card*/

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
*  The function L71_RcvMonRd returns a count of the data 
*  it updated in the data buffer.  The count will  be 0
*  meaning the sequential record was empty, or the count will
*  be 109 (9 overhead words, 100 data words).
*
**/
		value=L71_RcvMonRd(Data,Card);

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
