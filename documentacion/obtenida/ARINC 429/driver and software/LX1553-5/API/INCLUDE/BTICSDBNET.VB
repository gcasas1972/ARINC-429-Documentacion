Imports System
Imports System.Runtime.InteropServices

Module BTICSDBVB

    '/**
    '*
    '*  BTICSDB WIN32 DRIVER  Version 1.1.2  (03/02/2010)
    '*  Copyright (c) 2005-2010
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   BTICSDBNET.VB -- 32-bit
    '*                      BTICSDB Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  Structs used by the BTICSDB Driver.
    '*
    '**/

    <StructLayout(LayoutKind.Sequential)> Public Structure MSGFIELDSCSDB
        Public msgopt As UInt16 '//Driver writes message optionvals
        Public msgoptext As UInt16  '//Non-continuous, Valid, and current burst count (FW)
        Public burstcount As UInt16 '//Burst count (API)
        Public reserved As UInt16   '//reserved
        Public msgact As UInt16 '//Card writes message activity
        Public datacount As UInt16  '//Number of valid bytes in data[] buffer
        Public listptr As UInt32    '//Driver writes list buffer pointer
        Public timetag_hitcount As UInt32   '//Card writes time-tag low value (32 bits) - '//Card writes hit count
        Public maxtime_elapsetime As UInt32 '//Card writes max time - '//Card writes elapsed time
        Public mintime As UInt32    '//Card writes min time
        Public userptr As UInt32    '//Driver writes user code pointer
        Public miscptr As UInt32    '//reserved
        Public timetagh As UInt32   '//Card writes extended timetag (32 bits)
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> Public data() As UInt16    '//Card writes data block
    End Structure

    '/**
    '*
    '*  BTICSDB Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the BTICSDB Driver.
    '*
    '**/

    Private Class BTICSDB_32
        Public Declare Function BTICSDB_ChClear Lib "BTICSDB.DLL" Alias "_BTICSDB_ChClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChConfig Lib "BTICSDB.DLL" Alias "_BTICSDB_ChConfig@28" (ByVal configval As UInt32, ByVal bitrateflag As UInt16, ByVal bytesperblock As UInt16, ByVal framespersecond As UInt16, ByVal blocksperframe As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_ChGetCount Lib "BTICSDB.DLL" Alias "_BTICSDB_ChGetCount@12" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_ChGetInfo Lib "BTICSDB.DLL" Alias "_BTICSDB_ChGetInfo@12" (ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ChIsCSDB Lib "BTICSDB.DLL" Alias "_BTICSDB_ChIsCSDB@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChIsRcv Lib "BTICSDB.DLL" Alias "_BTICSDB_ChIsRcv@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChIsXmt Lib "BTICSDB.DLL" Alias "_BTICSDB_ChIsXmt@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_ChPause Lib "BTICSDB.DLL" Alias "_BTICSDB_ChPause@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_ChPauseCheck Lib "BTICSDB.DLL" Alias "_BTICSDB_ChPauseCheck@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_ChResume Lib "BTICSDB.DLL" Alias "_BTICSDB_ChResume@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_ChStart Lib "BTICSDB.DLL" Alias "_BTICSDB_ChStart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChStop Lib "BTICSDB.DLL" Alias "_BTICSDB_ChStop@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_FilterClear Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterClear@8" (ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_FilterDefault Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterDefault@12" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_FilterRd Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterRd@16" (ByVal addrval As Int32, ByVal sival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_FilterSet Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterSet@20" (ByVal configval As UInt32, ByVal addrval As Int32, ByVal simask As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_FilterWr Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterWr@20" (ByVal msgaddr As UInt32, ByVal addrval As Int32, ByVal sival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListDataRd Lib "BTICSDB.DLL" Alias "_BTICSDB_ListDataRd@16" (ByRef buf As Byte, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListDataWr Lib "BTICSDB.DLL" Alias "_BTICSDB_ListDataWr@16" (ByRef buf As Byte, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListRcvCreate Lib "BTICSDB.DLL" Alias "_BTICSDB_ListRcvCreate@16" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListStatus Lib "BTICSDB.DLL" Alias "_BTICSDB_ListStatus@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListXmtCreate Lib "BTICSDB.DLL" Alias "_BTICSDB_ListXmtCreate@16" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgBlockRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgBlockRd@12" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgBlockWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgBlockWr@12" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgCreate Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgCreate@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgDataByteRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgDataByteRd@12" (ByVal index As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Byte
        Public Declare Function BTICSDB_MsgDataByteWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgDataByteWr@16" (ByVal data As Byte, ByVal index As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_MsgDataRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgDataRd@16" (ByRef buf As Byte, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_MsgDataWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgDataWr@16" (ByRef buf As Byte, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_MsgIsAccessed Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgIsAccessed@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_MsgValidSet Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgValidSet@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICSDB_ParamAmplitudeConfig Lib "BTICSDB.DLL" Alias "_BTICSDB_ParamAmplitudeConfig@16" (ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ParamAmplitudeGet Lib "BTICSDB.DLL" Alias "_BTICSDB_ParamAmplitudeGet@12" (ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedBranch Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedBranch@16" (ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedBuild Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedBuild@28" (ByVal nummsgs As Int32, ByRef msgs As UInt32, ByRef freq As Int32, ByVal interblockgap As Int32, ByVal rsvdblocks As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedCall Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedCall@16" (ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedEntry Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedEntry@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedGap Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedGap@12" (ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedHalt Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedHalt@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedLog Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedLog@16" (ByVal condition As UInt32, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedMsg Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedMsg@12" (ByVal msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedPause Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedPause@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedPulse Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedPulse@12" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedRestart Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedRestart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedReturn Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedReturn@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChConfigEx Lib "BTICSDB.DLL" Alias "_BTICSDB_ChConfigEx@32" (ByVal configval As UInt32, ByVal bitrateflag As UInt16, ByVal bytesperblock As UInt16, ByVal framespersecond As UInt16, ByVal blocksperframe As UInt16, ByVal interbytegap As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChConfigExx Lib "BTICSDB.DLL" Alias "_BTICSDB_ChConfigExx@36" (ByVal configval As UInt32, ByVal count As UInt16, ByVal bitrateflag As UInt16, ByVal bytesperblock As UInt16, ByVal framespersecond As UInt16, ByVal blocksperframe As UInt16, ByVal interbytegap As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_CmdAddr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdAddr@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_CmdAlloc Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdAlloc@8" (ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_CmdAllocEx Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdAllocEx@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_CmdBaseRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdBaseRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICSDB_CmdBaseWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdBaseWr@12" (ByVal addrval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdClear Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_CmdCountRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCountRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_CmdCountWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCountWr@12" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdCtrlRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCtrlRd@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_CmdCtrlWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCtrlWr@16" (ByVal ctrlval As UInt16, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdCurrRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCurrRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_CmdCurrWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCurrWr@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICSDB_CmdInit Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdInit@8" (ByVal opcode As UInt16, ByRef block As UInt16)
        Public Declare Function BTICSDB_CmdInsert Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdInsert@12" (ByRef block As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_CmdMaxLoopRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdMaxLoopRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_CmdMaxLoopWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdMaxLoopWr@12" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdRd@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_CmdRestart Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdRestart@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdShotWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdShotWr@16" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_CmdSkipWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdSkipWr@16" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_CmdStackClr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdStackClr@8" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdStartRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdStartRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_CmdStartWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdStartWr@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdStepWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdStepWr@16" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_CmdTotalRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdTotalRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_CmdTotalWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdTotalWr@12" (ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdWr@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_DllUsageCount Lib "BTICSDB.DLL" Alias "_BTICSDB_DllUsageCount@0" () As Int32
        Public Declare Function BTICSDB_FilterAddr Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterAddr@16" (ByVal addrval As Int32, ByVal sival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_FilterCreate Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterCreate@4" (ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_FilterFill Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterFill@12" (ByVal msgaddr As UInt32, ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_GetChanCount Lib "BTICSDB.DLL" Alias "_BTICSDB_GetChanCount@12" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_IsChan Lib "BTICSDB.DLL" Alias "_BTICSDB_IsChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_IsRcvChan Lib "BTICSDB.DLL" Alias "_BTICSDB_IsRcvChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_IsXmtChan Lib "BTICSDB.DLL" Alias "_BTICSDB_IsXmtChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListAddr Lib "BTICSDB.DLL" Alias "_BTICSDB_ListAddr@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListAddrEx Lib "BTICSDB.DLL" Alias "_BTICSDB_ListAddrEx@16" (ByVal index As Int32, ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListAdvance Lib "BTICSDB.DLL" Alias "_BTICSDB_ListAdvance@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListClear Lib "BTICSDB.DLL" Alias "_BTICSDB_ListClear@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListConfig Lib "BTICSDB.DLL" Alias "_BTICSDB_ListConfig@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListConfigEx Lib "BTICSDB.DLL" Alias "_BTICSDB_ListConfigEx@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListDataRdEx Lib "BTICSDB.DLL" Alias "_BTICSDB_ListDataRdEx@20" (ByRef buf As Byte, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListDataWrEx Lib "BTICSDB.DLL" Alias "_BTICSDB_ListDataWrEx@20" (ByRef buf As Byte, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListInit Lib "BTICSDB.DLL" Alias "_BTICSDB_ListInit@12" (ByVal listaddr As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListNextRd Lib "BTICSDB.DLL" Alias "_BTICSDB_ListNextRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListNextWr Lib "BTICSDB.DLL" Alias "_BTICSDB_ListNextWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICSDB_ListPostRd Lib "BTICSDB.DLL" Alias "_BTICSDB_ListPostRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICSDB_ListPostWr Lib "BTICSDB.DLL" Alias "_BTICSDB_ListPostWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICSDB_ListPreRd Lib "BTICSDB.DLL" Alias "_BTICSDB_ListPreRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICSDB_ListPreWr Lib "BTICSDB.DLL" Alias "_BTICSDB_ListPreWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_MsgActivityRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgActivityRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_MsgActivityWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgActivityWr@12" (ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_MsgCheck Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgCheck@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICSDB_MsgCommRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgCommRd@12" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgCommWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgCommWr@12" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgConfig Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgConfig@16" (ByVal configval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_MsgCreateEx Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgCreateEx@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgFieldRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgFieldRd@12" (ByVal fieldtype As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgFieldWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgFieldWr@16" (ByVal fieldval As UInt32, ByVal fieldtype As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgOptRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgOptRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_MsgOptWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgOptWr@12" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_MsgReset Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgReset@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_SchedAgain Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedAgain@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedBranchEx Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedBranchEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedBuildEx Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedBuildEx@32" (ByVal nummsgs As Int32, ByRef msgs As UInt32, ByRef freq As Int32, ByVal interblockgap As Int32, ByVal rsvdblocks As Int32, ByVal bitrate As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedBuildExx Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedBuildExx@40" (ByVal nummsgs As Int32, ByRef msgs As UInt32, ByRef freq As Int32, ByVal interblockgap As Int32, ByVal rsvdblocks As Int32, ByVal bitrate As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedCallEx Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedCallEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedGCD Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedGCD@8" (ByVal a As Int32, ByVal b As Int32) As Int32
        Public Declare Function BTICSDB_SchedLCM Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedLCM@8" (ByVal a As Int32, ByVal b As Int32) As Int32
        Public Declare Function BTICSDB_SchedLogEx Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedLogEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedNop Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedNop@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedPulse0 Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedPulse0@12" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedPulse1 Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedPulse1@12" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedUser Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedUser@12" (ByVal useraddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_TestProtocol Lib "BTICSDB.DLL" Alias "_BTICSDB_TestProtocol@4" (ByVal handleval As UInt32) As Int32
    End Class

    Private Class BTICSDB_64
        Public Declare Function BTICSDB_ChClear Lib "BTICSDB64.DLL" Alias "BTICSDB_ChClear" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChConfig Lib "BTICSDB64.DLL" Alias "BTICSDB_ChConfig" (ByVal configval As UInt32, ByVal bitrateflag As UInt16, ByVal bytesperblock As UInt16, ByVal framespersecond As UInt16, ByVal blocksperframe As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_ChGetCount Lib "BTICSDB64.DLL" Alias "BTICSDB_ChGetCount" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_ChGetInfo Lib "BTICSDB64.DLL" Alias "BTICSDB_ChGetInfo" (ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ChIsCSDB Lib "BTICSDB64.DLL" Alias "BTICSDB_ChIsCSDB" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChIsRcv Lib "BTICSDB64.DLL" Alias "BTICSDB_ChIsRcv" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChIsXmt Lib "BTICSDB64.DLL" Alias "BTICSDB_ChIsXmt" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_ChPause Lib "BTICSDB64.DLL" Alias "BTICSDB_ChPause" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_ChPauseCheck Lib "BTICSDB64.DLL" Alias "BTICSDB_ChPauseCheck" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_ChResume Lib "BTICSDB64.DLL" Alias "BTICSDB_ChResume" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_ChStart Lib "BTICSDB64.DLL" Alias "BTICSDB_ChStart" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChStop Lib "BTICSDB64.DLL" Alias "BTICSDB_ChStop" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_FilterClear Lib "BTICSDB64.DLL" Alias "BTICSDB_FilterClear" (ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_FilterDefault Lib "BTICSDB64.DLL" Alias "BTICSDB_FilterDefault" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_FilterRd Lib "BTICSDB64.DLL" Alias "BTICSDB_FilterRd" (ByVal addrval As Int32, ByVal sival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_FilterSet Lib "BTICSDB64.DLL" Alias "BTICSDB_FilterSet" (ByVal configval As UInt32, ByVal addrval As Int32, ByVal simask As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_FilterWr Lib "BTICSDB64.DLL" Alias "BTICSDB_FilterWr" (ByVal msgaddr As UInt32, ByVal addrval As Int32, ByVal sival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListDataRd Lib "BTICSDB64.DLL" Alias "BTICSDB_ListDataRd" (ByRef buf As Byte, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListDataWr Lib "BTICSDB64.DLL" Alias "BTICSDB_ListDataWr" (ByRef buf As Byte, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListRcvCreate Lib "BTICSDB64.DLL" Alias "BTICSDB_ListRcvCreate" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListStatus Lib "BTICSDB64.DLL" Alias "BTICSDB_ListStatus" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListXmtCreate Lib "BTICSDB64.DLL" Alias "BTICSDB_ListXmtCreate" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgBlockRd Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgBlockRd" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgBlockWr Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgBlockWr" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgCreate Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgCreate" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgDataByteRd Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgDataByteRd" (ByVal index As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Byte
        Public Declare Function BTICSDB_MsgDataByteWr Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgDataByteWr" (ByVal data As Byte, ByVal index As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_MsgDataRd Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgDataRd" (ByRef buf As Byte, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_MsgDataWr Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgDataWr" (ByRef buf As Byte, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_MsgIsAccessed Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgIsAccessed" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_MsgValidSet Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgValidSet" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICSDB_ParamAmplitudeConfig Lib "BTICSDB64.DLL" Alias "BTICSDB_ParamAmplitudeConfig" (ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ParamAmplitudeGet Lib "BTICSDB64.DLL" Alias "BTICSDB_ParamAmplitudeGet" (ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedBranch Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedBranch" (ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedBuild Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedBuild" (ByVal nummsgs As Int32, ByRef msgs As UInt32, ByRef freq As Int32, ByVal interblockgap As Int32, ByVal rsvdblocks As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedCall Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedCall" (ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedEntry Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedEntry" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedGap Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedGap" (ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedHalt Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedHalt" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedLog Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedLog" (ByVal condition As UInt32, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedMsg Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedMsg" (ByVal msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedPause Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedPause" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedPulse Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedPulse" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedRestart Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedRestart" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedReturn Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedReturn" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChConfigEx Lib "BTICSDB64.DLL" Alias "BTICSDB_ChConfigEx" (ByVal configval As UInt32, ByVal bitrateflag As UInt16, ByVal bytesperblock As UInt16, ByVal framespersecond As UInt16, ByVal blocksperframe As UInt16, ByVal interbytegap As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ChConfigExx Lib "BTICSDB64.DLL" Alias "BTICSDB_ChConfigExx" (ByVal configval As UInt32, ByVal count As UInt16, ByVal bitrateflag As UInt16, ByVal bytesperblock As UInt16, ByVal framespersecond As UInt16, ByVal blocksperframe As UInt16, ByVal interbytegap As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_CmdAddr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdAddr" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_CmdAlloc Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdAlloc" (ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_CmdAllocEx Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdAllocEx" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_CmdBaseRd Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdBaseRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICSDB_CmdBaseWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdBaseWr" (ByVal addrval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdClear Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdClear" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_CmdCountRd Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdCountRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_CmdCountWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdCountWr" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdCtrlRd Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdCtrlRd" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_CmdCtrlWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdCtrlWr" (ByVal ctrlval As UInt16, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdCurrRd Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdCurrRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_CmdCurrWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdCurrWr" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICSDB_CmdInit Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdInit" (ByVal opcode As UInt16, ByRef block As UInt16)
        Public Declare Function BTICSDB_CmdInsert Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdInsert" (ByRef block As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_CmdMaxLoopRd Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdMaxLoopRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_CmdMaxLoopWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdMaxLoopWr" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdRd Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdRd" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_CmdRestart Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdRestart" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdShotWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdShotWr" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_CmdSkipWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdSkipWr" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_CmdStackClr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdStackClr" (ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdStartRd Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdStartRd" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_CmdStartWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdStartWr" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdStepWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdStepWr" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_CmdTotalRd Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdTotalRd" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_CmdTotalWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdTotalWr" (ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_CmdWr Lib "BTICSDB64.DLL" Alias "BTICSDB_CmdWr" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_DllUsageCount Lib "BTICSDB64.DLL" Alias "BTICSDB_DllUsageCount" () As Int32
        Public Declare Function BTICSDB_FilterAddr Lib "BTICSDB64.DLL" Alias "BTICSDB_FilterAddr" (ByVal addrval As Int32, ByVal sival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_FilterCreate Lib "BTICSDB64.DLL" Alias "BTICSDB_FilterCreate" (ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_FilterFill Lib "BTICSDB64.DLL" Alias "BTICSDB_FilterFill" (ByVal msgaddr As UInt32, ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICSDB_GetChanCount Lib "BTICSDB64.DLL" Alias "BTICSDB_GetChanCount" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_IsChan Lib "BTICSDB64.DLL" Alias "BTICSDB_IsChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_IsRcvChan Lib "BTICSDB64.DLL" Alias "BTICSDB_IsRcvChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_IsXmtChan Lib "BTICSDB64.DLL" Alias "BTICSDB_IsXmtChan" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListAddr Lib "BTICSDB64.DLL" Alias "BTICSDB_ListAddr" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListAddrEx Lib "BTICSDB64.DLL" Alias "BTICSDB_ListAddrEx" (ByVal index As Int32, ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListAdvance Lib "BTICSDB64.DLL" Alias "BTICSDB_ListAdvance" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListClear Lib "BTICSDB64.DLL" Alias "BTICSDB_ListClear" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListConfig Lib "BTICSDB64.DLL" Alias "BTICSDB_ListConfig" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListConfigEx Lib "BTICSDB64.DLL" Alias "BTICSDB_ListConfigEx" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListDataRdEx Lib "BTICSDB64.DLL" Alias "BTICSDB_ListDataRdEx" (ByRef buf As Byte, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListDataWrEx Lib "BTICSDB64.DLL" Alias "BTICSDB_ListDataWrEx" (ByRef buf As Byte, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListInit Lib "BTICSDB64.DLL" Alias "BTICSDB_ListInit" (ByVal listaddr As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_ListNextRd Lib "BTICSDB64.DLL" Alias "BTICSDB_ListNextRd" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_ListNextWr Lib "BTICSDB64.DLL" Alias "BTICSDB_ListNextWr" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICSDB_ListPostRd Lib "BTICSDB64.DLL" Alias "BTICSDB_ListPostRd" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICSDB_ListPostWr Lib "BTICSDB64.DLL" Alias "BTICSDB_ListPostWr" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICSDB_ListPreRd Lib "BTICSDB64.DLL" Alias "BTICSDB_ListPreRd" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICSDB_ListPreWr Lib "BTICSDB64.DLL" Alias "BTICSDB_ListPreWr" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_MsgActivityRd Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgActivityRd" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_MsgActivityWr Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgActivityWr" (ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_MsgCheck Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgCheck" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICSDB_MsgCommRd Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgCommRd" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgCommWr Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgCommWr" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgConfig Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgConfig" (ByVal configval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_MsgCreateEx Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgCreateEx" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgFieldRd Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgFieldRd" (ByVal fieldtype As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgFieldWr Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgFieldWr" (ByVal fieldval As UInt32, ByVal fieldtype As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_MsgOptRd Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgOptRd" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICSDB_MsgOptWr Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgOptWr" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICSDB_MsgReset Lib "BTICSDB64.DLL" Alias "BTICSDB_MsgReset" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICSDB_SchedAgain Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedAgain" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedBranchEx Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedBranchEx" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedBuildEx Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedBuildEx" (ByVal nummsgs As Int32, ByRef msgs As UInt32, ByRef freq As Int32, ByVal interblockgap As Int32, ByVal rsvdblocks As Int32, ByVal bitrate As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedBuildExx Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedBuildExx" (ByVal nummsgs As Int32, ByRef msgs As UInt32, ByRef freq As Int32, ByVal interblockgap As Int32, ByVal rsvdblocks As Int32, ByVal bitrate As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedCallEx Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedCallEx" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedGCD Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedGCD" (ByVal a As Int32, ByVal b As Int32) As Int32
        Public Declare Function BTICSDB_SchedLCM Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedLCM" (ByVal a As Int32, ByVal b As Int32) As Int32
        Public Declare Function BTICSDB_SchedLogEx Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedLogEx" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedNop Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedNop" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedPulse0 Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedPulse0" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedPulse1 Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedPulse1" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_SchedUser Lib "BTICSDB64.DLL" Alias "BTICSDB_SchedUser" (ByVal useraddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICSDB_TestProtocol Lib "BTICSDB64.DLL" Alias "BTICSDB_TestProtocol" (ByVal handleval As UInt32) As Int32
    End Class

    Public Function BTICSDB_ChClear(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChClear(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChClear(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_ChConfig(ByVal configval As UInt32, ByVal bitrateflag As UInt16, ByVal bytesperblock As UInt16, ByVal framespersecond As UInt16, ByVal blocksperframe As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChConfig(configval, bitrateflag, bytesperblock, framespersecond, blocksperframe, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChConfig(configval, bitrateflag, bytesperblock, framespersecond, blocksperframe, channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_ChGetCount(ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_ChGetCount(rcvcount, xmtcount, handleval)
        Else
            BTICSDB_64.BTICSDB_ChGetCount(rcvcount, xmtcount, handleval)
        End If
    End Sub
    Public Function BTICSDB_ChGetInfo(ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChGetInfo(infotype, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChGetInfo(infotype, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_ChIsCSDB(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChIsCSDB(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChIsCSDB(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_ChIsRcv(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChIsRcv(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChIsRcv(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_ChIsXmt(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChIsXmt(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChIsXmt(channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_ChPause(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_ChPause(channum, handleval)
        Else
            BTICSDB_64.BTICSDB_ChPause(channum, handleval)
        End If
    End Sub
    Public Function BTICSDB_ChPauseCheck(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChPauseCheck(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChPauseCheck(channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_ChResume(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_ChResume(channum, handleval)
        Else
            BTICSDB_64.BTICSDB_ChResume(channum, handleval)
        End If
    End Sub
    Public Function BTICSDB_ChStart(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChStart(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChStart(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_ChStop(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChStop(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChStop(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_FilterClear(ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_FilterClear(basevaladdr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_FilterClear(basevaladdr, handleval)
        End If
    End Function
    Public Function BTICSDB_FilterDefault(ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_FilterDefault(configval, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_FilterDefault(configval, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_FilterRd(ByVal addrval As Int32, ByVal sival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_FilterRd(addrval, sival, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_FilterRd(addrval, sival, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_FilterSet(ByVal configval As UInt32, ByVal addrval As Int32, ByVal simask As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_FilterSet(configval, addrval, simask, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_FilterSet(configval, addrval, simask, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_FilterWr(ByVal msgaddr As UInt32, ByVal addrval As Int32, ByVal sival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_FilterWr(msgaddr, addrval, sival, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_FilterWr(msgaddr, addrval, sival, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_ListDataRd(ByRef buf As Byte, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListDataRd(buf, count, listaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListDataRd(buf, count, listaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ListDataWr(ByRef buf As Byte, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListDataWr(buf, count, listaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListDataWr(buf, count, listaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ListRcvCreate(ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListRcvCreate(listconfigval, count, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListRcvCreate(listconfigval, count, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ListStatus(ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListStatus(listaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListStatus(listaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ListXmtCreate(ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListXmtCreate(listconfigval, count, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListXmtCreate(listconfigval, count, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgBlockRd(ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgBlockRd(msgfields, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgBlockRd(msgfields, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgBlockWr(ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgBlockWr(msgfields, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgBlockWr(msgfields, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgCreate(ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgCreate(configval, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgCreate(configval, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgDataByteRd(ByVal index As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Byte
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgDataByteRd(index, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgDataByteRd(index, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgDataByteWr(ByVal data As Byte, ByVal index As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgDataByteWr(data, index, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgDataByteWr(data, index, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgDataRd(ByRef buf As Byte, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgDataRd(buf, count, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgDataRd(buf, count, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgDataWr(ByRef buf As Byte, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgDataWr(buf, count, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgDataWr(buf, count, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgIsAccessed(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgIsAccessed(msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgIsAccessed(msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgValidSet(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgValidSet(msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgValidSet(msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ParamAmplitudeConfig(ByVal configval As UInt32, ByVal dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ParamAmplitudeConfig(configval, dacval, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ParamAmplitudeConfig(configval, dacval, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_ParamAmplitudeGet(ByRef dacval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ParamAmplitudeGet(dacval, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ParamAmplitudeGet(dacval, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedBranch(ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedBranch(condition, destindex, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedBranch(condition, destindex, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedBuild(ByVal nummsgs As Int32, ByRef msgs As UInt32, ByRef freq As Int32, ByVal interblockgap As Int32, ByVal rsvdblocks As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedBuild(nummsgs, msgs, freq, interblockgap, rsvdblocks, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedBuild(nummsgs, msgs, freq, interblockgap, rsvdblocks, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedCall(ByVal condition As UInt32, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedCall(condition, destindex, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedCall(condition, destindex, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedEntry(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedEntry(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedEntry(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedGap(ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedGap(gapval, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedGap(gapval, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedHalt(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedHalt(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedHalt(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedLog(ByVal condition As UInt32, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedLog(condition, tagval, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedLog(condition, tagval, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedMsg(ByVal msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedMsg(msgaddr, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedMsg(msgaddr, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedPause(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedPause(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedPause(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedPulse(ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedPulse(dionum, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedPulse(dionum, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedRestart(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedRestart(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedRestart(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedReturn(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedReturn(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedReturn(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_ChConfigEx(ByVal configval As UInt32, ByVal bitrateflag As UInt16, ByVal bytesperblock As UInt16, ByVal framespersecond As UInt16, ByVal blocksperframe As UInt16, ByVal interbytegap As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChConfigEx(configval, bitrateflag, bytesperblock, framespersecond, blocksperframe, interbytegap, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChConfigEx(configval, bitrateflag, bytesperblock, framespersecond, blocksperframe, interbytegap, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_ChConfigExx(ByVal configval As UInt32, ByVal count As UInt16, ByVal bitrateflag As UInt16, ByVal bytesperblock As UInt16, ByVal framespersecond As UInt16, ByVal blocksperframe As UInt16, ByVal interbytegap As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ChConfigExx(configval, count, bitrateflag, bytesperblock, framespersecond, blocksperframe, interbytegap, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ChConfigExx(configval, count, bitrateflag, bytesperblock, framespersecond, blocksperframe, interbytegap, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_CmdAddr(ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdAddr(index, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdAddr(index, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_CmdAlloc(ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdAlloc(count, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdAlloc(count, handleval)
        End If
    End Function
    Public Function BTICSDB_CmdAllocEx(ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdAllocEx(configval, count, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdAllocEx(configval, count, handleval)
        End If
    End Function
    Public Function BTICSDB_CmdBaseRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdBaseRd(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdBaseRd(channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_CmdBaseWr(ByVal addrval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_CmdBaseWr(addrval, channum, handleval)
        Else
            BTICSDB_64.BTICSDB_CmdBaseWr(addrval, channum, handleval)
        End If
    End Sub
    Public Function BTICSDB_CmdClear(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdClear(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdClear(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_CmdCountRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdCountRd(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdCountRd(channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_CmdCountWr(ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_CmdCountWr(countval, channum, handleval)
        Else
            BTICSDB_64.BTICSDB_CmdCountWr(countval, channum, handleval)
        End If
    End Sub
    Public Function BTICSDB_CmdCtrlRd(ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdCtrlRd(index, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdCtrlRd(index, channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_CmdCtrlWr(ByVal ctrlval As UInt16, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_CmdCtrlWr(ctrlval, index, channum, handleval)
        Else
            BTICSDB_64.BTICSDB_CmdCtrlWr(ctrlval, index, channum, handleval)
        End If
    End Sub
    Public Function BTICSDB_CmdCurrRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdCurrRd(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdCurrRd(channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_CmdCurrWr(ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_CmdCurrWr(addrval, channum, handleval)
        Else
            BTICSDB_64.BTICSDB_CmdCurrWr(addrval, channum, handleval)
        End If
    End Sub
    Public Sub BTICSDB_CmdInit(ByVal opcode As UInt16, ByRef block As UInt16)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_CmdInit(opcode, block)
        Else
            BTICSDB_64.BTICSDB_CmdInit(opcode, block)
        End If
    End Sub
    Public Function BTICSDB_CmdInsert(ByRef block As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdInsert(block, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdInsert(block, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_CmdMaxLoopRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdMaxLoopRd(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdMaxLoopRd(channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_CmdMaxLoopWr(ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_CmdMaxLoopWr(countval, channum, handleval)
        Else
            BTICSDB_64.BTICSDB_CmdMaxLoopWr(countval, channum, handleval)
        End If
    End Sub
    Public Function BTICSDB_CmdRd(ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdRd(block, addrval, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdRd(block, addrval, handleval)
        End If
    End Function
    Public Sub BTICSDB_CmdRestart(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_CmdRestart(channum, handleval)
        Else
            BTICSDB_64.BTICSDB_CmdRestart(channum, handleval)
        End If
    End Sub
    Public Function BTICSDB_CmdShotWr(ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdShotWr(value, index, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdShotWr(value, index, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_CmdSkipWr(ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdSkipWr(value, index, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdSkipWr(value, index, channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_CmdStackClr(ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_CmdStackClr(channum, handleval)
        Else
            BTICSDB_64.BTICSDB_CmdStackClr(channum, handleval)
        End If
    End Sub
    Public Function BTICSDB_CmdStartRd(ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdStartRd(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdStartRd(channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_CmdStartWr(ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_CmdStartWr(addrval, channum, handleval)
        Else
            BTICSDB_64.BTICSDB_CmdStartWr(addrval, channum, handleval)
        End If
    End Sub
    Public Function BTICSDB_CmdStepWr(ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdStepWr(value, index, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdStepWr(value, index, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_CmdTotalRd(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdTotalRd(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdTotalRd(channum, handleval)
        End If
    End Function
    Public Sub BTICSDB_CmdTotalWr(ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_CmdTotalWr(countval, channum, handleval)
        Else
            BTICSDB_64.BTICSDB_CmdTotalWr(countval, channum, handleval)
        End If
    End Sub
    Public Function BTICSDB_CmdWr(ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_CmdWr(block, addrval, handleval)
        Else
            Return BTICSDB_64.BTICSDB_CmdWr(block, addrval, handleval)
        End If
    End Function
    Public Function BTICSDB_DllUsageCount() As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_DllUsageCount
        Else
            Return BTICSDB_64.BTICSDB_DllUsageCount
        End If
    End Function
    Public Function BTICSDB_FilterAddr(ByVal addrval As Int32, ByVal sival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_FilterAddr(addrval, sival, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_FilterAddr(addrval, sival, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_FilterCreate(ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_FilterCreate(handleval)
        Else
            Return BTICSDB_64.BTICSDB_FilterCreate(handleval)
        End If
    End Function
    Public Function BTICSDB_FilterFill(ByVal msgaddr As UInt32, ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_FilterFill(msgaddr, basevaladdr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_FilterFill(msgaddr, basevaladdr, handleval)
        End If
    End Function
    Public Sub BTICSDB_GetChanCount(ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_GetChanCount(rcvcount, xmtcount, handleval)
        Else
            BTICSDB_64.BTICSDB_GetChanCount(rcvcount, xmtcount, handleval)
        End If
    End Sub
    Public Function BTICSDB_IsChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_IsChan(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_IsChan(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_IsRcvChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_IsRcvChan(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_IsRcvChan(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_IsXmtChan(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_IsXmtChan(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_IsXmtChan(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_ListAddr(ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListAddr(index, listaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListAddr(index, listaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ListAddrEx(ByVal index As Int32, ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListAddrEx(index, listaddr, header, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListAddrEx(index, listaddr, header, handleval)
        End If
    End Function
    Public Function BTICSDB_ListAdvance(ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListAdvance(listaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListAdvance(listaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ListClear(ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListClear(listaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListClear(listaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ListConfig(ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListConfig(configval, count, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListConfig(configval, count, handleval)
        End If
    End Function
    Public Function BTICSDB_ListConfigEx(ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListConfigEx(configval, count, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListConfigEx(configval, count, handleval)
        End If
    End Function
    Public Function BTICSDB_ListDataRdEx(ByRef buf As Byte, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListDataRdEx(buf, count, index, listaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListDataRdEx(buf, count, index, listaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ListDataWrEx(ByRef buf As Byte, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListDataWrEx(buf, count, index, listaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListDataWrEx(buf, count, index, listaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ListInit(ByVal listaddr As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListInit(listaddr, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListInit(listaddr, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_ListNextRd(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListNextRd(listaddr, header, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListNextRd(listaddr, header, handleval)
        End If
    End Function
    Public Function BTICSDB_ListNextWr(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_ListNextWr(listaddr, header, handleval)
        Else
            Return BTICSDB_64.BTICSDB_ListNextWr(listaddr, header, handleval)
        End If
    End Function
    Public Sub BTICSDB_ListPostRd(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_ListPostRd(listaddr, header, handleval)
        Else
            BTICSDB_64.BTICSDB_ListPostRd(listaddr, header, handleval)
        End If
    End Sub
    Public Sub BTICSDB_ListPostWr(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_ListPostWr(listaddr, header, handleval)
        Else
            BTICSDB_64.BTICSDB_ListPostWr(listaddr, header, handleval)
        End If
    End Sub
    Public Sub BTICSDB_ListPreRd(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_ListPreRd(listaddr, header, handleval)
        Else
            BTICSDB_64.BTICSDB_ListPreRd(listaddr, header, handleval)
        End If
    End Sub
    Public Sub BTICSDB_ListPreWr(ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_ListPreWr(listaddr, header, handleval)
        Else
            BTICSDB_64.BTICSDB_ListPreWr(listaddr, header, handleval)
        End If
    End Sub
    Public Function BTICSDB_MsgActivityRd(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgActivityRd(msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgActivityRd(msgaddr, handleval)
        End If
    End Function
    Public Sub BTICSDB_MsgActivityWr(ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_MsgActivityWr(value, msgaddr, handleval)
        Else
            BTICSDB_64.BTICSDB_MsgActivityWr(value, msgaddr, handleval)
        End If
    End Sub
    Public Function BTICSDB_MsgCheck(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgCheck(msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgCheck(msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgCommRd(ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgCommRd(msgfields, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgCommRd(msgfields, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgCommWr(ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgCommWr(msgfields, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgCommWr(msgfields, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgConfig(ByVal configval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgConfig(configval, count, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgConfig(configval, count, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgCreateEx(ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgCreateEx(configval, count, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgCreateEx(configval, count, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgFieldRd(ByVal fieldtype As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgFieldRd(fieldtype, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgFieldRd(fieldtype, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgFieldWr(ByVal fieldval As UInt32, ByVal fieldtype As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgFieldWr(fieldval, fieldtype, msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgFieldWr(fieldval, fieldtype, msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_MsgOptRd(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgOptRd(msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgOptRd(msgaddr, handleval)
        End If
    End Function
    Public Sub BTICSDB_MsgOptWr(ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICSDB_32.BTICSDB_MsgOptWr(msgopt, msgaddr, handleval)
        Else
            BTICSDB_64.BTICSDB_MsgOptWr(msgopt, msgaddr, handleval)
        End If
    End Sub
    Public Function BTICSDB_MsgReset(ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_MsgReset(msgaddr, handleval)
        Else
            Return BTICSDB_64.BTICSDB_MsgReset(msgaddr, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedAgain(ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedAgain(index, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedAgain(index, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedBranchEx(ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedBranchEx(condition1, condition2, destindex, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedBranchEx(condition1, condition2, destindex, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedBuildEx(ByVal nummsgs As Int32, ByRef msgs As UInt32, ByRef freq As Int32, ByVal interblockgap As Int32, ByVal rsvdblocks As Int32, ByVal bitrate As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedBuildEx(nummsgs, msgs, freq, interblockgap, rsvdblocks, bitrate, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedBuildEx(nummsgs, msgs, freq, interblockgap, rsvdblocks, bitrate, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedBuildExx(ByVal nummsgs As Int32, ByRef msgs As UInt32, ByRef freq As Int32, ByVal interblockgap As Int32, ByVal rsvdblocks As Int32, ByVal bitrate As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedBuildExx(nummsgs, msgs, freq, interblockgap, rsvdblocks, bitrate, buf, bufsize, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedBuildExx(nummsgs, msgs, freq, interblockgap, rsvdblocks, bitrate, buf, bufsize, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedCallEx(ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedCallEx(condition1, condition2, destindex, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedCallEx(condition1, condition2, destindex, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedGCD(ByVal a As Int32, ByVal b As Int32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedGCD(a, b)
        Else
            Return BTICSDB_64.BTICSDB_SchedGCD(a, b)
        End If
    End Function
    Public Function BTICSDB_SchedLCM(ByVal a As Int32, ByVal b As Int32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedLCM(a, b)
        Else
            Return BTICSDB_64.BTICSDB_SchedLCM(a, b)
        End If
    End Function
    Public Function BTICSDB_SchedLogEx(ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedLogEx(condition1, condition2, tagval, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedLogEx(condition1, condition2, tagval, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedNop(ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedNop(channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedNop(channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedPulse0(ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedPulse0(dionum, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedPulse0(dionum, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedPulse1(ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedPulse1(dionum, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedPulse1(dionum, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_SchedUser(ByVal useraddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_SchedUser(useraddr, channum, handleval)
        Else
            Return BTICSDB_64.BTICSDB_SchedUser(useraddr, channum, handleval)
        End If
    End Function
    Public Function BTICSDB_TestProtocol(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICSDB_32.BTICSDB_TestProtocol(handleval)
        Else
            Return BTICSDB_64.BTICSDB_TestProtocol(handleval)
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
    '*  Bitrate configuration options
    '*
    '**/

    Public Const BITRATECSDB_CLK1 As UInt16 = &H8000    '//CLK1, 20 MHz (default)
    Public Const BITRATECSDB_CLK2 As UInt16 = &H0    '//CLK2, 9.216 MHz (standard option)
    Public Const BITRATECSDB_XMTSLOPEHIGH As UInt16 = &H0    '//Transmit with high speed slope (default)
    Public Const BITRATECSDB_XMTSLOPELOW As UInt16 = &H4000 '//Transmit with low speed slope

    Public Const BITRATECSDB_921600BPS As UInt16 = &H0   '//External Clock, Div = 0
    Public Const BITRATECSDB_460800BPS As UInt16 = &H1   '//External Clock, Div = 1
    Public Const BITRATECSDB_230400BPS As UInt16 = &H3   '//External Clock, Div = 3
    Public Const BITRATECSDB_115200BPS As UInt16 = &H7   '//External Clock, Div = 7
    Public Const BITRATECSDB_57600BPS As UInt16 = &HF    '//External Clock, Div = 15
    Public Const BITRATECSDB_38400BPS As UInt16 = &H17    '//External Clock, Div = 23
    Public Const BITRATECSDB_28800BPS As UInt16 = &H1F    '//External Clock, Div = 31
    Public Const BITRATECSDB_19200BPS As UInt16 = &H2F    '//External Clock, Div = 47
    Public Const BITRATECSDB_14400BPS As UInt16 = &H3F    '//External Clock, Div = 63
    Public Const BITRATECSDB_9600BPS As UInt16 = &H5F '//External Clock, Div = 95
    Public Const BITRATECSDB_7200BPS As UInt16 = &H7F '//External Clock, Div = 127
    Public Const BITRATECSDB_4800BPS As UInt16 = &HBF '//External Clock, Div = 191
    Public Const BITRATECSDB_3600BPS As UInt16 = &HFF '//External Clock, Div = 255
    Public Const BITRATECSDB_2400BPS As UInt16 = &H17F '//External Clock, Div = 383
    Public Const BITRATECSDB_1800BPS As UInt16 = &H1FF '//External Clock, Div = 511
    Public Const BITRATECSDB_1200BPS As UInt16 = &H2FF '//External Clock, Div = 767
    Public Const BITRATECSDB_900BPS As UInt16 = &H3FF  '//External Clock, Div = 1023
    Public Const BITRATECSDB_600BPS As UInt16 = &H5FF  '//External Clock, Div = 1535
    Public Const BITRATECSDB_300BPS As UInt16 = &HBFF  '//External Clock, Div = 3071

    Public Const BITRATECSDB_500000BPS As UInt16 = &H8003   '//Internal Clock, Div = 3
    Public Const BITRATECSDB_400000BPS As UInt16 = &H8004   '//Internal Clock, Div = 4
    Public Const BITRATECSDB_250000BPS As UInt16 = &H8007   '//Internal Clock, Div = 7
    Public Const BITRATECSDB_200000BPS As UInt16 = &H8009   '//Internal Clock, Div = 9
    Public Const BITRATECSDB_100000BPS As UInt16 = &H8013   '//Internal Clock, Div = 19
    Public Const BITRATECSDB_80000BPS As UInt16 = &H8018    '//Internal Clock, Div = 24
    Public Const BITRATECSDB_50000BPS As UInt16 = &H8027    '//Internal Clock, Div = 39
    Public Const BITRATECSDB_40000BPS As UInt16 = &H8031    '//Internal Clock, Div = 49
    Public Const BITRATECSDB_25000BPS As UInt16 = &H804F    '//Internal Clock, Div = 79
    Public Const BITRATECSDB_20000BPS As UInt16 = &H8063    '//Internal Clock, Div = 99
    Public Const BITRATECSDB_12500BPS As UInt16 = &H809F    '//Internal Clock, Div = 159
    Public Const BITRATECSDB_10000BPS As UInt16 = &H80C7    '//Internal Clock, Div = 199

    Public Const BITRATECSDB_HIGHSPEED As UInt16 = &HC027   '//Internal Clock, Div = 39
    Public Const BITRATECSDB_LOWSPEED As UInt16 = &HC09F    '//Internal Clock, Div = 159

    '/**
    '*
    '*  SDI selection constants
    '*
    '**/

    Public Const SIALL As UInt32 = &HFF   '//Enable all SIs
    Public Const SIx00 As UInt32 = &H11   '//Enable SIx00
    Public Const SIx01 As UInt32 = &H22   '//Enable SIx01
    Public Const SIx10 As UInt32 = &H44   '//Enable SIx10
    Public Const SIx11 As UInt32 = &H88   '//Enable SIx11
    Public Const SI000 As UInt32 = &H1   '//Enable SI000
    Public Const SI001 As UInt32 = &H2   '//Enable SI001
    Public Const SI010 As UInt32 = &H4   '//Enable SI010
    Public Const SI011 As UInt32 = &H8   '//Enable SI011
    Public Const SI100 As UInt32 = &H10   '//Enable SI100
    Public Const SI101 As UInt32 = &H20   '//Enable SI101
    Public Const SI110 As UInt32 = &H40   '//Enable SI110
    Public Const SI111 As UInt32 = &H80   '//Enable SI111

    '/**
    '*
    '*  Channel configuration options
    '*
    '**/

    Public Const CHCFGCSDB_DEFAULT As UInt32 = &H0   '//Select all default settings (XMT & RCV) (default)
    Public Const CHCFGCSDB_SELFTESTOFF As UInt32 = &H0   '//Disable internal wraparound (XMT & RCV) (default)
    Public Const CHCFGCSDB_SELFTEST As UInt32 = &H4  '//Enable internal wraparound (XMT & RCV)
    Public Const CHCFGCSDB_PARITYODD As UInt32 = &H0 '//Enable odd parity (XMT & RCV) (default)
    Public Const CHCFGCSDB_PARITYNONE As UInt32 = 2147483648    '//Disable parity (XMT & RCV)
    Public Const CHCFGCSDB_PARITYEVEN As UInt32 = &H40000000    '//Enable even parity (XMT & RCV)
    Public Const CHCFGCSDB_PARITYMARK As UInt32 = &H20000000    '//Force set parity (XMT & RCV)
    Public Const CHCFGCSDB_PARITYSPACE As UInt32 = &H10000000   '//Force clear parity (XMT & RCV)
    Public Const CHCFGCSDB_ACTIVE As UInt32 = &H0    '//Enable channel activity (XMT & RCV) (default)
    Public Const CHCFGCSDB_INACTIVE As UInt32 = &H40  '//Disable channel activity (XMT & RCV)
    Public Const CHCFGCSDB_SEQSEL As UInt32 = &H0    '//Sequential record recording is enabled at message level (default)
    Public Const CHCFGCSDB_SEQALL As UInt32 = &H80000    '//Record entire channel in sequential record
    Public Const CHCFGCSDB_NOLOGHALT As UInt32 = &H0 '//No event log on schedule halt (default)
    Public Const CHCFGCSDB_LOGHALT As UInt32 = &H200000   '//Enable event log on schedule halt
    Public Const CHCFGCSDB_NOLOGPAUSE As UInt32 = &H0    '//No event log on schedule pause (default)
    Public Const CHCFGCSDB_LOGPAUSE As UInt32 = &H400000  '//Enable event log on schedule pause
    Public Const CHCFGCSDB_NOLOGERR As UInt32 = &H0  '//No event log on decoder errors (default)
    Public Const CHCFGCSDB_LOGERR As UInt32 = &H800000    '//Enable event log on decoder errors and sync errors.
    Public Const CHCFGCSDB_TIMETAGOFF As UInt32 = &H0    '//Time-tag is enabled on message level (default)
    Public Const CHCFGCSDB_TIMETAG As UInt32 = &H400   '//Enable time-tag for all message records
    Public Const CHCFGCSDB_NOHIT As UInt32 = &H0 '//Hit counter is enabled on message level (default)
    Public Const CHCFGCSDB_HIT As UInt32 = &H200   '//Hit counter is enabled for all messages
    Public Const CHCFGCSDB_ELAPSEOFF As UInt32 = &H0 '//Elapse time is enabled on message level (default)
    Public Const CHCFGCSDB_ELAPSE As UInt32 = &H800    '//Enable elapse time for all messages
    Public Const CHCFGCSDB_MAXMINOFF As UInt32 = &H0 '//Repetition rate monitoring is enabled on message level (default)
    Public Const CHCFGCSDB_MAX As UInt32 = &H1000   '//Enable max repetition rate monitoring for all messages
    Public Const CHCFGCSDB_MIN As UInt32 = &H2000   '//Enable min repetition rate monitoring for all messages
    Public Const CHCFGCSDB_MAXMIN As UInt32 = &H3000    '//Enable max and min repetition rate monitoring for all messages
    Public Const CHCFGCSDB_NOLOOPMAX As UInt32 = &H0 '//Disable schedule maximum loop count (default)
    Public Const CHCFGCSDB_LOOPMAX As UInt32 = &H100000   '//Enable schedule maximum loop count
    Public Const CHCFGCSDB_UNPAUSE As UInt32 = &H0   '//Mark channel as unpaused (default)
    Public Const CHCFGCSDB_PAUSE As UInt32 = &H1000000 '//Mark channel as paused
    Public Const CHCFGCSDB_BUSINVERTOFF As UInt32 = &H0  '//No bus inversion (default)
    Public Const CHCFGCSDB_BUSINVERT As UInt32 = &H1 '//Enable bus inversion
    Public Const CHCFGCSDB_MODE422 As UInt32 = &H0   '//Enable RS-422 mode (balanced) (XMT) (default)
    Public Const CHCFGCSDB_MODE232 As UInt32 = &H8000000   '//Enable RS-232 / RS-423 mode (unbalanced) (XMT)
    Public Const CHCFGCSDB_SYNCMODE As UInt32 = &H0  '//Synchronous scheduled mode (CSDB) (default)
    Public Const CHCFGCSDB_ASYNCMODE As UInt32 = &H2 '//Asynchrounous mode (general purpose serial)

    '/**
    '*
    '*  Message configuration options
    '*
    '**/

    Public Const MSGCRTCSDB_DEFAULT As UInt32 = &H0  '//Default settings
    Public Const MSGCRTCSDB_NOSEQ As UInt32 = &H0    '//Message will not be recorded in sequential record (default)
    Public Const MSGCRTCSDB_SEQ As UInt32 = &H1  '//Message will be recorded in sequential record
    Public Const MSGCRTCSDB_NOLOG As UInt32 = &H0    '//Message will not generate event log (default)
    Public Const MSGCRTCSDB_LOG As UInt32 = &H2  '//Message will generate event log
    Public Const MSGCRTCSDB_NOERROR As UInt32 = &H0  '//Message will not generate errors (default)
    Public Const MSGCRTCSDB_ERROR As UInt32 = &H4    '//Message can generate errors
    Public Const MSGCRTCSDB_NOSKIP As UInt32 = &H0   '//Message will not be skipped (default)
    Public Const MSGCRTCSDB_SKIP As UInt32 = &H8 '//Message will be skipped
    Public Const MSGCRTCSDB_NOTIMETAG As UInt32 = &H0    '//Message will not record time-tag (default)
    Public Const MSGCRTCSDB_TIMETAG As UInt32 = &H10  '//Message will record time-tag
    Public Const MSGCRTCSDB_NOELAPSE As UInt32 = &H0 '//Message will not record elapse time (default)
    Public Const MSGCRTCSDB_ELAPSE As UInt32 = &H20   '//Message will record elapse time
    Public Const MSGCRTCSDB_NOMAXMIN As UInt32 = &H0 '//Message will not record min/max time (default)
    Public Const MSGCRTCSDB_MAX As UInt32 = &H40  '//Message will record max time
    Public Const MSGCRTCSDB_MIN As UInt32 = &H80  '//Message will record min time
    Public Const MSGCRTCSDB_MAXMIN As UInt32 = &HC0   '//Message will record min/max time
    Public Const MSGCRTCSDB_NOHIT As UInt32 = &H0    '//Message will not record hit count (default)
    Public Const MSGCRTCSDB_HIT As UInt32 = &H800  '//Message will record hit count
    Public Const MSGCRTCSDB_WIPE As UInt32 = &H0 '//Enables message clear (default)
    Public Const MSGCRTCSDB_NOWIPE As UInt32 = 2147483648   '//Disables message clear
    Public Const MSGCRTCSDB_WIPE0 As UInt32 = &H0    '//Initialize data with zeros (default)
    Public Const MSGCRTCSDB_WIPE1 As UInt32 = &H40000000    '//Initialize data with ones
    Public Const MSGCRTCSDB_WIPESYNC As UInt32 = &H20000000 '//Initialize data with 0xA5
    Public Const MSGCRTCSDB_CONT As UInt32 = &H0 '//Selects continuous mode (default)
    Public Const MSGCRTCSDB_NONCONT As UInt32 = &H2000  '//Selects non-continuous mode
    Public Const MSGCRTCSDB_BURST As UInt32 = &H4000    '//Selects burst mode

    '/**
    '*
    '*  List buffer options
    '*
    '**/

    Public Const LISTCRTCSDB_DEFAULT As UInt32 = &H0 '//Select all default settings
    Public Const LISTCRTCSDB_FIFO As UInt32 = &H0    '//Enable FIFO mode (default)
    Public Const LISTCRTCSDB_PINGPONG As UInt32 = &H1    '//Enable ping-pong mode
    Public Const LISTCRTCSDB_CIRCULAR As UInt32 = &H2    '//Enable circular mode
    Public Const LISTCRTCSDB_RCV As UInt32 = &H10 '//User will read from list buffer
    Public Const LISTCRTCSDB_XMT As UInt32 = &H20 '//User will write to list buffer
    Public Const LISTCRTCSDB_NOLOG As UInt32 = &H0   '//Do not generate event log when list buffer empty/full (default)
    Public Const LISTCRTCSDB_LOG As UInt32 = &H100 '//Generate event log when list buffer empty/full

    '/**
    '*
    '*  Parametric configuration options
    '*
    '**/

    Public Const PARAMCFGCSDB_DEFAULT As UInt32 = &H0    '//Select all default settings (default)
    Public Const PARAMCFGCSDB_AMPLON As UInt32 = &H0 '//Enables parametric amplitude control (default)
    Public Const PARAMCFGCSDB_AMPLOFF As UInt32 = &H1    '//Disables parametric amplitude control

    '/**
    '*
    '*  Scheduling conditions.
    '*
    '**/

    Public Const CONDCSDB_ALWAYS As UInt32 = &H0 '//Unconditional
    Public Const CONDCSDB_DIO1ACT As UInt32 = &H1    '//Condition on digital I/O #1 active
    Public Const CONDCSDB_DIO1NACT As UInt32 = &H2   '//Condition on digital I/O #1 not active
    Public Const CONDCSDB_DIO2ACT As UInt32 = &H4    '//Condition on digital I/O #2 active
    Public Const CONDCSDB_DIO2NACT As UInt32 = &H8   '//Condition on digital I/O #2 not active
    Public Const CONDCSDB_DIO3ACT As UInt32 = &H10    '//Condition on digital I/O #3 active
    Public Const CONDCSDB_DIO3NACT As UInt32 = &H20   '//Condition on digital I/O #3 not active
    Public Const CONDCSDB_DIO4ACT As UInt32 = &H40    '//Condition on digital I/O #4 active
    Public Const CONDCSDB_DIO4NACT As UInt32 = &H80   '//Condition on digital I/O #4 not active
    Public Const CONDCSDB_DIO5ACT As UInt32 = &H100    '//Condition on digital I/O #5 active
    Public Const CONDCSDB_DIO5NACT As UInt32 = &H200   '//Condition on digital I/O #5 not active
    Public Const CONDCSDB_DIO6ACT As UInt32 = &H400    '//Condition on digital I/O #6 active
    Public Const CONDCSDB_DIO6NACT As UInt32 = &H800   '//Condition on digital I/O #6 not active
    Public Const CONDCSDB_DIO7ACT As UInt32 = &H1000    '//Condition on digital I/O #7 active
    Public Const CONDCSDB_DIO7NACT As UInt32 = &H2000   '//Condition on digital I/O #7 not active
    Public Const CONDCSDB_DIO8ACT As UInt32 = &H4000    '//Condition on digital I/O #8 active
    Public Const CONDCSDB_DIO8NACT As UInt32 = &H8000   '//Condition on digital I/O #8 not active

    '/**
    '*
    '*  Bit fields of the message activity flag.
    '*
    '**/

    Public Const MSGACTCSDB_CHMASK As UInt32 = &HFF00   '//Channel number mask value
    Public Const MSGACTCSDB_CHSHIFT As UInt32 = &H8  '//Channel number shift value
    Public Const MSGACTCSDB_ERR As UInt32 = &H80  '//Error bit
    Public Const MSGACTCSDB_BIT As UInt32 = &H40  '//Bit time error bit
    Public Const MSGACTCSDB_NRZ As UInt32 = &H20  '//NRZ bit error
    Public Const MSGACTCSDB_EDGE As UInt32 = &H10 '//Edge bit error
    Public Const MSGACTCSDB_PAR As UInt32 = &H8  '//Parity error bit
    Public Const MSGACTCSDB_FRAME As UInt32 = &H4    '//Frame error bit
    Public Const MSGACTCSDB_HIT As UInt32 = &H1  '//Always set

    '/**
    '*
    '*  Channel info fields.
    '*
    '**/

    Public Const INFOCSDB_PARAM As UInt32 = &H1  '//Channel supports parametric control

End Module
