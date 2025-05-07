/**
*
*  BTIDIO WIN32 DRIVER  Version 1.1.2  (03/02/2010)
*  Copyright (c) 2005-2010
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   BTIDIO.H -- Visual C++ 32-bit
*                      BTIDIO Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for Ballard Technology Discrete
*  cards.  Applications using the BTIDIO Driver Library must
*  incorporate this include file using the preprocessor
*  directive #include. If this file is in the current working
*  directory, the form would be:
*
*  #include "BTIDIO.H"
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

#ifndef __BTIDIO_H
#define __BTIDIO_H

/**
*
*  Pragma to specify link library.
*
**/

#ifdef __BORLANDC__
#pragma comment(lib,"btidiobc.lib")
#else
#if defined(_WIN32)
#if defined(_WIN64)
#pragma comment(lib,"btidio64.lib")
#else
#pragma comment(lib,"btidio.lib")
#endif
#endif
#endif

/**
*
*  Typedefs used by the BTIDIO Driver.
*
**/

#ifndef BTIDIOAPI
#ifdef __BORLANDC__
#define BTIDIOAPI
#else
#define BTIDIOAPI __declspec(dllimport)
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
*  BTIDIO Driver functions.
*
**/

BTIDIOAPI ERRVAL __stdcall BTIDIO_BankConfig(ULONG configval,USHORT threshold,USHORT samplerate,INT banknum,HCORE handleval);
BTIDIOAPI VOID __stdcall BTIDIO_BankFaultClr(BYTE mask,INT banknum,HCORE handleval);
BTIDIOAPI BYTE __stdcall BTIDIO_BankFaultRd(INT banknum,HCORE handleval);
BTIDIOAPI BOOL __stdcall BTIDIO_BankIsDIO(INT banknum,HCORE handleval);
BTIDIOAPI BYTE __stdcall BTIDIO_BankRd(INT banknum,HCORE handleval);
BTIDIOAPI BOOL __stdcall BTIDIO_BankStart(INT banknum,HCORE handleval);
BTIDIOAPI BOOL __stdcall BTIDIO_BankStop(INT banknum,HCORE handleval);
BTIDIOAPI ERRVAL __stdcall BTIDIO_BankWr(BYTE value,INT banknum,HCORE handleval);
BTIDIOAPI ERRVAL __stdcall BTIDIO_BankWrMask(BYTE value,BYTE mask,INT banknum,HCORE handleval);
BTIDIOAPI ERRVAL __stdcall BTIDIO_DiscreteConfig(ULONG configval,INT ionum,INT banknum,HCORE handleval);
BTIDIOAPI BOOL __stdcall BTIDIO_DiscreteRd(INT ionum,INT banknum,HCORE handleval);
BTIDIOAPI ERRVAL __stdcall BTIDIO_DiscreteWr(BOOL value,INT ionum,INT banknum,HCORE handleval);

/**
*
*  Internal functions used by the BTIDIO Driver.
*
**/

BTIDIOAPI ERRVAL __stdcall BTIDIO_BankClear(INT banknum,HCORE handleval);
BTIDIOAPI INT __stdcall BTIDIO_BankGetCount(HCORE handleval);
BTIDIOAPI ULONG __stdcall BTIDIO_BankGetInfo(USHORT infotype,INT banknum,HCORE handleval);
BTIDIOAPI USHORT __stdcall BTIDIO_BankGetSampleRate(INT banknum,HCORE handleval);
BTIDIOAPI USHORT __stdcall BTIDIO_BankGetThreshold(INT banknum,HCORE handleval);
BTIDIOAPI USHORT __stdcall BTIDIO_BankSetSampleRate(USHORT samplerate,INT banknum,HCORE handleval);
BTIDIOAPI USHORT __stdcall BTIDIO_BankSetThreshold(USHORT threshold,INT banknum,HCORE handleval);
BTIDIOAPI INT __stdcall BTIDIO_DiscreteGetCount(INT banknum,HCORE handleval);
BTIDIOAPI INT __stdcall BTIDIO_DllUsageCount(VOID);
BTIDIOAPI INT __stdcall BTIDIO_GetBankCount(HCORE handleval);
BTIDIOAPI ERRVAL __stdcall BTIDIO_HookMsgProc(INT msgval,LPVOID lpParam,HCORE handleval);
BTIDIOAPI BOOL __stdcall BTIDIO_IsBank(INT banknum,HCORE handleval);
BTIDIOAPI ERRVAL __stdcall BTIDIO_TestProtocol(HCORE handleval);

