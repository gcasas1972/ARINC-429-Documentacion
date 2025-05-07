/**
*
*  CM429-1 WIN32 DRIVER  Version 1.8  (11/30/2006)
*  Copyright (c) 1997-2006
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   C41W32.H -- Visual C++ 32-bit
*                      CM429-1 Driver Include Header File.
*
**/

/**
*
*    This file defines the procedures provided by the
*    Microsoft C and Borland Turbo C Driver Library for the
*    CM429-1.  Applications using the CM429-1 Driver
*    Library must incorporate this include file using the
*    preprocessor directive #include.  If this file is in the
*    current working directory, the form would be:
*
*    #include "C41W32.H"
*
*    Note:  This include file must be incorporated into the
*    application program for it to work under all memory
*    models, to work if the Pascal/FORTRAN calling convention
*    is generated with the /Gc option, or to work in the
*    Microsoft QuickC environment.
*
*    Refer to the Microsoft C or Borland Turbo C manual for
*    more information on header files.
*
**/

/**
*
*  Conditional block to prevent multiple defines.
*
**/

#ifndef __C41W32_H
#define __C41W32_H

/**
*
*  Typedefs used by the CM429-1 Driver.
*
**/

#ifndef C41W32API
#ifdef __BORLANDC__
#define C41W32API
#else
#define C41W32API __declspec(dllimport)
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

#ifndef LONG
typedef long LONG;
#endif

#ifndef LPLONG
typedef long * LPLONG;
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
*  CM429-1 Driver functions.
*
**/

