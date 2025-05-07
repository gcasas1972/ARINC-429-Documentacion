
/**
*
*  PC708-1 DRIVER EXAMPLE 8  Version 1.0  (05/14/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP8.C -- Example 8.
*                      "Delta Monitoring example"
*
*  Compiling commands:
*  Microsoft:  cl examp8.c p71w32.lib kernel32.lib
*
**/

/**
*
*  This example configures the P71 to transmit and receive
*  simueltaneously.  The tranmsitter is loaded with data
*  values that change at Range Bins 1, 129, 257, and 389.
*  The receiver is configured with the monitor in Delta mode.
*  The delta mode of the monitor will record the Range Bin
*  locations at which the data has changed.  
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

#define	FRAMEFREQ	50              /*Frame frequency of 50Hz*/
#define INTFREQ		2               /*Generate an interrupt after every 2nd message*/
#define	FRAMECOUNT	4               /*Transmit a total of 4 messages*/

USHORT XmtData[100];                /*Data to transmit message*/
USHORT RcvData[110];                /*Data to receive message*/

HANDLE hConsole;
COORD consolepos;

void main(void)
{
	USHORT value;
	HCARD Card;
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
		
	fprintf(stderr,"\nEXAMP8  Version 1.0  (05/14/1999)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC708-1 Example 8");
	fprintf(stderr,"\n\"Delta Monitoring example\"");
	fprintf(stderr,"\n");

/**
*
*  Open the P71 card at the specified memory and I/O
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
*  Configure the transmitter of the P71 card.
*
**/

	errval = PC708_XmtConfig(FRAMEFREQ,Card);	/*Configure the P71 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the transmitter.",errval);
		PC708_CardClose(Card);
		exit(1);
	}

/**
*
*  Configure the receiver of the P71 card.
*
**/

	errval = PC708_RcvConfigExx(RCVCFG_BUSA,1,MONCFG_DELTA | MONCFG_64K,INTCFG_DEFAULT,1024,MSGCRT_TIMETAG+MSGCRT_INT,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the receiver.",errval);
		PC708_CardClose(Card);
		exit(1);
	}

/**
*
*  Create the data for the message.
*
**/

	for (j=1;j<=128;++j)
	{
		PC708_FieldPutData(0x0000,j,XmtData);
	}
	for (j=129;j<=256;++j)
	{
		PC708_FieldPutData(0x0001,j,XmtData);
	}
	for (j=257;j<=384;++j)
	{
		PC708_FieldPutData(0x0002,j,XmtData);
	}
	for (j=385;j<=512;++j)
	{
		PC708_FieldPutData(0x0003,j,XmtData);
	}

	for (j=0;j<110;++j)
	{
		RcvData[j]=0;
	}

/**
*
*  Write the data for the message.
*
**/

	PC708_XmtWr(XmtData,0,Card);		/*Write the data for message*/

/**
*
*  Start the card to begin transmissions.
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
*  it updated in the data buffer.  The count will be 0
*  if the sequential record was empty (no record to read),
*  or the count will reflect the total number of 16-bit words
*  read out of the monitor (9 overhead words + x data words).
*
*  Note: The version number for a delta mode monitor record
*  is 02.  A normal monitor record's version number is 01.
*
**/
		value = PC708_RcvMonRd(RcvData,Card);

		printf("Version/Count:%04X\n",RcvData[0]);
		printf("Time Stamp: %04X %04X\n",RcvData[2],RcvData[1]);
		printf("Activity: %04X\n",RcvData[3]);
		printf("Data Count: %04d\n",RcvData[5]);

		printf("\nARINC 708 Header: %04X %04X %04X %04X",
			RcvData[9],
			RcvData[10],
			RcvData[11],
			RcvData[12]);
		printf("\n");

		for (j=13;(j<value);j+=2)
		{
			printf("\nRange Bin: %d",RcvData[j+0]);
			printf("\nValue    : %d",RcvData[j+1]);
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
*  The P71 card MUST be closed before exiting the program.
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
