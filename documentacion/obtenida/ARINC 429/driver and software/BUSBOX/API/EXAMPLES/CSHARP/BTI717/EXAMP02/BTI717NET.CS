using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class BTI717
    {
        /**
        *
        *  BTI717 WIN32 DRIVER  Version 1.8.2  (10/05/2010)
        *  Copyright (c) 2001-2010
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   BTI717NET.CS -- 32-bit
        *                      BTI717 Driver Include Header File.
        *
        **/

        /**
        *
        *  Structs used by the BTI717 Driver.
        *
        **/

        [StructLayout(LayoutKind.Sequential)]
        public struct SUBFRMFIELDS717
        {
            public UInt16 subfrmopt;           //Driver writes message optionvals
            public UInt16 subfrmact;           //Card writes message activity
            public UInt16 subfrmnum;           //Card writes subframe number
            public UInt16 subfrmwps;           //Card writes WPS
            public UInt32 timestamp_hitcount; //Card writes timestamp - //Card writes hit count
            public UInt32 spfptr;              //Card writes superframe pointer
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8192)]
            public UInt16[] data;	//Card/User writes subframe data. Valid from 0 -> WPS-1. (Rcv/Xmt)
            public UInt32 timestamph;          //Card writes extended timestamp
            public UInt16 extflag;             //Driver writes external trigger/sync control flags
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
            public UInt16[] rsvd;	//Reserved
        }

        /**
        *
        *  BTI717 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the BTI717 Driver.
        *
        **/

        private static class BTI717_32
        {
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChGetCount@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI717_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChGetInfo@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI717_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChIs717@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIs717(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChIsBiPhase@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIsBiPhase(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChIsRcv@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIsRcv(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChIsSelEnc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIsSelEnc(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChIsType@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIsType(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChIsXmt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIsXmt(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI717_ChPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChPauseCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChPauseCheck(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChResume@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI717_ChResume(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChStart(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChStatus@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChStatus(ref UInt16 buf, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChStop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChStop(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChSyncDefine@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChTriggerDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ParamAmplitudeConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ParamAmplitudeGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmBlkRd(ref UInt16 databuf, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmBlkWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmBlkWr(ref UInt16 databuf, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmStatus@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmStatus(ref UInt16 buf, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmSyncDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmTriggerDefine@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmWordConfig@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmWordConfig(UInt32 configval, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmWordRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmWordRd(ref UInt16 value, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmWordWr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmWordWr(UInt16 value, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SuperFrmConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmConfig(Int32 count, Int32 framespersuperframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SuperFrmCounterPos@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmCounterPos(Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SuperFrmDefine@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI717_SuperFrmDefine(Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SuperFrmWordConfig@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmWordConfig(UInt32 configval, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SuperFrmWordRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmWordRd(ref UInt16 value, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SuperFrmWordWr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmWordWr(UInt16 value, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SyncTest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SyncTest(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SyncValRd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SyncValRd(ref Int32 syncword1, ref Int32 syncword2, ref Int32 syncword3, ref Int32 syncword4, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SyncValWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SyncValWr(Int32 syncword1, Int32 syncword2, Int32 syncword3, Int32 syncword4, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChCreate@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI717_ChCreate(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_ChReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChReset(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_DllUsageCount();
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_GetChanCount@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI717_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_IsBiPhaseChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_IsBiPhaseChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_IsChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_IsChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_IsRcvChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_IsRcvChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_IsXmtChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_IsXmtChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI717_SubFrmAddr(Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmBlkRdEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmBlkRdEx(ref SUBFRMFIELDS717 subfrmdata, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmBlkWrEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmBlkWrEx(ref SUBFRMFIELDS717 subfrmdata, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmCreate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmCreate(UInt32 configval, Int32 subframe, UInt32 chanbase, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SubFrmReset@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmReset(Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SuperFrmBaseAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI717_SuperFrmBaseAddr(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SuperFrmConfigEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmConfigEx(UInt32 configval, Int32 count, Int32 framespersuperframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SuperFrmReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmReset(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_SyncValPtrInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SyncValPtrInit(Int32 channum, UInt32 handleval);
            [DllImport("BTI717.DLL", EntryPoint = "_BTI717_TestProtocol@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_TestProtocol(UInt32 handleval);
        }

        private static class BTI717_64
        {
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChGetCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI717_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChGetInfo", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI717_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChIs717", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIs717(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChIsBiPhase", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIsBiPhase(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChIsRcv", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIsRcv(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChIsSelEnc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIsSelEnc(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChIsType", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIsType(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChIsXmt", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChIsXmt(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChPause", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI717_ChPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChPauseCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChPauseCheck(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChResume", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI717_ChResume(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChStart(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChStatus(ref UInt16 buf, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChStop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChStop(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChSyncDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChTriggerDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ParamAmplitudeConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ParamAmplitudeGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmBlkRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmBlkRd(ref UInt16 databuf, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmBlkWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmBlkWr(ref UInt16 databuf, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmStatus(ref UInt16 buf, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmSyncDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmTriggerDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmWordConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmWordConfig(UInt32 configval, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmWordRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmWordRd(ref UInt16 value, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmWordWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmWordWr(UInt16 value, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SuperFrmConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmConfig(Int32 count, Int32 framespersuperframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SuperFrmCounterPos", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmCounterPos(Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SuperFrmDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI717_SuperFrmDefine(Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SuperFrmWordConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmWordConfig(UInt32 configval, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SuperFrmWordRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmWordRd(ref UInt16 value, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SuperFrmWordWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmWordWr(UInt16 value, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SyncTest", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SyncTest(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SyncValRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SyncValRd(ref Int32 syncword1, ref Int32 syncword2, ref Int32 syncword3, ref Int32 syncword4, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SyncValWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SyncValWr(Int32 syncword1, Int32 syncword2, Int32 syncword3, Int32 syncword4, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI717_ChCreate(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_ChReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_ChReset(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_DllUsageCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_DllUsageCount();
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_GetChanCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI717_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_IsBiPhaseChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_IsBiPhaseChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_IsChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_IsChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_IsRcvChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_IsRcvChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_IsXmtChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_IsXmtChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI717_SubFrmAddr(Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmBlkRdEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmBlkRdEx(ref SUBFRMFIELDS717 subfrmdata, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmBlkWrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmBlkWrEx(ref SUBFRMFIELDS717 subfrmdata, Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmCreate(UInt32 configval, Int32 subframe, UInt32 chanbase, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SubFrmReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SubFrmReset(Int32 subframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SuperFrmBaseAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI717_SuperFrmBaseAddr(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SuperFrmConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmConfigEx(UInt32 configval, Int32 count, Int32 framespersuperframe, Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SuperFrmReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SuperFrmReset(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_SyncValPtrInit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_SyncValPtrInit(Int32 channum, UInt32 handleval);
            [DllImport("BTI71764.DLL", EntryPoint = "BTI717_TestProtocol", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI717_TestProtocol(UInt32 handleval);
        }

        public static Int32 BTI717_ChClear(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChClear(channum, handleval);
            else
                return BTI717_64.BTI717_ChClear(channum, handleval);
        }
        public static Int32 BTI717_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChConfig(configval, channum, handleval);
            else
                return BTI717_64.BTI717_ChConfig(configval, channum, handleval);
        }
        public static void BTI717_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI717_32.BTI717_ChGetCount(ref rcvcount, ref xmtcount, handleval);
            else
                BTI717_64.BTI717_ChGetCount(ref rcvcount, ref xmtcount, handleval);
        }
        public static UInt32 BTI717_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChGetInfo(infotype, channum, handleval);
            else
                return BTI717_64.BTI717_ChGetInfo(infotype, channum, handleval);
        }
        public static Int32 BTI717_ChIs717(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChIs717(channum, handleval);
            else
                return BTI717_64.BTI717_ChIs717(channum, handleval);
        }
        public static Int32 BTI717_ChIsBiPhase(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChIsBiPhase(channum, handleval);
            else
                return BTI717_64.BTI717_ChIsBiPhase(channum, handleval);
        }
        public static Int32 BTI717_ChIsRcv(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChIsRcv(channum, handleval);
            else
                return BTI717_64.BTI717_ChIsRcv(channum, handleval);
        }
        public static Int32 BTI717_ChIsSelEnc(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChIsSelEnc(channum, handleval);
            else
                return BTI717_64.BTI717_ChIsSelEnc(channum, handleval);
        }
        public static Int32 BTI717_ChIsType(UInt32 configval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChIsType(configval, channum, handleval);
            else
                return BTI717_64.BTI717_ChIsType(configval, channum, handleval);
        }
        public static Int32 BTI717_ChIsXmt(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChIsXmt(channum, handleval);
            else
                return BTI717_64.BTI717_ChIsXmt(channum, handleval);
        }
        public static void BTI717_ChPause(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI717_32.BTI717_ChPause(channum, handleval);
            else
                BTI717_64.BTI717_ChPause(channum, handleval);
        }
        public static Int32 BTI717_ChPauseCheck(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChPauseCheck(channum, handleval);
            else
                return BTI717_64.BTI717_ChPauseCheck(channum, handleval);
        }
        public static void BTI717_ChResume(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI717_32.BTI717_ChResume(channum, handleval);
            else
                BTI717_64.BTI717_ChResume(channum, handleval);
        }
        public static Int32 BTI717_ChStart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChStart(channum, handleval);
            else
                return BTI717_64.BTI717_ChStart(channum, handleval);
        }
        public static Int32 BTI717_ChStatus(ref UInt16 buf, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChStatus(ref buf, channum, handleval);
            else
                return BTI717_64.BTI717_ChStatus(ref buf, channum, handleval);
        }
        public static Int32 BTI717_ChStop(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChStop(channum, handleval);
            else
                return BTI717_64.BTI717_ChStop(channum, handleval);
        }
        public static Int32 BTI717_ChSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval);
            else
                return BTI717_64.BTI717_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval);
        }
        public static Int32 BTI717_ChTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
            else
                return BTI717_64.BTI717_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
        }
        public static Int32 BTI717_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ParamAmplitudeConfig(configval, dacval, channum, handleval);
            else
                return BTI717_64.BTI717_ParamAmplitudeConfig(configval, dacval, channum, handleval);
        }
        public static Int32 BTI717_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ParamAmplitudeGet(ref dacval, channum, handleval);
            else
                return BTI717_64.BTI717_ParamAmplitudeGet(ref dacval, channum, handleval);
        }
        public static Int32 BTI717_SubFrmBlkRd(ref UInt16 databuf, Int32 subframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmBlkRd(ref databuf, subframe, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmBlkRd(ref databuf, subframe, channum, handleval);
        }
        public static Int32 BTI717_SubFrmBlkWr(ref UInt16 databuf, Int32 subframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmBlkWr(ref databuf, subframe, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmBlkWr(ref databuf, subframe, channum, handleval);
        }
        public static Int32 BTI717_SubFrmStatus(ref UInt16 buf, Int32 subframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmStatus(ref buf, subframe, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmStatus(ref buf, subframe, channum, handleval);
        }
        public static Int32 BTI717_SubFrmSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 subframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmSyncDefine(enableflag, syncmask, pinpolarity, subframe, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmSyncDefine(enableflag, syncmask, pinpolarity, subframe, channum, handleval);
        }
        public static Int32 BTI717_SubFrmTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 subframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmTriggerDefine(enableflag, trigmask, trigval, pinpolarity, subframe, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmTriggerDefine(enableflag, trigmask, trigval, pinpolarity, subframe, channum, handleval);
        }
        public static Int32 BTI717_SubFrmWordConfig(UInt32 configval, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmWordConfig(configval, subframe, word, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmWordConfig(configval, subframe, word, channum, handleval);
        }
        public static Int32 BTI717_SubFrmWordRd(ref UInt16 value, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmWordRd(ref value, subframe, word, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmWordRd(ref value, subframe, word, channum, handleval);
        }
        public static Int32 BTI717_SubFrmWordWr(UInt16 value, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmWordWr(value, subframe, word, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmWordWr(value, subframe, word, channum, handleval);
        }
        public static Int32 BTI717_SuperFrmConfig(Int32 count, Int32 framespersuperframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SuperFrmConfig(count, framespersuperframe, channum, handleval);
            else
                return BTI717_64.BTI717_SuperFrmConfig(count, framespersuperframe, channum, handleval);
        }
        public static Int32 BTI717_SuperFrmCounterPos(Int32 subframe, Int32 word, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SuperFrmCounterPos(subframe, word, channum, handleval);
            else
                return BTI717_64.BTI717_SuperFrmCounterPos(subframe, word, channum, handleval);
        }
        public static UInt32 BTI717_SuperFrmDefine(Int32 subframe, Int32 word, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SuperFrmDefine(subframe, word, channum, handleval);
            else
                return BTI717_64.BTI717_SuperFrmDefine(subframe, word, channum, handleval);
        }
        public static Int32 BTI717_SuperFrmWordConfig(UInt32 configval, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SuperFrmWordConfig(configval, superfrmnum, superfrmaddr, channum, handleval);
            else
                return BTI717_64.BTI717_SuperFrmWordConfig(configval, superfrmnum, superfrmaddr, channum, handleval);
        }
        public static Int32 BTI717_SuperFrmWordRd(ref UInt16 value, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SuperFrmWordRd(ref value, superfrmnum, superfrmaddr, channum, handleval);
            else
                return BTI717_64.BTI717_SuperFrmWordRd(ref value, superfrmnum, superfrmaddr, channum, handleval);
        }
        public static Int32 BTI717_SuperFrmWordWr(UInt16 value, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SuperFrmWordWr(value, superfrmnum, superfrmaddr, channum, handleval);
            else
                return BTI717_64.BTI717_SuperFrmWordWr(value, superfrmnum, superfrmaddr, channum, handleval);
        }
        public static Int32 BTI717_SyncTest(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SyncTest(channum, handleval);
            else
                return BTI717_64.BTI717_SyncTest(channum, handleval);
        }
        public static Int32 BTI717_SyncValRd(ref Int32 syncword1, ref Int32 syncword2, ref Int32 syncword3, ref Int32 syncword4, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SyncValRd(ref syncword1, ref syncword2, ref syncword3, ref syncword4, channum, handleval);
            else
                return BTI717_64.BTI717_SyncValRd(ref syncword1, ref syncword2, ref syncword3, ref syncword4, channum, handleval);
        }
        public static Int32 BTI717_SyncValWr(Int32 syncword1, Int32 syncword2, Int32 syncword3, Int32 syncword4, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SyncValWr(syncword1, syncword2, syncword3, syncword4, channum, handleval);
            else
                return BTI717_64.BTI717_SyncValWr(syncword1, syncword2, syncword3, syncword4, channum, handleval);
        }
        public static UInt32 BTI717_ChCreate(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChCreate(channum, handleval);
            else
                return BTI717_64.BTI717_ChCreate(channum, handleval);
        }
        public static Int32 BTI717_ChReset(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_ChReset(channum, handleval);
            else
                return BTI717_64.BTI717_ChReset(channum, handleval);
        }
        public static Int32 BTI717_DllUsageCount()
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_DllUsageCount();
            else
                return BTI717_64.BTI717_DllUsageCount();
        }
        public static void BTI717_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI717_32.BTI717_GetChanCount(ref rcvcount, ref xmtcount, handleval);
            else
                BTI717_64.BTI717_GetChanCount(ref rcvcount, ref xmtcount, handleval);
        }
        public static Int32 BTI717_IsBiPhaseChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_IsBiPhaseChan(channum, handleval);
            else
                return BTI717_64.BTI717_IsBiPhaseChan(channum, handleval);
        }
        public static Int32 BTI717_IsChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_IsChan(channum, handleval);
            else
                return BTI717_64.BTI717_IsChan(channum, handleval);
        }
        public static Int32 BTI717_IsRcvChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_IsRcvChan(channum, handleval);
            else
                return BTI717_64.BTI717_IsRcvChan(channum, handleval);
        }
        public static Int32 BTI717_IsXmtChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_IsXmtChan(channum, handleval);
            else
                return BTI717_64.BTI717_IsXmtChan(channum, handleval);
        }
        public static UInt32 BTI717_SubFrmAddr(Int32 subframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmAddr(subframe, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmAddr(subframe, channum, handleval);
        }
        public static Int32 BTI717_SubFrmBlkRdEx(ref SUBFRMFIELDS717 subfrmdata, Int32 subframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmBlkRdEx(ref subfrmdata, subframe, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmBlkRdEx(ref subfrmdata, subframe, channum, handleval);
        }
        public static Int32 BTI717_SubFrmBlkWrEx(ref SUBFRMFIELDS717 subfrmdata, Int32 subframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmBlkWrEx(ref subfrmdata, subframe, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmBlkWrEx(ref subfrmdata, subframe, channum, handleval);
        }
        public static Int32 BTI717_SubFrmCreate(UInt32 configval, Int32 subframe, UInt32 chanbase, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmCreate(configval, subframe, chanbase, handleval);
            else
                return BTI717_64.BTI717_SubFrmCreate(configval, subframe, chanbase, handleval);
        }
        public static Int32 BTI717_SubFrmReset(Int32 subframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SubFrmReset(subframe, channum, handleval);
            else
                return BTI717_64.BTI717_SubFrmReset(subframe, channum, handleval);
        }
        public static UInt32 BTI717_SuperFrmBaseAddr(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SuperFrmBaseAddr(channum, handleval);
            else
                return BTI717_64.BTI717_SuperFrmBaseAddr(channum, handleval);
        }
        public static Int32 BTI717_SuperFrmConfigEx(UInt32 configval, Int32 count, Int32 framespersuperframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SuperFrmConfigEx(configval, count, framespersuperframe, channum, handleval);
            else
                return BTI717_64.BTI717_SuperFrmConfigEx(configval, count, framespersuperframe, channum, handleval);
        }
        public static Int32 BTI717_SuperFrmReset(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SuperFrmReset(channum, handleval);
            else
                return BTI717_64.BTI717_SuperFrmReset(channum, handleval);
        }
        public static Int32 BTI717_SyncValPtrInit(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_SyncValPtrInit(channum, handleval);
            else
                return BTI717_64.BTI717_SyncValPtrInit(channum, handleval);
        }
        public static Int32 BTI717_TestProtocol(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI717_32.BTI717_TestProtocol(handleval);
            else
                return BTI717_64.BTI717_TestProtocol(handleval);
        }

        /**
        *
        *  Channel number constants
        *
        **/

        public const UInt32 CH0 = 0x0000;          //Channel 0
        public const UInt32 CH1 = 0x0001;          //Channel 1
        public const UInt32 CH2 = 0x0002;          //Channel 2
        public const UInt32 CH3 = 0x0003;          //Channel 3
        public const UInt32 CH4 = 0x0004;          //Channel 4
        public const UInt32 CH5 = 0x0005;          //Channel 5
        public const UInt32 CH6 = 0x0006;          //Channel 6
        public const UInt32 CH7 = 0x0007;          //Channel 7
        public const UInt32 CH8 = 0x0008;          //Channel 8
        public const UInt32 CH9 = 0x0009;          //Channel 9
        public const UInt32 CH10 = 0x000A;          //Channel 10
        public const UInt32 CH11 = 0x000B;          //Channel 11
        public const UInt32 CH12 = 0x000C;          //Channel 12
        public const UInt32 CH13 = 0x000D;          //Channel 13
        public const UInt32 CH14 = 0x000E;          //Channel 14
        public const UInt32 CH15 = 0x000F;          //Channel 15
        public const UInt32 CH16 = 0x0010;          //Channel 16
        public const UInt32 CH17 = 0x0011;          //Channel 17
        public const UInt32 CH18 = 0x0012;          //Channel 18
        public const UInt32 CH19 = 0x0013;          //Channel 19
        public const UInt32 CH20 = 0x0014;          //Channel 20
        public const UInt32 CH21 = 0x0015;          //Channel 21
        public const UInt32 CH22 = 0x0016;          //Channel 22
        public const UInt32 CH23 = 0x0017;          //Channel 23
        public const UInt32 CH24 = 0x0018;          //Channel 24
        public const UInt32 CH25 = 0x0019;          //Channel 25
        public const UInt32 CH26 = 0x001A;          //Channel 26
        public const UInt32 CH27 = 0x001B;          //Channel 27
        public const UInt32 CH28 = 0x001C;          //Channel 28
        public const UInt32 CH29 = 0x001D;          //Channel 29
        public const UInt32 CH30 = 0x001E;          //Channel 30
        public const UInt32 CH31 = 0x001F;          //Channel 31

        /**
        *
        *  Subframe constants
        *
        **/

        public const UInt32 SUBFRM1 = 0x0001;	//Sub Frame 1
        public const UInt32 SUBFRM2 = 0x0002;	//Sub Frame 2
        public const UInt32 SUBFRM3 = 0x0003;	//Sub Frame 3
        public const UInt32 SUBFRM4 = 0x0004;	//Sub Frame 4

        /**
        *
        *  Channel configuration options
        *
        **/

        public const UInt32 CHCFG717_DEFAULT = 0x00000000;	//Select all default settings (XMT & RCV) (default)
        public const UInt32 CHCFG717_AUTOSPEED = 0x00000002;	//Select auto speed detection (RCV)
        public const UInt32 CHCFG717_64WPS = 0x00004000;	//Select speed of 64WPS (XMT & RCV)
        public const UInt32 CHCFG717_128WPS = 0x00008000;	//Select speed of 128WPS (XMT & RCV)
        public const UInt32 CHCFG717_256WPS = 0x00000000;	//Select speed of 256WPS (XMT & RCV) (default)
        public const UInt32 CHCFG717_512WPS = 0x00010000;	//Select speed of 512WPS (XMT & RCV)
        public const UInt32 CHCFG717_1024WPS = 0x00020000;	//Select speed of 1024WPS (XMT & RCV)
        public const UInt32 CHCFG717_2048WPS = 0x00040000;	//Select speed of 2048WPS (XMT & RCV)
        public const UInt32 CHCFG717_4096WPS = 0x02000000;	//Select speed of 4096WPS (XMT & RCV)
        public const UInt32 CHCFG717_8192WPS = 0x04000000;	//Select speed of 8192WPS (XMT & RCV)
        public const UInt32 CHCFG717_BIPHASERCV = 0x00000000;	//Select Bi-Phase decoding for receiver (Bi-Phase or RCV) (default)
        public const UInt32 CHCFG717_BIPHASEXMT = 0x08000000;	//Select Bi-Phase encoding for transmitter (Bi-Phase or XMT)
        public const UInt32 CHCFG717_BIPOLARRCV = 0x20000000;	//Select Bi-Polar decoding for receiver (Bi-Polar or RCV)
        public const UInt32 CHCFG717_BIPOLARXMT = 0x60000000;	//Select Bi-Polar encoding for transmitter (Bi-Polar or XMT)
        public const UInt32 CHCFG717_BIPOLARHSPD = 0x08000000;	//Select high speed slope for Bi-Polar transmitter (Bi-Polar XMT)
        public const UInt32 CHCFG717_SELFTEST = 0x00000004;	//Enable internal wraparound (XMT & RCV)
        public const UInt32 CHCFG717_SELFTESTOFF = 0x00000000;	//Disable internal wraparound (XMT & RCV) (default)
        public const UInt32 CHCFG717_SYNC = 0x00000008;	//Sync Enable (XMT & RCV)
        public const UInt32 CHCFG717_SYNCOFF = 0x00000000;	//Disable sync output (XMT & RCV) (default)
        public const UInt32 CHCFG717_ACTIVE = 0x00000000;	//Enable channel activity (XMT & RCV) (default)
        public const UInt32 CHCFG717_INACTIVE = 0x00000040;	//Disable channel activity (XMT & RCV)
        public const UInt32 CHCFG717_EXTSTART = 0x00000100;	//Enable external trigger for first message only (XMT)
        public const UInt32 CHCFG717_EXTTRIG = 0x00000080;	//Enable external trigger for all messages (XMT)
        public const UInt32 CHCFG717_EXTOFF = 0x00000000;	//External trigger is enabled on message level (XMT) (default)
        public const UInt32 CHCFG717_HIT = 0x00000200;	//Hit counter is enabled for all sub frames (XMT & RCV)
        public const UInt32 CHCFG717_NOHIT = 0x00000000;	//Hit counter is disabled (XMT & RCV) (default)
        public const UInt32 CHCFG717_TIMETAG = 0x00000400;	//Enable time-tag for all sub frames (XMT & RCV)
        public const UInt32 CHCFG717_TIMETAGOFF = 0x00000000;	//Time-tag is disabled (XMT & RCV) (default)
        public const UInt32 CHCFG717_SEQALL = 0x00080000;	//Record entire channel in sequential record (XMT & RCV)
        public const UInt32 CHCFG717_SEQSEL = 0x00000000;	//Sequential record recording is enabled at word level (XMT & RCV) (default)
        public const UInt32 CHCFG717_LOGERR = 0x00800000;	//Enable event log on Out of Sync Error (RCV)
        public const UInt32 CHCFG717_NOLOGERR = 0x00000000;	//No event log on Out of Sync Error (RCV) (default)
        public const UInt32 CHCFG717_PAUSE = 0x01000000;	//Mark channel as paused (XMT & RCV)
        public const UInt32 CHCFG717_UNPAUSE = 0x00000000;	//Mark channel as unpaused (XMT & RCV) (default)
        public const UInt32 CHCFG717_XMTSLOPELOW = 0x00000000;	//Select low speed slope for transmitter (XMT) (default)
        public const UInt32 CHCFG717_XMTSLOPEHIGH = 0x10000000;	//Select high speed slope for transmitter (XMT)

        /**
        *
        *  Sub Frame word configuration options
        *
        **/

        public const UInt32 WRDCFG717_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 WRDCFG717_SFLOG = 0x00000001;	//Enable subframe event log
        public const UInt32 WRDCFG717_SFLOGOFF = 0x00000000;	//Disable subframe event log (default)
        public const UInt32 WRDCFG717_WRDLOG = 0x00000002;	//Enable word event log
        public const UInt32 WRDCFG717_WRDLOGOFF = 0x00000000;	//Disable word event log (default)
        public const UInt32 WRDCFG717_SEQ = 0x00000004;	//Enable sequential record
        public const UInt32 WRDCFG717_SEQOFF = 0x00000000;	//Disable sequential record (default)

        /**
        *
        *  Parametric configuration options
        *
        **/

        public const UInt32 PARAMCFG717_DEFAULT = 0x00000000;	//Select all default settings (default)
        public const UInt32 PARAMCFG717_AMPLON = 0x00000000;	//Enables parametric amplitude control (default)
        public const UInt32 PARAMCFG717_AMPLOFF = 0x00000001;	//Disables parametric amplitude control

        /**
        *
        *  Bit fields of the message activity flag.
        *
        **/

        public const UInt32 MSGACT717_CHMASK = 0xFF00;	//Channel number mask value
        public const UInt32 MSGACT717_CHSHIFT = 0x0008;	//Channel number shift value
        public const UInt32 MSGACT717_SPDMASK = 0x00E0;	//Current speed mask value
        public const UInt32 MSGACT717_64WPS = 0x0000;	//Current speed is 64   wps
        public const UInt32 MSGACT717_128WPS = 0x0020;	//Current speed is 128  wps
        public const UInt32 MSGACT717_256WPS = 0x0040;	//Current speed is 256  wps
        public const UInt32 MSGACT717_512WPS = 0x0060;	//Current speed is 512  wps
        public const UInt32 MSGACT717_1024WPS = 0x0080;	//Current speed is 1024 wps
        public const UInt32 MSGACT717_2048WPS = 0x00A0;	//Current speed is 2048 wps
        public const UInt32 MSGACT717_4096WPS = 0x00C0;	//Current speed is 4096 wps
        public const UInt32 MSGACT717_8192WPS = 0x00E0;	//Current speed is 8192 wps
        public const UInt32 MSGACT717_TO = 0x0002;	//Time out error bit
        public const UInt32 MSGACT717_HIT = 0x0001;	//Always set

        /**
        *
        *  Channel info fields.
        *
        **/

        public const UInt32 INFO717_PARAM = 0x0001;	//Channel supports parametric control

    }	//end class
}	//end namespace
