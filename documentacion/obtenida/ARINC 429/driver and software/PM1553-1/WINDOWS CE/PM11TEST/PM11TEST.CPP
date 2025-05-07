/**
*
*  PM1553-1 TEST UTILITY  Version 1.0  (08/27/2007)
*  Copyright (c) 2007
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM11TEST.CPP -- PM1553-1 Test Utility
*
*
**/

#include "stdafx.h"

int _tmain(int argc,TCHAR *argv[],TCHAR *envp[])
{
	INT portnum = 0x2C0;
	INT irqnum  = 0;
	INT result;
	HANDLE handleval;

	_tprintf(_T("\nPM11TEST  Version 1.0  (08/27/2007)"));
	_tprintf(_T("\nCopyright 2007  Ballard Technology, Inc.  Everett, WA, USA."));
	_tprintf(_T("\nAll rights reserved."));
	_tprintf(_T("\nGo to www.ballardtech.com or email support@ballardtech.com"));
	_tprintf(_T("\n"));

	_tprintf(_T("\nUsage: PM11TEST [portnum] [irqnum]"));
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

	_tprintf((irqnum) ? _T("\nOpening PM1553-1 card at port=%04X, irq=%d: "):_T("\nOpening PM1553-1 card at port=%04X: "),portnum,irqnum);

	if (!PM11_CardOpen(&handleval,portnum,irqnum))
	{
		_tprintf(_T("\nError:  Unable to open card"));
		_tprintf(_T("\n"));
		exit(1);
	}

	//
	//	Perform self test
	//

	result = PM11_SelfTest(handleval);

	switch(result)
	{
		case ERR_NONE:
			_tprintf(_T("PASSED"));
			break;
		case ERR_BADPARAMS:
			_tprintf(_T("FAILED - IO address or IRQ not valid"));
			break;
		case ERR_NOCARD:
			_tprintf(_T("FAILED - Card not present"));
			break;
		case ERR_SELFIOFAIL:
			_tprintf(_T("FAILED - Error reading/writing card registers"));
			break;
		case ERR_BITFAIL:
			_tprintf(_T("FAILED - Summit BIT failed"));
			break;
		case ERR_IRQFAIL:
			_tprintf(_T("FAILED - Error IRQ not configured correctly or conflict exists"));
			break;
		case ERR_UNKNOWN:
			_tprintf(_T("Unknown ERROR"));
			break;
		default:
			_tprintf(_T("Unknown ERROR %d"),result);
			break;
	}

	_tprintf(_T("\n"));

	//
	//	Close card
	//

	PM11_CardClose(handleval);

	exit(0);
}