#ifdef __cplusplus
}
#endif

/**
*
*  Bank number constants
*
**/

#define BANKA  0x0000           //Bank A
#define BANKB  0x0001           //Bank B
#define BANKC  0x0002           //Bank C
#define BANKD  0x0003           //Bank D

/**
*
*  Bank configuration options
*
**/

enum {
		BANKCFGDIO_DEFAULT       = 0x00000000L,      //Select all default settings (in & out) (default)
		BANKCFGDIO_INPUT         = 0x00000000L,      //Select input mode (in) (default)
		BANKCFGDIO_OUTPUT        = 0x00000001L,      //Select output mode (out)
		BANKCFGDIO_INOUT         = 0x00000002L,      //Select concurrent input and output mode (in & out)
		BANKCFGDIO_SERIES        = 0x00000000L,      //Select series mode (in) (default)
		BANKCFGDIO_SHUNT         = 0x00000004L,      //Select shunt mode (in)
		BANKCFGDIO_POLIN_INVOFF  = 0x00000000L,      //Disable polarity inversion for bank input (in) (default)
		BANKCFGDIO_POLIN_INV     = 0x00000100L,      //Enable polarity inversion for bank input (in)
		BANKCFGDIO_POLOUT_INVOFF = 0x00000000L,      //Disable polarity inversion for bank output (out) (default)
		BANKCFGDIO_POLOUT_INV    = 0x00000200L,      //Enable polarity inversion for bank output (out)
		BANKCFGDIO_ACTIVE        = 0x00000000L,      //Enable bank activity (in & out) (default)
		BANKCFGDIO_INACTIVE      = 0x00000010L,      //Disables bank activity (in & out)
		BANKCFGDIO_SEQSEL        = 0x00000000L,      //Sequential monitoring of selected transitions (in & out) (default)
		BANKCFGDIO_SEQALL        = 0x00000020L,      //Every transition will be recorded in the Sequential Record (in & out)
		BANKCFGDIO_NOLOGFAULT    = 0x00000000L,      //No entry will be made in the Event Log List when an output detects a fault (out) (default)
		BANKCFGDIO_LOGFAULT      = 0x00000040L,      //An entry will be made in the Event Log List when an output detects a fault (out)
		BANKCFGDIO_NOLOGEDGE     = 0x00000000L,      //No entry will be made in the Event Log List when an input detects an edge (in) (default)
		BANKCFGDIO_LOGEDGE       = 0x00000080L,      //An entry will be made in the Event Log List when an input detects an edge (in)
		BANKCFGDIO_LOGALL        = 0x000000C0L       //An entry will be made in the Event Log List when an input detects an edge and when an output detects a fault (in & out)
};

