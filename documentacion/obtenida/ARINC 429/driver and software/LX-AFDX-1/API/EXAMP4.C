
/**
*
*  LP-AFDX-1, LC-AFDX-1 and LM-AFDX-1 DRIVER EXAMPLE 4  Version 1.1  (03/31/2006)
*  Copyright (c) 2005-2006
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4.C -- Example 4.
*                      "Program for monitor example"
*
**/

/**
*
*  This program opens the card number 0, and configures
*  the sequential monitor to record all traffic. The
*  Ethernet ports are configured to auto-negotiate network
*  speed. While the card is running the monitor state is
*  displayed on the screen. Once the user presses any key
*  the card is stopped and the monitor data is dumped to
*  the screen.
*
**/


#include "AX1W32.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM   0

void main(void)
{
	HCARD   Card;
	ERRVAL  errval;
	BOOL	bDone;
	USHORT  seqtype;
	ULONG   bytecount;
	INT     reccount;
	USHORT  seqstatus;
	ULONG   total;
	static BYTE mondata[MAX_SEQRDBUFSIZE];

	LPBYTE pRec;
	SEQFINDINFO sfinfo;
	LPAFDXPKTDESC rec;
	LPAFDXPKTDESCHDR recheader;

	printf("\nEXAMP4 Version 1.1");
	printf("\nCopyright 2005-2006  Ballard Technology, Inc.  Everett, WA, USA.");
	printf("\nAll rights reserved.");
	printf("\nGo to www.ballardtech.com or email support@ballardtech.com");
	printf("\n");
	printf("\nLP-AFDX-1, LC-AFDX-1, and LM-AFDX-1 Example 4");
	printf("\n\"Program for monitor example.\"");
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
*  Configure the sequential monitor to record all packets.
*  Records the full packet with header info.
*
**/

	errval = AX1_SeqConfig(SEQCFG_ALL, Card);
	if (errval < 0)
	{
		printf("\nError: AX1_SeqConfig returned error %d.\n\n",errval);
		AX1_CardClose(Card);
		exit(1);
	}

	AX1_CardStart(Card);

/**
*
*  Display monitor data
*
**/

	total = 0;
	bDone = FALSE;

	printf("\rPress any key to stop the card....\n\n");

	while(!bDone && !_kbhit())
	{
		AX1_SeqStatus(&seqstatus, Card);

		if (SEQSTAT_PARTIAL == seqstatus)
		{
			bytecount = MAX_SEQRDBUFSIZE;
			reccount  = AX1_SeqRd(mondata, &bytecount, Card);

			AX1_SeqFindInit(mondata, bytecount, &sfinfo);

			while(reccount && !AX1_SeqFindNext(&pRec,&seqtype,&sfinfo))
			{
				total++;
				switch (seqtype & SEQTYPE_MASK)
				{
					default:
						printf("%03d: unknown seqtype = %04X \n",total, seqtype);
						break;
					case SEQTYPE_UDPFULL:
						rec = (LPAFDXPKTDESC)pRec;
						printf("%03d: seqtype=UDP-FULL reclen=%u tth=%08X tt=%08X data:%02X-%02X-%02X...\n",
							    total,
								rec->count,
								rec->timestamph,
								rec->timestamp,
								rec->packet[0],
								rec->packet[1],
								rec->packet[2]);
						break;
					case SEQTYPE_UDPNOPAYLOAD:
						recheader = (LPAFDXPKTDESCHDR)pRec;
						printf("%03d: seqtype=UDP-NOPAYLOAD, reclen=%u, tt=%08X \n",
							    total,
								recheader->count,
								recheader->timestamp);
						break;
					case SEQTYPE_OTHERFULL:
						printf("%03d: other seqtype  seqtype=%04X \n",total,seqtype);
						break;
				}

				if (total%10 && _kbhit())
				{
					bDone = TRUE;
					break;
				}
			}
		}
	}

	AX1_CardStop(Card);

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	AX1_CardClose(Card);
}
