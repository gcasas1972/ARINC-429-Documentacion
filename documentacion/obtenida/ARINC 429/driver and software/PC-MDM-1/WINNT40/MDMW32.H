/**
*
*  PC-MDM-1 WIN32 DRIVER  Version 1.0  (09/20/1997)
*  Copyright (c) 1997
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   MDMW32.H -- Visual C++ 32-bit
*                      PC-MDM-1 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for the PC-MDM-1.  Applications
*  using the PC-MDM-1 Driver Library must incorporate this
*  include file using the preprocessor directive #include. 
*  If this file is in the current working directory, the form
*  would be:
*
*  #include "MDMW32.H"
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

#ifndef __MDMW32_H
#define __MDMW32_H

/**
*
*  Typedefs used by the PC-MDM-1 Driver.
*
**/

#ifndef MDMW32API
#ifdef __BORLANDC__
#define MDMW32API
#else
#define MDMW32API __declspec(dllimport)
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
*  PC-MDM-1 Driver functions.
*
**/

MDMW32API ERRVAL __stdcall MDM_CardClose(HCARD handleval);
MDMW32API HCARD __stdcall MDM_CardOpen(ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval);
MDMW32API VOID __stdcall MDM_Command(INT value,HCARD handleval);
MDMW32API INT __stdcall MDM_CWD(HCARD handleval);
MDMW32API VOID __stdcall MDM_DiscreteTime(INT dta,INT dtb,INT dtc,INT dtd,INT dte,HCARD handleval);
MDMW32API INT __stdcall MDM_Error(HCARD handleval);
MDMW32API INT __stdcall MDM_Go(BOOL trval,INT count,HCARD handleval);
MDMW32API VOID __stdcall MDM_GoEx(BOOL trval,INT count,HCARD handleval);
MDMW32API INT __stdcall MDM_GoExx(BOOL trval,INT count,HCARD handleval);
MDMW32API VOID __stdcall MDM_IntClear(HCARD handleval);
MDMW32API BOOL __stdcall MDM_IsBC(HCARD handleval);
MDMW32API BOOL __stdcall MDM_IsRT(HCARD handleval);
MDMW32API VOID __stdcall MDM_MsgFlag(INT msgflag,HCARD handleval);
MDMW32API VOID __stdcall MDM_MsgOption(INT msgopt,HCARD handleval);
MDMW32API VOID __stdcall MDM_OnOff(BOOL value,HCARD handleval);
MDMW32API BOOL __stdcall MDM_OnOffStatus(HCARD handleval);
MDMW32API VOID __stdcall MDM_RcvRd(LPUSHORT buf,INT count,HCARD handleval);
MDMW32API VOID __stdcall MDM_RcvWr(LPUSHORT buf,INT count,HCARD handleval);
MDMW32API INT __stdcall MDM_Status(HCARD handleval);
MDMW32API VOID __stdcall MDM_SyncClear(HCARD handleval);
MDMW32API VOID __stdcall MDM_Trigger(HCARD handleval);
MDMW32API VOID __stdcall MDM_Wait(HCARD handleval);
MDMW32API VOID __stdcall MDM_XmtRd(LPUSHORT buf,INT count,HCARD handleval);
MDMW32API VOID __stdcall MDM_XmtWr(LPUSHORT buf,INT count,HCARD handleval);

/**
*
*  Internal functions used by the PC-MDM-1 Driver.
*
**/

