
/**
*
*   PC429 #2 DEMO C PROGRAM  Version 1.0  (03/31/1999)
*   Copyright (c) 1997-1999
*   Ballard Technology, Inc.
*   www.ballardtech.com
*   support@ballardtech.com
*   ALL RIGHTS RESERVED
*
*   NAME:   DEMO2.C -- Demo program #2.
*
**/

/**
*
*   This file is the second sample program demonstrating the
*   PC429 Driver functions.  It is a simple program which
*   transmits a message every 150ms and displays any received
*   messages with the same label.
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
*   The image file DEMO2.429 must be in the current
*   subdirectory.
*
**/

#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "p42w32.h"

unsigned long xmitaddr;			//Address of transmit message
unsigned long rcvaddr;			//Address of received message
unsigned long xmitmsg;			//32-bit value of transmit message
unsigned long rcvmsg;			//32-bit value of received message
unsigned long xmitdata;			//23-bit value of data field of transmit msg
unsigned long rcvdata;			//23-bit value of data field of received msg
unsigned long rcvtime;			//24-bit value of time tag of received msg

char szBuf[256];				//Temporary buffer

HCARD handleval;				//Device handle of PC429 board

/**
*
*  The ServiceBackground() procedure displays the transmitted and
*  received messages.
*
**/

void ServiceBackground(HWND hWnd)
{
	HANDLE hDC;

	hDC = GetDC(hWnd);							//Get window device context

/**
*
*   The following lines read the transmitted message and extract
*   the value of the data field.  The value is then decremented and
*   placed back into the message.  The message value is then
*   written back on the PC429 card.
*
*   The received message and its timestamp are also read and
*   displayed.
*
**/

	xmitmsg  = PC429_RdMsg(xmitaddr,handleval);	//Read transmit msg
	xmitdata = PC429_GetFldData(xmitmsg);		//Extract data field

	rcvmsg  = PC429_RdMsg(rcvaddr,handleval);	//Read received msg
	rcvtime = PC429_RdTime(rcvaddr,handleval);	//Read timestamp
	rcvdata = PC429_GetFldData(rcvmsg);			//Extract data field

	wsprintf(szBuf,"XMITMSG  =  %08lX  ",xmitmsg);		//Display transmit message
	TextOut(hDC,10,10,szBuf,strlen(szBuf));

	wsprintf(szBuf,"XMITDATA  =  %08lX  ",xmitdata);	//Display transmit data
	TextOut(hDC,10,30,szBuf,strlen(szBuf));

	wsprintf(szBuf,"RCVMSG  =  %08lX  ",rcvmsg);		//Display receive message
	TextOut(hDC,10,50,szBuf,strlen(szBuf));

	wsprintf(szBuf,"RCVTIME  =  %08lX  ",rcvtime);		//Display receive timestamp
	TextOut(hDC,10,70,szBuf,strlen(szBuf));

	wsprintf(szBuf,"RCVDATA  =  %08lX  ",rcvdata);		//Display receive data
	TextOut(hDC,10,90,szBuf,strlen(szBuf));

	xmitdata-=0x100L;									//Change transmit data

	xmitmsg = PC429_PutFldData(xmitmsg,xmitdata);		//Put data back in msg

	PC429_WrMsg(xmitaddr,xmitmsg,handleval);			//Write message with new data

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

int APIENTRY WinMain(HINSTANCE hInstance,HINSTANCE hPrevInstance,LPSTR lpszCmdLine,int nCmdShow)
{
	WORD wTimer;
	WNDCLASS wndclass;
	MSG msg;
	char szClassName[40] = "PC429 Windows Demo #2";
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
*   The following statement checks for the presence of a PC429
*   card.
*
**/

	handleval = PC429_Check(0xCE00,0x250,2,1);		//Check for card
	
	if (handleval<0)								//Check for card
	{
		MessageBox(hMainWnd,"Unable to open the device \\\\.\\PC429Board0.","Warning!",MB_OK);
		exit(0);
	}

/**
*
*   The following statement checks for the correct configuration of
*   the PC429 card.
*
**/

	if (!PC429_IsXmit(CH1,handleval) || !PC429_IsRcv(CH0,handleval) ||
		 PC429_IsXmit(CH2,handleval) ||  PC429_IsRcv(CH2,handleval) ||
		 PC429_IsXmit(CH3,handleval) ||  PC429_IsRcv(CH3,handleval))
	{
		MessageBox(hMainWnd,"Channel 1 is not a transmit channel, and/or channel 0 is not a receive channel.","Warning!",MB_OK);
		exit(0);
	}

/**
*
*   The following statement opens the Copilot image file
*   DEMO2.429 and loads it onto the PC429 card.
*
**/

	if (PC429_Load("DEMO2.429",handleval))		//Load to board
	{
		MessageBox(hMainWnd,"Unable to load image from the file DEMO2.429.","Warning!",MB_OK);
		exit(0);
	}

/**
*
*   The following starts the operation of the card.
*
**/

	PC429_Start(handleval);					//Start image

/**
*
*   The following statements read from the image file the
*   addresses of the specified transmit message and receive
*   filter.  Then the file is closed since all of the needed
*   information is already loaded into the hardware.
*
**/

	xmitaddr = PC429_NameToAddr("FUEL FLOW",        handleval,"DEMO2.429");
	rcvaddr  = PC429_NameToAddr("FUEL FLOW RECEIVE",handleval,"DEMO2.429");

	PC429_Start(handleval);					//Start PC429 card

	wTimer = SetTimer(hMainWnd,1,5,NULL);	//Allocate timer

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

	PC429_Stop(handleval);						//Stop card

	KillTimer(hMainWnd,1);					//Destroy timer

	return(msg.wParam);
}
