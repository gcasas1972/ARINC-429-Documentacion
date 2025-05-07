'/**
'*
'*  BTICSDB WIN32 DRIVER  Version 1.1.2  (03/02/2010)
'*  Copyright (c) 2005-2010
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   BTICSDB.BAS -- 32-bit
'*                      BTICSDB Driver Include Header File.
'*
'**/

'/**
'*
'*  Structs used by the BTICSDB Driver.
'*
'**/

Public Type MSGFIELDSCSDB
	msgopt As Integer	'//Driver writes message optionvals
	msgoptext As Integer	'//Non-continuous, Valid, and current burst count (FW)
	burstcount As Integer	'//Burst count (API)
	reserved As Integer	'//reserved
	msgact As Integer	'//Card writes message activity
	datacount As Integer	'//Number of valid bytes in data[] buffer
	listptr As Long	'//Driver writes list buffer pointer
	timetag_hitcount As Long	'//Card writes time-tag low value (32 bits) - '//Card writes hit count
	maxtime_elapsetime As Long	'//Card writes max time - '//Card writes elapsed time
	mintime As Long	'//Card writes min time
	userptr As Long	'//Driver writes user code pointer
	miscptr As Long	'//reserved
	timetagh As Long	'//Card writes extended timetag (32 bits)
	data(0 to 31) As Integer	'//Card writes data block
End Type

'/**
'*
'*  BTICSDB Driver functions.
'*
'**/

'/**
'*
'*  Internal functions used by the BTICSDB Driver.
'*
'**/

