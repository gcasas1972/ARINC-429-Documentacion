/**
*
*  PM429-1 EXAMPLE 1  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM41RCV.CPP -- Program for receiver example
*
**/

/**
*
*  This program opens the PM429-1 card at port 0x2C0, and
*  configures RCH0 to receive 2 GPS messages and display 
*  them on the screen.  All other messages are ignored.
*
**/

#include "stdafx.h"

int _tmain(int argc,TCHAR *argv[],TCHAR *envp[])
{
	INT portnum = 0x2C0;
	INT irqnum  = 0;
	USHORT val;																				//Comparison/loop variable
	HANDLE handleval;																		//Card handle

	UCHAR label[16];																		//Array of label filters

	UINT data;																				//Received data
	UINT lon_recv;																			//Displayed longitude
	UINT lat_recv;																			//Displayed latitude

	UCHAR lat_label;
	UCHAR lon_label;

    lat_label = PM41_UtilReverseLabel(0310);												//Label for latitude
	lon_label = PM41_UtilReverseLabel(0311);												//Label for longitude

	lon_recv = 0;																			//Initialize data variables
	lat_recv = 0;

	_tprintf(_T("\nPM41RCV  Version 1.0  (08/27/2007)"));
	_tprintf(_T("\nCopyright 2007  Ballard Technology, Inc.  Everett, WA, USA."));
	_tprintf(_T("\nAll rights reserved."));
	_tprintf(_T("\nGo to www.ballardtech.com or email support@ballardtech.com"));
	_tprintf(_T("\n"));
	_tprintf(_T("\n\"Program for receiver example.\""));
	_tprintf(_T("\n"));

	_tprintf(_T("\nUsage: PM41RCV [portnum] [irqnum]"));
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
	//  Set filters on desired labels.  All 16 label positions must be filled,
	//  even if less than 16 labels are desired.  Note that label 00 is treated
	//  the same as any other label.
	//

	label[0]= lat_label;											//Set first label array position with latitude label.

	for (val=1;val<=15;++val)										//Fill remaining array with longitude label.
	{
		label[val] = lon_label;
	}

	PM41_FilterLabelSet(label, CH0, handleval);						//Load labels into PM429-1.

	//
	//  Set PM429-1 service requests.  A service request (SRQ)
	//  will be set for RCH0 when any data is present in the PM429-1.
	//

	PM41_SRQConfig(ASRQ_RCV_RDY, CH0, handleval);					//Set SRQ

	//
	//  Configure channel RCH0 to be active and to receive at low speed.
	//

	PM41_ChConfig(ARINCCTRL_SPEED_LOW, ARINCCTRL_PAR_ODD, FALSE, FALSE, CH0, handleval);	//Configure RCH0

	//
	//  Display data on the screen.
	//

	_tprintf(_T("\nPress <ENTER> to exit....\n"));

	while(_gettchar()==WEOF)
	{
		if (PM41_SRQIsSet(SRQ_RCH0, handleval))						//Check for data in RCH0
		{
			data = PM41_ChDataRd(CH0, handleval);
			if ((data & 0x000000FF) == lat_label)
			{
				lat_recv = data;
			}
			else if ((data & 0x000000FF) == lon_label)
			{
				lon_recv = data;
			}
			else
			{
				_tprintf(_T("\nError: Data %08lX was received in error"), data);
			}

		}

		_tprintf(_T("\r"));											//Display values
		_tprintf(_T("Latitude=%08lX "),lat_recv);
		_tprintf(_T("     Longitude=%08lX"),lon_recv);
	}

	PM41_CardClose(handleval);										//Close card

	exit(0);
}
