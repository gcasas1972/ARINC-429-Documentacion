using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class BTICSDB
    {
        /**
        *
        *  BTICSDB WIN32 DRIVER  Version 1.1.2  (03/02/2010)
        *  Copyright (c) 2005-2010
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   BTICSDBNET.CS -- 32-bit
        *                      BTICSDB Driver Include Header File.
        *
        **/

        /**
        *
        *  Structs used by the BTICSDB Driver.
        *
        **/

        [StructLayout(LayoutKind.Sequential)]
        public struct MSGFIELDSCSDB
        {
            public UInt16 msgopt;             //Driver writes message optionvals
            public UInt16 msgoptext;          //Non-continuous, Valid, and current burst count (FW)
            public UInt16 burstcount;         //Burst count (API)
            public UInt16 reserved;           //reserved
            public UInt16 msgact;             //Card writes message activity
            public UInt16 datacount;          //Number of valid bytes in data[] buffer
            public UInt32 listptr;            //Driver writes list buffer pointer
            public UInt32 timetag_hitcount; //Card writes time-tag low value (32 bits) - //Card writes hit count
            public UInt32 maxtime_elapsetime; //Card writes max time - //Card writes elapsed time
            public UInt32 mintime;            //Card writes min time
            public UInt32 userptr;            //Driver writes user code pointer
            public UInt32 miscptr;            //reserved
            public UInt32 timetagh;           //Card writes extended timetag (32 bits)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public UInt16[] data;	//Card writes data block
        }

        /**
        *
        *  BTICSDB Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the BTICSDB Driver.
        *
        **/

        private static class BTICSDB_32
        {
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChClear(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChConfig@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChConfig(UInt32 configval, UInt16 bitrateflag, UInt16 bytesperblock, UInt16 framespersecond, UInt16 blocksperframe, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChGetCount@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChGetInfo@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChIsCSDB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChIsCSDB(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChIsRcv@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChIsRcv(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChIsXmt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChIsXmt(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ChPause(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChPauseCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChPauseCheck(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChResume@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ChResume(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChStart(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChStop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChStop(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_FilterClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_FilterClear(UInt32 basevaladdr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_FilterDefault@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_FilterDefault(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_FilterRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_FilterRd(Int32 addrval, Int32 sival, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_FilterSet@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_FilterSet(UInt32 configval, Int32 addrval, Int32 simask, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_FilterWr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_FilterWr(UInt32 msgaddr, Int32 addrval, Int32 sival, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListDataRd(ref byte buf, Int32 count, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListDataWr(ref byte buf, Int32 count, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListRcvCreate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListRcvCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListStatus(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListXmtCreate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListXmtCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgBlockRd(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgBlockWr(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgCreate@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgCreate(UInt32 configval, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgDataByteRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern byte BTICSDB_MsgDataByteRd(Int32 index, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgDataByteWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_MsgDataByteWr(byte data, Int32 index, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_MsgDataRd(ref byte buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_MsgDataWr(ref byte buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgIsAccessed@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgValidSet@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_MsgValidSet(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ParamAmplitudeConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ParamAmplitudeGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedBranch@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedBranch(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedBuild@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedBuild(Int32 nummsgs, ref UInt32 msgs, ref Int32 freq, Int32 interblockgap, Int32 rsvdblocks, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedCall@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedCall(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedEntry@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedEntry(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedGap@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedGap(UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedHalt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedHalt(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedLog@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedLog(UInt32 condition, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedMsg(UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedPause(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedPulse@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedPulse(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedRestart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedReturn@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedReturn(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChConfigEx@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChConfigEx(UInt32 configval, UInt16 bitrateflag, UInt16 bytesperblock, UInt16 framespersecond, UInt16 blocksperframe, UInt16 interbytegap, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ChConfigExx@36", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChConfigExx(UInt32 configval, UInt16 count, UInt16 bitrateflag, UInt16 bytesperblock, UInt16 framespersecond, UInt16 blocksperframe, UInt16 interbytegap, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_CmdAddr(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_CmdAlloc(Int32 count, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdBaseRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_CmdBaseRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdBaseWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdBaseWr(UInt32 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdClear(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdCountRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_CmdCountRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdCountWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdCountWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdCtrlRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_CmdCtrlRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdCtrlWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdCtrlWr(UInt16 ctrlval, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdCurrRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_CmdCurrRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdCurrWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdCurrWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdInit(UInt16 opcode, ref UInt16 block);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdInsert@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdInsert(ref UInt16 block, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdMaxLoopRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_CmdMaxLoopRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdMaxLoopWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdMaxLoopWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdRestart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdShotWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdShotWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdSkipWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdSkipWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdStackClr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdStackClr(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdStartRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_CmdStartRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdStartWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdStartWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdStepWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdStepWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdTotalRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdTotalRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdTotalWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdTotalWr(Int32 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_CmdWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_DllUsageCount();
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_FilterAddr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_FilterAddr(Int32 addrval, Int32 sival, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_FilterCreate@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_FilterCreate(UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_FilterFill@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_FilterFill(UInt32 msgaddr, UInt32 basevaladdr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_GetChanCount@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_IsChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_IsChan(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_IsRcvChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_IsRcvChan(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_IsXmtChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_IsXmtChan(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListAddrEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListAdvance@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListAdvance(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListClear(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListConfig(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListConfigEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListDataRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListDataRdEx(ref byte buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListDataWrEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListDataWrEx(ref byte buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListInit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListNextRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListNextRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListNextWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListNextWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListPostRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListPostWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListPreRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_ListPreWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgActivityRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_MsgActivityRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgActivityWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_MsgActivityWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_MsgCheck(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgCommRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgCommRd(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgCommWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgCommWr(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_MsgConfig(UInt32 configval, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgCreateEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgCreateEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgFieldRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgFieldRd(Int32 fieldtype, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgFieldWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgFieldWr(UInt32 fieldval, Int32 fieldtype, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_MsgReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgReset(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedAgain@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedAgain(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedBranchEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedBranchEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedBuildEx@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedBuildEx(Int32 nummsgs, ref UInt32 msgs, ref Int32 freq, Int32 interblockgap, Int32 rsvdblocks, Int32 bitrate, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedBuildExx@40", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedBuildExx(Int32 nummsgs, ref UInt32 msgs, ref Int32 freq, Int32 interblockgap, Int32 rsvdblocks, Int32 bitrate, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedCallEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedCallEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedGCD@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedGCD(Int32 a, Int32 b);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedLCM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedLCM(Int32 a, Int32 b);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedLogEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedLogEx(UInt16 condition1, UInt16 condition2, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedNop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedNop(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedPulse0@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedPulse0(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedPulse1@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedPulse1(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_SchedUser@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedUser(UInt32 useraddr, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB.DLL", EntryPoint = "_BTICSDB_TestProtocol@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_TestProtocol(UInt32 handleval);
        }

        private static class BTICSDB_64
        {
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChClear(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChConfig(UInt32 configval, UInt16 bitrateflag, UInt16 bytesperblock, UInt16 framespersecond, UInt16 blocksperframe, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChGetCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChGetInfo", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChIsCSDB", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChIsCSDB(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChIsRcv", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChIsRcv(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChIsXmt", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChIsXmt(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChPause", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ChPause(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChPauseCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChPauseCheck(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChResume", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ChResume(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChStart(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChStop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChStop(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_FilterClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_FilterClear(UInt32 basevaladdr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_FilterDefault", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_FilterDefault(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_FilterRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_FilterRd(Int32 addrval, Int32 sival, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_FilterSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_FilterSet(UInt32 configval, Int32 addrval, Int32 simask, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_FilterWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_FilterWr(UInt32 msgaddr, Int32 addrval, Int32 sival, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListDataRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListDataRd(ref byte buf, Int32 count, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListDataWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListDataWr(ref byte buf, Int32 count, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListRcvCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListRcvCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListStatus", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListStatus(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListXmtCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListXmtCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgBlockRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgBlockRd(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgBlockWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgBlockWr(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgCreate(UInt32 configval, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgDataByteRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern byte BTICSDB_MsgDataByteRd(Int32 index, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgDataByteWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_MsgDataByteWr(byte data, Int32 index, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgDataRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_MsgDataRd(ref byte buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgDataWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_MsgDataWr(ref byte buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgIsAccessed", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgValidSet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_MsgValidSet(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ParamAmplitudeConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ParamAmplitudeGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedBranch", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedBranch(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedBuild", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedBuild(Int32 nummsgs, ref UInt32 msgs, ref Int32 freq, Int32 interblockgap, Int32 rsvdblocks, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedCall", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedCall(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedEntry", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedEntry(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedGap", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedGap(UInt16 gapval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedHalt", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedHalt(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedLog", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedLog(UInt32 condition, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedMsg", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedMsg(UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedPause", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedPause(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedPulse", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedPulse(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedRestart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedReturn", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedReturn(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChConfigEx(UInt32 configval, UInt16 bitrateflag, UInt16 bytesperblock, UInt16 framespersecond, UInt16 blocksperframe, UInt16 interbytegap, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ChConfigExx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ChConfigExx(UInt32 configval, UInt16 count, UInt16 bitrateflag, UInt16 bytesperblock, UInt16 framespersecond, UInt16 blocksperframe, UInt16 interbytegap, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_CmdAddr(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdAlloc", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_CmdAlloc(Int32 count, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdAllocEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdBaseRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_CmdBaseRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdBaseWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdBaseWr(UInt32 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdClear(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdCountRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_CmdCountRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdCountWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdCountWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdCtrlRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_CmdCtrlRd(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdCtrlWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdCtrlWr(UInt16 ctrlval, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdCurrRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_CmdCurrRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdCurrWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdCurrWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdInit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdInit(UInt16 opcode, ref UInt16 block);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdInsert", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdInsert(ref UInt16 block, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdMaxLoopRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_CmdMaxLoopRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdMaxLoopWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdMaxLoopWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdRestart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdRestart(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdShotWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdShotWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdSkipWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdSkipWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdStackClr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdStackClr(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdStartRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_CmdStartRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdStartWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdStartWr(UInt16 addrval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdStepWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdStepWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdTotalRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdTotalRd(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdTotalWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_CmdTotalWr(Int32 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_CmdWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_DllUsageCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_DllUsageCount();
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_FilterAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_FilterAddr(Int32 addrval, Int32 sival, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_FilterCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_FilterCreate(UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_FilterFill", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_FilterFill(UInt32 msgaddr, UInt32 basevaladdr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_GetChanCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_IsChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_IsChan(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_IsRcvChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_IsRcvChan(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_IsXmtChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_IsXmtChan(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListAddrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListAdvance", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListAdvance(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListClear(UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListConfig(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListConfigEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListDataRdEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListDataRdEx(ref byte buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListDataWrEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListDataWrEx(ref byte buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListInit", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListNextRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListNextRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListNextWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_ListNextWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListPostRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListPostWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListPreRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_ListPreWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgActivityRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_MsgActivityRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgActivityWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_MsgActivityWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_MsgCheck(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgCommRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgCommRd(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgCommWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgCommWr(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_MsgConfig(UInt32 configval, Int32 count, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgCreateEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgCreateEx(UInt32 configval, Int32 count, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgFieldRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgFieldRd(Int32 fieldtype, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgFieldWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgFieldWr(UInt32 fieldval, Int32 fieldtype, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgOptRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTICSDB_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgOptWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTICSDB_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_MsgReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTICSDB_MsgReset(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedAgain", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedAgain(Int32 index, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedBranchEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedBranchEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedBuildEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedBuildEx(Int32 nummsgs, ref UInt32 msgs, ref Int32 freq, Int32 interblockgap, Int32 rsvdblocks, Int32 bitrate, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedBuildExx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedBuildExx(Int32 nummsgs, ref UInt32 msgs, ref Int32 freq, Int32 interblockgap, Int32 rsvdblocks, Int32 bitrate, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedCallEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedCallEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedGCD", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedGCD(Int32 a, Int32 b);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedLCM", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedLCM(Int32 a, Int32 b);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedLogEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedLogEx(UInt16 condition1, UInt16 condition2, UInt16 tagval, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedNop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedNop(Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedPulse0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedPulse0(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedPulse1", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedPulse1(Int32 dionum, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_SchedUser", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_SchedUser(UInt32 useraddr, Int32 channum, UInt32 handleval);
            [DllImport("BTICSDB64.DLL", EntryPoint = "BTICSDB_TestProtocol", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTICSDB_TestProtocol(UInt32 handleval);
        }

        public static Int32 BTICSDB_ChClear(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChClear(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChClear(channum, handleval);
        }
        public static Int32 BTICSDB_ChConfig(UInt32 configval, UInt16 bitrateflag, UInt16 bytesperblock, UInt16 framespersecond, UInt16 blocksperframe, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChConfig(configval, bitrateflag, bytesperblock, framespersecond, blocksperframe, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChConfig(configval, bitrateflag, bytesperblock, framespersecond, blocksperframe, channum, handleval);
        }
        public static void BTICSDB_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_ChGetCount(ref rcvcount, ref xmtcount, handleval);
            else
                BTICSDB_64.BTICSDB_ChGetCount(ref rcvcount, ref xmtcount, handleval);
        }
        public static UInt32 BTICSDB_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChGetInfo(infotype, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChGetInfo(infotype, channum, handleval);
        }
        public static Int32 BTICSDB_ChIsCSDB(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChIsCSDB(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChIsCSDB(channum, handleval);
        }
        public static Int32 BTICSDB_ChIsRcv(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChIsRcv(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChIsRcv(channum, handleval);
        }
        public static Int32 BTICSDB_ChIsXmt(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChIsXmt(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChIsXmt(channum, handleval);
        }
        public static void BTICSDB_ChPause(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_ChPause(channum, handleval);
            else
                BTICSDB_64.BTICSDB_ChPause(channum, handleval);
        }
        public static Int32 BTICSDB_ChPauseCheck(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChPauseCheck(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChPauseCheck(channum, handleval);
        }
        public static void BTICSDB_ChResume(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_ChResume(channum, handleval);
            else
                BTICSDB_64.BTICSDB_ChResume(channum, handleval);
        }
        public static Int32 BTICSDB_ChStart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChStart(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChStart(channum, handleval);
        }
        public static Int32 BTICSDB_ChStop(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChStop(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChStop(channum, handleval);
        }
        public static Int32 BTICSDB_FilterClear(UInt32 basevaladdr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_FilterClear(basevaladdr, handleval);
            else
                return BTICSDB_64.BTICSDB_FilterClear(basevaladdr, handleval);
        }
        public static UInt32 BTICSDB_FilterDefault(UInt32 configval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_FilterDefault(configval, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_FilterDefault(configval, channum, handleval);
        }
        public static UInt32 BTICSDB_FilterRd(Int32 addrval, Int32 sival, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_FilterRd(addrval, sival, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_FilterRd(addrval, sival, channum, handleval);
        }
        public static UInt32 BTICSDB_FilterSet(UInt32 configval, Int32 addrval, Int32 simask, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_FilterSet(configval, addrval, simask, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_FilterSet(configval, addrval, simask, channum, handleval);
        }
        public static Int32 BTICSDB_FilterWr(UInt32 msgaddr, Int32 addrval, Int32 sival, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_FilterWr(msgaddr, addrval, sival, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_FilterWr(msgaddr, addrval, sival, channum, handleval);
        }
        public static Int32 BTICSDB_ListDataRd(ref byte buf, Int32 count, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListDataRd(ref buf, count, listaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListDataRd(ref buf, count, listaddr, handleval);
        }
        public static Int32 BTICSDB_ListDataWr(ref byte buf, Int32 count, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListDataWr(ref buf, count, listaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListDataWr(ref buf, count, listaddr, handleval);
        }
        public static UInt32 BTICSDB_ListRcvCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListRcvCreate(listconfigval, count, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListRcvCreate(listconfigval, count, msgaddr, handleval);
        }
        public static Int32 BTICSDB_ListStatus(UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListStatus(listaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListStatus(listaddr, handleval);
        }
        public static UInt32 BTICSDB_ListXmtCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListXmtCreate(listconfigval, count, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListXmtCreate(listconfigval, count, msgaddr, handleval);
        }
        public static UInt32 BTICSDB_MsgBlockRd(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgBlockRd(ref msgfields, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgBlockRd(ref msgfields, msgaddr, handleval);
        }
        public static UInt32 BTICSDB_MsgBlockWr(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgBlockWr(ref msgfields, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgBlockWr(ref msgfields, msgaddr, handleval);
        }
        public static UInt32 BTICSDB_MsgCreate(UInt32 configval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgCreate(configval, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgCreate(configval, handleval);
        }
        public static byte BTICSDB_MsgDataByteRd(Int32 index, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgDataByteRd(index, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgDataByteRd(index, msgaddr, handleval);
        }
        public static Int32 BTICSDB_MsgDataByteWr(byte data, Int32 index, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgDataByteWr(data, index, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgDataByteWr(data, index, msgaddr, handleval);
        }
        public static Int32 BTICSDB_MsgDataRd(ref byte buf, Int32 count, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgDataRd(ref buf, count, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgDataRd(ref buf, count, msgaddr, handleval);
        }
        public static Int32 BTICSDB_MsgDataWr(ref byte buf, Int32 count, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgDataWr(ref buf, count, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgDataWr(ref buf, count, msgaddr, handleval);
        }
        public static Int32 BTICSDB_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgIsAccessed(msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgIsAccessed(msgaddr, handleval);
        }
        public static UInt16 BTICSDB_MsgValidSet(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgValidSet(msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgValidSet(msgaddr, handleval);
        }
        public static Int32 BTICSDB_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ParamAmplitudeConfig(configval, dacval, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ParamAmplitudeConfig(configval, dacval, channum, handleval);
        }
        public static Int32 BTICSDB_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ParamAmplitudeGet(ref dacval, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ParamAmplitudeGet(ref dacval, channum, handleval);
        }
        public static Int32 BTICSDB_SchedBranch(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedBranch(condition, destindex, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedBranch(condition, destindex, channum, handleval);
        }
        public static Int32 BTICSDB_SchedBuild(Int32 nummsgs, ref UInt32 msgs, ref Int32 freq, Int32 interblockgap, Int32 rsvdblocks, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedBuild(nummsgs, ref msgs, ref freq, interblockgap, rsvdblocks, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedBuild(nummsgs, ref msgs, ref freq, interblockgap, rsvdblocks, channum, handleval);
        }
        public static Int32 BTICSDB_SchedCall(UInt32 condition, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedCall(condition, destindex, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedCall(condition, destindex, channum, handleval);
        }
        public static Int32 BTICSDB_SchedEntry(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedEntry(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedEntry(channum, handleval);
        }
        public static Int32 BTICSDB_SchedGap(UInt16 gapval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedGap(gapval, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedGap(gapval, channum, handleval);
        }
        public static Int32 BTICSDB_SchedHalt(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedHalt(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedHalt(channum, handleval);
        }
        public static Int32 BTICSDB_SchedLog(UInt32 condition, UInt16 tagval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedLog(condition, tagval, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedLog(condition, tagval, channum, handleval);
        }
        public static Int32 BTICSDB_SchedMsg(UInt32 msgaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedMsg(msgaddr, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedMsg(msgaddr, channum, handleval);
        }
        public static Int32 BTICSDB_SchedPause(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedPause(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedPause(channum, handleval);
        }
        public static Int32 BTICSDB_SchedPulse(Int32 dionum, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedPulse(dionum, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedPulse(dionum, channum, handleval);
        }
        public static Int32 BTICSDB_SchedRestart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedRestart(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedRestart(channum, handleval);
        }
        public static Int32 BTICSDB_SchedReturn(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedReturn(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedReturn(channum, handleval);
        }
        public static Int32 BTICSDB_ChConfigEx(UInt32 configval, UInt16 bitrateflag, UInt16 bytesperblock, UInt16 framespersecond, UInt16 blocksperframe, UInt16 interbytegap, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChConfigEx(configval, bitrateflag, bytesperblock, framespersecond, blocksperframe, interbytegap, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChConfigEx(configval, bitrateflag, bytesperblock, framespersecond, blocksperframe, interbytegap, channum, handleval);
        }
        public static Int32 BTICSDB_ChConfigExx(UInt32 configval, UInt16 count, UInt16 bitrateflag, UInt16 bytesperblock, UInt16 framespersecond, UInt16 blocksperframe, UInt16 interbytegap, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ChConfigExx(configval, count, bitrateflag, bytesperblock, framespersecond, blocksperframe, interbytegap, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_ChConfigExx(configval, count, bitrateflag, bytesperblock, framespersecond, blocksperframe, interbytegap, channum, handleval);
        }
        public static UInt32 BTICSDB_CmdAddr(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdAddr(index, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdAddr(index, channum, handleval);
        }
        public static UInt32 BTICSDB_CmdAlloc(Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdAlloc(count, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdAlloc(count, handleval);
        }
        public static UInt32 BTICSDB_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdAllocEx(configval, count, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdAllocEx(configval, count, handleval);
        }
        public static UInt32 BTICSDB_CmdBaseRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdBaseRd(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdBaseRd(channum, handleval);
        }
        public static void BTICSDB_CmdBaseWr(UInt32 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_CmdBaseWr(addrval, channum, handleval);
            else
                BTICSDB_64.BTICSDB_CmdBaseWr(addrval, channum, handleval);
        }
        public static Int32 BTICSDB_CmdClear(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdClear(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdClear(channum, handleval);
        }
        public static UInt16 BTICSDB_CmdCountRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdCountRd(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdCountRd(channum, handleval);
        }
        public static void BTICSDB_CmdCountWr(UInt16 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_CmdCountWr(countval, channum, handleval);
            else
                BTICSDB_64.BTICSDB_CmdCountWr(countval, channum, handleval);
        }
        public static UInt16 BTICSDB_CmdCtrlRd(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdCtrlRd(index, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdCtrlRd(index, channum, handleval);
        }
        public static void BTICSDB_CmdCtrlWr(UInt16 ctrlval, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_CmdCtrlWr(ctrlval, index, channum, handleval);
            else
                BTICSDB_64.BTICSDB_CmdCtrlWr(ctrlval, index, channum, handleval);
        }
        public static UInt16 BTICSDB_CmdCurrRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdCurrRd(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdCurrRd(channum, handleval);
        }
        public static void BTICSDB_CmdCurrWr(UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_CmdCurrWr(addrval, channum, handleval);
            else
                BTICSDB_64.BTICSDB_CmdCurrWr(addrval, channum, handleval);
        }
        public static void BTICSDB_CmdInit(UInt16 opcode, ref UInt16 block)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_CmdInit(opcode, ref block);
            else
                BTICSDB_64.BTICSDB_CmdInit(opcode, ref block);
        }
        public static Int32 BTICSDB_CmdInsert(ref UInt16 block, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdInsert(ref block, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdInsert(ref block, channum, handleval);
        }
        public static UInt16 BTICSDB_CmdMaxLoopRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdMaxLoopRd(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdMaxLoopRd(channum, handleval);
        }
        public static void BTICSDB_CmdMaxLoopWr(UInt16 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_CmdMaxLoopWr(countval, channum, handleval);
            else
                BTICSDB_64.BTICSDB_CmdMaxLoopWr(countval, channum, handleval);
        }
        public static Int32 BTICSDB_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdRd(ref block, addrval, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdRd(ref block, addrval, handleval);
        }
        public static void BTICSDB_CmdRestart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_CmdRestart(channum, handleval);
            else
                BTICSDB_64.BTICSDB_CmdRestart(channum, handleval);
        }
        public static Int32 BTICSDB_CmdShotWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdShotWr(value, index, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdShotWr(value, index, channum, handleval);
        }
        public static Int32 BTICSDB_CmdSkipWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdSkipWr(value, index, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdSkipWr(value, index, channum, handleval);
        }
        public static void BTICSDB_CmdStackClr(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_CmdStackClr(channum, handleval);
            else
                BTICSDB_64.BTICSDB_CmdStackClr(channum, handleval);
        }
        public static UInt16 BTICSDB_CmdStartRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdStartRd(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdStartRd(channum, handleval);
        }
        public static void BTICSDB_CmdStartWr(UInt16 addrval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_CmdStartWr(addrval, channum, handleval);
            else
                BTICSDB_64.BTICSDB_CmdStartWr(addrval, channum, handleval);
        }
        public static Int32 BTICSDB_CmdStepWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdStepWr(value, index, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdStepWr(value, index, channum, handleval);
        }
        public static Int32 BTICSDB_CmdTotalRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdTotalRd(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdTotalRd(channum, handleval);
        }
        public static void BTICSDB_CmdTotalWr(Int32 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_CmdTotalWr(countval, channum, handleval);
            else
                BTICSDB_64.BTICSDB_CmdTotalWr(countval, channum, handleval);
        }
        public static Int32 BTICSDB_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_CmdWr(ref block, addrval, handleval);
            else
                return BTICSDB_64.BTICSDB_CmdWr(ref block, addrval, handleval);
        }
        public static Int32 BTICSDB_DllUsageCount()
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_DllUsageCount();
            else
                return BTICSDB_64.BTICSDB_DllUsageCount();
        }
        public static UInt32 BTICSDB_FilterAddr(Int32 addrval, Int32 sival, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_FilterAddr(addrval, sival, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_FilterAddr(addrval, sival, channum, handleval);
        }
        public static UInt32 BTICSDB_FilterCreate(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_FilterCreate(handleval);
            else
                return BTICSDB_64.BTICSDB_FilterCreate(handleval);
        }
        public static Int32 BTICSDB_FilterFill(UInt32 msgaddr, UInt32 basevaladdr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_FilterFill(msgaddr, basevaladdr, handleval);
            else
                return BTICSDB_64.BTICSDB_FilterFill(msgaddr, basevaladdr, handleval);
        }
        public static void BTICSDB_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_GetChanCount(ref rcvcount, ref xmtcount, handleval);
            else
                BTICSDB_64.BTICSDB_GetChanCount(ref rcvcount, ref xmtcount, handleval);
        }
        public static Int32 BTICSDB_IsChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_IsChan(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_IsChan(channum, handleval);
        }
        public static Int32 BTICSDB_IsRcvChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_IsRcvChan(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_IsRcvChan(channum, handleval);
        }
        public static Int32 BTICSDB_IsXmtChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_IsXmtChan(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_IsXmtChan(channum, handleval);
        }
        public static UInt32 BTICSDB_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListAddr(index, listaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListAddr(index, listaddr, handleval);
        }
        public static UInt32 BTICSDB_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListAddrEx(index, listaddr, ref header, handleval);
            else
                return BTICSDB_64.BTICSDB_ListAddrEx(index, listaddr, ref header, handleval);
        }
        public static Int32 BTICSDB_ListAdvance(UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListAdvance(listaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListAdvance(listaddr, handleval);
        }
        public static Int32 BTICSDB_ListClear(UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListClear(listaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListClear(listaddr, handleval);
        }
        public static UInt32 BTICSDB_ListConfig(UInt32 configval, Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListConfig(configval, count, handleval);
            else
                return BTICSDB_64.BTICSDB_ListConfig(configval, count, handleval);
        }
        public static UInt32 BTICSDB_ListConfigEx(UInt32 configval, Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListConfigEx(configval, count, handleval);
            else
                return BTICSDB_64.BTICSDB_ListConfigEx(configval, count, handleval);
        }
        public static Int32 BTICSDB_ListDataRdEx(ref byte buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListDataRdEx(ref buf, count, index, listaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListDataRdEx(ref buf, count, index, listaddr, handleval);
        }
        public static Int32 BTICSDB_ListDataWrEx(ref byte buf, Int32 count, Int32 index, UInt32 listaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListDataWrEx(ref buf, count, index, listaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListDataWrEx(ref buf, count, index, listaddr, handleval);
        }
        public static Int32 BTICSDB_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListInit(listaddr, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_ListInit(listaddr, msgaddr, handleval);
        }
        public static UInt32 BTICSDB_ListNextRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListNextRd(listaddr, ref header, handleval);
            else
                return BTICSDB_64.BTICSDB_ListNextRd(listaddr, ref header, handleval);
        }
        public static UInt32 BTICSDB_ListNextWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_ListNextWr(listaddr, ref header, handleval);
            else
                return BTICSDB_64.BTICSDB_ListNextWr(listaddr, ref header, handleval);
        }
        public static void BTICSDB_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_ListPostRd(listaddr, ref header, handleval);
            else
                BTICSDB_64.BTICSDB_ListPostRd(listaddr, ref header, handleval);
        }
        public static void BTICSDB_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_ListPostWr(listaddr, ref header, handleval);
            else
                BTICSDB_64.BTICSDB_ListPostWr(listaddr, ref header, handleval);
        }
        public static void BTICSDB_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_ListPreRd(listaddr, ref header, handleval);
            else
                BTICSDB_64.BTICSDB_ListPreRd(listaddr, ref header, handleval);
        }
        public static void BTICSDB_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_ListPreWr(listaddr, ref header, handleval);
            else
                BTICSDB_64.BTICSDB_ListPreWr(listaddr, ref header, handleval);
        }
        public static UInt16 BTICSDB_MsgActivityRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgActivityRd(msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgActivityRd(msgaddr, handleval);
        }
        public static void BTICSDB_MsgActivityWr(UInt16 value, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_MsgActivityWr(value, msgaddr, handleval);
            else
                BTICSDB_64.BTICSDB_MsgActivityWr(value, msgaddr, handleval);
        }
        public static UInt16 BTICSDB_MsgCheck(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgCheck(msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgCheck(msgaddr, handleval);
        }
        public static UInt32 BTICSDB_MsgCommRd(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgCommRd(ref msgfields, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgCommRd(ref msgfields, msgaddr, handleval);
        }
        public static UInt32 BTICSDB_MsgCommWr(ref MSGFIELDSCSDB msgfields, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgCommWr(ref msgfields, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgCommWr(ref msgfields, msgaddr, handleval);
        }
        public static Int32 BTICSDB_MsgConfig(UInt32 configval, Int32 count, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgConfig(configval, count, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgConfig(configval, count, msgaddr, handleval);
        }
        public static UInt32 BTICSDB_MsgCreateEx(UInt32 configval, Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgCreateEx(configval, count, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgCreateEx(configval, count, handleval);
        }
        public static UInt32 BTICSDB_MsgFieldRd(Int32 fieldtype, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgFieldRd(fieldtype, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgFieldRd(fieldtype, msgaddr, handleval);
        }
        public static UInt32 BTICSDB_MsgFieldWr(UInt32 fieldval, Int32 fieldtype, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgFieldWr(fieldval, fieldtype, msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgFieldWr(fieldval, fieldtype, msgaddr, handleval);
        }
        public static UInt16 BTICSDB_MsgOptRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgOptRd(msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgOptRd(msgaddr, handleval);
        }
        public static void BTICSDB_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTICSDB_32.BTICSDB_MsgOptWr(msgopt, msgaddr, handleval);
            else
                BTICSDB_64.BTICSDB_MsgOptWr(msgopt, msgaddr, handleval);
        }
        public static UInt32 BTICSDB_MsgReset(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_MsgReset(msgaddr, handleval);
            else
                return BTICSDB_64.BTICSDB_MsgReset(msgaddr, handleval);
        }
        public static Int32 BTICSDB_SchedAgain(Int32 index, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedAgain(index, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedAgain(index, channum, handleval);
        }
        public static Int32 BTICSDB_SchedBranchEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedBranchEx(condition1, condition2, destindex, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedBranchEx(condition1, condition2, destindex, channum, handleval);
        }
        public static Int32 BTICSDB_SchedBuildEx(Int32 nummsgs, ref UInt32 msgs, ref Int32 freq, Int32 interblockgap, Int32 rsvdblocks, Int32 bitrate, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedBuildEx(nummsgs, ref msgs, ref freq, interblockgap, rsvdblocks, bitrate, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedBuildEx(nummsgs, ref msgs, ref freq, interblockgap, rsvdblocks, bitrate, channum, handleval);
        }
        public static Int32 BTICSDB_SchedBuildExx(Int32 nummsgs, ref UInt32 msgs, ref Int32 freq, Int32 interblockgap, Int32 rsvdblocks, Int32 bitrate, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedBuildExx(nummsgs, ref msgs, ref freq, interblockgap, rsvdblocks, bitrate, buf, bufsize, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedBuildExx(nummsgs, ref msgs, ref freq, interblockgap, rsvdblocks, bitrate, buf, bufsize, channum, handleval);
        }
        public static Int32 BTICSDB_SchedCallEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedCallEx(condition1, condition2, destindex, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedCallEx(condition1, condition2, destindex, channum, handleval);
        }
        public static Int32 BTICSDB_SchedGCD(Int32 a, Int32 b)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedGCD(a, b);
            else
                return BTICSDB_64.BTICSDB_SchedGCD(a, b);
        }
        public static Int32 BTICSDB_SchedLCM(Int32 a, Int32 b)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedLCM(a, b);
            else
                return BTICSDB_64.BTICSDB_SchedLCM(a, b);
        }
        public static Int32 BTICSDB_SchedLogEx(UInt16 condition1, UInt16 condition2, UInt16 tagval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedLogEx(condition1, condition2, tagval, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedLogEx(condition1, condition2, tagval, channum, handleval);
        }
        public static Int32 BTICSDB_SchedNop(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedNop(channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedNop(channum, handleval);
        }
        public static Int32 BTICSDB_SchedPulse0(Int32 dionum, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedPulse0(dionum, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedPulse0(dionum, channum, handleval);
        }
        public static Int32 BTICSDB_SchedPulse1(Int32 dionum, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedPulse1(dionum, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedPulse1(dionum, channum, handleval);
        }
        public static Int32 BTICSDB_SchedUser(UInt32 useraddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_SchedUser(useraddr, channum, handleval);
            else
                return BTICSDB_64.BTICSDB_SchedUser(useraddr, channum, handleval);
        }
        public static Int32 BTICSDB_TestProtocol(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTICSDB_32.BTICSDB_TestProtocol(handleval);
            else
                return BTICSDB_64.BTICSDB_TestProtocol(handleval);
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
        *  Bitrate configuration options
        *
        **/

        public const UInt32 BITRATECSDB_CLK1 = 0x8000;      //CLK1, 20 MHz (default)
        public const UInt32 BITRATECSDB_CLK2 = 0x0000;      //CLK2, 9.216 MHz (standard option)
        public const UInt32 BITRATECSDB_XMTSLOPEHIGH = 0x0000;      //Transmit with high speed slope (default)
        public const UInt32 BITRATECSDB_XMTSLOPELOW = 0x4000;      //Transmit with low speed slope

        public const UInt32 BITRATECSDB_921600BPS = 0x0000;          //External Clock, Div = 0
        public const UInt32 BITRATECSDB_460800BPS = 0x0001;          //External Clock, Div = 1
        public const UInt32 BITRATECSDB_230400BPS = 0x0003;          //External Clock, Div = 3
        public const UInt32 BITRATECSDB_115200BPS = 0x0007;          //External Clock, Div = 7
        public const UInt32 BITRATECSDB_57600BPS = 0x000F;          //External Clock, Div = 15
        public const UInt32 BITRATECSDB_38400BPS = 0x0017;          //External Clock, Div = 23
        public const UInt32 BITRATECSDB_28800BPS = 0x001F;          //External Clock, Div = 31
        public const UInt32 BITRATECSDB_19200BPS = 0x002F;          //External Clock, Div = 47
        public const UInt32 BITRATECSDB_14400BPS = 0x003F;          //External Clock, Div = 63
        public const UInt32 BITRATECSDB_9600BPS = 0x005F;          //External Clock, Div = 95
        public const UInt32 BITRATECSDB_7200BPS = 0x007F;          //External Clock, Div = 127
        public const UInt32 BITRATECSDB_4800BPS = 0x00BF;          //External Clock, Div = 191
        public const UInt32 BITRATECSDB_3600BPS = 0x00FF;          //External Clock, Div = 255
        public const UInt32 BITRATECSDB_2400BPS = 0x017F;          //External Clock, Div = 383
        public const UInt32 BITRATECSDB_1800BPS = 0x01FF;          //External Clock, Div = 511
        public const UInt32 BITRATECSDB_1200BPS = 0x02FF;          //External Clock, Div = 767
        public const UInt32 BITRATECSDB_900BPS = 0x03FF;          //External Clock, Div = 1023
        public const UInt32 BITRATECSDB_600BPS = 0x05FF;          //External Clock, Div = 1535
        public const UInt32 BITRATECSDB_300BPS = 0x0BFF;          //External Clock, Div = 3071

        public const UInt32 BITRATECSDB_500000BPS = 0x8003;          //Internal Clock, Div = 3
        public const UInt32 BITRATECSDB_400000BPS = 0x8004;          //Internal Clock, Div = 4
        public const UInt32 BITRATECSDB_250000BPS = 0x8007;          //Internal Clock, Div = 7
        public const UInt32 BITRATECSDB_200000BPS = 0x8009;          //Internal Clock, Div = 9
        public const UInt32 BITRATECSDB_100000BPS = 0x8013;          //Internal Clock, Div = 19
        public const UInt32 BITRATECSDB_80000BPS = 0x8018;          //Internal Clock, Div = 24
        public const UInt32 BITRATECSDB_50000BPS = 0x8027;          //Internal Clock, Div = 39
        public const UInt32 BITRATECSDB_40000BPS = 0x8031;          //Internal Clock, Div = 49
        public const UInt32 BITRATECSDB_25000BPS = 0x804F;          //Internal Clock, Div = 79
        public const UInt32 BITRATECSDB_20000BPS = 0x8063;          //Internal Clock, Div = 99
        public const UInt32 BITRATECSDB_12500BPS = 0x809F;          //Internal Clock, Div = 159
        public const UInt32 BITRATECSDB_10000BPS = 0x80C7;          //Internal Clock, Div = 199

        public const UInt32 BITRATECSDB_HIGHSPEED = 0xC027;          //Internal Clock, Div = 39
        public const UInt32 BITRATECSDB_LOWSPEED = 0xC09F;          //Internal Clock, Div = 159

        /**
        *
        *  SDI selection constants
        *
        **/

        public const UInt32 SIALL = 0x00FF;	//Enable all SIs
        public const UInt32 SIx00 = 0x0011;	//Enable SIx00
        public const UInt32 SIx01 = 0x0022;	//Enable SIx01
        public const UInt32 SIx10 = 0x0044;	//Enable SIx10
        public const UInt32 SIx11 = 0x0088;	//Enable SIx11
        public const UInt32 SI000 = 0x0001;	//Enable SI000
        public const UInt32 SI001 = 0x0002;	//Enable SI001
        public const UInt32 SI010 = 0x0004;	//Enable SI010
        public const UInt32 SI011 = 0x0008;	//Enable SI011
        public const UInt32 SI100 = 0x0010;	//Enable SI100
        public const UInt32 SI101 = 0x0020;	//Enable SI101
        public const UInt32 SI110 = 0x0040;	//Enable SI110
        public const UInt32 SI111 = 0x0080;	//Enable SI111

        /**
        *
        *  Channel configuration options
        *
        **/

        public const UInt32 CHCFGCSDB_DEFAULT = 0x00000000;	//Select all default settings (XMT & RCV) (default)
        public const UInt32 CHCFGCSDB_SELFTESTOFF = 0x00000000;	//Disable internal wraparound (XMT & RCV) (default)
        public const UInt32 CHCFGCSDB_SELFTEST = 0x00000004;	//Enable internal wraparound (XMT & RCV)
        public const UInt32 CHCFGCSDB_PARITYODD = 0x00000000;	//Enable odd parity (XMT & RCV) (default)
        public const UInt32 CHCFGCSDB_PARITYNONE = 0x80000000;	//Disable parity (XMT & RCV)
        public const UInt32 CHCFGCSDB_PARITYEVEN = 0x40000000;	//Enable even parity (XMT & RCV)
        public const UInt32 CHCFGCSDB_PARITYMARK = 0x20000000;	//Force set parity (XMT & RCV)
        public const UInt32 CHCFGCSDB_PARITYSPACE = 0x10000000;	//Force clear parity (XMT & RCV)
        public const UInt32 CHCFGCSDB_ACTIVE = 0x00000000;	//Enable channel activity (XMT & RCV) (default)
        public const UInt32 CHCFGCSDB_INACTIVE = 0x00000040;	//Disable channel activity (XMT & RCV)
        public const UInt32 CHCFGCSDB_SEQSEL = 0x00000000;	//Sequential record recording is enabled at message level (default)
        public const UInt32 CHCFGCSDB_SEQALL = 0x00080000;	//Record entire channel in sequential record
        public const UInt32 CHCFGCSDB_NOLOGHALT = 0x00000000;	//No event log on schedule halt (default)
        public const UInt32 CHCFGCSDB_LOGHALT = 0x00200000;	//Enable event log on schedule halt
        public const UInt32 CHCFGCSDB_NOLOGPAUSE = 0x00000000;	//No event log on schedule pause (default)
        public const UInt32 CHCFGCSDB_LOGPAUSE = 0x00400000;	//Enable event log on schedule pause
        public const UInt32 CHCFGCSDB_NOLOGERR = 0x00000000;	//No event log on decoder errors (default)
        public const UInt32 CHCFGCSDB_LOGERR = 0x00800000;	//Enable event log on decoder errors and sync errors.
        public const UInt32 CHCFGCSDB_TIMETAGOFF = 0x00000000;	//Time-tag is enabled on message level (default)
        public const UInt32 CHCFGCSDB_TIMETAG = 0x00000400;	//Enable time-tag for all message records
        public const UInt32 CHCFGCSDB_NOHIT = 0x00000000;	//Hit counter is enabled on message level (default)
        public const UInt32 CHCFGCSDB_HIT = 0x00000200;	//Hit counter is enabled for all messages
        public const UInt32 CHCFGCSDB_ELAPSEOFF = 0x00000000;	//Elapse time is enabled on message level (default)
        public const UInt32 CHCFGCSDB_ELAPSE = 0x00000800;	//Enable elapse time for all messages
        public const UInt32 CHCFGCSDB_MAXMINOFF = 0x00000000;	//Repetition rate monitoring is enabled on message level (default)
        public const UInt32 CHCFGCSDB_MAX = 0x00001000;	//Enable max repetition rate monitoring for all messages
        public const UInt32 CHCFGCSDB_MIN = 0x00002000;	//Enable min repetition rate monitoring for all messages
        public const UInt32 CHCFGCSDB_MAXMIN = 0x00003000;	//Enable max and min repetition rate monitoring for all messages
        public const UInt32 CHCFGCSDB_NOLOOPMAX = 0x00000000;	//Disable schedule maximum loop count (default)
        public const UInt32 CHCFGCSDB_LOOPMAX = 0x00100000;	//Enable schedule maximum loop count
        public const UInt32 CHCFGCSDB_UNPAUSE = 0x00000000;	//Mark channel as unpaused (default)
        public const UInt32 CHCFGCSDB_PAUSE = 0x01000000;	//Mark channel as paused
        public const UInt32 CHCFGCSDB_BUSINVERTOFF = 0x00000000;	//No bus inversion (default)
        public const UInt32 CHCFGCSDB_BUSINVERT = 0x00000001;	//Enable bus inversion
        public const UInt32 CHCFGCSDB_MODE422 = 0x00000000;	//Enable RS-422 mode (balanced) (XMT) (default)
        public const UInt32 CHCFGCSDB_MODE232 = 0x08000000;	//Enable RS-232 / RS-423 mode (unbalanced) (XMT)
        public const UInt32 CHCFGCSDB_SYNCMODE = 0x00000000;	//Synchronous scheduled mode (CSDB) (default)
        public const UInt32 CHCFGCSDB_ASYNCMODE = 0x00000002;	//Asynchrounous mode (general purpose serial)

        /**
        *
        *  Message configuration options
        *
        **/

        public const UInt32 MSGCRTCSDB_DEFAULT = 0x00000000;	//Default settings
        public const UInt32 MSGCRTCSDB_NOSEQ = 0x00000000;	//Message will not be recorded in sequential record (default)
        public const UInt32 MSGCRTCSDB_SEQ = 0x00000001;	//Message will be recorded in sequential record
        public const UInt32 MSGCRTCSDB_NOLOG = 0x00000000;	//Message will not generate event log (default)
        public const UInt32 MSGCRTCSDB_LOG = 0x00000002;	//Message will generate event log
        public const UInt32 MSGCRTCSDB_NOERROR = 0x00000000;	//Message will not generate errors (default)
        public const UInt32 MSGCRTCSDB_ERROR = 0x00000004;	//Message can generate errors
        public const UInt32 MSGCRTCSDB_NOSKIP = 0x00000000;	//Message will not be skipped (default)
        public const UInt32 MSGCRTCSDB_SKIP = 0x00000008;	//Message will be skipped
        public const UInt32 MSGCRTCSDB_NOTIMETAG = 0x00000000;	//Message will not record time-tag (default)
        public const UInt32 MSGCRTCSDB_TIMETAG = 0x00000010;	//Message will record time-tag
        public const UInt32 MSGCRTCSDB_NOELAPSE = 0x00000000;	//Message will not record elapse time (default)
        public const UInt32 MSGCRTCSDB_ELAPSE = 0x00000020;	//Message will record elapse time
        public const UInt32 MSGCRTCSDB_NOMAXMIN = 0x00000000;	//Message will not record min/max time (default)
        public const UInt32 MSGCRTCSDB_MAX = 0x00000040;	//Message will record max time
        public const UInt32 MSGCRTCSDB_MIN = 0x00000080;	//Message will record min time
        public const UInt32 MSGCRTCSDB_MAXMIN = 0x000000C0;	//Message will record min/max time
        public const UInt32 MSGCRTCSDB_NOHIT = 0x00000000;	//Message will not record hit count (default)
        public const UInt32 MSGCRTCSDB_HIT = 0x00000800;	//Message will record hit count
        public const UInt32 MSGCRTCSDB_WIPE = 0x00000000;	//Enables message clear (default)
        public const UInt32 MSGCRTCSDB_NOWIPE = 0x80000000;	//Disables message clear
        public const UInt32 MSGCRTCSDB_WIPE0 = 0x00000000;	//Initialize data with zeros (default)
        public const UInt32 MSGCRTCSDB_WIPE1 = 0x40000000;	//Initialize data with ones
        public const UInt32 MSGCRTCSDB_WIPESYNC = 0x20000000;	//Initialize data with 0xA5
        public const UInt32 MSGCRTCSDB_CONT = 0x00000000;	//Selects continuous mode (default)
        public const UInt32 MSGCRTCSDB_NONCONT = 0x00002000;	//Selects non-continuous mode
        public const UInt32 MSGCRTCSDB_BURST = 0x00004000;	//Selects burst mode

        /**
        *
        *  List buffer options
        *
        **/

        public const UInt32 LISTCRTCSDB_DEFAULT = 0x00000000;	//Select all default settings
        public const UInt32 LISTCRTCSDB_FIFO = 0x00000000;	//Enable FIFO mode (default)
        public const UInt32 LISTCRTCSDB_PINGPONG = 0x00000001;	//Enable ping-pong mode
        public const UInt32 LISTCRTCSDB_CIRCULAR = 0x00000002;	//Enable circular mode
        public const UInt32 LISTCRTCSDB_RCV = 0x00000010;	//User will read from list buffer
        public const UInt32 LISTCRTCSDB_XMT = 0x00000020;	//User will write to list buffer
        public const UInt32 LISTCRTCSDB_NOLOG = 0x00000000;	//Do not generate event log when list buffer empty/full (default)
        public const UInt32 LISTCRTCSDB_LOG = 0x00000100;	//Generate event log when list buffer empty/full

        /**
        *
        *  Parametric configuration options
        *
        **/

        public const UInt32 PARAMCFGCSDB_DEFAULT = 0x00000000;	//Select all default settings (default)
        public const UInt32 PARAMCFGCSDB_AMPLON = 0x00000000;	//Enables parametric amplitude control (default)
        public const UInt32 PARAMCFGCSDB_AMPLOFF = 0x00000001;	//Disables parametric amplitude control

        /**
        *
        *  Scheduling conditions.
        *
        **/

        public const UInt32 CONDCSDB_ALWAYS = 0x00000000;	//Unconditional
        public const UInt32 CONDCSDB_DIO1ACT = 0x00000001;	//Condition on digital I/O #1 active
        public const UInt32 CONDCSDB_DIO1NACT = 0x00000002;	//Condition on digital I/O #1 not active
        public const UInt32 CONDCSDB_DIO2ACT = 0x00000004;	//Condition on digital I/O #2 active
        public const UInt32 CONDCSDB_DIO2NACT = 0x00000008;	//Condition on digital I/O #2 not active
        public const UInt32 CONDCSDB_DIO3ACT = 0x00000010;	//Condition on digital I/O #3 active
        public const UInt32 CONDCSDB_DIO3NACT = 0x00000020;	//Condition on digital I/O #3 not active
        public const UInt32 CONDCSDB_DIO4ACT = 0x00000040;	//Condition on digital I/O #4 active
        public const UInt32 CONDCSDB_DIO4NACT = 0x00000080;	//Condition on digital I/O #4 not active
        public const UInt32 CONDCSDB_DIO5ACT = 0x00000100;	//Condition on digital I/O #5 active
        public const UInt32 CONDCSDB_DIO5NACT = 0x00000200;	//Condition on digital I/O #5 not active
        public const UInt32 CONDCSDB_DIO6ACT = 0x00000400;	//Condition on digital I/O #6 active
        public const UInt32 CONDCSDB_DIO6NACT = 0x00000800;	//Condition on digital I/O #6 not active
        public const UInt32 CONDCSDB_DIO7ACT = 0x00001000;	//Condition on digital I/O #7 active
        public const UInt32 CONDCSDB_DIO7NACT = 0x00002000;	//Condition on digital I/O #7 not active
        public const UInt32 CONDCSDB_DIO8ACT = 0x00004000;	//Condition on digital I/O #8 active
        public const UInt32 CONDCSDB_DIO8NACT = 0x00008000;	//Condition on digital I/O #8 not active

        /**
        *
        *  Bit fields of the message activity flag.
        *
        **/

        public const UInt32 MSGACTCSDB_CHMASK = 0xFF00;	//Channel number mask value
        public const UInt32 MSGACTCSDB_CHSHIFT = 0x0008;	//Channel number shift value
        public const UInt32 MSGACTCSDB_ERR = 0x0080;	//Error bit
        public const UInt32 MSGACTCSDB_BIT = 0x0040;	//Bit time error bit
        public const UInt32 MSGACTCSDB_NRZ = 0x0020;	//NRZ bit error
        public const UInt32 MSGACTCSDB_EDGE = 0x0010;	//Edge bit error
        public const UInt32 MSGACTCSDB_PAR = 0x0008;	//Parity error bit
        public const UInt32 MSGACTCSDB_FRAME = 0x0004;	//Frame error bit
        public const UInt32 MSGACTCSDB_HIT = 0x0001;	//Always set

        /**
        *
        *  Channel info fields.
        *
        **/

        public const UInt32 INFOCSDB_PARAM = 0x0001;	//Channel supports parametric control

    }	//end class
}	//end namespace
