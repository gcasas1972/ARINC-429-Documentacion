
/**
*
*   PC429 #3 DEMO C PROGRAM  Version 1.0  (03/31/1999)
*   Copyright (c) 1997-1999
*   Ballard Technology, Inc.
*   www.ballardtech.com
*   support@ballardtech.com
*   ALL RIGHTS RESERVED
*
*   NAME:   DEMO3.C -- Demo program #3.
*
**/

/**
*
*   This file is the third sample program demonstrating the
*   PC429 Driver functions.  It is a simple program which
*   transmits a Fuel Flow message (label=244, equip id=33)
*   every 150ms with every other message containing a parity
*   error.  It also displays any received messages with the
*   same label.
*
*   To compile this program with the Microsoft C compiler,
*   use the following command line:
*
*   CL DEMO1.C P42W32.LIB GDI32.LIB
*
*   To run this example application, a PC429 card must be
*   installed in the computer.  The file P42W32.DLL must be
*   copied into the Windows subdirectory, or into any
*   subdirectory specified by the PATH environment variable.
*
*   Note that an image file is not needed.
*
**/

#include <windows.h>
#include <stdlib.h>
#include <string.h>
#include "p42w32.h"

unsigned long xmitaddr;			//Address of transmit message
unsigned long xmitmsg;			//32-bit value of transmit message
unsigned long xmitgap;			//32-bit value of message gap

unsigned long rcvaddr;			//Address of received message
unsigned long rcvmsg;			//32-bit value of received message
unsigned long rcvdata;			//23-bit value of data field of received msg
unsigned long rcvtime;			//24-bit value of time tag of received msg

unsigned xmitchan = CH1;		//Assume transmit channel on channel 1
unsigned rcvchan  = CH0;		//Assume receive channel on channel 0

HCARD handleval;				//Device handle of PC429 board

char szBuf[256];				//Temporary buffer
char szBufTemp[256];			//Temporary buffer

/**
*
*  The ServiceBackground() procedure displays the transmitted and
*  received messages.
*
**/

void ServiceBackground(HWND hWnd)
{
	HANDLE hDC;

	hDC = GetDC(hWnd);									//Get window device context

/**
*
*   The following lines read the received message, extract the
*   value of the data field, and display the BNR value.
*
**/

	rcvtime = PC429_RdTime(rcvaddr,handleval);			//Read timestamp
	rcvmsg  = PC429_RdMsg(rcvaddr,handleval);			//Read received msg
	rcvdata = PC429_GetFldData(rcvmsg);					//Extract data field

	wsprintf(szBuf,"RCVMSG    = %08lX   ",rcvmsg);		//Display receive message
	TextOut(hDC,10,10,szBuf,strlen(szBuf));

	wsprintf(szBuf,"RCVTIME   = %08lX   ",rcvtime);		//Display receive timestamp
	TextOut(hDC,10,30,szBuf,strlen(szBuf));

	wsprintf(szBuf,"RCVDATA   = %08lX   ",rcvdata);		//Display receive data
	TextOut(hDC,10,50,szBuf,strlen(szBuf));

	PC429_GetBNRVal(szBufTemp,rcvmsg,16,".5");			//BNR data to string
	wsprintf(szBuf,"BNR VALUE = %s  ",(LPSTR)szBufTemp);
	TextOut(hDC,10,70,szBuf,strlen(szBuf));

	ReleaseDC(hWnd,hDC);
}

/**
*
*  The WndProc() procedure handles the Windows messages.
*
**/

LRESULT CALLBACK WndProc(HWND hWnd,WORD iMessage,WPARAM wParam,LPARAM lParam)
{
	switch (iMessage)
	{
		case WM_TIMER:
			ServiceBackground(hWnd);
			break;

		case WM_CREATE:
			break;

		case WM_DESTROY:
			PostQuitMessage(0);
			break;

		default:
			return(DefWindowProc(hWnd,iMessage,wParam,lParam));
	}

	return(0);
}

/**
*
*    The WinMain() procedure is the main Windows procedure.
*
**/

