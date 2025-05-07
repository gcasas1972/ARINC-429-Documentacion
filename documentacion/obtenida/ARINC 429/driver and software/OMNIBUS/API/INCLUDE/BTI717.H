/**
*
*  BTI717 WIN32 DRIVER  Version 1.8.2  (10/05/2010)
*  Copyright (c) 2001-2010
*  Ballard Technology, Inc.
*  www.ballardtech.com
*  support@ballardtech.com
*  ALL RIGHTS RESERVED
*
*  NAME:   BTI717.H -- Visual C++ 32-bit
*                      BTI717 Driver Include Header File.
*
**/

/**
*
*  This file defines the procedures provided by the Visual
*  C++ 32-bit Driver Library for Ballard Technology ARINC 717
*  cards.  Applications using the BTI717 Driver Library must
*  incorporate this include file using the preprocessor
*  directive #include. If this file is in the current working
*  directory, the form would be:
*
*  #include "BTI717.H"
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

#ifndef __BTI717_H
#define __BTI717_H

/**
*
*  Pragma to specify link library.
*
**/

#ifdef __BORLANDC__
#pragma comment(lib,"bti717bc.lib")
#else
#if defined(_WIN32)
#if defined(_WIN64)
#pragma comment(lib,"bti71764.lib")
#else
#pragma comment(lib,"bti717.lib")
#endif
#endif
#endif

/**
*
*  Typedefs used by the BTI717 Driver.
*
**/

#ifndef BTI717API
#ifdef __BORLANDC__
#define BTI717API
#else
#define BTI717API __declspec(dllimport)
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

#ifndef SUBFRMADDR
typedef unsigned long SUBFRMADDR;
#endif

#ifndef SUPERFRMADDR
typedef unsigned long SUPERFRMADDR;
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
*  Structs used by the BTI717 Driver.
*
**/

#ifndef SUBFRMFIELDS717

typedef struct
{
    USHORT subfrmopt;           //Driver writes message options
    USHORT subfrmact;           //Card writes message activity
    USHORT subfrmnum;           //Card writes subframe number
    USHORT subfrmwps;           //Card writes WPS
    union {
        ULONG  timestamp;       //Card writes timestamp
        ULONG  hitcount;        //Card writes hit count
    };
    ULONG  spfptr;              //Card writes superframe pointer
    USHORT data[8192];          //Card/User writes subframe data. Valid from 0 -> WPS-1. (Rcv/Xmt)
    ULONG  timestamph;          //Card writes extended timestamp
    USHORT extflag;             //Driver writes external trigger/sync control flags
    USHORT rsvd[13];            //Reserved
} SUBFRMFIELDS717;

#endif

#ifndef LPSUBFRMFIELDS717
typedef SUBFRMFIELDS717 * LPSUBFRMFIELDS717;
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
*  BTI717 Driver functions.
*
**/

