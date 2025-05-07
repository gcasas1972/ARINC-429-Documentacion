/**
*
*  BTICard DRIVER EXAMPLE 5  (06/09/2011)
*  Copyright (c) 2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5.C -- Polling Eventlog for BIT
*
**/

/**
*
*  This example configures Card Number 0 to report BIT
*  errors in the Eventlog as well as the Eventlog.
*  Once configured, the Eventlog is polled for a BIT Error
*  Event and if an error occurs, the error is decoded.
*
**/

#include "BTICard.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define CORENUM		  0
#define SYSMON_NUMSENSORS 16
#define TRUE 1
#define FALSE 0

int main()
{
	HCARD   hCard;					/*Handle to card*/
	HCORE   hCore;					/*Handle to core*/
	ERRVAL  errval;					/*Error return value*/

	INT index;						/*Sensor index value*/
	BOOL enable;					/*Sensor logging enable value*/
	INT minval;						/*Sensor minimum threshold value*/
	INT maxval;						/*Sensor maximum threshold value*/

	USHORT  type;					/*Eventlog type*/
	ULONG   info;					/*Eventlog info*/

	INT timer;						/*Timer to see if Sensors are ready to be read*/

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP5  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2011  Ballard Technology, Inc.  Everett, WA, USA.       *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICard Example 5                                                 *");
	printf("\n    *  \"BIT Eventlog Polling\"                                            *");
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

	printf("\nUsing BTICard card #%d",CARDNUM);

	errval = BTICard_CardOpen(&hCard,CARDNUM);

	if (errval)
	{
		printf("\nError:  Either card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		exit(1);
	}

	errval = BTICard_CoreOpen(&hCore, CORENUM, hCard);

	if (errval)
	{
		printf("\nError:  Either core number %u is not present, or",CORENUM);
		printf("\n        an error occurred (%i) opening the core.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing Core #%d",CORENUM);

/**
*
*  Check to make sure SysMon is supported on this card/core and configure it for EventLog
*
**/

	errval = BTICard_BITConfig( BITCFG_MEMECC_LOG |
								BITCFG_CARD_STOPPED_LOG |
								BITCFG_FPGA_LOG |
								BITCFG_SYSMON_LOG |
								BITCFG_PROTOCOL_LOG,hCore);


	if (errval)
	{
		printf("\nError:  Either SysMon is not supported on this card, or",CORENUM);
		printf("\n        an error occurred (%i) while Configuring BIT.",errval);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Set each of the sensors to enable reporting
*
**/

	for (index=0; index < SYSMON_NUMSENSORS; index++)
	{
		/**
		*
		*  Read User Settings (Available for Temperature Sensors)
		*
		**/

		errval = BTICard_SysMonThresholdGet(&enable,&minval,&maxval,index,hCore);

		if (!errval && !enable)
		{
			/**
			*
			*  Restore User Settings while setting the reporting enable
			*
			**/

			errval = BTICard_SysMonThresholdSet(TRUE,minval,maxval,index,hCore);
		}
	}

/**
*
*  Configure the Event Log list.
*
**/

	errval = BTICard_EventLogConfig(LOGCFG_ENABLE,1024,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        event log list on core #%d.",CORENUM);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Verify that the sensor data is ready to be read
*
**/

	timer = BTICard_TickTimerStart(875);

	while (BTICard_TickTimerValid(timer) && (BTICard_SysMonValRd(0,hCore) == SYSMONRD_NOTVALID));

	if (BTICard_SysMonValRd(0,hCore) == SYSMONRD_NOTVALID)
	{
		printf("\nError:  Sensors exceeded timeout to be valid");
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Start the card
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit....\n\n");

	while (!_kbhit())
	{
		if (BTICard_EventLogRd(&type,&info,NULL,hCore))
		{
			printf("\nType = %08x info = %08x",type,info);

			/**
			*
			*  Check to see if Event is a BIT Error
			*
			**/

			if (type == EVENTTYPE_BITERROR)
			{
				if (info & BITSTAT_CARD_STOPPED)
				{
					printf("\nCard Stopped Error");
				}

				if (info & BITSTAT_CBIT_FPGA_ERR)
				{
					printf("\nCard CBIT FPGA");
				}

				if (info & (BITSTAT_SINGLE_BIT_ERR | BITSTAT_DOUBLE_BIT_ERR))
				{
					printf("\nECC Memory Error");
				}

				if (info & BITSTAT_SYSMON_ERR)
				{
					printf("\nSysmon error, 0x%04X ",info & BITSTAT_SYSMON_ERR);

					for (index = 0;index < SYSMON_NUMSENSORS;index++)
					{
						if ((info & BITSTAT_SYSMON_ERR) & 1<<index)
						{
							printf("\n     Error on index:%i",index);
						}
					}
				}

				if (info & BITSTAT_PROTOCOL_ERR)
				{
					printf("\nProtocol Error");
				}
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

	return(0);
}
