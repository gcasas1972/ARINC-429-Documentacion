/**
*
*  LP1553-3 and LC1553-3 WIN32 DRIVER  Version 2.2.1  (02/01/2008)
*  Copyright (c) 1997-2008
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   L13W32.H -- Visual C++ 32-bit
*                      L13 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for the L13.  Applications
*  using the L13 Driver Library must incorporate this
*  include file using the preprocessor directive #include. 
*  If this file is in the current working directory, the form
*  would be:
*
*  #include "L13W32.H"
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

#ifndef __L13W32_H
#define __L13W32_H

/**
*
*  Typedefs used by the L13 Driver.
*
**/

#ifndef L13W32API
#ifdef __BORLANDC__
#define L13W32API
#else
#define L13W32API __declspec(dllimport)
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
*  Structs used by the L13 Driver.
*
**/

#ifndef XMITFIELDS

typedef struct
{
    ULONG  ctrlflags;           //User writes message configuration options
    USHORT flag1;               //Card writes message flag 1
    USHORT flag2;               //Card writes message flag 2
    USHORT errflags;            //Card writes error flags
    USHORT actflags;            //Card writes activity flags
    USHORT resptime1;           //Card writes response time 1
    USHORT resptime2;           //Card writes response time 2
    USHORT datacount;           //Card writes data count
    USHORT resv7;               //Reserved field
    ULONG  timetag;             //Card writes time tag
    ULONG  elapsetime;          //Card writes elapsed time
    USHORT resv12;              //Reserved field
    USHORT resv13;              //Reserved field
    USHORT resv14;              //Reserved field
    USHORT resv15;              //Reserved field
    USHORT resv16;              //Reserved field
    USHORT resv17;              //Reserved field
    USHORT resv18;              //Reserved field
    USHORT resv19;              //Reserved field
    USHORT cwd1;                //User writes command word 1
    USHORT cwd2;                //User writes command word 2
    USHORT swd1;                //Card writes status word 1
    USHORT swd2;                //Card writes status word 2
    USHORT data[32];            //User writes data words
    USHORT extra[8];            //User writes extra words
} XMITFIELDS;

#endif

#ifndef LPXMITFIELDS
typedef XMITFIELDS * LPXMITFIELDS;
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
*  L13 Driver functions.
*
**/

