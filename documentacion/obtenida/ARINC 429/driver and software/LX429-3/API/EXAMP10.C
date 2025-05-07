
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 10  Version 1.0  (10/29/2001)
*  Copyright (c) 2000-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP10.C -- "Monitor to file example"
*
**/

/**
*
*  This program opens the L43 card number 0, creates a
*  default filter for all receive channels.  It also enables
*  the sequential monitor to record all received messages, and
*  then writes them to a file.
*
**/

#include "l43w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>

#define	CARDNUM 0                                 /*Card number of L43 card*/

char filename[256] = "EXAMP10.DAT";

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
	HCARD Card;                                 /*Handle of L43 card*/
	ERRVAL errval;                              /*Error return value*/
	FILE *fh;                                   /*Handle of data file*/
	char *opts;                                 /*Pointer to command line options*/

	MSGSTRUCT msgdefault[8];
	SEQRECORD seqbuf;
	INT j;
	INT cursor = 1;

	fprintf(stderr,"\nEXAMP10  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright (c) 2000-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 10");
	fprintf(stderr,"\n\"Monitor to file example.\"");
	fprintf(stderr,"\n");

/**
*
*  Check if we should display the help information.
*
**/

	if (isarghelp(argc,argv))
	{
		printf("\nUsage:  EXAMP10 [options]");
		printf("\n");

		printf("\n-?                    Display help information");
		printf("\n-FILENAME:<filename>  File to write data to.  Default EXAMP10.DAT.");
		printf("\n");
		exit(0);
	}

	fprintf(stderr,"\nFor help:  EXAMP10 ?");
	fprintf(stderr,"\n");

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
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);                   /*Open the L43 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L43 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

/**
*
*  Configure all receive channels for auto speed detection,
*  and to monitor all messages.
*
**/

	L43_CardReset(Card);                      /*Reset the L43 card*/

	for (j=0;j<8;++j)
	{
		if (L43_IsRcvChan(j,Card))
		{
			errval = L43_ChConfig(CHCFG_SEQALL | CHCFG_AUTOSPEED,j,Card);   /*Configure channel*/

			if (errval < 0)
			{
				fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,j);
				L43_CardClose(Card);
				exit(1);
			}
		}
	}

/**
*
*  Before any messages can be received, filters must be set
*  for the receive channels.  Since we want to record all data,
*  the default filter is used.
*
**/

	for (j=0;j<8;++j)
	{
		if (L43_IsRcvChan(j,Card));
		{
			msgdefault[j].addr = L43_FilterDefault(MSGCRT_DEFAULT,j,Card); 
		}
	}

/**
*
*  Configure the sequential record for continuous mode.
*
**/

	errval = L43_SeqConfig(SEQCFG_DPRAM,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the sequential record.",errval);
		L43_CardClose(Card);
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
		fprintf(stderr,"\nError:  Unable to open the data file %s.",filename);
		fprintf(stderr,"\n");
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Start operation of the card.
*
**/

	L43_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");
	printf("\nWriting...  ");
	
	while (!kbhit())
	{

/**
*
*  Display cursor
*
**/
		if(L43_SeqRd(&seqbuf,Card))
		{
			if (cursor==1) printf("\b|");
			else if (cursor==2) printf("\b/");
			else if (cursor==3) printf("\b-");
			else
			{
				printf("\b\\");
				cursor = 0;
			}
			cursor++;

			fwrite(&seqbuf,1,sizeof(seqbuf),fh);
		}
	}

	printf("\bDone.\n\n");

/**
*
*  Stop the L43 card.
*
**/

	L43_CardStop(Card);

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
