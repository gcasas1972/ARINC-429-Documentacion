Imports System
Imports System.Runtime.InteropServices

Module BTIDIOVB

    '/**
    '*
    '*  BTIDIO WIN32 DRIVER  Version 1.1.2  (03/02/2010)
    '*  Copyright (c) 2005-2010
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   BTIDIONET.VB -- 32-bit
    '*                      BTIDIO Driver Include Header File.
    '*
    '**/

    '/**
    '*
    '*  BTIDIO Driver functions.
    '*
    '**/

    '/**
    '*
    '*  Internal functions used by the BTIDIO Driver.
    '*
    '**/

    Private Class BTIDIO_32
        Public Declare Function BTIDIO_BankConfig Lib "BTIDIO.DLL" Alias "_BTIDIO_BankConfig@20" (ByVal configval As UInt32, ByVal threshold As UInt16, ByVal samplerate As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTIDIO_BankFaultClr Lib "BTIDIO.DLL" Alias "_BTIDIO_BankFaultClr@12" (ByVal mask As Byte, ByVal banknum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTIDIO_BankFaultRd Lib "BTIDIO.DLL" Alias "_BTIDIO_BankFaultRd@8" (ByVal banknum As Int32, ByVal handleval As UInt32) As Byte
        Public Declare Function BTIDIO_BankIsDIO Lib "BTIDIO.DLL" Alias "_BTIDIO_BankIsDIO@8" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankRd Lib "BTIDIO.DLL" Alias "_BTIDIO_BankRd@8" (ByVal banknum As Int32, ByVal handleval As UInt32) As Byte
        Public Declare Function BTIDIO_BankStart Lib "BTIDIO.DLL" Alias "_BTIDIO_BankStart@8" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankStop Lib "BTIDIO.DLL" Alias "_BTIDIO_BankStop@8" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankWr Lib "BTIDIO.DLL" Alias "_BTIDIO_BankWr@12" (ByVal value As Byte, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankWrMask Lib "BTIDIO.DLL" Alias "_BTIDIO_BankWrMask@16" (ByVal value As Byte, ByVal mask As Byte, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_DiscreteConfig Lib "BTIDIO.DLL" Alias "_BTIDIO_DiscreteConfig@16" (ByVal configval As UInt32, ByVal ionum As Int32, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_DiscreteRd Lib "BTIDIO.DLL" Alias "_BTIDIO_DiscreteRd@12" (ByVal ionum As Int32, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_DiscreteWr Lib "BTIDIO.DLL" Alias "_BTIDIO_DiscreteWr@16" (ByVal value As Int32, ByVal ionum As Int32, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankClear Lib "BTIDIO.DLL" Alias "_BTIDIO_BankClear@8" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankGetCount Lib "BTIDIO.DLL" Alias "_BTIDIO_BankGetCount@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankGetInfo Lib "BTIDIO.DLL" Alias "_BTIDIO_BankGetInfo@12" (ByVal infotype As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTIDIO_BankGetSampleRate Lib "BTIDIO.DLL" Alias "_BTIDIO_BankGetSampleRate@8" (ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTIDIO_BankGetThreshold Lib "BTIDIO.DLL" Alias "_BTIDIO_BankGetThreshold@8" (ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTIDIO_BankSetSampleRate Lib "BTIDIO.DLL" Alias "_BTIDIO_BankSetSampleRate@12" (ByVal samplerate As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTIDIO_BankSetThreshold Lib "BTIDIO.DLL" Alias "_BTIDIO_BankSetThreshold@12" (ByVal threshold As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTIDIO_DiscreteGetCount Lib "BTIDIO.DLL" Alias "_BTIDIO_DiscreteGetCount@8" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_DllUsageCount Lib "BTIDIO.DLL" Alias "_BTIDIO_DllUsageCount@0" () As Int32
        Public Declare Function BTIDIO_GetBankCount Lib "BTIDIO.DLL" Alias "_BTIDIO_GetBankCount@4" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_IsBank Lib "BTIDIO.DLL" Alias "_BTIDIO_IsBank@8" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_TestProtocol Lib "BTIDIO.DLL" Alias "_BTIDIO_TestProtocol@4" (ByVal handleval As UInt32) As Int32
    End Class

    Private Class BTIDIO_64
        Public Declare Function BTIDIO_BankConfig Lib "BTIDIO64.DLL" Alias "BTIDIO_BankConfig" (ByVal configval As UInt32, ByVal threshold As UInt16, ByVal samplerate As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Sub BTIDIO_BankFaultClr Lib "BTIDIO64.DLL" Alias "BTIDIO_BankFaultClr" (ByVal mask As Byte, ByVal banknum As Int32, ByVal handleval As UInt32)
        Public Declare Function BTIDIO_BankFaultRd Lib "BTIDIO64.DLL" Alias "BTIDIO_BankFaultRd" (ByVal banknum As Int32, ByVal handleval As UInt32) As Byte
        Public Declare Function BTIDIO_BankIsDIO Lib "BTIDIO64.DLL" Alias "BTIDIO_BankIsDIO" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankRd Lib "BTIDIO64.DLL" Alias "BTIDIO_BankRd" (ByVal banknum As Int32, ByVal handleval As UInt32) As Byte
        Public Declare Function BTIDIO_BankStart Lib "BTIDIO64.DLL" Alias "BTIDIO_BankStart" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankStop Lib "BTIDIO64.DLL" Alias "BTIDIO_BankStop" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankWr Lib "BTIDIO64.DLL" Alias "BTIDIO_BankWr" (ByVal value As Byte, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankWrMask Lib "BTIDIO64.DLL" Alias "BTIDIO_BankWrMask" (ByVal value As Byte, ByVal mask As Byte, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_DiscreteConfig Lib "BTIDIO64.DLL" Alias "BTIDIO_DiscreteConfig" (ByVal configval As UInt32, ByVal ionum As Int32, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_DiscreteRd Lib "BTIDIO64.DLL" Alias "BTIDIO_DiscreteRd" (ByVal ionum As Int32, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_DiscreteWr Lib "BTIDIO64.DLL" Alias "BTIDIO_DiscreteWr" (ByVal value As Int32, ByVal ionum As Int32, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankClear Lib "BTIDIO64.DLL" Alias "BTIDIO_BankClear" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankGetCount Lib "BTIDIO64.DLL" Alias "BTIDIO_BankGetCount" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_BankGetInfo Lib "BTIDIO64.DLL" Alias "BTIDIO_BankGetInfo" (ByVal infotype As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As UInt32
        Public Declare Function BTIDIO_BankGetSampleRate Lib "BTIDIO64.DLL" Alias "BTIDIO_BankGetSampleRate" (ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTIDIO_BankGetThreshold Lib "BTIDIO64.DLL" Alias "BTIDIO_BankGetThreshold" (ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTIDIO_BankSetSampleRate Lib "BTIDIO64.DLL" Alias "BTIDIO_BankSetSampleRate" (ByVal samplerate As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTIDIO_BankSetThreshold Lib "BTIDIO64.DLL" Alias "BTIDIO_BankSetThreshold" (ByVal threshold As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        Public Declare Function BTIDIO_DiscreteGetCount Lib "BTIDIO64.DLL" Alias "BTIDIO_DiscreteGetCount" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_DllUsageCount Lib "BTIDIO64.DLL" Alias "BTIDIO_DllUsageCount" () As Int32
        Public Declare Function BTIDIO_GetBankCount Lib "BTIDIO64.DLL" Alias "BTIDIO_GetBankCount" (ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_IsBank Lib "BTIDIO64.DLL" Alias "BTIDIO_IsBank" (ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        Public Declare Function BTIDIO_TestProtocol Lib "BTIDIO64.DLL" Alias "BTIDIO_TestProtocol" (ByVal handleval As UInt32) As Int32
    End Class

    Public Function BTIDIO_BankConfig(ByVal configval As UInt32, ByVal threshold As UInt16, ByVal samplerate As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankConfig(configval, threshold, samplerate, banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankConfig(configval, threshold, samplerate, banknum, handleval)
        End If
    End Function
    Public Sub BTIDIO_BankFaultClr(ByVal mask As Byte, ByVal banknum As Int32, ByVal handleval As UInt32)
        If (IntPtr.Size = 4) Then
            BTIDIO_32.BTIDIO_BankFaultClr(mask, banknum, handleval)
        Else
            BTIDIO_64.BTIDIO_BankFaultClr(mask, banknum, handleval)
        End If
    End Sub
    Public Function BTIDIO_BankFaultRd(ByVal banknum As Int32, ByVal handleval As UInt32) As Byte
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankFaultRd(banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankFaultRd(banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankIsDIO(ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankIsDIO(banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankIsDIO(banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankRd(ByVal banknum As Int32, ByVal handleval As UInt32) As Byte
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankRd(banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankRd(banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankStart(ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankStart(banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankStart(banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankStop(ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankStop(banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankStop(banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankWr(ByVal value As Byte, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankWr(value, banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankWr(value, banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankWrMask(ByVal value As Byte, ByVal mask As Byte, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankWrMask(value, mask, banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankWrMask(value, mask, banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_DiscreteConfig(ByVal configval As UInt32, ByVal ionum As Int32, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_DiscreteConfig(configval, ionum, banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_DiscreteConfig(configval, ionum, banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_DiscreteRd(ByVal ionum As Int32, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_DiscreteRd(ionum, banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_DiscreteRd(ionum, banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_DiscreteWr(ByVal value As Int32, ByVal ionum As Int32, ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_DiscreteWr(value, ionum, banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_DiscreteWr(value, ionum, banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankClear(ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankClear(banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankClear(banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankGetCount(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankGetCount(handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankGetCount(handleval)
        End If
    End Function
    Public Function BTIDIO_BankGetInfo(ByVal infotype As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As UInt32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankGetInfo(infotype, banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankGetInfo(infotype, banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankGetSampleRate(ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankGetSampleRate(banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankGetSampleRate(banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankGetThreshold(ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankGetThreshold(banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankGetThreshold(banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankSetSampleRate(ByVal samplerate As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankSetSampleRate(samplerate, banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankSetSampleRate(samplerate, banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_BankSetThreshold(ByVal threshold As UInt16, ByVal banknum As Int32, ByVal handleval As UInt32) As UInt16
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_BankSetThreshold(threshold, banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_BankSetThreshold(threshold, banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_DiscreteGetCount(ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_DiscreteGetCount(banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_DiscreteGetCount(banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_DllUsageCount() As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_DllUsageCount
        Else
            Return BTIDIO_64.BTIDIO_DllUsageCount
        End If
    End Function
    Public Function BTIDIO_GetBankCount(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_GetBankCount(handleval)
        Else
            Return BTIDIO_64.BTIDIO_GetBankCount(handleval)
        End If
    End Function
    Public Function BTIDIO_IsBank(ByVal banknum As Int32, ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_IsBank(banknum, handleval)
        Else
            Return BTIDIO_64.BTIDIO_IsBank(banknum, handleval)
        End If
    End Function
    Public Function BTIDIO_TestProtocol(ByVal handleval As UInt32) As Int32
        If (IntPtr.Size = 4) Then
            Return BTIDIO_32.BTIDIO_TestProtocol(handleval)
        Else
            Return BTIDIO_64.BTIDIO_TestProtocol(handleval)
        End If
    End Function

    '/**
    '*
    '*  Bank number constants
    '*
    '**/

    Public Const BANKA As UInt16 = &H0   '//Bank A
    Public Const BANKB As UInt16 = &H1   '//Bank B
    Public Const BANKC As UInt16 = &H2   '//Bank C
    Public Const BANKD As UInt16 = &H3   '//Bank D

    '/**
    '*
    '*  Bank configuration options
    '*
    '**/

    Public Const BANKCFGDIO_DEFAULT As UInt32 = &H0  '//Select all default settings (in & out) (default)
    Public Const BANKCFGDIO_INPUT As UInt32 = &H0    '//Select input mode (in) (default)
    Public Const BANKCFGDIO_OUTPUT As UInt32 = &H1   '//Select output mode (out)
    Public Const BANKCFGDIO_INOUT As UInt32 = &H2    '//Select concurrent input and output mode (in & out)
    Public Const BANKCFGDIO_SERIES As UInt32 = &H0   '//Select series mode (in) (default)
    Public Const BANKCFGDIO_SHUNT As UInt32 = &H4    '//Select shunt mode (in)
    Public Const BANKCFGDIO_POLIN_INVOFF As UInt32 = &H0 '//Disable polarity inversion for bank input (in) (default)
    Public Const BANKCFGDIO_POLIN_INV As UInt32 = &H100    '//Enable polarity inversion for bank input (in)
    Public Const BANKCFGDIO_POLOUT_INVOFF As UInt32 = &H0    '//Disable polarity inversion for bank output (out) (default)
    Public Const BANKCFGDIO_POLOUT_INV As UInt32 = &H200   '//Enable polarity inversion for bank output (out)
    Public Const BANKCFGDIO_ACTIVE As UInt32 = &H0   '//Enable bank activity (in & out) (default)
    Public Const BANKCFGDIO_INACTIVE As UInt32 = &H10 '//Disables bank activity (in & out)
    Public Const BANKCFGDIO_SEQSEL As UInt32 = &H0   '//Sequential monitoring of selected transitions (in & out) (default)
    Public Const BANKCFGDIO_SEQALL As UInt32 = &H20   '//Every transition will be recorded in the Sequential Record (in & out)
    Public Const BANKCFGDIO_NOLOGFAULT As UInt32 = &H0   '//No entry will be made in the Event Log List when an output detects a fault (out) (default)
    Public Const BANKCFGDIO_LOGFAULT As UInt32 = &H40 '//An entry will be made in the Event Log List when an output detects a fault (out)
    Public Const BANKCFGDIO_NOLOGEDGE As UInt32 = &H0    '//No entry will be made in the Event Log List when an input detects an edge (in) (default)
    Public Const BANKCFGDIO_LOGEDGE As UInt32 = &H80  '//An entry will be made in the Event Log List when an input detects an edge (in)
    Public Const BANKCFGDIO_LOGALL As UInt32 = &HC0   '//An entry will be made in the Event Log List when an input detects an edge and when an output detects a fault (in & out)

    Public Const THRESHOLDDIO_TTL As UInt32 = &HF0    '//Corresponds to a 1.4V switching threshold (TTL)
    Public Const THRESHOLDDIO_CMOS As UInt32 = &H1B0   '//Corresponds to a 2.5V switching threshold (CMOS)
    Public Const THRESHOLDDIO_1_4V As UInt32 = &HF0   '//Corresponds to a 1.4V switching threshold
    Public Const THRESHOLDDIO_2_5V As UInt32 = &H1B0   '//Corresponds to a 2.5V switching threshold
    Public Const THRESHOLDDIO_5V As UInt32 = &H370 '//Corresponds to a 5V switching threshold
    Public Const THRESHOLDDIO_7V As UInt32 = &H4D0 '//Corresponds to a 7V switching threshold
    Public Const THRESHOLDDIO_12V As UInt32 = &H850    '//Corresponds to a 12V switching threshold
    Public Const THRESHOLDDIO_16V As UInt32 = &HB10    '//Corresponds to a 16V switching threshold
    Public Const THRESHOLDDIO_10KOHM As UInt32 = &HF0 '//Corresponds to approx. 10kOhm switching threshold (Shunt)
    Public Const THRESHOLDDIO_25KOHM As UInt32 = &H1B0 '//Corresponds to approx. 25kOhm switching threshold (Shunt)
    Public Const THRESHOLDDIO_100KOHM As UInt32 = &H300    '//Corresponds to approx. 100kOhm switching threshold (Shunt)

    Public Const SAMPLERATEDIO_US As UInt32 = &H0    '//Corresponds to a 1us base sample clock
    Public Const SAMPLERATEDIO_MS As UInt32 = &H8000    '//Corresponds to a 1ms base sample clock

    '/**
    '*
    '*  Discrete configuration options
    '*
    '**/

    Public Const DISCCFGDIO_DEFAULT As UInt32 = &H0  '//Select all default settings (in & out) (default)
    Public Const DISCCFGDIO_INPUT As UInt32 = &H0    '//Select input mode (in) (default)
    Public Const DISCCFGDIO_OUTPUT As UInt32 = &H1   '//Select output mode (out)
    Public Const DISCCFGDIO_INOUT As UInt32 = &H2    '//Select concurrent input and output mode (in & out)
    Public Const DISCCFGDIO_POLIN_INVOFF As UInt32 = &H0 '//Disable polarity inversion for input (in) (default)
    Public Const DISCCFGDIO_POLIN_INV As UInt32 = &H4    '//Enable polarity inversion for input (in)
    Public Const DISCCFGDIO_POLOUT_INVOFF As UInt32 = &H0    '//Disable polarity inversion for output (out) (default)
    Public Const DISCCFGDIO_POLOUT_INV As UInt32 = &H8   '//Enable polarity inversion for output (out)
    Public Const DISCCFGDIO_SEQNONE As UInt32 = &H0  '//No transitions for this input will be recorded in the Sequential Record (in & out) (default)
    Public Const DISCCFGDIO_SEQPOSEDGE As UInt32 = &H10   '//Positive transitions for this input will be recorded in the Sequential Record (in & out)
    Public Const DISCCFGDIO_SEQNEGEDGE As UInt32 = &H20   '//Negative transitions for this input will be recorded in the Sequential Record (in & out)
    Public Const DISCCFGDIO_SEQANYEDGE As UInt32 = &H30   '//Every transition for this input will be recorded in the Sequential Record (in & out)
    Public Const DISCCFGDIO_NOLOGEDGE As UInt32 = &H0    '//No transitions for this input will create an entry in the Event Log List (in & out) (default)
    Public Const DISCCFGDIO_LOGPOSEDGE As UInt32 = &H40   '//Positive transitions for this input will create an entry in the Event Log List (in & out)
    Public Const DISCCFGDIO_LOGNEGEDGE As UInt32 = &H80   '//Negative transitions for this input will create an entry in the Event Log List (in & out)
    Public Const DISCCFGDIO_LOGANYEDGE As UInt32 = &HC0   '//Every transition for this input will create an entry in the Event Log List (in & out)
    Public Const DISCCFGDIO_NOLOGFAULT As UInt32 = &H0   '//No faults for this output will create an entry in the Event Log List (out) (default)
    Public Const DISCCFGDIO_LOGFAULT As UInt32 = &H100 '//Every fault for this output will create an entry in the Event Log List (out)
    Public Const DISCCFGDIO_LOGALL As UInt32 = &H1C0   '//Every transition for this input and every fault for this output will create an entry in the Event Log Lit (in/out)

    '/**
    '*
    '*  Bank info fields.
    '*
    '**/

    Public Const INFODIO_INPUT As UInt32 = &H1   '//Bank is input capable
    Public Const INFODIO_OUTPUT As UInt32 = &H2  '//Bank is output capable
    Public Const INFODIO_SERIES As UInt32 = &H4  '//Bank is series capable
    Public Const INFODIO_SHUNT As UInt32 = &H8   '//Bank is shunt capable

End Module
