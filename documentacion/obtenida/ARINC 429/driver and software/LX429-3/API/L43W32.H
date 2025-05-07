/**
*
*  LP429-3 and LC429-3 WIN32 DRIVER  Version 2.0.1  (05/27/2009)
*  Copyright (c) 1998-2009
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   L43W32.H -- Visual C++ 32-bit
*                      L43 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for the L43.  Applications
*  using the L43 Driver Library must incorporate this
*  include file using the preprocessor directive #include. 
*  If this file is in the current working directory, the form
*  would be:
*
*  #include "L43W32.H"
*
*  Refer to the Visual C++ manual for more information on
*  header files.
*
**/

/**
*
*  Conditional block to prevent multiple defines.
*
**/

#ifndef __L43W32_H
#define __L43W32_H

/**
*
*  Typedefs used by the L43 Driver.
*
**/

#ifndef L43W32API
#ifdef __BORLANDC__
#define L43W32API
#else
#define L43W32API __declspec(dllimport)
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

#ifndef BASEADDR
typedef unsigned long BASEADDR;
#endif

#ifndef SUBFRMADDR
typedef unsigned long SUBFRMADDR;
#endif

#ifndef SUPERFRMADDR
typedef unsigned long SUPERFRMADDR;
#endif

#ifndef LISTADDR
typedef unsigned long LISTADDR;
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
typedef int HCARD;
#endif

#ifndef ERRVAL
typedef int ERRVAL;
#endif

#ifndef SCHNDX
typedef int SCHNDX;
#endif

/**
*
*  Structs used by the L43 Driver.
*
**/

#ifndef MSGSTRUCT

typedef struct
{
	MSGADDR	addr;
	ULONG	data;
} MSGSTRUCT;

#endif

#ifndef LPMSGSTRUCT
typedef MSGSTRUCT * LPMSGSTRUCT;
#endif

#ifndef SEQRECORD

typedef struct
{
	USHORT	vercount;
	USHORT	timestampl;
	USHORT	timestamph;
	USHORT	activity;
	ULONG   data;
	USHORT  wordnum;       //ARINC 717 records only
	USHORT  subframe;      //ARINC 717 records only
	USHORT  superframe;    //ARINC 717 records only
} SEQRECORD;

#endif

#ifndef LPSEQRECORD
typedef SEQRECORD * LPSEQRECORD;
#endif

#ifndef MSGFIELDS

typedef struct
{
    USHORT msgopt;              //User writes message options
    USHORT msgact;              //Card writes message activity
    union {
		ULONG  msgdata;         //Card/User writes message data (Rcv/Xmt)
		ULONG  listptr;         //User writes list buffer pointer
	};
    union {
		ULONG  timetag;         //Card writes time tag
		ULONG  hitcount;        //Card writes hit count
	};
	union {
		ULONG  maxtime;			//Card writes max time
		ULONG  elapsetime;      //Card writes elapsed time
    };
	ULONG  mintime;	            //Card writes min time
    ULONG  userptr;             //User writes user code pointer
    ULONG  miscptr;             //User writes misc. pointer
    ULONG  rsvd;	            //Reserved
} MSGFIELDS;

#endif

#ifndef LPMSGFIELDS
typedef MSGFIELDS * LPMSGFIELDS;
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
*  L43 Driver functions.
*
**/

