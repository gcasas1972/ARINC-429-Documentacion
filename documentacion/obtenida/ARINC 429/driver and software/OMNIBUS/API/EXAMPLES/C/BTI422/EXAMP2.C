
/**
*
*  BTI422 DRIVER EXAMPLE 2  (06/09/2011)
*  Copyright (c) 2004-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- Polling the Event Log List
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first serial port at 115,200 bps with 8 bit data,
*  no parity, 1 stop bit.  The port is loaded with
*  initial data.  An Event Log List is configured and
*  the transmit FIFO is enabled to generate an Event
*  Log List entry when there are 8 bytes left.  The
*  program polls for these events and writes more data
*  to the port that caused the event.
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
#define	BUFSIZE       1024

void main(void)
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT corenum;
	INT port;
	INT j;
	USHORT type;
	INT count = 0;
	BYTE databuf[BUFSIZE];

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP2  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2004-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI422 Example 2                                                  *");
	printf("\n    *  \"Polling the Event Log List example.\"                             *");
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
*  Find the first ARINC 422 core.
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
		printf("\nError:  No ARINC 422 ports present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 422 core #%d",corenum);
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
*  Init data.
*
**/

	for (j=0;j<BUFSIZE;j++) databuf[j] = ((count)+j);
	BTI422_FIFODataWr(databuf,BUFSIZE,0,port,hCore);
	count++;

/**
*
*  Configure the Event Log list.
*
**/

	errval = BTICard_EventLogConfig(LOGCFG_ENABLE,256,hCore);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the event log list.",errval);
		fprintf(stderr,"\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure FIFO Threshold.
*
**/

	//Enable Threshold Event Logging
	BTI422_FIFOConfigTx(FIFOCFG422_TXTHRESHOLD,256,port,hCore);

/**
*
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");

	while (!kbhit())
	{
		if (BTICard_EventLogRd(&type,NULL,&port,hCore))	//Read entry from Event Log list
		{
			if (type == EVENTTYPE_422TXTHRESHOLD)
			{
				for (j=0;j<=BUFSIZE;j++) databuf[j] = ((count)+j);
				BTI422_FIFODataWr(databuf,BUFSIZE,0,port,hCore);

				printf("\nUpdated data for port%1d. (count = %d)",port,count);

				count++;
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