C41W32API ULONG __stdcall C41_AsciiFrom(LPCSTR asciistr,INT radixval);
C41W32API VOID __stdcall C41_AsciiTo(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
C41W32API ULONG __stdcall C41_BCDGetData(ULONG msg,USHORT msb,USHORT lsb);
C41W32API ULONG __stdcall C41_BCDGetMant(ULONG msg,USHORT sigdig);
C41W32API USHORT __stdcall C41_BCDGetSign(ULONG msg);
C41W32API USHORT __stdcall C41_BCDGetSSM(ULONG msg);
C41W32API VOID __stdcall C41_BCDGetVal(LPSTR buf,ULONG msg,USHORT sigdig,LPCSTR resolstr);
C41W32API ULONG __stdcall C41_BCDPutData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
C41W32API ULONG __stdcall C41_BCDPutMant(ULONG msg,ULONG value,USHORT sigdig,USHORT sign);
C41W32API ULONG __stdcall C41_BCDPutSign(ULONG msg,USHORT sign);
C41W32API ULONG __stdcall C41_BCDPutSSM(ULONG msg,USHORT value);
C41W32API ULONG __stdcall C41_BCDPutVal(LPCSTR buf,ULONG msg,USHORT sigdig,LPCSTR resolstr);
C41W32API ULONG __stdcall C41_BNRGetData(ULONG msg,USHORT msb,USHORT lsb);
C41W32API ULONG __stdcall C41_BNRGetMant(ULONG msg,USHORT sigbit);
C41W32API USHORT __stdcall C41_BNRGetSign(ULONG msg);
C41W32API USHORT __stdcall C41_BNRGetSSM(ULONG msg);
C41W32API VOID __stdcall C41_BNRGetVal(LPSTR buf,ULONG msg,USHORT sigbit,LPCSTR resolstr);
C41W32API ULONG __stdcall C41_BNRPutData(ULONG msg,ULONG value,USHORT msb,USHORT lsb);
C41W32API ULONG __stdcall C41_BNRPutMant(ULONG msg,ULONG value,USHORT sigbit,USHORT twos);
C41W32API ULONG __stdcall C41_BNRPutSign(ULONG msg,USHORT twos);
C41W32API ULONG __stdcall C41_BNRPutSSM(ULONG msg,USHORT value);
C41W32API ULONG __stdcall C41_BNRPutVal(LPCSTR buf,ULONG msg,USHORT sigbit,LPCSTR resolstr);
C41W32API INT __stdcall C41_ChCheck(INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ChClear(INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ChConfig(ULONG configval,INT channum,HCARD handleval);
C41W32API VOID __stdcall C41_ChPause(INT channum,HCARD handleval);
C41W32API VOID __stdcall C41_ChResume(INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_CloseAll(VOID);
C41W32API ERRVAL __stdcall C41_CloseCard(HCARD handleval);
C41W32API INT __stdcall C41_ExtRd(HCARD handleval);
C41W32API VOID __stdcall C41_ExtWr(INT extflag,HCARD handleval);
C41W32API ERRVAL __stdcall C41_FilterDefault(INT msgnum,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_FilterSet(INT labelval,INT sdimask,INT msgnum,INT channum,HCARD handleval);
C41W32API ULONG __stdcall C41_FldGetData(ULONG msgval);
C41W32API USHORT __stdcall C41_FldGetLabel(ULONG msgval);
C41W32API USHORT __stdcall C41_FldGetParity(ULONG msgval);
C41W32API USHORT __stdcall C41_FldGetSDI(ULONG msgval);
C41W32API ULONG __stdcall C41_FldGetValue(ULONG msgval,USHORT startbit,USHORT endbit);
C41W32API ULONG __stdcall C41_FldPutData(ULONG msgval,ULONG data);
C41W32API ULONG __stdcall C41_FldPutLabel(ULONG msgval,USHORT label);
C41W32API ULONG __stdcall C41_FldPutSDI(ULONG msgval,USHORT sdi);
C41W32API ULONG __stdcall C41_FldPutValue(ULONG msgval,ULONG dataval,USHORT startbit,USHORT endbit);
C41W32API ERRVAL __stdcall C41_IntDin(HCARD handleval);
C41W32API USHORT __stdcall C41_IntRd(LPUSHORT typeval,LPUSHORT infoval,HCARD handleval);
C41W32API USHORT __stdcall C41_ListMakeRcv(USHORT count,INT msgnum,HCARD handleval);
C41W32API USHORT __stdcall C41_ListMakeXmt(USHORT count,INT channum,HCARD handleval);
C41W32API USHORT __stdcall C41_ListRd(LPULONG msgval,USHORT listaddr,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ListStatus(USHORT listaddr,HCARD handleval);
C41W32API USHORT __stdcall C41_ListWr(ULONG msgval,USHORT listaddr,HCARD handleval);
C41W32API USHORT __stdcall C41_MemPeek(USHORT addrval,HCARD handleval);
C41W32API VOID __stdcall C41_MemPoke(USHORT value,USHORT addrval,HCARD handleval);
C41W32API ULONG __stdcall C41_MsgArincRd(INT msgnum,HCARD handleval);
C41W32API VOID __stdcall C41_MsgArincWr(ULONG msgval,INT msgnum,HCARD handleval);
C41W32API USHORT __stdcall C41_MsgBlockRd(LPUSHORT valueptr,INT msgnum,HCARD handleval);
C41W32API USHORT __stdcall C41_MsgBlockWr(LPUSHORT valueptr,INT msgnum,HCARD handleval);
C41W32API USHORT __stdcall C41_MsgCommRd(LPUSHORT valueptr,INT msgnum,HCARD handleval);
C41W32API USHORT __stdcall C41_MsgCommWr(LPUSHORT valueptr,INT msgnum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_MsgConfig(USHORT configval,INT msgnum,HCARD handleval);
C41W32API ULONG __stdcall C41_MsgEncoderRd(INT msgnum,HCARD handleval);
C41W32API VOID __stdcall C41_MsgEncoderWr(ULONG msgval,INT msgnum,HCARD handleval);
C41W32API HCARD __stdcall C41_OpenCard(INT cardnum);
C41W32API ERRVAL __stdcall C41_ProcCall(USHORT useraddr,HCARD handleval);
C41W32API USHORT __stdcall C41_ProcLoad(LPVOID userbuf,USHORT count,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ProcSetCh(USHORT useraddr,INT type,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ProcSetMsg(USHORT useraddr,INT msgnum,HCARD handleval);
C41W32API VOID __stdcall C41_Reset(HCARD handleval);
C41W32API VOID __stdcall C41_Restart(HCARD handleval);
C41W32API INT __stdcall C41_SchedBranch(INT schindex,INT condition,INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedBuild(INT basemsgnum,USHORT nummsgs,LPINT minperiod,LPINT maxperiod,INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedCall(INT schindex,INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedGap(USHORT gapval,INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedHalt(INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedInt(USHORT tagval,INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedMsg(INT msgnum,INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedPause(INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedPulse(INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedRestart(INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedRet(INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedStart(INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_SelfTest(HCARD handleval);
C41W32API ERRVAL __stdcall C41_SeqClear(HCARD handleval);
C41W32API ERRVAL __stdcall C41_SeqConfig(USHORT configval,INT interval,INT cardnum,HCARD handleval);
C41W32API USHORT __stdcall C41_SeqRd(LPULONG msgval,LPULONG stampval,HCARD handleval);
C41W32API USHORT __stdcall C41_Start(HCARD handleval);
C41W32API USHORT __stdcall C41_Stop(HCARD handleval);
C41W32API VOID __stdcall C41_TimerClear(HCARD handleval);
C41W32API ULONG __stdcall C41_TimerRd(HCARD handleval);
C41W32API USHORT __stdcall C41_TimerResolution(INT timerresol,HCARD handleval);

/**
*
*  CM429-1 717 Driver functions.
*
**/

C41W32API ERRVAL __stdcall C41_717Boot(INT handleval);
C41W32API ERRVAL __stdcall C41_717FrameWipe(INT channum,INT handleval);
C41W32API ERRVAL __stdcall C41_717SubFrmClear(INT channum,INT handleval);
C41W32API ERRVAL __stdcall C41_717SubFrmDataWipe(INT subframe,INT channum,INT handleval);
C41W32API LONG __stdcall C41_717SubFrmPtrDefault(INT channum,INT handleval);
C41W32API LONG __stdcall C41_717SubFrmPtrSet(INT subfrmnum,INT destsubfrm,INT channum,INT handleval);
C41W32API ERRVAL __stdcall C41_717SubFrmRecordWipe(INT subframe,INT channum,INT handleval);
C41W32API ERRVAL __stdcall C41_717SubFrmWordConfig(LONG configval,INT subframe,INT wordnum,INT channum,INT handleval);
C41W32API ERRVAL __stdcall C41_717SubFrmWordConfigEx(LONG configval,INT subframe,INT channum,INT handleval);
C41W32API INT __stdcall C41_717SubFrmWordRd(INT subframe,INT wordnum,INT channum,INT handleval);
C41W32API BOOL __stdcall C41_717SyncTest(INT channum,INT handleval);
C41W32API ERRVAL __stdcall C41_717SyncWordDefault(INT channum,INT handleval);
C41W32API ERRVAL __stdcall C41_717SyncWordSet(INT sync1,INT sync2,INT sync3,INT sync4,INT channum,INT handleval);
C41W32API VOID __stdcall C41_Ch717Disable(INT handleval);
C41W32API VOID __stdcall C41_Ch717Enable(INT handleval);

/**
*
*  Internal functions used by the CM429-1 Driver.
*
**/

C41W32API USHORT __stdcall C41_AcgaRd(USHORT addrval,HCARD handleval);
C41W32API VOID __stdcall C41_AcgaWr(USHORT value,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_AsciiToMant(LPCSTR str,LPLONG mant,LPINT exp);
C41W32API ERRVAL __stdcall C41_Boot(HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootAdd(LPCSTR filename,LPCSTR name,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootAddProc(USHORT value,USHORT addr,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootAddr(USHORT index,LPUSHORT addr,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootAddrNext(LPUSHORT addr,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootClose(HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootCount(LPUSHORT count,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootCrc(USHORT index,LPULONG crc,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootDelete(USHORT index,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootEx(HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootFlush(HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootGet(USHORT index,LPCSTR filename,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootInfo(USHORT index,LPUSHORT base,LPUSHORT length,LPSTR name,USHORT namelen,LPULONG crc,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootOpen(HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootPtrGet(LPUSHORT index,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootPtrPut(USHORT index,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootRdsW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootStr(USHORT index,LPSTR keystr,LPSTR buf,USHORT bufcount,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootWipe(HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootWrsW(LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_BootWrW(USHORT value,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_CardClose(HCARD handleval);
C41W32API VOID __stdcall C41_CardInit(VOID);
C41W32API HCARD __stdcall C41_CardOpen(INT cardnum);
C41W32API HCARD __stdcall C41_CardOpenEx(LPCSTR cardname,INT rcvcount,INT xmtcount,INT cardnum);
C41W32API HCARD __stdcall C41_CardOpenExx(LPCSTR cardname,INT rcvcount,INT xmtcount,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
C41W32API INT __stdcall C41_ChPauseCheck(INT channum,HCARD handleval);
C41W32API USHORT __stdcall C41_ChStart(INT channum,HCARD handleval);
C41W32API USHORT __stdcall C41_ChStop(INT channum,HCARD handleval);
C41W32API VOID __stdcall C41_CommCall(USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_CommCheck(HCARD handleval);
C41W32API ERRVAL __stdcall C41_CommDisable(HCARD handleval);
C41W32API ERRVAL __stdcall C41_CommEnable(HCARD handleval);
C41W32API USHORT __stdcall C41_CommRd(USHORT addrval,HCARD handleval);
C41W32API VOID __stdcall C41_CommRun(LPUSHORT dataptr,USHORT datacount,LPUSHORT codeptr,USHORT codecount,HCARD handleval);
C41W32API VOID __stdcall C41_CommStrRd(LPUSHORT valueptr,USHORT addrval,USHORT count,HCARD handleval);
C41W32API VOID __stdcall C41_CommStrWr(LPUSHORT valueptr,USHORT addrval,USHORT count,HCARD handleval);
C41W32API VOID __stdcall C41_CommTxen(USHORT addrval,HCARD handleval);
C41W32API VOID __stdcall C41_CommWr(USHORT value,USHORT addrval,HCARD handleval);
C41W32API ULONG __stdcall C41_ConvFromArinc(ULONG msgval);
C41W32API ULONG __stdcall C41_ConvToArinc(ULONG msgval);
C41W32API ULONG __stdcall C41_CycleAdvance(VOID);
C41W32API ERRVAL __stdcall C41_CycleBuild(INT basemsgnum,ULONG nummsgs,LPINT minperiod,LPINT maxperiod,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_CycleBuildEx(INT basemsgnum,INT nummsgs,LPINT minperiod,LPINT maxperiod,INT speed,LPVOID buf,ULONG bufsize,INT channum,HCARD handleval);
C41W32API INT __stdcall C41_CycleBuildSt(INT basemsgnum,INT nummsgs,LPINT minperiod,LPINT maxperiod,INT channum,HCARD handleval);
C41W32API ULONG __stdcall C41_CycleCalc(VOID);
C41W32API ERRVAL __stdcall C41_CycleCheck(LPINT minperiod,LPINT maxperiod);
C41W32API VOID __stdcall C41_CycleCheckEnd(VOID);
C41W32API VOID __stdcall C41_CycleCheckMiddle(INT msgnum,ULONG minlen,ULONG midlen,ULONG maxlen);
C41W32API VOID __stdcall C41_CycleCheckReal(INT msgnum,ULONG minlen,ULONG midlen,ULONG maxlen);
C41W32API VOID __stdcall C41_CycleCheckStart(VOID);
C41W32API ULONG __stdcall C41_CycleConflicts(VOID);
C41W32API VOID __stdcall C41_CycleDisplay(INT nummsgs,LPULONG count,LPULONG *data);
C41W32API ERRVAL __stdcall C41_CycleDivide(VOID);
C41W32API ULONG __stdcall C41_CycleFix(VOID);
C41W32API VOID __stdcall C41_CycleFixEnd(VOID);
C41W32API VOID __stdcall C41_CycleFixMiddle(ULONG conflicts);
C41W32API VOID __stdcall C41_CycleFixStart(VOID);
C41W32API VOID __stdcall C41_CycleHook(INT index,LPVOID ptr);
C41W32API ERRVAL __stdcall C41_CycleInsert(ULONG events,ULONG index,INT msgnum,ULONG gapval,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_CycleInsertEnd(ULONG events,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_CycleInsertStart(ULONG events,INT channum,HCARD handleval);
C41W32API VOID __stdcall C41_CycleLayout(VOID);
C41W32API ULONG __stdcall C41_CycleMaxval(LPULONG array,ULONG arraycount);
C41W32API ULONG __stdcall C41_CycleMinval(LPULONG array,ULONG arraycount);
C41W32API ERRVAL __stdcall C41_CycleParse(INT basemsgnum,INT channum,HCARD handleval);
C41W32API VOID __stdcall C41_CyclePrint(LPSTR str,...);
C41W32API ERRVAL __stdcall C41_CycleReset(VOID);
C41W32API ULONG __stdcall C41_CycleRotate(VOID);
C41W32API INT __stdcall C41_CycleShift(INT msgnum,INT value);
C41W32API ERRVAL __stdcall C41_CycleSlide(VOID);
C41W32API VOID __stdcall C41_CycleSlideEnd(VOID);
C41W32API VOID __stdcall C41_CycleSlideMiddle(ULONG index,ULONG count,ULONG conflicts);
C41W32API VOID __stdcall C41_CycleSlideStart(ULONG factor);
C41W32API VOID __stdcall C41_CycleSort(VOID);
C41W32API ULONG __stdcall C41_CycleToBit(ULONG value);
C41W32API ULONG __stdcall C41_CycleToMsec(ULONG value);
C41W32API VOID __stdcall C41_CycleUnsort(VOID);
C41W32API ULONG __stdcall C41_CycleWalk(VOID);
C41W32API VOID __stdcall C41_DataClear(USHORT maskval,USHORT addrval,INT channum,HCARD handleval);
C41W32API USHORT __stdcall C41_DataGet(USHORT maskval,USHORT addrval,INT channum,HCARD handleval);
C41W32API USHORT __stdcall C41_DataRead(USHORT addrval,INT channum,HCARD handleval);
C41W32API VOID __stdcall C41_DataSet(USHORT maskval,USHORT addrval,INT channum,HCARD handleval);
C41W32API VOID __stdcall C41_DataWrite(USHORT value,USHORT addrval,INT channum,HCARD handleval);
C41W32API ULONG __stdcall C41_Div(ULONG diva,ULONG divb);
C41W32API USHORT __stdcall C41_DPMIAllocSel(USHORT segval);
C41W32API ULONG __stdcall C41_DPMIDosAlloc(USHORT paras);
C41W32API USHORT __stdcall C41_DPMIDosFree(USHORT selector);
C41W32API VOID __stdcall C41_DPMIFreeSel(USHORT selector);
C41W32API USHORT __stdcall C41_DPMIIntSim(USHORT intnum,LPVOID dpmireg);
C41W32API USHORT __stdcall C41_DPMIPresent(VOID);
C41W32API INT __stdcall C41_DspIntmClear(HCARD handleval);
C41W32API INT __stdcall C41_DspIntmSet(HCARD handleval);
C41W32API INT __stdcall C41_DspXfClear(HCARD handleval);
C41W32API INT __stdcall C41_DspXfSet(HCARD handleval);
C41W32API LPCSTR __stdcall C41_ErrDesc(INT errval);
C41W32API LPCSTR __stdcall C41_ErrDescStr(INT errval);
C41W32API LPCSTR __stdcall C41_ErrName(INT errval);
C41W32API VOID __stdcall C41_ExpandMant(LPLONG mant,LPINT exp);
C41W32API INT __stdcall C41_ExtDinWr(INT dinvalue,INT channum,HCARD handleval);
C41W32API VOID __stdcall C41_FileClose(INT handle);
C41W32API BOOL __stdcall C41_FileErr(VOID);
C41W32API VOID __stdcall C41_FileErrClr(VOID);
C41W32API VOID __stdcall C41_FileErrSet(VOID);
C41W32API BOOL __stdcall C41_FileOpenRead(LPCSTR filename);
C41W32API BOOL __stdcall C41_FileOpenWrite(LPCSTR filename);
C41W32API BOOL __stdcall C41_FileRead(INT handle,LPVOID buffer,USHORT count);
C41W32API BOOL __stdcall C41_FileSeek(INT handle,ULONG offset);
C41W32API ULONG __stdcall C41_FileTell(INT handle);
C41W32API BOOL __stdcall C41_FileWrite(INT handle,LPVOID buffer,USHORT count);
C41W32API USHORT __stdcall C41_FilterAddr(INT labelval,INT sdival,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_FilterClear(INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_FilterFill(LPUSHORT msgaddr,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_FilterRd(LPUSHORT msgaddr,INT labelval,INT sdival,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_FilterWipe(INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_FilterWr(LPUSHORT msgaddr,INT labelval,INT sdival,INT channum,HCARD handleval);
C41W32API USHORT __stdcall C41_FldGetParBit(ULONG msgval);
C41W32API USHORT __stdcall C41_GetHigh(ULONG val);
C41W32API USHORT __stdcall C41_GetLow(ULONG val);
C41W32API USHORT __stdcall C41_GlobalRd(USHORT addrval,HCARD handleval);
C41W32API VOID __stdcall C41_GlobalWr(USHORT value,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_HandleAssign(USHORT sizval,USHORT memval,USHORT ioval,USHORT irqval,INT cardnum);
C41W32API ERRVAL __stdcall C41_HandleClose(HCARD handleval);
C41W32API ERRVAL __stdcall C41_HandleDel(HCARD handleval);
C41W32API ERRVAL __stdcall C41_HandleGet(LPUSHORT sizval,LPUSHORT memval,LPUSHORT ioval,LPUSHORT irqval,HCARD handleval);
C41W32API HCARD __stdcall C41_HandleIns(LPCSTR cardname,INT rcvcount,INT xmtcount,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
C41W32API USHORT __stdcall C41_HandleOkay(HCARD handleval);
C41W32API ERRVAL __stdcall C41_HandleOpen(LPCSTR cardname,INT rcvcount,INT xmtcount,INT cardnum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_HandleVer(HCARD handleval);
C41W32API USHORT __stdcall C41_HeapAlloc(USHORT wordcount,HCARD handleval);
C41W32API ERRVAL __stdcall C41_HeapCheck(HCARD handleval);
C41W32API ERRVAL __stdcall C41_HeapClear(HCARD handleval);
C41W32API ERRVAL __stdcall C41_HeapWipe(HCARD handleval);
C41W32API ERRVAL __stdcall C41_HexRd(LPCSTR fname,INT (__stdcall * proc)(USHORT value,USHORT addr,HCARD handleval),HCARD handleval);
C41W32API ERRVAL __stdcall C41_HexRun(LPCSTR fname,HCARD handleval);
C41W32API ERRVAL __stdcall C41_HexRunProc(USHORT value,USHORT addr,HCARD handleval);
C41W32API ERRVAL __stdcall C41_HexStat(LPUSHORT lowaddr,LPUSHORT highaddr,LPUSHORT count,LPCSTR fname);
C41W32API ERRVAL __stdcall C41_HexStatProc(USHORT value,USHORT addr,HCARD handleval);
C41W32API ERRVAL __stdcall C41_HexWrAddr(USHORT addr);
C41W32API ERRVAL __stdcall C41_HexWrByte(BYTE ch);
C41W32API ERRVAL __stdcall C41_HexWrClose(VOID);
C41W32API ERRVAL __stdcall C41_HexWrFlush(VOID);
C41W32API ERRVAL __stdcall C41_HexWrFlushByte(USHORT value);
C41W32API ERRVAL __stdcall C41_HexWrOpen(LPCSTR fname);
C41W32API ERRVAL __stdcall C41_InitFilt(USHORT chanflag,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_InitHeap(USHORT heapsize,HCARD handleval);
C41W32API ERRVAL __stdcall C41_InitInt(USHORT intsize,HCARD handleval);
C41W32API ERRVAL __stdcall C41_InitMsg(USHORT msgcount,HCARD handleval);
C41W32API ERRVAL __stdcall C41_InitSch(USHORT chancount,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_InitSeq(USHORT seqsize,HCARD handleval);
C41W32API ERRVAL __stdcall C41_IntClear(HCARD handleval);
C41W32API ERRVAL __stdcall C41_INTDisable(HCARD handleval);
C41W32API ERRVAL __stdcall C41_INTEnable(HCARD handleval);
C41W32API ERRVAL __stdcall C41_INTEnableCond(HCARD handleval);
C41W32API ERRVAL __stdcall C41_IntInstall(LPVOID hEvent,HCARD handleval);
C41W32API ERRVAL __stdcall C41_IntUninstall(HCARD handleval);
C41W32API ERRVAL __stdcall C41_IntWipe(HCARD handleval);
C41W32API ERRVAL __stdcall C41_Invoke(HCARD handleval);
C41W32API ERRVAL __stdcall C41_Invokee(HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernBegin(LPVOID *vxdptr,LPCSTR cardname,ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval);
C41W32API ERRVAL __stdcall C41_KernEEPRdsW(LPUSHORT bufptr,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernEEPRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernEEPWrsW(LPUSHORT bufptr,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernEEPWrW(USHORT value,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernEnd(LPVOID vxdptr);
C41W32API ERRVAL __stdcall C41_KernIntInstall(LPVOID hEvent,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernIntParam(ULONG clraddr,ULONG clrwidth,ULONG clrvalue,ULONG stataddr,ULONG statwidth,ULONG statvalue,ULONG statmask,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernIntUninstall(HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernIORdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernIOWrW(USHORT value,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernMEMFillW(USHORT value,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernMEMRdsW(LPUSHORT bufptr,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernMEMRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernMEMWrsW(LPUSHORT bufptr,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernMEMWrW(USHORT value,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernQuick(BOOL flag,HCARD handleval);
C41W32API ERRVAL __stdcall C41_KernStatusEx(LPULONG valueptr,ULONG type,ULONG index,HCARD handleval);
C41W32API USHORT __stdcall C41_ListSetRcv(USHORT listaddr,INT msgnum,HCARD handleval);
C41W32API USHORT __stdcall C41_ListSetXmt(USHORT listaddr,INT channum,HCARD handleval);
C41W32API ULONG __stdcall C41_MakeLong(USHORT valh,USHORT vall);
C41W32API LPSTR __stdcall C41_MantToAscii(LPSTR buf,LONG mant,INT exp);
C41W32API ULONG __stdcall C41_Mask(ULONG dataval,USHORT cntval);
C41W32API VOID __stdcall C41_MaxMant(LPLONG mant,LPINT exp);
C41W32API VOID __stdcall C41_MemFill(USHORT value,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API VOID __stdcall C41_MemStrRd(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API VOID __stdcall C41_MemStrWr(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API USHORT __stdcall C41_MEMWINRdB(ULONG addrval,HCARD handleval);
C41W32API ULONG __stdcall C41_MEMWINRdL(ULONG addrval,HCARD handleval);
C41W32API USHORT __stdcall C41_MEMWINRdW(ULONG addrval,HCARD handleval);
C41W32API VOID __stdcall C41_MEMWINWrB(USHORT value,ULONG addrval,HCARD handleval);
C41W32API VOID __stdcall C41_MEMWINWrL(ULONG value,ULONG addrval,HCARD handleval);
C41W32API VOID __stdcall C41_MEMWINWrW(USHORT value,ULONG addrval,HCARD handleval);
C41W32API VOID __stdcall C41_MemWipe(HCARD handleval);
C41W32API ULONG __stdcall C41_Mod(ULONG moda,ULONG modb);
C41W32API USHORT __stdcall C41_MsgAddr(INT msgnum,HCARD handleval);
C41W32API ULONG __stdcall C41_MsgArincPeek(INT msgnum,HCARD handleval);
C41W32API VOID __stdcall C41_MsgArincPoke(ULONG msgval,INT msgnum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_MsgClear(HCARD handleval);
C41W32API ERRVAL __stdcall C41_MsgDisable(INT msgnum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_MsgEnable(INT msgnum,HCARD handleval);
C41W32API ULONG __stdcall C41_MsgEncoderPeek(INT msgnum,HCARD handleval);
C41W32API VOID __stdcall C41_MsgEncoderPoke(ULONG msgval,INT msgnum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_MsgReset(HCARD handleval);
C41W32API ERRVAL __stdcall C41_MsgWipe(HCARD handleval);
C41W32API ULONG __stdcall C41_Mul(ULONG mula,ULONG mulb);
C41W32API VOID __stdcall C41_NormalMant(LPLONG mant,LPINT exp);
C41W32API USHORT __stdcall C41_PortRd(USHORT addrval,HCARD handleval);
C41W32API VOID __stdcall C41_PortWr(USHORT value,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ProcBoot(LPUSHORT usercode,ULONG count,HCARD handleval);
C41W32API INT __stdcall C41_ProcSetFore(USHORT useraddr,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ProcSetInt(USHORT useraddr,INT intnum,HCARD handleval);
C41W32API INT __stdcall C41_ProcSetPost(USHORT useraddr,INT channum,HCARD handleval);
C41W32API INT __stdcall C41_ProcSetPre(USHORT useraddr,INT channum,HCARD handleval);
C41W32API USHORT __stdcall C41_ProgRd(USHORT addrval,HCARD handleval);
C41W32API VOID __stdcall C41_ProgWr(USHORT value,USHORT addrval,HCARD handleval);
C41W32API USHORT __stdcall C41_RAMRdB(ULONG addrval,HCARD handleval);
C41W32API ULONG __stdcall C41_RAMRdL(ULONG addrval,HCARD handleval);
C41W32API USHORT __stdcall C41_RAMRdW(ULONG addrval,HCARD handleval);
C41W32API VOID __stdcall C41_RAMWrB(USHORT value,ULONG addrval,HCARD handleval);
C41W32API VOID __stdcall C41_RAMWrL(ULONG value,ULONG addrval,HCARD handleval);
C41W32API VOID __stdcall C41_RAMWrW(USHORT value,ULONG addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMChksW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMClose(HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMDisable(HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMEnable(HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMFlush(HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMInfoRd(LPBYTE buf,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMInfoWr(LPBYTE buf,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMOpen(HCARD handleval);
C41W32API VOID __stdcall C41_ROMProg(USHORT enableflag,LPUSHORT dataptr,USHORT cntval,ULONG addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMRdsW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMWrsW(USHORT enableflag,LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
C41W32API ERRVAL __stdcall C41_ROMWrW(USHORT value,USHORT addrval,HCARD handleval);
C41W32API USHORT __stdcall C41_SchedAddr(INT schindex,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_SchedClear(INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedFixedGap(USHORT gapval,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_SchedInsert(USHORT schflag,USHORT schopcode,USHORT schoperand,INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedNop(INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_SchedRd(LPUSHORT valueptr,INT schindex,INT channum,HCARD handleval);
C41W32API INT __stdcall C41_SchedUser(USHORT useraddr,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_SchedWipe(INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_SchedWr(LPUSHORT valueptr,INT schindex,INT channum,HCARD handleval);
C41W32API ERRVAL __stdcall C41_SeqInterval(INT interval,HCARD handleval);
C41W32API BOOL __stdcall C41_SeqIsRunning(HCARD handleval);
C41W32API ULONG __stdcall C41_SeqRdEx(LPUSHORT buf,ULONG bufcount,HCARD handleval);
C41W32API USHORT __stdcall C41_SeqStart(HCARD handleval);
C41W32API USHORT __stdcall C41_SeqStop(HCARD handleval);
C41W32API ERRVAL __stdcall C41_SeqWipe(HCARD handleval);
C41W32API ULONG __stdcall C41_Shl(ULONG dataval,USHORT cntval);
C41W32API ULONG __stdcall C41_Shr(ULONG dataval,USHORT cntval);
C41W32API USHORT __stdcall C41_SignMant(LPCSTR str);
C41W32API INT __stdcall C41_ValAsciiCmpi(LPSTR str1,LPSTR str2);
C41W32API LPSTR __stdcall C41_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
C41W32API VOID __stdcall C41_ValAsciiTrimLead(LPSTR buf);
C41W32API VOID __stdcall C41_ValAsciiTrimTrail(LPSTR buf);
C41W32API ULONG __stdcall C41_ValFromAscii(LPCSTR asciistr,INT radixval);
C41W32API LPSTR __stdcall C41_ValIncAscii(LPSTR asciistr);
C41W32API LPSTR __stdcall C41_ValInccAscii(LPSTR asciistr);
C41W32API BOOL __stdcall C41_ValIsLower(INT value);
C41W32API INT __stdcall C41_ValLenAscii(INT numbits,INT radixval);
C41W32API LPSTR __stdcall C41_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
C41W32API INT __stdcall C41_ValToUpper(INT value);
C41W32API ERRVAL __stdcall C41_Wipe(HCARD handleval);

#ifdef __cplusplus
}
#endif

#define SDI00  0x0001					//Enable SDI00
#define SDI01  0x0002					//Enable SDI01
#define SDI10  0x0004					//Enable SDI10
#define SDI11  0x0008					//Enable SDI11
#define SDIALL 0x000F					//Enable all SDIs

#define RCVCH0 0						//Receive  channel 0
#define RCVCH1 1						//Receive  channel 1
#define RCVCH2 2						//Receive  channel 2
#define RCVCH3 3						//Receive  channel 3
#define XMTCH0 4						//Transmit channel 0
#define XMTCH1 5						//Transmit channel 1

#define RCH0   0						//Receive  channel 0
#define RCH1   1						//Receive  channel 1
#define RCH2   2						//Receive  channel 2
#define RCH717 2						//Receive  717 channel (2)
#define RCH3   3						//Receive  channel 3
#define TCH4   4						//Transmit channel 0
#define TCH5   5						//Transmit channel 1

#define BADCH    0						//Missing channel
#define RCVCH    1						//Receive channel
#define XMTCH    2						//Transmit channel
#define RCV717CH 3						//717 Receive Channel

#define LIST_STAT_EMPTY   0				//List buffer is empty
#define LIST_STAT_PARTIAL 1				//List buffer is partially filled
#define LIST_STAT_FULL    2				//List buffer is full

#define PROC_PRE  1						//Pre-process
#define PROC_POST 2						//Post-process
#define PROC_FORE 3						//Foreground process

#define CHCFG_DEFAULT     0x00000000L	//Select all default settings (default)
#define CHCFG_NOEVEN      0x00000001L	//Reject even parity messages (RCV)
#define CHCFG_PAREVEN     0x00000002L	//Transmit messages with even parity (XMT)
#define CHCFG_HIGHSPEED   0x00000004L	//Select high speed (XMT & RCV)
#define CHCFG_LOWSPEED    0x00000000L	//Select low speed (XMT & RCV)
#define CHCFG_ACTIVE      0x00000008L	//Enable channel activity (XMT & RCV)
#define CHCFG_INACTIVE    0x00000000L	//Disable channel activity (XMT & RCV)
#define CHCFG_SYNC        0x00000010L	//Enable sync output (XMT & RCV)
#define CHCFG_SYNCOFF     0x00000000L	//Disable sync output (XMT & RCV)
#define CHCFG_SERVICE     0x00000020L	//Enable message service count
#define CHCFG_SERVICEOFF  0x00000000L	//Disable message service count
#define CHCFG_TIMETAG     0x00000040L	//Enable time-tag in message record
#define CHCFG_TIMETAGOFF  0x00000000L	//Disable time-tag in message record
#define CHCFG_ELAPSE      0x00000080L	//Enable elapse time
#define CHCFG_ELAPSEOFF   0x00000000L	//Disable elapse time
#define CHCFG_MAXMIN      0x00000100L	//Enable repetition rate monitoring
#define CHCFG_MAXMINOFF   0x00000000L	//Disable repetition rate monitoring
#define CHCFG_WRAPTEST    0x00000200L	//Enable internal wraparound
#define CHCFG_WRAPTESTOFF 0x00000000L	//Disable internal wraparound
#define CHCFG_SDI00       0x00001000L	//Enable SDI00 only (RCV)
#define CHCFG_SDI01       0x00002000L	//Enable SDI01 only (RCV)
#define CHCFG_SDI10       0x00004000L	//Enable SDI10 only (RCV)
#define CHCFG_SDI11       0x00008000L	//Enable SDI11 only (RCV)
#define CHCFG_SDIALL      0x00000000L	//Receive messages with any SDI (RCV)
#define CHCFG_SEQSEL      0x00010000L	//Turn on sequential record for channel
#define CHCFG_SEQALL      0x00020000L	//Turn on sequential record monitoring for channel
#define CHCFG_SEQOFF      0x00000000L	//Turn off sequential record for channel
#define CHCFG_INTSCH      0x00100000L	//Enable schedule interrupts
#define CHCFG_INTHALT     0x00200000L	//Enable schedule stop interrupt
#define CHCFG_INTPAUSE    0x00400000L	//Enable schedule stop interrupt
#define CHCFG_INTLIST     0x01000000L	//Enable list buffer interrupt
#define CHCFG_INTPARITY   0x02000000L	//Enable parity interrupt
#define CHCFG_INTNONE     0x00000000L	//Disable interrupts for channel
#define CHCFG_EXTTRIG     0x10000000L	//Enable external trigger
#define CHCFG_EXTSTART    0x20000000L	//Enable external start
#define CHCFG_EXTOFF      0x00000000L	//Disable external trigger

#define CHCFG717_DEFAULT  0x00000000L	//Select all default settings (default)
#define CHCFG717_SYNC     0x00000010L	//Enable sync output (XMT & RCV)
#define CHCFG717_TIMETAG  0x00000040L	//Enable time-tag in message record
#define CHCFG717_SEQSEL   0x00010000L	//Turn on sequential record for channel
#define CHCFG717_SEQALL   0x00020000L	//Turn on sequential record monitoring for channel
#define CHCFG717_64WPS	  0x00001000L	//Select speed of 64WPS 
#define CHCFG717_128WPS	  0x00002000L	//Select speed of 128WPS 
#define CHCFG717_256WPS	  0x00000000L	//Select speed of 256WPS (default)
#define CHCFG717_512WPS	  0x00004000L	//Select speed of 512WPS 
#define CHCFG717_1024WPS  0x00008000L	//Select speed of 1024WPS

#define WRDCFG_DEFAULT    0x0000        //Disable message record options
#define WRDCFG_SFINT      0x0004		//Enable message interrupt
#define WRDCFG_SFINTOFF   0x0000		//Disable message interrupt
#define WRDCFG_WRDINT     0x0002		//Enable skip message record
#define WRDCFG_WRDINTOFF  0x0000		//Disable skip message record
#define WRDCFG_SEQ        0x0001		//Enable sequential record
#define WRDCFG_SEQOFF     0x0000		//Disable sequential record

#define SEQCFG_DEFAULT     0x0000		//Turn off sequential record
#define SEQCFG_OFF         0x0000		//Turn off sequential record
#define SEQCFG_SEL         0x0001		//Turn on sequential record for channel
#define SEQCFG_ALL         0x0002		//Turn on sequential record monitoring for channel
#define SEQCFG_INT         0x0010		//Enable sequential record full interrupt
#define SEQCFG_INTOFF      0x0000		//Disable sequential record full interrupt
#define SEQCFG_WRAP        0x0020		//Enable sequential record wrap mode
#define SEQCFG_WRAPOFF     0x0000		//Disable sequential record wrap mode
#define SEQCFG_DELTA       0x0040		//Enable sequential record delta mode
#define SEQCFG_DELTAOFF    0x0000		//Disable sequential record delta mode
#define SEQCFG_INTERVAL    0x0080		//Enable sequential record interval mode
#define SEQCFG_INTERVALOFF 0x0000		//Disable sequential record interval mode

#define MSGCFG_DEFAULT    0x0000        //Disable message record options
#define MSGCFG_SEQ        0x0001		//Enable sequential record
#define MSGCFG_SEQOFF     0x0000		//Disable sequential record
#define MSGCFG_INT        0x0002		//Enable message interrupt
#define MSGCFG_INTOFF     0x0000		//Disable message interrupt
#define MSGCFG_SKIP       0x0004		//Enable skip message record
#define MSGCFG_SKIPOFF    0x0000		//Disable skip message record

#define OPCODE_NOP        0x0000
#define OPCODE_MESSAGE    0x0001
#define OPCODE_GAP        0x0002
#define OPCODE_LIST       0x0003
#define OPCODE_HALT       0x0004
#define OPCODE_PAUSE      0x0005
#define OPCODE_RESTART    0x0006
#define OPCODE_INTERRUPT  0x0007
#define OPCODE_USERCODE   0x0008
#define OPCODE_GOTO       0x0009
#define OPCODE_CALL       0x000A
#define OPCODE_RETURN     0x000B
#define OPCODE_DIN0       0x000C
#define OPCODE_DIN1       0x000D
#define OPCODE_PULSE      0x000E

#define COND_NONE         0
#define COND_UNCOND       1
#define COND_DIN0         2
#define COND_DIN1         3

#define REG_INT   0x00					//Interrupt register
#define REG_PAGE  0x01					//Page register
#define REG_RESV1 0x02					//Reserved register
#define REG_RST   0x03					//Reset register
#define REG_INTC  0x04					//Interrupt clear register
#define REG_RESV2 0x05					//Reserved register
#define REG_ERR   0x06					//Error register
#define REG_PWE   0x07					//Prom write enable register

#define REG_SRQ   0x3000				//Service request register
#define REG_MISC  0x3001				//Miscellaneous register
#define REG_INTE  0x3002				//Interrupt enable register
#define REG_SYNC  0x3003				//Sync register
#define REG_CHAN4 0x3004				//Channel 4 control register
#define REG_CHAN5 0x3005				//Channel 5 control register
#define REG_GAP4  0x3008				//Channel 4 gap register
#define REG_GAP5  0x3009				//Channel 5 gap register
#define REG_RESET 0x300F				//Reset register
#define REG_TTL   0x400A				//Time tag low word register
#define REG_TTH   0x400B				//Time tag high word register
#define REG_DAT0L 0x4080				//Channel 0 low data word register
#define REG_DAT0H 0x4081				//Channel 0 high data word register
#define REG_DAT1L 0x4082				//Channel 1 low data word register
#define REG_DAT1H 0x4083				//Channel 1 high data word register
#define REG_DAT2L 0x4084				//Channel 2 low data word register
#define REG_DAT2H 0x4085				//Channel 2 high data word register
#define REG_DAT3L 0x4086				//Channel 3 low data word register
#define REG_DAT3H 0x4087				//Channel 3 high data word register
#define REG_DAT4L 0x4090				//Channel 4 low data word register
#define REG_DAT4H 0x4091				//Channel 4 high data word register
#define REG_DAT5L 0x4092				//Channel 5 low data word register
#define REG_DAT5H 0x4093				//Channel 5 high data word register
#define REG_CTRLA 0x40A0				//Channel 0,1,4 control register
#define REG_CTRLB 0x40A1				//Channel 0,1,5 control register

#define TIMERRESOL_HIGH 1
#define TIMERRESOL_MED  2
#define TIMERRESOL_LOW  3

#define ERR_NONE       0				//No error
#define ERR_UNKNOWN	  -1				//An unexpected error occurred
#define ERR_BADVER    -2                //A bad version was encountered
#define ERR_NOCS      -10				//Card Services is not present
#define ERR_NOSOCKET  -11				//The specified socket is not present
#define ERR_NOCARD    -12				//Unable to find a CM429-1 card in the specified socket
#define ERR_NOTSR     -13				//Unable to find the CM429-1 memory resident driver
#define ERR_CLIENT    -14				//Unable to install a local client driver
#define ERR_CS        -15				//An error was returned by Card Services
#define ERR_WIN		  -16				//Card Services could not configure the memory window, I/O window, or IRQ steering
#define ERR_SEL		  -17				//Unable to allocate a memory selector
#define ERR_BADHANDLE -20				//A bad handle was specified
#define ERR_NOTCHAN   -21				//Specified channel does not exist
#define ERR_NOTRCV    -22				//Specified channel is not a receiver channel
#define ERR_NOTXMT    -23				//Specified channel is not a transmitter channel
#define ERR_LABEL     -24				//Bad label parameter specified
#define ERR_SDI       -25				//Bad SDI parameter specified
#define ERR_BADMSGNUM -26				//Specified message number is out of range
#define ERR_BADSCHNDX -27				//Specified schedule index is out of range
#define ERR_SCHFULL   -28				//Specified schedule is full
#define ERR_BADMSGPTR -29				//Tried to put both user code and list buffer in message
#define ERR_CORRUPT   -31				//Variables have been corrupted
#define ERR_SELFFAIL  -32				//Selftest failed
#define ERR_IOFAIL    -33				//IO selftest failed
#define ERR_MEMFAIL   -34				//Memory selftest failed
#define ERR_LOCK      -35				//Board is locked up
#define ERR_BADTYPE   -36				//Bad type value specified
#define ERR_FACTOR    -41				//A bad factor value was specified
#define ERR_ZEROLEN   -42				//Zero length was specified
#define ERR_BUFSIZE   -43				//Insufficient space in user buffer
#define ERR_NOMSGS    -44				//No messages specified
#define ERR_CONFLICTS -45				//Unable to resolve conflicts
#define ERR_RANGE     -46				//Schedule is out of range
#define ERR_FNAME     -50				//Bad filenames were specified
#define ERR_FRDWR     -51				//There was an error reading or writing the HEX file
#define ERR_HEX       -52				//There was a bad hex character in the HEX file
#define ERR_CRC       -53				//There was a bad checksum in the HEX file
#define ERR_TYPE      -54				//There was a bad type value in the HEX file
#define ERR_BOOTFULL  -61				//No space to add boot code
#define ERR_BOOTNUM   -62				//There is no boot code with the specified number
#define ERR_CISVERIFY -90				//Unable to verify the value written to the CIS
#define ERR_CISNONE   -91				//The CIS is not visible
#define ERR_CISENB    -92				//The PWE register cannot be enabled
#define ERR_CISMAGIC  -93				//Unable to write to the PWE register
#define ERR_VXD       -100				//Error returned from VXD
#define ERR_NOHANDLES -101				//CardOpen() already has allocated too many handles
#define ERR_NOIO      -102				//CardOpen() could not find the I/O
#define ERR_NOMEM     -103				//CardOpen() could not find the I/O
#define ERR_BAD16BIT  -104				//CardOpen() could not find the I/O
#define ERR_NOT717RCV -110				//Specified channel is not a 717 receiver channel
#define ERR_SUBFRMNUM -111				//Invalid 717 SubFrame number was specified or record does not exist
#define ERR_WORDNUM   -112				//Invalid 717 Word number was specified or record does not exist
#define ERR_SUBFRMREC -113				//Invalid 717 SubFrame number was specified or record does not exist
#define ERR_SYNCVAL   -114				//Invalid 717 Sync Value was specified
#define ERR_NOTINSYNC -115				//Not Synchronized to 717 databus

#endif
