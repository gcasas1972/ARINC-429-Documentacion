
/**
*
*  BTICard DRIVER EXAMPLE 2  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP2.C -- Toggling LED and DIO
*
**/

/**
*
*  This example opens Card Number 0 and finds the first
*  digital out (DOUT) signal.  The user presses the spacebar
*  to toggle the DOUT and card LED light on and off.
*
**/

#include "BTICard.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0
#define CORENUM 0

/**
*
*  This helper function determines the first DOUT number by
*  looking at the board information.
*
**/

INT BTICard_GetFirstDOUTNum(HCARD hCard)
{
	switch (BTICard_CardGetInfo(INFOTYPE_HWGEN, 0, hCard))
	{
		case 3:	return 3;	/*3RD GEN*/
		case 4:	return 5;	/*4TH GEN*/
		case 5:	return 9;	/*5TH GEN*/
	}

	return -1;
}


void main(void)
{
	HCARD  hCard;					/*Handle to card*/
	HCORE  hCore;					/*Handle to core*/
	ERRVAL errval;					/*Error return value*/
	INT    doutnum;

	int  done;
	int  val;
	char ch;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP2  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICard Example 2                                                 *");
	printf("\n    *  \"Toggling LED and DIO\"                                            *");
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
	printf("\nUsing BTICard card #%d",CARDNUM);

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
*  Determine the DOUT number.
*
**/

	doutnum = BTICard_GetFirstDOUTNum(hCard);

	if (doutnum < 0)
	{
		printf("\nError:  Unable to determine the DOUT number.");
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}
	printf("\nUsing DOUT number #%d",doutnum);

/**
*
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Display data
*
**/

	done = 0;		/* We are '!done' */
	ch = '?';		/* invalid data */
	val = 0;		/* DOUT un-set */

	printf("\n\nPress ESC to exit, <SPACE> to toggle DOUT and LED....\n\n");

	/* Print current values */
	printf("\rDOUT and LED are %s",(val ? (" ON") : ("OFF")));

	while(!done)
	{
		if (_kbhit())	/* If a key is pressed ... */
		{
			ch = _getch();	/* get the last key pressed */
			switch(ch)
			{
			case 0x1B:	/* ESC */
				done = 1;	/* We are done */
				break;

/***
*
*	On command, toggle the value of the selected DOUT and of the board LED.
*	These are done through native API functions. The LED is lock stepped to
*	the DOUT line.
*
***/
			case ' ':	/* <SPACE> */
				val = val ? 0 : 1;											/* invert output value */
				BTICard_ExtDIOWr(doutnum,val,hCore);						/* write value to DOUT */
				BTICard_ExtStatusLEDWr(val, 0, hCore);						/* write value to LED */
				printf("\rDOUT and LED are %s",(val ? (" ON") : ("OFF")));	/* Print current values */
				break;

			default:	/* All else, do nothing */
				break;
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
