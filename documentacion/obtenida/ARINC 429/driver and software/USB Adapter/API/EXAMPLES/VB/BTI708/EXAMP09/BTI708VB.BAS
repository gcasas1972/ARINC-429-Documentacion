'/**
'*
'*  BTI708 WIN32 DRIVER  Version 1.6.2  (03/02/2010)
'*  Copyright (c) 2001-2010
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   BTI708.BAS -- 32-bit
'*                      BTI708 Driver Include Header File.
'*
'**/

'/**
'*
'*  Structs used by the BTI708 Driver.
'*
'**/

Public Type MSGFIELDS708
	msgopt As Integer	'//Driver writes message optionvals
	msgact As Integer	'//Card writes message activity
	timetag_hitcount As Long	'//Card writes time tag - '//Card writes hit count
	elapsetime_maxtime_mintime As Long	'//Card writes elapsed time - '//Card writes max time - '//Card writes min time
	userptr As Long	'//Driver writes user code pointer
	framenum As Integer	'//Frame Number
	msgcount As Integer	'//Card / Driver writes message bit count (used in variable bit length mode)
	timetagh As Long	'//Card writes extended timetag
	extflag As Integer	'//Driver writes external flags
	rsvd5 As Integer	'//Reserved
	rsvd6 As Integer	'//Reserved
	rsvd7 As Integer	'//Reserved
	data(0 to 99) As Integer	'//Card / User writes message data
	extra(0 to 15) As Integer	'//Card / User writes extra data (used in variable bit length mode)
End Type

'/**
'*
'*  BTI708 Driver functions.
'*
'**/

'/**
'*
'*  Internal functions used by the BTI708 Driver.
'*
'**/

