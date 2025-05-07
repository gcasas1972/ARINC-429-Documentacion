using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class L13W32
    {
        /**
        *
        *  LP1553-3 and LC1553-3 WIN32 DRIVER  Version 2.2.1  (02/01/2008)
        *  Copyright (c) 1997-2008
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   L13W32NET.CS -- 32-bit
        *                      L13 Driver Include Header File.
        *
        **/

        /**
        *
        *  Structs used by the L13 Driver.
        *
        **/

        [StructLayout(LayoutKind.Sequential)]
        public struct XMITFIELDS
        {
            public UInt32 ctrlflags;           //User writes message configuration optionvals
            public UInt16 flag1;               //Card writes message flag 1
            public UInt16 flag2;               //Card writes message flag 2
            public UInt16 errflags;            //Card writes errorval flags
            public UInt16 actflags;            //Card writes activity flags
            public UInt16 resptime1;           //Card writes response time 1
            public UInt16 resptime2;           //Card writes response time 2
            public UInt16 datacount;           //Card writes data count
            public UInt16 resv7;               //Reserved field
            public UInt32 timetag;             //Card writes time tag
            public UInt32 elapsetime;          //Card writes elapsed time
            public UInt16 resv12;              //Reserved field
            public UInt16 resv13;              //Reserved field
            public UInt16 resv14;              //Reserved field
            public UInt16 resv15;              //Reserved field
            public UInt16 resv16;              //Reserved field
            public UInt16 resv17;              //Reserved field
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

        /**
        *
        *  L13 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the L13 Driver.
        *
        **/

        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCConfig(UInt32 configval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCCreateList@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_BCCreateList(UInt32 listconfigval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCCreateMsg@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_BCCreateMsg(UInt32 configval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedFrame@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedFrame(UInt32 timeval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedMsg@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedMsg(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedRetry@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedRetry(UInt16 condition, UInt16 retries, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCTransmitMsg@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCTransmitMsg(ref XMITFIELDS xmitfieldsval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCTransmitMsgEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCTransmitMsgEx(ref XMITFIELDS xmitfieldsval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardClose(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardOpen@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_CardOpen(Int32 cardnum);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CardReset(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardStart(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardStop(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorCtrl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ErrorCtrl(UInt32 ctrlval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ErrorDefine(UInt32 defineval, UInt16 errvalue, Int32 countval, UInt16 wordpos, UInt16 bitpos, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorSent@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ErrorSent(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorTagBC@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ErrorTagBC(Int32 tagval, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorTagRT@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ErrorTagRT(Int32 tagval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_IntConfig(UInt16 configval, UInt16 count, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ListDataRd(ref UInt16 buf, Int32 count, UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ListDataWr(ref UInt16 buf, Int32 count, UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonConfig(UInt32 configval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonFilterSA@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonFilterSA(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonFilterTA@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonFilterTA(UInt32 tamask, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonIsRunning(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MonRd(ref UInt16 buf, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MsgDataRd(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MsgDataWr(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgFieldRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MsgFieldRd(UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgFieldWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MsgFieldWr(UInt32 fieldval, UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_PlayConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_PlayConfig(UInt32 configval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_PlayWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_PlayWr(ref UInt16 buf, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_RTConfig(UInt32 configval, Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTCreateList@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_RTCreateList(UInt32 listconfigval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTCreateMsg@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_RTCreateMsg(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTGetMsg@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_RTGetMsg(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTSWDWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_RTSWDWr(UInt16 swdval, Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValPackCWD@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_ValPackCWD(Int32 taval, Int32 trflag, Int32 saval, Int32 wcval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValUnpackCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ValUnpackCWD(UInt16 cwdval, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 wcval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_AddrDSP@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_AddrDSP(UInt32 addr);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_AddrHost@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_AddrHost(UInt32 addr);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCConfigEx(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCConfigMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_BCConfigMsg(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCCreateListEx@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_BCCreateListEx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCCreateListExx@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_BCCreateListExx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCGetMsg@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_BCGetMsg(Int32 index, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedAgain@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedAgain(Int32 index, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedBranch@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedBranch(UInt16 condition, Int32 destindex, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedBranchDin0@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedBranchDin0(Int32 destindex, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedBranchDin1@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedBranchDin1(Int32 destindex, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedBranchEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedBranchEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, Int32 destindex, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedBuild@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedBuild(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedCall(Int32 destindex, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedCallCond@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedCallCond(UInt16 condition, Int32 destindex, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedCallCondEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedCallCondEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, Int32 destindex, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedEntry@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedEntry(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedFrameEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedFrameEnd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedFrameStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedFrameStart(UInt32 timeval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedGap@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedGap(UInt16 gapval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedGoto@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedGoto(Int32 destindex, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedHalt@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedHalt(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedInt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedInt(UInt16 tagval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedIntCond@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedIntCond(UInt16 condition, UInt16 tagval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedIntCondEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedIntCondEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 tagval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedNop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedNop(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedPause@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedPause(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedPulse@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedPulse(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedPulse0@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedPulse0(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedPulse1@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedPulse1(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedRestart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedRestart(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedRetryEx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedRetryEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 retryflag, UInt16 retries, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedReturn@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedReturn(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSchedUser@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSchedUser(UInt32 useraddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSetEntry@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSetEntry(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BCSetTimeout@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BCSetTimeout(UInt16 timeoutval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_BlkAddr(Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_BlkOptRd(Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BlkOptWr(UInt16 rtopt, Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkPtrRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_BlkPtrRd(Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkPtrWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_BlkPtrWr(UInt32 descaddr, Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BlkRd(ref UInt16 block, Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BlkReset(Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkSWDRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_BlkSWDRd(Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkSWDWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BlkSWDWr(UInt16 swdval, Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BlkWipe(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_BlkWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_BlkWr(ref UInt16 block, Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardBoot@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardBoot(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardCloseAll@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardCloseAll();
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardConfig(Int32 enableflag, UInt16 command, UInt16 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardGetInfo@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_CardGetInfo(UInt16 infotype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardGetInfoEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardGetInfoEx(ref UInt16 bufmodel, UInt16 bufmodelcount, ref UInt16 buffeature, UInt16 buffeaturecount, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardInit@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CardInit();
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardIsRunning(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardNop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardNop(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardNopEx@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardNopEx(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardOpenEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_CardOpenEx(ref string cardname, Int32 cardnum);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardOpenExx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_CardOpenExx(ref string cardname, Int32 cardnum, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardResetEx@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CardResetEx(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardResume(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardTest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardTest(UInt16 level, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardTest0@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardTest0(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardTest1@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardTest1(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardTest2@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardTest2(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardTest3@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CardTest3(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CardTrigger@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CardTrigger(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CFGRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_CFGRdL(Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CFGWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CFGWrL(UInt32 value, Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_CmdAddr(Int32 index, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_CmdAlloc(Int32 count, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdBaseRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_CmdBaseRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdBaseWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CmdBaseWr(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CmdClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_CmdCountRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CmdCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdCtrlRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_CmdCtrlRd(Int32 index, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdCtrlWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CmdCtrlWr(UInt16 ctrlval, Int32 index, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdCurrRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_CmdCurrRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdCurrWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CmdCurrWr(UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CmdInit(UInt16 opcode, ref UInt16 block);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdInsert@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CmdInsert(ref UInt16 block, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdMaxRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_CmdMaxRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdMaxWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CmdMaxWr(UInt16 count, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdShotWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CmdShotWr(Int32 value, Int32 index, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdSkipWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CmdSkipWr(Int32 value, Int32 index, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdStackClr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CmdStackClr(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdStartRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_CmdStartRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdStartWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CmdStartWr(UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdTotalRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CmdTotalRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdTotalWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CmdTotalWr(Int32 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CmdWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CommCall(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommCheck@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CommCheck(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommDisable@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CommDisable(UInt16 command, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommDisableEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CommDisableEx(UInt16 command, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CommEnable(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_CommRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CommRdsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_CommRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommRun@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CommRun(ref UInt16 dataptr, UInt16 datacount, ref UInt16 codeptr, UInt16 codecount, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CommWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_CommWrsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_CommWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_CommWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DARClr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DARClr(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DARGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DARGet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DARRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_DARRdL(UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DARRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_DARRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DARSet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DARSet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DARWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DARWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DARWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DescAddr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_DescAddr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DescAlloc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_DescAlloc(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DescConfig@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DescConfig(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DescOptRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_DescOptRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DescOptWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DescOptWr(UInt16 descopt, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DescPtrRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_DescPtrRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DescPtrWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_DescPtrWr(UInt32 msgaddr, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DescRd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_DescRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DescWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_DescWr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_Div@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_Div(UInt32 diva, UInt32 divb);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DllUsageCount();
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_DPMMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DPMMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_DPMRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_DPMRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMRdsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DPMRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DPMRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_DPMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DPMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DPMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMWrsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DPMWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DPMWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DPMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_DPMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspBioClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DspBioClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspBioRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_DspBioRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspBioSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DspBioSet(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspHmClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DspHmClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspHmSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DspHmSet(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspIntfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DspIntfClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspIntfRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DspIntfRead(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspIntmClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DspIntmClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspIntmSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DspIntmSet(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspXfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DspXfClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_DspXfSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_DspXfSet(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrDesc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L13_ErrDesc(Int32 errval);
        public static string L13_ErrDesc(Int32 errval) { return Marshal.PtrToStringAnsi(_L13_ErrDesc(errval)); }
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrDescStr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L13_ErrDescStr(Int32 errval);
        public static string L13_ErrDescStr(Int32 errval) { return Marshal.PtrToStringAnsi(_L13_ErrDescStr(errval)); }
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrName@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L13_ErrName(Int32 errval);
        public static string L13_ErrName(Int32 errval) { return Marshal.PtrToStringAnsi(_L13_ErrName(errval)); }
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorIsTaggedBC@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ErrorIsTaggedBC(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorIsTaggedRT@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ErrorIsTaggedRT(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorResponse@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ErrorResponse(UInt16 responseval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorSync@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ErrorSync(Int32 value, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorTimeout@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ErrorTimeout(UInt16 timeoutval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorWatch@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ErrorWatch(Int32 value, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorWatchWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ErrorWatchWr(UInt32 value, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ErrorWatchWrEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ErrorWatchWrEx(UInt32 value, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ExtDinRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ExtDinRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ExtDinWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ExtDinWr(Int32 dinval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ExtDoutRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ExtDoutRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ExtDoutWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ExtDoutWr(Int32 doutval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_FileClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_FileClose(IntPtr handle);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_FileErr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_FileErr();
        [DllImport("L13W32.DLL", EntryPoint = "_L13_FileErrClr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_FileErrClr();
        [DllImport("L13W32.DLL", EntryPoint = "_L13_FileErrSet@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_FileErrSet();
        [DllImport("L13W32.DLL", EntryPoint = "_L13_FileOpenRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* L13_FileOpenRead(ref string filename);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_FileOpenWrite@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* L13_FileOpenWrite(ref string filename);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_FileRead@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_FileRead(IntPtr handle, IntPtr buffer, UInt16 count);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_FileSeek@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_FileSeek(IntPtr handle, UInt32 offset);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_FileTell@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_FileTell(IntPtr handle);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_FileWrite@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_FileWrite(IntPtr handle, IntPtr buffer, UInt16 count);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_GetHigh@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_GetHigh(UInt32 val);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_GetLow@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_GetLow(UInt32 val);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_GlobalRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_GlobalRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_GlobalWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_GlobalWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HandleClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_HandleClose(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HandleDel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_HandleDel(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HandleGet@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_HandleGet(ref string cardstr, ref Int32 cardnum, ref Int32 devnum, ref UInt32 sizval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HandleIns@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_HandleIns(ref string cardname, Int32 cardnum, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HandleOkay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_HandleOkay(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HandleOpen@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_HandleOpen(ref string cardname, Int32 cardnum, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HandleOpenWin95@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_HandleOpenWin95(ref string cardname, Int32 cardnum, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HandleOpenWinNT@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_HandleOpenWinNT(ref string cardname, Int32 cardnum, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HandleVer@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_HandleVer(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HandleVerPLX@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_HandleVerPLX(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HeapAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_HeapAlloc(UInt32 wordcount, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HeapAllocAll@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_HeapAllocAll(ref UInt32 wordcount, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HeapAllocAllDPM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_HeapAllocAllDPM(ref UInt16 wordcount, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HeapAllocDPM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_HeapAllocDPM(UInt16 wordcount, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HeapAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_HeapAllocEx(UInt16 configval, UInt32 wordcount, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HeapWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_HeapWipe(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_HeapWipeDPM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_HeapWipeDPM(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IndirectRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_IndirectRd(Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IndirectWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_IndirectWr(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_IntClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntDisable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_IntDisable(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_IntEnable(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntEnableCond@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_IntEnableCond(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntGet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* L13_IntGet(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_IntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_IntRd(ref UInt16 typevalval, ref UInt16 infoval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_IntReset(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_IntStatus(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_IntUninstall(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IORdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_IORdW(Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IOWINRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_IOWINRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IOWINWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_IOWINWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_IOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_IOWrW(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernBegin@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        unsafe public static extern Int32 L13_KernBegin(IntPtr* vxdptr, ref string cardstr, ref string cardname, Int32 busnum, Int32 devnum, Int32 funcnum);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernDev@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernDev(ref Int32 valueptr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernEnd(IntPtr vxdptr);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernIntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernIntClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernIntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernIntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernIntParam@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernIntParam(UInt32 clraddr, UInt32 clrwidth, UInt32 clrvalue, UInt32 stataddr, UInt32 statwidth, UInt32 statvalue, UInt32 statmask, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernIntStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernIntStatus(ref Int32 valueptr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernIntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernIntUninstall(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernIORdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernIORdW(ref UInt16 valueptr, Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernIOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernIOWrW(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernMEMFillW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernMEMFillW(UInt16 value, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernMEMRdL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernMEMRdL(ref UInt32 valueptr, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernMEMRdsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernMEMRdsL(ref UInt32 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernMEMRdsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernMEMRdsW(ref UInt16 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernMEMRdW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernMEMRdW(ref UInt16 valueptr, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernMEMWrL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernMEMWrL(UInt32 value, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernMEMWrsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernMEMWrsL(ref UInt32 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernMEMWrsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernMEMWrsW(ref UInt16 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernMEMWrW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernMEMWrW(UInt16 value, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernQuick@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernQuick(Int32 flag, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernStatus@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernStatus(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_KernStatusEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_KernStatusEx(ref UInt32 valueptr, UInt32 typeval, UInt32 index, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListAddrEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ListBlockRd(ref UInt16 buf, UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListBlockRdEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ListBlockRdEx(ref UInt16 buf, Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ListBlockWr(ref UInt16 buf, UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListBlockWrEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ListBlockWrEx(ref UInt16 buf, Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ListClear(UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ListConfig(UInt32 configval, Int32 count, UInt16 skipval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ListConfigEx(UInt32 configval, Int32 count, UInt16 skipval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListDataRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ListDataRdEx(ref UInt16 buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListDataWrEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ListDataWrEx(ref UInt16 buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListInit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListNextRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ListNextRd(UInt32 listaddr, ref UInt16 header);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListNextWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ListNextWr(UInt32 listaddr, ref UInt16 header);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListPostRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListPostWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListPreRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListPreWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ListStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ListStatus(UInt32 listaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MakeLong@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MakeLong(UInt16 valh, UInt16 vall);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_Mask@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_Mask(UInt32 dataval, UInt16 cntval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINFillW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MEMWINFillW(UInt16 value, UInt32 addrval, UInt32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINRdB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MEMWINRdB(UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINRdL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MEMWINRdL(UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINRdsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MEMWINRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINRdsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MEMWINRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINRdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MEMWINRdW(UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINWrB@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MEMWINWrB(UInt16 value, UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINWrL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MEMWINWrL(UInt32 value, UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINWrsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MEMWINWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINWrsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MEMWINWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MEMWINWrW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MEMWINWrW(UInt16 value, UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_Mod@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_Mod(UInt32 moda, UInt32 modb);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeIsBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ModeIsBC(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeIsMon@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ModeIsMon(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeIsNotBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ModeIsNotBC(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeIsNotMon@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ModeIsNotMon(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeIsNotPlay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ModeIsNotPlay(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeIsNotRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ModeIsNotRT(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeIsNotSerial@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ModeIsNotSerial(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeIsPlay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ModeIsPlay(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeIsRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ModeIsRT(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeIsSerial@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ModeIsSerial(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_ModeRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ModeWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ModeWr(UInt16 mode, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MonBlkRd(ref UInt16 buf, UInt32 bufcount, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonBlkRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MonBlkRdEx(ref UInt16 buf, UInt32 bufcount, UInt32 maxblkcnt, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonConfigEx(UInt32 configval, UInt32 moncount, UInt16 cardnum, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonConfigExx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonConfigExx(UInt32 configval, UInt32 seqaddr, UInt32 moncount, UInt16 cardnum, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonFilterSAEx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonFilterSAEx(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MonRdEx(ref UInt16 buf, UInt16 bufcount, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonResume(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonStart(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonStatus(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MonStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MonStop(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MsgBlockRd(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MsgBlockWr(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MsgCheck(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgCommRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MsgCommRd(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgCommWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MsgCommWr(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MsgConfig(UInt32 configval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MsgConfigEx(UInt32 configval, UInt16 cwd, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgCWD1Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MsgCWD1Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgCWD1Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MsgCWD1Wr(UInt16 cwd1, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgCWD2Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MsgCWD2Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgCWD2Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MsgCWD2Wr(UInt16 cwd2, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgErrorRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MsgErrorRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgErrorWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MsgErrorWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgFlagRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MsgFlagRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgFlagWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MsgFlagWr(UInt16 msgflag, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgIsAccessed@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_MsgReset(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgSWD1Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MsgSWD1Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_MsgSWD2Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_MsgSWD2Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_Mul@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_Mul(UInt32 mula, UInt32 mulb);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_PlayClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_PlayClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_PlayConfigEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_PlayConfigEx(UInt32 configval, UInt32 playcount, UInt32 seqcount, UInt16 cardnum, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_PlayConfigExx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_PlayConfigExx(UInt32 configval, UInt32 playaddr, UInt32 playcount, UInt32 seqaddr, UInt32 seqcount, UInt16 cardnum, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_PlayWrEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_PlayWrEx(ref UInt16 buf, UInt16 bufcount, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_PortRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_PortRd(Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_PortWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_PortWr(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ProgRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_ProgRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ProgWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ProgWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMFill@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_RAMFill(UInt16 value, UInt32 addrval, UInt32 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMIsDPM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_RAMIsDPM(UInt32 addrval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_RAMRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_RAMRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMRdsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_RAMRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_RAMRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_RAMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_RAMWipe(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMWipeEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_RAMWipeEx(UInt16 value, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_RAMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_RAMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMWrsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_RAMWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_RAMWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RAMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_RAMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_RTConfigEx(UInt32 configval, Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTConfigExx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_RTConfigExx(UInt32 configval, Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTCreateListEx@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_RTCreateListEx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTCreateListExx@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_RTCreateListExx(UInt32 listconfigval, Int32 skipval, Int32 count, UInt32 msgconfigval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_RTReset(Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_RTStatus(Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_RTSWDRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_RTSWDRd(Int32 taval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedBuild@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SchedBuild(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 freq, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedBuildEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SchedBuildEx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 freq, ref Int32 period, IntPtr buf, UInt32 bufsize, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedBuildExx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SchedBuildExx(UInt32 frametime, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 period, IntPtr buf, UInt32 bufsize, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedCalc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SchedCalc(ref UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedDisplay@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_SchedDisplay(UInt32 nummsgs, ref UInt32 count);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedHook@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_SchedHook(Int32 index, IntPtr ptr);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedInsEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SchedInsEnd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedInsMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SchedInsMsg(UInt32 index, ref UInt32 msgaddr, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedInsStart@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SchedInsStart(UInt32 frametime, UInt32 count, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedMaxval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_SchedMaxval(ref UInt32 arrayval, UInt32 arrayvalcount);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SchedMinval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_SchedMinval(ref UInt32 arrayval, UInt32 arrayvalcount);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEEPokeW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SEEPokeW(Int32 value, Int32 numbits, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEERdBit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SEERdBit(ref Int32 valueptr, Int32 bitnum, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEERdL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SEERdL(ref UInt32 valueptr, Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEERdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SEERdW(ref Int32 valueptr, Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEEWrBit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SEEWrBit(Int32 value, Int32 bitnum, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEEWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SEEWrL(UInt32 value, Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEEWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SEEWrW(Int32 value, Int32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEMMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_SEMMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEMMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_SEMMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_SEMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SEMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_SEMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SerialClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SerialClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SerialConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SerialConfig(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SerialConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SerialConfigEx(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SerialStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_SerialStatus(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_SerialWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_SerialWr(ref UInt16 buf, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_Shl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_Shl(UInt32 dataval, UInt16 cntval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_Shr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_Shr(UInt32 dataval, UInt16 cntval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_TimerClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_TimerClear(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_TimerRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_TimerRd(UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_TimerResolution@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_TimerResolution(Int32 timerresol, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_TimerResolutionEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_TimerResolutionEx(UInt16 timershift, UInt32 handleval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValAsciiCmpi@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ValAsciiCmpi(ref string str1, ref string str2);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValAsciiCpy@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L13_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count);
        public static string L13_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count) { return Marshal.PtrToStringAnsi(_L13_ValAsciiCpy(ref strdest, ref strsrc, count)); }
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValAsciiTrimLead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ValAsciiTrimLead(ref string buf);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValAsciiTrimTrail@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ValAsciiTrimTrail(ref string buf);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValFromAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L13_ValFromAscii(ref string asciistr, Int32 radixval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValGetBits@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_ValGetBits(UInt16 oldvalue, Int32 startbit, Int32 endbit);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValIncAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L13_ValIncAscii(ref string asciistr);
        public static string L13_ValIncAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_L13_ValIncAscii(ref asciistr)); }
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValInccAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L13_ValInccAscii(ref string asciistr);
        public static string L13_ValInccAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_L13_ValInccAscii(ref asciistr)); }
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValIsLower@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ValIsLower(Int32 value);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValLenAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ValLenAscii(Int32 numbits, Int32 radixval);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValPackRTCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_ValPackRTCWD(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 count);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValPutBits@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L13_ValPutBits(UInt16 oldvalue, UInt16 newfld, Int32 startbit, Int32 endbit);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValToAscii@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L13_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval);
        public static string L13_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval) { return Marshal.PtrToStringAnsi(_L13_ValToAscii(value, ref asciistr, numbits, radixval)); }
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValToUpper@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L13_ValToUpper(Int32 value);
        [DllImport("L13W32.DLL", EntryPoint = "_L13_ValUnpackRTCWD@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L13_ValUnpackRTCWD(UInt16 cwd, ref Int32 bcastflag, ref Int32 mcflag, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 count);

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
        public const UInt32 RTCFG_WIPE123 = 0x04000000;
        public const UInt32 RTCFG_WIPECWD = 0x08000000;
        public const UInt32 RTCFG_MODEL = 0x00000000;
        public const UInt32 RTCFG_RAM = 0x00100000;
        public const UInt32 RTCFG_DPRAM = 0x00200000;

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
        *  Playback configuration options
        *
        **/

        public const UInt32 PLAYCFG_DEFAULT = 0x00000000;
        public const UInt32 PLAYCFG_ENABLE = 0x00000000;
        public const UInt32 PLAYCFG_DISABLE = 0x00000001;
        public const UInt32 PLAYCFG_16K = 0x00000000;
        public const UInt32 PLAYCFG_ALLAVAIL = 0x00008000;
        public const UInt32 PLAYCFG_32K = 0x00010000;
        public const UInt32 PLAYCFG_64K = 0x00020000;
        public const UInt32 PLAYCFG_128K = 0x00040000;
        public const UInt32 PLAYCFG_DPRAM = 0x00080000;

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

        public const UInt32 INFOTYPE_PLAT = 0x0001;           //Returns the L13 platform type
        public const UInt32 INFOTYPE_PROD = 0x0002;           //Returns the L13 product type
        public const UInt32 INFOTYPE_DASH = 0x0003;           //Returns the L13 dash number
        public const UInt32 INFOTYPE_VERSION = 0x0004;           //Returns the L13 version number
        public const UInt32 INFOTYPE_DATE = 0x0005;           //Returns the L13 version date
        public const UInt32 INFOTYPE_MODEL = 0x0006;           //Returns the L13 model number
        public const UInt32 INFOTYPE_MAXCOUNT = 0x0007;           //Returns the number of terminals the L13 can simulate
        public const UInt32 INFOTYPE_MULTIMODE = 0x0008;           //Returns whether L13 can simulate multi-modes
        public const UInt32 INFOTYPE_ERRORGEN = 0x0009;           //Returns whether L13 can generate errors
        public const UInt32 INFOTYPE_CONCURMON = 0x000A;           //Returns whether L13 has a concurrent monitor
        public const UInt32 INFOTYPE_MONFILTER = 0x000B;           //Returns whether L13 has a monitor filter
        public const UInt32 INFOTYPE_USERCODE = 0x000C;           //Returns whether L13 handles user code
        public const UInt32 INFOTYPE_LISTBUF = 0x000D;           //Returns whether L13 handles list buffering
        public const UInt32 INFOTYPE_MONFAST = 0x000E;           //Returns whether L13 has a fast monitor
        public const UInt32 INFOTYPE_MONDMA = 0x000F;           //Returns whether L13 has a dma monitor
        public const UInt32 INFOTYPE_MONBRAKE = 0x0010;           //Returns whether L13 has a monitor brake
        public const UInt32 INFOTYPE_PLAY = 0x0011;           //Returns whether L13 has playback capability

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
        *  Bit fields of the message error flag
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
        *  L13 IFGA Registers
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

        public const UInt32 EREG_STAT = 0x0180;                 //Status register (RD)
        public const UInt32 EREG_STATCLR = 0x0081;                 //Status clear register (WR)
        public const UInt32 EREG_STATDEC = 0x0082;                 //Decoder status register (RD)
        public const UInt32 EREG_VALA = 0x0084;                 //Decoder word value A register
        public const UInt32 EREG_VALAL = 0x0084;                 //Decoder low word value A register
        public const UInt32 EREG_VALAH = 0x0085;                 //Decoder high word value A register
        public const UInt32 EREG_VALB = 0x0086;                 //Decoder word value B register
        public const UInt32 EREG_VALBL = 0x0086;                 //Decoder low word value B register
        public const UInt32 EREG_VALBH = 0x0087;                 //Decoder high word value B register
        public const UInt32 EREG_GAPE = 0x0088;                 //Encoder gap register
        public const UInt32 EREG_CTRLE = 0x0089;                 //Encoder control register
        public const UInt32 EREG_VALE = 0x008A;                 //Encoder value register
        public const UInt32 EREG_VALEL = 0x008A;                 //Encoder low value register
        public const UInt32 EREG_VALEH = 0x008B;                 //Encoder high value register
        public const UInt32 EREG_ERRE = 0x008C;                 //Encoder error register
        public const UInt32 EREG_FT = 0x008E;                 //Frame time register
        public const UInt32 EREG_RST = 0x008F;                 //Reset register
        public const UInt32 EREG_GAPA = 0x0090;                 //Decoder gap time A register
        public const UInt32 EREG_GAPB = 0x0091;                 //Decoder gap time B register
        public const UInt32 EREG_GAPTO = 0x0092;                 //Decoder gap timeout register
        public const UInt32 EREG_CFGD = 0x0094;                 //Decoder configuration register
        public const UInt32 EREG_CFGE = 0x0095;                 //Encoder configuration register
        public const UInt32 EREG_CFGINT = 0x0096;                 //Interrupt configuration register
        public const UInt32 EREG_ID = 0x0097;                 //Identification register

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
        public const UInt32 INTTYPE_SERIAL = 0x0009;               //Serial empty

        /**
        *
        *  Timer resolutions.
        *
        **/

        public const UInt16 TIMERRESOL_1US = 1;	//1us timer resolution, 1:11:34
        public const UInt16 TIMERRESOL_16US = 2;	//16us timer resolution, 19:05:19 range
        public const UInt16 TIMERRESOL_1024US = 3;	//1024us timer resolution, 50 day range

        public const UInt16 MONRD_MAX_COUNT = 64;

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
        public const Int16 ERR_NOCARD = -13;	//CardOpen() could not find a L13 card at the specified address
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
