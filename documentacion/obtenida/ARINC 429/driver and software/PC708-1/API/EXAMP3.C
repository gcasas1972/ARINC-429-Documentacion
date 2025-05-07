
/**
*
*  PC708-1 DRIVER EXAMPLE 3  Version 1.2  (07/14/2000)
*  Copyright (c) 1998-2000
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*  
*  NAME:   EXAMP3.C -- Example 3.
*                      "Transmitter file loading example"
*
**/

/**
*
*  This example configures the PC708-1 to transmit a schedule
*  frames containing data from the file EXAMP3.DAT.
*
*  It does this by first configuring the card to transmit two
*  blocks of frames.  All frames in both blockes are
*  preloaded with data from the file and the card is started.
*
*  The program then begins to poll the interrupt log list on
*  the card.  If an interrupt is generated, the log entry is
*  read from the card.  The frame number that caused the
*  interrupt is extracted from the log entry and the
*  appropriate messages are updated.
*
*  If 2 blocks of 32 frames each are used, then frame 31 and
*  frame 63 will generate interrupts.  When the interrupt
*  from frame 31 is received, frames 0 through 31 are
*  updated.  When the interrupt from frame 63 is received,
*  frames 32 through 63 are updated.
*
*  Data from the data file are read until the end of the file
*  is reached.  Once reached, the program will seek to the
*  start of the file and transmit the file again.
*
*  The program continues in this manner until a key is
*  pressed.
*
*  Note: The program may not handle file lengths that are not
*  evenly divisable by 200.
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

USHORT framefreq  = 50;				/*Frame frequency of 50Hz*/
USHORT blocksize  = 32;				/*Generate an interrupt on every 32nd frame*/
USHORT framecount = 64;				/*Transmit a total of 64 frames*/

USHORT Data[100];					/*Data to transmit*/

HCARD Card;							/*Handle of card to access*/

char filename[256] = "EXAMP3.DAT";	/*Name of file containing data to transmit*/

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
	USHORT  framenum;
	ERRVAL  errval;
	USHORT  j;
	FILE *fh;						/*Handle of data file*/
	char *opts;						/*Pointer to command line options*/

	fprintf(stderr,"\nEXAMP3  Version 1.2  (07/14/2000)");
	fprintf(stderr,"\nCopyright 1998-2000  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nPC708-1 Example 3");
	fprintf(stderr,"\n\"Transmitter file loading example\"");
	fprintf(stderr,"\n");

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
		printf("\n-FREQ:dd              Set the frequency.  Default 50Hz.");
		printf("\n-BLOCKSIZE:dd         Set the block size.  Default 32 frames.");
		printf("\n-FILENAME:<filename>  File to read data from.  Default EXAMP3.DAT.");
		printf("\n-AUTO                 Loads two blocks of data from file, starts card,");
		printf("\n                      and exits the program, allowing the card to");
		printf("\n                      continuously transmit the data.");
		printf("\n");
		exit(0);
	}

	fprintf(stderr,"\nFor help:  EXAMP3 ?");
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
*  Check for the -BLOCKSIZE:dd option.
*
**/

	if ((opts = isargopt(argc,argv,"BLOCKSIZE")) != NULL)
	{
		strupr(opts);

		if (*opts++ != ':')
		{
			fprintf(stderr,	"\nError:  Semicolon is missing after option."
							"\n        Use the form -BLOCKSIZE:<blocksize>.");
			fprintf(stderr, "\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			fprintf(stderr,	"\nError:  The block size is missing after the option."
							"\n        Use the form -BLOCKSIZE:<blocksize>.");
			fprintf(stderr, "\n");
			exit(1);
		}

		if (sscanf(opts,"%u",&blocksize)!=1)
		{
			fprintf(stderr,	"\nError:  The block size is not a decimal number."
							"\n        Use the form -BLOCKSIZE:dd.");
			fprintf(stderr, "\n");
			exit(1);
		}

		framecount = blocksize * 2;

		fprintf(stderr,"\nUsing a block size of %u frames and a total of %u frames.",blocksize,framecount);
	}

