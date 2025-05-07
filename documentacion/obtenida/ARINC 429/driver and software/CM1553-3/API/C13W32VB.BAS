'/**
'*
'*  CM1553-3 WIN32 DRIVER  Version 1.6.1  (02/01/2008)
'*  Copyright (c) 1999-2008
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   C13W32.BAS -- 32-bit
'*                      CM1553-3 Driver Include Header File.
'*
'**/

'/**
'*
'*  Structs used by the C13 Driver.
'*
'**/

Public Type XMITFIELDS
	ctrlflags As Long	'//User writes message configuration optionvals
	flag1 As Integer	'//Card writes message flag 1
	flag2 As Integer	'//Card writes message flag 2
	errflags As Integer	'//Card writes errorval flags
	actflags As Integer	'//Card writes activity flags
	resptime1 As Integer	'//Card writes response time 1
	resptime2 As Integer	'//Card writes response time 2
	datacount As Integer	'//Card writes data count
	resv7 As Integer	'//Reserved field
	timetag As Long	'//Card writes time tag
	elapsetime As Long	'//Card writes elapsed time
	resv12 As Integer	'//Reserved field
	resv13 As Integer	'//Reserved field
	resv14 As Integer	'//Reserved field
	resv15 As Integer	'//Reserved field
	resv16 As Integer	'//Reserved field
	resv17 As Integer	'//Reserved field
	resv18 As Integer	'//Reserved field
	resv19 As Integer	'//Reserved field
	cwd1 As Integer	'//User writes command word 1
	cwd2 As Integer	'//User writes command word 2
	swd1 As Integer	'//Card writes status word 1
	swd2 As Integer	'//Card writes status word 2
	data(0 to 31) As Integer	'//User writes data words
	extra(0 to 7) As Integer	'//User writes extra words
End Type

'/**
'*
'*  C13 Driver functions.
'*
'**/

'/**
'*
'*  Internal functions used by the C13 Driver.
'*
'**/

