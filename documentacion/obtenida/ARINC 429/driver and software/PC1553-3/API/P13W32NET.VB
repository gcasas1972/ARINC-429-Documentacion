Imports System
Imports System.Runtime.InteropServices

Module P13W32VB

    '/**
    '*
    '*  PC1553-3 WIN32 DRIVER  Version 1.4  (02/20/1998)
    '*  Copyright (c) 1998
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   P13W32NET.VB -- 32-bit
    '*                      PC1553-3 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  Structs used by the PC1553-3 Driver.
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
    '*  PC1553-3 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the PC1553-3 Driver.
    '*
    '**/

    Public Declare Function P13_BCConfig Lib "P13W32.DLL" Alias "_P13_BCConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCCreateMsg Lib "P13W32.DLL" Alias "_P13_BCCreateMsg@20" (ByVal configval As UInt32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_BCSchedFrame Lib "P13W32.DLL" Alias "_P13_BCSchedFrame@8" (ByVal timeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedMsg Lib "P13W32.DLL" Alias "_P13_BCSchedMsg@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedRetry Lib "P13W32.DLL" Alias "_P13_BCSchedRetry@12" (ByVal condition As UInt16, ByVal retries As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCTransmitMsg Lib "P13W32.DLL" Alias "_P13_BCTransmitMsg@8" (ByRef xmitfieldsval As XMITFIELDS, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardClose Lib "P13W32.DLL" Alias "_P13_CardClose@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardOpen Lib "P13W32.DLL" Alias "_P13_CardOpen@16" (ByVal memval As UInt32, ByVal ioval As UInt16, ByVal irqval As UInt16, ByVal drqval As UInt16) As UInt32
    Public Declare Function P13_CardOpenP12 Lib "P13W32.DLL" Alias "_P13_CardOpenP12@16" (ByVal memval As UInt32, ByVal ioval As UInt16, ByVal irqval As UInt16, ByVal drqval As UInt16) As UInt32
    Public Declare Sub P13_CardReset Lib "P13W32.DLL" Alias "_P13_CardReset@4" (ByVal handleval As UInt32)
    Public Declare Function P13_CardStart Lib "P13W32.DLL" Alias "_P13_CardStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardStop Lib "P13W32.DLL" Alias "_P13_CardStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ErrorCtrl Lib "P13W32.DLL" Alias "_P13_ErrorCtrl@8" (ByVal ctrlval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ErrorDefine Lib "P13W32.DLL" Alias "_P13_ErrorDefine@24" (ByVal defineval As UInt32, ByVal errvalue As UInt16, ByVal countval As Int32, ByVal wordpos As UInt16, ByVal bitpos As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ErrorSent Lib "P13W32.DLL" Alias "_P13_ErrorSent@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ErrorTagBC Lib "P13W32.DLL" Alias "_P13_ErrorTagBC@12" (ByVal tagval As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ErrorTagRT Lib "P13W32.DLL" Alias "_P13_ErrorTagRT@24" (ByVal tagval As Int32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonConfig Lib "P13W32.DLL" Alias "_P13_MonConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonFilterSA Lib "P13W32.DLL" Alias "_P13_MonFilterSA@24" (ByVal taval As Int32, ByVal rcvsamask As UInt32, ByVal xmtsamask As UInt32, ByVal rcvmcmask As UInt32, ByVal xmtmcmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonFilterTA Lib "P13W32.DLL" Alias "_P13_MonFilterTA@8" (ByVal tamask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonIsRunning Lib "P13W32.DLL" Alias "_P13_MonIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonRd Lib "P13W32.DLL" Alias "_P13_MonRd@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_MsgDataRd Lib "P13W32.DLL" Alias "_P13_MsgDataRd@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Sub P13_MsgDataWr Lib "P13W32.DLL" Alias "_P13_MsgDataWr@16" (ByRef buf As UInt16, ByVal count As Int32, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_MsgFieldRd Lib "P13W32.DLL" Alias "_P13_MsgFieldRd@12" (ByVal fieldtype As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_MsgFieldWr Lib "P13W32.DLL" Alias "_P13_MsgFieldWr@16" (ByVal fieldval As UInt32, ByVal fieldtype As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_RTConfig Lib "P13W32.DLL" Alias "_P13_RTConfig@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_RTCreateMsg Lib "P13W32.DLL" Alias "_P13_RTCreateMsg@24" (ByVal configval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_RTGetMsg Lib "P13W32.DLL" Alias "_P13_RTGetMsg@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_RTSWDWr Lib "P13W32.DLL" Alias "_P13_RTSWDWr@12" (ByVal swdval As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ValPackCWD Lib "P13W32.DLL" Alias "_P13_ValPackCWD@16" (ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal wcval As Int32) As UInt16
    Public Declare Sub P13_ValUnpackCWD Lib "P13W32.DLL" Alias "_P13_ValUnpackCWD@20" (ByVal cwdval As UInt16, ByRef taval As Int32, ByRef trflag As Int32, ByRef saval As Int32, ByRef wcval As Int32)
    Public Declare Function PC1553_Bitset Lib "P13W32.DLL" Alias "_PC1553_Bitset@12" (ByVal wordval As UInt16, ByVal bitvalue As Int32, ByVal bitnum As Int32) As UInt16
    Public Declare Function PC1553_Bittest Lib "P13W32.DLL" Alias "_PC1553_Bittest@8" (ByVal wordval As UInt16, ByVal bitnum As Int32) As Int32
    Public Declare Sub PC1553_Clearlist Lib "P13W32.DLL" Alias "_PC1553_Clearlist@4" (ByVal fh As Int32)
    Public Declare Sub PC1553_Config Lib "P13W32.DLL" Alias "_PC1553_Config@16" (ByVal reg0 As Int32, ByVal reg1 As Int32, ByVal reg2 As Int32, ByVal portval As Int32)
    Public Declare Function PC1553_Execute Lib "P13W32.DLL" Alias "_PC1553_Execute@24" (ByRef nameptr As String, ByRef swdptr As UInt16, ByVal dwdptr As IntPtr, ByVal segval As Int32, ByVal portval As Int32, ByVal fh As Int32) As Int32
    Public Declare Sub PC1553_Freedrv Lib "P13W32.DLL" Alias "_PC1553_Freedrv@0" ()
    Public Declare Function PC1553_Loadlist Lib "P13W32.DLL" Alias "_PC1553_Loadlist@4" (ByRef filename As String) As Int32
    Public Declare Function PC1553_Maskshift Lib "P13W32.DLL" Alias "_PC1553_Maskshift@12" (ByVal inputval As UInt16, ByVal startbit As Int32, ByVal lengthval As Int32) As UInt16
    Public Declare Function PC1553_Packcwd Lib "P13W32.DLL" Alias "_PC1553_Packcwd@16" (ByVal taval As Int32, ByVal trval As Int32, ByVal saval As Int32, ByVal wcval As Int32) As UInt16
    Public Declare Function PC1553_Packwd Lib "P13W32.DLL" Alias "_PC1553_Packwd@16" (ByVal inputval As UInt16, ByVal oldval As UInt16, ByVal startbit As Int32, ByVal lengthval As Int32) As UInt16
    Public Declare Sub PC1553_Readbcdwd Lib "P13W32.DLL" Alias "_PC1553_Readbcdwd@16" (ByVal countval As Int32, ByVal startval As Int32, ByVal destptr As IntPtr, ByVal segval As Int32)
    Public Declare Function PC1553_Readresp Lib "P13W32.DLL" Alias "_PC1553_Readresp@4" (ByVal portval As Int32) As Int32
    Public Declare Sub PC1553_Readrtdwd Lib "P13W32.DLL" Alias "_PC1553_Readrtdwd@24" (ByVal trval As Int32, ByVal saval As Int32, ByVal countval As Int32, ByVal startval As Int32, ByVal destptr As IntPtr, ByVal segval As Int32)
    Public Declare Function PC1553_Readwd Lib "P13W32.DLL" Alias "_PC1553_Readwd@8" (ByVal offset As Int32, ByVal segval As Int32) As Int32
    Public Declare Function PC1553_Transmit Lib "P13W32.DLL" Alias "_PC1553_Transmit@4" (ByVal portval As Int32) As Int32
    Public Declare Sub PC1553_Writebcdwd Lib "P13W32.DLL" Alias "_PC1553_Writebcdwd@16" (ByVal countval As Int32, ByVal startval As Int32, ByVal srcptr As IntPtr, ByVal segval As Int32)
    Public Declare Sub PC1553_Writertdwd Lib "P13W32.DLL" Alias "_PC1553_Writertdwd@24" (ByVal trval As Int32, ByVal saval As Int32, ByVal countval As Int32, ByVal startval As Int32, ByVal srcptr As IntPtr, ByVal segval As Int32)
    Public Declare Sub PC1553_Writewd Lib "P13W32.DLL" Alias "_PC1553_Writewd@12" (ByVal value As Int32, ByVal offset As Int32, ByVal segval As Int32)
    Public Declare Function P12_Bitset Lib "P13W32.DLL" Alias "_P12_Bitset@12" (ByVal wordval As UInt16, ByVal bitvalue As Int32, ByVal bitnum As Int32) As UInt16
    Public Declare Function P12_Bittest Lib "P13W32.DLL" Alias "_P12_Bittest@8" (ByVal wordval As UInt16, ByVal bitnum As Int32) As Int32
    Public Declare Function P12_Checklist Lib "P13W32.DLL" Alias "_P12_Checklist@4" (ByVal fh As Int32) As Int32
    Public Declare Sub P12_Clearlist Lib "P13W32.DLL" Alias "_P12_Clearlist@4" (ByVal fh As Int32)
    Public Declare Sub P12_Config Lib "P13W32.DLL" Alias "_P12_Config@16" (ByVal reg0 As Int32, ByVal reg1 As Int32, ByVal reg2 As Int32, ByVal handleval As UInt32)
    Public Declare Function P12_Execconfig Lib "P13W32.DLL" Alias "_P12_Execconfig@12" (ByRef nameptr As String, ByVal fh As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P12_Execmsg Lib "P13W32.DLL" Alias "_P12_Execmsg@20" (ByRef nameptr As String, ByVal bufptr As IntPtr, ByRef swdptr As UInt16, ByVal fh As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P12_Execute Lib "P13W32.DLL" Alias "_P12_Execute@20" (ByRef nameptr As String, ByRef swdptr As UInt16, ByVal dwdptr As IntPtr, ByVal fh As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub P12_Freedrv Lib "P13W32.DLL" Alias "_P12_Freedrv@0" ()
    Public Declare Function P12_In Lib "P13W32.DLL" Alias "_P12_In@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P12_Loadlist Lib "P13W32.DLL" Alias "_P12_Loadlist@4" (ByRef filename As String) As Int32
    Public Declare Function P12_Locate Lib "P13W32.DLL" Alias "_P12_Locate@12" (ByVal keytype As Int32, ByRef nameptr As String, ByVal fh As Int32) As Int32
    Public Declare Function P12_Maskshift Lib "P13W32.DLL" Alias "_P12_Maskshift@12" (ByVal inputval As UInt16, ByVal startbit As Int32, ByVal lengthval As Int32) As UInt16
    Public Declare Sub P12_Out Lib "P13W32.DLL" Alias "_P12_Out@12" (ByVal dataval As Int32, ByVal addrval As Int32, ByVal handleval As UInt32)
    Public Declare Function P12_Packcwd Lib "P13W32.DLL" Alias "_P12_Packcwd@16" (ByVal taval As Int32, ByVal trval As Int32, ByVal saval As Int32, ByVal wcval As Int32) As UInt16
    Public Declare Function P12_Packwd Lib "P13W32.DLL" Alias "_P12_Packwd@16" (ByVal inputval As UInt16, ByVal oldval As UInt16, ByVal startbit As Int32, ByVal lengthval As Int32) As UInt16
    Public Declare Function P12_Readb Lib "P13W32.DLL" Alias "_P12_Readb@4" (ByVal fh As Int32) As Int32
    Public Declare Sub P12_Readbcdwd Lib "P13W32.DLL" Alias "_P12_Readbcdwd@16" (ByVal countval As Int32, ByVal startval As Int32, ByVal destptr As IntPtr, ByVal handleval As UInt32)
    Public Declare Function P12_Readresp Lib "P13W32.DLL" Alias "_P12_Readresp@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub P12_Readrtdwd Lib "P13W32.DLL" Alias "_P12_Readrtdwd@24" (ByVal trval As Int32, ByVal saval As Int32, ByVal countval As Int32, ByVal startval As Int32, ByVal destptr As IntPtr, ByVal handleval As UInt32)
    Public Declare Function P12_Readw Lib "P13W32.DLL" Alias "_P12_Readw@4" (ByVal fh As Int32) As Int32
    Public Declare Function P12_Readwd Lib "P13W32.DLL" Alias "_P12_Readwd@8" (ByVal offset As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub P12_Readwds Lib "P13W32.DLL" Alias "_P12_Readwds@16" (ByVal offval As Int32, ByVal destptr As IntPtr, ByVal cntval As Int32, ByVal handleval As UInt32)
    Public Declare Function P12_Transmit Lib "P13W32.DLL" Alias "_P12_Transmit@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub P12_Writebcdwd Lib "P13W32.DLL" Alias "_P12_Writebcdwd@16" (ByVal countval As Int32, ByVal startval As Int32, ByVal srcptr As IntPtr, ByVal handleval As UInt32)
    Public Declare Sub P12_Writertdwd Lib "P13W32.DLL" Alias "_P12_Writertdwd@24" (ByVal trval As Int32, ByVal saval As Int32, ByVal countval As Int32, ByVal startval As Int32, ByVal srcptr As IntPtr, ByVal handleval As UInt32)
    Public Declare Sub P12_Writewd Lib "P13W32.DLL" Alias "_P12_Writewd@12" (ByVal value As Int32, ByVal offset As Int32, ByVal handleval As UInt32)
    Public Declare Sub P12_Writewds Lib "P13W32.DLL" Alias "_P12_Writewds@16" (ByVal offval As Int32, ByVal srcptr As IntPtr, ByVal cntval As Int32, ByVal handleval As UInt32)
    Public Declare Function P13_AddrDSP Lib "P13W32.DLL" Alias "_P13_AddrDSP@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function P13_AddrHost Lib "P13W32.DLL" Alias "_P13_AddrHost@4" (ByVal addr As UInt32) As UInt32
    Public Declare Function P13_BCConfigEx Lib "P13W32.DLL" Alias "_P13_BCConfigEx@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCConfigMsg Lib "P13W32.DLL" Alias "_P13_BCConfigMsg@12" (ByVal configval As UInt32, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_BCSchedAgain Lib "P13W32.DLL" Alias "_P13_BCSchedAgain@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedBranch Lib "P13W32.DLL" Alias "_P13_BCSchedBranch@12" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedBranchDin0 Lib "P13W32.DLL" Alias "_P13_BCSchedBranchDin0@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedBranchDin1 Lib "P13W32.DLL" Alias "_P13_BCSchedBranchDin1@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedBranchEx Lib "P13W32.DLL" Alias "_P13_BCSchedBranchEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedBuild Lib "P13W32.DLL" Alias "_P13_BCSchedBuild@16" (ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef freq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedCall Lib "P13W32.DLL" Alias "_P13_BCSchedCall@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedCallCond Lib "P13W32.DLL" Alias "_P13_BCSchedCallCond@12" (ByVal condition As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedCallCondEx Lib "P13W32.DLL" Alias "_P13_BCSchedCallCondEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedEntry Lib "P13W32.DLL" Alias "_P13_BCSchedEntry@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedFrameEnd Lib "P13W32.DLL" Alias "_P13_BCSchedFrameEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedFrameStart Lib "P13W32.DLL" Alias "_P13_BCSchedFrameStart@8" (ByVal timeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedGap Lib "P13W32.DLL" Alias "_P13_BCSchedGap@8" (ByVal gapval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedGoto Lib "P13W32.DLL" Alias "_P13_BCSchedGoto@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedHalt Lib "P13W32.DLL" Alias "_P13_BCSchedHalt@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedInt Lib "P13W32.DLL" Alias "_P13_BCSchedInt@8" (ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedIntCond Lib "P13W32.DLL" Alias "_P13_BCSchedIntCond@12" (ByVal condition As UInt16, ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedIntCondEx Lib "P13W32.DLL" Alias "_P13_BCSchedIntCondEx@20" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal tagval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedNop Lib "P13W32.DLL" Alias "_P13_BCSchedNop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedPause Lib "P13W32.DLL" Alias "_P13_BCSchedPause@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedPulse Lib "P13W32.DLL" Alias "_P13_BCSchedPulse@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedPulse0 Lib "P13W32.DLL" Alias "_P13_BCSchedPulse0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedPulse1 Lib "P13W32.DLL" Alias "_P13_BCSchedPulse1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedRestart Lib "P13W32.DLL" Alias "_P13_BCSchedRestart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedRetryEx Lib "P13W32.DLL" Alias "_P13_BCSchedRetryEx@24" (ByVal condition1 As UInt16, ByVal condition2 As UInt16, ByVal condition3 As UInt16, ByVal retryflag As UInt16, ByVal retries As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedReturn Lib "P13W32.DLL" Alias "_P13_BCSchedReturn@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSchedUser Lib "P13W32.DLL" Alias "_P13_BCSchedUser@8" (ByVal useraddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSetEntry Lib "P13W32.DLL" Alias "_P13_BCSetEntry@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BCSetTimeout Lib "P13W32.DLL" Alias "_P13_BCSetTimeout@8" (ByVal timeoutval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BlkAddr Lib "P13W32.DLL" Alias "_P13_BlkAddr@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_BlkOptRd Lib "P13W32.DLL" Alias "_P13_BlkOptRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_BlkOptWr Lib "P13W32.DLL" Alias "_P13_BlkOptWr@12" (ByVal rtopt As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BlkPtrRd Lib "P13W32.DLL" Alias "_P13_BlkPtrRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub P13_BlkPtrWr Lib "P13W32.DLL" Alias "_P13_BlkPtrWr@12" (ByVal descaddr As UInt32, ByVal taval As Int32, ByVal handleval As UInt32)
    Public Declare Function P13_BlkRd Lib "P13W32.DLL" Alias "_P13_BlkRd@12" (ByRef block As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BlkReset Lib "P13W32.DLL" Alias "_P13_BlkReset@8" (ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BlkSWDRd Lib "P13W32.DLL" Alias "_P13_BlkSWDRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_BlkSWDWr Lib "P13W32.DLL" Alias "_P13_BlkSWDWr@12" (ByVal swdval As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BlkWipe Lib "P13W32.DLL" Alias "_P13_BlkWipe@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_BlkWr Lib "P13W32.DLL" Alias "_P13_BlkWr@12" (ByRef block As UInt16, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardBoot Lib "P13W32.DLL" Alias "_P13_CardBoot@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardCloseAll Lib "P13W32.DLL" Alias "_P13_CardCloseAll@0" () As Int32
    Public Declare Function P13_CardConfig Lib "P13W32.DLL" Alias "_P13_CardConfig@16" (ByVal enableflag As Int32, ByVal command As UInt16, ByVal taval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardGetInfo Lib "P13W32.DLL" Alias "_P13_CardGetInfo@8" (ByVal infotype As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_CardGetInfoEx Lib "P13W32.DLL" Alias "_P13_CardGetInfoEx@20" (ByRef bufmodel As UInt16, ByVal bufmodelcount As UInt16, ByRef buffeature As UInt16, ByVal buffeaturecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub P13_CardInit Lib "P13W32.DLL" Alias "_P13_CardInit@0" ()
    Public Declare Function P13_CardIsRunning Lib "P13W32.DLL" Alias "_P13_CardIsRunning@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardNop Lib "P13W32.DLL" Alias "_P13_CardNop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardOpenEx Lib "P13W32.DLL" Alias "_P13_CardOpenEx@20" (ByRef cardname As String, ByVal memval As UInt32, ByVal ioval As UInt16, ByVal irqval As UInt16, ByVal drqval As UInt16) As UInt32
    Public Declare Function P13_CardOpenExx Lib "P13W32.DLL" Alias "_P13_CardOpenExx@28" (ByRef cardname As String, ByVal memval As UInt32, ByVal ioval As UInt16, ByVal irqval As UInt16, ByVal drqval As UInt16, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Sub P13_CardResetEx Lib "P13W32.DLL" Alias "_P13_CardResetEx@4" (ByVal handleval As UInt32)
    Public Declare Function P13_CardResume Lib "P13W32.DLL" Alias "_P13_CardResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardTest Lib "P13W32.DLL" Alias "_P13_CardTest@8" (ByVal level As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardTest0 Lib "P13W32.DLL" Alias "_P13_CardTest0@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardTest1 Lib "P13W32.DLL" Alias "_P13_CardTest1@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardTest2 Lib "P13W32.DLL" Alias "_P13_CardTest2@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CardTest3 Lib "P13W32.DLL" Alias "_P13_CardTest3@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub P13_CardTrigger Lib "P13W32.DLL" Alias "_P13_CardTrigger@4" (ByVal handleval As UInt32)
    Public Declare Function P13_CmdAddr Lib "P13W32.DLL" Alias "_P13_CmdAddr@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_CmdAlloc Lib "P13W32.DLL" Alias "_P13_CmdAlloc@8" (ByVal count As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_CmdBaseRd Lib "P13W32.DLL" Alias "_P13_CmdBaseRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Sub P13_CmdBaseWr Lib "P13W32.DLL" Alias "_P13_CmdBaseWr@8" (ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_CmdClear Lib "P13W32.DLL" Alias "_P13_CmdClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CmdCountRd Lib "P13W32.DLL" Alias "_P13_CmdCountRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_CmdCountWr Lib "P13W32.DLL" Alias "_P13_CmdCountWr@8" (ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_CmdCtrlRd Lib "P13W32.DLL" Alias "_P13_CmdCtrlRd@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_CmdCtrlWr Lib "P13W32.DLL" Alias "_P13_CmdCtrlWr@12" (ByVal ctrlval As UInt16, ByVal index As Int32, ByVal handleval As UInt32)
    Public Declare Function P13_CmdCurrRd Lib "P13W32.DLL" Alias "_P13_CmdCurrRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_CmdCurrWr Lib "P13W32.DLL" Alias "_P13_CmdCurrWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub P13_CmdInit Lib "P13W32.DLL" Alias "_P13_CmdInit@8" (ByVal opcode As UInt16, ByRef block As UInt16)
    Public Declare Function P13_CmdInsert Lib "P13W32.DLL" Alias "_P13_CmdInsert@8" (ByRef block As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CmdMaxRd Lib "P13W32.DLL" Alias "_P13_CmdMaxRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_CmdMaxWr Lib "P13W32.DLL" Alias "_P13_CmdMaxWr@8" (ByVal count As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_CmdRd Lib "P13W32.DLL" Alias "_P13_CmdRd@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CmdShotWr Lib "P13W32.DLL" Alias "_P13_CmdShotWr@12" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CmdSkipWr Lib "P13W32.DLL" Alias "_P13_CmdSkipWr@12" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Sub P13_CmdStackClr Lib "P13W32.DLL" Alias "_P13_CmdStackClr@4" (ByVal handleval As UInt32)
    Public Declare Function P13_CmdStartRd Lib "P13W32.DLL" Alias "_P13_CmdStartRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_CmdStartWr Lib "P13W32.DLL" Alias "_P13_CmdStartWr@8" (ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_CmdTotalRd Lib "P13W32.DLL" Alias "_P13_CmdTotalRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub P13_CmdTotalWr Lib "P13W32.DLL" Alias "_P13_CmdTotalWr@8" (ByVal countval As Int32, ByVal handleval As UInt32)
    Public Declare Function P13_CmdWr Lib "P13W32.DLL" Alias "_P13_CmdWr@12" (ByRef block As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CommCall Lib "P13W32.DLL" Alias "_P13_CommCall@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CommCheck Lib "P13W32.DLL" Alias "_P13_CommCheck@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CommDisable Lib "P13W32.DLL" Alias "_P13_CommDisable@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CommEnable Lib "P13W32.DLL" Alias "_P13_CommEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CommRdL Lib "P13W32.DLL" Alias "_P13_CommRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_CommRdsW Lib "P13W32.DLL" Alias "_P13_CommRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_CommRdW Lib "P13W32.DLL" Alias "_P13_CommRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_CommRun Lib "P13W32.DLL" Alias "_P13_CommRun@20" (ByRef dataptr As UInt16, ByVal datacount As UInt16, ByRef codeptr As UInt16, ByVal codecount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub P13_CommWrL Lib "P13W32.DLL" Alias "_P13_CommWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_CommWrsW Lib "P13W32.DLL" Alias "_P13_CommWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub P13_CommWrW Lib "P13W32.DLL" Alias "_P13_CommWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub P13_DARClr Lib "P13W32.DLL" Alias "_P13_DARClr@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_DARGet Lib "P13W32.DLL" Alias "_P13_DARGet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_DARRdL Lib "P13W32.DLL" Alias "_P13_DARRdL@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_DARRdW Lib "P13W32.DLL" Alias "_P13_DARRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_DARSet Lib "P13W32.DLL" Alias "_P13_DARSet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub P13_DARWrL Lib "P13W32.DLL" Alias "_P13_DARWrL@12" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub P13_DARWrW Lib "P13W32.DLL" Alias "_P13_DARWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_DescAddr Lib "P13W32.DLL" Alias "_P13_DescAddr@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_DescAlloc Lib "P13W32.DLL" Alias "_P13_DescAlloc@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_DescConfig Lib "P13W32.DLL" Alias "_P13_DescConfig@24" (ByVal configval As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_DescOptRd Lib "P13W32.DLL" Alias "_P13_DescOptRd@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_DescOptWr Lib "P13W32.DLL" Alias "_P13_DescOptWr@24" (ByVal descopt As UInt16, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32)
    Public Declare Function P13_DescPtrRd Lib "P13W32.DLL" Alias "_P13_DescPtrRd@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_DescPtrWr Lib "P13W32.DLL" Alias "_P13_DescPtrWr@24" (ByVal msgaddr As UInt32, ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_DescRd Lib "P13W32.DLL" Alias "_P13_DescRd@24" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByRef desc As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_DescWr Lib "P13W32.DLL" Alias "_P13_DescWr@24" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByRef desc As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_Div Lib "P13W32.DLL" Alias "_P13_Div@8" (ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
    Public Declare Function P13_DllUsageCount Lib "P13W32.DLL" Alias "_P13_DllUsageCount@0" () As Int32
    Public Declare Function P13_DspBioRd Lib "P13W32.DLL" Alias "_P13_DspBioRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_DspIntfClear Lib "P13W32.DLL" Alias "_P13_DspIntfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_DspIntfRead Lib "P13W32.DLL" Alias "_P13_DspIntfRead@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_DspIntmClear Lib "P13W32.DLL" Alias "_P13_DspIntmClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_DspIntmSet Lib "P13W32.DLL" Alias "_P13_DspIntmSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_DspXfClear Lib "P13W32.DLL" Alias "_P13_DspXfClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_DspXfSet Lib "P13W32.DLL" Alias "_P13_DspXfSet@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ErrorIsTaggedBC Lib "P13W32.DLL" Alias "_P13_ErrorIsTaggedBC@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ErrorIsTaggedRT Lib "P13W32.DLL" Alias "_P13_ErrorIsTaggedRT@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ErrorResponse Lib "P13W32.DLL" Alias "_P13_ErrorResponse@8" (ByVal responseval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub P13_ErrorSync Lib "P13W32.DLL" Alias "_P13_ErrorSync@8" (ByVal value As Int32, ByVal handleval As UInt32)
    Public Declare Function P13_ErrorTimeout Lib "P13W32.DLL" Alias "_P13_ErrorTimeout@8" (ByVal timeoutval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ExtDinRd Lib "P13W32.DLL" Alias "_P13_ExtDinRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub P13_ExtDinWr Lib "P13W32.DLL" Alias "_P13_ExtDinWr@8" (ByVal dinval As Int32, ByVal handleval As UInt32)
    Public Declare Function P13_ExtDoutRd Lib "P13W32.DLL" Alias "_P13_ExtDoutRd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub P13_ExtDoutWr Lib "P13W32.DLL" Alias "_P13_ExtDoutWr@8" (ByVal doutval As Int32, ByVal handleval As UInt32)
    Public Declare Sub P13_FileClose Lib "P13W32.DLL" Alias "_P13_FileClose@4" (ByVal handle As IntPtr)
    Public Declare Function P13_FileErr Lib "P13W32.DLL" Alias "_P13_FileErr@0" () As Int32
    Public Declare Sub P13_FileErrClr Lib "P13W32.DLL" Alias "_P13_FileErrClr@0" ()
    Public Declare Sub P13_FileErrSet Lib "P13W32.DLL" Alias "_P13_FileErrSet@0" ()
    Public Declare Function P13_FileOpenRead Lib "P13W32.DLL" Alias "_P13_FileOpenRead@4" (ByRef filename As String) As UInt32
    Public Declare Function P13_FileOpenWrite Lib "P13W32.DLL" Alias "_P13_FileOpenWrite@4" (ByRef filename As String) As UInt32
    Public Declare Function P13_FileRead Lib "P13W32.DLL" Alias "_P13_FileRead@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function P13_FileSeek Lib "P13W32.DLL" Alias "_P13_FileSeek@8" (ByVal handle As IntPtr, ByVal offset As UInt32) As Int32
    Public Declare Function P13_FileTell Lib "P13W32.DLL" Alias "_P13_FileTell@4" (ByVal handle As IntPtr) As UInt32
    Public Declare Function P13_FileWrite Lib "P13W32.DLL" Alias "_P13_FileWrite@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
    Public Declare Function P13_GetHigh Lib "P13W32.DLL" Alias "_P13_GetHigh@4" (ByVal val As UInt32) As UInt16
    Public Declare Function P13_GetLow Lib "P13W32.DLL" Alias "_P13_GetLow@4" (ByVal val As UInt32) As UInt16
    Public Declare Function P13_GlobalRdW Lib "P13W32.DLL" Alias "_P13_GlobalRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_GlobalWrW Lib "P13W32.DLL" Alias "_P13_GlobalWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_HandleDel Lib "P13W32.DLL" Alias "_P13_HandleDel@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_HandleGet Lib "P13W32.DLL" Alias "_P13_HandleGet@24" (ByRef memval As UInt32, ByRef sizval As UInt32, ByRef ioval As UInt32, ByRef irqval As UInt16, ByRef drqval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_HandleGetIo Lib "P13W32.DLL" Alias "_P13_HandleGetIo@4" (ByVal ioval As UInt16) As UInt32
    Public Declare Function P13_HandleGetMem Lib "P13W32.DLL" Alias "_P13_HandleGetMem@4" (ByVal memval As UInt32) As UInt32
    Public Declare Function P13_HandleIns Lib "P13W32.DLL" Alias "_P13_HandleIns@28" (ByRef cardname As String, ByVal memval As UInt32, ByVal ioval As UInt16, ByVal irqval As UInt16, ByVal drqval As UInt16, ByVal happwnd As IntPtr, ByVal uiremovalmsg As UInt16) As UInt32
    Public Declare Function P13_HandleOkay Lib "P13W32.DLL" Alias "_P13_HandleOkay@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_HeapAlloc Lib "P13W32.DLL" Alias "_P13_HeapAlloc@8" (ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_HeapAllocAll Lib "P13W32.DLL" Alias "_P13_HeapAllocAll@8" (ByRef wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_HeapAllocEx Lib "P13W32.DLL" Alias "_P13_HeapAllocEx@12" (ByVal configval As UInt16, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_HeapWipe Lib "P13W32.DLL" Alias "_P13_HeapWipe@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_IndirectRd Lib "P13W32.DLL" Alias "_P13_IndirectRd@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_IndirectWr Lib "P13W32.DLL" Alias "_P13_IndirectWr@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_IntClear Lib "P13W32.DLL" Alias "_P13_IntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_IntConfig Lib "P13W32.DLL" Alias "_P13_IntConfig@12" (ByVal configval As UInt16, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_IntDisable Lib "P13W32.DLL" Alias "_P13_IntDisable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_IntEnable Lib "P13W32.DLL" Alias "_P13_IntEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_IntEnableCond Lib "P13W32.DLL" Alias "_P13_IntEnableCond@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_IntGet Lib "P13W32.DLL" Alias "_P13_IntGet@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_IntInstall Lib "P13W32.DLL" Alias "_P13_IntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_IntRd Lib "P13W32.DLL" Alias "_P13_IntRd@12" (ByRef typevalval As UInt16, ByRef infoval As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Sub P13_IntReset Lib "P13W32.DLL" Alias "_P13_IntReset@4" (ByVal handleval As UInt32)
    Public Declare Function P13_IntStatus Lib "P13W32.DLL" Alias "_P13_IntStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_IntUninstall Lib "P13W32.DLL" Alias "_P13_IntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_IORdW Lib "P13W32.DLL" Alias "_P13_IORdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_IOWINRdW Lib "P13W32.DLL" Alias "_P13_IOWINRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_IOWINWrW Lib "P13W32.DLL" Alias "_P13_IOWINWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub P13_IOWrW Lib "P13W32.DLL" Alias "_P13_IOWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_KernDev Lib "P13W32.DLL" Alias "_P13_KernDev@8" (ByRef valueptr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernEnd Lib "P13W32.DLL" Alias "_P13_KernEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernIntClear Lib "P13W32.DLL" Alias "_P13_KernIntClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernIntInstall Lib "P13W32.DLL" Alias "_P13_KernIntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernIntStatus Lib "P13W32.DLL" Alias "_P13_KernIntStatus@8" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernIntUninstall Lib "P13W32.DLL" Alias "_P13_KernIntUninstall@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernIORdW Lib "P13W32.DLL" Alias "_P13_KernIORdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernIOWrW Lib "P13W32.DLL" Alias "_P13_KernIOWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernMEMFillW Lib "P13W32.DLL" Alias "_P13_KernMEMFillW@16" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernMEMRdsW Lib "P13W32.DLL" Alias "_P13_KernMEMRdsW@16" (ByRef bufptr As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernMEMRdW Lib "P13W32.DLL" Alias "_P13_KernMEMRdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernMEMWrsW Lib "P13W32.DLL" Alias "_P13_KernMEMWrsW@16" (ByRef bufptr As UInt16, ByVal addrval As UInt16, ByVal countval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernMEMWrW Lib "P13W32.DLL" Alias "_P13_KernMEMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_KernStatus Lib "P13W32.DLL" Alias "_P13_KernStatus@12" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ListConfig Lib "P13W32.DLL" Alias "_P13_ListConfig@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_MakeLong Lib "P13W32.DLL" Alias "_P13_MakeLong@8" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
    Public Declare Function P13_Mask Lib "P13W32.DLL" Alias "_P13_Mask@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function P13_MEMWINRdB Lib "P13W32.DLL" Alias "_P13_MEMWINRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_MEMWINRdL Lib "P13W32.DLL" Alias "_P13_MEMWINRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_MEMWINRdW Lib "P13W32.DLL" Alias "_P13_MEMWINRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_MEMWINWrB Lib "P13W32.DLL" Alias "_P13_MEMWINWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub P13_MEMWINWrL Lib "P13W32.DLL" Alias "_P13_MEMWINWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub P13_MEMWINWrW Lib "P13W32.DLL" Alias "_P13_MEMWINWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_Mod Lib "P13W32.DLL" Alias "_P13_Mod@8" (ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
    Public Declare Function P13_ModeIsBC Lib "P13W32.DLL" Alias "_P13_ModeIsBC@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ModeIsMon Lib "P13W32.DLL" Alias "_P13_ModeIsMon@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ModeIsNotBC Lib "P13W32.DLL" Alias "_P13_ModeIsNotBC@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ModeIsNotMon Lib "P13W32.DLL" Alias "_P13_ModeIsNotMon@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ModeIsNotRT Lib "P13W32.DLL" Alias "_P13_ModeIsNotRT@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ModeIsNotSerial Lib "P13W32.DLL" Alias "_P13_ModeIsNotSerial@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ModeIsRT Lib "P13W32.DLL" Alias "_P13_ModeIsRT@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ModeIsSerial Lib "P13W32.DLL" Alias "_P13_ModeIsSerial@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_ModeRd Lib "P13W32.DLL" Alias "_P13_ModeRd@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_ModeWr Lib "P13W32.DLL" Alias "_P13_ModeWr@8" (ByVal mode As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_MonClear Lib "P13W32.DLL" Alias "_P13_MonClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonConfigEx Lib "P13W32.DLL" Alias "_P13_MonConfigEx@16" (ByVal configval As UInt32, ByVal moncount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonConfigExx Lib "P13W32.DLL" Alias "_P13_MonConfigExx@20" (ByVal configval As UInt32, ByVal seqaddr As UInt32, ByVal moncount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonFilterSAEx Lib "P13W32.DLL" Alias "_P13_MonFilterSAEx@24" (ByVal taval As Int32, ByVal rcvsamask As UInt32, ByVal xmtsamask As UInt32, ByVal rcvmcmask As UInt32, ByVal xmtmcmask As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonRdEx Lib "P13W32.DLL" Alias "_P13_MonRdEx@12" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_MonResume Lib "P13W32.DLL" Alias "_P13_MonResume@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonStart Lib "P13W32.DLL" Alias "_P13_MonStart@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonStatus Lib "P13W32.DLL" Alias "_P13_MonStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MonStop Lib "P13W32.DLL" Alias "_P13_MonStop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MsgBlockRd Lib "P13W32.DLL" Alias "_P13_MsgBlockRd@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_MsgBlockWr Lib "P13W32.DLL" Alias "_P13_MsgBlockWr@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_MsgCheck Lib "P13W32.DLL" Alias "_P13_MsgCheck@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_MsgCommRd Lib "P13W32.DLL" Alias "_P13_MsgCommRd@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_MsgCommWr Lib "P13W32.DLL" Alias "_P13_MsgCommWr@12" (ByRef buf As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_MsgConfig Lib "P13W32.DLL" Alias "_P13_MsgConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_MsgConfigEx Lib "P13W32.DLL" Alias "_P13_MsgConfigEx@12" (ByVal configval As UInt32, ByVal cwd As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_MsgCWD1Rd Lib "P13W32.DLL" Alias "_P13_MsgCWD1Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_MsgCWD1Wr Lib "P13W32.DLL" Alias "_P13_MsgCWD1Wr@12" (ByVal cwd1 As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_MsgCWD2Rd Lib "P13W32.DLL" Alias "_P13_MsgCWD2Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_MsgCWD2Wr Lib "P13W32.DLL" Alias "_P13_MsgCWD2Wr@12" (ByVal cwd2 As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_MsgErrorRd Lib "P13W32.DLL" Alias "_P13_MsgErrorRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_MsgErrorWr Lib "P13W32.DLL" Alias "_P13_MsgErrorWr@12" (ByVal value As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_MsgFlagRd Lib "P13W32.DLL" Alias "_P13_MsgFlagRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_MsgFlagWr Lib "P13W32.DLL" Alias "_P13_MsgFlagWr@12" (ByVal msgflag As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_MsgIsAccessed Lib "P13W32.DLL" Alias "_P13_MsgIsAccessed@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_MsgOptRd Lib "P13W32.DLL" Alias "_P13_MsgOptRd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_MsgOptWr Lib "P13W32.DLL" Alias "_P13_MsgOptWr@12" (ByVal msgopt As UInt16, ByVal msgaddr As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_MsgReset Lib "P13W32.DLL" Alias "_P13_MsgReset@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_MsgSWD1Rd Lib "P13W32.DLL" Alias "_P13_MsgSWD1Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_MsgSWD2Rd Lib "P13W32.DLL" Alias "_P13_MsgSWD2Rd@8" (ByVal msgaddr As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_Mul Lib "P13W32.DLL" Alias "_P13_Mul@8" (ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
    Public Declare Function P13_PortRd Lib "P13W32.DLL" Alias "_P13_PortRd@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_PortWr Lib "P13W32.DLL" Alias "_P13_PortWr@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_ProgRdW Lib "P13W32.DLL" Alias "_P13_ProgRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_ProgWrW Lib "P13W32.DLL" Alias "_P13_ProgWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub P13_RAMFill Lib "P13W32.DLL" Alias "_P13_RAMFill@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_RAMRdB Lib "P13W32.DLL" Alias "_P13_RAMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_RAMRdL Lib "P13W32.DLL" Alias "_P13_RAMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
    Public Declare Sub P13_RAMRdsW Lib "P13W32.DLL" Alias "_P13_RAMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub P13_RAMRdsxW Lib "P13W32.DLL" Alias "_P13_RAMRdsxW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_RAMRdW Lib "P13W32.DLL" Alias "_P13_RAMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_RAMWipe Lib "P13W32.DLL" Alias "_P13_RAMWipe@4" (ByVal handleval As UInt32)
    Public Declare Sub P13_RAMWipeEx Lib "P13W32.DLL" Alias "_P13_RAMWipeEx@8" (ByVal value As UInt16, ByVal handleval As UInt32)
    Public Declare Sub P13_RAMWrB Lib "P13W32.DLL" Alias "_P13_RAMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub P13_RAMWrL Lib "P13W32.DLL" Alias "_P13_RAMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Sub P13_RAMWrsW Lib "P13W32.DLL" Alias "_P13_RAMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub P13_RAMWrsxW Lib "P13W32.DLL" Alias "_P13_RAMWrsxW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub P13_RAMWrW Lib "P13W32.DLL" Alias "_P13_RAMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
    Public Declare Function P13_RTConfigEx Lib "P13W32.DLL" Alias "_P13_RTConfigEx@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_RTConfigExx Lib "P13W32.DLL" Alias "_P13_RTConfigExx@12" (ByVal configval As UInt32, ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_RTReset Lib "P13W32.DLL" Alias "_P13_RTReset@8" (ByVal taval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_RTStatus Lib "P13W32.DLL" Alias "_P13_RTStatus@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_RTSWDRd Lib "P13W32.DLL" Alias "_P13_RTSWDRd@8" (ByVal taval As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_SARRdW Lib "P13W32.DLL" Alias "_P13_SARRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub P13_SARWrW Lib "P13W32.DLL" Alias "_P13_SARWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    Public Declare Function P13_SchedBuild Lib "P13W32.DLL" Alias "_P13_SchedBuild@16" (ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef freq As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SchedBuildEx Lib "P13W32.DLL" Alias "_P13_SchedBuildEx@28" (ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef freq As UInt16, ByRef period As UInt16, ByVal buf As IntPtr, ByVal bufsize As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SchedBuildExx Lib "P13W32.DLL" Alias "_P13_SchedBuildExx@28" (ByVal frametime As UInt32, ByVal nummsgs As UInt16, ByRef msgaddr As UInt32, ByRef period As UInt16, ByVal buf As IntPtr, ByVal bufsize As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SchedCalc Lib "P13W32.DLL" Alias "_P13_SchedCalc@8" (ByRef msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SchedInsEnd Lib "P13W32.DLL" Alias "_P13_SchedInsEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SchedInsMsg Lib "P13W32.DLL" Alias "_P13_SchedInsMsg@12" (ByVal index As UInt16, ByRef msgaddr As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SchedInsStart Lib "P13W32.DLL" Alias "_P13_SchedInsStart@12" (ByVal frametime As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SchedMaxval Lib "P13W32.DLL" Alias "_P13_SchedMaxval@8" (ByRef arrayval As UInt16, ByVal arrayvalcount As UInt16) As UInt16
    Public Declare Function P13_SchedMinval Lib "P13W32.DLL" Alias "_P13_SchedMinval@8" (ByRef arrayval As UInt16, ByVal arrayvalcount As UInt16) As UInt16
    Public Declare Function P13_SerialClear Lib "P13W32.DLL" Alias "_P13_SerialClear@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SerialConfig Lib "P13W32.DLL" Alias "_P13_SerialConfig@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SerialConfigEx Lib "P13W32.DLL" Alias "_P13_SerialConfigEx@12" (ByVal configval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SerialStatus Lib "P13W32.DLL" Alias "_P13_SerialStatus@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function P13_SerialWr Lib "P13W32.DLL" Alias "_P13_SerialWr@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_Shl Lib "P13W32.DLL" Alias "_P13_Shl@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function P13_Shr Lib "P13W32.DLL" Alias "_P13_Shr@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Sub P13_TimerClear Lib "P13W32.DLL" Alias "_P13_TimerClear@4" (ByVal handleval As UInt32)
    Public Declare Function P13_TimerRd Lib "P13W32.DLL" Alias "_P13_TimerRd@4" (ByVal handleval As UInt32) As UInt32
    Public Declare Function P13_TimerResolution Lib "P13W32.DLL" Alias "_P13_TimerResolution@8" (ByVal timerresol As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function P13_TimerResolutionEx Lib "P13W32.DLL" Alias "_P13_TimerResolutionEx@8" (ByVal timershift As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function P13_ValAsciiCmpi Lib "P13W32.DLL" Alias "_P13_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Int32
    Public Declare Function P13_ValAsciiCpy Lib "P13W32.DLL" Alias "_P13_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Int32) As UInt32
    Public Declare Sub P13_ValAsciiTrimLead Lib "P13W32.DLL" Alias "_P13_ValAsciiTrimLead@4" (ByRef buf As String)
    Public Declare Sub P13_ValAsciiTrimTrail Lib "P13W32.DLL" Alias "_P13_ValAsciiTrimTrail@4" (ByRef buf As String)
    Public Declare Function P13_ValFromAscii Lib "P13W32.DLL" Alias "_P13_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
    Public Declare Function P13_ValGetBits Lib "P13W32.DLL" Alias "_P13_ValGetBits@12" (ByVal oldvalue As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function P13_ValIncAscii Lib "P13W32.DLL" Alias "_P13_ValIncAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function P13_ValInccAscii Lib "P13W32.DLL" Alias "_P13_ValInccAscii@4" (ByRef asciistr As String) As UInt32
    Public Declare Function P13_ValIsLower Lib "P13W32.DLL" Alias "_P13_ValIsLower@4" (ByVal value As Int32) As Int32
    Public Declare Function P13_ValLenAscii Lib "P13W32.DLL" Alias "_P13_ValLenAscii@8" (ByVal numbits As Int32, ByVal radixval As Int32) As Int32
    Public Declare Function P13_ValPackRTCWD Lib "P13W32.DLL" Alias "_P13_ValPackRTCWD@20" (ByVal mcflag As Int32, ByVal taval As Int32, ByVal trflag As Int32, ByVal saval As Int32, ByVal count As Int32) As UInt16
    Public Declare Function P13_ValPutBits Lib "P13W32.DLL" Alias "_P13_ValPutBits@16" (ByVal oldvalue As UInt16, ByVal newfld As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function P13_ValToAscii Lib "P13W32.DLL" Alias "_P13_ValToAscii@16" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
    Public Declare Function P13_ValToUpper Lib "P13W32.DLL" Alias "_P13_ValToUpper@4" (ByVal value As Int32) As Int32
    Public Declare Sub P13_ValUnpackRTCWD Lib "P13W32.DLL" Alias "_P13_ValUnpackRTCWD@28" (ByVal cwd As UInt16, ByRef bcastflag As Int32, ByRef mcflag As Int32, ByRef taval As Int32, ByRef trflag As Int32, ByRef saval As Int32, ByRef count As Int32)

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

    Public Const INFOTYPE_PLAT As UInt16 = &H1   '//Returns the PC1553-3 platform type
    Public Const INFOTYPE_PROD As UInt16 = &H2   '//Returns the PC1553-3 product type
    Public Const INFOTYPE_DASH As UInt16 = &H3   '//Returns the PC1553-3 dash number
    Public Const INFOTYPE_VERSION As UInt16 = &H4    '//Returns the PC1553-3 version number
    Public Const INFOTYPE_DATE As UInt16 = &H5   '//Returns the PC1553-3 version date
    Public Const INFOTYPE_MODEL As UInt16 = &H6  '//Returns the PC1553-3 model number
    Public Const INFOTYPE_MAXCOUNT As UInt16 = &H7   '//Returns the number of terminals the PC1553-3 can simulate
    Public Const INFOTYPE_MULTIMODE As UInt16 = &H8  '//Returns whether PC1553-3 can simulate multi-modes
    Public Const INFOTYPE_ERRORGEN As UInt16 = &H9   '//Returns whether PC1553-3 can generate errors
    Public Const INFOTYPE_CONCURMON As UInt16 = &HA  '//Returns whether PC1553-3 has a concurrent monitor
    Public Const INFOTYPE_MONFILTER As UInt16 = &HB  '//Returns whether PC1553-3 has a monitor filter
    Public Const INFOTYPE_USERCODE As UInt16 = &HC   '//Returns whether PC1553-3 handles user code
    Public Const INFOTYPE_LISTBUF As UInt16 = &HD    '//Returns whether PC1553-3 handles list buffering
    Public Const INFOTYPE_MONFAST As UInt16 = &HE    '//Returns whether PC1553-3 has a fast monitor
    Public Const INFOTYPE_MONDMA As UInt16 = &HF '//Returns whether PC1553-3 has a dma monitor
    Public Const INFOTYPE_MONBRAKE As UInt16 = &H10   '//Returns whether PC1553-3 has a monitor brake
    Public Const INFOTYPE_80MHZ As UInt16 = &H11  '//Returns whether PC1553-3 is using an 80MHz DSP

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
    '*  P13 Host Registers
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
    '*  P13 Host Indirect Registers
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

    Public Const EREG_STAT As UInt16 = &H2C80   '//Status register (RD)
    Public Const EREG_STATCLR As UInt16 = &H2C81    '//Status clear register (WR)
    Public Const EREG_STATDEC As UInt16 = &H2C82    '//Decoder status register (RD)
    Public Const EREG_VALA As UInt16 = &H2C84   '//Decoder word value A register
    Public Const EREG_VALAL As UInt16 = &H2C84  '//Decoder low word value A register
    Public Const EREG_VALAH As UInt16 = &H2C85  '//Decoder high word value A register
    Public Const EREG_VALB As UInt16 = &H2C86   '//Decoder word value B register
    Public Const EREG_VALBL As UInt16 = &H2C86  '//Decoder low word value B register
    Public Const EREG_VALBH As UInt16 = &H2C87  '//Decoder high word value B register
    Public Const EREG_GAPE As UInt16 = &H2C88   '//Encoder gap register
    Public Const EREG_CTRLE As UInt16 = &H2C89  '//Encoder control register
    Public Const EREG_VALE As UInt16 = &H2C8A   '//Encoder value register
    Public Const EREG_VALEL As UInt16 = &H2C8A  '//Encoder low value register
    Public Const EREG_VALEH As UInt16 = &H2C8B  '//Encoder high value register
    Public Const EREG_ERRE As UInt16 = &H2C8C   '//Encoder error register
    Public Const EREG_FT As UInt16 = &H2C8E '//Frame time register
    Public Const EREG_RST As UInt16 = &H2C8F    '//Reset register
    Public Const EREG_GAPA As UInt16 = &H2C90   '//Decoder gap time A register
    Public Const EREG_GAPB As UInt16 = &H2C91   '//Decoder gap time B register
    Public Const EREG_GAPTO As UInt16 = &H2C92  '//Decoder gap timeout register
    Public Const EREG_CFGD As UInt16 = &H2C94   '//Decoder configuration register
    Public Const EREG_CFGE As UInt16 = &H2C95   '//Encoder configuration register
    Public Const EREG_CFGINT As UInt16 = &H2C96 '//Interrupt configuration register
    Public Const EREG_ID As UInt16 = &H2C97 '//Identification register

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
    Public Const ERR_NOCARD As Int16 = -13  '//CardOpen() could not find a PC1553-3 card at the specified address
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
