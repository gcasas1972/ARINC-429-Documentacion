using System;
using System.Runtime.InteropServices;

namespace BALLARD
{
    public class BTI708
    {
        /**
        *
        *  BTI708 WIN32 DRIVER  Version 1.6.2  (03/02/2010)
        *  Copyright (c) 2001-2010
        *  Ballard Technology, Inc.
        *  www.ballardtech.com
        *  support@ballardtech.com
        *  ALL RIGHTS RESERVED
        *
        *  NAME:   BTI708NET.CS -- 32-bit
        *                      BTI708 Driver Include Header File.
        *
        **/

        /**
        *
        *  Structs used by the BTI708 Driver.
        *
        **/

        [StructLayout(LayoutKind.Sequential)]
        public struct MSGFIELDS708
        {
            public UInt16 msgopt;              //Driver writes message optionvals
            public UInt16 msgact;              //Card writes message activity
            public UInt32 timetag_hitcount; //Card writes time tag - //Card writes hit count
            public UInt32 elapsetime_maxtime_mintime; //Card writes elapsed time - //Card writes max time - //Card writes min time
            public UInt32 userptr;             //Driver writes user code pointer
            public UInt16 framenum;            //Frame Number
            public UInt16 msgcount;            //Card / Driver writes message bit count (used in variable bit length mode)
            public UInt32 timetagh;            //Card writes extended timetag
            public UInt16 extflag;             //Driver writes external flags
            public UInt16 rsvd5;               //Reserved
            public UInt16 rsvd6;               //Reserved
            public UInt16 rsvd7;               //Reserved
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
            public UInt16[] data;	//Card / User writes message data
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public UInt16[] extra;	//Card / User writes extra data (used in variable bit length mode)
        }

        /**
        *
        *  BTI708 Driver functions.
        *
        **/

        /**
        *
        *  Internal functions used by the BTI708 Driver.
        *
        **/

