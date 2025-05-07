/**
*
*  PM1553-1 EXAMPLE 3  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM11MON.CPP -- Example of Monitor Mode.
*
**/

/**
*
*  MON.C:  Example Monitor application for PM1553-1
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

#include "stdafx.h"

#define SUMMIT_MEMORY_SIZE	0x7FFF	//Size of Summit's memory in words
#define MON_CMD_LOC			0x100	//Starting address of monitor command blocks
#define MON_DATA_LOC		0x1000	//Starting address of monitor data
#define NMON_BLKS			10		//Number of monitor blocks

/**
*
*  PM11Ex3_SummitWipe()
*  Clears all Summit registers and memory
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex3_SummitWipe(HANDLE handleval)
{
	UINT i;

	for (i=0;i<=SUMMIT_MEMORY_SIZE;++i)
	{
		PM11_SummitWr(0,(USHORT)i,handleval);
	}
}

/**
*
*  PM11Ex3_ConfigSummitMon()
*  Configures the PM1553-1 Summit as a Monitor
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex3_ConfigSummitMon(HANDLE handleval)
{
	PM11_SummitWr(0x0000,      0x0000,handleval);				//Reg  0 - Note STEX is disabled
	PM11_SummitWr(0x0200,      0x0001,handleval);				//Reg  1 - Configured for monitor mode
	PM11_SummitWr(0x0000,      0x0002,handleval);				//Reg  2 - Current Command Reg
	PM11_SummitWr(0x0002,      0x0003,handleval);				//Reg  3 - Enable interrupt
	PM11_SummitWr(0x0000,      0x0004,handleval);				//Reg  4 - Pending Int Reg
	PM11_SummitWr(0x0000,      0x0005,handleval);				//Reg  5 - Int Log List Ptr Reg
	PM11_SummitWr(0x0000,      0x0006,handleval);				//Reg  6 - BIT Word Reg
	PM11_SummitWr(0x0000,      0x0007,handleval);				//Reg  7 - Time-Tag Reg
	PM11_SummitWr(0x0020,      0x0008,handleval);				//Reg  8 - Points to first command block
	PM11_SummitWr(0x0000,      0x0009,handleval);				//Reg  9 - 1553 Stat Word Bits Reg
	PM11_SummitWr(0x0000,      0x000A,handleval);				//Reg 10 - BC Cmd Block Init Count Reg
	PM11_SummitWr(MON_CMD_LOC, 0x000B,handleval);				//Reg 11 - Initial Mon Block Ptr Reg
	PM11_SummitWr(MON_DATA_LOC,0x000C,handleval);				//Reg 12 - Initial Mon Data Ptr Reg
	PM11_SummitWr(NMON_BLKS-1, 0x000D,handleval);				//Reg 13 - Mon Block Counter Reg
	PM11_SummitWr(0x0000,      0x000E,handleval);				//Reg 14 - Mon Filter Reg
	PM11_SummitWr(0x0001,      0x000F,handleval);				//Reg 15 - Mon Filter Reg (Filter for RTA 0)

}

/**
*
*  PM11Ex3_MonCount()
*  Returns current count of montior blocks
*  Arguments:
*    handleval: card handle
*  Returns:	Monitor count (in blocks)
*  Warnings:  None
*
**/

USHORT PM11Ex3_MonCount(HANDLE handleval)
{
	USHORT curr;													//Holds value of monitor block count register
	USHORT count;													//Holds calculated number of blocks remaining

	curr  = PM11_SummitRd(SREG_MON_BLKCOUNT,handleval);				//Get current monitor block count
	count = NMON_BLKS - curr -1;									//Calculate number of blocks remaining

	//
	//  If count is 0, return number of blocks allocated
	//  If count is not 0, return number of block remaining
	//

	return((!count) ? (NMON_BLKS) : (count));
}

