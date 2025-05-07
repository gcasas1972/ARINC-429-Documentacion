
/**
*
*  BTI422 DRIVER EXAMPLE 1  (06/09/2011)
*  Copyright (c) 2004-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Transmit and receive example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first serial port at 115,200 bps with 8 bit data,
*  no parity, 1 stop bit. Each key pressed is transmitted
*  and each character received is displayed.
*
**/

#include "BTICard.H"
#include "BTI422.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_PORTS     16

void main(void)
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT corenum;
	INT port;
	BOOL done;
	BYTE ch;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP1  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2004-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI422 Example 1                                                  *");
	printf("\n    *  \"Program for transmit and receive example.\"                       *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
	printf("\n");

/**
*
*  Open the card with the specified card number.
*  An error value is returned which is tested
*  to determine if an error occurred.
*
**/

	errval = BTICard_CardOpen(&hCard,CARDNUM);

	if (errval)
	{
		printf("\nError:  Either card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		exit(1);
	}

	printf("\nUsing ARINC 422 card #%d",CARDNUM);

/**
*
*  Find the first core with a serial port.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (port=0;port<MAX_PORTS;port++)
		{
			if (BTI422_PortIs422(port, hCore))	break;
		}

		if (port != MAX_PORTS) break;
	}

	if (errval || corenum == MAX_CORES || port == MAX_PORTS)
	{
		printf("\nError:  No serial ports present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing serial core #%d",corenum);
	printf("\nUsing port #%d",port);
	printf("\n");

/**
*
*  Configure port.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI422_PortConfig(PORTCFG422_PARITYNONE,BITRATE422_115200BPS,port,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring port %d.",errval,port);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Display data on the screen.
*
**/

	printf("\nPress ESC key to exit....\n\n");
	done = 0;

	while (!done)
	{
		if (BTI422_FIFODataRd(&ch,1,NULL,port,hCore))
		{
			if(ch == 0x0d)		// Carriage return
			{
				printf("\n");
			}
			else
			{
				printf("%c",ch);
			}
		}

		if (kbhit())
		{
			ch = getch();

			if (ch == 0x1B)		// ESC key
			{
				done = 1;
			}
			else if(ch == 0xE0)	// Function key
			{
				ch = getch();	// Function keys have extra keypress
			}
			else
			{
				BTI422_FIFODataWr(&ch,1,0,port,hCore);
			}
		}
	}

/**
*
*  Stop the card.
*
**/

	BTICard_CardStop(hCore);

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardClose(hCard);
}
