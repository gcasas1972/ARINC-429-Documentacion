'/**
'*
'*  BTI717 WIN32 DRIVER  Version 1.8.2  (10/05/2010)
'*  Copyright (c) 2001-2010
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   BTI717.BAS -- 32-bit
'*                      BTI717 Driver Include Header File.
'*
'**/

'/**
'*
'*  Structs used by the BTI717 Driver.
'*
'**/

Public Type SUBFRMFIELDS717
	subfrmopt As Integer	'//Driver writes message optionvals
	subfrmact As Integer	'//Card writes message activity
	subfrmnum As Integer	'//Card writes subframe number
	subfrmwps As Integer	'//Card writes WPS
	timestamp_hitcount As Long	'//Card writes timestamp - '//Card writes hit count
	spfptr As Long	'//Card writes superframe pointer
	data(0 to 8191) As Integer	'//Card/User writes subframe data. Valid from 0 -> WPS-1. (Rcv/Xmt)
	timestamph As Long	'//Card writes extended timestamp
	extflag As Integer	'//Driver writes external trigger/sync control flags
	rsvd(0 to 12) As Integer	'//Reserved
End Type

'/**
'*
'*  BTI717 Driver functions.
'*
'**/

'/**
'*
'*  Internal functions used by the BTI717 Driver.
'*
'**/

