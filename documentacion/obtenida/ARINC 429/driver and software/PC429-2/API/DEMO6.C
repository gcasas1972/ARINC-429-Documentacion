
#include <stdio.h>
#include "p42w32.h"

/**
*
*   PC429-1/2 SEQUENTIAL RECORD SAMPLE PROGRAM  Version 1.0  (03/31/1999)
*   Copyright (c) 1999
*   Ballard Technology, Inc.
*   www.ballardtech.com
*   support@ballardtech.com
*   ALL RIGHTS RESERVED
*
*   NAME:   DEMO6.C -- Sequential Record Sample Program.
*
**/

/**
*
*   This file is the source code for a sample program that
*   demonstrates the sequential record features of the
*   PC429-1/2 card.
*
*   To compile this program with the Microsoft C++ compiler,
*   use the following command line:
*
*   CL DEMO6.C P42W32.LIB
*
*   To compile this program with the Borland C++ compiler, use
*   the following command line:
*
*   BCC32 DEMO6.C P42W32.LIB
*
**/

VOID main(VOID)
{
	HCARD handleval;
	ERRVAL errval;
	INT j;
	USHORT channel;
	USHORT activeflag = 0;
	USHORT xmitwrap   = 0;
	USHORT rcvwrap    = 0;
	ULONG count;
	ULONG buf[0xFFFF];
	FILE* fhdat;
	FILE* fhtxt;

	fprintf(stderr,"\nDEMO6  Version 1.0  (03/31/1999)");
	fprintf(stderr,"\nCopyright 1996-1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");

/**
*
*   The following statement checks for the presence of a
*   PC429 card.
*
**/

	handleval = PC429_Check(0xCE00,0x250,2,1);

	if (handleval<0)					/*Check for card*/
	{
		printf("\nNo PC429 card at segment CE00H and port 250H (%i).",handleval);
		exit(1);
	}

/**
*
*   Create a file to write the sequential monitor data to.
*
**/

	fhdat = fopen("DEMO6.DAT","wb");

	if (NULL==fhdat)
	{
		printf("\nUnable to open the output file DEMO6.DAT for writing.");
		exit(1);
	}

/**
*
*   The following statements clears the card of messages and
*   filters.
*
**/

	PC429_Reset(handleval);							//Reset card
	PC429_SpeedClk(SPEED_CLKHIGH,handleval);		//Set timetag resolution
	PC429_ClrMsgFilt(handleval);					//Clear msgs and filt
	PC429_WrClk(0,handleval);

/**
*
*   We loop through all of the channels of the card.  We'll
*   enable self-test on all all receive channels and the
*   first transmit channel.  All transmit channels get a
*   single message scheduled.
*
**/

	for (channel=0;channel<8;++channel)					//Loop for each channel
	{
		if (PC429_IsXmit(1<<channel,handleval))			//If transmit channel
		{
			PC429_InsMsg(0,0,40,1<<channel,handleval);	//Insert message

			activeflag |= 1<<channel;					//Mark channel as active

			if (!xmitwrap)								//If using internal wrap
			{
				xmitwrap |= 1<<channel;					//Mark channel to use internal wrap
			}
		}

		if (PC429_IsRcv(1<<channel,handleval))			//If receive channel
		{
			activeflag |= 1<<channel;					//Mark channel as active

			if (!rcvwrap)								//If using internal wrap
			{
				rcvwrap |= 1<<channel;					//Mark channel to use internal wrap
			}
		}
	}

/**
*
*   The following statements configure the PC429 card.
*
**/

	PC429_Active(activeflag,handleval);				//All channels active
	PC429_SelfTest(xmitwrap | rcvwrap,handleval);	//Set wrap-around self-test
	PC429_HighSpeed(CHNONE,handleval);				//All channels low speed

/**
*
*   Configure the sequential record.
*
**/

	PC429_SeqRecParam(activeflag,SEQREC_MODE_MON,1,handleval);

/**
*
*   The following starts the operation of the card.
*
**/

	PC429_Start(handleval);						//Start image

/**
*
*   The following wait for a key to be pressed.
*
**/

	printf("\nPress any key to exit....");

	for (j=0;;++j)
	{
		if (!(j%0x20000))
		{
			if (kbhit()) break;			//Until key pressed
		}

		count = PC429_SeqRecRd(buf,sizeof(buf)/sizeof(buf[0]),handleval);

		if (count)		//Number of ULONGs written to the buffer
		{
			fwrite(buf,sizeof(buf[0]),count,fhdat);
		}
	}

/**
*
*   The following statement stops the card.
*
**/

	PC429_Stop(handleval);						//Stop image

/**
*
*   Close the output file.
*
**/

	fclose(fhdat);

/**
*
*   Open the file we just created.
*
**/

	fhdat = fopen("DEMO6.DAT","rb");

	if (NULL==fhdat)
	{
		printf("\nUnable to open the output file DEMO6.DAT for reading.");
		exit(1);
	}

/**
*
*   Read each 2 ULONG record and display the values.
*
**/

	while(fread(buf,sizeof(buf[0]),2,fhdat))
	{
		printf("\nmsg=%08lX ch=%u time=%06lX",
			buf[0],
			(buf[1]>>26) &7,
			(buf[1]>> 0) & 0xFFFFFF);
	}

/**
*
*   Close the file.
*
**/

	fclose(fhdat);
}
