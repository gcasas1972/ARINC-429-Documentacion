/**
*
*  PM1553-1 EXAMPLE 1  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM11BC.CPP -- Example of BC Mode.
*
**/

/**
*
*  BC.C:  Example bus controller application for PM1553-1.
*
*  Repeatedly transimt two 50 millisecond frames
*  Frame 1 = Message A, Message B, and optionally Message C
*  Frame 2 = Message B and optionally Message C
*  Message A: TA=3, TR=1, SA=0Ch, WC=4 (CWD=1D84h)
*  Message B: TA=9, TR=0, SA=0Eh, WC=2 (CWD=49C2h)
*  Message C: TA=9, TR=1, SA=0Fh, WC=18h (CWD=4DF8h)
*
*  Transmit Message C only if SRQ bit is set in status word of Message B
*
**/

#include "stdafx.h"

/**
*
*  PM11Ex1_ConfigSummitBC()
*  Configures the PM1553-1 Summit as a Bus Controller
*  Arguments:
*    handleval: card handle
*  Returns:  None
*  Warnings: None
*
**/

VOID PM11Ex1_ConfigSummitBC(HANDLE handleval)
{
	while(!PM11_SummitIsReady(handleval));								//Wait for Summit ready

	PM11_SummitWr(0x0002,0x0000,handleval);								//Reg  0 - Note STEX is disabled, Int log list enabled
	PM11_SummitWr(0x0000,0x0001,handleval);								//Reg  1 - Configured for BC
	PM11_SummitWr(0x0000,0x0002,handleval);								//Reg  2 - Current Command Reg
	PM11_SummitWr(0x0002,0x0003,handleval);								//Reg  3 - Enable Interrupt
	PM11_SummitWr(0x0000,0x0004,handleval);								//Reg  4 - Pending Int Reg
	PM11_SummitWr(0x4000,0x0005,handleval);								//Reg  5 - Int Log List Ptr Reg
	PM11_SummitWr(0x0000,0x0006,handleval);								//Reg  6 - BIT Word Reg
	PM11_SummitWr(0x0000,0x0007,handleval);								//Reg  7 - Time-Tag Reg
	PM11_SummitWr(0x0020,0x0008,handleval);								//Reg  8 - Points to first command block
	PM11_SummitWr(0x0000,0x0009,handleval);								//Reg  9 - 1553 Stat Word Bits Reg
	PM11_SummitWr(0x0000,0x000A,handleval);								//Reg 10 - BC Cmd Block Init Count Reg
	PM11_SummitWr(0x0000,0x000B,handleval);								//Reg 11 - Initial Mon Block Ptr Reg
	PM11_SummitWr(0x0000,0x000C,handleval);								//Reg 12 - Initial Mon Data Ptr Reg
	PM11_SummitWr(0x0000,0x000D,handleval);								//Reg 13 - Mon Block Counter Reg
	PM11_SummitWr(0x0000,0x000E,handleval);								//Reg 14 - Mon Filter Reg
	PM11_SummitWr(0x0000,0x000F,handleval);								//Reg 15 - Mon Filter Reg

	PM11_SummitWr(0x0000,0x0010,handleval);								//Illegal - Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,0x0011,handleval);								//Illegal - Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,0x0012,handleval);								//Illegal - Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,0x0013,handleval);								//Illegal - Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,0x0014,handleval);								//Illegal - Broadcast Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,0x0015,handleval);								//Illegal - Broadcast Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,0x0016,handleval);								//Illegal - Broadcast Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,0x0017,handleval);								//Illegal - Broadcast Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,0x0018,handleval);								//Illegal - Mode Code Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,0x0019,handleval);								//Illegal - Mode Code Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,0x001A,handleval);								//Illegal - Mode Code Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,0x001B,handleval);								//Illegal - Mode Code Xmt Subaddr 16-31
	PM11_SummitWr(0x0000,0x001C,handleval);								//Illegal - Mode Code Broadcast Rcv Subaddr  0-15
	PM11_SummitWr(0x0000,0x001D,handleval);								//Illegal - Mode Code Broadcast Rcv Subaddr 16-31
	PM11_SummitWr(0x0000,0x001E,handleval);								//Illegal - Mode Code Broadcast Xmt Subaddr  0-15
	PM11_SummitWr(0x0000,0x001F,handleval);								//Illegal - Mode Code Broadcast Xmt Subaddr 16-31

	//
	//  Each section of 8 SummitWr() statements below is a BC command block.
	//  Blocks are numbered for reference. The main BC schedule is blocks 0-5.
	//  The branch is blocks 6-8.
	//

	//
	//  Block 0
	//

	PM11_SummitWr(0xE000,0x0020,handleval);		//Load minor frame timer
	PM11_SummitWr(0x0000,0x0021,handleval);
	PM11_SummitWr(0x0000,0x0022,handleval);
	PM11_SummitWr(0x0000,0x0023,handleval);
	PM11_SummitWr(0x0000,0x0024,handleval);
	PM11_SummitWr(0x0000,0x0025,handleval);
	PM11_SummitWr(0x0000,0x0026,handleval);
	PM11_SummitWr(0x030E,0x0027,handleval);		//Timer value = 50ms

	//
	//  Block 1
	//

	PM11_SummitWr(0x4200,0x0028,handleval);		//Transmit Message A
	PM11_SummitWr(0x1D84,0x0029,handleval);		//Message A command word
	PM11_SummitWr(0x0000,0x002A,handleval);
	PM11_SummitWr(0x1000,0x002B,handleval);		//Message A data pointer
	PM11_SummitWr(0x0000,0x002C,handleval);
	PM11_SummitWr(0x0000,0x002D,handleval);
	PM11_SummitWr(0x0000,0x002E,handleval);
	PM11_SummitWr(0x0000,0x002F,handleval);

	//
	//  Block 2
	//
	PM11_SummitWr(0x6202,0x0030,handleval);		//Transmit Message B, branch on condition to block 6
	PM11_SummitWr(0x49C2,0x0031,handleval);		//Message B command word
	PM11_SummitWr(0x0000,0x0032,handleval);
	PM11_SummitWr(0x2000,0x0033,handleval);		//Message B data pointer
	PM11_SummitWr(0x0000,0x0034,handleval);
	PM11_SummitWr(0x0000,0x0035,handleval);
	PM11_SummitWr(0x0050,0x0036,handleval);		//Branch address (block 6)
	PM11_SummitWr(0x0000,0x0037,handleval);

	//
	//  Block 3
	//

	PM11_SummitWr(0xE000,0x0038,handleval);		//Load minor frame timer
	PM11_SummitWr(0x0000,0x0039,handleval);
	PM11_SummitWr(0x0000,0x003A,handleval);
	PM11_SummitWr(0x0000,0x003B,handleval);
	PM11_SummitWr(0x0000,0x003C,handleval);
	PM11_SummitWr(0x0000,0x003D,handleval);
	PM11_SummitWr(0x0000,0x003E,handleval);
	PM11_SummitWr(0x030E,0x003F,handleval);		//Timer value = 50ms

	//
	//  Block 4
	//

	PM11_SummitWr(0x6202,0x0040,handleval);		//Transmit Message B, branch on condition to block 6
	PM11_SummitWr(0x49C2,0x0041,handleval);		//Message B command word
	PM11_SummitWr(0x0000,0x0042,handleval);
	PM11_SummitWr(0x2000,0x0043,handleval);		//Message B data pointer
	PM11_SummitWr(0x0000,0x0044,handleval);
	PM11_SummitWr(0x0000,0x0045,handleval);
	PM11_SummitWr(0x0050,0x0046,handleval);		//Branch address (block 6)
	PM11_SummitWr(0x0000,0x0047,handleval);

	//
	//  Block 5
	//

	PM11_SummitWr(0x2000,0x0048,handleval);		//Goto
	PM11_SummitWr(0x0000,0x0049,handleval);
	PM11_SummitWr(0x0000,0x004A,handleval);
	PM11_SummitWr(0x0000,0x004B,handleval);
	PM11_SummitWr(0x0000,0x004C,handleval);
	PM11_SummitWr(0x0000,0x004D,handleval);
	PM11_SummitWr(0x0020,0x004E,handleval);		//Address of first command block 
	PM11_SummitWr(0x0000,0x004F,handleval);

	//
	//  Block 6
	//

	PM11_SummitWr(0x4200,0x0050,handleval);		//Transmit Message C
	PM11_SummitWr(0x4DF8,0x0051,handleval);		//Message C command word
	PM11_SummitWr(0x0000,0x0052,handleval);
	PM11_SummitWr(0x3000,0x0053,handleval);		//Message C data pointer
	PM11_SummitWr(0x0000,0x0054,handleval);
	PM11_SummitWr(0x0000,0x0055,handleval);
	PM11_SummitWr(0x0000,0x0056,handleval);
	PM11_SummitWr(0x0000,0x0057,handleval);

	//
	//  Block 7
	//

	PM11_SummitWr(0xA000,0x0058,handleval);		//Issue interrupt
	PM11_SummitWr(0x0000,0x0059,handleval);		//(Not used in this example)
	PM11_SummitWr(0x0000,0x005A,handleval);
	PM11_SummitWr(0x0000,0x005B,handleval);
	PM11_SummitWr(0x0000,0x005C,handleval);
	PM11_SummitWr(0x0000,0x005D,handleval);
	PM11_SummitWr(0x0000,0x005E,handleval);
	PM11_SummitWr(0x0000,0x005F,handleval);

	//
	//  Block 8
	//

	PM11_SummitWr(0xF000,0x0060,handleval);		//Return from branch 
	PM11_SummitWr(0x0000,0x0061,handleval);
	PM11_SummitWr(0x0000,0x0062,handleval);
	PM11_SummitWr(0x0000,0x0063,handleval);
	PM11_SummitWr(0x0000,0x0064,handleval);
	PM11_SummitWr(0x0000,0x0065,handleval);
	PM11_SummitWr(0x0000,0x0066,handleval);
	PM11_SummitWr(0x0000,0x0067,handleval);

	//
	//  Data initialization
	//

	PM11_SummitWr(0x0000,0x1000,handleval);		//Initialize data words for Message A
	PM11_SummitWr(0x0000,0x1001,handleval);		//These values will be overwritten by
	PM11_SummitWr(0x0000,0x1002,handleval);		//the data words transmitted by RT-A
	PM11_SummitWr(0x0000,0x1003,handleval);

	PM11_SummitWr(0x1234,0x2000,handleval);		//Initialize data words for Message B
	PM11_SummitWr(0x5678,0x2001,handleval);		//These values are received by RT-B

	PM11_SummitWr(0x0000,0x3000,handleval);		//Initialize data words for Message C
	PM11_SummitWr(0x0000,0x3001,handleval);
	PM11_SummitWr(0x0000,0x3002,handleval);
	PM11_SummitWr(0x0000,0x3003,handleval);
	PM11_SummitWr(0x0000,0x3004,handleval);
	PM11_SummitWr(0x0000,0x3005,handleval);
	PM11_SummitWr(0x0000,0x3006,handleval);
	PM11_SummitWr(0x0000,0x3007,handleval);
	PM11_SummitWr(0x0000,0x3008,handleval);
	PM11_SummitWr(0x0000,0x3009,handleval);
	PM11_SummitWr(0x0000,0x300A,handleval);
	PM11_SummitWr(0x0000,0x300B,handleval);
	PM11_SummitWr(0x0000,0x300C,handleval);
	PM11_SummitWr(0x0000,0x300D,handleval);
	PM11_SummitWr(0x0000,0x300E,handleval);
	PM11_SummitWr(0x0000,0x300F,handleval);
	PM11_SummitWr(0x0000,0x3010,handleval);
	PM11_SummitWr(0x0000,0x3011,handleval);
	PM11_SummitWr(0x0000,0x3012,handleval);
	PM11_SummitWr(0x0000,0x3013,handleval);
	PM11_SummitWr(0x0000,0x3014,handleval);
	PM11_SummitWr(0x0000,0x3015,handleval);
	PM11_SummitWr(0x0000,0x3016,handleval);
	PM11_SummitWr(0x0000,0x3017,handleval);
}