/**
*
*  Check for the -FREQ:dd option.
*
**/

	if ((opts = isargopt(argc,argv,"FREQ")) != NULL)
	{
		strupr(opts);

		if (*opts++ != ':')
		{
			fprintf(stderr,	"\nError:  Semicolon is missing after option."
							"\n        Use the form -FREQ:<blocksize>.");
			fprintf(stderr, "\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			fprintf(stderr,	"\nError:  The frequency is missing after the option."
							"\n        Use the form -FREQ:<frequency>.");
			fprintf(stderr, "\n");
			exit(1);
		}

		if (sscanf(opts,"%u",&framefreq)!=1)
		{
			fprintf(stderr,	"\nError:  The frequency is not a decimal number."
							"\n        Use the form -FREQ:dd.");
			fprintf(stderr, "\n");
			exit(1);
		}

		fprintf(stderr,"\nUsing a frequency of %uHz.",framefreq);
	}

/**
*
*  Configure the transmitter of the PC708-1 card.
*
**/

	errval = PC708_XmtConfigEx(framefreq,blocksize,framecount,Card);	/*Configure the PC708-1 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring the transmitter.",errval);
		PC708_CardClose(Card);
		exit(1);
	}

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
		PC708_CardClose(Card);
		exit(1);
	}

/**
*
*  Preload two blocks of data from the file to the card.
*
**/

	for (j=0;j<framecount;++j)		/*Loop through each of the frames*/
	{
		if (fread(Data,1,sizeof(Data),fh) == 0)	/*If at end of file*/
		{
			printf("\nResetting data file %s",filename);
			fseek(fh,0,0);						/*Seek to beginning of file*/
			fread(Data,1,sizeof(Data),fh);
			PC708_XmtWr(Data,j,Card);			/*Write the data for frame*/
		}
		else
		{
			PC708_XmtWr(Data,j,Card);			/*Write the data for frame*/
		}
	}

/**
*
*  Start the card to begin transmissions.
*
**/

	PC708_CardStart(Card);

/**
*
*  Check for the -AUTO option.
*
**/

	if ((opts = isargopt(argc,argv,"AUTO")) != NULL)
	{
		fprintf(stderr,"\nExiting program.");
		fprintf(stderr,"\nCard is now transmitting static data.");

		fclose(fh);								/*Close the file*/
		PC708_CardClose(Card);					/*Close the card*/
		exit(0);
	}

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit.");
	printf("\n");
	
	while (!_kbhit())
	{
		while(PC708_IntStatus(Card) != STAT_EMPTY)			/*Check if the interrupt log list is not empty*/
		{
			PC708_IntRd(NULL,&framenum,Card);				/*Read an entry from the interrupt log list*/

			if (framenum==(framecount/2)-1)					/*If interrupt for first block of frames*/
			{
				for (j=0;j<framecount/2;++j)				/*Loop through the first block of frames*/
				{
					if (fread(Data,1,sizeof(Data),fh) == 0)	/*If at end of file*/
					{
						printf("\nResetting data file %s",filename);
						fseek(fh,0,0);						/*Seek to beginning of file*/
						fread(Data,1,sizeof(Data),fh);
						PC708_XmtWr(Data,j,Card);			/*Write the data for frame*/
					}
					else
					{
						PC708_XmtWr(Data,j,Card);				/*Write the data for frame*/
					}
				}

				printf("\nUpdated frames %u to %u.",0,(framecount/2)-1);
			}

			if (framenum==framecount-1)						/*If interrupt for second block of frames*/
			{
				for (j=framecount/2;j<framecount;++j)		/*Loop through the second block of frames*/
				{
					if (fread(Data,1,sizeof(Data),fh) == 0)	/*If at end of file*/
					{
						printf("\nResetting data file %s",filename);
						fseek(fh,0,0);						/*Seek to beginning of file*/
						fread(Data,1,sizeof(Data),fh);
						PC708_XmtWr(Data,j,Card);			/*Write the data for frame*/
					}
					else
					{
						PC708_XmtWr(Data,j,Card);				/*Write the data for frame*/
					}
				}

				printf("\nUpdated frames %u to %u.",(framecount/2)-0,framecount-1);
			}
		}
	}

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
