'/**
'*
'*  LP429-3 and LC429-3 WIN32 DRIVER  Version 2.0.1  (05/27/2009)
'*  Copyright (c) 1998-2009
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   L43W32.BAS -- 32-bit
'*                      L43 Driver Include Header File.
'*
'**/

'/**
'*
'*  Structs used by the L43 Driver.
'*
'**/

Public Type MSGSTRUCT
	addr As Long
	data As Long
End Type

Public Type SEQRECORD
	vercount As Integer
	timestampl As Integer
	timestamph As Integer
	activity As Integer
	data As Long
	wordnum As Integer	'//ARINC 717 records only
	subframe As Integer	'//ARINC 717 records only
	superframe As Integer	'//ARINC 717 records only
End Type

Public Type MSGFIELDS
	msgopt As Integer	'//User writes message optionvals
	msgact As Integer	'//Card writes message activity
	msgdata_listptr As Long	'//Card/User writes message data (Rcv/Xmt) - '//User writes list buffer pointer
	timetag_hitcount As Long	'//Card writes time tag - '//Card writes hit count
	maxtime_elapsetime As Long	'//Card writes max time - '//Card writes elapsed time
	mintime As Long	'//Card writes min time
	userptr As Long	'//User writes user code pointer
	miscptr As Long	'//User writes misc. pointer
	rsvd As Long	'//Reserved
End Type

'/**
'*
'*  L43 Driver functions.
'*
'**/

'/**
'*
'*  L43/717 functions.
'*
'**/

'/**
'*
'*  Internal functions used by the L43 Driver.
'*
'**/

