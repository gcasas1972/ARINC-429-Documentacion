/**
*
*  PC-SSB-1 WIN32 DRIVER  Version 1.0  (12/31/1999)
*  Copyright (c) 1999
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:  PS1W32.H -- Visual C++ and Borland C++ 32-bit
*                     PC-SSB-1 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the
*  Microsoft C and Borland C Driver Library for the
*  PC-SSB-1.  Applications using the PC-SSB-1 Driver Library
*  must incorporate this include file using the
*  preprocessor directive #include.  If this file is in the
*  current working directory, the form would be:
*
*  #include "PS1W32.H"
*
*  Refer to the Visual C++ or Borland C++ manual for
*  more information on header files.
*
**/

/**
*
*  Conditional block to prevent multiple defines.
*
**/

#ifndef __PS1W32_H
#define __PS1W32_H

/**
*
*  Typedefs used by the PC-SSB-1 Driver.
*
**/

#ifndef PS1W32API
#ifdef __BORLANDC__
#define PS1W32API
#else
#define PS1W32API __declspec(dllimport)
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
*  "C" block if compiling a C++ file.
*
**/

#ifdef __cplusplus
extern "C" {
#endif

/**
*
*  PC-SSB-1 Driver functions.
*
**/

PS1W32API ERRVAL __stdcall SSBT_CardClose(HCARD handleval);
PS1W32API HCARD __stdcall SSBT_CardOpen(INT memval,INT ioval,INT irqval);

PS1W32API LPSTR __stdcall SSBT_AsciiCat(LPSTR strdest,LPCSTR strsrc);
PS1W32API INT __stdcall SSBT_AsciiCmpi(LPSTR str1,LPSTR str2);
PS1W32API LPSTR __stdcall SSBT_AsciiCpy(LPSTR strdest,LPCSTR strsrc);
PS1W32API INT __stdcall SSBT_AsciiFromNibble(CHAR ch);
PS1W32API LPSTR __stdcall SSBT_AsciiFromVal(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
PS1W32API LPSTR __stdcall SSBT_AsciiInc(LPSTR asciistr);
PS1W32API LPSTR __stdcall SSBT_AsciiIncc(LPSTR asciistr);
PS1W32API BOOL __stdcall SSBT_AsciiIsLower(INT value);
PS1W32API BOOL __stdcall SSBT_AsciiIsRadix(LPCSTR asciistr,INT radixval);
PS1W32API INT __stdcall SSBT_AsciiLenVal(INT numbits,INT radixval);
PS1W32API INT __stdcall SSBT_AsciiToUpper(INT value);
PS1W32API ULONG __stdcall SSBT_AsciiToVal(LPCSTR asciistr,INT radixval);
PS1W32API VOID __stdcall SSBT_AsciiTrimLead(LPSTR buf);
PS1W32API VOID __stdcall SSBT_AsciiTrimTrail(LPSTR buf);
PS1W32API VOID __stdcall SSBT_AsciiTrimZero(LPSTR buf);
PS1W32API ERRVAL __stdcall SSBT_CardCloseAll(VOID);
PS1W32API ERRVAL __stdcall SSBT_CardGetParam(LPSTR cardstr,LPUSHORT memval,LPUSHORT ioval,LPUSHORT irqval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_CardInit(VOID);
PS1W32API HCARD __stdcall SSBT_CardOpenEx(LPCSTR cardname,INT memval,INT ioval,INT irqval);
PS1W32API HCARD __stdcall SSBT_CardOpenExx(LPCSTR cardname,INT memval,INT ioval,INT irqval,LPVOID hAppWnd,USHORT uiRemovalMsg);
PS1W32API ERRVAL __stdcall SSBT_Check(HCARD handleval);
PS1W32API VOID __stdcall SSBT_ClrInt(HCARD handleval);
PS1W32API BYTE __stdcall SSBT_Config(BYTE regval,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_ConfigInt(BYTE regval,LPVOID newhandler,HCARD handleval);
PS1W32API ULONG __stdcall SSBT_Div(ULONG diva,ULONG divb);
PS1W32API LPCSTR __stdcall SSBT_ErrDesc(INT errval);
PS1W32API LPCSTR __stdcall SSBT_ErrDescStr(INT errval);
PS1W32API LPCSTR __stdcall SSBT_ErrName(INT errval);
PS1W32API USHORT __stdcall SSBT_GetHigh(ULONG val);
PS1W32API USHORT __stdcall SSBT_GetLow(ULONG val);
PS1W32API USHORT __stdcall SSBT_GetOff(LPVOID valptr);
PS1W32API USHORT __stdcall SSBT_GetSeg(LPVOID valptr);
PS1W32API ERRVAL __stdcall SSBT_HandleClose(HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_HandleDel(HCARD handleval);
PS1W32API HCARD __stdcall SSBT_HandleIns(LPCSTR cardname,INT memval,INT ioval,INT irqval,LPVOID hAppWnd,USHORT uiRemovalMsg);
PS1W32API BOOL __stdcall SSBT_HandleOkay(HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_HandleOpen(LPCSTR cardname,INT memval,INT ioval,INT irqval,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_HandleVer(HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_IntInstall(LPVOID hEvent,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_IntUninstall(HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernBegin(LPVOID *vxdptr,LPSTR cardstr,INT memval,INT ioval,INT irqval,LPCSTR cardname);
PS1W32API ERRVAL __stdcall SSBT_KernEnd(LPVOID vxdptr);
PS1W32API ERRVAL __stdcall SSBT_KernIntClear(HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernIntInstall(LPVOID hEvent,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernIntParam(ULONG clraddr,ULONG clrwidth,ULONG clrvalue,ULONG stataddr,ULONG statwidth,ULONG statvalue,ULONG statmask,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernIntStatus(LPINT valueptr,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernIntUninstall(HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernIORdB(LPBYTE valueptr,ULONG addrval,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernIOWrB(BYTE value,ULONG addrval,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMCopyB(LPVOID destptr,LPVOID srcptr,USHORT countval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMFillW(USHORT value,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMRdB(LPBYTE valueptr,ULONG addrval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMRdL(LPULONG valueptr,ULONG addrval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMRdsB(LPBYTE bufptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMRdsL(LPULONG bufptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMRdsW(LPUSHORT bufptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMRdW(LPUSHORT valueptr,ULONG addrval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMWrB(BYTE value,ULONG addrval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMWrL(ULONG value,ULONG addrval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMWrsB(LPBYTE bufptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMWrsL(LPULONG bufptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMWrsW(LPUSHORT bufptr,ULONG addrval,ULONG countval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernMEMWrW(USHORT value,ULONG addrval,INT bustype,HCARD handleval);
PS1W32API ERRVAL __stdcall SSBT_KernStatus(LPULONG valueptr,ULONG type,ULONG index,HCARD handleval);
PS1W32API ULONG __stdcall SSBT_MakeLong(USHORT valh,USHORT vall);
PS1W32API LPVOID __stdcall SSBT_MakePtr(USHORT valh,USHORT vall);
PS1W32API ULONG __stdcall SSBT_Mask(ULONG dataval,USHORT cntval);
PS1W32API VOID __stdcall SSBT_MemRdS(LPVOID bufptr,USHORT offval,USHORT cntval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_MemWrS(LPVOID bufptr,USHORT offval,USHORT cntval,HCARD handleval);
PS1W32API ULONG __stdcall SSBT_Mod(ULONG moda,ULONG modb);
PS1W32API VOID __stdcall SSBT_MonMemRdS(LPVOID bufptr,USHORT offval,USHORT cntval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_MonMemWrS(LPVOID bufptr,USHORT offval,USHORT cntval,HCARD handleval);
PS1W32API USHORT __stdcall SSBT_MonMsg(LPULONG dwdptr,HCARD handleval);
PS1W32API ULONG __stdcall SSBT_Mul(ULONG mula,ULONG mulb);
PS1W32API BYTE __stdcall SSBT_PortRd(INT addrval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_PortWr(BYTE value,INT addrval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_RamRdS(LPVOID bufptr,USHORT offval,USHORT cntval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_RamWrS(LPVOID bufptr,USHORT offval,USHORT cntval,HCARD handleval);
PS1W32API BYTE __stdcall SSBT_RcMsg(ULONG cmdval,LPULONG dwdptr,USHORT wcval,USHORT blkval,HCARD handleval);
PS1W32API USHORT __stdcall SSBT_RdAWC(HCARD handleval);
PS1W32API ULONG __stdcall SSBT_RdCwd(USHORT blkval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_RdDwd(LPULONG dwdptr,USHORT wcval,USHORT blkval,HCARD handleval);
PS1W32API USHORT __stdcall SSBT_RdMWC(HCARD handleval);
PS1W32API BYTE __stdcall SSBT_RdRegAccess(HCARD handleval);
PS1W32API BYTE __stdcall SSBT_RdStatReg(HCARD handleval);
PS1W32API VOID __stdcall SSBT_Reset(HCARD handleval);
PS1W32API VOID __stdcall SSBT_ResetMon(HCARD handleval);
PS1W32API VOID __stdcall SSBT_SelMonMem(BOOL regval,HCARD handleval);
PS1W32API ULONG __stdcall SSBT_Shl(ULONG dataval,USHORT cntval);
PS1W32API ULONG __stdcall SSBT_Shr(ULONG dataval,USHORT cntval);
PS1W32API BYTE __stdcall SSBT_Trigger(HCARD handleval);
PS1W32API BYTE __stdcall SSBT_TxMsg(ULONG cmdval,LPULONG dwdptr,USHORT wcval,USHORT blkval,HCARD handleval);
PS1W32API ULONG __stdcall SSBT_ValFromAscii(LPCSTR asciistr,INT radixval);
PS1W32API LPSTR __stdcall SSBT_ValToAscii(ULONG value,LPSTR asciistr,INT numbits,INT radixval);
PS1W32API VOID __stdcall SSBT_VerStr(LPSTR strptr,INT cntval);
PS1W32API BYTE __stdcall SSBT_WrCtrlReg(BOOL trval,USHORT wcval,USHORT blkval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_WrCwd(ULONG cmdval,USHORT blkval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_WrDwd(LPULONG dwdptr,USHORT wcval,USHORT blkval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_WrRegAccess(BYTE regval,HCARD handleval);
PS1W32API VOID __stdcall SSBT_WrRegAddr(BYTE regval,HCARD handleval);

#ifdef __cplusplus
}
#endif

/**
*
*  PC-SSB-1 Driver predefined constants.
*
**/

#define SSBT_WINDOW_SIZE 0x1000     //Size in bytes of memory window

#define SSBT_DFLT_ADDR 0xCC00       //Factory default segment address
#define SSBT_DFLT_PORT 0x2C0        //Factory default port address
#define SSBT_DFLT_IRQ  2            //Factory default interrupt request

#define REG_CTRL0  0x00             //Port address offset of Control Register 0
#define REG_CTRL1  0x01             //Port address offset of Control Register 1
#define REG_CTRL2  0x02             //Port address offset of Control Register 2
#define REG_CTRL3  0x03             //Port address offset of Control Register 3
#define REG_TRIG   0x04             //Port address offset of Trigger Register
#define REG_CLRINT 0x05             //Port address offset of Clear Interrupt Register
#define REG_ADDR   0x06             //Port address offset of Address Register
#define REG_ACCESS 0x07             //Port address offset of Access Register

#define REG_STAT0 0x00              //Port address offset of Status Register 0
#define REG_STAT2 0x02              //Port address offset of Status Register 2
#define REG_STAT3 0x03              //Port address offset of Status Register 3
#define REG_STAT4 0x04              //Port address offset of Status Register 4
#define REG_STAT5 0x05              //Port address offset of Status Register 5

#define IREG_CTRL0 0x00             //Address of Internal Control Register 0
#define IREG_CTRL1 0x01             //Address of Internal Control Register 1
#define IREG_CTRL2 0x02             //Address of Internal Control Register 2
#define IREG_CTRL3 0x03             //Address of Internal Control Register 3
#define IREG_CTRL4 0x04             //Address of Internal Control Register 4

/**
*
*  The following predefined constants identify the
*  values of the bit positions of Control Register 0.
*
**/

#define BCMODE  0x00                //Enables BC mode
#define RTMODE  0x10                //Enables RT mode
#define SIMMODE 0x20                //Enables simulate mode (BC only)
#define MONMODE 0x40                //Monitor mode
#define XTRIGEN 0x08                //Enables external trigger
#define INTEN   0x04                //Enables interrupt to host
#define RC0BUS  0x00                //Selects receive bus 0
#define RC1BUS  0x02                //Selects receive bus 1
#define TX0BUS  0x00                //Selects transmit bus 0
#define TX1BUS  0x01                //Selects transmit bus 1

/**
*
*  The following predefined constants identify the
*  values of the bit positions of Control Register 1.
*
**/

#define XMITMSG 0x80                //Transmit message
#define RCVMSG  0x00                //Receive message

/**
*
*  The following predefined constants identify the
*  values of the bit positions of Control Register 3.
*
**/

#define CTRL3_RESET   0x80          //Resets board
#define CTRL3_MRST    0x02          //Resets monitor
#define CTRL3_MONMEM  0x01          //Selects monitor memory
#define CTRL3_TERMMEM 0x00          //Selects terminal memory

/**
*
*  The following predefined constants identify the
*  values of the bit positions of Status Register 0.
*
**/

#define STAT0_INTI   0x80           //INTI bit
#define STAT0_MMEM   0x40           //Set if monitor memory selected
#define STAT0_MFULL  0x20           //Set if monitor is full
#define STAT0_MACT   0x10           //Set if monitor is active and not full
#define STAT0_NORESP 0x08           //Set if no response error
#define STAT0_WCERR  0x04           //Set if word count error
#define STAT0_ERROR  0x02           //Set if error
#define STAT0_DONE   0x01           //Set if done

/**
*
*  The following predefined constants identify the values
*  of the bit positions of the Monitor Attribute Byte.
*
**/

#define ATTR_RBUS  0x08             //Which bus received from
#define ATTR_PGAP  0x04             //Set if preceeding gap
#define ATTR_RSYNC 0x02             //Set if command sync
#define ATTR_WERR  0x01             //Set if word error

/**
*
*  The following predefined constants identify the error
*  return values.
*
**/

#define ERR_NONE          0         //No error
#define ERR_UNKNOWN      -1         //An unexpected error occurred
#define ERR_CHKREG3      -2         //Did not find zeros in bits 2-7 of Status Register 3
#define ERR_CHKREG5      -3         //Did not find zeros in bits 2-7 of Status Register 5
#define ERR_CHKREG01     -4         //While toggling MMEM bit in Status Register 0, read 1, expected 0
#define ERR_CHKREG02     -5         //While toggling MMEM bit in Status Register 0, read 0, expected 1
#define ERR_CHKREG03     -6         //While toggling MMEM bit in Status Register 0, read 1, expected 0
#define ERR_CHKTERM      -7         //Terminal memory contains unstable data
#define ERR_CHKMON       -8         //Monitor memory contains unstable data
#define ERR_CHKMEMWR     -9         //Cannot write to the terminal memory
#define ERR_CHKTERMWR    -10        //Trial value written to terminal memory disappeared
#define ERR_CHKMONWR     -11        //Trial value written to monitor memory disappeared
#define ERR_BADVER       -20        //A bad version was encountered
#define ERR_BADPARAMS    -21        //CardOpen() called with bad parameters
#define ERR_NOHANDLES    -22        //CardOpen() already has allocated too many handles
#define ERR_NOCARD       -23        //CardOpen() could not find a PS-SSB-1 card at the specified address
#define ERR_NOIO         -24        //CardOpen() could not find the I/O ports
#define ERR_NOMEM        -25        //CardOpen() could not find the memory
#define ERR_BAD16BIT     -26        //Card is conflicting with another 16-bit card
#define ERR_NOSEL        -27        //CardOpen() could not allocate a memory selector
#define ERR_BADHANDLE    -28        //A bad handle was specified
#define ERR_VXD          -29        //An error occurred in the VXD

#endif
