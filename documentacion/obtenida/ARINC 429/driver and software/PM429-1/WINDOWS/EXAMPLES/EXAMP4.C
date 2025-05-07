/**
*
*  PM429-1 EXAMPLE 4  Version 1.1  (04/05/2006)
*  Copyright (c) 2001-2006
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP4.C -- Example 4 
*                      "Program for transmitter example using interrupts."
*
**/

/**
*
*  This program detects the PM429-1 card at port 0x2C0, and
*  then transmits the messages with ramping data.
*
**/

#include "pm41.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>

struct Mailbox						//Variables used by the thread
{
	BOOL      fWindowsNT40;			//Flags whether we are running under WINNT
	BOOL      fStayAlive;			//Flag indicating the thread should stay alive
	BOOL      fToggle;				//Toggle between frames
	USHORT    port;					//Port address of card
	HANDLE    hEvent;				//Handle of event object
	HANDLE    hThread;				//Handle of thread object
	UINT      airspeed;				//Arinc word
	UINT      airtemp;				//Arinc word
} ThreadMailbox;

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	UINT airspeed_data;	/* data value */
	UINT airspeed_label;/* label */
	UINT airspeed_sdi;	/* sdi */
	UINT airspeed_ssm;	/* ssm */

	UINT airtemp_data;	/* data value */
	UINT airtemp_label; /* label */
	UINT airtemp_sdi;	/* sdi */
	UINT airtemp_ssm;	/* ssm */

	struct Mailbox *pMailbox = (struct Mailbox*)lpParam;

	//
	//	Initialize variables
	//

	airspeed_data  = 0;								/* set data */
	airspeed_label = PM41_UtilReverseLabel(0210);	/* set label (reverse bit order of octal 210) */
	airspeed_sdi   = (0 <<  9);						/* set SDI */ 
	airspeed_ssm   = (2 << 29);						/* set SSM */ 

	airtemp_data   = 0;								/* set data */
	airtemp_label  = PM41_UtilReverseLabel(0211);	/* set label (reverse bit order of octal 211) */
	airtemp_sdi    = (0 <<  9);						/* set SDI */ 
	airtemp_ssm    = (2 << 29);						/* set SSM */ 

	while(pMailbox->fStayAlive)
	{
		if (WaitForSingleObject(pMailbox->hEvent,200) != WAIT_TIMEOUT)
		{
			if (!(pMailbox->fWindowsNT40))				//Reset event if not WINNT
			{											//to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			//		
			//	Toggle between frame 1 and frame 2
			//

			if (pMailbox->fToggle)
			{
				//
				//	Process airspeed and air temperature message
				//

				airspeed_data      = ( airspeed_data>0x0007FFFE ) ? 0 : airspeed_data+1;               /* Calc new data */
				pMailbox->airspeed = ( airspeed_data | airspeed_sdi | airspeed_ssm | airspeed_label ); /* OR in SDI/SSM/label */
				
				airtemp_data      = (airtemp_data>0x0007FFFE) ? 0 : airtemp_data+1;						 /* Calc new data */
				pMailbox->airtemp = ( airtemp_data | airtemp_sdi | airtemp_ssm | airtemp_label );		 /* OR in SDI/SSM/label */

				//
				//	Write data and gap
				//

				PM41_ChDataWr(pMailbox->airspeed, CH4, pMailbox->port);		/* write data to TCH4 */
				PM41_ChDataWr(pMailbox->airtemp,  CH4, pMailbox->port);		/* write data to TCH4 */

				PM41_ChGapWr(870, CH4, pMailbox->port);						/* Write gap to start transmission */
			}
			else
			{
				//
				//	Process airspeed message
				//

				airspeed_data =      ( airspeed_data>0x0007FFFE ) ? 0 : airspeed_data+1;               /* Calc new data */
				pMailbox->airspeed = ( airspeed_data | airspeed_sdi | airspeed_ssm | airspeed_label ); /* OR in SDI/SSM/label */

				//
				//	Write data and gap
				//
			
				PM41_ChDataWr(pMailbox->airspeed, CH4, pMailbox->port);		/* write data to TCH4 */
													
				PM41_ChGapWr(905, CH4, pMailbox->port);						/* Write gap to start transmission*/
			}


			PM41_IntReset(pMailbox->port);				//Reset interrupt

			pMailbox->fToggle = !pMailbox->fToggle;		//Toggle flag
		}
	}

	return(0);
}

