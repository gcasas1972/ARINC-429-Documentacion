
/**
*
*   PC429 #1 DEMO C PROGRAM  Version 1.0  (03/31/1999)
*   Copyright (c) 1997-1999
*   Ballard Technology, Inc.
*   www.ballardtech.com
*   support@ballardtech.com
*   ALL RIGHTS RESERVED
*
*   NAME:   DEMO1.C -- Demo program #1.
*
**/

/**
*
*   This file is the first sample program demonstrating the
*   PC429 Driver functions.  It transmits two messages every
*   150ms.  The first message is Fuel Flow with a label of
*   244(O).  The second message is Exhaust Gas Temperature
*   with a label of 345(O).
*
*   These messages are transmitted from a transmit channel
*   and received by a receive channel through the internal
*   wrap-around feature of the PC429 and displayed on the
*   screen.
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
**/

#include <windows.h>
#include <stdlib.h>
#include <string.h>
#include "p42w32.h"

#define FFMAX ((double)3800.0)			//Maximum value for FF
#define FFMIN ((double)550.0)			//Minimum value for FF
#define FFSIG 16						//Number of sig digits in FF
#define FFRANGE 32768L					//Range of FF
#define FFRESOL ".5"					//Resolution of FF

#define EGTMAX ((double)650.0)			//Maximum value for EGT
#define EGTMIN ((double)275.0)			//Minimum value for EGT
#define EGTSIG 12						//Number of sig digits in EGT
#define EGTRANGE 2048L					//Range of EGT
#define EGTRESOL ".5"					//Resolution of EGT

#define FFLOW   ((double)(FFMIN  + ((FFMAX  - FFMIN)  / 3.0)))
#define FFHIGH  ((double)(FFMAX  - ((FFMAX  - FFMIN)  / 3.0)))
#define EGTLOW  ((double)(EGTMIN + ((EGTMAX - EGTMIN) / 3.0)))
#define EGTHIGH ((double)(EGTMAX - ((EGTMAX - EGTMIN) / 3.0)))

LRESULT CALLBACK WndProc(HWND hWnd,UINT iMessage,WPARAM wParam,LPARAM lParam);

BOOLEAN externflag  = FALSE;			//Enables external wrap
BOOLEAN noboardflag = FALSE;			//Disables use of hardware
BOOLEAN bothvalflag = FALSE;			//Displays scales for xmit/rcv
BOOLEAN fullwidflag = FALSE;			//Displays scales full width

ULONG FFxmitaddr  = 0;					//Address of FF xmit message
ULONG FFrcvaddr   = 0;					//Address of FF rcv message
ULONG EGTxmitaddr = 0;					//Address of EGT xmit message
ULONG EGTrcvaddr  = 0;					//Address of EGT rcv message

double FFxmitengr  = FFMIN;				//FF value transmitted
double EGTxmitengr = EGTMIN;			//EGT value transmitted

INT ARINC_ADDR = 0xCE00;				//Segment address of PC429 board
INT ARINC_PORT = 0x250;					//Port address of PC429 board

HCARD handleval;						//Device handle of PC429 board

TCHAR szBuf[256];						//Temporary buffer
TCHAR szBufTemp[256];					//Temporary buffer

TCHAR szClassName[40] = "PC429 Windows Demo #1";		//Window title

/**
*
*    The BoardDisplay() procedure displays the configuration
*    of the PC429 board that will be operated.
*
**/

