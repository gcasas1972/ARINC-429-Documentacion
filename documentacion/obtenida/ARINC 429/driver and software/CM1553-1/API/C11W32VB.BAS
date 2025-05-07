'/**
'*
'*  CM1553-1 WIN32 DRIVER Version 1.2  (04/09/1999)
'*  Copyright (c) 1997,1999
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   C11W32.BAS -- WIN32 CM1553-1 Driver
'*                      Include Header File.
'*
'**/

'/**
'*
'*  CM1553-1 Driver functions.
'*
'**/

'/**
'*
'*  Internal functions used by the CM1553-1 Driver.
'*
'**/

Public Declare Function C11_BCBranchEnd Lib "C11W32.DLL" Alias "_C11_BCBranchEnd@4" (ByVal handleval As Long) As Long
Public Declare Function C11_BCCallFrame Lib "C11W32.DLL" Alias "_C11_BCCallFrame@8" (ByVal index As Long, ByVal handleval As Long) As Integer
Public Declare Function C11_BCCheckMsg Lib "C11W32.DLL" Alias "_C11_BCCheckMsg@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function C11_BCConfig Lib "C11W32.DLL" Alias "_C11_BCConfig@8" (ByVal configflags As Long, ByVal handleval As Long) As Long
Public Declare Function C11_BCConfigEx Lib "C11W32.DLL" Alias "_C11_BCConfigEx@16" (ByVal configflags As Long, ByVal cmdcountval As Long, ByVal cyccountval As Long, ByVal handleval As Long) As Long
Public Declare Function C11_BCDoAgain Lib "C11W32.DLL" Alias "_C11_BCDoAgain@8" (ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function C11_BCDoGap Lib "C11W32.DLL" Alias "_C11_BCDoGap@8" (ByVal gapval As Long, ByVal handleval As Long) As Long
Public Declare Function C11_BCDoGoto Lib "C11W32.DLL" Alias "_C11_BCDoGoto@8" (ByVal destindex As Long, ByVal handleval As Long) As Long
Public Declare Function C11_BCDoHalt Lib "C11W32.DLL" Alias "_C11_BCDoHalt@4" (ByVal handleval As Long) As Long
Public Declare Function C11_BCDoInt Lib "C11W32.DLL" Alias "_C11_BCDoInt@4" (ByVal handleval As Long) As Long
Public Declare Function C11_BCDoMsg Lib "C11W32.DLL" Alias "_C11_BCDoMsg@16" (ByVal busab As Long, ByVal cwdval As Integer, ByRef datavals As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_BCDoResv Lib "C11W32.DLL" Alias "_C11_BCDoResv@4" (ByVal handleval As Long) As Long
Public Declare Function C11_BCDoRTRT Lib "C11W32.DLL" Alias "_C11_BCDoRTRT@16" (ByVal busab As Long, ByVal cwd1val As Integer, ByVal cwd2val As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_BCDoSelfTest Lib "C11W32.DLL" Alias "_C11_BCDoSelfTest@4" (ByVal handleval As Long) As Long
Public Declare Function C11_BCFrameEnd Lib "C11W32.DLL" Alias "_C11_BCFrameEnd@4" (ByVal handleval As Long) As Long
Public Declare Function C11_BCFrameStart Lib "C11W32.DLL" Alias "_C11_BCFrameStart@8" (ByVal timeval As Long, ByVal handleval As Long) As Long
Public Declare Function C11_BCMsgBranch Lib "C11W32.DLL" Alias "_C11_BCMsgBranch@16" (ByVal index As Long, ByVal destindex As Long, ByVal condition As Long, ByVal handleval As Long) As Long
Public Declare Function C11_BCMsgRetry Lib "C11W32.DLL" Alias "_C11_BCMsgRetry@16" (ByVal index As Long, ByVal retries As Long, ByVal condition As Long, ByVal handleval As Long) As Long
Public Declare Function C11_BCRdData Lib "C11W32.DLL" Alias "_C11_BCRdData@16" (ByVal index As Long, ByRef data As Integer, ByVal count As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_BCRdSWD1 Lib "C11W32.DLL" Alias "_C11_BCRdSWD1@8" (ByVal index As Long, ByVal handleval As Long) As Integer
Public Declare Function C11_BCRdSWD2 Lib "C11W32.DLL" Alias "_C11_BCRdSWD2@8" (ByVal index As Long, ByVal handleval As Long) As Integer
Public Declare Function C11_BCWrData Lib "C11W32.DLL" Alias "_C11_BCWrData@16" (ByVal index As Long, ByRef data As Integer, ByVal count As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_CloseCard Lib "C11W32.DLL" Alias "_C11_CloseCard@4" (ByVal handleval As Long) As Long
Public Declare Function C11_GetBitFld Lib "C11W32.DLL" Alias "_C11_GetBitFld@12" (ByVal oldvalue As Integer, ByVal startbit As Long, ByVal endbit As Long) As Integer
Public Declare Function C11_INTInstall Lib "C11W32.DLL" Alias "_C11_INTInstall@8" (ByRef hevent As Long, ByVal handleval As Long) As Long
Public Declare Function C11_INTRd Lib "C11W32.DLL" Alias "_C11_INTRd@16" (ByVal index As Long, ByRef typeval As Integer, ByRef eventval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_INTUninstall Lib "C11W32.DLL" Alias "_C11_INTUninstall@8" (ByRef hevent As Long, ByVal handleval As Long) As Long
Public Declare Function C11_INTUnmask Lib "C11W32.DLL" Alias "_C11_INTUnmask@8" (ByVal maskval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_MONConfig Lib "C11W32.DLL" Alias "_C11_MONConfig@12" (ByVal configflags As Long, ByVal moncount As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_MONCount Lib "C11W32.DLL" Alias "_C11_MONCount@4" (ByVal handleval As Long) As Long
Public Declare Function C11_MONRd Lib "C11W32.DLL" Alias "_C11_MONRd@16" (ByVal index As Integer, ByRef blockinfo As Integer, ByRef datawords As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_MONTermAddr Lib "C11W32.DLL" Alias "_C11_MONTermAddr@12" (ByVal termaddr As Integer, ByVal enableflag As Long, ByVal handleval As Long) As Long
Public Declare Function C11_OpenCard Lib "C11W32.DLL" Alias "_C11_OpenCard@4" (ByVal card_number As Long) As Long
Public Declare Function C11_PackCWD Lib "C11W32.DLL" Alias "_C11_PackCWD@16" (ByVal taval As Long, ByVal trval As Long, ByVal saval As Long, ByVal wcval As Long) As Integer
Public Declare Function C11_PeekMem Lib "C11W32.DLL" Alias "_C11_PeekMem@8" (ByVal wordoffset As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_PokeMem Lib "C11W32.DLL" Alias "_C11_PokeMem@12" (ByVal data As Integer, ByVal wordoffset As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_PutBitFld Lib "C11W32.DLL" Alias "_C11_PutBitFld@16" (ByVal oldvalue As Integer, ByVal newfld As Integer, ByVal startbit As Long, ByVal endbit As Long) As Integer
Public Declare Function C11_RdPort Lib "C11W32.DLL" Alias "_C11_RdPort@8" (ByVal register As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_Reset Lib "C11W32.DLL" Alias "_C11_Reset@4" (ByVal handleval As Long) As Long
Public Declare Function C11_Restart Lib "C11W32.DLL" Alias "_C11_Restart@4" (ByVal handleval As Long) As Long
Public Declare Function C11_RTAccessed Lib "C11W32.DLL" Alias "_C11_RTAccessed@8" (ByVal cwd As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_RTConfig Lib "C11W32.DLL" Alias "_C11_RTConfig@12" (ByVal configflags As Long, ByVal rtaddr As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_RTCountList Lib "C11W32.DLL" Alias "_C11_RTCountList@8" (ByVal cwd As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_RTIllegal Lib "C11W32.DLL" Alias "_C11_RTIllegal@8" (ByVal cwd As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_RTInitList Lib "C11W32.DLL" Alias "_C11_RTInitList@12" (ByVal cwd As Integer, ByVal count As Long, ByVal handleval As Long) As Integer
Public Declare Function C11_RTInt Lib "C11W32.DLL" Alias "_C11_RTInt@12" (ByVal cwd As Integer, ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_RTMONConfig Lib "C11W32.DLL" Alias "_C11_RTMONConfig@16" (ByVal configflags As Long, ByVal rtaddr As Integer, ByVal moncount As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_RTRdData Lib "C11W32.DLL" Alias "_C11_RTRdData@12" (ByVal cwd As Integer, ByRef data As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_RTRdDataEx Lib "C11W32.DLL" Alias "_C11_RTRdDataEx@12" (ByVal cwd As Integer, ByRef infodata As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_RTRdList Lib "C11W32.DLL" Alias "_C11_RTRdList@16" (ByVal cwd As Integer, ByVal index As Integer, ByRef infodata As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_RTRstList Lib "C11W32.DLL" Alias "_C11_RTRstList@8" (ByVal cwd As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_RTWrData Lib "C11W32.DLL" Alias "_C11_RTWrData@12" (ByVal cwd As Integer, ByRef data As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_RTWrSWD Lib "C11W32.DLL" Alias "_C11_RTWrSWD@8" (ByVal statusflags As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SelfTest Lib "C11W32.DLL" Alias "_C11_SelfTest@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_Start Lib "C11W32.DLL" Alias "_C11_Start@4" (ByVal handleval As Long) As Long
Public Declare Function C11_Stop Lib "C11W32.DLL" Alias "_C11_Stop@4" (ByVal handleval As Long) As Long
Public Declare Function C11_TransmitMsg Lib "C11W32.DLL" Alias "_C11_TransmitMsg@20" (ByVal busab As Long, ByVal cwd As Integer, ByRef dataptr As Integer, ByRef swd As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_TransmitRTRT Lib "C11W32.DLL" Alias "_C11_TransmitRTRT@28" (ByVal busab As Long, ByVal cwd1 As Integer, ByVal cwd2 As Integer, ByRef dataptr As Integer, ByRef swd1 As Integer, ByRef swd2 As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_UnpackCWD Lib "C11W32.DLL" Alias "_C11_UnpackCWD@20" (ByVal cwdval As Integer, ByRef taval As Long, ByRef trval As Long, ByRef saval As Long, ByRef wcval As Long) As Long
Public Declare Function C11_WrPort Lib "C11W32.DLL" Alias "_C11_WrPort@12" (ByVal data As Integer, ByVal register As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_BCAddrData Lib "C11W32.DLL" Alias "_C11_BCAddrData@8" (ByVal index As Long, ByVal handleval As Long) As Integer
Public Declare Function C11_BCBlockAddr Lib "C11W32.DLL" Alias "_C11_BCBlockAddr@8" (ByVal index As Long, ByVal handleval As Long) As Integer
Public Declare Function C11_BCBlockClear Lib "C11W32.DLL" Alias "_C11_BCBlockClear@4" (ByVal handleval As Long) As Long
Public Declare Function C11_BCBlockCount Lib "C11W32.DLL" Alias "_C11_BCBlockCount@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_BCBlockCtrl Lib "C11W32.DLL" Alias "_C11_BCBlockCtrl@8" (ByVal index As Long, ByVal handleval As Long) As Integer
Public Declare Function C11_BCBlockInit Lib "C11W32.DLL" Alias "_C11_BCBlockInit@8" (ByRef block As Integer, ByVal opcode As Integer) As Long
Public Declare Function C11_BCBlockInsert Lib "C11W32.DLL" Alias "_C11_BCBlockInsert@8" (ByRef block As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_BCBlockRead Lib "C11W32.DLL" Alias "_C11_BCBlockRead@12" (ByVal index As Long, ByRef block As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_BCBlockWrite Lib "C11W32.DLL" Alias "_C11_BCBlockWrite@12" (ByVal index As Long, ByRef block As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_BCCycleAddr Lib "C11W32.DLL" Alias "_C11_BCCycleAddr@8" (ByVal index As Long, ByVal handleval As Long) As Integer
Public Declare Function C11_BCCycleClear Lib "C11W32.DLL" Alias "_C11_BCCycleClear@4" (ByVal handleval As Long) As Long
Public Declare Function C11_BCCycleInsert Lib "C11W32.DLL" Alias "_C11_BCCycleInsert@8" (ByRef cycle As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_BCCycleRestart Lib "C11W32.DLL" Alias "_C11_BCCycleRestart@4" (ByVal handleval As Long) As Long
Public Declare Function C11_BCCycleWrite Lib "C11W32.DLL" Alias "_C11_BCCycleWrite@12" (ByVal index As Long, ByRef cycle As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_ClrAllILLEGAL Lib "C11W32.DLL" Alias "_C11_ClrAllILLEGAL@4" (ByVal handleval As Long) As Long
Public Declare Function C11_ClrILLEGAL Lib "C11W32.DLL" Alias "_C11_ClrILLEGAL@20" (ByVal subaddr As Long, ByVal trbit As Long, ByVal mcflag As Long, ByVal bcastflag As Long, ByVal handleval As Long) As Long
Public Declare Function C11_Div Lib "C11W32.DLL" Alias "_C11_Div@8" (ByVal diva As Long, ByVal divb As Long) As Long
Public Declare Function C11_FillMem Lib "C11W32.DLL" Alias "_C11_FillMem@16" (ByVal data As Integer, ByVal wordoffset As Integer, ByVal iwordcount As Long, ByVal handleval As Long) As Long
Public Declare Function C11_GetBCAST Lib "C11W32.DLL" Alias "_C11_GetBCAST@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetBUF Lib "C11W32.DLL" Alias "_C11_GetBUF@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetCHAN Lib "C11W32.DLL" Alias "_C11_GetCHAN@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetCIRCLE Lib "C11W32.DLL" Alias "_C11_GetCIRCLE@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetDYNBC Lib "C11W32.DLL" Alias "_C11_GetDYNBC@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetEXT Lib "C11W32.DLL" Alias "_C11_GetEXT@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetHigh Lib "C11W32.DLL" Alias "_C11_GetHigh@4" (ByVal val As Long) As Integer
Public Declare Function C11_GetILLEGAL Lib "C11W32.DLL" Alias "_C11_GetILLEGAL@20" (ByVal subaddr As Long, ByVal trbit As Long, ByVal mcflag As Long, ByVal bcastflag As Long, ByVal handleval As Long) As Integer
Public Declare Function C11_GetINT Lib "C11W32.DLL" Alias "_C11_GetINT@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetIntLog Lib "C11W32.DLL" Alias "_C11_GetIntLog@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetINTMASK Lib "C11W32.DLL" Alias "_C11_GetINTMASK@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetLow Lib "C11W32.DLL" Alias "_C11_GetLow@4" (ByVal val As Long) As Integer
Public Declare Function C11_GetMODE Lib "C11W32.DLL" Alias "_C11_GetMODE@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetMonCtrl Lib "C11W32.DLL" Alias "_C11_GetMonCtrl@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetMonFilt Lib "C11W32.DLL" Alias "_C11_GetMonFilt@12" (ByRef valuel As Integer, ByRef valueh As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_GetPP Lib "C11W32.DLL" Alias "_C11_GetPP@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetRTADDR Lib "C11W32.DLL" Alias "_C11_GetRTADDR@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetStatus Lib "C11W32.DLL" Alias "_C11_GetStatus@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetSTD Lib "C11W32.DLL" Alias "_C11_GetSTD@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetTIMEOUT Lib "C11W32.DLL" Alias "_C11_GetTIMEOUT@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_GetXMTSW Lib "C11W32.DLL" Alias "_C11_GetXMTSW@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_HeapAlloc Lib "C11W32.DLL" Alias "_C11_HeapAlloc@8" (ByVal wordcount As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_HeapAvail Lib "C11W32.DLL" Alias "_C11_HeapAvail@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_HeapClear Lib "C11W32.DLL" Alias "_C11_HeapClear@4" (ByVal handleval As Long) As Long
Public Declare Function C11_HeapRdHead Lib "C11W32.DLL" Alias "_C11_HeapRdHead@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_HeapWrHead Lib "C11W32.DLL" Alias "_C11_HeapWrHead@8" (ByVal value As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_INTDisable Lib "C11W32.DLL" Alias "_C11_INTDisable@4" (ByVal handleval As Long) As Long
Public Declare Function C11_INTEnable Lib "C11W32.DLL" Alias "_C11_INTEnable@4" (ByVal handleval As Long) As Long
Public Declare Function C11_INTRdPend Lib "C11W32.DLL" Alias "_C11_INTRdPend@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_INTRdPoll Lib "C11W32.DLL" Alias "_C11_INTRdPoll@4" (ByVal handleval As Long) As Long
Public Declare Function C11_INTReset Lib "C11W32.DLL" Alias "_C11_INTReset@4" (ByVal handleval As Long) As Long
Public Declare Function C11_IsBC Lib "C11W32.DLL" Alias "_C11_IsBC@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_IsMON Lib "C11W32.DLL" Alias "_C11_IsMON@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_IsRT Lib "C11W32.DLL" Alias "_C11_IsRT@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_IsRTMON Lib "C11W32.DLL" Alias "_C11_IsRTMON@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_MakeLong Lib "C11W32.DLL" Alias "_C11_MakeLong@8" (ByVal valh As Integer, ByVal vall As Integer) As Long
Public Declare Function C11_Mask Lib "C11W32.DLL" Alias "_C11_Mask@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function C11_Mod Lib "C11W32.DLL" Alias "_C11_Mod@8" (ByVal moda As Long, ByVal modb As Long) As Long
Public Declare Function C11_MONAll Lib "C11W32.DLL" Alias "_C11_MONAll@4" (ByVal handleval As Long) As Long
Public Declare Function C11_MONBlockBase Lib "C11W32.DLL" Alias "_C11_MONBlockBase@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_MONDataBase Lib "C11W32.DLL" Alias "_C11_MONDataBase@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_MONNone Lib "C11W32.DLL" Alias "_C11_MONNone@4" (ByVal handleval As Long) As Long
Public Declare Function C11_Mul Lib "C11W32.DLL" Alias "_C11_Mul@8" (ByVal mula As Long, ByVal mulb As Long) As Long
Public Declare Function C11_OkayHandle Lib "C11W32.DLL" Alias "_C11_OkayHandle@4" (ByVal handleval As Long) As Long
Public Declare Function C11_OpenDevice Lib "C11W32.DLL" Alias "_C11_OpenDevice@4" (ByRef device_id As Long) As Long
Public Declare Function C11_PackRTCWD Lib "C11W32.DLL" Alias "_C11_PackRTCWD@20" (ByVal subaddr As Long, ByVal trbit As Long, ByVal mcflag As Long, ByVal bcastflag As Long, ByVal count As Long) As Integer
Public Declare Function C11_PeekAttr Lib "C11W32.DLL" Alias "_C11_PeekAttr@8" (ByVal wordoffset As Integer, ByVal handleval As Long) As Byte
Public Declare Function C11_PeekStrAttr Lib "C11W32.DLL" Alias "_C11_PeekStrAttr@16" (ByRef pwbuffer As Integer, ByVal wordoffset As Integer, ByVal iwordcount As Long, ByVal handleval As Long) As Long
Public Declare Function C11_PeekStrMem Lib "C11W32.DLL" Alias "_C11_PeekStrMem@16" (ByRef pwbuffer As Integer, ByVal wordoffset As Integer, ByVal iwordcount As Long, ByVal handleval As Long) As Long
Public Declare Function C11_PokeAttr Lib "C11W32.DLL" Alias "_C11_PokeAttr@12" (ByVal data As Byte, ByVal wordoffset As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_PokeStrAttr Lib "C11W32.DLL" Alias "_C11_PokeStrAttr@16" (ByRef pwbuffer As Integer, ByVal wordoffset As Integer, ByVal iwordcount As Long, ByVal handleval As Long) As Long
Public Declare Function C11_PokeStrMem Lib "C11W32.DLL" Alias "_C11_PokeStrMem@16" (ByRef pwbuffer As Integer, ByVal wordoffset As Integer, ByVal iwordcount As Long, ByVal handleval As Long) As Long
Public Declare Function C11_RTAddrData Lib "C11W32.DLL" Alias "_C11_RTAddrData@12" (ByVal typeval As Integer, ByVal cwd As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_RTAddrDesc Lib "C11W32.DLL" Alias "_C11_RTAddrDesc@12" (ByVal typeval As Integer, ByVal cwd As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_RTAddrParity Lib "C11W32.DLL" Alias "_C11_RTAddrParity@4" (ByVal rtaddr As Long) As Long
Public Declare Function C11_RTInitData Lib "C11W32.DLL" Alias "_C11_RTInitData@8" (ByVal scheme As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_RTPokeData Lib "C11W32.DLL" Alias "_C11_RTPokeData@12" (ByVal cwd As Integer, ByRef data As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_RTRdDesc Lib "C11W32.DLL" Alias "_C11_RTRdDesc@12" (ByVal cwd As Integer, ByRef desc As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_RTWrDesc Lib "C11W32.DLL" Alias "_C11_RTWrDesc@12" (ByVal cwd As Integer, ByRef desc As Integer, ByVal handleval As Long) As Integer
Public Declare Function C11_SetAllILLEGAL Lib "C11W32.DLL" Alias "_C11_SetAllILLEGAL@4" (ByVal handleval As Long) As Long
Public Declare Function C11_SetBCAST Lib "C11W32.DLL" Alias "_C11_SetBCAST@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetBUF Lib "C11W32.DLL" Alias "_C11_SetBUF@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetCHAN Lib "C11W32.DLL" Alias "_C11_SetCHAN@8" (ByVal chanval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetCIRCLE Lib "C11W32.DLL" Alias "_C11_SetCIRCLE@8" (ByVal circleval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetDYNBC Lib "C11W32.DLL" Alias "_C11_SetDYNBC@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetEXT Lib "C11W32.DLL" Alias "_C11_SetEXT@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetILLEGAL Lib "C11W32.DLL" Alias "_C11_SetILLEGAL@20" (ByVal subaddr As Long, ByVal trbit As Long, ByVal mcflag As Long, ByVal bcastflag As Long, ByVal handleval As Long) As Long
Public Declare Function C11_SetINT Lib "C11W32.DLL" Alias "_C11_SetINT@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetIntLog Lib "C11W32.DLL" Alias "_C11_SetIntLog@8" (ByVal addressval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetINTMASK Lib "C11W32.DLL" Alias "_C11_SetINTMASK@8" (ByVal maskval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetLog Lib "C11W32.DLL" Alias "_C11_SetLog@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetMODE Lib "C11W32.DLL" Alias "_C11_SetMODE@8" (ByVal modeval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetMonCtrl Lib "C11W32.DLL" Alias "_C11_SetMonCtrl@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetMonFilt Lib "C11W32.DLL" Alias "_C11_SetMonFilt@12" (ByVal valuel As Integer, ByVal valueh As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetPP Lib "C11W32.DLL" Alias "_C11_SetPP@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetRTADDR Lib "C11W32.DLL" Alias "_C11_SetRTADDR@8" (ByVal rtaddr As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetStatus Lib "C11W32.DLL" Alias "_C11_SetStatus@12" (ByVal flags As Integer, ByVal immclear As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetSTD Lib "C11W32.DLL" Alias "_C11_SetSTD@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetTIMEOUT Lib "C11W32.DLL" Alias "_C11_SetTIMEOUT@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_SetXMTSW Lib "C11W32.DLL" Alias "_C11_SetXMTSW@8" (ByVal enableval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_Shl Lib "C11W32.DLL" Alias "_C11_Shl@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function C11_Shr Lib "C11W32.DLL" Alias "_C11_Shr@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function C11_StatRead Lib "C11W32.DLL" Alias "_C11_StatRead@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_TTRead Lib "C11W32.DLL" Alias "_C11_TTRead@4" (ByVal handleval As Long) As Integer
Public Declare Function C11_TTSet Lib "C11W32.DLL" Alias "_C11_TTSet@8" (ByVal timetagval As Integer, ByVal handleval As Long) As Long
Public Declare Function C11_TTZero Lib "C11W32.DLL" Alias "_C11_TTZero@4" (ByVal handleval As Long) As Long
Public Declare Function C11_UnpackRTCWD Lib "C11W32.DLL" Alias "_C11_UnpackRTCWD@24" (ByVal cwd As Integer, ByRef subaddr As Long, ByRef trbit As Long, ByRef mcflag As Long, ByRef bcastflag As Long, ByRef count As Long) As Long
Public Declare Function C11_WipeMem Lib "C11W32.DLL" Alias "_C11_WipeMem@4" (ByVal handleval As Long) As Long

Public Const CONFIG_DEFAULT As Long = &H0    '//Select all default settings (default)
Public Const CONFIG_INTCLK As Long = &H0 '//Use internal clock (default)
Public Const CONFIG_EXTCLK As Long = &H1 '//Use external clock
Public Const CONFIG_NOBUF As Long = &H0  '//Do not use buffer mode (default)
Public Const CONFIG_BUF As Long = &H2    '//Enable use of buffer mode
Public Const CONFIG_NOBCAST As Long = &H0    '//Do not respond to broadcast messages (default)
Public Const CONFIG_BCAST As Long = &H4  '//Respond to broadcast messages
Public Const CONFIG_STDB As Long = &H0   '//Use MIL-STD-1553B standard (default)
Public Const CONFIG_STDA As Long = &H8   '//Use MIL-STD-1553A standard
Public Const CONFIG_NODYNBC As Long = &H0    '//Do not respond to dynamic BC mode code (default)
Public Const CONFIG_DYNBC As Long = &H10  '//Respond to dynamic BC mode code
Public Const CONFIG_NOALTRETRY As Long = &H0 '//Retries are not on alternate busses (BC) (default)
Public Const CONFIG_ALTRETRY As Long = &H20   '//Retries on alternate busses (BC)
Public Const CONFIG_NOXMITSW As Long = &H0   '//Do not respond to xmit last status mode code (default)
Public Const CONFIG_XMITSW As Long = &H40 '//Respond to transmit last status mode code
Public Const CONFIG_ALLSUBADDR As Long = &H0 '//Respond to all subaddresses (default)
Public Const CONFIG_NOSUBADDR As Long = &H80  '//Do not respond to any subaddresses
Public Const CONFIG_WIPE As Long = &H0   '//Fills memory with zeros (default)
Public Const CONFIG_NOWIPE As Long = &H100 '//Does not fill memory with zeros
Public Const CONFIG_INIT As Long = &H0   '//Initialize mode (default)
Public Const CONFIG_NOINIT As Long = &H200 '//Does not initialize mode
Public Const CONFIG_LOGLIST As Long = &H0    '//Enable log list (default)
Public Const CONFIG_NOLOGLIST As Long = &H400  '//Disable log list
Public Const CONFIG_NONOTICE2 As Long = &H0  '//Enable log list (default)
Public Const CONFIG_NOTICE2 As Long = &H800    '//Disable log list
Public Const CONFIG_MONALL As Long = &H0 '//Enable monitoring of all RTs (default)
Public Const CONFIG_MONNONE As Long = &H1000    '//Disable monitoring of all RTs
Public Const CONFIG_REGTIMEOUT As Long = &H0 '//14us timeout (BC,MON) (default)
Public Const CONFIG_EXTTIMEOUT As Long = &H2000 '//30us extended timeout (BC,MON)
Public Const CONFIG_CHANAB As Long = &H0 '//Respond to both channels (default)
Public Const CONFIG_CHANA As Long = &H10000  '//Respond to channel A
Public Const CONFIG_CHANB As Long = &H20000  '//Respond to channel B
Public Const CONFIG_SINGLEBUF As Long = &H0  '//Use single buffer (RT) (default)
Public Const CONFIG_PINGPONG As Long = &H100000   '//Use ping-pong mode (RT)
Public Const CONFIG_CIRC1BUF As Long = &H200000   '//Use circular #1 buffers (RT)
Public Const CONFIG_CIRC2BUF As Long = &H300000   '//Use circular #2 buffers (RT)

Public Const SWD_IMCLR As Integer = &H8000  '//Immediate clear
Public Const SWD_BIT10 As Integer = &H200  '//Status word bit 10
Public Const SWD_INS As Integer = &H200    '//Instrumentation bit
Public Const SWD_BIT11 As Integer = &H100  '//Status word bit 11
Public Const SWD_SRQ As Integer = &H100    '//Service request bit
Public Const SWD_BIT12 As Integer = &H80  '//Status word bit 12
Public Const SWD_BIT13 As Integer = &H40  '//Status word bit 13
Public Const SWD_BIT14 As Integer = &H20  '//Status word bit 14
Public Const SWD_BIT15 As Integer = &H10  '//Status word bit 15
Public Const SWD_BIT16 As Integer = &H8  '//Status word bit 16
Public Const SWD_BUSY As Integer = &H8   '//Busy bit
Public Const SWD_BIT17 As Integer = &H4  '//Status word bit 17
Public Const SWD_SSYSF As Integer = &H4  '//Subsystem flag bit
Public Const SWD_BIT18 As Integer = &H2  '//Status word bit 18
Public Const SWD_BIT19 As Integer = &H1  '//Status word bit 19
Public Const SWD_TF As Integer = &H1 '//Terminal flag

Public Const INT_DMAF As Integer = &H8000   '//BC,RT,MON
Public Const INT_WRAPF As Integer = &H4000  '//BC,RT
Public Const INT_TAPF As Integer = &H2000   '//RT
Public Const INT_BITF As Integer = &H1000   '//BC,RT,MON
Public Const INT_MERR As Integer = &H800   '//BC,RT,MON
Public Const INT_SUBAD As Integer = &H400  '//RT
Public Const INT_BDRCV As Integer = &H200  '//RT
Public Const INT_IXEQ0 As Integer = &H100  '//RT
Public Const INT_ILCMD As Integer = &H80  '//RT
Public Const INT_EOL As Integer = &H20    '//BC
Public Const INT_ILLCMD As Integer = &H10 '//BC
Public Const INT_ILLOP As Integer = &H8  '//BC
Public Const INT_RTF As Integer = &H4    '//BC
Public Const INT_CBA As Integer = &H2    '//BC
Public Const INT_MBC As Integer = &H1    '//MON
Public Const INT_NONE As Integer = &H0   '//No interrupts

Public Const REG_INT As Integer = &H0    '//Interrupt register
Public Const REG_PAGE As Integer = &H1   '//Page register
Public Const REG_EXT As Integer = &H2    '//External register
Public Const REG_RESV As Integer = &H3   '//Reserved register
Public Const REG_INTC As Integer = &H4   '//Interrupt clear register
Public Const REG_RST As Integer = &H5    '//Reset register
Public Const REG_ERR As Integer = &H6    '//Error register
Public Const REG_PWE As Integer = &H7    '//Prom write enable register

Public Const BUSA As Integer = 0    '//Selects bus A
Public Const BUSB As Integer = 1    '//Selects bus B

Public Const MONNO As Integer = 0   '//Disables monitoring of a terminal address
Public Const MONYES As Integer = 1  '//Enables monitoring of a terminal address

Public Const COND_NONE As Integer = &H0  '//No condition
Public Const COND_FAIL As Integer = &H2000  '//Condition when all retries have failed
Public Const COND_UNCOND As Integer = &H4000    '//Unconditional
Public Const COND_SRQ As Integer = &H2   '//Condition on Service Request bit set in status word
Public Const COND_INS As Integer = &H4   '//Condition on Instrumentation bit set in status word
Public Const COND_SSFAIL As Integer = &H8    '//Condition on Subsystem Fail bit set in status word
Public Const COND_TF As Integer = &H10    '//Condition on Terminal Flag bit set in status word
Public Const COND_BUSY As Integer = &H20  '//Condition on Busy bit set in status word
Public Const COND_ME As Integer = &H40    '//Condition on Message Error bit set in status word
Public Const COND_RESPERR As Integer = &H80   '//Condition on response error
Public Const COND_MASK As Integer = &HFE

Public Const SUMMIT_CTRL As Integer = &H0    '//Control register
Public Const SUMMIT_OPSTAT As Integer = &H1  '//Operational status
Public Const SUMMIT_CURRCMD As Integer = &H2 '//Current Command
Public Const SUMMIT_INTMASK As Integer = &H3 '//Interrupt Mask
Public Const SUMMIT_INTPEND As Integer = &H4 '//Interrupt Pending
Public Const SUMMIT_INTLOG As Integer = &H5  '//Interrupt Log
Public Const SUMMIT_BITWORD As Integer = &H6 '//BIT Word
Public Const SUMMIT_TTMFT As Integer = &H7   '//Time-Tag/Minor Frame Timer
Public Const SUMMIT_RTDACBA As Integer = &H8 '//RT Descriptor/Command Block Pointer
Public Const SUMMIT_RTSTATUS As Integer = &H9    '//RT Status Word
Public Const SUMMIT_CBC As Integer = &HA '//Command Block Init Count
Public Const SUMMIT_MBA As Integer = &HB '//Monitor Block
Public Const SUMMIT_MDA As Integer = &HC '//Monitor Data
Public Const SUMMIT_MBC As Integer = &HD '//Monitor Block Count
Public Const SUMMIT_MFH As Integer = &HE '//Monitor Filter High
Public Const SUMMIT_MFL As Integer = &HF '//Monitor Filter Low

Public Const ERR_NONE As Integer = 0    '//No error
Public Const ERR_UNKNOWN As Integer = -1    '//An unexpected error occurred
Public Const ERR_NOCS As Integer = -10  '//Card Services is not present
Public Const ERR_NOSOCKET As Integer = -11  '//The specified socket is not present
Public Const ERR_NOCARD As Integer = -12    '//Unable to find a CM1553-1 card in the specified socket
Public Const ERR_NOTSR As Integer = -13 '//Unable to find the CM1553-1 memory resident driver
Public Const ERR_CLIENT As Integer = -14    '//Unable to install a local client driver
Public Const ERR_CS As Integer = -15    '//An error was returned by Card Services
Public Const ERR_WIN As Integer = -16   '//Card Services could not configure the memory window, I/O window, or IRQ steering
Public Const ERR_SEL As Integer = -17   '//Unable to allocate a memory selector
Public Const ERR_BADHANDLE As Integer = -20 '//A bad handle was specified
Public Const ERR_COUNT As Integer = -21 '//An invalid count was specified
Public Const ERR_ALLOC As Integer = -22 '//Not enough memory to allocate
Public Const ERR_INDEX As Integer = -23 '//The command block index was invalid or the schedule is full
Public Const ERR_RETRY As Integer = -31 '//The retry parameter is out of range
Public Const ERR_COND As Integer = -32  '//An invalid condition condition parameter was specified
Public Const ERR_BADMSG As Integer = -33    '//The specified command block is not a message block
Public Const ERR_RTRT As Integer = -34  '//The command words are not a valid RT-RT message
Public Const ERR_RESPONSE As Integer = -35  '//A bad response or no response was received from an RT
Public Const ERR_FNAME As Integer = -40 '//Bad filenames were specified
Public Const ERR_FRDWR As Integer = -41 '//There was an error reading or writing the HEX file
Public Const ERR_HEX As Integer = -42   '//There was a bad hex character in the HEX file
Public Const ERR_CRC As Integer = -43   '//There was a bad checksum in the HEX file
Public Const ERR_TYPE As Integer = -44  '//There was a bad type value in the HEX file
Public Const ERR_CISRANGE As Integer = -90  '//The specified address is outside of the CS address range
Public Const ERR_CISNONE As Integer = -91   '//The CIS is not visible
Public Const ERR_CISENB As Integer = -92    '//The PWE register cannot be enabled
Public Const ERR_CISMAGIC As Integer = -93  '//Unable to write to the PWE register
Public Const ERR_VXD As Integer = -100  '//Error returned from VXD
