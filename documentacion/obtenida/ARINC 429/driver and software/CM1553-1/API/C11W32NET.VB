Imports System
Imports System.Runtime.InteropServices

Module C11W32VB

    '/**
    '*
    '*  CM1553-1 WIN32 DRIVER Version 1.2  (04/09/1999)
    '*  Copyright (c) 1997,1999
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   C11W32NET.VB -- WIN32 CM1553-1 Driver
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

    Public Declare Function C11_BCBranchEnd Lib "C11W32.DLL" Alias "_C11_BCBranchEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCCallFrame Lib "C11W32.DLL" Alias "_C11_BCCallFrame@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_BCCheckMsg Lib "C11W32.DLL" Alias "_C11_BCCheckMsg@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCConfig Lib "C11W32.DLL" Alias "_C11_BCConfig@8" (ByVal configflags As UInt32, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCConfigEx Lib "C11W32.DLL" Alias "_C11_BCConfigEx@16" (ByVal configflags As UInt32, ByVal cmdcountval As Int32, ByVal cyccountval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCDoAgain Lib "C11W32.DLL" Alias "_C11_BCDoAgain@8" (ByVal index As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCDoGap Lib "C11W32.DLL" Alias "_C11_BCDoGap@8" (ByVal gapval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCDoGoto Lib "C11W32.DLL" Alias "_C11_BCDoGoto@8" (ByVal destindex As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCDoHalt Lib "C11W32.DLL" Alias "_C11_BCDoHalt@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCDoInt Lib "C11W32.DLL" Alias "_C11_BCDoInt@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCDoMsg Lib "C11W32.DLL" Alias "_C11_BCDoMsg@16" (ByVal busab As Int32, ByVal cwdval As UInt16, ByRef datavals As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCDoResv Lib "C11W32.DLL" Alias "_C11_BCDoResv@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCDoRTRT Lib "C11W32.DLL" Alias "_C11_BCDoRTRT@16" (ByVal busab As Int32, ByVal cwd1val As UInt16, ByVal cwd2val As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCDoSelfTest Lib "C11W32.DLL" Alias "_C11_BCDoSelfTest@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCFrameEnd Lib "C11W32.DLL" Alias "_C11_BCFrameEnd@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCFrameStart Lib "C11W32.DLL" Alias "_C11_BCFrameStart@8" (ByVal timeval As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCMsgBranch Lib "C11W32.DLL" Alias "_C11_BCMsgBranch@16" (ByVal index As Int32, ByVal destindex As Int32, ByVal condition As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCMsgRetry Lib "C11W32.DLL" Alias "_C11_BCMsgRetry@16" (ByVal index As Int32, ByVal retries As Int32, ByVal condition As Int32, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCRdData Lib "C11W32.DLL" Alias "_C11_BCRdData@16" (ByVal index As Int32, ByRef data As UInt16, ByVal count As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_BCRdSWD1 Lib "C11W32.DLL" Alias "_C11_BCRdSWD1@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_BCRdSWD2 Lib "C11W32.DLL" Alias "_C11_BCRdSWD2@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_BCWrData Lib "C11W32.DLL" Alias "_C11_BCWrData@16" (ByVal index As Int32, ByRef data As UInt16, ByVal count As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_CloseCard Lib "C11W32.DLL" Alias "_C11_CloseCard@4" (ByVal handleval As UInt32)
    Public Declare Function C11_GetBitFld Lib "C11W32.DLL" Alias "_C11_GetBitFld@12" (ByVal oldvalue As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function C11_INTInstall Lib "C11W32.DLL" Alias "_C11_INTInstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_INTRd Lib "C11W32.DLL" Alias "_C11_INTRd@16" (ByVal index As Int32, ByRef typeval As UInt16, ByRef eventval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_INTUninstall Lib "C11W32.DLL" Alias "_C11_INTUninstall@8" (ByVal hevent As IntPtr, ByVal handleval As UInt32) As Int32
    Public Declare Sub C11_INTUnmask Lib "C11W32.DLL" Alias "_C11_INTUnmask@8" (ByVal maskval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C11_MONConfig Lib "C11W32.DLL" Alias "_C11_MONConfig@12" (ByVal configflags As UInt32, ByVal moncount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_MONCount Lib "C11W32.DLL" Alias "_C11_MONCount@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_MONRd Lib "C11W32.DLL" Alias "_C11_MONRd@16" (ByVal index As UInt16, ByRef blockinfo As UInt16, ByRef datawords As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_MONTermAddr Lib "C11W32.DLL" Alias "_C11_MONTermAddr@12" (ByVal termaddr As UInt16, ByVal enableflag As Int32, ByVal handleval As UInt32)
    Public Declare Function C11_OpenCard Lib "C11W32.DLL" Alias "_C11_OpenCard@4" (ByVal card_number As Int32) As UInt32
    Public Declare Function C11_PackCWD Lib "C11W32.DLL" Alias "_C11_PackCWD@16" (ByVal taval As Int32, ByVal trval As Int32, ByVal saval As Int32, ByVal wcval As Int32) As UInt16
    Public Declare Function C11_PeekMem Lib "C11W32.DLL" Alias "_C11_PeekMem@8" (ByVal wordoffset As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_PokeMem Lib "C11W32.DLL" Alias "_C11_PokeMem@12" (ByVal data As UInt16, ByVal wordoffset As UInt16, ByVal handleval As UInt32)
    Public Declare Function C11_PutBitFld Lib "C11W32.DLL" Alias "_C11_PutBitFld@16" (ByVal oldvalue As UInt16, ByVal newfld As UInt16, ByVal startbit As Int32, ByVal endbit As Int32) As UInt16
    Public Declare Function C11_RdPort Lib "C11W32.DLL" Alias "_C11_RdPort@8" (ByVal register As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_Reset Lib "C11W32.DLL" Alias "_C11_Reset@4" (ByVal handleval As UInt32)
    Public Declare Sub C11_Restart Lib "C11W32.DLL" Alias "_C11_Restart@4" (ByVal handleval As UInt32)
    Public Declare Function C11_RTAccessed Lib "C11W32.DLL" Alias "_C11_RTAccessed@8" (ByVal cwd As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_RTConfig Lib "C11W32.DLL" Alias "_C11_RTConfig@12" (ByVal configflags As UInt32, ByVal rtaddr As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_RTCountList Lib "C11W32.DLL" Alias "_C11_RTCountList@8" (ByVal cwd As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub C11_RTIllegal Lib "C11W32.DLL" Alias "_C11_RTIllegal@8" (ByVal cwd As UInt16, ByVal handleval As UInt32)
    Public Declare Function C11_RTInitList Lib "C11W32.DLL" Alias "_C11_RTInitList@12" (ByVal cwd As UInt16, ByVal count As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_RTInt Lib "C11W32.DLL" Alias "_C11_RTInt@12" (ByVal cwd As UInt16, ByVal value As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_RTMONConfig Lib "C11W32.DLL" Alias "_C11_RTMONConfig@16" (ByVal configflags As UInt32, ByVal rtaddr As UInt16, ByVal moncount As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_RTRdData Lib "C11W32.DLL" Alias "_C11_RTRdData@12" (ByVal cwd As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_RTRdDataEx Lib "C11W32.DLL" Alias "_C11_RTRdDataEx@12" (ByVal cwd As UInt16, ByRef infodata As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_RTRdList Lib "C11W32.DLL" Alias "_C11_RTRdList@16" (ByVal cwd As UInt16, ByVal index As UInt16, ByRef infodata As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_RTRstList Lib "C11W32.DLL" Alias "_C11_RTRstList@8" (ByVal cwd As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_RTWrData Lib "C11W32.DLL" Alias "_C11_RTWrData@12" (ByVal cwd As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_RTWrSWD Lib "C11W32.DLL" Alias "_C11_RTWrSWD@8" (ByVal statusflags As UInt16, ByVal handleval As UInt32)
    Public Declare Function C11_SelfTest Lib "C11W32.DLL" Alias "_C11_SelfTest@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_Start Lib "C11W32.DLL" Alias "_C11_Start@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_Stop Lib "C11W32.DLL" Alias "_C11_Stop@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_TransmitMsg Lib "C11W32.DLL" Alias "_C11_TransmitMsg@20" (ByVal busab As Int32, ByVal cwd As UInt16, ByRef dataptr As UInt16, ByRef swd As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_TransmitRTRT Lib "C11W32.DLL" Alias "_C11_TransmitRTRT@28" (ByVal busab As Int32, ByVal cwd1 As UInt16, ByVal cwd2 As UInt16, ByRef dataptr As UInt16, ByRef swd1 As UInt16, ByRef swd2 As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub C11_UnpackCWD Lib "C11W32.DLL" Alias "_C11_UnpackCWD@20" (ByVal cwdval As UInt16, ByRef taval As Int32, ByRef trval As Int32, ByRef saval As Int32, ByRef wcval As Int32)
    Public Declare Sub C11_WrPort Lib "C11W32.DLL" Alias "_C11_WrPort@12" (ByVal data As UInt16, ByVal register As UInt16, ByVal handleval As UInt32)
    Public Declare Function C11_BCAddrData Lib "C11W32.DLL" Alias "_C11_BCAddrData@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_BCBlockAddr Lib "C11W32.DLL" Alias "_C11_BCBlockAddr@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_BCBlockClear Lib "C11W32.DLL" Alias "_C11_BCBlockClear@4" (ByVal handleval As UInt32)
    Public Declare Function C11_BCBlockCount Lib "C11W32.DLL" Alias "_C11_BCBlockCount@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_BCBlockCtrl Lib "C11W32.DLL" Alias "_C11_BCBlockCtrl@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_BCBlockInit Lib "C11W32.DLL" Alias "_C11_BCBlockInit@8" (ByRef block As UInt16, ByVal opcode As UInt16)
    Public Declare Function C11_BCBlockInsert Lib "C11W32.DLL" Alias "_C11_BCBlockInsert@8" (ByRef block As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Function C11_BCBlockRead Lib "C11W32.DLL" Alias "_C11_BCBlockRead@12" (ByVal index As Int32, ByRef block As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_BCBlockWrite Lib "C11W32.DLL" Alias "_C11_BCBlockWrite@12" (ByVal index As Int32, ByRef block As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_BCCycleAddr Lib "C11W32.DLL" Alias "_C11_BCCycleAddr@8" (ByVal index As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_BCCycleClear Lib "C11W32.DLL" Alias "_C11_BCCycleClear@4" (ByVal handleval As UInt32)
    Public Declare Function C11_BCCycleInsert Lib "C11W32.DLL" Alias "_C11_BCCycleInsert@8" (ByRef cycle As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_BCCycleRestart Lib "C11W32.DLL" Alias "_C11_BCCycleRestart@4" (ByVal handleval As UInt32)
    Public Declare Function C11_BCCycleWrite Lib "C11W32.DLL" Alias "_C11_BCCycleWrite@12" (ByVal index As Int32, ByRef cycle As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_ClrAllILLEGAL Lib "C11W32.DLL" Alias "_C11_ClrAllILLEGAL@4" (ByVal handleval As UInt32)
    Public Declare Sub C11_ClrILLEGAL Lib "C11W32.DLL" Alias "_C11_ClrILLEGAL@20" (ByVal subaddr As Int32, ByVal trbit As Int32, ByVal mcflag As Int32, ByVal bcastflag As Int32, ByVal handleval As UInt32)
    Public Declare Function C11_Div Lib "C11W32.DLL" Alias "_C11_Div@8" (ByVal diva As UInt32, ByVal divb As UInt32) As UInt32
    Public Declare Sub C11_FillMem Lib "C11W32.DLL" Alias "_C11_FillMem@16" (ByVal data As UInt16, ByVal wordoffset As UInt16, ByVal iwordcount As Int32, ByVal handleval As UInt32)
    Public Declare Function C11_GetBCAST Lib "C11W32.DLL" Alias "_C11_GetBCAST@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetBUF Lib "C11W32.DLL" Alias "_C11_GetBUF@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetCHAN Lib "C11W32.DLL" Alias "_C11_GetCHAN@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetCIRCLE Lib "C11W32.DLL" Alias "_C11_GetCIRCLE@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetDYNBC Lib "C11W32.DLL" Alias "_C11_GetDYNBC@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetEXT Lib "C11W32.DLL" Alias "_C11_GetEXT@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetHigh Lib "C11W32.DLL" Alias "_C11_GetHigh@4" (ByVal val As UInt32) As UInt16
    Public Declare Function C11_GetILLEGAL Lib "C11W32.DLL" Alias "_C11_GetILLEGAL@20" (ByVal subaddr As Int32, ByVal trbit As Int32, ByVal mcflag As Int32, ByVal bcastflag As Int32, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetINT Lib "C11W32.DLL" Alias "_C11_GetINT@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetIntLog Lib "C11W32.DLL" Alias "_C11_GetIntLog@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetINTMASK Lib "C11W32.DLL" Alias "_C11_GetINTMASK@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetLow Lib "C11W32.DLL" Alias "_C11_GetLow@4" (ByVal val As UInt32) As UInt16
    Public Declare Function C11_GetMODE Lib "C11W32.DLL" Alias "_C11_GetMODE@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetMonCtrl Lib "C11W32.DLL" Alias "_C11_GetMonCtrl@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_GetMonFilt Lib "C11W32.DLL" Alias "_C11_GetMonFilt@12" (ByRef valuel As UInt16, ByRef valueh As UInt16, ByVal handleval As UInt32)
    Public Declare Function C11_GetPP Lib "C11W32.DLL" Alias "_C11_GetPP@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetRTADDR Lib "C11W32.DLL" Alias "_C11_GetRTADDR@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetStatus Lib "C11W32.DLL" Alias "_C11_GetStatus@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetSTD Lib "C11W32.DLL" Alias "_C11_GetSTD@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetTIMEOUT Lib "C11W32.DLL" Alias "_C11_GetTIMEOUT@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_GetXMTSW Lib "C11W32.DLL" Alias "_C11_GetXMTSW@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_HeapAlloc Lib "C11W32.DLL" Alias "_C11_HeapAlloc@8" (ByVal wordcount As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_HeapAvail Lib "C11W32.DLL" Alias "_C11_HeapAvail@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_HeapClear Lib "C11W32.DLL" Alias "_C11_HeapClear@4" (ByVal handleval As UInt32)
    Public Declare Function C11_HeapRdHead Lib "C11W32.DLL" Alias "_C11_HeapRdHead@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_HeapWrHead Lib "C11W32.DLL" Alias "_C11_HeapWrHead@8" (ByVal value As UInt16, ByVal handleval As UInt32)
    Public Declare Function C11_INTDisable Lib "C11W32.DLL" Alias "_C11_INTDisable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_INTEnable Lib "C11W32.DLL" Alias "_C11_INTEnable@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_INTRdPend Lib "C11W32.DLL" Alias "_C11_INTRdPend@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_INTRdPoll Lib "C11W32.DLL" Alias "_C11_INTRdPoll@4" (ByVal handleval As UInt32) As Int32
    Public Declare Sub C11_INTReset Lib "C11W32.DLL" Alias "_C11_INTReset@4" (ByVal handleval As UInt32)
    Public Declare Function C11_IsBC Lib "C11W32.DLL" Alias "_C11_IsBC@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_IsMON Lib "C11W32.DLL" Alias "_C11_IsMON@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_IsRT Lib "C11W32.DLL" Alias "_C11_IsRT@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_IsRTMON Lib "C11W32.DLL" Alias "_C11_IsRTMON@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_MakeLong Lib "C11W32.DLL" Alias "_C11_MakeLong@8" (ByVal valh As UInt16, ByVal vall As UInt16) As UInt32
    Public Declare Function C11_Mask Lib "C11W32.DLL" Alias "_C11_Mask@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function C11_Mod Lib "C11W32.DLL" Alias "_C11_Mod@8" (ByVal moda As UInt32, ByVal modb As UInt32) As UInt32
    Public Declare Sub C11_MONAll Lib "C11W32.DLL" Alias "_C11_MONAll@4" (ByVal handleval As UInt32)
    Public Declare Function C11_MONBlockBase Lib "C11W32.DLL" Alias "_C11_MONBlockBase@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_MONDataBase Lib "C11W32.DLL" Alias "_C11_MONDataBase@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_MONNone Lib "C11W32.DLL" Alias "_C11_MONNone@4" (ByVal handleval As UInt32)
    Public Declare Function C11_Mul Lib "C11W32.DLL" Alias "_C11_Mul@8" (ByVal mula As UInt32, ByVal mulb As UInt32) As UInt32
    Public Declare Function C11_OkayHandle Lib "C11W32.DLL" Alias "_C11_OkayHandle@4" (ByVal handleval As UInt32) As Int32
    Public Declare Function C11_OpenDevice Lib "C11W32.DLL" Alias "_C11_OpenDevice@4" (ByVal device_id As IntPtr) As UInt32
    Public Declare Function C11_PackRTCWD Lib "C11W32.DLL" Alias "_C11_PackRTCWD@20" (ByVal subaddr As Int32, ByVal trbit As Int32, ByVal mcflag As Int32, ByVal bcastflag As Int32, ByVal count As Int32) As UInt16
    Public Declare Function C11_PeekAttr Lib "C11W32.DLL" Alias "_C11_PeekAttr@8" (ByVal wordoffset As UInt16, ByVal handleval As UInt32) As Byte
    Public Declare Sub C11_PeekStrAttr Lib "C11W32.DLL" Alias "_C11_PeekStrAttr@16" (ByRef pwbuffer As UInt16, ByVal wordoffset As UInt16, ByVal iwordcount As Int32, ByVal handleval As UInt32)
    Public Declare Sub C11_PeekStrMem Lib "C11W32.DLL" Alias "_C11_PeekStrMem@16" (ByRef pwbuffer As UInt16, ByVal wordoffset As UInt16, ByVal iwordcount As Int32, ByVal handleval As UInt32)
    Public Declare Sub C11_PokeAttr Lib "C11W32.DLL" Alias "_C11_PokeAttr@12" (ByVal data As Byte, ByVal wordoffset As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_PokeStrAttr Lib "C11W32.DLL" Alias "_C11_PokeStrAttr@16" (ByRef pwbuffer As UInt16, ByVal wordoffset As UInt16, ByVal iwordcount As Int32, ByVal handleval As UInt32)
    Public Declare Sub C11_PokeStrMem Lib "C11W32.DLL" Alias "_C11_PokeStrMem@16" (ByRef pwbuffer As UInt16, ByVal wordoffset As UInt16, ByVal iwordcount As Int32, ByVal handleval As UInt32)
    Public Declare Function C11_RTAddrData Lib "C11W32.DLL" Alias "_C11_RTAddrData@12" (ByVal typeval As UInt16, ByVal cwd As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_RTAddrDesc Lib "C11W32.DLL" Alias "_C11_RTAddrDesc@12" (ByVal typeval As UInt16, ByVal cwd As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_RTAddrParity Lib "C11W32.DLL" Alias "_C11_RTAddrParity@4" (ByVal rtaddr As Int32) As Int32
    Public Declare Sub C11_RTInitData Lib "C11W32.DLL" Alias "_C11_RTInitData@8" (ByVal scheme As UInt16, ByVal handleval As UInt32)
    Public Declare Function C11_RTPokeData Lib "C11W32.DLL" Alias "_C11_RTPokeData@12" (ByVal cwd As UInt16, ByRef data As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_RTRdDesc Lib "C11W32.DLL" Alias "_C11_RTRdDesc@12" (ByVal cwd As UInt16, ByRef desc As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_RTWrDesc Lib "C11W32.DLL" Alias "_C11_RTWrDesc@12" (ByVal cwd As UInt16, ByRef desc As UInt16, ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_SetAllILLEGAL Lib "C11W32.DLL" Alias "_C11_SetAllILLEGAL@4" (ByVal handleval As UInt32)
    Public Declare Sub C11_SetBCAST Lib "C11W32.DLL" Alias "_C11_SetBCAST@8" (ByVal enableval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetBUF Lib "C11W32.DLL" Alias "_C11_SetBUF@8" (ByVal enableval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetCHAN Lib "C11W32.DLL" Alias "_C11_SetCHAN@8" (ByVal chanval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetCIRCLE Lib "C11W32.DLL" Alias "_C11_SetCIRCLE@8" (ByVal circleval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetDYNBC Lib "C11W32.DLL" Alias "_C11_SetDYNBC@8" (ByVal enableval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetEXT Lib "C11W32.DLL" Alias "_C11_SetEXT@8" (ByVal enableval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetILLEGAL Lib "C11W32.DLL" Alias "_C11_SetILLEGAL@20" (ByVal subaddr As Int32, ByVal trbit As Int32, ByVal mcflag As Int32, ByVal bcastflag As Int32, ByVal handleval As UInt32)
    Public Declare Sub C11_SetINT Lib "C11W32.DLL" Alias "_C11_SetINT@8" (ByVal enableval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetIntLog Lib "C11W32.DLL" Alias "_C11_SetIntLog@8" (ByVal addressval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetINTMASK Lib "C11W32.DLL" Alias "_C11_SetINTMASK@8" (ByVal maskval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C11_SetLog Lib "C11W32.DLL" Alias "_C11_SetLog@8" (ByVal enableval As UInt16, ByVal handleval As UInt32) As Int32
    Public Declare Sub C11_SetMODE Lib "C11W32.DLL" Alias "_C11_SetMODE@8" (ByVal modeval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetMonCtrl Lib "C11W32.DLL" Alias "_C11_SetMonCtrl@8" (ByVal enableval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetMonFilt Lib "C11W32.DLL" Alias "_C11_SetMonFilt@12" (ByVal valuel As UInt16, ByVal valueh As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetPP Lib "C11W32.DLL" Alias "_C11_SetPP@8" (ByVal enableval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetRTADDR Lib "C11W32.DLL" Alias "_C11_SetRTADDR@8" (ByVal rtaddr As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetStatus Lib "C11W32.DLL" Alias "_C11_SetStatus@12" (ByVal flags As UInt16, ByVal immclear As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetSTD Lib "C11W32.DLL" Alias "_C11_SetSTD@8" (ByVal enableval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetTIMEOUT Lib "C11W32.DLL" Alias "_C11_SetTIMEOUT@8" (ByVal enableval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_SetXMTSW Lib "C11W32.DLL" Alias "_C11_SetXMTSW@8" (ByVal enableval As UInt16, ByVal handleval As UInt32)
    Public Declare Function C11_Shl Lib "C11W32.DLL" Alias "_C11_Shl@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function C11_Shr Lib "C11W32.DLL" Alias "_C11_Shr@8" (ByVal dataval As UInt32, ByVal cntval As UInt16) As UInt32
    Public Declare Function C11_StatRead Lib "C11W32.DLL" Alias "_C11_StatRead@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Function C11_TTRead Lib "C11W32.DLL" Alias "_C11_TTRead@4" (ByVal handleval As UInt32) As UInt16
    Public Declare Sub C11_TTSet Lib "C11W32.DLL" Alias "_C11_TTSet@8" (ByVal timetagval As UInt16, ByVal handleval As UInt32)
    Public Declare Sub C11_TTZero Lib "C11W32.DLL" Alias "_C11_TTZero@4" (ByVal handleval As UInt32)
    Public Declare Sub C11_UnpackRTCWD Lib "C11W32.DLL" Alias "_C11_UnpackRTCWD@24" (ByVal cwd As UInt16, ByRef subaddr As Int32, ByRef trbit As Int32, ByRef mcflag As Int32, ByRef bcastflag As Int32, ByRef count As Int32)
    Public Declare Sub C11_WipeMem Lib "C11W32.DLL" Alias "_C11_WipeMem@4" (ByVal handleval As UInt32)

    Public Const CONFIG_DEFAULT As UInt32 = &H0L '//Select all default settings (default)
    Public Const CONFIG_INTCLK As UInt32 = &H0L  '//Use internal clock (default)
    Public Const CONFIG_EXTCLK As UInt32 = &H1L  '//Use external clock
    Public Const CONFIG_NOBUF As UInt32 = &H0L   '//Do not use buffer mode (default)
    Public Const CONFIG_BUF As UInt32 = &H2L '//Enable use of buffer mode
    Public Const CONFIG_NOBCAST As UInt32 = &H0L '//Do not respond to broadcast messages (default)
    Public Const CONFIG_BCAST As UInt32 = &H4L   '//Respond to broadcast messages
    Public Const CONFIG_STDB As UInt32 = &H0L    '//Use MIL-STD-1553B standard (default)
    Public Const CONFIG_STDA As UInt32 = &H8L    '//Use MIL-STD-1553A standard
    Public Const CONFIG_NODYNBC As UInt32 = &H0L '//Do not respond to dynamic BC mode code (default)
    Public Const CONFIG_DYNBC As UInt32 = &H10L   '//Respond to dynamic BC mode code
    Public Const CONFIG_NOALTRETRY As UInt32 = &H0L  '//Retries are not on alternate busses (BC) (default)
    Public Const CONFIG_ALTRETRY As UInt32 = &H20L    '//Retries on alternate busses (BC)
    Public Const CONFIG_NOXMITSW As UInt32 = &H0L    '//Do not respond to xmit last status mode code (default)
    Public Const CONFIG_XMITSW As UInt32 = &H40L  '//Respond to transmit last status mode code
    Public Const CONFIG_ALLSUBADDR As UInt32 = &H0L  '//Respond to all subaddresses (default)
    Public Const CONFIG_NOSUBADDR As UInt32 = &H80L   '//Do not respond to any subaddresses
    Public Const CONFIG_WIPE As UInt32 = &H0L    '//Fills memory with zeros (default)
    Public Const CONFIG_NOWIPE As UInt32 = &H100L  '//Does not fill memory with zeros
    Public Const CONFIG_INIT As UInt32 = &H0L    '//Initialize mode (default)
    Public Const CONFIG_NOINIT As UInt32 = &H200L  '//Does not initialize mode
    Public Const CONFIG_LOGLIST As UInt32 = &H0L '//Enable log list (default)
    Public Const CONFIG_NOLOGLIST As UInt32 = &H400L   '//Disable log list
    Public Const CONFIG_NONOTICE2 As UInt32 = &H0L   '//Enable log list (default)
    Public Const CONFIG_NOTICE2 As UInt32 = &H800L '//Disable log list
    Public Const CONFIG_MONALL As UInt32 = &H0L  '//Enable monitoring of all RTs (default)
    Public Const CONFIG_MONNONE As UInt32 = &H1000L '//Disable monitoring of all RTs
    Public Const CONFIG_REGTIMEOUT As UInt32 = &H0L  '//14us timeout (BC,MON) (default)
    Public Const CONFIG_EXTTIMEOUT As UInt32 = &H2000L  '//30us extended timeout (BC,MON)
    Public Const CONFIG_CHANAB As UInt32 = &H0L  '//Respond to both channels (default)
    Public Const CONFIG_CHANA As UInt32 = &H10000L   '//Respond to channel A
    Public Const CONFIG_CHANB As UInt32 = &H20000L   '//Respond to channel B
    Public Const CONFIG_SINGLEBUF As UInt32 = &H0L   '//Use single buffer (RT) (default)
    Public Const CONFIG_PINGPONG As UInt32 = &H100000L    '//Use ping-pong mode (RT)
    Public Const CONFIG_CIRC1BUF As UInt32 = &H200000L    '//Use circular #1 buffers (RT)
    Public Const CONFIG_CIRC2BUF As UInt32 = &H300000L    '//Use circular #2 buffers (RT)

    Public Const SWD_IMCLR As UInt16 = &H8000   '//Immediate clear
    Public Const SWD_BIT10 As UInt16 = &H200   '//Status word bit 10
    Public Const SWD_INS As UInt16 = &H200 '//Instrumentation bit
    Public Const SWD_BIT11 As UInt16 = &H100   '//Status word bit 11
    Public Const SWD_SRQ As UInt16 = &H100 '//Service request bit
    Public Const SWD_BIT12 As UInt16 = &H80   '//Status word bit 12
    Public Const SWD_BIT13 As UInt16 = &H40   '//Status word bit 13
    Public Const SWD_BIT14 As UInt16 = &H20   '//Status word bit 14
    Public Const SWD_BIT15 As UInt16 = &H10   '//Status word bit 15
    Public Const SWD_BIT16 As UInt16 = &H8   '//Status word bit 16
    Public Const SWD_BUSY As UInt16 = &H8    '//Busy bit
    Public Const SWD_BIT17 As UInt16 = &H4   '//Status word bit 17
    Public Const SWD_SSYSF As UInt16 = &H4   '//Subsystem flag bit
    Public Const SWD_BIT18 As UInt16 = &H2   '//Status word bit 18
    Public Const SWD_BIT19 As UInt16 = &H1   '//Status word bit 19
    Public Const SWD_TF As UInt16 = &H1  '//Terminal flag

    Public Const INT_DMAF As UInt16 = &H8000    '//BC,RT,MON
    Public Const INT_WRAPF As UInt16 = &H4000   '//BC,RT
    Public Const INT_TAPF As UInt16 = &H2000    '//RT
    Public Const INT_BITF As UInt16 = &H1000    '//BC,RT,MON
    Public Const INT_MERR As UInt16 = &H800    '//BC,RT,MON
    Public Const INT_SUBAD As UInt16 = &H400   '//RT
    Public Const INT_BDRCV As UInt16 = &H200   '//RT
    Public Const INT_IXEQ0 As UInt16 = &H100   '//RT
    Public Const INT_ILCMD As UInt16 = &H80   '//RT
    Public Const INT_EOL As UInt16 = &H20 '//BC
    Public Const INT_ILLCMD As UInt16 = &H10  '//BC
    Public Const INT_ILLOP As UInt16 = &H8   '//BC
    Public Const INT_RTF As UInt16 = &H4 '//BC
    Public Const INT_CBA As UInt16 = &H2 '//BC
    Public Const INT_MBC As UInt16 = &H1 '//MON
    Public Const INT_NONE As UInt16 = &H0    '//No interrupts

    Public Const REG_INT As UInt16 = &H0 '//Interrupt register
    Public Const REG_PAGE As UInt16 = &H1    '//Page register
    Public Const REG_EXT As UInt16 = &H2 '//External register
    Public Const REG_RESV As UInt16 = &H3    '//Reserved register
    Public Const REG_INTC As UInt16 = &H4    '//Interrupt clear register
    Public Const REG_RST As UInt16 = &H5 '//Reset register
    Public Const REG_ERR As UInt16 = &H6 '//Error register
    Public Const REG_PWE As UInt16 = &H7 '//Prom write enable register

    Public Const BUSA As Int16 = 0  '//Selects bus A
    Public Const BUSB As Int16 = 1  '//Selects bus B

    Public Const MONNO As Int16 = 0 '//Disables monitoring of a terminal address
    Public Const MONYES As Int16 = 1    '//Enables monitoring of a terminal address

    Public Const COND_NONE As UInt16 = &H0   '//No condition
    Public Const COND_FAIL As UInt16 = &H2000   '//Condition when all retries have failed
    Public Const COND_UNCOND As UInt16 = &H4000 '//Unconditional
    Public Const COND_SRQ As UInt16 = &H2    '//Condition on Service Request bit set in status word
    Public Const COND_INS As UInt16 = &H4    '//Condition on Instrumentation bit set in status word
    Public Const COND_SSFAIL As UInt16 = &H8 '//Condition on Subsystem Fail bit set in status word
    Public Const COND_TF As UInt16 = &H10 '//Condition on Terminal Flag bit set in status word
    Public Const COND_BUSY As UInt16 = &H20   '//Condition on Busy bit set in status word
    Public Const COND_ME As UInt16 = &H40 '//Condition on Message Error bit set in status word
    Public Const COND_RESPERR As UInt16 = &H80    '//Condition on response error
    Public Const COND_MASK As UInt16 = &HFE

    Public Const SUMMIT_CTRL As UInt16 = &H0 '//Control register
    Public Const SUMMIT_OPSTAT As UInt16 = &H1   '//Operational status
    Public Const SUMMIT_CURRCMD As UInt16 = &H2  '//Current Command
    Public Const SUMMIT_INTMASK As UInt16 = &H3  '//Interrupt Mask
    Public Const SUMMIT_INTPEND As UInt16 = &H4  '//Interrupt Pending
    Public Const SUMMIT_INTLOG As UInt16 = &H5   '//Interrupt Log
    Public Const SUMMIT_BITWORD As UInt16 = &H6  '//BIT Word
    Public Const SUMMIT_TTMFT As UInt16 = &H7    '//Time-Tag/Minor Frame Timer
    Public Const SUMMIT_RTDACBA As UInt16 = &H8  '//RT Descriptor/Command Block Pointer
    Public Const SUMMIT_RTSTATUS As UInt16 = &H9 '//RT Status Word
    Public Const SUMMIT_CBC As UInt16 = &HA  '//Command Block Init Count
    Public Const SUMMIT_MBA As UInt16 = &HB  '//Monitor Block
    Public Const SUMMIT_MDA As UInt16 = &HC  '//Monitor Data
    Public Const SUMMIT_MBC As UInt16 = &HD  '//Monitor Block Count
    Public Const SUMMIT_MFH As UInt16 = &HE  '//Monitor Filter High
    Public Const SUMMIT_MFL As UInt16 = &HF  '//Monitor Filter Low

    Public Const ERR_NONE As Int16 = 0  '//No error
    Public Const ERR_UNKNOWN As Int16 = -1  '//An unexpected error occurred
    Public Const ERR_NOCS As Int16 = -10    '//Card Services is not present
    Public Const ERR_NOSOCKET As Int16 = -11    '//The specified socket is not present
    Public Const ERR_NOCARD As Int16 = -12  '//Unable to find a CM1553-1 card in the specified socket
    Public Const ERR_NOTSR As Int16 = -13   '//Unable to find the CM1553-1 memory resident driver
    Public Const ERR_CLIENT As Int16 = -14  '//Unable to install a local client driver
    Public Const ERR_CS As Int16 = -15  '//An error was returned by Card Services
    Public Const ERR_WIN As Int16 = -16 '//Card Services could not configure the memory window, I/O window, or IRQ steering
    Public Const ERR_SEL As Int16 = -17 '//Unable to allocate a memory selector
    Public Const ERR_BADHANDLE As Int16 = -20   '//A bad handle was specified
    Public Const ERR_COUNT As Int16 = -21   '//An invalid count was specified
    Public Const ERR_ALLOC As Int16 = -22   '//Not enough memory to allocate
    Public Const ERR_INDEX As Int16 = -23   '//The command block index was invalid or the schedule is full
    Public Const ERR_RETRY As Int16 = -31   '//The retry parameter is out of range
    Public Const ERR_COND As Int16 = -32    '//An invalid condition condition parameter was specified
    Public Const ERR_BADMSG As Int16 = -33  '//The specified command block is not a message block
    Public Const ERR_RTRT As Int16 = -34    '//The command words are not a valid RT-RT message
    Public Const ERR_RESPONSE As Int16 = -35    '//A bad response or no response was received from an RT
    Public Const ERR_FNAME As Int16 = -40   '//Bad filenames were specified
    Public Const ERR_FRDWR As Int16 = -41   '//There was an error reading or writing the HEX file
    Public Const ERR_HEX As Int16 = -42 '//There was a bad hex character in the HEX file
    Public Const ERR_CRC As Int16 = -43 '//There was a bad checksum in the HEX file
    Public Const ERR_TYPE As Int16 = -44    '//There was a bad type value in the HEX file
    Public Const ERR_CISRANGE As Int16 = -90    '//The specified address is outside of the CS address range
    Public Const ERR_CISNONE As Int16 = -91 '//The CIS is not visible
    Public Const ERR_CISENB As Int16 = -92  '//The PWE register cannot be enabled
    Public Const ERR_CISMAGIC As Int16 = -93    '//Unable to write to the PWE register
    Public Const ERR_VXD As Int16 = -100    '//Error returned from VXD

End Module
