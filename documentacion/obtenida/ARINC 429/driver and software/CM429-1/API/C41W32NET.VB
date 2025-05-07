Imports System
Imports System.Runtime.InteropServices

Module C41W32VB

    '/**
    '*
    '*  CM429-1 WIN32 DRIVER  Version 1.8  (11/30/2006)
    '*  Copyright (c) 1997-2006
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   C41W32NET.VB -- 32-bit
    '*                      CM429-1 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  CM429-1 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  CM429-1 717 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the CM429-1 Driver.
    '*
    '**/

    Public Declare Function C41_AsciiFrom Lib "C41W32.DLL" Alias "_C41_AsciiFrom@8" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
    Public Declare Sub C41_AsciiTo Lib "C41W32.DLL" Alias "_C41_AsciiTo@16" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32)
    Public Declare Function C41_BCDGetData Lib "C41W32.DLL" Alias "_C41_BCDGetData@12" (ByVal msg As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
    Public Declare Function C41_BCDGetMant Lib "C41W32.DLL" Alias "_C41_BCDGetMant@8" (ByVal msg As UInt32, ByVal sigdig As UInt16) As UInt32
    Public Declare Function C41_BCDGetSign Lib "C41W32.DLL" Alias "_C41_BCDGetSign@4" (ByVal msg As UInt32) As UInt16
    Public Declare Function C41_BCDGetSSM Lib "C41W32.DLL" Alias "_C41_BCDGetSSM@4" (ByVal msg As UInt32) As UInt16
    Public Declare Sub C41_BCDGetVal Lib "C41W32.DLL" Alias "_C41_BCDGetVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigdig As UInt16, ByRef resolstr As String)
    Public Declare Function C41_BCDPutData Lib "C41W32.DLL" Alias "_C41_BCDPutData@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
    Public Declare Function C41_BCDPutMant Lib "C41W32.DLL" Alias "_C41_BCDPutMant@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal sigdig As UInt16, ByVal sign As UInt16) As UInt32
    Public Declare Function C41_BCDPutSign Lib "C41W32.DLL" Alias "_C41_BCDPutSign@8" (ByVal msg As UInt32, ByVal sign As UInt16) As UInt32
    Public Declare Function C41_BCDPutSSM Lib "C41W32.DLL" Alias "_C41_BCDPutSSM@8" (ByVal msg As UInt32, ByVal value As UInt16) As UInt32
    Public Declare Function C41_BCDPutVal Lib "C41W32.DLL" Alias "_C41_BCDPutVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigdig As UInt16, ByRef resolstr As String) As UInt32
    Public Declare Function C41_BNRGetData Lib "C41W32.DLL" Alias "_C41_BNRGetData@12" (ByVal msg As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
    Public Declare Function C41_BNRGetMant Lib "C41W32.DLL" Alias "_C41_BNRGetMant@8" (ByVal msg As UInt32, ByVal sigbit As UInt16) As UInt32
    Public Declare Function C41_BNRGetSign Lib "C41W32.DLL" Alias "_C41_BNRGetSign@4" (ByVal msg As UInt32) As UInt16
    Public Declare Function C41_BNRGetSSM Lib "C41W32.DLL" Alias "_C41_BNRGetSSM@4" (ByVal msg As UInt32) As UInt16
    Public Declare Sub C41_BNRGetVal Lib "C41W32.DLL" Alias "_C41_BNRGetVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigbit As UInt16, ByRef resolstr As String)
    Public Declare Function C41_BNRPutData Lib "C41W32.DLL" Alias "_C41_BNRPutData@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal msb As UInt16, ByVal lsb As UInt16) As UInt32
    Public Declare Function C41_BNRPutMant Lib "C41W32.DLL" Alias "_C41_BNRPutMant@16" (ByVal msg As UInt32, ByVal value As UInt32, ByVal sigbit As UInt16, ByVal twos As UInt16) As UInt32
    Public Declare Function C41_BNRPutSign Lib "C41W32.DLL" Alias "_C41_BNRPutSign@8" (ByVal msg As UInt32, ByVal twos As UInt16) As UInt32
    Public Declare Function C41_BNRPutSSM Lib "C41W32.DLL" Alias "_C41_BNRPutSSM@8" (ByVal msg As UInt32, ByVal value As UInt16) As UInt32
    Public Declare Function C41_BNRPutVal Lib "C41W32.DLL" Alias "_C41_BNRPutVal@16" (ByRef buf As String, ByVal msg As UInt32, ByVal sigbit As UInt16, ByRef resolstr As String) As UInt32
    Public Declare Function C41_ChCheck Lib "C41W32.DLL" Alias "_C41_ChCheck@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_ChClear Lib "C41W32.DLL" Alias "_C41_ChClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_ChConfig Lib "C41W32.DLL" Alias "_C41_ChConfig@12" (ByVal configval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub C41_ChPause Lib "C41W32.DLL" Alias "_C41_ChPause@8" (ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Sub C41_ChResume Lib "C41W32.DLL" Alias "_C41_ChResume@8" (ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function C41_CloseAll Lib "C41W32.DLL" Alias "_C41_CloseAll@0" () As Int32
    Public Declare Function C41_CloseCard Lib "C41W32.DLL" Alias "_C41_CloseCard@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_ExtRd Lib "C41W32.DLL" Alias "_C41_ExtRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub C41_ExtWr Lib "C41W32.DLL" Alias "_C41_ExtWr@8" (ByVal extflag As Int32, ByVal handleval As UInt32)
    Public Declare Function C41_FilterDefault Lib "C41W32.DLL" Alias "_C41_FilterDefault@12" (ByVal msgnum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_FilterSet Lib "C41W32.DLL" Alias "_C41_FilterSet@20" (ByVal labelval As Int32, ByVal sdimask As Int32, ByVal msgnum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_FldGetData Lib "C41W32.DLL" Alias "_C41_FldGetData@4" (ByVal msgval As UInt32) As UInt32
    Public Declare Function C41_FldGetLabel Lib "C41W32.DLL" Alias "_C41_FldGetLabel@4" (ByVal msgval As UInt32) As UInt16
    Public Declare Function C41_FldGetParity Lib "C41W32.DLL" Alias "_C41_FldGetParity@4" (ByVal msgval As UInt32) As UInt16
    Public Declare Function C41_FldGetSDI Lib "C41W32.DLL" Alias "_C41_FldGetSDI@4" (ByVal msgval As UInt32) As UInt16
    Public Declare Function C41_FldGetValue Lib "C41W32.DLL" Alias "_C41_FldGetValue@12" (ByVal msgval As UInt32, ByVal startbit As UInt16, ByVal endbit As UInt16) As UInt32
    Public Declare Function C41_FldPutData Lib "C41W32.DLL" Alias "_C41_FldPutData@8" (ByVal msgval As UInt32, ByVal data As UInt32) As UInt32
    Public Declare Function C41_FldPutLabel Lib "C41W32.DLL" Alias "_C41_FldPutLabel@8" (ByVal msgval As UInt32, ByVal label As UInt16) As UInt32
    Public Declare Function C41_FldPutSDI Lib "C41W32.DLL" Alias "_C41_FldPutSDI@8" (ByVal msgval As UInt32, ByVal sdi As UInt16) As UInt32
    Public Declare Function C41_FldPutValue Lib "C41W32.DLL" Alias "_C41_FldPutValue@16" (ByVal msgval As UInt32, ByVal dataval As UInt32, ByVal startbit As UInt16, ByVal endbit As UInt16) As UInt32
    Public Declare Function C41_IntDin Lib "C41W32.DLL" Alias "_C41_IntDin@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_IntRd Lib "C41W32.DLL" Alias "_C41_IntRd@12" (ByRef typevalval As UInt16, ByRef infoval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_ListMakeRcv Lib "C41W32.DLL" Alias "_C41_ListMakeRcv@12" (ByVal count As UInt16, ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_ListMakeXmt Lib "C41W32.DLL" Alias "_C41_ListMakeXmt@12" (ByVal count As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_ListRd Lib "C41W32.DLL" Alias "_C41_ListRd@12" (ByRef msgval As UInt32, ByVal listaddr As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_ListStatus Lib "C41W32.DLL" Alias "_C41_ListStatus@8" (ByVal listaddr As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_ListWr Lib "C41W32.DLL" Alias "_C41_ListWr@12" (ByVal msgval As UInt32, ByVal listaddr As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_MemPeek Lib "C41W32.DLL" Alias "_C41_MemPeek@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_MemPoke Lib "C41W32.DLL" Alias "_C41_MemPoke@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C41_MsgArincRd Lib "C41W32.DLL" Alias "_C41_MsgArincRd@8" (ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub C41_MsgArincWr Lib "C41W32.DLL" Alias "_C41_MsgArincWr@12" (ByVal msgval As UInt32, ByVal msgnum As Int32, ByVal handleval As UInt32)
    Public Declare Function C41_MsgBlockRd Lib "C41W32.DLL" Alias "_C41_MsgBlockRd@12" (ByRef valueptr As UInt16, ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_MsgBlockWr Lib "C41W32.DLL" Alias "_C41_MsgBlockWr@12" (ByRef valueptr As UInt16, ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_MsgCommRd Lib "C41W32.DLL" Alias "_C41_MsgCommRd@12" (ByRef valueptr As UInt16, ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_MsgCommWr Lib "C41W32.DLL" Alias "_C41_MsgCommWr@12" (ByRef valueptr As UInt16, ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_MsgConfig Lib "C41W32.DLL" Alias "_C41_MsgConfig@12" (ByVal configval As UInt16, ByVal msgnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_MsgEncoderRd Lib "C41W32.DLL" Alias "_C41_MsgEncoderRd@8" (ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub C41_MsgEncoderWr Lib "C41W32.DLL" Alias "_C41_MsgEncoderWr@12" (ByVal msgval As UInt32, ByVal msgnum As Int32, ByVal handleval As UInt32)
    Public Declare Function C41_OpenCard Lib "C41W32.DLL" Alias "_C41_OpenCard@4" (ByVal cardnum As Int32) As UInt32
    Public Declare Sub C41_Reset Lib "C41W32.DLL" Alias "_C41_Reset@4" (ByVal handleval As UInt32)
    Public Declare Sub C41_Restart Lib "C41W32.DLL" Alias "_C41_Restart@4" (ByVal handleval As UInt32)
    Public Declare Function C41_SchedBranch Lib "C41W32.DLL" Alias "_C41_SchedBranch@16" (ByVal schindex As Int32, ByVal condition As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedBuild Lib "C41W32.DLL" Alias "_C41_SchedBuild@24" (ByVal basevalmsgnum As Int32, ByVal nummsgs As UInt16, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedCall Lib "C41W32.DLL" Alias "_C41_SchedCall@12" (ByVal schindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedGap Lib "C41W32.DLL" Alias "_C41_SchedGap@12" (ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedHalt Lib "C41W32.DLL" Alias "_C41_SchedHalt@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedInt Lib "C41W32.DLL" Alias "_C41_SchedInt@12" (ByVal tagval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedMsg Lib "C41W32.DLL" Alias "_C41_SchedMsg@12" (ByVal msgnum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedPause Lib "C41W32.DLL" Alias "_C41_SchedPause@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedPulse Lib "C41W32.DLL" Alias "_C41_SchedPulse@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedRestart Lib "C41W32.DLL" Alias "_C41_SchedRestart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedRet Lib "C41W32.DLL" Alias "_C41_SchedRet@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedStart Lib "C41W32.DLL" Alias "_C41_SchedStart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SelfTest Lib "C41W32.DLL" Alias "_C41_SelfTest@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SeqClear Lib "C41W32.DLL" Alias "_C41_SeqClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SeqConfig Lib "C41W32.DLL" Alias "_C41_SeqConfig@16" (ByVal configval As UInt16, ByVal interval As Int32, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SeqRd Lib "C41W32.DLL" Alias "_C41_SeqRd@12" (ByRef msgval As UInt32, ByRef stampval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_Start Lib "C41W32.DLL" Alias "_C41_Start@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_Stop Lib "C41W32.DLL" Alias "_C41_Stop@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_TimerClear Lib "C41W32.DLL" Alias "_C41_TimerClear@4" (ByVal handleval As UInt32)
    Public Declare Function C41_TimerRd Lib "C41W32.DLL" Alias "_C41_TimerRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function C41_TimerResolution Lib "C41W32.DLL" Alias "_C41_TimerResolution@8" (ByVal timerresol As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_717Boot Lib "C41W32.DLL" Alias "_C41_717Boot@4" (ByVal handleval As Int32) As Int32
    Public Declare Function C41_717FrameWipe Lib "C41W32.DLL" Alias "_C41_717FrameWipe@8" (ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SubFrmClear Lib "C41W32.DLL" Alias "_C41_717SubFrmClear@8" (ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SubFrmDataWipe Lib "C41W32.DLL" Alias "_C41_717SubFrmDataWipe@12" (ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SubFrmPtrDefault Lib "C41W32.DLL" Alias "_C41_717SubFrmPtrDefault@8" (ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SubFrmPtrSet Lib "C41W32.DLL" Alias "_C41_717SubFrmPtrSet@16" (ByVal subfrmnum As Int32, ByVal destsubfrm As Int32, ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SubFrmRecordWipe Lib "C41W32.DLL" Alias "_C41_717SubFrmRecordWipe@12" (ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SubFrmWordConfig Lib "C41W32.DLL" Alias "_C41_717SubFrmWordConfig@20" (ByVal configval As Int32, ByVal subframe As Int32, ByVal wordnum As Int32, ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SubFrmWordConfigEx Lib "C41W32.DLL" Alias "_C41_717SubFrmWordConfigEx@16" (ByVal configval As Int32, ByVal subframe As Int32, ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SubFrmWordRd Lib "C41W32.DLL" Alias "_C41_717SubFrmWordRd@16" (ByVal subframe As Int32, ByVal wordnum As Int32, ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SyncTest Lib "C41W32.DLL" Alias "_C41_717SyncTest@8" (ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SyncWordDefault Lib "C41W32.DLL" Alias "_C41_717SyncWordDefault@8" (ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Function C41_717SyncWordSet Lib "C41W32.DLL" Alias "_C41_717SyncWordSet@24" (ByVal sync1 As Int32, ByVal sync2 As Int32, ByVal sync3 As Int32, ByVal sync4 As Int32, ByVal channum As Int32, ByVal handleval As Int32) As Int32
    Public Declare Sub C41_Ch717Disable Lib "C41W32.DLL" Alias "_C41_Ch717Disable@4" (ByVal handleval As Int32)
    Public Declare Sub C41_Ch717Enable Lib "C41W32.DLL" Alias "_C41_Ch717Enable@4" (ByVal handleval As Int32)
    Public Declare Function C41_AcgaRd Lib "C41W32.DLL" Alias "_C41_AcgaRd@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_AcgaWr Lib "C41W32.DLL" Alias "_C41_AcgaWr@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C41_AsciiToMant Lib "C41W32.DLL" Alias "_C41_AsciiToMant@12" (ByRef str As String, ByRef mant As Int32, ByRef exp As Int32) As Int32
    Public Declare Function C41_CardClose Lib "C41W32.DLL" Alias "_C41_CardClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub C41_CardInit Lib "C41W32.DLL" Alias "_C41_CardInit@0" ()
    Public Declare Function C41_CardOpen Lib "C41W32.DLL" Alias "_C41_CardOpen@4" (ByVal cardnum As Int32) As UInt32
    Public Declare Function C41_CardOpenEx Lib "C41W32.DLL" Alias "_C41_CardOpenEx@16" (ByRef cardname As String, ByVal rcvcount As Int32, ByVal xmtcount As Int32, ByVal cardnum As Int32) As UInt32
    Public Declare Function C41_CardOpenExx Lib "C41W32.DLL" Alias "_C41_CardOpenExx@24" (ByRef cardname As String, ByVal rcvcount As Int32, ByVal xmtcount As Int32, ByVal cardnum As Int32, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Function C41_ChPauseCheck Lib "C41W32.DLL" Alias "_C41_ChPauseCheck@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_ChStart Lib "C41W32.DLL" Alias "_C41_ChStart@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_ChStop Lib "C41W32.DLL" Alias "_C41_ChStop@8" (ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_CommCall Lib "C41W32.DLL" Alias "_C41_CommCall@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C41_CommCheck Lib "C41W32.DLL" Alias "_C41_CommCheck@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_CommDisable Lib "C41W32.DLL" Alias "_C41_CommDisable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_CommEnable Lib "C41W32.DLL" Alias "_C41_CommEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_CommRd Lib "C41W32.DLL" Alias "_C41_CommRd@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_CommRun Lib "C41W32.DLL" Alias "_C41_CommRun@20" (ByRef dataptr As UInt16, ByVal datacount As UInt16, ByRef codeptr As UInt16, ByVal codecount As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C41_CommStrRd Lib "C41W32.DLL" Alias "_C41_CommStrRd@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal count As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C41_CommStrWr Lib "C41W32.DLL" Alias "_C41_CommStrWr@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal count As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C41_CommTxen Lib "C41W32.DLL" Alias "_C41_CommTxen@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C41_CommWr Lib "C41W32.DLL" Alias "_C41_CommWr@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C41_ConvFromArinc Lib "C41W32.DLL" Alias "_C41_ConvFromArinc@4" (ByVal msgval As UInt32) As UInt32
    Public Declare Function C41_ConvToArinc Lib "C41W32.DLL" Alias "_C41_ConvToArinc@4" (ByVal msgval As UInt32) As UInt32
    Public Declare Function C41_CycleAdvance Lib "C41W32.DLL" Alias "_C41_CycleAdvance@0" () As UInt32
    Public Declare Function C41_CycleBuild Lib "C41W32.DLL" Alias "_C41_CycleBuild@24" (ByVal basevalmsgnum As Int32, ByVal nummsgs As UInt32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_CycleBuildEx Lib "C41W32.DLL" Alias "_C41_CycleBuildEx@36" (ByVal basevalmsgnum As Int32, ByVal nummsgs As Int32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal speed As Int32, ByVal buf As IntPtr, ByVal bufsize As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_CycleBuildSt Lib "C41W32.DLL" Alias "_C41_CycleBuildSt@24" (ByVal basevalmsgnum As Int32, ByVal nummsgs As Int32, ByRef minperiod As Int32, ByRef maxperiod As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_CycleCalc Lib "C41W32.DLL" Alias "_C41_CycleCalc@0" () As UInt32
    Public Declare Function C41_CycleCheck Lib "C41W32.DLL" Alias "_C41_CycleCheck@8" (ByRef minperiod As Int32, ByRef maxperiod As Int32) As Int32
    Public Declare Sub C41_CycleCheckEnd Lib "C41W32.DLL" Alias "_C41_CycleCheckEnd@0" ()
    Public Declare Sub C41_CycleCheckMiddle Lib "C41W32.DLL" Alias "_C41_CycleCheckMiddle@16" (ByVal msgnum As Int32, ByVal minlen As UInt32, ByVal midlen As UInt32, ByVal maxlen As UInt32)
    Public Declare Sub C41_CycleCheckReal Lib "C41W32.DLL" Alias "_C41_CycleCheckReal@16" (ByVal msgnum As Int32, ByVal minlen As UInt32, ByVal midlen As UInt32, ByVal maxlen As UInt32)
    Public Declare Sub C41_CycleCheckStart Lib "C41W32.DLL" Alias "_C41_CycleCheckStart@0" ()
    Public Declare Function C41_CycleConflicts Lib "C41W32.DLL" Alias "_C41_CycleConflicts@0" () As UInt32
    Public Declare Function C41_CycleDivide Lib "C41W32.DLL" Alias "_C41_CycleDivide@0" () As Int32
    Public Declare Function C41_CycleFix Lib "C41W32.DLL" Alias "_C41_CycleFix@0" () As UInt32
    Public Declare Sub C41_CycleFixEnd Lib "C41W32.DLL" Alias "_C41_CycleFixEnd@0" ()
    Public Declare Sub C41_CycleFixMiddle Lib "C41W32.DLL" Alias "_C41_CycleFixMiddle@4" (ByVal conflicts As UInt32)
    Public Declare Sub C41_CycleFixStart Lib "C41W32.DLL" Alias "_C41_CycleFixStart@0" ()
    Public Declare Sub C41_CycleHook Lib "C41W32.DLL" Alias "_C41_CycleHook@8" (ByVal index As Int32, ByVal ptr As IntPtr)
    Public Declare Function C41_CycleInsert Lib "C41W32.DLL" Alias "_C41_CycleInsert@24" (ByVal eventvals As UInt32, ByVal index As UInt32, ByVal msgnum As Int32, ByVal gapval As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_CycleInsertEnd Lib "C41W32.DLL" Alias "_C41_CycleInsertEnd@12" (ByVal eventvals As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_CycleInsertStart Lib "C41W32.DLL" Alias "_C41_CycleInsertStart@12" (ByVal eventvals As UInt32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub C41_CycleLayout Lib "C41W32.DLL" Alias "_C41_CycleLayout@0" ()
    Public Declare Function C41_CycleMaxval Lib "C41W32.DLL" Alias "_C41_CycleMaxval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
    Public Declare Function C41_CycleMinval Lib "C41W32.DLL" Alias "_C41_CycleMinval@8" (ByRef arrayval As UInt32, ByVal arrayvalcount As UInt32) As UInt32
    Public Declare Function C41_CycleParse Lib "C41W32.DLL" Alias "_C41_CycleParse@12" (ByVal basevalmsgnum As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub C41_CyclePrint Lib "C41W32.DLL" Alias "" (ByVal ParamArray list() As String)
    Public Declare Function C41_CycleReset Lib "C41W32.DLL" Alias "_C41_CycleReset@0" () As Int32
    Public Declare Function C41_CycleRotate Lib "C41W32.DLL" Alias "_C41_CycleRotate@0" () As UInt32
    Public Declare Function C41_CycleShift Lib "C41W32.DLL" Alias "_C41_CycleShift@8" (ByVal msgnum As Int32, ByVal value As Int32) As Int32
    Public Declare Function C41_CycleSlide Lib "C41W32.DLL" Alias "_C41_CycleSlide@0" () As Int32
    Public Declare Sub C41_CycleSlideEnd Lib "C41W32.DLL" Alias "_C41_CycleSlideEnd@0" ()
    Public Declare Sub C41_CycleSlideMiddle Lib "C41W32.DLL" Alias "_C41_CycleSlideMiddle@12" (ByVal index As UInt32, ByVal count As UInt32, ByVal conflicts As UInt32)
    Public Declare Sub C41_CycleSlideStart Lib "C41W32.DLL" Alias "_C41_CycleSlideStart@4" (ByVal factor As UInt32)
    Public Declare Sub C41_CycleSort Lib "C41W32.DLL" Alias "_C41_CycleSort@0" ()
    Public Declare Function C41_CycleToBit Lib "C41W32.DLL" Alias "_C41_CycleToBit@4" (ByVal value As UInt32) As UInt32
    Public Declare Function C41_CycleToMsec Lib "C41W32.DLL" Alias "_C41_CycleToMsec@4" (ByVal value As UInt32) As UInt32
    Public Declare Sub C41_CycleUnsort Lib "C41W32.DLL" Alias "_C41_CycleUnsort@0" ()
    Public Declare Function C41_CycleWalk Lib "C41W32.DLL" Alias "_C41_CycleWalk@0" () As UInt32
    Public Declare Sub C41_DataClear Lib "C41W32.DLL" Alias "_C41_DataClear@16" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function C41_DataGet Lib "C41W32.DLL" Alias "_C41_DataGet@16" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_DataRead Lib "C41W32.DLL" Alias "_C41_DataRead@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_DataSet Lib "C41W32.DLL" Alias "_C41_DataSet@16" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Sub C41_DataWrite Lib "C41W32.DLL" Alias "_C41_DataWrite@16" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
    Public Declare Function C41_Div Lib "C41W32.DLL" Alias "_C41_Div@8" (ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
    Public Declare Function C41_DPMIAllocSel Lib "C41W32.DLL" Alias "_C41_DPMIAllocSel@4" (ByVal segval As UInt16) As UInt16
    Public Declare Function C41_DPMIDosAlloc Lib "C41W32.DLL" Alias "_C41_DPMIDosAlloc@4" (ByVal paras As UInt16) As UInt32
    Public Declare Function C41_DPMIDosFree Lib "C41W32.DLL" Alias "_C41_DPMIDosFree@4" (ByVal selector As UInt16) As UInt16
    Public Declare Sub C41_DPMIFreeSel Lib "C41W32.DLL" Alias "_C41_DPMIFreeSel@4" (ByVal selector As UInt16)
    Public Declare Function C41_DPMIIntSim Lib "C41W32.DLL" Alias "_C41_DPMIIntSim@8" (ByVal intnum As UInt16, ByVal dpmireg As IntPtr) As UInt16
    Public Declare Function C41_DPMIPresent Lib "C41W32.DLL" Alias "_C41_DPMIPresent@0" () As UInt16
    Public Declare Function C41_DspIntmClear Lib "C41W32.DLL" Alias "_C41_DspIntmClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_DspIntmSet Lib "C41W32.DLL" Alias "_C41_DspIntmSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_DspXfClear Lib "C41W32.DLL" Alias "_C41_DspXfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_DspXfSet Lib "C41W32.DLL" Alias "_C41_DspXfSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_ErrDesc Lib "C41W32.DLL" Alias "_C41_ErrDesc@4" (ByVal errval As Int32) As UInt32
    Public Declare Function C41_ErrDescStr Lib "C41W32.DLL" Alias "_C41_ErrDescStr@4" (ByVal errval As Int32) As UInt32
    Public Declare Function C41_ErrName Lib "C41W32.DLL" Alias "_C41_ErrName@4" (ByVal errval As Int32) As UInt32
    Public Declare Sub C41_ExpandMant Lib "C41W32.DLL" Alias "_C41_ExpandMant@8" (ByRef mant As Int32, ByRef exp As Int32)
    Public Declare Function C41_ExtDinWr Lib "C41W32.DLL" Alias "_C41_ExtDinWr@12" (ByVal dinvalue As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub C41_FileClose Lib "C41W32.DLL" Alias "_C41_FileClose@4" (ByVal handle As Int32)
    Public Declare Function C41_FileErr Lib "C41W32.DLL" Alias "_C41_FileErr@0" () As Int32
    Public Declare Sub C41_FileErrClr Lib "C41W32.DLL" Alias "_C41_FileErrClr@0" ()
    Public Declare Sub C41_FileErrSet Lib "C41W32.DLL" Alias "_C41_FileErrSet@0" ()
    Public Declare Function C41_FileOpenRead Lib "C41W32.DLL" Alias "_C41_FileOpenRead@4" (ByRef filename As String) As Int32
    Public Declare Function C41_FileOpenWrite Lib "C41W32.DLL" Alias "_C41_FileOpenWrite@4" (ByRef filename As String) As Int32
    Public Declare Function C41_FileRead Lib "C41W32.DLL" Alias "_C41_FileRead@12" (ByVal handle As Int32, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function C41_FileSeek Lib "C41W32.DLL" Alias "_C41_FileSeek@8" (ByVal handle As Int32, ByVal offset As UInt32) As Int32
    Public Declare Function C41_FileTell Lib "C41W32.DLL" Alias "_C41_FileTell@4" (ByVal handle As Int32) As UInt32
    Public Declare Function C41_FileWrite Lib "C41W32.DLL" Alias "_C41_FileWrite@12" (ByVal handle As Int32, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function C41_FilterAddr Lib "C41W32.DLL" Alias "_C41_FilterAddr@16" (ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_FilterClear Lib "C41W32.DLL" Alias "_C41_FilterClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_FilterFill Lib "C41W32.DLL" Alias "_C41_FilterFill@12" (ByRef msgaddr As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_FilterRd Lib "C41W32.DLL" Alias "_C41_FilterRd@20" (ByRef msgaddr As UInt16, ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_FilterWipe Lib "C41W32.DLL" Alias "_C41_FilterWipe@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_FilterWr Lib "C41W32.DLL" Alias "_C41_FilterWr@20" (ByRef msgaddr As UInt16, ByVal labelval As Int32, ByVal sdival As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_FldGetParBit Lib "C41W32.DLL" Alias "_C41_FldGetParBit@4" (ByVal msgval As UInt32) As UInt16
    Public Declare Function C41_GetHigh Lib "C41W32.DLL" Alias "_C41_GetHigh@4" (ByVal val As UInt32) As UInt16
    Public Declare Function C41_GetLow Lib "C41W32.DLL" Alias "_C41_GetLow@4" (ByVal val As UInt32) As UInt16
    Public Declare Function C41_GlobalRd Lib "C41W32.DLL" Alias "_C41_GlobalRd@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_GlobalWr Lib "C41W32.DLL" Alias "_C41_GlobalWr@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C41_HandleAssign Lib "C41W32.DLL" Alias "_C41_HandleAssign@20" (ByVal sizval As UInt16, ByVal memval As UInt16, ByVal ioval As UInt16, ByVal irqval As UInt16, ByVal cardnum As Int32) As Int32
    Public Declare Function C41_HandleClose Lib "C41W32.DLL" Alias "_C41_HandleClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_HandleDel Lib "C41W32.DLL" Alias "_C41_HandleDel@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_HandleGet Lib "C41W32.DLL" Alias "_C41_HandleGet@20" (ByRef sizval As UInt16, ByRef memval As UInt16, ByRef ioval As UInt16, ByRef irqval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_HandleIns Lib "C41W32.DLL" Alias "_C41_HandleIns@24" (ByRef cardname As String, ByVal rcvcount As Int32, ByVal xmtcount As Int32, ByVal cardnum As Int32, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Function C41_HandleOkay Lib "C41W32.DLL" Alias "_C41_HandleOkay@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_HandleOpen Lib "C41W32.DLL" Alias "_C41_HandleOpen@20" (ByRef cardname As String, ByVal rcvcount As Int32, ByVal xmtcount As Int32, ByVal cardnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_HandleVer Lib "C41W32.DLL" Alias "_C41_HandleVer@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_HeapAlloc Lib "C41W32.DLL" Alias "_C41_HeapAlloc@8" (ByVal wordcount As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_HeapCheck Lib "C41W32.DLL" Alias "_C41_HeapCheck@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_HeapClear Lib "C41W32.DLL" Alias "_C41_HeapClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_HeapWipe Lib "C41W32.DLL" Alias "_C41_HeapWipe@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_InitFilt Lib "C41W32.DLL" Alias "_C41_InitFilt@12" (ByVal chanflag As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_InitHeap Lib "C41W32.DLL" Alias "_C41_InitHeap@8" (ByVal heapsize As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_InitInt Lib "C41W32.DLL" Alias "_C41_InitInt@8" (ByVal intsize As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_InitMsg Lib "C41W32.DLL" Alias "_C41_InitMsg@8" (ByVal msgcount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_InitSch Lib "C41W32.DLL" Alias "_C41_InitSch@12" (ByVal chancount As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_InitSeq Lib "C41W32.DLL" Alias "_C41_InitSeq@8" (ByVal seqsize As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_IntClear Lib "C41W32.DLL" Alias "_C41_IntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_INTDisable Lib "C41W32.DLL" Alias "_C41_INTDisable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_INTEnable Lib "C41W32.DLL" Alias "_C41_INTEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_INTEnableCond Lib "C41W32.DLL" Alias "_C41_INTEnableCond@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_IntInstall Lib "C41W32.DLL" Alias "_C41_IntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_IntUninstall Lib "C41W32.DLL" Alias "_C41_IntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_IntWipe Lib "C41W32.DLL" Alias "_C41_IntWipe@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_Invoke Lib "C41W32.DLL" Alias "_C41_Invoke@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_Invokee Lib "C41W32.DLL" Alias "_C41_Invokee@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernEEPRdsW Lib "C41W32.DLL" Alias "_C41_KernEEPRdsW@16" (ByRef bufptr As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernEEPRdW Lib "C41W32.DLL" Alias "_C41_KernEEPRdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernEEPWrsW Lib "C41W32.DLL" Alias "_C41_KernEEPWrsW@16" (ByRef bufptr As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernEEPWrW Lib "C41W32.DLL" Alias "_C41_KernEEPWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernEnd Lib "C41W32.DLL" Alias "_C41_KernEnd@4" (ByVal vxdptr As IntPtr) As Int32
    Public Declare Function C41_KernIntInstall Lib "C41W32.DLL" Alias "_C41_KernIntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernIntParam Lib "C41W32.DLL" Alias "_C41_KernIntParam@32" (ByVal clraddr As UInt32, ByVal clrwidth As UInt32, ByVal clrvalue As UInt32, ByVal stataddr As UInt32, ByVal statwidth As UInt32, ByVal statvalue As UInt32, ByVal statmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernIntUninstall Lib "C41W32.DLL" Alias "_C41_KernIntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernIORdW Lib "C41W32.DLL" Alias "_C41_KernIORdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernIOWrW Lib "C41W32.DLL" Alias "_C41_KernIOWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernMEMFillW Lib "C41W32.DLL" Alias "_C41_KernMEMFillW@16" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernMEMRdsW Lib "C41W32.DLL" Alias "_C41_KernMEMRdsW@16" (ByRef bufptr As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernMEMRdW Lib "C41W32.DLL" Alias "_C41_KernMEMRdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernMEMWrsW Lib "C41W32.DLL" Alias "_C41_KernMEMWrsW@16" (ByRef bufptr As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernMEMWrW Lib "C41W32.DLL" Alias "_C41_KernMEMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernQuick Lib "C41W32.DLL" Alias "_C41_KernQuick@8" (ByVal flag As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_KernStatusEx Lib "C41W32.DLL" Alias "_C41_KernStatusEx@16" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal index As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_ListSetRcv Lib "C41W32.DLL" Alias "_C41_ListSetRcv@12" (ByVal listaddr As UInt16, ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_ListSetXmt Lib "C41W32.DLL" Alias "_C41_ListSetXmt@12" (ByVal listaddr As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_MakeLong Lib "C41W32.DLL" Alias "_C41_MakeLong@8" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
    Public Declare Function C41_MantToAscii Lib "C41W32.DLL" Alias "_C41_MantToAscii@12" (ByRef buf As String, ByVal mant As Int32, ByVal exp As Int32) As UInt32
    Public Declare Function C41_Mask Lib "C41W32.DLL" Alias "_C41_Mask@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Sub C41_MaxMant Lib "C41W32.DLL" Alias "_C41_MaxMant@8" (ByRef mant As Int32, ByRef exp As Int32)
    Public Declare Sub C41_MemFill Lib "C41W32.DLL" Alias "_C41_MemFill@16" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C41_MemStrRd Lib "C41W32.DLL" Alias "_C41_MemStrRd@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C41_MemStrWr Lib "C41W32.DLL" Alias "_C41_MemStrWr@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C41_MEMWINRdB Lib "C41W32.DLL" Alias "_C41_MEMWINRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_MEMWINRdL Lib "C41W32.DLL" Alias "_C41_MEMWINRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C41_MEMWINRdW Lib "C41W32.DLL" Alias "_C41_MEMWINRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_MEMWINWrB Lib "C41W32.DLL" Alias "_C41_MEMWINWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub C41_MEMWINWrL Lib "C41W32.DLL" Alias "_C41_MEMWINWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub C41_MEMWINWrW Lib "C41W32.DLL" Alias "_C41_MEMWINWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub C41_MemWipe Lib "C41W32.DLL" Alias "_C41_MemWipe@4" (ByVal handleval As UInt32)
    Public Declare Function C41_Mod Lib "C41W32.DLL" Alias "_C41_Mod@8" (ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
    Public Declare Function C41_MsgAddr Lib "C41W32.DLL" Alias "_C41_MsgAddr@8" (ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_MsgArincPeek Lib "C41W32.DLL" Alias "_C41_MsgArincPeek@8" (ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub C41_MsgArincPoke Lib "C41W32.DLL" Alias "_C41_MsgArincPoke@12" (ByVal msgval As UInt32, ByVal msgnum As Int32, ByVal handleval As UInt32)
    Public Declare Function C41_MsgClear Lib "C41W32.DLL" Alias "_C41_MsgClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_MsgDisable Lib "C41W32.DLL" Alias "_C41_MsgDisable@8" (ByVal msgnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_MsgEnable Lib "C41W32.DLL" Alias "_C41_MsgEnable@8" (ByVal msgnum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_MsgEncoderPeek Lib "C41W32.DLL" Alias "_C41_MsgEncoderPeek@8" (ByVal msgnum As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub C41_MsgEncoderPoke Lib "C41W32.DLL" Alias "_C41_MsgEncoderPoke@12" (ByVal msgval As UInt32, ByVal msgnum As Int32, ByVal handleval As UInt32)
    Public Declare Function C41_MsgReset Lib "C41W32.DLL" Alias "_C41_MsgReset@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_MsgWipe Lib "C41W32.DLL" Alias "_C41_MsgWipe@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_Mul Lib "C41W32.DLL" Alias "_C41_Mul@8" (ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
    Public Declare Sub C41_NormalMant Lib "C41W32.DLL" Alias "_C41_NormalMant@8" (ByRef mant As Int32, ByRef exp As Int32)
    Public Declare Function C41_PortRd Lib "C41W32.DLL" Alias "_C41_PortRd@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_PortWr Lib "C41W32.DLL" Alias "_C41_PortWr@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C41_ProgRd Lib "C41W32.DLL" Alias "_C41_ProgRd@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_ProgWr Lib "C41W32.DLL" Alias "_C41_ProgWr@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C41_RAMRdB Lib "C41W32.DLL" Alias "_C41_RAMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_RAMRdL Lib "C41W32.DLL" Alias "_C41_RAMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C41_RAMRdW Lib "C41W32.DLL" Alias "_C41_RAMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C41_RAMWrB Lib "C41W32.DLL" Alias "_C41_RAMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub C41_RAMWrL Lib "C41W32.DLL" Alias "_C41_RAMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub C41_RAMWrW Lib "C41W32.DLL" Alias "_C41_RAMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function C41_SchedAddr Lib "C41W32.DLL" Alias "_C41_SchedAddr@12" (ByVal schindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_SchedClear Lib "C41W32.DLL" Alias "_C41_SchedClear@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedFixedGap Lib "C41W32.DLL" Alias "_C41_SchedFixedGap@12" (ByVal gapval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedInsert Lib "C41W32.DLL" Alias "_C41_SchedInsert@20" (ByVal schflag As UInt16, ByVal schopcode As UInt16, ByVal schoperand As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedNop Lib "C41W32.DLL" Alias "_C41_SchedNop@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedRd Lib "C41W32.DLL" Alias "_C41_SchedRd@16" (ByRef valueptr As UInt16, ByVal schindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedUser Lib "C41W32.DLL" Alias "_C41_SchedUser@12" (ByVal useraddr As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedWipe Lib "C41W32.DLL" Alias "_C41_SchedWipe@8" (ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SchedWr Lib "C41W32.DLL" Alias "_C41_SchedWr@16" (ByRef valueptr As UInt16, ByVal schindex As Int32, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SeqInterval Lib "C41W32.DLL" Alias "_C41_SeqInterval@8" (ByVal interval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SeqIsRunning Lib "C41W32.DLL" Alias "_C41_SeqIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_SeqRdEx Lib "C41W32.DLL" Alias "_C41_SeqRdEx@12" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function C41_SeqStart Lib "C41W32.DLL" Alias "_C41_SeqStart@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_SeqStop Lib "C41W32.DLL" Alias "_C41_SeqStop@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C41_SeqWipe Lib "C41W32.DLL" Alias "_C41_SeqWipe@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C41_Shl Lib "C41W32.DLL" Alias "_C41_Shl@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function C41_Shr Lib "C41W32.DLL" Alias "_C41_Shr@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function C41_SignMant Lib "C41W32.DLL" Alias "_C41_SignMant@4" (ByRef str As String) As UInt16
    Public Declare Function C41_ValAsciiCmpi Lib "C41W32.DLL" Alias "_C41_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Int32
    Public Declare Function C41_ValAsciiCpy Lib "C41W32.DLL" Alias "_C41_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Int32) As UInt32
    Public Declare Sub C41_ValAsciiTrimLead Lib "C41W32.DLL" Alias "_C41_ValAsciiTrimLead@4" (ByRef buf As String)
    Public Declare Sub C41_ValAsciiTrimTrail Lib "C41W32.DLL" Alias "_C41_ValAsciiTrimTrail@4" (ByRef buf As String)
    Public Declare Function C41_ValFromAscii Lib "C41W32.DLL" Alias "_C41_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
    Public Declare Function C41_ValIncAscii Lib "C41W32.DLL" Alias "_C41_ValIncAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function C41_ValInccAscii Lib "C41W32.DLL" Alias "_C41_ValInccAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function C41_ValIsLower Lib "C41W32.DLL" Alias "_C41_ValIsLower@4" (ByVal value As Int32) As Int32
    Public Declare Function C41_ValLenAscii Lib "C41W32.DLL" Alias "_C41_ValLenAscii@8" (ByVal numbits As Int32, ByVal radixval As Int32) As Int32
    Public Declare Function C41_ValToAscii Lib "C41W32.DLL" Alias "_C41_ValToAscii@16" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
    Public Declare Function C41_ValToUpper Lib "C41W32.DLL" Alias "_C41_ValToUpper@4" (ByVal value As Int32) As Int32
    Public Declare Function C41_Wipe Lib "C41W32.DLL" Alias "_C41_Wipe@4" (ByVal handleval As UInt32) As Int32

    Public Const SDI00 As UInt16 = &H1   '//Enable SDI00
    Public Const SDI01 As UInt16 = &H2   '//Enable SDI01
    Public Const SDI10 As UInt16 = &H4   '//Enable SDI10
    Public Const SDI11 As UInt16 = &H8   '//Enable SDI11
    Public Const SDIALL As UInt16 = &HF  '//Enable all SDIs

    Public Const RCVCH0 As Int16 = 0    '//Receive  channel 0
    Public Const RCVCH1 As Int16 = 1    '//Receive  channel 1
    Public Const RCVCH2 As Int16 = 2    '//Receive  channel 2
    Public Const RCVCH3 As Int16 = 3    '//Receive  channel 3
    Public Const XMTCH0 As Int16 = 4    '//Transmit channel 0
    Public Const XMTCH1 As Int16 = 5    '//Transmit channel 1

    Public Const RCH0 As Int16 = 0  '//Receive  channel 0
    Public Const RCH1 As Int16 = 1  '//Receive  channel 1
    Public Const RCH2 As Int16 = 2  '//Receive  channel 2
    Public Const RCH717 As Int16 = 2    '//Receive  717 channel (2)
    Public Const RCH3 As Int16 = 3  '//Receive  channel 3
    Public Const TCH4 As Int16 = 4  '//Transmit channel 0
    Public Const TCH5 As Int16 = 5  '//Transmit channel 1

    Public Const BADCH As Int16 = 0 '//Missing channel
    Public Const RCVCH As Int16 = 1 '//Receive channel
    Public Const XMTCH As Int16 = 2 '//Transmit channel
    Public Const RCV717CH As Int16 = 3  '//717 Receive Channel

    Public Const LIST_STAT_EMPTY As Int16 = 0   '//List buffer is empty
    Public Const LIST_STAT_PARTIAL As Int16 = 1 '//List buffer is partially filled
    Public Const LIST_STAT_FULL As Int16 = 2    '//List buffer is full

    Public Const PROC_PRE As Int16 = 1  '//Pre-process
    Public Const PROC_POST As Int16 = 2 '//Post-process
    Public Const PROC_FORE As Int16 = 3 '//Foreground process

    Public Const CHCFG_DEFAULT As UInt32 = &H0L  '//Select all default settings (default)
    Public Const CHCFG_NOEVEN As UInt32 = &H1L   '//Reject even parity messages (RCV)
    Public Const CHCFG_PAREVEN As UInt32 = &H2L  '//Transmit messages with even parity (XMT)
    Public Const CHCFG_HIGHSPEED As UInt32 = &H4L    '//Select high speed (XMT & RCV)
    Public Const CHCFG_LOWSPEED As UInt32 = &H0L '//Select low speed (XMT & RCV)
    Public Const CHCFG_ACTIVE As UInt32 = &H8L   '//Enable channel activity (XMT & RCV)
    Public Const CHCFG_INACTIVE As UInt32 = &H0L '//Disable channel activity (XMT & RCV)
    Public Const CHCFG_SYNC As UInt32 = &H10L '//Enable sync output (XMT & RCV)
    Public Const CHCFG_SYNCOFF As UInt32 = &H0L  '//Disable sync output (XMT & RCV)
    Public Const CHCFG_SERVICE As UInt32 = &H20L  '//Enable message service count
    Public Const CHCFG_SERVICEOFF As UInt32 = &H0L   '//Disable message service count
    Public Const CHCFG_TIMETAG As UInt32 = &H40L  '//Enable time-tag in message record
    Public Const CHCFG_TIMETAGOFF As UInt32 = &H0L   '//Disable time-tag in message record
    Public Const CHCFG_ELAPSE As UInt32 = &H80L   '//Enable elapse time
    Public Const CHCFG_ELAPSEOFF As UInt32 = &H0L    '//Disable elapse time
    Public Const CHCFG_MAXMIN As UInt32 = &H100L   '//Enable repetition rate monitoring
    Public Const CHCFG_MAXMINOFF As UInt32 = &H0L    '//Disable repetition rate monitoring
    Public Const CHCFG_WRAPTEST As UInt32 = &H200L '//Enable internal wraparound
    Public Const CHCFG_WRAPTESTOFF As UInt32 = &H0L  '//Disable internal wraparound
    Public Const CHCFG_SDI00 As UInt32 = &H1000L    '//Enable SDI00 only (RCV)
    Public Const CHCFG_SDI01 As UInt32 = &H2000L    '//Enable SDI01 only (RCV)
    Public Const CHCFG_SDI10 As UInt32 = &H4000L    '//Enable SDI10 only (RCV)
    Public Const CHCFG_SDI11 As UInt32 = &H8000L    '//Enable SDI11 only (RCV)
    Public Const CHCFG_SDIALL As UInt32 = &H0L   '//Receive messages with any SDI (RCV)
    Public Const CHCFG_SEQSEL As UInt32 = &H10000L   '//Turn on sequential record for channel
    Public Const CHCFG_SEQALL As UInt32 = &H20000L   '//Turn on sequential record monitoring for channel
    Public Const CHCFG_SEQOFF As UInt32 = &H0L   '//Turn off sequential record for channel
    Public Const CHCFG_INTSCH As UInt32 = &H100000L   '//Enable schedule interrupts
    Public Const CHCFG_INTHALT As UInt32 = &H200000L  '//Enable schedule stop interrupt
    Public Const CHCFG_INTPAUSE As UInt32 = &H400000L '//Enable schedule stop interrupt
    Public Const CHCFG_INTLIST As UInt32 = &H1000000L  '//Enable list buffer interrupt
    Public Const CHCFG_INTPARITY As UInt32 = &H2000000L    '//Enable parity interrupt
    Public Const CHCFG_INTNONE As UInt32 = &H0L  '//Disable interrupts for channel
    Public Const CHCFG_EXTTRIG As UInt32 = &H10000000L  '//Enable external trigger
    Public Const CHCFG_EXTSTART As UInt32 = &H20000000L '//Enable external start
    Public Const CHCFG_EXTOFF As UInt32 = &H0L   '//Disable external trigger

    Public Const CHCFG717_DEFAULT As UInt32 = &H0L   '//Select all default settings (default)
    Public Const CHCFG717_SYNC As UInt32 = &H10L  '//Enable sync output (XMT & RCV)
    Public Const CHCFG717_TIMETAG As UInt32 = &H40L   '//Enable time-tag in message record
    Public Const CHCFG717_SEQSEL As UInt32 = &H10000L    '//Turn on sequential record for channel
    Public Const CHCFG717_SEQALL As UInt32 = &H20000L    '//Turn on sequential record monitoring for channel
    Public Const CHCFG717_64WPS As UInt32 = &H1000L '//Select speed of 64WPS
    Public Const CHCFG717_128WPS As UInt32 = &H2000L    '//Select speed of 128WPS
    Public Const CHCFG717_256WPS As UInt32 = &H0L    '//Select speed of 256WPS (default)
    Public Const CHCFG717_512WPS As UInt32 = &H4000L    '//Select speed of 512WPS
    Public Const CHCFG717_1024WPS As UInt32 = &H8000L   '//Select speed of 1024WPS

    Public Const WRDCFG_DEFAULT As UInt16 = &H0  '//Disable message record options
    Public Const WRDCFG_SFINT As UInt16 = &H4    '//Enable message interrupt
    Public Const WRDCFG_SFINTOFF As UInt16 = &H0 '//Disable message interrupt
    Public Const WRDCFG_WRDINT As UInt16 = &H2   '//Enable skip message record
    Public Const WRDCFG_WRDINTOFF As UInt16 = &H0    '//Disable skip message record
    Public Const WRDCFG_SEQ As UInt16 = &H1  '//Enable sequential record
    Public Const WRDCFG_SEQOFF As UInt16 = &H0   '//Disable sequential record

    Public Const SEQCFG_DEFAULT As UInt16 = &H0  '//Turn off sequential record
    Public Const SEQCFG_OFF As UInt16 = &H0  '//Turn off sequential record
    Public Const SEQCFG_SEL As UInt16 = &H1  '//Turn on sequential record for channel
    Public Const SEQCFG_ALL As UInt16 = &H2  '//Turn on sequential record monitoring for channel
    Public Const SEQCFG_INT As UInt16 = &H10  '//Enable sequential record full interrupt
    Public Const SEQCFG_INTOFF As UInt16 = &H0   '//Disable sequential record full interrupt
    Public Const SEQCFG_WRAP As UInt16 = &H20 '//Enable sequential record wrap mode
    Public Const SEQCFG_WRAPOFF As UInt16 = &H0  '//Disable sequential record wrap mode
    Public Const SEQCFG_DELTA As UInt16 = &H40    '//Enable sequential record delta mode
    Public Const SEQCFG_DELTAOFF As UInt16 = &H0 '//Disable sequential record delta mode
    Public Const SEQCFG_INTERVAL As UInt16 = &H80 '//Enable sequential record interval mode
    Public Const SEQCFG_INTERVALOFF As UInt16 = &H0  '//Disable sequential record interval mode

    Public Const MSGCFG_DEFAULT As UInt16 = &H0  '//Disable message record options
    Public Const MSGCFG_SEQ As UInt16 = &H1  '//Enable sequential record
    Public Const MSGCFG_SEQOFF As UInt16 = &H0   '//Disable sequential record
    Public Const MSGCFG_INT As UInt16 = &H2  '//Enable message interrupt
    Public Const MSGCFG_INTOFF As UInt16 = &H0   '//Disable message interrupt
    Public Const MSGCFG_SKIP As UInt16 = &H4 '//Enable skip message record
    Public Const MSGCFG_SKIPOFF As UInt16 = &H0  '//Disable skip message record

    Public Const OPCODE_NOP As UInt16 = &H0
    Public Const OPCODE_MESSAGE As UInt16 = &H1
    Public Const OPCODE_GAP As UInt16 = &H2
    Public Const OPCODE_LIST As UInt16 = &H3
    Public Const OPCODE_HALT As UInt16 = &H4
    Public Const OPCODE_PAUSE As UInt16 = &H5
    Public Const OPCODE_RESTART As UInt16 = &H6
    Public Const OPCODE_INTERRUPT As UInt16 = &H7
    Public Const OPCODE_USERCODE As UInt16 = &H8
    Public Const OPCODE_GOTO As UInt16 = &H9
    Public Const OPCODE_CALL As UInt16 = &HA
    Public Const OPCODE_RETURN As UInt16 = &HB
    Public Const OPCODE_DIN0 As UInt16 = &HC
    Public Const OPCODE_DIN1 As UInt16 = &HD
    Public Const OPCODE_PULSE As UInt16 = &HE

    Public Const COND_NONE As Int16 = 0
    Public Const COND_UNCOND As Int16 = 1
    Public Const COND_DIN0 As Int16 = 2
    Public Const COND_DIN1 As Int16 = 3

    Public Const REG_INT As UInt16 = &H0   '//Interrupt register
    Public Const REG_PAGE As UInt16 = &H1  '//Page register
    Public Const REG_RESV1 As UInt16 = &H2 '//Reserved register
    Public Const REG_RST As UInt16 = &H3   '//Reset register
    Public Const REG_INTC As UInt16 = &H4  '//Interrupt clear register
    Public Const REG_RESV2 As UInt16 = &H5 '//Reserved register
    Public Const REG_ERR As UInt16 = &H6   '//Error register
    Public Const REG_PWE As UInt16 = &H7   '//Prom write enable register

    Public Const REG_SRQ As UInt16 = &H3000 '//Service request register
    Public Const REG_MISC As UInt16 = &H3001    '//Miscellaneous register
    Public Const REG_INTE As UInt16 = &H3002    '//Interrupt enable register
    Public Const REG_SYNC As UInt16 = &H3003    '//Sync register
    Public Const REG_CHAN4 As UInt16 = &H3004   '//Channel 4 control register
    Public Const REG_CHAN5 As UInt16 = &H3005   '//Channel 5 control register
    Public Const REG_GAP4 As UInt16 = &H3008    '//Channel 4 gap register
    Public Const REG_GAP5 As UInt16 = &H3009    '//Channel 5 gap register
    Public Const REG_RESET As UInt16 = &H300F   '//Reset register
    Public Const REG_TTL As UInt16 = &H400A '//Time tag low word register
    Public Const REG_TTH As UInt16 = &H400B '//Time tag high word register
    Public Const REG_DAT0L As UInt16 = &H4080   '//Channel 0 low data word register
    Public Const REG_DAT0H As UInt16 = &H4081   '//Channel 0 high data word register
    Public Const REG_DAT1L As UInt16 = &H4082   '//Channel 1 low data word register
    Public Const REG_DAT1H As UInt16 = &H4083   '//Channel 1 high data word register
    Public Const REG_DAT2L As UInt16 = &H4084   '//Channel 2 low data word register
    Public Const REG_DAT2H As UInt16 = &H4085   '//Channel 2 high data word register
    Public Const REG_DAT3L As UInt16 = &H4086   '//Channel 3 low data word register
    Public Const REG_DAT3H As UInt16 = &H4087   '//Channel 3 high data word register
    Public Const REG_DAT4L As UInt16 = &H4090   '//Channel 4 low data word register
    Public Const REG_DAT4H As UInt16 = &H4091   '//Channel 4 high data word register
    Public Const REG_DAT5L As UInt16 = &H4092   '//Channel 5 low data word register
    Public Const REG_DAT5H As UInt16 = &H4093   '//Channel 5 high data word register
    Public Const REG_CTRLA As UInt16 = &H40A0   '//Channel 0,1,4 control register
    Public Const REG_CTRLB As UInt16 = &H40A1   '//Channel 0,1,5 control register

    Public Const TIMERRESOL_HIGH As Int16 = 1
    Public Const TIMERRESOL_MED As Int16 = 2
    Public Const TIMERRESOL_LOW As Int16 = 3

    Public Const ERR_NONE As Int16 = 0  '//No error
    Public Const ERR_UNKNOWN As Int16 = -1  '//An unexpected error occurred
    Public Const ERR_BADVER As Int16 = -2   '//A bad version was encountered
    Public Const ERR_NOCS As Int16 = -10    '//Card Services is not present
    Public Const ERR_NOSOCKET As Int16 = -11    '//The specified socket is not present
    Public Const ERR_NOCARD As Int16 = -12  '//Unable to find a CM429-1 card in the specified socket
    Public Const ERR_NOTSR As Int16 = -13   '//Unable to find the CM429-1 memory resident driver
    Public Const ERR_CLIENT As Int16 = -14  '//Unable to install a local client driver
    Public Const ERR_CS As Int16 = -15  '//An error was returned by Card Services
    Public Const ERR_WIN As Int16 = -16 '//Card Services could not configure the memory window, I/O window, or IRQ steering
    Public Const ERR_SEL As Int16 = -17 '//Unable to allocate a memory selector
    Public Const ERR_BADHANDLE As Int16 = -20   '//A bad handle was specified
    Public Const ERR_NOTCHAN As Int16 = -21 '//Specified channel does not exist
    Public Const ERR_NOTRCV As Int16 = -22  '//Specified channel is not a receiver channel
    Public Const ERR_NOTXMT As Int16 = -23  '//Specified channel is not a transmitter channel
    Public Const ERR_LABEL As Int16 = -24   '//Bad label parameter specified
    Public Const ERR_SDI As Int16 = -25 '//Bad SDI parameter specified
    Public Const ERR_BADMSGNUM As Int16 = -26   '//Specified message number is out of range
    Public Const ERR_BADSCHNDX As Int16 = -27   '//Specified schedule index is out of range
    Public Const ERR_SCHFULL As Int16 = -28 '//Specified schedule is full
    Public Const ERR_BADMSGPTR As Int16 = -29   '//Tried to put both user code and list buffer in message
    Public Const ERR_CORRUPT As Int16 = -31 '//Variables have been corrupted
    Public Const ERR_SELFFAIL As Int16 = -32    '//Selftest failed
    Public Const ERR_IOFAIL As Int16 = -33  '//IO selftest failed
    Public Const ERR_MEMFAIL As Int16 = -34 '//Memory selftest failed
    Public Const ERR_LOCK As Int16 = -35    '//Board is locked up
    Public Const ERR_BADTYPE As Int16 = -36 '//Bad type value specified
    Public Const ERR_FACTOR As Int16 = -41  '//A bad factor value was specified
    Public Const ERR_ZEROLEN As Int16 = -42 '//Zero length was specified
    Public Const ERR_BUFSIZE As Int16 = -43 '//Insufficient space in user buffer
    Public Const ERR_NOMSGS As Int16 = -44  '//No messages specified
    Public Const ERR_CONFLICTS As Int16 = -45   '//Unable to resolve conflicts
    Public Const ERR_RANGE As Int16 = -46   '//Schedule is out of range
    Public Const ERR_FNAME As Int16 = -50   '//Bad filenames were specified
    Public Const ERR_FRDWR As Int16 = -51   '//There was an error reading or writing the HEX file
    Public Const ERR_HEX As Int16 = -52 '//There was a bad hex character in the HEX file
    Public Const ERR_CRC As Int16 = -53 '//There was a bad checksum in the HEX file
    Public Const ERR_TYPE As Int16 = -54    '//There was a bad type value in the HEX file
    Public Const ERR_BOOTFULL As Int16 = -61    '//No space to add boot code
    Public Const ERR_BOOTNUM As Int16 = -62 '//There is no boot code with the specified number
    Public Const ERR_CISVERIFY As Int16 = -90   '//Unable to verify the value written to the CIS
    Public Const ERR_CISNONE As Int16 = -91 '//The CIS is not visible
    Public Const ERR_CISENB As Int16 = -92  '//The PWE register cannot be enabled
    Public Const ERR_CISMAGIC As Int16 = -93    '//Unable to write to the PWE register
    Public Const ERR_VXD As Int16 = -100    '//Error returned from VXD
    Public Const ERR_NOHANDLES As Int16 = -101  '//CardOpen() already has allocated too many handles
    Public Const ERR_NOIO As Int16 = -102   '//CardOpen() could not find the I/O
    Public Const ERR_NOMEM As Int16 = -103  '//CardOpen() could not find the I/O
    Public Const ERR_BAD16BIT As Int16 = -104   '//CardOpen() could not find the I/O
    Public Const ERR_NOT717RCV As Int16 = -110  '//Specified channel is not a 717 receiver channel
    Public Const ERR_SUBFRMNUM As Int16 = -111  '//Invalid 717 SubFrame number was specified or record does not exist
    Public Const ERR_WORDNUM As Int16 = -112    '//Invalid 717 Word number was specified or record does not exist
    Public Const ERR_SUBFRMREC As Int16 = -113  '//Invalid 717 SubFrame number was specified or record does not exist
    Public Const ERR_SYNCVAL As Int16 = -114    '//Invalid 717 Sync Value was specified
    Public Const ERR_NOTINSYNC As Int16 = -115  '//Not Synchronized to 717 databus

End Module
