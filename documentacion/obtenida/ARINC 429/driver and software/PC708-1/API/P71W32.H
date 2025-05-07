/**
*
*  PC708-1 WIN32 DRIVER  Version 1.3  (07/14/2000)
*  Copyright (c) 1998-2000
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   P71W32.H -- Visual C++ 32-bit
*                      PC708-1 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for the PC708-1.  Applications
*  using the PC708-1 Driver Library must incorporate this
*  include file using the preprocessor directive #include. 
*  If this file is in the current working directory, the form
*  would be:
*
*  #include "P71W32.H"
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

#ifndef __P71W32_H
#define __P71W32_H

/**
*
*  Typedefs used by the PC708-1 Driver.
*
**/

#ifndef P71W32API
#ifdef __BORLANDC__
#define P71W32API
#else
#define P71W32API __declspec(dllimport)
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
*  PC708-1 Driver functions.
*
**/

P71W32API ERRVAL __stdcall PC708_CardClose(HCARD handleval);
P71W32API HCARD __stdcall PC708_CardOpen(ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval);
P71W32API VOID __stdcall PC708_CardReset(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CardStart(HCARD handleval);
P71W32API BOOL __stdcall PC708_CardStop(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_IntInstall(LPVOID hEvent,HCARD handleval);
P71W32API ULONG __stdcall PC708_IntRd(LPUSHORT typeval,LPUSHORT infoval,HCARD handleval);
P71W32API INT __stdcall PC708_IntStatus(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_IntUninstall(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_RcvConfig(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_RcvConfigEx(ULONG rtconfigval,USHORT intfreq,HCARD handleval);
P71W32API ULONG __stdcall PC708_RcvMonBlkRd(LPUSHORT buf,ULONG bufcount,LPULONG blkcnt,HCARD handleval);
P71W32API ULONG __stdcall PC708_RcvMonBlkRdEx(LPUSHORT buf,ULONG bufcount,ULONG maxblkcnt,LPULONG blkcnt,HCARD handleval);
P71W32API USHORT __stdcall PC708_RcvMonRd(LPUSHORT buf,HCARD handleval);
P71W32API USHORT __stdcall PC708_RcvMonRdEx(LPUSHORT buf,USHORT index,HCARD handleval);
P71W32API BOOL __stdcall PC708_RcvMonStatus(HCARD handleval);
P71W32API VOID __stdcall PC708_RcvRd(LPUSHORT buf,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_XmtConfig(USHORT framefreq,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_XmtConfigEx(USHORT framefreq,USHORT intfreq,USHORT framecount,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_XmtConfigExx(ULONG xmtconfigval,USHORT framefreq,USHORT intfreq,USHORT framecount,HCARD handleval);
P71W32API VOID __stdcall PC708_XmtRd(LPUSHORT buf,USHORT framenum,HCARD handleval);
P71W32API BOOL __stdcall PC708_XmtStatus(HCARD handleval);
P71W32API VOID __stdcall PC708_XmtWr(LPUSHORT buf,USHORT framenum,HCARD handleval);

P71W32API USHORT __stdcall PC708_FieldGetAngle(LPUSHORT buf);
P71W32API FLOAT __stdcall PC708_FieldGetAngleFl(LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldGetControlAccept(LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldGetData(INT binnum, LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldGetDataAccept(LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldGetFaults(LPUSHORT buf);
P71W32API INT __stdcall PC708_FieldGetGain(LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldGetLabel(LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldGetMode(LPUSHORT buf);
P71W32API INT __stdcall PC708_FieldGetRange(LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldGetTilt(LPUSHORT buf);
P71W32API FLOAT __stdcall PC708_FieldGetTiltFl(LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldPutAngle(USHORT value,LPUSHORT buf);
P71W32API FLOAT __stdcall PC708_FieldPutAngleFl(FLOAT angle,LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldPutControlAccept(USHORT value,LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldPutData(USHORT value,INT binnum, LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldPutDataAccept(USHORT value,LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldPutFaults(USHORT value,LPUSHORT buf);
P71W32API INT __stdcall PC708_FieldPutGain(INT gain,LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldPutLabel(USHORT value,LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldPutMode(USHORT value,LPUSHORT buf);
P71W32API INT __stdcall PC708_FieldPutRange(INT range,LPUSHORT buf);
P71W32API USHORT __stdcall PC708_FieldPutTilt(USHORT value,LPUSHORT buf);
P71W32API FLOAT __stdcall PC708_FieldPutTiltFl(FLOAT tilt,LPUSHORT buf);

/**
*
*  Internal functions used by the PC708-1 Driver.
*
**/

P71W32API ULONG __stdcall PC708_AddrDSP(ULONG addr);
P71W32API ULONG __stdcall PC708_AddrHost(ULONG addr);
P71W32API ERRVAL __stdcall PC708_BCConfig(ULONG configval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BCConfigEx(ULONG configval,USHORT count,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_BCConfigMsg(ULONG configval,MSGADDR msgaddr,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_BCCreateMsg(ULONG configval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedAgain(SCHNDX index,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedBranch(USHORT condition,SCHNDX destindex,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedBranchDin0(SCHNDX destindex,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedBranchDin1(SCHNDX destindex,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedBranchEx(USHORT condition1,USHORT condition2,USHORT condition3,SCHNDX destindex,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BCSchedBuild(USHORT nummsgs,LPMSGADDR msgaddr,LPUSHORT freq,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedCall(SCHNDX destindex,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedCallCond(USHORT condition,SCHNDX destindex,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedCallCondEx(USHORT condition1,USHORT condition2,USHORT condition3,SCHNDX destindex,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedEntry(HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedFrame(ULONG timeval,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedFrameEnd(HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedFrameStart(ULONG timeval,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedGap(USHORT gapval,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedGoto(SCHNDX destindex,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedHalt(HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedInt(USHORT tagval,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedIntCond(USHORT condition,USHORT tagval,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedIntCondEx(USHORT condition1,USHORT condition2,USHORT condition3,USHORT tagval,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedMsg(MSGADDR msgaddr,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedNop(HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedPause(HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedPulse(HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedPulse0(HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedPulse1(HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedRestart(HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedRetry(USHORT condition,USHORT retries,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedRetryEx(USHORT condition1,USHORT condition2,USHORT condition3,USHORT retryflag,USHORT retries,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedReturn(HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSchedUser(ULONG useraddr,HCARD handleval);
P71W32API SCHNDX __stdcall PC708_BCSetEntry(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BCSetTimeout(USHORT timeoutval,HCARD handleval);
P71W32API ULONG __stdcall PC708_BlkAddr(INT taval,HCARD handleval);
P71W32API USHORT __stdcall PC708_BlkOptRd(INT taval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BlkOptWr(USHORT rtopt,INT taval,HCARD handleval);
P71W32API ULONG __stdcall PC708_BlkPtrRd(INT taval,HCARD handleval);
P71W32API VOID __stdcall PC708_BlkPtrWr(ULONG descaddr,INT taval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BlkRd(LPUSHORT block,INT taval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BlkReset(INT taval,HCARD handleval);
P71W32API USHORT __stdcall PC708_BlkSWDRd(INT taval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BlkSWDWr(USHORT swdval,INT taval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BlkWipe(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BlkWr(LPUSHORT block,INT taval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootAdd(LPCSTR filename,LPCSTR name,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootAddProc(USHORT value,USHORT addr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootAddr(USHORT index,LPUSHORT addr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootAddrNext(LPUSHORT addr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootCount(LPUSHORT count,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootCrc(USHORT index,LPULONG crc,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootDelete(USHORT index,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootGet(USHORT index,LPCSTR filename,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootInfo(USHORT index,LPUSHORT base,LPUSHORT length,LPSTR name,USHORT namelen,LPULONG crc,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootPtrGet(LPUSHORT index,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootPtrPut(USHORT index,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootRdW(LPUSHORT value,USHORT addr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootStr(USHORT index,LPSTR keystr,LPSTR buf,USHORT bufcount,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_BootWrW(USHORT value,USHORT addr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CardBoot(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CardCloseAll(VOID);
P71W32API ERRVAL __stdcall PC708_CardConfig(BOOL enableflag,USHORT command,USHORT taval,HCARD handleval);
P71W32API ULONG __stdcall PC708_CardGetInfo(USHORT infotype,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CardGetInfoEx(LPUSHORT bufmodel,USHORT bufmodelcount,LPUSHORT buffeature,USHORT buffeaturecount,HCARD handleval);
P71W32API VOID __stdcall PC708_CardInit(VOID);
P71W32API BOOL __stdcall PC708_CardIsRunning(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CardNop(HCARD handleval);
P71W32API HCARD __stdcall PC708_CardOpenEx(LPCSTR cardname,ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval);
P71W32API HCARD __stdcall PC708_CardOpenExx(LPCSTR cardname,ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval,LPVOID hAppWnd,USHORT uiRemovalMsg);
P71W32API VOID __stdcall PC708_CardResetEx(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CardResume(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CardTest(USHORT level,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CardTest0(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CardTest1(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CardTest2(HCARD handleval);
P71W32API VOID __stdcall PC708_CardTrigger(HCARD handleval);
P71W32API ULONG __stdcall PC708_CmdAddr(SCHNDX index,HCARD handleval);
P71W32API ULONG __stdcall PC708_CmdAlloc(USHORT count,HCARD handleval);
P71W32API ULONG __stdcall PC708_CmdBaseRd(HCARD handleval);
P71W32API VOID __stdcall PC708_CmdBaseWr(ULONG addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CmdClear(HCARD handleval);
P71W32API USHORT __stdcall PC708_CmdCountRd(HCARD handleval);
P71W32API VOID __stdcall PC708_CmdCountWr(USHORT countval,HCARD handleval);
P71W32API USHORT __stdcall PC708_CmdCtrlRd(SCHNDX index,HCARD handleval);
P71W32API VOID __stdcall PC708_CmdCtrlWr(USHORT ctrlval,SCHNDX index,HCARD handleval);
P71W32API USHORT __stdcall PC708_CmdCurrRd(HCARD handleval);
P71W32API VOID __stdcall PC708_CmdCurrWr(USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_CmdInit(USHORT opcode,LPUSHORT block);
P71W32API SCHNDX __stdcall PC708_CmdInsert(LPUSHORT block,HCARD handleval);
P71W32API USHORT __stdcall PC708_CmdMaxRd(HCARD handleval);
P71W32API VOID __stdcall PC708_CmdMaxWr(USHORT count,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CmdRd(LPUSHORT block,ULONG addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CmdSkipWr(BOOL value,SCHNDX index,HCARD handleval);
P71W32API VOID __stdcall PC708_CmdStackClr(HCARD handleval);
P71W32API USHORT __stdcall PC708_CmdStartRd(HCARD handleval);
P71W32API VOID __stdcall PC708_CmdStartWr(USHORT addrval,HCARD handleval);
P71W32API INT __stdcall PC708_CmdTotalRd(HCARD handleval);
P71W32API VOID __stdcall PC708_CmdTotalWr(INT countval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CmdWr(LPUSHORT block,ULONG addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CommCall(ULONG addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CommCheck(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CommDisable(USHORT command,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CommEnable(HCARD handleval);
P71W32API ULONG __stdcall PC708_CommRdL(ULONG addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CommRdsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
P71W32API USHORT __stdcall PC708_CommRdW(ULONG addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CommRun(LPUSHORT dataptr,USHORT datacount,LPUSHORT codeptr,USHORT codecount,HCARD handleval);
P71W32API VOID __stdcall PC708_CommWrL(ULONG value,ULONG addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_CommWrsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
P71W32API VOID __stdcall PC708_CommWrW(USHORT value,ULONG addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_DARClr(USHORT maskval,USHORT addrval,HCARD handleval);
P71W32API BOOL __stdcall PC708_DARGet(USHORT maskval,USHORT addrval,HCARD handleval);
P71W32API ULONG __stdcall PC708_DARRdL(USHORT addrval,HCARD handleval);
P71W32API USHORT __stdcall PC708_DARRdW(USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_DARSet(USHORT maskval,USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_DARWrL(ULONG value,USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_DARWrW(USHORT value,USHORT addrval,HCARD handleval);
P71W32API ULONG __stdcall PC708_Div(ULONG diva,ULONG divb);
P71W32API INT __stdcall PC708_DllUsageCount(VOID);
P71W32API USHORT __stdcall PC708_DspBioRd(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_DspIntfClear(HCARD handleval);
P71W32API BOOL __stdcall PC708_DspIntfRead(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_DspIntmClear(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_DspIntmSet(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_DspXfClear(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_DspXfSet(HCARD handleval);
P71W32API LPCSTR __stdcall PC708_ErrDesc(INT errval);
P71W32API LPCSTR __stdcall PC708_ErrDescStr(INT errval);
P71W32API LPCSTR __stdcall PC708_ErrName(INT errval);
P71W32API ERRVAL __stdcall PC708_ErrorDefine(BOOL busb,USHORT intfreq,HCARD handleval);
P71W32API BOOL __stdcall PC708_ExtDinRd(HCARD handleval);
P71W32API VOID __stdcall PC708_ExtDinWr(BOOL dinval,HCARD handleval);
P71W32API BOOL __stdcall PC708_ExtDoutRd(HCARD handleval);
P71W32API VOID __stdcall PC708_ExtDoutWr(BOOL doutval,HCARD handleval);
P71W32API VOID __stdcall PC708_FileClose(LPVOID handle);
P71W32API BOOL __stdcall PC708_FileErr(VOID);
P71W32API VOID __stdcall PC708_FileErrClr(VOID);
P71W32API VOID __stdcall PC708_FileErrSet(VOID);
P71W32API LPVOID __stdcall PC708_FileOpenRead(LPCSTR filename);
P71W32API LPVOID __stdcall PC708_FileOpenWrite(LPCSTR filename);
P71W32API BOOL __stdcall PC708_FileRead(LPVOID handle,LPVOID buffer,USHORT count);
P71W32API BOOL __stdcall PC708_FileSeek(LPVOID handle,ULONG offset);
P71W32API ULONG __stdcall PC708_FileTell(LPVOID handle);
P71W32API BOOL __stdcall PC708_FileWrite(LPVOID handle,LPVOID buffer,USHORT count);
P71W32API USHORT __stdcall PC708_GetHigh(ULONG val);
P71W32API USHORT __stdcall PC708_GetLow(ULONG val);
P71W32API USHORT __stdcall PC708_GlobalRdW(USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_GlobalWrW(USHORT value,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_HandleDel(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_HandleGet(LPULONG memval,LPULONG sizval,LPULONG ioval,LPUSHORT irqval,LPUSHORT drqval,HCARD handleval);
P71W32API HCARD __stdcall PC708_HandleGetIo(USHORT ioval);
P71W32API HCARD __stdcall PC708_HandleGetMem(ULONG memval);
P71W32API HCARD __stdcall PC708_HandleIns(LPCSTR cardname,ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval,LPVOID hAppWnd,USHORT uiRemovalMsg);
P71W32API BOOL __stdcall PC708_HandleOkay(HCARD handleval);
P71W32API ULONG __stdcall PC708_HeapAlloc(ULONG wordcount,HCARD handleval);
P71W32API ULONG __stdcall PC708_HeapAllocAll(LPULONG wordcount,HCARD handleval);
P71W32API ULONG __stdcall PC708_HeapAllocEx(USHORT configval,ULONG wordcount,HCARD handleval);
P71W32API ULONG __stdcall PC708_HeapWipe(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_HexRd(LPCSTR fname,ERRVAL (__stdcall *proc)(USHORT value,USHORT addr,HCARD handleval),HCARD handleval);
P71W32API ERRVAL __stdcall PC708_HexRun(LPCSTR fname,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_HexRunProc(USHORT value,USHORT addr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_HexStat(LPUSHORT lowaddr,LPUSHORT highaddr,LPUSHORT count,LPCSTR fname);
P71W32API ERRVAL __stdcall PC708_HexStatProc(USHORT value,USHORT addr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_HexWrAddr(USHORT addr);
P71W32API ERRVAL __stdcall PC708_HexWrByte(BYTE ch);
P71W32API ERRVAL __stdcall PC708_HexWrClose(void);
P71W32API ERRVAL __stdcall PC708_HexWrFlush(void);
P71W32API ERRVAL __stdcall PC708_HexWrFlushByte(USHORT value);
P71W32API ERRVAL __stdcall PC708_HexWrOpen(LPCSTR fname);
P71W32API USHORT __stdcall PC708_IndirectRd(USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_IndirectWr(USHORT value,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_IntClear(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_IntConfig(ULONG configval,USHORT count,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_IntDisable(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_IntEnable(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_IntEnableCond(HCARD handleval);
P71W32API LPVOID __stdcall PC708_IntGet(HCARD handleval);
P71W32API VOID __stdcall PC708_IntReset(HCARD handleval);
P71W32API USHORT __stdcall PC708_IORdW(USHORT addrval,HCARD handleval);
P71W32API USHORT __stdcall PC708_IOWINRdW(USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_IOWINWrW(USHORT value,USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_IOWrW(USHORT value,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernBegin(LPVOID *vxdptr,LPCSTR cardname,ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval);
P71W32API ERRVAL __stdcall PC708_KernDev(LPULONG valueptr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernEnd(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernIntClear(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernIntInstall(LPVOID hEvent,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernIntStatus(LPINT valueptr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernIntUninstall(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernIORdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernIOWrW(USHORT value,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernMEMFillW(USHORT value,USHORT addrval,USHORT countval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernMEMRdsW(LPUSHORT bufptr,USHORT addrval,USHORT countval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernMEMRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernMEMWrsW(LPUSHORT bufptr,USHORT addrval,USHORT countval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernMEMWrW(USHORT value,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_KernStatus(LPULONG valueptr,ULONG type,HCARD handleval);
P71W32API ULONG __stdcall PC708_ListConfig(ULONG configval,USHORT count,HCARD handleval);
P71W32API ULONG __stdcall PC708_MakeLong(USHORT valh,USHORT vall);
P71W32API ULONG __stdcall PC708_Mask(ULONG dataval,USHORT cntval);
P71W32API USHORT __stdcall PC708_MEMWINRdB(ULONG addrval,HCARD handleval);
P71W32API ULONG __stdcall PC708_MEMWINRdL(ULONG addrval,HCARD handleval);
P71W32API USHORT __stdcall PC708_MEMWINRdW(ULONG addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_MEMWINWrB(USHORT value,ULONG addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_MEMWINWrL(ULONG value,ULONG addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_MEMWINWrW(USHORT value,ULONG addrval,HCARD handleval);
P71W32API ULONG __stdcall PC708_Mod(ULONG moda,ULONG modb);
P71W32API BOOL __stdcall PC708_ModeIsBC(HCARD handleval);
P71W32API BOOL __stdcall PC708_ModeIsMon(HCARD handleval);
P71W32API BOOL __stdcall PC708_ModeIsNotBC(HCARD handleval);
P71W32API BOOL __stdcall PC708_ModeIsNotMon(HCARD handleval);
P71W32API BOOL __stdcall PC708_ModeIsNotRT(HCARD handleval);
P71W32API BOOL __stdcall PC708_ModeIsNotSerial(HCARD handleval);
P71W32API BOOL __stdcall PC708_ModeIsRT(HCARD handleval);
P71W32API BOOL __stdcall PC708_ModeIsSerial(HCARD handleval);
P71W32API USHORT __stdcall PC708_ModeRd(HCARD handleval);
P71W32API VOID __stdcall PC708_ModeWr(USHORT mode,HCARD handleval);
P71W32API ULONG __stdcall PC708_MonBlkRd(LPUSHORT buf,ULONG bufcount,LPULONG blkcnt,HCARD handleval);
P71W32API ULONG __stdcall PC708_MonBlkRdEx(LPUSHORT buf,ULONG bufcount,ULONG maxblkcnt,LPULONG blkcnt,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_MonClear(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_MonConfig(ULONG configval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_MonConfigEx(ULONG configval,ULONG moncount,USHORT cardnum,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_MonConfigExx(ULONG configval,ULONG seqaddr,ULONG moncount,USHORT cardnum,HCARD handleval);
P71W32API BOOL __stdcall PC708_MonIsRunning(HCARD handleval);
P71W32API USHORT __stdcall PC708_MonRd(LPUSHORT buf,HCARD handleval);
P71W32API USHORT __stdcall PC708_MonRdEx(LPUSHORT buf,USHORT bufcount,HCARD handleval);
P71W32API BOOL __stdcall PC708_MonResume(HCARD handleval);
P71W32API BOOL __stdcall PC708_MonStart(HCARD handleval);
P71W32API BOOL __stdcall PC708_MonStatus(HCARD handleval);
P71W32API BOOL __stdcall PC708_MonStop(HCARD handleval);
P71W32API MSGADDR __stdcall PC708_MsgBlockRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_MsgBlockWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
P71W32API USHORT __stdcall PC708_MsgCheck(MSGADDR msgaddr,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_MsgCommRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_MsgCommWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_MsgConfig(ULONG configval,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_MsgConfigEx(ULONG configval,USHORT cwd,HCARD handleval);
P71W32API USHORT __stdcall PC708_MsgCWD1Rd(MSGADDR msgaddr,HCARD handleval);
P71W32API VOID __stdcall PC708_MsgCWD1Wr(USHORT cwd1,MSGADDR msgaddr,HCARD handleval);
P71W32API USHORT __stdcall PC708_MsgCWD2Rd(MSGADDR msgaddr,HCARD handleval);
P71W32API VOID __stdcall PC708_MsgCWD2Wr(USHORT cwd2,MSGADDR msgaddr,HCARD handleval);
P71W32API VOID __stdcall PC708_MsgDataRd(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
P71W32API VOID __stdcall PC708_MsgDataWr(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
P71W32API USHORT __stdcall PC708_MsgErrorRd(MSGADDR msgaddr,HCARD handleval);
P71W32API VOID __stdcall PC708_MsgErrorWr(USHORT value,MSGADDR msgaddr,HCARD handleval);
P71W32API ULONG __stdcall PC708_MsgFieldRd(USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
P71W32API ULONG __stdcall PC708_MsgFieldWr(ULONG fieldval,USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
P71W32API USHORT __stdcall PC708_MsgFlagRd(MSGADDR msgaddr,HCARD handleval);
P71W32API VOID __stdcall PC708_MsgFlagWr(USHORT msgflag,MSGADDR msgaddr,HCARD handleval);
P71W32API BOOL __stdcall PC708_MsgIsAccessed(MSGADDR msgaddr,HCARD handleval);
P71W32API USHORT __stdcall PC708_MsgOptRd(MSGADDR msgaddr,HCARD handleval);
P71W32API VOID __stdcall PC708_MsgOptWr(USHORT msgopt,MSGADDR msgaddr,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_MsgReset(MSGADDR msgaddr,HCARD handleval);
P71W32API USHORT __stdcall PC708_MsgSWD1Rd(MSGADDR msgaddr,HCARD handleval);
P71W32API USHORT __stdcall PC708_MsgSWD2Rd(MSGADDR msgaddr,HCARD handleval);
P71W32API ULONG __stdcall PC708_Mul(ULONG mula,ULONG mulb);
P71W32API USHORT __stdcall PC708_PortRd(USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_PortWr(USHORT value,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ProcCall(ULONG useraddr,HCARD handleval);
P71W32API ULONG __stdcall PC708_ProcLoad(LPVOID userbuf,USHORT count,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ProcRun(LPVOID userbuf,USHORT count,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ProcSetFore(ULONG useraddr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ProcSetInt(USHORT useraddr,INT intnum,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ProcSetPost(ULONG useraddr,MSGADDR msgaddr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ProcSetPre(ULONG useraddr,MSGADDR msgaddr,HCARD handleval);
P71W32API USHORT __stdcall PC708_ProgRdW(USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_ProgWrW(USHORT value,USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_RAMFill(USHORT value,ULONG addrval,ULONG countval,HCARD handleval);
P71W32API USHORT __stdcall PC708_RAMRdB(ULONG addrval,HCARD handleval);
P71W32API ULONG __stdcall PC708_RAMRdL(ULONG addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_RAMRdsW(LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
P71W32API VOID __stdcall PC708_RAMRdsxW(LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
P71W32API USHORT __stdcall PC708_RAMRdW(ULONG addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_RAMWipe(HCARD handleval);
P71W32API VOID __stdcall PC708_RAMWipeEx(USHORT value,HCARD handleval);
P71W32API VOID __stdcall PC708_RAMWrB(USHORT value,ULONG addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_RAMWrL(ULONG value,ULONG addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_RAMWrsW(LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
P71W32API VOID __stdcall PC708_RAMWrsxW(LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
P71W32API VOID __stdcall PC708_RAMWrW(USHORT value,ULONG addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_RcvAlloc(USHORT framenum,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_RcvConfigExx(ULONG rtconfigval,USHORT intfreq,ULONG monconfigval,ULONG intconfigval,USHORT inttotal,ULONG msgconfigval,HCARD handleval);
P71W32API USHORT __stdcall PC708_RcvCountRd(HCARD handleval);
P71W32API VOID __stdcall PC708_RcvCountWr(USHORT countval,HCARD handleval);
P71W32API USHORT __stdcall PC708_RcvDataCountRd(HCARD handleval);
P71W32API VOID __stdcall PC708_RcvDataCountWr(USHORT countval,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_RcvIndex(USHORT framenum,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMChksW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMClose(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMDisable(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMEnable(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMFlush(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMInfoRd(LPBYTE buf,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMInfoWr(LPBYTE buf,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMOpen(HCARD handleval);
P71W32API VOID __stdcall PC708_ROMProg(USHORT enableflag,LPUSHORT dataptr,USHORT cntval,ULONG addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMRdsW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMWrsW(USHORT enableflag,LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_ROMWrW(USHORT value,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_RTConfig(ULONG configval,INT taval,USHORT intfreq,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_RTConfigEx(ULONG configval,INT taval,USHORT intfreq,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_RTConfigExx(ULONG configval,INT taval,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_RTConfigMsg(ULONG configval,MSGADDR msgaddr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_RTReset(INT taval,HCARD handleval);
P71W32API USHORT __stdcall PC708_RTStatus(INT taval,HCARD handleval);
P71W32API USHORT __stdcall PC708_RTSWDRd(INT taval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_RTSWDWr(USHORT swdval,INT taval,HCARD handleval);
P71W32API USHORT __stdcall PC708_SARRdW(USHORT addrval,HCARD handleval);
P71W32API VOID __stdcall PC708_SARWrW(USHORT value,USHORT addrval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_SchedBuild(USHORT nummsgs,LPMSGADDR msgaddr,LPUSHORT freq,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_SchedBuildEx(USHORT nummsgs,LPMSGADDR msgaddr,LPUSHORT freq,LPUSHORT period,LPVOID buf,USHORT bufsize,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_SchedBuildExx(ULONG frametime,USHORT nummsgs,LPMSGADDR msgaddr,LPUSHORT period,LPVOID buf,USHORT bufsize,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_SchedCalc(LPMSGADDR msgaddr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_SchedInsEnd(HCARD handleval);
P71W32API ERRVAL __stdcall PC708_SchedInsMsg(USHORT index,LPMSGADDR msgaddr,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_SchedInsStart(ULONG frametime,USHORT count,HCARD handleval);
P71W32API USHORT __stdcall PC708_SchedMaxval(LPUSHORT array,USHORT arraycount);
P71W32API USHORT __stdcall PC708_SchedMinval(LPUSHORT array,USHORT arraycount);
P71W32API ULONG __stdcall PC708_Shl(ULONG dataval,USHORT cntval);
P71W32API ULONG __stdcall PC708_Shr(ULONG dataval,USHORT cntval);
P71W32API VOID __stdcall PC708_TimerClear(HCARD handleval);
P71W32API ULONG __stdcall PC708_TimerRd(HCARD handleval);
P71W32API INT __stdcall PC708_TimerResolution(INT timerresol,HCARD handleval);
P71W32API USHORT __stdcall PC708_TimerResolutionEx(USHORT timershift,HCARD handleval);
P71W32API INT __stdcall PC708_ValAsciiCmpi(LPSTR str1,LPSTR str2);
P71W32API LPSTR __stdcall PC708_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
P71W32API VOID __stdcall PC708_ValAsciiTrimLead(LPSTR buf);
P71W32API VOID __stdcall PC708_ValAsciiTrimTrail(LPSTR buf);
P71W32API ULONG __stdcall PC708_ValFromAscii(LPCSTR asciistr,INT radixval);
P71W32API USHORT __stdcall PC708_ValGetBits(USHORT oldvalue,INT startbit,INT endbit);
P71W32API LPSTR __stdcall PC708_ValIncAscii(LPSTR asciistr);
P71W32API LPSTR __stdcall PC708_ValInccAscii(LPSTR asciistr);
P71W32API BOOL __stdcall PC708_ValIsLower(INT value);
P71W32API INT __stdcall PC708_ValLenAscii(INT numbits,INT radixval);
P71W32API USHORT __stdcall PC708_ValPackCWD(INT TAval,INT TRflag,INT SAval,INT WCval);
P71W32API USHORT __stdcall PC708_ValPackRTCWD(INT MCflag,INT TAval,INT TRflag,INT SAval,INT count);
P71W32API USHORT __stdcall PC708_ValPutBits(USHORT oldvalue,USHORT newfld,INT startbit,INT endbit);
P71W32API LPSTR __stdcall PC708_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
P71W32API INT __stdcall PC708_ValToUpper(INT value);
P71W32API VOID __stdcall PC708_ValUnpackCWD(USHORT CWDval,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT WCval);
P71W32API VOID __stdcall PC708_ValUnpackRTCWD(USHORT cwd,LPINT BCASTflag,LPINT MCflag,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT count);
P71W32API ERRVAL __stdcall PC708_XmtAlloc(USHORT framecount,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_XmtConfigExxx(ULONG bcconfigval,ULONG msgconfigval,USHORT framefreq,USHORT intfreq,USHORT framecount,HCARD handleval);
P71W32API USHORT __stdcall PC708_XmtCountRd(HCARD handleval);
P71W32API VOID __stdcall PC708_XmtCountWr(USHORT countval,HCARD handleval);
P71W32API USHORT __stdcall PC708_XmtDataCountRd(HCARD handleval);
P71W32API VOID __stdcall PC708_XmtDataCountWr(USHORT countval,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_XmtFreq(USHORT framefreq,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_XmtFreqEx(USHORT framefreq,USHORT intfreq,USHORT framecount,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_XmtFreqExx(USHORT framefreq,USHORT intfreq,USHORT framecount,ULONG bcconfigval,USHORT bctotal,ULONG intconfigval,USHORT inttotal,ULONG msgconfigval,HCARD handleval);
P71W32API MSGADDR __stdcall PC708_XmtIndex(USHORT framenum,HCARD handleval);
P71W32API USHORT __stdcall PC708_XmtNumberRd(HCARD handleval);
P71W32API VOID __stdcall PC708_XmtNumberWr(USHORT brdnum,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_XmtPeriod(ULONG frameperiod,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_XmtPeriodEx(ULONG frameperiod,USHORT intfreq,USHORT framecount,HCARD handleval);
P71W32API ERRVAL __stdcall PC708_XmtPeriodExx(ULONG frameperiod,USHORT intfreq,USHORT framecount,ULONG bcconfigval,USHORT bctotal,ULONG intconfigval,USHORT inttotal,ULONG msgconfigval,HCARD handleval);
P71W32API VOID __stdcall PC708_XmtRd(LPUSHORT buf,USHORT framenum,HCARD handleval);
P71W32API VOID __stdcall PC708_XmtSizeWr(USHORT mode,HCARD handleval);


#ifdef __cplusplus
}
#endif

/**
*
*  Transmitter configuration options
*
**/

#define XMTCFG_DEFAULT       0x00000000L	//Select all default settings
#define XMTCFG_BUSA          0x00000000L    //Message will be transmitted on bus A (default)
#define XMTCFG_BUSB          0x00000004L    //Message will be transmitted on bus B 
#define XMTCFG_NOSWAP		 0x00000000L	//Disable bit swapping (default)
#define XMTCFG_SWAP			 0x00004000L	//Enable bit swapping

/**
*
*  Receiver configuration options
*
**/

#define RCVCFG_DEFAULT       0x00000000L	//Select all default settings
#define RCVCFG_BUSA 	     0x00000000L	//Respond to channel A (default)
#define RCVCFG_BUSB	         0x00010000L	//Respond to channel B
#define RCVCFG_NOSWAP		 0x00000000L	//Disable bit swapping (default)
#define RCVCFG_SWAP			 0x00008000L	//Enable bit swapping
#define RCVCFG_WORDSYNC      0x00000000L	//Sync on words (default)
#define RCVCFG_BITSYNC       0x00080000L	//Sync on each bit


/**
*
*  Bus controller configuration options
*
**/

#define BCCFG_DEFAULT       0x00000000L     //Select all default settings
#define BCCFG_ENABLE        0x00000000L     //Enable bus controller (default)
#define BCCFG_DISABLE       0x00000001L     //Disable bus controller
#define BCCFG_TRIGNONE      0x00000000L     //No trigger (default)
#define BCCFG_TRIGEXT       0x00000010L     //Trigger external
#define BCCFG_TRIGSTART     0x00000020L     //Trigger external start
#define BCCFG_NOINTHALT     0x00000000L     //Do not generate interrupt on halt (default)
#define BCCFG_INTHALT       0x00000100L     //Generate interrupt on halt
#define BCCFG_NOINTPAUSE    0x00000000L     //Do not generate interrupt on pause (default)
#define BCCFG_INTPAUSE      0x00000200L     //Generate interrupt on pause
#define BCCFG_NOLOOPMAX     0x00000000L     //Disable maximum loop count (default)
#define BCCFG_LOOPMAX       0x00001000L     //Enable maximum loop count
#define BCCFG_NOSTEP        0x00000000L     //Disable single stepping (default)
#define BCCFG_STEP          0x00002000L     //Enable single stepping
#define BCCFG_NOSWAP		0x00000000L		//Disable bit swapping (default)
#define BCCFG_SWAP			0x00004000L		//Enable bit swapping
#define BCCFG_MC01          0x00000000L     //Select SA=00000 or SA=11111 for mode codes (default)
#define BCCFG_MC1           0x01000000L     //Select SA=11111 for mode codes
#define BCCFG_MC0           0x02000000L     //Select SA=00000 for mode codes
#define BCCFG_MCNONE        0x03000000L     //Disable mode codes
#define BCCFG_SYNCALL       0x00000000L     //*Sync on all messages (default)
#define BCCFG_SYNCSEL       0x40000000L     //*Selective sync

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
#define RTCFG_NOSWAP       0x00000000L		//Disable bit swapping (default)
#define RTCFG_SWAP         0x00008000L		//Enable bit swapping
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
#define RTCFG_WIPE123      0x01000000L      //Initialize data with incrementing values
#define RTCFG_WIPECWD      0x02000000L      //Initialize data with command word

/**
*
*  Serial configuration options
*
**/

#define SERCFG_DEFAULT      0x00000000L     //Select all default settings
#define SERCFG_CONTINUOUS   0x00000000L     //Enable continuous mode (default)
#define SERCFG_DISABLE      0x00000001L     //Disable free mode
#define SERCFG_FREE         0x00000002L     //Enable free mode
#define SERCFG_NOINTEMPTY   0x00000000L     //Do not generate interrupt when empty (default)
#define SERCFG_INTEMPTY     0x00000010L     //Generate interrupt when empty

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
*  Monitor configuration options
*
**/

#define LISTCFG_DEFAULT    0x00000000L      //Select all default settings
#define LISTCFG_PINGPONG   0x00000000L      //Enable ping-pong mode (default)
#define LISTCFG_DISABLE    0x00000001L      //Disable list buffer
#define LISTCFG_CONTINUOUS 0x00000002L      //Enable continuous mode
#define LISTCFG_FREE       0x00000004L      //Enable free mode
#define LISTCFG_NOINT      0x00000000L      //Do not generate interrupt when list buffer empty/full (default)
#define LISTCFG_INT        0x00000010L      //Generate interrupt when list buffer empty/full

/**
*
*  Info types
*
**/

#define INFOTYPE_PLAT      0x0001		//Returns the PC708 platform type
#define INFOTYPE_PROD      0x0002		//Returns the PC708 product type
#define INFOTYPE_REV       0x0003		//Returns the PC708 revision number
#define INFOTYPE_VERSION   0x0004		//Returns the PC708 version number
#define INFOTYPE_DATE      0x0005		//Returns the PC708 version date
#define INFOTYPE_TRANSMIT  0x0006		//Returns whether the PC708 has a transmitter
#define INFOTYPE_RECEIVE   0x0007		//Returns whether the PC708 has a receiver
#define INFOTYPE_DASH      0x0008		//Returns the PC708 dash number
#define INFOTYPE_MODEL     0x0009		//Returns the PC708 model number
#define INFOTYPE_MAXCOUNT  0x000A		//Returns the number of terminals the PC1553-3 can simulate
#define INFOTYPE_MULTIMODE 0x000B		//Returns whether PC708 can simulate multi-modes
#define INFOTYPE_ERRORGEN  0x000C		//Returns whether PC708 can generate errors
#define INFOTYPE_CONCURMON 0x000D		//Returns whether PC708 has a concurrent monitor
#define INFOTYPE_MONFILTER 0x000E		//Returns whether PC708 has a monitor filter
#define INFOTYPE_USERCODE  0x000F		//Returns whether PC708 handles user code
#define INFOTYPE_LISTBUF   0x0010		//Returns whether PC708 handles list buffering
#define INFOTYPE_MONFAST   0x0011		//Returns whether PC708 has a fast monitor
#define INFOTYPE_MONDMA    0x0012		//Returns whether PC708 has a dma monitor
#define INFOTYPE_DUAL	   0x0013		//Returns whether PC708 has dual xmt/rcv capability
#define INFOTYPE_BITSYNC   0x0014		//Returns whether PC708 has bit sync capability

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

#define MSGCRT_DEFAULT    0x00000000L       //Default settings
#define MSGCRT_ENABLE     0x00000000L       //Enable subaddress (RT) (default)
#define MSGCRT_DISABLE    0x00001000L       //Disable subaddress (RT)
#define MSGCRT_RESP       0x00000000L       //Enable response (RT) (default)
#define MSGCRT_NORESP     0x00002000L       //Disable response (RT)
#define MSGCRT_NOWRAP     0x00000000L       //Disable data wrap (RT) (default)
#define MSGCRT_WRAP       0x00004000L       //Enable data wrap (RT)
#define MSGCRT_NOINT      0x00000000L       //Message will generate interrupt (default)
#define MSGCRT_INT        0x00000001L       //Message will not generate interrupt
#define MSGCRT_NOERR      0x00000000L       //No message error will be generated for message (default)
#define MSGCRT_ERR        0x00000002L       //A message error will be generated for message
#define MSGCRT_BUSA       0x00000000L       //Message will be transmitted on bus A (BC) (default)
#define MSGCRT_BUSB       0x00000004L       //Message will be transmitted on bus B (BC)
#define MSGCRT_BCRT       0x00000000L       //Message is a BC-RT transfer (BC) (default)
#define MSGCRT_RTRT       0x00000008L       //Message is an RT-RT transfer (BC)
#define MSGCRT_NOMON      0x00000000L       //Message will not be monitored (default)
#define MSGCRT_MON        0x00000010L       //Message will be monitored
#define MSGCRT_NOTIMETAG  0x00000000L       //Message will not record time-tag (default)
#define MSGCRT_TIMETAG    0x00000040L       //Message will record time-tag
#define MSGCRT_NOELAPSE   0x00000000L       //Message will not record elapse time (default)
#define MSGCRT_ELAPSE     0x00000080L       //Message will record elapse time
#define MSGCRT_NOMIN      0x00000000L       //Message will not record min time (default)
#define MSGCRT_MIN        0x00000100L       //Message will record min time
#define MSGCRT_NOMAX      0x00000000L       //Message will not record max time (default)
#define MSGCRT_MAX        0x00000200L       //Message will record max time
#define MSGCRT_NOHIT      0x00000000L       //Message will not record hit count (default)
#define MSGCRT_HIT        0x00000400L       //Message will record hit count
#define MSGCRT_NOSYNC     0x00000000L       //No sync will be generated for message (default)
#define MSGCRT_SYNC       0x40000000L       //Sync will be generated for message
#define MSGCRT_WIPE       0x00000000L       //Enables message clear (default)
#define MSGCRT_NOWIPE     0x80000000L       //Disables message clear
#define MSGCRT_WIPE0      0x00000000L       //Initialize data with zeros (default)
#define MSGCRT_WIPE123    0x01000000L       //Initialize data with incrementing values
#define MSGCRT_WIPECWD    0x02000000L       //Initialize data with command word

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
*  P71 Host Registers
*
**/

#define HREG_CTRL   0x00                    //Host control register (WR)
#define HREG_STAT   0x00                    //Host status register (RD)
#define HREG_CONFIG 0x01                    //Configuration register (RD/WR)
#define HREG_CMAIL  0x02                    //Controller mailbox register (WR)
#define HREG_HMAIL  0x03                    //Host mailbox register (RD)
#define HREG_ACCESS 0x04                    //Access register (RD/WR)
#define HREG_PAGE   0x05                    //Page register (RD/WR)
#define HREG_INDSEL 0x06                    //Indirect register select (RD/WR)
#define HREG_INDVAL 0x07                    //Indirect register value (RD/WR)

/**
*
*  P12 Host Registers
*
**/

#define HREG_RESP    0x00                   //Response register (RD)
#define HREG_CTRL0   0x00                   //Control 0 register (WR)
#define HREG_CTRL1   0x01                   //Control 1 register (WR)
#define HREG_CTRL2   0x02                   //Control 2 register (WR)
#define HREG_TRIG    0x04                   //Transmit trigger register (WR)
#define HREG_INTCLR  0x05                   //Interrupt clear register (WR)
#define HREG_SYNCCLR 0x06                   //Sync clear register (WR)

/**
*
*  P71 Host Indirect Registers
*
**/

#define IREG_CTRL0   0x00                   //Control register 0 (RD/WR)
#define IREG_CTRL1   0x01                   //Control register 1 (RD/WR)
#define IREG_CTRL2   0x02                   //Control register 2 (RD/WR)
#define IREG_DMA     0x03                   //DMA register (RD/WR)
#define IREG_TRIG    0x04                   //Transmit trigger (WR)
#define IREG_RESP    0x04                   //Response register (RD)
#define IREG_INTCLR  0x05                   //Interrupt clear (RD/WR)
#define IREG_SYNCCLR 0x06                   //Sync clear (RD/WR)

/**
*
*  DSP Registers
*
**/

#define DREG_HOST  0x2C40                   //Host status register (RD)
#define DREG_INT   0x2C41                   //Interrupt register
#define DREG_CMAIL 0x2C42                   //Controller mailbox register
#define DREG_HMAIL 0x2C43                   //Host mailbox register
#define DREG_DMA   0x2C44                   //DMA register
#define DREG_PAGE  0x2C45                   //Page register
#define DREG_CTRL  0x2C48                   //Control from host register
#define DREG_RESP  0x2C49                   //Response to host register
#define DREG_SWD   0x2C4A                   //Status word from host register
#define DREG_HINT  0x2C4C                   //Host interrupt register
#define DREG_DIN   0x2C4D                   //DIN register
#define DREG_DOUT  0x2C4E                   //DOUT register

/**
*
*  EDGA Registers
*
**/

#define EREG_STAT    0xAC80				//Status register (RD)
#define EREG_CTRLE   0x2C81				//Encoder control register
#define EREG_VALE    0x2C82				//Encoder value register
#define EREG_CFGINT  0x2C83				//Interrupt configuration register
#define EREG_CFG     0x2C84				//Configuration register
#define EREG_VALD    0x2C85				//Encoder value register (RD)
#define EREG_FT      0x2C86				//Frame time register
#define EREG_ID      0x2C87				//Identification register (RD)
#define EREG_STATCLR 0x2C8E				//Status clear register (WR)
#define EREG_RST     0x2C8F				//Reset register (WR)

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

#define ERR_NONE          0                 //No error
#define ERR_UNKNOWN      -1                 //An unexpected error occurred
#define ERR_BADVER       -2                 //A bad version was encountered
#define ERR_BADPARAMS    -11                //CardOpen() called with bad parameters
#define ERR_NOHANDLES    -12                //CardOpen() already has allocated too many handles
#define ERR_NOCARD       -13                //CardOpen() could not find a PC708-1 card at the specified address
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

#endif
