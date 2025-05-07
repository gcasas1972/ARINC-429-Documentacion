
/**
*
*  PC-SSB-1 TRANSMIT DEMONSTRATION PROGRAM  Version 1.0  (12/31/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:  DEMOTX.C -- PC-SSB-1 Transmit Demonstration C Program.
*
**/

/**
*
*   This C program implements a simple transmit message and
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
	INT MWC;							//Value of Monitor Word Count Register
	INT temp;							//Temporary variable
	INT attr;							//Value of Attribute Byte in monitor
	USHORT wc;							//Number of data words to transmit
	USHORT block;						//Block number to transmit from
	BYTE status;						//Value of Status Register 0
	ULONG dwd[2];						//Data word array
	HCARD handleval;					//Card handle value
	ERRVAL errval;						//Error return value
	static ULONG mon[1024];				//Monitor array

	ULONG memval=0xCC00;				//Memory value
	INT ioval=0x2C0;					//IO Port address
	INT irqval=2;						//Interupt number

	fprintf(stderr,"\nDEMOTX  Version 1.0  (12/31/1999)");
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
*  The following section resets the monitor, configures the
*  PC-SSB card, and initializes the variables used in the call to
*  SSBT_TxMsg().
*
**/

	SSBT_ResetMon(handleval);						//Reset monitor

	status = SSBT_Config(BCMODE | MONMODE | TX0BUS | RC0BUS,handleval);	//Configure

	dwd[0]=0x12345678L;								//Initialize first data word
	dwd[1]=0x9ABCDEF0L;								//Initialize second data word

	wc    = 2;										//Initialize number of data words
	block = 0;										//Initialize block number

/**
*
*  The following section triggers the card, obtains the status,
*  and copies the contents of the monitor memory.
*
**/

    status = SSBT_TxMsg(0xCBA987L,dwd,wc,block,handleval);	//Trigger and get status	
	MWC    = SSBT_MonMsg(mon,handleval);					//Read monitor memory

/**
*
*  The following section displays the status and the contents of
*  the monitor memory.
*
**/

	printf("Status Register 0 = %02XH\n",status);	//Display status register value

	if (status & STAT0_ERROR)						//If ERROR bit in status set
	{
		printf("An error occurred.\n");				//Display error
	}

	for (temp=0;temp<MWC;++temp)					//Loop for each word in monitor
	{
		attr = (int)((mon[temp] >> 24) & 0xFFL);	//Retrieve Attribyte Byte
		mon[temp] &= 0xFFFFFFL;						//Mask off Attribyte Byte

		printf("mon[%u] = %06lX ",temp,mon[temp]);	//Print monitor value

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
