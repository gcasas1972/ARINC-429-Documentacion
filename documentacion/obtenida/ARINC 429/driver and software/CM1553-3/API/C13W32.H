/**
*
*  CM1553-3 WIN32 DRIVER  Version 1.6.1  (02/01/2008)
*  Copyright (c) 1999-2008
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   C13W32.H -- Visual C++ 32-bit
*                      CM1553-3 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for the CM1553-3.  Applications
*  using the CM1553-3 Driver Library must incorporate this
*  include file using the preprocessor directive #include. 
*  If this file is in the current working directory, the form
*  would be:
*
*  #include "C13W32.H"
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

#ifndef __C13W32_H
#define __C13W32_H

/**
*
*  Typedefs used by the C13 Driver.
*
**/

#ifndef C13DRVAPI
#ifdef __BORLANDC__
#define C13DRVAPI
#else
#define C13DRVAPI __declspec(dllexport)
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

#ifndef LPCUSHORT
typedef const unsigned short * LPCUSHORT;
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
*  Structs used by the C13 Driver.
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
*  C13 Driver functions.
*
**/

C13DRVAPI ERRVAL __stdcall C13_BCConfig(ULONG configval,HCARD handleval);
C13DRVAPI LISTADDR __stdcall C13_BCCreateList(ULONG listconfigval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_BCCreateMsg(ULONG configval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedFrame(ULONG timeval,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedMsg(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedRetry(USHORT condition,USHORT retries,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BCTransmitMsg(LPXMITFIELDS xmitfields,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BCTransmitMsgEx(LPXMITFIELDS xmitfields,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CardClose(HCARD handleval);
C13DRVAPI HCARD __stdcall C13_CardOpen(INT cardnum);
C13DRVAPI VOID __stdcall C13_CardReset(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CardStart(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_CardStop(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ErrorCtrl(ULONG ctrlval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ErrorDefine(ULONG defineval,USHORT errvalue,INT countval,USHORT wordpos,USHORT bitpos,HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ErrorSent(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ErrorTagBC(BOOL tagval,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ErrorTagRT(BOOL tagval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI INT __stdcall C13_ListDataRd(LPUSHORT buf,INT count,LISTADDR listaddr,HCARD handleval);
C13DRVAPI INT __stdcall C13_ListDataWr(LPUSHORT buf,INT count,LISTADDR listaddr,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_MonBlkRd(LPUSHORT buf,ULONG bufcount,LPULONG blkcnt,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_MonBlkRdEx(LPUSHORT buf,ULONG bufcount,ULONG maxblkcnt,LPULONG blkcnt,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_MonConfig(ULONG configval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_MonFilterSA(INT taval,ULONG rcvsamask,ULONG xmtsamask,ULONG rcvmcmask,ULONG xmtmcmask,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_MonFilterTA(ULONG tamask,HCARD handleval);
C13DRVAPI BOOL __stdcall C13_MonIsRunning(HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MonRd(LPUSHORT buf,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MsgDataRd(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MsgDataWr(LPUSHORT buf,INT count,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_MsgFieldRd(USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_MsgFieldWr(ULONG fieldval,USHORT fieldtype,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_PlayConfig(ULONG configval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_PlayWr(LPUSHORT buf,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_RTConfig(ULONG configval,INT taval,HCARD handleval);
C13DRVAPI LISTADDR __stdcall C13_RTCreateList(ULONG listconfigval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_RTCreateMsg(ULONG configval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_RTGetMsg(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_RTSWDWr(USHORT swdval,INT taval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_ValPackCWD(INT TAval,INT TRflag,INT SAval,INT WCval);
C13DRVAPI VOID __stdcall C13_ValUnpackCWD(USHORT CWDval,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT WCval);

/**
*
*  Internal functions used by the C13 Driver.
*
**/

C13DRVAPI ULONG __stdcall C13_AddrDSP(ULONG addr);
C13DRVAPI ULONG __stdcall C13_AddrHost(ULONG addr);
C13DRVAPI LPSTR __stdcall C13_AsciiCat(LPSTR strdest,LPCSTR strsrc);
C13DRVAPI INT __stdcall C13_AsciiCmpi(LPSTR str1,LPSTR str2);
C13DRVAPI LPSTR __stdcall C13_AsciiCpy(LPSTR strdest,LPCSTR strsrc);
C13DRVAPI INT __stdcall C13_AsciiFromNibble(CHAR ch);
C13DRVAPI LPSTR __stdcall C13_AsciiFromVal(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
C13DRVAPI LPSTR __stdcall C13_AsciiInc(LPSTR asciistr);
C13DRVAPI LPSTR __stdcall C13_AsciiIncc(LPSTR asciistr);
C13DRVAPI BOOL __stdcall C13_AsciiIsLower(INT value);
C13DRVAPI BOOL __stdcall C13_AsciiIsRadix(LPCSTR asciistr,INT radixval);
C13DRVAPI INT __stdcall C13_AsciiLenVal(INT numbits,INT radixval);
C13DRVAPI INT __stdcall C13_AsciiToUpper(INT value);
C13DRVAPI ULONG __stdcall C13_AsciiToVal(LPCSTR asciistr,INT radixval);
C13DRVAPI VOID __stdcall C13_AsciiTrimLead(LPSTR buf);
C13DRVAPI VOID __stdcall C13_AsciiTrimTrail(LPSTR buf);
C13DRVAPI VOID __stdcall C13_AsciiTrimZero(LPSTR buf);
C13DRVAPI ERRVAL __stdcall C13_BCConfigEx(ULONG configval,USHORT count,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_BCConfigMsg(ULONG configval,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI LISTADDR __stdcall C13_BCCreateListEx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
C13DRVAPI LISTADDR __stdcall C13_BCCreateListExx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,USHORT cwd1,USHORT cwd2,LPUSHORT data,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_BCGetMsg(INT index,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedAgain(SCHNDX index,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedBranch(USHORT condition,SCHNDX destindex,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedBranchDin0(SCHNDX destindex,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedBranchDin1(SCHNDX destindex,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedBranchEx(USHORT condition1,USHORT condition2,USHORT condition3,SCHNDX destindex,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BCSchedBuild(USHORT nummsgs,LPMSGADDR msgaddr,LPUSHORT freq,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedCall(SCHNDX destindex,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedCallCond(USHORT condition,SCHNDX destindex,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedCallCondEx(USHORT condition1,USHORT condition2,USHORT condition3,SCHNDX destindex,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedEntry(HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedFrameEnd(HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedFrameStart(ULONG timeval,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedGap(USHORT gapval,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedGoto(SCHNDX destindex,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedHalt(HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedInt(USHORT tagval,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedIntCond(USHORT condition,USHORT tagval,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedIntCondEx(USHORT condition1,USHORT condition2,USHORT condition3,USHORT tagval,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedNop(HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedPause(HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedPulse(HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedPulse0(HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedPulse1(HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedRestart(HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedRetryEx(USHORT condition1,USHORT condition2,USHORT condition3,USHORT retryflag,USHORT retries,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedReturn(HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSchedUser(ULONG useraddr,HCARD handleval);
C13DRVAPI SCHNDX __stdcall C13_BCSetEntry(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BCSetTimeout(USHORT timeoutval,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_BlkAddr(INT taval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_BlkOptRd(INT taval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BlkOptWr(USHORT rtopt,INT taval,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_BlkPtrRd(INT taval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_BlkPtrWr(ULONG descaddr,INT taval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BlkRd(LPUSHORT block,INT taval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BlkReset(INT taval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_BlkSWDRd(INT taval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BlkSWDWr(USHORT swdval,INT taval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BlkWipe(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BlkWr(LPUSHORT block,INT taval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootAdd(LPCSTR filename,LPCSTR name,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootAddProc(USHORT value,USHORT addr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootAddr(INT index,LPUSHORT addr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootAddrNext(LPUSHORT addr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootCount(LPUSHORT count,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootCrc(USHORT index,LPULONG crc,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootDelete(USHORT index,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootGet(USHORT index,LPCSTR filename,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootInfo(USHORT index,LPUSHORT base,LPUSHORT length,LPSTR name,USHORT namelen,LPULONG crc,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootPtrGet(LPUSHORT index,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootPtrPut(USHORT index,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootRdW(LPUSHORT value,USHORT addr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootStr(USHORT index,LPSTR keystr,LPSTR buf,USHORT bufcount,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootWipe(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_BootWrW(USHORT value,USHORT addr,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_CallbackHand(USHORT function,INT socketval,USHORT info,USHORT data,LPVOID ptr,LPVOID buf,USHORT misc);
C13DRVAPI ERRVAL __stdcall C13_CallbackIns(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CallbackRem(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CardBoot(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CardCloseAll(VOID);
C13DRVAPI ERRVAL __stdcall C13_CardConfig(BOOL enableflag,USHORT command,USHORT taval,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_CardGetInfo(USHORT infotype,HCARD handleval);
C13DRVAPI LPCSTR __stdcall C13_CardGetInfos(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CardGetParam(LPSTR cardstr,LPINT cardnum,LPINT devnum,LPULONG sizval,LPUSHORT memval,LPUSHORT ioval,LPUSHORT irqval,LPUSHORT spdval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_CardInit(VOID);
C13DRVAPI BOOL __stdcall C13_CardIsRunning(HCARD handleval);
C13DRVAPI HCARD __stdcall C13_CardOpenEx(LPCSTR cardname,INT cardnum);
C13DRVAPI HCARD __stdcall C13_CardOpenExx(LPCSTR cardname,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
C13DRVAPI VOID __stdcall C13_CardResetEx(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CardResume(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CardTest(USHORT level,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CardTest0(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CardTest1(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CardTest2(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CardTest3(HCARD handleval);
C13DRVAPI VOID __stdcall C13_CardTrigger(HCARD handleval);
C13DRVAPI VOID __stdcall C13_CDBase(LPUSHORT memval,LPUSHORT ioval,LPUSHORT irqval,LPUSHORT sizval,LPUSHORT spdval,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDDeregisterClient(VOID);
C13DRVAPI ERRVAL __stdcall C13_CDMapMem(ULONG offset,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDRegisterClient(VOID);
C13DRVAPI ERRVAL __stdcall C13_CDReleaseAll(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDReleaseConfig(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDReleaseDMA(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDReleaseExclusive(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDReleaseIO(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDReleaseIRQ(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDReleaseMem(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDRequestAll(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDRequestConfig(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDRequestDMA(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDRequestExclusive(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDRequestIO(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDRequestIRQ(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDRequestMem(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDReset(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDRestartAll(INT socketval);
C13DRVAPI VOID __stdcall C13_CDVarConfig(ULONG value,USHORT symbol,INT socketval);
C13DRVAPI USHORT __stdcall C13_CDVarCount(INT socketval);
C13DRVAPI VOID __stdcall C13_CDVarDefault(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDVarLoad(INT socketval);
C13DRVAPI ULONG __stdcall C13_CDVarQuery(USHORT symbol,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CDVarRetrieve(USHORT index,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEAttributeConfig(INT socketval);
C13DRVAPI VOID __stdcall C13_CEBase(LPUSHORT memval,LPUSHORT ioval,LPUSHORT irqval,LPUSHORT sizval,LPUSHORT spdval,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CECall(USHORT func,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CECallEx(USHORT func,INT socketval,LPUSHORT valuewptr,LPULONG valuelptr);
C13DRVAPI ERRVAL __stdcall C13_CECISClose(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CECISDisable(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CECISEnable(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CECISFlush(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CECISOpen(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CECISRead(LPUSHORT value,USHORT addr,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CECISReads(LPUSHORT value,USHORT addr,USHORT count,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CECISWrite(USHORT value,USHORT addr,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CECISWrites(LPUSHORT value,USHORT addr,USHORT count,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEDeregisterClient(VOID);
C13DRVAPI VOID __stdcall C13_CEErrorClear(VOID);
C13DRVAPI USHORT __stdcall C13_CEErrorCount(VOID);
C13DRVAPI ERRVAL __stdcall C13_CEErrorValue(USHORT index);
C13DRVAPI ERRVAL __stdcall C13_CEFiveVoltConfig(INT socketval);
C13DRVAPI USHORT __stdcall C13_CEFuncID(VOID);
C13DRVAPI ERRVAL __stdcall C13_CEIOAttrConfig(USHORT attrval,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEIOBaseConfig(USHORT baseval,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEIRQAttrConfig(USHORT attrval,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEIRQIrqConfig(USHORT irqval,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEMapMemory(ULONG offset,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEMemAttrConfig(USHORT attrval,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEMemBaseConfig(USHORT baseval,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEMemSizeConfig(ULONG sizeval,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEMemSpeedConfig(USHORT speedval,INT socketval);
C13DRVAPI BOOL __stdcall C13_CEPresent(VOID);
C13DRVAPI ERRVAL __stdcall C13_CERegisterClient(VOID);
C13DRVAPI ERRVAL __stdcall C13_CEReleaseAll(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEReleaseConfig(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEReleaseDMA(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEReleaseIO(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEReleaseIRQ(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEReleaseMemory(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CERequestAll(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CERequestConfig(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CERequestDMA(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CERequestIO(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CERequestIRQ(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CERequestMemory(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEReset(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEResetCheck(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEResetError(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CERestartAll(INT socketval);
C13DRVAPI VOID __stdcall C13_CEVarConfig(ULONG value,USHORT symbol,INT socketval);
C13DRVAPI VOID __stdcall C13_CEVarDefault(INT socketval);
C13DRVAPI ULONG __stdcall C13_CEVarQuery(USHORT symbol,INT socketval);
C13DRVAPI ERRVAL __stdcall C13_CEZeroVoltConfig(INT socketval);
C13DRVAPI ERRVAL __stdcall C13_ClientInstall(LPVOID func);
C13DRVAPI ERRVAL __stdcall C13_ClientUninstall(VOID);
C13DRVAPI ULONG __stdcall C13_CmdAddr(SCHNDX index,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_CmdAlloc(INT count,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_CmdAllocEx(ULONG configval,INT count,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_CmdBaseRd(HCARD handleval);
C13DRVAPI VOID __stdcall C13_CmdBaseWr(ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CmdClear(HCARD handleval);
C13DRVAPI USHORT __stdcall C13_CmdCountRd(HCARD handleval);
C13DRVAPI VOID __stdcall C13_CmdCountWr(USHORT countval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_CmdCtrlRd(SCHNDX index,HCARD handleval);
C13DRVAPI VOID __stdcall C13_CmdCtrlWr(USHORT ctrlval,SCHNDX index,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_CmdCurrRd(HCARD handleval);
C13DRVAPI VOID __stdcall C13_CmdCurrWr(USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_CmdInit(USHORT opcode,LPUSHORT block);
C13DRVAPI SCHNDX __stdcall C13_CmdInsert(LPUSHORT block,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_CmdMaxRd(HCARD handleval);
C13DRVAPI VOID __stdcall C13_CmdMaxWr(USHORT count,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CmdRd(LPUSHORT block,ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CmdShotWr(BOOL value,SCHNDX index,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CmdSkipWr(BOOL value,SCHNDX index,HCARD handleval);
C13DRVAPI VOID __stdcall C13_CmdStackClear(HCARD handleval);
C13DRVAPI USHORT __stdcall C13_CmdStartRd(HCARD handleval);
C13DRVAPI VOID __stdcall C13_CmdStartWr(USHORT addrval,HCARD handleval);
C13DRVAPI INT __stdcall C13_CmdTotalRd(HCARD handleval);
C13DRVAPI VOID __stdcall C13_CmdTotalWr(INT countval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CmdWr(LPUSHORT block,ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommCall(ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommCheck(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommCheckEx(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommConfig(BOOL enableflag,USHORT command,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommDataRdL(LPULONG valueptr,ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommDataRdsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommDataRdW(LPUSHORT valueptr,ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommDataWrL(ULONG value,ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommDataWrsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommDataWrW(USHORT value,ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommDisable(USHORT command,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommEnable(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommErrRdsW(LPUSHORT errbuf,USHORT errbufcount,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommErrWrsW(LPUSHORT errbuf,USHORT errbufcount,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommGlobRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommGlobWrW(USHORT value,USHORT addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommInfoRdsW(LPUSHORT bufmodel,USHORT bufmodelcount,LPUSHORT buffeature,USHORT buffeaturecount,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommProgRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommProgWrW(USHORT value,USHORT addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommRun(LPUSHORT dataptr,USHORT datacount,LPUSHORT progptr,USHORT progcount,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommStart(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CommStop(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_CSAdjustResourceInfo(USHORT action,USHORT resource,LPVOID resourceinfo,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSAdjustResourceInfoDma(USHORT action,LPVOID dmainfo,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSAdjustResourceInfoIo(USHORT action,LPVOID ioinfo,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSAdjustResourceInfoIrq(USHORT action,LPVOID irqinfo,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSAdjustResourceInfoMem(USHORT action,LPVOID meminfo,LPVOID clientinfo);
C13DRVAPI USHORT __stdcall C13_CSCall(USHORT func,LPUSHORT handle,LPVOID ptr,LPVOID argptr,USHORT arglen);
C13DRVAPI ERRVAL __stdcall C13_CSDeregisterClient(LPVOID clientinfo);
C13DRVAPI VOID __stdcall C13_CSErrClear(VOID);
C13DRVAPI INT __stdcall C13_CSErrGetCode(USHORT index);
C13DRVAPI USHORT __stdcall C13_CSErrGetCount(VOID);
C13DRVAPI VOID __stdcall C13_CSErrInsert(ERRVAL errval);
C13DRVAPI ERRVAL __stdcall C13_CSGetCardServicesInfoStr(LPSTR vendorstring,USHORT vendorstringlen);
C13DRVAPI ERRVAL __stdcall C13_CSGetCardServicesInfoVal(LPVOID csinfo);
C13DRVAPI ERRVAL __stdcall C13_CSGetClientInfo(LPSTR namestring,USHORT namestringlen,LPSTR vendorstring,USHORT vendorstringlen,LPVOID clientinfo);
C13DRVAPI LPSTR __stdcall C13_CSGetClientInfoName(LPSTR namestring,USHORT namestringlen,LPVOID clientinfo);
C13DRVAPI LPSTR __stdcall C13_CSGetClientInfoVendor(LPSTR vendorstring,USHORT vendorstringlen,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSGetConfigurationInfo(INT socketval,LPVOID configinfo,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSGetFirstClient(INT socketval,USHORT attributes,LPVOID clientinfo);
C13DRVAPI USHORT __stdcall C13_CSGetFirstTuple(INT socketval,USHORT attributes,USHORT desiredtuple,LPVOID tupleinfo);
C13DRVAPI ERRVAL __stdcall C13_CSGetNextClient(INT socketval,USHORT attributes,LPVOID clientinfo);
C13DRVAPI USHORT __stdcall C13_CSGetNextTuple(USHORT desiredtuple,LPVOID tupleinfo);
C13DRVAPI ERRVAL __stdcall C13_CSGetStatus(LPUSHORT cardstate,LPUSHORT socketstate,INT socketval);
C13DRVAPI USHORT __stdcall C13_CSGetStatusCard(INT socketval);
C13DRVAPI USHORT __stdcall C13_CSGetStatusSocket(INT socketval);
C13DRVAPI USHORT __stdcall C13_CSGetTupleChan(INT socketval);
C13DRVAPI USHORT __stdcall C13_CSGetTupleCount(INT socketval,USHORT desiredtuple);
C13DRVAPI USHORT __stdcall C13_CSGetTupleData(INT socketval,USHORT tupleoffset,LPBYTE tupledata,USHORT tupledatalen,LPVOID tupleinfo);
C13DRVAPI USHORT __stdcall C13_CSGetTupleIndex(INT socketval,USHORT index,USHORT desiredtuple,LPBYTE tupledata,USHORT tupledatalen);
C13DRVAPI ERRVAL __stdcall C13_CSGetTupleManuf(LPUSHORT code,LPUSHORT info,INT socketval);
C13DRVAPI USHORT __stdcall C13_CSLevel(VOID);
C13DRVAPI ERRVAL __stdcall C13_CSMapMemPage(ULONG cardoffset,USHORT page,LPVOID windowinfo);
C13DRVAPI ERRVAL __stdcall C13_CSModifyConfiguration(INT socketval,LPVOID configinfo,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSModifyWindow(USHORT attributes,USHORT accessspeed,LPVOID windowinfo);
C13DRVAPI ERRVAL __stdcall C13_CSRegisterClient(USHORT attributes,USHORT eventmask,USHORT version,LPVOID clientinfo,LPVOID func,USHORT data,LPVOID dataptr);
C13DRVAPI ERRVAL __stdcall C13_CSReleaseConfiguration(INT socketval,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSReleaseDMA(INT socketval,USHORT desiredchannel,BYTE attributes,BYTE assignedchannel,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSReleaseExclusive(INT socketval,USHORT attributes,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSReleaseIO(INT socketval,USHORT baseport,USHORT numports,USHORT attributes,USHORT ioaddrlines,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSReleaseIRQ(INT socketval,USHORT attributes,USHORT assignedirq,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSReleaseWindow(LPVOID windowinfo);
C13DRVAPI ERRVAL __stdcall C13_CSRequestConfiguration(INT socketval,LPVOID configinfo,LPVOID clientinfo);
C13DRVAPI BYTE __stdcall C13_CSRequestDMA(INT socketval,USHORT desiredchannel,BYTE attributes,LPBYTE assignedchannel,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSRequestExclusive(INT socketval,USHORT attributes,LPVOID clientinfo);
C13DRVAPI USHORT __stdcall C13_CSRequestIO(INT socketval,USHORT baseport,USHORT numports,USHORT attributes,USHORT ioaddrlines,LPVOID clientinfo);
C13DRVAPI USHORT __stdcall C13_CSRequestIRQ(INT socketval,LPUSHORT attributes,USHORT irqinfo1,USHORT irqinfo2,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSRequestWindow(INT socketval,LPUSHORT attributes,LPULONG base,LPULONG size,USHORT accessspeed,LPVOID windowinfo,LPVOID clientinfo);
C13DRVAPI ERRVAL __stdcall C13_CSResetCard(INT socketval,LPVOID clientinfo);
C13DRVAPI USHORT __stdcall C13_CSRevision(VOID);
C13DRVAPI USHORT __stdcall C13_CSSignature(VOID);
C13DRVAPI USHORT __stdcall C13_CSSocketCount(VOID);
C13DRVAPI USHORT __stdcall C13_CSValidateCIS(INT socketval);
C13DRVAPI LPSTR __stdcall C13_CSVendorString(LPSTR buf,USHORT bufsize);
C13DRVAPI VOID __stdcall C13_DARClear(USHORT maskval,USHORT addrval,HCARD handleval);
C13DRVAPI BOOL __stdcall C13_DARGet(USHORT maskval,USHORT addrval,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_DARRdL(USHORT addrval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_DARRdW(USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_DARSet(USHORT maskval,USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_DARWrL(ULONG value,USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_DARWrW(USHORT value,USHORT addrval,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_DescAddr(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_DescAlloc(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_DescConfig(ULONG configval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_DescOptRd(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_DescOptWr(USHORT descopt,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_DescPtrRd(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_DescPtrWr(MSGADDR msgaddr,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_DescRd(BOOL mcflag,INT taval,BOOL trflag,INT saval,LPUSHORT desc,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_DescWr(BOOL mcflag,INT taval,BOOL trflag,INT saval,LPUSHORT desc,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_Div(ULONG diva,ULONG divb);
C13DRVAPI INT __stdcall C13_DllUsageCount(VOID);
C13DRVAPI ERRVAL __stdcall C13_DspBioClear(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_DspBioRd(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_DspBioSet(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_DspIntfClear(USHORT intmask,HCARD handleval);
C13DRVAPI BOOL __stdcall C13_DspIntfRd(USHORT intmask,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_DspIntmClear(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_DspIntmSet(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_DspXfClear(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_DspXfRd(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_DspXfSet(HCARD handleval);
C13DRVAPI LPCSTR __stdcall C13_ErrDesc(INT errval);
C13DRVAPI LPCSTR __stdcall C13_ErrDescStr(INT errval);
C13DRVAPI LPCSTR __stdcall C13_ErrName(INT errval);
C13DRVAPI BOOL __stdcall C13_ErrorIsTaggedBC(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ErrorIsTaggedRT(BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ErrorResponse(USHORT responseval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_ErrorSync(BOOL value,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ErrorTimeout(USHORT timeoutval,HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ExtDinRd(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ExtDoutRd(HCARD handleval);
C13DRVAPI VOID __stdcall C13_ExtDoutWr(BOOL doutval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_FileClose(LPVOID handle);
C13DRVAPI BOOL __stdcall C13_FileErr(VOID);
C13DRVAPI VOID __stdcall C13_FileErrClear(VOID);
C13DRVAPI VOID __stdcall C13_FileErrSet(VOID);
C13DRVAPI LPVOID __stdcall C13_FileOpenRead(LPCSTR filename);
C13DRVAPI LPVOID __stdcall C13_FileOpenWrite(LPCSTR filename);
C13DRVAPI BOOL __stdcall C13_FileRead(LPVOID handle,LPVOID buffer,USHORT count);
C13DRVAPI BOOL __stdcall C13_FileSeek(LPVOID handle,ULONG offset);
C13DRVAPI ULONG __stdcall C13_FileTell(LPVOID handle);
C13DRVAPI BOOL __stdcall C13_FileWrite(LPVOID handle,LPVOID buffer,USHORT count);
C13DRVAPI USHORT __stdcall C13_GetHigh(ULONG val);
C13DRVAPI USHORT __stdcall C13_GetLow(ULONG val);
C13DRVAPI USHORT __stdcall C13_GetOff(LPVOID valptr);
C13DRVAPI USHORT __stdcall C13_GetSeg(LPVOID valptr);
C13DRVAPI USHORT __stdcall C13_GlobalRdW(USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_GlobalWrW(USHORT value,USHORT addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HandleClose(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HandleDel(HCARD handleval);
C13DRVAPI HCARD __stdcall C13_HandleIns(LPCSTR cardname,INT cardnum,LPVOID hAppWnd,USHORT uiRemovalMsg);
C13DRVAPI BOOL __stdcall C13_HandleOkay(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HandleOpen(LPCSTR cardname,INT cardnum,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HandleOpenDOS(LPCSTR cardname,INT cardnum,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HandleOpenWin(LPCSTR cardname,INT cardnum,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HandleVer(HCARD handleval);
C13DRVAPI ULONG __stdcall C13_HeapAlloc(ULONG wordcount,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_HeapAllocAll(LPULONG wordcount,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_HeapAllocAllDPM(LPULONG wordcount,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_HeapAllocDPM(ULONG wordcount,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_HeapAllocEx(USHORT configval,ULONG wordcount,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_HeapWipe(HCARD handleval);
C13DRVAPI ULONG __stdcall C13_HeapWipeDPM(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HexRd(LPCSTR fname,ERRVAL (__stdcall *proc)(USHORT value,USHORT addr,HCARD handleval),HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HexRun(LPCSTR fname,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HexRunProc(USHORT value,USHORT addr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HexStat(LPUSHORT lowaddr,LPUSHORT highaddr,LPUSHORT count,LPCSTR fname);
C13DRVAPI ERRVAL __stdcall C13_HexStatProc(USHORT value,USHORT addr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HexWrAddr(USHORT addr);
C13DRVAPI ERRVAL __stdcall C13_HexWrByte(BYTE ch);
C13DRVAPI ERRVAL __stdcall C13_HexWrClose(void);
C13DRVAPI ERRVAL __stdcall C13_HexWrFlush(void);
C13DRVAPI ERRVAL __stdcall C13_HexWrFlushByte(USHORT value);
C13DRVAPI ERRVAL __stdcall C13_HexWrOpen(LPCSTR fname);
C13DRVAPI USHORT __stdcall C13_HPMAddrRd(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HPMAddrWr(USHORT addrval,HCARD handleval);
C13DRVAPI BYTE __stdcall C13_HPMCtrlRd(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HPMCtrlWr(BYTE value,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_HPMDataRd(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HPMDataRds(LPUSHORT valueptr,USHORT countval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HPMDataWr(USHORT value,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_HPMDataWrs(LPUSHORT valueptr,USHORT countval,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_HPMRdL(USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_HPMRdsL(LPULONG valueptr,USHORT addrval,INT countval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_HPMRdsW(LPUSHORT valueptr,USHORT addrval,INT countval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_HPMRdW(USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_HPMWrL(ULONG value,USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_HPMWrsL(LPULONG valueptr,USHORT addrval,INT countval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_HPMWrsW(LPUSHORT valueptr,USHORT addrval,INT countval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_HPMWrW(USHORT value,USHORT addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_IntClear(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_IntConfig(USHORT configval,USHORT count,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_IntDisable(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_IntEnable(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_IntEnableCond(HCARD handleval);
C13DRVAPI LPVOID __stdcall C13_IntGet(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_IntInstall(LPVOID hEvent,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_IntRd(LPUSHORT typeval,LPUSHORT infoval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_IntReset(HCARD handleval);
C13DRVAPI INT __stdcall C13_IntStatus(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_IntUninstall(HCARD handleval);
C13DRVAPI USHORT __stdcall C13_IORdW(INT addrval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_IOWINRdW(USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_IOWINWrW(USHORT value,USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_IOWrW(USHORT value,INT addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernBegin(LPVOID *vxdptr,LPSTR cardstr,LPCSTR cardname);
C13DRVAPI ERRVAL __stdcall C13_KernEnd(LPVOID vxdptr);
C13DRVAPI ERRVAL __stdcall C13_KernIntClear(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernIntInstall(LPVOID hEvent,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernIntParam(ULONG clraddr,ULONG clrwidth,ULONG clrvalue,ULONG stataddr,ULONG statwidth,ULONG statvalue,ULONG statmask,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernIntStatus(LPINT valueptr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernIntUninstall(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernIORdB(LPBYTE valueptr,ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernIOWrB(BYTE value,ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMCopyB(LPVOID destptr,LPVOID srcptr,USHORT countval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMFillW(USHORT value,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMRdB(LPBYTE valueptr,ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMRdL(LPULONG valueptr,ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMRdsL(LPULONG bufptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMRdsW(LPUSHORT bufptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMRdW(LPUSHORT valueptr,ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMWrB(BYTE value,ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMWrL(ULONG value,ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMWrsL(LPULONG bufptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMWrsW(LPUSHORT bufptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernMEMWrW(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_KernStatus(LPULONG valueptr,ULONG type,ULONG index,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_ListAddr(INT index,LISTADDR listaddr,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_ListAddrEx(INT index,LISTADDR listaddr,LPUSHORT header);
C13DRVAPI MSGADDR __stdcall C13_ListBlockRd(LPUSHORT buf,LISTADDR listaddr,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_ListBlockRdEx(LPUSHORT buf,INT index,LISTADDR listaddr,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_ListBlockWr(LPUSHORT buf,LISTADDR listaddr,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_ListBlockWrEx(LPUSHORT buf,INT index,LISTADDR listaddr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ListClear(LISTADDR listaddr,HCARD handleval);
C13DRVAPI LISTADDR __stdcall C13_ListConfig(ULONG configval,INT count,USHORT skipval,HCARD handleval);
C13DRVAPI LISTADDR __stdcall C13_ListConfigEx(ULONG configval,INT count,USHORT skipval,HCARD handleval);
C13DRVAPI INT __stdcall C13_ListDataRdEx(LPUSHORT buf,INT count,INT index,LISTADDR listaddr,HCARD handleval);
C13DRVAPI INT __stdcall C13_ListDataWrEx(LPUSHORT buf,INT count,INT index,LISTADDR listaddr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ListInit(LISTADDR listaddr,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_ListNextRd(ULONG listaddr,LPUSHORT header);
C13DRVAPI MSGADDR __stdcall C13_ListNextWr(ULONG listaddr,LPUSHORT header);
C13DRVAPI VOID __stdcall C13_ListPostRd(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
C13DRVAPI VOID __stdcall C13_ListPostWr(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
C13DRVAPI VOID __stdcall C13_ListPreRd(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
C13DRVAPI VOID __stdcall C13_ListPreWr(LISTADDR listaddr,LPUSHORT header,HCARD handleval);
C13DRVAPI INT __stdcall C13_ListStatus(LISTADDR listaddr,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MakeClientInfo(LPVOID ptr);
C13DRVAPI ULONG __stdcall C13_MakeLong(USHORT valh,USHORT vall);
C13DRVAPI LPVOID __stdcall C13_MakePtr(USHORT valh,USHORT vall);
C13DRVAPI ULONG __stdcall C13_Mask(ULONG dataval,USHORT cntval);
C13DRVAPI VOID __stdcall C13_MEMWINFillW(USHORT value,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MEMWINRdB(ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_MEMWINRdL(ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MEMWINRdsL(LPULONG valueptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MEMWINRdsW(LPUSHORT valueptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MEMWINRdW(ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MEMWINWrB(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MEMWINWrL(ULONG value,ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MEMWINWrsL(LPULONG valueptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MEMWINWrsW(LPUSHORT valueptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MEMWINWrW(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_Mod(ULONG moda,ULONG modb);
C13DRVAPI BOOL __stdcall C13_ModeIsBC(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ModeIsMon(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ModeIsNotBC(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ModeIsNotMon(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ModeIsNotPlay(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ModeIsNotRT(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ModeIsNotSerial(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ModeIsPlay(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ModeIsRT(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_ModeIsSerial(HCARD handleval);
C13DRVAPI USHORT __stdcall C13_ModeRd(HCARD handleval);
C13DRVAPI VOID __stdcall C13_ModeWr(USHORT mode,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_MonClear(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_MonConfigEx(ULONG configval,ULONG moncount,USHORT cardnum,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_MonConfigExx(ULONG configval,ULONG seqaddr,ULONG moncount,USHORT cardnum,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_MonFilterSAEx(INT taval,ULONG rcvsamask,ULONG xmtsamask,ULONG rcvmcmask,ULONG xmtmcmask,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MonRdEx(LPUSHORT buf,USHORT bufcount,HCARD handleval);
C13DRVAPI BOOL __stdcall C13_MonResume(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_MonStart(HCARD handleval);
C13DRVAPI INT __stdcall C13_MonStatus(HCARD handleval);
C13DRVAPI BOOL __stdcall C13_MonStop(HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_MsgBlockRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_MsgBlockWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MsgCheck(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_MsgCommRd(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_MsgCommWr(LPUSHORT buf,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_MsgConfig(ULONG configval,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_MsgConfigEx(ULONG configval,USHORT cwd,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MsgCWD1Rd(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MsgCWD1Wr(USHORT cwd1,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MsgCWD2Rd(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MsgCWD2Wr(USHORT cwd2,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MsgErrorRd(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MsgErrorWr(USHORT value,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MsgFlagRd(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MsgFlagWr(USHORT msgflag,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI BOOL __stdcall C13_MsgIsAccessed(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MsgOptRd(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI VOID __stdcall C13_MsgOptWr(USHORT msgopt,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI MSGADDR __stdcall C13_MsgReset(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MsgSWD1Rd(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_MsgSWD2Rd(MSGADDR msgaddr,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_Mul(ULONG mula,ULONG mulb);
C13DRVAPI ERRVAL __stdcall C13_PlayClear(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_PlayConfigEx(ULONG configval,ULONG playcount,ULONG seqcount,USHORT cardnum,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_PlayConfigExx(ULONG configval,ULONG playaddr,ULONG playcount,ULONG seqaddr,ULONG seqcount,USHORT cardnum,HCARD handleval);
C13DRVAPI INT __stdcall C13_PlayStatus(HCARD handleval);
C13DRVAPI USHORT __stdcall C13_PlayWrEx(LPUSHORT buf,USHORT bufcount,HCARD handleval);
C13DRVAPI BYTE __stdcall C13_PortRd(INT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_PortWr(BYTE value,INT addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ProcCall(ULONG useraddr,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_ProcLoad(LPVOID userbuf,USHORT count,HCARD handleval);
C13DRVAPI VOID __stdcall C13_ProcLoc(LPCUSHORT inputcode,LPUSHORT outputcode,USHORT inputbase,USHORT outputbase,INT count);
C13DRVAPI ERRVAL __stdcall C13_ProcRun(LPVOID userbuf,USHORT count,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ProcSetFore(ULONG useraddr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ProcSetInt(USHORT useraddr,INT intnum,USHORT intmask,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ProcSetPost(ULONG useraddr,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ProcSetPre(ULONG useraddr,MSGADDR msgaddr,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_ProgRdW(USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_ProgWrW(USHORT value,USHORT addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_RAMFill(USHORT value,ULONG addrval,ULONG countval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_RAMRdB(ULONG addrval,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_RAMRdL(ULONG addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_RAMRdsW(LPUSHORT valueptr,ULONG addrval,ULONG countval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_RAMRdW(ULONG addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_RAMWipe(HCARD handleval);
C13DRVAPI VOID __stdcall C13_RAMWipeEx(USHORT value,HCARD handleval);
C13DRVAPI VOID __stdcall C13_RAMWrB(USHORT value,ULONG addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_RAMWrL(ULONG value,ULONG addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_RAMWrsW(LPUSHORT valueptr,ULONG addrval,ULONG countval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_RAMWrW(USHORT value,ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMChksW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMClose(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMDisable(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMEnable(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMFlush(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMInfoRd(LPBYTE buf,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMInfoWr(LPBYTE buf,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMOpen(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMProg(USHORT enableflag,LPUSHORT dataptr,USHORT cntval,ULONG addrval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_ROMProgg(USHORT value,ULONG addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMRdsW(LPUSHORT valueptr,USHORT addrval,USHORT countval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMWrsW(USHORT enableflag,LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_ROMWrW(USHORT value,USHORT addrval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_RTConfigEx(ULONG configval,INT taval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_RTConfigExx(ULONG configval,INT taval,HCARD handleval);
C13DRVAPI LISTADDR __stdcall C13_RTCreateListEx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI LISTADDR __stdcall C13_RTCreateListExx(ULONG listconfigval,INT skipval,INT count,ULONG msgconfigval,BOOL mcflag,INT taval,BOOL trflag,INT saval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_RTReset(INT taval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_RTStatus(INT taval,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_RTSWDRd(INT taval,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_SchedBuild(INT nummsgs,LPMSGADDR msgaddr,LPINT freq,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_SchedBuildEx(INT nummsgs,LPMSGADDR msgaddr,LPINT freq,LPINT period,LPVOID buf,ULONG bufsize,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_SchedBuildExx(ULONG frametime,INT nummsgs,LPMSGADDR msgaddr,LPINT period,LPVOID buf,ULONG bufsize,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_SchedCalc(LPMSGADDR msgaddr,HCARD handleval);
C13DRVAPI VOID __stdcall C13_SchedDisplay(ULONG nummsgs,LPULONG count);
C13DRVAPI VOID __stdcall C13_SchedHook(INT index,LPVOID ptr);
C13DRVAPI ERRVAL __stdcall C13_SchedInsEnd(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_SchedInsMsg(ULONG index,LPMSGADDR msgaddr,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_SchedInsStart(ULONG frametime,ULONG count,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_SchedMaxval(LPULONG array,ULONG arraycount);
C13DRVAPI ULONG __stdcall C13_SchedMinval(LPULONG array,ULONG arraycount);
C13DRVAPI VOID __stdcall C13_SchedPrint(LPSTR str,...);
C13DRVAPI VOID __stdcall C13_SchedPrint(LPSTR str,...);
C13DRVAPI ERRVAL __stdcall C13_SerialClear(HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_SerialConfig(ULONG configval,USHORT count,HCARD handleval);
C13DRVAPI ERRVAL __stdcall C13_SerialConfigEx(ULONG configval,USHORT count,HCARD handleval);
C13DRVAPI INT __stdcall C13_SerialStatus(HCARD handleval);
C13DRVAPI ULONG __stdcall C13_SerialWr(LPUSHORT buf,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_Shl(ULONG dataval,USHORT cntval);
C13DRVAPI ULONG __stdcall C13_Shr(ULONG dataval,USHORT cntval);
C13DRVAPI BOOL __stdcall C13_SocketConfig(INT socketval);
C13DRVAPI BOOL __stdcall C13_SocketPresent(INT socketval);
C13DRVAPI BOOL __stdcall C13_SocketVisable(INT socketval);
C13DRVAPI VOID __stdcall C13_TimerClear(HCARD handleval);
C13DRVAPI ULONG __stdcall C13_TimerRd(HCARD handleval);
C13DRVAPI INT __stdcall C13_TimerResolution(INT timerresol,HCARD handleval);
C13DRVAPI USHORT __stdcall C13_TimerResolutionEx(USHORT timershift,HCARD handleval);
C13DRVAPI ULONG __stdcall C13_ValFromAscii(LPCSTR asciistr,INT radixval);
C13DRVAPI USHORT __stdcall C13_ValGetBits(USHORT oldvalue,INT startbit,INT endbit);
C13DRVAPI USHORT __stdcall C13_ValPackRTCWD(INT MCflag,INT TAval,INT TRflag,INT SAval,INT count);
C13DRVAPI USHORT __stdcall C13_ValPutBits(USHORT oldvalue,USHORT newfld,INT startbit,INT endbit);
C13DRVAPI LPSTR __stdcall C13_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
C13DRVAPI VOID __stdcall C13_ValUnpackRTCWD(USHORT cwd,LPINT BCASTflag,LPINT MCflag,LPINT TAval,LPINT TRflag,LPINT SAval,LPINT count);
C13DRVAPI ERRVAL __stdcall C13_WatchConfig(ULONG configval,HCARD handleval);
C13DRVAPI VOID __stdcall C13_WatchWr(ULONG secs,HCARD handleval);
C13DRVAPI VOID __stdcall C13_WatchWrEx(ULONG value,HCARD handleval);

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
#define BCCFG_MODEL        0x00000000L      //BC messages are created in static RAM (default)
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
#define RTCFG_STDA         0x00400000L      //Use MIL-STD-1553A standard
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
#define RTCFG_MODEL        0x00000000L      //RT messages are created in static RAM (default)
#define RTCFG_RAM          0x00100000L      //RT messages are created in static RAM
#define RTCFG_DPRAM        0x00200000L      //RT messages are created in dual-port RAM
#define RTCFG_RESPONSEB    0x00000000L      //RT responds using MIL-STD-1553B response time (default)
#define RTCFG_RESPONSEA    0x00400000L      //RT responds using MIL-STD-1553A response time

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
*  Watchdog configuration options
*
**/

#define WATCHCFG_DEFAULT    0x00000000L     //Select all default settings
#define WATCHCFG_ENABLE     0x00000000L     //Enable watchdog timer (default)
#define WATCHCFG_DISABLE    0x00000001L     //Disable watchdog timer

/**
*
*  Playback configuration options
*
**/

#define PLAYCFG_DEFAULT     0x00000000L     //Select all default settings
#define PLAYCFG_ENABLE      0x00000000L     //Enable playback (default)
#define PLAYCFG_DISABLE     0x00000001L     //Disable playback
#define PLAYCFG_16K         0x00000000L     //Allocate a 16K playback buffer (default)
#define PLAYCFG_ALLAVAIL    0x00008000L     //Allocate all available memory to playback buffer
#define PLAYCFG_32K         0x00010000L     //Allocate a 32K playback buffer
#define PLAYCFG_64K         0x00020000L     //Allocate a 64K playback buffer
#define PLAYCFG_128K        0x00040000L     //Allocate a 128K playback buffer
#define PLAYCFG_DPRAM       0x00080000L     //Allocate all available dual-port memory

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

#define INFOTYPE_PLAT      0x0001           //Returns the C13 platform type
#define INFOTYPE_PROD      0x0002           //Returns the C13 product type
#define INFOTYPE_DASH      0x0003           //Returns the C13 dash number
#define INFOTYPE_VERSION   0x0004           //Returns the C13 version number
#define INFOTYPE_DATE      0x0005           //Returns the C13 version date
#define INFOTYPE_MODEL     0x0006           //Returns the C13 model number
#define INFOTYPE_MAXCOUNT  0x0007           //Returns the number of terminals the C13 can simulate
#define INFOTYPE_MULTIMODE 0x0008           //Returns whether C13 can simulate multi-modes
#define INFOTYPE_ERRORGEN  0x0009           //Returns whether C13 can generate errors
#define INFOTYPE_CONCURMON 0x000A           //Returns whether C13 has a concurrent monitor
#define INFOTYPE_MONFILTER 0x000B           //Returns whether C13 has a monitor filter
#define INFOTYPE_USERCODE  0x000C           //Returns whether C13 handles user code
#define INFOTYPE_LISTBUF   0x000D           //Returns whether C13 handles list buffering
#define INFOTYPE_MONFAST   0x000E           //Returns whether C13 has a fast monitor
#define INFOTYPE_MONDMA    0x000F           //Returns whether C13 has a dma monitor
#define INFOTYPE_MONBRAKE  0x0010           //Returns whether C13 has a monitor brake
#define INFOTYPE_PLAY      0x0011           //Returns whether C13 has playback capability
#define INFOTYPE_WATCH     0x0012           //Returns whether C13 has a watchdog
#define INFOTYPE_RESPONSEA 0x0013           //Returns whether C13 can do MIL-STD-1553A response time

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
#define MSGCRT_MODEL       0x00000000L      //Message located in static RAM (default)
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

/**
*
*  C13 HOST Registers
*
**/

#define HREG_STAT   0x0000                  //Status register (RD)
#define HREG_SET    0x0001                  //Set register (WR)
#define HREG_CLR    0x0002                  //Clear register (WR)
#define HREG_DCFG   0x0003                  //DSP configuration register (RD/WR)
#define HREG_HCFG   0x0004                  //HOST configuration register (RD/WR)
#define HREG_RESV   0x0005                  //Reserved register
#define HREG_PAGE   0x0006                  //Page register (RD/WR)
#define HREG_ERR    0x0007                  //Error register (RD)
#define HREG_HPCL   0x0008                  //Host port control low (RD/WR)
#define HREG_HPCH   0x0009                  //Host port control high (RD/WR)
#define HREG_HPIL   0x000A                  //Host port incrementer low (RD/WR)
#define HREG_HPIH   0x000B                  //Host port incrementer high (RD/WR)
#define HREG_HPAL   0x000C                  //Host port address low (RD/WR)
#define HREG_HPAH   0x000D                  //Host port address high (RD/WR)
#define HREG_HPDL   0x000E                  //Host port data low (RD/WR)
#define HREG_HPDH   0x000F                  //Host port data high (RD/WR)

/**
*
*  C13 IFGA Registers
*
**/

#define IREG_STAT   0x0020                  //Status register
#define IREG_SET    0x0021                  //Set register
#define IREG_CLR    0x0022                  //Clear register
#define IREG_RESV   0x0023                  //Reserved register
#define IREG_PAGE   0x0024                  //Page register
#define IREG_IOCFG  0x0025                  //I/O configuration register
#define IREG_DMA    0x0026                  //DMA register

/**
*
*  C13 EDGA Registers
*
**/

#define EREG_STAT    0x0000                 //Status register (RD)
#define EREG_STATCLR 0x0001                 //Status clear register (WR)
#define EREG_STATDEC 0x0002                 //Decoder status register (RD)
#define EREG_VALA    0x0004                 //Decoder word value A register
#define EREG_VALAL   0x0004                 //Decoder low word value A register
#define EREG_VALAH   0x0005                 //Decoder high word value A register
#define EREG_VALB    0x0006                 //Decoder word value B register
#define EREG_VALBL   0x0006                 //Decoder low word value B register
#define EREG_VALBH   0x0007                 //Decoder high word value B register
#define EREG_GAPE    0x0008                 //Encoder gap register
#define EREG_CTRLE   0x0009                 //Encoder control register
#define EREG_VALE    0x000A                 //Encoder value register
#define EREG_VALEL   0x000A                 //Encoder low value register
#define EREG_VALEH   0x000B                 //Encoder high value register
#define EREG_ERRE    0x000C                 //Encoder error register
#define EREG_FT      0x000E                 //Frame time register
#define EREG_RST     0x000F                 //Reset register
#define EREG_GAPA    0x0010                 //Decoder gap time A register
#define EREG_GAPB    0x0011                 //Decoder gap time B register
#define EREG_GAPTO   0x0012                 //Decoder gap timeout register
#define EREG_CFGD    0x0014                 //Decoder configuration register
#define EREG_CFGE    0x0015                 //Encoder configuration register
#define EREG_CFGINT  0x0016                 //Interrupt configuration register
#define EREG_ID      0x0017                 //Identification register

/**
*
*  C13 Global Registers
*
**/

#define GREG_IMR    0x0000                  //Interrupt mask register
#define GREG_IFR    0x0001                  //Interrupt flag register
#define GREG_ST0    0x0006                  //Status register 0
#define GREG_ST1    0x0007                  //Status register 1
#define GREG_AL     0x0008                  //Accumulator A low word (bits 15-00)
#define GREG_AH     0x0009                  //Accumulator A high word (bits 31-16)
#define GREG_AG     0x000A                  //Accumulator A guars bits (bits 39-32)
#define GREG_BL     0x000B                  //Accumulator B low word (bits 15-00)
#define GREG_BH     0x000C                  //Accumulator B high word (bits 31-16)
#define GREG_BG     0x000D                  //Accumulator B guard bits (bits 39-32
#define GREG_T      0x000E                  //Temporary register
#define GREG_TRN    0x000F                  //Transition register
#define GREG_AR0    0x0010                  //Auxilliary register 0
#define GREG_AR1    0x0011                  //Auxilliary register 1
#define GREG_AR2    0x0012                  //Auxilliary register 2
#define GREG_AR3    0x0013                  //Auxilliary register 3
#define GREG_AR4    0x0014                  //Auxilliary register 4
#define GREG_AR5    0x0015                  //Auxilliary register 5
#define GREG_AR6    0x0016                  //Auxilliary register 6
#define GREG_AR7    0x0017                  //Auxilliary register 7
#define GREG_SP     0x0018                  //Stack pointer
#define GREG_BK     0x0019                  //Circular-buffer size register
#define GREG_BRC    0x001A                  //Block-repeat counter
#define GREG_RSA    0x001B                  //Block-repeat start address
#define GREG_REA    0x001C                  //Block-repeat end address
#define GREG_PMST   0x001D                  //Processor mode status register
#define GREG_XPC    0x001E                  //Program counter extension register
#define GREG_BDRR0  0x0020                  //Buffered serial port 0 data receive register
#define GREG_BDXR0  0x0021                  //Buffered serial port 0 data transmit register
#define GREG_BSPC0  0x0022                  //Buffered serial port 0 control register
#define GREG_BSPEC0 0x0023                  //Buffered serial port 0 control extension register
#define GREG_TIM    0x0024                  //Timer count register
#define GREG_PRD    0x0025                  //Timer period register
#define GREG_TCR    0x0026                  //Timer control register
#define GREG_SWWSR  0x0028                  //External interface software wait-state register
#define GREG_BSCR   0x0029                  //External interface bank-switching control register
#define GREG_XSWR   0x002B                  //Extended software wait-state register
#define GREG_HPIC   0x002C                  //Host port interface control register
#define GREG_TRCV   0x0030                  //TDM serial port data receive register
#define GREG_TDXR   0x0031                  //TDM serial port data transmit register
#define GREG_TSPC   0x0032                  //TDM serial port control register
#define GREG_TCSR   0x0033                  //TDM serial port channel select register
#define GREG_TRTA   0x0034                  //TDM serial port receive transmit register
#define GREG_TRAD   0x0035                  //TDM serial port receive address register
#define GREG_AXR0   0x0038                  //ABU 0 transmit address register
#define GREG_BKX0   0x0039                  //ABU 0 transmit buffer-size register
#define GREG_ARR0   0x003A                  //ABU 0 receive address register
#define GREG_BKR0   0x003B                  //ABU 0 receive buffer-size register
#define GREG_AXR1   0x003C                  //ABU 1 transmit address register
#define GREG_BKX1   0x003D                  //ABU 1 transmit buffer-size register
#define GREG_ARR1   0x003E                  //ABU 1 receive address register
#define GREG_BKR1   0x003F                  //ABU 1 receive buffer-size register
#define GREG_BDRR1  0x0040                  //Buffered serial port 1 data receive register
#define GREG_BDXR1  0x0041                  //Buffered serial port 1 data transmit register
#define GREG_BSPC1  0x0042                  //Buffered serial port 1 control register
#define GREG_BSPCE1 0x0043                  //Buffered serial port 1 extension register
#define GREG_CLKMD  0x0058                  //Clock-mode register

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
#define ERR_NOCS         -3                 //Card Services is not present
#define ERR_NOSOCKET     -4                 //The specified socket is not present
#define ERR_CS           -5                 //A bad version was encountered
#define ERR_NOTSR        -6                 //Unable to find the CM1553-3 memory resident driver
#define ERR_CLIENT       -7                 //Unable to install a local client driver
#define ERR_WIN          -8                 //Card Services could not configure the memory window, I/O window, or IRQ steering
#define ERR_BADPARAMS    -11                //CardOpen() called with bad parameters
#define ERR_NOHANDLES    -12                //CardOpen() already has allocated too many handles
#define ERR_NOCARD       -13                //CardOpen() could not find a C13 card at the specified address
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
#define ERR_CISVERIFY    -90                //Unable to verify the value written to the CIS
#define ERR_CISNONE      -91                //The CIS is not visible

#endif