VOID BoardDisplay(HWND hWnd)
{
	USHORT channel;
	USHORT xmitwrap = 0xFFFF;
	USHORT rcvwrap  = 0xFFFF;

	if (!noboardflag)					//If using the hardware
	{
		szBuf[0]='\0';					//Clear string
		szBufTemp[0]='\0';				//Clear string

/**
*
*  Display segment and port address of board.
*
**/

		wsprintf(szBufTemp,"Segment Address:  %04XH\n",ARINC_ADDR);
		lstrcat(szBuf,szBufTemp);

		wsprintf(szBufTemp,"Port Address:  %03XH\n",ARINC_PORT);
		lstrcat(szBuf,szBufTemp);

		wsprintf(szBufTemp,"Channel Configuration:  ");
		lstrcat(szBuf,szBufTemp);

		memset(szBufTemp,0,sizeof(szBufTemp));		//Clear string

/**
*
*  Display channel configuration of board.
*
**/

		for (channel=0;channel<8;++channel)					//Loop for each channel
		{
			if (PC429_IsXmit(1<<channel,handleval))			//Is channel transmitter?
			{
				szBufTemp[7-channel]='T';					//Display T

				if (xmitwrap == 0xFFFF)						//If no xmit chan yet
				{
					xmitwrap = channel;						//Use this channel as xmit
				}
			}
			else if (PC429_IsRcv(1<<channel,handleval))		//Is channel receiver?
			{
				szBufTemp[7-channel]='R';					//Display R

				if (rcvwrap == 0xFFFF)						//If no rcv chan yet
				{
					rcvwrap = channel;						//Use this channel as rcv
				}
			}
			else
			{
				szBufTemp[7-channel]='-';					//Display dash
			}
		}

		lstrcat(szBuf,szBufTemp);
		lstrcat(szBuf,"\n");

/**
*
*  Display the two channels that will be used by the program.
*
**/

		wsprintf(szBufTemp,"Channel Operation:  %u -> %u",xmitwrap,rcvwrap);
		lstrcat(szBuf,szBufTemp);

		MessageBox(hWnd,szBuf,"Current Configuration",MB_OK);
	}
}

/**
*
*    The ServiceInit() procedure initializes the PC429 and
*    inserts the messages and filters.
*
**/

VOID ServiceInit(HWND hWnd)
{
	USHORT channel;
	ULONG FFmsg;
	ULONG FFgap;
	ULONG FFaddr;
	ULONG EGTmsg;
	ULONG EGTgap;
	ULONG EGTaddr;
	USHORT activeflag = 0;
	USHORT xmitwrap   = 0;
	USHORT rcvwrap    = 0;

	PC429_WipeMem(handleval);						//Reset card
	PC429_Reset(handleval);							//Reset card

	if (PC429_ClrMsgFilt(handleval))				//Clear msgs and filt
	{
		MessageBox(hWnd,"Unable to clear messages and filters.","Warning!",MB_OK);
		exit(0);
	}

	for (channel=0;channel<8;++channel)								//Loop for each channel
	{
		if (PC429_IsXmit(1<<channel,handleval))						//If transmit channel
		{
			FFmsg = PC429_PutFldLabel(0L,0244);						//Stuff label 244
			FFmsg = PC429_PutBNRVal("550",FFmsg,FFSIG,FFRESOL);		//Stuff value 550

			EGTmsg = PC429_PutFldLabel(0L,0345);					//Stuff label 345
			EGTmsg = PC429_PutBNRVal("275",EGTmsg,EGTSIG,EGTRESOL);	//Stuff value 275

			FFgap = 0x00000388L;									//72ms gap (150ms rep rate)
			FFgap = GAP_SYNC | FFgap;								//Enable sync
			FFgap = GAP_LOG  | FFgap;								//Enable log

			EGTgap = 0x00000388L;									//72ms gap (150ms rep rate)
			EGTgap = GAP_LOG  | EGTgap;								//Enable log

			FFaddr  = PC429_InsMsg(0,FFmsg, FFgap, 1<<channel,handleval);	//Ins msg
			EGTaddr = PC429_InsMsg(1,EGTmsg,EGTgap,1<<channel,handleval);	//Ins msg

			if (!(FFaddr && EGTaddr))								//Check for error
			{
				MessageBox(hWnd,"Unable to insert FF and EGT messages.","Warning!",MB_OK);
				exit(0);
			}

			activeflag |= 1<<channel;				//Mark channel as active

			if (!xmitwrap)							//If using internal wrap
			{
				xmitwrap |= 1<<channel;				//Mark channel to use internal wrap
				FFxmitaddr  = FFaddr;				//Save message address
				EGTxmitaddr = EGTaddr;				//Save message address
			}
		}

		if (PC429_IsRcv(1<<channel,handleval))			//If receive channel
		{
			FFaddr  = PC429_InsFilt(0244,SDI00 | SDI01 | SDI10 | SDI11,1<<channel,handleval);
			EGTaddr = PC429_InsFilt(0345,SDI00 | SDI01 | SDI10 | SDI11,1<<channel,handleval);

			if (!(FFaddr && EGTaddr))					//Check for error
			{
				MessageBox(hWnd,"Unable to insert FF and EGT filters.","Warning!",MB_OK);
				exit(0);
			}

			activeflag |= 1<<channel;					//Mark channel as active

			if (!rcvwrap)								//If using internal wrap
			{
				rcvwrap |= 1<<channel;					//Mark channel to use internal wrap
				FFrcvaddr  = FFaddr;					//Save message address
				EGTrcvaddr = EGTaddr;					//Save message address
			}
		}
	}

	PC429_Active(activeflag,handleval);					//Both channels active

	if (!externflag)
	{
		PC429_SelfTest(xmitwrap | rcvwrap,handleval);	//Set wrap-around self-test
	}
}