/**
*
*  PM11Ex3_MonAddrBlk()
*  Returns address of specified monitor block
*  Arguments:
*    index:  Index of the block (starting with 1)
*  Returns:   address of specified monitor block
*  Warnings:  None
*
**/

USHORT PM11Ex3_MonAddrBlk(USHORT index)
{
	return(MON_CMD_LOC + 8*(index-1));
}

int _tmain(int argc,TCHAR *argv[],TCHAR *envp[])
{
	INT portnum = 0x2C0;
	INT irqnum  = 0;
	INT previndex;													//Previous Summit index into monitor buffer
	INT currindex;													//Current index into monitor buffer
	INT nextindex;													//Summit's next index into monitor buffer
	HANDLE handleval;												//Card handle

	USHORT cwd;
	USHORT data[32];												//16-bit data words
	USHORT mbaddr, info, dataptr, i;

	_tprintf(_T("\nPM11MON  Version 1.0  (08/27/2007)"));
	_tprintf(_T("\nCopyright 2007  Ballard Technology, Inc.  Everett, WA, USA."));
	_tprintf(_T("\nAll rights reserved."));
	_tprintf(_T("\nGo to www.ballardtech.com or email support@ballardtech.com"));
	_tprintf(_T("\n"));
	_tprintf(_T("\n\"Continuous Monitor Mode.\""));
	_tprintf(_T("\nDisplay only CWD = 0184 messages"));

	_tprintf(_T("\nUsage: PM11MON [portnum] [irqnum]"));
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

	//
	//  Configure the PM1553-1 card as a monitor using the default
	//  settings.  The card will hold a maximum 512 messages.
	//

	PM11Ex3_ConfigSummitMon(handleval);		//Configure Summit (See below)

	//
	//  Activate the PM1553-1 card.  The card will begin to record
	//  all bus activity.
	//

	PM11_SummitStart(handleval);

	//
	//  Until a key is pressed by the user, display all bus
	//  traffic on the screen.
	//

	_tprintf(_T("\nPress <ENTER> to exit....\n"));

	nextindex = currindex = NMON_BLKS;											//Reset variables to empty condition

	while(_gettchar()==WEOF)
	{
		previndex = nextindex;													//Cache Summit's previous index

		nextindex = PM11Ex3_MonCount(handleval);								//Get Summit's next index

		if ((previndex<currindex && nextindex>currindex) ||						//If Summit has overrun...
			(nextindex<previndex && currindex>previndex) ||
			(currindex<nextindex && previndex>nextindex))
		{
			PM11_SummitStop(handleval);											//Stop Summit
			_tprintf(_T("\nThe Summit has been stopped!"));
			break;
		}

		if (nextindex != currindex)												//Wait for count to change
		{
			++currindex;														//Increment index

			if (currindex>NMON_BLKS) currindex=1;								//Wrap around
			
			mbaddr = PM11Ex3_MonAddrBlk((USHORT)currindex);						//Get the block address
			info   = PM11_SummitRd(mbaddr, handleval);							//Get the info word
			cwd    = PM11_SummitRd((USHORT) (mbaddr+1), handleval);				//Get the command word

			if ((cwd==0x0184) && !(info & 0x0080))								//Check for right cwd and no errors
			{
				dataptr = PM11_SummitRd((USHORT)(mbaddr+3), handleval);			//Get address of the data

				for (i=0;i<4;i++)												//Get 4 data words
				{
					data[i] = PM11_SummitRd(dataptr++,handleval);
				}

				//
				//  Print the current values
				//

				_tprintf(_T("CWD=%04X  DATA(1)=%04X	(2)=%04X  (3)=%04X	(4)=%04X P=%02X C=%02X N=%02X\r"),
				  cwd,data[0],data[1],data[2],data[3],previndex,currindex,nextindex);
			}
		}
	}

	PM11_SummitStop(handleval);													//Stop the PM1553-1 card.

	PM11_CardClose(handleval);													//Close card

	exit(0);
}
