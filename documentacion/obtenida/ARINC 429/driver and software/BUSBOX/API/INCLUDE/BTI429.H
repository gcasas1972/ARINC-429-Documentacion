/**
*
*  BTI429 WIN32 DRIVER  Version 1.10.0  (06/07/2011)
*  Copyright (c) 2001-2011
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   BTI429.H -- Visual C++ 32-bit
*                      BTI429 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for Ballard Technology ARINC 429
*  cards.  Applications using the BTI429 Driver Library must
*  incorporate this include file using the preprocessor
*  directive #include. If this file is in the current working
*  directory, the form would be:
*
*  #include "BTI429.H"
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

#ifndef __BTI429_H
#define __BTI429_H

/**
*
*  Pragma to specify link library.
*
**/

#ifdef __BORLANDC__
#pragma comment(lib,"bti429bc.lib")
#else
#if defined(_WIN32)
#if defined(_WIN64)
#pragma comment(lib,"bti42964.lib")
#else
#pragma comment(lib,"bti429.lib")
#endif
#endif
#endif

/**
*
*  Typedefs used by the BTI429 Driver.
*
**/

#ifndef BTI429API
#ifdef __BORLANDC__
#define BTI429API
#else
#define BTI429API __declspec(dllimport)
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
#if defined(_WIN64)
typedef void * HCARD;
#else
typedef int HCARD;
#endif
#endif

#ifndef HCORE
#if defined(_WIN64)
typedef void * HCORE;
#else
typedef int HCORE;
#endif
#endif

#ifndef LPHCORE
#if defined(_WIN64)
typedef void ** LPHCORE;
#else
typedef int * LPHCORE;
#endif
#endif

#ifndef ERRVAL
typedef int ERRVAL;
#endif

#ifndef SCHNDX
typedef int SCHNDX;
#endif

/**
*
*  Structs used by the BTI429 Driver.
*
**/

#ifndef MSGSTRUCT429

typedef struct
{
	MSGADDR	addr;
	ULONG	data;
} MSGSTRUCT429;

#endif

#ifndef LPMSGSTRUCT429
typedef MSGSTRUCT429 * LPMSGSTRUCT429;
#endif

#ifndef MSGFIELDS429

typedef struct
{
    USHORT msgopt;              //Driver writes message options
    USHORT msgact;              //Card writes message activity
    union {
        ULONG  msgdata;         //Card/User writes message data (Rcv/Xmt)
        ULONG  listptr;         //Driver writes list buffer pointer
    };
    union {
        ULONG  timetag;         //Card writes timetag
        ULONG  hitcount;        //Card writes hit count
    };
    union {
        ULONG  maxtime;         //Card writes max time
        ULONG  elapsetime;      //Card writes elapsed time
    };
    ULONG  mintime;             //Card writes min time
    ULONG  userptr;             //Driver writes user code pointer
    ULONG  timetagh;            //Card writes extended timetag
    USHORT decgap;              //Card writes measured decoder gap time (rsvd for xmt msg)
    USHORT rsvd;                //Reserved
} MSGFIELDS429;

#endif

#ifndef LPMSGFIELDS429
typedef MSGFIELDS429 * LPMSGFIELDS429;
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
*  BTI429 Driver functions.
*
**/

