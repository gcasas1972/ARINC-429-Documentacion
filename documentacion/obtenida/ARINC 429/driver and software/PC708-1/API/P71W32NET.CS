using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class P71W32
    {
        /**
        *
        *  PC708-1 WIN32 DRIVER  Version 1.3  (07/14/2000)
        *  Copyright (c) 1998-2000
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   P71W32NET.CS -- 32-bit
        *                      PC708-1 Driver Include Header File.
        *
        **/

        /**
        *
        *  PC708-1 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the PC708-1 Driver.
        *
        **/

        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardClose(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardOpen@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_CardOpen(UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CardReset(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardStart(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardStop(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_IntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_IntRd(ref UInt16 typevalval, ref UInt16 infoval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_IntStatus(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_IntUninstall(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvConfig@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_RcvConfig(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_RcvConfigEx(UInt32 rtconfigval, UInt16 intfreq, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvMonBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_RcvMonBlkRd(ref UInt16 buf, UInt32 bufcount, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvMonBlkRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_RcvMonBlkRdEx(ref UInt16 buf, UInt32 bufcount, UInt32 maxblkcnt, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvMonRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_RcvMonRd(ref UInt16 buf, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvMonRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_RcvMonRdEx(ref UInt16 buf, UInt16 index, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvMonStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_RcvMonStatus(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RcvRd(ref UInt16 buf, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtConfig(UInt16 framefreq, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtConfigEx(UInt16 framefreq, UInt16 intfreq, UInt16 framecount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtConfigExx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtConfigExx(UInt32 xmtconfigval, UInt16 framefreq, UInt16 intfreq, UInt16 framecount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_XmtRd(ref UInt16 buf, UInt16 framenum, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtStatus(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_XmtWr(ref UInt16 buf, UInt16 framenum, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetAngle@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldGetAngle(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetAngleFl@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Single PC708_FieldGetAngleFl(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetControlAccept@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldGetControlAccept(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetData@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldGetData(Int32 binnum, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetDataAccept@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldGetDataAccept(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetFaults@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldGetFaults(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetGain@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_FieldGetGain(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetLabel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldGetLabel(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetMode@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldGetMode(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetRange@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_FieldGetRange(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetTilt@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldGetTilt(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldGetTiltFl@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Single PC708_FieldGetTiltFl(ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutAngle@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldPutAngle(UInt16 value, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutAngleFl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Single PC708_FieldPutAngleFl(Single angle, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutControlAccept@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldPutControlAccept(UInt16 value, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldPutData(UInt16 value, Int32 binnum, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutDataAccept@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldPutDataAccept(UInt16 value, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutFaults@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldPutFaults(UInt16 value, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutGain@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_FieldPutGain(Int32 gain, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutLabel@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldPutLabel(UInt16 value, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutMode@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldPutMode(UInt16 value, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutRange@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_FieldPutRange(Int32 range, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutTilt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_FieldPutTilt(UInt16 value, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FieldPutTiltFl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Single PC708_FieldPutTiltFl(Single tilt, ref UInt16 buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_AddrDSP@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_AddrDSP(UInt32 addr);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_AddrHost@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_AddrHost(UInt32 addr);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCConfig(UInt32 configval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCConfigEx(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCConfigMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_BCConfigMsg(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCCreateMsg@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_BCCreateMsg(UInt32 configval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedAgain@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedAgain(Int32 index, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedBranch@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedBranch(UInt16 condition, Int32 destindex, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedBranchDin0@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedBranchDin0(Int32 destindex, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedBranchDin1@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedBranchDin1(Int32 destindex, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedBranchEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedBranchEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, Int32 destindex, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedBuild@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedBuild(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedCall(Int32 destindex, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedCallCond@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedCallCond(UInt16 condition, Int32 destindex, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedCallCondEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedCallCondEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, Int32 destindex, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedEntry@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedEntry(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedFrame@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedFrame(UInt32 timeval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedFrameEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedFrameEnd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedFrameStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedFrameStart(UInt32 timeval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedGap@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedGap(UInt16 gapval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedGoto@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedGoto(Int32 destindex, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedHalt@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedHalt(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedInt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedInt(UInt16 tagval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedIntCond@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedIntCond(UInt16 condition, UInt16 tagval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedIntCondEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedIntCondEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 tagval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedMsg@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedMsg(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedNop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedNop(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedPause@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedPause(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedPulse@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedPulse(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedPulse0@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedPulse0(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedPulse1@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedPulse1(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedRestart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedRestart(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedRetry@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedRetry(UInt16 condition, UInt16 retries, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedRetryEx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedRetryEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 retryflag, UInt16 retries, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedReturn@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedReturn(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSchedUser@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSchedUser(UInt32 useraddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSetEntry@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSetEntry(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BCSetTimeout@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BCSetTimeout(UInt16 timeoutval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_BlkAddr(Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_BlkOptRd(Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BlkOptWr(UInt16 rtopt, Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkPtrRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_BlkPtrRd(Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkPtrWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_BlkPtrWr(UInt32 descaddr, Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BlkRd(ref UInt16 block, Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BlkReset(Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkSWDRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_BlkSWDRd(Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkSWDWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BlkSWDWr(UInt16 swdval, Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BlkWipe(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_BlkWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_BlkWr(ref UInt16 block, Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardBoot@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardBoot(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardCloseAll@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardCloseAll();
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardConfig(Int32 enableflag, UInt16 command, UInt16 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardGetInfo@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_CardGetInfo(UInt16 infotype, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardGetInfoEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardGetInfoEx(ref UInt16 bufmodel, UInt16 bufmodelcount, ref UInt16 buffeature, UInt16 buffeaturecount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardInit@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CardInit();
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardIsRunning(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardNop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardNop(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardOpenEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_CardOpenEx(ref string cardname, UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardOpenExx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_CardOpenExx(ref string cardname, UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardResetEx@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CardResetEx(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardResume(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardTest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardTest(UInt16 level, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardTest0@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardTest0(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardTest1@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardTest1(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardTest2@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CardTest2(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CardTrigger@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CardTrigger(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_CmdAddr(Int32 index, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_CmdAlloc(UInt16 count, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdBaseRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_CmdBaseRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdBaseWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CmdBaseWr(UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CmdClear(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_CmdCountRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CmdCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdCtrlRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_CmdCtrlRd(Int32 index, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdCtrlWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CmdCtrlWr(UInt16 ctrlval, Int32 index, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdCurrRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_CmdCurrRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdCurrWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CmdCurrWr(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CmdInit(UInt16 opcode, ref UInt16 block);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdInsert@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CmdInsert(ref UInt16 block, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdMaxRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_CmdMaxRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdMaxWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CmdMaxWr(UInt16 count, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdSkipWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CmdSkipWr(Int32 value, Int32 index, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdStackClr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CmdStackClr(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdStartRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_CmdStartRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdStartWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CmdStartWr(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdTotalRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CmdTotalRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdTotalWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CmdTotalWr(Int32 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CmdWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CommCall(UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommCheck@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CommCheck(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommDisable@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CommDisable(UInt16 command, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CommEnable(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_CommRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CommRdsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_CommRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommRun@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CommRun(ref UInt16 dataptr, UInt16 datacount, ref UInt16 codeptr, UInt16 codecount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CommWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_CommWrsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_CommWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_CommWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DARClr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_DARClr(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DARGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_DARGet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DARRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_DARRdL(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DARRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_DARRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DARSet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_DARSet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DARWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_DARWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DARWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_DARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_Div@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_Div(UInt32 diva, UInt32 divb);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_DllUsageCount();
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DspBioRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_DspBioRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DspIntfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_DspIntfClear(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DspIntfRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_DspIntfRead(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DspIntmClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_DspIntmClear(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DspIntmSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_DspIntmSet(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DspXfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_DspXfClear(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_DspXfSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_DspXfSet(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ErrDesc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _PC708_ErrDesc(Int32 errval);
        public static string PC708_ErrDesc(Int32 errval) { return Marshal.PtrToStringAnsi(_PC708_ErrDesc(errval)); }
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ErrDescStr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _PC708_ErrDescStr(Int32 errval);
        public static string PC708_ErrDescStr(Int32 errval) { return Marshal.PtrToStringAnsi(_PC708_ErrDescStr(errval)); }
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ErrName@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _PC708_ErrName(Int32 errval);
        public static string PC708_ErrName(Int32 errval) { return Marshal.PtrToStringAnsi(_PC708_ErrName(errval)); }
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ErrorDefine@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ErrorDefine(Int32 busb, UInt16 intfreq, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ExtDinRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ExtDinRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ExtDinWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_ExtDinWr(Int32 dinval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ExtDoutRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ExtDoutRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ExtDoutWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_ExtDoutWr(Int32 doutval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FileClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_FileClose(IntPtr handle);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FileErr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_FileErr();
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FileErrClr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_FileErrClr();
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FileErrSet@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_FileErrSet();
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FileOpenRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* PC708_FileOpenRead(ref string filename);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FileOpenWrite@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* PC708_FileOpenWrite(ref string filename);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FileRead@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_FileRead(IntPtr handle, IntPtr buffer, UInt16 count);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FileSeek@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_FileSeek(IntPtr handle, UInt32 offset);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FileTell@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_FileTell(IntPtr handle);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_FileWrite@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_FileWrite(IntPtr handle, IntPtr buffer, UInt16 count);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_GetHigh@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_GetHigh(UInt32 val);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_GetLow@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_GetLow(UInt32 val);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_GlobalRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_GlobalRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_GlobalWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_GlobalWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_HandleDel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_HandleDel(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_HandleGet@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_HandleGet(ref UInt32 memval, ref UInt32 sizval, ref UInt32 ioval, ref UInt16 irqval, ref UInt16 drqval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_HandleGetIo@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_HandleGetIo(UInt16 ioval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_HandleGetMem@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_HandleGetMem(UInt32 memval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_HandleIns@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_HandleIns(ref string cardname, UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_HandleOkay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_HandleOkay(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_HeapAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_HeapAlloc(UInt32 wordcount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_HeapAllocAll@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_HeapAllocAll(ref UInt32 wordcount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_HeapAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_HeapAllocEx(UInt16 configval, UInt32 wordcount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_HeapWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_HeapWipe(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IndirectRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_IndirectRd(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IndirectWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_IndirectWr(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_IntClear(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_IntConfig(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntDisable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_IntDisable(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_IntEnable(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntEnableCond@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_IntEnableCond(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntGet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* PC708_IntGet(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IntReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_IntReset(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IORdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_IORdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IOWINRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_IOWINRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IOWINWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_IOWINWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_IOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_IOWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernBegin@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        unsafe public static extern Int32 PC708_KernBegin(IntPtr* vxdptr, ref string cardname, UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernDev@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernDev(ref UInt32 valueptr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernEnd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernIntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernIntClear(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernIntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernIntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernIntStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernIntStatus(ref Int32 valueptr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernIntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernIntUninstall(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernIORdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernIORdW(ref UInt16 valueptr, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernIOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernIOWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernMEMFillW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernMEMFillW(UInt16 value, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernMEMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernMEMRdsW(ref UInt16 bufptr, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernMEMRdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernMEMRdW(ref UInt16 valueptr, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernMEMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernMEMWrsW(ref UInt16 bufptr, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernMEMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernMEMWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_KernStatus@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_KernStatus(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ListConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_ListConfig(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MakeLong@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MakeLong(UInt16 valh, UInt16 vall);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_Mask@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_Mask(UInt32 dataval, UInt16 cntval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MEMWINRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MEMWINRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MEMWINRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MEMWINRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MEMWINRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MEMWINRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MEMWINWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_MEMWINWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MEMWINWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_MEMWINWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MEMWINWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_MEMWINWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_Mod@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_Mod(UInt32 moda, UInt32 modb);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ModeIsBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ModeIsBC(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ModeIsMon@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ModeIsMon(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ModeIsNotBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ModeIsNotBC(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ModeIsNotMon@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ModeIsNotMon(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ModeIsNotRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ModeIsNotRT(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ModeIsNotSerial@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ModeIsNotSerial(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ModeIsRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ModeIsRT(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ModeIsSerial@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ModeIsSerial(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ModeRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_ModeRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ModeWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_ModeWr(UInt16 mode, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MonBlkRd(ref UInt16 buf, UInt32 bufcount, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonBlkRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MonBlkRdEx(ref UInt16 buf, UInt32 bufcount, UInt32 maxblkcnt, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_MonClear(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_MonConfig(UInt32 configval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_MonConfigEx(UInt32 configval, UInt32 moncount, UInt16 cardnum, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonConfigExx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_MonConfigExx(UInt32 configval, UInt32 seqaddr, UInt32 moncount, UInt16 cardnum, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_MonIsRunning(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MonRd(ref UInt16 buf, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MonRdEx(ref UInt16 buf, UInt16 bufcount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_MonResume(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_MonStart(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_MonStatus(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MonStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_MonStop(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MsgBlockRd(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MsgBlockWr(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MsgCheck(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgCommRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MsgCommRd(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgCommWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MsgCommWr(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MsgConfig(UInt32 configval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MsgConfigEx(UInt32 configval, UInt16 cwd, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgCWD1Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MsgCWD1Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgCWD1Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_MsgCWD1Wr(UInt16 cwd1, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgCWD2Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MsgCWD2Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgCWD2Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_MsgCWD2Wr(UInt16 cwd2, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_MsgDataRd(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_MsgDataWr(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgErrorRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MsgErrorRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgErrorWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_MsgErrorWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgFieldRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MsgFieldRd(UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgFieldWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MsgFieldWr(UInt32 fieldval, UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgFlagRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MsgFlagRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgFlagWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_MsgFlagWr(UInt16 msgflag, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgIsAccessed@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_MsgReset(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgSWD1Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MsgSWD1Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_MsgSWD2Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_MsgSWD2Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_Mul@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_Mul(UInt32 mula, UInt32 mulb);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_PortRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_PortRd(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_PortWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_PortWr(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ProgRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_ProgRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ProgWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_ProgWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMFill@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RAMFill(UInt16 value, UInt32 addrval, UInt32 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_RAMRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_RAMRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RAMRdsW(ref UInt16 valueptr, UInt32 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMRdsxW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RAMRdsxW(ref UInt16 valueptr, UInt32 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_RAMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RAMWipe(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMWipeEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RAMWipeEx(UInt16 value, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RAMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RAMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RAMWrsW(ref UInt16 valueptr, UInt32 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMWrsxW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RAMWrsxW(ref UInt16 valueptr, UInt32 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RAMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RAMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_RcvAlloc(UInt16 framenum, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvConfigExx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_RcvConfigExx(UInt32 rtconfigval, UInt16 intfreq, UInt32 monconfigval, UInt32 intconfigval, UInt16 inttotal, UInt32 msgconfigval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_RcvCountRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RcvCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvDataCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_RcvDataCountRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvDataCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_RcvDataCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RcvIndex@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_RcvIndex(UInt16 framenum, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RTConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_RTConfig(UInt32 configval, Int32 taval, UInt16 intfreq, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RTConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_RTConfigEx(UInt32 configval, Int32 taval, UInt16 intfreq, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RTConfigExx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_RTConfigExx(UInt32 configval, Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RTConfigMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_RTConfigMsg(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RTReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_RTReset(Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RTStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_RTStatus(Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RTSWDRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_RTSWDRd(Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_RTSWDWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_RTSWDWr(UInt16 swdval, Int32 taval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SARRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_SARRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SARWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_SARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SchedBuild@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_SchedBuild(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SchedBuildEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_SchedBuildEx(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, ref UInt16 period, IntPtr buf, UInt16 bufsize, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SchedBuildExx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_SchedBuildExx(UInt32 frametime, UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 period, IntPtr buf, UInt16 bufsize, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SchedCalc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_SchedCalc(ref UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SchedInsEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_SchedInsEnd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SchedInsMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_SchedInsMsg(UInt16 index, ref UInt32 msgaddr, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SchedInsStart@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_SchedInsStart(UInt32 frametime, UInt16 count, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SchedMaxval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_SchedMaxval(ref UInt16 arrayval, UInt16 arrayvalcount);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_SchedMinval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_SchedMinval(ref UInt16 arrayval, UInt16 arrayvalcount);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_Shl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_Shl(UInt32 dataval, UInt16 cntval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_Shr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_Shr(UInt32 dataval, UInt16 cntval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_TimerClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_TimerClear(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_TimerRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_TimerRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_TimerResolution@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_TimerResolution(Int32 timerresol, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_TimerResolutionEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_TimerResolutionEx(UInt16 timershift, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValAsciiCmpi@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ValAsciiCmpi(ref string str1, ref string str2);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValAsciiCpy@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _PC708_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count);
        public static string PC708_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count) { return Marshal.PtrToStringAnsi(_PC708_ValAsciiCpy(ref strdest, ref strsrc, count)); }
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValAsciiTrimLead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_ValAsciiTrimLead(ref string buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValAsciiTrimTrail@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_ValAsciiTrimTrail(ref string buf);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValFromAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_ValFromAscii(ref string asciistr, Int32 radixval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValGetBits@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_ValGetBits(UInt16 oldvalue, Int32 startbit, Int32 endbit);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValIncAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _PC708_ValIncAscii(ref string asciistr);
        public static string PC708_ValIncAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_PC708_ValIncAscii(ref asciistr)); }
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValInccAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _PC708_ValInccAscii(ref string asciistr);
        public static string PC708_ValInccAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_PC708_ValInccAscii(ref asciistr)); }
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValIsLower@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ValIsLower(Int32 value);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValLenAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ValLenAscii(Int32 numbits, Int32 radixval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValPackCWD@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_ValPackCWD(Int32 taval, Int32 trflag, Int32 saval, Int32 wcval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValPackRTCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_ValPackRTCWD(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 count);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValPutBits@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_ValPutBits(UInt16 oldvalue, UInt16 newfld, Int32 startbit, Int32 endbit);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValToAscii@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _PC708_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval);
        public static string PC708_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval) { return Marshal.PtrToStringAnsi(_PC708_ValToAscii(value, ref asciistr, numbits, radixval)); }
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValToUpper@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_ValToUpper(Int32 value);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValUnpackCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_ValUnpackCWD(UInt16 cwdval, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 wcval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_ValUnpackRTCWD@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_ValUnpackRTCWD(UInt16 cwd, ref Int32 bcastflag, ref Int32 mcflag, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 count);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtAlloc(UInt16 framecount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtConfigExxx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtConfigExxx(UInt32 bcconfigval, UInt32 msgconfigval, UInt16 framefreq, UInt16 intfreq, UInt16 framecount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_XmtCountRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_XmtCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtDataCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_XmtDataCountRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtDataCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_XmtDataCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtFreq@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtFreq(UInt16 framefreq, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtFreqEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtFreqEx(UInt16 framefreq, UInt16 intfreq, UInt16 framecount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtFreqExx@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtFreqExx(UInt16 framefreq, UInt16 intfreq, UInt16 framecount, UInt32 bcconfigval, UInt16 bctotal, UInt32 intconfigval, UInt16 inttotal, UInt32 msgconfigval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtIndex@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 PC708_XmtIndex(UInt16 framenum, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtNumberRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC708_XmtNumberRd(UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtNumberWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_XmtNumberWr(UInt16 brdnum, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtPeriod@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtPeriod(UInt32 frameperiod, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtPeriodEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtPeriodEx(UInt32 frameperiod, UInt16 intfreq, UInt16 framecount, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtPeriodExx@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC708_XmtPeriodExx(UInt32 frameperiod, UInt16 intfreq, UInt16 framecount, UInt32 bcconfigval, UInt16 bctotal, UInt32 intconfigval, UInt16 inttotal, UInt32 msgconfigval, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_XmtRd(ref UInt16 buf, UInt16 framenum, UInt32 handleval);
        [DllImport("P71W32.DLL", EntryPoint = "_PC708_XmtSizeWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC708_XmtSizeWr(UInt16 mode, UInt32 handleval);

        /**
        *
        *  Transmitter configuration options
        *
        **/

        public const UInt32 XMTCFG_DEFAULT = 0x00000000;
        public const UInt32 XMTCFG_BUSA = 0x00000000;
        public const UInt32 XMTCFG_BUSB = 0x00000004;
        public const UInt32 XMTCFG_NOSWAP = 0x00000000;
        public const UInt32 XMTCFG_SWAP = 0x00004000;

        /**
        *
        *  Receiver configuration options
        *
        **/

        public const UInt32 RCVCFG_DEFAULT = 0x00000000;
        public const UInt32 RCVCFG_BUSA = 0x00000000;
        public const UInt32 RCVCFG_BUSB = 0x00010000;
        public const UInt32 RCVCFG_NOSWAP = 0x00000000;
        public const UInt32 RCVCFG_SWAP = 0x00008000;
        public const UInt32 RCVCFG_WORDSYNC = 0x00000000;
        public const UInt32 RCVCFG_BITSYNC = 0x00080000;

        /**
        *
        *  Bus controller configuration options
        *
        **/

        public const UInt32 BCCFG_DEFAULT = 0x00000000;
        public const UInt32 BCCFG_ENABLE = 0x00000000;
        public const UInt32 BCCFG_DISABLE = 0x00000001;
        public const UInt32 BCCFG_TRIGNONE = 0x00000000;
        public const UInt32 BCCFG_TRIGEXT = 0x00000010;
        public const UInt32 BCCFG_TRIGSTART = 0x00000020;
        public const UInt32 BCCFG_NOINTHALT = 0x00000000;
        public const UInt32 BCCFG_INTHALT = 0x00000100;
        public const UInt32 BCCFG_NOINTPAUSE = 0x00000000;
        public const UInt32 BCCFG_INTPAUSE = 0x00000200;
        public const UInt32 BCCFG_NOLOOPMAX = 0x00000000;
        public const UInt32 BCCFG_LOOPMAX = 0x00001000;
        public const UInt32 BCCFG_NOSTEP = 0x00000000;
        public const UInt32 BCCFG_STEP = 0x00002000;
        public const UInt32 BCCFG_NOSWAP = 0x00000000;
        public const UInt32 BCCFG_SWAP = 0x00004000;
        public const UInt32 BCCFG_MC01 = 0x00000000;
        public const UInt32 BCCFG_MC1 = 0x01000000;
        public const UInt32 BCCFG_MC0 = 0x02000000;
        public const UInt32 BCCFG_MCNONE = 0x03000000;
        public const UInt32 BCCFG_SYNCALL = 0x00000000;
        public const UInt32 BCCFG_SYNCSEL = 0x40000000;

        /**
        *
        *  Monitor configuration options
        *
        **/

        public const UInt32 MONCFG_DEFAULT = 0x00000000;
        public const UInt32 MONCFG_FILLHALT = 0x00000000;
        public const UInt32 MONCFG_DISABLE = 0x00000001;
        public const UInt32 MONCFG_CONTINUOUS = 0x00000002;
        public const UInt32 MONCFG_DMA = 0x00000004;
        public const UInt32 MONCFG_FREE = 0x00000008;
        public const UInt32 MONCFG_FAST = 0x00000010;
        public const UInt32 MONCFG_DELTA = 0x00000020;
        public const UInt32 MONCFG_NOINTFULL = 0x00000000;
        public const UInt32 MONCFG_INTFULL = 0x00001000;
        public const UInt32 MONCFG_COMPLETE = 0x00000000;
        public const UInt32 MONCFG_INCOMPLETE = 0x00002000;
        public const UInt32 MONCFG_MC01 = 0x00000000;
        public const UInt32 MONCFG_MC1 = 0x00100000;
        public const UInt32 MONCFG_MC0 = 0x00200000;
        public const UInt32 MONCFG_MCNONE = 0x00300000;
        public const UInt32 MONCFG_16K = 0x00000000;
        public const UInt32 MONCFG_ALLAVAIL = 0x01000000;
        public const UInt32 MONCFG_32K = 0x02000000;
        public const UInt32 MONCFG_64K = 0x04000000;
        public const UInt32 MONCFG_128K = 0x08000000;

        /**
        *
        *  Remote terminal configuration options
        *
        **/

        public const UInt32 RTCFG_DEFAULT = 0x00000000;
        public const UInt32 RTCFG_SIMULATE = 0x00000000;
        public const UInt32 RTCFG_DISABLE = 0x00000001;
        public const UInt32 RTCFG_MONITOR = 0x00000002;
        public const UInt32 RTCFG_NOBCAST = 0x00000000;
        public const UInt32 RTCFG_BCAST = 0x00000100;
        public const UInt32 RTCFG_NOAUTOBUSY = 0x00000000;
        public const UInt32 RTCFG_AUTOBUSY = 0x00000200;
        public const UInt32 RTCFG_BUILD = 0x00000000;
        public const UInt32 RTCFG_NOBUILD = 0x00000400;
        public const UInt32 RTCFG_STDB = 0x00000000;
        public const UInt32 RTCFG_STDA = 0x00000800;
        public const UInt32 RTCFG_NODYNBC = 0x00000000;
        public const UInt32 RTCFG_DYNBC = 0x00001000;
        public const UInt32 RTCFG_NOIMMCLR = 0x00000000;
        public const UInt32 RTCFG_IMMCLR = 0x00002000;
        public const UInt32 RTCFG_NOBCASTADDR = 0x00000000;
        public const UInt32 RTCFG_BCASTADDR = 0x00004000;
        public const UInt32 RTCFG_NOSWAP = 0x00000000;
        public const UInt32 RTCFG_SWAP = 0x00008000;
        public const UInt32 RTCFG_WORDSYNC = 0x00000000;
        public const UInt32 RTCFG_BITSYNC = 0x00080000;
        public const UInt32 RTCFG_CHANAB = 0x00000000;
        public const UInt32 RTCFG_CHANA = 0x00020000;
        public const UInt32 RTCFG_CHANB = 0x00010000;
        public const UInt32 RTCFG_CHANNONE = 0x00030000;
        public const UInt32 RTCFG_MC01 = 0x00000000;
        public const UInt32 RTCFG_MC1 = 0x01000000;
        public const UInt32 RTCFG_MC0 = 0x02000000;
        public const UInt32 RTCFG_MCNONE = 0x03000000;
        public const UInt32 RTCFG_SYNCALL = 0x00000000;
        public const UInt32 RTCFG_SYNCSEL = 0x40000000;
        public const UInt32 RTCFG_WIPE = 0x00000000;
        public const UInt32 RTCFG_NOWIPE = 0x80000000;
        public const UInt32 RTCFG_WIPE0 = 0x00000000;
        public const UInt32 RTCFG_WIPE123 = 0x01000000;
        public const UInt32 RTCFG_WIPECWD = 0x02000000;

        /**
        *
        *  Serial configuration options
        *
        **/

        public const UInt32 SERCFG_DEFAULT = 0x00000000;
        public const UInt32 SERCFG_CONTINUOUS = 0x00000000;
        public const UInt32 SERCFG_DISABLE = 0x00000001;
        public const UInt32 SERCFG_FREE = 0x00000002;
        public const UInt32 SERCFG_NOINTEMPTY = 0x00000000;
        public const UInt32 SERCFG_INTEMPTY = 0x00000010;

        /**
        *
        *  Interrupt log list configuration options
        *
        **/

        public const UInt32 INTCFG_DEFAULT = 0x00000000;
        public const UInt32 INTCFG_ENABLE = 0x00000000;
        public const UInt32 INTCFG_DISABLE = 0x00000001;

        /**
        *
        *  Monitor configuration options
        *
        **/

        public const UInt32 LISTCFG_DEFAULT = 0x00000000;
        public const UInt32 LISTCFG_PINGPONG = 0x00000000;
        public const UInt32 LISTCFG_DISABLE = 0x00000001;
        public const UInt32 LISTCFG_CONTINUOUS = 0x00000002;
        public const UInt32 LISTCFG_FREE = 0x00000004;
        public const UInt32 LISTCFG_NOINT = 0x00000000;
        public const UInt32 LISTCFG_INT = 0x00000010;

        /**
        *
        *  Info types
        *
        **/

        public const UInt32 INFOTYPE_PLAT = 0x0001;		//Returns the PC708 platform type
        public const UInt32 INFOTYPE_PROD = 0x0002;		//Returns the PC708 product type
        public const UInt32 INFOTYPE_REV = 0x0003;		//Returns the PC708 revision number
        public const UInt32 INFOTYPE_VERSION = 0x0004;		//Returns the PC708 version number
        public const UInt32 INFOTYPE_DATE = 0x0005;		//Returns the PC708 version date
        public const UInt32 INFOTYPE_TRANSMIT = 0x0006;		//Returns whether the PC708 has a transmitter
        public const UInt32 INFOTYPE_RECEIVE = 0x0007;		//Returns whether the PC708 has a receiver
        public const UInt32 INFOTYPE_DASH = 0x0008;		//Returns the PC708 dash number
        public const UInt32 INFOTYPE_MODEL = 0x0009;		//Returns the PC708 model number
        public const UInt32 INFOTYPE_MAXCOUNT = 0x000A;		//Returns the number of terminals the PC1553-3 can simulate
        public const UInt32 INFOTYPE_MULTIMODE = 0x000B;		//Returns whether PC708 can simulate multi-modes
        public const UInt32 INFOTYPE_ERRORGEN = 0x000C;		//Returns whether PC708 can generate errors
        public const UInt32 INFOTYPE_CONCURMON = 0x000D;		//Returns whether PC708 has a concurrent monitor
        public const UInt32 INFOTYPE_MONFILTER = 0x000E;		//Returns whether PC708 has a monitor filter
        public const UInt32 INFOTYPE_USERCODE = 0x000F;		//Returns whether PC708 handles user code
        public const UInt32 INFOTYPE_LISTBUF = 0x0010;		//Returns whether PC708 handles list buffering
        public const UInt32 INFOTYPE_MONFAST = 0x0011;		//Returns whether PC708 has a fast monitor
        public const UInt32 INFOTYPE_MONDMA = 0x0012;		//Returns whether PC708 has a dma monitor
        public const UInt32 INFOTYPE_DUAL = 0x0013;		//Returns whether PC708 has dual xmt/rcv capability
        public const UInt32 INFOTYPE_BITSYNC = 0x0014;		//Returns whether PC708 has bit sync capability

        /**
        *
        *  Error configuration options
        *
        **/

        public const UInt32 ERRDEF_NONE = 0x00000000;
        public const UInt32 ERRDEF_GAP = 0x00010000;
        public const UInt32 ERRDEF_CNTWRDABS = 0x00020000;
        public const UInt32 ERRDEF_CNTWRDREL = 0x00040000;
        public const UInt32 ERRDEF_CNTBIT = 0x00080000;
        public const UInt32 ERRDEF_MAN1 = 0x00100000;
        public const UInt32 ERRDEF_MAN2 = 0x00200000;
        public const UInt32 ERRDEF_SYNC = 0x00400000;
        public const UInt32 ERRDEF_PAR = 0x00800000;
        public const UInt32 ERRDEF_ZEROX = 0x01000000;

        public const UInt32 ERRDEF_DWD00 = 0x0000;            //Error will be generated in a data word  0
        public const UInt32 ERRDEF_DWD01 = 0x0001;            //Error will be generated in a data word  1
        public const UInt32 ERRDEF_DWD02 = 0x0002;            //Error will be generated in a data word  2
        public const UInt32 ERRDEF_DWD03 = 0x0003;            //Error will be generated in a data word  3
        public const UInt32 ERRDEF_DWD04 = 0x0004;            //Error will be generated in a data word  4
        public const UInt32 ERRDEF_DWD05 = 0x0005;            //Error will be generated in a data word  5
        public const UInt32 ERRDEF_DWD06 = 0x0006;            //Error will be generated in a data word  6
        public const UInt32 ERRDEF_DWD07 = 0x0007;            //Error will be generated in a data word  7
        public const UInt32 ERRDEF_DWD08 = 0x0008;            //Error will be generated in a data word  8
        public const UInt32 ERRDEF_DWD09 = 0x0009;            //Error will be generated in a data word  9
        public const UInt32 ERRDEF_DWD10 = 0x000A;            //Error will be generated in a data word 10
        public const UInt32 ERRDEF_DWD11 = 0x000B;            //Error will be generated in a data word 11
        public const UInt32 ERRDEF_DWD12 = 0x000C;            //Error will be generated in a data word 12
        public const UInt32 ERRDEF_DWD13 = 0x000D;            //Error will be generated in a data word 13
        public const UInt32 ERRDEF_DWD14 = 0x000E;            //Error will be generated in a data word 14
        public const UInt32 ERRDEF_DWD15 = 0x000F;            //Error will be generated in a data word 15
        public const UInt32 ERRDEF_DWD16 = 0x0010;            //Error will be generated in a data word 16
        public const UInt32 ERRDEF_DWD17 = 0x0011;            //Error will be generated in a data word 17
        public const UInt32 ERRDEF_DWD18 = 0x0012;            //Error will be generated in a data word 18
        public const UInt32 ERRDEF_DWD19 = 0x0013;            //Error will be generated in a data word 19
        public const UInt32 ERRDEF_DWD20 = 0x0014;            //Error will be generated in a data word 20
        public const UInt32 ERRDEF_DWD21 = 0x0015;            //Error will be generated in a data word 21
        public const UInt32 ERRDEF_DWD22 = 0x0016;            //Error will be generated in a data word 22
        public const UInt32 ERRDEF_DWD23 = 0x0017;            //Error will be generated in a data word 23
        public const UInt32 ERRDEF_DWD24 = 0x0018;            //Error will be generated in a data word 24
        public const UInt32 ERRDEF_DWD25 = 0x0019;            //Error will be generated in a data word 25
        public const UInt32 ERRDEF_DWD26 = 0x001A;            //Error will be generated in a data word 26
        public const UInt32 ERRDEF_DWD27 = 0x001B;            //Error will be generated in a data word 27
        public const UInt32 ERRDEF_DWD28 = 0x001C;            //Error will be generated in a data word 28
        public const UInt32 ERRDEF_DWD29 = 0x001D;            //Error will be generated in a data word 29
        public const UInt32 ERRDEF_DWD30 = 0x001E;            //Error will be generated in a data word 30
        public const UInt32 ERRDEF_DWD31 = 0x001F;            //Error will be generated in a data word 31
        public const UInt32 ERRDEF_CWD1 = 0x0100;            //Error will be generated in CWD1
        public const UInt32 ERRDEF_CWD2 = 0x0101;            //Error will be generated in CWD2
        public const UInt32 ERRDEF_SWD = 0x0102;            //Error will be generated in SWD1
        public const UInt32 ERRDEF_SWD1 = 0x0102;            //Error will be generated in SWD1
        public const UInt32 ERRDEF_SWD2 = 0x0102;            //Error will be generated in SWD2

        /**
        *
        *  Error control options
        *
        **/

        public const UInt32 ERRCTRL_OFF = 0x00000000;
        public const UInt32 ERRCTRL_ON = 0x00000001;
        public const UInt32 ERRCTRL_ONCE = 0x00000002;
        public const UInt32 ERRCTRL_EXTERNAL = 0x00000003;
        public const UInt32 ERRCTRL_TAGMSG = 0x00000000;
        public const UInt32 ERRCTRL_ANYMSG = 0x80000000;

        /**
        *
        *  Message configuration options
        *
        **/

        public const UInt32 MSGCRT_DEFAULT = 0x00000000;
        public const UInt32 MSGCRT_ENABLE = 0x00000000;
        public const UInt32 MSGCRT_DISABLE = 0x00001000;
        public const UInt32 MSGCRT_RESP = 0x00000000;
        public const UInt32 MSGCRT_NORESP = 0x00002000;
        public const UInt32 MSGCRT_NOWRAP = 0x00000000;
        public const UInt32 MSGCRT_WRAP = 0x00004000;
        public const UInt32 MSGCRT_NOINT = 0x00000000;
        public const UInt32 MSGCRT_INT = 0x00000001;
        public const UInt32 MSGCRT_NOERR = 0x00000000;
        public const UInt32 MSGCRT_ERR = 0x00000002;
        public const UInt32 MSGCRT_BUSA = 0x00000000;
        public const UInt32 MSGCRT_BUSB = 0x00000004;
        public const UInt32 MSGCRT_BCRT = 0x00000000;
        public const UInt32 MSGCRT_RTRT = 0x00000008;
        public const UInt32 MSGCRT_NOMON = 0x00000000;
        public const UInt32 MSGCRT_MON = 0x00000010;
        public const UInt32 MSGCRT_NOTIMETAG = 0x00000000;
        public const UInt32 MSGCRT_TIMETAG = 0x00000040;
        public const UInt32 MSGCRT_NOELAPSE = 0x00000000;
        public const UInt32 MSGCRT_ELAPSE = 0x00000080;
        public const UInt32 MSGCRT_NOMIN = 0x00000000;
        public const UInt32 MSGCRT_MIN = 0x00000100;
        public const UInt32 MSGCRT_NOMAX = 0x00000000;
        public const UInt32 MSGCRT_MAX = 0x00000200;
        public const UInt32 MSGCRT_NOHIT = 0x00000000;
        public const UInt32 MSGCRT_HIT = 0x00000400;
        public const UInt32 MSGCRT_NOSYNC = 0x00000000;
        public const UInt32 MSGCRT_SYNC = 0x40000000;
        public const UInt32 MSGCRT_WIPE = 0x00000000;
        public const UInt32 MSGCRT_NOWIPE = 0x80000000;
        public const UInt32 MSGCRT_WIPE0 = 0x00000000;
        public const UInt32 MSGCRT_WIPE123 = 0x01000000;
        public const UInt32 MSGCRT_WIPECWD = 0x02000000;

        /**
        *
        *  Bit fields of the message error flag.
        *
        **/

        public const UInt32 MSGERR_NORESP = 0x8000;          //Set when we timeout waiting for response
        public const UInt32 MSGERR_ANYERR = 0x4000;          //Set when any error bit is set
        public const UInt32 MSGERR_PROTOCOL = 0x2000;          //General protocol error
        public const UInt32 MSGERR_SYNC = 0x1000;          //Set when we have the wrong sync
        public const UInt32 MSGERR_DATACOUNT = 0x0800;          //Set when improper number of data words
        public const UInt32 MSGERR_MANCH = 0x0020;          //Set when manchester error detected
        public const UInt32 MSGERR_PARITY = 0x0010;          //Set when parity error detected
        public const UInt32 MSGERR_WORD = 0x0008;          //Set when word error detected
        public const UInt32 MSGERR_RETRY = 0x0004;          //All retries failed
        public const UInt32 MSGERR_SYSTEM = 0x0002;          //An internal system error occurred
        public const UInt32 MSGERR_HIT = 0x0001;          //Always set

        /**
        *
        *  Bit fields of the message activity flag.
        *
        **/

        public const UInt32 MSGACT_XMTCWD1 = 0x8000;          //Transmitted CWD1
        public const UInt32 MSGACT_XMTCWD2 = 0x4000;          //Transmitted CWD2
        public const UInt32 MSGACT_XMTSWD1 = 0x2000;          //Transmitted SWD1
        public const UInt32 MSGACT_XMTSWD2 = 0x1000;          //Transmitted SWD2
        public const UInt32 MSGACT_RCVCWD1 = 0x0800;          //Received CWD1
        public const UInt32 MSGACT_RCVCWD2 = 0x0400;          //Received CWD2
        public const UInt32 MSGACT_RCVSWD1 = 0x0200;          //Received SWD1
        public const UInt32 MSGACT_RCVSWD2 = 0x0100;          //Received SWD2
        public const UInt32 MSGACT_XMTDWD = 0x0080;          //Transmitted DWD
        public const UInt32 MSGACT_RCVDWD = 0x0040;          //Received DWD

        /**
        *
        *  P71 Host Registers
        *
        **/

        public const UInt32 HREG_CTRL = 0x00;                    //Host control register (WR)
        public const UInt32 HREG_STAT = 0x00;                    //Host status register (RD)
        public const UInt32 HREG_CONFIG = 0x01;                    //Configuration register (RD/WR)
        public const UInt32 HREG_CMAIL = 0x02;                    //Controller mailbox register (WR)
        public const UInt32 HREG_HMAIL = 0x03;                    //Host mailbox register (RD)
        public const UInt32 HREG_ACCESS = 0x04;                    //Access register (RD/WR)
        public const UInt32 HREG_PAGE = 0x05;                    //Page register (RD/WR)
        public const UInt32 HREG_INDSEL = 0x06;                    //Indirect register select (RD/WR)
        public const UInt32 HREG_INDVAL = 0x07;                    //Indirect register value (RD/WR)

        /**
        *
        *  P12 Host Registers
        *
        **/

        public const UInt32 HREG_RESP = 0x00;                   //Response register (RD)
        public const UInt32 HREG_CTRL0 = 0x00;                   //Control 0 register (WR)
        public const UInt32 HREG_CTRL1 = 0x01;                   //Control 1 register (WR)
        public const UInt32 HREG_CTRL2 = 0x02;                   //Control 2 register (WR)
        public const UInt32 HREG_TRIG = 0x04;                   //Transmit trigger register (WR)
        public const UInt32 HREG_INTCLR = 0x05;                   //Interrupt clear register (WR)
        public const UInt32 HREG_SYNCCLR = 0x06;                   //Sync clear register (WR)

        /**
        *
        *  P71 Host Indirect Registers
        *
        **/

        public const UInt32 IREG_CTRL0 = 0x00;                   //Control register 0 (RD/WR)
        public const UInt32 IREG_CTRL1 = 0x01;                   //Control register 1 (RD/WR)
        public const UInt32 IREG_CTRL2 = 0x02;                   //Control register 2 (RD/WR)
        public const UInt32 IREG_DMA = 0x03;                   //DMA register (RD/WR)
        public const UInt32 IREG_TRIG = 0x04;                   //Transmit trigger (WR)
        public const UInt32 IREG_RESP = 0x04;                   //Response register (RD)
        public const UInt32 IREG_INTCLR = 0x05;                   //Interrupt clear (RD/WR)
        public const UInt32 IREG_SYNCCLR = 0x06;                   //Sync clear (RD/WR)

        /**
        *
        *  DSP Registers
        *
        **/

        public const UInt32 DREG_HOST = 0x2C40;                   //Host status register (RD)
        public const UInt32 DREG_INT = 0x2C41;                   //Interrupt register
        public const UInt32 DREG_CMAIL = 0x2C42;                   //Controller mailbox register
        public const UInt32 DREG_HMAIL = 0x2C43;                   //Host mailbox register
        public const UInt32 DREG_DMA = 0x2C44;                   //DMA register
        public const UInt32 DREG_PAGE = 0x2C45;                   //Page register
        public const UInt32 DREG_CTRL = 0x2C48;                   //Control from host register
        public const UInt32 DREG_RESP = 0x2C49;                   //Response to host register
        public const UInt32 DREG_SWD = 0x2C4A;                   //Status word from host register
        public const UInt32 DREG_HINT = 0x2C4C;                   //Host interrupt register
        public const UInt32 DREG_DIN = 0x2C4D;                   //DIN register
        public const UInt32 DREG_DOUT = 0x2C4E;                   //DOUT register

        /**
        *
        *  EDGA Registers
        *
        **/

        public const UInt32 EREG_STAT = 0xAC80;				//Status register (RD)
        public const UInt32 EREG_CTRLE = 0x2C81;				//Encoder control register
        public const UInt32 EREG_VALE = 0x2C82;				//Encoder value register
        public const UInt32 EREG_CFGINT = 0x2C83;				//Interrupt configuration register
        public const UInt32 EREG_CFG = 0x2C84;				//Configuration register
        public const UInt32 EREG_VALD = 0x2C85;				//Encoder value register (RD)
        public const UInt32 EREG_FT = 0x2C86;				//Frame time register
        public const UInt32 EREG_ID = 0x2C87;				//Identification register (RD)
        public const UInt32 EREG_STATCLR = 0x2C8E;				//Status clear register (WR)
        public const UInt32 EREG_RST = 0x2C8F;				//Reset register (WR)

        /**
        *
        *  Condition flags.
        *
        **/

        public const UInt32 COND_FAIL = 0x0001;                 //Condition when all retries have failed
        public const UInt32 COND_SRQ = 0x0002;                 //Condition on Service Request bit set in status word
        public const UInt32 COND_INS = 0x0004;                 //Condition on Instrumentation bit set in status word
        public const UInt32 COND_SSF = 0x0008;                 //Condition on Subsystem Fail bit set in status word
        public const UInt32 COND_TF = 0x0010;                 //Condition on Terminal Flag bit set in status word
        public const UInt32 COND_BUSY = 0x0020;                 //Condition on Busy bit set in status word
        public const UInt32 COND_ME = 0x0040;                 //Condition on Message Error bit set in status word
        public const UInt32 COND_RESPERR = 0x0080;                 //Condition on response error
        public const UInt32 COND_NORESP = 0x0100;                 //Condition on response error
        public const UInt32 COND_ALTBUS = 0x0200;                 //Retries are performed on alternate bus

        /**
        *
        *  Field types.
        *
        **/

        public const UInt16 FIELD_CWD1 = 0;	//CWD1 field
        public const UInt16 FIELD_CWD2 = 1;	//CWD2 field
        public const UInt16 FIELD_SWD1 = 2;	//SWD1 field
        public const UInt16 FIELD_SWD2 = 3;	//SWD2 field
        public const UInt16 FIELD_TTAG = 4;	//Time tag field
        public const UInt16 FIELD_ELAPSE = 5;	//Elapse time field
        public const UInt16 FIELD_ERROR = 6;	//Error field
        public const UInt16 FIELD_ACT = 7;	//Activity field
        public const UInt16 FIELD_RESP1 = 8;	//Response time 1 field
        public const UInt16 FIELD_RESP2 = 9;	//Response time 2 field
        public const UInt16 FIELD_COUNT = 10;	//Data count field
        public const UInt16 FIELD_FLAG1 = 11;	//Flag 1 field
        public const UInt16 FIELD_FLAG2 = 12;	//Flag 2 field
        public const UInt16 FIELD_RESV = 13;	//Reserved field

        /**
        *
        *  Interrupt types.
        *
        **/

        public const UInt32 INTTYPE_MSG = 0x0001;               //Message interrupt
        public const UInt32 INTTYPE_OPCODE = 0x0002;               //Interrupt opcode
        public const UInt32 INTTYPE_HALT = 0x0003;               //Schedule halt
        public const UInt32 INTTYPE_PAUSE = 0x0004;               //Schedule pause
        public const UInt32 INTTYPE_SEQ = 0x0005;               //Sequential record full

        /**
        *
        *  Timer resolutions.
        *
        **/

        public const UInt16 TIMERRESOL_1US = 1;	//1us timer resolution, 1:11:34
        public const UInt16 TIMERRESOL_16US = 2;	//16us timer resolution, 19:05:19 range
        public const UInt16 TIMERRESOL_1024US = 3;	//1024us timer resolution, 50 day range

        public const UInt16 MONRD_MAX_COUNT = 109;

        public const UInt16 SUBADDRESS = 0;
        public const UInt16 MODECODE = 1;

        public const UInt16 RCV = 0;
        public const UInt16 XMT = 1;

        public const UInt16 STAT_EMPTY = 0;	//Buffer is empty
        public const UInt16 STAT_PARTIAL = 1;	//Buffer is partially filled
        public const UInt16 STAT_FULL = 2;	//Buffer is full
        public const UInt16 STAT_OFF = 3;	//Buffer is off

        public const UInt16 TEST_LEVEL_0 = 0;	//Test I/O interface
        public const UInt16 TEST_LEVEL_1 = 1;	//Test memory interface
        public const UInt16 TEST_LEVEL_2 = 2;	//Test communication process

        public const UInt16 ERR_NONE = 0;	//No error
        public const Int16 ERR_UNKNOWN = -1;	//An unexpected error occurred
        public const Int16 ERR_BADVER = -2;	//A bad version was encountered
        public const Int16 ERR_BADPARAMS = -11;	//CardOpen() called with bad parameters
        public const Int16 ERR_NOHANDLES = -12;	//CardOpen() already has allocated too many handles
        public const Int16 ERR_NOCARD = -13;	//CardOpen() could not find a PC708-1 card at the specified address
        public const Int16 ERR_NOIO = -14;	//CardOpen() could not find the I/O ports
        public const Int16 ERR_NOMEM = -15;	//CardOpen() could not find the memory
        public const Int16 ERR_BAD16BIT = -16;	//Card is conflicting with another 16-bit card
        public const Int16 ERR_WRONGMODEL = -17;	//Card does not support this feature
        public const Int16 ERR_NOSEL = -18;	//CardOpen() could not allocate a memory selector
        public const Int16 ERR_LOCK = -19;	//The communication process is locked up
        public const Int16 ERR_TOOMANY = -20;	//Too many terminals have been configured
        public const Int16 ERR_BADHANDLE = -21;	//A bad handle was specified
        public const Int16 ERR_BADTA = -22;	//A bad terminal address was specified
        public const Int16 ERR_BADFRAME = -23;	//A bad frame time was specified
        public const Int16 ERR_NOTBC = -24;	//The BC has not been configured
        public const Int16 ERR_NOTRT = -25;	//The RT has not been configured
        public const Int16 ERR_NOTMON = -26;	//The monitor has not been configured
        public const Int16 ERR_ALLOC = -27;	//There is not enough memory to allocate
        public const Int16 ERR_VXD = -28;	//An error occurred in the VXD
        public const Int16 ERR_BADMSG = -31;	//The specified command block is not a message block
        public const Int16 ERR_BADSCHNDX = -32;	//Specified command index is out of range
        public const Int16 ERR_BUFSIZE = -33;	//Insufficient space in user buffer
        public const Int16 ERR_NOCONFIG = -34;	//The card has not been properly configured
        public const Int16 ERR_BOOTFULL = -41;	//No space to add boot code
        public const Int16 ERR_BOOTNUM = -42;	//There is no boot code with the specified number
        public const Int16 ERR_ACCESS = -43;	//Unable to write to access register
        public const Int16 ERR_ROMVERIFY = -44;	//Unable to verify the value written to the ROM
        public const Int16 ERR_COUNT = -45;	//An invalid count was specified
        public const Int16 ERR_CRC = -46;	//There was a bad checksum in the HEX file
        public const Int16 ERR_FNAME = -47;	//Bad filenames were specified
        public const Int16 ERR_FRDWR = -48;	//There was an error reading or writing the HEX file
        public const Int16 ERR_HEX = -49;	//There was a bad hex character in the HEX file
        public const Int16 ERR_INDEX = -51;	//The command block index was invalid or the schedule is full
        public const Int16 ERR_NOMSGS = -52;	//No messages specified
        public const Int16 ERR_RESPONSE = -53;	//A bad response or no response was received from an RT
        public const Int16 ERR_TYPE = -54;	//There was a bad type value in the HEX file
        public const Int16 ERR_ZEROLEN = -55;	//Zero length was specified
        public const Int16 ERR_DMABAD = -61;	//Bad DMA channel was specified
        public const Int16 ERR_DMAODD = -62;	//An odd DMA address or count was specified
        public const Int16 ERR_DMAPAGE = -63;	//DMA buffer specified crosses a page boundary
        public const Int16 ERR_SELFIOFAIL = -71;	//I/O selftest failed
        public const Int16 ERR_SELFMEMFAIL = -72;	//Memory selftest failed
        public const Int16 ERR_SELFCOMMFAIL = -73;	//Communication selftest failed
        public const Int16 ERR_SELFXMTFAIL = -74;	//Transmit selftest failed

    }	//end class
}	//end namespace
