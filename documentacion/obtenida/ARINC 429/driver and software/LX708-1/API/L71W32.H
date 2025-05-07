/**
*
*  LP708-1 and LC708-1 WIN32 DRIVER  Version 1.2  (01/19/2001)
*  Copyright (c) 1999-2001
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   L71W32.H -- Visual C++ 32-bit
*                      L71 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for the L71.  Applications
*  using the L71 Driver Library must incorporate this
*  include file using the preprocessor directive #include. 
*  If this file is in the current working directory, the form
*  would be:
*
*  #include "L71W32.H"
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

#ifndef __L71W32_H
#define __L71W32_H

/**
*
*  Typedefs used by the L71 Driver.
*
**/

#ifndef L71W32API
#ifdef __BORLANDC__
#define L71W32API
#else
#define L71W32API __declspec(dllimport)
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

#ifndef FLOAT
typedef float FLOAT;
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
*  "C" block if compiling a C++ file.
*
**/

#ifdef __cplusplus
extern "C" {
#endif

/**
*
*  L71 Driver functions.
*
**/

L71W32API ERRVAL __stdcall L71_CardClose(HCARD handleval);
L71W32API HCARD __stdcall L71_CardOpen(INT cardnum);
L71W32API VOID __stdcall L71_CardReset(HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardStart(HCARD handleval);
L71W32API BOOL __stdcall L71_CardStop(HCARD handleval);
L71W32API USHORT __stdcall L71_FieldGetAngle(LPUSHORT buf);
L71W32API FLOAT __stdcall L71_FieldGetAngleFl(LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldGetControlAccept(LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldGetData(INT binnum,LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldGetDataAccept(LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldGetFaults(LPUSHORT buf);
L71W32API INT __stdcall L71_FieldGetGain(LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldGetLabel(LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldGetMode(LPUSHORT buf);
L71W32API INT __stdcall L71_FieldGetRange(LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldGetTilt(LPUSHORT buf);
L71W32API FLOAT __stdcall L71_FieldGetTiltFl(LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldPutAngle(USHORT value,LPUSHORT buf);
L71W32API FLOAT __stdcall L71_FieldPutAngleFl(FLOAT angle,LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldPutControlAccept(USHORT value,LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldPutData(USHORT value,INT binnum,LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldPutDataAccept(USHORT value,LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldPutFaults(USHORT value,LPUSHORT buf);
L71W32API INT __stdcall L71_FieldPutGain(INT gain,LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldPutLabel(USHORT value,LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldPutMode(USHORT value,LPUSHORT buf);
L71W32API INT __stdcall L71_FieldPutRange(INT range,LPUSHORT buf);
L71W32API USHORT __stdcall L71_FieldPutTilt(USHORT value,LPUSHORT buf);
L71W32API FLOAT __stdcall L71_FieldPutTiltFl(FLOAT tilt,LPUSHORT buf);
L71W32API ERRVAL __stdcall L71_IntInstall(LPVOID hEvent,HCARD handleval);
L71W32API ULONG __stdcall L71_IntRd(LPUSHORT typeval,LPUSHORT infoval,HCARD handleval);
L71W32API INT __stdcall L71_IntStatus(HCARD handleval);
L71W32API ERRVAL __stdcall L71_IntUninstall(HCARD handleval);
L71W32API ERRVAL __stdcall L71_RcvConfig(HCARD handleval);
L71W32API ERRVAL __stdcall L71_RcvConfigEx(ULONG rtconfigval,USHORT intfreq,HCARD handleval);
L71W32API ULONG __stdcall L71_RcvMonBlkRd(LPUSHORT buf,ULONG bufcount,LPULONG blkcnt,HCARD handleval);
L71W32API ULONG __stdcall L71_RcvMonBlkRdEx(LPUSHORT buf,ULONG bufcount,ULONG maxblkcnt,LPULONG blkcnt,HCARD handleval);
L71W32API USHORT __stdcall L71_RcvMonRd(LPUSHORT buf,HCARD handleval);
L71W32API USHORT __stdcall L71_RcvMonRdEx(LPUSHORT buf,USHORT index,HCARD handleval);
L71W32API BOOL __stdcall L71_RcvMonStatus(HCARD handleval);
L71W32API VOID __stdcall L71_RcvRd(LPUSHORT buf,HCARD handleval);
L71W32API ERRVAL __stdcall L71_XmtConfig(USHORT framefreq,HCARD handleval);
L71W32API ERRVAL __stdcall L71_XmtConfigEx(USHORT framefreq,USHORT intfreq,USHORT framecount,HCARD handleval);
L71W32API ERRVAL __stdcall L71_XmtConfigExx(ULONG xmtconfigval,USHORT framefreq,USHORT intfreq,USHORT framecount,HCARD handleval);
L71W32API VOID __stdcall L71_XmtRd(LPUSHORT buf,USHORT framenum,HCARD handleval);
L71W32API BOOL __stdcall L71_XmtStatus(HCARD handleval);
L71W32API VOID __stdcall L71_XmtWr(LPUSHORT buf,USHORT framenum,HCARD handleval);

/**
*
*  Internal functions used by the L71 Driver.
*
**/

L71W32API ULONG __stdcall L71_AddrDSP(ULONG addr);
L71W32API ULONG __stdcall L71_AddrHost(ULONG addr);
L71W32API ERRVAL __stdcall L71_BCConfig(ULONG configval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BCConfigEx(ULONG configval,USHORT count,HCARD handleval);
L71W32API MSGADDR __stdcall L71_BCConfigMsg(ULONG configval,MSGADDR msgaddr,HCARD handleval);
L71W32API LISTADDR __stdcall L71_BCCreateList(ULONG listconfigval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
L71W32API LISTADDR __stdcall L71_BCCreateListEx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
L71W32API LISTADDR __stdcall L71_BCCreateListExx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
L71W32API MSGADDR __stdcall L71_BCCreateMsg(ULONG configval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
L71W32API MSGADDR __stdcall L71_BCGetMsg(INT index,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedAgain(SCHNDX index,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedBranch(USHORT condition,SCHNDX destindex,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedBranchDin0(SCHNDX destindex,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedBranchDin1(SCHNDX destindex,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedBranchEx(USHORT condition1,USHORT condition2,USHORT condition3,SCHNDX destindex,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BCSchedBuild(USHORT nummsgs,LPMSGADDR msgaddr,LPUSHORT freq,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedCall(SCHNDX destindex,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedCallCond(USHORT condition,SCHNDX destindex,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedCallCondEx(USHORT condition1,USHORT condition2,USHORT condition3,SCHNDX destindex,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedEntry(HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedFrame(ULONG timeval,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedFrameEnd(HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedFrameStart(ULONG timeval,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedGap(USHORT gapval,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedGoto(SCHNDX destindex,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedHalt(HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedInt(USHORT tagval,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedIntCond(USHORT condition,USHORT tagval,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedIntCondEx(USHORT condition1,USHORT condition2,USHORT condition3,USHORT tagval,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedMsg(MSGADDR msgaddr,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedNop(HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedPause(HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedPulse(HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedPulse0(HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedPulse1(HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedRestart(HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedRetry(USHORT condition,USHORT retries,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedRetryEx(USHORT condition1,USHORT condition2,USHORT condition3,USHORT retryflag,USHORT retries,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedReturn(HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSchedUser(ULONG useraddr,HCARD handleval);
L71W32API SCHNDX __stdcall L71_BCSetEntry(HCARD handleval);
L71W32API ERRVAL __stdcall L71_BCSetTimeout(USHORT timeoutval,HCARD handleval);
L71W32API ULONG __stdcall L71_BlkAddr(INT taval,HCARD handleval);
L71W32API USHORT __stdcall L71_BlkOptRd(INT taval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BlkOptWr(USHORT rtopt,INT taval,HCARD handleval);
L71W32API ULONG __stdcall L71_BlkPtrRd(INT taval,HCARD handleval);
L71W32API VOID __stdcall L71_BlkPtrWr(ULONG descaddr,INT taval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BlkRd(LPUSHORT block,INT taval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BlkReset(INT taval,HCARD handleval);
L71W32API USHORT __stdcall L71_BlkSWDRd(INT taval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BlkSWDWr(USHORT swdval,INT taval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BlkWipe(HCARD handleval);
L71W32API ERRVAL __stdcall L71_BlkWr(LPUSHORT block,INT taval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootAdd(LPCSTR filename,LPCSTR name,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootAddProc(USHORT value,USHORT addr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootAddr(INT index,LPUSHORT addr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootAddrNext(LPUSHORT addr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootCount(LPUSHORT count,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootCrc(USHORT index,LPULONG crc,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootDelete(USHORT index,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootGet(USHORT index,LPCSTR filename,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootInfo(USHORT index,LPUSHORT base,LPUSHORT length,LPSTR name,USHORT namelen,LPULONG crc,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootPtrGet(LPUSHORT index,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootPtrPut(USHORT index,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootRdW(LPUSHORT value,USHORT addr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootStr(USHORT index,LPSTR keystr,LPSTR buf,USHORT bufcount,HCARD handleval);
L71W32API ERRVAL __stdcall L71_BootWrW(USHORT value,USHORT addr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardBoot(HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardCloseAll(VOID);
L71W32API ERRVAL __stdcall L71_CardConfig(BOOL enableflag,USHORT command,USHORT taval,HCARD handleval);
L71W32API ULONG __stdcall L71_CardGetInfo(USHORT infotype,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardGetInfoEx(LPUSHORT bufmodel,USHORT bufmodelcount,LPUSHORT buffeature,USHORT buffeaturecount,HCARD handleval);
L71W32API VOID __stdcall L71_CardInit(VOID);
L71W32API BOOL __stdcall L71_CardIsRunning(HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardNop(HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardNopEx(HCARD handleval);
L71W32API HCARD __stdcall L71_CardOpenEx(LPCSTR cardname,INT cardnum);
L71W32API HCARD __stdcall L71_CardOpenExx(LPCSTR cardname,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
L71W32API VOID __stdcall L71_CardResetEx(HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardResume(HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardTest(USHORT level,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardTest0(HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardTest1(HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardTest2(HCARD handleval);
L71W32API ERRVAL __stdcall L71_CardTest3(HCARD handleval);
L71W32API VOID __stdcall L71_CardTrigger(HCARD handleval);
L71W32API ULONG __stdcall L71_CFGRdL(INT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_CFGWrL(ULONG value,INT addrval,HCARD handleval);
L71W32API ULONG __stdcall L71_CmdAddr(SCHNDX index,HCARD handleval);
L71W32API ULONG __stdcall L71_CmdAlloc(INT count,HCARD handleval);
L71W32API ULONG __stdcall L71_CmdAllocEx(ULONG configval,INT count,HCARD handleval);
L71W32API ULONG __stdcall L71_CmdBaseRd(HCARD handleval);
L71W32API VOID __stdcall L71_CmdBaseWr(ULONG addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CmdClear(HCARD handleval);
L71W32API USHORT __stdcall L71_CmdCountRd(HCARD handleval);
L71W32API VOID __stdcall L71_CmdCountWr(USHORT countval,HCARD handleval);
L71W32API USHORT __stdcall L71_CmdCtrlRd(SCHNDX index,HCARD handleval);
L71W32API VOID __stdcall L71_CmdCtrlWr(USHORT ctrlval,SCHNDX index,HCARD handleval);
L71W32API USHORT __stdcall L71_CmdCurrRd(HCARD handleval);
L71W32API VOID __stdcall L71_CmdCurrWr(USHORT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_CmdInit(USHORT opcode,LPUSHORT block);
L71W32API SCHNDX __stdcall L71_CmdInsert(LPUSHORT block,HCARD handleval);
L71W32API USHORT __stdcall L71_CmdMaxRd(HCARD handleval);
L71W32API VOID __stdcall L71_CmdMaxWr(USHORT count,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CmdRd(LPUSHORT block,ULONG addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CmdShotWr(BOOL value,SCHNDX index,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CmdSkipWr(BOOL value,SCHNDX index,HCARD handleval);
L71W32API VOID __stdcall L71_CmdStackClr(HCARD handleval);
L71W32API USHORT __stdcall L71_CmdStartRd(HCARD handleval);
L71W32API VOID __stdcall L71_CmdStartWr(USHORT addrval,HCARD handleval);
L71W32API INT __stdcall L71_CmdTotalRd(HCARD handleval);
L71W32API VOID __stdcall L71_CmdTotalWr(INT countval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CmdWr(LPUSHORT block,ULONG addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CommCall(ULONG addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CommCheck(HCARD handleval);
L71W32API ERRVAL __stdcall L71_CommDisable(USHORT command,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CommDisableEx(USHORT command,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CommEnable(HCARD handleval);
L71W32API ULONG __stdcall L71_CommRdL(ULONG addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CommRdsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
L71W32API USHORT __stdcall L71_CommRdW(ULONG addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CommRun(LPUSHORT dataptr,USHORT datacount,LPUSHORT codeptr,USHORT codecount,HCARD handleval);
L71W32API VOID __stdcall L71_CommWrL(ULONG value,ULONG addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_CommWrsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
L71W32API VOID __stdcall L71_CommWrW(USHORT value,ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_DARClr(USHORT maskval,USHORT addrval,HCARD handleval);
L71W32API BOOL __stdcall L71_DARGet(USHORT maskval,USHORT addrval,HCARD handleval);
L71W32API ULONG __stdcall L71_DARRdL(USHORT addrval,HCARD handleval);
L71W32API USHORT __stdcall L71_DARRdW(USHORT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_DARSet(USHORT maskval,USHORT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_DARWrL(ULONG value,USHORT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_DARWrW(USHORT value,USHORT addrval,HCARD handleval);
L71W32API ULONG __stdcall L71_DescAddr(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API ULONG __stdcall L71_DescAlloc(HCARD handleval);
L71W32API ERRVAL __stdcall L71_DescConfig(ULONG configval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API USHORT __stdcall L71_DescOptRd(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API VOID __stdcall L71_DescOptWr(USHORT descopt,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API MSGADDR __stdcall L71_DescPtrRd(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API ULONG __stdcall L71_DescPtrWr(MSGADDR msgaddr,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API ULONG __stdcall L71_DescRd(BOOL mcflag,INT taval,BOOL trflag,INT saval,LPUSHORT desc,HCARD handleval);
L71W32API ULONG __stdcall L71_DescWr(BOOL mcflag,INT taval,BOOL trflag,INT saval,LPUSHORT desc,HCARD handleval);
L71W32API ULONG __stdcall L71_Div(ULONG diva,ULONG divb);
L71W32API INT __stdcall L71_DllUsageCount(VOID);
L71W32API USHORT __stdcall L71_DPMMRdW(ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_DPMMWrW(USHORT value,ULONG addrval,HCARD handleval);
L71W32API USHORT __stdcall L71_DPMRdB(ULONG addrval,HCARD handleval);
L71W32API ULONG __stdcall L71_DPMRdL(ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_DPMRdsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L71W32API VOID __stdcall L71_DPMRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L71W32API USHORT __stdcall L71_DPMRdW(ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_DPMWrB(USHORT value,ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_DPMWrL(ULONG value,ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_DPMWrsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L71W32API VOID __stdcall L71_DPMWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L71W32API VOID __stdcall L71_DPMWrW(USHORT value,ULONG addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_DspBioClear(HCARD handleval);
L71W32API USHORT __stdcall L71_DspBioRd(HCARD handleval);
L71W32API ERRVAL __stdcall L71_DspBioSet(HCARD handleval);
L71W32API ERRVAL __stdcall L71_DspIntfClear(HCARD handleval);
L71W32API BOOL __stdcall L71_DspIntfRead(HCARD handleval);
L71W32API ERRVAL __stdcall L71_DspIntmClear(HCARD handleval);
L71W32API ERRVAL __stdcall L71_DspIntmSet(HCARD handleval);
L71W32API ERRVAL __stdcall L71_DspXfClear(HCARD handleval);
L71W32API ERRVAL __stdcall L71_DspXfSet(HCARD handleval);
L71W32API LPCSTR __stdcall L71_ErrDesc(INT errval);
L71W32API LPCSTR __stdcall L71_ErrDescStr(INT errval);
L71W32API LPCSTR __stdcall L71_ErrName(INT errval);
L71W32API ERRVAL __stdcall L71_ErrorDefine(BOOL busb,USHORT intfreq,HCARD handleval);
L71W32API BOOL __stdcall L71_ExtDinRd(HCARD handleval);
L71W32API VOID __stdcall L71_ExtDinWr(BOOL dinval,HCARD handleval);
L71W32API BOOL __stdcall L71_ExtDoutRd(HCARD handleval);
L71W32API VOID __stdcall L71_ExtDoutWr(BOOL doutval,HCARD handleval);
L71W32API VOID __stdcall L71_FileClose(LPVOID handle);
L71W32API BOOL __stdcall L71_FileErr(VOID);
L71W32API VOID __stdcall L71_FileErrClr(VOID);
L71W32API VOID __stdcall L71_FileErrSet(VOID);
L71W32API LPVOID __stdcall L71_FileOpenRead(LPCSTR filename);
L71W32API LPVOID __stdcall L71_FileOpenWrite(LPCSTR filename);
L71W32API BOOL __stdcall L71_FileRead(LPVOID handle,LPVOID buffer,USHORT count);
L71W32API BOOL __stdcall L71_FileSeek(LPVOID handle,ULONG offset);
L71W32API ULONG __stdcall L71_FileTell(LPVOID handle);
L71W32API BOOL __stdcall L71_FileWrite(LPVOID handle,LPVOID buffer,USHORT count);
L71W32API USHORT __stdcall L71_GetHigh(ULONG val);
L71W32API USHORT __stdcall L71_GetLow(ULONG val);
L71W32API USHORT __stdcall L71_GlobalRdW(USHORT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_GlobalWrW(USHORT value,USHORT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_HandleClose(HCARD handleval);
L71W32API ERRVAL __stdcall L71_HandleDel(HCARD handleval);
L71W32API ERRVAL __stdcall L71_HandleGet(LPSTR cardstr,LPINT cardnum,LPINT devnum,LPULONG sizval,HCARD handleval);
L71W32API HCARD __stdcall L71_HandleIns(LPCSTR cardname,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
L71W32API BOOL __stdcall L71_HandleOkay(HCARD handleval);
L71W32API ERRVAL __stdcall L71_HandleOpen(LPCSTR cardname,INT cardnum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_HandleOpenWin95(LPCSTR cardname,INT cardnum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_HandleOpenWinNT(LPCSTR cardname,INT cardnum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_HandleVer(HCARD handleval);
L71W32API ERRVAL __stdcall L71_HandleVerPLX(HCARD handleval);
L71W32API ULONG __stdcall L71_HeapAlloc(ULONG wordcount,HCARD handleval);
L71W32API ULONG __stdcall L71_HeapAllocAll(LPULONG wordcount,HCARD handleval);
L71W32API ULONG __stdcall L71_HeapAllocAllDPM(LPUSHORT wordcount,HCARD handleval);
L71W32API ULONG __stdcall L71_HeapAllocDPM(USHORT wordcount,HCARD handleval);
L71W32API ULONG __stdcall L71_HeapAllocEx(USHORT configval,ULONG wordcount,HCARD handleval);
L71W32API ULONG __stdcall L71_HeapWipe(HCARD handleval);
L71W32API ULONG __stdcall L71_HeapWipeDPM(HCARD handleval);
L71W32API ERRVAL __stdcall L71_HexRd(LPCSTR fname,ERRVAL (__stdcall *proc)(USHORT value,USHORT addr,HCARD handleval),HCARD handleval);
L71W32API ERRVAL __stdcall L71_HexRun(LPCSTR fname,HCARD handleval);
L71W32API ERRVAL __stdcall L71_HexRunProc(USHORT value,USHORT addr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_HexStat(LPUSHORT lowaddr,LPUSHORT highaddr,LPUSHORT count,LPCSTR fname);
L71W32API ERRVAL __stdcall L71_HexStatProc(USHORT value,USHORT addr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_HexWrAddr(USHORT addr);
L71W32API ERRVAL __stdcall L71_HexWrByte(BYTE ch);
L71W32API ERRVAL __stdcall L71_HexWrClose(void);
L71W32API ERRVAL __stdcall L71_HexWrFlush(void);
L71W32API ERRVAL __stdcall L71_HexWrFlushByte(USHORT value);
L71W32API ERRVAL __stdcall L71_HexWrOpen(LPCSTR fname);
L71W32API USHORT __stdcall L71_IndirectRd(INT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_IndirectWr(USHORT value,INT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_IntClear(HCARD handleval);
L71W32API ERRVAL __stdcall L71_IntConfig(ULONG configval,USHORT count,HCARD handleval);
L71W32API ERRVAL __stdcall L71_IntDisable(HCARD handleval);
L71W32API ERRVAL __stdcall L71_IntEnable(HCARD handleval);
L71W32API ERRVAL __stdcall L71_IntEnableCond(HCARD handleval);
L71W32API LPVOID __stdcall L71_IntGet(HCARD handleval);
L71W32API VOID __stdcall L71_IntReset(HCARD handleval);
L71W32API USHORT __stdcall L71_IORdW(INT addrval,HCARD handleval);
L71W32API USHORT __stdcall L71_IOWINRdW(USHORT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_IOWINWrW(USHORT value,USHORT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_IOWrW(USHORT value,INT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernBegin(LPVOID *vxdptr,LPSTR cardstr,LPCSTR cardname,INT busnum,INT devnum,INT funcnum);
L71W32API ERRVAL __stdcall L71_KernDev(LPINT valueptr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernEnd(LPVOID vxdptr);
L71W32API ERRVAL __stdcall L71_KernIntClear(HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernIntInstall(LPVOID hEvent,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernIntParam(ULONG clraddr,ULONG clrwidth,ULONG clrvalue,ULONG stataddr,ULONG statwidth,ULONG statvalue,ULONG statmask,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernIntStatus(LPINT valueptr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernIntUninstall(HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernIORdW(LPUSHORT valueptr,INT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernIOWrW(USHORT value,INT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernMEMFillW(USHORT value,INT addrval,INT countval,INT bustype,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernMEMRdL(LPULONG valueptr,INT addrval,INT bustype,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernMEMRdsL(LPULONG bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernMEMRdsW(LPUSHORT bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernMEMRdW(LPUSHORT valueptr,INT addrval,INT bustype,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernMEMWrL(ULONG value,INT addrval,INT bustype,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernMEMWrsL(LPULONG bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernMEMWrsW(LPUSHORT bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernMEMWrW(USHORT value,INT addrval,INT bustype,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernQuick(BOOL flag,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernStatus(LPULONG valueptr,ULONG type,HCARD handleval);
L71W32API ERRVAL __stdcall L71_KernStatusEx(LPULONG valueptr,ULONG type,ULONG index,HCARD handleval);
L71W32API MSGADDR __stdcall L71_ListAddr(INT index,LISTADDR listaddr,HCARD handleval);
L71W32API MSGADDR __stdcall L71_ListAddrEx(INT index,LISTADDR listaddr,LPUSHORT header);
L71W32API MSGADDR __stdcall L71_ListBlockRd(LPUSHORT buf,LISTADDR listaddr,HCARD handleval);
L71W32API MSGADDR __stdcall L71_ListBlockRdEx(LPUSHORT buf,INT index,LISTADDR listaddr,HCARD handleval);
L71W32API MSGADDR __stdcall L71_ListBlockWr(LPUSHORT buf,LISTADDR listaddr,HCARD handleval);
L71W32API MSGADDR __stdcall L71_ListBlockWrEx(LPUSHORT buf,INT index,LISTADDR listaddr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ListClear(LISTADDR listaddr,HCARD handleval);
L71W32API LISTADDR __stdcall L71_ListConfig(ULONG configval,INT count,USHORT skipval,HCARD handleval);
L71W32API LISTADDR __stdcall L71_ListConfigEx(ULONG configval,INT count,USHORT skipval,HCARD handleval);
L71W32API INT __stdcall L71_ListDataRd(LPUSHORT buf,INT count,LISTADDR listaddr,HCARD handleval);
L71W32API INT __stdcall L71_ListDataRdEx(LPUSHORT buf,INT count,INT index,LISTADDR listaddr,HCARD handleval);
L71W32API INT __stdcall L71_ListDataWr(LPUSHORT buf,INT count,LISTADDR listaddr,HCARD handleval);
L71W32API INT __stdcall L71_ListDataWrEx(LPUSHORT buf,INT count,INT index,LISTADDR listaddr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ListInit(LISTADDR listaddr,MSGADDR msgaddr,HCARD handleval);
L71W32API MSGADDR __stdcall L71_ListNextRd(ULONG listaddr,LPUSHORT header);
L71W32API MSGADDR __stdcall L71_ListNextWr(ULONG listaddr,LPUSHORT header);
L71W32API VOID __stdcall L71_ListPostRd(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L71W32API VOID __stdcall L71_ListPostWr(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L71W32API VOID __stdcall L71_ListPreRd(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L71W32API VOID __stdcall L71_ListPreWr(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L71W32API INT __stdcall L71_ListStatus(LISTADDR listaddr,HCARD handleval);
L71W32API ULONG __stdcall L71_MakeLong(USHORT valh,USHORT vall);
L71W32API ULONG __stdcall L71_Mask(ULONG dataval,USHORT cntval);
L71W32API VOID __stdcall L71_MEMWINFillW(USHORT value,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
L71W32API USHORT __stdcall L71_MEMWINRdB(ULONG addrval,INT bustype,HCARD handleval);
L71W32API ULONG __stdcall L71_MEMWINRdL(ULONG addrval,INT bustype,HCARD handleval);
L71W32API VOID __stdcall L71_MEMWINRdsL(LPULONG valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L71W32API VOID __stdcall L71_MEMWINRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L71W32API USHORT __stdcall L71_MEMWINRdW(ULONG addrval,INT bustype,HCARD handleval);
L71W32API VOID __stdcall L71_MEMWINWrB(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
L71W32API VOID __stdcall L71_MEMWINWrL(ULONG value,ULONG addrval,INT bustype,HCARD handleval);
L71W32API VOID __stdcall L71_MEMWINWrsL(LPULONG valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L71W32API VOID __stdcall L71_MEMWINWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L71W32API VOID __stdcall L71_MEMWINWrW(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
L71W32API ULONG __stdcall L71_Mod(ULONG moda,ULONG modb);
L71W32API BOOL __stdcall L71_ModeIsBC(HCARD handleval);
L71W32API BOOL __stdcall L71_ModeIsMon(HCARD handleval);
L71W32API BOOL __stdcall L71_ModeIsNotBC(HCARD handleval);
L71W32API BOOL __stdcall L71_ModeIsNotMon(HCARD handleval);
L71W32API BOOL __stdcall L71_ModeIsNotRT(HCARD handleval);
L71W32API BOOL __stdcall L71_ModeIsNotSerial(HCARD handleval);
L71W32API BOOL __stdcall L71_ModeIsRT(HCARD handleval);
L71W32API BOOL __stdcall L71_ModeIsSerial(HCARD handleval);
L71W32API USHORT __stdcall L71_ModeRd(HCARD handleval);
L71W32API VOID __stdcall L71_ModeWr(USHORT mode,HCARD handleval);
L71W32API ULONG __stdcall L71_MonBlkRd(LPUSHORT buf,ULONG bufcount,LPULONG blkcnt,HCARD handleval);
L71W32API ULONG __stdcall L71_MonBlkRdEx(LPUSHORT buf,ULONG bufcount,ULONG maxblkcnt,LPULONG blkcnt,HCARD handleval);
L71W32API ERRVAL __stdcall L71_MonClear(HCARD handleval);
L71W32API ERRVAL __stdcall L71_MonConfig(ULONG configval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_MonConfigEx(ULONG configval,ULONG moncount,USHORT cardnum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_MonConfigExx(ULONG configval,ULONG seqaddr,ULONG moncount,USHORT cardnum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_MonFilterSA(INT taval,ULONG rcvsamask,ULONG xmtsamask,ULONG rcvmcmask,ULONG xmtmcmask,HCARD handleval);
L71W32API ERRVAL __stdcall L71_MonFilterSAEx(INT taval,ULONG rcvsamask,ULONG xmtsamask,ULONG rcvmcmask,ULONG xmtmcmask,HCARD handleval);
L71W32API ERRVAL __stdcall L71_MonFilterTA(ULONG tamask,HCARD handleval);
L71W32API BOOL __stdcall L71_MonIsRunning(HCARD handleval);
L71W32API USHORT __stdcall L71_MonRd(LPUSHORT buf,HCARD handleval);
L71W32API USHORT __stdcall L71_MonRdEx(LPUSHORT buf,USHORT bufcount,HCARD handleval);
L71W32API BOOL __stdcall L71_MonResume(HCARD handleval);
L71W32API BOOL __stdcall L71_MonStart(HCARD handleval);
L71W32API BOOL __stdcall L71_MonStatus(HCARD handleval);
L71W32API BOOL __stdcall L71_MonStop(HCARD handleval);
L71W32API MSGADDR __stdcall L71_MsgBlockRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
L71W32API MSGADDR __stdcall L71_MsgBlockWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
L71W32API USHORT __stdcall L71_MsgCheck(MSGADDR msgaddr,HCARD handleval);
L71W32API MSGADDR __stdcall L71_MsgCommRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
L71W32API MSGADDR __stdcall L71_MsgCommWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
L71W32API MSGADDR __stdcall L71_MsgConfig(ULONG configval,HCARD handleval);
L71W32API MSGADDR __stdcall L71_MsgConfigEx(ULONG configval,USHORT cwd,HCARD handleval);
L71W32API USHORT __stdcall L71_MsgCWD1Rd(MSGADDR msgaddr,HCARD handleval);
L71W32API VOID __stdcall L71_MsgCWD1Wr(USHORT cwd1,MSGADDR msgaddr,HCARD handleval);
L71W32API USHORT __stdcall L71_MsgCWD2Rd(MSGADDR msgaddr,HCARD handleval);
L71W32API VOID __stdcall L71_MsgCWD2Wr(USHORT cwd2,MSGADDR msgaddr,HCARD handleval);
L71W32API VOID __stdcall L71_MsgDataRd(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
L71W32API VOID __stdcall L71_MsgDataWr(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
L71W32API USHORT __stdcall L71_MsgErrorRd(MSGADDR msgaddr,HCARD handleval);
L71W32API VOID __stdcall L71_MsgErrorWr(USHORT value,MSGADDR msgaddr,HCARD handleval);
L71W32API ULONG __stdcall L71_MsgFieldRd(USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
L71W32API ULONG __stdcall L71_MsgFieldWr(ULONG fieldval,USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
L71W32API USHORT __stdcall L71_MsgFlagRd(MSGADDR msgaddr,HCARD handleval);
L71W32API VOID __stdcall L71_MsgFlagWr(USHORT msgflag,MSGADDR msgaddr,HCARD handleval);
L71W32API BOOL __stdcall L71_MsgIsAccessed(MSGADDR msgaddr,HCARD handleval);
L71W32API USHORT __stdcall L71_MsgOptRd(MSGADDR msgaddr,HCARD handleval);
L71W32API VOID __stdcall L71_MsgOptWr(USHORT msgopt,MSGADDR msgaddr,HCARD handleval);
L71W32API MSGADDR __stdcall L71_MsgReset(MSGADDR msgaddr,HCARD handleval);
L71W32API USHORT __stdcall L71_MsgSWD1Rd(MSGADDR msgaddr,HCARD handleval);
L71W32API USHORT __stdcall L71_MsgSWD2Rd(MSGADDR msgaddr,HCARD handleval);
L71W32API ULONG __stdcall L71_Mul(ULONG mula,ULONG mulb);
L71W32API USHORT __stdcall L71_PortRd(INT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_PortWr(USHORT value,INT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ProcCall(ULONG useraddr,HCARD handleval);
L71W32API ULONG __stdcall L71_ProcLoad(LPVOID userbuf,USHORT count,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ProcRun(LPVOID userbuf,USHORT count,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ProcRunEx(LPVOID userbuf,USHORT count,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ProcSetFore(ULONG useraddr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ProcSetInt(USHORT useraddr,INT intnum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ProcSetPost(ULONG useraddr,MSGADDR msgaddr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ProcSetPre(ULONG useraddr,MSGADDR msgaddr,HCARD handleval);
L71W32API USHORT __stdcall L71_ProgRdW(USHORT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_ProgWrW(USHORT value,USHORT addrval,HCARD handleval);
L71W32API VOID __stdcall L71_RAMFill(USHORT value,ULONG addrval,ULONG countval,HCARD handleval);
L71W32API BOOL __stdcall L71_RAMIsDPM(ULONG addrval);
L71W32API USHORT __stdcall L71_RAMRdB(ULONG addrval,HCARD handleval);
L71W32API ULONG __stdcall L71_RAMRdL(ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_RAMRdsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L71W32API VOID __stdcall L71_RAMRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L71W32API USHORT __stdcall L71_RAMRdW(ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_RAMWipe(HCARD handleval);
L71W32API VOID __stdcall L71_RAMWipeEx(USHORT value,HCARD handleval);
L71W32API VOID __stdcall L71_RAMWrB(USHORT value,ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_RAMWrL(ULONG value,ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_RAMWrsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L71W32API VOID __stdcall L71_RAMWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L71W32API VOID __stdcall L71_RAMWrW(USHORT value,ULONG addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_RcvAlloc(ULONG configval,USHORT framenum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_RcvConfigExx(ULONG rtconfigval,USHORT intfreq,ULONG monconfigval,ULONG intconfigval,USHORT inttotal,ULONG msgconfigval,HCARD handleval);
L71W32API USHORT __stdcall L71_RcvCountRd(HCARD handleval);
L71W32API VOID __stdcall L71_RcvCountWr(USHORT countval,HCARD handleval);
L71W32API USHORT __stdcall L71_RcvDataCountRd(HCARD handleval);
L71W32API VOID __stdcall L71_RcvDataCountWr(USHORT countval,HCARD handleval);
L71W32API MSGADDR __stdcall L71_RcvIndex(USHORT framenum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMChksW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMClose(HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMDisable(HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMEnable(HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMFlush(HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMInfoRd(LPBYTE buf,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMInfoWr(LPBYTE buf,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMOpen(HCARD handleval);
L71W32API VOID __stdcall L71_ROMProg(USHORT enableflag,LPUSHORT dataptr,USHORT cntval,ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_ROMProgg(INT value,ULONG addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMRdsW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMWrsW(USHORT enableflag,LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_ROMWrW(USHORT value,USHORT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_RTConfig(ULONG configval,INT taval,USHORT intfreq,HCARD handleval);
L71W32API ERRVAL __stdcall L71_RTConfigEx(ULONG configval,INT taval,USHORT intfreq,HCARD handleval);
L71W32API ERRVAL __stdcall L71_RTConfigExx(ULONG configval,INT taval,HCARD handleval);
L71W32API MSGADDR __stdcall L71_RTConfigMsg(ULONG configval,MSGADDR msgaddr,HCARD handleval);
L71W32API LISTADDR __stdcall L71_RTCreateList(ULONG listconfigval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API LISTADDR __stdcall L71_RTCreateListEx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API LISTADDR __stdcall L71_RTCreateListExx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API MSGADDR __stdcall L71_RTCreateMsg(ULONG configval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API MSGADDR __stdcall L71_RTGetMsg(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_RTReset(INT taval,HCARD handleval);
L71W32API USHORT __stdcall L71_RTStatus(INT taval,HCARD handleval);
L71W32API USHORT __stdcall L71_RTSWDRd(INT taval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_RTSWDWr(USHORT swdval,INT taval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SchedBuild(INT nummsgs,LPMSGADDR msgaddr,LPINT freq,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SchedBuildEx(INT nummsgs,LPMSGADDR msgaddr,LPINT freq,LPINT period,LPVOID buf,ULONG bufsize,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SchedBuildExx(ULONG frametime,INT nummsgs,LPMSGADDR msgaddr,LPINT period,LPVOID buf,ULONG bufsize,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SchedCalc(LPMSGADDR msgaddr,HCARD handleval);
L71W32API VOID __stdcall L71_SchedDisplay(ULONG nummsgs,LPULONG count);
L71W32API VOID __stdcall L71_SchedHook(INT index,LPVOID ptr);
L71W32API ERRVAL __stdcall L71_SchedInsEnd(HCARD handleval);
L71W32API ERRVAL __stdcall L71_SchedInsMsg(ULONG index,LPMSGADDR msgaddr,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SchedInsStart(ULONG frametime,ULONG count,HCARD handleval);
L71W32API ULONG __stdcall L71_SchedMaxval(LPULONG array,ULONG arraycount);
L71W32API ULONG __stdcall L71_SchedMinval(LPULONG array,ULONG arraycount);
L71W32API VOID __stdcall L71_SchedPrint(LPSTR str,...);
L71W32API ERRVAL __stdcall L71_SEEPokeW(INT value,INT numbits,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SEERdBit(LPINT valueptr,INT bitnum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SEERdL(LPULONG valueptr,INT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SEERdW(LPINT valueptr,INT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SEEWrBit(INT value,INT bitnum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SEEWrL(ULONG value,INT addrval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_SEEWrW(INT value,INT addrval,HCARD handleval);
L71W32API USHORT __stdcall L71_SEMMRdW(ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_SEMMWrW(USHORT value,ULONG addrval,HCARD handleval);
L71W32API USHORT __stdcall L71_SEMRdW(ULONG addrval,HCARD handleval);
L71W32API VOID __stdcall L71_SEMWrW(USHORT value,ULONG addrval,HCARD handleval);
L71W32API ULONG __stdcall L71_Shl(ULONG dataval,USHORT cntval);
L71W32API ULONG __stdcall L71_Shr(ULONG dataval,USHORT cntval);
L71W32API VOID __stdcall L71_TimerClear(HCARD handleval);
L71W32API ULONG __stdcall L71_TimerRd(HCARD handleval);
L71W32API INT __stdcall L71_TimerResolution(INT timerresol,HCARD handleval);
L71W32API USHORT __stdcall L71_TimerResolutionEx(USHORT timershift,HCARD handleval);
L71W32API INT __stdcall L71_ValAsciiCmpi(LPSTR str1,LPSTR str2);
L71W32API LPSTR __stdcall L71_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
L71W32API VOID __stdcall L71_ValAsciiTrimLead(LPSTR buf);
L71W32API VOID __stdcall L71_ValAsciiTrimTrail(LPSTR buf);
L71W32API ULONG __stdcall L71_ValFromAscii(LPCSTR asciistr,INT radixval);
L71W32API USHORT __stdcall L71_ValGetBits(USHORT oldvalue,INT startbit,INT endbit);
L71W32API LPSTR __stdcall L71_ValIncAscii(LPSTR asciistr);
L71W32API LPSTR __stdcall L71_ValInccAscii(LPSTR asciistr);
L71W32API BOOL __stdcall L71_ValIsLower(INT value);
L71W32API INT __stdcall L71_ValLenAscii(INT numbits,INT radixval);
L71W32API USHORT __stdcall L71_ValPackCWD(INT TAval,INT TRflag,INT SAval,INT WCval);
L71W32API USHORT __stdcall L71_ValPackRTCWD(INT MCflag,INT TAval,INT TRflag,INT SAval,INT count);
L71W32API USHORT __stdcall L71_ValPutBits(USHORT oldvalue,USHORT newfld,INT startbit,INT endbit);
L71W32API LPSTR __stdcall L71_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
L71W32API INT __stdcall L71_ValToUpper(INT value);
L71W32API VOID __stdcall L71_ValUnpackCWD(USHORT CWDval,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT WCval);
L71W32API VOID __stdcall L71_ValUnpackRTCWD(USHORT cwd,LPINT BCASTflag,LPINT MCflag,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT count);
L71W32API ERRVAL __stdcall L71_XmtAlloc(ULONG configval,USHORT framecount,HCARD handleval);
L71W32API ERRVAL __stdcall L71_XmtConfigExxx(ULONG bcconfigval,ULONG msgconfigval,USHORT framefreq,USHORT intfreq,USHORT framecount,HCARD handleval);
L71W32API USHORT __stdcall L71_XmtCountRd(HCARD handleval);
L71W32API VOID __stdcall L71_XmtCountWr(USHORT countval,HCARD handleval);
L71W32API USHORT __stdcall L71_XmtDataCountRd(HCARD handleval);
L71W32API VOID __stdcall L71_XmtDataCountWr(USHORT countval,HCARD handleval);
L71W32API ERRVAL __stdcall L71_XmtFreq(USHORT framefreq,HCARD handleval);
L71W32API ERRVAL __stdcall L71_XmtFreqEx(USHORT framefreq,USHORT intfreq,USHORT framecount,HCARD handleval);
L71W32API ERRVAL __stdcall L71_XmtFreqExx(USHORT framefreq,USHORT intfreq,USHORT framecount,ULONG bcconfigval,USHORT bctotal,ULONG intconfigval,USHORT inttotal,ULONG msgconfigval,HCARD handleval);
L71W32API MSGADDR __stdcall L71_XmtIndex(USHORT framenum,HCARD handleval);
L71W32API USHORT __stdcall L71_XmtNumberRd(HCARD handleval);
L71W32API VOID __stdcall L71_XmtNumberWr(USHORT brdnum,HCARD handleval);
L71W32API ERRVAL __stdcall L71_XmtPeriod(ULONG frameperiod,HCARD handleval);
L71W32API ERRVAL __stdcall L71_XmtPeriodEx(ULONG frameperiod,USHORT intfreq,USHORT framecount,HCARD handleval);
L71W32API ERRVAL __stdcall L71_XmtPeriodExx(ULONG frameperiod,USHORT intfreq,USHORT framecount,ULONG bcconfigval,USHORT bctotal,ULONG intconfigval,USHORT inttotal,ULONG msgconfigval,HCARD handleval);
L71W32API USHORT __stdcall L71_XmtSizeRd(HCARD handleval);
L71W32API VOID __stdcall L71_XmtSizeWr(USHORT mode,HCARD handleval);

#ifdef __cplusplus
}
#endif

/**
*
*  Transmitter configuration options
*
**/

#define XMTCFG_DEFAULT      0x00000000L	    //Select all default settings
#define XMTCFG_BUSA         0x00000000L     //Message will be transmitted on bus A (default)
#define XMTCFG_BUSB         0x00000004L     //Message will be transmitted on bus B 
#define XMTCFG_NOSWAP       0x00000000L     //Disable bit swapping (default)
#define XMTCFG_SWAP         0x00004000L     //Enable bit swapping
#define XMTCFG_MODEL        0x00000000L     //Xmt messages are created depending upon model (default)
#define XMTCFG_RAM          0x00100000L     //Xmt messages are created in static RAM
#define XMTCFG_DPRAM        0x00200000L     //Xmt messages are created in dual-port RAM

/**
*
*  Receiver configuration options
*
**/

#define RCVCFG_DEFAULT      0x00000000L     //Select all default settings
#define RCVCFG_BUSA 	    0x00000000L     //Respond to channel A (default)
#define RCVCFG_BUSB	        0x00010000L     //Respond to channel B
#define RCVCFG_NOSWAP       0x00000000L     //Disable bit swapping (default)
#define RCVCFG_SWAP         0x00008000L     //Enable bit swapping
#define RCVCFG_WORDSYNC     0x00000000L     //Sync on words (default)
#define RCVCFG_BITSYNC      0x00080000L	    //Sync on each bit
#define RCVCFG_MODEL        0x00000000L     //Xmt messages are created depending upon model (default)
#define RCVCFG_RAM          0x00100000L     //Xmt messages are created in static RAM
#define RCVCFG_DPRAM        0x00200000L     //Xmt messages are created in dual-port RAM


/**
*
*  Bus controller configuration options
*
**/

#define BCCFG_DEFAULT      0x00000000L      //Select all default settings
#define BCCFG_ENABLE       0x00000000L      //Enable bus controller (default)
#define BCCFG_DISABLE      0x00000001L      //Disable bus controller
#define BCCFG_TRIGNONE     0x00000000L      //No trigger (default)
#define BCCFG_TRIGEXT      0x00000010L      //Trigger external
#define BCCFG_TRIGSTART    0x00000020L      //Trigger external start
#define BCCFG_NOINTHALT    0x00000000L      //Do not generate interrupt on halt (default)
#define BCCFG_INTHALT      0x00000100L      //Generate interrupt on halt
#define BCCFG_NOINTPAUSE   0x00000000L      //Do not generate interrupt on pause (default)
#define BCCFG_INTPAUSE     0x00000200L      //Generate interrupt on pause
#define BCCFG_NOLOOPMAX    0x00000000L      //Disable maximum loop count (default)
#define BCCFG_LOOPMAX      0x00001000L      //Enable maximum loop count
#define BCCFG_NOSTEP       0x00000000L      //Disable single stepping (default)
#define BCCFG_STEP         0x00002000L      //Enable single stepping
#define BCCFG_NOSWAP       0x00000000L      //Disable bit swapping (default)
#define BCCFG_SWAP         0x00004000L      //Enable bit swapping
#define BCCFG_MC01         0x00000000L      //Select SA=00000 or SA=11111 for mode codes (default)
#define BCCFG_MC1          0x01000000L      //Select SA=11111 for mode codes
#define BCCFG_MC0          0x02000000L      //Select SA=00000 for mode codes
#define BCCFG_MCNONE       0x03000000L      //Disable mode codes
#define BCCFG_SYNCALL      0x00000000L      //*Sync on all messages (default)
#define BCCFG_SYNCSEL      0x40000000L      //*Selective sync
#define BCCFG_MODEL        0x00000000L      //BC messages are created in dual-port RAM (default)
#define BCCFG_RAM          0x00100000L      //BC messages are created in static RAM
#define BCCFG_DPRAM        0x00200000L      //BC messages are created in dual-port RAM

/**
*
*  Monitor configuration options
*
**/

#define MONCFG_DEFAULT      0x00000000L     //Select all default settings
#define MONCFG_FILLHALT     0x00000000L     //Enable monitor in fill and halt mode (default)
#define MONCFG_DISABLE      0x00000001L     //Disable monitor
#define MONCFG_CONTINUOUS   0x00000002L     //Enable monitor in continuous mode
#define MONCFG_DMA          0x00000004L     //Enable monitor in dma mode
#define MONCFG_FREE         0x00000008L     //Enable monitor in free mode
#define MONCFG_FAST         0x00000010L     //Enable monitor in fast mode
#define MONCFG_DELTA        0x00000020L     //Enable monitor in delta mode
#define MONCFG_NOINTFULL    0x00000000L     //Do not generate interrupt when monitor full (default)
#define MONCFG_INTFULL      0x00001000L     //Generate interrupt when monitor full
#define MONCFG_COMPLETE     0x00000000L     //Enable receiving complete words (default)
#define MONCFG_INCOMPLETE   0x00002000L     //Enable receiving incomplete words
#define MONCFG_MC01         0x00000000L     //Select SA=00000 or SA=11111 for mode codes (default)
#define MONCFG_MC1          0x00100000L     //Select SA=11111 for mode codes
#define MONCFG_MC0          0x00200000L     //Select SA=00000 for mode codes
#define MONCFG_MCNONE       0x00300000L     //Disable mode codes
#define MONCFG_16K          0x00000000L     //Allocate a 16K monitor buffer (default)
#define MONCFG_ALLAVAIL     0x01000000L     //Allocate all available memory to monitor buffer
#define MONCFG_32K          0x02000000L     //Allocate a 32K monitor buffer
#define MONCFG_64K          0x04000000L     //Allocate a 64K monitor buffer
#define MONCFG_128K         0x08000000L     //Allocate a 128K monitor buffer
#define MONCFG_DPRAM        0x10000000L     //Allocate all available dual-port memory

/**
*
*  Remote terminal configuration options
*
**/

#define RTCFG_DEFAULT      0x00000000L      //Select all default settings
#define RTCFG_SIMULATE     0x00000000L      //Enable RT simulation (default)
#define RTCFG_DISABLE      0x00000001L      //Disable RT
#define RTCFG_MONITOR      0x00000002L      //Enable RT monitor
#define RTCFG_NOBCAST      0x00000000L      //Disable broadcast (default)
#define RTCFG_BCAST        0x00000100L      //Enable broadcast
#define RTCFG_NOAUTOBUSY   0x00000000L      //Disable auto busy (default)
#define RTCFG_AUTOBUSY     0x00000200L      //Enable auto busy
#define RTCFG_BUILD        0x00000000L      //Enable auto building (default)
#define RTCFG_NOBUILD      0x00000400L      //Disable auto building
#define RTCFG_STDB         0x00000000L      //Use MIL-STD-1553B standard (default)
#define RTCFG_STDA         0x00000800L      //Use MIL-STD-1553A standard
#define RTCFG_NODYNBC      0x00000000L      //Do not respond to dynamic BC mode code (default)
#define RTCFG_DYNBC        0x00001000L      //Respond to dynamic BC mode code
#define RTCFG_NOIMMCLR     0x00000000L      //Do not clear status word bits (default)
#define RTCFG_IMMCLR       0x00002000L      //Status word bits are cleared immediately
#define RTCFG_NOBCASTADDR  0x00000000L      //Disable broadcast handling for address (default)
#define RTCFG_BCASTADDR    0x00004000L      //Enable broadcast handling for address
#define RTCFG_NOSWAP       0x00000000L      //Disable bit swapping (default)
#define RTCFG_SWAP         0x00008000L      //Enable bit swapping
#define RTCFG_WORDSYNC     0x00000000L		//Sync on words (default)
#define RTCFG_BITSYNC      0x00080000L		//Sync on each bit
#define RTCFG_CHANAB       0x00000000L      //Respond to both channels (default)
#define RTCFG_CHANA        0x00020000L      //Respond to channel A
#define RTCFG_CHANB        0x00010000L      //Respond to channel B
#define RTCFG_CHANNONE     0x00030000L      //Respond to neither channel A nor B
#define RTCFG_MC01         0x00000000L      //Select SA=00000 or SA=11111 for mode codes (default)
#define RTCFG_MC1          0x01000000L      //Select SA=11111 for mode codes
#define RTCFG_MC0          0x02000000L      //Select SA=00000 for mode codes
#define RTCFG_MCNONE       0x03000000L      //Disable mode codes
#define RTCFG_SYNCALL      0x00000000L      //*Sync on all messages (default)
#define RTCFG_SYNCSEL      0x40000000L      //*Selective sync
#define RTCFG_WIPE         0x00000000L      //Enables message clear (default)
#define RTCFG_NOWIPE       0x80000000L      //Disables message clear
#define RTCFG_WIPE0        0x00000000L      //Initialize data with zeros (default)
#define RTCFG_WIPE123      0x10000000L      //Initialize data with incrementing values
#define RTCFG_WIPECWD      0x20000000L      //Initialize data with command word
#define RTCFG_MODEL        0x00000000L      //RT messages are created in static RAM or dual-port RAM depending upon board model (default)
#define RTCFG_RAM          0x00100000L      //RT messages are created in static RAM
#define RTCFG_DPRAM        0x00200000L      //RT messages are created in dual-port RAM

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

#define INFOTYPE_PLAT      0x0001           //Returns the L71 platform type
#define INFOTYPE_PROD      0x0002           //Returns the L71 product type
#define INFOTYPE_DASH      0x0003           //Returns the L71 dash number
#define INFOTYPE_VERSION   0x0004           //Returns the L71 version number
#define INFOTYPE_DATE      0x0005           //Returns the L71 version date
#define INFOTYPE_TRANSMIT  0x0006           //Returns whether the L71 has a transmitter
#define INFOTYPE_RECEIVE   0x0007           //Returns whether the L71 has a receiver
#define INFOTYPE_MODEL     0x0008           //Returns the L71 model number
#define INFOTYPE_MAXCOUNT  0x0009           //Returns the number of terminals the L71 can simulate
#define INFOTYPE_MULTIMODE 0x000A           //Returns whether L71 can simulate multi-modes
#define INFOTYPE_ERRORGEN  0x000B           //Returns whether L71 can generate errors
#define INFOTYPE_CONCURMON 0x000C           //Returns whether L71 has a concurrent monitor
#define INFOTYPE_MONFILTER 0x000D           //Returns whether L71 has a monitor filter
#define INFOTYPE_USERCODE  0x000E           //Returns whether L71 handles user code
#define INFOTYPE_LISTBUF   0x000F           //Returns whether L71 handles list buffering
#define INFOTYPE_MONFAST   0x0010           //Returns whether L71 has a fast monitor
#define INFOTYPE_MONDMA    0x0011           //Returns whether L71 has a dma monitor
#define INFOTYPE_MONBRAKE  0x0012           //Returns whether L71 has a monitor brake
#define INFOTYPE_DUAL	   0x0013           //Returns whether the L71 has dual xmt/rcv capability
#define INFOTYPE_BITSYNC   0x0014           //Returns whether the L71 has bit sync capability

/**
*
*  Error configuration options
*
**/

#define ERRDEF_NONE       0x00000000L       //Disable error generation (default)
#define ERRDEF_GAP        0x00010000L       //Generate zero crossing error
#define ERRDEF_CNTWRDABS  0x00020000L       //Generate an absolute word count error
#define ERRDEF_CNTWRDREL  0x00040000L       //Generate a relative count error
#define ERRDEF_CNTBIT     0x00080000L       //Generate a bit count error
#define ERRDEF_MAN1       0x00100000L       //Generate manchester error on first half of bit
#define ERRDEF_MAN2       0x00200000L       //Generate manchester error on second half of bit
#define ERRDEF_SYNC       0x00400000L       //Generate a sync error
#define ERRDEF_PAR        0x00800000L       //Generate a parity error
#define ERRDEF_ZEROX      0x01000000L       //Generate zero crossing error

#define ERRDEF_DWD00      0x0000            //Error will be generated in a data word  0
#define ERRDEF_DWD01      0x0001            //Error will be generated in a data word  1
#define ERRDEF_DWD02      0x0002            //Error will be generated in a data word  2
#define ERRDEF_DWD03      0x0003            //Error will be generated in a data word  3
#define ERRDEF_DWD04      0x0004            //Error will be generated in a data word  4
#define ERRDEF_DWD05      0x0005            //Error will be generated in a data word  5
#define ERRDEF_DWD06      0x0006            //Error will be generated in a data word  6
#define ERRDEF_DWD07      0x0007            //Error will be generated in a data word  7
#define ERRDEF_DWD08      0x0008            //Error will be generated in a data word  8
#define ERRDEF_DWD09      0x0009            //Error will be generated in a data word  9
#define ERRDEF_DWD10      0x000A            //Error will be generated in a data word 10
#define ERRDEF_DWD11      0x000B            //Error will be generated in a data word 11
#define ERRDEF_DWD12      0x000C            //Error will be generated in a data word 12
#define ERRDEF_DWD13      0x000D            //Error will be generated in a data word 13
#define ERRDEF_DWD14      0x000E            //Error will be generated in a data word 14
#define ERRDEF_DWD15      0x000F            //Error will be generated in a data word 15
#define ERRDEF_DWD16      0x0010            //Error will be generated in a data word 16
#define ERRDEF_DWD17      0x0011            //Error will be generated in a data word 17
#define ERRDEF_DWD18      0x0012            //Error will be generated in a data word 18
#define ERRDEF_DWD19      0x0013            //Error will be generated in a data word 19
#define ERRDEF_DWD20      0x0014            //Error will be generated in a data word 20
#define ERRDEF_DWD21      0x0015            //Error will be generated in a data word 21
#define ERRDEF_DWD22      0x0016            //Error will be generated in a data word 22
#define ERRDEF_DWD23      0x0017            //Error will be generated in a data word 23
#define ERRDEF_DWD24      0x0018            //Error will be generated in a data word 24
#define ERRDEF_DWD25      0x0019            //Error will be generated in a data word 25
#define ERRDEF_DWD26      0x001A            //Error will be generated in a data word 26
#define ERRDEF_DWD27      0x001B            //Error will be generated in a data word 27
#define ERRDEF_DWD28      0x001C            //Error will be generated in a data word 28
#define ERRDEF_DWD29      0x001D            //Error will be generated in a data word 29
#define ERRDEF_DWD30      0x001E            //Error will be generated in a data word 30
#define ERRDEF_DWD31      0x001F            //Error will be generated in a data word 31
#define ERRDEF_CWD1       0x0100            //Error will be generated in CWD1
#define ERRDEF_CWD2       0x0101            //Error will be generated in CWD2
#define ERRDEF_SWD        0x0102            //Error will be generated in SWD1
#define ERRDEF_SWD1       0x0102            //Error will be generated in SWD1
#define ERRDEF_SWD2       0x0102            //Error will be generated in SWD2

/**
*
*  Error control options
*
**/

#define ERRCTRL_OFF      0x00000000L        //Disable error generation
#define ERRCTRL_ON       0x00000001L        //Enable error generation
#define ERRCTRL_ONCE     0x00000002L        //Enable error generation once
#define ERRCTRL_EXTERNAL 0x00000003L        //Enable externally triggered error generation
#define ERRCTRL_TAGMSG   0x00000000L        //Generate errors on tagged messages
#define ERRCTRL_ANYMSG   0x80000000L        //Generate errors on any message

/**
*
*  Message configuration options
*
**/

#define MSGCRT_DEFAULT     0x00000000L      //Default settings
#define MSGCRT_ENABLE      0x00000000L      //Enable subaddress (RT) (default)
#define MSGCRT_DISABLE     0x00001000L      //Disable subaddress (RT)
#define MSGCRT_RESP        0x00000000L      //Enable response (RT) (default)
#define MSGCRT_NORESP      0x00002000L      //Disable response (RT)
#define MSGCRT_NOWRAP      0x00000000L      //Disable data wrap (RT) (default)
#define MSGCRT_WRAP        0x00004000L      //Enable data wrap (RT)
#define MSGCRT_NOINT       0x00000000L      //Message will generate interrupt (default)
#define MSGCRT_INT         0x00000001L      //Message will not generate interrupt
#define MSGCRT_NOERR       0x00000000L      //No message error will be generated for message (default)
#define MSGCRT_ERR         0x00000002L      //A message error will be generated for message
#define MSGCRT_BUSA        0x00000000L      //Message will be transmitted on bus A (BC) (default)
#define MSGCRT_BUSB        0x00000004L      //Message will be transmitted on bus B (BC)
#define MSGCRT_BCRT        0x00000000L      //Message is a BC-RT transfer (BC) (default)
#define MSGCRT_RTRT        0x00000008L      //Message is an RT-RT transfer (BC)
#define MSGCRT_NOMON       0x00000000L      //Message will not be monitored (default)
#define MSGCRT_MON         0x00000010L      //Message will be monitored
#define MSGCRT_NOTIMETAG   0x00000000L      //Message will not record time-tag (default)
#define MSGCRT_TIMETAG     0x00000040L      //Message will record time-tag
#define MSGCRT_NOELAPSE    0x00000000L      //Message will not record elapse time (default)
#define MSGCRT_ELAPSE      0x00000080L      //Message will record elapse time
#define MSGCRT_NOMIN       0x00000000L      //Message will not record min time (default)
#define MSGCRT_MIN         0x00000100L      //Message will record min time
#define MSGCRT_NOMAX       0x00000000L      //Message will not record max time (default)
#define MSGCRT_MAX         0x00000200L      //Message will record max time
#define MSGCRT_NOHIT       0x00000000L      //Message will not record hit count (default)
#define MSGCRT_HIT         0x00000400L      //Message will record hit count
#define MSGCRT_NOSYNC      0x00000000L      //No sync will be generated for message (default)
#define MSGCRT_SYNC        0x40000000L      //Sync will be generated for message
#define MSGCRT_WIPE        0x00000000L      //Enables message clear (default)
#define MSGCRT_NOWIPE      0x80000000L      //Disables message clear
#define MSGCRT_WIPE0       0x00000000L      //Initialize data with zeros (default)
#define MSGCRT_WIPE123     0x01000000L      //Initialize data with incrementing values
#define MSGCRT_WIPECWD     0x02000000L      //Initialize data with command word
#define MSGCRT_MODEL       0x00000000L      //Message located in static RAM or dual-port RAM depending upon defaults (default)
#define MSGCRT_RAM         0x00100000L      //Message located in static RAM
#define MSGCRT_DPRAM       0x00200000L      //Message located in dual-port RAM

/**
*
*  List buffer options
*
**/

#define LISTCRT_DEFAULT    0x00000000L      //Select all default settings
#define LISTCRT_PINGPONG   0x00000000L      //Enable ping-pong mode (default)
#define LISTCRT_FIFO       0x00000001L      //Enable FIFO mode
#define LISTCRT_CIRCULAR   0x00000002L      //Enable circular mode
#define LISTCRT_TRBIT      0x00000000L      //User will read or write depending upon T/R bit
#define LISTCRT_READ       0x00000010L      //User will read from list buffer
#define LISTCRT_WRITE      0x00000020L      //User will write to list buffer
#define LISTCRT_NOTSKIP    0x00000000L      //Will not skip messages
#define LISTCRT_SKIP       0x00000040L      //Enable message skipping
#define LISTCRT_NOINT      0x00000000L      //Do not generate interrupt when list buffer empty/full (default)
#define LISTCRT_INT        0x00000100L      //Generate interrupt when list buffer empty/full
#define LISTCRT_NOHIT      0x00000000L      //Do not generate interrupt when list is hit (default)
#define LISTCRT_HIT        0x00000200L      //Generate interrupt when list is hit
#define LISTCRT_MODEL      0x00000000L      //List located in static RAM (default)
#define LISTCRT_RAM        0x00100000L      //List located in static RAM
#define LISTCRT_DPRAM      0x00200000L      //List located in dual-port RAM

/**
*
*  Bit fields of the message error flag.
*
**/

#define MSGERR_NORESP       0x8000          //Set when we timeout waiting for response
#define MSGERR_ANYERR       0x4000          //Set when any error bit is set
#define MSGERR_PROTOCOL     0x2000          //General protocol error
#define MSGERR_SYNC         0x1000          //Set when we have the wrong sync
#define MSGERR_DATACOUNT    0x0800          //Set when improper number of data words
#define MSGERR_MANCH        0x0020          //Set when manchester error detected
#define MSGERR_PARITY       0x0010          //Set when parity error detected
#define MSGERR_WORD         0x0008          //Set when word error detected
#define MSGERR_RETRY        0x0004          //All retries failed
#define MSGERR_SYSTEM       0x0002          //An internal system error occurred
#define MSGERR_HIT          0x0001          //Always set

/**
*
*  Bit fields of the message activity flag.
*
**/

#define MSGACT_XMTCWD1      0x8000          //Transmitted CWD1
#define MSGACT_XMTCWD2      0x4000          //Transmitted CWD2
#define MSGACT_XMTSWD1      0x2000          //Transmitted SWD1
#define MSGACT_XMTSWD2      0x1000          //Transmitted SWD2
#define MSGACT_RCVCWD1      0x0800          //Received CWD1
#define MSGACT_RCVCWD2      0x0400          //Received CWD2
#define MSGACT_RCVSWD1      0x0200          //Received SWD1
#define MSGACT_RCVSWD2      0x0100          //Received SWD2
#define MSGACT_XMTDWD       0x0080          //Transmitted DWD
#define MSGACT_RCVDWD       0x0040          //Received DWD

/**
*
*  L71 IFGA Registers
*
**/

#define IREG_STAT   0x0040                  //Status register (RD)
#define IREG_SET    0x0041                  //Set register (WR)
#define IREG_CLR    0x0042                  //Clear register (WR)
#define IREG_ID     0x0043                  //ID register (RD)
#define IREG_PAGE   0x0044                  //Page register
#define IREG_CONFIG 0x0045                  //Configuration register
#define IREG_DINT   0x0046                  //DSP interrupt register
#define IREG_HINT   0x0047                  //HOST interrupt register

/**
*
*  EDGA Registers
*
**/

#define EREG_STAT    0x0180				//Status register (RD)
#define EREG_CTRLE   0x0081				//Encoder control register
#define EREG_VALE    0x0082				//Encoder value register
#define EREG_CFGINT  0x0083				//Interrupt configuration register
#define EREG_CFG     0x0084				//Configuration register
#define EREG_VALD    0x0085				//Encoder value register (RD)
#define EREG_FT      0x0086				//Frame time register
#define EREG_ID      0x0087				//Identification register (RD)
#define EREG_STATCLR 0x008E				//Status clear register (WR)
#define EREG_RST     0x008F				//Reset register (WR)

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
*  Condition flags.
*
**/

#define COND_FAIL    0x0001                 //Condition when all retries have failed
#define COND_SRQ     0x0002                 //Condition on Service Request bit set in status word
#define COND_INS     0x0004                 //Condition on Instrumentation bit set in status word
#define COND_SSF     0x0008                 //Condition on Subsystem Fail bit set in status word
#define COND_TF      0x0010                 //Condition on Terminal Flag bit set in status word
#define COND_BUSY    0x0020                 //Condition on Busy bit set in status word
#define COND_ME      0x0040                 //Condition on Message Error bit set in status word
#define COND_RESPERR 0x0080                 //Condition on response error
#define COND_NORESP  0x0100                 //Condition on response error
#define COND_ALTBUS  0x0200                 //Retries are performed on alternate bus

/**
*
*  Field types.
*
**/

#define FIELD_CWD1   0                      //CWD1 field
#define FIELD_CWD2   1                      //CWD2 field
#define FIELD_SWD1   2                      //SWD1 field
#define FIELD_SWD2   3                      //SWD2 field
#define FIELD_TTAG   4                      //Time tag field
#define FIELD_ELAPSE 5                      //Elapse time field
#define FIELD_ERROR  6                      //Error field
#define FIELD_ACT    7                      //Activity field
#define FIELD_RESP1  8                      //Response time 1 field
#define FIELD_RESP2  9                      //Response time 2 field
#define FIELD_COUNT  10                     //Data count field
#define FIELD_FLAG1  11                     //Flag 1 field
#define FIELD_FLAG2  12                     //Flag 2 field
#define FIELD_RESV   13                     //Reserved field

/**
*
*  Interrupt types.
*
**/

#define INTTYPE_MSG    0x0001               //Message interrupt
#define INTTYPE_OPCODE 0x0002               //Interrupt opcode
#define INTTYPE_HALT   0x0003               //Schedule halt
#define INTTYPE_PAUSE  0x0004               //Schedule pause
#define INTTYPE_SEQ    0x0005               //Sequential record full
#define INTTYPE_LIST   0x0006               //List buffer empty/full
#define INTTYPE_PARITY 0x0007               //Parity error
#define INTTYPE_DIN    0x0008               //DIN

/**
*
*  Timer resolutions.
*
**/

#define TIMERRESOL_1US     1                //1us timer resolution, 1:11:34
#define TIMERRESOL_16US    2                //16us timer resolution, 19:05:19 range
#define TIMERRESOL_1024US  3                //1024us timer resolution, 50 day range

#define MONRD_MAX_COUNT 109

#define SUBADDRESS 0
#define MODECODE   1

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
#define ERR_NOCARD       -13                //CardOpen() could not find a L71 card at the specified address
#define ERR_NOIO         -14                //CardOpen() could not find the I/O ports
#define ERR_NOMEM        -15                //CardOpen() could not find the memory
#define ERR_BAD16BIT     -16                //Card is conflicting with another 16-bit card
#define ERR_WRONGMODEL   -17                //Card does not support this feature
#define ERR_NOSEL        -18                //CardOpen() could not allocate a memory selector
#define ERR_LOCK         -19                //The communication process is locked up
#define ERR_TOOMANY      -20                //Too many terminals have been configured
#define ERR_BADHANDLE    -21                //A bad handle was specified
#define ERR_BADTA        -22                //A bad terminal address was specified
#define ERR_BADFRAME     -23                //A bad frame time was specified
#define ERR_NOTBC        -24                //The BC has not been configured
#define ERR_NOTRT        -25                //The RT has not been configured
#define ERR_NOTMON       -26                //The monitor has not been configured
#define ERR_ALLOC        -27                //There is not enough memory to allocate
#define ERR_VXD          -28                //An error occurred in the VXD
#define ERR_BADMSG       -31                //The specified command block is not a message block
#define ERR_BADSCHNDX    -32                //Specified command index is out of range
#define ERR_BUFSIZE      -33                //Insufficient space in user buffer
#define ERR_NOCONFIG     -34                //The card has not been properly configured
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
#define ERR_RESPONSE     -53                //A bad response or no response was received from an RT
#define ERR_TYPE         -54                //There was a bad type value in the HEX file
#define ERR_ZEROLEN      -55                //Zero length was specified
#define ERR_DMABAD       -61                //Bad DMA channel was specified
#define ERR_DMAODD       -62                //An odd DMA address or count was specified
#define ERR_DMAPAGE      -63                //DMA buffer specified crosses a page boundary
#define ERR_SELFIOFAIL   -71                //I/O selftest failed
#define ERR_SELFMEMFAIL  -72                //Memory selftest failed
#define ERR_SELFCOMMFAIL -73                //Communication selftest failed
#define ERR_SELFXMTFAIL  -74                //Transmit selftest failed
#define ERR_PLXBUG       -75                //PLX bug is causing problems

#endif
