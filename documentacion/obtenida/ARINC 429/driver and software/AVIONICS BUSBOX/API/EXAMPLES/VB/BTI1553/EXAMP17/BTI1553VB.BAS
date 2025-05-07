'/**
'*
'*  BTI1553 WIN32 DRIVER  Version 1.11.0  (06/06/2011)
'*  Copyright (c) 2001-2011
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   BTI1553.BAS -- 32-bit
'*                       BTI1553 Driver Include Header File.
'*
'**/

'/**
'*
'*  Structs used by the BTI1553 Driver.
'*
'**/

Public Type XMITFIELDS1553
	ctrlflags As Long	'//User writes message configuration optionvals
	flag1 As Integer	'//Card writes message flag 1
	flag2 As Integer	'//Card writes message flag 2
	errflags As Integer	'//Card writes errorval flags
	actflags As Integer	'//Card writes activity flags
	resptime1 As Integer	'//Card writes response time 1
	resptime2 As Integer	'//Card writes response time 2
	datacount As Integer	'//Card writes data count
	extflag As Integer	'//Driver writes external flags
	timetag As Long	'//Card writes time tag
	elapsetime As Long	'//Card writes elapsed time
	preaddr As Long	'//Driver writes pre-proc address
	postaddr As Long	'//Driver writes post-proc address
	timetagh As Long	'//Card writes extended timetag
	resv18 As Integer	'//Reserved field
	resv19 As Integer	'//Reserved field
	cwd1 As Integer	'//User writes command word 1
	cwd2 As Integer	'//User writes command word 2
	swd1 As Integer	'//Card writes status word 1
	swd2 As Integer	'//Card writes status word 2
	data(0 to 31) As Integer	'//User writes data words
	extra(0 to 7) As Integer	'//User writes extra words
End Type

Public Type MSGFIELDS1553
	msgflag As Integer	'//Driver writes message flags
	msgopt As Integer	'//Driver writes message optionvals
	msgerr As Integer	'//Card writes message errorvals
	msgact As Integer	'//Card writes message activity
	resptime1 As Integer	'//Card writes response time 1
	resptime2 As Integer	'//Card writes response time 2
	datacount As Integer	'//Card writes data count
	extflag As Integer	'//Driver writes external flags
	timetag_hitcount As Long	'//Card writes time tag - '//Card writes hit count
	elapsetime_mintime_maxtime As Long	'//Card writes elapsed time - '//Card writes min time - '//Card writes max time
	preaddr As Long	'//Driver writes pre-proc address
	postaddr As Long	'//Driver writes post-proc address
	timetagh As Long	'//Card writes extended timetag
	resv18 As Integer	'//Reserved field
	resv19 As Integer	'//Reserved field
	cwd1 As Integer	'//Card/User writes command word 1 (R/T)
	cwd2 As Integer	'//Card/User writes command word 2 (R/T)
	swd1 As Integer	'//Card writes status word 1
	swd2 As Integer	'//Card writes status word 2
	data(0 to 31) As Integer	'//User/Card writes data words (R/T)
	extra(0 to 7) As Integer	'//User/Card writes extra words (R/T)
End Type

'/**
'*
'*  BTI1553 Driver functions.
'*
'**/

'/**
'*
'*  Internal functions used by the BTI1553 Driver.
'*
'**/

