/**
*
*  PM1553-1 Test Utility Version 1.0  (10/11/2002)
*  Copyright (c) 2002
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   PM11TEST.C -- PM11Test
*
*
**/

#include <stdio.h>
#include <stdlib.h>
#include "pm11.h"


// ----------------------------------------------------

int main(int argc, char* argv[])
{
	HANDLE hCard;

	USHORT addr;
	USHORT irq;

	int ret;

	printf("\nPM11TEST  Version 1.0  (10/11/2002)");
	printf("\nCopyright 2002 Ballard Technology, Inc.  Everett, WA, USA.");
	printf("\nAll rights reserved.");
	printf("\nGo to www.ballardtech.com or email support@ballardtech.com");
	printf("\n\n\n");

	if (argc == 1)
	{
		addr = 0x2C0;   // Assumes IO addr 2C0 if no arguments
		irq = 0;        // Assumes skipping IRQ testing if no arguments
	}
	else if (argc == 2)
	{
		sscanf(argv[1],"%x",&addr);  // Select IO address
		irq = 0;                     // Skip IRQ if one argument
	}
	else if (argc == 3)
	{
		sscanf(argv[1],"%x",&addr);  // Select IO
		sscanf(argv[2],"%d",&irq);   // Select IRQ
	}
	else
	{
		printf("\nTest Program Instructions");
		printf("\n");
		printf("\nUseage: 'pm11test [iobase] [interrupt]'");
		printf("\nRuns selftest of PM1553-1 card at I/O address 0x2C0.");
		printf("\nOption: iobase    -- Specifies hex I/O address of card (0x200 to 0x3F0).");
		printf("\n        interrupt -- Specifies IRQ of card (3,4,5,7,9,10,11,12).");
	}

	// the string here is the same as the value of the 'SymbolicName'
	// variable in the .inf (for win 2000) or .reg (in NT4.0), with the
	// prefix '\\\\.\\'
	hCard = PM11_CardOpen("\\.\\\\PM1553Card", addr);

	switch((int) hCard)
	{
	case ERR_MEM:	// this only gets passed back if CardOpen is called
					// more than PM41_MAXCARDS times.   Increase the
					// value of PM41_MAXCARDS to get around this.
		printf("FAILED: Not enough memory");
		return(0);
		
	default:
		printf("opened card %x at 0x%x\n", hCard, addr);
	}

	ret = PM11_SelfTest(addr,irq);


	switch(ret)
	{
	case ERR_NONE:
		printf("PASSED");
		break;
	case ERR_BADPARAMS:
		printf("FAILED - IO address or IRQ not valid");
		break;
	case ERR_NOCARD:
		printf("FAILED - Card not present");
		break;
	case ERR_SELFIOFAIL:
		printf("FAILED - Error reading/writing card registers");
		break;
	case ERR_BITFAIL:
		printf("FAILED - Summit BIT failed");
		break;
	case ERR_IRQFAIL:
		printf("FAILED - Error IRQ not configured correctly or conflict exists");
		break;
	case ERR_UNKNOWN:
	default:
		printf("Unknown ERROR");
	}

	PM11_CardClose(addr);

	return ret;
}