Public Declare Function C13_BCConfig Lib "C13W32.DLL" Alias "_C13_BCConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCCreateList Lib "C13W32.DLL" Alias "_C13_BCCreateList@28" (ByVal listconfigval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal cwd1 As Integer, ByVal cwd2 As Integer, ByRef data As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCCreateMsg Lib "C13W32.DLL" Alias "_C13_BCCreateMsg@20" (ByVal configval As Long, ByVal cwd1 As Integer, ByVal cwd2 As Integer, ByRef data As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedFrame Lib "C13W32.DLL" Alias "_C13_BCSchedFrame@8" (ByVal timeval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedMsg Lib "C13W32.DLL" Alias "_C13_BCSchedMsg@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedRetry Lib "C13W32.DLL" Alias "_C13_BCSchedRetry@12" (ByVal condition As Integer, ByVal retries As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCTransmitMsg Lib "C13W32.DLL" Alias "_C13_BCTransmitMsg@8" (ByRef xmitfieldsval As XMITFIELDS, ByVal handleval As Long) As Long
Public Declare Function C13_BCTransmitMsgEx Lib "C13W32.DLL" Alias "_C13_BCTransmitMsgEx@8" (ByRef xmitfieldsval As XMITFIELDS, ByVal handleval As Long) As Long
Public Declare Function C13_CardClose Lib "C13W32.DLL" Alias "_C13_CardClose@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardOpen Lib "C13W32.DLL" Alias "_C13_CardOpen@4" (ByVal cardnum As Long) As Long
Public Declare Function C13_CardReset Lib "C13W32.DLL" Alias "_C13_CardReset@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardStart Lib "C13W32.DLL" Alias "_C13_CardStart@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardStop Lib "C13W32.DLL" Alias "_C13_CardStop@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ErrorCtrl Lib "C13W32.DLL" Alias "_C13_ErrorCtrl@8" (ByVal ctrlval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ErrorDefine Lib "C13W32.DLL" Alias "_C13_ErrorDefine@24" (ByVal defineval As Long, ByVal errvalue As Integer, ByVal countval As Long, ByVal wordpos As Integer, ByVal bitpos As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_ErrorSent Lib "C13W32.DLL" Alias "_C13_ErrorSent@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ErrorTagBC Lib "C13W32.DLL" Alias "_C13_ErrorTagBC@12" (ByVal tagval As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ErrorTagRT Lib "C13W32.DLL" Alias "_C13_ErrorTagRT@24" (ByVal tagval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListDataRd Lib "C13W32.DLL" Alias "_C13_ListDataRd@16" (ByRef buf As Integer, ByVal count As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListDataWr Lib "C13W32.DLL" Alias "_C13_ListDataWr@16" (ByRef buf As Integer, ByVal count As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MonBlkRd Lib "C13W32.DLL" Alias "_C13_MonBlkRd@16" (ByRef buf As Integer, ByVal bufcount As Long, ByRef blkcnt As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MonBlkRdEx Lib "C13W32.DLL" Alias "_C13_MonBlkRdEx@20" (ByRef buf As Integer, ByVal bufcount As Long, ByVal maxblkcnt As Long, ByRef blkcnt As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MonConfig Lib "C13W32.DLL" Alias "_C13_MonConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MonFilterSA Lib "C13W32.DLL" Alias "_C13_MonFilterSA@24" (ByVal taval As Long, ByVal rcvsamask As Long, ByVal xmtsamask As Long, ByVal rcvmcmask As Long, ByVal xmtmcmask As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MonFilterTA Lib "C13W32.DLL" Alias "_C13_MonFilterTA@8" (ByVal tamask As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MonIsRunning Lib "C13W32.DLL" Alias "_C13_MonIsRunning@4" (ByVal handleval As Long) As Long
Public Declare Function C13_MonRd Lib "C13W32.DLL" Alias "_C13_MonRd@8" (ByRef buf As Integer, ByVal handleval As Long) As Integer
Public Declare Function C13_MsgDataRd Lib "C13W32.DLL" Alias "_C13_MsgDataRd@16" (ByRef buf As Integer, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgDataWr Lib "C13W32.DLL" Alias "_C13_MsgDataWr@16" (ByRef buf As Integer, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgFieldRd Lib "C13W32.DLL" Alias "_C13_MsgFieldRd@12" (ByVal fieldtype As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgFieldWr Lib "C13W32.DLL" Alias "_C13_MsgFieldWr@16" (ByVal fieldval As Long, ByVal fieldtype As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_PlayConfig Lib "C13W32.DLL" Alias "_C13_PlayConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_PlayWr Lib "C13W32.DLL" Alias "_C13_PlayWr@8" (ByRef buf As Integer, ByVal handleval As Long) As Integer
Public Declare Function C13_RTConfig Lib "C13W32.DLL" Alias "_C13_RTConfig@12" (ByVal configval As Long, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RTCreateList Lib "C13W32.DLL" Alias "_C13_RTCreateList@32" (ByVal listconfigval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RTCreateMsg Lib "C13W32.DLL" Alias "_C13_RTCreateMsg@24" (ByVal configval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RTGetMsg Lib "C13W32.DLL" Alias "_C13_RTGetMsg@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RTSWDWr Lib "C13W32.DLL" Alias "_C13_RTSWDWr@12" (ByVal swdval As Integer, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ValPackCWD Lib "C13W32.DLL" Alias "_C13_ValPackCWD@16" (ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal wcval As Long) As Integer
Public Declare Function C13_ValUnpackCWD Lib "C13W32.DLL" Alias "_C13_ValUnpackCWD@20" (ByVal cwdval As Integer, ByRef taval As Long, ByRef trflag As Long, ByRef saval As Long, ByRef wcval As Long) As Long
Public Declare Function C13_AddrDSP Lib "C13W32.DLL" Alias "_C13_AddrDSP@4" (ByVal addr As Long) As Long
Public Declare Function C13_AddrHost Lib "C13W32.DLL" Alias "_C13_AddrHost@4" (ByVal addr As Long) As Long
Public Declare Function C13_AsciiCat Lib "C13W32.DLL" Alias "_C13_AsciiCat@8" (ByRef strdest As String, ByRef strsrc As String) As Long
Public Declare Function C13_AsciiCmpi Lib "C13W32.DLL" Alias "_C13_AsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Long
Public Declare Function C13_AsciiCpy Lib "C13W32.DLL" Alias "_C13_AsciiCpy@8" (ByRef strdest As String, ByRef strsrc As String) As Long
Public Declare Function C13_AsciiFromNibble Lib "C13W32.DLL" Alias "_C13_AsciiFromNibble@4" (ByVal ch As Char) As Long
Public Declare Function C13_AsciiFromVal Lib "C13W32.DLL" Alias "_C13_AsciiFromVal@16" (ByVal value As Long, ByRef asciistr As String, ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function C13_AsciiInc Lib "C13W32.DLL" Alias "_C13_AsciiInc@4" (ByRef asciistr As String) As Long
Public Declare Function C13_AsciiIncc Lib "C13W32.DLL" Alias "_C13_AsciiIncc@4" (ByRef asciistr As String) As Long
Public Declare Function C13_AsciiIsLower Lib "C13W32.DLL" Alias "_C13_AsciiIsLower@4" (ByVal value As Long) As Long
Public Declare Function C13_AsciiIsRadix Lib "C13W32.DLL" Alias "_C13_AsciiIsRadix@8" (ByRef asciistr As String, ByVal radixval As Long) As Long
Public Declare Function C13_AsciiLenVal Lib "C13W32.DLL" Alias "_C13_AsciiLenVal@8" (ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function C13_AsciiToUpper Lib "C13W32.DLL" Alias "_C13_AsciiToUpper@4" (ByVal value As Long) As Long
Public Declare Function C13_AsciiToVal Lib "C13W32.DLL" Alias "_C13_AsciiToVal@8" (ByRef asciistr As String, ByVal radixval As Long) As Long
Public Declare Function C13_AsciiTrimLead Lib "C13W32.DLL" Alias "_C13_AsciiTrimLead@4" (ByRef buf As String) As Long
Public Declare Function C13_AsciiTrimTrail Lib "C13W32.DLL" Alias "_C13_AsciiTrimTrail@4" (ByRef buf As String) As Long
Public Declare Function C13_AsciiTrimZero Lib "C13W32.DLL" Alias "_C13_AsciiTrimZero@4" (ByRef buf As String) As Long
Public Declare Function C13_BCConfigEx Lib "C13W32.DLL" Alias "_C13_BCConfigEx@12" (ByVal configval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCConfigMsg Lib "C13W32.DLL" Alias "_C13_BCConfigMsg@12" (ByVal configval As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCCreateListEx Lib "C13W32.DLL" Alias "_C13_BCCreateListEx@32" (ByVal listconfigval As Long, ByVal skipval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal cwd1 As Integer, ByVal cwd2 As Integer, ByRef data As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCCreateListExx Lib "C13W32.DLL" Alias "_C13_BCCreateListExx@32" (ByVal listconfigval As Long, ByVal skipval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal cwd1 As Integer, ByVal cwd2 As Integer, ByRef data As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCGetMsg Lib "C13W32.DLL" Alias "_C13_BCGetMsg@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedAgain Lib "C13W32.DLL" Alias "_C13_BCSchedAgain@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedBranch Lib "C13W32.DLL" Alias "_C13_BCSchedBranch@12" (ByVal condition As Integer, ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedBranchDin0 Lib "C13W32.DLL" Alias "_C13_BCSchedBranchDin0@8" (ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedBranchDin1 Lib "C13W32.DLL" Alias "_C13_BCSchedBranchDin1@8" (ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedBranchEx Lib "C13W32.DLL" Alias "_C13_BCSchedBranchEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedBuild Lib "C13W32.DLL" Alias "_C13_BCSchedBuild@16" (ByVal nummsgs As Integer, ByRef msgaddr As Long, ByRef freq As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedCall Lib "C13W32.DLL" Alias "_C13_BCSchedCall@8" (ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedCallCond Lib "C13W32.DLL" Alias "_C13_BCSchedCallCond@12" (ByVal condition As Integer, ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedCallCondEx Lib "C13W32.DLL" Alias "_C13_BCSchedCallCondEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedEntry Lib "C13W32.DLL" Alias "_C13_BCSchedEntry@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedFrameEnd Lib "C13W32.DLL" Alias "_C13_BCSchedFrameEnd@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedFrameStart Lib "C13W32.DLL" Alias "_C13_BCSchedFrameStart@8" (ByVal timeval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedGap Lib "C13W32.DLL" Alias "_C13_BCSchedGap@8" (ByVal gapval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedGoto Lib "C13W32.DLL" Alias "_C13_BCSchedGoto@8" (ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedHalt Lib "C13W32.DLL" Alias "_C13_BCSchedHalt@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedInt Lib "C13W32.DLL" Alias "_C13_BCSchedInt@8" (ByVal tagval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedIntCond Lib "C13W32.DLL" Alias "_C13_BCSchedIntCond@12" (ByVal condition As Integer, ByVal tagval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedIntCondEx Lib "C13W32.DLL" Alias "_C13_BCSchedIntCondEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal tagval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedNop Lib "C13W32.DLL" Alias "_C13_BCSchedNop@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedPause Lib "C13W32.DLL" Alias "_C13_BCSchedPause@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedPulse Lib "C13W32.DLL" Alias "_C13_BCSchedPulse@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedPulse0 Lib "C13W32.DLL" Alias "_C13_BCSchedPulse0@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedPulse1 Lib "C13W32.DLL" Alias "_C13_BCSchedPulse1@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedRestart Lib "C13W32.DLL" Alias "_C13_BCSchedRestart@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedRetryEx Lib "C13W32.DLL" Alias "_C13_BCSchedRetryEx@24" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal retryflag As Integer, ByVal retries As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedReturn Lib "C13W32.DLL" Alias "_C13_BCSchedReturn@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSchedUser Lib "C13W32.DLL" Alias "_C13_BCSchedUser@8" (ByVal useraddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BCSetEntry Lib "C13W32.DLL" Alias "_C13_BCSetEntry@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BCSetTimeout Lib "C13W32.DLL" Alias "_C13_BCSetTimeout@8" (ByVal timeoutval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_BlkAddr Lib "C13W32.DLL" Alias "_C13_BlkAddr@8" (ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BlkOptRd Lib "C13W32.DLL" Alias "_C13_BlkOptRd@8" (ByVal taval As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_BlkOptWr Lib "C13W32.DLL" Alias "_C13_BlkOptWr@12" (ByVal rtopt As Integer, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BlkPtrRd Lib "C13W32.DLL" Alias "_C13_BlkPtrRd@8" (ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BlkPtrWr Lib "C13W32.DLL" Alias "_C13_BlkPtrWr@12" (ByVal descaddr As Long, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BlkRd Lib "C13W32.DLL" Alias "_C13_BlkRd@12" (ByRef block As Integer, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BlkReset Lib "C13W32.DLL" Alias "_C13_BlkReset@8" (ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BlkSWDRd Lib "C13W32.DLL" Alias "_C13_BlkSWDRd@8" (ByVal taval As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_BlkSWDWr Lib "C13W32.DLL" Alias "_C13_BlkSWDWr@12" (ByVal swdval As Integer, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_BlkWipe Lib "C13W32.DLL" Alias "_C13_BlkWipe@4" (ByVal handleval As Long) As Long
Public Declare Function C13_BlkWr Lib "C13W32.DLL" Alias "_C13_BlkWr@12" (ByRef block As Integer, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CardBoot Lib "C13W32.DLL" Alias "_C13_CardBoot@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardCloseAll Lib "C13W32.DLL" Alias "_C13_CardCloseAll@0" () As Long
Public Declare Function C13_CardConfig Lib "C13W32.DLL" Alias "_C13_CardConfig@16" (ByVal enableflag As Long, ByVal command As Integer, ByVal taval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CardGetInfo Lib "C13W32.DLL" Alias "_C13_CardGetInfo@8" (ByVal infotype As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CardGetInfos Lib "C13W32.DLL" Alias "_C13_CardGetInfos@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardGetParam Lib "C13W32.DLL" Alias "_C13_CardGetParam@36" (ByRef cardstr As String, ByRef cardnum As Long, ByRef devnum As Long, ByRef sizval As Long, ByRef memval As Integer, ByRef ioval As Integer, ByRef irqval As Integer, ByRef spdval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CardInit Lib "C13W32.DLL" Alias "_C13_CardInit@0" () As Long
Public Declare Function C13_CardIsRunning Lib "C13W32.DLL" Alias "_C13_CardIsRunning@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardOpenEx Lib "C13W32.DLL" Alias "_C13_CardOpenEx@8" (ByRef cardname As String, ByVal cardnum As Long) As Long
Public Declare Function C13_CardOpenExx Lib "C13W32.DLL" Alias "_C13_CardOpenExx@16" (ByRef cardname As String, ByVal cardnum As Long, ByRef happwnd As Long, ByVal uiremovalmsg As Integer) As Long
Public Declare Function C13_CardResetEx Lib "C13W32.DLL" Alias "_C13_CardResetEx@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardResume Lib "C13W32.DLL" Alias "_C13_CardResume@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardTest Lib "C13W32.DLL" Alias "_C13_CardTest@8" (ByVal level As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CardTest0 Lib "C13W32.DLL" Alias "_C13_CardTest0@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardTest1 Lib "C13W32.DLL" Alias "_C13_CardTest1@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardTest2 Lib "C13W32.DLL" Alias "_C13_CardTest2@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardTest3 Lib "C13W32.DLL" Alias "_C13_CardTest3@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CardTrigger Lib "C13W32.DLL" Alias "_C13_CardTrigger@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CDBase Lib "C13W32.DLL" Alias "" (ByRef memval As Integer, ByRef ioval As Integer, ByRef irqval As Integer, ByRef sizval As Integer, ByRef spdval As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CDDeregisterClient Lib "C13W32.DLL" Alias "" () As Long
Public Declare Function C13_CDMapMem Lib "C13W32.DLL" Alias "" (ByVal offset As Long, ByVal socketval As Long) As Long
Public Declare Function C13_CDRegisterClient Lib "C13W32.DLL" Alias "" () As Long
Public Declare Function C13_CDReleaseAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDReleaseConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDReleaseDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDReleaseExclusive Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDReleaseIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDReleaseIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDReleaseMem Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDRequestAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDRequestConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDRequestDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDRequestExclusive Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDRequestIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDRequestIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDRequestMem Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDReset Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDRestartAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDVarConfig Lib "C13W32.DLL" Alias "" (ByVal value As Long, ByVal symbol As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CDVarCount Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Integer
Public Declare Function C13_CDVarDefault Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDVarLoad Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CDVarQuery Lib "C13W32.DLL" Alias "" (ByVal symbol As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CDVarRetrieve Lib "C13W32.DLL" Alias "" (ByVal index As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEAttributeConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEBase Lib "C13W32.DLL" Alias "" (ByRef memval As Integer, ByRef ioval As Integer, ByRef irqval As Integer, ByRef sizval As Integer, ByRef spdval As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CECall Lib "C13W32.DLL" Alias "" (ByVal func As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CECallEx Lib "C13W32.DLL" Alias "" (ByVal func As Integer, ByVal socketval As Long, ByRef valuewptr As Integer, ByRef valuelptr As Long) As Long
Public Declare Function C13_CECISClose Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CECISDisable Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CECISEnable Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CECISFlush Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CECISOpen Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CECISRead Lib "C13W32.DLL" Alias "" (ByRef value As Integer, ByVal addr As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CECISReads Lib "C13W32.DLL" Alias "" (ByRef value As Integer, ByVal addr As Integer, ByVal count As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CECISWrite Lib "C13W32.DLL" Alias "" (ByVal value As Integer, ByVal addr As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CECISWrites Lib "C13W32.DLL" Alias "" (ByRef value As Integer, ByVal addr As Integer, ByVal count As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEDeregisterClient Lib "C13W32.DLL" Alias "" () As Long
Public Declare Function C13_CEErrorClear Lib "C13W32.DLL" Alias "" () As Long
Public Declare Function C13_CEErrorCount Lib "C13W32.DLL" Alias "" () As Integer
Public Declare Function C13_CEErrorValue Lib "C13W32.DLL" Alias "" (ByVal index As Integer) As Long
Public Declare Function C13_CEFiveVoltConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEFuncID Lib "C13W32.DLL" Alias "" () As Integer
Public Declare Function C13_CEIOAttrConfig Lib "C13W32.DLL" Alias "" (ByVal attrval As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEIOBaseConfig Lib "C13W32.DLL" Alias "" (ByVal basevalval As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEIRQAttrConfig Lib "C13W32.DLL" Alias "" (ByVal attrval As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEIRQIrqConfig Lib "C13W32.DLL" Alias "" (ByVal irqval As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEMapMemory Lib "C13W32.DLL" Alias "" (ByVal offset As Long, ByVal socketval As Long) As Long
Public Declare Function C13_CEMemAttrConfig Lib "C13W32.DLL" Alias "" (ByVal attrval As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEMemBaseConfig Lib "C13W32.DLL" Alias "" (ByVal basevalval As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEMemSizeConfig Lib "C13W32.DLL" Alias "" (ByVal sizeval As Long, ByVal socketval As Long) As Long
Public Declare Function C13_CEMemSpeedConfig Lib "C13W32.DLL" Alias "" (ByVal speedval As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEPresent Lib "C13W32.DLL" Alias "" () As Long
Public Declare Function C13_CERegisterClient Lib "C13W32.DLL" Alias "" () As Long
Public Declare Function C13_CEReleaseAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEReleaseConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEReleaseDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEReleaseIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEReleaseIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEReleaseMemory Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CERequestAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CERequestConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CERequestDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CERequestIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CERequestIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CERequestMemory Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEReset Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEResetCheck Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEResetError Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CERestartAll Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEVarConfig Lib "C13W32.DLL" Alias "" (ByVal value As Long, ByVal symbol As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEVarDefault Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CEVarQuery Lib "C13W32.DLL" Alias "" (ByVal symbol As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CEZeroVoltConfig Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Long
Public Declare Function C13_CmdAddr Lib "C13W32.DLL" Alias "_C13_CmdAddr@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CmdAlloc Lib "C13W32.DLL" Alias "_C13_CmdAlloc@8" (ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CmdAllocEx Lib "C13W32.DLL" Alias "_C13_CmdAllocEx@12" (ByVal configval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CmdBaseRd Lib "C13W32.DLL" Alias "_C13_CmdBaseRd@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CmdBaseWr Lib "C13W32.DLL" Alias "_C13_CmdBaseWr@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CmdClear Lib "C13W32.DLL" Alias "_C13_CmdClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CmdCountRd Lib "C13W32.DLL" Alias "_C13_CmdCountRd@4" (ByVal handleval As Long) As Integer
Public Declare Function C13_CmdCountWr Lib "C13W32.DLL" Alias "_C13_CmdCountWr@8" (ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CmdCtrlRd Lib "C13W32.DLL" Alias "_C13_CmdCtrlRd@8" (ByVal index As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_CmdCtrlWr Lib "C13W32.DLL" Alias "_C13_CmdCtrlWr@12" (ByVal ctrlval As Integer, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CmdCurrRd Lib "C13W32.DLL" Alias "_C13_CmdCurrRd@4" (ByVal handleval As Long) As Integer
Public Declare Function C13_CmdCurrWr Lib "C13W32.DLL" Alias "_C13_CmdCurrWr@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CmdInit Lib "C13W32.DLL" Alias "_C13_CmdInit@8" (ByVal opcode As Integer, ByRef block As Integer) As Long
Public Declare Function C13_CmdInsert Lib "C13W32.DLL" Alias "_C13_CmdInsert@8" (ByRef block As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CmdMaxRd Lib "C13W32.DLL" Alias "_C13_CmdMaxRd@4" (ByVal handleval As Long) As Integer
Public Declare Function C13_CmdMaxWr Lib "C13W32.DLL" Alias "_C13_CmdMaxWr@8" (ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CmdRd Lib "C13W32.DLL" Alias "_C13_CmdRd@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CmdShotWr Lib "C13W32.DLL" Alias "_C13_CmdShotWr@12" (ByVal value As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CmdSkipWr Lib "C13W32.DLL" Alias "_C13_CmdSkipWr@12" (ByVal value As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CmdStackClear Lib "C13W32.DLL" Alias "_C13_CmdStackClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CmdStartRd Lib "C13W32.DLL" Alias "_C13_CmdStartRd@4" (ByVal handleval As Long) As Integer
Public Declare Function C13_CmdStartWr Lib "C13W32.DLL" Alias "_C13_CmdStartWr@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CmdTotalRd Lib "C13W32.DLL" Alias "_C13_CmdTotalRd@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CmdTotalWr Lib "C13W32.DLL" Alias "_C13_CmdTotalWr@8" (ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CmdWr Lib "C13W32.DLL" Alias "_C13_CmdWr@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CommCall Lib "C13W32.DLL" Alias "_C13_CommCall@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CommCheck Lib "C13W32.DLL" Alias "_C13_CommCheck@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CommCheckEx Lib "C13W32.DLL" Alias "_C13_CommCheckEx@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CommConfig Lib "C13W32.DLL" Alias "_C13_CommConfig@12" (ByVal enableflag As Long, ByVal command As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommDataRdL Lib "C13W32.DLL" Alias "_C13_CommDataRdL@12" (ByRef valueptr As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CommDataRdsW Lib "C13W32.DLL" Alias "_C13_CommDataRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommDataRdW Lib "C13W32.DLL" Alias "_C13_CommDataRdW@12" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CommDataWrL Lib "C13W32.DLL" Alias "_C13_CommDataWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CommDataWrsW Lib "C13W32.DLL" Alias "_C13_CommDataWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommDataWrW Lib "C13W32.DLL" Alias "_C13_CommDataWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_CommDisable Lib "C13W32.DLL" Alias "_C13_CommDisable@8" (ByVal command As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommEnable Lib "C13W32.DLL" Alias "_C13_CommEnable@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CommErrRdsW Lib "C13W32.DLL" Alias "_C13_CommErrRdsW@12" (ByRef errbuf As Integer, ByVal errbufcount As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommErrWrsW Lib "C13W32.DLL" Alias "_C13_CommErrWrsW@12" (ByRef errbuf As Integer, ByVal errbufcount As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommGlobRdW Lib "C13W32.DLL" Alias "_C13_CommGlobRdW@12" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommGlobWrW Lib "C13W32.DLL" Alias "_C13_CommGlobWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommInfoRdsW Lib "C13W32.DLL" Alias "_C13_CommInfoRdsW@20" (ByRef bufmodel As Integer, ByVal bufmodelcount As Integer, ByRef buffeature As Integer, ByVal buffeaturecount As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommProgRdW Lib "C13W32.DLL" Alias "_C13_CommProgRdW@12" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommProgWrW Lib "C13W32.DLL" Alias "_C13_CommProgWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommRun Lib "C13W32.DLL" Alias "_C13_CommRun@20" (ByRef dataptr As Integer, ByVal datacount As Integer, ByRef progptr As Integer, ByVal progcount As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_CommStart Lib "C13W32.DLL" Alias "_C13_CommStart@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CommStop Lib "C13W32.DLL" Alias "_C13_CommStop@4" (ByVal handleval As Long) As Long
Public Declare Function C13_CSAdjustResourceInfo Lib "C13W32.DLL" Alias "" (ByVal action As Integer, ByVal resource As Integer, ByRef resourceinfo As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSAdjustResourceInfoDma Lib "C13W32.DLL" Alias "" (ByVal action As Integer, ByRef dmainfo As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSAdjustResourceInfoIo Lib "C13W32.DLL" Alias "" (ByVal action As Integer, ByRef ioinfo As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSAdjustResourceInfoIrq Lib "C13W32.DLL" Alias "" (ByVal action As Integer, ByRef irqinfo As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSAdjustResourceInfoMem Lib "C13W32.DLL" Alias "" (ByVal action As Integer, ByRef meminfo As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSCall Lib "C13W32.DLL" Alias "" (ByVal func As Integer, ByRef handle As Integer, ByRef ptr As Long, ByRef argptr As Long, ByVal arglen As Integer) As Integer
Public Declare Function C13_CSDeregisterClient Lib "C13W32.DLL" Alias "" (ByRef clientinfo As Long) As Long
Public Declare Function C13_CSErrClear Lib "C13W32.DLL" Alias "" () As Long
Public Declare Function C13_CSErrGetCode Lib "C13W32.DLL" Alias "" (ByVal index As Integer) As Long
Public Declare Function C13_CSErrGetCount Lib "C13W32.DLL" Alias "" () As Integer
Public Declare Function C13_CSErrInsert Lib "C13W32.DLL" Alias "" (ByVal errval As Long) As Long
Public Declare Function C13_CSGetCardServicesInfoStr Lib "C13W32.DLL" Alias "" (ByRef vendorstring As String, ByVal vendorstringlen As Integer) As Long
Public Declare Function C13_CSGetCardServicesInfoVal Lib "C13W32.DLL" Alias "" (ByRef csinfo As Long) As Long
Public Declare Function C13_CSGetClientInfo Lib "C13W32.DLL" Alias "" (ByRef namestring As String, ByVal namestringlen As Integer, ByRef vendorstring As String, ByVal vendorstringlen As Integer, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSGetClientInfoName Lib "C13W32.DLL" Alias "" (ByRef namestring As String, ByVal namestringlen As Integer, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSGetClientInfoVendor Lib "C13W32.DLL" Alias "" (ByRef vendorstring As String, ByVal vendorstringlen As Integer, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSGetConfigurationInfo Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByRef configinfo As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSGetFirstClient Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal attributes As Integer, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSGetFirstTuple Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal attributes As Integer, ByVal desiredtuple As Integer, ByRef tupleinfo As Long) As Integer
Public Declare Function C13_CSGetNextClient Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal attributes As Integer, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSGetNextTuple Lib "C13W32.DLL" Alias "" (ByVal desiredtuple As Integer, ByRef tupleinfo As Long) As Integer
Public Declare Function C13_CSGetStatus Lib "C13W32.DLL" Alias "" (ByRef cardstate As Integer, ByRef socketstate As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CSGetStatusCard Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Integer
Public Declare Function C13_CSGetStatusSocket Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Integer
Public Declare Function C13_CSGetTupleChan Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Integer
Public Declare Function C13_CSGetTupleCount Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal desiredtuple As Integer) As Integer
Public Declare Function C13_CSGetTupleData Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal tupleoffset As Integer, ByRef tupledata As Byte, ByVal tupledatalen As Integer, ByRef tupleinfo As Long) As Integer
Public Declare Function C13_CSGetTupleIndex Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal index As Integer, ByVal desiredtuple As Integer, ByRef tupledata As Byte, ByVal tupledatalen As Integer) As Integer
Public Declare Function C13_CSGetTupleManuf Lib "C13W32.DLL" Alias "" (ByRef code As Integer, ByRef info As Integer, ByVal socketval As Long) As Long
Public Declare Function C13_CSLevel Lib "C13W32.DLL" Alias "" () As Integer
Public Declare Function C13_CSMapMemPage Lib "C13W32.DLL" Alias "" (ByVal cardoffset As Long, ByVal page As Integer, ByRef windowinfo As Long) As Long
Public Declare Function C13_CSModifyConfiguration Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByRef configinfo As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSModifyWindow Lib "C13W32.DLL" Alias "" (ByVal attributes As Integer, ByVal accessspeed As Integer, ByRef windowinfo As Long) As Long
Public Declare Function C13_CSRegisterClient Lib "C13W32.DLL" Alias "" (ByVal attributes As Integer, ByVal eventvalmask As Integer, ByVal version As Integer, ByRef clientinfo As Long, ByRef func As Long, ByVal data As Integer, ByRef dataptr As Long) As Long
Public Declare Function C13_CSReleaseConfiguration Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSReleaseDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal desiredchannel As Integer, ByVal attributes As Byte, ByVal assignedchannel As Byte, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSReleaseExclusive Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal attributes As Integer, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSReleaseIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal basevalport As Integer, ByVal numports As Integer, ByVal attributes As Integer, ByVal ioaddrlines As Integer, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSReleaseIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal attributes As Integer, ByVal assignedirq As Integer, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSReleaseWindow Lib "C13W32.DLL" Alias "" (ByRef windowinfo As Long) As Long
Public Declare Function C13_CSRequestConfiguration Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByRef configinfo As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSRequestDMA Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal desiredchannel As Integer, ByVal attributes As Byte, ByRef assignedchannel As Byte, ByRef clientinfo As Long) As Byte
Public Declare Function C13_CSRequestExclusive Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal attributes As Integer, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSRequestIO Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByVal basevalport As Integer, ByVal numports As Integer, ByVal attributes As Integer, ByVal ioaddrlines As Integer, ByRef clientinfo As Long) As Integer
Public Declare Function C13_CSRequestIRQ Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByRef attributes As Integer, ByVal irqinfo1 As Integer, ByVal irqinfo2 As Integer, ByRef clientinfo As Long) As Integer
Public Declare Function C13_CSRequestWindow Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByRef attributes As Integer, ByRef baseval As Long, ByRef size As Long, ByVal accessspeed As Integer, ByRef windowinfo As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSResetCard Lib "C13W32.DLL" Alias "" (ByVal socketval As Long, ByRef clientinfo As Long) As Long
Public Declare Function C13_CSRevision Lib "C13W32.DLL" Alias "" () As Integer
Public Declare Function C13_CSSignature Lib "C13W32.DLL" Alias "" () As Integer
Public Declare Function C13_CSSocketCount Lib "C13W32.DLL" Alias "" () As Integer
Public Declare Function C13_CSValidateCIS Lib "C13W32.DLL" Alias "" (ByVal socketval As Long) As Integer
Public Declare Function C13_CSVendorString Lib "C13W32.DLL" Alias "" (ByRef buf As String, ByVal bufsize As Integer) As Long
Public Declare Function C13_DARClear Lib "C13W32.DLL" Alias "_C13_DARClear@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_DARGet Lib "C13W32.DLL" Alias "_C13_DARGet@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_DARRdL Lib "C13W32.DLL" Alias "_C13_DARRdL@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_DARRdW Lib "C13W32.DLL" Alias "_C13_DARRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function C13_DARSet Lib "C13W32.DLL" Alias "_C13_DARSet@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_DARWrL Lib "C13W32.DLL" Alias "_C13_DARWrL@12" (ByVal value As Long, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_DARWrW Lib "C13W32.DLL" Alias "_C13_DARWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_DescAddr Lib "C13W32.DLL" Alias "_C13_DescAddr@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_DescAlloc Lib "C13W32.DLL" Alias "_C13_DescAlloc@4" (ByVal handleval As Long) As Long
Public Declare Function C13_DescConfig Lib "C13W32.DLL" Alias "_C13_DescConfig@24" (ByVal configval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_DescOptRd Lib "C13W32.DLL" Alias "_C13_DescOptRd@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_DescOptWr Lib "C13W32.DLL" Alias "_C13_DescOptWr@24" (ByVal descopt As Integer, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_DescPtrRd Lib "C13W32.DLL" Alias "_C13_DescPtrRd@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_DescPtrWr Lib "C13W32.DLL" Alias "_C13_DescPtrWr@24" (ByVal msgaddr As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_DescRd Lib "C13W32.DLL" Alias "_C13_DescRd@24" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByRef desc As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_DescWr Lib "C13W32.DLL" Alias "_C13_DescWr@24" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByRef desc As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_Div Lib "C13W32.DLL" Alias "_C13_Div@8" (ByVal diva As Long, ByVal divb As Long) As Long
Public Declare Function C13_DllUsageCount Lib "C13W32.DLL" Alias "_C13_DllUsageCount@0" () As Long
Public Declare Function C13_DspBioClear Lib "C13W32.DLL" Alias "_C13_DspBioClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_DspBioRd Lib "C13W32.DLL" Alias "_C13_DspBioRd@4" (ByVal handleval As Long) As Long
Public Declare Function C13_DspBioSet Lib "C13W32.DLL" Alias "_C13_DspBioSet@4" (ByVal handleval As Long) As Long
Public Declare Function C13_DspIntfClear Lib "C13W32.DLL" Alias "_C13_DspIntfClear@8" (ByVal intmask As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_DspIntfRd Lib "C13W32.DLL" Alias "_C13_DspIntfRd@8" (ByVal intmask As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_DspIntmClear Lib "C13W32.DLL" Alias "_C13_DspIntmClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_DspIntmSet Lib "C13W32.DLL" Alias "_C13_DspIntmSet@4" (ByVal handleval As Long) As Long
Public Declare Function C13_DspXfClear Lib "C13W32.DLL" Alias "_C13_DspXfClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_DspXfRd Lib "C13W32.DLL" Alias "_C13_DspXfRd@4" (ByVal handleval As Long) As Long
Public Declare Function C13_DspXfSet Lib "C13W32.DLL" Alias "_C13_DspXfSet@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ErrDesc Lib "C13W32.DLL" Alias "_C13_ErrDesc@4" (ByVal errval As Long) As Long
Public Declare Function C13_ErrDescStr Lib "C13W32.DLL" Alias "_C13_ErrDescStr@4" (ByVal errval As Long) As Long
Public Declare Function C13_ErrName Lib "C13W32.DLL" Alias "_C13_ErrName@4" (ByVal errval As Long) As Long
Public Declare Function C13_ErrorIsTaggedBC Lib "C13W32.DLL" Alias "_C13_ErrorIsTaggedBC@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ErrorIsTaggedRT Lib "C13W32.DLL" Alias "_C13_ErrorIsTaggedRT@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ErrorResponse Lib "C13W32.DLL" Alias "_C13_ErrorResponse@8" (ByVal responseval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_ErrorSync Lib "C13W32.DLL" Alias "_C13_ErrorSync@8" (ByVal value As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ErrorTimeout Lib "C13W32.DLL" Alias "_C13_ErrorTimeout@8" (ByVal timeoutval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_ExtDinRd Lib "C13W32.DLL" Alias "_C13_ExtDinRd@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ExtDoutRd Lib "C13W32.DLL" Alias "_C13_ExtDoutRd@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ExtDoutWr Lib "C13W32.DLL" Alias "_C13_ExtDoutWr@8" (ByVal doutval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_FileClose Lib "C13W32.DLL" Alias "_C13_FileClose@4" (ByRef handle As Long) As Long
Public Declare Function C13_FileErr Lib "C13W32.DLL" Alias "_C13_FileErr@0" () As Long
Public Declare Function C13_FileErrClear Lib "C13W32.DLL" Alias "_C13_FileErrClear@0" () As Long
Public Declare Function C13_FileErrSet Lib "C13W32.DLL" Alias "_C13_FileErrSet@0" () As Long
Public Declare Function C13_FileOpenRead Lib "C13W32.DLL" Alias "_C13_FileOpenRead@4" (ByRef filename As String) As Long
Public Declare Function C13_FileOpenWrite Lib "C13W32.DLL" Alias "_C13_FileOpenWrite@4" (ByRef filename As String) As Long
Public Declare Function C13_FileRead Lib "C13W32.DLL" Alias "_C13_FileRead@12" (ByRef handle As Long, ByRef buffer As Long, ByVal count As Integer) As Long
Public Declare Function C13_FileSeek Lib "C13W32.DLL" Alias "_C13_FileSeek@8" (ByRef handle As Long, ByVal offset As Long) As Long
Public Declare Function C13_FileTell Lib "C13W32.DLL" Alias "_C13_FileTell@4" (ByRef handle As Long) As Long
Public Declare Function C13_FileWrite Lib "C13W32.DLL" Alias "_C13_FileWrite@12" (ByRef handle As Long, ByRef buffer As Long, ByVal count As Integer) As Long
Public Declare Function C13_GetHigh Lib "C13W32.DLL" Alias "_C13_GetHigh@4" (ByVal val As Long) As Integer
Public Declare Function C13_GetLow Lib "C13W32.DLL" Alias "_C13_GetLow@4" (ByVal val As Long) As Integer
Public Declare Function C13_GetOff Lib "C13W32.DLL" Alias "_C13_GetOff@4" (ByRef valptr As Long) As Integer
Public Declare Function C13_GetSeg Lib "C13W32.DLL" Alias "_C13_GetSeg@4" (ByRef valptr As Long) As Integer
Public Declare Function C13_GlobalRdW Lib "C13W32.DLL" Alias "_C13_GlobalRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function C13_GlobalWrW Lib "C13W32.DLL" Alias "_C13_GlobalWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_HandleClose Lib "C13W32.DLL" Alias "_C13_HandleClose@4" (ByVal handleval As Long) As Long
Public Declare Function C13_HandleDel Lib "C13W32.DLL" Alias "_C13_HandleDel@4" (ByVal handleval As Long) As Long
Public Declare Function C13_HandleIns Lib "C13W32.DLL" Alias "_C13_HandleIns@16" (ByRef cardname As String, ByVal cardnum As Long, ByRef happwnd As Long, ByVal uiremovalmsg As Integer) As Long
Public Declare Function C13_HandleOkay Lib "C13W32.DLL" Alias "_C13_HandleOkay@4" (ByVal handleval As Long) As Long
Public Declare Function C13_HandleOpen Lib "C13W32.DLL" Alias "_C13_HandleOpen@12" (ByRef cardname As String, ByVal cardnum As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HandleOpenDOS Lib "C13W32.DLL" Alias "" (ByRef cardname As String, ByVal cardnum As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HandleOpenWin Lib "C13W32.DLL" Alias "_C13_HandleOpenWin@12" (ByRef cardname As String, ByVal cardnum As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HandleVer Lib "C13W32.DLL" Alias "_C13_HandleVer@4" (ByVal handleval As Long) As Long
Public Declare Function C13_HeapAlloc Lib "C13W32.DLL" Alias "_C13_HeapAlloc@8" (ByVal wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HeapAllocAll Lib "C13W32.DLL" Alias "_C13_HeapAllocAll@8" (ByRef wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HeapAllocAllDPM Lib "C13W32.DLL" Alias "_C13_HeapAllocAllDPM@8" (ByRef wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HeapAllocDPM Lib "C13W32.DLL" Alias "_C13_HeapAllocDPM@8" (ByVal wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HeapAllocEx Lib "C13W32.DLL" Alias "_C13_HeapAllocEx@12" (ByVal configval As Integer, ByVal wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HeapWipe Lib "C13W32.DLL" Alias "_C13_HeapWipe@4" (ByVal handleval As Long) As Long
Public Declare Function C13_HeapWipeDPM Lib "C13W32.DLL" Alias "_C13_HeapWipeDPM@4" (ByVal handleval As Long) As Long
Public Declare Function C13_HPMAddrRd Lib "C13W32.DLL" Alias "_C13_HPMAddrRd@4" (ByVal handleval As Long) As Integer
Public Declare Function C13_HPMAddrWr Lib "C13W32.DLL" Alias "_C13_HPMAddrWr@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_HPMCtrlRd Lib "C13W32.DLL" Alias "_C13_HPMCtrlRd@4" (ByVal handleval As Long) As Byte
Public Declare Function C13_HPMCtrlWr Lib "C13W32.DLL" Alias "_C13_HPMCtrlWr@8" (ByVal value As Byte, ByVal handleval As Long) As Long
Public Declare Function C13_HPMDataRd Lib "C13W32.DLL" Alias "_C13_HPMDataRd@4" (ByVal handleval As Long) As Integer
Public Declare Function C13_HPMDataRds Lib "C13W32.DLL" Alias "_C13_HPMDataRds@12" (ByRef valueptr As Integer, ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_HPMDataWr Lib "C13W32.DLL" Alias "_C13_HPMDataWr@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_HPMDataWrs Lib "C13W32.DLL" Alias "_C13_HPMDataWrs@12" (ByRef valueptr As Integer, ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_HPMRdL Lib "C13W32.DLL" Alias "_C13_HPMRdL@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_HPMRdsL Lib "C13W32.DLL" Alias "_C13_HPMRdsL@16" (ByRef valueptr As Long, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HPMRdsW Lib "C13W32.DLL" Alias "_C13_HPMRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HPMRdW Lib "C13W32.DLL" Alias "_C13_HPMRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function C13_HPMWrL Lib "C13W32.DLL" Alias "_C13_HPMWrL@12" (ByVal value As Long, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_HPMWrsL Lib "C13W32.DLL" Alias "_C13_HPMWrsL@16" (ByRef valueptr As Long, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HPMWrsW Lib "C13W32.DLL" Alias "_C13_HPMWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_HPMWrW Lib "C13W32.DLL" Alias "_C13_HPMWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_IntClear Lib "C13W32.DLL" Alias "_C13_IntClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_IntConfig Lib "C13W32.DLL" Alias "_C13_IntConfig@12" (ByVal configval As Integer, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_IntDisable Lib "C13W32.DLL" Alias "_C13_IntDisable@4" (ByVal handleval As Long) As Long
Public Declare Function C13_IntEnable Lib "C13W32.DLL" Alias "_C13_IntEnable@4" (ByVal handleval As Long) As Long
Public Declare Function C13_IntEnableCond Lib "C13W32.DLL" Alias "_C13_IntEnableCond@4" (ByVal handleval As Long) As Long
Public Declare Function C13_IntGet Lib "C13W32.DLL" Alias "_C13_IntGet@4" (ByVal handleval As Long) As Long
Public Declare Function C13_IntInstall Lib "C13W32.DLL" Alias "_C13_IntInstall@8" (ByRef hevent As Long, ByVal handleval As Long) As Long
Public Declare Function C13_IntRd Lib "C13W32.DLL" Alias "_C13_IntRd@12" (ByRef typevalval As Integer, ByRef infoval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_IntReset Lib "C13W32.DLL" Alias "_C13_IntReset@4" (ByVal handleval As Long) As Long
Public Declare Function C13_IntStatus Lib "C13W32.DLL" Alias "_C13_IntStatus@4" (ByVal handleval As Long) As Long
Public Declare Function C13_IntUninstall Lib "C13W32.DLL" Alias "_C13_IntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function C13_IORdW Lib "C13W32.DLL" Alias "_C13_IORdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_IOWINRdW Lib "C13W32.DLL" Alias "_C13_IOWINRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function C13_IOWINWrW Lib "C13W32.DLL" Alias "_C13_IOWINWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_IOWrW Lib "C13W32.DLL" Alias "_C13_IOWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernEnd Lib "C13W32.DLL" Alias "_C13_KernEnd@4" (ByRef vxdptr As Long) As Long
Public Declare Function C13_KernIntClear Lib "C13W32.DLL" Alias "_C13_KernIntClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_KernIntInstall Lib "C13W32.DLL" Alias "_C13_KernIntInstall@8" (ByRef hevent As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernIntParam Lib "C13W32.DLL" Alias "_C13_KernIntParam@32" (ByVal clraddr As Long, ByVal clrwidth As Long, ByVal clrvalue As Long, ByVal stataddr As Long, ByVal statwidth As Long, ByVal statvalue As Long, ByVal statmask As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernIntStatus Lib "C13W32.DLL" Alias "_C13_KernIntStatus@8" (ByRef valueptr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernIntUninstall Lib "C13W32.DLL" Alias "_C13_KernIntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function C13_KernIORdB Lib "C13W32.DLL" Alias "_C13_KernIORdB@12" (ByRef valueptr As Byte, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernIOWrB Lib "C13W32.DLL" Alias "_C13_KernIOWrB@12" (ByVal value As Byte, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMCopyB Lib "C13W32.DLL" Alias "_C13_KernMEMCopyB@12" (ByRef destptr As Long, ByRef srcptr As Long, ByVal countval As Integer) As Long
Public Declare Function C13_KernMEMFillW Lib "C13W32.DLL" Alias "_C13_KernMEMFillW@20" (ByVal value As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMRdB Lib "C13W32.DLL" Alias "_C13_KernMEMRdB@16" (ByRef valueptr As Byte, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMRdL Lib "C13W32.DLL" Alias "_C13_KernMEMRdL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMRdsL Lib "C13W32.DLL" Alias "_C13_KernMEMRdsL@20" (ByRef bufptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMRdsW Lib "C13W32.DLL" Alias "_C13_KernMEMRdsW@20" (ByRef bufptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMRdW Lib "C13W32.DLL" Alias "_C13_KernMEMRdW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMWrB Lib "C13W32.DLL" Alias "_C13_KernMEMWrB@16" (ByVal value As Byte, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMWrL Lib "C13W32.DLL" Alias "_C13_KernMEMWrL@16" (ByVal value As Long, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMWrsL Lib "C13W32.DLL" Alias "_C13_KernMEMWrsL@20" (ByRef bufptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMWrsW Lib "C13W32.DLL" Alias "_C13_KernMEMWrsW@20" (ByRef bufptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernMEMWrW Lib "C13W32.DLL" Alias "_C13_KernMEMWrW@16" (ByVal value As Integer, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_KernStatus Lib "C13W32.DLL" Alias "_C13_KernStatus@16" (ByRef valueptr As Long, ByVal typeval As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListAddr Lib "C13W32.DLL" Alias "_C13_ListAddr@12" (ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListAddrEx Lib "C13W32.DLL" Alias "_C13_ListAddrEx@12" (ByVal index As Long, ByVal listaddr As Long, ByRef header As Integer) As Long
Public Declare Function C13_ListBlockRd Lib "C13W32.DLL" Alias "_C13_ListBlockRd@12" (ByRef buf As Integer, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListBlockRdEx Lib "C13W32.DLL" Alias "_C13_ListBlockRdEx@16" (ByRef buf As Integer, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListBlockWr Lib "C13W32.DLL" Alias "_C13_ListBlockWr@12" (ByRef buf As Integer, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListBlockWrEx Lib "C13W32.DLL" Alias "_C13_ListBlockWrEx@16" (ByRef buf As Integer, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListClear Lib "C13W32.DLL" Alias "_C13_ListClear@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListConfig Lib "C13W32.DLL" Alias "_C13_ListConfig@16" (ByVal configval As Long, ByVal count As Long, ByVal skipval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_ListConfigEx Lib "C13W32.DLL" Alias "_C13_ListConfigEx@16" (ByVal configval As Long, ByVal count As Long, ByVal skipval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_ListDataRdEx Lib "C13W32.DLL" Alias "_C13_ListDataRdEx@20" (ByRef buf As Integer, ByVal count As Long, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListDataWrEx Lib "C13W32.DLL" Alias "_C13_ListDataWrEx@20" (ByRef buf As Integer, ByVal count As Long, ByVal index As Long, ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListInit Lib "C13W32.DLL" Alias "_C13_ListInit@12" (ByVal listaddr As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ListNextRd Lib "C13W32.DLL" Alias "_C13_ListNextRd@8" (ByVal listaddr As Long, ByRef header As Integer) As Long
Public Declare Function C13_ListNextWr Lib "C13W32.DLL" Alias "_C13_ListNextWr@8" (ByVal listaddr As Long, ByRef header As Integer) As Long
Public Declare Function C13_ListPostRd Lib "C13W32.DLL" Alias "_C13_ListPostRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_ListPostWr Lib "C13W32.DLL" Alias "_C13_ListPostWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_ListPreRd Lib "C13W32.DLL" Alias "_C13_ListPreRd@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_ListPreWr Lib "C13W32.DLL" Alias "_C13_ListPreWr@12" (ByVal listaddr As Long, ByRef header As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_ListStatus Lib "C13W32.DLL" Alias "_C13_ListStatus@8" (ByVal listaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MakeClientInfo Lib "C13W32.DLL" Alias "" (ByRef ptr As Long) As Long
Public Declare Function C13_MakeLong Lib "C13W32.DLL" Alias "_C13_MakeLong@8" (ByVal valh As Integer, ByVal vall As Integer) As Long
Public Declare Function C13_MakePtr Lib "C13W32.DLL" Alias "_C13_MakePtr@8" (ByVal valh As Integer, ByVal vall As Integer) As Long
Public Declare Function C13_Mask Lib "C13W32.DLL" Alias "_C13_Mask@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function C13_MEMWINFillW Lib "C13W32.DLL" Alias "_C13_MEMWINFillW@20" (ByVal value As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MEMWINRdB Lib "C13W32.DLL" Alias "_C13_MEMWINRdB@12" (ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_MEMWINRdL Lib "C13W32.DLL" Alias "_C13_MEMWINRdL@12" (ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MEMWINRdsL Lib "C13W32.DLL" Alias "_C13_MEMWINRdsL@20" (ByRef valueptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MEMWINRdsW Lib "C13W32.DLL" Alias "_C13_MEMWINRdsW@20" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MEMWINRdW Lib "C13W32.DLL" Alias "_C13_MEMWINRdW@12" (ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_MEMWINWrB Lib "C13W32.DLL" Alias "_C13_MEMWINWrB@16" (ByVal value As Integer, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MEMWINWrL Lib "C13W32.DLL" Alias "_C13_MEMWINWrL@16" (ByVal value As Long, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MEMWINWrsL Lib "C13W32.DLL" Alias "_C13_MEMWINWrsL@20" (ByRef valueptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MEMWINWrsW Lib "C13W32.DLL" Alias "_C13_MEMWINWrsW@20" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MEMWINWrW Lib "C13W32.DLL" Alias "_C13_MEMWINWrW@16" (ByVal value As Integer, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function C13_Mod Lib "C13W32.DLL" Alias "_C13_Mod@8" (ByVal moda As Long, ByVal modb As Long) As Long
Public Declare Function C13_ModeIsBC Lib "C13W32.DLL" Alias "_C13_ModeIsBC@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ModeIsMon Lib "C13W32.DLL" Alias "_C13_ModeIsMon@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ModeIsNotBC Lib "C13W32.DLL" Alias "_C13_ModeIsNotBC@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ModeIsNotMon Lib "C13W32.DLL" Alias "_C13_ModeIsNotMon@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ModeIsNotPlay Lib "C13W32.DLL" Alias "_C13_ModeIsNotPlay@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ModeIsNotRT Lib "C13W32.DLL" Alias "_C13_ModeIsNotRT@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ModeIsNotSerial Lib "C13W32.DLL" Alias "_C13_ModeIsNotSerial@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ModeIsPlay Lib "C13W32.DLL" Alias "_C13_ModeIsPlay@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ModeIsRT Lib "C13W32.DLL" Alias "_C13_ModeIsRT@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ModeIsSerial Lib "C13W32.DLL" Alias "_C13_ModeIsSerial@4" (ByVal handleval As Long) As Long
Public Declare Function C13_ModeRd Lib "C13W32.DLL" Alias "_C13_ModeRd@4" (ByVal handleval As Long) As Integer
Public Declare Function C13_ModeWr Lib "C13W32.DLL" Alias "_C13_ModeWr@8" (ByVal mode As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_MonClear Lib "C13W32.DLL" Alias "_C13_MonClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_MonConfigEx Lib "C13W32.DLL" Alias "_C13_MonConfigEx@16" (ByVal configval As Long, ByVal moncount As Long, ByVal cardnum As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_MonConfigExx Lib "C13W32.DLL" Alias "_C13_MonConfigExx@20" (ByVal configval As Long, ByVal seqaddr As Long, ByVal moncount As Long, ByVal cardnum As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_MonFilterSAEx Lib "C13W32.DLL" Alias "_C13_MonFilterSAEx@24" (ByVal taval As Long, ByVal rcvsamask As Long, ByVal xmtsamask As Long, ByVal rcvmcmask As Long, ByVal xmtmcmask As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MonRdEx Lib "C13W32.DLL" Alias "_C13_MonRdEx@12" (ByRef buf As Integer, ByVal bufcount As Integer, ByVal handleval As Long) As Integer
Public Declare Function C13_MonResume Lib "C13W32.DLL" Alias "_C13_MonResume@4" (ByVal handleval As Long) As Long
Public Declare Function C13_MonStart Lib "C13W32.DLL" Alias "_C13_MonStart@4" (ByVal handleval As Long) As Long
Public Declare Function C13_MonStatus Lib "C13W32.DLL" Alias "_C13_MonStatus@4" (ByVal handleval As Long) As Long
Public Declare Function C13_MonStop Lib "C13W32.DLL" Alias "_C13_MonStop@4" (ByVal handleval As Long) As Long
Public Declare Function C13_MsgBlockRd Lib "C13W32.DLL" Alias "_C13_MsgBlockRd@12" (ByRef buf As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgBlockWr Lib "C13W32.DLL" Alias "_C13_MsgBlockWr@12" (ByRef buf As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgCheck Lib "C13W32.DLL" Alias "_C13_MsgCheck@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_MsgCommRd Lib "C13W32.DLL" Alias "_C13_MsgCommRd@12" (ByRef buf As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgCommWr Lib "C13W32.DLL" Alias "_C13_MsgCommWr@12" (ByRef buf As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgConfig Lib "C13W32.DLL" Alias "_C13_MsgConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgConfigEx Lib "C13W32.DLL" Alias "_C13_MsgConfigEx@12" (ByVal configval As Long, ByVal cwd As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_MsgCWD1Rd Lib "C13W32.DLL" Alias "_C13_MsgCWD1Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_MsgCWD1Wr Lib "C13W32.DLL" Alias "_C13_MsgCWD1Wr@12" (ByVal cwd1 As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgCWD2Rd Lib "C13W32.DLL" Alias "_C13_MsgCWD2Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_MsgCWD2Wr Lib "C13W32.DLL" Alias "_C13_MsgCWD2Wr@12" (ByVal cwd2 As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgErrorRd Lib "C13W32.DLL" Alias "_C13_MsgErrorRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_MsgErrorWr Lib "C13W32.DLL" Alias "_C13_MsgErrorWr@12" (ByVal value As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgFlagRd Lib "C13W32.DLL" Alias "_C13_MsgFlagRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_MsgFlagWr Lib "C13W32.DLL" Alias "_C13_MsgFlagWr@12" (ByVal msgflag As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgIsAccessed Lib "C13W32.DLL" Alias "_C13_MsgIsAccessed@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgOptRd Lib "C13W32.DLL" Alias "_C13_MsgOptRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_MsgOptWr Lib "C13W32.DLL" Alias "_C13_MsgOptWr@12" (ByVal msgopt As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgReset Lib "C13W32.DLL" Alias "_C13_MsgReset@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_MsgSWD1Rd Lib "C13W32.DLL" Alias "_C13_MsgSWD1Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_MsgSWD2Rd Lib "C13W32.DLL" Alias "_C13_MsgSWD2Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_Mul Lib "C13W32.DLL" Alias "_C13_Mul@8" (ByVal mula As Long, ByVal mulb As Long) As Long
Public Declare Function C13_PlayClear Lib "C13W32.DLL" Alias "_C13_PlayClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_PlayConfigEx Lib "C13W32.DLL" Alias "_C13_PlayConfigEx@20" (ByVal configval As Long, ByVal playcount As Long, ByVal seqcount As Long, ByVal cardnum As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_PlayConfigExx Lib "C13W32.DLL" Alias "_C13_PlayConfigExx@28" (ByVal configval As Long, ByVal playaddr As Long, ByVal playcount As Long, ByVal seqaddr As Long, ByVal seqcount As Long, ByVal cardnum As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_PlayStatus Lib "C13W32.DLL" Alias "_C13_PlayStatus@4" (ByVal handleval As Long) As Long
Public Declare Function C13_PlayWrEx Lib "C13W32.DLL" Alias "_C13_PlayWrEx@12" (ByRef buf As Integer, ByVal bufcount As Integer, ByVal handleval As Long) As Integer
Public Declare Function C13_PortRd Lib "C13W32.DLL" Alias "_C13_PortRd@8" (ByVal addrval As Long, ByVal handleval As Long) As Byte
Public Declare Function C13_PortWr Lib "C13W32.DLL" Alias "_C13_PortWr@12" (ByVal value As Byte, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_ProgRdW Lib "C13W32.DLL" Alias "_C13_ProgRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function C13_ProgWrW Lib "C13W32.DLL" Alias "_C13_ProgWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_RAMFill Lib "C13W32.DLL" Alias "_C13_RAMFill@16" (ByVal value As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RAMRdB Lib "C13W32.DLL" Alias "_C13_RAMRdB@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_RAMRdL Lib "C13W32.DLL" Alias "_C13_RAMRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RAMRdsW Lib "C13W32.DLL" Alias "_C13_RAMRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RAMRdW Lib "C13W32.DLL" Alias "_C13_RAMRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_RAMWipe Lib "C13W32.DLL" Alias "_C13_RAMWipe@4" (ByVal handleval As Long) As Long
Public Declare Function C13_RAMWipeEx Lib "C13W32.DLL" Alias "_C13_RAMWipeEx@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_RAMWrB Lib "C13W32.DLL" Alias "_C13_RAMWrB@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RAMWrL Lib "C13W32.DLL" Alias "_C13_RAMWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RAMWrsW Lib "C13W32.DLL" Alias "_C13_RAMWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RAMWrW Lib "C13W32.DLL" Alias "_C13_RAMWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RTConfigEx Lib "C13W32.DLL" Alias "_C13_RTConfigEx@12" (ByVal configval As Long, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RTConfigExx Lib "C13W32.DLL" Alias "_C13_RTConfigExx@12" (ByVal configval As Long, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RTCreateListEx Lib "C13W32.DLL" Alias "_C13_RTCreateListEx@36" (ByVal listconfigval As Long, ByVal skipval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RTCreateListExx Lib "C13W32.DLL" Alias "_C13_RTCreateListExx@36" (ByVal listconfigval As Long, ByVal skipval As Long, ByVal count As Long, ByVal msgconfigval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RTReset Lib "C13W32.DLL" Alias "_C13_RTReset@8" (ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_RTStatus Lib "C13W32.DLL" Alias "_C13_RTStatus@8" (ByVal taval As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_RTSWDRd Lib "C13W32.DLL" Alias "_C13_RTSWDRd@8" (ByVal taval As Long, ByVal handleval As Long) As Integer
Public Declare Function C13_SchedBuild Lib "C13W32.DLL" Alias "_C13_SchedBuild@16" (ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef freq As Long, ByVal handleval As Long) As Long
Public Declare Function C13_SchedBuildEx Lib "C13W32.DLL" Alias "_C13_SchedBuildEx@28" (ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef freq As Long, ByRef period As Long, ByRef buf As Long, ByVal bufsize As Long, ByVal handleval As Long) As Long
Public Declare Function C13_SchedBuildExx Lib "C13W32.DLL" Alias "_C13_SchedBuildExx@28" (ByVal frametime As Long, ByVal nummsgs As Long, ByRef msgaddr As Long, ByRef period As Long, ByRef buf As Long, ByVal bufsize As Long, ByVal handleval As Long) As Long
Public Declare Function C13_SchedCalc Lib "C13W32.DLL" Alias "_C13_SchedCalc@8" (ByRef msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_SchedDisplay Lib "C13W32.DLL" Alias "_C13_SchedDisplay@8" (ByVal nummsgs As Long, ByRef count As Long) As Long
Public Declare Function C13_SchedHook Lib "C13W32.DLL" Alias "_C13_SchedHook@8" (ByVal index As Long, ByRef ptr As Long) As Long
Public Declare Function C13_SchedInsEnd Lib "C13W32.DLL" Alias "_C13_SchedInsEnd@4" (ByVal handleval As Long) As Long
Public Declare Function C13_SchedInsMsg Lib "C13W32.DLL" Alias "_C13_SchedInsMsg@12" (ByVal index As Long, ByRef msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function C13_SchedInsStart Lib "C13W32.DLL" Alias "_C13_SchedInsStart@12" (ByVal frametime As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function C13_SchedMaxval Lib "C13W32.DLL" Alias "_C13_SchedMaxval@8" (ByRef arrayval As Long, ByVal arrayvalcount As Long) As Long
Public Declare Function C13_SchedMinval Lib "C13W32.DLL" Alias "_C13_SchedMinval@8" (ByRef arrayval As Long, ByVal arrayvalcount As Long) As Long
Public Declare Function C13_SerialClear Lib "C13W32.DLL" Alias "_C13_SerialClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_SerialConfig Lib "C13W32.DLL" Alias "_C13_SerialConfig@12" (ByVal configval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_SerialConfigEx Lib "C13W32.DLL" Alias "_C13_SerialConfigEx@12" (ByVal configval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_SerialStatus Lib "C13W32.DLL" Alias "_C13_SerialStatus@4" (ByVal handleval As Long) As Long
Public Declare Function C13_SerialWr Lib "C13W32.DLL" Alias "_C13_SerialWr@8" (ByRef buf As Integer, ByVal handleval As Long) As Long
Public Declare Function C13_Shl Lib "C13W32.DLL" Alias "_C13_Shl@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function C13_Shr Lib "C13W32.DLL" Alias "_C13_Shr@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function C13_TimerClear Lib "C13W32.DLL" Alias "_C13_TimerClear@4" (ByVal handleval As Long) As Long
Public Declare Function C13_TimerRd Lib "C13W32.DLL" Alias "_C13_TimerRd@4" (ByVal handleval As Long) As Long
Public Declare Function C13_TimerResolution Lib "C13W32.DLL" Alias "_C13_TimerResolution@8" (ByVal timerresol As Long, ByVal handleval As Long) As Long
Public Declare Function C13_TimerResolutionEx Lib "C13W32.DLL" Alias "_C13_TimerResolutionEx@8" (ByVal timershift As Integer, ByVal handleval As Long) As Integer
Public Declare Function C13_ValFromAscii Lib "C13W32.DLL" Alias "_C13_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Long) As Long
Public Declare Function C13_ValGetBits Lib "C13W32.DLL" Alias "_C13_ValGetBits@12" (ByVal oldvalue As Integer, ByVal startbit As Long, ByVal endbit As Long) As Integer
Public Declare Function C13_ValPackRTCWD Lib "C13W32.DLL" Alias "_C13_ValPackRTCWD@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal count As Long) As Integer
Public Declare Function C13_ValPutBits Lib "C13W32.DLL" Alias "_C13_ValPutBits@16" (ByVal oldvalue As Integer, ByVal newfld As Integer, ByVal startbit As Long, ByVal endbit As Long) As Integer
Public Declare Function C13_ValToAscii Lib "C13W32.DLL" Alias "_C13_ValToAscii@16" (ByVal value As Long, ByRef asciistr As String, ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function C13_ValUnpackRTCWD Lib "C13W32.DLL" Alias "_C13_ValUnpackRTCWD@28" (ByVal cwd As Integer, ByRef bcastflag As Long, ByRef mcflag As Long, ByRef taval As Long, ByRef trflag As Long, ByRef saval As Long, ByRef count As Long) As Long
Public Declare Function C13_WatchConfig Lib "C13W32.DLL" Alias "_C13_WatchConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function C13_WatchWr Lib "C13W32.DLL" Alias "_C13_WatchWr@8" (ByVal secs As Long, ByVal handleval As Long) As Long
Public Declare Function C13_WatchWrEx Lib "C13W32.DLL" Alias "_C13_WatchWrEx@8" (ByVal value As Long, ByVal handleval As Long) As Long

'/**
'*
'*  Bus controller configuration options
'*
'**/

Public Const BCCFG_DEFAULT As Long = &H0 '//Select all default settings
Public Const BCCFG_ENABLE As Long = &H0  '//Enable bus controller (default)
Public Const BCCFG_DISABLE As Long = &H1 '//Disable bus controller
Public Const BCCFG_TRIGNONE As Long = &H0    '//No trigger (default)
Public Const BCCFG_TRIGEXT As Long = &H10 '//Trigger external
Public Const BCCFG_TRIGSTART As Long = &H20   '//Trigger external start
Public Const BCCFG_NOINTHALT As Long = &H0   '//Do not generate interrupt on halt (default)
Public Const BCCFG_INTHALT As Long = &H100 '//Generate interrupt on halt
Public Const BCCFG_NOINTPAUSE As Long = &H0  '//Do not generate interrupt on pause (default)
Public Const BCCFG_INTPAUSE As Long = &H200    '//Generate interrupt on pause
Public Const BCCFG_NOLOOPMAX As Long = &H0   '//Disable maximum loop count (default)
Public Const BCCFG_LOOPMAX As Long = &H1000 '//Enable maximum loop count
Public Const BCCFG_NOSTEP As Long = &H0  '//Disable single stepping (default)
Public Const BCCFG_STEP As Long = &H2000    '//Enable single stepping
Public Const BCCFG_MC01 As Long = &H0    '//Select SA=00000 or SA=11111 for mode codes (default)
Public Const BCCFG_MC1 As Long = &H1000000 '//Select SA=11111 for mode codes
Public Const BCCFG_MC0 As Long = &H2000000 '//Select SA=00000 for mode codes
Public Const BCCFG_MCNONE As Long = &H3000000  '//Disable mode codes
Public Const BCCFG_SYNCALL As Long = &H0 '//Sync on all messages (default)
Public Const BCCFG_SYNCSEL As Long = &H40000000 '//Selective sync
Public Const BCCFG_MODEL As Long = &H0   '//BC messages are created in static RAM (default)
Public Const BCCFG_RAM As Long = &H100000 '//BC messages are created in static RAM
Public Const BCCFG_DPRAM As Long = &H200000   '//BC messages are created in dual-port RAM

'/**
'*
'*  Monitor configuration options
'*
'**/

Public Const MONCFG_DEFAULT As Long = &H0    '//Select all default settings
Public Const MONCFG_FILLHALT As Long = &H0   '//Enable monitor in fill and halt mode (default)
Public Const MONCFG_DISABLE As Long = &H1    '//Disable monitor
Public Const MONCFG_CONTINUOUS As Long = &H2 '//Enable monitor in continuous mode
Public Const MONCFG_DMA As Long = &H4    '//Enable monitor in dma mode
Public Const MONCFG_FREE As Long = &H8   '//Enable monitor in free mode
Public Const MONCFG_FAST As Long = &H10   '//Enable monitor in fast mode
Public Const MONCFG_NOINTFULL As Long = &H0  '//Do not generate interrupt when monitor full (default)
Public Const MONCFG_INTFULL As Long = &H1000    '//Generate interrupt when monitor full
Public Const MONCFG_COMPLETE As Long = &H0   '//Enable receiving complete words (default)
Public Const MONCFG_INCOMPLETE As Long = &H2000 '//Enable receiving incomplete words
Public Const MONCFG_MC01 As Long = &H0   '//Select SA=00000 or SA=11111 for mode codes (default)
Public Const MONCFG_MC1 As Long = &H100000    '//Select SA=11111 for mode codes
Public Const MONCFG_MC0 As Long = &H200000    '//Select SA=00000 for mode codes
Public Const MONCFG_MCNONE As Long = &H300000 '//Disable mode codes
Public Const MONCFG_16K As Long = &H0    '//Allocate a 16K monitor buffer (default)
Public Const MONCFG_ALLAVAIL As Long = &H1000000   '//Allocate all available memory to monitor buffer
Public Const MONCFG_32K As Long = &H2000000    '//Allocate a 32K monitor buffer
Public Const MONCFG_64K As Long = &H4000000    '//Allocate a 64K monitor buffer
Public Const MONCFG_128K As Long = &H8000000   '//Allocate a 128K monitor buffer
Public Const MONCFG_DPRAM As Long = &H10000000  '//Allocate all available dual-port memory

'/**
'*
'*  Remote terminal configuration options
'*
'**/

Public Const RTCFG_DEFAULT As Long = &H0 '//Select all default settings
Public Const RTCFG_SIMULATE As Long = &H0    '//Enable RT simulation (default)
Public Const RTCFG_DISABLE As Long = &H1 '//Disable RT
Public Const RTCFG_MONITOR As Long = &H2 '//Enable RT monitor
Public Const RTCFG_NOBCAST As Long = &H0 '//Disable broadcast (default)
Public Const RTCFG_BCAST As Long = &H100   '//Enable broadcast
Public Const RTCFG_NOAUTOBUSY As Long = &H0  '//Disable auto busy (default)
Public Const RTCFG_AUTOBUSY As Long = &H200    '//Enable auto busy
Public Const RTCFG_BUILD As Long = &H0   '//Enable auto building (default)
Public Const RTCFG_NOBUILD As Long = &H400 '//Disable auto building
Public Const RTCFG_STDB As Long = &H0    '//Use MIL-STD-1553B standard (default)
Public Const RTCFG_STDA As Long = &H400000    '//Use MIL-STD-1553A standard
Public Const RTCFG_NODYNBC As Long = &H0 '//Do not respond to dynamic BC mode code (default)
Public Const RTCFG_DYNBC As Long = &H1000   '//Respond to dynamic BC mode code
Public Const RTCFG_NOIMMCLR As Long = &H0    '//Do not clear status word bits (default)
Public Const RTCFG_IMMCLR As Long = &H2000  '//Status word bits are cleared immediately
Public Const RTCFG_NOBCASTADDR As Long = &H0 '//Disable broadcast handling for address (default)
Public Const RTCFG_BCASTADDR As Long = &H4000   '//Enable broadcast handling for address
Public Const RTCFG_CHANAB As Long = &H0  '//Respond to both channels (default)
Public Const RTCFG_CHANA As Long = &H20000   '//Respond to channel A
Public Const RTCFG_CHANB As Long = &H10000   '//Respond to channel B
Public Const RTCFG_CHANNONE As Long = &H30000    '//Respond to neither channel A nor B
Public Const RTCFG_MC01 As Long = &H0    '//Select SA=00000 or SA=11111 for mode codes (default)
Public Const RTCFG_MC1 As Long = &H1000000 '//Select SA=11111 for mode codes
Public Const RTCFG_MC0 As Long = &H2000000 '//Select SA=00000 for mode codes
Public Const RTCFG_MCNONE As Long = &H3000000  '//Disable mode codes
Public Const RTCFG_SYNCALL As Long = &H0 '//Sync on all messages (default)
Public Const RTCFG_SYNCSEL As Long = &H40000000 '//Selective sync
Public Const RTCFG_WIPE As Long = &H0    '//Enables message clear (default)
Public Const RTCFG_NOWIPE As Long = &H80000000  '//Disables message clear
Public Const RTCFG_WIPE0 As Long = &H0   '//Initialize data with zeros (default)
Public Const RTCFG_WIPE123 As Long = &H4000000 '//Initialize data with incrementing values
Public Const RTCFG_WIPECWD As Long = &H8000000 '//Initialize data with command word
Public Const RTCFG_MODEL As Long = &H0   '//RT messages are created in static RAM (default)
Public Const RTCFG_RAM As Long = &H100000 '//RT messages are created in static RAM
Public Const RTCFG_DPRAM As Long = &H200000   '//RT messages are created in dual-port RAM
Public Const RTCFG_RESPONSEB As Long = &H0   '//RT responds using MIL-STD-1553B response time (default)
Public Const RTCFG_RESPONSEA As Long = &H400000   '//RT responds using MIL-STD-1553A response time

'/**
'*
'*  Serial configuration options
'*
'**/

Public Const SERCFG_DEFAULT As Long = &H0    '//Select all default settings
Public Const SERCFG_CONTINUOUS As Long = &H0 '//Enable continuous mode (default)
Public Const SERCFG_DISABLE As Long = &H1    '//Disable free mode
Public Const SERCFG_FREE As Long = &H2   '//Enable free mode
Public Const SERCFG_NOINTEMPTY As Long = &H0 '//Do not generate interrupt when empty (default)
Public Const SERCFG_INTEMPTY As Long = &H10   '//Generate interrupt when empty

'/**
'*
'*  Watchdog configuration options
'*
'**/

Public Const WATCHCFG_DEFAULT As Long = &H0  '//Select all default settings
Public Const WATCHCFG_ENABLE As Long = &H0   '//Enable watchdog timer (default)
Public Const WATCHCFG_DISABLE As Long = &H1  '//Disable watchdog timer

'/**
'*
'*  Playback configuration options
'*
'**/

Public Const PLAYCFG_DEFAULT As Long = &H0   '//Select all default settings
Public Const PLAYCFG_ENABLE As Long = &H0    '//Enable playback (default)
Public Const PLAYCFG_DISABLE As Long = &H1   '//Disable playback
Public Const PLAYCFG_16K As Long = &H0   '//Allocate a 16K playback buffer (default)
Public Const PLAYCFG_ALLAVAIL As Long = &H8000  '//Allocate all available memory to playback buffer
Public Const PLAYCFG_32K As Long = &H10000   '//Allocate a 32K playback buffer
Public Const PLAYCFG_64K As Long = &H20000   '//Allocate a 64K playback buffer
Public Const PLAYCFG_128K As Long = &H40000  '//Allocate a 128K playback buffer
Public Const PLAYCFG_DPRAM As Long = &H80000 '//Allocate all available dual-port memory

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

Public Const INFOTYPE_PLAT As Integer = &H1  '//Returns the C13 platform type
Public Const INFOTYPE_PROD As Integer = &H2  '//Returns the C13 product type
Public Const INFOTYPE_DASH As Integer = &H3  '//Returns the C13 dash number
Public Const INFOTYPE_VERSION As Integer = &H4   '//Returns the C13 version number
Public Const INFOTYPE_DATE As Integer = &H5  '//Returns the C13 version date
Public Const INFOTYPE_MODEL As Integer = &H6 '//Returns the C13 model number
Public Const INFOTYPE_MAXCOUNT As Integer = &H7  '//Returns the number of terminals the C13 can simulate
Public Const INFOTYPE_MULTIMODE As Integer = &H8 '//Returns whether C13 can simulate multi-modes
Public Const INFOTYPE_ERRORGEN As Integer = &H9  '//Returns whether C13 can generate errors
Public Const INFOTYPE_CONCURMON As Integer = &HA '//Returns whether C13 has a concurrent monitor
Public Const INFOTYPE_MONFILTER As Integer = &HB '//Returns whether C13 has a monitor filter
Public Const INFOTYPE_USERCODE As Integer = &HC  '//Returns whether C13 handles user code
Public Const INFOTYPE_LISTBUF As Integer = &HD   '//Returns whether C13 handles list buffering
Public Const INFOTYPE_MONFAST As Integer = &HE   '//Returns whether C13 has a fast monitor
Public Const INFOTYPE_MONDMA As Integer = &HF    '//Returns whether C13 has a dma monitor
Public Const INFOTYPE_MONBRAKE As Integer = &H10  '//Returns whether C13 has a monitor brake
Public Const INFOTYPE_PLAY As Integer = &H11  '//Returns whether C13 has playback capability
Public Const INFOTYPE_WATCH As Integer = &H12 '//Returns whether C13 has a watchdog
Public Const INFOTYPE_RESPONSEA As Integer = &H13 '//Returns whether C13 can do MIL-STD-1553A response time

'/**
'*
'*  Error configuration options
'*
'**/

Public Const ERRDEF_NONE As Long = &H0   '//Disable error generation (default)
Public Const ERRDEF_GAP As Long = &H10000    '//Generate zero crossing error
Public Const ERRDEF_CNTWRDABS As Long = &H20000  '//Generate an absolute word count error
Public Const ERRDEF_CNTWRDREL As Long = &H40000  '//Generate a relative count error
Public Const ERRDEF_CNTBIT As Long = &H80000 '//Generate a bit count error
Public Const ERRDEF_MAN1 As Long = &H100000   '//Generate manchester error on first half of bit
Public Const ERRDEF_MAN2 As Long = &H200000   '//Generate manchester error on second half of bit
Public Const ERRDEF_SYNC As Long = &H400000   '//Generate a sync error
Public Const ERRDEF_PAR As Long = &H800000    '//Generate a parity error
Public Const ERRDEF_ZEROX As Long = &H1000000  '//Generate zero crossing error

Public Const ERRDEF_DWD00 As Integer = &H0   '//Error will be generated in a data word  0
Public Const ERRDEF_DWD01 As Integer = &H1   '//Error will be generated in a data word  1
Public Const ERRDEF_DWD02 As Integer = &H2   '//Error will be generated in a data word  2
Public Const ERRDEF_DWD03 As Integer = &H3   '//Error will be generated in a data word  3
Public Const ERRDEF_DWD04 As Integer = &H4   '//Error will be generated in a data word  4
Public Const ERRDEF_DWD05 As Integer = &H5   '//Error will be generated in a data word  5
Public Const ERRDEF_DWD06 As Integer = &H6   '//Error will be generated in a data word  6
Public Const ERRDEF_DWD07 As Integer = &H7   '//Error will be generated in a data word  7
Public Const ERRDEF_DWD08 As Integer = &H8   '//Error will be generated in a data word  8
Public Const ERRDEF_DWD09 As Integer = &H9   '//Error will be generated in a data word  9
Public Const ERRDEF_DWD10 As Integer = &HA   '//Error will be generated in a data word 10
Public Const ERRDEF_DWD11 As Integer = &HB   '//Error will be generated in a data word 11
Public Const ERRDEF_DWD12 As Integer = &HC   '//Error will be generated in a data word 12
Public Const ERRDEF_DWD13 As Integer = &HD   '//Error will be generated in a data word 13
Public Const ERRDEF_DWD14 As Integer = &HE   '//Error will be generated in a data word 14
Public Const ERRDEF_DWD15 As Integer = &HF   '//Error will be generated in a data word 15
Public Const ERRDEF_DWD16 As Integer = &H10   '//Error will be generated in a data word 16
Public Const ERRDEF_DWD17 As Integer = &H11   '//Error will be generated in a data word 17
Public Const ERRDEF_DWD18 As Integer = &H12   '//Error will be generated in a data word 18
Public Const ERRDEF_DWD19 As Integer = &H13   '//Error will be generated in a data word 19
Public Const ERRDEF_DWD20 As Integer = &H14   '//Error will be generated in a data word 20
Public Const ERRDEF_DWD21 As Integer = &H15   '//Error will be generated in a data word 21
Public Const ERRDEF_DWD22 As Integer = &H16   '//Error will be generated in a data word 22
Public Const ERRDEF_DWD23 As Integer = &H17   '//Error will be generated in a data word 23
Public Const ERRDEF_DWD24 As Integer = &H18   '//Error will be generated in a data word 24
Public Const ERRDEF_DWD25 As Integer = &H19   '//Error will be generated in a data word 25
Public Const ERRDEF_DWD26 As Integer = &H1A   '//Error will be generated in a data word 26
Public Const ERRDEF_DWD27 As Integer = &H1B   '//Error will be generated in a data word 27
Public Const ERRDEF_DWD28 As Integer = &H1C   '//Error will be generated in a data word 28
Public Const ERRDEF_DWD29 As Integer = &H1D   '//Error will be generated in a data word 29
Public Const ERRDEF_DWD30 As Integer = &H1E   '//Error will be generated in a data word 30
Public Const ERRDEF_DWD31 As Integer = &H1F   '//Error will be generated in a data word 31
Public Const ERRDEF_CWD1 As Integer = &H100    '//Error will be generated in CWD1
Public Const ERRDEF_CWD2 As Integer = &H101    '//Error will be generated in CWD2
Public Const ERRDEF_SWD As Integer = &H102 '//Error will be generated in SWD1
Public Const ERRDEF_SWD1 As Integer = &H102    '//Error will be generated in SWD1
Public Const ERRDEF_SWD2 As Integer = &H102    '//Error will be generated in SWD2

'/**
'*
'*  Error control options
'*
'**/

Public Const ERRCTRL_OFF As Long = &H0   '//Disable error generation
Public Const ERRCTRL_ON As Long = &H1    '//Enable error generation
Public Const ERRCTRL_ONCE As Long = &H2  '//Enable error generation once
Public Const ERRCTRL_EXTERNAL As Long = &H3  '//Enable externally triggered error generation
Public Const ERRCTRL_TAGMSG As Long = &H0    '//Generate errors on tagged messages
Public Const ERRCTRL_ANYMSG As Long = &H80000000    '//Generate errors on any message

'/**
'*
'*  Message configuration options
'*
'**/

Public Const MSGCRT_DEFAULT As Long = &H0    '//Default settings
Public Const MSGCRT_ENABLE As Long = &H0 '//Enable subaddress (RT) (default)
Public Const MSGCRT_DISABLE As Long = &H1000    '//Disable subaddress (RT)
Public Const MSGCRT_RESP As Long = &H0   '//Enable response (RT) (default)
Public Const MSGCRT_NORESP As Long = &H2000 '//Disable response (RT)
Public Const MSGCRT_NOWRAP As Long = &H0 '//Disable data wrap (RT) (default)
Public Const MSGCRT_WRAP As Long = &H4000   '//Enable data wrap (RT)
Public Const MSGCRT_NOINT As Long = &H0  '//Message will generate interrupt (default)
Public Const MSGCRT_INT As Long = &H1    '//Message will not generate interrupt
Public Const MSGCRT_NOERR As Long = &H0  '//No message error will be generated for message (default)
Public Const MSGCRT_ERR As Long = &H2    '//A message error will be generated for message
Public Const MSGCRT_BUSA As Long = &H0   '//Message will be transmitted on bus A (BC) (default)
Public Const MSGCRT_BUSB As Long = &H4   '//Message will be transmitted on bus B (BC)
Public Const MSGCRT_BCRT As Long = &H0   '//Message is a BC-RT transfer (BC) (default)
Public Const MSGCRT_RTRT As Long = &H8   '//Message is an RT-RT transfer (BC)
Public Const MSGCRT_NOMON As Long = &H0  '//Message will not be monitored (default)
Public Const MSGCRT_MON As Long = &H10    '//Message will be monitored
Public Const MSGCRT_NOTIMETAG As Long = &H0  '//Message will not record time-tag (default)
Public Const MSGCRT_TIMETAG As Long = &H40    '//Message will record time-tag
Public Const MSGCRT_NOELAPSE As Long = &H0   '//Message will not record elapse time (default)
Public Const MSGCRT_ELAPSE As Long = &H80 '//Message will record elapse time
Public Const MSGCRT_NOMIN As Long = &H0  '//Message will not record min time (default)
Public Const MSGCRT_MIN As Long = &H100    '//Message will record min time
Public Const MSGCRT_NOMAX As Long = &H0  '//Message will not record max time (default)
Public Const MSGCRT_MAX As Long = &H200    '//Message will record max time
Public Const MSGCRT_NOHIT As Long = &H0  '//Message will not record hit count (default)
Public Const MSGCRT_HIT As Long = &H400    '//Message will record hit count
Public Const MSGCRT_NOSYNC As Long = &H0 '//No sync will be generated for message (default)
Public Const MSGCRT_SYNC As Long = &H40000000   '//Sync will be generated for message
Public Const MSGCRT_WIPE As Long = &H0   '//Enables message clear (default)
Public Const MSGCRT_NOWIPE As Long = &H80000000 '//Disables message clear
Public Const MSGCRT_WIPE0 As Long = &H0  '//Initialize data with zeros (default)
Public Const MSGCRT_WIPE123 As Long = &H1000000    '//Initialize data with incrementing values
Public Const MSGCRT_WIPECWD As Long = &H2000000    '//Initialize data with command word
Public Const MSGCRT_MODEL As Long = &H0  '//Message located in static RAM (default)
Public Const MSGCRT_RAM As Long = &H100000    '//Message located in static RAM
Public Const MSGCRT_DPRAM As Long = &H200000  '//Message located in dual-port RAM

'/**
'*
'*  List buffer options
'*
'**/

Public Const LISTCRT_DEFAULT As Long = &H0   '//Select all default settings
Public Const LISTCRT_PINGPONG As Long = &H0  '//Enable ping-pong mode (default)
Public Const LISTCRT_FIFO As Long = &H1  '//Enable FIFO mode
Public Const LISTCRT_CIRCULAR As Long = &H2  '//Enable circular mode
Public Const LISTCRT_TRBIT As Long = &H0 '//User will read or write depending upon T/R bit
Public Const LISTCRT_READ As Long = &H10  '//User will read from list buffer
Public Const LISTCRT_WRITE As Long = &H20 '//User will write to list buffer
Public Const LISTCRT_NOTSKIP As Long = &H0   '//Will not skip messages
Public Const LISTCRT_SKIP As Long = &H40  '//Enable message skipping
Public Const LISTCRT_NOINT As Long = &H0 '//Do not generate interrupt when list buffer empty/full (default)
Public Const LISTCRT_INT As Long = &H100   '//Generate interrupt when list buffer empty/full
Public Const LISTCRT_NOHIT As Long = &H0 '//Do not generate interrupt when list is hit (default)
Public Const LISTCRT_HIT As Long = &H200   '//Generate interrupt when list is hit
Public Const LISTCRT_MODEL As Long = &H0 '//List located in static RAM (default)
Public Const LISTCRT_RAM As Long = &H100000   '//List located in static RAM
Public Const LISTCRT_DPRAM As Long = &H200000 '//List located in dual-port RAM

'/**
'*
'*  Bit fields of the message error flag
'*
'**/

Public Const MSGERR_NORESP As Integer = &H8000  '//Set when we timeout waiting for response
Public Const MSGERR_ANYERR As Integer = &H4000  '//Set when any error bit is set
Public Const MSGERR_PROTOCOL As Integer = &H2000    '//General protocol error
Public Const MSGERR_SYNC As Integer = &H1000    '//Set when we have the wrong sync
Public Const MSGERR_DATACOUNT As Integer = &H800   '//Set when improper number of data words
Public Const MSGERR_MANCH As Integer = &H20   '//Set when manchester error detected
Public Const MSGERR_PARITY As Integer = &H10  '//Set when parity error detected
Public Const MSGERR_WORD As Integer = &H8    '//Set when word error detected
Public Const MSGERR_RETRY As Integer = &H4   '//All retries failed
Public Const MSGERR_SYSTEM As Integer = &H2  '//An internal system error occurred
Public Const MSGERR_HIT As Integer = &H1 '//Always set

'/**
'*
'*  Bit fields of the message activity flag.
'*
'**/

Public Const MSGACT_XMTCWD1 As Integer = &H8000 '//Transmitted CWD1
Public Const MSGACT_XMTCWD2 As Integer = &H4000 '//Transmitted CWD2
Public Const MSGACT_XMTSWD1 As Integer = &H2000 '//Transmitted SWD1
Public Const MSGACT_XMTSWD2 As Integer = &H1000 '//Transmitted SWD2
Public Const MSGACT_RCVCWD1 As Integer = &H800 '//Received CWD1
Public Const MSGACT_RCVCWD2 As Integer = &H400 '//Received CWD2
Public Const MSGACT_RCVSWD1 As Integer = &H200 '//Received SWD1
Public Const MSGACT_RCVSWD2 As Integer = &H100 '//Received SWD2
Public Const MSGACT_XMTDWD As Integer = &H80  '//Transmitted DWD
Public Const MSGACT_RCVDWD As Integer = &H40  '//Received DWD

'/**
'*
'*  Condition flags.
'*
'**/

Public Const COND_FAIL As Integer = &H1  '//Condition when all retries have failed
Public Const COND_SRQ As Integer = &H2   '//Condition on Service Request bit set in status word
Public Const COND_INS As Integer = &H4   '//Condition on Instrumentation bit set in status word
Public Const COND_SSF As Integer = &H8   '//Condition on Subsystem Fail bit set in status word
Public Const COND_TF As Integer = &H10    '//Condition on Terminal Flag bit set in status word
Public Const COND_BUSY As Integer = &H20  '//Condition on Busy bit set in status word
Public Const COND_ME As Integer = &H40    '//Condition on Message Error bit set in status word
Public Const COND_RESPERR As Integer = &H80   '//Condition on response error
Public Const COND_NORESP As Integer = &H100    '//Condition on response error
Public Const COND_ALTBUS As Integer = &H200    '//Retries are performed on alternate bus

'/**
'*
'*  Field types.
'*
'**/

Public Const FIELD_CWD1 As Integer = 0  '//CWD1 field
Public Const FIELD_CWD2 As Integer = 1  '//CWD2 field
Public Const FIELD_SWD1 As Integer = 2  '//SWD1 field
Public Const FIELD_SWD2 As Integer = 3  '//SWD2 field
Public Const FIELD_TTAG As Integer = 4  '//Time tag field
Public Const FIELD_ELAPSE As Integer = 5    '//Elapse time field
Public Const FIELD_ERROR As Integer = 6 '//Error field
Public Const FIELD_ACT As Integer = 7   '//Activity field
Public Const FIELD_RESP1 As Integer = 8 '//Response time 1 field
Public Const FIELD_RESP2 As Integer = 9 '//Response time 2 field
Public Const FIELD_COUNT As Integer = 10    '//Data count field
Public Const FIELD_FLAG1 As Integer = 11    '//Flag 1 field
Public Const FIELD_FLAG2 As Integer = 12    '//Flag 2 field
Public Const FIELD_RESV As Integer = 13 '//Reserved field

'/**
'*
'*  Interrupt types.
'*
'**/

Public Const INTTYPE_MSG As Integer = &H1    '//Message interrupt
Public Const INTTYPE_OPCODE As Integer = &H2 '//Interrupt opcode
Public Const INTTYPE_HALT As Integer = &H3   '//Schedule halt
Public Const INTTYPE_PAUSE As Integer = &H4  '//Schedule pause
Public Const INTTYPE_SEQ As Integer = &H5    '//Sequential record full
Public Const INTTYPE_LIST As Integer = &H6   '//List buffer empty/full
Public Const INTTYPE_PARITY As Integer = &H7 '//Parity error
Public Const INTTYPE_DIN As Integer = &H8    '//DIN
Public Const INTTYPE_SERIAL As Integer = &H9 '//Serial empty

'/**
'*
'*  Timer resolutions.
'*
'**/

Public Const TIMERRESOL_1US As Integer = 1  '//1us timer resolution, 1:11:34
Public Const TIMERRESOL_16US As Integer = 2 '//16us timer resolution, 19:05:19 range
Public Const TIMERRESOL_1024US As Integer = 3   '//1024us timer resolution, 50 day range

'/**
'*
'*  C13 HOST Registers
'*
'**/

Public Const HREG_STAT As Integer = &H0  '//Status register (RD)
Public Const HREG_SET As Integer = &H1   '//Set register (WR)
Public Const HREG_CLR As Integer = &H2   '//Clear register (WR)
Public Const HREG_DCFG As Integer = &H3  '//DSP configuration register (RD/WR)
Public Const HREG_HCFG As Integer = &H4  '//HOST configuration register (RD/WR)
Public Const HREG_RESV As Integer = &H5  '//Reserved register
Public Const HREG_PAGE As Integer = &H6  '//Page register (RD/WR)
Public Const HREG_ERR As Integer = &H7   '//Error register (RD)
Public Const HREG_HPCL As Integer = &H8  '//Host port control low (RD/WR)
Public Const HREG_HPCH As Integer = &H9  '//Host port control high (RD/WR)
Public Const HREG_HPIL As Integer = &HA  '//Host port incrementer low (RD/WR)
Public Const HREG_HPIH As Integer = &HB  '//Host port incrementer high (RD/WR)
Public Const HREG_HPAL As Integer = &HC  '//Host port address low (RD/WR)
Public Const HREG_HPAH As Integer = &HD  '//Host port address high (RD/WR)
Public Const HREG_HPDL As Integer = &HE  '//Host port data low (RD/WR)
Public Const HREG_HPDH As Integer = &HF  '//Host port data high (RD/WR)

'/**
'*
'*  C13 IFGA Registers
'*
'**/

Public Const IREG_STAT As Integer = &H20  '//Status register
Public Const IREG_SET As Integer = &H21   '//Set register
Public Const IREG_CLR As Integer = &H22   '//Clear register
Public Const IREG_RESV As Integer = &H23  '//Reserved register
Public Const IREG_PAGE As Integer = &H24  '//Page register
Public Const IREG_IOCFG As Integer = &H25 '//I/O configuration register
Public Const IREG_DMA As Integer = &H26   '//DMA register

'/**
'*
'*  C13 EDGA Registers
'*
'**/

Public Const EREG_STAT As Integer = &H0  '//Status register (RD)
Public Const EREG_STATCLR As Integer = &H1   '//Status clear register (WR)
Public Const EREG_STATDEC As Integer = &H2   '//Decoder status register (RD)
Public Const EREG_VALA As Integer = &H4  '//Decoder word value A register
Public Const EREG_VALAL As Integer = &H4 '//Decoder low word value A register
Public Const EREG_VALAH As Integer = &H5 '//Decoder high word value A register
Public Const EREG_VALB As Integer = &H6  '//Decoder word value B register
Public Const EREG_VALBL As Integer = &H6 '//Decoder low word value B register
Public Const EREG_VALBH As Integer = &H7 '//Decoder high word value B register
Public Const EREG_GAPE As Integer = &H8  '//Encoder gap register
Public Const EREG_CTRLE As Integer = &H9 '//Encoder control register
Public Const EREG_VALE As Integer = &HA  '//Encoder value register
Public Const EREG_VALEL As Integer = &HA '//Encoder low value register
Public Const EREG_VALEH As Integer = &HB '//Encoder high value register
Public Const EREG_ERRE As Integer = &HC  '//Encoder error register
Public Const EREG_FT As Integer = &HE    '//Frame time register
Public Const EREG_RST As Integer = &HF   '//Reset register
Public Const EREG_GAPA As Integer = &H10  '//Decoder gap time A register
Public Const EREG_GAPB As Integer = &H11  '//Decoder gap time B register
Public Const EREG_GAPTO As Integer = &H12 '//Decoder gap timeout register
Public Const EREG_CFGD As Integer = &H14  '//Decoder configuration register
Public Const EREG_CFGE As Integer = &H15  '//Encoder configuration register
Public Const EREG_CFGINT As Integer = &H16    '//Interrupt configuration register
Public Const EREG_ID As Integer = &H17    '//Identification register

'/**
'*
'*  C13 Global Registers
'*
'**/

Public Const GREG_IMR As Integer = &H0   '//Interrupt mask register
Public Const GREG_IFR As Integer = &H1   '//Interrupt flag register
Public Const GREG_ST0 As Integer = &H6   '//Status register 0
Public Const GREG_ST1 As Integer = &H7   '//Status register 1
Public Const GREG_AL As Integer = &H8    '//Accumulator A low word (bits 15-00)
Public Const GREG_AH As Integer = &H9    '//Accumulator A high word (bits 31-16)
Public Const GREG_AG As Integer = &HA    '//Accumulator A guars bits (bits 39-32)
Public Const GREG_BL As Integer = &HB    '//Accumulator B low word (bits 15-00)
Public Const GREG_BH As Integer = &HC    '//Accumulator B high word (bits 31-16)
Public Const GREG_BG As Integer = &HD    '//Accumulator B guard bits (bits 39-32
Public Const GREG_T As Integer = &HE '//Temporary register
Public Const GREG_TRN As Integer = &HF   '//Transition register
Public Const GREG_AR0 As Integer = &H10   '//Auxilliary register 0
Public Const GREG_AR1 As Integer = &H11   '//Auxilliary register 1
Public Const GREG_AR2 As Integer = &H12   '//Auxilliary register 2
Public Const GREG_AR3 As Integer = &H13   '//Auxilliary register 3
Public Const GREG_AR4 As Integer = &H14   '//Auxilliary register 4
Public Const GREG_AR5 As Integer = &H15   '//Auxilliary register 5
Public Const GREG_AR6 As Integer = &H16   '//Auxilliary register 6
Public Const GREG_AR7 As Integer = &H17   '//Auxilliary register 7
Public Const GREG_SP As Integer = &H18    '//Stack pointer
Public Const GREG_BK As Integer = &H19    '//Circular-buffer size register
Public Const GREG_BRC As Integer = &H1A   '//Block-repeat counter
Public Const GREG_RSA As Integer = &H1B   '//Block-repeat start address
Public Const GREG_REA As Integer = &H1C   '//Block-repeat end address
Public Const GREG_PMST As Integer = &H1D  '//Processor mode status register
Public Const GREG_XPC As Integer = &H1E   '//Program counter extension register
Public Const GREG_BDRR0 As Integer = &H20 '//Buffered serial port 0 data receive register
Public Const GREG_BDXR0 As Integer = &H21 '//Buffered serial port 0 data transmit register
Public Const GREG_BSPC0 As Integer = &H22 '//Buffered serial port 0 control register
Public Const GREG_BSPEC0 As Integer = &H23    '//Buffered serial port 0 control extension register
Public Const GREG_TIM As Integer = &H24   '//Timer count register
Public Const GREG_PRD As Integer = &H25   '//Timer period register
Public Const GREG_TCR As Integer = &H26   '//Timer control register
Public Const GREG_SWWSR As Integer = &H28 '//External interface software wait-state register
Public Const GREG_BSCR As Integer = &H29  '//External interface bank-switching control register
Public Const GREG_XSWR As Integer = &H2B  '//Extended software wait-state register
Public Const GREG_HPIC As Integer = &H2C  '//Host port interface control register
Public Const GREG_TRCV As Integer = &H30  '//TDM serial port data receive register
Public Const GREG_TDXR As Integer = &H31  '//TDM serial port data transmit register
Public Const GREG_TSPC As Integer = &H32  '//TDM serial port control register
Public Const GREG_TCSR As Integer = &H33  '//TDM serial port channel select register
Public Const GREG_TRTA As Integer = &H34  '//TDM serial port receive transmit register
Public Const GREG_TRAD As Integer = &H35  '//TDM serial port receive address register
Public Const GREG_AXR0 As Integer = &H38  '//ABU 0 transmit address register
Public Const GREG_BKX0 As Integer = &H39  '//ABU 0 transmit buffer-size register
Public Const GREG_ARR0 As Integer = &H3A  '//ABU 0 receive address register
Public Const GREG_BKR0 As Integer = &H3B  '//ABU 0 receive buffer-size register
Public Const GREG_AXR1 As Integer = &H3C  '//ABU 1 transmit address register
Public Const GREG_BKX1 As Integer = &H3D  '//ABU 1 transmit buffer-size register
Public Const GREG_ARR1 As Integer = &H3E  '//ABU 1 receive address register
Public Const GREG_BKR1 As Integer = &H3F  '//ABU 1 receive buffer-size register
Public Const GREG_BDRR1 As Integer = &H40 '//Buffered serial port 1 data receive register
Public Const GREG_BDXR1 As Integer = &H41 '//Buffered serial port 1 data transmit register
Public Const GREG_BSPC1 As Integer = &H42 '//Buffered serial port 1 control register
Public Const GREG_BSPCE1 As Integer = &H43    '//Buffered serial port 1 extension register
Public Const GREG_CLKMD As Integer = &H58 '//Clock-mode register

Public Const MONRD_MAX_COUNT As Integer = 64

Public Const SUBADDRESS As Integer = 0
Public Const MODECODE As Integer = 1

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
Public Const ERR_NOCS As Integer = -3   '//Card Services is not present
Public Const ERR_NOSOCKET As Integer = -4   '//The specified socket is not present
Public Const ERR_CS As Integer = -5 '//A bad version was encountered
Public Const ERR_NOTSR As Integer = -6  '//Unable to find the CM1553-3 memory resident driver
Public Const ERR_CLIENT As Integer = -7 '//Unable to install a local client driver
Public Const ERR_WIN As Integer = -8    '//Card Services could not configure the memory window, I/O window, or IRQ steering
Public Const ERR_BADPARAMS As Integer = -11 '//CardOpen() called with bad parameters
Public Const ERR_NOHANDLES As Integer = -12 '//CardOpen() already has allocated too many handles
Public Const ERR_NOCARD As Integer = -13    '//CardOpen() could not find a C13 card at the specified address
Public Const ERR_NOIO As Integer = -14  '//CardOpen() could not find the I/O ports
Public Const ERR_NOMEM As Integer = -15 '//CardOpen() could not find the memory
Public Const ERR_BAD16BIT As Integer = -16  '//Card is conflicting with another 16-bit card
Public Const ERR_WRONGMODEL As Integer = -17    '//Card does not support this feature
Public Const ERR_NOSEL As Integer = -18 '//CardOpen() could not allocate a memory selector
Public Const ERR_LOCK As Integer = -19  '//The communication process is locked up
Public Const ERR_TOOMANY As Integer = -20   '//Too many terminals have been configured
Public Const ERR_BADHANDLE As Integer = -21 '//A bad handle was specified
Public Const ERR_BADTA As Integer = -22 '//A bad terminal address was specified
Public Const ERR_BADFRAME As Integer = -23  '//A bad frame time was specified
Public Const ERR_NOTBC As Integer = -24 '//The BC has not been configured
Public Const ERR_NOTRT As Integer = -25 '//The RT has not been configured
Public Const ERR_NOTMON As Integer = -26    '//The monitor has not been configured
Public Const ERR_ALLOC As Integer = -27 '//There is not enough memory to allocate
Public Const ERR_VXD As Integer = -28   '//An error occurred in the VXD
Public Const ERR_BADMSG As Integer = -31    '//The specified command block is not a message block
Public Const ERR_BADSCHNDX As Integer = -32 '//Specified command index is out of range
Public Const ERR_BUFSIZE As Integer = -33   '//Insufficient space in user buffer
Public Const ERR_NOCONFIG As Integer = -34  '//The card has not been properly configured
Public Const ERR_BOOTFULL As Integer = -41  '//No space to add boot code
Public Const ERR_BOOTNUM As Integer = -42   '//There is no boot code with the specified number
Public Const ERR_ROMVERIFY As Integer = -44 '//Unable to verify the value written to the ROM
Public Const ERR_COUNT As Integer = -45 '//An invalid count was specified
Public Const ERR_CRC As Integer = -46   '//There was a bad checksum in the HEX file
Public Const ERR_FNAME As Integer = -47 '//Bad filenames were specified
Public Const ERR_FRDWR As Integer = -48 '//There was an error reading or writing the HEX file
Public Const ERR_HEX As Integer = -49   '//There was a bad hex character in the HEX file
Public Const ERR_INDEX As Integer = -51 '//The command block index was invalid or the schedule is full
Public Const ERR_NOMSGS As Integer = -52    '//No messages specified
Public Const ERR_RESPONSE As Integer = -53  '//A bad response or no response was received from an RT
Public Const ERR_TYPE As Integer = -54  '//There was a bad type value in the HEX file
Public Const ERR_ZEROLEN As Integer = -55   '//Zero length was specified
Public Const ERR_DMABAD As Integer = -61    '//Bad DMA channel was specified
Public Const ERR_DMAODD As Integer = -62    '//An odd DMA address or count was specified
Public Const ERR_DMAPAGE As Integer = -63   '//DMA buffer specified crosses a page boundary
Public Const ERR_SELFIOFAIL As Integer = -71    '//I/O selftest failed
Public Const ERR_SELFMEMFAIL As Integer = -72   '//Memory selftest failed
Public Const ERR_SELFCOMMFAIL As Integer = -73  '//Communication selftest failed
Public Const ERR_SELFXMTFAIL As Integer = -74   '//Transmit selftest failed
Public Const ERR_CISVERIFY As Integer = -90 '//Unable to verify the value written to the CIS
Public Const ERR_CISNONE As Integer = -91   '//The CIS is not visible
