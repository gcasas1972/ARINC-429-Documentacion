using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class C41W32
    {
        /**
        *
        *  CM429-1 WIN32 DRIVER  Version 1.8  (11/30/2006)
        *  Copyright (c) 1997-2006
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   C41W32NET.CS -- 32-bit
        *                      CM429-1 Driver Include Header File.
        *
        **/

        /**
        *
        *  CM429-1 Driver functions.
        *
        **/

        /**
        *
        *  CM429-1 717 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the CM429-1 Driver.
        *
        **/

        [DllImport("C41W32.DLL", EntryPoint = "_C41_AsciiFrom@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_AsciiFrom(ref string asciistr, Int32 radixval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_AsciiTo@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_AsciiTo(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BCDGetData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BCDGetData(UInt32 msg, UInt16 msb, UInt16 lsb);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BCDGetMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BCDGetMant(UInt32 msg, UInt16 sigdig);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BCDGetSign@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_BCDGetSign(UInt32 msg);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BCDGetSSM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_BCDGetSSM(UInt32 msg);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BCDGetVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_BCDGetVal(ref string buf, UInt32 msg, UInt16 sigdig, ref string resolstr);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BCDPutData@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BCDPutData(UInt32 msg, UInt32 value, UInt16 msb, UInt16 lsb);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BCDPutMant@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BCDPutMant(UInt32 msg, UInt32 value, UInt16 sigdig, UInt16 sign);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BCDPutSign@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BCDPutSign(UInt32 msg, UInt16 sign);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BCDPutSSM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BCDPutSSM(UInt32 msg, UInt16 value);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BCDPutVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BCDPutVal(ref string buf, UInt32 msg, UInt16 sigdig, ref string resolstr);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BNRGetData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BNRGetData(UInt32 msg, UInt16 msb, UInt16 lsb);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BNRGetMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BNRGetMant(UInt32 msg, UInt16 sigbit);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BNRGetSign@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_BNRGetSign(UInt32 msg);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BNRGetSSM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_BNRGetSSM(UInt32 msg);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BNRGetVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_BNRGetVal(ref string buf, UInt32 msg, UInt16 sigbit, ref string resolstr);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BNRPutData@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BNRPutData(UInt32 msg, UInt32 value, UInt16 msb, UInt16 lsb);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BNRPutMant@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BNRPutMant(UInt32 msg, UInt32 value, UInt16 sigbit, UInt16 twos);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BNRPutSign@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BNRPutSign(UInt32 msg, UInt16 twos);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BNRPutSSM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BNRPutSSM(UInt32 msg, UInt16 value);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_BNRPutVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_BNRPutVal(ref string buf, UInt32 msg, UInt16 sigbit, ref string resolstr);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ChCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ChCheck(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ChClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ChClear(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ChConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ChPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_ChPause(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ChResume@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_ChResume(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CloseAll@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CloseAll();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CloseCard@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CloseCard(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ExtRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ExtRd(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ExtWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_ExtWr(Int32 extflag, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FilterDefault@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FilterDefault(Int32 msgnum, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FilterSet@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FilterSet(Int32 labelval, Int32 sdimask, Int32 msgnum, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FldGetData@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_FldGetData(UInt32 msgval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FldGetLabel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_FldGetLabel(UInt32 msgval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FldGetParity@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_FldGetParity(UInt32 msgval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FldGetSDI@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_FldGetSDI(UInt32 msgval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FldGetValue@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_FldGetValue(UInt32 msgval, UInt16 startbit, UInt16 endbit);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FldPutData@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_FldPutData(UInt32 msgval, UInt32 data);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FldPutLabel@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_FldPutLabel(UInt32 msgval, UInt16 label);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FldPutSDI@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_FldPutSDI(UInt32 msgval, UInt16 sdi);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FldPutValue@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_FldPutValue(UInt32 msgval, UInt32 dataval, UInt16 startbit, UInt16 endbit);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_IntDin@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_IntDin(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_IntRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_IntRd(ref UInt16 typevalval, ref UInt16 infoval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ListMakeRcv@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_ListMakeRcv(UInt16 count, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ListMakeXmt@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_ListMakeXmt(UInt16 count, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ListRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_ListRd(ref UInt32 msgval, UInt16 listaddr, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ListStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ListStatus(UInt16 listaddr, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ListWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_ListWr(UInt32 msgval, UInt16 listaddr, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MemPeek@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_MemPeek(UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MemPoke@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MemPoke(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgArincRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_MsgArincRd(Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgArincWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MsgArincWr(UInt32 msgval, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_MsgBlockRd(ref UInt16 valueptr, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_MsgBlockWr(ref UInt16 valueptr, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgCommRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_MsgCommRd(ref UInt16 valueptr, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgCommWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_MsgCommWr(ref UInt16 valueptr, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_MsgConfig(UInt16 configval, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgEncoderRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_MsgEncoderRd(Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgEncoderWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MsgEncoderWr(UInt32 msgval, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_OpenCard@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_OpenCard(Int32 cardnum);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Reset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_Reset(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Restart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_Restart(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedBranch@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedBranch(Int32 schindex, Int32 condition, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedBuild@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedBuild(Int32 basevalmsgnum, UInt16 nummsgs, ref Int32 minperiod, ref Int32 maxperiod, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedCall@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedCall(Int32 schindex, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedGap@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedGap(UInt16 gapval, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedHalt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedHalt(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedInt@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedInt(UInt16 tagval, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedMsg(Int32 msgnum, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedPause(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedPulse@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedPulse(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedRestart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedRestart(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedRet@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedRet(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedStart(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SelfTest@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SelfTest(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SeqClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SeqClear(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SeqConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SeqConfig(UInt16 configval, Int32 interval, Int32 cardnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SeqRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_SeqRd(ref UInt32 msgval, ref UInt32 stampval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Start@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_Start(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Stop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_Stop(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_TimerClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_TimerClear(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_TimerRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_TimerRd(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_TimerResolution@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_TimerResolution(Int32 timerresol, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717Boot@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717Boot(Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717FrameWipe@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717FrameWipe(Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SubFrmClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SubFrmClear(Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SubFrmDataWipe@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SubFrmDataWipe(Int32 subframe, Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SubFrmPtrDefault@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SubFrmPtrDefault(Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SubFrmPtrSet@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SubFrmPtrSet(Int32 subfrmnum, Int32 destsubfrm, Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SubFrmRecordWipe@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SubFrmRecordWipe(Int32 subframe, Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SubFrmWordConfig@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SubFrmWordConfig(Int32 configval, Int32 subframe, Int32 wordnum, Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SubFrmWordConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SubFrmWordConfigEx(Int32 configval, Int32 subframe, Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SubFrmWordRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SubFrmWordRd(Int32 subframe, Int32 wordnum, Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SyncTest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SyncTest(Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SyncWordDefault@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SyncWordDefault(Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_717SyncWordSet@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_717SyncWordSet(Int32 sync1, Int32 sync2, Int32 sync3, Int32 sync4, Int32 channum, Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Ch717Disable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_Ch717Disable(Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Ch717Enable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_Ch717Enable(Int32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_AcgaRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_AcgaRd(UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_AcgaWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_AcgaWr(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_AsciiToMant@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_AsciiToMant(ref string str, ref Int32 mant, ref Int32 exp);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CardClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CardClose(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CardInit@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CardInit();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CardOpen@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CardOpen(Int32 cardnum);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CardOpenEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CardOpenEx(ref string cardname, Int32 rcvcount, Int32 xmtcount, Int32 cardnum);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CardOpenExx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CardOpenExx(ref string cardname, Int32 rcvcount, Int32 xmtcount, Int32 cardnum, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ChPauseCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ChPauseCheck(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ChStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_ChStart(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ChStop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_ChStop(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CommCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CommCall(UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CommCheck@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CommCheck(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CommDisable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CommDisable(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CommEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CommEnable(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CommRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_CommRd(UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CommRun@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CommRun(ref UInt16 dataptr, UInt16 datacount, ref UInt16 codeptr, UInt16 codecount, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CommStrRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CommStrRd(ref UInt16 valueptr, UInt16 addrval, UInt16 count, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CommStrWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CommStrWr(ref UInt16 valueptr, UInt16 addrval, UInt16 count, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CommTxen@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CommTxen(UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CommWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CommWr(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ConvFromArinc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_ConvFromArinc(UInt32 msgval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ConvToArinc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_ConvToArinc(UInt32 msgval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleAdvance@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CycleAdvance();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleBuild@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleBuild(Int32 basevalmsgnum, UInt32 nummsgs, ref Int32 minperiod, ref Int32 maxperiod, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleBuildEx@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleBuildEx(Int32 basevalmsgnum, Int32 nummsgs, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleBuildSt@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleBuildSt(Int32 basevalmsgnum, Int32 nummsgs, ref Int32 minperiod, ref Int32 maxperiod, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleCalc@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CycleCalc();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleCheck(ref Int32 minperiod, ref Int32 maxperiod);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleCheckEnd@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleCheckEnd();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleCheckMiddle@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleCheckMiddle(Int32 msgnum, UInt32 minlen, UInt32 midlen, UInt32 maxlen);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleCheckReal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleCheckReal(Int32 msgnum, UInt32 minlen, UInt32 midlen, UInt32 maxlen);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleCheckStart@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleCheckStart();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleConflicts@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CycleConflicts();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleDisplay@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        unsafe public static extern void C41_CycleDisplay(Int32 nummsgs, ref UInt32 count, ref UInt32* data);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleDivide@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleDivide();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleFix@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CycleFix();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleFixEnd@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleFixEnd();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleFixMiddle@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleFixMiddle(UInt32 conflicts);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleFixStart@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleFixStart();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleHook@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleHook(Int32 index, IntPtr ptr);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleInsert@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleInsert(UInt32 eventvals, UInt32 index, Int32 msgnum, UInt32 gapval, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleInsertEnd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleInsertEnd(UInt32 eventvals, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleInsertStart@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleInsertStart(UInt32 eventvals, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleLayout@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleLayout();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleMaxval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CycleMaxval(ref UInt32 arrayval, UInt32 arrayvalcount);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleMinval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CycleMinval(ref UInt32 arrayval, UInt32 arrayvalcount);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleParse@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleParse(Int32 basevalmsgnum, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleReset@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleReset();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleRotate@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CycleRotate();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleShift@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleShift(Int32 msgnum, Int32 value);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleSlide@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_CycleSlide();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleSlideEnd@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleSlideEnd();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleSlideMiddle@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleSlideMiddle(UInt32 index, UInt32 count, UInt32 conflicts);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleSlideStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleSlideStart(UInt32 factor);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleSort@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleSort();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleToBit@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CycleToBit(UInt32 value);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleToMsec@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CycleToMsec(UInt32 value);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleUnsort@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_CycleUnsort();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_CycleWalk@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_CycleWalk();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DataClear@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_DataClear(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DataGet@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_DataGet(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DataRead@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_DataRead(UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DataSet@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_DataSet(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DataWrite@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_DataWrite(UInt16 value, UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Div@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_Div(UInt32 diva, UInt32 divb);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DPMIAllocSel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_DPMIAllocSel(UInt16 segval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DPMIDosAlloc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_DPMIDosAlloc(UInt16 paras);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DPMIDosFree@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_DPMIDosFree(UInt16 selector);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DPMIFreeSel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_DPMIFreeSel(UInt16 selector);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DPMIIntSim@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_DPMIIntSim(UInt16 intnum, IntPtr dpmireg);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DPMIPresent@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_DPMIPresent();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DspIntmClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_DspIntmClear(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DspIntmSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_DspIntmSet(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DspXfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_DspXfClear(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_DspXfSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_DspXfSet(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ErrDesc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _C41_ErrDesc(Int32 errval);
        public static string C41_ErrDesc(Int32 errval) { return Marshal.PtrToStringAnsi(_C41_ErrDesc(errval)); }
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ErrDescStr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _C41_ErrDescStr(Int32 errval);
        public static string C41_ErrDescStr(Int32 errval) { return Marshal.PtrToStringAnsi(_C41_ErrDescStr(errval)); }
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ErrName@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _C41_ErrName(Int32 errval);
        public static string C41_ErrName(Int32 errval) { return Marshal.PtrToStringAnsi(_C41_ErrName(errval)); }
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ExpandMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_ExpandMant(ref Int32 mant, ref Int32 exp);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ExtDinWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ExtDinWr(Int32 dinvalue, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FileClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_FileClose(Int32 handle);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FileErr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FileErr();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FileErrClr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_FileErrClr();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FileErrSet@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_FileErrSet();
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FileOpenRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FileOpenRead(ref string filename);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FileOpenWrite@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FileOpenWrite(ref string filename);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FileRead@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FileRead(Int32 handle, IntPtr buffer, UInt16 count);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FileSeek@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FileSeek(Int32 handle, UInt32 offset);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FileTell@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_FileTell(Int32 handle);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FileWrite@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FileWrite(Int32 handle, IntPtr buffer, UInt16 count);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FilterAddr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_FilterAddr(Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FilterClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FilterClear(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FilterFill@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FilterFill(ref UInt16 msgaddr, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FilterRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FilterRd(ref UInt16 msgaddr, Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FilterWipe@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FilterWipe(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FilterWr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_FilterWr(ref UInt16 msgaddr, Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_FldGetParBit@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_FldGetParBit(UInt32 msgval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_GetHigh@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_GetHigh(UInt32 val);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_GetLow@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_GetLow(UInt32 val);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_GlobalRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_GlobalRd(UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_GlobalWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_GlobalWr(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HandleAssign@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_HandleAssign(UInt16 sizval, UInt16 memval, UInt16 ioval, UInt16 irqval, Int32 cardnum);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HandleClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_HandleClose(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HandleDel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_HandleDel(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HandleGet@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_HandleGet(ref UInt16 sizval, ref UInt16 memval, ref UInt16 ioval, ref UInt16 irqval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HandleIns@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_HandleIns(ref string cardname, Int32 rcvcount, Int32 xmtcount, Int32 cardnum, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HandleOkay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_HandleOkay(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HandleOpen@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_HandleOpen(ref string cardname, Int32 rcvcount, Int32 xmtcount, Int32 cardnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HandleVer@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_HandleVer(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HeapAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_HeapAlloc(UInt16 wordcount, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HeapCheck@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_HeapCheck(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HeapClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_HeapClear(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_HeapWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_HeapWipe(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_InitFilt@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_InitFilt(UInt16 chanflag, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_InitHeap@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_InitHeap(UInt16 heapsize, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_InitInt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_InitInt(UInt16 intsize, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_InitMsg@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_InitMsg(UInt16 msgcount, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_InitSch@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_InitSch(UInt16 chancount, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_InitSeq@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_InitSeq(UInt16 seqsize, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_IntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_IntClear(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_INTDisable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_INTDisable(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_INTEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_INTEnable(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_INTEnableCond@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_INTEnableCond(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_IntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_IntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_IntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_IntUninstall(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_IntWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_IntWipe(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Invoke@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_Invoke(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Invokee@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_Invokee(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernBegin@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        unsafe public static extern Int32 C41_KernBegin(IntPtr* vxdptr, ref string cardname, UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernEEPRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernEEPRdsW(ref UInt16 bufptr, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernEEPRdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernEEPRdW(ref UInt16 valueptr, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernEEPWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernEEPWrsW(ref UInt16 bufptr, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernEEPWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernEEPWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernEnd(IntPtr vxdptr);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernIntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernIntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernIntParam@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernIntParam(UInt32 clraddr, UInt32 clrwidth, UInt32 clrvalue, UInt32 stataddr, UInt32 statwidth, UInt32 statvalue, UInt32 statmask, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernIntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernIntUninstall(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernIORdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernIORdW(ref UInt16 valueptr, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernIOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernIOWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernMEMFillW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernMEMFillW(UInt16 value, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernMEMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernMEMRdsW(ref UInt16 bufptr, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernMEMRdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernMEMRdW(ref UInt16 valueptr, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernMEMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernMEMWrsW(ref UInt16 bufptr, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernMEMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernMEMWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernQuick@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernQuick(Int32 flag, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_KernStatusEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_KernStatusEx(ref UInt32 valueptr, UInt32 typeval, UInt32 index, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ListSetRcv@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_ListSetRcv(UInt16 listaddr, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ListSetXmt@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_ListSetXmt(UInt16 listaddr, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MakeLong@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_MakeLong(UInt16 valh, UInt16 vall);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MantToAscii@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _C41_MantToAscii(ref string buf, Int32 mant, Int32 exp);
        public static string C41_MantToAscii(ref string buf, Int32 mant, Int32 exp) { return Marshal.PtrToStringAnsi(_C41_MantToAscii(ref buf, mant, exp)); }
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Mask@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_Mask(UInt32 dataval, UInt16 cntval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MaxMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MaxMant(ref Int32 mant, ref Int32 exp);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MemFill@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MemFill(UInt16 value, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MemStrRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MemStrRd(ref UInt16 valueptr, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MemStrWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MemStrWr(ref UInt16 valueptr, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MEMWINRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_MEMWINRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MEMWINRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_MEMWINRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MEMWINRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_MEMWINRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MEMWINWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MEMWINWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MEMWINWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MEMWINWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MEMWINWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MEMWINWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MemWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MemWipe(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Mod@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_Mod(UInt32 moda, UInt32 modb);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_MsgAddr(Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgArincPeek@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_MsgArincPeek(Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgArincPoke@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MsgArincPoke(UInt32 msgval, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_MsgClear(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgDisable@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_MsgDisable(Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgEnable@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_MsgEnable(Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgEncoderPeek@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_MsgEncoderPeek(Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgEncoderPoke@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_MsgEncoderPoke(UInt32 msgval, Int32 msgnum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_MsgReset(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_MsgWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_MsgWipe(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Mul@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_Mul(UInt32 mula, UInt32 mulb);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_NormalMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_NormalMant(ref Int32 mant, ref Int32 exp);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_PortRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_PortRd(UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_PortWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_PortWr(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ProgRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_ProgRd(UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ProgWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_ProgWr(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_RAMRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_RAMRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_RAMRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_RAMRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_RAMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_RAMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_RAMWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_RAMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_RAMWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_RAMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_RAMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_RAMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_SchedAddr(Int32 schindex, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedClear(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedFixedGap@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedFixedGap(UInt16 gapval, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedInsert@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedInsert(UInt16 schflag, UInt16 schopcode, UInt16 schoperand, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedNop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedNop(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedRd(ref UInt16 valueptr, Int32 schindex, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedUser@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedUser(UInt16 useraddr, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedWipe@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedWipe(Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SchedWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SchedWr(ref UInt16 valueptr, Int32 schindex, Int32 channum, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SeqInterval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SeqInterval(Int32 interval, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SeqIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SeqIsRunning(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SeqRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_SeqRdEx(ref UInt16 buf, UInt32 bufcount, UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SeqStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_SeqStart(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SeqStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_SeqStop(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SeqWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_SeqWipe(UInt32 handleval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Shl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_Shl(UInt32 dataval, UInt16 cntval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Shr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_Shr(UInt32 dataval, UInt16 cntval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_SignMant@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C41_SignMant(ref string str);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValAsciiCmpi@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ValAsciiCmpi(ref string str1, ref string str2);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValAsciiCpy@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _C41_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count);
        public static string C41_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count) { return Marshal.PtrToStringAnsi(_C41_ValAsciiCpy(ref strdest, ref strsrc, count)); }
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValAsciiTrimLead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_ValAsciiTrimLead(ref string buf);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValAsciiTrimTrail@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C41_ValAsciiTrimTrail(ref string buf);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValFromAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C41_ValFromAscii(ref string asciistr, Int32 radixval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValIncAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _C41_ValIncAscii(ref string asciistr);
        public static string C41_ValIncAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_C41_ValIncAscii(ref asciistr)); }
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValInccAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _C41_ValInccAscii(ref string asciistr);
        public static string C41_ValInccAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_C41_ValInccAscii(ref asciistr)); }
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValIsLower@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ValIsLower(Int32 value);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValLenAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ValLenAscii(Int32 numbits, Int32 radixval);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValToAscii@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _C41_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval);
        public static string C41_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval) { return Marshal.PtrToStringAnsi(_C41_ValToAscii(value, ref asciistr, numbits, radixval)); }
        [DllImport("C41W32.DLL", EntryPoint = "_C41_ValToUpper@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_ValToUpper(Int32 value);
        [DllImport("C41W32.DLL", EntryPoint = "_C41_Wipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C41_Wipe(UInt32 handleval);

        public const UInt32 SDI00 = 0x0001;					//Enable SDI00
        public const UInt32 SDI01 = 0x0002;					//Enable SDI01
        public const UInt32 SDI10 = 0x0004;					//Enable SDI10
        public const UInt32 SDI11 = 0x0008;					//Enable SDI11
        public const UInt32 SDIALL = 0x000F;					//Enable all SDIs

        public const UInt16 RCVCH0 = 0;	//Receive  channel 0
        public const UInt16 RCVCH1 = 1;	//Receive  channel 1
        public const UInt16 RCVCH2 = 2;	//Receive  channel 2
        public const UInt16 RCVCH3 = 3;	//Receive  channel 3
        public const UInt16 XMTCH0 = 4;	//Transmit channel 0
        public const UInt16 XMTCH1 = 5;	//Transmit channel 1

        public const UInt16 RCH0 = 0;	//Receive  channel 0
        public const UInt16 RCH1 = 1;	//Receive  channel 1
        public const UInt16 RCH2 = 2;	//Receive  channel 2
        public const UInt16 RCH717 = 2;	//Receive  717 channel (2)
        public const UInt16 RCH3 = 3;	//Receive  channel 3
        public const UInt16 TCH4 = 4;	//Transmit channel 0
        public const UInt16 TCH5 = 5;	//Transmit channel 1

        public const UInt16 BADCH = 0;	//Missing channel
        public const UInt16 RCVCH = 1;	//Receive channel
        public const UInt16 XMTCH = 2;	//Transmit channel
        public const UInt16 RCV717CH = 3;	//717 Receive Channel

        public const UInt16 LIST_STAT_EMPTY = 0;	//List buffer is empty
        public const UInt16 LIST_STAT_PARTIAL = 1;	//List buffer is partially filled
        public const UInt16 LIST_STAT_FULL = 2;	//List buffer is full

        public const UInt16 PROC_PRE = 1;	//Pre-process
        public const UInt16 PROC_POST = 2;	//Post-process
        public const UInt16 PROC_FORE = 3;	//Foreground process

        public const UInt32 CHCFG_DEFAULT = 0x00000000;
        public const UInt32 CHCFG_NOEVEN = 0x00000001;
        public const UInt32 CHCFG_PAREVEN = 0x00000002;
        public const UInt32 CHCFG_HIGHSPEED = 0x00000004;
        public const UInt32 CHCFG_LOWSPEED = 0x00000000;
        public const UInt32 CHCFG_ACTIVE = 0x00000008;
        public const UInt32 CHCFG_INACTIVE = 0x00000000;
        public const UInt32 CHCFG_SYNC = 0x00000010;
        public const UInt32 CHCFG_SYNCOFF = 0x00000000;
        public const UInt32 CHCFG_SERVICE = 0x00000020;
        public const UInt32 CHCFG_SERVICEOFF = 0x00000000;
        public const UInt32 CHCFG_TIMETAG = 0x00000040;
        public const UInt32 CHCFG_TIMETAGOFF = 0x00000000;
        public const UInt32 CHCFG_ELAPSE = 0x00000080;
        public const UInt32 CHCFG_ELAPSEOFF = 0x00000000;
        public const UInt32 CHCFG_MAXMIN = 0x00000100;
        public const UInt32 CHCFG_MAXMINOFF = 0x00000000;
        public const UInt32 CHCFG_WRAPTEST = 0x00000200;
        public const UInt32 CHCFG_WRAPTESTOFF = 0x00000000;
        public const UInt32 CHCFG_SDI00 = 0x00001000;
        public const UInt32 CHCFG_SDI01 = 0x00002000;
        public const UInt32 CHCFG_SDI10 = 0x00004000;
        public const UInt32 CHCFG_SDI11 = 0x00008000;
        public const UInt32 CHCFG_SDIALL = 0x00000000;
        public const UInt32 CHCFG_SEQSEL = 0x00010000;
        public const UInt32 CHCFG_SEQALL = 0x00020000;
        public const UInt32 CHCFG_SEQOFF = 0x00000000;
        public const UInt32 CHCFG_INTSCH = 0x00100000;
        public const UInt32 CHCFG_INTHALT = 0x00200000;
        public const UInt32 CHCFG_INTPAUSE = 0x00400000;
        public const UInt32 CHCFG_INTLIST = 0x01000000;
        public const UInt32 CHCFG_INTPARITY = 0x02000000;
        public const UInt32 CHCFG_INTNONE = 0x00000000;
        public const UInt32 CHCFG_EXTTRIG = 0x10000000;
        public const UInt32 CHCFG_EXTSTART = 0x20000000;
        public const UInt32 CHCFG_EXTOFF = 0x00000000;

        public const UInt32 CHCFG717_DEFAULT = 0x00000000;
        public const UInt32 CHCFG717_SYNC = 0x00000010;
        public const UInt32 CHCFG717_TIMETAG = 0x00000040;
        public const UInt32 CHCFG717_SEQSEL = 0x00010000;
        public const UInt32 CHCFG717_SEQALL = 0x00020000;
        public const UInt32 CHCFG717_64WPS = 0x00001000;
        public const UInt32 CHCFG717_128WPS = 0x00002000;
        public const UInt32 CHCFG717_256WPS = 0x00000000;
        public const UInt32 CHCFG717_512WPS = 0x00004000;
        public const UInt32 CHCFG717_1024WPS = 0x00008000;

        public const UInt32 WRDCFG_DEFAULT = 0x0000;        //Disable message record options
        public const UInt32 WRDCFG_SFINT = 0x0004;		//Enable message interrupt
        public const UInt32 WRDCFG_SFINTOFF = 0x0000;		//Disable message interrupt
        public const UInt32 WRDCFG_WRDINT = 0x0002;		//Enable skip message record
        public const UInt32 WRDCFG_WRDINTOFF = 0x0000;		//Disable skip message record
        public const UInt32 WRDCFG_SEQ = 0x0001;		//Enable sequential record
        public const UInt32 WRDCFG_SEQOFF = 0x0000;		//Disable sequential record

        public const UInt32 SEQCFG_DEFAULT = 0x0000;		//Turn off sequential record
        public const UInt32 SEQCFG_OFF = 0x0000;		//Turn off sequential record
        public const UInt32 SEQCFG_SEL = 0x0001;		//Turn on sequential record for channel
        public const UInt32 SEQCFG_ALL = 0x0002;		//Turn on sequential record monitoring for channel
        public const UInt32 SEQCFG_INT = 0x0010;		//Enable sequential record full interrupt
        public const UInt32 SEQCFG_INTOFF = 0x0000;		//Disable sequential record full interrupt
        public const UInt32 SEQCFG_WRAP = 0x0020;		//Enable sequential record wrap mode
        public const UInt32 SEQCFG_WRAPOFF = 0x0000;		//Disable sequential record wrap mode
        public const UInt32 SEQCFG_DELTA = 0x0040;		//Enable sequential record delta mode
        public const UInt32 SEQCFG_DELTAOFF = 0x0000;		//Disable sequential record delta mode
        public const UInt32 SEQCFG_INTERVAL = 0x0080;		//Enable sequential record interval mode
        public const UInt32 SEQCFG_INTERVALOFF = 0x0000;		//Disable sequential record interval mode

        public const UInt32 MSGCFG_DEFAULT = 0x0000;        //Disable message record options
        public const UInt32 MSGCFG_SEQ = 0x0001;		//Enable sequential record
        public const UInt32 MSGCFG_SEQOFF = 0x0000;		//Disable sequential record
        public const UInt32 MSGCFG_INT = 0x0002;		//Enable message interrupt
        public const UInt32 MSGCFG_INTOFF = 0x0000;		//Disable message interrupt
        public const UInt32 MSGCFG_SKIP = 0x0004;		//Enable skip message record
        public const UInt32 MSGCFG_SKIPOFF = 0x0000;		//Disable skip message record

        public const UInt32 OPCODE_NOP = 0x0000;
        public const UInt32 OPCODE_MESSAGE = 0x0001;
        public const UInt32 OPCODE_GAP = 0x0002;
        public const UInt32 OPCODE_LIST = 0x0003;
        public const UInt32 OPCODE_HALT = 0x0004;
        public const UInt32 OPCODE_PAUSE = 0x0005;
        public const UInt32 OPCODE_RESTART = 0x0006;
        public const UInt32 OPCODE_INTERRUPT = 0x0007;
        public const UInt32 OPCODE_USERCODE = 0x0008;
        public const UInt32 OPCODE_GOTO = 0x0009;
        public const UInt32 OPCODE_CALL = 0x000A;
        public const UInt32 OPCODE_RETURN = 0x000B;
        public const UInt32 OPCODE_DIN0 = 0x000C;
        public const UInt32 OPCODE_DIN1 = 0x000D;
        public const UInt32 OPCODE_PULSE = 0x000E;

        public const UInt16 COND_NONE = 0;
        public const UInt16 COND_UNCOND = 1;
        public const UInt16 COND_DIN0 = 2;
        public const UInt16 COND_DIN1 = 3;

        public const UInt32 REG_INT = 0x00;					//Interrupt register
        public const UInt32 REG_PAGE = 0x01;					//Page register
        public const UInt32 REG_RESV1 = 0x02;					//Reserved register
        public const UInt32 REG_RST = 0x03;					//Reset register
        public const UInt32 REG_INTC = 0x04;					//Interrupt clear register
        public const UInt32 REG_RESV2 = 0x05;					//Reserved register
        public const UInt32 REG_ERR = 0x06;					//Error register
        public const UInt32 REG_PWE = 0x07;					//Prom write enable register

        public const UInt32 REG_SRQ = 0x3000;				//Service request register
        public const UInt32 REG_MISC = 0x3001;				//Miscellaneous register
        public const UInt32 REG_INTE = 0x3002;				//Interrupt enable register
        public const UInt32 REG_SYNC = 0x3003;				//Sync register
        public const UInt32 REG_CHAN4 = 0x3004;				//Channel 4 control register
        public const UInt32 REG_CHAN5 = 0x3005;				//Channel 5 control register
        public const UInt32 REG_GAP4 = 0x3008;				//Channel 4 gap register
        public const UInt32 REG_GAP5 = 0x3009;				//Channel 5 gap register
        public const UInt32 REG_RESET = 0x300F;				//Reset register
        public const UInt32 REG_TTL = 0x400A;				//Time tag low word register
        public const UInt32 REG_TTH = 0x400B;				//Time tag high word register
        public const UInt32 REG_DAT0L = 0x4080;				//Channel 0 low data word register
        public const UInt32 REG_DAT0H = 0x4081;				//Channel 0 high data word register
        public const UInt32 REG_DAT1L = 0x4082;				//Channel 1 low data word register
        public const UInt32 REG_DAT1H = 0x4083;				//Channel 1 high data word register
        public const UInt32 REG_DAT2L = 0x4084;				//Channel 2 low data word register
        public const UInt32 REG_DAT2H = 0x4085;				//Channel 2 high data word register
        public const UInt32 REG_DAT3L = 0x4086;				//Channel 3 low data word register
        public const UInt32 REG_DAT3H = 0x4087;				//Channel 3 high data word register
        public const UInt32 REG_DAT4L = 0x4090;				//Channel 4 low data word register
        public const UInt32 REG_DAT4H = 0x4091;				//Channel 4 high data word register
        public const UInt32 REG_DAT5L = 0x4092;				//Channel 5 low data word register
        public const UInt32 REG_DAT5H = 0x4093;				//Channel 5 high data word register
        public const UInt32 REG_CTRLA = 0x40A0;				//Channel 0,1,4 control register
        public const UInt32 REG_CTRLB = 0x40A1;				//Channel 0,1,5 control register

        public const UInt16 TIMERRESOL_HIGH = 1;
        public const UInt16 TIMERRESOL_MED = 2;
        public const UInt16 TIMERRESOL_LOW = 3;

        public const UInt16 ERR_NONE = 0;	//No error
        public const Int16 ERR_UNKNOWN = -1;	//An unexpected error occurred
        public const Int16 ERR_BADVER = -2;	//A bad version was encountered
        public const Int16 ERR_NOCS = -10;	//Card Services is not present
        public const Int16 ERR_NOSOCKET = -11;	//The specified socket is not present
        public const Int16 ERR_NOCARD = -12;	//Unable to find a CM429-1 card in the specified socket
        public const Int16 ERR_NOTSR = -13;	//Unable to find the CM429-1 memory resident driver
        public const Int16 ERR_CLIENT = -14;	//Unable to install a local client driver
        public const Int16 ERR_CS = -15;	//An error was returned by Card Services
        public const Int16 ERR_WIN = -16;	//Card Services could not configure the memory window, I/O window, or IRQ steering
        public const Int16 ERR_SEL = -17;	//Unable to allocate a memory selector
        public const Int16 ERR_BADHANDLE = -20;	//A bad handle was specified
        public const Int16 ERR_NOTCHAN = -21;	//Specified channel does not exist
        public const Int16 ERR_NOTRCV = -22;	//Specified channel is not a receiver channel
        public const Int16 ERR_NOTXMT = -23;	//Specified channel is not a transmitter channel
        public const Int16 ERR_LABEL = -24;	//Bad label parameter specified
        public const Int16 ERR_SDI = -25;	//Bad SDI parameter specified
        public const Int16 ERR_BADMSGNUM = -26;	//Specified message number is out of range
        public const Int16 ERR_BADSCHNDX = -27;	//Specified schedule index is out of range
        public const Int16 ERR_SCHFULL = -28;	//Specified schedule is full
        public const Int16 ERR_BADMSGPTR = -29;	//Tried to put both user code and list buffer in message
        public const Int16 ERR_CORRUPT = -31;	//Variables have been corrupted
        public const Int16 ERR_SELFFAIL = -32;	//Selftest failed
        public const Int16 ERR_IOFAIL = -33;	//IO selftest failed
        public const Int16 ERR_MEMFAIL = -34;	//Memory selftest failed
        public const Int16 ERR_LOCK = -35;	//Board is locked up
        public const Int16 ERR_BADTYPE = -36;	//Bad type value specified
        public const Int16 ERR_FACTOR = -41;	//A bad factor value was specified
        public const Int16 ERR_ZEROLEN = -42;	//Zero length was specified
        public const Int16 ERR_BUFSIZE = -43;	//Insufficient space in user buffer
        public const Int16 ERR_NOMSGS = -44;	//No messages specified
        public const Int16 ERR_CONFLICTS = -45;	//Unable to resolve conflicts
        public const Int16 ERR_RANGE = -46;	//Schedule is out of range
        public const Int16 ERR_FNAME = -50;	//Bad filenames were specified
        public const Int16 ERR_FRDWR = -51;	//There was an error reading or writing the HEX file
        public const Int16 ERR_HEX = -52;	//There was a bad hex character in the HEX file
        public const Int16 ERR_CRC = -53;	//There was a bad checksum in the HEX file
        public const Int16 ERR_TYPE = -54;	//There was a bad type value in the HEX file
        public const Int16 ERR_BOOTFULL = -61;	//No space to add boot code
        public const Int16 ERR_BOOTNUM = -62;	//There is no boot code with the specified number
        public const Int16 ERR_CISVERIFY = -90;	//Unable to verify the value written to the CIS
        public const Int16 ERR_CISNONE = -91;	//The CIS is not visible
        public const Int16 ERR_CISENB = -92;	//The PWE register cannot be enabled
        public const Int16 ERR_CISMAGIC = -93;	//Unable to write to the PWE register
        public const Int16 ERR_VXD = -100;	//Error returned from VXD
        public const Int16 ERR_NOHANDLES = -101;	//CardOpen() already has allocated too many handles
        public const Int16 ERR_NOIO = -102;	//CardOpen() could not find the I/O
        public const Int16 ERR_NOMEM = -103;	//CardOpen() could not find the I/O
        public const Int16 ERR_BAD16BIT = -104;	//CardOpen() could not find the I/O
        public const Int16 ERR_NOT717RCV = -110;	//Specified channel is not a 717 receiver channel
        public const Int16 ERR_SUBFRMNUM = -111;	//Invalid 717 SubFrame number was specified or record does not exist
        public const Int16 ERR_WORDNUM = -112;	//Invalid 717 Word number was specified or record does not exist
        public const Int16 ERR_SUBFRMREC = -113;	//Invalid 717 SubFrame number was specified or record does not exist
        public const Int16 ERR_SYNCVAL = -114;	//Invalid 717 Sync Value was specified
        public const Int16 ERR_NOTINSYNC = -115;	//Not Synchronized to 717 databus

    }	//end class
}	//end namespace
