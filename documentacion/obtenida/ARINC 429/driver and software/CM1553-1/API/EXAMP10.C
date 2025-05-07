
#include "c11w32.h"
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM1553-1 DRIVER EXAMPLE 10  Version 1.0  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP10.C -- Example 10 from Section 5.4.
*                      "Bus controller polled interrupts."
*
**/

/**
*
*  This program opens the CM1553-1 card in socket 0 and
*  configures it as a bus controller.  It creates a message
*  schedule with one message and a message block that issues
*  a CBA interrupt from the Summit.
*
*  The program then spawns a worker thread that watches for
*  the interrupt from the Summit.  When the interrupt is
*  detected, it reads the entry from the Summit interrupt log
*  list, and then clears the interrupt from the Summit so it
*  can generate a new one.
*
**/

HCARD handle;							/*Handle of CM1553-1 card*/

typedef struct
{
	BOOL   aliveflag;					/*Set by thread, clear to kill thread*/
	BOOL   quitflag;					/*Cleared by thread, set when thread dies*/
	ULONG  hits;						/*Counts the number of times interrupt hit*/
	ULONG  misses;						/*Counts the number of times interrupt missed*/
	INT    msg;							/*Index of message*/
	HANDLE thread;
} THREAD_MAILBOX,*LPTHREAD_MAILBOX;

/**
*
*  The following is a worker thread that will do the actual polling.
*
**/

DWORD WINAPI WorkerThread(LPVOID lpParam)
{
	USHORT type;						/*Type of interrupt*/
	USHORT source;						/*Source of interrupt*/

	THREAD_MAILBOX *pmailbox = (LPTHREAD_MAILBOX)lpParam;

	while(pmailbox->aliveflag)
	{
		/**
		*
		*  Poll a CM1553-1 register to get state of interrupts from Summit.
		*
		**/

		if (C11_RdPort(REG_INT,handle) & 0xC0)	/*Look for MSGINT or YFINT*/
		{
			pmailbox->hits++;

			C11_INTRd(0,&type,&source,handle);	/*Read from interrupt log list*/

			if (type & INT_CBA)					/*If message error*/
			{
				printf("\nGot CBA interrupt!");
				printf("\n");
			}
			else
			{
				printf("\nGot some other interrupt!");
				printf("\n");
			}

			/**
			*
			*  The following clears the interrupt from the Summit
			*  to allow it to generate a new interrupt.
			*
			**/

			C11_PeekMem(SUMMIT_INTPEND,handle);		/*Read pending interrupt register*/
			C11_PeekMem(SUMMIT_INTMASK,handle);		/*Read mask register*/
		}
		else
		{
			pmailbox->misses++;
		}
	}

	pmailbox->quitflag=TRUE;

	return(0);
}

VOID main(VOID)
{
	USHORT command = 0x0820;
	DWORD  j;
	THREAD_MAILBOX mailbox;

	fprintf(stderr,"\nEXAMP10  Version 1.0  (04/09/1999)");
	fprintf(stderr,"\nCopyright 1997,1999 Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Bus controller polled interrupts.\"");
	fprintf(stderr,"\n");

/**
*
*  Open the CM1553-1 card in socket 0.  A handle to the card
*  is returned which is tested to determine if an error
*  occurred.
*
**/

	handle = C11_OpenCard(0);

	if (handle==NULL)
	{
		printf("\nError:  Either a CM1553-1 is not present in socket 0 or an");
		printf("\n        error occurred opening the card in socket 0.");
		printf("\n");
		exit(1);
	}

/**
*
*  Initialize mailbox.
*
**/

	mailbox.aliveflag = TRUE;
	mailbox.quitflag  = FALSE;
	mailbox.hits      = 0;
	mailbox.misses    = 0;

/**
*
*  Create a thread.
*
**/

	mailbox.thread = CreateThread(
		NULL,					//Use the default security attributes  
		0x10000,				//Initial thread stack size
		WorkerThread,			//Pointer to thread function 
		(LPVOID)&mailbox,		//Argument for new thread 
		0,						//Creation flags 
		&j);					//Pointer to returned thread identifier 

	if (mailbox.thread == NULL)
	{
		printf("\nError:  Thread creation failed");
		printf("\n        GetLastError = %d",GetLastError());
	}

/**
*
*  Configure the CM1553-1 card as a bus controller using the
*  default settings.
*
**/

	C11_BCConfig(CONFIG_DEFAULT,handle);

/**
*
*  Enable command block accessed interrupt.
*
**/

	C11_INTUnmask(INT_CBA,handle);		/*Unmask interrupt from Summit*/
	C11_WrPort(0x06,REG_INT,handle);	/*Enable MSGINT & YFINT, but disable them to host*/

/**
*
*  Create frame with two messages.
*
**/

	C11_BCFrameStart(1000,handle);
	mailbox.msg = C11_BCDoMsg(BUSA,command,NULL,handle);
	C11_BCDoInt(handle);
	C11_BCFrameEnd(handle);

/**
*
*  Activate the CM1553-1 card.  The card proceeds to transmit
*  the bus controller schedule.
*
**/

	C11_Start(handle);

/**
*
*  Until a key is pressed, displays the statistics on the
*  screen.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		printf("\rhits=%04X misses=%08lX intlog=%04X",mailbox.hits,mailbox.misses,C11_GetIntLog(handle));
	}

/**
*
*  Stop the CM1553-1 card.
*
**/

	C11_Stop(handle);

/**
*
*  Kill thread.
*
**/

	fprintf(stderr,"\nKilling thread....");

	for (mailbox.aliveflag=FALSE,j=0xFFFFFF;j && !mailbox.quitflag;--j);

	CloseHandle(mailbox.thread);

/**
*
*  We are done, so we MUST close the CM1553-1 card using the
*  handle obtained from C11_OpenCard().
*
**/

	C11_CloseCard(handle);
}