Public Declare Function BTI1553_BCConfig Lib "BTI1553.DLL" Alias "_BTI1553_BCConfig@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCConfigEx Lib "BTI1553.DLL" Alias "_BTI1553_BCConfigEx@16" (ByVal configval As Long, ByVal count As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCConfigMsg Lib "BTI1553.DLL" Alias "_BTI1553_BCConfigMsg@12" (ByVal configval As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCCreateList Lib "BTI1553.DLL" Alias "_BTI1553_BCCreateList@28" (ByVal listconfigval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal cwd1 As Integer, ByVal cwd2 As Integer, ByRef data As Integer, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCCreateMsg Lib "BTI1553.DLL" Alias "_BTI1553_BCCreateMsg@20" (ByVal configval As Long, ByVal cwd1 As Integer, ByVal cwd2 As Integer, ByRef data As Integer, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_BCPause Lib "BTI1553.DLL" Alias "_BTI1553_BCPause@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_BCPauseCheck Lib "BTI1553.DLL" Alias "_BTI1553_BCPauseCheck@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_BCResume Lib "BTI1553.DLL" Alias "_BTI1553_BCResume@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_BCSchedAgain Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedAgain@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedBranch Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedBranch@16" (ByVal condition As Long, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedBranchUpdate Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedBranchUpdate@16" (ByVal destindex As Long, ByVal opcodeindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedBuild Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedBuild@20" (ByVal nummsgs As Integer, ByRef msgaddr As Long, ByRef freq As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedCall Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedCall@16" (ByVal condition As Long, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedCallUpdate Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedCallUpdate@16" (ByVal destindex As Long, ByVal opcodeindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedEntry Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedEntry@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedFrame Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedFrame@12" (ByVal timeval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedFrameEnd Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedFrameEnd@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedFrameStart Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedFrameStart@12" (ByVal timeval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedGap Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedGap@12" (ByVal gapval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedHalt Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedHalt@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedLog Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedLog@16" (ByVal condition As Long, ByVal tagval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedMsg Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedMsg@12" (ByVal msgaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedPause Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedPause@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedPulse Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedPulse@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedPulse0 Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedPulse0@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedPulse1 Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedPulse1@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedRestart Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedRestart@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedRetry Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedRetry@16" (ByVal condition As Long, ByVal retries As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedReturn Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedReturn@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSetDefaultGap Lib "BTI1553.DLL" Alias "_BTI1553_BCSetDefaultGap@12" (ByVal gapval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSetTimeout Lib "BTI1553.DLL" Alias "_BTI1553_BCSetTimeout@12" (ByVal timeoutval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSyncDefine Lib "BTI1553.DLL" Alias "_BTI1553_BCSyncDefine@20" (ByVal enableflag As Long, ByVal syncmask As Integer, ByVal pinpolarity As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCTransmitMsg Lib "BTI1553.DLL" Alias "_BTI1553_BCTransmitMsg@12" (ByRef xmitfieldsval As XMITFIELDS1553, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCTriggerDefine Lib "BTI1553.DLL" Alias "_BTI1553_BCTriggerDefine@24" (ByVal enableflag As Long, ByVal trigmask As Integer, ByVal trigval As Integer, ByVal pinpolarity As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_ChGetCount Lib "BTI1553.DLL" Alias "_BTI1553_ChGetCount@20" (ByRef a_count As Long, ByRef b4_count As Long, ByRef b32_count As Long, ByRef c_count As Long, ByVal handleval As Long)
Public Declare Function BTI1553_ChGetInfo Lib "BTI1553.DLL" Alias "_BTI1553_ChGetInfo@12" (ByVal infotype As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIs1553 Lib "BTI1553.DLL" Alias "_BTI1553_ChIs1553@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsA Lib "BTI1553.DLL" Alias "_BTI1553_ChIsA@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsB32 Lib "BTI1553.DLL" Alias "_BTI1553_ChIsB32@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsB4 Lib "BTI1553.DLL" Alias "_BTI1553_ChIsB4@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsBM Lib "BTI1553.DLL" Alias "_BTI1553_ChIsBM@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsC Lib "BTI1553.DLL" Alias "_BTI1553_ChIsC@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsD Lib "BTI1553.DLL" Alias "_BTI1553_ChIsD@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsM Lib "BTI1553.DLL" Alias "_BTI1553_ChIsM@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsRM Lib "BTI1553.DLL" Alias "_BTI1553_ChIsRM@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsS Lib "BTI1553.DLL" Alias "_BTI1553_ChIsS@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsX Lib "BTI1553.DLL" Alias "_BTI1553_ChIsX@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChStart Lib "BTI1553.DLL" Alias "_BTI1553_ChStart@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChStop Lib "BTI1553.DLL" Alias "_BTI1553_ChStop@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdMaxLoopRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdMaxLoopRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_CmdMaxLoopWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdMaxLoopWr@12" (ByVal countval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_CmdShotRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdShotRd@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdShotWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdShotWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdSkipRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdSkipRd@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdSkipWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdSkipWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdStepRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdStepRd@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdStepWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdStepWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ErrorCtrl Lib "BTI1553.DLL" Alias "_BTI1553_ErrorCtrl@12" (ByVal ctrlval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ErrorDefine Lib "BTI1553.DLL" Alias "_BTI1553_ErrorDefine@28" (ByVal defineval As Long, ByVal errvalue As Integer, ByVal countval As Long, ByVal wordpos As Integer, ByVal bitpos As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ErrorSent Lib "BTI1553.DLL" Alias "_BTI1553_ErrorSent@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ErrorTagBC Lib "BTI1553.DLL" Alias "_BTI1553_ErrorTagBC@16" (ByVal tagval As Long, ByVal msgaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ErrorTagRT Lib "BTI1553.DLL" Alias "_BTI1553_ErrorTagRT@28" (ByVal tagval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ErrorTriggerDefine Lib "BTI1553.DLL" Alias "_BTI1553_ErrorTriggerDefine@24" (ByVal enableflag As Long, ByVal trigmask As Integer, ByVal trigval As Integer, ByVal pinpolarity As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListBlockRd Lib "BTI1553.DLL" Alias "_BTI1553_ListBlockRd@12" (ByRef buf As Integer, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListBlockWr Lib "BTI1553.DLL" Alias "_BTI1553_ListBlockWr@12" (ByRef buf As Integer, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListDataRd Lib "BTI1553.DLL" Alias "_BTI1553_ListDataRd@16" (ByRef buf As Integer, ByVal count As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListDataWr Lib "BTI1553.DLL" Alias "_BTI1553_ListDataWr@16" (ByRef buf As Integer, ByVal count As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListMultiBlockRd Lib "BTI1553.DLL" Alias "_BTI1553_ListMultiBlockRd@16" (ByRef buf As Integer, ByRef blkcountptr As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListMultiBlockWr Lib "BTI1553.DLL" Alias "_BTI1553_ListMultiBlockWr@16" (ByRef buf As Integer, ByVal blkcount As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MonConfig Lib "BTI1553.DLL" Alias "_BTI1553_MonConfig@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MonFilterSA Lib "BTI1553.DLL" Alias "_BTI1553_MonFilterSA@28" (ByVal taval As Long, ByVal rcvsamask As Long, ByVal xmtsamask As Long, ByVal rcvmcmask As Long, ByVal xmtmcmask As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MonFilterTA Lib "BTI1553.DLL" Alias "_BTI1553_MonFilterTA@12" (ByVal tamask As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgBlockRd Lib "BTI1553.DLL" Alias "_BTI1553_MsgBlockRd@12" (ByRef buf As MSGFIELDS1553, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgBlockWr Lib "BTI1553.DLL" Alias "_BTI1553_MsgBlockWr@12" (ByRef buf As MSGFIELDS1553, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_MsgDataRd Lib "BTI1553.DLL" Alias "_BTI1553_MsgDataRd@16" (ByRef buf As Integer, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Sub BTI1553_MsgDataWr Lib "BTI1553.DLL" Alias "_BTI1553_MsgDataWr@16" (ByRef buf As Integer, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI1553_MsgFieldRd Lib "BTI1553.DLL" Alias "_BTI1553_MsgFieldRd@12" (ByVal fieldtype As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgFieldWr Lib "BTI1553.DLL" Alias "_BTI1553_MsgFieldWr@16" (ByVal fieldval As Long, ByVal fieldtype As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_MsgGroupRd Lib "BTI1553.DLL" Alias "_BTI1553_MsgGroupRd@16" (ByVal nummsgs As Long, ByRef msgflds As MSGFIELDS1553, ByRef msgaddrptr As Long, ByVal handleval As Long)
Public Declare Sub BTI1553_MsgGroupWr Lib "BTI1553.DLL" Alias "_BTI1553_MsgGroupWr@16" (ByVal nummsgs As Long, ByRef msgflds As MSGFIELDS1553, ByRef msgaddrptr As Long, ByVal handleval As Long)
Public Declare Function BTI1553_MsgSkipRd Lib "BTI1553.DLL" Alias "_BTI1553_MsgSkipRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_MsgSkipWr Lib "BTI1553.DLL" Alias "_BTI1553_MsgSkipWr@12" (ByVal skip As Long, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI1553_MsgSyncDefine Lib "BTI1553.DLL" Alias "_BTI1553_MsgSyncDefine@20" (ByVal enableflag As Long, ByVal syncmask As Integer, ByVal pinpolarity As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgTriggerDefine Lib "BTI1553.DLL" Alias "_BTI1553_MsgTriggerDefine@24" (ByVal enableflag As Long, ByVal trigmask As Integer, ByVal trigval As Integer, ByVal pinpolarity As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ParamAmplitudeConfig Lib "BTI1553.DLL" Alias "_BTI1553_ParamAmplitudeConfig@16" (ByVal configval As Long, ByVal dacval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ParamAmplitudeGet Lib "BTI1553.DLL" Alias "_BTI1553_ParamAmplitudeGet@12" (ByRef dacval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_PlayConfig Lib "BTI1553.DLL" Alias "_BTI1553_PlayConfig@16" (ByVal configval As Long, ByVal tamask As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_PlayStatus Lib "BTI1553.DLL" Alias "_BTI1553_PlayStatus@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_PlayWr Lib "BTI1553.DLL" Alias "_BTI1553_PlayWr@16" (ByRef buf As Integer, ByVal bufcount As Integer, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI1553_RTConfig Lib "BTI1553.DLL" Alias "_BTI1553_RTConfig@16" (ByVal configval As Long, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTCreateList Lib "BTI1553.DLL" Alias "_BTI1553_RTCreateList@36" (ByVal listconfigval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTCreateMsg Lib "BTI1553.DLL" Alias "_BTI1553_RTCreateMsg@28" (ByVal configval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTGetMsg Lib "BTI1553.DLL" Alias "_BTI1553_RTGetMsg@24" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTReset Lib "BTI1553.DLL" Alias "_BTI1553_RTReset@12" (ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTResponseTimeSet Lib "BTI1553.DLL" Alias "_BTI1553_RTResponseTimeSet@16" (ByVal resptime As Long, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTSetMode Lib "BTI1553.DLL" Alias "_BTI1553_RTSetMode@16" (ByVal configval As Long, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTSWDRd Lib "BTI1553.DLL" Alias "_BTI1553_RTSWDRd@12" (ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI1553_RTSWDWr Lib "BTI1553.DLL" Alias "_BTI1553_RTSWDWr@16" (ByVal swdval As Integer, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTSyncDefine Lib "BTI1553.DLL" Alias "_BTI1553_RTSyncDefine@40" (ByVal enableflag As Long, ByVal syncmask As Integer, ByVal pinpolarity As Integer, ByVal taval As Long, ByVal rcvsamask As Long, ByVal xmtsamask As Long, ByVal rcvmcmask As Long, ByVal xmtmcmask As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ValPackCWD Lib "BTI1553.DLL" Alias "_BTI1553_ValPackCWD@16" (ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal wcval As Long) As Integer
Public Declare Sub BTI1553_ValUnpackCWD Lib "BTI1553.DLL" Alias "_BTI1553_ValUnpackCWD@20" (ByVal cwdval As Integer, ByRef taval As Long, ByRef trflag As Long, ByRef saval As Long, ByRef wcval As Long)
Public Declare Function BTI1553_BCCreateListEx Lib "BTI1553.DLL" Alias "_BTI1553_BCCreateListEx@32" (ByVal listconfigval As Long, ByVal skipval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal cwd1 As Integer, ByVal cwd2 As Integer, ByRef data As Integer, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCCreateListExx Lib "BTI1553.DLL" Alias "_BTI1553_BCCreateListExx@32" (ByVal listconfigval As Long, ByVal skipval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal cwd1 As Integer, ByVal cwd2 As Integer, ByRef data As Integer, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCGetMsg Lib "BTI1553.DLL" Alias "_BTI1553_BCGetMsg@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCIMGapRd Lib "BTI1553.DLL" Alias "_BTI1553_BCIMGapRd@12" (ByRef gapval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCIMGapWr Lib "BTI1553.DLL" Alias "_BTI1553_BCIMGapWr@12" (ByVal gapval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedBranchEx Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedBranchEx@28" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal opcode As Integer, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedCallEx Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedCallEx@28" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal opcode As Integer, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedLogEx Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedLogEx@28" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal opcode As Integer, ByVal tagval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedNop Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedNop@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedRetryEx Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedRetryEx@28" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal retryflag As Integer, ByVal retries As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSchedUser Lib "BTI1553.DLL" Alias "_BTI1553_BCSchedUser@12" (ByVal useraddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCSetEntry Lib "BTI1553.DLL" Alias "_BTI1553_BCSetEntry@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCTransmitMsgBlkEx Lib "BTI1553.DLL" Alias "_BTI1553_BCTransmitMsgBlkEx@20" (ByVal writeflag As Long, ByVal count As Long, ByRef xmitfieldsval As XMITFIELDS1553, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCTransmitMsgBlkInit Lib "BTI1553.DLL" Alias "_BTI1553_BCTransmitMsgBlkInit@12" (ByVal maxcount As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCTransmitMsgBlkRd Lib "BTI1553.DLL" Alias "_BTI1553_BCTransmitMsgBlkRd@16" (ByVal count As Long, ByRef xmitfieldsval As XMITFIELDS1553, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BCTransmitMsgBlkWr Lib "BTI1553.DLL" Alias "_BTI1553_BCTransmitMsgBlkWr@16" (ByVal count As Long, ByRef xmitfieldsval As XMITFIELDS1553, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BlkAddr Lib "BTI1553.DLL" Alias "_BTI1553_BlkAddr@12" (ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI1553_BlkOptRd Lib "BTI1553.DLL" Alias "_BTI1553_BlkOptRd@12" (ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI1553_BlkOptWr Lib "BTI1553.DLL" Alias "_BTI1553_BlkOptWr@16" (ByVal rtopt As Integer, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BlkPtrRd Lib "BTI1553.DLL" Alias "_BTI1553_BlkPtrRd@12" (ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_BlkPtrWr Lib "BTI1553.DLL" Alias "_BTI1553_BlkPtrWr@16" (ByVal descaddr As Long, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_BlkRd Lib "BTI1553.DLL" Alias "_BTI1553_BlkRd@16" (ByRef block As Integer, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BlkReset Lib "BTI1553.DLL" Alias "_BTI1553_BlkReset@12" (ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BlkSWDRd Lib "BTI1553.DLL" Alias "_BTI1553_BlkSWDRd@12" (ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI1553_BlkSWDWr Lib "BTI1553.DLL" Alias "_BTI1553_BlkSWDWr@16" (ByVal swdval As Integer, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BlkWipe Lib "BTI1553.DLL" Alias "_BTI1553_BlkWipe@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_BlkWr Lib "BTI1553.DLL" Alias "_BTI1553_BlkWr@16" (ByRef block As Integer, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChConfig Lib "BTI1553.DLL" Alias "_BTI1553_ChConfig@20" (ByVal enableflag As Long, ByVal typeval As Long, ByVal taval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ChIsRunning Lib "BTI1553.DLL" Alias "_BTI1553_ChIsRunning@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdAddr Lib "BTI1553.DLL" Alias "_BTI1553_CmdAddr@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdAlloc Lib "BTI1553.DLL" Alias "_BTI1553_CmdAlloc@8" (ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdAllocEx Lib "BTI1553.DLL" Alias "_BTI1553_CmdAllocEx@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdBaseRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdBaseRd@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_CmdBaseWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdBaseWr@12" (ByVal addrval As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_CmdClear Lib "BTI1553.DLL" Alias "_BTI1553_CmdClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdCountRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdCountRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_CmdCountWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdCountWr@12" (ByVal countval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_CmdCtrlRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdCtrlRd@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_CmdCtrlWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdCtrlWr@16" (ByVal ctrlval As Integer, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_CmdCurrRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdCurrRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_CmdCurrWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdCurrWr@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Sub BTI1553_CmdInit Lib "BTI1553.DLL" Alias "_BTI1553_CmdInit@8" (ByVal opcode As Integer, ByRef block As Integer)
Public Declare Function BTI1553_CmdInsert Lib "BTI1553.DLL" Alias "_BTI1553_CmdInsert@12" (ByRef block As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_CmdRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdRd@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_CmdRestart Lib "BTI1553.DLL" Alias "_BTI1553_CmdRestart@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Sub BTI1553_CmdStackClr Lib "BTI1553.DLL" Alias "_BTI1553_CmdStackClr@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_CmdStartRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdStartRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_CmdStartWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdStartWr@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_CmdTotalRd Lib "BTI1553.DLL" Alias "_BTI1553_CmdTotalRd@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_CmdTotalWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdTotalWr@12" (ByVal countval As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_CmdWr Lib "BTI1553.DLL" Alias "_BTI1553_CmdWr@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_DescAddr Lib "BTI1553.DLL" Alias "_BTI1553_DescAddr@24" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_DescAlloc Lib "BTI1553.DLL" Alias "_BTI1553_DescAlloc@4" (ByVal handleval As Long) As Long
Public Declare Function BTI1553_DescConfig Lib "BTI1553.DLL" Alias "_BTI1553_DescConfig@28" (ByVal configval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_DescConfigAll Lib "BTI1553.DLL" Alias "_BTI1553_DescConfigAll@16" (ByVal configval As Long, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_DescOptRd Lib "BTI1553.DLL" Alias "_BTI1553_DescOptRd@24" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_DescOptWr Lib "BTI1553.DLL" Alias "_BTI1553_DescOptWr@28" (ByVal descopt As Integer, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_DescPtrRd Lib "BTI1553.DLL" Alias "_BTI1553_DescPtrRd@24" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_DescPtrWr Lib "BTI1553.DLL" Alias "_BTI1553_DescPtrWr@28" (ByVal msgaddr As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_DescRd Lib "BTI1553.DLL" Alias "_BTI1553_DescRd@28" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByRef desc As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_DescWr Lib "BTI1553.DLL" Alias "_BTI1553_DescWr@28" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByRef desc As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_DllUsageCount Lib "BTI1553.DLL" Alias "_BTI1553_DllUsageCount@0" () As Long
Public Declare Function BTI1553_ErrorIsTaggedBC Lib "BTI1553.DLL" Alias "_BTI1553_ErrorIsTaggedBC@12" (ByVal msgaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ErrorIsTaggedRT Lib "BTI1553.DLL" Alias "_BTI1553_ErrorIsTaggedRT@24" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ErrorResponse Lib "BTI1553.DLL" Alias "_BTI1553_ErrorResponse@12" (ByVal responseval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_ErrorSync Lib "BTI1553.DLL" Alias "_BTI1553_ErrorSync@12" (ByVal value As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI1553_ErrorTimeout Lib "BTI1553.DLL" Alias "_BTI1553_ErrorTimeout@12" (ByVal timeoutval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_HostComm Lib "BTI1553.DLL" Alias "_BTI1553_HostComm@8" (ByRef lpparam As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_IsChan Lib "BTI1553.DLL" Alias "_BTI1553_IsChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListAddr Lib "BTI1553.DLL" Alias "_BTI1553_ListAddr@12" (ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListAddrEx Lib "BTI1553.DLL" Alias "_BTI1553_ListAddrEx@16" (ByVal index As Long, ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListBlockRdEx Lib "BTI1553.DLL" Alias "_BTI1553_ListBlockRdEx@16" (ByRef buf As Integer, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListBlockWrEx Lib "BTI1553.DLL" Alias "_BTI1553_ListBlockWrEx@16" (ByRef buf As Integer, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListClear Lib "BTI1553.DLL" Alias "_BTI1553_ListClear@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListConfig Lib "BTI1553.DLL" Alias "_BTI1553_ListConfig@16" (ByVal configval As Long, ByVal count As Long, ByVal skipval As Integer, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListConfigEx Lib "BTI1553.DLL" Alias "_BTI1553_ListConfigEx@16" (ByVal configval As Long, ByVal count As Long, ByVal skipval As Integer, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListDataRdEx Lib "BTI1553.DLL" Alias "_BTI1553_ListDataRdEx@20" (ByRef buf As Integer, ByVal count As Long, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListDataWrEx Lib "BTI1553.DLL" Alias "_BTI1553_ListDataWrEx@20" (ByRef buf As Integer, ByVal count As Long, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListInit Lib "BTI1553.DLL" Alias "_BTI1553_ListInit@12" (ByVal listaddr As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListNextRd Lib "BTI1553.DLL" Alias "_BTI1553_ListNextRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ListNextWr Lib "BTI1553.DLL" Alias "_BTI1553_ListNextWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_ListPostRd Lib "BTI1553.DLL" Alias "_BTI1553_ListPostRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Sub BTI1553_ListPostWr Lib "BTI1553.DLL" Alias "_BTI1553_ListPostWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Sub BTI1553_ListPreRd Lib "BTI1553.DLL" Alias "_BTI1553_ListPreRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Sub BTI1553_ListPreWr Lib "BTI1553.DLL" Alias "_BTI1553_ListPreWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Function BTI1553_ListStatus Lib "BTI1553.DLL" Alias "_BTI1553_ListStatus@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_ModeIsBC Lib "BTI1553.DLL" Alias "_BTI1553_ModeIsBC@4" (ByVal chanflag As Integer) As Long
Public Declare Function BTI1553_ModeIsMon Lib "BTI1553.DLL" Alias "_BTI1553_ModeIsMon@4" (ByVal chanflag As Integer) As Long
Public Declare Function BTI1553_ModeIsNotBC Lib "BTI1553.DLL" Alias "_BTI1553_ModeIsNotBC@4" (ByVal chanflag As Integer) As Long
Public Declare Function BTI1553_ModeIsNotMon Lib "BTI1553.DLL" Alias "_BTI1553_ModeIsNotMon@4" (ByVal chanflag As Integer) As Long
Public Declare Function BTI1553_ModeIsNotPlay Lib "BTI1553.DLL" Alias "_BTI1553_ModeIsNotPlay@4" (ByVal chanflag As Integer) As Long
Public Declare Function BTI1553_ModeIsNotRT Lib "BTI1553.DLL" Alias "_BTI1553_ModeIsNotRT@4" (ByVal chanflag As Integer) As Long
Public Declare Function BTI1553_ModeIsNotSerial Lib "BTI1553.DLL" Alias "_BTI1553_ModeIsNotSerial@4" (ByVal chanflag As Integer) As Long
Public Declare Function BTI1553_ModeIsPlay Lib "BTI1553.DLL" Alias "_BTI1553_ModeIsPlay@4" (ByVal chanflag As Integer) As Long
Public Declare Function BTI1553_ModeIsRT Lib "BTI1553.DLL" Alias "_BTI1553_ModeIsRT@4" (ByVal chanflag As Integer) As Long
Public Declare Function BTI1553_ModeIsSerial Lib "BTI1553.DLL" Alias "_BTI1553_ModeIsSerial@4" (ByVal chanflag As Integer) As Long
Public Declare Function BTI1553_MonConfigEx Lib "BTI1553.DLL" Alias "_BTI1553_MonConfigEx@20" (ByVal configval As Long, ByVal moncount As Long, ByVal cardnum As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MonFilterSAEx Lib "BTI1553.DLL" Alias "_BTI1553_MonFilterSAEx@28" (ByVal taval As Long, ByVal rcvsamask As Long, ByVal xmtsamask As Long, ByVal rcvmcmask As Long, ByVal xmtmcmask As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgCheck Lib "BTI1553.DLL" Alias "_BTI1553_MsgCheck@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI1553_MsgCommRd Lib "BTI1553.DLL" Alias "_BTI1553_MsgCommRd@12" (ByRef buf As MSGFIELDS1553, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgCommWr Lib "BTI1553.DLL" Alias "_BTI1553_MsgCommWr@12" (ByRef buf As MSGFIELDS1553, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgConfig Lib "BTI1553.DLL" Alias "_BTI1553_MsgConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgConfigEx Lib "BTI1553.DLL" Alias "_BTI1553_MsgConfigEx@12" (ByVal configval As Long, ByVal cwd As Integer, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgCWD1Rd Lib "BTI1553.DLL" Alias "_BTI1553_MsgCWD1Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_MsgCWD1Wr Lib "BTI1553.DLL" Alias "_BTI1553_MsgCWD1Wr@12" (ByVal cwd1 As Integer, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI1553_MsgCWD2Rd Lib "BTI1553.DLL" Alias "_BTI1553_MsgCWD2Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_MsgCWD2Wr Lib "BTI1553.DLL" Alias "_BTI1553_MsgCWD2Wr@12" (ByVal cwd2 As Integer, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI1553_MsgErrorRd Lib "BTI1553.DLL" Alias "_BTI1553_MsgErrorRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_MsgErrorWr Lib "BTI1553.DLL" Alias "_BTI1553_MsgErrorWr@12" (ByVal value As Integer, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI1553_MsgFlagRd Lib "BTI1553.DLL" Alias "_BTI1553_MsgFlagRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_MsgFlagWr Lib "BTI1553.DLL" Alias "_BTI1553_MsgFlagWr@12" (ByVal msgflag As Integer, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI1553_MsgIsAccessed Lib "BTI1553.DLL" Alias "_BTI1553_MsgIsAccessed@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgOptRd Lib "BTI1553.DLL" Alias "_BTI1553_MsgOptRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI1553_MsgOptWr Lib "BTI1553.DLL" Alias "_BTI1553_MsgOptWr@12" (ByVal msgopt As Integer, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI1553_MsgReset Lib "BTI1553.DLL" Alias "_BTI1553_MsgReset@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgResetEx Lib "BTI1553.DLL" Alias "_BTI1553_MsgResetEx@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_MsgSWD1Rd Lib "BTI1553.DLL" Alias "_BTI1553_MsgSWD1Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI1553_MsgSWD2Rd Lib "BTI1553.DLL" Alias "_BTI1553_MsgSWD2Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI1553_PlayClear Lib "BTI1553.DLL" Alias "_BTI1553_PlayClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_PlayConfigEx Lib "BTI1553.DLL" Alias "_BTI1553_PlayConfigEx@20" (ByVal configval As Long, ByVal playcount As Long, ByVal tamask As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_PlayCounterWr Lib "BTI1553.DLL" Alias "_BTI1553_PlayCounterWr@12" (ByVal totalcount As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_PlayStatusEx Lib "BTI1553.DLL" Alias "_BTI1553_PlayStatusEx@12" (ByRef totalcount As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_PlayWrEx Lib "BTI1553.DLL" Alias "_BTI1553_PlayWrEx@16" (ByRef buf As Integer, ByVal bufcount As Integer, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI1553_RTConfigEx Lib "BTI1553.DLL" Alias "_BTI1553_RTConfigEx@16" (ByVal configval As Long, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTConfigExx Lib "BTI1553.DLL" Alias "_BTI1553_RTConfigExx@16" (ByVal configval As Long, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTCreateListEx Lib "BTI1553.DLL" Alias "_BTI1553_RTCreateListEx@40" (ByVal listconfigval As Long, ByVal skipval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTCreateListExx Lib "BTI1553.DLL" Alias "_BTI1553_RTCreateListExx@40" (ByVal listconfigval As Long, ByVal skipval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTResponseTimeRd Lib "BTI1553.DLL" Alias "_BTI1553_RTResponseTimeRd@16" (ByRef timeval As Integer, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTResponseTimeWr Lib "BTI1553.DLL" Alias "_BTI1553_RTResponseTimeWr@16" (ByVal timeval As Integer, ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_RTStatus Lib "BTI1553.DLL" Alias "_BTI1553_RTStatus@12" (ByVal taval As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI1553_SABlkWr Lib "BTI1553.DLL" Alias "_BTI1553_SABlkWr@16" (ByVal taval As Long, ByVal saval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SABlkWrEx Lib "BTI1553.DLL" Alias "_BTI1553_SABlkWrEx@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SchedBuild Lib "BTI1553.DLL" Alias "_BTI1553_SchedBuild@20" (ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef freq As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SchedBuildEx Lib "BTI1553.DLL" Alias "_BTI1553_SchedBuildEx@32" (ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef freq As Long, ByRef period As Long, ByRef buf As Long, ByVal bufsize As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SchedBuildExx Lib "BTI1553.DLL" Alias "_BTI1553_SchedBuildExx@32" (ByVal frametime As Long, ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef period As Long, ByRef buf As Long, ByVal bufsize As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SchedCalc Lib "BTI1553.DLL" Alias "_BTI1553_SchedCalc@12" (ByRef msgaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI1553_SchedDisplay Lib "BTI1553.DLL" Alias "_BTI1553_SchedDisplay@8" (ByVal nummsgs As Long, ByRef count As Long)
Public Declare Sub BTI1553_SchedHook Lib "BTI1553.DLL" Alias "_BTI1553_SchedHook@8" (ByVal index As Long, ByRef ptr As Long)
Public Declare Function BTI1553_SchedInsEnd Lib "BTI1553.DLL" Alias "_BTI1553_SchedInsEnd@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SchedInsMsg Lib "BTI1553.DLL" Alias "_BTI1553_SchedInsMsg@16" (ByVal index As Long, ByRef msgaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SchedInsStart Lib "BTI1553.DLL" Alias "_BTI1553_SchedInsStart@16" (ByVal frametime As Long, ByVal count As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SchedMaxval Lib "BTI1553.DLL" Alias "_BTI1553_SchedMaxval@8" (ByRef arrayval As Long, ByVal arrayvalcount As Long) As Long
Public Declare Function BTI1553_SchedMinval Lib "BTI1553.DLL" Alias "_BTI1553_SchedMinval@8" (ByRef arrayval As Long, ByVal arrayvalcount As Long) As Long
Public Declare Function BTI1553_SerialClear Lib "BTI1553.DLL" Alias "_BTI1553_SerialClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SerialConfig Lib "BTI1553.DLL" Alias "_BTI1553_SerialConfig@16" (ByVal configval As Long, ByVal count As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SerialConfigEx Lib "BTI1553.DLL" Alias "_BTI1553_SerialConfigEx@16" (ByVal configval As Long, ByVal count As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SerialStatus Lib "BTI1553.DLL" Alias "_BTI1553_SerialStatus@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_SerialWr Lib "BTI1553.DLL" Alias "_BTI1553_SerialWr@12" (ByRef buf As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI1553_TestProtocol Lib "BTI1553.DLL" Alias "_BTI1553_TestProtocol@4" (ByVal handleval As Long) As Long
Public Declare Function BTI1553_ValPackRTCWD Lib "BTI1553.DLL" Alias "_BTI1553_ValPackRTCWD@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal count As Long) As Integer
Public Declare Sub BTI1553_ValUnpackRTCWD Lib "BTI1553.DLL" Alias "_BTI1553_ValUnpackRTCWD@28" (ByVal cwd As Integer, ByRef bcastflag As Long, ByRef mcflag As Long, ByRef taval As Long, ByRef trflag As Long, ByRef saval As Long, ByRef count As Long)

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

'/**
'*
'*  Bus controller configuration options
'*
'**/

Public Const BCCFG1553_DEFAULT As Long = &H0 '//Select all default settings
Public Const BCCFG1553_ENABLE As Long = &H0  '//Enable bus controller (default)
Public Const BCCFG1553_DISABLE As Long = &H1 '//Disable bus controller
Public Const BCCFG1553_TRIGNONE As Long = &H0    '//No trigger (default)
Public Const BCCFG1553_TRIGEXT As Long = &H10 '//Trigger external
Public Const BCCFG1553_TRIGSTART As Long = &H20   '//Trigger external start
Public Const BCCFG1553_NOLOGHALT As Long = &H0   '//Do not generate event log on halt (default)
Public Const BCCFG1553_LOGHALT As Long = &H100 '//Generate event log on halt
Public Const BCCFG1553_NOLOGPAUSE As Long = &H0  '//Do not generate event log on pause (default)
Public Const BCCFG1553_LOGPAUSE As Long = &H200    '//Generate event log on pause
Public Const BCCFG1553_NOLOOPMAX As Long = &H0   '//Disable maximum loop count (default)
Public Const BCCFG1553_LOOPMAX As Long = &H1000 '//Enable maximum loop count
Public Const BCCFG1553_NOSTEP As Long = &H0  '//Disable single stepping (default)
Public Const BCCFG1553_STEP As Long = &H2000    '//Enable single stepping
Public Const BCCFG1553_MC01 As Long = &H0    '//Select SA=00000 or SA=11111 for mode codes (default)
Public Const BCCFG1553_MC1 As Long = &H1000000 '//Select SA=11111 for mode codes
Public Const BCCFG1553_MC0 As Long = &H2000000 '//Select SA=00000 for mode codes
Public Const BCCFG1553_MCNONE As Long = &H3000000  '//Disable mode codes
Public Const BCCFG1553_TERMOFF As Long = &H0 '//Direct coupled termination resistance off (Bus A & B) (default)
Public Const BCCFG1553_TERMONA As Long = &H4000000 '//Direct coupled termination resistance on  (Bus A)
Public Const BCCFG1553_TERMONB As Long = &H8000000 '//Direct coupled termination resistance on  (Bus B)
Public Const BCCFG1553_TERMONAB As Long = &HC000000    '//Direct coupled termination resistance on  (Bus A & B)
Public Const BCCFG1553_SYNCSEL As Long = &H0 '//Selective sync (default)
Public Const BCCFG1553_SYNCALL As Long = &H40000000 '//Sync on all messages
Public Const BCCFG1553_PAUSE As Long = &H400   '//Mark channel as paused
Public Const BCCFG1553_UNPAUSE As Long = &H0 '//Mark channel as unpaused (default)
Public Const BCCFG1553_SELFTEST As Long = &H800000    '//This channel will transmit/receive on the internal self-test bus
Public Const BCCFG1553_SELFTESTOFF As Long = &H0 '//This channel will transmit/receive on the operational bus (default)

'/**
'*
'*  Monitor configuration options
'*
'**/

Public Const MONCFG1553_DEFAULT As Long = &H0    '//Select all default settings
Public Const MONCFG1553_ENABLE As Long = &H0 '//Enable monitor
Public Const MONCFG1553_DISABLE As Long = &H1    '//Disable monitor
Public Const MONCFG1553_NOBCAST As Long = &H0    '//Disable broadcast (default)
Public Const MONCFG1553_BCAST As Long = &H100  '//Enable broadcast
Public Const MONCFG1553_COMPLETE As Long = &H0   '//Enable receiving complete words (default)
Public Const MONCFG1553_INCOMPLETE As Long = &H10000 '//Enable receiving incomplete words
Public Const MONCFG1553_MC01 As Long = &H0   '//Select SA=00000 or SA=11111 for mode codes (default)
Public Const MONCFG1553_MC1 As Long = &H100000    '//Select SA=11111 for mode codes
Public Const MONCFG1553_MC0 As Long = &H200000    '//Select SA=00000 for mode codes
Public Const MONCFG1553_MCNONE As Long = &H300000 '//Disable mode codes
Public Const MONCFG1553_TERMOFF As Long = &H0    '//Direct coupled termination resistance off (Bus A & B) (default)
Public Const MONCFG1553_TERMONA As Long = &H4000000    '//Direct coupled termination resistance on  (Bus A)
Public Const MONCFG1553_TERMONB As Long = &H8000000    '//Direct coupled termination resistance on  (Bus B)
Public Const MONCFG1553_TERMONAB As Long = &HC000000   '//Direct coupled termination resistance on  (Bus A & B)
Public Const MONCFG1553_SELFTEST As Long = &H800000   '//This channel will transmit/receive on the internal self-test bus
Public Const MONCFG1553_SELFTESTOFF As Long = &H0    '//This channel will transmit/receive on the operational bus (default)

'/**
'*
'*  Remote terminal configuration options
'*
'**/

Public Const RTCFG1553_DEFAULT As Long = &H0 '//Select all default settings
Public Const RTCFG1553_SIMULATE As Long = &H0    '//Enable RT simulation (default)
Public Const RTCFG1553_DISABLE As Long = &H1 '//Disable RT
Public Const RTCFG1553_MONITOR As Long = &H2 '//Enable RT monitor
Public Const RTCFG1553_NOBCAST As Long = &H0 '//Disable broadcast (default)
Public Const RTCFG1553_BCAST As Long = &H100   '//Enable broadcast
Public Const RTCFG1553_NOAUTOBUSY As Long = &H0  '//Disable auto busy (default)
Public Const RTCFG1553_AUTOBUSY As Long = &H200    '//Enable auto busy
Public Const RTCFG1553_BUILD As Long = &H0   '//Enable auto building (default)
Public Const RTCFG1553_NOBUILD As Long = &H400 '//Disable auto building
Public Const RTCFG1553_STDB As Long = &H0    '//Use MIL-STD-1553B standard (default)
Public Const RTCFG1553_STDA As Long = &H400000    '//Use MIL-STD-1553A standard
Public Const RTCFG1553_NODYNBC As Long = &H0 '//Do not respond to dynamic BC mode code (default)
Public Const RTCFG1553_DYNBC As Long = &H1000   '//Respond to dynamic BC mode code
Public Const RTCFG1553_NOIMMCLR As Long = &H0    '//Do not clear status word bits (default)
Public Const RTCFG1553_IMMCLR As Long = &H2000  '//Status word bits are cleared immediately
Public Const RTCFG1553_NOBCASTADDR As Long = &H0 '//Disable broadcast handling for address (default)
Public Const RTCFG1553_BCASTADDR As Long = &H4000   '//Enable broadcast handling for address
Public Const RTCFG1553_CHANAB As Long = &H0  '//Respond to both channels (default)
Public Const RTCFG1553_CHANA As Long = &H20000   '//Respond to channel A
Public Const RTCFG1553_CHANB As Long = &H10000   '//Respond to channel B
Public Const RTCFG1553_CHANNONE As Long = &H30000    '//Respond to neither channel A nor B
Public Const RTCFG1553_MC01 As Long = &H0    '//Select SA=00000 or SA=11111 for mode codes (default)
Public Const RTCFG1553_MC1 As Long = &H1000000 '//Select SA=11111 for mode codes
Public Const RTCFG1553_MC0 As Long = &H2000000 '//Select SA=00000 for mode codes
Public Const RTCFG1553_MCNONE As Long = &H3000000  '//Disable mode codes
Public Const RTCFG1553_TERMOFF As Long = &H0 '//Direct coupled termination resistance off (Bus A & B) (default)
Public Const RTCFG1553_TERMONA As Long = &H4000000 '//Direct coupled termination resistance on  (Bus A)
Public Const RTCFG1553_TERMONB As Long = &H8000000 '//Direct coupled termination resistance on  (Bus B)
Public Const RTCFG1553_TERMONAB As Long = &HC000000    '//Direct coupled termination resistance on  (Bus A & B)
Public Const RTCFG1553_SYNCSEL As Long = &H0 '//Selective sync (default)
Public Const RTCFG1553_SYNCALL As Long = &H40000000 '//Sync on all messages
Public Const RTCFG1553_WIPE As Long = &H0    '//Enables message clear (default)
Public Const RTCFG1553_NOWIPE As Long = &H80000000  '//Disables message clear
Public Const RTCFG1553_WIPE0 As Long = &H0   '//Initialize data with zeros (default)
Public Const RTCFG1553_WIPE123 As Long = &H10000000 '//Initialize data with incrementing values
Public Const RTCFG1553_WIPECWD As Long = &H20000000 '//Initialize data with command word
Public Const RTCFG1553_RESPONSEB As Long = &H0   '//RT responds using MIL-STD-1553B response time
Public Const RTCFG1553_RESPONSEA As Long = &H400000   '//RT responds using MIL-STD-1553A response time
Public Const RTCFG1553_SELFTEST As Long = &H800000    '//This channel will transmit/receive on the internal self-test bus
Public Const RTCFG1553_SELFTESTOFF As Long = &H0 '//This channel will transmit/receive on the operational bus (default)

'/**
'*
'*  Playback configuration options
'*
'**/

Public Const PLAYCFG1553_DEFAULT As Long = &H0   '//Select all default settings
Public Const PLAYCFG1553_ENABLE As Long = &H0    '//Enable Playback mode
Public Const PLAYCFG1553_DISABLE As Long = &H1   '//Disable Playback mode
Public Const PLAYCFG1553_16K As Long = &H0   '//Allocate a 16K playback buffer (default)
Public Const PLAYCFG1553_ALLAVAIL As Long = &H10  '//Allocate all available memory to playback buffer
Public Const PLAYCFG1553_32K As Long = &H20   '//Allocate a 32K playback buffer
Public Const PLAYCFG1553_64K As Long = &H40   '//Allocate a 64K playback buffer
Public Const PLAYCFG1553_128K As Long = &H80  '//Allocate a 128K playback buffer
Public Const PLAYCFG1553_MC01 As Long = &H0  '//Select SA=00000 or SA=11111 for mode codes (default)
Public Const PLAYCFG1553_MC1 As Long = &H1000000   '//Select SA=11111 for mode codes
Public Const PLAYCFG1553_MC0 As Long = &H2000000   '//Select SA=00000 for mode codes
Public Const PLAYCFG1553_MCNONE As Long = &H3000000    '//Disable mode codes
Public Const PLAYCFG1553_TERMOFF As Long = &H0   '//Direct coupled termination resistance off (Bus A & B) (default)
Public Const PLAYCFG1553_TERMONA As Long = &H4000000   '//Direct coupled termination resistance on  (Bus A)
Public Const PLAYCFG1553_TERMONB As Long = &H8000000   '//Direct coupled termination resistance on  (Bus B)
Public Const PLAYCFG1553_TERMONAB As Long = &HC000000  '//Direct coupled termination resistance on  (Bus A & B)

'/**
'*
'*  Serial configuration options
'*
'**/

Public Const SERCFG1553_DEFAULT As Long = &H0    '//Select all default settings
Public Const SERCFG1553_CONTINUOUS As Long = &H0 '//Enable continuous mode (default)
Public Const SERCFG1553_DISABLE As Long = &H1    '//Disable free mode
Public Const SERCFG1553_FREE As Long = &H2   '//Enable free mode
Public Const SERCFG1553_NOLOGEMPTY As Long = &H0 '//Do not generate event log when empty (default)
Public Const SERCFG1553_LOGEMPTY As Long = &H10   '//Generate event log when empty

'/**
'*
'*  Error configuration options
'*
'**/

Public Const ERRDEF1553_NONE As Long = &H0   '//Disable error generation (default)
Public Const ERRDEF1553_GAP As Long = &H10000    '//Generate preceding gap error
Public Const ERRDEF1553_CNTWRDABS As Long = &H20000  '//Generate an absolute word count error
Public Const ERRDEF1553_CNTWRDREL As Long = &H40000  '//Generate a relative count error
Public Const ERRDEF1553_CNTBIT As Long = &H80000 '//Generate a bit count error
Public Const ERRDEF1553_MAN1 As Long = &H100000   '//Generate manchester error on first half of bit
Public Const ERRDEF1553_MAN2 As Long = &H200000   '//Generate manchester error on second half of bit
Public Const ERRDEF1553_SYNC As Long = &H400000   '//Generate a sync error
Public Const ERRDEF1553_PAR As Long = &H800000    '//Generate a parity error
Public Const ERRDEF1553_ZEROX1 As Long = &H1000000 '//Generate zero crossing error on leading zero crossing (if exists)
Public Const ERRDEF1553_ZEROX2 As Long = &H2000000 '//Generate zero crossing error on mid-bit zero crossing
Public Const ERRDEF1553_DWD00 As Long = &H0  '//Error will be generated in data word  0
Public Const ERRDEF1553_DWD01 As Long = &H1  '//Error will be generated in data word  1
Public Const ERRDEF1553_DWD02 As Long = &H2  '//Error will be generated in data word  2
Public Const ERRDEF1553_DWD03 As Long = &H3  '//Error will be generated in data word  3
Public Const ERRDEF1553_DWD04 As Long = &H4  '//Error will be generated in data word  4
Public Const ERRDEF1553_DWD05 As Long = &H5  '//Error will be generated in data word  5
Public Const ERRDEF1553_DWD06 As Long = &H6  '//Error will be generated in data word  6
Public Const ERRDEF1553_DWD07 As Long = &H7  '//Error will be generated in data word  7
Public Const ERRDEF1553_DWD08 As Long = &H8  '//Error will be generated in data word  8
Public Const ERRDEF1553_DWD09 As Long = &H9  '//Error will be generated in data word  9
Public Const ERRDEF1553_DWD10 As Long = &HA  '//Error will be generated in data word 10
Public Const ERRDEF1553_DWD11 As Long = &HB  '//Error will be generated in data word 11
Public Const ERRDEF1553_DWD12 As Long = &HC  '//Error will be generated in data word 12
Public Const ERRDEF1553_DWD13 As Long = &HD  '//Error will be generated in data word 13
Public Const ERRDEF1553_DWD14 As Long = &HE  '//Error will be generated in data word 14
Public Const ERRDEF1553_DWD15 As Long = &HF  '//Error will be generated in data word 15
Public Const ERRDEF1553_DWD16 As Long = &H10  '//Error will be generated in data word 16
Public Const ERRDEF1553_DWD17 As Long = &H11  '//Error will be generated in data word 17
Public Const ERRDEF1553_DWD18 As Long = &H12  '//Error will be generated in data word 18
Public Const ERRDEF1553_DWD19 As Long = &H13  '//Error will be generated in data word 19
Public Const ERRDEF1553_DWD20 As Long = &H14  '//Error will be generated in data word 20
Public Const ERRDEF1553_DWD21 As Long = &H15  '//Error will be generated in data word 21
Public Const ERRDEF1553_DWD22 As Long = &H16  '//Error will be generated in data word 22
Public Const ERRDEF1553_DWD23 As Long = &H17  '//Error will be generated in data word 23
Public Const ERRDEF1553_DWD24 As Long = &H18  '//Error will be generated in data word 24
Public Const ERRDEF1553_DWD25 As Long = &H19  '//Error will be generated in data word 25
Public Const ERRDEF1553_DWD26 As Long = &H1A  '//Error will be generated in data word 26
Public Const ERRDEF1553_DWD27 As Long = &H1B  '//Error will be generated in data word 27
Public Const ERRDEF1553_DWD28 As Long = &H1C  '//Error will be generated in data word 28
Public Const ERRDEF1553_DWD29 As Long = &H1D  '//Error will be generated in data word 29
Public Const ERRDEF1553_DWD30 As Long = &H1E  '//Error will be generated in data word 30
Public Const ERRDEF1553_DWD31 As Long = &H1F  '//Error will be generated in data word 31
Public Const ERRDEF1553_CWD1 As Long = &H100   '//Error will be generated in CWD1
Public Const ERRDEF1553_CWD2 As Long = &H101   '//Error will be generated in CWD2
Public Const ERRDEF1553_SWD As Long = &H102    '//Error will be generated in SWD
Public Const ERRDEF1553_SWD1 As Long = &H102   '//Error will be generated in SWD
Public Const ERRDEF1553_SWD2 As Long = &H102   '//Error will be generated in SWD

'/**
'*
'*  Error control options
'*
'**/

Public Const ERRCTRL1553_OFF As Long = &H0   '//Disable error generation
Public Const ERRCTRL1553_ON As Long = &H1    '//Enable error generation
Public Const ERRCTRL1553_ONCE As Long = &H2  '//Enable error generation once
Public Const ERRCTRL1553_EXTERNAL As Long = &H3  '//Enable externally triggered error generation
Public Const ERRCTRL1553_TAGMSG As Long = &H0    '//Generate errors on tagged messages
Public Const ERRCTRL1553_ANYMSG As Long = &H80000000    '//Generate errors on any message

'/**
'*
'*  Message configuration options
'*
'**/

Public Const MSGCRT1553_DEFAULT As Long = &H0    '//Default settings
Public Const MSGCRT1553_ENABLE As Long = &H0 '//Enable subaddress (RT) (default)
Public Const MSGCRT1553_DISABLE As Long = &H1000    '//Disable subaddress (RT)
Public Const MSGCRT1553_RESP As Long = &H0   '//Enable response (RT) (default)
Public Const MSGCRT1553_NORESP As Long = &H2000 '//Disable response (RT)
Public Const MSGCRT1553_NOWRAP As Long = &H0 '//Disable data wrap (RT) (default)
Public Const MSGCRT1553_WRAP As Long = &H4000   '//Enable data wrap (RT)
Public Const MSGCRT1553_NOLOG As Long = &H0  '//Message will not generate event log (default)
Public Const MSGCRT1553_LOG As Long = &H1    '//Message will generate event log
Public Const MSGCRT1553_NOERR As Long = &H0  '//No message error will be generated for message (default)
Public Const MSGCRT1553_ERR As Long = &H2    '//A message error will be generated for message
Public Const MSGCRT1553_BUSA As Long = &H0   '//Message will be transmitted on bus A (BC) (default)
Public Const MSGCRT1553_BUSB As Long = &H4   '//Message will be transmitted on bus B (BC)
Public Const MSGCRT1553_BCRT As Long = &H0   '//Message is a BC-RT transfer (BC) (default)
Public Const MSGCRT1553_RTRT As Long = &H8   '//Message is an RT-RT transfer (BC)
Public Const MSGCRT1553_NOMON As Long = &H0  '//Message will not be monitored (default)
Public Const MSGCRT1553_MON As Long = &H10    '//Message will be monitored
Public Const MSGCRT1553_NOTIMETAG As Long = &H0  '//Message will not record time-tag (default)
Public Const MSGCRT1553_TIMETAG As Long = &H40    '//Message will record time-tag
Public Const MSGCRT1553_NOELAPSE As Long = &H0   '//Message will not record elapse time (default)
Public Const MSGCRT1553_ELAPSE As Long = &H80 '//Message will record elapse time
Public Const MSGCRT1553_NOMIN As Long = &H0  '//Message will not record min time (default)
Public Const MSGCRT1553_MIN As Long = &H100    '//Message will record min time
Public Const MSGCRT1553_NOMAX As Long = &H0  '//Message will not record max time (default)
Public Const MSGCRT1553_MAX As Long = &H200    '//Message will record max time
Public Const MSGCRT1553_NOHIT As Long = &H0  '//Message will not record hit count (default)
Public Const MSGCRT1553_HIT As Long = &H400    '//Message will record hit count
Public Const MSGCRT1553_NOSYNC As Long = &H0 '//No sync will be generated for message (default)
Public Const MSGCRT1553_SYNC As Long = &H40000000   '//Sync will be generated for message
Public Const MSGCRT1553_WIPE As Long = &H0   '//Enables message clear (default)
Public Const MSGCRT1553_NOWIPE As Long = &H80000000 '//Disables message clear
Public Const MSGCRT1553_WIPE0 As Long = &H0  '//Initialize data with zeros (default)
Public Const MSGCRT1553_WIPE123 As Long = &H1000000    '//Initialize data with incrementing values
Public Const MSGCRT1553_WIPECWD As Long = &H2000000    '//Initialize data with command word

'/**
'*
'*  List buffer options
'*
'**/

Public Const LISTCRT1553_DEFAULT As Long = &H0   '//Select all default settings
Public Const LISTCRT1553_PINGPONG As Long = &H0  '//Enable ping-pong mode (default)
Public Const LISTCRT1553_FIFO As Long = &H1  '//Enable FIFO mode
Public Const LISTCRT1553_CIRCULAR As Long = &H2  '//Enable circular mode
Public Const LISTCRT1553_TRBIT As Long = &H0 '//User will read or write depending upon T/R bit
Public Const LISTCRT1553_READ As Long = &H10  '//User will read from list buffer
Public Const LISTCRT1553_WRITE As Long = &H20 '//User will write to list buffer
Public Const LISTCRT1553_NOTSKIP As Long = &H0   '//Will not skip messages
Public Const LISTCRT1553_SKIP As Long = &H40  '//Enable message skipping
Public Const LISTCRT1553_ASYNC As Long = &H80 '//Asynchronous mode
Public Const LISTCRT1553_NOLOG As Long = &H0 '//Do not generate event log when list buffer empty/full (default)
Public Const LISTCRT1553_LOG As Long = &H100   '//Generate event log when list buffer empty/full
Public Const LISTCRT1553_NOHIT As Long = &H0 '//Do not generate event log when list is hit (default)
Public Const LISTCRT1553_HIT As Long = &H200   '//Generate event log when list is hit
Public Const LISTCRT1553_NOLOGHALF As Long = &H0 '//Do not generate event log on middle and last entries (default)
Public Const LISTCRT1553_LOGHALF As Long = &H400   '//Generate event log on middle and last entries

'/**
'*
'*  Condition flags.
'*
'**/

Public Const COND1553_ALWAYS As Long = &H0   '//Unconditional
Public Const COND1553_FAIL As Long = &H1 '//Condition when all retries have failed
Public Const COND1553_SRQ As Long = &H2  '//Condition on Service Request bit set in status word
Public Const COND1553_INS As Long = &H4  '//Condition on Instrumentation bit set in status word
Public Const COND1553_SSF As Long = &H8  '//Condition on Subsystem Fail bit set in status word
Public Const COND1553_TF As Long = &H10   '//Condition on Terminal Flag bit set in status word
Public Const COND1553_BUSY As Long = &H20 '//Condition on Busy bit set in status word
Public Const COND1553_ME As Long = &H40   '//Condition on Message Error bit set in status word
Public Const COND1553_RESPERR As Long = &H80  '//Condition on response error
Public Const COND1553_NORESP As Long = &H100   '//Condition on no response error
Public Const COND1553_ALTBUS As Long = &H200   '//Retries are performed on alternate bus
Public Const COND1553_DIO1ACT As Long = &H1000  '//Condition on digital I/O #1 active
Public Const COND1553_DIO1NACT As Long = &H2000 '//Condition on digital I/O #1 not active
Public Const COND1553_DIO2ACT As Long = &H4000  '//Condition on digital I/O #2 active
Public Const COND1553_DIO2NACT As Long = &H8000 '//Condition on digital I/O #2 not active
Public Const COND1553_DIO3ACT As Long = &H10000  '//Condition on digital I/O #3 active
Public Const COND1553_DIO3NACT As Long = &H20000 '//Condition on digital I/O #3 not active
Public Const COND1553_DIO4ACT As Long = &H40000  '//Condition on digital I/O #4 active
Public Const COND1553_DIO4NACT As Long = &H80000 '//Condition on digital I/O #4 not active

'/**
'*
'*  Bit fields of the status word
'*
'**/

Public Const SWD1553_TAMASK As Long = &HF800    '//Masks off RT address in the SWD
Public Const SWD1553_ME As Long = &H400    '//Message error bit
Public Const SWD1553_INST As Long = &H200  '//Instrumentation bit
Public Const SWD1553_SRQ As Long = &H100   '//Service request bit
Public Const SWD1553_BCAST As Long = &H10 '//Broadcast received bit
Public Const SWD1553_BUSY As Long = &H8  '//Busy bit
Public Const SWD1553_SSF As Long = &H4   '//Subsystem flag bit
Public Const SWD1553_DBC As Long = &H2   '//Dynamic bus control acceptance bit
Public Const SWD1553_TF As Long = &H1    '//Terminal flag bit

'/**
'*
'*  Bit fields of the message error flag
'*
'**/

Public Const MSGERR1553_NORESP As Long = &H8000 '//Set when we timeout waiting for response
Public Const MSGERR1553_ANYERR As Long = &H4000 '//Set when any error bit is set
Public Const MSGERR1553_PROTOCOL As Long = &H2000   '//General protocol error
Public Const MSGERR1553_SYNC As Long = &H1000   '//Set when we have the wrong sync
Public Const MSGERR1553_DATACOUNT As Long = &H800  '//Set when improper number of data words
Public Const MSGERR1553_MANCH As Long = &H20  '//Set when manchester error detected
Public Const MSGERR1553_PARITY As Long = &H10 '//Set when parity error detected
Public Const MSGERR1553_WORD As Long = &H8   '//Set when word error detected
Public Const MSGERR1553_RETRY As Long = &H4  '//All retries failed
Public Const MSGERR1553_SYSTEM As Long = &H2 '//An internal system error occurred
Public Const MSGERR1553_HIT As Long = &H1    '//Always set

'/**
'*
'*  Bit fields of the message activity flag.
'*
'**/

Public Const MSGACT1553_CHMASK As Long = &HF000 '//Channel number mask value
Public Const MSGACT1553_CHSHIFT As Long = &HC    '//Channel number shift value
Public Const MSGACT1553_XMTCWD1 As Long = &H800    '//Transmitted CWD1
Public Const MSGACT1553_XMTCWD2 As Long = &H400    '//Transmitted CWD2
Public Const MSGACT1553_XMTSWD1 As Long = &H200    '//Transmitted SWD1
Public Const MSGACT1553_XMTSWD2 As Long = &H100    '//Transmitted SWD2
Public Const MSGACT1553_RCVCWD1 As Long = &H80    '//Received CWD1
Public Const MSGACT1553_RCVCWD2 As Long = &H40    '//Received CWD2
Public Const MSGACT1553_RCVSWD1 As Long = &H20    '//Received SWD1
Public Const MSGACT1553_RCVSWD2 As Long = &H10    '//Received SWD2
Public Const MSGACT1553_XMTDWD As Long = &H8 '//Transmitted DWD
Public Const MSGACT1553_RCVDWD As Long = &H4 '//Received DWD
Public Const MSGACT1553_BUS As Long = &H1    '//Bus A/B bit

'/**
'*
'*  Field types.
'*
'**/

Public Const FIELD1553_CWD1 As Long = &H0    '//CWD1 field
Public Const FIELD1553_CWD2 As Long = &H1    '//CWD2 field
Public Const FIELD1553_SWD1 As Long = &H2    '//SWD1 field
Public Const FIELD1553_SWD2 As Long = &H3    '//SWD2 field
Public Const FIELD1553_TTAG As Long = &H4    '//Time tag field
Public Const FIELD1553_ELAPSE As Long = &H5  '//Elapse time field
Public Const FIELD1553_ERROR As Long = &H6   '//Error field
Public Const FIELD1553_ACT As Long = &H7 '//Activity field
Public Const FIELD1553_RESP1 As Long = &H8   '//Response time 1 field
Public Const FIELD1553_RESP2 As Long = &H9   '//Response time 2 field
Public Const FIELD1553_COUNT As Long = &HA   '//Data count field
Public Const FIELD1553_FLAG1 As Long = &HB   '//Flag 1 field
Public Const FIELD1553_FLAG2 As Long = &HC   '//Flag 2 field
Public Const FIELD1553_EXTFLAG As Long = &HD '//External flag field
Public Const FIELD1553_TTAGH As Long = &HE   '//Extended time tag field

'/**
'*
'*  Channel info fields.
'*
'**/

Public Const INFO1553_MODEL As Long = &H1    '//Channel model type
Public Const INFO1553_MAXCOUNT As Long = &H2 '//Channel terminal count
Public Const INFO1553_MULTIMODE As Long = &H3    '//Channel supports multi-mode
Public Const INFO1553_ERRORGEN As Long = &H4 '//Channel supports error generation
Public Const INFO1553_CONCURMON As Long = &H5    '//Channel supports concurrent monitor
Public Const INFO1553_MONFILTER As Long = &H6    '//Channel supports filtering of monitor
Public Const INFO1553_PARAM As Long = &H7    '//Channel supports parametric control
Public Const INFO1553_RTRESPTIME As Long = &H8   '//Channel supports programmable RT response time
Public Const INFO1553_PLAYBACK As Long = &H9 '//Channel supports hardware playback mode
Public Const INFO1553_VER2CHOBJ As Long = &HA    '//Channel supports version 2 channel object
Public Const INFO1553_BCDFLTGAP As Long = &HB    '//Channel supports programmable default gap time

'/**
'*
'*  Parametric configuration options
'*
'**/

Public Const PARAMCFG1553_DEFAULT As Long = &H0  '//Select all default settings (default)
Public Const PARAMCFG1553_AMPLON As Long = &H0   '//Enables parametric amplitude control (default)
Public Const PARAMCFG1553_AMPLOFF As Long = &H1  '//Disables parametric amplitude control

'/**
'*
'*  Other flags.
'*
'**/

Public Const SUBADDRESS As Long = &H0    '//Selects Subaddress messages
Public Const MODECODE As Long = &H1  '//Selects Modecode messages
