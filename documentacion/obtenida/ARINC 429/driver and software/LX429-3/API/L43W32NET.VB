Imports System
Imports System.Runtime.InteropServices

Module L43W32VB

    '/**
    '*
    '*  LP429-3 and LC429-3 WIN32 DRIVER  Version 2.0.1  (05/27/2009)
    '*  Copyright (c) 1998-2009
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   L43W32NET.VB -- 32-bit
    '*                      L43 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  Structs used by the L43 Driver.
    '*
    '**/

    <StructLayout(LayoutKind.Sequential)> Public Structure MSGSTRUCT
        Public addr As UInt32
        Public data As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure SEQRECORD
        Public vercount As UInt16
        Public timestampl As UInt16
        Public timestamph As UInt16
        Public activity As UInt16
        Public data As UInt32
        Public wordnum As UInt16    '//ARINC 717 records only
        Public subframe As UInt16   '//ARINC 717 records only
        Public superframe As UInt16 '//ARINC 717 records only
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure MSGFIELDS
        Public msgopt As UInt16 '//User writes message optionvals
        Public msgact As UInt16 '//Card writes message activity
        Public msgdata_listptr As UInt32    '//Card/User writes message data (Rcv/Xmt) - '//User writes list buffer pointer
        Public timetag_hitcount As UInt32   '//Card writes time tag - '//Card writes hit count
        Public maxtime_elapsetime As UInt32 '//Card writes max time - '//Card writes elapsed time
        Public mintime As UInt32    '//Card writes min time
        Public userptr As UInt32    '//User writes user code pointer
        Public miscptr As UInt32    '//User writes misc. pointer
        Public rsvd As UInt32   '//Reserved
    End Structure

    '/**
    '*
    '*  L43 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  L43/717 functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the L43 Driver.
    '*
    '**/

    Public Declare Function L43_BCDGetData Lib "L43W32.DLL" Alias "_L43_BCDGetData@12" (ByVal msg As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
    Public Declare Function L43_BCDGetMant Lib "L43W32.DLL" Alias "_L43_BCDGetMant@8" (ByVal msg As UInt32, ByVal sigdig As UInt16) As UInt32
    Public Declare Function L43_BCDGetSign Lib "L43W32.DLL" Alias "_L43_BCDGetSign@4" (ByVal msg As UInt32) As UInt16
    Public Declare Function L43_BCDGetSSM Lib "L43W32.DLL" Alias "_L43_BCDGetSSM@4" (ByVal msg As UInt32) As UInt16
    Public Declare Sub L43_BCDGetVal Lib "L43W32.DLL" Alias "_L43_BCDGetVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigdig As UInt16, ByRef resolstr As String)
    Public Declare Function L43_BCDPutData Lib "L43W32.DLL" Alias "_L43_BCDPutData@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
    Public Declare Function L43_BCDPutMant Lib "L43W32.DLL" Alias "_L43_BCDPutMant@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal sigdig As UInt16, ByVal sign As UInt16) As UInt32
    Public Declare Function L43_BCDPutSign Lib "L43W32.DLL" Alias "_L43_BCDPutSign@8" (ByVal msg As UInt32, ByVal sign As UInt16) As UInt32
    Public Declare Function L43_BCDPutSSM Lib "L43W32.DLL" Alias "_L43_BCDPutSSM@8" (ByVal msg As UInt32, ByVal value As UInt16) As UInt32
    Public Declare Function L43_BCDPutVal Lib "L43W32.DLL" Alias "_L43_BCDPutVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigdig As UInt16, ByRef resolstr As String) As UInt32
    Public Declare Function L43_BNRGetData Lib "L43W32.DLL" Alias "_L43_BNRGetData@12" (ByVal msg As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
    Public Declare Function L43_BNRGetMant Lib "L43W32.DLL" Alias "_L43_BNRGetMant@8" (ByVal msg As UInt32, ByVal sigbit As UInt16) As UInt32
    Public Declare Function L43_BNRGetSign Lib "L43W32.DLL" Alias "_L43_BNRGetSign@4" (ByVal msg As UInt32) As UInt16
    Public Declare Function L43_BNRGetSSM Lib "L43W32.DLL" Alias "_L43_BNRGetSSM@4" (ByVal msg As UInt32) As UInt16
    Public Declare Sub L43_BNRGetVal Lib "L43W32.DLL" Alias "_L43_BNRGetVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigbit As UInt16, ByRef resolstr As String)
    Public Declare Function L43_BNRPutData Lib "L43W32.DLL" Alias "_L43_BNRPutData@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
    Public Declare Function L43_BNRPutMant Lib "L43W32.DLL" Alias "_L43_BNRPutMant@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal sigbit As UInt16, ByVal twos As UInt16) As UInt32
    Public Declare Function L43_BNRPutSign Lib "L43W32.DLL" Alias "_L43_BNRPutSign@8" (ByVal msg As UInt32, ByVal twos As UInt16) As UInt32
    Public Declare Function L43_BNRPutSSM Lib "L43W32.DLL" Alias "_L43_BNRPutSSM@8" (ByVal msg As UInt32, ByVal value As UInt16) As UInt32
    Public Declare Function L43_BNRPutVal Lib "L43W32.DLL" Alias "_L43_BNRPutVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigbit As UInt16, ByRef resolstr As String) As UInt32
    Public Declare Function L43_BrdNumRd Lib "L43W32.DLL" Alias "_L43_BrdNumRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_BrdNumWr Lib "L43W32.DLL" Alias "_L43_BrdNumWr@8" (ByVal brdnum As UInt16, ByVal handleval As UInt32)
    Public Declare Function L43_CardClose Lib "L43W32.DLL" Alias "_L43_CardClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CardOpen Lib "L43W32.DLL" Alias "_L43_CardOpen@4" (ByVal cardnum As Int32) As UInt32
    Public Declare Sub L43_CardReset Lib "L43W32.DLL" Alias "_L43_CardReset@4" (ByVal handleval As UInt32)
    Public Declare Function L43_CardResume Lib "L43W32.DLL" Alias "_L43_CardResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CardStart Lib "L43W32.DLL" Alias "_L43_CardStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CardStop Lib "L43W32.DLL" Alias "_L43_CardStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_CardTrigger Lib "L43W32.DLL" Alias "_L43_CardTrigger@4" (ByVal handleval As UInt32)
    Public Declare Function L43_ChClear Lib "L43W32.DLL" Alias "_L43_ChClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ChConfig Lib "L43W32.DLL" Alias "_L43_ChConfig@12" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_ChPause Lib "L43W32.DLL" Alias "_L43_ChPause@8" (ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_ChPauseCheck Lib "L43W32.DLL" Alias "_L43_ChPauseCheck@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_ChResume Lib "L43W32.DLL" Alias "_L43_ChResume@8" (ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_ExtDinRd Lib "L43W32.DLL" Alias "_L43_ExtDinRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_ExtDinWr Lib "L43W32.DLL" Alias "_L43_ExtDinWr@8" (ByVal dinval As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_ExtDIORd Lib "L43W32.DLL" Alias "_L43_ExtDIORd@8" (ByVal dionum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_ExtDIOWr Lib "L43W32.DLL" Alias "_L43_ExtDIOWr@12" (ByVal dionum As Int32, ByVal dioval As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_ExtLEDRd Lib "L43W32.DLL" Alias "_L43_ExtLEDRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_ExtLEDWr Lib "L43W32.DLL" Alias "_L43_ExtLEDWr@8" (ByVal ledval As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_FilterClear Lib "L43W32.DLL" Alias "_L43_FilterClear@8" (ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_FilterDefault Lib "L43W32.DLL" Alias "_L43_FilterDefault@12" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_FilterRd Lib "L43W32.DLL" Alias "_L43_FilterRd@16" (ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_FilterSet Lib "L43W32.DLL" Alias "_L43_FilterSet@20" (ByVal configval As UInt32, ByVal labelval As Int32, ByVal sdimask As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_FilterWr Lib "L43W32.DLL" Alias "_L43_FilterWr@20" (ByVal msgaddr As UInt32, ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_FldGetData Lib "L43W32.DLL" Alias "_L43_FldGetData@4" (ByVal msgval As UInt32) As UInt32
    Public Declare Function L43_FldGetLabel Lib "L43W32.DLL" Alias "_L43_FldGetLabel@4" (ByVal msgval As UInt32) As UInt16
    Public Declare Function L43_FldGetParity Lib "L43W32.DLL" Alias "_L43_FldGetParity@4" (ByVal msgval As UInt32) As UInt16
    Public Declare Function L43_FldGetSDI Lib "L43W32.DLL" Alias "_L43_FldGetSDI@4" (ByVal msgval As UInt32) As UInt16
    Public Declare Function L43_FldGetValue Lib "L43W32.DLL" Alias "_L43_FldGetValue@12" (ByVal msgval As UInt32, ByVal startbit As UInt16, ByVal endbit As UInt16) As UInt32
    Public Declare Function L43_FldPutData Lib "L43W32.DLL" Alias "_L43_FldPutData@8" (ByVal msgval As UInt32, ByVal data As UInt32) As UInt32
    Public Declare Function L43_FldPutLabel Lib "L43W32.DLL" Alias "_L43_FldPutLabel@8" (ByVal msgval As UInt32, ByVal label As UInt16) As UInt32
    Public Declare Function L43_FldPutSDI Lib "L43W32.DLL" Alias "_L43_FldPutSDI@8" (ByVal msgval As UInt32, ByVal sdi As UInt16) As UInt32
    Public Declare Function L43_FldPutValue Lib "L43W32.DLL" Alias "_L43_FldPutValue@16" (ByVal msgval As UInt32, ByVal dataval As UInt32, ByVal startbit As UInt16, ByVal endbit As UInt16) As UInt32
    Public Declare Sub L43_GetChanCount Lib "L43W32.DLL" Alias "_L43_GetChanCount@12" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_IntConfig Lib "L43W32.DLL" Alias "_L43_IntConfig@12" (ByVal configval As UInt16, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_IntInstall Lib "L43W32.DLL" Alias "_L43_IntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_IntRd Lib "L43W32.DLL" Alias "_L43_IntRd@12" (ByRef typevalval As UInt16, ByRef infoval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L43_IntReset Lib "L43W32.DLL" Alias "_L43_IntReset@4" (ByVal handleval As UInt32)
    Public Declare Function L43_IntStatus Lib "L43W32.DLL" Alias "_L43_IntStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_IntUninstall Lib "L43W32.DLL" Alias "_L43_IntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_IsChan Lib "L43W32.DLL" Alias "_L43_IsChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_IsRcvChan Lib "L43W32.DLL" Alias "_L43_IsRcvChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_IsXmtChan Lib "L43W32.DLL" Alias "_L43_IsXmtChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ListAsyncCreate Lib "L43W32.DLL" Alias "_L43_ListAsyncCreate@16" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_ListDataRd Lib "L43W32.DLL" Alias "_L43_ListDataRd@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_ListDataWr Lib "L43W32.DLL" Alias "_L43_ListDataWr@12" (ByVal value As UInt32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ListRcvCreate Lib "L43W32.DLL" Alias "_L43_ListRcvCreate@16" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_ListXmtCreate Lib "L43W32.DLL" Alias "_L43_ListXmtCreate@16" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_MsgBlockRd Lib "L43W32.DLL" Alias "_L43_MsgBlockRd@12" (ByRef msgfields As MSGFIELDS, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_MsgBlockWr Lib "L43W32.DLL" Alias "_L43_MsgBlockWr@12" (ByRef msgfields As MSGFIELDS, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_MsgCommRd Lib "L43W32.DLL" Alias "_L43_MsgCommRd@12" (ByRef msgfields As MSGFIELDS, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_MsgCommWr Lib "L43W32.DLL" Alias "_L43_MsgCommWr@12" (ByRef msgfields As MSGFIELDS, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_MsgCreate Lib "L43W32.DLL" Alias "_L43_MsgCreate@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_MsgDataRd Lib "L43W32.DLL" Alias "_L43_MsgDataRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L43_MsgDataWr Lib "L43W32.DLL" Alias "_L43_MsgDataWr@12" (ByVal value As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_MsgIsAccessed Lib "L43W32.DLL" Alias "_L43_MsgIsAccessed@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedBranch Lib "L43W32.DLL" Alias "_L43_SchedBranch@16" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedBuild Lib "L43W32.DLL" Alias "_L43_SchedBuild@24" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedCall Lib "L43W32.DLL" Alias "_L43_SchedCall@16" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedEntry Lib "L43W32.DLL" Alias "_L43_SchedEntry@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedGap Lib "L43W32.DLL" Alias "_L43_SchedGap@12" (ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedGapFixed Lib "L43W32.DLL" Alias "_L43_SchedGapFixed@12" (ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedGapList Lib "L43W32.DLL" Alias "_L43_SchedGapList@16" (ByVal gapval As UInt16, ByVal listaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedHalt Lib "L43W32.DLL" Alias "_L43_SchedHalt@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedInt Lib "L43W32.DLL" Alias "_L43_SchedInt@16" (ByVal condition As UInt16, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedMsg Lib "L43W32.DLL" Alias "_L43_SchedMsg@12" (ByVal msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedMsgEx Lib "L43W32.DLL" Alias "_L43_SchedMsgEx@16" (ByVal msgaddr As UInt32, ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedPause Lib "L43W32.DLL" Alias "_L43_SchedPause@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedPulse Lib "L43W32.DLL" Alias "_L43_SchedPulse@12" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedRestart Lib "L43W32.DLL" Alias "_L43_SchedRestart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedReturn Lib "L43W32.DLL" Alias "_L43_SchedReturn@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SeqConfig Lib "L43W32.DLL" Alias "_L43_SeqConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SeqInterval Lib "L43W32.DLL" Alias "_L43_SeqInterval@12" (ByVal interval As Int32, ByVal mode As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SeqIntFrequency Lib "L43W32.DLL" Alias "_L43_SeqIntFrequency@8" (ByVal intfreq As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_SeqIsRunning Lib "L43W32.DLL" Alias "_L43_SeqIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SeqRd Lib "L43W32.DLL" Alias "_L43_SeqRd@8" (ByRef buf As SEQRECORD, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_SeqStatus Lib "L43W32.DLL" Alias "_L43_SeqStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_TimerClear Lib "L43W32.DLL" Alias "_L43_TimerClear@4" (ByVal handleval As UInt32)
    Public Declare Function L43_TimerRd Lib "L43W32.DLL" Alias "_L43_TimerRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_TimerResolution Lib "L43W32.DLL" Alias "_L43_TimerResolution@8" (ByVal timerresol As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_Ch717Status Lib "L43W32.DLL" Alias "_L43_Ch717Status@12" (ByRef buf As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_Get717ChanCount Lib "L43W32.DLL" Alias "_L43_Get717ChanCount@12" (ByRef rcvcount As Int32, ByRef xmtcount As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_Is717BiPhaseChan Lib "L43W32.DLL" Alias "_L43_Is717BiPhaseChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_Is717Chan Lib "L43W32.DLL" Alias "_L43_Is717Chan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_Is717RcvChan Lib "L43W32.DLL" Alias "_L43_Is717RcvChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_Is717XmtChan Lib "L43W32.DLL" Alias "_L43_Is717XmtChan@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SubFrmBlkRd Lib "L43W32.DLL" Alias "_L43_SubFrmBlkRd@16" (ByRef databuf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SubFrmBlkWr Lib "L43W32.DLL" Alias "_L43_SubFrmBlkWr@16" (ByRef databuf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SubFrmStatus Lib "L43W32.DLL" Alias "_L43_SubFrmStatus@16" (ByRef buf As UInt16, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SubFrmWordConfig Lib "L43W32.DLL" Alias "_L43_SubFrmWordConfig@20" (ByVal configval As UInt32, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SubFrmWordRd Lib "L43W32.DLL" Alias "_L43_SubFrmWordRd@20" (ByRef value As UInt16, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SubFrmWordWr Lib "L43W32.DLL" Alias "_L43_SubFrmWordWr@20" (ByVal value As UInt16, ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SuperFrmConfig Lib "L43W32.DLL" Alias "_L43_SuperFrmConfig@16" (ByVal count As Int32, ByVal framespersuperframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SuperFrmCounterPos Lib "L43W32.DLL" Alias "_L43_SuperFrmCounterPos@16" (ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SuperFrmDefine Lib "L43W32.DLL" Alias "_L43_SuperFrmDefine@16" (ByVal subframe As Int32, ByVal word As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_SuperFrmWordRd Lib "L43W32.DLL" Alias "_L43_SuperFrmWordRd@20" (ByRef value As UInt16, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SuperFrmWordWr Lib "L43W32.DLL" Alias "_L43_SuperFrmWordWr@20" (ByVal value As UInt16, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SuperFrmWordConfig Lib "L43W32.DLL" Alias "_L43_SuperFrmWordConfig@20" (ByVal configval As UInt32, ByVal superfrmnum As Int32, ByVal superfrmaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SyncTest Lib "L43W32.DLL" Alias "_L43_SyncTest@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SyncValRd Lib "L43W32.DLL" Alias "_L43_SyncValRd@24" (ByRef syncword1 As Int32, ByRef syncword2 As Int32, ByRef syncword3 As Int32, ByRef syncword4 As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SyncValWr Lib "L43W32.DLL" Alias "_L43_SyncValWr@24" (ByVal syncword1 As Int32, ByVal syncword2 As Int32, ByVal syncword3 As Int32, ByVal syncword4 As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_AddrDSP Lib "L43W32.DLL" Alias "_L43_AddrDSP@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function L43_AddrHost Lib "L43W32.DLL" Alias "_L43_AddrHost@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function L43_AsciiToMant Lib "L43W32.DLL" Alias "_L43_AsciiToMant@12" (ByRef str As String, ByRef mant As UInt32, ByRef exp As Int32) As Int32
    Public Declare Function L43_CardBoot Lib "L43W32.DLL" Alias "_L43_CardBoot@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CardCloseAll Lib "L43W32.DLL" Alias "_L43_CardCloseAll@0" () As Int32
    Public Declare Function L43_CardGetInfo Lib "L43W32.DLL" Alias "_L43_CardGetInfo@8" (ByVal infotype As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_CardGetInfoEx Lib "L43W32.DLL" Alias "_L43_CardGetInfoEx@20" (ByRef bufmodel As UInt16, ByVal bufmodelcount As UInt16, ByRef buffeature As UInt16, ByVal buffeaturecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_CardInit Lib "L43W32.DLL" Alias "_L43_CardInit@0" ()
    Public Declare Function L43_CardIsRunning Lib "L43W32.DLL" Alias "_L43_CardIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CardNop Lib "L43W32.DLL" Alias "_L43_CardNop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CardOpenEx Lib "L43W32.DLL" Alias "_L43_CardOpenEx@8" (ByRef cardname As String, ByVal cardnum As Int32) As UInt32
    Public Declare Function L43_CardOpenExx Lib "L43W32.DLL" Alias "_L43_CardOpenExx@16" (ByRef cardname As String, ByVal cardnum As Int32, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Sub L43_CardResetEx Lib "L43W32.DLL" Alias "_L43_CardResetEx@4" (ByVal handleval As UInt32)
    Public Declare Function L43_CardTest Lib "L43W32.DLL" Alias "_L43_CardTest@8" (ByVal level As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CardTest0 Lib "L43W32.DLL" Alias "_L43_CardTest0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CardTest1 Lib "L43W32.DLL" Alias "_L43_CardTest1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CardTest2 Lib "L43W32.DLL" Alias "_L43_CardTest2@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CardTest3 Lib "L43W32.DLL" Alias "_L43_CardTest3@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CFGRdL Lib "L43W32.DLL" Alias "_L43_CFGRdL@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L43_CFGWrL Lib "L43W32.DLL" Alias "_L43_CFGWrL@12" (ByVal value As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_Ch717Config Lib "L43W32.DLL" Alias "_L43_Ch717Config@12" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_Ch717Create Lib "L43W32.DLL" Alias "_L43_Ch717Create@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_Ch717Reset Lib "L43W32.DLL" Alias "_L43_Ch717Reset@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ChConfigEx Lib "L43W32.DLL" Alias "_L43_ChConfigEx@16" (ByVal configval As UInt32, ByVal count As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_ChDARClr Lib "L43W32.DLL" Alias "_L43_ChDARClr@16" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_ChDARGet Lib "L43W32.DLL" Alias "_L43_ChDARGet@16" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ChDARRdL Lib "L43W32.DLL" Alias "_L43_ChDARRdL@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_ChDARRdW Lib "L43W32.DLL" Alias "_L43_ChDARRdW@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_ChDARSet Lib "L43W32.DLL" Alias "_L43_ChDARSet@16" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_ChDARWrL Lib "L43W32.DLL" Alias "_L43_ChDARWrL@16" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_ChDARWrW Lib "L43W32.DLL" Alias "_L43_ChDARWrW@16" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_ChStart Lib "L43W32.DLL" Alias "_L43_ChStart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ChStop Lib "L43W32.DLL" Alias "_L43_ChStop@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CmdAddr Lib "L43W32.DLL" Alias "_L43_CmdAddr@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_CmdAlloc Lib "L43W32.DLL" Alias "_L43_CmdAlloc@8" (ByVal count As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_CmdAllocEx Lib "L43W32.DLL" Alias "_L43_CmdAllocEx@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_CmdBaseRd Lib "L43W32.DLL" Alias "_L43_CmdBaseRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L43_CmdBaseWr Lib "L43W32.DLL" Alias "_L43_CmdBaseWr@12" (ByVal addrval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_CmdClear Lib "L43W32.DLL" Alias "_L43_CmdClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CmdCountRd Lib "L43W32.DLL" Alias "_L43_CmdCountRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_CmdCountWr Lib "L43W32.DLL" Alias "_L43_CmdCountWr@12" (ByVal countval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_CmdCtrlRd Lib "L43W32.DLL" Alias "_L43_CmdCtrlRd@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_CmdCtrlWr Lib "L43W32.DLL" Alias "_L43_CmdCtrlWr@16" (ByVal ctrlval As UInt16, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_CmdCurrRd Lib "L43W32.DLL" Alias "_L43_CmdCurrRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_CmdCurrWr Lib "L43W32.DLL" Alias "_L43_CmdCurrWr@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_CmdInit Lib "L43W32.DLL" Alias "_L43_CmdInit@8" (ByVal opcode As UInt16, ByRef block As UInt16)
    Public Declare Function L43_CmdInsert Lib "L43W32.DLL" Alias "_L43_CmdInsert@12" (ByRef block As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CmdMaxRd Lib "L43W32.DLL" Alias "_L43_CmdMaxRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_CmdMaxWr Lib "L43W32.DLL" Alias "_L43_CmdMaxWr@12" (ByVal count As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_CmdRd Lib "L43W32.DLL" Alias "_L43_CmdRd@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CmdShotWr Lib "L43W32.DLL" Alias "_L43_CmdShotWr@16" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CmdSkipWr Lib "L43W32.DLL" Alias "_L43_CmdSkipWr@16" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_CmdStackClr Lib "L43W32.DLL" Alias "_L43_CmdStackClr@8" (ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_CmdStartRd Lib "L43W32.DLL" Alias "_L43_CmdStartRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_CmdStartWr Lib "L43W32.DLL" Alias "_L43_CmdStartWr@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_CmdStepWr Lib "L43W32.DLL" Alias "_L43_CmdStepWr@16" (ByVal value As Int32, ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CmdTotalRd Lib "L43W32.DLL" Alias "_L43_CmdTotalRd@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_CmdTotalWr Lib "L43W32.DLL" Alias "_L43_CmdTotalWr@12" (ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_CmdWr Lib "L43W32.DLL" Alias "_L43_CmdWr@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CommCall Lib "L43W32.DLL" Alias "_L43_CommCall@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CommCheck Lib "L43W32.DLL" Alias "_L43_CommCheck@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CommDisable Lib "L43W32.DLL" Alias "_L43_CommDisable@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CommDisableEx Lib "L43W32.DLL" Alias "_L43_CommDisableEx@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CommEnable Lib "L43W32.DLL" Alias "_L43_CommEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CommRdL Lib "L43W32.DLL" Alias "_L43_CommRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_CommRdsW Lib "L43W32.DLL" Alias "_L43_CommRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_CommRdW Lib "L43W32.DLL" Alias "_L43_CommRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_CommRun Lib "L43W32.DLL" Alias "_L43_CommRun@20" (ByRef dataptr As UInt16, ByVal datacount As UInt16, ByRef codeptr As UInt16, ByVal codecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_CommWrL Lib "L43W32.DLL" Alias "_L43_CommWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_CommWrsW Lib "L43W32.DLL" Alias "_L43_CommWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_CommWrW Lib "L43W32.DLL" Alias "_L43_CommWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_ConvFromArinc Lib "L43W32.DLL" Alias "_L43_ConvFromArinc@4" (ByVal msgval As UInt32) As UInt32
    Public Declare Function L43_ConvToArinc Lib "L43W32.DLL" Alias "_L43_ConvToArinc@4" (ByVal msgval As UInt32) As UInt32
    Public Declare Sub L43_DARClr Lib "L43W32.DLL" Alias "_L43_DARClr@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L43_DARGet Lib "L43W32.DLL" Alias "_L43_DARGet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_DARRdL Lib "L43W32.DLL" Alias "_L43_DARRdL@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_DARRdW Lib "L43W32.DLL" Alias "_L43_DARRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_DARSet Lib "L43W32.DLL" Alias "_L43_DARSet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L43_DARWrL Lib "L43W32.DLL" Alias "_L43_DARWrL@12" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L43_DARWrW Lib "L43W32.DLL" Alias "_L43_DARWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L43_Div Lib "L43W32.DLL" Alias "_L43_Div@8" (ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
    Public Declare Function L43_DllUsageCount Lib "L43W32.DLL" Alias "_L43_DllUsageCount@0" () As Int32
    Public Declare Function L43_DPMMRdW Lib "L43W32.DLL" Alias "_L43_DPMMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_DPMMWrW Lib "L43W32.DLL" Alias "_L43_DPMMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_DPMRdB Lib "L43W32.DLL" Alias "_L43_DPMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_DPMRdL Lib "L43W32.DLL" Alias "_L43_DPMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L43_DPMRdsL Lib "L43W32.DLL" Alias "_L43_DPMRdsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_DPMRdsW Lib "L43W32.DLL" Alias "_L43_DPMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_DPMRdW Lib "L43W32.DLL" Alias "_L43_DPMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_DPMWrB Lib "L43W32.DLL" Alias "_L43_DPMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L43_DPMWrL Lib "L43W32.DLL" Alias "_L43_DPMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L43_DPMWrsL Lib "L43W32.DLL" Alias "_L43_DPMWrsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_DPMWrsW Lib "L43W32.DLL" Alias "_L43_DPMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_DPMWrW Lib "L43W32.DLL" Alias "_L43_DPMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_DspBioRd Lib "L43W32.DLL" Alias "_L43_DspBioRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_DspHmClear Lib "L43W32.DLL" Alias "_L43_DspHmClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_DspHmSet Lib "L43W32.DLL" Alias "_L43_DspHmSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_DspIntfClear Lib "L43W32.DLL" Alias "_L43_DspIntfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_DspIntfRead Lib "L43W32.DLL" Alias "_L43_DspIntfRead@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_DspIntmClear Lib "L43W32.DLL" Alias "_L43_DspIntmClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_DspIntmSet Lib "L43W32.DLL" Alias "_L43_DspIntmSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_DspXfClear Lib "L43W32.DLL" Alias "_L43_DspXfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_DspXfSet Lib "L43W32.DLL" Alias "_L43_DspXfSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ErrDesc Lib "L43W32.DLL" Alias "_L43_ErrDesc@4" (ByVal errval As Int32) As UInt32
    Public Declare Function L43_ErrDescStr Lib "L43W32.DLL" Alias "_L43_ErrDescStr@4" (ByVal errval As Int32) As UInt32
    Public Declare Function L43_ErrName Lib "L43W32.DLL" Alias "_L43_ErrName@4" (ByVal errval As Int32) As UInt32
    Public Declare Sub L43_ExpandMant Lib "L43W32.DLL" Alias "_L43_ExpandMant@8" (ByRef mant As UInt32, ByRef exp As Int32)
    Public Declare Sub L43_ExtDIODirSet Lib "L43W32.DLL" Alias "_L43_ExtDIODirSet@12" (ByVal dionum As Int32, ByVal dirval As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_ExtLEDWINRd Lib "L43W32.DLL" Alias "_L43_ExtLEDWINRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_ExtLEDWINWr Lib "L43W32.DLL" Alias "_L43_ExtLEDWINWr@8" (ByVal ledval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_FileClose Lib "L43W32.DLL" Alias "_L43_FileClose@4" (ByVal handle As IntPtr)
    Public Declare Function L43_FileErr Lib "L43W32.DLL" Alias "_L43_FileErr@0" () As Int32
    Public Declare Sub L43_FileErrClr Lib "L43W32.DLL" Alias "_L43_FileErrClr@0" ()
    Public Declare Sub L43_FileErrSet Lib "L43W32.DLL" Alias "_L43_FileErrSet@0" ()
    Public Declare Function L43_FileOpenRead Lib "L43W32.DLL" Alias "_L43_FileOpenRead@4" (ByRef filename As String) As UInt32
    Public Declare Function L43_FileOpenWrite Lib "L43W32.DLL" Alias "_L43_FileOpenWrite@4" (ByRef filename As String) As UInt32
    Public Declare Function L43_FileRead Lib "L43W32.DLL" Alias "_L43_FileRead@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function L43_FileSeek Lib "L43W32.DLL" Alias "_L43_FileSeek@8" (ByVal handle As IntPtr, ByVal offset As UInt32) As Int32
    Public Declare Function L43_FileTell Lib "L43W32.DLL" Alias "_L43_FileTell@4" (ByVal handle As IntPtr) As UInt32
    Public Declare Function L43_FileWrite Lib "L43W32.DLL" Alias "_L43_FileWrite@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function L43_FilterAddr Lib "L43W32.DLL" Alias "_L43_FilterAddr@16" (ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_FilterCreate Lib "L43W32.DLL" Alias "_L43_FilterCreate@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_FilterFill Lib "L43W32.DLL" Alias "_L43_FilterFill@12" (ByVal msgaddr As UInt32, ByVal basevaladdr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_FldGetParBit Lib "L43W32.DLL" Alias "_L43_FldGetParBit@4" (ByVal msgval As UInt32) As UInt16
    Public Declare Function L43_FldPutParBit Lib "L43W32.DLL" Alias "_L43_FldPutParBit@4" (ByVal msgval As UInt32) As UInt32
    Public Declare Function L43_GetHigh Lib "L43W32.DLL" Alias "_L43_GetHigh@4" (ByVal val As UInt32) As UInt16
    Public Declare Function L43_GetLow Lib "L43W32.DLL" Alias "_L43_GetLow@4" (ByVal val As UInt32) As UInt16
    Public Declare Function L43_GlobalRdW Lib "L43W32.DLL" Alias "_L43_GlobalRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_GlobalWrW Lib "L43W32.DLL" Alias "_L43_GlobalWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L43_HandleClose Lib "L43W32.DLL" Alias "_L43_HandleClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_HandleDel Lib "L43W32.DLL" Alias "_L43_HandleDel@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_HandleGet Lib "L43W32.DLL" Alias "_L43_HandleGet@20" (ByRef cardstr As String, ByRef cardnum As Int32, ByRef devnum As Int32, ByRef sizval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_HandleIns Lib "L43W32.DLL" Alias "_L43_HandleIns@16" (ByRef cardname As String, ByVal cardnum As Int32, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Function L43_HandleOkay Lib "L43W32.DLL" Alias "_L43_HandleOkay@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_HandleOpen Lib "L43W32.DLL" Alias "_L43_HandleOpen@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_HandleOpenWin95 Lib "L43W32.DLL" Alias "_L43_HandleOpenWin95@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_HandleOpenWinNT Lib "L43W32.DLL" Alias "_L43_HandleOpenWinNT@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_HandleVer Lib "L43W32.DLL" Alias "_L43_HandleVer@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_HandleVerPLX Lib "L43W32.DLL" Alias "_L43_HandleVerPLX@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_HeapAlloc Lib "L43W32.DLL" Alias "_L43_HeapAlloc@8" (ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_HeapAllocAll Lib "L43W32.DLL" Alias "_L43_HeapAllocAll@8" (ByRef wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_HeapAllocAllDPM Lib "L43W32.DLL" Alias "_L43_HeapAllocAllDPM@8" (ByRef wordcount As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_HeapAllocDPM Lib "L43W32.DLL" Alias "_L43_HeapAllocDPM@8" (ByVal wordcount As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_HeapAllocEx Lib "L43W32.DLL" Alias "_L43_HeapAllocEx@12" (ByVal configval As UInt16, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_HeapWipe Lib "L43W32.DLL" Alias "_L43_HeapWipe@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_HeapWipeDPM Lib "L43W32.DLL" Alias "_L43_HeapWipeDPM@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_IndirectRd Lib "L43W32.DLL" Alias "_L43_IndirectRd@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_IndirectWr Lib "L43W32.DLL" Alias "_L43_IndirectWr@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_IntClear Lib "L43W32.DLL" Alias "_L43_IntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_IntDisable Lib "L43W32.DLL" Alias "_L43_IntDisable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_IntEnable Lib "L43W32.DLL" Alias "_L43_IntEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_IntEnableCond Lib "L43W32.DLL" Alias "_L43_IntEnableCond@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_IntGet Lib "L43W32.DLL" Alias "_L43_IntGet@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_IORdW Lib "L43W32.DLL" Alias "_L43_IORdW@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_IOWINRdW Lib "L43W32.DLL" Alias "_L43_IOWINRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_IOWINWrW Lib "L43W32.DLL" Alias "_L43_IOWINWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L43_IOWrW Lib "L43W32.DLL" Alias "_L43_IOWrW@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_KernDev Lib "L43W32.DLL" Alias "_L43_KernDev@8" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernEnd Lib "L43W32.DLL" Alias "_L43_KernEnd@4" (ByVal vxdptr As IntPtr) As Int32
    Public Declare Function L43_KernIntClear Lib "L43W32.DLL" Alias "_L43_KernIntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernIntInstall Lib "L43W32.DLL" Alias "_L43_KernIntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernIntParam Lib "L43W32.DLL" Alias "_L43_KernIntParam@32" (ByVal clraddr As UInt32, ByVal clrwidth As UInt32, ByVal clrvalue As UInt32, ByVal stataddr As UInt32, ByVal statwidth As UInt32, ByVal statvalue As UInt32, ByVal statmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernIntStatus Lib "L43W32.DLL" Alias "_L43_KernIntStatus@8" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernIntUninstall Lib "L43W32.DLL" Alias "_L43_KernIntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernIORdW Lib "L43W32.DLL" Alias "_L43_KernIORdW@12" (ByRef valueptr As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernIOWrW Lib "L43W32.DLL" Alias "_L43_KernIOWrW@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernMEMFillW Lib "L43W32.DLL" Alias "_L43_KernMEMFillW@20" (ByVal value As UInt16, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernMEMRdL Lib "L43W32.DLL" Alias "_L43_KernMEMRdL@16" (ByRef valueptr As UInt32, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernMEMRdsL Lib "L43W32.DLL" Alias "_L43_KernMEMRdsL@20" (ByRef bufptr As UInt32, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernMEMRdsW Lib "L43W32.DLL" Alias "_L43_KernMEMRdsW@20" (ByRef bufptr As UInt16, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernMEMRdW Lib "L43W32.DLL" Alias "_L43_KernMEMRdW@16" (ByRef valueptr As UInt16, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernMEMWrL Lib "L43W32.DLL" Alias "_L43_KernMEMWrL@16" (ByVal value As UInt32, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernMEMWrsL Lib "L43W32.DLL" Alias "_L43_KernMEMWrsL@20" (ByRef bufptr As UInt32, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernMEMWrsW Lib "L43W32.DLL" Alias "_L43_KernMEMWrsW@20" (ByRef bufptr As UInt16, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernMEMWrW Lib "L43W32.DLL" Alias "_L43_KernMEMWrW@16" (ByVal value As UInt16, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernQuick Lib "L43W32.DLL" Alias "_L43_KernQuick@8" (ByVal flag As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernStatus Lib "L43W32.DLL" Alias "_L43_KernStatus@12" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_KernStatusEx Lib "L43W32.DLL" Alias "_L43_KernStatusEx@16" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal index As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_LabelReverse Lib "L43W32.DLL" Alias "_L43_LabelReverse@4" (ByVal msgval As UInt32) As UInt32
    Public Declare Function L43_ListAddr Lib "L43W32.DLL" Alias "_L43_ListAddr@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_ListAddrEx Lib "L43W32.DLL" Alias "_L43_ListAddrEx@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Function L43_ListAdvance Lib "L43W32.DLL" Alias "_L43_ListAdvance@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ListClear Lib "L43W32.DLL" Alias "_L43_ListClear@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ListConfig Lib "L43W32.DLL" Alias "_L43_ListConfig@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_ListConfigEx Lib "L43W32.DLL" Alias "_L43_ListConfigEx@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_ListDataBlkWr Lib "L43W32.DLL" Alias "_L43_ListDataBlkWr@16" (ByRef dataptr As UInt32, ByVal datacount As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ListDataRdEx Lib "L43W32.DLL" Alias "_L43_ListDataRdEx@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L43_ListDataWrEx Lib "L43W32.DLL" Alias "_L43_ListDataWrEx@16" (ByVal value As UInt32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_ListInit Lib "L43W32.DLL" Alias "_L43_ListInit@12" (ByVal listaddr As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_ListNextRd Lib "L43W32.DLL" Alias "_L43_ListNextRd@8" (ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Function L43_ListNextWr Lib "L43W32.DLL" Alias "_L43_ListNextWr@8" (ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Sub L43_ListPostRd Lib "L43W32.DLL" Alias "_L43_ListPostRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L43_ListPostWr Lib "L43W32.DLL" Alias "_L43_ListPostWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L43_ListPreRd Lib "L43W32.DLL" Alias "_L43_ListPreRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L43_ListPreWr Lib "L43W32.DLL" Alias "_L43_ListPreWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Function L43_ListStatus Lib "L43W32.DLL" Alias "_L43_ListStatus@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_MakeLong Lib "L43W32.DLL" Alias "_L43_MakeLong@8" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
    Public Declare Function L43_MantToAscii Lib "L43W32.DLL" Alias "_L43_MantToAscii@12" (ByRef buf As String, ByVal mant As Int32, ByVal exp As Int32) As UInt32
    Public Declare Function L43_Mask Lib "L43W32.DLL" Alias "_L43_Mask@8" (ByVal dataval As UInt32, ByVal cntval As Int32) As UInt32
    Public Declare Sub L43_MaxMant Lib "L43W32.DLL" Alias "_L43_MaxMant@8" (ByRef mant As UInt32, ByRef exp As Int32)
    Public Declare Sub L43_MEMWINFillW Lib "L43W32.DLL" Alias "_L43_MEMWINFillW@20" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_MEMWINRdB Lib "L43W32.DLL" Alias "_L43_MEMWINRdB@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_MEMWINRdL Lib "L43W32.DLL" Alias "_L43_MEMWINRdL@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L43_MEMWINRdsL Lib "L43W32.DLL" Alias "_L43_MEMWINRdsL@20" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_MEMWINRdsW Lib "L43W32.DLL" Alias "_L43_MEMWINRdsW@20" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_MEMWINRdW Lib "L43W32.DLL" Alias "_L43_MEMWINRdW@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_MEMWINWrB Lib "L43W32.DLL" Alias "_L43_MEMWINWrB@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_MEMWINWrL Lib "L43W32.DLL" Alias "_L43_MEMWINWrL@16" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_MEMWINWrsL Lib "L43W32.DLL" Alias "_L43_MEMWINWrsL@20" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_MEMWINWrsW Lib "L43W32.DLL" Alias "_L43_MEMWINWrsW@20" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_MEMWINWrW Lib "L43W32.DLL" Alias "_L43_MEMWINWrW@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_Mod Lib "L43W32.DLL" Alias "_L43_Mod@8" (ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
    Public Declare Function L43_MsgActivityRd Lib "L43W32.DLL" Alias "_L43_MsgActivityRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_MsgActivityWr Lib "L43W32.DLL" Alias "_L43_MsgActivityWr@12" (ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_MsgCheck Lib "L43W32.DLL" Alias "_L43_MsgCheck@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_MsgConfig Lib "L43W32.DLL" Alias "_L43_MsgConfig@12" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_MsgOptRd Lib "L43W32.DLL" Alias "_L43_MsgOptRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_MsgOptWr Lib "L43W32.DLL" Alias "_L43_MsgOptWr@12" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_MsgReset Lib "L43W32.DLL" Alias "_L43_MsgReset@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_Mul Lib "L43W32.DLL" Alias "_L43_Mul@8" (ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
    Public Declare Sub L43_NormalMant Lib "L43W32.DLL" Alias "_L43_NormalMant@8" (ByRef mant As UInt32, ByRef exp As Int32)
    Public Declare Function L43_PortRd Lib "L43W32.DLL" Alias "_L43_PortRd@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_PortWr Lib "L43W32.DLL" Alias "_L43_PortWr@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_ProgRdW Lib "L43W32.DLL" Alias "_L43_ProgRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_ProgWrW Lib "L43W32.DLL" Alias "_L43_ProgWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L43_RAMFill Lib "L43W32.DLL" Alias "_L43_RAMFill@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_RAMIsDPM Lib "L43W32.DLL" Alias "_L43_RAMIsDPM@4" (ByVal addrval As UInt32) As Int32
    Public Declare Function L43_RAMRdB Lib "L43W32.DLL" Alias "_L43_RAMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_RAMRdL Lib "L43W32.DLL" Alias "_L43_RAMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L43_RAMRdsL Lib "L43W32.DLL" Alias "_L43_RAMRdsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_RAMRdsW Lib "L43W32.DLL" Alias "_L43_RAMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function L43_RAMRdW Lib "L43W32.DLL" Alias "_L43_RAMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_RAMWipe Lib "L43W32.DLL" Alias "_L43_RAMWipe@4" (ByVal handleval As UInt32)
    Public Declare Sub L43_RAMWipeEx Lib "L43W32.DLL" Alias "_L43_RAMWipeEx@8" (ByVal value As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L43_RAMWrB Lib "L43W32.DLL" Alias "_L43_RAMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L43_RAMWrL Lib "L43W32.DLL" Alias "_L43_RAMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L43_RAMWrsL Lib "L43W32.DLL" Alias "_L43_RAMWrsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_RAMWrsW Lib "L43W32.DLL" Alias "_L43_RAMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L43_RAMWrW Lib "L43W32.DLL" Alias "_L43_RAMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_SchedAdvance Lib "L43W32.DLL" Alias "_L43_SchedAdvance@0" () As UInt32
    Public Declare Function L43_SchedAgain Lib "L43W32.DLL" Alias "_L43_SchedAgain@12" (ByVal index As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedBranchEx Lib "L43W32.DLL" Alias "_L43_SchedBranchEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedBuildEx Lib "L43W32.DLL" Alias "_L43_SchedBuildEx@28" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedBuildExx Lib "L43W32.DLL" Alias "_L43_SchedBuildExx@40" (ByVal basevalmsgnum As Int32, ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedCalc Lib "L43W32.DLL" Alias "_L43_SchedCalc@0" () As UInt32
    Public Declare Function L43_SchedCallEx Lib "L43W32.DLL" Alias "_L43_SchedCallEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal destindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedCheck Lib "L43W32.DLL" Alias "_L43_SchedCheck@8" (ByRef minperiod As Int32, ByRef maxperiod As Int32) As Int32
    Public Declare Sub L43_SchedCheckEnd Lib "L43W32.DLL" Alias "_L43_SchedCheckEnd@0" ()
    Public Declare Sub L43_SchedCheckMiddle Lib "L43W32.DLL" Alias "_L43_SchedCheckMiddle@16" (ByVal msgnum As UInt32, ByVal minlen As UInt32, ByVal midlen As UInt32, ByVal maxlen As UInt32)
    Public Declare Sub L43_SchedCheckReal Lib "L43W32.DLL" Alias "_L43_SchedCheckReal@16" (ByVal msgnum As UInt32, ByVal minlen As UInt32, ByVal midlen As UInt32, ByVal maxlen As UInt32)
    Public Declare Sub L43_SchedCheckStart Lib "L43W32.DLL" Alias "_L43_SchedCheckStart@0" ()
    Public Declare Function L43_SchedConflicts Lib "L43W32.DLL" Alias "_L43_SchedConflicts@0" () As UInt32
    Public Declare Function L43_SchedDivide Lib "L43W32.DLL" Alias "_L43_SchedDivide@0" () As Int32
    Public Declare Function L43_SchedFix Lib "L43W32.DLL" Alias "_L43_SchedFix@0" () As UInt32
    Public Declare Sub L43_SchedFixEnd Lib "L43W32.DLL" Alias "_L43_SchedFixEnd@0" ()
    Public Declare Sub L43_SchedFixMiddle Lib "L43W32.DLL" Alias "_L43_SchedFixMiddle@4" (ByVal conflicts As UInt32)
    Public Declare Sub L43_SchedFixStart Lib "L43W32.DLL" Alias "_L43_SchedFixStart@0" ()
    Public Declare Sub L43_SchedHook Lib "L43W32.DLL" Alias "_L43_SchedHook@8" (ByVal index As Int32, ByVal ptr As IntPtr)
    Public Declare Function L43_SchedInsert Lib "L43W32.DLL" Alias "_L43_SchedInsert@28" (ByVal eventvals As UInt32, ByVal index As UInt32, ByVal msgnum As UInt32, ByRef msgaddr As UInt32, ByVal gapval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedInsertEnd Lib "L43W32.DLL" Alias "_L43_SchedInsertEnd@12" (ByVal eventvals As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedInsertStart Lib "L43W32.DLL" Alias "_L43_SchedInsertStart@12" (ByVal eventvals As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedIntEx Lib "L43W32.DLL" Alias "_L43_SchedIntEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_SchedLayout Lib "L43W32.DLL" Alias "_L43_SchedLayout@0" ()
    Public Declare Function L43_SchedMaxval Lib "L43W32.DLL" Alias "_L43_SchedMaxval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
    Public Declare Function L43_SchedMinval Lib "L43W32.DLL" Alias "_L43_SchedMinval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
    Public Declare Function L43_SchedNop Lib "L43W32.DLL" Alias "_L43_SchedNop@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedParse Lib "L43W32.DLL" Alias "_L43_SchedParse@16" (ByVal basevalmsgnum As Int32, ByRef msgaddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L43_SchedPrint Lib "L43W32.DLL" Alias "" (ByVal ParamArray list() As String)
    Public Declare Function L43_SchedPulse0 Lib "L43W32.DLL" Alias "_L43_SchedPulse0@12" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedPulse1 Lib "L43W32.DLL" Alias "_L43_SchedPulse1@12" (ByVal dionum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedReset Lib "L43W32.DLL" Alias "_L43_SchedReset@0" () As Int32
    Public Declare Function L43_SchedRotate Lib "L43W32.DLL" Alias "_L43_SchedRotate@0" () As UInt32
    Public Declare Function L43_SchedShift Lib "L43W32.DLL" Alias "_L43_SchedShift@8" (ByVal msgnum As Int32, ByVal value As Int32) As Int32
    Public Declare Function L43_SchedSlide Lib "L43W32.DLL" Alias "_L43_SchedSlide@0" () As Int32
    Public Declare Sub L43_SchedSlideEnd Lib "L43W32.DLL" Alias "_L43_SchedSlideEnd@0" ()
    Public Declare Sub L43_SchedSlideMiddle Lib "L43W32.DLL" Alias "_L43_SchedSlideMiddle@12" (ByVal index As UInt32, ByVal count As UInt32, ByVal conflicts As UInt32)
    Public Declare Sub L43_SchedSlideStart Lib "L43W32.DLL" Alias "_L43_SchedSlideStart@4" (ByVal factor As UInt32)
    Public Declare Sub L43_SchedSort Lib "L43W32.DLL" Alias "_L43_SchedSort@0" ()
    Public Declare Function L43_SchedToBit Lib "L43W32.DLL" Alias "_L43_SchedToBit@4" (ByVal value As UInt32) As UInt32
    Public Declare Function L43_SchedToMsec Lib "L43W32.DLL" Alias "_L43_SchedToMsec@4" (ByVal value As UInt32) As UInt32
    Public Declare Sub L43_SchedUnsort Lib "L43W32.DLL" Alias "_L43_SchedUnsort@0" ()
    Public Declare Function L43_SchedUser Lib "L43W32.DLL" Alias "_L43_SchedUser@12" (ByVal useraddr As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SchedWalk Lib "L43W32.DLL" Alias "_L43_SchedWalk@0" () As UInt32
    Public Declare Function L43_SEEPokeW Lib "L43W32.DLL" Alias "_L43_SEEPokeW@12" (ByVal value As Int32, ByVal numbits As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SEERdBit Lib "L43W32.DLL" Alias "_L43_SEERdBit@12" (ByRef valueptr As Int32, ByVal bitnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SEERdL Lib "L43W32.DLL" Alias "_L43_SEERdL@12" (ByRef valueptr As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SEERdW Lib "L43W32.DLL" Alias "_L43_SEERdW@12" (ByRef valueptr As Int32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SEEWrBit Lib "L43W32.DLL" Alias "_L43_SEEWrBit@12" (ByVal value As Int32, ByVal bitnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SEEWrL Lib "L43W32.DLL" Alias "_L43_SEEWrL@12" (ByVal value As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SEEWrW Lib "L43W32.DLL" Alias "_L43_SEEWrW@12" (ByVal value As Int32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SEMMRdW Lib "L43W32.DLL" Alias "_L43_SEMMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_SEMMWrW Lib "L43W32.DLL" Alias "_L43_SEMMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_SEMRdW Lib "L43W32.DLL" Alias "_L43_SEMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L43_SEMWrW Lib "L43W32.DLL" Alias "_L43_SEMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L43_SeqBlkRd Lib "L43W32.DLL" Alias "_L43_SeqBlkRd@16" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_SeqBlkRdEx Lib "L43W32.DLL" Alias "_L43_SeqBlkRdEx@20" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal maxblkcnt As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_SeqClear Lib "L43W32.DLL" Alias "_L43_SeqClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SeqConfigEx Lib "L43W32.DLL" Alias "_L43_SeqConfigEx@16" (ByVal configval As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SeqConfigExx Lib "L43W32.DLL" Alias "_L43_SeqConfigExx@20" (ByVal configval As UInt32, ByVal seqaddr As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SeqIntervalEx Lib "L43W32.DLL" Alias "_L43_SeqIntervalEx@8" (ByVal shiftval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_SeqRdEx Lib "L43W32.DLL" Alias "_L43_SeqRdEx@12" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_SeqResume Lib "L43W32.DLL" Alias "_L43_SeqResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SeqStart Lib "L43W32.DLL" Alias "_L43_SeqStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SeqStop Lib "L43W32.DLL" Alias "_L43_SeqStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L43_Shl Lib "L43W32.DLL" Alias "_L43_Shl@8" (ByVal dataval As UInt32, ByVal cntval As Int32) As UInt32
    Public Declare Function L43_Shr Lib "L43W32.DLL" Alias "_L43_Shr@8" (ByVal dataval As UInt32, ByVal cntval As Int32) As UInt32
    Public Declare Function L43_SignMant Lib "L43W32.DLL" Alias "_L43_SignMant@4" (ByRef str As String) As UInt16
    Public Declare Function L43_SubFrmAddr Lib "L43W32.DLL" Alias "_L43_SubFrmAddr@12" (ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_SubFrmCreate Lib "L43W32.DLL" Alias "_L43_SubFrmCreate@16" (ByVal configval As UInt32, ByVal subframe As Int32, ByVal chanbase As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SubFrmReset Lib "L43W32.DLL" Alias "_L43_SubFrmReset@12" (ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SuperFrmBaseAddr Lib "L43W32.DLL" Alias "_L43_SuperFrmBaseAddr@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L43_SuperFrmConfigEx Lib "L43W32.DLL" Alias "_L43_SuperFrmConfigEx@20" (ByVal configval As UInt32, ByVal count As Int32, ByVal framespersuperframe As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SuperFrmReset Lib "L43W32.DLL" Alias "_L43_SuperFrmReset@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_SyncValPtrInit Lib "L43W32.DLL" Alias "_L43_SyncValPtrInit@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L43_TimerResolutionEx Lib "L43W32.DLL" Alias "_L43_TimerResolutionEx@8" (ByVal timershift As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L43_Transpose12 Lib "L43W32.DLL" Alias "_L43_Transpose12@4" (ByVal val As UInt16) As UInt16
    Public Declare Function L43_ValAsciiCmpi Lib "L43W32.DLL" Alias "_L43_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Int32
    Public Declare Function L43_ValAsciiCpy Lib "L43W32.DLL" Alias "_L43_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Int32) As UInt32
    Public Declare Sub L43_ValAsciiTrimLead Lib "L43W32.DLL" Alias "_L43_ValAsciiTrimLead@4" (ByRef buf As String)
    Public Declare Sub L43_ValAsciiTrimTrail Lib "L43W32.DLL" Alias "_L43_ValAsciiTrimTrail@4" (ByRef buf As String)
    Public Declare Function L43_ValFromAscii Lib "L43W32.DLL" Alias "_L43_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
    Public Declare Function L43_ValGetBits Lib "L43W32.DLL" Alias "_L43_ValGetBits@12" (ByVal oldvalue As UInt32, ByVal startbit As Int32, ByVal endbit As Int32) As UInt32
    Public Declare Function L43_ValIncAscii Lib "L43W32.DLL" Alias "_L43_ValIncAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function L43_ValInccAscii Lib "L43W32.DLL" Alias "_L43_ValInccAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function L43_ValIsLower Lib "L43W32.DLL" Alias "_L43_ValIsLower@4" (ByVal value As Int32) As Int32
    Public Declare Function L43_ValLenAscii Lib "L43W32.DLL" Alias "_L43_ValLenAscii@8" (ByVal numbits As Int32, ByVal radixval As Int32) As Int32
    Public Declare Function L43_ValPutBits Lib "L43W32.DLL" Alias "_L43_ValPutBits@16" (ByVal oldvalue As UInt32, ByVal newfld As UInt32, ByVal startbit As Int32, ByVal endbit As Int32) As UInt32
    Public Declare Function L43_ValToAscii Lib "L43W32.DLL" Alias "_L43_ValToAscii@16" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
    Public Declare Function L43_ValToUpper Lib "L43W32.DLL" Alias "_L43_ValToUpper@4" (ByVal value As Int32) As Int32

    Public Const CH0 As UInt16 = &H0 '//Channel 0
    Public Const CH1 As UInt16 = &H1 '//Channel 1
    Public Const CH2 As UInt16 = &H2 '//Channel 2
    Public Const CH3 As UInt16 = &H3 '//Channel 3
    Public Const CH4 As UInt16 = &H4 '//Channel 4
    Public Const CH5 As UInt16 = &H5 '//Channel 5
    Public Const CH6 As UInt16 = &H6 '//Channel 6
    Public Const CH7 As UInt16 = &H7 '//Channel 7

    Public Const SDI00 As UInt16 = &H1   '//Enable SDI00
    Public Const SDI01 As UInt16 = &H2   '//Enable SDI01
    Public Const SDI10 As UInt16 = &H4   '//Enable SDI10
    Public Const SDI11 As UInt16 = &H8   '//Enable SDI11
    Public Const SDIALL As UInt16 = &HF  '//Enable all SDIs

    Public Const SUBFRM1 As UInt16 = &H1 '//Sub Frame 1 (717)
    Public Const SUBFRM2 As UInt16 = &H2 '//Sub Frame 2 (717)
    Public Const SUBFRM3 As UInt16 = &H3 '//Sub Frame 3 (717)
    Public Const SUBFRM4 As UInt16 = &H4 '//Sub Frame 4 (717)

    '/**
    '*
    '*  Channel configuration options
    '*
    '**/

    Public Const CHCFG_DEFAULT As UInt32 = &H0L  '//Select all default settings (XMT & RCV) (default)
    Public Const CHCFG_HIGHSPEED As UInt32 = &H1L    '//Select high speed (XMT & RCV)
    Public Const CHCFG_AUTOSPEED As UInt32 = &H2L    '//Select auto speed detection (RCV)
    Public Const CHCFG_LOWSPEED As UInt32 = &H0L '//Select low speed (XMT & RCV) (default)
    Public Const CHCFG_SELFTEST As UInt32 = &H4L '//Enable internal wraparound (XMT & RCV)
    Public Const CHCFG_SELFTESTOFF As UInt32 = &H0L  '//Disable internal wraparound (XMT & RCV) (default)
    Public Const CHCFG_SYNC As UInt32 = &H8L '//Sync Enable (XMT & RCV)
    Public Const CHCFG_SYNCOFF As UInt32 = &H0L  '//Disable sync output (XMT & RCV) (default)
    Public Const CHCFG_PARODD As UInt32 = &H0L   '//Parity odd (XMT & RCV) (default)
    Public Const CHCFG_PAREVEN As UInt32 = &H10L  '//Parity even (XMT & RCV)
    Public Const CHCFG_PARDATA As UInt32 = &H20L  '//Parity bit as data (XMT & RCV)
    Public Const CHCFG_ACTIVE As UInt32 = &H0L   '//Enable ehannel activity (XMT & RCV) (default)
    Public Const CHCFG_INACTIVE As UInt32 = &H40L '//Disable channel activity (XMT & RCV)
    Public Const CHCFG_EXTTRIG As UInt32 = &H80L  '//Enable external trigger for all messages (XMT)
    Public Const CHCFG_EXTOFF As UInt32 = &H0L   '//External trigger is enabled on message level (XMT) (default)
    Public Const CHCFG_PARERR As UInt32 = &H100L   '//Enable parity error for all messages (XMT)
    Public Const CHCFG_NOERR As UInt32 = &H0L    '//errors are enabled on message level (XMT) (default)
    Public Const CHCFG_HIT As UInt32 = &H200L  '//Hit counter is enabled for all messages
    Public Const CHCFG_NOHIT As UInt32 = &H0L    '//Hit counter is enabled on message level (default)
    Public Const CHCFG_TIMETAG As UInt32 = &H400L  '//Enable time-tag for all message records
    Public Const CHCFG_TIMETAGOFF As UInt32 = &H0L   '//Time-tag is enabled on message level (default)
    Public Const CHCFG_ELAPSE As UInt32 = &H800L   '//Enable elapse time for all messages
    Public Const CHCFG_ELAPSEOFF As UInt32 = &H0L    '//Elapse time is enabled on message level (default)
    Public Const CHCFG_MAX As UInt32 = &H1000L  '//Enable max repetition rate monitoring for all messages
    Public Const CHCFG_MIN As UInt32 = &H2000L  '//Enable min repetition rate monitoring for all messages
    Public Const CHCFG_MAXMIN As UInt32 = &H3000L   '//Enable max and min repetition rate monitoring for all messages
    Public Const CHCFG_MAXMINOFF As UInt32 = &H0L    '//Repetition rate monitoring is enabled on message level (default)
    Public Const CHCFG_SEQALL As UInt32 = &H80000L   '//Record entire channel in sequential record
    Public Const CHCFG_SEQSEL As UInt32 = &H0L   '//Sequential record recording is enabled at message level (default)
    Public Const CHCFG_INTHALT As UInt32 = &H200000L  '//Enable schedule halt interrupt
    Public Const CHCFG_NOINTHALT As UInt32 = &H0L    '//No interrupt on schedule halt (default)
    Public Const CHCFG_INTPAUSE As UInt32 = &H400000L '//Enable schedule pause interrupt
    Public Const CHCFG_NOINTPAUSE As UInt32 = &H0L   '//No interrupt on schedulr pause (default)
    Public Const CHCFG_INTERR As UInt32 = &H800000L   '//Enable interrupts on decoder errors.
    Public Const CHCFG_NOINTERR As UInt32 = &H0L '//No interrupt on decoder errors (default)
    Public Const CHCFG_PAUSE As UInt32 = &H1000000L    '//Mark channel as paused
    Public Const CHCFG_UNPAUSE As UInt32 = &H0L  '//Mark channel as unpaused (default)
    Public Const CHCFG_RAM As UInt32 = &H0L  '//Messages are located in static RAM (default)
    Public Const CHCFG_DPRAM As UInt32 = &H80000000L    '//Messages are located in dual-port RAM

    Public Const CHCFG717_DEFAULT As UInt32 = &H0L   '//Select all default settings (XMT & RCV) (default)
    Public Const CHCFG717_AUTOSPEED As UInt32 = &H2L '//Select auto speed detection (RCV)
    Public Const CHCFG717_64WPS As UInt32 = &H4000L '//Select speed of 64WPS (XMT & RCV)
    Public Const CHCFG717_128WPS As UInt32 = &H8000L    '//Select speed of 128WPS (XMT & RCV)
    Public Const CHCFG717_256WPS As UInt32 = &H0L    '//Select speed of 256WPS (XMT & RCV) (default)
    Public Const CHCFG717_512WPS As UInt32 = &H10000L    '//Select speed of 512WPS (XMT & RCV)
    Public Const CHCFG717_1024WPS As UInt32 = &H20000L   '//Select speed of 1024WPS (XMT & RCV)
    Public Const CHCFG717_2048WPS As UInt32 = &H40000L   '//Select speed of 2048WPS (XMT & RCV)
    Public Const CHCFG717_4096WPS As UInt32 = &H2000000L   '//Select speed of 4096WPS (XMT & RCV)
    Public Const CHCFG717_8192WPS As UInt32 = &H4000000L   '//Select speed of 8192WPS (XMT & RCV)
    Public Const CHCFG717_BIPHASERCV As UInt32 = &H0L    '//Set Bi-Phase channel to receiver (Bi-Phase) (default)
    Public Const CHCFG717_BIPHASEXMT As UInt32 = &H8000000L    '//Set Bi-Phase channel to transmitter (Bi-Phase)
    Public Const CHCFG717_BIPOLARHSPD As UInt32 = &H8000000L   '//Select high spped slope for Bi-Polar transmitter (Bi-Polar XMT)
    Public Const CHCFG717_SELFTEST As UInt32 = &H4L  '//Enable internal wraparound (XMT & RCV)
    Public Const CHCFG717_SELFTESTOFF As UInt32 = &H0L   '//Disable internal wraparound (XMT & RCV) (default)
    Public Const CHCFG717_SYNC As UInt32 = &H8L  '//Sync Enable (XMT & RCV)
    Public Const CHCFG717_SYNCOFF As UInt32 = &H0L   '//Disable sync output (XMT & RCV) (default)
    Public Const CHCFG717_ACTIVE As UInt32 = &H0L    '//Enable ehannel activity (XMT & RCV) (default)
    Public Const CHCFG717_INACTIVE As UInt32 = &H40L  '//Disable channel activity (XMT & RCV)
    Public Const CHCFG717_EXTTRIG As UInt32 = &H80L   '//Enable external trigger for all messages (XMT)
    Public Const CHCFG717_EXTOFF As UInt32 = &H0L    '//External trigger is enabled on message level (XMT) (default)
    Public Const CHCFG717_HIT As UInt32 = &H200L   '//Hit counter is enabled for all sub frames (XMT & RCV)
    Public Const CHCFG717_NOHIT As UInt32 = &H0L '//Hit counter is disabled (XMT & RCV) (default)
    Public Const CHCFG717_TIMETAG As UInt32 = &H400L   '//Enable time-tag for all sub frames (XMT & RCV)
    Public Const CHCFG717_TIMETAGOFF As UInt32 = &H0L    '//Time-tag is disabled (XMT & RCV) (default)
    Public Const CHCFG717_SEQALL As UInt32 = &H80000L    '//Record entire channel in sequential record (XMT & RCV)
    Public Const CHCFG717_SEQSEL As UInt32 = &H0L    '//Sequential record recording is enabled at word level (XMT & RCV) (default)
    Public Const CHCFG717_INTERR As UInt32 = &H800000L    '//Enable interrupts on Out of Sync Error (RCV)
    Public Const CHCFG717_NOINTERR As UInt32 = &H0L  '//No interrupt on Out of Sync Error (RCV) (default)
    Public Const CHCFG717_PAUSE As UInt32 = &H1000000L '//Mark channel as paused (XMT & RCV)
    Public Const CHCFG717_UNPAUSE As UInt32 = &H0L   '//Mark channel as unpaused (XMT & RCV) (default)

    '/**
    '*
    '*  Sequential Record configuration options
    '*
    '**/

    Public Const SEQCFG_DEFAULT As UInt32 = &H0L '//Select all default settings
    Public Const SEQCFG_FILLHALT As UInt32 = &H0L    '//Enable sequential record in fill and halt mode (default)
    Public Const SEQCFG_DISABLE As UInt32 = &H1L '//Disable sequential record
    Public Const SEQCFG_CONTINUOUS As UInt32 = &H2L  '//Enable sequential record in continuous mode
    Public Const SEQCFG_FREE As UInt32 = &H8L    '//Enable sequential record in free mode
    Public Const SEQCFG_DELTA As UInt32 = &H10L   '//Enable sequential record in delta mode
    Public Const SEQCFG_INTERVAL As UInt32 = &H20L    '//Enable sequential record in interval mode
    Public Const SEQCFG_NOINTFULL As UInt32 = &H0L   '//Do not generate interrupt when sequential record is full (default)
    Public Const SEQCFG_INTFULL As UInt32 = &H1000L '//Generate interrupt when sequential record is full
    Public Const SEQCFG_NOINTFREQ As UInt32 = &H0L   '//Do not generate interrupts at a user specified frequency (default)
    Public Const SEQCFG_INTFREQ As UInt32 = &H2000L '//Generate interrupts at user specified frequency
    Public Const SEQCFG_16K As UInt32 = &H0L '//Allocate a 16K sequential record buffer (default)
    Public Const SEQCFG_ALLAVAIL As UInt32 = &H1000000L    '//Allocate all available memory to a sequential record buffer
    Public Const SEQCFG_32K As UInt32 = &H2000000L '//Allocate a 32K sequential record buffer
    Public Const SEQCFG_64K As UInt32 = &H4000000L '//Allocate a 64K sequential record buffer
    Public Const SEQCFG_128K As UInt32 = &H8000000L    '//Allocate a 128K sequential record buffer
    Public Const SEQCFG_DPRAM As UInt32 = &H10000000L   '//Allocate all available dual-port memory

    '/**
    '*
    '*  Interrupt log list configuration options
    '*
    '**/

    Public Const INTCFG_DEFAULT As UInt32 = &H0L '//Select all default settings
    Public Const INTCFG_ENABLE As UInt32 = &H0L  '//Enable interrupt log list (default)
    Public Const INTCFG_DISABLE As UInt32 = &H1L '//Disable interrupt log list

    '/**
    '*
    '*  Info types
    '*
    '**/

    Public Const INFOTYPE_PLAT As UInt16 = &H1   '//Returns the L43 platform type
    Public Const INFOTYPE_PROD As UInt16 = &H2   '//Returns the L43 product type
    Public Const INFOTYPE_DASH As UInt16 = &H3   '//Returns the L43 dash number
    Public Const INFOTYPE_VERSION As UInt16 = &H4    '//Returns the L43 version number
    Public Const INFOTYPE_DATE As UInt16 = &H5   '//Returns the L43 version date
    Public Const INFOTYPE_MODEL As UInt16 = &H6  '//Returns the L43 model number
    Public Const INFOTYPE_MAXCOUNT As UInt16 = &H7   '//Returns the max channel count
    Public Const INFOTYPE_USERCODE As UInt16 = &HA   '//Returns whether L43 handles user code
    Public Const INFOTYPE_LISTBUF As UInt16 = &HB    '//Returns whether L43 handles list buffering
    Public Const INFOTYPE_ARINC717 As UInt16 = &HC   '//Returns whether L43 has ARINC 717 channels

    '/**
    '*
    '*  Message configuration options
    '*
    '**/

    Public Const MSGCRT_DEFAULT As UInt32 = &H0L '//Default settings
    Public Const MSGCRT_NOSEQ As UInt32 = &H0L   '//Message will not be recorded in sequential record (default)
    Public Const MSGCRT_SEQ As UInt32 = &H1L '//Message will be recorded in sequential record
    Public Const MSGCRT_NOINT As UInt32 = &H0L   '//Message will not generate interrupt (default)
    Public Const MSGCRT_INT As UInt32 = &H2L '//Message will generate interrupt
    Public Const MSGCRT_NOLIST As UInt32 = &H0L  '//Message will not have a list buffer (default)
    Public Const MSGCRT_LIST As UInt32 = &H4L    '//Message will have a list buffer
    Public Const MSGCRT_NOSKIP As UInt32 = &H0L  '//Message will not be skipped (default)
    Public Const MSGCRT_SKIP As UInt32 = &H8L    '//Message will be skipped
    Public Const MSGCRT_NOTIMETAG As UInt32 = &H0L   '//Message will not record time-tag (default)
    Public Const MSGCRT_TIMETAG As UInt32 = &H10L '//Message will record time-tag
    Public Const MSGCRT_NOELAPSE As UInt32 = &H0L    '//Message will not record elapse time (default)
    Public Const MSGCRT_ELAPSE As UInt32 = &H20L  '//Message will record elapse time
    Public Const MSGCRT_NOMAXMIN As UInt32 = &H0L    '//Message will not record min/max time (default)
    Public Const MSGCRT_MAX As UInt32 = &H40L '//Message will record max time
    Public Const MSGCRT_MIN As UInt32 = &H80L '//Message will record min time
    Public Const MSGCRT_MAXMIN As UInt32 = &HC0L  '//Message will record min/max time
    Public Const MSGCRT_NOSYNC As UInt32 = &H0L  '//No sync will be generated for message (default)
    Public Const MSGCRT_SYNC As UInt32 = &H100L    '//Sync will be generated for message
    Public Const MSGCRT_NOERR As UInt32 = &H0L   '//No error will be generated for message (default)
    Public Const MSGCRT_PARERR As UInt32 = &H200L  '//Parity error will be generated for message
    Public Const MSGCRT_NOHIT As UInt32 = &H0L   '//Message will not record hit count (default)
    Public Const MSGCRT_HIT As UInt32 = &H400L '//Message will record hit count
    Public Const MSGCRT_NOEXTRIG As UInt32 = &H0L    '//Message will not be externally triggered (default)
    Public Const MSGCRT_EXTRIG As UInt32 = &H1000L  '//Message will be externally triggered
    Public Const MSGCRT_WIPE As UInt32 = &H0L    '//Enables message clear (default)
    Public Const MSGCRT_NOWIPE As UInt32 = &H80000000L  '//Disables message clear
    Public Const MSGCRT_WIPE0 As UInt32 = &H0L   '//Initialize data with zeros (default)
    Public Const MSGCRT_WIPE1 As UInt32 = &H40000000L   '//Initialize data with ones
    Public Const MSGCRT_CHAN As UInt32 = &H0L    '//Message located in static RAM or dual-port RAM depending upon channel config (default)
    Public Const MSGCRT_RAM As UInt32 = &H20000000L '//Message located in static RAM
    Public Const MSGCRT_DPRAM As UInt32 = &H10000000L   '//Message located in dual-port RAM

    '/**
    '*
    '*  Sub Frame word configuration options (717)
    '*
    '**/

    Public Const WRDCFG_DEFAULT As UInt32 = &H0L '//Select all default settings
    Public Const WRDCFG_SFINT As UInt32 = &H1L   '//Enable subframe interrupt
    Public Const WRDCFG_SFINTOFF As UInt32 = &H0L    '//Disable subframe interrupt (default)
    Public Const WRDCFG_WRDINT As UInt32 = &H2L  '//Enable word interrupt
    Public Const WRDCFG_WRDINTOFF As UInt32 = &H0L   '//Disable word interrupt (default)
    Public Const WRDCFG_SEQ As UInt32 = &H4L '//Enable sequential record
    Public Const WRDCFG_SEQOFF As UInt32 = &H0L  '//Disable sequential record (default)

    '/**
    '*
    '*  List buffer options
    '*
    '**/

    Public Const LISTCRT_DEFAULT As UInt32 = &H0L    '//Select all default settings
    Public Const LISTCRT_FIFO As UInt32 = &H0L   '//Enable FIFO mode (default)
    Public Const LISTCRT_PINGPONG As UInt32 = &H1L   '//Enable ping-pong mode
    Public Const LISTCRT_CIRCULAR As UInt32 = &H2L   '//Enable circular mode
    Public Const LISTCRT_RCV As UInt32 = &H10L    '//User will read from list buffer
    Public Const LISTCRT_XMT As UInt32 = &H20L    '//User will write to list buffer
    Public Const LISTCRT_NOINT As UInt32 = &H0L  '//Do not generate interrupt when list buffer empty/full (default)
    Public Const LISTCRT_INT As UInt32 = &H100L    '//Generate interrupt when list buffer empty/full
    Public Const LISTCRT_RAM As UInt32 = &H0L    '//List located in static RAM (default)
    Public Const LISTCRT_DPRAM As UInt32 = &H200000L  '//List located in dual-port RAM

    '/**
    '*
    '*  Bit fields of the message activity flag.
    '*
    '**/

    Public Const MSGACT_BRD As UInt16 = &HF000  '//All bits of Board number
    Public Const MSGACT_BRD3 As UInt16 = &H8000 '//Bit 3 of Board number
    Public Const MSGACT_BRD2 As UInt16 = &H4000 '//Bit 2 of Board number
    Public Const MSGACT_BRD1 As UInt16 = &H2000 '//Bit 1 of Board number
    Public Const MSGACT_BRD0 As UInt16 = &H1000 '//Bit 0 of Board number
    Public Const MSGACT_CHAN As UInt16 = &HF00 '//All bits of Channel number
    Public Const MSGACT_CHAN3 As UInt16 = &H800    '//Bit 3 of Channel number
    Public Const MSGACT_CHAN2 As UInt16 = &H400    '//Bit 2 of Channel number
    Public Const MSGACT_CHAN1 As UInt16 = &H200    '//Bit 1 of Channel number
    Public Const MSGACT_CHAN0 As UInt16 = &H100    '//Bit 0 of Channel number
    Public Const MSGACT_ASPD As UInt16 = &H80 '//Auto Speed
    Public Const MSGACT_ERR As UInt16 = &H40  '//Error bit
    Public Const MSGACT_GAP As UInt16 = &H20  '//Gap error bit
    Public Const MSGACT_PAR As UInt16 = &H10  '//Parity error bit
    Public Const MSGACT_LONG As UInt16 = &H8 '//Long word error bit
    Public Const MSGACT_BIT As UInt16 = &H4  '//Bit time error bit
    Public Const MSGACT_TO As UInt16 = &H2   '//Time out error bit
    Public Const MSGACT_HIT As UInt16 = &H1  '//Always set

    Public Const MSGACT717_BRD As UInt16 = &HF000   '//All bits of Board number
    Public Const MSGACT717_BRD3 As UInt16 = &H8000  '//Bit 3 of Board number
    Public Const MSGACT717_BRD2 As UInt16 = &H4000  '//Bit 2 of Board number
    Public Const MSGACT717_BRD1 As UInt16 = &H2000  '//Bit 1 of Board number
    Public Const MSGACT717_BRD0 As UInt16 = &H1000  '//Bit 0 of Board number
    Public Const MSGACT717_CHAN As UInt16 = &HF00  '//All bits of Channel number
    Public Const MSGACT717_CHAN3 As UInt16 = &H800 '//Bit 3 of Channel number
    Public Const MSGACT717_CHAN2 As UInt16 = &H400 '//Bit 2 of Channel number
    Public Const MSGACT717_CHAN1 As UInt16 = &H200 '//Bit 1 of Channel number
    Public Const MSGACT717_CHAN0 As UInt16 = &H100 '//Bit 0 of Channel number
    Public Const MSGACT717_SPD As UInt16 = &HE0   '//All bits of current speed
    Public Const MSGACT717_SPD2 As UInt16 = &H80  '//Bit 2 of current speed
    Public Const MSGACT717_SPD1 As UInt16 = &H40  '//Bit 1 of current speed
    Public Const MSGACT717_SPD0 As UInt16 = &H20  '//Bit 0 of current speed
    Public Const MSGACT717_TO As UInt16 = &H2    '//Time out error bit
    Public Const MSGACT717_HIT As UInt16 = &H1   '//Always set

    '/**
    '*
    '*  L43 IFGA Registers
    '*
    '**/

    Public Const IREG_STAT As UInt16 = &H40   '//Status register (RD)
    Public Const IREG_SET As UInt16 = &H41    '//Set register (WR)
    Public Const IREG_CLR As UInt16 = &H42    '//Clear register (WR)
    Public Const IREG_ID As UInt16 = &H43 '//ID register (RD)
    Public Const IREG_PAGE As UInt16 = &H44   '//Page register
    Public Const IREG_CONFIG As UInt16 = &H45 '//Configuration register
    Public Const IREG_INT As UInt16 = &H46    '//Interrupt register
    Public Const IREG_PRESCL As UInt16 = &H47 '//Prescale Register for clock divider

    '/**
    '*
    '*  EDGA Registers
    '*
    '**/

    Public Const EREG1_GSTAT As UInt16 = &H1180 '//Global Status
    Public Const EREG1_CHSTAT As UInt16 = &H181    '//Channel Status
    Public Const EREG1_CHDATAH As UInt16 = &H182   '//Channel Data High Word
    Public Const EREG1_CHDATAL As UInt16 = &H183   '//Channel Data Low Word
    Public Const EREG1_CHGAP As UInt16 = &H184 '//Channel Gap
    Public Const EREG1_CHCNTL As UInt16 = &H185    '//Channel Control Word
    Public Const EREG1_CHCFG As UInt16 = &H186 '//Channel Config
    Public Const EREG1_CHCFGINT As UInt16 = &H187  '//Channel Int Config
    Public Const EREG1_GERR As UInt16 = &H188  '//Global Error Register
    Public Const EREG1_GRST As UInt16 = &H189  '//Global Reset
    Public Const EREG1_GID As UInt16 = &H18C   '//Global ID

    Public Const EREG2_GSTAT As UInt16 = &H1280 '//Global Status
    Public Const EREG2_CHSTAT As UInt16 = &H281    '//Channel Status
    Public Const EREG2_CHDATAH As UInt16 = &H282   '//Channel Data High Word
    Public Const EREG2_CHDATAL As UInt16 = &H283   '//Channel Data Low Word
    Public Const EREG2_CHGAP As UInt16 = &H284 '//Channel Gap
    Public Const EREG2_CHCNTL As UInt16 = &H285    '//Channel Control Word
    Public Const EREG2_CHCFG As UInt16 = &H286 '//Channel Config
    Public Const EREG2_CHCFGINT As UInt16 = &H287  '//Channel Int Config
    Public Const EREG2_GERR As UInt16 = &H288  '//Global Error Register
    Public Const EREG2_GRST As UInt16 = &H289  '//Global Reset
    Public Const EREG2_GID As UInt16 = &H28C   '//Global ID

    '/**
    '*
    '*  Local Configuration Registers
    '*
    '**/

    Public Const CREG_LAS0RR As UInt16 = &H0 '//Local Address Space 0 Range
    Public Const CREG_LAS1RR As UInt16 = &H1 '//Local Address Space 1 Range
    Public Const CREG_LAS2RR As UInt16 = &H2 '//Local Address Space 2 Range
    Public Const CREG_LAS3RR As UInt16 = &H3 '//Local Address Space 3 Range
    Public Const CREG_EROMRR As UInt16 = &H4 '//Local Expansion ROM Range
    Public Const CREG_LAS0BA As UInt16 = &H5 '//Local Address Space 0 Local Base Address (Re-map)
    Public Const CREG_LAS1BA As UInt16 = &H6 '//Local Address Space 1 Local Base Address (Re-map)
    Public Const CREG_LAS2BA As UInt16 = &H7 '//Local Address Space 2 Local Base Address (Re-map)
    Public Const CREG_LAS3BA As UInt16 = &H8 '//Local Address Space 3 Local Base Address (Re-map)
    Public Const CREG_EROMBA As UInt16 = &H9 '//Expansion ROM Local Base Address (Re-map)
    Public Const CREG_LAS0BRD As UInt16 = &HA    '//Local Address Space 0 Bus Region Descriptors
    Public Const CREG_LAS1BRD As UInt16 = &HB    '//Local Address Space 1 Bus Region Descriptors
    Public Const CREG_LAS2BRD As UInt16 = &HC    '//Local Address Space 2 Bus Region Descriptors
    Public Const CREG_LAS3BRD As UInt16 = &HD    '//Local Address Space 3 Bus Region Descriptors
    Public Const CREG_EROMBRD As UInt16 = &HE    '//Expansion ROM Bus Region Descriptors
    Public Const CREG_CS0BASE As UInt16 = &HF    '//Chip Select 0 Base Address
    Public Const CREG_CS1BASE As UInt16 = &H10    '//Chip Select 1 Base Address
    Public Const CREG_CS2BASE As UInt16 = &H11    '//Chip Select 2 Base Address
    Public Const CREG_CS3BASE As UInt16 = &H12    '//Chip Select 3 Base Address
    Public Const CREG_INTCSR As UInt16 = &H13 '//Interrupt Control/Status
    Public Const CREG_CNTRL As UInt16 = &H14  '//EEPROM Control, PCI Slave Response, User I/O Control, Init Control

    '/**
    '*
    '*  Interrupt types.
    '*
    '**/

    Public Const INTTYPE_MSG As UInt16 = &H1 '//Message interrupt
    Public Const INTTYPE_OPCODE As UInt16 = &H2  '//Interrupt opcode
    Public Const INTTYPE_HALT As UInt16 = &H3    '//Schedule halt
    Public Const INTTYPE_PAUSE As UInt16 = &H4   '//Schedule pause
    Public Const INTTYPE_SEQFULL As UInt16 = &H5 '//Sequential record full
    Public Const INTTYPE_LIST As UInt16 = &H6    '//List buffer empty/full
    Public Const INTTYPE_ERR As UInt16 = &H7 '//Decoder error detected
    Public Const INTTYPE_SEQFREQ As UInt16 = &H8 '//Sequential record frequency
    Public Const INTTYPE_717WORD As UInt16 = &H9 '//717 word received
    Public Const INTTYPE_717SUBFRM As UInt16 = &HA   '//717 sub frame completed
    Public Const INTTYPE_717SYNCERR As UInt16 = &HB  '//717 Rcv channel lost synchronization

    '/**
    '*
    '*  Timer resolutions.
    '*
    '**/

    Public Const TIMERRESOL_1US As Int16 = 1    '//1us timer resolution, 1:11:34 range
    Public Const TIMERRESOL_16US As Int16 = 2   '//16us timer resolution, 19:05:19 range
    Public Const TIMERRESOL_1024US As Int16 = 3 '//1024us timer resolution, 50 day range
    Public Const TIMERRESOL_16348US As Int16 = 4    '//16348us timer resolution, 814 day range

    '/**
    '*
    '*  Interval calculation modes.
    '*
    '**/

    Public Const INTERVALMODE_CLOSEST As Int16 = 1  '//Finds interval closest to value specified
    Public Const INTERVALMODE_LESS As Int16 = 2 '//Finds closest interval less than value specified
    Public Const INTERVALMODE_GREATER As Int16 = 3  '//Finds closest interval more than value specified

    '/**
    '*
    '*  Scheduling conditions.
    '*
    '**/

    Public Const COND_ALWAYS As UInt16 = &H0
    Public Const COND_DIO1ACT As UInt16 = &H1
    Public Const COND_DIO1NACT As UInt16 = &H81
    Public Const COND_DIO2ACT As UInt16 = &H2
    Public Const COND_DIO2NACT As UInt16 = &H82
    Public Const COND_DIO3ACT As UInt16 = &H3
    Public Const COND_DIO3NACT As UInt16 = &H83
    Public Const COND_DIO4ACT As UInt16 = &H4
    Public Const COND_DIO4NACT As UInt16 = &H84

    Public Const SEQRD_MAX_COUNT As Int16 = 9

    Public Const RCV As Int16 = 0
    Public Const XMT As Int16 = 1

    Public Const STAT_EMPTY As Int16 = 0    '//Buffer is empty
    Public Const STAT_PARTIAL As Int16 = 1  '//Buffer is partially filled
    Public Const STAT_FULL As Int16 = 2 '//Buffer is full
    Public Const STAT_OFF As Int16 = 3  '//Buffer is off

    Public Const TEST_LEVEL_0 As Int16 = 0  '//Test I/O interface
    Public Const TEST_LEVEL_1 As Int16 = 1  '//Test memory interface
    Public Const TEST_LEVEL_2 As Int16 = 2  '//Test communication process
    Public Const TEST_LEVEL_3 As Int16 = 3  '//Test bus transceiver

    Public Const ERR_NONE As Int16 = 0  '//No error
    Public Const ERR_UNKNOWN As Int16 = -1  '//An unexpected error occurred
    Public Const ERR_BADVER As Int16 = -2   '//A bad version was encountered
    Public Const ERR_BADPARAMS As Int16 = -11   '//CardOpen() called with bad parameters
    Public Const ERR_NOHANDLES As Int16 = -12   '//CardOpen() already has allocated too many handles
    Public Const ERR_NOCARD As Int16 = -13  '//CardOpen() could not find a L43 card at the specified address
    Public Const ERR_NOIO As Int16 = -14    '//CardOpen() could not find the I/O ports
    Public Const ERR_NOMEM As Int16 = -15   '//CardOpen() could not find the memory
    Public Const ERR_BAD16BIT As Int16 = -16    '//Card is conflicting with another 16-bit card
    Public Const ERR_WRONGMODEL As Int16 = -17  '//Card does not support this feature
    Public Const ERR_NOSEL As Int16 = -18   '//CardOpen() could not allocate a memory selector
    Public Const ERR_LOCK As Int16 = -19    '//The communication process is locked up
    Public Const ERR_TOOMANY As Int16 = -20 '//Too many channels have been configured
    Public Const ERR_BADHANDLE As Int16 = -21   '//A bad handle was specified
    Public Const ERR_NOTCHAN As Int16 = -23 '//Not a valid channel
    Public Const ERR_NOTXMT As Int16 = -24  '//The Transmitter has not been configured
    Public Const ERR_NOTRCV As Int16 = -25  '//The Receiver has not been configured
    Public Const ERR_NOTSEQ As Int16 = -26  '//The Sequential Record has not been configured
    Public Const ERR_ALLOC As Int16 = -27   '//There is not enough memory to allocate
    Public Const ERR_VXD As Int16 = -28 '//An error occurred in the VXD
    Public Const ERR_BADLABEL As Int16 = -29    '//The specified label value is not valid
    Public Const ERR_BADSDI As Int16 = -30  '//The specified sdi value is not valid
    Public Const ERR_BADMSG As Int16 = -31  '//The specified command block is not a message block
    Public Const ERR_BADSCHNDX As Int16 = -32   '//Specified command index is out of range
    Public Const ERR_BUFSIZE As Int16 = -33 '//Insufficient space in user buffer
    Public Const ERR_NOCONFIG As Int16 = -34    '//The card has not been properly configured
    Public Const ERR_CONFLICTS As Int16 = -35   '//Unable to resolve conflicts
    Public Const ERR_RANGE As Int16 = -36   '//Schedule is out of range
    Public Const ERR_FACTOR As Int16 = -37  '//A bad factor value was specified
    Public Const ERR_BOOTFULL As Int16 = -41    '//No space to add boot code
    Public Const ERR_BOOTNUM As Int16 = -42 '//There is no boot code with the specified number
    Public Const ERR_ACCESS As Int16 = -43  '//Unable to write to access register
    Public Const ERR_ROMVERIFY As Int16 = -44   '//Unable to verify the value written to the ROM
    Public Const ERR_COUNT As Int16 = -45   '//An invalid count was specified
    Public Const ERR_CRC As Int16 = -46 '//There was a bad checksum in the HEX file
    Public Const ERR_FNAME As Int16 = -47   '//Bad filenames were specified
    Public Const ERR_FRDWR As Int16 = -48   '//There was an error reading or writing the HEX file
    Public Const ERR_HEX As Int16 = -49 '//There was a bad hex character in the HEX file
    Public Const ERR_INDEX As Int16 = -51   '//The command block index was invalid or the schedule is full
    Public Const ERR_NOMSGS As Int16 = -52  '//No messages specified
    Public Const ERR_TYPE As Int16 = -54    '//There was a bad type value in the HEX file
    Public Const ERR_ZEROLEN As Int16 = -55 '//Zero length was specified
    Public Const ERR_BADADDRESS As Int16 = -56  '//A bad address was specified
    Public Const ERR_SELFIOFAIL As Int16 = -71  '//I/O selftest failed
    Public Const ERR_SELFMEMFAIL As Int16 = -72 '//Memory selftest failed
    Public Const ERR_SELFCOMMFAIL As Int16 = -73    '//Communication selftest failed
    Public Const ERR_SELFXMTFAIL As Int16 = -74 '//Transmit selftest failed
    Public Const ERR_PLXBUG As Int16 = -75  '//PLX bug is causing problems
    Public Const ERR_NOT717CHAN As Int16 = -100 '//Specified channel is not a 717 channel
    Public Const ERR_SUBFRMNUM As Int16 = -101  '//Invalid 717 SubFrame number was specified
    Public Const ERR_WORDNUM As Int16 = -102    '//Invalid 717 Word number was specified
    Public Const ERR_NOTINSYNC As Int16 = -103  '//Not Synchronized to 717 databus
    Public Const ERR_SUPERFRM As Int16 = -104   '//SuperFrame not configured
    Public Const ERR_SUPERFRMNUM As Int16 = -105    '//Invalid 717 SuperFrame number was specified

End Module
