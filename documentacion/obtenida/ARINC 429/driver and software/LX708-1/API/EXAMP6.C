
/**
*
*  LP708-1 and LC708-1 DRIVER EXAMPLE 6  Version 1.0  (01/19/2001)
*  Copyright (c) 1999-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP6.C -- Example 6.
*                      "Receiver file storing example"
*
**/

/**
*
*  This example configures the L71 to receive messages.
*  It then reads the most current data and writes it to a file
*  called EXAMP6.DAT.
*
*  The program continues in this manner until a key is
*  pressed.
*
*  Note: Running this program for a long time could cause the file
*  being written to become very large.  Please be cautious while
*  running this example.
*
**/

#include "l71w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>

#define	CARDNUM 0                   /*Card number of L71 card*/

USHORT Data[100];                   /*Data to transmit*/

HCARD Card;                         /*Handle of card to access*/

char filename[256] = "EXAMP6.DAT";  /*Name of file to record data*/

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
	ERRVAL  errval;
	int j = 1;
	FILE *fh;                       /*Handle of data file*/
	char *opts;                     /*Pointer to command line options*/

	fprintf(stderr,"\nEXAMP6  Version 1.0  (01/19/2001)");
	fprintf(stderr,"\nCopyright 1999-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP708-1 and LC708-1 Example 6");
	fprintf(stderr,"\n\"Receiver file storing example\"");
	fprintf(stderr,"\n");

/**
*
*  Check if we should display the help information.
*
**/

	if (isarghelp(argc,argv))
	{
		printf("\nUsage:  EXAMP6 [options]");
		printf("\n");

		printf("\n-?                    Display help information");
		printf("\n-FILENAME:<filename>  File to write data to.  Default EXAMP6.DAT.");
		printf("\n");
		exit(0);
	}

	fprintf(stderr,"\nFor help:  EXAMP6 ?");
	fprintf(stderr,"\n");

/**
*
*  Open the L71 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L71_CardOpen(CARDNUM);                     /*Open the L71 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L71 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

	L71_CardReset(Card);

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
*  Configure the receiver of the L71 card.
*
**/

	errval = L71_RcvConfig(Card);     /*Configure the L71 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the receiver.",errval);
		L71_CardClose(Card);
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
		L71_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin receiving.
*
**/

	L71_CardStart(Card);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");
	printf("\nWriting...  ");
	
	while (!_kbhit())
	{

/**
*
*  Poll the interrupt log list until it contains an entry. 
*  Then, read the interrupt log list to clear that entry.
*  Read the most current data out of the card and write
*  it to the file.  The function L71_RcvRd returns 
*  after updating the data buffer with the most current
*  data.
*
**/
		while(L71_IntStatus(Card) != STAT_EMPTY)
		{
			if (j==1) printf("\b|");
			else if (j==2) printf("\b/");
			else if (j==3) printf("\b-");
			else
			{
				printf("\b\\");
				j = 0;
			}
			j++;

			L71_IntRd(NULL,NULL,Card);

			L71_RcvRd(Data,Card);

			fwrite(Data,1,sizeof(Data),fh);
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
*  Stop the card to halt transmissions.
*
**/

	L71_CardStop(Card);

/**
*
*  The L71 card MUST be closed before exiting the program.
*
**/

	L71_CardClose(Card);
}
