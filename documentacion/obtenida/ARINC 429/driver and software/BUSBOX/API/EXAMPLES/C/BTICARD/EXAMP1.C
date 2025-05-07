
/**
*
*  BTICard DRIVER EXAMPLE 1  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP1.C -- Report BTIDriver devices
*
**/

/**
*
*  This example uses a special feature of the BTICard_CardOpen()
*  function to search the computer for registered Ballard BTIDriver
*  devices.  The program loops through the array of discovered
*  devices and outputs some generic card information.
*
**/

#include "BTICard.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

void main(void)
{
	HCARD  hCard;					/*Handle to card*/
	ERRVAL errval;					/*Error return value*/
	ULONG  cardnum;
	USHORT j;
	ULONG ulGen;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP1  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICard Example 1                                                 *");
	printf("\n    *  \"Report BTIDriver devices\"                                        *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
	printf("\n");

	// Find all possible cards on this machine and the known universe
	BTICard_CardOpen(&hCard, 0xFFFF);		// cardnum of 0xFFFF = Search all possible cards

	// Loop through cards
	for (j=0;j<BTICard_HandleTotalCount;j++)
	{
		//Get the cardnum from the driver array of cardnums (filled in the special cardopen call)
		cardnum = BTICard_HandleCardNumbers[j];

		printf("\nFound BTICard card #%d", cardnum);

		//
		//  Open the card with the specified card number.
		//  An error value is returned which is tested
		//  to determine if an error occurred.
		//

		errval = BTICard_CardOpen(&hCard, cardnum);
		if(0!=errval || 0>hCard)
		{
			BTICard_CardClose(hCard);
			continue;
		}

		printf("\n  CardTypeStr: %s",		BTICard_CardTypeStr(hCard));
		printf("\n  CardProductStr: %s",	BTICard_CardProductStr(hCard));
		printf("\n  Card Info PROD: %u",	BTICard_CardGetInfo(INFOTYPE_PROD,0,hCard));
		printf("\n  Card Info GEN: %u",		BTICard_CardGetInfo(INFOTYPE_GEN,0,hCard));
		printf("\n*********************************\n");

/**
*
*  The card MUST be closed before continuing
*
**/

		BTICard_CardClose(hCard);
	}
}
