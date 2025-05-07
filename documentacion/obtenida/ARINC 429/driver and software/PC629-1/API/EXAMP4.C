
#include <windows.h>
#include <stdio.h>
#include "p61w32.h"

/**
*
*   PC629-1 EXAMPLE 4 PROGRAM  Version 1.0  (07/05/2002)
*   Copyright (c) 1999-2002
*   Ballard Technology, Inc.
*   www.ballardtech.com
*   support@ballardtech.com
*   ALL RIGHTS RESERVED
*
*   NAME:   EXAMP4.C -- Monitor Example Program.
*
**/

/**
*
*   The program configures all RPP cells for every possible
*   12-bit label.  Interrupts are enabled for each cell, and
*   the label value is placed in the interrupt vector for
*   each cell.  It then enables interrupts from the card.
*
*   Whenever an interrupt occurs, the vector register is read
*   to retrieve the label value.  Finally, the label value is
*   displayed.
*
*   To compile this program with the Microsoft C++ compiler,
*   use the following command line:
*
*   CL EXAMP4.C P61W32.LIB
*
*   To compile this program with the Borland C++ compiler, use
*   the following command line:
*
*   BCC32 EXAMP4.C P61W32.LIB
*
**/

INT ti=50;			//Transmit interval value
INT tg=8;			//Terminal gap value
INT sg=0;			//Sync gap value

HCARD handleval;

const INT RPP_BASE = 0x8000;		//Base address of RPP
const INT CFG_BASE = 0xFFE0;		//Base address of configuration table

BOOL labellist[0x1000];				//Records labels that we detect

BOOL filterflag = TRUE;				//Set to filter out labels that have been detected

typedef struct                      //Variables used by the thread
{
	BOOL      fWindowsNT40;         //Flags whether we are running under Windows NT 4.0
	BOOL      fStayAlive;           //Flag indicating the thread should stay alive
	BOOL      fHasQuit;             //Flag indicating the thread has quit
	ULONG     Hits;                 //Counting variable
	ULONG     Misses;               //Counting variable
	USHORT    Vect;                 //Vector value read from DATAC
	HANDLE    hEvent;               //Handle of event
	HANDLE    hThread;              //Handle of event
} ThreadMailbox;

/**
*
*  This is the interrupt service thread.  When an interrupt
*  occurs, it read the vector register and displays the label
*  value.
*
**/

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	pMailbox->fStayAlive = TRUE;
	pMailbox->fHasQuit   = FALSE;
	pMailbox->Hits       = 0;
	pMailbox->Misses     = 0;

	while(pMailbox->fStayAlive)
	{
		if (WaitForSingleObject(pMailbox->hEvent,200) == WAIT_TIMEOUT)
		{
			pMailbox->Misses++;                //Increment counter
		}
		else
		{
			pMailbox->Vect = PC629_RegRdVect(handleval) & 0xFFF;

			if (!pMailbox->fWindowsNT40)      //Reset event if not Windows NT 4.0
			{                                 //to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			pMailbox->Hits++;                //Increment counter

			if (!filterflag || !labellist[pMailbox->Vect])
			{
				printf("Label=%03XH\n",pMailbox->Vect);
			}

			labellist[pMailbox->Vect] = TRUE;

			PC629_IntClr(handleval);
		}
	}

	pMailbox->fHasQuit = TRUE;                //Set flag indicating we have quit

	return(0);
}

VOID main(VOID)
{
	ERRVAL errval;
	INT ch;
	BOOL done;
	INT j;
	INT cid;
	INT label;
	BYTE value0;
	BYTE value1;
	BYTE rppcell[8];
	USHORT vect;
	USHORT addr;
	BOOL fWindowsNT40;
	ThreadMailbox Mailbox;
	DWORD ThreadId;
	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP4  Version 1.0  (07/05/2002)");
	fprintf(stderr,"\nCopyright 1999-2002  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nExample 4 - Monitor Example Program");
	fprintf(stderr,"\n");

/**
*
*  Determine which OS we're running.  Interrupt handling is
*  slightly different between NT and all others.
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
*   The following statement checks for the presence of a
*   PC629-1 card.
*
**/

	handleval = PC629_CardOpenEx(0);

	if (handleval<0)					//Check for card
	{
		printf("\nUnable to open PC629-1 card number %u (%i).",0,handleval);
		exit(1);
	}

/**
*
*	Reset the PC629-1 card.
*
**/

	PC629_Reset(handleval);

/**
*
*  Create an event object.  Under Windows NT, the event
*  object is created by the kernel driver and the application
*  opens it by name and passes the handle to the driver. 
*  Under all other Windows operating systems, the application
*  creates the event object and passes its handle to the
*  driver.
*
**/

	if (fWindowsNT40)
	{
		Mailbox.hEvent = OpenEvent(
			SYNCHRONIZE,                //Desired access
			FALSE,                      //Inherit flag
			"PC629Interrupt");          //Pointer to event-object name

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			PC629_CardClose(handleval);
			exit(1);
		}
	}
	else
	{
		Mailbox.hEvent = CreateEvent(
			NULL,
			TRUE,                       //Flag for manual-reset event 
			FALSE,                      //Flag for initial state 
			NULL);                      //Pointer to event-object name  

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			PC629_CardClose(handleval);
			exit(1);
		}
	}

