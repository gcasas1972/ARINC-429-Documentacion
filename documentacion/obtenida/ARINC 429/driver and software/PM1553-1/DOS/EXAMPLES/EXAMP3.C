/**
*
*  PM1553-1 EXAMPLE 3  Version 1.0  (04/15/2002)
*  Copyright (c) 2002
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- "Example of Monitor Mode."
*
**/

/**
*
*  EXAMP3.C:  Example Monitor application for PM1553-1
*  This program opens the PM1553-1 card and
*  configures it to monitor all RT terminal
*  addresses.
*
*  After starting the card, it polls the monitor and
*  retrieves information on all messages received.  Only 
*  receive messages to terminal address 0 and subaddress 12
*  with 4 data words are of interest (i.e., command word =
*  0184). The command word and four associated data words
*  are printed along with some useful monitor index information.
*  
*  It also detects when the Summit overruns the monitor
*  buffer and halts the Summit.
*
*  At any time, the user can press a key to exit the program.
*
**/

#include <stdio.h>
#include <conio.h>
#include "pm11.h"

#define SUMMIT_MEMORY_SIZE  0x7FFF  // Size of Summit's memory in words
#define MON_CMD_LOC         0x100   // Starting address of monitor command blocks
#define MON_DATA_LOC        0x1000  // Starting address of monitor data
#define NMON_BLKS           10      // Number of monitor blocks

// Prototypes
VOID   PM11Ex3_SummitWipe(USHORT port);
VOID   PM11Ex3_ConfigSummitMon(USHORT port);
USHORT PM11Ex3_MonCount(USHORT port);
USHORT PM11Ex3_MonAddrBlk(USHORT index);

VOID main(VOID)
{
	INT previndex;                          // Previous Summit index into monitor buffer
	INT currindex;                          // Current index into monitor buffer
	INT nextindex;                          // Summit's next index into monitor buffer

	USHORT port;    // PM1553-1 port setting
	USHORT cwd;
	USHORT data[32];                        // 16-bit data words
	USHORT mbaddr, info, dataptr, i;

	fprintf(stderr,"\nEXAMP3  Version 1.0  (04/15/2002)");
	fprintf(stderr,"\nCopyright 2002  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Continuous Monitor Mode.\"");
	fprintf(stderr,"\nDisplay only CWD = 0184 messages");

	port = 0x2C0;		// initialize port setting

/**
*
*  Configure the PM1553-1 card as a monitor using the default
*  settings.  The card will hold a maximum 512 messages.
*
**/

	PM11Ex3_ConfigSummitMon(port); // Configure Summit (See below)

	// Activate the PM1553-1 card.  The card will begin to record
	// all bus activity.
	PM11_SummitStart(port);

	// Until a key is pressed by the user, display all bus
	// traffic on the screen.
	fprintf(stderr,"\nPress a key to exit....\n\n");

	nextindex = currindex = NMON_BLKS;    // Reset variables to empty condition

	while(!kbhit())
	{
		previndex = nextindex;            // Cache Summit's previous index

		nextindex = PM11Ex3_MonCount(port);  // Get Summit's next index

		if ((previndex<currindex && nextindex>currindex) ||  // If Summit has overrun...
			(nextindex<previndex && currindex>previndex) ||
			(currindex<nextindex && previndex>nextindex))
		{
			PM11_SummitStop(port);                           // ...stop Summit
			printf("\nThe Summit has been stopped!");
			break;
		}

		if (nextindex != currindex)                     // Wait for count to change
		{
			++currindex;                                // Increment index

			if (currindex>NMON_BLKS) currindex=1;               // Wrap around
			
			mbaddr = PM11Ex3_MonAddrBlk((USHORT)currindex);   // Get the block address
			info   = PM11_SummitRd(mbaddr, port);               // Get the info word
			cwd    = PM11_SummitRd((USHORT) (mbaddr+1), port);  // Get the command word

			if ((cwd == 0x0184) && !(info & 0x0080))            // Check for right cwd and no errors
			{
				dataptr = PM11_SummitRd((USHORT)(mbaddr+3), port); // Get address of the data

				for(i=0;i<4;i++)                                // Get 4 data words
				{
					data[i] = PM11_SummitRd(dataptr++,port);
				}

				// Print the current values
				printf("CWD=%04X  DATA(1)=%04X  (2)=%04X  (3)=%04X  (4)=%04X P=%02X C=%02X N=%02X\r",
				   cwd,data[0],data[1],data[2],data[3],previndex,currindex,nextindex);
			}
		}
	}

	PM11_SummitStop(port); //  Stop the PM1553-1 card.

}