        private static class BTI708_32
        {
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChClear@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChGetCount@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChGetInfo@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI708_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChIs708@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChIs708(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChIsRcv@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChIsRcv(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChIsXmt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChIsXmt(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChPause@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_ChPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChPauseCheck@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChPauseCheck(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChResume@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_ChResume(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChStart@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChStart(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChStop@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChStop(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChSyncDefine@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChTriggerDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetAngle@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetAngle(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetAngleFl@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Single BTI708_FieldGetAngleFl(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetControlAccept@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetControlAccept(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetData@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetData(Int32 binnum, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetDataAccept@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetDataAccept(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetFaults@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetFaults(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetGain@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_FieldGetGain(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetLabel@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetLabel(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetMode@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetMode(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetRange@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_FieldGetRange(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetTilt@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetTilt(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldGetTiltFl@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Single BTI708_FieldGetTiltFl(ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutAngle@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutAngle(UInt16 value, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutAngleFl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Single BTI708_FieldPutAngleFl(Single angle, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutControlAccept@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutControlAccept(UInt16 value, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutData@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutData(UInt16 value, Int32 binnum, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutDataAccept@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutDataAccept(UInt16 value, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutFaults@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutFaults(UInt16 value, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutGain@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_FieldPutGain(Int32 gain, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutLabel@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutLabel(UInt16 value, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutMode@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutMode(UInt16 value, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutRange@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_FieldPutRange(Int32 range, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutTilt@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutTilt(UInt16 value, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_FieldPutTiltFl@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Single BTI708_FieldPutTiltFl(Single tilt, ref UInt16 buf);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgBlockRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgBlockRd(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgBlockWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgBlockWr(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgDataRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgDataRd(ref UInt16 buf, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgDataWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgDataWr(ref UInt16 buf, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgIsAccessed@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgIsAccessed(Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgSyncDefine@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgTriggerDefine@28", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgVarDataRd@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgVarDataRd(ref UInt16 buf, ref Int32 bitcount, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgVarDataWr@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgVarDataWr(ref UInt16 buf, Int32 bitcount, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ParamAmplitudeConfig@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_RcvBuild@20", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_RcvBuild(UInt32 configval, Int32 logfreq, Int32 framecount, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_XmtBuild@24", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_XmtBuild(UInt32 configval, UInt16 framefreq, Int32 logfreq, Int32 framecount, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChConfigEx@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChDataCountRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_ChDataCountRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ChDataCountWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_ChDataCountWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_DllUsageCount@0", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_DllUsageCount();
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_GetChanCount@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_HostComm@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_HostComm(IntPtr lpparam, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_IsChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_IsChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_IsRcvChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_IsRcvChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_IsXmtChan@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_IsXmtChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgActivityRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_MsgActivityRd(Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgActivityWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_MsgActivityWr(UInt16 value, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgAddr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI708_MsgAddr(Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgCommRd@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgCommRd(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgCommWr@16", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgCommWr(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgConfig@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgConfig(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgCreate@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI708_MsgCreate(UInt32 configval, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgOptRd@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgOptWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_MsgReset(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgTableCreate@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI708_MsgTableCreate(Int32 count, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgTableRd@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI708_MsgTableRd(Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgTableReset@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_MsgTableReset(Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgTableWipe@8", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_MsgTableWipe(UInt32 basevaladdr, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_MsgTableWr@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgTableWr(UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_ParamAmplitudeGet@12", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI708.DLL", EntryPoint = "_BTI708_TestProtocol@4", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_TestProtocol(UInt32 handleval);
        }

        private static class BTI708_64
        {
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChClear", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChClear(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChGetCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChGetInfo", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI708_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChIs708", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChIs708(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChIsRcv", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChIsRcv(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChIsXmt", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChIsXmt(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChPause", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_ChPause(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChPauseCheck", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChPauseCheck(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChResume", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_ChResume(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChStart", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChStart(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChStop", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChStop(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChSyncDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChTriggerDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetAngle", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetAngle(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetAngleFl", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Single BTI708_FieldGetAngleFl(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetControlAccept", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetControlAccept(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetData", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetData(Int32 binnum, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetDataAccept", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetDataAccept(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetFaults", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetFaults(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetGain", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_FieldGetGain(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetLabel", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetLabel(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetMode", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetMode(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetRange", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_FieldGetRange(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetTilt", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldGetTilt(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldGetTiltFl", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Single BTI708_FieldGetTiltFl(ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutAngle", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutAngle(UInt16 value, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutAngleFl", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Single BTI708_FieldPutAngleFl(Single angle, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutControlAccept", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutControlAccept(UInt16 value, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutData", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutData(UInt16 value, Int32 binnum, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutDataAccept", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutDataAccept(UInt16 value, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutFaults", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutFaults(UInt16 value, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutGain", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_FieldPutGain(Int32 gain, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutLabel", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutLabel(UInt16 value, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutMode", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutMode(UInt16 value, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutRange", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_FieldPutRange(Int32 range, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutTilt", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_FieldPutTilt(UInt16 value, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_FieldPutTiltFl", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Single BTI708_FieldPutTiltFl(Single tilt, ref UInt16 buf);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgBlockRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgBlockRd(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgBlockWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgBlockWr(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgDataRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgDataRd(ref UInt16 buf, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgDataWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgDataWr(ref UInt16 buf, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgIsAccessed", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgIsAccessed(Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgSyncDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgTriggerDefine", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgVarDataRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgVarDataRd(ref UInt16 buf, ref Int32 bitcount, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgVarDataWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgVarDataWr(ref UInt16 buf, Int32 bitcount, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ParamAmplitudeConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_RcvBuild", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_RcvBuild(UInt32 configval, Int32 logfreq, Int32 framecount, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_XmtBuild", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_XmtBuild(UInt32 configval, UInt16 framefreq, Int32 logfreq, Int32 framecount, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChConfigEx", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ChConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChDataCountRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_ChDataCountRd(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ChDataCountWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_ChDataCountWr(UInt16 countval, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_DllUsageCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_DllUsageCount();
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_GetChanCount", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_HostComm", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_HostComm(IntPtr lpparam, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_IsChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_IsChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_IsRcvChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_IsRcvChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_IsXmtChan", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_IsXmtChan(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgActivityRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_MsgActivityRd(Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgActivityWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_MsgActivityWr(UInt16 value, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgAddr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI708_MsgAddr(Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgCommRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgCommRd(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgCommWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgCommWr(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgConfig", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgConfig(UInt32 configval, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI708_MsgCreate(UInt32 configval, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgOptRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt16 BTI708_MsgOptRd(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgOptWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_MsgReset(UInt32 msgaddr, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgTableCreate", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI708_MsgTableCreate(Int32 count, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgTableRd", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern UInt32 BTI708_MsgTableRd(Int32 msgindex, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgTableReset", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_MsgTableReset(Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgTableWipe", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern void BTI708_MsgTableWipe(UInt32 basevaladdr, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_MsgTableWr", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_MsgTableWr(UInt32 msgaddr, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_ParamAmplitudeGet", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval);
            [DllImport("BTI70864.DLL", EntryPoint = "BTI708_TestProtocol", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern Int32 BTI708_TestProtocol(UInt32 handleval);
        }

        public static Int32 BTI708_ChClear(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChClear(channum, handleval);
            else
                return BTI708_64.BTI708_ChClear(channum, handleval);
        }
        public static Int32 BTI708_ChConfig(UInt32 configval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChConfig(configval, channum, handleval);
            else
                return BTI708_64.BTI708_ChConfig(configval, channum, handleval);
        }
        public static void BTI708_ChGetCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI708_32.BTI708_ChGetCount(ref rcvcount, ref xmtcount, handleval);
            else
                BTI708_64.BTI708_ChGetCount(ref rcvcount, ref xmtcount, handleval);
        }
        public static UInt32 BTI708_ChGetInfo(UInt16 infotype, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChGetInfo(infotype, channum, handleval);
            else
                return BTI708_64.BTI708_ChGetInfo(infotype, channum, handleval);
        }
        public static Int32 BTI708_ChIs708(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChIs708(channum, handleval);
            else
                return BTI708_64.BTI708_ChIs708(channum, handleval);
        }
        public static Int32 BTI708_ChIsRcv(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChIsRcv(channum, handleval);
            else
                return BTI708_64.BTI708_ChIsRcv(channum, handleval);
        }
        public static Int32 BTI708_ChIsXmt(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChIsXmt(channum, handleval);
            else
                return BTI708_64.BTI708_ChIsXmt(channum, handleval);
        }
        public static void BTI708_ChPause(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI708_32.BTI708_ChPause(channum, handleval);
            else
                BTI708_64.BTI708_ChPause(channum, handleval);
        }
        public static Int32 BTI708_ChPauseCheck(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChPauseCheck(channum, handleval);
            else
                return BTI708_64.BTI708_ChPauseCheck(channum, handleval);
        }
        public static void BTI708_ChResume(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI708_32.BTI708_ChResume(channum, handleval);
            else
                BTI708_64.BTI708_ChResume(channum, handleval);
        }
        public static Int32 BTI708_ChStart(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChStart(channum, handleval);
            else
                return BTI708_64.BTI708_ChStart(channum, handleval);
        }
        public static Int32 BTI708_ChStop(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChStop(channum, handleval);
            else
                return BTI708_64.BTI708_ChStop(channum, handleval);
        }
        public static Int32 BTI708_ChSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval);
            else
                return BTI708_64.BTI708_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval);
        }
        public static Int32 BTI708_ChTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
            else
                return BTI708_64.BTI708_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval);
        }
        public static UInt16 BTI708_FieldGetAngle(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetAngle(ref buf);
            else
                return BTI708_64.BTI708_FieldGetAngle(ref buf);
        }
        public static Single BTI708_FieldGetAngleFl(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetAngleFl(ref buf);
            else
                return BTI708_64.BTI708_FieldGetAngleFl(ref buf);
        }
        public static UInt16 BTI708_FieldGetControlAccept(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetControlAccept(ref buf);
            else
                return BTI708_64.BTI708_FieldGetControlAccept(ref buf);
        }
        public static UInt16 BTI708_FieldGetData(Int32 binnum, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetData(binnum, ref buf);
            else
                return BTI708_64.BTI708_FieldGetData(binnum, ref buf);
        }
        public static UInt16 BTI708_FieldGetDataAccept(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetDataAccept(ref buf);
            else
                return BTI708_64.BTI708_FieldGetDataAccept(ref buf);
        }
        public static UInt16 BTI708_FieldGetFaults(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetFaults(ref buf);
            else
                return BTI708_64.BTI708_FieldGetFaults(ref buf);
        }
        public static Int32 BTI708_FieldGetGain(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetGain(ref buf);
            else
                return BTI708_64.BTI708_FieldGetGain(ref buf);
        }
        public static UInt16 BTI708_FieldGetLabel(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetLabel(ref buf);
            else
                return BTI708_64.BTI708_FieldGetLabel(ref buf);
        }
        public static UInt16 BTI708_FieldGetMode(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetMode(ref buf);
            else
                return BTI708_64.BTI708_FieldGetMode(ref buf);
        }
        public static Int32 BTI708_FieldGetRange(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetRange(ref buf);
            else
                return BTI708_64.BTI708_FieldGetRange(ref buf);
        }
        public static UInt16 BTI708_FieldGetTilt(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetTilt(ref buf);
            else
                return BTI708_64.BTI708_FieldGetTilt(ref buf);
        }
        public static Single BTI708_FieldGetTiltFl(ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldGetTiltFl(ref buf);
            else
                return BTI708_64.BTI708_FieldGetTiltFl(ref buf);
        }
        public static UInt16 BTI708_FieldPutAngle(UInt16 value, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutAngle(value, ref buf);
            else
                return BTI708_64.BTI708_FieldPutAngle(value, ref buf);
        }
        public static Single BTI708_FieldPutAngleFl(Single angle, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutAngleFl(angle, ref buf);
            else
                return BTI708_64.BTI708_FieldPutAngleFl(angle, ref buf);
        }
        public static UInt16 BTI708_FieldPutControlAccept(UInt16 value, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutControlAccept(value, ref buf);
            else
                return BTI708_64.BTI708_FieldPutControlAccept(value, ref buf);
        }
        public static UInt16 BTI708_FieldPutData(UInt16 value, Int32 binnum, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutData(value, binnum, ref buf);
            else
                return BTI708_64.BTI708_FieldPutData(value, binnum, ref buf);
        }
        public static UInt16 BTI708_FieldPutDataAccept(UInt16 value, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutDataAccept(value, ref buf);
            else
                return BTI708_64.BTI708_FieldPutDataAccept(value, ref buf);
        }
        public static UInt16 BTI708_FieldPutFaults(UInt16 value, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutFaults(value, ref buf);
            else
                return BTI708_64.BTI708_FieldPutFaults(value, ref buf);
        }
        public static Int32 BTI708_FieldPutGain(Int32 gain, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutGain(gain, ref buf);
            else
                return BTI708_64.BTI708_FieldPutGain(gain, ref buf);
        }
        public static UInt16 BTI708_FieldPutLabel(UInt16 value, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutLabel(value, ref buf);
            else
                return BTI708_64.BTI708_FieldPutLabel(value, ref buf);
        }
        public static UInt16 BTI708_FieldPutMode(UInt16 value, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutMode(value, ref buf);
            else
                return BTI708_64.BTI708_FieldPutMode(value, ref buf);
        }
        public static Int32 BTI708_FieldPutRange(Int32 range, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutRange(range, ref buf);
            else
                return BTI708_64.BTI708_FieldPutRange(range, ref buf);
        }
        public static UInt16 BTI708_FieldPutTilt(UInt16 value, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutTilt(value, ref buf);
            else
                return BTI708_64.BTI708_FieldPutTilt(value, ref buf);
        }
        public static Single BTI708_FieldPutTiltFl(Single tilt, ref UInt16 buf)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_FieldPutTiltFl(tilt, ref buf);
            else
                return BTI708_64.BTI708_FieldPutTiltFl(tilt, ref buf);
        }
        public static Int32 BTI708_MsgBlockRd(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgBlockRd(ref msgfields, msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgBlockRd(ref msgfields, msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgBlockWr(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgBlockWr(ref msgfields, msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgBlockWr(ref msgfields, msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgDataRd(ref UInt16 buf, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgDataRd(ref buf, msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgDataRd(ref buf, msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgDataWr(ref UInt16 buf, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgDataWr(ref buf, msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgDataWr(ref buf, msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgIsAccessed(Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgIsAccessed(msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgIsAccessed(msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgSyncDefine(Int32 enableflag, UInt16 syncmask, UInt16 pinpolarity, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgTriggerDefine(Int32 enableflag, UInt16 trigmask, UInt16 trigval, UInt16 pinpolarity, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgVarDataRd(ref UInt16 buf, ref Int32 bitcount, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgVarDataRd(ref buf, ref bitcount, msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgVarDataRd(ref buf, ref bitcount, msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgVarDataWr(ref UInt16 buf, Int32 bitcount, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgVarDataWr(ref buf, bitcount, msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgVarDataWr(ref buf, bitcount, msgindex, channum, handleval);
        }
        public static Int32 BTI708_ParamAmplitudeConfig(UInt32 configval, UInt16 dacval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ParamAmplitudeConfig(configval, dacval, channum, handleval);
            else
                return BTI708_64.BTI708_ParamAmplitudeConfig(configval, dacval, channum, handleval);
        }
        public static Int32 BTI708_RcvBuild(UInt32 configval, Int32 logfreq, Int32 framecount, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_RcvBuild(configval, logfreq, framecount, channum, handleval);
            else
                return BTI708_64.BTI708_RcvBuild(configval, logfreq, framecount, channum, handleval);
        }
        public static Int32 BTI708_XmtBuild(UInt32 configval, UInt16 framefreq, Int32 logfreq, Int32 framecount, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_XmtBuild(configval, framefreq, logfreq, framecount, channum, handleval);
            else
                return BTI708_64.BTI708_XmtBuild(configval, framefreq, logfreq, framecount, channum, handleval);
        }
        public static Int32 BTI708_ChConfigEx(UInt32 configval, UInt16 count, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChConfigEx(configval, count, channum, handleval);
            else
                return BTI708_64.BTI708_ChConfigEx(configval, count, channum, handleval);
        }
        public static UInt16 BTI708_ChDataCountRd(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChDataCountRd(channum, handleval);
            else
                return BTI708_64.BTI708_ChDataCountRd(channum, handleval);
        }
        public static UInt16 BTI708_ChDataCountWr(UInt16 countval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ChDataCountWr(countval, channum, handleval);
            else
                return BTI708_64.BTI708_ChDataCountWr(countval, channum, handleval);
        }
        public static Int32 BTI708_DllUsageCount()
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_DllUsageCount();
            else
                return BTI708_64.BTI708_DllUsageCount();
        }
        public static void BTI708_GetChanCount(ref Int32 rcvcount, ref Int32 xmtcount, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI708_32.BTI708_GetChanCount(ref rcvcount, ref xmtcount, handleval);
            else
                BTI708_64.BTI708_GetChanCount(ref rcvcount, ref xmtcount, handleval);
        }
        public static Int32 BTI708_HostComm(IntPtr lpparam, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_HostComm(lpparam, handleval);
            else
                return BTI708_64.BTI708_HostComm(lpparam, handleval);
        }
        public static Int32 BTI708_IsChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_IsChan(channum, handleval);
            else
                return BTI708_64.BTI708_IsChan(channum, handleval);
        }
        public static Int32 BTI708_IsRcvChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_IsRcvChan(channum, handleval);
            else
                return BTI708_64.BTI708_IsRcvChan(channum, handleval);
        }
        public static Int32 BTI708_IsXmtChan(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_IsXmtChan(channum, handleval);
            else
                return BTI708_64.BTI708_IsXmtChan(channum, handleval);
        }
        public static UInt16 BTI708_MsgActivityRd(Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgActivityRd(msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgActivityRd(msgindex, channum, handleval);
        }
        public static void BTI708_MsgActivityWr(UInt16 value, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI708_32.BTI708_MsgActivityWr(value, msgindex, channum, handleval);
            else
                BTI708_64.BTI708_MsgActivityWr(value, msgindex, channum, handleval);
        }
        public static UInt32 BTI708_MsgAddr(Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgAddr(msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgAddr(msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgCommRd(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgCommRd(ref msgfields, msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgCommRd(ref msgfields, msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgCommWr(ref MSGFIELDS708 msgfields, Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgCommWr(ref msgfields, msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgCommWr(ref msgfields, msgindex, channum, handleval);
        }
        public static Int32 BTI708_MsgConfig(UInt32 configval, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgConfig(configval, msgaddr, handleval);
            else
                return BTI708_64.BTI708_MsgConfig(configval, msgaddr, handleval);
        }
        public static UInt32 BTI708_MsgCreate(UInt32 configval, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgCreate(configval, handleval);
            else
                return BTI708_64.BTI708_MsgCreate(configval, handleval);
        }
        public static UInt16 BTI708_MsgOptRd(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgOptRd(msgaddr, handleval);
            else
                return BTI708_64.BTI708_MsgOptRd(msgaddr, handleval);
        }
        public static void BTI708_MsgOptWr(UInt16 msgopt, UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI708_32.BTI708_MsgOptWr(msgopt, msgaddr, handleval);
            else
                BTI708_64.BTI708_MsgOptWr(msgopt, msgaddr, handleval);
        }
        public static void BTI708_MsgReset(UInt32 msgaddr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI708_32.BTI708_MsgReset(msgaddr, handleval);
            else
                BTI708_64.BTI708_MsgReset(msgaddr, handleval);
        }
        public static UInt32 BTI708_MsgTableCreate(Int32 count, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgTableCreate(count, handleval);
            else
                return BTI708_64.BTI708_MsgTableCreate(count, handleval);
        }
        public static UInt32 BTI708_MsgTableRd(Int32 msgindex, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgTableRd(msgindex, channum, handleval);
            else
                return BTI708_64.BTI708_MsgTableRd(msgindex, channum, handleval);
        }
        public static void BTI708_MsgTableReset(Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI708_32.BTI708_MsgTableReset(channum, handleval);
            else
                BTI708_64.BTI708_MsgTableReset(channum, handleval);
        }
        public static void BTI708_MsgTableWipe(UInt32 basevaladdr, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                BTI708_32.BTI708_MsgTableWipe(basevaladdr, handleval);
            else
                BTI708_64.BTI708_MsgTableWipe(basevaladdr, handleval);
        }
        public static Int32 BTI708_MsgTableWr(UInt32 msgaddr, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_MsgTableWr(msgaddr, channum, handleval);
            else
                return BTI708_64.BTI708_MsgTableWr(msgaddr, channum, handleval);
        }
        public static Int32 BTI708_ParamAmplitudeGet(ref UInt16 dacval, Int32 channum, UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_ParamAmplitudeGet(ref dacval, channum, handleval);
            else
                return BTI708_64.BTI708_ParamAmplitudeGet(ref dacval, channum, handleval);
        }
        public static Int32 BTI708_TestProtocol(UInt32 handleval)
        {
            if (IntPtr.Size == 4)
                return BTI708_32.BTI708_TestProtocol(handleval);
            else
                return BTI708_64.BTI708_TestProtocol(handleval);
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
        *  Channel configuration options
        *
        **/

        public const UInt32 CHCFG708_DEFAULT = 0x00000000;	//Select all default settings (XMT & RCV) (default)
        public const UInt32 CHCFG708_NOSWAP = 0x00000000;	//Select 708 bit order (XMT & RCV) (default)
        public const UInt32 CHCFG708_SWAP = 0x00000001;	//Select 1553 bit order (XMT & RCV)
        public const UInt32 CHCFG708_WORDSYNC = 0x00000000;	//Select resync on words (RCV) (default)
        public const UInt32 CHCFG708_BITSYNC = 0x00000002;	//Select resync on every bit (RCV)
        public const UInt32 CHCFG708_SELFTEST = 0x00000004;	//Enable internal wraparound (XMT & RCV)
        public const UInt32 CHCFG708_SELFTESTOFF = 0x00000000;	//Disable internal wraparound (XMT & RCV) (default)
        public const UInt32 CHCFG708_SYNCSEL = 0x00000000;	//Sync output controlled at message level (XMT) (default)
        public const UInt32 CHCFG708_SYNCALL = 0x00000008;	//Sync output for all messages (XMT & RCV)
        public const UInt32 CHCFG708_ERRSYNCOFF = 0x00000000;	//Disable pulsing of DOUT for errors (RCV) (default)
        public const UInt32 CHCFG708_ERRSYNCON = 0x00000010;	//Enable pulsing of DOUT for errors (RCV)
        public const UInt32 CHCFG708_EXTTRIG = 0x00000020;	//Enable external trigger for all messages (XMT)
        public const UInt32 CHCFG708_EXTOFF = 0x00000000;	//External trigger is enabled on message level (XMT) (default)
        public const UInt32 CHCFG708_TRIGNONE = 0x00000000;	//No trigger (XMT) (default)
        public const UInt32 CHCFG708_TRIGEXT = 0x00000040;	//Trigger external (XMT)
        public const UInt32 CHCFG708_TRIGSTART = 0x00000080;	//Trigger external start (XMT)
        public const UInt32 CHCFG708_ACTIVE = 0x00000000;	//Enable channel (XMT & RCV) (default)
        public const UInt32 CHCFG708_INACTIVE = 0x00000100;	//Disable channel (XMT & RCV)
        public const UInt32 CHCFG708_HIT = 0x00000200;	//Hit counter is enabled for all messages (XMT & RCV)
        public const UInt32 CHCFG708_NOHIT = 0x00000000;	//Hit counter is enabled on message level (XMT & RCV) (default)
        public const UInt32 CHCFG708_TIMETAG = 0x00000400;	//Enable time-tag for all message records (XMT & RCV)
        public const UInt32 CHCFG708_TIMETAGOFF = 0x00000000;	//Time-tag is enabled on message level (XMT & RCV) (default)
        public const UInt32 CHCFG708_ELAPSE = 0x00000800;	//Enable elapse time for all messages (XMT & RCV)
        public const UInt32 CHCFG708_ELAPSEOFF = 0x00000000;	//Elapse time is enabled on message level (XMT & RCV) (default)
        public const UInt32 CHCFG708_MAX = 0x00001000;	//Enable max repetition rate monitoring for all messages (XMT & RCV)
        public const UInt32 CHCFG708_MAXOFF = 0x00000000;	//Repetition rate monitoring is enabled on message level (XMT & RCV) (default)
        public const UInt32 CHCFG708_MIN = 0x00002000;	//Enable min repetition rate monitoring for all messages (XMT & RCV)
        public const UInt32 CHCFG708_MINOFF = 0x00000000;	//Repetition rate monitoring is enabled on message level (XMT & RCV) (default)
        public const UInt32 CHCFG708_SEQALL = 0x00080000;	//Record entire channel in sequential record (XMT & RCV)
        public const UInt32 CHCFG708_SEQSEL = 0x00000000;	//Sequential record recording is enabled at message level (XMT & RCV) (default)
        public const UInt32 CHCFG708_PAUSE = 0x01000000;	//Mark channel as paused (XMT & RCV)
        public const UInt32 CHCFG708_UNPAUSE = 0x00000000;	//Mark channel as unpaused (XMT & RCV) (default)
        public const UInt32 CHCFG708_RCVBUSA = 0x00000000;	//Receive channel will operate on Bus A (RCV) (default)
        public const UInt32 CHCFG708_RCVBUSB = 0x00004000;	//Receive channel will operate on Bus B (RCV)
        public const UInt32 CHCFG708_XMTBUSA = 0x00004000;	//Transmit channel will operate on Bus A (XMT)
        public const UInt32 CHCFG708_XMTBUSB = 0x00000000;	//Transmit channel will operate on Bus B (XMT) (default)
        public const UInt32 CHCFG708_TERMOFF = 0x00000000;	//Direct coupled termination resistance off (XMT & RCV) (default)
        public const UInt32 CHCFG708_TERMON = 0x00008000;	//Direct coupled termination resistance on (XMT & RCV)
        public const UInt32 CHCFG708_FIXBIT = 0x00000000;	//Channel operates with fixed bit length (XMT & RCV) (default)
        public const UInt32 CHCFG708_VARBIT = 0x00010000;	//Channel operates with variable bit length (XMT & RCV)
        public const UInt32 CHCFG708_PRESYNCOFF = 0x00000000;	//Pre-sync pulses off (XMT) (default)
        public const UInt32 CHCFG708_PRESYNCON = 0x00020000;	//Pre-sync pulses on (XMT)

        /**
        *
        *  Message configuration options
        *
        **/

        public const UInt32 MSGCRT708_DEFAULT = 0x00000000;	//Default settings
        public const UInt32 MSGCRT708_NOSEQ = 0x00000000;	//Message will not be recorded in sequential record (default)
        public const UInt32 MSGCRT708_SEQ = 0x00000001;	//Message will be recorded in sequential record
        public const UInt32 MSGCRT708_NOLOG = 0x00000000;	//Message will not generate event log (default)
        public const UInt32 MSGCRT708_LOG = 0x00000002;	//Message will generate event log
        public const UInt32 MSGCRT708_NOSKIP = 0x00000000;	//Message will not be skipped (default)
        public const UInt32 MSGCRT708_SKIP = 0x00000008;	//Message will be skipped
        public const UInt32 MSGCRT708_NOTIMETAG = 0x00000000;	//Message will not record time-tag (default)
        public const UInt32 MSGCRT708_TIMETAG = 0x00000010;	//Message will record time-tag
        public const UInt32 MSGCRT708_NOELAPSE = 0x00000000;	//Message will not record elapse time (default)
        public const UInt32 MSGCRT708_ELAPSE = 0x00000020;	//Message will record elapse time
        public const UInt32 MSGCRT708_NOMAX = 0x00000000;	//Message will not record max time (default)
        public const UInt32 MSGCRT708_MAX = 0x00000040;	//Message will record max time
        public const UInt32 MSGCRT708_NOMIN = 0x00000000;	//Message will not record min time (default)
        public const UInt32 MSGCRT708_MIN = 0x00000080;	//Message will record min time
        public const UInt32 MSGCRT708_MAXMIN = 0x000000C0;	//Message will record min/max time
        public const UInt32 MSGCRT708_NOSYNC = 0x00000000;	//Message will not generate a syncout pulse (default)
        public const UInt32 MSGCRT708_SYNC = 0x00000100;	//Message will generate a syncout pulse
        public const UInt32 MSGCRT708_NOHIT = 0x00000000;	//Message will not record hit count (default)
        public const UInt32 MSGCRT708_HIT = 0x00000400;	//Message will record hit count
        public const UInt32 MSGCRT708_NOEXTRIG = 0x00000000;	//Message will not be externally triggered (default)
        public const UInt32 MSGCRT708_EXTRIG = 0x00001000;	//Message will be externally triggered

        /**
        *
        *  Parametric configuration options
        *
        **/

        public const UInt32 PARAMCFG708_DEFAULT = 0x00000000;	//Select all default settings (default)
        public const UInt32 PARAMCFG708_AMPLON = 0x00000000;	//Enables parametric amplitude control (default)
        public const UInt32 PARAMCFG708_AMPLOFF = 0x00000001;	//Disables parametric amplitude control

        /**
        *
        *  Bit fields of the message activity flag.
        *
        **/

        public const UInt32 MSGACT708_CHMASK = 0xFF00;	//Channel number mask value
        public const UInt32 MSGACT708_CHSHIFT = 0x0008;	//Channel number shift value
        public const UInt32 MSGACT708_ERR = 0x0080;	//Error bit
        public const UInt32 MSGACT708_SHORT = 0x0040;	//Short word error bit
        public const UInt32 MSGACT708_LONG = 0x0020;	//Long word error bit
        public const UInt32 MSGACT708_MANCH = 0x0010;	//Manchester error bit
        public const UInt32 MSGACT708_DSYNC = 0x0008;	//Data sync error bit
        public const UInt32 MSGACT708_WORD = 0x0004;	//Word error bit
        public const UInt32 MSGACT708_TO = 0x0002;	//Time out error bit
        public const UInt32 MSGACT708_HIT = 0x0001;	//Always set

        /**
        *
        *  Channel info fields.
        *
        **/

        public const UInt32 INFO708_PARAM = 0x0001;	//Channel supports parametric control
        public const UInt32 INFO708_VARBIT = 0x0002;	//Channel supports variable bit length mode

    }	//end class
}	//end namespace