Public Declare Function L43_BCDGetData Lib "L43W32.DLL" Alias "_L43_BCDGetData@12" (ByVal msg As Long, ByVal msb As Integer, ByVal lsb As Integer) As Long
Public Declare Function L43_BCDGetMant Lib "L43W32.DLL" Alias "_L43_BCDGetMant@8" (ByVal msg As Long, ByVal sigdig As Integer) As Long
Public Declare Function L43_BCDGetSign Lib "L43W32.DLL" Alias "_L43_BCDGetSign@4" (ByVal msg As Long) As Integer
Public Declare Function L43_BCDGetSSM Lib "L43W32.DLL" Alias "_L43_BCDGetSSM@4" (ByVal msg As Long) As Integer
Public Declare Function L43_BCDGetVal Lib "L43W32.DLL" Alias "_L43_BCDGetVal@16" (ByRef buf As String, ByVal msg As Long, ByVal sigdig As Integer, ByRef resolstr As String) As Long
Public Declare Function L43_BCDPutData Lib "L43W32.DLL" Alias "_L43_BCDPutData@16" (ByVal msg As Long, ByVal value As Long, ByVal msb As Integer, ByVal lsb As Integer) As Long
Public Declare Function L43_BCDPutMant Lib "L43W32.DLL" Alias "_L43_BCDPutMant@16" (ByVal msg As Long, ByVal value As Long, ByVal sigdig As Integer, ByVal sign As Integer) As Long
Public Declare Function L43_BCDPutSign Lib "L43W32.DLL" Alias "_L43_BCDPutSign@8" (ByVal msg As Long, ByVal sign As Integer) As Long
Public Declare Function L43_BCDPutSSM Lib "L43W32.DLL" Alias "_L43_BCDPutSSM@8" (ByVal msg As Long, ByVal value As Integer) As Long
Public Declare Function L43_BCDPutVal Lib "L43W32.DLL" Alias "_L43_BCDPutVal@16" (ByRef buf As String, ByVal msg As Long, ByVal sigdig As Integer, ByRef resolstr As String) As Long
Public Declare Function L43_BNRGetData Lib "L43W32.DLL" Alias "_L43_BNRGetData@12" (ByVal msg As Long, ByVal msb As Integer, ByVal lsb As Integer) As Long
Public Declare Function L43_BNRGetMant Lib "L43W32.DLL" Alias "_L43_BNRGetMant@8" (ByVal msg As Long, ByVal sigbit As Integer) As Long
Public Declare Function L43_BNRGetSign Lib "L43W32.DLL" Alias "_L43_BNRGetSign@4" (ByVal msg As Long) As Integer
Public Declare Function L43_BNRGetSSM Lib "L43W32.DLL" Alias "_L43_BNRGetSSM@4" (ByVal msg As Long) As Integer
Public Declare Function L43_BNRGetVal Lib "L43W32.DLL" Alias "_L43_BNRGetVal@16" (ByRef buf As String, ByVal msg As Long, ByVal sigbit As Integer, ByRef resolstr As String) As Long
Public Declare Function L43_BNRPutData Lib "L43W32.DLL" Alias "_L43_BNRPutData@16" (ByVal msg As Long, ByVal value As Long, ByVal msb As Integer, ByVal lsb As Integer) As Long
Public Declare Function L43_BNRPutMant Lib "L43W32.DLL" Alias "_L43_BNRPutMant@16" (ByVal msg As Long, ByVal value As Long, ByVal sigbit As Integer, ByVal twos As Integer) As Long
Public Declare Function L43_BNRPutSign Lib "L43W32.DLL" Alias "_L43_BNRPutSign@8" (ByVal msg As Long, ByVal twos As Integer) As Long
Public Declare Function L43_BNRPutSSM Lib "L43W32.DLL" Alias "_L43_BNRPutSSM@8" (ByVal msg As Long, ByVal value As Integer) As Long
Public Declare Function L43_BNRPutVal Lib "L43W32.DLL" Alias "_L43_BNRPutVal@16" (ByRef buf As String, ByVal msg As Long, ByVal sigbit As Integer, ByRef resolstr As String) As Long
Public Declare Function L43_BrdNumRd Lib "L43W32.DLL" Alias "_L43_BrdNumRd@4" (ByVal handleval As Long) As Integer
Public Declare Function L43_BrdNumWr Lib "L43W32.DLL" Alias "_L43_BrdNumWr@8" (ByVal brdnum As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_CardClose Lib "L43W32.DLL" Alias "_L43_CardClose@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardOpen Lib "L43W32.DLL" Alias "_L43_CardOpen@4" (ByVal cardnum As Long) As Long
Public Declare Function L43_CardReset Lib "L43W32.DLL" Alias "_L43_CardReset@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardResume Lib "L43W32.DLL" Alias "_L43_CardResume@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardStart Lib "L43W32.DLL" Alias "_L43_CardStart@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardStop Lib "L43W32.DLL" Alias "_L43_CardStop@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardTrigger Lib "L43W32.DLL" Alias "_L43_CardTrigger@4" (ByVal handleval As Long) As Long
Public Declare Function L43_ChClear Lib "L43W32.DLL" Alias "_L43_ChClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChConfig Lib "L43W32.DLL" Alias "_L43_ChConfig@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChPause Lib "L43W32.DLL" Alias "_L43_ChPause@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChPauseCheck Lib "L43W32.DLL" Alias "_L43_ChPauseCheck@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChResume Lib "L43W32.DLL" Alias "_L43_ChResume@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ExtDinRd Lib "L43W32.DLL" Alias "_L43_ExtDinRd@4" (ByVal handleval As Long) As Long
Public Declare Function L43_ExtDinWr Lib "L43W32.DLL" Alias "_L43_ExtDinWr@8" (ByVal dinval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ExtDIORd Lib "L43W32.DLL" Alias "_L43_ExtDIORd@8" (ByVal dionum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ExtDIOWr Lib "L43W32.DLL" Alias "_L43_ExtDIOWr@12" (ByVal dionum As Long, ByVal dioval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ExtLEDRd Lib "L43W32.DLL" Alias "_L43_ExtLEDRd@4" (ByVal handleval As Long) As Long
Public Declare Function L43_ExtLEDWr Lib "L43W32.DLL" Alias "_L43_ExtLEDWr@8" (ByVal ledval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_FilterClear Lib "L43W32.DLL" Alias "_L43_FilterClear@8" (ByVal basevaladdr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_FilterDefault Lib "L43W32.DLL" Alias "_L43_FilterDefault@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_FilterRd Lib "L43W32.DLL" Alias "_L43_FilterRd@16" (ByVal labelval As Long, ByVal sdival As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_FilterSet Lib "L43W32.DLL" Alias "_L43_FilterSet@20" (ByVal configval As Long, ByVal labelval As Long, ByVal sdimask As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_FilterWr Lib "L43W32.DLL" Alias "_L43_FilterWr@20" (ByVal msgaddr As Long, ByVal labelval As Long, ByVal sdival As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_FldGetData Lib "L43W32.DLL" Alias "_L43_FldGetData@4" (ByVal msgval As Long) As Long
Public Declare Function L43_FldGetLabel Lib "L43W32.DLL" Alias "_L43_FldGetLabel@4" (ByVal msgval As Long) As Integer
Public Declare Function L43_FldGetParity Lib "L43W32.DLL" Alias "_L43_FldGetParity@4" (ByVal msgval As Long) As Integer
Public Declare Function L43_FldGetSDI Lib "L43W32.DLL" Alias "_L43_FldGetSDI@4" (ByVal msgval As Long) As Integer
Public Declare Function L43_FldGetValue Lib "L43W32.DLL" Alias "_L43_FldGetValue@12" (ByVal msgval As Long, ByVal startbit As Integer, ByVal endbit As Integer) As Long
Public Declare Function L43_FldPutData Lib "L43W32.DLL" Alias "_L43_FldPutData@8" (ByVal msgval As Long, ByVal data As Long) As Long
Public Declare Function L43_FldPutLabel Lib "L43W32.DLL" Alias "_L43_FldPutLabel@8" (ByVal msgval As Long, ByVal label As Integer) As Long
Public Declare Function L43_FldPutSDI Lib "L43W32.DLL" Alias "_L43_FldPutSDI@8" (ByVal msgval As Long, ByVal sdi As Integer) As Long
Public Declare Function L43_FldPutValue Lib "L43W32.DLL" Alias "_L43_FldPutValue@16" (ByVal msgval As Long, ByVal dataval As Long, ByVal startbit As Integer, ByVal endbit As Integer) As Long
Public Declare Function L43_GetChanCount Lib "L43W32.DLL" Alias "_L43_GetChanCount@12" (ByRef rcvcount As Long, ByRef xmtcount As Long, ByVal handleval As Long) As Long
Public Declare Function L43_IntConfig Lib "L43W32.DLL" Alias "_L43_IntConfig@12" (ByVal configval As Integer, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_IntInstall Lib "L43W32.DLL" Alias "_L43_IntInstall@8" (ByRef hevent As Long, ByVal handleval As Long) As Long
Public Declare Function L43_IntRd Lib "L43W32.DLL" Alias "_L43_IntRd@12" (ByRef typevalval As Integer, ByRef infoval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_IntReset Lib "L43W32.DLL" Alias "_L43_IntReset@4" (ByVal handleval As Long) As Long
Public Declare Function L43_IntStatus Lib "L43W32.DLL" Alias "_L43_IntStatus@4" (ByVal handleval As Long) As Long
Public Declare Function L43_IntUninstall Lib "L43W32.DLL" Alias "_L43_IntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function L43_IsChan Lib "L43W32.DLL" Alias "_L43_IsChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_IsRcvChan Lib "L43W32.DLL" Alias "_L43_IsRcvChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_IsXmtChan Lib "L43W32.DLL" Alias "_L43_IsXmtChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListAsyncCreate Lib "L43W32.DLL" Alias "_L43_ListAsyncCreate@16" (ByVal listconfigval As Long, ByVal count As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListDataRd Lib "L43W32.DLL" Alias "_L43_ListDataRd@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListDataWr Lib "L43W32.DLL" Alias "_L43_ListDataWr@12" (ByVal value As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListRcvCreate Lib "L43W32.DLL" Alias "_L43_ListRcvCreate@16" (ByVal listconfigval As Long, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListXmtCreate Lib "L43W32.DLL" Alias "_L43_ListXmtCreate@16" (ByVal listconfigval As Long, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgBlockRd Lib "L43W32.DLL" Alias "_L43_MsgBlockRd@12" (ByRef msgfields As MSGFIELDS, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgBlockWr Lib "L43W32.DLL" Alias "_L43_MsgBlockWr@12" (ByRef msgfields As MSGFIELDS, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgCommRd Lib "L43W32.DLL" Alias "_L43_MsgCommRd@12" (ByRef msgfields As MSGFIELDS, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgCommWr Lib "L43W32.DLL" Alias "_L43_MsgCommWr@12" (ByRef msgfields As MSGFIELDS, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgCreate Lib "L43W32.DLL" Alias "_L43_MsgCreate@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgDataRd Lib "L43W32.DLL" Alias "_L43_MsgDataRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgDataWr Lib "L43W32.DLL" Alias "_L43_MsgDataWr@12" (ByVal value As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgIsAccessed Lib "L43W32.DLL" Alias "_L43_MsgIsAccessed@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedBranch Lib "L43W32.DLL" Alias "_L43_SchedBranch@16" (ByVal condition As Integer, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedBuild Lib "L43W32.DLL" Alias "_L43_SchedBuild@24" (ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef minperiod As Long, ByRef maxperiod As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedCall Lib "L43W32.DLL" Alias "_L43_SchedCall@16" (ByVal condition As Integer, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedEntry Lib "L43W32.DLL" Alias "_L43_SchedEntry@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedGap Lib "L43W32.DLL" Alias "_L43_SchedGap@12" (ByVal gapval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedGapFixed Lib "L43W32.DLL" Alias "_L43_SchedGapFixed@12" (ByVal gapval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedGapList Lib "L43W32.DLL" Alias "_L43_SchedGapList@16" (ByVal gapval As Integer, ByVal listaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedHalt Lib "L43W32.DLL" Alias "_L43_SchedHalt@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedInt Lib "L43W32.DLL" Alias "_L43_SchedInt@16" (ByVal condition As Integer, ByVal tagval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedMsg Lib "L43W32.DLL" Alias "_L43_SchedMsg@12" (ByVal msgaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedMsgEx Lib "L43W32.DLL" Alias "_L43_SchedMsgEx@16" (ByVal msgaddr As Long, ByVal gapval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedPause Lib "L43W32.DLL" Alias "_L43_SchedPause@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedPulse Lib "L43W32.DLL" Alias "_L43_SchedPulse@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedRestart Lib "L43W32.DLL" Alias "_L43_SchedRestart@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedReturn Lib "L43W32.DLL" Alias "_L43_SchedReturn@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SeqConfig Lib "L43W32.DLL" Alias "_L43_SeqConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SeqInterval Lib "L43W32.DLL" Alias "_L43_SeqInterval@12" (ByVal interval As Long, ByVal mode As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SeqIntFrequency Lib "L43W32.DLL" Alias "_L43_SeqIntFrequency@8" (ByVal intfreq As Integer, ByVal handleval As Long) As Integer
Public Declare Function L43_SeqIsRunning Lib "L43W32.DLL" Alias "_L43_SeqIsRunning@4" (ByVal handleval As Long) As Long
Public Declare Function L43_SeqRd Lib "L43W32.DLL" Alias "_L43_SeqRd@8" (ByRef buf As SEQRECORD, ByVal handleval As Long) As Integer
Public Declare Function L43_SeqStatus Lib "L43W32.DLL" Alias "_L43_SeqStatus@4" (ByVal handleval As Long) As Long
Public Declare Function L43_TimerClear Lib "L43W32.DLL" Alias "_L43_TimerClear@4" (ByVal handleval As Long) As Long
Public Declare Function L43_TimerRd Lib "L43W32.DLL" Alias "_L43_TimerRd@4" (ByVal handleval As Long) As Long
Public Declare Function L43_TimerResolution Lib "L43W32.DLL" Alias "_L43_TimerResolution@8" (ByVal timerresol As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Ch717Status Lib "L43W32.DLL" Alias "_L43_Ch717Status@12" (ByRef buf As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Get717ChanCount Lib "L43W32.DLL" Alias "_L43_Get717ChanCount@12" (ByRef rcvcount As Long, ByRef xmtcount As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Is717BiPhaseChan Lib "L43W32.DLL" Alias "_L43_Is717BiPhaseChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Is717Chan Lib "L43W32.DLL" Alias "_L43_Is717Chan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Is717RcvChan Lib "L43W32.DLL" Alias "_L43_Is717RcvChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Is717XmtChan Lib "L43W32.DLL" Alias "_L43_Is717XmtChan@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SubFrmBlkRd Lib "L43W32.DLL" Alias "_L43_SubFrmBlkRd@16" (ByRef databuf As Integer, ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SubFrmBlkWr Lib "L43W32.DLL" Alias "_L43_SubFrmBlkWr@16" (ByRef databuf As Integer, ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SubFrmStatus Lib "L43W32.DLL" Alias "_L43_SubFrmStatus@16" (ByRef buf As Integer, ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SubFrmWordConfig Lib "L43W32.DLL" Alias "_L43_SubFrmWordConfig@20" (ByVal configval As Long, ByVal subframe As Long, ByVal word As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SubFrmWordRd Lib "L43W32.DLL" Alias "_L43_SubFrmWordRd@20" (ByRef value As Integer, ByVal subframe As Long, ByVal word As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SubFrmWordWr Lib "L43W32.DLL" Alias "_L43_SubFrmWordWr@20" (ByVal value As Integer, ByVal subframe As Long, ByVal word As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SuperFrmConfig Lib "L43W32.DLL" Alias "_L43_SuperFrmConfig@16" (ByVal count As Long, ByVal framespersuperframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SuperFrmCounterPos Lib "L43W32.DLL" Alias "_L43_SuperFrmCounterPos@16" (ByVal subframe As Long, ByVal word As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SuperFrmDefine Lib "L43W32.DLL" Alias "_L43_SuperFrmDefine@16" (ByVal subframe As Long, ByVal word As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SuperFrmWordRd Lib "L43W32.DLL" Alias "_L43_SuperFrmWordRd@20" (ByRef value As Integer, ByVal superfrmnum As Long, ByVal superfrmaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SuperFrmWordWr Lib "L43W32.DLL" Alias "_L43_SuperFrmWordWr@20" (ByVal value As Integer, ByVal superfrmnum As Long, ByVal superfrmaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SuperFrmWordConfig Lib "L43W32.DLL" Alias "_L43_SuperFrmWordConfig@20" (ByVal configval As Long, ByVal superfrmnum As Long, ByVal superfrmaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SyncTest Lib "L43W32.DLL" Alias "_L43_SyncTest@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SyncValRd Lib "L43W32.DLL" Alias "_L43_SyncValRd@24" (ByRef syncword1 As Long, ByRef syncword2 As Long, ByRef syncword3 As Long, ByRef syncword4 As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SyncValWr Lib "L43W32.DLL" Alias "_L43_SyncValWr@24" (ByVal syncword1 As Long, ByVal syncword2 As Long, ByVal syncword3 As Long, ByVal syncword4 As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_AddrDSP Lib "L43W32.DLL" Alias "_L43_AddrDSP@4" (ByVal addr As Long) As Long
Public Declare Function L43_AddrHost Lib "L43W32.DLL" Alias "_L43_AddrHost@4" (ByVal addr As Long) As Long
Public Declare Function L43_AsciiToMant Lib "L43W32.DLL" Alias "_L43_AsciiToMant@12" (ByRef str As String, ByRef mant As Long, ByRef exp As Long) As Long
Public Declare Function L43_CardBoot Lib "L43W32.DLL" Alias "_L43_CardBoot@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardCloseAll Lib "L43W32.DLL" Alias "_L43_CardCloseAll@0" () As Long
Public Declare Function L43_CardGetInfo Lib "L43W32.DLL" Alias "_L43_CardGetInfo@8" (ByVal infotype As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_CardGetInfoEx Lib "L43W32.DLL" Alias "_L43_CardGetInfoEx@20" (ByRef bufmodel As Integer, ByVal bufmodelcount As Integer, ByRef buffeature As Integer, ByVal buffeaturecount As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_CardInit Lib "L43W32.DLL" Alias "_L43_CardInit@0" () As Long
Public Declare Function L43_CardIsRunning Lib "L43W32.DLL" Alias "_L43_CardIsRunning@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardNop Lib "L43W32.DLL" Alias "_L43_CardNop@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardOpenEx Lib "L43W32.DLL" Alias "_L43_CardOpenEx@8" (ByRef cardname As String, ByVal cardnum As Long) As Long
Public Declare Function L43_CardOpenExx Lib "L43W32.DLL" Alias "_L43_CardOpenExx@16" (ByRef cardname As String, ByVal cardnum As Long, ByRef happwnd As Long, ByVal uiremovalmsg As Integer) As Long
Public Declare Function L43_CardResetEx Lib "L43W32.DLL" Alias "_L43_CardResetEx@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardTest Lib "L43W32.DLL" Alias "_L43_CardTest@8" (ByVal level As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_CardTest0 Lib "L43W32.DLL" Alias "_L43_CardTest0@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardTest1 Lib "L43W32.DLL" Alias "_L43_CardTest1@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardTest2 Lib "L43W32.DLL" Alias "_L43_CardTest2@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CardTest3 Lib "L43W32.DLL" Alias "_L43_CardTest3@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CFGRdL Lib "L43W32.DLL" Alias "_L43_CFGRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CFGWrL Lib "L43W32.DLL" Alias "_L43_CFGWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Ch717Config Lib "L43W32.DLL" Alias "_L43_Ch717Config@12" (ByVal configval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Ch717Create Lib "L43W32.DLL" Alias "_L43_Ch717Create@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Ch717Reset Lib "L43W32.DLL" Alias "_L43_Ch717Reset@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChConfigEx Lib "L43W32.DLL" Alias "_L43_ChConfigEx@16" (ByVal configval As Long, ByVal count As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChDARClr Lib "L43W32.DLL" Alias "_L43_ChDARClr@16" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChDARGet Lib "L43W32.DLL" Alias "_L43_ChDARGet@16" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChDARRdL Lib "L43W32.DLL" Alias "_L43_ChDARRdL@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChDARRdW Lib "L43W32.DLL" Alias "_L43_ChDARRdW@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_ChDARSet Lib "L43W32.DLL" Alias "_L43_ChDARSet@16" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChDARWrL Lib "L43W32.DLL" Alias "_L43_ChDARWrL@16" (ByVal value As Long, ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChDARWrW Lib "L43W32.DLL" Alias "_L43_ChDARWrW@16" (ByVal value As Integer, ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChStart Lib "L43W32.DLL" Alias "_L43_ChStart@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ChStop Lib "L43W32.DLL" Alias "_L43_ChStop@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdAddr Lib "L43W32.DLL" Alias "_L43_CmdAddr@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdAlloc Lib "L43W32.DLL" Alias "_L43_CmdAlloc@8" (ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdAllocEx Lib "L43W32.DLL" Alias "_L43_CmdAllocEx@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdBaseRd Lib "L43W32.DLL" Alias "_L43_CmdBaseRd@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdBaseWr Lib "L43W32.DLL" Alias "_L43_CmdBaseWr@12" (ByVal addrval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdClear Lib "L43W32.DLL" Alias "_L43_CmdClear@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdCountRd Lib "L43W32.DLL" Alias "_L43_CmdCountRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_CmdCountWr Lib "L43W32.DLL" Alias "_L43_CmdCountWr@12" (ByVal countval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdCtrlRd Lib "L43W32.DLL" Alias "_L43_CmdCtrlRd@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_CmdCtrlWr Lib "L43W32.DLL" Alias "_L43_CmdCtrlWr@16" (ByVal ctrlval As Integer, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdCurrRd Lib "L43W32.DLL" Alias "_L43_CmdCurrRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_CmdCurrWr Lib "L43W32.DLL" Alias "_L43_CmdCurrWr@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdInit Lib "L43W32.DLL" Alias "_L43_CmdInit@8" (ByVal opcode As Integer, ByRef block As Integer) As Long
Public Declare Function L43_CmdInsert Lib "L43W32.DLL" Alias "_L43_CmdInsert@12" (ByRef block As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdMaxRd Lib "L43W32.DLL" Alias "_L43_CmdMaxRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_CmdMaxWr Lib "L43W32.DLL" Alias "_L43_CmdMaxWr@12" (ByVal count As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdRd Lib "L43W32.DLL" Alias "_L43_CmdRd@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdShotWr Lib "L43W32.DLL" Alias "_L43_CmdShotWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdSkipWr Lib "L43W32.DLL" Alias "_L43_CmdSkipWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdStackClr Lib "L43W32.DLL" Alias "_L43_CmdStackClr@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdStartRd Lib "L43W32.DLL" Alias "_L43_CmdStartRd@8" (ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_CmdStartWr Lib "L43W32.DLL" Alias "_L43_CmdStartWr@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdStepWr Lib "L43W32.DLL" Alias "_L43_CmdStepWr@16" (ByVal value As Long, ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdTotalRd Lib "L43W32.DLL" Alias "_L43_CmdTotalRd@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdTotalWr Lib "L43W32.DLL" Alias "_L43_CmdTotalWr@12" (ByVal countval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CmdWr Lib "L43W32.DLL" Alias "_L43_CmdWr@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CommCall Lib "L43W32.DLL" Alias "_L43_CommCall@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CommCheck Lib "L43W32.DLL" Alias "_L43_CommCheck@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CommDisable Lib "L43W32.DLL" Alias "_L43_CommDisable@8" (ByVal command As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_CommDisableEx Lib "L43W32.DLL" Alias "_L43_CommDisableEx@8" (ByVal command As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_CommEnable Lib "L43W32.DLL" Alias "_L43_CommEnable@4" (ByVal handleval As Long) As Long
Public Declare Function L43_CommRdL Lib "L43W32.DLL" Alias "_L43_CommRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CommRdsW Lib "L43W32.DLL" Alias "_L43_CommRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_CommRdW Lib "L43W32.DLL" Alias "_L43_CommRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_CommRun Lib "L43W32.DLL" Alias "_L43_CommRun@20" (ByRef dataptr As Integer, ByVal datacount As Integer, ByRef codeptr As Integer, ByVal codecount As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_CommWrL Lib "L43W32.DLL" Alias "_L43_CommWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_CommWrsW Lib "L43W32.DLL" Alias "_L43_CommWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_CommWrW Lib "L43W32.DLL" Alias "_L43_CommWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ConvFromArinc Lib "L43W32.DLL" Alias "_L43_ConvFromArinc@4" (ByVal msgval As Long) As Long
Public Declare Function L43_ConvToArinc Lib "L43W32.DLL" Alias "_L43_ConvToArinc@4" (ByVal msgval As Long) As Long
Public Declare Function L43_DARClr Lib "L43W32.DLL" Alias "_L43_DARClr@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_DARGet Lib "L43W32.DLL" Alias "_L43_DARGet@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_DARRdL Lib "L43W32.DLL" Alias "_L43_DARRdL@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_DARRdW Lib "L43W32.DLL" Alias "_L43_DARRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function L43_DARSet Lib "L43W32.DLL" Alias "_L43_DARSet@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_DARWrL Lib "L43W32.DLL" Alias "_L43_DARWrL@12" (ByVal value As Long, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_DARWrW Lib "L43W32.DLL" Alias "_L43_DARWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_Div Lib "L43W32.DLL" Alias "_L43_Div@8" (ByVal diva As Long, ByVal divb As Long) As Long
Public Declare Function L43_DllUsageCount Lib "L43W32.DLL" Alias "_L43_DllUsageCount@0" () As Long
Public Declare Function L43_DPMMRdW Lib "L43W32.DLL" Alias "_L43_DPMMRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_DPMMWrW Lib "L43W32.DLL" Alias "_L43_DPMMWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_DPMRdB Lib "L43W32.DLL" Alias "_L43_DPMRdB@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_DPMRdL Lib "L43W32.DLL" Alias "_L43_DPMRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_DPMRdsL Lib "L43W32.DLL" Alias "_L43_DPMRdsL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_DPMRdsW Lib "L43W32.DLL" Alias "_L43_DPMRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_DPMRdW Lib "L43W32.DLL" Alias "_L43_DPMRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_DPMWrB Lib "L43W32.DLL" Alias "_L43_DPMWrB@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_DPMWrL Lib "L43W32.DLL" Alias "_L43_DPMWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_DPMWrsL Lib "L43W32.DLL" Alias "_L43_DPMWrsL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_DPMWrsW Lib "L43W32.DLL" Alias "_L43_DPMWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_DPMWrW Lib "L43W32.DLL" Alias "_L43_DPMWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_DspBioRd Lib "L43W32.DLL" Alias "_L43_DspBioRd@4" (ByVal handleval As Long) As Integer
Public Declare Function L43_DspHmClear Lib "L43W32.DLL" Alias "_L43_DspHmClear@4" (ByVal handleval As Long) As Long
Public Declare Function L43_DspHmSet Lib "L43W32.DLL" Alias "_L43_DspHmSet@4" (ByVal handleval As Long) As Long
Public Declare Function L43_DspIntfClear Lib "L43W32.DLL" Alias "_L43_DspIntfClear@4" (ByVal handleval As Long) As Long
Public Declare Function L43_DspIntfRead Lib "L43W32.DLL" Alias "_L43_DspIntfRead@4" (ByVal handleval As Long) As Long
Public Declare Function L43_DspIntmClear Lib "L43W32.DLL" Alias "_L43_DspIntmClear@4" (ByVal handleval As Long) As Long
Public Declare Function L43_DspIntmSet Lib "L43W32.DLL" Alias "_L43_DspIntmSet@4" (ByVal handleval As Long) As Long
Public Declare Function L43_DspXfClear Lib "L43W32.DLL" Alias "_L43_DspXfClear@4" (ByVal handleval As Long) As Long
Public Declare Function L43_DspXfSet Lib "L43W32.DLL" Alias "_L43_DspXfSet@4" (ByVal handleval As Long) As Long
Public Declare Function L43_ErrDesc Lib "L43W32.DLL" Alias "_L43_ErrDesc@4" (ByVal errval As Long) As Long
Public Declare Function L43_ErrDescStr Lib "L43W32.DLL" Alias "_L43_ErrDescStr@4" (ByVal errval As Long) As Long
Public Declare Function L43_ErrName Lib "L43W32.DLL" Alias "_L43_ErrName@4" (ByVal errval As Long) As Long
Public Declare Function L43_ExpandMant Lib "L43W32.DLL" Alias "_L43_ExpandMant@8" (ByRef mant As Long, ByRef exp As Long) As Long
Public Declare Function L43_ExtDIODirSet Lib "L43W32.DLL" Alias "_L43_ExtDIODirSet@12" (ByVal dionum As Long, ByVal dirval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ExtLEDWINRd Lib "L43W32.DLL" Alias "_L43_ExtLEDWINRd@4" (ByVal handleval As Long) As Long
Public Declare Function L43_ExtLEDWINWr Lib "L43W32.DLL" Alias "_L43_ExtLEDWINWr@8" (ByVal ledval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_FileClose Lib "L43W32.DLL" Alias "_L43_FileClose@4" (ByRef handle As Long) As Long
Public Declare Function L43_FileErr Lib "L43W32.DLL" Alias "_L43_FileErr@0" () As Long
Public Declare Function L43_FileErrClr Lib "L43W32.DLL" Alias "_L43_FileErrClr@0" () As Long
Public Declare Function L43_FileErrSet Lib "L43W32.DLL" Alias "_L43_FileErrSet@0" () As Long
Public Declare Function L43_FileOpenRead Lib "L43W32.DLL" Alias "_L43_FileOpenRead@4" (ByRef filename As String) As Long
Public Declare Function L43_FileOpenWrite Lib "L43W32.DLL" Alias "_L43_FileOpenWrite@4" (ByRef filename As String) As Long
Public Declare Function L43_FileRead Lib "L43W32.DLL" Alias "_L43_FileRead@12" (ByRef handle As Long, ByRef buffer As Long, ByVal count As Integer) As Long
Public Declare Function L43_FileSeek Lib "L43W32.DLL" Alias "_L43_FileSeek@8" (ByRef handle As Long, ByVal offset As Long) As Long
Public Declare Function L43_FileTell Lib "L43W32.DLL" Alias "_L43_FileTell@4" (ByRef handle As Long) As Long
Public Declare Function L43_FileWrite Lib "L43W32.DLL" Alias "_L43_FileWrite@12" (ByRef handle As Long, ByRef buffer As Long, ByVal count As Integer) As Long
Public Declare Function L43_FilterAddr Lib "L43W32.DLL" Alias "_L43_FilterAddr@16" (ByVal labelval As Long, ByVal sdival As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_FilterCreate Lib "L43W32.DLL" Alias "_L43_FilterCreate@4" (ByVal handleval As Long) As Long
Public Declare Function L43_FilterFill Lib "L43W32.DLL" Alias "_L43_FilterFill@12" (ByVal msgaddr As Long, ByVal basevaladdr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_FldGetParBit Lib "L43W32.DLL" Alias "_L43_FldGetParBit@4" (ByVal msgval As Long) As Integer
Public Declare Function L43_FldPutParBit Lib "L43W32.DLL" Alias "_L43_FldPutParBit@4" (ByVal msgval As Long) As Long
Public Declare Function L43_GetHigh Lib "L43W32.DLL" Alias "_L43_GetHigh@4" (ByVal val As Long) As Integer
Public Declare Function L43_GetLow Lib "L43W32.DLL" Alias "_L43_GetLow@4" (ByVal val As Long) As Integer
Public Declare Function L43_GlobalRdW Lib "L43W32.DLL" Alias "_L43_GlobalRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function L43_GlobalWrW Lib "L43W32.DLL" Alias "_L43_GlobalWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_HandleClose Lib "L43W32.DLL" Alias "_L43_HandleClose@4" (ByVal handleval As Long) As Long
Public Declare Function L43_HandleDel Lib "L43W32.DLL" Alias "_L43_HandleDel@4" (ByVal handleval As Long) As Long
Public Declare Function L43_HandleGet Lib "L43W32.DLL" Alias "_L43_HandleGet@20" (ByRef cardstr As String, ByRef cardnum As Long, ByRef devnum As Long, ByRef sizval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_HandleIns Lib "L43W32.DLL" Alias "_L43_HandleIns@16" (ByRef cardname As String, ByVal cardnum As Long, ByRef happwnd As Long, ByVal uiremovalmsg As Integer) As Long
Public Declare Function L43_HandleOkay Lib "L43W32.DLL" Alias "_L43_HandleOkay@4" (ByVal handleval As Long) As Long
Public Declare Function L43_HandleOpen Lib "L43W32.DLL" Alias "_L43_HandleOpen@12" (ByRef cardname As String, ByVal cardnum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_HandleOpenWin95 Lib "L43W32.DLL" Alias "_L43_HandleOpenWin95@12" (ByRef cardname As String, ByVal cardnum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_HandleOpenWinNT Lib "L43W32.DLL" Alias "_L43_HandleOpenWinNT@12" (ByRef cardname As String, ByVal cardnum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_HandleVer Lib "L43W32.DLL" Alias "_L43_HandleVer@4" (ByVal handleval As Long) As Long
Public Declare Function L43_HandleVerPLX Lib "L43W32.DLL" Alias "_L43_HandleVerPLX@4" (ByVal handleval As Long) As Long
Public Declare Function L43_HeapAlloc Lib "L43W32.DLL" Alias "_L43_HeapAlloc@8" (ByVal wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function L43_HeapAllocAll Lib "L43W32.DLL" Alias "_L43_HeapAllocAll@8" (ByRef wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function L43_HeapAllocAllDPM Lib "L43W32.DLL" Alias "_L43_HeapAllocAllDPM@8" (ByRef wordcount As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_HeapAllocDPM Lib "L43W32.DLL" Alias "_L43_HeapAllocDPM@8" (ByVal wordcount As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_HeapAllocEx Lib "L43W32.DLL" Alias "_L43_HeapAllocEx@12" (ByVal configval As Integer, ByVal wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function L43_HeapWipe Lib "L43W32.DLL" Alias "_L43_HeapWipe@4" (ByVal handleval As Long) As Long
Public Declare Function L43_HeapWipeDPM Lib "L43W32.DLL" Alias "_L43_HeapWipeDPM@4" (ByVal handleval As Long) As Long
Public Declare Function L43_IndirectRd Lib "L43W32.DLL" Alias "_L43_IndirectRd@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_IndirectWr Lib "L43W32.DLL" Alias "_L43_IndirectWr@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_IntClear Lib "L43W32.DLL" Alias "_L43_IntClear@4" (ByVal handleval As Long) As Long
Public Declare Function L43_IntDisable Lib "L43W32.DLL" Alias "_L43_IntDisable@4" (ByVal handleval As Long) As Long
Public Declare Function L43_IntEnable Lib "L43W32.DLL" Alias "_L43_IntEnable@4" (ByVal handleval As Long) As Long
Public Declare Function L43_IntEnableCond Lib "L43W32.DLL" Alias "_L43_IntEnableCond@4" (ByVal handleval As Long) As Long
Public Declare Function L43_IntGet Lib "L43W32.DLL" Alias "_L43_IntGet@4" (ByVal handleval As Long) As Long
Public Declare Function L43_IORdW Lib "L43W32.DLL" Alias "_L43_IORdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_IOWINRdW Lib "L43W32.DLL" Alias "_L43_IOWINRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function L43_IOWINWrW Lib "L43W32.DLL" Alias "_L43_IOWINWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_IOWrW Lib "L43W32.DLL" Alias "_L43_IOWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernDev Lib "L43W32.DLL" Alias "_L43_KernDev@8" (ByRef valueptr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernEnd Lib "L43W32.DLL" Alias "_L43_KernEnd@4" (ByRef vxdptr As Long) As Long
Public Declare Function L43_KernIntClear Lib "L43W32.DLL" Alias "_L43_KernIntClear@4" (ByVal handleval As Long) As Long
Public Declare Function L43_KernIntInstall Lib "L43W32.DLL" Alias "_L43_KernIntInstall@8" (ByRef hevent As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernIntParam Lib "L43W32.DLL" Alias "_L43_KernIntParam@32" (ByVal clraddr As Long, ByVal clrwidth As Long, ByVal clrvalue As Long, ByVal stataddr As Long, ByVal statwidth As Long, ByVal statvalue As Long, ByVal statmask As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernIntStatus Lib "L43W32.DLL" Alias "_L43_KernIntStatus@8" (ByRef valueptr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernIntUninstall Lib "L43W32.DLL" Alias "_L43_KernIntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function L43_KernIORdW Lib "L43W32.DLL" Alias "_L43_KernIORdW@12" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernIOWrW Lib "L43W32.DLL" Alias "_L43_KernIOWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernMEMFillW Lib "L43W32.DLL" Alias "_L43_KernMEMFillW@20" (ByVal value As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernMEMRdL Lib "L43W32.DLL" Alias "_L43_KernMEMRdL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernMEMRdsL Lib "L43W32.DLL" Alias "_L43_KernMEMRdsL@20" (ByRef bufptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernMEMRdsW Lib "L43W32.DLL" Alias "_L43_KernMEMRdsW@20" (ByRef bufptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernMEMRdW Lib "L43W32.DLL" Alias "_L43_KernMEMRdW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernMEMWrL Lib "L43W32.DLL" Alias "_L43_KernMEMWrL@16" (ByVal value As Long, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernMEMWrsL Lib "L43W32.DLL" Alias "_L43_KernMEMWrsL@20" (ByRef bufptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernMEMWrsW Lib "L43W32.DLL" Alias "_L43_KernMEMWrsW@20" (ByRef bufptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernMEMWrW Lib "L43W32.DLL" Alias "_L43_KernMEMWrW@16" (ByVal value As Integer, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernQuick Lib "L43W32.DLL" Alias "_L43_KernQuick@8" (ByVal flag As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernStatus Lib "L43W32.DLL" Alias "_L43_KernStatus@12" (ByRef valueptr As Long, ByVal typeval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_KernStatusEx Lib "L43W32.DLL" Alias "_L43_KernStatusEx@16" (ByRef valueptr As Long, ByVal typeval As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function L43_LabelReverse Lib "L43W32.DLL" Alias "_L43_LabelReverse@4" (ByVal msgval As Long) As Long
Public Declare Function L43_ListAddr Lib "L43W32.DLL" Alias "_L43_ListAddr@12" (ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListAddrEx Lib "L43W32.DLL" Alias "_L43_ListAddrEx@12" (ByVal index As Long, ByVal listaddr As Long, ByRef header As Integer) As Long
Public Declare Function L43_ListAdvance Lib "L43W32.DLL" Alias "_L43_ListAdvance@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListClear Lib "L43W32.DLL" Alias "_L43_ListClear@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListConfig Lib "L43W32.DLL" Alias "_L43_ListConfig@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListConfigEx Lib "L43W32.DLL" Alias "_L43_ListConfigEx@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListDataBlkWr Lib "L43W32.DLL" Alias "_L43_ListDataBlkWr@16" (ByRef dataptr As Long, ByVal datacount As Integer, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListDataRdEx Lib "L43W32.DLL" Alias "_L43_ListDataRdEx@12" (ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListDataWrEx Lib "L43W32.DLL" Alias "_L43_ListDataWrEx@16" (ByVal value As Long, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListInit Lib "L43W32.DLL" Alias "_L43_ListInit@12" (ByVal listaddr As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ListNextRd Lib "L43W32.DLL" Alias "_L43_ListNextRd@8" (ByVal listaddr As Long, ByRef header As Integer) As Long
Public Declare Function L43_ListNextWr Lib "L43W32.DLL" Alias "_L43_ListNextWr@8" (ByVal listaddr As Long, ByRef header As Integer) As Long
Public Declare Function L43_ListPostRd Lib "L43W32.DLL" Alias "_L43_ListPostRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_ListPostWr Lib "L43W32.DLL" Alias "_L43_ListPostWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_ListPreRd Lib "L43W32.DLL" Alias "_L43_ListPreRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_ListPreWr Lib "L43W32.DLL" Alias "_L43_ListPreWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_ListStatus Lib "L43W32.DLL" Alias "_L43_ListStatus@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MakeLong Lib "L43W32.DLL" Alias "_L43_MakeLong@8" (ByVal valh As Integer, ByVal vall As Integer) As Long
Public Declare Function L43_MantToAscii Lib "L43W32.DLL" Alias "_L43_MantToAscii@12" (ByRef buf As String, ByVal mant As Long, ByVal exp As Long) As Long
Public Declare Function L43_Mask Lib "L43W32.DLL" Alias "_L43_Mask@8" (ByVal dataval As Long, ByVal cntval As Long) As Long
Public Declare Function L43_MaxMant Lib "L43W32.DLL" Alias "_L43_MaxMant@8" (ByRef mant As Long, ByRef exp As Long) As Long
Public Declare Function L43_MEMWINFillW Lib "L43W32.DLL" Alias "_L43_MEMWINFillW@20" (ByVal value As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MEMWINRdB Lib "L43W32.DLL" Alias "_L43_MEMWINRdB@12" (ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_MEMWINRdL Lib "L43W32.DLL" Alias "_L43_MEMWINRdL@12" (ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MEMWINRdsL Lib "L43W32.DLL" Alias "_L43_MEMWINRdsL@20" (ByRef valueptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MEMWINRdsW Lib "L43W32.DLL" Alias "_L43_MEMWINRdsW@20" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MEMWINRdW Lib "L43W32.DLL" Alias "_L43_MEMWINRdW@12" (ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_MEMWINWrB Lib "L43W32.DLL" Alias "_L43_MEMWINWrB@16" (ByVal value As Integer, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MEMWINWrL Lib "L43W32.DLL" Alias "_L43_MEMWINWrL@16" (ByVal value As Long, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MEMWINWrsL Lib "L43W32.DLL" Alias "_L43_MEMWINWrsL@20" (ByRef valueptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MEMWINWrsW Lib "L43W32.DLL" Alias "_L43_MEMWINWrsW@20" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MEMWINWrW Lib "L43W32.DLL" Alias "_L43_MEMWINWrW@16" (ByVal value As Integer, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Mod Lib "L43W32.DLL" Alias "_L43_Mod@8" (ByVal moda As Long, ByVal modb As Long) As Long
Public Declare Function L43_MsgActivityRd Lib "L43W32.DLL" Alias "_L43_MsgActivityRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_MsgActivityWr Lib "L43W32.DLL" Alias "_L43_MsgActivityWr@12" (ByVal value As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgCheck Lib "L43W32.DLL" Alias "_L43_MsgCheck@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_MsgConfig Lib "L43W32.DLL" Alias "_L43_MsgConfig@12" (ByVal configval As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgOptRd Lib "L43W32.DLL" Alias "_L43_MsgOptRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_MsgOptWr Lib "L43W32.DLL" Alias "_L43_MsgOptWr@12" (ByVal msgopt As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_MsgReset Lib "L43W32.DLL" Alias "_L43_MsgReset@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function L43_Mul Lib "L43W32.DLL" Alias "_L43_Mul@8" (ByVal mula As Long, ByVal mulb As Long) As Long
Public Declare Function L43_NormalMant Lib "L43W32.DLL" Alias "_L43_NormalMant@8" (ByRef mant As Long, ByRef exp As Long) As Long
Public Declare Function L43_PortRd Lib "L43W32.DLL" Alias "_L43_PortRd@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_PortWr Lib "L43W32.DLL" Alias "_L43_PortWr@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_ProgRdW Lib "L43W32.DLL" Alias "_L43_ProgRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function L43_ProgWrW Lib "L43W32.DLL" Alias "_L43_ProgWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_RAMFill Lib "L43W32.DLL" Alias "_L43_RAMFill@16" (ByVal value As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_RAMIsDPM Lib "L43W32.DLL" Alias "_L43_RAMIsDPM@4" (ByVal addrval As Long) As Long
Public Declare Function L43_RAMRdB Lib "L43W32.DLL" Alias "_L43_RAMRdB@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_RAMRdL Lib "L43W32.DLL" Alias "_L43_RAMRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_RAMRdsL Lib "L43W32.DLL" Alias "_L43_RAMRdsL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_RAMRdsW Lib "L43W32.DLL" Alias "_L43_RAMRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_RAMRdW Lib "L43W32.DLL" Alias "_L43_RAMRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_RAMWipe Lib "L43W32.DLL" Alias "_L43_RAMWipe@4" (ByVal handleval As Long) As Long
Public Declare Function L43_RAMWipeEx Lib "L43W32.DLL" Alias "_L43_RAMWipeEx@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_RAMWrB Lib "L43W32.DLL" Alias "_L43_RAMWrB@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_RAMWrL Lib "L43W32.DLL" Alias "_L43_RAMWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_RAMWrsL Lib "L43W32.DLL" Alias "_L43_RAMWrsL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_RAMWrsW Lib "L43W32.DLL" Alias "_L43_RAMWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_RAMWrW Lib "L43W32.DLL" Alias "_L43_RAMWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedAdvance Lib "L43W32.DLL" Alias "_L43_SchedAdvance@0" () As Long
Public Declare Function L43_SchedAgain Lib "L43W32.DLL" Alias "_L43_SchedAgain@12" (ByVal index As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedBranchEx Lib "L43W32.DLL" Alias "_L43_SchedBranchEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedBuildEx Lib "L43W32.DLL" Alias "_L43_SchedBuildEx@28" (ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef minperiod As Long, ByRef maxperiod As Long, ByVal speed As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedBuildExx Lib "L43W32.DLL" Alias "_L43_SchedBuildExx@40" (ByVal basevalmsgnum As Long, ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef minperiod As Long, ByRef maxperiod As Long, ByVal speed As Long, ByRef buf As Long, ByVal bufsize As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedCalc Lib "L43W32.DLL" Alias "_L43_SchedCalc@0" () As Long
Public Declare Function L43_SchedCallEx Lib "L43W32.DLL" Alias "_L43_SchedCallEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal destindex As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedCheck Lib "L43W32.DLL" Alias "_L43_SchedCheck@8" (ByRef minperiod As Long, ByRef maxperiod As Long) As Long
Public Declare Function L43_SchedCheckEnd Lib "L43W32.DLL" Alias "_L43_SchedCheckEnd@0" () As Long
Public Declare Function L43_SchedCheckMiddle Lib "L43W32.DLL" Alias "_L43_SchedCheckMiddle@16" (ByVal msgnum As Long, ByVal minlen As Long, ByVal midlen As Long, ByVal maxlen As Long) As Long
Public Declare Function L43_SchedCheckReal Lib "L43W32.DLL" Alias "_L43_SchedCheckReal@16" (ByVal msgnum As Long, ByVal minlen As Long, ByVal midlen As Long, ByVal maxlen As Long) As Long
Public Declare Function L43_SchedCheckStart Lib "L43W32.DLL" Alias "_L43_SchedCheckStart@0" () As Long
Public Declare Function L43_SchedConflicts Lib "L43W32.DLL" Alias "_L43_SchedConflicts@0" () As Long
Public Declare Function L43_SchedDivide Lib "L43W32.DLL" Alias "_L43_SchedDivide@0" () As Long
Public Declare Function L43_SchedFix Lib "L43W32.DLL" Alias "_L43_SchedFix@0" () As Long
Public Declare Function L43_SchedFixEnd Lib "L43W32.DLL" Alias "_L43_SchedFixEnd@0" () As Long
Public Declare Function L43_SchedFixMiddle Lib "L43W32.DLL" Alias "_L43_SchedFixMiddle@4" (ByVal conflicts As Long) As Long
Public Declare Function L43_SchedFixStart Lib "L43W32.DLL" Alias "_L43_SchedFixStart@0" () As Long
Public Declare Function L43_SchedHook Lib "L43W32.DLL" Alias "_L43_SchedHook@8" (ByVal index As Long, ByRef ptr As Long) As Long
Public Declare Function L43_SchedInsert Lib "L43W32.DLL" Alias "_L43_SchedInsert@28" (ByVal eventvals As Long, ByVal index As Long, ByVal msgnum As Long, ByRef msgaddr As Long, ByVal gapval As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedInsertEnd Lib "L43W32.DLL" Alias "_L43_SchedInsertEnd@12" (ByVal eventvals As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedInsertStart Lib "L43W32.DLL" Alias "_L43_SchedInsertStart@12" (ByVal eventvals As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedIntEx Lib "L43W32.DLL" Alias "_L43_SchedIntEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal tagval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedLayout Lib "L43W32.DLL" Alias "_L43_SchedLayout@0" () As Long
Public Declare Function L43_SchedMaxval Lib "L43W32.DLL" Alias "_L43_SchedMaxval@8" (ByRef arrayval As Long, ByVal arrayvalcount As Long) As Long
Public Declare Function L43_SchedMinval Lib "L43W32.DLL" Alias "_L43_SchedMinval@8" (ByRef arrayval As Long, ByVal arrayvalcount As Long) As Long
Public Declare Function L43_SchedNop Lib "L43W32.DLL" Alias "_L43_SchedNop@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedParse Lib "L43W32.DLL" Alias "_L43_SchedParse@16" (ByVal basevalmsgnum As Long, ByRef msgaddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedPulse0 Lib "L43W32.DLL" Alias "_L43_SchedPulse0@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedPulse1 Lib "L43W32.DLL" Alias "_L43_SchedPulse1@12" (ByVal dionum As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedReset Lib "L43W32.DLL" Alias "_L43_SchedReset@0" () As Long
Public Declare Function L43_SchedRotate Lib "L43W32.DLL" Alias "_L43_SchedRotate@0" () As Long
Public Declare Function L43_SchedShift Lib "L43W32.DLL" Alias "_L43_SchedShift@8" (ByVal msgnum As Long, ByVal value As Long) As Long
Public Declare Function L43_SchedSlide Lib "L43W32.DLL" Alias "_L43_SchedSlide@0" () As Long
Public Declare Function L43_SchedSlideEnd Lib "L43W32.DLL" Alias "_L43_SchedSlideEnd@0" () As Long
Public Declare Function L43_SchedSlideMiddle Lib "L43W32.DLL" Alias "_L43_SchedSlideMiddle@12" (ByVal index As Long, ByVal count As Long, ByVal conflicts As Long) As Long
Public Declare Function L43_SchedSlideStart Lib "L43W32.DLL" Alias "_L43_SchedSlideStart@4" (ByVal factor As Long) As Long
Public Declare Function L43_SchedSort Lib "L43W32.DLL" Alias "_L43_SchedSort@0" () As Long
Public Declare Function L43_SchedToBit Lib "L43W32.DLL" Alias "_L43_SchedToBit@4" (ByVal value As Long) As Long
Public Declare Function L43_SchedToMsec Lib "L43W32.DLL" Alias "_L43_SchedToMsec@4" (ByVal value As Long) As Long
Public Declare Function L43_SchedUnsort Lib "L43W32.DLL" Alias "_L43_SchedUnsort@0" () As Long
Public Declare Function L43_SchedUser Lib "L43W32.DLL" Alias "_L43_SchedUser@12" (ByVal useraddr As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SchedWalk Lib "L43W32.DLL" Alias "_L43_SchedWalk@0" () As Long
Public Declare Function L43_SEEPokeW Lib "L43W32.DLL" Alias "_L43_SEEPokeW@12" (ByVal value As Long, ByVal numbits As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SEERdBit Lib "L43W32.DLL" Alias "_L43_SEERdBit@12" (ByRef valueptr As Long, ByVal bitnum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SEERdL Lib "L43W32.DLL" Alias "_L43_SEERdL@12" (ByRef valueptr As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SEERdW Lib "L43W32.DLL" Alias "_L43_SEERdW@12" (ByRef valueptr As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SEEWrBit Lib "L43W32.DLL" Alias "_L43_SEEWrBit@12" (ByVal value As Long, ByVal bitnum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SEEWrL Lib "L43W32.DLL" Alias "_L43_SEEWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SEEWrW Lib "L43W32.DLL" Alias "_L43_SEEWrW@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SEMMRdW Lib "L43W32.DLL" Alias "_L43_SEMMRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_SEMMWrW Lib "L43W32.DLL" Alias "_L43_SEMMWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SEMRdW Lib "L43W32.DLL" Alias "_L43_SEMRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function L43_SEMWrW Lib "L43W32.DLL" Alias "_L43_SEMWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SeqBlkRd Lib "L43W32.DLL" Alias "_L43_SeqBlkRd@16" (ByRef buf As Integer, ByVal bufcount As Long, ByRef blkcnt As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SeqBlkRdEx Lib "L43W32.DLL" Alias "_L43_SeqBlkRdEx@20" (ByRef buf As Integer, ByVal bufcount As Long, ByVal maxblkcnt As Long, ByRef blkcnt As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SeqClear Lib "L43W32.DLL" Alias "_L43_SeqClear@4" (ByVal handleval As Long) As Long
Public Declare Function L43_SeqConfigEx Lib "L43W32.DLL" Alias "_L43_SeqConfigEx@16" (ByVal configval As Long, ByVal seqcount As Long, ByVal cardnum As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_SeqConfigExx Lib "L43W32.DLL" Alias "_L43_SeqConfigExx@20" (ByVal configval As Long, ByVal seqaddr As Long, ByVal seqcount As Long, ByVal cardnum As Integer, ByVal handleval As Long) As Long
Public Declare Function L43_SeqIntervalEx Lib "L43W32.DLL" Alias "_L43_SeqIntervalEx@8" (ByVal shiftval As Integer, ByVal handleval As Long) As Integer
Public Declare Function L43_SeqRdEx Lib "L43W32.DLL" Alias "_L43_SeqRdEx@12" (ByRef buf As Integer, ByVal bufcount As Integer, ByVal handleval As Long) As Integer
Public Declare Function L43_SeqResume Lib "L43W32.DLL" Alias "_L43_SeqResume@4" (ByVal handleval As Long) As Long
Public Declare Function L43_SeqStart Lib "L43W32.DLL" Alias "_L43_SeqStart@4" (ByVal handleval As Long) As Long
Public Declare Function L43_SeqStop Lib "L43W32.DLL" Alias "_L43_SeqStop@4" (ByVal handleval As Long) As Long
Public Declare Function L43_Shl Lib "L43W32.DLL" Alias "_L43_Shl@8" (ByVal dataval As Long, ByVal cntval As Long) As Long
Public Declare Function L43_Shr Lib "L43W32.DLL" Alias "_L43_Shr@8" (ByVal dataval As Long, ByVal cntval As Long) As Long
Public Declare Function L43_SignMant Lib "L43W32.DLL" Alias "_L43_SignMant@4" (ByRef str As String) As Integer
Public Declare Function L43_SubFrmAddr Lib "L43W32.DLL" Alias "_L43_SubFrmAddr@12" (ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SubFrmCreate Lib "L43W32.DLL" Alias "_L43_SubFrmCreate@16" (ByVal configval As Long, ByVal subframe As Long, ByVal chanbase As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SubFrmReset Lib "L43W32.DLL" Alias "_L43_SubFrmReset@12" (ByVal subframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SuperFrmBaseAddr Lib "L43W32.DLL" Alias "_L43_SuperFrmBaseAddr@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SuperFrmConfigEx Lib "L43W32.DLL" Alias "_L43_SuperFrmConfigEx@20" (ByVal configval As Long, ByVal count As Long, ByVal framespersuperframe As Long, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SuperFrmReset Lib "L43W32.DLL" Alias "_L43_SuperFrmReset@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_SyncValPtrInit Lib "L43W32.DLL" Alias "_L43_SyncValPtrInit@8" (ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function L43_TimerResolutionEx Lib "L43W32.DLL" Alias "_L43_TimerResolutionEx@8" (ByVal timershift As Integer, ByVal handleval As Long) As Integer
Public Declare Function L43_Transpose12 Lib "L43W32.DLL" Alias "_L43_Transpose12@4" (ByVal val As Integer) As Integer
Public Declare Function L43_ValAsciiCmpi Lib "L43W32.DLL" Alias "_L43_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Long
Public Declare Function L43_ValAsciiCpy Lib "L43W32.DLL" Alias "_L43_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Long) As Long
Public Declare Function L43_ValAsciiTrimLead Lib "L43W32.DLL" Alias "_L43_ValAsciiTrimLead@4" (ByRef buf As String) As Long
Public Declare Function L43_ValAsciiTrimTrail Lib "L43W32.DLL" Alias "_L43_ValAsciiTrimTrail@4" (ByRef buf As String) As Long
Public Declare Function L43_ValFromAscii Lib "L43W32.DLL" Alias "_L43_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Long) As Long
Public Declare Function L43_ValGetBits Lib "L43W32.DLL" Alias "_L43_ValGetBits@12" (ByVal oldvalue As Long, ByVal startbit As Long, ByVal endbit As Long) As Long
Public Declare Function L43_ValIncAscii Lib "L43W32.DLL" Alias "_L43_ValIncAscii@4" (ByRef asciistr As String) As Long
Public Declare Function L43_ValInccAscii Lib "L43W32.DLL" Alias "_L43_ValInccAscii@4" (ByRef asciistr As String) As Long
Public Declare Function L43_ValIsLower Lib "L43W32.DLL" Alias "_L43_ValIsLower@4" (ByVal value As Long) As Long
Public Declare Function L43_ValLenAscii Lib "L43W32.DLL" Alias "_L43_ValLenAscii@8" (ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function L43_ValPutBits Lib "L43W32.DLL" Alias "_L43_ValPutBits@16" (ByVal oldvalue As Long, ByVal newfld As Long, ByVal startbit As Long, ByVal endbit As Long) As Long
Public Declare Function L43_ValToAscii Lib "L43W32.DLL" Alias "_L43_ValToAscii@16" (ByVal value As Long, ByRef asciistr As String, ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function L43_ValToUpper Lib "L43W32.DLL" Alias "_L43_ValToUpper@4" (ByVal value As Long) As Long

Public Const CH0 As Integer = &H0    '//Channel 0
Public Const CH1 As Integer = &H1    '//Channel 1
Public Const CH2 As Integer = &H2    '//Channel 2
Public Const CH3 As Integer = &H3    '//Channel 3
Public Const CH4 As Integer = &H4    '//Channel 4
Public Const CH5 As Integer = &H5    '//Channel 5
Public Const CH6 As Integer = &H6    '//Channel 6
Public Const CH7 As Integer = &H7    '//Channel 7

Public Const SDI00 As Integer = &H1  '//Enable SDI00
Public Const SDI01 As Integer = &H2  '//Enable SDI01
Public Const SDI10 As Integer = &H4  '//Enable SDI10
Public Const SDI11 As Integer = &H8  '//Enable SDI11
Public Const SDIALL As Integer = &HF '//Enable all SDIs

Public Const SUBFRM1 As Integer = &H1    '//Sub Frame 1 (717)
Public Const SUBFRM2 As Integer = &H2    '//Sub Frame 2 (717)
Public Const SUBFRM3 As Integer = &H3    '//Sub Frame 3 (717)
Public Const SUBFRM4 As Integer = &H4    '//Sub Frame 4 (717)

'/**
'*
'*  Channel configuration options
'*
'**/

Public Const CHCFG_DEFAULT As Long = &H0 '//Select all default settings (XMT & RCV) (default)
Public Const CHCFG_HIGHSPEED As Long = &H1   '//Select high speed (XMT & RCV)
Public Const CHCFG_AUTOSPEED As Long = &H2   '//Select auto speed detection (RCV)
Public Const CHCFG_LOWSPEED As Long = &H0    '//Select low speed (XMT & RCV) (default)
Public Const CHCFG_SELFTEST As Long = &H4    '//Enable internal wraparound (XMT & RCV)
Public Const CHCFG_SELFTESTOFF As Long = &H0 '//Disable internal wraparound (XMT & RCV) (default)
Public Const CHCFG_SYNC As Long = &H8    '//Sync Enable (XMT & RCV)
Public Const CHCFG_SYNCOFF As Long = &H0 '//Disable sync output (XMT & RCV) (default)
Public Const CHCFG_PARODD As Long = &H0  '//Parity odd (XMT & RCV) (default)
Public Const CHCFG_PAREVEN As Long = &H10 '//Parity even (XMT & RCV)
Public Const CHCFG_PARDATA As Long = &H20 '//Parity bit as data (XMT & RCV)
Public Const CHCFG_ACTIVE As Long = &H0  '//Enable ehannel activity (XMT & RCV) (default)
Public Const CHCFG_INACTIVE As Long = &H40    '//Disable channel activity (XMT & RCV)
Public Const CHCFG_EXTTRIG As Long = &H80 '//Enable external trigger for all messages (XMT)
Public Const CHCFG_EXTOFF As Long = &H0  '//External trigger is enabled on message level (XMT) (default)
Public Const CHCFG_PARERR As Long = &H100  '//Enable parity error for all messages (XMT)
Public Const CHCFG_NOERR As Long = &H0   '//errors are enabled on message level (XMT) (default)
Public Const CHCFG_HIT As Long = &H200 '//Hit counter is enabled for all messages
Public Const CHCFG_NOHIT As Long = &H0   '//Hit counter is enabled on message level (default)
Public Const CHCFG_TIMETAG As Long = &H400 '//Enable time-tag for all message records
Public Const CHCFG_TIMETAGOFF As Long = &H0  '//Time-tag is enabled on message level (default)
Public Const CHCFG_ELAPSE As Long = &H800  '//Enable elapse time for all messages
Public Const CHCFG_ELAPSEOFF As Long = &H0   '//Elapse time is enabled on message level (default)
Public Const CHCFG_MAX As Long = &H1000 '//Enable max repetition rate monitoring for all messages
Public Const CHCFG_MIN As Long = &H2000 '//Enable min repetition rate monitoring for all messages
Public Const CHCFG_MAXMIN As Long = &H3000  '//Enable max and min repetition rate monitoring for all messages
Public Const CHCFG_MAXMINOFF As Long = &H0   '//Repetition rate monitoring is enabled on message level (default)
Public Const CHCFG_SEQALL As Long = &H80000  '//Record entire channel in sequential record
Public Const CHCFG_SEQSEL As Long = &H0  '//Sequential record recording is enabled at message level (default)
Public Const CHCFG_INTHALT As Long = &H200000 '//Enable schedule halt interrupt
Public Const CHCFG_NOINTHALT As Long = &H0   '//No interrupt on schedule halt (default)
Public Const CHCFG_INTPAUSE As Long = &H400000    '//Enable schedule pause interrupt
Public Const CHCFG_NOINTPAUSE As Long = &H0  '//No interrupt on schedulr pause (default)
Public Const CHCFG_INTERR As Long = &H800000  '//Enable interrupts on decoder errors.
Public Const CHCFG_NOINTERR As Long = &H0    '//No interrupt on decoder errors (default)
Public Const CHCFG_PAUSE As Long = &H1000000   '//Mark channel as paused
Public Const CHCFG_UNPAUSE As Long = &H0 '//Mark channel as unpaused (default)
Public Const CHCFG_RAM As Long = &H0 '//Messages are located in static RAM (default)
Public Const CHCFG_DPRAM As Long = &H80000000   '//Messages are located in dual-port RAM

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
Public Const CHCFG717_BIPHASERCV As Long = &H0   '//Set Bi-Phase channel to receiver (Bi-Phase) (default)
Public Const CHCFG717_BIPHASEXMT As Long = &H8000000   '//Set Bi-Phase channel to transmitter (Bi-Phase)
Public Const CHCFG717_BIPOLARHSPD As Long = &H8000000  '//Select high spped slope for Bi-Polar transmitter (Bi-Polar XMT)
Public Const CHCFG717_SELFTEST As Long = &H4 '//Enable internal wraparound (XMT & RCV)
Public Const CHCFG717_SELFTESTOFF As Long = &H0  '//Disable internal wraparound (XMT & RCV) (default)
Public Const CHCFG717_SYNC As Long = &H8 '//Sync Enable (XMT & RCV)
Public Const CHCFG717_SYNCOFF As Long = &H0  '//Disable sync output (XMT & RCV) (default)
Public Const CHCFG717_ACTIVE As Long = &H0   '//Enable ehannel activity (XMT & RCV) (default)
Public Const CHCFG717_INACTIVE As Long = &H40 '//Disable channel activity (XMT & RCV)
Public Const CHCFG717_EXTTRIG As Long = &H80  '//Enable external trigger for all messages (XMT)
Public Const CHCFG717_EXTOFF As Long = &H0   '//External trigger is enabled on message level (XMT) (default)
Public Const CHCFG717_HIT As Long = &H200  '//Hit counter is enabled for all sub frames (XMT & RCV)
Public Const CHCFG717_NOHIT As Long = &H0    '//Hit counter is disabled (XMT & RCV) (default)
Public Const CHCFG717_TIMETAG As Long = &H400  '//Enable time-tag for all sub frames (XMT & RCV)
Public Const CHCFG717_TIMETAGOFF As Long = &H0   '//Time-tag is disabled (XMT & RCV) (default)
Public Const CHCFG717_SEQALL As Long = &H80000   '//Record entire channel in sequential record (XMT & RCV)
Public Const CHCFG717_SEQSEL As Long = &H0   '//Sequential record recording is enabled at word level (XMT & RCV) (default)
Public Const CHCFG717_INTERR As Long = &H800000   '//Enable interrupts on Out of Sync Error (RCV)
Public Const CHCFG717_NOINTERR As Long = &H0 '//No interrupt on Out of Sync Error (RCV) (default)
Public Const CHCFG717_PAUSE As Long = &H1000000    '//Mark channel as paused (XMT & RCV)
Public Const CHCFG717_UNPAUSE As Long = &H0  '//Mark channel as unpaused (XMT & RCV) (default)

'/**
'*
'*  Sequential Record configuration options
'*
'**/

Public Const SEQCFG_DEFAULT As Long = &H0    '//Select all default settings
Public Const SEQCFG_FILLHALT As Long = &H0   '//Enable sequential record in fill and halt mode (default)
Public Const SEQCFG_DISABLE As Long = &H1    '//Disable sequential record
Public Const SEQCFG_CONTINUOUS As Long = &H2 '//Enable sequential record in continuous mode
Public Const SEQCFG_FREE As Long = &H8   '//Enable sequential record in free mode
Public Const SEQCFG_DELTA As Long = &H10  '//Enable sequential record in delta mode
Public Const SEQCFG_INTERVAL As Long = &H20   '//Enable sequential record in interval mode
Public Const SEQCFG_NOINTFULL As Long = &H0  '//Do not generate interrupt when sequential record is full (default)
Public Const SEQCFG_INTFULL As Long = &H1000    '//Generate interrupt when sequential record is full
Public Const SEQCFG_NOINTFREQ As Long = &H0  '//Do not generate interrupts at a user specified frequency (default)
Public Const SEQCFG_INTFREQ As Long = &H2000    '//Generate interrupts at user specified frequency
Public Const SEQCFG_16K As Long = &H0    '//Allocate a 16K sequential record buffer (default)
Public Const SEQCFG_ALLAVAIL As Long = &H1000000   '//Allocate all available memory to a sequential record buffer
Public Const SEQCFG_32K As Long = &H2000000    '//Allocate a 32K sequential record buffer
Public Const SEQCFG_64K As Long = &H4000000    '//Allocate a 64K sequential record buffer
Public Const SEQCFG_128K As Long = &H8000000   '//Allocate a 128K sequential record buffer
Public Const SEQCFG_DPRAM As Long = &H10000000  '//Allocate all available dual-port memory

'/**
'*
'*  Interrupt log list configuration options
'*
'**/

Public Const INTCFG_DEFAULT As Long = &H0    '//Select all default settings
Public Const INTCFG_ENABLE As Long = &H0 '//Enable interrupt log list (default)
Public Const INTCFG_DISABLE As Long = &H1    '//Disable interrupt log list

'/**
'*
'*  Info types
'*
'**/

Public Const INFOTYPE_PLAT As Integer = &H1  '//Returns the L43 platform type
Public Const INFOTYPE_PROD As Integer = &H2  '//Returns the L43 product type
Public Const INFOTYPE_DASH As Integer = &H3  '//Returns the L43 dash number
Public Const INFOTYPE_VERSION As Integer = &H4   '//Returns the L43 version number
Public Const INFOTYPE_DATE As Integer = &H5  '//Returns the L43 version date
Public Const INFOTYPE_MODEL As Integer = &H6 '//Returns the L43 model number
Public Const INFOTYPE_MAXCOUNT As Integer = &H7  '//Returns the max channel count
Public Const INFOTYPE_USERCODE As Integer = &HA  '//Returns whether L43 handles user code
Public Const INFOTYPE_LISTBUF As Integer = &HB   '//Returns whether L43 handles list buffering
Public Const INFOTYPE_ARINC717 As Integer = &HC  '//Returns whether L43 has ARINC 717 channels

'/**
'*
'*  Message configuration options
'*
'**/

Public Const MSGCRT_DEFAULT As Long = &H0    '//Default settings
Public Const MSGCRT_NOSEQ As Long = &H0  '//Message will not be recorded in sequential record (default)
Public Const MSGCRT_SEQ As Long = &H1    '//Message will be recorded in sequential record
Public Const MSGCRT_NOINT As Long = &H0  '//Message will not generate interrupt (default)
Public Const MSGCRT_INT As Long = &H2    '//Message will generate interrupt
Public Const MSGCRT_NOLIST As Long = &H0 '//Message will not have a list buffer (default)
Public Const MSGCRT_LIST As Long = &H4   '//Message will have a list buffer
Public Const MSGCRT_NOSKIP As Long = &H0 '//Message will not be skipped (default)
Public Const MSGCRT_SKIP As Long = &H8   '//Message will be skipped
Public Const MSGCRT_NOTIMETAG As Long = &H0  '//Message will not record time-tag (default)
Public Const MSGCRT_TIMETAG As Long = &H10    '//Message will record time-tag
Public Const MSGCRT_NOELAPSE As Long = &H0   '//Message will not record elapse time (default)
Public Const MSGCRT_ELAPSE As Long = &H20 '//Message will record elapse time
Public Const MSGCRT_NOMAXMIN As Long = &H0   '//Message will not record min/max time (default)
Public Const MSGCRT_MAX As Long = &H40    '//Message will record max time
Public Const MSGCRT_MIN As Long = &H80    '//Message will record min time
Public Const MSGCRT_MAXMIN As Long = &HC0 '//Message will record min/max time
Public Const MSGCRT_NOSYNC As Long = &H0 '//No sync will be generated for message (default)
Public Const MSGCRT_SYNC As Long = &H100   '//Sync will be generated for message
Public Const MSGCRT_NOERR As Long = &H0  '//No error will be generated for message (default)
Public Const MSGCRT_PARERR As Long = &H200 '//Parity error will be generated for message
Public Const MSGCRT_NOHIT As Long = &H0  '//Message will not record hit count (default)
Public Const MSGCRT_HIT As Long = &H400    '//Message will record hit count
Public Const MSGCRT_NOEXTRIG As Long = &H0   '//Message will not be externally triggered (default)
Public Const MSGCRT_EXTRIG As Long = &H1000 '//Message will be externally triggered
Public Const MSGCRT_WIPE As Long = &H0   '//Enables message clear (default)
Public Const MSGCRT_NOWIPE As Long = &H80000000 '//Disables message clear
Public Const MSGCRT_WIPE0 As Long = &H0  '//Initialize data with zeros (default)
Public Const MSGCRT_WIPE1 As Long = &H40000000  '//Initialize data with ones
Public Const MSGCRT_CHAN As Long = &H0   '//Message located in static RAM or dual-port RAM depending upon channel config (default)
Public Const MSGCRT_RAM As Long = &H20000000    '//Message located in static RAM
Public Const MSGCRT_DPRAM As Long = &H10000000  '//Message located in dual-port RAM

'/**
'*
'*  Sub Frame word configuration options (717)
'*
'**/

Public Const WRDCFG_DEFAULT As Long = &H0    '//Select all default settings
Public Const WRDCFG_SFINT As Long = &H1  '//Enable subframe interrupt
Public Const WRDCFG_SFINTOFF As Long = &H0   '//Disable subframe interrupt (default)
Public Const WRDCFG_WRDINT As Long = &H2 '//Enable word interrupt
Public Const WRDCFG_WRDINTOFF As Long = &H0  '//Disable word interrupt (default)
Public Const WRDCFG_SEQ As Long = &H4    '//Enable sequential record
Public Const WRDCFG_SEQOFF As Long = &H0 '//Disable sequential record (default)

'/**
'*
'*  List buffer options
'*
'**/

Public Const LISTCRT_DEFAULT As Long = &H0   '//Select all default settings
Public Const LISTCRT_FIFO As Long = &H0  '//Enable FIFO mode (default)
Public Const LISTCRT_PINGPONG As Long = &H1  '//Enable ping-pong mode
Public Const LISTCRT_CIRCULAR As Long = &H2  '//Enable circular mode
Public Const LISTCRT_RCV As Long = &H10   '//User will read from list buffer
Public Const LISTCRT_XMT As Long = &H20   '//User will write to list buffer
Public Const LISTCRT_NOINT As Long = &H0 '//Do not generate interrupt when list buffer empty/full (default)
Public Const LISTCRT_INT As Long = &H100   '//Generate interrupt when list buffer empty/full
Public Const LISTCRT_RAM As Long = &H0   '//List located in static RAM (default)
Public Const LISTCRT_DPRAM As Long = &H200000 '//List located in dual-port RAM

'/**
'*
'*  Bit fields of the message activity flag.
'*
'**/

Public Const MSGACT_BRD As Integer = &HF000 '//All bits of Board number
Public Const MSGACT_BRD3 As Integer = &H8000    '//Bit 3 of Board number
Public Const MSGACT_BRD2 As Integer = &H4000    '//Bit 2 of Board number
Public Const MSGACT_BRD1 As Integer = &H2000    '//Bit 1 of Board number
Public Const MSGACT_BRD0 As Integer = &H1000    '//Bit 0 of Board number
Public Const MSGACT_CHAN As Integer = &HF00    '//All bits of Channel number
Public Const MSGACT_CHAN3 As Integer = &H800   '//Bit 3 of Channel number
Public Const MSGACT_CHAN2 As Integer = &H400   '//Bit 2 of Channel number
Public Const MSGACT_CHAN1 As Integer = &H200   '//Bit 1 of Channel number
Public Const MSGACT_CHAN0 As Integer = &H100   '//Bit 0 of Channel number
Public Const MSGACT_ASPD As Integer = &H80    '//Auto Speed
Public Const MSGACT_ERR As Integer = &H40 '//Error bit
Public Const MSGACT_GAP As Integer = &H20 '//Gap error bit
Public Const MSGACT_PAR As Integer = &H10 '//Parity error bit
Public Const MSGACT_LONG As Integer = &H8    '//Long word error bit
Public Const MSGACT_BIT As Integer = &H4 '//Bit time error bit
Public Const MSGACT_TO As Integer = &H2  '//Time out error bit
Public Const MSGACT_HIT As Integer = &H1 '//Always set

Public Const MSGACT717_BRD As Integer = &HF000  '//All bits of Board number
Public Const MSGACT717_BRD3 As Integer = &H8000 '//Bit 3 of Board number
Public Const MSGACT717_BRD2 As Integer = &H4000 '//Bit 2 of Board number
Public Const MSGACT717_BRD1 As Integer = &H2000 '//Bit 1 of Board number
Public Const MSGACT717_BRD0 As Integer = &H1000 '//Bit 0 of Board number
Public Const MSGACT717_CHAN As Integer = &HF00 '//All bits of Channel number
Public Const MSGACT717_CHAN3 As Integer = &H800    '//Bit 3 of Channel number
Public Const MSGACT717_CHAN2 As Integer = &H400    '//Bit 2 of Channel number
Public Const MSGACT717_CHAN1 As Integer = &H200    '//Bit 1 of Channel number
Public Const MSGACT717_CHAN0 As Integer = &H100    '//Bit 0 of Channel number
Public Const MSGACT717_SPD As Integer = &HE0  '//All bits of current speed
Public Const MSGACT717_SPD2 As Integer = &H80 '//Bit 2 of current speed
Public Const MSGACT717_SPD1 As Integer = &H40 '//Bit 1 of current speed
Public Const MSGACT717_SPD0 As Integer = &H20 '//Bit 0 of current speed
Public Const MSGACT717_TO As Integer = &H2   '//Time out error bit
Public Const MSGACT717_HIT As Integer = &H1  '//Always set

'/**
'*
'*  L43 IFGA Registers
'*
'**/

Public Const IREG_STAT As Integer = &H40  '//Status register (RD)
Public Const IREG_SET As Integer = &H41   '//Set register (WR)
Public Const IREG_CLR As Integer = &H42   '//Clear register (WR)
Public Const IREG_ID As Integer = &H43    '//ID register (RD)
Public Const IREG_PAGE As Integer = &H44  '//Page register
Public Const IREG_CONFIG As Integer = &H45    '//Configuration register
Public Const IREG_INT As Integer = &H46   '//Interrupt register
Public Const IREG_PRESCL As Integer = &H47    '//Prescale Register for clock divider

'/**
'*
'*  EDGA Registers
'*
'**/

Public Const EREG1_GSTAT As Integer = &H1180    '//Global Status
Public Const EREG1_CHSTAT As Integer = &H181   '//Channel Status
Public Const EREG1_CHDATAH As Integer = &H182  '//Channel Data High Word
Public Const EREG1_CHDATAL As Integer = &H183  '//Channel Data Low Word
Public Const EREG1_CHGAP As Integer = &H184    '//Channel Gap
Public Const EREG1_CHCNTL As Integer = &H185   '//Channel Control Word
Public Const EREG1_CHCFG As Integer = &H186    '//Channel Config
Public Const EREG1_CHCFGINT As Integer = &H187 '//Channel Int Config
Public Const EREG1_GERR As Integer = &H188 '//Global Error Register
Public Const EREG1_GRST As Integer = &H189 '//Global Reset
Public Const EREG1_GID As Integer = &H18C  '//Global ID

Public Const EREG2_GSTAT As Integer = &H1280    '//Global Status
Public Const EREG2_CHSTAT As Integer = &H281   '//Channel Status
Public Const EREG2_CHDATAH As Integer = &H282  '//Channel Data High Word
Public Const EREG2_CHDATAL As Integer = &H283  '//Channel Data Low Word
Public Const EREG2_CHGAP As Integer = &H284    '//Channel Gap
Public Const EREG2_CHCNTL As Integer = &H285   '//Channel Control Word
Public Const EREG2_CHCFG As Integer = &H286    '//Channel Config
Public Const EREG2_CHCFGINT As Integer = &H287 '//Channel Int Config
Public Const EREG2_GERR As Integer = &H288 '//Global Error Register
Public Const EREG2_GRST As Integer = &H289 '//Global Reset
Public Const EREG2_GID As Integer = &H28C  '//Global ID

'/**
'*
'*  Local Configuration Registers
'*
'**/

Public Const CREG_LAS0RR As Integer = &H0    '//Local Address Space 0 Range
Public Const CREG_LAS1RR As Integer = &H1    '//Local Address Space 1 Range
Public Const CREG_LAS2RR As Integer = &H2    '//Local Address Space 2 Range
Public Const CREG_LAS3RR As Integer = &H3    '//Local Address Space 3 Range
Public Const CREG_EROMRR As Integer = &H4    '//Local Expansion ROM Range
Public Const CREG_LAS0BA As Integer = &H5    '//Local Address Space 0 Local Base Address (Re-map)
Public Const CREG_LAS1BA As Integer = &H6    '//Local Address Space 1 Local Base Address (Re-map)
Public Const CREG_LAS2BA As Integer = &H7    '//Local Address Space 2 Local Base Address (Re-map)
Public Const CREG_LAS3BA As Integer = &H8    '//Local Address Space 3 Local Base Address (Re-map)
Public Const CREG_EROMBA As Integer = &H9    '//Expansion ROM Local Base Address (Re-map)
Public Const CREG_LAS0BRD As Integer = &HA   '//Local Address Space 0 Bus Region Descriptors
Public Const CREG_LAS1BRD As Integer = &HB   '//Local Address Space 1 Bus Region Descriptors
Public Const CREG_LAS2BRD As Integer = &HC   '//Local Address Space 2 Bus Region Descriptors
Public Const CREG_LAS3BRD As Integer = &HD   '//Local Address Space 3 Bus Region Descriptors
Public Const CREG_EROMBRD As Integer = &HE   '//Expansion ROM Bus Region Descriptors
Public Const CREG_CS0BASE As Integer = &HF   '//Chip Select 0 Base Address
Public Const CREG_CS1BASE As Integer = &H10   '//Chip Select 1 Base Address
Public Const CREG_CS2BASE As Integer = &H11   '//Chip Select 2 Base Address
Public Const CREG_CS3BASE As Integer = &H12   '//Chip Select 3 Base Address
Public Const CREG_INTCSR As Integer = &H13    '//Interrupt Control/Status
Public Const CREG_CNTRL As Integer = &H14 '//EEPROM Control, PCI Slave Response, User I/O Control, Init Control

'/**
'*
'*  Interrupt types.
'*
'**/

Public Const INTTYPE_MSG As Integer = &H1    '//Message interrupt
Public Const INTTYPE_OPCODE As Integer = &H2 '//Interrupt opcode
Public Const INTTYPE_HALT As Integer = &H3   '//Schedule halt
Public Const INTTYPE_PAUSE As Integer = &H4  '//Schedule pause
Public Const INTTYPE_SEQFULL As Integer = &H5    '//Sequential record full
Public Const INTTYPE_LIST As Integer = &H6   '//List buffer empty/full
Public Const INTTYPE_ERR As Integer = &H7    '//Decoder error detected
Public Const INTTYPE_SEQFREQ As Integer = &H8    '//Sequential record frequency
Public Const INTTYPE_717WORD As Integer = &H9    '//717 word received
Public Const INTTYPE_717SUBFRM As Integer = &HA  '//717 sub frame completed
Public Const INTTYPE_717SYNCERR As Integer = &HB '//717 Rcv channel lost synchronization

'/**
'*
'*  Timer resolutions.
'*
'**/

Public Const TIMERRESOL_1US As Integer = 1  '//1us timer resolution, 1:11:34 range
Public Const TIMERRESOL_16US As Integer = 2 '//16us timer resolution, 19:05:19 range
Public Const TIMERRESOL_1024US As Integer = 3   '//1024us timer resolution, 50 day range
Public Const TIMERRESOL_16348US As Integer = 4  '//16348us timer resolution, 814 day range

'/**
'*
'*  Interval calculation modes.
'*
'**/

Public Const INTERVALMODE_CLOSEST As Integer = 1    '//Finds interval closest to value specified
Public Const INTERVALMODE_LESS As Integer = 2   '//Finds closest interval less than value specified
Public Const INTERVALMODE_GREATER As Integer = 3    '//Finds closest interval more than value specified

'/**
'*
'*  Scheduling conditions.
'*
'**/

Public Const COND_ALWAYS As Integer = &H0
Public Const COND_DIO1ACT As Integer = &H1
Public Const COND_DIO1NACT As Integer = &H81
Public Const COND_DIO2ACT As Integer = &H2
Public Const COND_DIO2NACT As Integer = &H82
Public Const COND_DIO3ACT As Integer = &H3
Public Const COND_DIO3NACT As Integer = &H83
Public Const COND_DIO4ACT As Integer = &H4
Public Const COND_DIO4NACT As Integer = &H84

Public Const SEQRD_MAX_COUNT As Integer = 9

Public Const RCV As Integer = 0
Public Const XMT As Integer = 1

Public Const STAT_EMPTY As Integer = 0  '//Buffer is empty
Public Const STAT_PARTIAL As Integer = 1    '//Buffer is partially filled
Public Const STAT_FULL As Integer = 2   '//Buffer is full
Public Const STAT_OFF As Integer = 3    '//Buffer is off

Public Const TEST_LEVEL_0 As Integer = 0    '//Test I/O interface
Public Const TEST_LEVEL_1 As Integer = 1    '//Test memory interface
Public Const TEST_LEVEL_2 As Integer = 2    '//Test communication process
Public Const TEST_LEVEL_3 As Integer = 3    '//Test bus transceiver

Public Const ERR_NONE As Integer = 0    '//No error
Public Const ERR_UNKNOWN As Integer = -1    '//An unexpected error occurred
Public Const ERR_BADVER As Integer = -2 '//A bad version was encountered
Public Const ERR_BADPARAMS As Integer = -11 '//CardOpen() called with bad parameters
Public Const ERR_NOHANDLES As Integer = -12 '//CardOpen() already has allocated too many handles
Public Const ERR_NOCARD As Integer = -13    '//CardOpen() could not find a L43 card at the specified address
Public Const ERR_NOIO As Integer = -14  '//CardOpen() could not find the I/O ports
Public Const ERR_NOMEM As Integer = -15 '//CardOpen() could not find the memory
Public Const ERR_BAD16BIT As Integer = -16  '//Card is conflicting with another 16-bit card
Public Const ERR_WRONGMODEL As Integer = -17    '//Card does not support this feature
Public Const ERR_NOSEL As Integer = -18 '//CardOpen() could not allocate a memory selector
Public Const ERR_LOCK As Integer = -19  '//The communication process is locked up
Public Const ERR_TOOMANY As Integer = -20   '//Too many channels have been configured
Public Const ERR_BADHANDLE As Integer = -21 '//A bad handle was specified
Public Const ERR_NOTCHAN As Integer = -23   '//Not a valid channel
Public Const ERR_NOTXMT As Integer = -24    '//The Transmitter has not been configured
Public Const ERR_NOTRCV As Integer = -25    '//The Receiver has not been configured
Public Const ERR_NOTSEQ As Integer = -26    '//The Sequential Record has not been configured
Public Const ERR_ALLOC As Integer = -27 '//There is not enough memory to allocate
Public Const ERR_VXD As Integer = -28   '//An error occurred in the VXD
Public Const ERR_BADLABEL As Integer = -29  '//The specified label value is not valid
Public Const ERR_BADSDI As Integer = -30    '//The specified sdi value is not valid
Public Const ERR_BADMSG As Integer = -31    '//The specified command block is not a message block
Public Const ERR_BADSCHNDX As Integer = -32 '//Specified command index is out of range
Public Const ERR_BUFSIZE As Integer = -33   '//Insufficient space in user buffer
Public Const ERR_NOCONFIG As Integer = -34  '//The card has not been properly configured
Public Const ERR_CONFLICTS As Integer = -35 '//Unable to resolve conflicts
Public Const ERR_RANGE As Integer = -36 '//Schedule is out of range
Public Const ERR_FACTOR As Integer = -37    '//A bad factor value was specified
Public Const ERR_BOOTFULL As Integer = -41  '//No space to add boot code
Public Const ERR_BOOTNUM As Integer = -42   '//There is no boot code with the specified number
Public Const ERR_ACCESS As Integer = -43    '//Unable to write to access register
Public Const ERR_ROMVERIFY As Integer = -44 '//Unable to verify the value written to the ROM
Public Const ERR_COUNT As Integer = -45 '//An invalid count was specified
Public Const ERR_CRC As Integer = -46   '//There was a bad checksum in the HEX file
Public Const ERR_FNAME As Integer = -47 '//Bad filenames were specified
Public Const ERR_FRDWR As Integer = -48 '//There was an error reading or writing the HEX file
Public Const ERR_HEX As Integer = -49   '//There was a bad hex character in the HEX file
Public Const ERR_INDEX As Integer = -51 '//The command block index was invalid or the schedule is full
Public Const ERR_NOMSGS As Integer = -52    '//No messages specified
Public Const ERR_TYPE As Integer = -54  '//There was a bad type value in the HEX file
Public Const ERR_ZEROLEN As Integer = -55   '//Zero length was specified
Public Const ERR_BADADDRESS As Integer = -56    '//A bad address was specified
Public Const ERR_SELFIOFAIL As Integer = -71    '//I/O selftest failed
Public Const ERR_SELFMEMFAIL As Integer = -72   '//Memory selftest failed
Public Const ERR_SELFCOMMFAIL As Integer = -73  '//Communication selftest failed
Public Const ERR_SELFXMTFAIL As Integer = -74   '//Transmit selftest failed
Public Const ERR_PLXBUG As Integer = -75    '//PLX bug is causing problems
Public Const ERR_NOT717CHAN As Integer = -100   '//Specified channel is not a 717 channel
Public Const ERR_SUBFRMNUM As Integer = -101    '//Invalid 717 SubFrame number was specified
Public Const ERR_WORDNUM As Integer = -102  '//Invalid 717 Word number was specified
Public Const ERR_NOTINSYNC As Integer = -103    '//Not Synchronized to 717 databus
Public Const ERR_SUPERFRM As Integer = -104 '//SuperFrame not configured
Public Const ERR_SUPERFRMNUM As Integer = -105  '//Invalid 717 SuperFrame number was specified