/**
*
*  PM11Ex3_SummitWipe()
*  Clears all Summit registers and memory
*  Arguments:
*     port: PM1553-1 port setting
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex3_SummitWipe(USHORT port)
{
	UINT i = 0 ; // index

	while (i <= SUMMIT_MEMORY_SIZE)
	{
		PM11_SummitWr(0, (USHORT)i++, port);
	}
}

/**
*
*  PM11Ex3_ConfigSummitMon()
*  Configures the PM1553-1 Summit as a Monitor
*  Arguments:
*     port: PM1553-1 port setting
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex3_ConfigSummitMon(USHORT port)
{
	PM11_SummitWr(0x0000,0x0000,port);  // Reg  0 - Note STEX is disabled
	PM11_SummitWr(0x0200,0x0001,port);  // Reg  1 - Configured for monitor mode
	PM11_SummitWr(0x0000,0x0002,port);  // Reg  2 - Current Command Reg
	PM11_SummitWr(0x0002,0x0003,port);  // Reg  3 - Enable interrupt
	PM11_SummitWr(0x0000,0x0004,port);  // Reg  4 - Pending Int Reg
	PM11_SummitWr(0x0000,0x0005,port);  // Reg  5 - Int Log List Ptr Reg
	PM11_SummitWr(0x0000,0x0006,port);  // Reg  6 - BIT Word Reg
	PM11_SummitWr(0x0000,0x0007,port);  // Reg  7 - Time-Tag Reg
	PM11_SummitWr(0x0020,0x0008,port);  // Reg  8 - Points to first command block
	PM11_SummitWr(0x0000,0x0009,port);  // Reg  9 - 1553 Stat Word Bits Reg
	PM11_SummitWr(0x0000,0x000A,port);  // Reg 10 - BC Cmd Block Init Count Reg
	PM11_SummitWr(MON_CMD_LOC,0x000B,port);   // Reg 11 - Initial Mon Block Ptr Reg
	PM11_SummitWr(MON_DATA_LOC,0x000C,port);  // Reg 12 - Initial Mon Data Ptr Reg
	PM11_SummitWr(NMON_BLKS-1,0x000D,port);   // Reg 13 - Mon Block Counter Reg
	PM11_SummitWr(0x0000,0x000E,port);  // Reg 14 - Mon Filter Reg
	PM11_SummitWr(0x0001,0x000F,port);  // Reg 15 - Mon Filter Reg (Filter for RTA 0)

}

/**
*
*   PM11Ex3_MonCount()
*   Returns current count of montior blocks
*   Arguments:
*      port:    PM1553-1 port setting
*      count:   Current count
*   Returns:    Monitor count (in blocks)
*   Warnings:   None
*
**/

USHORT PM11Ex3_MonCount(USHORT port)	
{
	USHORT curr;   // holds value of monitor block count register
	USHORT count;  // holds calculated number of blocks remaining

	curr  = PM11_SummitRd(SREG_MON_BLKCOUNT,port);   // get current monitor block count
	count = NMON_BLKS - curr -1;                     // calculate number of blocks remaining

	// if count is 0, return number of blocks allocated
	// if count is not 0, return number of block remaining

	return( (!count) ? (NMON_BLKS) : (count) );
}

/**
*
*  PM11Ex3_MonAddrBlk()
*  Returns address of specified monitor block
*  Arguments:
*     index: Index of the block (starting with 1)
*  Returns:   address of specified monitor block
*  Warnings:  None
*
**/

USHORT PM11Ex3_MonAddrBlk(USHORT index)
{
	return(MON_CMD_LOC + 8*(index-1));
}
