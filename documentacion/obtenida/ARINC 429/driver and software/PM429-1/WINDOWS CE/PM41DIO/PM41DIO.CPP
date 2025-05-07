/**
*
*  PM429-1 EXAMPLE 3  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM41DIO.CPP -- Digital I/O, timer, LED example.
*
**/

/**
*
*  This program opens the PM429-1 card and toggles the LED.
*
**/

#include "stdafx.h"

int _tmain(int argc,TCHAR *argv[],TCHAR *envp[])
{
	INT portnum = 0x2C0;
	INT irqnum  = 0;
	INT ch;
	BOOL done;
	USHORT count;																			//Index of DIN SRQ
	UINT time;																				//Timer value
	HANDLE handleval;																		//Card handle

	_tprintf(_T("\nPM41DIO  Version 1.0  (08/27/2007)"));
	_tprintf(_T("\nCopyright 2007  Ballard Technology, Inc.  Everett, WA, USA."));
	_tprintf(_T("\nAll rights reserved."));
	_tprintf(_T("\nGo to www.ballardtech.com or email support@ballardtech.com"));
	_tprintf(_T("\n"));
	_tprintf(_T("\n\"Program for Digital input/output, Timer, LED example.\""));
	_tprintf(_T("\n"));

	_tprintf(_T("\nUsage: PM41DIO [portnum] [irqnum]"));
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
	//	Open PM429-1 card
	//

	_tprintf((irqnum) ? _T("\nOpening PM429-1 card at port=%04X, irq=%d"):_T("\nOpening PM429-1 card at port=%04X"),portnum,irqnum);

	if (!PM41_CardOpen(&handleval,portnum,irqnum))
	{
		_tprintf(_T("\nError:  Unable to open card"));
		_tprintf(_T("\n"));
		exit(1);
	}

	//
	//	Reset the card
	//
	   
	PM41_CardReset(handleval);																//Reset card

	//
	//  Configure DIN/DOUT signals.  We will configure DIN0 to generate 
	//  a service request (SRQ), and use that SRQ to increment a hit counter. 
	//  If service requests are configured within 16 Msec of card reset	and
	//  the digital input is high, a positive edge may be seen due to the 
	//  card coming out of reset.
	//
	//  We will configure DOUT0 to be set and reset via the console, and  
	//  slave DOUT0 to the user LED.  The on-board timer will count at a 1Msec
	//  rate and be displayed on the screen in seconds.
	//

	count = 0;																				//Reset counter

	PM41_DINConfig(DSAMP_DBRES_1MS, 1, handleval);											//Configure DIN sample rate at 1 KHZ
	
	PM41_DINSRQSet(DINT_SRQ_0P, handleval);													//Configure DIN0 for SRQ on rising edge

	PM41_TimerConfig(TCTRL_RES_1MS | TCTRL_INCR, handleval);								//Configure timer for 1 Ms resolution, free run
	PM41_TimerStart(handleval);																//Start timer

	_tprintf(_T("\n"));
	_tprintf(_T("\nPress SPACE and <ENTER> to toggle DOUT0 & LED"));
 	_tprintf(_T("\nPress Q     and <ENTER> to exit....\n\n"));

	for (done=FALSE;!done;)																	//Run until the ESC key is pressed
	{
		ch = _gettchar();

		if (ch!=WEOF)																		//If a key is pressed
		{
			if (ch=='q' || ch=='Q') done=TRUE;

			if (ch==0x20)																	//Toggling DOUT0	
			{
				if (PM41_DOUTIsSet(DOUT_0, handleval))										//Check for DOUT0 set
				{
					PM41_DOUTClr(DOUT_0, handleval);										//Reset DOUT0
					PM41_LEDWr(FALSE, handleval);											//Reset user LED
				}
				else
				{
					PM41_DOUTWr(DOUT_0, handleval);											//Set DOUT0
					PM41_LEDWr(TRUE, handleval);											//Set user LED
				}
			}
		}

		if (PM41_SRQIsSet(SRQ_DIN0, handleval))
		{
			count++;																		//Increment SRQ count when SRQ received
			PM41_SRQClr(SRQ_DIN0, handleval);												//Clear SRQ
		}

		time = PM41_TimerRd(handleval);

		_tprintf(_T("\r"));																										//Display count
		_tprintf(_T("We saw DIN0 pulsed %d times.  Timer has run for %ld Sec "),count,(time/1000));
	}

	PM41_CardClose(handleval);											//Close card

	exit(0);
}
