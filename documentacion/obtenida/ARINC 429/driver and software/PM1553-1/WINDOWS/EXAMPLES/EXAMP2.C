/**
*
*  PM1553-1 EXAMPLE 2  Version 1.0  (04/04/2006)
*  Copyright (c) 2002-2006
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- "Example of RT Mode."
*
**/

/**
*
*  EXAMP2.C:  Example remote terminal application for PM1553-1.
*
*  Configures the PM1553-1 as a single buffered remote terminal.
*
*  The host repeatedly copies two words from receive subaddress 1 
*  to transmit subaddress 1 of terminal address 0. In other words,
*  when these two words are received, they are wrapped around and will be
*  transmitted back when requested by the bus controller.
*
*
**/

#include <stdio.h>
#include <conio.h>
#include "pm11.h"

#define DESC_BASE   0x0020  // Base address of Descriptor Table
#define DATA_BASE   0x0300  // Base address of normal RT data
#define BCAST_BASE  0x1000  // Base address of broadcast data
 
USHORT PM11Ex2_RTAddrDesc(USHORT cwd, USHORT descbase);
USHORT PM11Ex2_RTAddrData(USHORT cwd);
VOID   PM11Ex2_RTFillData(USHORT port);
VOID   PM11Ex2_ConfigSummitRT(USHORT port);