BTI717API ERRVAL __stdcall BTI717_ChClear(INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_ChConfig(ULONG configval,INT channum,HCORE handleval);
BTI717API VOID __stdcall BTI717_ChGetCount(LPINT rcvcount,LPINT xmtcount,HCORE handleval);
BTI717API ULONG __stdcall BTI717_ChGetInfo(USHORT infotype,INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_ChIs717(INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_ChIsBiPhase(INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_ChIsRcv(INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_ChIsSelEnc(INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_ChIsType(ULONG configval,INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_ChIsXmt(INT channum,HCORE handleval);
BTI717API VOID __stdcall BTI717_ChPause(INT channum,HCORE handleval);
BTI717API INT __stdcall BTI717_ChPauseCheck(INT channum,HCORE handleval);
BTI717API VOID __stdcall BTI717_ChResume(INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_ChStart(INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_ChStatus(LPUSHORT buf,INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_ChStop(INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_ChSyncDefine(BOOL enableflag,USHORT syncmask,USHORT pinpolarity,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_ChTriggerDefine(BOOL enableflag,USHORT trigmask,USHORT trigval,USHORT pinpolarity,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_ParamAmplitudeConfig(ULONG configval,USHORT dacval,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_ParamAmplitudeGet(LPUSHORT dacval,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmBlkRd(LPUSHORT databuf,INT subframe,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmBlkWr(LPUSHORT databuf,INT subframe,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmStatus(LPUSHORT buf,INT subframe,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmSyncDefine(BOOL enableflag,USHORT syncmask,USHORT pinpolarity,INT subframe,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmTriggerDefine(BOOL enableflag,USHORT trigmask,USHORT trigval,USHORT pinpolarity,INT subframe,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmWordConfig(ULONG configval,INT subframe,INT word,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmWordRd(LPUSHORT value,INT subframe,INT word,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmWordWr(USHORT value,INT subframe,INT word,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SuperFrmConfig(INT count,INT framespersuperframe,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SuperFrmCounterPos(INT subframe,INT word,INT channum,HCORE handleval);
BTI717API SUPERFRMADDR __stdcall BTI717_SuperFrmDefine(INT subframe,INT word,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SuperFrmWordConfig(ULONG configval,INT superfrmnum,SUPERFRMADDR superfrmaddr,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SuperFrmWordRd(LPUSHORT value,INT superfrmnum,SUPERFRMADDR superfrmaddr,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SuperFrmWordWr(USHORT value,INT superfrmnum,SUPERFRMADDR superfrmaddr,INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_SyncTest(INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SyncValRd(LPINT syncword1,LPINT syncword2,LPINT syncword3,LPINT syncword4,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SyncValWr(INT syncword1,INT syncword2,INT syncword3,INT syncword4,INT channum,HCORE handleval);

/**
*
*  Internal functions used by the BTI717 Driver.
*
**/

BTI717API BASEADDR __stdcall BTI717_ChCreate(INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_ChReset(INT channum,HCORE handleval);
BTI717API INT __stdcall BTI717_DllUsageCount(VOID);
BTI717API VOID __stdcall BTI717_GetChanCount(LPINT rcvcount,LPINT xmtcount,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_HookMsgProc(INT msgval,LPVOID lpParam,HCORE handleval);
BTI717API BOOL __stdcall BTI717_IsBiPhaseChan(INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_IsChan(INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_IsRcvChan(INT channum,HCORE handleval);
BTI717API BOOL __stdcall BTI717_IsXmtChan(INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_ProcSetPost(ULONG useraddr,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_ProcSetPre(ULONG useraddr,INT channum,HCORE handleval);
BTI717API SUBFRMADDR __stdcall BTI717_SubFrmAddr(INT subframe,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmBlkRdEx(LPSUBFRMFIELDS717 subfrmdata,INT subframe,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmBlkWrEx(LPSUBFRMFIELDS717 subfrmdata,INT subframe,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmCreate(ULONG configval,INT subframe,BASEADDR chanbase,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SubFrmReset(INT subframe,INT channum,HCORE handleval);
BTI717API BASEADDR __stdcall BTI717_SuperFrmBaseAddr(INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SuperFrmConfigEx(ULONG configval,INT count,INT framespersuperframe,INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SuperFrmReset(INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_SyncValPtrInit(INT channum,HCORE handleval);
BTI717API ERRVAL __stdcall BTI717_TestProtocol(HCORE handleval);

#ifdef __cplusplus
}
#endif

/**
*
*  Channel number constants
*
**/

#define CH0  0x0000          //Channel 0
#define	CH1  0x0001          //Channel 1
#define	CH2  0x0002          //Channel 2
#define	CH3  0x0003          //Channel 3
#define	CH4  0x0004          //Channel 4
#define	CH5  0x0005          //Channel 5
#define	CH6  0x0006          //Channel 6
#define	CH7  0x0007          //Channel 7
#define	CH8  0x0008          //Channel 8
#define	CH9  0x0009          //Channel 9
#define	CH10 0x000A          //Channel 10
#define	CH11 0x000B          //Channel 11
#define	CH12 0x000C          //Channel 12
#define	CH13 0x000D          //Channel 13
#define	CH14 0x000E          //Channel 14
#define	CH15 0x000F          //Channel 15
#define	CH16 0x0010          //Channel 16
#define	CH17 0x0011          //Channel 17
#define	CH18 0x0012          //Channel 18
#define	CH19 0x0013          //Channel 19
#define	CH20 0x0014          //Channel 20
#define	CH21 0x0015          //Channel 21
#define	CH22 0x0016          //Channel 22
#define	CH23 0x0017          //Channel 23
#define	CH24 0x0018          //Channel 24
#define	CH25 0x0019          //Channel 25
#define	CH26 0x001A          //Channel 26
#define	CH27 0x001B          //Channel 27
#define	CH28 0x001C          //Channel 28
#define	CH29 0x001D          //Channel 29
#define	CH30 0x001E          //Channel 30
#define	CH31 0x001F          //Channel 31

/**
*
*  Subframe constants
*
**/

enum {	SUBFRM1                = 0x0001,          //Sub Frame 1
		SUBFRM2                = 0x0002,          //Sub Frame 2
		SUBFRM3                = 0x0003,          //Sub Frame 3
		SUBFRM4                = 0x0004           //Sub Frame 4
};

/**
*
*  Channel configuration options
*
**/


enum {	CHCFG717_DEFAULT       = 0x00000000L,     //Select all default settings (XMT & RCV) (default)
		CHCFG717_AUTOSPEED     = 0x00000002L,     //Select auto speed detection (RCV)
		CHCFG717_64WPS         = 0x00004000L,     //Select speed of 64WPS (XMT & RCV)
		CHCFG717_128WPS        = 0x00008000L,     //Select speed of 128WPS (XMT & RCV)
		CHCFG717_256WPS        = 0x00000000L,     //Select speed of 256WPS (XMT & RCV) (default)
		CHCFG717_512WPS        = 0x00010000L,     //Select speed of 512WPS (XMT & RCV)
		CHCFG717_1024WPS       = 0x00020000L,     //Select speed of 1024WPS (XMT & RCV)
		CHCFG717_2048WPS       = 0x00040000L,     //Select speed of 2048WPS (XMT & RCV)
		CHCFG717_4096WPS       = 0x02000000L,     //Select speed of 4096WPS (XMT & RCV)
		CHCFG717_8192WPS       = 0x04000000L,     //Select speed of 8192WPS (XMT & RCV)
		CHCFG717_BIPHASERCV    = 0x00000000L,     //Select Bi-Phase decoding for receiver (Bi-Phase or RCV) (default)
		CHCFG717_BIPHASEXMT    = 0x08000000L,     //Select Bi-Phase encoding for transmitter (Bi-Phase or XMT)
		CHCFG717_BIPOLARRCV    = 0x20000000L,     //Select Bi-Polar decoding for receiver (Bi-Polar or RCV)
		CHCFG717_BIPOLARXMT    = 0x60000000L,     //Select Bi-Polar encoding for transmitter (Bi-Polar or XMT)
		CHCFG717_BIPOLARHSPD   = 0x08000000L,     //Select high speed slope for Bi-Polar transmitter (Bi-Polar XMT)
		CHCFG717_SELFTEST      = 0x00000004L,     //Enable internal wraparound (XMT & RCV)
		CHCFG717_SELFTESTOFF   = 0x00000000L,     //Disable internal wraparound (XMT & RCV) (default)
		CHCFG717_SYNC          = 0x00000008L,     //Sync Enable (XMT & RCV)
		CHCFG717_SYNCOFF       = 0x00000000L,     //Disable sync output (XMT & RCV) (default)
		CHCFG717_ACTIVE        = 0x00000000L,     //Enable channel activity (XMT & RCV) (default)
		CHCFG717_INACTIVE      = 0x00000040L,     //Disable channel activity (XMT & RCV)
		CHCFG717_EXTSTART      = 0x00000100L,     //Enable external trigger for first message only (XMT)
		CHCFG717_EXTTRIG       = 0x00000080L,     //Enable external trigger for all messages (XMT)
		CHCFG717_EXTOFF        = 0x00000000L,     //External trigger is enabled on message level (XMT) (default)
		CHCFG717_HIT           = 0x00000200L,     //Hit counter is enabled for all sub frames (XMT & RCV)
		CHCFG717_NOHIT         = 0x00000000L,     //Hit counter is disabled (XMT & RCV) (default)
		CHCFG717_TIMETAG       = 0x00000400L,     //Enable time-tag for all sub frames (XMT & RCV)
		CHCFG717_TIMETAGOFF    = 0x00000000L,     //Time-tag is disabled (XMT & RCV) (default)
		CHCFG717_SEQALL        = 0x00080000L,     //Record entire channel in sequential record (XMT & RCV)
		CHCFG717_SEQSEL        = 0x00000000L,     //Sequential record recording is enabled at word level (XMT & RCV) (default)
		CHCFG717_LOGERR        = 0x00800000L,     //Enable event log on Out of Sync Error (RCV)
		CHCFG717_NOLOGERR      = 0x00000000L,     //No event log on Out of Sync Error (RCV) (default)
		CHCFG717_PAUSE         = 0x01000000L,     //Mark channel as paused (XMT & RCV)
		CHCFG717_UNPAUSE       = 0x00000000L,     //Mark channel as unpaused (XMT & RCV) (default)
		CHCFG717_XMTSLOPELOW   = 0x00000000L,     //Select low speed slope for transmitter (XMT) (default)
		CHCFG717_XMTSLOPEHIGH  = 0x10000000L      //Select high speed slope for transmitter (XMT)
};

/**
*
*  Sub Frame word configuration options
*
**/

enum {	WRDCFG717_DEFAULT      = 0x00000000L,     //Select all default settings
		WRDCFG717_SFLOG        = 0x00000001L,     //Enable subframe event log
		WRDCFG717_SFLOGOFF     = 0x00000000L,     //Disable subframe event log (default)
		WRDCFG717_WRDLOG       = 0x00000002L,     //Enable word event log
		WRDCFG717_WRDLOGOFF    = 0x00000000L,     //Disable word event log (default)
		WRDCFG717_SEQ          = 0x00000004L,     //Enable sequential record
		WRDCFG717_SEQOFF       = 0x00000000L      //Disable sequential record (default)
};

/**
*
*  Parametric configuration options
*
**/

enum {	PARAMCFG717_DEFAULT    = 0x00000000L,     //Select all default settings (default)
		PARAMCFG717_AMPLON     = 0x00000000L,     //Enables parametric amplitude control (default)
		PARAMCFG717_AMPLOFF    = 0x00000001L      //Disables parametric amplitude control
};

/**
*
*  Bit fields of the message activity flag.
*
**/

enum {	MSGACT717_CHMASK       = 0xFF00,          //Channel number mask value
		MSGACT717_CHSHIFT      = 0x0008,          //Channel number shift value
		MSGACT717_SPDMASK      = 0x00E0,          //Current speed mask value
		MSGACT717_64WPS        = 0x0000,          //Current speed is 64   wps
		MSGACT717_128WPS       = 0x0020,          //Current speed is 128  wps
		MSGACT717_256WPS       = 0x0040,          //Current speed is 256  wps
		MSGACT717_512WPS       = 0x0060,          //Current speed is 512  wps
		MSGACT717_1024WPS      = 0x0080,          //Current speed is 1024 wps
		MSGACT717_2048WPS      = 0x00A0,          //Current speed is 2048 wps
		MSGACT717_4096WPS      = 0x00C0,          //Current speed is 4096 wps
		MSGACT717_8192WPS      = 0x00E0,          //Current speed is 8192 wps
		MSGACT717_TO           = 0x0002,          //Time out error bit
		MSGACT717_HIT          = 0x0001           //Always set
};

/**
*
*  Channel info fields.
*
**/

enum {	INFO717_PARAM         = 0x0001           //Channel supports parametric control
};

#endif