MDMW32API ULONG __stdcall MDM_AddrDSP(ULONG addr);
MDMW32API ULONG __stdcall MDM_AddrHost(ULONG addr);
MDMW32API ERRVAL __stdcall MDM_CardBoot(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CardCloseAll(VOID);
MDMW32API ULONG __stdcall MDM_CardGetInfo(USHORT infotype,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CardGetInfoEx(LPUSHORT bufmodel,USHORT bufmodelcount,LPUSHORT buffeature,USHORT buffeaturecount,HCARD handleval);
MDMW32API VOID __stdcall MDM_CardInit(VOID);
MDMW32API HCARD __stdcall MDM_CardOpenEx(LPCSTR cardname,ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval);
MDMW32API HCARD __stdcall MDM_CardOpenExx(LPCSTR cardname,ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval,LPVOID hAppWnd,USHORT uiRemovalMsg);
MDMW32API HCARD __stdcall MDM_CardOpenP12(ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval);
MDMW32API HCARD __stdcall MDM_CardOpenP13(ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval);
MDMW32API VOID __stdcall MDM_CardReset(HCARD handleval);
MDMW32API VOID __stdcall MDM_CardResetEx(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CardTest(USHORT level,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CardTest0(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CardTest1(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CardTest2(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CommCall(ULONG addrval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CommCheck(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CommDisable(USHORT command,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CommEnable(HCARD handleval);
MDMW32API ULONG __stdcall MDM_CommRdL(ULONG addrval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CommRdsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
MDMW32API USHORT __stdcall MDM_CommRdW(ULONG addrval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CommRun(LPUSHORT dataptr,USHORT datacount,LPUSHORT codeptr,USHORT codecount,HCARD handleval);
MDMW32API VOID __stdcall MDM_CommWrL(ULONG value,ULONG addrval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_CommWrsW(LPUSHORT valueptr,ULONG addrval,USHORT count,HCARD handleval);
MDMW32API VOID __stdcall MDM_CommWrW(USHORT value,ULONG addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_DARClr(USHORT maskval,USHORT addrval,HCARD handleval);
MDMW32API BOOL __stdcall MDM_DARGet(USHORT maskval,USHORT addrval,HCARD handleval);
MDMW32API ULONG __stdcall MDM_DARRdL(USHORT addrval,HCARD handleval);
MDMW32API USHORT __stdcall MDM_DARRdW(USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_DARSet(USHORT maskval,USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_DARWrL(ULONG value,USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_DARWrW(USHORT value,USHORT addrval,HCARD handleval);
MDMW32API ULONG __stdcall MDM_Div(ULONG diva,ULONG divb);
MDMW32API USHORT __stdcall MDM_DspBioRd(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_DspIntfClear(HCARD handleval);
MDMW32API BOOL __stdcall MDM_DspIntfRead(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_DspIntmClear(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_DspIntmSet(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_DspXfClear(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_DspXfSet(HCARD handleval);
MDMW32API BOOL __stdcall MDM_ExtDinRd(HCARD handleval);
MDMW32API VOID __stdcall MDM_ExtDinWr(BOOL dinval,HCARD handleval);
MDMW32API BOOL __stdcall MDM_ExtDoutRd(HCARD handleval);
MDMW32API VOID __stdcall MDM_ExtDoutWr(BOOL doutval,HCARD handleval);
MDMW32API VOID __stdcall MDM_FileClose(INT handle);
MDMW32API BOOL __stdcall MDM_FileErr(VOID);
MDMW32API VOID __stdcall MDM_FileErrClr(VOID);
MDMW32API VOID __stdcall MDM_FileErrSet(VOID);
MDMW32API INT __stdcall MDM_FileOpenRead(LPCSTR filename);
MDMW32API INT __stdcall MDM_FileOpenWrite(LPCSTR filename);
MDMW32API BOOL __stdcall MDM_FileRead(INT handle,LPVOID buffer,USHORT count);
MDMW32API BOOL __stdcall MDM_FileSeek(INT handle,ULONG offset);
MDMW32API ULONG __stdcall MDM_FileTell(INT handle);
MDMW32API BOOL __stdcall MDM_FileWrite(INT handle,LPVOID buffer,USHORT count);
MDMW32API USHORT __stdcall MDM_GetHigh(ULONG val);
MDMW32API USHORT __stdcall MDM_GetLow(ULONG val);
MDMW32API USHORT __stdcall MDM_GlobalRdW(USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_GlobalWrW(USHORT value,USHORT addrval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_HandleDel(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_HandleGet(LPULONG memval,LPULONG sizval,LPULONG ioval,LPUSHORT irqval,LPUSHORT drqval,HCARD handleval);
MDMW32API HCARD __stdcall MDM_HandleGetIo(USHORT ioval);
MDMW32API HCARD __stdcall MDM_HandleGetMem(ULONG memval);
MDMW32API HCARD __stdcall MDM_HandleIns(LPCSTR cardname,ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval,LPVOID hAppWnd,USHORT uiRemovalMsg);
MDMW32API BOOL __stdcall MDM_HandleOkay(HCARD handleval);
MDMW32API USHORT __stdcall MDM_IndirectRd(USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_IndirectWr(USHORT value,USHORT addrval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_IntDisable(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_IntEnable(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_IntEnableCond(HCARD handleval);
MDMW32API LPVOID __stdcall MDM_IntGet(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_IntInstall(LPVOID hEvent,HCARD handleval);
MDMW32API VOID __stdcall MDM_IntReset(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_IntUninstall(HCARD handleval);
MDMW32API USHORT __stdcall MDM_IORdW(USHORT addrval,HCARD handleval);
MDMW32API USHORT __stdcall MDM_IOWINRdW(USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_IOWINWrW(USHORT value,USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_IOWrW(USHORT value,USHORT addrval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_KernBegin(LPVOID *vxdptr,LPCSTR cardname,ULONG memval,USHORT ioval,USHORT irqval,USHORT drqval);
MDMW32API ERRVAL __stdcall MDM_KernEnd(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_KernIntInstall(LPVOID hEvent,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_KernIntUninstall(HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_KernIORdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_KernIOWrW(USHORT value,USHORT addrval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_KernMEMFillW(USHORT value,USHORT addrval,USHORT countval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_KernMEMRdsW(LPUSHORT bufptr,USHORT addrval,USHORT countval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_KernMEMRdW(LPUSHORT valueptr,USHORT addrval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_KernMEMWrsW(LPUSHORT bufptr,USHORT addrval,USHORT countval,HCARD handleval);
MDMW32API ERRVAL __stdcall MDM_KernMEMWrW(USHORT value,USHORT addrval,HCARD handleval);
MDMW32API ULONG __stdcall MDM_MakeLong(USHORT valh,USHORT vall);
MDMW32API ULONG __stdcall MDM_Mask(ULONG dataval,USHORT cntval);
MDMW32API VOID __stdcall MDM_MEMORYRdsW(LPUSHORT valueptr,INT addrval,INT countval,HCARD handleval);
MDMW32API USHORT __stdcall MDM_MEMORYRdW(INT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_MEMORYWrsW(LPUSHORT valueptr,INT addrval,INT countval,HCARD handleval);
MDMW32API VOID __stdcall MDM_MEMORYWrW(USHORT value,INT addrval,HCARD handleval);
MDMW32API USHORT __stdcall MDM_MEMWINRdB(ULONG addrval,HCARD handleval);
MDMW32API ULONG __stdcall MDM_MEMWINRdL(ULONG addrval,HCARD handleval);
MDMW32API USHORT __stdcall MDM_MEMWINRdW(ULONG addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_MEMWINWrB(USHORT value,ULONG addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_MEMWINWrL(ULONG value,ULONG addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_MEMWINWrW(USHORT value,ULONG addrval,HCARD handleval);
MDMW32API ULONG __stdcall MDM_Mod(ULONG moda,ULONG modb);
MDMW32API BOOL __stdcall MDM_ModeIsBC(HCARD handleval);
MDMW32API BOOL __stdcall MDM_ModeIsMon(HCARD handleval);
MDMW32API BOOL __stdcall MDM_ModeIsNotBC(HCARD handleval);
MDMW32API BOOL __stdcall MDM_ModeIsNotMon(HCARD handleval);
MDMW32API BOOL __stdcall MDM_ModeIsNotRT(HCARD handleval);
MDMW32API BOOL __stdcall MDM_ModeIsNotSerial(HCARD handleval);
MDMW32API BOOL __stdcall MDM_ModeIsRT(HCARD handleval);
MDMW32API BOOL __stdcall MDM_ModeIsSerial(HCARD handleval);
MDMW32API USHORT __stdcall MDM_ModeRd(HCARD handleval);
MDMW32API VOID __stdcall MDM_ModeWr(USHORT mode,HCARD handleval);
MDMW32API ULONG __stdcall MDM_Mul(ULONG mula,ULONG mulb);
MDMW32API USHORT __stdcall MDM_PortRd(USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_PortWr(USHORT value,USHORT addrval,HCARD handleval);
MDMW32API USHORT __stdcall MDM_ProgRdW(USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_ProgWrW(USHORT value,USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_RAMFill(USHORT value,ULONG addrval,ULONG countval,HCARD handleval);
MDMW32API USHORT __stdcall MDM_RAMRdB(ULONG addrval,HCARD handleval);
MDMW32API ULONG __stdcall MDM_RAMRdL(ULONG addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_RAMRdsW(LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
MDMW32API VOID __stdcall MDM_RAMRdsxW(LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
MDMW32API USHORT __stdcall MDM_RAMRdW(ULONG addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_RAMWipe(HCARD handleval);
MDMW32API VOID __stdcall MDM_RAMWipeEx(USHORT value,HCARD handleval);
MDMW32API VOID __stdcall MDM_RAMWrB(USHORT value,ULONG addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_RAMWrL(ULONG value,ULONG addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_RAMWrsW(LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
MDMW32API VOID __stdcall MDM_RAMWrsxW(LPUSHORT valueptr,ULONG addrval,USHORT countval,HCARD handleval);
MDMW32API VOID __stdcall MDM_RAMWrW(USHORT value,ULONG addrval,HCARD handleval);
MDMW32API USHORT __stdcall MDM_SARRdW(USHORT addrval,HCARD handleval);
MDMW32API VOID __stdcall MDM_SARWrW(USHORT value,USHORT addrval,HCARD handleval);
MDMW32API ULONG __stdcall MDM_Shl(ULONG dataval,USHORT cntval);
MDMW32API ULONG __stdcall MDM_Shr(ULONG dataval,USHORT cntval);
MDMW32API INT __stdcall MDM_ValAsciiCmpi(LPSTR str1,LPSTR str2);
MDMW32API LPSTR __stdcall MDM_ValAsciiCpy(LPSTR strdest,LPCSTR strsrc,INT count);
MDMW32API VOID __stdcall MDM_ValAsciiTrimLead(LPSTR buf);
MDMW32API VOID __stdcall MDM_ValAsciiTrimTrail(LPSTR buf);
MDMW32API ULONG __stdcall MDM_ValFromAscii(LPCSTR asciistr,INT radixval);
MDMW32API USHORT __stdcall MDM_ValGetBits(USHORT oldvalue,INT startbit,INT endbit);
MDMW32API LPSTR __stdcall MDM_ValIncAscii(LPSTR asciistr);
MDMW32API LPSTR __stdcall MDM_ValInccAscii(LPSTR asciistr);
MDMW32API BOOL __stdcall MDM_ValIsLower(INT value);
MDMW32API INT __stdcall MDM_ValLenAscii(INT numbits,INT radixval);
MDMW32API USHORT __stdcall MDM_ValPackCWD(INT TAval,INT TRval,INT SAval,INT WCval);
MDMW32API USHORT __stdcall MDM_ValPackRTCWD(INT subaddr,INT trbit,INT mcflag,INT bcastflag,INT count);
MDMW32API USHORT __stdcall MDM_ValPutBits(USHORT oldvalue,USHORT newfld,INT startbit,INT endbit);
MDMW32API LPSTR __stdcall MDM_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
MDMW32API INT __stdcall MDM_ValToUpper(INT value);
MDMW32API VOID __stdcall MDM_ValUnpackCWD(USHORT CWDval,LPINT TAval,LPINT TRval,LPINT SAval,LPINT WCval);
MDMW32API VOID __stdcall MDM_ValUnpackRTCWD(USHORT cwd,LPINT subaddr,LPINT trbit,LPINT mcflag,LPINT bcastflag,LPINT count);
MDMW32API USHORT __stdcall P12_Bitset(USHORT wordval,INT bitvalue,INT bitnum);
MDMW32API BOOL __stdcall P12_Bittest(USHORT wordval,INT bitnum);
MDMW32API ERRVAL __stdcall P12_Checklist(INT fh);
MDMW32API VOID __stdcall P12_Clearlist(INT fh);
MDMW32API VOID __stdcall P12_Config(INT reg0,INT reg1,INT reg2,HCARD handleval);
MDMW32API ERRVAL __stdcall P12_Execconfig(LPCSTR nameptr,INT fh,HCARD handleval);
MDMW32API ERRVAL __stdcall P12_Execmsg(LPCSTR nameptr,LPVOID bufptr,LPUSHORT swdptr,INT fh,HCARD handleval);
MDMW32API ERRVAL __stdcall P12_Execute(LPCSTR nameptr,LPUSHORT swdptr,LPVOID dwdptr,INT fh,HCARD handleval);
MDMW32API VOID __stdcall P12_Freedrv(VOID);
MDMW32API INT __stdcall P12_In(INT addrval,HCARD handleval);
MDMW32API INT __stdcall P12_Loadlist(LPCSTR filename);
MDMW32API ERRVAL __stdcall P12_Locate(INT keytype,LPCSTR nameptr,INT fh);
MDMW32API USHORT __stdcall P12_Maskshift(USHORT inputval,INT startbit,INT lengthval);
MDMW32API VOID __stdcall P12_Out(INT dataval,INT addrval,HCARD handleval);
MDMW32API USHORT __stdcall P12_Packcwd(INT TAval,INT TRval,INT SAval,INT WCval);
MDMW32API USHORT __stdcall P12_Packwd(USHORT inputval,USHORT oldval,INT startbit,INT lengthval);
MDMW32API INT __stdcall P12_Readb(INT fh);
MDMW32API VOID __stdcall P12_Readbcdwd(INT countval,INT startval,LPVOID destptr,HCARD handleval);
MDMW32API INT __stdcall P12_Readresp(HCARD handleval);
MDMW32API VOID __stdcall P12_Readrtdwd(INT TRval,INT SAval,INT countval,INT startval,LPVOID destptr,HCARD handleval);
MDMW32API INT __stdcall P12_Readw(INT fh);
MDMW32API INT __stdcall P12_Readwd(INT offset,HCARD handleval);
MDMW32API VOID __stdcall P12_Readwds(INT offval,LPVOID destptr,INT cntval,HCARD handleval);
MDMW32API INT __stdcall P12_Transmit(HCARD handleval);
MDMW32API VOID __stdcall P12_Writebcdwd(INT countval,INT startval,LPVOID srcptr,HCARD handleval);
MDMW32API VOID __stdcall P12_Writertdwd(INT TRval,INT SAval,INT countval,INT startval,LPVOID srcptr,HCARD handleval);
MDMW32API VOID __stdcall P12_Writewd(INT value,INT offset,HCARD handleval);
MDMW32API VOID __stdcall P12_Writewds(INT offval,LPVOID srcptr,INT cntval,HCARD handleval);

#ifdef __cplusplus
}
#endif

/**
*
*  Bits in status
*
**/

#define STATUS_DONE			0x01		//Set when board is done processing
#define STATUS_ERROR		0x02		//Set when error encountered in last message
#define STATUS_DIS			0x04		//State of discrete on/off
#define STATUS_RT			0x08		//Set if in RT mode, clear if in BC mode
#define STATUS_XMT			0x10		//Set if last message was transmit
#define STATUS_INTI			0x80		//Interrupt latch

/**
*
*  Bits in message error result
*
**/

#define ERROR_ERR			0x8000		//OR of the following error bits
#define ERROR_ERRSER		0x4000		//Set when the wrong sync is received
#define ERROR_ERRIER		0x2000		//Set when an incomplete word is received
#define ERROR_ERRMAN		0x1000		//Set when a manchester error is received
#define ERROR_ERRPER		0x0800		//Set when a parity error is received
#define ERROR_ERRIVWT		0x0400		//Set when invalid word timing is encountered
#define ERROR_ERRERR		0x0200		//Set when another error is encountered
#define ERROR_NOENCRDY		0x0100		//Set when the encoder is never ready
#define ERROR_NOWR			0x0080		//Set when no word is received
#define ERROR_NOWDIS		0x0040		//Set when no word discrete is received
#define ERROR_NOLIFE		0x0020		//Set when the card has no life
#define ERROR_WRAP			0x0010		//Set when the wrap around fails
#define ERROR_COUNT			0x0008		//Set when the word count is out of range
#define ERROR_HIT			0x0001		//Always set after any command is processed

/**
*
*  Values to use for the transmit/receive parameter of MDM_Go().
*
**/

#define TRANSMIT 1						//BC -> RT
#define RECEIVE  0						//BC <- RT

/**
*
*  Info types
*
**/

#define INFOTYPE_PLAT      0x0001           //Returns the PC-MDM-1 platform type
#define INFOTYPE_PROD      0x0002           //Returns the PC-MDM-1 product type
#define INFOTYPE_DASH      0x0003           //Returns the PC-MDM-1 dash number
#define INFOTYPE_VERSION   0x0004           //Returns the PC-MDM-1 version number
#define INFOTYPE_DATE      0x0005           //Returns the PC-MDM-1 version date
#define INFOTYPE_MODEL     0x0006           //Returns the PC-MDM-1 model number
#define INFOTYPE_MAXCOUNT  0x0007           //Returns the number of terminals the PC-MDM-1 can simulate
#define INFOTYPE_MULTIMODE 0x0008           //Returns whether PC-MDM-1 can simulate multi-modes
#define INFOTYPE_ERRORGEN  0x0009           //Returns whether PC-MDM-1 can generate errors
#define INFOTYPE_CONCURMON 0x000A           //Returns whether PC-MDM-1 has a concurrent monitor
#define INFOTYPE_MONFILTER 0x000B           //Returns whether PC-MDM-1 has a monitor filter
#define INFOTYPE_USERCODE  0x000C           //Returns whether PC-MDM-1 handles user code
#define INFOTYPE_LISTBUF   0x000D           //Returns whether PC-MDM-1 handles list buffering
#define INFOTYPE_MONFAST   0x000E           //Returns whether PC-MDM-1 has a fast monitor
#define INFOTYPE_MONDMA    0x000F           //Returns whether PC-MDM-1 has a dma monitor

/**
*
*  PC-MDM-1 Host Registers
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
*  PC-MDM-1 Host Indirect Registers
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

#define EREG_STAT    0x2C80                 //Status register (RD)
#define EREG_STATCLR 0x2C81                 //Status clear register (WR)
#define EREG_MODE    0x2C82                 //Mode register (RD)
#define EREG_ERRD    0x2C82                 //Decoder error register (RD)
#define EREG_VALD    0x2C84                 //Decoder word value register (RD)
#define EREG_EXTRA   0x2C86                 //Extra register (RD)
#define EREG_CTRL    0x2C89                 //Control register
#define EREG_VALE    0x2C8A                 //Encoder value register
#define EREG_ERRE    0x2C8C                 //Encoder error register
#define EREG_FT      0x2C8E                 //Frame time register
#define EREG_RST     0x2C8F                 //Reset register
#define EREG_DT1     0x2C90                 //Discrete time register 1
#define EREG_DT2     0x2C91                 //Discrete time register 2
#define EREG_DT3     0x2C92                 //Discrete time register 3
#define EREG_CFG     0x2C94                 //Decoder configuration register
#define EREG_CFGINT  0x2C96                 //Interrupt configuration register
#define EREG_ID      0x2C97                 //Identification register

/**
*
*  Self-test levels.
*
**/

#define TEST_LEVEL_0 0                      //Test I/O interface
#define TEST_LEVEL_1 1                      //Test memory interface
#define TEST_LEVEL_2 2                      //Test communication process

/**
*
*  Error return values.
*
**/

#define ERR_NONE          0                 //No error
#define ERR_UNKNOWN      -1                 //An unexpected error occurred
#define ERR_BADVER       -2                 //A bad version was encountered
#define ERR_BADPARAMS    -11                //CardOpen() called with bad parameters
#define ERR_NOHANDLES    -12                //CardOpen() already has allocated too many handles
#define ERR_NOCARD       -13                //CardOpen() could not find a PC-MDM-1 card at the specified address
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