Public Declare Function BTI708_ChClear Lib "BTI708.DLL" Alias "_BTI708_ChClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ChConfig Lib "BTI708.DLL" Alias "_BTI708_ChConfig@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI708_ChGetCount Lib "BTI708.DLL" Alias "_BTI708_ChGetCount@12" (ByRef rcvcount As Long, ByRef xmtcount As Long, ByVal handleval As Long)
Public Declare Function BTI708_ChGetInfo Lib "BTI708.DLL" Alias "_BTI708_ChGetInfo@12" (ByVal infotype As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ChIs708 Lib "BTI708.DLL" Alias "_BTI708_ChIs708@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ChIsRcv Lib "BTI708.DLL" Alias "_BTI708_ChIsRcv@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ChIsXmt Lib "BTI708.DLL" Alias "_BTI708_ChIsXmt@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI708_ChPause Lib "BTI708.DLL" Alias "_BTI708_ChPause@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI708_ChPauseCheck Lib "BTI708.DLL" Alias "_BTI708_ChPauseCheck@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI708_ChResume Lib "BTI708.DLL" Alias "_BTI708_ChResume@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI708_ChStart Lib "BTI708.DLL" Alias "_BTI708_ChStart@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ChStop Lib "BTI708.DLL" Alias "_BTI708_ChStop@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ChSyncDefine Lib "BTI708.DLL" Alias "_BTI708_ChSyncDefine@20" (ByVal enableflag As Long, ByVal syncmask As Integer, ByVal pinpolarity As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ChTriggerDefine Lib "BTI708.DLL" Alias "_BTI708_ChTriggerDefine@24" (ByVal enableflag As Long, ByVal trigmask As Integer, ByVal trigval As Integer, ByVal pinpolarity As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_FieldGetAngle Lib "BTI708.DLL" Alias "_BTI708_FieldGetAngle@4" (ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldGetAngleFl Lib "BTI708.DLL" Alias "_BTI708_FieldGetAngleFl@4" (ByRef buf As Integer) As Single
Public Declare Function BTI708_FieldGetControlAccept Lib "BTI708.DLL" Alias "_BTI708_FieldGetControlAccept@4" (ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldGetData Lib "BTI708.DLL" Alias "_BTI708_FieldGetData@8" (ByVal binnum As Long, ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldGetDataAccept Lib "BTI708.DLL" Alias "_BTI708_FieldGetDataAccept@4" (ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldGetFaults Lib "BTI708.DLL" Alias "_BTI708_FieldGetFaults@4" (ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldGetGain Lib "BTI708.DLL" Alias "_BTI708_FieldGetGain@4" (ByRef buf As Integer) As Long
Public Declare Function BTI708_FieldGetLabel Lib "BTI708.DLL" Alias "_BTI708_FieldGetLabel@4" (ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldGetMode Lib "BTI708.DLL" Alias "_BTI708_FieldGetMode@4" (ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldGetRange Lib "BTI708.DLL" Alias "_BTI708_FieldGetRange@4" (ByRef buf As Integer) As Long
Public Declare Function BTI708_FieldGetTilt Lib "BTI708.DLL" Alias "_BTI708_FieldGetTilt@4" (ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldGetTiltFl Lib "BTI708.DLL" Alias "_BTI708_FieldGetTiltFl@4" (ByRef buf As Integer) As Single
Public Declare Function BTI708_FieldPutAngle Lib "BTI708.DLL" Alias "_BTI708_FieldPutAngle@8" (ByVal value As Integer, ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldPutAngleFl Lib "BTI708.DLL" Alias "_BTI708_FieldPutAngleFl@8" (ByVal angle As Single, ByRef buf As Integer) As Single
Public Declare Function BTI708_FieldPutControlAccept Lib "BTI708.DLL" Alias "_BTI708_FieldPutControlAccept@8" (ByVal value As Integer, ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldPutData Lib "BTI708.DLL" Alias "_BTI708_FieldPutData@12" (ByVal value As Integer, ByVal binnum As Long, ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldPutDataAccept Lib "BTI708.DLL" Alias "_BTI708_FieldPutDataAccept@8" (ByVal value As Integer, ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldPutFaults Lib "BTI708.DLL" Alias "_BTI708_FieldPutFaults@8" (ByVal value As Integer, ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldPutGain Lib "BTI708.DLL" Alias "_BTI708_FieldPutGain@8" (ByVal gain As Long, ByRef buf As Integer) As Long
Public Declare Function BTI708_FieldPutLabel Lib "BTI708.DLL" Alias "_BTI708_FieldPutLabel@8" (ByVal value As Integer, ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldPutMode Lib "BTI708.DLL" Alias "_BTI708_FieldPutMode@8" (ByVal value As Integer, ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldPutRange Lib "BTI708.DLL" Alias "_BTI708_FieldPutRange@8" (ByVal range As Long, ByRef buf As Integer) As Long
Public Declare Function BTI708_FieldPutTilt Lib "BTI708.DLL" Alias "_BTI708_FieldPutTilt@8" (ByVal value As Integer, ByRef buf As Integer) As Integer
Public Declare Function BTI708_FieldPutTiltFl Lib "BTI708.DLL" Alias "_BTI708_FieldPutTiltFl@8" (ByVal tilt As Single, ByRef buf As Integer) As Single
Public Declare Function BTI708_MsgBlockRd Lib "BTI708.DLL" Alias "_BTI708_MsgBlockRd@16" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgBlockWr Lib "BTI708.DLL" Alias "_BTI708_MsgBlockWr@16" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgDataRd Lib "BTI708.DLL" Alias "_BTI708_MsgDataRd@16" (ByRef buf As Integer, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgDataWr Lib "BTI708.DLL" Alias "_BTI708_MsgDataWr@16" (ByRef buf As Integer, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgIsAccessed Lib "BTI708.DLL" Alias "_BTI708_MsgIsAccessed@12" (ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgSyncDefine Lib "BTI708.DLL" Alias "_BTI708_MsgSyncDefine@24" (ByVal enableflag As Long, ByVal syncmask As Integer, ByVal pinpolarity As Integer, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgTriggerDefine Lib "BTI708.DLL" Alias "_BTI708_MsgTriggerDefine@28" (ByVal enableflag As Long, ByVal trigmask As Integer, ByVal trigval As Integer, ByVal pinpolarity As Integer, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgVarDataRd Lib "BTI708.DLL" Alias "_BTI708_MsgVarDataRd@20" (ByRef buf As Integer, ByRef bitcount As Long, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgVarDataWr Lib "BTI708.DLL" Alias "_BTI708_MsgVarDataWr@20" (ByRef buf As Integer, ByVal bitcount As Long, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ParamAmplitudeConfig Lib "BTI708.DLL" Alias "_BTI708_ParamAmplitudeConfig@16" (ByVal configval As Long, ByVal dacval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_RcvBuild Lib "BTI708.DLL" Alias "_BTI708_RcvBuild@20" (ByVal configval As Long, ByVal logfreq As Long, ByVal framecount As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_XmtBuild Lib "BTI708.DLL" Alias "_BTI708_XmtBuild@24" (ByVal configval As Long, ByVal framefreq As Integer, ByVal logfreq As Long, ByVal framecount As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ChConfigEx Lib "BTI708.DLL" Alias "_BTI708_ChConfigEx@16" (ByVal configval As Long, ByVal count As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ChDataCountRd Lib "BTI708.DLL" Alias "_BTI708_ChDataCountRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI708_ChDataCountWr Lib "BTI708.DLL" Alias "_BTI708_ChDataCountWr@12" (ByVal countval As Integer, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI708_DllUsageCount Lib "BTI708.DLL" Alias "_BTI708_DllUsageCount@0" () As Long
Public Declare Sub BTI708_GetChanCount Lib "BTI708.DLL" Alias "_BTI708_GetChanCount@12" (ByRef rcvcount As Long, ByRef xmtcount As Long, ByVal handleval As Long)
Public Declare Function BTI708_HostComm Lib "BTI708.DLL" Alias "_BTI708_HostComm@8" (ByRef lpparam As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_IsChan Lib "BTI708.DLL" Alias "_BTI708_IsChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_IsRcvChan Lib "BTI708.DLL" Alias "_BTI708_IsRcvChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_IsXmtChan Lib "BTI708.DLL" Alias "_BTI708_IsXmtChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgActivityRd Lib "BTI708.DLL" Alias "_BTI708_MsgActivityRd@12" (ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI708_MsgActivityWr Lib "BTI708.DLL" Alias "_BTI708_MsgActivityWr@16" (ByVal value As Integer, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI708_MsgAddr Lib "BTI708.DLL" Alias "_BTI708_MsgAddr@12" (ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgCommRd Lib "BTI708.DLL" Alias "_BTI708_MsgCommRd@16" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgCommWr Lib "BTI708.DLL" Alias "_BTI708_MsgCommWr@16" (ByRef msgfields As MSGFIELDS708, ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgConfig Lib "BTI708.DLL" Alias "_BTI708_MsgConfig@12" (ByVal configval As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgCreate Lib "BTI708.DLL" Alias "_BTI708_MsgCreate@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgOptRd Lib "BTI708.DLL" Alias "_BTI708_MsgOptRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI708_MsgOptWr Lib "BTI708.DLL" Alias "_BTI708_MsgOptWr@12" (ByVal msgopt As Integer, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Sub BTI708_MsgReset Lib "BTI708.DLL" Alias "_BTI708_MsgReset@8" (ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI708_MsgTableCreate Lib "BTI708.DLL" Alias "_BTI708_MsgTableCreate@8" (ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_MsgTableRd Lib "BTI708.DLL" Alias "_BTI708_MsgTableRd@12" (ByVal msgindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI708_MsgTableReset Lib "BTI708.DLL" Alias "_BTI708_MsgTableReset@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Sub BTI708_MsgTableWipe Lib "BTI708.DLL" Alias "_BTI708_MsgTableWipe@8" (ByVal basevaladdr As Long, ByVal handleval As Long)
Public Declare Function BTI708_MsgTableWr Lib "BTI708.DLL" Alias "_BTI708_MsgTableWr@12" (ByVal msgaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_ParamAmplitudeGet Lib "BTI708.DLL" Alias "_BTI708_ParamAmplitudeGet@12" (ByRef dacval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI708_TestProtocol Lib "BTI708.DLL" Alias "_BTI708_TestProtocol@4" (ByVal handleval As Long) As Long

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
'*  Channel configuration options
'*
'**/

Public Const CHCFG708_DEFAULT As Long = &H0  '//Select all default settings (XMT & RCV) (default)
Public Const CHCFG708_NOSWAP As Long = &H0   '//Select 708 bit order (XMT & RCV) (default)
Public Const CHCFG708_SWAP As Long = &H1 '//Select 1553 bit order (XMT & RCV)
Public Const CHCFG708_WORDSYNC As Long = &H0 '//Select resync on words (RCV) (default)
Public Const CHCFG708_BITSYNC As Long = &H2  '//Select resync on every bit (RCV)
Public Const CHCFG708_SELFTEST As Long = &H4 '//Enable internal wraparound (XMT & RCV)
Public Const CHCFG708_SELFTESTOFF As Long = &H0  '//Disable internal wraparound (XMT & RCV) (default)
Public Const CHCFG708_SYNCSEL As Long = &H0  '//Sync output controlled at message level (XMT) (default)
Public Const CHCFG708_SYNCALL As Long = &H8  '//Sync output for all messages (XMT & RCV)
Public Const CHCFG708_ERRSYNCOFF As Long = &H0   '//Disable pulsing of DOUT for errors (RCV) (default)
Public Const CHCFG708_ERRSYNCON As Long = &H10    '//Enable pulsing of DOUT for errors (RCV)
Public Const CHCFG708_EXTTRIG As Long = &H20  '//Enable external trigger for all messages (XMT)
Public Const CHCFG708_EXTOFF As Long = &H0   '//External trigger is enabled on message level (XMT) (default)
Public Const CHCFG708_TRIGNONE As Long = &H0 '//No trigger (XMT) (default)
Public Const CHCFG708_TRIGEXT As Long = &H40  '//Trigger external (XMT)
Public Const CHCFG708_TRIGSTART As Long = &H80    '//Trigger external start (XMT)
Public Const CHCFG708_ACTIVE As Long = &H0   '//Enable channel (XMT & RCV) (default)
Public Const CHCFG708_INACTIVE As Long = &H100 '//Disable channel (XMT & RCV)
Public Const CHCFG708_HIT As Long = &H200  '//Hit counter is enabled for all messages (XMT & RCV)
Public Const CHCFG708_NOHIT As Long = &H0    '//Hit counter is enabled on message level (XMT & RCV) (default)
Public Const CHCFG708_TIMETAG As Long = &H400  '//Enable time-tag for all message records (XMT & RCV)
Public Const CHCFG708_TIMETAGOFF As Long = &H0   '//Time-tag is enabled on message level (XMT & RCV) (default)
Public Const CHCFG708_ELAPSE As Long = &H800   '//Enable elapse time for all messages (XMT & RCV)
Public Const CHCFG708_ELAPSEOFF As Long = &H0    '//Elapse time is enabled on message level (XMT & RCV) (default)
Public Const CHCFG708_MAX As Long = &H1000  '//Enable max repetition rate monitoring for all messages (XMT & RCV)
Public Const CHCFG708_MAXOFF As Long = &H0   '//Repetition rate monitoring is enabled on message level (XMT & RCV) (default)
Public Const CHCFG708_MIN As Long = &H2000  '//Enable min repetition rate monitoring for all messages (XMT & RCV)
Public Const CHCFG708_MINOFF As Long = &H0   '//Repetition rate monitoring is enabled on message level (XMT & RCV) (default)
Public Const CHCFG708_SEQALL As Long = &H80000   '//Record entire channel in sequential record (XMT & RCV)
Public Const CHCFG708_SEQSEL As Long = &H0   '//Sequential record recording is enabled at message level (XMT & RCV) (default)
Public Const CHCFG708_PAUSE As Long = &H1000000    '//Mark channel as paused (XMT & RCV)
Public Const CHCFG708_UNPAUSE As Long = &H0  '//Mark channel as unpaused (XMT & RCV) (default)
Public Const CHCFG708_RCVBUSA As Long = &H0  '//Receive channel will operate on Bus A (RCV) (default)
Public Const CHCFG708_RCVBUSB As Long = &H4000  '//Receive channel will operate on Bus B (RCV)
Public Const CHCFG708_XMTBUSA As Long = &H4000  '//Transmit channel will operate on Bus A (XMT)
Public Const CHCFG708_XMTBUSB As Long = &H0  '//Transmit channel will operate on Bus B (XMT) (default)
Public Const CHCFG708_TERMOFF As Long = &H0  '//Direct coupled termination resistance off (XMT & RCV) (default)
Public Const CHCFG708_TERMON As Long = &H8000   '//Direct coupled termination resistance on (XMT & RCV)
Public Const CHCFG708_FIXBIT As Long = &H0   '//Channel operates with fixed bit length (XMT & RCV) (default)
Public Const CHCFG708_VARBIT As Long = &H10000   '//Channel operates with variable bit length (XMT & RCV)
Public Const CHCFG708_PRESYNCOFF As Long = &H0   '//Pre-sync pulses off (XMT) (default)
Public Const CHCFG708_PRESYNCON As Long = &H20000    '//Pre-sync pulses on (XMT)

'/**
'*
'*  Message configuration options
'*
'**/

Public Const MSGCRT708_DEFAULT As Long = &H0 '//Default settings
Public Const MSGCRT708_NOSEQ As Long = &H0   '//Message will not be recorded in sequential record (default)
Public Const MSGCRT708_SEQ As Long = &H1 '//Message will be recorded in sequential record
Public Const MSGCRT708_NOLOG As Long = &H0   '//Message will not generate event log (default)
Public Const MSGCRT708_LOG As Long = &H2 '//Message will generate event log
Public Const MSGCRT708_NOSKIP As Long = &H0  '//Message will not be skipped (default)
Public Const MSGCRT708_SKIP As Long = &H8    '//Message will be skipped
Public Const MSGCRT708_NOTIMETAG As Long = &H0   '//Message will not record time-tag (default)
Public Const MSGCRT708_TIMETAG As Long = &H10 '//Message will record time-tag
Public Const MSGCRT708_NOELAPSE As Long = &H0    '//Message will not record elapse time (default)
Public Const MSGCRT708_ELAPSE As Long = &H20  '//Message will record elapse time
Public Const MSGCRT708_NOMAX As Long = &H0   '//Message will not record max time (default)
Public Const MSGCRT708_MAX As Long = &H40 '//Message will record max time
Public Const MSGCRT708_NOMIN As Long = &H0   '//Message will not record min time (default)
Public Const MSGCRT708_MIN As Long = &H80 '//Message will record min time
Public Const MSGCRT708_MAXMIN As Long = &HC0  '//Message will record min/max time
Public Const MSGCRT708_NOSYNC As Long = &H0  '//Message will not generate a syncout pulse (default)
Public Const MSGCRT708_SYNC As Long = &H100    '//Message will generate a syncout pulse
Public Const MSGCRT708_NOHIT As Long = &H0   '//Message will not record hit count (default)
Public Const MSGCRT708_HIT As Long = &H400 '//Message will record hit count
Public Const MSGCRT708_NOEXTRIG As Long = &H0    '//Message will not be externally triggered (default)
Public Const MSGCRT708_EXTRIG As Long = &H1000  '//Message will be externally triggered

'/**
'*
'*  Parametric configuration options
'*
'**/

Public Const PARAMCFG708_DEFAULT As Long = &H0   '//Select all default settings (default)
Public Const PARAMCFG708_AMPLON As Long = &H0    '//Enables parametric amplitude control (default)
Public Const PARAMCFG708_AMPLOFF As Long = &H1   '//Disables parametric amplitude control

'/**
'*
'*  Bit fields of the message activity flag.
'*
'**/

Public Const MSGACT708_CHMASK As Long = &HFF00  '//Channel number mask value
Public Const MSGACT708_CHSHIFT As Long = &H8 '//Channel number shift value
Public Const MSGACT708_ERR As Long = &H80 '//Error bit
Public Const MSGACT708_SHORT As Long = &H40   '//Short word error bit
Public Const MSGACT708_LONG As Long = &H20    '//Long word error bit
Public Const MSGACT708_MANCH As Long = &H10   '//Manchester error bit
Public Const MSGACT708_DSYNC As Long = &H8   '//Data sync error bit
Public Const MSGACT708_WORD As Long = &H4    '//Word error bit
Public Const MSGACT708_TO As Long = &H2  '//Time out error bit
Public Const MSGACT708_HIT As Long = &H1 '//Always set

'/**
'*
'*  Channel info fields.
'*
'**/

Public Const INFO708_PARAM As Long = &H1 '//Channel supports parametric control
Public Const INFO708_VARBIT As Long = &H2    '//Channel supports variable bit length mode
