using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class BTI1553
    {
        /**
        *
        *  BTI1553 WIN32 DRIVER  Version 1.11.0  (06/06/2011)
        *  Copyright (c) 2001-2011
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   BTI1553NET.CS -- 32-bit
        *                       BTI1553 Driver Include Header File.
        *
        **/

        /**
        *
        *  Structs used by the BTI1553 Driver.
        *
        **/

        [StructLayout(LayoutKind.Sequential)]
        public struct XMITFIELDS1553
        {
            public UInt32 ctrlflags;           //User writes message configuration optionvals
            public UInt16 flag1;               //Card writes message flag 1
            public UInt16 flag2;               //Card writes message flag 2
            public UInt16 errflags;            //Card writes errorval flags
            public UInt16 actflags;            //Card writes activity flags
            public UInt16 resptime1;           //Card writes response time 1
            public UInt16 resptime2;           //Card writes response time 2
            public UInt16 datacount;           //Card writes data count
            public UInt16 extflag;             //Driver writes external flags
            public UInt32 timetag;             //Card writes time tag
            public UInt32 elapsetime;          //Card writes elapsed time
            public UInt32 preaddr;             //Driver writes pre-proc address
            public UInt32 postaddr;            //Driver writes post-proc address
            public UInt32 timetagh;            //Card writes extended timetag
            public UInt16 resv18;              //Reserved field
            public UInt16 resv19;              //Reserved field
            public UInt16 cwd1;                //User writes command word 1
            public UInt16 cwd2;                //User writes command word 2
            public UInt16 swd1;                //Card writes status word 1
            public UInt16 swd2;                //Card writes status word 2
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public UInt16[] data;	//User writes data words
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public UInt16[] extra;	//User writes extra words
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSGFIELDS1553
        {
            public UInt16 msgflag;             //Driver writes message flags
            public UInt16 msgopt;              //Driver writes message optionvals
            public UInt16 msgerr;              //Card writes message errorvals
            public UInt16 msgact;              //Card writes message activity
            public UInt16 resptime1;           //Card writes response time 1
            public UInt16 resptime2;           //Card writes response time 2
            public UInt16 datacount;           //Card writes data count
            public UInt16 extflag;             //Driver writes external flags
            public UInt32 timetag_hitcount; //Card writes time tag - //Card writes hit count
            public UInt32 elapsetime_mintime_maxtime; //Card writes elapsed time - //Card writes min time - //Card writes max time
            public UInt32 preaddr;             //Driver writes pre-proc address
            public UInt32 postaddr;            //Driver writes post-proc address
            public UInt32 timetagh;            //Card writes extended timetag
            public UInt16 resv18;              //Reserved field
            public UInt16 resv19;              //Reserved field
            public UInt16 cwd1;                //Card/User writes command word 1 (R/T)
            public UInt16 cwd2;                //Card/User writes command word 2 (R/T)
            public UInt16 swd1;                //Card writes status word 1
            public UInt16 swd2;                //Card writes status word 2
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public UInt16[] data;	//User/Card writes data words (R/T)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public UInt16[] extra;	//User/Card writes extra words (R/T)
        }

        /**
        *
        *  BTI1553 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the BTI1553 Driver.
        *
        **/

        private static class BTI1553_32
        {
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCConfig(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCConfigMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCConfigMsg(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCCreateList@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCCreateList(UInt32 listconfigval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCCreateMsg@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCCreateMsg(UInt32 configval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_BCPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCPauseCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCPauseCheck(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCResume@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_BCResume(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedAgain@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedAgain(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedBranch@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedBranch(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedBranchUpdate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedBranchUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedBuild@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedBuild(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedCall@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedCall(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedCallUpdate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedCallUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedEntry@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedEntry(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedFrame@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedFrame(UInt32 timeval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedFrameEnd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedFrameEnd(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedFrameStart@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedFrameStart(UInt32 timeval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedGap@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedGap(UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedHalt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedHalt(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedLog@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedLog(UInt32 condition, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedMsg(UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedPulse@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedPulse(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedPulse0@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedPulse0(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedPulse1@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedPulse1(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedRestart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedRetry@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedRetry(UInt32 condition, UInt16 retries, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedReturn@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedReturn(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSetDefaultGap@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSetDefaultGap(Int32 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSetTimeout@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSetTimeout(UInt16 timeoutval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSyncDefine@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCTransmitMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTransmitMsg(ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCTriggerDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChGetCount@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ChGetCount(ref Int32 a_count, ref Int32 b4_count, ref Int32 b32_count, ref Int32 c_count, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChGetInfo@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIs1553@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIs1553(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsA@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsA(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsB32@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsB32(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsB4@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsB4(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsBM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsBM(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsC@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsC(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsD@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsD(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsM(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsRM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsRM(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsS@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsS(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsX@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsX(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChStart(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChStop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChStop(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdMaxLoopRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_CmdMaxLoopRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdMaxLoopWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdMaxLoopWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdShotRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdShotRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdShotWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdShotWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdSkipRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdSkipRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdSkipWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdSkipWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdStepRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdStepRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdStepWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdStepWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorCtrl@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorCtrl(UInt32 ctrlval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorDefine@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorDefine(UInt32 defineval, UInt16 errvalue, Int32 countval, UInt16 wordpos, UInt16 bitpos, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorSent@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorSent(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorTagBC@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorTagBC(Int32 tagval, UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorTagRT@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorTagRT(Int32 tagval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorTriggerDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListBlockRd(ref UInt16 buf, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListBlockWr(ref UInt16 buf, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListDataRd(ref UInt16 buf, Int32 count, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListDataWr(ref UInt16 buf, Int32 count, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListMultiBlockRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListMultiBlockRd(ref UInt16 buf, ref Int32 blkcountptr, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListMultiBlockWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListMultiBlockWr(ref UInt16 buf, Int32 blkcount, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MonConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MonConfig(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MonFilterSA@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MonFilterSA(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MonFilterTA@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MonFilterTA(UInt32 tamask, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgBlockRd(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgBlockWr(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgDataRd(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgDataWr(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgFieldRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgFieldRd(UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgFieldWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgFieldWr(UInt32 fieldval, UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgGroupRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgGroupRd(Int32 nummsgs, ref MSGFIELDS1553 msgflds, ref UInt32 msgaddrptr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgGroupWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgGroupWr(Int32 nummsgs, ref MSGFIELDS1553 msgflds, ref UInt32 msgaddrptr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgSkipRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MsgSkipRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgSkipWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgSkipWr(Int32 skip, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgSyncDefine@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MsgSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgTriggerDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MsgTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ParamAmplitudeConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ParamAmplitudeGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_PlayConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_PlayConfig(UInt32 configval, UInt32 tamask, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_PlayStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_PlayStatus(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_PlayWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_PlayWr(ref UInt16 buf, UInt16 bufcount, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTConfig(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTCreateList@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_RTCreateList(UInt32 listconfigval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTCreateMsg@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_RTCreateMsg(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTGetMsg@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_RTGetMsg(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTReset@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTReset(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTResponseTimeSet@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTResponseTimeSet(Int32 resptime, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTSetMode@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTSetMode(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTSWDRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_RTSWDRd(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTSWDWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTSWDWr(UInt16 swdval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTSyncDefine@40", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ValPackCWD@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_ValPackCWD(Int32 taval, Int32 trflag, Int32 saval, Int32 wcval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ValUnpackCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ValUnpackCWD(UInt16 cwdval, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 wcval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCCreateListEx@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCCreateListEx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCCreateListExx@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCCreateListExx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCGetMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCGetMsg(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCIMGapRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCIMGapRd(ref UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCIMGapWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCIMGapWr(UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedBranchEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedBranchEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 opcode, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedCallEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedCallEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 opcode, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedLogEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedLogEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 opcode, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedNop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedNop(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedRetryEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedRetryEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 retryflag, UInt16 retries, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSchedUser@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedUser(UInt32 useraddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCSetEntry@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSetEntry(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCTransmitMsgBlkEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTransmitMsgBlkEx(Int32 writeflag, Int32 count, ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCTransmitMsgBlkInit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTransmitMsgBlkInit(Int32 maxcount, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCTransmitMsgBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTransmitMsgBlkRd(Int32 count, ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BCTransmitMsgBlkWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTransmitMsgBlkWr(Int32 count, ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_BlkAddr(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkOptRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_BlkOptRd(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkOptWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkOptWr(UInt16 rtopt, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkPtrRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BlkPtrRd(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkPtrWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_BlkPtrWr(UInt32 descaddr, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkRd(ref UInt16 block, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkReset@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkReset(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkSWDRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_BlkSWDRd(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkSWDWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkSWDWr(UInt16 swdval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkWipe@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkWipe(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_BlkWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkWr(ref UInt16 block, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChConfig@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChConfig(Int32 enableflag, Int32 typeval, UInt16 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ChIsRunning@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsRunning(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_CmdAddr(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_CmdAlloc(Int32 count, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdBaseRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_CmdBaseRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdBaseWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdBaseWr(UInt32 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdCountRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_CmdCountRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdCountWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdCountWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdCtrlRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_CmdCtrlRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdCtrlWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdCtrlWr(UInt16 ctrlval, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdCurrRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_CmdCurrRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdCurrWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdCurrWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdInit(UInt16 opcode, ref UInt16 block);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdInsert@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdInsert(ref UInt16 block, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdRestart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdStackClr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdStackClr(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdStartRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_CmdStartRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdStartWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdStartWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdTotalRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdTotalRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdTotalWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdTotalWr(Int32 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_CmdWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DescAddr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescAddr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DescAlloc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescAlloc(UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DescConfig@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_DescConfig(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DescConfigAll@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_DescConfigAll(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DescOptRd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_DescOptRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DescOptWr@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_DescOptWr(UInt16 descopt, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DescPtrRd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescPtrRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DescPtrWr@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescPtrWr(UInt32 msgaddr, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DescRd@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DescWr@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescWr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_DllUsageCount();
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorIsTaggedBC@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorIsTaggedBC(UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorIsTaggedRT@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorIsTaggedRT(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorResponse@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorResponse(UInt16 responseval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorSync@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ErrorSync(Int32 value, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ErrorTimeout@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorTimeout(UInt16 timeoutval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_HostComm@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_HostComm(IntPtr lpparam, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_IsChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_IsChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListAddrEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListBlockRdEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListBlockRdEx(ref UInt16 buf, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListBlockWrEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListBlockWrEx(ref UInt16 buf, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListClear(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListConfig(UInt32 configval, Int32 count, UInt16 skipval, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListConfigEx(UInt32 configval, Int32 count, UInt16 skipval, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListDataRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListDataRdEx(ref UInt16 buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListDataWrEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListDataWrEx(ref UInt16 buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListInit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListNextRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListNextRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListNextWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListNextWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListPostRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListPostWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListPreRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListPreWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ListStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListStatus(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ModeIsBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsBC(UInt16 chanflag);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ModeIsMon@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsMon(UInt16 chanflag);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ModeIsNotBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsNotBC(UInt16 chanflag);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ModeIsNotMon@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsNotMon(UInt16 chanflag);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ModeIsNotPlay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsNotPlay(UInt16 chanflag);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ModeIsNotRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsNotRT(UInt16 chanflag);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ModeIsNotSerial@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsNotSerial(UInt16 chanflag);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ModeIsPlay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsPlay(UInt16 chanflag);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ModeIsRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsRT(UInt16 chanflag);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ModeIsSerial@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsSerial(UInt16 chanflag);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MonConfigEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MonConfigEx(UInt32 configval, UInt32 moncount, UInt16 cardnum, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MonFilterSAEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MonFilterSAEx(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgCheck(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgCommRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgCommRd(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgCommWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgCommWr(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgConfig(UInt32 configval, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgConfigEx(UInt32 configval, UInt16 cwd, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgCWD1Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgCWD1Rd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgCWD1Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgCWD1Wr(UInt16 cwd1, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgCWD2Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgCWD2Rd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgCWD2Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgCWD2Wr(UInt16 cwd2, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgErrorRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgErrorRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgErrorWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgErrorWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgFlagRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgFlagRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgFlagWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgFlagWr(UInt16 msgflag, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgIsAccessed@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgReset(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgResetEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgResetEx(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgSWD1Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgSWD1Rd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_MsgSWD2Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgSWD2Rd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_PlayClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_PlayClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_PlayConfigEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_PlayConfigEx(UInt32 configval, UInt32 playcount, UInt32 tamask, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_PlayCounterWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_PlayCounterWr(UInt32 totalcount, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_PlayStatusEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_PlayStatusEx(ref UInt32 totalcount, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_PlayWrEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_PlayWrEx(ref UInt16 buf, UInt16 bufcount, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTConfigEx(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTConfigExx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTConfigExx(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTCreateListEx@40", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_RTCreateListEx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTCreateListExx@40", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_RTCreateListExx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTResponseTimeRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTResponseTimeRd(ref UInt16 timeval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTResponseTimeWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTResponseTimeWr(UInt16 timeval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_RTStatus@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_RTStatus(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SABlkWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SABlkWr(Int32 taval, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SABlkWrEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SABlkWrEx(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedBuild@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedBuild(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 freq, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedBuildEx@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedBuildEx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 freq, ref Int32 period, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedBuildExx@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedBuildExx(UInt32 frametime, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 period, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedCalc@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedCalc(ref UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedDisplay@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_SchedDisplay(UInt32 nummsgs, ref UInt32 count);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedHook@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_SchedHook(Int32 index, IntPtr ptr);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedInsEnd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedInsEnd(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedInsMsg@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedInsMsg(UInt32 index, ref UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedInsStart@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedInsStart(UInt32 frametime, UInt32 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedMaxval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_SchedMaxval(ref UInt32 arrayval, UInt32 arrayvalcount);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SchedMinval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_SchedMinval(ref UInt32 arrayval, UInt32 arrayvalcount);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SerialClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SerialClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SerialConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SerialConfig(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SerialConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SerialConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SerialStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SerialStatus(Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_SerialWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_SerialWr(ref UInt16 buf, Int32 channum, UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_TestProtocol@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_TestProtocol(UInt32 handleval);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ValPackRTCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_ValPackRTCWD(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 count);
            [DllImport("BTI1553.DLL", EntryPoint = "_BTI1553_ValUnpackRTCWD@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ValUnpackRTCWD(UInt16 cwd, ref Int32 bcastflag, ref Int32 mcflag, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 count);
        }

        private static class BTI1553_64
        {
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCConfig(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCConfigMsg", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCConfigMsg(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCCreateList", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCCreateList(UInt32 listconfigval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCCreateMsg", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCCreateMsg(UInt32 configval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCPause", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_BCPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCPauseCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCPauseCheck(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCResume", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_BCResume(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedAgain", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedAgain(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedBranch", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedBranch(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedBranchUpdate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedBranchUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedBuild", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedBuild(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedCall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedCall(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedCallUpdate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedCallUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedEntry", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedEntry(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedFrame", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedFrame(UInt32 timeval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedFrameEnd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedFrameEnd(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedFrameStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedFrameStart(UInt32 timeval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedGap", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedGap(UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedHalt", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedHalt(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedLog", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedLog(UInt32 condition, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedMsg", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedMsg(UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedPause", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedPulse", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedPulse(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedPulse0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedPulse0(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedPulse1", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedPulse1(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedRestart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedRetry", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedRetry(UInt32 condition, UInt16 retries, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedReturn", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedReturn(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSetDefaultGap", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSetDefaultGap(Int32 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSetTimeout", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSetTimeout(UInt16 timeoutval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSyncDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCTransmitMsg", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTransmitMsg(ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCTriggerDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChGetCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ChGetCount(ref Int32 a_count, ref Int32 b4_count, ref Int32 b32_count, ref Int32 c_count, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChGetInfo", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIs1553", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIs1553(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsA(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsB32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsB32(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsB4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsB4(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsBM", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsBM(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsC", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsC(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsD", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsD(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsM", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsM(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsRM", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsRM(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsS", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsS(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsX", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsX(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChStart(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChStop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChStop(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdMaxLoopRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_CmdMaxLoopRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdMaxLoopWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdMaxLoopWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdShotRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdShotRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdShotWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdShotWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdSkipRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdSkipRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdSkipWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdSkipWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdStepRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdStepRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdStepWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdStepWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorCtrl", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorCtrl(UInt32 ctrlval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorDefine(UInt32 defineval, UInt16 errvalue, Int32 countval, UInt16 wordpos, UInt16 bitpos, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorSent", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorSent(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorTagBC", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorTagBC(Int32 tagval, UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorTagRT", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorTagRT(Int32 tagval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorTriggerDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListBlockRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListBlockRd(ref UInt16 buf, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListBlockWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListBlockWr(ref UInt16 buf, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListDataRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListDataRd(ref UInt16 buf, Int32 count, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListDataWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListDataWr(ref UInt16 buf, Int32 count, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListMultiBlockRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListMultiBlockRd(ref UInt16 buf, ref Int32 blkcountptr, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListMultiBlockWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListMultiBlockWr(ref UInt16 buf, Int32 blkcount, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MonConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MonConfig(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MonFilterSA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MonFilterSA(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MonFilterTA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MonFilterTA(UInt32 tamask, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgBlockRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgBlockRd(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgBlockWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgBlockWr(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgDataRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgDataRd(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgDataWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgDataWr(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgFieldRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgFieldRd(UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgFieldWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgFieldWr(UInt32 fieldval, UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgGroupRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgGroupRd(Int32 nummsgs, ref MSGFIELDS1553 msgflds, ref UInt32 msgaddrptr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgGroupWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgGroupWr(Int32 nummsgs, ref MSGFIELDS1553 msgflds, ref UInt32 msgaddrptr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgSkipRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MsgSkipRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgSkipWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgSkipWr(Int32 skip, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgSyncDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MsgSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgTriggerDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MsgTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ParamAmplitudeConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ParamAmplitudeGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_PlayConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_PlayConfig(UInt32 configval, UInt32 tamask, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_PlayStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_PlayStatus(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_PlayWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_PlayWr(ref UInt16 buf, UInt16 bufcount, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTConfig(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTCreateList", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_RTCreateList(UInt32 listconfigval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTCreateMsg", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_RTCreateMsg(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTGetMsg", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_RTGetMsg(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTReset(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTResponseTimeSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTResponseTimeSet(Int32 resptime, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTSetMode", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTSetMode(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTSWDRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_RTSWDRd(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTSWDWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTSWDWr(UInt16 swdval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTSyncDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ValPackCWD", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_ValPackCWD(Int32 taval, Int32 trflag, Int32 saval, Int32 wcval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ValUnpackCWD", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ValUnpackCWD(UInt16 cwdval, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 wcval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCCreateListEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCCreateListEx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCCreateListExx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCCreateListExx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCGetMsg", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BCGetMsg(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCIMGapRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCIMGapRd(ref UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCIMGapWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCIMGapWr(UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedBranchEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedBranchEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 opcode, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedCallEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedCallEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 opcode, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedLogEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedLogEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 opcode, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedNop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedNop(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedRetryEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedRetryEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 retryflag, UInt16 retries, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSchedUser", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSchedUser(UInt32 useraddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCSetEntry", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCSetEntry(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCTransmitMsgBlkEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTransmitMsgBlkEx(Int32 writeflag, Int32 count, ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCTransmitMsgBlkInit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTransmitMsgBlkInit(Int32 maxcount, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCTransmitMsgBlkRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTransmitMsgBlkRd(Int32 count, ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BCTransmitMsgBlkWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BCTransmitMsgBlkWr(Int32 count, ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_BlkAddr(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkOptRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_BlkOptRd(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkOptWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkOptWr(UInt16 rtopt, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkPtrRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_BlkPtrRd(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkPtrWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_BlkPtrWr(UInt32 descaddr, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkRd(ref UInt16 block, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkReset(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkSWDRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_BlkSWDRd(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkSWDWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkSWDWr(UInt16 swdval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkWipe", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkWipe(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_BlkWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_BlkWr(ref UInt16 block, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChConfig(Int32 enableflag, Int32 typeval, UInt16 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ChIsRunning", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ChIsRunning(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_CmdAddr(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdAlloc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_CmdAlloc(Int32 count, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdAllocEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdBaseRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_CmdBaseRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdBaseWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdBaseWr(UInt32 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdCountRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_CmdCountRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdCountWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdCountWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdCtrlRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_CmdCtrlRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdCtrlWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdCtrlWr(UInt16 ctrlval, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdCurrRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_CmdCurrRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdCurrWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdCurrWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdInit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdInit(UInt16 opcode, ref UInt16 block);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdInsert", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdInsert(ref UInt16 block, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdRestart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdStackClr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdStackClr(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdStartRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_CmdStartRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdStartWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdStartWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdTotalRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdTotalRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdTotalWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_CmdTotalWr(Int32 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_CmdWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DescAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescAddr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DescAlloc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescAlloc(UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DescConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_DescConfig(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DescConfigAll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_DescConfigAll(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DescOptRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_DescOptRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DescOptWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_DescOptWr(UInt16 descopt, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DescPtrRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescPtrRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DescPtrWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescPtrWr(UInt32 msgaddr, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DescRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DescWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_DescWr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_DllUsageCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_DllUsageCount();
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorIsTaggedBC", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorIsTaggedBC(UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorIsTaggedRT", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorIsTaggedRT(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorResponse", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorResponse(UInt16 responseval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorSync", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ErrorSync(Int32 value, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ErrorTimeout", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ErrorTimeout(UInt16 timeoutval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_HostComm", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_HostComm(IntPtr lpparam, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_IsChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_IsChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListAddrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListBlockRdEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListBlockRdEx(ref UInt16 buf, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListBlockWrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListBlockWrEx(ref UInt16 buf, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListClear(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListConfig(UInt32 configval, Int32 count, UInt16 skipval, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListConfigEx(UInt32 configval, Int32 count, UInt16 skipval, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListDataRdEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListDataRdEx(ref UInt16 buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListDataWrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListDataWrEx(ref UInt16 buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListInit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListNextRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListNextRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListNextWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_ListNextWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListPostRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListPostWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListPreRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListPreWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ListStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ListStatus(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ModeIsBC", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsBC(UInt16 chanflag);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ModeIsMon", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsMon(UInt16 chanflag);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ModeIsNotBC", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsNotBC(UInt16 chanflag);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ModeIsNotMon", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsNotMon(UInt16 chanflag);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ModeIsNotPlay", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsNotPlay(UInt16 chanflag);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ModeIsNotRT", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsNotRT(UInt16 chanflag);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ModeIsNotSerial", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsNotSerial(UInt16 chanflag);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ModeIsPlay", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsPlay(UInt16 chanflag);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ModeIsRT", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsRT(UInt16 chanflag);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ModeIsSerial", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_ModeIsSerial(UInt16 chanflag);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MonConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MonConfigEx(UInt32 configval, UInt32 moncount, UInt16 cardnum, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MonFilterSAEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MonFilterSAEx(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgCheck(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgCommRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgCommRd(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgCommWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgCommWr(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgConfig(UInt32 configval, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgConfigEx(UInt32 configval, UInt16 cwd, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgCWD1Rd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgCWD1Rd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgCWD1Wr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgCWD1Wr(UInt16 cwd1, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgCWD2Rd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgCWD2Rd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgCWD2Wr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgCWD2Wr(UInt16 cwd2, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgErrorRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgErrorRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgErrorWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgErrorWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgFlagRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgFlagRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgFlagWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgFlagWr(UInt16 msgflag, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgIsAccessed", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgOptRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgOptWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgReset(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgResetEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_MsgResetEx(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgSWD1Rd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgSWD1Rd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_MsgSWD2Rd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_MsgSWD2Rd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_PlayClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_PlayClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_PlayConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_PlayConfigEx(UInt32 configval, UInt32 playcount, UInt32 tamask, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_PlayCounterWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_PlayCounterWr(UInt32 totalcount, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_PlayStatusEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_PlayStatusEx(ref UInt32 totalcount, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_PlayWrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_PlayWrEx(ref UInt16 buf, UInt16 bufcount, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTConfigEx(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTConfigExx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTConfigExx(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTCreateListEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_RTCreateListEx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTCreateListExx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_RTCreateListExx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTResponseTimeRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTResponseTimeRd(ref UInt16 timeval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTResponseTimeWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_RTResponseTimeWr(UInt16 timeval, Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_RTStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_RTStatus(Int32 taval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SABlkWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SABlkWr(Int32 taval, Int32 saval, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SABlkWrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SABlkWrEx(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedBuild", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedBuild(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 freq, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedBuildEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedBuildEx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 freq, ref Int32 period, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedBuildExx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedBuildExx(UInt32 frametime, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 period, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedCalc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedCalc(ref UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedDisplay", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_SchedDisplay(UInt32 nummsgs, ref UInt32 count);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedHook", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_SchedHook(Int32 index, IntPtr ptr);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedInsEnd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedInsEnd(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedInsMsg", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedInsMsg(UInt32 index, ref UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedInsStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SchedInsStart(UInt32 frametime, UInt32 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedMaxval", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_SchedMaxval(ref UInt32 arrayval, UInt32 arrayvalcount);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SchedMinval", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_SchedMinval(ref UInt32 arrayval, UInt32 arrayvalcount);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SerialClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SerialClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SerialConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SerialConfig(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SerialConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SerialConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SerialStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_SerialStatus(Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_SerialWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI1553_SerialWr(ref UInt16 buf, Int32 channum, UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_TestProtocol", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI1553_TestProtocol(UInt32 handleval);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ValPackRTCWD", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI1553_ValPackRTCWD(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 count);
            [DllImport("BTI155364.DLL", EntryPoint = "BTI1553_ValUnpackRTCWD", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI1553_ValUnpackRTCWD(UInt16 cwd, ref Int32 bcastflag, ref Int32 mcflag, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 count);
        }

        public static Int32 BTI1553_BCConfig(UInt32 configval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCConfig(configval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCConfig(configval, channum, handleval);
        }
        public static Int32 BTI1553_BCConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCConfigEx(configval, count, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCConfigEx(configval, count, channum, handleval);
        }
        public static UInt32 BTI1553_BCConfigMsg(UInt32 configval, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCConfigMsg(configval, msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_BCConfigMsg(configval, msgaddr, handleval);
        }
        public static UInt32 BTI1553_BCCreateList(UInt32 listconfigval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCCreateList(listconfigval, count, msgconfigval, cwd1, cwd2, ref data, handleval);
            else
                return BTI1553_64.BTI1553_BCCreateList(listconfigval, count, msgconfigval, cwd1, cwd2, ref data, handleval);
        }
        public static UInt32 BTI1553_BCCreateMsg(UInt32 configval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCCreateMsg(configval, cwd1, cwd2, ref data, handleval);
            else
                return BTI1553_64.BTI1553_BCCreateMsg(configval, cwd1, cwd2, ref data, handleval);
        }
        public static void BTI1553_BCPause(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_BCPause(channum, handleval);
            else
                BTI1553_64.BTI1553_BCPause(channum, handleval);
        }
        public static Int32 BTI1553_BCPauseCheck(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCPauseCheck(channum, handleval);
            else
                return BTI1553_64.BTI1553_BCPauseCheck(channum, handleval);
        }
        public static void BTI1553_BCResume(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_BCResume(channum, handleval);
            else
                BTI1553_64.BTI1553_BCResume(channum, handleval);
        }
        public static Int32 BTI1553_BCSchedAgain(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedAgain(index, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedAgain(index, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedBranch(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedBranch(condition, destindex, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedBranch(condition, destindex, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedBranchUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedBranchUpdate(destindex, opcodeindex, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedBranchUpdate(destindex, opcodeindex, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedBuild(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedBuild(nummsgs, ref msgaddr, ref freq, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedBuild(nummsgs, ref msgaddr, ref freq, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedCall(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedCall(condition, destindex, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedCall(condition, destindex, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedCallUpdate(Int32 destindex, Int32 opcodeindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedCallUpdate(destindex, opcodeindex, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedCallUpdate(destindex, opcodeindex, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedEntry(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedEntry(channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedEntry(channum, handleval);
        }
        public static Int32 BTI1553_BCSchedFrame(UInt32 timeval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedFrame(timeval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedFrame(timeval, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedFrameEnd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedFrameEnd(channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedFrameEnd(channum, handleval);
        }
        public static Int32 BTI1553_BCSchedFrameStart(UInt32 timeval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedFrameStart(timeval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedFrameStart(timeval, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedGap(UInt16 gapval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedGap(gapval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedGap(gapval, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedHalt(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedHalt(channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedHalt(channum, handleval);
        }
        public static Int32 BTI1553_BCSchedLog(UInt32 condition, UInt16 tagval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedLog(condition, tagval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedLog(condition, tagval, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedMsg(UInt32 msgaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedMsg(msgaddr, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedMsg(msgaddr, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedPause(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedPause(channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedPause(channum, handleval);
        }
        public static Int32 BTI1553_BCSchedPulse(Int32 dionum, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedPulse(dionum, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedPulse(dionum, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedPulse0(Int32 dionum, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedPulse0(dionum, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedPulse0(dionum, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedPulse1(Int32 dionum, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedPulse1(dionum, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedPulse1(dionum, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedRestart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedRestart(channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedRestart(channum, handleval);
        }
        public static Int32 BTI1553_BCSchedRetry(UInt32 condition, UInt16 retries, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedRetry(condition, retries, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedRetry(condition, retries, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedReturn(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedReturn(channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedReturn(channum, handleval);
        }
        public static Int32 BTI1553_BCSetDefaultGap(Int32 gapval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSetDefaultGap(gapval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSetDefaultGap(gapval, channum, handleval);
        }
        public static Int32 BTI1553_BCSetTimeout(UInt16 timeoutval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSetTimeout(timeoutval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSetTimeout(timeoutval, channum, handleval);
        }
        public static Int32 BTI1553_BCSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval);
        }
        public static Int32 BTI1553_BCTransmitMsg(ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCTransmitMsg(ref xmitfieldsval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCTransmitMsg(ref xmitfieldsval, channum, handleval);
        }
        public static Int32 BTI1553_BCTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
        }
        public static void BTI1553_ChGetCount(ref Int32 a_count, ref Int32 b4_count, ref Int32 b32_count, ref Int32 c_count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_ChGetCount(ref a_count, ref b4_count, ref b32_count, ref c_count, handleval);
            else
                BTI1553_64.BTI1553_ChGetCount(ref a_count, ref b4_count, ref b32_count, ref c_count, handleval);
        }
        public static UInt32 BTI1553_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChGetInfo(infotype, channum, handleval);
            else
                return BTI1553_64.BTI1553_ChGetInfo(infotype, channum, handleval);
        }
        public static Int32 BTI1553_ChIs1553(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIs1553(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIs1553(channum, handleval);
        }
        public static Int32 BTI1553_ChIsA(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsA(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsA(channum, handleval);
        }
        public static Int32 BTI1553_ChIsB32(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsB32(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsB32(channum, handleval);
        }
        public static Int32 BTI1553_ChIsB4(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsB4(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsB4(channum, handleval);
        }
        public static Int32 BTI1553_ChIsBM(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsBM(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsBM(channum, handleval);
        }
        public static Int32 BTI1553_ChIsC(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsC(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsC(channum, handleval);
        }
        public static Int32 BTI1553_ChIsD(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsD(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsD(channum, handleval);
        }
        public static Int32 BTI1553_ChIsM(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsM(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsM(channum, handleval);
        }
        public static Int32 BTI1553_ChIsRM(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsRM(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsRM(channum, handleval);
        }
        public static Int32 BTI1553_ChIsS(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsS(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsS(channum, handleval);
        }
        public static Int32 BTI1553_ChIsX(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsX(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsX(channum, handleval);
        }
        public static Int32 BTI1553_ChStart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChStart(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChStart(channum, handleval);
        }
        public static Int32 BTI1553_ChStop(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChStop(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChStop(channum, handleval);
        }
        public static UInt16 BTI1553_CmdMaxLoopRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdMaxLoopRd(channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdMaxLoopRd(channum, handleval);
        }
        public static void BTI1553_CmdMaxLoopWr(UInt16 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_CmdMaxLoopWr(countval, channum, handleval);
            else
                BTI1553_64.BTI1553_CmdMaxLoopWr(countval, channum, handleval);
        }
        public static Int32 BTI1553_CmdShotRd(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdShotRd(index, channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdShotRd(index, channum, handleval);
        }
        public static Int32 BTI1553_CmdShotWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdShotWr(value, index, channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdShotWr(value, index, channum, handleval);
        }
        public static Int32 BTI1553_CmdSkipRd(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdSkipRd(index, channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdSkipRd(index, channum, handleval);
        }
        public static Int32 BTI1553_CmdSkipWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdSkipWr(value, index, channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdSkipWr(value, index, channum, handleval);
        }
        public static Int32 BTI1553_CmdStepRd(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdStepRd(index, channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdStepRd(index, channum, handleval);
        }
        public static Int32 BTI1553_CmdStepWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdStepWr(value, index, channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdStepWr(value, index, channum, handleval);
        }
        public static Int32 BTI1553_ErrorCtrl(UInt32 ctrlval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ErrorCtrl(ctrlval, channum, handleval);
            else
                return BTI1553_64.BTI1553_ErrorCtrl(ctrlval, channum, handleval);
        }
        public static Int32 BTI1553_ErrorDefine(UInt32 defineval, UInt16 errvalue, Int32 countval, UInt16 wordpos, UInt16 bitpos, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ErrorDefine(defineval, errvalue, countval, wordpos, bitpos, channum, handleval);
            else
                return BTI1553_64.BTI1553_ErrorDefine(defineval, errvalue, countval, wordpos, bitpos, channum, handleval);
        }
        public static Int32 BTI1553_ErrorSent(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ErrorSent(channum, handleval);
            else
                return BTI1553_64.BTI1553_ErrorSent(channum, handleval);
        }
        public static Int32 BTI1553_ErrorTagBC(Int32 tagval, UInt32 msgaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ErrorTagBC(tagval, msgaddr, channum, handleval);
            else
                return BTI1553_64.BTI1553_ErrorTagBC(tagval, msgaddr, channum, handleval);
        }
        public static Int32 BTI1553_ErrorTagRT(Int32 tagval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ErrorTagRT(tagval, mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_ErrorTagRT(tagval, mcflag, taval, trflag, saval, channum, handleval);
        }
        public static Int32 BTI1553_ErrorTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ErrorTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
            else
                return BTI1553_64.BTI1553_ErrorTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
        }
        public static UInt32 BTI1553_ListBlockRd(ref UInt16 buf, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListBlockRd(ref buf, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListBlockRd(ref buf, listaddr, handleval);
        }
        public static UInt32 BTI1553_ListBlockWr(ref UInt16 buf, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListBlockWr(ref buf, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListBlockWr(ref buf, listaddr, handleval);
        }
        public static Int32 BTI1553_ListDataRd(ref UInt16 buf, Int32 count, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListDataRd(ref buf, count, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListDataRd(ref buf, count, listaddr, handleval);
        }
        public static Int32 BTI1553_ListDataWr(ref UInt16 buf, Int32 count, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListDataWr(ref buf, count, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListDataWr(ref buf, count, listaddr, handleval);
        }
        public static Int32 BTI1553_ListMultiBlockRd(ref UInt16 buf, ref Int32 blkcountptr, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListMultiBlockRd(ref buf, ref blkcountptr, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListMultiBlockRd(ref buf, ref blkcountptr, listaddr, handleval);
        }
        public static Int32 BTI1553_ListMultiBlockWr(ref UInt16 buf, Int32 blkcount, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListMultiBlockWr(ref buf, blkcount, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListMultiBlockWr(ref buf, blkcount, listaddr, handleval);
        }
        public static Int32 BTI1553_MonConfig(UInt32 configval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MonConfig(configval, channum, handleval);
            else
                return BTI1553_64.BTI1553_MonConfig(configval, channum, handleval);
        }
        public static Int32 BTI1553_MonFilterSA(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MonFilterSA(taval, rcvsamask, xmtsamask, rcvmcmask, xmtmcmask, channum, handleval);
            else
                return BTI1553_64.BTI1553_MonFilterSA(taval, rcvsamask, xmtsamask, rcvmcmask, xmtmcmask, channum, handleval);
        }
        public static Int32 BTI1553_MonFilterTA(UInt32 tamask, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MonFilterTA(tamask, channum, handleval);
            else
                return BTI1553_64.BTI1553_MonFilterTA(tamask, channum, handleval);
        }
        public static UInt32 BTI1553_MsgBlockRd(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgBlockRd(ref buf, msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgBlockRd(ref buf, msgaddr, handleval);
        }
        public static UInt32 BTI1553_MsgBlockWr(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgBlockWr(ref buf, msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgBlockWr(ref buf, msgaddr, handleval);
        }
        public static void BTI1553_MsgDataRd(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_MsgDataRd(ref buf, count, msgaddr, handleval);
            else
                BTI1553_64.BTI1553_MsgDataRd(ref buf, count, msgaddr, handleval);
        }
        public static void BTI1553_MsgDataWr(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_MsgDataWr(ref buf, count, msgaddr, handleval);
            else
                BTI1553_64.BTI1553_MsgDataWr(ref buf, count, msgaddr, handleval);
        }
        public static UInt32 BTI1553_MsgFieldRd(UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgFieldRd(fieldtype, msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgFieldRd(fieldtype, msgaddr, handleval);
        }
        public static UInt32 BTI1553_MsgFieldWr(UInt32 fieldval, UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgFieldWr(fieldval, fieldtype, msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgFieldWr(fieldval, fieldtype, msgaddr, handleval);
        }
        public static void BTI1553_MsgGroupRd(Int32 nummsgs, ref MSGFIELDS1553 msgflds, ref UInt32 msgaddrptr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_MsgGroupRd(nummsgs, ref msgflds, ref msgaddrptr, handleval);
            else
                BTI1553_64.BTI1553_MsgGroupRd(nummsgs, ref msgflds, ref msgaddrptr, handleval);
        }
        public static void BTI1553_MsgGroupWr(Int32 nummsgs, ref MSGFIELDS1553 msgflds, ref UInt32 msgaddrptr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_MsgGroupWr(nummsgs, ref msgflds, ref msgaddrptr, handleval);
            else
                BTI1553_64.BTI1553_MsgGroupWr(nummsgs, ref msgflds, ref msgaddrptr, handleval);
        }
        public static Int32 BTI1553_MsgSkipRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgSkipRd(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgSkipRd(msgaddr, handleval);
        }
        public static void BTI1553_MsgSkipWr(Int32 skip, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_MsgSkipWr(skip, msgaddr, handleval);
            else
                BTI1553_64.BTI1553_MsgSkipWr(skip, msgaddr, handleval);
        }
        public static Int32 BTI1553_MsgSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgaddr, handleval);
        }
        public static Int32 BTI1553_MsgTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgaddr, handleval);
        }
        public static Int32 BTI1553_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ParamAmplitudeConfig(configval, dacval, channum, handleval);
            else
                return BTI1553_64.BTI1553_ParamAmplitudeConfig(configval, dacval, channum, handleval);
        }
        public static Int32 BTI1553_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ParamAmplitudeGet(ref dacval, channum, handleval);
            else
                return BTI1553_64.BTI1553_ParamAmplitudeGet(ref dacval, channum, handleval);
        }
        public static Int32 BTI1553_PlayConfig(UInt32 configval, UInt32 tamask, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_PlayConfig(configval, tamask, channum, handleval);
            else
                return BTI1553_64.BTI1553_PlayConfig(configval, tamask, channum, handleval);
        }
        public static Int32 BTI1553_PlayStatus(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_PlayStatus(channum, handleval);
            else
                return BTI1553_64.BTI1553_PlayStatus(channum, handleval);
        }
        public static UInt16 BTI1553_PlayWr(ref UInt16 buf, UInt16 bufcount, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_PlayWr(ref buf, bufcount, channum, handleval);
            else
                return BTI1553_64.BTI1553_PlayWr(ref buf, bufcount, channum, handleval);
        }
        public static Int32 BTI1553_RTConfig(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTConfig(configval, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTConfig(configval, taval, channum, handleval);
        }
        public static UInt32 BTI1553_RTCreateList(UInt32 listconfigval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTCreateList(listconfigval, count, msgconfigval, mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTCreateList(listconfigval, count, msgconfigval, mcflag, taval, trflag, saval, channum, handleval);
        }
        public static UInt32 BTI1553_RTCreateMsg(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTCreateMsg(configval, mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTCreateMsg(configval, mcflag, taval, trflag, saval, channum, handleval);
        }
        public static UInt32 BTI1553_RTGetMsg(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTGetMsg(mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTGetMsg(mcflag, taval, trflag, saval, channum, handleval);
        }
        public static Int32 BTI1553_RTReset(Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTReset(taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTReset(taval, channum, handleval);
        }
        public static Int32 BTI1553_RTResponseTimeSet(Int32 resptime, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTResponseTimeSet(resptime, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTResponseTimeSet(resptime, taval, channum, handleval);
        }
        public static Int32 BTI1553_RTSetMode(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTSetMode(configval, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTSetMode(configval, taval, channum, handleval);
        }
        public static UInt16 BTI1553_RTSWDRd(Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTSWDRd(taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTSWDRd(taval, channum, handleval);
        }
        public static Int32 BTI1553_RTSWDWr(UInt16 swdval, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTSWDWr(swdval, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTSWDWr(swdval, taval, channum, handleval);
        }
        public static Int32 BTI1553_RTSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTSyncDefine(enableflag, syncmask, pinpolarity, taval, rcvsamask, xmtsamask, rcvmcmask, xmtmcmask, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTSyncDefine(enableflag, syncmask, pinpolarity, taval, rcvsamask, xmtsamask, rcvmcmask, xmtmcmask, channum, handleval);
        }
        public static UInt16 BTI1553_ValPackCWD(Int32 taval, Int32 trflag, Int32 saval, Int32 wcval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ValPackCWD(taval, trflag, saval, wcval);
            else
                return BTI1553_64.BTI1553_ValPackCWD(taval, trflag, saval, wcval);
        }
        public static void BTI1553_ValUnpackCWD(UInt16 cwdval, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 wcval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_ValUnpackCWD(cwdval, ref taval, ref trflag, ref saval, ref wcval);
            else
                BTI1553_64.BTI1553_ValUnpackCWD(cwdval, ref taval, ref trflag, ref saval, ref wcval);
        }
        public static UInt32 BTI1553_BCCreateListEx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCCreateListEx(listconfigval, skipval, count, msgconfigval, cwd1, cwd2, ref data, handleval);
            else
                return BTI1553_64.BTI1553_BCCreateListEx(listconfigval, skipval, count, msgconfigval, cwd1, cwd2, ref data, handleval);
        }
        public static UInt32 BTI1553_BCCreateListExx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCCreateListExx(listconfigval, skipval, count, msgconfigval, cwd1, cwd2, ref data, handleval);
            else
                return BTI1553_64.BTI1553_BCCreateListExx(listconfigval, skipval, count, msgconfigval, cwd1, cwd2, ref data, handleval);
        }
        public static UInt32 BTI1553_BCGetMsg(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCGetMsg(index, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCGetMsg(index, channum, handleval);
        }
        public static Int32 BTI1553_BCIMGapRd(ref UInt16 gapval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCIMGapRd(ref gapval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCIMGapRd(ref gapval, channum, handleval);
        }
        public static Int32 BTI1553_BCIMGapWr(UInt16 gapval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCIMGapWr(gapval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCIMGapWr(gapval, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedBranchEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 opcode, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedBranchEx(condition1, condition2, condition3, opcode, destindex, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedBranchEx(condition1, condition2, condition3, opcode, destindex, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedCallEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 opcode, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedCallEx(condition1, condition2, condition3, opcode, destindex, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedCallEx(condition1, condition2, condition3, opcode, destindex, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedLogEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 opcode, UInt16 tagval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedLogEx(condition1, condition2, condition3, opcode, tagval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedLogEx(condition1, condition2, condition3, opcode, tagval, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedNop(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedNop(channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedNop(channum, handleval);
        }
        public static Int32 BTI1553_BCSchedRetryEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 retryflag, UInt16 retries, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedRetryEx(condition1, condition2, condition3, retryflag, retries, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedRetryEx(condition1, condition2, condition3, retryflag, retries, channum, handleval);
        }
        public static Int32 BTI1553_BCSchedUser(UInt32 useraddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSchedUser(useraddr, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSchedUser(useraddr, channum, handleval);
        }
        public static Int32 BTI1553_BCSetEntry(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCSetEntry(channum, handleval);
            else
                return BTI1553_64.BTI1553_BCSetEntry(channum, handleval);
        }
        public static Int32 BTI1553_BCTransmitMsgBlkEx(Int32 writeflag, Int32 count, ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCTransmitMsgBlkEx(writeflag, count, ref xmitfieldsval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCTransmitMsgBlkEx(writeflag, count, ref xmitfieldsval, channum, handleval);
        }
        public static Int32 BTI1553_BCTransmitMsgBlkInit(Int32 maxcount, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCTransmitMsgBlkInit(maxcount, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCTransmitMsgBlkInit(maxcount, channum, handleval);
        }
        public static Int32 BTI1553_BCTransmitMsgBlkRd(Int32 count, ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCTransmitMsgBlkRd(count, ref xmitfieldsval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCTransmitMsgBlkRd(count, ref xmitfieldsval, channum, handleval);
        }
        public static Int32 BTI1553_BCTransmitMsgBlkWr(Int32 count, ref XMITFIELDS1553 xmitfieldsval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BCTransmitMsgBlkWr(count, ref xmitfieldsval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BCTransmitMsgBlkWr(count, ref xmitfieldsval, channum, handleval);
        }
        public static UInt16 BTI1553_BlkAddr(Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BlkAddr(taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BlkAddr(taval, channum, handleval);
        }
        public static UInt16 BTI1553_BlkOptRd(Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BlkOptRd(taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BlkOptRd(taval, channum, handleval);
        }
        public static Int32 BTI1553_BlkOptWr(UInt16 rtopt, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BlkOptWr(rtopt, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BlkOptWr(rtopt, taval, channum, handleval);
        }
        public static UInt32 BTI1553_BlkPtrRd(Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BlkPtrRd(taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BlkPtrRd(taval, channum, handleval);
        }
        public static void BTI1553_BlkPtrWr(UInt32 descaddr, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_BlkPtrWr(descaddr, taval, channum, handleval);
            else
                BTI1553_64.BTI1553_BlkPtrWr(descaddr, taval, channum, handleval);
        }
        public static Int32 BTI1553_BlkRd(ref UInt16 block, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BlkRd(ref block, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BlkRd(ref block, taval, channum, handleval);
        }
        public static Int32 BTI1553_BlkReset(Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BlkReset(taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BlkReset(taval, channum, handleval);
        }
        public static UInt16 BTI1553_BlkSWDRd(Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BlkSWDRd(taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BlkSWDRd(taval, channum, handleval);
        }
        public static Int32 BTI1553_BlkSWDWr(UInt16 swdval, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BlkSWDWr(swdval, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BlkSWDWr(swdval, taval, channum, handleval);
        }
        public static Int32 BTI1553_BlkWipe(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BlkWipe(channum, handleval);
            else
                return BTI1553_64.BTI1553_BlkWipe(channum, handleval);
        }
        public static Int32 BTI1553_BlkWr(ref UInt16 block, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_BlkWr(ref block, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_BlkWr(ref block, taval, channum, handleval);
        }
        public static Int32 BTI1553_ChConfig(Int32 enableflag, Int32 typeval, UInt16 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChConfig(enableflag, typeval, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_ChConfig(enableflag, typeval, taval, channum, handleval);
        }
        public static Int32 BTI1553_ChIsRunning(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ChIsRunning(channum, handleval);
            else
                return BTI1553_64.BTI1553_ChIsRunning(channum, handleval);
        }
        public static UInt32 BTI1553_CmdAddr(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdAddr(index, channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdAddr(index, channum, handleval);
        }
        public static UInt32 BTI1553_CmdAlloc(Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdAlloc(count, handleval);
            else
                return BTI1553_64.BTI1553_CmdAlloc(count, handleval);
        }
        public static UInt32 BTI1553_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdAllocEx(configval, count, handleval);
            else
                return BTI1553_64.BTI1553_CmdAllocEx(configval, count, handleval);
        }
        public static UInt32 BTI1553_CmdBaseRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdBaseRd(channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdBaseRd(channum, handleval);
        }
        public static void BTI1553_CmdBaseWr(UInt32 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_CmdBaseWr(addrval, channum, handleval);
            else
                BTI1553_64.BTI1553_CmdBaseWr(addrval, channum, handleval);
        }
        public static Int32 BTI1553_CmdClear(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdClear(channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdClear(channum, handleval);
        }
        public static UInt16 BTI1553_CmdCountRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdCountRd(channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdCountRd(channum, handleval);
        }
        public static void BTI1553_CmdCountWr(UInt16 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_CmdCountWr(countval, channum, handleval);
            else
                BTI1553_64.BTI1553_CmdCountWr(countval, channum, handleval);
        }
        public static UInt16 BTI1553_CmdCtrlRd(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdCtrlRd(index, channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdCtrlRd(index, channum, handleval);
        }
        public static void BTI1553_CmdCtrlWr(UInt16 ctrlval, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_CmdCtrlWr(ctrlval, index, channum, handleval);
            else
                BTI1553_64.BTI1553_CmdCtrlWr(ctrlval, index, channum, handleval);
        }
        public static UInt16 BTI1553_CmdCurrRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdCurrRd(channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdCurrRd(channum, handleval);
        }
        public static void BTI1553_CmdCurrWr(UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_CmdCurrWr(addrval, channum, handleval);
            else
                BTI1553_64.BTI1553_CmdCurrWr(addrval, channum, handleval);
        }
        public static void BTI1553_CmdInit(UInt16 opcode, ref UInt16 block)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_CmdInit(opcode, ref block);
            else
                BTI1553_64.BTI1553_CmdInit(opcode, ref block);
        }
        public static Int32 BTI1553_CmdInsert(ref UInt16 block, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdInsert(ref block, channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdInsert(ref block, channum, handleval);
        }
        public static Int32 BTI1553_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdRd(ref block, addrval, handleval);
            else
                return BTI1553_64.BTI1553_CmdRd(ref block, addrval, handleval);
        }
        public static void BTI1553_CmdRestart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_CmdRestart(channum, handleval);
            else
                BTI1553_64.BTI1553_CmdRestart(channum, handleval);
        }
        public static void BTI1553_CmdStackClr(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_CmdStackClr(channum, handleval);
            else
                BTI1553_64.BTI1553_CmdStackClr(channum, handleval);
        }
        public static UInt16 BTI1553_CmdStartRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdStartRd(channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdStartRd(channum, handleval);
        }
        public static void BTI1553_CmdStartWr(UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_CmdStartWr(addrval, channum, handleval);
            else
                BTI1553_64.BTI1553_CmdStartWr(addrval, channum, handleval);
        }
        public static Int32 BTI1553_CmdTotalRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdTotalRd(channum, handleval);
            else
                return BTI1553_64.BTI1553_CmdTotalRd(channum, handleval);
        }
        public static void BTI1553_CmdTotalWr(Int32 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_CmdTotalWr(countval, channum, handleval);
            else
                BTI1553_64.BTI1553_CmdTotalWr(countval, channum, handleval);
        }
        public static Int32 BTI1553_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_CmdWr(ref block, addrval, handleval);
            else
                return BTI1553_64.BTI1553_CmdWr(ref block, addrval, handleval);
        }
        public static UInt32 BTI1553_DescAddr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_DescAddr(mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_DescAddr(mcflag, taval, trflag, saval, channum, handleval);
        }
        public static UInt32 BTI1553_DescAlloc(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_DescAlloc(handleval);
            else
                return BTI1553_64.BTI1553_DescAlloc(handleval);
        }
        public static Int32 BTI1553_DescConfig(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_DescConfig(configval, mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_DescConfig(configval, mcflag, taval, trflag, saval, channum, handleval);
        }
        public static Int32 BTI1553_DescConfigAll(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_DescConfigAll(configval, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_DescConfigAll(configval, taval, channum, handleval);
        }
        public static UInt16 BTI1553_DescOptRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_DescOptRd(mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_DescOptRd(mcflag, taval, trflag, saval, channum, handleval);
        }
        public static void BTI1553_DescOptWr(UInt16 descopt, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_DescOptWr(descopt, mcflag, taval, trflag, saval, channum, handleval);
            else
                BTI1553_64.BTI1553_DescOptWr(descopt, mcflag, taval, trflag, saval, channum, handleval);
        }
        public static UInt32 BTI1553_DescPtrRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_DescPtrRd(mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_DescPtrRd(mcflag, taval, trflag, saval, channum, handleval);
        }
        public static UInt32 BTI1553_DescPtrWr(UInt32 msgaddr, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_DescPtrWr(msgaddr, mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_DescPtrWr(msgaddr, mcflag, taval, trflag, saval, channum, handleval);
        }
        public static UInt32 BTI1553_DescRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_DescRd(mcflag, taval, trflag, saval, ref desc, channum, handleval);
            else
                return BTI1553_64.BTI1553_DescRd(mcflag, taval, trflag, saval, ref desc, channum, handleval);
        }
        public static UInt32 BTI1553_DescWr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_DescWr(mcflag, taval, trflag, saval, ref desc, channum, handleval);
            else
                return BTI1553_64.BTI1553_DescWr(mcflag, taval, trflag, saval, ref desc, channum, handleval);
        }
        public static Int32 BTI1553_DllUsageCount()
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_DllUsageCount();
            else
                return BTI1553_64.BTI1553_DllUsageCount();
        }
        public static Int32 BTI1553_ErrorIsTaggedBC(UInt32 msgaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ErrorIsTaggedBC(msgaddr, channum, handleval);
            else
                return BTI1553_64.BTI1553_ErrorIsTaggedBC(msgaddr, channum, handleval);
        }
        public static Int32 BTI1553_ErrorIsTaggedRT(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ErrorIsTaggedRT(mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_ErrorIsTaggedRT(mcflag, taval, trflag, saval, channum, handleval);
        }
        public static Int32 BTI1553_ErrorResponse(UInt16 responseval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ErrorResponse(responseval, channum, handleval);
            else
                return BTI1553_64.BTI1553_ErrorResponse(responseval, channum, handleval);
        }
        public static void BTI1553_ErrorSync(Int32 value, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_ErrorSync(value, channum, handleval);
            else
                BTI1553_64.BTI1553_ErrorSync(value, channum, handleval);
        }
        public static Int32 BTI1553_ErrorTimeout(UInt16 timeoutval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ErrorTimeout(timeoutval, channum, handleval);
            else
                return BTI1553_64.BTI1553_ErrorTimeout(timeoutval, channum, handleval);
        }
        public static Int32 BTI1553_HostComm(IntPtr lpparam, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_HostComm(lpparam, handleval);
            else
                return BTI1553_64.BTI1553_HostComm(lpparam, handleval);
        }
        public static Int32 BTI1553_IsChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_IsChan(channum, handleval);
            else
                return BTI1553_64.BTI1553_IsChan(channum, handleval);
        }
        public static UInt32 BTI1553_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListAddr(index, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListAddr(index, listaddr, handleval);
        }
        public static UInt32 BTI1553_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListAddrEx(index, listaddr, ref header, handleval);
            else
                return BTI1553_64.BTI1553_ListAddrEx(index, listaddr, ref header, handleval);
        }
        public static UInt32 BTI1553_ListBlockRdEx(ref UInt16 buf, Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListBlockRdEx(ref buf, index, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListBlockRdEx(ref buf, index, listaddr, handleval);
        }
        public static UInt32 BTI1553_ListBlockWrEx(ref UInt16 buf, Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListBlockWrEx(ref buf, index, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListBlockWrEx(ref buf, index, listaddr, handleval);
        }
        public static Int32 BTI1553_ListClear(UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListClear(listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListClear(listaddr, handleval);
        }
        public static UInt32 BTI1553_ListConfig(UInt32 configval, Int32 count, UInt16 skipval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListConfig(configval, count, skipval, handleval);
            else
                return BTI1553_64.BTI1553_ListConfig(configval, count, skipval, handleval);
        }
        public static UInt32 BTI1553_ListConfigEx(UInt32 configval, Int32 count, UInt16 skipval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListConfigEx(configval, count, skipval, handleval);
            else
                return BTI1553_64.BTI1553_ListConfigEx(configval, count, skipval, handleval);
        }
        public static Int32 BTI1553_ListDataRdEx(ref UInt16 buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListDataRdEx(ref buf, count, index, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListDataRdEx(ref buf, count, index, listaddr, handleval);
        }
        public static Int32 BTI1553_ListDataWrEx(ref UInt16 buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListDataWrEx(ref buf, count, index, listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListDataWrEx(ref buf, count, index, listaddr, handleval);
        }
        public static Int32 BTI1553_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListInit(listaddr, msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListInit(listaddr, msgaddr, handleval);
        }
        public static UInt32 BTI1553_ListNextRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListNextRd(listaddr, ref header, handleval);
            else
                return BTI1553_64.BTI1553_ListNextRd(listaddr, ref header, handleval);
        }
        public static UInt32 BTI1553_ListNextWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListNextWr(listaddr, ref header, handleval);
            else
                return BTI1553_64.BTI1553_ListNextWr(listaddr, ref header, handleval);
        }
        public static void BTI1553_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_ListPostRd(listaddr, ref header, handleval);
            else
                BTI1553_64.BTI1553_ListPostRd(listaddr, ref header, handleval);
        }
        public static void BTI1553_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_ListPostWr(listaddr, ref header, handleval);
            else
                BTI1553_64.BTI1553_ListPostWr(listaddr, ref header, handleval);
        }
        public static void BTI1553_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_ListPreRd(listaddr, ref header, handleval);
            else
                BTI1553_64.BTI1553_ListPreRd(listaddr, ref header, handleval);
        }
        public static void BTI1553_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_ListPreWr(listaddr, ref header, handleval);
            else
                BTI1553_64.BTI1553_ListPreWr(listaddr, ref header, handleval);
        }
        public static Int32 BTI1553_ListStatus(UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ListStatus(listaddr, handleval);
            else
                return BTI1553_64.BTI1553_ListStatus(listaddr, handleval);
        }
        public static Int32 BTI1553_ModeIsBC(UInt16 chanflag)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ModeIsBC(chanflag);
            else
                return BTI1553_64.BTI1553_ModeIsBC(chanflag);
        }
        public static Int32 BTI1553_ModeIsMon(UInt16 chanflag)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ModeIsMon(chanflag);
            else
                return BTI1553_64.BTI1553_ModeIsMon(chanflag);
        }
        public static Int32 BTI1553_ModeIsNotBC(UInt16 chanflag)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ModeIsNotBC(chanflag);
            else
                return BTI1553_64.BTI1553_ModeIsNotBC(chanflag);
        }
        public static Int32 BTI1553_ModeIsNotMon(UInt16 chanflag)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ModeIsNotMon(chanflag);
            else
                return BTI1553_64.BTI1553_ModeIsNotMon(chanflag);
        }
        public static Int32 BTI1553_ModeIsNotPlay(UInt16 chanflag)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ModeIsNotPlay(chanflag);
            else
                return BTI1553_64.BTI1553_ModeIsNotPlay(chanflag);
        }
        public static Int32 BTI1553_ModeIsNotRT(UInt16 chanflag)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ModeIsNotRT(chanflag);
            else
                return BTI1553_64.BTI1553_ModeIsNotRT(chanflag);
        }
        public static Int32 BTI1553_ModeIsNotSerial(UInt16 chanflag)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ModeIsNotSerial(chanflag);
            else
                return BTI1553_64.BTI1553_ModeIsNotSerial(chanflag);
        }
        public static Int32 BTI1553_ModeIsPlay(UInt16 chanflag)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ModeIsPlay(chanflag);
            else
                return BTI1553_64.BTI1553_ModeIsPlay(chanflag);
        }
        public static Int32 BTI1553_ModeIsRT(UInt16 chanflag)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ModeIsRT(chanflag);
            else
                return BTI1553_64.BTI1553_ModeIsRT(chanflag);
        }
        public static Int32 BTI1553_ModeIsSerial(UInt16 chanflag)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ModeIsSerial(chanflag);
            else
                return BTI1553_64.BTI1553_ModeIsSerial(chanflag);
        }
        public static Int32 BTI1553_MonConfigEx(UInt32 configval, UInt32 moncount, UInt16 cardnum, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MonConfigEx(configval, moncount, cardnum, channum, handleval);
            else
                return BTI1553_64.BTI1553_MonConfigEx(configval, moncount, cardnum, channum, handleval);
        }
        public static Int32 BTI1553_MonFilterSAEx(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MonFilterSAEx(taval, rcvsamask, xmtsamask, rcvmcmask, xmtmcmask, channum, handleval);
            else
                return BTI1553_64.BTI1553_MonFilterSAEx(taval, rcvsamask, xmtsamask, rcvmcmask, xmtmcmask, channum, handleval);
        }
        public static UInt16 BTI1553_MsgCheck(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgCheck(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgCheck(msgaddr, handleval);
        }
        public static UInt32 BTI1553_MsgCommRd(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgCommRd(ref buf, msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgCommRd(ref buf, msgaddr, handleval);
        }
        public static UInt32 BTI1553_MsgCommWr(ref MSGFIELDS1553 buf, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgCommWr(ref buf, msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgCommWr(ref buf, msgaddr, handleval);
        }
        public static UInt32 BTI1553_MsgConfig(UInt32 configval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgConfig(configval, handleval);
            else
                return BTI1553_64.BTI1553_MsgConfig(configval, handleval);
        }
        public static UInt32 BTI1553_MsgConfigEx(UInt32 configval, UInt16 cwd, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgConfigEx(configval, cwd, handleval);
            else
                return BTI1553_64.BTI1553_MsgConfigEx(configval, cwd, handleval);
        }
        public static UInt16 BTI1553_MsgCWD1Rd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgCWD1Rd(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgCWD1Rd(msgaddr, handleval);
        }
        public static void BTI1553_MsgCWD1Wr(UInt16 cwd1, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_MsgCWD1Wr(cwd1, msgaddr, handleval);
            else
                BTI1553_64.BTI1553_MsgCWD1Wr(cwd1, msgaddr, handleval);
        }
        public static UInt16 BTI1553_MsgCWD2Rd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgCWD2Rd(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgCWD2Rd(msgaddr, handleval);
        }
        public static void BTI1553_MsgCWD2Wr(UInt16 cwd2, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_MsgCWD2Wr(cwd2, msgaddr, handleval);
            else
                BTI1553_64.BTI1553_MsgCWD2Wr(cwd2, msgaddr, handleval);
        }
        public static UInt16 BTI1553_MsgErrorRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgErrorRd(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgErrorRd(msgaddr, handleval);
        }
        public static void BTI1553_MsgErrorWr(UInt16 value, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_MsgErrorWr(value, msgaddr, handleval);
            else
                BTI1553_64.BTI1553_MsgErrorWr(value, msgaddr, handleval);
        }
        public static UInt16 BTI1553_MsgFlagRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgFlagRd(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgFlagRd(msgaddr, handleval);
        }
        public static void BTI1553_MsgFlagWr(UInt16 msgflag, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_MsgFlagWr(msgflag, msgaddr, handleval);
            else
                BTI1553_64.BTI1553_MsgFlagWr(msgflag, msgaddr, handleval);
        }
        public static Int32 BTI1553_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgIsAccessed(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgIsAccessed(msgaddr, handleval);
        }
        public static UInt16 BTI1553_MsgOptRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgOptRd(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgOptRd(msgaddr, handleval);
        }
        public static void BTI1553_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_MsgOptWr(msgopt, msgaddr, handleval);
            else
                BTI1553_64.BTI1553_MsgOptWr(msgopt, msgaddr, handleval);
        }
        public static UInt32 BTI1553_MsgReset(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgReset(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgReset(msgaddr, handleval);
        }
        public static UInt32 BTI1553_MsgResetEx(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgResetEx(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgResetEx(msgaddr, handleval);
        }
        public static UInt16 BTI1553_MsgSWD1Rd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgSWD1Rd(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgSWD1Rd(msgaddr, handleval);
        }
        public static UInt16 BTI1553_MsgSWD2Rd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_MsgSWD2Rd(msgaddr, handleval);
            else
                return BTI1553_64.BTI1553_MsgSWD2Rd(msgaddr, handleval);
        }
        public static Int32 BTI1553_PlayClear(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_PlayClear(channum, handleval);
            else
                return BTI1553_64.BTI1553_PlayClear(channum, handleval);
        }
        public static Int32 BTI1553_PlayConfigEx(UInt32 configval, UInt32 playcount, UInt32 tamask, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_PlayConfigEx(configval, playcount, tamask, channum, handleval);
            else
                return BTI1553_64.BTI1553_PlayConfigEx(configval, playcount, tamask, channum, handleval);
        }
        public static UInt32 BTI1553_PlayCounterWr(UInt32 totalcount, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_PlayCounterWr(totalcount, channum, handleval);
            else
                return BTI1553_64.BTI1553_PlayCounterWr(totalcount, channum, handleval);
        }
        public static Int32 BTI1553_PlayStatusEx(ref UInt32 totalcount, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_PlayStatusEx(ref totalcount, channum, handleval);
            else
                return BTI1553_64.BTI1553_PlayStatusEx(ref totalcount, channum, handleval);
        }
        public static UInt16 BTI1553_PlayWrEx(ref UInt16 buf, UInt16 bufcount, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_PlayWrEx(ref buf, bufcount, channum, handleval);
            else
                return BTI1553_64.BTI1553_PlayWrEx(ref buf, bufcount, channum, handleval);
        }
        public static Int32 BTI1553_RTConfigEx(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTConfigEx(configval, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTConfigEx(configval, taval, channum, handleval);
        }
        public static Int32 BTI1553_RTConfigExx(UInt32 configval, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTConfigExx(configval, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTConfigExx(configval, taval, channum, handleval);
        }
        public static UInt32 BTI1553_RTCreateListEx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTCreateListEx(listconfigval, skipval, count, msgconfigval, mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTCreateListEx(listconfigval, skipval, count, msgconfigval, mcflag, taval, trflag, saval, channum, handleval);
        }
        public static UInt32 BTI1553_RTCreateListExx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTCreateListExx(listconfigval, skipval, count, msgconfigval, mcflag, taval, trflag, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTCreateListExx(listconfigval, skipval, count, msgconfigval, mcflag, taval, trflag, saval, channum, handleval);
        }
        public static Int32 BTI1553_RTResponseTimeRd(ref UInt16 timeval, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTResponseTimeRd(ref timeval, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTResponseTimeRd(ref timeval, taval, channum, handleval);
        }
        public static Int32 BTI1553_RTResponseTimeWr(UInt16 timeval, Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTResponseTimeWr(timeval, taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTResponseTimeWr(timeval, taval, channum, handleval);
        }
        public static UInt16 BTI1553_RTStatus(Int32 taval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_RTStatus(taval, channum, handleval);
            else
                return BTI1553_64.BTI1553_RTStatus(taval, channum, handleval);
        }
        public static Int32 BTI1553_SABlkWr(Int32 taval, Int32 saval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SABlkWr(taval, saval, channum, handleval);
            else
                return BTI1553_64.BTI1553_SABlkWr(taval, saval, channum, handleval);
        }
        public static Int32 BTI1553_SABlkWrEx(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SABlkWrEx(channum, handleval);
            else
                return BTI1553_64.BTI1553_SABlkWrEx(channum, handleval);
        }
        public static Int32 BTI1553_SchedBuild(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 freq, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SchedBuild(nummsgs, ref msgaddr, ref freq, channum, handleval);
            else
                return BTI1553_64.BTI1553_SchedBuild(nummsgs, ref msgaddr, ref freq, channum, handleval);
        }
        public static Int32 BTI1553_SchedBuildEx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 freq, ref Int32 period, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SchedBuildEx(nummsgs, ref msgaddr, ref freq, ref period, buf, bufsize, channum, handleval);
            else
                return BTI1553_64.BTI1553_SchedBuildEx(nummsgs, ref msgaddr, ref freq, ref period, buf, bufsize, channum, handleval);
        }
        public static Int32 BTI1553_SchedBuildExx(UInt32 frametime, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 period, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SchedBuildExx(frametime, nummsgs, ref msgaddr, ref period, buf, bufsize, channum, handleval);
            else
                return BTI1553_64.BTI1553_SchedBuildExx(frametime, nummsgs, ref msgaddr, ref period, buf, bufsize, channum, handleval);
        }
        public static Int32 BTI1553_SchedCalc(ref UInt32 msgaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SchedCalc(ref msgaddr, channum, handleval);
            else
                return BTI1553_64.BTI1553_SchedCalc(ref msgaddr, channum, handleval);
        }
        public static void BTI1553_SchedDisplay(UInt32 nummsgs, ref UInt32 count)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_SchedDisplay(nummsgs, ref count);
            else
                BTI1553_64.BTI1553_SchedDisplay(nummsgs, ref count);
        }
        public static void BTI1553_SchedHook(Int32 index, IntPtr ptr)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_SchedHook(index, ptr);
            else
                BTI1553_64.BTI1553_SchedHook(index, ptr);
        }
        public static Int32 BTI1553_SchedInsEnd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SchedInsEnd(channum, handleval);
            else
                return BTI1553_64.BTI1553_SchedInsEnd(channum, handleval);
        }
        public static Int32 BTI1553_SchedInsMsg(UInt32 index, ref UInt32 msgaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SchedInsMsg(index, ref msgaddr, channum, handleval);
            else
                return BTI1553_64.BTI1553_SchedInsMsg(index, ref msgaddr, channum, handleval);
        }
        public static Int32 BTI1553_SchedInsStart(UInt32 frametime, UInt32 count, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SchedInsStart(frametime, count, channum, handleval);
            else
                return BTI1553_64.BTI1553_SchedInsStart(frametime, count, channum, handleval);
        }
        public static UInt32 BTI1553_SchedMaxval(ref UInt32 arrayval, UInt32 arrayvalcount)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SchedMaxval(ref arrayval, arrayvalcount);
            else
                return BTI1553_64.BTI1553_SchedMaxval(ref arrayval, arrayvalcount);
        }
        public static UInt32 BTI1553_SchedMinval(ref UInt32 arrayval, UInt32 arrayvalcount)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SchedMinval(ref arrayval, arrayvalcount);
            else
                return BTI1553_64.BTI1553_SchedMinval(ref arrayval, arrayvalcount);
        }
        public static Int32 BTI1553_SerialClear(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SerialClear(channum, handleval);
            else
                return BTI1553_64.BTI1553_SerialClear(channum, handleval);
        }
        public static Int32 BTI1553_SerialConfig(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SerialConfig(configval, count, channum, handleval);
            else
                return BTI1553_64.BTI1553_SerialConfig(configval, count, channum, handleval);
        }
        public static Int32 BTI1553_SerialConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SerialConfigEx(configval, count, channum, handleval);
            else
                return BTI1553_64.BTI1553_SerialConfigEx(configval, count, channum, handleval);
        }
        public static Int32 BTI1553_SerialStatus(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SerialStatus(channum, handleval);
            else
                return BTI1553_64.BTI1553_SerialStatus(channum, handleval);
        }
        public static UInt32 BTI1553_SerialWr(ref UInt16 buf, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_SerialWr(ref buf, channum, handleval);
            else
                return BTI1553_64.BTI1553_SerialWr(ref buf, channum, handleval);
        }
        public static Int32 BTI1553_TestProtocol(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_TestProtocol(handleval);
            else
                return BTI1553_64.BTI1553_TestProtocol(handleval);
        }
        public static UInt16 BTI1553_ValPackRTCWD(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 count)
        {
            if (IntPtr.Size == 4)
                return BTI1553_32.BTI1553_ValPackRTCWD(mcflag, taval, trflag, saval, count);
            else
                return BTI1553_64.BTI1553_ValPackRTCWD(mcflag, taval, trflag, saval, count);
        }
        public static void BTI1553_ValUnpackRTCWD(UInt16 cwd, ref Int32 bcastflag, ref Int32 mcflag, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 count)
        {
            if (IntPtr.Size == 4)
                BTI1553_32.BTI1553_ValUnpackRTCWD(cwd, ref bcastflag, ref mcflag, ref taval, ref trflag, ref saval, ref count);
            else
                BTI1553_64.BTI1553_ValUnpackRTCWD(cwd, ref bcastflag, ref mcflag, ref taval, ref trflag, ref saval, ref count);
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

        /**
        *
        *  Bus controller configuration options
        *
        **/

        public const UInt32 BCCFG1553_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 BCCFG1553_ENABLE = 0x00000000;	//Enable bus controller (default)
        public const UInt32 BCCFG1553_DISABLE = 0x00000001;	//Disable bus controller
        public const UInt32 BCCFG1553_TRIGNONE = 0x00000000;	//No trigger (default)
        public const UInt32 BCCFG1553_TRIGEXT = 0x00000010;	//Trigger external
        public const UInt32 BCCFG1553_TRIGSTART = 0x00000020;	//Trigger external start
        public const UInt32 BCCFG1553_NOLOGHALT = 0x00000000;	//Do not generate event log on halt (default)
        public const UInt32 BCCFG1553_LOGHALT = 0x00000100;	//Generate event log on halt
        public const UInt32 BCCFG1553_NOLOGPAUSE = 0x00000000;	//Do not generate event log on pause (default)
        public const UInt32 BCCFG1553_LOGPAUSE = 0x00000200;	//Generate event log on pause
        public const UInt32 BCCFG1553_NOLOOPMAX = 0x00000000;	//Disable maximum loop count (default)
        public const UInt32 BCCFG1553_LOOPMAX = 0x00001000;	//Enable maximum loop count
        public const UInt32 BCCFG1553_NOSTEP = 0x00000000;	//Disable single stepping (default)
        public const UInt32 BCCFG1553_STEP = 0x00002000;	//Enable single stepping
        public const UInt32 BCCFG1553_MC01 = 0x00000000;	//Select SA=00000 or SA=11111 for mode codes (default)
        public const UInt32 BCCFG1553_MC1 = 0x01000000;	//Select SA=11111 for mode codes
        public const UInt32 BCCFG1553_MC0 = 0x02000000;	//Select SA=00000 for mode codes
        public const UInt32 BCCFG1553_MCNONE = 0x03000000;	//Disable mode codes
        public const UInt32 BCCFG1553_TERMOFF = 0x00000000;	//Direct coupled termination resistance off (Bus A & B) (default)
        public const UInt32 BCCFG1553_TERMONA = 0x04000000;	//Direct coupled termination resistance on  (Bus A)
        public const UInt32 BCCFG1553_TERMONB = 0x08000000;	//Direct coupled termination resistance on  (Bus B)
        public const UInt32 BCCFG1553_TERMONAB = 0x0C000000;	//Direct coupled termination resistance on  (Bus A & B)
        public const UInt32 BCCFG1553_SYNCSEL = 0x00000000;	//Selective sync (default)
        public const UInt32 BCCFG1553_SYNCALL = 0x40000000;	//Sync on all messages
        public const UInt32 BCCFG1553_PAUSE = 0x00000400;	//Mark channel as paused
        public const UInt32 BCCFG1553_UNPAUSE = 0x00000000;	//Mark channel as unpaused (default)
        public const UInt32 BCCFG1553_SELFTEST = 0x00800000;	//This channel will transmit/receive on the internal self-test bus
        public const UInt32 BCCFG1553_SELFTESTOFF = 0x00000000;	//This channel will transmit/receive on the operational bus (default)

        /**
        *
        *  Monitor configuration options
        *
        **/

        public const UInt32 MONCFG1553_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 MONCFG1553_ENABLE = 0x00000000;	//Enable monitor
        public const UInt32 MONCFG1553_DISABLE = 0x00000001;	//Disable monitor
        public const UInt32 MONCFG1553_NOBCAST = 0x00000000;	//Disable broadcast (default)
        public const UInt32 MONCFG1553_BCAST = 0x00000100;	//Enable broadcast
        public const UInt32 MONCFG1553_COMPLETE = 0x00000000;	//Enable receiving complete words (default)
        public const UInt32 MONCFG1553_INCOMPLETE = 0x00010000;	//Enable receiving incomplete words
        public const UInt32 MONCFG1553_MC01 = 0x00000000;	//Select SA=00000 or SA=11111 for mode codes (default)
        public const UInt32 MONCFG1553_MC1 = 0x00100000;	//Select SA=11111 for mode codes
        public const UInt32 MONCFG1553_MC0 = 0x00200000;	//Select SA=00000 for mode codes
        public const UInt32 MONCFG1553_MCNONE = 0x00300000;	//Disable mode codes
        public const UInt32 MONCFG1553_TERMOFF = 0x00000000;	//Direct coupled termination resistance off (Bus A & B) (default)
        public const UInt32 MONCFG1553_TERMONA = 0x04000000;	//Direct coupled termination resistance on  (Bus A)
        public const UInt32 MONCFG1553_TERMONB = 0x08000000;	//Direct coupled termination resistance on  (Bus B)
        public const UInt32 MONCFG1553_TERMONAB = 0x0C000000;	//Direct coupled termination resistance on  (Bus A & B)
        public const UInt32 MONCFG1553_SELFTEST = 0x00800000;	//This channel will transmit/receive on the internal self-test bus
        public const UInt32 MONCFG1553_SELFTESTOFF = 0x00000000;	//This channel will transmit/receive on the operational bus (default)

        /**
        *
        *  Remote terminal configuration options
        *
        **/

        public const UInt32 RTCFG1553_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 RTCFG1553_SIMULATE = 0x00000000;	//Enable RT simulation (default)
        public const UInt32 RTCFG1553_DISABLE = 0x00000001;	//Disable RT
        public const UInt32 RTCFG1553_MONITOR = 0x00000002;	//Enable RT monitor
        public const UInt32 RTCFG1553_NOBCAST = 0x00000000;	//Disable broadcast (default)
        public const UInt32 RTCFG1553_BCAST = 0x00000100;	//Enable broadcast
        public const UInt32 RTCFG1553_NOAUTOBUSY = 0x00000000;	//Disable auto busy (default)
        public const UInt32 RTCFG1553_AUTOBUSY = 0x00000200;	//Enable auto busy
        public const UInt32 RTCFG1553_BUILD = 0x00000000;	//Enable auto building (default)
        public const UInt32 RTCFG1553_NOBUILD = 0x00000400;	//Disable auto building
        public const UInt32 RTCFG1553_STDB = 0x00000000;	//Use MIL-STD-1553B standard (default)
        public const UInt32 RTCFG1553_STDA = 0x00400000;	//Use MIL-STD-1553A standard
        public const UInt32 RTCFG1553_NODYNBC = 0x00000000;	//Do not respond to dynamic BC mode code (default)
        public const UInt32 RTCFG1553_DYNBC = 0x00001000;	//Respond to dynamic BC mode code
        public const UInt32 RTCFG1553_NOIMMCLR = 0x00000000;	//Do not clear status word bits (default)
        public const UInt32 RTCFG1553_IMMCLR = 0x00002000;	//Status word bits are cleared immediately
        public const UInt32 RTCFG1553_NOBCASTADDR = 0x00000000;	//Disable broadcast handling for address (default)
        public const UInt32 RTCFG1553_BCASTADDR = 0x00004000;	//Enable broadcast handling for address
        public const UInt32 RTCFG1553_CHANAB = 0x00000000;	//Respond to both channels (default)
        public const UInt32 RTCFG1553_CHANA = 0x00020000;	//Respond to channel A
        public const UInt32 RTCFG1553_CHANB = 0x00010000;	//Respond to channel B
        public const UInt32 RTCFG1553_CHANNONE = 0x00030000;	//Respond to neither channel A nor B
        public const UInt32 RTCFG1553_MC01 = 0x00000000;	//Select SA=00000 or SA=11111 for mode codes (default)
        public const UInt32 RTCFG1553_MC1 = 0x01000000;	//Select SA=11111 for mode codes
        public const UInt32 RTCFG1553_MC0 = 0x02000000;	//Select SA=00000 for mode codes
        public const UInt32 RTCFG1553_MCNONE = 0x03000000;	//Disable mode codes
        public const UInt32 RTCFG1553_TERMOFF = 0x00000000;	//Direct coupled termination resistance off (Bus A & B) (default)
        public const UInt32 RTCFG1553_TERMONA = 0x04000000;	//Direct coupled termination resistance on  (Bus A)
        public const UInt32 RTCFG1553_TERMONB = 0x08000000;	//Direct coupled termination resistance on  (Bus B)
        public const UInt32 RTCFG1553_TERMONAB = 0x0C000000;	//Direct coupled termination resistance on  (Bus A & B)
        public const UInt32 RTCFG1553_SYNCSEL = 0x00000000;	//Selective sync (default)
        public const UInt32 RTCFG1553_SYNCALL = 0x40000000;	//Sync on all messages
        public const UInt32 RTCFG1553_WIPE = 0x00000000;	//Enables message clear (default)
        public const UInt32 RTCFG1553_NOWIPE = 0x80000000;	//Disables message clear
        public const UInt32 RTCFG1553_WIPE0 = 0x00000000;	//Initialize data with zeros (default)
        public const UInt32 RTCFG1553_WIPE123 = 0x10000000;	//Initialize data with incrementing values
        public const UInt32 RTCFG1553_WIPECWD = 0x20000000;	//Initialize data with command word
        public const UInt32 RTCFG1553_RESPONSEB = 0x00000000;	//RT responds using MIL-STD-1553B response time
        public const UInt32 RTCFG1553_RESPONSEA = 0x00400000;	//RT responds using MIL-STD-1553A response time
        public const UInt32 RTCFG1553_SELFTEST = 0x00800000;	//This channel will transmit/receive on the internal self-test bus
        public const UInt32 RTCFG1553_SELFTESTOFF = 0x00000000;	//This channel will transmit/receive on the operational bus (default)

        /**
        *
        *  Playback configuration options
        *
        **/

        public const UInt32 PLAYCFG1553_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 PLAYCFG1553_ENABLE = 0x00000000;	//Enable Playback mode
        public const UInt32 PLAYCFG1553_DISABLE = 0x00000001;	//Disable Playback mode
        public const UInt32 PLAYCFG1553_16K = 0x00000000;	//Allocate a 16K playback buffer (default)
        public const UInt32 PLAYCFG1553_ALLAVAIL = 0x00000010;	//Allocate all available memory to playback buffer
        public const UInt32 PLAYCFG1553_32K = 0x00000020;	//Allocate a 32K playback buffer
        public const UInt32 PLAYCFG1553_64K = 0x00000040;	//Allocate a 64K playback buffer
        public const UInt32 PLAYCFG1553_128K = 0x00000080;	//Allocate a 128K playback buffer
        public const UInt32 PLAYCFG1553_MC01 = 0x00000000;	//Select SA=00000 or SA=11111 for mode codes (default)
        public const UInt32 PLAYCFG1553_MC1 = 0x01000000;	//Select SA=11111 for mode codes
        public const UInt32 PLAYCFG1553_MC0 = 0x02000000;	//Select SA=00000 for mode codes
        public const UInt32 PLAYCFG1553_MCNONE = 0x03000000;	//Disable mode codes
        public const UInt32 PLAYCFG1553_TERMOFF = 0x00000000;	//Direct coupled termination resistance off (Bus A & B) (default)
        public const UInt32 PLAYCFG1553_TERMONA = 0x04000000;	//Direct coupled termination resistance on  (Bus A)
        public const UInt32 PLAYCFG1553_TERMONB = 0x08000000;	//Direct coupled termination resistance on  (Bus B)
        public const UInt32 PLAYCFG1553_TERMONAB = 0x0C000000;	//Direct coupled termination resistance on  (Bus A & B)

        /**
        *
        *  Serial configuration options
        *
        **/

        public const UInt32 SERCFG1553_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 SERCFG1553_CONTINUOUS = 0x00000000;	//Enable continuous mode (default)
        public const UInt32 SERCFG1553_DISABLE = 0x00000001;	//Disable free mode
        public const UInt32 SERCFG1553_FREE = 0x00000002;	//Enable free mode
        public const UInt32 SERCFG1553_NOLOGEMPTY = 0x00000000;	//Do not generate event log when empty (default)
        public const UInt32 SERCFG1553_LOGEMPTY = 0x00000010;	//Generate event log when empty

        /**
        *
        *  Error configuration options
        *
        **/

        public const UInt32 ERRDEF1553_NONE = 0x00000000;	//Disable error generation (default)
        public const UInt32 ERRDEF1553_GAP = 0x00010000;	//Generate preceding gap error
        public const UInt32 ERRDEF1553_CNTWRDABS = 0x00020000;	//Generate an absolute word count error
        public const UInt32 ERRDEF1553_CNTWRDREL = 0x00040000;	//Generate a relative count error
        public const UInt32 ERRDEF1553_CNTBIT = 0x00080000;	//Generate a bit count error
        public const UInt32 ERRDEF1553_MAN1 = 0x00100000;	//Generate manchester error on first half of bit
        public const UInt32 ERRDEF1553_MAN2 = 0x00200000;	//Generate manchester error on second half of bit
        public const UInt32 ERRDEF1553_SYNC = 0x00400000;	//Generate a sync error
        public const UInt32 ERRDEF1553_PAR = 0x00800000;	//Generate a parity error
        public const UInt32 ERRDEF1553_ZEROX1 = 0x01000000;	//Generate zero crossing error on leading zero crossing (if exists)
        public const UInt32 ERRDEF1553_ZEROX2 = 0x02000000;	//Generate zero crossing error on mid-bit zero crossing
        public const UInt32 ERRDEF1553_DWD00 = 0x0000;	//Error will be generated in data word  0
        public const UInt32 ERRDEF1553_DWD01 = 0x0001;	//Error will be generated in data word  1
        public const UInt32 ERRDEF1553_DWD02 = 0x0002;	//Error will be generated in data word  2
        public const UInt32 ERRDEF1553_DWD03 = 0x0003;	//Error will be generated in data word  3
        public const UInt32 ERRDEF1553_DWD04 = 0x0004;	//Error will be generated in data word  4
        public const UInt32 ERRDEF1553_DWD05 = 0x0005;	//Error will be generated in data word  5
        public const UInt32 ERRDEF1553_DWD06 = 0x0006;	//Error will be generated in data word  6
        public const UInt32 ERRDEF1553_DWD07 = 0x0007;	//Error will be generated in data word  7
        public const UInt32 ERRDEF1553_DWD08 = 0x0008;	//Error will be generated in data word  8
        public const UInt32 ERRDEF1553_DWD09 = 0x0009;	//Error will be generated in data word  9
        public const UInt32 ERRDEF1553_DWD10 = 0x000A;	//Error will be generated in data word 10
        public const UInt32 ERRDEF1553_DWD11 = 0x000B;	//Error will be generated in data word 11
        public const UInt32 ERRDEF1553_DWD12 = 0x000C;	//Error will be generated in data word 12
        public const UInt32 ERRDEF1553_DWD13 = 0x000D;	//Error will be generated in data word 13
        public const UInt32 ERRDEF1553_DWD14 = 0x000E;	//Error will be generated in data word 14
        public const UInt32 ERRDEF1553_DWD15 = 0x000F;	//Error will be generated in data word 15
        public const UInt32 ERRDEF1553_DWD16 = 0x0010;	//Error will be generated in data word 16
        public const UInt32 ERRDEF1553_DWD17 = 0x0011;	//Error will be generated in data word 17
        public const UInt32 ERRDEF1553_DWD18 = 0x0012;	//Error will be generated in data word 18
        public const UInt32 ERRDEF1553_DWD19 = 0x0013;	//Error will be generated in data word 19
        public const UInt32 ERRDEF1553_DWD20 = 0x0014;	//Error will be generated in data word 20
        public const UInt32 ERRDEF1553_DWD21 = 0x0015;	//Error will be generated in data word 21
        public const UInt32 ERRDEF1553_DWD22 = 0x0016;	//Error will be generated in data word 22
        public const UInt32 ERRDEF1553_DWD23 = 0x0017;	//Error will be generated in data word 23
        public const UInt32 ERRDEF1553_DWD24 = 0x0018;	//Error will be generated in data word 24
        public const UInt32 ERRDEF1553_DWD25 = 0x0019;	//Error will be generated in data word 25
        public const UInt32 ERRDEF1553_DWD26 = 0x001A;	//Error will be generated in data word 26
        public const UInt32 ERRDEF1553_DWD27 = 0x001B;	//Error will be generated in data word 27
        public const UInt32 ERRDEF1553_DWD28 = 0x001C;	//Error will be generated in data word 28
        public const UInt32 ERRDEF1553_DWD29 = 0x001D;	//Error will be generated in data word 29
        public const UInt32 ERRDEF1553_DWD30 = 0x001E;	//Error will be generated in data word 30
        public const UInt32 ERRDEF1553_DWD31 = 0x001F;	//Error will be generated in data word 31
        public const UInt32 ERRDEF1553_CWD1 = 0x0100;	//Error will be generated in CWD1
        public const UInt32 ERRDEF1553_CWD2 = 0x0101;	//Error will be generated in CWD2
        public const UInt32 ERRDEF1553_SWD = 0x0102;	//Error will be generated in SWD
        public const UInt32 ERRDEF1553_SWD1 = 0x0102;	//Error will be generated in SWD
        public const UInt32 ERRDEF1553_SWD2 = 0x0102;	//Error will be generated in SWD

        /**
        *
        *  Error control options
        *
        **/

        public const UInt32 ERRCTRL1553_OFF = 0x00000000;	//Disable error generation
        public const UInt32 ERRCTRL1553_ON = 0x00000001;	//Enable error generation
        public const UInt32 ERRCTRL1553_ONCE = 0x00000002;	//Enable error generation once
        public const UInt32 ERRCTRL1553_EXTERNAL = 0x00000003;	//Enable externally triggered error generation
        public const UInt32 ERRCTRL1553_TAGMSG = 0x00000000;	//Generate errors on tagged messages
        public const UInt32 ERRCTRL1553_ANYMSG = 0x80000000;	//Generate errors on any message

        /**
        *
        *  Message configuration options
        *
        **/

        public const UInt32 MSGCRT1553_DEFAULT = 0x00000000;	//Default settings
        public const UInt32 MSGCRT1553_ENABLE = 0x00000000;	//Enable subaddress (RT) (default)
        public const UInt32 MSGCRT1553_DISABLE = 0x00001000;	//Disable subaddress (RT)
        public const UInt32 MSGCRT1553_RESP = 0x00000000;	//Enable response (RT) (default)
        public const UInt32 MSGCRT1553_NORESP = 0x00002000;	//Disable response (RT)
        public const UInt32 MSGCRT1553_NOWRAP = 0x00000000;	//Disable data wrap (RT) (default)
        public const UInt32 MSGCRT1553_WRAP = 0x00004000;	//Enable data wrap (RT)
        public const UInt32 MSGCRT1553_NOLOG = 0x00000000;	//Message will not generate event log (default)
        public const UInt32 MSGCRT1553_LOG = 0x00000001;	//Message will generate event log
        public const UInt32 MSGCRT1553_NOERR = 0x00000000;	//No message error will be generated for message (default)
        public const UInt32 MSGCRT1553_ERR = 0x00000002;	//A message error will be generated for message
        public const UInt32 MSGCRT1553_BUSA = 0x00000000;	//Message will be transmitted on bus A (BC) (default)
        public const UInt32 MSGCRT1553_BUSB = 0x00000004;	//Message will be transmitted on bus B (BC)
        public const UInt32 MSGCRT1553_BCRT = 0x00000000;	//Message is a BC-RT transfer (BC) (default)
        public const UInt32 MSGCRT1553_RTRT = 0x00000008;	//Message is an RT-RT transfer (BC)
        public const UInt32 MSGCRT1553_NOMON = 0x00000000;	//Message will not be monitored (default)
        public const UInt32 MSGCRT1553_MON = 0x00000010;	//Message will be monitored
        public const UInt32 MSGCRT1553_NOTIMETAG = 0x00000000;	//Message will not record time-tag (default)
        public const UInt32 MSGCRT1553_TIMETAG = 0x00000040;	//Message will record time-tag
        public const UInt32 MSGCRT1553_NOELAPSE = 0x00000000;	//Message will not record elapse time (default)
        public const UInt32 MSGCRT1553_ELAPSE = 0x00000080;	//Message will record elapse time
        public const UInt32 MSGCRT1553_NOMIN = 0x00000000;	//Message will not record min time (default)
        public const UInt32 MSGCRT1553_MIN = 0x00000100;	//Message will record min time
        public const UInt32 MSGCRT1553_NOMAX = 0x00000000;	//Message will not record max time (default)
        public const UInt32 MSGCRT1553_MAX = 0x00000200;	//Message will record max time
        public const UInt32 MSGCRT1553_NOHIT = 0x00000000;	//Message will not record hit count (default)
        public const UInt32 MSGCRT1553_HIT = 0x00000400;	//Message will record hit count
        public const UInt32 MSGCRT1553_NOSYNC = 0x00000000;	//No sync will be generated for message (default)
        public const UInt32 MSGCRT1553_SYNC = 0x40000000;	//Sync will be generated for message
        public const UInt32 MSGCRT1553_WIPE = 0x00000000;	//Enables message clear (default)
        public const UInt32 MSGCRT1553_NOWIPE = 0x80000000;	//Disables message clear
        public const UInt32 MSGCRT1553_WIPE0 = 0x00000000;	//Initialize data with zeros (default)
        public const UInt32 MSGCRT1553_WIPE123 = 0x01000000;	//Initialize data with incrementing values
        public const UInt32 MSGCRT1553_WIPECWD = 0x02000000;	//Initialize data with command word

        /**
        *
        *  List buffer options
        *
        **/

        public const UInt32 LISTCRT1553_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 LISTCRT1553_PINGPONG = 0x00000000;	//Enable ping-pong mode (default)
        public const UInt32 LISTCRT1553_FIFO = 0x00000001;	//Enable FIFO mode
        public const UInt32 LISTCRT1553_CIRCULAR = 0x00000002;	//Enable circular mode
        public const UInt32 LISTCRT1553_TRBIT = 0x00000000;	//User will read or write depending upon T/R bit
        public const UInt32 LISTCRT1553_READ = 0x00000010;	//User will read from list buffer
        public const UInt32 LISTCRT1553_WRITE = 0x00000020;	//User will write to list buffer
        public const UInt32 LISTCRT1553_NOTSKIP = 0x00000000;	//Will not skip messages
        public const UInt32 LISTCRT1553_SKIP = 0x00000040;	//Enable message skipping
        public const UInt32 LISTCRT1553_ASYNC = 0x00000080;	//Asynchronous mode
        public const UInt32 LISTCRT1553_NOLOG = 0x00000000;	//Do not generate event log when list buffer empty/full (default)
        public const UInt32 LISTCRT1553_LOG = 0x00000100;	//Generate event log when list buffer empty/full
        public const UInt32 LISTCRT1553_NOHIT = 0x00000000;	//Do not generate event log when list is hit (default)
        public const UInt32 LISTCRT1553_HIT = 0x00000200;	//Generate event log when list is hit
        public const UInt32 LISTCRT1553_NOLOGHALF = 0x00000000;	//Do not generate event log on middle and last entries (default)
        public const UInt32 LISTCRT1553_LOGHALF = 0x00000400;	//Generate event log on middle and last entries

        /**
        *
        *  Condition flags.
        *
        **/

        public const UInt32 COND1553_ALWAYS = 0x00000000;	//Unconditional
        public const UInt32 COND1553_FAIL = 0x00000001;	//Condition when all retries have failed
        public const UInt32 COND1553_SRQ = 0x00000002;	//Condition on Service Request bit set in status word
        public const UInt32 COND1553_INS = 0x00000004;	//Condition on Instrumentation bit set in status word
        public const UInt32 COND1553_SSF = 0x00000008;	//Condition on Subsystem Fail bit set in status word
        public const UInt32 COND1553_TF = 0x00000010;	//Condition on Terminal Flag bit set in status word
        public const UInt32 COND1553_BUSY = 0x00000020;	//Condition on Busy bit set in status word
        public const UInt32 COND1553_ME = 0x00000040;	//Condition on Message Error bit set in status word
        public const UInt32 COND1553_RESPERR = 0x00000080;	//Condition on response error
        public const UInt32 COND1553_NORESP = 0x00000100;	//Condition on no response error
        public const UInt32 COND1553_ALTBUS = 0x00000200;	//Retries are performed on alternate bus
        public const UInt32 COND1553_DIO1ACT = 0x00001000;	//Condition on digital I/O #1 active
        public const UInt32 COND1553_DIO1NACT = 0x00002000;	//Condition on digital I/O #1 not active
        public const UInt32 COND1553_DIO2ACT = 0x00004000;	//Condition on digital I/O #2 active
        public const UInt32 COND1553_DIO2NACT = 0x00008000;	//Condition on digital I/O #2 not active
        public const UInt32 COND1553_DIO3ACT = 0x00010000;	//Condition on digital I/O #3 active
        public const UInt32 COND1553_DIO3NACT = 0x00020000;	//Condition on digital I/O #3 not active
        public const UInt32 COND1553_DIO4ACT = 0x00040000;	//Condition on digital I/O #4 active
        public const UInt32 COND1553_DIO4NACT = 0x00080000;	//Condition on digital I/O #4 not active

        /**
        *
        *  Bit fields of the status word
        *
        **/

        public const UInt32 SWD1553_TAMASK = 0xF800;	//Masks off RT address in the SWD
        public const UInt32 SWD1553_ME = 0x0400;	//Message error bit
        public const UInt32 SWD1553_INST = 0x0200;	//Instrumentation bit
        public const UInt32 SWD1553_SRQ = 0x0100;	//Service request bit
        public const UInt32 SWD1553_BCAST = 0x0010;	//Broadcast received bit
        public const UInt32 SWD1553_BUSY = 0x0008;	//Busy bit
        public const UInt32 SWD1553_SSF = 0x0004;	//Subsystem flag bit
        public const UInt32 SWD1553_DBC = 0x0002;	//Dynamic bus control acceptance bit
        public const UInt32 SWD1553_TF = 0x0001;	//Terminal flag bit

        /**
        *
        *  Bit fields of the message error flag
        *
        **/

        public const UInt32 MSGERR1553_NORESP = 0x8000;	//Set when we timeout waiting for response
        public const UInt32 MSGERR1553_ANYERR = 0x4000;	//Set when any error bit is set
        public const UInt32 MSGERR1553_PROTOCOL = 0x2000;	//General protocol error
        public const UInt32 MSGERR1553_SYNC = 0x1000;	//Set when we have the wrong sync
        public const UInt32 MSGERR1553_DATACOUNT = 0x0800;	//Set when improper number of data words
        public const UInt32 MSGERR1553_MANCH = 0x0020;	//Set when manchester error detected
        public const UInt32 MSGERR1553_PARITY = 0x0010;	//Set when parity error detected
        public const UInt32 MSGERR1553_WORD = 0x0008;	//Set when word error detected
        public const UInt32 MSGERR1553_RETRY = 0x0004;	//All retries failed
        public const UInt32 MSGERR1553_SYSTEM = 0x0002;	//An internal system error occurred
        public const UInt32 MSGERR1553_HIT = 0x0001;	//Always set

        /**
        *
        *  Bit fields of the message activity flag.
        *
        **/

        public const UInt32 MSGACT1553_CHMASK = 0xF000;	//Channel number mask value
        public const UInt32 MSGACT1553_CHSHIFT = 0x000C;	//Channel number shift value
        public const UInt32 MSGACT1553_XMTCWD1 = 0x0800;	//Transmitted CWD1
        public const UInt32 MSGACT1553_XMTCWD2 = 0x0400;	//Transmitted CWD2
        public const UInt32 MSGACT1553_XMTSWD1 = 0x0200;	//Transmitted SWD1
        public const UInt32 MSGACT1553_XMTSWD2 = 0x0100;	//Transmitted SWD2
        public const UInt32 MSGACT1553_RCVCWD1 = 0x0080;	//Received CWD1
        public const UInt32 MSGACT1553_RCVCWD2 = 0x0040;	//Received CWD2
        public const UInt32 MSGACT1553_RCVSWD1 = 0x0020;	//Received SWD1
        public const UInt32 MSGACT1553_RCVSWD2 = 0x0010;	//Received SWD2
        public const UInt32 MSGACT1553_XMTDWD = 0x0008;	//Transmitted DWD
        public const UInt32 MSGACT1553_RCVDWD = 0x0004;	//Received DWD
        public const UInt32 MSGACT1553_BUS = 0x0001;	//Bus A/B bit

        /**
        *
        *  Field types.
        *
        **/

        public const UInt32 FIELD1553_CWD1 = 0x0000;	//CWD1 field
        public const UInt32 FIELD1553_CWD2 = 0x0001;	//CWD2 field
        public const UInt32 FIELD1553_SWD1 = 0x0002;	//SWD1 field
        public const UInt32 FIELD1553_SWD2 = 0x0003;	//SWD2 field
        public const UInt32 FIELD1553_TTAG = 0x0004;	//Time tag field
        public const UInt32 FIELD1553_ELAPSE = 0x0005;	//Elapse time field
        public const UInt32 FIELD1553_ERROR = 0x0006;	//Error field
        public const UInt32 FIELD1553_ACT = 0x0007;	//Activity field
        public const UInt32 FIELD1553_RESP1 = 0x0008;	//Response time 1 field
        public const UInt32 FIELD1553_RESP2 = 0x0009;	//Response time 2 field
        public const UInt32 FIELD1553_COUNT = 0x000A;	//Data count field
        public const UInt32 FIELD1553_FLAG1 = 0x000B;	//Flag 1 field
        public const UInt32 FIELD1553_FLAG2 = 0x000C;	//Flag 2 field
        public const UInt32 FIELD1553_EXTFLAG = 0x000D;	//External flag field
        public const UInt32 FIELD1553_TTAGH = 0x000E;	//Extended time tag field

        /**
        *
        *  Channel info fields.
        *
        **/

        public const UInt32 INFO1553_MODEL = 0x0001;	//Channel model type
        public const UInt32 INFO1553_MAXCOUNT = 0x0002;	//Channel terminal count
        public const UInt32 INFO1553_MULTIMODE = 0x0003;	//Channel supports multi-mode
        public const UInt32 INFO1553_ERRORGEN = 0x0004;	//Channel supports error generation
        public const UInt32 INFO1553_CONCURMON = 0x0005;	//Channel supports concurrent monitor
        public const UInt32 INFO1553_MONFILTER = 0x0006;	//Channel supports filtering of monitor
        public const UInt32 INFO1553_PARAM = 0x0007;	//Channel supports parametric control
        public const UInt32 INFO1553_RTRESPTIME = 0x0008;	//Channel supports programmable RT response time
        public const UInt32 INFO1553_PLAYBACK = 0x0009;	//Channel supports hardware playback mode
        public const UInt32 INFO1553_VER2CHOBJ = 0x000A;	//Channel supports version 2 channel object
        public const UInt32 INFO1553_BCDFLTGAP = 0x000B;	//Channel supports programmable default gap time

        /**
        *
        *  Parametric configuration options
        *
        **/

        public const UInt32 PARAMCFG1553_DEFAULT = 0x00000000;	//Select all default settings (default)
        public const UInt32 PARAMCFG1553_AMPLON = 0x00000000;	//Enables parametric amplitude control (default)
        public const UInt32 PARAMCFG1553_AMPLOFF = 0x00000001;	//Disables parametric amplitude control

        /**
        *
        *  Other flags.
        *
        **/

        public const UInt32 SUBADDRESS = 0x0000;	//Selects Subaddress messages
        public const UInt32 MODECODE = 0x0001;	//Selects Modecode messages

    }	//end class
}	//end namespace