int APIENTRY WinMain(HANDLE hInstance,HANDLE hPrevInstance,LPSTR lpszCmdLine,int nCmdShow)
{
	WORD wTimer;
	WNDCLASS wndclass;
	MSG msg;
	char szClassName[40] = "PC429 Windows Demo #3";
	HWND hMainWnd;											//Main window handle

	if (hPrevInstance) exit(0);

	wndclass.style         = CS_HREDRAW | CS_VREDRAW;
	wndclass.lpfnWndProc   = (WNDPROC)WndProc;
	wndclass.cbClsExtra    = 0;
	wndclass.cbWndExtra    = 0;
	wndclass.hInstance     = hInstance;
	wndclass.hIcon         = NULL;
	wndclass.hCursor       = LoadCursor(NULL,IDC_ARROW);
	wndclass.hbrBackground = GetStockObject(WHITE_BRUSH);
	wndclass.lpszMenuName  = NULL;
	wndclass.lpszClassName = szClassName;

	if (!RegisterClass(&wndclass)) exit(0);

	hMainWnd = CreateWindow(szClassName,szClassName,WS_OVERLAPPEDWINDOW,0,0,(3*GetSystemMetrics(SM_CXSCREEN))/8,(3*GetSystemMetrics(SM_CYSCREEN))/8,NULL,NULL,hInstance,NULL);

	if (!hMainWnd) exit(0);

	ShowWindow(hMainWnd,nCmdShow);
	UpdateWindow(hMainWnd);

/**
*
*   The following statement checks for the presence of a
*   PC429 card.
*
**/

	handleval = PC429_Check(0xCE00,0x250,2,1);			//Check for card

	if (handleval<0)									//Check for card
	{
		MessageBox(hMainWnd,"Unable to open the device \\\\.\\PC429Board0.","Warning!",MB_OK);
		exit(0);
	}

	PC429_Reset(handleval);				//Reset card

/**
*
*   The following statement checks for the correct configuration of
*   the PC429 card.
*
**/

	if (!PC429_IsXmit(xmitchan,handleval) || !PC429_IsRcv(rcvchan,handleval))
	{
		MessageBox(hMainWnd,"Channel 1 is not a transmit channel, and/or channel 0 is not a receive channel.","Warning!",MB_OK);
		exit(0);
	}

/**
*
*   The following statements clear the card of messages and
*   filters and then inserts the first transmit message.
*
**/

	PC429_Stop(handleval);									//Stop image

	PC429_ClrMsgFilt(handleval);							//Clear msgs and filt

	xmitmsg = 0L;											//Zero message
	xmitmsg = PC429_PutFldLabel(xmitmsg,0244);				//Stuff label 244
	xmitmsg = PC429_PutBNRVal("550",xmitmsg,16,".5");		//Stuff value 550

	xmitgap = 0x00000733L;									//150ms gap

	xmitaddr = PC429_InsMsg(0,xmitmsg,xmitgap,xmitchan,handleval);	//Insert message

	if (!xmitaddr)											//Check for error
	{
		MessageBox(hMainWnd,"Unable to insert first message.","Warning!",MB_OK);
		exit(0);
	}

/**
*
*   The following statements insert the same message again
*   but with the error bit in the gap value set.  When this
*   second message is transmitted, it will contain the parity
*   error.
*
**/

	xmitgap = 0x00000733L + GAP_ERWRD;						//Set error bit

	xmitaddr = PC429_InsMsg(1,xmitmsg,xmitgap,xmitchan,handleval);	//Insert 2nd message

	if (!xmitaddr)											//Check for error
	{
		MessageBox(hMainWnd,"Unable to insert second message.","Warning!",MB_OK);
		exit(0);
	}

/**
*
*   The following statements insert a filter into the receive
*   channel.
*
**/

	rcvaddr = PC429_InsFilt(0244,SDI00+SDI01+SDI10+SDI11,rcvchan,handleval);	//Filter

	if (!rcvaddr)										//Check for error
	{
		MessageBox(hMainWnd,"Unable to insert filter.","Warning!",MB_OK);
		exit(0);
	}

/**
*
*   The following statements configure the PC429 card.
*
**/

	PC429_Active(xmitchan | rcvchan,handleval);		//Both channels active
	PC429_Error(xmitchan,handleval);				//Transmit errors enabled
	PC429_HighSpeed(CHNONE,handleval);				//Both channels low speed
	PC429_Parity(xmitchan,handleval);				//Set transmit parity even
	PC429_SelfTest(xmitchan | rcvchan,handleval);	//Set wrap-around self-test

/**
*
*   The following starts the operation of the card.
*
**/

	PC429_Start(handleval);						//Start image

	wTimer = SetTimer(hMainWnd,1,5,NULL);

	if (!wTimer)
	{
		MessageBox(hMainWnd,"Unable to allocate a timer.","Warning!",MB_OK);
		exit(0);
	}

	while(GetMessage(&msg,NULL,0,0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

/**
*
*   The following statement stops the card.
*
**/

	PC429_Stop(handleval);		//Stop card

	KillTimer(hMainWnd,1);		//Destroy timer

	return(msg.wParam);
}
