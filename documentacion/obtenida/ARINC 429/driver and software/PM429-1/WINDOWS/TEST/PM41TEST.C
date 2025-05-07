/**
*
*  PM429-1 Test Utility Version 1.0  (01/16/2003)
*  Copyright (c) 2001-2003
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

	HANDLE hCard;		/* PM429-1 card descriptor */
	int ret;

	printf("\nPM41TEST  Version 1.0  (01/16/2003)");
	printf("\nCopyright 2001-2003  Ballard Technology, Inc.  Everett, WA, USA.");
	printf("\nAll rights reserved.");
	printf("\nGo to www.ballardtech.com or email support@ballardtech.com");
	printf("\n\n\n\n");

	if (argc == 1)
	{
		addr = 0x2C0;
		irq = 11;
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
		printf("\n        interrupt -- Specifies IRQ of card (3,4,5,7,9,10,11,12).\n");
	}

	// the string here is the same as the value of the 'SymbolicName'
	// variable in the .inf (for win 2000) or .reg (in NT4.0), with the
	// prefix '\\\\.\\'
	hCard = PM41_CardOpen("\\\\.\\PM429Card00", addr);

	switch((int) hCard)
	{
	case ERR_MEM:	// this only gets passed back if CardOpen is called
					// more than PM41_MAXCARDS times.   Increase the
					// value of PM41_MAXCARDS to get around this.
		printf("FAILED: Not enough memory");
		return ERR_MEM;
		
	default:
		printf("opened card %x at 0x%x\n", hCard, addr);
	}

	ret = PM41_SelfTest(addr,irq);

	switch(ret)
	{
	case ERR_NONE:
		printf("PASSED\n");
		break;
	case ERR_BADPARAMS:
		printf("FAILED - IO address not valid\n");
		break;
	case ERR_NOCARD:
		printf("FAILED - Card not present\n");
		break;
	case ERR_SELFIOFAIL:
		printf("FAILED - Error reading/writing card registers\n");
		break;
	case ERR_SELFXMTFAIL:
		printf("FAILED - Error in transmission on internal wrap-around\n");
		break;
	case ERR_IRQFAIL:
		printf("FAILED - Error IRQ not configured correctly or conflict exists\n");
		break;
	case ERR_UNKNOWN:
	default:
		printf("Unknown ERROR\n");
	}

	if(FALSE == PM41_CardClose(addr))	/* release the card */
	{
		printf("Error closing card\n");
	}
	
	return ret;
}
