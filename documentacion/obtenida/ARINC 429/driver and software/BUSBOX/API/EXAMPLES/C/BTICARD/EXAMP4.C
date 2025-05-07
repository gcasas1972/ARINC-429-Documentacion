
/**
*
*  BTICard DRIVER EXAMPLE 4  (06/09/2011)
*  Copyright (c) 2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4.C -- Displaying SysMon
*
**/

/**
*
*  This example configures Card Number 0 to display the
*  current information in SysMon.
*
**/

#include "BTICard.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include <fcntl.h>

#define	CARDNUM 0
#define CORENUM 0
#define SYSMON_NUMSENSORS 16
#define TRUE 1
#define FALSE 0

int main()
{
	HCARD  hCard;					/*Handle to card*/
	HCORE  hCore;					/*Handle to core*/
	ERRVAL errval;					/*Error return value*/

	INT timer;						/*Timer to see if Sensors are ready to be read*/

	INT index;						/*Sensor index value*/
	BOOL enable;					/*Sensor logging enable value*/
	INT minval;						/*Sensor minimum threshold value*/
	INT maxval;						/*Sensor maximum threshold value*/
	CHAR tempstr[64];

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP4  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2011 Ballard Technology, Inc.  Everett, WA, USA.        *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICard Example 4                                                 *");
	printf("\n    *  \"Displaying SysMon\"                                               *");
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
*  Check to make sure SysMon is supported on this card/core
*
**/

	errval = BTICard_BITConfig(BITCFG_DEFAULT,hCore);

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
*  Display information for each sensor
*
**/

	printf("\n");

	for (index=0; index < SYSMON_NUMSENSORS; index++)
	{
		/**
		*
		*  Display Sensor Type
		*
		**/

		switch (BTICard_SysMonTypeGet(index,hCore))
		{
			case SYSMONTYPE_TEMP:
				strcpy(tempstr,"Temperature");
				break;
			case SYSMONTYPE_VOLTAGE:
				strcpy(tempstr,"Voltage");
				break;
			case SYSMONTYPE_CURRENT:
				strcpy(tempstr,"Current");
				break;
			default:
				continue;
				break;
		}

		printf("\nSensor #%02i: %s",index,tempstr);

		/**
		*
		*  Display Sensor Description
		*
		**/

		printf("\n            \"%s\"",BTICard_SysMonDescGet(index,hCore));
		printf("\n----------------------------------");
		/**
		*
		*  Display Read Value
		*
		**/

		printf("\n            Current Value: %s",BTICard_SysMonUserStr(BTICard_SysMonValRd(index,hCore),index,hCore));

		/**
		*
		*  Display Nominal Value (Valid for Voltage Sensors)
		*
		**/

		if (BTICard_SysMonTypeGet(index,hCore) == SYSMONTYPE_VOLTAGE)
		{
			printf("\n            Nominal Value: %s",BTICard_SysMonUserStr(BTICard_SysMonNomRd(index,hCore),index,hCore));
		}

		/**
		*
		*  Display Historical Minimum
		*
		**/

		printf("\n       Historical Minimum: %s",BTICard_SysMonUserStr(BTICard_SysMonMinRd(index,hCore),index,hCore));

		/**
		*
		*  Display Historical Maximum
		*
		**/

		printf("\n       Historical Maximum: %s",BTICard_SysMonUserStr(BTICard_SysMonMaxRd(index,hCore),index,hCore));

		/**
		*
		*  Display User Settings (Available for Temperature Sensors)
		*
		**/

		errval = BTICard_SysMonThresholdGet(&enable,&minval,&maxval,index,hCore);

		if (!errval)
		{
			printf("\n     Threshold Monitoring: %s",(enable) ? "Enabled":"Disabled");
			printf("\n   User Minimum Threshold: %s",BTICard_SysMonUserStr(minval,index,hCore));
			printf("\n   User Maximum Threshold: %s",BTICard_SysMonUserStr(maxval,index,hCore));
		}

		printf("\n");
	}

	printf("\n");

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardClose(hCard);

	system("pause");

	return(0);
}
