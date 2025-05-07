/**
*
*  BTICSDB WIN32 DRIVER  Version 1.1.2  (03/02/2010)
*  Copyright (c) 2005-2010
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   BTICSDB.H -- Visual C++ 32-bit
*                      BTICSDB Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for Ballard Technology CSDB
*  cards.  Applications using the BTICSDB Driver Library must
*  incorporate this include file using the preprocessor
*  directive #include. If this file is in the current working
*  directory, the form would be:
*
*  #include "BTICSDB.H"
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

#ifndef __BTICSDB_H
#define __BTICSDB_H

/**
*
*  Pragma to specify link library.
*
**/

#ifdef __BORLANDC__
#pragma comment(lib,"bticsdbbc.lib")
#else
#if defined(_WIN32)
#if defined(_WIN64)
#pragma comment(lib,"bticsdb64.lib")
#else
#pragma comment(lib,"bticsdb.lib")
#endif
#endif
#endif

/**
*
*  Typedefs used by the BTICSDB Driver.
*
**/

#ifndef BTICSDBAPI
#ifdef __BORLANDC__
#define BTICSDBAPI
#else
#define BTICSDBAPI __declspec(dllimport)
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
*  Structs used by the BTICSDB Driver.
*
**/
#ifndef MSGFIELDSCSDB

typedef struct
{
	USHORT  msgopt;             //Driver writes message options
	USHORT  msgoptext;          //Non-continuous, Valid, and current burst count (FW)
	USHORT  burstcount;         //Burst count (API)
	USHORT  reserved;           //reserved
	USHORT  msgact;             //Card writes message activity
	USHORT  datacount;          //Number of valid bytes in data[] buffer
	ULONG   listptr;            //Driver writes list buffer pointer
	union {
		ULONG  timetag;         //Card writes time-tag low value (32 bits)
		ULONG  hitcount;        //Card writes hit count
	};
	union {
		ULONG  maxtime;         //Card writes max time
		ULONG  elapsetime;      //Card writes elapsed time
	};
	ULONG   mintime;            //Card writes min time
	ULONG   userptr;            //Driver writes user code pointer
	ULONG   miscptr;            //reserved
	ULONG   timetagh;           //Card writes extended timetag (32 bits)
	USHORT  data[32];           //Card writes data block
} MSGFIELDSCSDB;

#endif

#ifndef LPMSGFIELDSCSDB
typedef MSGFIELDSCSDB * LPMSGFIELDSCSDB;
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
*  BTICSDB Driver functions.
*
**/

