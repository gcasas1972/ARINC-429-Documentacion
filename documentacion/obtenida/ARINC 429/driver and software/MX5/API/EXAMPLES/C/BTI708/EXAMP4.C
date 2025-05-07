
/**
*
*  BTI708 DRIVER EXAMPLE 4  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4.C -- Record to file example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first compatible core to configure the first receive
*  channel to record it's data to the Sequential Monitor.
*  The program then writes the data to a file (EXAMP4.DAT).
*
*  An Event Log frequency of 0 is specified, which will
*  not generate any Event Log List entries for these channels.
*
*  The program will continue to record data to the file
*  until a key is pressed.
*
*  Note: Running this program for a long time could cause the file
*  being written to become very large.  Please be cautious while
*  running this example.
*
**/

#include "BTICard.H"
#include "BTI708.H"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

char filename[256] = "EXAMP4.DAT";

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
	HCARD  hCard;
	HCORE  hCore;
	ERRVAL errval;
	INT    corenum;
	INT    rcvchan;
	FILE   *fh;
	char   *opts;
	INT    cursor = 1;

	USHORT seqbuf[2048];
	ULONG seqcount;
	ULONG blkcnt;
	LPSEQRECORD708 pRec708;
	SEQFINDINFO sfinfo;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP4  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI708 Example 4                                                  *");
	printf("\n    *  \"Record to file example.\"                                         *");
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
		printf("\nUsage:  EXAMP4 [options]");
		printf("\n");

		printf("\n-?                    Display help information");
		printf("\n-FILENAME:<filename>  File to write data to.  Default EXAMP4.DAT.");
		printf("\n");
		exit(0);
	}

	printf("\nFor help:  EXAMP4 ?");
	printf("\n");

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
			printf("\nError:  Semicolon is missing after option."
							"\n        Use the form -FILENAME:<filename>.");
			printf( "\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			printf("\nError:  Filename is missing after option."
							"\n        Use the form -FILENAME:<filename>.");
			printf("\n");
			exit(1);
		}

		strcpy(filename,opts);

		printf("\nUsing the filename %s.",filename);
	}

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

/**
*
*  Find the first ARINC 708 core with a receive channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)	if (BTI708_ChIsRcv(rcvchan,hCore)) break;

		if (rcvchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || rcvchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 708 receive channels present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 708 core #%d",corenum);
	printf("\nUsing receive channel #%d",rcvchan);
	printf("\n");

/**
*
*  Configure receive channel.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI708_ChConfig(CHCFG708_SEQALL,rcvchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Build the receive channel messages.
*
**/

	errval = BTI708_RcvBuild(MSGCRT708_DEFAULT,0,1,rcvchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while building",errval);
		printf("\n        channel #%d on core #.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
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
		printf("\n        the sequential monitor on core #.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Open the data file for writing.
*
**/

	fh = fopen(filename,"wb");

	if (fh==NULL)
	{
		printf("\nError:  Unable to open the data file %s.",filename);
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

	printf("\nPress any key to exit...");
	printf("\n");
	printf("\nWriting...  ");

	while (!kbhit())
	{
		seqcount = BTICard_SeqBlkRd(seqbuf,sizeof(seqbuf)/sizeof(seqbuf[0]),&blkcnt,hCore);

		BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

		while(!BTICard_SeqFindNext708(&pRec708,&sfinfo))
		{
			if      (cursor==1) printf("\b|");
			else if (cursor==2) printf("\b/");
			else if (cursor==3) printf("\b-");
			else
			{
				printf("\b\\");
				cursor = 0;
			}
			cursor++;

			fwrite(pRec708->data,1,sizeof(pRec708->data),fh);
		}
	}

	printf("\bDone.\n\n");

/**
*
*  Close the data file.
*
**/

	fclose(fh);

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