/**
*
*    The WinMain() procedure is the main Windows procedure.
*
**/

int PASCAL WinMain(HINSTANCE hInstance,HINSTANCE hPrevInstance,LPSTR lpszCmdLine,int nCmdShow)
{
	WORD wTimer;										//Timer handle
	WNDCLASS wndclass;									//Window class
	MSG msg;											//Window messages
	HWND hMainWnd;										//Main window handle

	if (hPrevInstance) exit(0);							//Can only run one instance

	wndclass.style         = CS_HREDRAW | CS_VREDRAW;
	wndclass.lpfnWndProc   = (WNDPROC)WndProc;
	wndclass.cbClsExtra    = 0;
	wndclass.cbWndExtra    = 0;
	wndclass.hInstance     = hInstance;
	wndclass.hIcon         = NULL;
	wndclass.hCursor       = LoadCursor(NULL,IDC_ARROW);
	wndclass.hbrBackground = (HBRUSH)(COLOR_WINDOW+1);
	wndclass.lpszMenuName  = NULL;
	wndclass.lpszClassName = szClassName;

	if (!RegisterClass(&wndclass)) exit(0);

	hMainWnd = CreateWindow(szClassName,
							szClassName,
							WS_OVERLAPPEDWINDOW,
							0,
							0,
							GetSystemMetrics(SM_CXSCREEN),
							(6*GetSystemMetrics(SM_CYSCREEN))/8,
							NULL,
							NULL,
							hInstance,
							NULL);

	if (!hMainWnd) exit(0);

	if (strchr(lpszCmdLine,'?') != NULL)			//Display command line options
	{
		MessageBox(hMainWnd,
			"Usage:  429DEMO <options>\n\n"
			"EXTERNAL\t\tEnables external wrap.\n"
			"NOBOARD\tOperates with no board.\n"
			"BOTH\t\tDisplays scale for both\n"
			"\t\ttransmit and receive values.\n"
			"FULL\t\tDisplays scale which\n"
			"\t\tfills screen width.\n","Command-line options.",MB_OK);
		exit(0);
	}

/**
*
*  Parse command line options.
*
**/

	strupr(lpszCmdLine);

	if (strstr(lpszCmdLine,"EXTERNAL") != NULL) externflag   = TRUE;
	if (strstr(lpszCmdLine,"NOBOARD")  != NULL) noboardflag  = TRUE;
	if (strstr(lpszCmdLine,"BOTH")     != NULL) bothvalflag  = TRUE;
	if (strstr(lpszCmdLine,"FULL")     != NULL) fullwidflag  = TRUE;

	ShowWindow(hMainWnd,nCmdShow);
	UpdateWindow(hMainWnd);

/**
*
*  Show command line options.
*
**/

	if (externflag)
	{
		MessageBox(hMainWnd,"External wrap is enabled.  An external wrap-around cable is needed.","Notice!",MB_OK);
	}

	if (noboardflag)
	{
		MessageBox(hMainWnd,"Operating with no hardware.","Notice!",MB_OK);
	}

	if (bothvalflag)
	{
		MessageBox(hMainWnd,"Displaying scales for both transmit and receive data.","Notice!",MB_OK);
	}

	if (fullwidflag)
	{
		MessageBox(hMainWnd,"Displaying scales in full width of screen.","Notice!",MB_OK);
	}

	if (!noboardflag)												//Check for card
	{
		handleval = PC429_Check(ARINC_ADDR,ARINC_PORT,2,1);			//Check for card

		if (handleval<0)
		{
			MessageBox(hMainWnd,"Unable to open the device \\\\.\\PC429Board0.","Warning!",MB_OK);
			exit(0);
		}
	}

	BoardDisplay(hMainWnd);								//Display result

	if (!noboardflag) ServiceInit(hMainWnd);			//Initialize card

	if (!noboardflag) PC429_Start(handleval);			//Start PC429 card

	wTimer = SetTimer(hMainWnd,1,5,NULL);				//Allocate timer

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

	if (!noboardflag) PC429_Stop(handleval);			//Stop card

	KillTimer(hMainWnd,1);								//Destroy timer

	return(msg.wParam);									//Return
}

