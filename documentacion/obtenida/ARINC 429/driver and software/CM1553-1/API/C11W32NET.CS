using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class C11W32
    {
        /**
        *
        *  CM1553-1 WIN32 DRIVER Version 1.2  (04/09/1999)
        *  Copyright (c) 1997,1999
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   C11W32NET.CS -- WIN32 CM1553-1 Driver
        *                      Include Header File.
        *
        **/

        /**
        *
        *  CM1553-1 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the CM1553-1 Driver.
        *
        **/

        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCBranchEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCBranchEnd(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCCallFrame@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCCallFrame(Int32 index, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCCheckMsg@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCCheckMsg(Int32 index, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCConfig@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCConfig(UInt32 configflags, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCConfigEx(UInt32 configflags, Int32 cmdcountval, Int32 cyccountval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCDoAgain@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCDoAgain(Int32 index, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCDoGap@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCDoGap(Int32 gapval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCDoGoto@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCDoGoto(Int32 destindex, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCDoHalt@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCDoHalt(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCDoInt@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCDoInt(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCDoMsg@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCDoMsg(Int32 busab, UInt16 cwdval, ref UInt16 datavals, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCDoResv@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCDoResv(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCDoRTRT@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCDoRTRT(Int32 busab, UInt16 cwd1val, UInt16 cwd2val, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCDoSelfTest@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCDoSelfTest(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCFrameEnd@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCFrameEnd(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCFrameStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCFrameStart(Int32 timeval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCMsgBranch@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCMsgBranch(Int32 index, Int32 destindex, Int32 condition, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCMsgRetry@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCMsgRetry(Int32 index, Int32 retries, Int32 condition, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCRdData@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCRdData(Int32 index, ref UInt16 data, UInt16 count, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCRdSWD1@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCRdSWD1(Int32 index, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCRdSWD2@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCRdSWD2(Int32 index, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCWrData@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCWrData(Int32 index, ref UInt16 data, UInt16 count, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_CloseCard@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_CloseCard(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetBitFld@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetBitFld(UInt16 oldvalue, Int32 startbit, Int32 endbit);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_INTInstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_INTInstall(IntPtr hevent, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_INTRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_INTRd(Int32 index, ref UInt16 typeval, ref UInt16 eventval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_INTUninstall@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_INTUninstall(IntPtr hevent, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_INTUnmask@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_INTUnmask(UInt16 maskval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_MONConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_MONConfig(UInt32 configflags, UInt16 moncount, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_MONCount@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_MONCount(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_MONRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_MONRd(UInt16 index, ref UInt16 blockinfo, ref UInt16 datawords, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_MONTermAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_MONTermAddr(UInt16 termaddr, Int32 enableflag, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_OpenCard@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C11_OpenCard(Int32 card_number);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PackCWD@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_PackCWD(Int32 taval, Int32 trval, Int32 saval, Int32 wcval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PeekMem@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_PeekMem(UInt16 wordoffset, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PokeMem@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_PokeMem(UInt16 data, UInt16 wordoffset, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PutBitFld@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_PutBitFld(UInt16 oldvalue, UInt16 newfld, Int32 startbit, Int32 endbit);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RdPort@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RdPort(UInt16 register, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_Reset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_Reset(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_Restart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_Restart(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTAccessed@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTAccessed(UInt16 cwd, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_RTConfig(UInt32 configflags, UInt16 rtaddr, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTCountList@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_RTCountList(UInt16 cwd, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTIllegal@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_RTIllegal(UInt16 cwd, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTInitList@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTInitList(UInt16 cwd, Int32 count, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTInt@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_RTInt(UInt16 cwd, UInt16 value, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTMONConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_RTMONConfig(UInt32 configflags, UInt16 rtaddr, UInt16 moncount, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTRdData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTRdData(UInt16 cwd, ref UInt16 data, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTRdDataEx@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTRdDataEx(UInt16 cwd, ref UInt16 infodata, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTRdList@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTRdList(UInt16 cwd, UInt16 index, ref UInt16 infodata, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTRstList@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTRstList(UInt16 cwd, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTWrData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTWrData(UInt16 cwd, ref UInt16 data, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTWrSWD@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_RTWrSWD(UInt16 statusflags, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SelfTest@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_SelfTest(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_Start@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_Start(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_Stop@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_Stop(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_TransmitMsg@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_TransmitMsg(Int32 busab, UInt16 cwd, ref UInt16 dataptr, ref UInt16 swd, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_TransmitRTRT@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_TransmitRTRT(Int32 busab, UInt16 cwd1, UInt16 cwd2, ref UInt16 dataptr, ref UInt16 swd1, ref UInt16 swd2, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_UnpackCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_UnpackCWD(UInt16 cwdval, ref Int32 taval, ref Int32 trval, ref Int32 saval, ref Int32 wcval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_WrPort@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_WrPort(UInt16 data, UInt16 register, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCAddrData@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCAddrData(Int32 index, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCBlockAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCBlockAddr(Int32 index, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCBlockClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_BCBlockClear(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCBlockCount@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCBlockCount(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCBlockCtrl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCBlockCtrl(Int32 index, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCBlockInit@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_BCBlockInit(ref UInt16 block, UInt16 opcode);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCBlockInsert@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_BCBlockInsert(ref UInt16 block, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCBlockRead@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCBlockRead(Int32 index, ref UInt16 block, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCBlockWrite@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCBlockWrite(Int32 index, ref UInt16 block, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCCycleAddr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCCycleAddr(Int32 index, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCCycleClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_BCCycleClear(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCCycleInsert@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCCycleInsert(ref UInt16 cycle, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCCycleRestart@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_BCCycleRestart(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_BCCycleWrite@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_BCCycleWrite(Int32 index, ref UInt16 cycle, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_ClrAllILLEGAL@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_ClrAllILLEGAL(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_ClrILLEGAL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_ClrILLEGAL(Int32 subaddr, Int32 trbit, Int32 mcflag, Int32 bcastflag, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_Div@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C11_Div(UInt32 diva, UInt32 divb);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_FillMem@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_FillMem(UInt16 data, UInt16 wordoffset, Int32 iwordcount, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetBCAST@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetBCAST(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetBUF@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetBUF(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetCHAN@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetCHAN(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetCIRCLE@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetCIRCLE(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetDYNBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetDYNBC(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetEXT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetEXT(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetHigh@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetHigh(UInt32 val);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetILLEGAL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetILLEGAL(Int32 subaddr, Int32 trbit, Int32 mcflag, Int32 bcastflag, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetINT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetINT(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetIntLog@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetIntLog(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetINTMASK@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetINTMASK(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetLow@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetLow(UInt32 val);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetMODE@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetMODE(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetMonCtrl@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetMonCtrl(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetMonFilt@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_GetMonFilt(ref UInt16 valuel, ref UInt16 valueh, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetPP@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetPP(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetRTADDR@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetRTADDR(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetStatus@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetStatus(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetSTD@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetSTD(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetTIMEOUT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetTIMEOUT(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_GetXMTSW@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_GetXMTSW(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_HeapAlloc@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_HeapAlloc(UInt16 wordcount, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_HeapAvail@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_HeapAvail(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_HeapClear@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_HeapClear(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_HeapRdHead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_HeapRdHead(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_HeapWrHead@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_HeapWrHead(UInt16 value, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_INTDisable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_INTDisable(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_INTEnable@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_INTEnable(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_INTRdPend@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_INTRdPend(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_INTRdPoll@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_INTRdPoll(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_INTReset@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_INTReset(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_IsBC@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_IsBC(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_IsMON@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_IsMON(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_IsRT@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_IsRT(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_IsRTMON@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_IsRTMON(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_MakeLong@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C11_MakeLong(UInt16 valh, UInt16 vall);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_Mask@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C11_Mask(UInt32 dataval, UInt16 cntval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_Mod@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C11_Mod(UInt32 moda, UInt32 modb);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_MONAll@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_MONAll(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_MONBlockBase@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_MONBlockBase(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_MONDataBase@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_MONDataBase(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_MONNone@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_MONNone(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_Mul@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C11_Mul(UInt32 mula, UInt32 mulb);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_OkayHandle@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_OkayHandle(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_OpenDevice@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C11_OpenDevice(IntPtr device_id);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PackRTCWD@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_PackRTCWD(Int32 subaddr, Int32 trbit, Int32 mcflag, Int32 bcastflag, Int32 count);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PeekAttr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern byte C11_PeekAttr(UInt16 wordoffset, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PeekStrAttr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_PeekStrAttr(ref UInt16 pwbuffer, UInt16 wordoffset, Int32 iwordcount, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PeekStrMem@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_PeekStrMem(ref UInt16 pwbuffer, UInt16 wordoffset, Int32 iwordcount, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PokeAttr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_PokeAttr(byte data, UInt16 wordoffset, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PokeStrAttr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_PokeStrAttr(ref UInt16 pwbuffer, UInt16 wordoffset, Int32 iwordcount, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_PokeStrMem@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_PokeStrMem(ref UInt16 pwbuffer, UInt16 wordoffset, Int32 iwordcount, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTAddrData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTAddrData(UInt16 typeval, UInt16 cwd, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTAddrDesc@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTAddrDesc(UInt16 typeval, UInt16 cwd, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTAddrParity@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_RTAddrParity(Int32 rtaddr);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTInitData@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_RTInitData(UInt16 scheme, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTPokeData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTPokeData(UInt16 cwd, ref UInt16 data, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTRdDesc@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTRdDesc(UInt16 cwd, ref UInt16 desc, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_RTWrDesc@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_RTWrDesc(UInt16 cwd, ref UInt16 desc, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetAllILLEGAL@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetAllILLEGAL(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetBCAST@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetBCAST(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetBUF@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetBUF(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetCHAN@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetCHAN(UInt16 chanval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetCIRCLE@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetCIRCLE(UInt16 circleval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetDYNBC@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetDYNBC(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetEXT@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetEXT(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetILLEGAL@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetILLEGAL(Int32 subaddr, Int32 trbit, Int32 mcflag, Int32 bcastflag, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetINT@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetINT(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetIntLog@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetIntLog(UInt16 addressval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetINTMASK@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetINTMASK(UInt16 maskval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetLog@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern Int32 C11_SetLog(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetMODE@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetMODE(UInt16 modeval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetMonCtrl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetMonCtrl(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetMonFilt@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetMonFilt(UInt16 valuel, UInt16 valueh, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetPP@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetPP(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetRTADDR@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetRTADDR(UInt16 rtaddr, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetStatus@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetStatus(UInt16 flags, UInt16 immclear, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetSTD@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetSTD(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetTIMEOUT@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetTIMEOUT(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_SetXMTSW@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_SetXMTSW(UInt16 enableval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_Shl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C11_Shl(UInt32 dataval, UInt16 cntval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_Shr@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 C11_Shr(UInt32 dataval, UInt16 cntval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_StatRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_StatRead(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_TTRead@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt16 C11_TTRead(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_TTSet@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_TTSet(UInt16 timetagval, UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_TTZero@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_TTZero(UInt32 handleval);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_UnpackRTCWD@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_UnpackRTCWD(UInt16 cwd, ref Int32 subaddr, ref Int32 trbit, ref Int32 mcflag, ref Int32 bcastflag, ref Int32 count);
        [DllImport("C11W32.DLL", EntryPoint = "_C11_WipeMem@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void C11_WipeMem(UInt32 handleval);

        public const UInt32 CONFIG_DEFAULT = 0x00000000;
        public const UInt32 CONFIG_INTCLK = 0x00000000;
        public const UInt32 CONFIG_EXTCLK = 0x00000001;
        public const UInt32 CONFIG_NOBUF = 0x00000000;
        public const UInt32 CONFIG_BUF = 0x00000002;
        public const UInt32 CONFIG_NOBCAST = 0x00000000;
        public const UInt32 CONFIG_BCAST = 0x00000004;
        public const UInt32 CONFIG_STDB = 0x00000000;
        public const UInt32 CONFIG_STDA = 0x00000008;
        public const UInt32 CONFIG_NODYNBC = 0x00000000;
        public const UInt32 CONFIG_DYNBC = 0x00000010;
        public const UInt32 CONFIG_NOALTRETRY = 0x00000000;
        public const UInt32 CONFIG_ALTRETRY = 0x00000020;
        public const UInt32 CONFIG_NOXMITSW = 0x00000000;
        public const UInt32 CONFIG_XMITSW = 0x00000040;
        public const UInt32 CONFIG_ALLSUBADDR = 0x00000000;
        public const UInt32 CONFIG_NOSUBADDR = 0x00000080;
        public const UInt32 CONFIG_WIPE = 0x00000000;
        public const UInt32 CONFIG_NOWIPE = 0x00000100;
        public const UInt32 CONFIG_INIT = 0x00000000;
        public const UInt32 CONFIG_NOINIT = 0x00000200;
        public const UInt32 CONFIG_LOGLIST = 0x00000000;
        public const UInt32 CONFIG_NOLOGLIST = 0x00000400;
        public const UInt32 CONFIG_NONOTICE2 = 0x00000000;
        public const UInt32 CONFIG_NOTICE2 = 0x00000800;
        public const UInt32 CONFIG_MONALL = 0x00000000;
        public const UInt32 CONFIG_MONNONE = 0x00001000;
        public const UInt32 CONFIG_REGTIMEOUT = 0x00000000;
        public const UInt32 CONFIG_EXTTIMEOUT = 0x00002000;
        public const UInt32 CONFIG_CHANAB = 0x00000000;
        public const UInt32 CONFIG_CHANA = 0x00010000;
        public const UInt32 CONFIG_CHANB = 0x00020000;
        public const UInt32 CONFIG_SINGLEBUF = 0x00000000;
        public const UInt32 CONFIG_PINGPONG = 0x00100000;
        public const UInt32 CONFIG_CIRC1BUF = 0x00200000;
        public const UInt32 CONFIG_CIRC2BUF = 0x00300000;

        public const UInt32 SWD_IMCLR = 0x8000;				//Immediate clear
        public const UInt32 SWD_BIT10 = 0x0200;				//Status word bit 10
        public const UInt32 SWD_INS = 0x0200;				//Instrumentation bit
        public const UInt32 SWD_BIT11 = 0x0100;				//Status word bit 11
        public const UInt32 SWD_SRQ = 0x0100;				//Service request bit
        public const UInt32 SWD_BIT12 = 0x0080;				//Status word bit 12
        public const UInt32 SWD_BIT13 = 0x0040;				//Status word bit 13
        public const UInt32 SWD_BIT14 = 0x0020;				//Status word bit 14
        public const UInt32 SWD_BIT15 = 0x0010;				//Status word bit 15
        public const UInt32 SWD_BIT16 = 0x0008;				//Status word bit 16
        public const UInt32 SWD_BUSY = 0x0008;				//Busy bit
        public const UInt32 SWD_BIT17 = 0x0004;				//Status word bit 17
        public const UInt32 SWD_SSYSF = 0x0004;				//Subsystem flag bit
        public const UInt32 SWD_BIT18 = 0x0002;				//Status word bit 18
        public const UInt32 SWD_BIT19 = 0x0001;				//Status word bit 19
        public const UInt32 SWD_TF = 0x0001;				//Terminal flag

        public const UInt32 INT_DMAF = 0x8000;				//BC,RT,MON
        public const UInt32 INT_WRAPF = 0x4000;				//BC,RT
        public const UInt32 INT_TAPF = 0x2000;				//RT
        public const UInt32 INT_BITF = 0x1000;				//BC,RT,MON
        public const UInt32 INT_MERR = 0x0800;				//BC,RT,MON
        public const UInt32 INT_SUBAD = 0x0400;				//RT
        public const UInt32 INT_BDRCV = 0x0200;				//RT
        public const UInt32 INT_IXEQ0 = 0x0100;				//RT
        public const UInt32 INT_ILCMD = 0x0080;				//RT
        public const UInt32 INT_EOL = 0x0020;				//BC
        public const UInt32 INT_ILLCMD = 0x0010;				//BC
        public const UInt32 INT_ILLOP = 0x0008;				//BC
        public const UInt32 INT_RTF = 0x0004;				//BC
        public const UInt32 INT_CBA = 0x0002;				//BC
        public const UInt32 INT_MBC = 0x0001;				//MON
        public const UInt32 INT_NONE = 0x0000;				//No interrupts

        public const UInt32 REG_INT = 0x0000;					//Interrupt register
        public const UInt32 REG_PAGE = 0x0001;					//Page register
        public const UInt32 REG_EXT = 0x0002;					//External register
        public const UInt32 REG_RESV = 0x0003;					//Reserved register
        public const UInt32 REG_INTC = 0x0004;					//Interrupt clear register
        public const UInt32 REG_RST = 0x0005;					//Reset register
        public const UInt32 REG_ERR = 0x0006;					//Error register
        public const UInt32 REG_PWE = 0x0007;					//Prom write enable register

        public const UInt16 BUSA = 0;	//Selects bus A
        public const UInt16 BUSB = 1;	//Selects bus B

        public const UInt16 MONNO = 0;	//Disables monitoring of a terminal address
        public const UInt16 MONYES = 1;	//Enables monitoring of a terminal address

        public const UInt32 COND_NONE = 0x0000;				//No condition
        public const UInt32 COND_FAIL = 0x2000;				//Condition when all retries have failed
        public const UInt32 COND_UNCOND = 0x4000;				//Unconditional
        public const UInt32 COND_SRQ = 0x0002;				//Condition on Service Request bit set in status word
        public const UInt32 COND_INS = 0x0004;				//Condition on Instrumentation bit set in status word
        public const UInt32 COND_SSFAIL = 0x0008;				//Condition on Subsystem Fail bit set in status word
        public const UInt32 COND_TF = 0x0010;				//Condition on Terminal Flag bit set in status word
        public const UInt32 COND_BUSY = 0x0020;				//Condition on Busy bit set in status word
        public const UInt32 COND_ME = 0x0040;				//Condition on Message Error bit set in status word
        public const UInt32 COND_RESPERR = 0x0080;				//Condition on response error
        public const UInt32 COND_MASK = 0x00FE;

        public const UInt32 SUMMIT_CTRL = 0x0000;			//Control register
        public const UInt32 SUMMIT_OPSTAT = 0x0001;			//Operational status
        public const UInt32 SUMMIT_CURRCMD = 0x0002;			//Current Command
        public const UInt32 SUMMIT_INTMASK = 0x0003;			//Interrupt Mask
        public const UInt32 SUMMIT_INTPEND = 0x0004;			//Interrupt Pending
        public const UInt32 SUMMIT_INTLOG = 0x0005;			//Interrupt Log
        public const UInt32 SUMMIT_BITWORD = 0x0006;			//BIT Word
        public const UInt32 SUMMIT_TTMFT = 0x0007;			//Time-Tag/Minor Frame Timer
        public const UInt32 SUMMIT_RTDACBA = 0x0008;			//RT Descriptor/Command Block Pointer
        public const UInt32 SUMMIT_RTSTATUS = 0x0009;			//RT Status Word
        public const UInt32 SUMMIT_CBC = 0x000A;			//Command Block Init Count
        public const UInt32 SUMMIT_MBA = 0x000B;			//Monitor Block
        public const UInt32 SUMMIT_MDA = 0x000C;			//Monitor Data
        public const UInt32 SUMMIT_MBC = 0x000D;			//Monitor Block Count
        public const UInt32 SUMMIT_MFH = 0x000E;			//Monitor Filter High
        public const UInt32 SUMMIT_MFL = 0x000F;			//Monitor Filter Low

        public const UInt16 ERR_NONE = 0;	//No error
        public const Int16 ERR_UNKNOWN = -1;	//An unexpected error occurred
        public const Int16 ERR_NOCS = -10;	//Card Services is not present
        public const Int16 ERR_NOSOCKET = -11;	//The specified socket is not present
        public const Int16 ERR_NOCARD = -12;	//Unable to find a CM1553-1 card in the specified socket
        public const Int16 ERR_NOTSR = -13;	//Unable to find the CM1553-1 memory resident driver
        public const Int16 ERR_CLIENT = -14;	//Unable to install a local client driver
        public const Int16 ERR_CS = -15;	//An error was returned by Card Services
        public const Int16 ERR_WIN = -16;	//Card Services could not configure the memory window, I/O window, or IRQ steering
        public const Int16 ERR_SEL = -17;	//Unable to allocate a memory selector
        public const Int16 ERR_BADHANDLE = -20;	//A bad handle was specified
        public const Int16 ERR_COUNT = -21;	//An invalid count was specified
        public const Int16 ERR_ALLOC = -22;	//Not enough memory to allocate
        public const Int16 ERR_INDEX = -23;	//The command block index was invalid or the schedule is full
        public const Int16 ERR_RETRY = -31;	//The retry parameter is out of range
        public const Int16 ERR_COND = -32;	//An invalid condition condition parameter was specified
        public const Int16 ERR_BADMSG = -33;	//The specified command block is not a message block
        public const Int16 ERR_RTRT = -34;	//The command words are not a valid RT-RT message
        public const Int16 ERR_RESPONSE = -35;	//A bad response or no response was received from an RT
        public const Int16 ERR_FNAME = -40;	//Bad filenames were specified
        public const Int16 ERR_FRDWR = -41;	//There was an error reading or writing the HEX file
        public const Int16 ERR_HEX = -42;	//There was a bad hex character in the HEX file
        public const Int16 ERR_CRC = -43;	//There was a bad checksum in the HEX file
        public const Int16 ERR_TYPE = -44;	//There was a bad type value in the HEX file
        public const Int16 ERR_CISRANGE = -90;	//The specified address is outside of the CS address range
        public const Int16 ERR_CISNONE = -91;	//The CIS is not visible
        public const Int16 ERR_CISENB = -92;	//The PWE register cannot be enabled
        public const Int16 ERR_CISMAGIC = -93;	//Unable to write to the PWE register
        public const Int16 ERR_VXD = -100;	//Error returned from VXD

    }	//end class
}	//end namespace