BTI429API ULONG __stdcall BTI429_BCDGetData(ULONG msg,USHORT msb,USHORT lsb);
BTI429API ULONG __stdcall BTI429_BCDGetMant(ULONG msg,USHORT sigdig);
BTI429API USHORT __stdcall BTI429_BCDGetSign(ULONG msg);
BTI429API USHORT __stdcall BTI429_BCDGetSSM(ULONG msg);
BTI429API VOID __stdcall BTI429_BCDGetVal(LPSTR buf,ULONG msg,USHORT sigdig,LPCSTR resolstr);
BTI429API ULONG __stdcall BTI429_BCDPutData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
BTI429API ULONG __stdcall BTI429_BCDPutMant(ULONG msg,ULONG value,USHORT sigdig,USHORT sign);
BTI429API ULONG __stdcall BTI429_BCDPutSign(ULONG msg,USHORT sign);
BTI429API ULONG __stdcall BTI429_BCDPutSSM(ULONG msg,USHORT value);
BTI429API ULONG __stdcall BTI429_BCDPutVal(LPCSTR buf,ULONG msg,USHORT sigdig,LPCSTR resolstr);
BTI429API ULONG __stdcall BTI429_BNRGetData(ULONG msg,USHORT msb,USHORT lsb);
BTI429API ULONG __stdcall BTI429_BNRGetMant(ULONG msg,USHORT sigbit);
BTI429API USHORT __stdcall BTI429_BNRGetSign(ULONG msg);
BTI429API USHORT __stdcall BTI429_BNRGetSSM(ULONG msg);
BTI429API VOID __stdcall BTI429_BNRGetVal(LPSTR buf,ULONG msg,USHORT sigbit,LPCSTR resolstr);
BTI429API ULONG __stdcall BTI429_BNRPutData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
BTI429API ULONG __stdcall BTI429_BNRPutMant(ULONG msg,ULONG value,USHORT sigbit,USHORT twos);
BTI429API ULONG __stdcall BTI429_BNRPutSign(ULONG msg,USHORT twos);
BTI429API ULONG __stdcall BTI429_BNRPutSSM(ULONG msg,USHORT value);
BTI429API ULONG __stdcall BTI429_BNRPutVal(LPCSTR buf,ULONG msg,USHORT sigbit,LPCSTR resolstr);
BTI429API ERRVAL __stdcall BTI429_ChClear(INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ChConfig(ULONG configval,INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_ChGetCount(LPINT rcvcount,LPINT xmtcount,HCORE handleval);
BTI429API ULONG __stdcall BTI429_ChGetInfo(USHORT infotype,INT channum,HCORE handleval);
BTI429API BOOL __stdcall BTI429_ChIs429(INT channum,HCORE handleval);
BTI429API BOOL __stdcall BTI429_ChIsRcv(INT channum,HCORE handleval);
BTI429API BOOL __stdcall BTI429_ChIsXmt(INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_ChPause(INT channum,HCORE handleval);
BTI429API INT __stdcall BTI429_ChPauseCheck(INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_ChResume(INT channum,HCORE handleval);
BTI429API BOOL __stdcall BTI429_ChStart(INT channum,HCORE handleval);
BTI429API BOOL __stdcall BTI429_ChStop(INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ChSyncDefine(BOOL enableflag,USHORT syncmask,USHORT pinpolarity,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ChTriggerDefine(BOOL enableflag,USHORT trigmask,USHORT trigval,USHORT pinpolarity,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_FilterClear(BASEADDR baseaddr,HCORE handleval);
BTI429API MSGADDR __stdcall BTI429_FilterDefault(ULONG configval,INT channum,HCORE handleval);
BTI429API MSGADDR __stdcall BTI429_FilterRd(INT labelval,INT sdival,INT channum,HCORE handleval);
BTI429API MSGADDR __stdcall BTI429_FilterSet(ULONG configval,INT labelval,INT sdimask,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_FilterWr(MSGADDR msgaddr,INT labelval,INT sdival,INT channum,HCORE handleval);
BTI429API ULONG __stdcall BTI429_FldGetData(ULONG msgval);
BTI429API USHORT __stdcall BTI429_FldGetLabel(ULONG msgval);
BTI429API USHORT __stdcall BTI429_FldGetParity(ULONG msgval);
BTI429API USHORT __stdcall BTI429_FldGetSDI(ULONG msgval);
BTI429API ULONG __stdcall BTI429_FldGetValue(ULONG msgval,USHORT startbit,USHORT endbit);
BTI429API ULONG __stdcall BTI429_FldPutData(ULONG msgval,ULONG data);
BTI429API ULONG __stdcall BTI429_FldPutLabel(ULONG msgval,USHORT label);
BTI429API ULONG __stdcall BTI429_FldPutSDI(ULONG msgval,USHORT sdi);
BTI429API ULONG __stdcall BTI429_FldPutValue(ULONG msgval,ULONG dataval,USHORT startbit,USHORT endbit);
BTI429API LISTADDR __stdcall BTI429_ListAsyncCreate(ULONG listconfigval,INT count,INT channum,HCORE handleval);
BTI429API ULONG __stdcall BTI429_ListDataRd(LISTADDR listaddr,HCORE handleval);
BTI429API BOOL __stdcall BTI429_ListDataWr(ULONG value,LISTADDR listaddr,HCORE handleval);
BTI429API LISTADDR __stdcall BTI429_ListRcvCreate(ULONG listconfigval,INT count,MSGADDR msgaddr,HCORE handleval);
BTI429API INT __stdcall BTI429_ListStatus(LISTADDR listaddr,HCORE handleval);
BTI429API LISTADDR __stdcall BTI429_ListXmtCreate(ULONG listconfigval,INT count,MSGADDR msgaddr,HCORE handleval);
BTI429API MSGADDR __stdcall BTI429_MsgBlockRd(LPMSGFIELDS429 msgfields,MSGADDR msgaddr,HCORE handleval);
BTI429API MSGADDR __stdcall BTI429_MsgBlockWr(LPMSGFIELDS429 msgfields,MSGADDR msgaddr,HCORE handleval);
BTI429API MSGADDR __stdcall BTI429_MsgCreate(ULONG configval,HCORE handleval);
BTI429API ULONG __stdcall BTI429_MsgDataRd(MSGADDR msgaddr,HCORE handleval);
BTI429API VOID __stdcall BTI429_MsgDataWr(ULONG value,MSGADDR msgaddr,HCORE handleval);
BTI429API VOID __stdcall BTI429_MsgGroupBlockRd(LPMSGFIELDS429 msgfields,LPMSGADDR msgaddrptr,INT nummsgs,HCORE handleval);
BTI429API VOID __stdcall BTI429_MsgGroupBlockWr(LPMSGFIELDS429 msgfields,LPMSGADDR msgaddrptr,INT nummsgs,HCORE handleval);
BTI429API VOID __stdcall BTI429_MsgGroupRd(LPULONG msgdataptr,LPMSGADDR msgaddrptr,INT nummsgs,HCORE handleval);
BTI429API VOID __stdcall BTI429_MsgGroupWr(LPULONG msgdataptr,LPMSGADDR msgaddrptr,INT nummsgs,HCORE handleval);
BTI429API BOOL __stdcall BTI429_MsgIsAccessed(MSGADDR msgaddr,HCORE handleval);
BTI429API BOOL __stdcall BTI429_MsgSkipRd(MSGADDR msgaddr,HCORE handleval);
BTI429API VOID __stdcall BTI429_MsgSkipWr(BOOL skip,MSGADDR msgaddr,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_MsgSyncDefine(BOOL enableflag,USHORT syncmask,USHORT pinpolarity,MSGADDR msgaddr,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_MsgTriggerDefine(BOOL enableflag,USHORT trigmask,USHORT trigval,USHORT pinpolarity,MSGADDR msgaddr,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ParamAmplitudeConfig(ULONG configval,USHORT dacval,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ParamAmplitudeGet(LPUSHORT dacval,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ParamBitRateConfig(ULONG configval,USHORT divval,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ParamBitRateGet(LPUSHORT divval,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedBranch(ULONG condition,SCHNDX destindex,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedBranchUpdate(SCHNDX destindex,SCHNDX opcodeindex,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedBuild(INT nummsgs,LPMSGADDR msgaddr,LPINT minperiod,LPINT maxperiod,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedCall(ULONG condition,SCHNDX destindex,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedCallUpdate(SCHNDX destindex,SCHNDX opcodeindex,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedMode(ULONG modeval);
BTI429API SCHNDX __stdcall BTI429_SchedEntry(INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedGap(USHORT gapval,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedGapFixed(USHORT gapval,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedGapList(USHORT gapval,LISTADDR listaddr,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedHalt(INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedLog(ULONG condition,USHORT tagval,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedMsg(MSGADDR msgaddr,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedMsgEx(MSGADDR msgaddr,USHORT gapval,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedPause(INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedPulse(INT dionum,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedRestart(INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedReturn(INT channum,HCORE handleval);

/**
*
*  Internal functions used by the BTI429 Driver.
*
**/

BTI429API ERRVAL __stdcall BTI429_ChConfigEx(ULONG configval,USHORT count,INT channum,HCORE handleval);
BTI429API ULONG __stdcall BTI429_CmdAddr(SCHNDX index,INT channum,HCORE handleval);
BTI429API ULONG __stdcall BTI429_CmdAlloc(INT count,HCORE handleval);
BTI429API ULONG __stdcall BTI429_CmdAllocEx(ULONG configval,INT count,HCORE handleval);
BTI429API ULONG __stdcall BTI429_CmdBaseRd(INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_CmdBaseWr(ULONG addrval,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_CmdClear(INT channum,HCORE handleval);
BTI429API USHORT __stdcall BTI429_CmdCountRd(INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_CmdCountWr(USHORT countval,INT channum,HCORE handleval);
BTI429API USHORT __stdcall BTI429_CmdCtrlRd(SCHNDX index,INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_CmdCtrlWr(USHORT ctrlval,SCHNDX index,INT channum,HCORE handleval);
BTI429API USHORT __stdcall BTI429_CmdCurrRd(INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_CmdCurrWr(USHORT addrval,INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_CmdInit(USHORT opcode,LPUSHORT block);
BTI429API SCHNDX __stdcall BTI429_CmdInsert(LPUSHORT block,INT channum,HCORE handleval);
BTI429API USHORT __stdcall BTI429_CmdMaxLoopRd(INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_CmdMaxLoopWr(USHORT countval,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_CmdRd(LPUSHORT block,ULONG addrval,HCORE handleval);
BTI429API VOID __stdcall BTI429_CmdRestart(INT channum,HCORE handleval);
BTI429API BOOL __stdcall BTI429_CmdShotRd(SCHNDX index,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_CmdShotWr(BOOL value,SCHNDX index,INT channum,HCORE handleval);
BTI429API BOOL __stdcall BTI429_CmdSkipRd(SCHNDX index,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_CmdSkipWr(BOOL value,SCHNDX index,INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_CmdStackClr(INT channum,HCORE handleval);
BTI429API USHORT __stdcall BTI429_CmdStartRd(INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_CmdStartWr(USHORT addrval,INT channum,HCORE handleval);
BTI429API BOOL __stdcall BTI429_CmdStepRd(SCHNDX index,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_CmdStepWr(BOOL value,SCHNDX index,INT channum,HCORE handleval);
BTI429API INT __stdcall BTI429_CmdTotalRd(INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_CmdTotalWr(INT countval,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_CmdWr(LPUSHORT block,ULONG addrval,HCORE handleval);
BTI429API ULONG __stdcall BTI429_ConvFromArinc(ULONG msgval);
BTI429API ULONG __stdcall BTI429_ConvToArinc(ULONG msgval);
BTI429API INT __stdcall BTI429_DllUsageCount(VOID);
BTI429API ULONG __stdcall BTI429_FilterAddr(INT labelval,INT sdival,INT channum,HCORE handleval);
BTI429API BASEADDR __stdcall BTI429_FilterCreate(HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_FilterFill(MSGADDR msgaddr,BASEADDR baseaddr,HCORE handleval);
BTI429API USHORT __stdcall BTI429_FldGetParBit(ULONG msgval);
BTI429API ULONG __stdcall BTI429_FldPutParBit(ULONG msgval);
BTI429API VOID __stdcall BTI429_GetChanCount(LPINT rcvcount,LPINT xmtcount,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_HookMsgProc(INT msgval,LPVOID lpParam,HCORE handleval);
BTI429API BOOL __stdcall BTI429_IsChan(INT channum,HCORE handleval);
BTI429API BOOL __stdcall BTI429_IsRcvChan(INT channum,HCORE handleval);
BTI429API BOOL __stdcall BTI429_IsXmtChan(INT channum,HCORE handleval);
BTI429API ULONG __stdcall BTI429_LabelReverse(ULONG msgval);
BTI429API ULONG __stdcall BTI429_ListAddr(INT index,LISTADDR listaddr,HCORE handleval);
BTI429API ULONG __stdcall BTI429_ListAddrEx(INT index,LISTADDR listaddr,LPUSHORT header,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ListAdvance(LISTADDR listaddr,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ListClear(LISTADDR listaddr,HCORE handleval);
BTI429API LISTADDR __stdcall BTI429_ListConfig(ULONG configval,INT count,HCORE handleval);
BTI429API LISTADDR __stdcall BTI429_ListConfigEx(ULONG configval,INT count,HCORE handleval);
BTI429API BOOL __stdcall BTI429_ListDataBlkRd(LPULONG dataptr,LPUSHORT datacountptr,LISTADDR listaddr,HCORE handleval);
BTI429API BOOL __stdcall BTI429_ListDataBlkWr(LPULONG dataptr,USHORT datacount,LISTADDR listaddr,HCORE handleval);
BTI429API ULONG __stdcall BTI429_ListDataRdEx(INT index,LISTADDR listaddr,HCORE handleval);
BTI429API VOID __stdcall BTI429_ListDataWrEx(ULONG value,INT index,LISTADDR listaddr,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ListInit(LISTADDR listaddr,MSGADDR msgaddr,HCORE handleval);
BTI429API ULONG __stdcall BTI429_ListNextRd(ULONG listaddr,LPUSHORT header,HCORE handleval);
BTI429API ULONG __stdcall BTI429_ListNextWr(ULONG listaddr,LPUSHORT header,HCORE handleval);
BTI429API VOID __stdcall BTI429_ListPostRd(LISTADDR listaddr,LPUSHORT header,HCORE handleval);
BTI429API VOID __stdcall BTI429_ListPostWr(LISTADDR listaddr,LPUSHORT header,HCORE handleval);
BTI429API VOID __stdcall BTI429_ListPreRd(LISTADDR listaddr,LPUSHORT header,HCORE handleval);
BTI429API VOID __stdcall BTI429_ListPreWr(LISTADDR listaddr,LPUSHORT header,HCORE handleval);
BTI429API USHORT __stdcall BTI429_MsgActivityRd(MSGADDR msgaddr,HCORE handleval);
BTI429API VOID __stdcall BTI429_MsgActivityWr(USHORT value,MSGADDR msgaddr,HCORE handleval);
BTI429API USHORT __stdcall BTI429_MsgCheck(MSGADDR msgaddr,HCORE handleval);
BTI429API MSGADDR __stdcall BTI429_MsgCommRd(LPMSGFIELDS429 msgfields,MSGADDR msgaddr,HCORE handleval);
BTI429API MSGADDR __stdcall BTI429_MsgCommWr(LPMSGFIELDS429 msgfields,MSGADDR msgaddr,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_MsgConfig(ULONG configval,MSGADDR msgaddr,HCORE handleval);
BTI429API USHORT __stdcall BTI429_MsgOptRd(MSGADDR msgaddr,HCORE handleval);
BTI429API VOID __stdcall BTI429_MsgOptWr(USHORT msgopt,MSGADDR msgaddr,HCORE handleval);
BTI429API MSGADDR __stdcall BTI429_MsgReset(MSGADDR msgaddr,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ProcSetPost(ULONG useraddr,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_ProcSetPre(ULONG useraddr,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_Sched1Build(INT basemsgnum,INT nummsgs,LPMSGADDR msgaddr,LPINT minperiodIn,LPINT maxperiodIn,BOOL speed,BOOL microflag,INT channum,BOOL debug,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_Sched2AdvanceMessage(INT entries,INT panicindex,INT nummsgs,LPVOID infoptr,LPINT nextdeltaptr,INT ulMasterTimer,LPMSGADDR msgaddrptr,BOOL debugflag,BOOL tryflag,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_Sched2AdvanceNoMessage(INT nummsgs,LPVOID infoptr,LPINT nextdeltaptr,INT ulMasterTimer,LPMSGADDR msgaddrptr,BOOL debugflag,BOOL tryflag,INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_Sched2Analyze(INT nummsgs,LPVOID infoptr);
BTI429API ERRVAL __stdcall BTI429_Sched2Build(INT nummsgs,LPMSGADDR msgaddrptr,LPINT minlist,LPINT maxlist,BOOL speedflag,BOOL microflag,BOOL debugflag,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_Sched2BuildEx(LPINT styleptr,INT nummsgs,LPINT minlist,LPINT maxlist,BOOL speedflag,BOOL microflag);
BTI429API ERRVAL __stdcall BTI429_Sched2BuildExx(INT style,BOOL speedflag,BOOL microflag,BOOL debugflag,BOOL tryflag,INT nummsgs,LPINT minlist,LPINT maxlist,LPINT entriesptr,LPINT maxentriesptr,LPVOID infoptr,LPMSGADDR msgaddrptr,INT channum,HCORE handleval);
BTI429API ULONG __stdcall BTI429_SchedAdvance(LPVOID infoptr);
BTI429API SCHNDX __stdcall BTI429_SchedAgain(SCHNDX index,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedBranchEx(USHORT condition1,USHORT condition2,SCHNDX destindex,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedBuildEx(INT nummsgs,LPMSGADDR msgaddr,LPINT minperiod,LPINT maxperiod,BOOL speed,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedBuildExx(INT basemsgnum,INT nummsgs,LPMSGADDR msgaddr,LPINT minperiod,LPINT maxperiod,BOOL speed,LPVOID buf,ULONG bufsize,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedBuildExxx(INT nummsgs,LPMSGADDR msgaddr,LPINT minperiod,LPINT maxperiod,BOOL speed,INT channum,BOOL debug,BOOL microflag,INT algorithm,HCORE handleval);
BTI429API ULONG __stdcall BTI429_SchedCalc(LPVOID infoptr);
BTI429API SCHNDX __stdcall BTI429_SchedCallEx(USHORT condition1,USHORT condition2,SCHNDX destindex,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedCheck(LPINT minperiod,LPINT maxperiod,LPVOID infoptr);
BTI429API VOID __stdcall BTI429_SchedCheckEnd(VOID);
BTI429API VOID __stdcall BTI429_SchedCheckMiddle(ULONG msgnum,ULONG minlen,ULONG midlen,ULONG maxlen);
BTI429API VOID __stdcall BTI429_SchedCheckReal(ULONG msgnum,ULONG minlen,ULONG midlen,ULONG maxlen);
BTI429API VOID __stdcall BTI429_SchedCheckStart(VOID);
BTI429API ULONG __stdcall BTI429_SchedConflicts(LPVOID infoptr);
BTI429API VOID __stdcall BTI429_SchedDisplay(ULONG nummsgs,LPULONG count,LPULONG *data);
BTI429API ERRVAL __stdcall BTI429_SchedDivide(LPVOID infoptr);
BTI429API ULONG __stdcall BTI429_SchedFix(LPVOID infoptr);
BTI429API VOID __stdcall BTI429_SchedFixEnd(VOID);
BTI429API VOID __stdcall BTI429_SchedFixMiddle(ULONG conflicts);
BTI429API VOID __stdcall BTI429_SchedFixStart(VOID);
BTI429API VOID __stdcall BTI429_SchedHook(INT index,LPVOID ptr);
BTI429API ERRVAL __stdcall BTI429_SchedInsert(ULONG events,ULONG index,ULONG msgnum,LPMSGADDR msgaddr,ULONG gapval,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedInsert2(ULONG events,ULONG index,INT msgnum,LPMSGADDR msgaddr,ULONG gapval,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedInsertEnd(ULONG events,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedInsertStart(ULONG events,INT channum,HCORE handleval);
BTI429API VOID __stdcall BTI429_SchedLayout(LPVOID infoptr);
BTI429API SCHNDX __stdcall BTI429_SchedLogEx(USHORT condition1,USHORT condition2,USHORT tagval,INT channum,HCORE handleval);
BTI429API ULONG __stdcall BTI429_SchedMaxval(LPULONG array,ULONG arraycount);
BTI429API ULONG __stdcall BTI429_SchedMinval(LPULONG array,ULONG arraycount);
BTI429API SCHNDX __stdcall BTI429_SchedNop(INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedParse(INT basemsgnum,LPMSGADDR msgaddr,INT channum,LPVOID infoptr,HCORE handleval);
BTI429API VOID __stdcall BTI429_SchedPrint(LPSTR str,...);
BTI429API VOID __stdcall BTI429_SchedPrintEx(INT type,LPSTR str,...);
BTI429API SCHNDX __stdcall BTI429_SchedPulse0(INT dionum,INT channum,HCORE handleval);
BTI429API SCHNDX __stdcall BTI429_SchedPulse1(INT dionum,INT channum,HCORE handleval);
BTI429API ERRVAL __stdcall BTI429_SchedReset(LPVOID infoptr);
BTI429API ULONG __stdcall BTI429_SchedRotate(LPVOID infoptr);
BTI429API INT __stdcall BTI429_SchedShift(INT msgnum,INT value,LPVOID infoptr);
BTI429API ERRVAL __stdcall BTI429_SchedSlide(LPVOID infoptr);
BTI429API VOID __stdcall BTI429_SchedSlideEnd(VOID);
BTI429API VOID __stdcall BTI429_SchedSlideMiddle(ULONG index,ULONG count,ULONG conflicts);
BTI429API VOID __stdcall BTI429_SchedSlideStart(ULONG factor);
BTI429API VOID __stdcall BTI429_SchedSort(LPVOID infoptr);
BTI429API ULONG __stdcall BTI429_SchedToBit(ULONG value,LPVOID infoptr);
BTI429API ULONG __stdcall BTI429_SchedToMsec(ULONG value,LPVOID infoptr);
BTI429API VOID __stdcall BTI429_SchedUnsort(LPVOID infoptr);
BTI429API SCHNDX __stdcall BTI429_SchedUser(ULONG useraddr,INT channum,HCORE handleval);
BTI429API ULONG __stdcall BTI429_SchedWalk(LPVOID infoptr);
BTI429API ERRVAL __stdcall BTI429_TestProtocol(HCORE handleval);
BTI429API USHORT __stdcall BTI429_Transpose12(USHORT val);

#ifdef __cplusplus
}
#endif

/**
*
*  Channel number constants
*
**/

#define CH0  0x0000           //Channel 0
#define	CH1  0x0001           //Channel 1
#define	CH2  0x0002           //Channel 2
#define	CH3  0x0003           //Channel 3
#define	CH4  0x0004           //Channel 4
#define	CH5  0x0005           //Channel 5
#define	CH6  0x0006           //Channel 6
#define	CH7  0x0007           //Channel 7
#define	CH8  0x0008           //Channel 8
#define	CH9  0x0009           //Channel 9
#define	CH10 0x000A           //Channel 10
#define	CH11 0x000B           //Channel 11
#define	CH12 0x000C           //Channel 12
#define	CH13 0x000D           //Channel 13
#define	CH14 0x000E           //Channel 14
#define	CH15 0x000F           //Channel 15
#define	CH16 0x0010           //Channel 16
#define	CH17 0x0011           //Channel 17
#define	CH18 0x0012           //Channel 18
#define	CH19 0x0013           //Channel 19
#define	CH20 0x0014           //Channel 20
#define	CH21 0x0015           //Channel 21
#define	CH22 0x0016           //Channel 22
#define	CH23 0x0017           //Channel 23
#define	CH24 0x0018           //Channel 24
#define	CH25 0x0019           //Channel 25
#define	CH26 0x001A           //Channel 26
#define	CH27 0x001B           //Channel 27
#define	CH28 0x001C           //Channel 28
#define	CH29 0x001D           //Channel 29
#define	CH30 0x001E           //Channel 30
#define	CH31 0x001F           //Channel 31

/**
*
*  SDI selection constants
*
**/

enum {	SDI00                 = 0x0001,           //Enable SDI00
		SDI01                 = 0x0002,           //Enable SDI01
		SDI10                 = 0x0004,           //Enable SDI10
		SDI11                 = 0x0008,           //Enable SDI11
		SDIALL                = 0x000F            //Enable all SDIs
};

/**
*
*  Channel configuration options
*
**/

enum {	CHCFG429_DEFAULT      = 0x00000000L,      //Select all default settings (XMT & RCV) (default)
		CHCFG429_HIGHSPEED    = 0x00000001L,      //Select high speed (XMT & RCV)
		CHCFG429_AUTOSPEED    = 0x00000002L,      //Select auto speed detection (RCV)
		CHCFG429_LOWSPEED     = 0x00000000L,      //Select low speed (XMT & RCV) (default)
		CHCFG429_SELFTEST     = 0x00000004L,      //Enable internal wraparound (XMT & RCV)
		CHCFG429_SELFTESTOFF  = 0x00000000L,      //Disable internal wraparound (XMT & RCV) (default)
		CHCFG429_SYNC         = 0x00000008L,      //Sync Enable (XMT & RCV)
		CHCFG429_SYNCOFF      = 0x00000000L,      //Disable sync output (XMT & RCV) (default)
		CHCFG429_PARODD       = 0x00000000L,      //Parity odd (XMT & RCV) (default)
		CHCFG429_PAREVEN      = 0x00000010L,      //Parity even (XMT & RCV)
		CHCFG429_PARDATA      = 0x00000020L,      //Parity bit as data (XMT & RCV)
		CHCFG429_ACTIVE       = 0x00000000L,      //Enable channel activity (XMT & RCV) (default)
		CHCFG429_INACTIVE     = 0x00000040L,      //Disable channel activity (XMT & RCV)
		CHCFG429_EXTTRIG      = 0x00000080L,      //Enable external trigger for all messages (XMT)
		CHCFG429_EXTOFF       = 0x00000000L,      //External trigger is enabled on message level (XMT) (default)
		CHCFG429_PARERR       = 0x00000100L,      //Enable parity error for all messages (XMT)
		CHCFG429_NOERR        = 0x00000000L,      //Errors are enabled on message level (XMT) (default)
		CHCFG429_HIT          = 0x00000200L,      //Hit counter is enabled for all messages
		CHCFG429_NOHIT        = 0x00000000L,      //Hit counter is enabled on message level (default)
		CHCFG429_TIMETAG      = 0x00000400L,      //Enable time-tag for all message records
		CHCFG429_TIMETAGOFF   = 0x00000000L,      //Time-tag is enabled on message level (default)
		CHCFG429_ELAPSE       = 0x00000800L,      //Enable elapse time for all messages
		CHCFG429_ELAPSEOFF    = 0x00000000L,      //Elapse time is enabled on message level (default)
		CHCFG429_MAX          = 0x00001000L,      //Enable max repetition rate monitoring for all messages
		CHCFG429_MIN          = 0x00002000L,      //Enable min repetition rate monitoring for all messages
		CHCFG429_MAXMIN       = 0x00003000L,      //Enable max and min repetition rate monitoring for all messages
		CHCFG429_MAXMINOFF    = 0x00000000L,      //Repetition rate monitoring is enabled on message level (default)
		CHCFG429_SEQALL       = 0x00080000L,      //Record entire channel in sequential record
		CHCFG429_SEQSEL       = 0x00000000L,      //Sequential record recording is enabled at message level (default)
		CHCFG429_LOOPMAX      = 0x00100000L,      //Enable schedule maximum loop count
		CHCFG429_NOLOOPMAX    = 0x00000000L,      //Disable schedule maximum loop count (default)
		CHCFG429_LOGHALT      = 0x00200000L,      //Enable event log on schedule halt
		CHCFG429_NOLOGHALT    = 0x00000000L,      //No event log on schedule halt (default)
		CHCFG429_LOGPAUSE     = 0x00400000L,      //Enable event log on schedule pause
		CHCFG429_NOLOGPAUSE   = 0x00000000L,      //No event log on schedule pause (default)
		CHCFG429_LOGERR       = 0x00800000L,      //Enable event log on decoder errors.
		CHCFG429_NOLOGERR     = 0x00000000L,      //No event log on decoder errors (default)
		CHCFG429_PAUSE        = 0x01000000L,      //Mark channel as paused
		CHCFG429_UNPAUSE      = 0x00000000L       //Mark channel as unpaused (default)
};

/**
*
*  Message configuration options
*
**/

enum {	MSGCRT429_DEFAULT     = 0x00000000L,      //Default settings
		MSGCRT429_NOSEQ       = 0x00000000L,      //Message will not be recorded in sequential record (default)
		MSGCRT429_SEQ         = 0x00000001L,      //Message will be recorded in sequential record
		MSGCRT429_NOLOG       = 0x00000000L,      //Message will not generate event log (default)
		MSGCRT429_LOG         = 0x00000002L,      //Message will generate event log
		MSGCRT429_NOSKIP      = 0x00000000L,      //Message will not be skipped (default)
		MSGCRT429_SKIP        = 0x00000008L,      //Message will be skipped
		MSGCRT429_NOTIMETAG   = 0x00000000L,      //Message will not record time-tag (default)
		MSGCRT429_TIMETAG     = 0x00000010L,      //Message will record time-tag
		MSGCRT429_NOELAPSE    = 0x00000000L,      //Message will not record elapse time (default)
		MSGCRT429_ELAPSE      = 0x00000020L,      //Message will record elapse time
		MSGCRT429_NOMAXMIN    = 0x00000000L,      //Message will not record min/max time (default)
		MSGCRT429_MAX         = 0x00000040L,      //Message will record max time
		MSGCRT429_MIN         = 0x00000080L,      //Message will record min time
		MSGCRT429_MAXMIN      = 0x000000C0L,      //Message will record min/max time
		MSGCRT429_NOSYNC      = 0x00000000L,      //No sync will be generated for message (default)
		MSGCRT429_SYNC        = 0x00000100L,      //Sync will be generated for message
		MSGCRT429_NOERR       = 0x00000000L,      //No error will be generated for message (default)
		MSGCRT429_PARERR      = 0x00000200L,      //Parity error will be generated for message
		MSGCRT429_NOHIT       = 0x00000000L,      //Message will not record hit count (default)
		MSGCRT429_HIT         = 0x00000400L,      //Message will record hit count
		MSGCRT429_NOEXTRIG    = 0x00000000L,      //Message will not be externally triggered (default)
		MSGCRT429_EXTRIG      = 0x00001000L,      //Message will be externally triggered
		MSGCRT429_WIPE        = 0x00000000L,      //Enables message clear (default)
		MSGCRT429_NOWIPE      = 0x80000000L,      //Disables message clear
		MSGCRT429_WIPE0       = 0x00000000L,      //Initialize data with zeros (default)
		MSGCRT429_WIPE1       = 0x40000000L       //Initialize data with ones
};

/**
*
*  List buffer options
*
**/

enum {	LISTCRT429_DEFAULT    = 0x00000000L,      //Select all default settings
		LISTCRT429_FIFO       = 0x00000000L,      //Enable FIFO mode (default)
		LISTCRT429_PINGPONG   = 0x00000001L,      //Enable ping-pong mode
		LISTCRT429_CIRCULAR   = 0x00000002L,      //Enable circular mode
		LISTCRT429_RCV        = 0x00000010L,      //User will read from list buffer
		LISTCRT429_XMT        = 0x00000020L,      //User will write to list buffer
		LISTCRT429_ASYNC      = 0x00000040L,      //Asynchronous mode
		LISTCRT429_NOLOG      = 0x00000000L,      //Do not generate event log when list buffer empty/full (default)
		LISTCRT429_LOG        = 0x00000100L       //Generate event log when list buffer empty/full
};

/**
*
*  Parametric configuration options
*
**/

enum {	PARAMCFG429_DEFAULT    = 0x00000000L,     //Select all default settings (default)
		PARAMCFG429_AMPLON     = 0x00000000L,     //Enables parametric amplitude control (default)
		PARAMCFG429_AMPLOFF    = 0x00000001L,     //Disables parametric amplitude control
		PARAMCFG429_BITRATEON  = 0x00000000L,     //Enables parametric bit rate control (default)
		PARAMCFG429_BITRATEOFF = 0x00000002L      //Disables parametric bit rate control
};

/**
*
*  Scheduling conditions.
*
**/

enum {	COND429_ALWAYS        = 0x00000000L,      //Unconditional
		COND429_DIO1ACT       = 0x00000001L,      //Condition on digital I/O #1 active
		COND429_DIO1NACT      = 0x00000002L,      //Condition on digital I/O #1 not active
		COND429_DIO2ACT       = 0x00000004L,      //Condition on digital I/O #2 active
		COND429_DIO2NACT      = 0x00000008L,      //Condition on digital I/O #2 not active
		COND429_DIO3ACT       = 0x00000010L,      //Condition on digital I/O #3 active
		COND429_DIO3NACT      = 0x00000020L,      //Condition on digital I/O #3 not active
		COND429_DIO4ACT       = 0x00000040L,      //Condition on digital I/O #4 active
		COND429_DIO4NACT      = 0x00000080L,      //Condition on digital I/O #4 not active
		COND429_DIO5ACT       = 0x00000100L,      //Condition on digital I/O #5 active
		COND429_DIO5NACT      = 0x00000200L,      //Condition on digital I/O #5 not active
		COND429_DIO6ACT       = 0x00000400L,      //Condition on digital I/O #6 active
		COND429_DIO6NACT      = 0x00000800L,      //Condition on digital I/O #6 not active
		COND429_DIO7ACT       = 0x00001000L,      //Condition on digital I/O #7 active
		COND429_DIO7NACT      = 0x00002000L,      //Condition on digital I/O #7 not active
		COND429_DIO8ACT       = 0x00004000L,      //Condition on digital I/O #8 active
		COND429_DIO8NACT      = 0x00008000L       //Condition on digital I/O #8 not active
};

/**
*
*  Bit fields of the message activity flag.
*
**/

enum {	MSGACT429_CHMASK      = 0xFF00,           //Channel number mask value
		MSGACT429_CHSHIFT     = 0x0008,           //Channel number shift value
		MSGACT429_SPD         = 0x0080,           //Bus speed
		MSGACT429_ERR         = 0x0040,           //Error bit
		MSGACT429_GAP         = 0x0020,           //Gap error bit
		MSGACT429_PAR         = 0x0010,           //Parity error bit
		MSGACT429_LONG        = 0x0008,           //Long word error bit
		MSGACT429_BIT         = 0x0004,           //Bit time error bit
		MSGACT429_TO          = 0x0002,           //Time out error bit
		MSGACT429_HIT         = 0x0001            //Always set
};

/**
*
*  Channel info fields.
*
**/

enum {	INFO429_PARAM         = 0x0001           //Channel supports parametric control
};

/**
*
*  Scheduling algorithm options
*
**/

enum {
		SCHEDMODE_DEFAULT        = 0x0000,         //Select all default settings
		SCHEDMODE_METHOD_NORMAL  = 0x0000,         //Choose the normal scheduling method
		SCHEDMODE_METHOD_QUICK   = 0x0001,         //Choose the quick scheduling method
		SCHEDMODE_METHOD_BOTH    = 0x0002,         //Use the quick method first, if fail, then use the normal method
		SCHEDMODE_METHOD_MASK    = 0x000F,         //Mask for method setting
		SCHEDMODE_MILLISEC       = 0x0000,         //Specify periods in milliseconds
		SCHEDMODE_MICROSEC       = 0x0010,         //Specify periods in microseconds
		SCHEDMODE_REMOTE         = 0x0000,         //Perform calculations remotely, if applicable
		SCHEDMODE_LOCAL          = 0x0020,         //Perform calculations locally, if applicable

		                                           //Deprecated options
		SCHEDMODE_DEFAULT_ALGOR  = 0x0000,         //Choose the default algorithm
		SCHEDMODE_QUICK_ALGOR    = 0x0001,         //Choose the quick algorithm
		SCHEDMODE_BOTH_ALGOR     = 0x0002,         //Use the quick algorithm first, if fail, then use the normal algorithm
		SCHEDMODE_ALGOR_MASK     = 0x000F          //Mask for algorithm setting
};

#endif