BTICSDBAPI ERRVAL __stdcall BTICSDB_ChClear(INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_ChConfig(ULONG configval,USHORT bitrateflag,USHORT bytesperblock,USHORT framespersecond,USHORT blocksperframe,INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_ChGetCount(LPINT rcvcount,LPINT xmtcount,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_ChGetInfo(USHORT infotype,INT channum,HCORE handleval);
BTICSDBAPI BOOL __stdcall BTICSDB_ChIsCSDB(INT channum,HCORE handleval);
BTICSDBAPI BOOL __stdcall BTICSDB_ChIsRcv(INT channum,HCORE handleval);
BTICSDBAPI BOOL __stdcall BTICSDB_ChIsXmt(INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_ChPause(INT channum,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_ChPauseCheck(INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_ChResume(INT channum,HCORE handleval);
BTICSDBAPI BOOL __stdcall BTICSDB_ChStart(INT channum,HCORE handleval);
BTICSDBAPI BOOL __stdcall BTICSDB_ChStop(INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_FilterClear(BASEADDR baseaddr,HCORE handleval);
BTICSDBAPI MSGADDR __stdcall BTICSDB_FilterDefault(ULONG configval,INT channum,HCORE handleval);
BTICSDBAPI MSGADDR __stdcall BTICSDB_FilterRd(INT addrval,INT sival,INT channum,HCORE handleval);
BTICSDBAPI MSGADDR __stdcall BTICSDB_FilterSet(ULONG configval,INT addrval,INT simask,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_FilterWr(MSGADDR msgaddr,INT addrval,INT sival,INT channum,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_ListDataRd(LPBYTE buf,INT count,LISTADDR listaddr,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_ListDataWr(LPBYTE buf,INT count,LISTADDR listaddr,HCORE handleval);
BTICSDBAPI LISTADDR __stdcall BTICSDB_ListRcvCreate(ULONG listconfigval,INT count,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_ListStatus(LISTADDR listaddr,HCORE handleval);
BTICSDBAPI LISTADDR __stdcall BTICSDB_ListXmtCreate(ULONG listconfigval,INT count,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI MSGADDR __stdcall BTICSDB_MsgBlockRd(LPMSGFIELDSCSDB msgfields,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI MSGADDR __stdcall BTICSDB_MsgBlockWr(LPMSGFIELDSCSDB msgfields,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI MSGADDR __stdcall BTICSDB_MsgCreate(ULONG configval,HCORE handleval);
BTICSDBAPI BYTE __stdcall BTICSDB_MsgDataByteRd(INT index,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_MsgDataByteWr(BYTE data,INT index,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_MsgDataRd(LPBYTE buf,INT count,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_MsgDataWr(LPBYTE buf,INT count,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI BOOL __stdcall BTICSDB_MsgIsAccessed(MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI USHORT __stdcall BTICSDB_MsgValidSet(MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_ParamAmplitudeConfig(ULONG configval,USHORT dacval,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_ParamAmplitudeGet(LPUSHORT dacval,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedBranch(ULONG condition,SCHNDX destindex,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_SchedBuild(INT nummsgs,LPMSGADDR msgs,LPINT freq,INT interblockgap,INT rsvdblocks,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedCall(ULONG condition,SCHNDX destindex,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedEntry(INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedGap(USHORT gapval,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedHalt(INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedLog(ULONG condition,USHORT tagval,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedMsg(MSGADDR msgaddr,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedPause(INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedPulse(INT dionum,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedRestart(INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedReturn(INT channum,HCORE handleval);

/**
*
*  Internal functions used by the BTICSDB Driver.
*
**/

BTICSDBAPI ERRVAL __stdcall BTICSDB_ChConfigEx(ULONG configval,USHORT bitrateflag,USHORT bytesperblock,USHORT framespersecond,USHORT blocksperframe,USHORT interbytegap,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_ChConfigExx(ULONG configval,USHORT count,USHORT bitrateflag,USHORT bytesperblock,USHORT framespersecond,USHORT blocksperframe,USHORT interbytegap,INT channum,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_CmdAddr(SCHNDX index,INT channum,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_CmdAlloc(INT count,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_CmdAllocEx(ULONG configval,INT count,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_CmdBaseRd(INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_CmdBaseWr(ULONG addrval,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_CmdClear(INT channum,HCORE handleval);
BTICSDBAPI USHORT __stdcall BTICSDB_CmdCountRd(INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_CmdCountWr(USHORT countval,INT channum,HCORE handleval);
BTICSDBAPI USHORT __stdcall BTICSDB_CmdCtrlRd(SCHNDX index,INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_CmdCtrlWr(USHORT ctrlval,SCHNDX index,INT channum,HCORE handleval);
BTICSDBAPI USHORT __stdcall BTICSDB_CmdCurrRd(INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_CmdCurrWr(USHORT addrval,INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_CmdInit(USHORT opcode,LPUSHORT block);
BTICSDBAPI SCHNDX __stdcall BTICSDB_CmdInsert(LPUSHORT block,INT channum,HCORE handleval);
BTICSDBAPI USHORT __stdcall BTICSDB_CmdMaxLoopRd(INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_CmdMaxLoopWr(USHORT countval,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_CmdRd(LPUSHORT block,ULONG addrval,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_CmdRestart(INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_CmdShotWr(BOOL value,SCHNDX index,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_CmdSkipWr(BOOL value,SCHNDX index,INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_CmdStackClr(INT channum,HCORE handleval);
BTICSDBAPI USHORT __stdcall BTICSDB_CmdStartRd(INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_CmdStartWr(USHORT addrval,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_CmdStepWr(BOOL value,SCHNDX index,INT channum,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_CmdTotalRd(INT channum,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_CmdTotalWr(INT countval,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_CmdWr(LPUSHORT block,ULONG addrval,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_DllUsageCount(VOID);
BTICSDBAPI ULONG __stdcall BTICSDB_FilterAddr(INT addrval,INT sival,INT channum,HCORE handleval);
BTICSDBAPI BASEADDR __stdcall BTICSDB_FilterCreate(HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_FilterFill(MSGADDR msgaddr,BASEADDR baseaddr,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_GetChanCount(LPINT rcvcount,LPINT xmtcount,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_HookMsgProc(INT msgval,LPVOID lpParam,HCORE handleval);
BTICSDBAPI BOOL __stdcall BTICSDB_IsChan(INT channum,HCORE handleval);
BTICSDBAPI BOOL __stdcall BTICSDB_IsRcvChan(INT channum,HCORE handleval);
BTICSDBAPI BOOL __stdcall BTICSDB_IsXmtChan(INT channum,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_ListAddr(INT index,LISTADDR listaddr,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_ListAddrEx(INT index,LISTADDR listaddr,LPUSHORT header,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_ListAdvance(LISTADDR listaddr,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_ListClear(LISTADDR listaddr,HCORE handleval);
BTICSDBAPI LISTADDR __stdcall BTICSDB_ListConfig(ULONG configval,INT count,HCORE handleval);
BTICSDBAPI LISTADDR __stdcall BTICSDB_ListConfigEx(ULONG configval,INT count,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_ListDataRdEx(LPBYTE buf,INT count,INT index,LISTADDR listaddr,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_ListDataWrEx(LPBYTE buf,INT count,INT index,LISTADDR listaddr,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_ListInit(LISTADDR listaddr,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_ListNextRd(ULONG listaddr,LPUSHORT header,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_ListNextWr(ULONG listaddr,LPUSHORT header,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_ListPostRd(LISTADDR listaddr,LPUSHORT header,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_ListPostWr(LISTADDR listaddr,LPUSHORT header,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_ListPreRd(LISTADDR listaddr,LPUSHORT header,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_ListPreWr(LISTADDR listaddr,LPUSHORT header,HCORE handleval);
BTICSDBAPI USHORT __stdcall BTICSDB_MsgActivityRd(MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_MsgActivityWr(USHORT value,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI USHORT __stdcall BTICSDB_MsgCheck(MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI MSGADDR __stdcall BTICSDB_MsgCommRd(LPMSGFIELDSCSDB msgfields,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI MSGADDR __stdcall BTICSDB_MsgCommWr(LPMSGFIELDSCSDB msgfields,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_MsgConfig(ULONG configval,INT count,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI MSGADDR __stdcall BTICSDB_MsgCreateEx(ULONG configval,INT count,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_MsgFieldRd(INT fieldtype,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI ULONG __stdcall BTICSDB_MsgFieldWr(ULONG fieldval,INT fieldtype,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI USHORT __stdcall BTICSDB_MsgOptRd(MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI VOID __stdcall BTICSDB_MsgOptWr(USHORT msgopt,MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI MSGADDR __stdcall BTICSDB_MsgReset(MSGADDR msgaddr,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_ProcSetPost(ULONG useraddr,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_ProcSetPre(ULONG useraddr,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedAgain(SCHNDX index,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedBranchEx(USHORT condition1,USHORT condition2,SCHNDX destindex,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_SchedBuildEx(INT nummsgs,LPMSGADDR msgs,LPINT freq,INT interblockgap,INT rsvdblocks,INT bitrate,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_SchedBuildExx(INT nummsgs,LPMSGADDR msgs,LPINT freq,INT interblockgap,INT rsvdblocks,INT bitrate,LPVOID buf,ULONG bufsize,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedCallEx(USHORT condition1,USHORT condition2,SCHNDX destindex,INT channum,HCORE handleval);
BTICSDBAPI INT __stdcall BTICSDB_SchedGCD(INT a,INT b);
BTICSDBAPI INT __stdcall BTICSDB_SchedLCM(INT a,INT b);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedLogEx(USHORT condition1,USHORT condition2,USHORT tagval,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedNop(INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedPulse0(INT dionum,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedPulse1(INT dionum,INT channum,HCORE handleval);
BTICSDBAPI SCHNDX __stdcall BTICSDB_SchedUser(ULONG useraddr,INT channum,HCORE handleval);
BTICSDBAPI ERRVAL __stdcall BTICSDB_TestProtocol(HCORE handleval);

#ifdef __cplusplus
}
#endif

/**
*
*  Channel number constants
*
**/

#define	CH0  0x0000           //Channel 0
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
*  Bitrate configuration options
*
**/

#define	BITRATECSDB_CLK1            0x8000      //CLK1, 20 MHz (default)
#define	BITRATECSDB_CLK2            0x0000      //CLK2, 9.216 MHz (standard option)
#define	BITRATECSDB_XMTSLOPEHIGH    0x0000      //Transmit with high speed slope (default)
#define	BITRATECSDB_XMTSLOPELOW     0x4000      //Transmit with low speed slope

#define	BITRATECSDB_921600BPS   0x0000          //External Clock, Div = 0
#define	BITRATECSDB_460800BPS   0x0001          //External Clock, Div = 1
#define	BITRATECSDB_230400BPS   0x0003          //External Clock, Div = 3
#define	BITRATECSDB_115200BPS   0x0007          //External Clock, Div = 7
#define	BITRATECSDB_57600BPS    0x000F          //External Clock, Div = 15
#define	BITRATECSDB_38400BPS    0x0017          //External Clock, Div = 23
#define	BITRATECSDB_28800BPS    0x001F          //External Clock, Div = 31
#define	BITRATECSDB_19200BPS    0x002F          //External Clock, Div = 47
#define	BITRATECSDB_14400BPS    0x003F          //External Clock, Div = 63
#define	BITRATECSDB_9600BPS     0x005F          //External Clock, Div = 95
#define	BITRATECSDB_7200BPS     0x007F          //External Clock, Div = 127
#define	BITRATECSDB_4800BPS     0x00BF          //External Clock, Div = 191
#define	BITRATECSDB_3600BPS     0x00FF          //External Clock, Div = 255
#define	BITRATECSDB_2400BPS     0x017F          //External Clock, Div = 383
#define	BITRATECSDB_1800BPS     0x01FF          //External Clock, Div = 511
#define	BITRATECSDB_1200BPS     0x02FF          //External Clock, Div = 767
#define	BITRATECSDB_900BPS      0x03FF          //External Clock, Div = 1023
#define	BITRATECSDB_600BPS      0x05FF          //External Clock, Div = 1535
#define	BITRATECSDB_300BPS      0x0BFF          //External Clock, Div = 3071

#define	BITRATECSDB_500000BPS   0x8003          //Internal Clock, Div = 3
#define	BITRATECSDB_400000BPS   0x8004          //Internal Clock, Div = 4
#define	BITRATECSDB_250000BPS   0x8007          //Internal Clock, Div = 7
#define	BITRATECSDB_200000BPS   0x8009          //Internal Clock, Div = 9
#define	BITRATECSDB_100000BPS   0x8013          //Internal Clock, Div = 19
#define	BITRATECSDB_80000BPS    0x8018          //Internal Clock, Div = 24
#define	BITRATECSDB_50000BPS    0x8027          //Internal Clock, Div = 39
#define	BITRATECSDB_40000BPS    0x8031          //Internal Clock, Div = 49
#define	BITRATECSDB_25000BPS    0x804F          //Internal Clock, Div = 79
#define	BITRATECSDB_20000BPS    0x8063          //Internal Clock, Div = 99
#define	BITRATECSDB_12500BPS    0x809F          //Internal Clock, Div = 159
#define	BITRATECSDB_10000BPS    0x80C7          //Internal Clock, Div = 199

#define	BITRATECSDB_HIGHSPEED   0xC027          //Internal Clock, Div = 39
#define	BITRATECSDB_LOWSPEED    0xC09F          //Internal Clock, Div = 159

/**
*
*  SDI selection constants
*
**/

enum {	SIALL                 = 0x00FF,           //Enable all SIs
		SIx00                 = 0x0011,           //Enable SIx00
		SIx01                 = 0x0022,           //Enable SIx01
		SIx10                 = 0x0044,           //Enable SIx10
		SIx11                 = 0x0088,           //Enable SIx11
		SI000                 = 0x0001,           //Enable SI000
		SI001                 = 0x0002,           //Enable SI001
		SI010                 = 0x0004,           //Enable SI010
		SI011                 = 0x0008,           //Enable SI011
		SI100                 = 0x0010,           //Enable SI100
		SI101                 = 0x0020,           //Enable SI101
		SI110                 = 0x0040,           //Enable SI110
		SI111                 = 0x0080            //Enable SI111
};

/**
*
*  Channel configuration options
*
**/


enum {	CHCFGCSDB_DEFAULT      = 0x00000000L,      //Select all default settings (XMT & RCV) (default)
		CHCFGCSDB_SELFTESTOFF  = 0x00000000L,      //Disable internal wraparound (XMT & RCV) (default)
		CHCFGCSDB_SELFTEST     = 0x00000004L,      //Enable internal wraparound (XMT & RCV)
		CHCFGCSDB_PARITYODD    = 0x00000000L,      //Enable odd parity (XMT & RCV) (default)
		CHCFGCSDB_PARITYNONE   = 0x80000000L,      //Disable parity (XMT & RCV)
		CHCFGCSDB_PARITYEVEN   = 0x40000000L,      //Enable even parity (XMT & RCV)
		CHCFGCSDB_PARITYMARK   = 0x20000000L,      //Force set parity (XMT & RCV)
		CHCFGCSDB_PARITYSPACE  = 0x10000000L,      //Force clear parity (XMT & RCV)
		CHCFGCSDB_ACTIVE       = 0x00000000L,      //Enable channel activity (XMT & RCV) (default)
		CHCFGCSDB_INACTIVE     = 0x00000040L,      //Disable channel activity (XMT & RCV)
		CHCFGCSDB_SEQSEL       = 0x00000000L,      //Sequential record recording is enabled at message level (default)
		CHCFGCSDB_SEQALL       = 0x00080000L,      //Record entire channel in sequential record
		CHCFGCSDB_NOLOGHALT    = 0x00000000L,      //No event log on schedule halt (default)
		CHCFGCSDB_LOGHALT      = 0x00200000L,      //Enable event log on schedule halt
		CHCFGCSDB_NOLOGPAUSE   = 0x00000000L,      //No event log on schedule pause (default)
		CHCFGCSDB_LOGPAUSE     = 0x00400000L,      //Enable event log on schedule pause
		CHCFGCSDB_NOLOGERR     = 0x00000000L,      //No event log on decoder errors (default)
		CHCFGCSDB_LOGERR       = 0x00800000L,      //Enable event log on decoder errors and sync errors.
		CHCFGCSDB_TIMETAGOFF   = 0x00000000L,      //Time-tag is enabled on message level (default)
		CHCFGCSDB_TIMETAG      = 0x00000400L,      //Enable time-tag for all message records
		CHCFGCSDB_NOHIT        = 0x00000000L,      //Hit counter is enabled on message level (default)
		CHCFGCSDB_HIT          = 0x00000200L,      //Hit counter is enabled for all messages
		CHCFGCSDB_ELAPSEOFF    = 0x00000000L,      //Elapse time is enabled on message level (default)
		CHCFGCSDB_ELAPSE       = 0x00000800L,      //Enable elapse time for all messages
		CHCFGCSDB_MAXMINOFF    = 0x00000000L,      //Repetition rate monitoring is enabled on message level (default)
		CHCFGCSDB_MAX          = 0x00001000L,      //Enable max repetition rate monitoring for all messages
		CHCFGCSDB_MIN          = 0x00002000L,      //Enable min repetition rate monitoring for all messages
		CHCFGCSDB_MAXMIN       = 0x00003000L,      //Enable max and min repetition rate monitoring for all messages
		CHCFGCSDB_NOLOOPMAX    = 0x00000000L,      //Disable schedule maximum loop count (default)
		CHCFGCSDB_LOOPMAX      = 0x00100000L,      //Enable schedule maximum loop count
		CHCFGCSDB_UNPAUSE      = 0x00000000L,      //Mark channel as unpaused (default)
		CHCFGCSDB_PAUSE        = 0x01000000L,      //Mark channel as paused
		CHCFGCSDB_BUSINVERTOFF = 0x00000000L,      //No bus inversion (default)
		CHCFGCSDB_BUSINVERT    = 0x00000001L,      //Enable bus inversion
		CHCFGCSDB_MODE422      = 0x00000000L,      //Enable RS-422 mode (balanced) (XMT) (default)
		CHCFGCSDB_MODE232      = 0x08000000L,      //Enable RS-232 / RS-423 mode (unbalanced) (XMT)
		CHCFGCSDB_SYNCMODE     = 0x00000000L,      //Synchronous, scheduled mode (CSDB) (default)
		CHCFGCSDB_ASYNCMODE    = 0x00000002L       //Asynchrounous mode (general purpose serial)
};

/**
*
*  Message configuration options
*
**/

enum {	MSGCRTCSDB_DEFAULT     = 0x00000000L,      //Default settings
		MSGCRTCSDB_NOSEQ       = 0x00000000L,      //Message will not be recorded in sequential record (default)
		MSGCRTCSDB_SEQ         = 0x00000001L,      //Message will be recorded in sequential record
		MSGCRTCSDB_NOLOG       = 0x00000000L,      //Message will not generate event log (default)
		MSGCRTCSDB_LOG         = 0x00000002L,      //Message will generate event log
		MSGCRTCSDB_NOERROR     = 0x00000000L,      //Message will not generate errors (default)
		MSGCRTCSDB_ERROR       = 0x00000004L,      //Message can generate errors
		MSGCRTCSDB_NOSKIP      = 0x00000000L,      //Message will not be skipped (default)
		MSGCRTCSDB_SKIP        = 0x00000008L,      //Message will be skipped
		MSGCRTCSDB_NOTIMETAG   = 0x00000000L,      //Message will not record time-tag (default)
		MSGCRTCSDB_TIMETAG     = 0x00000010L,      //Message will record time-tag
		MSGCRTCSDB_NOELAPSE    = 0x00000000L,      //Message will not record elapse time (default)
		MSGCRTCSDB_ELAPSE      = 0x00000020L,      //Message will record elapse time
		MSGCRTCSDB_NOMAXMIN    = 0x00000000L,      //Message will not record min/max time (default)
		MSGCRTCSDB_MAX         = 0x00000040L,      //Message will record max time
		MSGCRTCSDB_MIN         = 0x00000080L,      //Message will record min time
		MSGCRTCSDB_MAXMIN      = 0x000000C0L,      //Message will record min/max time
		MSGCRTCSDB_NOHIT       = 0x00000000L,      //Message will not record hit count (default)
		MSGCRTCSDB_HIT         = 0x00000800L,      //Message will record hit count
		MSGCRTCSDB_WIPE        = 0x00000000L,      //Enables message clear (default)
		MSGCRTCSDB_NOWIPE      = 0x80000000L,      //Disables message clear
		MSGCRTCSDB_WIPE0       = 0x00000000L,      //Initialize data with zeros (default)
		MSGCRTCSDB_WIPE1       = 0x40000000L,      //Initialize data with ones
		MSGCRTCSDB_WIPESYNC    = 0x20000000L,      //Initialize data with 0xA5
		MSGCRTCSDB_CONT        = 0x00000000L,      //Selects continuous mode (default)
		MSGCRTCSDB_NONCONT     = 0x00002000L,      //Selects non-continuous mode
		MSGCRTCSDB_BURST       = 0x00004000L       //Selects burst mode
};

/**
*
*  List buffer options
*
**/

enum {	LISTCRTCSDB_DEFAULT    = 0x00000000L,      //Select all default settings
		LISTCRTCSDB_FIFO       = 0x00000000L,      //Enable FIFO mode (default)
		LISTCRTCSDB_PINGPONG   = 0x00000001L,      //Enable ping-pong mode
		LISTCRTCSDB_CIRCULAR   = 0x00000002L,      //Enable circular mode
		LISTCRTCSDB_RCV        = 0x00000010L,      //User will read from list buffer
		LISTCRTCSDB_XMT        = 0x00000020L,      //User will write to list buffer
		LISTCRTCSDB_NOLOG      = 0x00000000L,      //Do not generate event log when list buffer empty/full (default)
		LISTCRTCSDB_LOG        = 0x00000100L       //Generate event log when list buffer empty/full
};

/**
*
*  Parametric configuration options
*
**/

enum {	PARAMCFGCSDB_DEFAULT    = 0x00000000L,     //Select all default settings (default)
		PARAMCFGCSDB_AMPLON     = 0x00000000L,     //Enables parametric amplitude control (default)
		PARAMCFGCSDB_AMPLOFF    = 0x00000001L      //Disables parametric amplitude control
};

/**
*
*  Scheduling conditions.
*
**/

enum {	CONDCSDB_ALWAYS        = 0x00000000L,      //Unconditional
		CONDCSDB_DIO1ACT       = 0x00000001L,      //Condition on digital I/O #1 active
		CONDCSDB_DIO1NACT      = 0x00000002L,      //Condition on digital I/O #1 not active
		CONDCSDB_DIO2ACT       = 0x00000004L,      //Condition on digital I/O #2 active
		CONDCSDB_DIO2NACT      = 0x00000008L,      //Condition on digital I/O #2 not active
		CONDCSDB_DIO3ACT       = 0x00000010L,      //Condition on digital I/O #3 active
		CONDCSDB_DIO3NACT      = 0x00000020L,      //Condition on digital I/O #3 not active
		CONDCSDB_DIO4ACT       = 0x00000040L,      //Condition on digital I/O #4 active
		CONDCSDB_DIO4NACT      = 0x00000080L,      //Condition on digital I/O #4 not active
		CONDCSDB_DIO5ACT       = 0x00000100L,      //Condition on digital I/O #5 active
		CONDCSDB_DIO5NACT      = 0x00000200L,      //Condition on digital I/O #5 not active
		CONDCSDB_DIO6ACT       = 0x00000400L,      //Condition on digital I/O #6 active
		CONDCSDB_DIO6NACT      = 0x00000800L,      //Condition on digital I/O #6 not active
		CONDCSDB_DIO7ACT       = 0x00001000L,      //Condition on digital I/O #7 active
		CONDCSDB_DIO7NACT      = 0x00002000L,      //Condition on digital I/O #7 not active
		CONDCSDB_DIO8ACT       = 0x00004000L,      //Condition on digital I/O #8 active
		CONDCSDB_DIO8NACT      = 0x00008000L       //Condition on digital I/O #8 not active
};

/**
*
*  Bit fields of the message activity flag.
*
**/

enum {	MSGACTCSDB_CHMASK      = 0xFF00,           //Channel number mask value
		MSGACTCSDB_CHSHIFT     = 0x0008,           //Channel number shift value
		MSGACTCSDB_ERR         = 0x0080,           //Error bit
		MSGACTCSDB_BIT         = 0x0040,           //Bit time error bit
		MSGACTCSDB_NRZ         = 0x0020,           //NRZ bit error
		MSGACTCSDB_EDGE        = 0x0010,           //Edge bit error
		MSGACTCSDB_PAR         = 0x0008,           //Parity error bit
		MSGACTCSDB_FRAME       = 0x0004,           //Frame error bit
		MSGACTCSDB_HIT         = 0x0001            //Always set
};


/**
*
*  Channel info fields.
*
**/

enum {	INFOCSDB_PARAM         = 0x0001           //Channel supports parametric control
};

#endif
