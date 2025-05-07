'/**
'*
'*  BTICard WIN32 DRIVER  Version 2.6.4  (01/24/2013)
'*  Copyright (c) 2001-2013
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   BTICard.BAS -- 32-bit
'*                       BTICard Driver Include Header File.
'*
'**/

'/**
'*
'*  Structs used by the BTICard Driver.
'*
'**/

Public Type SEQRECORD1553
	typeval As Integer	'//Valid in all versions
	count As Integer	'//Valid in all versions
	timestamp As Long	'//Valid in all versions
	activity As Integer	'//Valid in all versions
	errorval As Integer	'//Valid in all versions
	cwd1 As Integer	'//Valid in all versions
	cwd2 As Integer	'//Valid in all versions
	swd1 As Integer	'//Valid in all versions
	swd2 As Integer	'//Valid in all versions
	datacount As Integer	'//Valid in all versions
	data(0 to 39) As Integer	'//Variable length (don't exceed data[datacount-1])
End Type

Public Type SEQRECORDMORE1553
	timestamph As Long	'//Valid if version of baseval record (SEQRECORD1553) >= 1
	resptime1 As Integer	'//Valid if version of baseval record (SEQRECORD1553) >= 1
	resptime2 As Integer	'//Valid if version of baseval record (SEQRECORD1553) >= 1
End Type

Public Type SEQRECORD429
	typeval As Integer	'//Valid in all versions
	count As Integer	'//Valid in all versions
	timestamp As Long	'//Valid in all versions
	activity As Integer	'//Valid in all versions
	decgap As Integer	'//Valid if version >= 1
	data As Long	'//Valid in all versions
	timestamph As Long	'//Valid if version >= 1
End Type

Public Type SEQRECORD717
	typeval As Integer	'//Valid in all versions
	count As Integer	'//Valid in all versions
	timestamp As Long	'//Valid in all versions
	activity As Integer	'//Valid in all versions
	wordnum As Integer	'//Valid in all versions
	subframe As Integer	'//Valid in all versions
	superframe As Integer	'//Valid in all versions
	data As Integer	'//Valid in all versions
	rsvd9 As Integer	'//Valid if version >= 1
	timestamph As Long	'//Valid if version >= 1
End Type

Public Type SEQRECORD708
	typeval As Integer	'//Valid in all versions
	count As Integer	'//Valid in all versions
	timestamp As Long	'//Valid in all versions
	activity As Integer	'//Valid in all versions
	datacount As Integer	'//Valid in all versions
	data(0 to 99) As Integer	'//Valid in all versions
	extra(0 to 15) As Integer	'//Valid if version >= 1
	bitcount As Integer	'//Valid if version >= 1
	rsvd123 As Integer	'//Valid if version >= 1
	timestamph As Long	'//Valid if version >= 1
End Type

Public Type SEQRECORDCSDB
	typeval As Integer	'//Valid in all versions
	count As Integer	'//Valid in all versions
	timestamp As Long	'//Valid in all versions
	timestamph As Long	'//Valid in all versions
	activity As Integer	'//Valid in all versions
	datacount As Integer	'//Valid in all versions
	data(0 to 31) As Integer	'//Valid in all versions
End Type

Public Type SEQRECORDDIO
	typeval As Integer	'//Valid in all versions
	count As Integer	'//Valid in all versions
	bank As Integer	'//Valid in all versions
	state As Integer	'//Valid in version 0
	timestamp As Long	'//Valid in all versions
	timestamph As Long	'//Valid in all versions
	change As Integer	'//Valid in version 1
	value As Integer	'//Valid in version 1
End Type

Public Type SEQFINDINFO
	pRecFirst As Long
	pRecNext As Long
	pRecLast As Long
End Type

Public Type BTIIRIGTIME
	days As Integer
	hours As Integer
	min As Integer
	sec As Integer
	msec As Integer
	usec As Integer
End Type

'/**
'*
'*  BTICard Driver functions.
'*
'**/

