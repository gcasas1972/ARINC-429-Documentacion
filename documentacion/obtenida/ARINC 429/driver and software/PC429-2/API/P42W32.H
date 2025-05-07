/**
*
*  PC429 WIN32 Driver  Version 1.2  (03/31/1999)
*  Copyright (c) 1997-1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   P42W32.H -- PC429 32-BIT DLL Driver Include File.
*
**/

/**
*
*    This file defines the procedures provided by the 32-bit
*    DLL Driver for the PC429.  Applications using the PC429
*    DLL Driver must incorporate this include file using the
*    preprocessor directive #include.  If this file is in the
*    current working directory, the form would be:
*
*    #include "p42w32.h"
*
*    Refer to your compiler manual for more information on
*    header files.
*
**/

/**
*
*    Include statements only if they have not been included before.
*
**/

#ifndef __P42W32_H
#define __P42W32_H

/**
*
*  Typedefs used by the PC1553-3 Driver.
*
**/

#ifndef P42W32API
#ifdef __BORLANDC__
#define P42W32API
#else
#define P42W32API __declspec(dllimport)
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
typedef int HCARD;
#endif

#ifndef ERRVAL
typedef int ERRVAL;
#endif

#ifndef SCHNDX
typedef int SCHNDX;
#endif

#ifndef SHORT
typedef short int SHORT;
#endif

#ifndef LPSHORT
typedef short int * LPSHORT;
#endif

#ifndef LONG
typedef long int LONG;
#endif

#ifndef LPLONG
typedef long int * LPLONG;
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
*    PC429 32-BIT DLL Driver procedures.
*
**/

