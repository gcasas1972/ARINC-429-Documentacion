/**
*
*  PC629-1 WIN32 DRIVER  Version 1.1  (07/05/2002)
*  Copyright (c) 1999-2002
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   P61W32.H -- Visual C++ 32-bit
*                      PC629-1 Driver Library Include File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for the PC629-1.  Applications
*  using the PC629-1 Driver Library must incorporate this
*  include file using the preprocessor directive #include. 
*  If this file is in the current working directory, the form
*  would be:
*
*  #include "P61W32.H"
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

#ifndef __P61W32_H
#define __P61W32_H

/**
*
*  Typedefs used by the PC629-1 Driver.
*
**/

#ifndef P61W32API
#define P61W32API __declspec(dllimport)
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

#ifndef LPBOOL
typedef int * LPBOOL;
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
*  PC629-1 Driver functions.
*
**/

P61W32API VOID __stdcall PC629_ALTen(USHORT altval,HCARD handleval);
P61W32API VOID __stdcall PC629_AXTen(USHORT axtval,HCARD handleval);
P61W32API USHORT __stdcall PC629_BIT(HCARD handleval);
P61W32API USHORT __stdcall PC629_BITProm(HCARD handleval);
P61W32API USHORT __stdcall PC629_BITRam(HCARD handleval);
P61W32API USHORT __stdcall PC629_BITSim(HCARD handleval);
P61W32API ERRVAL __stdcall PC629_CardClose(HCARD handleval);
P61W32API VOID __stdcall PC629_CardCloseAll(VOID);
P61W32API HCARD __stdcall PC629_CardOpen(INT segval,INT portval,INT irqval);
P61W32API HCARD __stdcall PC629_CardOpenEx(INT cardnum);
P61W32API HCARD __stdcall PC629_Check(INT segval,INT portval,INT irqval);
P61W32API VOID __stdcall PC629_CIDSet(USHORT cidval,HCARD handleval);
P61W32API USHORT __stdcall PC629_FileLoad(LPCSTR filename,HCARD handleval);
P61W32API VOID __stdcall PC629_GapSet(USHORT tival,USHORT tgval,USHORT sgval,HCARD handleval);
P61W32API VOID __stdcall PC629_IMAFS(HCARD handleval);
P61W32API VOID __stdcall PC629_IntClr(HCARD handleval);
P61W32API ERRVAL __stdcall PC629_IntInst(LPVOID hEvent,USHORT options,HCARD handleval);
P61W32API ERRVAL __stdcall PC629_IntUninst(HCARD handleval);
P61W32API BOOL __stdcall PC629_IsOn(HCARD handleval);
P61W32API VOID __stdcall PC629_PromFill(USHORT value,HCARD handleval);
P61W32API USHORT __stdcall PC629_PromRdB(ULONG srcaddr,HCARD handleval);
P61W32API VOID __stdcall PC629_PromRdS(ULONG srcaddr,LPVOID destptr,USHORT cntval,HCARD handleval);
P61W32API VOID __stdcall PC629_PromWrB(ULONG destaddr,USHORT value,HCARD handleval);
P61W32API VOID __stdcall PC629_PromWrS(LPVOID srcptr,ULONG destaddr,USHORT cntval,HCARD handleval);
P61W32API USHORT __stdcall PC629_RamBlkAct(USHORT blknum,HCARD handleval);
P61W32API USHORT __stdcall PC629_RamCnt(USHORT blkcnt,HCARD handleval);
P61W32API VOID __stdcall PC629_RamFill(USHORT blknum,USHORT startaddr,ULONG count,USHORT value,HCARD handleval);
P61W32API VOID __stdcall PC629_RamRdS(USHORT blknum,USHORT srcaddr,LPVOID destptr,USHORT cntval,HCARD handleval);
P61W32API USHORT __stdcall PC629_RamRdW(USHORT blknum,USHORT srcaddr,HCARD handleval);
P61W32API VOID __stdcall PC629_RamWrS(LPVOID srcptr,USHORT blknum,USHORT destaddr,USHORT cntval,HCARD handleval);
P61W32API VOID __stdcall PC629_RamWrW(USHORT blknum,USHORT destaddr,USHORT value,HCARD handleval);
P61W32API USHORT __stdcall PC629_RegRdDir(USHORT regnum,HCARD handleval);
P61W32API USHORT __stdcall PC629_RegRdErr(HCARD handleval);
P61W32API USHORT __stdcall PC629_RegRdInd(USHORT regnum,HCARD handleval);
P61W32API USHORT __stdcall PC629_RegRdLWM(HCARD handleval);
P61W32API USHORT __stdcall PC629_RegRdStatus(HCARD handleval);
P61W32API USHORT __stdcall PC629_RegRdVect(HCARD handleval);
P61W32API VOID __stdcall PC629_RegWrDir(USHORT regnum,USHORT value,HCARD handleval);
P61W32API VOID __stdcall PC629_RegWrInd(USHORT regnum,USHORT value,HCARD handleval);
P61W32API VOID __stdcall PC629_Reset(HCARD handleval);
P61W32API BOOL __stdcall PC629_Start(HCARD handleval);
P61W32API BOOL __stdcall PC629_Stop(HCARD handleval);
P61W32API ERRVAL __stdcall PC629_Uncheck(HCARD handleval);
P61W32API ERRVAL __stdcall PC629_UncheckAll();
P61W32API VOID __stdcall PC629_XFormat(USHORT value,HCARD handleval);

