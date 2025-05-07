Imports System
Imports System.Runtime.InteropServices

Module BTI708VB

    '/**
    '*
    '*  BTI708 WIN32 DRIVER  Version 1.6.2  (03/02/2010)
    '*  Copyright (c) 2001-2010
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   BTI708NET.VB -- 32-bit
    '*                      BTI708 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  Structs used by the BTI708 Driver.
    '*
    '**/

    <StructLayout(LayoutKind.Sequential)> Public Structure MSGFIELDS708
        Public msgopt As UInt16 '//Driver writes message optionvals
        Public msgact As UInt16 '//Card writes message activity
        Public timetag_hitcount As UInt32   '//Card writes time tag - '//Card writes hit count
        Public elapsetime_maxtime_mintime As UInt32 '//Card writes elapsed time - '//Card writes max time - '//Card writes min time
        Public userptr As UInt32    '//Driver writes user code pointer
        Public framenum As UInt16   '//Frame Number
        Public msgcount As UInt16   '//Card / Driver writes message bit count (used in variable bit length mode)
        Public timetagh As UInt32   '//Card writes extended timetag
        Public extflag As UInt16    '//Driver writes external flags
        Public rsvd5 As UInt16  '//Reserved
        Public rsvd6 As UInt16  '//Reserved
        Public rsvd7 As UInt16  '//Reserved
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=100)> Public data() As UInt16   '//Card / User writes message data
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)> Public extra() As UInt16   '//Card / User writes extra data (used in variable bit length mode)
    End Structure

    '/**
    '*
    '*  BTI708 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the BTI708 Driver.
    '*
    '**/

    Private Class BTI708_32
        Public Declare Function BTI708_ChClear Lib "BTI708.DLL" Alias "_BTI708_ChClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChConfig Lib "BTI708.DLL" Alias "_BTI708_ChConfig@12" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI708_ChGetCount Lib "BTI708.DLL" Alias "_BTI708_ChGetCount@12" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI708_ChGetInfo Lib "BTI708.DLL" Alias "_BTI708_ChGetInfo@12" (ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI708_ChIs708 Lib "BTI708.DLL" Alias "_BTI708_ChIs708@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChIsRcv Lib "BTI708.DLL" Alias "_BTI708_ChIsRcv@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChIsXmt Lib "BTI708.DLL" Alias "_BTI708_ChIsXmt@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI708_ChPause Lib "BTI708.DLL" Alias "_BTI708_ChPause@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI708_ChPauseCheck Lib "BTI708.DLL" Alias "_BTI708_ChPauseCheck@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI708_ChResume Lib "BTI708.DLL" Alias "_BTI708_ChResume@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI708_ChStart Lib "BTI708.DLL" Alias "_BTI708_ChStart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChStop Lib "BTI708.DLL" Alias "_BTI708_ChStop@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChSyncDefine Lib "BTI708.DLL" Alias "_BTI708_ChSyncDefine@20" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChTriggerDefine Lib "BTI708.DLL" Alias "_BTI708_ChTriggerDefine@24" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_FieldGetAngle Lib "BTI708.DLL" Alias "_BTI708_FieldGetAngle@4" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetAngleFl Lib "BTI708.DLL" Alias "_BTI708_FieldGetAngleFl@4" (ByRef buf As UInt16) As Single
        Public Declare Function BTI708_FieldGetControlAccept Lib "BTI708.DLL" Alias "_BTI708_FieldGetControlAccept@4" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetData Lib "BTI708.DLL" Alias "_BTI708_FieldGetData@8" (ByVal binnum As Int32, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetDataAccept Lib "BTI708.DLL" Alias "_BTI708_FieldGetDataAccept@4" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetFaults Lib "BTI708.DLL" Alias "_BTI708_FieldGetFaults@4" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetGain Lib "BTI708.DLL" Alias "_BTI708_FieldGetGain@4" (ByRef buf As UInt16) As Int32
        Public Declare Function BTI708_FieldGetLabel Lib "BTI708.DLL" Alias "_BTI708_FieldGetLabel@4" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetMode Lib "BTI708.DLL" Alias "_BTI708_FieldGetMode@4" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetRange Lib "BTI708.DLL" Alias "_BTI708_FieldGetRange@4" (ByRef buf As UInt16) As Int32
        Public Declare Function BTI708_FieldGetTilt Lib "BTI708.DLL" Alias "_BTI708_FieldGetTilt@4" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetTiltFl Lib "BTI708.DLL" Alias "_BTI708_FieldGetTiltFl@4" (ByRef buf As UInt16) As Single
        Public Declare Function BTI708_FieldPutAngle Lib "BTI708.DLL" Alias "_BTI708_FieldPutAngle@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutAngleFl Lib "BTI708.DLL" Alias "_BTI708_FieldPutAngleFl@8" (ByVal angle As Single, ByRef buf As UInt16) As Single
        Public Declare Function BTI708_FieldPutControlAccept Lib "BTI708.DLL" Alias "_BTI708_FieldPutControlAccept@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutData Lib "BTI708.DLL" Alias "_BTI708_FieldPutData@12" (ByVal value As UInt16, ByVal binnum As Int32, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutDataAccept Lib "BTI708.DLL" Alias "_BTI708_FieldPutDataAccept@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutFaults Lib "BTI708.DLL" Alias "_BTI708_FieldPutFaults@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutGain Lib "BTI708.DLL" Alias "_BTI708_FieldPutGain@8" (ByVal gain As Int32, ByRef buf As UInt16) As Int32
        Public Declare Function BTI708_FieldPutLabel Lib "BTI708.DLL" Alias "_BTI708_FieldPutLabel@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutMode Lib "BTI708.DLL" Alias "_BTI708_FieldPutMode@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutRange Lib "BTI708.DLL" Alias "_BTI708_FieldPutRange@8" (ByVal range As Int32, ByRef buf As UInt16) As Int32
        Public Declare Function BTI708_FieldPutTilt Lib "BTI708.DLL" Alias "_BTI708_FieldPutTilt@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutTiltFl Lib "BTI708.DLL" Alias "_BTI708_FieldPutTiltFl@8" (ByVal tilt As Single, ByRef buf As UInt16) As Single
        Public Declare Function BTI708_MsgBlockRd Lib "BTI708.DLL" Alias "_BTI708_MsgBlockRd@16" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgBlockWr Lib "BTI708.DLL" Alias "_BTI708_MsgBlockWr@16" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgDataRd Lib "BTI708.DLL" Alias "_BTI708_MsgDataRd@16" (ByRef buf As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgDataWr Lib "BTI708.DLL" Alias "_BTI708_MsgDataWr@16" (ByRef buf As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgIsAccessed Lib "BTI708.DLL" Alias "_BTI708_MsgIsAccessed@12" (ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgSyncDefine Lib "BTI708.DLL" Alias "_BTI708_MsgSyncDefine@24" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgTriggerDefine Lib "BTI708.DLL" Alias "_BTI708_MsgTriggerDefine@28" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgVarDataRd Lib "BTI708.DLL" Alias "_BTI708_MsgVarDataRd@20" (ByRef buf As UInt16, ByRef bitcount As Int32, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgVarDataWr Lib "BTI708.DLL" Alias "_BTI708_MsgVarDataWr@20" (ByRef buf As UInt16, ByVal bitcount As Int32, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ParamAmplitudeConfig Lib "BTI708.DLL" Alias "_BTI708_ParamAmplitudeConfig@16" (ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_RcvBuild Lib "BTI708.DLL" Alias "_BTI708_RcvBuild@20" (ByVal configval As UInt32, ByVal logfreq As Int32, ByVal framecount As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_XmtBuild Lib "BTI708.DLL" Alias "_BTI708_XmtBuild@24" (ByVal configval As UInt32, ByVal framefreq As UInt16, ByVal logfreq As Int32, ByVal framecount As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChConfigEx Lib "BTI708.DLL" Alias "_BTI708_ChConfigEx@16" (ByVal configval As UInt32, ByVal count As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChDataCountRd Lib "BTI708.DLL" Alias "_BTI708_ChDataCountRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTI708_ChDataCountWr Lib "BTI708.DLL" Alias "_BTI708_ChDataCountWr@12" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTI708_DllUsageCount Lib "BTI708.DLL" Alias "_BTI708_DllUsageCount@0" () As Int32
        Public Declare Sub BTI708_GetChanCount Lib "BTI708.DLL" Alias "_BTI708_GetChanCount@12" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI708_HostComm Lib "BTI708.DLL" Alias "_BTI708_HostComm@8" (ByVal lpparam As IntPtr, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_IsChan Lib "BTI708.DLL" Alias "_BTI708_IsChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_IsRcvChan Lib "BTI708.DLL" Alias "_BTI708_IsRcvChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_IsXmtChan Lib "BTI708.DLL" Alias "_BTI708_IsXmtChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgActivityRd Lib "BTI708.DLL" Alias "_BTI708_MsgActivityRd@12" (ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI708_MsgActivityWr Lib "BTI708.DLL" Alias "_BTI708_MsgActivityWr@16" (ByVal value As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI708_MsgAddr Lib "BTI708.DLL" Alias "_BTI708_MsgAddr@12" (ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI708_MsgCommRd Lib "BTI708.DLL" Alias "_BTI708_MsgCommRd@16" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgCommWr Lib "BTI708.DLL" Alias "_BTI708_MsgCommWr@16" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgConfig Lib "BTI708.DLL" Alias "_BTI708_MsgConfig@12" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgCreate Lib "BTI708.DLL" Alias "_BTI708_MsgCreate@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI708_MsgOptRd Lib "BTI708.DLL" Alias "_BTI708_MsgOptRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI708_MsgOptWr Lib "BTI708.DLL" Alias "_BTI708_MsgOptWr@12" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTI708_MsgReset Lib "BTI708.DLL" Alias "_BTI708_MsgReset@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI708_MsgTableCreate Lib "BTI708.DLL" Alias "_BTI708_MsgTableCreate@8" (ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI708_MsgTableRd Lib "BTI708.DLL" Alias "_BTI708_MsgTableRd@12" (ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTI708_MsgTableReset Lib "BTI708.DLL" Alias "_BTI708_MsgTableReset@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTI708_MsgTableWipe Lib "BTI708.DLL" Alias "_BTI708_MsgTableWipe@8" (ByVal basevaladdr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI708_MsgTableWr Lib "BTI708.DLL" Alias "_BTI708_MsgTableWr@12" (ByVal msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ParamAmplitudeGet Lib "BTI708.DLL" Alias "_BTI708_ParamAmplitudeGet@12" (ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_TestProtocol Lib "BTI708.DLL" Alias "_BTI708_TestProtocol@4" (ByVal handleval As UInt32) As Int32
    End Class

    Private Class BTI708_64
        Public Declare Function BTI708_ChClear Lib "BTI70864.DLL" Alias "BTI708_ChClear" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChConfig Lib "BTI70864.DLL" Alias "BTI708_ChConfig" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI708_ChGetCount Lib "BTI70864.DLL" Alias "BTI708_ChGetCount" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI708_ChGetInfo Lib "BTI70864.DLL" Alias "BTI708_ChGetInfo" (ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI708_ChIs708 Lib "BTI70864.DLL" Alias "BTI708_ChIs708" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChIsRcv Lib "BTI70864.DLL" Alias "BTI708_ChIsRcv" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChIsXmt Lib "BTI70864.DLL" Alias "BTI708_ChIsXmt" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI708_ChPause Lib "BTI70864.DLL" Alias "BTI708_ChPause" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI708_ChPauseCheck Lib "BTI70864.DLL" Alias "BTI708_ChPauseCheck" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI708_ChResume Lib "BTI70864.DLL" Alias "BTI708_ChResume" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI708_ChStart Lib "BTI70864.DLL" Alias "BTI708_ChStart" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChStop Lib "BTI70864.DLL" Alias "BTI708_ChStop" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChSyncDefine Lib "BTI70864.DLL" Alias "BTI708_ChSyncDefine" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChTriggerDefine Lib "BTI70864.DLL" Alias "BTI708_ChTriggerDefine" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_FieldGetAngle Lib "BTI70864.DLL" Alias "BTI708_FieldGetAngle" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetAngleFl Lib "BTI70864.DLL" Alias "BTI708_FieldGetAngleFl" (ByRef buf As UInt16) As Single
        Public Declare Function BTI708_FieldGetControlAccept Lib "BTI70864.DLL" Alias "BTI708_FieldGetControlAccept" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetData Lib "BTI70864.DLL" Alias "BTI708_FieldGetData" (ByVal binnum As Int32, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetDataAccept Lib "BTI70864.DLL" Alias "BTI708_FieldGetDataAccept" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetFaults Lib "BTI70864.DLL" Alias "BTI708_FieldGetFaults" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetGain Lib "BTI70864.DLL" Alias "BTI708_FieldGetGain" (ByRef buf As UInt16) As Int32
        Public Declare Function BTI708_FieldGetLabel Lib "BTI70864.DLL" Alias "BTI708_FieldGetLabel" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetMode Lib "BTI70864.DLL" Alias "BTI708_FieldGetMode" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetRange Lib "BTI70864.DLL" Alias "BTI708_FieldGetRange" (ByRef buf As UInt16) As Int32
        Public Declare Function BTI708_FieldGetTilt Lib "BTI70864.DLL" Alias "BTI708_FieldGetTilt" (ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldGetTiltFl Lib "BTI70864.DLL" Alias "BTI708_FieldGetTiltFl" (ByRef buf As UInt16) As Single
        Public Declare Function BTI708_FieldPutAngle Lib "BTI70864.DLL" Alias "BTI708_FieldPutAngle" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutAngleFl Lib "BTI70864.DLL" Alias "BTI708_FieldPutAngleFl" (ByVal angle As Single, ByRef buf As UInt16) As Single
        Public Declare Function BTI708_FieldPutControlAccept Lib "BTI70864.DLL" Alias "BTI708_FieldPutControlAccept" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutData Lib "BTI70864.DLL" Alias "BTI708_FieldPutData" (ByVal value As UInt16, ByVal binnum As Int32, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutDataAccept Lib "BTI70864.DLL" Alias "BTI708_FieldPutDataAccept" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutFaults Lib "BTI70864.DLL" Alias "BTI708_FieldPutFaults" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutGain Lib "BTI70864.DLL" Alias "BTI708_FieldPutGain" (ByVal gain As Int32, ByRef buf As UInt16) As Int32
        Public Declare Function BTI708_FieldPutLabel Lib "BTI70864.DLL" Alias "BTI708_FieldPutLabel" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutMode Lib "BTI70864.DLL" Alias "BTI708_FieldPutMode" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutRange Lib "BTI70864.DLL" Alias "BTI708_FieldPutRange" (ByVal range As Int32, ByRef buf As UInt16) As Int32
        Public Declare Function BTI708_FieldPutTilt Lib "BTI70864.DLL" Alias "BTI708_FieldPutTilt" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        Public Declare Function BTI708_FieldPutTiltFl Lib "BTI70864.DLL" Alias "BTI708_FieldPutTiltFl" (ByVal tilt As Single, ByRef buf As UInt16) As Single
        Public Declare Function BTI708_MsgBlockRd Lib "BTI70864.DLL" Alias "BTI708_MsgBlockRd" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgBlockWr Lib "BTI70864.DLL" Alias "BTI708_MsgBlockWr" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgDataRd Lib "BTI70864.DLL" Alias "BTI708_MsgDataRd" (ByRef buf As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgDataWr Lib "BTI70864.DLL" Alias "BTI708_MsgDataWr" (ByRef buf As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgIsAccessed Lib "BTI70864.DLL" Alias "BTI708_MsgIsAccessed" (ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgSyncDefine Lib "BTI70864.DLL" Alias "BTI708_MsgSyncDefine" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgTriggerDefine Lib "BTI70864.DLL" Alias "BTI708_MsgTriggerDefine" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgVarDataRd Lib "BTI70864.DLL" Alias "BTI708_MsgVarDataRd" (ByRef buf As UInt16, ByRef bitcount As Int32, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgVarDataWr Lib "BTI70864.DLL" Alias "BTI708_MsgVarDataWr" (ByRef buf As UInt16, ByVal bitcount As Int32, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ParamAmplitudeConfig Lib "BTI70864.DLL" Alias "BTI708_ParamAmplitudeConfig" (ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_RcvBuild Lib "BTI70864.DLL" Alias "BTI708_RcvBuild" (ByVal configval As UInt32, ByVal logfreq As Int32, ByVal framecount As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_XmtBuild Lib "BTI70864.DLL" Alias "BTI708_XmtBuild" (ByVal configval As UInt32, ByVal framefreq As UInt16, ByVal logfreq As Int32, ByVal framecount As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChConfigEx Lib "BTI70864.DLL" Alias "BTI708_ChConfigEx" (ByVal configval As UInt32, ByVal count As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ChDataCountRd Lib "BTI70864.DLL" Alias "BTI708_ChDataCountRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTI708_ChDataCountWr Lib "BTI70864.DLL" Alias "BTI708_ChDataCountWr" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTI708_DllUsageCount Lib "BTI70864.DLL" Alias "BTI708_DllUsageCount" () As Int32
        Public Declare Sub BTI708_GetChanCount Lib "BTI70864.DLL" Alias "BTI708_GetChanCount" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI708_HostComm Lib "BTI70864.DLL" Alias "BTI708_HostComm" (ByVal lpparam As IntPtr, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_IsChan Lib "BTI70864.DLL" Alias "BTI708_IsChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_IsRcvChan Lib "BTI70864.DLL" Alias "BTI708_IsRcvChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_IsXmtChan Lib "BTI70864.DLL" Alias "BTI708_IsXmtChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgActivityRd Lib "BTI70864.DLL" Alias "BTI708_MsgActivityRd" (ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI708_MsgActivityWr Lib "BTI70864.DLL" Alias "BTI708_MsgActivityWr" (ByVal value As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI708_MsgAddr Lib "BTI70864.DLL" Alias "BTI708_MsgAddr" (ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI708_MsgCommRd Lib "BTI70864.DLL" Alias "BTI708_MsgCommRd" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgCommWr Lib "BTI70864.DLL" Alias "BTI708_MsgCommWr" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgConfig Lib "BTI70864.DLL" Alias "BTI708_MsgConfig" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_MsgCreate Lib "BTI70864.DLL" Alias "BTI708_MsgCreate" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI708_MsgOptRd Lib "BTI70864.DLL" Alias "BTI708_MsgOptRd" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI708_MsgOptWr Lib "BTI70864.DLL" Alias "BTI708_MsgOptWr" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTI708_MsgReset Lib "BTI70864.DLL" Alias "BTI708_MsgReset" (ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI708_MsgTableCreate Lib "BTI70864.DLL" Alias "BTI708_MsgTableCreate" (ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI708_MsgTableRd Lib "BTI70864.DLL" Alias "BTI708_MsgTableRd" (ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTI708_MsgTableReset Lib "BTI70864.DLL" Alias "BTI708_MsgTableReset" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTI708_MsgTableWipe Lib "BTI70864.DLL" Alias "BTI708_MsgTableWipe" (ByVal basevaladdr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI708_MsgTableWr Lib "BTI70864.DLL" Alias "BTI708_MsgTableWr" (ByVal msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_ParamAmplitudeGet Lib "BTI70864.DLL" Alias "BTI708_ParamAmplitudeGet" (ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI708_TestProtocol Lib "BTI70864.DLL" Alias "BTI708_TestProtocol" (ByVal handleval As UInt32) As Int32
    End Class

    Public Function BTI708_ChClear(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChClear(channum, handleval)
        Else
            Return BTI708_64.BTI708_ChClear(channum, handleval)
        End If
    End Function
    Public Function BTI708_ChConfig(ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChConfig(configval, channum, handleval)
        Else
            Return BTI708_64.BTI708_ChConfig(configval, channum, handleval)
        End If
    End Function
    Public Sub BTI708_ChGetCount(ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI708_32.BTI708_ChGetCount(rcvcount, xmtcount, handleval)
        Else
            BTI708_64.BTI708_ChGetCount(rcvcount, xmtcount, handleval)
        End If
    End Sub
    Public Function BTI708_ChGetInfo(ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChGetInfo(infotype, channum, handleval)
        Else
            Return BTI708_64.BTI708_ChGetInfo(infotype, channum, handleval)
        End If
    End Function
    Public Function BTI708_ChIs708(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChIs708(channum, handleval)
        Else
            Return BTI708_64.BTI708_ChIs708(channum, handleval)
        End If
    End Function
    Public Function BTI708_ChIsRcv(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChIsRcv(channum, handleval)
        Else
            Return BTI708_64.BTI708_ChIsRcv(channum, handleval)
        End If
    End Function
    Public Function BTI708_ChIsXmt(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChIsXmt(channum, handleval)
        Else
            Return BTI708_64.BTI708_ChIsXmt(channum, handleval)
        End If
    End Function
    Public Sub BTI708_ChPause(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI708_32.BTI708_ChPause(channum, handleval)
        Else
            BTI708_64.BTI708_ChPause(channum, handleval)
        End If
    End Sub
    Public Function BTI708_ChPauseCheck(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChPauseCheck(channum, handleval)
        Else
            Return BTI708_64.BTI708_ChPauseCheck(channum, handleval)
        End If
    End Function
    Public Sub BTI708_ChResume(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI708_32.BTI708_ChResume(channum, handleval)
        Else
            BTI708_64.BTI708_ChResume(channum, handleval)
        End If
    End Sub
    Public Function BTI708_ChStart(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChStart(channum, handleval)
        Else
            Return BTI708_64.BTI708_ChStart(channum, handleval)
        End If
    End Function
    Public Function BTI708_ChStop(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChStop(channum, handleval)
        Else
            Return BTI708_64.BTI708_ChStop(channum, handleval)
        End If
    End Function
    Public Function BTI708_ChSyncDefine(ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval)
        Else
            Return BTI708_64.BTI708_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval)
        End If
    End Function
    Public Function BTI708_ChTriggerDefine(ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval)
        Else
            Return BTI708_64.BTI708_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval)
        End If
    End Function
    Public Function BTI708_FieldGetAngle(ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetAngle(buf)
        Else
            Return BTI708_64.BTI708_FieldGetAngle(buf)
        End If
    End Function
    Public Function BTI708_FieldGetAngleFl(ByRef buf As UInt16) As Single
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetAngleFl(buf)
        Else
            Return BTI708_64.BTI708_FieldGetAngleFl(buf)
        End If
    End Function
    Public Function BTI708_FieldGetControlAccept(ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetControlAccept(buf)
        Else
            Return BTI708_64.BTI708_FieldGetControlAccept(buf)
        End If
    End Function
    Public Function BTI708_FieldGetData(ByVal binnum As Int32, ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetData(binnum, buf)
        Else
            Return BTI708_64.BTI708_FieldGetData(binnum, buf)
        End If
    End Function
    Public Function BTI708_FieldGetDataAccept(ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetDataAccept(buf)
        Else
            Return BTI708_64.BTI708_FieldGetDataAccept(buf)
        End If
    End Function
    Public Function BTI708_FieldGetFaults(ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetFaults(buf)
        Else
            Return BTI708_64.BTI708_FieldGetFaults(buf)
        End If
    End Function
    Public Function BTI708_FieldGetGain(ByRef buf As UInt16) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetGain(buf)
        Else
            Return BTI708_64.BTI708_FieldGetGain(buf)
        End If
    End Function
    Public Function BTI708_FieldGetLabel(ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetLabel(buf)
        Else
            Return BTI708_64.BTI708_FieldGetLabel(buf)
        End If
    End Function
    Public Function BTI708_FieldGetMode(ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetMode(buf)
        Else
            Return BTI708_64.BTI708_FieldGetMode(buf)
        End If
    End Function
    Public Function BTI708_FieldGetRange(ByRef buf As UInt16) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetRange(buf)
        Else
            Return BTI708_64.BTI708_FieldGetRange(buf)
        End If
    End Function
    Public Function BTI708_FieldGetTilt(ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetTilt(buf)
        Else
            Return BTI708_64.BTI708_FieldGetTilt(buf)
        End If
    End Function
    Public Function BTI708_FieldGetTiltFl(ByRef buf As UInt16) As Single
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldGetTiltFl(buf)
        Else
            Return BTI708_64.BTI708_FieldGetTiltFl(buf)
        End If
    End Function
    Public Function BTI708_FieldPutAngle(ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutAngle(value, buf)
        Else
            Return BTI708_64.BTI708_FieldPutAngle(value, buf)
        End If
    End Function
    Public Function BTI708_FieldPutAngleFl(ByVal angle As Single, ByRef buf As UInt16) As Single
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutAngleFl(angle, buf)
        Else
            Return BTI708_64.BTI708_FieldPutAngleFl(angle, buf)
        End If
    End Function
    Public Function BTI708_FieldPutControlAccept(ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutControlAccept(value, buf)
        Else
            Return BTI708_64.BTI708_FieldPutControlAccept(value, buf)
        End If
    End Function
    Public Function BTI708_FieldPutData(ByVal value As UInt16, ByVal binnum As Int32, ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutData(value, binnum, buf)
        Else
            Return BTI708_64.BTI708_FieldPutData(value, binnum, buf)
        End If
    End Function
    Public Function BTI708_FieldPutDataAccept(ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutDataAccept(value, buf)
        Else
            Return BTI708_64.BTI708_FieldPutDataAccept(value, buf)
        End If
    End Function
    Public Function BTI708_FieldPutFaults(ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutFaults(value, buf)
        Else
            Return BTI708_64.BTI708_FieldPutFaults(value, buf)
        End If
    End Function
    Public Function BTI708_FieldPutGain(ByVal gain As Int32, ByRef buf As UInt16) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutGain(gain, buf)
        Else
            Return BTI708_64.BTI708_FieldPutGain(gain, buf)
        End If
    End Function
    Public Function BTI708_FieldPutLabel(ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutLabel(value, buf)
        Else
            Return BTI708_64.BTI708_FieldPutLabel(value, buf)
        End If
    End Function
    Public Function BTI708_FieldPutMode(ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutMode(value, buf)
        Else
            Return BTI708_64.BTI708_FieldPutMode(value, buf)
        End If
    End Function
    Public Function BTI708_FieldPutRange(ByVal range As Int32, ByRef buf As UInt16) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutRange(range, buf)
        Else
            Return BTI708_64.BTI708_FieldPutRange(range, buf)
        End If
    End Function
    Public Function BTI708_FieldPutTilt(ByVal value As UInt16, ByRef buf As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutTilt(value, buf)
        Else
            Return BTI708_64.BTI708_FieldPutTilt(value, buf)
        End If
    End Function
    Public Function BTI708_FieldPutTiltFl(ByVal tilt As Single, ByRef buf As UInt16) As Single
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_FieldPutTiltFl(tilt, buf)
        Else
            Return BTI708_64.BTI708_FieldPutTiltFl(tilt, buf)
        End If
    End Function
    Public Function BTI708_MsgBlockRd(ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgBlockRd(msgfields, msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgBlockRd(msgfields, msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgBlockWr(ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgBlockWr(msgfields, msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgBlockWr(msgfields, msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgDataRd(ByRef buf As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgDataRd(buf, msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgDataRd(buf, msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgDataWr(ByRef buf As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgDataWr(buf, msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgDataWr(buf, msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgIsAccessed(ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgIsAccessed(msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgIsAccessed(msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgSyncDefine(ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgTriggerDefine(ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgVarDataRd(ByRef buf As UInt16, ByRef bitcount As Int32, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgVarDataRd(buf, bitcount, msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgVarDataRd(buf, bitcount, msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgVarDataWr(ByRef buf As UInt16, ByVal bitcount As Int32, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgVarDataWr(buf, bitcount, msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgVarDataWr(buf, bitcount, msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_ParamAmplitudeConfig(ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ParamAmplitudeConfig(configval, dacval, channum, handleval)
        Else
            Return BTI708_64.BTI708_ParamAmplitudeConfig(configval, dacval, channum, handleval)
        End If
    End Function
    Public Function BTI708_RcvBuild(ByVal configval As UInt32, ByVal logfreq As Int32, ByVal framecount As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_RcvBuild(configval, logfreq, framecount, channum, handleval)
        Else
            Return BTI708_64.BTI708_RcvBuild(configval, logfreq, framecount, channum, handleval)
        End If
    End Function
    Public Function BTI708_XmtBuild(ByVal configval As UInt32, ByVal framefreq As UInt16, ByVal logfreq As Int32, ByVal framecount As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_XmtBuild(configval, framefreq, logfreq, framecount, channum, handleval)
        Else
            Return BTI708_64.BTI708_XmtBuild(configval, framefreq, logfreq, framecount, channum, handleval)
        End If
    End Function
    Public Function BTI708_ChConfigEx(ByVal configval As UInt32, ByVal count As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChConfigEx(configval, count, channum, handleval)
        Else
            Return BTI708_64.BTI708_ChConfigEx(configval, count, channum, handleval)
        End If
    End Function
    Public Function BTI708_ChDataCountRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChDataCountRd(channum, handleval)
        Else
            Return BTI708_64.BTI708_ChDataCountRd(channum, handleval)
        End If
    End Function
    Public Function BTI708_ChDataCountWr(ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ChDataCountWr(countval, channum, handleval)
        Else
            Return BTI708_64.BTI708_ChDataCountWr(countval, channum, handleval)
        End If
    End Function
    Public Function BTI708_DllUsageCount() As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_DllUsageCount
        Else
            Return BTI708_64.BTI708_DllUsageCount
        End If
    End Function
    Public Sub BTI708_GetChanCount(ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI708_32.BTI708_GetChanCount(rcvcount, xmtcount, handleval)
        Else
            BTI708_64.BTI708_GetChanCount(rcvcount, xmtcount, handleval)
        End If
    End Sub
    Public Function BTI708_HostComm(ByVal lpparam As IntPtr, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_HostComm(lpparam, handleval)
        Else
            Return BTI708_64.BTI708_HostComm(lpparam, handleval)
        End If
    End Function
    Public Function BTI708_IsChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_IsChan(channum, handleval)
        Else
            Return BTI708_64.BTI708_IsChan(channum, handleval)
        End If
    End Function
    Public Function BTI708_IsRcvChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_IsRcvChan(channum, handleval)
        Else
            Return BTI708_64.BTI708_IsRcvChan(channum, handleval)
        End If
    End Function
    Public Function BTI708_IsXmtChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_IsXmtChan(channum, handleval)
        Else
            Return BTI708_64.BTI708_IsXmtChan(channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgActivityRd(ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgActivityRd(msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgActivityRd(msgindex, channum, handleval)
        End If
    End Function
    Public Sub BTI708_MsgActivityWr(ByVal value As UInt16, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI708_32.BTI708_MsgActivityWr(value, msgindex, channum, handleval)
        Else
            BTI708_64.BTI708_MsgActivityWr(value, msgindex, channum, handleval)
        End If
    End Sub
    Public Function BTI708_MsgAddr(ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgAddr(msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgAddr(msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgCommRd(ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgCommRd(msgfields, msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgCommRd(msgfields, msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgCommWr(ByRef msgfields As MSGFIELDS708, ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgCommWr(msgfields, msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgCommWr(msgfields, msgindex, channum, handleval)
        End If
    End Function
    Public Function BTI708_MsgConfig(ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgConfig(configval, msgaddr, handleval)
        Else
            Return BTI708_64.BTI708_MsgConfig(configval, msgaddr, handleval)
        End If
    End Function
    Public Function BTI708_MsgCreate(ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgCreate(configval, handleval)
        Else
            Return BTI708_64.BTI708_MsgCreate(configval, handleval)
        End If
    End Function
    Public Function BTI708_MsgOptRd(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgOptRd(msgaddr, handleval)
        Else
            Return BTI708_64.BTI708_MsgOptRd(msgaddr, handleval)
        End If
    End Function
    Public Sub BTI708_MsgOptWr(ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI708_32.BTI708_MsgOptWr(msgopt, msgaddr, handleval)
        Else
            BTI708_64.BTI708_MsgOptWr(msgopt, msgaddr, handleval)
        End If
    End Sub
    Public Sub BTI708_MsgReset(ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI708_32.BTI708_MsgReset(msgaddr, handleval)
        Else
            BTI708_64.BTI708_MsgReset(msgaddr, handleval)
        End If
    End Sub
    Public Function BTI708_MsgTableCreate(ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgTableCreate(count, handleval)
        Else
            Return BTI708_64.BTI708_MsgTableCreate(count, handleval)
        End If
    End Function
    Public Function BTI708_MsgTableRd(ByVal msgindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgTableRd(msgindex, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgTableRd(msgindex, channum, handleval)
        End If
    End Function
    Public Sub BTI708_MsgTableReset(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI708_32.BTI708_MsgTableReset(channum, handleval)
        Else
            BTI708_64.BTI708_MsgTableReset(channum, handleval)
        End If
    End Sub
    Public Sub BTI708_MsgTableWipe(ByVal basevaladdr As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI708_32.BTI708_MsgTableWipe(basevaladdr, handleval)
        Else
            BTI708_64.BTI708_MsgTableWipe(basevaladdr, handleval)
        End If
    End Sub
    Public Function BTI708_MsgTableWr(ByVal msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_MsgTableWr(msgaddr, channum, handleval)
        Else
            Return BTI708_64.BTI708_MsgTableWr(msgaddr, channum, handleval)
        End If
    End Function
    Public Function BTI708_ParamAmplitudeGet(ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_ParamAmplitudeGet(dacval, channum, handleval)
        Else
            Return BTI708_64.BTI708_ParamAmplitudeGet(dacval, channum, handleval)
        End If
    End Function
    Public Function BTI708_TestProtocol(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI708_32.BTI708_TestProtocol(handleval)
        Else
            Return BTI708_64.BTI708_TestProtocol(handleval)
        End If
    End Function

    '/**
    '*
    '*  Channel number constants
    '*
    '**/

    Public Const CH0 As UInt16 = &H0 '//Channel 0
    Public Const CH1 As UInt16 = &H1 '//Channel 1
    Public Const CH2 As UInt16 = &H2 '//Channel 2
    Public Const CH3 As UInt16 = &H3 '//Channel 3
    Public Const CH4 As UInt16 = &H4 '//Channel 4
    Public Const CH5 As UInt16 = &H5 '//Channel 5
    Public Const CH6 As UInt16 = &H6 '//Channel 6
    Public Const CH7 As UInt16 = &H7 '//Channel 7
    Public Const CH8 As UInt16 = &H8 '//Channel 8
    Public Const CH9 As UInt16 = &H9 '//Channel 9
    Public Const CH10 As UInt16 = &HA    '//Channel 10
    Public Const CH11 As UInt16 = &HB    '//Channel 11
    Public Const CH12 As UInt16 = &HC    '//Channel 12
    Public Const CH13 As UInt16 = &HD    '//Channel 13
    Public Const CH14 As UInt16 = &HE    '//Channel 14
    Public Const CH15 As UInt16 = &HF    '//Channel 15
    Public Const CH16 As UInt16 = &H10    '//Channel 16
    Public Const CH17 As UInt16 = &H11    '//Channel 17
    Public Const CH18 As UInt16 = &H12    '//Channel 18
    Public Const CH19 As UInt16 = &H13    '//Channel 19
    Public Const CH20 As UInt16 = &H14    '//Channel 20
    Public Const CH21 As UInt16 = &H15    '//Channel 21
    Public Const CH22 As UInt16 = &H16    '//Channel 22
    Public Const CH23 As UInt16 = &H17    '//Channel 23
    Public Const CH24 As UInt16 = &H18    '//Channel 24
    Public Const CH25 As UInt16 = &H19    '//Channel 25
    Public Const CH26 As UInt16 = &H1A    '//Channel 26
    Public Const CH27 As UInt16 = &H1B    '//Channel 27
    Public Const CH28 As UInt16 = &H1C    '//Channel 28
    Public Const CH29 As UInt16 = &H1D    '//Channel 29
    Public Const CH30 As UInt16 = &H1E    '//Channel 30
    Public Const CH31 As UInt16 = &H1F    '//Channel 31

    '/**
    '*
    '*  Channel configuration options
    '*
    '**/

    Public Const CHCFG708_DEFAULT As UInt32 = &H0    '//Select all default settings (XMT & RCV) (default)
    Public Const CHCFG708_NOSWAP As UInt32 = &H0 '//Select 708 bit order (XMT & RCV) (default)
    Public Const CHCFG708_SWAP As UInt32 = &H1   '//Select 1553 bit order (XMT & RCV)
    Public Const CHCFG708_WORDSYNC As UInt32 = &H0   '//Select resync on words (RCV) (default)
    Public Const CHCFG708_BITSYNC As UInt32 = &H2    '//Select resync on every bit (RCV)
    Public Const CHCFG708_SELFTEST As UInt32 = &H4   '//Enable internal wraparound (XMT & RCV)
    Public Const CHCFG708_SELFTESTOFF As UInt32 = &H0    '//Disable internal wraparound (XMT & RCV) (default)
    Public Const CHCFG708_SYNCSEL As UInt32 = &H0    '//Sync output controlled at message level (XMT) (default)
    Public Const CHCFG708_SYNCALL As UInt32 = &H8    '//Sync output for all messages (XMT & RCV)
    Public Const CHCFG708_ERRSYNCOFF As UInt32 = &H0 '//Disable pulsing of DOUT for errors (RCV) (default)
    Public Const CHCFG708_ERRSYNCON As UInt32 = &H10  '//Enable pulsing of DOUT for errors (RCV)
    Public Const CHCFG708_EXTTRIG As UInt32 = &H20    '//Enable external trigger for all messages (XMT)
    Public Const CHCFG708_EXTOFF As UInt32 = &H0 '//External trigger is enabled on message level (XMT) (default)
    Public Const CHCFG708_TRIGNONE As UInt32 = &H0   '//No trigger (XMT) (default)
    Public Const CHCFG708_TRIGEXT As UInt32 = &H40    '//Trigger external (XMT)
    Public Const CHCFG708_TRIGSTART As UInt32 = &H80  '//Trigger external start (XMT)
    Public Const CHCFG708_ACTIVE As UInt32 = &H0 '//Enable channel (XMT & RCV) (default)
    Public Const CHCFG708_INACTIVE As UInt32 = &H100   '//Disable channel (XMT & RCV)
    Public Const CHCFG708_HIT As UInt32 = &H200    '//Hit counter is enabled for all messages (XMT & RCV)
    Public Const CHCFG708_NOHIT As UInt32 = &H0  '//Hit counter is enabled on message level (XMT & RCV) (default)
    Public Const CHCFG708_TIMETAG As UInt32 = &H400    '//Enable time-tag for all message records (XMT & RCV)
    Public Const CHCFG708_TIMETAGOFF As UInt32 = &H0 '//Time-tag is enabled on message level (XMT & RCV) (default)
    Public Const CHCFG708_ELAPSE As UInt32 = &H800 '//Enable elapse time for all messages (XMT & RCV)
    Public Const CHCFG708_ELAPSEOFF As UInt32 = &H0  '//Elapse time is enabled on message level (XMT & RCV) (default)
    Public Const CHCFG708_MAX As UInt32 = &H1000    '//Enable max repetition rate monitoring for all messages (XMT & RCV)
    Public Const CHCFG708_MAXOFF As UInt32 = &H0 '//Repetition rate monitoring is enabled on message level (XMT & RCV) (default)
    Public Const CHCFG708_MIN As UInt32 = &H2000    '//Enable min repetition rate monitoring for all messages (XMT & RCV)
    Public Const CHCFG708_MINOFF As UInt32 = &H0 '//Repetition rate monitoring is enabled on message level (XMT & RCV) (default)
    Public Const CHCFG708_SEQALL As UInt32 = &H80000 '//Record entire channel in sequential record (XMT & RCV)
    Public Const CHCFG708_SEQSEL As UInt32 = &H0 '//Sequential record recording is enabled at message level (XMT & RCV) (default)
    Public Const CHCFG708_PAUSE As UInt32 = &H1000000  '//Mark channel as paused (XMT & RCV)
    Public Const CHCFG708_UNPAUSE As UInt32 = &H0    '//Mark channel as unpaused (XMT & RCV) (default)
    Public Const CHCFG708_RCVBUSA As UInt32 = &H0    '//Receive channel will operate on Bus A (RCV) (default)
    Public Const CHCFG708_RCVBUSB As UInt32 = &H4000    '//Receive channel will operate on Bus B (RCV)
    Public Const CHCFG708_XMTBUSA As UInt32 = &H4000    '//Transmit channel will operate on Bus A (XMT)
    Public Const CHCFG708_XMTBUSB As UInt32 = &H0    '//Transmit channel will operate on Bus B (XMT) (default)
    Public Const CHCFG708_TERMOFF As UInt32 = &H0    '//Direct coupled termination resistance off (XMT & RCV) (default)
    Public Const CHCFG708_TERMON As UInt32 = &H8000 '//Direct coupled termination resistance on (XMT & RCV)
    Public Const CHCFG708_FIXBIT As UInt32 = &H0 '//Channel operates with fixed bit length (XMT & RCV) (default)
    Public Const CHCFG708_VARBIT As UInt32 = &H10000 '//Channel operates with variable bit length (XMT & RCV)
    Public Const CHCFG708_PRESYNCOFF As UInt32 = &H0 '//Pre-sync pulses off (XMT) (default)
    Public Const CHCFG708_PRESYNCON As UInt32 = &H20000  '//Pre-sync pulses on (XMT)

    '/**
    '*
    '*  Message configuration options
    '*
    '**/

    Public Const MSGCRT708_DEFAULT As UInt32 = &H0   '//Default settings
    Public Const MSGCRT708_NOSEQ As UInt32 = &H0 '//Message will not be recorded in sequential record (default)
    Public Const MSGCRT708_SEQ As UInt32 = &H1   '//Message will be recorded in sequential record
    Public Const MSGCRT708_NOLOG As UInt32 = &H0 '//Message will not generate event log (default)
    Public Const MSGCRT708_LOG As UInt32 = &H2   '//Message will generate event log
    Public Const MSGCRT708_NOSKIP As UInt32 = &H0    '//Message will not be skipped (default)
    Public Const MSGCRT708_SKIP As UInt32 = &H8  '//Message will be skipped
    Public Const MSGCRT708_NOTIMETAG As UInt32 = &H0 '//Message will not record time-tag (default)
    Public Const MSGCRT708_TIMETAG As UInt32 = &H10   '//Message will record time-tag
    Public Const MSGCRT708_NOELAPSE As UInt32 = &H0  '//Message will not record elapse time (default)
    Public Const MSGCRT708_ELAPSE As UInt32 = &H20    '//Message will record elapse time
    Public Const MSGCRT708_NOMAX As UInt32 = &H0 '//Message will not record max time (default)
    Public Const MSGCRT708_MAX As UInt32 = &H40   '//Message will record max time
    Public Const MSGCRT708_NOMIN As UInt32 = &H0 '//Message will not record min time (default)
    Public Const MSGCRT708_MIN As UInt32 = &H80   '//Message will record min time
    Public Const MSGCRT708_MAXMIN As UInt32 = &HC0    '//Message will record min/max time
    Public Const MSGCRT708_NOSYNC As UInt32 = &H0    '//Message will not generate a syncout pulse (default)
    Public Const MSGCRT708_SYNC As UInt32 = &H100  '//Message will generate a syncout pulse
    Public Const MSGCRT708_NOHIT As UInt32 = &H0 '//Message will not record hit count (default)
    Public Const MSGCRT708_HIT As UInt32 = &H400   '//Message will record hit count
    Public Const MSGCRT708_NOEXTRIG As UInt32 = &H0  '//Message will not be externally triggered (default)
    Public Const MSGCRT708_EXTRIG As UInt32 = &H1000    '//Message will be externally triggered

    '/**
    '*
    '*  Parametric configuration options
    '*
    '**/

    Public Const PARAMCFG708_DEFAULT As UInt32 = &H0 '//Select all default settings (default)
    Public Const PARAMCFG708_AMPLON As UInt32 = &H0  '//Enables parametric amplitude control (default)
    Public Const PARAMCFG708_AMPLOFF As UInt32 = &H1 '//Disables parametric amplitude control

    '/**
    '*
    '*  Bit fields of the message activity flag.
    '*
    '**/

    Public Const MSGACT708_CHMASK As UInt32 = &HFF00    '//Channel number mask value
    Public Const MSGACT708_CHSHIFT As UInt32 = &H8   '//Channel number shift value
    Public Const MSGACT708_ERR As UInt32 = &H80   '//Error bit
    Public Const MSGACT708_SHORT As UInt32 = &H40 '//Short word error bit
    Public Const MSGACT708_LONG As UInt32 = &H20  '//Long word error bit
    Public Const MSGACT708_MANCH As UInt32 = &H10 '//Manchester error bit
    Public Const MSGACT708_DSYNC As UInt32 = &H8 '//Data sync error bit
    Public Const MSGACT708_WORD As UInt32 = &H4  '//Word error bit
    Public Const MSGACT708_TO As UInt32 = &H2    '//Time out error bit
    Public Const MSGACT708_HIT As UInt32 = &H1   '//Always set

    '/**
    '*
    '*  Channel info fields.
    '*
    '**/

    Public Const INFO708_PARAM As UInt32 = &H1   '//Channel supports parametric control
    Public Const INFO708_VARBIT As UInt32 = &H2  '//Channel supports variable bit length mode

End Module
