/**
*
*  CM1553-1 WIN32 DRIVER Version 1.2  (04/09/1999)
*  Copyright (c) 1997,1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   C11W32.H -- Visual C++ WIN32 CM1553-1 Driver
*                      Include Header File.
*
**/

/**
*
*    This file defines the procedures provided by the Visual
*    C++ WIN32 Driver Library for the CM1553-3.  Applications
*    using the CM1553-3 Driver Library must incorporate this
*    include file using the preprocessor directive #include. 
*    If this file is in the current working directory, the
*    form would be:
*
*    #include "C11W32.H"
*
*    Refer to the Visual C++ manual for more information on
*    header files.
*
**/

/**
*
*  Conditional block to prevent multiple defines.
*
**/

#ifndef __C11W32_H__
#define __C11W32_H__

/**
*
*  Typedefs used by the CM1553-1 Driver.
*
**/

#ifndef C11W32API
#ifdef __BORLANDC__
#define C11W32API
#else
#define C11W32API __declspec(dllimport)
#endif
#endif

#ifndef VOID
typedef void VOID;
#endif

#ifndef LPVOID
typedef void * LPVOID;
#endif

#ifndef INT
typedef int INT;
#endif

#ifndef LPINT
typedef int * LPINT;
#endif

#ifndef BYTE
typedef unsigned char BYTE;
#endif

#ifndef LPBYTE
typedef unsigned char * LPBYTE;
#endif

#ifndef CHAR
typedef char CHAR;
#endif

#ifndef USHORT
typedef unsigned short USHORT;
#endif

#ifndef LPUSHORT
typedef unsigned short * LPUSHORT;
#endif

#ifndef ULONG
typedef unsigned long ULONG;
#endif

#ifndef LPULONG
typedef unsigned long * LPULONG;
#endif

#ifndef MSGADDR
typedef unsigned long MSGADDR;
#endif

#ifndef LPMSGADDR
typedef unsigned long * LPMSGADDR;
#endif

#ifndef LPCSTR
typedef const char * LPCSTR;
#endif

#ifndef LPSTR
typedef char * LPSTR;
#endif

#ifndef BOOL
typedef int BOOL;
#endif

#ifndef HCARD
typedef void* HCARD;
#endif

#ifndef ERRVAL
typedef int ERRVAL;
#endif

#ifndef SCHNDX
typedef int SCHNDX;
#endif

/**
*
*  "C" block if compiling a C++ file.
*
**/

