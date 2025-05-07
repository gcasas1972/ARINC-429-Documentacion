Imports System
Imports System.Runtime.InteropServices

Module BTI429VB

    '/**
    '*
    '*  BTI429 WIN32 DRIVER  Version 1.10.0  (06/07/2011)
    '*  Copyright (c) 2001-2011
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   BTI429NET.VB -- 32-bit
    '*                      BTI429 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  Structs used by the BTI429 Driver.
    '*
    '**/

    <StructLayout(LayoutKind.Sequential)> Public Structure MSGSTRUCT429
        Public addr As UInt32
        Public data As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MSGFIELDS429
        Public msgopt As UInt16 '//Driver writes message optionvals
        Public msgact As UInt16 '//Card writes message activity
        Public msgdata_listptr As UInt32    '//Card/User writes message data (Rcv/Xmt) - '//Driver writes list buffer pointer
        Public timetag_hitcount As UInt32   '//Card writes timetag - '//Card writes hit count
        Public maxtime_elapsetime As UInt32 '//Card writes max time - '//Card writes elapsed time
        Public mintime As UInt32    '//Card writes min time
        Public userptr As UInt32    '//Driver writes user code pointer
        Public timetagh As UInt32   '//Card writes extended timetag
        Public decgap As UInt16 '//Card writes measured decoder gap time (rsvd for xmt msg)
        Public rsvd As UInt16   '//Reserved
    End Structure

    '/**
    '*
    '*  BTI429 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the BTI429 Driver.
    '*
    '**/

    Private Class BTI429_32
        Public Declare Function BTI429_BCDGetData Lib "BTI429.DLL" Alias "_BTI429_BCDGetData@12" (ByVal msg As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        Public Declare Function BTI429_BCDGetMant Lib "BTI429.DLL" Alias "_BTI429_BCDGetMant@8" (ByVal msg As UInt32, ByVal sigdig As UInt16) As UInt32
        Public Declare Function BTI429_BCDGetSign Lib "BTI429.DLL" Alias "_BTI429_BCDGetSign@4" (ByVal msg As UInt32) As UInt16
        Public Declare Function BTI429_BCDGetSSM Lib "BTI429.DLL" Alias "_BTI429_BCDGetSSM@4" (ByVal msg As UInt32) As UInt16
        Public Declare Sub BTI429_BCDGetVal Lib "BTI429.DLL" Alias "_BTI429_BCDGetVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigdig As UInt16, ByRef resolstr As String)
        Public Declare Function BTI429_BCDPutData Lib "BTI429.DLL" Alias "_BTI429_BCDPutData@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        Public Declare Function BTI429_BCDPutMant Lib "BTI429.DLL" Alias "_BTI429_BCDPutMant@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal sigdig As UInt16, ByVal sign As UInt16) As UInt32
        Public Declare Function BTI429_BCDPutSign Lib "BTI429.DLL" Alias "_BTI429_BCDPutSign@8" (ByVal msg As UInt32, ByVal sign As UInt16) As UInt32
        Public Declare Function BTI429_BCDPutSSM Lib "BTI429.DLL" Alias "_BTI429_BCDPutSSM@8" (ByVal msg As UInt32, ByVal value As UInt16) As UInt32
        Public Declare Function BTI429_BCDPutVal Lib "BTI429.DLL" Alias "_BTI429_BCDPutVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigdig As UInt16, ByRef resolstr As String) As UInt32
        Public Declare Function BTI429_BNRGetData Lib "BTI429.DLL" Alias "_BTI429_BNRGetData@12" (ByVal msg As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        Public Declare Function BTI429_BNRGetMant Lib "BTI429.DLL" Alias "_BTI429_BNRGetMant@8" (ByVal msg As UInt32, ByVal sigbit As UInt16) As UInt32
        Public Declare Function BTI429_BNRGetSign Lib "BTI429.DLL" Alias "_BTI429_BNRGetSign@4" (ByVal msg As UInt32) As UInt16
        Public Declare Function BTI429_BNRGetSSM Lib "BTI429.DLL" Alias "_BTI429_BNRGetSSM@4" (ByVal msg As UInt32) As UInt16
        Public Declare Sub BTI429_BNRGetVal Lib "BTI429.DLL" Alias "_BTI429_BNRGetVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigbit As UInt16, ByRef resolstr As String)
        Public Declare Function BTI429_BNRPutData Lib "BTI429.DLL" Alias "_BTI429_BNRPutData@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        Public Declare Function BTI429_BNRPutMant Lib "BTI429.DLL" Alias "_BTI429_BNRPutMant@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal sigbit As UInt16, ByVal twos As UInt16) As UInt32
        Public Declare Function BTI429_BNRPutSign Lib "BTI429.DLL" Alias "_BTI429_BNRPutSign@8" (ByVal msg As UInt32, ByVal twos As UInt16) As UInt32
        Public Declare Function BTI429_BNRPutSSM Lib "BTI429.DLL" Alias "_BTI429_BNRPutSSM@8" (ByVal msg As UInt32, ByVal value As UInt16) As UInt32
        Public Declare Function BTI429_BNRPutVal Lib "BTI429.DLL" Alias "_BTI429_BNRPutVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigbit As UInt16, ByRef resolstr As String) As UInt32
        Public Declare Function BTI429_ChClear Lib "BTI429.DLL" Alias "_BTI429_ChClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChConfig Lib "BTI429.DLL" Alias "_BTI429_ChConfig@12" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_ChGetCount Lib "BTI429.DLL" Alias "_BTI429_ChGetCount@12" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_ChGetInfo Lib "BTI429.DLL" Alias "_BTI429_ChGetInfo@12" (ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ChIs429 Lib "BTI429.DLL" Alias "_BTI429_ChIs429@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChIsRcv Lib "BTI429.DLL" Alias "_BTI429_ChIsRcv@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChIsXmt Lib "BTI429.DLL" Alias "_BTI429_ChIsXmt@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_ChPause Lib "BTI429.DLL" Alias "_BTI429_ChPause@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_ChPauseCheck Lib "BTI429.DLL" Alias "_BTI429_ChPauseCheck@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_ChResume Lib "BTI429.DLL" Alias "_BTI429_ChResume@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_ChStart Lib "BTI429.DLL" Alias "_BTI429_ChStart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChStop Lib "BTI429.DLL" Alias "_BTI429_ChStop@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChSyncDefine Lib "BTI429.DLL" Alias "_BTI429_ChSyncDefine@20" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChTriggerDefine Lib "BTI429.DLL" Alias "_BTI429_ChTriggerDefine@24" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_FilterClear Lib "BTI429.DLL" Alias "_BTI429_FilterClear@8" (ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_FilterDefault Lib "BTI429.DLL" Alias "_BTI429_FilterDefault@12" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_FilterRd Lib "BTI429.DLL" Alias "_BTI429_FilterRd@16" (ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_FilterSet Lib "BTI429.DLL" Alias "_BTI429_FilterSet@20" (ByVal configval As UInt32, ByVal labelval As Int32, ByVal sdimask As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_FilterWr Lib "BTI429.DLL" Alias "_BTI429_FilterWr@20" (ByVal msgaddr As UInt32, ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_FldGetData Lib "BTI429.DLL" Alias "_BTI429_FldGetData@4" (ByVal msgval As UInt32) As UInt32
        Public Declare Function BTI429_FldGetLabel Lib "BTI429.DLL" Alias "_BTI429_FldGetLabel@4" (ByVal msgval As UInt32) As UInt16
        Public Declare Function BTI429_FldGetParity Lib "BTI429.DLL" Alias "_BTI429_FldGetParity@4" (ByVal msgval As UInt32) As UInt16
        Public Declare Function BTI429_FldGetSDI Lib "BTI429.DLL" Alias "_BTI429_FldGetSDI@4" (ByVal msgval As UInt32) As UInt16
        Public Declare Function BTI429_FldGetValue Lib "BTI429.DLL" Alias "_BTI429_FldGetValue@12" (ByVal msgval As UInt32, ByVal startbit As UInt16, ByVal endbit As UInt16) As UInt32
        Public Declare Function BTI429_FldPutData Lib "BTI429.DLL" Alias "_BTI429_FldPutData@8" (ByVal msgval As UInt32, ByVal data As UInt32) As UInt32
        Public Declare Function BTI429_FldPutLabel Lib "BTI429.DLL" Alias "_BTI429_FldPutLabel@8" (ByVal msgval As UInt32, ByVal label As UInt16) As UInt32
        Public Declare Function BTI429_FldPutSDI Lib "BTI429.DLL" Alias "_BTI429_FldPutSDI@8" (ByVal msgval As UInt32, ByVal sdi As UInt16) As UInt32
        Public Declare Function BTI429_FldPutValue Lib "BTI429.DLL" Alias "_BTI429_FldPutValue@16" (ByVal msgval As UInt32, ByVal dataval As UInt32, ByVal startbit As UInt16, ByVal endbit As UInt16) As UInt32
        Public Declare Function BTI429_ListAsyncCreate Lib "BTI429.DLL" Alias "_BTI429_ListAsyncCreate@16" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListDataRd Lib "BTI429.DLL" Alias "_BTI429_ListDataRd@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListDataWr Lib "BTI429.DLL" Alias "_BTI429_ListDataWr@12" (ByVal value As UInt32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListRcvCreate Lib "BTI429.DLL" Alias "_BTI429_ListRcvCreate@16" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListStatus Lib "BTI429.DLL" Alias "_BTI429_ListStatus@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListXmtCreate Lib "BTI429.DLL" Alias "_BTI429_ListXmtCreate@16" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgBlockRd Lib "BTI429.DLL" Alias "_BTI429_MsgBlockRd@12" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgBlockWr Lib "BTI429.DLL" Alias "_BTI429_MsgBlockWr@12" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgCreate Lib "BTI429.DLL" Alias "_BTI429_MsgCreate@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgDataRd Lib "BTI429.DLL" Alias "_BTI429_MsgDataRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTI429_MsgDataWr Lib "BTI429.DLL" Alias "_BTI429_MsgDataWr@12" (ByVal value As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTI429_MsgGroupBlockRd Lib "BTI429.DLL" Alias "_BTI429_MsgGroupBlockRd@16" (ByRef msgfields As MSGFIELDS429, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTI429_MsgGroupBlockWr Lib "BTI429.DLL" Alias "_BTI429_MsgGroupBlockWr@16" (ByRef msgfields As MSGFIELDS429, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTI429_MsgGroupRd Lib "BTI429.DLL" Alias "_BTI429_MsgGroupRd@16" (ByRef msgdataptr As UInt32, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTI429_MsgGroupWr Lib "BTI429.DLL" Alias "_BTI429_MsgGroupWr@16" (ByRef msgdataptr As UInt32, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_MsgIsAccessed Lib "BTI429.DLL" Alias "_BTI429_MsgIsAccessed@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_MsgSkipRd Lib "BTI429.DLL" Alias "_BTI429_MsgSkipRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_MsgSkipWr Lib "BTI429.DLL" Alias "_BTI429_MsgSkipWr@12" (ByVal skip As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI429_MsgSyncDefine Lib "BTI429.DLL" Alias "_BTI429_MsgSyncDefine@20" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_MsgTriggerDefine Lib "BTI429.DLL" Alias "_BTI429_MsgTriggerDefine@24" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ParamAmplitudeConfig Lib "BTI429.DLL" Alias "_BTI429_ParamAmplitudeConfig@16" (ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ParamAmplitudeGet Lib "BTI429.DLL" Alias "_BTI429_ParamAmplitudeGet@12" (ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ParamBitRateConfig Lib "BTI429.DLL" Alias "_BTI429_ParamBitRateConfig@16" (ByVal configval As UInt32, ByVal divval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ParamBitRateGet Lib "BTI429.DLL" Alias "_BTI429_ParamBitRateGet@12" (ByRef divval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBranch Lib "BTI429.DLL" Alias "_BTI429_SchedBranch@16" (ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBranchUpdate Lib "BTI429.DLL" Alias "_BTI429_SchedBranchUpdate@16" (ByVal destindex As Int32, ByVal opcodeindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBuild Lib "BTI429.DLL" Alias "_BTI429_SchedBuild@24" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedCall Lib "BTI429.DLL" Alias "_BTI429_SchedCall@16" (ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedCallUpdate Lib "BTI429.DLL" Alias "_BTI429_SchedCallUpdate@16" (ByVal destindex As Int32, ByVal opcodeindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedMode Lib "BTI429.DLL" Alias "_BTI429_SchedMode@4" (ByVal modeval As UInt32) As Int32
        Public Declare Function BTI429_SchedEntry Lib "BTI429.DLL" Alias "_BTI429_SchedEntry@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedGap Lib "BTI429.DLL" Alias "_BTI429_SchedGap@12" (ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedGapFixed Lib "BTI429.DLL" Alias "_BTI429_SchedGapFixed@12" (ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedGapList Lib "BTI429.DLL" Alias "_BTI429_SchedGapList@16" (ByVal gapval As UInt16, ByVal listaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedHalt Lib "BTI429.DLL" Alias "_BTI429_SchedHalt@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedLog Lib "BTI429.DLL" Alias "_BTI429_SchedLog@16" (ByVal condition As UInt32, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedMsg Lib "BTI429.DLL" Alias "_BTI429_SchedMsg@12" (ByVal msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedMsgEx Lib "BTI429.DLL" Alias "_BTI429_SchedMsgEx@16" (ByVal msgaddr As UInt32, ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedPause Lib "BTI429.DLL" Alias "_BTI429_SchedPause@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedPulse Lib "BTI429.DLL" Alias "_BTI429_SchedPulse@12" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedRestart Lib "BTI429.DLL" Alias "_BTI429_SchedRestart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedReturn Lib "BTI429.DLL" Alias "_BTI429_SchedReturn@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChConfigEx Lib "BTI429.DLL" Alias "_BTI429_ChConfigEx@16" (ByVal configval As UInt32, ByVal count As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdAddr Lib "BTI429.DLL" Alias "_BTI429_CmdAddr@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_CmdAlloc Lib "BTI429.DLL" Alias "_BTI429_CmdAlloc@8" (ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_CmdAllocEx Lib "BTI429.DLL" Alias "_BTI429_CmdAllocEx@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_CmdBaseRd Lib "BTI429.DLL" Alias "_BTI429_CmdBaseRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTI429_CmdBaseWr Lib "BTI429.DLL" Alias "_BTI429_CmdBaseWr@12" (ByVal addrval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdClear Lib "BTI429.DLL" Alias "_BTI429_CmdClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdCountRd Lib "BTI429.DLL" Alias "_BTI429_CmdCountRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_CmdCountWr Lib "BTI429.DLL" Alias "_BTI429_CmdCountWr@12" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdCtrlRd Lib "BTI429.DLL" Alias "_BTI429_CmdCtrlRd@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_CmdCtrlWr Lib "BTI429.DLL" Alias "_BTI429_CmdCtrlWr@16" (ByVal ctrlval As UInt16, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdCurrRd Lib "BTI429.DLL" Alias "_BTI429_CmdCurrRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_CmdCurrWr Lib "BTI429.DLL" Alias "_BTI429_CmdCurrWr@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTI429_CmdInit Lib "BTI429.DLL" Alias "_BTI429_CmdInit@8" (ByVal opcode As UInt16, ByRef block As UInt16)
        Public Declare Function BTI429_CmdInsert Lib "BTI429.DLL" Alias "_BTI429_CmdInsert@12" (ByRef block As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdMaxLoopRd Lib "BTI429.DLL" Alias "_BTI429_CmdMaxLoopRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_CmdMaxLoopWr Lib "BTI429.DLL" Alias "_BTI429_CmdMaxLoopWr@12" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdRd Lib "BTI429.DLL" Alias "_BTI429_CmdRd@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_CmdRestart Lib "BTI429.DLL" Alias "_BTI429_CmdRestart@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdShotRd Lib "BTI429.DLL" Alias "_BTI429_CmdShotRd@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdShotWr Lib "BTI429.DLL" Alias "_BTI429_CmdShotWr@16" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdSkipRd Lib "BTI429.DLL" Alias "_BTI429_CmdSkipRd@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdSkipWr Lib "BTI429.DLL" Alias "_BTI429_CmdSkipWr@16" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_CmdStackClr Lib "BTI429.DLL" Alias "_BTI429_CmdStackClr@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdStartRd Lib "BTI429.DLL" Alias "_BTI429_CmdStartRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_CmdStartWr Lib "BTI429.DLL" Alias "_BTI429_CmdStartWr@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdStepRd Lib "BTI429.DLL" Alias "_BTI429_CmdStepRd@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdStepWr Lib "BTI429.DLL" Alias "_BTI429_CmdStepWr@16" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdTotalRd Lib "BTI429.DLL" Alias "_BTI429_CmdTotalRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_CmdTotalWr Lib "BTI429.DLL" Alias "_BTI429_CmdTotalWr@12" (ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdWr Lib "BTI429.DLL" Alias "_BTI429_CmdWr@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ConvFromArinc Lib "BTI429.DLL" Alias "_BTI429_ConvFromArinc@4" (ByVal msgval As UInt32) As UInt32
        Public Declare Function BTI429_ConvToArinc Lib "BTI429.DLL" Alias "_BTI429_ConvToArinc@4" (ByVal msgval As UInt32) As UInt32
        Public Declare Function BTI429_DllUsageCount Lib "BTI429.DLL" Alias "_BTI429_DllUsageCount@0" () As Int32
        Public Declare Function BTI429_FilterAddr Lib "BTI429.DLL" Alias "_BTI429_FilterAddr@16" (ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_FilterCreate Lib "BTI429.DLL" Alias "_BTI429_FilterCreate@4" (ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_FilterFill Lib "BTI429.DLL" Alias "_BTI429_FilterFill@12" (ByVal msgaddr As UInt32, ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_FldGetParBit Lib "BTI429.DLL" Alias "_BTI429_FldGetParBit@4" (ByVal msgval As UInt32) As UInt16
        Public Declare Function BTI429_FldPutParBit Lib "BTI429.DLL" Alias "_BTI429_FldPutParBit@4" (ByVal msgval As UInt32) As UInt32
        Public Declare Sub BTI429_GetChanCount Lib "BTI429.DLL" Alias "_BTI429_GetChanCount@12" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_IsChan Lib "BTI429.DLL" Alias "_BTI429_IsChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_IsRcvChan Lib "BTI429.DLL" Alias "_BTI429_IsRcvChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_IsXmtChan Lib "BTI429.DLL" Alias "_BTI429_IsXmtChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_LabelReverse Lib "BTI429.DLL" Alias "_BTI429_LabelReverse@4" (ByVal msgval As UInt32) As UInt32
        Public Declare Function BTI429_ListAddr Lib "BTI429.DLL" Alias "_BTI429_ListAddr@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListAddrEx Lib "BTI429.DLL" Alias "_BTI429_ListAddrEx@16" (ByVal index As Int32, ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListAdvance Lib "BTI429.DLL" Alias "_BTI429_ListAdvance@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListClear Lib "BTI429.DLL" Alias "_BTI429_ListClear@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListConfig Lib "BTI429.DLL" Alias "_BTI429_ListConfig@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListConfigEx Lib "BTI429.DLL" Alias "_BTI429_ListConfigEx@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListDataBlkRd Lib "BTI429.DLL" Alias "_BTI429_ListDataBlkRd@16" (ByRef dataptr As UInt32, ByRef datacountptr As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListDataBlkWr Lib "BTI429.DLL" Alias "_BTI429_ListDataBlkWr@16" (ByRef dataptr As UInt32, ByVal datacount As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListDataRdEx Lib "BTI429.DLL" Alias "_BTI429_ListDataRdEx@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTI429_ListDataWrEx Lib "BTI429.DLL" Alias "_BTI429_ListDataWrEx@16" (ByVal value As UInt32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI429_ListInit Lib "BTI429.DLL" Alias "_BTI429_ListInit@12" (ByVal listaddr As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListNextRd Lib "BTI429.DLL" Alias "_BTI429_ListNextRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListNextWr Lib "BTI429.DLL" Alias "_BTI429_ListNextWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTI429_ListPostRd Lib "BTI429.DLL" Alias "_BTI429_ListPostRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTI429_ListPostWr Lib "BTI429.DLL" Alias "_BTI429_ListPostWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTI429_ListPreRd Lib "BTI429.DLL" Alias "_BTI429_ListPreRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTI429_ListPreWr Lib "BTI429.DLL" Alias "_BTI429_ListPreWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTI429_MsgActivityRd Lib "BTI429.DLL" Alias "_BTI429_MsgActivityRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_MsgActivityWr Lib "BTI429.DLL" Alias "_BTI429_MsgActivityWr@12" (ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI429_MsgCheck Lib "BTI429.DLL" Alias "_BTI429_MsgCheck@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTI429_MsgCommRd Lib "BTI429.DLL" Alias "_BTI429_MsgCommRd@12" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgCommWr Lib "BTI429.DLL" Alias "_BTI429_MsgCommWr@12" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgConfig Lib "BTI429.DLL" Alias "_BTI429_MsgConfig@12" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_MsgOptRd Lib "BTI429.DLL" Alias "_BTI429_MsgOptRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_MsgOptWr Lib "BTI429.DLL" Alias "_BTI429_MsgOptWr@12" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI429_MsgReset Lib "BTI429.DLL" Alias "_BTI429_MsgReset@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_Sched1Build Lib "BTI429.DLL" Alias "_BTI429_Sched1Build@40" (ByVal basevalmsgnum As Int32, ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiodin As Int32, ByRef maxperiodin As Int32, ByVal speed As Int32, ByVal microflag As Int32, ByVal channum As Int32, ByVal debugval As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_Sched2AdvanceMessage Lib "BTI429.DLL" Alias "_BTI429_Sched2AdvanceMessage@44" (ByVal entries As Int32, ByVal panicindex As Int32, ByVal nummsgs As Int32, ByVal infoptr As IntPtr, ByRef nextdeltaptr As Int32, ByVal ulmastertimer As Int32, ByRef msgaddrptr As UInt32, ByVal debugvalflag As Int32, ByVal tryflag As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_Sched2AdvanceNoMessage Lib "BTI429.DLL" Alias "_BTI429_Sched2AdvanceNoMessage@36" (ByVal nummsgs As Int32, ByVal infoptr As IntPtr, ByRef nextdeltaptr As Int32, ByVal ulmastertimer As Int32, ByRef msgaddrptr As UInt32, ByVal debugvalflag As Int32, ByVal tryflag As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_Sched2Analyze Lib "BTI429.DLL" Alias "_BTI429_Sched2Analyze@8" (ByVal nummsgs As Int32, ByVal infoptr As IntPtr)
        Public Declare Function BTI429_Sched2Build Lib "BTI429.DLL" Alias "_BTI429_Sched2Build@36" (ByVal nummsgs As Int32, ByRef msgaddrptr As UInt32, ByRef minlist As Int32, ByRef maxlist As Int32, ByVal speedflag As Int32, ByVal microflag As Int32, ByVal debugvalflag As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_Sched2BuildEx Lib "BTI429.DLL" Alias "_BTI429_Sched2BuildEx@24" (ByRef styleptr As Int32, ByVal nummsgs As Int32, ByRef minlist As Int32, ByRef maxlist As Int32, ByVal speedflag As Int32, ByVal microflag As Int32) As Int32
        Public Declare Function BTI429_Sched2BuildExx Lib "BTI429.DLL" Alias "_BTI429_Sched2BuildExx@56" (ByVal style As Int32, ByVal speedflag As Int32, ByVal microflag As Int32, ByVal debugvalflag As Int32, ByVal tryflag As Int32, ByVal nummsgs As Int32, ByRef minlist As Int32, ByRef maxlist As Int32, ByRef entriesptr As Int32, ByRef maxentriesptr As Int32, ByVal infoptr As IntPtr, ByRef msgaddrptr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedAdvance Lib "BTI429.DLL" Alias "_BTI429_SchedAdvance@4" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_SchedAgain Lib "BTI429.DLL" Alias "_BTI429_SchedAgain@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBranchEx Lib "BTI429.DLL" Alias "_BTI429_SchedBranchEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBuildEx Lib "BTI429.DLL" Alias "_BTI429_SchedBuildEx@28" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBuildExx Lib "BTI429.DLL" Alias "_BTI429_SchedBuildExx@40" (ByVal basevalmsgnum As Int32, ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBuildExxx Lib "BTI429.DLL" Alias "_BTI429_SchedBuildExxx@40" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal channum As Int32, ByVal debugval As Int32, ByVal microflag As Int32, ByVal algorithm As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedCalc Lib "BTI429.DLL" Alias "_BTI429_SchedCalc@4" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_SchedCallEx Lib "BTI429.DLL" Alias "_BTI429_SchedCallEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedCheck Lib "BTI429.DLL" Alias "_BTI429_SchedCheck@12" (ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal infoptr As IntPtr) As Int32
        Public Declare Sub BTI429_SchedCheckEnd Lib "BTI429.DLL" Alias "_BTI429_SchedCheckEnd@0" ()
        Public Declare Sub BTI429_SchedCheckMiddle Lib "BTI429.DLL" Alias "_BTI429_SchedCheckMiddle@16" (ByVal msgnum As UInt32, ByVal minlen As UInt32, ByVal midlen As UInt32, ByVal maxlen As UInt32)
        Public Declare Sub BTI429_SchedCheckReal Lib "BTI429.DLL" Alias "_BTI429_SchedCheckReal@16" (ByVal msgnum As UInt32, ByVal minlen As UInt32, ByVal midlen As UInt32, ByVal maxlen As UInt32)
        Public Declare Sub BTI429_SchedCheckStart Lib "BTI429.DLL" Alias "_BTI429_SchedCheckStart@0" ()
        Public Declare Function BTI429_SchedConflicts Lib "BTI429.DLL" Alias "_BTI429_SchedConflicts@4" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_SchedDivide Lib "BTI429.DLL" Alias "_BTI429_SchedDivide@4" (ByVal infoptr As IntPtr) As Int32
        Public Declare Function BTI429_SchedFix Lib "BTI429.DLL" Alias "_BTI429_SchedFix@4" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Sub BTI429_SchedFixEnd Lib "BTI429.DLL" Alias "_BTI429_SchedFixEnd@0" ()
        Public Declare Sub BTI429_SchedFixMiddle Lib "BTI429.DLL" Alias "_BTI429_SchedFixMiddle@4" (ByVal conflicts As UInt32)
        Public Declare Sub BTI429_SchedFixStart Lib "BTI429.DLL" Alias "_BTI429_SchedFixStart@0" ()
        Public Declare Sub BTI429_SchedHook Lib "BTI429.DLL" Alias "_BTI429_SchedHook@8" (ByVal index As Int32, ByVal ptr As IntPtr)
        Public Declare Function BTI429_SchedInsert Lib "BTI429.DLL" Alias "_BTI429_SchedInsert@28" (ByVal eventvals As UInt32, ByVal index As UInt32, ByVal msgnum As UInt32, ByRef msgaddr As UInt32, ByVal gapval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedInsert2 Lib "BTI429.DLL" Alias "_BTI429_SchedInsert2@28" (ByVal eventvals As UInt32, ByVal index As UInt32, ByVal msgnum As Int32, ByRef msgaddr As UInt32, ByVal gapval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedInsertEnd Lib "BTI429.DLL" Alias "_BTI429_SchedInsertEnd@12" (ByVal eventvals As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedInsertStart Lib "BTI429.DLL" Alias "_BTI429_SchedInsertStart@12" (ByVal eventvals As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_SchedLayout Lib "BTI429.DLL" Alias "_BTI429_SchedLayout@4" (ByVal infoptr As IntPtr)
        Public Declare Function BTI429_SchedLogEx Lib "BTI429.DLL" Alias "_BTI429_SchedLogEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedMaxval Lib "BTI429.DLL" Alias "_BTI429_SchedMaxval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
        Public Declare Function BTI429_SchedMinval Lib "BTI429.DLL" Alias "_BTI429_SchedMinval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
        Public Declare Function BTI429_SchedNop Lib "BTI429.DLL" Alias "_BTI429_SchedNop@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedParse Lib "BTI429.DLL" Alias "_BTI429_SchedParse@20" (ByVal basevalmsgnum As Int32, ByRef msgaddr As UInt32, ByVal channum As Int32, ByVal infoptr As IntPtr, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_SchedPrint Lib "BTI429.DLL" Alias "" (ByVal ParamArray list() As String)
        Public Declare Sub BTI429_SchedPrintEx Lib "BTI429.DLL" Alias "" (ByVal ParamArray list() As Int32)
        Public Declare Function BTI429_SchedPulse0 Lib "BTI429.DLL" Alias "_BTI429_SchedPulse0@12" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedPulse1 Lib "BTI429.DLL" Alias "_BTI429_SchedPulse1@12" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedReset Lib "BTI429.DLL" Alias "_BTI429_SchedReset@4" (ByVal infoptr As IntPtr) As Int32
        Public Declare Function BTI429_SchedRotate Lib "BTI429.DLL" Alias "_BTI429_SchedRotate@4" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_SchedShift Lib "BTI429.DLL" Alias "_BTI429_SchedShift@12" (ByVal msgnum As Int32, ByVal value As Int32, ByVal infoptr As IntPtr) As Int32
        Public Declare Function BTI429_SchedSlide Lib "BTI429.DLL" Alias "_BTI429_SchedSlide@4" (ByVal infoptr As IntPtr) As Int32
        Public Declare Sub BTI429_SchedSlideEnd Lib "BTI429.DLL" Alias "_BTI429_SchedSlideEnd@0" ()
        Public Declare Sub BTI429_SchedSlideMiddle Lib "BTI429.DLL" Alias "_BTI429_SchedSlideMiddle@12" (ByVal index As UInt32, ByVal count As UInt32, ByVal conflicts As UInt32)
        Public Declare Sub BTI429_SchedSlideStart Lib "BTI429.DLL" Alias "_BTI429_SchedSlideStart@4" (ByVal factor As UInt32)
        Public Declare Sub BTI429_SchedSort Lib "BTI429.DLL" Alias "_BTI429_SchedSort@4" (ByVal infoptr As IntPtr)
        Public Declare Function BTI429_SchedToBit Lib "BTI429.DLL" Alias "_BTI429_SchedToBit@8" (ByVal value As UInt32, ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_SchedToMsec Lib "BTI429.DLL" Alias "_BTI429_SchedToMsec@8" (ByVal value As UInt32, ByVal infoptr As IntPtr) As UInt32
        Public Declare Sub BTI429_SchedUnsort Lib "BTI429.DLL" Alias "_BTI429_SchedUnsort@4" (ByVal infoptr As IntPtr)
        Public Declare Function BTI429_SchedUser Lib "BTI429.DLL" Alias "_BTI429_SchedUser@12" (ByVal useraddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedWalk Lib "BTI429.DLL" Alias "_BTI429_SchedWalk@4" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_TestProtocol Lib "BTI429.DLL" Alias "_BTI429_TestProtocol@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_Transpose12 Lib "BTI429.DLL" Alias "_BTI429_Transpose12@4" (ByVal val As UInt16) As UInt16
    End Class

    Private Class BTI429_64
        Public Declare Function BTI429_BCDGetData Lib "BTI42964.DLL" Alias "BTI429_BCDGetData" (ByVal msg As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        Public Declare Function BTI429_BCDGetMant Lib "BTI42964.DLL" Alias "BTI429_BCDGetMant" (ByVal msg As UInt32, ByVal sigdig As UInt16) As UInt32
        Public Declare Function BTI429_BCDGetSign Lib "BTI42964.DLL" Alias "BTI429_BCDGetSign" (ByVal msg As UInt32) As UInt16
        Public Declare Function BTI429_BCDGetSSM Lib "BTI42964.DLL" Alias "BTI429_BCDGetSSM" (ByVal msg As UInt32) As UInt16
        Public Declare Sub BTI429_BCDGetVal Lib "BTI42964.DLL" Alias "BTI429_BCDGetVal" (ByRef buf As String, ByVal msg As UInt32, ByVal sigdig As UInt16, ByRef resolstr As String)
        Public Declare Function BTI429_BCDPutData Lib "BTI42964.DLL" Alias "BTI429_BCDPutData" (ByVal msg As UInt32, ByVal value As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        Public Declare Function BTI429_BCDPutMant Lib "BTI42964.DLL" Alias "BTI429_BCDPutMant" (ByVal msg As UInt32, ByVal value As UInt32, ByVal sigdig As UInt16, ByVal sign As UInt16) As UInt32
        Public Declare Function BTI429_BCDPutSign Lib "BTI42964.DLL" Alias "BTI429_BCDPutSign" (ByVal msg As UInt32, ByVal sign As UInt16) As UInt32
        Public Declare Function BTI429_BCDPutSSM Lib "BTI42964.DLL" Alias "BTI429_BCDPutSSM" (ByVal msg As UInt32, ByVal value As UInt16) As UInt32
        Public Declare Function BTI429_BCDPutVal Lib "BTI42964.DLL" Alias "BTI429_BCDPutVal" (ByRef buf As String, ByVal msg As UInt32, ByVal sigdig As UInt16, ByRef resolstr As String) As UInt32
        Public Declare Function BTI429_BNRGetData Lib "BTI42964.DLL" Alias "BTI429_BNRGetData" (ByVal msg As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        Public Declare Function BTI429_BNRGetMant Lib "BTI42964.DLL" Alias "BTI429_BNRGetMant" (ByVal msg As UInt32, ByVal sigbit As UInt16) As UInt32
        Public Declare Function BTI429_BNRGetSign Lib "BTI42964.DLL" Alias "BTI429_BNRGetSign" (ByVal msg As UInt32) As UInt16
        Public Declare Function BTI429_BNRGetSSM Lib "BTI42964.DLL" Alias "BTI429_BNRGetSSM" (ByVal msg As UInt32) As UInt16
        Public Declare Sub BTI429_BNRGetVal Lib "BTI42964.DLL" Alias "BTI429_BNRGetVal" (ByRef buf As String, ByVal msg As UInt32, ByVal sigbit As UInt16, ByRef resolstr As String)
        Public Declare Function BTI429_BNRPutData Lib "BTI42964.DLL" Alias "BTI429_BNRPutData" (ByVal msg As UInt32, ByVal value As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        Public Declare Function BTI429_BNRPutMant Lib "BTI42964.DLL" Alias "BTI429_BNRPutMant" (ByVal msg As UInt32, ByVal value As UInt32, ByVal sigbit As UInt16, ByVal twos As UInt16) As UInt32
        Public Declare Function BTI429_BNRPutSign Lib "BTI42964.DLL" Alias "BTI429_BNRPutSign" (ByVal msg As UInt32, ByVal twos As UInt16) As UInt32
        Public Declare Function BTI429_BNRPutSSM Lib "BTI42964.DLL" Alias "BTI429_BNRPutSSM" (ByVal msg As UInt32, ByVal value As UInt16) As UInt32
        Public Declare Function BTI429_BNRPutVal Lib "BTI42964.DLL" Alias "BTI429_BNRPutVal" (ByRef buf As String, ByVal msg As UInt32, ByVal sigbit As UInt16, ByRef resolstr As String) As UInt32
        Public Declare Function BTI429_ChClear Lib "BTI42964.DLL" Alias "BTI429_ChClear" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChConfig Lib "BTI42964.DLL" Alias "BTI429_ChConfig" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_ChGetCount Lib "BTI42964.DLL" Alias "BTI429_ChGetCount" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_ChGetInfo Lib "BTI42964.DLL" Alias "BTI429_ChGetInfo" (ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ChIs429 Lib "BTI42964.DLL" Alias "BTI429_ChIs429" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChIsRcv Lib "BTI42964.DLL" Alias "BTI429_ChIsRcv" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChIsXmt Lib "BTI42964.DLL" Alias "BTI429_ChIsXmt" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_ChPause Lib "BTI42964.DLL" Alias "BTI429_ChPause" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_ChPauseCheck Lib "BTI42964.DLL" Alias "BTI429_ChPauseCheck" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_ChResume Lib "BTI42964.DLL" Alias "BTI429_ChResume" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_ChStart Lib "BTI42964.DLL" Alias "BTI429_ChStart" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChStop Lib "BTI42964.DLL" Alias "BTI429_ChStop" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChSyncDefine Lib "BTI42964.DLL" Alias "BTI429_ChSyncDefine" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChTriggerDefine Lib "BTI42964.DLL" Alias "BTI429_ChTriggerDefine" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_FilterClear Lib "BTI42964.DLL" Alias "BTI429_FilterClear" (ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_FilterDefault Lib "BTI42964.DLL" Alias "BTI429_FilterDefault" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_FilterRd Lib "BTI42964.DLL" Alias "BTI429_FilterRd" (ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_FilterSet Lib "BTI42964.DLL" Alias "BTI429_FilterSet" (ByVal configval As UInt32, ByVal labelval As Int32, ByVal sdimask As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_FilterWr Lib "BTI42964.DLL" Alias "BTI429_FilterWr" (ByVal msgaddr As UInt32, ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_FldGetData Lib "BTI42964.DLL" Alias "BTI429_FldGetData" (ByVal msgval As UInt32) As UInt32
        Public Declare Function BTI429_FldGetLabel Lib "BTI42964.DLL" Alias "BTI429_FldGetLabel" (ByVal msgval As UInt32) As UInt16
        Public Declare Function BTI429_FldGetParity Lib "BTI42964.DLL" Alias "BTI429_FldGetParity" (ByVal msgval As UInt32) As UInt16
        Public Declare Function BTI429_FldGetSDI Lib "BTI42964.DLL" Alias "BTI429_FldGetSDI" (ByVal msgval As UInt32) As UInt16
        Public Declare Function BTI429_FldGetValue Lib "BTI42964.DLL" Alias "BTI429_FldGetValue" (ByVal msgval As UInt32, ByVal startbit As UInt16, ByVal endbit As UInt16) As UInt32
        Public Declare Function BTI429_FldPutData Lib "BTI42964.DLL" Alias "BTI429_FldPutData" (ByVal msgval As UInt32, ByVal data As UInt32) As UInt32
        Public Declare Function BTI429_FldPutLabel Lib "BTI42964.DLL" Alias "BTI429_FldPutLabel" (ByVal msgval As UInt32, ByVal label As UInt16) As UInt32
        Public Declare Function BTI429_FldPutSDI Lib "BTI42964.DLL" Alias "BTI429_FldPutSDI" (ByVal msgval As UInt32, ByVal sdi As UInt16) As UInt32
        Public Declare Function BTI429_FldPutValue Lib "BTI42964.DLL" Alias "BTI429_FldPutValue" (ByVal msgval As UInt32, ByVal dataval As UInt32, ByVal startbit As UInt16, ByVal endbit As UInt16) As UInt32
        Public Declare Function BTI429_ListAsyncCreate Lib "BTI42964.DLL" Alias "BTI429_ListAsyncCreate" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListDataRd Lib "BTI42964.DLL" Alias "BTI429_ListDataRd" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListDataWr Lib "BTI42964.DLL" Alias "BTI429_ListDataWr" (ByVal value As UInt32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListRcvCreate Lib "BTI42964.DLL" Alias "BTI429_ListRcvCreate" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListStatus Lib "BTI42964.DLL" Alias "BTI429_ListStatus" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListXmtCreate Lib "BTI42964.DLL" Alias "BTI429_ListXmtCreate" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgBlockRd Lib "BTI42964.DLL" Alias "BTI429_MsgBlockRd" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgBlockWr Lib "BTI42964.DLL" Alias "BTI429_MsgBlockWr" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgCreate Lib "BTI42964.DLL" Alias "BTI429_MsgCreate" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgDataRd Lib "BTI42964.DLL" Alias "BTI429_MsgDataRd" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTI429_MsgDataWr Lib "BTI42964.DLL" Alias "BTI429_MsgDataWr" (ByVal value As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTI429_MsgGroupBlockRd Lib "BTI42964.DLL" Alias "BTI429_MsgGroupBlockRd" (ByRef msgfields As MSGFIELDS429, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTI429_MsgGroupBlockWr Lib "BTI42964.DLL" Alias "BTI429_MsgGroupBlockWr" (ByRef msgfields As MSGFIELDS429, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTI429_MsgGroupRd Lib "BTI42964.DLL" Alias "BTI429_MsgGroupRd" (ByRef msgdataptr As UInt32, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTI429_MsgGroupWr Lib "BTI42964.DLL" Alias "BTI429_MsgGroupWr" (ByRef msgdataptr As UInt32, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_MsgIsAccessed Lib "BTI42964.DLL" Alias "BTI429_MsgIsAccessed" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_MsgSkipRd Lib "BTI42964.DLL" Alias "BTI429_MsgSkipRd" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_MsgSkipWr Lib "BTI42964.DLL" Alias "BTI429_MsgSkipWr" (ByVal skip As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI429_MsgSyncDefine Lib "BTI42964.DLL" Alias "BTI429_MsgSyncDefine" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_MsgTriggerDefine Lib "BTI42964.DLL" Alias "BTI429_MsgTriggerDefine" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ParamAmplitudeConfig Lib "BTI42964.DLL" Alias "BTI429_ParamAmplitudeConfig" (ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ParamAmplitudeGet Lib "BTI42964.DLL" Alias "BTI429_ParamAmplitudeGet" (ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ParamBitRateConfig Lib "BTI42964.DLL" Alias "BTI429_ParamBitRateConfig" (ByVal configval As UInt32, ByVal divval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ParamBitRateGet Lib "BTI42964.DLL" Alias "BTI429_ParamBitRateGet" (ByRef divval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBranch Lib "BTI42964.DLL" Alias "BTI429_SchedBranch" (ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBranchUpdate Lib "BTI42964.DLL" Alias "BTI429_SchedBranchUpdate" (ByVal destindex As Int32, ByVal opcodeindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBuild Lib "BTI42964.DLL" Alias "BTI429_SchedBuild" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedCall Lib "BTI42964.DLL" Alias "BTI429_SchedCall" (ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedCallUpdate Lib "BTI42964.DLL" Alias "BTI429_SchedCallUpdate" (ByVal destindex As Int32, ByVal opcodeindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedMode Lib "BTI42964.DLL" Alias "BTI429_SchedMode" (ByVal modeval As UInt32) As Int32
        Public Declare Function BTI429_SchedEntry Lib "BTI42964.DLL" Alias "BTI429_SchedEntry" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedGap Lib "BTI42964.DLL" Alias "BTI429_SchedGap" (ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedGapFixed Lib "BTI42964.DLL" Alias "BTI429_SchedGapFixed" (ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedGapList Lib "BTI42964.DLL" Alias "BTI429_SchedGapList" (ByVal gapval As UInt16, ByVal listaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedHalt Lib "BTI42964.DLL" Alias "BTI429_SchedHalt" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedLog Lib "BTI42964.DLL" Alias "BTI429_SchedLog" (ByVal condition As UInt32, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedMsg Lib "BTI42964.DLL" Alias "BTI429_SchedMsg" (ByVal msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedMsgEx Lib "BTI42964.DLL" Alias "BTI429_SchedMsgEx" (ByVal msgaddr As UInt32, ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedPause Lib "BTI42964.DLL" Alias "BTI429_SchedPause" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedPulse Lib "BTI42964.DLL" Alias "BTI429_SchedPulse" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedRestart Lib "BTI42964.DLL" Alias "BTI429_SchedRestart" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedReturn Lib "BTI42964.DLL" Alias "BTI429_SchedReturn" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ChConfigEx Lib "BTI42964.DLL" Alias "BTI429_ChConfigEx" (ByVal configval As UInt32, ByVal count As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdAddr Lib "BTI42964.DLL" Alias "BTI429_CmdAddr" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_CmdAlloc Lib "BTI42964.DLL" Alias "BTI429_CmdAlloc" (ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_CmdAllocEx Lib "BTI42964.DLL" Alias "BTI429_CmdAllocEx" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_CmdBaseRd Lib "BTI42964.DLL" Alias "BTI429_CmdBaseRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTI429_CmdBaseWr Lib "BTI42964.DLL" Alias "BTI429_CmdBaseWr" (ByVal addrval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdClear Lib "BTI42964.DLL" Alias "BTI429_CmdClear" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdCountRd Lib "BTI42964.DLL" Alias "BTI429_CmdCountRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_CmdCountWr Lib "BTI42964.DLL" Alias "BTI429_CmdCountWr" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdCtrlRd Lib "BTI42964.DLL" Alias "BTI429_CmdCtrlRd" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_CmdCtrlWr Lib "BTI42964.DLL" Alias "BTI429_CmdCtrlWr" (ByVal ctrlval As UInt16, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdCurrRd Lib "BTI42964.DLL" Alias "BTI429_CmdCurrRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_CmdCurrWr Lib "BTI42964.DLL" Alias "BTI429_CmdCurrWr" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTI429_CmdInit Lib "BTI42964.DLL" Alias "BTI429_CmdInit" (ByVal opcode As UInt16, ByRef block As UInt16)
        Public Declare Function BTI429_CmdInsert Lib "BTI42964.DLL" Alias "BTI429_CmdInsert" (ByRef block As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdMaxLoopRd Lib "BTI42964.DLL" Alias "BTI429_CmdMaxLoopRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_CmdMaxLoopWr Lib "BTI42964.DLL" Alias "BTI429_CmdMaxLoopWr" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdRd Lib "BTI42964.DLL" Alias "BTI429_CmdRd" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_CmdRestart Lib "BTI42964.DLL" Alias "BTI429_CmdRestart" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdShotRd Lib "BTI42964.DLL" Alias "BTI429_CmdShotRd" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdShotWr Lib "BTI42964.DLL" Alias "BTI429_CmdShotWr" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdSkipRd Lib "BTI42964.DLL" Alias "BTI429_CmdSkipRd" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdSkipWr Lib "BTI42964.DLL" Alias "BTI429_CmdSkipWr" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_CmdStackClr Lib "BTI42964.DLL" Alias "BTI429_CmdStackClr" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdStartRd Lib "BTI42964.DLL" Alias "BTI429_CmdStartRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_CmdStartWr Lib "BTI42964.DLL" Alias "BTI429_CmdStartWr" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdStepRd Lib "BTI42964.DLL" Alias "BTI429_CmdStepRd" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdStepWr Lib "BTI42964.DLL" Alias "BTI429_CmdStepWr" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_CmdTotalRd Lib "BTI42964.DLL" Alias "BTI429_CmdTotalRd" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_CmdTotalWr Lib "BTI42964.DLL" Alias "BTI429_CmdTotalWr" (ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_CmdWr Lib "BTI42964.DLL" Alias "BTI429_CmdWr" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ConvFromArinc Lib "BTI42964.DLL" Alias "BTI429_ConvFromArinc" (ByVal msgval As UInt32) As UInt32
        Public Declare Function BTI429_ConvToArinc Lib "BTI42964.DLL" Alias "BTI429_ConvToArinc" (ByVal msgval As UInt32) As UInt32
        Public Declare Function BTI429_DllUsageCount Lib "BTI42964.DLL" Alias "BTI429_DllUsageCount" () As Int32
        Public Declare Function BTI429_FilterAddr Lib "BTI42964.DLL" Alias "BTI429_FilterAddr" (ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_FilterCreate Lib "BTI42964.DLL" Alias "BTI429_FilterCreate" (ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_FilterFill Lib "BTI42964.DLL" Alias "BTI429_FilterFill" (ByVal msgaddr As UInt32, ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_FldGetParBit Lib "BTI42964.DLL" Alias "BTI429_FldGetParBit" (ByVal msgval As UInt32) As UInt16
        Public Declare Function BTI429_FldPutParBit Lib "BTI42964.DLL" Alias "BTI429_FldPutParBit" (ByVal msgval As UInt32) As UInt32
        Public Declare Sub BTI429_GetChanCount Lib "BTI42964.DLL" Alias "BTI429_GetChanCount" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI429_IsChan Lib "BTI42964.DLL" Alias "BTI429_IsChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_IsRcvChan Lib "BTI42964.DLL" Alias "BTI429_IsRcvChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_IsXmtChan Lib "BTI42964.DLL" Alias "BTI429_IsXmtChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_LabelReverse Lib "BTI42964.DLL" Alias "BTI429_LabelReverse" (ByVal msgval As UInt32) As UInt32
        Public Declare Function BTI429_ListAddr Lib "BTI42964.DLL" Alias "BTI429_ListAddr" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListAddrEx Lib "BTI42964.DLL" Alias "BTI429_ListAddrEx" (ByVal index As Int32, ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListAdvance Lib "BTI42964.DLL" Alias "BTI429_ListAdvance" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListClear Lib "BTI42964.DLL" Alias "BTI429_ListClear" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListConfig Lib "BTI42964.DLL" Alias "BTI429_ListConfig" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListConfigEx Lib "BTI42964.DLL" Alias "BTI429_ListConfigEx" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListDataBlkRd Lib "BTI42964.DLL" Alias "BTI429_ListDataBlkRd" (ByRef dataptr As UInt32, ByRef datacountptr As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListDataBlkWr Lib "BTI42964.DLL" Alias "BTI429_ListDataBlkWr" (ByRef dataptr As UInt32, ByVal datacount As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListDataRdEx Lib "BTI42964.DLL" Alias "BTI429_ListDataRdEx" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTI429_ListDataWrEx Lib "BTI42964.DLL" Alias "BTI429_ListDataWrEx" (ByVal value As UInt32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI429_ListInit Lib "BTI42964.DLL" Alias "BTI429_ListInit" (ByVal listaddr As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_ListNextRd Lib "BTI42964.DLL" Alias "BTI429_ListNextRd" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_ListNextWr Lib "BTI42964.DLL" Alias "BTI429_ListNextWr" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTI429_ListPostRd Lib "BTI42964.DLL" Alias "BTI429_ListPostRd" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTI429_ListPostWr Lib "BTI42964.DLL" Alias "BTI429_ListPostWr" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTI429_ListPreRd Lib "BTI42964.DLL" Alias "BTI429_ListPreRd" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTI429_ListPreWr Lib "BTI42964.DLL" Alias "BTI429_ListPreWr" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTI429_MsgActivityRd Lib "BTI42964.DLL" Alias "BTI429_MsgActivityRd" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_MsgActivityWr Lib "BTI42964.DLL" Alias "BTI429_MsgActivityWr" (ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI429_MsgCheck Lib "BTI42964.DLL" Alias "BTI429_MsgCheck" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTI429_MsgCommRd Lib "BTI42964.DLL" Alias "BTI429_MsgCommRd" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgCommWr Lib "BTI42964.DLL" Alias "BTI429_MsgCommWr" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_MsgConfig Lib "BTI42964.DLL" Alias "BTI429_MsgConfig" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_MsgOptRd Lib "BTI42964.DLL" Alias "BTI429_MsgOptRd" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTI429_MsgOptWr Lib "BTI42964.DLL" Alias "BTI429_MsgOptWr" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTI429_MsgReset Lib "BTI42964.DLL" Alias "BTI429_MsgReset" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI429_Sched1Build Lib "BTI42964.DLL" Alias "BTI429_Sched1Build" (ByVal basevalmsgnum As Int32, ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiodin As Int32, ByRef maxperiodin As Int32, ByVal speed As Int32, ByVal microflag As Int32, ByVal channum As Int32, ByVal debugval As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_Sched2AdvanceMessage Lib "BTI42964.DLL" Alias "BTI429_Sched2AdvanceMessage" (ByVal entries As Int32, ByVal panicindex As Int32, ByVal nummsgs As Int32, ByVal infoptr As IntPtr, ByRef nextdeltaptr As Int32, ByVal ulmastertimer As Int32, ByRef msgaddrptr As UInt32, ByVal debugvalflag As Int32, ByVal tryflag As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_Sched2AdvanceNoMessage Lib "BTI42964.DLL" Alias "BTI429_Sched2AdvanceNoMessage" (ByVal nummsgs As Int32, ByVal infoptr As IntPtr, ByRef nextdeltaptr As Int32, ByVal ulmastertimer As Int32, ByRef msgaddrptr As UInt32, ByVal debugvalflag As Int32, ByVal tryflag As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_Sched2Analyze Lib "BTI42964.DLL" Alias "BTI429_Sched2Analyze" (ByVal nummsgs As Int32, ByVal infoptr As IntPtr)
        Public Declare Function BTI429_Sched2Build Lib "BTI42964.DLL" Alias "BTI429_Sched2Build" (ByVal nummsgs As Int32, ByRef msgaddrptr As UInt32, ByRef minlist As Int32, ByRef maxlist As Int32, ByVal speedflag As Int32, ByVal microflag As Int32, ByVal debugvalflag As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_Sched2BuildEx Lib "BTI42964.DLL" Alias "BTI429_Sched2BuildEx" (ByRef styleptr As Int32, ByVal nummsgs As Int32, ByRef minlist As Int32, ByRef maxlist As Int32, ByVal speedflag As Int32, ByVal microflag As Int32) As Int32
        Public Declare Function BTI429_Sched2BuildExx Lib "BTI42964.DLL" Alias "BTI429_Sched2BuildExx" (ByVal style As Int32, ByVal speedflag As Int32, ByVal microflag As Int32, ByVal debugvalflag As Int32, ByVal tryflag As Int32, ByVal nummsgs As Int32, ByRef minlist As Int32, ByRef maxlist As Int32, ByRef entriesptr As Int32, ByRef maxentriesptr As Int32, ByVal infoptr As IntPtr, ByRef msgaddrptr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedAdvance Lib "BTI42964.DLL" Alias "BTI429_SchedAdvance" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_SchedAgain Lib "BTI42964.DLL" Alias "BTI429_SchedAgain" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBranchEx Lib "BTI42964.DLL" Alias "BTI429_SchedBranchEx" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBuildEx Lib "BTI42964.DLL" Alias "BTI429_SchedBuildEx" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBuildExx Lib "BTI42964.DLL" Alias "BTI429_SchedBuildExx" (ByVal basevalmsgnum As Int32, ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedBuildExxx Lib "BTI42964.DLL" Alias "BTI429_SchedBuildExxx" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal channum As Int32, ByVal debugval As Int32, ByVal microflag As Int32, ByVal algorithm As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedCalc Lib "BTI42964.DLL" Alias "BTI429_SchedCalc" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_SchedCallEx Lib "BTI42964.DLL" Alias "BTI429_SchedCallEx" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedCheck Lib "BTI42964.DLL" Alias "BTI429_SchedCheck" (ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal infoptr As IntPtr) As Int32
        Public Declare Sub BTI429_SchedCheckEnd Lib "BTI42964.DLL" Alias "BTI429_SchedCheckEnd" ()
        Public Declare Sub BTI429_SchedCheckMiddle Lib "BTI42964.DLL" Alias "BTI429_SchedCheckMiddle" (ByVal msgnum As UInt32, ByVal minlen As UInt32, ByVal midlen As UInt32, ByVal maxlen As UInt32)
        Public Declare Sub BTI429_SchedCheckReal Lib "BTI42964.DLL" Alias "BTI429_SchedCheckReal" (ByVal msgnum As UInt32, ByVal minlen As UInt32, ByVal midlen As UInt32, ByVal maxlen As UInt32)
        Public Declare Sub BTI429_SchedCheckStart Lib "BTI42964.DLL" Alias "BTI429_SchedCheckStart" ()
        Public Declare Function BTI429_SchedConflicts Lib "BTI42964.DLL" Alias "BTI429_SchedConflicts" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_SchedDivide Lib "BTI42964.DLL" Alias "BTI429_SchedDivide" (ByVal infoptr As IntPtr) As Int32
        Public Declare Function BTI429_SchedFix Lib "BTI42964.DLL" Alias "BTI429_SchedFix" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Sub BTI429_SchedFixEnd Lib "BTI42964.DLL" Alias "BTI429_SchedFixEnd" ()
        Public Declare Sub BTI429_SchedFixMiddle Lib "BTI42964.DLL" Alias "BTI429_SchedFixMiddle" (ByVal conflicts As UInt32)
        Public Declare Sub BTI429_SchedFixStart Lib "BTI42964.DLL" Alias "BTI429_SchedFixStart" ()
        Public Declare Sub BTI429_SchedHook Lib "BTI42964.DLL" Alias "BTI429_SchedHook" (ByVal index As Int32, ByVal ptr As IntPtr)
        Public Declare Function BTI429_SchedInsert Lib "BTI42964.DLL" Alias "BTI429_SchedInsert" (ByVal eventvals As UInt32, ByVal index As UInt32, ByVal msgnum As UInt32, ByRef msgaddr As UInt32, ByVal gapval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedInsert2 Lib "BTI42964.DLL" Alias "BTI429_SchedInsert2" (ByVal eventvals As UInt32, ByVal index As UInt32, ByVal msgnum As Int32, ByRef msgaddr As UInt32, ByVal gapval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedInsertEnd Lib "BTI42964.DLL" Alias "BTI429_SchedInsertEnd" (ByVal eventvals As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedInsertStart Lib "BTI42964.DLL" Alias "BTI429_SchedInsertStart" (ByVal eventvals As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_SchedLayout Lib "BTI42964.DLL" Alias "BTI429_SchedLayout" (ByVal infoptr As IntPtr)
        Public Declare Function BTI429_SchedLogEx Lib "BTI42964.DLL" Alias "BTI429_SchedLogEx" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedMaxval Lib "BTI42964.DLL" Alias "BTI429_SchedMaxval" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
        Public Declare Function BTI429_SchedMinval Lib "BTI42964.DLL" Alias "BTI429_SchedMinval" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
        Public Declare Function BTI429_SchedNop Lib "BTI42964.DLL" Alias "BTI429_SchedNop" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedParse Lib "BTI42964.DLL" Alias "BTI429_SchedParse" (ByVal basevalmsgnum As Int32, ByRef msgaddr As UInt32, ByVal channum As Int32, ByVal infoptr As IntPtr, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI429_SchedPrint Lib "BTI42964.DLL" Alias "" (ByVal ParamArray list() As String)
        Public Declare Sub BTI429_SchedPrintEx Lib "BTI42964.DLL" Alias "" (ByVal ParamArray list() As Int32)
        Public Declare Function BTI429_SchedPulse0 Lib "BTI42964.DLL" Alias "BTI429_SchedPulse0" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedPulse1 Lib "BTI42964.DLL" Alias "BTI429_SchedPulse1" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedReset Lib "BTI42964.DLL" Alias "BTI429_SchedReset" (ByVal infoptr As IntPtr) As Int32
        Public Declare Function BTI429_SchedRotate Lib "BTI42964.DLL" Alias "BTI429_SchedRotate" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_SchedShift Lib "BTI42964.DLL" Alias "BTI429_SchedShift" (ByVal msgnum As Int32, ByVal value As Int32, ByVal infoptr As IntPtr) As Int32
        Public Declare Function BTI429_SchedSlide Lib "BTI42964.DLL" Alias "BTI429_SchedSlide" (ByVal infoptr As IntPtr) As Int32
        Public Declare Sub BTI429_SchedSlideEnd Lib "BTI42964.DLL" Alias "BTI429_SchedSlideEnd" ()
        Public Declare Sub BTI429_SchedSlideMiddle Lib "BTI42964.DLL" Alias "BTI429_SchedSlideMiddle" (ByVal index As UInt32, ByVal count As UInt32, ByVal conflicts As UInt32)
        Public Declare Sub BTI429_SchedSlideStart Lib "BTI42964.DLL" Alias "BTI429_SchedSlideStart" (ByVal factor As UInt32)
        Public Declare Sub BTI429_SchedSort Lib "BTI42964.DLL" Alias "BTI429_SchedSort" (ByVal infoptr As IntPtr)
        Public Declare Function BTI429_SchedToBit Lib "BTI42964.DLL" Alias "BTI429_SchedToBit" (ByVal value As UInt32, ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_SchedToMsec Lib "BTI42964.DLL" Alias "BTI429_SchedToMsec" (ByVal value As UInt32, ByVal infoptr As IntPtr) As UInt32
        Public Declare Sub BTI429_SchedUnsort Lib "BTI42964.DLL" Alias "BTI429_SchedUnsort" (ByVal infoptr As IntPtr)
        Public Declare Function BTI429_SchedUser Lib "BTI42964.DLL" Alias "BTI429_SchedUser" (ByVal useraddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_SchedWalk Lib "BTI42964.DLL" Alias "BTI429_SchedWalk" (ByVal infoptr As IntPtr) As UInt32
        Public Declare Function BTI429_TestProtocol Lib "BTI42964.DLL" Alias "BTI429_TestProtocol" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTI429_Transpose12 Lib "BTI42964.DLL" Alias "BTI429_Transpose12" (ByVal val As UInt16) As UInt16
    End Class

    Public Function BTI429_BCDGetData(ByVal msg As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BCDGetData(msg, msb, lsb)
        Else
            Return BTI429_64.BTI429_BCDGetData(msg, msb, lsb)
        End If
    End Function
    Public Function BTI429_BCDGetMant(ByVal msg As UInt32, ByVal sigdig As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BCDGetMant(msg, sigdig)
        Else
            Return BTI429_64.BTI429_BCDGetMant(msg, sigdig)
        End If
    End Function
    Public Function BTI429_BCDGetSign(ByVal msg As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BCDGetSign(msg)
        Else
            Return BTI429_64.BTI429_BCDGetSign(msg)
        End If
    End Function
    Public Function BTI429_BCDGetSSM(ByVal msg As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BCDGetSSM(msg)
        Else
            Return BTI429_64.BTI429_BCDGetSSM(msg)
        End If
    End Function
    Public Sub BTI429_BCDGetVal(ByRef buf As String, ByVal msg As UInt32, ByVal sigdig As UInt16, ByRef resolstr As String)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_BCDGetVal(buf, msg, sigdig, resolstr)
        Else
            BTI429_64.BTI429_BCDGetVal(buf, msg, sigdig, resolstr)
        End If
    End Sub
    Public Function BTI429_BCDPutData(ByVal msg As UInt32, ByVal value As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BCDPutData(msg, value, msb, lsb)
        Else
            Return BTI429_64.BTI429_BCDPutData(msg, value, msb, lsb)
        End If
    End Function
    Public Function BTI429_BCDPutMant(ByVal msg As UInt32, ByVal value As UInt32, ByVal sigdig As UInt16, ByVal sign As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BCDPutMant(msg, value, sigdig, sign)
        Else
            Return BTI429_64.BTI429_BCDPutMant(msg, value, sigdig, sign)
        End If
    End Function
    Public Function BTI429_BCDPutSign(ByVal msg As UInt32, ByVal sign As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BCDPutSign(msg, sign)
        Else
            Return BTI429_64.BTI429_BCDPutSign(msg, sign)
        End If
    End Function
    Public Function BTI429_BCDPutSSM(ByVal msg As UInt32, ByVal value As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BCDPutSSM(msg, value)
        Else
            Return BTI429_64.BTI429_BCDPutSSM(msg, value)
        End If
    End Function
    Public Function BTI429_BCDPutVal(ByRef buf As String, ByVal msg As UInt32, ByVal sigdig As UInt16, ByRef resolstr As String) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BCDPutVal(buf, msg, sigdig, resolstr)
        Else
            Return BTI429_64.BTI429_BCDPutVal(buf, msg, sigdig, resolstr)
        End If
    End Function
    Public Function BTI429_BNRGetData(ByVal msg As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BNRGetData(msg, msb, lsb)
        Else
            Return BTI429_64.BTI429_BNRGetData(msg, msb, lsb)
        End If
    End Function
    Public Function BTI429_BNRGetMant(ByVal msg As UInt32, ByVal sigbit As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BNRGetMant(msg, sigbit)
        Else
            Return BTI429_64.BTI429_BNRGetMant(msg, sigbit)
        End If
    End Function
    Public Function BTI429_BNRGetSign(ByVal msg As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BNRGetSign(msg)
        Else
            Return BTI429_64.BTI429_BNRGetSign(msg)
        End If
    End Function
    Public Function BTI429_BNRGetSSM(ByVal msg As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BNRGetSSM(msg)
        Else
            Return BTI429_64.BTI429_BNRGetSSM(msg)
        End If
    End Function
    Public Sub BTI429_BNRGetVal(ByRef buf As String, ByVal msg As UInt32, ByVal sigbit As UInt16, ByRef resolstr As String)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_BNRGetVal(buf, msg, sigbit, resolstr)
        Else
            BTI429_64.BTI429_BNRGetVal(buf, msg, sigbit, resolstr)
        End If
    End Sub
    Public Function BTI429_BNRPutData(ByVal msg As UInt32, ByVal value As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BNRPutData(msg, value, msb, lsb)
        Else
            Return BTI429_64.BTI429_BNRPutData(msg, value, msb, lsb)
        End If
    End Function
    Public Function BTI429_BNRPutMant(ByVal msg As UInt32, ByVal value As UInt32, ByVal sigbit As UInt16, ByVal twos As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BNRPutMant(msg, value, sigbit, twos)
        Else
            Return BTI429_64.BTI429_BNRPutMant(msg, value, sigbit, twos)
        End If
    End Function
    Public Function BTI429_BNRPutSign(ByVal msg As UInt32, ByVal twos As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BNRPutSign(msg, twos)
        Else
            Return BTI429_64.BTI429_BNRPutSign(msg, twos)
        End If
    End Function
    Public Function BTI429_BNRPutSSM(ByVal msg As UInt32, ByVal value As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BNRPutSSM(msg, value)
        Else
            Return BTI429_64.BTI429_BNRPutSSM(msg, value)
        End If
    End Function
    Public Function BTI429_BNRPutVal(ByRef buf As String, ByVal msg As UInt32, ByVal sigbit As UInt16, ByRef resolstr As String) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_BNRPutVal(buf, msg, sigbit, resolstr)
        Else
            Return BTI429_64.BTI429_BNRPutVal(buf, msg, sigbit, resolstr)
        End If
    End Function
    Public Function BTI429_ChClear(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChClear(channum, handleval)
        Else
            Return BTI429_64.BTI429_ChClear(channum, handleval)
        End If
    End Function
    Public Function BTI429_ChConfig(ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChConfig(configval, channum, handleval)
        Else
            Return BTI429_64.BTI429_ChConfig(configval, channum, handleval)
        End If
    End Function
    Public Sub BTI429_ChGetCount(ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_ChGetCount(rcvcount, xmtcount, handleval)
        Else
            BTI429_64.BTI429_ChGetCount(rcvcount, xmtcount, handleval)
        End If
    End Sub
    Public Function BTI429_ChGetInfo(ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChGetInfo(infotype, channum, handleval)
        Else
            Return BTI429_64.BTI429_ChGetInfo(infotype, channum, handleval)
        End If
    End Function
    Public Function BTI429_ChIs429(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChIs429(channum, handleval)
        Else
            Return BTI429_64.BTI429_ChIs429(channum, handleval)
        End If
    End Function
    Public Function BTI429_ChIsRcv(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChIsRcv(channum, handleval)
        Else
            Return BTI429_64.BTI429_ChIsRcv(channum, handleval)
        End If
    End Function
    Public Function BTI429_ChIsXmt(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChIsXmt(channum, handleval)
        Else
            Return BTI429_64.BTI429_ChIsXmt(channum, handleval)
        End If
    End Function
    Public Sub BTI429_ChPause(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_ChPause(channum, handleval)
        Else
            BTI429_64.BTI429_ChPause(channum, handleval)
        End If
    End Sub
    Public Function BTI429_ChPauseCheck(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChPauseCheck(channum, handleval)
        Else
            Return BTI429_64.BTI429_ChPauseCheck(channum, handleval)
        End If
    End Function
    Public Sub BTI429_ChResume(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_ChResume(channum, handleval)
        Else
            BTI429_64.BTI429_ChResume(channum, handleval)
        End If
    End Sub
    Public Function BTI429_ChStart(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChStart(channum, handleval)
        Else
            Return BTI429_64.BTI429_ChStart(channum, handleval)
        End If
    End Function
    Public Function BTI429_ChStop(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChStop(channum, handleval)
        Else
            Return BTI429_64.BTI429_ChStop(channum, handleval)
        End If
    End Function
    Public Function BTI429_ChSyncDefine(ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval)
        Else
            Return BTI429_64.BTI429_ChSyncDefine(enableflag, syncmask, pinpolarity, channum, handleval)
        End If
    End Function
    Public Function BTI429_ChTriggerDefine(ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval)
        Else
            Return BTI429_64.BTI429_ChTriggerDefine(enableflag, trigmask, trigval, pinpolarity, channum, handleval)
        End If
    End Function
    Public Function BTI429_FilterClear(ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FilterClear(basevaladdr, handleval)
        Else
            Return BTI429_64.BTI429_FilterClear(basevaladdr, handleval)
        End If
    End Function
    Public Function BTI429_FilterDefault(ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FilterDefault(configval, channum, handleval)
        Else
            Return BTI429_64.BTI429_FilterDefault(configval, channum, handleval)
        End If
    End Function
    Public Function BTI429_FilterRd(ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FilterRd(labelval, sdival, channum, handleval)
        Else
            Return BTI429_64.BTI429_FilterRd(labelval, sdival, channum, handleval)
        End If
    End Function
    Public Function BTI429_FilterSet(ByVal configval As UInt32, ByVal labelval As Int32, ByVal sdimask As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FilterSet(configval, labelval, sdimask, channum, handleval)
        Else
            Return BTI429_64.BTI429_FilterSet(configval, labelval, sdimask, channum, handleval)
        End If
    End Function
    Public Function BTI429_FilterWr(ByVal msgaddr As UInt32, ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FilterWr(msgaddr, labelval, sdival, channum, handleval)
        Else
            Return BTI429_64.BTI429_FilterWr(msgaddr, labelval, sdival, channum, handleval)
        End If
    End Function
    Public Function BTI429_FldGetData(ByVal msgval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldGetData(msgval)
        Else
            Return BTI429_64.BTI429_FldGetData(msgval)
        End If
    End Function
    Public Function BTI429_FldGetLabel(ByVal msgval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldGetLabel(msgval)
        Else
            Return BTI429_64.BTI429_FldGetLabel(msgval)
        End If
    End Function
    Public Function BTI429_FldGetParity(ByVal msgval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldGetParity(msgval)
        Else
            Return BTI429_64.BTI429_FldGetParity(msgval)
        End If
    End Function
    Public Function BTI429_FldGetSDI(ByVal msgval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldGetSDI(msgval)
        Else
            Return BTI429_64.BTI429_FldGetSDI(msgval)
        End If
    End Function
    Public Function BTI429_FldGetValue(ByVal msgval As UInt32, ByVal startbit As UInt16, ByVal endbit As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldGetValue(msgval, startbit, endbit)
        Else
            Return BTI429_64.BTI429_FldGetValue(msgval, startbit, endbit)
        End If
    End Function
    Public Function BTI429_FldPutData(ByVal msgval As UInt32, ByVal data As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldPutData(msgval, data)
        Else
            Return BTI429_64.BTI429_FldPutData(msgval, data)
        End If
    End Function
    Public Function BTI429_FldPutLabel(ByVal msgval As UInt32, ByVal label As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldPutLabel(msgval, label)
        Else
            Return BTI429_64.BTI429_FldPutLabel(msgval, label)
        End If
    End Function
    Public Function BTI429_FldPutSDI(ByVal msgval As UInt32, ByVal sdi As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldPutSDI(msgval, sdi)
        Else
            Return BTI429_64.BTI429_FldPutSDI(msgval, sdi)
        End If
    End Function
    Public Function BTI429_FldPutValue(ByVal msgval As UInt32, ByVal dataval As UInt32, ByVal startbit As UInt16, ByVal endbit As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldPutValue(msgval, dataval, startbit, endbit)
        Else
            Return BTI429_64.BTI429_FldPutValue(msgval, dataval, startbit, endbit)
        End If
    End Function
    Public Function BTI429_ListAsyncCreate(ByVal listconfigval As UInt32, ByVal count As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListAsyncCreate(listconfigval, count, channum, handleval)
        Else
            Return BTI429_64.BTI429_ListAsyncCreate(listconfigval, count, channum, handleval)
        End If
    End Function
    Public Function BTI429_ListDataRd(ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListDataRd(listaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListDataRd(listaddr, handleval)
        End If
    End Function
    Public Function BTI429_ListDataWr(ByVal value As UInt32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListDataWr(value, listaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListDataWr(value, listaddr, handleval)
        End If
    End Function
    Public Function BTI429_ListRcvCreate(ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListRcvCreate(listconfigval, count, msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListRcvCreate(listconfigval, count, msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_ListStatus(ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListStatus(listaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListStatus(listaddr, handleval)
        End If
    End Function
    Public Function BTI429_ListXmtCreate(ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListXmtCreate(listconfigval, count, msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListXmtCreate(listconfigval, count, msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_MsgBlockRd(ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgBlockRd(msgfields, msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgBlockRd(msgfields, msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_MsgBlockWr(ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgBlockWr(msgfields, msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgBlockWr(msgfields, msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_MsgCreate(ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgCreate(configval, handleval)
        Else
            Return BTI429_64.BTI429_MsgCreate(configval, handleval)
        End If
    End Function
    Public Function BTI429_MsgDataRd(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgDataRd(msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgDataRd(msgaddr, handleval)
        End If
    End Function
    Public Sub BTI429_MsgDataWr(ByVal value As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_MsgDataWr(value, msgaddr, handleval)
        Else
            BTI429_64.BTI429_MsgDataWr(value, msgaddr, handleval)
        End If
    End Sub
    Public Sub BTI429_MsgGroupBlockRd(ByRef msgfields As MSGFIELDS429, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_MsgGroupBlockRd(msgfields, msgaddrptr, nummsgs, handleval)
        Else
            BTI429_64.BTI429_MsgGroupBlockRd(msgfields, msgaddrptr, nummsgs, handleval)
        End If
    End Sub
    Public Sub BTI429_MsgGroupBlockWr(ByRef msgfields As MSGFIELDS429, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_MsgGroupBlockWr(msgfields, msgaddrptr, nummsgs, handleval)
        Else
            BTI429_64.BTI429_MsgGroupBlockWr(msgfields, msgaddrptr, nummsgs, handleval)
        End If
    End Sub
    Public Sub BTI429_MsgGroupRd(ByRef msgdataptr As UInt32, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_MsgGroupRd(msgdataptr, msgaddrptr, nummsgs, handleval)
        Else
            BTI429_64.BTI429_MsgGroupRd(msgdataptr, msgaddrptr, nummsgs, handleval)
        End If
    End Sub
    Public Sub BTI429_MsgGroupWr(ByRef msgdataptr As UInt32, ByRef msgaddrptr As UInt32, ByVal nummsgs As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_MsgGroupWr(msgdataptr, msgaddrptr, nummsgs, handleval)
        Else
            BTI429_64.BTI429_MsgGroupWr(msgdataptr, msgaddrptr, nummsgs, handleval)
        End If
    End Sub
    Public Function BTI429_MsgIsAccessed(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgIsAccessed(msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgIsAccessed(msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_MsgSkipRd(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgSkipRd(msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgSkipRd(msgaddr, handleval)
        End If
    End Function
    Public Sub BTI429_MsgSkipWr(ByVal skip As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_MsgSkipWr(skip, msgaddr, handleval)
        Else
            BTI429_64.BTI429_MsgSkipWr(skip, msgaddr, handleval)
        End If
    End Sub
    Public Function BTI429_MsgSyncDefine(ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgSyncDefine(enableflag, syncmask, pinpolarity, msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_MsgTriggerDefine(ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal trigval As UInt16, ByVal pinpolarity As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgTriggerDefine(enableflag, trigmask, trigval, pinpolarity, msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_ParamAmplitudeConfig(ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ParamAmplitudeConfig(configval, dacval, channum, handleval)
        Else
            Return BTI429_64.BTI429_ParamAmplitudeConfig(configval, dacval, channum, handleval)
        End If
    End Function
    Public Function BTI429_ParamAmplitudeGet(ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ParamAmplitudeGet(dacval, channum, handleval)
        Else
            Return BTI429_64.BTI429_ParamAmplitudeGet(dacval, channum, handleval)
        End If
    End Function
    Public Function BTI429_ParamBitRateConfig(ByVal configval As UInt32, ByVal divval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ParamBitRateConfig(configval, divval, channum, handleval)
        Else
            Return BTI429_64.BTI429_ParamBitRateConfig(configval, divval, channum, handleval)
        End If
    End Function
    Public Function BTI429_ParamBitRateGet(ByRef divval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ParamBitRateGet(divval, channum, handleval)
        Else
            Return BTI429_64.BTI429_ParamBitRateGet(divval, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedBranch(ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedBranch(condition, destindex, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedBranch(condition, destindex, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedBranchUpdate(ByVal destindex As Int32, ByVal opcodeindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedBranchUpdate(destindex, opcodeindex, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedBranchUpdate(destindex, opcodeindex, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedBuild(ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedBuild(nummsgs, msgaddr, minperiod, maxperiod, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedBuild(nummsgs, msgaddr, minperiod, maxperiod, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedCall(ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedCall(condition, destindex, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedCall(condition, destindex, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedCallUpdate(ByVal destindex As Int32, ByVal opcodeindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedCallUpdate(destindex, opcodeindex, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedCallUpdate(destindex, opcodeindex, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedMode(ByVal modeval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedMode(modeval)
        Else
            Return BTI429_64.BTI429_SchedMode(modeval)
        End If
    End Function
    Public Function BTI429_SchedEntry(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedEntry(channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedEntry(channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedGap(ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedGap(gapval, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedGap(gapval, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedGapFixed(ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedGapFixed(gapval, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedGapFixed(gapval, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedGapList(ByVal gapval As UInt16, ByVal listaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedGapList(gapval, listaddr, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedGapList(gapval, listaddr, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedHalt(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedHalt(channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedHalt(channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedLog(ByVal condition As UInt32, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedLog(condition, tagval, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedLog(condition, tagval, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedMsg(ByVal msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedMsg(msgaddr, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedMsg(msgaddr, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedMsgEx(ByVal msgaddr As UInt32, ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedMsgEx(msgaddr, gapval, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedMsgEx(msgaddr, gapval, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedPause(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedPause(channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedPause(channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedPulse(ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedPulse(dionum, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedPulse(dionum, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedRestart(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedRestart(channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedRestart(channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedReturn(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedReturn(channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedReturn(channum, handleval)
        End If
    End Function
    Public Function BTI429_ChConfigEx(ByVal configval As UInt32, ByVal count As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ChConfigEx(configval, count, channum, handleval)
        Else
            Return BTI429_64.BTI429_ChConfigEx(configval, count, channum, handleval)
        End If
    End Function
    Public Function BTI429_CmdAddr(ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdAddr(index, channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdAddr(index, channum, handleval)
        End If
    End Function
    Public Function BTI429_CmdAlloc(ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdAlloc(count, handleval)
        Else
            Return BTI429_64.BTI429_CmdAlloc(count, handleval)
        End If
    End Function
    Public Function BTI429_CmdAllocEx(ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdAllocEx(configval, count, handleval)
        Else
            Return BTI429_64.BTI429_CmdAllocEx(configval, count, handleval)
        End If
    End Function
    Public Function BTI429_CmdBaseRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdBaseRd(channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdBaseRd(channum, handleval)
        End If
    End Function
    Public Sub BTI429_CmdBaseWr(ByVal addrval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_CmdBaseWr(addrval, channum, handleval)
        Else
            BTI429_64.BTI429_CmdBaseWr(addrval, channum, handleval)
        End If
    End Sub
    Public Function BTI429_CmdClear(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdClear(channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdClear(channum, handleval)
        End If
    End Function
    Public Function BTI429_CmdCountRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdCountRd(channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdCountRd(channum, handleval)
        End If
    End Function
    Public Sub BTI429_CmdCountWr(ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_CmdCountWr(countval, channum, handleval)
        Else
            BTI429_64.BTI429_CmdCountWr(countval, channum, handleval)
        End If
    End Sub
    Public Function BTI429_CmdCtrlRd(ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdCtrlRd(index, channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdCtrlRd(index, channum, handleval)
        End If
    End Function
    Public Sub BTI429_CmdCtrlWr(ByVal ctrlval As UInt16, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_CmdCtrlWr(ctrlval, index, channum, handleval)
        Else
            BTI429_64.BTI429_CmdCtrlWr(ctrlval, index, channum, handleval)
        End If
    End Sub
    Public Function BTI429_CmdCurrRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdCurrRd(channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdCurrRd(channum, handleval)
        End If
    End Function
    Public Sub BTI429_CmdCurrWr(ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_CmdCurrWr(addrval, channum, handleval)
        Else
            BTI429_64.BTI429_CmdCurrWr(addrval, channum, handleval)
        End If
    End Sub
    Public Sub BTI429_CmdInit(ByVal opcode As UInt16, ByRef block As UInt16)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_CmdInit(opcode, block)
        Else
            BTI429_64.BTI429_CmdInit(opcode, block)
        End If
    End Sub
    Public Function BTI429_CmdInsert(ByRef block As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdInsert(block, channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdInsert(block, channum, handleval)
        End If
    End Function
    Public Function BTI429_CmdMaxLoopRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdMaxLoopRd(channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdMaxLoopRd(channum, handleval)
        End If
    End Function
    Public Sub BTI429_CmdMaxLoopWr(ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_CmdMaxLoopWr(countval, channum, handleval)
        Else
            BTI429_64.BTI429_CmdMaxLoopWr(countval, channum, handleval)
        End If
    End Sub
    Public Function BTI429_CmdRd(ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdRd(block, addrval, handleval)
        Else
            Return BTI429_64.BTI429_CmdRd(block, addrval, handleval)
        End If
    End Function
    Public Sub BTI429_CmdRestart(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_CmdRestart(channum, handleval)
        Else
            BTI429_64.BTI429_CmdRestart(channum, handleval)
        End If
    End Sub
    Public Function BTI429_CmdShotRd(ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdShotRd(index, channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdShotRd(index, channum, handleval)
        End If
    End Function
    Public Function BTI429_CmdShotWr(ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdShotWr(value, index, channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdShotWr(value, index, channum, handleval)
        End If
    End Function
    Public Function BTI429_CmdSkipRd(ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdSkipRd(index, channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdSkipRd(index, channum, handleval)
        End If
    End Function
    Public Function BTI429_CmdSkipWr(ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdSkipWr(value, index, channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdSkipWr(value, index, channum, handleval)
        End If
    End Function
    Public Sub BTI429_CmdStackClr(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_CmdStackClr(channum, handleval)
        Else
            BTI429_64.BTI429_CmdStackClr(channum, handleval)
        End If
    End Sub
    Public Function BTI429_CmdStartRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdStartRd(channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdStartRd(channum, handleval)
        End If
    End Function
    Public Sub BTI429_CmdStartWr(ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_CmdStartWr(addrval, channum, handleval)
        Else
            BTI429_64.BTI429_CmdStartWr(addrval, channum, handleval)
        End If
    End Sub
    Public Function BTI429_CmdStepRd(ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdStepRd(index, channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdStepRd(index, channum, handleval)
        End If
    End Function
    Public Function BTI429_CmdStepWr(ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdStepWr(value, index, channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdStepWr(value, index, channum, handleval)
        End If
    End Function
    Public Function BTI429_CmdTotalRd(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdTotalRd(channum, handleval)
        Else
            Return BTI429_64.BTI429_CmdTotalRd(channum, handleval)
        End If
    End Function
    Public Sub BTI429_CmdTotalWr(ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_CmdTotalWr(countval, channum, handleval)
        Else
            BTI429_64.BTI429_CmdTotalWr(countval, channum, handleval)
        End If
    End Sub
    Public Function BTI429_CmdWr(ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_CmdWr(block, addrval, handleval)
        Else
            Return BTI429_64.BTI429_CmdWr(block, addrval, handleval)
        End If
    End Function
    Public Function BTI429_ConvFromArinc(ByVal msgval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ConvFromArinc(msgval)
        Else
            Return BTI429_64.BTI429_ConvFromArinc(msgval)
        End If
    End Function
    Public Function BTI429_ConvToArinc(ByVal msgval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ConvToArinc(msgval)
        Else
            Return BTI429_64.BTI429_ConvToArinc(msgval)
        End If
    End Function
    Public Function BTI429_DllUsageCount() As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_DllUsageCount
        Else
            Return BTI429_64.BTI429_DllUsageCount
        End If
    End Function
    Public Function BTI429_FilterAddr(ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FilterAddr(labelval, sdival, channum, handleval)
        Else
            Return BTI429_64.BTI429_FilterAddr(labelval, sdival, channum, handleval)
        End If
    End Function
    Public Function BTI429_FilterCreate(ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FilterCreate(handleval)
        Else
            Return BTI429_64.BTI429_FilterCreate(handleval)
        End If
    End Function
    Public Function BTI429_FilterFill(ByVal msgaddr As UInt32, ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FilterFill(msgaddr, basevaladdr, handleval)
        Else
            Return BTI429_64.BTI429_FilterFill(msgaddr, basevaladdr, handleval)
        End If
    End Function
    Public Function BTI429_FldGetParBit(ByVal msgval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldGetParBit(msgval)
        Else
            Return BTI429_64.BTI429_FldGetParBit(msgval)
        End If
    End Function
    Public Function BTI429_FldPutParBit(ByVal msgval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_FldPutParBit(msgval)
        Else
            Return BTI429_64.BTI429_FldPutParBit(msgval)
        End If
    End Function
    Public Sub BTI429_GetChanCount(ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_GetChanCount(rcvcount, xmtcount, handleval)
        Else
            BTI429_64.BTI429_GetChanCount(rcvcount, xmtcount, handleval)
        End If
    End Sub
    Public Function BTI429_IsChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_IsChan(channum, handleval)
        Else
            Return BTI429_64.BTI429_IsChan(channum, handleval)
        End If
    End Function
    Public Function BTI429_IsRcvChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_IsRcvChan(channum, handleval)
        Else
            Return BTI429_64.BTI429_IsRcvChan(channum, handleval)
        End If
    End Function
    Public Function BTI429_IsXmtChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_IsXmtChan(channum, handleval)
        Else
            Return BTI429_64.BTI429_IsXmtChan(channum, handleval)
        End If
    End Function
    Public Function BTI429_LabelReverse(ByVal msgval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_LabelReverse(msgval)
        Else
            Return BTI429_64.BTI429_LabelReverse(msgval)
        End If
    End Function
    Public Function BTI429_ListAddr(ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListAddr(index, listaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListAddr(index, listaddr, handleval)
        End If
    End Function
    Public Function BTI429_ListAddrEx(ByVal index As Int32, ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListAddrEx(index, listaddr, header, handleval)
        Else
            Return BTI429_64.BTI429_ListAddrEx(index, listaddr, header, handleval)
        End If
    End Function
    Public Function BTI429_ListAdvance(ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListAdvance(listaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListAdvance(listaddr, handleval)
        End If
    End Function
    Public Function BTI429_ListClear(ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListClear(listaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListClear(listaddr, handleval)
        End If
    End Function
    Public Function BTI429_ListConfig(ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListConfig(configval, count, handleval)
        Else
            Return BTI429_64.BTI429_ListConfig(configval, count, handleval)
        End If
    End Function
    Public Function BTI429_ListConfigEx(ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListConfigEx(configval, count, handleval)
        Else
            Return BTI429_64.BTI429_ListConfigEx(configval, count, handleval)
        End If
    End Function
    Public Function BTI429_ListDataBlkRd(ByRef dataptr As UInt32, ByRef datacountptr As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListDataBlkRd(dataptr, datacountptr, listaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListDataBlkRd(dataptr, datacountptr, listaddr, handleval)
        End If
    End Function
    Public Function BTI429_ListDataBlkWr(ByRef dataptr As UInt32, ByVal datacount As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListDataBlkWr(dataptr, datacount, listaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListDataBlkWr(dataptr, datacount, listaddr, handleval)
        End If
    End Function
    Public Function BTI429_ListDataRdEx(ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListDataRdEx(index, listaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListDataRdEx(index, listaddr, handleval)
        End If
    End Function
    Public Sub BTI429_ListDataWrEx(ByVal value As UInt32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_ListDataWrEx(value, index, listaddr, handleval)
        Else
            BTI429_64.BTI429_ListDataWrEx(value, index, listaddr, handleval)
        End If
    End Sub
    Public Function BTI429_ListInit(ByVal listaddr As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListInit(listaddr, msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_ListInit(listaddr, msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_ListNextRd(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListNextRd(listaddr, header, handleval)
        Else
            Return BTI429_64.BTI429_ListNextRd(listaddr, header, handleval)
        End If
    End Function
    Public Function BTI429_ListNextWr(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_ListNextWr(listaddr, header, handleval)
        Else
            Return BTI429_64.BTI429_ListNextWr(listaddr, header, handleval)
        End If
    End Function
    Public Sub BTI429_ListPostRd(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_ListPostRd(listaddr, header, handleval)
        Else
            BTI429_64.BTI429_ListPostRd(listaddr, header, handleval)
        End If
    End Sub
    Public Sub BTI429_ListPostWr(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_ListPostWr(listaddr, header, handleval)
        Else
            BTI429_64.BTI429_ListPostWr(listaddr, header, handleval)
        End If
    End Sub
    Public Sub BTI429_ListPreRd(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_ListPreRd(listaddr, header, handleval)
        Else
            BTI429_64.BTI429_ListPreRd(listaddr, header, handleval)
        End If
    End Sub
    Public Sub BTI429_ListPreWr(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_ListPreWr(listaddr, header, handleval)
        Else
            BTI429_64.BTI429_ListPreWr(listaddr, header, handleval)
        End If
    End Sub
    Public Function BTI429_MsgActivityRd(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgActivityRd(msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgActivityRd(msgaddr, handleval)
        End If
    End Function
    Public Sub BTI429_MsgActivityWr(ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_MsgActivityWr(value, msgaddr, handleval)
        Else
            BTI429_64.BTI429_MsgActivityWr(value, msgaddr, handleval)
        End If
    End Sub
    Public Function BTI429_MsgCheck(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgCheck(msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgCheck(msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_MsgCommRd(ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgCommRd(msgfields, msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgCommRd(msgfields, msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_MsgCommWr(ByRef msgfields As MSGFIELDS429, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgCommWr(msgfields, msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgCommWr(msgfields, msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_MsgConfig(ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgConfig(configval, msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgConfig(configval, msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_MsgOptRd(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgOptRd(msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgOptRd(msgaddr, handleval)
        End If
    End Function
    Public Sub BTI429_MsgOptWr(ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_MsgOptWr(msgopt, msgaddr, handleval)
        Else
            BTI429_64.BTI429_MsgOptWr(msgopt, msgaddr, handleval)
        End If
    End Sub
    Public Function BTI429_MsgReset(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_MsgReset(msgaddr, handleval)
        Else
            Return BTI429_64.BTI429_MsgReset(msgaddr, handleval)
        End If
    End Function
    Public Function BTI429_Sched1Build(ByVal basevalmsgnum As Int32, ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiodin As Int32, ByRef maxperiodin As Int32, ByVal speed As Int32, ByVal microflag As Int32, ByVal channum As Int32, ByVal debugval As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_Sched1Build(basevalmsgnum, nummsgs, msgaddr, minperiodin, maxperiodin, speed, microflag, channum, debugval, handleval)
        Else
            Return BTI429_64.BTI429_Sched1Build(basevalmsgnum, nummsgs, msgaddr, minperiodin, maxperiodin, speed, microflag, channum, debugval, handleval)
        End If
    End Function
    Public Function BTI429_Sched2AdvanceMessage(ByVal entries As Int32, ByVal panicindex As Int32, ByVal nummsgs As Int32, ByVal infoptr As IntPtr, ByRef nextdeltaptr As Int32, ByVal ulmastertimer As Int32, ByRef msgaddrptr As UInt32, ByVal debugvalflag As Int32, ByVal tryflag As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_Sched2AdvanceMessage(entries, panicindex, nummsgs, infoptr, nextdeltaptr, ulmastertimer, msgaddrptr, debugvalflag, tryflag, channum, handleval)
        Else
            Return BTI429_64.BTI429_Sched2AdvanceMessage(entries, panicindex, nummsgs, infoptr, nextdeltaptr, ulmastertimer, msgaddrptr, debugvalflag, tryflag, channum, handleval)
        End If
    End Function
    Public Function BTI429_Sched2AdvanceNoMessage(ByVal nummsgs As Int32, ByVal infoptr As IntPtr, ByRef nextdeltaptr As Int32, ByVal ulmastertimer As Int32, ByRef msgaddrptr As UInt32, ByVal debugvalflag As Int32, ByVal tryflag As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_Sched2AdvanceNoMessage(nummsgs, infoptr, nextdeltaptr, ulmastertimer, msgaddrptr, debugvalflag, tryflag, channum, handleval)
        Else
            Return BTI429_64.BTI429_Sched2AdvanceNoMessage(nummsgs, infoptr, nextdeltaptr, ulmastertimer, msgaddrptr, debugvalflag, tryflag, channum, handleval)
        End If
    End Function
    Public Sub BTI429_Sched2Analyze(ByVal nummsgs As Int32, ByVal infoptr As IntPtr)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_Sched2Analyze(nummsgs, infoptr)
        Else
            BTI429_64.BTI429_Sched2Analyze(nummsgs, infoptr)
        End If
    End Sub
    Public Function BTI429_Sched2Build(ByVal nummsgs As Int32, ByRef msgaddrptr As UInt32, ByRef minlist As Int32, ByRef maxlist As Int32, ByVal speedflag As Int32, ByVal microflag As Int32, ByVal debugvalflag As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_Sched2Build(nummsgs, msgaddrptr, minlist, maxlist, speedflag, microflag, debugvalflag, channum, handleval)
        Else
            Return BTI429_64.BTI429_Sched2Build(nummsgs, msgaddrptr, minlist, maxlist, speedflag, microflag, debugvalflag, channum, handleval)
        End If
    End Function
    Public Function BTI429_Sched2BuildEx(ByRef styleptr As Int32, ByVal nummsgs As Int32, ByRef minlist As Int32, ByRef maxlist As Int32, ByVal speedflag As Int32, ByVal microflag As Int32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_Sched2BuildEx(styleptr, nummsgs, minlist, maxlist, speedflag, microflag)
        Else
            Return BTI429_64.BTI429_Sched2BuildEx(styleptr, nummsgs, minlist, maxlist, speedflag, microflag)
        End If
    End Function
    Public Function BTI429_Sched2BuildExx(ByVal style As Int32, ByVal speedflag As Int32, ByVal microflag As Int32, ByVal debugvalflag As Int32, ByVal tryflag As Int32, ByVal nummsgs As Int32, ByRef minlist As Int32, ByRef maxlist As Int32, ByRef entriesptr As Int32, ByRef maxentriesptr As Int32, ByVal infoptr As IntPtr, ByRef msgaddrptr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_Sched2BuildExx(style, speedflag, microflag, debugvalflag, tryflag, nummsgs, minlist, maxlist, entriesptr, maxentriesptr, infoptr, msgaddrptr, channum, handleval)
        Else
            Return BTI429_64.BTI429_Sched2BuildExx(style, speedflag, microflag, debugvalflag, tryflag, nummsgs, minlist, maxlist, entriesptr, maxentriesptr, infoptr, msgaddrptr, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedAdvance(ByVal infoptr As IntPtr) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedAdvance(infoptr)
        Else
            Return BTI429_64.BTI429_SchedAdvance(infoptr)
        End If
    End Function
    Public Function BTI429_SchedAgain(ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedAgain(index, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedAgain(index, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedBranchEx(ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedBranchEx(condition1, condition2, destindex, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedBranchEx(condition1, condition2, destindex, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedBuildEx(ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedBuildEx(nummsgs, msgaddr, minperiod, maxperiod, speed, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedBuildEx(nummsgs, msgaddr, minperiod, maxperiod, speed, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedBuildExx(ByVal basevalmsgnum As Int32, ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedBuildExx(basevalmsgnum, nummsgs, msgaddr, minperiod, maxperiod, speed, buf, bufsize, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedBuildExx(basevalmsgnum, nummsgs, msgaddr, minperiod, maxperiod, speed, buf, bufsize, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedBuildExxx(ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal channum As Int32, ByVal debugval As Int32, ByVal microflag As Int32, ByVal algorithm As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedBuildExxx(nummsgs, msgaddr, minperiod, maxperiod, speed, channum, debugval, microflag, algorithm, handleval)
        Else
            Return BTI429_64.BTI429_SchedBuildExxx(nummsgs, msgaddr, minperiod, maxperiod, speed, channum, debugval, microflag, algorithm, handleval)
        End If
    End Function
    Public Function BTI429_SchedCalc(ByVal infoptr As IntPtr) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedCalc(infoptr)
        Else
            Return BTI429_64.BTI429_SchedCalc(infoptr)
        End If
    End Function
    Public Function BTI429_SchedCallEx(ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedCallEx(condition1, condition2, destindex, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedCallEx(condition1, condition2, destindex, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedCheck(ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal infoptr As IntPtr) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedCheck(minperiod, maxperiod, infoptr)
        Else
            Return BTI429_64.BTI429_SchedCheck(minperiod, maxperiod, infoptr)
        End If
    End Function
    Public Sub BTI429_SchedCheckEnd()
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedCheckEnd()
        Else
            BTI429_64.BTI429_SchedCheckEnd()
        End If
    End Sub
    Public Sub BTI429_SchedCheckMiddle(ByVal msgnum As UInt32, ByVal minlen As UInt32, ByVal midlen As UInt32, ByVal maxlen As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedCheckMiddle(msgnum, minlen, midlen, maxlen)
        Else
            BTI429_64.BTI429_SchedCheckMiddle(msgnum, minlen, midlen, maxlen)
        End If
    End Sub
    Public Sub BTI429_SchedCheckReal(ByVal msgnum As UInt32, ByVal minlen As UInt32, ByVal midlen As UInt32, ByVal maxlen As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedCheckReal(msgnum, minlen, midlen, maxlen)
        Else
            BTI429_64.BTI429_SchedCheckReal(msgnum, minlen, midlen, maxlen)
        End If
    End Sub
    Public Sub BTI429_SchedCheckStart()
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedCheckStart()
        Else
            BTI429_64.BTI429_SchedCheckStart()
        End If
    End Sub
    Public Function BTI429_SchedConflicts(ByVal infoptr As IntPtr) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedConflicts(infoptr)
        Else
            Return BTI429_64.BTI429_SchedConflicts(infoptr)
        End If
    End Function
    Public Function BTI429_SchedDivide(ByVal infoptr As IntPtr) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedDivide(infoptr)
        Else
            Return BTI429_64.BTI429_SchedDivide(infoptr)
        End If
    End Function
    Public Function BTI429_SchedFix(ByVal infoptr As IntPtr) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedFix(infoptr)
        Else
            Return BTI429_64.BTI429_SchedFix(infoptr)
        End If
    End Function
    Public Sub BTI429_SchedFixEnd()
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedFixEnd()
        Else
            BTI429_64.BTI429_SchedFixEnd()
        End If
    End Sub
    Public Sub BTI429_SchedFixMiddle(ByVal conflicts As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedFixMiddle(conflicts)
        Else
            BTI429_64.BTI429_SchedFixMiddle(conflicts)
        End If
    End Sub
    Public Sub BTI429_SchedFixStart()
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedFixStart()
        Else
            BTI429_64.BTI429_SchedFixStart()
        End If
    End Sub
    Public Sub BTI429_SchedHook(ByVal index As Int32, ByVal ptr As IntPtr)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedHook(index, ptr)
        Else
            BTI429_64.BTI429_SchedHook(index, ptr)
        End If
    End Sub
    Public Function BTI429_SchedInsert(ByVal eventvals As UInt32, ByVal index As UInt32, ByVal msgnum As UInt32, ByRef msgaddr As UInt32, ByVal gapval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedInsert(eventvals, index, msgnum, msgaddr, gapval, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedInsert(eventvals, index, msgnum, msgaddr, gapval, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedInsert2(ByVal eventvals As UInt32, ByVal index As UInt32, ByVal msgnum As Int32, ByRef msgaddr As UInt32, ByVal gapval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedInsert2(eventvals, index, msgnum, msgaddr, gapval, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedInsert2(eventvals, index, msgnum, msgaddr, gapval, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedInsertEnd(ByVal eventvals As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedInsertEnd(eventvals, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedInsertEnd(eventvals, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedInsertStart(ByVal eventvals As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedInsertStart(eventvals, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedInsertStart(eventvals, channum, handleval)
        End If
    End Function
    Public Sub BTI429_SchedLayout(ByVal infoptr As IntPtr)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedLayout(infoptr)
        Else
            BTI429_64.BTI429_SchedLayout(infoptr)
        End If
    End Sub
    Public Function BTI429_SchedLogEx(ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedLogEx(condition1, condition2, tagval, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedLogEx(condition1, condition2, tagval, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedMaxval(ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedMaxval(arrayval, arrayvalcount)
        Else
            Return BTI429_64.BTI429_SchedMaxval(arrayval, arrayvalcount)
        End If
    End Function
    Public Function BTI429_SchedMinval(ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedMinval(arrayval, arrayvalcount)
        Else
            Return BTI429_64.BTI429_SchedMinval(arrayval, arrayvalcount)
        End If
    End Function
    Public Function BTI429_SchedNop(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedNop(channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedNop(channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedParse(ByVal basevalmsgnum As Int32, ByRef msgaddr As UInt32, ByVal channum As Int32, ByVal infoptr As IntPtr, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedParse(basevalmsgnum, msgaddr, channum, infoptr, handleval)
        Else
            Return BTI429_64.BTI429_SchedParse(basevalmsgnum, msgaddr, channum, infoptr, handleval)
        End If
    End Function
    Public Sub BTI429_SchedPrint(ByVal ParamArray list() As String)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedPrint(list)
        Else
            BTI429_64.BTI429_SchedPrint(list)
        End If
    End Sub
    Public Sub BTI429_SchedPrintEx(ByVal ParamArray list() As Int32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedPrintEx(list)
        Else
            BTI429_64.BTI429_SchedPrintEx(list)
        End If
    End Sub
    Public Function BTI429_SchedPulse0(ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedPulse0(dionum, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedPulse0(dionum, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedPulse1(ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedPulse1(dionum, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedPulse1(dionum, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedReset(ByVal infoptr As IntPtr) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedReset(infoptr)
        Else
            Return BTI429_64.BTI429_SchedReset(infoptr)
        End If
    End Function
    Public Function BTI429_SchedRotate(ByVal infoptr As IntPtr) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedRotate(infoptr)
        Else
            Return BTI429_64.BTI429_SchedRotate(infoptr)
        End If
    End Function
    Public Function BTI429_SchedShift(ByVal msgnum As Int32, ByVal value As Int32, ByVal infoptr As IntPtr) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedShift(msgnum, value, infoptr)
        Else
            Return BTI429_64.BTI429_SchedShift(msgnum, value, infoptr)
        End If
    End Function
    Public Function BTI429_SchedSlide(ByVal infoptr As IntPtr) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedSlide(infoptr)
        Else
            Return BTI429_64.BTI429_SchedSlide(infoptr)
        End If
    End Function
    Public Sub BTI429_SchedSlideEnd()
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedSlideEnd()
        Else
            BTI429_64.BTI429_SchedSlideEnd()
        End If
    End Sub
    Public Sub BTI429_SchedSlideMiddle(ByVal index As UInt32, ByVal count As UInt32, ByVal conflicts As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedSlideMiddle(index, count, conflicts)
        Else
            BTI429_64.BTI429_SchedSlideMiddle(index, count, conflicts)
        End If
    End Sub
    Public Sub BTI429_SchedSlideStart(ByVal factor As UInt32)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedSlideStart(factor)
        Else
            BTI429_64.BTI429_SchedSlideStart(factor)
        End If
    End Sub
    Public Sub BTI429_SchedSort(ByVal infoptr As IntPtr)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedSort(infoptr)
        Else
            BTI429_64.BTI429_SchedSort(infoptr)
        End If
    End Sub
    Public Function BTI429_SchedToBit(ByVal value As UInt32, ByVal infoptr As IntPtr) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedToBit(value, infoptr)
        Else
            Return BTI429_64.BTI429_SchedToBit(value, infoptr)
        End If
    End Function
    Public Function BTI429_SchedToMsec(ByVal value As UInt32, ByVal infoptr As IntPtr) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedToMsec(value, infoptr)
        Else
            Return BTI429_64.BTI429_SchedToMsec(value, infoptr)
        End If
    End Function
    Public Sub BTI429_SchedUnsort(ByVal infoptr As IntPtr)
        If (IntPtr.Size = 4) Then
            BTI429_32.BTI429_SchedUnsort(infoptr)
        Else
            BTI429_64.BTI429_SchedUnsort(infoptr)
        End If
    End Sub
    Public Function BTI429_SchedUser(ByVal useraddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedUser(useraddr, channum, handleval)
        Else
            Return BTI429_64.BTI429_SchedUser(useraddr, channum, handleval)
        End If
    End Function
    Public Function BTI429_SchedWalk(ByVal infoptr As IntPtr) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_SchedWalk(infoptr)
        Else
            Return BTI429_64.BTI429_SchedWalk(infoptr)
        End If
    End Function
    Public Function BTI429_TestProtocol(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_TestProtocol(handleval)
        Else
            Return BTI429_64.BTI429_TestProtocol(handleval)
        End If
    End Function
    Public Function BTI429_Transpose12(ByVal val As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTI429_32.BTI429_Transpose12(val)
        Else
            Return BTI429_64.BTI429_Transpose12(val)
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
    '*  SDI selection constants
    '*
    '**/

    Public Const SDI00 As UInt32 = &H1   '//Enable SDI00
    Public Const SDI01 As UInt32 = &H2   '//Enable SDI01
    Public Const SDI10 As UInt32 = &H4   '//Enable SDI10
    Public Const SDI11 As UInt32 = &H8   '//Enable SDI11
    Public Const SDIALL As UInt32 = &HF  '//Enable all SDIs

    '/**
    '*
    '*  Channel configuration options
    '*
    '**/

    Public Const CHCFG429_DEFAULT As UInt32 = &H0    '//Select all default settings (XMT & RCV) (default)
    Public Const CHCFG429_HIGHSPEED As UInt32 = &H1  '//Select high speed (XMT & RCV)
    Public Const CHCFG429_AUTOSPEED As UInt32 = &H2  '//Select auto speed detection (RCV)
    Public Const CHCFG429_LOWSPEED As UInt32 = &H0   '//Select low speed (XMT & RCV) (default)
    Public Const CHCFG429_SELFTEST As UInt32 = &H4   '//Enable internal wraparound (XMT & RCV)
    Public Const CHCFG429_SELFTESTOFF As UInt32 = &H0    '//Disable internal wraparound (XMT & RCV) (default)
    Public Const CHCFG429_SYNC As UInt32 = &H8   '//Sync Enable (XMT & RCV)
    Public Const CHCFG429_SYNCOFF As UInt32 = &H0    '//Disable sync output (XMT & RCV) (default)
    Public Const CHCFG429_PARODD As UInt32 = &H0 '//Parity odd (XMT & RCV) (default)
    Public Const CHCFG429_PAREVEN As UInt32 = &H10    '//Parity even (XMT & RCV)
    Public Const CHCFG429_PARDATA As UInt32 = &H20    '//Parity bit as data (XMT & RCV)
    Public Const CHCFG429_ACTIVE As UInt32 = &H0 '//Enable channel activity (XMT & RCV) (default)
    Public Const CHCFG429_INACTIVE As UInt32 = &H40   '//Disable channel activity (XMT & RCV)
    Public Const CHCFG429_EXTTRIG As UInt32 = &H80    '//Enable external trigger for all messages (XMT)
    Public Const CHCFG429_EXTOFF As UInt32 = &H0 '//External trigger is enabled on message level (XMT) (default)
    Public Const CHCFG429_PARERR As UInt32 = &H100 '//Enable parity error for all messages (XMT)
    Public Const CHCFG429_NOERR As UInt32 = &H0  '//Errors are enabled on message level (XMT) (default)
    Public Const CHCFG429_HIT As UInt32 = &H200    '//Hit counter is enabled for all messages
    Public Const CHCFG429_NOHIT As UInt32 = &H0  '//Hit counter is enabled on message level (default)
    Public Const CHCFG429_TIMETAG As UInt32 = &H400    '//Enable time-tag for all message records
    Public Const CHCFG429_TIMETAGOFF As UInt32 = &H0 '//Time-tag is enabled on message level (default)
    Public Const CHCFG429_ELAPSE As UInt32 = &H800 '//Enable elapse time for all messages
    Public Const CHCFG429_ELAPSEOFF As UInt32 = &H0  '//Elapse time is enabled on message level (default)
    Public Const CHCFG429_MAX As UInt32 = &H1000    '//Enable max repetition rate monitoring for all messages
    Public Const CHCFG429_MIN As UInt32 = &H2000    '//Enable min repetition rate monitoring for all messages
    Public Const CHCFG429_MAXMIN As UInt32 = &H3000 '//Enable max and min repetition rate monitoring for all messages
    Public Const CHCFG429_MAXMINOFF As UInt32 = &H0  '//Repetition rate monitoring is enabled on message level (default)
    Public Const CHCFG429_SEQALL As UInt32 = &H80000 '//Record entire channel in sequential record
    Public Const CHCFG429_SEQSEL As UInt32 = &H0 '//Sequential record recording is enabled at message level (default)
    Public Const CHCFG429_LOOPMAX As UInt32 = &H100000    '//Enable schedule maximum loop count
    Public Const CHCFG429_NOLOOPMAX As UInt32 = &H0  '//Disable schedule maximum loop count (default)
    Public Const CHCFG429_LOGHALT As UInt32 = &H200000    '//Enable event log on schedule halt
    Public Const CHCFG429_NOLOGHALT As UInt32 = &H0  '//No event log on schedule halt (default)
    Public Const CHCFG429_LOGPAUSE As UInt32 = &H400000   '//Enable event log on schedule pause
    Public Const CHCFG429_NOLOGPAUSE As UInt32 = &H0 '//No event log on schedule pause (default)
    Public Const CHCFG429_LOGERR As UInt32 = &H800000 '//Enable event log on decoder errors.
    Public Const CHCFG429_NOLOGERR As UInt32 = &H0   '//No event log on decoder errors (default)
    Public Const CHCFG429_PAUSE As UInt32 = &H1000000  '//Mark channel as paused
    Public Const CHCFG429_UNPAUSE As UInt32 = &H0    '//Mark channel as unpaused (default)

    '/**
    '*
    '*  Message configuration options
    '*
    '**/

    Public Const MSGCRT429_DEFAULT As UInt32 = &H0   '//Default settings
    Public Const MSGCRT429_NOSEQ As UInt32 = &H0 '//Message will not be recorded in sequential record (default)
    Public Const MSGCRT429_SEQ As UInt32 = &H1   '//Message will be recorded in sequential record
    Public Const MSGCRT429_NOLOG As UInt32 = &H0 '//Message will not generate event log (default)
    Public Const MSGCRT429_LOG As UInt32 = &H2   '//Message will generate event log
    Public Const MSGCRT429_NOSKIP As UInt32 = &H0    '//Message will not be skipped (default)
    Public Const MSGCRT429_SKIP As UInt32 = &H8  '//Message will be skipped
    Public Const MSGCRT429_NOTIMETAG As UInt32 = &H0 '//Message will not record time-tag (default)
    Public Const MSGCRT429_TIMETAG As UInt32 = &H10   '//Message will record time-tag
    Public Const MSGCRT429_NOELAPSE As UInt32 = &H0  '//Message will not record elapse time (default)
    Public Const MSGCRT429_ELAPSE As UInt32 = &H20    '//Message will record elapse time
    Public Const MSGCRT429_NOMAXMIN As UInt32 = &H0  '//Message will not record min/max time (default)
    Public Const MSGCRT429_MAX As UInt32 = &H40   '//Message will record max time
    Public Const MSGCRT429_MIN As UInt32 = &H80   '//Message will record min time
    Public Const MSGCRT429_MAXMIN As UInt32 = &HC0    '//Message will record min/max time
    Public Const MSGCRT429_NOSYNC As UInt32 = &H0    '//No sync will be generated for message (default)
    Public Const MSGCRT429_SYNC As UInt32 = &H100  '//Sync will be generated for message
    Public Const MSGCRT429_NOERR As UInt32 = &H0 '//No error will be generated for message (default)
    Public Const MSGCRT429_PARERR As UInt32 = &H200    '//Parity error will be generated for message
    Public Const MSGCRT429_NOHIT As UInt32 = &H0 '//Message will not record hit count (default)
    Public Const MSGCRT429_HIT As UInt32 = &H400   '//Message will record hit count
    Public Const MSGCRT429_NOEXTRIG As UInt32 = &H0  '//Message will not be externally triggered (default)
    Public Const MSGCRT429_EXTRIG As UInt32 = &H1000    '//Message will be externally triggered
    Public Const MSGCRT429_WIPE As UInt32 = &H0  '//Enables message clear (default)
    Public Const MSGCRT429_NOWIPE As UInt32 = 2147483648    '//Disables message clear
    Public Const MSGCRT429_WIPE0 As UInt32 = &H0 '//Initialize data with zeros (default)
    Public Const MSGCRT429_WIPE1 As UInt32 = &H40000000 '//Initialize data with ones

    '/**
    '*
    '*  List buffer options
    '*
    '**/

    Public Const LISTCRT429_DEFAULT As UInt32 = &H0  '//Select all default settings
    Public Const LISTCRT429_FIFO As UInt32 = &H0 '//Enable FIFO mode (default)
    Public Const LISTCRT429_PINGPONG As UInt32 = &H1 '//Enable ping-pong mode
    Public Const LISTCRT429_CIRCULAR As UInt32 = &H2 '//Enable circular mode
    Public Const LISTCRT429_RCV As UInt32 = &H10  '//User will read from list buffer
    Public Const LISTCRT429_XMT As UInt32 = &H20  '//User will write to list buffer
    Public Const LISTCRT429_ASYNC As UInt32 = &H40    '//Asynchronous mode
    Public Const LISTCRT429_NOLOG As UInt32 = &H0    '//Do not generate event log when list buffer empty/full (default)
    Public Const LISTCRT429_LOG As UInt32 = &H100  '//Generate event log when list buffer empty/full

    '/**
    '*
    '*  Parametric configuration options
    '*
    '**/

    Public Const PARAMCFG429_DEFAULT As UInt32 = &H0 '//Select all default settings (default)
    Public Const PARAMCFG429_AMPLON As UInt32 = &H0  '//Enables parametric amplitude control (default)
    Public Const PARAMCFG429_AMPLOFF As UInt32 = &H1 '//Disables parametric amplitude control
    Public Const PARAMCFG429_BITRATEON As UInt32 = &H0   '//Enables parametric bit rate control (default)
    Public Const PARAMCFG429_BITRATEOFF As UInt32 = &H2  '//Disables parametric bit rate control

    '/**
    '*
    '*  Scheduling conditions.
    '*
    '**/

    Public Const COND429_ALWAYS As UInt32 = &H0  '//Unconditional
    Public Const COND429_DIO1ACT As UInt32 = &H1 '//Condition on digital I/O #1 active
    Public Const COND429_DIO1NACT As UInt32 = &H2    '//Condition on digital I/O #1 not active
    Public Const COND429_DIO2ACT As UInt32 = &H4 '//Condition on digital I/O #2 active
    Public Const COND429_DIO2NACT As UInt32 = &H8    '//Condition on digital I/O #2 not active
    Public Const COND429_DIO3ACT As UInt32 = &H10 '//Condition on digital I/O #3 active
    Public Const COND429_DIO3NACT As UInt32 = &H20    '//Condition on digital I/O #3 not active
    Public Const COND429_DIO4ACT As UInt32 = &H40 '//Condition on digital I/O #4 active
    Public Const COND429_DIO4NACT As UInt32 = &H80    '//Condition on digital I/O #4 not active
    Public Const COND429_DIO5ACT As UInt32 = &H100 '//Condition on digital I/O #5 active
    Public Const COND429_DIO5NACT As UInt32 = &H200    '//Condition on digital I/O #5 not active
    Public Const COND429_DIO6ACT As UInt32 = &H400 '//Condition on digital I/O #6 active
    Public Const COND429_DIO6NACT As UInt32 = &H800    '//Condition on digital I/O #6 not active
    Public Const COND429_DIO7ACT As UInt32 = &H1000 '//Condition on digital I/O #7 active
    Public Const COND429_DIO7NACT As UInt32 = &H2000    '//Condition on digital I/O #7 not active
    Public Const COND429_DIO8ACT As UInt32 = &H4000 '//Condition on digital I/O #8 active
    Public Const COND429_DIO8NACT As UInt32 = &H8000    '//Condition on digital I/O #8 not active

    '/**
    '*
    '*  Bit fields of the message activity flag.
    '*
    '**/

    Public Const MSGACT429_CHMASK As UInt32 = &HFF00    '//Channel number mask value
    Public Const MSGACT429_CHSHIFT As UInt32 = &H8   '//Channel number shift value
    Public Const MSGACT429_SPD As UInt32 = &H80   '//Bus speed
    Public Const MSGACT429_ERR As UInt32 = &H40   '//Error bit
    Public Const MSGACT429_GAP As UInt32 = &H20   '//Gap error bit
    Public Const MSGACT429_PAR As UInt32 = &H10   '//Parity error bit
    Public Const MSGACT429_LONG As UInt32 = &H8  '//Long word error bit
    Public Const MSGACT429_BIT As UInt32 = &H4   '//Bit time error bit
    Public Const MSGACT429_TO As UInt32 = &H2    '//Time out error bit
    Public Const MSGACT429_HIT As UInt32 = &H1   '//Always set

    '/**
    '*
    '*  Channel info fields.
    '*
    '**/

    Public Const INFO429_PARAM As UInt32 = &H1   '//Channel supports parametric control

    '/**
    '*
    '*  Scheduling algorithm options
    '*
    '**/

    Public Const SCHEDMODE_DEFAULT As UInt32 = &H0   '//Select all default settings
    Public Const SCHEDMODE_METHOD_NORMAL As UInt32 = &H0 '//Choose the normal scheduling method
    Public Const SCHEDMODE_METHOD_QUICK As UInt32 = &H1  '//Choose the quick scheduling method
    Public Const SCHEDMODE_METHOD_BOTH As UInt32 = &H2   '//Use the quick method first if fail then use the normal method
    Public Const SCHEDMODE_METHOD_MASK As UInt32 = &HF   '//Mask for method setting
    Public Const SCHEDMODE_MILLISEC As UInt32 = &H0  '//Specify periods in milliseconds
    Public Const SCHEDMODE_MICROSEC As UInt32 = &H10  '//Specify periods in microseconds
    Public Const SCHEDMODE_REMOTE As UInt32 = &H0    '//Perform calculations remotely if applicable
    Public Const SCHEDMODE_LOCAL As UInt32 = &H20 '//Perform calculations locally if applicable
    Public Const SCHEDMODE_DEFAULT_ALGOR As UInt32 = &H0 '//Choose the default algorithm
    Public Const SCHEDMODE_QUICK_ALGOR As UInt32 = &H1   '//Choose the quick algorithm
    Public Const SCHEDMODE_BOTH_ALGOR As UInt32 = &H2    '//Use the quick algorithm first if fail then use the normal algorithm
    Public Const SCHEDMODE_ALGOR_MASK As UInt32 = &HF    '//Mask for algorithm setting

End Module
