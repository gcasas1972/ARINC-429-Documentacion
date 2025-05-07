'/**
'*
'*  PC629-1 WIN32 DRIVER  Version 1.1  (07/05/2002)
'*  Copyright (c) 1999-2002
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   P61W32.BAS -- 32-bit
'*                      PC629-1 Driver Library Include File.
'*
'**/

'/**
'*
'*  PC629-1 Driver functions.
'*
'**/

'/**
'*
'*  Internal functions used by the PC629-1 Driver.
'*
'**/

Public Declare Function PC629_ALTen Lib "P61W32.DLL" Alias "_PC629_ALTen@8" (ByVal altval As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_AXTen Lib "P61W32.DLL" Alias "_PC629_AXTen@8" (ByVal axtval As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_BIT Lib "P61W32.DLL" Alias "_PC629_BIT@4" (ByVal handleval As Long) As Integer
Public Declare Function PC629_BITProm Lib "P61W32.DLL" Alias "_PC629_BITProm@4" (ByVal handleval As Long) As Integer
Public Declare Function PC629_BITRam Lib "P61W32.DLL" Alias "_PC629_BITRam@4" (ByVal handleval As Long) As Integer
Public Declare Function PC629_BITSim Lib "P61W32.DLL" Alias "_PC629_BITSim@4" (ByVal handleval As Long) As Integer
Public Declare Function PC629_CardClose Lib "P61W32.DLL" Alias "_PC629_CardClose@4" (ByVal handleval As Long) As Long
Public Declare Function PC629_CardCloseAll Lib "P61W32.DLL" Alias "_PC629_CardCloseAll@0" () As Long
Public Declare Function PC629_CardOpen Lib "P61W32.DLL" Alias "_PC629_CardOpen@12" (ByVal segval As Long, ByVal portval As Long, ByVal irqval As Long) As Long
Public Declare Function PC629_CardOpenEx Lib "P61W32.DLL" Alias "_PC629_CardOpenEx@4" (ByVal cardnum As Long) As Long
Public Declare Function PC629_Check Lib "P61W32.DLL" Alias "_PC629_Check@12" (ByVal segval As Long, ByVal portval As Long, ByVal irqval As Long) As Long
Public Declare Function PC629_CIDSet Lib "P61W32.DLL" Alias "_PC629_CIDSet@8" (ByVal cidval As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_FileLoad Lib "P61W32.DLL" Alias "_PC629_FileLoad@8" (ByRef filename As String, ByVal handleval As Long) As Integer
Public Declare Function PC629_GapSet Lib "P61W32.DLL" Alias "_PC629_GapSet@16" (ByVal tival As Integer, ByVal tgval As Integer, ByVal sgval As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_IMAFS Lib "P61W32.DLL" Alias "_PC629_IMAFS@4" (ByVal handleval As Long) As Long
Public Declare Function PC629_IntClr Lib "P61W32.DLL" Alias "_PC629_IntClr@4" (ByVal handleval As Long) As Long
Public Declare Function PC629_IntInst Lib "P61W32.DLL" Alias "_PC629_IntInst@12" (ByRef hevent As Long, ByVal optionvals As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_IntUninst Lib "P61W32.DLL" Alias "_PC629_IntUninst@4" (ByVal handleval As Long) As Long
Public Declare Function PC629_IsOn Lib "P61W32.DLL" Alias "_PC629_IsOn@4" (ByVal handleval As Long) As Long
Public Declare Function PC629_PromFill Lib "P61W32.DLL" Alias "_PC629_PromFill@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_PromRdB Lib "P61W32.DLL" Alias "_PC629_PromRdB@8" (ByVal srcaddr As Long, ByVal handleval As Long) As Integer
Public Declare Function PC629_PromRdS Lib "P61W32.DLL" Alias "_PC629_PromRdS@16" (ByVal srcaddr As Long, ByRef destptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_PromWrB Lib "P61W32.DLL" Alias "_PC629_PromWrB@12" (ByVal destaddr As Long, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_PromWrS Lib "P61W32.DLL" Alias "_PC629_PromWrS@16" (ByRef srcptr As Long, ByVal destaddr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_RamBlkAct Lib "P61W32.DLL" Alias "_PC629_RamBlkAct@8" (ByVal blknum As Integer, ByVal handleval As Long) As Integer
Public Declare Function PC629_RamCnt Lib "P61W32.DLL" Alias "_PC629_RamCnt@8" (ByVal blkcnt As Integer, ByVal handleval As Long) As Integer
Public Declare Function PC629_RamFill Lib "P61W32.DLL" Alias "_PC629_RamFill@20" (ByVal blknum As Integer, ByVal startaddr As Integer, ByVal count As Long, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_RamRdS Lib "P61W32.DLL" Alias "_PC629_RamRdS@20" (ByVal blknum As Integer, ByVal srcaddr As Integer, ByRef destptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_RamRdW Lib "P61W32.DLL" Alias "_PC629_RamRdW@12" (ByVal blknum As Integer, ByVal srcaddr As Integer, ByVal handleval As Long) As Integer
Public Declare Function PC629_RamWrS Lib "P61W32.DLL" Alias "_PC629_RamWrS@20" (ByRef srcptr As Long, ByVal blknum As Integer, ByVal destaddr As Integer, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_RamWrW Lib "P61W32.DLL" Alias "_PC629_RamWrW@16" (ByVal blknum As Integer, ByVal destaddr As Integer, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_RegRdDir Lib "P61W32.DLL" Alias "_PC629_RegRdDir@8" (ByVal regnum As Integer, ByVal handleval As Long) As Integer
Public Declare Function PC629_RegRdErr Lib "P61W32.DLL" Alias "_PC629_RegRdErr@4" (ByVal handleval As Long) As Integer
Public Declare Function PC629_RegRdInd Lib "P61W32.DLL" Alias "_PC629_RegRdInd@8" (ByVal regnum As Integer, ByVal handleval As Long) As Integer
Public Declare Function PC629_RegRdLWM Lib "P61W32.DLL" Alias "_PC629_RegRdLWM@4" (ByVal handleval As Long) As Integer
Public Declare Function PC629_RegRdStatus Lib "P61W32.DLL" Alias "_PC629_RegRdStatus@4" (ByVal handleval As Long) As Integer
Public Declare Function PC629_RegRdVect Lib "P61W32.DLL" Alias "_PC629_RegRdVect@4" (ByVal handleval As Long) As Integer
Public Declare Function PC629_RegWrDir Lib "P61W32.DLL" Alias "_PC629_RegWrDir@12" (ByVal regnum As Integer, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_RegWrInd Lib "P61W32.DLL" Alias "_PC629_RegWrInd@12" (ByVal regnum As Integer, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function PC629_Reset Lib "P61W32.DLL" Alias "_PC629_Reset@4" (ByVal handleval As Long) As Long
Public Declare Function PC629_Start Lib "P61W32.DLL" Alias "_PC629_Start@4" (ByVal handleval As Long) As Long
Public Declare Function PC629_Stop Lib "P61W32.DLL" Alias "_PC629_Stop@4" (ByVal handleval As Long) As Long
Public Declare Function PC629_Uncheck Lib "P61W32.DLL" Alias "_PC629_Uncheck@4" (ByVal handleval As Long) As Long
Public Declare Function PC629_UncheckAll Lib "P61W32.DLL" Alias "_PC629_UncheckAll@0" () As Long
Public Declare Function PC629_XFormat Lib "P61W32.DLL" Alias "_PC629_XFormat@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_BIT Lib "P61W32.DLL" Alias "_DRV629_BIT@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_BITProm Lib "P61W32.DLL" Alias "_DRV629_BITProm@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_BITRam Lib "P61W32.DLL" Alias "_DRV629_BITRam@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_BITSim Lib "P61W32.DLL" Alias "_DRV629_BITSim@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_CardClose Lib "P61W32.DLL" Alias "_DRV629_CardClose@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_CardCloseAll Lib "P61W32.DLL" Alias "_DRV629_CardCloseAll@0" () As Long
Public Declare Function DRV629_CardInit Lib "P61W32.DLL" Alias "_DRV629_CardInit@0" () As Long
Public Declare Function DRV629_CardOpen Lib "P61W32.DLL" Alias "_DRV629_CardOpen@12" (ByVal segval As Long, ByVal portval As Long, ByVal irqval As Long) As Long
Public Declare Function DRV629_CardOpenEx Lib "P61W32.DLL" Alias "_DRV629_CardOpenEx@16" (ByRef cardname As String, ByVal segval As Long, ByVal portval As Long, ByVal irqval As Long) As Long
Public Declare Function DRV629_CardOpenExx Lib "P61W32.DLL" Alias "_DRV629_CardOpenExx@24" (ByRef cardname As String, ByVal segval As Long, ByVal portval As Long, ByVal irqval As Long, ByRef happwnd As Long, ByVal uiremovalmsg As Integer) As Long
Public Declare Function DRV629_CardOpenExxx Lib "P61W32.DLL" Alias "_DRV629_CardOpenExxx@4" (ByVal cardnum As Long) As Long
Public Declare Function DRV629_CardOpenExxxx Lib "P61W32.DLL" Alias "_DRV629_CardOpenExxxx@8" (ByVal cardnum As Long, ByRef cardname As String) As Long
Public Declare Function DRV629_Check Lib "P61W32.DLL" Alias "_DRV629_Check@12" (ByVal segval As Long, ByVal portval As Long, ByVal irqval As Long) As Long
Public Declare Function DRV629_Div Lib "P61W32.DLL" Alias "_DRV629_Div@8" (ByVal diva As Long, ByVal divb As Long) As Long
Public Declare Function DRV629_DllUsageCount Lib "P61W32.DLL" Alias "_DRV629_DllUsageCount@0" () As Long
Public Declare Function DRV629_ErrClear Lib "P61W32.DLL" Alias "_DRV629_ErrClear@0" () As Long
Public Declare Function DRV629_ErrGetFlag Lib "P61W32.DLL" Alias "_DRV629_ErrGetFlag@0" () As Long
Public Declare Function DRV629_ErrGetLine Lib "P61W32.DLL" Alias "_DRV629_ErrGetLine@0" () As Long
Public Declare Function DRV629_ErrGetValue Lib "P61W32.DLL" Alias "_DRV629_ErrGetValue@0" () As Long
Public Declare Function DRV629_ErrSet Lib "P61W32.DLL" Alias "_DRV629_ErrSet@8" (ByVal errvalue As Long, ByVal errline As Long) As Long
Public Declare Function DRV629_FileClose Lib "P61W32.DLL" Alias "_DRV629_FileClose@4" (ByRef handle As Long) As Long
Public Declare Function DRV629_FileLoad Lib "P61W32.DLL" Alias "_DRV629_FileLoad@8" (ByRef filename As String, ByVal handleval As Long) As Long
Public Declare Function DRV629_FileOpen Lib "P61W32.DLL" Alias "_DRV629_FileOpen@4" (ByRef filename As String) As Long
Public Declare Function DRV629_FilePush Lib "P61W32.DLL" Alias "_DRV629_FilePush@8" (ByRef handle As Long, ByVal value As Integer) As Long
Public Declare Function DRV629_FileReadB Lib "P61W32.DLL" Alias "_DRV629_FileReadB@12" (ByRef handle As Long, ByRef buffer As Long, ByVal count As Integer) As Long
Public Declare Function DRV629_FileSeek Lib "P61W32.DLL" Alias "_DRV629_FileSeek@8" (ByRef handle As Long, ByVal offset As Long) As Long
Public Declare Function DRV629_FileTell Lib "P61W32.DLL" Alias "_DRV629_FileTell@4" (ByRef handle As Long) As Long
Public Declare Function DRV629_FileWrite Lib "P61W32.DLL" Alias "_DRV629_FileWrite@12" (ByRef handle As Long, ByRef buffer As Long, ByVal count As Integer) As Long
Public Declare Function DRV629_GetCID Lib "P61W32.DLL" Alias "_DRV629_GetCID@4" (ByVal index As Integer) As Integer
Public Declare Function DRV629_GetHandler Lib "P61W32.DLL" Alias "_DRV629_GetHandler@4" (ByVal index As Integer) As Long
Public Declare Function DRV629_GetHigh Lib "P61W32.DLL" Alias "_DRV629_GetHigh@4" (ByVal val As Long) As Integer
Public Declare Function DRV629_GetInitFlag Lib "P61W32.DLL" Alias "_DRV629_GetInitFlag@0" () As Integer
Public Declare Function DRV629_GetLow Lib "P61W32.DLL" Alias "_DRV629_GetLow@4" (ByVal val As Long) As Integer
Public Declare Function DRV629_GetMask1 Lib "P61W32.DLL" Alias "_DRV629_GetMask1@4" (ByVal index As Integer) As Integer
Public Declare Function DRV629_GetMask2 Lib "P61W32.DLL" Alias "_DRV629_GetMask2@4" (ByVal index As Integer) As Integer
Public Declare Function DRV629_GetPromAddr Lib "P61W32.DLL" Alias "_DRV629_GetPromAddr@4" (ByVal index As Integer) As Long
Public Declare Function DRV629_GetTGSG Lib "P61W32.DLL" Alias "_DRV629_GetTGSG@4" (ByVal index As Integer) As Integer
Public Declare Function DRV629_GetTISG Lib "P61W32.DLL" Alias "_DRV629_GetTISG@4" (ByVal index As Integer) As Integer
Public Declare Function DRV629_HandleClose Lib "P61W32.DLL" Alias "_DRV629_HandleClose@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_HandleDel Lib "P61W32.DLL" Alias "_DRV629_HandleDel@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_HandleIns Lib "P61W32.DLL" Alias "_DRV629_HandleIns@24" (ByRef cardname As String, ByVal segval As Long, ByVal portval As Long, ByVal irqval As Long, ByRef happwnd As Long, ByVal uiremovalmsg As Integer) As Long
Public Declare Function DRV629_HandleOkay Lib "P61W32.DLL" Alias "_DRV629_HandleOkay@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_HandleOpen Lib "P61W32.DLL" Alias "_DRV629_HandleOpen@20" (ByRef cardname As String, ByVal segval As Long, ByVal portval As Long, ByVal irqval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_HandleVer Lib "P61W32.DLL" Alias "_DRV629_HandleVer@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_IMAFS Lib "P61W32.DLL" Alias "_DRV629_IMAFS@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_Index Lib "P61W32.DLL" Alias "_DRV629_Index@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_InfoClear Lib "P61W32.DLL" Alias "_DRV629_InfoClear@0" () As Long
Public Declare Function DRV629_InfoGetDesc Lib "P61W32.DLL" Alias "_DRV629_InfoGetDesc@0" () As Long
Public Declare Function DRV629_InfoGetFlag Lib "P61W32.DLL" Alias "_DRV629_InfoGetFlag@0" () As Integer
Public Declare Function DRV629_InfoGetLine Lib "P61W32.DLL" Alias "_DRV629_InfoGetLine@0" () As Long
Public Declare Function DRV629_InfoGetType Lib "P61W32.DLL" Alias "_DRV629_InfoGetType@0" () As Integer
Public Declare Function DRV629_InfoSet Lib "P61W32.DLL" Alias "_DRV629_InfoSet@12" (ByVal infotype As Integer, ByVal infoline As Long, ByVal infodesc As Long) As Long
Public Declare Function DRV629_Insert Lib "P61W32.DLL" Alias "_DRV629_Insert@16" (ByVal selval As Integer, ByVal segval As Integer, ByVal portval As Integer, ByVal irqval As Integer) As Long
Public Declare Function DRV629_IntDisable Lib "P61W32.DLL" Alias "_DRV629_IntDisable@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_IntEnable Lib "P61W32.DLL" Alias "_DRV629_IntEnable@8" (ByVal optionvals As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_IntInstall Lib "P61W32.DLL" Alias "_DRV629_IntInstall@12" (ByRef hevent As Long, ByVal optionvals As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_IntUninstall Lib "P61W32.DLL" Alias "_DRV629_IntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_Isalnum Lib "P61W32.DLL" Alias "_DRV629_Isalnum@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Isalpha Lib "P61W32.DLL" Alias "_DRV629_Isalpha@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Isascii Lib "P61W32.DLL" Alias "_DRV629_Isascii@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Iscntrl Lib "P61W32.DLL" Alias "_DRV629_Iscntrl@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Isdigit Lib "P61W32.DLL" Alias "_DRV629_Isdigit@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Isgraph Lib "P61W32.DLL" Alias "_DRV629_Isgraph@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Ishexstr Lib "P61W32.DLL" Alias "_DRV629_Ishexstr@4" (ByRef str As String) As Integer
Public Declare Function DRV629_Islower Lib "P61W32.DLL" Alias "_DRV629_Islower@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_IsOn Lib "P61W32.DLL" Alias "_DRV629_IsOn@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_Isprint Lib "P61W32.DLL" Alias "_DRV629_Isprint@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Ispunct Lib "P61W32.DLL" Alias "_DRV629_Ispunct@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Isseparate Lib "P61W32.DLL" Alias "_DRV629_Isseparate@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Isspace Lib "P61W32.DLL" Alias "_DRV629_Isspace@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Isupper Lib "P61W32.DLL" Alias "_DRV629_Isupper@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Isxdigit Lib "P61W32.DLL" Alias "_DRV629_Isxdigit@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_KernEnd Lib "P61W32.DLL" Alias "_DRV629_KernEnd@4" (ByRef vxdptr As Long) As Long
Public Declare Function DRV629_KernIntClear Lib "P61W32.DLL" Alias "_DRV629_KernIntClear@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_KernIntInstall Lib "P61W32.DLL" Alias "_DRV629_KernIntInstall@8" (ByRef hevent As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernIntUninstall Lib "P61W32.DLL" Alias "_DRV629_KernIntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_KernIOEmptyB Lib "P61W32.DLL" Alias "_DRV629_KernIOEmptyB@16" (ByRef valueptr As Byte, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernIOFillB Lib "P61W32.DLL" Alias "_DRV629_KernIOFillB@16" (ByVal value As Byte, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernIORdB Lib "P61W32.DLL" Alias "_DRV629_KernIORdB@12" (ByRef valueptr As Byte, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernIORdsB Lib "P61W32.DLL" Alias "_DRV629_KernIORdsB@16" (ByRef valueptr As Byte, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernIORdW Lib "P61W32.DLL" Alias "_DRV629_KernIORdW@12" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernIOWrB Lib "P61W32.DLL" Alias "_DRV629_KernIOWrB@12" (ByVal value As Byte, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernIOWrsB Lib "P61W32.DLL" Alias "_DRV629_KernIOWrsB@16" (ByRef valueptr As Byte, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernIOWrW Lib "P61W32.DLL" Alias "_DRV629_KernIOWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMFillW Lib "P61W32.DLL" Alias "_DRV629_KernMEMFillW@16" (ByVal value As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMRdB Lib "P61W32.DLL" Alias "_DRV629_KernMEMRdB@12" (ByRef valueptr As Byte, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMRdL Lib "P61W32.DLL" Alias "_DRV629_KernMEMRdL@12" (ByRef valueptr As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMRdsL Lib "P61W32.DLL" Alias "_DRV629_KernMEMRdsL@16" (ByRef bufptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMRdsW Lib "P61W32.DLL" Alias "_DRV629_KernMEMRdsW@16" (ByRef bufptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMRdW Lib "P61W32.DLL" Alias "_DRV629_KernMEMRdW@12" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMWrB Lib "P61W32.DLL" Alias "_DRV629_KernMEMWrB@12" (ByVal value As Byte, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMWrL Lib "P61W32.DLL" Alias "_DRV629_KernMEMWrL@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMWrsL Lib "P61W32.DLL" Alias "_DRV629_KernMEMWrsL@16" (ByRef bufptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMWrsW Lib "P61W32.DLL" Alias "_DRV629_KernMEMWrsW@16" (ByRef bufptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernMEMWrW Lib "P61W32.DLL" Alias "_DRV629_KernMEMWrW@12" (ByVal value As Integer, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernQuick Lib "P61W32.DLL" Alias "_DRV629_KernQuick@8" (ByVal flag As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_KernStatusEx Lib "P61W32.DLL" Alias "_DRV629_KernStatusEx@16" (ByRef valueptr As Long, ByVal typeval As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_LineClr Lib "P61W32.DLL" Alias "_DRV629_LineClr@0" () As Long
Public Declare Function DRV629_LineGet Lib "P61W32.DLL" Alias "_DRV629_LineGet@0" () As Long
Public Declare Function DRV629_LineInc Lib "P61W32.DLL" Alias "_DRV629_LineInc@0" () As Long
Public Declare Function DRV629_MakeLong Lib "P61W32.DLL" Alias "_DRV629_MakeLong@8" (ByVal valh As Integer, ByVal vall As Integer) As Long
Public Declare Function DRV629_Mask Lib "P61W32.DLL" Alias "_DRV629_Mask@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function DRV629_MemCrc Lib "P61W32.DLL" Alias "_DRV629_MemCrc@12" (ByVal addrval As Integer, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_MemCrcVal Lib "P61W32.DLL" Alias "_DRV629_MemCrcVal@8" (ByVal crc As Long, ByVal value As Byte) As Long
Public Declare Function DRV629_MemRdB Lib "P61W32.DLL" Alias "_DRV629_MemRdB@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function DRV629_MemRdL Lib "P61W32.DLL" Alias "_DRV629_MemRdL@8" (ByVal addrval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_MemRdsW Lib "P61W32.DLL" Alias "_DRV629_MemRdsW@16" (ByRef dataptr As Long, ByVal addrval As Integer, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_MemRdW Lib "P61W32.DLL" Alias "_DRV629_MemRdW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function DRV629_MemStosW Lib "P61W32.DLL" Alias "_DRV629_MemStosW@16" (ByVal addrval As Integer, ByVal dataval As Integer, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_MemStosWR Lib "P61W32.DLL" Alias "_DRV629_MemStosWR@12" (ByVal addrval As Integer, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_MemWrB Lib "P61W32.DLL" Alias "_DRV629_MemWrB@12" (ByVal addrval As Integer, ByVal dataval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_MemWrL Lib "P61W32.DLL" Alias "_DRV629_MemWrL@12" (ByVal addrval As Integer, ByVal dataval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_MemWrsW Lib "P61W32.DLL" Alias "_DRV629_MemWrsW@16" (ByVal addrval As Integer, ByRef dataptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_MemWrW Lib "P61W32.DLL" Alias "_DRV629_MemWrW@12" (ByVal addrval As Integer, ByVal dataval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_Mod Lib "P61W32.DLL" Alias "_DRV629_Mod@8" (ByVal moda As Long, ByVal modb As Long) As Long
Public Declare Function DRV629_Mul Lib "P61W32.DLL" Alias "_DRV629_Mul@8" (ByVal mula As Long, ByVal mulb As Long) As Long
Public Declare Function DRV629_Nocomment Lib "P61W32.DLL" Alias "_DRV629_Nocomment@4" (ByRef str As String) As Long
Public Declare Function DRV629_OpExec Lib "P61W32.DLL" Alias "_DRV629_OpExec@12" (ByVal opcode As Integer, ByVal value As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_OpGet Lib "P61W32.DLL" Alias "_DRV629_OpGet@4" (ByRef opstr As String) As Integer
Public Declare Function DRV629_PortInB Lib "P61W32.DLL" Alias "_DRV629_PortInB@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function DRV629_PortInsB Lib "P61W32.DLL" Alias "_DRV629_PortInsB@16" (ByVal addrval As Integer, ByRef dataptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PortInsW Lib "P61W32.DLL" Alias "_DRV629_PortInsW@16" (ByVal addrval As Integer, ByRef dataptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PortInW Lib "P61W32.DLL" Alias "_DRV629_PortInW@8" (ByVal addrval As Integer, ByVal handleval As Long) As Integer
Public Declare Function DRV629_PortLodsB Lib "P61W32.DLL" Alias "_DRV629_PortLodsB@12" (ByVal addrval As Integer, ByVal cntval As Long, ByVal handleval As Long) As Integer
Public Declare Function DRV629_PortLodsW Lib "P61W32.DLL" Alias "_DRV629_PortLodsW@12" (ByVal addrval As Integer, ByVal cntval As Long, ByVal handleval As Long) As Integer
Public Declare Function DRV629_PortOutB Lib "P61W32.DLL" Alias "_DRV629_PortOutB@12" (ByVal addrval As Integer, ByVal dataval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PortOutsB Lib "P61W32.DLL" Alias "_DRV629_PortOutsB@16" (ByVal addrval As Integer, ByRef dataptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PortOutsW Lib "P61W32.DLL" Alias "_DRV629_PortOutsW@16" (ByVal addrval As Integer, ByRef dataptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PortOutW Lib "P61W32.DLL" Alias "_DRV629_PortOutW@12" (ByVal addrval As Integer, ByVal dataval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PortStepB Lib "P61W32.DLL" Alias "_DRV629_PortStepB@20" (ByVal addrval As Integer, ByVal dataval As Integer, ByVal cntval As Long, ByVal stepval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PortStosB Lib "P61W32.DLL" Alias "_DRV629_PortStosB@16" (ByVal addrval As Integer, ByVal dataval As Integer, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_PortStosBR Lib "P61W32.DLL" Alias "_DRV629_PortStosBR@12" (ByVal addrval As Integer, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_PortStosW Lib "P61W32.DLL" Alias "_DRV629_PortStosW@16" (ByVal addrval As Integer, ByVal dataval As Integer, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromFill Lib "P61W32.DLL" Alias "_DRV629_PromFill@16" (ByVal addrval As Long, ByVal value As Integer, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromFillR Lib "P61W32.DLL" Alias "_DRV629_PromFillR@12" (ByVal addrval As Long, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromFillStep Lib "P61W32.DLL" Alias "_DRV629_PromFillStep@20" (ByVal addrval As Long, ByVal value As Integer, ByVal cntval As Long, ByVal stepval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromIns Lib "P61W32.DLL" Alias "_DRV629_PromIns@16" (ByVal addrval As Long, ByRef dataptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromLoc Lib "P61W32.DLL" Alias "_DRV629_PromLoc@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromLod Lib "P61W32.DLL" Alias "_DRV629_PromLod@8" (ByVal cntval As Long, ByVal handleval As Long) As Integer
Public Declare Function DRV629_PromOffsetFill Lib "P61W32.DLL" Alias "_DRV629_PromOffsetFill@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromOuts Lib "P61W32.DLL" Alias "_DRV629_PromOuts@16" (ByVal addrval As Long, ByRef dataptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromRdB Lib "P61W32.DLL" Alias "_DRV629_PromRdB@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function DRV629_PromRdL Lib "P61W32.DLL" Alias "_DRV629_PromRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromRdW Lib "P61W32.DLL" Alias "_DRV629_PromRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function DRV629_PromStep Lib "P61W32.DLL" Alias "_DRV629_PromStep@16" (ByVal value As Integer, ByVal cntval As Long, ByVal stepval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromSto Lib "P61W32.DLL" Alias "_DRV629_PromSto@12" (ByVal value As Integer, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromStoR Lib "P61W32.DLL" Alias "_DRV629_PromStoR@8" (ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromWrB Lib "P61W32.DLL" Alias "_DRV629_PromWrB@12" (ByVal addrval As Long, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromWrL Lib "P61W32.DLL" Alias "_DRV629_PromWrL@12" (ByVal addrval As Long, ByVal value As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_PromWrW Lib "P61W32.DLL" Alias "_DRV629_PromWrW@12" (ByVal addrval As Long, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamBlkAddr Lib "P61W32.DLL" Alias "_DRV629_RamBlkAddr@8" (ByVal blknum As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamBlkCnt Lib "P61W32.DLL" Alias "_DRV629_RamBlkCnt@8" (ByVal blkcnt As Integer, ByVal handleval As Long) As Integer
Public Declare Function DRV629_RamBlkCount Lib "P61W32.DLL" Alias "_DRV629_RamBlkCount@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RamBlkCurr Lib "P61W32.DLL" Alias "_DRV629_RamBlkCurr@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RamBlkFill Lib "P61W32.DLL" Alias "_DRV629_RamBlkFill@20" (ByVal blkval As Integer, ByVal startaddr As Long, ByVal count As Long, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamBlkSize Lib "P61W32.DLL" Alias "_DRV629_RamBlkSize@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_RamFill Lib "P61W32.DLL" Alias "_DRV629_RamFill@16" (ByVal addrval As Long, ByVal value As Integer, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamFillR Lib "P61W32.DLL" Alias "_DRV629_RamFillR@12" (ByVal addrval As Long, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamLods Lib "P61W32.DLL" Alias "_DRV629_RamLods@16" (ByVal addrval As Long, ByRef dataptr As Byte, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamPageCrc Lib "P61W32.DLL" Alias "_DRV629_RamPageCrc@8" (ByVal pageval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamRdB Lib "P61W32.DLL" Alias "_DRV629_RamRdB@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function DRV629_RamRdL Lib "P61W32.DLL" Alias "_DRV629_RamRdL@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamRdW Lib "P61W32.DLL" Alias "_DRV629_RamRdW@8" (ByVal addrval As Long, ByVal handleval As Long) As Integer
Public Declare Function DRV629_RamStos Lib "P61W32.DLL" Alias "_DRV629_RamStos@16" (ByVal addrval As Long, ByRef dataptr As Byte, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamSwitch Lib "P61W32.DLL" Alias "_DRV629_RamSwitch@8" (ByVal blknum As Integer, ByVal handleval As Long) As Integer
Public Declare Function DRV629_RamWrB Lib "P61W32.DLL" Alias "_DRV629_RamWrB@12" (ByVal addrval As Long, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamWrL Lib "P61W32.DLL" Alias "_DRV629_RamWrL@12" (ByVal addrval As Long, ByVal value As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_RamWrW Lib "P61W32.DLL" Alias "_DRV629_RamWrW@12" (ByVal addrval As Long, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_Rand Lib "P61W32.DLL" Alias "_DRV629_Rand@0" () As Integer
Public Declare Function DRV629_RegInsProm Lib "P61W32.DLL" Alias "_DRV629_RegInsProm@12" (ByRef dataptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegLodPort Lib "P61W32.DLL" Alias "_DRV629_RegLodPort@8" (ByVal cntval As Long, ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegOutsProm Lib "P61W32.DLL" Alias "_DRV629_RegOutsProm@12" (ByRef dataptr As Long, ByVal cntval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegRdCtrl Lib "P61W32.DLL" Alias "_DRV629_RegRdCtrl@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdDir Lib "P61W32.DLL" Alias "_DRV629_RegRdDir@8" (ByVal regnum As Integer, ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdErr Lib "P61W32.DLL" Alias "_DRV629_RegRdErr@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdInd Lib "P61W32.DLL" Alias "_DRV629_RegRdInd@8" (ByVal regnum As Integer, ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdIntVect Lib "P61W32.DLL" Alias "_DRV629_RegRdIntVect@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdLast Lib "P61W32.DLL" Alias "_DRV629_RegRdLast@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdMemCfg Lib "P61W32.DLL" Alias "_DRV629_RegRdMemCfg@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdMemPage Lib "P61W32.DLL" Alias "_DRV629_RegRdMemPage@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdPort Lib "P61W32.DLL" Alias "_DRV629_RegRdPort@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdPortSel Lib "P61W32.DLL" Alias "_DRV629_RegRdPortSel@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdProm Lib "P61W32.DLL" Alias "_DRV629_RegRdProm@8" (ByVal cntval As Long, ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegRdStatus Lib "P61W32.DLL" Alias "_DRV629_RegRdStatus@4" (ByVal handleval As Long) As Integer
Public Declare Function DRV629_RegStepPort Lib "P61W32.DLL" Alias "_DRV629_RegStepPort@16" (ByVal value As Integer, ByVal cntval As Long, ByVal stepval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegStepProm Lib "P61W32.DLL" Alias "_DRV629_RegStepProm@16" (ByVal value As Integer, ByVal cntval As Long, ByVal stepval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegStoPort Lib "P61W32.DLL" Alias "_DRV629_RegStoPort@12" (ByVal value As Integer, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegStoRPort Lib "P61W32.DLL" Alias "_DRV629_RegStoRPort@8" (ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrCID Lib "P61W32.DLL" Alias "_DRV629_RegWrCID@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrClrInt Lib "P61W32.DLL" Alias "_DRV629_RegWrClrInt@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrCtrl Lib "P61W32.DLL" Alias "_DRV629_RegWrCtrl@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrDir Lib "P61W32.DLL" Alias "_DRV629_RegWrDir@12" (ByVal regnum As Integer, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrInd Lib "P61W32.DLL" Alias "_DRV629_RegWrInd@12" (ByVal regnum As Integer, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrMemCfg Lib "P61W32.DLL" Alias "_DRV629_RegWrMemCfg@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrMemPage Lib "P61W32.DLL" Alias "_DRV629_RegWrMemPage@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrPort Lib "P61W32.DLL" Alias "_DRV629_RegWrPort@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrPortSel Lib "P61W32.DLL" Alias "_DRV629_RegWrPortSel@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrProm Lib "P61W32.DLL" Alias "_DRV629_RegWrProm@12" (ByVal value As Integer, ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrReset Lib "P61W32.DLL" Alias "_DRV629_RegWrReset@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrRProm Lib "P61W32.DLL" Alias "_DRV629_RegWrRProm@8" (ByVal cntval As Long, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrSegSel Lib "P61W32.DLL" Alias "_DRV629_RegWrSegSel@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrTGSG Lib "P61W32.DLL" Alias "_DRV629_RegWrTGSG@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_RegWrTISG Lib "P61W32.DLL" Alias "_DRV629_RegWrTISG@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_Reset Lib "P61W32.DLL" Alias "_DRV629_Reset@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_SetCID Lib "P61W32.DLL" Alias "_DRV629_SetCID@8" (ByVal cidval As Integer, ByVal index As Integer) As Long
Public Declare Function DRV629_SetHandler Lib "P61W32.DLL" Alias "_DRV629_SetHandler@8" (ByRef funcval As Long, ByVal index As Integer) As Long
Public Declare Function DRV629_SetInitFlag Lib "P61W32.DLL" Alias "_DRV629_SetInitFlag@4" (ByVal flagval As Integer) As Long
Public Declare Function DRV629_SetMask1 Lib "P61W32.DLL" Alias "_DRV629_SetMask1@8" (ByVal mask1val As Integer, ByVal index As Integer) As Long
Public Declare Function DRV629_SetMask2 Lib "P61W32.DLL" Alias "_DRV629_SetMask2@8" (ByVal mask2val As Integer, ByVal index As Integer) As Long
Public Declare Function DRV629_SetPromAddr Lib "P61W32.DLL" Alias "_DRV629_SetPromAddr@8" (ByVal addrval As Long, ByVal index As Integer) As Long
Public Declare Function DRV629_SetTGSG Lib "P61W32.DLL" Alias "_DRV629_SetTGSG@8" (ByVal tgsgval As Integer, ByVal index As Integer) As Long
Public Declare Function DRV629_SetTISG Lib "P61W32.DLL" Alias "_DRV629_SetTISG@8" (ByVal tisgval As Integer, ByVal index As Integer) As Long
Public Declare Function DRV629_Shl Lib "P61W32.DLL" Alias "_DRV629_Shl@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function DRV629_Shr Lib "P61W32.DLL" Alias "_DRV629_Shr@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function DRV629_Srand Lib "P61W32.DLL" Alias "_DRV629_Srand@4" (ByVal value As Integer) As Long
Public Declare Function DRV629_Start Lib "P61W32.DLL" Alias "_DRV629_Start@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_Stop Lib "P61W32.DLL" Alias "_DRV629_Stop@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_Strchrr Lib "P61W32.DLL" Alias "_DRV629_Strchrr@8" (ByRef str As String, ByVal value As Integer) As Long
Public Declare Function DRV629_Strcmp Lib "P61W32.DLL" Alias "_DRV629_Strcmp@8" (ByRef str1 As String, ByRef str2 As String) As Long
Public Declare Function DRV629_Strcmpi Lib "P61W32.DLL" Alias "_DRV629_Strcmpi@8" (ByRef str1 As String, ByRef str2 As String) As Long
Public Declare Function DRV629_Strcpy Lib "P61W32.DLL" Alias "_DRV629_Strcpy@8" (ByRef tostr As String, ByRef fromstr As String) As Long
Public Declare Function DRV629_Stricmp Lib "P61W32.DLL" Alias "_DRV629_Stricmp@8" (ByRef str1 As String, ByRef str2 As String) As Long
Public Declare Function DRV629_Strlen Lib "P61W32.DLL" Alias "_DRV629_Strlen@4" (ByRef str As String) As Integer
Public Declare Function DRV629_Strlwr Lib "P61W32.DLL" Alias "_DRV629_Strlwr@4" (ByRef str As String) As Long
Public Declare Function DRV629_Strmfe Lib "P61W32.DLL" Alias "_DRV629_Strmfe@12" (ByRef newname As String, ByRef oldname As String, ByRef ext As String) As Long
Public Declare Function DRV629_Strncmp Lib "P61W32.DLL" Alias "_DRV629_Strncmp@12" (ByRef str1 As String, ByRef str2 As String, ByVal count As Integer) As Long
Public Declare Function DRV629_Strncpy Lib "P61W32.DLL" Alias "_DRV629_Strncpy@12" (ByRef tostr As String, ByRef fromstr As String, ByVal count As Integer) As Long
Public Declare Function DRV629_Strpfe Lib "P61W32.DLL" Alias "_DRV629_Strpfe@12" (ByRef newname As String, ByRef oldname As String, ByRef ext As String) As Long
Public Declare Function DRV629_Strtok Lib "P61W32.DLL" Alias "_DRV629_Strtok@8" (ByRef str As String, ByRef tokenstr As String) As Long
Public Declare Function DRV629_Strupr Lib "P61W32.DLL" Alias "_DRV629_Strupr@4" (ByRef str As String) As Long
Public Declare Function DRV629_TableAddrGet Lib "P61W32.DLL" Alias "_DRV629_TableAddrGet@4" (ByVal index As Integer) As Integer
Public Declare Function DRV629_TableAddrSet Lib "P61W32.DLL" Alias "_DRV629_TableAddrSet@8" (ByVal index As Integer, ByVal value As Integer) As Long
Public Declare Function DRV629_TableIrqGet Lib "P61W32.DLL" Alias "_DRV629_TableIrqGet@4" (ByVal index As Integer) As Integer
Public Declare Function DRV629_TableIrqSet Lib "P61W32.DLL" Alias "_DRV629_TableIrqSet@8" (ByVal index As Integer, ByVal value As Integer) As Long
Public Declare Function DRV629_TablePortGet Lib "P61W32.DLL" Alias "_DRV629_TablePortGet@4" (ByVal index As Integer) As Integer
Public Declare Function DRV629_TablePortSet Lib "P61W32.DLL" Alias "_DRV629_TablePortSet@8" (ByVal index As Integer, ByVal value As Integer) As Long
Public Declare Function DRV629_TableSelGet Lib "P61W32.DLL" Alias "_DRV629_TableSelGet@4" (ByVal index As Integer) As Integer
Public Declare Function DRV629_TableSelSet Lib "P61W32.DLL" Alias "_DRV629_TableSelSet@8" (ByVal index As Integer, ByVal value As Integer) As Long
Public Declare Function DRV629_TableSizeGet Lib "P61W32.DLL" Alias "_DRV629_TableSizeGet@0" () As Integer
Public Declare Function DRV629_TableSizeSet Lib "P61W32.DLL" Alias "_DRV629_TableSizeSet@4" (ByVal value As Integer) As Long
Public Declare Function DRV629_Token Lib "P61W32.DLL" Alias "_DRV629_Token@12" (ByRef fh As Long, ByRef buf As String, ByVal count As Integer) As Long
Public Declare Function DRV629_Tolower Lib "P61W32.DLL" Alias "_DRV629_Tolower@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Toupper Lib "P61W32.DLL" Alias "_DRV629_Toupper@4" (ByVal value As Integer) As Integer
Public Declare Function DRV629_Uncheck Lib "P61W32.DLL" Alias "_DRV629_Uncheck@4" (ByVal handleval As Long) As Long
Public Declare Function DRV629_UncheckAll Lib "P61W32.DLL" Alias "_DRV629_UncheckAll@0" () As Long
Public Declare Function DRV629_ValAsciiCmpi Lib "P61W32.DLL" Alias "_DRV629_ValAsciiCmpi@8" (ByRef str1 As String, ByRef str2 As String) As Long
Public Declare Function DRV629_ValAsciiCpy Lib "P61W32.DLL" Alias "_DRV629_ValAsciiCpy@12" (ByRef strdest As String, ByRef strsrc As String, ByVal count As Long) As Long
Public Declare Function DRV629_ValAsciiTrimLead Lib "P61W32.DLL" Alias "_DRV629_ValAsciiTrimLead@4" (ByRef buf As String) As Long
Public Declare Function DRV629_ValAsciiTrimTrail Lib "P61W32.DLL" Alias "_DRV629_ValAsciiTrimTrail@4" (ByRef buf As String) As Long
Public Declare Function DRV629_ValFromAscii Lib "P61W32.DLL" Alias "_DRV629_ValFromAscii@8" (ByRef asciistr As String, ByVal radixval As Long) As Long
Public Declare Function DRV629_ValIncAscii Lib "P61W32.DLL" Alias "_DRV629_ValIncAscii@4" (ByRef asciistr As String) As Long
Public Declare Function DRV629_ValInccAscii Lib "P61W32.DLL" Alias "_DRV629_ValInccAscii@4" (ByRef asciistr As String) As Long
Public Declare Function DRV629_ValIsLower Lib "P61W32.DLL" Alias "_DRV629_ValIsLower@4" (ByVal value As Long) As Long
Public Declare Function DRV629_ValLenAscii Lib "P61W32.DLL" Alias "_DRV629_ValLenAscii@8" (ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function DRV629_ValToAscii Lib "P61W32.DLL" Alias "_DRV629_ValToAscii@16" (ByVal value As Long, ByRef asciistr As String, ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function DRV629_ValToUpper Lib "P61W32.DLL" Alias "_DRV629_ValToUpper@4" (ByVal value As Long) As Long
Public Declare Function DRV629_Version Lib "P61W32.DLL" Alias "_DRV629_Version@0" () As Long
Public Declare Function DRV629_WipeRam Lib "P61W32.DLL" Alias "_DRV629_WipeRam@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_WrALT Lib "P61W32.DLL" Alias "_DRV629_WrALT@8" (ByVal altval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_WrAXT Lib "P61W32.DLL" Alias "_DRV629_WrAXT@8" (ByVal axtval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_WrCID Lib "P61W32.DLL" Alias "_DRV629_WrCID@8" (ByVal cidval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_WrTITGSG Lib "P61W32.DLL" Alias "_DRV629_WrTITGSG@16" (ByVal tival As Integer, ByVal tgval As Integer, ByVal sgval As Integer, ByVal handleval As Long) As Long
Public Declare Function DRV629_XFormat Lib "P61W32.DLL" Alias "_DRV629_XFormat@8" (ByVal value As Integer, ByVal handleval As Long) As Long

'/**
'*
'*  PC629-1 Driver predefined constants.
'*
'**/

Public Const ALT_OFF As Integer = &H0    '//Disables alt, enables primary schedule
Public Const ALT_ON As Integer = &H1 '//Enables alternate schedule

Public Const AXT_OFF As Integer = &H0    '//Disables alternate label extensions
Public Const AXT_ON As Integer = &H1 '//Enables alternate label extensions

Public Const OPT_NONE As Integer = &H0   '//No interrupt options selected
Public Const INT_ERROR As Integer = &H1  '//Interrupts generated on errors

Public Const FORMAT_INDEP As Integer = &H0   '//Selects independent schedule format
Public Const FORMAT_BLOCK As Integer = &H1   '//Selects block schedule format

'/**
'*
'*  PC629-1 Parse Codes.
'*
'**/

Public Const INFOVAL_ORG As Integer = 1 '//ORG information
Public Const INFOVAL_ROM As Integer = 2 '//ROM switch
Public Const INFOVAL_RAM As Integer = 3 '//RAM switch
Public Const INFOVAL_RAMBYTE As Integer = 4 '//RAM byte value
Public Const INFOVAL_RAMWORD As Integer = 5 '//RAM word value
Public Const INFOVAL_RAMDWORD As Integer = 6    '//RAM long word value
Public Const INFOVAL_ROMBYTE As Integer = 7 '//ROM byte value
Public Const INFOVAL_ROMWORD As Integer = 8 '//ROM word value
Public Const INFOVAL_ROMDWORD As Integer = 9    '//ROM long word value
Public Const INFOVAL_OPCODE As Integer = 10 '//Opcode code
Public Const INFOVAL_OPVALUE As Integer = 11    '//Opcode value

'/**
'*
'*  PC629-1 Direct Registers.
'*
'**/

Public Const MEM_PAGE_REG As Integer = &H0   '//Read/write memory page
Public Const PORT_SEL_REG As Integer = &H1   '//Read/write internal port select
Public Const INT_CLR_REG As Integer = &H2    '//Write clears interrupts
Public Const VECT_LSB_REG As Integer = &H2   '//Read interrupt vector LSB
Public Const RESET_REG As Integer = &H3  '//Write triggers master reset
Public Const VECT_MSB_REG As Integer = &H3   '//Read interrupt vector MSB
Public Const REG_ACCESS_LSB As Integer = &H4 '//Read/write internal register LSB
Public Const REG_ACCESS_MSB As Integer = &H5 '//Read internal register MSB
Public Const SEG_SEL_REG As Integer = &H6    '//Write to segment select
Public Const STATUS_REG As Integer = &H6 '//Read status

'/**
'*
'*  PC629-1 Indirect Registers.
'*
'**/

Public Const CID_IREG As Integer = &H0   '//Write channel ID
Public Const TISG_IREG As Integer = &H1  '//Write xmit interval/sync gap
Public Const TGAP_IREG As Integer = &H2  '//Write terminal gap
Public Const MEMCFG_IREG As Integer = &H3    '//Read/write memory configuration
Public Const CTRL_IREG As Integer = &H4  '//Read/write control
Public Const PPROM_IREG As Integer = &H5 '//Read/write personality prom
Public Const ERR_IREG As Integer = &H6   '//Read error register
Public Const LASTWDMON_IREG As Integer = &H7 '//Read last word monitor

'/**
'*
'*  PC629-1 Error Return Values.
'*
'**/

Public Const ERR_NONE As Integer = 0    '//No error
Public Const ERR_UNKNOWN As Integer = -1    '//An unexpected error occurred
Public Const ERR_BADVER As Integer = -2 '//A bad version was encountered
Public Const ERR_BADPARAMS As Integer = -11 '//CardOpen() called with bad parameters
Public Const ERR_NOHANDLES As Integer = -12 '//CardOpen() already has allocated too many handles
Public Const ERR_NOCARD As Integer = -13    '//The drivers for the specified PC629-1 card have not been installed
Public Const ERR_NOIO As Integer = -14  '//CardOpen() could not find the I/O ports
Public Const ERR_NOMEM As Integer = -15 '//CardOpen() could not find the memory
Public Const ERR_BADHANDLE As Integer = -21 '//A bad handle was specified
Public Const ERR_VXD As Integer = -28   '//An error occurred in the VXD
Public Const ERR_FNAME As Integer = -47 '//Bad filenames were specified
Public Const ERR_FRDWR As Integer = -48 '//There was an error reading or writing file
Public Const ERR_UNKNOWNOP As Integer = -91 '//Unknown opcode
Public Const ERR_UNKNOWNHEX As Integer = -92    '//Unknown hexvalue
Public Const ERR_NOVALUE As Integer = -93   '//No value for opcode
