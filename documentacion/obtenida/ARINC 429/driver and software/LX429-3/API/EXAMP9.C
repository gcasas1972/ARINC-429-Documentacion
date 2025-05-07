
/**
*
*  LP429-3 and LC429-3 DRIVER EXAMPLE 9  Version 1.0  (10/29/2001)
*  Copyright (c) 1998-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   EXAMP9.C -- Example 9.
*                      "Transmitter interrupt example"
*
**/

/**
*
*  This program is example program two written to incoorporate
*  the use of interrupts.  An interrupt serivce thread is created
*  and will check to see if the card has issued an interrupt.
*  The thread will read the interrupt info out of the card using the 
*  L43_IntRd function.
*
**/

#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>
#include "l43w32.h"

#define	CARDNUM 0                   /*Card number of L43 card*/

typedef struct                      /*Variables used by the thread*/
{
	BOOL      fWindowsNT40;         /*Flags whether we are running under Windows NT 4.0*/
	BOOL      fStayAlive;           /*Flag indicating the thread should stay alive*/
	BOOL      fHasQuit;             /*Flag indicating the thread has quit*/
	HCARD     Card;                 /*Handle of LP429-3 card*/
	ULONG     Hits;                 /*Counting variable*/
	ULONG     Misses;               /*Counting variable*/
	HANDLE    hEvent;               /*Handle of event*/
	HANDLE    hThread;              /*Handle of event*/
	MSGSTRUCT comp_airspeed;        /*Message*/
	MSGSTRUCT tot_air_temp;         /*Message*/
	MSGSTRUCT altitude_rate;        /*Message*/
} ThreadMailbox;

/**
*
*  This is the interrupt service thread.  It will read 
*  data from the interrupt log list using L43_IntRd(), increment 
*  the data from the message associated with the interrupt,
*  and then write the data back to the card.
*
**/

DWORD WINAPI InterruptServiceThread(LPVOID lpParam)
{
	ULONG msgaddr;
	ULONG bnr_data;

	ThreadMailbox *pMailbox = (ThreadMailbox*)lpParam;

	while(pMailbox->fStayAlive)
	{
		if (WaitForSingleObject(pMailbox->hEvent,200) == WAIT_TIMEOUT)
		{
			pMailbox->Misses++;               //Increment counter
		}
		else
		{
			if (!(pMailbox->fWindowsNT40))    //Reset event if not Windows NT 4.0
			{                                 //to allow another event
				ResetEvent(pMailbox->hEvent);
			}

			pMailbox->Hits++;                 //Increment counter

			L43_IntRd(NULL,&msgaddr,pMailbox->Card);

			if (msgaddr == pMailbox->comp_airspeed.addr)
			{
				pMailbox->comp_airspeed.data = L43_MsgDataRd(msgaddr,pMailbox->Card);
				bnr_data = L43_BNRGetMant(pMailbox->comp_airspeed.data,14);
				++bnr_data;
				pMailbox->comp_airspeed.data = L43_BNRPutMant(pMailbox->comp_airspeed.data,bnr_data,14,0);
				L43_MsgDataWr(pMailbox->comp_airspeed.data,msgaddr,pMailbox->Card);
			}
			else if (msgaddr == pMailbox->tot_air_temp.addr)
			{
				pMailbox->tot_air_temp.data = L43_MsgDataRd(msgaddr,pMailbox->Card);
				bnr_data = L43_BNRGetMant(pMailbox->tot_air_temp.data,14);
				++bnr_data;
				pMailbox->tot_air_temp.data = L43_BNRPutMant(pMailbox->tot_air_temp.data,bnr_data,14,0);
				L43_MsgDataWr(pMailbox->tot_air_temp.data,msgaddr,pMailbox->Card);
			}
			else if (msgaddr == pMailbox->altitude_rate.addr)
			{
				pMailbox->altitude_rate.data = L43_MsgDataRd(msgaddr,pMailbox->Card);
				bnr_data = L43_BNRGetMant(pMailbox->altitude_rate.data,14);
				++bnr_data;
				pMailbox->altitude_rate.data = L43_BNRPutMant(pMailbox->altitude_rate.data,bnr_data,14,0);
				L43_MsgDataWr(pMailbox->altitude_rate.data,msgaddr,pMailbox->Card);
			}

			L43_IntReset(pMailbox->Card);
		}
	}

	pMailbox->fHasQuit = TRUE;                   //Set flag indicating we have quit

	return(0);
}

