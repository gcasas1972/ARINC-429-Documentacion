
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include "c41w32.h"

/**
*
*  CM429-1 DRIVER EXAMPLE 7  Version 1.0  (05/26/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP7.C -- Modified Example 4 from Section 4.4.
*                      "Example with explicit message timing"
*                      "and interrupts."
*
**/

/**
*
*  This program opens the CM429-1 card in socket 0, and
*  builds a transmit schedule using explicit message timing. 
*  The internal wrap-around is enabled and filters are set to
*  receive the messages.  The minimum and maximum elapsed
*  time for each message is displayed.
*
**/

#define	XMT_AIRSPEED  0		/*Message Record for transmitted Computed Airspeed*/
#define	XMT_ALTITUDE  1		/*Message Record for transmitted Altitude Rate*/
#define	RCV_AIRSPEED 10		/*Message Record for received Computed Airspeed*/
#define	RCV_ALTITUDE 11		/*Message Record for received Altitude Rate*/

USHORT AltitudeRecord[8];	/*Stores Message Record for Altitude Rate*/
USHORT AirSpeedRecord[8];	/*Stores Message Record for Computed Airspeed*/

typedef struct						/*Variables used by the thread*/
{
	BOOL    fWindowsNT40;			/*Flags whether we are running under Windows NT 4.0*/
	BOOL    fStayAlive;				/*Flag indicating the thread should stay alive*/
	BOOL    fHasQuit;				/*Flag indicating the thread has quit*/
	HCARD   handle;					/*Handle of CM429-1 card*/
	ULONG   Hits;					/*Counting variable*/
	ULONG   Misses;					/*Counting variable*/
	HANDLE  hEvent;					/*Handle of event*/
	HANDLE  hThread;				/*Handle of event*/
} ThreadMailbox;

/**
*
*  The following thread is spun off by the main application. 
*  It waits for the specified thread to be released when the
*  CM429-1 card generates an interrupt.  It then resets the
*  event to allow us to receive more events, reads an entry
*  from the interrupt log list, and waits for the next event.
*
**/

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	USHORT Type;
	USHORT Info;

	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	pMailbox->fStayAlive = TRUE;
	pMailbox->fHasQuit   = FALSE;
	pMailbox->Hits       = 0;

	while(pMailbox->fStayAlive)
	{
		if (WaitForSingleObject(pMailbox->hEvent,200) == WAIT_TIMEOUT)
		{
			pMailbox->Misses++;								//Increment counter
		}
		else
		{
			if (!pMailbox->fWindowsNT40)					//Reset event if not Windows NT 4.0
			{												//to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			pMailbox->Hits++;								//Increment counter

			C41_IntRd(&Type,&Info,pMailbox->handle);		//Read entry from interrupt log list

			C41_PortWr(0x00,REG_INTC,pMailbox->handle);		//Clear interrupt
		}
	}

	pMailbox->fHasQuit = TRUE;								//Set flag indicating we have quit

	return(0);
}

void main(void)
{
	DWORD ThreadId;
	ThreadMailbox Mailbox;
	BOOL fWindowsNT40;
	ULONG j;

	HCARD handle;								/*Handle of CM429-1 card*/
	ERRVAL errval;								/*Error result*/

	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP7  Version 1.0  (05/26/1999)");
	fprintf(stderr,"\nCopyright 1999  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Example with explicit message timing and interrupts.\"");
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
*  Open the CM429-1 card in socket 0.  A handle to the card
*  is returned which is tested to determine if an error
*  occurred.
*
**/

	handle = C41_OpenCard(0);			/*Open CM429-1 card in socket 0*/

	if (handle<0)
	{
		printf("\nError:  Either a CM429-1 is not present in socket 0 or");
		printf("\n        an error occurred (%i) opening the card in socket 0.",handle);
		printf("\n");
		exit(1);
	}

/**
*
*  Reset the card which also resets the Min/Max Elapsed Time
*  counters.
*
**/

	C41_Reset(handle);

/**
*
*  Create an event object.
*
**/

	if (fWindowsNT40)
	{
		Mailbox.hEvent = OpenEvent(
			SYNCHRONIZE,				//Desired access
			FALSE,						//Inherit flag
			"CM429Interrupt");			//Pointer to event-object name  

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			C41_CloseCard(handle);
			exit(1);
		}
	}
	else
	{
		Mailbox.hEvent = CreateEvent(
			NULL,
			TRUE,						//Flag for manual-reset event 
			FALSE,						//Flag for initial state 
			NULL);						//Pointer to event-object name  

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			C41_CloseCard(handle);
			exit(1);
		}
	}

/**
*
*  Create a thread.
*
**/

	Mailbox.fWindowsNT40 = fWindowsNT40;
	Mailbox.handle       = handle;

	Mailbox.hThread = CreateThread(
		NULL,					//Use the default security attributes  
		0x10000,				//Initial thread stack size
		InterruptServiceThread,	//Pointer to thread function 
		(LPVOID)&Mailbox,		//Argument for new thread 
		0,						//Creation flags 
		&ThreadId);				//Pointer to returned thread identifier 

	if (Mailbox.hThread == NULL)
	{
		printf("\nThread creation failed");
		printf("\nGetLastError = %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		C41_CloseCard(handle);
		exit(1);
	}

/**
*
*  Install the interrupt handler.
*
**/

	errval = C41_IntInstall(Mailbox.hEvent,handle);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while installing interrupt handler.",errval);
		printf("\nGetLastError returned %d",GetLastError());
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		C41_CloseCard(handle);
		exit(1);
	}

