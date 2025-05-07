'/**
'*
'*  PC1553-3 WIN32 DRIVER  Version 1.4  (02/20/1998)
'*  Copyright (c) 1998
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   P13W32.BAS -- 32-bit
'*                      PC1553-3 Driver Include Header File.
'*
'**/

'/**
'*
'*  Structs used by the PC1553-3 Driver.
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
'*  PC1553-3 Driver functions.
'*
'**/

'/**
'*
'*  Internal functions used by the PC1553-3 Driver.
'*
'**/

Public Declare Function P13_BCConfig Lib "P13W32.DLL" Alias "_P13_BCConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCCreateMsg Lib "P13W32.DLL" Alias "_P13_BCCreateMsg@20" (ByVal configval As Long, ByVal cwd1 As Integer, ByVal cwd2 As Integer, ByRef data As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedFrame Lib "P13W32.DLL" Alias "_P13_BCSchedFrame@8" (ByVal timeval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedMsg Lib "P13W32.DLL" Alias "_P13_BCSchedMsg@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedRetry Lib "P13W32.DLL" Alias "_P13_BCSchedRetry@12" (ByVal condition As Integer, ByVal retries As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_BCTransmitMsg Lib "P13W32.DLL" Alias "_P13_BCTransmitMsg@8" (ByRef xmitfieldsval As XMITFIELDS, ByVal handleval As Long) As Long
Public Declare Function P13_CardClose Lib "P13W32.DLL" Alias "_P13_CardClose@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardOpen Lib "P13W32.DLL" Alias "_P13_CardOpen@16" (ByVal memval As Long, ByVal ioval As Integer, ByVal irqval As Integer, ByVal drqval As Integer) As Long
Public Declare Function P13_CardOpenP12 Lib "P13W32.DLL" Alias "_P13_CardOpenP12@16" (ByVal memval As Long, ByVal ioval As Integer, ByVal irqval As Integer, ByVal drqval As Integer) As Long
Public Declare Function P13_CardReset Lib "P13W32.DLL" Alias "_P13_CardReset@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardStart Lib "P13W32.DLL" Alias "_P13_CardStart@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardStop Lib "P13W32.DLL" Alias "_P13_CardStop@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ErrorCtrl Lib "P13W32.DLL" Alias "_P13_ErrorCtrl@8" (ByVal ctrlval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_ErrorDefine Lib "P13W32.DLL" Alias "_P13_ErrorDefine@24" (ByVal defineval As Long, ByVal errvalue As Integer, ByVal countval As Long, ByVal wordpos As Integer, ByVal bitpos As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_ErrorSent Lib "P13W32.DLL" Alias "_P13_ErrorSent@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ErrorTagBC Lib "P13W32.DLL" Alias "_P13_ErrorTagBC@12" (ByVal tagval As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_ErrorTagRT Lib "P13W32.DLL" Alias "_P13_ErrorTagRT@24" (ByVal tagval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MonConfig Lib "P13W32.DLL" Alias "_P13_MonConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MonFilterSA Lib "P13W32.DLL" Alias "_P13_MonFilterSA@24" (ByVal taval As Long, ByVal rcvsamask As Long, ByVal xmtsamask As Long, ByVal rcvmcmask As Long, ByVal xmtmcmask As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MonFilterTA Lib "P13W32.DLL" Alias "_P13_MonFilterTA@8" (ByVal tamask As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MonIsRunning Lib "P13W32.DLL" Alias "_P13_MonIsRunning@4" (ByVal handleval As Long) As Long
Public Declare Function P13_MonRd Lib "P13W32.DLL" Alias "_P13_MonRd@8" (ByRef buf As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_MsgDataRd Lib "P13W32.DLL" Alias "_P13_MsgDataRd@16" (ByRef buf As Integer, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgDataWr Lib "P13W32.DLL" Alias "_P13_MsgDataWr@16" (ByRef buf As Integer, ByVal count As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgFieldRd Lib "P13W32.DLL" Alias "_P13_MsgFieldRd@12" (ByVal fieldtype As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgFieldWr Lib "P13W32.DLL" Alias "_P13_MsgFieldWr@16" (ByVal fieldval As Long, ByVal fieldtype As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RTConfig Lib "P13W32.DLL" Alias "_P13_RTConfig@12" (ByVal configval As Long, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RTCreateMsg Lib "P13W32.DLL" Alias "_P13_RTCreateMsg@24" (ByVal configval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RTGetMsg Lib "P13W32.DLL" Alias "_P13_RTGetMsg@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RTSWDWr Lib "P13W32.DLL" Alias "_P13_RTSWDWr@12" (ByVal swdval As Integer, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_ValPackCWD Lib "P13W32.DLL" Alias "_P13_ValPackCWD@16" (ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal wcval As Long) As Integer
Public Declare Function P13_ValUnpackCWD Lib "P13W32.DLL" Alias "_P13_ValUnpackCWD@20" (ByVal cwdval As Integer, ByRef taval As Long, ByRef trflag As Long, ByRef saval As Long, ByRef wcval As Long) As Long
Public Declare Function PC1553_Bitset Lib "P13W32.DLL" Alias "_PC1553_Bitset@12" (ByVal wordval As Integer, ByVal bitvalue As Long, ByVal bitnum As Long) As Integer
Public Declare Function PC1553_Bittest Lib "P13W32.DLL" Alias "_PC1553_Bittest@8" (ByVal wordval As Integer, ByVal bitnum As Long) As Long
Public Declare Function PC1553_Clearlist Lib "P13W32.DLL" Alias "_PC1553_Clearlist@4" (ByVal fh As Long) As Long
Public Declare Function PC1553_Config Lib "P13W32.DLL" Alias "_PC1553_Config@16" (ByVal reg0 As Long, ByVal reg1 As Long, ByVal reg2 As Long, ByVal portval As Long) As Long
Public Declare Function PC1553_Execute Lib "P13W32.DLL" Alias "_PC1553_Execute@24" (ByRef nameptr As String, ByRef swdptr As Integer, ByRef dwdptr As Long, ByVal segval As Long, ByVal portval As Long, ByVal fh As Long) As Long
Public Declare Function PC1553_Freedrv Lib "P13W32.DLL" Alias "_PC1553_Freedrv@0" () As Long
Public Declare Function PC1553_Loadlist Lib "P13W32.DLL" Alias "_PC1553_Loadlist@4" (ByRef filename As String) As Long
Public Declare Function PC1553_Maskshift Lib "P13W32.DLL" Alias "_PC1553_Maskshift@12" (ByVal inputval As Integer, ByVal startbit As Long, ByVal lengthval As Long) As Integer
Public Declare Function PC1553_Packcwd Lib "P13W32.DLL" Alias "_PC1553_Packcwd@16" (ByVal taval As Long, ByVal trval As Long, ByVal saval As Long, ByVal wcval As Long) As Integer
Public Declare Function PC1553_Packwd Lib "P13W32.DLL" Alias "_PC1553_Packwd@16" (ByVal inputval As Integer, ByVal oldval As Integer, ByVal startbit As Long, ByVal lengthval As Long) As Integer
Public Declare Function PC1553_Readbcdwd Lib "P13W32.DLL" Alias "_PC1553_Readbcdwd@16" (ByVal countval As Long, ByVal startval As Long, ByRef destptr As Long, ByVal segval As Long) As Long
Public Declare Function PC1553_Readresp Lib "P13W32.DLL" Alias "_PC1553_Readresp@4" (ByVal portval As Long) As Long
Public Declare Function PC1553_Readrtdwd Lib "P13W32.DLL" Alias "_PC1553_Readrtdwd@24" (ByVal trval As Long, ByVal saval As Long, ByVal countval As Long, ByVal startval As Long, ByRef destptr As Long, ByVal segval As Long) As Long
Public Declare Function PC1553_Readwd Lib "P13W32.DLL" Alias "_PC1553_Readwd@8" (ByVal offset As Long, ByVal segval As Long) As Long
Public Declare Function PC1553_Transmit Lib "P13W32.DLL" Alias "_PC1553_Transmit@4" (ByVal portval As Long) As Long
Public Declare Function PC1553_Writebcdwd Lib "P13W32.DLL" Alias "_PC1553_Writebcdwd@16" (ByVal countval As Long, ByVal startval As Long, ByRef srcptr As Long, ByVal segval As Long) As Long
Public Declare Function PC1553_Writertdwd Lib "P13W32.DLL" Alias "_PC1553_Writertdwd@24" (ByVal trval As Long, ByVal saval As Long, ByVal countval As Long, ByVal startval As Long, ByRef srcptr As Long, ByVal segval As Long) As Long
Public Declare Function PC1553_Writewd Lib "P13W32.DLL" Alias "_PC1553_Writewd@12" (ByVal value As Long, ByVal offset As Long, ByVal segval As Long) As Long
Public Declare Function P12_Bitset Lib "P13W32.DLL" Alias "_P12_Bitset@12" (ByVal wordval As Integer, ByVal bitvalue As Long, ByVal bitnum As Long) As Integer
Public Declare Function P12_Bittest Lib "P13W32.DLL" Alias "_P12_Bittest@8" (ByVal wordval As Integer, ByVal bitnum As Long) As Long
Public Declare Function P12_Checklist Lib "P13W32.DLL" Alias "_P12_Checklist@4" (ByVal fh As Long) As Long
Public Declare Function P12_Clearlist Lib "P13W32.DLL" Alias "_P12_Clearlist@4" (ByVal fh As Long) As Long
Public Declare Function P12_Config Lib "P13W32.DLL" Alias "_P12_Config@16" (ByVal reg0 As Long, ByVal reg1 As Long, ByVal reg2 As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Execconfig Lib "P13W32.DLL" Alias "_P12_Execconfig@12" (ByRef nameptr As String, ByVal fh As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Execmsg Lib "P13W32.DLL" Alias "_P12_Execmsg@20" (ByRef nameptr As String, ByRef bufptr As Long, ByRef swdptr As Integer, ByVal fh As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Execute Lib "P13W32.DLL" Alias "_P12_Execute@20" (ByRef nameptr As String, ByRef swdptr As Integer, ByRef dwdptr As Long, ByVal fh As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Freedrv Lib "P13W32.DLL" Alias "_P12_Freedrv@0" () As Long
Public Declare Function P12_In Lib "P13W32.DLL" Alias "_P12_In@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Loadlist Lib "P13W32.DLL" Alias "_P12_Loadlist@4" (ByRef filename As String) As Long
Public Declare Function P12_Locate Lib "P13W32.DLL" Alias "_P12_Locate@12" (ByVal keytype As Long, ByRef nameptr As String, ByVal fh As Long) As Long
Public Declare Function P12_Maskshift Lib "P13W32.DLL" Alias "_P12_Maskshift@12" (ByVal inputval As Integer, ByVal startbit As Long, ByVal lengthval As Long) As Integer
Public Declare Function P12_Out Lib "P13W32.DLL" Alias "_P12_Out@12" (ByVal dataval As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Packcwd Lib "P13W32.DLL" Alias "_P12_Packcwd@16" (ByVal taval As Long, ByVal trval As Long, ByVal saval As Long, ByVal wcval As Long) As Integer
Public Declare Function P12_Packwd Lib "P13W32.DLL" Alias "_P12_Packwd@16" (ByVal inputval As Integer, ByVal oldval As Integer, ByVal startbit As Long, ByVal lengthval As Long) As Integer
Public Declare Function P12_Readb Lib "P13W32.DLL" Alias "_P12_Readb@4" (ByVal fh As Long) As Long
Public Declare Function P12_Readbcdwd Lib "P13W32.DLL" Alias "_P12_Readbcdwd@16" (ByVal countval As Long, ByVal startval As Long, ByRef destptr As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Readresp Lib "P13W32.DLL" Alias "_P12_Readresp@4" (ByVal handleval As Long) As Long
Public Declare Function P12_Readrtdwd Lib "P13W32.DLL" Alias "_P12_Readrtdwd@24" (ByVal trval As Long, ByVal saval As Long, ByVal countval As Long, ByVal startval As Long, ByRef destptr As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Readw Lib "P13W32.DLL" Alias "_P12_Readw@4" (ByVal fh As Long) As Long
Public Declare Function P12_Readwd Lib "P13W32.DLL" Alias "_P12_Readwd@8" (ByVal offset As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Readwds Lib "P13W32.DLL" Alias "_P12_Readwds@16" (ByVal offval As Long, ByRef destptr As Long, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Transmit Lib "P13W32.DLL" Alias "_P12_Transmit@4" (ByVal handleval As Long) As Long
Public Declare Function P12_Writebcdwd Lib "P13W32.DLL" Alias "_P12_Writebcdwd@16" (ByVal countval As Long, ByVal startval As Long, ByRef srcptr As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Writertdwd Lib "P13W32.DLL" Alias "_P12_Writertdwd@24" (ByVal trval As Long, ByVal saval As Long, ByVal countval As Long, ByVal startval As Long, ByRef srcptr As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Writewd Lib "P13W32.DLL" Alias "_P12_Writewd@12" (ByVal value As Long, ByVal offset As Long, ByVal handleval As Long) As Long
Public Declare Function P12_Writewds Lib "P13W32.DLL" Alias "_P12_Writewds@16" (ByVal offval As Long, ByRef srcptr As Long, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_AddrDSP Lib "P13W32.DLL" Alias "_P13_AddrDSP@4" (ByVal addr As Long) As Long
Public Declare Function P13_AddrHost Lib "P13W32.DLL" Alias "_P13_AddrHost@4" (ByVal addr As Long) As Long
Public Declare Function P13_BCConfigEx Lib "P13W32.DLL" Alias "_P13_BCConfigEx@12" (ByVal configval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_BCConfigMsg Lib "P13W32.DLL" Alias "_P13_BCConfigMsg@12" (ByVal configval As Long, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedAgain Lib "P13W32.DLL" Alias "_P13_BCSchedAgain@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedBranch Lib "P13W32.DLL" Alias "_P13_BCSchedBranch@12" (ByVal condition As Integer, ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedBranchDin0 Lib "P13W32.DLL" Alias "_P13_BCSchedBranchDin0@8" (ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedBranchDin1 Lib "P13W32.DLL" Alias "_P13_BCSchedBranchDin1@8" (ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedBranchEx Lib "P13W32.DLL" Alias "_P13_BCSchedBranchEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedBuild Lib "P13W32.DLL" Alias "_P13_BCSchedBuild@16" (ByVal nummsgs As Integer, ByRef msgaddr As Long, ByRef freq As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedCall Lib "P13W32.DLL" Alias "_P13_BCSchedCall@8" (ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedCallCond Lib "P13W32.DLL" Alias "_P13_BCSchedCallCond@12" (ByVal condition As Integer, ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedCallCondEx Lib "P13W32.DLL" Alias "_P13_BCSchedCallCondEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedEntry Lib "P13W32.DLL" Alias "_P13_BCSchedEntry@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedFrameEnd Lib "P13W32.DLL" Alias "_P13_BCSchedFrameEnd@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedFrameStart Lib "P13W32.DLL" Alias "_P13_BCSchedFrameStart@8" (ByVal timeval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedGap Lib "P13W32.DLL" Alias "_P13_BCSchedGap@8" (ByVal gapval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedGoto Lib "P13W32.DLL" Alias "_P13_BCSchedGoto@8" (ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedHalt Lib "P13W32.DLL" Alias "_P13_BCSchedHalt@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedInt Lib "P13W32.DLL" Alias "_P13_BCSchedInt@8" (ByVal tagval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedIntCond Lib "P13W32.DLL" Alias "_P13_BCSchedIntCond@12" (ByVal condition As Integer, ByVal tagval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedIntCondEx Lib "P13W32.DLL" Alias "_P13_BCSchedIntCondEx@20" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal tagval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedNop Lib "P13W32.DLL" Alias "_P13_BCSchedNop@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedPause Lib "P13W32.DLL" Alias "_P13_BCSchedPause@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedPulse Lib "P13W32.DLL" Alias "_P13_BCSchedPulse@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedPulse0 Lib "P13W32.DLL" Alias "_P13_BCSchedPulse0@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedPulse1 Lib "P13W32.DLL" Alias "_P13_BCSchedPulse1@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedRestart Lib "P13W32.DLL" Alias "_P13_BCSchedRestart@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedRetryEx Lib "P13W32.DLL" Alias "_P13_BCSchedRetryEx@24" (ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal condition3 As Integer, ByVal retryflag As Integer, ByVal retries As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedReturn Lib "P13W32.DLL" Alias "_P13_BCSchedReturn@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSchedUser Lib "P13W32.DLL" Alias "_P13_BCSchedUser@8" (ByVal useraddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BCSetEntry Lib "P13W32.DLL" Alias "_P13_BCSetEntry@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BCSetTimeout Lib "P13W32.DLL" Alias "_P13_BCSetTimeout@8" (ByVal timeoutval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_BlkAddr Lib "P13W32.DLL" Alias "_P13_BlkAddr@8" (ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BlkOptRd Lib "P13W32.DLL" Alias "_P13_BlkOptRd@8" (ByVal taval As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_BlkOptWr Lib "P13W32.DLL" Alias "_P13_BlkOptWr@12" (ByVal rtopt As Integer, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BlkPtrRd Lib "P13W32.DLL" Alias "_P13_BlkPtrRd@8" (ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BlkPtrWr Lib "P13W32.DLL" Alias "_P13_BlkPtrWr@12" (ByVal descaddr As Long, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BlkRd Lib "P13W32.DLL" Alias "_P13_BlkRd@12" (ByRef block As Integer, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BlkReset Lib "P13W32.DLL" Alias "_P13_BlkReset@8" (ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BlkSWDRd Lib "P13W32.DLL" Alias "_P13_BlkSWDRd@8" (ByVal taval As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_BlkSWDWr Lib "P13W32.DLL" Alias "_P13_BlkSWDWr@12" (ByVal swdval As Integer, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_BlkWipe Lib "P13W32.DLL" Alias "_P13_BlkWipe@4" (ByVal handleval As Long) As Long
Public Declare Function P13_BlkWr Lib "P13W32.DLL" Alias "_P13_BlkWr@12" (ByRef block As Integer, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CardBoot Lib "P13W32.DLL" Alias "_P13_CardBoot@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardCloseAll Lib "P13W32.DLL" Alias "_P13_CardCloseAll@0" () As Long
Public Declare Function P13_CardConfig Lib "P13W32.DLL" Alias "_P13_CardConfig@16" (ByVal enableflag As Long, ByVal command As Integer, ByVal taval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CardGetInfo Lib "P13W32.DLL" Alias "_P13_CardGetInfo@8" (ByVal infotype As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CardGetInfoEx Lib "P13W32.DLL" Alias "_P13_CardGetInfoEx@20" (ByRef bufmodel As Integer, ByVal bufmodelcount As Integer, ByRef buffeature As Integer, ByVal buffeaturecount As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CardInit Lib "P13W32.DLL" Alias "_P13_CardInit@0" () As Long
Public Declare Function P13_CardIsRunning Lib "P13W32.DLL" Alias "_P13_CardIsRunning@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardNop Lib "P13W32.DLL" Alias "_P13_CardNop@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardOpenEx Lib "P13W32.DLL" Alias "_P13_CardOpenEx@20" (ByRef cardname As String, ByVal memval As Long, ByVal ioval As Integer, ByVal irqval As Integer, ByVal drqval As Integer) As Long
Public Declare Function P13_CardOpenExx Lib "P13W32.DLL" Alias "_P13_CardOpenExx@28" (ByRef cardname As String, ByVal memval As Long, ByVal ioval As Integer, ByVal irqval As Integer, ByVal drqval As Integer, ByRef happwnd As Long, ByVal uiremovalmsg As Integer) As Long
Public Declare Function P13_CardResetEx Lib "P13W32.DLL" Alias "_P13_CardResetEx@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardResume Lib "P13W32.DLL" Alias "_P13_CardResume@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardTest Lib "P13W32.DLL" Alias "_P13_CardTest@8" (ByVal level As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CardTest0 Lib "P13W32.DLL" Alias "_P13_CardTest0@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardTest1 Lib "P13W32.DLL" Alias "_P13_CardTest1@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardTest2 Lib "P13W32.DLL" Alias "_P13_CardTest2@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardTest3 Lib "P13W32.DLL" Alias "_P13_CardTest3@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CardTrigger Lib "P13W32.DLL" Alias "_P13_CardTrigger@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CmdAddr Lib "P13W32.DLL" Alias "_P13_CmdAddr@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CmdAlloc Lib "P13W32.DLL" Alias "_P13_CmdAlloc@8" (ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CmdBaseRd Lib "P13W32.DLL" Alias "_P13_CmdBaseRd@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CmdBaseWr Lib "P13W32.DLL" Alias "_P13_CmdBaseWr@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CmdClear Lib "P13W32.DLL" Alias "_P13_CmdClear@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CmdCountRd Lib "P13W32.DLL" Alias "_P13_CmdCountRd@4" (ByVal handleval As Long) As Integer
Public Declare Function P13_CmdCountWr Lib "P13W32.DLL" Alias "_P13_CmdCountWr@8" (ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CmdCtrlRd Lib "P13W32.DLL" Alias "_P13_CmdCtrlRd@8" (ByVal index As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_CmdCtrlWr Lib "P13W32.DLL" Alias "_P13_CmdCtrlWr@12" (ByVal ctrlval As Integer, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CmdCurrRd Lib "P13W32.DLL" Alias "_P13_CmdCurrRd@4" (ByVal handleval As Long) As Integer
Public Declare Function P13_CmdCurrWr Lib "P13W32.DLL" Alias "_P13_CmdCurrWr@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CmdInit Lib "P13W32.DLL" Alias "_P13_CmdInit@8" (ByVal opcode As Integer, ByRef block As Integer) As Long
Public Declare Function P13_CmdInsert Lib "P13W32.DLL" Alias "_P13_CmdInsert@8" (ByRef block As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CmdMaxRd Lib "P13W32.DLL" Alias "_P13_CmdMaxRd@4" (ByVal handleval As Long) As Integer
Public Declare Function P13_CmdMaxWr Lib "P13W32.DLL" Alias "_P13_CmdMaxWr@8" (ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CmdRd Lib "P13W32.DLL" Alias "_P13_CmdRd@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CmdShotWr Lib "P13W32.DLL" Alias "_P13_CmdShotWr@12" (ByVal value As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CmdSkipWr Lib "P13W32.DLL" Alias "_P13_CmdSkipWr@12" (ByVal value As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CmdStackClr Lib "P13W32.DLL" Alias "_P13_CmdStackClr@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CmdStartRd Lib "P13W32.DLL" Alias "_P13_CmdStartRd@4" (ByVal handleval As Long) As Integer
Public Declare Function P13_CmdStartWr Lib "P13W32.DLL" Alias "_P13_CmdStartWr@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CmdTotalRd Lib "P13W32.DLL" Alias "_P13_CmdTotalRd@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CmdTotalWr Lib "P13W32.DLL" Alias "_P13_CmdTotalWr@8" (ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CmdWr Lib "P13W32.DLL" Alias "_P13_CmdWr@12" (ByRef block As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CommCall Lib "P13W32.DLL" Alias "_P13_CommCall@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CommCheck Lib "P13W32.DLL" Alias "_P13_CommCheck@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CommDisable Lib "P13W32.DLL" Alias "_P13_CommDisable@8" (ByVal command As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CommEnable Lib "P13W32.DLL" Alias "_P13_CommEnable@4" (ByVal handleval As Long) As Long
Public Declare Function P13_CommRdL Lib "P13W32.DLL" Alias "_P13_CommRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CommRdsW Lib "P13W32.DLL" Alias "_P13_CommRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CommRdW Lib "P13W32.DLL" Alias "_P13_CommRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_CommRun Lib "P13W32.DLL" Alias "_P13_CommRun@20" (ByRef dataptr As Integer, ByVal datacount As Integer, ByRef codeptr As Integer, ByVal codecount As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CommWrL Lib "P13W32.DLL" Alias "_P13_CommWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_CommWrsW Lib "P13W32.DLL" Alias "_P13_CommWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_CommWrW Lib "P13W32.DLL" Alias "_P13_CommWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_DARClr Lib "P13W32.DLL" Alias "_P13_DARClr@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_DARGet Lib "P13W32.DLL" Alias "_P13_DARGet@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_DARRdL Lib "P13W32.DLL" Alias "_P13_DARRdL@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_DARRdW Lib "P13W32.DLL" Alias "_P13_DARRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_DARSet Lib "P13W32.DLL" Alias "_P13_DARSet@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_DARWrL Lib "P13W32.DLL" Alias "_P13_DARWrL@12" (ByVal value As Long, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_DARWrW Lib "P13W32.DLL" Alias "_P13_DARWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_DescAddr Lib "P13W32.DLL" Alias "_P13_DescAddr@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_DescAlloc Lib "P13W32.DLL" Alias "_P13_DescAlloc@4" (ByVal handleval As Long) As Long
Public Declare Function P13_DescConfig Lib "P13W32.DLL" Alias "_P13_DescConfig@24" (ByVal configval As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_DescOptRd Lib "P13W32.DLL" Alias "_P13_DescOptRd@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_DescOptWr Lib "P13W32.DLL" Alias "_P13_DescOptWr@24" (ByVal descopt As Integer, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_DescPtrRd Lib "P13W32.DLL" Alias "_P13_DescPtrRd@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_DescPtrWr Lib "P13W32.DLL" Alias "_P13_DescPtrWr@24" (ByVal msgaddr As Long, ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_DescRd Lib "P13W32.DLL" Alias "_P13_DescRd@24" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByRef desc As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_DescWr Lib "P13W32.DLL" Alias "_P13_DescWr@24" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByRef desc As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_Div Lib "P13W32.DLL" Alias "_P13_Div@8" (ByVal diva As Long, ByVal divb As Long) As Long
Public Declare Function P13_DllUsageCount Lib "P13W32.DLL" Alias "_P13_DllUsageCount@0" () As Long
Public Declare Function P13_DspBioRd Lib "P13W32.DLL" Alias "_P13_DspBioRd@4" (ByVal handleval As Long) As Integer
Public Declare Function P13_DspIntfClear Lib "P13W32.DLL" Alias "_P13_DspIntfClear@4" (ByVal handleval As Long) As Long
Public Declare Function P13_DspIntfRead Lib "P13W32.DLL" Alias "_P13_DspIntfRead@4" (ByVal handleval As Long) As Long
Public Declare Function P13_DspIntmClear Lib "P13W32.DLL" Alias "_P13_DspIntmClear@4" (ByVal handleval As Long) As Long
Public Declare Function P13_DspIntmSet Lib "P13W32.DLL" Alias "_P13_DspIntmSet@4" (ByVal handleval As Long) As Long
Public Declare Function P13_DspXfClear Lib "P13W32.DLL" Alias "_P13_DspXfClear@4" (ByVal handleval As Long) As Long
Public Declare Function P13_DspXfSet Lib "P13W32.DLL" Alias "_P13_DspXfSet@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ErrorIsTaggedBC Lib "P13W32.DLL" Alias "_P13_ErrorIsTaggedBC@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_ErrorIsTaggedRT Lib "P13W32.DLL" Alias "_P13_ErrorIsTaggedRT@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_ErrorResponse Lib "P13W32.DLL" Alias "_P13_ErrorResponse@8" (ByVal responseval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_ErrorSync Lib "P13W32.DLL" Alias "_P13_ErrorSync@8" (ByVal value As Long, ByVal handleval As Long) As Long
Public Declare Function P13_ErrorTimeout Lib "P13W32.DLL" Alias "_P13_ErrorTimeout@8" (ByVal timeoutval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_ExtDinRd Lib "P13W32.DLL" Alias "_P13_ExtDinRd@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ExtDinWr Lib "P13W32.DLL" Alias "_P13_ExtDinWr@8" (ByVal dinval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_ExtDoutRd Lib "P13W32.DLL" Alias "_P13_ExtDoutRd@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ExtDoutWr Lib "P13W32.DLL" Alias "_P13_ExtDoutWr@8" (ByVal doutval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_FileClose Lib "P13W32.DLL" Alias "_P13_FileClose@4" (ByRef handle As Long) As Long
Public Declare Function P13_FileErr Lib "P13W32.DLL" Alias "_P13_FileErr@0" () As Long
Public Declare Function P13_FileErrClr Lib "P13W32.DLL" Alias "_P13_FileErrClr@0" () As Long
Public Declare Function P13_FileErrSet Lib "P13W32.DLL" Alias "_P13_FileErrSet@0" () As Long
Public Declare Function P13_FileOpenRead Lib "P13W32.DLL" Alias "_P13_FileOpenRead@4" (ByRef filename As String) As Long
Public Declare Function P13_FileOpenWrite Lib "P13W32.DLL" Alias "_P13_FileOpenWrite@4" (ByRef filename As String) As Long
Public Declare Function P13_FileRead Lib "P13W32.DLL" Alias "_P13_FileRead@12" (ByRef handle As Long, ByRef buffer As Long, ByVal count As Integer) As Long
Public Declare Function P13_FileSeek Lib "P13W32.DLL" Alias "_P13_FileSeek@8" (ByRef handle As Long, ByVal offset As Long) As Long
Public Declare Function P13_FileTell Lib "P13W32.DLL" Alias "_P13_FileTell@4" (ByRef handle As Long) As Long
Public Declare Function P13_FileWrite Lib "P13W32.DLL" Alias "_P13_FileWrite@12" (ByRef handle As Long, ByRef buffer As Long, ByVal count As Integer) As Long
Public Declare Function P13_GetHigh Lib "P13W32.DLL" Alias "_P13_GetHigh@4" (ByVal val As Long) As Integer
Public Declare Function P13_GetLow Lib "P13W32.DLL" Alias "_P13_GetLow@4" (ByVal val As Long) As Integer
Public Declare Function P13_GlobalRdW Lib "P13W32.DLL" Alias "_P13_GlobalRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_GlobalWrW Lib "P13W32.DLL" Alias "_P13_GlobalWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_HandleDel Lib "P13W32.DLL" Alias "_P13_HandleDel@4" (ByVal handleval As Long) As Long
Public Declare Function P13_HandleGet Lib "P13W32.DLL" Alias "_P13_HandleGet@24" (ByRef memval As Long, ByRef sizval As Long, ByRef ioval As Long, ByRef irqval As Integer, ByRef drqval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_HandleGetIo Lib "P13W32.DLL" Alias "_P13_HandleGetIo@4" (ByVal ioval As Integer) As Long
Public Declare Function P13_HandleGetMem Lib "P13W32.DLL" Alias "_P13_HandleGetMem@4" (ByVal memval As Long) As Long
Public Declare Function P13_HandleIns Lib "P13W32.DLL" Alias "_P13_HandleIns@28" (ByRef cardname As String, ByVal memval As Long, ByVal ioval As Integer, ByVal irqval As Integer, ByVal drqval As Integer, ByRef happwnd As Long, ByVal uiremovalmsg As Integer) As Long
Public Declare Function P13_HandleOkay Lib "P13W32.DLL" Alias "_P13_HandleOkay@4" (ByVal handleval As Long) As Long
Public Declare Function P13_HeapAlloc Lib "P13W32.DLL" Alias "_P13_HeapAlloc@8" (ByVal wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function P13_HeapAllocAll Lib "P13W32.DLL" Alias "_P13_HeapAllocAll@8" (ByRef wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function P13_HeapAllocEx Lib "P13W32.DLL" Alias "_P13_HeapAllocEx@12" (ByVal configval As Integer, ByVal wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function P13_HeapWipe Lib "P13W32.DLL" Alias "_P13_HeapWipe@4" (ByVal handleval As Long) As Long
Public Declare Function P13_IndirectRd Lib "P13W32.DLL" Alias "_P13_IndirectRd@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_IndirectWr Lib "P13W32.DLL" Alias "_P13_IndirectWr@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_IntClear Lib "P13W32.DLL" Alias "_P13_IntClear@4" (ByVal handleval As Long) As Long
Public Declare Function P13_IntConfig Lib "P13W32.DLL" Alias "_P13_IntConfig@12" (ByVal configval As Integer, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_IntDisable Lib "P13W32.DLL" Alias "_P13_IntDisable@4" (ByVal handleval As Long) As Long
Public Declare Function P13_IntEnable Lib "P13W32.DLL" Alias "_P13_IntEnable@4" (ByVal handleval As Long) As Long
Public Declare Function P13_IntEnableCond Lib "P13W32.DLL" Alias "_P13_IntEnableCond@4" (ByVal handleval As Long) As Long
Public Declare Function P13_IntGet Lib "P13W32.DLL" Alias "_P13_IntGet@4" (ByVal handleval As Long) As Long
Public Declare Function P13_IntInstall Lib "P13W32.DLL" Alias "_P13_IntInstall@8" (ByRef hevent As Long, ByVal handleval As Long) As Long
Public Declare Function P13_IntRd Lib "P13W32.DLL" Alias "_P13_IntRd@12" (ByRef typevalval As Integer, ByRef infoval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_IntReset Lib "P13W32.DLL" Alias "_P13_IntReset@4" (ByVal handleval As Long) As Long
Public Declare Function P13_IntStatus Lib "P13W32.DLL" Alias "_P13_IntStatus@4" (ByVal handleval As Long) As Long
Public Declare Function P13_IntUninstall Lib "P13W32.DLL" Alias "_P13_IntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function P13_IORdW Lib "P13W32.DLL" Alias "_P13_IORdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_IOWINRdW Lib "P13W32.DLL" Alias "_P13_IOWINRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_IOWINWrW Lib "P13W32.DLL" Alias "_P13_IOWINWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_IOWrW Lib "P13W32.DLL" Alias "_P13_IOWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_KernDev Lib "P13W32.DLL" Alias "_P13_KernDev@8" (ByRef valueptr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_KernEnd Lib "P13W32.DLL" Alias "_P13_KernEnd@4" (ByVal handleval As Long) As Long
Public Declare Function P13_KernIntClear Lib "P13W32.DLL" Alias "_P13_KernIntClear@4" (ByVal handleval As Long) As Long
Public Declare Function P13_KernIntInstall Lib "P13W32.DLL" Alias "_P13_KernIntInstall@8" (ByRef hevent As Long, ByVal handleval As Long) As Long
Public Declare Function P13_KernIntStatus Lib "P13W32.DLL" Alias "_P13_KernIntStatus@8" (ByRef valueptr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_KernIntUninstall Lib "P13W32.DLL" Alias "_P13_KernIntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function P13_KernIORdW Lib "P13W32.DLL" Alias "_P13_KernIORdW@12" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_KernIOWrW Lib "P13W32.DLL" Alias "_P13_KernIOWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_KernMEMFillW Lib "P13W32.DLL" Alias "_P13_KernMEMFillW@16" (ByVal value As Integer, ByVal addrval As Integer, ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_KernMEMRdsW Lib "P13W32.DLL" Alias "_P13_KernMEMRdsW@16" (ByRef bufptr As Integer, ByVal addrval As Integer, ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_KernMEMRdW Lib "P13W32.DLL" Alias "_P13_KernMEMRdW@12" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_KernMEMWrsW Lib "P13W32.DLL" Alias "_P13_KernMEMWrsW@16" (ByRef bufptr As Integer, ByVal addrval As Integer, ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_KernMEMWrW Lib "P13W32.DLL" Alias "_P13_KernMEMWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_KernStatus Lib "P13W32.DLL" Alias "_P13_KernStatus@12" (ByRef valueptr As Long, ByVal typeval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_ListConfig Lib "P13W32.DLL" Alias "_P13_ListConfig@12" (ByVal configval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_MakeLong Lib "P13W32.DLL" Alias "_P13_MakeLong@8" (ByVal valh As Integer, ByVal vall As Integer) As Long
Public Declare Function P13_Mask Lib "P13W32.DLL" Alias "_P13_Mask@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function P13_MEMWINRdB Lib "P13W32.DLL" Alias "_P13_MEMWINRdB@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_MEMWINRdL Lib "P13W32.DLL" Alias "_P13_MEMWINRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MEMWINRdW Lib "P13W32.DLL" Alias "_P13_MEMWINRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_MEMWINWrB Lib "P13W32.DLL" Alias "_P13_MEMWINWrB@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MEMWINWrL Lib "P13W32.DLL" Alias "_P13_MEMWINWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MEMWINWrW Lib "P13W32.DLL" Alias "_P13_MEMWINWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_Mod Lib "P13W32.DLL" Alias "_P13_Mod@8" (ByVal moda As Long, ByVal modb As Long) As Long
Public Declare Function P13_ModeIsBC Lib "P13W32.DLL" Alias "_P13_ModeIsBC@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ModeIsMon Lib "P13W32.DLL" Alias "_P13_ModeIsMon@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ModeIsNotBC Lib "P13W32.DLL" Alias "_P13_ModeIsNotBC@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ModeIsNotMon Lib "P13W32.DLL" Alias "_P13_ModeIsNotMon@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ModeIsNotRT Lib "P13W32.DLL" Alias "_P13_ModeIsNotRT@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ModeIsNotSerial Lib "P13W32.DLL" Alias "_P13_ModeIsNotSerial@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ModeIsRT Lib "P13W32.DLL" Alias "_P13_ModeIsRT@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ModeIsSerial Lib "P13W32.DLL" Alias "_P13_ModeIsSerial@4" (ByVal handleval As Long) As Long
Public Declare Function P13_ModeRd Lib "P13W32.DLL" Alias "_P13_ModeRd@4" (ByVal handleval As Long) As Integer
Public Declare Function P13_ModeWr Lib "P13W32.DLL" Alias "_P13_ModeWr@8" (ByVal mode As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_MonClear Lib "P13W32.DLL" Alias "_P13_MonClear@4" (ByVal handleval As Long) As Long
Public Declare Function P13_MonConfigEx Lib "P13W32.DLL" Alias "_P13_MonConfigEx@16" (ByVal configval As Long, ByVal moncount As Long, ByVal cardnum As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_MonConfigExx Lib "P13W32.DLL" Alias "_P13_MonConfigExx@20" (ByVal configval As Long, ByVal seqaddr As Long, ByVal moncount As Long, ByVal cardnum As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_MonFilterSAEx Lib "P13W32.DLL" Alias "_P13_MonFilterSAEx@24" (ByVal taval As Long, ByVal rcvsamask As Long, ByVal xmtsamask As Long, ByVal rcvmcmask As Long, ByVal xmtmcmask As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MonRdEx Lib "P13W32.DLL" Alias "_P13_MonRdEx@12" (ByRef buf As Integer, ByVal bufcount As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_MonResume Lib "P13W32.DLL" Alias "_P13_MonResume@4" (ByVal handleval As Long) As Long
Public Declare Function P13_MonStart Lib "P13W32.DLL" Alias "_P13_MonStart@4" (ByVal handleval As Long) As Long
Public Declare Function P13_MonStatus Lib "P13W32.DLL" Alias "_P13_MonStatus@4" (ByVal handleval As Long) As Long
Public Declare Function P13_MonStop Lib "P13W32.DLL" Alias "_P13_MonStop@4" (ByVal handleval As Long) As Long
Public Declare Function P13_MsgBlockRd Lib "P13W32.DLL" Alias "_P13_MsgBlockRd@12" (ByRef buf As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgBlockWr Lib "P13W32.DLL" Alias "_P13_MsgBlockWr@12" (ByRef buf As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgCheck Lib "P13W32.DLL" Alias "_P13_MsgCheck@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_MsgCommRd Lib "P13W32.DLL" Alias "_P13_MsgCommRd@12" (ByRef buf As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgCommWr Lib "P13W32.DLL" Alias "_P13_MsgCommWr@12" (ByRef buf As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgConfig Lib "P13W32.DLL" Alias "_P13_MsgConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgConfigEx Lib "P13W32.DLL" Alias "_P13_MsgConfigEx@12" (ByVal configval As Long, ByVal cwd As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_MsgCWD1Rd Lib "P13W32.DLL" Alias "_P13_MsgCWD1Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_MsgCWD1Wr Lib "P13W32.DLL" Alias "_P13_MsgCWD1Wr@12" (ByVal cwd1 As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgCWD2Rd Lib "P13W32.DLL" Alias "_P13_MsgCWD2Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_MsgCWD2Wr Lib "P13W32.DLL" Alias "_P13_MsgCWD2Wr@12" (ByVal cwd2 As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgErrorRd Lib "P13W32.DLL" Alias "_P13_MsgErrorRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_MsgErrorWr Lib "P13W32.DLL" Alias "_P13_MsgErrorWr@12" (ByVal value As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgFlagRd Lib "P13W32.DLL" Alias "_P13_MsgFlagRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_MsgFlagWr Lib "P13W32.DLL" Alias "_P13_MsgFlagWr@12" (ByVal msgflag As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgIsAccessed Lib "P13W32.DLL" Alias "_P13_MsgIsAccessed@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgOptRd Lib "P13W32.DLL" Alias "_P13_MsgOptRd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_MsgOptWr Lib "P13W32.DLL" Alias "_P13_MsgOptWr@12" (ByVal msgopt As Integer, ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgReset Lib "P13W32.DLL" Alias "_P13_MsgReset@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_MsgSWD1Rd Lib "P13W32.DLL" Alias "_P13_MsgSWD1Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_MsgSWD2Rd Lib "P13W32.DLL" Alias "_P13_MsgSWD2Rd@8" (ByVal msgaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_Mul Lib "P13W32.DLL" Alias "_P13_Mul@8" (ByVal mula As Long, ByVal mulb As Long) As Long
Public Declare Function P13_PortRd Lib "P13W32.DLL" Alias "_P13_PortRd@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_PortWr Lib "P13W32.DLL" Alias "_P13_PortWr@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_ProgRdW Lib "P13W32.DLL" Alias "_P13_ProgRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_ProgWrW Lib "P13W32.DLL" Alias "_P13_ProgWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_RAMFill Lib "P13W32.DLL" Alias "_P13_RAMFill@16" (ByVal value As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RAMRdB Lib "P13W32.DLL" Alias "_P13_RAMRdB@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_RAMRdL Lib "P13W32.DLL" Alias "_P13_RAMRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RAMRdsW Lib "P13W32.DLL" Alias "_P13_RAMRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_RAMRdsxW Lib "P13W32.DLL" Alias "_P13_RAMRdsxW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_RAMRdW Lib "P13W32.DLL" Alias "_P13_RAMRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_RAMWipe Lib "P13W32.DLL" Alias "_P13_RAMWipe@4" (ByVal handleval As Long) As Long
Public Declare Function P13_RAMWipeEx Lib "P13W32.DLL" Alias "_P13_RAMWipeEx@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_RAMWrB Lib "P13W32.DLL" Alias "_P13_RAMWrB@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RAMWrL Lib "P13W32.DLL" Alias "_P13_RAMWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RAMWrsW Lib "P13W32.DLL" Alias "_P13_RAMWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_RAMWrsxW Lib "P13W32.DLL" Alias "_P13_RAMWrsxW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_RAMWrW Lib "P13W32.DLL" Alias "_P13_RAMWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RTConfigEx Lib "P13W32.DLL" Alias "_P13_RTConfigEx@12" (ByVal configval As Long, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RTConfigExx Lib "P13W32.DLL" Alias "_P13_RTConfigExx@12" (ByVal configval As Long, ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RTReset Lib "P13W32.DLL" Alias "_P13_RTReset@8" (ByVal taval As Long, ByVal handleval As Long) As Long
Public Declare Function P13_RTStatus Lib "P13W32.DLL" Alias "_P13_RTStatus@8" (ByVal taval As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_RTSWDRd Lib "P13W32.DLL" Alias "_P13_RTSWDRd@8" (ByVal taval As Long, ByVal handleval As Long) As Integer
Public Declare Function P13_SARRdW Lib "P13W32.DLL" Alias "_P13_SARRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_SARWrW Lib "P13W32.DLL" Alias "_P13_SARWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_SchedBuild Lib "P13W32.DLL" Alias "_P13_SchedBuild@16" (ByVal nummsgs As Integer, ByRef msgaddr As Long, ByRef freq As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_SchedBuildEx Lib "P13W32.DLL" Alias "_P13_SchedBuildEx@28" (ByVal nummsgs As Integer, ByRef msgaddr As Long, ByRef freq As Integer, ByRef period As Integer, ByRef buf As Long, ByVal bufsize As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_SchedBuildExx Lib "P13W32.DLL" Alias "_P13_SchedBuildExx@28" (ByVal frametime As Long, ByVal nummsgs As Integer, ByRef msgaddr As Long, ByRef period As Integer, ByRef buf As Long, ByVal bufsize As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_SchedCalc Lib "P13W32.DLL" Alias "_P13_SchedCalc@8" (ByRef msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_SchedInsEnd Lib "P13W32.DLL" Alias "_P13_SchedInsEnd@4" (ByVal handleval As Long) As Long
Public Declare Function P13_SchedInsMsg Lib "P13W32.DLL" Alias "_P13_SchedInsMsg@12" (ByVal index As Integer, ByRef msgaddr As Long, ByVal handleval As Long) As Long
Public Declare Function P13_SchedInsStart Lib "P13W32.DLL" Alias "_P13_SchedInsStart@12" (ByVal frametime As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_SchedMaxval Lib "P13W32.DLL" Alias "_P13_SchedMaxval@8" (ByRef arrayval As Integer, ByVal arrayvalcount As Integer) As Integer
Public Declare Function P13_SchedMinval Lib "P13W32.DLL" Alias "_P13_SchedMinval@8" (ByRef arrayval As Integer, ByVal arrayvalcount As Integer) As Integer
Public Declare Function P13_SerialClear Lib "P13W32.DLL" Alias "_P13_SerialClear@4" (ByVal handleval As Long) As Long
Public Declare Function P13_SerialConfig Lib "P13W32.DLL" Alias "_P13_SerialConfig@12" (ByVal configval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_SerialConfigEx Lib "P13W32.DLL" Alias "_P13_SerialConfigEx@12" (ByVal configval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_SerialStatus Lib "P13W32.DLL" Alias "_P13_SerialStatus@4" (ByVal handleval As Long) As Long
Public Declare Function P13_SerialWr Lib "P13W32.DLL" Alias "_P13_SerialWr@8" (ByRef buf As Integer, ByVal handleval As Long) As Long
Public Declare Function P13_Shl Lib "P13W32.DLL" Alias "_P13_Shl@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function P13_Shr Lib "P13W32.DLL" Alias "_P13_Shr@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function P13_TimerClear Lib "P13W32.DLL" Alias "_P13_TimerClear@4" (ByVal handleval As Long) As Long
Public Declare Function P13_TimerRd Lib "P13W32.DLL" Alias "_P13_TimerRd@4" (ByVal handleval As Long) As Long
Public Declare Function P13_TimerResolution Lib "P13W32.DLL" Alias "_P13_TimerResolution@8" (ByVal timerresol As Long, ByVal handleval As Long) As Long
Public Declare Function P13_TimerResolutionEx Lib "P13W32.DLL" Alias "_P13_TimerResolutionEx@8" (ByVal timershift As Integer, ByVal handleval As Long) As Integer
Public Declare Function P13_ValAsciiCmpi Lib "P13W32.DLL" Alias "_P13_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Long
Public Declare Function P13_ValAsciiCpy Lib "P13W32.DLL" Alias "_P13_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Long) As Long
Public Declare Function P13_ValAsciiTrimLead Lib "P13W32.DLL" Alias "_P13_ValAsciiTrimLead@4" (ByRef buf As String) As Long
Public Declare Function P13_ValAsciiTrimTrail Lib "P13W32.DLL" Alias "_P13_ValAsciiTrimTrail@4" (ByRef buf As String) As Long
Public Declare Function P13_ValFromAscii Lib "P13W32.DLL" Alias "_P13_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Long) As Long
Public Declare Function P13_ValGetBits Lib "P13W32.DLL" Alias "_P13_ValGetBits@12" (ByVal oldvalue As Integer, ByVal startbit As Long, ByVal endbit As Long) As Integer
Public Declare Function P13_ValIncAscii Lib "P13W32.DLL" Alias "_P13_ValIncAscii@4" (ByRef asciistr As String) As Long
Public Declare Function P13_ValInccAscii Lib "P13W32.DLL" Alias "_P13_ValInccAscii@4" (ByRef asciistr As String) As Long
Public Declare Function P13_ValIsLower Lib "P13W32.DLL" Alias "_P13_ValIsLower@4" (ByVal value As Long) As Long
Public Declare Function P13_ValLenAscii Lib "P13W32.DLL" Alias "_P13_ValLenAscii@8" (ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function P13_ValPackRTCWD Lib "P13W32.DLL" Alias "_P13_ValPackRTCWD@20" (ByVal mcflag As Long, ByVal taval As Long, ByVal trflag As Long, ByVal saval As Long, ByVal count As Long) As Integer
Public Declare Function P13_ValPutBits Lib "P13W32.DLL" Alias "_P13_ValPutBits@16" (ByVal oldvalue As Integer, ByVal newfld As Integer, ByVal startbit As Long, ByVal endbit As Long) As Integer
Public Declare Function P13_ValToAscii Lib "P13W32.DLL" Alias "_P13_ValToAscii@16" (ByVal value As Long, ByRef asciistr As String, ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function P13_ValToUpper Lib "P13W32.DLL" Alias "_P13_ValToUpper@4" (ByVal value As Long) As Long
Public Declare Function P13_ValUnpackRTCWD Lib "P13W32.DLL" Alias "_P13_ValUnpackRTCWD@28" (ByVal cwd As Integer, ByRef bcastflag As Long, ByRef mcflag As Long, ByRef taval As Long, ByRef trflag As Long, ByRef saval As Long, ByRef count As Long) As Long

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
Public Const RTCFG_STDA As Long = &H800    '//Use MIL-STD-1553A standard
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
Public Const RTCFG_WIPE123 As Long = &H1000000 '//Initialize data with incrementing values
Public Const RTCFG_WIPECWD As Long = &H2000000 '//Initialize data with command word

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
'*  Interrupt log list configuration options
'*
'**/

Public Const INTCFG_DEFAULT As Long = &H0    '//Select all default settings
Public Const INTCFG_ENABLE As Long = &H0 '//Enable interrupt log list (default)
Public Const INTCFG_DISABLE As Long = &H1    '//Disable interrupt log list

'/**
'*
'*  Monitor configuration options
'*
'**/

Public Const LISTCFG_DEFAULT As Long = &H0   '//Select all default settings
Public Const LISTCFG_PINGPONG As Long = &H0  '//Enable ping-pong mode (default)
Public Const LISTCFG_DISABLE As Long = &H1   '//Disable list buffer
Public Const LISTCFG_CONTINUOUS As Long = &H2    '//Enable continuous mode
Public Const LISTCFG_FREE As Long = &H4  '//Enable free mode
Public Const LISTCFG_NOINT As Long = &H0 '//Do not generate interrupt when list buffer empty/full (default)
Public Const LISTCFG_INT As Long = &H10   '//Generate interrupt when list buffer empty/full

'/**
'*
'*  Info types
'*
'**/

Public Const INFOTYPE_PLAT As Integer = &H1  '//Returns the PC1553-3 platform type
Public Const INFOTYPE_PROD As Integer = &H2  '//Returns the PC1553-3 product type
Public Const INFOTYPE_DASH As Integer = &H3  '//Returns the PC1553-3 dash number
Public Const INFOTYPE_VERSION As Integer = &H4   '//Returns the PC1553-3 version number
Public Const INFOTYPE_DATE As Integer = &H5  '//Returns the PC1553-3 version date
Public Const INFOTYPE_MODEL As Integer = &H6 '//Returns the PC1553-3 model number
Public Const INFOTYPE_MAXCOUNT As Integer = &H7  '//Returns the number of terminals the PC1553-3 can simulate
Public Const INFOTYPE_MULTIMODE As Integer = &H8 '//Returns whether PC1553-3 can simulate multi-modes
Public Const INFOTYPE_ERRORGEN As Integer = &H9  '//Returns whether PC1553-3 can generate errors
Public Const INFOTYPE_CONCURMON As Integer = &HA '//Returns whether PC1553-3 has a concurrent monitor
Public Const INFOTYPE_MONFILTER As Integer = &HB '//Returns whether PC1553-3 has a monitor filter
Public Const INFOTYPE_USERCODE As Integer = &HC  '//Returns whether PC1553-3 handles user code
Public Const INFOTYPE_LISTBUF As Integer = &HD   '//Returns whether PC1553-3 handles list buffering
Public Const INFOTYPE_MONFAST As Integer = &HE   '//Returns whether PC1553-3 has a fast monitor
Public Const INFOTYPE_MONDMA As Integer = &HF    '//Returns whether PC1553-3 has a dma monitor
Public Const INFOTYPE_MONBRAKE As Integer = &H10  '//Returns whether PC1553-3 has a monitor brake
Public Const INFOTYPE_80MHZ As Integer = &H11 '//Returns whether PC1553-3 is using an 80MHz DSP

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

'/**
'*
'*  Bit fields of the message error flag.
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
'*  P13 Host Registers
'*
'**/

Public Const HREG_CTRL As Integer = &H0    '//Host control register (WR)
Public Const HREG_STAT As Integer = &H0    '//Host status register (RD)
Public Const HREG_CONFIG As Integer = &H1  '//Configuration register (RD/WR)
Public Const HREG_CMAIL As Integer = &H2   '//Controller mailbox register (WR)
Public Const HREG_HMAIL As Integer = &H3   '//Host mailbox register (RD)
Public Const HREG_ACCESS As Integer = &H4  '//Access register (RD/WR)
Public Const HREG_PAGE As Integer = &H5    '//Page register (RD/WR)
Public Const HREG_INDSEL As Integer = &H6  '//Indirect register select (RD/WR)
Public Const HREG_INDVAL As Integer = &H7  '//Indirect register value (RD/WR)

'/**
'*
'*  P12 Host Registers
'*
'**/

Public Const HREG_RESP As Integer = &H0    '//Response register (RD)
Public Const HREG_CTRL0 As Integer = &H0   '//Control 0 register (WR)
Public Const HREG_CTRL1 As Integer = &H1   '//Control 1 register (WR)
Public Const HREG_CTRL2 As Integer = &H2   '//Control 2 register (WR)
Public Const HREG_TRIG As Integer = &H4    '//Transmit trigger register (WR)
Public Const HREG_INTCLR As Integer = &H5  '//Interrupt clear register (WR)
Public Const HREG_SYNCCLR As Integer = &H6 '//Sync clear register (WR)

'/**
'*
'*  P13 Host Indirect Registers
'*
'**/

Public Const IREG_CTRL0 As Integer = &H0   '//Control register 0 (RD/WR)
Public Const IREG_CTRL1 As Integer = &H1   '//Control register 1 (RD/WR)
Public Const IREG_CTRL2 As Integer = &H2   '//Control register 2 (RD/WR)
Public Const IREG_DMA As Integer = &H3 '//DMA register (RD/WR)
Public Const IREG_TRIG As Integer = &H4    '//Transmit trigger (WR)
Public Const IREG_RESP As Integer = &H4    '//Response register (RD)
Public Const IREG_INTCLR As Integer = &H5  '//Interrupt clear (RD/WR)
Public Const IREG_SYNCCLR As Integer = &H6 '//Sync clear (RD/WR)

'/**
'*
'*  DSP Registers
'*
'**/

Public Const DREG_HOST As Integer = &H2C40  '//Host status register (RD)
Public Const DREG_INT As Integer = &H2C41   '//Interrupt register
Public Const DREG_CMAIL As Integer = &H2C42 '//Controller mailbox register
Public Const DREG_HMAIL As Integer = &H2C43 '//Host mailbox register
Public Const DREG_DMA As Integer = &H2C44   '//DMA register
Public Const DREG_PAGE As Integer = &H2C45  '//Page register
Public Const DREG_CTRL As Integer = &H2C48  '//Control from host register
Public Const DREG_RESP As Integer = &H2C49  '//Response to host register
Public Const DREG_SWD As Integer = &H2C4A   '//Status word from host register
Public Const DREG_HINT As Integer = &H2C4C  '//Host interrupt register
Public Const DREG_DIN As Integer = &H2C4D   '//DIN register
Public Const DREG_DOUT As Integer = &H2C4E  '//DOUT register

'/**
'*
'*  EDGA Registers
'*
'**/

Public Const EREG_STAT As Integer = &H2C80  '//Status register (RD)
Public Const EREG_STATCLR As Integer = &H2C81   '//Status clear register (WR)
Public Const EREG_STATDEC As Integer = &H2C82   '//Decoder status register (RD)
Public Const EREG_VALA As Integer = &H2C84  '//Decoder word value A register
Public Const EREG_VALAL As Integer = &H2C84 '//Decoder low word value A register
Public Const EREG_VALAH As Integer = &H2C85 '//Decoder high word value A register
Public Const EREG_VALB As Integer = &H2C86  '//Decoder word value B register
Public Const EREG_VALBL As Integer = &H2C86 '//Decoder low word value B register
Public Const EREG_VALBH As Integer = &H2C87 '//Decoder high word value B register
Public Const EREG_GAPE As Integer = &H2C88  '//Encoder gap register
Public Const EREG_CTRLE As Integer = &H2C89 '//Encoder control register
Public Const EREG_VALE As Integer = &H2C8A  '//Encoder value register
Public Const EREG_VALEL As Integer = &H2C8A '//Encoder low value register
Public Const EREG_VALEH As Integer = &H2C8B '//Encoder high value register
Public Const EREG_ERRE As Integer = &H2C8C  '//Encoder error register
Public Const EREG_FT As Integer = &H2C8E    '//Frame time register
Public Const EREG_RST As Integer = &H2C8F   '//Reset register
Public Const EREG_GAPA As Integer = &H2C90  '//Decoder gap time A register
Public Const EREG_GAPB As Integer = &H2C91  '//Decoder gap time B register
Public Const EREG_GAPTO As Integer = &H2C92 '//Decoder gap timeout register
Public Const EREG_CFGD As Integer = &H2C94  '//Decoder configuration register
Public Const EREG_CFGE As Integer = &H2C95  '//Encoder configuration register
Public Const EREG_CFGINT As Integer = &H2C96    '//Interrupt configuration register
Public Const EREG_ID As Integer = &H2C97    '//Identification register

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
Public Const ERR_BADPARAMS As Integer = -11 '//CardOpen() called with bad parameters
Public Const ERR_NOHANDLES As Integer = -12 '//CardOpen() already has allocated too many handles
Public Const ERR_NOCARD As Integer = -13    '//CardOpen() could not find a PC1553-3 card at the specified address
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
Public Const ERR_ACCESS As Integer = -43    '//Unable to write to access register
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