void main(void)
{
	USHORT port;		/* Port setting of PM429-1 card */
	HANDLE hCard;		/* PM429-1 card descriptor */
	BOOL val;			/* Test variable */
	BOOL result;

	DWORD ThreadId;
	OSVERSIONINFO OSInfo;
	BOOL fWindowsNT40;

	fprintf(stderr,"\nEXAMP4  Version 1.1  (04/05/2006)");
	fprintf(stderr,"\nCopyright 2001-2006  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\n\"Program for transmitter example using interrupts.\"");
	fprintf(stderr,"\n");

	port = 0x2C0;						/* port setting */

	//
	//	Determine which OS we're running.  Interrupt handling is
	//	slightly different between NT and all others.
	//

	OSInfo.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);

	if (GetVersionEx(&OSInfo))
	{
		fWindowsNT40 = (VER_PLATFORM_WIN32_NT==OSInfo.dwPlatformId && 4>=OSInfo.dwMajorVersion);
	}
	else
	{
		printf("\nError:  Unable to determine the operating system");
		printf("\n        we are running on.");
		printf("\n");
		exit(1);
	}

	//
	//	Open the card using the'SymbolicName' from the
	// .INF or .REG file, but with the prefix '\\\\.\\'
	//

	hCard = PM41_CardOpen("\\.\\\\PM429Card", port);

	if (hCard==PM41_INVALID_HANDLE)
	{
		printf("\nFAILED: Could not open card");
		return;
	}

	if (hCard==PM41_ERRMEM_HANDLE)
	{
		printf("\nFAILED: Not enough memory");
		printf("\n        Increase PM41_MAXCARDS");
		return;
	}

	printf("\nOpened card %08lX at %03XH",hCard,port);

	//
	//	Check card
	//

	val = PM41_IsCard(port);			/* Access PM429-1 */

	if (!val)
	{
		printf("\nError:  No PM429-1 present at port %03X", port);
		printf("\n");
		exit(1);
	}

	PM41_CardReset(port);				/* Reset card */

	//
	//	Create an event object.
	//

	if (fWindowsNT40)
	{
		ThreadMailbox.hEvent = OpenEvent(
			SYNCHRONIZE,				//Desired access
			FALSE,						//Inherit flag
			"PM429Interrupt");			//Pointer to event-object name

		if (ThreadMailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			PM41_CardClose(port);
			exit(1);
		}
	}
	else
	{
		ThreadMailbox.hEvent = CreateEvent(
			NULL,
			TRUE,						//Flag for manual-reset event 
			FALSE,						//Flag for initial state 
			NULL);						//Pointer to event-object name  

		if (ThreadMailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			PM41_CardClose(port);
			exit(1);
		}
	}

	//
	//	Create a thread.
	//

	ThreadMailbox.fWindowsNT40 = fWindowsNT40;
	ThreadMailbox.port         = port;
	ThreadMailbox.fStayAlive   = TRUE;
	ThreadMailbox.fToggle      = FALSE;

	ThreadMailbox.hThread = CreateThread(
		NULL,					//Use the default security attributes  
		0x10000,				//Initial thread stack size
		InterruptServiceThread,	//Pointer to thread function 
		(LPVOID)&ThreadMailbox,	//Argument for new thread 
		0,						//Creation flags 
		&ThreadId);				//Pointer to returned thread identifier 

	if (ThreadMailbox.hThread == NULL)
	{
		printf("\nThread creation failed");
		printf("\nGetLastError = %d",GetLastError());
		CloseHandle(ThreadMailbox.hEvent);
		PM41_CardClose(port);
		exit(1);
	}

	//
	//	Enable interrupts from card.
	//

	PM41_IntEnable(SRQ_TCH4,port);

	//
	//	Install the interrupt handler.
	//

	result = PM41_IntInstall(ThreadMailbox.hEvent,port);

	if (!result)
	{
		fprintf(stderr,"\nError:  An error was encountered while installing interrupt handler.");
		printf("\nGetLastError returned %d",GetLastError());
		CloseHandle(ThreadMailbox.hEvent);
		CloseHandle(ThreadMailbox.hThread);
		PM41_CardClose(port);
		exit(1);
	}

	//
	//	Configure channel TCH4 to be active and to transmit at low speed.
	//	A service request (SRQ) will be set when the transmit FIFO is empty.
	//

	PM41_ChConfig(ARINCCTRL_SPEED_LOW, ARINCCTRL_PAR_ODD, FALSE, FALSE, CH4, port);		/*Configure TCH4*/
	PM41_SRQConfig(ASRQ_XMT_EMPT,CH4, port);

	//
	//	Change data until a key is pressed.  The messages will be scheduled such that 
	//	the airspeed message will be transmitted every 75ms, and the air temperature
	//	message will be transmitted every 150ms. The SDI/SSM/label values are placed into 
	//	the proper place in the data word.  The messages will be placed into two 75ms frames.
	//
	//	See the PM429-1 manual for details of calculating schedule times.
	//

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		printf("\rAirspeed = %08lX  Airtemp = %08lX  Frame = %u", ThreadMailbox.airspeed, ThreadMailbox.airtemp, ThreadMailbox.fToggle ? 1:0);
	}

	//
	//	Clear the flag keeping the thread alive and wait for the
	//	thread to quit.
	//

	printf("\nWaiting for the thread to quit.");
	
	ThreadMailbox.fStayAlive = FALSE;					//Clear the fStayAlive flag so the thread exits

	WaitForSingleObject(ThreadMailbox.hThread,10000);	//Waiting for thread to quit

	//
	//	Uninstall the interrupt handler.
	//

	result = PM41_IntUninstall(port);

	if (!result)
	{
		fprintf(stderr,"\nError:  An error was encountered while uninstalling interrupt handler.");
		CloseHandle(ThreadMailbox.hEvent);
		CloseHandle(ThreadMailbox.hThread);
		PM41_CardClose(port);
		exit(1);
	}

	//
	//	Disable interrupts from card.
	//

	PM41_IntDisable(port);
	
	//
	//	Close the card
	//

	CloseHandle(ThreadMailbox.hEvent);
	CloseHandle(ThreadMailbox.hThread);
	PM41_CardClose(port);
}
