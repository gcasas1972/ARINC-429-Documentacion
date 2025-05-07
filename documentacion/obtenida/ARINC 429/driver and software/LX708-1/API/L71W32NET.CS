using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class L71W32
    {
        /**
        *
        *  LP708-1 and LC708-1 WIN32 DRIVER  Version 1.2  (01/19/2001)
        *  Copyright (c) 1999-2001
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   L71W32NET.CS -- 32-bit
        *                      L71 Driver Include Header File.
        *
        **/

        /**
        *
        *  L71 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the L71 Driver.
        *
        **/

        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardClose(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardOpen@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_CardOpen(Int32 cardnum);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CardReset(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardStart(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardStop(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetAngle@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldGetAngle(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetAngleFl@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Single L71_FieldGetAngleFl(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetControlAccept@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldGetControlAccept(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetData@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldGetData(Int32 binnum, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetDataAccept@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldGetDataAccept(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetFaults@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldGetFaults(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetGain@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_FieldGetGain(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetLabel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldGetLabel(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetMode@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldGetMode(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetRange@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_FieldGetRange(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetTilt@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldGetTilt(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldGetTiltFl@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Single L71_FieldGetTiltFl(ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutAngle@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldPutAngle(UInt16 value, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutAngleFl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Single L71_FieldPutAngleFl(Single angle, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutControlAccept@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldPutControlAccept(UInt16 value, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldPutData(UInt16 value, Int32 binnum, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutDataAccept@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldPutDataAccept(UInt16 value, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutFaults@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldPutFaults(UInt16 value, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutGain@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_FieldPutGain(Int32 gain, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutLabel@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldPutLabel(UInt16 value, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutMode@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldPutMode(UInt16 value, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutRange@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_FieldPutRange(Int32 range, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutTilt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_FieldPutTilt(UInt16 value, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FieldPutTiltFl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Single L71_FieldPutTiltFl(Single tilt, ref UInt16 buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_IntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_IntRd(ref UInt16 typevalval, ref UInt16 infoval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_IntStatus(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_IntUninstall(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvConfig@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RcvConfig(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RcvConfigEx(UInt32 rtconfigval, UInt16 intfreq, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvMonBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_RcvMonBlkRd(ref UInt16 buf, UInt32 bufcount, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvMonBlkRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_RcvMonBlkRdEx(ref UInt16 buf, UInt32 bufcount, UInt32 maxblkcnt, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvMonRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_RcvMonRd(ref UInt16 buf, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvMonRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_RcvMonRdEx(ref UInt16 buf, UInt16 index, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvMonStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RcvMonStatus(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RcvRd(ref UInt16 buf, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtConfig(UInt16 framefreq, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtConfigEx(UInt16 framefreq, UInt16 intfreq, UInt16 framecount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtConfigExx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtConfigExx(UInt32 xmtconfigval, UInt16 framefreq, UInt16 intfreq, UInt16 framecount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_XmtRd(ref UInt16 buf, UInt16 framenum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtStatus(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_XmtWr(ref UInt16 buf, UInt16 framenum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_AddrDSP@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_AddrDSP(UInt32 addr);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_AddrHost@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_AddrHost(UInt32 addr);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCConfig(UInt32 configval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCConfigEx(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCConfigMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_BCConfigMsg(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCCreateList@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_BCCreateList(UInt32 listconfigval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCCreateListEx@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_BCCreateListEx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCCreateListExx@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_BCCreateListExx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCCreateMsg@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_BCCreateMsg(UInt32 configval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCGetMsg@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_BCGetMsg(Int32 index, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedAgain@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedAgain(Int32 index, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedBranch@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedBranch(UInt16 condition, Int32 destindex, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedBranchDin0@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedBranchDin0(Int32 destindex, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedBranchDin1@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedBranchDin1(Int32 destindex, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedBranchEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedBranchEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, Int32 destindex, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedBuild@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedBuild(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedCall(Int32 destindex, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedCallCond@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedCallCond(UInt16 condition, Int32 destindex, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedCallCondEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedCallCondEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, Int32 destindex, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedEntry@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedEntry(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedFrame@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedFrame(UInt32 timeval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedFrameEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedFrameEnd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedFrameStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedFrameStart(UInt32 timeval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedGap@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedGap(UInt16 gapval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedGoto@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedGoto(Int32 destindex, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedHalt@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedHalt(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedInt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedInt(UInt16 tagval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedIntCond@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedIntCond(UInt16 condition, UInt16 tagval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedIntCondEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedIntCondEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 tagval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedMsg@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedMsg(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedNop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedNop(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedPause@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedPause(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedPulse@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedPulse(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedPulse0@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedPulse0(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedPulse1@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedPulse1(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedRestart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedRestart(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedRetry@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedRetry(UInt16 condition, UInt16 retries, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedRetryEx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedRetryEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 retryflag, UInt16 retries, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedReturn@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedReturn(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSchedUser@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSchedUser(UInt32 useraddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSetEntry@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSetEntry(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BCSetTimeout@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BCSetTimeout(UInt16 timeoutval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_BlkAddr(Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_BlkOptRd(Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BlkOptWr(UInt16 rtopt, Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkPtrRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_BlkPtrRd(Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkPtrWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_BlkPtrWr(UInt32 descaddr, Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BlkRd(ref UInt16 block, Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BlkReset(Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkSWDRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_BlkSWDRd(Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkSWDWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BlkSWDWr(UInt16 swdval, Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BlkWipe(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_BlkWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_BlkWr(ref UInt16 block, Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardBoot@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardBoot(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardCloseAll@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardCloseAll();
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardConfig(Int32 enableflag, UInt16 command, UInt16 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardGetInfo@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_CardGetInfo(UInt16 infotype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardGetInfoEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardGetInfoEx(ref UInt16 bufmodel, UInt16 bufmodelcount, ref UInt16 buffeature, UInt16 buffeaturecount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardInit@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CardInit();
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardIsRunning(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardNop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardNop(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardNopEx@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardNopEx(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardOpenEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_CardOpenEx(ref string cardname, Int32 cardnum);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardOpenExx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_CardOpenExx(ref string cardname, Int32 cardnum, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardResetEx@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CardResetEx(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardResume(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardTest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardTest(UInt16 level, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardTest0@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardTest0(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardTest1@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardTest1(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardTest2@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardTest2(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardTest3@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CardTest3(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CardTrigger@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CardTrigger(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CFGRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_CFGRdL(Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CFGWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CFGWrL(UInt32 value, Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_CmdAddr(Int32 index, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_CmdAlloc(Int32 count, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdBaseRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_CmdBaseRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdBaseWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CmdBaseWr(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CmdClear(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_CmdCountRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CmdCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdCtrlRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_CmdCtrlRd(Int32 index, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdCtrlWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CmdCtrlWr(UInt16 ctrlval, Int32 index, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdCurrRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_CmdCurrRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdCurrWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CmdCurrWr(UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CmdInit(UInt16 opcode, ref UInt16 block);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdInsert@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CmdInsert(ref UInt16 block, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdMaxRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_CmdMaxRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdMaxWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CmdMaxWr(UInt16 count, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdShotWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CmdShotWr(Int32 value, Int32 index, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdSkipWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CmdSkipWr(Int32 value, Int32 index, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdStackClr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CmdStackClr(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdStartRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_CmdStartRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdStartWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CmdStartWr(UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdTotalRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CmdTotalRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdTotalWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CmdTotalWr(Int32 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CmdWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CommCall(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommCheck@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CommCheck(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommDisable@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CommDisable(UInt16 command, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommDisableEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CommDisableEx(UInt16 command, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CommEnable(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_CommRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CommRdsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_CommRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommRun@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CommRun(ref UInt16 dataptr, UInt16 datacount, ref UInt16 codeptr, UInt16 codecount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CommWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_CommWrsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_CommWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_CommWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DARClr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DARClr(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DARGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DARGet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DARRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_DARRdL(UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DARRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_DARRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DARSet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DARSet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DARWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DARWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DARWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DescAddr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_DescAddr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DescAlloc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_DescAlloc(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DescConfig@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DescConfig(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DescOptRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_DescOptRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DescOptWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DescOptWr(UInt16 descopt, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DescPtrRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_DescPtrRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DescPtrWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_DescPtrWr(UInt32 msgaddr, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DescRd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_DescRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DescWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_DescWr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_Div@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_Div(UInt32 diva, UInt32 divb);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DllUsageCount();
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_DPMMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DPMMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_DPMRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_DPMRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMRdsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DPMRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DPMRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_DPMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DPMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DPMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMWrsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DPMWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DPMWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DPMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_DPMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DspBioClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DspBioClear(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DspBioRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_DspBioRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DspBioSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DspBioSet(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DspIntfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DspIntfClear(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DspIntfRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DspIntfRead(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DspIntmClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DspIntmClear(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DspIntmSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DspIntmSet(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DspXfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DspXfClear(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_DspXfSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_DspXfSet(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ErrDesc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L71_ErrDesc(Int32 errval);
        public static string L71_ErrDesc(Int32 errval) { return Marshal.PtrToStringAnsi(_L71_ErrDesc(errval)); }
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ErrDescStr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L71_ErrDescStr(Int32 errval);
        public static string L71_ErrDescStr(Int32 errval) { return Marshal.PtrToStringAnsi(_L71_ErrDescStr(errval)); }
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ErrName@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L71_ErrName(Int32 errval);
        public static string L71_ErrName(Int32 errval) { return Marshal.PtrToStringAnsi(_L71_ErrName(errval)); }
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ErrorDefine@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ErrorDefine(Int32 busb, UInt16 intfreq, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ExtDinRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ExtDinRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ExtDinWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ExtDinWr(Int32 dinval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ExtDoutRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ExtDoutRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ExtDoutWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ExtDoutWr(Int32 doutval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FileClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_FileClose(IntPtr handle);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FileErr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_FileErr();
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FileErrClr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_FileErrClr();
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FileErrSet@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_FileErrSet();
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FileOpenRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* L71_FileOpenRead(ref string filename);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FileOpenWrite@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* L71_FileOpenWrite(ref string filename);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FileRead@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_FileRead(IntPtr handle, IntPtr buffer, UInt16 count);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FileSeek@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_FileSeek(IntPtr handle, UInt32 offset);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FileTell@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_FileTell(IntPtr handle);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_FileWrite@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_FileWrite(IntPtr handle, IntPtr buffer, UInt16 count);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_GetHigh@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_GetHigh(UInt32 val);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_GetLow@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_GetLow(UInt32 val);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_GlobalRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_GlobalRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_GlobalWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_GlobalWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HandleClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_HandleClose(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HandleDel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_HandleDel(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HandleGet@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_HandleGet(ref string cardstr, ref Int32 cardnum, ref Int32 devnum, ref UInt32 sizval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HandleIns@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_HandleIns(ref string cardname, Int32 cardnum, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HandleOkay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_HandleOkay(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HandleOpen@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_HandleOpen(ref string cardname, Int32 cardnum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HandleOpenWin95@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_HandleOpenWin95(ref string cardname, Int32 cardnum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HandleOpenWinNT@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_HandleOpenWinNT(ref string cardname, Int32 cardnum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HandleVer@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_HandleVer(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HandleVerPLX@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_HandleVerPLX(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HeapAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_HeapAlloc(UInt32 wordcount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HeapAllocAll@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_HeapAllocAll(ref UInt32 wordcount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HeapAllocAllDPM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_HeapAllocAllDPM(ref UInt16 wordcount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HeapAllocDPM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_HeapAllocDPM(UInt16 wordcount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HeapAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_HeapAllocEx(UInt16 configval, UInt32 wordcount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HeapWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_HeapWipe(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_HeapWipeDPM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_HeapWipeDPM(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IndirectRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_IndirectRd(Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IndirectWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_IndirectWr(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_IntClear(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_IntConfig(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntDisable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_IntDisable(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_IntEnable(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntEnableCond@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_IntEnableCond(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntGet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* L71_IntGet(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IntReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_IntReset(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IORdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_IORdW(Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IOWINRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_IOWINRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IOWINWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_IOWINWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_IOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_IOWrW(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernBegin@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        unsafe public static extern Int32 L71_KernBegin(IntPtr* vxdptr, ref string cardstr, ref string cardname, Int32 busnum, Int32 devnum, Int32 funcnum);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernDev@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernDev(ref Int32 valueptr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernEnd(IntPtr vxdptr);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernIntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernIntClear(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernIntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernIntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernIntParam@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernIntParam(UInt32 clraddr, UInt32 clrwidth, UInt32 clrvalue, UInt32 stataddr, UInt32 statwidth, UInt32 statvalue, UInt32 statmask, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernIntStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernIntStatus(ref Int32 valueptr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernIntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernIntUninstall(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernIORdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernIORdW(ref UInt16 valueptr, Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernIOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernIOWrW(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernMEMFillW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernMEMFillW(UInt16 value, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernMEMRdL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernMEMRdL(ref UInt32 valueptr, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernMEMRdsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernMEMRdsL(ref UInt32 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernMEMRdsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernMEMRdsW(ref UInt16 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernMEMRdW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernMEMRdW(ref UInt16 valueptr, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernMEMWrL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernMEMWrL(UInt32 value, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernMEMWrsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernMEMWrsL(ref UInt32 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernMEMWrsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernMEMWrsW(ref UInt16 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernMEMWrW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernMEMWrW(UInt16 value, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernQuick@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernQuick(Int32 flag, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernStatus@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernStatus(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_KernStatusEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_KernStatusEx(ref UInt32 valueptr, UInt32 typeval, UInt32 index, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListAddrEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ListBlockRd(ref UInt16 buf, UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListBlockRdEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ListBlockRdEx(ref UInt16 buf, Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ListBlockWr(ref UInt16 buf, UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListBlockWrEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ListBlockWrEx(ref UInt16 buf, Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ListClear(UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ListConfig(UInt32 configval, Int32 count, UInt16 skipval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ListConfigEx(UInt32 configval, Int32 count, UInt16 skipval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ListDataRd(ref UInt16 buf, Int32 count, UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListDataRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ListDataRdEx(ref UInt16 buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ListDataWr(ref UInt16 buf, Int32 count, UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListDataWrEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ListDataWrEx(ref UInt16 buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListInit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListNextRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ListNextRd(UInt32 listaddr, ref UInt16 header);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListNextWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ListNextWr(UInt32 listaddr, ref UInt16 header);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListPostRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListPostWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListPreRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListPreWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ListStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ListStatus(UInt32 listaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MakeLong@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MakeLong(UInt16 valh, UInt16 vall);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_Mask@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_Mask(UInt32 dataval, UInt16 cntval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINFillW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MEMWINFillW(UInt16 value, UInt32 addrval, UInt32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINRdB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MEMWINRdB(UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINRdL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MEMWINRdL(UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINRdsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MEMWINRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINRdsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MEMWINRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINRdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MEMWINRdW(UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINWrB@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MEMWINWrB(UInt16 value, UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINWrL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MEMWINWrL(UInt32 value, UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINWrsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MEMWINWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINWrsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MEMWINWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MEMWINWrW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MEMWINWrW(UInt16 value, UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_Mod@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_Mod(UInt32 moda, UInt32 modb);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ModeIsBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ModeIsBC(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ModeIsMon@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ModeIsMon(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ModeIsNotBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ModeIsNotBC(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ModeIsNotMon@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ModeIsNotMon(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ModeIsNotRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ModeIsNotRT(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ModeIsNotSerial@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ModeIsNotSerial(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ModeIsRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ModeIsRT(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ModeIsSerial@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ModeIsSerial(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ModeRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_ModeRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ModeWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ModeWr(UInt16 mode, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MonBlkRd(ref UInt16 buf, UInt32 bufcount, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonBlkRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MonBlkRdEx(ref UInt16 buf, UInt32 bufcount, UInt32 maxblkcnt, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonClear(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonConfig(UInt32 configval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonConfigEx(UInt32 configval, UInt32 moncount, UInt16 cardnum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonConfigExx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonConfigExx(UInt32 configval, UInt32 seqaddr, UInt32 moncount, UInt16 cardnum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonFilterSA@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonFilterSA(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonFilterSAEx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonFilterSAEx(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonFilterTA@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonFilterTA(UInt32 tamask, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonIsRunning(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MonRd(ref UInt16 buf, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MonRdEx(ref UInt16 buf, UInt16 bufcount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonResume(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonStart(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonStatus(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MonStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MonStop(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MsgBlockRd(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MsgBlockWr(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MsgCheck(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgCommRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MsgCommRd(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgCommWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MsgCommWr(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MsgConfig(UInt32 configval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MsgConfigEx(UInt32 configval, UInt16 cwd, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgCWD1Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MsgCWD1Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgCWD1Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MsgCWD1Wr(UInt16 cwd1, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgCWD2Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MsgCWD2Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgCWD2Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MsgCWD2Wr(UInt16 cwd2, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MsgDataRd(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MsgDataWr(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgErrorRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MsgErrorRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgErrorWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MsgErrorWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgFieldRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MsgFieldRd(UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgFieldWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MsgFieldWr(UInt32 fieldval, UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgFlagRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MsgFlagRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgFlagWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MsgFlagWr(UInt16 msgflag, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgIsAccessed@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_MsgReset(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgSWD1Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MsgSWD1Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_MsgSWD2Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_MsgSWD2Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_Mul@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_Mul(UInt32 mula, UInt32 mulb);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_PortRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_PortRd(Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_PortWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_PortWr(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ProgRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_ProgRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ProgWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ProgWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMFill@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RAMFill(UInt16 value, UInt32 addrval, UInt32 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMIsDPM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RAMIsDPM(UInt32 addrval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_RAMRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_RAMRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMRdsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RAMRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RAMRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_RAMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RAMWipe(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMWipeEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RAMWipeEx(UInt16 value, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RAMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RAMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMWrsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RAMWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RAMWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RAMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RAMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvAlloc@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RcvAlloc(UInt32 configval, UInt16 framenum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvConfigExx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RcvConfigExx(UInt32 rtconfigval, UInt16 intfreq, UInt32 monconfigval, UInt32 intconfigval, UInt16 inttotal, UInt32 msgconfigval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_RcvCountRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RcvCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvDataCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_RcvDataCountRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvDataCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_RcvDataCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RcvIndex@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_RcvIndex(UInt16 framenum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RTConfig(UInt32 configval, Int32 taval, UInt16 intfreq, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RTConfigEx(UInt32 configval, Int32 taval, UInt16 intfreq, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTConfigExx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RTConfigExx(UInt32 configval, Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTConfigMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_RTConfigMsg(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTCreateList@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_RTCreateList(UInt32 listconfigval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTCreateListEx@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_RTCreateListEx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTCreateListExx@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_RTCreateListExx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTCreateMsg@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_RTCreateMsg(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTGetMsg@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_RTGetMsg(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RTReset(Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_RTStatus(Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTSWDRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_RTSWDRd(Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_RTSWDWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_RTSWDWr(UInt16 swdval, Int32 taval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedBuild@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SchedBuild(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 freq, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedBuildEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SchedBuildEx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 freq, ref Int32 period, IntPtr buf, UInt32 bufsize, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedBuildExx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SchedBuildExx(UInt32 frametime, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 period, IntPtr buf, UInt32 bufsize, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedCalc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SchedCalc(ref UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedDisplay@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_SchedDisplay(UInt32 nummsgs, ref UInt32 count);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedHook@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_SchedHook(Int32 index, IntPtr ptr);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedInsEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SchedInsEnd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedInsMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SchedInsMsg(UInt32 index, ref UInt32 msgaddr, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedInsStart@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SchedInsStart(UInt32 frametime, UInt32 count, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedMaxval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_SchedMaxval(ref UInt32 arrayval, UInt32 arrayvalcount);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SchedMinval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_SchedMinval(ref UInt32 arrayval, UInt32 arrayvalcount);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEEPokeW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SEEPokeW(Int32 value, Int32 numbits, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEERdBit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SEERdBit(ref Int32 valueptr, Int32 bitnum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEERdL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SEERdL(ref UInt32 valueptr, Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEERdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SEERdW(ref Int32 valueptr, Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEEWrBit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SEEWrBit(Int32 value, Int32 bitnum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEEWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SEEWrL(UInt32 value, Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEEWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_SEEWrW(Int32 value, Int32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEMMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_SEMMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEMMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_SEMMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_SEMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_SEMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_SEMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_Shl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_Shl(UInt32 dataval, UInt16 cntval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_Shr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_Shr(UInt32 dataval, UInt16 cntval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_TimerClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_TimerClear(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_TimerRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_TimerRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_TimerResolution@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_TimerResolution(Int32 timerresol, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_TimerResolutionEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_TimerResolutionEx(UInt16 timershift, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValAsciiCmpi@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ValAsciiCmpi(ref string str1, ref string str2);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValAsciiCpy@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L71_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count);
        public static string L71_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count) { return Marshal.PtrToStringAnsi(_L71_ValAsciiCpy(ref strdest, ref strsrc, count)); }
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValAsciiTrimLead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ValAsciiTrimLead(ref string buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValAsciiTrimTrail@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ValAsciiTrimTrail(ref string buf);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValFromAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_ValFromAscii(ref string asciistr, Int32 radixval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValGetBits@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_ValGetBits(UInt16 oldvalue, Int32 startbit, Int32 endbit);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValIncAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L71_ValIncAscii(ref string asciistr);
        public static string L71_ValIncAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_L71_ValIncAscii(ref asciistr)); }
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValInccAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L71_ValInccAscii(ref string asciistr);
        public static string L71_ValInccAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_L71_ValInccAscii(ref asciistr)); }
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValIsLower@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ValIsLower(Int32 value);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValLenAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ValLenAscii(Int32 numbits, Int32 radixval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValPackCWD@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_ValPackCWD(Int32 taval, Int32 trflag, Int32 saval, Int32 wcval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValPackRTCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_ValPackRTCWD(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 count);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValPutBits@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_ValPutBits(UInt16 oldvalue, UInt16 newfld, Int32 startbit, Int32 endbit);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValToAscii@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L71_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval);
        public static string L71_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval) { return Marshal.PtrToStringAnsi(_L71_ValToAscii(value, ref asciistr, numbits, radixval)); }
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValToUpper@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_ValToUpper(Int32 value);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValUnpackCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ValUnpackCWD(UInt16 cwdval, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 wcval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_ValUnpackRTCWD@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_ValUnpackRTCWD(UInt16 cwd, ref Int32 bcastflag, ref Int32 mcflag, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 count);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtAlloc@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtAlloc(UInt32 configval, UInt16 framecount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtConfigExxx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtConfigExxx(UInt32 bcconfigval, UInt32 msgconfigval, UInt16 framefreq, UInt16 intfreq, UInt16 framecount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_XmtCountRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_XmtCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtDataCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_XmtDataCountRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtDataCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_XmtDataCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtFreq@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtFreq(UInt16 framefreq, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtFreqEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtFreqEx(UInt16 framefreq, UInt16 intfreq, UInt16 framecount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtFreqExx@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtFreqExx(UInt16 framefreq, UInt16 intfreq, UInt16 framecount, UInt32 bcconfigval, UInt16 bctotal, UInt32 intconfigval, UInt16 inttotal, UInt32 msgconfigval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtIndex@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L71_XmtIndex(UInt16 framenum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtNumberRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_XmtNumberRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtNumberWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_XmtNumberWr(UInt16 brdnum, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtPeriod@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtPeriod(UInt32 frameperiod, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtPeriodEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtPeriodEx(UInt32 frameperiod, UInt16 intfreq, UInt16 framecount, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtPeriodExx@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L71_XmtPeriodExx(UInt32 frameperiod, UInt16 intfreq, UInt16 framecount, UInt32 bcconfigval, UInt16 bctotal, UInt32 intconfigval, UInt16 inttotal, UInt32 msgconfigval, UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtSizeRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L71_XmtSizeRd(UInt32 handleval);
        [DllImport("L71W32.DLL", EntryPoint = "_L71_XmtSizeWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L71_XmtSizeWr(UInt16 mode, UInt32 handleval);

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
        public const UInt32 XMTCFG_MODEL = 0x00000000;
        public const UInt32 XMTCFG_RAM = 0x00100000;
        public const UInt32 XMTCFG_DPRAM = 0x00200000;

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
        public const UInt32 RCVCFG_MODEL = 0x00000000;
        public const UInt32 RCVCFG_RAM = 0x00100000;
        public const UInt32 RCVCFG_DPRAM = 0x00200000;

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
        public const UInt32 BCCFG_MODEL = 0x00000000;
        public const UInt32 BCCFG_RAM = 0x00100000;
        public const UInt32 BCCFG_DPRAM = 0x00200000;

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
        public const UInt32 MONCFG_DPRAM = 0x10000000;

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
        public const UInt32 RTCFG_WIPE123 = 0x10000000;
        public const UInt32 RTCFG_WIPECWD = 0x20000000;
        public const UInt32 RTCFG_MODEL = 0x00000000;
        public const UInt32 RTCFG_RAM = 0x00100000;
        public const UInt32 RTCFG_DPRAM = 0x00200000;

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
        *  Info types
        *
        **/

        public const UInt32 INFOTYPE_PLAT = 0x0001;           //Returns the L71 platform type
        public const UInt32 INFOTYPE_PROD = 0x0002;           //Returns the L71 product type
        public const UInt32 INFOTYPE_DASH = 0x0003;           //Returns the L71 dash number
        public const UInt32 INFOTYPE_VERSION = 0x0004;           //Returns the L71 version number
        public const UInt32 INFOTYPE_DATE = 0x0005;           //Returns the L71 version date
        public const UInt32 INFOTYPE_TRANSMIT = 0x0006;           //Returns whether the L71 has a transmitter
        public const UInt32 INFOTYPE_RECEIVE = 0x0007;           //Returns whether the L71 has a receiver
        public const UInt32 INFOTYPE_MODEL = 0x0008;           //Returns the L71 model number
        public const UInt32 INFOTYPE_MAXCOUNT = 0x0009;           //Returns the number of terminals the L71 can simulate
        public const UInt32 INFOTYPE_MULTIMODE = 0x000A;           //Returns whether L71 can simulate multi-modes
        public const UInt32 INFOTYPE_ERRORGEN = 0x000B;           //Returns whether L71 can generate errors
        public const UInt32 INFOTYPE_CONCURMON = 0x000C;           //Returns whether L71 has a concurrent monitor
        public const UInt32 INFOTYPE_MONFILTER = 0x000D;           //Returns whether L71 has a monitor filter
        public const UInt32 INFOTYPE_USERCODE = 0x000E;           //Returns whether L71 handles user code
        public const UInt32 INFOTYPE_LISTBUF = 0x000F;           //Returns whether L71 handles list buffering
        public const UInt32 INFOTYPE_MONFAST = 0x0010;           //Returns whether L71 has a fast monitor
        public const UInt32 INFOTYPE_MONDMA = 0x0011;           //Returns whether L71 has a dma monitor
        public const UInt32 INFOTYPE_MONBRAKE = 0x0012;           //Returns whether L71 has a monitor brake
        public const UInt32 INFOTYPE_DUAL = 0x0013;           //Returns whether the L71 has dual xmt/rcv capability
        public const UInt32 INFOTYPE_BITSYNC = 0x0014;           //Returns whether the L71 has bit sync capability

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
        public const UInt32 MSGCRT_MODEL = 0x00000000;
        public const UInt32 MSGCRT_RAM = 0x00100000;
        public const UInt32 MSGCRT_DPRAM = 0x00200000;

        /**
        *
        *  List buffer options
        *
        **/

        public const UInt32 LISTCRT_DEFAULT = 0x00000000;
        public const UInt32 LISTCRT_PINGPONG = 0x00000000;
        public const UInt32 LISTCRT_FIFO = 0x00000001;
        public const UInt32 LISTCRT_CIRCULAR = 0x00000002;
        public const UInt32 LISTCRT_TRBIT = 0x00000000;
        public const UInt32 LISTCRT_READ = 0x00000010;
        public const UInt32 LISTCRT_WRITE = 0x00000020;
        public const UInt32 LISTCRT_NOTSKIP = 0x00000000;
        public const UInt32 LISTCRT_SKIP = 0x00000040;
        public const UInt32 LISTCRT_NOINT = 0x00000000;
        public const UInt32 LISTCRT_INT = 0x00000100;
        public const UInt32 LISTCRT_NOHIT = 0x00000000;
        public const UInt32 LISTCRT_HIT = 0x00000200;
        public const UInt32 LISTCRT_MODEL = 0x00000000;
        public const UInt32 LISTCRT_RAM = 0x00100000;
        public const UInt32 LISTCRT_DPRAM = 0x00200000;

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
        *  L71 IFGA Registers
        *
        **/

        public const UInt32 IREG_STAT = 0x0040;                  //Status register (RD)
        public const UInt32 IREG_SET = 0x0041;                  //Set register (WR)
        public const UInt32 IREG_CLR = 0x0042;                  //Clear register (WR)
        public const UInt32 IREG_ID = 0x0043;                  //ID register (RD)
        public const UInt32 IREG_PAGE = 0x0044;                  //Page register
        public const UInt32 IREG_CONFIG = 0x0045;                  //Configuration register
        public const UInt32 IREG_DINT = 0x0046;                  //DSP interrupt register
        public const UInt32 IREG_HINT = 0x0047;                  //HOST interrupt register

        /**
        *
        *  EDGA Registers
        *
        **/

        public const UInt32 EREG_STAT = 0x0180;				//Status register (RD)
        public const UInt32 EREG_CTRLE = 0x0081;				//Encoder control register
        public const UInt32 EREG_VALE = 0x0082;				//Encoder value register
        public const UInt32 EREG_CFGINT = 0x0083;				//Interrupt configuration register
        public const UInt32 EREG_CFG = 0x0084;				//Configuration register
        public const UInt32 EREG_VALD = 0x0085;				//Encoder value register (RD)
        public const UInt32 EREG_FT = 0x0086;				//Frame time register
        public const UInt32 EREG_ID = 0x0087;				//Identification register (RD)
        public const UInt32 EREG_STATCLR = 0x008E;				//Status clear register (WR)
        public const UInt32 EREG_RST = 0x008F;				//Reset register (WR)

        /**
        *
        *  Local Configuration Registers
        *
        **/

        public const UInt32 CREG_LAS0RR = 0x0000;					//Local Address Space 0 Range
        public const UInt32 CREG_LAS1RR = 0x0001;					//Local Address Space 1 Range
        public const UInt32 CREG_LAS2RR = 0x0002;					//Local Address Space 2 Range
        public const UInt32 CREG_LAS3RR = 0x0003;					//Local Address Space 3 Range
        public const UInt32 CREG_EROMRR = 0x0004;					//Local Expansion ROM Range
        public const UInt32 CREG_LAS0BA = 0x0005;					//Local Address Space 0 Local Base Address (Re-map)
        public const UInt32 CREG_LAS1BA = 0x0006;					//Local Address Space 1 Local Base Address (Re-map)
        public const UInt32 CREG_LAS2BA = 0x0007;					//Local Address Space 2 Local Base Address (Re-map)
        public const UInt32 CREG_LAS3BA = 0x0008;					//Local Address Space 3 Local Base Address (Re-map)
        public const UInt32 CREG_EROMBA = 0x0009;					//Expansion ROM Local Base Address (Re-map)
        public const UInt32 CREG_LAS0BRD = 0x000A;					//Local Address Space 0 Bus Region Descriptors
        public const UInt32 CREG_LAS1BRD = 0x000B;					//Local Address Space 1 Bus Region Descriptors
        public const UInt32 CREG_LAS2BRD = 0x000C;					//Local Address Space 2 Bus Region Descriptors
        public const UInt32 CREG_LAS3BRD = 0x000D;					//Local Address Space 3 Bus Region Descriptors
        public const UInt32 CREG_EROMBRD = 0x000E;					//Expansion ROM Bus Region Descriptors
        public const UInt32 CREG_CS0BASE = 0x000F;					//Chip Select 0 Base Address
        public const UInt32 CREG_CS1BASE = 0x0010;					//Chip Select 1 Base Address
        public const UInt32 CREG_CS2BASE = 0x0011;					//Chip Select 2 Base Address
        public const UInt32 CREG_CS3BASE = 0x0012;					//Chip Select 3 Base Address
        public const UInt32 CREG_INTCSR = 0x0013;					//Interrupt Control/Status
        public const UInt32 CREG_CNTRL = 0x0014;					//EEPROM Control, PCI Slave Response, User I/O Control, Init Control

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
        public const UInt32 INTTYPE_LIST = 0x0006;               //List buffer empty/full
        public const UInt32 INTTYPE_PARITY = 0x0007;               //Parity error
        public const UInt32 INTTYPE_DIN = 0x0008;               //DIN

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
        public const UInt16 TEST_LEVEL_3 = 3;	//Test bus transceiver

        public const UInt16 ERR_NONE = 0;	//No error
        public const Int16 ERR_UNKNOWN = -1;	//An unexpected error occurred
        public const Int16 ERR_BADVER = -2;	//A bad version was encountered
        public const Int16 ERR_BADPARAMS = -11;	//CardOpen() called with bad parameters
        public const Int16 ERR_NOHANDLES = -12;	//CardOpen() already has allocated too many handles
        public const Int16 ERR_NOCARD = -13;	//CardOpen() could not find a L71 card at the specified address
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
        public const Int16 ERR_PLXBUG = -75;	//PLX bug is causing problems

    }	//end class
}	//end namespace
