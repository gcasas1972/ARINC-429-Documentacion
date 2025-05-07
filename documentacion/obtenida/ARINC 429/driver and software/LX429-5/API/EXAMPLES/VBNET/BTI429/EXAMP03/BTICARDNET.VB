Imports System
Imports System.Runtime.InteropServices

Module BTICARDVB

    '/**
    '*
    '*  BTICard WIN32 DRIVER  Version 2.6.4  (01/24/2013)
    '*  Copyright (c) 2001-2013
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   BTICardNET.VB -- 32-bit
    '*                       BTICard Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  Structs used by the BTICard Driver.
    '*
    '**/

    <StructLayout(LayoutKind.Sequential)> Public Structure SEQRECORD1553
        Public typeval As UInt16    '//Valid in all versions
        Public count As UInt16  '//Valid in all versions
        Public timestamp As UInt32  '//Valid in all versions
        Public activity As UInt16   '//Valid in all versions
        Public errorval As UInt16   '//Valid in all versions
        Public cwd1 As UInt16   '//Valid in all versions
        Public cwd2 As UInt16   '//Valid in all versions
        Public swd1 As UInt16   '//Valid in all versions
        Public swd2 As UInt16   '//Valid in all versions
        Public datacount As UInt16  '//Valid in all versions
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=40)> Public data() As UInt16    '//Variable length (don't exceed data[datacount-1])
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure SEQRECORDMORE1553
        Public timestamph As UInt32 '//Valid if version of baseval record (SEQRECORD1553) >= 1
        Public resptime1 As UInt16  '//Valid if version of baseval record (SEQRECORD1553) >= 1
        Public resptime2 As UInt16  '//Valid if version of baseval record (SEQRECORD1553) >= 1
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure SEQRECORD429
        Public typeval As UInt16    '//Valid in all versions
        Public count As UInt16  '//Valid in all versions
        Public timestamp As UInt32  '//Valid in all versions
        Public activity As UInt16   '//Valid in all versions
        Public decgap As UInt16 '//Valid if version >= 1
        Public data As UInt32   '//Valid in all versions
        Public timestamph As UInt32 '//Valid if version >= 1
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure SEQRECORD717
        Public typeval As UInt16    '//Valid in all versions
        Public count As UInt16  '//Valid in all versions
        Public timestamp As UInt32  '//Valid in all versions
        Public activity As UInt16   '//Valid in all versions
        Public wordnum As UInt16    '//Valid in all versions
        Public subframe As UInt16   '//Valid in all versions
        Public superframe As UInt16 '//Valid in all versions
        Public data As UInt16   '//Valid in all versions
        Public rsvd9 As UInt16  '//Valid if version >= 1
        Public timestamph As UInt32 '//Valid if version >= 1
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure SEQRECORD708
        Public typeval As UInt16    '//Valid in all versions
        Public count As UInt16  '//Valid in all versions
        Public timestamp As UInt32  '//Valid in all versions
        Public activity As UInt16   '//Valid in all versions
        Public datacount As UInt16  '//Valid in all versions
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=100)> Public data() As UInt16   '//Valid in all versions
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)> Public extra() As UInt16   '//Valid if version >= 1
        Public bitcount As UInt16   '//Valid if version >= 1
        Public rsvd123 As UInt16    '//Valid if version >= 1
        Public timestamph As UInt32 '//Valid if version >= 1
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure SEQRECORDCSDB
        Public typeval As UInt16    '//Valid in all versions
        Public count As UInt16  '//Valid in all versions
        Public timestamp As UInt32  '//Valid in all versions
        Public timestamph As UInt32 '//Valid in all versions
        Public activity As UInt16   '//Valid in all versions
        Public datacount As UInt16  '//Valid in all versions
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> Public data() As UInt16    '//Valid in all versions
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure SEQRECORDDIO
        Public typeval As UInt16    '//Valid in all versions
        Public count As UInt16  '//Valid in all versions
        Public bank As UInt16   '//Valid in all versions
        Public state As UInt16  '//Valid in version 0
        Public timestamp As UInt32  '//Valid in all versions
        Public timestamph As UInt32 '//Valid in all versions
        Public change As UInt16 '//Valid in version 1
        Public value As UInt16  '//Valid in version 1
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure SEQFINDINFO
        Public pRecFirst As UInt32
        Public pRecNext As UInt32
        Public pRecLast As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential)> Public Structure BTIIRIGTIME
        Public days As UInt16
        Public hours As UInt16
        Public min As UInt16
        Public sec As UInt16
        Public msec As UInt16
        Public usec As UInt16
    End Structure

    '/**
    '*
    '*  BTICard Driver functions.
    '*
    '**/

    Private Class BTICARD_32
        Public Declare Sub BTICard_Add64 Lib "BTICARD.DLL" Alias "_BTICard_Add64@24" (ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        Public Declare Function BTICard_AddrDSP Lib "BTICARD.DLL" Alias "_BTICard_AddrDSP@8" (ByVal addr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_AddrHost Lib "BTICARD.DLL" Alias "_BTICard_AddrHost@8" (ByVal addr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_AsciiToMant Lib "BTICARD.DLL" Alias "_BTICard_AsciiToMant@12" (ByRef str As String, ByRef mant As UInt32, ByRef exp As Int32) As Int32
        Public Declare Function BTICard_BCDToBin Lib "BTICARD.DLL" Alias "_BTICard_BCDToBin@12" (ByVal bcdval As UInt32, ByVal msb As Int32, ByVal lsb As Int32) As UInt32
        Public Declare Function BTICard_BinToBCD Lib "BTICARD.DLL" Alias "_BTICard_BinToBCD@16" (ByVal oldbcdval As UInt32, ByVal binval As UInt32, ByVal msb As Int32, ByVal lsb As Int32) As UInt32
        Public Declare Function BTICard_BITConfig Lib "BTICARD.DLL" Alias "_BTICard_BITConfig@8" (ByVal ctrlflags As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_BITInitiate Lib "BTICARD.DLL" Alias "_BTICard_BITInitiate@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_BITStatusClear Lib "BTICARD.DLL" Alias "_BTICard_BITStatusClear@8" (ByVal statval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_BITStatusRd Lib "BTICARD.DLL" Alias "_BTICard_BITStatusRd@4" (ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_CardClose Lib "BTICARD.DLL" Alias "_BTICard_CardClose@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardCloseAll Lib "BTICARD.DLL" Alias "_BTICard_CardCloseAll@0" () As Int32
        Public Declare Function BTICard_CardGetInfo Lib "BTICARD.DLL" Alias "_BTICard_CardGetInfo@12" (ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_CardGetInfoEx Lib "BTICARD.DLL" Alias "_BTICard_CardGetInfoEx@20" (ByRef bufmodel As UInt16, ByVal bufmodelcount As UInt16, ByRef buffeature As UInt16, ByVal buffeaturecount As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardIsRunning Lib "BTICARD.DLL" Alias "_BTICard_CardIsRunning@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardNop Lib "BTICARD.DLL" Alias "_BTICard_CardNop@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardOpen Lib "BTICARD.DLL" Alias "_BTICard_CardOpen@8" (ByRef lphandle As UInt32, ByVal cardnum As Int32) As Int32
        Public Declare Function BTICard_CardOpenStr Lib "BTICARD.DLL" Alias "_BTICard_CardOpenStr@8" (ByRef lphandle As UInt32, ByRef cardstr As String) As Int32
        Public Declare Function BTICard_CardProductStr Lib "BTICARD.DLL" Alias "_BTICard_CardProductStr@4" (ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_CardReset Lib "BTICARD.DLL" Alias "_BTICard_CardReset@4" (ByVal handleval As UInt32)
        Public Declare Sub BTICard_CardResetEx Lib "BTICARD.DLL" Alias "_BTICard_CardResetEx@4" (ByVal handleval As UInt32)
        Public Declare Function BTICard_CardResume Lib "BTICARD.DLL" Alias "_BTICard_CardResume@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardShadow Lib "BTICARD.DLL" Alias "_BTICard_CardShadow@8" (ByVal shadowval As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardStart Lib "BTICARD.DLL" Alias "_BTICard_CardStart@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardStop Lib "BTICARD.DLL" Alias "_BTICard_CardStop@4" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_CardSyncEnable Lib "BTICARD.DLL" Alias "_BTICard_CardSyncEnable@16" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_CardSyncValid Lib "BTICARD.DLL" Alias "_BTICard_CardSyncValid@4" (ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_CardTest Lib "BTICARD.DLL" Alias "_BTICard_CardTest@8" (ByVal level As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardTest0 Lib "BTICARD.DLL" Alias "_BTICard_CardTest0@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardTest1 Lib "BTICARD.DLL" Alias "_BTICard_CardTest1@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardTest2 Lib "BTICARD.DLL" Alias "_BTICard_CardTest2@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardTest3 Lib "BTICARD.DLL" Alias "_BTICard_CardTest3@4" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_CardTrigger Lib "BTICARD.DLL" Alias "_BTICard_CardTrigger@4" (ByVal handleval As UInt32)
        Public Declare Sub BTICard_CardTriggerEnable Lib "BTICARD.DLL" Alias "_BTICard_CardTriggerEnable@8" (ByVal enableflag As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_CardTriggerEnableEx Lib "BTICARD.DLL" Alias "_BTICard_CardTriggerEnableEx@16" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal pinpolarity As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_CardTriggerEx Lib "BTICARD.DLL" Alias "_BTICard_CardTriggerEx@8" (ByVal trigmask As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_CardTriggerValid Lib "BTICARD.DLL" Alias "_BTICard_CardTriggerValid@4" (ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_CardTypeStr Lib "BTICARD.DLL" Alias "_BTICard_CardTypeStr@4" (ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_ChDARClr Lib "BTICARD.DLL" Alias "_BTICard_ChDARClr@16" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ChDARGet Lib "BTICARD.DLL" Alias "_BTICard_ChDARGet@16" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_ChDARRdL Lib "BTICARD.DLL" Alias "_BTICard_ChDARRdL@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_ChDARRdsW Lib "BTICARD.DLL" Alias "_BTICard_ChDARRdsW@20" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ChDARRdW Lib "BTICARD.DLL" Alias "_BTICard_ChDARRdW@12" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_ChDARSet Lib "BTICARD.DLL" Alias "_BTICard_ChDARSet@16" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ChDARWrL Lib "BTICARD.DLL" Alias "_BTICard_ChDARWrL@16" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ChDARWrsW Lib "BTICARD.DLL" Alias "_BTICard_ChDARWrsW@20" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ChDARWrW Lib "BTICARD.DLL" Alias "_BTICard_ChDARWrW@16" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_CISRd Lib "BTICARD.DLL" Alias "_BTICard_CISRd@16" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal cistype As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CISWr Lib "BTICARD.DLL" Alias "_BTICard_CISWr@16" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal cistype As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommBufRd Lib "BTICARD.DLL" Alias "_BTICard_CommBufRd@8" (ByVal offset As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_CommBufWr Lib "BTICARD.DLL" Alias "_BTICard_CommBufWr@12" (ByVal value As UInt16, ByVal offset As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_CommCall Lib "BTICARD.DLL" Alias "_BTICard_CommCall@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommChannelReconfig Lib "BTICARD.DLL" Alias "_BTICard_CommChannelReconfig@8" (ByVal chmask As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommCheck Lib "BTICARD.DLL" Alias "_BTICard_CommCheck@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommDisable Lib "BTICARD.DLL" Alias "_BTICard_CommDisable@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommDisableEx Lib "BTICARD.DLL" Alias "_BTICard_CommDisableEx@8" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommEnable Lib "BTICARD.DLL" Alias "_BTICard_CommEnable@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommExternSRQ Lib "BTICARD.DLL" Alias "_BTICard_CommExternSRQ@8" (ByVal chmask As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommFillW Lib "BTICARD.DLL" Alias "_BTICard_CommFillW@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommProtocolFunc Lib "BTICARD.DLL" Alias "_BTICard_CommProtocolFunc@16" (ByVal opcode As UInt16, ByVal argcount As UInt16, ByRef argbuf As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommRdL Lib "BTICARD.DLL" Alias "_BTICard_CommRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_CommRdsW Lib "BTICARD.DLL" Alias "_BTICard_CommRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommRdW Lib "BTICARD.DLL" Alias "_BTICard_CommRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_CommRun Lib "BTICARD.DLL" Alias "_BTICard_CommRun@20" (ByRef dataptr As UInt16, ByVal datacount As UInt16, ByRef codeptr As UInt16, ByVal codecount As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_CommWrL Lib "BTICARD.DLL" Alias "_BTICard_CommWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICard_CommWrsW Lib "BTICARD.DLL" Alias "_BTICard_CommWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_CommWrW Lib "BTICARD.DLL" Alias "_BTICard_CommWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICard_CoProcCheck Lib "BTICARD.DLL" Alias "_BTICard_CoProcCheck@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcGetInfo Lib "BTICARD.DLL" Alias "_BTICard_CoProcGetInfo@12" (ByRef valueptr As UInt32, ByVal infotype As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemRdL Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemRdL@12" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemRdsL Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemRdsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemRdsW Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemRdW Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemRdW@12" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemWrL Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemWrsL Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemWrsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemWrsW Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemWrW Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoreOpen Lib "BTICARD.DLL" Alias "_BTICard_CoreOpen@12" (ByRef lphcore As UInt32, ByVal corenum As Int32, ByVal hcard As UInt32) As Int32
        Public Declare Sub BTICard_DARClr Lib "BTICARD.DLL" Alias "_BTICard_DARClr@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_DARGet Lib "BTICARD.DLL" Alias "_BTICard_DARGet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DARRdL Lib "BTICARD.DLL" Alias "_BTICard_DARRdL@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_DARRdsW Lib "BTICARD.DLL" Alias "_BTICard_DARRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_DARRdW Lib "BTICARD.DLL" Alias "_BTICard_DARRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_DARSet Lib "BTICARD.DLL" Alias "_BTICard_DARSet@12" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_DARWrL Lib "BTICARD.DLL" Alias "_BTICard_DARWrL@12" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_DARWrsW Lib "BTICARD.DLL" Alias "_BTICard_DARWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_DARWrW Lib "BTICARD.DLL" Alias "_BTICard_DARWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_Div Lib "BTICARD.DLL" Alias "_BTICard_Div@8" (ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
        Public Declare Sub BTICard_Div64 Lib "BTICARD.DLL" Alias "_BTICard_Div64@24" (ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        Public Declare Function BTICard_DllUsageCount Lib "BTICARD.DLL" Alias "_BTICard_DllUsageCount@0" () As Int32
        Public Declare Function BTICard_DspBioClear Lib "BTICARD.DLL" Alias "_BTICard_DspBioClear@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspBioRd Lib "BTICARD.DLL" Alias "_BTICard_DspBioRd@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspBioSet Lib "BTICARD.DLL" Alias "_BTICard_DspBioSet@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspIntfClear Lib "BTICARD.DLL" Alias "_BTICard_DspIntfClear@8" (ByVal intmask As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspIntfRd Lib "BTICARD.DLL" Alias "_BTICard_DspIntfRd@8" (ByVal intmask As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspIntmClear Lib "BTICARD.DLL" Alias "_BTICard_DspIntmClear@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspIntmSet Lib "BTICARD.DLL" Alias "_BTICard_DspIntmSet@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspXfClear Lib "BTICARD.DLL" Alias "_BTICard_DspXfClear@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspXfRd Lib "BTICARD.DLL" Alias "_BTICard_DspXfRd@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspXfSet Lib "BTICARD.DLL" Alias "_BTICard_DspXfSet@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_ErrDesc Lib "BTICARD.DLL" Alias "_BTICard_ErrDesc@8" (ByVal errval As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_ErrDescStr Lib "BTICARD.DLL" Alias "_BTICard_ErrDescStr@8" (ByVal errval As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_ErrName Lib "BTICARD.DLL" Alias "_BTICard_ErrName@8" (ByVal errval As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_EventLogClear Lib "BTICARD.DLL" Alias "_BTICard_EventLogClear@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_EventLogConfig Lib "BTICARD.DLL" Alias "_BTICard_EventLogConfig@12" (ByVal configval As UInt16, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_EventLogRd Lib "BTICARD.DLL" Alias "_BTICard_EventLogRd@16" (ByRef typevalval As UInt16, ByRef infoval As UInt32, ByRef channel As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_EventLogStatus Lib "BTICARD.DLL" Alias "_BTICard_EventLogStatus@4" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_ExpandMant Lib "BTICARD.DLL" Alias "_BTICard_ExpandMant@8" (ByRef mant As UInt32, ByRef exp As Int32)
        Public Declare Function BTICard_ExtDinRd Lib "BTICARD.DLL" Alias "_BTICard_ExtDinRd@4" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_ExtDinWr Lib "BTICARD.DLL" Alias "_BTICard_ExtDinWr@8" (ByVal dinval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ExtDIODirSet Lib "BTICARD.DLL" Alias "_BTICard_ExtDIODirSet@12" (ByVal dionum As Int32, ByVal dirval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ExtDIOMonConfig Lib "BTICARD.DLL" Alias "_BTICard_ExtDIOMonConfig@16" (ByVal rise_edge As UInt16, ByVal fall_edge As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_ExtDIORd Lib "BTICARD.DLL" Alias "_BTICard_ExtDIORd@8" (ByVal dionum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_ExtDIOWr Lib "BTICARD.DLL" Alias "_BTICard_ExtDIOWr@12" (ByVal dionum As Int32, ByVal dioval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ExtLEDRd Lib "BTICARD.DLL" Alias "_BTICard_ExtLEDRd@4" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_ExtLEDWr Lib "BTICARD.DLL" Alias "_BTICard_ExtLEDWr@8" (ByVal ledval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ExtStatusLEDRd Lib "BTICARD.DLL" Alias "_BTICard_ExtStatusLEDRd@12" (ByRef ledon As Int32, ByRef ledcolor As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ExtStatusLEDWr Lib "BTICARD.DLL" Alias "_BTICard_ExtStatusLEDWr@12" (ByVal ledon As Int32, ByVal ledcolor As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_FileClose Lib "BTICARD.DLL" Alias "_BTICard_FileClose@4" (ByVal handle As IntPtr)
        Public Declare Function BTICard_FileErr Lib "BTICARD.DLL" Alias "_BTICard_FileErr@0" () As Int32
        Public Declare Sub BTICard_FileErrClr Lib "BTICARD.DLL" Alias "_BTICard_FileErrClr@0" ()
        Public Declare Sub BTICard_FileErrSet Lib "BTICARD.DLL" Alias "_BTICard_FileErrSet@0" ()
        Public Declare Function BTICard_FileOpenRead Lib "BTICARD.DLL" Alias "_BTICard_FileOpenRead@4" (ByRef filename As String) As UInt32
        Public Declare Function BTICard_FileOpenWrite Lib "BTICARD.DLL" Alias "_BTICard_FileOpenWrite@4" (ByRef filename As String) As UInt32
        Public Declare Function BTICard_FileRead Lib "BTICARD.DLL" Alias "_BTICard_FileRead@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
        Public Declare Function BTICard_FileSeek Lib "BTICARD.DLL" Alias "_BTICard_FileSeek@8" (ByVal handle As IntPtr, ByVal offset As UInt32) As Int32
        Public Declare Function BTICard_FileTell Lib "BTICARD.DLL" Alias "_BTICard_FileTell@4" (ByVal handle As IntPtr) As UInt32
        Public Declare Function BTICard_FileWrite Lib "BTICARD.DLL" Alias "_BTICard_FileWrite@12" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
        Public Declare Function BTICard_GetHigh Lib "BTICARD.DLL" Alias "_BTICard_GetHigh@4" (ByVal val As UInt32) As UInt16
        Public Declare Function BTICard_GetLow Lib "BTICARD.DLL" Alias "_BTICard_GetLow@4" (ByVal val As UInt32) As UInt16
        Public Declare Function BTICard_GlobalRdW Lib "BTICARD.DLL" Alias "_BTICard_GlobalRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_GlobalWrW Lib "BTICARD.DLL" Alias "_BTICard_GlobalWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_HandleInfoEx Lib "BTICARD.DLL" Alias "_BTICard_HandleInfoEx@12" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_HandleIsCard Lib "BTICARD.DLL" Alias "_BTICard_HandleIsCard@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_HandleIsCore Lib "BTICARD.DLL" Alias "_BTICard_HandleIsCore@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_HandleMakeCard Lib "BTICARD.DLL" Alias "_BTICard_HandleMakeCard@12" (ByRef lphcard As UInt32, ByRef lpcorenum As Int32, ByVal hcore As UInt32) As Int32
        Public Declare Function BTICard_HandleMakeCore Lib "BTICARD.DLL" Alias "_BTICard_HandleMakeCore@12" (ByRef lphcore As UInt32, ByVal corenum As Int32, ByVal hcard As UInt32) As Int32
        Public Declare Function BTICard_HandleMakeRPC Lib "BTICARD.DLL" Alias "_BTICard_HandleMakeRPC@12" (ByRef hcard_remote As UInt32, ByRef lphrpc As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_HandleOkay Lib "BTICARD.DLL" Alias "_BTICard_HandleOkay@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_HeapAlloc Lib "BTICARD.DLL" Alias "_BTICard_HeapAlloc@12" (ByVal section As Int32, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_HeapAllocAll Lib "BTICARD.DLL" Alias "_BTICard_HeapAllocAll@12" (ByVal section As Int32, ByRef wordcount As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_HeapAllocEx Lib "BTICARD.DLL" Alias "_BTICard_HeapAllocEx@16" (ByVal configval As UInt16, ByVal section As Int32, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_HeapWipe Lib "BTICARD.DLL" Alias "_BTICard_HeapWipe@8" (ByVal section As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_HPIFill Lib "BTICARD.DLL" Alias "_BTICard_HPIFill@16" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_HPIRdL Lib "BTICARD.DLL" Alias "_BTICard_HPIRdL@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_HPIRdsL Lib "BTICARD.DLL" Alias "_BTICard_HPIRdsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_HPIRdsW Lib "BTICARD.DLL" Alias "_BTICard_HPIRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_HPIRdW Lib "BTICARD.DLL" Alias "_BTICard_HPIRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_HPIWrL Lib "BTICARD.DLL" Alias "_BTICard_HPIWrL@12" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_HPIWrsL Lib "BTICARD.DLL" Alias "_BTICard_HPIWrsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_HPIWrsW Lib "BTICARD.DLL" Alias "_BTICard_HPIWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_HPIWrW Lib "BTICARD.DLL" Alias "_BTICard_HPIWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_IDRegRd Lib "BTICARD.DLL" Alias "_BTICard_IDRegRd@8" (ByVal gate_array_num As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_IDRegWr Lib "BTICARD.DLL" Alias "_BTICard_IDRegWr@12" (ByVal value As UInt16, ByVal gate_array_num As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_IntClear Lib "BTICARD.DLL" Alias "_BTICard_IntClear@4" (ByVal handleval As UInt32)
        Public Declare Function BTICard_IntDisable Lib "BTICARD.DLL" Alias "_BTICard_IntDisable@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IntEnable Lib "BTICARD.DLL" Alias "_BTICard_IntEnable@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IntEnableCond Lib "BTICARD.DLL" Alias "_BTICard_IntEnableCond@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IntGet Lib "BTICARD.DLL" Alias "_BTICard_IntGet@4" (ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_IntInstall Lib "BTICARD.DLL" Alias "_BTICard_IntInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_IntReset Lib "BTICARD.DLL" Alias "_BTICard_IntReset@4" (ByVal handleval As UInt32)
        Public Declare Function BTICard_IntUninstall Lib "BTICARD.DLL" Alias "_BTICard_IntUninstall@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IORdL Lib "BTICARD.DLL" Alias "_BTICard_IORdL@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_IORdW Lib "BTICARD.DLL" Alias "_BTICard_IORdW@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_IOWINRdW Lib "BTICARD.DLL" Alias "_BTICard_IOWINRdW@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_IOWINWrW Lib "BTICARD.DLL" Alias "_BTICard_IOWINWrW@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_IOWrL Lib "BTICARD.DLL" Alias "_BTICard_IOWrL@12" (ByVal value As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_IOWrW Lib "BTICARD.DLL" Alias "_BTICard_IOWrW@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_IRIGConfig Lib "BTICARD.DLL" Alias "_BTICard_IRIGConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGFieldGetDays Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetDays@8" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Function BTICard_IRIGFieldGetHours Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetHours@8" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Function BTICard_IRIGFieldGetMicrosec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetMicrosec@8" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Function BTICard_IRIGFieldGetMillisec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetMillisec@8" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Function BTICard_IRIGFieldGetMin Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetMin@8" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Function BTICard_IRIGFieldGetSec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetSec@8" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Sub BTICard_IRIGFieldPutDays Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutDays@12" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Sub BTICard_IRIGFieldPutHours Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutHours@12" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Sub BTICard_IRIGFieldPutMicrosec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutMicrosec@12" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Sub BTICard_IRIGFieldPutMillisec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutMillisec@12" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Sub BTICard_IRIGFieldPutMin Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutMin@12" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Sub BTICard_IRIGFieldPutSec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutSec@12" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Function BTICard_IRIGInputThresholdGet Lib "BTICARD.DLL" Alias "_BTICard_IRIGInputThresholdGet@8" (ByRef dacval As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGInputThresholdSet Lib "BTICARD.DLL" Alias "_BTICard_IRIGInputThresholdSet@8" (ByVal dacval As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGRd Lib "BTICARD.DLL" Alias "_BTICard_IRIGRd@8" (ByRef irigtime As BTIIRIGTIME, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGRdEx Lib "BTICARD.DLL" Alias "_BTICard_IRIGRdEx@8" (ByRef timebuf As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGSyncStatus Lib "BTICARD.DLL" Alias "_BTICard_IRIGSyncStatus@4" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_IRIGTimeBCDToBin Lib "BTICARD.DLL" Alias "_BTICard_IRIGTimeBCDToBin@16" (ByRef timevalh As UInt32, ByRef timevall As UInt32, ByVal irigvalh As UInt32, ByVal irigvall As UInt32)
        Public Declare Sub BTICard_IRIGTimeBinToBCD Lib "BTICARD.DLL" Alias "_BTICard_IRIGTimeBinToBCD@16" (ByRef irigvalh As UInt32, ByRef irigvall As UInt32, ByVal timevalh As UInt32, ByVal timevall As UInt32)
        Public Declare Function BTICard_IRIGWr Lib "BTICARD.DLL" Alias "_BTICard_IRIGWr@8" (ByRef irigtime As BTIIRIGTIME, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGWrEx Lib "BTICARD.DLL" Alias "_BTICard_IRIGWrEx@8" (ByRef timebuf As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_KernIntStatus Lib "BTICARD.DLL" Alias "_BTICard_KernIntStatus@8" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_KernStatus Lib "BTICARD.DLL" Alias "_BTICard_KernStatus@12" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_KernStatusEx Lib "BTICARD.DLL" Alias "_BTICard_KernStatusEx@16" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal index As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_MakeLong Lib "BTICARD.DLL" Alias "_BTICard_MakeLong@8" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
        Public Declare Function BTICard_MakeWord Lib "BTICARD.DLL" Alias "_BTICard_MakeWord@8" (ByVal valh As Byte, ByVal vall As Byte) As UInt16
        Public Declare Function BTICard_MantToAscii Lib "BTICARD.DLL" Alias "_BTICard_MantToAscii@12" (ByRef buf As String, ByVal mant As Int32, ByVal exp As Int32) As UInt32
        Public Declare Function BTICard_Mask Lib "BTICARD.DLL" Alias "_BTICard_Mask@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
        Public Declare Sub BTICard_MaxMant Lib "BTICARD.DLL" Alias "_BTICard_MaxMant@8" (ByRef mant As UInt32, ByRef exp As Int32)
        Public Declare Function BTICard_Mod Lib "BTICARD.DLL" Alias "_BTICard_Mod@8" (ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
        Public Declare Sub BTICard_Mod64 Lib "BTICARD.DLL" Alias "_BTICard_Mod64@24" (ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        Public Declare Function BTICard_Mul Lib "BTICARD.DLL" Alias "_BTICard_Mul@8" (ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
        Public Declare Sub BTICard_Mul64 Lib "BTICARD.DLL" Alias "_BTICard_Mul64@24" (ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        Public Declare Sub BTICard_NormalMant Lib "BTICARD.DLL" Alias "_BTICard_NormalMant@8" (ByRef mant As UInt32, ByRef exp As Int32)
        Public Declare Function BTICard_PortRd Lib "BTICARD.DLL" Alias "_BTICard_PortRd@8" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_PortWr Lib "BTICARD.DLL" Alias "_BTICard_PortWr@12" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ProgRdW Lib "BTICARD.DLL" Alias "_BTICard_ProgRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_ProgWrW Lib "BTICARD.DLL" Alias "_BTICard_ProgWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMFill Lib "BTICARD.DLL" Alias "_BTICard_RAMFill@16" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICard_RAMRdB Lib "BTICARD.DLL" Alias "_BTICard_RAMRdB@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_RAMRdL Lib "BTICARD.DLL" Alias "_BTICard_RAMRdL@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_RAMRdmL Lib "BTICARD.DLL" Alias "_BTICard_RAMRdmL@16" (ByRef valueptr As UInt32, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMRdmW Lib "BTICARD.DLL" Alias "_BTICard_RAMRdmW@16" (ByRef valueptr As UInt16, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMRdsL Lib "BTICARD.DLL" Alias "_BTICard_RAMRdsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMRdsW Lib "BTICARD.DLL" Alias "_BTICard_RAMRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_RAMRdW Lib "BTICARD.DLL" Alias "_BTICard_RAMRdW@8" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_RAMWipe Lib "BTICARD.DLL" Alias "_BTICard_RAMWipe@4" (ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWipeEx Lib "BTICARD.DLL" Alias "_BTICard_RAMWipeEx@8" (ByVal value As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrB Lib "BTICARD.DLL" Alias "_BTICard_RAMWrB@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrL Lib "BTICARD.DLL" Alias "_BTICard_RAMWrL@12" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrmL Lib "BTICARD.DLL" Alias "_BTICard_RAMWrmL@16" (ByRef valueptr As UInt32, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrmW Lib "BTICARD.DLL" Alias "_BTICard_RAMWrmW@16" (ByRef valueptr As UInt16, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrsL Lib "BTICARD.DLL" Alias "_BTICard_RAMWrsL@16" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrsW Lib "BTICARD.DLL" Alias "_BTICard_RAMWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrW Lib "BTICARD.DLL" Alias "_BTICard_RAMWrW@12" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ReverseLong Lib "BTICARD.DLL" Alias "_BTICard_ReverseLong@4" (ByVal value As UInt32) As UInt32
        Public Declare Function BTICard_ReverseWord Lib "BTICARD.DLL" Alias "_BTICard_ReverseWord@4" (ByVal value As UInt16) As UInt16
        Public Declare Function BTICard_SeqBlkRd Lib "BTICARD.DLL" Alias "_BTICard_SeqBlkRd@16" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SeqBlkRdEx Lib "BTICARD.DLL" Alias "_BTICard_SeqBlkRdEx@20" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal maxblkcnt As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SeqClear Lib "BTICARD.DLL" Alias "_BTICard_SeqClear@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqCommRd Lib "BTICARD.DLL" Alias "_BTICard_SeqCommRd@12" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SeqConfig Lib "BTICARD.DLL" Alias "_BTICard_SeqConfig@8" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqConfigEx Lib "BTICARD.DLL" Alias "_BTICard_SeqConfigEx@16" (ByVal configval As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqConfigExx Lib "BTICARD.DLL" Alias "_BTICard_SeqConfigExx@20" (ByVal configval As UInt32, ByVal seqaddr As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqDMARd Lib "BTICARD.DLL" Alias "_BTICard_SeqDMARd@12" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SeqFindCheckVersion Lib "BTICARD.DLL" Alias "_BTICard_SeqFindCheckVersion@8" (ByRef precord As UInt16, ByVal version As UInt16) As Int32
        Public Declare Function BTICard_SeqFindInit Lib "BTICARD.DLL" Alias "_BTICard_SeqFindInit@12" (ByRef seqbuf As UInt16, ByVal seqbufsize As UInt32, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindMore1553Ex Lib "BTICARD.DLL" Alias "_BTICard_SeqFindMore1553Ex@12" (ByRef precmore As SEQRECORDMORE1553, ByVal recordsize As UInt16, ByRef precbase As SEQRECORD1553) As Int32
        Public Declare Function BTICard_SeqFindNext1553Ex Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNext1553Ex@12" (ByRef precord As SEQRECORD1553, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNext429Ex Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNext429Ex@12" (ByRef precord As SEQRECORD429, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNext708Ex Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNext708Ex@12" (ByRef precord As SEQRECORD708, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNext717Ex Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNext717Ex@12" (ByRef precord As SEQRECORD717, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNextCSDBEx Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNextCSDBEx@12" (ByRef precord As SEQRECORDCSDB, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNextDIOEx Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNextDIOEx@12" (ByRef precord As SEQRECORDDIO, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNextEx Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNextEx@16" (ByRef precord As UInt16, ByVal recordcount As UInt16, ByRef seqtype As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqInterval Lib "BTICARD.DLL" Alias "_BTICard_SeqInterval@12" (ByVal interval As Int32, ByVal mode As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqIntervalEx Lib "BTICARD.DLL" Alias "_BTICard_SeqIntervalEx@8" (ByVal shiftval As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SeqIsRunning Lib "BTICARD.DLL" Alias "_BTICard_SeqIsRunning@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqLogFrequency Lib "BTICARD.DLL" Alias "_BTICard_SeqLogFrequency@8" (ByVal logfreq As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SeqRd Lib "BTICARD.DLL" Alias "_BTICard_SeqRd@8" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SeqRdEx Lib "BTICARD.DLL" Alias "_BTICard_SeqRdEx@12" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SeqResume Lib "BTICARD.DLL" Alias "_BTICard_SeqResume@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqStart Lib "BTICARD.DLL" Alias "_BTICard_SeqStart@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqStatus Lib "BTICARD.DLL" Alias "_BTICard_SeqStatus@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqStop Lib "BTICARD.DLL" Alias "_BTICard_SeqStop@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_Shl Lib "BTICARD.DLL" Alias "_BTICard_Shl@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
        Public Declare Function BTICard_Shr Lib "BTICARD.DLL" Alias "_BTICard_Shr@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
        Public Declare Function BTICard_SignMant Lib "BTICARD.DLL" Alias "_BTICard_SignMant@4" (ByRef str As String) As UInt16
        Public Declare Sub BTICard_Sub64 Lib "BTICARD.DLL" Alias "_BTICard_Sub64@24" (ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        Public Declare Sub BTICard_SwapEndianL Lib "BTICARD.DLL" Alias "_BTICard_SwapEndianL@4" (ByRef value As UInt32)
        Public Declare Sub BTICard_SwapEndianW Lib "BTICARD.DLL" Alias "_BTICard_SwapEndianW@8" (ByRef valuea As UInt16, ByRef valueb As UInt16)
        Public Declare Sub BTICard_SwapIfBigEndianL Lib "BTICARD.DLL" Alias "_BTICard_SwapIfBigEndianL@4" (ByRef value As UInt32)
        Public Declare Sub BTICard_SwapIfBigEndianW Lib "BTICARD.DLL" Alias "_BTICard_SwapIfBigEndianW@8" (ByRef valuea As UInt16, ByRef valueb As UInt16)
        Public Declare Sub BTICard_SwapIfLittleEndianL Lib "BTICARD.DLL" Alias "_BTICard_SwapIfLittleEndianL@4" (ByRef value As UInt32)
        Public Declare Sub BTICard_SwapIfLittleEndianW Lib "BTICARD.DLL" Alias "_BTICard_SwapIfLittleEndianW@8" (ByRef valuea As UInt16, ByRef valueb As UInt16)
        Public Declare Function BTICard_SysMonClear Lib "BTICARD.DLL" Alias "_BTICard_SysMonClear@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonInit Lib "BTICARD.DLL" Alias "_BTICard_SysMonInit@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonTypeGet Lib "BTICARD.DLL" Alias "_BTICard_SysMonTypeGet@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SysMonDescGet Lib "BTICARD.DLL" Alias "_BTICard_SysMonDescGet@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SysMonMaxRd Lib "BTICARD.DLL" Alias "_BTICard_SysMonMaxRd@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonMinRd Lib "BTICARD.DLL" Alias "_BTICard_SysMonMinRd@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonNomRd Lib "BTICARD.DLL" Alias "_BTICard_SysMonNomRd@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonUserStr Lib "BTICARD.DLL" Alias "_BTICard_SysMonUserStr@12" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SysMonValRd Lib "BTICARD.DLL" Alias "_BTICard_SysMonValRd@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonValStr Lib "BTICARD.DLL" Alias "_BTICard_SysMonValStr@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SysMonThresholdSet Lib "BTICARD.DLL" Alias "_BTICard_SysMonThresholdSet@20" (ByVal enable As Int32, ByVal minval As Int32, ByVal maxval As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonValToDAC Lib "BTICARD.DLL" Alias "_BTICard_SysMonValToDAC@24" (ByVal val As Int32, ByVal rangemin As Int32, ByVal rangemax As Int32, ByVal dacval_max As UInt16, ByVal scalefactor As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SysMonDACToVal Lib "BTICARD.DLL" Alias "_BTICard_SysMonDACToVal@24" (ByVal dacval As UInt16, ByVal rangemin As Int32, ByVal rangemax As Int32, ByVal dacval_max As UInt16, ByVal scalefactor As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_TickTimerStart Lib "BTICARD.DLL" Alias "_BTICard_TickTimerStart@4" (ByVal milliseconds As Int32) As Int32
        Public Declare Function BTICard_TickTimerValid Lib "BTICARD.DLL" Alias "_BTICard_TickTimerValid@4" (ByVal timer As Int32) As Int32
        Public Declare Function BTICard_Timer64Rd Lib "BTICARD.DLL" Alias "_BTICard_Timer64Rd@12" (ByRef valueh As UInt32, ByRef valuel As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_Timer64Wr Lib "BTICARD.DLL" Alias "_BTICard_Timer64Wr@12" (ByVal valueh As UInt32, ByVal valuel As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_TimerClear Lib "BTICARD.DLL" Alias "_BTICard_TimerClear@4" (ByVal handleval As UInt32)
        Public Declare Function BTICard_TimerRd Lib "BTICARD.DLL" Alias "_BTICard_TimerRd@4" (ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_TimerResolution Lib "BTICARD.DLL" Alias "_BTICard_TimerResolution@8" (ByVal timerresol As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_TimerResolutionEx Lib "BTICARD.DLL" Alias "_BTICard_TimerResolutionEx@8" (ByVal timershift As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_TimerStatus Lib "BTICARD.DLL" Alias "_BTICard_TimerStatus@4" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_TimerWr Lib "BTICARD.DLL" Alias "_BTICard_TimerWr@8" (ByVal value As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ValAsciiCmpi Lib "BTICARD.DLL" Alias "_BTICard_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Int32
        Public Declare Function BTICard_ValAsciiCpy Lib "BTICARD.DLL" Alias "_BTICard_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Int32) As UInt32
        Public Declare Sub BTICard_ValAsciiTrimLead Lib "BTICARD.DLL" Alias "_BTICard_ValAsciiTrimLead@4" (ByRef buf As String)
        Public Declare Sub BTICard_ValAsciiTrimTrail Lib "BTICARD.DLL" Alias "_BTICard_ValAsciiTrimTrail@4" (ByRef buf As String)
        Public Declare Function BTICard_ValFromAscii Lib "BTICARD.DLL" Alias "_BTICard_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
        Public Declare Function BTICard_ValGetBits Lib "BTICARD.DLL" Alias "_BTICard_ValGetBits@12" (ByVal oldvalue As UInt32, ByVal startbit As Int32, ByVal endbit As Int32) As UInt32
        Public Declare Function BTICard_ValIncAscii Lib "BTICARD.DLL" Alias "_BTICard_ValIncAscii@4" (ByRef asciistr As String) As UInt32
        Public Declare Function BTICard_ValInccAscii Lib "BTICARD.DLL" Alias "_BTICard_ValInccAscii@4" (ByRef asciistr As String) As UInt32
        Public Declare Function BTICard_ValIsLower Lib "BTICARD.DLL" Alias "_BTICard_ValIsLower@4" (ByVal value As Int32) As Int32
        Public Declare Function BTICard_ValLenAscii Lib "BTICARD.DLL" Alias "_BTICard_ValLenAscii@8" (ByVal numbits As Int32, ByVal radixval As Int32) As Int32
        Public Declare Function BTICard_ValPutBits Lib "BTICARD.DLL" Alias "_BTICard_ValPutBits@16" (ByVal oldvalue As UInt32, ByVal newfld As UInt32, ByVal startbit As Int32, ByVal endbit As Int32) As UInt32
        Public Declare Function BTICard_ValToAscii Lib "BTICARD.DLL" Alias "_BTICard_ValToAscii@16" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
        Public Declare Function BTICard_ValToUpper Lib "BTICARD.DLL" Alias "_BTICard_ValToUpper@4" (ByVal value As Int32) As Int32
        Public Declare Function BTICard_VARRdL Lib "BTICARD.DLL" Alias "_BTICard_VARRdL@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_VARRdsW Lib "BTICARD.DLL" Alias "_BTICard_VARRdsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_VARRdW Lib "BTICARD.DLL" Alias "_BTICard_VARRdW@8" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_VARWrL Lib "BTICARD.DLL" Alias "_BTICard_VARWrL@12" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_VARWrsW Lib "BTICARD.DLL" Alias "_BTICard_VARWrsW@16" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_VARWrW Lib "BTICARD.DLL" Alias "_BTICard_VARWrW@12" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    End Class

    Private Class BTICARD_64
        Public Declare Sub BTICard_Add64 Lib "BTICARD64.DLL" Alias "BTICard_Add64" (ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        Public Declare Function BTICard_AddrDSP Lib "BTICARD64.DLL" Alias "BTICard_AddrDSP" (ByVal addr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_AddrHost Lib "BTICARD64.DLL" Alias "BTICard_AddrHost" (ByVal addr As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_AsciiToMant Lib "BTICARD64.DLL" Alias "BTICard_AsciiToMant" (ByRef str As String, ByRef mant As UInt32, ByRef exp As Int32) As Int32
        Public Declare Function BTICard_BCDToBin Lib "BTICARD64.DLL" Alias "BTICard_BCDToBin" (ByVal bcdval As UInt32, ByVal msb As Int32, ByVal lsb As Int32) As UInt32
        Public Declare Function BTICard_BinToBCD Lib "BTICARD64.DLL" Alias "BTICard_BinToBCD" (ByVal oldbcdval As UInt32, ByVal binval As UInt32, ByVal msb As Int32, ByVal lsb As Int32) As UInt32
        Public Declare Function BTICard_BITConfig Lib "BTICARD64.DLL" Alias "BTICard_BITConfig" (ByVal ctrlflags As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_BITInitiate Lib "BTICARD64.DLL" Alias "BTICard_BITInitiate" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_BITStatusClear Lib "BTICARD64.DLL" Alias "BTICard_BITStatusClear" (ByVal statval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_BITStatusRd Lib "BTICARD64.DLL" Alias "BTICard_BITStatusRd" (ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_CardClose Lib "BTICARD64.DLL" Alias "BTICard_CardClose" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardCloseAll Lib "BTICARD64.DLL" Alias "BTICard_CardCloseAll" () As Int32
        Public Declare Function BTICard_CardGetInfo Lib "BTICARD64.DLL" Alias "BTICard_CardGetInfo" (ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_CardGetInfoEx Lib "BTICARD64.DLL" Alias "BTICard_CardGetInfoEx" (ByRef bufmodel As UInt16, ByVal bufmodelcount As UInt16, ByRef buffeature As UInt16, ByVal buffeaturecount As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardIsRunning Lib "BTICARD64.DLL" Alias "BTICard_CardIsRunning" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardNop Lib "BTICARD64.DLL" Alias "BTICard_CardNop" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardOpen Lib "BTICARD64.DLL" Alias "BTICard_CardOpen" (ByRef lphandle As UInt32, ByVal cardnum As Int32) As Int32
        Public Declare Function BTICard_CardOpenStr Lib "BTICARD64.DLL" Alias "BTICard_CardOpenStr" (ByRef lphandle As UInt32, ByRef cardstr As String) As Int32
        Public Declare Function BTICard_CardProductStr Lib "BTICARD64.DLL" Alias "BTICard_CardProductStr" (ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_CardReset Lib "BTICARD64.DLL" Alias "BTICard_CardReset" (ByVal handleval As UInt32)
        Public Declare Sub BTICard_CardResetEx Lib "BTICARD64.DLL" Alias "BTICard_CardResetEx" (ByVal handleval As UInt32)
        Public Declare Function BTICard_CardResume Lib "BTICARD64.DLL" Alias "BTICard_CardResume" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardShadow Lib "BTICARD64.DLL" Alias "BTICard_CardShadow" (ByVal shadowval As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardStart Lib "BTICARD64.DLL" Alias "BTICard_CardStart" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardStop Lib "BTICARD64.DLL" Alias "BTICard_CardStop" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_CardSyncEnable Lib "BTICARD64.DLL" Alias "BTICard_CardSyncEnable" (ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_CardSyncValid Lib "BTICARD64.DLL" Alias "BTICard_CardSyncValid" (ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_CardTest Lib "BTICARD64.DLL" Alias "BTICard_CardTest" (ByVal level As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardTest0 Lib "BTICARD64.DLL" Alias "BTICard_CardTest0" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardTest1 Lib "BTICARD64.DLL" Alias "BTICard_CardTest1" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardTest2 Lib "BTICARD64.DLL" Alias "BTICard_CardTest2" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CardTest3 Lib "BTICARD64.DLL" Alias "BTICard_CardTest3" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_CardTrigger Lib "BTICARD64.DLL" Alias "BTICard_CardTrigger" (ByVal handleval As UInt32)
        Public Declare Sub BTICard_CardTriggerEnable Lib "BTICARD64.DLL" Alias "BTICard_CardTriggerEnable" (ByVal enableflag As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_CardTriggerEnableEx Lib "BTICARD64.DLL" Alias "BTICard_CardTriggerEnableEx" (ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal pinpolarity As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_CardTriggerEx Lib "BTICARD64.DLL" Alias "BTICard_CardTriggerEx" (ByVal trigmask As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_CardTriggerValid Lib "BTICARD64.DLL" Alias "BTICard_CardTriggerValid" (ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_CardTypeStr Lib "BTICARD64.DLL" Alias "BTICard_CardTypeStr" (ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_ChDARClr Lib "BTICARD64.DLL" Alias "BTICard_ChDARClr" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ChDARGet Lib "BTICARD64.DLL" Alias "BTICard_ChDARGet" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_ChDARRdL Lib "BTICARD64.DLL" Alias "BTICard_ChDARRdL" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_ChDARRdsW Lib "BTICARD64.DLL" Alias "BTICard_ChDARRdsW" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ChDARRdW Lib "BTICARD64.DLL" Alias "BTICard_ChDARRdW" (ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_ChDARSet Lib "BTICARD64.DLL" Alias "BTICard_ChDARSet" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ChDARWrL Lib "BTICARD64.DLL" Alias "BTICard_ChDARWrL" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ChDARWrsW Lib "BTICARD64.DLL" Alias "BTICard_ChDARWrsW" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ChDARWrW Lib "BTICARD64.DLL" Alias "BTICard_ChDARWrW" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_CISRd Lib "BTICARD64.DLL" Alias "BTICard_CISRd" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal cistype As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CISWr Lib "BTICARD64.DLL" Alias "BTICard_CISWr" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal cistype As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommBufRd Lib "BTICARD64.DLL" Alias "BTICard_CommBufRd" (ByVal offset As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_CommBufWr Lib "BTICARD64.DLL" Alias "BTICard_CommBufWr" (ByVal value As UInt16, ByVal offset As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_CommCall Lib "BTICARD64.DLL" Alias "BTICard_CommCall" (ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommChannelReconfig Lib "BTICARD64.DLL" Alias "BTICard_CommChannelReconfig" (ByVal chmask As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommCheck Lib "BTICARD64.DLL" Alias "BTICard_CommCheck" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommDisable Lib "BTICARD64.DLL" Alias "BTICard_CommDisable" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommDisableEx Lib "BTICARD64.DLL" Alias "BTICard_CommDisableEx" (ByVal command As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommEnable Lib "BTICARD64.DLL" Alias "BTICard_CommEnable" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommExternSRQ Lib "BTICARD64.DLL" Alias "BTICard_CommExternSRQ" (ByVal chmask As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommFillW Lib "BTICARD64.DLL" Alias "BTICard_CommFillW" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommProtocolFunc Lib "BTICARD64.DLL" Alias "BTICard_CommProtocolFunc" (ByVal opcode As UInt16, ByVal argcount As UInt16, ByRef argbuf As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommRdL Lib "BTICARD64.DLL" Alias "BTICard_CommRdL" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_CommRdsW Lib "BTICARD64.DLL" Alias "BTICard_CommRdsW" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CommRdW Lib "BTICARD64.DLL" Alias "BTICard_CommRdW" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_CommRun Lib "BTICARD64.DLL" Alias "BTICard_CommRun" (ByRef dataptr As UInt16, ByVal datacount As UInt16, ByRef codeptr As UInt16, ByVal codecount As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_CommWrL Lib "BTICARD64.DLL" Alias "BTICard_CommWrL" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICard_CommWrsW Lib "BTICARD64.DLL" Alias "BTICard_CommWrsW" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_CommWrW Lib "BTICARD64.DLL" Alias "BTICard_CommWrW" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICard_CoProcCheck Lib "BTICARD64.DLL" Alias "BTICard_CoProcCheck" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcGetInfo Lib "BTICARD64.DLL" Alias "BTICard_CoProcGetInfo" (ByRef valueptr As UInt32, ByVal infotype As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemRdL Lib "BTICARD64.DLL" Alias "BTICard_CoProcMemRdL" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemRdsL Lib "BTICARD64.DLL" Alias "BTICard_CoProcMemRdsL" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemRdsW Lib "BTICARD64.DLL" Alias "BTICard_CoProcMemRdsW" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemRdW Lib "BTICARD64.DLL" Alias "BTICard_CoProcMemRdW" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemWrL Lib "BTICARD64.DLL" Alias "BTICard_CoProcMemWrL" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemWrsL Lib "BTICARD64.DLL" Alias "BTICard_CoProcMemWrsL" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemWrsW Lib "BTICARD64.DLL" Alias "BTICard_CoProcMemWrsW" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoProcMemWrW Lib "BTICARD64.DLL" Alias "BTICard_CoProcMemWrW" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_CoreOpen Lib "BTICARD64.DLL" Alias "BTICard_CoreOpen" (ByRef lphcore As UInt32, ByVal corenum As Int32, ByVal hcard As UInt32) As Int32
        Public Declare Sub BTICard_DARClr Lib "BTICARD64.DLL" Alias "BTICard_DARClr" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_DARGet Lib "BTICARD64.DLL" Alias "BTICard_DARGet" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DARRdL Lib "BTICARD64.DLL" Alias "BTICard_DARRdL" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_DARRdsW Lib "BTICARD64.DLL" Alias "BTICard_DARRdsW" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_DARRdW Lib "BTICARD64.DLL" Alias "BTICard_DARRdW" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_DARSet Lib "BTICARD64.DLL" Alias "BTICard_DARSet" (ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_DARWrL Lib "BTICARD64.DLL" Alias "BTICard_DARWrL" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_DARWrsW Lib "BTICARD64.DLL" Alias "BTICard_DARWrsW" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_DARWrW Lib "BTICARD64.DLL" Alias "BTICard_DARWrW" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_Div Lib "BTICARD64.DLL" Alias "BTICard_Div" (ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
        Public Declare Sub BTICard_Div64 Lib "BTICARD64.DLL" Alias "BTICard_Div64" (ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        Public Declare Function BTICard_DllUsageCount Lib "BTICARD64.DLL" Alias "BTICard_DllUsageCount" () As Int32
        Public Declare Function BTICard_DspBioClear Lib "BTICARD64.DLL" Alias "BTICard_DspBioClear" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspBioRd Lib "BTICARD64.DLL" Alias "BTICard_DspBioRd" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspBioSet Lib "BTICARD64.DLL" Alias "BTICard_DspBioSet" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspIntfClear Lib "BTICARD64.DLL" Alias "BTICard_DspIntfClear" (ByVal intmask As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspIntfRd Lib "BTICARD64.DLL" Alias "BTICard_DspIntfRd" (ByVal intmask As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspIntmClear Lib "BTICARD64.DLL" Alias "BTICard_DspIntmClear" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspIntmSet Lib "BTICARD64.DLL" Alias "BTICard_DspIntmSet" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspXfClear Lib "BTICARD64.DLL" Alias "BTICard_DspXfClear" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspXfRd Lib "BTICARD64.DLL" Alias "BTICard_DspXfRd" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_DspXfSet Lib "BTICARD64.DLL" Alias "BTICard_DspXfSet" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_ErrDesc Lib "BTICARD64.DLL" Alias "BTICard_ErrDesc" (ByVal errval As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_ErrDescStr Lib "BTICARD64.DLL" Alias "BTICard_ErrDescStr" (ByVal errval As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_ErrName Lib "BTICARD64.DLL" Alias "BTICard_ErrName" (ByVal errval As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_EventLogClear Lib "BTICARD64.DLL" Alias "BTICard_EventLogClear" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_EventLogConfig Lib "BTICARD64.DLL" Alias "BTICard_EventLogConfig" (ByVal configval As UInt16, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_EventLogRd Lib "BTICARD64.DLL" Alias "BTICard_EventLogRd" (ByRef typevalval As UInt16, ByRef infoval As UInt32, ByRef channel As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_EventLogStatus Lib "BTICARD64.DLL" Alias "BTICard_EventLogStatus" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_ExpandMant Lib "BTICARD64.DLL" Alias "BTICard_ExpandMant" (ByRef mant As UInt32, ByRef exp As Int32)
        Public Declare Function BTICard_ExtDinRd Lib "BTICARD64.DLL" Alias "BTICard_ExtDinRd" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_ExtDinWr Lib "BTICARD64.DLL" Alias "BTICard_ExtDinWr" (ByVal dinval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ExtDIODirSet Lib "BTICARD64.DLL" Alias "BTICard_ExtDIODirSet" (ByVal dionum As Int32, ByVal dirval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ExtDIOMonConfig Lib "BTICARD64.DLL" Alias "BTICard_ExtDIOMonConfig" (ByVal rise_edge As UInt16, ByVal fall_edge As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_ExtDIORd Lib "BTICARD64.DLL" Alias "BTICard_ExtDIORd" (ByVal dionum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_ExtDIOWr Lib "BTICARD64.DLL" Alias "BTICard_ExtDIOWr" (ByVal dionum As Int32, ByVal dioval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ExtLEDRd Lib "BTICARD64.DLL" Alias "BTICard_ExtLEDRd" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_ExtLEDWr Lib "BTICARD64.DLL" Alias "BTICard_ExtLEDWr" (ByVal ledval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ExtStatusLEDRd Lib "BTICARD64.DLL" Alias "BTICard_ExtStatusLEDRd" (ByRef ledon As Int32, ByRef ledcolor As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_ExtStatusLEDWr Lib "BTICARD64.DLL" Alias "BTICard_ExtStatusLEDWr" (ByVal ledon As Int32, ByVal ledcolor As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_FileClose Lib "BTICARD64.DLL" Alias "BTICard_FileClose" (ByVal handle As IntPtr)
        Public Declare Function BTICard_FileErr Lib "BTICARD64.DLL" Alias "BTICard_FileErr" () As Int32
        Public Declare Sub BTICard_FileErrClr Lib "BTICARD64.DLL" Alias "BTICard_FileErrClr" ()
        Public Declare Sub BTICard_FileErrSet Lib "BTICARD64.DLL" Alias "BTICard_FileErrSet" ()
        Public Declare Function BTICard_FileOpenRead Lib "BTICARD64.DLL" Alias "BTICard_FileOpenRead" (ByRef filename As String) As UInt32
        Public Declare Function BTICard_FileOpenWrite Lib "BTICARD64.DLL" Alias "BTICard_FileOpenWrite" (ByRef filename As String) As UInt32
        Public Declare Function BTICard_FileRead Lib "BTICARD64.DLL" Alias "BTICard_FileRead" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
        Public Declare Function BTICard_FileSeek Lib "BTICARD64.DLL" Alias "BTICard_FileSeek" (ByVal handle As IntPtr, ByVal offset As UInt32) As Int32
        Public Declare Function BTICard_FileTell Lib "BTICARD64.DLL" Alias "BTICard_FileTell" (ByVal handle As IntPtr) As UInt32
        Public Declare Function BTICard_FileWrite Lib "BTICARD64.DLL" Alias "BTICard_FileWrite" (ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
        Public Declare Function BTICard_GetHigh Lib "BTICARD64.DLL" Alias "BTICard_GetHigh" (ByVal val As UInt32) As UInt16
        Public Declare Function BTICard_GetLow Lib "BTICARD64.DLL" Alias "BTICard_GetLow" (ByVal val As UInt32) As UInt16
        Public Declare Function BTICard_GlobalRdW Lib "BTICARD64.DLL" Alias "BTICard_GlobalRdW" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_GlobalWrW Lib "BTICARD64.DLL" Alias "BTICard_GlobalWrW" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_HandleInfoEx Lib "BTICARD64.DLL" Alias "BTICard_HandleInfoEx" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_HandleIsCard Lib "BTICARD64.DLL" Alias "BTICard_HandleIsCard" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_HandleIsCore Lib "BTICARD64.DLL" Alias "BTICard_HandleIsCore" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_HandleMakeCard Lib "BTICARD64.DLL" Alias "BTICard_HandleMakeCard" (ByRef lphcard As UInt32, ByRef lpcorenum As Int32, ByVal hcore As UInt32) As Int32
        Public Declare Function BTICard_HandleMakeCore Lib "BTICARD64.DLL" Alias "BTICard_HandleMakeCore" (ByRef lphcore As UInt32, ByVal corenum As Int32, ByVal hcard As UInt32) As Int32
        Public Declare Function BTICard_HandleMakeRPC Lib "BTICARD64.DLL" Alias "BTICard_HandleMakeRPC" (ByRef hcard_remote As UInt32, ByRef lphrpc As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_HandleOkay Lib "BTICARD64.DLL" Alias "BTICard_HandleOkay" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_HeapAlloc Lib "BTICARD64.DLL" Alias "BTICard_HeapAlloc" (ByVal section As Int32, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_HeapAllocAll Lib "BTICARD64.DLL" Alias "BTICard_HeapAllocAll" (ByVal section As Int32, ByRef wordcount As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_HeapAllocEx Lib "BTICARD64.DLL" Alias "BTICard_HeapAllocEx" (ByVal configval As UInt16, ByVal section As Int32, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_HeapWipe Lib "BTICARD64.DLL" Alias "BTICard_HeapWipe" (ByVal section As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_HPIFill Lib "BTICARD64.DLL" Alias "BTICard_HPIFill" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_HPIRdL Lib "BTICARD64.DLL" Alias "BTICard_HPIRdL" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_HPIRdsL Lib "BTICARD64.DLL" Alias "BTICard_HPIRdsL" (ByRef valueptr As UInt32, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_HPIRdsW Lib "BTICARD64.DLL" Alias "BTICard_HPIRdsW" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_HPIRdW Lib "BTICARD64.DLL" Alias "BTICard_HPIRdW" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_HPIWrL Lib "BTICARD64.DLL" Alias "BTICard_HPIWrL" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_HPIWrsL Lib "BTICARD64.DLL" Alias "BTICard_HPIWrsL" (ByRef valueptr As UInt32, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_HPIWrsW Lib "BTICARD64.DLL" Alias "BTICard_HPIWrsW" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_HPIWrW Lib "BTICARD64.DLL" Alias "BTICard_HPIWrW" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Function BTICard_IDRegRd Lib "BTICARD64.DLL" Alias "BTICard_IDRegRd" (ByVal gate_array_num As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_IDRegWr Lib "BTICARD64.DLL" Alias "BTICard_IDRegWr" (ByVal value As UInt16, ByVal gate_array_num As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_IntClear Lib "BTICARD64.DLL" Alias "BTICard_IntClear" (ByVal handleval As UInt32)
        Public Declare Function BTICard_IntDisable Lib "BTICARD64.DLL" Alias "BTICard_IntDisable" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IntEnable Lib "BTICARD64.DLL" Alias "BTICard_IntEnable" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IntEnableCond Lib "BTICARD64.DLL" Alias "BTICard_IntEnableCond" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IntGet Lib "BTICARD64.DLL" Alias "BTICard_IntGet" (ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_IntInstall Lib "BTICARD64.DLL" Alias "BTICard_IntInstall" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_IntReset Lib "BTICARD64.DLL" Alias "BTICard_IntReset" (ByVal handleval As UInt32)
        Public Declare Function BTICard_IntUninstall Lib "BTICARD64.DLL" Alias "BTICard_IntUninstall" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IORdL Lib "BTICARD64.DLL" Alias "BTICard_IORdL" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_IORdW Lib "BTICARD64.DLL" Alias "BTICard_IORdW" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_IOWINRdW Lib "BTICARD64.DLL" Alias "BTICard_IOWINRdW" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_IOWINWrW Lib "BTICARD64.DLL" Alias "BTICard_IOWINWrW" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_IOWrL Lib "BTICARD64.DLL" Alias "BTICard_IOWrL" (ByVal value As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_IOWrW Lib "BTICARD64.DLL" Alias "BTICard_IOWrW" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_IRIGConfig Lib "BTICARD64.DLL" Alias "BTICard_IRIGConfig" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGFieldGetDays Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldGetDays" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Function BTICard_IRIGFieldGetHours Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldGetHours" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Function BTICard_IRIGFieldGetMicrosec Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldGetMicrosec" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Function BTICard_IRIGFieldGetMillisec Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldGetMillisec" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Function BTICard_IRIGFieldGetMin Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldGetMin" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Function BTICard_IRIGFieldGetSec Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldGetSec" (ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        Public Declare Sub BTICard_IRIGFieldPutDays Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldPutDays" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Sub BTICard_IRIGFieldPutHours Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldPutHours" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Sub BTICard_IRIGFieldPutMicrosec Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldPutMicrosec" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Sub BTICard_IRIGFieldPutMillisec Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldPutMillisec" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Sub BTICard_IRIGFieldPutMin Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldPutMin" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Sub BTICard_IRIGFieldPutSec Lib "BTICARD64.DLL" Alias "BTICard_IRIGFieldPutSec" (ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        Public Declare Function BTICard_IRIGInputThresholdGet Lib "BTICARD64.DLL" Alias "BTICard_IRIGInputThresholdGet" (ByRef dacval As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGInputThresholdSet Lib "BTICARD64.DLL" Alias "BTICard_IRIGInputThresholdSet" (ByVal dacval As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGRd Lib "BTICARD64.DLL" Alias "BTICard_IRIGRd" (ByRef irigtime As BTIIRIGTIME, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGRdEx Lib "BTICARD64.DLL" Alias "BTICard_IRIGRdEx" (ByRef timebuf As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGSyncStatus Lib "BTICARD64.DLL" Alias "BTICard_IRIGSyncStatus" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_IRIGTimeBCDToBin Lib "BTICARD64.DLL" Alias "BTICard_IRIGTimeBCDToBin" (ByRef timevalh As UInt32, ByRef timevall As UInt32, ByVal irigvalh As UInt32, ByVal irigvall As UInt32)
        Public Declare Sub BTICard_IRIGTimeBinToBCD Lib "BTICARD64.DLL" Alias "BTICard_IRIGTimeBinToBCD" (ByRef irigvalh As UInt32, ByRef irigvall As UInt32, ByVal timevalh As UInt32, ByVal timevall As UInt32)
        Public Declare Function BTICard_IRIGWr Lib "BTICARD64.DLL" Alias "BTICard_IRIGWr" (ByRef irigtime As BTIIRIGTIME, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_IRIGWrEx Lib "BTICARD64.DLL" Alias "BTICard_IRIGWrEx" (ByRef timebuf As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_KernIntStatus Lib "BTICARD64.DLL" Alias "BTICard_KernIntStatus" (ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_KernStatus Lib "BTICARD64.DLL" Alias "BTICard_KernStatus" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_KernStatusEx Lib "BTICARD64.DLL" Alias "BTICard_KernStatusEx" (ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal index As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_MakeLong Lib "BTICARD64.DLL" Alias "BTICard_MakeLong" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
        Public Declare Function BTICard_MakeWord Lib "BTICARD64.DLL" Alias "BTICard_MakeWord" (ByVal valh As Byte, ByVal vall As Byte) As UInt16
        Public Declare Function BTICard_MantToAscii Lib "BTICARD64.DLL" Alias "BTICard_MantToAscii" (ByRef buf As String, ByVal mant As Int32, ByVal exp As Int32) As UInt32
        Public Declare Function BTICard_Mask Lib "BTICARD64.DLL" Alias "BTICard_Mask" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
        Public Declare Sub BTICard_MaxMant Lib "BTICARD64.DLL" Alias "BTICard_MaxMant" (ByRef mant As UInt32, ByRef exp As Int32)
        Public Declare Function BTICard_Mod Lib "BTICARD64.DLL" Alias "BTICard_Mod" (ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
        Public Declare Sub BTICard_Mod64 Lib "BTICARD64.DLL" Alias "BTICard_Mod64" (ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        Public Declare Function BTICard_Mul Lib "BTICARD64.DLL" Alias "BTICard_Mul" (ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
        Public Declare Sub BTICard_Mul64 Lib "BTICARD64.DLL" Alias "BTICard_Mul64" (ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        Public Declare Sub BTICard_NormalMant Lib "BTICARD64.DLL" Alias "BTICard_NormalMant" (ByRef mant As UInt32, ByRef exp As Int32)
        Public Declare Function BTICard_PortRd Lib "BTICARD64.DLL" Alias "BTICard_PortRd" (ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_PortWr Lib "BTICARD64.DLL" Alias "BTICard_PortWr" (ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ProgRdW Lib "BTICARD64.DLL" Alias "BTICard_ProgRdW" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_ProgWrW Lib "BTICARD64.DLL" Alias "BTICard_ProgWrW" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMFill Lib "BTICARD64.DLL" Alias "BTICard_RAMFill" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICard_RAMRdB Lib "BTICARD64.DLL" Alias "BTICard_RAMRdB" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_RAMRdL Lib "BTICARD64.DLL" Alias "BTICard_RAMRdL" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_RAMRdmL Lib "BTICARD64.DLL" Alias "BTICard_RAMRdmL" (ByRef valueptr As UInt32, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMRdmW Lib "BTICARD64.DLL" Alias "BTICard_RAMRdmW" (ByRef valueptr As UInt16, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMRdsL Lib "BTICARD64.DLL" Alias "BTICard_RAMRdsL" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMRdsW Lib "BTICARD64.DLL" Alias "BTICard_RAMRdsW" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_RAMRdW Lib "BTICARD64.DLL" Alias "BTICard_RAMRdW" (ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_RAMWipe Lib "BTICARD64.DLL" Alias "BTICard_RAMWipe" (ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWipeEx Lib "BTICARD64.DLL" Alias "BTICard_RAMWipeEx" (ByVal value As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrB Lib "BTICARD64.DLL" Alias "BTICard_RAMWrB" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrL Lib "BTICARD64.DLL" Alias "BTICard_RAMWrL" (ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrmL Lib "BTICARD64.DLL" Alias "BTICard_RAMWrmL" (ByRef valueptr As UInt32, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrmW Lib "BTICARD64.DLL" Alias "BTICard_RAMWrmW" (ByRef valueptr As UInt16, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrsL Lib "BTICARD64.DLL" Alias "BTICard_RAMWrsL" (ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrsW Lib "BTICARD64.DLL" Alias "BTICard_RAMWrsW" (ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_RAMWrW Lib "BTICARD64.DLL" Alias "BTICard_RAMWrW" (ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ReverseLong Lib "BTICARD64.DLL" Alias "BTICard_ReverseLong" (ByVal value As UInt32) As UInt32
        Public Declare Function BTICard_ReverseWord Lib "BTICARD64.DLL" Alias "BTICard_ReverseWord" (ByVal value As UInt16) As UInt16
        Public Declare Function BTICard_SeqBlkRd Lib "BTICARD64.DLL" Alias "BTICard_SeqBlkRd" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SeqBlkRdEx Lib "BTICARD64.DLL" Alias "BTICard_SeqBlkRdEx" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal maxblkcnt As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SeqClear Lib "BTICARD64.DLL" Alias "BTICard_SeqClear" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqCommRd Lib "BTICARD64.DLL" Alias "BTICard_SeqCommRd" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SeqConfig Lib "BTICARD64.DLL" Alias "BTICard_SeqConfig" (ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqConfigEx Lib "BTICARD64.DLL" Alias "BTICard_SeqConfigEx" (ByVal configval As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqConfigExx Lib "BTICARD64.DLL" Alias "BTICard_SeqConfigExx" (ByVal configval As UInt32, ByVal seqaddr As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqDMARd Lib "BTICARD64.DLL" Alias "BTICard_SeqDMARd" (ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SeqFindCheckVersion Lib "BTICARD64.DLL" Alias "BTICard_SeqFindCheckVersion" (ByRef precord As UInt16, ByVal version As UInt16) As Int32
        Public Declare Function BTICard_SeqFindInit Lib "BTICARD64.DLL" Alias "BTICard_SeqFindInit" (ByRef seqbuf As UInt16, ByVal seqbufsize As UInt32, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindMore1553Ex Lib "BTICARD64.DLL" Alias "BTICard_SeqFindMore1553Ex" (ByRef precmore As SEQRECORDMORE1553, ByVal recordsize As UInt16, ByRef precbase As SEQRECORD1553) As Int32
        Public Declare Function BTICard_SeqFindNext1553Ex Lib "BTICARD64.DLL" Alias "BTICard_SeqFindNext1553Ex" (ByRef precord As SEQRECORD1553, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNext429Ex Lib "BTICARD64.DLL" Alias "BTICard_SeqFindNext429Ex" (ByRef precord As SEQRECORD429, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNext708Ex Lib "BTICARD64.DLL" Alias "BTICard_SeqFindNext708Ex" (ByRef precord As SEQRECORD708, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNext717Ex Lib "BTICARD64.DLL" Alias "BTICard_SeqFindNext717Ex" (ByRef precord As SEQRECORD717, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNextCSDBEx Lib "BTICARD64.DLL" Alias "BTICard_SeqFindNextCSDBEx" (ByRef precord As SEQRECORDCSDB, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNextDIOEx Lib "BTICARD64.DLL" Alias "BTICard_SeqFindNextDIOEx" (ByRef precord As SEQRECORDDIO, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqFindNextEx Lib "BTICARD64.DLL" Alias "BTICard_SeqFindNextEx" (ByRef precord As UInt16, ByVal recordcount As UInt16, ByRef seqtype As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        Public Declare Function BTICard_SeqInterval Lib "BTICARD64.DLL" Alias "BTICard_SeqInterval" (ByVal interval As Int32, ByVal mode As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqIntervalEx Lib "BTICARD64.DLL" Alias "BTICard_SeqIntervalEx" (ByVal shiftval As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SeqIsRunning Lib "BTICARD64.DLL" Alias "BTICard_SeqIsRunning" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqLogFrequency Lib "BTICARD64.DLL" Alias "BTICard_SeqLogFrequency" (ByVal logfreq As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SeqRd Lib "BTICARD64.DLL" Alias "BTICard_SeqRd" (ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SeqRdEx Lib "BTICARD64.DLL" Alias "BTICard_SeqRdEx" (ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SeqResume Lib "BTICARD64.DLL" Alias "BTICard_SeqResume" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqStart Lib "BTICARD64.DLL" Alias "BTICard_SeqStart" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqStatus Lib "BTICARD64.DLL" Alias "BTICard_SeqStatus" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SeqStop Lib "BTICARD64.DLL" Alias "BTICard_SeqStop" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_Shl Lib "BTICARD64.DLL" Alias "BTICard_Shl" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
        Public Declare Function BTICard_Shr Lib "BTICARD64.DLL" Alias "BTICard_Shr" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
        Public Declare Function BTICard_SignMant Lib "BTICARD64.DLL" Alias "BTICard_SignMant" (ByRef str As String) As UInt16
        Public Declare Sub BTICard_Sub64 Lib "BTICARD64.DLL" Alias "BTICard_Sub64" (ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        Public Declare Sub BTICard_SwapEndianL Lib "BTICARD64.DLL" Alias "BTICard_SwapEndianL" (ByRef value As UInt32)
        Public Declare Sub BTICard_SwapEndianW Lib "BTICARD64.DLL" Alias "BTICard_SwapEndianW" (ByRef valuea As UInt16, ByRef valueb As UInt16)
        Public Declare Sub BTICard_SwapIfBigEndianL Lib "BTICARD64.DLL" Alias "BTICard_SwapIfBigEndianL" (ByRef value As UInt32)
        Public Declare Sub BTICard_SwapIfBigEndianW Lib "BTICARD64.DLL" Alias "BTICard_SwapIfBigEndianW" (ByRef valuea As UInt16, ByRef valueb As UInt16)
        Public Declare Sub BTICard_SwapIfLittleEndianL Lib "BTICARD64.DLL" Alias "BTICard_SwapIfLittleEndianL" (ByRef value As UInt32)
        Public Declare Sub BTICard_SwapIfLittleEndianW Lib "BTICARD64.DLL" Alias "BTICard_SwapIfLittleEndianW" (ByRef valuea As UInt16, ByRef valueb As UInt16)
        Public Declare Function BTICard_SysMonClear Lib "BTICARD64.DLL" Alias "BTICard_SysMonClear" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonInit Lib "BTICARD64.DLL" Alias "BTICard_SysMonInit" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonTypeGet Lib "BTICARD64.DLL" Alias "BTICard_SysMonTypeGet" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SysMonDescGet Lib "BTICARD64.DLL" Alias "BTICard_SysMonDescGet" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SysMonMaxRd Lib "BTICARD64.DLL" Alias "BTICard_SysMonMaxRd" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonMinRd Lib "BTICARD64.DLL" Alias "BTICard_SysMonMinRd" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonNomRd Lib "BTICARD64.DLL" Alias "BTICard_SysMonNomRd" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonUserStr Lib "BTICARD64.DLL" Alias "BTICard_SysMonUserStr" (ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SysMonValRd Lib "BTICARD64.DLL" Alias "BTICard_SysMonValRd" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonValStr Lib "BTICARD64.DLL" Alias "BTICard_SysMonValStr" (ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_SysMonThresholdSet Lib "BTICARD64.DLL" Alias "BTICard_SysMonThresholdSet" (ByVal enable As Int32, ByVal minval As Int32, ByVal maxval As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_SysMonValToDAC Lib "BTICARD64.DLL" Alias "BTICard_SysMonValToDAC" (ByVal val As Int32, ByVal rangemin As Int32, ByVal rangemax As Int32, ByVal dacval_max As UInt16, ByVal scalefactor As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_SysMonDACToVal Lib "BTICARD64.DLL" Alias "BTICard_SysMonDACToVal" (ByVal dacval As UInt16, ByVal rangemin As Int32, ByVal rangemax As Int32, ByVal dacval_max As UInt16, ByVal scalefactor As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_TickTimerStart Lib "BTICARD64.DLL" Alias "BTICard_TickTimerStart" (ByVal milliseconds As Int32) As Int32
        Public Declare Function BTICard_TickTimerValid Lib "BTICARD64.DLL" Alias "BTICard_TickTimerValid" (ByVal timer As Int32) As Int32
        Public Declare Function BTICard_Timer64Rd Lib "BTICARD64.DLL" Alias "BTICard_Timer64Rd" (ByRef valueh As UInt32, ByRef valuel As UInt32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_Timer64Wr Lib "BTICARD64.DLL" Alias "BTICard_Timer64Wr" (ByVal valueh As UInt32, ByVal valuel As UInt32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_TimerClear Lib "BTICARD64.DLL" Alias "BTICard_TimerClear" (ByVal handleval As UInt32)
        Public Declare Function BTICard_TimerRd Lib "BTICARD64.DLL" Alias "BTICard_TimerRd" (ByVal handleval As UInt32) As UInt32
        Public Declare Function BTICard_TimerResolution Lib "BTICARD64.DLL" Alias "BTICard_TimerResolution" (ByVal timerresol As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTICard_TimerResolutionEx Lib "BTICARD64.DLL" Alias "BTICard_TimerResolutionEx" (ByVal timershift As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTICard_TimerStatus Lib "BTICARD64.DLL" Alias "BTICard_TimerStatus" (ByVal handleval As UInt32) As Int32
        Public Declare Sub BTICard_TimerWr Lib "BTICARD64.DLL" Alias "BTICard_TimerWr" (ByVal value As UInt32, ByVal handleval As UInt32)
        Public Declare Function BTICard_ValAsciiCmpi Lib "BTICARD64.DLL" Alias "BTICard_ValAsciiCmpi" (ByRef str1 As String, ByRef str2 As String) As Int32
        Public Declare Function BTICard_ValAsciiCpy Lib "BTICARD64.DLL" Alias "BTICard_ValAsciiCpy" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Int32) As UInt32
        Public Declare Sub BTICard_ValAsciiTrimLead Lib "BTICARD64.DLL" Alias "BTICard_ValAsciiTrimLead" (ByRef buf As String)
        Public Declare Sub BTICard_ValAsciiTrimTrail Lib "BTICARD64.DLL" Alias "BTICard_ValAsciiTrimTrail" (ByRef buf As String)
        Public Declare Function BTICard_ValFromAscii Lib "BTICARD64.DLL" Alias "BTICard_ValFromAscii" (ByRef asciistr As String, ByVal radixval As Int32) As UInt32
        Public Declare Function BTICard_ValGetBits Lib "BTICARD64.DLL" Alias "BTICard_ValGetBits" (ByVal oldvalue As UInt32, ByVal startbit As Int32, ByVal endbit As Int32) As UInt32
        Public Declare Function BTICard_ValIncAscii Lib "BTICARD64.DLL" Alias "BTICard_ValIncAscii" (ByRef asciistr As String) As UInt32
        Public Declare Function BTICard_ValInccAscii Lib "BTICARD64.DLL" Alias "BTICard_ValInccAscii" (ByRef asciistr As String) As UInt32
        Public Declare Function BTICard_ValIsLower Lib "BTICARD64.DLL" Alias "BTICard_ValIsLower" (ByVal value As Int32) As Int32
        Public Declare Function BTICard_ValLenAscii Lib "BTICARD64.DLL" Alias "BTICard_ValLenAscii" (ByVal numbits As Int32, ByVal radixval As Int32) As Int32
        Public Declare Function BTICard_ValPutBits Lib "BTICARD64.DLL" Alias "BTICard_ValPutBits" (ByVal oldvalue As UInt32, ByVal newfld As UInt32, ByVal startbit As Int32, ByVal endbit As Int32) As UInt32
        Public Declare Function BTICard_ValToAscii Lib "BTICARD64.DLL" Alias "BTICard_ValToAscii" (ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
        Public Declare Function BTICard_ValToUpper Lib "BTICARD64.DLL" Alias "BTICard_ValToUpper" (ByVal value As Int32) As Int32
        Public Declare Function BTICard_VARRdL Lib "BTICARD64.DLL" Alias "BTICard_VARRdL" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
        Public Declare Sub BTICard_VARRdsW Lib "BTICARD64.DLL" Alias "BTICard_VARRdsW" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Function BTICard_VARRdW Lib "BTICARD64.DLL" Alias "BTICard_VARRdW" (ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        Public Declare Sub BTICard_VARWrL Lib "BTICARD64.DLL" Alias "BTICard_VARWrL" (ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
        Public Declare Sub BTICard_VARWrsW Lib "BTICARD64.DLL" Alias "BTICard_VARWrsW" (ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        Public Declare Sub BTICard_VARWrW Lib "BTICARD64.DLL" Alias "BTICard_VARWrW" (ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
    End Class

    Public Sub BTICard_Add64(ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_Add64(resulth, resultl, valah, valal, valbh, valbl)
        Else
            BTICARD_64.BTICard_Add64(resulth, resultl, valah, valal, valbh, valbl)
        End If
    End Sub
    Public Function BTICard_AddrDSP(ByVal addr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_AddrDSP(addr, handleval)
        Else
            Return BTICARD_64.BTICard_AddrDSP(addr, handleval)
        End If
    End Function
    Public Function BTICard_AddrHost(ByVal addr As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_AddrHost(addr, handleval)
        Else
            Return BTICARD_64.BTICard_AddrHost(addr, handleval)
        End If
    End Function
    Public Function BTICard_AsciiToMant(ByRef str As String, ByRef mant As UInt32, ByRef exp As Int32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_AsciiToMant(str, mant, exp)
        Else
            Return BTICARD_64.BTICard_AsciiToMant(str, mant, exp)
        End If
    End Function
    Public Function BTICard_BCDToBin(ByVal bcdval As UInt32, ByVal msb As Int32, ByVal lsb As Int32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_BCDToBin(bcdval, msb, lsb)
        Else
            Return BTICARD_64.BTICard_BCDToBin(bcdval, msb, lsb)
        End If
    End Function
    Public Function BTICard_BinToBCD(ByVal oldbcdval As UInt32, ByVal binval As UInt32, ByVal msb As Int32, ByVal lsb As Int32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_BinToBCD(oldbcdval, binval, msb, lsb)
        Else
            Return BTICARD_64.BTICard_BinToBCD(oldbcdval, binval, msb, lsb)
        End If
    End Function
    Public Function BTICard_BITConfig(ByVal ctrlflags As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_BITConfig(ctrlflags, handleval)
        Else
            Return BTICARD_64.BTICard_BITConfig(ctrlflags, handleval)
        End If
    End Function
    Public Function BTICard_BITInitiate(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_BITInitiate(handleval)
        Else
            Return BTICARD_64.BTICard_BITInitiate(handleval)
        End If
    End Function
    Public Function BTICard_BITStatusClear(ByVal statval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_BITStatusClear(statval, handleval)
        Else
            Return BTICARD_64.BTICard_BITStatusClear(statval, handleval)
        End If
    End Function
    Public Function BTICard_BITStatusRd(ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_BITStatusRd(handleval)
        Else
            Return BTICARD_64.BTICard_BITStatusRd(handleval)
        End If
    End Function
    Public Function BTICard_CardClose(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardClose(handleval)
        Else
            Return BTICARD_64.BTICard_CardClose(handleval)
        End If
    End Function
    Public Function BTICard_CardCloseAll() As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardCloseAll
        Else
            Return BTICARD_64.BTICard_CardCloseAll
        End If
    End Function
    Public Function BTICard_CardGetInfo(ByVal infotype As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardGetInfo(infotype, channum, handleval)
        Else
            Return BTICARD_64.BTICard_CardGetInfo(infotype, channum, handleval)
        End If
    End Function
    Public Function BTICard_CardGetInfoEx(ByRef bufmodel As UInt16, ByVal bufmodelcount As UInt16, ByRef buffeature As UInt16, ByVal buffeaturecount As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardGetInfoEx(bufmodel, bufmodelcount, buffeature, buffeaturecount, handleval)
        Else
            Return BTICARD_64.BTICard_CardGetInfoEx(bufmodel, bufmodelcount, buffeature, buffeaturecount, handleval)
        End If
    End Function
    Public Function BTICard_CardIsRunning(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardIsRunning(handleval)
        Else
            Return BTICARD_64.BTICard_CardIsRunning(handleval)
        End If
    End Function
    Public Function BTICard_CardNop(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardNop(handleval)
        Else
            Return BTICARD_64.BTICard_CardNop(handleval)
        End If
    End Function
    Public Function BTICard_CardOpen(ByRef lphandle As UInt32, ByVal cardnum As Int32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardOpen(lphandle, cardnum)
        Else
            Return BTICARD_64.BTICard_CardOpen(lphandle, cardnum)
        End If
    End Function
    Public Function BTICard_CardOpenStr(ByRef lphandle As UInt32, ByRef cardstr As String) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardOpenStr(lphandle, cardstr)
        Else
            Return BTICARD_64.BTICard_CardOpenStr(lphandle, cardstr)
        End If
    End Function
    Public Function BTICard_CardProductStr(ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardProductStr(handleval)
        Else
            Return BTICARD_64.BTICard_CardProductStr(handleval)
        End If
    End Function
    Public Sub BTICard_CardReset(ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_CardReset(handleval)
        Else
            BTICARD_64.BTICard_CardReset(handleval)
        End If
    End Sub
    Public Sub BTICard_CardResetEx(ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_CardResetEx(handleval)
        Else
            BTICARD_64.BTICard_CardResetEx(handleval)
        End If
    End Sub
    Public Function BTICard_CardResume(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardResume(handleval)
        Else
            Return BTICARD_64.BTICard_CardResume(handleval)
        End If
    End Function
    Public Function BTICard_CardShadow(ByVal shadowval As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardShadow(shadowval, handleval)
        Else
            Return BTICARD_64.BTICard_CardShadow(shadowval, handleval)
        End If
    End Function
    Public Function BTICard_CardStart(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardStart(handleval)
        Else
            Return BTICARD_64.BTICard_CardStart(handleval)
        End If
    End Function
    Public Function BTICard_CardStop(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardStop(handleval)
        Else
            Return BTICARD_64.BTICard_CardStop(handleval)
        End If
    End Function
    Public Sub BTICard_CardSyncEnable(ByVal enableflag As Int32, ByVal syncmask As UInt16, ByVal pinpolarity As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_CardSyncEnable(enableflag, syncmask, pinpolarity, handleval)
        Else
            BTICARD_64.BTICard_CardSyncEnable(enableflag, syncmask, pinpolarity, handleval)
        End If
    End Sub
    Public Function BTICard_CardSyncValid(ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardSyncValid(handleval)
        Else
            Return BTICARD_64.BTICard_CardSyncValid(handleval)
        End If
    End Function
    Public Function BTICard_CardTest(ByVal level As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardTest(level, handleval)
        Else
            Return BTICARD_64.BTICard_CardTest(level, handleval)
        End If
    End Function
    Public Function BTICard_CardTest0(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardTest0(handleval)
        Else
            Return BTICARD_64.BTICard_CardTest0(handleval)
        End If
    End Function
    Public Function BTICard_CardTest1(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardTest1(handleval)
        Else
            Return BTICARD_64.BTICard_CardTest1(handleval)
        End If
    End Function
    Public Function BTICard_CardTest2(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardTest2(handleval)
        Else
            Return BTICARD_64.BTICard_CardTest2(handleval)
        End If
    End Function
    Public Function BTICard_CardTest3(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardTest3(handleval)
        Else
            Return BTICARD_64.BTICard_CardTest3(handleval)
        End If
    End Function
    Public Sub BTICard_CardTrigger(ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_CardTrigger(handleval)
        Else
            BTICARD_64.BTICard_CardTrigger(handleval)
        End If
    End Sub
    Public Sub BTICard_CardTriggerEnable(ByVal enableflag As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_CardTriggerEnable(enableflag, handleval)
        Else
            BTICARD_64.BTICard_CardTriggerEnable(enableflag, handleval)
        End If
    End Sub
    Public Sub BTICard_CardTriggerEnableEx(ByVal enableflag As Int32, ByVal trigmask As UInt16, ByVal pinpolarity As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_CardTriggerEnableEx(enableflag, trigmask, pinpolarity, handleval)
        Else
            BTICARD_64.BTICard_CardTriggerEnableEx(enableflag, trigmask, pinpolarity, handleval)
        End If
    End Sub
    Public Sub BTICard_CardTriggerEx(ByVal trigmask As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_CardTriggerEx(trigmask, handleval)
        Else
            BTICARD_64.BTICard_CardTriggerEx(trigmask, handleval)
        End If
    End Sub
    Public Function BTICard_CardTriggerValid(ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardTriggerValid(handleval)
        Else
            Return BTICARD_64.BTICard_CardTriggerValid(handleval)
        End If
    End Function
    Public Function BTICard_CardTypeStr(ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CardTypeStr(handleval)
        Else
            Return BTICARD_64.BTICard_CardTypeStr(handleval)
        End If
    End Function
    Public Sub BTICard_ChDARClr(ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ChDARClr(maskval, addrval, channum, handleval)
        Else
            BTICARD_64.BTICard_ChDARClr(maskval, addrval, channum, handleval)
        End If
    End Sub
    Public Function BTICard_ChDARGet(ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ChDARGet(maskval, addrval, channum, handleval)
        Else
            Return BTICARD_64.BTICard_ChDARGet(maskval, addrval, channum, handleval)
        End If
    End Function
    Public Function BTICard_ChDARRdL(ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ChDARRdL(addrval, channum, handleval)
        Else
            Return BTICARD_64.BTICard_ChDARRdL(addrval, channum, handleval)
        End If
    End Function
    Public Sub BTICard_ChDARRdsW(ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ChDARRdsW(valueptr, addrval, countval, channum, handleval)
        Else
            BTICARD_64.BTICard_ChDARRdsW(valueptr, addrval, countval, channum, handleval)
        End If
    End Sub
    Public Function BTICard_ChDARRdW(ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ChDARRdW(addrval, channum, handleval)
        Else
            Return BTICARD_64.BTICard_ChDARRdW(addrval, channum, handleval)
        End If
    End Function
    Public Sub BTICard_ChDARSet(ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ChDARSet(maskval, addrval, channum, handleval)
        Else
            BTICARD_64.BTICard_ChDARSet(maskval, addrval, channum, handleval)
        End If
    End Sub
    Public Sub BTICard_ChDARWrL(ByVal value As UInt32, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ChDARWrL(value, addrval, channum, handleval)
        Else
            BTICARD_64.BTICard_ChDARWrL(value, addrval, channum, handleval)
        End If
    End Sub
    Public Sub BTICard_ChDARWrsW(ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ChDARWrsW(valueptr, addrval, countval, channum, handleval)
        Else
            BTICARD_64.BTICard_ChDARWrsW(valueptr, addrval, countval, channum, handleval)
        End If
    End Sub
    Public Sub BTICard_ChDARWrW(ByVal value As UInt16, ByVal addrval As UInt16, ByVal channum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ChDARWrW(value, addrval, channum, handleval)
        Else
            BTICARD_64.BTICard_ChDARWrW(value, addrval, channum, handleval)
        End If
    End Sub
    Public Function BTICard_CISRd(ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal cistype As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CISRd(buf, bufcount, cistype, handleval)
        Else
            Return BTICARD_64.BTICard_CISRd(buf, bufcount, cistype, handleval)
        End If
    End Function
    Public Function BTICard_CISWr(ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal cistype As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CISWr(buf, bufcount, cistype, handleval)
        Else
            Return BTICARD_64.BTICard_CISWr(buf, bufcount, cistype, handleval)
        End If
    End Function
    Public Function BTICard_CommBufRd(ByVal offset As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommBufRd(offset, handleval)
        Else
            Return BTICARD_64.BTICard_CommBufRd(offset, handleval)
        End If
    End Function
    Public Sub BTICard_CommBufWr(ByVal value As UInt16, ByVal offset As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_CommBufWr(value, offset, handleval)
        Else
            BTICARD_64.BTICard_CommBufWr(value, offset, handleval)
        End If
    End Sub
    Public Function BTICard_CommCall(ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommCall(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_CommCall(addrval, handleval)
        End If
    End Function
    Public Function BTICard_CommChannelReconfig(ByVal chmask As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommChannelReconfig(chmask, handleval)
        Else
            Return BTICARD_64.BTICard_CommChannelReconfig(chmask, handleval)
        End If
    End Function
    Public Function BTICard_CommCheck(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommCheck(handleval)
        Else
            Return BTICARD_64.BTICard_CommCheck(handleval)
        End If
    End Function
    Public Function BTICard_CommDisable(ByVal command As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommDisable(command, handleval)
        Else
            Return BTICARD_64.BTICard_CommDisable(command, handleval)
        End If
    End Function
    Public Function BTICard_CommDisableEx(ByVal command As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommDisableEx(command, handleval)
        Else
            Return BTICARD_64.BTICard_CommDisableEx(command, handleval)
        End If
    End Function
    Public Function BTICard_CommEnable(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommEnable(handleval)
        Else
            Return BTICARD_64.BTICard_CommEnable(handleval)
        End If
    End Function
    Public Function BTICard_CommExternSRQ(ByVal chmask As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommExternSRQ(chmask, handleval)
        Else
            Return BTICARD_64.BTICard_CommExternSRQ(chmask, handleval)
        End If
    End Function
    Public Function BTICard_CommFillW(ByVal value As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommFillW(value, addrval, count, handleval)
        Else
            Return BTICARD_64.BTICard_CommFillW(value, addrval, count, handleval)
        End If
    End Function
    Public Function BTICard_CommProtocolFunc(ByVal opcode As UInt16, ByVal argcount As UInt16, ByRef argbuf As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommProtocolFunc(opcode, argcount, argbuf, handleval)
        Else
            Return BTICARD_64.BTICard_CommProtocolFunc(opcode, argcount, argbuf, handleval)
        End If
    End Function
    Public Function BTICard_CommRdL(ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommRdL(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_CommRdL(addrval, handleval)
        End If
    End Function
    Public Function BTICard_CommRdsW(ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommRdsW(valueptr, addrval, count, handleval)
        Else
            Return BTICARD_64.BTICard_CommRdsW(valueptr, addrval, count, handleval)
        End If
    End Function
    Public Function BTICard_CommRdW(ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommRdW(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_CommRdW(addrval, handleval)
        End If
    End Function
    Public Function BTICard_CommRun(ByRef dataptr As UInt16, ByVal datacount As UInt16, ByRef codeptr As UInt16, ByVal codecount As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommRun(dataptr, datacount, codeptr, codecount, handleval)
        Else
            Return BTICARD_64.BTICard_CommRun(dataptr, datacount, codeptr, codecount, handleval)
        End If
    End Function
    Public Sub BTICard_CommWrL(ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_CommWrL(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_CommWrL(value, addrval, handleval)
        End If
    End Sub
    Public Function BTICard_CommWrsW(ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CommWrsW(valueptr, addrval, count, handleval)
        Else
            Return BTICARD_64.BTICard_CommWrsW(valueptr, addrval, count, handleval)
        End If
    End Function
    Public Sub BTICard_CommWrW(ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_CommWrW(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_CommWrW(value, addrval, handleval)
        End If
    End Sub
    Public Function BTICard_CoProcCheck(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoProcCheck(handleval)
        Else
            Return BTICARD_64.BTICard_CoProcCheck(handleval)
        End If
    End Function
    Public Function BTICard_CoProcGetInfo(ByRef valueptr As UInt32, ByVal infotype As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoProcGetInfo(valueptr, infotype, handleval)
        Else
            Return BTICARD_64.BTICard_CoProcGetInfo(valueptr, infotype, handleval)
        End If
    End Function
    Public Function BTICard_CoProcMemRdL(ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoProcMemRdL(valueptr, addrval, handleval)
        Else
            Return BTICARD_64.BTICard_CoProcMemRdL(valueptr, addrval, handleval)
        End If
    End Function
    Public Function BTICard_CoProcMemRdsL(ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoProcMemRdsL(valueptr, addrval, count, handleval)
        Else
            Return BTICARD_64.BTICard_CoProcMemRdsL(valueptr, addrval, count, handleval)
        End If
    End Function
    Public Function BTICard_CoProcMemRdsW(ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoProcMemRdsW(valueptr, addrval, count, handleval)
        Else
            Return BTICARD_64.BTICard_CoProcMemRdsW(valueptr, addrval, count, handleval)
        End If
    End Function
    Public Function BTICard_CoProcMemRdW(ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoProcMemRdW(valueptr, addrval, handleval)
        Else
            Return BTICARD_64.BTICard_CoProcMemRdW(valueptr, addrval, handleval)
        End If
    End Function
    Public Function BTICard_CoProcMemWrL(ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoProcMemWrL(value, addrval, handleval)
        Else
            Return BTICARD_64.BTICard_CoProcMemWrL(value, addrval, handleval)
        End If
    End Function
    Public Function BTICard_CoProcMemWrsL(ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoProcMemWrsL(valueptr, addrval, count, handleval)
        Else
            Return BTICARD_64.BTICard_CoProcMemWrsL(valueptr, addrval, count, handleval)
        End If
    End Function
    Public Function BTICard_CoProcMemWrsW(ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal count As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoProcMemWrsW(valueptr, addrval, count, handleval)
        Else
            Return BTICARD_64.BTICard_CoProcMemWrsW(valueptr, addrval, count, handleval)
        End If
    End Function
    Public Function BTICard_CoProcMemWrW(ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoProcMemWrW(value, addrval, handleval)
        Else
            Return BTICARD_64.BTICard_CoProcMemWrW(value, addrval, handleval)
        End If
    End Function
    Public Function BTICard_CoreOpen(ByRef lphcore As UInt32, ByVal corenum As Int32, ByVal hcard As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_CoreOpen(lphcore, corenum, hcard)
        Else
            Return BTICARD_64.BTICard_CoreOpen(lphcore, corenum, hcard)
        End If
    End Function
    Public Sub BTICard_DARClr(ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_DARClr(maskval, addrval, handleval)
        Else
            BTICARD_64.BTICard_DARClr(maskval, addrval, handleval)
        End If
    End Sub
    Public Function BTICard_DARGet(ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DARGet(maskval, addrval, handleval)
        Else
            Return BTICARD_64.BTICard_DARGet(maskval, addrval, handleval)
        End If
    End Function
    Public Function BTICard_DARRdL(ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DARRdL(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_DARRdL(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_DARRdsW(ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_DARRdsW(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_DARRdsW(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Function BTICard_DARRdW(ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DARRdW(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_DARRdW(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_DARSet(ByVal maskval As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_DARSet(maskval, addrval, handleval)
        Else
            BTICARD_64.BTICard_DARSet(maskval, addrval, handleval)
        End If
    End Sub
    Public Sub BTICard_DARWrL(ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_DARWrL(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_DARWrL(value, addrval, handleval)
        End If
    End Sub
    Public Sub BTICard_DARWrsW(ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_DARWrsW(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_DARWrsW(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_DARWrW(ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_DARWrW(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_DARWrW(value, addrval, handleval)
        End If
    End Sub
    Public Function BTICard_Div(ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_Div(diva, divb)
        Else
            Return BTICARD_64.BTICard_Div(diva, divb)
        End If
    End Function
    Public Sub BTICard_Div64(ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_Div64(resulth, resultl, valah, valal, valbh, valbl)
        Else
            BTICARD_64.BTICard_Div64(resulth, resultl, valah, valal, valbh, valbl)
        End If
    End Sub
    Public Function BTICard_DllUsageCount() As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DllUsageCount
        Else
            Return BTICARD_64.BTICard_DllUsageCount
        End If
    End Function
    Public Function BTICard_DspBioClear(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DspBioClear(handleval)
        Else
            Return BTICARD_64.BTICard_DspBioClear(handleval)
        End If
    End Function
    Public Function BTICard_DspBioRd(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DspBioRd(handleval)
        Else
            Return BTICARD_64.BTICard_DspBioRd(handleval)
        End If
    End Function
    Public Function BTICard_DspBioSet(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DspBioSet(handleval)
        Else
            Return BTICARD_64.BTICard_DspBioSet(handleval)
        End If
    End Function
    Public Function BTICard_DspIntfClear(ByVal intmask As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DspIntfClear(intmask, handleval)
        Else
            Return BTICARD_64.BTICard_DspIntfClear(intmask, handleval)
        End If
    End Function
    Public Function BTICard_DspIntfRd(ByVal intmask As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DspIntfRd(intmask, handleval)
        Else
            Return BTICARD_64.BTICard_DspIntfRd(intmask, handleval)
        End If
    End Function
    Public Function BTICard_DspIntmClear(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DspIntmClear(handleval)
        Else
            Return BTICARD_64.BTICard_DspIntmClear(handleval)
        End If
    End Function
    Public Function BTICard_DspIntmSet(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DspIntmSet(handleval)
        Else
            Return BTICARD_64.BTICard_DspIntmSet(handleval)
        End If
    End Function
    Public Function BTICard_DspXfClear(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DspXfClear(handleval)
        Else
            Return BTICARD_64.BTICard_DspXfClear(handleval)
        End If
    End Function
    Public Function BTICard_DspXfRd(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DspXfRd(handleval)
        Else
            Return BTICARD_64.BTICard_DspXfRd(handleval)
        End If
    End Function
    Public Function BTICard_DspXfSet(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_DspXfSet(handleval)
        Else
            Return BTICARD_64.BTICard_DspXfSet(handleval)
        End If
    End Function
    Public Function BTICard_ErrDesc(ByVal errval As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ErrDesc(errval, handleval)
        Else
            Return BTICARD_64.BTICard_ErrDesc(errval, handleval)
        End If
    End Function
    Public Function BTICard_ErrDescStr(ByVal errval As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ErrDescStr(errval, handleval)
        Else
            Return BTICARD_64.BTICard_ErrDescStr(errval, handleval)
        End If
    End Function
    Public Function BTICard_ErrName(ByVal errval As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ErrName(errval, handleval)
        Else
            Return BTICARD_64.BTICard_ErrName(errval, handleval)
        End If
    End Function
    Public Function BTICard_EventLogClear(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_EventLogClear(handleval)
        Else
            Return BTICARD_64.BTICard_EventLogClear(handleval)
        End If
    End Function
    Public Function BTICard_EventLogConfig(ByVal configval As UInt16, ByVal count As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_EventLogConfig(configval, count, handleval)
        Else
            Return BTICARD_64.BTICard_EventLogConfig(configval, count, handleval)
        End If
    End Function
    Public Function BTICard_EventLogRd(ByRef typevalval As UInt16, ByRef infoval As UInt32, ByRef channel As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_EventLogRd(typevalval, infoval, channel, handleval)
        Else
            Return BTICARD_64.BTICard_EventLogRd(typevalval, infoval, channel, handleval)
        End If
    End Function
    Public Function BTICard_EventLogStatus(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_EventLogStatus(handleval)
        Else
            Return BTICARD_64.BTICard_EventLogStatus(handleval)
        End If
    End Function
    Public Sub BTICard_ExpandMant(ByRef mant As UInt32, ByRef exp As Int32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ExpandMant(mant, exp)
        Else
            BTICARD_64.BTICard_ExpandMant(mant, exp)
        End If
    End Sub
    Public Function BTICard_ExtDinRd(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ExtDinRd(handleval)
        Else
            Return BTICARD_64.BTICard_ExtDinRd(handleval)
        End If
    End Function
    Public Sub BTICard_ExtDinWr(ByVal dinval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ExtDinWr(dinval, handleval)
        Else
            BTICARD_64.BTICard_ExtDinWr(dinval, handleval)
        End If
    End Sub
    Public Sub BTICard_ExtDIODirSet(ByVal dionum As Int32, ByVal dirval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ExtDIODirSet(dionum, dirval, handleval)
        Else
            BTICARD_64.BTICard_ExtDIODirSet(dionum, dirval, handleval)
        End If
    End Sub
    Public Function BTICard_ExtDIOMonConfig(ByVal rise_edge As UInt16, ByVal fall_edge As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ExtDIOMonConfig(rise_edge, fall_edge, banknum, handleval)
        Else
            Return BTICARD_64.BTICard_ExtDIOMonConfig(rise_edge, fall_edge, banknum, handleval)
        End If
    End Function
    Public Function BTICard_ExtDIORd(ByVal dionum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ExtDIORd(dionum, handleval)
        Else
            Return BTICARD_64.BTICard_ExtDIORd(dionum, handleval)
        End If
    End Function
    Public Sub BTICard_ExtDIOWr(ByVal dionum As Int32, ByVal dioval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ExtDIOWr(dionum, dioval, handleval)
        Else
            BTICARD_64.BTICard_ExtDIOWr(dionum, dioval, handleval)
        End If
    End Sub
    Public Function BTICard_ExtLEDRd(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ExtLEDRd(handleval)
        Else
            Return BTICARD_64.BTICard_ExtLEDRd(handleval)
        End If
    End Function
    Public Sub BTICard_ExtLEDWr(ByVal ledval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ExtLEDWr(ledval, handleval)
        Else
            BTICARD_64.BTICard_ExtLEDWr(ledval, handleval)
        End If
    End Sub
    Public Sub BTICard_ExtStatusLEDRd(ByRef ledon As Int32, ByRef ledcolor As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ExtStatusLEDRd(ledon, ledcolor, handleval)
        Else
            BTICARD_64.BTICard_ExtStatusLEDRd(ledon, ledcolor, handleval)
        End If
    End Sub
    Public Sub BTICard_ExtStatusLEDWr(ByVal ledon As Int32, ByVal ledcolor As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ExtStatusLEDWr(ledon, ledcolor, handleval)
        Else
            BTICARD_64.BTICard_ExtStatusLEDWr(ledon, ledcolor, handleval)
        End If
    End Sub
    Public Sub BTICard_FileClose(ByVal handle As IntPtr)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_FileClose(handle)
        Else
            BTICARD_64.BTICard_FileClose(handle)
        End If
    End Sub
    Public Function BTICard_FileErr() As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_FileErr
        Else
            Return BTICARD_64.BTICard_FileErr
        End If
    End Function
    Public Sub BTICard_FileErrClr()
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_FileErrClr()
        Else
            BTICARD_64.BTICard_FileErrClr()
        End If
    End Sub
    Public Sub BTICard_FileErrSet()
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_FileErrSet()
        Else
            BTICARD_64.BTICard_FileErrSet()
        End If
    End Sub
    Public Function BTICard_FileOpenRead(ByRef filename As String) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_FileOpenRead(filename)
        Else
            Return BTICARD_64.BTICard_FileOpenRead(filename)
        End If
    End Function
    Public Function BTICard_FileOpenWrite(ByRef filename As String) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_FileOpenWrite(filename)
        Else
            Return BTICARD_64.BTICard_FileOpenWrite(filename)
        End If
    End Function
    Public Function BTICard_FileRead(ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_FileRead(handle, buffer, count)
        Else
            Return BTICARD_64.BTICard_FileRead(handle, buffer, count)
        End If
    End Function
    Public Function BTICard_FileSeek(ByVal handle As IntPtr, ByVal offset As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_FileSeek(handle, offset)
        Else
            Return BTICARD_64.BTICard_FileSeek(handle, offset)
        End If
    End Function
    Public Function BTICard_FileTell(ByVal handle As IntPtr) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_FileTell(handle)
        Else
            Return BTICARD_64.BTICard_FileTell(handle)
        End If
    End Function
    Public Function BTICard_FileWrite(ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal count As UInt16) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_FileWrite(handle, buffer, count)
        Else
            Return BTICARD_64.BTICard_FileWrite(handle, buffer, count)
        End If
    End Function
    Public Function BTICard_GetHigh(ByVal val As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_GetHigh(val)
        Else
            Return BTICARD_64.BTICard_GetHigh(val)
        End If
    End Function
    Public Function BTICard_GetLow(ByVal val As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_GetLow(val)
        Else
            Return BTICARD_64.BTICard_GetLow(val)
        End If
    End Function
    Public Function BTICard_GlobalRdW(ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_GlobalRdW(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_GlobalRdW(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_GlobalWrW(ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_GlobalWrW(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_GlobalWrW(value, addrval, handleval)
        End If
    End Sub
    Public Function BTICard_HandleInfoEx(ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HandleInfoEx(valueptr, typeval, handleval)
        Else
            Return BTICARD_64.BTICard_HandleInfoEx(valueptr, typeval, handleval)
        End If
    End Function
    Public Function BTICard_HandleIsCard(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HandleIsCard(handleval)
        Else
            Return BTICARD_64.BTICard_HandleIsCard(handleval)
        End If
    End Function
    Public Function BTICard_HandleIsCore(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HandleIsCore(handleval)
        Else
            Return BTICARD_64.BTICard_HandleIsCore(handleval)
        End If
    End Function
    Public Function BTICard_HandleMakeCard(ByRef lphcard As UInt32, ByRef lpcorenum As Int32, ByVal hcore As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HandleMakeCard(lphcard, lpcorenum, hcore)
        Else
            Return BTICARD_64.BTICard_HandleMakeCard(lphcard, lpcorenum, hcore)
        End If
    End Function
    Public Function BTICard_HandleMakeCore(ByRef lphcore As UInt32, ByVal corenum As Int32, ByVal hcard As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HandleMakeCore(lphcore, corenum, hcard)
        Else
            Return BTICARD_64.BTICard_HandleMakeCore(lphcore, corenum, hcard)
        End If
    End Function
    Public Function BTICard_HandleMakeRPC(ByRef hcard_remote As UInt32, ByRef lphrpc As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HandleMakeRPC(hcard_remote, lphrpc, handleval)
        Else
            Return BTICARD_64.BTICard_HandleMakeRPC(hcard_remote, lphrpc, handleval)
        End If
    End Function
    Public Function BTICard_HandleOkay(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HandleOkay(handleval)
        Else
            Return BTICARD_64.BTICard_HandleOkay(handleval)
        End If
    End Function
    Public Function BTICard_HeapAlloc(ByVal section As Int32, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HeapAlloc(section, wordcount, handleval)
        Else
            Return BTICARD_64.BTICard_HeapAlloc(section, wordcount, handleval)
        End If
    End Function
    Public Function BTICard_HeapAllocAll(ByVal section As Int32, ByRef wordcount As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HeapAllocAll(section, wordcount, handleval)
        Else
            Return BTICARD_64.BTICard_HeapAllocAll(section, wordcount, handleval)
        End If
    End Function
    Public Function BTICard_HeapAllocEx(ByVal configval As UInt16, ByVal section As Int32, ByVal wordcount As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HeapAllocEx(configval, section, wordcount, handleval)
        Else
            Return BTICARD_64.BTICard_HeapAllocEx(configval, section, wordcount, handleval)
        End If
    End Function
    Public Function BTICard_HeapWipe(ByVal section As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HeapWipe(section, handleval)
        Else
            Return BTICARD_64.BTICard_HeapWipe(section, handleval)
        End If
    End Function
    Public Sub BTICard_HPIFill(ByVal value As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_HPIFill(value, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_HPIFill(value, addrval, countval, handleval)
        End If
    End Sub
    Public Function BTICard_HPIRdL(ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HPIRdL(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_HPIRdL(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_HPIRdsL(ByRef valueptr As UInt32, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_HPIRdsL(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_HPIRdsL(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_HPIRdsW(ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_HPIRdsW(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_HPIRdsW(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Function BTICard_HPIRdW(ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_HPIRdW(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_HPIRdW(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_HPIWrL(ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_HPIWrL(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_HPIWrL(value, addrval, handleval)
        End If
    End Sub
    Public Sub BTICard_HPIWrsL(ByRef valueptr As UInt32, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_HPIWrsL(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_HPIWrsL(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_HPIWrsW(ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_HPIWrsW(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_HPIWrsW(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_HPIWrW(ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_HPIWrW(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_HPIWrW(value, addrval, handleval)
        End If
    End Sub
    Public Function BTICard_IDRegRd(ByVal gate_array_num As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IDRegRd(gate_array_num, handleval)
        Else
            Return BTICARD_64.BTICard_IDRegRd(gate_array_num, handleval)
        End If
    End Function
    Public Sub BTICard_IDRegWr(ByVal value As UInt16, ByVal gate_array_num As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IDRegWr(value, gate_array_num, handleval)
        Else
            BTICARD_64.BTICard_IDRegWr(value, gate_array_num, handleval)
        End If
    End Sub
    Public Sub BTICard_IntClear(ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IntClear(handleval)
        Else
            BTICARD_64.BTICard_IntClear(handleval)
        End If
    End Sub
    Public Function BTICard_IntDisable(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IntDisable(handleval)
        Else
            Return BTICARD_64.BTICard_IntDisable(handleval)
        End If
    End Function
    Public Function BTICard_IntEnable(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IntEnable(handleval)
        Else
            Return BTICARD_64.BTICard_IntEnable(handleval)
        End If
    End Function
    Public Function BTICard_IntEnableCond(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IntEnableCond(handleval)
        Else
            Return BTICARD_64.BTICard_IntEnableCond(handleval)
        End If
    End Function
    Public Function BTICard_IntGet(ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IntGet(handleval)
        Else
            Return BTICARD_64.BTICard_IntGet(handleval)
        End If
    End Function
    Public Function BTICard_IntInstall(ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IntInstall(hevent, handleval)
        Else
            Return BTICARD_64.BTICard_IntInstall(hevent, handleval)
        End If
    End Function
    Public Sub BTICard_IntReset(ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IntReset(handleval)
        Else
            BTICARD_64.BTICard_IntReset(handleval)
        End If
    End Sub
    Public Function BTICard_IntUninstall(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IntUninstall(handleval)
        Else
            Return BTICARD_64.BTICard_IntUninstall(handleval)
        End If
    End Function
    Public Function BTICard_IORdL(ByVal addrval As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IORdL(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_IORdL(addrval, handleval)
        End If
    End Function
    Public Function BTICard_IORdW(ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IORdW(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_IORdW(addrval, handleval)
        End If
    End Function
    Public Function BTICard_IOWINRdW(ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IOWINRdW(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_IOWINRdW(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_IOWINWrW(ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IOWINWrW(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_IOWINWrW(value, addrval, handleval)
        End If
    End Sub
    Public Sub BTICard_IOWrL(ByVal value As UInt32, ByVal addrval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IOWrL(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_IOWrL(value, addrval, handleval)
        End If
    End Sub
    Public Sub BTICard_IOWrW(ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IOWrW(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_IOWrW(value, addrval, handleval)
        End If
    End Sub
    Public Function BTICard_IRIGConfig(ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGConfig(configval, handleval)
        Else
            Return BTICARD_64.BTICard_IRIGConfig(configval, handleval)
        End If
    End Function
    Public Function BTICard_IRIGFieldGetDays(ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGFieldGetDays(irigvalh, irigvall)
        Else
            Return BTICARD_64.BTICard_IRIGFieldGetDays(irigvalh, irigvall)
        End If
    End Function
    Public Function BTICard_IRIGFieldGetHours(ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGFieldGetHours(irigvalh, irigvall)
        Else
            Return BTICARD_64.BTICard_IRIGFieldGetHours(irigvalh, irigvall)
        End If
    End Function
    Public Function BTICard_IRIGFieldGetMicrosec(ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGFieldGetMicrosec(irigvalh, irigvall)
        Else
            Return BTICARD_64.BTICard_IRIGFieldGetMicrosec(irigvalh, irigvall)
        End If
    End Function
    Public Function BTICard_IRIGFieldGetMillisec(ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGFieldGetMillisec(irigvalh, irigvall)
        Else
            Return BTICARD_64.BTICard_IRIGFieldGetMillisec(irigvalh, irigvall)
        End If
    End Function
    Public Function BTICard_IRIGFieldGetMin(ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGFieldGetMin(irigvalh, irigvall)
        Else
            Return BTICARD_64.BTICard_IRIGFieldGetMin(irigvalh, irigvall)
        End If
    End Function
    Public Function BTICard_IRIGFieldGetSec(ByVal irigvalh As UInt32, ByVal irigvall As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGFieldGetSec(irigvalh, irigvall)
        Else
            Return BTICARD_64.BTICard_IRIGFieldGetSec(irigvalh, irigvall)
        End If
    End Function
    Public Sub BTICard_IRIGFieldPutDays(ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IRIGFieldPutDays(value, irigvalh, irigvall)
        Else
            BTICARD_64.BTICard_IRIGFieldPutDays(value, irigvalh, irigvall)
        End If
    End Sub
    Public Sub BTICard_IRIGFieldPutHours(ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IRIGFieldPutHours(value, irigvalh, irigvall)
        Else
            BTICARD_64.BTICard_IRIGFieldPutHours(value, irigvalh, irigvall)
        End If
    End Sub
    Public Sub BTICard_IRIGFieldPutMicrosec(ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IRIGFieldPutMicrosec(value, irigvalh, irigvall)
        Else
            BTICARD_64.BTICard_IRIGFieldPutMicrosec(value, irigvalh, irigvall)
        End If
    End Sub
    Public Sub BTICard_IRIGFieldPutMillisec(ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IRIGFieldPutMillisec(value, irigvalh, irigvall)
        Else
            BTICARD_64.BTICard_IRIGFieldPutMillisec(value, irigvalh, irigvall)
        End If
    End Sub
    Public Sub BTICard_IRIGFieldPutMin(ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IRIGFieldPutMin(value, irigvalh, irigvall)
        Else
            BTICARD_64.BTICard_IRIGFieldPutMin(value, irigvalh, irigvall)
        End If
    End Sub
    Public Sub BTICard_IRIGFieldPutSec(ByVal value As UInt32, ByRef irigvalh As UInt32, ByRef irigvall As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IRIGFieldPutSec(value, irigvalh, irigvall)
        Else
            BTICARD_64.BTICard_IRIGFieldPutSec(value, irigvalh, irigvall)
        End If
    End Sub
    Public Function BTICard_IRIGInputThresholdGet(ByRef dacval As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGInputThresholdGet(dacval, handleval)
        Else
            Return BTICARD_64.BTICard_IRIGInputThresholdGet(dacval, handleval)
        End If
    End Function
    Public Function BTICard_IRIGInputThresholdSet(ByVal dacval As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGInputThresholdSet(dacval, handleval)
        Else
            Return BTICARD_64.BTICard_IRIGInputThresholdSet(dacval, handleval)
        End If
    End Function
    Public Function BTICard_IRIGRd(ByRef irigtime As BTIIRIGTIME, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGRd(irigtime, handleval)
        Else
            Return BTICARD_64.BTICard_IRIGRd(irigtime, handleval)
        End If
    End Function
    Public Function BTICard_IRIGRdEx(ByRef timebuf As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGRdEx(timebuf, handleval)
        Else
            Return BTICARD_64.BTICard_IRIGRdEx(timebuf, handleval)
        End If
    End Function
    Public Function BTICard_IRIGSyncStatus(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGSyncStatus(handleval)
        Else
            Return BTICARD_64.BTICard_IRIGSyncStatus(handleval)
        End If
    End Function
    Public Sub BTICard_IRIGTimeBCDToBin(ByRef timevalh As UInt32, ByRef timevall As UInt32, ByVal irigvalh As UInt32, ByVal irigvall As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IRIGTimeBCDToBin(timevalh, timevall, irigvalh, irigvall)
        Else
            BTICARD_64.BTICard_IRIGTimeBCDToBin(timevalh, timevall, irigvalh, irigvall)
        End If
    End Sub
    Public Sub BTICard_IRIGTimeBinToBCD(ByRef irigvalh As UInt32, ByRef irigvall As UInt32, ByVal timevalh As UInt32, ByVal timevall As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_IRIGTimeBinToBCD(irigvalh, irigvall, timevalh, timevall)
        Else
            BTICARD_64.BTICard_IRIGTimeBinToBCD(irigvalh, irigvall, timevalh, timevall)
        End If
    End Sub
    Public Function BTICard_IRIGWr(ByRef irigtime As BTIIRIGTIME, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGWr(irigtime, handleval)
        Else
            Return BTICARD_64.BTICard_IRIGWr(irigtime, handleval)
        End If
    End Function
    Public Function BTICard_IRIGWrEx(ByRef timebuf As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_IRIGWrEx(timebuf, handleval)
        Else
            Return BTICARD_64.BTICard_IRIGWrEx(timebuf, handleval)
        End If
    End Function
    Public Function BTICard_KernIntStatus(ByRef valueptr As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_KernIntStatus(valueptr, handleval)
        Else
            Return BTICARD_64.BTICard_KernIntStatus(valueptr, handleval)
        End If
    End Function
    Public Function BTICard_KernStatus(ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_KernStatus(valueptr, typeval, handleval)
        Else
            Return BTICARD_64.BTICard_KernStatus(valueptr, typeval, handleval)
        End If
    End Function
    Public Function BTICard_KernStatusEx(ByRef valueptr As UInt32, ByVal typeval As UInt32, ByVal index As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_KernStatusEx(valueptr, typeval, index, handleval)
        Else
            Return BTICARD_64.BTICard_KernStatusEx(valueptr, typeval, index, handleval)
        End If
    End Function
    Public Function BTICard_MakeLong(ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_MakeLong(valh, vall)
        Else
            Return BTICARD_64.BTICard_MakeLong(valh, vall)
        End If
    End Function
    Public Function BTICard_MakeWord(ByVal valh As Byte, ByVal vall As Byte) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_MakeWord(valh, vall)
        Else
            Return BTICARD_64.BTICard_MakeWord(valh, vall)
        End If
    End Function
    Public Function BTICard_MantToAscii(ByRef buf As String, ByVal mant As Int32, ByVal exp As Int32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_MantToAscii(buf, mant, exp)
        Else
            Return BTICARD_64.BTICard_MantToAscii(buf, mant, exp)
        End If
    End Function
    Public Function BTICard_Mask(ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_Mask(dataval, cntval)
        Else
            Return BTICARD_64.BTICard_Mask(dataval, cntval)
        End If
    End Function
    Public Sub BTICard_MaxMant(ByRef mant As UInt32, ByRef exp As Int32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_MaxMant(mant, exp)
        Else
            BTICARD_64.BTICard_MaxMant(mant, exp)
        End If
    End Sub
    Public Function BTICard_Mod(ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_Mod(moda, modb)
        Else
            Return BTICARD_64.BTICard_Mod(moda, modb)
        End If
    End Function
    Public Sub BTICard_Mod64(ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_Mod64(resulth, resultl, valah, valal, valbh, valbl)
        Else
            BTICARD_64.BTICard_Mod64(resulth, resultl, valah, valal, valbh, valbl)
        End If
    End Sub
    Public Function BTICard_Mul(ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_Mul(mula, mulb)
        Else
            Return BTICARD_64.BTICard_Mul(mula, mulb)
        End If
    End Function
    Public Sub BTICard_Mul64(ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_Mul64(resulth, resultl, valah, valal, valbh, valbl)
        Else
            BTICARD_64.BTICard_Mul64(resulth, resultl, valah, valal, valbh, valbl)
        End If
    End Sub
    Public Sub BTICard_NormalMant(ByRef mant As UInt32, ByRef exp As Int32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_NormalMant(mant, exp)
        Else
            BTICARD_64.BTICard_NormalMant(mant, exp)
        End If
    End Sub
    Public Function BTICard_PortRd(ByVal addrval As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_PortRd(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_PortRd(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_PortWr(ByVal value As UInt16, ByVal addrval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_PortWr(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_PortWr(value, addrval, handleval)
        End If
    End Sub
    Public Function BTICard_ProgRdW(ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ProgRdW(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_ProgRdW(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_ProgWrW(ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ProgWrW(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_ProgWrW(value, addrval, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMFill(ByVal value As UInt16, ByVal addrval As UInt32, ByVal countval As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMFill(value, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_RAMFill(value, addrval, countval, handleval)
        End If
    End Sub
    Public Function BTICard_RAMRdB(ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_RAMRdB(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_RAMRdB(addrval, handleval)
        End If
    End Function
    Public Function BTICard_RAMRdL(ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_RAMRdL(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_RAMRdL(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_RAMRdmL(ByRef valueptr As UInt32, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMRdmL(valueptr, addrptr, countval, handleval)
        Else
            BTICARD_64.BTICard_RAMRdmL(valueptr, addrptr, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMRdmW(ByRef valueptr As UInt16, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMRdmW(valueptr, addrptr, countval, handleval)
        Else
            BTICARD_64.BTICard_RAMRdmW(valueptr, addrptr, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMRdsL(ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMRdsL(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_RAMRdsL(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMRdsW(ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMRdsW(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_RAMRdsW(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Function BTICard_RAMRdW(ByVal addrval As UInt32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_RAMRdW(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_RAMRdW(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_RAMWipe(ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMWipe(handleval)
        Else
            BTICARD_64.BTICard_RAMWipe(handleval)
        End If
    End Sub
    Public Sub BTICard_RAMWipeEx(ByVal value As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMWipeEx(value, handleval)
        Else
            BTICARD_64.BTICard_RAMWipeEx(value, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMWrB(ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMWrB(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_RAMWrB(value, addrval, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMWrL(ByVal value As UInt32, ByVal addrval As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMWrL(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_RAMWrL(value, addrval, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMWrmL(ByRef valueptr As UInt32, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMWrmL(valueptr, addrptr, countval, handleval)
        Else
            BTICARD_64.BTICard_RAMWrmL(valueptr, addrptr, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMWrmW(ByRef valueptr As UInt16, ByRef addrptr As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMWrmW(valueptr, addrptr, countval, handleval)
        Else
            BTICARD_64.BTICard_RAMWrmW(valueptr, addrptr, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMWrsL(ByRef valueptr As UInt32, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMWrsL(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_RAMWrsL(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMWrsW(ByRef valueptr As UInt16, ByVal addrval As UInt32, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMWrsW(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_RAMWrsW(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_RAMWrW(ByVal value As UInt16, ByVal addrval As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_RAMWrW(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_RAMWrW(value, addrval, handleval)
        End If
    End Sub
    Public Function BTICard_ReverseLong(ByVal value As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ReverseLong(value)
        Else
            Return BTICARD_64.BTICard_ReverseLong(value)
        End If
    End Function
    Public Function BTICard_ReverseWord(ByVal value As UInt16) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ReverseWord(value)
        Else
            Return BTICARD_64.BTICard_ReverseWord(value)
        End If
    End Function
    Public Function BTICard_SeqBlkRd(ByRef buf As UInt16, ByVal bufcount As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqBlkRd(buf, bufcount, blkcnt, handleval)
        Else
            Return BTICARD_64.BTICard_SeqBlkRd(buf, bufcount, blkcnt, handleval)
        End If
    End Function
    Public Function BTICard_SeqBlkRdEx(ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal maxblkcnt As UInt32, ByRef blkcnt As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqBlkRdEx(buf, bufcount, maxblkcnt, blkcnt, handleval)
        Else
            Return BTICARD_64.BTICard_SeqBlkRdEx(buf, bufcount, maxblkcnt, blkcnt, handleval)
        End If
    End Function
    Public Function BTICard_SeqClear(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqClear(handleval)
        Else
            Return BTICARD_64.BTICard_SeqClear(handleval)
        End If
    End Function
    Public Function BTICard_SeqCommRd(ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqCommRd(buf, bufcount, handleval)
        Else
            Return BTICARD_64.BTICard_SeqCommRd(buf, bufcount, handleval)
        End If
    End Function
    Public Function BTICard_SeqConfig(ByVal configval As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqConfig(configval, handleval)
        Else
            Return BTICARD_64.BTICard_SeqConfig(configval, handleval)
        End If
    End Function
    Public Function BTICard_SeqConfigEx(ByVal configval As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqConfigEx(configval, seqcount, cardnum, handleval)
        Else
            Return BTICARD_64.BTICard_SeqConfigEx(configval, seqcount, cardnum, handleval)
        End If
    End Function
    Public Function BTICard_SeqConfigExx(ByVal configval As UInt32, ByVal seqaddr As UInt32, ByVal seqcount As UInt32, ByVal cardnum As UInt16, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqConfigExx(configval, seqaddr, seqcount, cardnum, handleval)
        Else
            Return BTICARD_64.BTICard_SeqConfigExx(configval, seqaddr, seqcount, cardnum, handleval)
        End If
    End Function
    Public Function BTICard_SeqDMARd(ByRef buf As UInt16, ByVal bufcount As UInt32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqDMARd(buf, bufcount, handleval)
        Else
            Return BTICARD_64.BTICard_SeqDMARd(buf, bufcount, handleval)
        End If
    End Function
    Public Function BTICard_SeqFindCheckVersion(ByRef precord As UInt16, ByVal version As UInt16) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqFindCheckVersion(precord, version)
        Else
            Return BTICARD_64.BTICard_SeqFindCheckVersion(precord, version)
        End If
    End Function
    Public Function BTICard_SeqFindInit(ByRef seqbuf As UInt16, ByVal seqbufsize As UInt32, ByRef sfinfo As SEQFINDINFO) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqFindInit(seqbuf, seqbufsize, sfinfo)
        Else
            Return BTICARD_64.BTICard_SeqFindInit(seqbuf, seqbufsize, sfinfo)
        End If
    End Function
    Public Function BTICard_SeqFindMore1553Ex(ByRef precmore As SEQRECORDMORE1553, ByVal recordsize As UInt16, ByRef precbase As SEQRECORD1553) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqFindMore1553Ex(precmore, recordsize, precbase)
        Else
            Return BTICARD_64.BTICard_SeqFindMore1553Ex(precmore, recordsize, precbase)
        End If
    End Function
    Public Function BTICard_SeqFindNext1553Ex(ByRef precord As SEQRECORD1553, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqFindNext1553Ex(precord, recordsize, sfinfo)
        Else
            Return BTICARD_64.BTICard_SeqFindNext1553Ex(precord, recordsize, sfinfo)
        End If
    End Function
    Public Function BTICard_SeqFindNext429Ex(ByRef precord As SEQRECORD429, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqFindNext429Ex(precord, recordsize, sfinfo)
        Else
            Return BTICARD_64.BTICard_SeqFindNext429Ex(precord, recordsize, sfinfo)
        End If
    End Function
    Public Function BTICard_SeqFindNext708Ex(ByRef precord As SEQRECORD708, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqFindNext708Ex(precord, recordsize, sfinfo)
        Else
            Return BTICARD_64.BTICard_SeqFindNext708Ex(precord, recordsize, sfinfo)
        End If
    End Function
    Public Function BTICard_SeqFindNext717Ex(ByRef precord As SEQRECORD717, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqFindNext717Ex(precord, recordsize, sfinfo)
        Else
            Return BTICARD_64.BTICard_SeqFindNext717Ex(precord, recordsize, sfinfo)
        End If
    End Function
    Public Function BTICard_SeqFindNextCSDBEx(ByRef precord As SEQRECORDCSDB, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqFindNextCSDBEx(precord, recordsize, sfinfo)
        Else
            Return BTICARD_64.BTICard_SeqFindNextCSDBEx(precord, recordsize, sfinfo)
        End If
    End Function
    Public Function BTICard_SeqFindNextDIOEx(ByRef precord As SEQRECORDDIO, ByVal recordsize As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqFindNextDIOEx(precord, recordsize, sfinfo)
        Else
            Return BTICARD_64.BTICard_SeqFindNextDIOEx(precord, recordsize, sfinfo)
        End If
    End Function
    Public Function BTICard_SeqFindNextEx(ByRef precord As UInt16, ByVal recordcount As UInt16, ByRef seqtype As UInt16, ByRef sfinfo As SEQFINDINFO) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqFindNextEx(precord, recordcount, seqtype, sfinfo)
        Else
            Return BTICARD_64.BTICard_SeqFindNextEx(precord, recordcount, seqtype, sfinfo)
        End If
    End Function
    Public Function BTICard_SeqInterval(ByVal interval As Int32, ByVal mode As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqInterval(interval, mode, handleval)
        Else
            Return BTICARD_64.BTICard_SeqInterval(interval, mode, handleval)
        End If
    End Function
    Public Function BTICard_SeqIntervalEx(ByVal shiftval As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqIntervalEx(shiftval, handleval)
        Else
            Return BTICARD_64.BTICard_SeqIntervalEx(shiftval, handleval)
        End If
    End Function
    Public Function BTICard_SeqIsRunning(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqIsRunning(handleval)
        Else
            Return BTICARD_64.BTICard_SeqIsRunning(handleval)
        End If
    End Function
    Public Function BTICard_SeqLogFrequency(ByVal logfreq As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqLogFrequency(logfreq, handleval)
        Else
            Return BTICARD_64.BTICard_SeqLogFrequency(logfreq, handleval)
        End If
    End Function
    Public Function BTICard_SeqRd(ByRef buf As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqRd(buf, handleval)
        Else
            Return BTICARD_64.BTICard_SeqRd(buf, handleval)
        End If
    End Function
    Public Function BTICard_SeqRdEx(ByRef buf As UInt16, ByVal bufcount As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqRdEx(buf, bufcount, handleval)
        Else
            Return BTICARD_64.BTICard_SeqRdEx(buf, bufcount, handleval)
        End If
    End Function
    Public Function BTICard_SeqResume(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqResume(handleval)
        Else
            Return BTICARD_64.BTICard_SeqResume(handleval)
        End If
    End Function
    Public Function BTICard_SeqStart(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqStart(handleval)
        Else
            Return BTICARD_64.BTICard_SeqStart(handleval)
        End If
    End Function
    Public Function BTICard_SeqStatus(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqStatus(handleval)
        Else
            Return BTICARD_64.BTICard_SeqStatus(handleval)
        End If
    End Function
    Public Function BTICard_SeqStop(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SeqStop(handleval)
        Else
            Return BTICARD_64.BTICard_SeqStop(handleval)
        End If
    End Function
    Public Function BTICard_Shl(ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_Shl(dataval, cntval)
        Else
            Return BTICARD_64.BTICard_Shl(dataval, cntval)
        End If
    End Function
    Public Function BTICard_Shr(ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_Shr(dataval, cntval)
        Else
            Return BTICARD_64.BTICard_Shr(dataval, cntval)
        End If
    End Function
    Public Function BTICard_SignMant(ByRef str As String) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SignMant(str)
        Else
            Return BTICARD_64.BTICard_SignMant(str)
        End If
    End Function
    Public Sub BTICard_Sub64(ByRef resulth As UInt32, ByRef resultl As UInt32, ByVal valah As UInt32, ByVal valal As UInt32, ByVal valbh As UInt32, ByVal valbl As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_Sub64(resulth, resultl, valah, valal, valbh, valbl)
        Else
            BTICARD_64.BTICard_Sub64(resulth, resultl, valah, valal, valbh, valbl)
        End If
    End Sub
    Public Sub BTICard_SwapEndianL(ByRef value As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_SwapEndianL(value)
        Else
            BTICARD_64.BTICard_SwapEndianL(value)
        End If
    End Sub
    Public Sub BTICard_SwapEndianW(ByRef valuea As UInt16, ByRef valueb As UInt16)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_SwapEndianW(valuea, valueb)
        Else
            BTICARD_64.BTICard_SwapEndianW(valuea, valueb)
        End If
    End Sub
    Public Sub BTICard_SwapIfBigEndianL(ByRef value As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_SwapIfBigEndianL(value)
        Else
            BTICARD_64.BTICard_SwapIfBigEndianL(value)
        End If
    End Sub
    Public Sub BTICard_SwapIfBigEndianW(ByRef valuea As UInt16, ByRef valueb As UInt16)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_SwapIfBigEndianW(valuea, valueb)
        Else
            BTICARD_64.BTICard_SwapIfBigEndianW(valuea, valueb)
        End If
    End Sub
    Public Sub BTICard_SwapIfLittleEndianL(ByRef value As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_SwapIfLittleEndianL(value)
        Else
            BTICARD_64.BTICard_SwapIfLittleEndianL(value)
        End If
    End Sub
    Public Sub BTICard_SwapIfLittleEndianW(ByRef valuea As UInt16, ByRef valueb As UInt16)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_SwapIfLittleEndianW(valuea, valueb)
        Else
            BTICARD_64.BTICard_SwapIfLittleEndianW(valuea, valueb)
        End If
    End Sub
    Public Function BTICard_SysMonClear(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonClear(handleval)
        Else
            Return BTICARD_64.BTICard_SysMonClear(handleval)
        End If
    End Function
    Public Function BTICard_SysMonInit(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonInit(handleval)
        Else
            Return BTICARD_64.BTICard_SysMonInit(handleval)
        End If
    End Function
    Public Function BTICard_SysMonTypeGet(ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonTypeGet(index, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonTypeGet(index, handleval)
        End If
    End Function
    Public Function BTICard_SysMonDescGet(ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonDescGet(index, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonDescGet(index, handleval)
        End If
    End Function
    Public Function BTICard_SysMonMaxRd(ByVal index As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonMaxRd(index, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonMaxRd(index, handleval)
        End If
    End Function
    Public Function BTICard_SysMonMinRd(ByVal index As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonMinRd(index, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonMinRd(index, handleval)
        End If
    End Function
    Public Function BTICard_SysMonNomRd(ByVal index As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonNomRd(index, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonNomRd(index, handleval)
        End If
    End Function
    Public Function BTICard_SysMonUserStr(ByVal value As Int32, ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonUserStr(value, index, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonUserStr(value, index, handleval)
        End If
    End Function
    Public Function BTICard_SysMonValRd(ByVal index As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonValRd(index, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonValRd(index, handleval)
        End If
    End Function
    Public Function BTICard_SysMonValStr(ByVal index As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonValStr(index, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonValStr(index, handleval)
        End If
    End Function
    Public Function BTICard_SysMonThresholdSet(ByVal enable As Int32, ByVal minval As Int32, ByVal maxval As Int32, ByVal index As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonThresholdSet(enable, minval, maxval, index, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonThresholdSet(enable, minval, maxval, index, handleval)
        End If
    End Function
    Public Function BTICard_SysMonValToDAC(ByVal val As Int32, ByVal rangemin As Int32, ByVal rangemax As Int32, ByVal dacval_max As UInt16, ByVal scalefactor As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonValToDAC(val, rangemin, rangemax, dacval_max, scalefactor, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonValToDAC(val, rangemin, rangemax, dacval_max, scalefactor, handleval)
        End If
    End Function
    Public Function BTICard_SysMonDACToVal(ByVal dacval As UInt16, ByVal rangemin As Int32, ByVal rangemax As Int32, ByVal dacval_max As UInt16, ByVal scalefactor As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_SysMonDACToVal(dacval, rangemin, rangemax, dacval_max, scalefactor, handleval)
        Else
            Return BTICARD_64.BTICard_SysMonDACToVal(dacval, rangemin, rangemax, dacval_max, scalefactor, handleval)
        End If
    End Function
    Public Function BTICard_TickTimerStart(ByVal milliseconds As Int32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_TickTimerStart(milliseconds)
        Else
            Return BTICARD_64.BTICard_TickTimerStart(milliseconds)
        End If
    End Function
    Public Function BTICard_TickTimerValid(ByVal timer As Int32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_TickTimerValid(timer)
        Else
            Return BTICARD_64.BTICard_TickTimerValid(timer)
        End If
    End Function
    Public Function BTICard_Timer64Rd(ByRef valueh As UInt32, ByRef valuel As UInt32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_Timer64Rd(valueh, valuel, handleval)
        Else
            Return BTICARD_64.BTICard_Timer64Rd(valueh, valuel, handleval)
        End If
    End Function
    Public Sub BTICard_Timer64Wr(ByVal valueh As UInt32, ByVal valuel As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_Timer64Wr(valueh, valuel, handleval)
        Else
            BTICARD_64.BTICard_Timer64Wr(valueh, valuel, handleval)
        End If
    End Sub
    Public Sub BTICard_TimerClear(ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_TimerClear(handleval)
        Else
            BTICARD_64.BTICard_TimerClear(handleval)
        End If
    End Sub
    Public Function BTICard_TimerRd(ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_TimerRd(handleval)
        Else
            Return BTICARD_64.BTICard_TimerRd(handleval)
        End If
    End Function
    Public Function BTICard_TimerResolution(ByVal timerresol As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_TimerResolution(timerresol, handleval)
        Else
            Return BTICARD_64.BTICard_TimerResolution(timerresol, handleval)
        End If
    End Function
    Public Function BTICard_TimerResolutionEx(ByVal timershift As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_TimerResolutionEx(timershift, handleval)
        Else
            Return BTICARD_64.BTICard_TimerResolutionEx(timershift, handleval)
        End If
    End Function
    Public Function BTICard_TimerStatus(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_TimerStatus(handleval)
        Else
            Return BTICARD_64.BTICard_TimerStatus(handleval)
        End If
    End Function
    Public Sub BTICard_TimerWr(ByVal value As UInt32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_TimerWr(value, handleval)
        Else
            BTICARD_64.BTICard_TimerWr(value, handleval)
        End If
    End Sub
    Public Function BTICard_ValAsciiCmpi(ByRef str1 As String, ByRef str2 As String) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValAsciiCmpi(str1, str2)
        Else
            Return BTICARD_64.BTICard_ValAsciiCmpi(str1, str2)
        End If
    End Function
    Public Function BTICard_ValAsciiCpy(ByRef strdest As String, ByRef strsrc As String, ByVal count As Int32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValAsciiCpy(strdest, strsrc, count)
        Else
            Return BTICARD_64.BTICard_ValAsciiCpy(strdest, strsrc, count)
        End If
    End Function
    Public Sub BTICard_ValAsciiTrimLead(ByRef buf As String)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ValAsciiTrimLead(buf)
        Else
            BTICARD_64.BTICard_ValAsciiTrimLead(buf)
        End If
    End Sub
    Public Sub BTICard_ValAsciiTrimTrail(ByRef buf As String)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_ValAsciiTrimTrail(buf)
        Else
            BTICARD_64.BTICard_ValAsciiTrimTrail(buf)
        End If
    End Sub
    Public Function BTICard_ValFromAscii(ByRef asciistr As String, ByVal radixval As Int32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValFromAscii(asciistr, radixval)
        Else
            Return BTICARD_64.BTICard_ValFromAscii(asciistr, radixval)
        End If
    End Function
    Public Function BTICard_ValGetBits(ByVal oldvalue As UInt32, ByVal startbit As Int32, ByVal endbit As Int32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValGetBits(oldvalue, startbit, endbit)
        Else
            Return BTICARD_64.BTICard_ValGetBits(oldvalue, startbit, endbit)
        End If
    End Function
    Public Function BTICard_ValIncAscii(ByRef asciistr As String) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValIncAscii(asciistr)
        Else
            Return BTICARD_64.BTICard_ValIncAscii(asciistr)
        End If
    End Function
    Public Function BTICard_ValInccAscii(ByRef asciistr As String) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValInccAscii(asciistr)
        Else
            Return BTICARD_64.BTICard_ValInccAscii(asciistr)
        End If
    End Function
    Public Function BTICard_ValIsLower(ByVal value As Int32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValIsLower(value)
        Else
            Return BTICARD_64.BTICard_ValIsLower(value)
        End If
    End Function
    Public Function BTICard_ValLenAscii(ByVal numbits As Int32, ByVal radixval As Int32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValLenAscii(numbits, radixval)
        Else
            Return BTICARD_64.BTICard_ValLenAscii(numbits, radixval)
        End If
    End Function
    Public Function BTICard_ValPutBits(ByVal oldvalue As UInt32, ByVal newfld As UInt32, ByVal startbit As Int32, ByVal endbit As Int32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValPutBits(oldvalue, newfld, startbit, endbit)
        Else
            Return BTICARD_64.BTICard_ValPutBits(oldvalue, newfld, startbit, endbit)
        End If
    End Function
    Public Function BTICard_ValToAscii(ByVal value As UInt32, ByRef asciistr As String, ByVal numbits As Int32, ByVal radixval As Int32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValToAscii(value, asciistr, numbits, radixval)
        Else
            Return BTICARD_64.BTICard_ValToAscii(value, asciistr, numbits, radixval)
        End If
    End Function
    Public Function BTICard_ValToUpper(ByVal value As Int32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_ValToUpper(value)
        Else
            Return BTICARD_64.BTICard_ValToUpper(value)
        End If
    End Function
    Public Function BTICard_VARRdL(ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_VARRdL(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_VARRdL(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_VARRdsW(ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_VARRdsW(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_VARRdsW(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Function BTICard_VARRdW(ByVal addrval As UInt16, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTICARD_32.BTICard_VARRdW(addrval, handleval)
        Else
            Return BTICARD_64.BTICard_VARRdW(addrval, handleval)
        End If
    End Function
    Public Sub BTICard_VARWrL(ByVal value As UInt32, ByVal addrval As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_VARWrL(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_VARWrL(value, addrval, handleval)
        End If
    End Sub
    Public Sub BTICard_VARWrsW(ByRef valueptr As UInt16, ByVal addrval As UInt16, ByVal countval As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_VARWrsW(valueptr, addrval, countval, handleval)
        Else
            BTICARD_64.BTICard_VARWrsW(valueptr, addrval, countval, handleval)
        End If
    End Sub
    Public Sub BTICard_VARWrW(ByVal value As UInt16, ByVal addrval As UInt16, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTICARD_32.BTICard_VARWrW(value, addrval, handleval)
        Else
            BTICARD_64.BTICard_VARWrW(value, addrval, handleval)
        End If
    End Sub

    '/**
    '*
    '*  External definitions
    '*
    '*  Note: To operate the BUSBox in serial (RS-232) mode, set
    '*  the BUSBox_SerialMode = TRUE.  Optionally, you can set the
    '*  BUSBox_BaudRate = baudvalue, but this defaults to the
    '*  suggested 115200 baud.
    '*
    '**/

    '/**
    '*
    '*  Core number constants
    '*
    '**/

    Public Const COREA As UInt32 = &H0   '//Selects Core A
    Public Const COREB As UInt32 = &H1   '//Selects Core B
    Public Const COREC As UInt32 = &H2   '//Selects Core C
    Public Const CORED As UInt32 = &H3   '//Selects Core D

    '/**
    '*
    '*  Sequential Record configuration options
    '*
    '**/

    Public Const SEQCFG_DEFAULT As UInt32 = &H0  '//Select all default settings
    Public Const SEQCFG_FILLHALT As UInt32 = &H0 '//Enable sequential record in fill and halt mode (default)
    Public Const SEQCFG_DISABLE As UInt32 = &H1  '//Disable sequential record
    Public Const SEQCFG_CONTINUOUS As UInt32 = &H2   '//Enable sequential record in continuous mode
    Public Const SEQCFG_DMA As UInt32 = &H4  '//Enable monitor in dma mode
    Public Const SEQCFG_FREE As UInt32 = &H8 '//Enable sequential record in free mode
    Public Const SEQCFG_DELTA As UInt32 = &H10    '//Enable sequential record in delta mode
    Public Const SEQCFG_INTERVAL As UInt32 = &H20 '//Enable sequential record in interval mode
    Public Const SEQCFG_NOLOGFULL As UInt32 = &H0    '//Do not generate event log when sequential record is full (default)
    Public Const SEQCFG_LOGFULL As UInt32 = &H1000  '//Generate event log when sequential record is full
    Public Const SEQCFG_NOLOGFREQ As UInt32 = &H0    '//Do not generate event logs at a user specified frequency (default)
    Public Const SEQCFG_LOGFREQ As UInt32 = &H2000  '//Generate event logs at user specified frequency
    Public Const SEQCFG_16K As UInt32 = &H0  '//Allocate a 16K sequential record buffer (default)
    Public Const SEQCFG_ALLAVAIL As UInt32 = &H1000000 '//Allocate all available memory to a sequential record buffer
    Public Const SEQCFG_32K As UInt32 = &H2000000  '//Allocate a 32K sequential record buffer
    Public Const SEQCFG_64K As UInt32 = &H4000000  '//Allocate a 64K sequential record buffer
    Public Const SEQCFG_128K As UInt32 = &H8000000 '//Allocate a 128K sequential record buffer

    '/**
    '*
    '*  Sequential Record type fields
    '*
    '**/

    Public Const SEQTYPE_MASK As UInt32 = &HFF    '//Sequential record type mask value
    Public Const SEQTYPE_429 As UInt32 = &H1 '//Sequential record type is ARINC 429
    Public Const SEQTYPE_717 As UInt32 = &H2 '//Sequential record type is ARINC 717
    Public Const SEQTYPE_1553 As UInt32 = &H3    '//Sequential record type is MIL-STD-1553
    Public Const SEQTYPE_708 As UInt32 = &H4 '//Sequential record type is ARINC 708
    Public Const SEQTYPE_USER As UInt32 = &H5    '//Sequential record type is User Defined
    Public Const SEQTYPE_CSDB As UInt32 = &H6    '//Sequential record type is CSDB
    Public Const SEQTYPE_DIO As UInt32 = &H7 '//Sequential record type is DIO
    Public Const SEQTYPE_RESTART As UInt32 = &HFF '//Sequential record type is Restart

    '/**
    '*
    '*  Sequential Record version fields
    '*
    '**/

    Public Const SEQVER_MASK As UInt32 = &HFF00 '//Sequential record version mask value
    Public Const SEQVER_0 As UInt32 = &H0    '//Sequential record version number is 0
    Public Const SEQVER_1 As UInt32 = &H100    '//Sequential record version number is 1

    '/**
    '*
    '*  Event log list configuration options
    '*
    '**/

    Public Const LOGCFG_DEFAULT As UInt32 = &H0  '//Select all default settings
    Public Const LOGCFG_ENABLE As UInt32 = &H0   '//Enable event log list (default)
    Public Const LOGCFG_DISABLE As UInt32 = &H1  '//Disable event log list

    '/**
    '*
    '*  IRIG timer configuration options
    '*
    '**/

    Public Const IRIGCFG_DEFAULT As UInt32 = &H0 '//Select all default settings
    Public Const IRIGCFG_ENABLE As UInt32 = &H0  '//Enable IRIG timer (default)
    Public Const IRIGCFG_DISABLE As UInt32 = &H1 '//Disable IRIG timer
    Public Const IRIGCFG_SPEEDB As UInt32 = &H0  '//Bit rate is IRIGB (default)
    Public Const IRIGCFG_SPEEDA As UInt32 = &H2  '//Bit rate is IRIGA
    Public Const IRIGCFG_INTERNAL As UInt32 = &H0    '//IRIG timer operates internally (default)
    Public Const IRIGCFG_EXTERNAL As UInt32 = &H4    '//IRIG timer operates externally
    Public Const IRIGCFG_SLAVE As UInt32 = &H0   '//IRIG timer is a slave  / receiver (default)
    Public Const IRIGCFG_MASTER As UInt32 = &H8  '//IRIG timer is a master / transmitter
    Public Const IRIGCFG_PPS As UInt32 = &H10 '//IRIG timer operates in PPS mode (rcv/xmt)
    Public Const IRIGCFG_PWM As UInt32 = &H0 '//IRIG timer uses pulse width modulated signaling (rcv/xmt) (default)
    Public Const IRIGCFG_AM As UInt32 = &H20  '//IRIG timer uses amplitude modulated signaling (rcv only hw dependant)

    '/**
    '*
    '*  IRIG timer field definitions
    '*
    '**/

    Public Const IRIGFIELD_USECLSB As UInt32 = &H0   '//Microseconds LSB in timestamp field
    Public Const IRIGFIELD_USECMSB As UInt32 = &HB   '//Microseconds MSB in timestamp field
    Public Const IRIGFIELD_MSECLSB As UInt32 = &HC   '//Milliseconds LSB in timestamp field
    Public Const IRIGFIELD_MSECMSB As UInt32 = &H17   '//Milliseconds MSB in timestamp field
    Public Const IRIGFIELD_SECLSB As UInt32 = &H18    '//Seconds LSB in timestamp field
    Public Const IRIGFIELD_SECMSB As UInt32 = &H1F    '//Seconds MSB in timestamp field
    Public Const IRIGFIELD_MINLSB As UInt32 = &H0    '//Minutes LSB in timestamph field
    Public Const IRIGFIELD_MINMSB As UInt32 = &H7    '//Minutes MSB in timestamph field
    Public Const IRIGFIELD_HRSLSB As UInt32 = &H8    '//Hours LSB in timestamph field
    Public Const IRIGFIELD_HRSMSB As UInt32 = &HF    '//Hours MSB in timestamph field
    Public Const IRIGFIELD_DAYLSB As UInt32 = &H10    '//Days LSB in timestamph field
    Public Const IRIGFIELD_DAYMSB As UInt32 = &H1B    '//Days MSB in timestamph field

    '/**
    '*
    '*  C54x Global Registers
    '*
    '**/

    Public Const C54_GREG_IMR As UInt32 = &H0    '//Interrupt mask register
    Public Const C54_GREG_IFR As UInt32 = &H1    '//Interrupt flag register
    Public Const C54_GREG_ST0 As UInt32 = &H6    '//Status register 0
    Public Const C54_GREG_ST1 As UInt32 = &H7    '//Status register 1
    Public Const C54_GREG_AL As UInt32 = &H8 '//Accumulator A low word (bits 15-00)
    Public Const C54_GREG_AH As UInt32 = &H9 '//Accumulator A high word (bits 31-16)
    Public Const C54_GREG_AG As UInt32 = &HA '//Accumulator A guars bits (bits 39-32)
    Public Const C54_GREG_BL As UInt32 = &HB '//Accumulator B low word (bits 15-00)
    Public Const C54_GREG_BH As UInt32 = &HC '//Accumulator B high word (bits 31-16)
    Public Const C54_GREG_BG As UInt32 = &HD '//Accumulator B guard bits (bits 39-32
    Public Const C54_GREG_T As UInt32 = &HE  '//Temporary register
    Public Const C54_GREG_TRN As UInt32 = &HF    '//Transition register
    Public Const C54_GREG_AR0 As UInt32 = &H10    '//Auxilliary register 0
    Public Const C54_GREG_AR1 As UInt32 = &H11    '//Auxilliary register 1
    Public Const C54_GREG_AR2 As UInt32 = &H12    '//Auxilliary register 2
    Public Const C54_GREG_AR3 As UInt32 = &H13    '//Auxilliary register 3
    Public Const C54_GREG_AR4 As UInt32 = &H14    '//Auxilliary register 4
    Public Const C54_GREG_AR5 As UInt32 = &H15    '//Auxilliary register 5
    Public Const C54_GREG_AR6 As UInt32 = &H16    '//Auxilliary register 6
    Public Const C54_GREG_AR7 As UInt32 = &H17    '//Auxilliary register 7
    Public Const C54_GREG_SP As UInt32 = &H18 '//Stack pointer
    Public Const C54_GREG_BK As UInt32 = &H19 '//Circular-buffer size register
    Public Const C54_GREG_BRC As UInt32 = &H1A    '//Block-repeat counter
    Public Const C54_GREG_RSA As UInt32 = &H1B    '//Block-repeat start address
    Public Const C54_GREG_REA As UInt32 = &H1C    '//Block-repeat end address
    Public Const C54_GREG_PMST As UInt32 = &H1D   '//Processor mode status register
    Public Const C54_GREG_XPC As UInt32 = &H1E    '//Program counter extension register
    Public Const C54_GREG_DRR20 As UInt32 = &H20  '//McBSP0 data receive register high
    Public Const C54_GREG_DRR10 As UInt32 = &H21  '//McBSP0 data receive register low
    Public Const C54_GREG_DXR20 As UInt32 = &H22  '//McBSP0 data transmit register high
    Public Const C54_GREG_DXR10 As UInt32 = &H23  '//McBSP0 data transmit register low
    Public Const C54_GREG_TIM As UInt32 = &H24    '//Timer count register
    Public Const C54_GREG_PRD As UInt32 = &H25    '//Timer period register
    Public Const C54_GREG_TCR As UInt32 = &H26    '//Timer control register
    Public Const C54_GREG_SWWSR As UInt32 = &H28  '//External interface software wait-state register
    Public Const C54_GREG_BSCR As UInt32 = &H29   '//External interface bank-switching control register
    Public Const C54_GREG_SWCR As UInt32 = &H2B   '//Software wait-state control register
    Public Const C54_GREG_HPIC As UInt32 = &H2C   '//Host port interface control register
    Public Const C54_GREG_DRR22 As UInt32 = &H30  '//McBSP2 data receive register high
    Public Const C54_GREG_DRR12 As UInt32 = &H31  '//McBSP2 data receive register low
    Public Const C54_GREG_DXR22 As UInt32 = &H32  '//McBSP2 data transmit register high
    Public Const C54_GREG_DXR12 As UInt32 = &H33  '//McBSP2 data transmit register low
    Public Const C54_GREG_SPSA2 As UInt32 = &H34  '//McBSP2 sub-address register
    Public Const C54_GREG_SPDR2 As UInt32 = &H35  '//McBSP2 sub-address data register
    Public Const C54_GREG_SPSA0 As UInt32 = &H38  '//McBSP0 sub-address register
    Public Const C54_GREG_SPDR0 As UInt32 = &H39  '//McBSP0 sub-address data register
    Public Const C54_GREG_DRR21 As UInt32 = &H40  '//McBSP1 data receive register high
    Public Const C54_GREG_DRR11 As UInt32 = &H41  '//McBSP1 data receive register low
    Public Const C54_GREG_DXR21 As UInt32 = &H42  '//McBSP1 data transmit register high
    Public Const C54_GREG_DXR11 As UInt32 = &H43  '//McBSP1 data transmit register low
    Public Const C54_GREG_SPSA1 As UInt32 = &H48  '//McBSP1 sub-address register
    Public Const C54_GREG_SPDR1 As UInt32 = &H49  '//McBSP1 sub-address data register
    Public Const C54_GREG_DMPREC As UInt32 = &H54 '//DMA channel priority and enable control
    Public Const C54_GREG_DMSBAR As UInt32 = &H55 '//DMA channel sub-address register
    Public Const C54_GREG_DMADI As UInt32 = &H56  '//DMA channel sub-address data with increment
    Public Const C54_GREG_DMADN As UInt32 = &H57  '//DMA channel sub-address data without increment
    Public Const C54_GREG_CLKMD As UInt32 = &H58  '//Clock-mode register

    '/**
    '*
    '*  Event types.
    '*
    '**/

    Public Const EVENTTYPE_1553MSG As UInt32 = &H1   '//MIL-STD-1553 message
    Public Const EVENTTYPE_1553OPCODE As UInt32 = &H2    '//MIL-STD-1553 event log opcode
    Public Const EVENTTYPE_1553HALT As UInt32 = &H3  '//MIL-STD-1553 schedule halt
    Public Const EVENTTYPE_1553PAUSE As UInt32 = &H4 '//MIL-STD-1553 schedule pause
    Public Const EVENTTYPE_1553LIST As UInt32 = &H5  '//MIL-STD-1553 list buffer empty/full
    Public Const EVENTTYPE_1553SERIAL As UInt32 = &H6    '//MIL-STD-1553 serial empty
    Public Const EVENTTYPE_429MSG As UInt32 = &H11    '//ARINC 429 message
    Public Const EVENTTYPE_429OPCODE As UInt32 = &H12 '//ARINC 429 event log opcode
    Public Const EVENTTYPE_429HALT As UInt32 = &H13   '//ARINC 429 schedule halt
    Public Const EVENTTYPE_429PAUSE As UInt32 = &H14  '//ARINC 429 schedule pause
    Public Const EVENTTYPE_429LIST As UInt32 = &H15   '//ARINC 429 list buffer empty/full
    Public Const EVENTTYPE_429ERR As UInt32 = &H16    '//ARINC 429 decoder error detected
    Public Const EVENTTYPE_717WORD As UInt32 = &H21   '//ARINC 717 word received
    Public Const EVENTTYPE_717SUBFRM As UInt32 = &H22 '//ARINC 717 sub frame completed
    Public Const EVENTTYPE_717SYNCERR As UInt32 = &H23    '//ARINC 717 receive channel lost synchronization
    Public Const EVENTTYPE_708MSG As UInt32 = &H31    '//ARINC 708 message
    Public Const EVENTTYPE_SEQFULL As UInt32 = &H41   '//Sequential record full
    Public Const EVENTTYPE_SEQFREQ As UInt32 = &H42   '//Sequential record frequency
    Public Const EVENTTYPE_422TXTHRESHOLD As UInt32 = &H51    '//RS-422 TX under threshold
    Public Const EVENTTYPE_422TXFIFO As UInt32 = &H52 '//RS-422 TX underflow
    Public Const EVENTTYPE_422RXTHRESHOLD As UInt32 = &H53    '//RS-422 RX over threshold
    Public Const EVENTTYPE_422RXFIFO As UInt32 = &H54 '//RS-422 RX overflow
    Public Const EVENTTYPE_422RXERROR As UInt32 = &H55    '//RS-422 RX error
    Public Const EVENTTYPE_CSDBMSG As UInt32 = &H58   '//CSDB message
    Public Const EVENTTYPE_CSDBOPCODE As UInt32 = &H59    '//CSDB event log opcode
    Public Const EVENTTYPE_CSDBHALT As UInt32 = &H5A  '//CSDB schedule halt
    Public Const EVENTTYPE_CSDBPAUSE As UInt32 = &H5B '//CSDB schedule pause
    Public Const EVENTTYPE_CSDBLIST As UInt32 = &H5C  '//CSDB list buffer empty/full
    Public Const EVENTTYPE_CSDBERR As UInt32 = &H5D   '//CSDB decoder error detected
    Public Const EVENTTYPE_CSDBSYNCERR As UInt32 = &H5E   '//CSDB receive channel lost synchronization
    Public Const EVENTTYPE_DIOEDGE As UInt32 = &H60   '//DIO edge event
    Public Const EVENTTYPE_DIOFAULT As UInt32 = &H61  '//DIO fault event
    Public Const EVENTTYPE_BITERROR As UInt32 = &H71  '//Built-in Test error event

    '/**
    '*
    '*  Card Info types
    '*
    '**/

    Public Const INFOTYPE_PLAT As UInt32 = &H1   '//Returns the platform type
    Public Const INFOTYPE_PROD As UInt32 = &H2   '//Returns the product type
    Public Const INFOTYPE_GEN As UInt32 = &H3    '//Returns the generation number
    Public Const INFOTYPE_1553COUNT As UInt32 = &H4  '//Returns the 1553 channel count
    Public Const INFOTYPE_1553SIZE As UInt32 = &H5   '//Returns the 1553 channel size
    Public Const INFOTYPE_429COUNT As UInt32 = &H6   '//Returns the 429 channel count
    Public Const INFOTYPE_429SIZE As UInt32 = &H7    '//Returns the 429 channel size
    Public Const INFOTYPE_717COUNT As UInt32 = &H8   '//Returns the 717 channel count
    Public Const INFOTYPE_717SIZE As UInt32 = &H9    '//Returns the 717 channel size
    Public Const INFOTYPE_708COUNT As UInt32 = &HA   '//Returns the 708 channel count
    Public Const INFOTYPE_708SIZE As UInt32 = &HB    '//Returns the 708 channel size
    Public Const INFOTYPE_VERSION As UInt32 = &HC    '//Returns the version number
    Public Const INFOTYPE_DATE As UInt32 = &HD   '//Returns the version date
    Public Const INFOTYPE_CHINFO As UInt32 = &HE '//Returns the channel info
    Public Const INFOTYPE_422COUNT As UInt32 = &HF   '//Returns the 422 port count
    Public Const INFOTYPE_422SIZE As UInt32 = &H10    '//Returns the 422 port size
    Public Const INFOTYPE_CSDBCOUNT As UInt32 = &H11  '//Returns the CSDB channel count
    Public Const INFOTYPE_CSDBSIZE As UInt32 = &H12   '//Returns the CSDB channel size
    Public Const INFOTYPE_DIOCOUNT As UInt32 = &H13   '//Returns the DIO bank count
    Public Const INFOTYPE_DIOSIZE As UInt32 = &H14    '//Returns the DIO bank size
    Public Const INFOTYPE_HWGEN As UInt32 = &H15  '//Returns the Hardware Generation

    '/**
    '*
    '*  Co-Processor Info types
    '*
    '**/

    Public Const COPROCINFO_PLAT As UInt32 = &H1 '//Returns the platform type
    Public Const COPROCINFO_PROD As UInt32 = &H2 '//Returns the product type
    Public Const COPROCINFO_GEN As UInt32 = &H3  '//Returns the generation number
    Public Const COPROCINFO_VERSION As UInt32 = &H4  '//Returns the version number (major.minor)
    Public Const COPROCINFO_DATE As UInt32 = &H5 '//Returns the version date
    Public Const COPROCINFO_CISADDR As UInt32 = &H6  '//Returns the CIS address
    Public Const COPROCINFO_DMA As UInt32 = &H7  '//Returns whether or not CoProc supports DMA mode
    Public Const COPROCINFO_VERSIONEX As UInt32 = &H9    '//Returns the version number (major.minor.minorminor)

    '/**
    '*
    '*  CIS types
    '*
    '**/

    Public Const CISTYPE_CARD As UInt32 = &H1    '//Select card CIS
    Public Const CISTYPE_IOMODULE As UInt32 = &H2    '//Select I/O module CIS
    Public Const CISTYPE_PLX As UInt32 = &H3 '//Select PLX EEPROM
    Public Const CISTYPE_INFO As UInt32 = &H4    '//Select Info module CIS

    '/**
    '*
    '*  Handle Info types
    '*
    '**/

    Public Const HANDINFO_CORENUM As UInt32 = &H1    '//Returns the Handle Core number

    '/**
    '*
    '*  Trigger flags
    '*
    '**/

    Public Const TRIGMASK_TRIGA As UInt32 = &H1  '//Selects trigger line A
    Public Const TRIGMASK_TRIGB As UInt32 = &H2  '//Selects trigger line B
    Public Const TRIGMASK_TRIGC As UInt32 = &H4  '//Selects trigger line C
    Public Const TRIGVAL_TRIGAOFF As UInt32 = &H0    '//Tests for trigger line A inactive
    Public Const TRIGVAL_TRIGAON As UInt32 = &H1 '//Tests for trigger line A active
    Public Const TRIGVAL_TRIGBOFF As UInt32 = &H0    '//Tests for trigger line B inactive
    Public Const TRIGVAL_TRIGBON As UInt32 = &H2 '//Tests for trigger line B active
    Public Const TRIGVAL_TRIGCOFF As UInt32 = &H0    '//Tests for trigger line C inactive
    Public Const TRIGVAL_TRIGCON As UInt32 = &H4 '//Tests for trigger line C active
    Public Const TRIGPOL_TRIGAL As UInt32 = &H0  '//Sets active low polarity for trigger line A
    Public Const TRIGPOL_TRIGAH As UInt32 = &H1  '//Sets active high polarity for trigger line A
    Public Const TRIGPOL_TRIGBL As UInt32 = &H0  '//Sets active low polarity for trigger line B
    Public Const TRIGPOL_TRIGBH As UInt32 = &H2  '//Sets active high polarity for trigger line B
    Public Const TRIGPOL_TRIGCL As UInt32 = &H0  '//Sets active low polarity for trigger line C
    Public Const TRIGPOL_TRIGCH As UInt32 = &H4  '//Sets active high polarity for trigger line C

    '/**
    '*
    '*  Sync flags
    '*
    '**/

    Public Const SYNCMASK_SYNCA As UInt32 = &H1  '//Selects sync line A
    Public Const SYNCMASK_SYNCB As UInt32 = &H2  '//Selects sync line B
    Public Const SYNCMASK_SYNCC As UInt32 = &H4  '//Selects sync line C
    Public Const SYNCPOL_SYNCAL As UInt32 = &H0  '//Sets active low polarity for sync line A
    Public Const SYNCPOL_SYNCAH As UInt32 = &H1  '//Sets active high polarity for sync line A
    Public Const SYNCPOL_SYNCBL As UInt32 = &H0  '//Sets active low polarity for sync line B
    Public Const SYNCPOL_SYNCBH As UInt32 = &H2  '//Sets active high polarity for sync line B
    Public Const SYNCPOL_SYNCCL As UInt32 = &H0  '//Sets active low polarity for sync line C
    Public Const SYNCPOL_SYNCCH As UInt32 = &H4  '//Sets active high polarity for sync line C

    '/**
    '*
    '*  Heap flags.
    '*
    '**/

    Public Const HEAPCFG_DEFAULT As UInt32 = &H0 '//Block is allocated within page
    Public Const HEAPCFG_TEST As UInt32 = &H1    '//Returns address but doesn't make it permanent
    Public Const HEAPCFG_NULL As UInt32 = &H2    '//Returns address but doesn't mark it as in use
    Public Const HEAPCFG_SPAN As UInt32 = &H4    '//Block can span pages
    Public Const HEAPCFG_QUICK As UInt32 = &H8   '//Does a quick allocation
    Public Const HEAPCFG_NOALIGN As UInt32 = &H10 '//Relaxes alignment rules to help fit
    Public Const HEAPSECT_SRAM As UInt32 = &H0   '//Heap section for primary SRAM

    '/**
    '*
    '*  Timer resolutions.
    '*
    '**/

    Public Const TIMERRESOL_1US As Int32 = 1    '//1us timer resolution 1:11:34 range
    Public Const TIMERRESOL_16US As Int32 = 2   '//16us timer resolution 19:05:19 range
    Public Const TIMERRESOL_1024US As Int32 = 3 '//1024us timer resolution 50 day range

    '/**
    '*
    '*  Timer status.
    '*
    '**/

    Public Const TIMETAG_FORMAT_BIN As Int32 = 0    '//Timetag will be in binary format
    Public Const TIMETAG_FORMAT_BCD As Int32 = 1    '//Timetag will be in BCD format

    '/**
    '*
    '*  Interval calculation modes.
    '*
    '**/

    Public Const INTERVALMODE_CLOSEST As Int32 = 1  '//Finds interval closest to value specified
    Public Const INTERVALMODE_LESS As Int32 = 2 '//Finds closest interval less than value specified
    Public Const INTERVALMODE_GREATER As Int32 = 3  '//Finds closest interval more than value specified

    '/**
    '*
    '*  Test flags.
    '*
    '**/

    Public Const TEST_LEVEL_0 As Int32 = 0  '//Test I/O interface
    Public Const TEST_LEVEL_1 As Int32 = 1  '//Test memory interface
    Public Const TEST_LEVEL_2 As Int32 = 2  '//Test communication process
    Public Const TEST_LEVEL_3 As Int32 = 3  '//Test bus transceiver

    '/**
    '*
    '*  Status flags.
    '*
    '**/

    Public Const STAT_EMPTY As Int32 = 0    '//Buffer is empty
    Public Const STAT_PARTIAL As Int32 = 1  '//Buffer is partially filled
    Public Const STAT_FULL As Int32 = 2 '//Buffer is full
    Public Const STAT_OFF As Int32 = 3  '//Buffer is off

    '/**
    '*
    '*  SysMon flags
    '*
    '**/

    Public Const SYSMONTYPE_NONE As Int32 = 0   '//Sensor not present
    Public Const SYSMONTYPE_TEMP As Int32 = 1   '//Temperature sensor
    Public Const SYSMONTYPE_VOLTAGE As Int32 = 2    '//Voltage sensor
    Public Const SYSMONTYPE_CURRENT As Int32 = 3    '//Current sensor

    '/**
    '*
    '*  SysMon Read Constant
    '*
    '**/

    Public Const SYSMONRD_NOTVALID As Int32 = -1000000  '//SysMon value not available

    '/**
    '*
    '*  BIT flags
    '*
    '**/

    Public Const BITCFG_DEFAULT As UInt32 = &H0  '//Select all default settings
    Public Const BITCFG_MEMECC_ENABLE As UInt32 = &H0    '//Enables Stopping card operation on memory ECC failure  ie uncorrectable error(default)
    Public Const BITCFG_MEMECC_DISABLE As UInt32 = &H1   '//Disables Stopping card operation on memory ECC failure  ie uncorrectable error
    Public Const BITCFG_FPGA_ENABLE As UInt32 = &H0  '//Enables FPGA Single Event Upset (SEU) detection (default)
    Public Const BITCFG_FPGA_DISABLE As UInt32 = &H2 '//Disables FPGA Single Event Upset (SEU) detection
    Public Const BITCFG_PROTOCOL_ENABLE As UInt32 = &H0  '//Enables Protocol error reporting (default)
    Public Const BITCFG_PROTOCOL_DISABLE As UInt32 = &H4 '//Disables Protocol error reporting
    Public Const BITCFG_MEMECC_NOLOG As UInt32 = &H0 '//Do not generate event logs when ECC event occurs (default)
    Public Const BITCFG_MEMECC_LOG As UInt32 = &H10   '//Generate event logs when ECC event occurs
    Public Const BITCFG_FPGA_NOLOG As UInt32 = &H0   '//Do not generate event logs when FPGA Single Event Upset (SEU) event occurs (default)
    Public Const BITCFG_FPGA_LOG As UInt32 = &H20 '//Generate event logs when FPGA Single Event Upset (SEU) event occurs
    Public Const BITCFG_PROTOCOL_NOLOG As UInt32 = &H0   '//Do not generate event logs when Protocol error occurs (default)
    Public Const BITCFG_PROTOCOL_LOG As UInt32 = &H40 '//Generate event logs when Protocol error occurs
    Public Const BITCFG_CARD_STOPPED_NOLOG As UInt32 = &H0   '//Do not generate event logs when the card is stopped due to CBIT error (default)
    Public Const BITCFG_CARD_STOPPED_LOG As UInt32 = &H80 '//Generate event logs when the card is stopped due to CBIT error
    Public Const BITCFG_SYSMON_NOLOG As UInt32 = &H0 '//Do not generate event logs when System Monitor error occurs (default)
    Public Const BITCFG_SYSMON_LOG As UInt32 = &H100   '//Generate event logs when System Monitor error occurs

    Public Const BITSTAT_NOSTATUS As UInt32 = &H0    '//No errors or warnings for BIT
    Public Const BITSTAT_CARD_STOPPED As UInt32 = &H20000000    '//Continuous BIT fatal system error card stopped
    Public Const BITSTAT_CBIT_FPGA_ERR As UInt32 = &H10000000   '//Continuous BIT FPGA error (SEU)
    Public Const BITSTAT_SINGLE_BIT_ERR As UInt32 = &H8000000  '//Continuous BIT Single Bit Error (Correctable)
    Public Const BITSTAT_DOUBLE_BIT_ERR As UInt32 = &H4000000  '//Continuous BIT Double Bit Error
    Public Const BITSTAT_SYSMON_ERR As UInt32 = &HFFFF  '//Continuous BIT System Monitor error
    Public Const BITSTAT_PROTOCOL_ERR As UInt32 = &HFF0000    '//Continuous BIT Protocol Error

    '/**
    '*
    '*  Other flags.
    '*
    '**/

    Public Const RCV As Int32 = 0
    Public Const XMT As Int32 = 1

    '/**
    '*
    '*  Error types.
    '*
    '**/

    Public Const ERR_NONE As Int32 = 0  '//No error
    Public Const ERR_UNKNOWN As Int32 = -1  '//An unexpected error occurred
    Public Const ERR_BADVER As Int32 = -2   '//A bad version was encountered
    Public Const ERR_BADPTR As Int32 = -3   '//A bad pointer was passed
    Public Const ERR_NOCORE As Int32 = -4   '//The specified core number doesn't exist
    Public Const ERR_BADPARAMS As Int32 = -11   '//CardOpen() called with bad parameters
    Public Const ERR_NOHANDLES As Int32 = -12   '//CardOpen() already has allocated too many handles
    Public Const ERR_NOCARD As Int32 = -13  '//CardOpen() could not find a L43 card at the specified address
    Public Const ERR_NOIO As Int32 = -14    '//CardOpen() could not find the I/O ports
    Public Const ERR_NOMEM As Int32 = -15   '//CardOpen() could not find the memory
    Public Const ERR_BAD16BIT As Int32 = -16    '//Card is conflicting with another 16-bit card
    Public Const ERR_WRONGMODEL As Int32 = -17  '//Card does not support this feature
    Public Const ERR_NOSEL As Int32 = -18   '//CardOpen() could not allocate a memory selector
    Public Const ERR_LOCK As Int32 = -19    '//The communication process is locked up
    Public Const ERR_TOOMANY As Int32 = -20 '//Too many channels have been configured
    Public Const ERR_BADHANDLE As Int32 = -21   '//A bad handle was specified
    Public Const ERR_GOODHANDLE As Int32 = -22  '//The handle is still valid and should not be destroyed
    Public Const ERR_NOTCHAN As Int32 = -23 '//Not a valid channel
    Public Const ERR_NOTXMT As Int32 = -24  '//The Transmitter has not been configured
    Public Const ERR_NOTRCV As Int32 = -25  '//The Receiver has not been configured
    Public Const ERR_NOTSEQ As Int32 = -26  '//The Sequential Record has not been configured
    Public Const ERR_ALLOC As Int32 = -27   '//There is not enough memory to allocate
    Public Const ERR_VXD As Int32 = -28 '//An error occurred in the VXD
    Public Const ERR_BADLABEL As Int32 = -29    '//The specified label value is not valid
    Public Const ERR_BADSDI As Int32 = -30  '//The specified sdi value is not valid
    Public Const ERR_BADMSG As Int32 = -31  '//The specified command block is not a message block
    Public Const ERR_BADSCHNDX As Int32 = -32   '//Specified command index is out of range
    Public Const ERR_BUFSIZE As Int32 = -33 '//Insufficient space in user buffer
    Public Const ERR_NOCONFIG As Int32 = -34    '//The card has not been properly configured
    Public Const ERR_CONFLICTS As Int32 = -35   '//Unable to resolve conflicts
    Public Const ERR_RANGE As Int32 = -36   '//Schedule is out of range
    Public Const ERR_FACTOR As Int32 = -37  '//A bad factor value was specified
    Public Const ERR_NOIOBOOT As Int32 = -40    '//Could not talk to IO Boot port of DSP
    Public Const ERR_BOOTFULL As Int32 = -41    '//No space to add boot code
    Public Const ERR_BOOTNUM As Int32 = -42 '//There is no boot code with the specified number
    Public Const ERR_ACCESS As Int32 = -43  '//Unable to write to access register
    Public Const ERR_ROMVERIFY As Int32 = -44   '//Unable to verify the value written to the ROM
    Public Const ERR_COUNT As Int32 = -45   '//An invalid count was specified
    Public Const ERR_CRC As Int32 = -46 '//There was a bad checksum in the HEX file
    Public Const ERR_FNAME As Int32 = -47   '//Bad filenames were specified
    Public Const ERR_FRDWR As Int32 = -48   '//There was an error reading or writing the HEX file
    Public Const ERR_HEX As Int32 = -49 '//There was a bad hex character in the HEX file
    Public Const ERR_INDEX As Int32 = -51   '//The command block index was invalid or the schedule is full
    Public Const ERR_NOMSGS As Int32 = -52  '//No messages specified
    Public Const ERR_TYPE As Int32 = -54    '//There was a bad type value in the HEX file
    Public Const ERR_ZEROLEN As Int32 = -55 '//Zero length was specified
    Public Const ERR_BADADDRESS As Int32 = -56  '//A bad address was specified
    Public Const ERR_MSGNDX As Int32 = -57  '//A bad message index was specified
    Public Const ERR_BADTA As Int32 = -60   '//A bad terminal address was specified
    Public Const ERR_BADFRAME As Int32 = -61    '//A bad frame time was specified
    Public Const ERR_NOTBC As Int32 = -62   '//The BC has not been configured
    Public Const ERR_NOTRT As Int32 = -63   '//The RT has not been configured
    Public Const ERR_NOTMON As Int32 = -64  '//The monitor has not been configured
    Public Const ERR_SELFIOFAIL As Int32 = -71  '//I/O selftest failed
    Public Const ERR_SELFMEMFAIL As Int32 = -72 '//Memory selftest failed
    Public Const ERR_SELFCOMMFAIL As Int32 = -73    '//Communication selftest failed
    Public Const ERR_SELFXMTFAIL As Int32 = -74 '//Transmit selftest failed
    Public Const ERR_PLXBUG As Int32 = -75  '//PLX bug is causing problems
    Public Const ERR_NOTSUPPORTED As Int32 = -76    '//Base class does not support feature
    Public Const ERR_DLL As Int32 = -77 '//A required DLL is missing
    Public Const ERR_SEQTYPE As Int32 = -80 '//Invalid sequential record type value
    Public Const ERR_SEQNEXT As Int32 = -81 '//Next sequential record does not exist
    Public Const ERR_SEQFINDINFO As Int32 = -82 '//The SEQFINDINFO structure is not valid
    Public Const ERR_SEQBASEPTR As Int32 = -83  '//The base pointer passed is invalid
    Public Const ERR_SEQMORE As Int32 = -84 '//More (extended) record data does not exist
    Public Const ERR_TIMEOUT As Int32 = -90 '//Function timed out waiting for data
    Public Const ERR_SUBFRMNUM As Int32 = -101  '//Invalid SubFrame number was specified
    Public Const ERR_WORDNUM As Int32 = -102    '//Invalid Word number was specified
    Public Const ERR_NOTINSYNC As Int32 = -103  '//Not Synchronized to databus
    Public Const ERR_SUPERFRM As Int32 = -104   '//SuperFrame not configured
    Public Const ERR_SUPERFRMNUM As Int32 = -105    '//Invalid SuperFrame number was specified

End Module
