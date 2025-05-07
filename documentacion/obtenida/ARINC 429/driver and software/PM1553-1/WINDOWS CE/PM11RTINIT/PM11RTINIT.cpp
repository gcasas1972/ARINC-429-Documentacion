/**
*
*  PM1553-1 EXAMPLE 4  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM11RTINIT.CPP -- Example of RT Mode with initialize.
*
**/

/**
*
*  RTINIT.C:  Example initialized remote terminal application for PM1553-1.
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

#include "stdafx.h"

#define DESC_BASE   0x0020			//Base address of Descriptor Table
#define DATA_BASE   0x0300			//Base address of normal RT data
#define BCAST_BASE  0x1000			//Base address of broadcast data

/**
*
*  PM11Ex4_ROMCopyImage()
*  Copies the Summit contents (registers and memory) to the PROM
*  Arguments:
*    handleval:   PM1553-1 port setting
*  Returns:  0 if successful, non-zero if write operation failed
*  Warnings: None
*
**/

INT PM11Ex4_ROMCopyImage(HANDLE handleval)
{
	USHORT value,addr;
	USHORT i;
	INT status;

	status = 0;
	value = 0;
	addr = 0;

	status = PM11_ROMWipe(handleval);										//Erase the EEPROM
	if (status) return(status);												//Check for a successful write

	//
	//  This copies first 1000h Summit locations from Summit to EEPROM
	//  starting with 1 through FFFh and then 0 in order to set STEX bit last.
	//

	for (i=1;i<0x1000;i++)
	{
		value = PM11_SummitRd(i,handleval);

		status = PM11_ROMWr((UCHAR)     (i>>0),addr++,handleval); if (status) return(status);	//Write low byte first
		status = PM11_ROMWr((UCHAR)     (i>>8),addr++,handleval); if (status) return(status);	//Then high byte address
		status = PM11_ROMWr((UCHAR) (value>>0),addr++,handleval); if (status) return(status);	//Then low byte data
		status = PM11_ROMWr((UCHAR) (value>>8),addr++,handleval); if (status) return(status);	//Then write high byte data
	}

	value = PM11_SummitRd(SREG_CTRL,handleval);

	status = PM11_ROMWr((UCHAR) (SREG_CTRL>>0),addr++,handleval); if (status) return(status);	//Write low byte first
	status = PM11_ROMWr((UCHAR) (SREG_CTRL>>8),addr++,handleval); if (status) return(status);	//Then high byte address
	status = PM11_ROMWr((UCHAR)     (value>>0),addr++,handleval); if (status) return(status);	//Then low byte data
	status = PM11_ROMWr((UCHAR)     (value>>8),addr++,handleval); if (status) return(status);	//Then write high byte data

	return(status);
}

/**
*
*  PM11Ex4_RTAddrDesc() 
*  Returns address of specified descriptor.
*  Arguments:
*    cwd:       Command word
*    descbase:  Starting address of RT descriptor table
*    addr:      Returns address of descriptor
*  Returns:     Descriptor address of the specified command word.
*  Warnings:    None
*
**/

USHORT PM11Ex4_RTAddrDesc(USHORT cwd,USHORT descbase)
{
	INT ta,subaddr,wc;
	BOOL trbit;
	BOOL mcflag;
	USHORT addr;

	PM11_UnpackCWD(cwd,&ta,&trbit,&subaddr,&wc);

	//
	//  Set mode code flag
	//

	mcflag = ((subaddr == 0) | (subaddr == 31)) ? TRUE:FALSE;
	
	addr  = ((mcflag) ? (32*2) : (0));									//Set offset for mode code vs. no mode code
	addr += ((trbit)  ? (32*1) : (0));									//Set offset for T/R

	//
	//  Offset for word count or subaddr
	//

	addr += ((mcflag) ? wc:subaddr);

	addr *= 4;															//Four words per descriptor entry
	addr += descbase;													//Add base offset

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
	INT ta,subaddr,wc;
	BOOL trbit;
	USHORT addr=0x0000;													//Initialize address

	PM11_UnpackCWD(cwd,&ta,&trbit,&subaddr,&wc);

	//
	//  Set broadcast vs non-broadcast data
	//

	addr = ((ta==31) ? BCAST_BASE:DATA_BASE);

	if ((subaddr == 0) || (subaddr == 31))								//Is a mode code
	{
		addr += 32*2*(2+32);											//Set mode code offset
		addr += (trbit) ? ((16*(2+0))+(16*(2+1))) : (0x0000);			//Set transmit offset
		addr += (subaddr>15) ? (16*(2+0)) : (0x0000);
		addr += (subaddr>15) ? ((subaddr&0x0F) * (2+1)) : ((subaddr&0x0F) * (2+0));
	}
	else																//Is not a mode code
	{
		//
		//  Offset transmit vs receive data
		//

		addr += ((trbit) ? (32*(2+32)) : (0x0000));

		//
		//  Offset for previous subaddresses
		//

		addr += subaddr * (2+32);
	}

	return(addr);
}