L13W32API ERRVAL __stdcall L13_BCConfig(ULONG configval,HCARD handleval);
L13W32API LISTADDR __stdcall L13_BCCreateList(ULONG listconfigval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
L13W32API MSGADDR __stdcall L13_BCCreateMsg(ULONG configval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedFrame(ULONG timeval,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedMsg(MSGADDR msgaddr,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedRetry(USHORT condition,USHORT retries,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BCTransmitMsg(LPXMITFIELDS xmitfields,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BCTransmitMsgEx(LPXMITFIELDS xmitfields,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardClose(HCARD handleval);
L13W32API HCARD __stdcall L13_CardOpen(INT cardnum);
L13W32API VOID __stdcall L13_CardReset(HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardStart(HCARD handleval);
L13W32API BOOL __stdcall L13_CardStop(HCARD handleval);
L13W32API ERRVAL __stdcall L13_ErrorCtrl(ULONG ctrlval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ErrorDefine(ULONG defineval,USHORT errvalue,INT countval,USHORT wordpos,USHORT bitpos,HCARD handleval);
L13W32API BOOL __stdcall L13_ErrorSent(HCARD handleval);
L13W32API ERRVAL __stdcall L13_ErrorTagBC(BOOL tagval,MSGADDR msgaddr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ErrorTagRT(BOOL tagval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_IntConfig(USHORT configval,USHORT count,HCARD handleval);
L13W32API INT __stdcall L13_ListDataRd(LPUSHORT buf,INT count,LISTADDR listaddr,HCARD handleval);
L13W32API INT __stdcall L13_ListDataWr(LPUSHORT buf,INT count,LISTADDR listaddr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_MonConfig(ULONG configval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_MonFilterSA(INT taval,ULONG rcvsamask,ULONG xmtsamask,ULONG rcvmcmask,ULONG xmtmcmask,HCARD handleval);
L13W32API ERRVAL __stdcall L13_MonFilterTA(ULONG tamask,HCARD handleval);
L13W32API BOOL __stdcall L13_MonIsRunning(HCARD handleval);
L13W32API USHORT __stdcall L13_MonRd(LPUSHORT buf,HCARD handleval);
L13W32API VOID __stdcall L13_MsgDataRd(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
L13W32API VOID __stdcall L13_MsgDataWr(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
L13W32API ULONG __stdcall L13_MsgFieldRd(USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
L13W32API ULONG __stdcall L13_MsgFieldWr(ULONG fieldval,USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_PlayConfig(ULONG configval,HCARD handleval);
L13W32API USHORT __stdcall L13_PlayWr(LPUSHORT buf,HCARD handleval);
L13W32API ERRVAL __stdcall L13_RTConfig(ULONG configval,INT taval,HCARD handleval);
L13W32API LISTADDR __stdcall L13_RTCreateList(ULONG listconfigval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API MSGADDR __stdcall L13_RTCreateMsg(ULONG configval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API MSGADDR __stdcall L13_RTGetMsg(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_RTSWDWr(USHORT swdval,INT taval,HCARD handleval);
L13W32API USHORT __stdcall L13_ValPackCWD(INT TAval,INT TRflag,INT SAval,INT WCval);
L13W32API VOID __stdcall L13_ValUnpackCWD(USHORT CWDval,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT WCval);

/**
*
*  Internal functions used by the L13 Driver.
*
**/

L13W32API ULONG __stdcall L13_AddrDSP(ULONG addr);
L13W32API ULONG __stdcall L13_AddrHost(ULONG addr);
L13W32API ERRVAL __stdcall L13_BCConfigEx(ULONG configval,USHORT count,HCARD handleval);
L13W32API MSGADDR __stdcall L13_BCConfigMsg(ULONG configval,MSGADDR msgaddr,HCARD handleval);
L13W32API LISTADDR __stdcall L13_BCCreateListEx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
L13W32API LISTADDR __stdcall L13_BCCreateListExx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
L13W32API MSGADDR __stdcall L13_BCGetMsg(INT index,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedAgain(SCHNDX index,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedBranch(USHORT condition,SCHNDX destindex,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedBranchDin0(SCHNDX destindex,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedBranchDin1(SCHNDX destindex,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedBranchEx(USHORT condition1,USHORT condition2,USHORT condition3,SCHNDX destindex,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BCSchedBuild(USHORT nummsgs,LPMSGADDR msgaddr,LPUSHORT freq,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedCall(SCHNDX destindex,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedCallCond(USHORT condition,SCHNDX destindex,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedCallCondEx(USHORT condition1,USHORT condition2,USHORT condition3,SCHNDX destindex,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedEntry(HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedFrameEnd(HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedFrameStart(ULONG timeval,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedGap(USHORT gapval,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedGoto(SCHNDX destindex,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedHalt(HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedInt(USHORT tagval,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedIntCond(USHORT condition,USHORT tagval,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedIntCondEx(USHORT condition1,USHORT condition2,USHORT condition3,USHORT tagval,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedNop(HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedPause(HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedPulse(HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedPulse0(HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedPulse1(HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedRestart(HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedRetryEx(USHORT condition1,USHORT condition2,USHORT condition3,USHORT retryflag,USHORT retries,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedReturn(HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSchedUser(ULONG useraddr,HCARD handleval);
L13W32API SCHNDX __stdcall L13_BCSetEntry(HCARD handleval);
L13W32API ERRVAL __stdcall L13_BCSetTimeout(USHORT timeoutval,HCARD handleval);
L13W32API ULONG __stdcall L13_BlkAddr(INT taval,HCARD handleval);
L13W32API USHORT __stdcall L13_BlkOptRd(INT taval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BlkOptWr(USHORT rtopt,INT taval,HCARD handleval);
L13W32API ULONG __stdcall L13_BlkPtrRd(INT taval,HCARD handleval);
L13W32API VOID __stdcall L13_BlkPtrWr(ULONG descaddr,INT taval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BlkRd(LPUSHORT block,INT taval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BlkReset(INT taval,HCARD handleval);
L13W32API USHORT __stdcall L13_BlkSWDRd(INT taval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BlkSWDWr(USHORT swdval,INT taval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BlkWipe(HCARD handleval);
L13W32API ERRVAL __stdcall L13_BlkWr(LPUSHORT block,INT taval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootAdd(LPCSTR filename,LPCSTR name,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootAddProc(USHORT value,USHORT addr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootAddr(INT index,LPUSHORT addr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootAddrNext(LPUSHORT addr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootCount(LPUSHORT count,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootCrc(USHORT index,LPULONG crc,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootDelete(USHORT index,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootGet(USHORT index,LPCSTR filename,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootInfo(USHORT index,LPUSHORT base,LPUSHORT length,LPSTR name,USHORT namelen,LPULONG crc,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootPtrGet(LPUSHORT index,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootPtrPut(USHORT index,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootRdW(LPUSHORT value,USHORT addr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootStr(USHORT index,LPSTR keystr,LPSTR buf,USHORT bufcount,HCARD handleval);
L13W32API ERRVAL __stdcall L13_BootWrW(USHORT value,USHORT addr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardBoot(HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardCloseAll(VOID);
L13W32API ERRVAL __stdcall L13_CardConfig(BOOL enableflag,USHORT command,USHORT taval,HCARD handleval);
L13W32API ULONG __stdcall L13_CardGetInfo(USHORT infotype,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardGetInfoEx(LPUSHORT bufmodel,USHORT bufmodelcount,LPUSHORT buffeature,USHORT buffeaturecount,HCARD handleval);
L13W32API VOID __stdcall L13_CardInit(VOID);
L13W32API BOOL __stdcall L13_CardIsRunning(HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardNop(HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardNopEx(HCARD handleval);
L13W32API HCARD __stdcall L13_CardOpenEx(LPCSTR cardname,INT cardnum);
L13W32API HCARD __stdcall L13_CardOpenExx(LPCSTR cardname,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
L13W32API VOID __stdcall L13_CardResetEx(HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardResume(HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardTest(USHORT level,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardTest0(HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardTest1(HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardTest2(HCARD handleval);
L13W32API ERRVAL __stdcall L13_CardTest3(HCARD handleval);
L13W32API VOID __stdcall L13_CardTrigger(HCARD handleval);
L13W32API ULONG __stdcall L13_CFGRdL(INT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_CFGWrL(ULONG value,INT addrval,HCARD handleval);
L13W32API ULONG __stdcall L13_CmdAddr(SCHNDX index,HCARD handleval);
L13W32API ULONG __stdcall L13_CmdAlloc(INT count,HCARD handleval);
L13W32API ULONG __stdcall L13_CmdAllocEx(ULONG configval,INT count,HCARD handleval);
L13W32API ULONG __stdcall L13_CmdBaseRd(HCARD handleval);
L13W32API VOID __stdcall L13_CmdBaseWr(ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CmdClear(HCARD handleval);
L13W32API USHORT __stdcall L13_CmdCountRd(HCARD handleval);
L13W32API VOID __stdcall L13_CmdCountWr(USHORT countval,HCARD handleval);
L13W32API USHORT __stdcall L13_CmdCtrlRd(SCHNDX index,HCARD handleval);
L13W32API VOID __stdcall L13_CmdCtrlWr(USHORT ctrlval,SCHNDX index,HCARD handleval);
L13W32API USHORT __stdcall L13_CmdCurrRd(HCARD handleval);
L13W32API VOID __stdcall L13_CmdCurrWr(USHORT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_CmdInit(USHORT opcode,LPUSHORT block);
L13W32API SCHNDX __stdcall L13_CmdInsert(LPUSHORT block,HCARD handleval);
L13W32API USHORT __stdcall L13_CmdMaxRd(HCARD handleval);
L13W32API VOID __stdcall L13_CmdMaxWr(USHORT count,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CmdRd(LPUSHORT block,ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CmdShotWr(BOOL value,SCHNDX index,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CmdSkipWr(BOOL value,SCHNDX index,HCARD handleval);
L13W32API VOID __stdcall L13_CmdStackClr(HCARD handleval);
L13W32API USHORT __stdcall L13_CmdStartRd(HCARD handleval);
L13W32API VOID __stdcall L13_CmdStartWr(USHORT addrval,HCARD handleval);
L13W32API INT __stdcall L13_CmdTotalRd(HCARD handleval);
L13W32API VOID __stdcall L13_CmdTotalWr(INT countval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CmdWr(LPUSHORT block,ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CommCall(ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CommCheck(HCARD handleval);
L13W32API ERRVAL __stdcall L13_CommDisable(USHORT command,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CommDisableEx(USHORT command,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CommEnable(HCARD handleval);
L13W32API ULONG __stdcall L13_CommRdL(ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CommRdsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
L13W32API USHORT __stdcall L13_CommRdW(ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CommRun(LPUSHORT dataptr,USHORT datacount,LPUSHORT codeptr,USHORT codecount,HCARD handleval);
L13W32API VOID __stdcall L13_CommWrL(ULONG value,ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_CommWrsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
L13W32API VOID __stdcall L13_CommWrW(USHORT value,ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_DARClr(USHORT maskval,USHORT addrval,HCARD handleval);
L13W32API BOOL __stdcall L13_DARGet(USHORT maskval,USHORT addrval,HCARD handleval);
L13W32API ULONG __stdcall L13_DARRdL(USHORT addrval,HCARD handleval);
L13W32API USHORT __stdcall L13_DARRdW(USHORT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_DARSet(USHORT maskval,USHORT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_DARWrL(ULONG value,USHORT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_DARWrW(USHORT value,USHORT addrval,HCARD handleval);
L13W32API ULONG __stdcall L13_DescAddr(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API ULONG __stdcall L13_DescAlloc(HCARD handleval);
L13W32API ERRVAL __stdcall L13_DescConfig(ULONG configval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API USHORT __stdcall L13_DescOptRd(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API VOID __stdcall L13_DescOptWr(USHORT descopt,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API MSGADDR __stdcall L13_DescPtrRd(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API ULONG __stdcall L13_DescPtrWr(MSGADDR msgaddr,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API ULONG __stdcall L13_DescRd(BOOL mcflag,INT taval,BOOL trflag,INT saval,LPUSHORT desc,HCARD handleval);
L13W32API ULONG __stdcall L13_DescWr(BOOL mcflag,INT taval,BOOL trflag,INT saval,LPUSHORT desc,HCARD handleval);
L13W32API ULONG __stdcall L13_Div(ULONG diva,ULONG divb);
L13W32API INT __stdcall L13_DllUsageCount(VOID);
L13W32API USHORT __stdcall L13_DPMMRdW(ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_DPMMWrW(USHORT value,ULONG addrval,HCARD handleval);
L13W32API USHORT __stdcall L13_DPMRdB(ULONG addrval,HCARD handleval);
L13W32API ULONG __stdcall L13_DPMRdL(ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_DPMRdsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L13W32API VOID __stdcall L13_DPMRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L13W32API USHORT __stdcall L13_DPMRdW(ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_DPMWrB(USHORT value,ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_DPMWrL(ULONG value,ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_DPMWrsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L13W32API VOID __stdcall L13_DPMWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L13W32API VOID __stdcall L13_DPMWrW(USHORT value,ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_DspBioClear(HCARD handleval);
L13W32API USHORT __stdcall L13_DspBioRd(HCARD handleval);
L13W32API ERRVAL __stdcall L13_DspBioSet(HCARD handleval);
L13W32API ERRVAL __stdcall L13_DspHmClear(HCARD handleval);
L13W32API ERRVAL __stdcall L13_DspHmSet(HCARD handleval);
L13W32API ERRVAL __stdcall L13_DspIntfClear(HCARD handleval);
L13W32API BOOL __stdcall L13_DspIntfRead(HCARD handleval);
L13W32API ERRVAL __stdcall L13_DspIntmClear(HCARD handleval);
L13W32API ERRVAL __stdcall L13_DspIntmSet(HCARD handleval);
L13W32API ERRVAL __stdcall L13_DspXfClear(HCARD handleval);
L13W32API ERRVAL __stdcall L13_DspXfSet(HCARD handleval);
L13W32API LPCSTR __stdcall L13_ErrDesc(INT errval);
L13W32API LPCSTR __stdcall L13_ErrDescStr(INT errval);
L13W32API LPCSTR __stdcall L13_ErrName(INT errval);
L13W32API BOOL __stdcall L13_ErrorIsTaggedBC(MSGADDR msgaddr,HCARD handleval);
L13W32API BOOL __stdcall L13_ErrorIsTaggedRT(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ErrorResponse(USHORT responseval,HCARD handleval);
L13W32API VOID __stdcall L13_ErrorSync(BOOL value,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ErrorTimeout(USHORT timeoutval,HCARD handleval);
L13W32API VOID __stdcall L13_ErrorWatch(BOOL value,HCARD handleval);
L13W32API VOID __stdcall L13_ErrorWatchWr(ULONG value,HCARD handleval);
L13W32API VOID __stdcall L13_ErrorWatchWrEx(ULONG value,HCARD handleval);
L13W32API BOOL __stdcall L13_ExtDinRd(HCARD handleval);
L13W32API VOID __stdcall L13_ExtDinWr(BOOL dinval,HCARD handleval);
L13W32API BOOL __stdcall L13_ExtDoutRd(HCARD handleval);
L13W32API VOID __stdcall L13_ExtDoutWr(BOOL doutval,HCARD handleval);
L13W32API VOID __stdcall L13_FileClose(LPVOID handle);
L13W32API BOOL __stdcall L13_FileErr(VOID);
L13W32API VOID __stdcall L13_FileErrClr(VOID);
L13W32API VOID __stdcall L13_FileErrSet(VOID);
L13W32API LPVOID __stdcall L13_FileOpenRead(LPCSTR filename);
L13W32API LPVOID __stdcall L13_FileOpenWrite(LPCSTR filename);
L13W32API BOOL __stdcall L13_FileRead(LPVOID handle,LPVOID buffer,USHORT count);
L13W32API BOOL __stdcall L13_FileSeek(LPVOID handle,ULONG offset);
L13W32API ULONG __stdcall L13_FileTell(LPVOID handle);
L13W32API BOOL __stdcall L13_FileWrite(LPVOID handle,LPVOID buffer,USHORT count);
L13W32API USHORT __stdcall L13_GetHigh(ULONG val);
L13W32API USHORT __stdcall L13_GetLow(ULONG val);
L13W32API USHORT __stdcall L13_GlobalRdW(USHORT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_GlobalWrW(USHORT value,USHORT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_HandleClose(HCARD handleval);
L13W32API ERRVAL __stdcall L13_HandleDel(HCARD handleval);
L13W32API ERRVAL __stdcall L13_HandleGet(LPSTR cardstr,LPINT cardnum,LPINT devnum,LPULONG sizval,HCARD handleval);
L13W32API HCARD __stdcall L13_HandleIns(LPCSTR cardname,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
L13W32API BOOL __stdcall L13_HandleOkay(HCARD handleval);
L13W32API ERRVAL __stdcall L13_HandleOpen(LPCSTR cardname,INT cardnum,HCARD handleval);
L13W32API ERRVAL __stdcall L13_HandleOpenWin95(LPCSTR cardname,INT cardnum,HCARD handleval);
L13W32API ERRVAL __stdcall L13_HandleOpenWinNT(LPCSTR cardname,INT cardnum,HCARD handleval);
L13W32API ERRVAL __stdcall L13_HandleVer(HCARD handleval);
L13W32API ERRVAL __stdcall L13_HandleVerPLX(HCARD handleval);
L13W32API ULONG __stdcall L13_HeapAlloc(ULONG wordcount,HCARD handleval);
L13W32API ULONG __stdcall L13_HeapAllocAll(LPULONG wordcount,HCARD handleval);
L13W32API ULONG __stdcall L13_HeapAllocAllDPM(LPUSHORT wordcount,HCARD handleval);
L13W32API ULONG __stdcall L13_HeapAllocDPM(USHORT wordcount,HCARD handleval);
L13W32API ULONG __stdcall L13_HeapAllocEx(USHORT configval,ULONG wordcount,HCARD handleval);
L13W32API ULONG __stdcall L13_HeapWipe(HCARD handleval);
L13W32API ULONG __stdcall L13_HeapWipeDPM(HCARD handleval);
L13W32API ERRVAL __stdcall L13_HexRd(LPCSTR fname,ERRVAL (__stdcall *proc)(USHORT value,USHORT addr,HCARD handleval),HCARD handleval);
L13W32API ERRVAL __stdcall L13_HexRun(LPCSTR fname,HCARD handleval);
L13W32API ERRVAL __stdcall L13_HexRunProc(USHORT value,USHORT addr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_HexStat(LPUSHORT lowaddr,LPUSHORT highaddr,LPUSHORT count,LPCSTR fname);
L13W32API ERRVAL __stdcall L13_HexStatProc(USHORT value,USHORT addr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_HexWrAddr(USHORT addr);
L13W32API ERRVAL __stdcall L13_HexWrByte(BYTE ch);
L13W32API ERRVAL __stdcall L13_HexWrClose(void);
L13W32API ERRVAL __stdcall L13_HexWrFlush(void);
L13W32API ERRVAL __stdcall L13_HexWrFlushByte(USHORT value);
L13W32API ERRVAL __stdcall L13_HexWrOpen(LPCSTR fname);
L13W32API USHORT __stdcall L13_IndirectRd(INT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_IndirectWr(USHORT value,INT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_IntClear(HCARD handleval);
L13W32API ERRVAL __stdcall L13_IntDisable(HCARD handleval);
L13W32API ERRVAL __stdcall L13_IntEnable(HCARD handleval);
L13W32API ERRVAL __stdcall L13_IntEnableCond(HCARD handleval);
L13W32API LPVOID __stdcall L13_IntGet(HCARD handleval);
L13W32API ERRVAL __stdcall L13_IntInstall(LPVOID hEvent,HCARD handleval);
L13W32API ULONG __stdcall L13_IntRd(LPUSHORT typeval,LPUSHORT infoval,HCARD handleval);
L13W32API VOID __stdcall L13_IntReset(HCARD handleval);
L13W32API INT __stdcall L13_IntStatus(HCARD handleval);
L13W32API ERRVAL __stdcall L13_IntUninstall(HCARD handleval);
L13W32API USHORT __stdcall L13_IORdW(INT addrval,HCARD handleval);
L13W32API USHORT __stdcall L13_IOWINRdW(USHORT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_IOWINWrW(USHORT value,USHORT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_IOWrW(USHORT value,INT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernBegin(LPVOID *vxdptr,LPSTR cardstr,LPCSTR cardname,INT busnum,INT devnum,INT funcnum);
L13W32API ERRVAL __stdcall L13_KernDev(LPINT valueptr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernEnd(LPVOID vxdptr);
L13W32API ERRVAL __stdcall L13_KernIntClear(HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernIntInstall(LPVOID hEvent,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernIntParam(ULONG clraddr,ULONG clrwidth,ULONG clrvalue,ULONG stataddr,ULONG statwidth,ULONG statvalue,ULONG statmask,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernIntStatus(LPINT valueptr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernIntUninstall(HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernIORdW(LPUSHORT valueptr,INT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernIOWrW(USHORT value,INT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernMEMFillW(USHORT value,INT addrval,INT countval,INT bustype,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernMEMRdL(LPULONG valueptr,INT addrval,INT bustype,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernMEMRdsL(LPULONG bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernMEMRdsW(LPUSHORT bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernMEMRdW(LPUSHORT valueptr,INT addrval,INT bustype,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernMEMWrL(ULONG value,INT addrval,INT bustype,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernMEMWrsL(LPULONG bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernMEMWrsW(LPUSHORT bufptr,INT addrval,INT countval,INT bustype,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernMEMWrW(USHORT value,INT addrval,INT bustype,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernQuick(BOOL flag,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernStatus(LPULONG valueptr,ULONG type,HCARD handleval);
L13W32API ERRVAL __stdcall L13_KernStatusEx(LPULONG valueptr,ULONG type,ULONG index,HCARD handleval);
L13W32API MSGADDR __stdcall L13_ListAddr(INT index,LISTADDR listaddr,HCARD handleval);
L13W32API MSGADDR __stdcall L13_ListAddrEx(INT index,LISTADDR listaddr,LPUSHORT header);
L13W32API MSGADDR __stdcall L13_ListBlockRd(LPUSHORT buf,LISTADDR listaddr,HCARD handleval);
L13W32API MSGADDR __stdcall L13_ListBlockRdEx(LPUSHORT buf,INT index,LISTADDR listaddr,HCARD handleval);
L13W32API MSGADDR __stdcall L13_ListBlockWr(LPUSHORT buf,LISTADDR listaddr,HCARD handleval);
L13W32API MSGADDR __stdcall L13_ListBlockWrEx(LPUSHORT buf,INT index,LISTADDR listaddr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ListClear(LISTADDR listaddr,HCARD handleval);
L13W32API LISTADDR __stdcall L13_ListConfig(ULONG configval,INT count,USHORT skipval,HCARD handleval);
L13W32API LISTADDR __stdcall L13_ListConfigEx(ULONG configval,INT count,USHORT skipval,HCARD handleval);
L13W32API INT __stdcall L13_ListDataRdEx(LPUSHORT buf,INT count,INT index,LISTADDR listaddr,HCARD handleval);
L13W32API INT __stdcall L13_ListDataWrEx(LPUSHORT buf,INT count,INT index,LISTADDR listaddr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ListInit(LISTADDR listaddr,MSGADDR msgaddr,HCARD handleval);
L13W32API MSGADDR __stdcall L13_ListNextRd(ULONG listaddr,LPUSHORT header);
L13W32API MSGADDR __stdcall L13_ListNextWr(ULONG listaddr,LPUSHORT header);
L13W32API VOID __stdcall L13_ListPostRd(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L13W32API VOID __stdcall L13_ListPostWr(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L13W32API VOID __stdcall L13_ListPreRd(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L13W32API VOID __stdcall L13_ListPreWr(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
L13W32API INT __stdcall L13_ListStatus(LISTADDR listaddr,HCARD handleval);
L13W32API ULONG __stdcall L13_MakeLong(USHORT valh,USHORT vall);
L13W32API ULONG __stdcall L13_Mask(ULONG dataval,USHORT cntval);
L13W32API VOID __stdcall L13_MEMWINFillW(USHORT value,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
L13W32API USHORT __stdcall L13_MEMWINRdB(ULONG addrval,INT bustype,HCARD handleval);
L13W32API ULONG __stdcall L13_MEMWINRdL(ULONG addrval,INT bustype,HCARD handleval);
L13W32API VOID __stdcall L13_MEMWINRdsL(LPULONG valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L13W32API VOID __stdcall L13_MEMWINRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L13W32API USHORT __stdcall L13_MEMWINRdW(ULONG addrval,INT bustype,HCARD handleval);
L13W32API VOID __stdcall L13_MEMWINWrB(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
L13W32API VOID __stdcall L13_MEMWINWrL(ULONG value,ULONG addrval,INT bustype,HCARD handleval);
L13W32API VOID __stdcall L13_MEMWINWrsL(LPULONG valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L13W32API VOID __stdcall L13_MEMWINWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,INT bustype,HCARD handleval);
L13W32API VOID __stdcall L13_MEMWINWrW(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
L13W32API ULONG __stdcall L13_Mod(ULONG moda,ULONG modb);
L13W32API BOOL __stdcall L13_ModeIsBC(HCARD handleval);
L13W32API BOOL __stdcall L13_ModeIsMon(HCARD handleval);
L13W32API BOOL __stdcall L13_ModeIsNotBC(HCARD handleval);
L13W32API BOOL __stdcall L13_ModeIsNotMon(HCARD handleval);
L13W32API BOOL __stdcall L13_ModeIsNotPlay(HCARD handleval);
L13W32API BOOL __stdcall L13_ModeIsNotRT(HCARD handleval);
L13W32API BOOL __stdcall L13_ModeIsNotSerial(HCARD handleval);
L13W32API BOOL __stdcall L13_ModeIsPlay(HCARD handleval);
L13W32API BOOL __stdcall L13_ModeIsRT(HCARD handleval);
L13W32API BOOL __stdcall L13_ModeIsSerial(HCARD handleval);
L13W32API USHORT __stdcall L13_ModeRd(HCARD handleval);
L13W32API VOID __stdcall L13_ModeWr(USHORT mode,HCARD handleval);
L13W32API ULONG __stdcall L13_MonBlkRd(LPUSHORT buf,ULONG bufcount,LPULONG blkcnt,HCARD handleval);
L13W32API ULONG __stdcall L13_MonBlkRdEx(LPUSHORT buf,ULONG bufcount,ULONG maxblkcnt,LPULONG blkcnt,HCARD handleval);
L13W32API ERRVAL __stdcall L13_MonClear(HCARD handleval);
L13W32API ERRVAL __stdcall L13_MonConfigEx(ULONG configval,ULONG moncount,USHORT cardnum,HCARD handleval);
L13W32API ERRVAL __stdcall L13_MonConfigExx(ULONG configval,ULONG seqaddr,ULONG moncount,USHORT cardnum,HCARD handleval);
L13W32API ERRVAL __stdcall L13_MonFilterSAEx(INT taval,ULONG rcvsamask,ULONG xmtsamask,ULONG rcvmcmask,ULONG xmtmcmask,HCARD handleval);
L13W32API USHORT __stdcall L13_MonRdEx(LPUSHORT buf,USHORT bufcount,HCARD handleval);
L13W32API BOOL __stdcall L13_MonResume(HCARD handleval);
L13W32API BOOL __stdcall L13_MonStart(HCARD handleval);
L13W32API BOOL __stdcall L13_MonStatus(HCARD handleval);
L13W32API BOOL __stdcall L13_MonStop(HCARD handleval);
L13W32API MSGADDR __stdcall L13_MsgBlockRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
L13W32API MSGADDR __stdcall L13_MsgBlockWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
L13W32API USHORT __stdcall L13_MsgCheck(MSGADDR msgaddr,HCARD handleval);
L13W32API MSGADDR __stdcall L13_MsgCommRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
L13W32API MSGADDR __stdcall L13_MsgCommWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
L13W32API MSGADDR __stdcall L13_MsgConfig(ULONG configval,HCARD handleval);
L13W32API MSGADDR __stdcall L13_MsgConfigEx(ULONG configval,USHORT cwd,HCARD handleval);
L13W32API USHORT __stdcall L13_MsgCWD1Rd(MSGADDR msgaddr,HCARD handleval);
L13W32API VOID __stdcall L13_MsgCWD1Wr(USHORT cwd1,MSGADDR msgaddr,HCARD handleval);
L13W32API USHORT __stdcall L13_MsgCWD2Rd(MSGADDR msgaddr,HCARD handleval);
L13W32API VOID __stdcall L13_MsgCWD2Wr(USHORT cwd2,MSGADDR msgaddr,HCARD handleval);
L13W32API USHORT __stdcall L13_MsgErrorRd(MSGADDR msgaddr,HCARD handleval);
L13W32API VOID __stdcall L13_MsgErrorWr(USHORT value,MSGADDR msgaddr,HCARD handleval);
L13W32API USHORT __stdcall L13_MsgFlagRd(MSGADDR msgaddr,HCARD handleval);
L13W32API VOID __stdcall L13_MsgFlagWr(USHORT msgflag,MSGADDR msgaddr,HCARD handleval);
L13W32API BOOL __stdcall L13_MsgIsAccessed(MSGADDR msgaddr,HCARD handleval);
L13W32API USHORT __stdcall L13_MsgOptRd(MSGADDR msgaddr,HCARD handleval);
L13W32API VOID __stdcall L13_MsgOptWr(USHORT msgopt,MSGADDR msgaddr,HCARD handleval);
L13W32API MSGADDR __stdcall L13_MsgReset(MSGADDR msgaddr,HCARD handleval);
L13W32API USHORT __stdcall L13_MsgSWD1Rd(MSGADDR msgaddr,HCARD handleval);
L13W32API USHORT __stdcall L13_MsgSWD2Rd(MSGADDR msgaddr,HCARD handleval);
L13W32API ULONG __stdcall L13_Mul(ULONG mula,ULONG mulb);
L13W32API ERRVAL __stdcall L13_PlayClear(HCARD handleval);
L13W32API ERRVAL __stdcall L13_PlayConfigEx(ULONG configval,ULONG playcount,ULONG seqcount,USHORT cardnum,HCARD handleval);
L13W32API ERRVAL __stdcall L13_PlayConfigExx(ULONG configval,ULONG playaddr,ULONG playcount,ULONG seqaddr,ULONG seqcount,USHORT cardnum,HCARD handleval);
L13W32API USHORT __stdcall L13_PlayWrEx(LPUSHORT buf,USHORT bufcount,HCARD handleval);
L13W32API USHORT __stdcall L13_PortRd(INT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_PortWr(USHORT value,INT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ProcCall(ULONG useraddr,HCARD handleval);
L13W32API ULONG __stdcall L13_ProcLoad(LPVOID userbuf,USHORT count,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ProcRun(LPVOID userbuf,USHORT count,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ProcRunEx(LPVOID userbuf,USHORT count,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ProcSetFore(ULONG useraddr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ProcSetInt(USHORT useraddr,INT intnum,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ProcSetPost(ULONG useraddr,MSGADDR msgaddr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ProcSetPre(ULONG useraddr,MSGADDR msgaddr,HCARD handleval);
L13W32API USHORT __stdcall L13_ProgRdW(USHORT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_ProgWrW(USHORT value,USHORT addrval,HCARD handleval);
L13W32API VOID __stdcall L13_RAMFill(USHORT value,ULONG addrval,ULONG countval,HCARD handleval);
L13W32API BOOL __stdcall L13_RAMIsDPM(ULONG addrval);
L13W32API USHORT __stdcall L13_RAMRdB(ULONG addrval,HCARD handleval);
L13W32API ULONG __stdcall L13_RAMRdL(ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_RAMRdsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L13W32API VOID __stdcall L13_RAMRdsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L13W32API USHORT __stdcall L13_RAMRdW(ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_RAMWipe(HCARD handleval);
L13W32API VOID __stdcall L13_RAMWipeEx(USHORT value,HCARD handleval);
L13W32API VOID __stdcall L13_RAMWrB(USHORT value,ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_RAMWrL(ULONG value,ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_RAMWrsL(LPULONG valueptr,ULONG addrval,INT countval,HCARD handleval);
L13W32API VOID __stdcall L13_RAMWrsW(LPUSHORT valueptr,ULONG addrval,INT countval,HCARD handleval);
L13W32API VOID __stdcall L13_RAMWrW(USHORT value,ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMChksW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMClose(HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMDisable(HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMEnable(HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMFlush(HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMInfoRd(LPBYTE buf,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMInfoWr(LPBYTE buf,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMOpen(HCARD handleval);
L13W32API VOID __stdcall L13_ROMProg(USHORT enableflag,LPUSHORT dataptr,USHORT cntval,ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_ROMProgg(INT value,ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMRdsW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMWrsW(USHORT enableflag,LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_ROMWrW(USHORT value,USHORT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_RTConfigEx(ULONG configval,INT taval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_RTConfigExx(ULONG configval,INT taval,HCARD handleval);
L13W32API LISTADDR __stdcall L13_RTCreateListEx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API LISTADDR __stdcall L13_RTCreateListExx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_RTReset(INT taval,HCARD handleval);
L13W32API USHORT __stdcall L13_RTStatus(INT taval,HCARD handleval);
L13W32API USHORT __stdcall L13_RTSWDRd(INT taval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SchedBuild(INT nummsgs,LPMSGADDR msgaddr,LPINT freq,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SchedBuildEx(INT nummsgs,LPMSGADDR msgaddr,LPINT freq,LPINT period,LPVOID buf,ULONG bufsize,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SchedBuildExx(ULONG frametime,INT nummsgs,LPMSGADDR msgaddr,LPINT period,LPVOID buf,ULONG bufsize,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SchedCalc(LPMSGADDR msgaddr,HCARD handleval);
L13W32API VOID __stdcall L13_SchedDisplay(ULONG nummsgs,LPULONG count);
L13W32API VOID __stdcall L13_SchedHook(INT index,LPVOID ptr);
L13W32API ERRVAL __stdcall L13_SchedInsEnd(HCARD handleval);
L13W32API ERRVAL __stdcall L13_SchedInsMsg(ULONG index,LPMSGADDR msgaddr,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SchedInsStart(ULONG frametime,ULONG count,HCARD handleval);
L13W32API ULONG __stdcall L13_SchedMaxval(LPULONG array,ULONG arraycount);
L13W32API ULONG __stdcall L13_SchedMinval(LPULONG array,ULONG arraycount);
L13W32API VOID __stdcall L13_SchedPrint(LPSTR str,...);
L13W32API ERRVAL __stdcall L13_SEEPokeW(INT value,INT numbits,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SEERdBit(LPINT valueptr,INT bitnum,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SEERdL(LPULONG valueptr,INT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SEERdW(LPINT valueptr,INT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SEEWrBit(INT value,INT bitnum,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SEEWrL(ULONG value,INT addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SEEWrW(INT value,INT addrval,HCARD handleval);
L13W32API USHORT __stdcall L13_SEMMRdW(ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_SEMMWrW(USHORT value,ULONG addrval,HCARD handleval);
L13W32API USHORT __stdcall L13_SEMRdW(ULONG addrval,HCARD handleval);
L13W32API VOID __stdcall L13_SEMWrW(USHORT value,ULONG addrval,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SerialClear(HCARD handleval);
L13W32API ERRVAL __stdcall L13_SerialConfig(ULONG configval,USHORT count,HCARD handleval);
L13W32API ERRVAL __stdcall L13_SerialConfigEx(ULONG configval,USHORT count,HCARD handleval);
L13W32API INT __stdcall L13_SerialStatus(HCARD handleval);
L13W32API ULONG __stdcall L13_SerialWr(LPUSHORT buf,HCARD handleval);
L13W32API ULONG __stdcall L13_Shl(ULONG dataval,USHORT cntval);
L13W32API ULONG __stdcall L13_Shr(ULONG dataval,USHORT cntval);
L13W32API VOID __stdcall L13_TimerClear(HCARD handleval);
L13W32API ULONG __stdcall L13_TimerRd(HCARD handleval);
L13W32API INT __stdcall L13_TimerResolution(INT timerresol,HCARD handleval);
L13W32API USHORT __stdcall L13_TimerResolutionEx(USHORT timershift,HCARD handleval);
L13W32API INT __stdcall L13_ValAsciiCmpi(LPSTR str1,LPSTR str2);
L13W32API LPSTR __stdcall L13_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
L13W32API VOID __stdcall L13_ValAsciiTrimLead(LPSTR buf);
L13W32API VOID __stdcall L13_ValAsciiTrimTrail(LPSTR buf);
L13W32API ULONG __stdcall L13_ValFromAscii(LPCSTR asciistr,INT radixval);
L13W32API USHORT __stdcall L13_ValGetBits(USHORT oldvalue,INT startbit,INT endbit);
L13W32API LPSTR __stdcall L13_ValIncAscii(LPSTR asciistr);
L13W32API LPSTR __stdcall L13_ValInccAscii(LPSTR asciistr);
L13W32API BOOL __stdcall L13_ValIsLower(INT value);
L13W32API INT __stdcall L13_ValLenAscii(INT numbits,INT radixval);
L13W32API USHORT __stdcall L13_ValPackRTCWD(INT MCflag,INT TAval,INT TRflag,INT SAval,INT count);
L13W32API USHORT __stdcall L13_ValPutBits(USHORT oldvalue,USHORT newfld,INT startbit,INT endbit);
L13W32API LPSTR __stdcall L13_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
L13W32API INT __stdcall L13_ValToUpper(INT value);
L13W32API VOID __stdcall L13_ValUnpackRTCWD(USHORT cwd,LPINT BCASTflag,LPINT MCflag,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT count);

#ifdef __cplusplus
}
#endif

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
#define RTCFG_WIPE123      0x04000000L      //Initialize data with incrementing values
#define RTCFG_WIPECWD      0x08000000L      //Initialize data with command word
#define RTCFG_MODEL        0x00000000L      //RT messages are created in static RAM or dual-port RAM depending upon board model (default)
#define RTCFG_RAM          0x00100000L      //RT messages are created in static RAM
#define RTCFG_DPRAM        0x00200000L      //RT messages are created in dual-port RAM

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
*  Playback configuration options
*
**/

#define PLAYCFG_DEFAULT      0x00000000L     //Select all default settings
#define PLAYCFG_ENABLE       0x00000000L     //Enable playback (default)
#define PLAYCFG_DISABLE      0x00000001L     //Disable playback
#define PLAYCFG_16K          0x00000000L     //Allocate a 16K playback buffer (default)
#define PLAYCFG_ALLAVAIL     0x00008000L     //Allocate all available memory to playback buffer
#define PLAYCFG_32K          0x00010000L     //Allocate a 32K playback buffer
#define PLAYCFG_64K          0x00020000L     //Allocate a 64K playback buffer
#define PLAYCFG_128K         0x00040000L     //Allocate a 128K playback buffer
#define PLAYCFG_DPRAM        0x00080000L     //Allocate all available dual-port memory

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

#define INFOTYPE_PLAT      0x0001           //Returns the L13 platform type
#define INFOTYPE_PROD      0x0002           //Returns the L13 product type
#define INFOTYPE_DASH      0x0003           //Returns the L13 dash number
#define INFOTYPE_VERSION   0x0004           //Returns the L13 version number
#define INFOTYPE_DATE      0x0005           //Returns the L13 version date
#define INFOTYPE_MODEL     0x0006           //Returns the L13 model number
#define INFOTYPE_MAXCOUNT  0x0007           //Returns the number of terminals the L13 can simulate
#define INFOTYPE_MULTIMODE 0x0008           //Returns whether L13 can simulate multi-modes
#define INFOTYPE_ERRORGEN  0x0009           //Returns whether L13 can generate errors
#define INFOTYPE_CONCURMON 0x000A           //Returns whether L13 has a concurrent monitor
#define INFOTYPE_MONFILTER 0x000B           //Returns whether L13 has a monitor filter
#define INFOTYPE_USERCODE  0x000C           //Returns whether L13 handles user code
#define INFOTYPE_LISTBUF   0x000D           //Returns whether L13 handles list buffering
#define INFOTYPE_MONFAST   0x000E           //Returns whether L13 has a fast monitor
#define INFOTYPE_MONDMA    0x000F           //Returns whether L13 has a dma monitor
#define INFOTYPE_MONBRAKE  0x0010           //Returns whether L13 has a monitor brake
#define INFOTYPE_PLAY      0x0011           //Returns whether L13 has playback capability

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
#define MSGCRT_NOINT       0x00000000L      //Message will not generate interrupt (default)
#define MSGCRT_INT         0x00000001L      //Message will generate interrupt
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
*  Bit fields of the message error flag
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
*  L13 IFGA Registers
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

#define EREG_STAT    0x0180                 //Status register (RD)
#define EREG_STATCLR 0x0081                 //Status clear register (WR)
#define EREG_STATDEC 0x0082                 //Decoder status register (RD)
#define EREG_VALA    0x0084                 //Decoder word value A register
#define EREG_VALAL   0x0084                 //Decoder low word value A register
#define EREG_VALAH   0x0085                 //Decoder high word value A register
#define EREG_VALB    0x0086                 //Decoder word value B register
#define EREG_VALBL   0x0086                 //Decoder low word value B register
#define EREG_VALBH   0x0087                 //Decoder high word value B register
#define EREG_GAPE    0x0088                 //Encoder gap register
#define EREG_CTRLE   0x0089                 //Encoder control register
#define EREG_VALE    0x008A                 //Encoder value register
#define EREG_VALEL   0x008A                 //Encoder low value register
#define EREG_VALEH   0x008B                 //Encoder high value register
#define EREG_ERRE    0x008C                 //Encoder error register
#define EREG_FT      0x008E                 //Frame time register
#define EREG_RST     0x008F                 //Reset register
#define EREG_GAPA    0x0090                 //Decoder gap time A register
#define EREG_GAPB    0x0091                 //Decoder gap time B register
#define EREG_GAPTO   0x0092                 //Decoder gap timeout register
#define EREG_CFGD    0x0094                 //Decoder configuration register
#define EREG_CFGE    0x0095                 //Encoder configuration register
#define EREG_CFGINT  0x0096                 //Interrupt configuration register
#define EREG_ID      0x0097                 //Identification register

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
#define INTTYPE_SERIAL 0x0009               //Serial empty

/**
*
*  Timer resolutions.
*
**/

#define TIMERRESOL_1US     1                //1us timer resolution, 1:11:34
#define TIMERRESOL_16US    2                //16us timer resolution, 19:05:19 range
#define TIMERRESOL_1024US  3                //1024us timer resolution, 50 day range

#define MONRD_MAX_COUNT 64

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
#define ERR_NOCARD       -13                //CardOpen() could not find a L13 card at the specified address
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
