
/**
*
*  LP1553-3 and LC1553-3 DRIVER TEST
*  Copyright (c) 2000
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   TEST.C -- Test intermessage gap.
*
**/

/**
*
*  This test configures the LP1553-3 to spit out a receive command with
*  an associated response followed by a transmit command with an
*  associated response.  The gap between the two messages, the bus, and
*  some other parameters can be changed with various key presses.
*
**/

#include <l13w32.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <ctype.h>

#define TRUE 1
#define FALSE 0

USHORT gapval=0x1A0;		//Size of intermessage gap
INT    dwdcount=5;			//Number of data words
BOOL   busflag=FALSE;		//Bus A/B
USHORT serialbuf[256];		//Serial data
USHORT dwd[32];				//Data words
USHORT cwd1=0x0825;			//Receive command word
USHORT swd1=0x0800;			//Receive command's status word response
USHORT cwd2=0x0C25;			//Transmit command word
USHORT swd2=0x0800;			//Transmit command's status word response

void main(void)
{
	USHORT j;
	USHORT done;
	USHORT ch;
	ERRVAL errval;
	HCARD handleval;

	fprintf(stderr,"\nTEST  Version 1.0");
	fprintf(stderr,"\nCopyright 2000  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Test");
	fprintf(stderr,"\n\"Test the intermessage gap time\"");
	fprintf(stderr,"\n");

/**
*
*	Open card and display error if any.
*
**/

	handleval = L13_CardOpen(0);

	if (handleval<0)
	{
		fprintf(stderr,"\nError:  Unable to request handle for the card.");
		fprintf(stderr,"\n        (%s)",L13_ErrDescStr(handleval));
		fprintf(stderr,"\n");
		exit(1);
	}

/**
*
*	Reset the card
*
**/

	L13_CardReset(handleval);

/**
*
*	Enable the monitor.
*
**/

	errval = L13_MonConfig(MONCFG_DEFAULT,handleval);

	if (errval)
	{
		fprintf(stderr,"\nError:  Unable to configure monitor mode on the card.");
		fprintf(stderr,"\n        (%s)",L13_ErrDescStr(errval));
		fprintf(stderr,"\n");
		exit(1);
	}

/**
*
*	Enable the serial mode.
*
**/

	errval = L13_SerialConfig(SERCFG_CONTINUOUS,256,handleval);

	if (errval<0)
	{
		fprintf(stderr,"\nError:  Unable to configure serial mode on the card.");
		fprintf(stderr,"\n        (%s)",L13_ErrDescStr(errval));
		fprintf(stderr,"\n");
		exit(1);
	}

/**
*
*	Loop until ESC key hit.
*
**/

	printf("\n+/- to change intermessage gap");
	printf("\nU/D to change word count");
	printf("\nA/B to change bus");
	printf("\nESC to quit");
	printf("\n");

	for (done=FALSE;!done;)
	{

/**
*
*	Process keyboard presses.
*
**/

		if (kbhit())
		{
			ch = getch();

			switch(ch)
			{
				case 27:				//ESC key
					done=TRUE;
					break;

				case '+':
					++gapval;
					break;

				case '-':
					--gapval;
					break;

				case 'a':
				case 'A':
					busflag=FALSE;
					break;

				case 'b':
				case 'B':
					busflag=TRUE;
					break;

				case 'u':
				case 'U':
					++dwdcount;
					dwdcount &= 0xFF;
					break;

				case 'd':
				case 'D':
					--dwdcount;
					dwdcount &= 0xFF;
					break;
			}

			printf("\ngapval=%04X dwdcount=%04X bus=%s",gapval,dwdcount,(busflag) ? "B":"A");
		}

/**
*
*	When the serial buffer is empty, stop the card, load up the next
*	series of records, and restart the card.
*
**/

		if (STAT_EMPTY == L13_SerialStatus(handleval))
		{
			//Stop the card

			L13_CardStop(handleval);

			//Load the receive command

			serialbuf[0] = cwd1;						//Low half of encoder value
			serialbuf[1] = 0x0000;						//High half of encoder value
			serialbuf[2] = 0x0501;						//Encoder config value
			serialbuf[3] = 0x0000;						//Encoder gap value
			serialbuf[4] = 0x0000;						//Encoder error value
			serialbuf[5] = 0x0096 | ((busflag) ? 1:0);	//Encoder control value
			serialbuf[6] = 0x0000;
			serialbuf[7] = 0x0000;
			L13_SerialWr(serialbuf,handleval);

			//Load the data words

			for (j=0;j<dwdcount;++j)
			{
				serialbuf[0] = dwd[j];						//Low half of encoder value
				serialbuf[1] = 0x0000;						//High half of encoder value
				serialbuf[2] = 0x0501;						//Encoder config value
				serialbuf[3] = 0x0000;						//Encoder gap value
				serialbuf[4] = 0x0000;						//Encoder error value
				serialbuf[5] = 0x0016 | ((busflag) ? 1:0);	//Encoder control value
				serialbuf[6] = 0x0000;
				serialbuf[7] = 0x0000;
				L13_SerialWr(serialbuf,handleval);
			}

			//Load the status word response

			serialbuf[0] = swd1;						//Low half of encoder value
			serialbuf[1] = 0x0000;						//High half of encoder value
			serialbuf[2] = 0x0501;						//Encoder config value
			serialbuf[3] = 80;							//Encoder gap value
			serialbuf[4] = 0x0000;						//Encoder error value
			serialbuf[5] = 0x00B6 | ((busflag) ? 1:0);	//Encoder control value
			serialbuf[6] = 0x0000;
			serialbuf[7] = 0x0000;
			L13_SerialWr(serialbuf,handleval);

			//Load the transmit command

			serialbuf[0] = cwd2;						//Low half of encoder value
			serialbuf[1] = 0x0000;						//High half of encoder value
			serialbuf[2] = 0x0501;						//Encoder config value
			serialbuf[3] = gapval;						//Encoder gap value
			serialbuf[4] = 0x0000;						//Encoder error value
			serialbuf[5] = 0x00B6 | ((busflag) ? 1:0);	//Encoder control value
			serialbuf[6] = 0x0000;
			serialbuf[7] = 0x0000;
			L13_SerialWr(serialbuf,handleval);

			//Load the status word response

			serialbuf[0] = swd2;						//Low half of encoder value
			serialbuf[1] = 0x0000;						//High half of encoder value
			serialbuf[2] = 0x0501;						//Encoder config value
			serialbuf[3] = 80;							//Encoder gap value
			serialbuf[4] = 0x0000;						//Encoder error value
			serialbuf[5] = 0x00B6 | ((busflag) ? 1:0);	//Encoder control value
			serialbuf[6] = 0x0000;
			serialbuf[7] = 0x0000;
			L13_SerialWr(serialbuf,handleval);

			//Load the data word response

			for (j=0;j<dwdcount;++j)
			{
				serialbuf[0] = dwd[j];						//Low half of encoder value
				serialbuf[1] = 0x0000;						//High half of encoder value
				serialbuf[2] = 0x0501;						//Encoder config value
				serialbuf[3] = 0x0000;						//Encoder gap value
				serialbuf[4] = 0x0000;						//Encoder error value
				serialbuf[5] = 0x0016 | ((busflag) ? 1:0);	//Encoder control value
				serialbuf[6] = 0x0000;
				serialbuf[7] = 0x0000;
				L13_SerialWr(serialbuf,handleval);
			}

			//Start the card

			L13_CardStart(handleval);
		}
	}

/**
*
*	Close the card.
*
**/

	errval = L13_CardClose(handleval);

	if (errval)
	{
		fprintf(stderr,"\nError:  Unable to release handle for the card.");
		fprintf(stderr,"\n        (%s)",L13_ErrDescStr(errval));
		fprintf(stderr,"\n");
		exit(1);
	}
}