int _tmain(int argc,TCHAR *argv[],TCHAR *envp[])
{
	INT portnum = 0x2C0;
	INT irqnum  = 0;
	HANDLE handleval;													//PM1553-1 card handle
	USHORT data1;
	USHORT data2;

	_tprintf(_T("\nPM11BC  Version 1.0  (08/27/2007)"));
	_tprintf(_T("\nCopyright 2007  Ballard Technology, Inc.  Everett, WA, USA."));
	_tprintf(_T("\nAll rights reserved."));
	_tprintf(_T("\nGo to www.ballardtech.com or email support@ballardtech.com"));
	_tprintf(_T("\n"));
	_tprintf(_T("\n\"BC transmission with schedule.\""));
	_tprintf(_T("\n"));

	_tprintf(_T("\nUsage: PM11BC [portnum] [irqnum]"));
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
	//  Configure and start card
	//

	PM11Ex1_ConfigSummitBC(handleval);									//Configure SUMMIT (See below)
	PM11_SummitStart(handleval);										//Start the SUMMIT

	//
	//  Process data: The following code copies data words from Message A to Message B
	//

	_tprintf(_T("\nPress <ENTER> to exit....\n"));

	while(_gettchar()==WEOF)											//Loop until a key is pressed
	{
		data1 = PM11_SummitRd(0x1000,handleval);						///Get first two data words from Message A
		data2 = PM11_SummitRd(0x1001,handleval);

		
		PM11_SummitWr(data1,0x2000,handleval);							//Copy to first two data words for Message B
		PM11_SummitWr(data2,0x2001,handleval);
	}

	PM11_SummitStop(handleval);											//Stop Summit operation

	PM11_CardClose(handleval);											//Close card

	exit(0);
}
