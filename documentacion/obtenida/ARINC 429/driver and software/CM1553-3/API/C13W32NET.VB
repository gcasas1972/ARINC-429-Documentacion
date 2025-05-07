Imports System
Imports System.Runtime.InteropServices

Module C13W32VB

    '/**
    '*
    '*  CM1553-3 WIN32 DRIVER  Version 1.6.1  (02/01/2008)
    '*  Copyright (c) 1999-2008
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   C13W32NET.VB -- 32-bit
    '*                      CM1553-3 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  Structs used by the C13 Driver.
    '*
    '**/

    <StructLayout(LayoutKind.Sequential)> Public Structure XMITFIELDS
        Public ctrlflags As UInt32  '//User writes message configuration optionvals
        Public flag1 As UInt16  '//Card writes message flag 1
        Public flag2 As UInt16  '//Card writes message flag 2
        Public errflags As UInt16   '//Card writes errorval flags
        Public actflags As UInt16   '//Card writes activity flags
        Public resptime1 As UInt16  '//Card writes response time 1
        Public resptime2 As UInt16  '//Card writes response time 2
        Public datacount As UInt16  '//Card writes data count
        Public resv7 As UInt16  '//Reserved field
        Public timetag As UInt32    '//Card writes time tag
        Public elapsetime As UInt32 '//Card writes elapsed time
        Public resv12 As UInt16 '//Reserved field
        Public resv13 As UInt16 '//Reserved field
        Public resv14 As UInt16 '//Reserved field
        Public resv15 As UInt16 '//Reserved field
        Public resv16 As UInt16 '//Reserved field
        Public resv17 As UInt16 '//Reserved field
        Public resv18 As UInt16 '//Reserved field
        Public resv19 As UInt16 '//Reserved field
        Public cwd1 As UInt16   '//User writes command word 1
        Public cwd2 As UInt16   '//User writes command word 2
        Public swd1 As UInt16   '//Card writes status word 1
        Public swd2 As UInt16   '//Card writes status word 2
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> Public data() As UInt16    '//User writes data words
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public extra() As UInt16    '//User writes extra words
    End Structure

    '/**
    '*
    '*  C13 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the C13 Driver.
    '*
    '**/

    Public Declare Function C13_BCConfig Lib "C13W32.DLL" Alias "_C13_BCConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCCreateList Lib "C13W32.DLL" Alias "_C13_BCCreateList@28" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_BCCreateMsg Lib "C13W32.DLL" Alias "_C13_BCCreateMsg@20" (ByVal configval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_BCSchedFrame Lib "C13W32.DLL" Alias "_C13_BCSchedFrame@8" (ByVal timeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedMsg Lib "C13W32.DLL" Alias "_C13_BCSchedMsg@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedRetry Lib "C13W32.DLL" Alias "_C13_BCSchedRetry@12" (ByVal condition As UInt16, ByVal retries As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCTransmitMsg Lib "C13W32.DLL" Alias "_C13_BCTransmitMsg@8" (ByRef xmitfieldsval As XMITFIELDS, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCTransmitMsgEx Lib "C13W32.DLL" Alias "_C13_BCTransmitMsgEx@8" (ByRef xmitfieldsval As XMITFIELDS, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardClose Lib "C13W32.DLL" Alias "_C13_CardClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardOpen Lib "C13W32.DLL" Alias "_C13_CardOpen@4" (ByVal cardnum As Int32) As UInt32
    Public Declare Sub C13_CardReset Lib "C13W32.DLL" Alias "_C13_CardReset@4" (ByVal handleval As UInt32)
    Public Declare Function C13_CardStart Lib "C13W32.DLL" Alias "_C13_CardStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardStop Lib "C13W32.DLL" Alias "_C13_CardStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ErrorCtrl Lib "C13W32.DLL" Alias "_C13_ErrorCtrl@8" (ByVal ctrlval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ErrorDefine Lib "C13W32.DLL" Alias "_C13_ErrorDefine@24" (ByVal defineval As UInt32, ByVal errvalue As UInt16, ByVal countval As Int32, ByVal wordpos As UInt16, ByVal bitpos As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ErrorSent Lib "C13W32.DLL" Alias "_C13_ErrorSent@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ErrorTagBC Lib "C13W32.DLL" Alias "_C13_ErrorTagBC@12" (ByVal tagval As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ErrorTagRT Lib "C13W32.DLL" Alias "_C13_ErrorTagRT@24" (ByVal tagval As Int32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ListDataRd Lib "C13W32.DLL" Alias "_C13_ListDataRd@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ListDataWr Lib "C13W32.DLL" Alias "_C13_ListDataWr@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonBlkRd Lib "C13W32.DLL" Alias "_C13_MonBlkRd@16" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_MonBlkRdEx Lib "C13W32.DLL" Alias "_C13_MonBlkRdEx@20" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal maxblkcnt As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_MonConfig Lib "C13W32.DLL" Alias "_C13_MonConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonFilterSA Lib "C13W32.DLL" Alias "_C13_MonFilterSA@24" (ByVal taval As Int32, ByVal rcvsamask As UInt32, ByVal xmtsamask As UInt32, ByVal rcvmcmask As UInt32, ByVal xmtmcmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonFilterTA Lib "C13W32.DLL" Alias "_C13_MonFilterTA@8" (ByVal tamask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonIsRunning Lib "C13W32.DLL" Alias "_C13_MonIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonRd Lib "C13W32.DLL" Alias "_C13_MonRd@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_MsgDataRd Lib "C13W32.DLL" Alias "_C13_MsgDataRd@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Sub C13_MsgDataWr Lib "C13W32.DLL" Alias "_C13_MsgDataWr@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function C13_MsgFieldRd Lib "C13W32.DLL" Alias "_C13_MsgFieldRd@12" (ByVal fieldtype As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_MsgFieldWr Lib "C13W32.DLL" Alias "_C13_MsgFieldWr@16" (ByVal fieldval As UInt32, ByVal fieldtype As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_PlayConfig Lib "C13W32.DLL" Alias "_C13_PlayConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_PlayWr Lib "C13W32.DLL" Alias "_C13_PlayWr@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_RTConfig Lib "C13W32.DLL" Alias "_C13_RTConfig@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_RTCreateList Lib "C13W32.DLL" Alias "_C13_RTCreateList@32" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_RTCreateMsg Lib "C13W32.DLL" Alias "_C13_RTCreateMsg@24" (ByVal configval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_RTGetMsg Lib "C13W32.DLL" Alias "_C13_RTGetMsg@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_RTSWDWr Lib "C13W32.DLL" Alias "_C13_RTSWDWr@12" (ByVal swdval As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ValPackCWD Lib "C13W32.DLL" Alias "_C13_ValPackCWD@16" (ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal wcval As Int32) As UInt16
    Public Declare Sub C13_ValUnpackCWD Lib "C13W32.DLL" Alias "_C13_ValUnpackCWD@20" (ByVal cwdval As UInt16, ByRef taval As Int32, ByRef trflag As Int32, ByRef saval As Int32, ByRef wcval As Int32)
    Public Declare Function C13_AddrDSP Lib "C13W32.DLL" Alias "_C13_AddrDSP@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function C13_AddrHost Lib "C13W32.DLL" Alias "_C13_AddrHost@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function C13_AsciiCat Lib "C13W32.DLL" Alias "_C13_AsciiCat@8" (ByRef strdest As String, ByRef strsrc As String) As UInt32
    Public Declare Function C13_AsciiCmpi Lib "C13W32.DLL" Alias "_C13_AsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Int32
    Public Declare Function C13_AsciiCpy Lib "C13W32.DLL" Alias "_C13_AsciiCpy@8" (ByRef strdest As String, ByRef strsrc As String) As UInt32
    Public Declare Function C13_AsciiFromNibble Lib "C13W32.DLL" Alias "_C13_AsciiFromNibble@4" (ByVal ch As Char) As Int32
    Public Declare Function C13_AsciiFromVal Lib "C13W32.DLL" Alias "_C13_AsciiFromVal@16" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
    Public Declare Function C13_AsciiInc Lib "C13W32.DLL" Alias "_C13_AsciiInc@4" (ByRef asciistr As String) As UInt32
    Public Declare Function C13_AsciiIncc Lib "C13W32.DLL" Alias "_C13_AsciiIncc@4" (ByRef asciistr As String) As UInt32
    Public Declare Function C13_AsciiIsLower Lib "C13W32.DLL" Alias "_C13_AsciiIsLower@4" (ByVal value As Int32) As Int32
    Public Declare Function C13_AsciiIsRadix Lib "C13W32.DLL" Alias "_C13_AsciiIsRadix@8" (ByRef asciistr As String, ByVal radixval As Int32) As Int32
    Public Declare Function C13_AsciiLenVal Lib "C13W32.DLL" Alias "_C13_AsciiLenVal@8" (ByVal numbits As Int32, ByVal radixval As Int32) As Int32
    Public Declare Function C13_AsciiToUpper Lib "C13W32.DLL" Alias "_C13_AsciiToUpper@4" (ByVal value As Int32) As Int32
    Public Declare Function C13_AsciiToVal Lib "C13W32.DLL" Alias "_C13_AsciiToVal@8" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
    Public Declare Sub C13_AsciiTrimLead Lib "C13W32.DLL" Alias "_C13_AsciiTrimLead@4" (ByRef buf As String)
    Public Declare Sub C13_AsciiTrimTrail Lib "C13W32.DLL" Alias "_C13_AsciiTrimTrail@4" (ByRef buf As String)
    Public Declare Sub C13_AsciiTrimZero Lib "C13W32.DLL" Alias "_C13_AsciiTrimZero@4" (ByRef buf As String)
    Public Declare Function C13_BCConfigEx Lib "C13W32.DLL" Alias "_C13_BCConfigEx@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCConfigMsg Lib "C13W32.DLL" Alias "_C13_BCConfigMsg@12" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_BCCreateListEx Lib "C13W32.DLL" Alias "_C13_BCCreateListEx@32" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_BCCreateListExx Lib "C13W32.DLL" Alias "_C13_BCCreateListExx@32" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_BCGetMsg Lib "C13W32.DLL" Alias "_C13_BCGetMsg@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_BCSchedAgain Lib "C13W32.DLL" Alias "_C13_BCSchedAgain@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedBranch Lib "C13W32.DLL" Alias "_C13_BCSchedBranch@12" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedBranchDin0 Lib "C13W32.DLL" Alias "_C13_BCSchedBranchDin0@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedBranchDin1 Lib "C13W32.DLL" Alias "_C13_BCSchedBranchDin1@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedBranchEx Lib "C13W32.DLL" Alias "_C13_BCSchedBranchEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedBuild Lib "C13W32.DLL" Alias "_C13_BCSchedBuild@16" (ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef freq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedCall Lib "C13W32.DLL" Alias "_C13_BCSchedCall@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedCallCond Lib "C13W32.DLL" Alias "_C13_BCSchedCallCond@12" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedCallCondEx Lib "C13W32.DLL" Alias "_C13_BCSchedCallCondEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedEntry Lib "C13W32.DLL" Alias "_C13_BCSchedEntry@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedFrameEnd Lib "C13W32.DLL" Alias "_C13_BCSchedFrameEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedFrameStart Lib "C13W32.DLL" Alias "_C13_BCSchedFrameStart@8" (ByVal timeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedGap Lib "C13W32.DLL" Alias "_C13_BCSchedGap@8" (ByVal gapval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedGoto Lib "C13W32.DLL" Alias "_C13_BCSchedGoto@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedHalt Lib "C13W32.DLL" Alias "_C13_BCSchedHalt@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedInt Lib "C13W32.DLL" Alias "_C13_BCSchedInt@8" (ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedIntCond Lib "C13W32.DLL" Alias "_C13_BCSchedIntCond@12" (ByVal condition As UInt16, ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedIntCondEx Lib "C13W32.DLL" Alias "_C13_BCSchedIntCondEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedNop Lib "C13W32.DLL" Alias "_C13_BCSchedNop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedPause Lib "C13W32.DLL" Alias "_C13_BCSchedPause@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedPulse Lib "C13W32.DLL" Alias "_C13_BCSchedPulse@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedPulse0 Lib "C13W32.DLL" Alias "_C13_BCSchedPulse0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedPulse1 Lib "C13W32.DLL" Alias "_C13_BCSchedPulse1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedRestart Lib "C13W32.DLL" Alias "_C13_BCSchedRestart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedRetryEx Lib "C13W32.DLL" Alias "_C13_BCSchedRetryEx@24" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal retryflag As UInt16, ByVal retries As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedReturn Lib "C13W32.DLL" Alias "_C13_BCSchedReturn@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSchedUser Lib "C13W32.DLL" Alias "_C13_BCSchedUser@8" (ByVal useraddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSetEntry Lib "C13W32.DLL" Alias "_C13_BCSetEntry@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BCSetTimeout Lib "C13W32.DLL" Alias "_C13_BCSetTimeout@8" (ByVal timeoutval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BlkAddr Lib "C13W32.DLL" Alias "_C13_BlkAddr@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_BlkOptRd Lib "C13W32.DLL" Alias "_C13_BlkOptRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_BlkOptWr Lib "C13W32.DLL" Alias "_C13_BlkOptWr@12" (ByVal rtopt As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BlkPtrRd Lib "C13W32.DLL" Alias "_C13_BlkPtrRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub C13_BlkPtrWr Lib "C13W32.DLL" Alias "_C13_BlkPtrWr@12" (ByVal descaddr As UInt32, ByVal taval As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_BlkRd Lib "C13W32.DLL" Alias "_C13_BlkRd@12" (ByRef block As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BlkReset Lib "C13W32.DLL" Alias "_C13_BlkReset@8" (ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BlkSWDRd Lib "C13W32.DLL" Alias "_C13_BlkSWDRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_BlkSWDWr Lib "C13W32.DLL" Alias "_C13_BlkSWDWr@12" (ByVal swdval As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BlkWipe Lib "C13W32.DLL" Alias "_C13_BlkWipe@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_BlkWr Lib "C13W32.DLL" Alias "_C13_BlkWr@12" (ByRef block As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardBoot Lib "C13W32.DLL" Alias "_C13_CardBoot@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardCloseAll Lib "C13W32.DLL" Alias "_C13_CardCloseAll@0" () As Int32
    Public Declare Function C13_CardConfig Lib "C13W32.DLL" Alias "_C13_CardConfig@16" (ByVal enableflag As Int32, ByVal command As UInt16, ByVal taval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardGetInfo Lib "C13W32.DLL" Alias "_C13_CardGetInfo@8" (ByVal infotype As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_CardGetInfos Lib "C13W32.DLL" Alias "_C13_CardGetInfos@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_CardGetParam Lib "C13W32.DLL" Alias "_C13_CardGetParam@36" (ByRef cardstr As String, ByRef cardnum As Int32, ByRef devnum As Int32, ByRef sizval As UInt32, ByRef memval As UInt16, ByRef ioval As UInt16, ByRef irqval As UInt16, ByRef spdval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub C13_CardInit Lib "C13W32.DLL" Alias "_C13_CardInit@0" ()
    Public Declare Function C13_CardIsRunning Lib "C13W32.DLL" Alias "_C13_CardIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardOpenEx Lib "C13W32.DLL" Alias "_C13_CardOpenEx@8" (ByRef cardname As String, ByVal cardnum As Int32) As UInt32
    Public Declare Function C13_CardOpenExx Lib "C13W32.DLL" Alias "_C13_CardOpenExx@16" (ByRef cardname As String, ByVal cardnum As Int32, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Sub C13_CardResetEx Lib "C13W32.DLL" Alias "_C13_CardResetEx@4" (ByVal handleval As UInt32)
    Public Declare Function C13_CardResume Lib "C13W32.DLL" Alias "_C13_CardResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardTest Lib "C13W32.DLL" Alias "_C13_CardTest@8" (ByVal level As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardTest0 Lib "C13W32.DLL" Alias "_C13_CardTest0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardTest1 Lib "C13W32.DLL" Alias "_C13_CardTest1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardTest2 Lib "C13W32.DLL" Alias "_C13_CardTest2@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CardTest3 Lib "C13W32.DLL" Alias "_C13_CardTest3@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub C13_CardTrigger Lib "C13W32.DLL" Alias "_C13_CardTrigger@4" (ByVal handleval As UInt32)
    Public Declare Sub C13_CDBase Lib "C13W32.DLL" Alias "" (ByRef memval As UInt16, ByRef ioval As UInt16, ByRef irqval As UInt16, ByRef sizval As UInt16, ByRef spdval As UInt16, ByVal socketval As Int32)
    Public Declare Function C13_CDDeregisterClient Lib "C13W32.DLL" Alias "" () As Int32
    Public Declare Function C13_CDMapMem Lib "C13W32.DLL" Alias "" (ByVal offset As UInt32, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDRegisterClient Lib "C13W32.DLL" Alias "" () As Int32
    Public Declare Function C13_CDReleaseAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDReleaseConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDReleaseDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDReleaseExclusive Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDReleaseIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDReleaseIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDReleaseMem Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDRequestAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDRequestConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDRequestDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDRequestExclusive Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDRequestIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDRequestIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDRequestMem Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDReset Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDRestartAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Sub C13_CDVarConfig Lib "C13W32.DLL" Alias "" (ByVal value As UInt32, ByVal symbol As UInt16, ByVal socketval As Int32)
    Public Declare Function C13_CDVarCount Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As UInt16
    Public Declare Sub C13_CDVarDefault Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32)
    Public Declare Function C13_CDVarLoad Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CDVarQuery Lib "C13W32.DLL" Alias "" (ByVal symbol As UInt16, ByVal socketval As Int32) As UInt32
    Public Declare Function C13_CDVarRetrieve Lib "C13W32.DLL" Alias "" (ByVal index As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEAttributeConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Sub C13_CEBase Lib "C13W32.DLL" Alias "" (ByRef memval As UInt16, ByRef ioval As UInt16, ByRef irqval As UInt16, ByRef sizval As UInt16, ByRef spdval As UInt16, ByVal socketval As Int32)
    Public Declare Function C13_CECall Lib "C13W32.DLL" Alias "" (ByVal func As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CECallEx Lib "C13W32.DLL" Alias "" (ByVal func As UInt16, ByVal socketval As Int32, ByRef valuewptr As UInt16, ByRef valuelptr As UInt32) As Int32
    Public Declare Function C13_CECISClose Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CECISDisable Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CECISEnable Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CECISFlush Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CECISOpen Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CECISRead Lib "C13W32.DLL" Alias "" (ByRef value As UInt16, ByVal addr As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CECISReads Lib "C13W32.DLL" Alias "" (ByRef value As UInt16, ByVal addr As UInt16, ByVal count As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CECISWrite Lib "C13W32.DLL" Alias "" (ByVal value As UInt16, ByVal addr As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CECISWrites Lib "C13W32.DLL" Alias "" (ByRef value As UInt16, ByVal addr As UInt16, ByVal count As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEDeregisterClient Lib "C13W32.DLL" Alias "" () As Int32
    Public Declare Sub C13_CEErrorClear Lib "C13W32.DLL" Alias "" ()
    Public Declare Function C13_CEErrorCount Lib "C13W32.DLL" Alias "" () As UInt16
    Public Declare Function C13_CEErrorValue Lib "C13W32.DLL" Alias "" (ByVal index As UInt16) As Int32
    Public Declare Function C13_CEFiveVoltConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEFuncID Lib "C13W32.DLL" Alias "" () As UInt16
    Public Declare Function C13_CEIOAttrConfig Lib "C13W32.DLL" Alias "" (ByVal attrval As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEIOBaseConfig Lib "C13W32.DLL" Alias "" (ByVal basevalval As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEIRQAttrConfig Lib "C13W32.DLL" Alias "" (ByVal attrval As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEIRQIrqConfig Lib "C13W32.DLL" Alias "" (ByVal irqval As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEMapMemory Lib "C13W32.DLL" Alias "" (ByVal offset As UInt32, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEMemAttrConfig Lib "C13W32.DLL" Alias "" (ByVal attrval As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEMemBaseConfig Lib "C13W32.DLL" Alias "" (ByVal basevalval As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEMemSizeConfig Lib "C13W32.DLL" Alias "" (ByVal sizeval As UInt32, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEMemSpeedConfig Lib "C13W32.DLL" Alias "" (ByVal speedval As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEPresent Lib "C13W32.DLL" Alias "" () As Int32
    Public Declare Function C13_CERegisterClient Lib "C13W32.DLL" Alias "" () As Int32
    Public Declare Function C13_CEReleaseAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEReleaseConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEReleaseDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEReleaseIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEReleaseIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEReleaseMemory Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CERequestAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CERequestConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CERequestDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CERequestIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CERequestIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CERequestMemory Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEReset Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEResetCheck Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CEResetError Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CERestartAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Sub C13_CEVarConfig Lib "C13W32.DLL" Alias "" (ByVal value As UInt32, ByVal symbol As UInt16, ByVal socketval As Int32)
    Public Declare Sub C13_CEVarDefault Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32)
    Public Declare Function C13_CEVarQuery Lib "C13W32.DLL" Alias "" (ByVal symbol As UInt16, ByVal socketval As Int32) As UInt32
    Public Declare Function C13_CEZeroVoltConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As Int32
    Public Declare Function C13_CmdAddr Lib "C13W32.DLL" Alias "_C13_CmdAddr@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_CmdAlloc Lib "C13W32.DLL" Alias "_C13_CmdAlloc@8" (ByVal count As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_CmdAllocEx Lib "C13W32.DLL" Alias "_C13_CmdAllocEx@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_CmdBaseRd Lib "C13W32.DLL" Alias "_C13_CmdBaseRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Sub C13_CmdBaseWr Lib "C13W32.DLL" Alias "_C13_CmdBaseWr@8" (ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function C13_CmdClear Lib "C13W32.DLL" Alias "_C13_CmdClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CmdCountRd Lib "C13W32.DLL" Alias "_C13_CmdCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_CmdCountWr Lib "C13W32.DLL" Alias "_C13_CmdCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C13_CmdCtrlRd Lib "C13W32.DLL" Alias "_C13_CmdCtrlRd@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_CmdCtrlWr Lib "C13W32.DLL" Alias "_C13_CmdCtrlWr@12" (ByVal ctrlval As UInt16, ByVal index As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_CmdCurrRd Lib "C13W32.DLL" Alias "_C13_CmdCurrRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_CmdCurrWr Lib "C13W32.DLL" Alias "_C13_CmdCurrWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C13_CmdInit Lib "C13W32.DLL" Alias "_C13_CmdInit@8" (ByVal opcode As UInt16, ByRef block As UInt16)
    Public Declare Function C13_CmdInsert Lib "C13W32.DLL" Alias "_C13_CmdInsert@8" (ByRef block As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CmdMaxRd Lib "C13W32.DLL" Alias "_C13_CmdMaxRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_CmdMaxWr Lib "C13W32.DLL" Alias "_C13_CmdMaxWr@8" (ByVal count As UInt16, ByVal handleval As UInt32)
    Public Declare Function C13_CmdRd Lib "C13W32.DLL" Alias "_C13_CmdRd@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CmdShotWr Lib "C13W32.DLL" Alias "_C13_CmdShotWr@12" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CmdSkipWr Lib "C13W32.DLL" Alias "_C13_CmdSkipWr@12" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub C13_CmdStackClear Lib "C13W32.DLL" Alias "_C13_CmdStackClear@4" (ByVal handleval As UInt32)
    Public Declare Function C13_CmdStartRd Lib "C13W32.DLL" Alias "_C13_CmdStartRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_CmdStartWr Lib "C13W32.DLL" Alias "_C13_CmdStartWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C13_CmdTotalRd Lib "C13W32.DLL" Alias "_C13_CmdTotalRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub C13_CmdTotalWr Lib "C13W32.DLL" Alias "_C13_CmdTotalWr@8" (ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_CmdWr Lib "C13W32.DLL" Alias "_C13_CmdWr@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommCall Lib "C13W32.DLL" Alias "_C13_CommCall@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommCheck Lib "C13W32.DLL" Alias "_C13_CommCheck@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommCheckEx Lib "C13W32.DLL" Alias "_C13_CommCheckEx@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommConfig Lib "C13W32.DLL" Alias "_C13_CommConfig@12" (ByVal enableflag As Int32, ByVal command As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommDataRdL Lib "C13W32.DLL" Alias "_C13_CommDataRdL@12" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommDataRdsW Lib "C13W32.DLL" Alias "_C13_CommDataRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommDataRdW Lib "C13W32.DLL" Alias "_C13_CommDataRdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommDataWrL Lib "C13W32.DLL" Alias "_C13_CommDataWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommDataWrsW Lib "C13W32.DLL" Alias "_C13_CommDataWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommDataWrW Lib "C13W32.DLL" Alias "_C13_CommDataWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommDisable Lib "C13W32.DLL" Alias "_C13_CommDisable@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommEnable Lib "C13W32.DLL" Alias "_C13_CommEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommErrRdsW Lib "C13W32.DLL" Alias "_C13_CommErrRdsW@12" (ByRef errbuf As UInt16, ByVal errbufcount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommErrWrsW Lib "C13W32.DLL" Alias "_C13_CommErrWrsW@12" (ByRef errbuf As UInt16, ByVal errbufcount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommGlobRdW Lib "C13W32.DLL" Alias "_C13_CommGlobRdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommGlobWrW Lib "C13W32.DLL" Alias "_C13_CommGlobWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommInfoRdsW Lib "C13W32.DLL" Alias "_C13_CommInfoRdsW@20" (ByRef bufmodel As UInt16, ByVal bufmodelcount As UInt16, ByRef buffeature As UInt16, ByVal buffeaturecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommProgRdW Lib "C13W32.DLL" Alias "_C13_CommProgRdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommProgWrW Lib "C13W32.DLL" Alias "_C13_CommProgWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommRun Lib "C13W32.DLL" Alias "_C13_CommRun@20" (ByRef dataptr As UInt16, ByVal datacount As UInt16, ByRef progptr As UInt16, ByVal progcount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommStart Lib "C13W32.DLL" Alias "_C13_CommStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CommStop Lib "C13W32.DLL" Alias "_C13_CommStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_CSAdjustResourceInfo Lib "C13W32.DLL" Alias "" (ByVal action As UInt16, ByVal resource As UInt16, ByVal resourceinfo As IntPtr, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSAdjustResourceInfoDma Lib "C13W32.DLL" Alias "" (ByVal action As UInt16, ByVal dmainfo As IntPtr, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSAdjustResourceInfoIo Lib "C13W32.DLL" Alias "" (ByVal action As UInt16, ByVal ioinfo As IntPtr, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSAdjustResourceInfoIrq Lib "C13W32.DLL" Alias "" (ByVal action As UInt16, ByVal irqinfo As IntPtr, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSAdjustResourceInfoMem Lib "C13W32.DLL" Alias "" (ByVal action As UInt16, ByVal meminfo As IntPtr, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSCall Lib "C13W32.DLL" Alias "" (ByVal func As UInt16, ByRef handle As UInt16, ByVal ptr As IntPtr, ByVal argptr As IntPtr, ByVal arglen As UInt16) As UInt16
    Public Declare Function C13_CSDeregisterClient Lib "C13W32.DLL" Alias "" (ByVal clientinfo As IntPtr) As Int32
    Public Declare Sub C13_CSErrClear Lib "C13W32.DLL" Alias "" ()
    Public Declare Function C13_CSErrGetCode Lib "C13W32.DLL" Alias "" (ByVal index As UInt16) As Int32
    Public Declare Function C13_CSErrGetCount Lib "C13W32.DLL" Alias "" () As UInt16
    Public Declare Sub C13_CSErrInsert Lib "C13W32.DLL" Alias "" (ByVal errval As Int32)
    Public Declare Function C13_CSGetCardServicesInfoStr Lib "C13W32.DLL" Alias "" (ByRef vendorstring As String, ByVal vendorstringlen As UInt16) As Int32
    Public Declare Function C13_CSGetCardServicesInfoVal Lib "C13W32.DLL" Alias "" (ByVal csinfo As IntPtr) As Int32
    Public Declare Function C13_CSGetClientInfo Lib "C13W32.DLL" Alias "" (ByRef namestring As String, ByVal namestringlen As UInt16, ByRef vendorstring As String, ByVal vendorstringlen As UInt16, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSGetClientInfoName Lib "C13W32.DLL" Alias "" (ByRef namestring As String, ByVal namestringlen As UInt16, ByVal clientinfo As IntPtr) As UInt32
    Public Declare Function C13_CSGetClientInfoVendor Lib "C13W32.DLL" Alias "" (ByRef vendorstring As String, ByVal vendorstringlen As UInt16, ByVal clientinfo As IntPtr) As UInt32
    Public Declare Function C13_CSGetConfigurationInfo Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal configinfo As IntPtr, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSGetFirstClient Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal attributes As UInt16, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSGetFirstTuple Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal attributes As UInt16, ByVal desiredtuple As UInt16, ByVal tupleinfo As IntPtr) As UInt16
    Public Declare Function C13_CSGetNextClient Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal attributes As UInt16, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSGetNextTuple Lib "C13W32.DLL" Alias "" (ByVal desiredtuple As UInt16, ByVal tupleinfo As IntPtr) As UInt16
    Public Declare Function C13_CSGetStatus Lib "C13W32.DLL" Alias "" (ByRef cardstate As UInt16, ByRef socketstate As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CSGetStatusCard Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As UInt16
    Public Declare Function C13_CSGetStatusSocket Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As UInt16
    Public Declare Function C13_CSGetTupleChan Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As UInt16
    Public Declare Function C13_CSGetTupleCount Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal desiredtuple As UInt16) As UInt16
    Public Declare Function C13_CSGetTupleData Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal tupleoffset As UInt16, ByRef tupledata As Byte, ByVal tupledatalen As UInt16, ByVal tupleinfo As IntPtr) As UInt16
    Public Declare Function C13_CSGetTupleIndex Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal index As UInt16, ByVal desiredtuple As UInt16, ByRef tupledata As Byte, ByVal tupledatalen As UInt16) As UInt16
    Public Declare Function C13_CSGetTupleManuf Lib "C13W32.DLL" Alias "" (ByRef code As UInt16, ByRef info As UInt16, ByVal socketval As Int32) As Int32
    Public Declare Function C13_CSLevel Lib "C13W32.DLL" Alias "" () As UInt16
    Public Declare Function C13_CSMapMemPage Lib "C13W32.DLL" Alias "" (ByVal cardoffset As UInt32, ByVal page As UInt16, ByVal windowinfo As IntPtr) As Int32
    Public Declare Function C13_CSModifyConfiguration Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal configinfo As IntPtr, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSModifyWindow Lib "C13W32.DLL" Alias "" (ByVal attributes As UInt16, ByVal accessspeed As UInt16, ByVal windowinfo As IntPtr) As Int32
    Public Declare Function C13_CSRegisterClient Lib "C13W32.DLL" Alias "" (ByVal attributes As UInt16, ByVal eventvalmask As UInt16, ByVal version As UInt16, ByVal clientinfo As IntPtr, ByVal func As IntPtr, ByVal data As UInt16, ByVal dataptr As IntPtr) As Int32
    Public Declare Function C13_CSReleaseConfiguration Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSReleaseDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal desiredchannel As UInt16, ByVal attributes As Byte, ByVal assignedchannel As Byte, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSReleaseExclusive Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal attributes As UInt16, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSReleaseIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal basevalport As UInt16, ByVal numports As UInt16, ByVal attributes As UInt16, ByVal ioaddrlines As UInt16, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSReleaseIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal attributes As UInt16, ByVal assignedirq As UInt16, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSReleaseWindow Lib "C13W32.DLL" Alias "" (ByVal windowinfo As IntPtr) As Int32
    Public Declare Function C13_CSRequestConfiguration Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal configinfo As IntPtr, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSRequestDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal desiredchannel As UInt16, ByVal attributes As Byte, ByRef assignedchannel As Byte, ByVal clientinfo As IntPtr) As Byte
    Public Declare Function C13_CSRequestExclusive Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal attributes As UInt16, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSRequestIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal basevalport As UInt16, ByVal numports As UInt16, ByVal attributes As UInt16, ByVal ioaddrlines As UInt16, ByVal clientinfo As IntPtr) As UInt16
    Public Declare Function C13_CSRequestIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByRef attributes As UInt16, ByVal irqinfo1 As UInt16, ByVal irqinfo2 As UInt16, ByVal clientinfo As IntPtr) As UInt16
    Public Declare Function C13_CSRequestWindow Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByRef attributes As UInt16, ByRef baseval As UInt32, ByRef size As UInt32, ByVal accessspeed As UInt16, ByVal windowinfo As IntPtr, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSResetCard Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32, ByVal clientinfo As IntPtr) As Int32
    Public Declare Function C13_CSRevision Lib "C13W32.DLL" Alias "" () As UInt16
    Public Declare Function C13_CSSignature Lib "C13W32.DLL" Alias "" () As UInt16
    Public Declare Function C13_CSSocketCount Lib "C13W32.DLL" Alias "" () As UInt16
    Public Declare Function C13_CSValidateCIS Lib "C13W32.DLL" Alias "" (ByVal socketval As Int32) As UInt16
    Public Declare Function C13_CSVendorString Lib "C13W32.DLL" Alias "" (ByRef buf As String, ByVal bufsize As UInt16) As UInt32
    Public Declare Sub C13_DARClear Lib "C13W32.DLL" Alias "_C13_DARClear@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C13_DARGet Lib "C13W32.DLL" Alias "_C13_DARGet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DARRdL Lib "C13W32.DLL" Alias "_C13_DARRdL@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_DARRdW Lib "C13W32.DLL" Alias "_C13_DARRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_DARSet Lib "C13W32.DLL" Alias "_C13_DARSet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C13_DARWrL Lib "C13W32.DLL" Alias "_C13_DARWrL@12" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C13_DARWrW Lib "C13W32.DLL" Alias "_C13_DARWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C13_DescAddr Lib "C13W32.DLL" Alias "_C13_DescAddr@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_DescAlloc Lib "C13W32.DLL" Alias "_C13_DescAlloc@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_DescConfig Lib "C13W32.DLL" Alias "_C13_DescConfig@24" (ByVal configval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DescOptRd Lib "C13W32.DLL" Alias "_C13_DescOptRd@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_DescOptWr Lib "C13W32.DLL" Alias "_C13_DescOptWr@24" (ByVal descopt As UInt16, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_DescPtrRd Lib "C13W32.DLL" Alias "_C13_DescPtrRd@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_DescPtrWr Lib "C13W32.DLL" Alias "_C13_DescPtrWr@24" (ByVal msgaddr As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_DescRd Lib "C13W32.DLL" Alias "_C13_DescRd@24" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByRef desc As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_DescWr Lib "C13W32.DLL" Alias "_C13_DescWr@24" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByRef desc As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_Div Lib "C13W32.DLL" Alias "_C13_Div@8" (ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
    Public Declare Function C13_DllUsageCount Lib "C13W32.DLL" Alias "_C13_DllUsageCount@0" () As Int32
    Public Declare Function C13_DspBioClear Lib "C13W32.DLL" Alias "_C13_DspBioClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DspBioRd Lib "C13W32.DLL" Alias "_C13_DspBioRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DspBioSet Lib "C13W32.DLL" Alias "_C13_DspBioSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DspIntfClear Lib "C13W32.DLL" Alias "_C13_DspIntfClear@8" (ByVal intmask As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DspIntfRd Lib "C13W32.DLL" Alias "_C13_DspIntfRd@8" (ByVal intmask As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DspIntmClear Lib "C13W32.DLL" Alias "_C13_DspIntmClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DspIntmSet Lib "C13W32.DLL" Alias "_C13_DspIntmSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DspXfClear Lib "C13W32.DLL" Alias "_C13_DspXfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DspXfRd Lib "C13W32.DLL" Alias "_C13_DspXfRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_DspXfSet Lib "C13W32.DLL" Alias "_C13_DspXfSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ErrDesc Lib "C13W32.DLL" Alias "_C13_ErrDesc@4" (ByVal errval As Int32) As UInt32
    Public Declare Function C13_ErrDescStr Lib "C13W32.DLL" Alias "_C13_ErrDescStr@4" (ByVal errval As Int32) As UInt32
    Public Declare Function C13_ErrName Lib "C13W32.DLL" Alias "_C13_ErrName@4" (ByVal errval As Int32) As UInt32
    Public Declare Function C13_ErrorIsTaggedBC Lib "C13W32.DLL" Alias "_C13_ErrorIsTaggedBC@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ErrorIsTaggedRT Lib "C13W32.DLL" Alias "_C13_ErrorIsTaggedRT@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ErrorResponse Lib "C13W32.DLL" Alias "_C13_ErrorResponse@8" (ByVal responseval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub C13_ErrorSync Lib "C13W32.DLL" Alias "_C13_ErrorSync@8" (ByVal value As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_ErrorTimeout Lib "C13W32.DLL" Alias "_C13_ErrorTimeout@8" (ByVal timeoutval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ExtDinRd Lib "C13W32.DLL" Alias "_C13_ExtDinRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ExtDoutRd Lib "C13W32.DLL" Alias "_C13_ExtDoutRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub C13_ExtDoutWr Lib "C13W32.DLL" Alias "_C13_ExtDoutWr@8" (ByVal doutval As Int32, ByVal handleval As UInt32)
    Public Declare Sub C13_FileClose Lib "C13W32.DLL" Alias "_C13_FileClose@4" (ByVal handle As IntPtr)
    Public Declare Function C13_FileErr Lib "C13W32.DLL" Alias "_C13_FileErr@0" () As Int32
    Public Declare Sub C13_FileErrClear Lib "C13W32.DLL" Alias "_C13_FileErrClear@0" ()
    Public Declare Sub C13_FileErrSet Lib "C13W32.DLL" Alias "_C13_FileErrSet@0" ()
    Public Declare Function C13_FileOpenRead Lib "C13W32.DLL" Alias "_C13_FileOpenRead@4" (ByRef filename As String) As UInt32
    Public Declare Function C13_FileOpenWrite Lib "C13W32.DLL" Alias "_C13_FileOpenWrite@4" (ByRef filename As String) As UInt32
    Public Declare Function C13_FileRead Lib "C13W32.DLL" Alias "_C13_FileRead@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function C13_FileSeek Lib "C13W32.DLL" Alias "_C13_FileSeek@8" (ByVal handle As IntPtr, ByVal offset As UInt32) As Int32
    Public Declare Function C13_FileTell Lib "C13W32.DLL" Alias "_C13_FileTell@4" (ByVal handle As IntPtr) As UInt32
    Public Declare Function C13_FileWrite Lib "C13W32.DLL" Alias "_C13_FileWrite@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function C13_GetHigh Lib "C13W32.DLL" Alias "_C13_GetHigh@4" (ByVal val As UInt32) As UInt16
    Public Declare Function C13_GetLow Lib "C13W32.DLL" Alias "_C13_GetLow@4" (ByVal val As UInt32) As UInt16
    Public Declare Function C13_GetOff Lib "C13W32.DLL" Alias "_C13_GetOff@4" (ByVal valptr As IntPtr) As UInt16
    Public Declare Function C13_GetSeg Lib "C13W32.DLL" Alias "_C13_GetSeg@4" (ByVal valptr As IntPtr) As UInt16
    Public Declare Function C13_GlobalRdW Lib "C13W32.DLL" Alias "_C13_GlobalRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_GlobalWrW Lib "C13W32.DLL" Alias "_C13_GlobalWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C13_HandleClose Lib "C13W32.DLL" Alias "_C13_HandleClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HandleDel Lib "C13W32.DLL" Alias "_C13_HandleDel@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HandleIns Lib "C13W32.DLL" Alias "_C13_HandleIns@16" (ByRef cardname As String, ByVal cardnum As Int32, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Function C13_HandleOkay Lib "C13W32.DLL" Alias "_C13_HandleOkay@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HandleOpen Lib "C13W32.DLL" Alias "_C13_HandleOpen@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HandleOpenDOS Lib "C13W32.DLL" Alias "" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HandleOpenWin Lib "C13W32.DLL" Alias "_C13_HandleOpenWin@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HandleVer Lib "C13W32.DLL" Alias "_C13_HandleVer@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HeapAlloc Lib "C13W32.DLL" Alias "_C13_HeapAlloc@8" (ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_HeapAllocAll Lib "C13W32.DLL" Alias "_C13_HeapAllocAll@8" (ByRef wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_HeapAllocAllDPM Lib "C13W32.DLL" Alias "_C13_HeapAllocAllDPM@8" (ByRef wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_HeapAllocDPM Lib "C13W32.DLL" Alias "_C13_HeapAllocDPM@8" (ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_HeapAllocEx Lib "C13W32.DLL" Alias "_C13_HeapAllocEx@12" (ByVal configval As UInt16, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_HeapWipe Lib "C13W32.DLL" Alias "_C13_HeapWipe@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_HeapWipeDPM Lib "C13W32.DLL" Alias "_C13_HeapWipeDPM@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_HPMAddrRd Lib "C13W32.DLL" Alias "_C13_HPMAddrRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_HPMAddrWr Lib "C13W32.DLL" Alias "_C13_HPMAddrWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HPMCtrlRd Lib "C13W32.DLL" Alias "_C13_HPMCtrlRd@4" (ByVal handleval As UInt32) As Byte
    Public Declare Function C13_HPMCtrlWr Lib "C13W32.DLL" Alias "_C13_HPMCtrlWr@8" (ByVal value As Byte, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HPMDataRd Lib "C13W32.DLL" Alias "_C13_HPMDataRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_HPMDataRds Lib "C13W32.DLL" Alias "_C13_HPMDataRds@12" (ByRef valueptr As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HPMDataWr Lib "C13W32.DLL" Alias "_C13_HPMDataWr@8" (ByVal value As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HPMDataWrs Lib "C13W32.DLL" Alias "_C13_HPMDataWrs@12" (ByRef valueptr As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_HPMRdL Lib "C13W32.DLL" Alias "_C13_HPMRdL@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Sub C13_HPMRdsL Lib "C13W32.DLL" Alias "_C13_HPMRdsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub C13_HPMRdsW Lib "C13W32.DLL" Alias "_C13_HPMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_HPMRdW Lib "C13W32.DLL" Alias "_C13_HPMRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_HPMWrL Lib "C13W32.DLL" Alias "_C13_HPMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C13_HPMWrsL Lib "C13W32.DLL" Alias "_C13_HPMWrsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub C13_HPMWrsW Lib "C13W32.DLL" Alias "_C13_HPMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub C13_HPMWrW Lib "C13W32.DLL" Alias "_C13_HPMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C13_IntClear Lib "C13W32.DLL" Alias "_C13_IntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_IntConfig Lib "C13W32.DLL" Alias "_C13_IntConfig@12" (ByVal configval As UInt16, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_IntDisable Lib "C13W32.DLL" Alias "_C13_IntDisable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_IntEnable Lib "C13W32.DLL" Alias "_C13_IntEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_IntEnableCond Lib "C13W32.DLL" Alias "_C13_IntEnableCond@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_IntGet Lib "C13W32.DLL" Alias "_C13_IntGet@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_IntInstall Lib "C13W32.DLL" Alias "_C13_IntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_IntRd Lib "C13W32.DLL" Alias "_C13_IntRd@12" (ByRef typevalval As UInt16, ByRef infoval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Sub C13_IntReset Lib "C13W32.DLL" Alias "_C13_IntReset@4" (ByVal handleval As UInt32)
    Public Declare Function C13_IntStatus Lib "C13W32.DLL" Alias "_C13_IntStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_IntUninstall Lib "C13W32.DLL" Alias "_C13_IntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_IORdW Lib "C13W32.DLL" Alias "_C13_IORdW@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_IOWINRdW Lib "C13W32.DLL" Alias "_C13_IOWINRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_IOWINWrW Lib "C13W32.DLL" Alias "_C13_IOWINWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C13_IOWrW Lib "C13W32.DLL" Alias "_C13_IOWrW@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_KernEnd Lib "C13W32.DLL" Alias "_C13_KernEnd@4" (ByVal vxdptr As IntPtr) As Int32
    Public Declare Function C13_KernIntClear Lib "C13W32.DLL" Alias "_C13_KernIntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernIntInstall Lib "C13W32.DLL" Alias "_C13_KernIntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernIntParam Lib "C13W32.DLL" Alias "_C13_KernIntParam@32" (ByVal clraddr As UInt32, ByVal clrwidth As UInt32, ByVal clrvalue As UInt32, ByVal stataddr As UInt32, ByVal statwidth As UInt32, ByVal statvalue As UInt32, ByVal statmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernIntStatus Lib "C13W32.DLL" Alias "_C13_KernIntStatus@8" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernIntUninstall Lib "C13W32.DLL" Alias "_C13_KernIntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernIORdB Lib "C13W32.DLL" Alias "_C13_KernIORdB@12" (ByRef valueptr As Byte, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernIOWrB Lib "C13W32.DLL" Alias "_C13_KernIOWrB@12" (ByVal value As Byte, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMCopyB Lib "C13W32.DLL" Alias "_C13_KernMEMCopyB@12" (ByVal destptr As IntPtr, ByVal srcptr As IntPtr, ByVal countval As UInt16) As Int32
    Public Declare Function C13_KernMEMFillW Lib "C13W32.DLL" Alias "_C13_KernMEMFillW@20" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMRdB Lib "C13W32.DLL" Alias "_C13_KernMEMRdB@16" (ByRef valueptr As Byte, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMRdL Lib "C13W32.DLL" Alias "_C13_KernMEMRdL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMRdsL Lib "C13W32.DLL" Alias "_C13_KernMEMRdsL@20" (ByRef bufptr As UInt32, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMRdsW Lib "C13W32.DLL" Alias "_C13_KernMEMRdsW@20" (ByRef bufptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMRdW Lib "C13W32.DLL" Alias "_C13_KernMEMRdW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMWrB Lib "C13W32.DLL" Alias "_C13_KernMEMWrB@16" (ByVal value As Byte, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMWrL Lib "C13W32.DLL" Alias "_C13_KernMEMWrL@16" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMWrsL Lib "C13W32.DLL" Alias "_C13_KernMEMWrsL@20" (ByRef bufptr As UInt32, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMWrsW Lib "C13W32.DLL" Alias "_C13_KernMEMWrsW@20" (ByRef bufptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernMEMWrW Lib "C13W32.DLL" Alias "_C13_KernMEMWrW@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_KernStatus Lib "C13W32.DLL" Alias "_C13_KernStatus@16" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal index As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ListAddr Lib "C13W32.DLL" Alias "_C13_ListAddr@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_ListAddrEx Lib "C13W32.DLL" Alias "_C13_ListAddrEx@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Function C13_ListBlockRd Lib "C13W32.DLL" Alias "_C13_ListBlockRd@12" (ByRef buf As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_ListBlockRdEx Lib "C13W32.DLL" Alias "_C13_ListBlockRdEx@16" (ByRef buf As UInt16, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_ListBlockWr Lib "C13W32.DLL" Alias "_C13_ListBlockWr@12" (ByRef buf As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_ListBlockWrEx Lib "C13W32.DLL" Alias "_C13_ListBlockWrEx@16" (ByRef buf As UInt16, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_ListClear Lib "C13W32.DLL" Alias "_C13_ListClear@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ListConfig Lib "C13W32.DLL" Alias "_C13_ListConfig@16" (ByVal configval As UInt32, ByVal count As Int32, ByVal skipval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_ListConfigEx Lib "C13W32.DLL" Alias "_C13_ListConfigEx@16" (ByVal configval As UInt32, ByVal count As Int32, ByVal skipval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_ListDataRdEx Lib "C13W32.DLL" Alias "_C13_ListDataRdEx@20" (ByRef buf As UInt16, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ListDataWrEx Lib "C13W32.DLL" Alias "_C13_ListDataWrEx@20" (ByRef buf As UInt16, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ListInit Lib "C13W32.DLL" Alias "_C13_ListInit@12" (ByVal listaddr As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ListNextRd Lib "C13W32.DLL" Alias "_C13_ListNextRd@8" (ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Function C13_ListNextWr Lib "C13W32.DLL" Alias "_C13_ListNextWr@8" (ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Sub C13_ListPostRd Lib "C13W32.DLL" Alias "_C13_ListPostRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C13_ListPostWr Lib "C13W32.DLL" Alias "_C13_ListPostWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C13_ListPreRd Lib "C13W32.DLL" Alias "_C13_ListPreRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C13_ListPreWr Lib "C13W32.DLL" Alias "_C13_ListPreWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Function C13_ListStatus Lib "C13W32.DLL" Alias "_C13_ListStatus@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Sub C13_MakeClientInfo Lib "C13W32.DLL" Alias "" (ByVal ptr As IntPtr)
    Public Declare Function C13_MakeLong Lib "C13W32.DLL" Alias "_C13_MakeLong@8" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
    Public Declare Function C13_MakePtr Lib "C13W32.DLL" Alias "_C13_MakePtr@8" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
    Public Declare Function C13_Mask Lib "C13W32.DLL" Alias "_C13_Mask@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Sub C13_MEMWINFillW Lib "C13W32.DLL" Alias "_C13_MEMWINFillW@20" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_MEMWINRdB Lib "C13W32.DLL" Alias "_C13_MEMWINRdB@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_MEMWINRdL Lib "C13W32.DLL" Alias "_C13_MEMWINRdL@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub C13_MEMWINRdsL Lib "C13W32.DLL" Alias "_C13_MEMWINRdsL@20" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub C13_MEMWINRdsW Lib "C13W32.DLL" Alias "_C13_MEMWINRdsW@20" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_MEMWINRdW Lib "C13W32.DLL" Alias "_C13_MEMWINRdW@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_MEMWINWrB Lib "C13W32.DLL" Alias "_C13_MEMWINWrB@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub C13_MEMWINWrL Lib "C13W32.DLL" Alias "_C13_MEMWINWrL@16" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub C13_MEMWINWrsL Lib "C13W32.DLL" Alias "_C13_MEMWINWrsL@20" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub C13_MEMWINWrsW Lib "C13W32.DLL" Alias "_C13_MEMWINWrsW@20" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub C13_MEMWINWrW Lib "C13W32.DLL" Alias "_C13_MEMWINWrW@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_Mod Lib "C13W32.DLL" Alias "_C13_Mod@8" (ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
    Public Declare Function C13_ModeIsBC Lib "C13W32.DLL" Alias "_C13_ModeIsBC@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ModeIsMon Lib "C13W32.DLL" Alias "_C13_ModeIsMon@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ModeIsNotBC Lib "C13W32.DLL" Alias "_C13_ModeIsNotBC@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ModeIsNotMon Lib "C13W32.DLL" Alias "_C13_ModeIsNotMon@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ModeIsNotPlay Lib "C13W32.DLL" Alias "_C13_ModeIsNotPlay@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ModeIsNotRT Lib "C13W32.DLL" Alias "_C13_ModeIsNotRT@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ModeIsNotSerial Lib "C13W32.DLL" Alias "_C13_ModeIsNotSerial@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ModeIsPlay Lib "C13W32.DLL" Alias "_C13_ModeIsPlay@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ModeIsRT Lib "C13W32.DLL" Alias "_C13_ModeIsRT@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ModeIsSerial Lib "C13W32.DLL" Alias "_C13_ModeIsSerial@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_ModeRd Lib "C13W32.DLL" Alias "_C13_ModeRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_ModeWr Lib "C13W32.DLL" Alias "_C13_ModeWr@8" (ByVal mode As UInt16, ByVal handleval As UInt32)
    Public Declare Function C13_MonClear Lib "C13W32.DLL" Alias "_C13_MonClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonConfigEx Lib "C13W32.DLL" Alias "_C13_MonConfigEx@16" (ByVal configval As UInt32, ByVal moncount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonConfigExx Lib "C13W32.DLL" Alias "_C13_MonConfigExx@20" (ByVal configval As UInt32, ByVal seqaddr As UInt32, ByVal moncount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonFilterSAEx Lib "C13W32.DLL" Alias "_C13_MonFilterSAEx@24" (ByVal taval As Int32, ByVal rcvsamask As UInt32, ByVal xmtsamask As UInt32, ByVal rcvmcmask As UInt32, ByVal xmtmcmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonRdEx Lib "C13W32.DLL" Alias "_C13_MonRdEx@12" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_MonResume Lib "C13W32.DLL" Alias "_C13_MonResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonStart Lib "C13W32.DLL" Alias "_C13_MonStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonStatus Lib "C13W32.DLL" Alias "_C13_MonStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MonStop Lib "C13W32.DLL" Alias "_C13_MonStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MsgBlockRd Lib "C13W32.DLL" Alias "_C13_MsgBlockRd@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_MsgBlockWr Lib "C13W32.DLL" Alias "_C13_MsgBlockWr@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_MsgCheck Lib "C13W32.DLL" Alias "_C13_MsgCheck@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_MsgCommRd Lib "C13W32.DLL" Alias "_C13_MsgCommRd@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_MsgCommWr Lib "C13W32.DLL" Alias "_C13_MsgCommWr@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_MsgConfig Lib "C13W32.DLL" Alias "_C13_MsgConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_MsgConfigEx Lib "C13W32.DLL" Alias "_C13_MsgConfigEx@12" (ByVal configval As UInt32, ByVal cwd As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_MsgCWD1Rd Lib "C13W32.DLL" Alias "_C13_MsgCWD1Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_MsgCWD1Wr Lib "C13W32.DLL" Alias "_C13_MsgCWD1Wr@12" (ByVal cwd1 As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function C13_MsgCWD2Rd Lib "C13W32.DLL" Alias "_C13_MsgCWD2Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_MsgCWD2Wr Lib "C13W32.DLL" Alias "_C13_MsgCWD2Wr@12" (ByVal cwd2 As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function C13_MsgErrorRd Lib "C13W32.DLL" Alias "_C13_MsgErrorRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_MsgErrorWr Lib "C13W32.DLL" Alias "_C13_MsgErrorWr@12" (ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function C13_MsgFlagRd Lib "C13W32.DLL" Alias "_C13_MsgFlagRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_MsgFlagWr Lib "C13W32.DLL" Alias "_C13_MsgFlagWr@12" (ByVal msgflag As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function C13_MsgIsAccessed Lib "C13W32.DLL" Alias "_C13_MsgIsAccessed@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_MsgOptRd Lib "C13W32.DLL" Alias "_C13_MsgOptRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_MsgOptWr Lib "C13W32.DLL" Alias "_C13_MsgOptWr@12" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function C13_MsgReset Lib "C13W32.DLL" Alias "_C13_MsgReset@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_MsgSWD1Rd Lib "C13W32.DLL" Alias "_C13_MsgSWD1Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_MsgSWD2Rd Lib "C13W32.DLL" Alias "_C13_MsgSWD2Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_Mul Lib "C13W32.DLL" Alias "_C13_Mul@8" (ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
    Public Declare Function C13_PlayClear Lib "C13W32.DLL" Alias "_C13_PlayClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_PlayConfigEx Lib "C13W32.DLL" Alias "_C13_PlayConfigEx@20" (ByVal configval As UInt32, ByVal playcount As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_PlayConfigExx Lib "C13W32.DLL" Alias "_C13_PlayConfigExx@28" (ByVal configval As UInt32, ByVal playaddr As UInt32, ByVal playcount As UInt32, ByVal seqaddr As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_PlayStatus Lib "C13W32.DLL" Alias "_C13_PlayStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_PlayWrEx Lib "C13W32.DLL" Alias "_C13_PlayWrEx@12" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_PortRd Lib "C13W32.DLL" Alias "_C13_PortRd@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As Byte
    Public Declare Sub C13_PortWr Lib "C13W32.DLL" Alias "_C13_PortWr@12" (ByVal value As Byte, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function C13_ProgRdW Lib "C13W32.DLL" Alias "_C13_ProgRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_ProgWrW Lib "C13W32.DLL" Alias "_C13_ProgWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C13_RAMFill Lib "C13W32.DLL" Alias "_C13_RAMFill@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
    Public Declare Function C13_RAMRdB Lib "C13W32.DLL" Alias "_C13_RAMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_RAMRdL Lib "C13W32.DLL" Alias "_C13_RAMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub C13_RAMRdsW Lib "C13W32.DLL" Alias "_C13_RAMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
    Public Declare Function C13_RAMRdW Lib "C13W32.DLL" Alias "_C13_RAMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C13_RAMWipe Lib "C13W32.DLL" Alias "_C13_RAMWipe@4" (ByVal handleval As UInt32)
    Public Declare Sub C13_RAMWipeEx Lib "C13W32.DLL" Alias "_C13_RAMWipeEx@8" (ByVal value As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C13_RAMWrB Lib "C13W32.DLL" Alias "_C13_RAMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub C13_RAMWrL Lib "C13W32.DLL" Alias "_C13_RAMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub C13_RAMWrsW Lib "C13W32.DLL" Alias "_C13_RAMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub C13_RAMWrW Lib "C13W32.DLL" Alias "_C13_RAMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function C13_RTConfigEx Lib "C13W32.DLL" Alias "_C13_RTConfigEx@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_RTConfigExx Lib "C13W32.DLL" Alias "_C13_RTConfigExx@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_RTCreateListEx Lib "C13W32.DLL" Alias "_C13_RTCreateListEx@36" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_RTCreateListExx Lib "C13W32.DLL" Alias "_C13_RTCreateListExx@36" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_RTReset Lib "C13W32.DLL" Alias "_C13_RTReset@8" (ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_RTStatus Lib "C13W32.DLL" Alias "_C13_RTStatus@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_RTSWDRd Lib "C13W32.DLL" Alias "_C13_RTSWDRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_SchedBuild Lib "C13W32.DLL" Alias "_C13_SchedBuild@16" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef freq As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_SchedBuildEx Lib "C13W32.DLL" Alias "_C13_SchedBuildEx@28" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef freq As Int32, ByRef period As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_SchedBuildExx Lib "C13W32.DLL" Alias "_C13_SchedBuildExx@28" (ByVal frametime As UInt32, ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef period As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_SchedCalc Lib "C13W32.DLL" Alias "_C13_SchedCalc@8" (ByRef msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Sub C13_SchedDisplay Lib "C13W32.DLL" Alias "_C13_SchedDisplay@8" (ByVal nummsgs As UInt32, ByRef count As UInt32)
    Public Declare Sub C13_SchedHook Lib "C13W32.DLL" Alias "_C13_SchedHook@8" (ByVal index As Int32, ByVal ptr As IntPtr)
    Public Declare Function C13_SchedInsEnd Lib "C13W32.DLL" Alias "_C13_SchedInsEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_SchedInsMsg Lib "C13W32.DLL" Alias "_C13_SchedInsMsg@12" (ByVal index As UInt32, ByRef msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_SchedInsStart Lib "C13W32.DLL" Alias "_C13_SchedInsStart@12" (ByVal frametime As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_SchedMaxval Lib "C13W32.DLL" Alias "_C13_SchedMaxval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
    Public Declare Function C13_SchedMinval Lib "C13W32.DLL" Alias "_C13_SchedMinval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
    Public Declare Sub C13_SchedPrint Lib "C13W32.DLL" Alias "" (ByVal ParamArray list() As String)
    Public Declare Sub C13_SchedPrint Lib "C13W32.DLL" Alias "" (ByVal ParamArray list() As String)
    Public Declare Function C13_SerialClear Lib "C13W32.DLL" Alias "_C13_SerialClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_SerialConfig Lib "C13W32.DLL" Alias "_C13_SerialConfig@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_SerialConfigEx Lib "C13W32.DLL" Alias "_C13_SerialConfigEx@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_SerialStatus Lib "C13W32.DLL" Alias "_C13_SerialStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C13_SerialWr Lib "C13W32.DLL" Alias "_C13_SerialWr@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_Shl Lib "C13W32.DLL" Alias "_C13_Shl@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function C13_Shr Lib "C13W32.DLL" Alias "_C13_Shr@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Sub C13_TimerClear Lib "C13W32.DLL" Alias "_C13_TimerClear@4" (ByVal handleval As UInt32)
    Public Declare Function C13_TimerRd Lib "C13W32.DLL" Alias "_C13_TimerRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function C13_TimerResolution Lib "C13W32.DLL" Alias "_C13_TimerResolution@8" (ByVal timerresol As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C13_TimerResolutionEx Lib "C13W32.DLL" Alias "_C13_TimerResolutionEx@8" (ByVal timershift As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C13_ValFromAscii Lib "C13W32.DLL" Alias "_C13_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
    Public Declare Function C13_ValGetBits Lib "C13W32.DLL" Alias "_C13_ValGetBits@12" (ByVal oldvalue As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function C13_ValPackRTCWD Lib "C13W32.DLL" Alias "_C13_ValPackRTCWD@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal count As Int32) As UInt16
    Public Declare Function C13_ValPutBits Lib "C13W32.DLL" Alias "_C13_ValPutBits@16" (ByVal oldvalue As UInt16, ByVal newfld As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function C13_ValToAscii Lib "C13W32.DLL" Alias "_C13_ValToAscii@16" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
    Public Declare Sub C13_ValUnpackRTCWD Lib "C13W32.DLL" Alias "_C13_ValUnpackRTCWD@28" (ByVal cwd As UInt16, ByRef bcastflag As Int32, ByRef mcflag As Int32, ByRef taval As Int32, ByRef trflag As Int32, ByRef saval As Int32, ByRef count As Int32)
    Public Declare Function C13_WatchConfig Lib "C13W32.DLL" Alias "_C13_WatchConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Sub C13_WatchWr Lib "C13W32.DLL" Alias "_C13_WatchWr@8" (ByVal secs As UInt32, ByVal handleval As UInt32)
    Public Declare Sub C13_WatchWrEx Lib "C13W32.DLL" Alias "_C13_WatchWrEx@8" (ByVal value As UInt32, ByVal handleval As UInt32)

    '/**
    '*
    '*  Bus controller configuration options
    '*
    '**/

    Public Const BCCFG_DEFAULT As UInt32 = &H0L  '//Select all default settings
    Public Const BCCFG_ENABLE As UInt32 = &H0L   '//Enable bus controller (default)
    Public Const BCCFG_DISABLE As UInt32 = &H1L  '//Disable bus controller
    Public Const BCCFG_TRIGNONE As UInt32 = &H0L '//No trigger (default)
    Public Const BCCFG_TRIGEXT As UInt32 = &H10L  '//Trigger external
    Public Const BCCFG_TRIGSTART As UInt32 = &H20L    '//Trigger external start
    Public Const BCCFG_NOINTHALT As UInt32 = &H0L    '//Do not generate interrupt on halt (default)
    Public Const BCCFG_INTHALT As UInt32 = &H100L  '//Generate interrupt on halt
    Public Const BCCFG_NOINTPAUSE As UInt32 = &H0L   '//Do not generate interrupt on pause (default)
    Public Const BCCFG_INTPAUSE As UInt32 = &H200L '//Generate interrupt on pause
    Public Const BCCFG_NOLOOPMAX As UInt32 = &H0L    '//Disable maximum loop count (default)
    Public Const BCCFG_LOOPMAX As UInt32 = &H1000L  '//Enable maximum loop count
    Public Const BCCFG_NOSTEP As UInt32 = &H0L   '//Disable single stepping (default)
    Public Const BCCFG_STEP As UInt32 = &H2000L '//Enable single stepping
    Public Const BCCFG_MC01 As UInt32 = &H0L '//Select SA=00000 or SA=11111 for mode codes (default)
    Public Const BCCFG_MC1 As UInt32 = &H1000000L  '//Select SA=11111 for mode codes
    Public Const BCCFG_MC0 As UInt32 = &H2000000L  '//Select SA=00000 for mode codes
    Public Const BCCFG_MCNONE As UInt32 = &H3000000L   '//Disable mode codes
    Public Const BCCFG_SYNCALL As UInt32 = &H0L  '//Sync on all messages (default)
    Public Const BCCFG_SYNCSEL As UInt32 = &H40000000L  '//Selective sync
    Public Const BCCFG_MODEL As UInt32 = &H0L    '//BC messages are created in static RAM (default)
    Public Const BCCFG_RAM As UInt32 = &H100000L  '//BC messages are created in static RAM
    Public Const BCCFG_DPRAM As UInt32 = &H200000L    '//BC messages are created in dual-port RAM

    '/**
    '*
    '*  Monitor configuration options
    '*
    '**/

    Public Const MONCFG_DEFAULT As UInt32 = &H0L '//Select all default settings
    Public Const MONCFG_FILLHALT As UInt32 = &H0L    '//Enable monitor in fill and halt mode (default)
    Public Const MONCFG_DISABLE As UInt32 = &H1L '//Disable monitor
    Public Const MONCFG_CONTINUOUS As UInt32 = &H2L  '//Enable monitor in continuous mode
    Public Const MONCFG_DMA As UInt32 = &H4L '//Enable monitor in dma mode
    Public Const MONCFG_FREE As UInt32 = &H8L    '//Enable monitor in free mode
    Public Const MONCFG_FAST As UInt32 = &H10L    '//Enable monitor in fast mode
    Public Const MONCFG_NOINTFULL As UInt32 = &H0L   '//Do not generate interrupt when monitor full (default)
    Public Const MONCFG_INTFULL As UInt32 = &H1000L '//Generate interrupt when monitor full
    Public Const MONCFG_COMPLETE As UInt32 = &H0L    '//Enable receiving complete words (default)
    Public Const MONCFG_INCOMPLETE As UInt32 = &H2000L  '//Enable receiving incomplete words
    Public Const MONCFG_MC01 As UInt32 = &H0L    '//Select SA=00000 or SA=11111 for mode codes (default)
    Public Const MONCFG_MC1 As UInt32 = &H100000L '//Select SA=11111 for mode codes
    Public Const MONCFG_MC0 As UInt32 = &H200000L '//Select SA=00000 for mode codes
    Public Const MONCFG_MCNONE As UInt32 = &H300000L  '//Disable mode codes
    Public Const MONCFG_16K As UInt32 = &H0L '//Allocate a 16K monitor buffer (default)
    Public Const MONCFG_ALLAVAIL As UInt32 = &H1000000L    '//Allocate all available memory to monitor buffer
    Public Const MONCFG_32K As UInt32 = &H2000000L '//Allocate a 32K monitor buffer
    Public Const MONCFG_64K As UInt32 = &H4000000L '//Allocate a 64K monitor buffer
    Public Const MONCFG_128K As UInt32 = &H8000000L    '//Allocate a 128K monitor buffer
    Public Const MONCFG_DPRAM As UInt32 = &H10000000L   '//Allocate all available dual-port memory

    '/**
    '*
    '*  Remote terminal configuration options
    '*
    '**/

    Public Const RTCFG_DEFAULT As UInt32 = &H0L  '//Select all default settings
    Public Const RTCFG_SIMULATE As UInt32 = &H0L '//Enable RT simulation (default)
    Public Const RTCFG_DISABLE As UInt32 = &H1L  '//Disable RT
    Public Const RTCFG_MONITOR As UInt32 = &H2L  '//Enable RT monitor
    Public Const RTCFG_NOBCAST As UInt32 = &H0L  '//Disable broadcast (default)
    Public Const RTCFG_BCAST As UInt32 = &H100L    '//Enable broadcast
    Public Const RTCFG_NOAUTOBUSY As UInt32 = &H0L   '//Disable auto busy (default)
    Public Const RTCFG_AUTOBUSY As UInt32 = &H200L '//Enable auto busy
    Public Const RTCFG_BUILD As UInt32 = &H0L    '//Enable auto building (default)
    Public Const RTCFG_NOBUILD As UInt32 = &H400L  '//Disable auto building
    Public Const RTCFG_STDB As UInt32 = &H0L '//Use MIL-STD-1553B standard (default)
    Public Const RTCFG_STDA As UInt32 = &H400000L '//Use MIL-STD-1553A standard
    Public Const RTCFG_NODYNBC As UInt32 = &H0L  '//Do not respond to dynamic BC mode code (default)
    Public Const RTCFG_DYNBC As UInt32 = &H1000L    '//Respond to dynamic BC mode code
    Public Const RTCFG_NOIMMCLR As UInt32 = &H0L '//Do not clear status word bits (default)
    Public Const RTCFG_IMMCLR As UInt32 = &H2000L   '//Status word bits are cleared immediately
    Public Const RTCFG_NOBCASTADDR As UInt32 = &H0L  '//Disable broadcast handling for address (default)
    Public Const RTCFG_BCASTADDR As UInt32 = &H4000L    '//Enable broadcast handling for address
    Public Const RTCFG_CHANAB As UInt32 = &H0L   '//Respond to both channels (default)
    Public Const RTCFG_CHANA As UInt32 = &H20000L    '//Respond to channel A
    Public Const RTCFG_CHANB As UInt32 = &H10000L    '//Respond to channel B
    Public Const RTCFG_CHANNONE As UInt32 = &H30000L '//Respond to neither channel A nor B
    Public Const RTCFG_MC01 As UInt32 = &H0L '//Select SA=00000 or SA=11111 for mode codes (default)
    Public Const RTCFG_MC1 As UInt32 = &H1000000L  '//Select SA=11111 for mode codes
    Public Const RTCFG_MC0 As UInt32 = &H2000000L  '//Select SA=00000 for mode codes
    Public Const RTCFG_MCNONE As UInt32 = &H3000000L   '//Disable mode codes
    Public Const RTCFG_SYNCALL As UInt32 = &H0L  '//Sync on all messages (default)
    Public Const RTCFG_SYNCSEL As UInt32 = &H40000000L  '//Selective sync
    Public Const RTCFG_WIPE As UInt32 = &H0L '//Enables message clear (default)
    Public Const RTCFG_NOWIPE As UInt32 = &H80000000L   '//Disables message clear
    Public Const RTCFG_WIPE0 As UInt32 = &H0L    '//Initialize data with zeros (default)
    Public Const RTCFG_WIPE123 As UInt32 = &H4000000L  '//Initialize data with incrementing values
    Public Const RTCFG_WIPECWD As UInt32 = &H8000000L  '//Initialize data with command word
    Public Const RTCFG_MODEL As UInt32 = &H0L    '//RT messages are created in static RAM (default)
    Public Const RTCFG_RAM As UInt32 = &H100000L  '//RT messages are created in static RAM
    Public Const RTCFG_DPRAM As UInt32 = &H200000L    '//RT messages are created in dual-port RAM
    Public Const RTCFG_RESPONSEB As UInt32 = &H0L    '//RT responds using MIL-STD-1553B response time (default)
    Public Const RTCFG_RESPONSEA As UInt32 = &H400000L    '//RT responds using MIL-STD-1553A response time

    '/**
    '*
    '*  Serial configuration options
    '*
    '**/

    Public Const SERCFG_DEFAULT As UInt32 = &H0L '//Select all default settings
    Public Const SERCFG_CONTINUOUS As UInt32 = &H0L  '//Enable continuous mode (default)
    Public Const SERCFG_DISABLE As UInt32 = &H1L '//Disable free mode
    Public Const SERCFG_FREE As UInt32 = &H2L    '//Enable free mode
    Public Const SERCFG_NOINTEMPTY As UInt32 = &H0L  '//Do not generate interrupt when empty (default)
    Public Const SERCFG_INTEMPTY As UInt32 = &H10L    '//Generate interrupt when empty

    '/**
    '*
    '*  Watchdog configuration options
    '*
    '**/

    Public Const WATCHCFG_DEFAULT As UInt32 = &H0L   '//Select all default settings
    Public Const WATCHCFG_ENABLE As UInt32 = &H0L    '//Enable watchdog timer (default)
    Public Const WATCHCFG_DISABLE As UInt32 = &H1L   '//Disable watchdog timer

    '/**
    '*
    '*  Playback configuration options
    '*
    '**/

    Public Const PLAYCFG_DEFAULT As UInt32 = &H0L    '//Select all default settings
    Public Const PLAYCFG_ENABLE As UInt32 = &H0L '//Enable playback (default)
    Public Const PLAYCFG_DISABLE As UInt32 = &H1L    '//Disable playback
    Public Const PLAYCFG_16K As UInt32 = &H0L    '//Allocate a 16K playback buffer (default)
    Public Const PLAYCFG_ALLAVAIL As UInt32 = &H8000L   '//Allocate all available memory to playback buffer
    Public Const PLAYCFG_32K As UInt32 = &H10000L    '//Allocate a 32K playback buffer
    Public Const PLAYCFG_64K As UInt32 = &H20000L    '//Allocate a 64K playback buffer
    Public Const PLAYCFG_128K As UInt32 = &H40000L   '//Allocate a 128K playback buffer
    Public Const PLAYCFG_DPRAM As UInt32 = &H80000L  '//Allocate all available dual-port memory

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

    Public Const INFOTYPE_PLAT As UInt16 = &H1   '//Returns the C13 platform type
    Public Const INFOTYPE_PROD As UInt16 = &H2   '//Returns the C13 product type
    Public Const INFOTYPE_DASH As UInt16 = &H3   '//Returns the C13 dash number
    Public Const INFOTYPE_VERSION As UInt16 = &H4    '//Returns the C13 version number
    Public Const INFOTYPE_DATE As UInt16 = &H5   '//Returns the C13 version date
    Public Const INFOTYPE_MODEL As UInt16 = &H6  '//Returns the C13 model number
    Public Const INFOTYPE_MAXCOUNT As UInt16 = &H7   '//Returns the number of terminals the C13 can simulate
    Public Const INFOTYPE_MULTIMODE As UInt16 = &H8  '//Returns whether C13 can simulate multi-modes
    Public Const INFOTYPE_ERRORGEN As UInt16 = &H9   '//Returns whether C13 can generate errors
    Public Const INFOTYPE_CONCURMON As UInt16 = &HA  '//Returns whether C13 has a concurrent monitor
    Public Const INFOTYPE_MONFILTER As UInt16 = &HB  '//Returns whether C13 has a monitor filter
    Public Const INFOTYPE_USERCODE As UInt16 = &HC   '//Returns whether C13 handles user code
    Public Const INFOTYPE_LISTBUF As UInt16 = &HD    '//Returns whether C13 handles list buffering
    Public Const INFOTYPE_MONFAST As UInt16 = &HE    '//Returns whether C13 has a fast monitor
    Public Const INFOTYPE_MONDMA As UInt16 = &HF '//Returns whether C13 has a dma monitor
    Public Const INFOTYPE_MONBRAKE As UInt16 = &H10   '//Returns whether C13 has a monitor brake
    Public Const INFOTYPE_PLAY As UInt16 = &H11   '//Returns whether C13 has playback capability
    Public Const INFOTYPE_WATCH As UInt16 = &H12  '//Returns whether C13 has a watchdog
    Public Const INFOTYPE_RESPONSEA As UInt16 = &H13  '//Returns whether C13 can do MIL-STD-1553A response time

    '/**
    '*
    '*  Error configuration options
    '*
    '**/

    Public Const ERRDEF_NONE As UInt32 = &H0L    '//Disable error generation (default)
    Public Const ERRDEF_GAP As UInt32 = &H10000L '//Generate zero crossing error
    Public Const ERRDEF_CNTWRDABS As UInt32 = &H20000L   '//Generate an absolute word count error
    Public Const ERRDEF_CNTWRDREL As UInt32 = &H40000L   '//Generate a relative count error
    Public Const ERRDEF_CNTBIT As UInt32 = &H80000L  '//Generate a bit count error
    Public Const ERRDEF_MAN1 As UInt32 = &H100000L    '//Generate manchester error on first half of bit
    Public Const ERRDEF_MAN2 As UInt32 = &H200000L    '//Generate manchester error on second half of bit
    Public Const ERRDEF_SYNC As UInt32 = &H400000L    '//Generate a sync error
    Public Const ERRDEF_PAR As UInt32 = &H800000L '//Generate a parity error
    Public Const ERRDEF_ZEROX As UInt32 = &H1000000L   '//Generate zero crossing error

    Public Const ERRDEF_DWD00 As UInt16 = &H0    '//Error will be generated in a data word  0
    Public Const ERRDEF_DWD01 As UInt16 = &H1    '//Error will be generated in a data word  1
    Public Const ERRDEF_DWD02 As UInt16 = &H2    '//Error will be generated in a data word  2
    Public Const ERRDEF_DWD03 As UInt16 = &H3    '//Error will be generated in a data word  3
    Public Const ERRDEF_DWD04 As UInt16 = &H4    '//Error will be generated in a data word  4
    Public Const ERRDEF_DWD05 As UInt16 = &H5    '//Error will be generated in a data word  5
    Public Const ERRDEF_DWD06 As UInt16 = &H6    '//Error will be generated in a data word  6
    Public Const ERRDEF_DWD07 As UInt16 = &H7    '//Error will be generated in a data word  7
    Public Const ERRDEF_DWD08 As UInt16 = &H8    '//Error will be generated in a data word  8
    Public Const ERRDEF_DWD09 As UInt16 = &H9    '//Error will be generated in a data word  9
    Public Const ERRDEF_DWD10 As UInt16 = &HA    '//Error will be generated in a data word 10
    Public Const ERRDEF_DWD11 As UInt16 = &HB    '//Error will be generated in a data word 11
    Public Const ERRDEF_DWD12 As UInt16 = &HC    '//Error will be generated in a data word 12
    Public Const ERRDEF_DWD13 As UInt16 = &HD    '//Error will be generated in a data word 13
    Public Const ERRDEF_DWD14 As UInt16 = &HE    '//Error will be generated in a data word 14
    Public Const ERRDEF_DWD15 As UInt16 = &HF    '//Error will be generated in a data word 15
    Public Const ERRDEF_DWD16 As UInt16 = &H10    '//Error will be generated in a data word 16
    Public Const ERRDEF_DWD17 As UInt16 = &H11    '//Error will be generated in a data word 17
    Public Const ERRDEF_DWD18 As UInt16 = &H12    '//Error will be generated in a data word 18
    Public Const ERRDEF_DWD19 As UInt16 = &H13    '//Error will be generated in a data word 19
    Public Const ERRDEF_DWD20 As UInt16 = &H14    '//Error will be generated in a data word 20
    Public Const ERRDEF_DWD21 As UInt16 = &H15    '//Error will be generated in a data word 21
    Public Const ERRDEF_DWD22 As UInt16 = &H16    '//Error will be generated in a data word 22
    Public Const ERRDEF_DWD23 As UInt16 = &H17    '//Error will be generated in a data word 23
    Public Const ERRDEF_DWD24 As UInt16 = &H18    '//Error will be generated in a data word 24
    Public Const ERRDEF_DWD25 As UInt16 = &H19    '//Error will be generated in a data word 25
    Public Const ERRDEF_DWD26 As UInt16 = &H1A    '//Error will be generated in a data word 26
    Public Const ERRDEF_DWD27 As UInt16 = &H1B    '//Error will be generated in a data word 27
    Public Const ERRDEF_DWD28 As UInt16 = &H1C    '//Error will be generated in a data word 28
    Public Const ERRDEF_DWD29 As UInt16 = &H1D    '//Error will be generated in a data word 29
    Public Const ERRDEF_DWD30 As UInt16 = &H1E    '//Error will be generated in a data word 30
    Public Const ERRDEF_DWD31 As UInt16 = &H1F    '//Error will be generated in a data word 31
    Public Const ERRDEF_CWD1 As UInt16 = &H100 '//Error will be generated in CWD1
    Public Const ERRDEF_CWD2 As UInt16 = &H101 '//Error will be generated in CWD2
    Public Const ERRDEF_SWD As UInt16 = &H102  '//Error will be generated in SWD1
    Public Const ERRDEF_SWD1 As UInt16 = &H102 '//Error will be generated in SWD1
    Public Const ERRDEF_SWD2 As UInt16 = &H102 '//Error will be generated in SWD2

    '/**
    '*
    '*  Error control options
    '*
    '**/

    Public Const ERRCTRL_OFF As UInt32 = &H0L    '//Disable error generation
    Public Const ERRCTRL_ON As UInt32 = &H1L '//Enable error generation
    Public Const ERRCTRL_ONCE As UInt32 = &H2L   '//Enable error generation once
    Public Const ERRCTRL_EXTERNAL As UInt32 = &H3L   '//Enable externally triggered error generation
    Public Const ERRCTRL_TAGMSG As UInt32 = &H0L '//Generate errors on tagged messages
    Public Const ERRCTRL_ANYMSG As UInt32 = &H80000000L '//Generate errors on any message

    '/**
    '*
    '*  Message configuration options
    '*
    '**/

    Public Const MSGCRT_DEFAULT As UInt32 = &H0L '//Default settings
    Public Const MSGCRT_ENABLE As UInt32 = &H0L  '//Enable subaddress (RT) (default)
    Public Const MSGCRT_DISABLE As UInt32 = &H1000L '//Disable subaddress (RT)
    Public Const MSGCRT_RESP As UInt32 = &H0L    '//Enable response (RT) (default)
    Public Const MSGCRT_NORESP As UInt32 = &H2000L  '//Disable response (RT)
    Public Const MSGCRT_NOWRAP As UInt32 = &H0L  '//Disable data wrap (RT) (default)
    Public Const MSGCRT_WRAP As UInt32 = &H4000L    '//Enable data wrap (RT)
    Public Const MSGCRT_NOINT As UInt32 = &H0L   '//Message will generate interrupt (default)
    Public Const MSGCRT_INT As UInt32 = &H1L '//Message will not generate interrupt
    Public Const MSGCRT_NOERR As UInt32 = &H0L   '//No message error will be generated for message (default)
    Public Const MSGCRT_ERR As UInt32 = &H2L '//A message error will be generated for message
    Public Const MSGCRT_BUSA As UInt32 = &H0L    '//Message will be transmitted on bus A (BC) (default)
    Public Const MSGCRT_BUSB As UInt32 = &H4L    '//Message will be transmitted on bus B (BC)
    Public Const MSGCRT_BCRT As UInt32 = &H0L    '//Message is a BC-RT transfer (BC) (default)
    Public Const MSGCRT_RTRT As UInt32 = &H8L    '//Message is an RT-RT transfer (BC)
    Public Const MSGCRT_NOMON As UInt32 = &H0L   '//Message will not be monitored (default)
    Public Const MSGCRT_MON As UInt32 = &H10L '//Message will be monitored
    Public Const MSGCRT_NOTIMETAG As UInt32 = &H0L   '//Message will not record time-tag (default)
    Public Const MSGCRT_TIMETAG As UInt32 = &H40L '//Message will record time-tag
    Public Const MSGCRT_NOELAPSE As UInt32 = &H0L    '//Message will not record elapse time (default)
    Public Const MSGCRT_ELAPSE As UInt32 = &H80L  '//Message will record elapse time
    Public Const MSGCRT_NOMIN As UInt32 = &H0L   '//Message will not record min time (default)
    Public Const MSGCRT_MIN As UInt32 = &H100L '//Message will record min time
    Public Const MSGCRT_NOMAX As UInt32 = &H0L   '//Message will not record max time (default)
    Public Const MSGCRT_MAX As UInt32 = &H200L '//Message will record max time
    Public Const MSGCRT_NOHIT As UInt32 = &H0L   '//Message will not record hit count (default)
    Public Const MSGCRT_HIT As UInt32 = &H400L '//Message will record hit count
    Public Const MSGCRT_NOSYNC As UInt32 = &H0L  '//No sync will be generated for message (default)
    Public Const MSGCRT_SYNC As UInt32 = &H40000000L    '//Sync will be generated for message
    Public Const MSGCRT_WIPE As UInt32 = &H0L    '//Enables message clear (default)
    Public Const MSGCRT_NOWIPE As UInt32 = &H80000000L  '//Disables message clear
    Public Const MSGCRT_WIPE0 As UInt32 = &H0L   '//Initialize data with zeros (default)
    Public Const MSGCRT_WIPE123 As UInt32 = &H1000000L '//Initialize data with incrementing values
    Public Const MSGCRT_WIPECWD As UInt32 = &H2000000L '//Initialize data with command word
    Public Const MSGCRT_MODEL As UInt32 = &H0L   '//Message located in static RAM (default)
    Public Const MSGCRT_RAM As UInt32 = &H100000L '//Message located in static RAM
    Public Const MSGCRT_DPRAM As UInt32 = &H200000L   '//Message located in dual-port RAM

    '/**
    '*
    '*  List buffer options
    '*
    '**/

    Public Const LISTCRT_DEFAULT As UInt32 = &H0L    '//Select all default settings
    Public Const LISTCRT_PINGPONG As UInt32 = &H0L   '//Enable ping-pong mode (default)
    Public Const LISTCRT_FIFO As UInt32 = &H1L   '//Enable FIFO mode
    Public Const LISTCRT_CIRCULAR As UInt32 = &H2L   '//Enable circular mode
    Public Const LISTCRT_TRBIT As UInt32 = &H0L  '//User will read or write depending upon T/R bit
    Public Const LISTCRT_READ As UInt32 = &H10L   '//User will read from list buffer
    Public Const LISTCRT_WRITE As UInt32 = &H20L  '//User will write to list buffer
    Public Const LISTCRT_NOTSKIP As UInt32 = &H0L    '//Will not skip messages
    Public Const LISTCRT_SKIP As UInt32 = &H40L   '//Enable message skipping
    Public Const LISTCRT_NOINT As UInt32 = &H0L  '//Do not generate interrupt when list buffer empty/full (default)
    Public Const LISTCRT_INT As UInt32 = &H100L    '//Generate interrupt when list buffer empty/full
    Public Const LISTCRT_NOHIT As UInt32 = &H0L  '//Do not generate interrupt when list is hit (default)
    Public Const LISTCRT_HIT As UInt32 = &H200L    '//Generate interrupt when list is hit
    Public Const LISTCRT_MODEL As UInt32 = &H0L  '//List located in static RAM (default)
    Public Const LISTCRT_RAM As UInt32 = &H100000L    '//List located in static RAM
    Public Const LISTCRT_DPRAM As UInt32 = &H200000L  '//List located in dual-port RAM

    '/**
    '*
    '*  Bit fields of the message error flag
    '*
    '**/

    Public Const MSGERR_NORESP As UInt16 = &H8000   '//Set when we timeout waiting for response
    Public Const MSGERR_ANYERR As UInt16 = &H4000   '//Set when any error bit is set
    Public Const MSGERR_PROTOCOL As UInt16 = &H2000 '//General protocol error
    Public Const MSGERR_SYNC As UInt16 = &H1000 '//Set when we have the wrong sync
    Public Const MSGERR_DATACOUNT As UInt16 = &H800    '//Set when improper number of data words
    Public Const MSGERR_MANCH As UInt16 = &H20    '//Set when manchester error detected
    Public Const MSGERR_PARITY As UInt16 = &H10   '//Set when parity error detected
    Public Const MSGERR_WORD As UInt16 = &H8 '//Set when word error detected
    Public Const MSGERR_RETRY As UInt16 = &H4    '//All retries failed
    Public Const MSGERR_SYSTEM As UInt16 = &H2   '//An internal system error occurred
    Public Const MSGERR_HIT As UInt16 = &H1  '//Always set

    '/**
    '*
    '*  Bit fields of the message activity flag.
    '*
    '**/

    Public Const MSGACT_XMTCWD1 As UInt16 = &H8000  '//Transmitted CWD1
    Public Const MSGACT_XMTCWD2 As UInt16 = &H4000  '//Transmitted CWD2
    Public Const MSGACT_XMTSWD1 As UInt16 = &H2000  '//Transmitted SWD1
    Public Const MSGACT_XMTSWD2 As UInt16 = &H1000  '//Transmitted SWD2
    Public Const MSGACT_RCVCWD1 As UInt16 = &H800  '//Received CWD1
    Public Const MSGACT_RCVCWD2 As UInt16 = &H400  '//Received CWD2
    Public Const MSGACT_RCVSWD1 As UInt16 = &H200  '//Received SWD1
    Public Const MSGACT_RCVSWD2 As UInt16 = &H100  '//Received SWD2
    Public Const MSGACT_XMTDWD As UInt16 = &H80   '//Transmitted DWD
    Public Const MSGACT_RCVDWD As UInt16 = &H40   '//Received DWD

    '/**
    '*
    '*  Condition flags.
    '*
    '**/

    Public Const COND_FAIL As UInt16 = &H1   '//Condition when all retries have failed
    Public Const COND_SRQ As UInt16 = &H2    '//Condition on Service Request bit set in status word
    Public Const COND_INS As UInt16 = &H4    '//Condition on Instrumentation bit set in status word
    Public Const COND_SSF As UInt16 = &H8    '//Condition on Subsystem Fail bit set in status word
    Public Const COND_TF As UInt16 = &H10 '//Condition on Terminal Flag bit set in status word
    Public Const COND_BUSY As UInt16 = &H20   '//Condition on Busy bit set in status word
    Public Const COND_ME As UInt16 = &H40 '//Condition on Message Error bit set in status word
    Public Const COND_RESPERR As UInt16 = &H80    '//Condition on response error
    Public Const COND_NORESP As UInt16 = &H100 '//Condition on response error
    Public Const COND_ALTBUS As UInt16 = &H200 '//Retries are performed on alternate bus

    '/**
    '*
    '*  Field types.
    '*
    '**/

    Public Const FIELD_CWD1 As Int16 = 0    '//CWD1 field
    Public Const FIELD_CWD2 As Int16 = 1    '//CWD2 field
    Public Const FIELD_SWD1 As Int16 = 2    '//SWD1 field
    Public Const FIELD_SWD2 As Int16 = 3    '//SWD2 field
    Public Const FIELD_TTAG As Int16 = 4    '//Time tag field
    Public Const FIELD_ELAPSE As Int16 = 5  '//Elapse time field
    Public Const FIELD_ERROR As Int16 = 6   '//Error field
    Public Const FIELD_ACT As Int16 = 7 '//Activity field
    Public Const FIELD_RESP1 As Int16 = 8   '//Response time 1 field
    Public Const FIELD_RESP2 As Int16 = 9   '//Response time 2 field
    Public Const FIELD_COUNT As Int16 = 10  '//Data count field
    Public Const FIELD_FLAG1 As Int16 = 11  '//Flag 1 field
    Public Const FIELD_FLAG2 As Int16 = 12  '//Flag 2 field
    Public Const FIELD_RESV As Int16 = 13   '//Reserved field

    '/**
    '*
    '*  Interrupt types.
    '*
    '**/

    Public Const INTTYPE_MSG As UInt16 = &H1 '//Message interrupt
    Public Const INTTYPE_OPCODE As UInt16 = &H2  '//Interrupt opcode
    Public Const INTTYPE_HALT As UInt16 = &H3    '//Schedule halt
    Public Const INTTYPE_PAUSE As UInt16 = &H4   '//Schedule pause
    Public Const INTTYPE_SEQ As UInt16 = &H5 '//Sequential record full
    Public Const INTTYPE_LIST As UInt16 = &H6    '//List buffer empty/full
    Public Const INTTYPE_PARITY As UInt16 = &H7  '//Parity error
    Public Const INTTYPE_DIN As UInt16 = &H8 '//DIN
    Public Const INTTYPE_SERIAL As UInt16 = &H9  '//Serial empty

    '/**
    '*
    '*  Timer resolutions.
    '*
    '**/

    Public Const TIMERRESOL_1US As Int16 = 1    '//1us timer resolution, 1:11:34
    Public Const TIMERRESOL_16US As Int16 = 2   '//16us timer resolution, 19:05:19 range
    Public Const TIMERRESOL_1024US As Int16 = 3 '//1024us timer resolution, 50 day range

    '/**
    '*
    '*  C13 HOST Registers
    '*
    '**/

    Public Const HREG_STAT As UInt16 = &H0   '//Status register (RD)
    Public Const HREG_SET As UInt16 = &H1    '//Set register (WR)
    Public Const HREG_CLR As UInt16 = &H2    '//Clear register (WR)
    Public Const HREG_DCFG As UInt16 = &H3   '//DSP configuration register (RD/WR)
    Public Const HREG_HCFG As UInt16 = &H4   '//HOST configuration register (RD/WR)
    Public Const HREG_RESV As UInt16 = &H5   '//Reserved register
    Public Const HREG_PAGE As UInt16 = &H6   '//Page register (RD/WR)
    Public Const HREG_ERR As UInt16 = &H7    '//Error register (RD)
    Public Const HREG_HPCL As UInt16 = &H8   '//Host port control low (RD/WR)
    Public Const HREG_HPCH As UInt16 = &H9   '//Host port control high (RD/WR)
    Public Const HREG_HPIL As UInt16 = &HA   '//Host port incrementer low (RD/WR)
    Public Const HREG_HPIH As UInt16 = &HB   '//Host port incrementer high (RD/WR)
    Public Const HREG_HPAL As UInt16 = &HC   '//Host port address low (RD/WR)
    Public Const HREG_HPAH As UInt16 = &HD   '//Host port address high (RD/WR)
    Public Const HREG_HPDL As UInt16 = &HE   '//Host port data low (RD/WR)
    Public Const HREG_HPDH As UInt16 = &HF   '//Host port data high (RD/WR)

    '/**
    '*
    '*  C13 IFGA Registers
    '*
    '**/

    Public Const IREG_STAT As UInt16 = &H20   '//Status register
    Public Const IREG_SET As UInt16 = &H21    '//Set register
    Public Const IREG_CLR As UInt16 = &H22    '//Clear register
    Public Const IREG_RESV As UInt16 = &H23   '//Reserved register
    Public Const IREG_PAGE As UInt16 = &H24   '//Page register
    Public Const IREG_IOCFG As UInt16 = &H25  '//I/O configuration register
    Public Const IREG_DMA As UInt16 = &H26    '//DMA register

    '/**
    '*
    '*  C13 EDGA Registers
    '*
    '**/

    Public Const EREG_STAT As UInt16 = &H0   '//Status register (RD)
    Public Const EREG_STATCLR As UInt16 = &H1    '//Status clear register (WR)
    Public Const EREG_STATDEC As UInt16 = &H2    '//Decoder status register (RD)
    Public Const EREG_VALA As UInt16 = &H4   '//Decoder word value A register
    Public Const EREG_VALAL As UInt16 = &H4  '//Decoder low word value A register
    Public Const EREG_VALAH As UInt16 = &H5  '//Decoder high word value A register
    Public Const EREG_VALB As UInt16 = &H6   '//Decoder word value B register
    Public Const EREG_VALBL As UInt16 = &H6  '//Decoder low word value B register
    Public Const EREG_VALBH As UInt16 = &H7  '//Decoder high word value B register
    Public Const EREG_GAPE As UInt16 = &H8   '//Encoder gap register
    Public Const EREG_CTRLE As UInt16 = &H9  '//Encoder control register
    Public Const EREG_VALE As UInt16 = &HA   '//Encoder value register
    Public Const EREG_VALEL As UInt16 = &HA  '//Encoder low value register
    Public Const EREG_VALEH As UInt16 = &HB  '//Encoder high value register
    Public Const EREG_ERRE As UInt16 = &HC   '//Encoder error register
    Public Const EREG_FT As UInt16 = &HE '//Frame time register
    Public Const EREG_RST As UInt16 = &HF    '//Reset register
    Public Const EREG_GAPA As UInt16 = &H10   '//Decoder gap time A register
    Public Const EREG_GAPB As UInt16 = &H11   '//Decoder gap time B register
    Public Const EREG_GAPTO As UInt16 = &H12  '//Decoder gap timeout register
    Public Const EREG_CFGD As UInt16 = &H14   '//Decoder configuration register
    Public Const EREG_CFGE As UInt16 = &H15   '//Encoder configuration register
    Public Const EREG_CFGINT As UInt16 = &H16 '//Interrupt configuration register
    Public Const EREG_ID As UInt16 = &H17 '//Identification register

    '/**
    '*
    '*  C13 Global Registers
    '*
    '**/

    Public Const GREG_IMR As UInt16 = &H0    '//Interrupt mask register
    Public Const GREG_IFR As UInt16 = &H1    '//Interrupt flag register
    Public Const GREG_ST0 As UInt16 = &H6    '//Status register 0
    Public Const GREG_ST1 As UInt16 = &H7    '//Status register 1
    Public Const GREG_AL As UInt16 = &H8 '//Accumulator A low word (bits 15-00)
    Public Const GREG_AH As UInt16 = &H9 '//Accumulator A high word (bits 31-16)
    Public Const GREG_AG As UInt16 = &HA '//Accumulator A guars bits (bits 39-32)
    Public Const GREG_BL As UInt16 = &HB '//Accumulator B low word (bits 15-00)
    Public Const GREG_BH As UInt16 = &HC '//Accumulator B high word (bits 31-16)
    Public Const GREG_BG As UInt16 = &HD '//Accumulator B guard bits (bits 39-32
    Public Const GREG_T As UInt16 = &HE  '//Temporary register
    Public Const GREG_TRN As UInt16 = &HF    '//Transition register
    Public Const GREG_AR0 As UInt16 = &H10    '//Auxilliary register 0
    Public Const GREG_AR1 As UInt16 = &H11    '//Auxilliary register 1
    Public Const GREG_AR2 As UInt16 = &H12    '//Auxilliary register 2
    Public Const GREG_AR3 As UInt16 = &H13    '//Auxilliary register 3
    Public Const GREG_AR4 As UInt16 = &H14    '//Auxilliary register 4
    Public Const GREG_AR5 As UInt16 = &H15    '//Auxilliary register 5
    Public Const GREG_AR6 As UInt16 = &H16    '//Auxilliary register 6
    Public Const GREG_AR7 As UInt16 = &H17    '//Auxilliary register 7
    Public Const GREG_SP As UInt16 = &H18 '//Stack pointer
    Public Const GREG_BK As UInt16 = &H19 '//Circular-buffer size register
    Public Const GREG_BRC As UInt16 = &H1A    '//Block-repeat counter
    Public Const GREG_RSA As UInt16 = &H1B    '//Block-repeat start address
    Public Const GREG_REA As UInt16 = &H1C    '//Block-repeat end address
    Public Const GREG_PMST As UInt16 = &H1D   '//Processor mode status register
    Public Const GREG_XPC As UInt16 = &H1E    '//Program counter extension register
    Public Const GREG_BDRR0 As UInt16 = &H20  '//Buffered serial port 0 data receive register
    Public Const GREG_BDXR0 As UInt16 = &H21  '//Buffered serial port 0 data transmit register
    Public Const GREG_BSPC0 As UInt16 = &H22  '//Buffered serial port 0 control register
    Public Const GREG_BSPEC0 As UInt16 = &H23 '//Buffered serial port 0 control extension register
    Public Const GREG_TIM As UInt16 = &H24    '//Timer count register
    Public Const GREG_PRD As UInt16 = &H25    '//Timer period register
    Public Const GREG_TCR As UInt16 = &H26    '//Timer control register
    Public Const GREG_SWWSR As UInt16 = &H28  '//External interface software wait-state register
    Public Const GREG_BSCR As UInt16 = &H29   '//External interface bank-switching control register
    Public Const GREG_XSWR As UInt16 = &H2B   '//Extended software wait-state register
    Public Const GREG_HPIC As UInt16 = &H2C   '//Host port interface control register
    Public Const GREG_TRCV As UInt16 = &H30   '//TDM serial port data receive register
    Public Const GREG_TDXR As UInt16 = &H31   '//TDM serial port data transmit register
    Public Const GREG_TSPC As UInt16 = &H32   '//TDM serial port control register
    Public Const GREG_TCSR As UInt16 = &H33   '//TDM serial port channel select register
    Public Const GREG_TRTA As UInt16 = &H34   '//TDM serial port receive transmit register
    Public Const GREG_TRAD As UInt16 = &H35   '//TDM serial port receive address register
    Public Const GREG_AXR0 As UInt16 = &H38   '//ABU 0 transmit address register
    Public Const GREG_BKX0 As UInt16 = &H39   '//ABU 0 transmit buffer-size register
    Public Const GREG_ARR0 As UInt16 = &H3A   '//ABU 0 receive address register
    Public Const GREG_BKR0 As UInt16 = &H3B   '//ABU 0 receive buffer-size register
    Public Const GREG_AXR1 As UInt16 = &H3C   '//ABU 1 transmit address register
    Public Const GREG_BKX1 As UInt16 = &H3D   '//ABU 1 transmit buffer-size register
    Public Const GREG_ARR1 As UInt16 = &H3E   '//ABU 1 receive address register
    Public Const GREG_BKR1 As UInt16 = &H3F   '//ABU 1 receive buffer-size register
    Public Const GREG_BDRR1 As UInt16 = &H40  '//Buffered serial port 1 data receive register
    Public Const GREG_BDXR1 As UInt16 = &H41  '//Buffered serial port 1 data transmit register
    Public Const GREG_BSPC1 As UInt16 = &H42  '//Buffered serial port 1 control register
    Public Const GREG_BSPCE1 As UInt16 = &H43 '//Buffered serial port 1 extension register
    Public Const GREG_CLKMD As UInt16 = &H58  '//Clock-mode register

    Public Const MONRD_MAX_COUNT As Int16 = 64

    Public Const SUBADDRESS As Int16 = 0
    Public Const MODECODE As Int16 = 1

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
    Public Const ERR_NOCS As Int16 = -3 '//Card Services is not present
    Public Const ERR_NOSOCKET As Int16 = -4 '//The specified socket is not present
    Public Const ERR_CS As Int16 = -5   '//A bad version was encountered
    Public Const ERR_NOTSR As Int16 = -6    '//Unable to find the CM1553-3 memory resident driver
    Public Const ERR_CLIENT As Int16 = -7   '//Unable to install a local client driver
    Public Const ERR_WIN As Int16 = -8  '//Card Services could not configure the memory window, I/O window, or IRQ steering
    Public Const ERR_BADPARAMS As Int16 = -11   '//CardOpen() called with bad parameters
    Public Const ERR_NOHANDLES As Int16 = -12   '//CardOpen() already has allocated too many handles
    Public Const ERR_NOCARD As Int16 = -13  '//CardOpen() could not find a C13 card at the specified address
    Public Const ERR_NOIO As Int16 = -14    '//CardOpen() could not find the I/O ports
    Public Const ERR_NOMEM As Int16 = -15   '//CardOpen() could not find the memory
    Public Const ERR_BAD16BIT As Int16 = -16    '//Card is conflicting with another 16-bit card
    Public Const ERR_WRONGMODEL As Int16 = -17  '//Card does not support this feature
    Public Const ERR_NOSEL As Int16 = -18   '//CardOpen() could not allocate a memory selector
    Public Const ERR_LOCK As Int16 = -19    '//The communication process is locked up
    Public Const ERR_TOOMANY As Int16 = -20 '//Too many terminals have been configured
    Public Const ERR_BADHANDLE As Int16 = -21   '//A bad handle was specified
    Public Const ERR_BADTA As Int16 = -22   '//A bad terminal address was specified
    Public Const ERR_BADFRAME As Int16 = -23    '//A bad frame time was specified
    Public Const ERR_NOTBC As Int16 = -24   '//The BC has not been configured
    Public Const ERR_NOTRT As Int16 = -25   '//The RT has not been configured
    Public Const ERR_NOTMON As Int16 = -26  '//The monitor has not been configured
    Public Const ERR_ALLOC As Int16 = -27   '//There is not enough memory to allocate
    Public Const ERR_VXD As Int16 = -28 '//An error occurred in the VXD
    Public Const ERR_BADMSG As Int16 = -31  '//The specified command block is not a message block
    Public Const ERR_BADSCHNDX As Int16 = -32   '//Specified command index is out of range
    Public Const ERR_BUFSIZE As Int16 = -33 '//Insufficient space in user buffer
    Public Const ERR_NOCONFIG As Int16 = -34    '//The card has not been properly configured
    Public Const ERR_BOOTFULL As Int16 = -41    '//No space to add boot code
    Public Const ERR_BOOTNUM As Int16 = -42 '//There is no boot code with the specified number
    Public Const ERR_ROMVERIFY As Int16 = -44   '//Unable to verify the value written to the ROM
    Public Const ERR_COUNT As Int16 = -45   '//An invalid count was specified
    Public Const ERR_CRC As Int16 = -46 '//There was a bad checksum in the HEX file
    Public Const ERR_FNAME As Int16 = -47   '//Bad filenames were specified
    Public Const ERR_FRDWR As Int16 = -48   '//There was an error reading or writing the HEX file
    Public Const ERR_HEX As Int16 = -49 '//There was a bad hex character in the HEX file
    Public Const ERR_INDEX As Int16 = -51   '//The command block index was invalid or the schedule is full
    Public Const ERR_NOMSGS As Int16 = -52  '//No messages specified
    Public Const ERR_RESPONSE As Int16 = -53    '//A bad response or no response was received from an RT
    Public Const ERR_TYPE As Int16 = -54    '//There was a bad type value in the HEX file
    Public Const ERR_ZEROLEN As Int16 = -55 '//Zero length was specified
    Public Const ERR_DMABAD As Int16 = -61  '//Bad DMA channel was specified
    Public Const ERR_DMAODD As Int16 = -62  '//An odd DMA address or count was specified
    Public Const ERR_DMAPAGE As Int16 = -63 '//DMA buffer specified crosses a page boundary
    Public Const ERR_SELFIOFAIL As Int16 = -71  '//I/O selftest failed
    Public Const ERR_SELFMEMFAIL As Int16 = -72 '//Memory selftest failed
    Public Const ERR_SELFCOMMFAIL As Int16 = -73    '//Communication selftest failed
    Public Const ERR_SELFXMTFAIL As Int16 = -74 '//Transmit selftest failed
    Public Const ERR_CISVERIFY As Int16 = -90   '//Unable to verify the value written to the CIS
    Public Const ERR_CISNONE As Int16 = -91 '//The CIS is not visible

End Module
