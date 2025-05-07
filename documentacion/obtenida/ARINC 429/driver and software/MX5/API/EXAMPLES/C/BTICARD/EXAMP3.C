
/**
*
*  BTICard DRIVER EXAMPLE 3  (06/09/2011)
*  Copyright (c) 2009-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP3.C -- Monitoring DIO
*
**/

/**
*
*  This example configures Card Number 0 to record DIO in
*  the sequential monitor.  This program monitors rising
*  edges on DIN lines 1,2,3,4,5,6 and the first DOUT line
*  on the core.  The DOUT signal is toggled each time the
*  user presses the spacebar.  The contents of the
*  sequential monitor is output to the screen.
*
*  The card number and DOUT signal line number can be
*  specified on the command line.
*
**/

#include "BTICard.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>

#define	CARDNUM 0
#define CORENUM 0

/**
*
*  This helper function checks for the help option on the
*  command line.
*
**/

int isarghelp(int argc,char *argv[])
{
	int j;

	for (j=0;j<argc;++j)
	{
		if (!strcmp(argv[j],"?") || !strcmp(argv[j],"-?") || !strcmp(argv[j],"/?"))
		{
			return(1);
		}
	}
	return(0);
}

/**
*
*  This helper function checks for options on the
*  command line.
*
**/

char *isargopt(int argc,char *argv[],const char *opts)
{
	USHORT j;

	for (j=0;j<argc;++j)
	{
		if ((*argv[j]=='-' || *argv[j]=='/') && !_strnicmp(opts,argv[j]+1,strlen(opts)))
		{
			return(argv[j]+strlen(opts)+1);
		}
	}
	return(NULL);
}

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


void main(int argc,char *argv[])
{
	HCARD  hCard;					/*Handle to card*/
	HCORE  hCore;					/*Handle to core*/
	ERRVAL errval;					/*Error return value*/
	INT    cardnum;
	INT    doutnum;

	USHORT rise;
	BOOL   done;
	INT    val=0;
	char   ch;
	char   *opts;

	USHORT seqbuf[2048];
	ULONG  seqcount;
	ULONG  blkcnt;
	LPSEQRECORDDIO pRecDIO;
	SEQFINDINFO sfinfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP3  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2009-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTICard Example 3                                                 *");
	printf("\n    *  \"Monitoring DIO\"                                                  *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
	printf("\n");

/**
*
*  Check if we should display the help information.
*
**/

	if (isarghelp(argc,argv))
	{
		printf("\nUsage:  EXAMP3 [options]");
		printf("\n");

		printf("\n-?                    Display help information");
		printf("\n-CARDNUM:dd           Set the card number.  Default 0.");
		printf("\n-DOUTNUM:dd	        Set the DOUT number.  Default 9.");
		printf("\n");
		exit(0);
	}

	printf("\nFor help:  EXAMP3 ?");
	printf("\n");

/**
*
*  Check for the -CARDNUM:dd option.
*
**/

	cardnum = CARDNUM;

	if ((opts = isargopt(argc,argv,"CARDNUM")) != NULL)
	{
		_strupr(opts);

		if (*opts++ != ':')
		{
			printf("\nError:  Semicolon is missing after option."
							"\n        Use the form -CARDNUM:<number>.");
			printf("\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			printf("\nError:  The card number is missing after the option."
							"\n        Use the form -CARDNUM:<number>.");
			printf("\n");
			exit(1);
		}

		if (sscanf(opts,"%u",&cardnum)!=1)
		{
			printf("\nError:  The card number is not a decimal number."
							"\n        Use the form -CARDNUM:dd.");
			printf("\n");
			exit(1);
		}
	}

	printf("\nUsing BTICard card #%d",cardnum);

/**
*
*  Open the card with the specified card number.
*  An error value is returned which is tested
*  to determine if an error occurred.
*
**/

	errval = BTICard_CardOpen(&hCard,cardnum);

	if (errval)
	{
		printf("\nError:  Either card number %u is not present, or",cardnum);
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
		exit(1);
	}
	printf("\nUsing Core #%d",CORENUM);

/**
*
*  Check for the -DOUTNUM:dd option.
*
**/

	BTICard_CardReset(hCore);									/*Reset the core*/

	doutnum = BTICard_GetFirstDOUTNum(hCard);

	if ((opts = isargopt(argc,argv,"DOUTNUM")) != NULL)
	{
		_strupr(opts);

		if (*opts++ != ':')
		{
			printf("\nError:  Semicolon is missing after option."
							"\n        Use the form -DOUTNUM:<number>.");
			printf("\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			printf("\nError:  The DOUT number is missing after the option."
							"\n        Use the form -DOUTNUM:<number>.");
			printf("\n");
			exit(1);
		}

		if (sscanf(opts,"%u",&cardnum)!=1)
		{
			printf("\nError:  The DOUT number is not a decimal number."
							"\n        Use the form -DOUTNUM:dd.");
			printf("\n");
			exit(1);
		}
	}

	if (doutnum <= 0 || doutnum > 16)
	{
		printf("\nError:  Unable to determine the DOUT number.");
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}
	printf("\nUsing DOUT number #%d",doutnum);

/**
*
*  Configure the DIO for Monitor.
*
**/

	//Monitor rising edges on DIN lines 1,2,3,4,5,6 and DOUT line doutnum
	rise = 0x0001 + 0x0002 + 0x0004 + 0x0008 + 0x0010 + 0x0020;
	rise = rise + (1 << (doutnum - 1));

	errval = BTICard_ExtDIOMonConfig(rise,0,0,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the DIO for monitor on core #%d.",CORENUM);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCore));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure the Sequential Monitor.
*
**/

	errval = BTICard_SeqConfig(SEQCFG_DEFAULT,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the sequential monitor on core #%d.",CORENUM);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
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
*  Loop until a key is hit.
*
**/

	printf("\nPress ESC to exit, <SPACE> to toggle DOUT and LED....\n\n");
	printf("\n\n");

	done = 0;

	while (!done)
	{
		//Read keyboard
		if (_kbhit())
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
				break;

			}
		}

		//Read the sequential monitor buffer
		seqcount = BTICard_SeqBlkRd(seqbuf,sizeof(seqbuf)/sizeof(seqbuf[0]),&blkcnt,hCore);

		if (!seqcount) continue;

		BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

		while(!BTICard_SeqFindNextDIO(&pRecDIO,&sfinfo))
		{
			printf("Time Stamp: %08lX\n",pRecDIO->timestamp);

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
