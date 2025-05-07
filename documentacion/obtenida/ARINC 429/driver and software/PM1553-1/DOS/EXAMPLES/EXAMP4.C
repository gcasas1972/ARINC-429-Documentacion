/**
*
*  PM1553-1 EXAMPLE 4  Version 1.0  (04/15/2002)
*  Copyright (c) 2002
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4.C -- "Example of RT Mode with initialize."
*
**/
/**
*
*  EXAMP4.C:  Example initialized remote terminal application for PM1553-1.
*
*  This example is identical to Example 2, except that if the
*  AUTO- jumper is off, it expects the PM1553-1 to be properly 
*  configured from the EEPROM through the autoinitialization 
*  process.  If the AUTO- jumper is on, this program configures
*  the Summit as in Example 2; and if the PWE jumper is on, it 
*  copies the configuration to the EEPROM.
*
*  Once configured, the host repeatedly copies two words from receive 
*  subaddress 1 to transmit subaddress 1. In other words, when these 
*  two words are received, they are wrapped around and will be 
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
 

// Prototypes
INT    PM11Ex4_ROMCopyImage(USHORT port);
USHORT PM11Ex4_RTAddrDesc(USHORT cwd, USHORT descbase);
VOID   PM11Ex4_ConfigSummitRT(USHORT port);
VOID   PM11Ex4_RTFillData(USHORT port);
USHORT PM11Ex4_RTAddrData(USHORT cwd);

VOID main(VOID)
{
	USHORT port;
	USHORT data1, data2, SA1Raddr, SA1Taddr, romfail;

	fprintf(stderr,"\nEXAMP4  Version 1.0  (04/15/2002)");
	fprintf(stderr,"\nCopyright 2002 Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"RT with autoinitialization example.\"");
	fprintf(stderr,"\n");

	port = 0x02C0;   // Initialize port value

	while(!PM11_SummitIsReady(port)); // Wait for READY 

	if((PM11_RegRd(CREG_MISC, port) & AUTOINIT_EN))  // Autoinitialize (i.e., the AUTO- jumper is off)
	{
		fprintf(stderr,"**** Using configuration from autoinitialization *****\n");
		fprintf(stderr,"Summit NOT COPIED to EEPROM\n\n");
	}
	else  // Software initialize
	{
		fprintf(stderr,"\nConfiguring Summit...\n");
		
		PM11Ex4_ConfigSummitRT(port);  // Configure SUMMIT
		PM11Ex4_RTFillData(port);      // Fill data memory with known values
		PM11_SummitStart(port);        // Start the Summit

		fprintf(stderr,"...Configuration complete.\n");

		if(PM11_RegRd(CREG_STATUS, port) & PROM_WE)  // PROM write is enabled
		{
			PM11_ROMWipe(port);                       // erase PROM
			romfail = PM11Ex4_ROMCopyImage(port);     // Copy Summit image to PROM
			if(romfail)
			{
				fprintf(stderr,"***EEPROM WRITE FAILED! ******\n");
			}
			else
			{
				fprintf(stderr,"****** SUMMIT COPIED TO EEPROM ******\n");
			}
		}
		else  // PROM write is disabled
		{
			fprintf(stderr,"Summit NOT COPIED to EEPROM\n\n");
		}
	}

	SA1Raddr = PM11Ex4_RTAddrData(PM11_PackCWD(0,0,1,0)) + 2;  // Address of SA1 receive data
	SA1Taddr = PM11Ex4_RTAddrData(PM11_PackCWD(0,1,1,0)) + 2;  // Address of SA1 transmit data

	fprintf(stderr,"\nPress any key to exit...");

	while(!kbhit())
	{
		data1 = PM11_SummitRd(SA1Raddr,port);               // Get first two data
		data2 = PM11_SummitRd((USHORT)(SA1Raddr+1),port);   // words from receive SA1 data

		PM11_SummitWr(data1,SA1Taddr,port);                 // Copy to first two data
		PM11_SummitWr(data2,(USHORT)(SA1Taddr + 1),port);   // words for Message B
	}

	PM11_SummitStop(port);    // stop Summit operation
}


/**
*
*  PM11Ex4_ROMCopyImage()
*  Copies the Summit contents (registers and memory) to the PROM
*  Arguments:
*    port: PM1553-1 port setting
*  Returns:  0 if successful, non-zero if write operation failed
*  Warnings: None
*
**/

