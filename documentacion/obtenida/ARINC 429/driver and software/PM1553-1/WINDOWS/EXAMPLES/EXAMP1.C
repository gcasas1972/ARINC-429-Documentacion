/**
*
*  PM1553-1 EXAMPLE 1  Version 1.0  (04/04/2006)
*  Copyright (c) 2002-2006
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- "Example of BC Mode."
*
**/

/**
*
*  EXAMP1.C:  Example bus controller application for PM1553-1.
*
*  Repeatedly transmit two 50 millisecond frames
*  Frame 1 = Message A, Message B, and optionally Message C
*  Frame 2 = Message B and optionally Message C
*  Message A: TA=3, TR=1, SA=0Ch, WC=4 (CWD=1D84h)
*  Message B: TA=9, TR=0, SA=0Eh, WC=2 (CWD=49C2h)
*  Message C: TA=9, TR=1, SA=0Fh, WC=18h (CWD=4DF8h)
*
*  Transmit Message C only if SRQ bit is set in status word of Message B
*
**/

#include <stdio.h>
#include <conio.h>
#include "pm11.h"
#include <windows.h>

VOID PM11Ex1_ConfigSummitBC(USHORT port);

VOID main(VOID)
{
	HANDLE hCard;

	USHORT port;    // PM1553-1 port setting
	USHORT data1;
	USHORT data2;

	fprintf(stderr,"\nEXAMP1  Version 1.0  (04/04/2006)");
	fprintf(stderr,"\nCopyright 2002-2006  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"BC transmission with schedule and interrupts.\"");
	fprintf(stderr,"\n");

	port = 0x2C0;   // Intialize port value

	//
	//	Open the card using the'SymbolicName' from the
	// .INF or .REG file, but with the prefix '\\\\.\\'
	//

	hCard = PM11_CardOpen("\\.\\\\PM1553Card", port);

	if (hCard==PM11_INVALID_HANDLE)
	{
		printf("\nFAILED: Could not open card");
		return;
	}

	if (hCard==PM11_ERRMEM_HANDLE)
	{
		printf("\nFAILED: Not enough memory");
		printf("\n        Increase PM41_MAXCARDS");
		return;
	}

	printf("\nOpened card %08lX at %03XH",hCard,port);

	//
	//	Configure SUMMIT
	//

	PM11Ex1_ConfigSummitBC(port);     // Configure SUMMIT (See below)

	//
	//	Start SUMMIT
	//

	PM11_SummitStart(port);           // Start the SUMMIT

	//
	//	Process data: The following code copies data words from Message A to Message B
	//

	fprintf(stderr,"\nPress any key to exit...");

	while(!kbhit())  //  Loop until a key is pressed
	{
		// Get first two data words from Message A
		data1 = PM11_SummitRd(0x1000,port);
		data2 = PM11_SummitRd(0x1001,port);

		// Copy to first two data words for Message B
		PM11_SummitWr(data1,0x2000,port);
		PM11_SummitWr(data2,0x2001,port);
	}

	//
	//	Stop the SUMMIT
	//

	PM11_SummitStop(port);    // Stop Summit operation

	//
	//	Close the card
	//

	PM11_CardClose(port);     // Close card
}

