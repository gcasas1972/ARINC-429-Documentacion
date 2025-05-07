'/**
'*
'*  BTI429 WIN32 DRIVER  Version 1.10.0  (06/07/2011)
'*  Copyright (c) 2001-2011
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   BTI429.BAS -- 32-bit
'*                      BTI429 Driver Include Header File.
'*
'**/

'/**
'*
'*  Structs used by the BTI429 Driver.
'*
'**/

Public Type MSGSTRUCT429
	addr As Long
	data As Long
End Type

Public Type MSGFIELDS429
	msgopt As Integer	'//Driver writes message optionvals
	msgact As Integer	'//Card writes message activity
	msgdata_listptr As Long	'//Card/User writes message data (Rcv/Xmt) - '//Driver writes list buffer pointer
	timetag_hitcount As Long	'//Card writes timetag - '//Card writes hit count
	maxtime_elapsetime As Long	'//Card writes max time - '//Card writes elapsed time
	mintime As Long	'//Card writes min time
	userptr As Long	'//Driver writes user code pointer
	timetagh As Long	'//Card writes extended timetag
	decgap As Integer	'//Card writes measured decoder gap time (rsvd for xmt msg)
	rsvd As Integer	'//Reserved
End Type

'/**
'*
'*  BTI429 Driver functions.
'*
'**/

'/**
'*
'*  Internal functions used by the BTI429 Driver.
'*
'**/