enum {
		THRESHOLDDIO_TTL      = 0x00F0,           //Corresponds to a 1.4V switching threshold (TTL)
		THRESHOLDDIO_CMOS     = 0x01B0,           //Corresponds to a 2.5V switching threshold (CMOS)
		THRESHOLDDIO_1_4V     = 0x00F0,           //Corresponds to a 1.4V switching threshold
		THRESHOLDDIO_2_5V     = 0x01B0,           //Corresponds to a 2.5V switching threshold
		THRESHOLDDIO_5V       = 0x0370,           //Corresponds to a 5V switching threshold
		THRESHOLDDIO_7V       = 0x04D0,           //Corresponds to a 7V switching threshold
		THRESHOLDDIO_12V      = 0x0850,           //Corresponds to a 12V switching threshold
		THRESHOLDDIO_16V      = 0x0B10,           //Corresponds to a 16V switching threshold
		THRESHOLDDIO_10KOHM   = 0x00F0,           //Corresponds to approx. 10kOhm switching threshold (Shunt)
		THRESHOLDDIO_25KOHM   = 0x01B0,           //Corresponds to approx. 25kOhm switching threshold (Shunt)
		THRESHOLDDIO_100KOHM  = 0x0300            //Corresponds to approx. 100kOhm switching threshold (Shunt)
};

enum {
		SAMPLERATEDIO_US      = 0x0000,           //Corresponds to a 1us base sample clock
		SAMPLERATEDIO_MS      = 0x8000            //Corresponds to a 1ms base sample clock
};

/**
*
*  Discrete configuration options
*
**/

enum {
		DISCCFGDIO_DEFAULT       = 0x00000000L,      //Select all default settings (in & out) (default)
		DISCCFGDIO_INPUT         = 0x00000000L,      //Select input mode (in) (default)
		DISCCFGDIO_OUTPUT        = 0x00000001L,      //Select output mode (out)
		DISCCFGDIO_INOUT         = 0x00000002L,      //Select concurrent input and output mode (in & out)
		DISCCFGDIO_POLIN_INVOFF  = 0x00000000L,      //Disable polarity inversion for input (in) (default)
		DISCCFGDIO_POLIN_INV     = 0x00000004L,      //Enable polarity inversion for input (in)
		DISCCFGDIO_POLOUT_INVOFF = 0x00000000L,      //Disable polarity inversion for output (out) (default)
		DISCCFGDIO_POLOUT_INV    = 0x00000008L,      //Enable polarity inversion for output (out)
		DISCCFGDIO_SEQNONE       = 0x00000000L,      //No transitions for this input will be recorded in the Sequential Record (in & out) (default)
		DISCCFGDIO_SEQPOSEDGE    = 0x00000010L,      //Positive transitions for this input will be recorded in the Sequential Record (in & out)
		DISCCFGDIO_SEQNEGEDGE    = 0x00000020L,      //Negative transitions for this input will be recorded in the Sequential Record (in & out)
		DISCCFGDIO_SEQANYEDGE    = 0x00000030L,      //Every transition for this input will be recorded in the Sequential Record (in & out)
		DISCCFGDIO_NOLOGEDGE     = 0x00000000L,      //No transitions for this input will create an entry in the Event Log List (in & out) (default)
		DISCCFGDIO_LOGPOSEDGE    = 0x00000040L,      //Positive transitions for this input will create an entry in the Event Log List (in & out)
		DISCCFGDIO_LOGNEGEDGE    = 0x00000080L,      //Negative transitions for this input will create an entry in the Event Log List (in & out)
		DISCCFGDIO_LOGANYEDGE    = 0x000000C0L,      //Every transition for this input will create an entry in the Event Log List (in & out)
		DISCCFGDIO_NOLOGFAULT    = 0x00000000L,      //No faults for this output will create an entry in the Event Log List (out) (default)
		DISCCFGDIO_LOGFAULT      = 0x00000100L,      //Every fault for this output will create an entry in the Event Log List (out)
		DISCCFGDIO_LOGALL        = 0x000001C0L       //Every transition for this input and every fault for this output will create an entry in the Event Log Lit (in/out)
};

/**
*
*  Bank info fields.
*
**/

enum {	INFODIO_INPUT          = 0x0001,          //Bank is input capable
		INFODIO_OUTPUT         = 0x0002,          //Bank is output capable
		INFODIO_SERIES         = 0x0004,          //Bank is series capable
		INFODIO_SHUNT          = 0x0008           //Bank is shunt capable
};

#endif