/**
*
*  PM11Ex1_ConfigSummitBC()
*  Configures the PM1553-1 Summit as a Bus Controller
*  Arguments:
*    port: PM1553-1 port setting
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex1_ConfigSummitBC(USHORT port)
{
	while (!PM11_SummitIsReady(port));  // Wait for Summit ready

	PM11_SummitWr(0x0002,0x0000,port);  // Reg  0 - Note STEX is disabled, Int log list enabled
	PM11_SummitWr(0x0000,0x0001,port);  // Reg  1 - Configured for BC
	PM11_SummitWr(0x0000,0x0002,port);  // Reg  2 - Current Command Reg
	PM11_SummitWr(0x0002,0x0003,port);  // Reg  3 - Enable Interrupt
	PM11_SummitWr(0x0000,0x0004,port);  // Reg  4 - Pending Int Reg
	PM11_SummitWr(0x4000,0x0005,port);  // Reg  5 - Int Log List Ptr Reg
	PM11_SummitWr(0x0000,0x0006,port);  // Reg  6 - BIT Word Reg
	PM11_SummitWr(0x0000,0x0007,port);  // Reg  7 - Time-Tag Reg
	PM11_SummitWr(0x0020,0x0008,port);  // Reg  8 - Points to first command block
	PM11_SummitWr(0x0000,0x0009,port);  // Reg  9 - 1553 Stat Word Bits Reg
	PM11_SummitWr(0x0000,0x000A,port);  // Reg 10 - BC Cmd Block Init Count Reg
	PM11_SummitWr(0x0000,0x000B,port);  // Reg 11 - Initial Mon Block Ptr Reg
	PM11_SummitWr(0x0000,0x000C,port);  // Reg 12 - Initial Mon Data Ptr Reg
	PM11_SummitWr(0x0000,0x000D,port);  // Reg 13 - Mon Block Counter Reg
	PM11_SummitWr(0x0000,0x000E,port);  // Reg 14 - Mon Filter Reg
	PM11_SummitWr(0x0000,0x000F,port);  // Reg 15 - Mon Filter Reg

	PM11_SummitWr(0x0000,0x0010,port);  // Illegal - Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,0x0011,port);  // Illegal - Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,0x0012,port);  // Illegal - Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,0x0013,port);  // Illegal - Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,0x0014,port);  // Illegal - Broadcast Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,0x0015,port);  // Illegal - Broadcast Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,0x0016,port);  // Illegal - Broadcast Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,0x0017,port);  // Illegal - Broadcast Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,0x0018,port);  // Illegal - Mode Code Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,0x0019,port);  // Illegal - Mode Code Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,0x001A,port);  // Illegal - Mode Code Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,0x001B,port);  // Illegal - Mode Code Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,0x001C,port);  // Illegal - Mode Code Broadcast Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,0x001D,port);  // Illegal - Mode Code Broadcast Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,0x001E,port);  // Illegal - Mode Code Broadcast Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,0x001F,port);  // Illegal - Mode Code Broadcast Xmt Subaddr 16-31

	// Each section of 8 SummitWr() statements below is a BC command block.
	// Blocks are numbered for reference. The main BC schedule is blocks 0-5.
	// The branch is blocks 6-8.

	// Block 0
	PM11_SummitWr(0xE000,0x0020,port);	// Load minor frame timer
	PM11_SummitWr(0x0000,0x0021,port);
	PM11_SummitWr(0x0000,0x0022,port);
	PM11_SummitWr(0x0000,0x0023,port);
	PM11_SummitWr(0x0000,0x0024,port);
	PM11_SummitWr(0x0000,0x0025,port);
	PM11_SummitWr(0x0000,0x0026,port);
	PM11_SummitWr(0x030E,0x0027,port);	// Timer value = 50ms

	// Block 1
	PM11_SummitWr(0x4200,0x0028,port);	// Transmit Message A
	PM11_SummitWr(0x1D84,0x0029,port);	// Message A command word
	PM11_SummitWr(0x0000,0x002A,port);
	PM11_SummitWr(0x1000,0x002B,port);	// Message A data pointer
	PM11_SummitWr(0x0000,0x002C,port);
	PM11_SummitWr(0x0000,0x002D,port);
	PM11_SummitWr(0x0000,0x002E,port);
	PM11_SummitWr(0x0000,0x002F,port);

	// Block 2
	PM11_SummitWr(0x6202,0x0030,port);	// Transmit Message B, branch on condition to block 6
	PM11_SummitWr(0x49C2,0x0031,port);	// Message B command word
	PM11_SummitWr(0x0000,0x0032,port);
	PM11_SummitWr(0x2000,0x0033,port);	// Message B data pointer
	PM11_SummitWr(0x0000,0x0034,port);
	PM11_SummitWr(0x0000,0x0035,port);
	PM11_SummitWr(0x0050,0x0036,port);	// Branch address (block 6)
	PM11_SummitWr(0x0000,0x0037,port);

	// Block 3
	PM11_SummitWr(0xE000,0x0038,port);	// Load minor frame timer
	PM11_SummitWr(0x0000,0x0039,port);
	PM11_SummitWr(0x0000,0x003A,port);
	PM11_SummitWr(0x0000,0x003B,port);
	PM11_SummitWr(0x0000,0x003C,port);
	PM11_SummitWr(0x0000,0x003D,port);
	PM11_SummitWr(0x0000,0x003E,port);
	PM11_SummitWr(0x030E,0x003F,port);	// Timer value = 50ms

	// Block 4
	PM11_SummitWr(0x6202,0x0040,port);	// Transmit Message B, branch on condition to block 6
	PM11_SummitWr(0x49C2,0x0041,port);	// Message B command word
	PM11_SummitWr(0x0000,0x0042,port);
	PM11_SummitWr(0x2000,0x0043,port);	// Message B data pointer
	PM11_SummitWr(0x0000,0x0044,port);
	PM11_SummitWr(0x0000,0x0045,port);
	PM11_SummitWr(0x0050,0x0046,port);	// Branch address (block 6)
	PM11_SummitWr(0x0000,0x0047,port);

	// Block 5
	PM11_SummitWr(0x2000,0x0048,port);	// Goto
	PM11_SummitWr(0x0000,0x0049,port);
	PM11_SummitWr(0x0000,0x004A,port);
	PM11_SummitWr(0x0000,0x004B,port);
	PM11_SummitWr(0x0000,0x004C,port);
	PM11_SummitWr(0x0000,0x004D,port);
	PM11_SummitWr(0x0020,0x004E,port);	// Address of first command block 
	PM11_SummitWr(0x0000,0x004F,port);

	// Block 6
	PM11_SummitWr(0x4200,0x0050,port);	// Transmit Message C
	PM11_SummitWr(0x4DF8,0x0051,port);	// Message C command word
	PM11_SummitWr(0x0000,0x0052,port);
	PM11_SummitWr(0x3000,0x0053,port);	// Message C data pointer
	PM11_SummitWr(0x0000,0x0054,port);
	PM11_SummitWr(0x0000,0x0055,port);
	PM11_SummitWr(0x0000,0x0056,port);
	PM11_SummitWr(0x0000,0x0057,port);

	// Block 7
	PM11_SummitWr(0xA000,0x0058,port);	// Issue interrupt
	PM11_SummitWr(0x0000,0x0059,port);
	PM11_SummitWr(0x0000,0x005A,port);
	PM11_SummitWr(0x0000,0x005B,port);
	PM11_SummitWr(0x0000,0x005C,port);
	PM11_SummitWr(0x0000,0x005D,port);
	PM11_SummitWr(0x0000,0x005E,port);
	PM11_SummitWr(0x0000,0x005F,port);

	// Block 8
	PM11_SummitWr(0xF000,0x0060,port);	// Return from branch 
	PM11_SummitWr(0x0000,0x0061,port);
	PM11_SummitWr(0x0000,0x0062,port);
	PM11_SummitWr(0x0000,0x0063,port);
	PM11_SummitWr(0x0000,0x0064,port);
	PM11_SummitWr(0x0000,0x0065,port);
	PM11_SummitWr(0x0000,0x0066,port);
	PM11_SummitWr(0x0000,0x0067,port);

	// Data initialization

	PM11_SummitWr(0x0000,0x1000,port);	// Initialize data words for Message A
	PM11_SummitWr(0x0000,0x1001,port);	// These values will be overwritten by
	PM11_SummitWr(0x0000,0x1002,port);	// the data words transmitted by RT-A
	PM11_SummitWr(0x0000,0x1003,port);

	PM11_SummitWr(0x1234,0x2000,port);	// Initialize data words for Message B
	PM11_SummitWr(0x5678,0x2001,port);	// These values are received by RT-B

	PM11_SummitWr(0x0000,0x3000,port);	// Initialize data words for Message C
	PM11_SummitWr(0x0000,0x3001,port);
	PM11_SummitWr(0x0000,0x3002,port);
	PM11_SummitWr(0x0000,0x3003,port);
	PM11_SummitWr(0x0000,0x3004,port);
	PM11_SummitWr(0x0000,0x3005,port);
	PM11_SummitWr(0x0000,0x3006,port);
	PM11_SummitWr(0x0000,0x3007,port);
	PM11_SummitWr(0x0000,0x3008,port);
	PM11_SummitWr(0x0000,0x3009,port);
	PM11_SummitWr(0x0000,0x300A,port);
	PM11_SummitWr(0x0000,0x300B,port);
	PM11_SummitWr(0x0000,0x300C,port);
	PM11_SummitWr(0x0000,0x300D,port);
	PM11_SummitWr(0x0000,0x300E,port);
	PM11_SummitWr(0x0000,0x300F,port);
	PM11_SummitWr(0x0000,0x3010,port);
	PM11_SummitWr(0x0000,0x3011,port);
	PM11_SummitWr(0x0000,0x3012,port);
	PM11_SummitWr(0x0000,0x3013,port);
	PM11_SummitWr(0x0000,0x3014,port);
	PM11_SummitWr(0x0000,0x3015,port);
	PM11_SummitWr(0x0000,0x3016,port);
	PM11_SummitWr(0x0000,0x3017,port);
}