P42W32API USHORT __stdcall PC429_Active(USHORT channels,HCARD handleval);
P42W32API USHORT __stdcall PC429_BrdNum(USHORT brdnum,HCARD handleval);
P42W32API VOID __stdcall PC429_BrdStat(USHORT value,HCARD handleval);
P42W32API HCARD __stdcall PC429_Check(INT memval,INT ioval,INT irqval,INT drqval);
P42W32API USHORT __stdcall PC429_CheckChan(HCARD handleval);
P42W32API VOID __stdcall PC429_CLI(HCARD handleval);
P42W32API VOID __stdcall PC429_Close(HCARD handleval);
P42W32API USHORT __stdcall PC429_ClrMsgFilt(HCARD handleval);
P42W32API SHORT __stdcall PC429_Comm(USHORT command,USHORT count,LPUSHORT value,HCARD handleval);
P42W32API SHORT __stdcall PC429_CommPoll(USHORT command,USHORT count,LPUSHORT value,HCARD handleval);
P42W32API ULONG __stdcall PC429_CreateMsg(HCARD handleval);
P42W32API ULONG __stdcall PC429_DecRdData(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall PC429_DecRdErr(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall PC429_DecRdOvf(USHORT channel,HCARD handleval);
P42W32API ULONG __stdcall PC429_DecRdSeq(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall PC429_DecRdSrq(USHORT channel,HCARD handleval);
P42W32API VOID __stdcall PC429_DecWrCtrl(USHORT value,USHORT channel,HCARD handleval);
P42W32API VOID __stdcall PC429_DecWrReset(USHORT value,USHORT channel,HCARD handleval);
P42W32API INT __stdcall PC429_DllUsageCount(VOID);
P42W32API USHORT __stdcall PC429_ElapseClk(USHORT channels,HCARD handleval);
P42W32API USHORT __stdcall PC429_EncRdOvf(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall PC429_EncRdSrq(USHORT channel,HCARD handleval);
P42W32API VOID __stdcall PC429_EncWrCtrl(USHORT value,USHORT channel,HCARD handleval);
P42W32API VOID __stdcall PC429_EncWrData(ULONG value,USHORT channel,HCARD handleval);
P42W32API VOID __stdcall PC429_EncWrGap(USHORT value,USHORT channel,HCARD handleval);
P42W32API VOID __stdcall PC429_EncWrReset(USHORT value,USHORT channel,HCARD handleval);
P42W32API VOID __stdcall PC429_EncWrSeq(ULONG value,USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall PC429_Error(USHORT channels,HCARD handleval);
P42W32API USHORT __stdcall PC429_Extern(USHORT channels,HCARD handleval);
P42W32API VOID __stdcall PC429_FreeDrv(VOID);
P42W32API ULONG __stdcall PC429_FromAscii(LPSTR asciistr,USHORT radixval);
P42W32API VOID __stdcall PC429_Gate(USHORT command,HCARD handleval);
P42W32API ULONG __stdcall PC429_GetBCDData(ULONG msgval,USHORT msb,USHORT lsb);
P42W32API ULONG __stdcall PC429_GetBCDMant(ULONG msgval,USHORT sigdig);
P42W32API USHORT __stdcall PC429_GetBCDSign(ULONG msgval);
P42W32API USHORT __stdcall PC429_GetBCDSSM(ULONG msgval);
P42W32API VOID __stdcall PC429_GetBCDVal(LPSTR resultstr,ULONG msgval,USHORT sigdig,LPSTR resolstr);
P42W32API ULONG __stdcall PC429_GetBNRData(ULONG msgval,USHORT msb,USHORT lsb,USHORT twos);
P42W32API ULONG __stdcall PC429_GetBNRMant(ULONG msgval,USHORT sigbit);
P42W32API USHORT __stdcall PC429_GetBNRSign(ULONG msgval);
P42W32API USHORT __stdcall PC429_GetBNRSSM(ULONG msgval);
P42W32API VOID __stdcall PC429_GetBNRVal(LPSTR resultstr,ULONG msgval,USHORT sigbit,LPSTR resolstr);
P42W32API ULONG __stdcall PC429_GetFilt(USHORT labelval,USHORT sdival,USHORT channel,HCARD handleval);
P42W32API ULONG __stdcall PC429_GetFldData(ULONG msgval);
P42W32API USHORT __stdcall PC429_GetFldLabel(ULONG msgval);
P42W32API USHORT __stdcall PC429_GetFldParity(ULONG msgval);
P42W32API USHORT __stdcall PC429_GetFldSDI(ULONG msgval);
P42W32API ULONG __stdcall PC429_GetFldValue(ULONG msgval,USHORT startbit,USHORT endbit);
P42W32API ULONG __stdcall PC429_GetGap(USHORT indexval,USHORT channel,HCARD handleval);
P42W32API ULONG __stdcall PC429_GetMsg(USHORT indexval,USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall PC429_GetMsgCnt(USHORT channel,HCARD handleval);
P42W32API VOID __stdcall PC429_Halt(HCARD handleval);
P42W32API USHORT __stdcall PC429_HighSpeed(USHORT channels,HCARD handleval);
P42W32API ERRVAL __stdcall PC429_Init(VOID);
P42W32API ULONG __stdcall PC429_InsFilt(USHORT labelval,USHORT sdival,USHORT channel,HCARD handleval);
P42W32API ULONG __stdcall PC429_InsMsg(USHORT indexval,ULONG msgval,ULONG gapval,USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall PC429_IsOldBrd(HCARD handleval);
P42W32API USHORT __stdcall PC429_IsRcv(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall PC429_IsXmit(USHORT channel,HCARD handleval);
P42W32API SHORT __stdcall PC429_Load(LPSTR filename,HCARD handleval);
P42W32API ULONG __stdcall PC429_NameToAddr(LPSTR nameptr,HCARD handleval,LPSTR filename);
P42W32API HCARD __stdcall PC429_Open(INT cardnum);
P42W32API USHORT __stdcall PC429_OscClk(USHORT oscval,HCARD handleval);
P42W32API USHORT __stdcall PC429_Parity(USHORT channels,HCARD handleval);
P42W32API ULONG __stdcall PC429_PeekMsg(ULONG addrval,HCARD handleval);
P42W32API VOID __stdcall PC429_PokeeMsg(ULONG addrval,ULONG msgval,HCARD handleval);
P42W32API VOID __stdcall PC429_PokeMsg(ULONG addrval,ULONG msgval,HCARD handleval);
P42W32API VOID __stdcall PC429_Pulse(HCARD handleval);
P42W32API ULONG __stdcall PC429_PutBCDData(ULONG msgval,ULONG value,USHORT msb,USHORT lsb);
P42W32API ULONG __stdcall PC429_PutBCDMant(ULONG msgval,ULONG value,USHORT sigdig,USHORT sign);
P42W32API ULONG __stdcall PC429_PutBCDSign(ULONG msgval,USHORT sign);
P42W32API ULONG __stdcall PC429_PutBCDSSM(ULONG msgval,USHORT value);
P42W32API ULONG __stdcall PC429_PutBCDVal(LPSTR valuestr,ULONG msgval,USHORT sigdig,LPSTR resolstr);
P42W32API ULONG __stdcall PC429_PutBNRData(ULONG msgval,ULONG value,USHORT msb,USHORT lsb,USHORT twos);
P42W32API ULONG __stdcall PC429_PutBNRMant(ULONG msgval,ULONG value,USHORT sigbit,USHORT twos);
P42W32API ULONG __stdcall PC429_PutBNRSign(ULONG msgval,USHORT sign);
P42W32API ULONG __stdcall PC429_PutBNRSSM(ULONG msgval,USHORT value);
P42W32API ULONG __stdcall PC429_PutBNRVal(LPSTR valuestr,ULONG msgval,USHORT sigbit,LPSTR resolstr);
P42W32API ULONG __stdcall PC429_PutFldData(ULONG msgval,ULONG dataval);
P42W32API ULONG __stdcall PC429_PutFldLabel(ULONG msgval,USHORT labelval);
P42W32API ULONG __stdcall PC429_PutFldSDI(ULONG msgval,USHORT sdival);
P42W32API ULONG __stdcall PC429_PutFldValue(ULONG msgval,ULONG dataval,USHORT startbit,USHORT endbit);
P42W32API ULONG __stdcall PC429_RdClk(HCARD handleval);
P42W32API ULONG __stdcall PC429_RdGap(ULONG addrval,HCARD handleval);
P42W32API ULONG __stdcall PC429_RdMsg(ULONG addrval,HCARD handleval);
P42W32API USHORT __stdcall PC429_RdOpt(HCARD handleval);
P42W32API VOID __stdcall PC429_RdSeq(HCARD handleval,LPUSHORT bottom,LPUSHORT top,LPUSHORT tail,LPUSHORT head);
P42W32API ULONG __stdcall PC429_RdTime(ULONG addrval,HCARD handleval);
P42W32API USHORT __stdcall PC429_ReadLbl(USHORT label,HCARD handleval);
P42W32API USHORT __stdcall PC429_ReadSym(USHORT symbol,HCARD handleval);
P42W32API USHORT __stdcall PC429_Ready(HCARD handleval);
P42W32API VOID __stdcall PC429_Rearm(USHORT channel,HCARD handleval);
P42W32API VOID __stdcall PC429_Reset(HCARD handleval);
P42W32API ERRVAL __stdcall PC429_SchedBuild(INT nummsgs,LPINT minperiod,LPINT maxperiod,BOOL speed,INT channel,HCARD handleval);
P42W32API ERRVAL __stdcall PC429_SchedBuildEx(INT basemsgnum,INT nummsgs,LPINT minperiod,LPINT maxperiod,INT speed,LPVOID buf,ULONG bufsize,INT channel,HCARD handleval);
P42W32API ULONG __stdcall PC429_SchedMsg(USHORT index,ULONG msgaddr,ULONG gapval,USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall PC429_SelfTest(USHORT channels,HCARD handleval);
P42W32API VOID __stdcall PC429_SeqRecParam(INT channels,INT mode,INT interval,HCARD handleval);
P42W32API ULONG __stdcall PC429_SeqRecRd(LPULONG buf,ULONG bufsize,HCARD handleval);
P42W32API VOID __stdcall PC429_SeqRecStart(HCARD handleval);
P42W32API VOID __stdcall PC429_SeqRecStop(HCARD handleval);
P42W32API VOID __stdcall PC429_SeqStat(USHORT value,HCARD handleval);
P42W32API USHORT __stdcall PC429_Single(USHORT channels,HCARD handleval);
P42W32API USHORT __stdcall PC429_SpeedClk(USHORT speed,HCARD handleval);
P42W32API VOID __stdcall PC429_Start(HCARD handleval);
P42W32API VOID __stdcall PC429_STI(HCARD handleval);
P42W32API VOID __stdcall PC429_Stop(HCARD handleval);
P42W32API ERRVAL __stdcall PC429_Test(HCARD handleval);
P42W32API VOID __stdcall PC429_ToAscii(ULONG value,LPSTR asciistr,USHORT numbits,USHORT radixval);
P42W32API VOID __stdcall PC429_Uncheck(HCARD handleval);
P42W32API USHORT __stdcall PC429_UserCode(LPBYTE usercode,USHORT count,HCARD handleval);
P42W32API VOID __stdcall PC429_VerStr(LPSTR strptr,USHORT count);
P42W32API VOID __stdcall PC429_WipeMem(HCARD handleval);
P42W32API VOID __stdcall PC429_WrClk(ULONG clock,HCARD handleval);
P42W32API VOID __stdcall PC429_WrGap(ULONG addrval,ULONG gapval,HCARD handleval);
P42W32API VOID __stdcall PC429_WrMsg(ULONG addrval,ULONG msgval,HCARD handleval);
P42W32API VOID __stdcall PC429_WrOpt(USHORT option,HCARD handleval);
P42W32API VOID __stdcall PC429_WrSeq(HCARD handleval,USHORT bottom,USHORT top,USHORT tail,USHORT head);
P42W32API VOID __stdcall PC429_WrTime(ULONG addrval,ULONG timeval,HCARD handleval);

/**
*
*  Internal functions used by the PC1553-3 Driver.
*
**/

P42W32API USHORT __stdcall DRV429_Active(USHORT value,HCARD handleval);
P42W32API USHORT __stdcall DRV429_AllocCycle(INT numframes,HCARD handleval);
P42W32API USHORT __stdcall DRV429_AllocFilt(HCARD handleval);
P42W32API USHORT __stdcall DRV429_AllocFrame(INT nummsgs,HCARD handleval);
P42W32API USHORT __stdcall DRV429_AllocGap(HCARD handleval);
P42W32API USHORT __stdcall DRV429_AllocHeader(HCARD handleval);
P42W32API USHORT __stdcall DRV429_AllocHeap(INT size,HCARD handleval);
P42W32API USHORT __stdcall DRV429_AllocLabelTable(HCARD handleval);
P42W32API USHORT __stdcall DRV429_AllocMsg(HCARD handleval);
P42W32API USHORT __stdcall DRV429_AllocSDITable(HCARD handleval);
P42W32API USHORT __stdcall DRV429_AsciiToMant(LPSTR str,LPLONG mant,LPSHORT exp);
P42W32API USHORT __stdcall DRV429_BrdNum(USHORT brdnum,HCARD handleval);
P42W32API VOID __stdcall DRV429_BrdStat(USHORT value,HCARD handleval);
P42W32API BOOL __stdcall DRV429_Check(HCARD handleval);
P42W32API USHORT __stdcall DRV429_CheckChan(HCARD handleval);
P42W32API VOID __stdcall DRV429_CLI(HCARD handleval);
P42W32API VOID __stdcall DRV429_Close(HCARD handleval);
P42W32API VOID __stdcall DRV429_ClrCtrInt(HCARD handleval);
P42W32API VOID __stdcall DRV429_ClrDMA(HCARD handleval);
P42W32API VOID __stdcall DRV429_ClrHostInt(HCARD handleval);
P42W32API USHORT __stdcall DRV429_ClrMsgFilt(HCARD handleval);
P42W32API SHORT __stdcall DRV429_Comm(USHORT command,USHORT count,LPUSHORT value,HCARD handleval);
P42W32API SHORT __stdcall DRV429_CommPoll(USHORT command,USHORT count,LPUSHORT value,HCARD handleval);
P42W32API ULONG __stdcall DRV429_CreateMsg(HCARD handleval);
P42W32API ULONG __stdcall DRV429_DecRdData(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall DRV429_DecRdErr(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall DRV429_DecRdOvf(USHORT channel,HCARD handleval);
P42W32API ULONG __stdcall DRV429_DecRdSeq(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall DRV429_DecRdSrq(USHORT channel,HCARD handleval);
P42W32API VOID __stdcall DRV429_DecWrCtrl(USHORT value,USHORT channel,HCARD handleval);
P42W32API VOID __stdcall DRV429_DecWrReset(USHORT value,USHORT channel,HCARD handleval);
P42W32API LPSTR __stdcall DRV429_DfltMsg(USHORT index);
P42W32API ULONG __stdcall DRV429_Div(ULONG diva,ULONG divb);
P42W32API USHORT __stdcall DRV429_ElapseClk(USHORT value,HCARD handleval);
P42W32API USHORT __stdcall DRV429_EncRdOvf(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall DRV429_EncRdSrq(USHORT channel,HCARD handleval);
P42W32API VOID __stdcall DRV429_EncWrCtrl(USHORT value,USHORT channel,HCARD handleval);
P42W32API VOID __stdcall DRV429_EncWrData(ULONG value,USHORT channel,HCARD handleval);
P42W32API VOID __stdcall DRV429_EncWrGap(USHORT value,USHORT channel,HCARD handleval);
P42W32API VOID __stdcall DRV429_EncWrReset(USHORT value,USHORT channel,HCARD handleval);
P42W32API VOID __stdcall DRV429_EncWrSeq(ULONG value,USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall DRV429_Error(USHORT value,HCARD handleval);
P42W32API VOID __stdcall DRV429_ExpandMant(LPLONG mant,LPSHORT exp);
P42W32API INT __stdcall DRV429_ExpCRC(INT version);
P42W32API USHORT __stdcall DRV429_Extern(USHORT value,HCARD handleval);
P42W32API VOID __stdcall DRV429_FileClose(INT handle);
P42W32API BOOL __stdcall DRV429_FileErr(VOID);
P42W32API VOID __stdcall DRV429_FileErrClr(VOID);
P42W32API VOID __stdcall DRV429_FileErrSet(VOID);
P42W32API INT __stdcall DRV429_FileOpenRead(LPCSTR filename);
P42W32API INT __stdcall DRV429_FileOpenWrite(LPCSTR filename);
P42W32API BOOL __stdcall DRV429_FileRead(INT handle,LPVOID buffer,USHORT count);
P42W32API BOOL __stdcall DRV429_FileSeek(INT handle,ULONG offset);
P42W32API ULONG __stdcall DRV429_FileTell(INT handle);
P42W32API BOOL __stdcall DRV429_FileWrite(INT handle,LPVOID buffer,USHORT count);
P42W32API USHORT __stdcall DRV429_Free(HCARD handleval);
P42W32API VOID __stdcall DRV429_FreeDrv(VOID);
P42W32API VOID __stdcall DRV429_FreeHeap(HCARD handleval);
P42W32API VOID __stdcall DRV429_Gate(USHORT command,HCARD handleval);
P42W32API ULONG __stdcall DRV429_GetBCDData(ULONG msg,USHORT msb,USHORT lsb);
P42W32API ULONG __stdcall DRV429_GetBCDMant(ULONG msg,USHORT sigdig);
P42W32API USHORT __stdcall DRV429_GetBCDSign(ULONG msg);
P42W32API USHORT __stdcall DRV429_GetBCDSSM(ULONG msg);
P42W32API VOID __stdcall DRV429_GetBCDVal(LPSTR buf,ULONG msg,USHORT sigdig,LPSTR resolstr);
P42W32API ULONG __stdcall DRV429_GetBNRData(ULONG msg,USHORT msb,USHORT lsb,USHORT twos);
P42W32API ULONG __stdcall DRV429_GetBNRMant(ULONG msg,USHORT sigbit);
P42W32API USHORT __stdcall DRV429_GetBNRSign(ULONG msg);
P42W32API USHORT __stdcall DRV429_GetBNRSSM(ULONG msg);
P42W32API VOID __stdcall DRV429_GetBNRVal(LPSTR buf,ULONG msg,USHORT sigbit,LPSTR resolstr);
P42W32API ULONG __stdcall DRV429_GetFilt(USHORT labelval,USHORT sdival,USHORT channel,HCARD handleval);
P42W32API ULONG __stdcall DRV429_GetFldData(ULONG msgval);
P42W32API USHORT __stdcall DRV429_GetFldLabel(ULONG msgval);
P42W32API INT __stdcall DRV429_GetFldParBit(ULONG msgval);
P42W32API INT __stdcall DRV429_GetFldParity(ULONG msgval);
P42W32API INT __stdcall DRV429_GetFldSDI(ULONG msgval);
P42W32API ULONG __stdcall DRV429_GetFldValue(ULONG msgval,INT startbit,INT endbit);
P42W32API ULONG __stdcall DRV429_GetGap(USHORT index,USHORT channel,HCARD handleval);
P42W32API ULONG __stdcall DRV429_GetMsg(USHORT index,USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall DRV429_GetMsgCnt(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall DRV429_GetVersion(HCARD handleval);
P42W32API VOID __stdcall DRV429_Halt(HCARD handleval);
P42W32API ERRVAL __stdcall DRV429_HandleInit(VOID);
P42W32API BOOL __stdcall DRV429_HandleOkay(HCARD handleval);
P42W32API HCARD __stdcall DRV429_HandleRegister(LPCSTR cardname,INT memval,INT ioval,INT irqval,INT drqval,LPVOID hAppWnd,USHORT uiRemovalMsg);
P42W32API ERRVAL __stdcall DRV429_HandleUnregister(HCARD handleval);
P42W32API USHORT __stdcall DRV429_HighSpeed(USHORT value,HCARD handleval);
P42W32API USHORT __stdcall DRV429_ImageCycle(USHORT channel,HCARD handleval,USHORT addr);
P42W32API USHORT __stdcall DRV429_ImageFilt(USHORT labelval,USHORT sdi,USHORT channel,HCARD handleval,USHORT addr);
P42W32API USHORT __stdcall DRV429_ImageFrame(USHORT framenum,USHORT channel,HCARD handleval,USHORT addr);
P42W32API USHORT __stdcall DRV429_ImageGap(USHORT framenum,USHORT msgnum,USHORT channel,HCARD handleval,USHORT addr);
P42W32API USHORT __stdcall DRV429_ImageHeader(USHORT channel,HCARD handleval,USHORT addr);
P42W32API USHORT __stdcall DRV429_ImageLabelTable(USHORT channel,HCARD handleval,USHORT addr);
P42W32API USHORT __stdcall DRV429_ImageMsg(USHORT framenum,USHORT msgnum,USHORT channel,HCARD handleval,USHORT addr);
P42W32API USHORT __stdcall DRV429_ImageSDITable(USHORT labelval,USHORT channel,HCARD handleval,USHORT addr);
P42W32API INT __stdcall DRV429_In(HCARD handleval,INT addrval);
P42W32API USHORT __stdcall DRV429_InAccess(INT ctrval,HCARD handleval);
P42W32API USHORT __stdcall DRV429_InP(INT addr,HCARD handleval);
P42W32API ULONG __stdcall DRV429_InsFilt(USHORT labelval,USHORT sdival,USHORT channel,HCARD handleval);
P42W32API ULONG __stdcall DRV429_InsMsg(USHORT index,ULONG msgval,ULONG gapval,USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall DRV429_IsOldBrd(HCARD handleval);
P42W32API USHORT __stdcall DRV429_IsRcv(USHORT channel,HCARD handleval);
P42W32API USHORT __stdcall DRV429_IsXmit(USHORT channel,HCARD handleval);
P42W32API ERRVAL __stdcall DRV429_KernBegin(LPVOID *vxdptr,LPCSTR cardname,INT memval,INT ioval,INT irqval,INT drqval);
P42W32API ERRVAL __stdcall DRV429_KernEnd(HCARD handleval);
P42W32API ERRVAL __stdcall DRV429_KernGet(LPULONG memptr,LPULONG ioptr,HCARD handleval);
P42W32API ERRVAL __stdcall DRV429_KernQuick(BOOL flag,HCARD handleval);
P42W32API ERRVAL __stdcall DRV429_KernStatusEx(LPULONG valueptr,ULONG type,ULONG index,HCARD handleval);
P42W32API VOID __stdcall DRV429_KillSeq(HCARD handleval);
P42W32API ERRVAL __stdcall DRV429_Load(LPCSTR filename,HCARD handleval);
P42W32API ULONG __stdcall DRV429_MakePtr(HCARD handleval,INT offval);
P42W32API LPSTR __stdcall DRV429_MantToAscii(LPSTR buf,LONG mant,SHORT exp);
P42W32API VOID __stdcall DRV429_MarkMem(HCARD handleval);
P42W32API ULONG __stdcall DRV429_Mask(ULONG dataval,INT cntval);
P42W32API VOID __stdcall DRV429_MaxMant(LPLONG mant,LPSHORT exp);
P42W32API ULONG __stdcall DRV429_Mod(ULONG moda,ULONG modb);
P42W32API ULONG __stdcall DRV429_Mul(ULONG mula,ULONG mulb);
P42W32API SHORT __stdcall DRV429_NameCmp(LPSTR str1,LPSTR str2);
P42W32API ULONG __stdcall DRV429_NameToAddr(LPSTR name,HCARD handleval,LPSTR filename);
P42W32API VOID __stdcall DRV429_NormalMant(LPLONG mant,LPSHORT exp);
P42W32API HCARD __stdcall DRV429_Open(INT cardnum);
P42W32API USHORT __stdcall DRV429_OscClk(USHORT oscval,HCARD handleval);
P42W32API VOID __stdcall DRV429_Out(HCARD handleval,INT addrval,INT value);
P42W32API VOID __stdcall DRV429_OutAccess(INT ctrval,INT regval,HCARD handleval);
P42W32API VOID __stdcall DRV429_OutP(INT addr,INT value,HCARD handleval);
P42W32API USHORT __stdcall DRV429_Parity(USHORT value,HCARD handleval);
P42W32API INT __stdcall DRV429_PeekB(INT addr,HCARD handleval);
P42W32API ULONG __stdcall DRV429_PeekL(INT addr,HCARD handleval);
P42W32API INT __stdcall DRV429_PeekW(INT addr,HCARD handleval);
P42W32API VOID __stdcall DRV429_PokeB(INT addr,HCARD handleval,INT value);
P42W32API VOID __stdcall DRV429_PokeeB(INT addr,HCARD handleval,INT value);
P42W32API VOID __stdcall DRV429_PokeeL(INT addr,HCARD handleval,ULONG value);
P42W32API VOID __stdcall DRV429_PokeeW(INT addr,HCARD handleval,INT value);
P42W32API VOID __stdcall DRV429_PokeL(INT addr,HCARD handleval,ULONG value);
P42W32API VOID __stdcall DRV429_PokeW(INT addr,HCARD handleval,INT value);
P42W32API VOID __stdcall DRV429_Pulse(HCARD handleval);
P42W32API ULONG __stdcall DRV429_PutBCDData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
P42W32API ULONG __stdcall DRV429_PutBCDMant(ULONG msg,ULONG value,USHORT sigdig,USHORT sign);
P42W32API ULONG __stdcall DRV429_PutBCDSign(ULONG msg,USHORT sign);
P42W32API ULONG __stdcall DRV429_PutBCDSSM(ULONG msg,USHORT value);
P42W32API ULONG __stdcall DRV429_PutBCDVal(LPSTR buf,ULONG msg,USHORT sigdig,LPSTR resolstr);
P42W32API ULONG __stdcall DRV429_PutBNRData(ULONG msg,ULONG value,USHORT msb,USHORT lsb,USHORT twos);
P42W32API ULONG __stdcall DRV429_PutBNRMant(ULONG msg,ULONG value,USHORT sigbit,USHORT twos);
P42W32API ULONG __stdcall DRV429_PutBNRSign(ULONG msg,USHORT sign);
P42W32API ULONG __stdcall DRV429_PutBNRSSM(ULONG msg,USHORT value);
P42W32API ULONG __stdcall DRV429_PutBNRVal(LPSTR buf,ULONG msg,USHORT sigbit,LPSTR resolstr);
P42W32API ULONG __stdcall DRV429_PutFldData(ULONG msgval,ULONG dataval);
P42W32API ULONG __stdcall DRV429_PutFldLabel(ULONG msgval,INT labelval);
P42W32API ULONG __stdcall DRV429_PutFldSDI(ULONG msgval,INT sdival);
P42W32API ULONG __stdcall DRV429_PutFldValue(ULONG msgval,ULONG newval,INT startbit,INT endbit);
P42W32API ULONG __stdcall DRV429_RandL(VOID);
P42W32API ULONG __stdcall DRV429_RdClk(HCARD handleval);
P42W32API USHORT __stdcall DRV429_RdFreePtr(HCARD handleval);
P42W32API USHORT __stdcall DRV429_RdHeapEnd(HCARD handleval);
P42W32API USHORT __stdcall DRV429_RdHeapStart(HCARD handleval);
P42W32API INT __stdcall DRV429_RdOpt(HCARD handleval);
P42W32API VOID __stdcall DRV429_RdSeq(HCARD handleval,LPUSHORT bottom,LPUSHORT top,LPUSHORT tail,LPUSHORT head);
P42W32API BYTE __stdcall DRV429_ReadB(INT addrval,HCARD handleval);
P42W32API VOID __stdcall DRV429_ReadBStr(LPBYTE valueptr,INT countval,INT addrval,HCARD handleval);
P42W32API USHORT __stdcall DRV429_ReadCtrlReg(HCARD handleval);
P42W32API ULONG __stdcall DRV429_ReadL(INT addrval,HCARD handleval);
P42W32API INT __stdcall DRV429_ReadLbl(INT label,HCARD handleval);
P42W32API USHORT __stdcall DRV429_ReadRegA(HCARD handleval);
P42W32API USHORT __stdcall DRV429_ReadRegB(HCARD handleval);
P42W32API BYTE __stdcall DRV429_ReadROMB(INT addrval,HCARD handleval);
P42W32API USHORT __stdcall DRV429_ReadStatusReg(HCARD handleval);
P42W32API INT __stdcall DRV429_ReadSym(INT symbol,HCARD handleval);
P42W32API INT __stdcall DRV429_ReadW(INT addrval,HCARD handleval);
P42W32API USHORT __stdcall DRV429_Ready(HCARD handleval);
P42W32API USHORT __stdcall DRV429_RealChan(USHORT channel);
P42W32API VOID __stdcall DRV429_Rearm(USHORT channel,HCARD handleval);
P42W32API VOID __stdcall DRV429_Reset(HCARD handleval);
P42W32API VOID __stdcall DRV429_Restart(HCARD handleval);
P42W32API ULONG __stdcall DRV429_SchedAdvance(VOID);
P42W32API ULONG __stdcall DRV429_SchedCalc(VOID);
P42W32API ERRVAL __stdcall DRV429_SchedCheck(LPINT minperiod,LPINT maxperiod);
P42W32API VOID __stdcall DRV429_SchedCheckEnd(VOID);
P42W32API VOID __stdcall DRV429_SchedCheckMiddle(ULONG msgnum,ULONG minlen,ULONG midlen,ULONG maxlen);
P42W32API VOID __stdcall DRV429_SchedCheckReal(ULONG msgnum,ULONG minlen,ULONG midlen,ULONG maxlen);
P42W32API VOID __stdcall DRV429_SchedCheckStart(VOID);
P42W32API ULONG __stdcall DRV429_SchedConflicts(VOID);
P42W32API VOID __stdcall DRV429_SchedDisplay(ULONG nummsgs,LPULONG count,LPULONG *data);
P42W32API ERRVAL __stdcall DRV429_SchedDivide(VOID);
P42W32API ULONG __stdcall DRV429_SchedFix(VOID);
P42W32API VOID __stdcall DRV429_SchedFixEnd(VOID);
P42W32API VOID __stdcall DRV429_SchedFixMiddle(ULONG conflicts);
P42W32API VOID __stdcall DRV429_SchedFixStart(VOID);
P42W32API VOID __stdcall DRV429_SchedHook(INT index,LPVOID ptr);
P42W32API ERRVAL __stdcall DRV429_SchedInsert(ULONG events,ULONG index,ULONG msgnum,ULONG gapval,INT channel,HCARD handleval);
P42W32API ERRVAL __stdcall DRV429_SchedInsertEnd(ULONG events,INT channel,HCARD handleval);
P42W32API ERRVAL __stdcall DRV429_SchedInsertStart(ULONG events,INT channel,HCARD handleval);
P42W32API VOID __stdcall DRV429_SchedLayout(VOID);
P42W32API ULONG __stdcall DRV429_SchedMaxval(LPULONG array,ULONG arraycount);
P42W32API ULONG __stdcall DRV429_SchedMinval(LPULONG array,ULONG arraycount);
P42W32API ULONG __stdcall DRV429_SchedMsg(USHORT index,ULONG msgaddr,ULONG gapval,USHORT channel,HCARD handleval);
P42W32API ERRVAL __stdcall DRV429_SchedParse(INT basemsgnum,INT channel,HCARD handleval);
P42W32API VOID __stdcall DRV429_SchedPrint(LPSTR str,...);
P42W32API ERRVAL __stdcall DRV429_SchedReset(VOID);
P42W32API ERRVAL __stdcall DRV429_SchedRotate(VOID);
P42W32API INT __stdcall DRV429_SchedShift(INT msgnum,INT value);
P42W32API ERRVAL __stdcall DRV429_SchedSlide(VOID);
P42W32API VOID __stdcall DRV429_SchedSlideEnd(VOID);
P42W32API VOID __stdcall DRV429_SchedSlideMiddle(ULONG index,ULONG count,ULONG conflicts);
P42W32API VOID __stdcall DRV429_SchedSlideStart(ULONG factor);
P42W32API VOID __stdcall DRV429_SchedSort(VOID);
P42W32API ULONG __stdcall DRV429_SchedToBit(ULONG value);
P42W32API ULONG __stdcall DRV429_SchedToMsec(ULONG value);
P42W32API VOID __stdcall DRV429_SchedUnsort(VOID);
P42W32API ULONG __stdcall DRV429_SchedWalk(VOID);
P42W32API USHORT __stdcall DRV429_SelfTest(USHORT value,HCARD handleval);
P42W32API VOID __stdcall DRV429_SeqDMAStat(USHORT value,HCARD handleval);
P42W32API VOID __stdcall DRV429_SeqRecParam(INT channels,INT mode,INT interval,HCARD handleval);
P42W32API ULONG __stdcall DRV429_SeqRecRd(LPULONG buf,ULONG bufsize,HCARD handleval);
P42W32API VOID __stdcall DRV429_SeqRecStart(HCARD handleval);
P42W32API VOID __stdcall DRV429_SeqRecStop(HCARD handleval);
P42W32API VOID __stdcall DRV429_SeqStat(USHORT value,HCARD handleval);
P42W32API VOID __stdcall DRV429_SetCtrInt(HCARD handleval);
P42W32API VOID __stdcall DRV429_SetHostInt(HCARD handleval);
P42W32API VOID __stdcall DRV429_SetWindow(INT addrval,BOOL ramrom,HCARD handleval);
P42W32API ULONG __stdcall DRV429_Shl(ULONG dataval,INT cntval);
P42W32API ULONG __stdcall DRV429_Shr(ULONG dataval,INT cntval);
P42W32API USHORT __stdcall DRV429_SignMant(LPSTR str);
P42W32API USHORT __stdcall DRV429_Single(USHORT value,HCARD handleval);
P42W32API USHORT __stdcall DRV429_SpeedClk(USHORT speed,HCARD handleval);
P42W32API VOID __stdcall DRV429_Start(HCARD handleval);
P42W32API VOID __stdcall DRV429_STI(HCARD handleval);
P42W32API VOID __stdcall DRV429_Stop(HCARD handleval);
P42W32API ERRVAL __stdcall DRV429_Test(HCARD handleval);
P42W32API USHORT __stdcall DRV429_UserCode(LPBYTE ptr,USHORT count,HCARD handleval);
P42W32API INT __stdcall DRV429_ValAsciiCmpi(LPSTR str1,LPSTR str2);
P42W32API LPSTR __stdcall DRV429_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
P42W32API VOID __stdcall DRV429_ValAsciiTrimLead(LPSTR buf);
P42W32API VOID __stdcall DRV429_ValAsciiTrimTrail(LPSTR buf);
P42W32API ULONG __stdcall DRV429_ValFromAscii(LPCSTR asciistr,INT radixval);
P42W32API LPSTR __stdcall DRV429_ValIncAscii(LPSTR asciistr);
P42W32API LPSTR __stdcall DRV429_ValInccAscii(LPSTR asciistr);
P42W32API BOOL __stdcall DRV429_ValIsLower(INT value);
P42W32API INT __stdcall DRV429_ValLenAscii(INT numbits,INT radixval);
P42W32API LPSTR __stdcall DRV429_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
P42W32API INT __stdcall DRV429_ValToUpper(INT value);
P42W32API LPSTR __stdcall DRV429_Version(VOID);
P42W32API VOID __stdcall DRV429_VerStr(LPSTR strptr,USHORT count);
P42W32API VOID __stdcall DRV429_WipeMem(HCARD handleval);
P42W32API VOID __stdcall DRV429_WrClk(ULONG clock,HCARD handleval);
P42W32API VOID __stdcall DRV429_WrFreePtr(USHORT freeptr,HCARD handleval);
P42W32API VOID __stdcall DRV429_WriteB(INT addrval,HCARD handleval,BYTE value);
P42W32API VOID __stdcall DRV429_WriteCtrlReg(USHORT value,HCARD handleval);
P42W32API VOID __stdcall DRV429_WriteL(INT addrval,HCARD handleval,ULONG value);
P42W32API VOID __stdcall DRV429_WritePulseReg(USHORT value,HCARD handleval);
P42W32API VOID __stdcall DRV429_WriteRegA(USHORT value,HCARD handleval);
P42W32API VOID __stdcall DRV429_WriteRegB(USHORT value,HCARD handleval);
P42W32API VOID __stdcall DRV429_WriteStatusReg(USHORT value,HCARD handleval);
P42W32API VOID __stdcall DRV429_WriteW(INT addrval,HCARD handleval,USHORT value);
P42W32API VOID __stdcall DRV429_WrOpt(INT option,HCARD handleval);
P42W32API VOID __stdcall DRV429_WrSeq(HCARD handleval,USHORT bottom,USHORT top,USHORT tail,USHORT head);

/**
*
*  PC429-1/2 Schedule Build externals.
*
**/

extern P42W32API BOOL  PC429_SchedSpeed;		//Speed of cycle
extern P42W32API ULONG PC429_SchedNumMsgs;		//Number of messages provided by user
extern P42W32API ULONG PC429_SchedLen;			//Resulting cycle length
extern P42W32API ULONG PC429_SchedEvents;		//Resulting number of events
extern P42W32API ULONG PC429_SchedMem;			//Reports size of needed memory buffer
extern P42W32API ULONG PC429_SchedCalcSpan;		//Span value from CycleCalc()
extern P42W32API ULONG PC429_SchedCalcEvent;	//Event value from CycleCalc()
extern P42W32API ULONG PC429_SchedMaxEvent;		//Maximum number of event
extern P42W32API ULONG PC429_SchedEntries;		//Number of entries
extern P42W32API ULONG PC429_SchedHits;			//Number of conflicts before fix
extern P42W32API ULONG PC429_SchedFails;		//Resulting conflicts after fix
extern P42W32API ULONG PC429_SchedTrack;		//Tracks entries while building schedule

extern P42W32API ULONG PC429_SchedMinSpan;		//Sets the largest span thats close enough to zero
extern P42W32API ULONG PC429_SchedMaxLen;		//Sets the maximum cycle length
extern P42W32API ULONG PC429_SchedMaxMult;		//Sets the maximum cycle length multiplier
extern P42W32API ULONG PC429_SchedFactor;		//Sets how much sliding to perform
extern P42W32API BOOL  PC429_SchedNoAlloc;		//Disable allocation of messages
extern P42W32API BOOL  PC429_SchedDebug;		//Enables debugging

extern P42W32API ULONG PC429_SchedBuildAddr[512];

#ifdef __cplusplus
}
#endif

/**
*
*    PC429 32-BIT DLL Driver predefined constants.
*
**/

#define CH0                     0x0001          /*Channel 0*/
#define CH1                     0x0002          /*Channel 1*/
#define CH2                     0x0004          /*Channel 2*/
#define CH3                     0x0008          /*Channel 3*/
#define CH4                     0x0010          /*Channel 4*/
#define CH5                     0x0020          /*Channel 5*/
#define CH6                     0x0040          /*Channel 6*/
#define CH7                     0x0080          /*Channel 7*/
#define CHNONE                  0x0000          /*Channel none*/

#define GAP_NOWRD               0x00008000L     /*Gap NOWRD bit*/
#define GAP_SYNC                0x00004000L     /*Gap SYNC bit*/
#define GAP_LOG                 0x00002000L     /*Gap LOG bit*/
#define GAP_ERWRD               0x00001000L     /*Gap ERWRD bit*/

/**
*
*    The following three constants are for compatibility with
*    earlier versions of the Driver.  They can only be used
*    with software operating the PC429-1.
*
**/

#define SEQREC_CH_XMIT          0x0002      /*Selects transmit channel*/
#define SEQREC_CH_RCV           0x0001      /*Selects receive channel*/
#define SEQREC_CH_XMIT_RCV      0x0003      /*Selects transmit and receive channel*/

#define SEQREC_MODE_NORMAL      0x0000      /*Enables interval mode*/
#define SEQREC_MODE_DELTA       0x0001      /*Enables delta mode*/
#define SEQREC_MODE_INTRVL      0x0002      /*Enables interval mode*/
#define SEQREC_MODE_DELT_INT    0x0003      /*Enables delta and interval mode*/
#define SEQREC_MODE_MON         0x0004      /*Enables monitor mode*/

#define SPEED_CLKHIGH           0x0000      /*Clock resolution .1 msec*/
#define SPEED_CLKMED            0x0001      /*Clock resolution  1 msec*/
#define SPEED_CLKLOW            0x0002      /*Clock resolution 10 msec*/

#define SDI00                   0x0001      /*SDI filter 00*/
#define SDI01                   0x0002      /*SDI filter 01*/
#define SDI10                   0x0004      /*SDI filter 10*/
#define SDI11                   0x0008      /*SDI filter 11*/
#define SDIALL                  0x000F      /*SDI filter all*/

#define ERR_NONE           0                //No error
#define ERR_UNKNOWN       -1                //An unexpected error occurred
#define ERR_NOCARD       -12                //Unable to find a PC429-1/2 card
#define ERR_BADMSGNUM    -26                //Specified message number is out of range
#define ERR_SCHFULL      -28                //Specified schedule is full
#define ERR_FACTOR       -41                //A bad factor value was specified
#define ERR_ZEROLEN      -42                //Zero length was specified
#define ERR_BUFSIZE      -43                //Insufficient space in user buffer
#define ERR_NOMSGS       -44                //No messages specified
#define ERR_CONFLICTS    -45                //Unable to resolve conflicts
#define ERR_RANGE        -46                //Schedule is out of range
#define ERR_SELFIOFAIL   -71                //I/O selftest failed
#define ERR_SELFMEMFAIL  -72                //Memory selftest failed
#define ERR_SELFCOMMFAIL -73                //Communication selftest failed
#define ERR_SELFXMTFAIL  -74                //Transmit selftest failed

#endif