Public Declare Function BTI429_BCDGetData Lib "BTI429.DLL" Alias "_BTI429_BCDGetData@12" (ByVal msg As Long, ByVal msb As Integer, ByVal lsb As Integer) As Long
Public Declare Function BTI429_BCDGetMant Lib "BTI429.DLL" Alias "_BTI429_BCDGetMant@8" (ByVal msg As Long, ByVal sigdig As Integer) As Long
Public Declare Function BTI429_BCDGetSign Lib "BTI429.DLL" Alias "_BTI429_BCDGetSign@4" (ByVal msg As Long) As Integer
Public Declare Function BTI429_BCDGetSSM Lib "BTI429.DLL" Alias "_BTI429_BCDGetSSM@4" (ByVal msg As Long) As Integer
Public Declare Sub BTI429_BCDGetVal Lib "BTI429.DLL" Alias "_BTI429_BCDGetVal@16" (ByRef buf As String, ByVal msg As Long, ByVal sigdig As Integer, ByRef resolstr As String)
Public Declare Function BTI429_BCDPutData Lib "BTI429.DLL" Alias "_BTI429_BCDPutData@16" (ByVal msg As Long, ByVal value As Long, ByVal msb As Integer, ByVal lsb As Integer) As Long
Public Declare Function BTI429_BCDPutMant Lib "BTI429.DLL" Alias "_BTI429_BCDPutMant@16" (ByVal msg As Long, ByVal value As Long, ByVal sigdig As Integer, ByVal sign As Integer) As Long
Public Declare Function BTI429_BCDPutSign Lib "BTI429.DLL" Alias "_BTI429_BCDPutSign@8" (ByVal msg As Long, ByVal sign As Integer) As Long
Public Declare Function BTI429_BCDPutSSM Lib "BTI429.DLL" Alias "_BTI429_BCDPutSSM@8" (ByVal msg As Long, ByVal value As Integer) As Long
Public Declare Function BTI429_BCDPutVal Lib "BTI429.DLL" Alias "_BTI429_BCDPutVal@16" (ByRef buf As String, ByVal msg As Long, ByVal sigdig As Integer, ByRef resolstr As String) As Long
Public Declare Function BTI429_BNRGetData Lib "BTI429.DLL" Alias "_BTI429_BNRGetData@12" (ByVal msg As Long, ByVal msb As Integer, ByVal lsb As Integer) As Long
Public Declare Function BTI429_BNRGetMant Lib "BTI429.DLL" Alias "_BTI429_BNRGetMant@8" (ByVal msg As Long, ByVal sigbit As Integer) As Long
Public Declare Function BTI429_BNRGetSign Lib "BTI429.DLL" Alias "_BTI429_BNRGetSign@4" (ByVal msg As Long) As Integer
Public Declare Function BTI429_BNRGetSSM Lib "BTI429.DLL" Alias "_BTI429_BNRGetSSM@4" (ByVal msg As Long) As Integer
Public Declare Sub BTI429_BNRGetVal Lib "BTI429.DLL" Alias "_BTI429_BNRGetVal@16" (ByRef buf As String, ByVal msg As Long, ByVal sigbit As Integer, ByRef resolstr As String)
Public Declare Function BTI429_BNRPutData Lib "BTI429.DLL" Alias "_BTI429_BNRPutData@16" (ByVal msg As Long, ByVal value As Long, ByVal msb As Integer, ByVal lsb As Integer) As Long
Public Declare Function BTI429_BNRPutMant Lib "BTI429.DLL" Alias "_BTI429_BNRPutMant@16" (ByVal msg As Long, ByVal value As Long, ByVal sigbit As Integer, ByVal twos As Integer) As Long
Public Declare Function BTI429_BNRPutSign Lib "BTI429.DLL" Alias "_BTI429_BNRPutSign@8" (ByVal msg As Long, ByVal twos As Integer) As Long
Public Declare Function BTI429_BNRPutSSM Lib "BTI429.DLL" Alias "_BTI429_BNRPutSSM@8" (ByVal msg As Long, ByVal value As Integer) As Long
Public Declare Function BTI429_BNRPutVal Lib "BTI429.DLL" Alias "_BTI429_BNRPutVal@16" (ByRef buf As String, ByVal msg As Long, ByVal sigbit As Integer, ByRef resolstr As String) As Long
Public Declare Function BTI429_ChClear Lib "BTI429.DLL" Alias "_BTI429_ChClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ChConfig Lib "BTI429.DLL" Alias "_BTI429_ChConfig@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_ChGetCount Lib "BTI429.DLL" Alias "_BTI429_ChGetCount@12" (ByRef rcvcount As Long, ByRef xmtcount As Long, ByVal handleval As Long)
Public Declare Function BTI429_ChGetInfo Lib "BTI429.DLL" Alias "_BTI429_ChGetInfo@12" (ByVal infotype As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ChIs429 Lib "BTI429.DLL" Alias "_BTI429_ChIs429@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ChIsRcv Lib "BTI429.DLL" Alias "_BTI429_ChIsRcv@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ChIsXmt Lib "BTI429.DLL" Alias "_BTI429_ChIsXmt@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_ChPause Lib "BTI429.DLL" Alias "_BTI429_ChPause@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI429_ChPauseCheck Lib "BTI429.DLL" Alias "_BTI429_ChPauseCheck@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_ChResume Lib "BTI429.DLL" Alias "_BTI429_ChResume@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI429_ChStart Lib "BTI429.DLL" Alias "_BTI429_ChStart@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ChStop Lib "BTI429.DLL" Alias "_BTI429_ChStop@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ChSyncDefine Lib "BTI429.DLL" Alias "_BTI429_ChSyncDefine@20" (ByVal enableflag As Long, ByVal syncmask As Integer, ByVal pinpolarity As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ChTriggerDefine Lib "BTI429.DLL" Alias "_BTI429_ChTriggerDefine@24" (ByVal enableflag As Long, ByVal trigmask As Integer, ByVal trigval As Integer, ByVal pinpolarity As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_FilterClear Lib "BTI429.DLL" Alias "_BTI429_FilterClear@8" (ByVal basevaladdr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_FilterDefault Lib "BTI429.DLL" Alias "_BTI429_FilterDefault@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_FilterRd Lib "BTI429.DLL" Alias "_BTI429_FilterRd@16" (ByVal labelval As Long, ByVal sdival As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_FilterSet Lib "BTI429.DLL" Alias "_BTI429_FilterSet@20" (ByVal configval As Long, ByVal labelval As Long, ByVal sdimask As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_FilterWr Lib "BTI429.DLL" Alias "_BTI429_FilterWr@20" (ByVal msgaddr As Long, ByVal labelval As Long, ByVal sdival As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_FldGetData Lib "BTI429.DLL" Alias "_BTI429_FldGetData@4" (ByVal msgval As Long) As Long
Public Declare Function BTI429_FldGetLabel Lib "BTI429.DLL" Alias "_BTI429_FldGetLabel@4" (ByVal msgval As Long) As Integer
Public Declare Function BTI429_FldGetParity Lib "BTI429.DLL" Alias "_BTI429_FldGetParity@4" (ByVal msgval As Long) As Integer
Public Declare Function BTI429_FldGetSDI Lib "BTI429.DLL" Alias "_BTI429_FldGetSDI@4" (ByVal msgval As Long) As Integer
Public Declare Function BTI429_FldGetValue Lib "BTI429.DLL" Alias "_BTI429_FldGetValue@12" (ByVal msgval As Long, ByVal startbit As Integer, ByVal endbit As Integer) As Long
Public Declare Function BTI429_FldPutData Lib "BTI429.DLL" Alias "_BTI429_FldPutData@8" (ByVal msgval As Long, ByVal data As Long) As Long
Public Declare Function BTI429_FldPutLabel Lib "BTI429.DLL" Alias "_BTI429_FldPutLabel@8" (ByVal msgval As Long, ByVal label As Integer) As Long
Public Declare Function BTI429_FldPutSDI Lib "BTI429.DLL" Alias "_BTI429_FldPutSDI@8" (ByVal msgval As Long, ByVal sdi As Integer) As Long
Public Declare Function BTI429_FldPutValue Lib "BTI429.DLL" Alias "_BTI429_FldPutValue@16" (ByVal msgval As Long, ByVal dataval As Long, ByVal startbit As Integer, ByVal endbit As Integer) As Long
Public Declare Function BTI429_ListAsyncCreate Lib "BTI429.DLL" Alias "_BTI429_ListAsyncCreate@16" (ByVal listconfigval As Long, ByVal count As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListDataRd Lib "BTI429.DLL" Alias "_BTI429_ListDataRd@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListDataWr Lib "BTI429.DLL" Alias "_BTI429_ListDataWr@12" (ByVal value As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListRcvCreate Lib "BTI429.DLL" Alias "_BTI429_ListRcvCreate@16" (ByVal listconfigval As Long, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListStatus Lib "BTI429.DLL" Alias "_BTI429_ListStatus@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListXmtCreate Lib "BTI429.DLL" Alias "_BTI429_ListXmtCreate@16" (ByVal listconfigval As Long, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_MsgBlockRd Lib "BTI429.DLL" Alias "_BTI429_MsgBlockRd@12" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_MsgBlockWr Lib "BTI429.DLL" Alias "_BTI429_MsgBlockWr@12" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_MsgCreate Lib "BTI429.DLL" Alias "_BTI429_MsgCreate@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_MsgDataRd Lib "BTI429.DLL" Alias "_BTI429_MsgDataRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_MsgDataWr Lib "BTI429.DLL" Alias "_BTI429_MsgDataWr@12" (ByVal value As Long, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Sub BTI429_MsgGroupBlockRd Lib "BTI429.DLL" Alias "_BTI429_MsgGroupBlockRd@16" (ByRef msgfields As MSGFIELDS429, ByRef msgaddrptr As Long, ByVal nummsgs As Long, ByVal handleval As Long)
Public Declare Sub BTI429_MsgGroupBlockWr Lib "BTI429.DLL" Alias "_BTI429_MsgGroupBlockWr@16" (ByRef msgfields As MSGFIELDS429, ByRef msgaddrptr As Long, ByVal nummsgs As Long, ByVal handleval As Long)
Public Declare Sub BTI429_MsgGroupRd Lib "BTI429.DLL" Alias "_BTI429_MsgGroupRd@16" (ByRef msgdataptr As Long, ByRef msgaddrptr As Long, ByVal nummsgs As Long, ByVal handleval As Long)
Public Declare Sub BTI429_MsgGroupWr Lib "BTI429.DLL" Alias "_BTI429_MsgGroupWr@16" (ByRef msgdataptr As Long, ByRef msgaddrptr As Long, ByVal nummsgs As Long, ByVal handleval As Long)
Public Declare Function BTI429_MsgIsAccessed Lib "BTI429.DLL" Alias "_BTI429_MsgIsAccessed@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_MsgSkipRd Lib "BTI429.DLL" Alias "_BTI429_MsgSkipRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_MsgSkipWr Lib "BTI429.DLL" Alias "_BTI429_MsgSkipWr@12" (ByVal skip As Long, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI429_MsgSyncDefine Lib "BTI429.DLL" Alias "_BTI429_MsgSyncDefine@20" (ByVal enableflag As Long, ByVal syncmask As Integer, ByVal pinpolarity As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_MsgTriggerDefine Lib "BTI429.DLL" Alias "_BTI429_MsgTriggerDefine@24" (ByVal enableflag As Long, ByVal trigmask As Integer, ByVal trigval As Integer, ByVal pinpolarity As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ParamAmplitudeConfig Lib "BTI429.DLL" Alias "_BTI429_ParamAmplitudeConfig@16" (ByVal configval As Long, ByVal dacval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ParamAmplitudeGet Lib "BTI429.DLL" Alias "_BTI429_ParamAmplitudeGet@12" (ByRef dacval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ParamBitRateConfig Lib "BTI429.DLL" Alias "_BTI429_ParamBitRateConfig@16" (ByVal configval As Long, ByVal divval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ParamBitRateGet Lib "BTI429.DLL" Alias "_BTI429_ParamBitRateGet@12" (ByRef divval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedBranch Lib "BTI429.DLL" Alias "_BTI429_SchedBranch@16" (ByVal condition As Long, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedBranchUpdate Lib "BTI429.DLL" Alias "_BTI429_SchedBranchUpdate@16" (ByVal destindex As Long, ByVal opcodeindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedBuild Lib "BTI429.DLL" Alias "_BTI429_SchedBuild@24" (ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef minperiod As Long, ByRef maxperiod As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedCall Lib "BTI429.DLL" Alias "_BTI429_SchedCall@16" (ByVal condition As Long, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedCallUpdate Lib "BTI429.DLL" Alias "_BTI429_SchedCallUpdate@16" (ByVal destindex As Long, ByVal opcodeindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedMode Lib "BTI429.DLL" Alias "_BTI429_SchedMode@4" (ByVal modeval As Long) As Long
Public Declare Function BTI429_SchedEntry Lib "BTI429.DLL" Alias "_BTI429_SchedEntry@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedGap Lib "BTI429.DLL" Alias "_BTI429_SchedGap@12" (ByVal gapval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedGapFixed Lib "BTI429.DLL" Alias "_BTI429_SchedGapFixed@12" (ByVal gapval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedGapList Lib "BTI429.DLL" Alias "_BTI429_SchedGapList@16" (ByVal gapval As Integer, ByVal listaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedHalt Lib "BTI429.DLL" Alias "_BTI429_SchedHalt@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedLog Lib "BTI429.DLL" Alias "_BTI429_SchedLog@16" (ByVal condition As Long, ByVal tagval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedMsg Lib "BTI429.DLL" Alias "_BTI429_SchedMsg@12" (ByVal msgaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedMsgEx Lib "BTI429.DLL" Alias "_BTI429_SchedMsgEx@16" (ByVal msgaddr As Long, ByVal gapval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedPause Lib "BTI429.DLL" Alias "_BTI429_SchedPause@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedPulse Lib "BTI429.DLL" Alias "_BTI429_SchedPulse@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedRestart Lib "BTI429.DLL" Alias "_BTI429_SchedRestart@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedReturn Lib "BTI429.DLL" Alias "_BTI429_SchedReturn@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ChConfigEx Lib "BTI429.DLL" Alias "_BTI429_ChConfigEx@16" (ByVal configval As Long, ByVal count As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdAddr Lib "BTI429.DLL" Alias "_BTI429_CmdAddr@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdAlloc Lib "BTI429.DLL" Alias "_BTI429_CmdAlloc@8" (ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdAllocEx Lib "BTI429.DLL" Alias "_BTI429_CmdAllocEx@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdBaseRd Lib "BTI429.DLL" Alias "_BTI429_CmdBaseRd@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_CmdBaseWr Lib "BTI429.DLL" Alias "_BTI429_CmdBaseWr@12" (ByVal addrval As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI429_CmdClear Lib "BTI429.DLL" Alias "_BTI429_CmdClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdCountRd Lib "BTI429.DLL" Alias "_BTI429_CmdCountRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI429_CmdCountWr Lib "BTI429.DLL" Alias "_BTI429_CmdCountWr@12" (ByVal countval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI429_CmdCtrlRd Lib "BTI429.DLL" Alias "_BTI429_CmdCtrlRd@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI429_CmdCtrlWr Lib "BTI429.DLL" Alias "_BTI429_CmdCtrlWr@16" (ByVal ctrlval As Integer, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI429_CmdCurrRd Lib "BTI429.DLL" Alias "_BTI429_CmdCurrRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI429_CmdCurrWr Lib "BTI429.DLL" Alias "_BTI429_CmdCurrWr@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Sub BTI429_CmdInit Lib "BTI429.DLL" Alias "_BTI429_CmdInit@8" (ByVal opcode As Integer, ByRef block As Integer)
Public Declare Function BTI429_CmdInsert Lib "BTI429.DLL" Alias "_BTI429_CmdInsert@12" (ByRef block As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdMaxLoopRd Lib "BTI429.DLL" Alias "_BTI429_CmdMaxLoopRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI429_CmdMaxLoopWr Lib "BTI429.DLL" Alias "_BTI429_CmdMaxLoopWr@12" (ByVal countval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI429_CmdRd Lib "BTI429.DLL" Alias "_BTI429_CmdRd@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_CmdRestart Lib "BTI429.DLL" Alias "_BTI429_CmdRestart@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI429_CmdShotRd Lib "BTI429.DLL" Alias "_BTI429_CmdShotRd@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdShotWr Lib "BTI429.DLL" Alias "_BTI429_CmdShotWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdSkipRd Lib "BTI429.DLL" Alias "_BTI429_CmdSkipRd@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdSkipWr Lib "BTI429.DLL" Alias "_BTI429_CmdSkipWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_CmdStackClr Lib "BTI429.DLL" Alias "_BTI429_CmdStackClr@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI429_CmdStartRd Lib "BTI429.DLL" Alias "_BTI429_CmdStartRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI429_CmdStartWr Lib "BTI429.DLL" Alias "_BTI429_CmdStartWr@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI429_CmdStepRd Lib "BTI429.DLL" Alias "_BTI429_CmdStepRd@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdStepWr Lib "BTI429.DLL" Alias "_BTI429_CmdStepWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_CmdTotalRd Lib "BTI429.DLL" Alias "_BTI429_CmdTotalRd@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_CmdTotalWr Lib "BTI429.DLL" Alias "_BTI429_CmdTotalWr@12" (ByVal countval As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTI429_CmdWr Lib "BTI429.DLL" Alias "_BTI429_CmdWr@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ConvFromArinc Lib "BTI429.DLL" Alias "_BTI429_ConvFromArinc@4" (ByVal msgval As Long) As Long
Public Declare Function BTI429_ConvToArinc Lib "BTI429.DLL" Alias "_BTI429_ConvToArinc@4" (ByVal msgval As Long) As Long
Public Declare Function BTI429_DllUsageCount Lib "BTI429.DLL" Alias "_BTI429_DllUsageCount@0" () As Long
Public Declare Function BTI429_FilterAddr Lib "BTI429.DLL" Alias "_BTI429_FilterAddr@16" (ByVal labelval As Long, ByVal sdival As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_FilterCreate Lib "BTI429.DLL" Alias "_BTI429_FilterCreate@4" (ByVal handleval As Long) As Long
Public Declare Function BTI429_FilterFill Lib "BTI429.DLL" Alias "_BTI429_FilterFill@12" (ByVal msgaddr As Long, ByVal basevaladdr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_FldGetParBit Lib "BTI429.DLL" Alias "_BTI429_FldGetParBit@4" (ByVal msgval As Long) As Integer
Public Declare Function BTI429_FldPutParBit Lib "BTI429.DLL" Alias "_BTI429_FldPutParBit@4" (ByVal msgval As Long) As Long
Public Declare Sub BTI429_GetChanCount Lib "BTI429.DLL" Alias "_BTI429_GetChanCount@12" (ByRef rcvcount As Long, ByRef xmtcount As Long, ByVal handleval As Long)
Public Declare Function BTI429_IsChan Lib "BTI429.DLL" Alias "_BTI429_IsChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_IsRcvChan Lib "BTI429.DLL" Alias "_BTI429_IsRcvChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_IsXmtChan Lib "BTI429.DLL" Alias "_BTI429_IsXmtChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_LabelReverse Lib "BTI429.DLL" Alias "_BTI429_LabelReverse@4" (ByVal msgval As Long) As Long
Public Declare Function BTI429_ListAddr Lib "BTI429.DLL" Alias "_BTI429_ListAddr@12" (ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListAddrEx Lib "BTI429.DLL" Alias "_BTI429_ListAddrEx@16" (ByVal index As Long, ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListAdvance Lib "BTI429.DLL" Alias "_BTI429_ListAdvance@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListClear Lib "BTI429.DLL" Alias "_BTI429_ListClear@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListConfig Lib "BTI429.DLL" Alias "_BTI429_ListConfig@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListConfigEx Lib "BTI429.DLL" Alias "_BTI429_ListConfigEx@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListDataBlkRd Lib "BTI429.DLL" Alias "_BTI429_ListDataBlkRd@16" (ByRef dataptr As Long, ByRef datacountptr As Integer, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListDataBlkWr Lib "BTI429.DLL" Alias "_BTI429_ListDataBlkWr@16" (ByRef dataptr As Long, ByVal datacount As Integer, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListDataRdEx Lib "BTI429.DLL" Alias "_BTI429_ListDataRdEx@12" (ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_ListDataWrEx Lib "BTI429.DLL" Alias "_BTI429_ListDataWrEx@16" (ByVal value As Long, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long)
Public Declare Function BTI429_ListInit Lib "BTI429.DLL" Alias "_BTI429_ListInit@12" (ByVal listaddr As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListNextRd Lib "BTI429.DLL" Alias "_BTI429_ListNextRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function BTI429_ListNextWr Lib "BTI429.DLL" Alias "_BTI429_ListNextWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Sub BTI429_ListPostRd Lib "BTI429.DLL" Alias "_BTI429_ListPostRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Sub BTI429_ListPostWr Lib "BTI429.DLL" Alias "_BTI429_ListPostWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Sub BTI429_ListPreRd Lib "BTI429.DLL" Alias "_BTI429_ListPreRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Sub BTI429_ListPreWr Lib "BTI429.DLL" Alias "_BTI429_ListPreWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Function BTI429_MsgActivityRd Lib "BTI429.DLL" Alias "_BTI429_MsgActivityRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI429_MsgActivityWr Lib "BTI429.DLL" Alias "_BTI429_MsgActivityWr@12" (ByVal value As Integer, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI429_MsgCheck Lib "BTI429.DLL" Alias "_BTI429_MsgCheck@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function BTI429_MsgCommRd Lib "BTI429.DLL" Alias "_BTI429_MsgCommRd@12" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_MsgCommWr Lib "BTI429.DLL" Alias "_BTI429_MsgCommWr@12" (ByRef msgfields As MSGFIELDS429, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_MsgConfig Lib "BTI429.DLL" Alias "_BTI429_MsgConfig@12" (ByVal configval As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_MsgOptRd Lib "BTI429.DLL" Alias "_BTI429_MsgOptRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTI429_MsgOptWr Lib "BTI429.DLL" Alias "_BTI429_MsgOptWr@12" (ByVal msgopt As Integer, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTI429_MsgReset Lib "BTI429.DLL" Alias "_BTI429_MsgReset@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_Sched1Build Lib "BTI429.DLL" Alias "_BTI429_Sched1Build@40" (ByVal basevalmsgnum As Long, ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef minperiodin As Long, ByRef maxperiodin As Long, ByVal speed As Long, ByVal microflag As Long, ByVal channum As Long, ByVal debugval As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_Sched2AdvanceMessage Lib "BTI429.DLL" Alias "_BTI429_Sched2AdvanceMessage@44" (ByVal entries As Long, ByVal panicindex As Long, ByVal nummsgs As Long, ByRef infoptr As Long, ByRef nextdeltaptr As Long, ByVal ulmastertimer As Long, ByRef msgaddrptr As Long, ByVal debugvalflag As Long, ByVal tryflag As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_Sched2AdvanceNoMessage Lib "BTI429.DLL" Alias "_BTI429_Sched2AdvanceNoMessage@36" (ByVal nummsgs As Long, ByRef infoptr As Long, ByRef nextdeltaptr As Long, ByVal ulmastertimer As Long, ByRef msgaddrptr As Long, ByVal debugvalflag As Long, ByVal tryflag As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_Sched2Analyze Lib "BTI429.DLL" Alias "_BTI429_Sched2Analyze@8" (ByVal nummsgs As Long, ByRef infoptr As Long)
Public Declare Function BTI429_Sched2Build Lib "BTI429.DLL" Alias "_BTI429_Sched2Build@36" (ByVal nummsgs As Long, ByRef msgaddrptr As Long, ByRef minlist As Long, ByRef maxlist As Long, ByVal speedflag As Long, ByVal microflag As Long, ByVal debugvalflag As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_Sched2BuildEx Lib "BTI429.DLL" Alias "_BTI429_Sched2BuildEx@24" (ByRef styleptr As Long, ByVal nummsgs As Long, ByRef minlist As Long, ByRef maxlist As Long, ByVal speedflag As Long, ByVal microflag As Long) As Long
Public Declare Function BTI429_Sched2BuildExx Lib "BTI429.DLL" Alias "_BTI429_Sched2BuildExx@56" (ByVal style As Long, ByVal speedflag As Long, ByVal microflag As Long, ByVal debugvalflag As Long, ByVal tryflag As Long, ByVal nummsgs As Long, ByRef minlist As Long, ByRef maxlist As Long, ByRef entriesptr As Long, ByRef maxentriesptr As Long, ByRef infoptr As Long, ByRef msgaddrptr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedAdvance Lib "BTI429.DLL" Alias "_BTI429_SchedAdvance@4" (ByRef infoptr As Long) As Long
Public Declare Function BTI429_SchedAgain Lib "BTI429.DLL" Alias "_BTI429_SchedAgain@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedBranchEx Lib "BTI429.DLL" Alias "_BTI429_SchedBranchEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedBuildEx Lib "BTI429.DLL" Alias "_BTI429_SchedBuildEx@28" (ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef minperiod As Long, ByRef maxperiod As Long, ByVal speed As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedBuildExx Lib "BTI429.DLL" Alias "_BTI429_SchedBuildExx@40" (ByVal basevalmsgnum As Long, ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef minperiod As Long, ByRef maxperiod As Long, ByVal speed As Long, ByRef buf As Long, ByVal bufsize As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedBuildExxx Lib "BTI429.DLL" Alias "_BTI429_SchedBuildExxx@40" (ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef minperiod As Long, ByRef maxperiod As Long, ByVal speed As Long, ByVal channum As Long, ByVal debugval As Long, ByVal microflag As Long, ByVal algorithm As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedCalc Lib "BTI429.DLL" Alias "_BTI429_SchedCalc@4" (ByRef infoptr As Long) As Long
Public Declare Function BTI429_SchedCallEx Lib "BTI429.DLL" Alias "_BTI429_SchedCallEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedCheck Lib "BTI429.DLL" Alias "_BTI429_SchedCheck@12" (ByRef minperiod As Long, ByRef maxperiod As Long, ByRef infoptr As Long) As Long
Public Declare Sub BTI429_SchedCheckEnd Lib "BTI429.DLL" Alias "_BTI429_SchedCheckEnd@0" ()
Public Declare Sub BTI429_SchedCheckMiddle Lib "BTI429.DLL" Alias "_BTI429_SchedCheckMiddle@16" (ByVal msgnum As Long, ByVal minlen As Long, ByVal midlen As Long, ByVal maxlen As Long)
Public Declare Sub BTI429_SchedCheckReal Lib "BTI429.DLL" Alias "_BTI429_SchedCheckReal@16" (ByVal msgnum As Long, ByVal minlen As Long, ByVal midlen As Long, ByVal maxlen As Long)
Public Declare Sub BTI429_SchedCheckStart Lib "BTI429.DLL" Alias "_BTI429_SchedCheckStart@0" ()
Public Declare Function BTI429_SchedConflicts Lib "BTI429.DLL" Alias "_BTI429_SchedConflicts@4" (ByRef infoptr As Long) As Long
Public Declare Function BTI429_SchedDivide Lib "BTI429.DLL" Alias "_BTI429_SchedDivide@4" (ByRef infoptr As Long) As Long
Public Declare Function BTI429_SchedFix Lib "BTI429.DLL" Alias "_BTI429_SchedFix@4" (ByRef infoptr As Long) As Long
Public Declare Sub BTI429_SchedFixEnd Lib "BTI429.DLL" Alias "_BTI429_SchedFixEnd@0" ()
Public Declare Sub BTI429_SchedFixMiddle Lib "BTI429.DLL" Alias "_BTI429_SchedFixMiddle@4" (ByVal conflicts As Long)
Public Declare Sub BTI429_SchedFixStart Lib "BTI429.DLL" Alias "_BTI429_SchedFixStart@0" ()
Public Declare Sub BTI429_SchedHook Lib "BTI429.DLL" Alias "_BTI429_SchedHook@8" (ByVal index As Long, ByRef ptr As Long)
Public Declare Function BTI429_SchedInsert Lib "BTI429.DLL" Alias "_BTI429_SchedInsert@28" (ByVal eventvals As Long, ByVal index As Long, ByVal msgnum As Long, ByRef msgaddr As Long, ByVal gapval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedInsert2 Lib "BTI429.DLL" Alias "_BTI429_SchedInsert2@28" (ByVal eventvals As Long, ByVal index As Long, ByVal msgnum As Long, ByRef msgaddr As Long, ByVal gapval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedInsertEnd Lib "BTI429.DLL" Alias "_BTI429_SchedInsertEnd@12" (ByVal eventvals As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedInsertStart Lib "BTI429.DLL" Alias "_BTI429_SchedInsertStart@12" (ByVal eventvals As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTI429_SchedLayout Lib "BTI429.DLL" Alias "_BTI429_SchedLayout@4" (ByRef infoptr As Long)
Public Declare Function BTI429_SchedLogEx Lib "BTI429.DLL" Alias "_BTI429_SchedLogEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal tagval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedMaxval Lib "BTI429.DLL" Alias "_BTI429_SchedMaxval@8" (ByRef arrayval As Long, ByVal arrayvalcount As Long) As Long
Public Declare Function BTI429_SchedMinval Lib "BTI429.DLL" Alias "_BTI429_SchedMinval@8" (ByRef arrayval As Long, ByVal arrayvalcount As Long) As Long
Public Declare Function BTI429_SchedNop Lib "BTI429.DLL" Alias "_BTI429_SchedNop@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedParse Lib "BTI429.DLL" Alias "_BTI429_SchedParse@20" (ByVal basevalmsgnum As Long, ByRef msgaddr As Long, ByVal channum As Long, ByRef infoptr As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedPulse0 Lib "BTI429.DLL" Alias "_BTI429_SchedPulse0@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedPulse1 Lib "BTI429.DLL" Alias "_BTI429_SchedPulse1@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedReset Lib "BTI429.DLL" Alias "_BTI429_SchedReset@4" (ByRef infoptr As Long) As Long
Public Declare Function BTI429_SchedRotate Lib "BTI429.DLL" Alias "_BTI429_SchedRotate@4" (ByRef infoptr As Long) As Long
Public Declare Function BTI429_SchedShift Lib "BTI429.DLL" Alias "_BTI429_SchedShift@12" (ByVal msgnum As Long, ByVal value As Long, ByRef infoptr As Long) As Long
Public Declare Function BTI429_SchedSlide Lib "BTI429.DLL" Alias "_BTI429_SchedSlide@4" (ByRef infoptr As Long) As Long
Public Declare Sub BTI429_SchedSlideEnd Lib "BTI429.DLL" Alias "_BTI429_SchedSlideEnd@0" ()
Public Declare Sub BTI429_SchedSlideMiddle Lib "BTI429.DLL" Alias "_BTI429_SchedSlideMiddle@12" (ByVal index As Long, ByVal count As Long, ByVal conflicts As Long)
Public Declare Sub BTI429_SchedSlideStart Lib "BTI429.DLL" Alias "_BTI429_SchedSlideStart@4" (ByVal factor As Long)
Public Declare Sub BTI429_SchedSort Lib "BTI429.DLL" Alias "_BTI429_SchedSort@4" (ByRef infoptr As Long)
Public Declare Function BTI429_SchedToBit Lib "BTI429.DLL" Alias "_BTI429_SchedToBit@8" (ByVal value As Long, ByRef infoptr As Long) As Long
Public Declare Function BTI429_SchedToMsec Lib "BTI429.DLL" Alias "_BTI429_SchedToMsec@8" (ByVal value As Long, ByRef infoptr As Long) As Long
Public Declare Sub BTI429_SchedUnsort Lib "BTI429.DLL" Alias "_BTI429_SchedUnsort@4" (ByRef infoptr As Long)
Public Declare Function BTI429_SchedUser Lib "BTI429.DLL" Alias "_BTI429_SchedUser@12" (ByVal useraddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTI429_SchedWalk Lib "BTI429.DLL" Alias "_BTI429_SchedWalk@4" (ByRef infoptr As Long) As Long
Public Declare Function BTI429_TestProtocol Lib "BTI429.DLL" Alias "_BTI429_TestProtocol@4" (ByVal handleval As Long) As Long
Public Declare Function BTI429_Transpose12 Lib "BTI429.DLL" Alias "_BTI429_Transpose12@4" (ByVal val As Integer) As Integer

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
'*  SDI selection constants
'*
'**/

Public Const SDI00 As Long = &H1 '//Enable SDI00
Public Const SDI01 As Long = &H2 '//Enable SDI01
Public Const SDI10 As Long = &H4 '//Enable SDI10
Public Const SDI11 As Long = &H8 '//Enable SDI11
Public Const SDIALL As Long = &HF    '//Enable all SDIs

'/**
'*
'*  Channel configuration options
'*
'**/

Public Const CHCFG429_DEFAULT As Long = &H0  '//Select all default settings (XMT & RCV) (default)
Public Const CHCFG429_HIGHSPEED As Long = &H1    '//Select high speed (XMT & RCV)
Public Const CHCFG429_AUTOSPEED As Long = &H2    '//Select auto speed detection (RCV)
Public Const CHCFG429_LOWSPEED As Long = &H0 '//Select low speed (XMT & RCV) (default)
Public Const CHCFG429_SELFTEST As Long = &H4 '//Enable internal wraparound (XMT & RCV)
Public Const CHCFG429_SELFTESTOFF As Long = &H0  '//Disable internal wraparound (XMT & RCV) (default)
Public Const CHCFG429_SYNC As Long = &H8 '//Sync Enable (XMT & RCV)
Public Const CHCFG429_SYNCOFF As Long = &H0  '//Disable sync output (XMT & RCV) (default)
Public Const CHCFG429_PARODD As Long = &H0   '//Parity odd (XMT & RCV) (default)
Public Const CHCFG429_PAREVEN As Long = &H10  '//Parity even (XMT & RCV)
Public Const CHCFG429_PARDATA As Long = &H20  '//Parity bit as data (XMT & RCV)
Public Const CHCFG429_ACTIVE As Long = &H0   '//Enable channel activity (XMT & RCV) (default)
Public Const CHCFG429_INACTIVE As Long = &H40 '//Disable channel activity (XMT & RCV)
Public Const CHCFG429_EXTTRIG As Long = &H80  '//Enable external trigger for all messages (XMT)
Public Const CHCFG429_EXTOFF As Long = &H0   '//External trigger is enabled on message level (XMT) (default)
Public Const CHCFG429_PARERR As Long = &H100   '//Enable parity error for all messages (XMT)
Public Const CHCFG429_NOERR As Long = &H0    '//Errors are enabled on message level (XMT) (default)
Public Const CHCFG429_HIT As Long = &H200  '//Hit counter is enabled for all messages
Public Const CHCFG429_NOHIT As Long = &H0    '//Hit counter is enabled on message level (default)
Public Const CHCFG429_TIMETAG As Long = &H400  '//Enable time-tag for all message records
Public Const CHCFG429_TIMETAGOFF As Long = &H0   '//Time-tag is enabled on message level (default)
Public Const CHCFG429_ELAPSE As Long = &H800   '//Enable elapse time for all messages
Public Const CHCFG429_ELAPSEOFF As Long = &H0    '//Elapse time is enabled on message level (default)
Public Const CHCFG429_MAX As Long = &H1000  '//Enable max repetition rate monitoring for all messages
Public Const CHCFG429_MIN As Long = &H2000  '//Enable min repetition rate monitoring for all messages
Public Const CHCFG429_MAXMIN As Long = &H3000   '//Enable max and min repetition rate monitoring for all messages
Public Const CHCFG429_MAXMINOFF As Long = &H0    '//Repetition rate monitoring is enabled on message level (default)
Public Const CHCFG429_SEQALL As Long = &H80000   '//Record entire channel in sequential record
Public Const CHCFG429_SEQSEL As Long = &H0   '//Sequential record recording is enabled at message level (default)
Public Const CHCFG429_LOOPMAX As Long = &H100000  '//Enable schedule maximum loop count
Public Const CHCFG429_NOLOOPMAX As Long = &H0    '//Disable schedule maximum loop count (default)
Public Const CHCFG429_LOGHALT As Long = &H200000  '//Enable event log on schedule halt
Public Const CHCFG429_NOLOGHALT As Long = &H0    '//No event log on schedule halt (default)
Public Const CHCFG429_LOGPAUSE As Long = &H400000 '//Enable event log on schedule pause
Public Const CHCFG429_NOLOGPAUSE As Long = &H0   '//No event log on schedule pause (default)
Public Const CHCFG429_LOGERR As Long = &H800000   '//Enable event log on decoder errors.
Public Const CHCFG429_NOLOGERR As Long = &H0 '//No event log on decoder errors (default)
Public Const CHCFG429_PAUSE As Long = &H1000000    '//Mark channel as paused
Public Const CHCFG429_UNPAUSE As Long = &H0  '//Mark channel as unpaused (default)

'/**
'*
'*  Message configuration options
'*
'**/

Public Const MSGCRT429_DEFAULT As Long = &H0 '//Default settings
Public Const MSGCRT429_NOSEQ As Long = &H0   '//Message will not be recorded in sequential record (default)
Public Const MSGCRT429_SEQ As Long = &H1 '//Message will be recorded in sequential record
Public Const MSGCRT429_NOLOG As Long = &H0   '//Message will not generate event log (default)
Public Const MSGCRT429_LOG As Long = &H2 '//Message will generate event log
Public Const MSGCRT429_NOSKIP As Long = &H0  '//Message will not be skipped (default)
Public Const MSGCRT429_SKIP As Long = &H8    '//Message will be skipped
Public Const MSGCRT429_NOTIMETAG As Long = &H0   '//Message will not record time-tag (default)
Public Const MSGCRT429_TIMETAG As Long = &H10 '//Message will record time-tag
Public Const MSGCRT429_NOELAPSE As Long = &H0    '//Message will not record elapse time (default)
Public Const MSGCRT429_ELAPSE As Long = &H20  '//Message will record elapse time
Public Const MSGCRT429_NOMAXMIN As Long = &H0    '//Message will not record min/max time (default)
Public Const MSGCRT429_MAX As Long = &H40 '//Message will record max time
Public Const MSGCRT429_MIN As Long = &H80 '//Message will record min time
Public Const MSGCRT429_MAXMIN As Long = &HC0  '//Message will record min/max time
Public Const MSGCRT429_NOSYNC As Long = &H0  '//No sync will be generated for message (default)
Public Const MSGCRT429_SYNC As Long = &H100    '//Sync will be generated for message
Public Const MSGCRT429_NOERR As Long = &H0   '//No error will be generated for message (default)
Public Const MSGCRT429_PARERR As Long = &H200  '//Parity error will be generated for message
Public Const MSGCRT429_NOHIT As Long = &H0   '//Message will not record hit count (default)
Public Const MSGCRT429_HIT As Long = &H400 '//Message will record hit count
Public Const MSGCRT429_NOEXTRIG As Long = &H0    '//Message will not be externally triggered (default)
Public Const MSGCRT429_EXTRIG As Long = &H1000  '//Message will be externally triggered
Public Const MSGCRT429_WIPE As Long = &H0    '//Enables message clear (default)
Public Const MSGCRT429_NOWIPE As Long = &H80000000  '//Disables message clear
Public Const MSGCRT429_WIPE0 As Long = &H0   '//Initialize data with zeros (default)
Public Const MSGCRT429_WIPE1 As Long = &H40000000   '//Initialize data with ones

'/**
'*
'*  List buffer options
'*
'**/

Public Const LISTCRT429_DEFAULT As Long = &H0    '//Select all default settings
Public Const LISTCRT429_FIFO As Long = &H0   '//Enable FIFO mode (default)
Public Const LISTCRT429_PINGPONG As Long = &H1   '//Enable ping-pong mode
Public Const LISTCRT429_CIRCULAR As Long = &H2   '//Enable circular mode
Public Const LISTCRT429_RCV As Long = &H10    '//User will read from list buffer
Public Const LISTCRT429_XMT As Long = &H20    '//User will write to list buffer
Public Const LISTCRT429_ASYNC As Long = &H40  '//Asynchronous mode
Public Const LISTCRT429_NOLOG As Long = &H0  '//Do not generate event log when list buffer empty/full (default)
Public Const LISTCRT429_LOG As Long = &H100    '//Generate event log when list buffer empty/full

'/**
'*
'*  Parametric configuration options
'*
'**/

Public Const PARAMCFG429_DEFAULT As Long = &H0   '//Select all default settings (default)
Public Const PARAMCFG429_AMPLON As Long = &H0    '//Enables parametric amplitude control (default)
Public Const PARAMCFG429_AMPLOFF As Long = &H1   '//Disables parametric amplitude control
Public Const PARAMCFG429_BITRATEON As Long = &H0 '//Enables parametric bit rate control (default)
Public Const PARAMCFG429_BITRATEOFF As Long = &H2    '//Disables parametric bit rate control

'/**
'*
'*  Scheduling conditions.
'*
'**/

Public Const COND429_ALWAYS As Long = &H0    '//Unconditional
Public Const COND429_DIO1ACT As Long = &H1   '//Condition on digital I/O #1 active
Public Const COND429_DIO1NACT As Long = &H2  '//Condition on digital I/O #1 not active
Public Const COND429_DIO2ACT As Long = &H4   '//Condition on digital I/O #2 active
Public Const COND429_DIO2NACT As Long = &H8  '//Condition on digital I/O #2 not active
Public Const COND429_DIO3ACT As Long = &H10   '//Condition on digital I/O #3 active
Public Const COND429_DIO3NACT As Long = &H20  '//Condition on digital I/O #3 not active
Public Const COND429_DIO4ACT As Long = &H40   '//Condition on digital I/O #4 active
Public Const COND429_DIO4NACT As Long = &H80  '//Condition on digital I/O #4 not active
Public Const COND429_DIO5ACT As Long = &H100   '//Condition on digital I/O #5 active
Public Const COND429_DIO5NACT As Long = &H200  '//Condition on digital I/O #5 not active
Public Const COND429_DIO6ACT As Long = &H400   '//Condition on digital I/O #6 active
Public Const COND429_DIO6NACT As Long = &H800  '//Condition on digital I/O #6 not active
Public Const COND429_DIO7ACT As Long = &H1000   '//Condition on digital I/O #7 active
Public Const COND429_DIO7NACT As Long = &H2000  '//Condition on digital I/O #7 not active
Public Const COND429_DIO8ACT As Long = &H4000   '//Condition on digital I/O #8 active
Public Const COND429_DIO8NACT As Long = &H8000  '//Condition on digital I/O #8 not active

'/**
'*
'*  Bit fields of the message activity flag.
'*
'**/

Public Const MSGACT429_CHMASK As Long = &HFF00  '//Channel number mask value
Public Const MSGACT429_CHSHIFT As Long = &H8 '//Channel number shift value
Public Const MSGACT429_SPD As Long = &H80 '//Bus speed
Public Const MSGACT429_ERR As Long = &H40 '//Error bit
Public Const MSGACT429_GAP As Long = &H20 '//Gap error bit
Public Const MSGACT429_PAR As Long = &H10 '//Parity error bit
Public Const MSGACT429_LONG As Long = &H8    '//Long word error bit
Public Const MSGACT429_BIT As Long = &H4 '//Bit time error bit
Public Const MSGACT429_TO As Long = &H2  '//Time out error bit
Public Const MSGACT429_HIT As Long = &H1 '//Always set

'/**
'*
'*  Channel info fields.
'*
'**/

Public Const INFO429_PARAM As Long = &H1 '//Channel supports parametric control

'/**
'*
'*  Scheduling algorithm options
'*
'**/

Public Const SCHEDMODE_DEFAULT As Long = &H0 '//Select all default settings
Public Const SCHEDMODE_METHOD_NORMAL As Long = &H0   '//Choose the normal scheduling method
Public Const SCHEDMODE_METHOD_QUICK As Long = &H1    '//Choose the quick scheduling method
Public Const SCHEDMODE_METHOD_BOTH As Long = &H2 '//Use the quick method first if fail then use the normal method
Public Const SCHEDMODE_METHOD_MASK As Long = &HF '//Mask for method setting
Public Const SCHEDMODE_MILLISEC As Long = &H0    '//Specify periods in milliseconds
Public Const SCHEDMODE_MICROSEC As Long = &H10    '//Specify periods in microseconds
Public Const SCHEDMODE_REMOTE As Long = &H0  '//Perform calculations remotely if applicable
Public Const SCHEDMODE_LOCAL As Long = &H20   '//Perform calculations locally if applicable
Public Const SCHEDMODE_DEFAULT_ALGOR As Long = &H0   '//Choose the default algorithm
Public Const SCHEDMODE_QUICK_ALGOR As Long = &H1 '//Choose the quick algorithm
Public Const SCHEDMODE_BOTH_ALGOR As Long = &H2  '//Use the quick algorithm first if fail then use the normal algorithm
Public Const SCHEDMODE_ALGOR_MASK As Long = &HF  '//Mask for algorithm setting
