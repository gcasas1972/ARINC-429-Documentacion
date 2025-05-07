Imports System
Imports System.Runtime.InteropServices

Module L71W32VB

    '/**
    '*
    '*  LP708-1 and LC708-1 WIN32 DRIVER  Version 1.2  (01/19/2001)
    '*  Copyright (c) 1999-2001
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   L71W32NET.VB -- 32-bit
    '*                      L71 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  L71 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the L71 Driver.
    '*
    '**/

    Public Declare Function L71_CardClose Lib "L71W32.DLL" Alias "_L71_CardClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardOpen Lib "L71W32.DLL" Alias "_L71_CardOpen@4" (ByVal cardnum As Int32) As UInt32
    Public Declare Sub L71_CardReset Lib "L71W32.DLL" Alias "_L71_CardReset@4" (ByVal handleval As UInt32)
    Public Declare Function L71_CardStart Lib "L71W32.DLL" Alias "_L71_CardStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardStop Lib "L71W32.DLL" Alias "_L71_CardStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_FieldGetAngle Lib "L71W32.DLL" Alias "_L71_FieldGetAngle@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldGetAngleFl Lib "L71W32.DLL" Alias "_L71_FieldGetAngleFl@4" (ByRef buf As UInt16) As Single
    Public Declare Function L71_FieldGetControlAccept Lib "L71W32.DLL" Alias "_L71_FieldGetControlAccept@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldGetData Lib "L71W32.DLL" Alias "_L71_FieldGetData@8" (ByVal binnum As Int32, ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldGetDataAccept Lib "L71W32.DLL" Alias "_L71_FieldGetDataAccept@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldGetFaults Lib "L71W32.DLL" Alias "_L71_FieldGetFaults@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldGetGain Lib "L71W32.DLL" Alias "_L71_FieldGetGain@4" (ByRef buf As UInt16) As Int32
    Public Declare Function L71_FieldGetLabel Lib "L71W32.DLL" Alias "_L71_FieldGetLabel@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldGetMode Lib "L71W32.DLL" Alias "_L71_FieldGetMode@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldGetRange Lib "L71W32.DLL" Alias "_L71_FieldGetRange@4" (ByRef buf As UInt16) As Int32
    Public Declare Function L71_FieldGetTilt Lib "L71W32.DLL" Alias "_L71_FieldGetTilt@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldGetTiltFl Lib "L71W32.DLL" Alias "_L71_FieldGetTiltFl@4" (ByRef buf As UInt16) As Single
    Public Declare Function L71_FieldPutAngle Lib "L71W32.DLL" Alias "_L71_FieldPutAngle@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldPutAngleFl Lib "L71W32.DLL" Alias "_L71_FieldPutAngleFl@8" (ByVal angle As Single, ByRef buf As UInt16) As Single
    Public Declare Function L71_FieldPutControlAccept Lib "L71W32.DLL" Alias "_L71_FieldPutControlAccept@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldPutData Lib "L71W32.DLL" Alias "_L71_FieldPutData@12" (ByVal value As UInt16, ByVal binnum As Int32, ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldPutDataAccept Lib "L71W32.DLL" Alias "_L71_FieldPutDataAccept@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldPutFaults Lib "L71W32.DLL" Alias "_L71_FieldPutFaults@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldPutGain Lib "L71W32.DLL" Alias "_L71_FieldPutGain@8" (ByVal gain As Int32, ByRef buf As UInt16) As Int32
    Public Declare Function L71_FieldPutLabel Lib "L71W32.DLL" Alias "_L71_FieldPutLabel@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldPutMode Lib "L71W32.DLL" Alias "_L71_FieldPutMode@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldPutRange Lib "L71W32.DLL" Alias "_L71_FieldPutRange@8" (ByVal range As Int32, ByRef buf As UInt16) As Int32
    Public Declare Function L71_FieldPutTilt Lib "L71W32.DLL" Alias "_L71_FieldPutTilt@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function L71_FieldPutTiltFl Lib "L71W32.DLL" Alias "_L71_FieldPutTiltFl@8" (ByVal tilt As Single, ByRef buf As UInt16) As Single
    Public Declare Function L71_IntInstall Lib "L71W32.DLL" Alias "_L71_IntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_IntRd Lib "L71W32.DLL" Alias "_L71_IntRd@12" (ByRef typevalval As UInt16, ByRef infoval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_IntStatus Lib "L71W32.DLL" Alias "_L71_IntStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_IntUninstall Lib "L71W32.DLL" Alias "_L71_IntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_RcvConfig Lib "L71W32.DLL" Alias "_L71_RcvConfig@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_RcvConfigEx Lib "L71W32.DLL" Alias "_L71_RcvConfigEx@12" (ByVal rtconfigval As UInt32, ByVal intfreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_RcvMonBlkRd Lib "L71W32.DLL" Alias "_L71_RcvMonBlkRd@16" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_RcvMonBlkRdEx Lib "L71W32.DLL" Alias "_L71_RcvMonBlkRdEx@20" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal maxblkcnt As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_RcvMonRd Lib "L71W32.DLL" Alias "_L71_RcvMonRd@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_RcvMonRdEx Lib "L71W32.DLL" Alias "_L71_RcvMonRdEx@12" (ByRef buf As UInt16, ByVal index As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_RcvMonStatus Lib "L71W32.DLL" Alias "_L71_RcvMonStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_RcvRd Lib "L71W32.DLL" Alias "_L71_RcvRd@8" (ByRef buf As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_XmtConfig Lib "L71W32.DLL" Alias "_L71_XmtConfig@8" (ByVal framefreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_XmtConfigEx Lib "L71W32.DLL" Alias "_L71_XmtConfigEx@16" (ByVal framefreq As UInt16, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_XmtConfigExx Lib "L71W32.DLL" Alias "_L71_XmtConfigExx@20" (ByVal xmtconfigval As UInt32, ByVal framefreq As UInt16, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_XmtRd Lib "L71W32.DLL" Alias "_L71_XmtRd@12" (ByRef buf As UInt16, ByVal framenum As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_XmtStatus Lib "L71W32.DLL" Alias "_L71_XmtStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_XmtWr Lib "L71W32.DLL" Alias "_L71_XmtWr@12" (ByRef buf As UInt16, ByVal framenum As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_AddrDSP Lib "L71W32.DLL" Alias "_L71_AddrDSP@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function L71_AddrHost Lib "L71W32.DLL" Alias "_L71_AddrHost@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function L71_BCConfig Lib "L71W32.DLL" Alias "_L71_BCConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCConfigEx Lib "L71W32.DLL" Alias "_L71_BCConfigEx@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCConfigMsg Lib "L71W32.DLL" Alias "_L71_BCConfigMsg@12" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_BCCreateList Lib "L71W32.DLL" Alias "_L71_BCCreateList@28" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_BCCreateListEx Lib "L71W32.DLL" Alias "_L71_BCCreateListEx@32" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_BCCreateListExx Lib "L71W32.DLL" Alias "_L71_BCCreateListExx@32" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_BCCreateMsg Lib "L71W32.DLL" Alias "_L71_BCCreateMsg@20" (ByVal configval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_BCGetMsg Lib "L71W32.DLL" Alias "_L71_BCGetMsg@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_BCSchedAgain Lib "L71W32.DLL" Alias "_L71_BCSchedAgain@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedBranch Lib "L71W32.DLL" Alias "_L71_BCSchedBranch@12" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedBranchDin0 Lib "L71W32.DLL" Alias "_L71_BCSchedBranchDin0@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedBranchDin1 Lib "L71W32.DLL" Alias "_L71_BCSchedBranchDin1@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedBranchEx Lib "L71W32.DLL" Alias "_L71_BCSchedBranchEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedBuild Lib "L71W32.DLL" Alias "_L71_BCSchedBuild@16" (ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef freq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedCall Lib "L71W32.DLL" Alias "_L71_BCSchedCall@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedCallCond Lib "L71W32.DLL" Alias "_L71_BCSchedCallCond@12" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedCallCondEx Lib "L71W32.DLL" Alias "_L71_BCSchedCallCondEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedEntry Lib "L71W32.DLL" Alias "_L71_BCSchedEntry@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedFrame Lib "L71W32.DLL" Alias "_L71_BCSchedFrame@8" (ByVal timeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedFrameEnd Lib "L71W32.DLL" Alias "_L71_BCSchedFrameEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedFrameStart Lib "L71W32.DLL" Alias "_L71_BCSchedFrameStart@8" (ByVal timeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedGap Lib "L71W32.DLL" Alias "_L71_BCSchedGap@8" (ByVal gapval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedGoto Lib "L71W32.DLL" Alias "_L71_BCSchedGoto@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedHalt Lib "L71W32.DLL" Alias "_L71_BCSchedHalt@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedInt Lib "L71W32.DLL" Alias "_L71_BCSchedInt@8" (ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedIntCond Lib "L71W32.DLL" Alias "_L71_BCSchedIntCond@12" (ByVal condition As UInt16, ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedIntCondEx Lib "L71W32.DLL" Alias "_L71_BCSchedIntCondEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedMsg Lib "L71W32.DLL" Alias "_L71_BCSchedMsg@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedNop Lib "L71W32.DLL" Alias "_L71_BCSchedNop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedPause Lib "L71W32.DLL" Alias "_L71_BCSchedPause@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedPulse Lib "L71W32.DLL" Alias "_L71_BCSchedPulse@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedPulse0 Lib "L71W32.DLL" Alias "_L71_BCSchedPulse0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedPulse1 Lib "L71W32.DLL" Alias "_L71_BCSchedPulse1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedRestart Lib "L71W32.DLL" Alias "_L71_BCSchedRestart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedRetry Lib "L71W32.DLL" Alias "_L71_BCSchedRetry@12" (ByVal condition As UInt16, ByVal retries As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedRetryEx Lib "L71W32.DLL" Alias "_L71_BCSchedRetryEx@24" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal retryflag As UInt16, ByVal retries As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedReturn Lib "L71W32.DLL" Alias "_L71_BCSchedReturn@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSchedUser Lib "L71W32.DLL" Alias "_L71_BCSchedUser@8" (ByVal useraddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSetEntry Lib "L71W32.DLL" Alias "_L71_BCSetEntry@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BCSetTimeout Lib "L71W32.DLL" Alias "_L71_BCSetTimeout@8" (ByVal timeoutval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BlkAddr Lib "L71W32.DLL" Alias "_L71_BlkAddr@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_BlkOptRd Lib "L71W32.DLL" Alias "_L71_BlkOptRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_BlkOptWr Lib "L71W32.DLL" Alias "_L71_BlkOptWr@12" (ByVal rtopt As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BlkPtrRd Lib "L71W32.DLL" Alias "_L71_BlkPtrRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L71_BlkPtrWr Lib "L71W32.DLL" Alias "_L71_BlkPtrWr@12" (ByVal descaddr As UInt32, ByVal taval As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_BlkRd Lib "L71W32.DLL" Alias "_L71_BlkRd@12" (ByRef block As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BlkReset Lib "L71W32.DLL" Alias "_L71_BlkReset@8" (ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BlkSWDRd Lib "L71W32.DLL" Alias "_L71_BlkSWDRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_BlkSWDWr Lib "L71W32.DLL" Alias "_L71_BlkSWDWr@12" (ByVal swdval As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BlkWipe Lib "L71W32.DLL" Alias "_L71_BlkWipe@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_BlkWr Lib "L71W32.DLL" Alias "_L71_BlkWr@12" (ByRef block As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardBoot Lib "L71W32.DLL" Alias "_L71_CardBoot@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardCloseAll Lib "L71W32.DLL" Alias "_L71_CardCloseAll@0" () As Int32
    Public Declare Function L71_CardConfig Lib "L71W32.DLL" Alias "_L71_CardConfig@16" (ByVal enableflag As Int32, ByVal command As UInt16, ByVal taval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardGetInfo Lib "L71W32.DLL" Alias "_L71_CardGetInfo@8" (ByVal infotype As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_CardGetInfoEx Lib "L71W32.DLL" Alias "_L71_CardGetInfoEx@20" (ByRef bufmodel As UInt16, ByVal bufmodelcount As UInt16, ByRef buffeature As UInt16, ByVal buffeaturecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_CardInit Lib "L71W32.DLL" Alias "_L71_CardInit@0" ()
    Public Declare Function L71_CardIsRunning Lib "L71W32.DLL" Alias "_L71_CardIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardNop Lib "L71W32.DLL" Alias "_L71_CardNop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardNopEx Lib "L71W32.DLL" Alias "_L71_CardNopEx@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardOpenEx Lib "L71W32.DLL" Alias "_L71_CardOpenEx@8" (ByRef cardname As String, ByVal cardnum As Int32) As UInt32
    Public Declare Function L71_CardOpenExx Lib "L71W32.DLL" Alias "_L71_CardOpenExx@16" (ByRef cardname As String, ByVal cardnum As Int32, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Sub L71_CardResetEx Lib "L71W32.DLL" Alias "_L71_CardResetEx@4" (ByVal handleval As UInt32)
    Public Declare Function L71_CardResume Lib "L71W32.DLL" Alias "_L71_CardResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardTest Lib "L71W32.DLL" Alias "_L71_CardTest@8" (ByVal level As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardTest0 Lib "L71W32.DLL" Alias "_L71_CardTest0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardTest1 Lib "L71W32.DLL" Alias "_L71_CardTest1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardTest2 Lib "L71W32.DLL" Alias "_L71_CardTest2@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CardTest3 Lib "L71W32.DLL" Alias "_L71_CardTest3@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_CardTrigger Lib "L71W32.DLL" Alias "_L71_CardTrigger@4" (ByVal handleval As UInt32)
    Public Declare Function L71_CFGRdL Lib "L71W32.DLL" Alias "_L71_CFGRdL@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L71_CFGWrL Lib "L71W32.DLL" Alias "_L71_CFGWrL@12" (ByVal value As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_CmdAddr Lib "L71W32.DLL" Alias "_L71_CmdAddr@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_CmdAlloc Lib "L71W32.DLL" Alias "_L71_CmdAlloc@8" (ByVal count As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_CmdAllocEx Lib "L71W32.DLL" Alias "_L71_CmdAllocEx@12" (ByVal configval As UInt32, ByVal count As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_CmdBaseRd Lib "L71W32.DLL" Alias "_L71_CmdBaseRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Sub L71_CmdBaseWr Lib "L71W32.DLL" Alias "_L71_CmdBaseWr@8" (ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_CmdClear Lib "L71W32.DLL" Alias "_L71_CmdClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CmdCountRd Lib "L71W32.DLL" Alias "_L71_CmdCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_CmdCountWr Lib "L71W32.DLL" Alias "_L71_CmdCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_CmdCtrlRd Lib "L71W32.DLL" Alias "_L71_CmdCtrlRd@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_CmdCtrlWr Lib "L71W32.DLL" Alias "_L71_CmdCtrlWr@12" (ByVal ctrlval As UInt16, ByVal index As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_CmdCurrRd Lib "L71W32.DLL" Alias "_L71_CmdCurrRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_CmdCurrWr Lib "L71W32.DLL" Alias "_L71_CmdCurrWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L71_CmdInit Lib "L71W32.DLL" Alias "_L71_CmdInit@8" (ByVal opcode As UInt16, ByRef block As UInt16)
    Public Declare Function L71_CmdInsert Lib "L71W32.DLL" Alias "_L71_CmdInsert@8" (ByRef block As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CmdMaxRd Lib "L71W32.DLL" Alias "_L71_CmdMaxRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_CmdMaxWr Lib "L71W32.DLL" Alias "_L71_CmdMaxWr@8" (ByVal count As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_CmdRd Lib "L71W32.DLL" Alias "_L71_CmdRd@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CmdShotWr Lib "L71W32.DLL" Alias "_L71_CmdShotWr@12" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CmdSkipWr Lib "L71W32.DLL" Alias "_L71_CmdSkipWr@12" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_CmdStackClr Lib "L71W32.DLL" Alias "_L71_CmdStackClr@4" (ByVal handleval As UInt32)
    Public Declare Function L71_CmdStartRd Lib "L71W32.DLL" Alias "_L71_CmdStartRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_CmdStartWr Lib "L71W32.DLL" Alias "_L71_CmdStartWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_CmdTotalRd Lib "L71W32.DLL" Alias "_L71_CmdTotalRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_CmdTotalWr Lib "L71W32.DLL" Alias "_L71_CmdTotalWr@8" (ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_CmdWr Lib "L71W32.DLL" Alias "_L71_CmdWr@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CommCall Lib "L71W32.DLL" Alias "_L71_CommCall@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CommCheck Lib "L71W32.DLL" Alias "_L71_CommCheck@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CommDisable Lib "L71W32.DLL" Alias "_L71_CommDisable@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CommDisableEx Lib "L71W32.DLL" Alias "_L71_CommDisableEx@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CommEnable Lib "L71W32.DLL" Alias "_L71_CommEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CommRdL Lib "L71W32.DLL" Alias "_L71_CommRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_CommRdsW Lib "L71W32.DLL" Alias "_L71_CommRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_CommRdW Lib "L71W32.DLL" Alias "_L71_CommRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_CommRun Lib "L71W32.DLL" Alias "_L71_CommRun@20" (ByRef dataptr As UInt16, ByVal datacount As UInt16, ByRef codeptr As UInt16, ByVal codecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_CommWrL Lib "L71W32.DLL" Alias "_L71_CommWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_CommWrsW Lib "L71W32.DLL" Alias "_L71_CommWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_CommWrW Lib "L71W32.DLL" Alias "_L71_CommWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L71_DARClr Lib "L71W32.DLL" Alias "_L71_DARClr@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_DARGet Lib "L71W32.DLL" Alias "_L71_DARGet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_DARRdL Lib "L71W32.DLL" Alias "_L71_DARRdL@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_DARRdW Lib "L71W32.DLL" Alias "_L71_DARRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_DARSet Lib "L71W32.DLL" Alias "_L71_DARSet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L71_DARWrL Lib "L71W32.DLL" Alias "_L71_DARWrL@12" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L71_DARWrW Lib "L71W32.DLL" Alias "_L71_DARWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_DescAddr Lib "L71W32.DLL" Alias "_L71_DescAddr@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_DescAlloc Lib "L71W32.DLL" Alias "_L71_DescAlloc@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_DescConfig Lib "L71W32.DLL" Alias "_L71_DescConfig@24" (ByVal configval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_DescOptRd Lib "L71W32.DLL" Alias "_L71_DescOptRd@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_DescOptWr Lib "L71W32.DLL" Alias "_L71_DescOptWr@24" (ByVal descopt As UInt16, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_DescPtrRd Lib "L71W32.DLL" Alias "_L71_DescPtrRd@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_DescPtrWr Lib "L71W32.DLL" Alias "_L71_DescPtrWr@24" (ByVal msgaddr As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_DescRd Lib "L71W32.DLL" Alias "_L71_DescRd@24" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByRef desc As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_DescWr Lib "L71W32.DLL" Alias "_L71_DescWr@24" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByRef desc As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_Div Lib "L71W32.DLL" Alias "_L71_Div@8" (ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
    Public Declare Function L71_DllUsageCount Lib "L71W32.DLL" Alias "_L71_DllUsageCount@0" () As Int32
    Public Declare Function L71_DPMMRdW Lib "L71W32.DLL" Alias "_L71_DPMMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_DPMMWrW Lib "L71W32.DLL" Alias "_L71_DPMMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_DPMRdB Lib "L71W32.DLL" Alias "_L71_DPMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_DPMRdL Lib "L71W32.DLL" Alias "_L71_DPMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L71_DPMRdsL Lib "L71W32.DLL" Alias "_L71_DPMRdsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_DPMRdsW Lib "L71W32.DLL" Alias "_L71_DPMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_DPMRdW Lib "L71W32.DLL" Alias "_L71_DPMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_DPMWrB Lib "L71W32.DLL" Alias "_L71_DPMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L71_DPMWrL Lib "L71W32.DLL" Alias "_L71_DPMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L71_DPMWrsL Lib "L71W32.DLL" Alias "_L71_DPMWrsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_DPMWrsW Lib "L71W32.DLL" Alias "_L71_DPMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_DPMWrW Lib "L71W32.DLL" Alias "_L71_DPMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_DspBioClear Lib "L71W32.DLL" Alias "_L71_DspBioClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_DspBioRd Lib "L71W32.DLL" Alias "_L71_DspBioRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_DspBioSet Lib "L71W32.DLL" Alias "_L71_DspBioSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_DspIntfClear Lib "L71W32.DLL" Alias "_L71_DspIntfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_DspIntfRead Lib "L71W32.DLL" Alias "_L71_DspIntfRead@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_DspIntmClear Lib "L71W32.DLL" Alias "_L71_DspIntmClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_DspIntmSet Lib "L71W32.DLL" Alias "_L71_DspIntmSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_DspXfClear Lib "L71W32.DLL" Alias "_L71_DspXfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_DspXfSet Lib "L71W32.DLL" Alias "_L71_DspXfSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ErrDesc Lib "L71W32.DLL" Alias "_L71_ErrDesc@4" (ByVal errval As Int32) As UInt32
    Public Declare Function L71_ErrDescStr Lib "L71W32.DLL" Alias "_L71_ErrDescStr@4" (ByVal errval As Int32) As UInt32
    Public Declare Function L71_ErrName Lib "L71W32.DLL" Alias "_L71_ErrName@4" (ByVal errval As Int32) As UInt32
    Public Declare Function L71_ErrorDefine Lib "L71W32.DLL" Alias "_L71_ErrorDefine@12" (ByVal busb As Int32, ByVal intfreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ExtDinRd Lib "L71W32.DLL" Alias "_L71_ExtDinRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_ExtDinWr Lib "L71W32.DLL" Alias "_L71_ExtDinWr@8" (ByVal dinval As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_ExtDoutRd Lib "L71W32.DLL" Alias "_L71_ExtDoutRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_ExtDoutWr Lib "L71W32.DLL" Alias "_L71_ExtDoutWr@8" (ByVal doutval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_FileClose Lib "L71W32.DLL" Alias "_L71_FileClose@4" (ByVal handle As IntPtr)
    Public Declare Function L71_FileErr Lib "L71W32.DLL" Alias "_L71_FileErr@0" () As Int32
    Public Declare Sub L71_FileErrClr Lib "L71W32.DLL" Alias "_L71_FileErrClr@0" ()
    Public Declare Sub L71_FileErrSet Lib "L71W32.DLL" Alias "_L71_FileErrSet@0" ()
    Public Declare Function L71_FileOpenRead Lib "L71W32.DLL" Alias "_L71_FileOpenRead@4" (ByRef filename As String) As UInt32
    Public Declare Function L71_FileOpenWrite Lib "L71W32.DLL" Alias "_L71_FileOpenWrite@4" (ByRef filename As String) As UInt32
    Public Declare Function L71_FileRead Lib "L71W32.DLL" Alias "_L71_FileRead@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function L71_FileSeek Lib "L71W32.DLL" Alias "_L71_FileSeek@8" (ByVal handle As IntPtr, ByVal offset As UInt32) As Int32
    Public Declare Function L71_FileTell Lib "L71W32.DLL" Alias "_L71_FileTell@4" (ByVal handle As IntPtr) As UInt32
    Public Declare Function L71_FileWrite Lib "L71W32.DLL" Alias "_L71_FileWrite@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function L71_GetHigh Lib "L71W32.DLL" Alias "_L71_GetHigh@4" (ByVal val As UInt32) As UInt16
    Public Declare Function L71_GetLow Lib "L71W32.DLL" Alias "_L71_GetLow@4" (ByVal val As UInt32) As UInt16
    Public Declare Function L71_GlobalRdW Lib "L71W32.DLL" Alias "_L71_GlobalRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_GlobalWrW Lib "L71W32.DLL" Alias "_L71_GlobalWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_HandleClose Lib "L71W32.DLL" Alias "_L71_HandleClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_HandleDel Lib "L71W32.DLL" Alias "_L71_HandleDel@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_HandleGet Lib "L71W32.DLL" Alias "_L71_HandleGet@20" (ByRef cardstr As String, ByRef cardnum As Int32, ByRef devnum As Int32, ByRef sizval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_HandleIns Lib "L71W32.DLL" Alias "_L71_HandleIns@16" (ByRef cardname As String, ByVal cardnum As Int32, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Function L71_HandleOkay Lib "L71W32.DLL" Alias "_L71_HandleOkay@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_HandleOpen Lib "L71W32.DLL" Alias "_L71_HandleOpen@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_HandleOpenWin95 Lib "L71W32.DLL" Alias "_L71_HandleOpenWin95@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_HandleOpenWinNT Lib "L71W32.DLL" Alias "_L71_HandleOpenWinNT@12" (ByRef cardname As String, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_HandleVer Lib "L71W32.DLL" Alias "_L71_HandleVer@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_HandleVerPLX Lib "L71W32.DLL" Alias "_L71_HandleVerPLX@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_HeapAlloc Lib "L71W32.DLL" Alias "_L71_HeapAlloc@8" (ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_HeapAllocAll Lib "L71W32.DLL" Alias "_L71_HeapAllocAll@8" (ByRef wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_HeapAllocAllDPM Lib "L71W32.DLL" Alias "_L71_HeapAllocAllDPM@8" (ByRef wordcount As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_HeapAllocDPM Lib "L71W32.DLL" Alias "_L71_HeapAllocDPM@8" (ByVal wordcount As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_HeapAllocEx Lib "L71W32.DLL" Alias "_L71_HeapAllocEx@12" (ByVal configval As UInt16, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_HeapWipe Lib "L71W32.DLL" Alias "_L71_HeapWipe@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_HeapWipeDPM Lib "L71W32.DLL" Alias "_L71_HeapWipeDPM@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_IndirectRd Lib "L71W32.DLL" Alias "_L71_IndirectRd@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_IndirectWr Lib "L71W32.DLL" Alias "_L71_IndirectWr@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_IntClear Lib "L71W32.DLL" Alias "_L71_IntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_IntConfig Lib "L71W32.DLL" Alias "_L71_IntConfig@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_IntDisable Lib "L71W32.DLL" Alias "_L71_IntDisable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_IntEnable Lib "L71W32.DLL" Alias "_L71_IntEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_IntEnableCond Lib "L71W32.DLL" Alias "_L71_IntEnableCond@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_IntGet Lib "L71W32.DLL" Alias "_L71_IntGet@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Sub L71_IntReset Lib "L71W32.DLL" Alias "_L71_IntReset@4" (ByVal handleval As UInt32)
    Public Declare Function L71_IORdW Lib "L71W32.DLL" Alias "_L71_IORdW@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_IOWINRdW Lib "L71W32.DLL" Alias "_L71_IOWINRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_IOWINWrW Lib "L71W32.DLL" Alias "_L71_IOWINWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L71_IOWrW Lib "L71W32.DLL" Alias "_L71_IOWrW@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_KernDev Lib "L71W32.DLL" Alias "_L71_KernDev@8" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernEnd Lib "L71W32.DLL" Alias "_L71_KernEnd@4" (ByVal vxdptr As IntPtr) As Int32
    Public Declare Function L71_KernIntClear Lib "L71W32.DLL" Alias "_L71_KernIntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernIntInstall Lib "L71W32.DLL" Alias "_L71_KernIntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernIntParam Lib "L71W32.DLL" Alias "_L71_KernIntParam@32" (ByVal clraddr As UInt32, ByVal clrwidth As UInt32, ByVal clrvalue As UInt32, ByVal stataddr As UInt32, ByVal statwidth As UInt32, ByVal statvalue As UInt32, ByVal statmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernIntStatus Lib "L71W32.DLL" Alias "_L71_KernIntStatus@8" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernIntUninstall Lib "L71W32.DLL" Alias "_L71_KernIntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernIORdW Lib "L71W32.DLL" Alias "_L71_KernIORdW@12" (ByRef valueptr As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernIOWrW Lib "L71W32.DLL" Alias "_L71_KernIOWrW@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernMEMFillW Lib "L71W32.DLL" Alias "_L71_KernMEMFillW@20" (ByVal value As UInt16, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernMEMRdL Lib "L71W32.DLL" Alias "_L71_KernMEMRdL@16" (ByRef valueptr As UInt32, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernMEMRdsL Lib "L71W32.DLL" Alias "_L71_KernMEMRdsL@20" (ByRef bufptr As UInt32, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernMEMRdsW Lib "L71W32.DLL" Alias "_L71_KernMEMRdsW@20" (ByRef bufptr As UInt16, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernMEMRdW Lib "L71W32.DLL" Alias "_L71_KernMEMRdW@16" (ByRef valueptr As UInt16, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernMEMWrL Lib "L71W32.DLL" Alias "_L71_KernMEMWrL@16" (ByVal value As UInt32, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernMEMWrsL Lib "L71W32.DLL" Alias "_L71_KernMEMWrsL@20" (ByRef bufptr As UInt32, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernMEMWrsW Lib "L71W32.DLL" Alias "_L71_KernMEMWrsW@20" (ByRef bufptr As UInt16, ByVal addrval As Int32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernMEMWrW Lib "L71W32.DLL" Alias "_L71_KernMEMWrW@16" (ByVal value As UInt16, ByVal addrval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernQuick Lib "L71W32.DLL" Alias "_L71_KernQuick@8" (ByVal flag As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernStatus Lib "L71W32.DLL" Alias "_L71_KernStatus@12" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_KernStatusEx Lib "L71W32.DLL" Alias "_L71_KernStatusEx@16" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal index As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ListAddr Lib "L71W32.DLL" Alias "_L71_ListAddr@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_ListAddrEx Lib "L71W32.DLL" Alias "_L71_ListAddrEx@12" (ByVal index As Int32, ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Function L71_ListBlockRd Lib "L71W32.DLL" Alias "_L71_ListBlockRd@12" (ByRef buf As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_ListBlockRdEx Lib "L71W32.DLL" Alias "_L71_ListBlockRdEx@16" (ByRef buf As UInt16, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_ListBlockWr Lib "L71W32.DLL" Alias "_L71_ListBlockWr@12" (ByRef buf As UInt16, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_ListBlockWrEx Lib "L71W32.DLL" Alias "_L71_ListBlockWrEx@16" (ByRef buf As UInt16, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_ListClear Lib "L71W32.DLL" Alias "_L71_ListClear@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ListConfig Lib "L71W32.DLL" Alias "_L71_ListConfig@16" (ByVal configval As UInt32, ByVal count As Int32, ByVal skipval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_ListConfigEx Lib "L71W32.DLL" Alias "_L71_ListConfigEx@16" (ByVal configval As UInt32, ByVal count As Int32, ByVal skipval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_ListDataRd Lib "L71W32.DLL" Alias "_L71_ListDataRd@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ListDataRdEx Lib "L71W32.DLL" Alias "_L71_ListDataRdEx@20" (ByRef buf As UInt16, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ListDataWr Lib "L71W32.DLL" Alias "_L71_ListDataWr@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ListDataWrEx Lib "L71W32.DLL" Alias "_L71_ListDataWrEx@20" (ByRef buf As UInt16, ByVal count As Int32, ByVal index As Int32, ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ListInit Lib "L71W32.DLL" Alias "_L71_ListInit@12" (ByVal listaddr As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ListNextRd Lib "L71W32.DLL" Alias "_L71_ListNextRd@8" (ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Function L71_ListNextWr Lib "L71W32.DLL" Alias "_L71_ListNextWr@8" (ByVal listaddr As UInt32, ByRef header As UInt16) As UInt32
    Public Declare Sub L71_ListPostRd Lib "L71W32.DLL" Alias "_L71_ListPostRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L71_ListPostWr Lib "L71W32.DLL" Alias "_L71_ListPostWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L71_ListPreRd Lib "L71W32.DLL" Alias "_L71_ListPreRd@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L71_ListPreWr Lib "L71W32.DLL" Alias "_L71_ListPreWr@12" (ByVal listaddr As UInt32, ByRef header As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_ListStatus Lib "L71W32.DLL" Alias "_L71_ListStatus@8" (ByVal listaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MakeLong Lib "L71W32.DLL" Alias "_L71_MakeLong@8" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
    Public Declare Function L71_Mask Lib "L71W32.DLL" Alias "_L71_Mask@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Sub L71_MEMWINFillW Lib "L71W32.DLL" Alias "_L71_MEMWINFillW@20" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_MEMWINRdB Lib "L71W32.DLL" Alias "_L71_MEMWINRdB@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_MEMWINRdL Lib "L71W32.DLL" Alias "_L71_MEMWINRdL@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L71_MEMWINRdsL Lib "L71W32.DLL" Alias "_L71_MEMWINRdsL@20" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_MEMWINRdsW Lib "L71W32.DLL" Alias "_L71_MEMWINRdsW@20" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_MEMWINRdW Lib "L71W32.DLL" Alias "_L71_MEMWINRdW@12" (ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_MEMWINWrB Lib "L71W32.DLL" Alias "_L71_MEMWINWrB@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_MEMWINWrL Lib "L71W32.DLL" Alias "_L71_MEMWINWrL@16" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_MEMWINWrsL Lib "L71W32.DLL" Alias "_L71_MEMWINWrsL@20" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_MEMWINWrsW Lib "L71W32.DLL" Alias "_L71_MEMWINWrsW@20" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_MEMWINWrW Lib "L71W32.DLL" Alias "_L71_MEMWINWrW@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal bustype As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_Mod Lib "L71W32.DLL" Alias "_L71_Mod@8" (ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
    Public Declare Function L71_ModeIsBC Lib "L71W32.DLL" Alias "_L71_ModeIsBC@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ModeIsMon Lib "L71W32.DLL" Alias "_L71_ModeIsMon@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ModeIsNotBC Lib "L71W32.DLL" Alias "_L71_ModeIsNotBC@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ModeIsNotMon Lib "L71W32.DLL" Alias "_L71_ModeIsNotMon@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ModeIsNotRT Lib "L71W32.DLL" Alias "_L71_ModeIsNotRT@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ModeIsNotSerial Lib "L71W32.DLL" Alias "_L71_ModeIsNotSerial@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ModeIsRT Lib "L71W32.DLL" Alias "_L71_ModeIsRT@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ModeIsSerial Lib "L71W32.DLL" Alias "_L71_ModeIsSerial@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_ModeRd Lib "L71W32.DLL" Alias "_L71_ModeRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_ModeWr Lib "L71W32.DLL" Alias "_L71_ModeWr@8" (ByVal mode As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_MonBlkRd Lib "L71W32.DLL" Alias "_L71_MonBlkRd@16" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MonBlkRdEx Lib "L71W32.DLL" Alias "_L71_MonBlkRdEx@20" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal maxblkcnt As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MonClear Lib "L71W32.DLL" Alias "_L71_MonClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonConfig Lib "L71W32.DLL" Alias "_L71_MonConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonConfigEx Lib "L71W32.DLL" Alias "_L71_MonConfigEx@16" (ByVal configval As UInt32, ByVal moncount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonConfigExx Lib "L71W32.DLL" Alias "_L71_MonConfigExx@20" (ByVal configval As UInt32, ByVal seqaddr As UInt32, ByVal moncount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonFilterSA Lib "L71W32.DLL" Alias "_L71_MonFilterSA@24" (ByVal taval As Int32, ByVal rcvsamask As UInt32, ByVal xmtsamask As UInt32, ByVal rcvmcmask As UInt32, ByVal xmtmcmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonFilterSAEx Lib "L71W32.DLL" Alias "_L71_MonFilterSAEx@24" (ByVal taval As Int32, ByVal rcvsamask As UInt32, ByVal xmtsamask As UInt32, ByVal rcvmcmask As UInt32, ByVal xmtmcmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonFilterTA Lib "L71W32.DLL" Alias "_L71_MonFilterTA@8" (ByVal tamask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonIsRunning Lib "L71W32.DLL" Alias "_L71_MonIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonRd Lib "L71W32.DLL" Alias "_L71_MonRd@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_MonRdEx Lib "L71W32.DLL" Alias "_L71_MonRdEx@12" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_MonResume Lib "L71W32.DLL" Alias "_L71_MonResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonStart Lib "L71W32.DLL" Alias "_L71_MonStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonStatus Lib "L71W32.DLL" Alias "_L71_MonStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MonStop Lib "L71W32.DLL" Alias "_L71_MonStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MsgBlockRd Lib "L71W32.DLL" Alias "_L71_MsgBlockRd@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MsgBlockWr Lib "L71W32.DLL" Alias "_L71_MsgBlockWr@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MsgCheck Lib "L71W32.DLL" Alias "_L71_MsgCheck@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_MsgCommRd Lib "L71W32.DLL" Alias "_L71_MsgCommRd@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MsgCommWr Lib "L71W32.DLL" Alias "_L71_MsgCommWr@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MsgConfig Lib "L71W32.DLL" Alias "_L71_MsgConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MsgConfigEx Lib "L71W32.DLL" Alias "_L71_MsgConfigEx@12" (ByVal configval As UInt32, ByVal cwd As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MsgCWD1Rd Lib "L71W32.DLL" Alias "_L71_MsgCWD1Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_MsgCWD1Wr Lib "L71W32.DLL" Alias "_L71_MsgCWD1Wr@12" (ByVal cwd1 As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_MsgCWD2Rd Lib "L71W32.DLL" Alias "_L71_MsgCWD2Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_MsgCWD2Wr Lib "L71W32.DLL" Alias "_L71_MsgCWD2Wr@12" (ByVal cwd2 As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L71_MsgDataRd Lib "L71W32.DLL" Alias "_L71_MsgDataRd@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L71_MsgDataWr Lib "L71W32.DLL" Alias "_L71_MsgDataWr@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_MsgErrorRd Lib "L71W32.DLL" Alias "_L71_MsgErrorRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_MsgErrorWr Lib "L71W32.DLL" Alias "_L71_MsgErrorWr@12" (ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_MsgFieldRd Lib "L71W32.DLL" Alias "_L71_MsgFieldRd@12" (ByVal fieldtype As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MsgFieldWr Lib "L71W32.DLL" Alias "_L71_MsgFieldWr@16" (ByVal fieldval As UInt32, ByVal fieldtype As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MsgFlagRd Lib "L71W32.DLL" Alias "_L71_MsgFlagRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_MsgFlagWr Lib "L71W32.DLL" Alias "_L71_MsgFlagWr@12" (ByVal msgflag As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_MsgIsAccessed Lib "L71W32.DLL" Alias "_L71_MsgIsAccessed@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_MsgOptRd Lib "L71W32.DLL" Alias "_L71_MsgOptRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_MsgOptWr Lib "L71W32.DLL" Alias "_L71_MsgOptWr@12" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_MsgReset Lib "L71W32.DLL" Alias "_L71_MsgReset@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_MsgSWD1Rd Lib "L71W32.DLL" Alias "_L71_MsgSWD1Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_MsgSWD2Rd Lib "L71W32.DLL" Alias "_L71_MsgSWD2Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_Mul Lib "L71W32.DLL" Alias "_L71_Mul@8" (ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
    Public Declare Function L71_PortRd Lib "L71W32.DLL" Alias "_L71_PortRd@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_PortWr Lib "L71W32.DLL" Alias "_L71_PortWr@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_ProgRdW Lib "L71W32.DLL" Alias "_L71_ProgRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_ProgWrW Lib "L71W32.DLL" Alias "_L71_ProgWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L71_RAMFill Lib "L71W32.DLL" Alias "_L71_RAMFill@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_RAMIsDPM Lib "L71W32.DLL" Alias "_L71_RAMIsDPM@4" (ByVal addrval As UInt32) As Int32
    Public Declare Function L71_RAMRdB Lib "L71W32.DLL" Alias "_L71_RAMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_RAMRdL Lib "L71W32.DLL" Alias "_L71_RAMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub L71_RAMRdsL Lib "L71W32.DLL" Alias "_L71_RAMRdsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_RAMRdsW Lib "L71W32.DLL" Alias "_L71_RAMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function L71_RAMRdW Lib "L71W32.DLL" Alias "_L71_RAMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_RAMWipe Lib "L71W32.DLL" Alias "_L71_RAMWipe@4" (ByVal handleval As UInt32)
    Public Declare Sub L71_RAMWipeEx Lib "L71W32.DLL" Alias "_L71_RAMWipeEx@8" (ByVal value As UInt16, ByVal handleval As UInt32)
    Public Declare Sub L71_RAMWrB Lib "L71W32.DLL" Alias "_L71_RAMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L71_RAMWrL Lib "L71W32.DLL" Alias "_L71_RAMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub L71_RAMWrsL Lib "L71W32.DLL" Alias "_L71_RAMWrsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_RAMWrsW Lib "L71W32.DLL" Alias "_L71_RAMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Sub L71_RAMWrW Lib "L71W32.DLL" Alias "_L71_RAMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_RcvAlloc Lib "L71W32.DLL" Alias "_L71_RcvAlloc@12" (ByVal configval As UInt32, ByVal framenum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_RcvConfigExx Lib "L71W32.DLL" Alias "_L71_RcvConfigExx@28" (ByVal rtconfigval As UInt32, ByVal intfreq As UInt16, ByVal monconfigval As UInt32, ByVal intconfigval As UInt32, ByVal inttotal As UInt16, ByVal msgconfigval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_RcvCountRd Lib "L71W32.DLL" Alias "_L71_RcvCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_RcvCountWr Lib "L71W32.DLL" Alias "_L71_RcvCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_RcvDataCountRd Lib "L71W32.DLL" Alias "_L71_RcvDataCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_RcvDataCountWr Lib "L71W32.DLL" Alias "_L71_RcvDataCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_RcvIndex Lib "L71W32.DLL" Alias "_L71_RcvIndex@8" (ByVal framenum As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_RTConfig Lib "L71W32.DLL" Alias "_L71_RTConfig@16" (ByVal configval As UInt32, ByVal taval As Int32, ByVal intfreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_RTConfigEx Lib "L71W32.DLL" Alias "_L71_RTConfigEx@16" (ByVal configval As UInt32, ByVal taval As Int32, ByVal intfreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_RTConfigExx Lib "L71W32.DLL" Alias "_L71_RTConfigExx@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_RTConfigMsg Lib "L71W32.DLL" Alias "_L71_RTConfigMsg@12" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_RTCreateList Lib "L71W32.DLL" Alias "_L71_RTCreateList@32" (ByVal listconfigval As UInt32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_RTCreateListEx Lib "L71W32.DLL" Alias "_L71_RTCreateListEx@36" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_RTCreateListExx Lib "L71W32.DLL" Alias "_L71_RTCreateListExx@36" (ByVal listconfigval As UInt32, ByVal skipval As Int32, ByVal count As Int32, ByVal msgconfigval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_RTCreateMsg Lib "L71W32.DLL" Alias "_L71_RTCreateMsg@24" (ByVal configval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_RTGetMsg Lib "L71W32.DLL" Alias "_L71_RTGetMsg@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_RTReset Lib "L71W32.DLL" Alias "_L71_RTReset@8" (ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_RTStatus Lib "L71W32.DLL" Alias "_L71_RTStatus@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_RTSWDRd Lib "L71W32.DLL" Alias "_L71_RTSWDRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_RTSWDWr Lib "L71W32.DLL" Alias "_L71_RTSWDWr@12" (ByVal swdval As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SchedBuild Lib "L71W32.DLL" Alias "_L71_SchedBuild@16" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef freq As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SchedBuildEx Lib "L71W32.DLL" Alias "_L71_SchedBuildEx@28" (ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef freq As Int32, ByRef period As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SchedBuildExx Lib "L71W32.DLL" Alias "_L71_SchedBuildExx@28" (ByVal frametime As UInt32, ByVal nummsgs As Int32, ByRef msgaddr As UInt32, ByRef period As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SchedCalc Lib "L71W32.DLL" Alias "_L71_SchedCalc@8" (ByRef msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Sub L71_SchedDisplay Lib "L71W32.DLL" Alias "_L71_SchedDisplay@8" (ByVal nummsgs As UInt32, ByRef count As UInt32)
    Public Declare Sub L71_SchedHook Lib "L71W32.DLL" Alias "_L71_SchedHook@8" (ByVal index As Int32, ByVal ptr As IntPtr)
    Public Declare Function L71_SchedInsEnd Lib "L71W32.DLL" Alias "_L71_SchedInsEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SchedInsMsg Lib "L71W32.DLL" Alias "_L71_SchedInsMsg@12" (ByVal index As UInt32, ByRef msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SchedInsStart Lib "L71W32.DLL" Alias "_L71_SchedInsStart@12" (ByVal frametime As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SchedMaxval Lib "L71W32.DLL" Alias "_L71_SchedMaxval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
    Public Declare Function L71_SchedMinval Lib "L71W32.DLL" Alias "_L71_SchedMinval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
    Public Declare Sub L71_SchedPrint Lib "L71W32.DLL" Alias "" (ByVal ParamArray list() As String)
    Public Declare Function L71_SEEPokeW Lib "L71W32.DLL" Alias "_L71_SEEPokeW@12" (ByVal value As Int32, ByVal numbits As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SEERdBit Lib "L71W32.DLL" Alias "_L71_SEERdBit@12" (ByRef valueptr As Int32, ByVal bitnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SEERdL Lib "L71W32.DLL" Alias "_L71_SEERdL@12" (ByRef valueptr As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SEERdW Lib "L71W32.DLL" Alias "_L71_SEERdW@12" (ByRef valueptr As Int32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SEEWrBit Lib "L71W32.DLL" Alias "_L71_SEEWrBit@12" (ByVal value As Int32, ByVal bitnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SEEWrL Lib "L71W32.DLL" Alias "_L71_SEEWrL@12" (ByVal value As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SEEWrW Lib "L71W32.DLL" Alias "_L71_SEEWrW@12" (ByVal value As Int32, ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_SEMMRdW Lib "L71W32.DLL" Alias "_L71_SEMMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_SEMMWrW Lib "L71W32.DLL" Alias "_L71_SEMMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_SEMRdW Lib "L71W32.DLL" Alias "_L71_SEMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_SEMWrW Lib "L71W32.DLL" Alias "_L71_SEMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function L71_Shl Lib "L71W32.DLL" Alias "_L71_Shl@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function L71_Shr Lib "L71W32.DLL" Alias "_L71_Shr@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Sub L71_TimerClear Lib "L71W32.DLL" Alias "_L71_TimerClear@4" (ByVal handleval As UInt32)
    Public Declare Function L71_TimerRd Lib "L71W32.DLL" Alias "_L71_TimerRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_TimerResolution Lib "L71W32.DLL" Alias "_L71_TimerResolution@8" (ByVal timerresol As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_TimerResolutionEx Lib "L71W32.DLL" Alias "_L71_TimerResolutionEx@8" (ByVal timershift As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function L71_ValAsciiCmpi Lib "L71W32.DLL" Alias "_L71_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Int32
    Public Declare Function L71_ValAsciiCpy Lib "L71W32.DLL" Alias "_L71_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Int32) As UInt32
    Public Declare Sub L71_ValAsciiTrimLead Lib "L71W32.DLL" Alias "_L71_ValAsciiTrimLead@4" (ByRef buf As String)
    Public Declare Sub L71_ValAsciiTrimTrail Lib "L71W32.DLL" Alias "_L71_ValAsciiTrimTrail@4" (ByRef buf As String)
    Public Declare Function L71_ValFromAscii Lib "L71W32.DLL" Alias "_L71_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
    Public Declare Function L71_ValGetBits Lib "L71W32.DLL" Alias "_L71_ValGetBits@12" (ByVal oldvalue As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function L71_ValIncAscii Lib "L71W32.DLL" Alias "_L71_ValIncAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function L71_ValInccAscii Lib "L71W32.DLL" Alias "_L71_ValInccAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function L71_ValIsLower Lib "L71W32.DLL" Alias "_L71_ValIsLower@4" (ByVal value As Int32) As Int32
    Public Declare Function L71_ValLenAscii Lib "L71W32.DLL" Alias "_L71_ValLenAscii@8" (ByVal numbits As Int32, ByVal radixval As Int32) As Int32
    Public Declare Function L71_ValPackCWD Lib "L71W32.DLL" Alias "_L71_ValPackCWD@16" (ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal wcval As Int32) As UInt16
    Public Declare Function L71_ValPackRTCWD Lib "L71W32.DLL" Alias "_L71_ValPackRTCWD@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal count As Int32) As UInt16
    Public Declare Function L71_ValPutBits Lib "L71W32.DLL" Alias "_L71_ValPutBits@16" (ByVal oldvalue As UInt16, ByVal newfld As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function L71_ValToAscii Lib "L71W32.DLL" Alias "_L71_ValToAscii@16" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
    Public Declare Function L71_ValToUpper Lib "L71W32.DLL" Alias "_L71_ValToUpper@4" (ByVal value As Int32) As Int32
    Public Declare Sub L71_ValUnpackCWD Lib "L71W32.DLL" Alias "_L71_ValUnpackCWD@20" (ByVal cwdval As UInt16, ByRef taval As Int32, ByRef trflag As Int32, ByRef saval As Int32, ByRef wcval As Int32)
    Public Declare Sub L71_ValUnpackRTCWD Lib "L71W32.DLL" Alias "_L71_ValUnpackRTCWD@28" (ByVal cwd As UInt16, ByRef bcastflag As Int32, ByRef mcflag As Int32, ByRef taval As Int32, ByRef trflag As Int32, ByRef saval As Int32, ByRef count As Int32)
    Public Declare Function L71_XmtAlloc Lib "L71W32.DLL" Alias "_L71_XmtAlloc@12" (ByVal configval As UInt32, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_XmtConfigExxx Lib "L71W32.DLL" Alias "_L71_XmtConfigExxx@24" (ByVal bcconfigval As UInt32, ByVal msgconfigval As UInt32, ByVal framefreq As UInt16, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_XmtCountRd Lib "L71W32.DLL" Alias "_L71_XmtCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_XmtCountWr Lib "L71W32.DLL" Alias "_L71_XmtCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_XmtDataCountRd Lib "L71W32.DLL" Alias "_L71_XmtDataCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_XmtDataCountWr Lib "L71W32.DLL" Alias "_L71_XmtDataCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_XmtFreq Lib "L71W32.DLL" Alias "_L71_XmtFreq@8" (ByVal framefreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_XmtFreqEx Lib "L71W32.DLL" Alias "_L71_XmtFreqEx@16" (ByVal framefreq As UInt16, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_XmtFreqExx Lib "L71W32.DLL" Alias "_L71_XmtFreqExx@36" (ByVal framefreq As UInt16, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal bcconfigval As UInt32, ByVal bctotal As UInt16, ByVal intconfigval As UInt32, ByVal inttotal As UInt16, ByVal msgconfigval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_XmtIndex Lib "L71W32.DLL" Alias "_L71_XmtIndex@8" (ByVal framenum As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function L71_XmtNumberRd Lib "L71W32.DLL" Alias "_L71_XmtNumberRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_XmtNumberWr Lib "L71W32.DLL" Alias "_L71_XmtNumberWr@8" (ByVal brdnum As UInt16, ByVal handleval As UInt32)
    Public Declare Function L71_XmtPeriod Lib "L71W32.DLL" Alias "_L71_XmtPeriod@8" (ByVal frameperiod As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_XmtPeriodEx Lib "L71W32.DLL" Alias "_L71_XmtPeriodEx@16" (ByVal frameperiod As UInt32, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_XmtPeriodExx Lib "L71W32.DLL" Alias "_L71_XmtPeriodExx@36" (ByVal frameperiod As UInt32, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal bcconfigval As UInt32, ByVal bctotal As UInt16, ByVal intconfigval As UInt32, ByVal inttotal As UInt16, ByVal msgconfigval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function L71_XmtSizeRd Lib "L71W32.DLL" Alias "_L71_XmtSizeRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub L71_XmtSizeWr Lib "L71W32.DLL" Alias "_L71_XmtSizeWr@8" (ByVal mode As UInt16, ByVal handleval As UInt32)

    '/**
    '*
    '*  Transmitter configuration options
    '*
    '**/

    Public Const XMTCFG_DEFAULT As UInt32 = &H0L '//Select all default settings
    Public Const XMTCFG_BUSA As UInt32 = &H0L    '//Message will be transmitted on bus A (default)
    Public Const XMTCFG_BUSB As UInt32 = &H4L    '//Message will be transmitted on bus B
    Public Const XMTCFG_NOSWAP As UInt32 = &H0L  '//Disable bit swapping (default)
    Public Const XMTCFG_SWAP As UInt32 = &H4000L    '//Enable bit swapping
    Public Const XMTCFG_MODEL As UInt32 = &H0L   '//Xmt messages are created depending upon model (default)
    Public Const XMTCFG_RAM As UInt32 = &H100000L '//Xmt messages are created in static RAM
    Public Const XMTCFG_DPRAM As UInt32 = &H200000L   '//Xmt messages are created in dual-port RAM

    '/**
    '*
    '*  Receiver configuration options
    '*
    '**/

    Public Const RCVCFG_DEFAULT As UInt32 = &H0L '//Select all default settings
    Public Const RCVCFG_BUSA As UInt32 = &H0L    '//Respond to channel A (default)
    Public Const RCVCFG_BUSB As UInt32 = &H10000L    '//Respond to channel B
    Public Const RCVCFG_NOSWAP As UInt32 = &H0L  '//Disable bit swapping (default)
    Public Const RCVCFG_SWAP As UInt32 = &H8000L    '//Enable bit swapping
    Public Const RCVCFG_WORDSYNC As UInt32 = &H0L    '//Sync on words (default)
    Public Const RCVCFG_BITSYNC As UInt32 = &H80000L '//Sync on each bit
    Public Const RCVCFG_MODEL As UInt32 = &H0L   '//Xmt messages are created depending upon model (default)
    Public Const RCVCFG_RAM As UInt32 = &H100000L '//Xmt messages are created in static RAM
    Public Const RCVCFG_DPRAM As UInt32 = &H200000L   '//Xmt messages are created in dual-port RAM

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
    Public Const BCCFG_NOSWAP As UInt32 = &H0L   '//Disable bit swapping (default)
    Public Const BCCFG_SWAP As UInt32 = &H4000L '//Enable bit swapping
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
    Public Const MONCFG_DELTA As UInt32 = &H20L   '//Enable monitor in delta mode
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
    Public Const RTCFG_NOSWAP As UInt32 = &H0L   '//Disable bit swapping (default)
    Public Const RTCFG_SWAP As UInt32 = &H8000L '//Enable bit swapping
    Public Const RTCFG_WORDSYNC As UInt32 = &H0L '//Sync on words (default)
    Public Const RTCFG_BITSYNC As UInt32 = &H80000L  '//Sync on each bit
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
    Public Const RTCFG_WIPE123 As UInt32 = &H10000000L  '//Initialize data with incrementing values
    Public Const RTCFG_WIPECWD As UInt32 = &H20000000L  '//Initialize data with command word
    Public Const RTCFG_MODEL As UInt32 = &H0L    '//RT messages are created in static RAM or dual-port RAM depending upon board model (default)
    Public Const RTCFG_RAM As UInt32 = &H100000L  '//RT messages are created in static RAM
    Public Const RTCFG_DPRAM As UInt32 = &H200000L    '//RT messages are created in dual-port RAM

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

    Public Const INFOTYPE_PLAT As UInt16 = &H1   '//Returns the L71 platform type
    Public Const INFOTYPE_PROD As UInt16 = &H2   '//Returns the L71 product type
    Public Const INFOTYPE_DASH As UInt16 = &H3   '//Returns the L71 dash number
    Public Const INFOTYPE_VERSION As UInt16 = &H4    '//Returns the L71 version number
    Public Const INFOTYPE_DATE As UInt16 = &H5   '//Returns the L71 version date
    Public Const INFOTYPE_TRANSMIT As UInt16 = &H6   '//Returns whether the L71 has a transmitter
    Public Const INFOTYPE_RECEIVE As UInt16 = &H7    '//Returns whether the L71 has a receiver
    Public Const INFOTYPE_MODEL As UInt16 = &H8  '//Returns the L71 model number
    Public Const INFOTYPE_MAXCOUNT As UInt16 = &H9   '//Returns the number of terminals the L71 can simulate
    Public Const INFOTYPE_MULTIMODE As UInt16 = &HA  '//Returns whether L71 can simulate multi-modes
    Public Const INFOTYPE_ERRORGEN As UInt16 = &HB   '//Returns whether L71 can generate errors
    Public Const INFOTYPE_CONCURMON As UInt16 = &HC  '//Returns whether L71 has a concurrent monitor
    Public Const INFOTYPE_MONFILTER As UInt16 = &HD  '//Returns whether L71 has a monitor filter
    Public Const INFOTYPE_USERCODE As UInt16 = &HE   '//Returns whether L71 handles user code
    Public Const INFOTYPE_LISTBUF As UInt16 = &HF    '//Returns whether L71 handles list buffering
    Public Const INFOTYPE_MONFAST As UInt16 = &H10    '//Returns whether L71 has a fast monitor
    Public Const INFOTYPE_MONDMA As UInt16 = &H11 '//Returns whether L71 has a dma monitor
    Public Const INFOTYPE_MONBRAKE As UInt16 = &H12   '//Returns whether L71 has a monitor brake
    Public Const INFOTYPE_DUAL As UInt16 = &H13   '//Returns whether the L71 has dual xmt/rcv capability
    Public Const INFOTYPE_BITSYNC As UInt16 = &H14    '//Returns whether the L71 has bit sync capability

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
    '*  Bit fields of the message error flag.
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
    '*  L71 IFGA Registers
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
    Public Const EREG_CTRLE As UInt16 = &H81  '//Encoder control register
    Public Const EREG_VALE As UInt16 = &H82   '//Encoder value register
    Public Const EREG_CFGINT As UInt16 = &H83 '//Interrupt configuration register
    Public Const EREG_CFG As UInt16 = &H84    '//Configuration register
    Public Const EREG_VALD As UInt16 = &H85   '//Encoder value register (RD)
    Public Const EREG_FT As UInt16 = &H86 '//Frame time register
    Public Const EREG_ID As UInt16 = &H87 '//Identification register (RD)
    Public Const EREG_STATCLR As UInt16 = &H8E    '//Status clear register (WR)
    Public Const EREG_RST As UInt16 = &H8F    '//Reset register (WR)

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

    '/**
    '*
    '*  Timer resolutions.
    '*
    '**/

    Public Const TIMERRESOL_1US As Int16 = 1    '//1us timer resolution, 1:11:34
    Public Const TIMERRESOL_16US As Int16 = 2   '//16us timer resolution, 19:05:19 range
    Public Const TIMERRESOL_1024US As Int16 = 3 '//1024us timer resolution, 50 day range

    Public Const MONRD_MAX_COUNT As Int16 = 109

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
    Public Const ERR_NOCARD As Int16 = -13  '//CardOpen() could not find a L71 card at the specified address
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
