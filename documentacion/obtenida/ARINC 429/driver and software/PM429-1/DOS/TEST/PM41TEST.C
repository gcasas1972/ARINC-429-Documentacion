/**
*
*  PM429-1 Test Utility Version 1.0  (10/31/2001)
*  Copyright (c) 2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM41TEST.C -- PM41Test
*                  
*
**/

#include <stdio.h>
#include <stdlib.h>
#include "pm41.h"


// ----------------------------------------------------

int main(int argc, char* argv[])
{
	USHORT addr;
	USHORT irq;

	int ret;

	printf("\nPM41TEST  Version 1.0  (10/31/2001)");
	printf("\nCopyright 2001  Ballard Technology, Inc.  Everett, WA, USA.");
	printf("\nAll rights reserved.");
	printf("\nGo to www.ballardtech.com or email support@ballardtech.com");
	printf("\n\n\n");

	if (argc == 1)
	{
		addr = 0x2C0;
		irq = 0;
	}
	else if (argc == 2)
	{
		sscanf(argv[1],"%x",&addr);
		irq = 0;
	}
	else if (argc == 3)
	{
		sscanf(argv[1],"%x",&addr);
		sscanf(argv[2],"%d",&irq);
	}
	else
	{
		printf("\nTest Program Instructions");
		printf("\n");
		printf("\nUseage: 'pm41test [iobase] [interrupt]'");
		printf("\nRuns selftest of PM4291- card at I/O address 0x2C0.");
		printf("\nOption: iobase    -- Specifies hex I/O address of card (0x200 to 0x3F0).");
		printf("\n        interrupt -- Specifies IRQ of card (3,4,5,7,9,10,11,12).");
	}

	ret = PM41_SelfTest(addr,irq);


	switch(ret)
	{
	case ERR_NONE:
		printf("PASSED");
		break;
	case ERR_BADPARAMS:
		printf("FAILED - IO address not valid");
		break;
	case ERR_NOCARD:
		printf("FAILED - Card not present");
		break;
	case ERR_SELFIOFAIL:
		printf("FAILED - Error reading/writing card registers");
		break;
	case ERR_SELFXMTFAIL:
		printf("FAILED - Error in transmission on internal wrap-around");
		break;
	case ERR_IRQFAIL:
		printf("FAILED - Error IRQ not configured correctly or conflict exists");
		break;
	case ERR_UNKNOWN:
	default:
		printf("Unknown ERROR");
	}
	
	return ret;
}