/**
*
*  The following four functions display the transmitted and
*  received messages.
*
**/

VOID GraphXmitFF(HANDLE hDC,ULONG xmitmsg,ULONG xmittime,double xmitengr)
{
	LONG barx;
	LONG bary;
	ULONG mag = 3L;

	gcvt(xmitengr,10,szBuf);
	strcat(szBuf,"   ");
	TextOut(hDC,340,110,szBuf,strlen(szBuf));

	if (!bothvalflag) return;

	barx = (int)(((unsigned long)xmitengr * (unsigned long)GetSystemMetrics(SM_CXSCREEN)) / ((!fullwidflag) ? (unsigned long)FFRANGE/mag : (unsigned long)FFMAX));
	bary = 220;

	SelectObject(hDC,GetStockObject(NULL_PEN));

	SelectObject(hDC,GetStockObject(BLACK_BRUSH));
	Rectangle(hDC,0,bary,barx,bary+20);

	SelectObject(hDC,GetStockObject(WHITE_BRUSH));
	Rectangle(hDC,barx,bary,GetSystemMetrics(SM_CXSCREEN),bary+20);
}

VOID GraphXmitEGT(HANDLE hDC,ULONG xmitmsg,ULONG xmittime,double xmitengr)
{
	LONG barx;
	LONG bary;
	ULONG mag = 2L;

	gcvt(xmitengr,10,szBuf);
	strcat(szBuf,"   ");
	TextOut(hDC,340,150,szBuf,strlen(szBuf));

	if (!bothvalflag) return;

	barx = (int)(((unsigned long)xmitengr * (unsigned long)GetSystemMetrics(SM_CXSCREEN)) / ((!fullwidflag) ? (unsigned long)EGTRANGE/mag : (unsigned long)EGTMAX));
	bary = 280;

	SelectObject(hDC,GetStockObject(NULL_PEN));

	SelectObject(hDC,GetStockObject(BLACK_BRUSH));
	Rectangle(hDC,0,bary,barx,bary+20);

	SelectObject(hDC,GetStockObject(WHITE_BRUSH));
	Rectangle(hDC,barx,bary,GetSystemMetrics(SM_CXSCREEN),bary+20);
}

VOID GraphRcvFF(HANDLE hDC,ULONG rcvmsg,ULONG rcvtime,double rcvengr)
{
	LONG barx;
	LONG bary;
	ULONG mag = 3L;

	gcvt(rcvengr,10,szBuf);
	strcat(szBuf,"   ");
	TextOut(hDC,440,110,szBuf,strlen(szBuf));

	barx = (int)(((unsigned long)rcvengr * (unsigned long)GetSystemMetrics(SM_CXSCREEN)) / ((!fullwidflag) ? (unsigned long)FFRANGE/mag : (unsigned long)FFMAX));
	bary = 200;

	SelectObject(hDC,GetStockObject(NULL_PEN));

	SelectObject(hDC,GetStockObject(BLACK_BRUSH));
	Rectangle(hDC,0,bary,barx,bary+20);

	SelectObject(hDC,GetStockObject(LTGRAY_BRUSH));
	Rectangle(hDC,barx,bary,GetSystemMetrics(SM_CXSCREEN),bary+20);
}

VOID GraphRcvEGT(HANDLE hDC,ULONG rcvmsg,ULONG rcvtime,double rcvengr)
{
	LONG barx;
	LONG bary;
	ULONG mag = 2L;

	gcvt(rcvengr,10,szBuf);
	strcat(szBuf,"   ");
	TextOut(hDC,440,150,szBuf,strlen(szBuf));

	barx = (int)(((unsigned long)rcvengr * (unsigned long)GetSystemMetrics(SM_CXSCREEN)) / ((!fullwidflag) ? (unsigned long)EGTRANGE/mag : (unsigned long)EGTMAX));
	bary = 260;

	SelectObject(hDC,GetStockObject(NULL_PEN));

	SelectObject(hDC,GetStockObject(BLACK_BRUSH));
	Rectangle(hDC,0,bary,barx,bary+20);

	SelectObject(hDC,GetStockObject(LTGRAY_BRUSH));
	Rectangle(hDC,barx,bary,GetSystemMetrics(SM_CXSCREEN),bary+20);
}

/**
*
*  The ServiceUpdate() procedure updates the display.
*
**/

