'/**
'*
'*  BTIDIO WIN32 DRIVER  Version 1.1.2  (03/02/2010)
'*  Copyright (c) 2005-2010
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   BTIDIO.BAS -- 32-bit
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

Public Declare Function BTIDIO_BankConfig Lib "BTIDIO.DLL" Alias "_BTIDIO_BankConfig@20" (ByVal configval As Long, ByVal threshold As Integer, ByVal samplerate As Integer, ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTIDIO_BankFaultClr Lib "BTIDIO.DLL" Alias "_BTIDIO_BankFaultClr@12" (ByVal mask As Byte, ByVal banknum As Long, ByVal handleval As Long)
Public Declare Function BTIDIO_BankFaultRd Lib "BTIDIO.DLL" Alias "_BTIDIO_BankFaultRd@8" (ByVal banknum As Long, ByVal handleval As Long) As Byte
Public Declare Function BTIDIO_BankIsDIO Lib "BTIDIO.DLL" Alias "_BTIDIO_BankIsDIO@8" (ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_BankRd Lib "BTIDIO.DLL" Alias "_BTIDIO_BankRd@8" (ByVal banknum As Long, ByVal handleval As Long) As Byte
Public Declare Function BTIDIO_BankStart Lib "BTIDIO.DLL" Alias "_BTIDIO_BankStart@8" (ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_BankStop Lib "BTIDIO.DLL" Alias "_BTIDIO_BankStop@8" (ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_BankWr Lib "BTIDIO.DLL" Alias "_BTIDIO_BankWr@12" (ByVal value As Byte, ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_BankWrMask Lib "BTIDIO.DLL" Alias "_BTIDIO_BankWrMask@16" (ByVal value As Byte, ByVal mask As Byte, ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_DiscreteConfig Lib "BTIDIO.DLL" Alias "_BTIDIO_DiscreteConfig@16" (ByVal configval As Long, ByVal ionum As Long, ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_DiscreteRd Lib "BTIDIO.DLL" Alias "_BTIDIO_DiscreteRd@12" (ByVal ionum As Long, ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_DiscreteWr Lib "BTIDIO.DLL" Alias "_BTIDIO_DiscreteWr@16" (ByVal value As Long, ByVal ionum As Long, ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_BankClear Lib "BTIDIO.DLL" Alias "_BTIDIO_BankClear@8" (ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_BankGetCount Lib "BTIDIO.DLL" Alias "_BTIDIO_BankGetCount@4" (ByVal handleval As Long) As Long
Public Declare Function BTIDIO_BankGetInfo Lib "BTIDIO.DLL" Alias "_BTIDIO_BankGetInfo@12" (ByVal infotype As Integer, ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_BankGetSampleRate Lib "BTIDIO.DLL" Alias "_BTIDIO_BankGetSampleRate@8" (ByVal banknum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTIDIO_BankGetThreshold Lib "BTIDIO.DLL" Alias "_BTIDIO_BankGetThreshold@8" (ByVal banknum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTIDIO_BankSetSampleRate Lib "BTIDIO.DLL" Alias "_BTIDIO_BankSetSampleRate@12" (ByVal samplerate As Integer, ByVal banknum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTIDIO_BankSetThreshold Lib "BTIDIO.DLL" Alias "_BTIDIO_BankSetThreshold@12" (ByVal threshold As Integer, ByVal banknum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTIDIO_DiscreteGetCount Lib "BTIDIO.DLL" Alias "_BTIDIO_DiscreteGetCount@8" (ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_DllUsageCount Lib "BTIDIO.DLL" Alias "_BTIDIO_DllUsageCount@0" () As Long
Public Declare Function BTIDIO_GetBankCount Lib "BTIDIO.DLL" Alias "_BTIDIO_GetBankCount@4" (ByVal handleval As Long) As Long
Public Declare Function BTIDIO_IsBank Lib "BTIDIO.DLL" Alias "_BTIDIO_IsBank@8" (ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTIDIO_TestProtocol Lib "BTIDIO.DLL" Alias "_BTIDIO_TestProtocol@4" (ByVal handleval As Long) As Long

'/**
'*
'*  Bank number constants
'*
'**/

Public Const BANKA As Integer = &H0  '//Bank A
Public Const BANKB As Integer = &H1  '//Bank B
Public Const BANKC As Integer = &H2  '//Bank C
Public Const BANKD As Integer = &H3  '//Bank D

'/**
'*
'*  Bank configuration options
'*
'**/

Public Const BANKCFGDIO_DEFAULT As Long = &H0    '//Select all default settings (in & out) (default)
Public Const BANKCFGDIO_INPUT As Long = &H0  '//Select input mode (in) (default)
Public Const BANKCFGDIO_OUTPUT As Long = &H1 '//Select output mode (out)
Public Const BANKCFGDIO_INOUT As Long = &H2  '//Select concurrent input and output mode (in & out)
Public Const BANKCFGDIO_SERIES As Long = &H0 '//Select series mode (in) (default)
Public Const BANKCFGDIO_SHUNT As Long = &H4  '//Select shunt mode (in)
Public Const BANKCFGDIO_POLIN_INVOFF As Long = &H0   '//Disable polarity inversion for bank input (in) (default)
Public Const BANKCFGDIO_POLIN_INV As Long = &H100  '//Enable polarity inversion for bank input (in)
Public Const BANKCFGDIO_POLOUT_INVOFF As Long = &H0  '//Disable polarity inversion for bank output (out) (default)
Public Const BANKCFGDIO_POLOUT_INV As Long = &H200 '//Enable polarity inversion for bank output (out)
Public Const BANKCFGDIO_ACTIVE As Long = &H0 '//Enable bank activity (in & out) (default)
Public Const BANKCFGDIO_INACTIVE As Long = &H10   '//Disables bank activity (in & out)
Public Const BANKCFGDIO_SEQSEL As Long = &H0 '//Sequential monitoring of selected transitions (in & out) (default)
Public Const BANKCFGDIO_SEQALL As Long = &H20 '//Every transition will be recorded in the Sequential Record (in & out)
Public Const BANKCFGDIO_NOLOGFAULT As Long = &H0 '//No entry will be made in the Event Log List when an output detects a fault (out) (default)
Public Const BANKCFGDIO_LOGFAULT As Long = &H40   '//An entry will be made in the Event Log List when an output detects a fault (out)
Public Const BANKCFGDIO_NOLOGEDGE As Long = &H0  '//No entry will be made in the Event Log List when an input detects an edge (in) (default)
Public Const BANKCFGDIO_LOGEDGE As Long = &H80    '//An entry will be made in the Event Log List when an input detects an edge (in)
Public Const BANKCFGDIO_LOGALL As Long = &HC0 '//An entry will be made in the Event Log List when an input detects an edge and when an output detects a fault (in & out)

Public Const THRESHOLDDIO_TTL As Long = &HF0  '//Corresponds to a 1.4V switching threshold (TTL)
Public Const THRESHOLDDIO_CMOS As Long = &H1B0 '//Corresponds to a 2.5V switching threshold (CMOS)
Public Const THRESHOLDDIO_1_4V As Long = &HF0 '//Corresponds to a 1.4V switching threshold
Public Const THRESHOLDDIO_2_5V As Long = &H1B0 '//Corresponds to a 2.5V switching threshold
Public Const THRESHOLDDIO_5V As Long = &H370   '//Corresponds to a 5V switching threshold
Public Const THRESHOLDDIO_7V As Long = &H4D0   '//Corresponds to a 7V switching threshold
Public Const THRESHOLDDIO_12V As Long = &H850  '//Corresponds to a 12V switching threshold
Public Const THRESHOLDDIO_16V As Long = &HB10  '//Corresponds to a 16V switching threshold
Public Const THRESHOLDDIO_10KOHM As Long = &HF0   '//Corresponds to approx. 10kOhm switching threshold (Shunt)
Public Const THRESHOLDDIO_25KOHM As Long = &H1B0   '//Corresponds to approx. 25kOhm switching threshold (Shunt)
Public Const THRESHOLDDIO_100KOHM As Long = &H300  '//Corresponds to approx. 100kOhm switching threshold (Shunt)

Public Const SAMPLERATEDIO_US As Long = &H0  '//Corresponds to a 1us base sample clock
Public Const SAMPLERATEDIO_MS As Long = &H8000  '//Corresponds to a 1ms base sample clock

'/**
'*
'*  Discrete configuration options
'*
'**/

Public Const DISCCFGDIO_DEFAULT As Long = &H0    '//Select all default settings (in & out) (default)
Public Const DISCCFGDIO_INPUT As Long = &H0  '//Select input mode (in) (default)
Public Const DISCCFGDIO_OUTPUT As Long = &H1 '//Select output mode (out)
Public Const DISCCFGDIO_INOUT As Long = &H2  '//Select concurrent input and output mode (in & out)
Public Const DISCCFGDIO_POLIN_INVOFF As Long = &H0   '//Disable polarity inversion for input (in) (default)
Public Const DISCCFGDIO_POLIN_INV As Long = &H4  '//Enable polarity inversion for input (in)
Public Const DISCCFGDIO_POLOUT_INVOFF As Long = &H0  '//Disable polarity inversion for output (out) (default)
Public Const DISCCFGDIO_POLOUT_INV As Long = &H8 '//Enable polarity inversion for output (out)
Public Const DISCCFGDIO_SEQNONE As Long = &H0    '//No transitions for this input will be recorded in the Sequential Record (in & out) (default)
Public Const DISCCFGDIO_SEQPOSEDGE As Long = &H10 '//Positive transitions for this input will be recorded in the Sequential Record (in & out)
Public Const DISCCFGDIO_SEQNEGEDGE As Long = &H20 '//Negative transitions for this input will be recorded in the Sequential Record (in & out)
Public Const DISCCFGDIO_SEQANYEDGE As Long = &H30 '//Every transition for this input will be recorded in the Sequential Record (in & out)
Public Const DISCCFGDIO_NOLOGEDGE As Long = &H0  '//No transitions for this input will create an entry in the Event Log List (in & out) (default)
Public Const DISCCFGDIO_LOGPOSEDGE As Long = &H40 '//Positive transitions for this input will create an entry in the Event Log List (in & out)
Public Const DISCCFGDIO_LOGNEGEDGE As Long = &H80 '//Negative transitions for this input will create an entry in the Event Log List (in & out)
Public Const DISCCFGDIO_LOGANYEDGE As Long = &HC0 '//Every transition for this input will create an entry in the Event Log List (in & out)
Public Const DISCCFGDIO_NOLOGFAULT As Long = &H0 '//No faults for this output will create an entry in the Event Log List (out) (default)
Public Const DISCCFGDIO_LOGFAULT As Long = &H100   '//Every fault for this output will create an entry in the Event Log List (out)
Public Const DISCCFGDIO_LOGALL As Long = &H1C0 '//Every transition for this input and every fault for this output will create an entry in the Event Log Lit (in/out)

'/**
'*
'*  Bank info fields.
'*
'**/

Public Const INFODIO_INPUT As Long = &H1 '//Bank is input capable
Public Const INFODIO_OUTPUT As Long = &H2    '//Bank is output capable
Public Const INFODIO_SERIES As Long = &H4    '//Bank is series capable
Public Const INFODIO_SHUNT As Long = &H8 '//Bank is shunt capable
