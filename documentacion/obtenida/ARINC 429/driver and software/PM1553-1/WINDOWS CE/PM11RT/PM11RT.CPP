/**
*
*  PM1553-1 EXAMPLE 2  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM11RT.CPP -- Example of RT Mode.
*
**/

/**
*
*  RT.C:  Example remote terminal application for PM1553-1.
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

#include "stdafx.h"

#define DESC_BASE	0x0020		//Base address of Descriptor Table
#define DATA_BASE	0x0300		//Base address of normal RT data
#define BCAST_BASE	0x1000		//Base address of broadcast data

/**
*
*  PM11Ex2_RTAddrDesc() 
*  Returns address of specified descriptor.
*  Arguments:
*    cwd:  Command word
*    descbase: Starting address of RT descriptor table
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

	//
	//  Set mode code flag
	//

	mcflag= ((subaddr == 0) | (subaddr == 31)) ? TRUE : FALSE;
	
	addr  = ((mcflag) ? (32*2) : (0));											//Set offset for mode code vs. no mode code
	addr += ((trbit)  ? (32*1) : (0));											//Set offset for T/R

	//
	//  Offset for word count or subaddr
	//

	addr += ((mcflag) ? wc : subaddr);

	addr *= 4;																	//Four words per descriptor entry
	addr += descbase;															//Add base offset

	return(addr);
}

/**
*
*  PM11Ex2_RTAddrData()
*  Returns address of RT data.
*  Arguments:
*    cwd:    Command word
*    addr:   Returns address of data
*  Returns:  Data address of the specified command word.
*  Warnings: None
*
**/

USHORT PM11Ex2_RTAddrData(USHORT cwd)
{
	INT ta, subaddr, wc;
	BOOL trbit;
	USHORT addr=0x0000;															//Initialize address

	PM11_UnpackCWD(cwd,&ta,&trbit,&subaddr,&wc);

	//
	//  Set broadcast vs non-broadcast data
	//

	addr = ((ta==31) ? BCAST_BASE : DATA_BASE);

	if ((subaddr == 0) | (subaddr == 31))										//Is a mode code
	{
		addr += 32*2*(2+32);													//Set mode code offset
		addr += (trbit) ? ((16*(2+0))+(16*(2+1))) : (0x0000);					//Set transmit offset
		addr += (subaddr>15) ? (16*(2+0)) : (0x0000);
		addr += (subaddr>15) ? ((subaddr&0x0F) * (2+1)) : ((subaddr&0x0F) * (2+0));
	}
	else																		//Is not a mode code
	{
		addr += (trbit) ? (32*(2+32)) : (0x0000);								//Offset transmit vs receive data
		addr += subaddr * (2+32);												//Offset for previous subaddresses
	}

	return(addr);
}