VOID ServiceUpdate(HWND hWnd)
{
	HANDLE hDC;

	POINT ptsh[] = {	 40, 50,						//Horizontal lines
						580, 50,
						580,100,
						 40,100,
						 40,170,
						580,170};

	POINT ptsv[] = {	 40, 50,						//Vertical lines
						 40,170,
						300,170,
						300, 50,
						500, 50,
						500,170,
						580,170,
						580, 50};

	hDC = GetDC(hWnd);									//Get window device context

	wsprintf(szBuf,"ARINC 429 DEMONSTRATION PROGRAM");
//	TextOut(hDC,(GetSystemMetrics(SM_CXSCREEN)-LOWORD(GetTextExtent(hDC,szBuf,strlen(szBuf))))/2, 5,szBuf,strlen(szBuf));

	wsprintf(szBuf,"EXAMPLE:  PROPULSION MULTIPLEXER     EQUIP ID = 33");
//	TextOut(hDC,(GetSystemMetrics(SM_CXSCREEN)-LOWORD(GetTextExtent(hDC,szBuf,strlen(szBuf))))/2,25,szBuf,strlen(szBuf));

	wsprintf(szBuf,"LABEL (O)");		TextOut(hDC, 50, 80,szBuf,strlen(szBuf));
	wsprintf(szBuf,"DESCRIPTION");		TextOut(hDC,140, 80,szBuf,strlen(szBuf));
	wsprintf(szBuf,"TRANSMIT");			TextOut(hDC,320, 60,szBuf,strlen(szBuf));
	wsprintf(szBuf,"VALUE");			TextOut(hDC,330, 80,szBuf,strlen(szBuf));
	wsprintf(szBuf,"RECEIVE");			TextOut(hDC,420, 60,szBuf,strlen(szBuf));
	wsprintf(szBuf,"VALUE");			TextOut(hDC,430, 80,szBuf,strlen(szBuf));
	wsprintf(szBuf,"UNITS");			TextOut(hDC,510, 80,szBuf,strlen(szBuf));
	wsprintf(szBuf,"244");				TextOut(hDC, 70,110,szBuf,strlen(szBuf));
	wsprintf(szBuf,"FUEL FLOW");		TextOut(hDC,140,110,szBuf,strlen(szBuf));
	wsprintf(szBuf,"345");				TextOut(hDC, 70,150,szBuf,strlen(szBuf));
	wsprintf(szBuf,"EXHAUST GAS TEMP");	TextOut(hDC,140,150,szBuf,strlen(szBuf));
	wsprintf(szBuf,"LBS/HR");			TextOut(hDC,510,110,szBuf,strlen(szBuf));
	wsprintf(szBuf,"Deg C");			TextOut(hDC,510,150,szBuf,strlen(szBuf));
	wsprintf(szBuf,"FUEL FLOW");		TextOut(hDC,  5,185,szBuf,strlen(szBuf));
	wsprintf(szBuf,"EXHAUST GAS TEMP");	TextOut(hDC,  5,245,szBuf,strlen(szBuf));

	Polyline(hDC,ptsh,6);				//Display lines
	Polyline(hDC,ptsv,8);				//Display lines

	ReleaseDC(hWnd,hDC);
}

/**
*
*  The ServiceXmit() procedure increments and decrements the
*  transmitted message data values.
*
**/

VOID ServiceXmit(HANDLE hDC)
{
	ULONG period = 100L;					//Number of counts before changing direction
	static BOOLEAN dirflag = TRUE;			//Current direction
	static ULONG count = 0L;				//Current count

	double FFstep  = (double)80.1;			//Step value
	double EGTstep = (double)10.1;			//Step value

	if (++count > period)					//If count overflows
	{
		dirflag = !dirflag;					//Change direction
		count = 0L;							//Clear counter
	}

	if ( dirflag && FFxmitengr < FFMAX) FFxmitengr += FFstep;	//Increment FF
	if (!dirflag && FFxmitengr > FFMIN) FFxmitengr -= FFstep;	//Decrement FF

	if (FFxmitengr > FFHIGH && EGTxmitengr < EGTMAX) EGTxmitengr += EGTstep;	//Increment EGT
	if (FFxmitengr < FFLOW  && EGTxmitengr > EGTMIN) EGTxmitengr -= EGTstep;	//Decrement EGT
}

/**
*
*  The ServiceBackground() procedure handles the timer calls.
*
**/

