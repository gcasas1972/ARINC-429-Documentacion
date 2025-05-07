Imports System
Imports System.Runtime.InteropServices

Module BTI422VB

    '/**
    '*
    '*  BTI422 WIN32 DRIVER  Version 1.1.2  (03/02/2010)
    '*  Copyright (c) 2004-2010
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   BTI422NET.VB -- 32-bit
    '*                      BTI422 Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  Structs used by the BTI422 Driver.
    '*
    '**/

    '/**
    '*
    '*  BTI422 Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the BTI422 Driver.
    '*
    '**/

    Private Class BTI422_32
        Public Declare Function BTI422_FIFOCheckRx Lib "BTI422.DLL" Alias "_BTI422_FIFOCheckRx@8" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOCheckTx Lib "BTI422.DLL" Alias "_BTI422_FIFOCheckTx@8" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOConfigRx Lib "BTI422.DLL" Alias "_BTI422_FIFOConfigRx@16" (ByVal configval As UInt32, ByVal threshold As Int32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOConfigTx Lib "BTI422.DLL" Alias "_BTI422_FIFOConfigTx@16" (ByVal configval As UInt32, ByVal threshold As Int32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFODataRd Lib "BTI422.DLL" Alias "_BTI422_FIFODataRd@20" (ByRef buf As Byte, ByVal count As Int32, ByRef status As UInt32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFODataWr Lib "BTI422.DLL" Alias "_BTI422_FIFODataWr@20" (ByRef buf As Byte, ByVal count As Int32, ByVal ctrlflags As UInt32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOFlushRx Lib "BTI422.DLL" Alias "_BTI422_FIFOFlushRx@8" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOFlushTx Lib "BTI422.DLL" Alias "_BTI422_FIFOFlushTx@8" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOGapWr Lib "BTI422.DLL" Alias "_BTI422_FIFOGapWr@16" (ByVal gapcount As UInt16, ByVal ctrlflags As UInt32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_ParamAmplitudeConfig Lib "BTI422.DLL" Alias "_BTI422_ParamAmplitudeConfig@16" (ByVal configval As UInt32, ByVal dacval As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_ParamAmplitudeGet Lib "BTI422.DLL" Alias "_BTI422_ParamAmplitudeGet@12" (ByRef dacval As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_PortConfig Lib "BTI422.DLL" Alias "_BTI422_PortConfig@16" (ByVal configval As UInt32, ByVal bitrateflag As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI422_PortGetCount Lib "BTI422.DLL" Alias "_BTI422_PortGetCount@8" (ByRef portcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI422_PortGetInfo Lib "BTI422.DLL" Alias "_BTI422_PortGetInfo@12" (ByVal infotype As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI422_PortIs422 Lib "BTI422.DLL" Alias "_BTI422_PortIs422@8" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_PortStart Lib "BTI422.DLL" Alias "_BTI422_PortStart@8" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_PortStop Lib "BTI422.DLL" Alias "_BTI422_PortStop@8" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_DllUsageCount Lib "BTI422.DLL" Alias "_BTI422_DllUsageCount@0" () As Int32
        Public Declare Function BTI422_PortCreate Lib "BTI422.DLL" Alias "_BTI422_PortCreate@8" (ByVal portnum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI422_PortReset Lib "BTI422.DLL" Alias "_BTI422_PortReset@8" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_TestProtocol Lib "BTI422.DLL" Alias "_BTI422_TestProtocol@4" (ByVal handleval As UInt32) As Int32
    End Class

    Private Class BTI422_64
        Public Declare Function BTI422_FIFOCheckRx Lib "BTI42264.DLL" Alias "BTI422_FIFOCheckRx" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOCheckTx Lib "BTI42264.DLL" Alias "BTI422_FIFOCheckTx" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOConfigRx Lib "BTI42264.DLL" Alias "BTI422_FIFOConfigRx" (ByVal configval As UInt32, ByVal threshold As Int32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOConfigTx Lib "BTI42264.DLL" Alias "BTI422_FIFOConfigTx" (ByVal configval As UInt32, ByVal threshold As Int32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFODataRd Lib "BTI42264.DLL" Alias "BTI422_FIFODataRd" (ByRef buf As Byte, ByVal count As Int32, ByRef status As UInt32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFODataWr Lib "BTI42264.DLL" Alias "BTI422_FIFODataWr" (ByRef buf As Byte, ByVal count As Int32, ByVal ctrlflags As UInt32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOFlushRx Lib "BTI42264.DLL" Alias "BTI422_FIFOFlushRx" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOFlushTx Lib "BTI42264.DLL" Alias "BTI422_FIFOFlushTx" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_FIFOGapWr Lib "BTI42264.DLL" Alias "BTI422_FIFOGapWr" (ByVal gapcount As UInt16, ByVal ctrlflags As UInt32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_ParamAmplitudeConfig Lib "BTI42264.DLL" Alias "BTI422_ParamAmplitudeConfig" (ByVal configval As UInt32, ByVal dacval As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_ParamAmplitudeGet Lib "BTI42264.DLL" Alias "BTI422_ParamAmplitudeGet" (ByRef dacval As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_PortConfig Lib "BTI42264.DLL" Alias "BTI422_PortConfig" (ByVal configval As UInt32, ByVal bitrateflag As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTI422_PortGetCount Lib "BTI42264.DLL" Alias "BTI422_PortGetCount" (ByRef portcount As Int32, ByVal handleval As UInt32)
        Public Declare Function BTI422_PortGetInfo Lib "BTI42264.DLL" Alias "BTI422_PortGetInfo" (ByVal infotype As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI422_PortIs422 Lib "BTI42264.DLL" Alias "BTI422_PortIs422" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_PortStart Lib "BTI42264.DLL" Alias "BTI422_PortStart" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_PortStop Lib "BTI42264.DLL" Alias "BTI422_PortStop" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_DllUsageCount Lib "BTI42264.DLL" Alias "BTI422_DllUsageCount" () As Int32
        Public Declare Function BTI422_PortCreate Lib "BTI42264.DLL" Alias "BTI422_PortCreate" (ByVal portnum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTI422_PortReset Lib "BTI42264.DLL" Alias "BTI422_PortReset" (ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTI422_TestProtocol Lib "BTI42264.DLL" Alias "BTI422_TestProtocol" (ByVal handleval As UInt32) As Int32
    End Class

    Public Function BTI422_FIFOCheckRx(ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_FIFOCheckRx(portnum, handleval)
        Else
            Return BTI422_64.BTI422_FIFOCheckRx(portnum, handleval)
        End If
    End Function
    Public Function BTI422_FIFOCheckTx(ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_FIFOCheckTx(portnum, handleval)
        Else
            Return BTI422_64.BTI422_FIFOCheckTx(portnum, handleval)
        End If
    End Function
    Public Function BTI422_FIFOConfigRx(ByVal configval As UInt32, ByVal threshold As Int32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_FIFOConfigRx(configval, threshold, portnum, handleval)
        Else
            Return BTI422_64.BTI422_FIFOConfigRx(configval, threshold, portnum, handleval)
        End If
    End Function
    Public Function BTI422_FIFOConfigTx(ByVal configval As UInt32, ByVal threshold As Int32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_FIFOConfigTx(configval, threshold, portnum, handleval)
        Else
            Return BTI422_64.BTI422_FIFOConfigTx(configval, threshold, portnum, handleval)
        End If
    End Function
    Public Function BTI422_FIFODataRd(ByRef buf As Byte, ByVal count As Int32, ByRef status As UInt32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_FIFODataRd(buf, count, status, portnum, handleval)
        Else
            Return BTI422_64.BTI422_FIFODataRd(buf, count, status, portnum, handleval)
        End If
    End Function
    Public Function BTI422_FIFODataWr(ByRef buf As Byte, ByVal count As Int32, ByVal ctrlflags As UInt32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_FIFODataWr(buf, count, ctrlflags, portnum, handleval)
        Else
            Return BTI422_64.BTI422_FIFODataWr(buf, count, ctrlflags, portnum, handleval)
        End If
    End Function
    Public Function BTI422_FIFOFlushRx(ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_FIFOFlushRx(portnum, handleval)
        Else
            Return BTI422_64.BTI422_FIFOFlushRx(portnum, handleval)
        End If
    End Function
    Public Function BTI422_FIFOFlushTx(ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_FIFOFlushTx(portnum, handleval)
        Else
            Return BTI422_64.BTI422_FIFOFlushTx(portnum, handleval)
        End If
    End Function
    Public Function BTI422_FIFOGapWr(ByVal gapcount As UInt16, ByVal ctrlflags As UInt32, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_FIFOGapWr(gapcount, ctrlflags, portnum, handleval)
        Else
            Return BTI422_64.BTI422_FIFOGapWr(gapcount, ctrlflags, portnum, handleval)
        End If
    End Function
    Public Function BTI422_ParamAmplitudeConfig(ByVal configval As UInt32, ByVal dacval As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_ParamAmplitudeConfig(configval, dacval, portnum, handleval)
        Else
            Return BTI422_64.BTI422_ParamAmplitudeConfig(configval, dacval, portnum, handleval)
        End If
    End Function
    Public Function BTI422_ParamAmplitudeGet(ByRef dacval As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_ParamAmplitudeGet(dacval, portnum, handleval)
        Else
            Return BTI422_64.BTI422_ParamAmplitudeGet(dacval, portnum, handleval)
        End If
    End Function
    Public Function BTI422_PortConfig(ByVal configval As UInt32, ByVal bitrateflag As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_PortConfig(configval, bitrateflag, portnum, handleval)
        Else
            Return BTI422_64.BTI422_PortConfig(configval, bitrateflag, portnum, handleval)
        End If
    End Function
    Public Sub BTI422_PortGetCount(ByRef portcount As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTI422_32.BTI422_PortGetCount(portcount, handleval)
        Else
            BTI422_64.BTI422_PortGetCount(portcount, handleval)
        End If
    End Sub
    Public Function BTI422_PortGetInfo(ByVal infotype As UInt16, ByVal portnum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_PortGetInfo(infotype, portnum, handleval)
        Else
            Return BTI422_64.BTI422_PortGetInfo(infotype, portnum, handleval)
        End If
    End Function
    Public Function BTI422_PortIs422(ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_PortIs422(portnum, handleval)
        Else
            Return BTI422_64.BTI422_PortIs422(portnum, handleval)
        End If
    End Function
    Public Function BTI422_PortStart(ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_PortStart(portnum, handleval)
        Else
            Return BTI422_64.BTI422_PortStart(portnum, handleval)
        End If
    End Function
    Public Function BTI422_PortStop(ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_PortStop(portnum, handleval)
        Else
            Return BTI422_64.BTI422_PortStop(portnum, handleval)
        End If
    End Function
    Public Function BTI422_DllUsageCount() As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_DllUsageCount
        Else
            Return BTI422_64.BTI422_DllUsageCount
        End If
    End Function
    Public Function BTI422_PortCreate(ByVal portnum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_PortCreate(portnum, handleval)
        Else
            Return BTI422_64.BTI422_PortCreate(portnum, handleval)
        End If
    End Function
    Public Function BTI422_PortReset(ByVal portnum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_PortReset(portnum, handleval)
        Else
            Return BTI422_64.BTI422_PortReset(portnum, handleval)
        End If
    End Function
    Public Function BTI422_TestProtocol(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTI422_32.BTI422_TestProtocol(handleval)
        Else
            Return BTI422_64.BTI422_TestProtocol(handleval)
        End If
    End Function

    '/**
    '*
    '*  Port number constants
    '*
    '**/

    Public Const PORT0 As UInt16 = &H0   '//Port 0
    Public Const PORT1 As UInt16 = &H1   '//Port 1
    Public Const PORT2 As UInt16 = &H2   '//Port 2
    Public Const PORT3 As UInt16 = &H3   '//Port 3
    Public Const PORT4 As UInt16 = &H4   '//Port 4
    Public Const PORT5 As UInt16 = &H5   '//Port 5
    Public Const PORT6 As UInt16 = &H6   '//Port 6
    Public Const PORT7 As UInt16 = &H7   '//Port 7
    Public Const PORT8 As UInt16 = &H8   '//Port 8
    Public Const PORT9 As UInt16 = &H9   '//Port 9
    Public Const PORT10 As UInt16 = &HA  '//Port 10
    Public Const PORT11 As UInt16 = &HB  '//Port 11
    Public Const PORT12 As UInt16 = &HC  '//Port 12
    Public Const PORT13 As UInt16 = &HD  '//Port 13
    Public Const PORT14 As UInt16 = &HE  '//Port 14
    Public Const PORT15 As UInt16 = &HF  '//Port 15
    Public Const PORT16 As UInt16 = &H10  '//Port 16
    Public Const PORT17 As UInt16 = &H11  '//Port 17
    Public Const PORT18 As UInt16 = &H12  '//Port 18
    Public Const PORT19 As UInt16 = &H13  '//Port 19
    Public Const PORT20 As UInt16 = &H14  '//Port 20
    Public Const PORT21 As UInt16 = &H15  '//Port 21
    Public Const PORT22 As UInt16 = &H16  '//Port 22
    Public Const PORT23 As UInt16 = &H17  '//Port 23
    Public Const PORT24 As UInt16 = &H18  '//Port 24
    Public Const PORT25 As UInt16 = &H19  '//Port 25
    Public Const PORT26 As UInt16 = &H1A  '//Port 26
    Public Const PORT27 As UInt16 = &H1B  '//Port 27
    Public Const PORT28 As UInt16 = &H1C  '//Port 28
    Public Const PORT29 As UInt16 = &H1D  '//Port 29
    Public Const PORT30 As UInt16 = &H1E  '//Port 30
    Public Const PORT31 As UInt16 = &H1F  '//Port 31

    '/**
    '*
    '*  Bitrate configuration options
    '*
    '**/

    Public Const BITRATE422_CLK1 As UInt16 = &H8000 '//CLK1, 20 MHz (default)
    Public Const BITRATE422_CLK2 As UInt16 = &H0 '//CLK2, 9.216 MHz (standard option)
    Public Const BITRATE422_XMTSLOPEHIGH As UInt16 = &H0 '//Transmit with high speed slope (default)
    Public Const BITRATE422_XMTSLOPELOW As UInt16 = &H4000  '//Transmit with low speed slope

    '// These defines assume an external clock of 9.216 MHz
    Public Const BITRATE422_921600BPS As UInt16 = &H0    '//External Clock, Div = 0
    Public Const BITRATE422_460800BPS As UInt16 = &H1    '//External Clock, Div = 1
    Public Const BITRATE422_230400BPS As UInt16 = &H3    '//External Clock, Div = 3
    Public Const BITRATE422_115200BPS As UInt16 = &H7    '//External Clock, Div = 7
    Public Const BITRATE422_57600BPS As UInt16 = &HF '//External Clock, Div = 15
    Public Const BITRATE422_38400BPS As UInt16 = &H17 '//External Clock, Div = 23
    Public Const BITRATE422_28800BPS As UInt16 = &H1F '//External Clock, Div = 31
    Public Const BITRATE422_19200BPS As UInt16 = &H2F '//External Clock, Div = 47
    Public Const BITRATE422_14400BPS As UInt16 = &H3F '//External Clock, Div = 63
    Public Const BITRATE422_9600BPS As UInt16 = &H5F  '//External Clock, Div = 95
    Public Const BITRATE422_7200BPS As UInt16 = &H7F  '//External Clock, Div = 127
    Public Const BITRATE422_4800BPS As UInt16 = &HBF  '//External Clock, Div = 191
    Public Const BITRATE422_3600BPS As UInt16 = &HFF  '//External Clock, Div = 255
    Public Const BITRATE422_2400BPS As UInt16 = &H17F  '//External Clock, Div = 383
    Public Const BITRATE422_1800BPS As UInt16 = &H1FF  '//External Clock, Div = 511
    Public Const BITRATE422_1200BPS As UInt16 = &H2FF  '//External Clock, Div = 767
    Public Const BITRATE422_900BPS As UInt16 = &H3FF   '//External Clock, Div = 1023
    Public Const BITRATE422_600BPS As UInt16 = &H5FF   '//External Clock, Div = 1535
    Public Const BITRATE422_300BPS As UInt16 = &HBFF   '//External Clock, Div = 3071

    Public Const BITRATE422_1000000BPS As UInt16 = &H8001   '//Internal Clock, Div = 1
    Public Const BITRATE422_500000BPS As UInt16 = &H8003    '//Internal Clock, Div = 3
    Public Const BITRATE422_400000BPS As UInt16 = &H8004    '//Internal Clock, Div = 4
    Public Const BITRATE422_250000BPS As UInt16 = &H8007    '//Internal Clock, Div = 7
    Public Const BITRATE422_200000BPS As UInt16 = &H8009    '//Internal Clock, Div = 9
    Public Const BITRATE422_100000BPS As UInt16 = &H8013    '//Internal Clock, Div = 19
    Public Const BITRATE422_80000BPS As UInt16 = &H8018 '//Internal Clock, Div = 24
    Public Const BITRATE422_50000BPS As UInt16 = &H8027 '//Internal Clock, Div = 39
    Public Const BITRATE422_40000BPS As UInt16 = &H8031 '//Internal Clock, Div = 49
    Public Const BITRATE422_25000BPS As UInt16 = &H804F '//Internal Clock, Div = 79
    Public Const BITRATE422_20000BPS As UInt16 = &H8063 '//Internal Clock, Div = 99
    Public Const BITRATE422_12500BPS As UInt16 = &H809F '//Internal Clock, Div = 159
    Public Const BITRATE422_10000BPS As UInt16 = &H80C7 '//Internal Clock, Div = 199

    '/**
    '*
    '*  Port configuration options
    '*
    '**/

    Public Const PORTCFG422_DEFAULT As UInt32 = &H0  '//Select all default settings (XMT & RCV) (default)
    Public Const PORTCFG422_RCVALL As UInt32 = &H0   '//Recieve all data (RCV) (default)
    Public Const PORTCFG422_RCVGOOD As UInt32 = &H40000000  '//Receive only error free data (RCV)
    Public Const PORTCFG422_SELFTEST As UInt32 = &H4 '//Enable internal wraparound (XMT & RCV)
    Public Const PORTCFG422_SELFTESTOFF As UInt32 = &H0  '//Disable internal wraparound (XMT & RCV) (default)
    Public Const PORTCFG422_ACTIVE As UInt32 = &H0   '//Enable channel activity (XMT & RCV) (default)
    Public Const PORTCFG422_INACTIVE As UInt32 = &H40 '//Disable channel activity (XMT & RCV)
    Public Const PORTCFG422_PARITYNONE As UInt32 = &H0   '//Disable parity (XMT & RCV) (default)
    Public Const PORTCFG422_PARITYODD As UInt32 = &H800000    '//Enable odd parity (XMT & RCV)
    Public Const PORTCFG422_PARITYEVEN As UInt32 = &H400000   '//Enable even parity (XMT & RCV)
    Public Const PORTCFG422_PARITYMARK As UInt32 = &H200000   '//Force set parity (XMT & RCV)
    Public Const PORTCFG422_PARITYSPACE As UInt32 = &H100000  '//Force clear parity (XMT & RCV)
    Public Const PORTCFG422_BUSINVERT As UInt32 = 2147483648    '//Enable bus polarity inversion (XMT & RCV)
    Public Const PORTCFG422_BUSINVERTOFF As UInt32 = &H0 '//Disable bus polarity inversion (XMT & RCV) (default)
    Public Const PORTCFG422_MODE232 As UInt32 = &H8000000  '//Enable RS-232 / RS-423 mode (unbalanced) (XMT)
    Public Const PORTCFG422_MODE422 As UInt32 = &H0  '//Enable RS-422 mode (balanced) (XMT) (default)

    '/**
    '*
    '*  FIFO configuration options
    '*
    '**/

    Public Const FIFOCFG422_DEFAULT As UInt32 = &H0  '//Select all default settings
    Public Const FIFOCFG422_NONE As UInt32 = &H0 '//Disable FIFO Events (default)
    Public Const FIFOCFG422_TXTHRESHOLD As UInt32 = &H1  '//Enable Transmit FIFO Threshold Event
    Public Const FIFOCFG422_TXEMPTY As UInt32 = &H2  '//Enable Transmit FIFO Empty Event
    Public Const FIFOCFG422_RXTHRESHOLD As UInt32 = &H4  '//Enable Receive FIFO Threshold Event
    Public Const FIFOCFG422_RXFULL As UInt32 = &H8   '//Enable Receive FIFO Full Event
    Public Const FIFOCFG422_RXERROR As UInt32 = &H10  '//Enable Receive Error Event

    '/**
    '*
    '*  FIFO word configuration options
    '*
    '**/

    Public Const WRDCFG422_DEFAULT As UInt32 = &H0   '//Select all default settings
    Public Const WRDCFG422_GAPEN As UInt32 = &H8000 '//Enable the use of data as gap
    Public Const WRDCFG422_GAPENOFF As UInt32 = &H0  '//Disable the use of data as gap (default)
    Public Const WRDCFG422_FRAMEERR As UInt32 = &H1000  '//Enable Frame Error
    Public Const WRDCFG422_FRAMEERROFF As UInt32 = &H0   '//Disable Frame Error (default)
    Public Const WRDCFG422_PARERR As UInt32 = &H800    '//Enable Parity Error
    Public Const WRDCFG422_PARERROFF As UInt32 = &H0 '//Disable Parity Error (default)
    Public Const WRDCFG422_ATOMIC As UInt32 = 2147483648    '//Enable atomic FIFO access
    Public Const WRDCFG422_ATOMICOFF As UInt32 = &H0 '//Disable atomic FIFO access (default)

    '/**
    '*
    '*  FIFO gap configuration options
    '*
    '**/

    Public Const GAPCFG422_DEFAULT As UInt32 = &H0   '//Select all default settings

    '/**
    '*
    '*  Bit fields of the FIFO status flags.
    '*
    '**/

    Public Const WRDSTAT422_ANYERR As UInt32 = &H20   '//Any error
    Public Const WRDSTAT422_BITERR As UInt32 = &H10   '//Any bit error
    Public Const WRDSTAT422_NRZERR As UInt32 = &H8   '//Bit error (NRZ)
    Public Const WRDSTAT422_EDGEERR As UInt32 = &H4  '//Bit error (Edge)
    Public Const WRDSTAT422_PARERR As UInt32 = &H2   '//Parity error
    Public Const WRDSTAT422_FRAMEERR As UInt32 = &H1 '//Frame error

    '/**
    '*
    '*  Parametric configuration options
    '*
    '**/

    Public Const PARAMCFG422_DEFAULT As UInt32 = &H0 '//Select all default settings (default)
    Public Const PARAMCFG422_AMPLON As UInt32 = &H0  '//Enables parametric amplitude control (default)
    Public Const PARAMCFG422_AMPLOFF As UInt32 = &H1 '//Disables parametric amplitude control

    '/**
    '*
    '*  Channel info fields.
    '*
    '**/

    Public Const INFO422_PARAM As UInt32 = &H1   '//Channel supports parametric control

End Module
