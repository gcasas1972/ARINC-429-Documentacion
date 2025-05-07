Imports System
Imports System.Runtime.InteropServices

Module BTI717VB

    '/**
    '*
    '*  BTI717 WIN32 DRIVER  Version 1.8.2  (10/05/2010)
    '*  Copyright (c) 2001-2010
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   BTI717NET.VB -- 32-bit
    '*                      BTI717 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  Structs used by the BTI717 Driver.
    '*
    '**/

    <StructLayout(LayoutKind.Sequential)> Public Structure SUBFRMFIELDS717
        Public subfrmopt As UInt16  '//Driver writes message optionvals
        Public subfrmact As UInt16  '//Card writes message activity
        Public subfrmnum As UInt16  '//Card writes subframe number
        Public subfrmwps As UInt16  '//Card writes WPS
        Public timestamp_hitcount As UInt32 '//Card writes timestamp - '//Card writes hit count
        Public spfptr As UInt32 '//Card writes superframe pointer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8192)> Public data() As UInt16  '//Card/User writes subframe data. Valid from 0 -> WPS-1. (Rcv/Xmt)
        Public timestamph As UInt32 '//Card writes extended timestamp
        Public extflag As UInt16    '//Driver writes external trigger/sync control flags
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=13)> Public rsvd() As UInt16    '//Reserved
    End Structure

    '/**
    '*
    '*  BTI717 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the BTI717 Driver.
    '*
    '**/

    Private Class BTI717_32
        Public Declare Function BTI717_ChClear Lib "BTI717.DLL" Alias "_BTI717_ChClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChConfig Lib "BTI717.DLL" Alias "_BTI717_ChConfig@12" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI717_ChGetCount Lib "BTI717.DLL" Alias "_BTI717_ChGetCount@12" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI717_ChGetInfo Lib "BTI717.DLL" Alias "_BTI717_ChGetInfo@12" (ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI717_ChIs717 Lib "BTI717.DLL" Alias "_BTI717_ChIs717@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChIsBiPhase Lib "BTI717.DLL" Alias "_BTI717_ChIsBiPhase@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChIsRcv Lib "BTI717.DLL" Alias "_BTI717_ChIsRcv@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChIsSelEnc Lib "BTI717.DLL" Alias "_BTI717_ChIsSelEnc@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChIsType Lib "BTI717.DLL" Alias "_BTI717_ChIsType@12" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChIsXmt Lib "BTI717.DLL" Alias "_BTI717_ChIsXmt@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI717_ChPause Lib "BTI717.DLL" Alias "_BTI717_ChPause@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI717_ChPauseCheck Lib "BTI717.DLL" Alias "_BTI717_ChPauseCheck@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI717_ChResume Lib "BTI717.DLL" Alias "_BTI717_ChResume@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI717_ChStart Lib "BTI717.DLL" Alias "_BTI717_ChStart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChStatus Lib "BTI717.DLL" Alias "_BTI717_ChStatus@12" (ByRef buf As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChStop Lib "BTI717.DLL" Alias "_BTI717_ChStop@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChSyncDefine Lib "BTI717.DLL" Alias "_BTI717_ChSyncDefine@20" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChTriggerDefine Lib "BTI717.DLL" Alias "_BTI717_ChTriggerDefine@24" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ParamAmplitudeConfig Lib "BTI717.DLL" Alias "_BTI717_ParamAmplitudeConfig@16" (ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ParamAmplitudeGet Lib "BTI717.DLL" Alias "_BTI717_ParamAmplitudeGet@12" (ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmBlkRd Lib "BTI717.DLL" Alias "_BTI717_SubFrmBlkRd@16" (ByRef databuf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmBlkWr Lib "BTI717.DLL" Alias "_BTI717_SubFrmBlkWr@16" (ByRef databuf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmStatus Lib "BTI717.DLL" Alias "_BTI717_SubFrmStatus@16" (ByRef buf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmSyncDefine Lib "BTI717.DLL" Alias "_BTI717_SubFrmSyncDefine@24" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmTriggerDefine Lib "BTI717.DLL" Alias "_BTI717_SubFrmTriggerDefine@28" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmWordConfig Lib "BTI717.DLL" Alias "_BTI717_SubFrmWordConfig@20" (ByVal configval As UInt32, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmWordRd Lib "BTI717.DLL" Alias "_BTI717_SubFrmWordRd@20" (ByRef value As UInt16, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmWordWr Lib "BTI717.DLL" Alias "_BTI717_SubFrmWordWr@20" (ByVal value As UInt16, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmConfig Lib "BTI717.DLL" Alias "_BTI717_SuperFrmConfig@16" (ByVal count As Int32, ByVal framespersuperframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmCounterPos Lib "BTI717.DLL" Alias "_BTI717_SuperFrmCounterPos@16" (ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmDefine Lib "BTI717.DLL" Alias "_BTI717_SuperFrmDefine@16" (ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI717_SuperFrmWordConfig Lib "BTI717.DLL" Alias "_BTI717_SuperFrmWordConfig@20" (ByVal configval As UInt32, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmWordRd Lib "BTI717.DLL" Alias "_BTI717_SuperFrmWordRd@20" (ByRef value As UInt16, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmWordWr Lib "BTI717.DLL" Alias "_BTI717_SuperFrmWordWr@20" (ByVal value As UInt16, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SyncTest Lib "BTI717.DLL" Alias "_BTI717_SyncTest@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SyncValRd Lib "BTI717.DLL" Alias "_BTI717_SyncValRd@24" (ByRef syncword1 As Int32, ByRef syncword2 As Int32, ByRef syncword3 As Int32, ByRef syncword4 As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SyncValWr Lib "BTI717.DLL" Alias "_BTI717_SyncValWr@24" (ByVal syncword1 As Int32, ByVal syncword2 As Int32, ByVal syncword3 As Int32, ByVal syncword4 As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChCreate Lib "BTI717.DLL" Alias "_BTI717_ChCreate@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI717_ChReset Lib "BTI717.DLL" Alias "_BTI717_ChReset@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_DllUsageCount Lib "BTI717.DLL" Alias "_BTI717_DllUsageCount@0" () As Int32
        Public Declare Sub BTI717_GetChanCount Lib "BTI717.DLL" Alias "_BTI717_GetChanCount@12" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI717_IsBiPhaseChan Lib "BTI717.DLL" Alias "_BTI717_IsBiPhaseChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_IsChan Lib "BTI717.DLL" Alias "_BTI717_IsChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_IsRcvChan Lib "BTI717.DLL" Alias "_BTI717_IsRcvChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_IsXmtChan Lib "BTI717.DLL" Alias "_BTI717_IsXmtChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmAddr Lib "BTI717.DLL" Alias "_BTI717_SubFrmAddr@12" (ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI717_SubFrmBlkRdEx Lib "BTI717.DLL" Alias "_BTI717_SubFrmBlkRdEx@16" (ByRef subfrmdata As SUBFRMFIELDS717, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmBlkWrEx Lib "BTI717.DLL" Alias "_BTI717_SubFrmBlkWrEx@16" (ByRef subfrmdata As SUBFRMFIELDS717, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmCreate Lib "BTI717.DLL" Alias "_BTI717_SubFrmCreate@16" (ByVal configval As UInt32, ByVal subframe As Int32, ByVal chanbase As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmReset Lib "BTI717.DLL" Alias "_BTI717_SubFrmReset@12" (ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmBaseAddr Lib "BTI717.DLL" Alias "_BTI717_SuperFrmBaseAddr@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI717_SuperFrmConfigEx Lib "BTI717.DLL" Alias "_BTI717_SuperFrmConfigEx@20" (ByVal configval As UInt32, ByVal count As Int32, ByVal framespersuperframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmReset Lib "BTI717.DLL" Alias "_BTI717_SuperFrmReset@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SyncValPtrInit Lib "BTI717.DLL" Alias "_BTI717_SyncValPtrInit@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_TestProtocol Lib "BTI717.DLL" Alias "_BTI717_TestProtocol@4" (ByVal handleval As UInt32) As Int32
    End Class

    Private Class BTI717_64
        Public Declare Function BTI717_ChClear Lib "BTI71764.DLL" Alias "BTI717_ChClear" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChConfig Lib "BTI71764.DLL" Alias "BTI717_ChConfig" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI717_ChGetCount Lib "BTI71764.DLL" Alias "BTI717_ChGetCount" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI717_ChGetInfo Lib "BTI71764.DLL" Alias "BTI717_ChGetInfo" (ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI717_ChIs717 Lib "BTI71764.DLL" Alias "BTI717_ChIs717" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChIsBiPhase Lib "BTI71764.DLL" Alias "BTI717_ChIsBiPhase" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChIsRcv Lib "BTI71764.DLL" Alias "BTI717_ChIsRcv" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChIsSelEnc Lib "BTI71764.DLL" Alias "BTI717_ChIsSelEnc" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChIsType Lib "BTI71764.DLL" Alias "BTI717_ChIsType" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChIsXmt Lib "BTI71764.DLL" Alias "BTI717_ChIsXmt" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI717_ChPause Lib "BTI71764.DLL" Alias "BTI717_ChPause" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI717_ChPauseCheck Lib "BTI71764.DLL" Alias "BTI717_ChPauseCheck" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI717_ChResume Lib "BTI71764.DLL" Alias "BTI717_ChResume" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI717_ChStart Lib "BTI71764.DLL" Alias "BTI717_ChStart" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChStatus Lib "BTI71764.DLL" Alias "BTI717_ChStatus" (ByRef buf As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChStop Lib "BTI71764.DLL" Alias "BTI717_ChStop" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChSyncDefine Lib "BTI71764.DLL" Alias "BTI717_ChSyncDefine" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChTriggerDefine Lib "BTI71764.DLL" Alias "BTI717_ChTriggerDefine" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ParamAmplitudeConfig Lib "BTI71764.DLL" Alias "BTI717_ParamAmplitudeConfig" (ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ParamAmplitudeGet Lib "BTI71764.DLL" Alias "BTI717_ParamAmplitudeGet" (ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmBlkRd Lib "BTI71764.DLL" Alias "BTI717_SubFrmBlkRd" (ByRef databuf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmBlkWr Lib "BTI71764.DLL" Alias "BTI717_SubFrmBlkWr" (ByRef databuf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmStatus Lib "BTI71764.DLL" Alias "BTI717_SubFrmStatus" (ByRef buf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmSyncDefine Lib "BTI71764.DLL" Alias "BTI717_SubFrmSyncDefine" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmTriggerDefine Lib "BTI71764.DLL" Alias "BTI717_SubFrmTriggerDefine" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmWordConfig Lib "BTI71764.DLL" Alias "BTI717_SubFrmWordConfig" (ByVal configval As UInt32, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmWordRd Lib "BTI71764.DLL" Alias "BTI717_SubFrmWordRd" (ByRef value As UInt16, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmWordWr Lib "BTI71764.DLL" Alias "BTI717_SubFrmWordWr" (ByVal value As UInt16, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmConfig Lib "BTI71764.DLL" Alias "BTI717_SuperFrmConfig" (ByVal count As Int32, ByVal framespersuperframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmCounterPos Lib "BTI71764.DLL" Alias "BTI717_SuperFrmCounterPos" (ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmDefine Lib "BTI71764.DLL" Alias "BTI717_SuperFrmDefine" (ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI717_SuperFrmWordConfig Lib "BTI71764.DLL" Alias "BTI717_SuperFrmWordConfig" (ByVal configval As UInt32, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmWordRd Lib "BTI71764.DLL" Alias "BTI717_SuperFrmWordRd" (ByRef value As UInt16, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmWordWr Lib "BTI71764.DLL" Alias "BTI717_SuperFrmWordWr" (ByVal value As UInt16, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SyncTest Lib "BTI71764.DLL" Alias "BTI717_SyncTest" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SyncValRd Lib "BTI71764.DLL" Alias "BTI717_SyncValRd" (ByRef syncword1 As Int32, ByRef syncword2 As Int32, ByRef syncword3 As Int32, ByRef syncword4 As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SyncValWr Lib "BTI71764.DLL" Alias "BTI717_SyncValWr" (ByVal syncword1 As Int32, ByVal syncword2 As Int32, ByVal syncword3 As Int32, ByVal syncword4 As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_ChCreate Lib "BTI71764.DLL" Alias "BTI717_ChCreate" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI717_ChReset Lib "BTI71764.DLL" Alias "BTI717_ChReset" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_DllUsageCount Lib "BTI71764.DLL" Alias "BTI717_DllUsageCount" () As Int32
        Public Declare Sub BTI717_GetChanCount Lib "BTI71764.DLL" Alias "BTI717_GetChanCount" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI717_IsBiPhaseChan Lib "BTI71764.DLL" Alias "BTI717_IsBiPhaseChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_IsChan Lib "BTI71764.DLL" Alias "BTI717_IsChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_IsRcvChan Lib "BTI71764.DLL" Alias "BTI717_IsRcvChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_IsXmtChan Lib "BTI71764.DLL" Alias "BTI717_IsXmtChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmAddr Lib "BTI71764.DLL" Alias "BTI717_SubFrmAddr" (ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI717_SubFrmBlkRdEx Lib "BTI71764.DLL" Alias "BTI717_SubFrmBlkRdEx" (ByRef subfrmdata As SUBFRMFIELDS717, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmBlkWrEx Lib "BTI71764.DLL" Alias "BTI717_SubFrmBlkWrEx" (ByRef subfrmdata As SUBFRMFIELDS717, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmCreate Lib "BTI71764.DLL" Alias "BTI717_SubFrmCreate" (ByVal configval As UInt32, ByVal subframe As Int32, ByVal chanbase As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SubFrmReset Lib "BTI71764.DLL" Alias "BTI717_SubFrmReset" (ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmBaseAddr Lib "BTI71764.DLL" Alias "BTI717_SuperFrmBaseAddr" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI717_SuperFrmConfigEx Lib "BTI71764.DLL" Alias "BTI717_SuperFrmConfigEx" (ByVal configval As UInt32, ByVal count As Int32, ByVal framespersuperframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SuperFrmReset Lib "BTI71764.DLL" Alias "BTI717_SuperFrmReset" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_SyncValPtrInit Lib "BTI71764.DLL" Alias "BTI717_SyncValPtrInit" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI717_TestProtocol Lib "BTI71764.DLL" Alias "BTI717_TestProtocol" (ByVal handleval As UInt32) As Int32
    End Class

    Public Function BTI717_ChClear(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChClear(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChClear(channum, handleval)
        End If
    End Function
    Public Function BTI717_ChConfig(ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChConfig(configval, channum, handleval)
        Else
            Return BTI717_64.BTI717_ChConfig(configval, channum, handleval)
        End If
    End Function
    Public Sub BTI717_ChGetCount(ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI717_32.BTI717_ChGetCount(rcvcount, xmtcount, handleval)
        Else
            BTI717_64.BTI717_ChGetCount(rcvcount, xmtcount, handleval)
        End If
    End Sub
    Public Function BTI717_ChGetInfo(ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChGetInfo(infotype, channum, handleval)
        Else
            Return BTI717_64.BTI717_ChGetInfo(infotype, channum, handleval)
        End If
    End Function
    Public Function BTI717_ChIs717(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChIs717(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChIs717(channum, handleval)
        End If
    End Function
    Public Function BTI717_ChIsBiPhase(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChIsBiPhase(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChIsBiPhase(channum, handleval)
        End If
    End Function
    Public Function BTI717_ChIsRcv(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChIsRcv(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChIsRcv(channum, handleval)
        End If
    End Function
    Public Function BTI717_ChIsSelEnc(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChIsSelEnc(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChIsSelEnc(channum, handleval)
        End If
    End Function
    Public Function BTI717_ChIsType(ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChIsType(configval, channum, handleval)
        Else
            Return BTI717_64.BTI717_ChIsType(configval, channum, handleval)
        End If
    End Function
    Public Function BTI717_ChIsXmt(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChIsXmt(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChIsXmt(channum, handleval)
        End If
    End Function
    Public Sub BTI717_ChPause(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI717_32.BTI717_ChPause(channum, handleval)
        Else
            BTI717_64.BTI717_ChPause(channum, handleval)
        End If
    End Sub
    Public Function BTI717_ChPauseCheck(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChPauseCheck(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChPauseCheck(channum, handleval)
        End If
    End Function
    Public Sub BTI717_ChResume(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI717_32.BTI717_ChResume(channum, handleval)
        Else
            BTI717_64.BTI717_ChResume(channum, handleval)
        End If
    End Sub
    Public Function BTI717_ChStart(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChStart(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChStart(channum, handleval)
        End If
    End Function
    Public Function BTI717_ChStatus(ByRef buf As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChStatus(buf, channum, handleval)
        Else
            Return BTI717_64.BTI717_ChStatus(buf, channum, handleval)
        End If
    End Function
    Public Function BTI717_ChStop(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChStop(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChStop(channum, handleval)
        End If
    End Function
    Public Function BTI717_ChSyncDefine(ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval)
        Else
            Return BTI717_64.BTI717_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval)
        End If
    End Function
    Public Function BTI717_ChTriggerDefine(ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval)
        Else
            Return BTI717_64.BTI717_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval)
        End If
    End Function
    Public Function BTI717_ParamAmplitudeConfig(ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ParamAmplitudeConfig(configval, dacval, channum, handleval)
        Else
            Return BTI717_64.BTI717_ParamAmplitudeConfig(configval, dacval, channum, handleval)
        End If
    End Function
    Public Function BTI717_ParamAmplitudeGet(ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ParamAmplitudeGet(dacval, channum, handleval)
        Else
            Return BTI717_64.BTI717_ParamAmplitudeGet(dacval, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmBlkRd(ByRef databuf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmBlkRd(databuf, subframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmBlkRd(databuf, subframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmBlkWr(ByRef databuf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmBlkWr(databuf, subframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmBlkWr(databuf, subframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmStatus(ByRef buf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmStatus(buf, subframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmStatus(buf, subframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmSyncDefine(ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmSyncDefine(enableflag, syncmask, pinpolarity, subframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmSyncDefine(enableflag, syncmask, pinpolarity, subframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmTriggerDefine(ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmTriggerDefine(enableflag, trigmask, trigval, pinpolarity, subframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmTriggerDefine(enableflag, trigmask, trigval, pinpolarity, subframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmWordConfig(ByVal configval As UInt32, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmWordConfig(configval, subframe, word, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmWordConfig(configval, subframe, word, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmWordRd(ByRef value As UInt16, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmWordRd(value, subframe, word, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmWordRd(value, subframe, word, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmWordWr(ByVal value As UInt16, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmWordWr(value, subframe, word, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmWordWr(value, subframe, word, channum, handleval)
        End If
    End Function
    Public Function BTI717_SuperFrmConfig(ByVal count As Int32, ByVal framespersuperframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SuperFrmConfig(count, framespersuperframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SuperFrmConfig(count, framespersuperframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SuperFrmCounterPos(ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SuperFrmCounterPos(subframe, word, channum, handleval)
        Else
            Return BTI717_64.BTI717_SuperFrmCounterPos(subframe, word, channum, handleval)
        End If
    End Function
    Public Function BTI717_SuperFrmDefine(ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SuperFrmDefine(subframe, word, channum, handleval)
        Else
            Return BTI717_64.BTI717_SuperFrmDefine(subframe, word, channum, handleval)
        End If
    End Function
    Public Function BTI717_SuperFrmWordConfig(ByVal configval As UInt32, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SuperFrmWordConfig(configval, superfrmnum, superfrmaddr, channum, handleval)
        Else
            Return BTI717_64.BTI717_SuperFrmWordConfig(configval, superfrmnum, superfrmaddr, channum, handleval)
        End If
    End Function
    Public Function BTI717_SuperFrmWordRd(ByRef value As UInt16, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SuperFrmWordRd(value, superfrmnum, superfrmaddr, channum, handleval)
        Else
            Return BTI717_64.BTI717_SuperFrmWordRd(value, superfrmnum, superfrmaddr, channum, handleval)
        End If
    End Function
    Public Function BTI717_SuperFrmWordWr(ByVal value As UInt16, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SuperFrmWordWr(value, superfrmnum, superfrmaddr, channum, handleval)
        Else
            Return BTI717_64.BTI717_SuperFrmWordWr(value, superfrmnum, superfrmaddr, channum, handleval)
        End If
    End Function
    Public Function BTI717_SyncTest(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SyncTest(channum, handleval)
        Else
            Return BTI717_64.BTI717_SyncTest(channum, handleval)
        End If
    End Function
    Public Function BTI717_SyncValRd(ByRef syncword1 As Int32, ByRef syncword2 As Int32, ByRef syncword3 As Int32, ByRef syncword4 As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SyncValRd(syncword1, syncword2, syncword3, syncword4, channum, handleval)
        Else
            Return BTI717_64.BTI717_SyncValRd(syncword1, syncword2, syncword3, syncword4, channum, handleval)
        End If
    End Function
    Public Function BTI717_SyncValWr(ByVal syncword1 As Int32, ByVal syncword2 As Int32, ByVal syncword3 As Int32, ByVal syncword4 As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SyncValWr(syncword1, syncword2, syncword3, syncword4, channum, handleval)
        Else
            Return BTI717_64.BTI717_SyncValWr(syncword1, syncword2, syncword3, syncword4, channum, handleval)
        End If
    End Function
    Public Function BTI717_ChCreate(ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChCreate(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChCreate(channum, handleval)
        End If
    End Function
    Public Function BTI717_ChReset(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_ChReset(channum, handleval)
        Else
            Return BTI717_64.BTI717_ChReset(channum, handleval)
        End If
    End Function
    Public Function BTI717_DllUsageCount() As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_DllUsageCount
        Else
            Return BTI717_64.BTI717_DllUsageCount
        End If
    End Function
    Public Sub BTI717_GetChanCount(ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI717_32.BTI717_GetChanCount(rcvcount, xmtcount, handleval)
        Else
            BTI717_64.BTI717_GetChanCount(rcvcount, xmtcount, handleval)
        End If
    End Sub
    Public Function BTI717_IsBiPhaseChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_IsBiPhaseChan(channum, handleval)
        Else
            Return BTI717_64.BTI717_IsBiPhaseChan(channum, handleval)
        End If
    End Function
    Public Function BTI717_IsChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_IsChan(channum, handleval)
        Else
            Return BTI717_64.BTI717_IsChan(channum, handleval)
        End If
    End Function
    Public Function BTI717_IsRcvChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_IsRcvChan(channum, handleval)
        Else
            Return BTI717_64.BTI717_IsRcvChan(channum, handleval)
        End If
    End Function
    Public Function BTI717_IsXmtChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_IsXmtChan(channum, handleval)
        Else
            Return BTI717_64.BTI717_IsXmtChan(channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmAddr(ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmAddr(subframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmAddr(subframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmBlkRdEx(ByRef subfrmdata As SUBFRMFIELDS717, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmBlkRdEx(subfrmdata, subframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmBlkRdEx(subfrmdata, subframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmBlkWrEx(ByRef subfrmdata As SUBFRMFIELDS717, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmBlkWrEx(subfrmdata, subframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmBlkWrEx(subfrmdata, subframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmCreate(ByVal configval As UInt32, ByVal subframe As Int32, ByVal chanbase As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmCreate(configval, subframe, chanbase, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmCreate(configval, subframe, chanbase, handleval)
        End If
    End Function
    Public Function BTI717_SubFrmReset(ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SubFrmReset(subframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SubFrmReset(subframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SuperFrmBaseAddr(ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SuperFrmBaseAddr(channum, handleval)
        Else
            Return BTI717_64.BTI717_SuperFrmBaseAddr(channum, handleval)
        End If
    End Function
    Public Function BTI717_SuperFrmConfigEx(ByVal configval As UInt32, ByVal count As Int32, ByVal framespersuperframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SuperFrmConfigEx(configval, count, framespersuperframe, channum, handleval)
        Else
            Return BTI717_64.BTI717_SuperFrmConfigEx(configval, count, framespersuperframe, channum, handleval)
        End If
    End Function
    Public Function BTI717_SuperFrmReset(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SuperFrmReset(channum, handleval)
        Else
            Return BTI717_64.BTI717_SuperFrmReset(channum, handleval)
        End If
    End Function
    Public Function BTI717_SyncValPtrInit(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_SyncValPtrInit(channum, handleval)
        Else
            Return BTI717_64.BTI717_SyncValPtrInit(channum, handleval)
        End If
    End Function
    Public Function BTI717_TestProtocol(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI717_32.BTI717_TestProtocol(handleval)
        Else
            Return BTI717_64.BTI717_TestProtocol(handleval)
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
    '*  Subframe constants
    '*
    '**/

    Public Const SUBFRM1 As UInt32 = &H1 '//Sub Frame 1
    Public Const SUBFRM2 As UInt32 = &H2 '//Sub Frame 2
    Public Const SUBFRM3 As UInt32 = &H3 '//Sub Frame 3
    Public Const SUBFRM4 As UInt32 = &H4 '//Sub Frame 4

    '/**
    '*
    '*  Channel configuration options
    '*
    '**/

    Public Const CHCFG717_DEFAULT As UInt32 = &H0    '//Select all default settings (XMT & RCV) (default)
    Public Const CHCFG717_AUTOSPEED As UInt32 = &H2  '//Select auto speed detection (RCV)
    Public Const CHCFG717_64WPS As UInt32 = &H4000  '//Select speed of 64WPS (XMT & RCV)
    Public Const CHCFG717_128WPS As UInt32 = &H8000 '//Select speed of 128WPS (XMT & RCV)
    Public Const CHCFG717_256WPS As UInt32 = &H0 '//Select speed of 256WPS (XMT & RCV) (default)
    Public Const CHCFG717_512WPS As UInt32 = &H10000 '//Select speed of 512WPS (XMT & RCV)
    Public Const CHCFG717_1024WPS As UInt32 = &H20000    '//Select speed of 1024WPS (XMT & RCV)
    Public Const CHCFG717_2048WPS As UInt32 = &H40000    '//Select speed of 2048WPS (XMT & RCV)
    Public Const CHCFG717_4096WPS As UInt32 = &H2000000    '//Select speed of 4096WPS (XMT & RCV)
    Public Const CHCFG717_8192WPS As UInt32 = &H4000000    '//Select speed of 8192WPS (XMT & RCV)
    Public Const CHCFG717_BIPHASERCV As UInt32 = &H0 '//Select Bi-Phase decoding for receiver (Bi-Phase or RCV) (default)
    Public Const CHCFG717_BIPHASEXMT As UInt32 = &H8000000 '//Select Bi-Phase encoding for transmitter (Bi-Phase or XMT)
    Public Const CHCFG717_BIPOLARRCV As UInt32 = &H20000000 '//Select Bi-Polar decoding for receiver (Bi-Polar or RCV)
    Public Const CHCFG717_BIPOLARXMT As UInt32 = &H60000000 '//Select Bi-Polar encoding for transmitter (Bi-Polar or XMT)
    Public Const CHCFG717_BIPOLARHSPD As UInt32 = &H8000000    '//Select high speed slope for Bi-Polar transmitter (Bi-Polar XMT)
    Public Const CHCFG717_SELFTEST As UInt32 = &H4   '//Enable internal wraparound (XMT & RCV)
    Public Const CHCFG717_SELFTESTOFF As UInt32 = &H0    '//Disable internal wraparound (XMT & RCV) (default)
    Public Const CHCFG717_SYNC As UInt32 = &H8   '//Sync Enable (XMT & RCV)
    Public Const CHCFG717_SYNCOFF As UInt32 = &H0    '//Disable sync output (XMT & RCV) (default)
    Public Const CHCFG717_ACTIVE As UInt32 = &H0 '//Enable channel activity (XMT & RCV) (default)
    Public Const CHCFG717_INACTIVE As UInt32 = &H40   '//Disable channel activity (XMT & RCV)
    Public Const CHCFG717_EXTSTART As UInt32 = &H100   '//Enable external trigger for first message only (XMT)
    Public Const CHCFG717_EXTTRIG As UInt32 = &H80    '//Enable external trigger for all messages (XMT)
    Public Const CHCFG717_EXTOFF As UInt32 = &H0 '//External trigger is enabled on message level (XMT) (default)
    Public Const CHCFG717_HIT As UInt32 = &H200    '//Hit counter is enabled for all sub frames (XMT & RCV)
    Public Const CHCFG717_NOHIT As UInt32 = &H0  '//Hit counter is disabled (XMT & RCV) (default)
    Public Const CHCFG717_TIMETAG As UInt32 = &H400    '//Enable time-tag for all sub frames (XMT & RCV)
    Public Const CHCFG717_TIMETAGOFF As UInt32 = &H0 '//Time-tag is disabled (XMT & RCV) (default)
    Public Const CHCFG717_SEQALL As UInt32 = &H80000 '//Record entire channel in sequential record (XMT & RCV)
    Public Const CHCFG717_SEQSEL As UInt32 = &H0 '//Sequential record recording is enabled at word level (XMT & RCV) (default)
    Public Const CHCFG717_LOGERR As UInt32 = &H800000 '//Enable event log on Out of Sync Error (RCV)
    Public Const CHCFG717_NOLOGERR As UInt32 = &H0   '//No event log on Out of Sync Error (RCV) (default)
    Public Const CHCFG717_PAUSE As UInt32 = &H1000000  '//Mark channel as paused (XMT & RCV)
    Public Const CHCFG717_UNPAUSE As UInt32 = &H0    '//Mark channel as unpaused (XMT & RCV) (default)
    Public Const CHCFG717_XMTSLOPELOW As UInt32 = &H0    '//Select low speed slope for transmitter (XMT) (default)
    Public Const CHCFG717_XMTSLOPEHIGH As UInt32 = &H10000000   '//Select high speed slope for transmitter (XMT)

    '/**
    '*
    '*  Sub Frame word configuration options
    '*
    '**/

    Public Const WRDCFG717_DEFAULT As UInt32 = &H0   '//Select all default settings
    Public Const WRDCFG717_SFLOG As UInt32 = &H1 '//Enable subframe event log
    Public Const WRDCFG717_SFLOGOFF As UInt32 = &H0  '//Disable subframe event log (default)
    Public Const WRDCFG717_WRDLOG As UInt32 = &H2    '//Enable word event log
    Public Const WRDCFG717_WRDLOGOFF As UInt32 = &H0 '//Disable word event log (default)
    Public Const WRDCFG717_SEQ As UInt32 = &H4   '//Enable sequential record
    Public Const WRDCFG717_SEQOFF As UInt32 = &H0    '//Disable sequential record (default)

    '/**
    '*
    '*  Parametric configuration options
    '*
    '**/

    Public Const PARAMCFG717_DEFAULT As UInt32 = &H0 '//Select all default settings (default)
    Public Const PARAMCFG717_AMPLON As UInt32 = &H0  '//Enables parametric amplitude control (default)
    Public Const PARAMCFG717_AMPLOFF As UInt32 = &H1 '//Disables parametric amplitude control

    '/**
    '*
    '*  Bit fields of the message activity flag.
    '*
    '**/

    Public Const MSGACT717_CHMASK As UInt32 = &HFF00    '//Channel number mask value
    Public Const MSGACT717_CHSHIFT As UInt32 = &H8   '//Channel number shift value
    Public Const MSGACT717_SPDMASK As UInt32 = &HE0   '//Current speed mask value
    Public Const MSGACT717_64WPS As UInt32 = &H0 '//Current speed is 64   wps
    Public Const MSGACT717_128WPS As UInt32 = &H20    '//Current speed is 128  wps
    Public Const MSGACT717_256WPS As UInt32 = &H40    '//Current speed is 256  wps
    Public Const MSGACT717_512WPS As UInt32 = &H60    '//Current speed is 512  wps
    Public Const MSGACT717_1024WPS As UInt32 = &H80   '//Current speed is 1024 wps
    Public Const MSGACT717_2048WPS As UInt32 = &HA0   '//Current speed is 2048 wps
    Public Const MSGACT717_4096WPS As UInt32 = &HC0   '//Current speed is 4096 wps
    Public Const MSGACT717_8192WPS As UInt32 = &HE0   '//Current speed is 8192 wps
    Public Const MSGACT717_TO As UInt32 = &H2    '//Time out error bit
    Public Const MSGACT717_HIT As UInt32 = &H1   '//Always set

    '/**
    '*
    '*  Channel info fields.
    '*
    '**/

    Public Const INFO717_PARAM As UInt32 = &H1   '//Channel supports parametric control

End Module