Public Declare Function BTICSDB_ChClear Lib "BTICSDB.DLL" Alias "_BTICSDB_ChClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ChConfig Lib "BTICSDB.DLL" Alias "_BTICSDB_ChConfig@28" (ByVal configval As Long, ByVal bitrateflag As Integer, ByVal bytesperblock As Integer, ByVal framespersecond As Integer, ByVal blocksperframe As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICSDB_ChGetCount Lib "BTICSDB.DLL" Alias "_BTICSDB_ChGetCount@12" (ByRef rcvcount As Long, ByRef xmtcount As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_ChGetInfo Lib "BTICSDB.DLL" Alias "_BTICSDB_ChGetInfo@12" (ByVal infotype As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ChIsCSDB Lib "BTICSDB.DLL" Alias "_BTICSDB_ChIsCSDB@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ChIsRcv Lib "BTICSDB.DLL" Alias "_BTICSDB_ChIsRcv@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ChIsXmt Lib "BTICSDB.DLL" Alias "_BTICSDB_ChIsXmt@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICSDB_ChPause Lib "BTICSDB.DLL" Alias "_BTICSDB_ChPause@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_ChPauseCheck Lib "BTICSDB.DLL" Alias "_BTICSDB_ChPauseCheck@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICSDB_ChResume Lib "BTICSDB.DLL" Alias "_BTICSDB_ChResume@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_ChStart Lib "BTICSDB.DLL" Alias "_BTICSDB_ChStart@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ChStop Lib "BTICSDB.DLL" Alias "_BTICSDB_ChStop@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_FilterClear Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterClear@8" (ByVal basevaladdr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_FilterDefault Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterDefault@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_FilterRd Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterRd@16" (ByVal addrval As Long, ByVal sival As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_FilterSet Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterSet@20" (ByVal configval As Long, ByVal addrval As Long, ByVal simask As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_FilterWr Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterWr@20" (ByVal msgaddr As Long, ByVal addrval As Long, ByVal sival As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListDataRd Lib "BTICSDB.DLL" Alias "_BTICSDB_ListDataRd@16" (ByRef buf As Byte, ByVal count As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListDataWr Lib "BTICSDB.DLL" Alias "_BTICSDB_ListDataWr@16" (ByRef buf As Byte, ByVal count As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListRcvCreate Lib "BTICSDB.DLL" Alias "_BTICSDB_ListRcvCreate@16" (ByVal listconfigval As Long, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListStatus Lib "BTICSDB.DLL" Alias "_BTICSDB_ListStatus@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListXmtCreate Lib "BTICSDB.DLL" Alias "_BTICSDB_ListXmtCreate@16" (ByVal listconfigval As Long, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgBlockRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgBlockRd@12" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgBlockWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgBlockWr@12" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgCreate Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgCreate@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgDataByteRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgDataByteRd@12" (ByVal index As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Byte
Public Declare Function BTICSDB_MsgDataByteWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgDataByteWr@16" (ByVal data As Byte, ByVal index As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgDataRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgDataRd@16" (ByRef buf As Byte, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgDataWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgDataWr@16" (ByRef buf As Byte, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgIsAccessed Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgIsAccessed@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgValidSet Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgValidSet@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function BTICSDB_ParamAmplitudeConfig Lib "BTICSDB.DLL" Alias "_BTICSDB_ParamAmplitudeConfig@16" (ByVal configval As Long, ByVal dacval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ParamAmplitudeGet Lib "BTICSDB.DLL" Alias "_BTICSDB_ParamAmplitudeGet@12" (ByRef dacval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedBranch Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedBranch@16" (ByVal condition As Long, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedBuild Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedBuild@28" (ByVal nummsgs As Long, ByRef msgs As Long, ByRef freq As Long, ByVal interblockgap As Long, ByVal rsvdblocks As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedCall Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedCall@16" (ByVal condition As Long, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedEntry Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedEntry@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedGap Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedGap@12" (ByVal gapval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedHalt Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedHalt@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedLog Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedLog@16" (ByVal condition As Long, ByVal tagval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedMsg Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedMsg@12" (ByVal msgaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedPause Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedPause@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedPulse Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedPulse@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedRestart Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedRestart@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedReturn Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedReturn@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ChConfigEx Lib "BTICSDB.DLL" Alias "_BTICSDB_ChConfigEx@32" (ByVal configval As Long, ByVal bitrateflag As Integer, ByVal bytesperblock As Integer, ByVal framespersecond As Integer, ByVal blocksperframe As Integer, ByVal interbytegap As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ChConfigExx Lib "BTICSDB.DLL" Alias "_BTICSDB_ChConfigExx@36" (ByVal configval As Long, ByVal count As Integer, ByVal bitrateflag As Integer, ByVal bytesperblock As Integer, ByVal framespersecond As Integer, ByVal blocksperframe As Integer, ByVal interbytegap As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_CmdAddr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdAddr@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_CmdAlloc Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdAlloc@8" (ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_CmdAllocEx Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdAllocEx@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_CmdBaseRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdBaseRd@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICSDB_CmdBaseWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdBaseWr@12" (ByVal addrval As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_CmdClear Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_CmdCountRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCountRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICSDB_CmdCountWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCountWr@12" (ByVal countval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_CmdCtrlRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCtrlRd@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICSDB_CmdCtrlWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCtrlWr@16" (ByVal ctrlval As Integer, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_CmdCurrRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCurrRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICSDB_CmdCurrWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdCurrWr@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Sub BTICSDB_CmdInit Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdInit@8" (ByVal opcode As Integer, ByRef block As Integer)
Public Declare Function BTICSDB_CmdInsert Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdInsert@12" (ByRef block As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_CmdMaxLoopRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdMaxLoopRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICSDB_CmdMaxLoopWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdMaxLoopWr@12" (ByVal countval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_CmdRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdRd@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICSDB_CmdRestart Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdRestart@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_CmdShotWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdShotWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_CmdSkipWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdSkipWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICSDB_CmdStackClr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdStackClr@8" (ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_CmdStartRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdStartRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICSDB_CmdStartWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdStartWr@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_CmdStepWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdStepWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_CmdTotalRd Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdTotalRd@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICSDB_CmdTotalWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdTotalWr@12" (ByVal countval As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_CmdWr Lib "BTICSDB.DLL" Alias "_BTICSDB_CmdWr@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_DllUsageCount Lib "BTICSDB.DLL" Alias "_BTICSDB_DllUsageCount@0" () As Long
Public Declare Function BTICSDB_FilterAddr Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterAddr@16" (ByVal addrval As Long, ByVal sival As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_FilterCreate Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterCreate@4" (ByVal handleval As Long) As Long
Public Declare Function BTICSDB_FilterFill Lib "BTICSDB.DLL" Alias "_BTICSDB_FilterFill@12" (ByVal msgaddr As Long, ByVal basevaladdr As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICSDB_GetChanCount Lib "BTICSDB.DLL" Alias "_BTICSDB_GetChanCount@12" (ByRef rcvcount As Long, ByRef xmtcount As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_IsChan Lib "BTICSDB.DLL" Alias "_BTICSDB_IsChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_IsRcvChan Lib "BTICSDB.DLL" Alias "_BTICSDB_IsRcvChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_IsXmtChan Lib "BTICSDB.DLL" Alias "_BTICSDB_IsXmtChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListAddr Lib "BTICSDB.DLL" Alias "_BTICSDB_ListAddr@12" (ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListAddrEx Lib "BTICSDB.DLL" Alias "_BTICSDB_ListAddrEx@16" (ByVal index As Long, ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListAdvance Lib "BTICSDB.DLL" Alias "_BTICSDB_ListAdvance@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListClear Lib "BTICSDB.DLL" Alias "_BTICSDB_ListClear@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListConfig Lib "BTICSDB.DLL" Alias "_BTICSDB_ListConfig@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListConfigEx Lib "BTICSDB.DLL" Alias "_BTICSDB_ListConfigEx@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListDataRdEx Lib "BTICSDB.DLL" Alias "_BTICSDB_ListDataRdEx@20" (ByRef buf As Byte, ByVal count As Long, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListDataWrEx Lib "BTICSDB.DLL" Alias "_BTICSDB_ListDataWrEx@20" (ByRef buf As Byte, ByVal count As Long, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListInit Lib "BTICSDB.DLL" Alias "_BTICSDB_ListInit@12" (ByVal listaddr As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListNextRd Lib "BTICSDB.DLL" Alias "_BTICSDB_ListNextRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_ListNextWr Lib "BTICSDB.DLL" Alias "_BTICSDB_ListNextWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Sub BTICSDB_ListPostRd Lib "BTICSDB.DLL" Alias "_BTICSDB_ListPostRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Sub BTICSDB_ListPostWr Lib "BTICSDB.DLL" Alias "_BTICSDB_ListPostWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Sub BTICSDB_ListPreRd Lib "BTICSDB.DLL" Alias "_BTICSDB_ListPreRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Sub BTICSDB_ListPreWr Lib "BTICSDB.DLL" Alias "_BTICSDB_ListPreWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long)
Public Declare Function BTICSDB_MsgActivityRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgActivityRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICSDB_MsgActivityWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgActivityWr@12" (ByVal value As Integer, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_MsgCheck Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgCheck@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function BTICSDB_MsgCommRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgCommRd@12" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgCommWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgCommWr@12" (ByRef msgfields As MSGFIELDSCSDB, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgConfig Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgConfig@16" (ByVal configval As Long, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgCreateEx Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgCreateEx@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgFieldRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgFieldRd@12" (ByVal fieldtype As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgFieldWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgFieldWr@16" (ByVal fieldval As Long, ByVal fieldtype As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_MsgOptRd Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgOptRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICSDB_MsgOptWr Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgOptWr@12" (ByVal msgopt As Integer, ByVal msgaddr As Long, ByVal handleval As Long)
Public Declare Function BTICSDB_MsgReset Lib "BTICSDB.DLL" Alias "_BTICSDB_MsgReset@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedAgain Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedAgain@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedBranchEx Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedBranchEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedBuildEx Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedBuildEx@32" (ByVal nummsgs As Long, ByRef msgs As Long, ByRef freq As Long, ByVal interblockgap As Long, ByVal rsvdblocks As Long, ByVal bitrate As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedBuildExx Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedBuildExx@40" (ByVal nummsgs As Long, ByRef msgs As Long, ByRef freq As Long, ByVal interblockgap As Long, ByVal rsvdblocks As Long, ByVal bitrate As Long, ByRef buf As Long, ByVal bufsize As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedCallEx Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedCallEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedGCD Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedGCD@8" (ByVal a As Long, ByVal b As Long) As Long
Public Declare Function BTICSDB_SchedLCM Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedLCM@8" (ByVal a As Long, ByVal b As Long) As Long
Public Declare Function BTICSDB_SchedLogEx Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedLogEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal tagval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedNop Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedNop@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedPulse0 Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedPulse0@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedPulse1 Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedPulse1@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_SchedUser Lib "BTICSDB.DLL" Alias "_BTICSDB_SchedUser@12" (ByVal useraddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICSDB_TestProtocol Lib "BTICSDB.DLL" Alias "_BTICSDB_TestProtocol@4" (ByVal handleval As Long) As Long

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
'*  Bitrate configuration options
'*
'**/

Public Const BITRATECSDB_CLK1 As Integer = &H8000   '//CLK1, 20 MHz (default)
Public Const BITRATECSDB_CLK2 As Integer = &H0   '//CLK2, 9.216 MHz (standard option)
Public Const BITRATECSDB_XMTSLOPEHIGH As Integer = &H0   '//Transmit with high speed slope (default)
Public Const BITRATECSDB_XMTSLOPELOW As Integer = &H4000    '//Transmit with low speed slope

Public Const BITRATECSDB_921600BPS As Integer = &H0  '//External Clock, Div = 0
Public Const BITRATECSDB_460800BPS As Integer = &H1  '//External Clock, Div = 1
Public Const BITRATECSDB_230400BPS As Integer = &H3  '//External Clock, Div = 3
Public Const BITRATECSDB_115200BPS As Integer = &H7  '//External Clock, Div = 7
Public Const BITRATECSDB_57600BPS As Integer = &HF   '//External Clock, Div = 15
Public Const BITRATECSDB_38400BPS As Integer = &H17   '//External Clock, Div = 23
Public Const BITRATECSDB_28800BPS As Integer = &H1F   '//External Clock, Div = 31
Public Const BITRATECSDB_19200BPS As Integer = &H2F   '//External Clock, Div = 47
Public Const BITRATECSDB_14400BPS As Integer = &H3F   '//External Clock, Div = 63
Public Const BITRATECSDB_9600BPS As Integer = &H5F    '//External Clock, Div = 95
Public Const BITRATECSDB_7200BPS As Integer = &H7F    '//External Clock, Div = 127
Public Const BITRATECSDB_4800BPS As Integer = &HBF    '//External Clock, Div = 191
Public Const BITRATECSDB_3600BPS As Integer = &HFF    '//External Clock, Div = 255
Public Const BITRATECSDB_2400BPS As Integer = &H17F    '//External Clock, Div = 383
Public Const BITRATECSDB_1800BPS As Integer = &H1FF    '//External Clock, Div = 511
Public Const BITRATECSDB_1200BPS As Integer = &H2FF    '//External Clock, Div = 767
Public Const BITRATECSDB_900BPS As Integer = &H3FF '//External Clock, Div = 1023
Public Const BITRATECSDB_600BPS As Integer = &H5FF '//External Clock, Div = 1535
Public Const BITRATECSDB_300BPS As Integer = &HBFF '//External Clock, Div = 3071

Public Const BITRATECSDB_500000BPS As Integer = &H8003  '//Internal Clock, Div = 3
Public Const BITRATECSDB_400000BPS As Integer = &H8004  '//Internal Clock, Div = 4
Public Const BITRATECSDB_250000BPS As Integer = &H8007  '//Internal Clock, Div = 7
Public Const BITRATECSDB_200000BPS As Integer = &H8009  '//Internal Clock, Div = 9
Public Const BITRATECSDB_100000BPS As Integer = &H8013  '//Internal Clock, Div = 19
Public Const BITRATECSDB_80000BPS As Integer = &H8018   '//Internal Clock, Div = 24
Public Const BITRATECSDB_50000BPS As Integer = &H8027   '//Internal Clock, Div = 39
Public Const BITRATECSDB_40000BPS As Integer = &H8031   '//Internal Clock, Div = 49
Public Const BITRATECSDB_25000BPS As Integer = &H804F   '//Internal Clock, Div = 79
Public Const BITRATECSDB_20000BPS As Integer = &H8063   '//Internal Clock, Div = 99
Public Const BITRATECSDB_12500BPS As Integer = &H809F   '//Internal Clock, Div = 159
Public Const BITRATECSDB_10000BPS As Integer = &H80C7   '//Internal Clock, Div = 199

Public Const BITRATECSDB_HIGHSPEED As Integer = &HC027  '//Internal Clock, Div = 39
Public Const BITRATECSDB_LOWSPEED As Integer = &HC09F   '//Internal Clock, Div = 159

'/**
'*
'*  SDI selection constants
'*
'**/

Public Const SIALL As Long = &HFF '//Enable all SIs
Public Const SIx00 As Long = &H11 '//Enable SIx00
Public Const SIx01 As Long = &H22 '//Enable SIx01
Public Const SIx10 As Long = &H44 '//Enable SIx10
Public Const SIx11 As Long = &H88 '//Enable SIx11
Public Const SI000 As Long = &H1 '//Enable SI000
Public Const SI001 As Long = &H2 '//Enable SI001
Public Const SI010 As Long = &H4 '//Enable SI010
Public Const SI011 As Long = &H8 '//Enable SI011
Public Const SI100 As Long = &H10 '//Enable SI100
Public Const SI101 As Long = &H20 '//Enable SI101
Public Const SI110 As Long = &H40 '//Enable SI110
Public Const SI111 As Long = &H80 '//Enable SI111

'/**
'*
'*  Channel configuration options
'*
'**/

Public Const CHCFGCSDB_DEFAULT As Long = &H0 '//Select all default settings (XMT & RCV) (default)
Public Const CHCFGCSDB_SELFTESTOFF As Long = &H0 '//Disable internal wraparound (XMT & RCV) (default)
Public Const CHCFGCSDB_SELFTEST As Long = &H4    '//Enable internal wraparound (XMT & RCV)
Public Const CHCFGCSDB_PARITYODD As Long = &H0   '//Enable odd parity (XMT & RCV) (default)
Public Const CHCFGCSDB_PARITYNONE As Long = &H80000000  '//Disable parity (XMT & RCV)
Public Const CHCFGCSDB_PARITYEVEN As Long = &H40000000  '//Enable even parity (XMT & RCV)
Public Const CHCFGCSDB_PARITYMARK As Long = &H20000000  '//Force set parity (XMT & RCV)
Public Const CHCFGCSDB_PARITYSPACE As Long = &H10000000 '//Force clear parity (XMT & RCV)
Public Const CHCFGCSDB_ACTIVE As Long = &H0  '//Enable channel activity (XMT & RCV) (default)
Public Const CHCFGCSDB_INACTIVE As Long = &H40    '//Disable channel activity (XMT & RCV)
Public Const CHCFGCSDB_SEQSEL As Long = &H0  '//Sequential record recording is enabled at message level (default)
Public Const CHCFGCSDB_SEQALL As Long = &H80000  '//Record entire channel in sequential record
Public Const CHCFGCSDB_NOLOGHALT As Long = &H0   '//No event log on schedule halt (default)
Public Const CHCFGCSDB_LOGHALT As Long = &H200000 '//Enable event log on schedule halt
Public Const CHCFGCSDB_NOLOGPAUSE As Long = &H0  '//No event log on schedule pause (default)
Public Const CHCFGCSDB_LOGPAUSE As Long = &H400000    '//Enable event log on schedule pause
Public Const CHCFGCSDB_NOLOGERR As Long = &H0    '//No event log on decoder errors (default)
Public Const CHCFGCSDB_LOGERR As Long = &H800000  '//Enable event log on decoder errors and sync errors.
Public Const CHCFGCSDB_TIMETAGOFF As Long = &H0  '//Time-tag is enabled on message level (default)
Public Const CHCFGCSDB_TIMETAG As Long = &H400 '//Enable time-tag for all message records
Public Const CHCFGCSDB_NOHIT As Long = &H0   '//Hit counter is enabled on message level (default)
Public Const CHCFGCSDB_HIT As Long = &H200 '//Hit counter is enabled for all messages
Public Const CHCFGCSDB_ELAPSEOFF As Long = &H0   '//Elapse time is enabled on message level (default)
Public Const CHCFGCSDB_ELAPSE As Long = &H800  '//Enable elapse time for all messages
Public Const CHCFGCSDB_MAXMINOFF As Long = &H0   '//Repetition rate monitoring is enabled on message level (default)
Public Const CHCFGCSDB_MAX As Long = &H1000 '//Enable max repetition rate monitoring for all messages
Public Const CHCFGCSDB_MIN As Long = &H2000 '//Enable min repetition rate monitoring for all messages
Public Const CHCFGCSDB_MAXMIN As Long = &H3000  '//Enable max and min repetition rate monitoring for all messages
Public Const CHCFGCSDB_NOLOOPMAX As Long = &H0   '//Disable schedule maximum loop count (default)
Public Const CHCFGCSDB_LOOPMAX As Long = &H100000 '//Enable schedule maximum loop count
Public Const CHCFGCSDB_UNPAUSE As Long = &H0 '//Mark channel as unpaused (default)
Public Const CHCFGCSDB_PAUSE As Long = &H1000000   '//Mark channel as paused
Public Const CHCFGCSDB_BUSINVERTOFF As Long = &H0    '//No bus inversion (default)
Public Const CHCFGCSDB_BUSINVERT As Long = &H1   '//Enable bus inversion
Public Const CHCFGCSDB_MODE422 As Long = &H0 '//Enable RS-422 mode (balanced) (XMT) (default)
Public Const CHCFGCSDB_MODE232 As Long = &H8000000 '//Enable RS-232 / RS-423 mode (unbalanced) (XMT)
Public Const CHCFGCSDB_SYNCMODE As Long = &H0    '//Synchronous scheduled mode (CSDB) (default)
Public Const CHCFGCSDB_ASYNCMODE As Long = &H2   '//Asynchrounous mode (general purpose serial)

'/**
'*
'*  Message configuration options
'*
'**/

Public Const MSGCRTCSDB_DEFAULT As Long = &H0    '//Default settings
Public Const MSGCRTCSDB_NOSEQ As Long = &H0  '//Message will not be recorded in sequential record (default)
Public Const MSGCRTCSDB_SEQ As Long = &H1    '//Message will be recorded in sequential record
Public Const MSGCRTCSDB_NOLOG As Long = &H0  '//Message will not generate event log (default)
Public Const MSGCRTCSDB_LOG As Long = &H2    '//Message will generate event log
Public Const MSGCRTCSDB_NOERROR As Long = &H0    '//Message will not generate errors (default)
Public Const MSGCRTCSDB_ERROR As Long = &H4  '//Message can generate errors
Public Const MSGCRTCSDB_NOSKIP As Long = &H0 '//Message will not be skipped (default)
Public Const MSGCRTCSDB_SKIP As Long = &H8   '//Message will be skipped
Public Const MSGCRTCSDB_NOTIMETAG As Long = &H0  '//Message will not record time-tag (default)
Public Const MSGCRTCSDB_TIMETAG As Long = &H10    '//Message will record time-tag
Public Const MSGCRTCSDB_NOELAPSE As Long = &H0   '//Message will not record elapse time (default)
Public Const MSGCRTCSDB_ELAPSE As Long = &H20 '//Message will record elapse time
Public Const MSGCRTCSDB_NOMAXMIN As Long = &H0   '//Message will not record min/max time (default)
Public Const MSGCRTCSDB_MAX As Long = &H40    '//Message will record max time
Public Const MSGCRTCSDB_MIN As Long = &H80    '//Message will record min time
Public Const MSGCRTCSDB_MAXMIN As Long = &HC0 '//Message will record min/max time
Public Const MSGCRTCSDB_NOHIT As Long = &H0  '//Message will not record hit count (default)
Public Const MSGCRTCSDB_HIT As Long = &H800    '//Message will record hit count
Public Const MSGCRTCSDB_WIPE As Long = &H0   '//Enables message clear (default)
Public Const MSGCRTCSDB_NOWIPE As Long = &H80000000 '//Disables message clear
Public Const MSGCRTCSDB_WIPE0 As Long = &H0  '//Initialize data with zeros (default)
Public Const MSGCRTCSDB_WIPE1 As Long = &H40000000  '//Initialize data with ones
Public Const MSGCRTCSDB_WIPESYNC As Long = &H20000000   '//Initialize data with 0xA5
Public Const MSGCRTCSDB_CONT As Long = &H0   '//Selects continuous mode (default)
Public Const MSGCRTCSDB_NONCONT As Long = &H2000    '//Selects non-continuous mode
Public Const MSGCRTCSDB_BURST As Long = &H4000  '//Selects burst mode

'/**
'*
'*  List buffer options
'*
'**/

Public Const LISTCRTCSDB_DEFAULT As Long = &H0   '//Select all default settings
Public Const LISTCRTCSDB_FIFO As Long = &H0  '//Enable FIFO mode (default)
Public Const LISTCRTCSDB_PINGPONG As Long = &H1  '//Enable ping-pong mode
Public Const LISTCRTCSDB_CIRCULAR As Long = &H2  '//Enable circular mode
Public Const LISTCRTCSDB_RCV As Long = &H10   '//User will read from list buffer
Public Const LISTCRTCSDB_XMT As Long = &H20   '//User will write to list buffer
Public Const LISTCRTCSDB_NOLOG As Long = &H0 '//Do not generate event log when list buffer empty/full (default)
Public Const LISTCRTCSDB_LOG As Long = &H100   '//Generate event log when list buffer empty/full

'/**
'*
'*  Parametric configuration options
'*
'**/

Public Const PARAMCFGCSDB_DEFAULT As Long = &H0  '//Select all default settings (default)
Public Const PARAMCFGCSDB_AMPLON As Long = &H0   '//Enables parametric amplitude control (default)
Public Const PARAMCFGCSDB_AMPLOFF As Long = &H1  '//Disables parametric amplitude control

'/**
'*
'*  Scheduling conditions.
'*
'**/

Public Const CONDCSDB_ALWAYS As Long = &H0   '//Unconditional
Public Const CONDCSDB_DIO1ACT As Long = &H1  '//Condition on digital I/O #1 active
Public Const CONDCSDB_DIO1NACT As Long = &H2 '//Condition on digital I/O #1 not active
Public Const CONDCSDB_DIO2ACT As Long = &H4  '//Condition on digital I/O #2 active
Public Const CONDCSDB_DIO2NACT As Long = &H8 '//Condition on digital I/O #2 not active
Public Const CONDCSDB_DIO3ACT As Long = &H10  '//Condition on digital I/O #3 active
Public Const CONDCSDB_DIO3NACT As Long = &H20 '//Condition on digital I/O #3 not active
Public Const CONDCSDB_DIO4ACT As Long = &H40  '//Condition on digital I/O #4 active
Public Const CONDCSDB_DIO4NACT As Long = &H80 '//Condition on digital I/O #4 not active
Public Const CONDCSDB_DIO5ACT As Long = &H100  '//Condition on digital I/O #5 active
Public Const CONDCSDB_DIO5NACT As Long = &H200 '//Condition on digital I/O #5 not active
Public Const CONDCSDB_DIO6ACT As Long = &H400  '//Condition on digital I/O #6 active
Public Const CONDCSDB_DIO6NACT As Long = &H800 '//Condition on digital I/O #6 not active
Public Const CONDCSDB_DIO7ACT As Long = &H1000  '//Condition on digital I/O #7 active
Public Const CONDCSDB_DIO7NACT As Long = &H2000 '//Condition on digital I/O #7 not active
Public Const CONDCSDB_DIO8ACT As Long = &H4000  '//Condition on digital I/O #8 active
Public Const CONDCSDB_DIO8NACT As Long = &H8000 '//Condition on digital I/O #8 not active

'/**
'*
'*  Bit fields of the message activity flag.
'*
'**/

Public Const MSGACTCSDB_CHMASK As Long = &HFF00 '//Channel number mask value
Public Const MSGACTCSDB_CHSHIFT As Long = &H8    '//Channel number shift value
Public Const MSGACTCSDB_ERR As Long = &H80    '//Error bit
Public Const MSGACTCSDB_BIT As Long = &H40    '//Bit time error bit
Public Const MSGACTCSDB_NRZ As Long = &H20    '//NRZ bit error
Public Const MSGACTCSDB_EDGE As Long = &H10   '//Edge bit error
Public Const MSGACTCSDB_PAR As Long = &H8    '//Parity error bit
Public Const MSGACTCSDB_FRAME As Long = &H4  '//Frame error bit
Public Const MSGACTCSDB_HIT As Long = &H1    '//Always set

'/**
'*
'*  Channel info fields.
'*
'**/

Public Const INFOCSDB_PARAM As Long = &H1    '//Channel supports parametric control