/**
*
*  PM11Ex4_RTFillData()
*  Fills all data locations with a value that indicates SA and word number
*  Arguments:
*    handleval:   PM1553-1 port setting
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex4_RTFillData(HANDLE handleval)
{
	USHORT cwd,addr,data;
	int trbit,subaddr,wc;

	for (trbit=0;trbit<=1;++trbit)										//Loop through XMT and RCV
	{
		for (subaddr=0;subaddr<=31;++subaddr)							//Loop through subaddresses
		{
			cwd = PM11_PackCWD(1,trbit,subaddr,0);						//Make CWD (note RTA == 1)
			addr = PM11Ex4_RTAddrData(cwd) + 2;							//Get base address
			data = subaddr << 8;										//Set data
			if (trbit) data = data | 0x8000;							//Add T/R bit
			for (wc =0; wc < 32; wc++)									//Loop through words
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
*  PM11Ex4_ConfigSummitRT()
*  Configures the PM1553-1 Summit as a Remote Terminal
*  Arguments:
*    port:   PM1553-1 handleval setting
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex4_ConfigSummitRT(HANDLE handleval)
{
	USHORT mcflag,trbit,subaddr,cwd,addr;
	
	while(!PM11_SummitIsReady(handleval));

	PM11_SummitWr(0x1810,   0x0000,handleval);				//Reg  0 - Note STEX is disabled, Ch A/B, Brcast Enable
	PM11_SummitWr(0x0500,   0x0001,handleval);				//Reg  1 - TA=0, RT
	PM11_SummitWr(0x0000,   0x0002,handleval);				//Reg  2 - Current Command Reg
	PM11_SummitWr(0x0000,   0x0003,handleval);				//Reg  3 - Enable Interrupt
	PM11_SummitWr(0x0000,   0x0004,handleval);				//Reg  4 - Pending Int Reg
	PM11_SummitWr(0x0000,   0x0005,handleval);				//Reg  5 - Int Log List Ptr Reg
	PM11_SummitWr(0x0000,   0x0006,handleval);				//Reg  6 - BIT Word Reg
	PM11_SummitWr(0x0000,   0x0007,handleval);				//Reg  7 - Time-Tag Reg
	PM11_SummitWr(DESC_BASE,0x0008,handleval);				//Reg  8 - Points to Descriptor Table
	PM11_SummitWr(0x0000,   0x0009,handleval);				//Reg  9 - 1553 Stat Word Bits Reg
	PM11_SummitWr(0x0000,   0x000A,handleval);				//Reg 10 - BC Cmd Block Init Count Reg
	PM11_SummitWr(0x0000,   0x000B,handleval);				//Reg 11 - Initial Mon Block Ptr Reg
	PM11_SummitWr(0x0000,   0x000C,handleval);				//Reg 12 - Initial Mon Data Ptr Reg
	PM11_SummitWr(0x0000,   0x000D,handleval);				//Reg 13 - Mon Block Counter Reg
	PM11_SummitWr(0x0000,   0x000E,handleval);				//Reg 14 - Mon Filter Reg
	PM11_SummitWr(0x0000,   0x000F,handleval);				//Reg 15 - Mon Filter Reg

	PM11_SummitWr(0x0000,   0x0010,handleval);				//Illegal - Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,   0x0011,handleval);				//Illegal - Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,   0x0012,handleval);				//Illegal - Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,   0x0013,handleval);				//Illegal - Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,   0x0014,handleval);				//Illegal - Broadcast Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,   0x0015,handleval);				//Illegal - Broadcast Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,   0x0016,handleval);				//Illegal - Broadcast Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,   0x0017,handleval);				//Illegal - Broadcast Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,   0x0018,handleval);				//Illegal - Mode Code Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,   0x0019,handleval);				//Illegal - Mode Code Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,   0x001A,handleval);				//Illegal - Mode Code Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,   0x001B,handleval);				//Illegal - Mode Code Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,   0x001C,handleval);				//Illegal - Mode Code Broadcast Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,   0x001D,handleval);				//Illegal - Mode Code Broadcast Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,   0x001E,handleval);				//Illegal - Mode Code Broadcast Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,   0x001F,handleval);				//Illegal - Mode Code Broadcast Xmt Subaddr 16-31

	//
	//  Loop through descriptors
	//

	for (mcflag=0;mcflag<=1;++mcflag)					//MC vs no MC
	{
		for (trbit=0;trbit<=1;++trbit)					//RCV vs XMT
		{
			for (subaddr=0;subaddr<=30;++subaddr)		//Subaddresses/mode codes
			{
				//
				//  Get descriptor address
				//

				cwd  = PM11_PackCWD(1,trbit,subaddr,0);
				addr = PM11Ex4_RTAddrDesc(cwd, DESC_BASE);

				//
				//  Write to control word.
				//

				PM11_SummitWr(0x0001,(USHORT)(addr+0x0000),handleval);

				//
				//  Write to data pointer A and null data pointer B.
				//

				PM11_SummitWr(PM11Ex4_RTAddrData(cwd),(USHORT)(addr+0x0001),handleval);
				PM11_SummitWr(0x0000,                 (USHORT)(addr+0x0002),handleval);

				//
				//  Write to broadcast pointer.
				//

				PM11_SummitWr(PM11Ex4_RTAddrData(PM11_PackCWD(31,trbit,subaddr,0)),(USHORT)(addr+0x0003),handleval);
			}
		}
	}
}

int _tmain(int argc,TCHAR *argv[],TCHAR *envp[])
{
	INT portnum = 0x2C0;
	INT irqnum  = 0;
	HANDLE handleval;
	USHORT data1,data2,SA1Raddr,SA1Taddr,romfail;

	_tprintf(_T("\nPM11RTINIT  Version 1.0  (08/27/2007)"));
	_tprintf(_T("\nCopyright 2007  Ballard Technology, Inc.  Everett, WA, USA."));
	_tprintf(_T("\nAll rights reserved."));
	_tprintf(_T("\nGo to www.ballardtech.com or email support@ballardtech.com"));
	_tprintf(_T("\n"));
	_tprintf(_T("\n\"RT with autoinitialization example.\""));
	_tprintf(_T("\n"));

	_tprintf(_T("\nUsage: PM11RTINIT [portnum] [irqnum]"));
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

	if ((PM11_RegRd(CREG_MISC,handleval) & AUTOINIT_EN))					//Autoinitialize (i.e., the AUTO- jumper is off)
	{
		_tprintf(_T("**** Using configuration from autoinitialization *****\n"));
		_tprintf(_T("Summit NOT COPIED to EEPROM\n\n"));
	}
	else																	//Software initialize
	{
		_tprintf(_T("\nConfiguring Summit...\n"));
		
		PM11Ex4_ConfigSummitRT(handleval);									//Configure SUMMIT
		PM11Ex4_RTFillData(handleval);										//Fill data memory with known values
		PM11_SummitStart(handleval);										//Start the Summit

		_tprintf(_T("...Configuration complete.\n"));

		if (PM11_RegRd(CREG_STATUS,handleval) & PROM_WE)					//PROM write is enabled
		{
			PM11_ROMWipe(handleval);										//Erase PROM
			romfail = PM11Ex4_ROMCopyImage(handleval);						//Copy Summit image to PROM
			if (romfail)
			{
				_tprintf(_T("***EEPROM WRITE FAILED! ******\n"));
			}
			else
			{
				_tprintf(_T("****** SUMMIT COPIED TO EEPROM ******\n"));
			}
		}
		else																//PROM write is disabled
		{
			_tprintf(_T("Summit NOT COPIED to EEPROM\n\n"));
		}
	}

	SA1Raddr = PM11Ex4_RTAddrData(PM11_PackCWD(0,0,1,0)) + 2;				//Address of SA1 receive data
	SA1Taddr = PM11Ex4_RTAddrData(PM11_PackCWD(0,1,1,0)) + 2;				//Address of SA1 transmit data

	_tprintf(_T("\nPress <ENTER> to exit....\n"));

	while(_gettchar()==WEOF)
	{
		data1 = PM11_SummitRd(SA1Raddr,handleval);							//Get first two data
		data2 = PM11_SummitRd((USHORT)(SA1Raddr+1),handleval);				//Words from receive SA1 data

		PM11_SummitWr(data1,SA1Taddr,handleval);							//Copy to first two data
		PM11_SummitWr(data2,(USHORT)(SA1Taddr + 1),handleval);				//Words for Message B
	}

	PM11_SummitStop(handleval);												//Stop Summit operation

	PM11_CardClose(handleval);												//Close card

	exit(0);
}