/**
*
*  PM11Ex2_RTFillData()
*  Fills all data locations with a value that indicates SA and word number
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex2_RTFillData(HANDLE handleval)
{
	USHORT cwd, addr, data;
	int trbit, subaddr, wc;

	for (trbit=0;trbit<=1;++trbit)												//Loop through XMT and RCV
	{
		for (subaddr=0;subaddr<=31;++subaddr)									//Loop through subaddresses
		{
			cwd = PM11_PackCWD(1,trbit,subaddr,0);								//Make CWD (note RTA == 1)
			addr = PM11Ex2_RTAddrData(cwd) + 2;									//Get base address
			data = subaddr << 8;												//Set data
			if (trbit) data = data | 0x8000;									//Add T/R bit
			for (wc =0; wc < 32; wc++)											//Loop through words
			{
				PM11_SummitWr(data,addr,handleval);
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
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex2_ConfigSummitRT(HANDLE handleval)
{
	USHORT mcflag, trbit, subaddr, cwd, addr;
	
	while(!PM11_SummitIsReady(handleval));
	
	PM11_SummitWr(0x1810,   0x0000,handleval);		//Reg  0 - Note STEX is disabled, Ch A/B, Brcast Enable
	PM11_SummitWr(0x0500,   0x0001,handleval);		//Reg  1 - TA=0, RT
	PM11_SummitWr(0x0000,   0x0002,handleval);		//Reg  2 - Current Command Reg
	PM11_SummitWr(0x0000,   0x0003,handleval);		//Reg  3 - Enable Interrupt
	PM11_SummitWr(0x0000,   0x0004,handleval);		//Reg  4 - Pending Int Reg
	PM11_SummitWr(0x0000,   0x0005,handleval);		//Reg  5 - Int Log List Ptr Reg
	PM11_SummitWr(0x0000,   0x0006,handleval);		//Reg  6 - BIT Word Reg
	PM11_SummitWr(0x0000,   0x0007,handleval);		//Reg  7 - Time-Tag Reg
	PM11_SummitWr(DESC_BASE,0x0008,handleval);		//Reg  8 - Points to Descriptor Table
	PM11_SummitWr(0x0000,   0x0009,handleval);		//Reg  9 - 1553 Stat Word Bits Reg
	PM11_SummitWr(0x0000,   0x000A,handleval);		//Reg 10 - BC Cmd Block Init Count Reg
	PM11_SummitWr(0x0000,   0x000B,handleval);		//Reg 11 - Initial Mon Block Ptr Reg
	PM11_SummitWr(0x0000,   0x000C,handleval);		//Reg 12 - Initial Mon Data Ptr Reg
	PM11_SummitWr(0x0000,   0x000D,handleval);		//Reg 13 - Mon Block Counter Reg
	PM11_SummitWr(0x0000,   0x000E,handleval);		//Reg 14 - Mon Filter Reg
	PM11_SummitWr(0x0000,   0x000F,handleval);		//Reg 15 - Mon Filter Reg

	PM11_SummitWr(0x0000,   0x0010,handleval);		//Illegal - Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,   0x0011,handleval);		//Illegal - Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,   0x0012,handleval);		//Illegal - Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,   0x0013,handleval);		//Illegal - Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,   0x0014,handleval);		//Illegal - Broadcast Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,   0x0015,handleval);		//Illegal - Broadcast Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,   0x0016,handleval);		//Illegal - Broadcast Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,   0x0017,handleval);		//Illegal - Broadcast Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,   0x0018,handleval);		//Illegal - Mode Code Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,   0x0019,handleval);		//Illegal - Mode Code Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,   0x001A,handleval);		//Illegal - Mode Code Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,   0x001B,handleval);		//Illegal - Mode Code Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,   0x001C,handleval);		//Illegal - Mode Code Broadcast Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,   0x001D,handleval);		//Illegal - Mode Code Broadcast Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,   0x001E,handleval);		//Illegal - Mode Code Broadcast Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,   0x001F,handleval);		//Illegal - Mode Code Broadcast Xmt Subaddr 16-31

	//
	//  Loop through descriptors
	//

	for (mcflag=0;mcflag<=1;++mcflag)						//MC vs no MC
	{
		for (trbit=0;trbit<=1;++trbit)						//RCV vs XMT
		{
			for (subaddr=0;subaddr<=30;++subaddr)			//Subaddresses/mode codes
			{
				//
				//  Get descriptor address
				//

				cwd  = PM11_PackCWD(1,trbit,subaddr,0);
				addr = PM11Ex2_RTAddrDesc(cwd, DESC_BASE);

				//
				//  Write to control word.
				//

				PM11_SummitWr(0x0001,(USHORT)(addr+0x0000),handleval);

				//
				//  Write to data pointer A and null data pointer B.
				//

				PM11_SummitWr(PM11Ex2_RTAddrData(cwd),(USHORT)(addr+0x0001),handleval);
				PM11_SummitWr(0x0000, (USHORT)(addr+0x0002), handleval);

				//
				//  Write to broadcast pointer.
				//

				PM11_SummitWr(PM11Ex2_RTAddrData(PM11_PackCWD(31,trbit,subaddr,0)),(USHORT)(addr+0x0003),handleval);
			}
		}
	}
}

int _tmain(int argc,TCHAR *argv[],TCHAR *envp[])
{
	INT portnum = 0x2C0;
	INT irqnum  = 0;
	HANDLE handleval;
	USHORT data1, data2, SA1Raddr, SA1Taddr;

	_tprintf(_T("\nPM11RT  Version 1.0  (08/27/2007)"));
	_tprintf(_T("\nCopyright 2007  Ballard Technology, Inc.  Everett, WA, USA."));
	_tprintf(_T("\nAll rights reserved."));
	_tprintf(_T("\nGo to www.ballardtech.com or email support@ballardtech.com"));
	_tprintf(_T("\n"));
	_tprintf(_T("\n\"RT example.\""));
	_tprintf(_T("\n"));
	_tprintf(_T("\nSimulating RT 0, Transmit/Receive Subaddress 1"));

	_tprintf(_T("\nUsage: PM11RT [portnum] [irqnum]"));
	_tprintf(_T("\nportnum - I/O address of card in hex (200H-3F0H), 2C0H if not specified."));
	_tprintf(_T("\nirqnum  - IRQ of card in decimal (3,4,5,7,9,10,11,12), 0 ignores IRQ."));
	_tprintf(_T("\n"));

	//
	//	Get command line parameters
	//

	if (argc>=2)
	{
		if (!_stscanf(argv[1],_T("%x"),&portnum))
		{
			_tprintf(_T("\nUnable to read port number"));
			exit(0);
		}
	}

	if (argc>=3)
	{
		if (!_stscanf(argv[2],_T("%d"),&irqnum))
		{
			_tprintf(_T("\nUnable to read irq number"));
			exit(0);
		}
	}

	//
	//	Open PM1553-1 card
	//

	_tprintf((irqnum) ? _T("\nOpening PM1553-1 card at port=%04X, irq=%d"):_T("\nOpening PM1553-1 card at port=%04X"),portnum,irqnum);

	if (!PM11_CardOpen(&handleval,portnum,irqnum))
	{
		_tprintf(_T("\nError:  Unable to open card"));
		_tprintf(_T("\n"));
		exit(1);
	}

	while(!PM11_SummitIsReady(handleval));									//Wait for READY 

	PM11Ex2_ConfigSummitRT(handleval);										//Configure Summit
	PM11Ex2_RTFillData(handleval);											//Fill data memory with known values
	PM11_SummitStart(handleval);											//Start the Summit

	SA1Raddr = PM11Ex2_RTAddrData(PM11_PackCWD(0,0,1,0)) + 2;				//Address of SA1 receive data
	SA1Taddr = PM11Ex2_RTAddrData(PM11_PackCWD(0,1,1,0)) + 2;				//Address of SA1 transmit data

	_tprintf(_T("\nPress <ENTER> to exit....\n"));

	while(_gettchar()==WEOF)
	{
		data1 = PM11_SummitRd(SA1Raddr,handleval);							//Get first two data
		data2 = PM11_SummitRd((USHORT)(SA1Raddr+1),handleval);				//Words from receive SA1 data

		PM11_SummitWr(data1,SA1Taddr,handleval);							//Copy to first two data
		PM11_SummitWr(data2,(USHORT)(SA1Taddr+1),handleval);				//Words for Message B
	}

	PM11_SummitStop(handleval);												//Stop Summit operation

	PM11_CardClose(handleval);												//Close card

	exit(0);
}