VOID ServiceBackground(HWND hWnd)
{
	ULONG FFmsg;
	ULONG EGTmsg;
	ULONG FFtime;
	ULONG EGTtime;
	double FFengr;
	double EGTengr;
	HANDLE hDC;

	hDC = GetDC(hWnd);									//Get window device context

	ServiceXmit(hDC);									//Advance values

/**
*
*  The following lines read the transmit messages from the PC429 board
*  and stuffs the new data values into the message.  The message is
*  then written back to the board.  Note that the procedure
*  PC429_PutBNRVal() takes a string and performs the necessary
*  conversion.
*
**/

	gcvt(FFxmitengr,10,szBuf);											//Convert double to string
	FFmsg = (!noboardflag) ? PC429_RdMsg(FFxmitaddr,handleval) : 0;		//Read xmit message from board
	FFmsg = PC429_PutBNRVal(szBuf,FFmsg,FFSIG,FFRESOL);					//Stuff new data value
	if (!noboardflag) PC429_WrMsg(FFxmitaddr,FFmsg,handleval);			//Write xmit message back to board

	gcvt(EGTxmitengr,10,szBuf);											//Convert double to string
	EGTmsg = (!noboardflag) ? PC429_RdMsg(EGTxmitaddr,handleval) : 0;	//Read xmit message from board
	EGTmsg = PC429_PutBNRVal(szBuf,EGTmsg,EGTSIG,EGTRESOL);				//Stuff new data value
	if (!noboardflag) PC429_WrMsg(EGTxmitaddr,EGTmsg,handleval);		//Write xmit message back to board

/**
*
*  The following lines read the received messages, extract the
*  BNR value and display the value.
*
**/

	if (!noboardflag) FFmsg  = PC429_RdMsg(FFrcvaddr,handleval);	//Read rcv message from board
	if (!noboardflag) FFtime = PC429_RdTime(FFrcvaddr,handleval);	//Read rcv time from board
	PC429_GetBNRVal(szBuf,FFmsg,FFSIG,FFRESOL);						//Extract BNR value
	FFengr = strtod(szBuf,NULL);									//Convert BNR string to double
	GraphRcvFF(hDC,FFmsg,FFtime,FFengr);							//Display double value

	if (!noboardflag) EGTmsg  = PC429_RdMsg(EGTrcvaddr,handleval);	//Read rcv message from board
	if (!noboardflag) EGTtime = PC429_RdTime(EGTrcvaddr,handleval);	//Read rcv time from board
	PC429_GetBNRVal(szBuf,EGTmsg,EGTSIG,EGTRESOL);					//Extract BNR value
	EGTengr = strtod(szBuf,NULL);									//Convert BNR string to double
	GraphRcvEGT(hDC,EGTmsg,EGTtime,EGTengr);						//Display double value

/**
*
*  The following lines read the transmit messages, extract the
*  BNR value and display the value.
*
**/

	if (!noboardflag) FFmsg  = PC429_RdMsg(FFxmitaddr,handleval);	//Read xmit message from board
	if (!noboardflag) FFtime = PC429_RdTime(FFxmitaddr,handleval);	//Read xmit time from board
	PC429_GetBNRVal(szBuf,FFmsg,FFSIG,FFRESOL);						//Extract BNR value
	FFengr = strtod(szBuf,NULL);									//Convert BNR string to double
	GraphXmitFF(hDC,FFmsg,FFtime,FFengr);							//Display double value

	if (!noboardflag) EGTmsg  = PC429_RdMsg(EGTxmitaddr,handleval);	//Read xmit message from board
	if (!noboardflag) EGTtime = PC429_RdTime(EGTxmitaddr,handleval);//Read xmit time from board
	PC429_GetBNRVal(szBuf,EGTmsg,EGTSIG,EGTRESOL);					//Extract BNR value
	EGTengr = strtod(szBuf,NULL);									//Convert BNR string to double
	GraphXmitEGT(hDC,EGTmsg,EGTtime,EGTengr);						//Display double value

	ReleaseDC(hWnd,hDC);
}

/**
*
*  The following procedure handles the Windows messages.
*
**/

LRESULT CALLBACK WndProc(HWND hWnd,UINT iMessage,WPARAM wParam,LPARAM lParam)
{
	switch (iMessage)
	{
		case WM_TIMER:
			ServiceBackground(hWnd);
			break;

		case WM_CREATE:
			break;

		case WM_PAINT:
			ServiceUpdate(hWnd);
			return(DefWindowProc(hWnd,iMessage,wParam,lParam));

		case WM_DESTROY:
			PostQuitMessage(0);
			break;

		default:
			return(DefWindowProc(hWnd,iMessage,wParam,lParam));
	}

	return(0);
}
