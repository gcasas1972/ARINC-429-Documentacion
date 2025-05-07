/**
*
*  PM429-1 EXAMPLE 2  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM41XMT.CPP -- Program for transmitter example using polling.
*
**/

/**
*
*  This program detects the PM429-1 card at port 0x2C0, and
*  then transmits the messages with ramping data.
*
**/

#include "stdafx.h"

int _tmain(int argc,TCHAR *argv[],TCHAR *envp[])
{
	INT portnum = 0x2C0;
	INT irqnum  = 0;
	HANDLE handleval;																		//Card handle

	UINT airspeed_data;																		//Data value
	UINT airspeed_label;																	//Label
	UINT airspeed_sdi;																		//SDI
	UINT airspeed_ssm;																		//SSM

	UINT airtemp_data;																		//Data value
	UINT airtemp_label;																		//Label
	UINT airtemp_sdi;																		//SDI
	UINT airtemp_ssm;																		//SSM

	_tprintf(_T("\nPM41XMT  Version 1.0  (08/27/2007)"));
	_tprintf(_T("\nCopyright 2007  Ballard Technology, Inc.  Everett, WA, USA."));
	_tprintf(_T("\nAll rights reserved."));
	_tprintf(_T("\nGo to www.ballardtech.com or email support@ballardtech.com"));
	_tprintf(_T("\n"));
	_tprintf(_T("\n\"Program for transmitter example using polling.\""));
	_tprintf(_T("\n"));

	_tprintf(_T("\nUsage: PM41XMT [portnum] [irqnum]"));
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
	//  Configure channel TCH4 to be active and to transmit at low speed.
	//  A service request (SRQ) will be set when the transmit FIFO is empty.
	//

	PM41_ChConfig(ARINCCTRL_SPEED_LOW, ARINCCTRL_PAR_ODD, FALSE, FALSE, CH4, handleval);	//Configure TCH4
	PM41_SRQConfig(ASRQ_XMT_EMPT,CH4, handleval);

	//
	//  Initialize variables
	//

	airspeed_data  = 0;																		//Set data
	airspeed_label = PM41_UtilReverseLabel(0210);											//Set label (reverse bit order of octal 210)
	airspeed_sdi   = (0 <<  9);																//Set SDI 
	airspeed_ssm   = (2 << 29);																//Set SSM 

	airtemp_data   = 0;																		//Set data
	airtemp_label  = PM41_UtilReverseLabel(0211);											//Set label (reverse bit order of octal 211)
	airtemp_sdi    = (0 <<  9);																//Set SDI 
	airtemp_ssm    = (2 << 29);																//Set SSM 

	//
	//  Change data until a key is pressed.  The messages will be scheduled such that 
	//  the airspeed message will be transmitted every 75ms, and the air temperature
	//  message will be transmitted every 150ms. The SDI/SSM/label values are placed into 
	//  the proper place in the data word.  The messages will be placed into two 75ms frames.
	//
	//  See the PM429-1 manual for details of calculating schedule times.
	//

	_tprintf(_T("\nPress <ENTER> to exit....\n"));

	while(_gettchar()==WEOF)
	{
		//
		//  First frame: Airspeed and air temperature messages are processed.
		//

		airspeed_data = (airspeed_data & 0x1FFFFC00);										//Filter out SDI/SSM/label
		airspeed_data = (airspeed_data >> 10);												//Shift data to LSB position

		if (airspeed_data > 0x0007FFFE)
		{
			airspeed_data = 0;																//If max value is reached, reset data.
		}
		else
		{
			airspeed_data++; 																//Increment data
		}

		airspeed_data = (airspeed_data << 10);												//Shift data back to proper position
		airspeed_data = (airspeed_data | airspeed_sdi | airspeed_ssm |airspeed_label);		//OR in SDI/SSM/label

		//
		//  Begin processsing air temp. message
		//

		airtemp_data = (airtemp_data & 0x1FFFFC00);											//Filter out SDI/SSM/label
		airtemp_data = (airtemp_data >> 10);												//Shift data to LSB position

		if (airtemp_data > 0x0007FFFE)
		{
			airtemp_data = 0; 																//If max value is reached, reset data.
		}
		else
		{
			airtemp_data++;																	//Increment data
		}

		airtemp_data = (airtemp_data << 10);												//Shift data back to proper position
		airtemp_data = (airtemp_data | airtemp_sdi | airtemp_ssm | airtemp_label);			//OR in SDI/SSM/label

		_tprintf(_T("\rAirspeed = %08lX     Airtemp = %08lX"), airspeed_data, airtemp_data);

		while(!PM41_SRQIsSet(SRQ_TCH4, handleval));											//Wait for complete transmission of second frame*/
		
		PM41_ChDataWr(airspeed_data, CH4, handleval);										//Write data  to TCH4
		PM41_ChDataWr(airtemp_data, CH4, handleval);										//Write data  to TCH4

		PM41_ChGapWr(870, CH4, handleval);													//Write gap : this will begin transmission

		//
		//  Second frame: Airspeed message is processed.
		//

		airspeed_data = (airspeed_data & 0x1FFFFC00);										//Filter out SDI/SSM/label
		airspeed_data = (airspeed_data >> 10);												//Shift data to LSB position

		if (airspeed_data > 0x0007FFFE)
		{
			airspeed_data = 0;																//If max value is reached, reset data.
		}
		else
		{
			airspeed_data++;																//Increment data
		}

		airspeed_data = (airspeed_data << 10);												//Shift data back to proper position
		airspeed_data = (airspeed_data | airspeed_sdi | airspeed_ssm | airspeed_label);		//OR in SDI/SSM/label

		_tprintf(_T("\rAirspeed = %08lX     Airtemp = %08lX"), airspeed_data, airtemp_data);

		while(!PM41_SRQIsSet(SRQ_TCH4, handleval));											//Wait for complete transmission of first frame*/
		
		PM41_ChDataWr(airspeed_data, CH4, handleval);										//Write data  to TCH4

		PM41_ChGapWr(905, CH4, handleval);													//Write gap
	
	}

	PM41_CardClose(handleval);																//Close card

	exit(0);
}
