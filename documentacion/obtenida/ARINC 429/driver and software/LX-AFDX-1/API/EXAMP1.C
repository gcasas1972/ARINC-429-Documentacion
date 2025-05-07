
/**
*
*  LP-AFDX-1, LC-AFDX-1 and LM-AFDX-1 DRIVER EXAMPLE 1  Version 1.1  (03/31/2006)
*  Copyright (c) 2005-2006
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Example 1.
*                      "Program for receiver example"
*
**/

/**
*
*  This program opens the AFDX card number 0, and configures
*  sampling port-1 on VL-1 to receive. The Ethernet ports are
*  configured to auto-negotiate network speed. The received
*  data is displayed on the screen along with the associated
*  timetag values. May be used with example 2, 3, 4 or 5.
*
**/

#include "AX1W32.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM  0
#define VLID	 1
#define BAG		 128
#define SKEW	 400
#define DST_PORT 1

void main(void)
{
	HCARD    Card;
	ERRVAL   errval;
	HVL      hvl;
	HPORT    hport;
	USHORT   length;
	BYTE     rsn;
	ULONG    tth;
	ULONG    ttl;
	ULONG    ttsec;
	ULONG    ttusec;
	static BYTE data[MAX_AFDXPAYLOAD];

	printf("\nEXAMP1  Version 1.1");
	printf("\nCopyright 2005-2006  Ballard Technology, Inc.  Everett, WA, USA.");
	printf("\nAll rights reserved.");
	printf("\nGo to www.ballardtech.com or email support@ballardtech.com");
	printf("\n");
	printf("\nLP-AFDX-1, LC-AFDX-1, and LM-AFDX-1 Example 1");
	printf("\n\"Program for receiver example.\"");
	printf("\n");

/**
*
*  Open the card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	errval = AX1_CardOpen(&Card, CARDNUM);
	if (errval < 0)
	{
		printf("\nError:  Either AFDX card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",errval);
		printf("\n");
		exit(1);
	}

	printf("\nPlease wait for the device to reset...");

	errval = AX1_CardReset(Card);
	if (errval < 0)
	{
		printf("\nError: AX1_CardReset returned error %d.\n\n",errval);
		AX1_CardClose(Card);
		exit(1);
	}

	printf("\rReset complete\t\t\t\t");

/**
*
*  Configure the redundant network to auto-negotiate speed
*
**/

	errval = AX1_NetConfig(NETCFG_DEFAULT,0,NETSPEED_AUTO,NETID_REDUND,Card);
	if (errval < 0)
	{
		printf("\nError: AX1_NetConfig returned error %d.\n\n",errval);
		AX1_CardClose(Card);
		exit(1);
	}

/**
*
*  Create Virtual Links and Ports
*
**/

	errval = AX1_VLConfig(VLCFG_RCV,			// Control Flags
						  VLID,					// Virtual Link Identifier
						  BAG,					// Bandwidth Alocation Gap in milliseconds
						  SKEW,					// SkewMax in microseconds
						  &hvl,					// Returned VL Handle
						  NETID_REDUND,			// Network Identifier
						  Card);				// Card handle
	if (errval < 0)
	{
		printf("\nError: AX1_VLConfig returned error %d.\n\n",errval);
		AX1_CardClose(Card);
		exit(1);
	}

	errval = AX1_PortConfig(PORTCFG_SAMPLE,		// Config val
							DST_PORT,			// Destination port number
							1,					// Source port number
							0,					// Depth of port (queue ports only)
							&hport,				// Returned port handle
							hvl,				// VL handle
							Card);				// Card handle

	if (errval < 0)
	{
		printf("\nError: AX1_PortConfig returned error %d.\n\n",errval);
		AX1_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card.
*
**/

	AX1_CardStart(Card);

/**
*
*  Display data on the screen.
*
**/

	printf("\rPress any key to exit....\n\n");

	while(!_kbhit())
	{
		length = MAX_AFDXPAYLOAD;

		errval = AX1_PortDataRd(data,		// byte array
								&length,	// IN = size of array, OUT = size of valid data
								&rsn,		// Sequence number
								&tth,		// Timetag hi
								&ttl,		// Timetag lo
								hport,		// Port Handle
			                    Card);		// handle to card

		if (!errval && length)
		{
			/* Convert the timetag to units of seconds */
			AX1_TimeGetSeconds(tth, ttl, &ttsec, &ttusec);

			printf("\rRSN:%03u Time:%01u.%06u Data:%02X,%02X,%02X...    ",
				   rsn,
				   ttsec,ttusec,
				   data[0], data[1], data[2]);
		}
	}

/**
*
*  Stop the card.
*
**/

	AX1_CardStop(Card);

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	AX1_CardClose(Card);
}