INT PM11Ex4_ROMCopyImage(USHORT port)
{
	USHORT value, addr;
	USHORT i;
	INT status;

	status = 0;
	value = 0;
	addr = 0;

	status = PM11_ROMWipe(port);    // Erase the EEPROM
	if(status) return status;       // Check for a successful write

	// This copies first 1000h Summit locations from Summit to EEPROM
	// starting with 1 through FFFh and then 0 in order to set STEX bit last.
	for (i = 1; i < 0x1000; i++)
	{
		value = PM11_SummitRd(i, port);

		PM11_ROMWr((UCHAR) i, addr++, port);            // Write low byte first
		if(status) return status;
		PM11_ROMWr((UCHAR) (i >> 8), addr++, port);     // then high byte address
		if(status) return status;
		PM11_ROMWr((UCHAR) value, addr++, port);        // then low byte data
		if(status) return status;
		PM11_ROMWr((UCHAR) (value >> 8), addr++, port); // then write high byte data
		if(status) return status;
	}

	value = PM11_SummitRd(SREG_CTRL, port);
	PM11_ROMWr((UCHAR) SREG_CTRL, addr++, port);        // Write low byte first
	if(status) return status;
	PM11_ROMWr((UCHAR) (SREG_CTRL >> 8), addr++, port); // then high byte address
	if(status) return status;
	PM11_ROMWr((UCHAR) value, addr++, port);            // then low byte data
	if(status) return status;
	PM11_ROMWr((UCHAR) (value >> 8), addr++, port);     // then write high byte data

	return status;
}

/**
*
*  PM11Ex4_RTAddrDesc() 
*  Returns address of specified descriptor.
*  Arguments:
*    cwd:       Command word
*    descbase:  Starting address of RT descriptor table
*    addr:      Returns address of descriptor
*  Returns:   Descriptor address of the specified command word.
*  Warnings:  None
*
**/

USHORT PM11Ex4_RTAddrDesc(USHORT cwd, USHORT descbase)
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

	addr *= 4;         // four words per descriptor entry
	addr += descbase;  // add base offset

	return(addr);
}

/**
*
*  PM11Ex4_RTAddrData()
*  Returns address of RT data.
*  Arguments:
*    cwd:  Command word
*    addr: Returns address of data
*  Returns:
*    Data address of the specified command word.
*  Warnings: None
*
**/

USHORT PM11Ex4_RTAddrData(USHORT cwd)
{
	INT ta, subaddr, wc;
	BOOL trbit;
	USHORT addr=0x0000;  // initialize address

	PM11_UnpackCWD(cwd,&ta,&trbit,&subaddr,&wc);

	// set broadcast vs non-broadcast data
	(ta == 31) ? (addr = BCAST_BASE) : (addr = DATA_BASE);

	if ((subaddr == 0) | (subaddr == 31))  //is a mode code
	{
		addr += 32*2*(2+32);                                     // set mode code offset
		addr += (trbit) ? ( (16*(2+0))+(16*(2+1)) ) : (0x0000);  // set transmit offset
		addr += (subaddr>15) ? (16*(2+0)) : (0x0000);
		addr += (subaddr>15) ? ((subaddr&0x0F) * (2+1)) : ((subaddr&0x0F) * (2+0));
	}
	else                                   //is not a mode code
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
*  PM11Ex4_RTFillData()
*  Fills all data locations with a value that indicates SA and word number
*  Arguments:
*    port: PM1553-1 port setting
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex4_RTFillData(USHORT port)
{
	USHORT cwd, addr, data;
	int trbit, subaddr, wc;

	for (trbit=0;trbit<=1;++trbit)  // loop through XMT and RCV
	{
		for (subaddr=0;subaddr<=31;++subaddr)  // loop through subaddresses
		{
			cwd = PM11_PackCWD(1,trbit,subaddr,0);  // make CWD (note RTA == 1)
			addr = PM11Ex4_RTAddrData(cwd) + 2;     // get base address
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
*  PM11Ex4_ConfigSummitRT()
*  Configures the PM1553-1 Summit as a Remote Terminal
*  Arguments:
*    port: PM1553-1 port setting
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex4_ConfigSummitRT(USHORT port)
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

	// Loop through descriptors

	for (mcflag=0;mcflag<=1;++mcflag)  // MC vs no MC
	{
		for (trbit=0;trbit<=1;++trbit) // RCV vs XMT
		{
			for (subaddr=0;subaddr<=30;++subaddr)  // subaddresses/mode codes
			{
				// Get descriptor address
				cwd  = PM11_PackCWD(1,trbit,subaddr,0);
				addr = PM11Ex4_RTAddrDesc(cwd, DESC_BASE);

				//  Write to control word.
				PM11_SummitWr(0x0001,(USHORT)(addr+0x0000),port);

				//  Write to data pointer A and null data pointer B.
				PM11_SummitWr(PM11Ex4_RTAddrData(cwd),(USHORT)(addr+0x0001),port);
				PM11_SummitWr(0x0000, (USHORT)(addr+0x0002), port);

				//  Write to broadcast pointer.
				PM11_SummitWr(PM11Ex4_RTAddrData(PM11_PackCWD(31,trbit,subaddr,0)),(USHORT)(addr+0x0003),port);
			}
		}
	}
}
