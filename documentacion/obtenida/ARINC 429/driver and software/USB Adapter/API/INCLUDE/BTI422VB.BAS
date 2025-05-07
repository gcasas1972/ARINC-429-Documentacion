'/**
'*
'*  BTI422 WIN32 DRIVER  Version 1.1.2  (03/02/2010)
'*  Copyright (c) 2004-2010
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   BTI422.BAS -- 32-bit
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

Public Declare Function BTI422_FIFOCheckRx Lib "BTI422.DLL" Alias "_BTI422_FIFOCheckRx@8" (ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_FIFOCheckTx Lib "BTI422.DLL" Alias "_BTI422_FIFOCheckTx@8" (ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_FIFOConfigRx Lib "BTI422.DLL" Alias "_BTI422_FIFOConfigRx@16" (ByVal configval As Long, ByVal threshold As Long, ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_FIFOConfigTx Lib "BTI422.DLL" Alias "_BTI422_FIFOConfigTx@16" (ByVal configval As Long, ByVal threshold As Long, ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_FIFODataRd Lib "BTI422.DLL" Alias "_BTI422_FIFODataRd@20" (ByRef buf As Byte, ByVal count As Long, ByRef status As Long, ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_FIFODataWr Lib "BTI422.DLL" Alias "_BTI422_FIFODataWr@20" (ByRef buf As Byte, ByVal count As Long, ByVal ctrlflags As Long, ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_FIFOFlushRx Lib "BTI422.DLL" Alias "_BTI422_FIFOFlushRx@8" (ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_FIFOFlushTx Lib "BTI422.DLL" Alias "_BTI422_FIFOFlushTx@8" (ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_FIFOGapWr Lib "BTI422.DLL" Alias "_BTI422_FIFOGapWr@16" (ByVal gapcount As Integer, ByVal ctrlflags As Long, ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_ParamAmplitudeConfig Lib "BTI422.DLL" Alias "_BTI422_ParamAmplitudeConfig@16" (ByVal configval As Long, ByVal dacval As Integer, ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_ParamAmplitudeGet Lib "BTI422.DLL" Alias "_BTI422_ParamAmplitudeGet@12" (ByRef dacval As Integer, ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_PortConfig Lib "BTI422.DLL" Alias "_BTI422_PortConfig@16" (ByVal configval As Long, ByVal bitrateflag As Integer, ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI422_PortGetCount Lib "BTI422.DLL" Alias "_BTI422_PortGetCount@8" (ByRef portcount As Long, ByVal handleval As Long)
Public Declare Function BTI422_PortGetInfo Lib "BTI422.DLL" Alias "_BTI422_PortGetInfo@12" (ByVal infotype As Integer, ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_PortIs422 Lib "BTI422.DLL" Alias "_BTI422_PortIs422@8" (ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_PortStart Lib "BTI422.DLL" Alias "_BTI422_PortStart@8" (ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_PortStop Lib "BTI422.DLL" Alias "_BTI422_PortStop@8" (ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_DllUsageCount Lib "BTI422.DLL" Alias "_BTI422_DllUsageCount@0" () As Long
Public Declare Function BTI422_PortCreate Lib "BTI422.DLL" Alias "_BTI422_PortCreate@8" (ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_PortReset Lib "BTI422.DLL" Alias "_BTI422_PortReset@8" (ByVal portnum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI422_TestProtocol Lib "BTI422.DLL" Alias "_BTI422_TestProtocol@4" (ByVal handleval As Long) As Long

'/**
'*
'*  Port number constants
'*
'**/

Public Const PORT0 As Integer = &H0  '//Port 0
Public Const PORT1 As Integer = &H1  '//Port 1
Public Const PORT2 As Integer = &H2  '//Port 2
Public Const PORT3 As Integer = &H3  '//Port 3
Public Const PORT4 As Integer = &H4  '//Port 4
Public Const PORT5 As Integer = &H5  '//Port 5
Public Const PORT6 As Integer = &H6  '//Port 6
Public Const PORT7 As Integer = &H7  '//Port 7
Public Const PORT8 As Integer = &H8  '//Port 8
Public Const PORT9 As Integer = &H9  '//Port 9
Public Const PORT10 As Integer = &HA '//Port 10
Public Const PORT11 As Integer = &HB '//Port 11
Public Const PORT12 As Integer = &HC '//Port 12
Public Const PORT13 As Integer = &HD '//Port 13
Public Const PORT14 As Integer = &HE '//Port 14
Public Const PORT15 As Integer = &HF '//Port 15
Public Const PORT16 As Integer = &H10 '//Port 16
Public Const PORT17 As Integer = &H11 '//Port 17
Public Const PORT18 As Integer = &H12 '//Port 18
Public Const PORT19 As Integer = &H13 '//Port 19
Public Const PORT20 As Integer = &H14 '//Port 20
Public Const PORT21 As Integer = &H15 '//Port 21
Public Const PORT22 As Integer = &H16 '//Port 22
Public Const PORT23 As Integer = &H17 '//Port 23
Public Const PORT24 As Integer = &H18 '//Port 24
Public Const PORT25 As Integer = &H19 '//Port 25
Public Const PORT26 As Integer = &H1A '//Port 26
Public Const PORT27 As Integer = &H1B '//Port 27
Public Const PORT28 As Integer = &H1C '//Port 28
Public Const PORT29 As Integer = &H1D '//Port 29
Public Const PORT30 As Integer = &H1E '//Port 30
Public Const PORT31 As Integer = &H1F '//Port 31

'/**
'*
'*  Bitrate configuration options
'*
'**/

Public Const BITRATE422_CLK1 As Integer = &H8000    '//CLK1, 20 MHz (default)
Public Const BITRATE422_CLK2 As Integer = &H0    '//CLK2, 9.216 MHz (standard option)
Public Const BITRATE422_XMTSLOPEHIGH As Integer = &H0    '//Transmit with high speed slope (default)
Public Const BITRATE422_XMTSLOPELOW As Integer = &H4000 '//Transmit with low speed slope

'// These defines assume an external clock of 9.216 MHz
Public Const BITRATE422_921600BPS As Integer = &H0   '//External Clock, Div = 0
Public Const BITRATE422_460800BPS As Integer = &H1   '//External Clock, Div = 1
Public Const BITRATE422_230400BPS As Integer = &H3   '//External Clock, Div = 3
Public Const BITRATE422_115200BPS As Integer = &H7   '//External Clock, Div = 7
Public Const BITRATE422_57600BPS As Integer = &HF    '//External Clock, Div = 15
Public Const BITRATE422_38400BPS As Integer = &H17    '//External Clock, Div = 23
Public Const BITRATE422_28800BPS As Integer = &H1F    '//External Clock, Div = 31
Public Const BITRATE422_19200BPS As Integer = &H2F    '//External Clock, Div = 47
Public Const BITRATE422_14400BPS As Integer = &H3F    '//External Clock, Div = 63
Public Const BITRATE422_9600BPS As Integer = &H5F '//External Clock, Div = 95
Public Const BITRATE422_7200BPS As Integer = &H7F '//External Clock, Div = 127
Public Const BITRATE422_4800BPS As Integer = &HBF '//External Clock, Div = 191
Public Const BITRATE422_3600BPS As Integer = &HFF '//External Clock, Div = 255
Public Const BITRATE422_2400BPS As Integer = &H17F '//External Clock, Div = 383
Public Const BITRATE422_1800BPS As Integer = &H1FF '//External Clock, Div = 511
Public Const BITRATE422_1200BPS As Integer = &H2FF '//External Clock, Div = 767
Public Const BITRATE422_900BPS As Integer = &H3FF  '//External Clock, Div = 1023
Public Const BITRATE422_600BPS As Integer = &H5FF  '//External Clock, Div = 1535
Public Const BITRATE422_300BPS As Integer = &HBFF  '//External Clock, Div = 3071

Public Const BITRATE422_1000000BPS As Integer = &H8001  '//Internal Clock, Div = 1
Public Const BITRATE422_500000BPS As Integer = &H8003   '//Internal Clock, Div = 3
Public Const BITRATE422_400000BPS As Integer = &H8004   '//Internal Clock, Div = 4
Public Const BITRATE422_250000BPS As Integer = &H8007   '//Internal Clock, Div = 7
Public Const BITRATE422_200000BPS As Integer = &H8009   '//Internal Clock, Div = 9
Public Const BITRATE422_100000BPS As Integer = &H8013   '//Internal Clock, Div = 19
Public Const BITRATE422_80000BPS As Integer = &H8018    '//Internal Clock, Div = 24
Public Const BITRATE422_50000BPS As Integer = &H8027    '//Internal Clock, Div = 39
Public Const BITRATE422_40000BPS As Integer = &H8031    '//Internal Clock, Div = 49
Public Const BITRATE422_25000BPS As Integer = &H804F    '//Internal Clock, Div = 79
Public Const BITRATE422_20000BPS As Integer = &H8063    '//Internal Clock, Div = 99
Public Const BITRATE422_12500BPS As Integer = &H809F    '//Internal Clock, Div = 159
Public Const BITRATE422_10000BPS As Integer = &H80C7    '//Internal Clock, Div = 199

'/**
'*
'*  Port configuration options
'*
'**/

Public Const PORTCFG422_DEFAULT As Long = &H0    '//Select all default settings (XMT & RCV) (default)
Public Const PORTCFG422_RCVALL As Long = &H0 '//Recieve all data (RCV) (default)
Public Const PORTCFG422_RCVGOOD As Long = &H40000000    '//Receive only error free data (RCV)
Public Const PORTCFG422_SELFTEST As Long = &H4   '//Enable internal wraparound (XMT & RCV)
Public Const PORTCFG422_SELFTESTOFF As Long = &H0    '//Disable internal wraparound (XMT & RCV) (default)
Public Const PORTCFG422_ACTIVE As Long = &H0 '//Enable channel activity (XMT & RCV) (default)
Public Const PORTCFG422_INACTIVE As Long = &H40   '//Disable channel activity (XMT & RCV)
Public Const PORTCFG422_PARITYNONE As Long = &H0 '//Disable parity (XMT & RCV) (default)
Public Const PORTCFG422_PARITYODD As Long = &H800000  '//Enable odd parity (XMT & RCV)
Public Const PORTCFG422_PARITYEVEN As Long = &H400000 '//Enable even parity (XMT & RCV)
Public Const PORTCFG422_PARITYMARK As Long = &H200000 '//Force set parity (XMT & RCV)
Public Const PORTCFG422_PARITYSPACE As Long = &H100000    '//Force clear parity (XMT & RCV)
Public Const PORTCFG422_BUSINVERT As Long = &H80000000  '//Enable bus polarity inversion (XMT & RCV)
Public Const PORTCFG422_BUSINVERTOFF As Long = &H0   '//Disable bus polarity inversion (XMT & RCV) (default)
Public Const PORTCFG422_MODE232 As Long = &H8000000    '//Enable RS-232 / RS-423 mode (unbalanced) (XMT)
Public Const PORTCFG422_MODE422 As Long = &H0    '//Enable RS-422 mode (balanced) (XMT) (default)

'/**
'*
'*  FIFO configuration options
'*
'**/

Public Const FIFOCFG422_DEFAULT As Long = &H0    '//Select all default settings
Public Const FIFOCFG422_NONE As Long = &H0   '//Disable FIFO Events (default)
Public Const FIFOCFG422_TXTHRESHOLD As Long = &H1    '//Enable Transmit FIFO Threshold Event
Public Const FIFOCFG422_TXEMPTY As Long = &H2    '//Enable Transmit FIFO Empty Event
Public Const FIFOCFG422_RXTHRESHOLD As Long = &H4    '//Enable Receive FIFO Threshold Event
Public Const FIFOCFG422_RXFULL As Long = &H8 '//Enable Receive FIFO Full Event
Public Const FIFOCFG422_RXERROR As Long = &H10    '//Enable Receive Error Event

'/**
'*
'*  FIFO word configuration options
'*
'**/

Public Const WRDCFG422_DEFAULT As Long = &H0 '//Select all default settings
Public Const WRDCFG422_GAPEN As Long = &H8000   '//Enable the use of data as gap
Public Const WRDCFG422_GAPENOFF As Long = &H0    '//Disable the use of data as gap (default)
Public Const WRDCFG422_FRAMEERR As Long = &H1000    '//Enable Frame Error
Public Const WRDCFG422_FRAMEERROFF As Long = &H0 '//Disable Frame Error (default)
Public Const WRDCFG422_PARERR As Long = &H800  '//Enable Parity Error
Public Const WRDCFG422_PARERROFF As Long = &H0   '//Disable Parity Error (default)
Public Const WRDCFG422_ATOMIC As Long = &H80000000  '//Enable atomic FIFO access
Public Const WRDCFG422_ATOMICOFF As Long = &H0   '//Disable atomic FIFO access (default)

'/**
'*
'*  FIFO gap configuration options
'*
'**/

Public Const GAPCFG422_DEFAULT As Long = &H0 '//Select all default settings

'/**
'*
'*  Bit fields of the FIFO status flags.
'*
'**/

Public Const WRDSTAT422_ANYERR As Long = &H20 '//Any error
Public Const WRDSTAT422_BITERR As Long = &H10 '//Any bit error
Public Const WRDSTAT422_NRZERR As Long = &H8 '//Bit error (NRZ)
Public Const WRDSTAT422_EDGEERR As Long = &H4    '//Bit error (Edge)
Public Const WRDSTAT422_PARERR As Long = &H2 '//Parity error
Public Const WRDSTAT422_FRAMEERR As Long = &H1   '//Frame error

'/**
'*
'*  Parametric configuration options
'*
'**/

Public Const PARAMCFG422_DEFAULT As Long = &H0   '//Select all default settings (default)
Public Const PARAMCFG422_AMPLON As Long = &H0    '//Enables parametric amplitude control (default)
Public Const PARAMCFG422_AMPLOFF As Long = &H1   '//Disables parametric amplitude control

'/**
'*
'*  Channel info fields.
'*
'**/

Public Const INFO422_PARAM As Long = &H1 '//Channel supports parametric control