/**
*
*  Install the interrupt handler for the card.
*
**/

	errval = PC629_IntInst(Mailbox.hEvent,OPT_NONE,handleval);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  Unable to install the interrupt handler.");
		fprintf(stderr,"\n");
		CloseHandle(Mailbox.hEvent);
		PC629_CardClose(handleval);
		exit(1);
	}

/**
*
*  Create a thread.
*
**/

	Mailbox.fWindowsNT40 = fWindowsNT40;

	Mailbox.fStayAlive = TRUE;
	Mailbox.fHasQuit   = FALSE;
	Mailbox.Hits       = 0;
	Mailbox.Misses     = 0;

	Mailbox.hThread = CreateThread(
		NULL,                   //Use the default security attributes  
		0x10000,                //Initial thread stack size
		InterruptServiceThread, //Pointer to thread function 
		(LPVOID)&Mailbox,       //Argument for new thread 
		0,                      //Creation flags 
		&ThreadId);             //Pointer to returned thread identifier 

	if (Mailbox.hThread == NULL)
	{
		printf("\nThread creation failed");
		printf("\nGetLastError = %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		PC629_CardClose(handleval);
		exit(1);
	}

/**
*
*	Fill the XPP & RPP of the PC629-1 with 1's.
*
**/

	PC629_PromFill(0xFF,handleval);

/**
*
*	Fill in RPP cells for labels 000H-FFBH.
*
**/

	for (label=0;label<=0xFFF;++label)
	{
		rppcell[0] = 0x00;							//RAM address
		rppcell[1] = 0x00;							//RAM address
		rppcell[2] = 0xDF;							//Enable LINT
		rppcell[3] = 0xFF;							//Ignore VWS
		rppcell[4] = 0x80 + ((label>>8) & 0x7F);	//Put label in vector
		rppcell[5] = 0x00 + ((label>>0) & 0xFF);	//Put label in vector
		rppcell[6] = 0xFF;							//Disable OP
		rppcell[7] = 0x00;							//Zero OVR

		PC629_PromWrS(rppcell,RPP_BASE+(label*8),8,handleval);
	}

/**
*
*	Fill in the RPP configuration table.
*
**/

	for (cid=0;cid<=0x0F;++cid)
	{
		value0 = ((sg<<6) & 0x80) + ((ti<<0) & 0x7F);
		value1 = ((sg<<7) & 0x80) + ((tg<<0) & 0x7F);

		PC629_PromWrB(CFG_BASE+(cid*2)+0,value0,handleval);
		PC629_PromWrB(CFG_BASE+(cid*2)+1,value1,handleval);
	}

/**
*
*   Apply TI,TG,SG to DATAC pins.
*
**/

	value0 = ((sg<<6) & 0x80) + ((ti<<0) & 0x7F);		//0x32
	value1 = ((sg<<7) & 0x80) + ((tg<<0) & 0x7F);		//0x08

	DRV629_RegWrTISG(value0,handleval);
	DRV629_RegWrTGSG(value1,handleval);

/**
*
*   Clear out our table of detected labels.
*
**/

	for (j=0;j<sizeof(labellist)/sizeof(labellist[0]);++j)
	{
		labellist[j] = FALSE;
	}

/**
*
*   Start the PC629-1 card.
*
**/

	PC629_Start(handleval);

/**
*
*	Display value of the register.
*
**/

	printf("\nPress 'Q' to quit....");
	printf("\n");
	printf("\n");

	for (j=0,done=0;!done;++j)
	{
		if (!(j%0x100000))
		{
			if (kbhit())
			{
				ch = getch();

				if (ch=='q' || ch=='Q')
				{
					done=1;
				}
			}
		}
	}

/**
*
*  Clear the flag keeping the thread alive and wait for the
*  thread to quit.
*
**/

	printf("\nWaiting for the thread to quit.");
	
	Mailbox.fStayAlive = FALSE;                     //Clear the fStayAlive flag so the thread commits suicide after the next interrupt

	WaitForSingleObject(Mailbox.hThread,5000);		//Waiting for thread to quit

/**
*
*   Stop the PC629-1 card.
*
**/

	PC629_Stop(handleval);

/**
*
*   Release the handle to the PC629-1 card.
*
**/

	PC629_CardClose(handleval);

/**
*
*   Release the WIN32 handles.
*
**/

	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);
}
