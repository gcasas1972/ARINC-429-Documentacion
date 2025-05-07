Imports System
Imports System.Runtime.InteropServices

Module L13W32VB

    '/**
    '*
    '*  LP1553-3 and LC1553-3 WIN32 DRIVER  Version 2.2.1  (02/01/2008)
    '*  Copyright (c) 1997-2008
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   L13W32NET.VB -- 32-bit
    '*                      L13 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  Structs used by the L13 Driver.
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
    '*  L13 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the L13 Driver.
    '*
    '**/

    Public Declare Function L13_BCConfig Lib "L13W32.DLL" Alias "_L13_BCConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCCreateList Lib "L13W32.DLL" Alias "_L13_BCCreateList@28" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_BCCreateMsg Lib "L13W32.DLL" Alias "_L13_BCCreateMsg@20" (ByVal configval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_BCSchedFrame Lib "L13W32.DLL" Alias "_L13_BCSchedFrame@8" (ByVal timeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedMsg Lib "L13W32.DLL" Alias "_L13_BCSchedMsg@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedRetry Lib "L13W32.DLL" Alias "_L13_BCSchedRetry@12" (ByVal condition As UInt16, ByVal retries As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCTransmitMsg Lib "L13W32.DLL" Alias "_L13_BCTransmitMsg@8" (ByRef xmitfieldsval As XMITFIELDS, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCTransmitMsgEx Lib "L13W32.DLL" Alias "_L13_BCTransmitMsgEx@8" (ByRef xmitfieldsval As XMITFIELDS, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardClose Lib "L13W32.DLL" Alias "_L13_CardClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardOpen Lib "L13W32.DLL" Alias "_L13_CardOpen@4" (ByVal cardnum As Int32) As UInt32
    Public Declare Sub L13_CardReset Lib "L13W32.DLL" Alias "_L13_CardReset@4" (ByVal handleval As UInt32)
    Public Declare Function L13_CardStart Lib "L13W32.DLL" Alias "_L13_CardStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardStop Lib "L13W32.DLL" Alias "_L13_CardStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ErrorCtrl Lib "L13W32.DLL" Alias "_L13_ErrorCtrl@8" (ByVal ctrlval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ErrorDefine Lib "L13W32.DLL" Alias "_L13_ErrorDefine@24" (ByVal defineval As UInt32, ByVal errvalue As UInt16, ByVal countval As Int32, ByVal wordpos As UInt16, ByVal bitpos As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ErrorSent Lib "L13W32.DLL" Alias "_L13_ErrorSent@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ErrorTagBC Lib "L13W32.DLL" Alias "_L13_ErrorTagBC@12" (ByVal tagval As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ErrorTagRT Lib "L13W32.DLL" Alias "_L13_ErrorTagRT@24" (ByVal tagval As Int32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_IntConfig Lib "L13W32.DLL" Alias "_L13_IntConfig@12" (ByVal configval As UInt16, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ListDataRd Lib "L13W32.DLL" Alias "_L13_ListDataRd@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ListDataWr Lib "L13W32.DLL" Alias "_L13_ListDataWr@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonConfig Lib "L13W32.DLL" Alias "_L13_MonConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonFilterSA Lib "L13W32.DLL" Alias "_L13_MonFilterSA@24" (ByVal taval As Int32, ByVal rcvsamask As UInt32, ByVal xmtsamask As UInt32, ByVal rcvmcmask As UInt32, ByVal xmtmcmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonFilterTA Lib "L13W32.DLL" Alias "_L13_MonFilterTA@8" (ByVal tamask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonIsRunning Lib "L13W32.DLL" Alias "_L13_MonIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonRd Lib "L13W32.DLL" Alias "_L13_MonRd@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_MsgDataRd Lib "L13W32.DLL" Alias "_L13_MsgDataRd@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L13_MsgDataWr Lib "L13W32.DLL" Alias "_L13_MsgDataWr@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_MsgFieldRd Lib "L13W32.DLL" Alias "_L13_MsgFieldRd@12" (ByVal fieldtype As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_MsgFieldWr Lib "L13W32.DLL" Alias "_L13_MsgFieldWr@16" (ByVal fieldval As UInt32, ByVal fieldtype As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_PlayConfig Lib "L13W32.DLL" Alias "_L13_PlayConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_PlayWr Lib "L13W32.DLL" Alias "_L13_PlayWr@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_RTConfig Lib "L13W32.DLL" Alias "_L13_RTConfig@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_RTCreateList Lib "L13W32.DLL" Alias "_L13_RTCreateList@32" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_RTCreateMsg Lib "L13W32.DLL" Alias "_L13_RTCreateMsg@24" (ByVal configval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_RTGetMsg Lib "L13W32.DLL" Alias "_L13_RTGetMsg@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_RTSWDWr Lib "L13W32.DLL" Alias "_L13_RTSWDWr@12" (ByVal swdval As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ValPackCWD Lib "L13W32.DLL" Alias "_L13_ValPackCWD@16" (ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal wcval As Int32) As UInt16
    Public Declare Sub L13_ValUnpackCWD Lib "L13W32.DLL" Alias "_L13_ValUnpackCWD@20" (ByVal cwdval As UInt16, ByRef taval As Int32, ByRef trflag As Int32, ByRef saval As Int32, ByRef wcval As Int32)
    Public Declare Function L13_AddrDSP Lib "L13W32.DLL" Alias "_L13_AddrDSP@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function L13_AddrHost Lib "L13W32.DLL" Alias "_L13_AddrHost@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function L13_BCConfigEx Lib "L13W32.DLL" Alias "_L13_BCConfigEx@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCConfigMsg Lib "L13W32.DLL" Alias "_L13_BCConfigMsg@12" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_BCCreateListEx Lib "L13W32.DLL" Alias "_L13_BCCreateListEx@32" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_BCCreateListExx Lib "L13W32.DLL" Alias "_L13_BCCreateListExx@32" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_BCGetMsg Lib "L13W32.DLL" Alias "_L13_BCGetMsg@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_BCSchedAgain Lib "L13W32.DLL" Alias "_L13_BCSchedAgain@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedBranch Lib "L13W32.DLL" Alias "_L13_BCSchedBranch@12" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedBranchDin0 Lib "L13W32.DLL" Alias "_L13_BCSchedBranchDin0@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedBranchDin1 Lib "L13W32.DLL" Alias "_L13_BCSchedBranchDin1@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedBranchEx Lib "L13W32.DLL" Alias "_L13_BCSchedBranchEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedBuild Lib "L13W32.DLL" Alias "_L13_BCSchedBuild@16" (ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef freq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedCall Lib "L13W32.DLL" Alias "_L13_BCSchedCall@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedCallCond Lib "L13W32.DLL" Alias "_L13_BCSchedCallCond@12" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedCallCondEx Lib "L13W32.DLL" Alias "_L13_BCSchedCallCondEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedEntry Lib "L13W32.DLL" Alias "_L13_BCSchedEntry@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedFrameEnd Lib "L13W32.DLL" Alias "_L13_BCSchedFrameEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedFrameStart Lib "L13W32.DLL" Alias "_L13_BCSchedFrameStart@8" (ByVal timeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedGap Lib "L13W32.DLL" Alias "_L13_BCSchedGap@8" (ByVal gapval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedGoto Lib "L13W32.DLL" Alias "_L13_BCSchedGoto@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedHalt Lib "L13W32.DLL" Alias "_L13_BCSchedHalt@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedInt Lib "L13W32.DLL" Alias "_L13_BCSchedInt@8" (ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedIntCond Lib "L13W32.DLL" Alias "_L13_BCSchedIntCond@12" (ByVal condition As UInt16, ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedIntCondEx Lib "L13W32.DLL" Alias "_L13_BCSchedIntCondEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedNop Lib "L13W32.DLL" Alias "_L13_BCSchedNop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedPause Lib "L13W32.DLL" Alias "_L13_BCSchedPause@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedPulse Lib "L13W32.DLL" Alias "_L13_BCSchedPulse@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedPulse0 Lib "L13W32.DLL" Alias "_L13_BCSchedPulse0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedPulse1 Lib "L13W32.DLL" Alias "_L13_BCSchedPulse1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedRestart Lib "L13W32.DLL" Alias "_L13_BCSchedRestart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedRetryEx Lib "L13W32.DLL" Alias "_L13_BCSchedRetryEx@24" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal retryflag As UInt16, ByVal retries As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedReturn Lib "L13W32.DLL" Alias "_L13_BCSchedReturn@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSchedUser Lib "L13W32.DLL" Alias "_L13_BCSchedUser@8" (ByVal useraddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSetEntry Lib "L13W32.DLL" Alias "_L13_BCSetEntry@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BCSetTimeout Lib "L13W32.DLL" Alias "_L13_BCSetTimeout@8" (ByVal timeoutval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BlkAddr Lib "L13W32.DLL" Alias "_L13_BlkAddr@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_BlkOptRd Lib "L13W32.DLL" Alias "_L13_BlkOptRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_BlkOptWr Lib "L13W32.DLL" Alias "_L13_BlkOptWr@12" (ByVal rtopt As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BlkPtrRd Lib "L13W32.DLL" Alias "_L13_BlkPtrRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L13_BlkPtrWr Lib "L13W32.DLL" Alias "_L13_BlkPtrWr@12" (ByVal descaddr As UInt32, ByVal taval As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_BlkRd Lib "L13W32.DLL" Alias "_L13_BlkRd@12" (ByRef block As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BlkReset Lib "L13W32.DLL" Alias "_L13_BlkReset@8" (ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BlkSWDRd Lib "L13W32.DLL" Alias "_L13_BlkSWDRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_BlkSWDWr Lib "L13W32.DLL" Alias "_L13_BlkSWDWr@12" (ByVal swdval As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BlkWipe Lib "L13W32.DLL" Alias "_L13_BlkWipe@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_BlkWr Lib "L13W32.DLL" Alias "_L13_BlkWr@12" (ByRef block As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardBoot Lib "L13W32.DLL" Alias "_L13_CardBoot@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardCloseAll Lib "L13W32.DLL" Alias "_L13_CardCloseAll@0" () As Int32
    Public Declare Function L13_CardConfig Lib "L13W32.DLL" Alias "_L13_CardConfig@16" (ByVal enableflag As Int32, ByVal command As UInt16, ByVal taval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardGetInfo Lib "L13W32.DLL" Alias "_L13_CardGetInfo@8" (ByVal infotype As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_CardGetInfoEx Lib "L13W32.DLL" Alias "_L13_CardGetInfoEx@20" (ByRef bufmodel As UInt16, ByVal bufmodelcount As UInt16, ByRef buffeature As UInt16, ByVal buffeaturecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_CardInit Lib "L13W32.DLL" Alias "_L13_CardInit@0" ()
    Public Declare Function L13_CardIsRunning Lib "L13W32.DLL" Alias "_L13_CardIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardNop Lib "L13W32.DLL" Alias "_L13_CardNop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardNopEx Lib "L13W32.DLL" Alias "_L13_CardNopEx@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardOpenEx Lib "L13W32.DLL" Alias "_L13_CardOpenEx@8" (ByRef cardname As String, ByVal cardnum As Int32) As UInt32
    Public Declare Function L13_CardOpenExx Lib "L13W32.DLL" Alias "_L13_CardOpenExx@16" (ByRef cardname As String, ByVal cardnum As Int32, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Sub L13_CardResetEx Lib "L13W32.DLL" Alias "_L13_CardResetEx@4" (ByVal handleval As UInt32)
    Public Declare Function L13_CardResume Lib "L13W32.DLL" Alias "_L13_CardResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardTest Lib "L13W32.DLL" Alias "_L13_CardTest@8" (ByVal level As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardTest0 Lib "L13W32.DLL" Alias "_L13_CardTest0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardTest1 Lib "L13W32.DLL" Alias "_L13_CardTest1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardTest2 Lib "L13W32.DLL" Alias "_L13_CardTest2@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CardTest3 Lib "L13W32.DLL" Alias "_L13_CardTest3@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_CardTrigger Lib "L13W32.DLL" Alias "_L13_CardTrigger@4" (ByVal handleval As UInt32)
    Public Declare Function L13_CFGRdL Lib "L13W32.DLL" Alias "_L13_CFGRdL@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L13_CFGWrL Lib "L13W32.DLL" Alias "_L13_CFGWrL@12" (ByVal value As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_CmdAddr Lib "L13W32.DLL" Alias "_L13_CmdAddr@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_CmdAlloc Lib "L13W32.DLL" Alias "_L13_CmdAlloc@8" (ByVal count As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_CmdAllocEx Lib "L13W32.DLL" Alias "_L13_CmdAllocEx@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_CmdBaseRd Lib "L13W32.DLL" Alias "_L13_CmdBaseRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Sub L13_CmdBaseWr Lib "L13W32.DLL" Alias "_L13_CmdBaseWr@8" (ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_CmdClear Lib "L13W32.DLL" Alias "_L13_CmdClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CmdCountRd Lib "L13W32.DLL" Alias "_L13_CmdCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_CmdCountWr Lib "L13W32.DLL" Alias "_L13_CmdCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L13_CmdCtrlRd Lib "L13W32.DLL" Alias "_L13_CmdCtrlRd@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_CmdCtrlWr Lib "L13W32.DLL" Alias "_L13_CmdCtrlWr@12" (ByVal ctrlval As UInt16, ByVal index As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_CmdCurrRd Lib "L13W32.DLL" Alias "_L13_CmdCurrRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_CmdCurrWr Lib "L13W32.DLL" Alias "_L13_CmdCurrWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L13_CmdInit Lib "L13W32.DLL" Alias "_L13_CmdInit@8" (ByVal opcode As UInt16, ByRef block As UInt16)
    Public Declare Function L13_CmdInsert Lib "L13W32.DLL" Alias "_L13_CmdInsert@8" (ByRef block As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CmdMaxRd Lib "L13W32.DLL" Alias "_L13_CmdMaxRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_CmdMaxWr Lib "L13W32.DLL" Alias "_L13_CmdMaxWr@8" (ByVal count As UInt16, ByVal handleval As UInt32)
    Public Declare Function L13_CmdRd Lib "L13W32.DLL" Alias "_L13_CmdRd@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CmdShotWr Lib "L13W32.DLL" Alias "_L13_CmdShotWr@12" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CmdSkipWr Lib "L13W32.DLL" Alias "_L13_CmdSkipWr@12" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_CmdStackClr Lib "L13W32.DLL" Alias "_L13_CmdStackClr@4" (ByVal handleval As UInt32)
    Public Declare Function L13_CmdStartRd Lib "L13W32.DLL" Alias "_L13_CmdStartRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_CmdStartWr Lib "L13W32.DLL" Alias "_L13_CmdStartWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L13_CmdTotalRd Lib "L13W32.DLL" Alias "_L13_CmdTotalRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_CmdTotalWr Lib "L13W32.DLL" Alias "_L13_CmdTotalWr@8" (ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_CmdWr Lib "L13W32.DLL" Alias "_L13_CmdWr@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CommCall Lib "L13W32.DLL" Alias "_L13_CommCall@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CommCheck Lib "L13W32.DLL" Alias "_L13_CommCheck@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CommDisable Lib "L13W32.DLL" Alias "_L13_CommDisable@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CommDisableEx Lib "L13W32.DLL" Alias "_L13_CommDisableEx@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CommEnable Lib "L13W32.DLL" Alias "_L13_CommEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CommRdL Lib "L13W32.DLL" Alias "_L13_CommRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_CommRdsW Lib "L13W32.DLL" Alias "_L13_CommRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_CommRdW Lib "L13W32.DLL" Alias "_L13_CommRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_CommRun Lib "L13W32.DLL" Alias "_L13_CommRun@20" (ByRef dataptr As UInt16, ByVal datacount As UInt16, ByRef codeptr As UInt16, ByVal codecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_CommWrL Lib "L13W32.DLL" Alias "_L13_CommWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_CommWrsW Lib "L13W32.DLL" Alias "_L13_CommWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_CommWrW Lib "L13W32.DLL" Alias "_L13_CommWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L13_DARClr Lib "L13W32.DLL" Alias "_L13_DARClr@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L13_DARGet Lib "L13W32.DLL" Alias "_L13_DARGet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DARRdL Lib "L13W32.DLL" Alias "_L13_DARRdL@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_DARRdW Lib "L13W32.DLL" Alias "_L13_DARRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_DARSet Lib "L13W32.DLL" Alias "_L13_DARSet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L13_DARWrL Lib "L13W32.DLL" Alias "_L13_DARWrL@12" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L13_DARWrW Lib "L13W32.DLL" Alias "_L13_DARWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L13_DescAddr Lib "L13W32.DLL" Alias "_L13_DescAddr@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_DescAlloc Lib "L13W32.DLL" Alias "_L13_DescAlloc@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_DescConfig Lib "L13W32.DLL" Alias "_L13_DescConfig@24" (ByVal configval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DescOptRd Lib "L13W32.DLL" Alias "_L13_DescOptRd@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_DescOptWr Lib "L13W32.DLL" Alias "_L13_DescOptWr@24" (ByVal descopt As UInt16, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_DescPtrRd Lib "L13W32.DLL" Alias "_L13_DescPtrRd@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_DescPtrWr Lib "L13W32.DLL" Alias "_L13_DescPtrWr@24" (ByVal msgaddr As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_DescRd Lib "L13W32.DLL" Alias "_L13_DescRd@24" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByRef desc As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_DescWr Lib "L13W32.DLL" Alias "_L13_DescWr@24" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByRef desc As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_Div Lib "L13W32.DLL" Alias "_L13_Div@8" (ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
    Public Declare Function L13_DllUsageCount Lib "L13W32.DLL" Alias "_L13_DllUsageCount@0" () As Int32
    Public Declare Function L13_DPMMRdW Lib "L13W32.DLL" Alias "_L13_DPMMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_DPMMWrW Lib "L13W32.DLL" Alias "_L13_DPMMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_DPMRdB Lib "L13W32.DLL" Alias "_L13_DPMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_DPMRdL Lib "L13W32.DLL" Alias "_L13_DPMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L13_DPMRdsL Lib "L13W32.DLL" Alias "_L13_DPMRdsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_DPMRdsW Lib "L13W32.DLL" Alias "_L13_DPMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_DPMRdW Lib "L13W32.DLL" Alias "_L13_DPMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_DPMWrB Lib "L13W32.DLL" Alias "_L13_DPMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L13_DPMWrL Lib "L13W32.DLL" Alias "_L13_DPMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L13_DPMWrsL Lib "L13W32.DLL" Alias "_L13_DPMWrsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_DPMWrsW Lib "L13W32.DLL" Alias "_L13_DPMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_DPMWrW Lib "L13W32.DLL" Alias "_L13_DPMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_DspBioClear Lib "L13W32.DLL" Alias "_L13_DspBioClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DspBioRd Lib "L13W32.DLL" Alias "_L13_DspBioRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_DspBioSet Lib "L13W32.DLL" Alias "_L13_DspBioSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DspHmClear Lib "L13W32.DLL" Alias "_L13_DspHmClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DspHmSet Lib "L13W32.DLL" Alias "_L13_DspHmSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DspIntfClear Lib "L13W32.DLL" Alias "_L13_DspIntfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DspIntfRead Lib "L13W32.DLL" Alias "_L13_DspIntfRead@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DspIntmClear Lib "L13W32.DLL" Alias "_L13_DspIntmClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DspIntmSet Lib "L13W32.DLL" Alias "_L13_DspIntmSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DspXfClear Lib "L13W32.DLL" Alias "_L13_DspXfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_DspXfSet Lib "L13W32.DLL" Alias "_L13_DspXfSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ErrDesc Lib "L13W32.DLL" Alias "_L13_ErrDesc@4" (ByVal errval As Int32) As UInt32
    Public Declare Function L13_ErrDescStr Lib "L13W32.DLL" Alias "_L13_ErrDescStr@4" (ByVal errval As Int32) As UInt32
    Public Declare Function L13_ErrName Lib "L13W32.DLL" Alias "_L13_ErrName@4" (ByVal errval As Int32) As UInt32
    Public Declare Function L13_ErrorIsTaggedBC Lib "L13W32.DLL" Alias "_L13_ErrorIsTaggedBC@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ErrorIsTaggedRT Lib "L13W32.DLL" Alias "_L13_ErrorIsTaggedRT@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ErrorResponse Lib "L13W32.DLL" Alias "_L13_ErrorResponse@8" (ByVal responseval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_ErrorSync Lib "L13W32.DLL" Alias "_L13_ErrorSync@8" (ByVal value As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_ErrorTimeout Lib "L13W32.DLL" Alias "_L13_ErrorTimeout@8" (ByVal timeoutval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_ErrorWatch Lib "L13W32.DLL" Alias "_L13_ErrorWatch@8" (ByVal value As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_ErrorWatchWr Lib "L13W32.DLL" Alias "_L13_ErrorWatchWr@8" (ByVal value As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L13_ErrorWatchWrEx Lib "L13W32.DLL" Alias "_L13_ErrorWatchWrEx@8" (ByVal value As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_ExtDinRd Lib "L13W32.DLL" Alias "_L13_ExtDinRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_ExtDinWr Lib "L13W32.DLL" Alias "_L13_ExtDinWr@8" (ByVal dinval As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_ExtDoutRd Lib "L13W32.DLL" Alias "_L13_ExtDoutRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_ExtDoutWr Lib "L13W32.DLL" Alias "_L13_ExtDoutWr@8" (ByVal doutval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_FileClose Lib "L13W32.DLL" Alias "_L13_FileClose@4" (ByVal handle As IntPtr)
    Public Declare Function L13_FileErr Lib "L13W32.DLL" Alias "_L13_FileErr@0" () As Int32
    Public Declare Sub L13_FileErrClr Lib "L13W32.DLL" Alias "_L13_FileErrClr@0" ()
    Public Declare Sub L13_FileErrSet Lib "L13W32.DLL" Alias "_L13_FileErrSet@0" ()
    Public Declare Function L13_FileOpenRead Lib "L13W32.DLL" Alias "_L13_FileOpenRead@4" (ByRef filename As String) As UInt32
    Public Declare Function L13_FileOpenWrite Lib "L13W32.DLL" Alias "_L13_FileOpenWrite@4" (ByRef filename As String) As UInt32
    Public Declare Function L13_FileRead Lib "L13W32.DLL" Alias "_L13_FileRead@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function L13_FileSeek Lib "L13W32.DLL" Alias "_L13_FileSeek@8" (ByVal handle As IntPtr, ByVal offset As UInt32) As Int32
    Public Declare Function L13_FileTell Lib "L13W32.DLL" Alias "_L13_FileTell@4" (ByVal handle As IntPtr) As UInt32
    Public Declare Function L13_FileWrite Lib "L13W32.DLL" Alias "_L13_FileWrite@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function L13_GetHigh Lib "L13W32.DLL" Alias "_L13_GetHigh@4" (ByVal val As UInt32) As UInt16
    Public Declare Function L13_GetLow Lib "L13W32.DLL" Alias "_L13_GetLow@4" (ByVal val As UInt32) As UInt16
    Public Declare Function L13_GlobalRdW Lib "L13W32.DLL" Alias "_L13_GlobalRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_GlobalWrW Lib "L13W32.DLL" Alias "_L13_GlobalWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L13_HandleClose Lib "L13W32.DLL" Alias "_L13_HandleClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_HandleDel Lib "L13W32.DLL" Alias "_L13_HandleDel@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_HandleGet Lib "L13W32.DLL" Alias "_L13_HandleGet@20" (ByRef cardstr As String, ByRef cardnum As Int32, ByRef devnum As Int32, ByRef sizval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_HandleIns Lib "L13W32.DLL" Alias "_L13_HandleIns@16" (ByRef cardname As String, ByVal cardnum As Int32, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Function L13_HandleOkay Lib "L13W32.DLL" Alias "_L13_HandleOkay@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_HandleOpen Lib "L13W32.DLL" Alias "_L13_HandleOpen@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_HandleOpenWin95 Lib "L13W32.DLL" Alias "_L13_HandleOpenWin95@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_HandleOpenWinNT Lib "L13W32.DLL" Alias "_L13_HandleOpenWinNT@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_HandleVer Lib "L13W32.DLL" Alias "_L13_HandleVer@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_HandleVerPLX Lib "L13W32.DLL" Alias "_L13_HandleVerPLX@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_HeapAlloc Lib "L13W32.DLL" Alias "_L13_HeapAlloc@8" (ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_HeapAllocAll Lib "L13W32.DLL" Alias "_L13_HeapAllocAll@8" (ByRef wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_HeapAllocAllDPM Lib "L13W32.DLL" Alias "_L13_HeapAllocAllDPM@8" (ByRef wordcount As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_HeapAllocDPM Lib "L13W32.DLL" Alias "_L13_HeapAllocDPM@8" (ByVal wordcount As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_HeapAllocEx Lib "L13W32.DLL" Alias "_L13_HeapAllocEx@12" (ByVal configval As UInt16, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_HeapWipe Lib "L13W32.DLL" Alias "_L13_HeapWipe@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_HeapWipeDPM Lib "L13W32.DLL" Alias "_L13_HeapWipeDPM@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_IndirectRd Lib "L13W32.DLL" Alias "_L13_IndirectRd@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_IndirectWr Lib "L13W32.DLL" Alias "_L13_IndirectWr@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_IntClear Lib "L13W32.DLL" Alias "_L13_IntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_IntDisable Lib "L13W32.DLL" Alias "_L13_IntDisable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_IntEnable Lib "L13W32.DLL" Alias "_L13_IntEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_IntEnableCond Lib "L13W32.DLL" Alias "_L13_IntEnableCond@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_IntGet Lib "L13W32.DLL" Alias "_L13_IntGet@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_IntInstall Lib "L13W32.DLL" Alias "_L13_IntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_IntRd Lib "L13W32.DLL" Alias "_L13_IntRd@12" (ByRef typevalval As UInt16, ByRef infoval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L13_IntReset Lib "L13W32.DLL" Alias "_L13_IntReset@4" (ByVal handleval As UInt32)
    Public Declare Function L13_IntStatus Lib "L13W32.DLL" Alias "_L13_IntStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_IntUninstall Lib "L13W32.DLL" Alias "_L13_IntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_IORdW Lib "L13W32.DLL" Alias "_L13_IORdW@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_IOWINRdW Lib "L13W32.DLL" Alias "_L13_IOWINRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_IOWINWrW Lib "L13W32.DLL" Alias "_L13_IOWINWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L13_IOWrW Lib "L13W32.DLL" Alias "_L13_IOWrW@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_KernDev Lib "L13W32.DLL" Alias "_L13_KernDev@8" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernEnd Lib "L13W32.DLL" Alias "_L13_KernEnd@4" (ByVal vxdptr As IntPtr) As Int32
    Public Declare Function L13_KernIntClear Lib "L13W32.DLL" Alias "_L13_KernIntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernIntInstall Lib "L13W32.DLL" Alias "_L13_KernIntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernIntParam Lib "L13W32.DLL" Alias "_L13_KernIntParam@32" (ByVal clraddr As UInt32, ByVal clrwidth As UInt32, ByVal clrvalue As UInt32, ByVal stataddr As UInt32, ByVal statwidth As UInt32, ByVal statvalue As UInt32, ByVal statmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernIntStatus Lib "L13W32.DLL" Alias "_L13_KernIntStatus@8" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernIntUninstall Lib "L13W32.DLL" Alias "_L13_KernIntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernIORdW Lib "L13W32.DLL" Alias "_L13_KernIORdW@12" (ByRef valueptr As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernIOWrW Lib "L13W32.DLL" Alias "_L13_KernIOWrW@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernMEMFillW Lib "L13W32.DLL" Alias "_L13_KernMEMFillW@20" (ByVal value As UInt16, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernMEMRdL Lib "L13W32.DLL" Alias "_L13_KernMEMRdL@16" (ByRef valueptr As UInt32, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernMEMRdsL Lib "L13W32.DLL" Alias "_L13_KernMEMRdsL@20" (ByRef bufptr As UInt32, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernMEMRdsW Lib "L13W32.DLL" Alias "_L13_KernMEMRdsW@20" (ByRef bufptr As UInt16, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernMEMRdW Lib "L13W32.DLL" Alias "_L13_KernMEMRdW@16" (ByRef valueptr As UInt16, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernMEMWrL Lib "L13W32.DLL" Alias "_L13_KernMEMWrL@16" (ByVal value As UInt32, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernMEMWrsL Lib "L13W32.DLL" Alias "_L13_KernMEMWrsL@20" (ByRef bufptr As UInt32, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernMEMWrsW Lib "L13W32.DLL" Alias "_L13_KernMEMWrsW@20" (ByRef bufptr As UInt16, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernMEMWrW Lib "L13W32.DLL" Alias "_L13_KernMEMWrW@16" (ByVal value As UInt16, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernQuick Lib "L13W32.DLL" Alias "_L13_KernQuick@8" (ByVal flag As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernStatus Lib "L13W32.DLL" Alias "_L13_KernStatus@12" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_KernStatusEx Lib "L13W32.DLL" Alias "_L13_KernStatusEx@16" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal index As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ListAddr Lib "L13W32.DLL" Alias "_L13_ListAddr@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_ListAddrEx Lib "L13W32.DLL" Alias "_L13_ListAddrEx@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Function L13_ListBlockRd Lib "L13W32.DLL" Alias "_L13_ListBlockRd@12" (ByRef buf As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_ListBlockRdEx Lib "L13W32.DLL" Alias "_L13_ListBlockRdEx@16" (ByRef buf As UInt16, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_ListBlockWr Lib "L13W32.DLL" Alias "_L13_ListBlockWr@12" (ByRef buf As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_ListBlockWrEx Lib "L13W32.DLL" Alias "_L13_ListBlockWrEx@16" (ByRef buf As UInt16, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_ListClear Lib "L13W32.DLL" Alias "_L13_ListClear@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ListConfig Lib "L13W32.DLL" Alias "_L13_ListConfig@16" (ByVal configval As UInt32, ByVal count As Int32, ByVal skipval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_ListConfigEx Lib "L13W32.DLL" Alias "_L13_ListConfigEx@16" (ByVal configval As UInt32, ByVal count As Int32, ByVal skipval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_ListDataRdEx Lib "L13W32.DLL" Alias "_L13_ListDataRdEx@20" (ByRef buf As UInt16, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ListDataWrEx Lib "L13W32.DLL" Alias "_L13_ListDataWrEx@20" (ByRef buf As UInt16, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ListInit Lib "L13W32.DLL" Alias "_L13_ListInit@12" (ByVal listaddr As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ListNextRd Lib "L13W32.DLL" Alias "_L13_ListNextRd@8" (ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Function L13_ListNextWr Lib "L13W32.DLL" Alias "_L13_ListNextWr@8" (ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Sub L13_ListPostRd Lib "L13W32.DLL" Alias "_L13_ListPostRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L13_ListPostWr Lib "L13W32.DLL" Alias "_L13_ListPostWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L13_ListPreRd Lib "L13W32.DLL" Alias "_L13_ListPreRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L13_ListPreWr Lib "L13W32.DLL" Alias "_L13_ListPreWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Function L13_ListStatus Lib "L13W32.DLL" Alias "_L13_ListStatus@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MakeLong Lib "L13W32.DLL" Alias "_L13_MakeLong@8" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
    Public Declare Function L13_Mask Lib "L13W32.DLL" Alias "_L13_Mask@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Sub L13_MEMWINFillW Lib "L13W32.DLL" Alias "_L13_MEMWINFillW@20" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_MEMWINRdB Lib "L13W32.DLL" Alias "_L13_MEMWINRdB@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_MEMWINRdL Lib "L13W32.DLL" Alias "_L13_MEMWINRdL@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L13_MEMWINRdsL Lib "L13W32.DLL" Alias "_L13_MEMWINRdsL@20" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_MEMWINRdsW Lib "L13W32.DLL" Alias "_L13_MEMWINRdsW@20" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_MEMWINRdW Lib "L13W32.DLL" Alias "_L13_MEMWINRdW@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_MEMWINWrB Lib "L13W32.DLL" Alias "_L13_MEMWINWrB@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_MEMWINWrL Lib "L13W32.DLL" Alias "_L13_MEMWINWrL@16" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_MEMWINWrsL Lib "L13W32.DLL" Alias "_L13_MEMWINWrsL@20" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_MEMWINWrsW Lib "L13W32.DLL" Alias "_L13_MEMWINWrsW@20" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_MEMWINWrW Lib "L13W32.DLL" Alias "_L13_MEMWINWrW@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_Mod Lib "L13W32.DLL" Alias "_L13_Mod@8" (ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
    Public Declare Function L13_ModeIsBC Lib "L13W32.DLL" Alias "_L13_ModeIsBC@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ModeIsMon Lib "L13W32.DLL" Alias "_L13_ModeIsMon@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ModeIsNotBC Lib "L13W32.DLL" Alias "_L13_ModeIsNotBC@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ModeIsNotMon Lib "L13W32.DLL" Alias "_L13_ModeIsNotMon@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ModeIsNotPlay Lib "L13W32.DLL" Alias "_L13_ModeIsNotPlay@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ModeIsNotRT Lib "L13W32.DLL" Alias "_L13_ModeIsNotRT@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ModeIsNotSerial Lib "L13W32.DLL" Alias "_L13_ModeIsNotSerial@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ModeIsPlay Lib "L13W32.DLL" Alias "_L13_ModeIsPlay@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ModeIsRT Lib "L13W32.DLL" Alias "_L13_ModeIsRT@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ModeIsSerial Lib "L13W32.DLL" Alias "_L13_ModeIsSerial@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_ModeRd Lib "L13W32.DLL" Alias "_L13_ModeRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_ModeWr Lib "L13W32.DLL" Alias "_L13_ModeWr@8" (ByVal mode As UInt16, ByVal handleval As UInt32)
    Public Declare Function L13_MonBlkRd Lib "L13W32.DLL" Alias "_L13_MonBlkRd@16" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_MonBlkRdEx Lib "L13W32.DLL" Alias "_L13_MonBlkRdEx@20" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal maxblkcnt As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_MonClear Lib "L13W32.DLL" Alias "_L13_MonClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonConfigEx Lib "L13W32.DLL" Alias "_L13_MonConfigEx@16" (ByVal configval As UInt32, ByVal moncount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonConfigExx Lib "L13W32.DLL" Alias "_L13_MonConfigExx@20" (ByVal configval As UInt32, ByVal seqaddr As UInt32, ByVal moncount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonFilterSAEx Lib "L13W32.DLL" Alias "_L13_MonFilterSAEx@24" (ByVal taval As Int32, ByVal rcvsamask As UInt32, ByVal xmtsamask As UInt32, ByVal rcvmcmask As UInt32, ByVal xmtmcmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonRdEx Lib "L13W32.DLL" Alias "_L13_MonRdEx@12" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_MonResume Lib "L13W32.DLL" Alias "_L13_MonResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonStart Lib "L13W32.DLL" Alias "_L13_MonStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonStatus Lib "L13W32.DLL" Alias "_L13_MonStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MonStop Lib "L13W32.DLL" Alias "_L13_MonStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MsgBlockRd Lib "L13W32.DLL" Alias "_L13_MsgBlockRd@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_MsgBlockWr Lib "L13W32.DLL" Alias "_L13_MsgBlockWr@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_MsgCheck Lib "L13W32.DLL" Alias "_L13_MsgCheck@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_MsgCommRd Lib "L13W32.DLL" Alias "_L13_MsgCommRd@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_MsgCommWr Lib "L13W32.DLL" Alias "_L13_MsgCommWr@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_MsgConfig Lib "L13W32.DLL" Alias "_L13_MsgConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_MsgConfigEx Lib "L13W32.DLL" Alias "_L13_MsgConfigEx@12" (ByVal configval As UInt32, ByVal cwd As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_MsgCWD1Rd Lib "L13W32.DLL" Alias "_L13_MsgCWD1Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_MsgCWD1Wr Lib "L13W32.DLL" Alias "_L13_MsgCWD1Wr@12" (ByVal cwd1 As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_MsgCWD2Rd Lib "L13W32.DLL" Alias "_L13_MsgCWD2Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_MsgCWD2Wr Lib "L13W32.DLL" Alias "_L13_MsgCWD2Wr@12" (ByVal cwd2 As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_MsgErrorRd Lib "L13W32.DLL" Alias "_L13_MsgErrorRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_MsgErrorWr Lib "L13W32.DLL" Alias "_L13_MsgErrorWr@12" (ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_MsgFlagRd Lib "L13W32.DLL" Alias "_L13_MsgFlagRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_MsgFlagWr Lib "L13W32.DLL" Alias "_L13_MsgFlagWr@12" (ByVal msgflag As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_MsgIsAccessed Lib "L13W32.DLL" Alias "_L13_MsgIsAccessed@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_MsgOptRd Lib "L13W32.DLL" Alias "_L13_MsgOptRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_MsgOptWr Lib "L13W32.DLL" Alias "_L13_MsgOptWr@12" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_MsgReset Lib "L13W32.DLL" Alias "_L13_MsgReset@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_MsgSWD1Rd Lib "L13W32.DLL" Alias "_L13_MsgSWD1Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_MsgSWD2Rd Lib "L13W32.DLL" Alias "_L13_MsgSWD2Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_Mul Lib "L13W32.DLL" Alias "_L13_Mul@8" (ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
    Public Declare Function L13_PlayClear Lib "L13W32.DLL" Alias "_L13_PlayClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_PlayConfigEx Lib "L13W32.DLL" Alias "_L13_PlayConfigEx@20" (ByVal configval As UInt32, ByVal playcount As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_PlayConfigExx Lib "L13W32.DLL" Alias "_L13_PlayConfigExx@28" (ByVal configval As UInt32, ByVal playaddr As UInt32, ByVal playcount As UInt32, ByVal seqaddr As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_PlayWrEx Lib "L13W32.DLL" Alias "_L13_PlayWrEx@12" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_PortRd Lib "L13W32.DLL" Alias "_L13_PortRd@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_PortWr Lib "L13W32.DLL" Alias "_L13_PortWr@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_ProgRdW Lib "L13W32.DLL" Alias "_L13_ProgRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_ProgWrW Lib "L13W32.DLL" Alias "_L13_ProgWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L13_RAMFill Lib "L13W32.DLL" Alias "_L13_RAMFill@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_RAMIsDPM Lib "L13W32.DLL" Alias "_L13_RAMIsDPM@4" (ByVal addrval As UInt32) As Int32
    Public Declare Function L13_RAMRdB Lib "L13W32.DLL" Alias "_L13_RAMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_RAMRdL Lib "L13W32.DLL" Alias "_L13_RAMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L13_RAMRdsL Lib "L13W32.DLL" Alias "_L13_RAMRdsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_RAMRdsW Lib "L13W32.DLL" Alias "_L13_RAMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function L13_RAMRdW Lib "L13W32.DLL" Alias "_L13_RAMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_RAMWipe Lib "L13W32.DLL" Alias "_L13_RAMWipe@4" (ByVal handleval As UInt32)
    Public Declare Sub L13_RAMWipeEx Lib "L13W32.DLL" Alias "_L13_RAMWipeEx@8" (ByVal value As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L13_RAMWrB Lib "L13W32.DLL" Alias "_L13_RAMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L13_RAMWrL Lib "L13W32.DLL" Alias "_L13_RAMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L13_RAMWrsL Lib "L13W32.DLL" Alias "_L13_RAMWrsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_RAMWrsW Lib "L13W32.DLL" Alias "_L13_RAMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L13_RAMWrW Lib "L13W32.DLL" Alias "_L13_RAMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_RTConfigEx Lib "L13W32.DLL" Alias "_L13_RTConfigEx@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_RTConfigExx Lib "L13W32.DLL" Alias "_L13_RTConfigExx@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_RTCreateListEx Lib "L13W32.DLL" Alias "_L13_RTCreateListEx@36" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_RTCreateListExx Lib "L13W32.DLL" Alias "_L13_RTCreateListExx@36" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_RTReset Lib "L13W32.DLL" Alias "_L13_RTReset@8" (ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_RTStatus Lib "L13W32.DLL" Alias "_L13_RTStatus@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_RTSWDRd Lib "L13W32.DLL" Alias "_L13_RTSWDRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_SchedBuild Lib "L13W32.DLL" Alias "_L13_SchedBuild@16" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef freq As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SchedBuildEx Lib "L13W32.DLL" Alias "_L13_SchedBuildEx@28" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef freq As Int32, ByRef period As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SchedBuildExx Lib "L13W32.DLL" Alias "_L13_SchedBuildExx@28" (ByVal frametime As UInt32, ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef period As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SchedCalc Lib "L13W32.DLL" Alias "_L13_SchedCalc@8" (ByRef msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L13_SchedDisplay Lib "L13W32.DLL" Alias "_L13_SchedDisplay@8" (ByVal nummsgs As UInt32, ByRef count As UInt32)
    Public Declare Sub L13_SchedHook Lib "L13W32.DLL" Alias "_L13_SchedHook@8" (ByVal index As Int32, ByVal ptr As IntPtr)
    Public Declare Function L13_SchedInsEnd Lib "L13W32.DLL" Alias "_L13_SchedInsEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SchedInsMsg Lib "L13W32.DLL" Alias "_L13_SchedInsMsg@12" (ByVal index As UInt32, ByRef msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SchedInsStart Lib "L13W32.DLL" Alias "_L13_SchedInsStart@12" (ByVal frametime As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SchedMaxval Lib "L13W32.DLL" Alias "_L13_SchedMaxval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
    Public Declare Function L13_SchedMinval Lib "L13W32.DLL" Alias "_L13_SchedMinval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
    Public Declare Sub L13_SchedPrint Lib "L13W32.DLL" Alias "" (ByVal ParamArray list() As String)
    Public Declare Function L13_SEEPokeW Lib "L13W32.DLL" Alias "_L13_SEEPokeW@12" (ByVal value As Int32, ByVal numbits As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SEERdBit Lib "L13W32.DLL" Alias "_L13_SEERdBit@12" (ByRef valueptr As Int32, ByVal bitnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SEERdL Lib "L13W32.DLL" Alias "_L13_SEERdL@12" (ByRef valueptr As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SEERdW Lib "L13W32.DLL" Alias "_L13_SEERdW@12" (ByRef valueptr As Int32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SEEWrBit Lib "L13W32.DLL" Alias "_L13_SEEWrBit@12" (ByVal value As Int32, ByVal bitnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SEEWrL Lib "L13W32.DLL" Alias "_L13_SEEWrL@12" (ByVal value As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SEEWrW Lib "L13W32.DLL" Alias "_L13_SEEWrW@12" (ByVal value As Int32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SEMMRdW Lib "L13W32.DLL" Alias "_L13_SEMMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_SEMMWrW Lib "L13W32.DLL" Alias "_L13_SEMMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_SEMRdW Lib "L13W32.DLL" Alias "_L13_SEMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L13_SEMWrW Lib "L13W32.DLL" Alias "_L13_SEMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L13_SerialClear Lib "L13W32.DLL" Alias "_L13_SerialClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SerialConfig Lib "L13W32.DLL" Alias "_L13_SerialConfig@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SerialConfigEx Lib "L13W32.DLL" Alias "_L13_SerialConfigEx@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SerialStatus Lib "L13W32.DLL" Alias "_L13_SerialStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L13_SerialWr Lib "L13W32.DLL" Alias "_L13_SerialWr@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_Shl Lib "L13W32.DLL" Alias "_L13_Shl@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function L13_Shr Lib "L13W32.DLL" Alias "_L13_Shr@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Sub L13_TimerClear Lib "L13W32.DLL" Alias "_L13_TimerClear@4" (ByVal handleval As UInt32)
    Public Declare Function L13_TimerRd Lib "L13W32.DLL" Alias "_L13_TimerRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L13_TimerResolution Lib "L13W32.DLL" Alias "_L13_TimerResolution@8" (ByVal timerresol As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L13_TimerResolutionEx Lib "L13W32.DLL" Alias "_L13_TimerResolutionEx@8" (ByVal timershift As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L13_ValAsciiCmpi Lib "L13W32.DLL" Alias "_L13_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Int32
    Public Declare Function L13_ValAsciiCpy Lib "L13W32.DLL" Alias "_L13_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Int32) As UInt32
    Public Declare Sub L13_ValAsciiTrimLead Lib "L13W32.DLL" Alias "_L13_ValAsciiTrimLead@4" (ByRef buf As String)
    Public Declare Sub L13_ValAsciiTrimTrail Lib "L13W32.DLL" Alias "_L13_ValAsciiTrimTrail@4" (ByRef buf As String)
    Public Declare Function L13_ValFromAscii Lib "L13W32.DLL" Alias "_L13_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
    Public Declare Function L13_ValGetBits Lib "L13W32.DLL" Alias "_L13_ValGetBits@12" (ByVal oldvalue As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function L13_ValIncAscii Lib "L13W32.DLL" Alias "_L13_ValIncAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function L13_ValInccAscii Lib "L13W32.DLL" Alias "_L13_ValInccAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function L13_ValIsLower Lib "L13W32.DLL" Alias "_L13_ValIsLower@4" (ByVal value As Int32) As Int32
    Public Declare Function L13_ValLenAscii Lib "L13W32.DLL" Alias "_L13_ValLenAscii@8" (ByVal numbits As Int32, ByVal radixval As Int32) As Int32
    Public Declare Function L13_ValPackRTCWD Lib "L13W32.DLL" Alias "_L13_ValPackRTCWD@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal count As Int32) As UInt16
    Public Declare Function L13_ValPutBits Lib "L13W32.DLL" Alias "_L13_ValPutBits@16" (ByVal oldvalue As UInt16, ByVal newfld As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function L13_ValToAscii Lib "L13W32.DLL" Alias "_L13_ValToAscii@16" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
    Public Declare Function L13_ValToUpper Lib "L13W32.DLL" Alias "_L13_ValToUpper@4" (ByVal value As Int32) As Int32
    Public Declare Sub L13_ValUnpackRTCWD Lib "L13W32.DLL" Alias "_L13_ValUnpackRTCWD@28" (ByVal cwd As UInt16, ByRef bcastflag As Int32, ByRef mcflag As Int32, ByRef taval As Int32, ByRef trflag As Int32, ByRef saval As Int32, ByRef count As Int32)

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
    Public Const BCCFG_MODEL As UInt32 = &H0L    '//BC messages are created in dual-port RAM (default)
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
    Public Const RTCFG_STDA As UInt32 = &H800L '//Use MIL-STD-1553A standard
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
    Public Const RTCFG_MODEL As UInt32 = &H0L    '//RT messages are created in static RAM or dual-port RAM depending upon board model (default)
    Public Const RTCFG_RAM As UInt32 = &H100000L  '//RT messages are created in static RAM
    Public Const RTCFG_DPRAM As UInt32 = &H200000L    '//RT messages are created in dual-port RAM

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

    Public Const INFOTYPE_PLAT As UInt16 = &H1   '//Returns the L13 platform type
    Public Const INFOTYPE_PROD As UInt16 = &H2   '//Returns the L13 product type
    Public Const INFOTYPE_DASH As UInt16 = &H3   '//Returns the L13 dash number
    Public Const INFOTYPE_VERSION As UInt16 = &H4    '//Returns the L13 version number
    Public Const INFOTYPE_DATE As UInt16 = &H5   '//Returns the L13 version date
    Public Const INFOTYPE_MODEL As UInt16 = &H6  '//Returns the L13 model number
    Public Const INFOTYPE_MAXCOUNT As UInt16 = &H7   '//Returns the number of terminals the L13 can simulate
    Public Const INFOTYPE_MULTIMODE As UInt16 = &H8  '//Returns whether L13 can simulate multi-modes
    Public Const INFOTYPE_ERRORGEN As UInt16 = &H9   '//Returns whether L13 can generate errors
    Public Const INFOTYPE_CONCURMON As UInt16 = &HA  '//Returns whether L13 has a concurrent monitor
    Public Const INFOTYPE_MONFILTER As UInt16 = &HB  '//Returns whether L13 has a monitor filter
    Public Const INFOTYPE_USERCODE As UInt16 = &HC   '//Returns whether L13 handles user code
    Public Const INFOTYPE_LISTBUF As UInt16 = &HD    '//Returns whether L13 handles list buffering
    Public Const INFOTYPE_MONFAST As UInt16 = &HE    '//Returns whether L13 has a fast monitor
    Public Const INFOTYPE_MONDMA As UInt16 = &HF '//Returns whether L13 has a dma monitor
    Public Const INFOTYPE_MONBRAKE As UInt16 = &H10   '//Returns whether L13 has a monitor brake
    Public Const INFOTYPE_PLAY As UInt16 = &H11   '//Returns whether L13 has playback capability

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
    Public Const MSGCRT_NOINT As UInt32 = &H0L   '//Message will not generate interrupt (default)
    Public Const MSGCRT_INT As UInt32 = &H1L '//Message will generate interrupt
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
    Public Const MSGCRT_MODEL As UInt32 = &H0L   '//Message located in static RAM or dual-port RAM depending upon defaults (default)
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
    '*  L13 IFGA Registers
    '*
    '**/

    Public Const IREG_STAT As UInt16 = &H40   '//Status register (RD)
    Public Const IREG_SET As UInt16 = &H41    '//Set register (WR)
    Public Const IREG_CLR As UInt16 = &H42    '//Clear register (WR)
    Public Const IREG_ID As UInt16 = &H43 '//ID register (RD)
    Public Const IREG_PAGE As UInt16 = &H44   '//Page register
    Public Const IREG_CONFIG As UInt16 = &H45 '//Configuration register
    Public Const IREG_DINT As UInt16 = &H46   '//DSP interrupt register
    Public Const IREG_HINT As UInt16 = &H47   '//HOST interrupt register

    '/**
    '*
    '*  EDGA Registers
    '*
    '**/

    Public Const EREG_STAT As UInt16 = &H180   '//Status register (RD)
    Public Const EREG_STATCLR As UInt16 = &H81    '//Status clear register (WR)
    Public Const EREG_STATDEC As UInt16 = &H82    '//Decoder status register (RD)
    Public Const EREG_VALA As UInt16 = &H84   '//Decoder word value A register
    Public Const EREG_VALAL As UInt16 = &H84  '//Decoder low word value A register
    Public Const EREG_VALAH As UInt16 = &H85  '//Decoder high word value A register
    Public Const EREG_VALB As UInt16 = &H86   '//Decoder word value B register
    Public Const EREG_VALBL As UInt16 = &H86  '//Decoder low word value B register
    Public Const EREG_VALBH As UInt16 = &H87  '//Decoder high word value B register
    Public Const EREG_GAPE As UInt16 = &H88   '//Encoder gap register
    Public Const EREG_CTRLE As UInt16 = &H89  '//Encoder control register
    Public Const EREG_VALE As UInt16 = &H8A   '//Encoder value register
    Public Const EREG_VALEL As UInt16 = &H8A  '//Encoder low value register
    Public Const EREG_VALEH As UInt16 = &H8B  '//Encoder high value register
    Public Const EREG_ERRE As UInt16 = &H8C   '//Encoder error register
    Public Const EREG_FT As UInt16 = &H8E '//Frame time register
    Public Const EREG_RST As UInt16 = &H8F    '//Reset register
    Public Const EREG_GAPA As UInt16 = &H90   '//Decoder gap time A register
    Public Const EREG_GAPB As UInt16 = &H91   '//Decoder gap time B register
    Public Const EREG_GAPTO As UInt16 = &H92  '//Decoder gap timeout register
    Public Const EREG_CFGD As UInt16 = &H94   '//Decoder configuration register
    Public Const EREG_CFGE As UInt16 = &H95   '//Encoder configuration register
    Public Const EREG_CFGINT As UInt16 = &H96 '//Interrupt configuration register
    Public Const EREG_ID As UInt16 = &H97 '//Identification register

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
    Public Const ERR_BADPARAMS As Int16 = -11   '//CardOpen() called with bad parameters
    Public Const ERR_NOHANDLES As Int16 = -12   '//CardOpen() already has allocated too many handles
    Public Const ERR_NOCARD As Int16 = -13  '//CardOpen() could not find a L13 card at the specified address
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
    Public Const ERR_ACCESS As Int16 = -43  '//Unable to write to access register
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
    Public Const ERR_PLXBUG As Int16 = -75  '//PLX bug is causing problems

End Module
