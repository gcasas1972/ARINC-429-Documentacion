
/**
*
*  BTI708 DRIVER EXAMPLE 5  (06/09/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP5.C -- Transmitter file playback example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first compatible core to configure the first transmit
*  channel to transmit a sequence of 64 messages at a
*  rate of 200Hz.  The messages are automatically assigned
*  the numbers 0 through 63.
*
*  A data file is used to source the data to transmit
*  on the bus.
*
*  An Event Log frequency of 32 is specified, which will
*  cause the channel to issue an Event Log List entry
*  every 32nd message (message numbers 31, and 63).
*  The program uses these events to update he data for
*  the half of messages that were just transmitted.
*
*  Data from the data file are read until the end of the file
*  is reached.  Once reached, the program will seek to the
*  start of the file and transmit the file again.
*
*  The program continues in this manner until a key is
*  pressed.
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

USHORT framefreq   = 200;           /*Frame frequency of 200Hz*/
USHORT blocksize   = 32;            /*Generate an Event Log List entry on every 32nd frame*/
USHORT framecount  = 64;            /*Transmit a total of 64 frames*/

char filename[256] = "EXAMP5.DAT";  /*Name of file containing data to transmit*/

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
	INT    xmtchan;
	INT    j;
	USHORT Data[100];
	USHORT Type;
	ULONG  Info;
	USHORT framenum;
	FILE *fh;
	char *opts;

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP5  (06/09/2011)                                              *");
	printf("\n    *  Copyright 2001-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI708 Example 5                                                  *");
	printf("\n    *  \"Transmitter file playback example.\"                              *");
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
		printf("\nUsage:  EXAMP5 [options]");
		printf("\n");

		printf("\n-?                    Display help information");
		printf("\n-FREQ:dd              Set the frequency.  Default 200Hz.");
		printf("\n-BLOCKSIZE:dd         Set the block size.  Default 32 frames.");
		printf("\n-FILENAME:<filename>  File to read data from.  Default EXAMP5.DAT.");
		printf("\n-AUTO                 Loads two blocks of data from file, starts card,");
		printf("\n                      and exits the program, allowing the card to");
		printf("\n                      continuously transmit the data.");
		printf("\n");
		exit(0);
	}

	printf("\nFor help:  EXAMP5 ?");
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
			printf("\n");
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
*  Check for the -BLOCKSIZE:dd option.
*
**/

	if ((opts = isargopt(argc,argv,"BLOCKSIZE")) != NULL)
	{
		strupr(opts);

		if (*opts++ != ':')
		{
			printf("\nError:  Semicolon is missing after option."
							"\n        Use the form -BLOCKSIZE:<blocksize>.");
			printf("\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			printf("\nError:  The block size is missing after the option."
							"\n        Use the form -BLOCKSIZE:<blocksize>.");
			printf("\n");
			exit(1);
		}

		if (sscanf(opts,"%u",&blocksize)!=1)
		{
			printf("\nError:  The block size is not a decimal number."
							"\n        Use the form -BLOCKSIZE:dd.");
			printf("\n");
			exit(1);
		}

		framecount = blocksize * 2;

		printf("\nUsing a block size of %u frames and a total of %u frames.",blocksize,framecount);
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
			printf("\nError:  Semicolon is missing after option."
							"\n        Use the form -FREQ:<blocksize>.");
			printf("\n");
			exit(1);
		}

		if (!strlen(opts))
		{
			printf("\nError:  The frequency is missing after the option."
							"\n        Use the form -FREQ:<frequency>.");
			printf("\n");
			exit(1);
		}

		if (sscanf(opts,"%u",&framefreq)!=1)
		{
			printf("\nError:  The frequency is not a decimal number."
							"\n        Use the form -FREQ:dd.");
			printf("\n");
			exit(1);
		}

		printf("\nUsing a frequency of %uHz.",framefreq);
	}

/**
*
*  Find the first ARINC 708 core with a transmit channel.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		errval = BTICard_CoreOpen(&hCore,corenum,hCard);
		if (errval) break;

		for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	if (BTI708_ChIsXmt(xmtchan,hCore)) break;

		if (xmtchan != MAX_CHANNELS) break;
	}

	if (errval || corenum == MAX_CORES || xmtchan == MAX_CHANNELS)
	{
		printf("\nError:  No ARINC 708 transmit channels present in cardnum %d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\nUsing ARINC 708 core #%d",corenum);
	printf("\nUsing transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure transmit channel.
*
**/

	BTICard_CardReset(hCore);

	errval = BTI708_ChConfig(CHCFG708_DEFAULT,xmtchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Build the transmit channel messages.
*
**/

	errval = BTI708_XmtBuild(MSGCRT708_DEFAULT,framefreq,blocksize,framecount,xmtchan,hCore);

	if (errval)
	{
		printf("\nError:  An error was encountered (%i) while building",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
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
		printf("\nError:  Unable to open the data file %s.",filename);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Preload two blocks of data from the file to the card.
*
**/

	for (j=0;j<framecount;++j)						//Loop through each of the frames
	{
		if (fread(Data,1,sizeof(Data),fh) == 0)		//If at end of file
		{
			printf("\nResetting data file %s",filename);
			fseek(fh,0,0);							//Seek to beginning of file
			fread(Data,1,sizeof(Data),fh);
			BTI708_MsgDataWr(Data,j,xmtchan,hCore);	//Write the data for frame
		}
		else
		{
			BTI708_MsgDataWr(Data,j,xmtchan,hCore);	//Write the data for frame
		}
	}

/**
*
*  Configure the Event Log list.
*
**/

	errval = BTICard_EventLogConfig(LOGCFG_ENABLE,1024,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        the event log list on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
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
*  Check for the -AUTO option.
*
**/

	if ((opts = isargopt(argc,argv,"AUTO")) != NULL)
	{
		printf("\nExiting program.");
		printf("\nDevice is now transmitting static data.");

		fclose(fh);                             //Close the file
		BTICard_CardClose(hCard);               //Close the card
		exit(0);
	}

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress any key to exit...");
	printf("\n");

	while (!kbhit())
	{
		if (BTICard_EventLogRd(&Type,&Info,NULL,hCore))	//Read entry from Event Log list
		{
			framenum = (USHORT)Info;

			if (framenum == ((framecount/2)-1))			//First half transmitted
			{
				for (j=0;j<=framenum;j++)
				{
					if (fread(Data,1,sizeof(Data),fh) == 0)		//If at end of file
					{
						printf("\nResetting data file %s",filename);
						fseek(fh,0,0);							//Seek to beginning of file
						fread(Data,1,sizeof(Data),fh);
						BTI708_MsgDataWr(Data,j,xmtchan,hCore);	//Write the data for frame
					}
					else
					{
						BTI708_MsgDataWr(Data,j,xmtchan,hCore);	//Write the data for frame
					}
				}

				printf("\nUpdated frames %u to %u.",0,framenum);
			}
			else if (framenum == (framecount-1))		//Second half transmitted
			{
				for (j=(framecount/2);j<=framenum;j++)
				{
					if (fread(Data,1,sizeof(Data),fh) == 0)		//If at end of file
					{
						printf("\nResetting data file %s",filename);
						fseek(fh,0,0);							//Seek to beginning of file
						fread(Data,1,sizeof(Data),fh);
						BTI708_MsgDataWr(Data,j,xmtchan,hCore);	//Write the data for frame
					}
					else
					{
						BTI708_MsgDataWr(Data,j,xmtchan,hCore);	//Write the data for frame
					}
				}

				printf("\nUpdated frames %u to %u.",framecount/2,framenum);
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