Public Declare Sub BTICard_Add64 Lib "BTICARD.DLL" Alias "_BTICard_Add64@24" (ByRef resulth As Long, ByRef resultl As Long, ByVal valah As Long, ByVal valal As Long, ByVal valbh As Long, ByVal valbl As Long)
Public Declare Function BTICard_AddrDSP Lib "BTICARD.DLL" Alias "_BTICard_AddrDSP@8" (ByVal addr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_AddrHost Lib "BTICARD.DLL" Alias "_BTICard_AddrHost@8" (ByVal addr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_AsciiToMant Lib "BTICARD.DLL" Alias "_BTICard_AsciiToMant@12" (ByRef str As String, ByRef mant As Long, ByRef exp As Long) As Long
Public Declare Function BTICard_BCDToBin Lib "BTICARD.DLL" Alias "_BTICard_BCDToBin@12" (ByVal bcdval As Long, ByVal msb As Long, ByVal lsb As Long) As Long
Public Declare Function BTICard_BinToBCD Lib "BTICARD.DLL" Alias "_BTICard_BinToBCD@16" (ByVal oldbcdval As Long, ByVal binval As Long, ByVal msb As Long, ByVal lsb As Long) As Long
Public Declare Function BTICard_BITConfig Lib "BTICARD.DLL" Alias "_BTICard_BITConfig@8" (ByVal ctrlflags As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_BITInitiate Lib "BTICARD.DLL" Alias "_BTICard_BITInitiate@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_BITStatusClear Lib "BTICARD.DLL" Alias "_BTICard_BITStatusClear@8" (ByVal statval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_BITStatusRd Lib "BTICARD.DLL" Alias "_BTICard_BITStatusRd@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CardClose Lib "BTICARD.DLL" Alias "_BTICard_CardClose@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CardCloseAll Lib "BTICARD.DLL" Alias "_BTICard_CardCloseAll@0" () As Long
Public Declare Function BTICard_CardGetInfo Lib "BTICARD.DLL" Alias "_BTICard_CardGetInfo@12" (ByVal infotype As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CardGetInfoEx Lib "BTICARD.DLL" Alias "_BTICard_CardGetInfoEx@20" (ByRef bufmodel As Integer, ByVal bufmodelcount As Integer, ByRef buffeature As Integer, ByVal buffeaturecount As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_CardIsRunning Lib "BTICARD.DLL" Alias "_BTICard_CardIsRunning@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CardNop Lib "BTICARD.DLL" Alias "_BTICard_CardNop@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CardOpen Lib "BTICARD.DLL" Alias "_BTICard_CardOpen@8" (ByRef lphandle As Long, ByVal cardnum As Long) As Long
Public Declare Function BTICard_CardOpenStr Lib "BTICARD.DLL" Alias "_BTICard_CardOpenStr@8" (ByRef lphandle As Long, ByRef cardstr As String) As Long
Public Declare Function BTICard_CardProductStr Lib "BTICARD.DLL" Alias "_BTICard_CardProductStr@4" (ByVal handleval As Long) As Long
Public Declare Sub BTICard_CardReset Lib "BTICARD.DLL" Alias "_BTICard_CardReset@4" (ByVal handleval As Long)
Public Declare Sub BTICard_CardResetEx Lib "BTICARD.DLL" Alias "_BTICard_CardResetEx@4" (ByVal handleval As Long)
Public Declare Function BTICard_CardResume Lib "BTICARD.DLL" Alias "_BTICard_CardResume@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CardShadow Lib "BTICARD.DLL" Alias "_BTICard_CardShadow@8" (ByVal shadowval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CardStart Lib "BTICARD.DLL" Alias "_BTICard_CardStart@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CardStop Lib "BTICARD.DLL" Alias "_BTICard_CardStop@4" (ByVal handleval As Long) As Long
Public Declare Sub BTICard_CardSyncEnable Lib "BTICARD.DLL" Alias "_BTICard_CardSyncEnable@16" (ByVal enableflag As Long, ByVal syncmask As Integer, ByVal pinpolarity As Integer, ByVal handleval As Long)
Public Declare Function BTICard_CardSyncValid Lib "BTICARD.DLL" Alias "_BTICard_CardSyncValid@4" (ByVal handleval As Long) As Integer
Public Declare Function BTICard_CardTest Lib "BTICARD.DLL" Alias "_BTICard_CardTest@8" (ByVal level As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_CardTest0 Lib "BTICARD.DLL" Alias "_BTICard_CardTest0@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CardTest1 Lib "BTICARD.DLL" Alias "_BTICard_CardTest1@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CardTest2 Lib "BTICARD.DLL" Alias "_BTICard_CardTest2@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CardTest3 Lib "BTICARD.DLL" Alias "_BTICard_CardTest3@4" (ByVal handleval As Long) As Long
Public Declare Sub BTICard_CardTrigger Lib "BTICARD.DLL" Alias "_BTICard_CardTrigger@4" (ByVal handleval As Long)
Public Declare Sub BTICard_CardTriggerEnable Lib "BTICARD.DLL" Alias "_BTICard_CardTriggerEnable@8" (ByVal enableflag As Long, ByVal handleval As Long)
Public Declare Sub BTICard_CardTriggerEnableEx Lib "BTICARD.DLL" Alias "_BTICard_CardTriggerEnableEx@16" (ByVal enableflag As Long, ByVal trigmask As Integer, ByVal pinpolarity As Integer, ByVal handleval As Long)
Public Declare Sub BTICard_CardTriggerEx Lib "BTICARD.DLL" Alias "_BTICard_CardTriggerEx@8" (ByVal trigmask As Integer, ByVal handleval As Long)
Public Declare Function BTICard_CardTriggerValid Lib "BTICARD.DLL" Alias "_BTICard_CardTriggerValid@4" (ByVal handleval As Long) As Integer
Public Declare Function BTICard_CardTypeStr Lib "BTICARD.DLL" Alias "_BTICard_CardTypeStr@4" (ByVal handleval As Long) As Long
Public Declare Sub BTICard_ChDARClr Lib "BTICARD.DLL" Alias "_BTICard_ChDARClr@16" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICard_ChDARGet Lib "BTICARD.DLL" Alias "_BTICard_ChDARGet@16" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_ChDARRdL Lib "BTICARD.DLL" Alias "_BTICard_ChDARRdL@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICard_ChDARRdsW Lib "BTICARD.DLL" Alias "_BTICard_ChDARRdsW@20" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICard_ChDARRdW Lib "BTICARD.DLL" Alias "_BTICard_ChDARRdW@12" (ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_ChDARSet Lib "BTICARD.DLL" Alias "_BTICard_ChDARSet@16" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Sub BTICard_ChDARWrL Lib "BTICARD.DLL" Alias "_BTICard_ChDARWrL@16" (ByVal value As Long, ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Sub BTICard_ChDARWrsW Lib "BTICARD.DLL" Alias "_BTICard_ChDARWrsW@20" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal channum As Long, ByVal handleval As Long)
Public Declare Sub BTICard_ChDARWrW Lib "BTICARD.DLL" Alias "_BTICard_ChDARWrW@16" (ByVal value As Integer, ByVal addrval As Integer, ByVal channum As Long, ByVal handleval As Long)
Public Declare Function BTICard_CISRd Lib "BTICARD.DLL" Alias "_BTICard_CISRd@16" (ByRef buf As Integer, ByVal bufcount As Integer, ByVal cistype As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CISWr Lib "BTICARD.DLL" Alias "_BTICard_CISWr@16" (ByRef buf As Integer, ByVal bufcount As Integer, ByVal cistype As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CommBufRd Lib "BTICARD.DLL" Alias "_BTICard_CommBufRd@8" (ByVal offset As Integer, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_CommBufWr Lib "BTICARD.DLL" Alias "_BTICard_CommBufWr@12" (ByVal value As Integer, ByVal offset As Integer, ByVal handleval As Long)
Public Declare Function BTICard_CommCall Lib "BTICARD.DLL" Alias "_BTICard_CommCall@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CommChannelReconfig Lib "BTICARD.DLL" Alias "_BTICard_CommChannelReconfig@8" (ByVal chmask As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CommCheck Lib "BTICARD.DLL" Alias "_BTICard_CommCheck@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CommDisable Lib "BTICARD.DLL" Alias "_BTICard_CommDisable@8" (ByVal command As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_CommDisableEx Lib "BTICARD.DLL" Alias "_BTICard_CommDisableEx@8" (ByVal command As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_CommEnable Lib "BTICARD.DLL" Alias "_BTICard_CommEnable@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CommExternSRQ Lib "BTICARD.DLL" Alias "_BTICard_CommExternSRQ@8" (ByVal chmask As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CommFillW Lib "BTICARD.DLL" Alias "_BTICard_CommFillW@16" (ByVal value As Integer, ByVal addrval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_CommProtocolFunc Lib "BTICARD.DLL" Alias "_BTICard_CommProtocolFunc@16" (ByVal opcode As Integer, ByVal argcount As Integer, ByRef argbuf As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_CommRdL Lib "BTICARD.DLL" Alias "_BTICard_CommRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CommRdsW Lib "BTICARD.DLL" Alias "_BTICard_CommRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_CommRdW Lib "BTICARD.DLL" Alias "_BTICard_CommRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function BTICard_CommRun Lib "BTICARD.DLL" Alias "_BTICard_CommRun@20" (ByRef dataptr As Integer, ByVal datacount As Integer, ByRef codeptr As Integer, ByVal codecount As Integer, ByVal handleval As Long) As Long
Public Declare Sub BTICard_CommWrL Lib "BTICARD.DLL" Alias "_BTICard_CommWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Function BTICard_CommWrsW Lib "BTICARD.DLL" Alias "_BTICard_CommWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Sub BTICard_CommWrW Lib "BTICARD.DLL" Alias "_BTICard_CommWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Function BTICard_CoProcCheck Lib "BTICARD.DLL" Alias "_BTICard_CoProcCheck@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_CoProcGetInfo Lib "BTICARD.DLL" Alias "_BTICard_CoProcGetInfo@12" (ByRef valueptr As Long, ByVal infotype As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_CoProcMemRdL Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemRdL@12" (ByRef valueptr As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CoProcMemRdsL Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemRdsL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CoProcMemRdsW Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CoProcMemRdW Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemRdW@12" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CoProcMemWrL Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CoProcMemWrsL Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemWrsL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CoProcMemWrsW Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal count As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CoProcMemWrW Lib "BTICARD.DLL" Alias "_BTICard_CoProcMemWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_CoreOpen Lib "BTICARD.DLL" Alias "_BTICard_CoreOpen@12" (ByRef lphcore As Long, ByVal corenum As Long, ByVal hcard As Long) As Long
Public Declare Sub BTICard_DARClr Lib "BTICARD.DLL" Alias "_BTICard_DARClr@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long)
Public Declare Function BTICard_DARGet Lib "BTICARD.DLL" Alias "_BTICard_DARGet@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_DARRdL Lib "BTICARD.DLL" Alias "_BTICard_DARRdL@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Sub BTICard_DARRdsW Lib "BTICARD.DLL" Alias "_BTICard_DARRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long)
Public Declare Function BTICard_DARRdW Lib "BTICARD.DLL" Alias "_BTICard_DARRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_DARSet Lib "BTICARD.DLL" Alias "_BTICard_DARSet@12" (ByVal maskval As Integer, ByVal addrval As Integer, ByVal handleval As Long)
Public Declare Sub BTICard_DARWrL Lib "BTICARD.DLL" Alias "_BTICard_DARWrL@12" (ByVal value As Long, ByVal addrval As Integer, ByVal handleval As Long)
Public Declare Sub BTICard_DARWrsW Lib "BTICARD.DLL" Alias "_BTICard_DARWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_DARWrW Lib "BTICARD.DLL" Alias "_BTICard_DARWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long)
Public Declare Function BTICard_Div Lib "BTICARD.DLL" Alias "_BTICard_Div@8" (ByVal diva As Long, ByVal divb As Long) As Long
Public Declare Sub BTICard_Div64 Lib "BTICARD.DLL" Alias "_BTICard_Div64@24" (ByRef resulth As Long, ByRef resultl As Long, ByVal valah As Long, ByVal valal As Long, ByVal valbh As Long, ByVal valbl As Long)
Public Declare Function BTICard_DllUsageCount Lib "BTICARD.DLL" Alias "_BTICard_DllUsageCount@0" () As Long
Public Declare Function BTICard_DspBioClear Lib "BTICARD.DLL" Alias "_BTICard_DspBioClear@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_DspBioRd Lib "BTICARD.DLL" Alias "_BTICard_DspBioRd@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_DspBioSet Lib "BTICARD.DLL" Alias "_BTICard_DspBioSet@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_DspIntfClear Lib "BTICARD.DLL" Alias "_BTICard_DspIntfClear@8" (ByVal intmask As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_DspIntfRd Lib "BTICARD.DLL" Alias "_BTICard_DspIntfRd@8" (ByVal intmask As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_DspIntmClear Lib "BTICARD.DLL" Alias "_BTICard_DspIntmClear@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_DspIntmSet Lib "BTICARD.DLL" Alias "_BTICard_DspIntmSet@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_DspXfClear Lib "BTICARD.DLL" Alias "_BTICard_DspXfClear@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_DspXfRd Lib "BTICARD.DLL" Alias "_BTICard_DspXfRd@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_DspXfSet Lib "BTICARD.DLL" Alias "_BTICard_DspXfSet@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_ErrDesc Lib "BTICARD.DLL" Alias "_BTICard_ErrDesc@8" (ByVal errval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_ErrDescStr Lib "BTICARD.DLL" Alias "_BTICard_ErrDescStr@8" (ByVal errval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_ErrName Lib "BTICARD.DLL" Alias "_BTICard_ErrName@8" (ByVal errval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_EventLogClear Lib "BTICARD.DLL" Alias "_BTICard_EventLogClear@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_EventLogConfig Lib "BTICARD.DLL" Alias "_BTICard_EventLogConfig@12" (ByVal configval As Integer, ByVal count As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_EventLogRd Lib "BTICARD.DLL" Alias "_BTICard_EventLogRd@16" (ByRef typevalval As Integer, ByRef infoval As Long, ByRef channel As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_EventLogStatus Lib "BTICARD.DLL" Alias "_BTICard_EventLogStatus@4" (ByVal handleval As Long) As Long
Public Declare Sub BTICard_ExpandMant Lib "BTICARD.DLL" Alias "_BTICard_ExpandMant@8" (ByRef mant As Long, ByRef exp As Long)
Public Declare Function BTICard_ExtDinRd Lib "BTICARD.DLL" Alias "_BTICard_ExtDinRd@4" (ByVal handleval As Long) As Long
Public Declare Sub BTICard_ExtDinWr Lib "BTICARD.DLL" Alias "_BTICard_ExtDinWr@8" (ByVal dinval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_ExtDIODirSet Lib "BTICARD.DLL" Alias "_BTICard_ExtDIODirSet@12" (ByVal dionum As Long, ByVal dirval As Long, ByVal handleval As Long)
Public Declare Function BTICard_ExtDIOMonConfig Lib "BTICARD.DLL" Alias "_BTICard_ExtDIOMonConfig@16" (ByVal rise_edge As Integer, ByVal fall_edge As Integer, ByVal banknum As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_ExtDIORd Lib "BTICARD.DLL" Alias "_BTICard_ExtDIORd@8" (ByVal dionum As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICard_ExtDIOWr Lib "BTICARD.DLL" Alias "_BTICard_ExtDIOWr@12" (ByVal dionum As Long, ByVal dioval As Long, ByVal handleval As Long)
Public Declare Function BTICard_ExtLEDRd Lib "BTICARD.DLL" Alias "_BTICard_ExtLEDRd@4" (ByVal handleval As Long) As Long
Public Declare Sub BTICard_ExtLEDWr Lib "BTICARD.DLL" Alias "_BTICard_ExtLEDWr@8" (ByVal ledval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_ExtStatusLEDRd Lib "BTICARD.DLL" Alias "_BTICard_ExtStatusLEDRd@12" (ByRef ledon As Long, ByRef ledcolor As Long, ByVal handleval As Long)
Public Declare Sub BTICard_ExtStatusLEDWr Lib "BTICARD.DLL" Alias "_BTICard_ExtStatusLEDWr@12" (ByVal ledon As Long, ByVal ledcolor As Long, ByVal handleval As Long)
Public Declare Sub BTICard_FileClose Lib "BTICARD.DLL" Alias "_BTICard_FileClose@4" (ByRef handle As Long)
Public Declare Function BTICard_FileErr Lib "BTICARD.DLL" Alias "_BTICard_FileErr@0" () As Long
Public Declare Sub BTICard_FileErrClr Lib "BTICARD.DLL" Alias "_BTICard_FileErrClr@0" ()
Public Declare Sub BTICard_FileErrSet Lib "BTICARD.DLL" Alias "_BTICard_FileErrSet@0" ()
Public Declare Function BTICard_FileOpenRead Lib "BTICARD.DLL" Alias "_BTICard_FileOpenRead@4" (ByRef filename As String) As Long
Public Declare Function BTICard_FileOpenWrite Lib "BTICARD.DLL" Alias "_BTICard_FileOpenWrite@4" (ByRef filename As String) As Long
Public Declare Function BTICard_FileRead Lib "BTICARD.DLL" Alias "_BTICard_FileRead@12" (ByRef handle As Long, ByRef buffer As Long, ByVal count As Integer) As Long
Public Declare Function BTICard_FileSeek Lib "BTICARD.DLL" Alias "_BTICard_FileSeek@8" (ByRef handle As Long, ByVal offset As Long) As Long
Public Declare Function BTICard_FileTell Lib "BTICARD.DLL" Alias "_BTICard_FileTell@4" (ByRef handle As Long) As Long
Public Declare Function BTICard_FileWrite Lib "BTICARD.DLL" Alias "_BTICard_FileWrite@12" (ByRef handle As Long, ByRef buffer As Long, ByVal count As Integer) As Long
Public Declare Function BTICard_GetHigh Lib "BTICARD.DLL" Alias "_BTICard_GetHigh@4" (ByVal val As Long) As Integer
Public Declare Function BTICard_GetLow Lib "BTICARD.DLL" Alias "_BTICard_GetLow@4" (ByVal val As Long) As Integer
Public Declare Function BTICard_GlobalRdW Lib "BTICARD.DLL" Alias "_BTICard_GlobalRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_GlobalWrW Lib "BTICARD.DLL" Alias "_BTICard_GlobalWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long)
Public Declare Function BTICard_HandleInfoEx Lib "BTICARD.DLL" Alias "_BTICard_HandleInfoEx@12" (ByRef valueptr As Long, ByVal typeval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_HandleIsCard Lib "BTICARD.DLL" Alias "_BTICard_HandleIsCard@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_HandleIsCore Lib "BTICARD.DLL" Alias "_BTICard_HandleIsCore@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_HandleMakeCard Lib "BTICARD.DLL" Alias "_BTICard_HandleMakeCard@12" (ByRef lphcard As Long, ByRef lpcorenum As Long, ByVal hcore As Long) As Long
Public Declare Function BTICard_HandleMakeCore Lib "BTICARD.DLL" Alias "_BTICard_HandleMakeCore@12" (ByRef lphcore As Long, ByVal corenum As Long, ByVal hcard As Long) As Long
Public Declare Function BTICard_HandleMakeRPC Lib "BTICARD.DLL" Alias "_BTICard_HandleMakeRPC@12" (ByRef hcard_remote As Long, ByRef lphrpc As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_HandleOkay Lib "BTICARD.DLL" Alias "_BTICard_HandleOkay@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_HeapAlloc Lib "BTICARD.DLL" Alias "_BTICard_HeapAlloc@12" (ByVal section As Long, ByVal wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_HeapAllocAll Lib "BTICARD.DLL" Alias "_BTICard_HeapAllocAll@12" (ByVal section As Long, ByRef wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_HeapAllocEx Lib "BTICARD.DLL" Alias "_BTICard_HeapAllocEx@16" (ByVal configval As Integer, ByVal section As Long, ByVal wordcount As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_HeapWipe Lib "BTICARD.DLL" Alias "_BTICard_HeapWipe@8" (ByVal section As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICard_HPIFill Lib "BTICARD.DLL" Alias "_BTICard_HPIFill@16" (ByVal value As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long)
Public Declare Function BTICard_HPIRdL Lib "BTICARD.DLL" Alias "_BTICard_HPIRdL@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Sub BTICard_HPIRdsL Lib "BTICARD.DLL" Alias "_BTICard_HPIRdsL@16" (ByRef valueptr As Long, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_HPIRdsW Lib "BTICARD.DLL" Alias "_BTICard_HPIRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long)
Public Declare Function BTICard_HPIRdW Lib "BTICARD.DLL" Alias "_BTICard_HPIRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_HPIWrL Lib "BTICARD.DLL" Alias "_BTICard_HPIWrL@12" (ByVal value As Long, ByVal addrval As Integer, ByVal handleval As Long)
Public Declare Sub BTICard_HPIWrsL Lib "BTICARD.DLL" Alias "_BTICard_HPIWrsL@16" (ByRef valueptr As Long, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_HPIWrsW Lib "BTICARD.DLL" Alias "_BTICard_HPIWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_HPIWrW Lib "BTICARD.DLL" Alias "_BTICard_HPIWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long)
Public Declare Function BTICard_IDRegRd Lib "BTICARD.DLL" Alias "_BTICard_IDRegRd@8" (ByVal gate_array_num As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_IDRegWr Lib "BTICARD.DLL" Alias "_BTICard_IDRegWr@12" (ByVal value As Integer, ByVal gate_array_num As Long, ByVal handleval As Long)
Public Declare Sub BTICard_IntClear Lib "BTICARD.DLL" Alias "_BTICard_IntClear@4" (ByVal handleval As Long)
Public Declare Function BTICard_IntDisable Lib "BTICARD.DLL" Alias "_BTICard_IntDisable@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_IntEnable Lib "BTICARD.DLL" Alias "_BTICard_IntEnable@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_IntEnableCond Lib "BTICARD.DLL" Alias "_BTICard_IntEnableCond@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_IntGet Lib "BTICARD.DLL" Alias "_BTICard_IntGet@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_IntInstall Lib "BTICARD.DLL" Alias "_BTICard_IntInstall@8" (ByRef hevent As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICard_IntReset Lib "BTICARD.DLL" Alias "_BTICard_IntReset@4" (ByVal handleval As Long)
Public Declare Function BTICard_IntUninstall Lib "BTICARD.DLL" Alias "_BTICard_IntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_IORdL Lib "BTICARD.DLL" Alias "_BTICard_IORdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_IORdW Lib "BTICARD.DLL" Alias "_BTICard_IORdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function BTICard_IOWINRdW Lib "BTICARD.DLL" Alias "_BTICard_IOWINRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_IOWINWrW Lib "BTICARD.DLL" Alias "_BTICard_IOWINWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_IOWrL Lib "BTICARD.DLL" Alias "_BTICard_IOWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_IOWrW Lib "BTICARD.DLL" Alias "_BTICard_IOWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Function BTICard_IRIGConfig Lib "BTICARD.DLL" Alias "_BTICard_IRIGConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_IRIGFieldGetDays Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetDays@8" (ByVal irigvalh As Long, ByVal irigvall As Long) As Long
Public Declare Function BTICard_IRIGFieldGetHours Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetHours@8" (ByVal irigvalh As Long, ByVal irigvall As Long) As Long
Public Declare Function BTICard_IRIGFieldGetMicrosec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetMicrosec@8" (ByVal irigvalh As Long, ByVal irigvall As Long) As Long
Public Declare Function BTICard_IRIGFieldGetMillisec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetMillisec@8" (ByVal irigvalh As Long, ByVal irigvall As Long) As Long
Public Declare Function BTICard_IRIGFieldGetMin Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetMin@8" (ByVal irigvalh As Long, ByVal irigvall As Long) As Long
Public Declare Function BTICard_IRIGFieldGetSec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldGetSec@8" (ByVal irigvalh As Long, ByVal irigvall As Long) As Long
Public Declare Sub BTICard_IRIGFieldPutDays Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutDays@12" (ByVal value As Long, ByRef irigvalh As Long, ByRef irigvall As Long)
Public Declare Sub BTICard_IRIGFieldPutHours Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutHours@12" (ByVal value As Long, ByRef irigvalh As Long, ByRef irigvall As Long)
Public Declare Sub BTICard_IRIGFieldPutMicrosec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutMicrosec@12" (ByVal value As Long, ByRef irigvalh As Long, ByRef irigvall As Long)
Public Declare Sub BTICard_IRIGFieldPutMillisec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutMillisec@12" (ByVal value As Long, ByRef irigvalh As Long, ByRef irigvall As Long)
Public Declare Sub BTICard_IRIGFieldPutMin Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutMin@12" (ByVal value As Long, ByRef irigvalh As Long, ByRef irigvall As Long)
Public Declare Sub BTICard_IRIGFieldPutSec Lib "BTICARD.DLL" Alias "_BTICard_IRIGFieldPutSec@12" (ByVal value As Long, ByRef irigvalh As Long, ByRef irigvall As Long)
Public Declare Function BTICard_IRIGInputThresholdGet Lib "BTICARD.DLL" Alias "_BTICard_IRIGInputThresholdGet@8" (ByRef dacval As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_IRIGInputThresholdSet Lib "BTICARD.DLL" Alias "_BTICard_IRIGInputThresholdSet@8" (ByVal dacval As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_IRIGRd Lib "BTICARD.DLL" Alias "_BTICard_IRIGRd@8" (ByRef irigtime As BTIIRIGTIME, ByVal handleval As Long) As Long
Public Declare Function BTICard_IRIGRdEx Lib "BTICARD.DLL" Alias "_BTICard_IRIGRdEx@8" (ByRef timebuf As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_IRIGSyncStatus Lib "BTICARD.DLL" Alias "_BTICard_IRIGSyncStatus@4" (ByVal handleval As Long) As Long
Public Declare Sub BTICard_IRIGTimeBCDToBin Lib "BTICARD.DLL" Alias "_BTICard_IRIGTimeBCDToBin@16" (ByRef timevalh As Long, ByRef timevall As Long, ByVal irigvalh As Long, ByVal irigvall As Long)
Public Declare Sub BTICard_IRIGTimeBinToBCD Lib "BTICARD.DLL" Alias "_BTICard_IRIGTimeBinToBCD@16" (ByRef irigvalh As Long, ByRef irigvall As Long, ByVal timevalh As Long, ByVal timevall As Long)
Public Declare Function BTICard_IRIGWr Lib "BTICARD.DLL" Alias "_BTICard_IRIGWr@8" (ByRef irigtime As BTIIRIGTIME, ByVal handleval As Long) As Long
Public Declare Function BTICard_IRIGWrEx Lib "BTICARD.DLL" Alias "_BTICard_IRIGWrEx@8" (ByRef timebuf As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_KernIntStatus Lib "BTICARD.DLL" Alias "_BTICard_KernIntStatus@8" (ByRef valueptr As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_KernStatus Lib "BTICARD.DLL" Alias "_BTICard_KernStatus@12" (ByRef valueptr As Long, ByVal typeval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_KernStatusEx Lib "BTICARD.DLL" Alias "_BTICard_KernStatusEx@16" (ByRef valueptr As Long, ByVal typeval As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_MakeLong Lib "BTICARD.DLL" Alias "_BTICard_MakeLong@8" (ByVal valh As Integer, ByVal vall As Integer) As Long
Public Declare Function BTICard_MakeWord Lib "BTICARD.DLL" Alias "_BTICard_MakeWord@8" (ByVal valh As Byte, ByVal vall As Byte) As Integer
Public Declare Function BTICard_MantToAscii Lib "BTICARD.DLL" Alias "_BTICard_MantToAscii@12" (ByRef buf As String, ByVal mant As Long, ByVal exp As Long) As Long
Public Declare Function BTICard_Mask Lib "BTICARD.DLL" Alias "_BTICard_Mask@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Sub BTICard_MaxMant Lib "BTICARD.DLL" Alias "_BTICard_MaxMant@8" (ByRef mant As Long, ByRef exp As Long)
Public Declare Function BTICard_Mod Lib "BTICARD.DLL" Alias "_BTICard_Mod@8" (ByVal moda As Long, ByVal modb As Long) As Long
Public Declare Sub BTICard_Mod64 Lib "BTICARD.DLL" Alias "_BTICard_Mod64@24" (ByRef resulth As Long, ByRef resultl As Long, ByVal valah As Long, ByVal valal As Long, ByVal valbh As Long, ByVal valbl As Long)
Public Declare Function BTICard_Mul Lib "BTICARD.DLL" Alias "_BTICard_Mul@8" (ByVal mula As Long, ByVal mulb As Long) As Long
Public Declare Sub BTICard_Mul64 Lib "BTICARD.DLL" Alias "_BTICard_Mul64@24" (ByRef resulth As Long, ByRef resultl As Long, ByVal valah As Long, ByVal valal As Long, ByVal valbh As Long, ByVal valbl As Long)
Public Declare Sub BTICard_NormalMant Lib "BTICARD.DLL" Alias "_BTICard_NormalMant@8" (ByRef mant As Long, ByRef exp As Long)
Public Declare Function BTICard_PortRd Lib "BTICARD.DLL" Alias "_BTICard_PortRd@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_PortWr Lib "BTICARD.DLL" Alias "_BTICard_PortWr@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Function BTICard_ProgRdW Lib "BTICARD.DLL" Alias "_BTICard_ProgRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_ProgWrW Lib "BTICARD.DLL" Alias "_BTICard_ProgWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_RAMFill Lib "BTICARD.DLL" Alias "_BTICard_RAMFill@16" (ByVal value As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long)
Public Declare Function BTICard_RAMRdB Lib "BTICARD.DLL" Alias "_BTICard_RAMRdB@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function BTICard_RAMRdL Lib "BTICARD.DLL" Alias "_BTICard_RAMRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICard_RAMRdmL Lib "BTICARD.DLL" Alias "_BTICard_RAMRdmL@16" (ByRef valueptr As Long, ByRef addrptr As Long, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_RAMRdmW Lib "BTICARD.DLL" Alias "_BTICard_RAMRdmW@16" (ByRef valueptr As Integer, ByRef addrptr As Long, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_RAMRdsL Lib "BTICARD.DLL" Alias "_BTICard_RAMRdsL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_RAMRdsW Lib "BTICARD.DLL" Alias "_BTICard_RAMRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long)
Public Declare Function BTICard_RAMRdW Lib "BTICARD.DLL" Alias "_BTICard_RAMRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_RAMWipe Lib "BTICARD.DLL" Alias "_BTICard_RAMWipe@4" (ByVal handleval As Long)
Public Declare Sub BTICard_RAMWipeEx Lib "BTICARD.DLL" Alias "_BTICard_RAMWipeEx@8" (ByVal value As Integer, ByVal handleval As Long)
Public Declare Sub BTICard_RAMWrB Lib "BTICARD.DLL" Alias "_BTICard_RAMWrB@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_RAMWrL Lib "BTICARD.DLL" Alias "_BTICard_RAMWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_RAMWrmL Lib "BTICARD.DLL" Alias "_BTICard_RAMWrmL@16" (ByRef valueptr As Long, ByRef addrptr As Long, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_RAMWrmW Lib "BTICARD.DLL" Alias "_BTICard_RAMWrmW@16" (ByRef valueptr As Integer, ByRef addrptr As Long, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_RAMWrsL Lib "BTICARD.DLL" Alias "_BTICard_RAMWrsL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_RAMWrsW Lib "BTICARD.DLL" Alias "_BTICard_RAMWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_RAMWrW Lib "BTICARD.DLL" Alias "_BTICard_RAMWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Function BTICard_ReverseLong Lib "BTICARD.DLL" Alias "_BTICard_ReverseLong@4" (ByVal value As Long) As Long
Public Declare Function BTICard_ReverseWord Lib "BTICARD.DLL" Alias "_BTICard_ReverseWord@4" (ByVal value As Integer) As Integer
Public Declare Function BTICard_SeqBlkRd Lib "BTICARD.DLL" Alias "_BTICard_SeqBlkRd@16" (ByRef buf As Integer, ByVal bufcount As Long, ByRef blkcnt As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqBlkRdEx Lib "BTICARD.DLL" Alias "_BTICard_SeqBlkRdEx@20" (ByRef buf As Integer, ByVal bufcount As Long, ByVal maxblkcnt As Long, ByRef blkcnt As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqClear Lib "BTICARD.DLL" Alias "_BTICard_SeqClear@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqCommRd Lib "BTICARD.DLL" Alias "_BTICard_SeqCommRd@12" (ByRef buf As Integer, ByVal bufcount As Integer, ByVal handleval As Long) As Integer
Public Declare Function BTICard_SeqConfig Lib "BTICARD.DLL" Alias "_BTICard_SeqConfig@8" (ByVal configval As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqConfigEx Lib "BTICARD.DLL" Alias "_BTICard_SeqConfigEx@16" (ByVal configval As Long, ByVal seqcount As Long, ByVal cardnum As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqConfigExx Lib "BTICARD.DLL" Alias "_BTICard_SeqConfigExx@20" (ByVal configval As Long, ByVal seqaddr As Long, ByVal seqcount As Long, ByVal cardnum As Integer, ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqDMARd Lib "BTICARD.DLL" Alias "_BTICard_SeqDMARd@12" (ByRef buf As Integer, ByVal bufcount As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqFindCheckVersion Lib "BTICARD.DLL" Alias "_BTICard_SeqFindCheckVersion@8" (ByRef precord As Integer, ByVal version As Integer) As Long
Public Declare Function BTICard_SeqFindInit Lib "BTICARD.DLL" Alias "_BTICard_SeqFindInit@12" (ByRef seqbuf As Integer, ByVal seqbufsize As Long, ByRef sfinfo As SEQFINDINFO) As Long
Public Declare Function BTICard_SeqFindMore1553Ex Lib "BTICARD.DLL" Alias "_BTICard_SeqFindMore1553Ex@12" (ByRef precmore As SEQRECORDMORE1553, ByVal recordsize As Integer, ByRef precbase As SEQRECORD1553) As Long
Public Declare Function BTICard_SeqFindNext1553Ex Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNext1553Ex@12" (ByRef precord As SEQRECORD1553, ByVal recordsize As Integer, ByRef sfinfo As SEQFINDINFO) As Long
Public Declare Function BTICard_SeqFindNext429Ex Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNext429Ex@12" (ByRef precord As SEQRECORD429, ByVal recordsize As Integer, ByRef sfinfo As SEQFINDINFO) As Long
Public Declare Function BTICard_SeqFindNext708Ex Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNext708Ex@12" (ByRef precord As SEQRECORD708, ByVal recordsize As Integer, ByRef sfinfo As SEQFINDINFO) As Long
Public Declare Function BTICard_SeqFindNext717Ex Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNext717Ex@12" (ByRef precord As SEQRECORD717, ByVal recordsize As Integer, ByRef sfinfo As SEQFINDINFO) As Long
Public Declare Function BTICard_SeqFindNextCSDBEx Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNextCSDBEx@12" (ByRef precord As SEQRECORDCSDB, ByVal recordsize As Integer, ByRef sfinfo As SEQFINDINFO) As Long
Public Declare Function BTICard_SeqFindNextDIOEx Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNextDIOEx@12" (ByRef precord As SEQRECORDDIO, ByVal recordsize As Integer, ByRef sfinfo As SEQFINDINFO) As Long
Public Declare Function BTICard_SeqFindNextEx Lib "BTICARD.DLL" Alias "_BTICard_SeqFindNextEx@16" (ByRef precord As Integer, ByVal recordcount As Integer, ByRef seqtype As Integer, ByRef sfinfo As SEQFINDINFO) As Long
Public Declare Function BTICard_SeqInterval Lib "BTICARD.DLL" Alias "_BTICard_SeqInterval@12" (ByVal interval As Long, ByVal mode As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqIntervalEx Lib "BTICARD.DLL" Alias "_BTICard_SeqIntervalEx@8" (ByVal shiftval As Integer, ByVal handleval As Long) As Integer
Public Declare Function BTICard_SeqIsRunning Lib "BTICARD.DLL" Alias "_BTICard_SeqIsRunning@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqLogFrequency Lib "BTICARD.DLL" Alias "_BTICard_SeqLogFrequency@8" (ByVal logfreq As Integer, ByVal handleval As Long) As Integer
Public Declare Function BTICard_SeqRd Lib "BTICARD.DLL" Alias "_BTICard_SeqRd@8" (ByRef buf As Integer, ByVal handleval As Long) As Integer
Public Declare Function BTICard_SeqRdEx Lib "BTICARD.DLL" Alias "_BTICard_SeqRdEx@12" (ByRef buf As Integer, ByVal bufcount As Integer, ByVal handleval As Long) As Integer
Public Declare Function BTICard_SeqResume Lib "BTICARD.DLL" Alias "_BTICard_SeqResume@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqStart Lib "BTICARD.DLL" Alias "_BTICard_SeqStart@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqStatus Lib "BTICARD.DLL" Alias "_BTICard_SeqStatus@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_SeqStop Lib "BTICARD.DLL" Alias "_BTICard_SeqStop@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_Shl Lib "BTICARD.DLL" Alias "_BTICard_Shl@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function BTICard_Shr Lib "BTICARD.DLL" Alias "_BTICard_Shr@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function BTICard_SignMant Lib "BTICARD.DLL" Alias "_BTICard_SignMant@4" (ByRef str As String) As Integer
Public Declare Sub BTICard_Sub64 Lib "BTICARD.DLL" Alias "_BTICard_Sub64@24" (ByRef resulth As Long, ByRef resultl As Long, ByVal valah As Long, ByVal valal As Long, ByVal valbh As Long, ByVal valbl As Long)
Public Declare Sub BTICard_SwapEndianL Lib "BTICARD.DLL" Alias "_BTICard_SwapEndianL@4" (ByRef value As Long)
Public Declare Sub BTICard_SwapEndianW Lib "BTICARD.DLL" Alias "_BTICard_SwapEndianW@8" (ByRef valuea As Integer, ByRef valueb As Integer)
Public Declare Sub BTICard_SwapIfBigEndianL Lib "BTICARD.DLL" Alias "_BTICard_SwapIfBigEndianL@4" (ByRef value As Long)
Public Declare Sub BTICard_SwapIfBigEndianW Lib "BTICARD.DLL" Alias "_BTICard_SwapIfBigEndianW@8" (ByRef valuea As Integer, ByRef valueb As Integer)
Public Declare Sub BTICard_SwapIfLittleEndianL Lib "BTICARD.DLL" Alias "_BTICard_SwapIfLittleEndianL@4" (ByRef value As Long)
Public Declare Sub BTICard_SwapIfLittleEndianW Lib "BTICARD.DLL" Alias "_BTICard_SwapIfLittleEndianW@8" (ByRef valuea As Integer, ByRef valueb As Integer)
Public Declare Function BTICard_SysMonClear Lib "BTICARD.DLL" Alias "_BTICard_SysMonClear@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonInit Lib "BTICARD.DLL" Alias "_BTICard_SysMonInit@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonTypeGet Lib "BTICARD.DLL" Alias "_BTICard_SysMonTypeGet@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonDescGet Lib "BTICARD.DLL" Alias "_BTICard_SysMonDescGet@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonMaxRd Lib "BTICARD.DLL" Alias "_BTICard_SysMonMaxRd@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonMinRd Lib "BTICARD.DLL" Alias "_BTICard_SysMonMinRd@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonNomRd Lib "BTICARD.DLL" Alias "_BTICard_SysMonNomRd@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonUserStr Lib "BTICARD.DLL" Alias "_BTICard_SysMonUserStr@12" (ByVal value As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonValRd Lib "BTICARD.DLL" Alias "_BTICard_SysMonValRd@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonValStr Lib "BTICARD.DLL" Alias "_BTICard_SysMonValStr@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonThresholdSet Lib "BTICARD.DLL" Alias "_BTICard_SysMonThresholdSet@20" (ByVal enable As Long, ByVal minval As Long, ByVal maxval As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_SysMonValToDAC Lib "BTICARD.DLL" Alias "_BTICard_SysMonValToDAC@24" (ByVal val As Long, ByVal rangemin As Long, ByVal rangemax As Long, ByVal dacval_max As Integer, ByVal scalefactor As Long, ByVal handleval As Long) As Integer
Public Declare Function BTICard_SysMonDACToVal Lib "BTICARD.DLL" Alias "_BTICard_SysMonDACToVal@24" (ByVal dacval As Integer, ByVal rangemin As Long, ByVal rangemax As Long, ByVal dacval_max As Integer, ByVal scalefactor As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_TickTimerStart Lib "BTICARD.DLL" Alias "_BTICard_TickTimerStart@4" (ByVal milliseconds As Long) As Long
Public Declare Function BTICard_TickTimerValid Lib "BTICARD.DLL" Alias "_BTICard_TickTimerValid@4" (ByVal timer As Long) As Long
Public Declare Function BTICard_Timer64Rd Lib "BTICARD.DLL" Alias "_BTICard_Timer64Rd@12" (ByRef valueh As Long, ByRef valuel As Long, ByVal handleval As Long) As Long
Public Declare Sub BTICard_Timer64Wr Lib "BTICARD.DLL" Alias "_BTICard_Timer64Wr@12" (ByVal valueh As Long, ByVal valuel As Long, ByVal handleval As Long)
Public Declare Sub BTICard_TimerClear Lib "BTICARD.DLL" Alias "_BTICard_TimerClear@4" (ByVal handleval As Long)
Public Declare Function BTICard_TimerRd Lib "BTICARD.DLL" Alias "_BTICard_TimerRd@4" (ByVal handleval As Long) As Long
Public Declare Function BTICard_TimerResolution Lib "BTICARD.DLL" Alias "_BTICard_TimerResolution@8" (ByVal timerresol As Long, ByVal handleval As Long) As Long
Public Declare Function BTICard_TimerResolutionEx Lib "BTICARD.DLL" Alias "_BTICard_TimerResolutionEx@8" (ByVal timershift As Integer, ByVal handleval As Long) As Integer
Public Declare Function BTICard_TimerStatus Lib "BTICARD.DLL" Alias "_BTICard_TimerStatus@4" (ByVal handleval As Long) As Long
Public Declare Sub BTICard_TimerWr Lib "BTICARD.DLL" Alias "_BTICard_TimerWr@8" (ByVal value As Long, ByVal handleval As Long)
Public Declare Function BTICard_ValAsciiCmpi Lib "BTICARD.DLL" Alias "_BTICard_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Long
Public Declare Function BTICard_ValAsciiCpy Lib "BTICARD.DLL" Alias "_BTICard_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Long) As Long
Public Declare Sub BTICard_ValAsciiTrimLead Lib "BTICARD.DLL" Alias "_BTICard_ValAsciiTrimLead@4" (ByRef buf As String)
Public Declare Sub BTICard_ValAsciiTrimTrail Lib "BTICARD.DLL" Alias "_BTICard_ValAsciiTrimTrail@4" (ByRef buf As String)
Public Declare Function BTICard_ValFromAscii Lib "BTICARD.DLL" Alias "_BTICard_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Long) As Long
Public Declare Function BTICard_ValGetBits Lib "BTICARD.DLL" Alias "_BTICard_ValGetBits@12" (ByVal oldvalue As Long, ByVal startbit As Long, ByVal endbit As Long) As Long
Public Declare Function BTICard_ValIncAscii Lib "BTICARD.DLL" Alias "_BTICard_ValIncAscii@4" (ByRef asciistr As String) As Long
Public Declare Function BTICard_ValInccAscii Lib "BTICARD.DLL" Alias "_BTICard_ValInccAscii@4" (ByRef asciistr As String) As Long
Public Declare Function BTICard_ValIsLower Lib "BTICARD.DLL" Alias "_BTICard_ValIsLower@4" (ByVal value As Long) As Long
Public Declare Function BTICard_ValLenAscii Lib "BTICARD.DLL" Alias "_BTICard_ValLenAscii@8" (ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function BTICard_ValPutBits Lib "BTICARD.DLL" Alias "_BTICard_ValPutBits@16" (ByVal oldvalue As Long, ByVal newfld As Long, ByVal startbit As Long, ByVal endbit As Long) As Long
Public Declare Function BTICard_ValToAscii Lib "BTICARD.DLL" Alias "_BTICard_ValToAscii@16" (ByVal value As Long, ByRef asciistr As String, ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function BTICard_ValToUpper Lib "BTICARD.DLL" Alias "_BTICard_ValToUpper@4" (ByVal value As Long) As Long
Public Declare Function BTICard_VARRdL Lib "BTICARD.DLL" Alias "_BTICard_VARRdL@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Sub BTICard_VARRdsW Lib "BTICARD.DLL" Alias "_BTICard_VARRdsW@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long)
Public Declare Function BTICard_VARRdW Lib "BTICARD.DLL" Alias "_BTICard_VARRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Sub BTICard_VARWrL Lib "BTICARD.DLL" Alias "_BTICard_VARWrL@12" (ByVal value As Long, ByVal addrval As Integer, ByVal handleval As Long)
Public Declare Sub BTICard_VARWrsW Lib "BTICARD.DLL" Alias "_BTICard_VARWrsW@16" (ByRef valueptr As Integer, ByVal addrval As Integer, ByVal countval As Long, ByVal handleval As Long)
Public Declare Sub BTICard_VARWrW Lib "BTICARD.DLL" Alias "_BTICard_VARWrW@12" (ByVal value As Integer, ByVal addrval As Integer, ByVal handleval As Long)

'/**
'*
'*  External definitions
'*
'*  Note: To operate the BUSBox in serial (RS-232) mode, set
'*  the BUSBox_SerialMode = TRUE.  Optionally, you can set the
'*  BUSBox_BaudRate = baudvalue, but this defaults to the
'*  suggested 115200 baud.
'*
'**/

'/**
'*
'*  Core number constants
'*
'**/

Public Const COREA As Long = &H0 '//Selects Core A
Public Const COREB As Long = &H1 '//Selects Core B
Public Const COREC As Long = &H2 '//Selects Core C
Public Const CORED As Long = &H3 '//Selects Core D

'/**
'*
'*  Sequential Record configuration options
'*
'**/

Public Const SEQCFG_DEFAULT As Long = &H0    '//Select all default settings
Public Const SEQCFG_FILLHALT As Long = &H0   '//Enable sequential record in fill and halt mode (default)
Public Const SEQCFG_DISABLE As Long = &H1    '//Disable sequential record
Public Const SEQCFG_CONTINUOUS As Long = &H2 '//Enable sequential record in continuous mode
Public Const SEQCFG_DMA As Long = &H4    '//Enable monitor in dma mode
Public Const SEQCFG_FREE As Long = &H8   '//Enable sequential record in free mode
Public Const SEQCFG_DELTA As Long = &H10  '//Enable sequential record in delta mode
Public Const SEQCFG_INTERVAL As Long = &H20   '//Enable sequential record in interval mode
Public Const SEQCFG_NOLOGFULL As Long = &H0  '//Do not generate event log when sequential record is full (default)
Public Const SEQCFG_LOGFULL As Long = &H1000    '//Generate event log when sequential record is full
Public Const SEQCFG_NOLOGFREQ As Long = &H0  '//Do not generate event logs at a user specified frequency (default)
Public Const SEQCFG_LOGFREQ As Long = &H2000    '//Generate event logs at user specified frequency
Public Const SEQCFG_16K As Long = &H0    '//Allocate a 16K sequential record buffer (default)
Public Const SEQCFG_ALLAVAIL As Long = &H1000000   '//Allocate all available memory to a sequential record buffer
Public Const SEQCFG_32K As Long = &H2000000    '//Allocate a 32K sequential record buffer
Public Const SEQCFG_64K As Long = &H4000000    '//Allocate a 64K sequential record buffer
Public Const SEQCFG_128K As Long = &H8000000   '//Allocate a 128K sequential record buffer

'/**
'*
'*  Sequential Record type fields
'*
'**/

Public Const SEQTYPE_MASK As Long = &HFF  '//Sequential record type mask value
Public Const SEQTYPE_429 As Long = &H1   '//Sequential record type is ARINC 429
Public Const SEQTYPE_717 As Long = &H2   '//Sequential record type is ARINC 717
Public Const SEQTYPE_1553 As Long = &H3  '//Sequential record type is MIL-STD-1553
Public Const SEQTYPE_708 As Long = &H4   '//Sequential record type is ARINC 708
Public Const SEQTYPE_USER As Long = &H5  '//Sequential record type is User Defined
Public Const SEQTYPE_CSDB As Long = &H6  '//Sequential record type is CSDB
Public Const SEQTYPE_DIO As Long = &H7   '//Sequential record type is DIO
Public Const SEQTYPE_RESTART As Long = &HFF   '//Sequential record type is Restart

'/**
'*
'*  Sequential Record version fields
'*
'**/

Public Const SEQVER_MASK As Long = &HFF00   '//Sequential record version mask value
Public Const SEQVER_0 As Long = &H0  '//Sequential record version number is 0
Public Const SEQVER_1 As Long = &H100  '//Sequential record version number is 1

'/**
'*
'*  Event log list configuration options
'*
'**/

Public Const LOGCFG_DEFAULT As Long = &H0    '//Select all default settings
Public Const LOGCFG_ENABLE As Long = &H0 '//Enable event log list (default)
Public Const LOGCFG_DISABLE As Long = &H1    '//Disable event log list

'/**
'*
'*  IRIG timer configuration options
'*
'**/

Public Const IRIGCFG_DEFAULT As Long = &H0   '//Select all default settings
Public Const IRIGCFG_ENABLE As Long = &H0    '//Enable IRIG timer (default)
Public Const IRIGCFG_DISABLE As Long = &H1   '//Disable IRIG timer
Public Const IRIGCFG_SPEEDB As Long = &H0    '//Bit rate is IRIGB (default)
Public Const IRIGCFG_SPEEDA As Long = &H2    '//Bit rate is IRIGA
Public Const IRIGCFG_INTERNAL As Long = &H0  '//IRIG timer operates internally (default)
Public Const IRIGCFG_EXTERNAL As Long = &H4  '//IRIG timer operates externally
Public Const IRIGCFG_SLAVE As Long = &H0 '//IRIG timer is a slave  / receiver (default)
Public Const IRIGCFG_MASTER As Long = &H8    '//IRIG timer is a master / transmitter
Public Const IRIGCFG_PPS As Long = &H10   '//IRIG timer operates in PPS mode (rcv/xmt)
Public Const IRIGCFG_PWM As Long = &H0   '//IRIG timer uses pulse width modulated signaling (rcv/xmt) (default)
Public Const IRIGCFG_AM As Long = &H20    '//IRIG timer uses amplitude modulated signaling (rcv only hw dependant)

'/**
'*
'*  IRIG timer field definitions
'*
'**/

Public Const IRIGFIELD_USECLSB As Long = &H0 '//Microseconds LSB in timestamp field
Public Const IRIGFIELD_USECMSB As Long = &HB '//Microseconds MSB in timestamp field
Public Const IRIGFIELD_MSECLSB As Long = &HC '//Milliseconds LSB in timestamp field
Public Const IRIGFIELD_MSECMSB As Long = &H17 '//Milliseconds MSB in timestamp field
Public Const IRIGFIELD_SECLSB As Long = &H18  '//Seconds LSB in timestamp field
Public Const IRIGFIELD_SECMSB As Long = &H1F  '//Seconds MSB in timestamp field
Public Const IRIGFIELD_MINLSB As Long = &H0  '//Minutes LSB in timestamph field
Public Const IRIGFIELD_MINMSB As Long = &H7  '//Minutes MSB in timestamph field
Public Const IRIGFIELD_HRSLSB As Long = &H8  '//Hours LSB in timestamph field
Public Const IRIGFIELD_HRSMSB As Long = &HF  '//Hours MSB in timestamph field
Public Const IRIGFIELD_DAYLSB As Long = &H10  '//Days LSB in timestamph field
Public Const IRIGFIELD_DAYMSB As Long = &H1B  '//Days MSB in timestamph field

'/**
'*
'*  C54x Global Registers
'*
'**/

Public Const C54_GREG_IMR As Long = &H0  '//Interrupt mask register
Public Const C54_GREG_IFR As Long = &H1  '//Interrupt flag register
Public Const C54_GREG_ST0 As Long = &H6  '//Status register 0
Public Const C54_GREG_ST1 As Long = &H7  '//Status register 1
Public Const C54_GREG_AL As Long = &H8   '//Accumulator A low word (bits 15-00)
Public Const C54_GREG_AH As Long = &H9   '//Accumulator A high word (bits 31-16)
Public Const C54_GREG_AG As Long = &HA   '//Accumulator A guars bits (bits 39-32)
Public Const C54_GREG_BL As Long = &HB   '//Accumulator B low word (bits 15-00)
Public Const C54_GREG_BH As Long = &HC   '//Accumulator B high word (bits 31-16)
Public Const C54_GREG_BG As Long = &HD   '//Accumulator B guard bits (bits 39-32
Public Const C54_GREG_T As Long = &HE    '//Temporary register
Public Const C54_GREG_TRN As Long = &HF  '//Transition register
Public Const C54_GREG_AR0 As Long = &H10  '//Auxilliary register 0
Public Const C54_GREG_AR1 As Long = &H11  '//Auxilliary register 1
Public Const C54_GREG_AR2 As Long = &H12  '//Auxilliary register 2
Public Const C54_GREG_AR3 As Long = &H13  '//Auxilliary register 3
Public Const C54_GREG_AR4 As Long = &H14  '//Auxilliary register 4
Public Const C54_GREG_AR5 As Long = &H15  '//Auxilliary register 5
Public Const C54_GREG_AR6 As Long = &H16  '//Auxilliary register 6
Public Const C54_GREG_AR7 As Long = &H17  '//Auxilliary register 7
Public Const C54_GREG_SP As Long = &H18   '//Stack pointer
Public Const C54_GREG_BK As Long = &H19   '//Circular-buffer size register
Public Const C54_GREG_BRC As Long = &H1A  '//Block-repeat counter
Public Const C54_GREG_RSA As Long = &H1B  '//Block-repeat start address
Public Const C54_GREG_REA As Long = &H1C  '//Block-repeat end address
Public Const C54_GREG_PMST As Long = &H1D '//Processor mode status register
Public Const C54_GREG_XPC As Long = &H1E  '//Program counter extension register
Public Const C54_GREG_DRR20 As Long = &H20    '//McBSP0 data receive register high
Public Const C54_GREG_DRR10 As Long = &H21    '//McBSP0 data receive register low
Public Const C54_GREG_DXR20 As Long = &H22    '//McBSP0 data transmit register high
Public Const C54_GREG_DXR10 As Long = &H23    '//McBSP0 data transmit register low
Public Const C54_GREG_TIM As Long = &H24  '//Timer count register
Public Const C54_GREG_PRD As Long = &H25  '//Timer period register
Public Const C54_GREG_TCR As Long = &H26  '//Timer control register
Public Const C54_GREG_SWWSR As Long = &H28    '//External interface software wait-state register
Public Const C54_GREG_BSCR As Long = &H29 '//External interface bank-switching control register
Public Const C54_GREG_SWCR As Long = &H2B '//Software wait-state control register
Public Const C54_GREG_HPIC As Long = &H2C '//Host port interface control register
Public Const C54_GREG_DRR22 As Long = &H30    '//McBSP2 data receive register high
Public Const C54_GREG_DRR12 As Long = &H31    '//McBSP2 data receive register low
Public Const C54_GREG_DXR22 As Long = &H32    '//McBSP2 data transmit register high
Public Const C54_GREG_DXR12 As Long = &H33    '//McBSP2 data transmit register low
Public Const C54_GREG_SPSA2 As Long = &H34    '//McBSP2 sub-address register
Public Const C54_GREG_SPDR2 As Long = &H35    '//McBSP2 sub-address data register
Public Const C54_GREG_SPSA0 As Long = &H38    '//McBSP0 sub-address register
Public Const C54_GREG_SPDR0 As Long = &H39    '//McBSP0 sub-address data register
Public Const C54_GREG_DRR21 As Long = &H40    '//McBSP1 data receive register high
Public Const C54_GREG_DRR11 As Long = &H41    '//McBSP1 data receive register low
Public Const C54_GREG_DXR21 As Long = &H42    '//McBSP1 data transmit register high
Public Const C54_GREG_DXR11 As Long = &H43    '//McBSP1 data transmit register low
Public Const C54_GREG_SPSA1 As Long = &H48    '//McBSP1 sub-address register
Public Const C54_GREG_SPDR1 As Long = &H49    '//McBSP1 sub-address data register
Public Const C54_GREG_DMPREC As Long = &H54   '//DMA channel priority and enable control
Public Const C54_GREG_DMSBAR As Long = &H55   '//DMA channel sub-address register
Public Const C54_GREG_DMADI As Long = &H56    '//DMA channel sub-address data with increment
Public Const C54_GREG_DMADN As Long = &H57    '//DMA channel sub-address data without increment
Public Const C54_GREG_CLKMD As Long = &H58    '//Clock-mode register

'/**
'*
'*  Event types.
'*
'**/

Public Const EVENTTYPE_1553MSG As Long = &H1 '//MIL-STD-1553 message
Public Const EVENTTYPE_1553OPCODE As Long = &H2  '//MIL-STD-1553 event log opcode
Public Const EVENTTYPE_1553HALT As Long = &H3    '//MIL-STD-1553 schedule halt
Public Const EVENTTYPE_1553PAUSE As Long = &H4   '//MIL-STD-1553 schedule pause
Public Const EVENTTYPE_1553LIST As Long = &H5    '//MIL-STD-1553 list buffer empty/full
Public Const EVENTTYPE_1553SERIAL As Long = &H6  '//MIL-STD-1553 serial empty
Public Const EVENTTYPE_429MSG As Long = &H11  '//ARINC 429 message
Public Const EVENTTYPE_429OPCODE As Long = &H12   '//ARINC 429 event log opcode
Public Const EVENTTYPE_429HALT As Long = &H13 '//ARINC 429 schedule halt
Public Const EVENTTYPE_429PAUSE As Long = &H14    '//ARINC 429 schedule pause
Public Const EVENTTYPE_429LIST As Long = &H15 '//ARINC 429 list buffer empty/full
Public Const EVENTTYPE_429ERR As Long = &H16  '//ARINC 429 decoder error detected
Public Const EVENTTYPE_717WORD As Long = &H21 '//ARINC 717 word received
Public Const EVENTTYPE_717SUBFRM As Long = &H22   '//ARINC 717 sub frame completed
Public Const EVENTTYPE_717SYNCERR As Long = &H23  '//ARINC 717 receive channel lost synchronization
Public Const EVENTTYPE_708MSG As Long = &H31  '//ARINC 708 message
Public Const EVENTTYPE_SEQFULL As Long = &H41 '//Sequential record full
Public Const EVENTTYPE_SEQFREQ As Long = &H42 '//Sequential record frequency
Public Const EVENTTYPE_422TXTHRESHOLD As Long = &H51  '//RS-422 TX under threshold
Public Const EVENTTYPE_422TXFIFO As Long = &H52   '//RS-422 TX underflow
Public Const EVENTTYPE_422RXTHRESHOLD As Long = &H53  '//RS-422 RX over threshold
Public Const EVENTTYPE_422RXFIFO As Long = &H54   '//RS-422 RX overflow
Public Const EVENTTYPE_422RXERROR As Long = &H55  '//RS-422 RX error
Public Const EVENTTYPE_CSDBMSG As Long = &H58 '//CSDB message
Public Const EVENTTYPE_CSDBOPCODE As Long = &H59  '//CSDB event log opcode
Public Const EVENTTYPE_CSDBHALT As Long = &H5A    '//CSDB schedule halt
Public Const EVENTTYPE_CSDBPAUSE As Long = &H5B   '//CSDB schedule pause
Public Const EVENTTYPE_CSDBLIST As Long = &H5C    '//CSDB list buffer empty/full
Public Const EVENTTYPE_CSDBERR As Long = &H5D '//CSDB decoder error detected
Public Const EVENTTYPE_CSDBSYNCERR As Long = &H5E '//CSDB receive channel lost synchronization
Public Const EVENTTYPE_DIOEDGE As Long = &H60 '//DIO edge event
Public Const EVENTTYPE_DIOFAULT As Long = &H61    '//DIO fault event
Public Const EVENTTYPE_BITERROR As Long = &H71    '//Built-in Test error event

'/**
'*
'*  Card Info types
'*
'**/

Public Const INFOTYPE_PLAT As Long = &H1 '//Returns the platform type
Public Const INFOTYPE_PROD As Long = &H2 '//Returns the product type
Public Const INFOTYPE_GEN As Long = &H3  '//Returns the generation number
Public Const INFOTYPE_1553COUNT As Long = &H4    '//Returns the 1553 channel count
Public Const INFOTYPE_1553SIZE As Long = &H5 '//Returns the 1553 channel size
Public Const INFOTYPE_429COUNT As Long = &H6 '//Returns the 429 channel count
Public Const INFOTYPE_429SIZE As Long = &H7  '//Returns the 429 channel size
Public Const INFOTYPE_717COUNT As Long = &H8 '//Returns the 717 channel count
Public Const INFOTYPE_717SIZE As Long = &H9  '//Returns the 717 channel size
Public Const INFOTYPE_708COUNT As Long = &HA '//Returns the 708 channel count
Public Const INFOTYPE_708SIZE As Long = &HB  '//Returns the 708 channel size
Public Const INFOTYPE_VERSION As Long = &HC  '//Returns the version number
Public Const INFOTYPE_DATE As Long = &HD '//Returns the version date
Public Const INFOTYPE_CHINFO As Long = &HE   '//Returns the channel info
Public Const INFOTYPE_422COUNT As Long = &HF '//Returns the 422 port count
Public Const INFOTYPE_422SIZE As Long = &H10  '//Returns the 422 port size
Public Const INFOTYPE_CSDBCOUNT As Long = &H11    '//Returns the CSDB channel count
Public Const INFOTYPE_CSDBSIZE As Long = &H12 '//Returns the CSDB channel size
Public Const INFOTYPE_DIOCOUNT As Long = &H13 '//Returns the DIO bank count
Public Const INFOTYPE_DIOSIZE As Long = &H14  '//Returns the DIO bank size
Public Const INFOTYPE_HWGEN As Long = &H15    '//Returns the Hardware Generation

'/**
'*
'*  Co-Processor Info types
'*
'**/

Public Const COPROCINFO_PLAT As Long = &H1   '//Returns the platform type
Public Const COPROCINFO_PROD As Long = &H2   '//Returns the product type
Public Const COPROCINFO_GEN As Long = &H3    '//Returns the generation number
Public Const COPROCINFO_VERSION As Long = &H4    '//Returns the version number (major.minor)
Public Const COPROCINFO_DATE As Long = &H5   '//Returns the version date
Public Const COPROCINFO_CISADDR As Long = &H6    '//Returns the CIS address
Public Const COPROCINFO_DMA As Long = &H7    '//Returns whether or not CoProc supports DMA mode
Public Const COPROCINFO_VERSIONEX As Long = &H9  '//Returns the version number (major.minor.minorminor)

'/**
'*
'*  CIS types
'*
'**/

Public Const CISTYPE_CARD As Long = &H1  '//Select card CIS
Public Const CISTYPE_IOMODULE As Long = &H2  '//Select I/O module CIS
Public Const CISTYPE_PLX As Long = &H3   '//Select PLX EEPROM
Public Const CISTYPE_INFO As Long = &H4  '//Select Info module CIS

'/**
'*
'*  Handle Info types
'*
'**/

Public Const HANDINFO_CORENUM As Long = &H1  '//Returns the Handle Core number

'/**
'*
'*  Trigger flags
'*
'**/

Public Const TRIGMASK_TRIGA As Long = &H1    '//Selects trigger line A
Public Const TRIGMASK_TRIGB As Long = &H2    '//Selects trigger line B
Public Const TRIGMASK_TRIGC As Long = &H4    '//Selects trigger line C
Public Const TRIGVAL_TRIGAOFF As Long = &H0  '//Tests for trigger line A inactive
Public Const TRIGVAL_TRIGAON As Long = &H1   '//Tests for trigger line A active
Public Const TRIGVAL_TRIGBOFF As Long = &H0  '//Tests for trigger line B inactive
Public Const TRIGVAL_TRIGBON As Long = &H2   '//Tests for trigger line B active
Public Const TRIGVAL_TRIGCOFF As Long = &H0  '//Tests for trigger line C inactive
Public Const TRIGVAL_TRIGCON As Long = &H4   '//Tests for trigger line C active
Public Const TRIGPOL_TRIGAL As Long = &H0    '//Sets active low polarity for trigger line A
Public Const TRIGPOL_TRIGAH As Long = &H1    '//Sets active high polarity for trigger line A
Public Const TRIGPOL_TRIGBL As Long = &H0    '//Sets active low polarity for trigger line B
Public Const TRIGPOL_TRIGBH As Long = &H2    '//Sets active high polarity for trigger line B
Public Const TRIGPOL_TRIGCL As Long = &H0    '//Sets active low polarity for trigger line C
Public Const TRIGPOL_TRIGCH As Long = &H4    '//Sets active high polarity for trigger line C

'/**
'*
'*  Sync flags
'*
'**/

Public Const SYNCMASK_SYNCA As Long = &H1    '//Selects sync line A
Public Const SYNCMASK_SYNCB As Long = &H2    '//Selects sync line B
Public Const SYNCMASK_SYNCC As Long = &H4    '//Selects sync line C
Public Const SYNCPOL_SYNCAL As Long = &H0    '//Sets active low polarity for sync line A
Public Const SYNCPOL_SYNCAH As Long = &H1    '//Sets active high polarity for sync line A
Public Const SYNCPOL_SYNCBL As Long = &H0    '//Sets active low polarity for sync line B
Public Const SYNCPOL_SYNCBH As Long = &H2    '//Sets active high polarity for sync line B
Public Const SYNCPOL_SYNCCL As Long = &H0    '//Sets active low polarity for sync line C
Public Const SYNCPOL_SYNCCH As Long = &H4    '//Sets active high polarity for sync line C

'/**
'*
'*  Heap flags.
'*
'**/

Public Const HEAPCFG_DEFAULT As Long = &H0   '//Block is allocated within page
Public Const HEAPCFG_TEST As Long = &H1  '//Returns address but doesn't make it permanent
Public Const HEAPCFG_NULL As Long = &H2  '//Returns address but doesn't mark it as in use
Public Const HEAPCFG_SPAN As Long = &H4  '//Block can span pages
Public Const HEAPCFG_QUICK As Long = &H8 '//Does a quick allocation
Public Const HEAPCFG_NOALIGN As Long = &H10   '//Relaxes alignment rules to help fit
Public Const HEAPSECT_SRAM As Long = &H0 '//Heap section for primary SRAM

'/**
'*
'*  Timer resolutions.
'*
'**/

Public Const TIMERRESOL_1US As Long = 1 '//1us timer resolution 1:11:34 range
Public Const TIMERRESOL_16US As Long = 2    '//16us timer resolution 19:05:19 range
Public Const TIMERRESOL_1024US As Long = 3  '//1024us timer resolution 50 day range

'/**
'*
'*  Timer status.
'*
'**/

Public Const TIMETAG_FORMAT_BIN As Long = 0 '//Timetag will be in binary format
Public Const TIMETAG_FORMAT_BCD As Long = 1 '//Timetag will be in BCD format

'/**
'*
'*  Interval calculation modes.
'*
'**/

Public Const INTERVALMODE_CLOSEST As Long = 1   '//Finds interval closest to value specified
Public Const INTERVALMODE_LESS As Long = 2  '//Finds closest interval less than value specified
Public Const INTERVALMODE_GREATER As Long = 3   '//Finds closest interval more than value specified

'/**
'*
'*  Test flags.
'*
'**/

Public Const TEST_LEVEL_0 As Long = 0   '//Test I/O interface
Public Const TEST_LEVEL_1 As Long = 1   '//Test memory interface
Public Const TEST_LEVEL_2 As Long = 2   '//Test communication process
Public Const TEST_LEVEL_3 As Long = 3   '//Test bus transceiver

'/**
'*
'*  Status flags.
'*
'**/

Public Const STAT_EMPTY As Long = 0 '//Buffer is empty
Public Const STAT_PARTIAL As Long = 1   '//Buffer is partially filled
Public Const STAT_FULL As Long = 2  '//Buffer is full
Public Const STAT_OFF As Long = 3   '//Buffer is off

'/**
'*
'*  SysMon flags
'*
'**/

Public Const SYSMONTYPE_NONE As Long = 0    '//Sensor not present
Public Const SYSMONTYPE_TEMP As Long = 1    '//Temperature sensor
Public Const SYSMONTYPE_VOLTAGE As Long = 2 '//Voltage sensor
Public Const SYSMONTYPE_CURRENT As Long = 3 '//Current sensor

'/**
'*
'*  SysMon Read Constant
'*
'**/

Public Const SYSMONRD_NOTVALID As Long = -1000000   '//SysMon value not available

'/**
'*
'*  BIT flags
'*
'**/

Public Const BITCFG_DEFAULT As Long = &H0    '//Select all default settings
Public Const BITCFG_MEMECC_ENABLE As Long = &H0  '//Enables Stopping card operation on memory ECC failure  ie uncorrectable error(default)
Public Const BITCFG_MEMECC_DISABLE As Long = &H1 '//Disables Stopping card operation on memory ECC failure  ie uncorrectable error
Public Const BITCFG_FPGA_ENABLE As Long = &H0    '//Enables FPGA Single Event Upset (SEU) detection (default)
Public Const BITCFG_FPGA_DISABLE As Long = &H2   '//Disables FPGA Single Event Upset (SEU) detection
Public Const BITCFG_PROTOCOL_ENABLE As Long = &H0    '//Enables Protocol error reporting (default)
Public Const BITCFG_PROTOCOL_DISABLE As Long = &H4   '//Disables Protocol error reporting
Public Const BITCFG_MEMECC_NOLOG As Long = &H0   '//Do not generate event logs when ECC event occurs (default)
Public Const BITCFG_MEMECC_LOG As Long = &H10 '//Generate event logs when ECC event occurs
Public Const BITCFG_FPGA_NOLOG As Long = &H0 '//Do not generate event logs when FPGA Single Event Upset (SEU) event occurs (default)
Public Const BITCFG_FPGA_LOG As Long = &H20   '//Generate event logs when FPGA Single Event Upset (SEU) event occurs
Public Const BITCFG_PROTOCOL_NOLOG As Long = &H0 '//Do not generate event logs when Protocol error occurs (default)
Public Const BITCFG_PROTOCOL_LOG As Long = &H40   '//Generate event logs when Protocol error occurs
Public Const BITCFG_CARD_STOPPED_NOLOG As Long = &H0 '//Do not generate event logs when the card is stopped due to CBIT error (default)
Public Const BITCFG_CARD_STOPPED_LOG As Long = &H80   '//Generate event logs when the card is stopped due to CBIT error
Public Const BITCFG_SYSMON_NOLOG As Long = &H0   '//Do not generate event logs when System Monitor error occurs (default)
Public Const BITCFG_SYSMON_LOG As Long = &H100 '//Generate event logs when System Monitor error occurs

Public Const BITSTAT_NOSTATUS As Long = &H0  '//No errors or warnings for BIT
Public Const BITSTAT_CARD_STOPPED As Long = &H20000000  '//Continuous BIT fatal system error card stopped
Public Const BITSTAT_CBIT_FPGA_ERR As Long = &H10000000 '//Continuous BIT FPGA error (SEU)
Public Const BITSTAT_SINGLE_BIT_ERR As Long = &H8000000    '//Continuous BIT Single Bit Error (Correctable)
Public Const BITSTAT_DOUBLE_BIT_ERR As Long = &H4000000    '//Continuous BIT Double Bit Error
Public Const BITSTAT_SYSMON_ERR As Long = &HFFFF    '//Continuous BIT System Monitor error
Public Const BITSTAT_PROTOCOL_ERR As Long = &HFF0000  '//Continuous BIT Protocol Error

'/**
'*
'*  Other flags.
'*
'**/

Public Const RCV As Long = 0
Public Const XMT As Long = 1

'/**
'*
'*  Error types.
'*
'**/

Public Const ERR_NONE As Long = 0   '//No error
Public Const ERR_UNKNOWN As Long = -1   '//An unexpected error occurred
Public Const ERR_BADVER As Long = -2    '//A bad version was encountered
Public Const ERR_BADPTR As Long = -3    '//A bad pointer was passed
Public Const ERR_NOCORE As Long = -4    '//The specified core number doesn't exist
Public Const ERR_BADPARAMS As Long = -11    '//CardOpen() called with bad parameters
Public Const ERR_NOHANDLES As Long = -12    '//CardOpen() already has allocated too many handles
Public Const ERR_NOCARD As Long = -13   '//CardOpen() could not find a L43 card at the specified address
Public Const ERR_NOIO As Long = -14 '//CardOpen() could not find the I/O ports
Public Const ERR_NOMEM As Long = -15    '//CardOpen() could not find the memory
Public Const ERR_BAD16BIT As Long = -16 '//Card is conflicting with another 16-bit card
Public Const ERR_WRONGMODEL As Long = -17   '//Card does not support this feature
Public Const ERR_NOSEL As Long = -18    '//CardOpen() could not allocate a memory selector
Public Const ERR_LOCK As Long = -19 '//The communication process is locked up
Public Const ERR_TOOMANY As Long = -20  '//Too many channels have been configured
Public Const ERR_BADHANDLE As Long = -21    '//A bad handle was specified
Public Const ERR_GOODHANDLE As Long = -22   '//The handle is still valid and should not be destroyed
Public Const ERR_NOTCHAN As Long = -23  '//Not a valid channel
Public Const ERR_NOTXMT As Long = -24   '//The Transmitter has not been configured
Public Const ERR_NOTRCV As Long = -25   '//The Receiver has not been configured
Public Const ERR_NOTSEQ As Long = -26   '//The Sequential Record has not been configured
Public Const ERR_ALLOC As Long = -27    '//There is not enough memory to allocate
Public Const ERR_VXD As Long = -28  '//An error occurred in the VXD
Public Const ERR_BADLABEL As Long = -29 '//The specified label value is not valid
Public Const ERR_BADSDI As Long = -30   '//The specified sdi value is not valid
Public Const ERR_BADMSG As Long = -31   '//The specified command block is not a message block
Public Const ERR_BADSCHNDX As Long = -32    '//Specified command index is out of range
Public Const ERR_BUFSIZE As Long = -33  '//Insufficient space in user buffer
Public Const ERR_NOCONFIG As Long = -34 '//The card has not been properly configured
Public Const ERR_CONFLICTS As Long = -35    '//Unable to resolve conflicts
Public Const ERR_RANGE As Long = -36    '//Schedule is out of range
Public Const ERR_FACTOR As Long = -37   '//A bad factor value was specified
Public Const ERR_NOIOBOOT As Long = -40 '//Could not talk to IO Boot port of DSP
Public Const ERR_BOOTFULL As Long = -41 '//No space to add boot code
Public Const ERR_BOOTNUM As Long = -42  '//There is no boot code with the specified number
Public Const ERR_ACCESS As Long = -43   '//Unable to write to access register
Public Const ERR_ROMVERIFY As Long = -44    '//Unable to verify the value written to the ROM
Public Const ERR_COUNT As Long = -45    '//An invalid count was specified
Public Const ERR_CRC As Long = -46  '//There was a bad checksum in the HEX file
Public Const ERR_FNAME As Long = -47    '//Bad filenames were specified
Public Const ERR_FRDWR As Long = -48    '//There was an error reading or writing the HEX file
Public Const ERR_HEX As Long = -49  '//There was a bad hex character in the HEX file
Public Const ERR_INDEX As Long = -51    '//The command block index was invalid or the schedule is full
Public Const ERR_NOMSGS As Long = -52   '//No messages specified
Public Const ERR_TYPE As Long = -54 '//There was a bad type value in the HEX file
Public Const ERR_ZEROLEN As Long = -55  '//Zero length was specified
Public Const ERR_BADADDRESS As Long = -56   '//A bad address was specified
Public Const ERR_MSGNDX As Long = -57   '//A bad message index was specified
Public Const ERR_BADTA As Long = -60    '//A bad terminal address was specified
Public Const ERR_BADFRAME As Long = -61 '//A bad frame time was specified
Public Const ERR_NOTBC As Long = -62    '//The BC has not been configured
Public Const ERR_NOTRT As Long = -63    '//The RT has not been configured
Public Const ERR_NOTMON As Long = -64   '//The monitor has not been configured
Public Const ERR_SELFIOFAIL As Long = -71   '//I/O selftest failed
Public Const ERR_SELFMEMFAIL As Long = -72  '//Memory selftest failed
Public Const ERR_SELFCOMMFAIL As Long = -73 '//Communication selftest failed
Public Const ERR_SELFXMTFAIL As Long = -74  '//Transmit selftest failed
Public Const ERR_PLXBUG As Long = -75   '//PLX bug is causing problems
Public Const ERR_NOTSUPPORTED As Long = -76 '//Base class does not support feature
Public Const ERR_DLL As Long = -77  '//A required DLL is missing
Public Const ERR_SEQTYPE As Long = -80  '//Invalid sequential record type value
Public Const ERR_SEQNEXT As Long = -81  '//Next sequential record does not exist
Public Const ERR_SEQFINDINFO As Long = -82  '//The SEQFINDINFO structure is not valid
Public Const ERR_SEQBASEPTR As Long = -83   '//The base pointer passed is invalid
Public Const ERR_SEQMORE As Long = -84  '//More (extended) record data does not exist
Public Const ERR_TIMEOUT As Long = -90  '//Function timed out waiting for data
Public Const ERR_SUBFRMNUM As Long = -101   '//Invalid SubFrame number was specified
Public Const ERR_WORDNUM As Long = -102 '//Invalid Word number was specified
Public Const ERR_NOTINSYNC As Long = -103   '//Not Synchronized to databus
Public Const ERR_SUPERFRM As Long = -104    '//SuperFrame not configured
Public Const ERR_SUPERFRMNUM As Long = -105 '//Invalid SuperFrame number was specified
