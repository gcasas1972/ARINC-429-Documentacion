Imports System
Imports System.Runtime.InteropServices

Module P71W32VB

    '/**
    '*
    '*  PC708-1 WIN32 DRIVER  Version 1.3  (07/14/2000)
    '*  Copyright (c) 1998-2000
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   P71W32NET.VB -- 32-bit
    '*                      PC708-1 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  PC708-1 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the PC708-1 Driver.
    '*
    '**/

    Public Declare Function PC708_CardClose Lib "P71W32.DLL" Alias "_PC708_CardClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardOpen Lib "P71W32.DLL" Alias "_PC708_CardOpen@16" (ByVal memval As UInt32, ByVal ioval As UInt16, ByVal irqval As UInt16, ByVal drqval As UInt16) As UInt32
    Public Declare Sub PC708_CardReset Lib "P71W32.DLL" Alias "_PC708_CardReset@4" (ByVal handleval As UInt32)
    Public Declare Function PC708_CardStart Lib "P71W32.DLL" Alias "_PC708_CardStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardStop Lib "P71W32.DLL" Alias "_PC708_CardStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_IntInstall Lib "P71W32.DLL" Alias "_PC708_IntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_IntRd Lib "P71W32.DLL" Alias "_PC708_IntRd@12" (ByRef typevalval As UInt16, ByRef infoval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_IntStatus Lib "P71W32.DLL" Alias "_PC708_IntStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_IntUninstall Lib "P71W32.DLL" Alias "_PC708_IntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_RcvConfig Lib "P71W32.DLL" Alias "_PC708_RcvConfig@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_RcvConfigEx Lib "P71W32.DLL" Alias "_PC708_RcvConfigEx@12" (ByVal rtconfigval As UInt32, ByVal intfreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_RcvMonBlkRd Lib "P71W32.DLL" Alias "_PC708_RcvMonBlkRd@16" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_RcvMonBlkRdEx Lib "P71W32.DLL" Alias "_PC708_RcvMonBlkRdEx@20" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal maxblkcnt As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_RcvMonRd Lib "P71W32.DLL" Alias "_PC708_RcvMonRd@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_RcvMonRdEx Lib "P71W32.DLL" Alias "_PC708_RcvMonRdEx@12" (ByRef buf As UInt16, ByVal index As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_RcvMonStatus Lib "P71W32.DLL" Alias "_PC708_RcvMonStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_RcvRd Lib "P71W32.DLL" Alias "_PC708_RcvRd@8" (ByRef buf As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_XmtConfig Lib "P71W32.DLL" Alias "_PC708_XmtConfig@8" (ByVal framefreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_XmtConfigEx Lib "P71W32.DLL" Alias "_PC708_XmtConfigEx@16" (ByVal framefreq As UInt16, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_XmtConfigExx Lib "P71W32.DLL" Alias "_PC708_XmtConfigExx@20" (ByVal xmtconfigval As UInt32, ByVal framefreq As UInt16, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_XmtRd Lib "P71W32.DLL" Alias "_PC708_XmtRd@12" (ByRef buf As UInt16, ByVal framenum As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_XmtStatus Lib "P71W32.DLL" Alias "_PC708_XmtStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_XmtWr Lib "P71W32.DLL" Alias "_PC708_XmtWr@12" (ByRef buf As UInt16, ByVal framenum As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_FieldGetAngle Lib "P71W32.DLL" Alias "_PC708_FieldGetAngle@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldGetAngleFl Lib "P71W32.DLL" Alias "_PC708_FieldGetAngleFl@4" (ByRef buf As UInt16) As Single
    Public Declare Function PC708_FieldGetControlAccept Lib "P71W32.DLL" Alias "_PC708_FieldGetControlAccept@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldGetData Lib "P71W32.DLL" Alias "_PC708_FieldGetData@8" (ByVal binnum As Int32, ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldGetDataAccept Lib "P71W32.DLL" Alias "_PC708_FieldGetDataAccept@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldGetFaults Lib "P71W32.DLL" Alias "_PC708_FieldGetFaults@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldGetGain Lib "P71W32.DLL" Alias "_PC708_FieldGetGain@4" (ByRef buf As UInt16) As Int32
    Public Declare Function PC708_FieldGetLabel Lib "P71W32.DLL" Alias "_PC708_FieldGetLabel@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldGetMode Lib "P71W32.DLL" Alias "_PC708_FieldGetMode@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldGetRange Lib "P71W32.DLL" Alias "_PC708_FieldGetRange@4" (ByRef buf As UInt16) As Int32
    Public Declare Function PC708_FieldGetTilt Lib "P71W32.DLL" Alias "_PC708_FieldGetTilt@4" (ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldGetTiltFl Lib "P71W32.DLL" Alias "_PC708_FieldGetTiltFl@4" (ByRef buf As UInt16) As Single
    Public Declare Function PC708_FieldPutAngle Lib "P71W32.DLL" Alias "_PC708_FieldPutAngle@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldPutAngleFl Lib "P71W32.DLL" Alias "_PC708_FieldPutAngleFl@8" (ByVal angle As Single, ByRef buf As UInt16) As Single
    Public Declare Function PC708_FieldPutControlAccept Lib "P71W32.DLL" Alias "_PC708_FieldPutControlAccept@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldPutData Lib "P71W32.DLL" Alias "_PC708_FieldPutData@12" (ByVal value As UInt16, ByVal binnum As Int32, ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldPutDataAccept Lib "P71W32.DLL" Alias "_PC708_FieldPutDataAccept@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldPutFaults Lib "P71W32.DLL" Alias "_PC708_FieldPutFaults@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldPutGain Lib "P71W32.DLL" Alias "_PC708_FieldPutGain@8" (ByVal gain As Int32, ByRef buf As UInt16) As Int32
    Public Declare Function PC708_FieldPutLabel Lib "P71W32.DLL" Alias "_PC708_FieldPutLabel@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldPutMode Lib "P71W32.DLL" Alias "_PC708_FieldPutMode@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldPutRange Lib "P71W32.DLL" Alias "_PC708_FieldPutRange@8" (ByVal range As Int32, ByRef buf As UInt16) As Int32
    Public Declare Function PC708_FieldPutTilt Lib "P71W32.DLL" Alias "_PC708_FieldPutTilt@8" (ByVal value As UInt16, ByRef buf As UInt16) As UInt16
    Public Declare Function PC708_FieldPutTiltFl Lib "P71W32.DLL" Alias "_PC708_FieldPutTiltFl@8" (ByVal tilt As Single, ByRef buf As UInt16) As Single
    Public Declare Function PC708_AddrDSP Lib "P71W32.DLL" Alias "_PC708_AddrDSP@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function PC708_AddrHost Lib "P71W32.DLL" Alias "_PC708_AddrHost@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function PC708_BCConfig Lib "P71W32.DLL" Alias "_PC708_BCConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCConfigEx Lib "P71W32.DLL" Alias "_PC708_BCConfigEx@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCConfigMsg Lib "P71W32.DLL" Alias "_PC708_BCConfigMsg@12" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_BCCreateMsg Lib "P71W32.DLL" Alias "_PC708_BCCreateMsg@20" (ByVal configval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_BCSchedAgain Lib "P71W32.DLL" Alias "_PC708_BCSchedAgain@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedBranch Lib "P71W32.DLL" Alias "_PC708_BCSchedBranch@12" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedBranchDin0 Lib "P71W32.DLL" Alias "_PC708_BCSchedBranchDin0@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedBranchDin1 Lib "P71W32.DLL" Alias "_PC708_BCSchedBranchDin1@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedBranchEx Lib "P71W32.DLL" Alias "_PC708_BCSchedBranchEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedBuild Lib "P71W32.DLL" Alias "_PC708_BCSchedBuild@16" (ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef freq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedCall Lib "P71W32.DLL" Alias "_PC708_BCSchedCall@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedCallCond Lib "P71W32.DLL" Alias "_PC708_BCSchedCallCond@12" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedCallCondEx Lib "P71W32.DLL" Alias "_PC708_BCSchedCallCondEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedEntry Lib "P71W32.DLL" Alias "_PC708_BCSchedEntry@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedFrame Lib "P71W32.DLL" Alias "_PC708_BCSchedFrame@8" (ByVal timeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedFrameEnd Lib "P71W32.DLL" Alias "_PC708_BCSchedFrameEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedFrameStart Lib "P71W32.DLL" Alias "_PC708_BCSchedFrameStart@8" (ByVal timeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedGap Lib "P71W32.DLL" Alias "_PC708_BCSchedGap@8" (ByVal gapval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedGoto Lib "P71W32.DLL" Alias "_PC708_BCSchedGoto@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedHalt Lib "P71W32.DLL" Alias "_PC708_BCSchedHalt@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedInt Lib "P71W32.DLL" Alias "_PC708_BCSchedInt@8" (ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedIntCond Lib "P71W32.DLL" Alias "_PC708_BCSchedIntCond@12" (ByVal condition As UInt16, ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedIntCondEx Lib "P71W32.DLL" Alias "_PC708_BCSchedIntCondEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedMsg Lib "P71W32.DLL" Alias "_PC708_BCSchedMsg@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedNop Lib "P71W32.DLL" Alias "_PC708_BCSchedNop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedPause Lib "P71W32.DLL" Alias "_PC708_BCSchedPause@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedPulse Lib "P71W32.DLL" Alias "_PC708_BCSchedPulse@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedPulse0 Lib "P71W32.DLL" Alias "_PC708_BCSchedPulse0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedPulse1 Lib "P71W32.DLL" Alias "_PC708_BCSchedPulse1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedRestart Lib "P71W32.DLL" Alias "_PC708_BCSchedRestart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedRetry Lib "P71W32.DLL" Alias "_PC708_BCSchedRetry@12" (ByVal condition As UInt16, ByVal retries As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedRetryEx Lib "P71W32.DLL" Alias "_PC708_BCSchedRetryEx@24" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal retryflag As UInt16, ByVal retries As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedReturn Lib "P71W32.DLL" Alias "_PC708_BCSchedReturn@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSchedUser Lib "P71W32.DLL" Alias "_PC708_BCSchedUser@8" (ByVal useraddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSetEntry Lib "P71W32.DLL" Alias "_PC708_BCSetEntry@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BCSetTimeout Lib "P71W32.DLL" Alias "_PC708_BCSetTimeout@8" (ByVal timeoutval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BlkAddr Lib "P71W32.DLL" Alias "_PC708_BlkAddr@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_BlkOptRd Lib "P71W32.DLL" Alias "_PC708_BlkOptRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_BlkOptWr Lib "P71W32.DLL" Alias "_PC708_BlkOptWr@12" (ByVal rtopt As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BlkPtrRd Lib "P71W32.DLL" Alias "_PC708_BlkPtrRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub PC708_BlkPtrWr Lib "P71W32.DLL" Alias "_PC708_BlkPtrWr@12" (ByVal descaddr As UInt32, ByVal taval As Int32, ByVal handleval As UInt32)
    Public Declare Function PC708_BlkRd Lib "P71W32.DLL" Alias "_PC708_BlkRd@12" (ByRef block As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BlkReset Lib "P71W32.DLL" Alias "_PC708_BlkReset@8" (ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BlkSWDRd Lib "P71W32.DLL" Alias "_PC708_BlkSWDRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_BlkSWDWr Lib "P71W32.DLL" Alias "_PC708_BlkSWDWr@12" (ByVal swdval As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BlkWipe Lib "P71W32.DLL" Alias "_PC708_BlkWipe@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_BlkWr Lib "P71W32.DLL" Alias "_PC708_BlkWr@12" (ByRef block As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardBoot Lib "P71W32.DLL" Alias "_PC708_CardBoot@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardCloseAll Lib "P71W32.DLL" Alias "_PC708_CardCloseAll@0" () As Int32
    Public Declare Function PC708_CardConfig Lib "P71W32.DLL" Alias "_PC708_CardConfig@16" (ByVal enableflag As Int32, ByVal command As UInt16, ByVal taval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardGetInfo Lib "P71W32.DLL" Alias "_PC708_CardGetInfo@8" (ByVal infotype As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_CardGetInfoEx Lib "P71W32.DLL" Alias "_PC708_CardGetInfoEx@20" (ByRef bufmodel As UInt16, ByVal bufmodelcount As UInt16, ByRef buffeature As UInt16, ByVal buffeaturecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_CardInit Lib "P71W32.DLL" Alias "_PC708_CardInit@0" ()
    Public Declare Function PC708_CardIsRunning Lib "P71W32.DLL" Alias "_PC708_CardIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardNop Lib "P71W32.DLL" Alias "_PC708_CardNop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardOpenEx Lib "P71W32.DLL" Alias "_PC708_CardOpenEx@20" (ByRef cardname As String, ByVal memval As UInt32, ByVal ioval As UInt16, ByVal irqval As UInt16, ByVal drqval As UInt16) As UInt32
    Public Declare Function PC708_CardOpenExx Lib "P71W32.DLL" Alias "_PC708_CardOpenExx@28" (ByRef cardname As String, ByVal memval As UInt32, ByVal ioval As UInt16, ByVal irqval As UInt16, ByVal drqval As UInt16, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Sub PC708_CardResetEx Lib "P71W32.DLL" Alias "_PC708_CardResetEx@4" (ByVal handleval As UInt32)
    Public Declare Function PC708_CardResume Lib "P71W32.DLL" Alias "_PC708_CardResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardTest Lib "P71W32.DLL" Alias "_PC708_CardTest@8" (ByVal level As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardTest0 Lib "P71W32.DLL" Alias "_PC708_CardTest0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardTest1 Lib "P71W32.DLL" Alias "_PC708_CardTest1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CardTest2 Lib "P71W32.DLL" Alias "_PC708_CardTest2@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_CardTrigger Lib "P71W32.DLL" Alias "_PC708_CardTrigger@4" (ByVal handleval As UInt32)
    Public Declare Function PC708_CmdAddr Lib "P71W32.DLL" Alias "_PC708_CmdAddr@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_CmdAlloc Lib "P71W32.DLL" Alias "_PC708_CmdAlloc@8" (ByVal count As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_CmdBaseRd Lib "P71W32.DLL" Alias "_PC708_CmdBaseRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Sub PC708_CmdBaseWr Lib "P71W32.DLL" Alias "_PC708_CmdBaseWr@8" (ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function PC708_CmdClear Lib "P71W32.DLL" Alias "_PC708_CmdClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CmdCountRd Lib "P71W32.DLL" Alias "_PC708_CmdCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_CmdCountWr Lib "P71W32.DLL" Alias "_PC708_CmdCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_CmdCtrlRd Lib "P71W32.DLL" Alias "_PC708_CmdCtrlRd@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_CmdCtrlWr Lib "P71W32.DLL" Alias "_PC708_CmdCtrlWr@12" (ByVal ctrlval As UInt16, ByVal index As Int32, ByVal handleval As UInt32)
    Public Declare Function PC708_CmdCurrRd Lib "P71W32.DLL" Alias "_PC708_CmdCurrRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_CmdCurrWr Lib "P71W32.DLL" Alias "_PC708_CmdCurrWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub PC708_CmdInit Lib "P71W32.DLL" Alias "_PC708_CmdInit@8" (ByVal opcode As UInt16, ByRef block As UInt16)
    Public Declare Function PC708_CmdInsert Lib "P71W32.DLL" Alias "_PC708_CmdInsert@8" (ByRef block As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CmdMaxRd Lib "P71W32.DLL" Alias "_PC708_CmdMaxRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_CmdMaxWr Lib "P71W32.DLL" Alias "_PC708_CmdMaxWr@8" (ByVal count As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_CmdRd Lib "P71W32.DLL" Alias "_PC708_CmdRd@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CmdSkipWr Lib "P71W32.DLL" Alias "_PC708_CmdSkipWr@12" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_CmdStackClr Lib "P71W32.DLL" Alias "_PC708_CmdStackClr@4" (ByVal handleval As UInt32)
    Public Declare Function PC708_CmdStartRd Lib "P71W32.DLL" Alias "_PC708_CmdStartRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_CmdStartWr Lib "P71W32.DLL" Alias "_PC708_CmdStartWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_CmdTotalRd Lib "P71W32.DLL" Alias "_PC708_CmdTotalRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_CmdTotalWr Lib "P71W32.DLL" Alias "_PC708_CmdTotalWr@8" (ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function PC708_CmdWr Lib "P71W32.DLL" Alias "_PC708_CmdWr@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CommCall Lib "P71W32.DLL" Alias "_PC708_CommCall@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CommCheck Lib "P71W32.DLL" Alias "_PC708_CommCheck@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CommDisable Lib "P71W32.DLL" Alias "_PC708_CommDisable@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CommEnable Lib "P71W32.DLL" Alias "_PC708_CommEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CommRdL Lib "P71W32.DLL" Alias "_PC708_CommRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_CommRdsW Lib "P71W32.DLL" Alias "_PC708_CommRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_CommRdW Lib "P71W32.DLL" Alias "_PC708_CommRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_CommRun Lib "P71W32.DLL" Alias "_PC708_CommRun@20" (ByRef dataptr As UInt16, ByVal datacount As UInt16, ByRef codeptr As UInt16, ByVal codecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_CommWrL Lib "P71W32.DLL" Alias "_PC708_CommWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function PC708_CommWrsW Lib "P71W32.DLL" Alias "_PC708_CommWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_CommWrW Lib "P71W32.DLL" Alias "_PC708_CommWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub PC708_DARClr Lib "P71W32.DLL" Alias "_PC708_DARClr@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_DARGet Lib "P71W32.DLL" Alias "_PC708_DARGet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_DARRdL Lib "P71W32.DLL" Alias "_PC708_DARRdL@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_DARRdW Lib "P71W32.DLL" Alias "_PC708_DARRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_DARSet Lib "P71W32.DLL" Alias "_PC708_DARSet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub PC708_DARWrL Lib "P71W32.DLL" Alias "_PC708_DARWrL@12" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub PC708_DARWrW Lib "P71W32.DLL" Alias "_PC708_DARWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_Div Lib "P71W32.DLL" Alias "_PC708_Div@8" (ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
    Public Declare Function PC708_DllUsageCount Lib "P71W32.DLL" Alias "_PC708_DllUsageCount@0" () As Int32
    Public Declare Function PC708_DspBioRd Lib "P71W32.DLL" Alias "_PC708_DspBioRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_DspIntfClear Lib "P71W32.DLL" Alias "_PC708_DspIntfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_DspIntfRead Lib "P71W32.DLL" Alias "_PC708_DspIntfRead@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_DspIntmClear Lib "P71W32.DLL" Alias "_PC708_DspIntmClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_DspIntmSet Lib "P71W32.DLL" Alias "_PC708_DspIntmSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_DspXfClear Lib "P71W32.DLL" Alias "_PC708_DspXfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_DspXfSet Lib "P71W32.DLL" Alias "_PC708_DspXfSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ErrDesc Lib "P71W32.DLL" Alias "_PC708_ErrDesc@4" (ByVal errval As Int32) As UInt32
    Public Declare Function PC708_ErrDescStr Lib "P71W32.DLL" Alias "_PC708_ErrDescStr@4" (ByVal errval As Int32) As UInt32
    Public Declare Function PC708_ErrName Lib "P71W32.DLL" Alias "_PC708_ErrName@4" (ByVal errval As Int32) As UInt32
    Public Declare Function PC708_ErrorDefine Lib "P71W32.DLL" Alias "_PC708_ErrorDefine@12" (ByVal busb As Int32, ByVal intfreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ExtDinRd Lib "P71W32.DLL" Alias "_PC708_ExtDinRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_ExtDinWr Lib "P71W32.DLL" Alias "_PC708_ExtDinWr@8" (ByVal dinval As Int32, ByVal handleval As UInt32)
    Public Declare Function PC708_ExtDoutRd Lib "P71W32.DLL" Alias "_PC708_ExtDoutRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_ExtDoutWr Lib "P71W32.DLL" Alias "_PC708_ExtDoutWr@8" (ByVal doutval As Int32, ByVal handleval As UInt32)
    Public Declare Sub PC708_FileClose Lib "P71W32.DLL" Alias "_PC708_FileClose@4" (ByVal handle As IntPtr)
    Public Declare Function PC708_FileErr Lib "P71W32.DLL" Alias "_PC708_FileErr@0" () As Int32
    Public Declare Sub PC708_FileErrClr Lib "P71W32.DLL" Alias "_PC708_FileErrClr@0" ()
    Public Declare Sub PC708_FileErrSet Lib "P71W32.DLL" Alias "_PC708_FileErrSet@0" ()
    Public Declare Function PC708_FileOpenRead Lib "P71W32.DLL" Alias "_PC708_FileOpenRead@4" (ByRef filename As String) As UInt32
    Public Declare Function PC708_FileOpenWrite Lib "P71W32.DLL" Alias "_PC708_FileOpenWrite@4" (ByRef filename As String) As UInt32
    Public Declare Function PC708_FileRead Lib "P71W32.DLL" Alias "_PC708_FileRead@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function PC708_FileSeek Lib "P71W32.DLL" Alias "_PC708_FileSeek@8" (ByVal handle As IntPtr, ByVal offset As UInt32) As Int32
    Public Declare Function PC708_FileTell Lib "P71W32.DLL" Alias "_PC708_FileTell@4" (ByVal handle As IntPtr) As UInt32
    Public Declare Function PC708_FileWrite Lib "P71W32.DLL" Alias "_PC708_FileWrite@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function PC708_GetHigh Lib "P71W32.DLL" Alias "_PC708_GetHigh@4" (ByVal val As UInt32) As UInt16
    Public Declare Function PC708_GetLow Lib "P71W32.DLL" Alias "_PC708_GetLow@4" (ByVal val As UInt32) As UInt16
    Public Declare Function PC708_GlobalRdW Lib "P71W32.DLL" Alias "_PC708_GlobalRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_GlobalWrW Lib "P71W32.DLL" Alias "_PC708_GlobalWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_HandleDel Lib "P71W32.DLL" Alias "_PC708_HandleDel@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_HandleGet Lib "P71W32.DLL" Alias "_PC708_HandleGet@24" (ByRef memval As UInt32, ByRef sizval As UInt32, ByRef ioval As UInt32, ByRef irqval As UInt16, ByRef drqval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_HandleGetIo Lib "P71W32.DLL" Alias "_PC708_HandleGetIo@4" (ByVal ioval As UInt16) As UInt32
    Public Declare Function PC708_HandleGetMem Lib "P71W32.DLL" Alias "_PC708_HandleGetMem@4" (ByVal memval As UInt32) As UInt32
    Public Declare Function PC708_HandleIns Lib "P71W32.DLL" Alias "_PC708_HandleIns@28" (ByRef cardname As String, ByVal memval As UInt32, ByVal ioval As UInt16, ByVal irqval As UInt16, ByVal drqval As UInt16, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Function PC708_HandleOkay Lib "P71W32.DLL" Alias "_PC708_HandleOkay@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_HeapAlloc Lib "P71W32.DLL" Alias "_PC708_HeapAlloc@8" (ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_HeapAllocAll Lib "P71W32.DLL" Alias "_PC708_HeapAllocAll@8" (ByRef wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_HeapAllocEx Lib "P71W32.DLL" Alias "_PC708_HeapAllocEx@12" (ByVal configval As UInt16, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_HeapWipe Lib "P71W32.DLL" Alias "_PC708_HeapWipe@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_IndirectRd Lib "P71W32.DLL" Alias "_PC708_IndirectRd@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_IndirectWr Lib "P71W32.DLL" Alias "_PC708_IndirectWr@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_IntClear Lib "P71W32.DLL" Alias "_PC708_IntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_IntConfig Lib "P71W32.DLL" Alias "_PC708_IntConfig@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_IntDisable Lib "P71W32.DLL" Alias "_PC708_IntDisable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_IntEnable Lib "P71W32.DLL" Alias "_PC708_IntEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_IntEnableCond Lib "P71W32.DLL" Alias "_PC708_IntEnableCond@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_IntGet Lib "P71W32.DLL" Alias "_PC708_IntGet@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Sub PC708_IntReset Lib "P71W32.DLL" Alias "_PC708_IntReset@4" (ByVal handleval As UInt32)
    Public Declare Function PC708_IORdW Lib "P71W32.DLL" Alias "_PC708_IORdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_IOWINRdW Lib "P71W32.DLL" Alias "_PC708_IOWINRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_IOWINWrW Lib "P71W32.DLL" Alias "_PC708_IOWINWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub PC708_IOWrW Lib "P71W32.DLL" Alias "_PC708_IOWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_KernDev Lib "P71W32.DLL" Alias "_PC708_KernDev@8" (ByRef valueptr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernEnd Lib "P71W32.DLL" Alias "_PC708_KernEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernIntClear Lib "P71W32.DLL" Alias "_PC708_KernIntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernIntInstall Lib "P71W32.DLL" Alias "_PC708_KernIntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernIntStatus Lib "P71W32.DLL" Alias "_PC708_KernIntStatus@8" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernIntUninstall Lib "P71W32.DLL" Alias "_PC708_KernIntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernIORdW Lib "P71W32.DLL" Alias "_PC708_KernIORdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernIOWrW Lib "P71W32.DLL" Alias "_PC708_KernIOWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernMEMFillW Lib "P71W32.DLL" Alias "_PC708_KernMEMFillW@16" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernMEMRdsW Lib "P71W32.DLL" Alias "_PC708_KernMEMRdsW@16" (ByRef bufptr As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernMEMRdW Lib "P71W32.DLL" Alias "_PC708_KernMEMRdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernMEMWrsW Lib "P71W32.DLL" Alias "_PC708_KernMEMWrsW@16" (ByRef bufptr As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernMEMWrW Lib "P71W32.DLL" Alias "_PC708_KernMEMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_KernStatus Lib "P71W32.DLL" Alias "_PC708_KernStatus@12" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ListConfig Lib "P71W32.DLL" Alias "_PC708_ListConfig@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MakeLong Lib "P71W32.DLL" Alias "_PC708_MakeLong@8" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
    Public Declare Function PC708_Mask Lib "P71W32.DLL" Alias "_PC708_Mask@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function PC708_MEMWINRdB Lib "P71W32.DLL" Alias "_PC708_MEMWINRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_MEMWINRdL Lib "P71W32.DLL" Alias "_PC708_MEMWINRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MEMWINRdW Lib "P71W32.DLL" Alias "_PC708_MEMWINRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_MEMWINWrB Lib "P71W32.DLL" Alias "_PC708_MEMWINWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub PC708_MEMWINWrL Lib "P71W32.DLL" Alias "_PC708_MEMWINWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub PC708_MEMWINWrW Lib "P71W32.DLL" Alias "_PC708_MEMWINWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function PC708_Mod Lib "P71W32.DLL" Alias "_PC708_Mod@8" (ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
    Public Declare Function PC708_ModeIsBC Lib "P71W32.DLL" Alias "_PC708_ModeIsBC@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ModeIsMon Lib "P71W32.DLL" Alias "_PC708_ModeIsMon@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ModeIsNotBC Lib "P71W32.DLL" Alias "_PC708_ModeIsNotBC@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ModeIsNotMon Lib "P71W32.DLL" Alias "_PC708_ModeIsNotMon@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ModeIsNotRT Lib "P71W32.DLL" Alias "_PC708_ModeIsNotRT@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ModeIsNotSerial Lib "P71W32.DLL" Alias "_PC708_ModeIsNotSerial@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ModeIsRT Lib "P71W32.DLL" Alias "_PC708_ModeIsRT@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ModeIsSerial Lib "P71W32.DLL" Alias "_PC708_ModeIsSerial@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_ModeRd Lib "P71W32.DLL" Alias "_PC708_ModeRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_ModeWr Lib "P71W32.DLL" Alias "_PC708_ModeWr@8" (ByVal mode As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_MonBlkRd Lib "P71W32.DLL" Alias "_PC708_MonBlkRd@16" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MonBlkRdEx Lib "P71W32.DLL" Alias "_PC708_MonBlkRdEx@20" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal maxblkcnt As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MonClear Lib "P71W32.DLL" Alias "_PC708_MonClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_MonConfig Lib "P71W32.DLL" Alias "_PC708_MonConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_MonConfigEx Lib "P71W32.DLL" Alias "_PC708_MonConfigEx@16" (ByVal configval As UInt32, ByVal moncount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_MonConfigExx Lib "P71W32.DLL" Alias "_PC708_MonConfigExx@20" (ByVal configval As UInt32, ByVal seqaddr As UInt32, ByVal moncount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_MonIsRunning Lib "P71W32.DLL" Alias "_PC708_MonIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_MonRd Lib "P71W32.DLL" Alias "_PC708_MonRd@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_MonRdEx Lib "P71W32.DLL" Alias "_PC708_MonRdEx@12" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_MonResume Lib "P71W32.DLL" Alias "_PC708_MonResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_MonStart Lib "P71W32.DLL" Alias "_PC708_MonStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_MonStatus Lib "P71W32.DLL" Alias "_PC708_MonStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_MonStop Lib "P71W32.DLL" Alias "_PC708_MonStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_MsgBlockRd Lib "P71W32.DLL" Alias "_PC708_MsgBlockRd@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MsgBlockWr Lib "P71W32.DLL" Alias "_PC708_MsgBlockWr@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MsgCheck Lib "P71W32.DLL" Alias "_PC708_MsgCheck@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_MsgCommRd Lib "P71W32.DLL" Alias "_PC708_MsgCommRd@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MsgCommWr Lib "P71W32.DLL" Alias "_PC708_MsgCommWr@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MsgConfig Lib "P71W32.DLL" Alias "_PC708_MsgConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MsgConfigEx Lib "P71W32.DLL" Alias "_PC708_MsgConfigEx@12" (ByVal configval As UInt32, ByVal cwd As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MsgCWD1Rd Lib "P71W32.DLL" Alias "_PC708_MsgCWD1Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_MsgCWD1Wr Lib "P71W32.DLL" Alias "_PC708_MsgCWD1Wr@12" (ByVal cwd1 As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function PC708_MsgCWD2Rd Lib "P71W32.DLL" Alias "_PC708_MsgCWD2Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_MsgCWD2Wr Lib "P71W32.DLL" Alias "_PC708_MsgCWD2Wr@12" (ByVal cwd2 As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Sub PC708_MsgDataRd Lib "P71W32.DLL" Alias "_PC708_MsgDataRd@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Sub PC708_MsgDataWr Lib "P71W32.DLL" Alias "_PC708_MsgDataWr@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function PC708_MsgErrorRd Lib "P71W32.DLL" Alias "_PC708_MsgErrorRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_MsgErrorWr Lib "P71W32.DLL" Alias "_PC708_MsgErrorWr@12" (ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function PC708_MsgFieldRd Lib "P71W32.DLL" Alias "_PC708_MsgFieldRd@12" (ByVal fieldtype As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MsgFieldWr Lib "P71W32.DLL" Alias "_PC708_MsgFieldWr@16" (ByVal fieldval As UInt32, ByVal fieldtype As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MsgFlagRd Lib "P71W32.DLL" Alias "_PC708_MsgFlagRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_MsgFlagWr Lib "P71W32.DLL" Alias "_PC708_MsgFlagWr@12" (ByVal msgflag As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function PC708_MsgIsAccessed Lib "P71W32.DLL" Alias "_PC708_MsgIsAccessed@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_MsgOptRd Lib "P71W32.DLL" Alias "_PC708_MsgOptRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_MsgOptWr Lib "P71W32.DLL" Alias "_PC708_MsgOptWr@12" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function PC708_MsgReset Lib "P71W32.DLL" Alias "_PC708_MsgReset@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_MsgSWD1Rd Lib "P71W32.DLL" Alias "_PC708_MsgSWD1Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_MsgSWD2Rd Lib "P71W32.DLL" Alias "_PC708_MsgSWD2Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_Mul Lib "P71W32.DLL" Alias "_PC708_Mul@8" (ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
    Public Declare Function PC708_PortRd Lib "P71W32.DLL" Alias "_PC708_PortRd@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_PortWr Lib "P71W32.DLL" Alias "_PC708_PortWr@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_ProgRdW Lib "P71W32.DLL" Alias "_PC708_ProgRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_ProgWrW Lib "P71W32.DLL" Alias "_PC708_ProgWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub PC708_RAMFill Lib "P71W32.DLL" Alias "_PC708_RAMFill@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
    Public Declare Function PC708_RAMRdB Lib "P71W32.DLL" Alias "_PC708_RAMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_RAMRdL Lib "P71W32.DLL" Alias "_PC708_RAMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub PC708_RAMRdsW Lib "P71W32.DLL" Alias "_PC708_RAMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub PC708_RAMRdsxW Lib "P71W32.DLL" Alias "_PC708_RAMRdsxW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_RAMRdW Lib "P71W32.DLL" Alias "_PC708_RAMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_RAMWipe Lib "P71W32.DLL" Alias "_PC708_RAMWipe@4" (ByVal handleval As UInt32)
    Public Declare Sub PC708_RAMWipeEx Lib "P71W32.DLL" Alias "_PC708_RAMWipeEx@8" (ByVal value As UInt16, ByVal handleval As UInt32)
    Public Declare Sub PC708_RAMWrB Lib "P71W32.DLL" Alias "_PC708_RAMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub PC708_RAMWrL Lib "P71W32.DLL" Alias "_PC708_RAMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub PC708_RAMWrsW Lib "P71W32.DLL" Alias "_PC708_RAMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub PC708_RAMWrsxW Lib "P71W32.DLL" Alias "_PC708_RAMWrsxW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub PC708_RAMWrW Lib "P71W32.DLL" Alias "_PC708_RAMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function PC708_RcvAlloc Lib "P71W32.DLL" Alias "_PC708_RcvAlloc@8" (ByVal framenum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_RcvConfigExx Lib "P71W32.DLL" Alias "_PC708_RcvConfigExx@28" (ByVal rtconfigval As UInt32, ByVal intfreq As UInt16, ByVal monconfigval As UInt32, ByVal intconfigval As UInt32, ByVal inttotal As UInt16, ByVal msgconfigval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_RcvCountRd Lib "P71W32.DLL" Alias "_PC708_RcvCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_RcvCountWr Lib "P71W32.DLL" Alias "_PC708_RcvCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_RcvDataCountRd Lib "P71W32.DLL" Alias "_PC708_RcvDataCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_RcvDataCountWr Lib "P71W32.DLL" Alias "_PC708_RcvDataCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_RcvIndex Lib "P71W32.DLL" Alias "_PC708_RcvIndex@8" (ByVal framenum As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_RTConfig Lib "P71W32.DLL" Alias "_PC708_RTConfig@16" (ByVal configval As UInt32, ByVal taval As Int32, ByVal intfreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_RTConfigEx Lib "P71W32.DLL" Alias "_PC708_RTConfigEx@16" (ByVal configval As UInt32, ByVal taval As Int32, ByVal intfreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_RTConfigExx Lib "P71W32.DLL" Alias "_PC708_RTConfigExx@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_RTConfigMsg Lib "P71W32.DLL" Alias "_PC708_RTConfigMsg@12" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_RTReset Lib "P71W32.DLL" Alias "_PC708_RTReset@8" (ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_RTStatus Lib "P71W32.DLL" Alias "_PC708_RTStatus@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_RTSWDRd Lib "P71W32.DLL" Alias "_PC708_RTSWDRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_RTSWDWr Lib "P71W32.DLL" Alias "_PC708_RTSWDWr@12" (ByVal swdval As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_SARRdW Lib "P71W32.DLL" Alias "_PC708_SARRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_SARWrW Lib "P71W32.DLL" Alias "_PC708_SARWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_SchedBuild Lib "P71W32.DLL" Alias "_PC708_SchedBuild@16" (ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef freq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_SchedBuildEx Lib "P71W32.DLL" Alias "_PC708_SchedBuildEx@28" (ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef freq As UInt16, ByRef period As UInt16, ByVal buf As IntPtr, ByVal bufsize As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_SchedBuildExx Lib "P71W32.DLL" Alias "_PC708_SchedBuildExx@28" (ByVal frametime As UInt32, ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef period As UInt16, ByVal buf As IntPtr, ByVal bufsize As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_SchedCalc Lib "P71W32.DLL" Alias "_PC708_SchedCalc@8" (ByRef msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_SchedInsEnd Lib "P71W32.DLL" Alias "_PC708_SchedInsEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_SchedInsMsg Lib "P71W32.DLL" Alias "_PC708_SchedInsMsg@12" (ByVal index As UInt16, ByRef msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_SchedInsStart Lib "P71W32.DLL" Alias "_PC708_SchedInsStart@12" (ByVal frametime As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_SchedMaxval Lib "P71W32.DLL" Alias "_PC708_SchedMaxval@8" (ByRef arrayval As UInt16, ByVal arrayvalcount As UInt16) As UInt16
    Public Declare Function PC708_SchedMinval Lib "P71W32.DLL" Alias "_PC708_SchedMinval@8" (ByRef arrayval As UInt16, ByVal arrayvalcount As UInt16) As UInt16
    Public Declare Function PC708_Shl Lib "P71W32.DLL" Alias "_PC708_Shl@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function PC708_Shr Lib "P71W32.DLL" Alias "_PC708_Shr@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Sub PC708_TimerClear Lib "P71W32.DLL" Alias "_PC708_TimerClear@4" (ByVal handleval As UInt32)
    Public Declare Function PC708_TimerRd Lib "P71W32.DLL" Alias "_PC708_TimerRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_TimerResolution Lib "P71W32.DLL" Alias "_PC708_TimerResolution@8" (ByVal timerresol As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_TimerResolutionEx Lib "P71W32.DLL" Alias "_PC708_TimerResolutionEx@8" (ByVal timershift As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function PC708_ValAsciiCmpi Lib "P71W32.DLL" Alias "_PC708_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Int32
    Public Declare Function PC708_ValAsciiCpy Lib "P71W32.DLL" Alias "_PC708_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Int32) As UInt32
    Public Declare Sub PC708_ValAsciiTrimLead Lib "P71W32.DLL" Alias "_PC708_ValAsciiTrimLead@4" (ByRef buf As String)
    Public Declare Sub PC708_ValAsciiTrimTrail Lib "P71W32.DLL" Alias "_PC708_ValAsciiTrimTrail@4" (ByRef buf As String)
    Public Declare Function PC708_ValFromAscii Lib "P71W32.DLL" Alias "_PC708_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
    Public Declare Function PC708_ValGetBits Lib "P71W32.DLL" Alias "_PC708_ValGetBits@12" (ByVal oldvalue As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function PC708_ValIncAscii Lib "P71W32.DLL" Alias "_PC708_ValIncAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function PC708_ValInccAscii Lib "P71W32.DLL" Alias "_PC708_ValInccAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function PC708_ValIsLower Lib "P71W32.DLL" Alias "_PC708_ValIsLower@4" (ByVal value As Int32) As Int32
    Public Declare Function PC708_ValLenAscii Lib "P71W32.DLL" Alias "_PC708_ValLenAscii@8" (ByVal numbits As Int32, ByVal radixval As Int32) As Int32
    Public Declare Function PC708_ValPackCWD Lib "P71W32.DLL" Alias "_PC708_ValPackCWD@16" (ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal wcval As Int32) As UInt16
    Public Declare Function PC708_ValPackRTCWD Lib "P71W32.DLL" Alias "_PC708_ValPackRTCWD@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal count As Int32) As UInt16
    Public Declare Function PC708_ValPutBits Lib "P71W32.DLL" Alias "_PC708_ValPutBits@16" (ByVal oldvalue As UInt16, ByVal newfld As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function PC708_ValToAscii Lib "P71W32.DLL" Alias "_PC708_ValToAscii@16" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
    Public Declare Function PC708_ValToUpper Lib "P71W32.DLL" Alias "_PC708_ValToUpper@4" (ByVal value As Int32) As Int32
    Public Declare Sub PC708_ValUnpackCWD Lib "P71W32.DLL" Alias "_PC708_ValUnpackCWD@20" (ByVal cwdval As UInt16, ByRef taval As Int32, ByRef trflag As Int32, ByRef saval As Int32, ByRef wcval As Int32)
    Public Declare Sub PC708_ValUnpackRTCWD Lib "P71W32.DLL" Alias "_PC708_ValUnpackRTCWD@28" (ByVal cwd As UInt16, ByRef bcastflag As Int32, ByRef mcflag As Int32, ByRef taval As Int32, ByRef trflag As Int32, ByRef saval As Int32, ByRef count As Int32)
    Public Declare Function PC708_XmtAlloc Lib "P71W32.DLL" Alias "_PC708_XmtAlloc@8" (ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_XmtConfigExxx Lib "P71W32.DLL" Alias "_PC708_XmtConfigExxx@24" (ByVal bcconfigval As UInt32, ByVal msgconfigval As UInt32, ByVal framefreq As UInt16, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_XmtCountRd Lib "P71W32.DLL" Alias "_PC708_XmtCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_XmtCountWr Lib "P71W32.DLL" Alias "_PC708_XmtCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_XmtDataCountRd Lib "P71W32.DLL" Alias "_PC708_XmtDataCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_XmtDataCountWr Lib "P71W32.DLL" Alias "_PC708_XmtDataCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_XmtFreq Lib "P71W32.DLL" Alias "_PC708_XmtFreq@8" (ByVal framefreq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_XmtFreqEx Lib "P71W32.DLL" Alias "_PC708_XmtFreqEx@16" (ByVal framefreq As UInt16, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_XmtFreqExx Lib "P71W32.DLL" Alias "_PC708_XmtFreqExx@36" (ByVal framefreq As UInt16, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal bcconfigval As UInt32, ByVal bctotal As UInt16, ByVal intconfigval As UInt32, ByVal inttotal As UInt16, ByVal msgconfigval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_XmtIndex Lib "P71W32.DLL" Alias "_PC708_XmtIndex@8" (ByVal framenum As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function PC708_XmtNumberRd Lib "P71W32.DLL" Alias "_PC708_XmtNumberRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub PC708_XmtNumberWr Lib "P71W32.DLL" Alias "_PC708_XmtNumberWr@8" (ByVal brdnum As UInt16, ByVal handleval As UInt32)
    Public Declare Function PC708_XmtPeriod Lib "P71W32.DLL" Alias "_PC708_XmtPeriod@8" (ByVal frameperiod As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_XmtPeriodEx Lib "P71W32.DLL" Alias "_PC708_XmtPeriodEx@16" (ByVal frameperiod As UInt32, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function PC708_XmtPeriodExx Lib "P71W32.DLL" Alias "_PC708_XmtPeriodExx@36" (ByVal frameperiod As UInt32, ByVal intfreq As UInt16, ByVal framecount As UInt16, ByVal bcconfigval As UInt32, ByVal bctotal As UInt16, ByVal intconfigval As UInt32, ByVal inttotal As UInt16, ByVal msgconfigval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Sub PC708_XmtRd Lib "P71W32.DLL" Alias "_PC708_XmtRd@12" (ByRef buf As UInt16, ByVal framenum As UInt16, ByVal handleval As UInt32)
    Public Declare Sub PC708_XmtSizeWr Lib "P71W32.DLL" Alias "_PC708_XmtSizeWr@8" (ByVal mode As UInt16, ByVal handleval As UInt32)

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
    Public Const RTCFG_WIPE123 As UInt32 = &H1000000L  '//Initialize data with incrementing values
    Public Const RTCFG_WIPECWD As UInt32 = &H2000000L  '//Initialize data with command word

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
    '*  Interrupt log list configuration options
    '*
    '**/

    Public Const INTCFG_DEFAULT As UInt32 = &H0L '//Select all default settings
    Public Const INTCFG_ENABLE As UInt32 = &H0L  '//Enable interrupt log list (default)
    Public Const INTCFG_DISABLE As UInt32 = &H1L '//Disable interrupt log list

    '/**
    '*
    '*  Monitor configuration options
    '*
    '**/

    Public Const LISTCFG_DEFAULT As UInt32 = &H0L    '//Select all default settings
    Public Const LISTCFG_PINGPONG As UInt32 = &H0L   '//Enable ping-pong mode (default)
    Public Const LISTCFG_DISABLE As UInt32 = &H1L    '//Disable list buffer
    Public Const LISTCFG_CONTINUOUS As UInt32 = &H2L '//Enable continuous mode
    Public Const LISTCFG_FREE As UInt32 = &H4L   '//Enable free mode
    Public Const LISTCFG_NOINT As UInt32 = &H0L  '//Do not generate interrupt when list buffer empty/full (default)
    Public Const LISTCFG_INT As UInt32 = &H10L    '//Generate interrupt when list buffer empty/full

    '/**
    '*
    '*  Info types
    '*
    '**/

    Public Const INFOTYPE_PLAT As UInt16 = &H1   '//Returns the PC708 platform type
    Public Const INFOTYPE_PROD As UInt16 = &H2   '//Returns the PC708 product type
    Public Const INFOTYPE_REV As UInt16 = &H3    '//Returns the PC708 revision number
    Public Const INFOTYPE_VERSION As UInt16 = &H4    '//Returns the PC708 version number
    Public Const INFOTYPE_DATE As UInt16 = &H5   '//Returns the PC708 version date
    Public Const INFOTYPE_TRANSMIT As UInt16 = &H6   '//Returns whether the PC708 has a transmitter
    Public Const INFOTYPE_RECEIVE As UInt16 = &H7    '//Returns whether the PC708 has a receiver
    Public Const INFOTYPE_DASH As UInt16 = &H8   '//Returns the PC708 dash number
    Public Const INFOTYPE_MODEL As UInt16 = &H9  '//Returns the PC708 model number
    Public Const INFOTYPE_MAXCOUNT As UInt16 = &HA   '//Returns the number of terminals the PC1553-3 can simulate
    Public Const INFOTYPE_MULTIMODE As UInt16 = &HB  '//Returns whether PC708 can simulate multi-modes
    Public Const INFOTYPE_ERRORGEN As UInt16 = &HC   '//Returns whether PC708 can generate errors
    Public Const INFOTYPE_CONCURMON As UInt16 = &HD  '//Returns whether PC708 has a concurrent monitor
    Public Const INFOTYPE_MONFILTER As UInt16 = &HE  '//Returns whether PC708 has a monitor filter
    Public Const INFOTYPE_USERCODE As UInt16 = &HF   '//Returns whether PC708 handles user code
    Public Const INFOTYPE_LISTBUF As UInt16 = &H10    '//Returns whether PC708 handles list buffering
    Public Const INFOTYPE_MONFAST As UInt16 = &H11    '//Returns whether PC708 has a fast monitor
    Public Const INFOTYPE_MONDMA As UInt16 = &H12 '//Returns whether PC708 has a dma monitor
    Public Const INFOTYPE_DUAL As UInt16 = &H13   '//Returns whether PC708 has dual xmt/rcv capability
    Public Const INFOTYPE_BITSYNC As UInt16 = &H14    '//Returns whether PC708 has bit sync capability

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
    '*  P71 Host Registers
    '*
    '**/

    Public Const HREG_CTRL As UInt16 = &H0 '//Host control register (WR)
    Public Const HREG_STAT As UInt16 = &H0 '//Host status register (RD)
    Public Const HREG_CONFIG As UInt16 = &H1   '//Configuration register (RD/WR)
    Public Const HREG_CMAIL As UInt16 = &H2    '//Controller mailbox register (WR)
    Public Const HREG_HMAIL As UInt16 = &H3    '//Host mailbox register (RD)
    Public Const HREG_ACCESS As UInt16 = &H4   '//Access register (RD/WR)
    Public Const HREG_PAGE As UInt16 = &H5 '//Page register (RD/WR)
    Public Const HREG_INDSEL As UInt16 = &H6   '//Indirect register select (RD/WR)
    Public Const HREG_INDVAL As UInt16 = &H7   '//Indirect register value (RD/WR)

    '/**
    '*
    '*  P12 Host Registers
    '*
    '**/

    Public Const HREG_RESP As UInt16 = &H0 '//Response register (RD)
    Public Const HREG_CTRL0 As UInt16 = &H0    '//Control 0 register (WR)
    Public Const HREG_CTRL1 As UInt16 = &H1    '//Control 1 register (WR)
    Public Const HREG_CTRL2 As UInt16 = &H2    '//Control 2 register (WR)
    Public Const HREG_TRIG As UInt16 = &H4 '//Transmit trigger register (WR)
    Public Const HREG_INTCLR As UInt16 = &H5   '//Interrupt clear register (WR)
    Public Const HREG_SYNCCLR As UInt16 = &H6  '//Sync clear register (WR)

    '/**
    '*
    '*  P71 Host Indirect Registers
    '*
    '**/

    Public Const IREG_CTRL0 As UInt16 = &H0    '//Control register 0 (RD/WR)
    Public Const IREG_CTRL1 As UInt16 = &H1    '//Control register 1 (RD/WR)
    Public Const IREG_CTRL2 As UInt16 = &H2    '//Control register 2 (RD/WR)
    Public Const IREG_DMA As UInt16 = &H3  '//DMA register (RD/WR)
    Public Const IREG_TRIG As UInt16 = &H4 '//Transmit trigger (WR)
    Public Const IREG_RESP As UInt16 = &H4 '//Response register (RD)
    Public Const IREG_INTCLR As UInt16 = &H5   '//Interrupt clear (RD/WR)
    Public Const IREG_SYNCCLR As UInt16 = &H6  '//Sync clear (RD/WR)

    '/**
    '*
    '*  DSP Registers
    '*
    '**/

    Public Const DREG_HOST As UInt16 = &H2C40   '//Host status register (RD)
    Public Const DREG_INT As UInt16 = &H2C41    '//Interrupt register
    Public Const DREG_CMAIL As UInt16 = &H2C42  '//Controller mailbox register
    Public Const DREG_HMAIL As UInt16 = &H2C43  '//Host mailbox register
    Public Const DREG_DMA As UInt16 = &H2C44    '//DMA register
    Public Const DREG_PAGE As UInt16 = &H2C45   '//Page register
    Public Const DREG_CTRL As UInt16 = &H2C48   '//Control from host register
    Public Const DREG_RESP As UInt16 = &H2C49   '//Response to host register
    Public Const DREG_SWD As UInt16 = &H2C4A    '//Status word from host register
    Public Const DREG_HINT As UInt16 = &H2C4C   '//Host interrupt register
    Public Const DREG_DIN As UInt16 = &H2C4D    '//DIN register
    Public Const DREG_DOUT As UInt16 = &H2C4E   '//DOUT register

    '/**
    '*
    '*  EDGA Registers
    '*
    '**/

    Public Const EREG_STAT As UInt16 = &HAC80   '//Status register (RD)
    Public Const EREG_CTRLE As UInt16 = &H2C81  '//Encoder control register
    Public Const EREG_VALE As UInt16 = &H2C82   '//Encoder value register
    Public Const EREG_CFGINT As UInt16 = &H2C83 '//Interrupt configuration register
    Public Const EREG_CFG As UInt16 = &H2C84    '//Configuration register
    Public Const EREG_VALD As UInt16 = &H2C85   '//Encoder value register (RD)
    Public Const EREG_FT As UInt16 = &H2C86 '//Frame time register
    Public Const EREG_ID As UInt16 = &H2C87 '//Identification register (RD)
    Public Const EREG_STATCLR As UInt16 = &H2C8E    '//Status clear register (WR)
    Public Const EREG_RST As UInt16 = &H2C8F    '//Reset register (WR)

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

    Public Const ERR_NONE As Int16 = 0  '//No error
    Public Const ERR_UNKNOWN As Int16 = -1  '//An unexpected error occurred
    Public Const ERR_BADVER As Int16 = -2   '//A bad version was encountered
    Public Const ERR_BADPARAMS As Int16 = -11   '//CardOpen() called with bad parameters
    Public Const ERR_NOHANDLES As Int16 = -12   '//CardOpen() already has allocated too many handles
    Public Const ERR_NOCARD As Int16 = -13  '//CardOpen() could not find a PC708-1 card at the specified address
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

End Module