L43W32API ULONG __stdcall L43_BCDGetData(ULONG msg,USHORT msb,USHORT lsb);
L43W32API ULONG __stdcall L43_BCDGetMant(ULONG msg,USHORT sigdig);
L43W32API USHORT __stdcall L43_BCDGetSign(ULONG msg);
L43W32API USHORT __stdcall L43_BCDGetSSM(ULONG msg);
L43W32API VOID __stdcall L43_BCDGetVal(LPSTR buf,ULONG msg,USHORT sigdig,LPCSTR resolstr);
L43W32API ULONG __stdcall L43_BCDPutData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
L43W32API ULONG __stdcall L43_BCDPutMant(ULONG msg,ULONG value,USHORT sigdig,USHORT sign);
L43W32API ULONG __stdcall L43_BCDPutSign(ULONG msg,USHORT sign);
L43W32API ULONG __stdcall L43_BCDPutSSM(ULONG msg,USHORT value);
L43W32API ULONG __stdcall L43_BCDPutVal(LPCSTR buf,ULONG msg,USHORT sigdig,LPCSTR resolstr);
L43W32API ULONG __stdcall L43_BNRGetData(ULONG msg,USHORT msb,USHORT lsb);
L43W32API ULONG __stdcall L43_BNRGetMant(ULONG msg,USHORT sigbit);
L43W32API USHORT __stdcall L43_BNRGetSign(ULONG msg);
L43W32API USHORT __stdcall L43_BNRGetSSM(ULONG msg);
L43W32API VOID __stdcall L43_BNRGetVal(LPSTR buf,ULONG msg,USHORT sigbit,LPCSTR resolstr);
L43W32API ULONG __stdcall L43_BNRPutData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
L43W32API ULONG __stdcall L43_BNRPutMant(ULONG msg,ULONG value,USHORT sigbit,USHORT twos);
L43W32API ULONG __stdcall L43_BNRPutSign(ULONG msg,USHORT twos);
L43W32API ULONG __stdcall L43_BNRPutSSM(ULONG msg,USHORT value);
L43W32API ULONG __stdcall L43_BNRPutVal(LPCSTR buf,ULONG msg,USHORT sigbit,LPCSTR resolstr);
L43W32API USHORT __stdcall L43_BrdNumRd(HCARD handleval);
L43W32API VOID __stdcall L43_BrdNumWr(USHORT brdnum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardClose(HCARD handleval);
L43W32API HCARD __stdcall L43_CardOpen(INT cardnum);
L43W32API VOID __stdcall L43_CardReset(HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardResume(HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardStart(HCARD handleval);
L43W32API BOOL __stdcall L43_CardStop(HCARD handleval);
L43W32API VOID __stdcall L43_CardTrigger(HCARD handleval);
L43W32API ERRVAL __stdcall L43_ChClear(INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ChConfig(ULONG configval,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_ChPause(INT channum,HCARD handleval);
L43W32API INT __stdcall L43_ChPauseCheck(INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_ChResume(INT channum,HCARD handleval);
L43W32API BOOL __stdcall L43_ExtDinRd(HCARD handleval);
L43W32API VOID __stdcall L43_ExtDinWr(BOOL dinval,HCARD handleval);
L43W32API BOOL __stdcall L43_ExtDIORd(INT dionum,HCARD handleval);
L43W32API VOID __stdcall L43_ExtDIOWr(INT dionum,BOOL dioval,HCARD handleval);
L43W32API BOOL __stdcall L43_ExtLEDRd(HCARD handleval);
L43W32API VOID __stdcall L43_ExtLEDWr(BOOL ledval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_FilterClear(BASEADDR baseaddr,HCARD handleval);
L43W32API MSGADDR __stdcall L43_FilterDefault(ULONG configval,INT channum,HCARD handleval);
L43W32API MSGADDR __stdcall L43_FilterRd(INT labelval,INT sdival,INT channum,HCARD handleval);
L43W32API MSGADDR __stdcall L43_FilterSet(ULONG configval,INT labelval,INT sdimask,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_FilterWr(MSGADDR msgaddr,INT labelval,INT sdival,INT channum,HCARD handleval);
L43W32API ULONG __stdcall L43_FldGetData(ULONG msgval);
L43W32API USHORT __stdcall L43_FldGetLabel(ULONG msgval);
L43W32API USHORT __stdcall L43_FldGetParity(ULONG msgval);
L43W32API USHORT __stdcall L43_FldGetSDI(ULONG msgval);
L43W32API ULONG __stdcall L43_FldGetValue(ULONG msgval,USHORT startbit,USHORT endbit);
L43W32API ULONG __stdcall L43_FldPutData(ULONG msgval,ULONG data);
L43W32API ULONG __stdcall L43_FldPutLabel(ULONG msgval,USHORT label);
L43W32API ULONG __stdcall L43_FldPutSDI(ULONG msgval,USHORT sdi);
L43W32API ULONG __stdcall L43_FldPutValue(ULONG msgval,ULONG dataval,USHORT startbit,USHORT endbit);
L43W32API VOID __stdcall L43_GetChanCount(LPINT rcvcount,LPINT xmtcount,HCARD handleval);
L43W32API ERRVAL __stdcall L43_IntConfig(USHORT configval,USHORT count,HCARD handleval);
L43W32API ERRVAL __stdcall L43_IntInstall(LPVOID hEvent,HCARD handleval);
L43W32API ULONG __stdcall L43_IntRd(LPUSHORT typeval,LPULONG infoval,HCARD handleval);
L43W32API VOID __stdcall L43_IntReset(HCARD handleval);
L43W32API INT __stdcall L43_IntStatus(HCARD handleval);
L43W32API ERRVAL __stdcall L43_IntUninstall(HCARD handleval);
L43W32API BOOL __stdcall L43_IsChan(INT channum,HCARD handleval);
L43W32API BOOL __stdcall L43_IsRcvChan(INT channum,HCARD handleval);
L43W32API BOOL __stdcall L43_IsXmtChan(INT channum,HCARD handleval);
L43W32API LISTADDR __stdcall L43_ListAsyncCreate(ULONG listconfigval,INT count,INT channum,HCARD handleval);
L43W32API ULONG __stdcall L43_ListDataRd(LISTADDR listaddr,HCARD handleval);
L43W32API BOOL __stdcall L43_ListDataWr(ULONG value,LISTADDR listaddr,HCARD handleval);
L43W32API LISTADDR __stdcall L43_ListRcvCreate(ULONG listconfigval,INT count,MSGADDR msgaddr,HCARD handleval);
L43W32API LISTADDR __stdcall L43_ListXmtCreate(ULONG listconfigval,INT count,MSGADDR msgaddr,HCARD handleval);
L43W32API MSGADDR __stdcall L43_MsgBlockRd(LPMSGFIELDS msgfields,MSGADDR msgaddr,HCARD handleval);
L43W32API MSGADDR __stdcall L43_MsgBlockWr(LPMSGFIELDS msgfields,MSGADDR msgaddr,HCARD handleval);
L43W32API MSGADDR __stdcall L43_MsgCommRd(LPMSGFIELDS msgfields,MSGADDR msgaddr,HCARD handleval);
L43W32API MSGADDR __stdcall L43_MsgCommWr(LPMSGFIELDS msgfields,MSGADDR msgaddr,HCARD handleval);
L43W32API MSGADDR __stdcall L43_MsgCreate(ULONG configval,HCARD handleval);
L43W32API ULONG __stdcall L43_MsgDataRd(MSGADDR msgaddr,HCARD handleval);
L43W32API VOID __stdcall L43_MsgDataWr(ULONG value,MSGADDR msgaddr,HCARD handleval);
L43W32API BOOL __stdcall L43_MsgIsAccessed(MSGADDR msgaddr,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedBranch(USHORT condition,SCHNDX destindex,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SchedBuild(INT nummsgs,LPMSGADDR msgaddr,LPINT minperiod,LPINT maxperiod,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedCall(USHORT condition,SCHNDX destindex,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedEntry(INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedGap(USHORT gapval,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedGapFixed(USHORT gapval,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedGapList(USHORT gapval,LISTADDR listaddr,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedHalt(INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedInt(USHORT condition,USHORT tagval,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedMsg(MSGADDR msgaddr,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedMsgEx(MSGADDR msgaddr,USHORT gapval,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedPause(INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedPulse(INT dionum,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedRestart(INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedReturn(INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SeqConfig(ULONG configval,HCARD handleval);
L43W32API INT __stdcall L43_SeqInterval(INT interval,INT mode,HCARD handleval);
L43W32API USHORT __stdcall L43_SeqIntFrequency(USHORT intfreq,HCARD handleval);
L43W32API BOOL __stdcall L43_SeqIsRunning(HCARD handleval);
L43W32API USHORT __stdcall L43_SeqRd(LPSEQRECORD buf,HCARD handleval);
L43W32API BOOL __stdcall L43_SeqStatus(HCARD handleval);
L43W32API VOID __stdcall L43_TimerClear(HCARD handleval);
L43W32API ULONG __stdcall L43_TimerRd(HCARD handleval);
L43W32API INT __stdcall L43_TimerResolution(INT timerresol,HCARD handleval);

/**
*
*  L43/717 functions.
*
**/

L43W32API ERRVAL __stdcall L43_Ch717Status(LPUSHORT buf,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_Get717ChanCount(LPINT rcvcount,LPINT xmtcount,HCARD handleval);
L43W32API BOOL __stdcall L43_Is717BiPhaseChan(INT channum,HCARD handleval);
L43W32API BOOL __stdcall L43_Is717Chan(INT channum,HCARD handleval);
L43W32API BOOL __stdcall L43_Is717RcvChan(INT channum,HCARD handleval);
L43W32API BOOL __stdcall L43_Is717XmtChan(INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SubFrmBlkRd(LPUSHORT databuf,INT subframe,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SubFrmBlkWr(LPUSHORT databuf,INT subframe,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SubFrmStatus(LPUSHORT buf,INT subframe,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SubFrmWordConfig(ULONG configval,INT subframe,INT word,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SubFrmWordRd(LPUSHORT value,INT subframe,INT word,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SubFrmWordWr(USHORT value,INT subframe,INT word,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SuperFrmConfig(INT count,INT framespersuperframe,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SuperFrmCounterPos(INT subframe,INT word,INT channum,HCARD handleval);
L43W32API SUPERFRMADDR __stdcall L43_SuperFrmDefine(INT subframe,INT word,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SuperFrmWordRd(LPUSHORT value,INT superfrmnum,SUPERFRMADDR superfrmaddr,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SuperFrmWordWr(USHORT value,INT superfrmnum,SUPERFRMADDR superfrmaddr,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SuperFrmWordConfig(ULONG configval,INT superfrmnum,SUPERFRMADDR superfrmaddr,INT channum,HCARD handleval);
L43W32API BOOL __stdcall L43_SyncTest(INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SyncValRd(LPINT syncword1,LPINT syncword2,LPINT syncword3,LPINT syncword4,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SyncValWr(INT syncword1,INT syncword2,INT syncword3,INT syncword4,INT channum,HCARD handleval);

/**
*
*  Internal functions used by the L43 Driver.
*
**/

L43W32API ULONG __stdcall L43_AddrDSP(ULONG addr);
L43W32API ULONG __stdcall L43_AddrHost(ULONG addr);
L43W32API ERRVAL __stdcall L43_AsciiToMant(LPCSTR str,LPULONG mant,LPINT exp);
L43W32API ERRVAL __stdcall L43_BootAdd(LPCSTR filename,LPCSTR name,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootAddProc(USHORT value,USHORT addr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootAddr(INT index,LPUSHORT addr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootAddrNext(LPUSHORT addr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootCount(LPUSHORT count,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootCrc(USHORT index,LPULONG crc,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootDelete(USHORT index,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootGet(USHORT index,LPCSTR filename,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootInfo(USHORT index,LPUSHORT base,LPUSHORT length,LPSTR name,USHORT namelen,LPULONG crc,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootPtrGet(LPUSHORT index,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootPtrPut(USHORT index,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootRdW(LPUSHORT value,USHORT addr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootStr(USHORT index,LPSTR keystr,LPSTR buf,USHORT bufcount,HCARD handleval);
L43W32API ERRVAL __stdcall L43_BootWrW(USHORT value,USHORT addr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardBoot(HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardCloseAll(VOID);
L43W32API ULONG __stdcall L43_CardGetInfo(USHORT infotype,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardGetInfoEx(LPUSHORT bufmodel,USHORT bufmodelcount,LPUSHORT buffeature,USHORT buffeaturecount,HCARD handleval);
L43W32API VOID __stdcall L43_CardInit(VOID);
L43W32API BOOL __stdcall L43_CardIsRunning(HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardNop(HCARD handleval);
L43W32API HCARD __stdcall L43_CardOpenEx(LPCSTR cardname,INT cardnum);
L43W32API HCARD __stdcall L43_CardOpenExx(LPCSTR cardname,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
L43W32API VOID __stdcall L43_CardResetEx(HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardTest(USHORT level,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardTest0(HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardTest1(HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardTest2(HCARD handleval);
L43W32API ERRVAL __stdcall L43_CardTest3(HCARD handleval);
L43W32API ULONG __stdcall L43_CFGRdL(INT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_CFGWrL(ULONG value,INT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_Ch717Config(ULONG configval,INT channum,HCARD handleval);
L43W32API BASEADDR __stdcall L43_Ch717Create(INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_Ch717Reset(INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ChConfigEx(ULONG configval,USHORT count,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_ChDARClr(USHORT maskval,USHORT addrval,INT channum,HCARD handleval);
L43W32API BOOL __stdcall L43_ChDARGet(USHORT maskval,USHORT addrval,INT channum,HCARD handleval);
L43W32API ULONG __stdcall L43_ChDARRdL(USHORT addrval,INT channum,HCARD handleval);
L43W32API USHORT __stdcall L43_ChDARRdW(USHORT addrval,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_ChDARSet(USHORT maskval,USHORT addrval,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_ChDARWrL(ULONG value,USHORT addrval,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_ChDARWrW(USHORT value,USHORT addrval,INT channum,HCARD handleval);
L43W32API BOOL __stdcall L43_ChStart(INT channum,HCARD handleval);
L43W32API BOOL __stdcall L43_ChStop(INT channum,HCARD handleval);
L43W32API ULONG __stdcall L43_CmdAddr(SCHNDX index,INT channum,HCARD handleval);
L43W32API ULONG __stdcall L43_CmdAlloc(INT count,HCARD handleval);
L43W32API ULONG __stdcall L43_CmdAllocEx(ULONG configval,INT count,HCARD handleval);
L43W32API ULONG __stdcall L43_CmdBaseRd(INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_CmdBaseWr(ULONG addrval,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CmdClear(INT channum,HCARD handleval);
L43W32API USHORT __stdcall L43_CmdCountRd(INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_CmdCountWr(USHORT countval,INT channum,HCARD handleval);
L43W32API USHORT __stdcall L43_CmdCtrlRd(SCHNDX index,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_CmdCtrlWr(USHORT ctrlval,SCHNDX index,INT channum,HCARD handleval);
L43W32API USHORT __stdcall L43_CmdCurrRd(INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_CmdCurrWr(USHORT addrval,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_CmdInit(USHORT opcode,LPUSHORT block);
L43W32API SCHNDX __stdcall L43_CmdInsert(LPUSHORT block,INT channum,HCARD handleval);
L43W32API USHORT __stdcall L43_CmdMaxRd(INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_CmdMaxWr(USHORT count,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CmdRd(LPUSHORT block,ULONG addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CmdShotWr(BOOL value,SCHNDX index,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CmdSkipWr(BOOL value,SCHNDX index,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_CmdStackClr(INT channum,HCARD handleval);
L43W32API USHORT __stdcall L43_CmdStartRd(INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_CmdStartWr(USHORT addrval,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CmdStepWr(BOOL value,SCHNDX index,INT channum,HCARD handleval);
L43W32API INT __stdcall L43_CmdTotalRd(INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_CmdTotalWr(INT countval,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CmdWr(LPUSHORT block,ULONG addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CommCall(ULONG addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CommCheck(HCARD handleval);
L43W32API ERRVAL __stdcall L43_CommDisable(USHORT command,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CommDisableEx(USHORT command,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CommEnable(HCARD handleval);
L43W32API ULONG __stdcall L43_CommRdL(ULONG addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CommRdsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
L43W32API USHORT __stdcall L43_CommRdW(ULONG addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CommRun(LPUSHORT dataptr,USHORT datacount,LPUSHORT codeptr,USHORT codecount,HCARD handleval);
L43W32API VOID __stdcall L43_CommWrL(ULONG value,ULONG addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_CommWrsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
L43W32API VOID __stdcall L43_CommWrW(USHORT value,ULONG addrval,HCARD handleval);
L43W32API ULONG __stdcall L43_ConvFromArinc(ULONG msgval);
L43W32API ULONG __stdcall L43_ConvToArinc(ULONG msgval);
L43W32API VOID __stdcall L43_DARClr(USHORT maskval,USHORT addrval,HCARD handleval);
L43W32API BOOL __stdcall L43_DARGet(USHORT maskval,USHORT addrval,HCARD handleval);
L43W32API ULONG __stdcall L43_DARRdL(USHORT addrval,HCARD handleval);
L43W32API USHORT __stdcall L43_DARRdW(USHORT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_DARSet(USHORT maskval,USHORT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_DARWrL(ULONG value,USHORT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_DARWrW(USHORT value,USHORT addrval,HCARD handleval);
L43W32API ULONG __stdcall L43_Div(ULONG diva,ULONG divb);
L43W32API INT __stdcall L43_DllUsageCount(VOID);
L43W32API USHORT __stdcall L43_DPMMRdW(ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_DPMMWrW(USHORT value,ULONG addrval,HCARD handleval);
L43W32API USHORT __stdcall L43_DPMRdB(ULONG addrval,HCARD handleval);
L43W32API ULONG __stdcall L43_DPMRdL(ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_DPMRdsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L43W32API VOID __stdcall L43_DPMRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L43W32API USHORT __stdcall L43_DPMRdW(ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_DPMWrB(USHORT value,ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_DPMWrL(ULONG value,ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_DPMWrsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L43W32API VOID __stdcall L43_DPMWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L43W32API VOID __stdcall L43_DPMWrW(USHORT value,ULONG addrval,HCARD handleval);
L43W32API USHORT __stdcall L43_DspBioRd(HCARD handleval);
L43W32API ERRVAL __stdcall L43_DspHmClear(HCARD handleval);
L43W32API ERRVAL __stdcall L43_DspHmSet(HCARD handleval);
L43W32API ERRVAL __stdcall L43_DspIntfClear(HCARD handleval);
L43W32API BOOL __stdcall L43_DspIntfRead(HCARD handleval);
L43W32API ERRVAL __stdcall L43_DspIntmClear(HCARD handleval);
L43W32API ERRVAL __stdcall L43_DspIntmSet(HCARD handleval);
L43W32API ERRVAL __stdcall L43_DspXfClear(HCARD handleval);
L43W32API ERRVAL __stdcall L43_DspXfSet(HCARD handleval);
L43W32API LPCSTR __stdcall L43_ErrDesc(INT errval);
L43W32API LPCSTR __stdcall L43_ErrDescStr(INT errval);
L43W32API LPCSTR __stdcall L43_ErrName(INT errval);
L43W32API VOID __stdcall L43_ExpandMant(LPULONG mant,LPINT exp);
L43W32API VOID __stdcall L43_ExtDIODirSet(INT dionum,BOOL dirval,HCARD handleval);
L43W32API BOOL __stdcall L43_ExtLEDWINRd(HCARD handleval);
L43W32API VOID __stdcall L43_ExtLEDWINWr(BOOL ledval,HCARD handleval);
L43W32API VOID __stdcall L43_FileClose(LPVOID handle);
L43W32API BOOL __stdcall L43_FileErr(VOID);
L43W32API VOID __stdcall L43_FileErrClr(VOID);
L43W32API VOID __stdcall L43_FileErrSet(VOID);
L43W32API LPVOID __stdcall L43_FileOpenRead(LPCSTR filename);
L43W32API LPVOID __stdcall L43_FileOpenWrite(LPCSTR filename);
L43W32API BOOL __stdcall L43_FileRead(LPVOID handle,LPVOID buffer,USHORT count);
L43W32API BOOL __stdcall L43_FileSeek(LPVOID handle,ULONG offset);
L43W32API ULONG __stdcall L43_FileTell(LPVOID handle);
L43W32API BOOL __stdcall L43_FileWrite(LPVOID handle,LPVOID buffer,USHORT count);
L43W32API ULONG __stdcall L43_FilterAddr(INT labelval,INT sdival,INT channum,HCARD handleval);
L43W32API BASEADDR __stdcall L43_FilterCreate(HCARD handleval);
L43W32API ERRVAL __stdcall L43_FilterFill(MSGADDR msgaddr,BASEADDR baseaddr,HCARD handleval);
L43W32API USHORT __stdcall L43_FldGetParBit(ULONG msgval);
L43W32API ULONG __stdcall L43_FldPutParBit(ULONG msgval);
L43W32API USHORT __stdcall L43_GetHigh(ULONG val);
L43W32API USHORT __stdcall L43_GetLow(ULONG val);
L43W32API USHORT __stdcall L43_GlobalRdW(USHORT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_GlobalWrW(USHORT value,USHORT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_HandleClose(HCARD handleval);
L43W32API ERRVAL __stdcall L43_HandleDel(HCARD handleval);
L43W32API ERRVAL __stdcall L43_HandleGet(LPSTR cardstr,LPINT cardnum,LPINT devnum,LPULONG sizval,HCARD handleval);
L43W32API HCARD __stdcall L43_HandleIns(LPCSTR cardname,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
L43W32API BOOL __stdcall L43_HandleOkay(HCARD handleval);
L43W32API ERRVAL __stdcall L43_HandleOpen(LPCSTR cardname,INT cardnum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_HandleOpenWin95(LPCSTR cardname,INT cardnum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_HandleOpenWinNT(LPCSTR cardname,INT cardnum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_HandleVer(HCARD handleval);
L43W32API ERRVAL __stdcall L43_HandleVerPLX(HCARD handleval);
L43W32API ULONG __stdcall L43_HeapAlloc(ULONG wordcount,HCARD handleval);
L43W32API ULONG __stdcall L43_HeapAllocAll(LPULONG wordcount,HCARD handleval);
L43W32API ULONG __stdcall L43_HeapAllocAllDPM(LPUSHORT wordcount,HCARD handleval);
L43W32API ULONG __stdcall L43_HeapAllocDPM(USHORT wordcount,HCARD handleval);
L43W32API ULONG __stdcall L43_HeapAllocEx(USHORT configval,ULONG wordcount,HCARD handleval);
L43W32API ULONG __stdcall L43_HeapWipe(HCARD handleval);
L43W32API ULONG __stdcall L43_HeapWipeDPM(HCARD handleval);
L43W32API ERRVAL __stdcall L43_HexRd(LPCSTR fname,ERRVAL (__stdcall *proc)(USHORT value,USHORT addr,HCARD handleval),HCARD handleval);
L43W32API ERRVAL __stdcall L43_HexRun(LPCSTR fname,HCARD handleval);
L43W32API ERRVAL __stdcall L43_HexRunProc(USHORT value,USHORT addr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_HexStat(LPUSHORT lowaddr,LPUSHORT highaddr,LPUSHORT count,LPCSTR fname);
L43W32API ERRVAL __stdcall L43_HexStatProc(USHORT value,USHORT addr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_HexWrAddr(USHORT addr);
L43W32API ERRVAL __stdcall L43_HexWrByte(BYTE ch);
L43W32API ERRVAL __stdcall L43_HexWrClose(void);
L43W32API ERRVAL __stdcall L43_HexWrFlush(void);
L43W32API ERRVAL __stdcall L43_HexWrFlushByte(USHORT value);
L43W32API ERRVAL __stdcall L43_HexWrOpen(LPCSTR fname);
L43W32API USHORT __stdcall L43_IndirectRd(INT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_IndirectWr(USHORT value,INT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_IntClear(HCARD handleval);
L43W32API ERRVAL __stdcall L43_IntDisable(HCARD handleval);
L43W32API ERRVAL __stdcall L43_IntEnable(HCARD handleval);
L43W32API ERRVAL __stdcall L43_IntEnableCond(HCARD handleval);
L43W32API LPVOID __stdcall L43_IntGet(HCARD handleval);
L43W32API USHORT __stdcall L43_IORdW(INT addrval,HCARD handleval);
L43W32API USHORT __stdcall L43_IOWINRdW(USHORT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_IOWINWrW(USHORT value,USHORT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_IOWrW(USHORT value,INT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernBegin(LPVOID *vxdptr,LPSTR cardstr,LPCSTR cardname,INT busnum,INT devnum,INT funcnum);
L43W32API ERRVAL __stdcall L43_KernDev(LPINT valueptr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernEnd(LPVOID vxdptr);
L43W32API ERRVAL __stdcall L43_KernIntClear(HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernIntInstall(LPVOID hEvent,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernIntParam(ULONG clraddr,ULONG clrwidth,ULONG clrvalue,ULONG stataddr,ULONG statwidth,ULONG statvalue,ULONG statmask,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernIntStatus(LPINT valueptr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernIntUninstall(HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernIORdW(LPUSHORT valueptr,INT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernIOWrW(USHORT value,INT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernMEMFillW(USHORT value,INT addrval,INT countval,INT bustype,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernMEMRdL(LPULONG valueptr,INT addrval,INT bustype,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernMEMRdsL(LPULONG bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernMEMRdsW(LPUSHORT bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernMEMRdW(LPUSHORT valueptr,INT addrval,INT bustype,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernMEMWrL(ULONG value,INT addrval,INT bustype,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernMEMWrsL(LPULONG bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernMEMWrsW(LPUSHORT bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernMEMWrW(USHORT value,INT addrval,INT bustype,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernQuick(BOOL flag,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernStatus(LPULONG valueptr,ULONG type,HCARD handleval);
L43W32API ERRVAL __stdcall L43_KernStatusEx(LPULONG valueptr,ULONG type,ULONG index,HCARD handleval);
L43W32API ULONG __stdcall L43_LabelReverse(ULONG msgval);
L43W32API ULONG __stdcall L43_ListAddr(INT index,LISTADDR listaddr,HCARD handleval);
L43W32API ULONG __stdcall L43_ListAddrEx(INT index,LISTADDR listaddr,LPUSHORT header);
L43W32API ERRVAL __stdcall L43_ListAdvance(LISTADDR listaddr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ListClear(LISTADDR listaddr,HCARD handleval);
L43W32API LISTADDR __stdcall L43_ListConfig(ULONG configval,INT count,HCARD handleval);
L43W32API LISTADDR __stdcall L43_ListConfigEx(ULONG configval,INT count,HCARD handleval);
L43W32API USHORT __stdcall L43_ListDataBlkRd(ULONG data[],USHORT datacount,LISTADDR listaddr,HCARD handleval);
L43W32API BOOL __stdcall L43_ListDataBlkWr(LPULONG dataptr,USHORT datacount,LISTADDR listaddr,HCARD handleval);
L43W32API ULONG __stdcall L43_ListDataRdEx(INT index,LISTADDR listaddr,HCARD handleval);
L43W32API VOID __stdcall L43_ListDataWrEx(ULONG value,INT index,LISTADDR listaddr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ListInit(LISTADDR listaddr,MSGADDR msgaddr,HCARD handleval);
L43W32API ULONG __stdcall L43_ListNextRd(ULONG listaddr,LPUSHORT header);
L43W32API ULONG __stdcall L43_ListNextWr(ULONG listaddr,LPUSHORT header);
L43W32API VOID __stdcall L43_ListPostRd(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L43W32API VOID __stdcall L43_ListPostWr(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L43W32API VOID __stdcall L43_ListPreRd(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L43W32API VOID __stdcall L43_ListPreWr(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L43W32API INT __stdcall L43_ListStatus(LISTADDR listaddr,HCARD handleval);
L43W32API ULONG __stdcall L43_MakeLong(USHORT valh,USHORT vall);
L43W32API LPSTR __stdcall L43_MantToAscii(LPSTR buf,long mant,int exp);
L43W32API ULONG __stdcall L43_Mask(ULONG dataval,INT cntval);
L43W32API VOID __stdcall L43_MaxMant(LPULONG mant,LPINT exp);
L43W32API VOID __stdcall L43_MEMWINFillW(USHORT value,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
L43W32API USHORT __stdcall L43_MEMWINRdB(ULONG addrval,INT bustype,HCARD handleval);
L43W32API ULONG __stdcall L43_MEMWINRdL(ULONG addrval,INT bustype,HCARD handleval);
L43W32API VOID __stdcall L43_MEMWINRdsL(LPULONG valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L43W32API VOID __stdcall L43_MEMWINRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L43W32API USHORT __stdcall L43_MEMWINRdW(ULONG addrval,INT bustype,HCARD handleval);
L43W32API VOID __stdcall L43_MEMWINWrB(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
L43W32API VOID __stdcall L43_MEMWINWrL(ULONG value,ULONG addrval,INT bustype,HCARD handleval);
L43W32API VOID __stdcall L43_MEMWINWrsL(LPULONG valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L43W32API VOID __stdcall L43_MEMWINWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L43W32API VOID __stdcall L43_MEMWINWrW(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
L43W32API ULONG __stdcall L43_Mod(ULONG moda,ULONG modb);
L43W32API USHORT __stdcall L43_MsgActivityRd(MSGADDR msgaddr,HCARD handleval);
L43W32API VOID __stdcall L43_MsgActivityWr(USHORT value,MSGADDR msgaddr,HCARD handleval);
L43W32API USHORT __stdcall L43_MsgCheck(MSGADDR msgaddr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_MsgConfig(ULONG configval,MSGADDR msgaddr,HCARD handleval);
L43W32API USHORT __stdcall L43_MsgOptRd(MSGADDR msgaddr,HCARD handleval);
L43W32API VOID __stdcall L43_MsgOptWr(USHORT msgopt,MSGADDR msgaddr,HCARD handleval);
L43W32API MSGADDR __stdcall L43_MsgReset(MSGADDR msgaddr,HCARD handleval);
L43W32API ULONG __stdcall L43_Mul(ULONG mula,ULONG mulb);
L43W32API VOID __stdcall L43_NormalMant(LPULONG mant,LPINT exp);
L43W32API USHORT __stdcall L43_PortRd(INT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_PortWr(USHORT value,INT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ProcCall(ULONG useraddr,HCARD handleval);
L43W32API ULONG __stdcall L43_ProcLoad(LPVOID userbuf,USHORT count,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ProcRun(LPVOID userbuf,USHORT count,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ProcSetFore(ULONG useraddr,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ProcSetInt(USHORT useraddr,INT intnum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ProcSetPost(ULONG useraddr,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ProcSetPre(ULONG useraddr,INT channum,HCARD handleval);
L43W32API USHORT __stdcall L43_ProgRdW(USHORT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_ProgWrW(USHORT value,USHORT addrval,HCARD handleval);
L43W32API VOID __stdcall L43_RAMFill(USHORT value,ULONG addrval,ULONG countval,HCARD handleval);
L43W32API BOOL __stdcall L43_RAMIsDPM(ULONG addrval);
L43W32API USHORT __stdcall L43_RAMRdB(ULONG addrval,HCARD handleval);
L43W32API ULONG __stdcall L43_RAMRdL(ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_RAMRdsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L43W32API VOID __stdcall L43_RAMRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L43W32API USHORT __stdcall L43_RAMRdW(ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_RAMWipe(HCARD handleval);
L43W32API VOID __stdcall L43_RAMWipeEx(USHORT value,HCARD handleval);
L43W32API VOID __stdcall L43_RAMWrB(USHORT value,ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_RAMWrL(ULONG value,ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_RAMWrsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L43W32API VOID __stdcall L43_RAMWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L43W32API VOID __stdcall L43_RAMWrW(USHORT value,ULONG addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMChksW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMClose(HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMDisable(HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMEnable(HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMFlush(HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMInfoRd(LPBYTE buf,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMInfoWr(LPBYTE buf,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMOpen(HCARD handleval);
L43W32API VOID __stdcall L43_ROMProg(USHORT enableflag,LPUSHORT dataptr,USHORT cntval,ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_ROMProgg(INT value,ULONG addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMRdsW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMWrsW(USHORT enableflag,LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_ROMWrW(USHORT value,USHORT addrval,HCARD handleval);
L43W32API ULONG __stdcall L43_SchedAdvance(VOID);
L43W32API SCHNDX __stdcall L43_SchedAgain(SCHNDX index,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedBranchEx(USHORT condition1,USHORT condition2,SCHNDX destindex,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SchedBuildEx(INT nummsgs,LPMSGADDR msgaddr,LPINT minperiod,LPINT maxperiod,BOOL speed,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SchedBuildExx(INT basemsgnum,INT nummsgs,LPMSGADDR msgaddr,LPINT minperiod,LPINT maxperiod,INT speed,LPVOID buf,ULONG bufsize,INT channum,HCARD handleval);
L43W32API ULONG __stdcall L43_SchedCalc(VOID);
L43W32API SCHNDX __stdcall L43_SchedCallEx(USHORT condition1,USHORT condition2,SCHNDX destindex,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SchedCheck(LPINT minperiod,LPINT maxperiod);
L43W32API VOID __stdcall L43_SchedCheckEnd(VOID);
L43W32API VOID __stdcall L43_SchedCheckMiddle(ULONG msgnum,ULONG minlen,ULONG midlen,ULONG maxlen);
L43W32API VOID __stdcall L43_SchedCheckReal(ULONG msgnum,ULONG minlen,ULONG midlen,ULONG maxlen);
L43W32API VOID __stdcall L43_SchedCheckStart(VOID);
L43W32API ULONG __stdcall L43_SchedConflicts(VOID);
L43W32API VOID __stdcall L43_SchedDisplay(ULONG nummsgs,LPULONG count,LPULONG *data);
L43W32API ERRVAL __stdcall L43_SchedDivide(VOID);
L43W32API ULONG __stdcall L43_SchedFix(VOID);
L43W32API VOID __stdcall L43_SchedFixEnd(VOID);
L43W32API VOID __stdcall L43_SchedFixMiddle(ULONG conflicts);
L43W32API VOID __stdcall L43_SchedFixStart(VOID);
L43W32API VOID __stdcall L43_SchedHook(INT index,LPVOID ptr);
L43W32API ERRVAL __stdcall L43_SchedInsert(ULONG events,ULONG index,ULONG msgnum,LPMSGADDR msgaddr,ULONG gapval,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SchedInsertEnd(ULONG events,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SchedInsertStart(ULONG events,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedIntEx(USHORT condition1,USHORT condition2,USHORT tagval,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_SchedLayout(VOID);
L43W32API ULONG __stdcall L43_SchedMaxval(LPULONG array,ULONG arraycount);
L43W32API ULONG __stdcall L43_SchedMinval(LPULONG array,ULONG arraycount);
L43W32API SCHNDX __stdcall L43_SchedNop(INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SchedParse(INT basemsgnum,LPMSGADDR msgaddr,INT channum,HCARD handleval);
L43W32API VOID __stdcall L43_SchedPrint(LPSTR str,...);
L43W32API SCHNDX __stdcall L43_SchedPulse0(INT dionum,INT channum,HCARD handleval);
L43W32API SCHNDX __stdcall L43_SchedPulse1(INT dionum,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SchedReset(VOID);
L43W32API ULONG __stdcall L43_SchedRotate(VOID);
L43W32API INT __stdcall L43_SchedShift(INT msgnum,INT value);
L43W32API ERRVAL __stdcall L43_SchedSlide(VOID);
L43W32API VOID __stdcall L43_SchedSlideEnd(VOID);
L43W32API VOID __stdcall L43_SchedSlideMiddle(ULONG index,ULONG count,ULONG conflicts);
L43W32API VOID __stdcall L43_SchedSlideStart(ULONG factor);
L43W32API VOID __stdcall L43_SchedSort(VOID);
L43W32API ULONG __stdcall L43_SchedToBit(ULONG value);
L43W32API ULONG __stdcall L43_SchedToMsec(ULONG value);
L43W32API VOID __stdcall L43_SchedUnsort(VOID);
L43W32API SCHNDX __stdcall L43_SchedUser(ULONG useraddr,INT channum,HCARD handleval);
L43W32API ULONG __stdcall L43_SchedWalk(VOID);
L43W32API ERRVAL __stdcall L43_SEEPokeW(INT value,INT numbits,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SEERdBit(LPINT valueptr,INT bitnum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SEERdL(LPULONG valueptr,INT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SEERdW(LPINT valueptr,INT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SEEWrBit(INT value,INT bitnum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SEEWrL(ULONG value,INT addrval,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SEEWrW(INT value,INT addrval,HCARD handleval);
L43W32API USHORT __stdcall L43_SEMMRdW(ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_SEMMWrW(USHORT value,ULONG addrval,HCARD handleval);
L43W32API USHORT __stdcall L43_SEMRdW(ULONG addrval,HCARD handleval);
L43W32API VOID __stdcall L43_SEMWrW(USHORT value,ULONG addrval,HCARD handleval);
L43W32API ULONG __stdcall L43_SeqBlkRd(LPUSHORT buf,ULONG bufcount,LPULONG blkcnt,HCARD handleval);
L43W32API ULONG __stdcall L43_SeqBlkRdEx(LPUSHORT buf,ULONG bufcount,ULONG maxblkcnt,LPULONG blkcnt,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SeqClear(HCARD handleval);
L43W32API ERRVAL __stdcall L43_SeqConfigEx(ULONG configval,ULONG seqcount,USHORT cardnum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SeqConfigExx(ULONG configval,ULONG seqaddr,ULONG seqcount,USHORT cardnum,HCARD handleval);
L43W32API USHORT __stdcall L43_SeqIntervalEx(USHORT shiftval,HCARD handleval);
L43W32API USHORT __stdcall L43_SeqRdEx(LPUSHORT buf,USHORT bufcount,HCARD handleval);
L43W32API BOOL __stdcall L43_SeqResume(HCARD handleval);
L43W32API BOOL __stdcall L43_SeqStart(HCARD handleval);
L43W32API BOOL __stdcall L43_SeqStop(HCARD handleval);
L43W32API ULONG __stdcall L43_Shl(ULONG dataval,INT cntval);
L43W32API ULONG __stdcall L43_Shr(ULONG dataval,INT cntval);
L43W32API USHORT __stdcall L43_SignMant(LPCSTR str);
L43W32API SUBFRMADDR __stdcall L43_SubFrmAddr(INT subframe,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SubFrmCreate(ULONG configval,INT subframe,BASEADDR chanbase,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SubFrmReset(INT subframe,INT channum,HCARD handleval);
L43W32API BASEADDR __stdcall L43_SuperFrmBaseAddr(INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SuperFrmConfigEx(ULONG configval,INT count,INT framespersuperframe,INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SuperFrmReset(INT channum,HCARD handleval);
L43W32API ERRVAL __stdcall L43_SyncValPtrInit(INT channum,HCARD handleval);
L43W32API USHORT __stdcall L43_TimerResolutionEx(USHORT timershift,HCARD handleval);
L43W32API USHORT __stdcall L43_Transpose12(USHORT val);
L43W32API INT __stdcall L43_ValAsciiCmpi(LPSTR str1,LPSTR str2);
L43W32API LPSTR __stdcall L43_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
L43W32API VOID __stdcall L43_ValAsciiTrimLead(LPSTR buf);
L43W32API VOID __stdcall L43_ValAsciiTrimTrail(LPSTR buf);
L43W32API ULONG __stdcall L43_ValFromAscii(LPCSTR asciistr,INT radixval);
L43W32API ULONG __stdcall L43_ValGetBits(ULONG oldvalue,INT startbit,INT endbit);
L43W32API LPSTR __stdcall L43_ValIncAscii(LPSTR asciistr);
L43W32API LPSTR __stdcall L43_ValInccAscii(LPSTR asciistr);
L43W32API BOOL __stdcall L43_ValIsLower(INT value);
L43W32API INT __stdcall L43_ValLenAscii(INT numbits,INT radixval);
L43W32API ULONG __stdcall L43_ValPutBits(ULONG oldvalue,ULONG newfld,INT startbit,INT endbit);
L43W32API LPSTR __stdcall L43_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
L43W32API INT __stdcall L43_ValToUpper(INT value);

#ifdef __cplusplus
}
#endif

#define CH0	    0x0000					//Channel 0
#define CH1	    0x0001					//Channel 1
#define CH2	    0x0002					//Channel 2
#define CH3	    0x0003					//Channel 3
#define CH4	    0x0004					//Channel 4
#define CH5	    0x0005					//Channel 5
#define CH6	    0x0006					//Channel 6
#define CH7	    0x0007					//Channel 7

#define SDI00   0x0001					//Enable SDI00
#define SDI01   0x0002					//Enable SDI01
#define SDI10   0x0004					//Enable SDI10
#define SDI11   0x0008					//Enable SDI11
#define SDIALL  0x000F					//Enable all SDIs

#define SUBFRM1    0x0001               //Sub Frame 1 (717)
#define SUBFRM2    0x0002               //Sub Frame 2 (717)
#define SUBFRM3    0x0003               //Sub Frame 3 (717)
#define SUBFRM4    0x0004               //Sub Frame 4 (717)

/**
*
*  Channel configuration options
*
**/

#define CHCFG_DEFAULT     0x00000000L	//Select all default settings (XMT & RCV) (default)
#define CHCFG_HIGHSPEED   0x00000001L	//Select high speed (XMT & RCV)
#define CHCFG_AUTOSPEED   0x00000002L	//Select auto speed detection (RCV)
#define CHCFG_LOWSPEED    0x00000000L	//Select low speed (XMT & RCV) (default)
#define CHCFG_SELFTEST    0x00000004L	//Enable internal wraparound (XMT & RCV)
#define CHCFG_SELFTESTOFF 0x00000000L	//Disable internal wraparound (XMT & RCV) (default)
#define CHCFG_SYNC	  	  0x00000008L	//Sync Enable (XMT & RCV)
#define CHCFG_SYNCOFF     0x00000000L	//Disable sync output (XMT & RCV) (default)
#define CHCFG_PARODD	  0x00000000L	//Parity odd (XMT & RCV) (default)
#define CHCFG_PAREVEN	  0x00000010L	//Parity even (XMT & RCV)
#define CHCFG_PARDATA	  0x00000020L	//Parity bit as data (XMT & RCV)
#define CHCFG_ACTIVE	  0x00000000L	//Enable ehannel activity (XMT & RCV) (default)
#define CHCFG_INACTIVE    0x00000040L	//Disable channel activity (XMT & RCV)
#define CHCFG_EXTTRIG     0x00000080L	//Enable external trigger for all messages (XMT)
#define CHCFG_EXTOFF      0x00000000L	//External trigger is enabled on message level (XMT) (default)
#define CHCFG_PARERR      0x00000100L	//Enable parity error for all messages (XMT)
#define CHCFG_NOERR       0x00000000L	//errors are enabled on message level (XMT) (default)
#define CHCFG_HIT	      0x00000200L	//Hit counter is enabled for all messages
#define CHCFG_NOHIT		  0x00000000L	//Hit counter is enabled on message level (default)
#define CHCFG_TIMETAG     0x00000400L	//Enable time-tag for all message records
#define CHCFG_TIMETAGOFF  0x00000000L	//Time-tag is enabled on message level (default)
#define CHCFG_ELAPSE      0x00000800L	//Enable elapse time for all messages
#define CHCFG_ELAPSEOFF   0x00000000L	//Elapse time is enabled on message level (default)
#define CHCFG_MAX         0x00001000L	//Enable max repetition rate monitoring for all messages
#define CHCFG_MIN         0x00002000L	//Enable min repetition rate monitoring for all messages
#define CHCFG_MAXMIN      0x00003000L	//Enable max and min repetition rate monitoring for all messages
#define CHCFG_MAXMINOFF   0x00000000L	//Repetition rate monitoring is enabled on message level (default)
#define CHCFG_SEQALL      0x00080000L	//Record entire channel in sequential record
#define CHCFG_SEQSEL      0x00000000L	//Sequential record recording is enabled at message level (default)
#define CHCFG_INTHALT     0x00200000L	//Enable schedule halt interrupt
#define CHCFG_NOINTHALT   0x00000000L	//No interrupt on schedule halt (default)
#define CHCFG_INTPAUSE    0x00400000L	//Enable schedule pause interrupt
#define CHCFG_NOINTPAUSE  0x00000000L	//No interrupt on schedulr pause (default)
#define CHCFG_INTERR	  0x00800000L	//Enable interrupts on decoder errors.
#define CHCFG_NOINTERR	  0x00000000L	//No interrupt on decoder errors (default)
#define CHCFG_PAUSE       0x01000000L	//Mark channel as paused
#define CHCFG_UNPAUSE     0x00000000L	//Mark channel as unpaused (default)
#define CHCFG_RAM         0x00000000L   //Messages are located in static RAM (default)
#define CHCFG_DPRAM       0x80000000L   //Messages are located in dual-port RAM

#define CHCFG717_DEFAULT     0x00000000L	//Select all default settings (XMT & RCV) (default)
#define CHCFG717_AUTOSPEED   0x00000002L	//Select auto speed detection (RCV)
#define CHCFG717_64WPS       0x00004000L	//Select speed of 64WPS (XMT & RCV) 
#define CHCFG717_128WPS      0x00008000L	//Select speed of 128WPS (XMT & RCV) 
#define CHCFG717_256WPS      0x00000000L	//Select speed of 256WPS (XMT & RCV) (default)
#define CHCFG717_512WPS      0x00010000L	//Select speed of 512WPS (XMT & RCV) 
#define CHCFG717_1024WPS     0x00020000L	//Select speed of 1024WPS (XMT & RCV) 
#define CHCFG717_2048WPS     0x00040000L	//Select speed of 2048WPS (XMT & RCV) 
#define CHCFG717_4096WPS     0x02000000L	//Select speed of 4096WPS (XMT & RCV) 
#define CHCFG717_8192WPS     0x04000000L	//Select speed of 8192WPS (XMT & RCV) 
#define CHCFG717_BIPHASERCV  0x00000000L    //Set Bi-Phase channel to receiver (Bi-Phase) (default)
#define CHCFG717_BIPHASEXMT  0x08000000L    //Set Bi-Phase channel to transmitter (Bi-Phase)
#define CHCFG717_BIPOLARHSPD 0x08000000L    //Select high spped slope for Bi-Polar transmitter (Bi-Polar XMT)
#define CHCFG717_SELFTEST    0x00000004L	//Enable internal wraparound (XMT & RCV)
#define CHCFG717_SELFTESTOFF 0x00000000L	//Disable internal wraparound (XMT & RCV) (default)
#define CHCFG717_SYNC	  	 0x00000008L	//Sync Enable (XMT & RCV)
#define CHCFG717_SYNCOFF     0x00000000L	//Disable sync output (XMT & RCV) (default)
#define CHCFG717_ACTIVE	     0x00000000L	//Enable ehannel activity (XMT & RCV) (default)
#define CHCFG717_INACTIVE    0x00000040L	//Disable channel activity (XMT & RCV)
#define CHCFG717_EXTTRIG     0x00000080L	//Enable external trigger for all messages (XMT)
#define CHCFG717_EXTOFF      0x00000000L	//External trigger is enabled on message level (XMT) (default)
#define CHCFG717_HIT	     0x00000200L	//Hit counter is enabled for all sub frames (XMT & RCV) 
#define CHCFG717_NOHIT		 0x00000000L	//Hit counter is disabled (XMT & RCV) (default)
#define CHCFG717_TIMETAG     0x00000400L	//Enable time-tag for all sub frames (XMT & RCV) 
#define CHCFG717_TIMETAGOFF  0x00000000L	//Time-tag is disabled (XMT & RCV) (default)
#define CHCFG717_SEQALL      0x00080000L	//Record entire channel in sequential record (XMT & RCV)
#define CHCFG717_SEQSEL      0x00000000L	//Sequential record recording is enabled at word level (XMT & RCV) (default)
#define CHCFG717_INTERR	     0x00800000L	//Enable interrupts on Out of Sync Error (RCV)
#define CHCFG717_NOINTERR	 0x00000000L	//No interrupt on Out of Sync Error (RCV) (default)
#define CHCFG717_PAUSE       0x01000000L	//Mark channel as paused (XMT & RCV) 
#define CHCFG717_UNPAUSE     0x00000000L	//Mark channel as unpaused (XMT & RCV) (default)

/**
*
*  Sequential Record configuration options
*
**/

#define SEQCFG_DEFAULT      0x00000000L     //Select all default settings
#define SEQCFG_FILLHALT     0x00000000L     //Enable sequential record in fill and halt mode (default)
#define SEQCFG_DISABLE      0x00000001L     //Disable sequential record
#define SEQCFG_CONTINUOUS   0x00000002L     //Enable sequential record in continuous mode
#define SEQCFG_FREE         0x00000008L     //Enable sequential record in free mode
#define SEQCFG_DELTA        0x00000010L     //Enable sequential record in delta mode
#define SEQCFG_INTERVAL     0x00000020L     //Enable sequential record in interval mode
#define SEQCFG_NOINTFULL    0x00000000L     //Do not generate interrupt when sequential record is full (default)
#define SEQCFG_INTFULL      0x00001000L     //Generate interrupt when sequential record is full
#define SEQCFG_NOINTFREQ    0x00000000L     //Do not generate interrupts at a user specified frequency (default)
#define SEQCFG_INTFREQ      0x00002000L     //Generate interrupts at user specified frequency
#define SEQCFG_16K          0x00000000L     //Allocate a 16K sequential record buffer (default)
#define SEQCFG_ALLAVAIL     0x01000000L     //Allocate all available memory to a sequential record buffer
#define SEQCFG_32K          0x02000000L     //Allocate a 32K sequential record buffer
#define SEQCFG_64K          0x04000000L     //Allocate a 64K sequential record buffer
#define SEQCFG_128K         0x08000000L     //Allocate a 128K sequential record buffer
#define SEQCFG_DPRAM        0x10000000L     //Allocate all available dual-port memory


/**
*
*  Interrupt log list configuration options
*
**/

#define INTCFG_DEFAULT      0x00000000L     //Select all default settings
#define INTCFG_ENABLE       0x00000000L     //Enable interrupt log list (default)
#define INTCFG_DISABLE      0x00000001L     //Disable interrupt log list

/**
*
*  Info types
*
**/

#define INFOTYPE_PLAT      0x0001           //Returns the L43 platform type
#define INFOTYPE_PROD      0x0002           //Returns the L43 product type
#define INFOTYPE_DASH      0x0003           //Returns the L43 dash number
#define INFOTYPE_VERSION   0x0004           //Returns the L43 version number
#define INFOTYPE_DATE      0x0005           //Returns the L43 version date
#define INFOTYPE_MODEL     0x0006           //Returns the L43 model number
#define INFOTYPE_MAXCOUNT  0x0007           //Returns the max channel count
#define INFOTYPE_USERCODE  0x000A           //Returns whether L43 handles user code
#define INFOTYPE_LISTBUF   0x000B           //Returns whether L43 handles list buffering
#define INFOTYPE_ARINC717  0x000C           //Returns whether L43 has ARINC 717 channels

/**
*
*  Message configuration options
*
**/

#define MSGCRT_DEFAULT     0x00000000L      //Default settings
#define MSGCRT_NOSEQ       0x00000000L      //Message will not be recorded in sequential record (default)
#define MSGCRT_SEQ         0x00000001L      //Message will be recorded in sequential record
#define MSGCRT_NOINT       0x00000000L      //Message will not generate interrupt (default)
#define MSGCRT_INT         0x00000002L      //Message will generate interrupt
#define MSGCRT_NOLIST      0x00000000L      //Message will not have a list buffer (default)
#define MSGCRT_LIST        0x00000004L      //Message will have a list buffer
#define MSGCRT_NOSKIP      0x00000000L      //Message will not be skipped (default)
#define MSGCRT_SKIP        0x00000008L      //Message will be skipped
#define MSGCRT_NOTIMETAG   0x00000000L      //Message will not record time-tag (default)
#define MSGCRT_TIMETAG     0x00000010L      //Message will record time-tag
#define MSGCRT_NOELAPSE    0x00000000L      //Message will not record elapse time (default)
#define MSGCRT_ELAPSE      0x00000020L      //Message will record elapse time
#define MSGCRT_NOMAXMIN    0x00000000L      //Message will not record min/max time (default)
#define MSGCRT_MAX         0x00000040L      //Message will record max time
#define MSGCRT_MIN         0x00000080L      //Message will record min time
#define MSGCRT_MAXMIN      0x000000C0L      //Message will record min/max time
#define MSGCRT_NOSYNC      0x00000000L      //No sync will be generated for message (default)
#define MSGCRT_SYNC        0x00000100L      //Sync will be generated for message
#define MSGCRT_NOERR       0x00000000L      //No error will be generated for message (default)
#define MSGCRT_PARERR      0x00000200L      //Parity error will be generated for message
#define MSGCRT_NOHIT       0x00000000L      //Message will not record hit count (default)
#define MSGCRT_HIT         0x00000400L      //Message will record hit count
#define MSGCRT_NOEXTRIG    0x00000000L      //Message will not be externally triggered (default)
#define MSGCRT_EXTRIG      0x00001000L      //Message will be externally triggered
#define MSGCRT_WIPE        0x00000000L      //Enables message clear (default)
#define MSGCRT_NOWIPE      0x80000000L      //Disables message clear
#define MSGCRT_WIPE0       0x00000000L      //Initialize data with zeros (default)
#define MSGCRT_WIPE1       0x40000000L      //Initialize data with ones
#define MSGCRT_CHAN        0x00000000L      //Message located in static RAM or dual-port RAM depending upon channel config (default)
#define MSGCRT_RAM         0x20000000L      //Message located in static RAM
#define MSGCRT_DPRAM       0x10000000L      //Message located in dual-port RAM

/**
*
*  Sub Frame word configuration options (717)
*
**/

#define WRDCFG_DEFAULT    0x00000000L       //Select all default settings
#define WRDCFG_SFINT      0x00000001L       //Enable subframe interrupt
#define WRDCFG_SFINTOFF   0x00000000L       //Disable subframe interrupt (default)
#define WRDCFG_WRDINT     0x00000002L       //Enable word interrupt
#define WRDCFG_WRDINTOFF  0x00000000L       //Disable word interrupt (default)
#define WRDCFG_SEQ        0x00000004L       //Enable sequential record
#define WRDCFG_SEQOFF     0x00000000L       //Disable sequential record (default)

/**
*
*  List buffer options
*
**/

#define LISTCRT_DEFAULT    0x00000000L      //Select all default settings
#define LISTCRT_FIFO       0x00000000L      //Enable FIFO mode (default)
#define LISTCRT_PINGPONG   0x00000001L      //Enable ping-pong mode
#define LISTCRT_CIRCULAR   0x00000002L      //Enable circular mode
#define LISTCRT_RCV	       0x00000010L      //User will read from list buffer
#define LISTCRT_XMT 	   0x00000020L      //User will write to list buffer
#define LISTCRT_NOINT      0x00000000L      //Do not generate interrupt when list buffer empty/full (default)
#define LISTCRT_INT        0x00000100L      //Generate interrupt when list buffer empty/full
#define LISTCRT_RAM        0x00000000L      //List located in static RAM (default)
#define LISTCRT_DPRAM      0x00200000L      //List located in dual-port RAM

/**
*
*  Bit fields of the message activity flag.
*
**/

#define MSGACT_BRD		0xF000		//All bits of Board number
#define MSGACT_BRD3		0x8000		//Bit 3 of Board number
#define MSGACT_BRD2		0x4000		//Bit 2 of Board number
#define MSGACT_BRD1		0x2000		//Bit 1 of Board number
#define MSGACT_BRD0		0x1000		//Bit 0 of Board number
#define MSGACT_CHAN		0x0F00		//All bits of Channel number
#define MSGACT_CHAN3	0x0800		//Bit 3 of Channel number
#define MSGACT_CHAN2	0x0400		//Bit 2 of Channel number
#define MSGACT_CHAN1	0x0200		//Bit 1 of Channel number
#define MSGACT_CHAN0	0x0100		//Bit 0 of Channel number
#define MSGACT_ASPD		0x0080		//Auto Speed
#define MSGACT_ERR		0x0040		//Error bit
#define MSGACT_GAP		0x0020		//Gap error bit
#define MSGACT_PAR		0x0010		//Parity error bit
#define MSGACT_LONG		0x0008		//Long word error bit
#define MSGACT_BIT		0x0004		//Bit time error bit
#define MSGACT_TO		0x0002		//Time out error bit
#define MSGACT_HIT		0x0001		//Always set

#define MSGACT717_BRD	 0xF000		//All bits of Board number
#define MSGACT717_BRD3	 0x8000		//Bit 3 of Board number
#define MSGACT717_BRD2	 0x4000		//Bit 2 of Board number
#define MSGACT717_BRD1	 0x2000		//Bit 1 of Board number
#define MSGACT717_BRD0	 0x1000		//Bit 0 of Board number
#define MSGACT717_CHAN	 0x0F00		//All bits of Channel number
#define MSGACT717_CHAN3	 0x0800		//Bit 3 of Channel number
#define MSGACT717_CHAN2	 0x0400		//Bit 2 of Channel number
#define MSGACT717_CHAN1	 0x0200		//Bit 1 of Channel number
#define MSGACT717_CHAN0	 0x0100		//Bit 0 of Channel number
#define MSGACT717_SPD    0x00E0		//All bits of current speed
#define MSGACT717_SPD2   0x0080		//Bit 2 of current speed
#define MSGACT717_SPD1   0x0040		//Bit 1 of current speed
#define MSGACT717_SPD0   0x0020		//Bit 0 of current speed
#define MSGACT717_TO     0x0002		//Time out error bit
#define MSGACT717_HIT    0x0001		//Always set

/**
*
*  L43 IFGA Registers
*
**/

#define IREG_STAT   0x0040                  //Status register (RD)
#define IREG_SET    0x0041                  //Set register (WR)
#define IREG_CLR    0x0042                  //Clear register (WR)
#define IREG_ID     0x0043                  //ID register (RD)
#define IREG_PAGE   0x0044                  //Page register
#define IREG_CONFIG 0x0045                  //Configuration register
#define IREG_INT    0x0046                  //Interrupt register
#define IREG_PRESCL 0x0047                  //Prescale Register for clock divider

/**
*
*  EDGA Registers
*
**/

#define EREG1_GSTAT			0x1180	//Global Status
#define EREG1_CHSTAT		0x0181	//Channel Status
#define EREG1_CHDATAH		0x0182	//Channel Data High Word
#define EREG1_CHDATAL		0x0183	//Channel Data Low Word
#define EREG1_CHGAP			0x0184	//Channel Gap
#define EREG1_CHCNTL		0x0185	//Channel Control Word
#define EREG1_CHCFG			0x0186	//Channel Config
#define EREG1_CHCFGINT		0x0187	//Channel Int Config
#define EREG1_GERR			0x0188	//Global Error Register
#define EREG1_GRST			0x0189	//Global Reset
#define EREG1_GID			0x018C	//Global ID

#define EREG2_GSTAT			0x1280	//Global Status
#define EREG2_CHSTAT		0x0281	//Channel Status
#define EREG2_CHDATAH		0x0282	//Channel Data High Word
#define EREG2_CHDATAL		0x0283	//Channel Data Low Word
#define EREG2_CHGAP			0x0284	//Channel Gap
#define EREG2_CHCNTL		0x0285	//Channel Control Word
#define EREG2_CHCFG			0x0286	//Channel Config
#define EREG2_CHCFGINT		0x0287	//Channel Int Config
#define EREG2_GERR			0x0288	//Global Error Register
#define EREG2_GRST			0x0289	//Global Reset
#define EREG2_GID			0x028C	//Global ID

/**
*
*  Local Configuration Registers
*
**/

#define CREG_LAS0RR  0x0000					//Local Address Space 0 Range
#define CREG_LAS1RR  0x0001					//Local Address Space 1 Range
#define CREG_LAS2RR  0x0002					//Local Address Space 2 Range
#define CREG_LAS3RR  0x0003					//Local Address Space 3 Range
#define CREG_EROMRR  0x0004					//Local Expansion ROM Range
#define CREG_LAS0BA  0x0005					//Local Address Space 0 Local Base Address (Re-map)
#define CREG_LAS1BA  0x0006					//Local Address Space 1 Local Base Address (Re-map)
#define CREG_LAS2BA  0x0007					//Local Address Space 2 Local Base Address (Re-map)
#define CREG_LAS3BA  0x0008					//Local Address Space 3 Local Base Address (Re-map)
#define CREG_EROMBA  0x0009					//Expansion ROM Local Base Address (Re-map)
#define CREG_LAS0BRD 0x000A					//Local Address Space 0 Bus Region Descriptors
#define CREG_LAS1BRD 0x000B					//Local Address Space 1 Bus Region Descriptors
#define CREG_LAS2BRD 0x000C					//Local Address Space 2 Bus Region Descriptors
#define CREG_LAS3BRD 0x000D					//Local Address Space 3 Bus Region Descriptors
#define CREG_EROMBRD 0x000E					//Expansion ROM Bus Region Descriptors
#define CREG_CS0BASE 0x000F					//Chip Select 0 Base Address
#define CREG_CS1BASE 0x0010					//Chip Select 1 Base Address
#define CREG_CS2BASE 0x0011					//Chip Select 2 Base Address
#define CREG_CS3BASE 0x0012					//Chip Select 3 Base Address
#define CREG_INTCSR  0x0013					//Interrupt Control/Status
#define CREG_CNTRL   0x0014					//EEPROM Control, PCI Slave Response, User I/O Control, Init Control

/**
*
*  Interrupt types.
*
**/

#define INTTYPE_MSG          0x0001               //Message interrupt
#define INTTYPE_OPCODE       0x0002               //Interrupt opcode
#define INTTYPE_HALT         0x0003               //Schedule halt
#define INTTYPE_PAUSE        0x0004               //Schedule pause
#define INTTYPE_SEQFULL      0x0005               //Sequential record full
#define INTTYPE_LIST         0x0006               //List buffer empty/full
#define INTTYPE_ERR          0x0007               //Decoder error detected
#define INTTYPE_SEQFREQ      0x0008               //Sequential record frequency
#define INTTYPE_717WORD      0x0009               //717 word received
#define INTTYPE_717SUBFRM    0x000A               //717 sub frame completed
#define INTTYPE_717SYNCERR   0x000B               //717 Rcv channel lost synchronization

/**
*
*  Timer resolutions.
*
**/

#define TIMERRESOL_1US      1                //1us timer resolution, 1:11:34 range
#define TIMERRESOL_16US     2                //16us timer resolution, 19:05:19 range
#define TIMERRESOL_1024US   3                //1024us timer resolution, 50 day range
#define TIMERRESOL_16348US  4                //16348us timer resolution, 814 day range

/**
*
*  Interval calculation modes.
*
**/

#define INTERVALMODE_CLOSEST  1              //Finds interval closest to value specified
#define INTERVALMODE_LESS     2              //Finds closest interval less than value specified
#define INTERVALMODE_GREATER  3              //Finds closest interval more than value specified

/**
*
*  Scheduling conditions.
*
**/

#define COND_ALWAYS		0x0000
#define COND_DIO1ACT	0x0001
#define COND_DIO1NACT	0x0081
#define COND_DIO2ACT	0x0002
#define COND_DIO2NACT	0x0082
#define COND_DIO3ACT	0x0003
#define COND_DIO3NACT	0x0083
#define COND_DIO4ACT	0x0004
#define COND_DIO4NACT	0x0084


#define SEQRD_MAX_COUNT 9

#define RCV 0
#define XMT 1

#define STAT_EMPTY   0                      //Buffer is empty
#define STAT_PARTIAL 1                      //Buffer is partially filled
#define STAT_FULL    2                      //Buffer is full
#define STAT_OFF     3                      //Buffer is off

#define TEST_LEVEL_0 0                      //Test I/O interface
#define TEST_LEVEL_1 1                      //Test memory interface
#define TEST_LEVEL_2 2                      //Test communication process
#define TEST_LEVEL_3 3                      //Test bus transceiver

#define ERR_NONE          0                 //No error
#define ERR_UNKNOWN      -1                 //An unexpected error occurred
#define ERR_BADVER       -2                 //A bad version was encountered
#define ERR_BADPARAMS    -11                //CardOpen() called with bad parameters
#define ERR_NOHANDLES    -12                //CardOpen() already has allocated too many handles
#define ERR_NOCARD       -13                //CardOpen() could not find a L43 card at the specified address
#define ERR_NOIO         -14                //CardOpen() could not find the I/O ports
#define ERR_NOMEM        -15                //CardOpen() could not find the memory
#define ERR_BAD16BIT     -16                //Card is conflicting with another 16-bit card
#define ERR_WRONGMODEL   -17                //Card does not support this feature
#define ERR_NOSEL        -18                //CardOpen() could not allocate a memory selector
#define ERR_LOCK         -19                //The communication process is locked up
#define ERR_TOOMANY      -20                //Too many channels have been configured
#define ERR_BADHANDLE    -21                //A bad handle was specified
#define ERR_NOTCHAN	     -23                //Not a valid channel
#define ERR_NOTXMT       -24                //The Transmitter has not been configured
#define ERR_NOTRCV       -25                //The Receiver has not been configured
#define ERR_NOTSEQ       -26                //The Sequential Record has not been configured
#define ERR_ALLOC        -27                //There is not enough memory to allocate
#define ERR_VXD          -28                //An error occurred in the VXD
#define ERR_BADLABEL     -29                //The specified label value is not valid
#define ERR_BADSDI	     -30                //The specified sdi value is not valid
#define ERR_BADMSG       -31                //The specified command block is not a message block
#define ERR_BADSCHNDX    -32                //Specified command index is out of range
#define ERR_BUFSIZE      -33                //Insufficient space in user buffer
#define ERR_NOCONFIG     -34                //The card has not been properly configured
#define ERR_CONFLICTS	 -35				//Unable to resolve conflicts
#define ERR_RANGE    	 -36				//Schedule is out of range
#define ERR_FACTOR  	 -37				//A bad factor value was specified
#define ERR_BOOTFULL     -41                //No space to add boot code
#define ERR_BOOTNUM      -42                //There is no boot code with the specified number
#define ERR_ACCESS       -43                //Unable to write to access register
#define ERR_ROMVERIFY    -44                //Unable to verify the value written to the ROM
#define ERR_COUNT        -45                //An invalid count was specified
#define ERR_CRC          -46                //There was a bad checksum in the HEX file
#define ERR_FNAME        -47                //Bad filenames were specified
#define ERR_FRDWR        -48                //There was an error reading or writing the HEX file
#define ERR_HEX          -49                //There was a bad hex character in the HEX file
#define ERR_INDEX        -51                //The command block index was invalid or the schedule is full
#define ERR_NOMSGS       -52                //No messages specified
#define ERR_TYPE         -54                //There was a bad type value in the HEX file
#define ERR_ZEROLEN      -55                //Zero length was specified
#define ERR_BADADDRESS	 -56				//A bad address was specified
#define ERR_SELFIOFAIL   -71                //I/O selftest failed
#define ERR_SELFMEMFAIL  -72                //Memory selftest failed
#define ERR_SELFCOMMFAIL -73                //Communication selftest failed
#define ERR_SELFXMTFAIL  -74                //Transmit selftest failed
#define ERR_PLXBUG       -75                //PLX bug is causing problems
#define ERR_NOT717CHAN   -100				//Specified channel is not a 717 channel
#define ERR_SUBFRMNUM    -101				//Invalid 717 SubFrame number was specified
#define ERR_WORDNUM      -102				//Invalid 717 Word number was specified
#define ERR_NOTINSYNC    -103				//Not Synchronized to 717 databus
#define ERR_SUPERFRM     -104				//SuperFrame not configured
#define ERR_SUPERFRMNUM  -105				//Invalid 717 SuperFrame number was specified

#endif
