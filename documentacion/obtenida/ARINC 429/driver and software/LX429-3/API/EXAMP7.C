
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 7  Version 1.0  (10/29/2001)
*  Copyright (c) 1998-2001
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
*  This program opens the L43 card number 0, and
*  configures an asynchronous transmit list buffer.  The 
*  program reads a data file and transmits that data with
*  a user specified label.  If no data file or label is
*  specifed by the user the default values are examp7.dat,
*  and label 0172.
*  
**/

#include "l43w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>

#define	CARDNUM 0                               /*Card number of L43 card*/

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
	HCARD Card;                             /*Handle of L43 card*/
	ERRVAL errval;                          /*Error return value*/
	INT xmtchan;                            /*Channel number*/
	FILE *fh;                               /*Handle of data file*/
	char *opts;                             /*Pointer to command line options*/

	LISTADDR asynclistaddr;
	ULONG Data;

	fprintf(stderr,"\nEXAMP7  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1998-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 7");
	fprintf(stderr,"\n\"Program for file transfer.\"");
	fprintf(stderr,"\n");

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
		printf("\n-FILENAME:<filename>  File to read data from.  Default EXAMP7.DAT.");
		printf("\n");
		exit(0);
	}

	fprintf(stderr,"\nFor help:  EXAMP7 ?");
	fprintf(stderr,"\n");

/**
*
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);              /*Open the L43 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L43 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

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
			fprintf(stderr,	"\nError:  Semicolon is missing after option."
							"\n        Use the form -FILENAME:<filename>.");
			fprintf(stderr, "\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			fprintf(stderr, "\nError:  Filename is missing after option."
							"\n        Use the form -FILENAME:<filename>.");
			fprintf(stderr, "\n");
			exit(1);
		}

		strcpy(filename,opts);

		fprintf(stderr,"\nUsing the filename %s.",filename);
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
			fprintf(stderr,	"\nError:  Semicolon is missing after option."
							"\n        Use the form -LABEL:<label#>.");
			fprintf(stderr, "\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			fprintf(stderr,	"\nError:  The label number is missing after the option."
							"\n        Use the form -LABEL:<label#>.");
			fprintf(stderr, "\n");
			exit(1);
		}

		if (sscanf(opts,"%o",&label)!=1)
		{
			fprintf(stderr,	"\nError:  The label number is not an octal number."
							"\n        Use the form -LABEL:ooo.");
			fprintf(stderr, "\n");
			exit(1);
		}

		fprintf(stderr,"\nUsing label %03o.",label);
	}

/**
*
*  Find the first transmit channel.
*
**/

	for (xmtchan=0;xmtchan<8;++xmtchan) if (L43_IsXmtChan(xmtchan,Card)) break;
	if (xmtchan == 8)
	{
		printf("\nError:  No transmit channels present in L43 cardnum %d.",CARDNUM);
		printf("\n");
		exit(1);
	}

	fprintf(stderr,"\nUsing transmit channel %d",xmtchan);
	fprintf(stderr,"\n");

/**
*
*  Configure xmtchan to transmit at low speed.
*
**/

	L43_CardReset(Card);                          /*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG_DEFAULT,xmtchan,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,xmtchan);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Create the asynchronous list buffer.
*
**/

	asynclistaddr = L43_ListAsyncCreate(LISTCRT_FIFO,8192,xmtchan,Card);

	if (!asynclistaddr)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the list buffer.",errval);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Next, a schedule is built by creating explicit message timing.
*  While creating a schedule we can still use the SchedGap() funciton
*  to create our gap times.  This function will determine that an
*  asynchronous list buffer has been created for the channel, and will
*  internally call the SchedGapList() function with appropriate parameters.
*  Alternatively, we could use the SchedGapList() function directly 
*  and specify the address value ourselves. This method is usefull if 
*  more than one asynchronoous list buffer is desired per channel.
*
**/

	L43_SchedGap(1024,xmtchan,Card);					//This line, and
//	L43_SchedGapList(1024,asynclistaddr,xmtchan,Card);	//this line, do the same thing. 

/**
*
*  Start operation of the card.
*
**/

	L43_CardStart(Card);

/**
*
*  Open the data file for reading.
*
**/

	fh = fopen(filename,"rb");

	if (fh==NULL)
	{
		fprintf(stderr,"\nError:  Unable to open the data file %s.",filename);
		fprintf(stderr,"\n");
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Transmit data until EOF or until a key is hit.
*
**/

	fprintf(stderr,"\nPress any key to exit....\n\n");

	while ((!kbhit()) && (fread(&Data,1,sizeof(Data),fh) != 0))
	{
		Data = (Data & 0xFFFFFF00L) | (label & 0x000000FFL);
		while(!L43_ListDataWr(Data,asynclistaddr,Card));
	}

	fprintf(stderr,"\nFinished loading data on to the card.");
	fprintf(stderr,"\nCard may still be transmitting.");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n");

/**
*
*  Close the data file.
*
**/

	fclose(fh);

/**
*
*  The L43 card MUST be closed before exiting the program.
*
**/

	L43_CardClose(Card);

}