void main(void)
{
	DWORD ThreadId;
	ThreadMailbox Mailbox;
	BOOL fWindowsNT40;

	HCARD   Card;
	ERRVAL  errval;
	INT     xmtchan;
	ULONG   j;
	MSGADDR msgaddr[3];
	INT	min_intrvls[3];
	INT	max_intrvls[3];

	OSVERSIONINFO OSInfo;

	fprintf(stderr,"\nEXAMP9  Version 1.0  (10/29/2001)");
	fprintf(stderr,"\nCopyright 1998-2001  Ballard Technology, Inc.  Everett, WA, USA.");
	fprintf(stderr,"\nAll rights reserved.");
	fprintf(stderr,"\nGo to www.ballardtech.com or email support@ballardtech.com");
	fprintf(stderr,"\n");
	fprintf(stderr,"\nLP429-3 and LC429-3 Example 9");
	fprintf(stderr,"\n\"Transmitter interrupt example\"");
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
		fWindowsNT40 = (VER_PLATFORM_WIN32_NT==OSInfo.dwPlatformId && 4>=OSInfo.dwMajorVersion);
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
*  Open the L43 card with the specified card number.
*  A handle to the card is returned which is tested
*  to determine if an error occurred.
*
**/

	Card = L43_CardOpen(CARDNUM);                /*Open the L43 card*/

	if (Card < 0)
	{
		printf("\nError:  Either L43 card number %u is not present, or",CARDNUM);
		printf("\n        an error occurred (%i) opening the card.",Card);
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
		if (L43_CardGetInfo(INFOTYPE_PLAT,Card) == 'LP')   //Card is LP429-3
		{
			Mailbox.hEvent = OpenEvent(
				SYNCHRONIZE,                //Desired access
				FALSE,                      //Inherit flag
				"LP429Interrupt");          //Pointer to event-object name
		}
		else                                               //Card is LC429-3
		{
			Mailbox.hEvent = OpenEvent(
				SYNCHRONIZE,                //Desired access
				FALSE,                      //Inherit flag
				"LC429Interrupt");          //Pointer to event-object name
		}

		if (Mailbox.hEvent == NULL)
		{
			printf("\nEvent creation failed");
			printf("\nGetLastError returned %d",GetLastError());
			L43_CardClose(Card);
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
			L43_CardClose(Card);
			exit(1);
		}
	}

/**
*
*  Create a thread.
*
**/

	Mailbox.fWindowsNT40 = fWindowsNT40;
	Mailbox.Card         = Card;

	Mailbox.fStayAlive   = TRUE;
	Mailbox.fHasQuit     = FALSE;
	Mailbox.Hits         = 0;
	Mailbox.Misses       = 0;

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
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Install the interrupt handler for the card.
*
**/

	errval = L43_IntInstall(Mailbox.hEvent,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  Unable to install the interrupt handler for the");
		fprintf(stderr,"\n        L43 card number %u.",Card);
		fprintf(stderr,"\n");
		CloseHandle(Mailbox.hThread);
		CloseHandle(Mailbox.hEvent);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Find the first transmit channel.
*
**/

	for (xmtchan=0;xmtchan<8;++xmtchan) if (L43_IsXmtChan(xmtchan,Card)) break;

	if (xmtchan == 8)
	{
		printf("\nError:  No transmit channels present in L43 cardnum %d.",CARDNUM);
		printf("\n");
		exit(1);
	}

	fprintf(stderr,"\nUsing transmit channel %d",xmtchan);
	fprintf(stderr,"\n");

/**
*
*  Configure xmtchan to transmit at low speed.
*
**/

	L43_CardReset(Card);                    /*Reset the L43 card*/

	errval = L43_ChConfig(CHCFG_DEFAULT,xmtchan,Card);	/*Configure channel*/

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring channel %d.",errval,xmtchan);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Create a message for each of the labels we are transmitting.
*  Each message is configured to cause an interrupt.
*
**/

	Mailbox.comp_airspeed.addr = L43_MsgCreate(MSGCRT_INT,Card);
	Mailbox.tot_air_temp.addr  = L43_MsgCreate(MSGCRT_INT,Card);
	Mailbox.altitude_rate.addr = L43_MsgCreate(MSGCRT_INT,Card);

/**
*
*  Setup the arrays of message addresses, and intervals
*  needed to build the schedule.  Note that the nth element
*  in each array correspond to eachother.
*
**/

	msgaddr[0] = Mailbox.comp_airspeed.addr;
	min_intrvls[0] = 250; 
	max_intrvls[0] = 500; 

	msgaddr[1] = Mailbox.tot_air_temp.addr;
	min_intrvls[1] = 250; 
	max_intrvls[1] = 500; 

	msgaddr[2] = Mailbox.altitude_rate.addr;
	min_intrvls[2] = 100;
	max_intrvls[2] = 200;

/**
*
*  Next, build a schedule using the minimum and maximum
*  transmit intervals.
*
**/

	L43_SchedBuild(3,msgaddr,min_intrvls,max_intrvls,xmtchan,Card);

/**
*
*  Initialize the three Message Records.
*
**/

	Mailbox.comp_airspeed.data = L43_FldPutLabel(0L,0206);   /*Init label field*/
	Mailbox.tot_air_temp.data  = L43_FldPutLabel(0L,0211);
	Mailbox.altitude_rate.data = L43_FldPutLabel(0L,0212);

	Mailbox.comp_airspeed.data = L43_BNRPutMant(Mailbox.comp_airspeed.data,0L,14,0);   /*Init BNR data*/
	Mailbox.tot_air_temp.data  = L43_BNRPutMant(Mailbox.tot_air_temp.data,0L,11,0);
	Mailbox.altitude_rate.data = L43_BNRPutMant(Mailbox.altitude_rate.data,0L,16,0);

	L43_MsgDataWr(Mailbox.comp_airspeed.data,Mailbox.comp_airspeed.addr,Card);
	L43_MsgDataWr(Mailbox.tot_air_temp.data,Mailbox.tot_air_temp.addr,Card);
	L43_MsgDataWr(Mailbox.altitude_rate.data,Mailbox.altitude_rate.addr,Card);

/**
*
*  Configure the interrupt log list.
*
**/

	errval = L43_IntConfig(INTCFG_ENABLE,1024,Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while configuring interrupt log list.",errval);
		L43_IntUninstall(Card);
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  Start operation of the card.
*
**/

	L43_CardStart(Card);

/**
*
*  Display data on the screen.
*
**/

	fprintf(stderr,"\nPress a key to exit....\n\n");

	while(!kbhit())
	{
		printf("\r");
		printf("AirSpeed=%08lX ",Mailbox.comp_airspeed.data);
		printf("AirTemp=%08lX ",Mailbox.tot_air_temp.data);
		printf("AltRate=%08lX",Mailbox.altitude_rate.data);
	}

/**
*
*  Clear the flag keeping the thread alive and wait for the
*  thread to quit.
*
**/

	printf("\nWaiting for the thread to quit.");
	
	Mailbox.fStayAlive = FALSE;                     //Clear the fStayAlive flag so the thread commits suicide after the next interrupt

	for (j=0xFFFFFFFF;j && !Mailbox.fHasQuit;--j);  //Waiting for thread to quit

/**
*
*  Stop the L43 card.
*
**/

	L43_CardStop(Card);

/**
*
*  Uninstall the interrupt handler.
*
**/

	errval = L43_IntUninstall(Card);

	if (errval < 0)
	{
		fprintf(stderr,"\nError:  An error was encountered (%i) while uninstalling interrupt handler.",errval);
		CloseHandle(Mailbox.hEvent);
		CloseHandle(Mailbox.hThread);
		L43_CardClose(Card);
		exit(1);
	}

/**
*
*  The L43 card MUST be closed before exiting the program.
*
**/

	CloseHandle(Mailbox.hThread);
	CloseHandle(Mailbox.hEvent);
	L43_CardClose(Card);
}
