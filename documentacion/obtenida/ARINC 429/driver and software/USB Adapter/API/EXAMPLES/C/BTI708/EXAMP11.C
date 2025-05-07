
/**
*
*  BTI708 DRIVER EXAMPLE 11  (06/09/2011)
*  Copyright (c) 2003-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP11.C -- Variable Bit Length example
*
**/

/**
*
*  This program opens Card Number 0, and configures the
*  first transmit channel on the first 708 Core to transmit
*  a sequence of 32 messages at a rate of 200Hz. The messages
*  are automatically assigned the numbers 0 through 31.
*
*  The transmitted and received bit lengths are displayed on
*  the console.
*
*  The user can then control the bit length using the LEFT and
*  RIGHT arrow keys.
*
*  The program continues in this manner until a key is
*  pressed.
*
**/

#include "BTICard.H"
#include "BTI708.H"
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM		  0
#define	MAX_CORES     4
#define	MAX_CHANNELS  32

#define	FRAMEFREQ	  100          /*Frame frequency of 200Hz*/
#define LOGFREQ		  16           /*Generate a Log Event after every 16th message*/
#define	FRAMECOUNT	  32           /*Transmit a total of 32 messages*/

#define BIT_HIGH	  1856
#define BIT_LOW		  1

void main(void)
{
	HCARD  hCard;
	HCORE  hCore;
	ERRVAL errval;
	INT    corenum;
	INT    xmtchan;
	INT    rcvchan;
	BOOL   xmtfound;
	BOOL   rcvfound;
	INT    cfgflag;
	INT    j,jj;
	USHORT Data[116];
	USHORT bitlength = 1600;
	BOOL   done;
	char   ch;
	HANDLE hConsole;
	COORD  consolepos;

	USHORT seqbuf[2048];
	ULONG seqcount;
	ULONG blkcnt;
	LPSEQRECORD708 pRec708;
	SEQFINDINFO sfinfo;

/**
*
*  Create a display window.
*
**/

	system("cls");	/* Clear the console window. */

	hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

	consolepos.X =  0;
	consolepos.Y =  0;
	SetConsoleCursorPosition(hConsole,consolepos);

	FillConsoleOutputCharacter(hConsole,' ',2000,consolepos,&j);

	consolepos.X =  0;
	consolepos.Y =  0;
	SetConsoleCursorPosition(hConsole,consolepos);

	printf("\n    **********************************************************************");
	printf("\n    *                                                                    *");
	printf("\n    *  EXAMP11  (06/09/2011)                                             *");
	printf("\n    *  Copyright 2003-2011  Ballard Technology, Inc.  Everett, WA, USA.  *");
	printf("\n    *  All rights reserved.                                              *");
	printf("\n    *  Go to www.ballardtech.com or email support@ballardtech.com        *");
	printf("\n    *                                                                    *");
	printf("\n    *  BTI708 Example 11                                                 *");
	printf("\n    *  \"Program for variable bit length example.\"                        *");
	printf("\n    *                                                                    *");
	printf("\n    **********************************************************************");
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
*  Find the first ARINC 708 core with a receive and transmit channel that supports variable bit length.
*
**/

	for (corenum=0;corenum<MAX_CORES;corenum++)
	{
		rcvfound = 0;
		xmtfound = 0;

		errval = BTICard_CoreOpen(&hCore,corenum,hCard);	/* Open a handle to the core. */
		if (errval) break;

		for (rcvchan=0;rcvchan<MAX_CHANNELS;rcvchan++)		/* Search for receive channel. */
		{
			rcvfound = BTI708_ChIsRcv(rcvchan,hCore);
			if (rcvfound) break;
		}

		if (rcvfound)
		{
			for (xmtchan=0;xmtchan<MAX_CHANNELS;xmtchan++)	/* Search for transmit channel. */
			{
				xmtfound = (BTI708_ChIsXmt(xmtchan,hCore) && BTI708_ChGetInfo(INFO708_VARBIT,xmtchan,hCore));
				if (xmtfound) break;
			}
		}

		if (rcvfound && xmtfound)	break;
	}

	if (errval || (corenum == MAX_CORES) || !rcvfound || !xmtfound)
	{
		printf("\nError:  No compatible ARINC 708 core present in card #%d.",CARDNUM);
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

	printf("\n\tUsing ARINC 708 core #%d",corenum);
	printf("\n\tUsing receive channel #%d",rcvchan);
	printf("\n\tUsing variable bit length transmit channel #%d",xmtchan);
	printf("\n");

/**
*
*  Configure receive channel.
*
**/

	BTICard_CardReset(hCore);

	cfgflag = CHCFG708_DEFAULT | CHCFG708_SEQALL | CHCFG708_SELFTEST | CHCFG708_VARBIT;

	errval = BTI708_ChConfig(cfgflag,rcvchan,hCore);

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
		printf("\n        channel #%d on core #%d.",rcvchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		printf("\n");
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Configure xmtchan for variable bit length and self test
*
**/

	cfgflag = CHCFG708_DEFAULT /*| CHCFG708_SELFTEST*/ | CHCFG708_VARBIT;

	errval = BTI708_ChConfig(cfgflag,xmtchan,hCore);

	if (errval < 0)
	{
		printf("\nError:  An error was encountered (%i) while configuring",errval);
		printf("\n        channel #%d on core #%d.",xmtchan,corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
		BTICard_CardClose(hCard);
		exit(1);
	}

/**
*
*  Build the transmit channel messages.
*
**/

	errval = BTI708_XmtBuild(MSGCRT708_DEFAULT,FRAMEFREQ,LOGFREQ,FRAMECOUNT,xmtchan,hCore);

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
*  Create and write the data for the messages.
*
**/

	/* Initialize the data array */
	for (jj=0;jj<116;jj++) Data[jj] = jj;

	bitlength = (bitlength>BIT_HIGH) ? BIT_HIGH : bitlength;
	bitlength = (bitlength<BIT_LOW)  ? BIT_LOW  : bitlength;

	for (j=0;j<FRAMECOUNT;j++)					/*Loop through all the messages*/
	{
		/* Write the variable length data to the device */
		errval = BTI708_MsgVarDataWr(Data,bitlength,j,xmtchan,hCore);
		if (errval)
		{
			printf("\nError:  An error was encountered (%i) while writing variable",errval);
			printf("\n        bit length data on channel #%d on core #%d.",xmtchan,corenum);
			printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
			printf("\n");
			BTICard_CardClose(hCard);
			exit(1);
		}
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
		printf("\n        the sequential monitor on core #%d.",corenum);
		printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
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
*  Move to display window.
*
**/

	consolepos.X = 0;
	consolepos.Y = 16;
	SetConsoleCursorPosition(hConsole,consolepos);

/**
*
*  Change bitlength values when arrow keys are pressed. Exit when ESC is pressed.
*
**/

	printf("\n\tOPTIONS:");
	printf("\n\tARROW RIGHT = Add 1 to Transmit bit length");
	printf("\n\tARROW LEFT  = Subtract 1 from Transmit bit length");
	printf("\n\tESC         = Exit program");
	printf("\n\n");

	for (done=0;!done;)
	{
		seqcount = BTICard_SeqBlkRd(seqbuf,sizeof(seqbuf)/sizeof(seqbuf[0]),&blkcnt,hCore);

		BTICard_SeqFindInit(seqbuf,seqcount,&sfinfo);

		while(!BTICard_SeqFindNext708(&pRec708,&sfinfo))
		{
			printf("\tTime Stamp: %08lX\n",pRec708->timestamp);
			printf("\tActivity:   %04X\n", pRec708->activity);


			printf("\n\t(Tx) Bit Length: %4d",bitlength);
			printf("\n\t(Rx) Bit Length: %4d",pRec708->bitcount);

			consolepos.X =  0;
			consolepos.Y = 22;
			SetConsoleCursorPosition(hConsole,consolepos);
		}

		if (kbhit())
		{
			ch = _getch();

			if (ch==0xE0)	ch=_getch();	/* When reading arrow key _getch() must be called twice. */

			switch (ch)
			{
				case 27:	/* ESC */
				{
					done=1;
					break;
				}
				case 75:	/* LEFT  */
				case 77:	/* RIGHT */
				{
					if (ch==77)	bitlength = (bitlength+1>BIT_HIGH) ? BIT_HIGH : bitlength+1;
					else        bitlength = (bitlength-1<BIT_LOW)  ? BIT_LOW  : bitlength-1;

					for (j=0;j<FRAMECOUNT;j++)					/*Loop through all the messages*/
					{
						/* Write the variable length data to the device */
						errval = BTI708_MsgVarDataWr(Data,bitlength,j,xmtchan,hCore);
						if (errval)
						{
							printf("\nError:  An error was encountered (%i) while writing variable",errval);
							printf("\n        bit length data on channel #%d on core #%d.",xmtchan,corenum);
							printf("\n        (%s)",BTICard_ErrDescStr(errval,hCard));
							printf("\n");
							BTICard_CardClose(hCard);
							exit(1);
						}
					}

					break;
				}
			}
		}
	}

/**
*
*  Move to bottom of screen.
*
**/

	consolepos.X =  0;
	consolepos.Y = 32;
	SetConsoleCursorPosition(hConsole,consolepos);

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
