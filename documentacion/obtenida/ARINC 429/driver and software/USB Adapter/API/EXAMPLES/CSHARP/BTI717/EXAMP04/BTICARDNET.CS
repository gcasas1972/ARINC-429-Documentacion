using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class BTICARD
    {
        /**
        *
        *  BTICard WIN32 DRIVER  Version 2.6.4  (01/24/2013)
        *  Copyright (c) 2001-2013
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   BTICardNET.CS -- 32-bit
        *                       BTICard Driver Include Header File.
        *
        **/

        /**
        *
        *  Structs used by the BTICard Driver.
        *
        **/

        [StructLayout(LayoutKind.Sequential)]
        public struct SEQRECORD1553
        {
            public UInt16 typeval;               //Valid in all versions
            public UInt16 count;              //Valid in all versions
            public UInt32 timestamp;          //Valid in all versions
            public UInt16 activity;           //Valid in all versions
            public UInt16 errorval;              //Valid in all versions
            public UInt16 cwd1;               //Valid in all versions
            public UInt16 cwd2;               //Valid in all versions
            public UInt16 swd1;               //Valid in all versions
            public UInt16 swd2;               //Valid in all versions
            public UInt16 datacount;          //Valid in all versions
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
            public UInt16[] data;	//Variable length (don't exceed data[datacount-1])
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SEQRECORDMORE1553
        {
            public UInt32 timestamph;         //Valid if version of baseval record (SEQRECORD1553) >= 1
            public UInt16 resptime1;          //Valid if version of baseval record (SEQRECORD1553) >= 1
            public UInt16 resptime2;          //Valid if version of baseval record (SEQRECORD1553) >= 1
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SEQRECORD429
        {
            public UInt16 typeval;               //Valid in all versions
            public UInt16 count;              //Valid in all versions
            public UInt32 timestamp;          //Valid in all versions
            public UInt16 activity;           //Valid in all versions
            public UInt16 decgap;             //Valid if version >= 1
            public UInt32 data;               //Valid in all versions
            public UInt32 timestamph;         //Valid if version >= 1
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SEQRECORD717
        {
            public UInt16 typeval;               //Valid in all versions
            public UInt16 count;              //Valid in all versions
            public UInt32 timestamp;          //Valid in all versions
            public UInt16 activity;           //Valid in all versions
            public UInt16 wordnum;            //Valid in all versions
            public UInt16 subframe;           //Valid in all versions
            public UInt16 superframe;         //Valid in all versions
            public UInt16 data;               //Valid in all versions
            public UInt16 rsvd9;              //Valid if version >= 1
            public UInt32 timestamph;         //Valid if version >= 1
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SEQRECORD708
        {
            public UInt16 typeval;               //Valid in all versions
            public UInt16 count;              //Valid in all versions
            public UInt32 timestamp;          //Valid in all versions
            public UInt16 activity;           //Valid in all versions
            public UInt16 datacount;          //Valid in all versions
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
            public UInt16[] data;	//Valid in all versions
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public UInt16[] extra;	//Valid if version >= 1
            public UInt16 bitcount;           //Valid if version >= 1
            public UInt16 rsvd123;            //Valid if version >= 1
            public UInt32 timestamph;         //Valid if version >= 1
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SEQRECORDCSDB
        {
            public UInt16 typeval;               //Valid in all versions
            public UInt16 count;              //Valid in all versions
            public UInt32 timestamp;          //Valid in all versions
            public UInt32 timestamph;         //Valid in all versions
            public UInt16 activity;           //Valid in all versions
            public UInt16 datacount;          //Valid in all versions
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public UInt16[] data;	//Valid in all versions
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SEQRECORDDIO
        {
            public UInt16 typeval;               //Valid in all versions
            public UInt16 count;              //Valid in all versions
            public UInt16 bank;               //Valid in all versions
            public UInt16 state;              //Valid in version 0
            public UInt32 timestamp;          //Valid in all versions
            public UInt32 timestamph;         //Valid in all versions
            public UInt16 change;             //Valid in version 1
            public UInt16 value;              //Valid in version 1
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SEQFINDINFO
        {
            public unsafe UInt16* pRecFirst;
            public unsafe UInt16* pRecNext;
            public unsafe UInt16* pRecLast;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BTIIRIGTIME
        {
            public UInt16 days;
            public UInt16 hours;
            public UInt16 min;
            public UInt16 sec;
            public UInt16 msec;
            public UInt16 usec;
        }

        /**
        *
        *  BTICard Driver functions.
        *
        **/

        private static class BTICARD_32
        {
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Add64@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Add64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_AddrDSP@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_AddrDSP(UInt32 addr, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_AddrHost@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_AddrHost(UInt32 addr, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_AsciiToMant@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_AsciiToMant(ref string str, ref UInt32 mant, ref Int32 exp);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_BCDToBin@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_BCDToBin(UInt32 bcdval, Int32 msb, Int32 lsb);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_BinToBCD@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_BinToBCD(UInt32 oldbcdval, UInt32 binval, Int32 msb, Int32 lsb);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_BITConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_BITConfig(UInt32 ctrlflags, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_BITInitiate@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_BITInitiate(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_BITStatusClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_BITStatusClear(UInt32 statval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_BITStatusRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_BITStatusRd(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardClose(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardCloseAll@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardCloseAll();
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardGetInfo@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_CardGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardGetInfoEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardGetInfoEx(ref UInt16 bufmodel, UInt16 bufmodelcount, ref UInt16 buffeature, UInt16 buffeaturecount, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardIsRunning(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardNop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardNop(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardOpen@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardOpen(ref UInt32 lphandle, Int32 cardnum);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardOpenStr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardOpenStr(ref UInt32 lphandle, ref string cardstr);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardProductStr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_CardProductStr(UInt32 handleval);
            public static string BTICard_CardProductStr(UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_CardProductStr(handleval)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardReset(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardResetEx@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardResetEx(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardResume(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardShadow@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardShadow(Int32 shadowval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardStart(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardStop(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardSyncEnable@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardSyncEnable(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardSyncValid@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_CardSyncValid(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardTest(UInt16 level, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTest0@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardTest0(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTest1@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardTest1(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTest2@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardTest2(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTest3@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardTest3(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTrigger@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardTrigger(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTriggerEnable@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardTriggerEnable(Int32 enableflag, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTriggerEnableEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardTriggerEnableEx(Int32 enableflag, UInt16 trigmask, UInt16 pinpolarity, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTriggerEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardTriggerEx(UInt16 trigmask, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTriggerValid@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_CardTriggerValid(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CardTypeStr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_CardTypeStr(UInt32 handleval);
            public static string BTICard_CardTypeStr(UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_CardTypeStr(handleval)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ChDARClr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARClr(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ChDARGet@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ChDARGet(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ChDARRdL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_ChDARRdL(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ChDARRdsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ChDARRdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_ChDARRdW(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ChDARSet@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARSet(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ChDARWrL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARWrL(UInt32 value, UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ChDARWrsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ChDARWrW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARWrW(UInt16 value, UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CISRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CISRd(ref UInt16 buf, UInt16 bufcount, Int32 cistype, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CISWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CISWr(ref UInt16 buf, UInt16 bufcount, Int32 cistype, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommBufRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_CommBufRd(UInt16 offset, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommBufWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CommBufWr(UInt16 value, UInt16 offset, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommCall(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommChannelReconfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommChannelReconfig(UInt32 chmask, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommCheck@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommCheck(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommDisable@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommDisable(UInt16 command, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommDisableEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommDisableEx(UInt16 command, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommEnable(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommExternSRQ@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommExternSRQ(UInt32 chmask, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommFillW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommFillW(UInt16 value, UInt32 addrval, UInt16 count, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommProtocolFunc@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommProtocolFunc(UInt16 opcode, UInt16 argcount, ref UInt16 argbuf, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_CommRdL(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommRdsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_CommRdW(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommRun@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommRun(ref UInt16 dataptr, UInt16 datacount, ref UInt16 codeptr, UInt16 codecount, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CommWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommWrsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CommWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CommWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoProcCheck@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcCheck(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoProcGetInfo@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcGetInfo(ref UInt32 valueptr, UInt16 infotype, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoProcMemRdL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemRdL(ref UInt32 valueptr, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoProcMemRdsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemRdsL(ref UInt32 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoProcMemRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemRdsW(ref UInt16 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoProcMemRdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemRdW(ref UInt16 valueptr, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoProcMemWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoProcMemWrsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemWrsL(ref UInt32 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoProcMemWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemWrsW(ref UInt16 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoProcMemWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_CoreOpen@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoreOpen(ref UInt32 lphcore, Int32 corenum, UInt32 hcard);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DARClr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARClr(UInt16 maskval, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DARGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DARGet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DARRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_DARRdL(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DARRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DARRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_DARRdW(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DARSet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARSet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DARWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DARWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DARWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Div@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Div(UInt32 diva, UInt32 divb);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Div64@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Div64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DllUsageCount();
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DspBioClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspBioClear(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DspBioRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspBioRd(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DspBioSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspBioSet(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DspIntfClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspIntfClear(UInt16 intmask, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DspIntfRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspIntfRd(UInt16 intmask, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DspIntmClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspIntmClear(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DspIntmSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspIntmSet(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DspXfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspXfClear(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DspXfRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspXfRd(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_DspXfSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspXfSet(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ErrDesc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ErrDesc(Int32 errval, UInt32 handleval);
            public static string BTICard_ErrDesc(Int32 errval, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_ErrDesc(errval, handleval)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ErrDescStr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ErrDescStr(Int32 errval, UInt32 handleval);
            public static string BTICard_ErrDescStr(Int32 errval, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_ErrDescStr(errval, handleval)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ErrName@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ErrName(Int32 errval, UInt32 handleval);
            public static string BTICard_ErrName(Int32 errval, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_ErrName(errval, handleval)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_EventLogClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_EventLogClear(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_EventLogConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_EventLogConfig(UInt16 configval, UInt16 count, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_EventLogRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_EventLogRd(ref UInt16 typevalval, ref UInt32 infoval, ref Int32 channel, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_EventLogStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_EventLogStatus(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExpandMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExpandMant(ref UInt32 mant, ref Int32 exp);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExtDinRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ExtDinRd(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExtDinWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtDinWr(Int32 dinval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExtDIODirSet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtDIODirSet(Int32 dionum, Int32 dirval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExtDIOMonConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ExtDIOMonConfig(UInt16 rise_edge, UInt16 fall_edge, Int32 banknum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExtDIORd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ExtDIORd(Int32 dionum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExtDIOWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtDIOWr(Int32 dionum, Int32 dioval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExtLEDRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ExtLEDRd(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExtLEDWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtLEDWr(Int32 ledval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExtStatusLEDRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtStatusLEDRd(ref Int32 ledon, ref Int32 ledcolor, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ExtStatusLEDWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtStatusLEDWr(Int32 ledon, Int32 ledcolor, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_FileClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_FileClose(IntPtr handle);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_FileErr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_FileErr();
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_FileErrClr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_FileErrClr();
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_FileErrSet@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_FileErrSet();
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_FileOpenRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern unsafe IntPtr* BTICard_FileOpenRead(ref string filename);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_FileOpenWrite@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern unsafe IntPtr* BTICard_FileOpenWrite(ref string filename);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_FileRead@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_FileRead(IntPtr handle, IntPtr buffer, UInt16 count);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_FileSeek@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_FileSeek(IntPtr handle, UInt32 offset);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_FileTell@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_FileTell(IntPtr handle);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_FileWrite@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_FileWrite(IntPtr handle, IntPtr buffer, UInt16 count);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_GetHigh@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_GetHigh(UInt32 val);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_GetLow@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_GetLow(UInt32 val);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_GlobalRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_GlobalRdW(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_GlobalWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_GlobalWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HandleInfo@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_HandleInfo(ref string cardstr, ref Int32 cardnum, ref UInt32 sizval, IntPtr* vxdptr, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HandleInfoEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleInfoEx(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HandleIsCard@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleIsCard(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HandleIsCore@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleIsCore(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HandleMakeCard@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleMakeCard(ref UInt32 lphcard, ref Int32 lpcorenum, UInt32 hcore);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HandleMakeCore@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleMakeCore(ref UInt32 lphcore, Int32 corenum, UInt32 hcard);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HandleMakeRPC@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleMakeRPC(ref UInt32 hcard_remote, ref UInt32 lphrpc, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HandleOkay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleOkay(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HeapAlloc@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_HeapAlloc(Int32 section, UInt32 wordcount, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HeapAllocAll@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_HeapAllocAll(Int32 section, ref UInt32 wordcount, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HeapAllocEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_HeapAllocEx(UInt16 configval, Int32 section, UInt32 wordcount, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HeapWipe@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_HeapWipe(Int32 section, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HPIFill@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIFill(UInt16 value, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HPIRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_HPIRdL(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HPIRdsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIRdsL(ref UInt32 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HPIRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HPIRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_HPIRdW(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HPIWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HPIWrsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIWrsL(ref UInt32 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HPIWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_HPIWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IDRegRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_IDRegRd(Int32 gate_array_num, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IDRegWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IDRegWr(UInt16 value, Int32 gate_array_num, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IntClear(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IntDisable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IntDisable(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IntEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IntEnable(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IntEnableCond@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IntEnableCond(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IntGet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern unsafe IntPtr* BTICard_IntGet(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IntInstall(IntPtr hevent, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IntReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IntReset(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IntUninstall(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IORdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IORdL(Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IORdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_IORdW(Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IOWINRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_IOWINRdW(Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IOWINWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IOWINWrW(UInt16 value, Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IOWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IOWrL(UInt32 value, Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IOWrW(UInt16 value, Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGConfig(UInt32 configval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldGetDays@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetDays(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldGetHours@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetHours(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldGetMicrosec@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetMicrosec(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldGetMillisec@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetMillisec(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldGetMin@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetMin(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldGetSec@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetSec(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldPutDays@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutDays(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldPutHours@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutHours(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldPutMicrosec@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutMicrosec(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldPutMillisec@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutMillisec(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldPutMin@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutMin(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGFieldPutSec@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutSec(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGInputThresholdGet@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGInputThresholdGet(ref UInt16 dacval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGInputThresholdSet@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGInputThresholdSet(UInt16 dacval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGRd(ref BTIIRIGTIME irigtime, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGRdEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGRdEx(ref UInt16 timebuf, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGSyncStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGSyncStatus(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGTimeBCDToBin@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGTimeBCDToBin(ref UInt32 timevalh, ref UInt32 timevall, UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGTimeBinToBCD@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGTimeBinToBCD(ref UInt32 irigvalh, ref UInt32 irigvall, UInt32 timevalh, UInt32 timevall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGWr(ref BTIIRIGTIME irigtime, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_IRIGWrEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGWrEx(ref UInt16 timebuf, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_KernIntStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_KernIntStatus(ref Int32 valueptr, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_KernStatus@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_KernStatus(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_KernStatusEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_KernStatusEx(ref UInt32 valueptr, UInt32 typeval, UInt32 index, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_MakeLong@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_MakeLong(UInt16 valh, UInt16 vall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_MakeWord@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_MakeWord(byte valh, byte vall);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_MantToAscii@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_MantToAscii(ref string buf, Int32 mant, Int32 exp);
            public static string BTICard_MantToAscii(ref string buf, Int32 mant, Int32 exp) { return Marshal.PtrToStringAnsi(_BTICard_MantToAscii(ref buf, mant, exp)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Mask@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Mask(UInt32 dataval, UInt16 cntval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_MaxMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_MaxMant(ref UInt32 mant, ref Int32 exp);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Mod@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Mod(UInt32 moda, UInt32 modb);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Mod64@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Mod64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Mul@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Mul(UInt32 mula, UInt32 mulb);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Mul64@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Mul64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_NormalMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_NormalMant(ref UInt32 mant, ref Int32 exp);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_PortRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_PortRd(Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_PortWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_PortWr(UInt16 value, Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ProgRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_ProgRdW(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ProgWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ProgWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMFill@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMFill(UInt16 value, UInt32 addrval, UInt32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_RAMRdB(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_RAMRdL(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMRdmL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMRdmL(ref UInt32 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMRdmW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMRdmW(ref UInt16 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMRdsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_RAMRdW(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWipe(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMWipeEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWipeEx(UInt16 value, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMWrmL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrmL(ref UInt32 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMWrmW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrmW(ref UInt16 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMWrsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_RAMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ReverseLong@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_ReverseLong(UInt32 value);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ReverseWord@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_ReverseWord(UInt16 value);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_SeqBlkRd(ref UInt16 buf, UInt32 bufcount, ref UInt32 blkcnt, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqBlkRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_SeqBlkRdEx(ref UInt16 buf, UInt32 bufcount, UInt32 maxblkcnt, ref UInt32 blkcnt, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqClear(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqCommRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SeqCommRd(ref UInt16 buf, UInt16 bufcount, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqConfig(UInt32 configval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqConfigEx(UInt32 configval, UInt32 seqcount, UInt16 cardnum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqConfigExx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqConfigExx(UInt32 configval, UInt32 seqaddr, UInt32 seqcount, UInt16 cardnum, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqDMARd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_SeqDMARd(ref UInt16 buf, UInt32 bufcount, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindCheckVersion@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindCheckVersion(ref UInt16 precord, UInt16 version);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindInit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindInit(ref UInt16 seqbuf, UInt32 seqbufsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindMore1553@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindMore1553(ref SEQRECORDMORE1553* precmore, ref SEQRECORD1553 precbase);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindMore1553Ex@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindMore1553Ex(ref SEQRECORDMORE1553 precmore, UInt16 recordsize, ref SEQRECORD1553 precbase);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNext@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNext(ref UInt16* precord, ref UInt16 seqtype, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNext1553@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNext1553(ref SEQRECORD1553* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNext1553Ex@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNext1553Ex(ref SEQRECORD1553 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNext429@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNext429(ref SEQRECORD429* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNext429Ex@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNext429Ex(ref SEQRECORD429 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNext708@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNext708(ref SEQRECORD708* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNext708Ex@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNext708Ex(ref SEQRECORD708 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNext717@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNext717(ref SEQRECORD717* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNext717Ex@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNext717Ex(ref SEQRECORD717 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNextCSDB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNextCSDB(ref SEQRECORDCSDB* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNextCSDBEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNextCSDBEx(ref SEQRECORDCSDB precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNextDIO@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNextDIO(ref SEQRECORDDIO* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNextDIOEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNextDIOEx(ref SEQRECORDDIO precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqFindNextEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNextEx(ref UInt16 precord, UInt16 recordcount, ref UInt16 seqtype, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqInterval@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqInterval(Int32 interval, Int32 mode, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqIntervalEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SeqIntervalEx(UInt16 shiftval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqIsRunning(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqLogFrequency@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SeqLogFrequency(UInt16 logfreq, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SeqRd(ref UInt16 buf, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SeqRdEx(ref UInt16 buf, UInt16 bufcount, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqResume(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqStart(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqStatus(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SeqStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqStop(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Shl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Shl(UInt32 dataval, UInt16 cntval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Shr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Shr(UInt32 dataval, UInt16 cntval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SignMant@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SignMant(ref string str);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Sub64@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Sub64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SwapEndianL@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapEndianL(ref UInt32 value);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SwapEndianW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapEndianW(ref UInt16 valuea, ref UInt16 valueb);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SwapIfBigEndianL@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapIfBigEndianL(ref UInt32 value);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SwapIfBigEndianW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapIfBigEndianW(ref UInt16 valuea, ref UInt16 valueb);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SwapIfLittleEndianL@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapIfLittleEndianL(ref UInt32 value);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SwapIfLittleEndianW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapIfLittleEndianW(ref UInt16 valuea, ref UInt16 valueb);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonClear(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonInit@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonInit(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonTypeGet@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_SysMonTypeGet(Int32 index, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonDescGet@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_SysMonDescGet(Int32 index, UInt32 handleval);
            public static string BTICard_SysMonDescGet(Int32 index, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_SysMonDescGet(index, handleval)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonMaxRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonMaxRd(Int32 index, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonMinRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonMinRd(Int32 index, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonNomRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonNomRd(Int32 index, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonUserStr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_SysMonUserStr(Int32 value, Int32 index, UInt32 handleval);
            public static string BTICard_SysMonUserStr(Int32 value, Int32 index, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_SysMonUserStr(value, index, handleval)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonValRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonValRd(Int32 index, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonValStr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_SysMonValStr(Int32 index, UInt32 handleval);
            public static string BTICard_SysMonValStr(Int32 index, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_SysMonValStr(index, handleval)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonThresholdSet@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonThresholdSet(Int32 enable, Int32 minval, Int32 maxval, Int32 index, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonThresholdGet@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SysMonThresholdGet(Int32* enable, ref Int32 minval, ref Int32 maxval, Int32 index, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonValToDAC@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SysMonValToDAC(Int32 val, Int32 rangemin, Int32 rangemax, UInt16 dacval_max, Int32 scalefactor, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_SysMonDACToVal@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonDACToVal(UInt16 dacval, Int32 rangemin, Int32 rangemax, UInt16 dacval_max, Int32 scalefactor, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_TickTimerStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_TickTimerStart(Int32 milliseconds);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_TickTimerValid@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_TickTimerValid(Int32 timer);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Timer64Rd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_Timer64Rd(ref UInt32 valueh, ref UInt32 valuel, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_Timer64Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Timer64Wr(UInt32 valueh, UInt32 valuel, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_TimerClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_TimerClear(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_TimerRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_TimerRd(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_TimerResolution@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_TimerResolution(Int32 timerresol, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_TimerResolutionEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_TimerResolutionEx(UInt16 timershift, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_TimerStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_TimerStatus(UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_TimerWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_TimerWr(UInt32 value, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValAsciiCmpi@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ValAsciiCmpi(ref string str1, ref string str2);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValAsciiCpy@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count);
            public static string BTICard_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count) { return Marshal.PtrToStringAnsi(_BTICard_ValAsciiCpy(ref strdest, ref strsrc, count)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValAsciiTrimLead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ValAsciiTrimLead(ref string buf);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValAsciiTrimTrail@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ValAsciiTrimTrail(ref string buf);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValFromAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_ValFromAscii(ref string asciistr, Int32 radixval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValGetBits@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_ValGetBits(UInt32 oldvalue, Int32 startbit, Int32 endbit);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValIncAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ValIncAscii(ref string asciistr);
            public static string BTICard_ValIncAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_BTICard_ValIncAscii(ref asciistr)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValInccAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ValInccAscii(ref string asciistr);
            public static string BTICard_ValInccAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_BTICard_ValInccAscii(ref asciistr)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValIsLower@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ValIsLower(Int32 value);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValLenAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ValLenAscii(Int32 numbits, Int32 radixval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValPutBits@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_ValPutBits(UInt32 oldvalue, UInt32 newfld, Int32 startbit, Int32 endbit);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValToAscii@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval);
            public static string BTICard_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval) { return Marshal.PtrToStringAnsi(_BTICard_ValToAscii(value, ref asciistr, numbits, radixval)); }
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_ValToUpper@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ValToUpper(Int32 value);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_VARRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_VARRdL(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_VARRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_VARRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_VARRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_VARRdW(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_VARWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_VARWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_VARWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_VARWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD.DLL", EntryPoint = "_BTICard_VARWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_VARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        }

        private static class BTICARD_64
        {
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Add64", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Add64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_AddrDSP", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_AddrDSP(UInt32 addr, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_AddrHost", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_AddrHost(UInt32 addr, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_AsciiToMant", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_AsciiToMant(ref string str, ref UInt32 mant, ref Int32 exp);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_BCDToBin", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_BCDToBin(UInt32 bcdval, Int32 msb, Int32 lsb);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_BinToBCD", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_BinToBCD(UInt32 oldbcdval, UInt32 binval, Int32 msb, Int32 lsb);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_BITConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_BITConfig(UInt32 ctrlflags, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_BITInitiate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_BITInitiate(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_BITStatusClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_BITStatusClear(UInt32 statval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_BITStatusRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_BITStatusRd(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardClose", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardClose(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardCloseAll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardCloseAll();
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardGetInfo", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_CardGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardGetInfoEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardGetInfoEx(ref UInt16 bufmodel, UInt16 bufmodelcount, ref UInt16 buffeature, UInt16 buffeaturecount, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardIsRunning", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardIsRunning(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardNop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardNop(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardOpen", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardOpen(ref UInt32 lphandle, Int32 cardnum);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardOpenStr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardOpenStr(ref UInt32 lphandle, ref string cardstr);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardProductStr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_CardProductStr(UInt32 handleval);
            public static string BTICard_CardProductStr(UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_CardProductStr(handleval)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardReset(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardResetEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardResetEx(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardResume", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardResume(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardShadow", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardShadow(Int32 shadowval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardStart(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardStop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardStop(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardSyncEnable", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardSyncEnable(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardSyncValid", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_CardSyncValid(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTest", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardTest(UInt16 level, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTest0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardTest0(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTest1", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardTest1(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTest2", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardTest2(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTest3", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CardTest3(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTrigger", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardTrigger(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTriggerEnable", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardTriggerEnable(Int32 enableflag, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTriggerEnableEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardTriggerEnableEx(Int32 enableflag, UInt16 trigmask, UInt16 pinpolarity, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTriggerEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CardTriggerEx(UInt16 trigmask, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTriggerValid", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_CardTriggerValid(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CardTypeStr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_CardTypeStr(UInt32 handleval);
            public static string BTICard_CardTypeStr(UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_CardTypeStr(handleval)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ChDARClr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARClr(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ChDARGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ChDARGet(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ChDARRdL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_ChDARRdL(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ChDARRdsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ChDARRdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_ChDARRdW(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ChDARSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARSet(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ChDARWrL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARWrL(UInt32 value, UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ChDARWrsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ChDARWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ChDARWrW(UInt16 value, UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CISRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CISRd(ref UInt16 buf, UInt16 bufcount, Int32 cistype, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CISWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CISWr(ref UInt16 buf, UInt16 bufcount, Int32 cistype, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommBufRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_CommBufRd(UInt16 offset, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommBufWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CommBufWr(UInt16 value, UInt16 offset, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommCall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommCall(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommChannelReconfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommChannelReconfig(UInt32 chmask, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommCheck(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommDisable", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommDisable(UInt16 command, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommDisableEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommDisableEx(UInt16 command, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommEnable", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommEnable(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommExternSRQ", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommExternSRQ(UInt32 chmask, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommFillW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommFillW(UInt16 value, UInt32 addrval, UInt16 count, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommProtocolFunc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommProtocolFunc(UInt16 opcode, UInt16 argcount, ref UInt16 argbuf, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommRdL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_CommRdL(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommRdsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommRdsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommRdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_CommRdW(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommRun", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommRun(ref UInt16 dataptr, UInt16 datacount, ref UInt16 codeptr, UInt16 codecount, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommWrL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CommWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommWrsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CommWrsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CommWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_CommWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoProcCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcCheck(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoProcGetInfo", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcGetInfo(ref UInt32 valueptr, UInt16 infotype, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoProcMemRdL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemRdL(ref UInt32 valueptr, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoProcMemRdsL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemRdsL(ref UInt32 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoProcMemRdsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemRdsW(ref UInt16 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoProcMemRdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemRdW(ref UInt16 valueptr, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoProcMemWrL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoProcMemWrsL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemWrsL(ref UInt32 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoProcMemWrsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemWrsW(ref UInt16 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoProcMemWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoProcMemWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_CoreOpen", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_CoreOpen(ref UInt32 lphcore, Int32 corenum, UInt32 hcard);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DARClr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARClr(UInt16 maskval, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DARGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DARGet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DARRdL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_DARRdL(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DARRdsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DARRdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_DARRdW(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DARSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARSet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DARWrL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DARWrsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DARWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_DARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Div", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Div(UInt32 diva, UInt32 divb);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Div64", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Div64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DllUsageCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DllUsageCount();
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DspBioClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspBioClear(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DspBioRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspBioRd(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DspBioSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspBioSet(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DspIntfClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspIntfClear(UInt16 intmask, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DspIntfRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspIntfRd(UInt16 intmask, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DspIntmClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspIntmClear(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DspIntmSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspIntmSet(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DspXfClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspXfClear(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DspXfRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspXfRd(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_DspXfSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_DspXfSet(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ErrDesc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ErrDesc(Int32 errval, UInt32 handleval);
            public static string BTICard_ErrDesc(Int32 errval, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_ErrDesc(errval, handleval)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ErrDescStr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ErrDescStr(Int32 errval, UInt32 handleval);
            public static string BTICard_ErrDescStr(Int32 errval, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_ErrDescStr(errval, handleval)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ErrName", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ErrName(Int32 errval, UInt32 handleval);
            public static string BTICard_ErrName(Int32 errval, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_ErrName(errval, handleval)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_EventLogClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_EventLogClear(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_EventLogConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_EventLogConfig(UInt16 configval, UInt16 count, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_EventLogRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_EventLogRd(ref UInt16 typevalval, ref UInt32 infoval, ref Int32 channel, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_EventLogStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_EventLogStatus(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExpandMant", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExpandMant(ref UInt32 mant, ref Int32 exp);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExtDinRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ExtDinRd(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExtDinWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtDinWr(Int32 dinval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExtDIODirSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtDIODirSet(Int32 dionum, Int32 dirval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExtDIOMonConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ExtDIOMonConfig(UInt16 rise_edge, UInt16 fall_edge, Int32 banknum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExtDIORd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ExtDIORd(Int32 dionum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExtDIOWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtDIOWr(Int32 dionum, Int32 dioval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExtLEDRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ExtLEDRd(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExtLEDWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtLEDWr(Int32 ledval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExtStatusLEDRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtStatusLEDRd(ref Int32 ledon, ref Int32 ledcolor, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ExtStatusLEDWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ExtStatusLEDWr(Int32 ledon, Int32 ledcolor, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_FileClose", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_FileClose(IntPtr handle);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_FileErr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_FileErr();
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_FileErrClr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_FileErrClr();
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_FileErrSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_FileErrSet();
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_FileOpenRead", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern unsafe IntPtr* BTICard_FileOpenRead(ref string filename);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_FileOpenWrite", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern unsafe IntPtr* BTICard_FileOpenWrite(ref string filename);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_FileRead", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_FileRead(IntPtr handle, IntPtr buffer, UInt16 count);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_FileSeek", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_FileSeek(IntPtr handle, UInt32 offset);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_FileTell", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_FileTell(IntPtr handle);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_FileWrite", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_FileWrite(IntPtr handle, IntPtr buffer, UInt16 count);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_GetHigh", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_GetHigh(UInt32 val);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_GetLow", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_GetLow(UInt32 val);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_GlobalRdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_GlobalRdW(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_GlobalWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_GlobalWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HandleInfo", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_HandleInfo(ref string cardstr, ref Int32 cardnum, ref UInt32 sizval, IntPtr* vxdptr, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HandleInfoEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleInfoEx(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HandleIsCard", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleIsCard(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HandleIsCore", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleIsCore(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HandleMakeCard", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleMakeCard(ref UInt32 lphcard, ref Int32 lpcorenum, UInt32 hcore);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HandleMakeCore", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleMakeCore(ref UInt32 lphcore, Int32 corenum, UInt32 hcard);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HandleMakeRPC", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleMakeRPC(ref UInt32 hcard_remote, ref UInt32 lphrpc, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HandleOkay", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_HandleOkay(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HeapAlloc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_HeapAlloc(Int32 section, UInt32 wordcount, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HeapAllocAll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_HeapAllocAll(Int32 section, ref UInt32 wordcount, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HeapAllocEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_HeapAllocEx(UInt16 configval, Int32 section, UInt32 wordcount, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HeapWipe", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_HeapWipe(Int32 section, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HPIFill", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIFill(UInt16 value, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HPIRdL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_HPIRdL(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HPIRdsL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIRdsL(ref UInt32 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HPIRdsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HPIRdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_HPIRdW(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HPIWrL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HPIWrsL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIWrsL(ref UInt32 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HPIWrsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_HPIWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_HPIWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IDRegRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_IDRegRd(Int32 gate_array_num, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IDRegWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IDRegWr(UInt16 value, Int32 gate_array_num, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IntClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IntClear(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IntDisable", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IntDisable(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IntEnable", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IntEnable(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IntEnableCond", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IntEnableCond(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IntGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern unsafe IntPtr* BTICard_IntGet(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IntInstall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IntInstall(IntPtr hevent, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IntReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IntReset(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IntUninstall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IntUninstall(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IORdL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IORdL(Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IORdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_IORdW(Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IOWINRdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_IOWINRdW(Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IOWINWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IOWINWrW(UInt16 value, Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IOWrL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IOWrL(UInt32 value, Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IOWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IOWrW(UInt16 value, Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGConfig(UInt32 configval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldGetDays", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetDays(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldGetHours", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetHours(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldGetMicrosec", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetMicrosec(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldGetMillisec", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetMillisec(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldGetMin", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetMin(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldGetSec", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_IRIGFieldGetSec(UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldPutDays", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutDays(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldPutHours", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutHours(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldPutMicrosec", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutMicrosec(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldPutMillisec", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutMillisec(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldPutMin", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutMin(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGFieldPutSec", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGFieldPutSec(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGInputThresholdGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGInputThresholdGet(ref UInt16 dacval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGInputThresholdSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGInputThresholdSet(UInt16 dacval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGRd(ref BTIIRIGTIME irigtime, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGRdEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGRdEx(ref UInt16 timebuf, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGSyncStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGSyncStatus(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGTimeBCDToBin", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGTimeBCDToBin(ref UInt32 timevalh, ref UInt32 timevall, UInt32 irigvalh, UInt32 irigvall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGTimeBinToBCD", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_IRIGTimeBinToBCD(ref UInt32 irigvalh, ref UInt32 irigvall, UInt32 timevalh, UInt32 timevall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGWr(ref BTIIRIGTIME irigtime, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_IRIGWrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_IRIGWrEx(ref UInt16 timebuf, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_KernIntStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_KernIntStatus(ref Int32 valueptr, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_KernStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_KernStatus(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_KernStatusEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_KernStatusEx(ref UInt32 valueptr, UInt32 typeval, UInt32 index, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_MakeLong", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_MakeLong(UInt16 valh, UInt16 vall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_MakeWord", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_MakeWord(byte valh, byte vall);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_MantToAscii", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_MantToAscii(ref string buf, Int32 mant, Int32 exp);
            public static string BTICard_MantToAscii(ref string buf, Int32 mant, Int32 exp) { return Marshal.PtrToStringAnsi(_BTICard_MantToAscii(ref buf, mant, exp)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Mask", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Mask(UInt32 dataval, UInt16 cntval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_MaxMant", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_MaxMant(ref UInt32 mant, ref Int32 exp);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Mod", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Mod(UInt32 moda, UInt32 modb);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Mod64", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Mod64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Mul", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Mul(UInt32 mula, UInt32 mulb);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Mul64", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Mul64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_NormalMant", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_NormalMant(ref UInt32 mant, ref Int32 exp);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_PortRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_PortRd(Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_PortWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_PortWr(UInt16 value, Int32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ProgRdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_ProgRdW(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ProgWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ProgWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMFill", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMFill(UInt16 value, UInt32 addrval, UInt32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMRdB", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_RAMRdB(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMRdL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_RAMRdL(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMRdmL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMRdmL(ref UInt32 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMRdmW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMRdmW(ref UInt16 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMRdsL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMRdsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMRdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_RAMRdW(UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMWipe", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWipe(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMWipeEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWipeEx(UInt16 value, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMWrB", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMWrL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMWrmL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrmL(ref UInt32 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMWrmW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrmW(ref UInt16 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMWrsL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMWrsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_RAMWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_RAMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ReverseLong", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_ReverseLong(UInt32 value);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ReverseWord", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_ReverseWord(UInt16 value);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqBlkRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_SeqBlkRd(ref UInt16 buf, UInt32 bufcount, ref UInt32 blkcnt, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqBlkRdEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_SeqBlkRdEx(ref UInt16 buf, UInt32 bufcount, UInt32 maxblkcnt, ref UInt32 blkcnt, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqClear(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqCommRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SeqCommRd(ref UInt16 buf, UInt16 bufcount, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqConfig(UInt32 configval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqConfigEx(UInt32 configval, UInt32 seqcount, UInt16 cardnum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqConfigExx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqConfigExx(UInt32 configval, UInt32 seqaddr, UInt32 seqcount, UInt16 cardnum, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqDMARd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_SeqDMARd(ref UInt16 buf, UInt32 bufcount, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindCheckVersion", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindCheckVersion(ref UInt16 precord, UInt16 version);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindInit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindInit(ref UInt16 seqbuf, UInt32 seqbufsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindMore1553", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindMore1553(ref SEQRECORDMORE1553* precmore, ref SEQRECORD1553 precbase);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindMore1553Ex", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindMore1553Ex(ref SEQRECORDMORE1553 precmore, UInt16 recordsize, ref SEQRECORD1553 precbase);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNext", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNext(ref UInt16* precord, ref UInt16 seqtype, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNext1553", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNext1553(ref SEQRECORD1553* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNext1553Ex", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNext1553Ex(ref SEQRECORD1553 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNext429", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNext429(ref SEQRECORD429* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNext429Ex", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNext429Ex(ref SEQRECORD429 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNext708", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNext708(ref SEQRECORD708* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNext708Ex", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNext708Ex(ref SEQRECORD708 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNext717", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNext717(ref SEQRECORD717* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNext717Ex", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNext717Ex(ref SEQRECORD717 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNextCSDB", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNextCSDB(ref SEQRECORDCSDB* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNextCSDBEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNextCSDBEx(ref SEQRECORDCSDB precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNextDIO", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SeqFindNextDIO(ref SEQRECORDDIO* precord, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNextDIOEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNextDIOEx(ref SEQRECORDDIO precord, UInt16 recordsize, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqFindNextEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqFindNextEx(ref UInt16 precord, UInt16 recordcount, ref UInt16 seqtype, ref SEQFINDINFO sfinfo);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqInterval", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqInterval(Int32 interval, Int32 mode, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqIntervalEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SeqIntervalEx(UInt16 shiftval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqIsRunning", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqIsRunning(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqLogFrequency", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SeqLogFrequency(UInt16 logfreq, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SeqRd(ref UInt16 buf, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqRdEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SeqRdEx(ref UInt16 buf, UInt16 bufcount, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqResume", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqResume(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqStart(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqStatus(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SeqStop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SeqStop(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Shl", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Shl(UInt32 dataval, UInt16 cntval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Shr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_Shr(UInt32 dataval, UInt16 cntval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SignMant", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SignMant(ref string str);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Sub64", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Sub64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SwapEndianL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapEndianL(ref UInt32 value);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SwapEndianW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapEndianW(ref UInt16 valuea, ref UInt16 valueb);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SwapIfBigEndianL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapIfBigEndianL(ref UInt32 value);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SwapIfBigEndianW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapIfBigEndianW(ref UInt16 valuea, ref UInt16 valueb);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SwapIfLittleEndianL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapIfLittleEndianL(ref UInt32 value);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SwapIfLittleEndianW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_SwapIfLittleEndianW(ref UInt16 valuea, ref UInt16 valueb);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonClear(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonInit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonInit(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonTypeGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_SysMonTypeGet(Int32 index, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonDescGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_SysMonDescGet(Int32 index, UInt32 handleval);
            public static string BTICard_SysMonDescGet(Int32 index, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_SysMonDescGet(index, handleval)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonMaxRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonMaxRd(Int32 index, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonMinRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonMinRd(Int32 index, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonNomRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonNomRd(Int32 index, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonUserStr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_SysMonUserStr(Int32 value, Int32 index, UInt32 handleval);
            public static string BTICard_SysMonUserStr(Int32 value, Int32 index, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_SysMonUserStr(value, index, handleval)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonValRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonValRd(Int32 index, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonValStr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_SysMonValStr(Int32 index, UInt32 handleval);
            public static string BTICard_SysMonValStr(Int32 index, UInt32 handleval) { return Marshal.PtrToStringAnsi(_BTICard_SysMonValStr(index, handleval)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonThresholdSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonThresholdSet(Int32 enable, Int32 minval, Int32 maxval, Int32 index, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonThresholdGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern Int32 BTICard_SysMonThresholdGet(Int32* enable, ref Int32 minval, ref Int32 maxval, Int32 index, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonValToDAC", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_SysMonValToDAC(Int32 val, Int32 rangemin, Int32 rangemax, UInt16 dacval_max, Int32 scalefactor, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_SysMonDACToVal", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_SysMonDACToVal(UInt16 dacval, Int32 rangemin, Int32 rangemax, UInt16 dacval_max, Int32 scalefactor, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_TickTimerStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_TickTimerStart(Int32 milliseconds);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_TickTimerValid", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_TickTimerValid(Int32 timer);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Timer64Rd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_Timer64Rd(ref UInt32 valueh, ref UInt32 valuel, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_Timer64Wr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_Timer64Wr(UInt32 valueh, UInt32 valuel, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_TimerClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_TimerClear(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_TimerRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_TimerRd(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_TimerResolution", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_TimerResolution(Int32 timerresol, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_TimerResolutionEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_TimerResolutionEx(UInt16 timershift, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_TimerStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_TimerStatus(UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_TimerWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_TimerWr(UInt32 value, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValAsciiCmpi", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ValAsciiCmpi(ref string str1, ref string str2);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValAsciiCpy", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count);
            public static string BTICard_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count) { return Marshal.PtrToStringAnsi(_BTICard_ValAsciiCpy(ref strdest, ref strsrc, count)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValAsciiTrimLead", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ValAsciiTrimLead(ref string buf);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValAsciiTrimTrail", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_ValAsciiTrimTrail(ref string buf);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValFromAscii", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_ValFromAscii(ref string asciistr, Int32 radixval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValGetBits", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_ValGetBits(UInt32 oldvalue, Int32 startbit, Int32 endbit);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValIncAscii", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ValIncAscii(ref string asciistr);
            public static string BTICard_ValIncAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_BTICard_ValIncAscii(ref asciistr)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValInccAscii", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ValInccAscii(ref string asciistr);
            public static string BTICard_ValInccAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_BTICard_ValInccAscii(ref asciistr)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValIsLower", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ValIsLower(Int32 value);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValLenAscii", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ValLenAscii(Int32 numbits, Int32 radixval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValPutBits", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_ValPutBits(UInt32 oldvalue, UInt32 newfld, Int32 startbit, Int32 endbit);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValToAscii", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern IntPtr _BTICard_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval);
            public static string BTICard_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval) { return Marshal.PtrToStringAnsi(_BTICard_ValToAscii(value, ref asciistr, numbits, radixval)); }
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_ValToUpper", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICard_ValToUpper(Int32 value);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_VARRdL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICard_VARRdL(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_VARRdsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_VARRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_VARRdW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICard_VARRdW(UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_VARWrL", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_VARWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_VARWrsW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_VARWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval);
            [DllImport("BTICARD64.DLL", EntryPoint = "BTICard_VARWrW", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICard_VARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        }

        public static void BTICard_Add64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_Add64(ref resulth, ref resultl, valah, valal, valbh, valbl);
            else
                BTICARD_64.BTICard_Add64(ref resulth, ref resultl, valah, valal, valbh, valbl);
        }
        public static UInt32 BTICard_AddrDSP(UInt32 addr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_AddrDSP(addr, handleval);
            else
                return BTICARD_64.BTICard_AddrDSP(addr, handleval);
        }
        public static UInt32 BTICard_AddrHost(UInt32 addr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_AddrHost(addr, handleval);
            else
                return BTICARD_64.BTICard_AddrHost(addr, handleval);
        }
        public static Int32 BTICard_AsciiToMant(ref string str, ref UInt32 mant, ref Int32 exp)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_AsciiToMant(ref str, ref mant, ref exp);
            else
                return BTICARD_64.BTICard_AsciiToMant(ref str, ref mant, ref exp);
        }
        public static UInt32 BTICard_BCDToBin(UInt32 bcdval, Int32 msb, Int32 lsb)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_BCDToBin(bcdval, msb, lsb);
            else
                return BTICARD_64.BTICard_BCDToBin(bcdval, msb, lsb);
        }
        public static UInt32 BTICard_BinToBCD(UInt32 oldbcdval, UInt32 binval, Int32 msb, Int32 lsb)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_BinToBCD(oldbcdval, binval, msb, lsb);
            else
                return BTICARD_64.BTICard_BinToBCD(oldbcdval, binval, msb, lsb);
        }
        public static Int32 BTICard_BITConfig(UInt32 ctrlflags, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_BITConfig(ctrlflags, handleval);
            else
                return BTICARD_64.BTICard_BITConfig(ctrlflags, handleval);
        }
        public static Int32 BTICard_BITInitiate(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_BITInitiate(handleval);
            else
                return BTICARD_64.BTICard_BITInitiate(handleval);
        }
        public static Int32 BTICard_BITStatusClear(UInt32 statval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_BITStatusClear(statval, handleval);
            else
                return BTICARD_64.BTICard_BITStatusClear(statval, handleval);
        }
        public static UInt32 BTICard_BITStatusRd(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_BITStatusRd(handleval);
            else
                return BTICARD_64.BTICard_BITStatusRd(handleval);
        }
        public static Int32 BTICard_CardClose(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardClose(handleval);
            else
                return BTICARD_64.BTICard_CardClose(handleval);
        }
        public static Int32 BTICard_CardCloseAll()
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardCloseAll();
            else
                return BTICARD_64.BTICard_CardCloseAll();
        }
        public static UInt32 BTICard_CardGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardGetInfo(infotype, channum, handleval);
            else
                return BTICARD_64.BTICard_CardGetInfo(infotype, channum, handleval);
        }
        public static Int32 BTICard_CardGetInfoEx(ref UInt16 bufmodel, UInt16 bufmodelcount, ref UInt16 buffeature, UInt16 buffeaturecount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardGetInfoEx(ref bufmodel, bufmodelcount, ref buffeature, buffeaturecount, handleval);
            else
                return BTICARD_64.BTICard_CardGetInfoEx(ref bufmodel, bufmodelcount, ref buffeature, buffeaturecount, handleval);
        }
        public static Int32 BTICard_CardIsRunning(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardIsRunning(handleval);
            else
                return BTICARD_64.BTICard_CardIsRunning(handleval);
        }
        public static Int32 BTICard_CardNop(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardNop(handleval);
            else
                return BTICARD_64.BTICard_CardNop(handleval);
        }
        public static Int32 BTICard_CardOpen(ref UInt32 lphandle, Int32 cardnum)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardOpen(ref lphandle, cardnum);
            else
                return BTICARD_64.BTICard_CardOpen(ref lphandle, cardnum);
        }
        public static Int32 BTICard_CardOpenStr(ref UInt32 lphandle, ref string cardstr)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardOpenStr(ref lphandle, ref cardstr);
            else
                return BTICARD_64.BTICard_CardOpenStr(ref lphandle, ref cardstr);
        }
        public static unsafe string BTICard_CardProductStr(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardProductStr(handleval);
            else
                return BTICARD_64.BTICard_CardProductStr(handleval);
        }
        public static void BTICard_CardReset(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_CardReset(handleval);
            else
                BTICARD_64.BTICard_CardReset(handleval);
        }
        public static void BTICard_CardResetEx(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_CardResetEx(handleval);
            else
                BTICARD_64.BTICard_CardResetEx(handleval);
        }
        public static Int32 BTICard_CardResume(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardResume(handleval);
            else
                return BTICARD_64.BTICard_CardResume(handleval);
        }
        public static Int32 BTICard_CardShadow(Int32 shadowval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardShadow(shadowval, handleval);
            else
                return BTICARD_64.BTICard_CardShadow(shadowval, handleval);
        }
        public static Int32 BTICard_CardStart(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardStart(handleval);
            else
                return BTICARD_64.BTICard_CardStart(handleval);
        }
        public static Int32 BTICard_CardStop(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardStop(handleval);
            else
                return BTICARD_64.BTICard_CardStop(handleval);
        }
        public static void BTICard_CardSyncEnable(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_CardSyncEnable(enableflag, syncmask, pinpolarity, handleval);
            else
                BTICARD_64.BTICard_CardSyncEnable(enableflag, syncmask, pinpolarity, handleval);
        }
        public static UInt16 BTICard_CardSyncValid(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardSyncValid(handleval);
            else
                return BTICARD_64.BTICard_CardSyncValid(handleval);
        }
        public static Int32 BTICard_CardTest(UInt16 level, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardTest(level, handleval);
            else
                return BTICARD_64.BTICard_CardTest(level, handleval);
        }
        public static Int32 BTICard_CardTest0(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardTest0(handleval);
            else
                return BTICARD_64.BTICard_CardTest0(handleval);
        }
        public static Int32 BTICard_CardTest1(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardTest1(handleval);
            else
                return BTICARD_64.BTICard_CardTest1(handleval);
        }
        public static Int32 BTICard_CardTest2(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardTest2(handleval);
            else
                return BTICARD_64.BTICard_CardTest2(handleval);
        }
        public static Int32 BTICard_CardTest3(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardTest3(handleval);
            else
                return BTICARD_64.BTICard_CardTest3(handleval);
        }
        public static void BTICard_CardTrigger(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_CardTrigger(handleval);
            else
                BTICARD_64.BTICard_CardTrigger(handleval);
        }
        public static void BTICard_CardTriggerEnable(Int32 enableflag, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_CardTriggerEnable(enableflag, handleval);
            else
                BTICARD_64.BTICard_CardTriggerEnable(enableflag, handleval);
        }
        public static void BTICard_CardTriggerEnableEx(Int32 enableflag, UInt16 trigmask, UInt16 pinpolarity, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_CardTriggerEnableEx(enableflag, trigmask, pinpolarity, handleval);
            else
                BTICARD_64.BTICard_CardTriggerEnableEx(enableflag, trigmask, pinpolarity, handleval);
        }
        public static void BTICard_CardTriggerEx(UInt16 trigmask, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_CardTriggerEx(trigmask, handleval);
            else
                BTICARD_64.BTICard_CardTriggerEx(trigmask, handleval);
        }
        public static UInt16 BTICard_CardTriggerValid(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardTriggerValid(handleval);
            else
                return BTICARD_64.BTICard_CardTriggerValid(handleval);
        }
        public static unsafe string BTICard_CardTypeStr(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CardTypeStr(handleval);
            else
                return BTICARD_64.BTICard_CardTypeStr(handleval);
        }
        public static void BTICard_ChDARClr(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ChDARClr(maskval, addrval, channum, handleval);
            else
                BTICARD_64.BTICard_ChDARClr(maskval, addrval, channum, handleval);
        }
        public static Int32 BTICard_ChDARGet(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ChDARGet(maskval, addrval, channum, handleval);
            else
                return BTICARD_64.BTICard_ChDARGet(maskval, addrval, channum, handleval);
        }
        public static UInt32 BTICard_ChDARRdL(UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ChDARRdL(addrval, channum, handleval);
            else
                return BTICARD_64.BTICard_ChDARRdL(addrval, channum, handleval);
        }
        public static void BTICard_ChDARRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ChDARRdsW(ref valueptr, addrval, countval, channum, handleval);
            else
                BTICARD_64.BTICard_ChDARRdsW(ref valueptr, addrval, countval, channum, handleval);
        }
        public static UInt16 BTICard_ChDARRdW(UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ChDARRdW(addrval, channum, handleval);
            else
                return BTICARD_64.BTICard_ChDARRdW(addrval, channum, handleval);
        }
        public static void BTICard_ChDARSet(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ChDARSet(maskval, addrval, channum, handleval);
            else
                BTICARD_64.BTICard_ChDARSet(maskval, addrval, channum, handleval);
        }
        public static void BTICard_ChDARWrL(UInt32 value, UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ChDARWrL(value, addrval, channum, handleval);
            else
                BTICARD_64.BTICard_ChDARWrL(value, addrval, channum, handleval);
        }
        public static void BTICard_ChDARWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ChDARWrsW(ref valueptr, addrval, countval, channum, handleval);
            else
                BTICARD_64.BTICard_ChDARWrsW(ref valueptr, addrval, countval, channum, handleval);
        }
        public static void BTICard_ChDARWrW(UInt16 value, UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ChDARWrW(value, addrval, channum, handleval);
            else
                BTICARD_64.BTICard_ChDARWrW(value, addrval, channum, handleval);
        }
        public static Int32 BTICard_CISRd(ref UInt16 buf, UInt16 bufcount, Int32 cistype, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CISRd(ref buf, bufcount, cistype, handleval);
            else
                return BTICARD_64.BTICard_CISRd(ref buf, bufcount, cistype, handleval);
        }
        public static Int32 BTICard_CISWr(ref UInt16 buf, UInt16 bufcount, Int32 cistype, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CISWr(ref buf, bufcount, cistype, handleval);
            else
                return BTICARD_64.BTICard_CISWr(ref buf, bufcount, cistype, handleval);
        }
        public static UInt16 BTICard_CommBufRd(UInt16 offset, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommBufRd(offset, handleval);
            else
                return BTICARD_64.BTICard_CommBufRd(offset, handleval);
        }
        public static void BTICard_CommBufWr(UInt16 value, UInt16 offset, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_CommBufWr(value, offset, handleval);
            else
                BTICARD_64.BTICard_CommBufWr(value, offset, handleval);
        }
        public static Int32 BTICard_CommCall(UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommCall(addrval, handleval);
            else
                return BTICARD_64.BTICard_CommCall(addrval, handleval);
        }
        public static Int32 BTICard_CommChannelReconfig(UInt32 chmask, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommChannelReconfig(chmask, handleval);
            else
                return BTICARD_64.BTICard_CommChannelReconfig(chmask, handleval);
        }
        public static Int32 BTICard_CommCheck(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommCheck(handleval);
            else
                return BTICARD_64.BTICard_CommCheck(handleval);
        }
        public static Int32 BTICard_CommDisable(UInt16 command, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommDisable(command, handleval);
            else
                return BTICARD_64.BTICard_CommDisable(command, handleval);
        }
        public static Int32 BTICard_CommDisableEx(UInt16 command, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommDisableEx(command, handleval);
            else
                return BTICARD_64.BTICard_CommDisableEx(command, handleval);
        }
        public static Int32 BTICard_CommEnable(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommEnable(handleval);
            else
                return BTICARD_64.BTICard_CommEnable(handleval);
        }
        public static Int32 BTICard_CommExternSRQ(UInt32 chmask, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommExternSRQ(chmask, handleval);
            else
                return BTICARD_64.BTICard_CommExternSRQ(chmask, handleval);
        }
        public static Int32 BTICard_CommFillW(UInt16 value, UInt32 addrval, UInt16 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommFillW(value, addrval, count, handleval);
            else
                return BTICARD_64.BTICard_CommFillW(value, addrval, count, handleval);
        }
        public static Int32 BTICard_CommProtocolFunc(UInt16 opcode, UInt16 argcount, ref UInt16 argbuf, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommProtocolFunc(opcode, argcount, ref argbuf, handleval);
            else
                return BTICARD_64.BTICard_CommProtocolFunc(opcode, argcount, ref argbuf, handleval);
        }
        public static UInt32 BTICard_CommRdL(UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommRdL(addrval, handleval);
            else
                return BTICARD_64.BTICard_CommRdL(addrval, handleval);
        }
        public static Int32 BTICard_CommRdsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommRdsW(ref valueptr, addrval, count, handleval);
            else
                return BTICARD_64.BTICard_CommRdsW(ref valueptr, addrval, count, handleval);
        }
        public static UInt16 BTICard_CommRdW(UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommRdW(addrval, handleval);
            else
                return BTICARD_64.BTICard_CommRdW(addrval, handleval);
        }
        public static Int32 BTICard_CommRun(ref UInt16 dataptr, UInt16 datacount, ref UInt16 codeptr, UInt16 codecount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommRun(ref dataptr, datacount, ref codeptr, codecount, handleval);
            else
                return BTICARD_64.BTICard_CommRun(ref dataptr, datacount, ref codeptr, codecount, handleval);
        }
        public static void BTICard_CommWrL(UInt32 value, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_CommWrL(value, addrval, handleval);
            else
                BTICARD_64.BTICard_CommWrL(value, addrval, handleval);
        }
        public static Int32 BTICard_CommWrsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CommWrsW(ref valueptr, addrval, count, handleval);
            else
                return BTICARD_64.BTICard_CommWrsW(ref valueptr, addrval, count, handleval);
        }
        public static void BTICard_CommWrW(UInt16 value, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_CommWrW(value, addrval, handleval);
            else
                BTICARD_64.BTICard_CommWrW(value, addrval, handleval);
        }
        public static Int32 BTICard_CoProcCheck(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoProcCheck(handleval);
            else
                return BTICARD_64.BTICard_CoProcCheck(handleval);
        }
        public static Int32 BTICard_CoProcGetInfo(ref UInt32 valueptr, UInt16 infotype, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoProcGetInfo(ref valueptr, infotype, handleval);
            else
                return BTICARD_64.BTICard_CoProcGetInfo(ref valueptr, infotype, handleval);
        }
        public static Int32 BTICard_CoProcMemRdL(ref UInt32 valueptr, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoProcMemRdL(ref valueptr, addrval, handleval);
            else
                return BTICARD_64.BTICard_CoProcMemRdL(ref valueptr, addrval, handleval);
        }
        public static Int32 BTICard_CoProcMemRdsL(ref UInt32 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoProcMemRdsL(ref valueptr, addrval, count, handleval);
            else
                return BTICARD_64.BTICard_CoProcMemRdsL(ref valueptr, addrval, count, handleval);
        }
        public static Int32 BTICard_CoProcMemRdsW(ref UInt16 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoProcMemRdsW(ref valueptr, addrval, count, handleval);
            else
                return BTICARD_64.BTICard_CoProcMemRdsW(ref valueptr, addrval, count, handleval);
        }
        public static Int32 BTICard_CoProcMemRdW(ref UInt16 valueptr, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoProcMemRdW(ref valueptr, addrval, handleval);
            else
                return BTICARD_64.BTICard_CoProcMemRdW(ref valueptr, addrval, handleval);
        }
        public static Int32 BTICard_CoProcMemWrL(UInt32 value, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoProcMemWrL(value, addrval, handleval);
            else
                return BTICARD_64.BTICard_CoProcMemWrL(value, addrval, handleval);
        }
        public static Int32 BTICard_CoProcMemWrsL(ref UInt32 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoProcMemWrsL(ref valueptr, addrval, count, handleval);
            else
                return BTICARD_64.BTICard_CoProcMemWrsL(ref valueptr, addrval, count, handleval);
        }
        public static Int32 BTICard_CoProcMemWrsW(ref UInt16 valueptr, UInt32 addrval, UInt32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoProcMemWrsW(ref valueptr, addrval, count, handleval);
            else
                return BTICARD_64.BTICard_CoProcMemWrsW(ref valueptr, addrval, count, handleval);
        }
        public static Int32 BTICard_CoProcMemWrW(UInt16 value, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoProcMemWrW(value, addrval, handleval);
            else
                return BTICARD_64.BTICard_CoProcMemWrW(value, addrval, handleval);
        }
        public static Int32 BTICard_CoreOpen(ref UInt32 lphcore, Int32 corenum, UInt32 hcard)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_CoreOpen(ref lphcore, corenum, hcard);
            else
                return BTICARD_64.BTICard_CoreOpen(ref lphcore, corenum, hcard);
        }
        public static void BTICard_DARClr(UInt16 maskval, UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_DARClr(maskval, addrval, handleval);
            else
                BTICARD_64.BTICard_DARClr(maskval, addrval, handleval);
        }
        public static Int32 BTICard_DARGet(UInt16 maskval, UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DARGet(maskval, addrval, handleval);
            else
                return BTICARD_64.BTICard_DARGet(maskval, addrval, handleval);
        }
        public static UInt32 BTICard_DARRdL(UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DARRdL(addrval, handleval);
            else
                return BTICARD_64.BTICard_DARRdL(addrval, handleval);
        }
        public static void BTICard_DARRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_DARRdsW(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_DARRdsW(ref valueptr, addrval, countval, handleval);
        }
        public static UInt16 BTICard_DARRdW(UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DARRdW(addrval, handleval);
            else
                return BTICARD_64.BTICard_DARRdW(addrval, handleval);
        }
        public static void BTICard_DARSet(UInt16 maskval, UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_DARSet(maskval, addrval, handleval);
            else
                BTICARD_64.BTICard_DARSet(maskval, addrval, handleval);
        }
        public static void BTICard_DARWrL(UInt32 value, UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_DARWrL(value, addrval, handleval);
            else
                BTICARD_64.BTICard_DARWrL(value, addrval, handleval);
        }
        public static void BTICard_DARWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_DARWrsW(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_DARWrsW(ref valueptr, addrval, countval, handleval);
        }
        public static void BTICard_DARWrW(UInt16 value, UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_DARWrW(value, addrval, handleval);
            else
                BTICARD_64.BTICard_DARWrW(value, addrval, handleval);
        }
        public static UInt32 BTICard_Div(UInt32 diva, UInt32 divb)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_Div(diva, divb);
            else
                return BTICARD_64.BTICard_Div(diva, divb);
        }
        public static void BTICard_Div64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_Div64(ref resulth, ref resultl, valah, valal, valbh, valbl);
            else
                BTICARD_64.BTICard_Div64(ref resulth, ref resultl, valah, valal, valbh, valbl);
        }
        public static Int32 BTICard_DllUsageCount()
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DllUsageCount();
            else
                return BTICARD_64.BTICard_DllUsageCount();
        }
        public static Int32 BTICard_DspBioClear(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DspBioClear(handleval);
            else
                return BTICARD_64.BTICard_DspBioClear(handleval);
        }
        public static Int32 BTICard_DspBioRd(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DspBioRd(handleval);
            else
                return BTICARD_64.BTICard_DspBioRd(handleval);
        }
        public static Int32 BTICard_DspBioSet(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DspBioSet(handleval);
            else
                return BTICARD_64.BTICard_DspBioSet(handleval);
        }
        public static Int32 BTICard_DspIntfClear(UInt16 intmask, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DspIntfClear(intmask, handleval);
            else
                return BTICARD_64.BTICard_DspIntfClear(intmask, handleval);
        }
        public static Int32 BTICard_DspIntfRd(UInt16 intmask, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DspIntfRd(intmask, handleval);
            else
                return BTICARD_64.BTICard_DspIntfRd(intmask, handleval);
        }
        public static Int32 BTICard_DspIntmClear(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DspIntmClear(handleval);
            else
                return BTICARD_64.BTICard_DspIntmClear(handleval);
        }
        public static Int32 BTICard_DspIntmSet(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DspIntmSet(handleval);
            else
                return BTICARD_64.BTICard_DspIntmSet(handleval);
        }
        public static Int32 BTICard_DspXfClear(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DspXfClear(handleval);
            else
                return BTICARD_64.BTICard_DspXfClear(handleval);
        }
        public static Int32 BTICard_DspXfRd(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DspXfRd(handleval);
            else
                return BTICARD_64.BTICard_DspXfRd(handleval);
        }
        public static Int32 BTICard_DspXfSet(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_DspXfSet(handleval);
            else
                return BTICARD_64.BTICard_DspXfSet(handleval);
        }
        public static unsafe string BTICard_ErrDesc(Int32 errval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ErrDesc(errval, handleval);
            else
                return BTICARD_64.BTICard_ErrDesc(errval, handleval);
        }
        public static unsafe string BTICard_ErrDescStr(Int32 errval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ErrDescStr(errval, handleval);
            else
                return BTICARD_64.BTICard_ErrDescStr(errval, handleval);
        }
        public static unsafe string BTICard_ErrName(Int32 errval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ErrName(errval, handleval);
            else
                return BTICARD_64.BTICard_ErrName(errval, handleval);
        }
        public static Int32 BTICard_EventLogClear(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_EventLogClear(handleval);
            else
                return BTICARD_64.BTICard_EventLogClear(handleval);
        }
        public static Int32 BTICard_EventLogConfig(UInt16 configval, UInt16 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_EventLogConfig(configval, count, handleval);
            else
                return BTICARD_64.BTICard_EventLogConfig(configval, count, handleval);
        }
        public static UInt32 BTICard_EventLogRd(ref UInt16 typevalval, ref UInt32 infoval, ref Int32 channel, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_EventLogRd(ref typevalval, ref infoval, ref channel, handleval);
            else
                return BTICARD_64.BTICard_EventLogRd(ref typevalval, ref infoval, ref channel, handleval);
        }
        public static Int32 BTICard_EventLogStatus(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_EventLogStatus(handleval);
            else
                return BTICARD_64.BTICard_EventLogStatus(handleval);
        }
        public static void BTICard_ExpandMant(ref UInt32 mant, ref Int32 exp)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ExpandMant(ref mant, ref exp);
            else
                BTICARD_64.BTICard_ExpandMant(ref mant, ref exp);
        }
        public static Int32 BTICard_ExtDinRd(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ExtDinRd(handleval);
            else
                return BTICARD_64.BTICard_ExtDinRd(handleval);
        }
        public static void BTICard_ExtDinWr(Int32 dinval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ExtDinWr(dinval, handleval);
            else
                BTICARD_64.BTICard_ExtDinWr(dinval, handleval);
        }
        public static void BTICard_ExtDIODirSet(Int32 dionum, Int32 dirval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ExtDIODirSet(dionum, dirval, handleval);
            else
                BTICARD_64.BTICard_ExtDIODirSet(dionum, dirval, handleval);
        }
        public static Int32 BTICard_ExtDIOMonConfig(UInt16 rise_edge, UInt16 fall_edge, Int32 banknum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ExtDIOMonConfig(rise_edge, fall_edge, banknum, handleval);
            else
                return BTICARD_64.BTICard_ExtDIOMonConfig(rise_edge, fall_edge, banknum, handleval);
        }
        public static Int32 BTICard_ExtDIORd(Int32 dionum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ExtDIORd(dionum, handleval);
            else
                return BTICARD_64.BTICard_ExtDIORd(dionum, handleval);
        }
        public static void BTICard_ExtDIOWr(Int32 dionum, Int32 dioval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ExtDIOWr(dionum, dioval, handleval);
            else
                BTICARD_64.BTICard_ExtDIOWr(dionum, dioval, handleval);
        }
        public static Int32 BTICard_ExtLEDRd(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ExtLEDRd(handleval);
            else
                return BTICARD_64.BTICard_ExtLEDRd(handleval);
        }
        public static void BTICard_ExtLEDWr(Int32 ledval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ExtLEDWr(ledval, handleval);
            else
                BTICARD_64.BTICard_ExtLEDWr(ledval, handleval);
        }
        public static void BTICard_ExtStatusLEDRd(ref Int32 ledon, ref Int32 ledcolor, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ExtStatusLEDRd(ref ledon, ref ledcolor, handleval);
            else
                BTICARD_64.BTICard_ExtStatusLEDRd(ref ledon, ref ledcolor, handleval);
        }
        public static void BTICard_ExtStatusLEDWr(Int32 ledon, Int32 ledcolor, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ExtStatusLEDWr(ledon, ledcolor, handleval);
            else
                BTICARD_64.BTICard_ExtStatusLEDWr(ledon, ledcolor, handleval);
        }
        public static void BTICard_FileClose(IntPtr handle)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_FileClose(handle);
            else
                BTICARD_64.BTICard_FileClose(handle);
        }
        public static Int32 BTICard_FileErr()
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_FileErr();
            else
                return BTICARD_64.BTICard_FileErr();
        }
        public static void BTICard_FileErrClr()
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_FileErrClr();
            else
                BTICARD_64.BTICard_FileErrClr();
        }
        public static void BTICard_FileErrSet()
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_FileErrSet();
            else
                BTICARD_64.BTICard_FileErrSet();
        }
        public static unsafe IntPtr* BTICard_FileOpenRead(ref string filename)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_FileOpenRead(ref filename);
            else
                return BTICARD_64.BTICard_FileOpenRead(ref filename);
        }
        public static unsafe IntPtr* BTICard_FileOpenWrite(ref string filename)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_FileOpenWrite(ref filename);
            else
                return BTICARD_64.BTICard_FileOpenWrite(ref filename);
        }
        public static Int32 BTICard_FileRead(IntPtr handle, IntPtr buffer, UInt16 count)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_FileRead(handle, buffer, count);
            else
                return BTICARD_64.BTICard_FileRead(handle, buffer, count);
        }
        public static Int32 BTICard_FileSeek(IntPtr handle, UInt32 offset)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_FileSeek(handle, offset);
            else
                return BTICARD_64.BTICard_FileSeek(handle, offset);
        }
        public static UInt32 BTICard_FileTell(IntPtr handle)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_FileTell(handle);
            else
                return BTICARD_64.BTICard_FileTell(handle);
        }
        public static Int32 BTICard_FileWrite(IntPtr handle, IntPtr buffer, UInt16 count)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_FileWrite(handle, buffer, count);
            else
                return BTICARD_64.BTICard_FileWrite(handle, buffer, count);
        }
        public static UInt16 BTICard_GetHigh(UInt32 val)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_GetHigh(val);
            else
                return BTICARD_64.BTICard_GetHigh(val);
        }
        public static UInt16 BTICard_GetLow(UInt32 val)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_GetLow(val);
            else
                return BTICARD_64.BTICard_GetLow(val);
        }
        public static UInt16 BTICard_GlobalRdW(UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_GlobalRdW(addrval, handleval);
            else
                return BTICARD_64.BTICard_GlobalRdW(addrval, handleval);
        }
        public static void BTICard_GlobalWrW(UInt16 value, UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_GlobalWrW(value, addrval, handleval);
            else
                BTICARD_64.BTICard_GlobalWrW(value, addrval, handleval);
        }
        unsafe public static Int32 BTICard_HandleInfo(ref string cardstr, ref Int32 cardnum, ref UInt32 sizval, IntPtr* vxdptr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HandleInfo(ref cardstr, ref cardnum, ref sizval, vxdptr, handleval);
            else
                return BTICARD_64.BTICard_HandleInfo(ref cardstr, ref cardnum, ref sizval, vxdptr, handleval);
        }
        public static Int32 BTICard_HandleInfoEx(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HandleInfoEx(ref valueptr, typeval, handleval);
            else
                return BTICARD_64.BTICard_HandleInfoEx(ref valueptr, typeval, handleval);
        }
        public static Int32 BTICard_HandleIsCard(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HandleIsCard(handleval);
            else
                return BTICARD_64.BTICard_HandleIsCard(handleval);
        }
        public static Int32 BTICard_HandleIsCore(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HandleIsCore(handleval);
            else
                return BTICARD_64.BTICard_HandleIsCore(handleval);
        }
        public static Int32 BTICard_HandleMakeCard(ref UInt32 lphcard, ref Int32 lpcorenum, UInt32 hcore)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HandleMakeCard(ref lphcard, ref lpcorenum, hcore);
            else
                return BTICARD_64.BTICard_HandleMakeCard(ref lphcard, ref lpcorenum, hcore);
        }
        public static Int32 BTICard_HandleMakeCore(ref UInt32 lphcore, Int32 corenum, UInt32 hcard)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HandleMakeCore(ref lphcore, corenum, hcard);
            else
                return BTICARD_64.BTICard_HandleMakeCore(ref lphcore, corenum, hcard);
        }
        public static Int32 BTICard_HandleMakeRPC(ref UInt32 hcard_remote, ref UInt32 lphrpc, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HandleMakeRPC(ref hcard_remote, ref lphrpc, handleval);
            else
                return BTICARD_64.BTICard_HandleMakeRPC(ref hcard_remote, ref lphrpc, handleval);
        }
        public static Int32 BTICard_HandleOkay(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HandleOkay(handleval);
            else
                return BTICARD_64.BTICard_HandleOkay(handleval);
        }
        public static UInt32 BTICard_HeapAlloc(Int32 section, UInt32 wordcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HeapAlloc(section, wordcount, handleval);
            else
                return BTICARD_64.BTICard_HeapAlloc(section, wordcount, handleval);
        }
        public static UInt32 BTICard_HeapAllocAll(Int32 section, ref UInt32 wordcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HeapAllocAll(section, ref wordcount, handleval);
            else
                return BTICARD_64.BTICard_HeapAllocAll(section, ref wordcount, handleval);
        }
        public static UInt32 BTICard_HeapAllocEx(UInt16 configval, Int32 section, UInt32 wordcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HeapAllocEx(configval, section, wordcount, handleval);
            else
                return BTICARD_64.BTICard_HeapAllocEx(configval, section, wordcount, handleval);
        }
        public static UInt32 BTICard_HeapWipe(Int32 section, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HeapWipe(section, handleval);
            else
                return BTICARD_64.BTICard_HeapWipe(section, handleval);
        }
        public static void BTICard_HPIFill(UInt16 value, UInt16 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_HPIFill(value, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_HPIFill(value, addrval, countval, handleval);
        }
        public static UInt32 BTICard_HPIRdL(UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HPIRdL(addrval, handleval);
            else
                return BTICARD_64.BTICard_HPIRdL(addrval, handleval);
        }
        public static void BTICard_HPIRdsL(ref UInt32 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_HPIRdsL(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_HPIRdsL(ref valueptr, addrval, countval, handleval);
        }
        public static void BTICard_HPIRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_HPIRdsW(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_HPIRdsW(ref valueptr, addrval, countval, handleval);
        }
        public static UInt16 BTICard_HPIRdW(UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_HPIRdW(addrval, handleval);
            else
                return BTICARD_64.BTICard_HPIRdW(addrval, handleval);
        }
        public static void BTICard_HPIWrL(UInt32 value, UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_HPIWrL(value, addrval, handleval);
            else
                BTICARD_64.BTICard_HPIWrL(value, addrval, handleval);
        }
        public static void BTICard_HPIWrsL(ref UInt32 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_HPIWrsL(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_HPIWrsL(ref valueptr, addrval, countval, handleval);
        }
        public static void BTICard_HPIWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_HPIWrsW(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_HPIWrsW(ref valueptr, addrval, countval, handleval);
        }
        public static void BTICard_HPIWrW(UInt16 value, UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_HPIWrW(value, addrval, handleval);
            else
                BTICARD_64.BTICard_HPIWrW(value, addrval, handleval);
        }
        public static UInt16 BTICard_IDRegRd(Int32 gate_array_num, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IDRegRd(gate_array_num, handleval);
            else
                return BTICARD_64.BTICard_IDRegRd(gate_array_num, handleval);
        }
        public static void BTICard_IDRegWr(UInt16 value, Int32 gate_array_num, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IDRegWr(value, gate_array_num, handleval);
            else
                BTICARD_64.BTICard_IDRegWr(value, gate_array_num, handleval);
        }
        public static void BTICard_IntClear(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IntClear(handleval);
            else
                BTICARD_64.BTICard_IntClear(handleval);
        }
        public static Int32 BTICard_IntDisable(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IntDisable(handleval);
            else
                return BTICARD_64.BTICard_IntDisable(handleval);
        }
        public static Int32 BTICard_IntEnable(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IntEnable(handleval);
            else
                return BTICARD_64.BTICard_IntEnable(handleval);
        }
        public static Int32 BTICard_IntEnableCond(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IntEnableCond(handleval);
            else
                return BTICARD_64.BTICard_IntEnableCond(handleval);
        }
        public static unsafe IntPtr* BTICard_IntGet(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IntGet(handleval);
            else
                return BTICARD_64.BTICard_IntGet(handleval);
        }
        public static Int32 BTICard_IntInstall(IntPtr hevent, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IntInstall(hevent, handleval);
            else
                return BTICARD_64.BTICard_IntInstall(hevent, handleval);
        }
        public static void BTICard_IntReset(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IntReset(handleval);
            else
                BTICARD_64.BTICard_IntReset(handleval);
        }
        public static Int32 BTICard_IntUninstall(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IntUninstall(handleval);
            else
                return BTICARD_64.BTICard_IntUninstall(handleval);
        }
        public static UInt32 BTICard_IORdL(Int32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IORdL(addrval, handleval);
            else
                return BTICARD_64.BTICard_IORdL(addrval, handleval);
        }
        public static UInt16 BTICard_IORdW(Int32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IORdW(addrval, handleval);
            else
                return BTICARD_64.BTICard_IORdW(addrval, handleval);
        }
        public static UInt16 BTICard_IOWINRdW(Int32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IOWINRdW(addrval, handleval);
            else
                return BTICARD_64.BTICard_IOWINRdW(addrval, handleval);
        }
        public static void BTICard_IOWINWrW(UInt16 value, Int32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IOWINWrW(value, addrval, handleval);
            else
                BTICARD_64.BTICard_IOWINWrW(value, addrval, handleval);
        }
        public static void BTICard_IOWrL(UInt32 value, Int32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IOWrL(value, addrval, handleval);
            else
                BTICARD_64.BTICard_IOWrL(value, addrval, handleval);
        }
        public static void BTICard_IOWrW(UInt16 value, Int32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IOWrW(value, addrval, handleval);
            else
                BTICARD_64.BTICard_IOWrW(value, addrval, handleval);
        }
        public static Int32 BTICard_IRIGConfig(UInt32 configval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGConfig(configval, handleval);
            else
                return BTICARD_64.BTICard_IRIGConfig(configval, handleval);
        }
        public static UInt32 BTICard_IRIGFieldGetDays(UInt32 irigvalh, UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGFieldGetDays(irigvalh, irigvall);
            else
                return BTICARD_64.BTICard_IRIGFieldGetDays(irigvalh, irigvall);
        }
        public static UInt32 BTICard_IRIGFieldGetHours(UInt32 irigvalh, UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGFieldGetHours(irigvalh, irigvall);
            else
                return BTICARD_64.BTICard_IRIGFieldGetHours(irigvalh, irigvall);
        }
        public static UInt32 BTICard_IRIGFieldGetMicrosec(UInt32 irigvalh, UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGFieldGetMicrosec(irigvalh, irigvall);
            else
                return BTICARD_64.BTICard_IRIGFieldGetMicrosec(irigvalh, irigvall);
        }
        public static UInt32 BTICard_IRIGFieldGetMillisec(UInt32 irigvalh, UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGFieldGetMillisec(irigvalh, irigvall);
            else
                return BTICARD_64.BTICard_IRIGFieldGetMillisec(irigvalh, irigvall);
        }
        public static UInt32 BTICard_IRIGFieldGetMin(UInt32 irigvalh, UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGFieldGetMin(irigvalh, irigvall);
            else
                return BTICARD_64.BTICard_IRIGFieldGetMin(irigvalh, irigvall);
        }
        public static UInt32 BTICard_IRIGFieldGetSec(UInt32 irigvalh, UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGFieldGetSec(irigvalh, irigvall);
            else
                return BTICARD_64.BTICard_IRIGFieldGetSec(irigvalh, irigvall);
        }
        public static void BTICard_IRIGFieldPutDays(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IRIGFieldPutDays(value, ref irigvalh, ref irigvall);
            else
                BTICARD_64.BTICard_IRIGFieldPutDays(value, ref irigvalh, ref irigvall);
        }
        public static void BTICard_IRIGFieldPutHours(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IRIGFieldPutHours(value, ref irigvalh, ref irigvall);
            else
                BTICARD_64.BTICard_IRIGFieldPutHours(value, ref irigvalh, ref irigvall);
        }
        public static void BTICard_IRIGFieldPutMicrosec(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IRIGFieldPutMicrosec(value, ref irigvalh, ref irigvall);
            else
                BTICARD_64.BTICard_IRIGFieldPutMicrosec(value, ref irigvalh, ref irigvall);
        }
        public static void BTICard_IRIGFieldPutMillisec(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IRIGFieldPutMillisec(value, ref irigvalh, ref irigvall);
            else
                BTICARD_64.BTICard_IRIGFieldPutMillisec(value, ref irigvalh, ref irigvall);
        }
        public static void BTICard_IRIGFieldPutMin(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IRIGFieldPutMin(value, ref irigvalh, ref irigvall);
            else
                BTICARD_64.BTICard_IRIGFieldPutMin(value, ref irigvalh, ref irigvall);
        }
        public static void BTICard_IRIGFieldPutSec(UInt32 value, ref UInt32 irigvalh, ref UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IRIGFieldPutSec(value, ref irigvalh, ref irigvall);
            else
                BTICARD_64.BTICard_IRIGFieldPutSec(value, ref irigvalh, ref irigvall);
        }
        public static Int32 BTICard_IRIGInputThresholdGet(ref UInt16 dacval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGInputThresholdGet(ref dacval, handleval);
            else
                return BTICARD_64.BTICard_IRIGInputThresholdGet(ref dacval, handleval);
        }
        public static Int32 BTICard_IRIGInputThresholdSet(UInt16 dacval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGInputThresholdSet(dacval, handleval);
            else
                return BTICARD_64.BTICard_IRIGInputThresholdSet(dacval, handleval);
        }
        public static Int32 BTICard_IRIGRd(ref BTIIRIGTIME irigtime, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGRd(ref irigtime, handleval);
            else
                return BTICARD_64.BTICard_IRIGRd(ref irigtime, handleval);
        }
        public static Int32 BTICard_IRIGRdEx(ref UInt16 timebuf, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGRdEx(ref timebuf, handleval);
            else
                return BTICARD_64.BTICard_IRIGRdEx(ref timebuf, handleval);
        }
        public static Int32 BTICard_IRIGSyncStatus(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGSyncStatus(handleval);
            else
                return BTICARD_64.BTICard_IRIGSyncStatus(handleval);
        }
        public static void BTICard_IRIGTimeBCDToBin(ref UInt32 timevalh, ref UInt32 timevall, UInt32 irigvalh, UInt32 irigvall)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IRIGTimeBCDToBin(ref timevalh, ref timevall, irigvalh, irigvall);
            else
                BTICARD_64.BTICard_IRIGTimeBCDToBin(ref timevalh, ref timevall, irigvalh, irigvall);
        }
        public static void BTICard_IRIGTimeBinToBCD(ref UInt32 irigvalh, ref UInt32 irigvall, UInt32 timevalh, UInt32 timevall)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_IRIGTimeBinToBCD(ref irigvalh, ref irigvall, timevalh, timevall);
            else
                BTICARD_64.BTICard_IRIGTimeBinToBCD(ref irigvalh, ref irigvall, timevalh, timevall);
        }
        public static Int32 BTICard_IRIGWr(ref BTIIRIGTIME irigtime, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGWr(ref irigtime, handleval);
            else
                return BTICARD_64.BTICard_IRIGWr(ref irigtime, handleval);
        }
        public static Int32 BTICard_IRIGWrEx(ref UInt16 timebuf, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_IRIGWrEx(ref timebuf, handleval);
            else
                return BTICARD_64.BTICard_IRIGWrEx(ref timebuf, handleval);
        }
        public static Int32 BTICard_KernIntStatus(ref Int32 valueptr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_KernIntStatus(ref valueptr, handleval);
            else
                return BTICARD_64.BTICard_KernIntStatus(ref valueptr, handleval);
        }
        public static Int32 BTICard_KernStatus(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_KernStatus(ref valueptr, typeval, handleval);
            else
                return BTICARD_64.BTICard_KernStatus(ref valueptr, typeval, handleval);
        }
        public static Int32 BTICard_KernStatusEx(ref UInt32 valueptr, UInt32 typeval, UInt32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_KernStatusEx(ref valueptr, typeval, index, handleval);
            else
                return BTICARD_64.BTICard_KernStatusEx(ref valueptr, typeval, index, handleval);
        }
        public static UInt32 BTICard_MakeLong(UInt16 valh, UInt16 vall)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_MakeLong(valh, vall);
            else
                return BTICARD_64.BTICard_MakeLong(valh, vall);
        }
        public static UInt16 BTICard_MakeWord(byte valh, byte vall)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_MakeWord(valh, vall);
            else
                return BTICARD_64.BTICard_MakeWord(valh, vall);
        }
        public static unsafe string BTICard_MantToAscii(ref string buf, Int32 mant, Int32 exp)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_MantToAscii(ref buf, mant, exp);
            else
                return BTICARD_64.BTICard_MantToAscii(ref buf, mant, exp);
        }
        public static UInt32 BTICard_Mask(UInt32 dataval, UInt16 cntval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_Mask(dataval, cntval);
            else
                return BTICARD_64.BTICard_Mask(dataval, cntval);
        }
        public static void BTICard_MaxMant(ref UInt32 mant, ref Int32 exp)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_MaxMant(ref mant, ref exp);
            else
                BTICARD_64.BTICard_MaxMant(ref mant, ref exp);
        }
        public static UInt32 BTICard_Mod(UInt32 moda, UInt32 modb)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_Mod(moda, modb);
            else
                return BTICARD_64.BTICard_Mod(moda, modb);
        }
        public static void BTICard_Mod64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_Mod64(ref resulth, ref resultl, valah, valal, valbh, valbl);
            else
                BTICARD_64.BTICard_Mod64(ref resulth, ref resultl, valah, valal, valbh, valbl);
        }
        public static UInt32 BTICard_Mul(UInt32 mula, UInt32 mulb)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_Mul(mula, mulb);
            else
                return BTICARD_64.BTICard_Mul(mula, mulb);
        }
        public static void BTICard_Mul64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_Mul64(ref resulth, ref resultl, valah, valal, valbh, valbl);
            else
                BTICARD_64.BTICard_Mul64(ref resulth, ref resultl, valah, valal, valbh, valbl);
        }
        public static void BTICard_NormalMant(ref UInt32 mant, ref Int32 exp)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_NormalMant(ref mant, ref exp);
            else
                BTICARD_64.BTICard_NormalMant(ref mant, ref exp);
        }
        public static UInt16 BTICard_PortRd(Int32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_PortRd(addrval, handleval);
            else
                return BTICARD_64.BTICard_PortRd(addrval, handleval);
        }
        public static void BTICard_PortWr(UInt16 value, Int32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_PortWr(value, addrval, handleval);
            else
                BTICARD_64.BTICard_PortWr(value, addrval, handleval);
        }
        public static UInt16 BTICard_ProgRdW(UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ProgRdW(addrval, handleval);
            else
                return BTICARD_64.BTICard_ProgRdW(addrval, handleval);
        }
        public static void BTICard_ProgWrW(UInt16 value, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ProgWrW(value, addrval, handleval);
            else
                BTICARD_64.BTICard_ProgWrW(value, addrval, handleval);
        }
        public static void BTICard_RAMFill(UInt16 value, UInt32 addrval, UInt32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMFill(value, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_RAMFill(value, addrval, countval, handleval);
        }
        public static UInt16 BTICard_RAMRdB(UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_RAMRdB(addrval, handleval);
            else
                return BTICARD_64.BTICard_RAMRdB(addrval, handleval);
        }
        public static UInt32 BTICard_RAMRdL(UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_RAMRdL(addrval, handleval);
            else
                return BTICARD_64.BTICard_RAMRdL(addrval, handleval);
        }
        public static void BTICard_RAMRdmL(ref UInt32 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMRdmL(ref valueptr, ref addrptr, countval, handleval);
            else
                BTICARD_64.BTICard_RAMRdmL(ref valueptr, ref addrptr, countval, handleval);
        }
        public static void BTICard_RAMRdmW(ref UInt16 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMRdmW(ref valueptr, ref addrptr, countval, handleval);
            else
                BTICARD_64.BTICard_RAMRdmW(ref valueptr, ref addrptr, countval, handleval);
        }
        public static void BTICard_RAMRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMRdsL(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_RAMRdsL(ref valueptr, addrval, countval, handleval);
        }
        public static void BTICard_RAMRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMRdsW(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_RAMRdsW(ref valueptr, addrval, countval, handleval);
        }
        public static UInt16 BTICard_RAMRdW(UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_RAMRdW(addrval, handleval);
            else
                return BTICARD_64.BTICard_RAMRdW(addrval, handleval);
        }
        public static void BTICard_RAMWipe(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMWipe(handleval);
            else
                BTICARD_64.BTICard_RAMWipe(handleval);
        }
        public static void BTICard_RAMWipeEx(UInt16 value, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMWipeEx(value, handleval);
            else
                BTICARD_64.BTICard_RAMWipeEx(value, handleval);
        }
        public static void BTICard_RAMWrB(UInt16 value, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMWrB(value, addrval, handleval);
            else
                BTICARD_64.BTICard_RAMWrB(value, addrval, handleval);
        }
        public static void BTICard_RAMWrL(UInt32 value, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMWrL(value, addrval, handleval);
            else
                BTICARD_64.BTICard_RAMWrL(value, addrval, handleval);
        }
        public static void BTICard_RAMWrmL(ref UInt32 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMWrmL(ref valueptr, ref addrptr, countval, handleval);
            else
                BTICARD_64.BTICard_RAMWrmL(ref valueptr, ref addrptr, countval, handleval);
        }
        public static void BTICard_RAMWrmW(ref UInt16 valueptr, ref UInt32 addrptr, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMWrmW(ref valueptr, ref addrptr, countval, handleval);
            else
                BTICARD_64.BTICard_RAMWrmW(ref valueptr, ref addrptr, countval, handleval);
        }
        public static void BTICard_RAMWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMWrsL(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_RAMWrsL(ref valueptr, addrval, countval, handleval);
        }
        public static void BTICard_RAMWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMWrsW(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_RAMWrsW(ref valueptr, addrval, countval, handleval);
        }
        public static void BTICard_RAMWrW(UInt16 value, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_RAMWrW(value, addrval, handleval);
            else
                BTICARD_64.BTICard_RAMWrW(value, addrval, handleval);
        }
        public static UInt32 BTICard_ReverseLong(UInt32 value)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ReverseLong(value);
            else
                return BTICARD_64.BTICard_ReverseLong(value);
        }
        public static UInt16 BTICard_ReverseWord(UInt16 value)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ReverseWord(value);
            else
                return BTICARD_64.BTICard_ReverseWord(value);
        }
        public static UInt32 BTICard_SeqBlkRd(ref UInt16 buf, UInt32 bufcount, ref UInt32 blkcnt, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqBlkRd(ref buf, bufcount, ref blkcnt, handleval);
            else
                return BTICARD_64.BTICard_SeqBlkRd(ref buf, bufcount, ref blkcnt, handleval);
        }
        public static UInt32 BTICard_SeqBlkRdEx(ref UInt16 buf, UInt32 bufcount, UInt32 maxblkcnt, ref UInt32 blkcnt, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqBlkRdEx(ref buf, bufcount, maxblkcnt, ref blkcnt, handleval);
            else
                return BTICARD_64.BTICard_SeqBlkRdEx(ref buf, bufcount, maxblkcnt, ref blkcnt, handleval);
        }
        public static Int32 BTICard_SeqClear(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqClear(handleval);
            else
                return BTICARD_64.BTICard_SeqClear(handleval);
        }
        public static UInt16 BTICard_SeqCommRd(ref UInt16 buf, UInt16 bufcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqCommRd(ref buf, bufcount, handleval);
            else
                return BTICARD_64.BTICard_SeqCommRd(ref buf, bufcount, handleval);
        }
        public static Int32 BTICard_SeqConfig(UInt32 configval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqConfig(configval, handleval);
            else
                return BTICARD_64.BTICard_SeqConfig(configval, handleval);
        }
        public static Int32 BTICard_SeqConfigEx(UInt32 configval, UInt32 seqcount, UInt16 cardnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqConfigEx(configval, seqcount, cardnum, handleval);
            else
                return BTICARD_64.BTICard_SeqConfigEx(configval, seqcount, cardnum, handleval);
        }
        public static Int32 BTICard_SeqConfigExx(UInt32 configval, UInt32 seqaddr, UInt32 seqcount, UInt16 cardnum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqConfigExx(configval, seqaddr, seqcount, cardnum, handleval);
            else
                return BTICARD_64.BTICard_SeqConfigExx(configval, seqaddr, seqcount, cardnum, handleval);
        }
        public static UInt32 BTICard_SeqDMARd(ref UInt16 buf, UInt32 bufcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqDMARd(ref buf, bufcount, handleval);
            else
                return BTICARD_64.BTICard_SeqDMARd(ref buf, bufcount, handleval);
        }
        public static Int32 BTICard_SeqFindCheckVersion(ref UInt16 precord, UInt16 version)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindCheckVersion(ref precord, version);
            else
                return BTICARD_64.BTICard_SeqFindCheckVersion(ref precord, version);
        }
        public static Int32 BTICard_SeqFindInit(ref UInt16 seqbuf, UInt32 seqbufsize, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindInit(ref seqbuf, seqbufsize, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindInit(ref seqbuf, seqbufsize, ref sfinfo);
        }
        unsafe public static Int32 BTICard_SeqFindMore1553(ref SEQRECORDMORE1553* precmore, ref SEQRECORD1553 precbase)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindMore1553(ref precmore, ref precbase);
            else
                return BTICARD_64.BTICard_SeqFindMore1553(ref precmore, ref precbase);
        }
        public static Int32 BTICard_SeqFindMore1553Ex(ref SEQRECORDMORE1553 precmore, UInt16 recordsize, ref SEQRECORD1553 precbase)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindMore1553Ex(ref precmore, recordsize, ref precbase);
            else
                return BTICARD_64.BTICard_SeqFindMore1553Ex(ref precmore, recordsize, ref precbase);
        }
        unsafe public static Int32 BTICard_SeqFindNext(ref UInt16* precord, ref UInt16 seqtype, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNext(ref precord, ref seqtype, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNext(ref precord, ref seqtype, ref sfinfo);
        }
        unsafe public static Int32 BTICard_SeqFindNext1553(ref SEQRECORD1553* precord, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNext1553(ref precord, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNext1553(ref precord, ref sfinfo);
        }
        public static Int32 BTICard_SeqFindNext1553Ex(ref SEQRECORD1553 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNext1553Ex(ref precord, recordsize, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNext1553Ex(ref precord, recordsize, ref sfinfo);
        }
        unsafe public static Int32 BTICard_SeqFindNext429(ref SEQRECORD429* precord, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNext429(ref precord, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNext429(ref precord, ref sfinfo);
        }
        public static Int32 BTICard_SeqFindNext429Ex(ref SEQRECORD429 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNext429Ex(ref precord, recordsize, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNext429Ex(ref precord, recordsize, ref sfinfo);
        }
        unsafe public static Int32 BTICard_SeqFindNext708(ref SEQRECORD708* precord, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNext708(ref precord, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNext708(ref precord, ref sfinfo);
        }
        public static Int32 BTICard_SeqFindNext708Ex(ref SEQRECORD708 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNext708Ex(ref precord, recordsize, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNext708Ex(ref precord, recordsize, ref sfinfo);
        }
        unsafe public static Int32 BTICard_SeqFindNext717(ref SEQRECORD717* precord, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNext717(ref precord, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNext717(ref precord, ref sfinfo);
        }
        public static Int32 BTICard_SeqFindNext717Ex(ref SEQRECORD717 precord, UInt16 recordsize, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNext717Ex(ref precord, recordsize, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNext717Ex(ref precord, recordsize, ref sfinfo);
        }
        unsafe public static Int32 BTICard_SeqFindNextCSDB(ref SEQRECORDCSDB* precord, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNextCSDB(ref precord, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNextCSDB(ref precord, ref sfinfo);
        }
        public static Int32 BTICard_SeqFindNextCSDBEx(ref SEQRECORDCSDB precord, UInt16 recordsize, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNextCSDBEx(ref precord, recordsize, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNextCSDBEx(ref precord, recordsize, ref sfinfo);
        }
        unsafe public static Int32 BTICard_SeqFindNextDIO(ref SEQRECORDDIO* precord, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNextDIO(ref precord, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNextDIO(ref precord, ref sfinfo);
        }
        public static Int32 BTICard_SeqFindNextDIOEx(ref SEQRECORDDIO precord, UInt16 recordsize, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNextDIOEx(ref precord, recordsize, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNextDIOEx(ref precord, recordsize, ref sfinfo);
        }
        public static Int32 BTICard_SeqFindNextEx(ref UInt16 precord, UInt16 recordcount, ref UInt16 seqtype, ref SEQFINDINFO sfinfo)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqFindNextEx(ref precord, recordcount, ref seqtype, ref sfinfo);
            else
                return BTICARD_64.BTICard_SeqFindNextEx(ref precord, recordcount, ref seqtype, ref sfinfo);
        }
        public static Int32 BTICard_SeqInterval(Int32 interval, Int32 mode, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqInterval(interval, mode, handleval);
            else
                return BTICARD_64.BTICard_SeqInterval(interval, mode, handleval);
        }
        public static UInt16 BTICard_SeqIntervalEx(UInt16 shiftval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqIntervalEx(shiftval, handleval);
            else
                return BTICARD_64.BTICard_SeqIntervalEx(shiftval, handleval);
        }
        public static Int32 BTICard_SeqIsRunning(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqIsRunning(handleval);
            else
                return BTICARD_64.BTICard_SeqIsRunning(handleval);
        }
        public static UInt16 BTICard_SeqLogFrequency(UInt16 logfreq, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqLogFrequency(logfreq, handleval);
            else
                return BTICARD_64.BTICard_SeqLogFrequency(logfreq, handleval);
        }
        public static UInt16 BTICard_SeqRd(ref UInt16 buf, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqRd(ref buf, handleval);
            else
                return BTICARD_64.BTICard_SeqRd(ref buf, handleval);
        }
        public static UInt16 BTICard_SeqRdEx(ref UInt16 buf, UInt16 bufcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqRdEx(ref buf, bufcount, handleval);
            else
                return BTICARD_64.BTICard_SeqRdEx(ref buf, bufcount, handleval);
        }
        public static Int32 BTICard_SeqResume(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqResume(handleval);
            else
                return BTICARD_64.BTICard_SeqResume(handleval);
        }
        public static Int32 BTICard_SeqStart(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqStart(handleval);
            else
                return BTICARD_64.BTICard_SeqStart(handleval);
        }
        public static Int32 BTICard_SeqStatus(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqStatus(handleval);
            else
                return BTICARD_64.BTICard_SeqStatus(handleval);
        }
        public static Int32 BTICard_SeqStop(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SeqStop(handleval);
            else
                return BTICARD_64.BTICard_SeqStop(handleval);
        }
        public static UInt32 BTICard_Shl(UInt32 dataval, UInt16 cntval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_Shl(dataval, cntval);
            else
                return BTICARD_64.BTICard_Shl(dataval, cntval);
        }
        public static UInt32 BTICard_Shr(UInt32 dataval, UInt16 cntval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_Shr(dataval, cntval);
            else
                return BTICARD_64.BTICard_Shr(dataval, cntval);
        }
        public static UInt16 BTICard_SignMant(ref string str)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SignMant(ref str);
            else
                return BTICARD_64.BTICard_SignMant(ref str);
        }
        public static void BTICard_Sub64(ref UInt32 resulth, ref UInt32 resultl, UInt32 valah, UInt32 valal, UInt32 valbh, UInt32 valbl)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_Sub64(ref resulth, ref resultl, valah, valal, valbh, valbl);
            else
                BTICARD_64.BTICard_Sub64(ref resulth, ref resultl, valah, valal, valbh, valbl);
        }
        public static void BTICard_SwapEndianL(ref UInt32 value)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_SwapEndianL(ref value);
            else
                BTICARD_64.BTICard_SwapEndianL(ref value);
        }
        public static void BTICard_SwapEndianW(ref UInt16 valuea, ref UInt16 valueb)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_SwapEndianW(ref valuea, ref valueb);
            else
                BTICARD_64.BTICard_SwapEndianW(ref valuea, ref valueb);
        }
        public static void BTICard_SwapIfBigEndianL(ref UInt32 value)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_SwapIfBigEndianL(ref value);
            else
                BTICARD_64.BTICard_SwapIfBigEndianL(ref value);
        }
        public static void BTICard_SwapIfBigEndianW(ref UInt16 valuea, ref UInt16 valueb)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_SwapIfBigEndianW(ref valuea, ref valueb);
            else
                BTICARD_64.BTICard_SwapIfBigEndianW(ref valuea, ref valueb);
        }
        public static void BTICard_SwapIfLittleEndianL(ref UInt32 value)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_SwapIfLittleEndianL(ref value);
            else
                BTICARD_64.BTICard_SwapIfLittleEndianL(ref value);
        }
        public static void BTICard_SwapIfLittleEndianW(ref UInt16 valuea, ref UInt16 valueb)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_SwapIfLittleEndianW(ref valuea, ref valueb);
            else
                BTICARD_64.BTICard_SwapIfLittleEndianW(ref valuea, ref valueb);
        }
        public static Int32 BTICard_SysMonClear(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonClear(handleval);
            else
                return BTICARD_64.BTICard_SysMonClear(handleval);
        }
        public static Int32 BTICard_SysMonInit(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonInit(handleval);
            else
                return BTICARD_64.BTICard_SysMonInit(handleval);
        }
        public static UInt32 BTICard_SysMonTypeGet(Int32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonTypeGet(index, handleval);
            else
                return BTICARD_64.BTICard_SysMonTypeGet(index, handleval);
        }
        public static unsafe string BTICard_SysMonDescGet(Int32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonDescGet(index, handleval);
            else
                return BTICARD_64.BTICard_SysMonDescGet(index, handleval);
        }
        public static Int32 BTICard_SysMonMaxRd(Int32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonMaxRd(index, handleval);
            else
                return BTICARD_64.BTICard_SysMonMaxRd(index, handleval);
        }
        public static Int32 BTICard_SysMonMinRd(Int32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonMinRd(index, handleval);
            else
                return BTICARD_64.BTICard_SysMonMinRd(index, handleval);
        }
        public static Int32 BTICard_SysMonNomRd(Int32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonNomRd(index, handleval);
            else
                return BTICARD_64.BTICard_SysMonNomRd(index, handleval);
        }
        public static unsafe string BTICard_SysMonUserStr(Int32 value, Int32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonUserStr(value, index, handleval);
            else
                return BTICARD_64.BTICard_SysMonUserStr(value, index, handleval);
        }
        public static Int32 BTICard_SysMonValRd(Int32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonValRd(index, handleval);
            else
                return BTICARD_64.BTICard_SysMonValRd(index, handleval);
        }
        public static unsafe string BTICard_SysMonValStr(Int32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonValStr(index, handleval);
            else
                return BTICARD_64.BTICard_SysMonValStr(index, handleval);
        }
        public static Int32 BTICard_SysMonThresholdSet(Int32 enable, Int32 minval, Int32 maxval, Int32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonThresholdSet(enable, minval, maxval, index, handleval);
            else
                return BTICARD_64.BTICard_SysMonThresholdSet(enable, minval, maxval, index, handleval);
        }
        unsafe public static Int32 BTICard_SysMonThresholdGet(Int32* enable, ref Int32 minval, ref Int32 maxval, Int32 index, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonThresholdGet(enable, ref minval, ref maxval, index, handleval);
            else
                return BTICARD_64.BTICard_SysMonThresholdGet(enable, ref minval, ref maxval, index, handleval);
        }
        public static UInt16 BTICard_SysMonValToDAC(Int32 val, Int32 rangemin, Int32 rangemax, UInt16 dacval_max, Int32 scalefactor, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonValToDAC(val, rangemin, rangemax, dacval_max, scalefactor, handleval);
            else
                return BTICARD_64.BTICard_SysMonValToDAC(val, rangemin, rangemax, dacval_max, scalefactor, handleval);
        }
        public static Int32 BTICard_SysMonDACToVal(UInt16 dacval, Int32 rangemin, Int32 rangemax, UInt16 dacval_max, Int32 scalefactor, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_SysMonDACToVal(dacval, rangemin, rangemax, dacval_max, scalefactor, handleval);
            else
                return BTICARD_64.BTICard_SysMonDACToVal(dacval, rangemin, rangemax, dacval_max, scalefactor, handleval);
        }
        public static Int32 BTICard_TickTimerStart(Int32 milliseconds)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_TickTimerStart(milliseconds);
            else
                return BTICARD_64.BTICard_TickTimerStart(milliseconds);
        }
        public static Int32 BTICard_TickTimerValid(Int32 timer)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_TickTimerValid(timer);
            else
                return BTICARD_64.BTICard_TickTimerValid(timer);
        }
        public static Int32 BTICard_Timer64Rd(ref UInt32 valueh, ref UInt32 valuel, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_Timer64Rd(ref valueh, ref valuel, handleval);
            else
                return BTICARD_64.BTICard_Timer64Rd(ref valueh, ref valuel, handleval);
        }
        public static void BTICard_Timer64Wr(UInt32 valueh, UInt32 valuel, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_Timer64Wr(valueh, valuel, handleval);
            else
                BTICARD_64.BTICard_Timer64Wr(valueh, valuel, handleval);
        }
        public static void BTICard_TimerClear(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_TimerClear(handleval);
            else
                BTICARD_64.BTICard_TimerClear(handleval);
        }
        public static UInt32 BTICard_TimerRd(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_TimerRd(handleval);
            else
                return BTICARD_64.BTICard_TimerRd(handleval);
        }
        public static Int32 BTICard_TimerResolution(Int32 timerresol, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_TimerResolution(timerresol, handleval);
            else
                return BTICARD_64.BTICard_TimerResolution(timerresol, handleval);
        }
        public static UInt16 BTICard_TimerResolutionEx(UInt16 timershift, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_TimerResolutionEx(timershift, handleval);
            else
                return BTICARD_64.BTICard_TimerResolutionEx(timershift, handleval);
        }
        public static Int32 BTICard_TimerStatus(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_TimerStatus(handleval);
            else
                return BTICARD_64.BTICard_TimerStatus(handleval);
        }
        public static void BTICard_TimerWr(UInt32 value, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_TimerWr(value, handleval);
            else
                BTICARD_64.BTICard_TimerWr(value, handleval);
        }
        public static Int32 BTICard_ValAsciiCmpi(ref string str1, ref string str2)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValAsciiCmpi(ref str1, ref str2);
            else
                return BTICARD_64.BTICard_ValAsciiCmpi(ref str1, ref str2);
        }
        public static unsafe string BTICard_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValAsciiCpy(ref strdest, ref strsrc, count);
            else
                return BTICARD_64.BTICard_ValAsciiCpy(ref strdest, ref strsrc, count);
        }
        public static void BTICard_ValAsciiTrimLead(ref string buf)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ValAsciiTrimLead(ref buf);
            else
                BTICARD_64.BTICard_ValAsciiTrimLead(ref buf);
        }
        public static void BTICard_ValAsciiTrimTrail(ref string buf)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_ValAsciiTrimTrail(ref buf);
            else
                BTICARD_64.BTICard_ValAsciiTrimTrail(ref buf);
        }
        public static UInt32 BTICard_ValFromAscii(ref string asciistr, Int32 radixval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValFromAscii(ref asciistr, radixval);
            else
                return BTICARD_64.BTICard_ValFromAscii(ref asciistr, radixval);
        }
        public static UInt32 BTICard_ValGetBits(UInt32 oldvalue, Int32 startbit, Int32 endbit)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValGetBits(oldvalue, startbit, endbit);
            else
                return BTICARD_64.BTICard_ValGetBits(oldvalue, startbit, endbit);
        }
        public static unsafe string BTICard_ValIncAscii(ref string asciistr)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValIncAscii(ref asciistr);
            else
                return BTICARD_64.BTICard_ValIncAscii(ref asciistr);
        }
        public static unsafe string BTICard_ValInccAscii(ref string asciistr)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValInccAscii(ref asciistr);
            else
                return BTICARD_64.BTICard_ValInccAscii(ref asciistr);
        }
        public static Int32 BTICard_ValIsLower(Int32 value)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValIsLower(value);
            else
                return BTICARD_64.BTICard_ValIsLower(value);
        }
        public static Int32 BTICard_ValLenAscii(Int32 numbits, Int32 radixval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValLenAscii(numbits, radixval);
            else
                return BTICARD_64.BTICard_ValLenAscii(numbits, radixval);
        }
        public static UInt32 BTICard_ValPutBits(UInt32 oldvalue, UInt32 newfld, Int32 startbit, Int32 endbit)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValPutBits(oldvalue, newfld, startbit, endbit);
            else
                return BTICARD_64.BTICard_ValPutBits(oldvalue, newfld, startbit, endbit);
        }
        public static unsafe string BTICard_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValToAscii(value, ref asciistr, numbits, radixval);
            else
                return BTICARD_64.BTICard_ValToAscii(value, ref asciistr, numbits, radixval);
        }
        public static Int32 BTICard_ValToUpper(Int32 value)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_ValToUpper(value);
            else
                return BTICARD_64.BTICard_ValToUpper(value);
        }
        public static UInt32 BTICard_VARRdL(UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_VARRdL(addrval, handleval);
            else
                return BTICARD_64.BTICard_VARRdL(addrval, handleval);
        }
        public static void BTICard_VARRdsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_VARRdsW(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_VARRdsW(ref valueptr, addrval, countval, handleval);
        }
        public static UInt16 BTICard_VARRdW(UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICARD_32.BTICard_VARRdW(addrval, handleval);
            else
                return BTICARD_64.BTICard_VARRdW(addrval, handleval);
        }
        public static void BTICard_VARWrL(UInt32 value, UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_VARWrL(value, addrval, handleval);
            else
                BTICARD_64.BTICard_VARWrL(value, addrval, handleval);
        }
        public static void BTICard_VARWrsW(ref UInt16 valueptr, UInt16 addrval, Int32 countval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_VARWrsW(ref valueptr, addrval, countval, handleval);
            else
                BTICARD_64.BTICard_VARWrsW(ref valueptr, addrval, countval, handleval);
        }
        public static void BTICard_VARWrW(UInt16 value, UInt16 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICARD_32.BTICard_VARWrW(value, addrval, handleval);
            else
                BTICARD_64.BTICard_VARWrW(value, addrval, handleval);
        }

        /**
        *
        *  External definitions
        *
        *  Note: To operate the BUSBox in serial (RS-232) mode, set
        *  the BUSBox_SerialMode = TRUE.  Optionally, you can set the
        *  BUSBox_BaudRate = baudvalue, but this defaults to the
        *  suggested 115200 baud.
        *
        **/

        /**
        *
        *  Core number constants
        *
        **/

        public const UInt32 COREA = 0x0000;	//Selects Core A
        public const UInt32 COREB = 0x0001;	//Selects Core B
        public const UInt32 COREC = 0x0002;	//Selects Core C
        public const UInt32 CORED = 0x0003;	//Selects Core D

        /**
        *
        *  Sequential Record configuration options
        *
        **/

        public const UInt32 SEQCFG_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 SEQCFG_FILLHALT = 0x00000000;	//Enable sequential record in fill and halt mode (default)
        public const UInt32 SEQCFG_DISABLE = 0x00000001;	//Disable sequential record
        public const UInt32 SEQCFG_CONTINUOUS = 0x00000002;	//Enable sequential record in continuous mode
        public const UInt32 SEQCFG_DMA = 0x00000004;	//Enable monitor in dma mode
        public const UInt32 SEQCFG_FREE = 0x00000008;	//Enable sequential record in free mode
        public const UInt32 SEQCFG_DELTA = 0x00000010;	//Enable sequential record in delta mode
        public const UInt32 SEQCFG_INTERVAL = 0x00000020;	//Enable sequential record in interval mode
        public const UInt32 SEQCFG_NOLOGFULL = 0x00000000;	//Do not generate event log when sequential record is full (default)
        public const UInt32 SEQCFG_LOGFULL = 0x00001000;	//Generate event log when sequential record is full
        public const UInt32 SEQCFG_NOLOGFREQ = 0x00000000;	//Do not generate event logs at a user specified frequency (default)
        public const UInt32 SEQCFG_LOGFREQ = 0x00002000;	//Generate event logs at user specified frequency
        public const UInt32 SEQCFG_16K = 0x00000000;	//Allocate a 16K sequential record buffer (default)
        public const UInt32 SEQCFG_ALLAVAIL = 0x01000000;	//Allocate all available memory to a sequential record buffer
        public const UInt32 SEQCFG_32K = 0x02000000;	//Allocate a 32K sequential record buffer
        public const UInt32 SEQCFG_64K = 0x04000000;	//Allocate a 64K sequential record buffer
        public const UInt32 SEQCFG_128K = 0x08000000;	//Allocate a 128K sequential record buffer

        /**
        *
        *  Sequential Record type fields
        *
        **/

        public const UInt32 SEQTYPE_MASK = 0x00FF;	//Sequential record type mask value
        public const UInt32 SEQTYPE_429 = 0x0001;	//Sequential record type is ARINC 429
        public const UInt32 SEQTYPE_717 = 0x0002;	//Sequential record type is ARINC 717
        public const UInt32 SEQTYPE_1553 = 0x0003;	//Sequential record type is MIL-STD-1553
        public const UInt32 SEQTYPE_708 = 0x0004;	//Sequential record type is ARINC 708
        public const UInt32 SEQTYPE_USER = 0x0005;	//Sequential record type is User Defined
        public const UInt32 SEQTYPE_CSDB = 0x0006;	//Sequential record type is CSDB
        public const UInt32 SEQTYPE_DIO = 0x0007;	//Sequential record type is DIO
        public const UInt32 SEQTYPE_RESTART = 0x00FF;	//Sequential record type is Restart

        /**
        *
        *  Sequential Record version fields
        *
        **/

        public const UInt32 SEQVER_MASK = 0xFF00;	//Sequential record version mask value
        public const UInt32 SEQVER_0 = 0x0000;	//Sequential record version number is 0
        public const UInt32 SEQVER_1 = 0x0100;	//Sequential record version number is 1

        /**
        *
        *  Event log list configuration options
        *
        **/

        public const UInt32 LOGCFG_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 LOGCFG_ENABLE = 0x00000000;	//Enable event log list (default)
        public const UInt32 LOGCFG_DISABLE = 0x00000001;	//Disable event log list

        /**
        *
        *  IRIG timer configuration options
        *
        **/

        public const UInt32 IRIGCFG_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 IRIGCFG_ENABLE = 0x00000000;	//Enable IRIG timer (default)
        public const UInt32 IRIGCFG_DISABLE = 0x00000001;	//Disable IRIG timer
        public const UInt32 IRIGCFG_SPEEDB = 0x00000000;	//Bit rate is IRIGB (default)
        public const UInt32 IRIGCFG_SPEEDA = 0x00000002;	//Bit rate is IRIGA
        public const UInt32 IRIGCFG_INTERNAL = 0x00000000;	//IRIG timer operates internally (default)
        public const UInt32 IRIGCFG_EXTERNAL = 0x00000004;	//IRIG timer operates externally
        public const UInt32 IRIGCFG_SLAVE = 0x00000000;	//IRIG timer is a slave  / receiver (default)
        public const UInt32 IRIGCFG_MASTER = 0x00000008;	//IRIG timer is a master / transmitter
        public const UInt32 IRIGCFG_PPS = 0x00000010;	//IRIG timer operates in PPS mode (rcv/xmt)
        public const UInt32 IRIGCFG_PWM = 0x00000000;	//IRIG timer uses pulse width modulated signaling (rcv/xmt) (default)
        public const UInt32 IRIGCFG_AM = 0x00000020;	//IRIG timer uses amplitude modulated signaling (rcv only hw dependant)

        /**
        *
        *  IRIG timer field definitions
        *
        **/

        public const UInt32 IRIGFIELD_USECLSB = 0x0000;	//Microseconds LSB in timestamp field
        public const UInt32 IRIGFIELD_USECMSB = 0x000B;	//Microseconds MSB in timestamp field
        public const UInt32 IRIGFIELD_MSECLSB = 0x000C;	//Milliseconds LSB in timestamp field
        public const UInt32 IRIGFIELD_MSECMSB = 0x0017;	//Milliseconds MSB in timestamp field
        public const UInt32 IRIGFIELD_SECLSB = 0x0018;	//Seconds LSB in timestamp field
        public const UInt32 IRIGFIELD_SECMSB = 0x001F;	//Seconds MSB in timestamp field
        public const UInt32 IRIGFIELD_MINLSB = 0x0000;	//Minutes LSB in timestamph field
        public const UInt32 IRIGFIELD_MINMSB = 0x0007;	//Minutes MSB in timestamph field
        public const UInt32 IRIGFIELD_HRSLSB = 0x0008;	//Hours LSB in timestamph field
        public const UInt32 IRIGFIELD_HRSMSB = 0x000F;	//Hours MSB in timestamph field
        public const UInt32 IRIGFIELD_DAYLSB = 0x0010;	//Days LSB in timestamph field
        public const UInt32 IRIGFIELD_DAYMSB = 0x001B;	//Days MSB in timestamph field

        /**
        *
        *  C54x Global Registers
        *
        **/

        public const UInt32 C54_GREG_IMR = 0x0000;	//Interrupt mask register
        public const UInt32 C54_GREG_IFR = 0x0001;	//Interrupt flag register
        public const UInt32 C54_GREG_ST0 = 0x0006;	//Status register 0
        public const UInt32 C54_GREG_ST1 = 0x0007;	//Status register 1
        public const UInt32 C54_GREG_AL = 0x0008;	//Accumulator A low word (bits 15-00)
        public const UInt32 C54_GREG_AH = 0x0009;	//Accumulator A high word (bits 31-16)
        public const UInt32 C54_GREG_AG = 0x000A;	//Accumulator A guars bits (bits 39-32)
        public const UInt32 C54_GREG_BL = 0x000B;	//Accumulator B low word (bits 15-00)
        public const UInt32 C54_GREG_BH = 0x000C;	//Accumulator B high word (bits 31-16)
        public const UInt32 C54_GREG_BG = 0x000D;	//Accumulator B guard bits (bits 39-32
        public const UInt32 C54_GREG_T = 0x000E;	//Temporary register
        public const UInt32 C54_GREG_TRN = 0x000F;	//Transition register
        public const UInt32 C54_GREG_AR0 = 0x0010;	//Auxilliary register 0
        public const UInt32 C54_GREG_AR1 = 0x0011;	//Auxilliary register 1
        public const UInt32 C54_GREG_AR2 = 0x0012;	//Auxilliary register 2
        public const UInt32 C54_GREG_AR3 = 0x0013;	//Auxilliary register 3
        public const UInt32 C54_GREG_AR4 = 0x0014;	//Auxilliary register 4
        public const UInt32 C54_GREG_AR5 = 0x0015;	//Auxilliary register 5
        public const UInt32 C54_GREG_AR6 = 0x0016;	//Auxilliary register 6
        public const UInt32 C54_GREG_AR7 = 0x0017;	//Auxilliary register 7
        public const UInt32 C54_GREG_SP = 0x0018;	//Stack pointer
        public const UInt32 C54_GREG_BK = 0x0019;	//Circular-buffer size register
        public const UInt32 C54_GREG_BRC = 0x001A;	//Block-repeat counter
        public const UInt32 C54_GREG_RSA = 0x001B;	//Block-repeat start address
        public const UInt32 C54_GREG_REA = 0x001C;	//Block-repeat end address
        public const UInt32 C54_GREG_PMST = 0x001D;	//Processor mode status register
        public const UInt32 C54_GREG_XPC = 0x001E;	//Program counter extension register
        public const UInt32 C54_GREG_DRR20 = 0x0020;	//McBSP0 data receive register high
        public const UInt32 C54_GREG_DRR10 = 0x0021;	//McBSP0 data receive register low
        public const UInt32 C54_GREG_DXR20 = 0x0022;	//McBSP0 data transmit register high
        public const UInt32 C54_GREG_DXR10 = 0x0023;	//McBSP0 data transmit register low
        public const UInt32 C54_GREG_TIM = 0x0024;	//Timer count register
        public const UInt32 C54_GREG_PRD = 0x0025;	//Timer period register
        public const UInt32 C54_GREG_TCR = 0x0026;	//Timer control register
        public const UInt32 C54_GREG_SWWSR = 0x0028;	//External interface software wait-state register
        public const UInt32 C54_GREG_BSCR = 0x0029;	//External interface bank-switching control register
        public const UInt32 C54_GREG_SWCR = 0x002B;	//Software wait-state control register
        public const UInt32 C54_GREG_HPIC = 0x002C;	//Host port interface control register
        public const UInt32 C54_GREG_DRR22 = 0x0030;	//McBSP2 data receive register high
        public const UInt32 C54_GREG_DRR12 = 0x0031;	//McBSP2 data receive register low
        public const UInt32 C54_GREG_DXR22 = 0x0032;	//McBSP2 data transmit register high
        public const UInt32 C54_GREG_DXR12 = 0x0033;	//McBSP2 data transmit register low
        public const UInt32 C54_GREG_SPSA2 = 0x0034;	//McBSP2 sub-address register
        public const UInt32 C54_GREG_SPDR2 = 0x0035;	//McBSP2 sub-address data register
        public const UInt32 C54_GREG_SPSA0 = 0x0038;	//McBSP0 sub-address register
        public const UInt32 C54_GREG_SPDR0 = 0x0039;	//McBSP0 sub-address data register
        public const UInt32 C54_GREG_DRR21 = 0x0040;	//McBSP1 data receive register high
        public const UInt32 C54_GREG_DRR11 = 0x0041;	//McBSP1 data receive register low
        public const UInt32 C54_GREG_DXR21 = 0x0042;	//McBSP1 data transmit register high
        public const UInt32 C54_GREG_DXR11 = 0x0043;	//McBSP1 data transmit register low
        public const UInt32 C54_GREG_SPSA1 = 0x0048;	//McBSP1 sub-address register
        public const UInt32 C54_GREG_SPDR1 = 0x0049;	//McBSP1 sub-address data register
        public const UInt32 C54_GREG_DMPREC = 0x0054;	//DMA channel priority and enable control
        public const UInt32 C54_GREG_DMSBAR = 0x0055;	//DMA channel sub-address register
        public const UInt32 C54_GREG_DMADI = 0x0056;	//DMA channel sub-address data with increment
        public const UInt32 C54_GREG_DMADN = 0x0057;	//DMA channel sub-address data without increment
        public const UInt32 C54_GREG_CLKMD = 0x0058;	//Clock-mode register

        /**
        *
        *  Event types.
        *
        **/

        public const UInt32 EVENTTYPE_1553MSG = 0x0001;	//MIL-STD-1553 message
        public const UInt32 EVENTTYPE_1553OPCODE = 0x0002;	//MIL-STD-1553 event log opcode
        public const UInt32 EVENTTYPE_1553HALT = 0x0003;	//MIL-STD-1553 schedule halt
        public const UInt32 EVENTTYPE_1553PAUSE = 0x0004;	//MIL-STD-1553 schedule pause
        public const UInt32 EVENTTYPE_1553LIST = 0x0005;	//MIL-STD-1553 list buffer empty/full
        public const UInt32 EVENTTYPE_1553SERIAL = 0x0006;	//MIL-STD-1553 serial empty
        public const UInt32 EVENTTYPE_429MSG = 0x0011;	//ARINC 429 message
        public const UInt32 EVENTTYPE_429OPCODE = 0x0012;	//ARINC 429 event log opcode
        public const UInt32 EVENTTYPE_429HALT = 0x0013;	//ARINC 429 schedule halt
        public const UInt32 EVENTTYPE_429PAUSE = 0x0014;	//ARINC 429 schedule pause
        public const UInt32 EVENTTYPE_429LIST = 0x0015;	//ARINC 429 list buffer empty/full
        public const UInt32 EVENTTYPE_429ERR = 0x0016;	//ARINC 429 decoder error detected
        public const UInt32 EVENTTYPE_717WORD = 0x0021;	//ARINC 717 word received
        public const UInt32 EVENTTYPE_717SUBFRM = 0x0022;	//ARINC 717 sub frame completed
        public const UInt32 EVENTTYPE_717SYNCERR = 0x0023;	//ARINC 717 receive channel lost synchronization
        public const UInt32 EVENTTYPE_708MSG = 0x0031;	//ARINC 708 message
        public const UInt32 EVENTTYPE_SEQFULL = 0x0041;	//Sequential record full
        public const UInt32 EVENTTYPE_SEQFREQ = 0x0042;	//Sequential record frequency
        public const UInt32 EVENTTYPE_422TXTHRESHOLD = 0x0051;	//RS-422 TX under threshold
        public const UInt32 EVENTTYPE_422TXFIFO = 0x0052;	//RS-422 TX underflow
        public const UInt32 EVENTTYPE_422RXTHRESHOLD = 0x0053;	//RS-422 RX over threshold
        public const UInt32 EVENTTYPE_422RXFIFO = 0x0054;	//RS-422 RX overflow
        public const UInt32 EVENTTYPE_422RXERROR = 0x0055;	//RS-422 RX error
        public const UInt32 EVENTTYPE_CSDBMSG = 0x0058;	//CSDB message
        public const UInt32 EVENTTYPE_CSDBOPCODE = 0x0059;	//CSDB event log opcode
        public const UInt32 EVENTTYPE_CSDBHALT = 0x005A;	//CSDB schedule halt
        public const UInt32 EVENTTYPE_CSDBPAUSE = 0x005B;	//CSDB schedule pause
        public const UInt32 EVENTTYPE_CSDBLIST = 0x005C;	//CSDB list buffer empty/full
        public const UInt32 EVENTTYPE_CSDBERR = 0x005D;	//CSDB decoder error detected
        public const UInt32 EVENTTYPE_CSDBSYNCERR = 0x005E;	//CSDB receive channel lost synchronization
        public const UInt32 EVENTTYPE_DIOEDGE = 0x0060;	//DIO edge event
        public const UInt32 EVENTTYPE_DIOFAULT = 0x0061;	//DIO fault event
        public const UInt32 EVENTTYPE_BITERROR = 0x0071;	//Built-in Test error event

        /**
        *
        *  Card Info types
        *
        **/

        public const UInt32 INFOTYPE_PLAT = 0x0001;	//Returns the platform type
        public const UInt32 INFOTYPE_PROD = 0x0002;	//Returns the product type
        public const UInt32 INFOTYPE_GEN = 0x0003;	//Returns the generation number
        public const UInt32 INFOTYPE_1553COUNT = 0x0004;	//Returns the 1553 channel count
        public const UInt32 INFOTYPE_1553SIZE = 0x0005;	//Returns the 1553 channel size
        public const UInt32 INFOTYPE_429COUNT = 0x0006;	//Returns the 429 channel count
        public const UInt32 INFOTYPE_429SIZE = 0x0007;	//Returns the 429 channel size
        public const UInt32 INFOTYPE_717COUNT = 0x0008;	//Returns the 717 channel count
        public const UInt32 INFOTYPE_717SIZE = 0x0009;	//Returns the 717 channel size
        public const UInt32 INFOTYPE_708COUNT = 0x000A;	//Returns the 708 channel count
        public const UInt32 INFOTYPE_708SIZE = 0x000B;	//Returns the 708 channel size
        public const UInt32 INFOTYPE_VERSION = 0x000C;	//Returns the version number
        public const UInt32 INFOTYPE_DATE = 0x000D;	//Returns the version date
        public const UInt32 INFOTYPE_CHINFO = 0x000E;	//Returns the channel info
        public const UInt32 INFOTYPE_422COUNT = 0x000F;	//Returns the 422 port count
        public const UInt32 INFOTYPE_422SIZE = 0x0010;	//Returns the 422 port size
        public const UInt32 INFOTYPE_CSDBCOUNT = 0x0011;	//Returns the CSDB channel count
        public const UInt32 INFOTYPE_CSDBSIZE = 0x0012;	//Returns the CSDB channel size
        public const UInt32 INFOTYPE_DIOCOUNT = 0x0013;	//Returns the DIO bank count
        public const UInt32 INFOTYPE_DIOSIZE = 0x0014;	//Returns the DIO bank size
        public const UInt32 INFOTYPE_HWGEN = 0x0015;	//Returns the Hardware Generation

        /**
        *
        *  Co-Processor Info types
        *
        **/

        public const UInt32 COPROCINFO_PLAT = 0x0001;	//Returns the platform type
        public const UInt32 COPROCINFO_PROD = 0x0002;	//Returns the product type
        public const UInt32 COPROCINFO_GEN = 0x0003;	//Returns the generation number
        public const UInt32 COPROCINFO_VERSION = 0x0004;	//Returns the version number (major.minor)
        public const UInt32 COPROCINFO_DATE = 0x0005;	//Returns the version date
        public const UInt32 COPROCINFO_CISADDR = 0x0006;	//Returns the CIS address
        public const UInt32 COPROCINFO_DMA = 0x0007;	//Returns whether or not CoProc supports DMA mode
        public const UInt32 COPROCINFO_VERSIONEX = 0x0009;	//Returns the version number (major.minor.minorminor)

        /**
        *
        *  CIS types
        *
        **/

        public const UInt32 CISTYPE_CARD = 0x0001;	//Select card CIS
        public const UInt32 CISTYPE_IOMODULE = 0x0002;	//Select I/O module CIS
        public const UInt32 CISTYPE_PLX = 0x0003;	//Select PLX EEPROM
        public const UInt32 CISTYPE_INFO = 0x0004;	//Select Info module CIS

        /**
        *
        *  Handle Info types
        *
        **/

        public const UInt32 HANDINFO_CORENUM = 0x0001;	//Returns the Handle Core number

        /**
        *
        *  Trigger flags
        *
        **/

        public const UInt32 TRIGMASK_TRIGA = 0x0001;	//Selects trigger line A
        public const UInt32 TRIGMASK_TRIGB = 0x0002;	//Selects trigger line B
        public const UInt32 TRIGMASK_TRIGC = 0x0004;	//Selects trigger line C
        public const UInt32 TRIGVAL_TRIGAOFF = 0x0000;	//Tests for trigger line A inactive
        public const UInt32 TRIGVAL_TRIGAON = 0x0001;	//Tests for trigger line A active
        public const UInt32 TRIGVAL_TRIGBOFF = 0x0000;	//Tests for trigger line B inactive
        public const UInt32 TRIGVAL_TRIGBON = 0x0002;	//Tests for trigger line B active
        public const UInt32 TRIGVAL_TRIGCOFF = 0x0000;	//Tests for trigger line C inactive
        public const UInt32 TRIGVAL_TRIGCON = 0x0004;	//Tests for trigger line C active
        public const UInt32 TRIGPOL_TRIGAL = 0x0000;	//Sets active low polarity for trigger line A
        public const UInt32 TRIGPOL_TRIGAH = 0x0001;	//Sets active high polarity for trigger line A
        public const UInt32 TRIGPOL_TRIGBL = 0x0000;	//Sets active low polarity for trigger line B
        public const UInt32 TRIGPOL_TRIGBH = 0x0002;	//Sets active high polarity for trigger line B
        public const UInt32 TRIGPOL_TRIGCL = 0x0000;	//Sets active low polarity for trigger line C
        public const UInt32 TRIGPOL_TRIGCH = 0x0004;	//Sets active high polarity for trigger line C

        /**
        *
        *  Sync flags
        *
        **/

        public const UInt32 SYNCMASK_SYNCA = 0x0001;	//Selects sync line A
        public const UInt32 SYNCMASK_SYNCB = 0x0002;	//Selects sync line B
        public const UInt32 SYNCMASK_SYNCC = 0x0004;	//Selects sync line C
        public const UInt32 SYNCPOL_SYNCAL = 0x0000;	//Sets active low polarity for sync line A
        public const UInt32 SYNCPOL_SYNCAH = 0x0001;	//Sets active high polarity for sync line A
        public const UInt32 SYNCPOL_SYNCBL = 0x0000;	//Sets active low polarity for sync line B
        public const UInt32 SYNCPOL_SYNCBH = 0x0002;	//Sets active high polarity for sync line B
        public const UInt32 SYNCPOL_SYNCCL = 0x0000;	//Sets active low polarity for sync line C
        public const UInt32 SYNCPOL_SYNCCH = 0x0004;	//Sets active high polarity for sync line C

        /**
        *
        *  Heap flags.
        *
        **/

        public const UInt32 HEAPCFG_DEFAULT = 0x0000;	//Block is allocated within page
        public const UInt32 HEAPCFG_TEST = 0x0001;	//Returns address but doesn't make it permanent
        public const UInt32 HEAPCFG_NULL = 0x0002;	//Returns address but doesn't mark it as in use
        public const UInt32 HEAPCFG_SPAN = 0x0004;	//Block can span pages
        public const UInt32 HEAPCFG_QUICK = 0x0008;	//Does a quick allocation
        public const UInt32 HEAPCFG_NOALIGN = 0x0010;	//Relaxes alignment rules to help fit
        public const UInt32 HEAPSECT_SRAM = 0x0000;	//Heap section for primary SRAM

        /**
        *
        *  Timer resolutions.
        *
        **/

        public const Int32 TIMERRESOL_1US = 1;	//1us timer resolution 1:11:34 range
        public const Int32 TIMERRESOL_16US = 2;	//16us timer resolution 19:05:19 range
        public const Int32 TIMERRESOL_1024US = 3;	//1024us timer resolution 50 day range

        /**
        *
        *  Timer status.
        *
        **/

        public const Int32 TIMETAG_FORMAT_BIN = 0;	//Timetag will be in binary format
        public const Int32 TIMETAG_FORMAT_BCD = 1;	//Timetag will be in BCD format

        /**
        *
        *  Interval calculation modes.
        *
        **/

        public const Int32 INTERVALMODE_CLOSEST = 1;	//Finds interval closest to value specified
        public const Int32 INTERVALMODE_LESS = 2;	//Finds closest interval less than value specified
        public const Int32 INTERVALMODE_GREATER = 3;	//Finds closest interval more than value specified

        /**
        *
        *  Test flags.
        *
        **/

        public const Int32 TEST_LEVEL_0 = 0;	//Test I/O interface
        public const Int32 TEST_LEVEL_1 = 1;	//Test memory interface
        public const Int32 TEST_LEVEL_2 = 2;	//Test communication process
        public const Int32 TEST_LEVEL_3 = 3;	//Test bus transceiver

        /**
        *
        *  Status flags.
        *
        **/

        public const Int32 STAT_EMPTY = 0;	//Buffer is empty
        public const Int32 STAT_PARTIAL = 1;	//Buffer is partially filled
        public const Int32 STAT_FULL = 2;	//Buffer is full
        public const Int32 STAT_OFF = 3;	//Buffer is off

        /**
        *
        *  SysMon flags
        *
        **/

        public const Int32 SYSMONTYPE_NONE = 0;	//Sensor not present
        public const Int32 SYSMONTYPE_TEMP = 1;	//Temperature sensor
        public const Int32 SYSMONTYPE_VOLTAGE = 2;	//Voltage sensor
        public const Int32 SYSMONTYPE_CURRENT = 3;	//Current sensor

        /**
        *
        *  SysMon Read Constant
        *
        **/

        public const Int32 SYSMONRD_NOTVALID = -1000000;	//SysMon value not available

        /**
        *
        *  BIT flags
        *
        **/

        public const UInt32 BITCFG_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 BITCFG_MEMECC_ENABLE = 0x00000000;	//Enables Stopping card operation on memory ECC failure  ie uncorrectable error(default)
        public const UInt32 BITCFG_MEMECC_DISABLE = 0x00000001;	//Disables Stopping card operation on memory ECC failure  ie uncorrectable error
        public const UInt32 BITCFG_FPGA_ENABLE = 0x00000000;	//Enables FPGA Single Event Upset (SEU) detection (default)
        public const UInt32 BITCFG_FPGA_DISABLE = 0x00000002;	//Disables FPGA Single Event Upset (SEU) detection
        public const UInt32 BITCFG_PROTOCOL_ENABLE = 0x00000000;	//Enables Protocol error reporting (default)
        public const UInt32 BITCFG_PROTOCOL_DISABLE = 0x00000004;	//Disables Protocol error reporting
        public const UInt32 BITCFG_MEMECC_NOLOG = 0x00000000;	//Do not generate event logs when ECC event occurs (default)
        public const UInt32 BITCFG_MEMECC_LOG = 0x00000010;	//Generate event logs when ECC event occurs
        public const UInt32 BITCFG_FPGA_NOLOG = 0x00000000;	//Do not generate event logs when FPGA Single Event Upset (SEU) event occurs (default)
        public const UInt32 BITCFG_FPGA_LOG = 0x00000020;	//Generate event logs when FPGA Single Event Upset (SEU) event occurs
        public const UInt32 BITCFG_PROTOCOL_NOLOG = 0x00000000;	//Do not generate event logs when Protocol error occurs (default)
        public const UInt32 BITCFG_PROTOCOL_LOG = 0x00000040;	//Generate event logs when Protocol error occurs
        public const UInt32 BITCFG_CARD_STOPPED_NOLOG = 0x00000000;	//Do not generate event logs when the card is stopped due to CBIT error (default)
        public const UInt32 BITCFG_CARD_STOPPED_LOG = 0x00000080;	//Generate event logs when the card is stopped due to CBIT error
        public const UInt32 BITCFG_SYSMON_NOLOG = 0x00000000;	//Do not generate event logs when System Monitor error occurs (default)
        public const UInt32 BITCFG_SYSMON_LOG = 0x00000100;	//Generate event logs when System Monitor error occurs

        public const UInt32 BITSTAT_NOSTATUS = 0x00000000;	//No errors or warnings for BIT
        public const UInt32 BITSTAT_CARD_STOPPED = 0x20000000;	//Continuous BIT fatal system error card stopped
        public const UInt32 BITSTAT_CBIT_FPGA_ERR = 0x10000000;	//Continuous BIT FPGA error (SEU)
        public const UInt32 BITSTAT_SINGLE_BIT_ERR = 0x08000000;	//Continuous BIT Single Bit Error (Correctable)
        public const UInt32 BITSTAT_DOUBLE_BIT_ERR = 0x04000000;	//Continuous BIT Double Bit Error
        public const UInt32 BITSTAT_SYSMON_ERR = 0x0000FFFF;	//Continuous BIT System Monitor error
        public const UInt32 BITSTAT_PROTOCOL_ERR = 0x00FF0000;	//Continuous BIT Protocol Error

        /**
        *
        *  Other flags.
        *
        **/

        public const Int32 RCV = 0;
        public const Int32 XMT = 1;

        /**
        *
        *  Error types.
        *
        **/

        public const Int32 ERR_NONE = 0;	//No error
        public const Int32 ERR_UNKNOWN = -1;	//An unexpected error occurred
        public const Int32 ERR_BADVER = -2;	//A bad version was encountered
        public const Int32 ERR_BADPTR = -3;	//A bad pointer was passed
        public const Int32 ERR_NOCORE = -4;	//The specified core number doesn't exist
        public const Int32 ERR_BADPARAMS = -11;	//CardOpen() called with bad parameters
        public const Int32 ERR_NOHANDLES = -12;	//CardOpen() already has allocated too many handles
        public const Int32 ERR_NOCARD = -13;	//CardOpen() could not find a L43 card at the specified address
        public const Int32 ERR_NOIO = -14;	//CardOpen() could not find the I/O ports
        public const Int32 ERR_NOMEM = -15;	//CardOpen() could not find the memory
        public const Int32 ERR_BAD16BIT = -16;	//Card is conflicting with another 16-bit card
        public const Int32 ERR_WRONGMODEL = -17;	//Card does not support this feature
        public const Int32 ERR_NOSEL = -18;	//CardOpen() could not allocate a memory selector
        public const Int32 ERR_LOCK = -19;	//The communication process is locked up
        public const Int32 ERR_TOOMANY = -20;	//Too many channels have been configured
        public const Int32 ERR_BADHANDLE = -21;	//A bad handle was specified
        public const Int32 ERR_GOODHANDLE = -22;	//The handle is still valid and should not be destroyed
        public const Int32 ERR_NOTCHAN = -23;	//Not a valid channel
        public const Int32 ERR_NOTXMT = -24;	//The Transmitter has not been configured
        public const Int32 ERR_NOTRCV = -25;	//The Receiver has not been configured
        public const Int32 ERR_NOTSEQ = -26;	//The Sequential Record has not been configured
        public const Int32 ERR_ALLOC = -27;	//There is not enough memory to allocate
        public const Int32 ERR_VXD = -28;	//An error occurred in the VXD
        public const Int32 ERR_BADLABEL = -29;	//The specified label value is not valid
        public const Int32 ERR_BADSDI = -30;	//The specified sdi value is not valid
        public const Int32 ERR_BADMSG = -31;	//The specified command block is not a message block
        public const Int32 ERR_BADSCHNDX = -32;	//Specified command index is out of range
        public const Int32 ERR_BUFSIZE = -33;	//Insufficient space in user buffer
        public const Int32 ERR_NOCONFIG = -34;	//The card has not been properly configured
        public const Int32 ERR_CONFLICTS = -35;	//Unable to resolve conflicts
        public const Int32 ERR_RANGE = -36;	//Schedule is out of range
        public const Int32 ERR_FACTOR = -37;	//A bad factor value was specified
        public const Int32 ERR_NOIOBOOT = -40;	//Could not talk to IO Boot port of DSP
        public const Int32 ERR_BOOTFULL = -41;	//No space to add boot code
        public const Int32 ERR_BOOTNUM = -42;	//There is no boot code with the specified number
        public const Int32 ERR_ACCESS = -43;	//Unable to write to access register
        public const Int32 ERR_ROMVERIFY = -44;	//Unable to verify the value written to the ROM
        public const Int32 ERR_COUNT = -45;	//An invalid count was specified
        public const Int32 ERR_CRC = -46;	//There was a bad checksum in the HEX file
        public const Int32 ERR_FNAME = -47;	//Bad filenames were specified
        public const Int32 ERR_FRDWR = -48;	//There was an error reading or writing the HEX file
        public const Int32 ERR_HEX = -49;	//There was a bad hex character in the HEX file
        public const Int32 ERR_INDEX = -51;	//The command block index was invalid or the schedule is full
        public const Int32 ERR_NOMSGS = -52;	//No messages specified
        public const Int32 ERR_TYPE = -54;	//There was a bad type value in the HEX file
        public const Int32 ERR_ZEROLEN = -55;	//Zero length was specified
        public const Int32 ERR_BADADDRESS = -56;	//A bad address was specified
        public const Int32 ERR_MSGNDX = -57;	//A bad message index was specified
        public const Int32 ERR_BADTA = -60;	//A bad terminal address was specified
        public const Int32 ERR_BADFRAME = -61;	//A bad frame time was specified
        public const Int32 ERR_NOTBC = -62;	//The BC has not been configured
        public const Int32 ERR_NOTRT = -63;	//The RT has not been configured
        public const Int32 ERR_NOTMON = -64;	//The monitor has not been configured
        public const Int32 ERR_SELFIOFAIL = -71;	//I/O selftest failed
        public const Int32 ERR_SELFMEMFAIL = -72;	//Memory selftest failed
        public const Int32 ERR_SELFCOMMFAIL = -73;	//Communication selftest failed
        public const Int32 ERR_SELFXMTFAIL = -74;	//Transmit selftest failed
        public const Int32 ERR_PLXBUG = -75;	//PLX bug is causing problems
        public const Int32 ERR_NOTSUPPORTED = -76;	//Base class does not support feature
        public const Int32 ERR_DLL = -77;	//A required DLL is missing
        public const Int32 ERR_SEQTYPE = -80;	//Invalid sequential record type value
        public const Int32 ERR_SEQNEXT = -81;	//Next sequential record does not exist
        public const Int32 ERR_SEQFINDINFO = -82;	//The SEQFINDINFO structure is not valid
        public const Int32 ERR_SEQBASEPTR = -83;	//The base pointer passed is invalid
        public const Int32 ERR_SEQMORE = -84;	//More (extended) record data does not exist
        public const Int32 ERR_TIMEOUT = -90;	//Function timed out waiting for data
        public const Int32 ERR_SUBFRMNUM = -101;	//Invalid SubFrame number was specified
        public const Int32 ERR_WORDNUM = -102;	//Invalid Word number was specified
        public const Int32 ERR_NOTINSYNC = -103;	//Not Synchronized to databus
        public const Int32 ERR_SUPERFRM = -104;	//SuperFrame not configured
        public const Int32 ERR_SUPERFRMNUM = -105;	//Invalid SuperFrame number was specified

    }	//end class
}	//end namespace
