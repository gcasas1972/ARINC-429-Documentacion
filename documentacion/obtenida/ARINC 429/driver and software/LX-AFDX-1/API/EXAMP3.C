
/**
*
*  LP-AFDX-1, LC-AFDX-1 and LM-AFDX-1 DRIVER EXAMPLE 3  Version 1.1  (03/31/2006)
*  Copyright (c) 2005-2006
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- Example 3.
*                      "Program for transmit example (Queueing port)"
*
**/

/**
*
*  This program opens the AFDX card number 0, and configures
*  queueing port-1 on VL-1 to transmit. The Ethernet ports are
*  configured to auto-negotiate network speed. The queue is
*  initially empty. Each time the user presses the spacebar a
*  packet is added to the queue for transmission.
*
**/

#include "AX1W32.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM  0
#define VLID     1
#define BAG		 128
#define SKEW	 400
#define DST_PORT 1
#define PAYLOAD  20							// Must be equal or greater then 17
#define FRAMELEN PAYLOAD+HEADERLEN_ALL+1	// Must be equal or greater than 60

void main(void)
{
	HCARD    Card;
	ERRVAL   errval;
	ADDRESS  macdst;
	ADDRESS  macsrc;
	HVL      hvl;
	HPORT    hport;
	USHORT   fun = 0;
	BOOL     done;
	USHORT   wrcount = 0;
	char     ch;
	static BYTE packet[MAX_AFDXPACKETSIZE];

	printf("\nEXAMP3  Version 1.1");
	printf("\nCopyright 2005-2006  Ballard Technology, Inc.  Everett, WA, USA.");
	printf("\nAll rights reserved.");
	printf("\nGo to www.ballardtech.com or email support@ballardtech.com");
	printf("\n");
	printf("\nLP-AFDX-1, LC-AFDX-1, and LM-AFDX-1 Example 3");
	printf("\n\"Program for transmit example (Queueing port).\"");
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
*  Create Virtual Link and Port
*
**/

	errval = AX1_VLConfig(VLCFG_TX,					// Control Flags
						  VLID,						// Virtual Link Identifier
						  BAG,						// Bandwidth Alocation Gap in milliseconds
						  16,						// SkewMax in microseconds
						  &(hvl),					// Returned VL handle
						  NETID_REDUND,				// Network Identifier
						  Card);					// Card handle
	if (errval < 0)
	{
		printf("\nError: AX1_VLConfig returned error %d.\n\n",errval);
		AX1_CardClose(Card);
		exit(1);
	}

	errval = AX1_PortConfig(PORTCFG_QUEUE,			// Config val
							DST_PORT,				// Destination port number
							1,						// Source port number
							10,						// depth of port
							&(hport),				// Returned port handle
							hvl,					// VL Handle
							Card);					// Card handle

	if (errval < 0)
	{
		printf("\nError: AX1_PortConfig returned error %d.\n\n",errval);
		AX1_CardClose(Card);
		exit(1);
	}

/**
*
*  Create the transmit schedule.
*
**/

	errval = AX1_SchedBuild(NETID_REDUND, Card);
	if (errval < 0)
	{
		printf("\nError: AX1_SchedBuild returned error %d.\n\n",errval);
		AX1_CardClose(Card);
		exit(1);
	}

/**
*
*  Create a raw packet to send on the queue port
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
	AX1_PktPutSeqNum(1,packet);							// Place the RSN in packet

	errval = AX1_PortRawWr(packet,						// Packet data array
						   FRAMELEN,					// Packet size
						   hport,		    			// Port handle
						   Card);						// Card handle

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
*  Write the packet to the port each press of the space bar.
*
**/

	printf("\r");
	printf("Press SPACEBAR ..to add a Msg to the Queue -- uses RawWr\n");
	printf("Press 'D'........to add a Msg to the Queue -- uses DataWr\n");
	printf("Press ESC .......to exit\n\n");

	for (done=0;!done;)
	{
		printf("\rQueue port write count: %u",wrcount);

		if (_kbhit())
		{
			ch = _getch();

			if (ch=='d' || ch=='D')
			{
				errval = AX1_PortDataWr(0,&(packet[HEADERLEN_ALL]), PAYLOAD, hport, Card);
				if (errval)
				{
					printf("\nPortRawWr returned error %d.\n",errval);
				}
				else
				{
					++wrcount;
				}
			}

			if (ch==' ')
			{
				errval = AX1_PortRawWr(packet, FRAMELEN, hport, Card);
				if (errval)
				{
					printf("\nPortRawWr returned error %d.\n",errval);
				}
				else
				{
					++wrcount;
				}
			}

			if (ch==27)
			{
				done=1;
			}
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