Public Declare Function BTI717_ChClear Lib "BTI717.DLL" Alias "_BTI717_ChClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChConfig Lib "BTI717.DLL" Alias "_BTI717_ChConfig@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI717_ChGetCount Lib "BTI717.DLL" Alias "_BTI717_ChGetCount@12" (ByRef rcvcount As Long, ByRef xmtcount As Long, ByVal handleval As Long)
Public Declare Function BTI717_ChGetInfo Lib "BTI717.DLL" Alias "_BTI717_ChGetInfo@12" (ByVal infotype As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChIs717 Lib "BTI717.DLL" Alias "_BTI717_ChIs717@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChIsBiPhase Lib "BTI717.DLL" Alias "_BTI717_ChIsBiPhase@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChIsRcv Lib "BTI717.DLL" Alias "_BTI717_ChIsRcv@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChIsSelEnc Lib "BTI717.DLL" Alias "_BTI717_ChIsSelEnc@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChIsType Lib "BTI717.DLL" Alias "_BTI717_ChIsType@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChIsXmt Lib "BTI717.DLL" Alias "_BTI717_ChIsXmt@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI717_ChPause Lib "BTI717.DLL" Alias "_BTI717_ChPause@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI717_ChPauseCheck Lib "BTI717.DLL" Alias "_BTI717_ChPauseCheck@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI717_ChResume Lib "BTI717.DLL" Alias "_BTI717_ChResume@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI717_ChStart Lib "BTI717.DLL" Alias "_BTI717_ChStart@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChStatus Lib "BTI717.DLL" Alias "_BTI717_ChStatus@12" (ByRef buf As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChStop Lib "BTI717.DLL" Alias "_BTI717_ChStop@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChSyncDefine Lib "BTI717.DLL" Alias "_BTI717_ChSyncDefine@20" (ByVal enableflag As Long, ByVal syncmask As Integer, ByVal pinpolarity As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChTriggerDefine Lib "BTI717.DLL" Alias "_BTI717_ChTriggerDefine@24" (ByVal enableflag As Long, ByVal trigmask As Integer, ByVal trigval As Integer, ByVal pinpolarity As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ParamAmplitudeConfig Lib "BTI717.DLL" Alias "_BTI717_ParamAmplitudeConfig@16" (ByVal configval As Long, ByVal dacval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ParamAmplitudeGet Lib "BTI717.DLL" Alias "_BTI717_ParamAmplitudeGet@12" (ByRef dacval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmBlkRd Lib "BTI717.DLL" Alias "_BTI717_SubFrmBlkRd@16" (ByRef databuf As Integer, ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmBlkWr Lib "BTI717.DLL" Alias "_BTI717_SubFrmBlkWr@16" (ByRef databuf As Integer, ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmStatus Lib "BTI717.DLL" Alias "_BTI717_SubFrmStatus@16" (ByRef buf As Integer, ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmSyncDefine Lib "BTI717.DLL" Alias "_BTI717_SubFrmSyncDefine@24" (ByVal enableflag As Long, ByVal syncmask As Integer, ByVal pinpolarity As Integer, ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmTriggerDefine Lib "BTI717.DLL" Alias "_BTI717_SubFrmTriggerDefine@28" (ByVal enableflag As Long, ByVal trigmask As Integer, ByVal trigval As Integer, ByVal pinpolarity As Integer, ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmWordConfig Lib "BTI717.DLL" Alias "_BTI717_SubFrmWordConfig@20" (ByVal configval As Long, ByVal subframe As Long, ByVal word As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmWordRd Lib "BTI717.DLL" Alias "_BTI717_SubFrmWordRd@20" (ByRef value As Integer, ByVal subframe As Long, ByVal word As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmWordWr Lib "BTI717.DLL" Alias "_BTI717_SubFrmWordWr@20" (ByVal value As Integer, ByVal subframe As Long, ByVal word As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SuperFrmConfig Lib "BTI717.DLL" Alias "_BTI717_SuperFrmConfig@16" (ByVal count As Long, ByVal framespersuperframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SuperFrmCounterPos Lib "BTI717.DLL" Alias "_BTI717_SuperFrmCounterPos@16" (ByVal subframe As Long, ByVal word As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SuperFrmDefine Lib "BTI717.DLL" Alias "_BTI717_SuperFrmDefine@16" (ByVal subframe As Long, ByVal word As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SuperFrmWordConfig Lib "BTI717.DLL" Alias "_BTI717_SuperFrmWordConfig@20" (ByVal configval As Long, ByVal superfrmnum As Long, ByVal superfrmaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SuperFrmWordRd Lib "BTI717.DLL" Alias "_BTI717_SuperFrmWordRd@20" (ByRef value As Integer, ByVal superfrmnum As Long, ByVal superfrmaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SuperFrmWordWr Lib "BTI717.DLL" Alias "_BTI717_SuperFrmWordWr@20" (ByVal value As Integer, ByVal superfrmnum As Long, ByVal superfrmaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SyncTest Lib "BTI717.DLL" Alias "_BTI717_SyncTest@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SyncValRd Lib "BTI717.DLL" Alias "_BTI717_SyncValRd@24" (ByRef syncword1 As Long, ByRef syncword2 As Long, ByRef syncword3 As Long, ByRef syncword4 As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SyncValWr Lib "BTI717.DLL" Alias "_BTI717_SyncValWr@24" (ByVal syncword1 As Long, ByVal syncword2 As Long, ByVal syncword3 As Long, ByVal syncword4 As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChCreate Lib "BTI717.DLL" Alias "_BTI717_ChCreate@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_ChReset Lib "BTI717.DLL" Alias "_BTI717_ChReset@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_DllUsageCount Lib "BTI717.DLL" Alias "_BTI717_DllUsageCount@0" () As Long
Public Declare Sub BTI717_GetChanCount Lib "BTI717.DLL" Alias "_BTI717_GetChanCount@12" (ByRef rcvcount As Long, ByRef xmtcount As Long, ByVal handleval As Long)
Public Declare Function BTI717_IsBiPhaseChan Lib "BTI717.DLL" Alias "_BTI717_IsBiPhaseChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_IsChan Lib "BTI717.DLL" Alias "_BTI717_IsChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_IsRcvChan Lib "BTI717.DLL" Alias "_BTI717_IsRcvChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_IsXmtChan Lib "BTI717.DLL" Alias "_BTI717_IsXmtChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmAddr Lib "BTI717.DLL" Alias "_BTI717_SubFrmAddr@12" (ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmBlkRdEx Lib "BTI717.DLL" Alias "_BTI717_SubFrmBlkRdEx@16" (ByRef subfrmdata As SUBFRMFIELDS717, ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmBlkWrEx Lib "BTI717.DLL" Alias "_BTI717_SubFrmBlkWrEx@16" (ByRef subfrmdata As SUBFRMFIELDS717, ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmCreate Lib "BTI717.DLL" Alias "_BTI717_SubFrmCreate@16" (ByVal configval As Long, ByVal subframe As Long, ByVal chanbase As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SubFrmReset Lib "BTI717.DLL" Alias "_BTI717_SubFrmReset@12" (ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SuperFrmBaseAddr Lib "BTI717.DLL" Alias "_BTI717_SuperFrmBaseAddr@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SuperFrmConfigEx Lib "BTI717.DLL" Alias "_BTI717_SuperFrmConfigEx@20" (ByVal configval As Long, ByVal count As Long, ByVal framespersuperframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SuperFrmReset Lib "BTI717.DLL" Alias "_BTI717_SuperFrmReset@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_SyncValPtrInit Lib "BTI717.DLL" Alias "_BTI717_SyncValPtrInit@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI717_TestProtocol Lib "BTI717.DLL" Alias "_BTI717_TestProtocol@4" (ByVal handleval As Long) As Long

'/**
'*
'*  Channel number constants
'*
'**/

Public Const CH0 As Integer = &H0    '//Channel 0
Public Const CH1 As Integer = &H1    '//Channel 1
Public Const CH2 As Integer = &H2    '//Channel 2
Public Const CH3 As Integer = &H3    '//Channel 3
Public Const CH4 As Integer = &H4    '//Channel 4
Public Const CH5 As Integer = &H5    '//Channel 5
Public Const CH6 As Integer = &H6    '//Channel 6
Public Const CH7 As Integer = &H7    '//Channel 7
Public Const CH8 As Integer = &H8    '//Channel 8
Public Const CH9 As Integer = &H9    '//Channel 9
Public Const CH10 As Integer = &HA   '//Channel 10
Public Const CH11 As Integer = &HB   '//Channel 11
Public Const CH12 As Integer = &HC   '//Channel 12
Public Const CH13 As Integer = &HD   '//Channel 13
Public Const CH14 As Integer = &HE   '//Channel 14
Public Const CH15 As Integer = &HF   '//Channel 15
Public Const CH16 As Integer = &H10   '//Channel 16
Public Const CH17 As Integer = &H11   '//Channel 17
Public Const CH18 As Integer = &H12   '//Channel 18
Public Const CH19 As Integer = &H13   '//Channel 19
Public Const CH20 As Integer = &H14   '//Channel 20
Public Const CH21 As Integer = &H15   '//Channel 21
Public Const CH22 As Integer = &H16   '//Channel 22
Public Const CH23 As Integer = &H17   '//Channel 23
Public Const CH24 As Integer = &H18   '//Channel 24
Public Const CH25 As Integer = &H19   '//Channel 25
Public Const CH26 As Integer = &H1A   '//Channel 26
Public Const CH27 As Integer = &H1B   '//Channel 27
Public Const CH28 As Integer = &H1C   '//Channel 28
Public Const CH29 As Integer = &H1D   '//Channel 29
Public Const CH30 As Integer = &H1E   '//Channel 30
Public Const CH31 As Integer = &H1F   '//Channel 31

'/**
'*
'*  Subframe constants
'*
'**/

Public Const SUBFRM1 As Long = &H1   '//Sub Frame 1
Public Const SUBFRM2 As Long = &H2   '//Sub Frame 2
Public Const SUBFRM3 As Long = &H3   '//Sub Frame 3
Public Const SUBFRM4 As Long = &H4   '//Sub Frame 4

'/**
'*
'*  Channel configuration options
'*
'**/

Public Const CHCFG717_DEFAULT As Long = &H0  '//Select all default settings (XMT & RCV) (default)
Public Const CHCFG717_AUTOSPEED As Long = &H2    '//Select auto speed detection (RCV)
Public Const CHCFG717_64WPS As Long = &H4000    '//Select speed of 64WPS (XMT & RCV)
Public Const CHCFG717_128WPS As Long = &H8000   '//Select speed of 128WPS (XMT & RCV)
Public Const CHCFG717_256WPS As Long = &H0   '//Select speed of 256WPS (XMT & RCV) (default)
Public Const CHCFG717_512WPS As Long = &H10000   '//Select speed of 512WPS (XMT & RCV)
Public Const CHCFG717_1024WPS As Long = &H20000  '//Select speed of 1024WPS (XMT & RCV)
Public Const CHCFG717_2048WPS As Long = &H40000  '//Select speed of 2048WPS (XMT & RCV)
Public Const CHCFG717_4096WPS As Long = &H2000000  '//Select speed of 4096WPS (XMT & RCV)
Public Const CHCFG717_8192WPS As Long = &H4000000  '//Select speed of 8192WPS (XMT & RCV)
Public Const CHCFG717_BIPHASERCV As Long = &H0   '//Select Bi-Phase decoding for receiver (Bi-Phase or RCV) (default)
Public Const CHCFG717_BIPHASEXMT As Long = &H8000000   '//Select Bi-Phase encoding for transmitter (Bi-Phase or XMT)
Public Const CHCFG717_BIPOLARRCV As Long = &H20000000   '//Select Bi-Polar decoding for receiver (Bi-Polar or RCV)
Public Const CHCFG717_BIPOLARXMT As Long = &H60000000   '//Select Bi-Polar encoding for transmitter (Bi-Polar or XMT)
Public Const CHCFG717_BIPOLARHSPD As Long = &H8000000  '//Select high speed slope for Bi-Polar transmitter (Bi-Polar XMT)
Public Const CHCFG717_SELFTEST As Long = &H4 '//Enable internal wraparound (XMT & RCV)
Public Const CHCFG717_SELFTESTOFF As Long = &H0  '//Disable internal wraparound (XMT & RCV) (default)
Public Const CHCFG717_SYNC As Long = &H8 '//Sync Enable (XMT & RCV)
Public Const CHCFG717_SYNCOFF As Long = &H0  '//Disable sync output (XMT & RCV) (default)
Public Const CHCFG717_ACTIVE As Long = &H0   '//Enable channel activity (XMT & RCV) (default)
Public Const CHCFG717_INACTIVE As Long = &H40 '//Disable channel activity (XMT & RCV)
Public Const CHCFG717_EXTSTART As Long = &H100 '//Enable external trigger for first message only (XMT)
Public Const CHCFG717_EXTTRIG As Long = &H80  '//Enable external trigger for all messages (XMT)
Public Const CHCFG717_EXTOFF As Long = &H0   '//External trigger is enabled on message level (XMT) (default)
Public Const CHCFG717_HIT As Long = &H200  '//Hit counter is enabled for all sub frames (XMT & RCV)
Public Const CHCFG717_NOHIT As Long = &H0    '//Hit counter is disabled (XMT & RCV) (default)
Public Const CHCFG717_TIMETAG As Long = &H400  '//Enable time-tag for all sub frames (XMT & RCV)
Public Const CHCFG717_TIMETAGOFF As Long = &H0   '//Time-tag is disabled (XMT & RCV) (default)
Public Const CHCFG717_SEQALL As Long = &H80000   '//Record entire channel in sequential record (XMT & RCV)
Public Const CHCFG717_SEQSEL As Long = &H0   '//Sequential record recording is enabled at word level (XMT & RCV) (default)
Public Const CHCFG717_LOGERR As Long = &H800000   '//Enable event log on Out of Sync Error (RCV)
Public Const CHCFG717_NOLOGERR As Long = &H0 '//No event log on Out of Sync Error (RCV) (default)
Public Const CHCFG717_PAUSE As Long = &H1000000    '//Mark channel as paused (XMT & RCV)
Public Const CHCFG717_UNPAUSE As Long = &H0  '//Mark channel as unpaused (XMT & RCV) (default)
Public Const CHCFG717_XMTSLOPELOW As Long = &H0  '//Select low speed slope for transmitter (XMT) (default)
Public Const CHCFG717_XMTSLOPEHIGH As Long = &H10000000 '//Select high speed slope for transmitter (XMT)

'/**
'*
'*  Sub Frame word configuration options
'*
'**/

Public Const WRDCFG717_DEFAULT As Long = &H0 '//Select all default settings
Public Const WRDCFG717_SFLOG As Long = &H1   '//Enable subframe event log
Public Const WRDCFG717_SFLOGOFF As Long = &H0    '//Disable subframe event log (default)
Public Const WRDCFG717_WRDLOG As Long = &H2  '//Enable word event log
Public Const WRDCFG717_WRDLOGOFF As Long = &H0   '//Disable word event log (default)
Public Const WRDCFG717_SEQ As Long = &H4 '//Enable sequential record
Public Const WRDCFG717_SEQOFF As Long = &H0  '//Disable sequential record (default)

'/**
'*
'*  Parametric configuration options
'*
'**/

Public Const PARAMCFG717_DEFAULT As Long = &H0   '//Select all default settings (default)
Public Const PARAMCFG717_AMPLON As Long = &H0    '//Enables parametric amplitude control (default)
Public Const PARAMCFG717_AMPLOFF As Long = &H1   '//Disables parametric amplitude control

'/**
'*
'*  Bit fields of the message activity flag.
'*
'**/

Public Const MSGACT717_CHMASK As Long = &HFF00  '//Channel number mask value
Public Const MSGACT717_CHSHIFT As Long = &H8 '//Channel number shift value
Public Const MSGACT717_SPDMASK As Long = &HE0 '//Current speed mask value
Public Const MSGACT717_64WPS As Long = &H0   '//Current speed is 64   wps
Public Const MSGACT717_128WPS As Long = &H20  '//Current speed is 128  wps
Public Const MSGACT717_256WPS As Long = &H40  '//Current speed is 256  wps
Public Const MSGACT717_512WPS As Long = &H60  '//Current speed is 512  wps
Public Const MSGACT717_1024WPS As Long = &H80 '//Current speed is 1024 wps
Public Const MSGACT717_2048WPS As Long = &HA0 '//Current speed is 2048 wps
Public Const MSGACT717_4096WPS As Long = &HC0 '//Current speed is 4096 wps
Public Const MSGACT717_8192WPS As Long = &HE0 '//Current speed is 8192 wps
Public Const MSGACT717_TO As Long = &H2  '//Time out error bit
Public Const MSGACT717_HIT As Long = &H1 '//Always set

'/**
'*
'*  Channel info fields.
'*
'**/

Public Const INFO717_PARAM As Long = &H1 '//Channel supports parametric control
