using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class L43W32
    {
        /**
        *
        *  LP429-3 and LC429-3 WIN32 DRIVER  Version 2.0.1  (05/27/2009)
        *  Copyright (c) 1998-2009
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   L43W32NET.CS -- 32-bit
        *                      L43 Driver Include Header File.
        *
        **/

        /**
        *
        *  Structs used by the L43 Driver.
        *
        **/

        [StructLayout(LayoutKind.Sequential)]
        public struct MSGSTRUCT
        {
            public UInt32 addr;
            public UInt32 data;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SEQRECORD
        {
            public UInt16 vercount;
            public UInt16 timestampl;
            public UInt16 timestamph;
            public UInt16 activity;
            public UInt32 data;
            public UInt16 wordnum;       //ARINC 717 records only
            public UInt16 subframe;      //ARINC 717 records only
            public UInt16 superframe;    //ARINC 717 records only
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSGFIELDS
        {
            public UInt16 msgopt;              //User writes message optionvals
            public UInt16 msgact;              //Card writes message activity
            public UInt32 msgdata_listptr; //Card/User writes message data (Rcv/Xmt) - //User writes list buffer pointer
            public UInt32 timetag_hitcount; //Card writes time tag - //Card writes hit count
            public UInt32 maxtime_elapsetime; //Card writes max time - //Card writes elapsed time
            public UInt32 mintime;             //Card writes min time
            public UInt32 userptr;             //User writes user code pointer
            public UInt32 miscptr;             //User writes misc. pointer
            public UInt32 rsvd;             //Reserved
        }

        /**
        *
        *  L43 Driver functions.
        *
        **/

        /**
        *
        *  L43/717 functions.
        *
        **/

        /**
        *
        *  Internal functions used by the L43 Driver.
        *
        **/

        [DllImport("L43W32.DLL", EntryPoint = "_L43_BCDGetData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BCDGetData(UInt32 msg, UInt16 msb, UInt16 lsb);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BCDGetMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BCDGetMant(UInt32 msg, UInt16 sigdig);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BCDGetSign@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_BCDGetSign(UInt32 msg);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BCDGetSSM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_BCDGetSSM(UInt32 msg);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BCDGetVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_BCDGetVal(ref string buf, UInt32 msg, UInt16 sigdig, ref string resolstr);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BCDPutData@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BCDPutData(UInt32 msg, UInt32 value, UInt16 msb, UInt16 lsb);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BCDPutMant@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BCDPutMant(UInt32 msg, UInt32 value, UInt16 sigdig, UInt16 sign);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BCDPutSign@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BCDPutSign(UInt32 msg, UInt16 sign);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BCDPutSSM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BCDPutSSM(UInt32 msg, UInt16 value);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BCDPutVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BCDPutVal(ref string buf, UInt32 msg, UInt16 sigdig, ref string resolstr);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BNRGetData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BNRGetData(UInt32 msg, UInt16 msb, UInt16 lsb);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BNRGetMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BNRGetMant(UInt32 msg, UInt16 sigbit);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BNRGetSign@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_BNRGetSign(UInt32 msg);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BNRGetSSM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_BNRGetSSM(UInt32 msg);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BNRGetVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_BNRGetVal(ref string buf, UInt32 msg, UInt16 sigbit, ref string resolstr);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BNRPutData@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BNRPutData(UInt32 msg, UInt32 value, UInt16 msb, UInt16 lsb);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BNRPutMant@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BNRPutMant(UInt32 msg, UInt32 value, UInt16 sigbit, UInt16 twos);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BNRPutSign@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BNRPutSign(UInt32 msg, UInt16 twos);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BNRPutSSM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BNRPutSSM(UInt32 msg, UInt16 value);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BNRPutVal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_BNRPutVal(ref string buf, UInt32 msg, UInt16 sigbit, ref string resolstr);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BrdNumRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_BrdNumRd(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_BrdNumWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_BrdNumWr(UInt16 brdnum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardClose(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardOpen@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_CardOpen(Int32 cardnum);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CardReset(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardResume(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardStart(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardStop(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardTrigger@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CardTrigger(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ChClear(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ChPause(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChPauseCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ChPauseCheck(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChResume@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ChResume(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ExtDinRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ExtDinRd(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ExtDinWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ExtDinWr(Int32 dinval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ExtDIORd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ExtDIORd(Int32 dionum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ExtDIOWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ExtDIOWr(Int32 dionum, Int32 dioval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ExtLEDRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ExtLEDRd(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ExtLEDWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ExtLEDWr(Int32 ledval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FilterClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_FilterClear(UInt32 basevaladdr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FilterDefault@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FilterDefault(UInt32 configval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FilterRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FilterRd(Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FilterSet@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FilterSet(UInt32 configval, Int32 labelval, Int32 sdimask, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FilterWr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_FilterWr(UInt32 msgaddr, Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldGetData@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FldGetData(UInt32 msgval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldGetLabel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_FldGetLabel(UInt32 msgval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldGetParity@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_FldGetParity(UInt32 msgval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldGetSDI@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_FldGetSDI(UInt32 msgval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldGetValue@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FldGetValue(UInt32 msgval, UInt16 startbit, UInt16 endbit);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldPutData@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FldPutData(UInt32 msgval, UInt32 data);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldPutLabel@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FldPutLabel(UInt32 msgval, UInt16 label);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldPutSDI@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FldPutSDI(UInt32 msgval, UInt16 sdi);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldPutValue@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FldPutValue(UInt32 msgval, UInt32 dataval, UInt16 startbit, UInt16 endbit);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_GetChanCount@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IntConfig(UInt16 configval, UInt16 count, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_IntRd(ref UInt16 typevalval, ref UInt32 infoval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_IntReset(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IntStatus(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IntUninstall(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IsChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IsChan(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IsRcvChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IsRcvChan(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IsXmtChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IsXmtChan(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListAsyncCreate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListAsyncCreate(UInt32 listconfigval, Int32 count, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListDataRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListDataRd(UInt32 listaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListDataWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ListDataWr(UInt32 value, UInt32 listaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListRcvCreate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListRcvCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListXmtCreate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListXmtCreate(UInt32 listconfigval, Int32 count, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_MsgBlockRd(ref MSGFIELDS msgfields, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_MsgBlockWr(ref MSGFIELDS msgfields, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgCommRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_MsgCommRd(ref MSGFIELDS msgfields, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgCommWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_MsgCommWr(ref MSGFIELDS msgfields, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgCreate@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_MsgCreate(UInt32 configval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgDataRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_MsgDataRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgDataWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MsgDataWr(UInt32 value, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgIsAccessed@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedBranch@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedBranch(UInt16 condition, Int32 destindex, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedBuild@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedBuild(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedCall@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedCall(UInt16 condition, Int32 destindex, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedEntry@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedEntry(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedGap@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedGap(UInt16 gapval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedGapFixed@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedGapFixed(UInt16 gapval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedGapList@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedGapList(UInt16 gapval, UInt32 listaddr, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedHalt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedHalt(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedInt@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedInt(UInt16 condition, UInt16 tagval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedMsg(UInt32 msgaddr, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedMsgEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedMsgEx(UInt32 msgaddr, UInt16 gapval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedPause(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedPulse@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedPulse(Int32 dionum, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedRestart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedRestart(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedReturn@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedReturn(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SeqConfig(UInt32 configval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqInterval@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SeqInterval(Int32 interval, Int32 mode, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqIntFrequency@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_SeqIntFrequency(UInt16 intfreq, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SeqIsRunning(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_SeqRd(ref SEQRECORD buf, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SeqStatus(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_TimerClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_TimerClear(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_TimerRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_TimerRd(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_TimerResolution@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_TimerResolution(Int32 timerresol, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Ch717Status@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_Ch717Status(ref UInt16 buf, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Get717ChanCount@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_Get717ChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Is717BiPhaseChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_Is717BiPhaseChan(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Is717Chan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_Is717Chan(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Is717RcvChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_Is717RcvChan(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Is717XmtChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_Is717XmtChan(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SubFrmBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SubFrmBlkRd(ref UInt16 databuf, Int32 subframe, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SubFrmBlkWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SubFrmBlkWr(ref UInt16 databuf, Int32 subframe, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SubFrmStatus@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SubFrmStatus(ref UInt16 buf, Int32 subframe, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SubFrmWordConfig@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SubFrmWordConfig(UInt32 configval, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SubFrmWordRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SubFrmWordRd(ref UInt16 value, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SubFrmWordWr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SubFrmWordWr(UInt16 value, Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SuperFrmConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SuperFrmConfig(Int32 count, Int32 framespersuperframe, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SuperFrmCounterPos@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SuperFrmCounterPos(Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SuperFrmDefine@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SuperFrmDefine(Int32 subframe, Int32 word, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SuperFrmWordRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SuperFrmWordRd(ref UInt16 value, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SuperFrmWordWr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SuperFrmWordWr(UInt16 value, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SuperFrmWordConfig@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SuperFrmWordConfig(UInt32 configval, Int32 superfrmnum, UInt32 superfrmaddr, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SyncTest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SyncTest(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SyncValRd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SyncValRd(ref Int32 syncword1, ref Int32 syncword2, ref Int32 syncword3, ref Int32 syncword4, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SyncValWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SyncValWr(Int32 syncword1, Int32 syncword2, Int32 syncword3, Int32 syncword4, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_AddrDSP@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_AddrDSP(UInt32 addr);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_AddrHost@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_AddrHost(UInt32 addr);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_AsciiToMant@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_AsciiToMant(ref string str, ref UInt32 mant, ref Int32 exp);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardBoot@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardBoot(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardCloseAll@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardCloseAll();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardGetInfo@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_CardGetInfo(UInt16 infotype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardGetInfoEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardGetInfoEx(ref UInt16 bufmodel, UInt16 bufmodelcount, ref UInt16 buffeature, UInt16 buffeaturecount, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardInit@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CardInit();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardIsRunning(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardNop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardNop(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardOpenEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_CardOpenEx(ref string cardname, Int32 cardnum);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardOpenExx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_CardOpenExx(ref string cardname, Int32 cardnum, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardResetEx@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CardResetEx(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardTest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardTest(UInt16 level, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardTest0@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardTest0(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardTest1@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardTest1(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardTest2@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardTest2(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CardTest3@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CardTest3(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CFGRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_CFGRdL(Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CFGWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CFGWrL(UInt32 value, Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Ch717Config@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_Ch717Config(UInt32 configval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Ch717Create@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_Ch717Create(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Ch717Reset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_Ch717Reset(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ChConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChDARClr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ChDARClr(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChDARGet@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ChDARGet(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChDARRdL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ChDARRdL(UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChDARRdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_ChDARRdW(UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChDARSet@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ChDARSet(UInt16 maskval, UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChDARWrL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ChDARWrL(UInt32 value, UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChDARWrW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ChDARWrW(UInt16 value, UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ChStart(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ChStop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ChStop(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_CmdAddr(Int32 index, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_CmdAlloc(Int32 count, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_CmdAllocEx(UInt32 configval, Int32 count, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdBaseRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_CmdBaseRd(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdBaseWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CmdBaseWr(UInt32 addrval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CmdClear(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdCountRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_CmdCountRd(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdCountWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CmdCountWr(UInt16 countval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdCtrlRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_CmdCtrlRd(Int32 index, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdCtrlWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CmdCtrlWr(UInt16 ctrlval, Int32 index, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdCurrRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_CmdCurrRd(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdCurrWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CmdCurrWr(UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CmdInit(UInt16 opcode, ref UInt16 block);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdInsert@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CmdInsert(ref UInt16 block, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdMaxRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_CmdMaxRd(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdMaxWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CmdMaxWr(UInt16 count, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdShotWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CmdShotWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdSkipWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CmdSkipWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdStackClr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CmdStackClr(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdStartRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_CmdStartRd(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdStartWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CmdStartWr(UInt16 addrval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdStepWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CmdStepWr(Int32 value, Int32 index, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdTotalRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CmdTotalRd(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdTotalWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CmdTotalWr(Int32 countval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CmdWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CommCall(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommCheck@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CommCheck(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommDisable@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CommDisable(UInt16 command, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommDisableEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CommDisableEx(UInt16 command, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CommEnable(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_CommRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CommRdsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_CommRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommRun@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CommRun(ref UInt16 dataptr, UInt16 datacount, ref UInt16 codeptr, UInt16 codecount, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CommWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_CommWrsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_CommWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_CommWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ConvFromArinc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ConvFromArinc(UInt32 msgval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ConvToArinc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ConvToArinc(UInt32 msgval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DARClr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DARClr(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DARGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_DARGet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DARRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_DARRdL(UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DARRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_DARRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DARSet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DARSet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DARWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DARWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DARWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Div@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_Div(UInt32 diva, UInt32 divb);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_DllUsageCount();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_DPMMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DPMMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_DPMRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_DPMRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMRdsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DPMRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DPMRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_DPMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DPMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DPMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMWrsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DPMWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DPMWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DPMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_DPMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DspBioRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_DspBioRd(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DspHmClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_DspHmClear(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DspHmSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_DspHmSet(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DspIntfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_DspIntfClear(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DspIntfRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_DspIntfRead(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DspIntmClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_DspIntmClear(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DspIntmSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_DspIntmSet(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DspXfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_DspXfClear(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_DspXfSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_DspXfSet(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ErrDesc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L43_ErrDesc(Int32 errval);
        public static string L43_ErrDesc(Int32 errval) { return Marshal.PtrToStringAnsi(_L43_ErrDesc(errval)); }
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ErrDescStr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L43_ErrDescStr(Int32 errval);
        public static string L43_ErrDescStr(Int32 errval) { return Marshal.PtrToStringAnsi(_L43_ErrDescStr(errval)); }
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ErrName@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L43_ErrName(Int32 errval);
        public static string L43_ErrName(Int32 errval) { return Marshal.PtrToStringAnsi(_L43_ErrName(errval)); }
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ExpandMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ExpandMant(ref UInt32 mant, ref Int32 exp);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ExtDIODirSet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ExtDIODirSet(Int32 dionum, Int32 dirval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ExtLEDWINRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ExtLEDWINRd(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ExtLEDWINWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ExtLEDWINWr(Int32 ledval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FileClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_FileClose(IntPtr handle);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FileErr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_FileErr();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FileErrClr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_FileErrClr();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FileErrSet@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_FileErrSet();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FileOpenRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* L43_FileOpenRead(ref string filename);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FileOpenWrite@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* L43_FileOpenWrite(ref string filename);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FileRead@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_FileRead(IntPtr handle, IntPtr buffer, UInt16 count);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FileSeek@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_FileSeek(IntPtr handle, UInt32 offset);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FileTell@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FileTell(IntPtr handle);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FileWrite@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_FileWrite(IntPtr handle, IntPtr buffer, UInt16 count);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FilterAddr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FilterAddr(Int32 labelval, Int32 sdival, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FilterCreate@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FilterCreate(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FilterFill@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_FilterFill(UInt32 msgaddr, UInt32 basevaladdr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldGetParBit@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_FldGetParBit(UInt32 msgval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_FldPutParBit@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_FldPutParBit(UInt32 msgval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_GetHigh@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_GetHigh(UInt32 val);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_GetLow@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_GetLow(UInt32 val);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_GlobalRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_GlobalRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_GlobalWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_GlobalWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HandleClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_HandleClose(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HandleDel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_HandleDel(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HandleGet@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_HandleGet(ref string cardstr, ref Int32 cardnum, ref Int32 devnum, ref UInt32 sizval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HandleIns@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_HandleIns(ref string cardname, Int32 cardnum, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HandleOkay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_HandleOkay(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HandleOpen@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_HandleOpen(ref string cardname, Int32 cardnum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HandleOpenWin95@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_HandleOpenWin95(ref string cardname, Int32 cardnum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HandleOpenWinNT@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_HandleOpenWinNT(ref string cardname, Int32 cardnum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HandleVer@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_HandleVer(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HandleVerPLX@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_HandleVerPLX(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HeapAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_HeapAlloc(UInt32 wordcount, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HeapAllocAll@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_HeapAllocAll(ref UInt32 wordcount, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HeapAllocAllDPM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_HeapAllocAllDPM(ref UInt16 wordcount, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HeapAllocDPM@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_HeapAllocDPM(UInt16 wordcount, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HeapAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_HeapAllocEx(UInt16 configval, UInt32 wordcount, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HeapWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_HeapWipe(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_HeapWipeDPM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_HeapWipeDPM(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IndirectRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_IndirectRd(Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IndirectWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_IndirectWr(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IntClear(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntDisable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IntDisable(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IntEnable(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntEnableCond@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_IntEnableCond(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IntGet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* L43_IntGet(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IORdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_IORdW(Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IOWINRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_IOWINRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IOWINWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_IOWINWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_IOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_IOWrW(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernBegin@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        unsafe public static extern Int32 L43_KernBegin(IntPtr* vxdptr, ref string cardstr, ref string cardname, Int32 busnum, Int32 devnum, Int32 funcnum);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernDev@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernDev(ref Int32 valueptr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernEnd(IntPtr vxdptr);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernIntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernIntClear(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernIntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernIntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernIntParam@32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernIntParam(UInt32 clraddr, UInt32 clrwidth, UInt32 clrvalue, UInt32 stataddr, UInt32 statwidth, UInt32 statvalue, UInt32 statmask, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernIntStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernIntStatus(ref Int32 valueptr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernIntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernIntUninstall(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernIORdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernIORdW(ref UInt16 valueptr, Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernIOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernIOWrW(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernMEMFillW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernMEMFillW(UInt16 value, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernMEMRdL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernMEMRdL(ref UInt32 valueptr, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernMEMRdsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernMEMRdsL(ref UInt32 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernMEMRdsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernMEMRdsW(ref UInt16 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernMEMRdW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernMEMRdW(ref UInt16 valueptr, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernMEMWrL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernMEMWrL(UInt32 value, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernMEMWrsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernMEMWrsL(ref UInt32 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernMEMWrsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernMEMWrsW(ref UInt16 bufptr, Int32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernMEMWrW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernMEMWrW(UInt16 value, Int32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernQuick@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernQuick(Int32 flag, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernStatus@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernStatus(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_KernStatusEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_KernStatusEx(ref UInt32 valueptr, UInt32 typeval, UInt32 index, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_LabelReverse@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_LabelReverse(UInt32 msgval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListAddr(Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListAddrEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListAddrEx(Int32 index, UInt32 listaddr, ref UInt16 header);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListAdvance@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ListAdvance(UInt32 listaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ListClear(UInt32 listaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListConfig(UInt32 configval, Int32 count, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListConfigEx(UInt32 configval, Int32 count, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListDataBlkWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ListDataBlkWr(ref UInt32 dataptr, UInt16 datacount, UInt32 listaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListDataRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListDataRdEx(Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListDataWrEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ListDataWrEx(UInt32 value, Int32 index, UInt32 listaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListInit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ListInit(UInt32 listaddr, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListNextRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListNextRd(UInt32 listaddr, ref UInt16 header);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListNextWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ListNextWr(UInt32 listaddr, ref UInt16 header);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListPostRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ListPostRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListPostWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ListPostWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListPreRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ListPreRd(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListPreWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ListPreWr(UInt32 listaddr, ref UInt16 header, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ListStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ListStatus(UInt32 listaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MakeLong@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_MakeLong(UInt16 valh, UInt16 vall);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MantToAscii@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L43_MantToAscii(ref string buf, Int32 mant, Int32 exp);
        public static string L43_MantToAscii(ref string buf, Int32 mant, Int32 exp) { return Marshal.PtrToStringAnsi(_L43_MantToAscii(ref buf, mant, exp)); }
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Mask@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_Mask(UInt32 dataval, Int32 cntval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MaxMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MaxMant(ref UInt32 mant, ref Int32 exp);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINFillW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MEMWINFillW(UInt16 value, UInt32 addrval, UInt32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINRdB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_MEMWINRdB(UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINRdL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_MEMWINRdL(UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINRdsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MEMWINRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINRdsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MEMWINRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINRdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_MEMWINRdW(UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINWrB@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MEMWINWrB(UInt16 value, UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINWrL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MEMWINWrL(UInt32 value, UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINWrsL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MEMWINWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINWrsW@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MEMWINWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MEMWINWrW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MEMWINWrW(UInt16 value, UInt32 addrval, Int32 bustype, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Mod@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_Mod(UInt32 moda, UInt32 modb);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgActivityRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_MsgActivityRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgActivityWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MsgActivityWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_MsgCheck(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_MsgConfig(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_MsgReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_MsgReset(UInt32 msgaddr, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Mul@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_Mul(UInt32 mula, UInt32 mulb);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_NormalMant@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_NormalMant(ref UInt32 mant, ref Int32 exp);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_PortRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_PortRd(Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_PortWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_PortWr(UInt16 value, Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ProgRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_ProgRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ProgWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ProgWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMFill@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_RAMFill(UInt16 value, UInt32 addrval, UInt32 countval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMIsDPM@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_RAMIsDPM(UInt32 addrval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_RAMRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_RAMRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMRdsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_RAMRdsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_RAMRdsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_RAMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_RAMWipe(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMWipeEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_RAMWipeEx(UInt16 value, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_RAMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_RAMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMWrsL@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_RAMWrsL(ref UInt32 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_RAMWrsW(ref UInt16 valueptr, UInt32 addrval, Int32 countval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_RAMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_RAMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedAdvance@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SchedAdvance();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedAgain@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedAgain(Int32 index, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedBranchEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedBranchEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedBuildEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedBuildEx(Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedBuildExx@40", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedBuildExx(Int32 basevalmsgnum, Int32 nummsgs, ref UInt32 msgaddr, ref Int32 minperiod, ref Int32 maxperiod, Int32 speed, IntPtr buf, UInt32 bufsize, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedCalc@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SchedCalc();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedCallEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedCallEx(UInt16 condition1, UInt16 condition2, Int32 destindex, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedCheck(ref Int32 minperiod, ref Int32 maxperiod);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedCheckEnd@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedCheckEnd();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedCheckMiddle@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedCheckMiddle(UInt32 msgnum, UInt32 minlen, UInt32 midlen, UInt32 maxlen);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedCheckReal@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedCheckReal(UInt32 msgnum, UInt32 minlen, UInt32 midlen, UInt32 maxlen);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedCheckStart@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedCheckStart();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedConflicts@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SchedConflicts();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedDisplay@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        unsafe public static extern void L43_SchedDisplay(UInt32 nummsgs, ref UInt32 count, ref UInt32* data);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedDivide@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedDivide();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedFix@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SchedFix();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedFixEnd@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedFixEnd();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedFixMiddle@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedFixMiddle(UInt32 conflicts);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedFixStart@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedFixStart();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedHook@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedHook(Int32 index, IntPtr ptr);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedInsert@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedInsert(UInt32 eventvals, UInt32 index, UInt32 msgnum, ref UInt32 msgaddr, UInt32 gapval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedInsertEnd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedInsertEnd(UInt32 eventvals, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedInsertStart@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedInsertStart(UInt32 eventvals, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedIntEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedIntEx(UInt16 condition1, UInt16 condition2, UInt16 tagval, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedLayout@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedLayout();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedMaxval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SchedMaxval(ref UInt32 arrayval, UInt32 arrayvalcount);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedMinval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SchedMinval(ref UInt32 arrayval, UInt32 arrayvalcount);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedNop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedNop(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedParse@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedParse(Int32 basevalmsgnum, ref UInt32 msgaddr, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedPulse0@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedPulse0(Int32 dionum, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedPulse1@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedPulse1(Int32 dionum, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedReset@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedReset();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedRotate@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SchedRotate();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedShift@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedShift(Int32 msgnum, Int32 value);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedSlide@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedSlide();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedSlideEnd@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedSlideEnd();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedSlideMiddle@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedSlideMiddle(UInt32 index, UInt32 count, UInt32 conflicts);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedSlideStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedSlideStart(UInt32 factor);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedSort@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedSort();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedToBit@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SchedToBit(UInt32 value);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedToMsec@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SchedToMsec(UInt32 value);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedUnsort@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SchedUnsort();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedUser@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SchedUser(UInt32 useraddr, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SchedWalk@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SchedWalk();
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEEPokeW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SEEPokeW(Int32 value, Int32 numbits, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEERdBit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SEERdBit(ref Int32 valueptr, Int32 bitnum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEERdL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SEERdL(ref UInt32 valueptr, Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEERdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SEERdW(ref Int32 valueptr, Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEEWrBit@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SEEWrBit(Int32 value, Int32 bitnum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEEWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SEEWrL(UInt32 value, Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEEWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SEEWrW(Int32 value, Int32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEMMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_SEMMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEMMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SEMMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_SEMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SEMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_SEMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqBlkRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SeqBlkRd(ref UInt16 buf, UInt32 bufcount, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqBlkRdEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SeqBlkRdEx(ref UInt16 buf, UInt32 bufcount, UInt32 maxblkcnt, ref UInt32 blkcnt, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SeqClear(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SeqConfigEx(UInt32 configval, UInt32 seqcount, UInt16 cardnum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqConfigExx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SeqConfigExx(UInt32 configval, UInt32 seqaddr, UInt32 seqcount, UInt16 cardnum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqIntervalEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_SeqIntervalEx(UInt16 shiftval, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_SeqRdEx(ref UInt16 buf, UInt16 bufcount, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SeqResume(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SeqStart(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SeqStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SeqStop(UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Shl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_Shl(UInt32 dataval, Int32 cntval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Shr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_Shr(UInt32 dataval, Int32 cntval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SignMant@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_SignMant(ref string str);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SubFrmAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SubFrmAddr(Int32 subframe, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SubFrmCreate@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SubFrmCreate(UInt32 configval, Int32 subframe, UInt32 chanbase, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SubFrmReset@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SubFrmReset(Int32 subframe, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SuperFrmBaseAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_SuperFrmBaseAddr(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SuperFrmConfigEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SuperFrmConfigEx(UInt32 configval, Int32 count, Int32 framespersuperframe, Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SuperFrmReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SuperFrmReset(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_SyncValPtrInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_SyncValPtrInit(Int32 channum, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_TimerResolutionEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_TimerResolutionEx(UInt16 timershift, UInt32 handleval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_Transpose12@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 L43_Transpose12(UInt16 val);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValAsciiCmpi@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ValAsciiCmpi(ref string str1, ref string str2);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValAsciiCpy@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L43_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count);
        public static string L43_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count) { return Marshal.PtrToStringAnsi(_L43_ValAsciiCpy(ref strdest, ref strsrc, count)); }
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValAsciiTrimLead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ValAsciiTrimLead(ref string buf);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValAsciiTrimTrail@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void L43_ValAsciiTrimTrail(ref string buf);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValFromAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ValFromAscii(ref string asciistr, Int32 radixval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValGetBits@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ValGetBits(UInt32 oldvalue, Int32 startbit, Int32 endbit);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValIncAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L43_ValIncAscii(ref string asciistr);
        public static string L43_ValIncAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_L43_ValIncAscii(ref asciistr)); }
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValInccAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L43_ValInccAscii(ref string asciistr);
        public static string L43_ValInccAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_L43_ValInccAscii(ref asciistr)); }
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValIsLower@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ValIsLower(Int32 value);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValLenAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ValLenAscii(Int32 numbits, Int32 radixval);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValPutBits@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 L43_ValPutBits(UInt32 oldvalue, UInt32 newfld, Int32 startbit, Int32 endbit);
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValToAscii@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _L43_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval);
        public static string L43_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval) { return Marshal.PtrToStringAnsi(_L43_ValToAscii(value, ref asciistr, numbits, radixval)); }
        [DllImport("L43W32.DLL", EntryPoint = "_L43_ValToUpper@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 L43_ValToUpper(Int32 value);

        public const UInt32 CH0 = 0x0000;					//Channel 0
        public const UInt32 CH1 = 0x0001;					//Channel 1
        public const UInt32 CH2 = 0x0002;					//Channel 2
        public const UInt32 CH3 = 0x0003;					//Channel 3
        public const UInt32 CH4 = 0x0004;					//Channel 4
        public const UInt32 CH5 = 0x0005;					//Channel 5
        public const UInt32 CH6 = 0x0006;					//Channel 6
        public const UInt32 CH7 = 0x0007;					//Channel 7

        public const UInt32 SDI00 = 0x0001;					//Enable SDI00
        public const UInt32 SDI01 = 0x0002;					//Enable SDI01
        public const UInt32 SDI10 = 0x0004;					//Enable SDI10
        public const UInt32 SDI11 = 0x0008;					//Enable SDI11
        public const UInt32 SDIALL = 0x000F;					//Enable all SDIs

        public const UInt32 SUBFRM1 = 0x0001;               //Sub Frame 1 (717)
        public const UInt32 SUBFRM2 = 0x0002;               //Sub Frame 2 (717)
        public const UInt32 SUBFRM3 = 0x0003;               //Sub Frame 3 (717)
        public const UInt32 SUBFRM4 = 0x0004;               //Sub Frame 4 (717)

        /**
        *
        *  Channel configuration options
        *
        **/

        public const UInt32 CHCFG_DEFAULT = 0x00000000;
        public const UInt32 CHCFG_HIGHSPEED = 0x00000001;
        public const UInt32 CHCFG_AUTOSPEED = 0x00000002;
        public const UInt32 CHCFG_LOWSPEED = 0x00000000;
        public const UInt32 CHCFG_SELFTEST = 0x00000004;
        public const UInt32 CHCFG_SELFTESTOFF = 0x00000000;
        public const UInt32 CHCFG_SYNC = 0x00000008;
        public const UInt32 CHCFG_SYNCOFF = 0x00000000;
        public const UInt32 CHCFG_PARODD = 0x00000000;
        public const UInt32 CHCFG_PAREVEN = 0x00000010;
        public const UInt32 CHCFG_PARDATA = 0x00000020;
        public const UInt32 CHCFG_ACTIVE = 0x00000000;
        public const UInt32 CHCFG_INACTIVE = 0x00000040;
        public const UInt32 CHCFG_EXTTRIG = 0x00000080;
        public const UInt32 CHCFG_EXTOFF = 0x00000000;
        public const UInt32 CHCFG_PARERR = 0x00000100;
        public const UInt32 CHCFG_NOERR = 0x00000000;
        public const UInt32 CHCFG_HIT = 0x00000200;
        public const UInt32 CHCFG_NOHIT = 0x00000000;
        public const UInt32 CHCFG_TIMETAG = 0x00000400;
        public const UInt32 CHCFG_TIMETAGOFF = 0x00000000;
        public const UInt32 CHCFG_ELAPSE = 0x00000800;
        public const UInt32 CHCFG_ELAPSEOFF = 0x00000000;
        public const UInt32 CHCFG_MAX = 0x00001000;
        public const UInt32 CHCFG_MIN = 0x00002000;
        public const UInt32 CHCFG_MAXMIN = 0x00003000;
        public const UInt32 CHCFG_MAXMINOFF = 0x00000000;
        public const UInt32 CHCFG_SEQALL = 0x00080000;
        public const UInt32 CHCFG_SEQSEL = 0x00000000;
        public const UInt32 CHCFG_INTHALT = 0x00200000;
        public const UInt32 CHCFG_NOINTHALT = 0x00000000;
        public const UInt32 CHCFG_INTPAUSE = 0x00400000;
        public const UInt32 CHCFG_NOINTPAUSE = 0x00000000;
        public const UInt32 CHCFG_INTERR = 0x00800000;
        public const UInt32 CHCFG_NOINTERR = 0x00000000;
        public const UInt32 CHCFG_PAUSE = 0x01000000;
        public const UInt32 CHCFG_UNPAUSE = 0x00000000;
        public const UInt32 CHCFG_RAM = 0x00000000;
        public const UInt32 CHCFG_DPRAM = 0x80000000;

        public const UInt32 CHCFG717_DEFAULT = 0x00000000;
        public const UInt32 CHCFG717_AUTOSPEED = 0x00000002;
        public const UInt32 CHCFG717_64WPS = 0x00004000;
        public const UInt32 CHCFG717_128WPS = 0x00008000;
        public const UInt32 CHCFG717_256WPS = 0x00000000;
        public const UInt32 CHCFG717_512WPS = 0x00010000;
        public const UInt32 CHCFG717_1024WPS = 0x00020000;
        public const UInt32 CHCFG717_2048WPS = 0x00040000;
        public const UInt32 CHCFG717_4096WPS = 0x02000000;
        public const UInt32 CHCFG717_8192WPS = 0x04000000;
        public const UInt32 CHCFG717_BIPHASERCV = 0x00000000;
        public const UInt32 CHCFG717_BIPHASEXMT = 0x08000000;
        public const UInt32 CHCFG717_BIPOLARHSPD = 0x08000000;
        public const UInt32 CHCFG717_SELFTEST = 0x00000004;
        public const UInt32 CHCFG717_SELFTESTOFF = 0x00000000;
        public const UInt32 CHCFG717_SYNC = 0x00000008;
        public const UInt32 CHCFG717_SYNCOFF = 0x00000000;
        public const UInt32 CHCFG717_ACTIVE = 0x00000000;
        public const UInt32 CHCFG717_INACTIVE = 0x00000040;
        public const UInt32 CHCFG717_EXTTRIG = 0x00000080;
        public const UInt32 CHCFG717_EXTOFF = 0x00000000;
        public const UInt32 CHCFG717_HIT = 0x00000200;
        public const UInt32 CHCFG717_NOHIT = 0x00000000;
        public const UInt32 CHCFG717_TIMETAG = 0x00000400;
        public const UInt32 CHCFG717_TIMETAGOFF = 0x00000000;
        public const UInt32 CHCFG717_SEQALL = 0x00080000;
        public const UInt32 CHCFG717_SEQSEL = 0x00000000;
        public const UInt32 CHCFG717_INTERR = 0x00800000;
        public const UInt32 CHCFG717_NOINTERR = 0x00000000;
        public const UInt32 CHCFG717_PAUSE = 0x01000000;
        public const UInt32 CHCFG717_UNPAUSE = 0x00000000;

        /**
        *
        *  Sequential Record configuration options
        *
        **/

        public const UInt32 SEQCFG_DEFAULT = 0x00000000;
        public const UInt32 SEQCFG_FILLHALT = 0x00000000;
        public const UInt32 SEQCFG_DISABLE = 0x00000001;
        public const UInt32 SEQCFG_CONTINUOUS = 0x00000002;
        public const UInt32 SEQCFG_FREE = 0x00000008;
        public const UInt32 SEQCFG_DELTA = 0x00000010;
        public const UInt32 SEQCFG_INTERVAL = 0x00000020;
        public const UInt32 SEQCFG_NOINTFULL = 0x00000000;
        public const UInt32 SEQCFG_INTFULL = 0x00001000;
        public const UInt32 SEQCFG_NOINTFREQ = 0x00000000;
        public const UInt32 SEQCFG_INTFREQ = 0x00002000;
        public const UInt32 SEQCFG_16K = 0x00000000;
        public const UInt32 SEQCFG_ALLAVAIL = 0x01000000;
        public const UInt32 SEQCFG_32K = 0x02000000;
        public const UInt32 SEQCFG_64K = 0x04000000;
        public const UInt32 SEQCFG_128K = 0x08000000;
        public const UInt32 SEQCFG_DPRAM = 0x10000000;

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

        public const UInt32 INFOTYPE_PLAT = 0x0001;           //Returns the L43 platform type
        public const UInt32 INFOTYPE_PROD = 0x0002;           //Returns the L43 product type
        public const UInt32 INFOTYPE_DASH = 0x0003;           //Returns the L43 dash number
        public const UInt32 INFOTYPE_VERSION = 0x0004;           //Returns the L43 version number
        public const UInt32 INFOTYPE_DATE = 0x0005;           //Returns the L43 version date
        public const UInt32 INFOTYPE_MODEL = 0x0006;           //Returns the L43 model number
        public const UInt32 INFOTYPE_MAXCOUNT = 0x0007;           //Returns the max channel count
        public const UInt32 INFOTYPE_USERCODE = 0x000A;           //Returns whether L43 handles user code
        public const UInt32 INFOTYPE_LISTBUF = 0x000B;           //Returns whether L43 handles list buffering
        public const UInt32 INFOTYPE_ARINC717 = 0x000C;           //Returns whether L43 has ARINC 717 channels

        /**
        *
        *  Message configuration options
        *
        **/

        public const UInt32 MSGCRT_DEFAULT = 0x00000000;
        public const UInt32 MSGCRT_NOSEQ = 0x00000000;
        public const UInt32 MSGCRT_SEQ = 0x00000001;
        public const UInt32 MSGCRT_NOINT = 0x00000000;
        public const UInt32 MSGCRT_INT = 0x00000002;
        public const UInt32 MSGCRT_NOLIST = 0x00000000;
        public const UInt32 MSGCRT_LIST = 0x00000004;
        public const UInt32 MSGCRT_NOSKIP = 0x00000000;
        public const UInt32 MSGCRT_SKIP = 0x00000008;
        public const UInt32 MSGCRT_NOTIMETAG = 0x00000000;
        public const UInt32 MSGCRT_TIMETAG = 0x00000010;
        public const UInt32 MSGCRT_NOELAPSE = 0x00000000;
        public const UInt32 MSGCRT_ELAPSE = 0x00000020;
        public const UInt32 MSGCRT_NOMAXMIN = 0x00000000;
        public const UInt32 MSGCRT_MAX = 0x00000040;
        public const UInt32 MSGCRT_MIN = 0x00000080;
        public const UInt32 MSGCRT_MAXMIN = 0x000000C0;
        public const UInt32 MSGCRT_NOSYNC = 0x00000000;
        public const UInt32 MSGCRT_SYNC = 0x00000100;
        public const UInt32 MSGCRT_NOERR = 0x00000000;
        public const UInt32 MSGCRT_PARERR = 0x00000200;
        public const UInt32 MSGCRT_NOHIT = 0x00000000;
        public const UInt32 MSGCRT_HIT = 0x00000400;
        public const UInt32 MSGCRT_NOEXTRIG = 0x00000000;
        public const UInt32 MSGCRT_EXTRIG = 0x00001000;
        public const UInt32 MSGCRT_WIPE = 0x00000000;
        public const UInt32 MSGCRT_NOWIPE = 0x80000000;
        public const UInt32 MSGCRT_WIPE0 = 0x00000000;
        public const UInt32 MSGCRT_WIPE1 = 0x40000000;
        public const UInt32 MSGCRT_CHAN = 0x00000000;
        public const UInt32 MSGCRT_RAM = 0x20000000;
        public const UInt32 MSGCRT_DPRAM = 0x10000000;

        /**
        *
        *  Sub Frame word configuration options (717)
        *
        **/

        public const UInt32 WRDCFG_DEFAULT = 0x00000000;
        public const UInt32 WRDCFG_SFINT = 0x00000001;
        public const UInt32 WRDCFG_SFINTOFF = 0x00000000;
        public const UInt32 WRDCFG_WRDINT = 0x00000002;
        public const UInt32 WRDCFG_WRDINTOFF = 0x00000000;
        public const UInt32 WRDCFG_SEQ = 0x00000004;
        public const UInt32 WRDCFG_SEQOFF = 0x00000000;

        /**
        *
        *  List buffer options
        *
        **/

        public const UInt32 LISTCRT_DEFAULT = 0x00000000;
        public const UInt32 LISTCRT_FIFO = 0x00000000;
        public const UInt32 LISTCRT_PINGPONG = 0x00000001;
        public const UInt32 LISTCRT_CIRCULAR = 0x00000002;
        public const UInt32 LISTCRT_RCV = 0x00000010;
        public const UInt32 LISTCRT_XMT = 0x00000020;
        public const UInt32 LISTCRT_NOINT = 0x00000000;
        public const UInt32 LISTCRT_INT = 0x00000100;
        public const UInt32 LISTCRT_RAM = 0x00000000;
        public const UInt32 LISTCRT_DPRAM = 0x00200000;

        /**
        *
        *  Bit fields of the message activity flag.
        *
        **/

        public const UInt32 MSGACT_BRD = 0xF000;		//All bits of Board number
        public const UInt32 MSGACT_BRD3 = 0x8000;		//Bit 3 of Board number
        public const UInt32 MSGACT_BRD2 = 0x4000;		//Bit 2 of Board number
        public const UInt32 MSGACT_BRD1 = 0x2000;		//Bit 1 of Board number
        public const UInt32 MSGACT_BRD0 = 0x1000;		//Bit 0 of Board number
        public const UInt32 MSGACT_CHAN = 0x0F00;		//All bits of Channel number
        public const UInt32 MSGACT_CHAN3 = 0x0800;		//Bit 3 of Channel number
        public const UInt32 MSGACT_CHAN2 = 0x0400;		//Bit 2 of Channel number
        public const UInt32 MSGACT_CHAN1 = 0x0200;		//Bit 1 of Channel number
        public const UInt32 MSGACT_CHAN0 = 0x0100;		//Bit 0 of Channel number
        public const UInt32 MSGACT_ASPD = 0x0080;		//Auto Speed
        public const UInt32 MSGACT_ERR = 0x0040;		//Error bit
        public const UInt32 MSGACT_GAP = 0x0020;		//Gap error bit
        public const UInt32 MSGACT_PAR = 0x0010;		//Parity error bit
        public const UInt32 MSGACT_LONG = 0x0008;		//Long word error bit
        public const UInt32 MSGACT_BIT = 0x0004;		//Bit time error bit
        public const UInt32 MSGACT_TO = 0x0002;		//Time out error bit
        public const UInt32 MSGACT_HIT = 0x0001;		//Always set

        public const UInt32 MSGACT717_BRD = 0xF000;		//All bits of Board number
        public const UInt32 MSGACT717_BRD3 = 0x8000;		//Bit 3 of Board number
        public const UInt32 MSGACT717_BRD2 = 0x4000;		//Bit 2 of Board number
        public const UInt32 MSGACT717_BRD1 = 0x2000;		//Bit 1 of Board number
        public const UInt32 MSGACT717_BRD0 = 0x1000;		//Bit 0 of Board number
        public const UInt32 MSGACT717_CHAN = 0x0F00;		//All bits of Channel number
        public const UInt32 MSGACT717_CHAN3 = 0x0800;		//Bit 3 of Channel number
        public const UInt32 MSGACT717_CHAN2 = 0x0400;		//Bit 2 of Channel number
        public const UInt32 MSGACT717_CHAN1 = 0x0200;		//Bit 1 of Channel number
        public const UInt32 MSGACT717_CHAN0 = 0x0100;		//Bit 0 of Channel number
        public const UInt32 MSGACT717_SPD = 0x00E0;		//All bits of current speed
        public const UInt32 MSGACT717_SPD2 = 0x0080;		//Bit 2 of current speed
        public const UInt32 MSGACT717_SPD1 = 0x0040;		//Bit 1 of current speed
        public const UInt32 MSGACT717_SPD0 = 0x0020;		//Bit 0 of current speed
        public const UInt32 MSGACT717_TO = 0x0002;		//Time out error bit
        public const UInt32 MSGACT717_HIT = 0x0001;		//Always set

        /**
        *
        *  L43 IFGA Registers
        *
        **/

        public const UInt32 IREG_STAT = 0x0040;                  //Status register (RD)
        public const UInt32 IREG_SET = 0x0041;                  //Set register (WR)
        public const UInt32 IREG_CLR = 0x0042;                  //Clear register (WR)
        public const UInt32 IREG_ID = 0x0043;                  //ID register (RD)
        public const UInt32 IREG_PAGE = 0x0044;                  //Page register
        public const UInt32 IREG_CONFIG = 0x0045;                  //Configuration register
        public const UInt32 IREG_INT = 0x0046;                  //Interrupt register
        public const UInt32 IREG_PRESCL = 0x0047;                  //Prescale Register for clock divider

        /**
        *
        *  EDGA Registers
        *
        **/

        public const UInt32 EREG1_GSTAT = 0x1180;	//Global Status
        public const UInt32 EREG1_CHSTAT = 0x0181;	//Channel Status
        public const UInt32 EREG1_CHDATAH = 0x0182;	//Channel Data High Word
        public const UInt32 EREG1_CHDATAL = 0x0183;	//Channel Data Low Word
        public const UInt32 EREG1_CHGAP = 0x0184;	//Channel Gap
        public const UInt32 EREG1_CHCNTL = 0x0185;	//Channel Control Word
        public const UInt32 EREG1_CHCFG = 0x0186;	//Channel Config
        public const UInt32 EREG1_CHCFGINT = 0x0187;	//Channel Int Config
        public const UInt32 EREG1_GERR = 0x0188;	//Global Error Register
        public const UInt32 EREG1_GRST = 0x0189;	//Global Reset
        public const UInt32 EREG1_GID = 0x018C;	//Global ID

        public const UInt32 EREG2_GSTAT = 0x1280;	//Global Status
        public const UInt32 EREG2_CHSTAT = 0x0281;	//Channel Status
        public const UInt32 EREG2_CHDATAH = 0x0282;	//Channel Data High Word
        public const UInt32 EREG2_CHDATAL = 0x0283;	//Channel Data Low Word
        public const UInt32 EREG2_CHGAP = 0x0284;	//Channel Gap
        public const UInt32 EREG2_CHCNTL = 0x0285;	//Channel Control Word
        public const UInt32 EREG2_CHCFG = 0x0286;	//Channel Config
        public const UInt32 EREG2_CHCFGINT = 0x0287;	//Channel Int Config
        public const UInt32 EREG2_GERR = 0x0288;	//Global Error Register
        public const UInt32 EREG2_GRST = 0x0289;	//Global Reset
        public const UInt32 EREG2_GID = 0x028C;	//Global ID

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
        *  Interrupt types.
        *
        **/

        public const UInt32 INTTYPE_MSG = 0x0001;               //Message interrupt
        public const UInt32 INTTYPE_OPCODE = 0x0002;               //Interrupt opcode
        public const UInt32 INTTYPE_HALT = 0x0003;               //Schedule halt
        public const UInt32 INTTYPE_PAUSE = 0x0004;               //Schedule pause
        public const UInt32 INTTYPE_SEQFULL = 0x0005;               //Sequential record full
        public const UInt32 INTTYPE_LIST = 0x0006;               //List buffer empty/full
        public const UInt32 INTTYPE_ERR = 0x0007;               //Decoder error detected
        public const UInt32 INTTYPE_SEQFREQ = 0x0008;               //Sequential record frequency
        public const UInt32 INTTYPE_717WORD = 0x0009;               //717 word received
        public const UInt32 INTTYPE_717SUBFRM = 0x000A;               //717 sub frame completed
        public const UInt32 INTTYPE_717SYNCERR = 0x000B;               //717 Rcv channel lost synchronization

        /**
        *
        *  Timer resolutions.
        *
        **/

        public const UInt16 TIMERRESOL_1US = 1;	//1us timer resolution, 1:11:34 range
        public const UInt16 TIMERRESOL_16US = 2;	//16us timer resolution, 19:05:19 range
        public const UInt16 TIMERRESOL_1024US = 3;	//1024us timer resolution, 50 day range
        public const UInt16 TIMERRESOL_16348US = 4;	//16348us timer resolution, 814 day range

        /**
        *
        *  Interval calculation modes.
        *
        **/

        public const UInt16 INTERVALMODE_CLOSEST = 1;	//Finds interval closest to value specified
        public const UInt16 INTERVALMODE_LESS = 2;	//Finds closest interval less than value specified
        public const UInt16 INTERVALMODE_GREATER = 3;	//Finds closest interval more than value specified

        /**
        *
        *  Scheduling conditions.
        *
        **/

        public const UInt32 COND_ALWAYS = 0x0000;
        public const UInt32 COND_DIO1ACT = 0x0001;
        public const UInt32 COND_DIO1NACT = 0x0081;
        public const UInt32 COND_DIO2ACT = 0x0002;
        public const UInt32 COND_DIO2NACT = 0x0082;
        public const UInt32 COND_DIO3ACT = 0x0003;
        public const UInt32 COND_DIO3NACT = 0x0083;
        public const UInt32 COND_DIO4ACT = 0x0004;
        public const UInt32 COND_DIO4NACT = 0x0084;

        public const UInt16 SEQRD_MAX_COUNT = 9;

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
        public const Int16 ERR_NOCARD = -13;	//CardOpen() could not find a L43 card at the specified address
        public const Int16 ERR_NOIO = -14;	//CardOpen() could not find the I/O ports
        public const Int16 ERR_NOMEM = -15;	//CardOpen() could not find the memory
        public const Int16 ERR_BAD16BIT = -16;	//Card is conflicting with another 16-bit card
        public const Int16 ERR_WRONGMODEL = -17;	//Card does not support this feature
        public const Int16 ERR_NOSEL = -18;	//CardOpen() could not allocate a memory selector
        public const Int16 ERR_LOCK = -19;	//The communication process is locked up
        public const Int16 ERR_TOOMANY = -20;	//Too many channels have been configured
        public const Int16 ERR_BADHANDLE = -21;	//A bad handle was specified
        public const Int16 ERR_NOTCHAN = -23;	//Not a valid channel
        public const Int16 ERR_NOTXMT = -24;	//The Transmitter has not been configured
        public const Int16 ERR_NOTRCV = -25;	//The Receiver has not been configured
        public const Int16 ERR_NOTSEQ = -26;	//The Sequential Record has not been configured
        public const Int16 ERR_ALLOC = -27;	//There is not enough memory to allocate
        public const Int16 ERR_VXD = -28;	//An error occurred in the VXD
        public const Int16 ERR_BADLABEL = -29;	//The specified label value is not valid
        public const Int16 ERR_BADSDI = -30;	//The specified sdi value is not valid
        public const Int16 ERR_BADMSG = -31;	//The specified command block is not a message block
        public const Int16 ERR_BADSCHNDX = -32;	//Specified command index is out of range
        public const Int16 ERR_BUFSIZE = -33;	//Insufficient space in user buffer
        public const Int16 ERR_NOCONFIG = -34;	//The card has not been properly configured
        public const Int16 ERR_CONFLICTS = -35;	//Unable to resolve conflicts
        public const Int16 ERR_RANGE = -36;	//Schedule is out of range
        public const Int16 ERR_FACTOR = -37;	//A bad factor value was specified
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
        public const Int16 ERR_TYPE = -54;	//There was a bad type value in the HEX file
        public const Int16 ERR_ZEROLEN = -55;	//Zero length was specified
        public const Int16 ERR_BADADDRESS = -56;	//A bad address was specified
        public const Int16 ERR_SELFIOFAIL = -71;	//I/O selftest failed
        public const Int16 ERR_SELFMEMFAIL = -72;	//Memory selftest failed
        public const Int16 ERR_SELFCOMMFAIL = -73;	//Communication selftest failed
        public const Int16 ERR_SELFXMTFAIL = -74;	//Transmit selftest failed
        public const Int16 ERR_PLXBUG = -75;	//PLX bug is causing problems
        public const Int16 ERR_NOT717CHAN = -100;	//Specified channel is not a 717 channel
        public const Int16 ERR_SUBFRMNUM = -101;	//Invalid 717 SubFrame number was specified
        public const Int16 ERR_WORDNUM = -102;	//Invalid 717 Word number was specified
        public const Int16 ERR_NOTINSYNC = -103;	//Not Synchronized to 717 databus
        public const Int16 ERR_SUPERFRM = -104;	//SuperFrame not configured
        public const Int16 ERR_SUPERFRMNUM = -105;	//Invalid 717 SuperFrame number was specified

    }	//end class
}	//end namespace