VOID main(VOID)
{
	HANDLE hCard;

	USHORT port;
	USHORT data1, data2, SA1Raddr, SA1Taddr;

	fprintf(stderr,"\nEXAMP2  Version 1.0  (04/04/2006)");
	fprintf(stderr,"\nCopyright 2002-2006  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"RT example.\"");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nSimulating RT 0, Transmit/Receive Subaddress 1");

	port = 0x2C0;        // initialize port setting

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
	//	Configure and start summit
	//

	while(!PM11_SummitIsReady(port)); // Wait for READY 

	//
	//	Configure SUMMIT
	//

	PM11Ex2_ConfigSummitRT(port);    // Configure Summit
	PM11Ex2_RTFillData(port);        // Fill data memory with known values

	//
	//	Start SUMMIT
	//

	PM11_SummitStart(port);          // Start the Summit

	//
	//	Get address of subaddresses
	//

	SA1Raddr = PM11Ex2_RTAddrData(PM11_PackCWD(0,0,1,0)) + 2;  // Address of SA1 receive data
	SA1Taddr = PM11Ex2_RTAddrData(PM11_PackCWD(0,1,1,0)) + 2;  // Address of SA1 transmit data

	//
	//	Move data between subaddresses
	//

	fprintf(stderr,"\nPress any key to exit...");

	while(!kbhit())
	{
		data1 = PM11_SummitRd((USHORT)(SA1Raddr+0),port);   // Get first two data
		data2 = PM11_SummitRd((USHORT)(SA1Raddr+1),port);   // words from receive SA1 data

		PM11_SummitWr(data1,(USHORT)(SA1Taddr+0),port);     // Copy to first two data
		PM11_SummitWr(data2,(USHORT)(SA1Taddr+1),port);     // words for Message B
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
*  PM11Ex2_RTAddrDesc() 
*  Returns address of specified descriptor.
*  Arguments:
*    cwd:  Command word
*    descbase:  Starting address of RT descriptor table
*    addr:      Returns address of descriptor
*  Returns:    Descriptor address of the specified command word.
*  Warnings:   None
*
**/

USHORT PM11Ex2_RTAddrDesc(USHORT cwd, USHORT descbase)
{

	INT ta, subaddr, wc;
	BOOL trbit;
	BOOL mcflag;
	USHORT addr;

	PM11_UnpackCWD(cwd,&ta,&trbit,&subaddr,&wc);

	// set mode code flag
	((subaddr == 0) | (subaddr == 31)) ? (mcflag = TRUE) : (mcflag = FALSE);
	
	addr  = ( (mcflag) ? (32*2) : (0) );  // set offset for mode code vs. no mode code
	addr += ( (trbit)  ? (32*1) : (0) );  // set offset for T/R

	// offset for word count or subaddr
	(mcflag) ? (addr += wc) : (addr += subaddr);

	addr *= 4;            // four words per descriptor entry
	addr += descbase;     // add base offset

	return(addr);
}

/**
*
*  PM11Ex2_RTAddrData()
*  Returns address of RT data.
*  Arguments:
*    cwd:   Command word
*    addr:  Returns address of data
*  Returns: Data address of the specified command word.
*  Warnings: None
*
**/

USHORT PM11Ex2_RTAddrData(USHORT cwd)
{
	INT ta, subaddr, wc;
	BOOL trbit;
	USHORT addr=0x0000;  // initialize address

	PM11_UnpackCWD(cwd,&ta,&trbit,&subaddr,&wc);

	// set broadcast vs non-broadcast data
	(ta == 31) ? (addr = BCAST_BASE) : (addr = DATA_BASE);

	if ((subaddr == 0) | (subaddr == 31))   //is a mode code
	{
		addr += 32*2*(2+32);                                    // set mode code offset
		addr += (trbit) ? ( (16*(2+0))+(16*(2+1)) ) : (0x0000); // set transmit offset
		addr += (subaddr>15) ? (16*(2+0)) : (0x0000);
		addr += (subaddr>15) ? ((subaddr&0x0F) * (2+1)) : ((subaddr&0x0F) * (2+0));
	}
	else                                    //is not a mode code
	{
		// offset transmit vs receive data
		addr += (trbit) ? (32*(2+32)) : (0x0000);

		// offset for previous subaddresses
		addr += subaddr * (2+32);
	}

	return(addr);
}

/**
*
*  PM11Ex2_RTFillData()
*  Fills all data locations with a value that indicates SA and word number
*  Arguments:
*    port: PM1553-1 port setting
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex2_RTFillData(USHORT port)
{
	USHORT cwd, addr, data;
	int trbit, subaddr, wc;

	for (trbit=0;trbit<=1;++trbit)  // loop through XMT and RCV
	{
		for (subaddr=0;subaddr<=31;++subaddr)  // loop through subaddresses
		{
			cwd = PM11_PackCWD(1,trbit,subaddr,0);  // make CWD (note RTA == 1)
			addr = PM11Ex2_RTAddrData(cwd) + 2;     // get base address
			data = subaddr << 8;                    // set data
			if (trbit) data = data | 0x8000;        // add T/R bit
			for(wc =0; wc < 32; wc++)               // loop through words
			{
				PM11_SummitWr(data,addr,port);
				data++;
				addr++;
			}
		}
	}
}

/**
*
*  PM11Ex2_ConfigSummitRT()
*  Configures the PM1553-1 Summit as a Remote Terminal
*  Arguments:
*    port: PM1553-1 port setting
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex2_ConfigSummitRT(USHORT port)
{

	USHORT mcflag, trbit, subaddr, cwd, addr;
	
	while(!PM11_SummitIsReady(port));
	
	PM11_SummitWr(0x1810,0x0000,port);  // Reg  0 - Note STEX is disabled, Ch A/B, Brcast Enable
	PM11_SummitWr(0x0500,0x0001,port);  // Reg  1 - TA=0, RT
	PM11_SummitWr(0x0000,0x0002,port);  // Reg  2 - Current Command Reg
	PM11_SummitWr(0x0000,0x0003,port);  // Reg  3 - Enable Interrupt
	PM11_SummitWr(0x0000,0x0004,port);  // Reg  4 - Pending Int Reg
	PM11_SummitWr(0x0000,0x0005,port);  // Reg  5 - Int Log List Ptr Reg
	PM11_SummitWr(0x0000,0x0006,port);  // Reg  6 - BIT Word Reg
	PM11_SummitWr(0x0000,0x0007,port);  // Reg  7 - Time-Tag Reg
	PM11_SummitWr(DESC_BASE,0x0008,port);  // Reg  8 - Points to Descriptor Table
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

	//
	// Loop through descriptors
	//
	for (mcflag=0;mcflag<=1;++mcflag)  // MC vs no MC
	{
		for (trbit=0;trbit<=1;++trbit)  // RCV vs XMT
		{
			for (subaddr=0;subaddr<=30;++subaddr)  // subaddresses/mode codes
			{
				// Get descriptor address
				cwd  = PM11_PackCWD(1,trbit,subaddr,0);
				addr = PM11Ex2_RTAddrDesc(cwd, DESC_BASE);

				// Write to control word.
				PM11_SummitWr(0x0001,(USHORT)(addr+0x0000),port);

				// Write to data pointer A and null data pointer B.
				PM11_SummitWr(PM11Ex2_RTAddrData(cwd),(USHORT)(addr+0x0001),port);
				PM11_SummitWr(0x0000, (USHORT)(addr+0x0002), port);

				// Write to broadcast pointer.
				PM11_SummitWr(PM11Ex2_RTAddrData(PM11_PackCWD(31,trbit,subaddr,0)),(USHORT)(addr+0x0003),port);
			}
		}
	}
}
