
/**
*
*  PC708-1 DRIVER EXAMPLE 6  Version 1.2  (07/14/2000)
*  Copyright (c) 1998-2000
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
*  This example configures the PC708-1 to receive messages.
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

#include "p71w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>

#define	MEMBASE 0xCC00				/*Memory address of PC708-1 card*/
#define IOBASE  0x2C0				/*I/O address of PC708-1 card*/
#define	IRQCHAN 2					/*Interrupt channel of PC708-1 card*/
#define	DMACHAN 1					/*DMA channel of PC708-1 card*/

USHORT Data[100];					/*Data to receive */

HCARD Card;							/*Handle of card to access*/

char filename[256] = "EXAMP6.DAT";	/*Name of file to record data */

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
	FILE *fh;						/*Handle of data file*/
	char *opts;						/*Pointer to command line options*/

	fprintf(stderr,"\nEXAMP6  Version 1.2  (07/14/2000)");
	fprintf(stderr,"\nCopyright 1998-2000  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC708-1 Example 6");
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
*  Open the PC708-1 card at the specified memory and I/O
*  address.  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = PC708_CardOpen(MEMBASE,IOBASE,IRQCHAN,DMACHAN);	/*Open the PC708-1 card*/

	if (Card < 0)
	{
		printf("\nError:  Either a PC708-1 is not present at memory %04XH, I/O %03XH,",MEMBASE,IOBASE);
		printf("\n        or an error occurred (%i) opening the card.",Card);
		printf("\n");
		exit(1);
	}

	PC708_CardReset(Card);

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
*  Configure the receiver of the PC708-1 card.
*
**/

	errval = PC708_RcvConfig(Card);			/*Configure the PC708-1 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the receiver.",errval);
		PC708_CardClose(Card);
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
		PC708_CardClose(Card);
		exit(1);
	}

/**
*
*  Start the card to begin receiving.
*
**/

	PC708_CardStart(Card);

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
*  it to the file.  The function PC708_RcvRd returns 
*  after updating the data buffer with the most current
*  data.
*
**/
		while(PC708_IntStatus(Card) != STAT_EMPTY)
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

			PC708_IntRd(NULL,NULL,Card);

			PC708_RcvRd(Data,Card);

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

	PC708_CardStop(Card);					/*Stop the card*/

/**
*
*  The PC708-1 card MUST be closed before exiting the program.
*
**/

	PC708_CardClose(Card);					/*Close the card*/
}
