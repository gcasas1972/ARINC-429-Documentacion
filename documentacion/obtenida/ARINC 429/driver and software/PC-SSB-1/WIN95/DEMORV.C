
/**
*
*  PC-SSB-1 RECEIVE DEMONSTRATION PROGRAM  Version 1.0  (12/31/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:  DEMORV.C -- PC-SSB-1 Receive Demonstration C Program.
*
**/

/**
*
*   This C program implements a simple receive message and
*   displays any result.
*
*   To compile this program with the Borland C++ compiler, use
*   the following command line:
*
*   BCC32 DEMOTX.C PS1W32.LIB
*
*   To compile this program with the Visual C++ compiler,
*   use the following command line:
*
*   CL DEMOTX.C PS1W32.LIB
*
**/

#include "ps1w32.h"
#include <stdio.h>

void main(void)
{
	INT AWC;							//Value of Actual Word Count Register
	INT temp;							//Temporary variable
	INT attr;							//Value of Attribute Byte in monitor
	USHORT wc;							//Number of data words to receive
	USHORT block;						//Block number to receive into
	BYTE status;						//Value of Status Register 0
	ULONG dwd[2];						//Data word array
	HCARD handleval;					//Card handle value
	ERRVAL errval;						//Error return value
	
	ULONG memval=0xCC00;				//Memory value
	INT ioval=0x2C0;					//IO Port address
	INT irqval=2;						//Interupt number

	fprintf(stderr,"\nDEMORV  Version 1.0  (12/31/1999)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");

/**
*
*  The following section selects the PC-SSB card to use and
*  checks if it actually exists.
*
**/

	handleval = SSBT_CardOpen(memval,ioval,irqval);		//Open card at specified memory and port addresses

	if (handleval<0)									//Verify the handle
	{
		printf("\nError:  Unable to open the PC-SSB-1 card at MEM=%04XH PORT=%03XH IRQ=%u (%i).",memval,ioval,irqval,handleval);
		printf("\n");
		exit(1);
	}

/**
*
*	Check if the specified card exists.
*
**/

	errval = SSBT_Check(handleval);

	if (errval)
	{
		printf("\nError:  Unable to find the card at MEM=%04XH PORT=%03XH IRQ=%u (%i).",memval,ioval,irqval,errval);
		printf("\n");
		exit(1);
	}

/**
*
*  The following section configures the PC-SSB card and
*  initializes the variables used in the call to SSBT_RcMsg().
*
**/

	status = SSBT_Config(BCMODE | TX0BUS | RC0BUS,handleval);	//Configure

	wc    = 2;										//Initialize number of data words
	block = 0;										//Initialize block number

	status = SSBT_RcMsg(0xCBA987L,dwd,wc,block,handleval);	//Trigger and get status
	AWC    = SSBT_RdAWC(handleval);							//Read Actual Word Count Register

	printf("Status Register 0 = %02XH\n",status);	//Display status register value

	if (status & STAT0_ERROR)						//If ERROR bit in status set
	{
		printf("An error occurred.\n");				//Display error
	}

	if (status & STAT0_NORESP)						//If NORESP bit in status set
	{
		printf("No response received from the RT.\n");
	}

	if ((status & STAT0_WCERR) && AWC<wc)				//If WCERR bit in status set
	{
		if (AWC<wc)										//If AWC too short
		{
			printf("Too few data words received.\n");	//Display error
		}
		else
		{
			printf("Too many words received.\n");		//Display error
		}
	}

	for (temp=0;temp<AWC;++temp)
	{
		attr = (int)((dwd[temp] >> 24) & 0xFFL);	//Retrieve Attribyte Byte
		dwd[temp] &= 0xFFFFFFL;						//Mask off Attribyte Byte

		printf("dwd[%u] = %06lX ",temp,dwd[temp]);	//Print dwd value

		printf((attr & ATTR_RBUS)  ? "BUSB "     : "BUSA ");		//Print
		printf((attr & ATTR_PGAP)  ? "GAP "      : "    ");			//attribute
		printf((attr & ATTR_RSYNC) ? "CMDSYNC  " : "DATASYNC ");	//byte
		printf((attr & ATTR_WERR)  ? "ERROR "    : "      ");

		printf("\n");
	}

/**
*
*	The card must be closed before the program exits.
*
**/

	SSBT_CardClose(handleval);
}