/**
*
*  Configure channel RCH0 to be active and to receive at low
*  speed.  The Min/Max Elapse Time option is also enabled.
*
**/

	errval = C41_ChConfig(CHCFG_ACTIVE | CHCFG_MAXMIN,RCH0,handle);	/*Configure RCH0*/

	if (errval<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring receive channel 0.",errval);
	}

/**
*
*  Configure channel TCH4 to be active and to transmit at low
*  speed.  Note that the wrap-around selftest is also enabled. 
*  The external line drivers are disabled, and TCH4 is
*  connected internally to RCH0 and RCH1.  The data received
*  by RCH1 is inverted, but the data received by RCH0 is not.
*
**/

	errval = C41_ChConfig(CHCFG_ACTIVE | CHCFG_WRAPTEST | CHCFG_INTSCH, TCH4, handle);

	if (errval<0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring transmit channel 4.",errval);
	}

/**
*
*  Before any messages can be received, filters must be set
*  for the receive channel.  Two filters are set for the two
*  messages of interest.  Note that no default filter is
*  created.
*
**/

	C41_FilterSet(0206, SDIALL, RCV_AIRSPEED, RCH0, handle);
	C41_FilterSet(0212, SDIALL, RCV_ALTITUDE, RCH0, handle);

/**
*
*  Next, a schedule is built by creating explicit message timing.
*
**/

	C41_SchedMsg(XMT_ALTITUDE, TCH4, handle);
	C41_SchedMsg(XMT_AIRSPEED, TCH4, handle);
	C41_SchedGap(495, TCH4, handle);
	C41_SchedMsg(XMT_ALTITUDE, TCH4, handle);
	C41_SchedGap(531, TCH4, handle);
	C41_SchedInt(0xFFFF, TCH4, handle);

/**
*
*  Those messages that are to be transmitted are initialized.
*
**/

	C41_MsgArincWr(0x0000008A, XMT_ALTITUDE, handle);
	C41_MsgArincWr(0x00000086, XMT_AIRSPEED, handle);

/**
*
*  Start operation of the card.
*
**/

	C41_Start(handle);

/**
*
*  Display data until a key is pressed.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{

/**
*
*  The Message Records containing receive messages are read. 
*  Each Message Record contains 8 16-bit words, of which word
*  4 and 5 contain the Minimum and Maximum Elapsed time
*  respectively.  These values are displayed on the screen
*  as well as the message value received.
*
**/

		C41_MsgBlockRd(AltitudeRecord, RCV_ALTITUDE, handle);
		C41_MsgBlockRd(AirSpeedRecord, RCV_AIRSPEED, handle);

		printf("\r");														/*Display values*/

//		printf("AirSpeed=%08lX ",C41_MsgArincRd(RCV_AIRSPEED, handle));		/*Read and display*/
//		printf("min/max=%ums/%ums ",AirSpeedRecord[4],AirSpeedRecord[5]);

//		printf("Altitude=%08lX ",C41_MsgArincRd(RCV_ALTITUDE, handle));		/*message values*/
//		printf("min/max=%ums/%ums ",AltitudeRecord[4],AltitudeRecord[5]);

		printf("Hits=%u Misses=%u ",Mailbox.Hits,Mailbox.Misses);
	}

/**
*
*  Stop the CM429-1 card.
*
**/

	C41_Stop(handle);

/**
*
*  The Message Records containing receive messages are read. 
*  Each Message Record contains 8 16-bit words, of which word
*  4 and 5 contain the Minimum and Maximum Elapsed time
*  respectively.  These values are displayed on the screen.
*
**/

	C41_MsgBlockRd(AltitudeRecord, RCV_ALTITUDE, handle);
	C41_MsgBlockRd(AirSpeedRecord, RCV_AIRSPEED, handle);

	printf("\nMax transmit interval of AirSpeed is %ums.",AirSpeedRecord[4]);
	printf("\nMin transmit interval of AirSpeed is %ums.",AirSpeedRecord[5]);
	printf("\nMax transmit interval of Altitude is %ums.",AltitudeRecord[4]);
	printf("\nMin transmit interval of Altitude is %ums.",AltitudeRecord[5]);

/**
*
*  Clear the flag keeping the thread alive and wait for the
*  thread to quit.
*
**/

	printf("\nWaiting for the thread to quit.");
	
	Mailbox.fStayAlive = FALSE;						//Clear the fStayAlive flag so the thread commits suicide after the next interrupt

	for (j=0xFFFFFFFF;j && !Mailbox.fHasQuit;--j);	//Waiting for thread to quit

/**
*
*  Uninstall the interrupt handler.
*
**/

	errval = C41_IntUninstall(handle);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while uninstalling interrupt handler.",errval);
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		C41_CloseCard(handle);
		exit(1);
	}

/**
*
*  The CM429-1 card MUST be closed before exiting the program.
*
**/

	C41_IntUninstall(handle);
	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);
	C41_CloseCard(handle);
}
