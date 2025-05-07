
/**
*
*  LP-AFDX-1, LC-AFDX-1 and LM-AFDX-1 DRIVER EXAMPLE 5  Version 1.1  (03/31/2006)
*  Copyright (c) 2005-2006
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5.C -- Example 5.
*                      "Program for explicit transmit timing example"
*
**/

/**
*
*  This program opens the AFDX card number 0, and configures
*  sampling port-1 on VL-1 and sampling port-1 on VL-2 to
*  transmit. Unlike example 2 wich used the automatic schedule
*  creation function AX1_SchedBuild() this example creates and
*  runs an explicit schedule. The Ethernet ports are configured
*  to auto-negotiate network speed. The data is displayed on the
*  screen. May be used with example 1.
*
**/

#include "AX1W32.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM  0
#define BAG		 128
#define SKEW	 400
#define DST_PORT 1
#define VLID     1
#define PAYLOAD  20							// must be equal or greater than 17
#define FRAMELEN PAYLOAD+HEADERLEN_ALL+1	// Must be equal or greater than 60

void main(void)
{
	HCARD    Card;
	ERRVAL   errval;
	USHORT   vlid      = 1;
	ADDRESS  macdst;
	ADDRESS  macsrc;
	HVL      hvl[2];
	HPORT    hport[2];
	INT      i;
	BOOL     done;
	static BYTE data[MAX_AFDXPAYLOAD];
	static BYTE packet[MAX_AFDXPACKETSIZE];

	printf("\nEXAMP5 Version 1.1");
	printf("\nCopyright 2005-2006  Ballard Technology, Inc.  Everett, WA, USA.");
	printf("\nAll rights reserved.");
	printf("\nGo to www.ballardtech.com or email support@ballardtech.com");
	printf("\n");
	printf("\nLP-AFDX-1, LC-AFDX-1, and LM-AFDX-1 Example 5");
	printf("\n\"Program for explicit transmit timing example.\"");
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

	for (i=0; i<2; i++)
	{
		vlid = i + 1;

		errval = AX1_VLConfig(VLCFG_TX,					// Control Flags
							  vlid,						// Virtual Link Identifier
							  BAG,						// Bandwidth Alocation Gap in milliseconds
							  SKEW,						// SkewMax in microseconds
							  &(hvl[i]),				// Returned VL handle
							  NETID_REDUND,				// Network Identifier
							  Card);					// Card handle
		if (errval < 0)
		{
			printf("\nError: AX1_VLConfig returned error %d.\n\n",errval);
			AX1_CardClose(Card);
			exit(1);
		}

		errval = AX1_PortConfig(PORTCFG_SAMPLE,			// Config val
								DST_PORT,				// Destination port number
								1,						// Source port number
								0,						// Depth of port (queue ports only)
								&(hport[i]),			// Returned port handle
								hvl[i],					// VL handle
								Card);					// Card handle

		if (errval < 0)
		{
			printf("\nError: AX1_PortConfig returned error %d.\n\n",errval);
			AX1_CardClose(Card);
			exit(1);
		}
	}

/**
*
*  Create the transmit schedule.
*	VL-1 will transmit every 2ms. VL-2 will transmit every 4ms.
*
**/

	// Schedule Frame-1 (Two millisecond frame)
	errval = AX1_SchedFrameStart(2000, NETID_REDUND, Card);
	errval = AX1_SchedPort(FALSE, FALSE, TRUE, TRUE, hport[0], NULL, NETID_REDUND, Card);
	errval = AX1_SchedFrameEnd(NETID_REDUND, Card);

	// Schedule Frame-2 (Two millisecond frame)
	errval = AX1_SchedFrameStart(2000, NETID_REDUND, Card);
	errval = AX1_SchedPort(FALSE, FALSE, TRUE, TRUE, hport[0], NULL, NETID_REDUND, Card);
	errval = AX1_SchedPort(FALSE, FALSE, TRUE, TRUE, hport[1], NULL, NETID_REDUND, Card);
	errval = AX1_SchedFrameEnd(NETID_REDUND, Card);

/**
*
*  Initialize the data.
*
**/

	AX1_MakeDstMAC(VLID, &macdst);						// Create a destination MAC address
	AX1_MakeSrcMAC(0,0,0,INTID_BUS_A, &macsrc);			// Create a source MAC address

	AX1_PktPutHeaderConstants(packet);					// Place header constants in packet
	AX1_PktPutLenFromFrame(FRAMELEN,packet);			// Place frame length in packet
	AX1_PktPutDstMac(macdst, packet);					// Place destination MAC address in packet
	AX1_PktPutSrcMac(macsrc, packet);					// Place source MAC address in packet
	AX1_PktPutIPDest(AX1_MakeDstIP(VLID), packet);		// Create a destination IP and place it in packet
	AX1_PktPutIPSrc(AX1_MakeSrcIP(0,0,0,0), packet);	// Create a source IP and place it in packet
	AX1_PktPutUDPPortDest(DST_PORT,packet);				// Place destination port in packet			
	AX1_PktPutUDPPortSrc(1,packet);						// Place source port address in packet	

	for (i=OFFSET_UDPDATA; i<MAX_AFDXPACKETSIZE; i++)	packet[i]=(i%255);

	for (i=0; i<PAYLOAD; i++)	data[i]=(i%255);

	AX1_PktPutSeqNum(1,packet);							// Place the RSN in packet

	errval = AX1_PortRawWr(packet,				// Packet data array
						   MAX_AFDXPACKETSIZE,	// Packet size
						   hport[0],			// Port handle
						   Card);				// Card handle

	if (errval < 0)
	{
		printf("\nError: AX1_PortRawWr returned error %d.\n\n",errval);
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

	for (done=0;!done;)
	{
		if (_kbhit())
		{
			done=1;
		}

		// change data values
		data[0] += 1;
		data[1] += 2;
		data[2] += 4;

		// write to port on VL-1
		errval  = AX1_PortDataWr(0,						// RSN value (used with VLCFG_NOAUTORSN)
								 data,					// Payload data array
								 PAYLOAD,				// Payload size
								 hport[0],				// Port handle
			                     Card);					// Pard handle
		if (errval < 0)
		{
			printf("\nAX1_PortDataWr returned error %d.\n\n",errval);
		}

		// print to screen
		printf("\r changing data = %02X,%02X,%02X ", data[0], data[1], data[2]);
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
