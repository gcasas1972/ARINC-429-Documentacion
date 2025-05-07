
/**
*
*  BTI429 DRIVER EXAMPLE 7  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP7.C -- File transfer example
*
**/

/**
*
*  This program opens Card Number 0, finds the first
*  compatible core, and configures an asynchronous transmit
*  list buffer.  The program reads a data file and transmits
*  that data with a user-specified label.  If no data file
*  or label is specified by the user, the default values are
*  examp7.dat, and label 0172.
*
**/

#include "BTICard.h"
#include "BTI429.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

char filename[256] = "EXAMP7.DAT";
ULONG label = 0172;

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
		if ((*argv[j]=='-' || *argv[j]=='/') && !strnicmp(opts,argv[j]+1,strlen(opts)))
		{
			return(argv[j]+strlen(opts)+1);
		}
	}
	return(NULL);
}

void main(int argc,char *argv[])
{
	HCARD hCard;
	HCORE hCore;
	ERRVAL errval;
	INT corenum;
	INT xmtchan;
	FILE *fh;
	char *opts;

	LISTADDR asynclistaddr;
	ULONG Data;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP7  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI429 Example 7                                                  *");
	printf("\n    *  \"Program for file transfer.\"                                      *");
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
		printf("\nUsage:  EXAMP7 [options]");
		printf("\n");

		printf("\n-?                    Display help information");
		printf("\n-LABEL:ooo            Set the label (octal).  Default 0172.");
		printf("\n-FILENAME:<filename>  File to read data from. Default EXAMP7.DAT.");
		printf("\n");
		exit(0);
	}

	printf("\nFor help:  EXAMP7 ?");
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

	printf("\nUsing ARINC 429 card #%d",CARDNUM);

/**
*
*  Check for the -FILENAME:<filename> option.
*
**/

	if ((opts = isargopt(argc,argv,"FILENAME")) != NULL)
	{
		strupr(opts);

		if (*opts++ != ':')
		{
			printf(	"\nError:  Semicolon is missing after option."
							"\n        Use the form -FILENAME:<filename>.");
			printf( "\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			printf( "\nError:  Filename is missing after option."
							"\n        Use the form -FILENAME:<filename>.");
			printf( "\n");
			exit(1);
		}

		strcpy(filename,opts);

		printf("\nUsing the filename %s.",filename);
	}

/**
*
*  Check for the -LABEL:dd option.
*
**/

	if ((opts = isargopt(argc,argv,"LABEL")) != NULL)
	{
		strupr(opts);

		if (*opts++ != ':')
		{
			printf(	"\nError:  Semicolon is missing after option."
							"\n        Use the form -LABEL:<label#>.");
			printf( "\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			printf(	"\nError:  The label number is missing after the option."
							"\n        Use the form -LABEL:<label#>.");
			printf( "\n");
			exit(1);
		}

		if (sscanf(opts,"%o",&label)!=1)
		{
			printf(	"\nError:  The label number is not an octal number."
							"\n        Use the form -LABEL:ooo.");
			printf( "\n");
			exit(1);
		}

		printf("\nUsing label %03o.",label);
	}

/**
*
*  Find the first ARINC 429 core with a transmit channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (BTI429_ChIsXmt(xmtchan,hCore))	break;

		if (xmtchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 429 transmit channels present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 429 core #%d",corenum);
	printf("\nUsing transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure xmtchan to transmit at low speed.
*
**/

	BTICard_CardReset(hCore);                          /*Reset the card*/

	errval = BTI429_ChConfig(CHCFG429_DEFAULT,xmtchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Create the asynchronous list buffer.
*
**/

	asynclistaddr = BTI429_ListAsyncCreate(LISTCRT429_FIFO,8192,xmtchan,hCore);

	if (!asynclistaddr)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the list buffer on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Next, a schedule is built by creating explicit message timing.
*  While creating a schedule we can still use the SchedGap() function
*  to create our gap times.  This function will determine that an
*  asynchronous list buffer has been created for the channel, and will
*  internally call the SchedGapList() function with appropriate parameters.
*  Alternatively, we could use the SchedGapList() function directly
*  and specify the address value ourselves. This method is useful if
*  more than one asynchronous list buffer is desired per channel.
*
**/

	BTI429_SchedGap(1024,xmtchan,hCore);						//This line, and
//	BTI429_SchedGapList(1024,asynclistaddr,xmtchan,hCore);		//this line, do the same thing.

/**
*
*  Start operation of the card.
*
**/

	BTICard_CardStart(hCore);

/**
*
*  Open the data file for reading.
*
**/

	fh = fopen(filename,"rb");

	if (fh==NULL)
	{
		printf("\nError:  Unable to open the data file %s.",filename);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Transmit data until EOF or until a key is hit.
*
**/

	printf("\nPress any key to exit....\n\n");

	while ((!kbhit()) && (fread(&Data,1,sizeof(Data),fh) != 0))
	{
		Data = (Data & 0xFFFFFF00L) | (label & 0x000000FFL);
		while(!BTI429_ListDataWr(Data,asynclistaddr,hCore));
	}

	printf("\nFinished loading data on to the card.");
	printf("\nCard may still be transmitting.");
	printf("\n");
	printf("\n");

/**
*
*  Close the data file.
*
**/

	fclose(fh);

/**
*
*  The card MUST be closed before exiting the program.
*
**/

	BTICard_CardClose(hCard);
}