/**
*
*  Internal functions used by the PC629-1 Driver.
*
**/

P61W32API ERRVAL __stdcall DRV629_BIT(HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_BITProm(HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_BITRam(HCARD handleval);
P61W32API USHORT __stdcall DRV629_BITSim(HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_CardClose(HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_CardCloseAll(VOID);
P61W32API ERRVAL __stdcall DRV629_CardInit(VOID);
P61W32API HCARD __stdcall DRV629_CardOpen(INT segval,INT portval,INT irqval);
P61W32API HCARD __stdcall DRV629_CardOpenEx(LPCSTR cardname,INT segval,INT portval,INT irqval);
P61W32API HCARD __stdcall DRV629_CardOpenExx(LPCSTR cardname,INT segval,INT portval,INT irqval,LPVOID hAppWnd,USHORT uiRemovalMsg);
P61W32API HCARD __stdcall DRV629_CardOpenExxx(INT cardnum);
P61W32API HCARD __stdcall DRV629_CardOpenExxxx(INT cardnum,LPSTR cardname);
P61W32API HCARD __stdcall DRV629_Check(INT segval,INT portval,INT irqval);
P61W32API ULONG __stdcall DRV629_Div(ULONG diva,ULONG divb);
P61W32API INT __stdcall DRV629_DllUsageCount(VOID);
P61W32API VOID __stdcall DRV629_ErrClear(VOID);
P61W32API BOOL __stdcall DRV629_ErrGetFlag(VOID);
P61W32API ULONG __stdcall DRV629_ErrGetLine(VOID);
P61W32API ERRVAL __stdcall DRV629_ErrGetValue(VOID);
P61W32API VOID __stdcall DRV629_ErrSet(ERRVAL errvalue,ULONG errline);
P61W32API VOID __stdcall DRV629_FileClose(LPVOID handle);
P61W32API ERRVAL __stdcall DRV629_FileLoad(LPCSTR filename,HCARD handleval);
P61W32API LPVOID __stdcall DRV629_FileOpen(LPCSTR filename);
P61W32API VOID __stdcall DRV629_FilePush(LPVOID handle,USHORT value);
P61W32API ERRVAL __stdcall DRV629_FileRead(LPVOID fh,USHORT options,VOID (*func)(VOID),HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_FileReadB(LPVOID handle,LPVOID buffer,USHORT count);
P61W32API ERRVAL __stdcall DRV629_FileSeek(LPVOID handle,ULONG offset);
P61W32API ULONG __stdcall DRV629_FileTell(LPVOID handle);
P61W32API ERRVAL __stdcall DRV629_FileWrite(LPVOID handle,LPVOID buffer,USHORT count);
P61W32API USHORT __stdcall DRV629_GetCID(USHORT index);
P61W32API LPVOID __stdcall DRV629_GetHandler(USHORT index);
P61W32API USHORT __stdcall DRV629_GetHigh(ULONG val);
P61W32API USHORT __stdcall DRV629_GetInitFlag(VOID);
P61W32API USHORT __stdcall DRV629_GetLow(ULONG val);
P61W32API USHORT __stdcall DRV629_GetMask1(USHORT index);
P61W32API USHORT __stdcall DRV629_GetMask2(USHORT index);
P61W32API ULONG __stdcall DRV629_GetPromAddr(USHORT index);
P61W32API USHORT __stdcall DRV629_GetTGSG(USHORT index);
P61W32API USHORT __stdcall DRV629_GetTISG(USHORT index);
P61W32API ERRVAL __stdcall DRV629_HandleClose(HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_HandleDel(HCARD handleval);
P61W32API HCARD __stdcall DRV629_HandleIns(LPCSTR cardname,INT segval,INT portval,INT irqval,LPVOID hAppWnd,USHORT uiRemovalMsg);
P61W32API BOOL __stdcall DRV629_HandleOkay(HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_HandleOpen(LPCSTR cardname,INT segval,INT portval,INT irqval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_HandleVer(HCARD handleval);
P61W32API VOID __stdcall DRV629_IMAFS(HCARD handleval);
P61W32API USHORT __stdcall DRV629_Index(HCARD handleval);
P61W32API VOID __stdcall DRV629_InfoClear(VOID);
P61W32API ULONG __stdcall DRV629_InfoGetDesc(VOID);
P61W32API USHORT __stdcall DRV629_InfoGetFlag(VOID);
P61W32API ULONG __stdcall DRV629_InfoGetLine(VOID);
P61W32API USHORT __stdcall DRV629_InfoGetType(VOID);
P61W32API VOID __stdcall DRV629_InfoSet(USHORT infotype,ULONG infoline,ULONG infodesc);
P61W32API ERRVAL __stdcall DRV629_Insert(USHORT selval,USHORT segval,USHORT portval,USHORT irqval);
P61W32API ERRVAL __stdcall DRV629_IntDisable(HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_IntEnable(USHORT options,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_IntInstall(LPVOID hEvent,USHORT options,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_IntUninstall(HCARD handleval);
P61W32API USHORT __stdcall DRV629_Isalnum(USHORT value);
P61W32API USHORT __stdcall DRV629_Isalpha(USHORT value);
P61W32API USHORT __stdcall DRV629_Isascii(USHORT value);
P61W32API USHORT __stdcall DRV629_Iscntrl(USHORT value);
P61W32API USHORT __stdcall DRV629_Isdigit(USHORT value);
P61W32API USHORT __stdcall DRV629_Isgraph(USHORT value);
P61W32API USHORT __stdcall DRV629_Ishexstr(LPSTR str);
P61W32API USHORT __stdcall DRV629_Islower(USHORT value);
P61W32API BOOL __stdcall DRV629_IsOn(HCARD handleval);
P61W32API USHORT __stdcall DRV629_Isprint(USHORT value);
P61W32API USHORT __stdcall DRV629_Ispunct(USHORT value);
P61W32API USHORT __stdcall DRV629_Isseparate(USHORT value);
P61W32API USHORT __stdcall DRV629_Isspace(USHORT value);
P61W32API USHORT __stdcall DRV629_Isupper(USHORT value);
P61W32API USHORT __stdcall DRV629_Isxdigit(USHORT value);
P61W32API ERRVAL __stdcall DRV629_KernBegin(LPVOID *vxdptr,LPSTR cardstr,INT segval,INT ioval,INT irqval);
P61W32API ERRVAL __stdcall DRV629_KernEnd(LPVOID vxdptr);
P61W32API ERRVAL __stdcall DRV629_KernIntClear(HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernIntInstall(LPVOID hEvent,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernIntUninstall(HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernIOEmptyB(LPBYTE valueptr,INT addrval,INT countval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernIOFillB(BYTE value,INT addrval,INT countval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernIORdB(LPBYTE valueptr,INT addrval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernIORdsB(LPBYTE valueptr,INT addrval,INT countval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernIORdW(LPUSHORT valueptr,INT addrval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernIOWrB(BYTE value,INT addrval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernIOWrsB(LPBYTE valueptr,INT addrval,INT countval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernIOWrW(USHORT value,INT addrval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMFillW(USHORT value,INT addrval,INT countval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMRdB(LPBYTE valueptr,INT addrval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMRdL(LPULONG valueptr,INT addrval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMRdsL(LPULONG bufptr,INT addrval,INT countval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMRdsW(LPUSHORT bufptr,INT addrval,INT countval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMRdW(LPUSHORT valueptr,INT addrval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMWrB(BYTE value,INT addrval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMWrL(ULONG value,INT addrval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMWrsL(LPULONG bufptr,INT addrval,INT countval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMWrsW(LPUSHORT bufptr,INT addrval,INT countval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernMEMWrW(USHORT value,INT addrval,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernQuick(BOOL flag,HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_KernStatusEx(LPULONG valueptr,ULONG type,ULONG index,HCARD handleval);
P61W32API VOID __stdcall DRV629_LineClr(VOID);
P61W32API ULONG __stdcall DRV629_LineGet(VOID);
P61W32API VOID __stdcall DRV629_LineInc(VOID);
P61W32API ULONG __stdcall DRV629_MakeLong(USHORT valh,USHORT vall);
P61W32API ULONG __stdcall DRV629_Mask(ULONG dataval,USHORT cntval);
P61W32API ULONG __stdcall DRV629_MemCrc(USHORT addrval,USHORT cntval,HCARD handleval);
P61W32API ULONG __stdcall DRV629_MemCrcVal(ULONG crc,BYTE value);
P61W32API USHORT __stdcall DRV629_MemRdB(USHORT addrval,HCARD handleval);
P61W32API ULONG __stdcall DRV629_MemRdL(USHORT addrval,HCARD handleval);
P61W32API VOID __stdcall DRV629_MemRdsW(LPVOID dataptr,USHORT addrval,USHORT cntval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_MemRdW(USHORT addrval,HCARD handleval);
P61W32API VOID __stdcall DRV629_MemStosW(USHORT addrval,USHORT dataval,USHORT cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_MemStosWR(USHORT addrval,USHORT cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_MemWrB(USHORT addrval,USHORT dataval,HCARD handleval);
P61W32API VOID __stdcall DRV629_MemWrL(USHORT addrval,ULONG dataval,HCARD handleval);
P61W32API VOID __stdcall DRV629_MemWrsW(USHORT addrval,LPVOID dataptr,USHORT cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_MemWrW(USHORT addrval,USHORT dataval,HCARD handleval);
P61W32API ULONG __stdcall DRV629_Mod(ULONG moda,ULONG modb);
P61W32API ULONG __stdcall DRV629_Mul(ULONG mula,ULONG mulb);
P61W32API VOID __stdcall DRV629_Nocomment(LPSTR str);
P61W32API ERRVAL __stdcall DRV629_OpExec(USHORT opcode,ULONG value,HCARD handleval);
P61W32API USHORT __stdcall DRV629_OpGet(LPCSTR opstr);
P61W32API USHORT __stdcall DRV629_PortInB(USHORT addrval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PortInsB(USHORT addrval,LPVOID dataptr,USHORT cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PortInsW(USHORT addrval,LPVOID dataptr,USHORT cntval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_PortInW(USHORT addrval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_PortLodsB(USHORT addrval,ULONG cntval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_PortLodsW(USHORT addrval,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PortOutB(USHORT addrval,USHORT dataval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PortOutsB(USHORT addrval,LPVOID dataptr,USHORT cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PortOutsW(USHORT addrval,LPVOID dataptr,USHORT cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PortOutW(USHORT addrval,USHORT dataval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PortStepB(USHORT addrval,USHORT dataval,ULONG cntval,USHORT stepval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PortStosB(USHORT addrval,USHORT dataval,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PortStosBR(USHORT addrval,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PortStosW(USHORT addrval,USHORT dataval,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromFill(ULONG addrval,USHORT value,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromFillR(ULONG addrval,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromFillStep(ULONG addrval,USHORT value,ULONG cntval,USHORT stepval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromIns(ULONG addrval,LPVOID dataptr,USHORT cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromLoc(ULONG addrval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_PromLod(ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromOffsetFill(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromOuts(ULONG addrval,LPVOID dataptr,USHORT cntval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_PromRdB(ULONG addrval,HCARD handleval);
P61W32API ULONG __stdcall DRV629_PromRdL(ULONG addrval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_PromRdW(ULONG addrval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromStep(USHORT value,ULONG cntval,USHORT stepval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromSto(USHORT value,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromStoR(ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromWrB(ULONG addrval,USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromWrL(ULONG addrval,ULONG value,HCARD handleval);
P61W32API VOID __stdcall DRV629_PromWrW(ULONG addrval,USHORT value,HCARD handleval);
P61W32API ULONG __stdcall DRV629_RamBlkAddr(USHORT blknum,HCARD handleval);
P61W32API USHORT __stdcall DRV629_RamBlkCnt(USHORT blkcnt,HCARD handleval);
P61W32API USHORT __stdcall DRV629_RamBlkCount(HCARD handleval);
P61W32API USHORT __stdcall DRV629_RamBlkCurr(HCARD handleval);
P61W32API VOID __stdcall DRV629_RamBlkFill(USHORT blkval,ULONG startaddr,ULONG count,USHORT value,HCARD handleval);
P61W32API ULONG __stdcall DRV629_RamBlkSize(HCARD handleval);
P61W32API VOID __stdcall DRV629_RamFill(ULONG addrval,USHORT value,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_RamFillR(ULONG addrval,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_RamLods(ULONG addrval,LPBYTE dataptr,ULONG cntval,HCARD handleval);
P61W32API ULONG __stdcall DRV629_RamPageCrc(USHORT pageval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_RamRdB(ULONG addrval,HCARD handleval);
P61W32API ULONG __stdcall DRV629_RamRdL(ULONG addrval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_RamRdW(ULONG addrval,HCARD handleval);
P61W32API VOID __stdcall DRV629_RamStos(ULONG addrval,LPBYTE dataptr,ULONG cntval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_RamSwitch(USHORT blknum,HCARD handleval);
P61W32API VOID __stdcall DRV629_RamWrB(ULONG addrval,USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RamWrL(ULONG addrval,ULONG value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RamWrW(ULONG addrval,USHORT value,HCARD handleval);
P61W32API USHORT __stdcall DRV629_Rand(VOID);
P61W32API VOID __stdcall DRV629_RegInsProm(LPVOID dataptr,USHORT cntval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegLodPort(ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegOutsProm(LPVOID dataptr,USHORT cntval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdCtrl(HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdDir(USHORT regnum,HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdErr(HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdInd(USHORT regnum,HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdIntVect(HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdLast(HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdMemCfg(HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdMemPage(HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdPort(HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdPortSel(HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdProm(ULONG cntval,HCARD handleval);
P61W32API USHORT __stdcall DRV629_RegRdStatus(HCARD handleval);
P61W32API VOID __stdcall DRV629_RegStepPort(USHORT value,ULONG cntval,USHORT stepval,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegStepProm(USHORT value,ULONG cntval,USHORT stepval,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegStoPort(USHORT value,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegStoRPort(ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrCID(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrClrInt(HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrCtrl(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrDir(USHORT regnum,USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrInd(USHORT regnum,USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrMemCfg(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrMemPage(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrPort(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrPortSel(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrProm(USHORT value,ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrReset(HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrRProm(ULONG cntval,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrSegSel(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrTGSG(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_RegWrTISG(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_Reset(HCARD handleval);
P61W32API VOID __stdcall DRV629_SetCID(USHORT cidval,USHORT index);
P61W32API VOID __stdcall DRV629_SetHandler(LPVOID funcval,USHORT index);
P61W32API VOID __stdcall DRV629_SetInitFlag(USHORT flagval);
P61W32API VOID __stdcall DRV629_SetMask1(USHORT mask1val,USHORT index);
P61W32API VOID __stdcall DRV629_SetMask2(USHORT mask2val,USHORT index);
P61W32API VOID __stdcall DRV629_SetPromAddr(ULONG addrval,USHORT index);
P61W32API VOID __stdcall DRV629_SetTGSG(USHORT tgsgval,USHORT index);
P61W32API VOID __stdcall DRV629_SetTISG(USHORT tisgval,USHORT index);
P61W32API ULONG __stdcall DRV629_Shl(ULONG dataval,USHORT cntval);
P61W32API ULONG __stdcall DRV629_Shr(ULONG dataval,USHORT cntval);
P61W32API VOID __stdcall DRV629_Srand(USHORT value);
P61W32API BOOL __stdcall DRV629_Start(HCARD handleval);
P61W32API BOOL __stdcall DRV629_Stop(HCARD handleval);
P61W32API LPSTR __stdcall DRV629_Strchrr(LPSTR str,USHORT value);
P61W32API INT __stdcall DRV629_Strcmp(LPCSTR str1,LPCSTR str2);
P61W32API INT __stdcall DRV629_Strcmpi(LPSTR str1,LPSTR str2);
P61W32API LPSTR __stdcall DRV629_Strcpy(LPSTR tostr,LPSTR fromstr);
P61W32API INT __stdcall DRV629_Stricmp(LPSTR str1,LPSTR str2);
P61W32API USHORT __stdcall DRV629_Strlen(LPSTR str);
P61W32API LPSTR __stdcall DRV629_Strlwr(LPSTR str);
P61W32API LPSTR __stdcall DRV629_Strmfe(LPSTR newname,LPSTR oldname,LPSTR ext);
P61W32API INT __stdcall DRV629_Strncmp(LPSTR str1,LPSTR str2,USHORT count);
P61W32API LPSTR __stdcall DRV629_Strncpy(LPSTR tostr,LPSTR fromstr,USHORT count);
P61W32API LPSTR __stdcall DRV629_Strpfe(LPSTR newname,LPSTR oldname,LPSTR ext);
P61W32API LPSTR __stdcall DRV629_Strtok(LPSTR str,LPSTR tokenstr);
P61W32API LPSTR __stdcall DRV629_Strupr(LPSTR str);
P61W32API USHORT __stdcall DRV629_TableAddrGet(USHORT index);
P61W32API VOID __stdcall DRV629_TableAddrSet(USHORT index,USHORT value);
P61W32API USHORT __stdcall DRV629_TableIrqGet(USHORT index);
P61W32API VOID __stdcall DRV629_TableIrqSet(USHORT index,USHORT value);
P61W32API USHORT __stdcall DRV629_TablePortGet(USHORT index);
P61W32API VOID __stdcall DRV629_TablePortSet(USHORT index,USHORT value);
P61W32API USHORT __stdcall DRV629_TableSelGet(USHORT index);
P61W32API VOID __stdcall DRV629_TableSelSet(USHORT index,USHORT value);
P61W32API USHORT __stdcall DRV629_TableSizeGet(VOID);
P61W32API VOID __stdcall DRV629_TableSizeSet(USHORT value);
P61W32API ERRVAL __stdcall DRV629_Token(LPVOID fh,LPSTR buf,USHORT count);
P61W32API USHORT __stdcall DRV629_Tolower(USHORT value);
P61W32API USHORT __stdcall DRV629_Toupper(USHORT value);
P61W32API ERRVAL __stdcall DRV629_Uncheck(HCARD handleval);
P61W32API ERRVAL __stdcall DRV629_UncheckAll();
P61W32API INT __stdcall DRV629_ValAsciiCmpi(LPSTR str1,LPSTR str2);
P61W32API LPSTR __stdcall DRV629_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
P61W32API VOID __stdcall DRV629_ValAsciiTrimLead(LPSTR buf);
P61W32API VOID __stdcall DRV629_ValAsciiTrimTrail(LPSTR buf);
P61W32API ULONG __stdcall DRV629_ValFromAscii(LPCSTR asciistr,INT radixval);
P61W32API LPSTR __stdcall DRV629_ValIncAscii(LPSTR asciistr);
P61W32API LPSTR __stdcall DRV629_ValInccAscii(LPSTR asciistr);
P61W32API BOOL __stdcall DRV629_ValIsLower(INT value);
P61W32API INT __stdcall DRV629_ValLenAscii(INT numbits,INT radixval);
P61W32API LPSTR __stdcall DRV629_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
P61W32API INT __stdcall DRV629_ValToUpper(INT value);
P61W32API LPCSTR __stdcall DRV629_Version(VOID);
P61W32API VOID __stdcall DRV629_WipeRam(USHORT value,HCARD handleval);
P61W32API VOID __stdcall DRV629_WrALT(USHORT altval,HCARD handleval);
P61W32API VOID __stdcall DRV629_WrAXT(USHORT axtval,HCARD handleval);
P61W32API VOID __stdcall DRV629_WrCID(USHORT cidval,HCARD handleval);
P61W32API VOID __stdcall DRV629_WrTITGSG(USHORT tival,USHORT tgval,USHORT sgval,HCARD handleval);
P61W32API VOID __stdcall DRV629_XFormat(USHORT value,HCARD handleval);

#ifdef __cplusplus
}
#endif

/**
*
*  PC629-1 Driver predefined constants.
*
**/

#define ALT_OFF             0x0000      //Disables alt, enables primary schedule
#define ALT_ON              0x0001      //Enables alternate schedule

#define AXT_OFF             0x0000      //Disables alternate label extensions
#define AXT_ON              0x0001      //Enables alternate label extensions

#define OPT_NONE            0x0000      //No interrupt options selected
#define INT_ERROR           0x0001      //Interrupts generated on errors

#define FORMAT_INDEP        0x0000      //Selects independent schedule format
#define FORMAT_BLOCK        0x0001      //Selects block schedule format

/**
*
*  PC629-1 Parse Codes.
*
**/

#define INFOVAL_ORG			1		//ORG information
#define INFOVAL_ROM			2		//ROM switch
#define INFOVAL_RAM			3		//RAM switch
#define INFOVAL_RAMBYTE		4		//RAM byte value
#define INFOVAL_RAMWORD		5		//RAM word value
#define INFOVAL_RAMDWORD	6		//RAM long word value
#define INFOVAL_ROMBYTE		7		//ROM byte value
#define INFOVAL_ROMWORD		8		//ROM word value
#define INFOVAL_ROMDWORD	9		//ROM long word value
#define INFOVAL_OPCODE		10		//Opcode code
#define INFOVAL_OPVALUE		11		//Opcode value

/**
*
*  PC629-1 Direct Registers.
*
**/

#define MEM_PAGE_REG	0x0000		//Read/write memory page
#define PORT_SEL_REG	0x0001		//Read/write internal port select
#define INT_CLR_REG		0x0002		//Write clears interrupts
#define VECT_LSB_REG	0x0002		//Read interrupt vector LSB
#define RESET_REG		0x0003		//Write triggers master reset
#define VECT_MSB_REG	0x0003		//Read interrupt vector MSB
#define REG_ACCESS_LSB	0x0004		//Read/write internal register LSB
#define REG_ACCESS_MSB	0x0005		//Read internal register MSB
#define SEG_SEL_REG		0x0006		//Write to segment select
#define STATUS_REG		0x0006		//Read status

/**
*
*  PC629-1 Indirect Registers.
*
**/

#define CID_IREG		0x0000		//Write channel ID
#define TISG_IREG		0x0001		//Write xmit interval/sync gap
#define TGAP_IREG		0x0002		//Write terminal gap
#define MEMCFG_IREG		0x0003		//Read/write memory configuration
#define CTRL_IREG		0x0004		//Read/write control
#define PPROM_IREG		0x0005		//Read/write personality prom
#define ERR_IREG		0x0006		//Read error register
#define LASTWDMON_IREG	0x0007		//Read last word monitor

/**
*
*  PC629-1 Error Return Values.
*
**/

#define ERR_NONE          0                 //No error
#define ERR_UNKNOWN      -1                 //An unexpected error occurred
#define ERR_BADVER       -2                 //A bad version was encountered
#define ERR_BADPARAMS    -11                //CardOpen() called with bad parameters
#define ERR_NOHANDLES    -12                //CardOpen() already has allocated too many handles
#define ERR_NOCARD       -13                //The drivers for the specified PC629-1 card have not been installed
#define ERR_NOIO         -14                //CardOpen() could not find the I/O ports
#define ERR_NOMEM        -15                //CardOpen() could not find the memory
#define ERR_BADHANDLE    -21                //A bad handle was specified
#define ERR_VXD          -28                //An error occurred in the VXD
#define ERR_FNAME        -47                //Bad filenames were specified
#define ERR_FRDWR        -48                //There was an error reading or writing file
#define ERR_UNKNOWNOP    -91                //Unknown opcode
#define ERR_UNKNOWNHEX   -92                //Unknown hexvalue
#define ERR_NOVALUE      -93                //No value for opcode

#endif