#ifdef __cplusplus
extern "C" {
#endif

/**
*
*  CM1553-1 Driver functions.
*
**/

C11W32API INT __stdcall C11_BCBranchEnd(HCARD handleval);
C11W32API USHORT __stdcall C11_BCCallFrame(INT index,HCARD handleval);
C11W32API INT __stdcall C11_BCCheckMsg(INT index,HCARD handleval);
C11W32API INT __stdcall C11_BCConfig(ULONG configflags,HCARD handleval);
C11W32API INT __stdcall C11_BCConfigEx(ULONG configflags,INT cmdcountval,INT cyccountval,HCARD handleval);
C11W32API INT __stdcall C11_BCDoAgain(INT index,HCARD handleval);
C11W32API INT __stdcall C11_BCDoGap(INT gapval,HCARD handleval);
C11W32API INT __stdcall C11_BCDoGoto(INT destindex,HCARD handleval);
C11W32API INT __stdcall C11_BCDoHalt(HCARD handleval);
C11W32API INT __stdcall C11_BCDoInt(HCARD handleval);
C11W32API INT __stdcall C11_BCDoMsg(BOOL busab,USHORT cwdval,LPUSHORT datavals,HCARD handleval);
C11W32API INT __stdcall C11_BCDoResv(HCARD handleval);
C11W32API INT __stdcall C11_BCDoRTRT(BOOL busab,USHORT cwd1val,USHORT cwd2val,HCARD handleval);
C11W32API INT __stdcall C11_BCDoSelfTest(HCARD handleval);
C11W32API INT __stdcall C11_BCFrameEnd(HCARD handleval);
C11W32API INT __stdcall C11_BCFrameStart(INT timeval,HCARD handleval);
C11W32API INT __stdcall C11_BCMsgBranch(INT index,INT destindex,INT condition,HCARD handleval);
C11W32API INT __stdcall C11_BCMsgRetry(INT index,INT retries,INT condition,HCARD handleval);
C11W32API USHORT __stdcall C11_BCRdData(INT index,LPUSHORT data,USHORT count,HCARD handleval);
C11W32API USHORT __stdcall C11_BCRdSWD1(INT index,HCARD handleval);
C11W32API USHORT __stdcall C11_BCRdSWD2(INT index,HCARD handleval);
C11W32API USHORT __stdcall C11_BCWrData(INT index,LPUSHORT data,USHORT count,HCARD handleval);
C11W32API VOID __stdcall C11_CloseCard(HCARD handleval);
C11W32API USHORT __stdcall C11_GetBitFld(USHORT oldvalue,INT startbit,INT endbit);
C11W32API INT __stdcall C11_INTInstall(LPVOID hEvent,HCARD handleval);
C11W32API INT __stdcall C11_INTRd(INT index,LPUSHORT type,LPUSHORT event,HCARD handleval);
C11W32API INT __stdcall C11_INTUninstall(LPVOID hEvent,HCARD handleval);
C11W32API VOID __stdcall C11_INTUnmask(USHORT maskval,HCARD handleval);
C11W32API INT __stdcall C11_MONConfig(ULONG configflags,USHORT moncount,HCARD handleval);
C11W32API INT __stdcall C11_MONCount(HCARD handleval);
C11W32API USHORT __stdcall C11_MONRd(USHORT index,LPUSHORT blockinfo,LPUSHORT datawords,HCARD handleval);
C11W32API VOID __stdcall C11_MONTermAddr(USHORT termaddr,INT enableflag,HCARD handleval);
C11W32API HCARD __stdcall C11_OpenCard(INT card_number);
C11W32API USHORT __stdcall C11_PackCWD(INT TAval,INT TRval,INT SAval,INT WCval);
C11W32API USHORT __stdcall C11_PeekMem(USHORT WordOffset,HCARD handleval);
C11W32API VOID __stdcall C11_PokeMem(USHORT Data,USHORT WordOffset,HCARD handleval);
C11W32API USHORT __stdcall C11_PutBitFld(USHORT oldvalue,USHORT newfld,INT startbit,INT endbit);
C11W32API USHORT __stdcall C11_RdPort(USHORT Register,HCARD handleval);
C11W32API VOID __stdcall C11_Reset(HCARD handleval);
C11W32API VOID __stdcall C11_Restart(HCARD handleval);
C11W32API USHORT __stdcall C11_RTAccessed(USHORT cwd,HCARD handleval);
C11W32API INT __stdcall C11_RTConfig(ULONG configflags,USHORT rtaddr,HCARD handleval);
C11W32API INT __stdcall C11_RTCountList(USHORT cwd,HCARD handleval);
C11W32API VOID __stdcall C11_RTIllegal(USHORT cwd,HCARD handleval);
C11W32API USHORT __stdcall C11_RTInitList(USHORT cwd,INT count,HCARD handleval);
C11W32API INT __stdcall C11_RTInt(USHORT cwd,USHORT value,HCARD handleval);
C11W32API INT __stdcall C11_RTMONConfig(ULONG configflags,USHORT rtaddr,USHORT moncount,HCARD handleval);
C11W32API USHORT __stdcall C11_RTRdData(USHORT cwd,LPUSHORT data,HCARD handleval);
C11W32API USHORT __stdcall C11_RTRdDataEx(USHORT cwd,LPUSHORT infodata,HCARD handleval);
C11W32API USHORT __stdcall C11_RTRdList(USHORT cwd,USHORT index,LPUSHORT infodata,HCARD handleval);
C11W32API USHORT __stdcall C11_RTRstList(USHORT cwd,HCARD handleval);
C11W32API USHORT __stdcall C11_RTWrData(USHORT cwd,LPUSHORT data,HCARD handleval);
C11W32API VOID __stdcall C11_RTWrSWD(USHORT statusflags,HCARD handleval);
C11W32API USHORT __stdcall C11_SelfTest(HCARD handleval);
C11W32API BOOL __stdcall C11_Start(HCARD handleval);
C11W32API BOOL __stdcall C11_Stop(HCARD handleval);
C11W32API INT __stdcall C11_TransmitMsg(BOOL busab,USHORT cwd,LPUSHORT dataptr,LPUSHORT swd,HCARD handleval);
C11W32API INT __stdcall C11_TransmitRTRT(BOOL busab,USHORT cwd1,USHORT cwd2,LPUSHORT dataptr,LPUSHORT swd1,LPUSHORT swd2,HCARD handleval);
C11W32API VOID __stdcall C11_UnpackCWD(USHORT CWDval,LPINT TAval,LPINT TRval,LPINT SAval,LPINT WCval);
C11W32API VOID __stdcall C11_WrPort(USHORT Data,USHORT Register,HCARD handleval);

/**
*
*  Internal functions used by the CM1553-1 Driver.
*
**/

C11W32API USHORT __stdcall C11_BCAddrData(INT index,HCARD handleval);
C11W32API USHORT __stdcall C11_BCBlockAddr(INT index,HCARD handleval);
C11W32API VOID __stdcall C11_BCBlockClear(HCARD handleval);
C11W32API USHORT __stdcall C11_BCBlockCount(HCARD handleval);
C11W32API USHORT __stdcall C11_BCBlockCtrl(INT index,HCARD handleval);
C11W32API VOID __stdcall C11_BCBlockInit(LPUSHORT block,USHORT opcode);
C11W32API INT __stdcall C11_BCBlockInsert(LPUSHORT block,HCARD handleval);
C11W32API USHORT __stdcall C11_BCBlockRead(INT index,LPUSHORT block,HCARD handleval);
C11W32API USHORT __stdcall C11_BCBlockWrite(INT index,LPUSHORT block,HCARD handleval);
C11W32API USHORT __stdcall C11_BCCycleAddr(INT index,HCARD handleval);
C11W32API VOID __stdcall C11_BCCycleClear(HCARD handleval);
C11W32API USHORT __stdcall C11_BCCycleInsert(LPUSHORT cycle,HCARD handleval);
C11W32API VOID __stdcall C11_BCCycleRestart(HCARD handleval);
C11W32API USHORT __stdcall C11_BCCycleWrite(INT index,LPUSHORT cycle,HCARD handleval);
C11W32API VOID __stdcall C11_ClrAllILLEGAL(HCARD handleval);
C11W32API VOID __stdcall C11_ClrILLEGAL(INT subaddr,BOOL trbit,BOOL mcflag,BOOL bcastflag,HCARD handleval);
C11W32API ULONG __stdcall C11_Div(ULONG diva,ULONG divb);
C11W32API VOID __stdcall C11_FillMem(USHORT Data,USHORT WordOffset,INT iWordCount,HCARD handleval);
C11W32API USHORT __stdcall C11_GetBCAST(HCARD handleval);
C11W32API USHORT __stdcall C11_GetBUF(HCARD handleval);
C11W32API USHORT __stdcall C11_GetCHAN(HCARD handleval);
C11W32API USHORT __stdcall C11_GetCIRCLE(HCARD handleval);
C11W32API USHORT __stdcall C11_GetDYNBC(HCARD handleval);
C11W32API USHORT __stdcall C11_GetEXT(HCARD handleval);
C11W32API USHORT __stdcall C11_GetHigh(ULONG val);
C11W32API USHORT __stdcall C11_GetILLEGAL(INT subaddr,BOOL trbit,BOOL mcflag,BOOL bcastflag,HCARD handleval);
C11W32API USHORT __stdcall C11_GetINT(HCARD handleval);
C11W32API USHORT __stdcall C11_GetIntLog(HCARD handleval);
C11W32API USHORT __stdcall C11_GetINTMASK(HCARD handleval);
C11W32API USHORT __stdcall C11_GetLow(ULONG val);
C11W32API USHORT __stdcall C11_GetMODE(HCARD handleval);
C11W32API USHORT __stdcall C11_GetMonCtrl(HCARD handleval);
C11W32API VOID __stdcall C11_GetMonFilt(LPUSHORT valuel,LPUSHORT valueh,HCARD handleval);
C11W32API USHORT __stdcall C11_GetPP(HCARD handleval);
C11W32API USHORT __stdcall C11_GetRTADDR(HCARD handleval);
C11W32API USHORT __stdcall C11_GetStatus(HCARD handleval);
C11W32API USHORT __stdcall C11_GetSTD(HCARD handleval);
C11W32API USHORT __stdcall C11_GetTIMEOUT(HCARD handleval);
C11W32API USHORT __stdcall C11_GetXMTSW(HCARD handleval);
C11W32API USHORT __stdcall C11_HeapAlloc(USHORT wordcount,HCARD handleval);
C11W32API USHORT __stdcall C11_HeapAvail(HCARD handleval);
C11W32API VOID __stdcall C11_HeapClear(HCARD handleval);
C11W32API USHORT __stdcall C11_HeapRdHead(HCARD handleval);
C11W32API VOID __stdcall C11_HeapWrHead(USHORT value,HCARD handleval);
C11W32API INT __stdcall C11_INTDisable(HCARD handleval);
C11W32API INT __stdcall C11_INTEnable(HCARD handleval);
C11W32API USHORT __stdcall C11_INTRdPend(HCARD handleval);
C11W32API INT __stdcall C11_INTRdPoll(HCARD handleval);
C11W32API VOID __stdcall C11_INTReset(HCARD handleval);
C11W32API USHORT __stdcall C11_IsBC(HCARD handleval);
C11W32API USHORT __stdcall C11_IsMON(HCARD handleval);
C11W32API USHORT __stdcall C11_IsRT(HCARD handleval);
C11W32API USHORT __stdcall C11_IsRTMON(HCARD handleval);
C11W32API ULONG __stdcall C11_MakeLong(USHORT valh,USHORT vall);
C11W32API ULONG __stdcall C11_Mask(ULONG dataval,USHORT cntval);
C11W32API ULONG __stdcall C11_Mod(ULONG moda,ULONG modb);
C11W32API VOID __stdcall C11_MONAll(HCARD handleval);
C11W32API USHORT __stdcall C11_MONBlockBase(HCARD handleval);
C11W32API USHORT __stdcall C11_MONDataBase(HCARD handleval);
C11W32API VOID __stdcall C11_MONNone(HCARD handleval);
C11W32API ULONG __stdcall C11_Mul(ULONG mula,ULONG mulb);
C11W32API BOOL __stdcall C11_OkayHandle(HCARD handleval);
C11W32API HCARD __stdcall C11_OpenDevice(LPVOID device_id);
C11W32API USHORT __stdcall C11_PackRTCWD(INT subaddr,BOOL trbit,BOOL mcflag,BOOL bcastflag,INT count);
C11W32API BYTE __stdcall C11_PeekAttr(USHORT WordOffset,HCARD handleval);
C11W32API VOID __stdcall C11_PeekStrAttr(LPUSHORT pwBuffer,USHORT WordOffset,INT iWordCount,HCARD handleval);
C11W32API VOID __stdcall C11_PeekStrMem(LPUSHORT pwBuffer,USHORT WordOffset,INT iWordCount,HCARD handleval);
C11W32API VOID __stdcall C11_PokeAttr(BYTE Data,USHORT WordOffset,HCARD handleval);
C11W32API VOID __stdcall C11_PokeStrAttr(LPUSHORT pwBuffer,USHORT WordOffset,INT iWordCount,HCARD handleval);
C11W32API VOID __stdcall C11_PokeStrMem(LPUSHORT pwBuffer,USHORT WordOffset,INT iWordCount,HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMChksW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMClose(HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMDisable(HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMEnable(HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMFlush(HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMInfoRd(LPBYTE buf,HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMInfoWr(LPBYTE buf,HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMOpen(HCARD handleval);
C11W32API VOID __stdcall C11_ROMProg(USHORT enableflag,LPUSHORT dataptr,USHORT cntval,ULONG addrval,HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMRdsW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMWrsW(USHORT enableflag,LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
C11W32API ERRVAL __stdcall C11_ROMWrW(USHORT value,USHORT addrval,HCARD handleval);
C11W32API USHORT __stdcall C11_RTAddrData(USHORT type,USHORT cwd,HCARD handleval);
C11W32API USHORT __stdcall C11_RTAddrDesc(USHORT type,USHORT cwd,HCARD handleval);
C11W32API BOOL __stdcall C11_RTAddrParity(INT rtaddr);
C11W32API VOID __stdcall C11_RTInitData(USHORT scheme,HCARD handleval);
C11W32API USHORT __stdcall C11_RTPokeData(USHORT cwd,LPUSHORT data,HCARD handleval);
C11W32API USHORT __stdcall C11_RTRdDesc(USHORT cwd,LPUSHORT desc,HCARD handleval);
C11W32API USHORT __stdcall C11_RTWrDesc(USHORT cwd,LPUSHORT desc,HCARD handleval);
C11W32API VOID __stdcall C11_SetAllILLEGAL(HCARD handleval);
C11W32API VOID __stdcall C11_SetBCAST(USHORT enableval,HCARD handleval);
C11W32API VOID __stdcall C11_SetBUF(USHORT enableval,HCARD handleval);
C11W32API VOID __stdcall C11_SetCHAN(USHORT chanval,HCARD handleval);
C11W32API VOID __stdcall C11_SetCIRCLE(USHORT circleval,HCARD handleval);
C11W32API VOID __stdcall C11_SetDYNBC(USHORT enableval,HCARD handleval);
C11W32API VOID __stdcall C11_SetEXT(USHORT enableval,HCARD handleval);
C11W32API VOID __stdcall C11_SetILLEGAL(INT subaddr,BOOL trbit,BOOL mcflag,BOOL bcastflag,HCARD handleval);
C11W32API VOID __stdcall C11_SetINT(USHORT enableval,HCARD handleval);
C11W32API VOID __stdcall C11_SetIntLog(USHORT addressval,HCARD handleval);
C11W32API VOID __stdcall C11_SetINTMASK(USHORT maskval,HCARD handleval);
C11W32API INT __stdcall C11_SetLog(USHORT enableval,HCARD handleval);
C11W32API VOID __stdcall C11_SetMODE(USHORT modeval,HCARD handleval);
C11W32API VOID __stdcall C11_SetMonCtrl(USHORT enableval,HCARD handleval);
C11W32API VOID __stdcall C11_SetMonFilt(USHORT valuel,USHORT valueh,HCARD handleval);
C11W32API VOID __stdcall C11_SetPP(USHORT enableval,HCARD handleval);
C11W32API VOID __stdcall C11_SetRTADDR(USHORT rtaddr,HCARD handleval);
C11W32API VOID __stdcall C11_SetStatus(USHORT flags,USHORT immclear,HCARD handleval);
C11W32API VOID __stdcall C11_SetSTD(USHORT enableval,HCARD handleval);
C11W32API VOID __stdcall C11_SetTIMEOUT(USHORT enableval,HCARD handleval);
C11W32API VOID __stdcall C11_SetXMTSW(USHORT enableval,HCARD handleval);
C11W32API ULONG __stdcall C11_Shl(ULONG dataval,USHORT cntval);
C11W32API ULONG __stdcall C11_Shr(ULONG dataval,USHORT cntval);
C11W32API USHORT __stdcall C11_StatRead(HCARD handleval);
C11W32API USHORT __stdcall C11_TTRead(HCARD handleval);
C11W32API VOID __stdcall C11_TTSet(USHORT timetagval,HCARD handleval);
C11W32API VOID __stdcall C11_TTZero(HCARD handleval);
C11W32API VOID __stdcall C11_UnpackRTCWD(USHORT cwd,LPINT subaddr,LPINT trbit,LPINT mcflag,LPINT bcastflag,LPINT count);
C11W32API VOID __stdcall C11_WipeMem(HCARD handleval);

#ifdef __cplusplus
}
#endif

#define CONFIG_DEFAULT    0x00000000L	//Select all default settings (default)
#define CONFIG_INTCLK     0x00000000L	//Use internal clock (default)
#define CONFIG_EXTCLK     0x00000001L	//Use external clock
#define CONFIG_NOBUF      0x00000000L	//Do not use buffer mode (default)
#define CONFIG_BUF        0x00000002L	//Enable use of buffer mode
#define CONFIG_NOBCAST    0x00000000L	//Do not respond to broadcast messages (default)
#define CONFIG_BCAST      0x00000004L	//Respond to broadcast messages
#define CONFIG_STDB       0x00000000L	//Use MIL-STD-1553B standard (default)
#define CONFIG_STDA       0x00000008L	//Use MIL-STD-1553A standard
#define CONFIG_NODYNBC    0x00000000L	//Do not respond to dynamic BC mode code (default)
#define CONFIG_DYNBC      0x00000010L	//Respond to dynamic BC mode code
#define CONFIG_NOALTRETRY 0x00000000L	//Retries are not on alternate busses (BC) (default)
#define CONFIG_ALTRETRY   0x00000020L	//Retries on alternate busses (BC)
#define CONFIG_NOXMITSW   0x00000000L	//Do not respond to xmit last status mode code (default)
#define CONFIG_XMITSW     0x00000040L	//Respond to transmit last status mode code
#define CONFIG_ALLSUBADDR 0x00000000L	//Respond to all subaddresses (default)
#define CONFIG_NOSUBADDR  0x00000080L	//Do not respond to any subaddresses
#define CONFIG_WIPE       0x00000000L	//Fills memory with zeros (default)
#define CONFIG_NOWIPE     0x00000100L	//Does not fill memory with zeros
#define CONFIG_INIT       0x00000000L	//Initialize mode (default)
#define CONFIG_NOINIT     0x00000200L	//Does not initialize mode
#define CONFIG_LOGLIST    0x00000000L	//Enable log list (default)
#define CONFIG_NOLOGLIST  0x00000400L	//Disable log list
#define CONFIG_NONOTICE2  0x00000000L	//Enable log list (default)
#define CONFIG_NOTICE2    0x00000800L	//Disable log list
#define CONFIG_MONALL     0x00000000L	//Enable monitoring of all RTs (default)
#define CONFIG_MONNONE    0x00001000L	//Disable monitoring of all RTs
#define CONFIG_REGTIMEOUT 0x00000000L	//14us timeout (BC,MON) (default)
#define CONFIG_EXTTIMEOUT 0x00002000L	//30us extended timeout (BC,MON)
#define CONFIG_CHANAB     0x00000000L	//Respond to both channels (default)
#define CONFIG_CHANA      0x00010000L	//Respond to channel A
#define CONFIG_CHANB      0x00020000L	//Respond to channel B
#define CONFIG_SINGLEBUF  0x00000000L	//Use single buffer (RT) (default)
#define CONFIG_PINGPONG   0x00100000L	//Use ping-pong mode (RT)
#define CONFIG_CIRC1BUF   0x00200000L	//Use circular #1 buffers (RT)
#define CONFIG_CIRC2BUF   0x00300000L	//Use circular #2 buffers (RT)

#define SWD_IMCLR 0x8000				//Immediate clear
#define SWD_BIT10 0x0200				//Status word bit 10
#define SWD_INS   0x0200				//Instrumentation bit
#define SWD_BIT11 0x0100				//Status word bit 11
#define SWD_SRQ   0x0100				//Service request bit
#define SWD_BIT12 0x0080				//Status word bit 12
#define SWD_BIT13 0x0040				//Status word bit 13
#define SWD_BIT14 0x0020				//Status word bit 14
#define SWD_BIT15 0x0010				//Status word bit 15
#define SWD_BIT16 0x0008				//Status word bit 16
#define SWD_BUSY  0x0008				//Busy bit
#define SWD_BIT17 0x0004				//Status word bit 17
#define SWD_SSYSF 0x0004				//Subsystem flag bit
#define SWD_BIT18 0x0002				//Status word bit 18
#define SWD_BIT19 0x0001				//Status word bit 19
#define SWD_TF    0x0001				//Terminal flag

#define INT_DMAF     0x8000				//BC,RT,MON
#define INT_WRAPF    0x4000				//BC,RT
#define INT_TAPF     0x2000				//RT
#define INT_BITF     0x1000				//BC,RT,MON
#define INT_MERR     0x0800				//BC,RT,MON
#define INT_SUBAD    0x0400				//RT
#define INT_BDRCV    0x0200				//RT
#define INT_IXEQ0    0x0100				//RT
#define INT_ILCMD    0x0080				//RT
#define INT_EOL      0x0020				//BC
#define INT_ILLCMD   0x0010				//BC
#define INT_ILLOP    0x0008				//BC
#define INT_RTF      0x0004				//BC
#define INT_CBA      0x0002				//BC
#define INT_MBC      0x0001				//MON
#define INT_NONE     0x0000				//No interrupts

#define REG_INT  0x0000					//Interrupt register
#define REG_PAGE 0x0001					//Page register
#define REG_EXT  0x0002					//External register
#define REG_RESV 0x0003					//Reserved register
#define REG_INTC 0x0004					//Interrupt clear register
#define REG_RST  0x0005					//Reset register
#define REG_ERR  0x0006					//Error register
#define REG_PWE  0x0007					//Prom write enable register

#define BUSA 0							//Selects bus A
#define BUSB 1							//Selects bus B

#define MONNO  0						//Disables monitoring of a terminal address
#define MONYES 1						//Enables monitoring of a terminal address

#define COND_NONE    0x0000				//No condition
#define COND_FAIL    0x2000				//Condition when all retries have failed
#define COND_UNCOND  0x4000				//Unconditional
#define COND_SRQ     0x0002				//Condition on Service Request bit set in status word
#define COND_INS     0x0004				//Condition on Instrumentation bit set in status word
#define COND_SSFAIL  0x0008				//Condition on Subsystem Fail bit set in status word
#define COND_TF      0x0010				//Condition on Terminal Flag bit set in status word
#define COND_BUSY    0x0020				//Condition on Busy bit set in status word
#define COND_ME      0x0040				//Condition on Message Error bit set in status word
#define COND_RESPERR 0x0080				//Condition on response error
#define COND_MASK    0x00FE

#define SUMMIT_CTRL     0x0000			//Control register
#define SUMMIT_OPSTAT   0x0001			//Operational status
#define SUMMIT_CURRCMD  0x0002			//Current Command
#define SUMMIT_INTMASK  0x0003			//Interrupt Mask
#define SUMMIT_INTPEND  0x0004			//Interrupt Pending
#define SUMMIT_INTLOG   0x0005			//Interrupt Log
#define SUMMIT_BITWORD  0x0006			//BIT Word
#define SUMMIT_TTMFT    0x0007			//Time-Tag/Minor Frame Timer
#define SUMMIT_RTDACBA  0x0008			//RT Descriptor/Command Block Pointer
#define SUMMIT_RTSTATUS 0x0009			//RT Status Word
#define SUMMIT_CBC      0x000A			//Command Block Init Count
#define SUMMIT_MBA      0x000B			//Monitor Block
#define SUMMIT_MDA      0x000C			//Monitor Data
#define SUMMIT_MBC      0x000D			//Monitor Block Count
#define SUMMIT_MFH      0x000E			//Monitor Filter High
#define SUMMIT_MFL      0x000F			//Monitor Filter Low

#define ERR_NONE       0				//No error
#define ERR_UNKNOWN	  -1				//An unexpected error occurred
#define ERR_NOCS      -10				//Card Services is not present
#define ERR_NOSOCKET  -11				//The specified socket is not present
#define ERR_NOCARD    -12				//Unable to find a CM1553-1 card in the specified socket
#define ERR_NOTSR     -13				//Unable to find the CM1553-1 memory resident driver
#define ERR_CLIENT    -14				//Unable to install a local client driver
#define ERR_CS        -15				//An error was returned by Card Services
#define ERR_WIN		  -16				//Card Services could not configure the memory window, I/O window, or IRQ steering
#define ERR_SEL	  	  -17				//Unable to allocate a memory selector
#define ERR_BADHANDLE -20				//A bad handle was specified
#define ERR_COUNT     -21				//An invalid count was specified
#define ERR_ALLOC     -22				//Not enough memory to allocate
#define ERR_INDEX     -23				//The command block index was invalid or the schedule is full
#define ERR_RETRY     -31				//The retry parameter is out of range
#define ERR_COND      -32				//An invalid condition condition parameter was specified
#define ERR_BADMSG    -33				//The specified command block is not a message block
#define ERR_RTRT      -34				//The command words are not a valid RT-RT message
#define ERR_RESPONSE  -35				//A bad response or no response was received from an RT
#define ERR_FNAME     -40				//Bad filenames were specified
#define ERR_FRDWR     -41				//There was an error reading or writing the HEX file
#define ERR_HEX       -42				//There was a bad hex character in the HEX file
#define ERR_CRC       -43				//There was a bad checksum in the HEX file
#define ERR_TYPE      -44				//There was a bad type value in the HEX file
#define ERR_CISRANGE  -90				//The specified address is outside of the CS address range
#define ERR_CISNONE   -91				//The CIS is not visible
#define ERR_CISENB    -92				//The PWE register cannot be enabled
#define ERR_CISMAGIC  -93				//Unable to write to the PWE register
#define ERR_VXD       -100				//Error returned from VXD

#endif
