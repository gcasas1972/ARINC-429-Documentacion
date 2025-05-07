
/**
*
*  LP1553-3 and LC1553-3 DRIVER EXAMPLE  Version 1.0  (02/12/2002)
*  Copyright (c) 2002
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   SCHOPTZ.C -- Schedule optimizer
*
**/

/**
*
*
*  This example configures the L13 as a bus controller and
*  schedules 3 messages to transmit a different rates using
*  the L13_SchedBuild() function.
*
*  It then calls the special function L13_SchedOptimize() on
*  one of the messages.  This function moves the message into
*  a "subroutine" schedule, and then goes back into the main
*  schedule and replaces each instance of the message in the
*  schedule to a call to the "subroutine".
*
*  To show it works, the example can toggle the skip bit of
*  the message in the "subroutine" to mask-out the message,
*  even if the message may be repeated several times in the
*  schedule.
*
**/

#include "l13w32.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define	CARDNUM 0					/*Card number of L13 card*/

#define CMD0 0x0821			/*Command word for first message*/
#define CMD1 0x0822			/*Command word for second message*/
#define CMD2 0x0823			/*Command word for third message*/

SCHNDX L13_SchedOptimize(MSGADDR msgaddr,HCARD handleval)
{
	ERRVAL errval;
	USHORT cmdblk[8];
	ULONG addrval;
	SCHNDX schndx;
	INT j;
	ULONG destaddr;
	
	//
	//	Verify message address
	//

	if (!msgaddr) return(ERR_BADMSG);

	//
	//	Create a 'subroutine' schedule after the 'main' schedule
	//

	errval = L13_BCSchedRestart(handleval);
	if (errval<0) return(errval);

	schndx = L13_BCSchedMsg(msgaddr,handleval);
	if (schndx<0) return(schndx);

	destaddr = L13_CmdAddr(schndx,handleval);
	if (!destaddr) return(ERR_UNKNOWN);

	errval = L13_BCSchedReturn(handleval);
	if (errval<0) return(errval);

	//
	//	Loop through schedule, but stop at the subroutine
	//

	for (j=0;j<schndx;++j)
	{
		addrval = L13_CmdAddr(j,handleval);				//Calc address of command block

		errval = L13_CmdRd(cmdblk,addrval,handleval);	//Read contents of command block

		if (0x01 == (cmdblk[0] & 0xFF))					//Is it a message block?
		{
			if (cmdblk[1]==L13_GetHigh(msgaddr) && cmdblk[2]==L13_GetLow(msgaddr))	//Does it point to our message?
			{
				L13_CmdInit(14,cmdblk);					//Turn into a CALL command block

				cmdblk[7] = L13_GetLow(destaddr);		//Call into 'subroutine'

				L13_CmdWr(cmdblk,addrval,handleval);	//Write modified command block
			}
		}
	}

	return(schndx);										//Return index of command
}

void main(void)
{
	HCARD   handleval;
	ERRVAL  errval;
	MSGADDR msgaddr[3];
	USHORT  freq[3] = {1500,500,250};
	SCHNDX  schndx;
	BOOL    done;
	INT     ch;
	BOOL    skip=0;

	fprintf(stderr,"\nSCHOPTZ  Version 1.0  (02/12/2002)");
	fprintf(stderr,"\nCopyright 2002  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP1553-3 and LC1553-3 Example");
	fprintf(stderr,"\n\"Schedule Optimizer\"");
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
*  Configure the card for bus controller mode.
*
**/

	L13_CardReset(handleval);							/*Reset the L13 card*/

	errval = L13_BCConfig(BCCFG_DEFAULT,handleval);		/*Configure the L13 card*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring for bus controller mode.",errval);
		L13_CardClose(handleval);
		exit(1);
	}

/**
*
*  Create the message records for each of the three messages.
*
**/

	msgaddr[0] = L13_BCCreateMsg(MSGCRT_DEFAULT,    CMD0, 0, NULL, handleval);
	msgaddr[1] = L13_BCCreateMsg(MSGCRT_DEFAULT,    CMD1, 0, NULL, handleval);
	msgaddr[2] = L13_BCCreateMsg(MSGCRT_DEFAULT,    CMD2, 0, NULL, handleval);

/**
*
*  Schedule the messages to create the desired bus controller
*  schedule.
*
**/

	errval = L13_BCSchedBuild(3,msgaddr,freq,handleval);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while scheduling messages.",errval);
		L13_CardClose(handleval);
		exit(1);
	}

/**
*
*  Optimize the fast message and save its index.
*
**/

	schndx = L13_SchedOptimize(msgaddr[0],handleval);

	if (schndx < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while optimizing schedule.",schndx);
		L13_CardClose(handleval);
		exit(1);
	}

/**
*
*  Start the card to begin transmissions.
*
**/

	L13_CardStart(handleval);

/**
*
*  Loop until a key is hit.
*
**/

	printf("\nPress SPACEBAR to toggle skip bit.");
	printf("\nPress ESC to exit.");
	printf("\n");

	for (done=0;!done;)
	{
		if (kbhit())
		{
			ch = getch();

			if (ch==27)
			{
				done=1;
			}

			if (ch==32)
			{
				skip = !skip;
				printf("\nTurning skip bit %s.",(skip) ? "on":"off");
				L13_CmdSkipWr(skip,schndx,handleval);
			}
		}
	}

/**
*
*  The L13 card MUST be closed before exiting the program.
*
**/

	L13_CardStop(handleval);					/*Stop the card*/
	L13_CardClose(handleval);					/*Close the card*/
}
