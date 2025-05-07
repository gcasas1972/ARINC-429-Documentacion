
#include "c11w32.h"
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

/**
*
*  CM1553-1 DRIVER EXAMPLE 9  Version 1.0  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP9.C -- Example 9 from Section 5.4.
*                      "Bus controller interrupts."
*
**/

/**
*
*  This program opens the CM1553-1 card in socket 0 and
*  configures it as a bus controller.  It creates a message
*  schedule with two messages and installs an interrupt
*  handler.  Message error interrupts are also enabled.
*
*  When either of the messages generates an error, the
*  interrupt handler is called.  The interrupt handler
*  examines the source of the error and increments a count
*  value.  Pressing the ESC key exits the program.
*
**/

typedef struct
{
	BOOL   fWindowsNT40;
	BOOL   aliveflag;					/*Set by thread, clear to kill thread*/
	BOOL   quitflag;					/*Cleared by thread, set when thread dies*/
	HCARD  handle;						/*Handle of CM1553-1 card*/
	ULONG  hits;						/*Counts the number of times interrupt hit*/
	ULONG  misses;						/*Counts the number of times event timed out*/
	INT    msg1;						/*Index of message #1*/
	INT    msg2;						/*Index of message #2*/
	INT    errors1;						/*Count of errors for message #1*/
	INT    errors2;						/*Count of errors for message #2*/
	HANDLE event;
	HANDLE thread;
} THREAD_MAILBOX,*LPTHREAD_MAILBOX;

/**
*
*  The following is the interrupt service thread.
*
**/

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	USHORT type;						/*Type of interrupt*/
	USHORT source;						/*Source of interrupt*/

	THREAD_MAILBOX *pmailbox = (LPTHREAD_MAILBOX)lpParam;

	while(pmailbox->aliveflag)
	{
		if (WaitForSingleObject(pmailbox->event,200) == WAIT_TIMEOUT)
		{
			pmailbox->misses++;
		}
		else
		{
			if (!(pmailbox->fWindowsNT40))
			{
				ResetEvent(pmailbox->event);
			}

			pmailbox->hits++;

			C11_INTRd(0,&type,&source,pmailbox->handle);	/*Read from interrupt log list*/

			if (type & INT_MERR)				/*If message error*/
			{
				if (source == pmailbox->msg1) ++pmailbox->errors1;	/*Increment error count depending*/
				if (source == pmailbox->msg2) ++pmailbox->errors2;	/*upon message that generated error*/
			}

			C11_INTReset(pmailbox->handle);					/*Clear pending interrupt*/
		}
	}

	pmailbox->quitflag=TRUE;

	return(0);
}

VOID main(VOID)
{
	USHORT command1 = 0x0820;
	USHORT command2 = 0x0C20;
	BOOL   fWindowsNT40;
	DWORD  j;
	THREAD_MAILBOX mailbox;
	HCARD  handle;
	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP9  Version 1.0  (04/09/1999)");
	fprintf(stderr,"\nCopyright 1997,1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Bus controller interrupts.\"");
	fprintf(stderr,"\n");

/**
*
*  Determine which OS we're running.  Interrupt handling is
*  slightly different between NT and 95.
*
**/

	OSInfo.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);

	if (GetVersionEx(&OSInfo))
	{
		fWindowsNT40 = ((VER_PLATFORM_WIN32_NT == OSInfo.dwPlatformId) &&
		                (OSInfo.dwMajorVersion <= 4));
	}
	else
	{
		printf("\nError:  Unable to determine the operating system");
		printf("\n        we are running on.");
		printf("\n");
		exit(1);
	}

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
*  Create an event object.
*
**/

	if (fWindowsNT40)
	{
		mailbox.event = OpenEvent(
			SYNCHRONIZE,				//Desired access
			FALSE,						//Inherit flag
			"CM1553Interrupt");			//Pointer to event-object name  

		if (mailbox.event == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
		}
	}
	else
	{
		mailbox.event = CreateEvent(
			NULL,
			TRUE,			//Flag for manual-reset event 
			FALSE,			//Flag for initial state 
			NULL);		 	//Pointer to event-object name  

		if (mailbox.event == NULL)
		{
			printf("\nError:  Event creation failed");
			printf("\n        GetLastError returned %d",GetLastError());
		}
	}

/**
*
*  Initialize mailbox.
*
**/

	mailbox.handle       = handle;
	mailbox.errors1      = 0;				/*Reset error count*/
	mailbox.errors2      = 0;				/*Reset error count*/
	mailbox.aliveflag    = TRUE;
	mailbox.quitflag     = FALSE;
	mailbox.hits         = 0;
	mailbox.misses       = 0;
	mailbox.fWindowsNT40 = fWindowsNT40;

/**
*
*  Create a thread.
*
**/

	mailbox.thread = CreateThread(
		NULL,					//Use the default security attributes  
		0x10000,				//Initial thread stack size
		InterruptServiceThread,	//Pointer to thread function 
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
*  Install interrupt handler and enable message error interrupt.
*
**/

	if (C11_INTInstall(mailbox.event,handle))
	{
		printf("\nError:  Error occurred installing the interrupt handler");
		printf("\n        GetLastError returned %d",GetLastError());
		exit(1);
	}

	C11_INTUnmask(INT_MERR,handle);

/**
*
*  Create frame with two messages.
*
**/

	C11_BCFrameStart(100,handle);
	mailbox.msg1 = C11_BCDoMsg(BUSA,command1,NULL,handle);
	mailbox.msg2 = C11_BCDoMsg(BUSA,command2,NULL,handle);
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
*  Until a key is pressed, displays the error count on the
*  screen.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		printf("\rerrors1=%04X errors2=%04X hits=%04X misses=%04X intlog=%04X",mailbox.errors1,mailbox.errors2,mailbox.hits,mailbox.misses,C11_GetIntLog(handle));
	}

/**
*
*  Stop the CM1553-1 card.
*
**/

	C11_Stop(handle);

/**
*
*  Uninstall the interrupt handler.
*
**/

	C11_INTUninstall(mailbox.event,handle);

/**
*
*  Kill thread and event objects.
*
**/

	fprintf(stderr,"\nKilling thread....");

	for (mailbox.aliveflag=FALSE,j=0xFFFFFF;j && !mailbox.quitflag;--j);

	CloseHandle(mailbox.thread);
	CloseHandle(mailbox.event);

/**
*
*  We are done, so we MUST close the CM1553-1 card using the
*  handle obtained from C11_OpenCard().
*
**/

	C11_CloseCard(handle);
}
