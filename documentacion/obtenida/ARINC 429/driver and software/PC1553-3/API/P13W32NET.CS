using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class P13W32
    {
        /**
        *
        *  PC1553-3 WIN32 DRIVER  Version 1.4  (02/20/1998)
        *  Copyright (c) 1998
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   P13W32NET.CS -- 32-bit
        *                      PC1553-3 Driver Include Header File.
        *
        **/

        /**
        *
        *  Structs used by the PC1553-3 Driver.
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
        *  PC1553-3 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the PC1553-3 Driver.
        *
        **/

        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCConfig(UInt32 configval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCCreateMsg@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_BCCreateMsg(UInt32 configval, UInt16 cwd1, UInt16 cwd2, ref UInt16 data, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedFrame@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedFrame(UInt32 timeval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedMsg@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedMsg(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedRetry@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedRetry(UInt16 condition, UInt16 retries, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCTransmitMsg@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCTransmitMsg(ref XMITFIELDS xmitfieldsval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardClose(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardOpen@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_CardOpen(UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardOpenP12@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_CardOpenP12(UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CardReset(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardStart(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardStop(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ErrorCtrl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ErrorCtrl(UInt32 ctrlval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ErrorDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ErrorDefine(UInt32 defineval, UInt16 errvalue, Int32 countval, UInt16 wordpos, UInt16 bitpos, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ErrorSent@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ErrorSent(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ErrorTagBC@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ErrorTagBC(Int32 tagval, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ErrorTagRT@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ErrorTagRT(Int32 tagval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonConfig(UInt32 configval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonFilterSA@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonFilterSA(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonFilterTA@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonFilterTA(UInt32 tamask, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonIsRunning(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MonRd(ref UInt16 buf, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_MsgDataRd(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_MsgDataWr(ref UInt16 buf, Int32 count, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgFieldRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MsgFieldRd(UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgFieldWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MsgFieldWr(UInt32 fieldval, UInt16 fieldtype, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RTConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_RTConfig(UInt32 configval, Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RTCreateMsg@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_RTCreateMsg(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RTGetMsg@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_RTGetMsg(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RTSWDWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_RTSWDWr(UInt16 swdval, Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValPackCWD@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_ValPackCWD(Int32 taval, Int32 trflag, Int32 saval, Int32 wcval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValUnpackCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_ValUnpackCWD(UInt16 cwdval, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 wcval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Bitset@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC1553_Bitset(UInt16 wordval, Int32 bitvalue, Int32 bitnum);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Bittest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC1553_Bittest(UInt16 wordval, Int32 bitnum);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Clearlist@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC1553_Clearlist(Int32 fh);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Config@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC1553_Config(Int32 reg0, Int32 reg1, Int32 reg2, Int32 portval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Execute@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC1553_Execute(ref string nameptr, ref UInt16 swdptr, IntPtr dwdptr, Int32 segval, Int32 portval, Int32 fh);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Freedrv@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC1553_Freedrv();
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Loadlist@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC1553_Loadlist(ref string filename);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Maskshift@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC1553_Maskshift(UInt16 inputval, Int32 startbit, Int32 lengthval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Packcwd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC1553_Packcwd(Int32 taval, Int32 trval, Int32 saval, Int32 wcval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Packwd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 PC1553_Packwd(UInt16 inputval, UInt16 oldval, Int32 startbit, Int32 lengthval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Readbcdwd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC1553_Readbcdwd(Int32 countval, Int32 startval, IntPtr destptr, Int32 segval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Readresp@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC1553_Readresp(Int32 portval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Readrtdwd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC1553_Readrtdwd(Int32 trval, Int32 saval, Int32 countval, Int32 startval, IntPtr destptr, Int32 segval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Readwd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC1553_Readwd(Int32 offset, Int32 segval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Transmit@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 PC1553_Transmit(Int32 portval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Writebcdwd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC1553_Writebcdwd(Int32 countval, Int32 startval, IntPtr srcptr, Int32 segval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Writertdwd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC1553_Writertdwd(Int32 trval, Int32 saval, Int32 countval, Int32 startval, IntPtr srcptr, Int32 segval);
        [DllImport("P13W32.DLL", EntryPoint = "_PC1553_Writewd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void PC1553_Writewd(Int32 value, Int32 offset, Int32 segval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Bitset@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P12_Bitset(UInt16 wordval, Int32 bitvalue, Int32 bitnum);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Bittest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Bittest(UInt16 wordval, Int32 bitnum);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Checklist@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Checklist(Int32 fh);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Clearlist@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Clearlist(Int32 fh);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Config@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Config(Int32 reg0, Int32 reg1, Int32 reg2, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Execconfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Execconfig(ref string nameptr, Int32 fh, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Execmsg@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Execmsg(ref string nameptr, IntPtr bufptr, ref UInt16 swdptr, Int32 fh, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Execute@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Execute(ref string nameptr, ref UInt16 swdptr, IntPtr dwdptr, Int32 fh, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Freedrv@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Freedrv();
        [DllImport("P13W32.DLL", EntryPoint = "_P12_In@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_In(Int32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Loadlist@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Loadlist(ref string filename);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Locate@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Locate(Int32 keytype, ref string nameptr, Int32 fh);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Maskshift@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P12_Maskshift(UInt16 inputval, Int32 startbit, Int32 lengthval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Out@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Out(Int32 dataval, Int32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Packcwd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P12_Packcwd(Int32 taval, Int32 trval, Int32 saval, Int32 wcval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Packwd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P12_Packwd(UInt16 inputval, UInt16 oldval, Int32 startbit, Int32 lengthval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Readb@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Readb(Int32 fh);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Readbcdwd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Readbcdwd(Int32 countval, Int32 startval, IntPtr destptr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Readresp@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Readresp(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Readrtdwd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Readrtdwd(Int32 trval, Int32 saval, Int32 countval, Int32 startval, IntPtr destptr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Readw@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Readw(Int32 fh);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Readwd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Readwd(Int32 offset, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Readwds@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Readwds(Int32 offval, IntPtr destptr, Int32 cntval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Transmit@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P12_Transmit(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Writebcdwd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Writebcdwd(Int32 countval, Int32 startval, IntPtr srcptr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Writertdwd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Writertdwd(Int32 trval, Int32 saval, Int32 countval, Int32 startval, IntPtr srcptr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Writewd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Writewd(Int32 value, Int32 offset, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P12_Writewds@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P12_Writewds(Int32 offval, IntPtr srcptr, Int32 cntval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_AddrDSP@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_AddrDSP(UInt32 addr);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_AddrHost@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_AddrHost(UInt32 addr);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCConfigEx(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCConfigMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_BCConfigMsg(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedAgain@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedAgain(Int32 index, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedBranch@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedBranch(UInt16 condition, Int32 destindex, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedBranchDin0@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedBranchDin0(Int32 destindex, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedBranchDin1@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedBranchDin1(Int32 destindex, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedBranchEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedBranchEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, Int32 destindex, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedBuild@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedBuild(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedCall(Int32 destindex, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedCallCond@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedCallCond(UInt16 condition, Int32 destindex, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedCallCondEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedCallCondEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, Int32 destindex, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedEntry@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedEntry(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedFrameEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedFrameEnd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedFrameStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedFrameStart(UInt32 timeval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedGap@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedGap(UInt16 gapval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedGoto@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedGoto(Int32 destindex, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedHalt@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedHalt(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedInt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedInt(UInt16 tagval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedIntCond@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedIntCond(UInt16 condition, UInt16 tagval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedIntCondEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedIntCondEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 tagval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedNop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedNop(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedPause@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedPause(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedPulse@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedPulse(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedPulse0@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedPulse0(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedPulse1@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedPulse1(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedRestart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedRestart(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedRetryEx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedRetryEx(UInt16 condition1, UInt16 condition2, UInt16 condition3, UInt16 retryflag, UInt16 retries, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedReturn@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedReturn(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSchedUser@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSchedUser(UInt32 useraddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSetEntry@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSetEntry(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BCSetTimeout@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BCSetTimeout(UInt16 timeoutval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_BlkAddr(Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_BlkOptRd(Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BlkOptWr(UInt16 rtopt, Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkPtrRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_BlkPtrRd(Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkPtrWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_BlkPtrWr(UInt32 descaddr, Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BlkRd(ref UInt16 block, Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BlkReset(Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkSWDRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_BlkSWDRd(Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkSWDWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BlkSWDWr(UInt16 swdval, Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BlkWipe(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_BlkWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_BlkWr(ref UInt16 block, Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardBoot@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardBoot(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardCloseAll@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardCloseAll();
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardConfig(Int32 enableflag, UInt16 command, UInt16 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardGetInfo@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_CardGetInfo(UInt16 infotype, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardGetInfoEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardGetInfoEx(ref UInt16 bufmodel, UInt16 bufmodelcount, ref UInt16 buffeature, UInt16 buffeaturecount, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardInit@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CardInit();
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardIsRunning@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardIsRunning(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardNop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardNop(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardOpenEx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_CardOpenEx(ref string cardname, UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardOpenExx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_CardOpenExx(ref string cardname, UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardResetEx@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CardResetEx(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardResume(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardTest@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardTest(UInt16 level, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardTest0@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardTest0(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardTest1@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardTest1(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardTest2@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardTest2(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardTest3@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CardTest3(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CardTrigger@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CardTrigger(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_CmdAddr(Int32 index, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_CmdAlloc(UInt16 count, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdBaseRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_CmdBaseRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdBaseWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CmdBaseWr(UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CmdClear(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdCountRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_CmdCountRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdCountWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CmdCountWr(UInt16 countval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdCtrlRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_CmdCtrlRd(Int32 index, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdCtrlWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CmdCtrlWr(UInt16 ctrlval, Int32 index, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdCurrRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_CmdCurrRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdCurrWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CmdCurrWr(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CmdInit(UInt16 opcode, ref UInt16 block);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdInsert@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CmdInsert(ref UInt16 block, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdMaxRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_CmdMaxRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdMaxWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CmdMaxWr(UInt16 count, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CmdRd(ref UInt16 block, UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdShotWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CmdShotWr(Int32 value, Int32 index, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdSkipWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CmdSkipWr(Int32 value, Int32 index, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdStackClr@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CmdStackClr(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdStartRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_CmdStartRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdStartWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CmdStartWr(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdTotalRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CmdTotalRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdTotalWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CmdTotalWr(Int32 countval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CmdWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CmdWr(ref UInt16 block, UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommCall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CommCall(UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommCheck@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CommCheck(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommDisable@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CommDisable(UInt16 command, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CommEnable(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_CommRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CommRdsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_CommRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommRun@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CommRun(ref UInt16 dataptr, UInt16 datacount, ref UInt16 codeptr, UInt16 codecount, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CommWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_CommWrsW(ref UInt16 valueptr, UInt32 addrval, UInt16 count, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_CommWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_CommWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DARClr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_DARClr(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DARGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_DARGet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DARRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_DARRdL(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DARRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_DARRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DARSet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_DARSet(UInt16 maskval, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DARWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_DARWrL(UInt32 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DARWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_DARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DescAddr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_DescAddr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DescAlloc@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_DescAlloc(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DescConfig@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_DescConfig(UInt32 configval, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DescOptRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_DescOptRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DescOptWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_DescOptWr(UInt16 descopt, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DescPtrRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_DescPtrRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DescPtrWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_DescPtrWr(UInt32 msgaddr, Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DescRd@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_DescRd(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DescWr@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_DescWr(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, ref UInt16 desc, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_Div@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_Div(UInt32 diva, UInt32 divb);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_DllUsageCount();
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DspBioRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_DspBioRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DspIntfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_DspIntfClear(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DspIntfRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_DspIntfRead(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DspIntmClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_DspIntmClear(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DspIntmSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_DspIntmSet(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DspXfClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_DspXfClear(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_DspXfSet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_DspXfSet(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ErrorIsTaggedBC@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ErrorIsTaggedBC(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ErrorIsTaggedRT@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ErrorIsTaggedRT(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ErrorResponse@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ErrorResponse(UInt16 responseval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ErrorSync@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_ErrorSync(Int32 value, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ErrorTimeout@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ErrorTimeout(UInt16 timeoutval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ExtDinRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ExtDinRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ExtDinWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_ExtDinWr(Int32 dinval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ExtDoutRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ExtDoutRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ExtDoutWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_ExtDoutWr(Int32 doutval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_FileClose@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_FileClose(IntPtr handle);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_FileErr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_FileErr();
        [DllImport("P13W32.DLL", EntryPoint = "_P13_FileErrClr@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_FileErrClr();
        [DllImport("P13W32.DLL", EntryPoint = "_P13_FileErrSet@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_FileErrSet();
        [DllImport("P13W32.DLL", EntryPoint = "_P13_FileOpenRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* P13_FileOpenRead(ref string filename);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_FileOpenWrite@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* P13_FileOpenWrite(ref string filename);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_FileRead@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_FileRead(IntPtr handle, IntPtr buffer, UInt16 count);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_FileSeek@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_FileSeek(IntPtr handle, UInt32 offset);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_FileTell@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_FileTell(IntPtr handle);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_FileWrite@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_FileWrite(IntPtr handle, IntPtr buffer, UInt16 count);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_GetHigh@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_GetHigh(UInt32 val);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_GetLow@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_GetLow(UInt32 val);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_GlobalRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_GlobalRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_GlobalWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_GlobalWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_HandleDel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_HandleDel(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_HandleGet@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_HandleGet(ref UInt32 memval, ref UInt32 sizval, ref UInt32 ioval, ref UInt16 irqval, ref UInt16 drqval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_HandleGetIo@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_HandleGetIo(UInt16 ioval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_HandleGetMem@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_HandleGetMem(UInt32 memval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_HandleIns@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_HandleIns(ref string cardname, UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval, IntPtr happwnd, UInt16 uiremovalmsg);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_HandleOkay@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_HandleOkay(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_HeapAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_HeapAlloc(UInt32 wordcount, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_HeapAllocAll@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_HeapAllocAll(ref UInt32 wordcount, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_HeapAllocEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_HeapAllocEx(UInt16 configval, UInt32 wordcount, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_HeapWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_HeapWipe(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IndirectRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_IndirectRd(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IndirectWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_IndirectWr(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_IntClear(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_IntConfig(UInt16 configval, UInt16 count, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntDisable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_IntDisable(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_IntEnable(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntEnableCond@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_IntEnableCond(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntGet@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern unsafe IntPtr* P13_IntGet(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_IntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_IntRd(ref UInt16 typevalval, ref UInt16 infoval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_IntReset(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_IntStatus(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_IntUninstall(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IORdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_IORdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IOWINRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_IOWINRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IOWINWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_IOWINWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_IOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_IOWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernBegin@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        unsafe public static extern Int32 P13_KernBegin(IntPtr* vxdptr, ref string cardname, UInt32 memval, UInt16 ioval, UInt16 irqval, UInt16 drqval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernDev@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernDev(ref UInt32 valueptr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernEnd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernIntClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernIntClear(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernIntInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernIntInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernIntStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernIntStatus(ref Int32 valueptr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernIntUninstall@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernIntUninstall(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernIORdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernIORdW(ref UInt16 valueptr, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernIOWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernIOWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernMEMFillW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernMEMFillW(UInt16 value, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernMEMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernMEMRdsW(ref UInt16 bufptr, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernMEMRdW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernMEMRdW(ref UInt16 valueptr, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernMEMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernMEMWrsW(ref UInt16 bufptr, UInt16 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernMEMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernMEMWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_KernStatus@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_KernStatus(ref UInt32 valueptr, UInt32 typeval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ListConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_ListConfig(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MakeLong@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MakeLong(UInt16 valh, UInt16 vall);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_Mask@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_Mask(UInt32 dataval, UInt16 cntval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MEMWINRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MEMWINRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MEMWINRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MEMWINRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MEMWINRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MEMWINRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MEMWINWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_MEMWINWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MEMWINWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_MEMWINWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MEMWINWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_MEMWINWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_Mod@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_Mod(UInt32 moda, UInt32 modb);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ModeIsBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ModeIsBC(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ModeIsMon@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ModeIsMon(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ModeIsNotBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ModeIsNotBC(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ModeIsNotMon@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ModeIsNotMon(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ModeIsNotRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ModeIsNotRT(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ModeIsNotSerial@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ModeIsNotSerial(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ModeIsRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ModeIsRT(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ModeIsSerial@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ModeIsSerial(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ModeRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_ModeRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ModeWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_ModeWr(UInt16 mode, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonClear(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonConfigEx(UInt32 configval, UInt32 moncount, UInt16 cardnum, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonConfigExx@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonConfigExx(UInt32 configval, UInt32 seqaddr, UInt32 moncount, UInt16 cardnum, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonFilterSAEx@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonFilterSAEx(Int32 taval, UInt32 rcvsamask, UInt32 xmtsamask, UInt32 rcvmcmask, UInt32 xmtmcmask, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonRdEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MonRdEx(ref UInt16 buf, UInt16 bufcount, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonResume@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonResume(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonStart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonStart(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonStatus(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MonStop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MonStop(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgBlockRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MsgBlockRd(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgBlockWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MsgBlockWr(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MsgCheck(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgCommRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MsgCommRd(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgCommWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MsgCommWr(ref UInt16 buf, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MsgConfig(UInt32 configval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MsgConfigEx(UInt32 configval, UInt16 cwd, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgCWD1Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MsgCWD1Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgCWD1Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_MsgCWD1Wr(UInt16 cwd1, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgCWD2Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MsgCWD2Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgCWD2Wr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_MsgCWD2Wr(UInt16 cwd2, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgErrorRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MsgErrorRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgErrorWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_MsgErrorWr(UInt16 value, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgFlagRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MsgFlagRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgFlagWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_MsgFlagWr(UInt16 msgflag, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgIsAccessed@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_MsgIsAccessed(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_MsgReset(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgSWD1Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MsgSWD1Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_MsgSWD2Rd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_MsgSWD2Rd(UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_Mul@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_Mul(UInt32 mula, UInt32 mulb);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_PortRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_PortRd(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_PortWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_PortWr(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ProgRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_ProgRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ProgWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_ProgWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMFill@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_RAMFill(UInt16 value, UInt32 addrval, UInt32 countval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMRdB@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_RAMRdB(UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMRdL@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_RAMRdL(UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMRdsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_RAMRdsW(ref UInt16 valueptr, UInt32 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMRdsxW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_RAMRdsxW(ref UInt16 valueptr, UInt32 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_RAMRdW(UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMWipe@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_RAMWipe(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMWipeEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_RAMWipeEx(UInt16 value, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMWrB@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_RAMWrB(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMWrL@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_RAMWrL(UInt32 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMWrsW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_RAMWrsW(ref UInt16 valueptr, UInt32 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMWrsxW@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_RAMWrsxW(ref UInt16 valueptr, UInt32 addrval, UInt16 countval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RAMWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_RAMWrW(UInt16 value, UInt32 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RTConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_RTConfigEx(UInt32 configval, Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RTConfigExx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_RTConfigExx(UInt32 configval, Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RTReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_RTReset(Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RTStatus@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_RTStatus(Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_RTSWDRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_RTSWDRd(Int32 taval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SARRdW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_SARRdW(UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SARWrW@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_SARWrW(UInt16 value, UInt16 addrval, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SchedBuild@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SchedBuild(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SchedBuildEx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SchedBuildEx(UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 freq, ref UInt16 period, IntPtr buf, UInt16 bufsize, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SchedBuildExx@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SchedBuildExx(UInt32 frametime, UInt16 nummsgs, ref UInt32 msgaddr, ref UInt16 period, IntPtr buf, UInt16 bufsize, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SchedCalc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SchedCalc(ref UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SchedInsEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SchedInsEnd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SchedInsMsg@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SchedInsMsg(UInt16 index, ref UInt32 msgaddr, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SchedInsStart@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SchedInsStart(UInt32 frametime, UInt16 count, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SchedMaxval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_SchedMaxval(ref UInt16 arrayval, UInt16 arrayvalcount);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SchedMinval@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_SchedMinval(ref UInt16 arrayval, UInt16 arrayvalcount);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SerialClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SerialClear(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SerialConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SerialConfig(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SerialConfigEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SerialConfigEx(UInt32 configval, UInt16 count, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SerialStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_SerialStatus(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_SerialWr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_SerialWr(ref UInt16 buf, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_Shl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_Shl(UInt32 dataval, UInt16 cntval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_Shr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_Shr(UInt32 dataval, UInt16 cntval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_TimerClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_TimerClear(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_TimerRd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_TimerRd(UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_TimerResolution@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_TimerResolution(Int32 timerresol, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_TimerResolutionEx@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_TimerResolutionEx(UInt16 timershift, UInt32 handleval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValAsciiCmpi@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ValAsciiCmpi(ref string str1, ref string str2);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValAsciiCpy@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _P13_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count);
        public static string P13_ValAsciiCpy(ref string strdest, ref string strsrc, Int32 count) { return Marshal.PtrToStringAnsi(_P13_ValAsciiCpy(ref strdest, ref strsrc, count)); }
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValAsciiTrimLead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_ValAsciiTrimLead(ref string buf);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValAsciiTrimTrail@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_ValAsciiTrimTrail(ref string buf);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValFromAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 P13_ValFromAscii(ref string asciistr, Int32 radixval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValGetBits@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_ValGetBits(UInt16 oldvalue, Int32 startbit, Int32 endbit);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValIncAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _P13_ValIncAscii(ref string asciistr);
        public static string P13_ValIncAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_P13_ValIncAscii(ref asciistr)); }
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValInccAscii@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _P13_ValInccAscii(ref string asciistr);
        public static string P13_ValInccAscii(ref string asciistr) { return Marshal.PtrToStringAnsi(_P13_ValInccAscii(ref asciistr)); }
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValIsLower@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ValIsLower(Int32 value);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValLenAscii@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ValLenAscii(Int32 numbits, Int32 radixval);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValPackRTCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_ValPackRTCWD(Int32 mcflag, Int32 taval, Int32 trflag, Int32 saval, Int32 count);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValPutBits@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 P13_ValPutBits(UInt16 oldvalue, UInt16 newfld, Int32 startbit, Int32 endbit);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValToAscii@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr _P13_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval);
        public static string P13_ValToAscii(UInt32 value, ref string asciistr, Int32 numbits, Int32 radixval) { return Marshal.PtrToStringAnsi(_P13_ValToAscii(value, ref asciistr, numbits, radixval)); }
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValToUpper@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 P13_ValToUpper(Int32 value);
        [DllImport("P13W32.DLL", EntryPoint = "_P13_ValUnpackRTCWD@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void P13_ValUnpackRTCWD(UInt16 cwd, ref Int32 bcastflag, ref Int32 mcflag, ref Int32 taval, ref Int32 trflag, ref Int32 saval, ref Int32 count);

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

        public const UInt32 INFOTYPE_PLAT = 0x0001;           //Returns the PC1553-3 platform type
        public const UInt32 INFOTYPE_PROD = 0x0002;           //Returns the PC1553-3 product type
        public const UInt32 INFOTYPE_DASH = 0x0003;           //Returns the PC1553-3 dash number
        public const UInt32 INFOTYPE_VERSION = 0x0004;           //Returns the PC1553-3 version number
        public const UInt32 INFOTYPE_DATE = 0x0005;           //Returns the PC1553-3 version date
        public const UInt32 INFOTYPE_MODEL = 0x0006;           //Returns the PC1553-3 model number
        public const UInt32 INFOTYPE_MAXCOUNT = 0x0007;           //Returns the number of terminals the PC1553-3 can simulate
        public const UInt32 INFOTYPE_MULTIMODE = 0x0008;           //Returns whether PC1553-3 can simulate multi-modes
        public const UInt32 INFOTYPE_ERRORGEN = 0x0009;           //Returns whether PC1553-3 can generate errors
        public const UInt32 INFOTYPE_CONCURMON = 0x000A;           //Returns whether PC1553-3 has a concurrent monitor
        public const UInt32 INFOTYPE_MONFILTER = 0x000B;           //Returns whether PC1553-3 has a monitor filter
        public const UInt32 INFOTYPE_USERCODE = 0x000C;           //Returns whether PC1553-3 handles user code
        public const UInt32 INFOTYPE_LISTBUF = 0x000D;           //Returns whether PC1553-3 handles list buffering
        public const UInt32 INFOTYPE_MONFAST = 0x000E;           //Returns whether PC1553-3 has a fast monitor
        public const UInt32 INFOTYPE_MONDMA = 0x000F;           //Returns whether PC1553-3 has a dma monitor
        public const UInt32 INFOTYPE_MONBRAKE = 0x0010;           //Returns whether PC1553-3 has a monitor brake
        public const UInt32 INFOTYPE_80MHZ = 0x0011;           //Returns whether PC1553-3 is using an 80MHz DSP

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
        *  P13 Host Registers
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
        *  P13 Host Indirect Registers
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

        public const UInt32 EREG_STAT = 0x2C80;                 //Status register (RD)
        public const UInt32 EREG_STATCLR = 0x2C81;                 //Status clear register (WR)
        public const UInt32 EREG_STATDEC = 0x2C82;                 //Decoder status register (RD)
        public const UInt32 EREG_VALA = 0x2C84;                 //Decoder word value A register
        public const UInt32 EREG_VALAL = 0x2C84;                 //Decoder low word value A register
        public const UInt32 EREG_VALAH = 0x2C85;                 //Decoder high word value A register
        public const UInt32 EREG_VALB = 0x2C86;                 //Decoder word value B register
        public const UInt32 EREG_VALBL = 0x2C86;                 //Decoder low word value B register
        public const UInt32 EREG_VALBH = 0x2C87;                 //Decoder high word value B register
        public const UInt32 EREG_GAPE = 0x2C88;                 //Encoder gap register
        public const UInt32 EREG_CTRLE = 0x2C89;                 //Encoder control register
        public const UInt32 EREG_VALE = 0x2C8A;                 //Encoder value register
        public const UInt32 EREG_VALEL = 0x2C8A;                 //Encoder low value register
        public const UInt32 EREG_VALEH = 0x2C8B;                 //Encoder high value register
        public const UInt32 EREG_ERRE = 0x2C8C;                 //Encoder error register
        public const UInt32 EREG_FT = 0x2C8E;                 //Frame time register
        public const UInt32 EREG_RST = 0x2C8F;                 //Reset register
        public const UInt32 EREG_GAPA = 0x2C90;                 //Decoder gap time A register
        public const UInt32 EREG_GAPB = 0x2C91;                 //Decoder gap time B register
        public const UInt32 EREG_GAPTO = 0x2C92;                 //Decoder gap timeout register
        public const UInt32 EREG_CFGD = 0x2C94;                 //Decoder configuration register
        public const UInt32 EREG_CFGE = 0x2C95;                 //Encoder configuration register
        public const UInt32 EREG_CFGINT = 0x2C96;                 //Interrupt configuration register
        public const UInt32 EREG_ID = 0x2C97;                 //Identification register

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
        public const Int16 ERR_NOCARD = -13;	//CardOpen() could not find a PC1553-3 card at the specified address
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
