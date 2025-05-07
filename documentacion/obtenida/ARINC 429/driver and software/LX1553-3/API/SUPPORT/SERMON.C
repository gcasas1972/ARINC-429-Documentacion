
/**
*
*  LP1553-3 and LC1553-3 SERIAL MONITOR EXAMPLE  Version 1.0  (06/30/2000)
*  Copyright (c) 2000
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   SERMON.C -- "Monitoring the bus using serial mode"
*
**/

/**
*
*  This example configures the L13 as a "serial" monitor.  It
*  watches for every word received on the MIL-STD-1553 bus
*  and displays all of the relevant information about the
*  word.  No analysis of the protocol is provided.
*
*  Note that in serial mode, much more information is
*  generated than in monitor mode.  This program may not keep
*  up with a fully-loaded bus.
*
**/

/**
*
*  When running the L13 in serial mode, the behavior of the
*  monitor is modified.  Instead of recording MIL-STD-1553
*  message transactions, it instead monitors individual
*  words, much like a serial port monitor.  In this mode, the
*  monitor record returned by MonRd() always contains 22 16-bit
*  words, but only words 0, 18, 19, 20, and 21 are valid. 
*  Word 0 contains the same information as in monitor mode. 
*  The other words contain fields that describe the
*  attributes of each MIL-STD-1553 word received by the L13.
*
*  Description of the fields printed out by this program:
*
*  CNT=00000000
*    Counts the number of records read by MonRd().  This is
*    just a local variable maintained by the software for
*    informational purposes.
*
*  RECSIZ - Record Size (word 0, low byte)
*    Number of 16-bit words contained in the monitor record.
*
*  VER - Version (word 0, high byte)
*    Version number of the monitor record.  For future use.
*
*  WORD - Word Value (word 18, 16 bits)
*    Value of the MIL-STD-1553 word received.  This value
*    does not include the sync and parity bits.
*
*  WR - Word Received (word 19, bit 15)
*    Set if a word was received.  Should always be set.
*
*  CWR - Command Word Received (word 19, bit 14)
*    Set if the word received has a command sync.  Clear if
*    the word received has a data sync.
*
*  OV - Overflow (word 19, bit 13)
*    Set if an overflow condition occurred.  Should always be
*    clear.
*
*  VWT - Valid Word Time (word 19, bit 12)
*    Set if the decoder reached the valid word time.  For
*    internal use only.
*
*  VWS - Valid Word Status (word 19, bit 11)
*    Set if a valid contiguous word was received.  For
*    internal use only.
*
*  GTO - Gap Timeout (word 19, bit 10)
*    Set if a gap timeout was encountered.  Indicates that
*    the gap preceeding the word was larger than the default
*    gap timeout value, which is probably set to 14us.  This
*    bit is only valid after at least one word is received.
*
*  UFE - Underflow Error (word 19, bit 0)
*    Set if an underflow error occurred in the encoder.  For
*    internal use only.
*
*  GAP - Gap (word 20, bit 15)
*    Set to indicate a gap preceeds the word received.  This
*    bit is only valid after at least one word was received.
*
*  SYNC - Sync (word 20, bit 14)
*    Set if the word received has a command sync.  Clear if
*    the word received has a data sync.
*
*  PAR - Parity (word 20, bit 13)
*    Set to the value of the parity bit of the word received.
*
*  ERR - Error (word 20, bit 11)
*    Set if any of the fields MAN, PER, or IE are set.
*
*  MAN - Manchester Error (word 20, bit 10)
*    Set if the word received contains a manchester error.
*
*  PER - Parity Error (word 20, bit 9)
*    Set if the word received contains a parity error.
*
*  IE - Incomplete Word Error (word 20, bit 8)
*    Set if the word received is incomplete.
*
*  GAPT - Gap Time (word 21, low 10 bits)
*    The size of the gap preceeding the word received.  To
*    calculate the gap in microseconds measured from the
*    trailing edge of the parity bit to the leading edge of
*    the sync, subtract 50 from the gap time and divide by
*    10.  To calculate the gap in microseconds measured from
*    the zero-crossing of the parity to the zero-crossing of
*    the sync, subtract 30 and divide by 10.
*
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of L13 card*/

