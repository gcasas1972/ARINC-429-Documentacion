using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class BTI429
    {
        /**
        *
        *  BTI429 WIN32 DRIVER  Version 1.10.0  (06/07/2011)
        *  Copyright (c) 2001-2011
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   BTI429NET.CS -- 32-bit
        *                      BTI429 Driver Include Header File.
        *
        **/

        /**
        *
        *  Structs used by the BTI429 Driver.
        *
        **/

        [StructLayout(LayoutKind.Sequential)]
        public struct MSGSTRUCT429
        {
            public UInt32 addr;
            public UInt32 data;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSGFIELDS429
        {
            public UInt16 msgopt;              //Driver writes message optionvals
            public UInt16 msgact;              //Card writes message activity
            public UInt32 msgdata_listptr; //Card/User writes message data (Rcv/Xmt) - //Driver writes list buffer pointer
            public UInt32 timetag_hitcount; //Card writes timetag - //Card writes hit count
            public UInt32 maxtime_elapsetime; //Card writes max time - //Card writes elapsed time
            public UInt32 mintime;             //Card writes min time
            public UInt32 userptr;             //Driver writes user code pointer
            public UInt32 timetagh;            //Card writes extended timetag
            public UInt16 decgap;              //Card writes measured decoder gap time (rsvd for xmt msg)
            public UInt16 rsvd;                //Reserved
        }

        /**
        *
        *  BTI429 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the BTI429 Driver.
        *
        **/

        private static class BTI429_32
        {
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BCDGetData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDGetData(UInt32 msg, UInt16 msb, UInt16 lsb);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BCDGetMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDGetMant(UInt32 msg, UInt16 sigdig);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BCDGetSign@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_BCDGetSign(UInt32 msg);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BCDGetSSM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_BCDGetSSM(UInt32 msg);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BCDGetVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_BCDGetVal(ref string buf, UInt32 msg, UInt16 sigdig, ref string resolstr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BCDPutData@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDPutData(UInt32 msg, UInt32 value, UInt16 msb, UInt16 lsb);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BCDPutMant@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDPutMant(UInt32 msg, UInt32 value, UInt16 sigdig, UInt16 sign);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BCDPutSign@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDPutSign(UInt32 msg, UInt16 sign);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BCDPutSSM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDPutSSM(UInt32 msg, UInt16 value);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BCDPutVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDPutVal(ref string buf, UInt32 msg, UInt16 sigdig, ref string resolstr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BNRGetData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRGetData(UInt32 msg, UInt16 msb, UInt16 lsb);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BNRGetMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRGetMant(UInt32 msg, UInt16 sigbit);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BNRGetSign@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_BNRGetSign(UInt32 msg);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BNRGetSSM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_BNRGetSSM(UInt32 msg);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BNRGetVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_BNRGetVal(ref string buf, UInt32 msg, UInt16 sigbit, ref string resolstr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BNRPutData@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRPutData(UInt32 msg, UInt32 value, UInt16 msb, UInt16 lsb);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BNRPutMant@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRPutMant(UInt32 msg, UInt32 value, UInt16 sigbit, UInt16 twos);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BNRPutSign@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRPutSign(UInt32 msg, UInt16 twos);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BNRPutSSM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRPutSSM(UInt32 msg, UInt16 value);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_BNRPutVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRPutVal(ref string buf, UInt32 msg, UInt16 sigbit, ref string resolstr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChGetCount@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChGetInfo@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChIs429@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChIs429(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChIsRcv@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChIsRcv(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChIsXmt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChIsXmt(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ChPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChPauseCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChPauseCheck(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChResume@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ChResume(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChStart(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChStop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChStop(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChSyncDefine@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChTriggerDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FilterClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_FilterClear(UInt32 basevaladdr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FilterDefault@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FilterDefault(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FilterRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FilterRd(Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FilterSet@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FilterSet(UInt32 configval, Int32 labelval, Int32 sdimask, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FilterWr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_FilterWr(UInt32 msgaddr, Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldGetData@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldGetData(UInt32 msgval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldGetLabel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_FldGetLabel(UInt32 msgval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldGetParity@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_FldGetParity(UInt32 msgval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldGetSDI@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_FldGetSDI(UInt32 msgval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldGetValue@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldGetValue(UInt32 msgval, UInt16 startbit, UInt16 endbit);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldPutData@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldPutData(UInt32 msgval, UInt32 data);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldPutLabel@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldPutLabel(UInt32 msgval, UInt16 label);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldPutSDI@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldPutSDI(UInt32 msgval, UInt16 sdi);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldPutValue@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldPutValue(UInt32 msgval, UInt32 dataval, UInt16 startbit, UInt16 endbit);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListAsyncCreate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListAsyncCreate(UInt32 listconfigval, Int32 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListDataRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListDataRd(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListDataWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListDataWr(UInt32 value, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListRcvCreate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListRcvCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListStatus(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListXmtCreate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListXmtCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgBlockRd(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgBlockWr(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgCreate@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgCreate(UInt32 configval, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgDataRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgDataRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgDataWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgDataWr(UInt32 value, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgGroupBlockRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgGroupBlockRd(ref MSGFIELDS429 msgfields, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgGroupBlockWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgGroupBlockWr(ref MSGFIELDS429 msgfields, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgGroupRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgGroupRd(ref UInt32 msgdataptr, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgGroupWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgGroupWr(ref UInt32 msgdataptr, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgIsAccessed@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgSkipRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_MsgSkipRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgSkipWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgSkipWr(Int32 skip, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgSyncDefine@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_MsgSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgTriggerDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_MsgTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ParamAmplitudeConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ParamAmplitudeGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ParamBitRateConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ParamBitRateConfig(UInt32 configval, UInt16 divval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ParamBitRateGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ParamBitRateGet(ref UInt16 divval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedBranch@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBranch(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedBranchUpdate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBranchUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedBuild@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBuild(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedCall@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedCall(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedCallUpdate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedCallUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedMode@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedMode(UInt32 modeval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedEntry@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedEntry(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedGap@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedGap(UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedGapFixed@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedGapFixed(UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedGapList@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedGapList(UInt16 gapval, UInt32 listaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedHalt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedHalt(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedLog@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedLog(UInt32 condition, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedMsg(UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedMsgEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedMsgEx(UInt32 msgaddr, UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedPulse@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedPulse(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedRestart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedReturn@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedReturn(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ChConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_CmdAddr(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_CmdAlloc(Int32 count, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdBaseRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_CmdBaseRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdBaseWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdBaseWr(UInt32 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdCountRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_CmdCountRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdCountWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdCountWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdCtrlRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_CmdCtrlRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdCtrlWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdCtrlWr(UInt16 ctrlval, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdCurrRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_CmdCurrRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdCurrWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdCurrWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdInit(UInt16 opcode, ref UInt16 block);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdInsert@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdInsert(ref UInt16 block, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdMaxLoopRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_CmdMaxLoopRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdMaxLoopWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdMaxLoopWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdRestart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdShotRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdShotRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdShotWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdShotWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdSkipRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdSkipRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdSkipWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdSkipWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdStackClr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdStackClr(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdStartRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_CmdStartRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdStartWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdStartWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdStepRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdStepRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdStepWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdStepWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdTotalRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdTotalRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdTotalWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdTotalWr(Int32 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_CmdWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ConvFromArinc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ConvFromArinc(UInt32 msgval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ConvToArinc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ConvToArinc(UInt32 msgval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_DllUsageCount();
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FilterAddr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FilterAddr(Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FilterCreate@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FilterCreate(UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FilterFill@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_FilterFill(UInt32 msgaddr, UInt32 basevaladdr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldGetParBit@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_FldGetParBit(UInt32 msgval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_FldPutParBit@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldPutParBit(UInt32 msgval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_GetChanCount@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_IsChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_IsChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_IsRcvChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_IsRcvChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_IsXmtChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_IsXmtChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_LabelReverse@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_LabelReverse(UInt32 msgval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListAddrEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListAdvance@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListAdvance(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListClear(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListConfig(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListConfigEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListDataBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListDataBlkRd(ref UInt32 dataptr, ref UInt16 datacountptr, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListDataBlkWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListDataBlkWr(ref UInt32 dataptr, UInt16 datacount, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListDataRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListDataRdEx(Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListDataWrEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ListDataWrEx(UInt32 value, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListInit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListNextRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListNextRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListNextWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListNextWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListPostRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListPostWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListPreRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_ListPreWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgActivityRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_MsgActivityRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgActivityWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgActivityWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_MsgCheck(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgCommRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgCommRd(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgCommWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgCommWr(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_MsgConfig(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_MsgReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgReset(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_Sched1Build@40", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched1Build(Int32 basevalmsgnum, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiodin, ref Int32 maxperiodin, Int32 speed, Int32 microflag, Int32 channum, Int32 debugval, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_Sched2AdvanceMessage@44", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched2AdvanceMessage(Int32 entries, Int32 panicindex, Int32 nummsgs, IntPtr infoptr, ref Int32 nextdeltaptr, Int32 ulmastertimer, ref UInt32 msgaddrptr, Int32 debugvalflag, Int32 tryflag, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_Sched2AdvanceNoMessage@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched2AdvanceNoMessage(Int32 nummsgs, IntPtr infoptr, ref Int32 nextdeltaptr, Int32 ulmastertimer, ref UInt32 msgaddrptr, Int32 debugvalflag, Int32 tryflag, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_Sched2Analyze@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_Sched2Analyze(Int32 nummsgs, IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_Sched2Build@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched2Build(Int32 nummsgs, ref UInt32 msgaddrptr, ref Int32 minlist, ref Int32 maxlist, Int32 speedflag, Int32 microflag, Int32 debugvalflag, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_Sched2BuildEx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched2BuildEx(ref Int32 styleptr, Int32 nummsgs, ref Int32 minlist, ref Int32 maxlist, Int32 speedflag, Int32 microflag);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_Sched2BuildExx@56", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched2BuildExx(Int32 style, Int32 speedflag, Int32 microflag, Int32 debugvalflag, Int32 tryflag, Int32 nummsgs, ref Int32 minlist, ref Int32 maxlist, ref Int32 entriesptr, ref Int32 maxentriesptr, IntPtr infoptr, ref UInt32 msgaddrptr, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedAdvance@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedAdvance(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedAgain@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedAgain(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedBranchEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBranchEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedBuildEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBuildEx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedBuildExx@40", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBuildExx(Int32 basevalmsgnum, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedBuildExxx@40", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBuildExxx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, Int32 channum, Int32 debugval, Int32 microflag, Int32 algorithm, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedCalc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedCalc(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedCallEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedCallEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedCheck@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedCheck(ref Int32 minperiod, ref Int32 maxperiod, IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedCheckEnd@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedCheckEnd();
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedCheckMiddle@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedCheckMiddle(UInt32 msgnum, UInt32 minlen, UInt32 midlen, UInt32 maxlen);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedCheckReal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedCheckReal(UInt32 msgnum, UInt32 minlen, UInt32 midlen, UInt32 maxlen);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedCheckStart@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedCheckStart();
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedConflicts@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedConflicts(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedDisplay@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern void BTI429_SchedDisplay(UInt32 nummsgs, ref UInt32 count, ref UInt32* data);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedDivide@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedDivide(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedFix@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedFix(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedFixEnd@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedFixEnd();
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedFixMiddle@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedFixMiddle(UInt32 conflicts);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedFixStart@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedFixStart();
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedHook@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedHook(Int32 index, IntPtr ptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedInsert@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedInsert(UInt32 eventvals, UInt32 index, UInt32 msgnum, ref UInt32 msgaddr, UInt32 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedInsert2@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedInsert2(UInt32 eventvals, UInt32 index, Int32 msgnum, ref UInt32 msgaddr, UInt32 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedInsertEnd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedInsertEnd(UInt32 eventvals, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedInsertStart@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedInsertStart(UInt32 eventvals, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedLayout@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedLayout(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedLogEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedLogEx(UInt16 condition1, UInt16 condition2, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedMaxval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedMaxval(ref UInt32 arrayval, UInt32 arrayvalcount);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedMinval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedMinval(ref UInt32 arrayval, UInt32 arrayvalcount);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedNop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedNop(Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedParse@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedParse(Int32 basevalmsgnum, ref UInt32 msgaddr, Int32 channum, IntPtr infoptr, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedPulse0@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedPulse0(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedPulse1@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedPulse1(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedReset(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedRotate@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedRotate(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedShift@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedShift(Int32 msgnum, Int32 value, IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedSlide@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedSlide(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedSlideEnd@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedSlideEnd();
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedSlideMiddle@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedSlideMiddle(UInt32 index, UInt32 count, UInt32 conflicts);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedSlideStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedSlideStart(UInt32 factor);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedSort@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedSort(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedToBit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedToBit(UInt32 value, IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedToMsec@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedToMsec(UInt32 value, IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedUnsort@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedUnsort(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedUser@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedUser(UInt32 useraddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_SchedWalk@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedWalk(IntPtr infoptr);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_TestProtocol@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_TestProtocol(UInt32 handleval);
            [DllImport("BTI429.DLL", EntryPoint = "_BTI429_Transpose12@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_Transpose12(UInt16 val);
        }

        private static class BTI429_64
        {
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BCDGetData", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDGetData(UInt32 msg, UInt16 msb, UInt16 lsb);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BCDGetMant", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDGetMant(UInt32 msg, UInt16 sigdig);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BCDGetSign", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_BCDGetSign(UInt32 msg);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BCDGetSSM", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_BCDGetSSM(UInt32 msg);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BCDGetVal", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_BCDGetVal(ref string buf, UInt32 msg, UInt16 sigdig, ref string resolstr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BCDPutData", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDPutData(UInt32 msg, UInt32 value, UInt16 msb, UInt16 lsb);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BCDPutMant", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDPutMant(UInt32 msg, UInt32 value, UInt16 sigdig, UInt16 sign);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BCDPutSign", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDPutSign(UInt32 msg, UInt16 sign);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BCDPutSSM", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDPutSSM(UInt32 msg, UInt16 value);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BCDPutVal", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BCDPutVal(ref string buf, UInt32 msg, UInt16 sigdig, ref string resolstr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BNRGetData", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRGetData(UInt32 msg, UInt16 msb, UInt16 lsb);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BNRGetMant", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRGetMant(UInt32 msg, UInt16 sigbit);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BNRGetSign", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_BNRGetSign(UInt32 msg);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BNRGetSSM", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_BNRGetSSM(UInt32 msg);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BNRGetVal", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_BNRGetVal(ref string buf, UInt32 msg, UInt16 sigbit, ref string resolstr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BNRPutData", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRPutData(UInt32 msg, UInt32 value, UInt16 msb, UInt16 lsb);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BNRPutMant", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRPutMant(UInt32 msg, UInt32 value, UInt16 sigbit, UInt16 twos);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BNRPutSign", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRPutSign(UInt32 msg, UInt16 twos);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BNRPutSSM", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRPutSSM(UInt32 msg, UInt16 value);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_BNRPutVal", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_BNRPutVal(ref string buf, UInt32 msg, UInt16 sigbit, ref string resolstr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChGetCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChGetInfo", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChIs429", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChIs429(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChIsRcv", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChIsRcv(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChIsXmt", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChIsXmt(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChPause", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ChPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChPauseCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChPauseCheck(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChResume", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ChResume(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChStart(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChStop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChStop(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChSyncDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChTriggerDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FilterClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_FilterClear(UInt32 basevaladdr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FilterDefault", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FilterDefault(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FilterRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FilterRd(Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FilterSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FilterSet(UInt32 configval, Int32 labelval, Int32 sdimask, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FilterWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_FilterWr(UInt32 msgaddr, Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldGetData", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldGetData(UInt32 msgval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldGetLabel", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_FldGetLabel(UInt32 msgval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldGetParity", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_FldGetParity(UInt32 msgval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldGetSDI", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_FldGetSDI(UInt32 msgval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldGetValue", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldGetValue(UInt32 msgval, UInt16 startbit, UInt16 endbit);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldPutData", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldPutData(UInt32 msgval, UInt32 data);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldPutLabel", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldPutLabel(UInt32 msgval, UInt16 label);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldPutSDI", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldPutSDI(UInt32 msgval, UInt16 sdi);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldPutValue", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldPutValue(UInt32 msgval, UInt32 dataval, UInt16 startbit, UInt16 endbit);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListAsyncCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListAsyncCreate(UInt32 listconfigval, Int32 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListDataRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListDataRd(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListDataWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListDataWr(UInt32 value, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListRcvCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListRcvCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListStatus(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListXmtCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListXmtCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgBlockRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgBlockRd(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgBlockWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgBlockWr(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgCreate(UInt32 configval, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgDataRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgDataRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgDataWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgDataWr(UInt32 value, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgGroupBlockRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgGroupBlockRd(ref MSGFIELDS429 msgfields, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgGroupBlockWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgGroupBlockWr(ref MSGFIELDS429 msgfields, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgGroupRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgGroupRd(ref UInt32 msgdataptr, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgGroupWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgGroupWr(ref UInt32 msgdataptr, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgIsAccessed", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgSkipRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_MsgSkipRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgSkipWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgSkipWr(Int32 skip, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgSyncDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_MsgSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgTriggerDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_MsgTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ParamAmplitudeConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ParamAmplitudeGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ParamBitRateConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ParamBitRateConfig(UInt32 configval, UInt16 divval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ParamBitRateGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ParamBitRateGet(ref UInt16 divval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedBranch", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBranch(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedBranchUpdate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBranchUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedBuild", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBuild(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedCall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedCall(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedCallUpdate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedCallUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedMode", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedMode(UInt32 modeval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedEntry", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedEntry(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedGap", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedGap(UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedGapFixed", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedGapFixed(UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedGapList", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedGapList(UInt16 gapval, UInt32 listaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedHalt", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedHalt(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedLog", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedLog(UInt32 condition, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedMsg", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedMsg(UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedMsgEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedMsgEx(UInt32 msgaddr, UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedPause", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedPulse", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedPulse(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedRestart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedReturn", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedReturn(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ChConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ChConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_CmdAddr(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdAlloc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_CmdAlloc(Int32 count, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdAllocEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdBaseRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_CmdBaseRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdBaseWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdBaseWr(UInt32 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdCountRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_CmdCountRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdCountWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdCountWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdCtrlRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_CmdCtrlRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdCtrlWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdCtrlWr(UInt16 ctrlval, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdCurrRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_CmdCurrRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdCurrWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdCurrWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdInit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdInit(UInt16 opcode, ref UInt16 block);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdInsert", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdInsert(ref UInt16 block, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdMaxLoopRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_CmdMaxLoopRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdMaxLoopWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdMaxLoopWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdRestart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdShotRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdShotRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdShotWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdShotWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdSkipRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdSkipRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdSkipWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdSkipWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdStackClr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdStackClr(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdStartRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_CmdStartRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdStartWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdStartWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdStepRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdStepRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdStepWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdStepWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdTotalRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdTotalRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdTotalWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_CmdTotalWr(Int32 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_CmdWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ConvFromArinc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ConvFromArinc(UInt32 msgval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ConvToArinc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ConvToArinc(UInt32 msgval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_DllUsageCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_DllUsageCount();
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FilterAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FilterAddr(Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FilterCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FilterCreate(UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FilterFill", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_FilterFill(UInt32 msgaddr, UInt32 basevaladdr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldGetParBit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_FldGetParBit(UInt32 msgval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_FldPutParBit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_FldPutParBit(UInt32 msgval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_GetChanCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_IsChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_IsChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_IsRcvChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_IsRcvChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_IsXmtChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_IsXmtChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_LabelReverse", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_LabelReverse(UInt32 msgval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListAddrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListAdvance", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListAdvance(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListClear(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListConfig(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListConfigEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListDataBlkRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListDataBlkRd(ref UInt32 dataptr, ref UInt16 datacountptr, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListDataBlkWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListDataBlkWr(ref UInt32 dataptr, UInt16 datacount, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListDataRdEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListDataRdEx(Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListDataWrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ListDataWrEx(UInt32 value, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListInit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListNextRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListNextRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListNextWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_ListNextWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListPostRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListPostWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListPreRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_ListPreWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgActivityRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_MsgActivityRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgActivityWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgActivityWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_MsgCheck(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgCommRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgCommRd(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgCommWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgCommWr(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_MsgConfig(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgOptRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgOptWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_MsgReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_MsgReset(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_Sched1Build", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched1Build(Int32 basevalmsgnum, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiodin, ref Int32 maxperiodin, Int32 speed, Int32 microflag, Int32 channum, Int32 debugval, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_Sched2AdvanceMessage", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched2AdvanceMessage(Int32 entries, Int32 panicindex, Int32 nummsgs, IntPtr infoptr, ref Int32 nextdeltaptr, Int32 ulmastertimer, ref UInt32 msgaddrptr, Int32 debugvalflag, Int32 tryflag, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_Sched2AdvanceNoMessage", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched2AdvanceNoMessage(Int32 nummsgs, IntPtr infoptr, ref Int32 nextdeltaptr, Int32 ulmastertimer, ref UInt32 msgaddrptr, Int32 debugvalflag, Int32 tryflag, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_Sched2Analyze", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_Sched2Analyze(Int32 nummsgs, IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_Sched2Build", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched2Build(Int32 nummsgs, ref UInt32 msgaddrptr, ref Int32 minlist, ref Int32 maxlist, Int32 speedflag, Int32 microflag, Int32 debugvalflag, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_Sched2BuildEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched2BuildEx(ref Int32 styleptr, Int32 nummsgs, ref Int32 minlist, ref Int32 maxlist, Int32 speedflag, Int32 microflag);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_Sched2BuildExx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_Sched2BuildExx(Int32 style, Int32 speedflag, Int32 microflag, Int32 debugvalflag, Int32 tryflag, Int32 nummsgs, ref Int32 minlist, ref Int32 maxlist, ref Int32 entriesptr, ref Int32 maxentriesptr, IntPtr infoptr, ref UInt32 msgaddrptr, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedAdvance", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedAdvance(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedAgain", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedAgain(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedBranchEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBranchEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedBuildEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBuildEx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedBuildExx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBuildExx(Int32 basevalmsgnum, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedBuildExxx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedBuildExxx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, Int32 channum, Int32 debugval, Int32 microflag, Int32 algorithm, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedCalc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedCalc(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedCallEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedCallEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedCheck(ref Int32 minperiod, ref Int32 maxperiod, IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedCheckEnd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedCheckEnd();
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedCheckMiddle", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedCheckMiddle(UInt32 msgnum, UInt32 minlen, UInt32 midlen, UInt32 maxlen);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedCheckReal", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedCheckReal(UInt32 msgnum, UInt32 minlen, UInt32 midlen, UInt32 maxlen);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedCheckStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedCheckStart();
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedConflicts", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedConflicts(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedDisplay", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            unsafe public static extern void BTI429_SchedDisplay(UInt32 nummsgs, ref UInt32 count, ref UInt32* data);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedDivide", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedDivide(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedFix", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedFix(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedFixEnd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedFixEnd();
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedFixMiddle", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedFixMiddle(UInt32 conflicts);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedFixStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedFixStart();
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedHook", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedHook(Int32 index, IntPtr ptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedInsert", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedInsert(UInt32 eventvals, UInt32 index, UInt32 msgnum, ref UInt32 msgaddr, UInt32 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedInsert2", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedInsert2(UInt32 eventvals, UInt32 index, Int32 msgnum, ref UInt32 msgaddr, UInt32 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedInsertEnd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedInsertEnd(UInt32 eventvals, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedInsertStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedInsertStart(UInt32 eventvals, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedLayout", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedLayout(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedLogEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedLogEx(UInt16 condition1, UInt16 condition2, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedMaxval", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedMaxval(ref UInt32 arrayval, UInt32 arrayvalcount);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedMinval", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedMinval(ref UInt32 arrayval, UInt32 arrayvalcount);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedNop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedNop(Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedParse", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedParse(Int32 basevalmsgnum, ref UInt32 msgaddr, Int32 channum, IntPtr infoptr, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedPulse0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedPulse0(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedPulse1", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedPulse1(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedReset(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedRotate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedRotate(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedShift", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedShift(Int32 msgnum, Int32 value, IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedSlide", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedSlide(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedSlideEnd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedSlideEnd();
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedSlideMiddle", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedSlideMiddle(UInt32 index, UInt32 count, UInt32 conflicts);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedSlideStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedSlideStart(UInt32 factor);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedSort", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedSort(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedToBit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedToBit(UInt32 value, IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedToMsec", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedToMsec(UInt32 value, IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedUnsort", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI429_SchedUnsort(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedUser", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_SchedUser(UInt32 useraddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_SchedWalk", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI429_SchedWalk(IntPtr infoptr);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_TestProtocol", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI429_TestProtocol(UInt32 handleval);
            [DllImport("BTI42964.DLL", EntryPoint = "BTI429_Transpose12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI429_Transpose12(UInt16 val);
        }

        public static UInt32 BTI429_BCDGetData(UInt32 msg, UInt16 msb, UInt16 lsb)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BCDGetData(msg, msb, lsb);
            else
                return BTI429_64.BTI429_BCDGetData(msg, msb, lsb);
        }
        public static UInt32 BTI429_BCDGetMant(UInt32 msg, UInt16 sigdig)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BCDGetMant(msg, sigdig);
            else
                return BTI429_64.BTI429_BCDGetMant(msg, sigdig);
        }
        public static UInt16 BTI429_BCDGetSign(UInt32 msg)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BCDGetSign(msg);
            else
                return BTI429_64.BTI429_BCDGetSign(msg);
        }
        public static UInt16 BTI429_BCDGetSSM(UInt32 msg)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BCDGetSSM(msg);
            else
                return BTI429_64.BTI429_BCDGetSSM(msg);
        }
        public static void BTI429_BCDGetVal(ref string buf, UInt32 msg, UInt16 sigdig, ref string resolstr)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_BCDGetVal(ref buf, msg, sigdig, ref resolstr);
            else
                BTI429_64.BTI429_BCDGetVal(ref buf, msg, sigdig, ref resolstr);
        }
        public static UInt32 BTI429_BCDPutData(UInt32 msg, UInt32 value, UInt16 msb, UInt16 lsb)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BCDPutData(msg, value, msb, lsb);
            else
                return BTI429_64.BTI429_BCDPutData(msg, value, msb, lsb);
        }
        public static UInt32 BTI429_BCDPutMant(UInt32 msg, UInt32 value, UInt16 sigdig, UInt16 sign)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BCDPutMant(msg, value, sigdig, sign);
            else
                return BTI429_64.BTI429_BCDPutMant(msg, value, sigdig, sign);
        }
        public static UInt32 BTI429_BCDPutSign(UInt32 msg, UInt16 sign)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BCDPutSign(msg, sign);
            else
                return BTI429_64.BTI429_BCDPutSign(msg, sign);
        }
        public static UInt32 BTI429_BCDPutSSM(UInt32 msg, UInt16 value)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BCDPutSSM(msg, value);
            else
                return BTI429_64.BTI429_BCDPutSSM(msg, value);
        }
        public static UInt32 BTI429_BCDPutVal(ref string buf, UInt32 msg, UInt16 sigdig, ref string resolstr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BCDPutVal(ref buf, msg, sigdig, ref resolstr);
            else
                return BTI429_64.BTI429_BCDPutVal(ref buf, msg, sigdig, ref resolstr);
        }
        public static UInt32 BTI429_BNRGetData(UInt32 msg, UInt16 msb, UInt16 lsb)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BNRGetData(msg, msb, lsb);
            else
                return BTI429_64.BTI429_BNRGetData(msg, msb, lsb);
        }
        public static UInt32 BTI429_BNRGetMant(UInt32 msg, UInt16 sigbit)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BNRGetMant(msg, sigbit);
            else
                return BTI429_64.BTI429_BNRGetMant(msg, sigbit);
        }
        public static UInt16 BTI429_BNRGetSign(UInt32 msg)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BNRGetSign(msg);
            else
                return BTI429_64.BTI429_BNRGetSign(msg);
        }
        public static UInt16 BTI429_BNRGetSSM(UInt32 msg)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BNRGetSSM(msg);
            else
                return BTI429_64.BTI429_BNRGetSSM(msg);
        }
        public static void BTI429_BNRGetVal(ref string buf, UInt32 msg, UInt16 sigbit, ref string resolstr)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_BNRGetVal(ref buf, msg, sigbit, ref resolstr);
            else
                BTI429_64.BTI429_BNRGetVal(ref buf, msg, sigbit, ref resolstr);
        }
        public static UInt32 BTI429_BNRPutData(UInt32 msg, UInt32 value, UInt16 msb, UInt16 lsb)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BNRPutData(msg, value, msb, lsb);
            else
                return BTI429_64.BTI429_BNRPutData(msg, value, msb, lsb);
        }
        public static UInt32 BTI429_BNRPutMant(UInt32 msg, UInt32 value, UInt16 sigbit, UInt16 twos)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BNRPutMant(msg, value, sigbit, twos);
            else
                return BTI429_64.BTI429_BNRPutMant(msg, value, sigbit, twos);
        }
        public static UInt32 BTI429_BNRPutSign(UInt32 msg, UInt16 twos)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BNRPutSign(msg, twos);
            else
                return BTI429_64.BTI429_BNRPutSign(msg, twos);
        }
        public static UInt32 BTI429_BNRPutSSM(UInt32 msg, UInt16 value)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BNRPutSSM(msg, value);
            else
                return BTI429_64.BTI429_BNRPutSSM(msg, value);
        }
        public static UInt32 BTI429_BNRPutVal(ref string buf, UInt32 msg, UInt16 sigbit, ref string resolstr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_BNRPutVal(ref buf, msg, sigbit, ref resolstr);
            else
                return BTI429_64.BTI429_BNRPutVal(ref buf, msg, sigbit, ref resolstr);
        }
        public static Int32 BTI429_ChClear(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChClear(channum, handleval);
            else
                return BTI429_64.BTI429_ChClear(channum, handleval);
        }
        public static Int32 BTI429_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChConfig(configval, channum, handleval);
            else
                return BTI429_64.BTI429_ChConfig(configval, channum, handleval);
        }
        public static void BTI429_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_ChGetCount(ref rcvcount, ref xmtcount, handleval);
            else
                BTI429_64.BTI429_ChGetCount(ref rcvcount, ref xmtcount, handleval);
        }
        public static UInt32 BTI429_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChGetInfo(infotype, channum, handleval);
            else
                return BTI429_64.BTI429_ChGetInfo(infotype, channum, handleval);
        }
        public static Int32 BTI429_ChIs429(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChIs429(channum, handleval);
            else
                return BTI429_64.BTI429_ChIs429(channum, handleval);
        }
        public static Int32 BTI429_ChIsRcv(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChIsRcv(channum, handleval);
            else
                return BTI429_64.BTI429_ChIsRcv(channum, handleval);
        }
        public static Int32 BTI429_ChIsXmt(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChIsXmt(channum, handleval);
            else
                return BTI429_64.BTI429_ChIsXmt(channum, handleval);
        }
        public static void BTI429_ChPause(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_ChPause(channum, handleval);
            else
                BTI429_64.BTI429_ChPause(channum, handleval);
        }
        public static Int32 BTI429_ChPauseCheck(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChPauseCheck(channum, handleval);
            else
                return BTI429_64.BTI429_ChPauseCheck(channum, handleval);
        }
        public static void BTI429_ChResume(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_ChResume(channum, handleval);
            else
                BTI429_64.BTI429_ChResume(channum, handleval);
        }
        public static Int32 BTI429_ChStart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChStart(channum, handleval);
            else
                return BTI429_64.BTI429_ChStart(channum, handleval);
        }
        public static Int32 BTI429_ChStop(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChStop(channum, handleval);
            else
                return BTI429_64.BTI429_ChStop(channum, handleval);
        }
        public static Int32 BTI429_ChSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval);
            else
                return BTI429_64.BTI429_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval);
        }
        public static Int32 BTI429_ChTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
            else
                return BTI429_64.BTI429_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
        }
        public static Int32 BTI429_FilterClear(UInt32 basevaladdr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FilterClear(basevaladdr, handleval);
            else
                return BTI429_64.BTI429_FilterClear(basevaladdr, handleval);
        }
        public static UInt32 BTI429_FilterDefault(UInt32 configval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FilterDefault(configval, channum, handleval);
            else
                return BTI429_64.BTI429_FilterDefault(configval, channum, handleval);
        }
        public static UInt32 BTI429_FilterRd(Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FilterRd(labelval, sdival, channum, handleval);
            else
                return BTI429_64.BTI429_FilterRd(labelval, sdival, channum, handleval);
        }
        public static UInt32 BTI429_FilterSet(UInt32 configval, Int32 labelval, Int32 sdimask, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FilterSet(configval, labelval, sdimask, channum, handleval);
            else
                return BTI429_64.BTI429_FilterSet(configval, labelval, sdimask, channum, handleval);
        }
        public static Int32 BTI429_FilterWr(UInt32 msgaddr, Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FilterWr(msgaddr, labelval, sdival, channum, handleval);
            else
                return BTI429_64.BTI429_FilterWr(msgaddr, labelval, sdival, channum, handleval);
        }
        public static UInt32 BTI429_FldGetData(UInt32 msgval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldGetData(msgval);
            else
                return BTI429_64.BTI429_FldGetData(msgval);
        }
        public static UInt16 BTI429_FldGetLabel(UInt32 msgval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldGetLabel(msgval);
            else
                return BTI429_64.BTI429_FldGetLabel(msgval);
        }
        public static UInt16 BTI429_FldGetParity(UInt32 msgval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldGetParity(msgval);
            else
                return BTI429_64.BTI429_FldGetParity(msgval);
        }
        public static UInt16 BTI429_FldGetSDI(UInt32 msgval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldGetSDI(msgval);
            else
                return BTI429_64.BTI429_FldGetSDI(msgval);
        }
        public static UInt32 BTI429_FldGetValue(UInt32 msgval, UInt16 startbit, UInt16 endbit)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldGetValue(msgval, startbit, endbit);
            else
                return BTI429_64.BTI429_FldGetValue(msgval, startbit, endbit);
        }
        public static UInt32 BTI429_FldPutData(UInt32 msgval, UInt32 data)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldPutData(msgval, data);
            else
                return BTI429_64.BTI429_FldPutData(msgval, data);
        }
        public static UInt32 BTI429_FldPutLabel(UInt32 msgval, UInt16 label)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldPutLabel(msgval, label);
            else
                return BTI429_64.BTI429_FldPutLabel(msgval, label);
        }
        public static UInt32 BTI429_FldPutSDI(UInt32 msgval, UInt16 sdi)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldPutSDI(msgval, sdi);
            else
                return BTI429_64.BTI429_FldPutSDI(msgval, sdi);
        }
        public static UInt32 BTI429_FldPutValue(UInt32 msgval, UInt32 dataval, UInt16 startbit, UInt16 endbit)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldPutValue(msgval, dataval, startbit, endbit);
            else
                return BTI429_64.BTI429_FldPutValue(msgval, dataval, startbit, endbit);
        }
        public static UInt32 BTI429_ListAsyncCreate(UInt32 listconfigval, Int32 count, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListAsyncCreate(listconfigval, count, channum, handleval);
            else
                return BTI429_64.BTI429_ListAsyncCreate(listconfigval, count, channum, handleval);
        }
        public static UInt32 BTI429_ListDataRd(UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListDataRd(listaddr, handleval);
            else
                return BTI429_64.BTI429_ListDataRd(listaddr, handleval);
        }
        public static Int32 BTI429_ListDataWr(UInt32 value, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListDataWr(value, listaddr, handleval);
            else
                return BTI429_64.BTI429_ListDataWr(value, listaddr, handleval);
        }
        public static UInt32 BTI429_ListRcvCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListRcvCreate(listconfigval, count, msgaddr, handleval);
            else
                return BTI429_64.BTI429_ListRcvCreate(listconfigval, count, msgaddr, handleval);
        }
        public static Int32 BTI429_ListStatus(UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListStatus(listaddr, handleval);
            else
                return BTI429_64.BTI429_ListStatus(listaddr, handleval);
        }
        public static UInt32 BTI429_ListXmtCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListXmtCreate(listconfigval, count, msgaddr, handleval);
            else
                return BTI429_64.BTI429_ListXmtCreate(listconfigval, count, msgaddr, handleval);
        }
        public static UInt32 BTI429_MsgBlockRd(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgBlockRd(ref msgfields, msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgBlockRd(ref msgfields, msgaddr, handleval);
        }
        public static UInt32 BTI429_MsgBlockWr(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgBlockWr(ref msgfields, msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgBlockWr(ref msgfields, msgaddr, handleval);
        }
        public static UInt32 BTI429_MsgCreate(UInt32 configval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgCreate(configval, handleval);
            else
                return BTI429_64.BTI429_MsgCreate(configval, handleval);
        }
        public static UInt32 BTI429_MsgDataRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgDataRd(msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgDataRd(msgaddr, handleval);
        }
        public static void BTI429_MsgDataWr(UInt32 value, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_MsgDataWr(value, msgaddr, handleval);
            else
                BTI429_64.BTI429_MsgDataWr(value, msgaddr, handleval);
        }
        public static void BTI429_MsgGroupBlockRd(ref MSGFIELDS429 msgfields, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_MsgGroupBlockRd(ref msgfields, ref msgaddrptr, nummsgs, handleval);
            else
                BTI429_64.BTI429_MsgGroupBlockRd(ref msgfields, ref msgaddrptr, nummsgs, handleval);
        }
        public static void BTI429_MsgGroupBlockWr(ref MSGFIELDS429 msgfields, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_MsgGroupBlockWr(ref msgfields, ref msgaddrptr, nummsgs, handleval);
            else
                BTI429_64.BTI429_MsgGroupBlockWr(ref msgfields, ref msgaddrptr, nummsgs, handleval);
        }
        public static void BTI429_MsgGroupRd(ref UInt32 msgdataptr, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_MsgGroupRd(ref msgdataptr, ref msgaddrptr, nummsgs, handleval);
            else
                BTI429_64.BTI429_MsgGroupRd(ref msgdataptr, ref msgaddrptr, nummsgs, handleval);
        }
        public static void BTI429_MsgGroupWr(ref UInt32 msgdataptr, ref UInt32 msgaddrptr, Int32 nummsgs, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_MsgGroupWr(ref msgdataptr, ref msgaddrptr, nummsgs, handleval);
            else
                BTI429_64.BTI429_MsgGroupWr(ref msgdataptr, ref msgaddrptr, nummsgs, handleval);
        }
        public static Int32 BTI429_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgIsAccessed(msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgIsAccessed(msgaddr, handleval);
        }
        public static Int32 BTI429_MsgSkipRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgSkipRd(msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgSkipRd(msgaddr, handleval);
        }
        public static void BTI429_MsgSkipWr(Int32 skip, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_MsgSkipWr(skip, msgaddr, handleval);
            else
                BTI429_64.BTI429_MsgSkipWr(skip, msgaddr, handleval);
        }
        public static Int32 BTI429_MsgSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgaddr, handleval);
        }
        public static Int32 BTI429_MsgTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgaddr, handleval);
        }
        public static Int32 BTI429_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ParamAmplitudeConfig(configval, dacval, channum, handleval);
            else
                return BTI429_64.BTI429_ParamAmplitudeConfig(configval, dacval, channum, handleval);
        }
        public static Int32 BTI429_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ParamAmplitudeGet(ref dacval, channum, handleval);
            else
                return BTI429_64.BTI429_ParamAmplitudeGet(ref dacval, channum, handleval);
        }
        public static Int32 BTI429_ParamBitRateConfig(UInt32 configval, UInt16 divval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ParamBitRateConfig(configval, divval, channum, handleval);
            else
                return BTI429_64.BTI429_ParamBitRateConfig(configval, divval, channum, handleval);
        }
        public static Int32 BTI429_ParamBitRateGet(ref UInt16 divval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ParamBitRateGet(ref divval, channum, handleval);
            else
                return BTI429_64.BTI429_ParamBitRateGet(ref divval, channum, handleval);
        }
        public static Int32 BTI429_SchedBranch(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedBranch(condition, destindex, channum, handleval);
            else
                return BTI429_64.BTI429_SchedBranch(condition, destindex, channum, handleval);
        }
        public static Int32 BTI429_SchedBranchUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedBranchUpdate(destindex, opcodeindex, channum, handleval);
            else
                return BTI429_64.BTI429_SchedBranchUpdate(destindex, opcodeindex, channum, handleval);
        }
        public static Int32 BTI429_SchedBuild(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedBuild(nummsgs, ref msgaddr, ref minperiod, ref maxperiod, channum, handleval);
            else
                return BTI429_64.BTI429_SchedBuild(nummsgs, ref msgaddr, ref minperiod, ref maxperiod, channum, handleval);
        }
        public static Int32 BTI429_SchedCall(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedCall(condition, destindex, channum, handleval);
            else
                return BTI429_64.BTI429_SchedCall(condition, destindex, channum, handleval);
        }
        public static Int32 BTI429_SchedCallUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedCallUpdate(destindex, opcodeindex, channum, handleval);
            else
                return BTI429_64.BTI429_SchedCallUpdate(destindex, opcodeindex, channum, handleval);
        }
        public static Int32 BTI429_SchedMode(UInt32 modeval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedMode(modeval);
            else
                return BTI429_64.BTI429_SchedMode(modeval);
        }
        public static Int32 BTI429_SchedEntry(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedEntry(channum, handleval);
            else
                return BTI429_64.BTI429_SchedEntry(channum, handleval);
        }
        public static Int32 BTI429_SchedGap(UInt16 gapval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedGap(gapval, channum, handleval);
            else
                return BTI429_64.BTI429_SchedGap(gapval, channum, handleval);
        }
        public static Int32 BTI429_SchedGapFixed(UInt16 gapval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedGapFixed(gapval, channum, handleval);
            else
                return BTI429_64.BTI429_SchedGapFixed(gapval, channum, handleval);
        }
        public static Int32 BTI429_SchedGapList(UInt16 gapval, UInt32 listaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedGapList(gapval, listaddr, channum, handleval);
            else
                return BTI429_64.BTI429_SchedGapList(gapval, listaddr, channum, handleval);
        }
        public static Int32 BTI429_SchedHalt(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedHalt(channum, handleval);
            else
                return BTI429_64.BTI429_SchedHalt(channum, handleval);
        }
        public static Int32 BTI429_SchedLog(UInt32 condition, UInt16 tagval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedLog(condition, tagval, channum, handleval);
            else
                return BTI429_64.BTI429_SchedLog(condition, tagval, channum, handleval);
        }
        public static Int32 BTI429_SchedMsg(UInt32 msgaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedMsg(msgaddr, channum, handleval);
            else
                return BTI429_64.BTI429_SchedMsg(msgaddr, channum, handleval);
        }
        public static Int32 BTI429_SchedMsgEx(UInt32 msgaddr, UInt16 gapval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedMsgEx(msgaddr, gapval, channum, handleval);
            else
                return BTI429_64.BTI429_SchedMsgEx(msgaddr, gapval, channum, handleval);
        }
        public static Int32 BTI429_SchedPause(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedPause(channum, handleval);
            else
                return BTI429_64.BTI429_SchedPause(channum, handleval);
        }
        public static Int32 BTI429_SchedPulse(Int32 dionum, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedPulse(dionum, channum, handleval);
            else
                return BTI429_64.BTI429_SchedPulse(dionum, channum, handleval);
        }
        public static Int32 BTI429_SchedRestart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedRestart(channum, handleval);
            else
                return BTI429_64.BTI429_SchedRestart(channum, handleval);
        }
        public static Int32 BTI429_SchedReturn(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedReturn(channum, handleval);
            else
                return BTI429_64.BTI429_SchedReturn(channum, handleval);
        }
        public static Int32 BTI429_ChConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ChConfigEx(configval, count, channum, handleval);
            else
                return BTI429_64.BTI429_ChConfigEx(configval, count, channum, handleval);
        }
        public static UInt32 BTI429_CmdAddr(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdAddr(index, channum, handleval);
            else
                return BTI429_64.BTI429_CmdAddr(index, channum, handleval);
        }
        public static UInt32 BTI429_CmdAlloc(Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdAlloc(count, handleval);
            else
                return BTI429_64.BTI429_CmdAlloc(count, handleval);
        }
        public static UInt32 BTI429_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdAllocEx(configval, count, handleval);
            else
                return BTI429_64.BTI429_CmdAllocEx(configval, count, handleval);
        }
        public static UInt32 BTI429_CmdBaseRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdBaseRd(channum, handleval);
            else
                return BTI429_64.BTI429_CmdBaseRd(channum, handleval);
        }
        public static void BTI429_CmdBaseWr(UInt32 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_CmdBaseWr(addrval, channum, handleval);
            else
                BTI429_64.BTI429_CmdBaseWr(addrval, channum, handleval);
        }
        public static Int32 BTI429_CmdClear(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdClear(channum, handleval);
            else
                return BTI429_64.BTI429_CmdClear(channum, handleval);
        }
        public static UInt16 BTI429_CmdCountRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdCountRd(channum, handleval);
            else
                return BTI429_64.BTI429_CmdCountRd(channum, handleval);
        }
        public static void BTI429_CmdCountWr(UInt16 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_CmdCountWr(countval, channum, handleval);
            else
                BTI429_64.BTI429_CmdCountWr(countval, channum, handleval);
        }
        public static UInt16 BTI429_CmdCtrlRd(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdCtrlRd(index, channum, handleval);
            else
                return BTI429_64.BTI429_CmdCtrlRd(index, channum, handleval);
        }
        public static void BTI429_CmdCtrlWr(UInt16 ctrlval, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_CmdCtrlWr(ctrlval, index, channum, handleval);
            else
                BTI429_64.BTI429_CmdCtrlWr(ctrlval, index, channum, handleval);
        }
        public static UInt16 BTI429_CmdCurrRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdCurrRd(channum, handleval);
            else
                return BTI429_64.BTI429_CmdCurrRd(channum, handleval);
        }
        public static void BTI429_CmdCurrWr(UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_CmdCurrWr(addrval, channum, handleval);
            else
                BTI429_64.BTI429_CmdCurrWr(addrval, channum, handleval);
        }
        public static void BTI429_CmdInit(UInt16 opcode, ref UInt16 block)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_CmdInit(opcode, ref block);
            else
                BTI429_64.BTI429_CmdInit(opcode, ref block);
        }
        public static Int32 BTI429_CmdInsert(ref UInt16 block, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdInsert(ref block, channum, handleval);
            else
                return BTI429_64.BTI429_CmdInsert(ref block, channum, handleval);
        }
        public static UInt16 BTI429_CmdMaxLoopRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdMaxLoopRd(channum, handleval);
            else
                return BTI429_64.BTI429_CmdMaxLoopRd(channum, handleval);
        }
        public static void BTI429_CmdMaxLoopWr(UInt16 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_CmdMaxLoopWr(countval, channum, handleval);
            else
                BTI429_64.BTI429_CmdMaxLoopWr(countval, channum, handleval);
        }
        public static Int32 BTI429_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdRd(ref block, addrval, handleval);
            else
                return BTI429_64.BTI429_CmdRd(ref block, addrval, handleval);
        }
        public static void BTI429_CmdRestart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_CmdRestart(channum, handleval);
            else
                BTI429_64.BTI429_CmdRestart(channum, handleval);
        }
        public static Int32 BTI429_CmdShotRd(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdShotRd(index, channum, handleval);
            else
                return BTI429_64.BTI429_CmdShotRd(index, channum, handleval);
        }
        public static Int32 BTI429_CmdShotWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdShotWr(value, index, channum, handleval);
            else
                return BTI429_64.BTI429_CmdShotWr(value, index, channum, handleval);
        }
        public static Int32 BTI429_CmdSkipRd(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdSkipRd(index, channum, handleval);
            else
                return BTI429_64.BTI429_CmdSkipRd(index, channum, handleval);
        }
        public static Int32 BTI429_CmdSkipWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdSkipWr(value, index, channum, handleval);
            else
                return BTI429_64.BTI429_CmdSkipWr(value, index, channum, handleval);
        }
        public static void BTI429_CmdStackClr(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_CmdStackClr(channum, handleval);
            else
                BTI429_64.BTI429_CmdStackClr(channum, handleval);
        }
        public static UInt16 BTI429_CmdStartRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdStartRd(channum, handleval);
            else
                return BTI429_64.BTI429_CmdStartRd(channum, handleval);
        }
        public static void BTI429_CmdStartWr(UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_CmdStartWr(addrval, channum, handleval);
            else
                BTI429_64.BTI429_CmdStartWr(addrval, channum, handleval);
        }
        public static Int32 BTI429_CmdStepRd(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdStepRd(index, channum, handleval);
            else
                return BTI429_64.BTI429_CmdStepRd(index, channum, handleval);
        }
        public static Int32 BTI429_CmdStepWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdStepWr(value, index, channum, handleval);
            else
                return BTI429_64.BTI429_CmdStepWr(value, index, channum, handleval);
        }
        public static Int32 BTI429_CmdTotalRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdTotalRd(channum, handleval);
            else
                return BTI429_64.BTI429_CmdTotalRd(channum, handleval);
        }
        public static void BTI429_CmdTotalWr(Int32 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_CmdTotalWr(countval, channum, handleval);
            else
                BTI429_64.BTI429_CmdTotalWr(countval, channum, handleval);
        }
        public static Int32 BTI429_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_CmdWr(ref block, addrval, handleval);
            else
                return BTI429_64.BTI429_CmdWr(ref block, addrval, handleval);
        }
        public static UInt32 BTI429_ConvFromArinc(UInt32 msgval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ConvFromArinc(msgval);
            else
                return BTI429_64.BTI429_ConvFromArinc(msgval);
        }
        public static UInt32 BTI429_ConvToArinc(UInt32 msgval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ConvToArinc(msgval);
            else
                return BTI429_64.BTI429_ConvToArinc(msgval);
        }
        public static Int32 BTI429_DllUsageCount()
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_DllUsageCount();
            else
                return BTI429_64.BTI429_DllUsageCount();
        }
        public static UInt32 BTI429_FilterAddr(Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FilterAddr(labelval, sdival, channum, handleval);
            else
                return BTI429_64.BTI429_FilterAddr(labelval, sdival, channum, handleval);
        }
        public static UInt32 BTI429_FilterCreate(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FilterCreate(handleval);
            else
                return BTI429_64.BTI429_FilterCreate(handleval);
        }
        public static Int32 BTI429_FilterFill(UInt32 msgaddr, UInt32 basevaladdr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FilterFill(msgaddr, basevaladdr, handleval);
            else
                return BTI429_64.BTI429_FilterFill(msgaddr, basevaladdr, handleval);
        }
        public static UInt16 BTI429_FldGetParBit(UInt32 msgval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldGetParBit(msgval);
            else
                return BTI429_64.BTI429_FldGetParBit(msgval);
        }
        public static UInt32 BTI429_FldPutParBit(UInt32 msgval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_FldPutParBit(msgval);
            else
                return BTI429_64.BTI429_FldPutParBit(msgval);
        }
        public static void BTI429_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_GetChanCount(ref rcvcount, ref xmtcount, handleval);
            else
                BTI429_64.BTI429_GetChanCount(ref rcvcount, ref xmtcount, handleval);
        }
        public static Int32 BTI429_IsChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_IsChan(channum, handleval);
            else
                return BTI429_64.BTI429_IsChan(channum, handleval);
        }
        public static Int32 BTI429_IsRcvChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_IsRcvChan(channum, handleval);
            else
                return BTI429_64.BTI429_IsRcvChan(channum, handleval);
        }
        public static Int32 BTI429_IsXmtChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_IsXmtChan(channum, handleval);
            else
                return BTI429_64.BTI429_IsXmtChan(channum, handleval);
        }
        public static UInt32 BTI429_LabelReverse(UInt32 msgval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_LabelReverse(msgval);
            else
                return BTI429_64.BTI429_LabelReverse(msgval);
        }
        public static UInt32 BTI429_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListAddr(index, listaddr, handleval);
            else
                return BTI429_64.BTI429_ListAddr(index, listaddr, handleval);
        }
        public static UInt32 BTI429_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListAddrEx(index, listaddr, ref header, handleval);
            else
                return BTI429_64.BTI429_ListAddrEx(index, listaddr, ref header, handleval);
        }
        public static Int32 BTI429_ListAdvance(UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListAdvance(listaddr, handleval);
            else
                return BTI429_64.BTI429_ListAdvance(listaddr, handleval);
        }
        public static Int32 BTI429_ListClear(UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListClear(listaddr, handleval);
            else
                return BTI429_64.BTI429_ListClear(listaddr, handleval);
        }
        public static UInt32 BTI429_ListConfig(UInt32 configval, Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListConfig(configval, count, handleval);
            else
                return BTI429_64.BTI429_ListConfig(configval, count, handleval);
        }
        public static UInt32 BTI429_ListConfigEx(UInt32 configval, Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListConfigEx(configval, count, handleval);
            else
                return BTI429_64.BTI429_ListConfigEx(configval, count, handleval);
        }
        public static Int32 BTI429_ListDataBlkRd(ref UInt32 dataptr, ref UInt16 datacountptr, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListDataBlkRd(ref dataptr, ref datacountptr, listaddr, handleval);
            else
                return BTI429_64.BTI429_ListDataBlkRd(ref dataptr, ref datacountptr, listaddr, handleval);
        }
        public static Int32 BTI429_ListDataBlkWr(ref UInt32 dataptr, UInt16 datacount, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListDataBlkWr(ref dataptr, datacount, listaddr, handleval);
            else
                return BTI429_64.BTI429_ListDataBlkWr(ref dataptr, datacount, listaddr, handleval);
        }
        public static UInt32 BTI429_ListDataRdEx(Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListDataRdEx(index, listaddr, handleval);
            else
                return BTI429_64.BTI429_ListDataRdEx(index, listaddr, handleval);
        }
        public static void BTI429_ListDataWrEx(UInt32 value, Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_ListDataWrEx(value, index, listaddr, handleval);
            else
                BTI429_64.BTI429_ListDataWrEx(value, index, listaddr, handleval);
        }
        public static Int32 BTI429_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListInit(listaddr, msgaddr, handleval);
            else
                return BTI429_64.BTI429_ListInit(listaddr, msgaddr, handleval);
        }
        public static UInt32 BTI429_ListNextRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListNextRd(listaddr, ref header, handleval);
            else
                return BTI429_64.BTI429_ListNextRd(listaddr, ref header, handleval);
        }
        public static UInt32 BTI429_ListNextWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_ListNextWr(listaddr, ref header, handleval);
            else
                return BTI429_64.BTI429_ListNextWr(listaddr, ref header, handleval);
        }
        public static void BTI429_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_ListPostRd(listaddr, ref header, handleval);
            else
                BTI429_64.BTI429_ListPostRd(listaddr, ref header, handleval);
        }
        public static void BTI429_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_ListPostWr(listaddr, ref header, handleval);
            else
                BTI429_64.BTI429_ListPostWr(listaddr, ref header, handleval);
        }
        public static void BTI429_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_ListPreRd(listaddr, ref header, handleval);
            else
                BTI429_64.BTI429_ListPreRd(listaddr, ref header, handleval);
        }
        public static void BTI429_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_ListPreWr(listaddr, ref header, handleval);
            else
                BTI429_64.BTI429_ListPreWr(listaddr, ref header, handleval);
        }
        public static UInt16 BTI429_MsgActivityRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgActivityRd(msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgActivityRd(msgaddr, handleval);
        }
        public static void BTI429_MsgActivityWr(UInt16 value, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_MsgActivityWr(value, msgaddr, handleval);
            else
                BTI429_64.BTI429_MsgActivityWr(value, msgaddr, handleval);
        }
        public static UInt16 BTI429_MsgCheck(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgCheck(msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgCheck(msgaddr, handleval);
        }
        public static UInt32 BTI429_MsgCommRd(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgCommRd(ref msgfields, msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgCommRd(ref msgfields, msgaddr, handleval);
        }
        public static UInt32 BTI429_MsgCommWr(ref MSGFIELDS429 msgfields, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgCommWr(ref msgfields, msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgCommWr(ref msgfields, msgaddr, handleval);
        }
        public static Int32 BTI429_MsgConfig(UInt32 configval, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgConfig(configval, msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgConfig(configval, msgaddr, handleval);
        }
        public static UInt16 BTI429_MsgOptRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgOptRd(msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgOptRd(msgaddr, handleval);
        }
        public static void BTI429_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_MsgOptWr(msgopt, msgaddr, handleval);
            else
                BTI429_64.BTI429_MsgOptWr(msgopt, msgaddr, handleval);
        }
        public static UInt32 BTI429_MsgReset(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_MsgReset(msgaddr, handleval);
            else
                return BTI429_64.BTI429_MsgReset(msgaddr, handleval);
        }
        public static Int32 BTI429_Sched1Build(Int32 basevalmsgnum, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiodin, ref Int32 maxperiodin, Int32 speed, Int32 microflag, Int32 channum, Int32 debugval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_Sched1Build(basevalmsgnum, nummsgs, ref msgaddr, ref minperiodin, ref maxperiodin, speed, microflag, channum, debugval, handleval);
            else
                return BTI429_64.BTI429_Sched1Build(basevalmsgnum, nummsgs, ref msgaddr, ref minperiodin, ref maxperiodin, speed, microflag, channum, debugval, handleval);
        }
        public static Int32 BTI429_Sched2AdvanceMessage(Int32 entries, Int32 panicindex, Int32 nummsgs, IntPtr infoptr, ref Int32 nextdeltaptr, Int32 ulmastertimer, ref UInt32 msgaddrptr, Int32 debugvalflag, Int32 tryflag, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_Sched2AdvanceMessage(entries, panicindex, nummsgs, infoptr, ref nextdeltaptr, ulmastertimer, ref msgaddrptr, debugvalflag, tryflag, channum, handleval);
            else
                return BTI429_64.BTI429_Sched2AdvanceMessage(entries, panicindex, nummsgs, infoptr, ref nextdeltaptr, ulmastertimer, ref msgaddrptr, debugvalflag, tryflag, channum, handleval);
        }
        public static Int32 BTI429_Sched2AdvanceNoMessage(Int32 nummsgs, IntPtr infoptr, ref Int32 nextdeltaptr, Int32 ulmastertimer, ref UInt32 msgaddrptr, Int32 debugvalflag, Int32 tryflag, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_Sched2AdvanceNoMessage(nummsgs, infoptr, ref nextdeltaptr, ulmastertimer, ref msgaddrptr, debugvalflag, tryflag, channum, handleval);
            else
                return BTI429_64.BTI429_Sched2AdvanceNoMessage(nummsgs, infoptr, ref nextdeltaptr, ulmastertimer, ref msgaddrptr, debugvalflag, tryflag, channum, handleval);
        }
        public static void BTI429_Sched2Analyze(Int32 nummsgs, IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_Sched2Analyze(nummsgs, infoptr);
            else
                BTI429_64.BTI429_Sched2Analyze(nummsgs, infoptr);
        }
        public static Int32 BTI429_Sched2Build(Int32 nummsgs, ref UInt32 msgaddrptr, ref Int32 minlist, ref Int32 maxlist, Int32 speedflag, Int32 microflag, Int32 debugvalflag, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_Sched2Build(nummsgs, ref msgaddrptr, ref minlist, ref maxlist, speedflag, microflag, debugvalflag, channum, handleval);
            else
                return BTI429_64.BTI429_Sched2Build(nummsgs, ref msgaddrptr, ref minlist, ref maxlist, speedflag, microflag, debugvalflag, channum, handleval);
        }
        public static Int32 BTI429_Sched2BuildEx(ref Int32 styleptr, Int32 nummsgs, ref Int32 minlist, ref Int32 maxlist, Int32 speedflag, Int32 microflag)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_Sched2BuildEx(ref styleptr, nummsgs, ref minlist, ref maxlist, speedflag, microflag);
            else
                return BTI429_64.BTI429_Sched2BuildEx(ref styleptr, nummsgs, ref minlist, ref maxlist, speedflag, microflag);
        }
        public static Int32 BTI429_Sched2BuildExx(Int32 style, Int32 speedflag, Int32 microflag, Int32 debugvalflag, Int32 tryflag, Int32 nummsgs, ref Int32 minlist, ref Int32 maxlist, ref Int32 entriesptr, ref Int32 maxentriesptr, IntPtr infoptr, ref UInt32 msgaddrptr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_Sched2BuildExx(style, speedflag, microflag, debugvalflag, tryflag, nummsgs, ref minlist, ref maxlist, ref entriesptr, ref maxentriesptr, infoptr, ref msgaddrptr, channum, handleval);
            else
                return BTI429_64.BTI429_Sched2BuildExx(style, speedflag, microflag, debugvalflag, tryflag, nummsgs, ref minlist, ref maxlist, ref entriesptr, ref maxentriesptr, infoptr, ref msgaddrptr, channum, handleval);
        }
        public static UInt32 BTI429_SchedAdvance(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedAdvance(infoptr);
            else
                return BTI429_64.BTI429_SchedAdvance(infoptr);
        }
        public static Int32 BTI429_SchedAgain(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedAgain(index, channum, handleval);
            else
                return BTI429_64.BTI429_SchedAgain(index, channum, handleval);
        }
        public static Int32 BTI429_SchedBranchEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedBranchEx(condition1, condition2, destindex, channum, handleval);
            else
                return BTI429_64.BTI429_SchedBranchEx(condition1, condition2, destindex, channum, handleval);
        }
        public static Int32 BTI429_SchedBuildEx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedBuildEx(nummsgs, ref msgaddr, ref minperiod, ref maxperiod, speed, channum, handleval);
            else
                return BTI429_64.BTI429_SchedBuildEx(nummsgs, ref msgaddr, ref minperiod, ref maxperiod, speed, channum, handleval);
        }
        public static Int32 BTI429_SchedBuildExx(Int32 basevalmsgnum, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedBuildExx(basevalmsgnum, nummsgs, ref msgaddr, ref minperiod, ref maxperiod, speed, buf, bufsize, channum, handleval);
            else
                return BTI429_64.BTI429_SchedBuildExx(basevalmsgnum, nummsgs, ref msgaddr, ref minperiod, ref maxperiod, speed, buf, bufsize, channum, handleval);
        }
        public static Int32 BTI429_SchedBuildExxx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, Int32 channum, Int32 debugval, Int32 microflag, Int32 algorithm, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedBuildExxx(nummsgs, ref msgaddr, ref minperiod, ref maxperiod, speed, channum, debugval, microflag, algorithm, handleval);
            else
                return BTI429_64.BTI429_SchedBuildExxx(nummsgs, ref msgaddr, ref minperiod, ref maxperiod, speed, channum, debugval, microflag, algorithm, handleval);
        }
        public static UInt32 BTI429_SchedCalc(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedCalc(infoptr);
            else
                return BTI429_64.BTI429_SchedCalc(infoptr);
        }
        public static Int32 BTI429_SchedCallEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedCallEx(condition1, condition2, destindex, channum, handleval);
            else
                return BTI429_64.BTI429_SchedCallEx(condition1, condition2, destindex, channum, handleval);
        }
        public static Int32 BTI429_SchedCheck(ref Int32 minperiod, ref Int32 maxperiod, IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedCheck(ref minperiod, ref maxperiod, infoptr);
            else
                return BTI429_64.BTI429_SchedCheck(ref minperiod, ref maxperiod, infoptr);
        }
        public static void BTI429_SchedCheckEnd()
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedCheckEnd();
            else
                BTI429_64.BTI429_SchedCheckEnd();
        }
        public static void BTI429_SchedCheckMiddle(UInt32 msgnum, UInt32 minlen, UInt32 midlen, UInt32 maxlen)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedCheckMiddle(msgnum, minlen, midlen, maxlen);
            else
                BTI429_64.BTI429_SchedCheckMiddle(msgnum, minlen, midlen, maxlen);
        }
        public static void BTI429_SchedCheckReal(UInt32 msgnum, UInt32 minlen, UInt32 midlen, UInt32 maxlen)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedCheckReal(msgnum, minlen, midlen, maxlen);
            else
                BTI429_64.BTI429_SchedCheckReal(msgnum, minlen, midlen, maxlen);
        }
        public static void BTI429_SchedCheckStart()
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedCheckStart();
            else
                BTI429_64.BTI429_SchedCheckStart();
        }
        public static UInt32 BTI429_SchedConflicts(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedConflicts(infoptr);
            else
                return BTI429_64.BTI429_SchedConflicts(infoptr);
        }
        unsafe public static void BTI429_SchedDisplay(UInt32 nummsgs, ref UInt32 count, ref UInt32* data)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedDisplay(nummsgs, ref count, ref data);
            else
                BTI429_64.BTI429_SchedDisplay(nummsgs, ref count, ref data);
        }
        public static Int32 BTI429_SchedDivide(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedDivide(infoptr);
            else
                return BTI429_64.BTI429_SchedDivide(infoptr);
        }
        public static UInt32 BTI429_SchedFix(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedFix(infoptr);
            else
                return BTI429_64.BTI429_SchedFix(infoptr);
        }
        public static void BTI429_SchedFixEnd()
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedFixEnd();
            else
                BTI429_64.BTI429_SchedFixEnd();
        }
        public static void BTI429_SchedFixMiddle(UInt32 conflicts)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedFixMiddle(conflicts);
            else
                BTI429_64.BTI429_SchedFixMiddle(conflicts);
        }
        public static void BTI429_SchedFixStart()
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedFixStart();
            else
                BTI429_64.BTI429_SchedFixStart();
        }
        public static void BTI429_SchedHook(Int32 index, IntPtr ptr)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedHook(index, ptr);
            else
                BTI429_64.BTI429_SchedHook(index, ptr);
        }
        public static Int32 BTI429_SchedInsert(UInt32 eventvals, UInt32 index, UInt32 msgnum, ref UInt32 msgaddr, UInt32 gapval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedInsert(eventvals, index, msgnum, ref msgaddr, gapval, channum, handleval);
            else
                return BTI429_64.BTI429_SchedInsert(eventvals, index, msgnum, ref msgaddr, gapval, channum, handleval);
        }
        public static Int32 BTI429_SchedInsert2(UInt32 eventvals, UInt32 index, Int32 msgnum, ref UInt32 msgaddr, UInt32 gapval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedInsert2(eventvals, index, msgnum, ref msgaddr, gapval, channum, handleval);
            else
                return BTI429_64.BTI429_SchedInsert2(eventvals, index, msgnum, ref msgaddr, gapval, channum, handleval);
        }
        public static Int32 BTI429_SchedInsertEnd(UInt32 eventvals, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedInsertEnd(eventvals, channum, handleval);
            else
                return BTI429_64.BTI429_SchedInsertEnd(eventvals, channum, handleval);
        }
        public static Int32 BTI429_SchedInsertStart(UInt32 eventvals, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedInsertStart(eventvals, channum, handleval);
            else
                return BTI429_64.BTI429_SchedInsertStart(eventvals, channum, handleval);
        }
        public static void BTI429_SchedLayout(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedLayout(infoptr);
            else
                BTI429_64.BTI429_SchedLayout(infoptr);
        }
        public static Int32 BTI429_SchedLogEx(UInt16 condition1, UInt16 condition2, UInt16 tagval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedLogEx(condition1, condition2, tagval, channum, handleval);
            else
                return BTI429_64.BTI429_SchedLogEx(condition1, condition2, tagval, channum, handleval);
        }
        public static UInt32 BTI429_SchedMaxval(ref UInt32 arrayval, UInt32 arrayvalcount)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedMaxval(ref arrayval, arrayvalcount);
            else
                return BTI429_64.BTI429_SchedMaxval(ref arrayval, arrayvalcount);
        }
        public static UInt32 BTI429_SchedMinval(ref UInt32 arrayval, UInt32 arrayvalcount)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedMinval(ref arrayval, arrayvalcount);
            else
                return BTI429_64.BTI429_SchedMinval(ref arrayval, arrayvalcount);
        }
        public static Int32 BTI429_SchedNop(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedNop(channum, handleval);
            else
                return BTI429_64.BTI429_SchedNop(channum, handleval);
        }
        public static Int32 BTI429_SchedParse(Int32 basevalmsgnum, ref UInt32 msgaddr, Int32 channum, IntPtr infoptr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedParse(basevalmsgnum, ref msgaddr, channum, infoptr, handleval);
            else
                return BTI429_64.BTI429_SchedParse(basevalmsgnum, ref msgaddr, channum, infoptr, handleval);
        }
        public static Int32 BTI429_SchedPulse0(Int32 dionum, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedPulse0(dionum, channum, handleval);
            else
                return BTI429_64.BTI429_SchedPulse0(dionum, channum, handleval);
        }
        public static Int32 BTI429_SchedPulse1(Int32 dionum, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedPulse1(dionum, channum, handleval);
            else
                return BTI429_64.BTI429_SchedPulse1(dionum, channum, handleval);
        }
        public static Int32 BTI429_SchedReset(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedReset(infoptr);
            else
                return BTI429_64.BTI429_SchedReset(infoptr);
        }
        public static UInt32 BTI429_SchedRotate(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedRotate(infoptr);
            else
                return BTI429_64.BTI429_SchedRotate(infoptr);
        }
        public static Int32 BTI429_SchedShift(Int32 msgnum, Int32 value, IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedShift(msgnum, value, infoptr);
            else
                return BTI429_64.BTI429_SchedShift(msgnum, value, infoptr);
        }
        public static Int32 BTI429_SchedSlide(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedSlide(infoptr);
            else
                return BTI429_64.BTI429_SchedSlide(infoptr);
        }
        public static void BTI429_SchedSlideEnd()
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedSlideEnd();
            else
                BTI429_64.BTI429_SchedSlideEnd();
        }
        public static void BTI429_SchedSlideMiddle(UInt32 index, UInt32 count, UInt32 conflicts)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedSlideMiddle(index, count, conflicts);
            else
                BTI429_64.BTI429_SchedSlideMiddle(index, count, conflicts);
        }
        public static void BTI429_SchedSlideStart(UInt32 factor)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedSlideStart(factor);
            else
                BTI429_64.BTI429_SchedSlideStart(factor);
        }
        public static void BTI429_SchedSort(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedSort(infoptr);
            else
                BTI429_64.BTI429_SchedSort(infoptr);
        }
        public static UInt32 BTI429_SchedToBit(UInt32 value, IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedToBit(value, infoptr);
            else
                return BTI429_64.BTI429_SchedToBit(value, infoptr);
        }
        public static UInt32 BTI429_SchedToMsec(UInt32 value, IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedToMsec(value, infoptr);
            else
                return BTI429_64.BTI429_SchedToMsec(value, infoptr);
        }
        public static void BTI429_SchedUnsort(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                BTI429_32.BTI429_SchedUnsort(infoptr);
            else
                BTI429_64.BTI429_SchedUnsort(infoptr);
        }
        public static Int32 BTI429_SchedUser(UInt32 useraddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedUser(useraddr, channum, handleval);
            else
                return BTI429_64.BTI429_SchedUser(useraddr, channum, handleval);
        }
        public static UInt32 BTI429_SchedWalk(IntPtr infoptr)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_SchedWalk(infoptr);
            else
                return BTI429_64.BTI429_SchedWalk(infoptr);
        }
        public static Int32 BTI429_TestProtocol(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_TestProtocol(handleval);
            else
                return BTI429_64.BTI429_TestProtocol(handleval);
        }
        public static UInt16 BTI429_Transpose12(UInt16 val)
        {
            if (IntPtr.Size == 4)
                return BTI429_32.BTI429_Transpose12(val);
            else
                return BTI429_64.BTI429_Transpose12(val);
        }

        /**
        *
        *  Channel number constants
        *
        **/

        public const UInt32 CH0 = 0x0000;           //Channel 0
        public const UInt32 CH1 = 0x0001;           //Channel 1
        public const UInt32 CH2 = 0x0002;           //Channel 2
        public const UInt32 CH3 = 0x0003;           //Channel 3
        public const UInt32 CH4 = 0x0004;           //Channel 4
        public const UInt32 CH5 = 0x0005;           //Channel 5
        public const UInt32 CH6 = 0x0006;           //Channel 6
        public const UInt32 CH7 = 0x0007;           //Channel 7
        public const UInt32 CH8 = 0x0008;           //Channel 8
        public const UInt32 CH9 = 0x0009;           //Channel 9
        public const UInt32 CH10 = 0x000A;           //Channel 10
        public const UInt32 CH11 = 0x000B;           //Channel 11
        public const UInt32 CH12 = 0x000C;           //Channel 12
        public const UInt32 CH13 = 0x000D;           //Channel 13
        public const UInt32 CH14 = 0x000E;           //Channel 14
        public const UInt32 CH15 = 0x000F;           //Channel 15
        public const UInt32 CH16 = 0x0010;           //Channel 16
        public const UInt32 CH17 = 0x0011;           //Channel 17
        public const UInt32 CH18 = 0x0012;           //Channel 18
        public const UInt32 CH19 = 0x0013;           //Channel 19
        public const UInt32 CH20 = 0x0014;           //Channel 20
        public const UInt32 CH21 = 0x0015;           //Channel 21
        public const UInt32 CH22 = 0x0016;           //Channel 22
        public const UInt32 CH23 = 0x0017;           //Channel 23
        public const UInt32 CH24 = 0x0018;           //Channel 24
        public const UInt32 CH25 = 0x0019;           //Channel 25
        public const UInt32 CH26 = 0x001A;           //Channel 26
        public const UInt32 CH27 = 0x001B;           //Channel 27
        public const UInt32 CH28 = 0x001C;           //Channel 28
        public const UInt32 CH29 = 0x001D;           //Channel 29
        public const UInt32 CH30 = 0x001E;           //Channel 30
        public const UInt32 CH31 = 0x001F;           //Channel 31

        /**
        *
        *  SDI selection constants
        *
        **/

        public const UInt32 SDI00 = 0x0001;	//Enable SDI00
        public const UInt32 SDI01 = 0x0002;	//Enable SDI01
        public const UInt32 SDI10 = 0x0004;	//Enable SDI10
        public const UInt32 SDI11 = 0x0008;	//Enable SDI11
        public const UInt32 SDIALL = 0x000F;	//Enable all SDIs

        /**
        *
        *  Channel configuration options
        *
        **/

        public const UInt32 CHCFG429_DEFAULT = 0x00000000;	//Select all default settings (XMT & RCV) (default)
        public const UInt32 CHCFG429_HIGHSPEED = 0x00000001;	//Select high speed (XMT & RCV)
        public const UInt32 CHCFG429_AUTOSPEED = 0x00000002;	//Select auto speed detection (RCV)
        public const UInt32 CHCFG429_LOWSPEED = 0x00000000;	//Select low speed (XMT & RCV) (default)
        public const UInt32 CHCFG429_SELFTEST = 0x00000004;	//Enable internal wraparound (XMT & RCV)
        public const UInt32 CHCFG429_SELFTESTOFF = 0x00000000;	//Disable internal wraparound (XMT & RCV) (default)
        public const UInt32 CHCFG429_SYNC = 0x00000008;	//Sync Enable (XMT & RCV)
        public const UInt32 CHCFG429_SYNCOFF = 0x00000000;	//Disable sync output (XMT & RCV) (default)
        public const UInt32 CHCFG429_PARODD = 0x00000000;	//Parity odd (XMT & RCV) (default)
        public const UInt32 CHCFG429_PAREVEN = 0x00000010;	//Parity even (XMT & RCV)
        public const UInt32 CHCFG429_PARDATA = 0x00000020;	//Parity bit as data (XMT & RCV)
        public const UInt32 CHCFG429_ACTIVE = 0x00000000;	//Enable channel activity (XMT & RCV) (default)
        public const UInt32 CHCFG429_INACTIVE = 0x00000040;	//Disable channel activity (XMT & RCV)
        public const UInt32 CHCFG429_EXTTRIG = 0x00000080;	//Enable external trigger for all messages (XMT)
        public const UInt32 CHCFG429_EXTOFF = 0x00000000;	//External trigger is enabled on message level (XMT) (default)
        public const UInt32 CHCFG429_PARERR = 0x00000100;	//Enable parity error for all messages (XMT)
        public const UInt32 CHCFG429_NOERR = 0x00000000;	//Errors are enabled on message level (XMT) (default)
        public const UInt32 CHCFG429_HIT = 0x00000200;	//Hit counter is enabled for all messages
        public const UInt32 CHCFG429_NOHIT = 0x00000000;	//Hit counter is enabled on message level (default)
        public const UInt32 CHCFG429_TIMETAG = 0x00000400;	//Enable time-tag for all message records
        public const UInt32 CHCFG429_TIMETAGOFF = 0x00000000;	//Time-tag is enabled on message level (default)
        public const UInt32 CHCFG429_ELAPSE = 0x00000800;	//Enable elapse time for all messages
        public const UInt32 CHCFG429_ELAPSEOFF = 0x00000000;	//Elapse time is enabled on message level (default)
        public const UInt32 CHCFG429_MAX = 0x00001000;	//Enable max repetition rate monitoring for all messages
        public const UInt32 CHCFG429_MIN = 0x00002000;	//Enable min repetition rate monitoring for all messages
        public const UInt32 CHCFG429_MAXMIN = 0x00003000;	//Enable max and min repetition rate monitoring for all messages
        public const UInt32 CHCFG429_MAXMINOFF = 0x00000000;	//Repetition rate monitoring is enabled on message level (default)
        public const UInt32 CHCFG429_SEQALL = 0x00080000;	//Record entire channel in sequential record
        public const UInt32 CHCFG429_SEQSEL = 0x00000000;	//Sequential record recording is enabled at message level (default)
        public const UInt32 CHCFG429_LOOPMAX = 0x00100000;	//Enable schedule maximum loop count
        public const UInt32 CHCFG429_NOLOOPMAX = 0x00000000;	//Disable schedule maximum loop count (default)
        public const UInt32 CHCFG429_LOGHALT = 0x00200000;	//Enable event log on schedule halt
        public const UInt32 CHCFG429_NOLOGHALT = 0x00000000;	//No event log on schedule halt (default)
        public const UInt32 CHCFG429_LOGPAUSE = 0x00400000;	//Enable event log on schedule pause
        public const UInt32 CHCFG429_NOLOGPAUSE = 0x00000000;	//No event log on schedule pause (default)
        public const UInt32 CHCFG429_LOGERR = 0x00800000;	//Enable event log on decoder errors.
        public const UInt32 CHCFG429_NOLOGERR = 0x00000000;	//No event log on decoder errors (default)
        public const UInt32 CHCFG429_PAUSE = 0x01000000;	//Mark channel as paused
        public const UInt32 CHCFG429_UNPAUSE = 0x00000000;	//Mark channel as unpaused (default)

        /**
        *
        *  Message configuration options
        *
        **/

        public const UInt32 MSGCRT429_DEFAULT = 0x00000000;	//Default settings
        public const UInt32 MSGCRT429_NOSEQ = 0x00000000;	//Message will not be recorded in sequential record (default)
        public const UInt32 MSGCRT429_SEQ = 0x00000001;	//Message will be recorded in sequential record
        public const UInt32 MSGCRT429_NOLOG = 0x00000000;	//Message will not generate event log (default)
        public const UInt32 MSGCRT429_LOG = 0x00000002;	//Message will generate event log
        public const UInt32 MSGCRT429_NOSKIP = 0x00000000;	//Message will not be skipped (default)
        public const UInt32 MSGCRT429_SKIP = 0x00000008;	//Message will be skipped
        public const UInt32 MSGCRT429_NOTIMETAG = 0x00000000;	//Message will not record time-tag (default)
        public const UInt32 MSGCRT429_TIMETAG = 0x00000010;	//Message will record time-tag
        public const UInt32 MSGCRT429_NOELAPSE = 0x00000000;	//Message will not record elapse time (default)
        public const UInt32 MSGCRT429_ELAPSE = 0x00000020;	//Message will record elapse time
        public const UInt32 MSGCRT429_NOMAXMIN = 0x00000000;	//Message will not record min/max time (default)
        public const UInt32 MSGCRT429_MAX = 0x00000040;	//Message will record max time
        public const UInt32 MSGCRT429_MIN = 0x00000080;	//Message will record min time
        public const UInt32 MSGCRT429_MAXMIN = 0x000000C0;	//Message will record min/max time
        public const UInt32 MSGCRT429_NOSYNC = 0x00000000;	//No sync will be generated for message (default)
        public const UInt32 MSGCRT429_SYNC = 0x00000100;	//Sync will be generated for message
        public const UInt32 MSGCRT429_NOERR = 0x00000000;	//No error will be generated for message (default)
        public const UInt32 MSGCRT429_PARERR = 0x00000200;	//Parity error will be generated for message
        public const UInt32 MSGCRT429_NOHIT = 0x00000000;	//Message will not record hit count (default)
        public const UInt32 MSGCRT429_HIT = 0x00000400;	//Message will record hit count
        public const UInt32 MSGCRT429_NOEXTRIG = 0x00000000;	//Message will not be externally triggered (default)
        public const UInt32 MSGCRT429_EXTRIG = 0x00001000;	//Message will be externally triggered
        public const UInt32 MSGCRT429_WIPE = 0x00000000;	//Enables message clear (default)
        public const UInt32 MSGCRT429_NOWIPE = 0x80000000;	//Disables message clear
        public const UInt32 MSGCRT429_WIPE0 = 0x00000000;	//Initialize data with zeros (default)
        public const UInt32 MSGCRT429_WIPE1 = 0x40000000;	//Initialize data with ones

        /**
        *
        *  List buffer options
        *
        **/

        public const UInt32 LISTCRT429_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 LISTCRT429_FIFO = 0x00000000;	//Enable FIFO mode (default)
        public const UInt32 LISTCRT429_PINGPONG = 0x00000001;	//Enable ping-pong mode
        public const UInt32 LISTCRT429_CIRCULAR = 0x00000002;	//Enable circular mode
        public const UInt32 LISTCRT429_RCV = 0x00000010;	//User will read from list buffer
        public const UInt32 LISTCRT429_XMT = 0x00000020;	//User will write to list buffer
        public const UInt32 LISTCRT429_ASYNC = 0x00000040;	//Asynchronous mode
        public const UInt32 LISTCRT429_NOLOG = 0x00000000;	//Do not generate event log when list buffer empty/full (default)
        public const UInt32 LISTCRT429_LOG = 0x00000100;	//Generate event log when list buffer empty/full

        /**
        *
        *  Parametric configuration options
        *
        **/

        public const UInt32 PARAMCFG429_DEFAULT = 0x00000000;	//Select all default settings (default)
        public const UInt32 PARAMCFG429_AMPLON = 0x00000000;	//Enables parametric amplitude control (default)
        public const UInt32 PARAMCFG429_AMPLOFF = 0x00000001;	//Disables parametric amplitude control
        public const UInt32 PARAMCFG429_BITRATEON = 0x00000000;	//Enables parametric bit rate control (default)
        public const UInt32 PARAMCFG429_BITRATEOFF = 0x00000002;	//Disables parametric bit rate control

        /**
        *
        *  Scheduling conditions.
        *
        **/

        public const UInt32 COND429_ALWAYS = 0x00000000;	//Unconditional
        public const UInt32 COND429_DIO1ACT = 0x00000001;	//Condition on digital I/O #1 active
        public const UInt32 COND429_DIO1NACT = 0x00000002;	//Condition on digital I/O #1 not active
        public const UInt32 COND429_DIO2ACT = 0x00000004;	//Condition on digital I/O #2 active
        public const UInt32 COND429_DIO2NACT = 0x00000008;	//Condition on digital I/O #2 not active
        public const UInt32 COND429_DIO3ACT = 0x00000010;	//Condition on digital I/O #3 active
        public const UInt32 COND429_DIO3NACT = 0x00000020;	//Condition on digital I/O #3 not active
        public const UInt32 COND429_DIO4ACT = 0x00000040;	//Condition on digital I/O #4 active
        public const UInt32 COND429_DIO4NACT = 0x00000080;	//Condition on digital I/O #4 not active
        public const UInt32 COND429_DIO5ACT = 0x00000100;	//Condition on digital I/O #5 active
        public const UInt32 COND429_DIO5NACT = 0x00000200;	//Condition on digital I/O #5 not active
        public const UInt32 COND429_DIO6ACT = 0x00000400;	//Condition on digital I/O #6 active
        public const UInt32 COND429_DIO6NACT = 0x00000800;	//Condition on digital I/O #6 not active
        public const UInt32 COND429_DIO7ACT = 0x00001000;	//Condition on digital I/O #7 active
        public const UInt32 COND429_DIO7NACT = 0x00002000;	//Condition on digital I/O #7 not active
        public const UInt32 COND429_DIO8ACT = 0x00004000;	//Condition on digital I/O #8 active
        public const UInt32 COND429_DIO8NACT = 0x00008000;	//Condition on digital I/O #8 not active

        /**
        *
        *  Bit fields of the message activity flag.
        *
        **/

        public const UInt32 MSGACT429_CHMASK = 0xFF00;	//Channel number mask value
        public const UInt32 MSGACT429_CHSHIFT = 0x0008;	//Channel number shift value
        public const UInt32 MSGACT429_SPD = 0x0080;	//Bus speed
        public const UInt32 MSGACT429_ERR = 0x0040;	//Error bit
        public const UInt32 MSGACT429_GAP = 0x0020;	//Gap error bit
        public const UInt32 MSGACT429_PAR = 0x0010;	//Parity error bit
        public const UInt32 MSGACT429_LONG = 0x0008;	//Long word error bit
        public const UInt32 MSGACT429_BIT = 0x0004;	//Bit time error bit
        public const UInt32 MSGACT429_TO = 0x0002;	//Time out error bit
        public const UInt32 MSGACT429_HIT = 0x0001;	//Always set

        /**
        *
        *  Channel info fields.
        *
        **/

        public const UInt32 INFO429_PARAM = 0x0001;	//Channel supports parametric control

        /**
        *
        *  Scheduling algorithm options
        *
        **/

        public const UInt32 SCHEDMODE_DEFAULT = 0x0000;	//Select all default settings
        public const UInt32 SCHEDMODE_METHOD_NORMAL = 0x0000;	//Choose the normal scheduling method
        public const UInt32 SCHEDMODE_METHOD_QUICK = 0x0001;	//Choose the quick scheduling method
        public const UInt32 SCHEDMODE_METHOD_BOTH = 0x0002;	//Use the quick method first if fail then use the normal method
        public const UInt32 SCHEDMODE_METHOD_MASK = 0x000F;	//Mask for method setting
        public const UInt32 SCHEDMODE_MILLISEC = 0x0000;	//Specify periods in milliseconds
        public const UInt32 SCHEDMODE_MICROSEC = 0x0010;	//Specify periods in microseconds
        public const UInt32 SCHEDMODE_REMOTE = 0x0000;	//Perform calculations remotely if applicable
        public const UInt32 SCHEDMODE_LOCAL = 0x0020;	//Perform calculations locally if applicable
        public const UInt32 SCHEDMODE_DEFAULT_ALGOR = 0x0000;	//Choose the default algorithm
        public const UInt32 SCHEDMODE_QUICK_ALGOR = 0x0001;	//Choose the quick algorithm
        public const UInt32 SCHEDMODE_BOTH_ALGOR = 0x0002;	//Use the quick algorithm first if fail then use the normal algorithm
        public const UInt32 SCHEDMODE_ALGOR_MASK = 0x000F;	//Mask for algorithm setting

    }	//end class
}	//end namespace