void main(void)
{
	HCARD  handleval;
	ERRVAL errval;
	USHORT monbuf[256];
	INT j;
	ULONG count=0;
	float gapt;

	fprintf(stderr,"\nSERIAL MODE EXAMPLE  Version 1.0  (06/30/2000)");
	fprintf(stderr,"\nCopyright 2000  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Serial Example");
	fprintf(stderr,"\n\"Monitoring the bus using serial mode\"");
	fprintf(stderr,"\n");

/**
*
*  Open the L13 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	handleval = L13_CardOpen(CARDNUM);					/*Open the L13 card*/

	if (handleval < 0)
	{
		printf("\nError:  Either L13 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",handleval);
		printf("\n");
		exit(1);
	}

/**
*
*  Reset the card.
*
**/

	L13_CardReset(handleval);

/**
*
*  Configure the card for monitor mode.
*
**/

	errval = L13_MonConfig(MONCFG_DEFAULT,handleval);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for monitor mode.",errval);
		L13_CardClose(handleval);
		exit(1);
	}

/**
*
*  Configure the card for serial mode.  Serial mode must be
*  enabled after monitor mode.  The count parameter is as
*  small as possible because we will not be transmitting any
*  serial words.
*
**/

	errval = L13_SerialConfig(SERCFG_CONTINUOUS,1,handleval);

	if (errval)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for serial mode.",errval);
		L13_CardClose(handleval);
		exit(1);
	}

/**
*
*  Start the card to begin receiving messages.
*
**/

	L13_CardStart(handleval);

/**
*
*  Wait until key is hit.
*
**/

	printf("Press any key to quit program...\n");

	while(!kbhit())
	{
		if (L13_MonRd(monbuf,handleval))
		{
			printf("\n");

			printf("CNT=%08lX ",count++);

			printf("RECSIZ=%02u ",(monbuf[0]>>0) & 0xFF);
			printf("VER=%01u ",   (monbuf[0]>>8) & 0xFF);

			printf("WORD=%04XH ",monbuf[18]);

			printf("WR=%1u ",  (monbuf[19] >> 15) & 1);
			printf("CWR=%1u ", (monbuf[19] >> 14) & 1);
			printf("OV=%1u ",  (monbuf[19] >> 13) & 1);
			printf("VWT=%1u ", (monbuf[19] >> 12) & 1);
			printf("VWS=%1u ", (monbuf[19] >> 11) & 1);
			printf("GTO=%1u ", (monbuf[19] >> 10) & 1);
			printf("UFE=%1u ", (monbuf[19] >>  0) & 1);

			printf("GAP=%1u ", (monbuf[20] >> 15) & 1);
			printf("SYNC=%1u ",(monbuf[20] >> 14) & 1);
			printf("PAR=%1u ", (monbuf[20] >> 13) & 1);
			printf("ERR=%1u ", (monbuf[20] >> 11) & 1);
			printf("MAN=%1u ", (monbuf[20] >> 10) & 1);
			printf("PER=%1u ", (monbuf[20] >>  9) & 1);
			printf("IE=%1u ",  (monbuf[20] >>  8) & 1);

			gapt = monbuf[21] & 0x3FF;
			gapt = gapt - 50;
			gapt = gapt / 10.0;

			printf("GAPT=%fus (trailing parity to leading sync) ",gapt);

			gapt = monbuf[21] & 0x3FF;
			gapt = gapt - 30;
			gapt = gapt / 10.0;

			printf("GAPT=%fus (zerox parity to zerox sync) ",gapt);
		}
	}

/**
*
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardStop(handleval);
	L13_CardClose(handleval);
}
