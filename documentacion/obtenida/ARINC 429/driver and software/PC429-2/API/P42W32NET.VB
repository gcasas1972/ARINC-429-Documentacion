Option Strict Off
Option Explicit On

Imports System.Runtime.InteropServices

Module P42W32VB

    '/**
    '*
    '*  PC429-1/2 WIN32 DRIVER  Version 1.0  (01/15/2009)
    '*  Copyright (c) 1997-2009
    '*  Ballard Technology, Inc.
    '*  www.ballardtech.com
    '*  support@ballardtech.com
    '*  ALL RIGHTS RESERVED
    '*
    '*  NAME:   P42W32NET.VB -- Visual Basic .NET
    '*                          PC429-1/2 Driver Header File.
    '*
    '**/

    '/**
    '*
    '*  This file defines the procedures provided by the 32-bit
    '*  Driver Library for the PC429-1/2.  Visual Basic
    '*  applications using the PC429-1/2 Driver Library must
    '*  incorporate this text file into the Visual Basic project.
    '*
    '**/

    '/**
    '*
    '*  PC429-1/2 Driver functions.
    '*
    '**/

    Public Declare Function PC429_Active Lib "P42W32.DLL" Alias "_PC429_Active@8" (ByVal channels As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_BrdNum Lib "P42W32.DLL" Alias "_PC429_BrdNum@8" (ByVal brdnum As Short, ByVal handleval As Integer) As Short
    Public Declare Sub PC429_BrdStat Lib "P42W32.DLL" Alias "_PC429_BrdStat@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Function PC429_Check Lib "P42W32.DLL" Alias "_PC429_Check@16" (ByVal memval As Integer, ByVal ioval As Integer, ByVal irqval As Integer, ByVal drqval As Integer) As Integer
    Public Declare Function PC429_CheckChan Lib "P42W32.DLL" Alias "_PC429_CheckChan@4" (ByVal handleval As Integer) As Short
    Public Declare Sub PC429_CLI Lib "P42W32.DLL" Alias "_PC429_CLI@4" (ByVal handleval As Integer)
    Public Declare Sub PC429_Close Lib "P42W32.DLL" Alias "_PC429_Close@4" (ByVal handleval As Integer)
    Public Declare Function PC429_ClrMsgFilt Lib "P42W32.DLL" Alias "_PC429_ClrMsgFilt@4" (ByVal handleval As Integer) As Short
    Public Declare Function PC429_Comm Lib "P42W32.DLL" Alias "_PC429_Comm@16" (ByVal command As Short, ByVal count As Short, ByRef value As Short, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_CommPoll Lib "P42W32.DLL" Alias "_PC429_CommPoll@16" (ByVal command As Short, ByVal count As Short, ByRef value As Short, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_CreateMsg Lib "P42W32.DLL" Alias "_PC429_CreateMsg@4" (ByVal handleval As Integer) As Integer
    Public Declare Function PC429_DecRdData Lib "P42W32.DLL" Alias "_PC429_DecRdData@8" (ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_DecRdErr Lib "P42W32.DLL" Alias "_PC429_DecRdErr@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_DecRdOvf Lib "P42W32.DLL" Alias "_PC429_DecRdOvf@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_DecRdSeq Lib "P42W32.DLL" Alias "_PC429_DecRdSeq@8" (ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_DecRdSrq Lib "P42W32.DLL" Alias "_PC429_DecRdSrq@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Sub PC429_DecWrCtrl Lib "P42W32.DLL" Alias "_PC429_DecWrCtrl@12" (ByVal value As Short, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub PC429_DecWrReset Lib "P42W32.DLL" Alias "_PC429_DecWrReset@12" (ByVal value As Short, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Function PC429_DllUsageCount Lib "P42W32.DLL" Alias "_PC429_DllUsageCount@0" () As Integer
    Public Declare Function PC429_ElapseClk Lib "P42W32.DLL" Alias "_PC429_ElapseClk@8" (ByVal channels As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_EncRdOvf Lib "P42W32.DLL" Alias "_PC429_EncRdOvf@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_EncRdSrq Lib "P42W32.DLL" Alias "_PC429_EncRdSrq@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Sub PC429_EncWrCtrl Lib "P42W32.DLL" Alias "_PC429_EncWrCtrl@12" (ByVal value As Short, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub PC429_EncWrData Lib "P42W32.DLL" Alias "_PC429_EncWrData@12" (ByVal value As Integer, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub PC429_EncWrGap Lib "P42W32.DLL" Alias "_PC429_EncWrGap@12" (ByVal value As Short, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub PC429_EncWrReset Lib "P42W32.DLL" Alias "_PC429_EncWrReset@12" (ByVal value As Short, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub PC429_EncWrSeq Lib "P42W32.DLL" Alias "_PC429_EncWrSeq@12" (ByVal value As Integer, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Function PC429_Error Lib "P42W32.DLL" Alias "_PC429_Error@8" (ByVal channels As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_Extern Lib "P42W32.DLL" Alias "_PC429_Extern@8" (ByVal channels As Short, ByVal handleval As Integer) As Short
    Public Declare Sub PC429_FreeDrv Lib "P42W32.DLL" Alias "_PC429_FreeDrv@0" ()
    Public Declare Function PC429_FromAscii Lib "P42W32.DLL" Alias "_PC429_FromAscii@8" (ByVal asciistr As String, ByVal radixval As Short) As Integer
    Public Declare Sub PC429_Gate Lib "P42W32.DLL" Alias "_PC429_Gate@8" (ByVal command As Short, ByVal handleval As Integer)
    Public Declare Function PC429_GetBCDData Lib "P42W32.DLL" Alias "_PC429_GetBCDData@12" (ByVal msgval As Integer, ByVal msb As Short, ByVal lsb As Short) As Integer
    Public Declare Function PC429_GetBCDMant Lib "P42W32.DLL" Alias "_PC429_GetBCDMant@8" (ByVal msgval As Integer, ByVal sigdig As Short) As Integer
    Public Declare Function PC429_GetBCDSign Lib "P42W32.DLL" Alias "_PC429_GetBCDSign@4" (ByVal msgval As Integer) As Short
    Public Declare Function PC429_GetBCDSSM Lib "P42W32.DLL" Alias "_PC429_GetBCDSSM@4" (ByVal msgval As Integer) As Short
    Public Declare Sub PC429_GetBCDVal Lib "P42W32.DLL" Alias "_PC429_GetBCDVal@16" (ByVal resultstr As String, ByVal msgval As Integer, ByVal sigdig As Short, ByVal resolstr As String)
    Public Declare Function PC429_GetBNRData Lib "P42W32.DLL" Alias "_PC429_GetBNRData@16" (ByVal msgval As Integer, ByVal msb As Short, ByVal lsb As Short, ByVal twos As Short) As Integer
    Public Declare Function PC429_GetBNRMant Lib "P42W32.DLL" Alias "_PC429_GetBNRMant@8" (ByVal msgval As Integer, ByVal sigbit As Short) As Integer
    Public Declare Function PC429_GetBNRSign Lib "P42W32.DLL" Alias "_PC429_GetBNRSign@4" (ByVal msgval As Integer) As Short
    Public Declare Function PC429_GetBNRSSM Lib "P42W32.DLL" Alias "_PC429_GetBNRSSM@4" (ByVal msgval As Integer) As Short
    Public Declare Sub PC429_GetBNRVal Lib "P42W32.DLL" Alias "_PC429_GetBNRVal@16" (ByVal resultstr As String, ByVal msgval As Integer, ByVal sigbit As Short, ByVal resolstr As String)
    Public Declare Function PC429_GetFilt Lib "P42W32.DLL" Alias "_PC429_GetFilt@16" (ByVal labelval As Short, ByVal sdival As Short, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_GetFldData Lib "P42W32.DLL" Alias "_PC429_GetFldData@4" (ByVal msgval As Integer) As Integer
    Public Declare Function PC429_GetFldLabel Lib "P42W32.DLL" Alias "_PC429_GetFldLabel@4" (ByVal msgval As Integer) As Short
    Public Declare Function PC429_GetFldParity Lib "P42W32.DLL" Alias "_PC429_GetFldParity@4" (ByVal msgval As Integer) As Short
    Public Declare Function PC429_GetFldSDI Lib "P42W32.DLL" Alias "_PC429_GetFldSDI@4" (ByVal msgval As Integer) As Short
    Public Declare Function PC429_GetFldValue Lib "P42W32.DLL" Alias "_PC429_GetFldValue@12" (ByVal msgval As Integer, ByVal startbit As Short, ByVal endbit As Short) As Integer
    Public Declare Function PC429_GetGap Lib "P42W32.DLL" Alias "_PC429_GetGap@12" (ByVal indexval As Short, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_GetMsg Lib "P42W32.DLL" Alias "_PC429_GetMsg@12" (ByVal indexval As Short, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_GetMsgCnt Lib "P42W32.DLL" Alias "_PC429_GetMsgCnt@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Sub PC429_Halt Lib "P42W32.DLL" Alias "_PC429_Halt@4" (ByVal handleval As Integer)
    Public Declare Function PC429_HighSpeed Lib "P42W32.DLL" Alias "_PC429_HighSpeed@8" (ByVal channels As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_Init Lib "P42W32.DLL" Alias "_PC429_Init@0" () As Integer
    Public Declare Function PC429_InsFilt Lib "P42W32.DLL" Alias "_PC429_InsFilt@16" (ByVal labelval As Short, ByVal sdival As Short, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_InsMsg Lib "P42W32.DLL" Alias "_PC429_InsMsg@20" (ByVal indexval As Short, ByVal msgval As Integer, ByVal gapval As Integer, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_IsOldBrd Lib "P42W32.DLL" Alias "_PC429_IsOldBrd@4" (ByVal handleval As Integer) As Short
    Public Declare Function PC429_IsRcv Lib "P42W32.DLL" Alias "_PC429_IsRcv@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_IsXmit Lib "P42W32.DLL" Alias "_PC429_IsXmit@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_Load Lib "P42W32.DLL" Alias "_PC429_Load@8" (ByVal filename As String, ByVal handleval As Integer) As Short
    Public Declare Function PC429_NameToAddr Lib "P42W32.DLL" Alias "_PC429_NameToAddr@12" (ByVal nameptr As String, ByVal handleval As Integer, ByVal filename As String) As Integer
    Public Declare Function PC429_Open Lib "P42W32.DLL" Alias "_PC429_Open@4" (ByVal cardnum As Integer) As Integer
    Public Declare Function PC429_OscClk Lib "P42W32.DLL" Alias "_PC429_OscClk@8" (ByVal oscval As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_Parity Lib "P42W32.DLL" Alias "_PC429_Parity@8" (ByVal channels As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_PeekMsg Lib "P42W32.DLL" Alias "_PC429_PeekMsg@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub PC429_PokeeMsg Lib "P42W32.DLL" Alias "_PC429_PokeeMsg@12" (ByVal addrval As Integer, ByVal msgval As Integer, ByVal handleval As Integer)
    Public Declare Sub PC429_PokeMsg Lib "P42W32.DLL" Alias "_PC429_PokeMsg@12" (ByVal addrval As Integer, ByVal msgval As Integer, ByVal handleval As Integer)
    Public Declare Sub PC429_Pulse Lib "P42W32.DLL" Alias "_PC429_Pulse@4" (ByVal handleval As Integer)
    Public Declare Function PC429_PutBCDData Lib "P42W32.DLL" Alias "_PC429_PutBCDData@16" (ByVal msgval As Integer, ByVal value As Integer, ByVal msb As Short, ByVal lsb As Short) As Integer
    Public Declare Function PC429_PutBCDMant Lib "P42W32.DLL" Alias "_PC429_PutBCDMant@16" (ByVal msgval As Integer, ByVal value As Integer, ByVal sigdig As Short, ByVal sign As Short) As Integer
    Public Declare Function PC429_PutBCDSign Lib "P42W32.DLL" Alias "_PC429_PutBCDSign@8" (ByVal msgval As Integer, ByVal sign As Short) As Integer
    Public Declare Function PC429_PutBCDSSM Lib "P42W32.DLL" Alias "_PC429_PutBCDSSM@8" (ByVal msgval As Integer, ByVal value As Short) As Integer
    Public Declare Function PC429_PutBCDVal Lib "P42W32.DLL" Alias "_PC429_PutBCDVal@16" (ByVal valuestr As String, ByVal msgval As Integer, ByVal sigdig As Short, ByVal resolstr As String) As Integer
    Public Declare Function PC429_PutBNRData Lib "P42W32.DLL" Alias "_PC429_PutBNRData@20" (ByVal msgval As Integer, ByVal value As Integer, ByVal msb As Short, ByVal lsb As Short, ByVal twos As Short) As Integer
    Public Declare Function PC429_PutBNRMant Lib "P42W32.DLL" Alias "_PC429_PutBNRMant@16" (ByVal msgval As Integer, ByVal value As Integer, ByVal sigbit As Short, ByVal twos As Short) As Integer
    Public Declare Function PC429_PutBNRSign Lib "P42W32.DLL" Alias "_PC429_PutBNRSign@8" (ByVal msgval As Integer, ByVal sign As Short) As Integer
    Public Declare Function PC429_PutBNRSSM Lib "P42W32.DLL" Alias "_PC429_PutBNRSSM@8" (ByVal msgval As Integer, ByVal value As Short) As Integer
    Public Declare Function PC429_PutBNRVal Lib "P42W32.DLL" Alias "_PC429_PutBNRVal@16" (ByVal valuestr As String, ByVal msgval As Integer, ByVal sigbit As Short, ByVal resolstr As String) As Integer
    Public Declare Function PC429_PutFldData Lib "P42W32.DLL" Alias "_PC429_PutFldData@8" (ByVal msgval As Integer, ByVal dataval As Integer) As Integer
    Public Declare Function PC429_PutFldLabel Lib "P42W32.DLL" Alias "_PC429_PutFldLabel@8" (ByVal msgval As Integer, ByVal labelval As Short) As Integer
    Public Declare Function PC429_PutFldSDI Lib "P42W32.DLL" Alias "_PC429_PutFldSDI@8" (ByVal msgval As Integer, ByVal sdival As Short) As Integer
    Public Declare Function PC429_PutFldValue Lib "P42W32.DLL" Alias "_PC429_PutFldValue@16" (ByVal msgval As Integer, ByVal dataval As Integer, ByVal startbit As Short, ByVal endbit As Short) As Integer
    Public Declare Function PC429_RdClk Lib "P42W32.DLL" Alias "_PC429_RdClk@4" (ByVal handleval As Integer) As Integer
    Public Declare Function PC429_RdGap Lib "P42W32.DLL" Alias "_PC429_RdGap@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_RdMsg Lib "P42W32.DLL" Alias "_PC429_RdMsg@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_RdOpt Lib "P42W32.DLL" Alias "_PC429_RdOpt@4" (ByVal handleval As Integer) As Short
    Public Declare Sub PC429_RdSeq Lib "P42W32.DLL" Alias "_PC429_RdSeq@20" (ByVal handleval As Integer, ByRef bottom As Short, ByRef top As Short, ByRef tail As Short, ByRef head As Short)
    Public Declare Function PC429_RdTime Lib "P42W32.DLL" Alias "_PC429_RdTime@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_ReadLbl Lib "P42W32.DLL" Alias "_PC429_ReadLbl@8" (ByVal label As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_ReadSym Lib "P42W32.DLL" Alias "_PC429_ReadSym@8" (ByVal symbol As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_Ready Lib "P42W32.DLL" Alias "_PC429_Ready@4" (ByVal handleval As Integer) As Short
    Public Declare Sub PC429_Rearm Lib "P42W32.DLL" Alias "_PC429_Rearm@8" (ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub PC429_Reset Lib "P42W32.DLL" Alias "_PC429_Reset@4" (ByVal handleval As Integer)
    Public Declare Function PC429_SchedBuild Lib "P42W32.DLL" Alias "_PC429_SchedBuild@24" (ByVal nummsgs As Integer, ByRef minperiod As Integer, ByRef maxperiod As Integer, ByVal speed As Integer, ByVal channel As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_SchedBuildEx Lib "P42W32.DLL" Alias "_PC429_SchedBuildEx@36" (ByVal basemsgnum As Integer, ByVal nummsgs As Integer, ByRef minperiod As Integer, ByRef maxperiod As Integer, ByVal speed As Integer, ByRef buf As Integer, ByVal bufsize As Integer, ByVal channel As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_SchedMsg Lib "P42W32.DLL" Alias "_PC429_SchedMsg@20" (ByVal index As Short, ByVal msgaddr As Integer, ByVal gapval As Integer, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function PC429_SelfTest Lib "P42W32.DLL" Alias "_PC429_SelfTest@8" (ByVal channels As Short, ByVal handleval As Integer) As Short
    Public Declare Sub PC429_SeqRecParam Lib "P42W32.DLL" Alias "_PC429_SeqRecParam@16" (ByVal channels As Integer, ByVal mode As Integer, ByVal interval As Integer, ByVal handleval As Integer)
    Public Declare Function PC429_SeqRecRd Lib "P42W32.DLL" Alias "_PC429_SeqRecRd@12" (ByRef buf As Integer, ByVal bufsize As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub PC429_SeqRecStart Lib "P42W32.DLL" Alias "_PC429_SeqRecStart@4" (ByVal handleval As Integer)
    Public Declare Sub PC429_SeqRecStop Lib "P42W32.DLL" Alias "_PC429_SeqRecStop@4" (ByVal handleval As Integer)
    Public Declare Sub PC429_SeqStat Lib "P42W32.DLL" Alias "_PC429_SeqStat@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Function PC429_Single Lib "P42W32.DLL" Alias "_PC429_Single@8" (ByVal channels As Short, ByVal handleval As Integer) As Short
    Public Declare Function PC429_SpeedClk Lib "P42W32.DLL" Alias "_PC429_SpeedClk@8" (ByVal speed As Short, ByVal handleval As Integer) As Short
    Public Declare Sub PC429_Start Lib "P42W32.DLL" Alias "_PC429_Start@4" (ByVal handleval As Integer)
    Public Declare Sub PC429_STI Lib "P42W32.DLL" Alias "_PC429_STI@4" (ByVal handleval As Integer)
    Public Declare Sub PC429_Stop Lib "P42W32.DLL" Alias "_PC429_Stop@4" (ByVal handleval As Integer)
    Public Declare Function PC429_Test Lib "P42W32.DLL" Alias "_PC429_Test@4" (ByVal handleval As Integer) As Integer
    Public Declare Sub PC429_ToAscii Lib "P42W32.DLL" Alias "_PC429_ToAscii@16" (ByVal value As Integer, ByVal asciistr As String, ByVal numbits As Short, ByVal radixval As Short)
    Public Declare Sub PC429_Uncheck Lib "P42W32.DLL" Alias "_PC429_Uncheck@4" (ByVal handleval As Integer)
    Public Declare Function PC429_UserCode Lib "P42W32.DLL" Alias "_PC429_UserCode@12" (ByRef usercode As Integer, ByVal count As Short, ByVal handleval As Integer) As Short
    Public Declare Sub PC429_VerStr Lib "P42W32.DLL" Alias "_PC429_VerStr@8" (ByVal strptr As String, ByVal count As Short)
    Public Declare Sub PC429_WipeMem Lib "P42W32.DLL" Alias "_PC429_WipeMem@4" (ByVal handleval As Integer)
    Public Declare Sub PC429_WrClk Lib "P42W32.DLL" Alias "_PC429_WrClk@8" (ByVal clock As Integer, ByVal handleval As Integer)
    Public Declare Sub PC429_WrGap Lib "P42W32.DLL" Alias "_PC429_WrGap@12" (ByVal addrval As Integer, ByVal gapval As Integer, ByVal handleval As Integer)
    Public Declare Sub PC429_WrMsg Lib "P42W32.DLL" Alias "_PC429_WrMsg@12" (ByVal addrval As Integer, ByVal msgval As Integer, ByVal handleval As Integer)
    Public Declare Sub PC429_WrOpt Lib "P42W32.DLL" Alias "_PC429_WrOpt@8" (ByVal optionval As Short, ByVal handleval As Integer)
    Public Declare Sub PC429_WrSeq Lib "P42W32.DLL" Alias "_PC429_WrSeq@20" (ByVal handleval As Integer, ByVal bottom As Short, ByVal top As Short, ByVal tail As Short, ByVal head As Short)
    Public Declare Sub PC429_WrTime Lib "P42W32.DLL" Alias "_PC429_WrTime@12" (ByVal addrval As Integer, ByVal timeval As Integer, ByVal handleval As Integer)

    Public Declare Function DRV429_Active Lib "P42W32.DLL" Alias "_DRV429_Active@8" (ByVal value As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_AllocCycle Lib "P42W32.DLL" Alias "_DRV429_AllocCycle@8" (ByVal numframes As Integer, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_AllocFilt Lib "P42W32.DLL" Alias "_DRV429_AllocFilt@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_AllocFrame Lib "P42W32.DLL" Alias "_DRV429_AllocFrame@8" (ByVal nummsgs As Integer, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_AllocGap Lib "P42W32.DLL" Alias "_DRV429_AllocGap@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_AllocHeader Lib "P42W32.DLL" Alias "_DRV429_AllocHeader@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_AllocHeap Lib "P42W32.DLL" Alias "_DRV429_AllocHeap@8" (ByVal size As Integer, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_AllocLabelTable Lib "P42W32.DLL" Alias "_DRV429_AllocLabelTable@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_AllocMsg Lib "P42W32.DLL" Alias "_DRV429_AllocMsg@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_AllocSDITable Lib "P42W32.DLL" Alias "_DRV429_AllocSDITable@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_AsciiToMant Lib "P42W32.DLL" Alias "_DRV429_AsciiToMant@12" (ByVal str As String, ByRef mant As Integer, ByRef exp As Short) As Short
    Public Declare Function DRV429_BrdNum Lib "P42W32.DLL" Alias "_DRV429_BrdNum@8" (ByVal brdnum As Short, ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_BrdStat Lib "P42W32.DLL" Alias "_DRV429_BrdStat@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Function DRV429_Check Lib "P42W32.DLL" Alias "_DRV429_Check@4" (ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_CheckChan Lib "P42W32.DLL" Alias "_DRV429_CheckChan@4" (ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_CLI Lib "P42W32.DLL" Alias "_DRV429_CLI@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_Close Lib "P42W32.DLL" Alias "_DRV429_Close@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_ClrCtrInt Lib "P42W32.DLL" Alias "_DRV429_ClrCtrInt@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_ClrDMA Lib "P42W32.DLL" Alias "_DRV429_ClrDMA@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_ClrHostInt Lib "P42W32.DLL" Alias "_DRV429_ClrHostInt@4" (ByVal handleval As Integer)
    Public Declare Function DRV429_ClrMsgFilt Lib "P42W32.DLL" Alias "_DRV429_ClrMsgFilt@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_Comm Lib "P42W32.DLL" Alias "_DRV429_Comm@16" (ByVal command As Short, ByVal count As Short, ByRef value As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_CommPoll Lib "P42W32.DLL" Alias "_DRV429_CommPoll@16" (ByVal command As Short, ByVal count As Short, ByRef value As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_CreateMsg Lib "P42W32.DLL" Alias "_DRV429_CreateMsg@4" (ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_DecRdData Lib "P42W32.DLL" Alias "_DRV429_DecRdData@8" (ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_DecRdErr Lib "P42W32.DLL" Alias "_DRV429_DecRdErr@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_DecRdOvf Lib "P42W32.DLL" Alias "_DRV429_DecRdOvf@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_DecRdSeq Lib "P42W32.DLL" Alias "_DRV429_DecRdSeq@8" (ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_DecRdSrq Lib "P42W32.DLL" Alias "_DRV429_DecRdSrq@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_DecWrCtrl Lib "P42W32.DLL" Alias "_DRV429_DecWrCtrl@12" (ByVal value As Short, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_DecWrReset Lib "P42W32.DLL" Alias "_DRV429_DecWrReset@12" (ByVal value As Short, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Function DRV429_DfltMsg Lib "P42W32.DLL" Alias "_DRV429_DfltMsg@4" (ByVal index As Short) As String
    Public Declare Function DRV429_Div Lib "P42W32.DLL" Alias "_DRV429_Div@8" (ByVal diva As Integer, ByVal divb As Integer) As Integer
    Public Declare Function DRV429_ElapseClk Lib "P42W32.DLL" Alias "_DRV429_ElapseClk@8" (ByVal value As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_EncRdOvf Lib "P42W32.DLL" Alias "_DRV429_EncRdOvf@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_EncRdSrq Lib "P42W32.DLL" Alias "_DRV429_EncRdSrq@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_EncWrCtrl Lib "P42W32.DLL" Alias "_DRV429_EncWrCtrl@12" (ByVal value As Short, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_EncWrData Lib "P42W32.DLL" Alias "_DRV429_EncWrData@12" (ByVal value As Integer, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_EncWrGap Lib "P42W32.DLL" Alias "_DRV429_EncWrGap@12" (ByVal value As Short, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_EncWrReset Lib "P42W32.DLL" Alias "_DRV429_EncWrReset@12" (ByVal value As Short, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_EncWrSeq Lib "P42W32.DLL" Alias "_DRV429_EncWrSeq@12" (ByVal value As Integer, ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Function DRV429_Error Lib "P42W32.DLL" Alias "_DRV429_Error@8" (ByVal value As Short, ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_ExpandMant Lib "P42W32.DLL" Alias "_DRV429_ExpandMant@8" (ByRef mant As Integer, ByRef exp As Short)
    Public Declare Function DRV429_ExpCRC Lib "P42W32.DLL" Alias "_DRV429_ExpCRC@4" (ByVal version As Integer) As Integer
    Public Declare Function DRV429_Extern Lib "P42W32.DLL" Alias "_DRV429_Extern@8" (ByVal value As Short, ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_FileClose Lib "P42W32.DLL" Alias "_DRV429_FileClose@4" (ByVal handle As Integer)
    Public Declare Function DRV429_FileErr Lib "P42W32.DLL" Alias "_DRV429_FileErr@0" () As Integer
    Public Declare Sub DRV429_FileErrClr Lib "P42W32.DLL" Alias "_DRV429_FileErrClr@0" ()
    Public Declare Sub DRV429_FileErrSet Lib "P42W32.DLL" Alias "_DRV429_FileErrSet@0" ()
    Public Declare Function DRV429_FileOpenRead Lib "P42W32.DLL" Alias "_DRV429_FileOpenRead@4" (ByVal filename As String) As Integer
    Public Declare Function DRV429_FileOpenWrite Lib "P42W32.DLL" Alias "_DRV429_FileOpenWrite@4" (ByVal filename As String) As Integer
    Public Declare Function DRV429_FileRead Lib "P42W32.DLL" Alias "_DRV429_FileRead@12" (ByVal handle As Integer, ByRef buffer As Integer, ByVal count As Short) As Integer
    Public Declare Function DRV429_FileSeek Lib "P42W32.DLL" Alias "_DRV429_FileSeek@8" (ByVal handle As Integer, ByVal offset As Integer) As Integer
    Public Declare Function DRV429_FileTell Lib "P42W32.DLL" Alias "_DRV429_FileTell@4" (ByVal handle As Integer) As Integer
    Public Declare Function DRV429_FileWrite Lib "P42W32.DLL" Alias "_DRV429_FileWrite@12" (ByVal handle As Integer, ByRef buffer As Integer, ByVal count As Short) As Integer
    Public Declare Function DRV429_Free Lib "P42W32.DLL" Alias "_DRV429_Free@4" (ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_FreeDrv Lib "P42W32.DLL" Alias "_DRV429_FreeDrv@0" ()
    Public Declare Sub DRV429_FreeHeap Lib "P42W32.DLL" Alias "_DRV429_FreeHeap@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_Gate Lib "P42W32.DLL" Alias "_DRV429_Gate@8" (ByVal command As Short, ByVal handleval As Integer)
    Public Declare Function DRV429_GetBCDData Lib "P42W32.DLL" Alias "_DRV429_GetBCDData@12" (ByVal msg As Integer, ByVal msb As Short, ByVal lsb As Short) As Integer
    Public Declare Function DRV429_GetBCDMant Lib "P42W32.DLL" Alias "_DRV429_GetBCDMant@8" (ByVal msg As Integer, ByVal sigdig As Short) As Integer
    Public Declare Function DRV429_GetBCDSign Lib "P42W32.DLL" Alias "_DRV429_GetBCDSign@4" (ByVal msg As Integer) As Short
    Public Declare Function DRV429_GetBCDSSM Lib "P42W32.DLL" Alias "_DRV429_GetBCDSSM@4" (ByVal msg As Integer) As Short
    Public Declare Sub DRV429_GetBCDVal Lib "P42W32.DLL" Alias "_DRV429_GetBCDVal@16" (ByVal buf As String, ByVal msg As Integer, ByVal sigdig As Short, ByVal resolstr As String)
    Public Declare Function DRV429_GetBNRData Lib "P42W32.DLL" Alias "_DRV429_GetBNRData@16" (ByVal msg As Integer, ByVal msb As Short, ByVal lsb As Short, ByVal twos As Short) As Integer
    Public Declare Function DRV429_GetBNRMant Lib "P42W32.DLL" Alias "_DRV429_GetBNRMant@8" (ByVal msg As Integer, ByVal sigbit As Short) As Integer
    Public Declare Function DRV429_GetBNRSign Lib "P42W32.DLL" Alias "_DRV429_GetBNRSign@4" (ByVal msg As Integer) As Short
    Public Declare Function DRV429_GetBNRSSM Lib "P42W32.DLL" Alias "_DRV429_GetBNRSSM@4" (ByVal msg As Integer) As Short
    Public Declare Sub DRV429_GetBNRVal Lib "P42W32.DLL" Alias "_DRV429_GetBNRVal@16" (ByVal buf As String, ByVal msg As Integer, ByVal sigbit As Short, ByVal resolstr As String)
    Public Declare Function DRV429_GetFilt Lib "P42W32.DLL" Alias "_DRV429_GetFilt@16" (ByVal labelval As Short, ByVal sdival As Short, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_GetFldData Lib "P42W32.DLL" Alias "_DRV429_GetFldData@4" (ByVal msgval As Integer) As Integer
    Public Declare Function DRV429_GetFldLabel Lib "P42W32.DLL" Alias "_DRV429_GetFldLabel@4" (ByVal msgval As Integer) As Short
    Public Declare Function DRV429_GetFldParBit Lib "P42W32.DLL" Alias "_DRV429_GetFldParBit@4" (ByVal msgval As Integer) As Integer
    Public Declare Function DRV429_GetFldParity Lib "P42W32.DLL" Alias "_DRV429_GetFldParity@4" (ByVal msgval As Integer) As Integer
    Public Declare Function DRV429_GetFldSDI Lib "P42W32.DLL" Alias "_DRV429_GetFldSDI@4" (ByVal msgval As Integer) As Integer
    Public Declare Function DRV429_GetFldValue Lib "P42W32.DLL" Alias "_DRV429_GetFldValue@12" (ByVal msgval As Integer, ByVal startbit As Integer, ByVal endbit As Integer) As Integer
    Public Declare Function DRV429_GetGap Lib "P42W32.DLL" Alias "_DRV429_GetGap@12" (ByVal index As Short, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_GetMsg Lib "P42W32.DLL" Alias "_DRV429_GetMsg@12" (ByVal index As Short, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_GetMsgCnt Lib "P42W32.DLL" Alias "_DRV429_GetMsgCnt@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_GetVersion Lib "P42W32.DLL" Alias "_DRV429_GetVersion@4" (ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_Halt Lib "P42W32.DLL" Alias "_DRV429_Halt@4" (ByVal handleval As Integer)
    Public Declare Function DRV429_HandleInit Lib "P42W32.DLL" Alias "_DRV429_HandleInit@0" () As Integer
    Public Declare Function DRV429_HandleOkay Lib "P42W32.DLL" Alias "_DRV429_HandleOkay@4" (ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_HandleRegister Lib "P42W32.DLL" Alias "_DRV429_HandleRegister@28" (ByVal cardname As String, ByVal memval As Integer, ByVal ioval As Integer, ByVal irqval As Integer, ByVal drqval As Integer, ByRef hAppWnd As Integer, ByVal uiRemovalMsg As Short) As Integer
    Public Declare Function DRV429_HandleUnregister Lib "P42W32.DLL" Alias "_DRV429_HandleUnregister@4" (ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_HighSpeed Lib "P42W32.DLL" Alias "_DRV429_HighSpeed@8" (ByVal value As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_ImageCycle Lib "P42W32.DLL" Alias "_DRV429_ImageCycle@12" (ByVal channel As Short, ByVal handleval As Integer, ByVal addr As Short) As Short
    Public Declare Function DRV429_ImageFilt Lib "P42W32.DLL" Alias "_DRV429_ImageFilt@20" (ByVal labelval As Short, ByVal sdi As Short, ByVal channel As Short, ByVal handleval As Integer, ByVal addr As Short) As Short
    Public Declare Function DRV429_ImageFrame Lib "P42W32.DLL" Alias "_DRV429_ImageFrame@16" (ByVal framenum As Short, ByVal channel As Short, ByVal handleval As Integer, ByVal addr As Short) As Short
    Public Declare Function DRV429_ImageGap Lib "P42W32.DLL" Alias "_DRV429_ImageGap@20" (ByVal framenum As Short, ByVal msgnum As Short, ByVal channel As Short, ByVal handleval As Integer, ByVal addr As Short) As Short
    Public Declare Function DRV429_ImageHeader Lib "P42W32.DLL" Alias "_DRV429_ImageHeader@12" (ByVal channel As Short, ByVal handleval As Integer, ByVal addr As Short) As Short
    Public Declare Function DRV429_ImageLabelTable Lib "P42W32.DLL" Alias "_DRV429_ImageLabelTable@12" (ByVal channel As Short, ByVal handleval As Integer, ByVal addr As Short) As Short
    Public Declare Function DRV429_ImageMsg Lib "P42W32.DLL" Alias "_DRV429_ImageMsg@20" (ByVal framenum As Short, ByVal msgnum As Short, ByVal channel As Short, ByVal handleval As Integer, ByVal addr As Short) As Short
    Public Declare Function DRV429_ImageSDITable Lib "P42W32.DLL" Alias "_DRV429_ImageSDITable@16" (ByVal labelval As Short, ByVal channel As Short, ByVal handleval As Integer, ByVal addr As Short) As Short
    Public Declare Function DRV429_In Lib "P42W32.DLL" Alias "_DRV429_In@8" (ByVal handleval As Integer, ByVal addrval As Integer) As Integer
    Public Declare Function DRV429_InAccess Lib "P42W32.DLL" Alias "_DRV429_InAccess@8" (ByVal ctrval As Integer, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_InP Lib "P42W32.DLL" Alias "_DRV429_InP@8" (ByVal addr As Integer, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_InsFilt Lib "P42W32.DLL" Alias "_DRV429_InsFilt@16" (ByVal labelval As Short, ByVal sdival As Short, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_InsMsg Lib "P42W32.DLL" Alias "_DRV429_InsMsg@20" (ByVal index As Short, ByVal msgval As Integer, ByVal gapval As Integer, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_IsOldBrd Lib "P42W32.DLL" Alias "_DRV429_IsOldBrd@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_IsRcv Lib "P42W32.DLL" Alias "_DRV429_IsRcv@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_IsXmit Lib "P42W32.DLL" Alias "_DRV429_IsXmit@8" (ByVal channel As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_KernBegin Lib "P42W32.DLL" Alias "_DRV429_KernBegin@24" (ByVal vxdptr As Integer, ByVal cardname As String, ByVal memval As Integer, ByVal ioval As Integer, ByVal irqval As Integer, ByVal drqval As Integer) As Integer
    Public Declare Function DRV429_KernEnd Lib "P42W32.DLL" Alias "_DRV429_KernEnd@4" (ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_KernGet Lib "P42W32.DLL" Alias "_DRV429_KernGet@12" (ByRef memptr As Integer, ByRef ioptr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_KernQuick Lib "P42W32.DLL" Alias "_DRV429_KernQuick@8" (ByVal flag As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_KernStatusEx Lib "P42W32.DLL" Alias "_DRV429_KernStatusEx@16" (ByRef valueptr As Integer, ByVal typeval As Integer, ByVal index As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub DRV429_KillSeq Lib "P42W32.DLL" Alias "_DRV429_KillSeq@4" (ByVal handleval As Integer)
    Public Declare Function DRV429_Load Lib "P42W32.DLL" Alias "_DRV429_Load@8" (ByVal filename As String, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_MakePtr Lib "P42W32.DLL" Alias "_DRV429_MakePtr@8" (ByVal handleval As Integer, ByVal offval As Integer) As Integer
    Public Declare Function DRV429_MantToAscii Lib "P42W32.DLL" Alias "_DRV429_MantToAscii@12" (ByVal buf As String, ByVal mant As Integer, ByVal exp As Integer) As String
    Public Declare Sub DRV429_MarkMem Lib "P42W32.DLL" Alias "_DRV429_MarkMem@4" (ByVal handleval As Integer)
    Public Declare Function DRV429_Mask Lib "P42W32.DLL" Alias "_DRV429_Mask@8" (ByVal dataval As Integer, ByVal cntval As Integer) As Integer
    Public Declare Sub DRV429_MaxMant Lib "P42W32.DLL" Alias "_DRV429_MaxMant@8" (ByRef mant As Integer, ByRef exp As Short)
    Public Declare Function DRV429_Mod Lib "P42W32.DLL" Alias "_DRV429_Mod@8" (ByVal moda As Integer, ByVal modb As Integer) As Integer
    Public Declare Function DRV429_Mul Lib "P42W32.DLL" Alias "_DRV429_Mul@8" (ByVal mula As Integer, ByVal mulb As Integer) As Integer
    Public Declare Function DRV429_NameCmp Lib "P42W32.DLL" Alias "_DRV429_NameCmp@8" (ByVal str1 As String, ByVal str2 As String) As Short
    Public Declare Function DRV429_NameToAddr Lib "P42W32.DLL" Alias "_DRV429_NameToAddr@12" (ByVal name As String, ByVal handleval As Integer, ByVal filename As String) As Integer
    Public Declare Sub DRV429_NormalMant Lib "P42W32.DLL" Alias "_DRV429_NormalMant@8" (ByRef mant As Integer, ByRef exp As Short)
    Public Declare Function DRV429_Open Lib "P42W32.DLL" Alias "_DRV429_Open@4" (ByVal cardnum As Integer) As Integer
    Public Declare Function DRV429_OscClk Lib "P42W32.DLL" Alias "_DRV429_OscClk@8" (ByVal oscval As Short, ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_Out Lib "P42W32.DLL" Alias "_DRV429_Out@12" (ByVal handleval As Integer, ByVal addrval As Integer, ByVal value As Integer)
    Public Declare Sub DRV429_OutAccess Lib "P42W32.DLL" Alias "_DRV429_OutAccess@12" (ByVal ctrval As Integer, ByVal regval As Integer, ByVal handleval As Integer)
    Public Declare Sub DRV429_OutP Lib "P42W32.DLL" Alias "_DRV429_OutP@12" (ByVal addr As Integer, ByVal value As Integer, ByVal handleval As Integer)
    Public Declare Function DRV429_Parity Lib "P42W32.DLL" Alias "_DRV429_Parity@8" (ByVal value As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_PeekB Lib "P42W32.DLL" Alias "_DRV429_PeekB@8" (ByVal addr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_PeekL Lib "P42W32.DLL" Alias "_DRV429_PeekL@8" (ByVal addr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_PeekW Lib "P42W32.DLL" Alias "_DRV429_PeekW@8" (ByVal addr As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub DRV429_PokeB Lib "P42W32.DLL" Alias "_DRV429_PokeB@12" (ByVal addr As Integer, ByVal handleval As Integer, ByVal value As Integer)
    Public Declare Sub DRV429_PokeeB Lib "P42W32.DLL" Alias "_DRV429_PokeeB@12" (ByVal addr As Integer, ByVal handleval As Integer, ByVal value As Integer)
    Public Declare Sub DRV429_PokeeL Lib "P42W32.DLL" Alias "_DRV429_PokeeL@12" (ByVal addr As Integer, ByVal handleval As Integer, ByVal value As Integer)
    Public Declare Sub DRV429_PokeeW Lib "P42W32.DLL" Alias "_DRV429_PokeeW@12" (ByVal addr As Integer, ByVal handleval As Integer, ByVal value As Integer)
    Public Declare Sub DRV429_PokeL Lib "P42W32.DLL" Alias "_DRV429_PokeL@12" (ByVal addr As Integer, ByVal handleval As Integer, ByVal value As Integer)
    Public Declare Sub DRV429_PokeW Lib "P42W32.DLL" Alias "_DRV429_PokeW@12" (ByVal addr As Integer, ByVal handleval As Integer, ByVal value As Integer)
    Public Declare Sub DRV429_Pulse Lib "P42W32.DLL" Alias "_DRV429_Pulse@4" (ByVal handleval As Integer)
    Public Declare Function DRV429_PutBCDData Lib "P42W32.DLL" Alias "_DRV429_PutBCDData@16" (ByVal msg As Integer, ByVal value As Integer, ByVal msb As Short, ByVal lsb As Short) As Integer
    Public Declare Function DRV429_PutBCDMant Lib "P42W32.DLL" Alias "_DRV429_PutBCDMant@16" (ByVal msg As Integer, ByVal value As Integer, ByVal sigdig As Short, ByVal sign As Short) As Integer
    Public Declare Function DRV429_PutBCDSign Lib "P42W32.DLL" Alias "_DRV429_PutBCDSign@8" (ByVal msg As Integer, ByVal sign As Short) As Integer
    Public Declare Function DRV429_PutBCDSSM Lib "P42W32.DLL" Alias "_DRV429_PutBCDSSM@8" (ByVal msg As Integer, ByVal value As Short) As Integer
    Public Declare Function DRV429_PutBCDVal Lib "P42W32.DLL" Alias "_DRV429_PutBCDVal@16" (ByVal buf As String, ByVal msg As Integer, ByVal sigdig As Short, ByVal resolstr As String) As Integer
    Public Declare Function DRV429_PutBNRData Lib "P42W32.DLL" Alias "_DRV429_PutBNRData@20" (ByVal msg As Integer, ByVal value As Integer, ByVal msb As Short, ByVal lsb As Short, ByVal twos As Short) As Integer
    Public Declare Function DRV429_PutBNRMant Lib "P42W32.DLL" Alias "_DRV429_PutBNRMant@16" (ByVal msg As Integer, ByVal value As Integer, ByVal sigbit As Short, ByVal twos As Short) As Integer
    Public Declare Function DRV429_PutBNRSign Lib "P42W32.DLL" Alias "_DRV429_PutBNRSign@8" (ByVal msg As Integer, ByVal sign As Short) As Integer
    Public Declare Function DRV429_PutBNRSSM Lib "P42W32.DLL" Alias "_DRV429_PutBNRSSM@8" (ByVal msg As Integer, ByVal value As Short) As Integer
    Public Declare Function DRV429_PutBNRVal Lib "P42W32.DLL" Alias "_DRV429_PutBNRVal@16" (ByVal buf As String, ByVal msg As Integer, ByVal sigbit As Short, ByVal resolstr As String) As Integer
    Public Declare Function DRV429_PutFldData Lib "P42W32.DLL" Alias "_DRV429_PutFldData@8" (ByVal msgval As Integer, ByVal dataval As Integer) As Integer
    Public Declare Function DRV429_PutFldLabel Lib "P42W32.DLL" Alias "_DRV429_PutFldLabel@8" (ByVal msgval As Integer, ByVal labelval As Integer) As Integer
    Public Declare Function DRV429_PutFldSDI Lib "P42W32.DLL" Alias "_DRV429_PutFldSDI@8" (ByVal msgval As Integer, ByVal sdival As Integer) As Integer
    Public Declare Function DRV429_PutFldValue Lib "P42W32.DLL" Alias "_DRV429_PutFldValue@16" (ByVal msgval As Integer, ByVal newval As Integer, ByVal startbit As Integer, ByVal endbit As Integer) As Integer
    Public Declare Function DRV429_RandL Lib "P42W32.DLL" Alias "_DRV429_RandL@0" () As Integer
    Public Declare Function DRV429_RdClk Lib "P42W32.DLL" Alias "_DRV429_RdClk@4" (ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_RdFreePtr Lib "P42W32.DLL" Alias "_DRV429_RdFreePtr@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_RdHeapEnd Lib "P42W32.DLL" Alias "_DRV429_RdHeapEnd@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_RdHeapStart Lib "P42W32.DLL" Alias "_DRV429_RdHeapStart@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_RdOpt Lib "P42W32.DLL" Alias "_DRV429_RdOpt@4" (ByVal handleval As Integer) As Integer
    Public Declare Sub DRV429_RdSeq Lib "P42W32.DLL" Alias "_DRV429_RdSeq@20" (ByVal handleval As Integer, ByRef bottom As Short, ByRef top As Short, ByRef tail As Short, ByRef head As Short)
    Public Declare Function DRV429_ReadB Lib "P42W32.DLL" Alias "_DRV429_ReadB@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub DRV429_ReadBStr Lib "P42W32.DLL" Alias "_DRV429_ReadBStr@16" (ByRef valueptr As Integer, ByVal countval As Integer, ByVal addrval As Integer, ByVal handleval As Integer)
    Public Declare Function DRV429_ReadCtrlReg Lib "P42W32.DLL" Alias "_DRV429_ReadCtrlReg@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_ReadL Lib "P42W32.DLL" Alias "_DRV429_ReadL@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_ReadLbl Lib "P42W32.DLL" Alias "_DRV429_ReadLbl@8" (ByVal label As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_ReadRegA Lib "P42W32.DLL" Alias "_DRV429_ReadRegA@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_ReadRegB Lib "P42W32.DLL" Alias "_DRV429_ReadRegB@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_ReadROMB Lib "P42W32.DLL" Alias "_DRV429_ReadROMB@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_ReadStatusReg Lib "P42W32.DLL" Alias "_DRV429_ReadStatusReg@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_ReadSym Lib "P42W32.DLL" Alias "_DRV429_ReadSym@8" (ByVal symbol As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_ReadW Lib "P42W32.DLL" Alias "_DRV429_ReadW@8" (ByVal addrval As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_Ready Lib "P42W32.DLL" Alias "_DRV429_Ready@4" (ByVal handleval As Integer) As Short
    Public Declare Function DRV429_RealChan Lib "P42W32.DLL" Alias "_DRV429_RealChan@4" (ByVal channel As Short) As Short
    Public Declare Sub DRV429_Rearm Lib "P42W32.DLL" Alias "_DRV429_Rearm@8" (ByVal channel As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_Reset Lib "P42W32.DLL" Alias "_DRV429_Reset@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_Restart Lib "P42W32.DLL" Alias "_DRV429_Restart@4" (ByVal handleval As Integer)
    Public Declare Function DRV429_SchedAdvance Lib "P42W32.DLL" Alias "_DRV429_SchedAdvance@0" () As Integer
    Public Declare Function DRV429_SchedCalc Lib "P42W32.DLL" Alias "_DRV429_SchedCalc@0" () As Integer
    Public Declare Function DRV429_SchedCheck Lib "P42W32.DLL" Alias "_DRV429_SchedCheck@8" (ByRef minperiod As Integer, ByRef maxperiod As Integer) As Integer
    Public Declare Sub DRV429_SchedCheckEnd Lib "P42W32.DLL" Alias "_DRV429_SchedCheckEnd@0" ()
    Public Declare Sub DRV429_SchedCheckMiddle Lib "P42W32.DLL" Alias "_DRV429_SchedCheckMiddle@16" (ByVal msgnum As Integer, ByVal minlen As Integer, ByVal midlen As Integer, ByVal maxlen As Integer)
    Public Declare Sub DRV429_SchedCheckReal Lib "P42W32.DLL" Alias "_DRV429_SchedCheckReal@16" (ByVal msgnum As Integer, ByVal minlen As Integer, ByVal midlen As Integer, ByVal maxlen As Integer)
    Public Declare Sub DRV429_SchedCheckStart Lib "P42W32.DLL" Alias "_DRV429_SchedCheckStart@0" ()
    Public Declare Function DRV429_SchedConflicts Lib "P42W32.DLL" Alias "_DRV429_SchedConflicts@0" () As Integer
    Public Declare Sub DRV429_SchedDisplay Lib "P42W32.DLL" Alias "_DRV429_SchedDisplay@12" (ByVal nummsgs As Integer, ByRef count As Integer, ByRef dataval As Integer)
    Public Declare Function DRV429_SchedDivide Lib "P42W32.DLL" Alias "_DRV429_SchedDivide@0" () As Integer
    Public Declare Function DRV429_SchedFix Lib "P42W32.DLL" Alias "_DRV429_SchedFix@0" () As Integer
    Public Declare Sub DRV429_SchedFixEnd Lib "P42W32.DLL" Alias "_DRV429_SchedFixEnd@0" ()
    Public Declare Sub DRV429_SchedFixMiddle Lib "P42W32.DLL" Alias "_DRV429_SchedFixMiddle@4" (ByVal conflicts As Integer)
    Public Declare Sub DRV429_SchedFixStart Lib "P42W32.DLL" Alias "_DRV429_SchedFixStart@0" ()
    Public Declare Sub DRV429_SchedHook Lib "P42W32.DLL" Alias "_DRV429_SchedHook@8" (ByVal index As Integer, ByRef ptr As Integer)
    Public Declare Function DRV429_SchedInsert Lib "P42W32.DLL" Alias "_DRV429_SchedInsert@24" (ByVal events As Integer, ByVal index As Integer, ByVal msgnum As Integer, ByVal gapval As Integer, ByVal channel As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_SchedInsertEnd Lib "P42W32.DLL" Alias "_DRV429_SchedInsertEnd@12" (ByVal events As Integer, ByVal channel As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_SchedInsertStart Lib "P42W32.DLL" Alias "_DRV429_SchedInsertStart@12" (ByVal events As Integer, ByVal channel As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub DRV429_SchedLayout Lib "P42W32.DLL" Alias "_DRV429_SchedLayout@0" ()
    Public Declare Function DRV429_SchedMaxval Lib "P42W32.DLL" Alias "_DRV429_SchedMaxval@8" (ByRef arrayval As Integer, ByVal arraycount As Integer) As Integer
    Public Declare Function DRV429_SchedMinval Lib "P42W32.DLL" Alias "_DRV429_SchedMinval@8" (ByRef arrayval As Integer, ByVal arraycount As Integer) As Integer
    Public Declare Function DRV429_SchedMsg Lib "P42W32.DLL" Alias "_DRV429_SchedMsg@20" (ByVal index As Short, ByVal msgaddr As Integer, ByVal gapval As Integer, ByVal channel As Short, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_SchedParse Lib "P42W32.DLL" Alias "_DRV429_SchedParse@12" (ByVal basemsgnum As Integer, ByVal channel As Integer, ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_SchedReset Lib "P42W32.DLL" Alias "_DRV429_SchedReset@0" () As Integer
    Public Declare Function DRV429_SchedRotate Lib "P42W32.DLL" Alias "_DRV429_SchedRotate@0" () As Integer
    Public Declare Function DRV429_SchedShift Lib "P42W32.DLL" Alias "_DRV429_SchedShift@8" (ByVal msgnum As Integer, ByVal value As Integer) As Integer
    Public Declare Function DRV429_SchedSlide Lib "P42W32.DLL" Alias "_DRV429_SchedSlide@0" () As Integer
    Public Declare Sub DRV429_SchedSlideEnd Lib "P42W32.DLL" Alias "_DRV429_SchedSlideEnd@0" ()
    Public Declare Sub DRV429_SchedSlideMiddle Lib "P42W32.DLL" Alias "_DRV429_SchedSlideMiddle@12" (ByVal index As Integer, ByVal count As Integer, ByVal conflicts As Integer)
    Public Declare Sub DRV429_SchedSlideStart Lib "P42W32.DLL" Alias "_DRV429_SchedSlideStart@4" (ByVal factor As Integer)
    Public Declare Sub DRV429_SchedSort Lib "P42W32.DLL" Alias "_DRV429_SchedSort@0" ()
    Public Declare Function DRV429_SchedToBit Lib "P42W32.DLL" Alias "_DRV429_SchedToBit@4" (ByVal value As Integer) As Integer
    Public Declare Function DRV429_SchedToMsec Lib "P42W32.DLL" Alias "_DRV429_SchedToMsec@4" (ByVal value As Integer) As Integer
    Public Declare Sub DRV429_SchedUnsort Lib "P42W32.DLL" Alias "_DRV429_SchedUnsort@0" ()
    Public Declare Function DRV429_SchedWalk Lib "P42W32.DLL" Alias "_DRV429_SchedWalk@0" () As Integer
    Public Declare Function DRV429_SelfTest Lib "P42W32.DLL" Alias "_DRV429_SelfTest@8" (ByVal value As Short, ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_SeqDMAStat Lib "P42W32.DLL" Alias "_DRV429_SeqDMAStat@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_SeqRecParam Lib "P42W32.DLL" Alias "_DRV429_SeqRecParam@16" (ByVal channels As Integer, ByVal mode As Integer, ByVal interval As Integer, ByVal handleval As Integer)
    Public Declare Function DRV429_SeqRecRd Lib "P42W32.DLL" Alias "_DRV429_SeqRecRd@12" (ByRef buf As Integer, ByVal bufsize As Integer, ByVal handleval As Integer) As Integer
    Public Declare Sub DRV429_SeqRecStart Lib "P42W32.DLL" Alias "_DRV429_SeqRecStart@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_SeqRecStop Lib "P42W32.DLL" Alias "_DRV429_SeqRecStop@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_SeqStat Lib "P42W32.DLL" Alias "_DRV429_SeqStat@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_SetCtrInt Lib "P42W32.DLL" Alias "_DRV429_SetCtrInt@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_SetHostInt Lib "P42W32.DLL" Alias "_DRV429_SetHostInt@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_SetWindow Lib "P42W32.DLL" Alias "_DRV429_SetWindow@12" (ByVal addrval As Integer, ByVal ramrom As Integer, ByVal handleval As Integer)
    Public Declare Function DRV429_Shl Lib "P42W32.DLL" Alias "_DRV429_Shl@8" (ByVal dataval As Integer, ByVal cntval As Integer) As Integer
    Public Declare Function DRV429_Shr Lib "P42W32.DLL" Alias "_DRV429_Shr@8" (ByVal dataval As Integer, ByVal cntval As Integer) As Integer
    Public Declare Function DRV429_SignMant Lib "P42W32.DLL" Alias "_DRV429_SignMant@4" (ByVal str As String) As Short
    Public Declare Function DRV429_Single Lib "P42W32.DLL" Alias "_DRV429_Single@8" (ByVal value As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_SpeedClk Lib "P42W32.DLL" Alias "_DRV429_SpeedClk@8" (ByVal speed As Short, ByVal handleval As Integer) As Short
    Public Declare Sub DRV429_Start Lib "P42W32.DLL" Alias "_DRV429_Start@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_STI Lib "P42W32.DLL" Alias "_DRV429_STI@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_Stop Lib "P42W32.DLL" Alias "_DRV429_Stop@4" (ByVal handleval As Integer)
    Public Declare Function DRV429_Test Lib "P42W32.DLL" Alias "_DRV429_Test@4" (ByVal handleval As Integer) As Integer
    Public Declare Function DRV429_UserCode Lib "P42W32.DLL" Alias "_DRV429_UserCode@12" (ByRef ptr As Integer, ByVal count As Short, ByVal handleval As Integer) As Short
    Public Declare Function DRV429_ValAsciiCmpi Lib "P42W32.DLL" Alias "_DRV429_ValAsciiCmpi@8" (ByVal str1 As String, ByVal str2 As String) As Integer
    Public Declare Function DRV429_ValAsciiCpy Lib "P42W32.DLL" Alias "_DRV429_ValAsciiCpy@12" (ByVal strdest As String, ByVal strsrc As String, ByVal count As Integer) As String
    Public Declare Sub DRV429_ValAsciiTrimLead Lib "P42W32.DLL" Alias "_DRV429_ValAsciiTrimLead@4" (ByVal buf As String)
    Public Declare Sub DRV429_ValAsciiTrimTrail Lib "P42W32.DLL" Alias "_DRV429_ValAsciiTrimTrail@4" (ByVal buf As String)
    Public Declare Function DRV429_ValFromAscii Lib "P42W32.DLL" Alias "_DRV429_ValFromAscii@8" (ByVal asciistr As String, ByVal radixval As Integer) As Integer
    Public Declare Function DRV429_ValIncAscii Lib "P42W32.DLL" Alias "_DRV429_ValIncAscii@4" (ByVal asciistr As String) As String
    Public Declare Function DRV429_ValInccAscii Lib "P42W32.DLL" Alias "_DRV429_ValInccAscii@4" (ByVal asciistr As String) As String
    Public Declare Function DRV429_ValIsLower Lib "P42W32.DLL" Alias "_DRV429_ValIsLower@4" (ByVal value As Integer) As Integer
    Public Declare Function DRV429_ValLenAscii Lib "P42W32.DLL" Alias "_DRV429_ValLenAscii@8" (ByVal numbits As Integer, ByVal radixval As Integer) As Integer
    Public Declare Function DRV429_ValToAscii Lib "P42W32.DLL" Alias "_DRV429_ValToAscii@16" (ByVal value As Integer, ByVal asciistr As String, ByVal numbits As Integer, ByVal radixval As Integer) As String
    Public Declare Function DRV429_ValToUpper Lib "P42W32.DLL" Alias "_DRV429_ValToUpper@4" (ByVal value As Integer) As Integer
    Public Declare Function DRV429_Version Lib "P42W32.DLL" Alias "_DRV429_Version@0" () As String
    Public Declare Sub DRV429_VerStr Lib "P42W32.DLL" Alias "_DRV429_VerStr@8" (ByVal strptr As String, ByVal count As Short)
    Public Declare Sub DRV429_WipeMem Lib "P42W32.DLL" Alias "_DRV429_WipeMem@4" (ByVal handleval As Integer)
    Public Declare Sub DRV429_WrClk Lib "P42W32.DLL" Alias "_DRV429_WrClk@8" (ByVal clock As Integer, ByVal handleval As Integer)
    Public Declare Sub DRV429_WrFreePtr Lib "P42W32.DLL" Alias "_DRV429_WrFreePtr@8" (ByVal freeptr As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_WriteB Lib "P42W32.DLL" Alias "_DRV429_WriteB@12" (ByVal addrval As Integer, ByVal handleval As Integer, ByVal value As Integer)
    Public Declare Sub DRV429_WriteCtrlReg Lib "P42W32.DLL" Alias "_DRV429_WriteCtrlReg@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_WriteL Lib "P42W32.DLL" Alias "_DRV429_WriteL@12" (ByVal addrval As Integer, ByVal handleval As Integer, ByVal value As Integer)
    Public Declare Sub DRV429_WritePulseReg Lib "P42W32.DLL" Alias "_DRV429_WritePulseReg@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_WriteRegA Lib "P42W32.DLL" Alias "_DRV429_WriteRegA@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_WriteRegB Lib "P42W32.DLL" Alias "_DRV429_WriteRegB@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_WriteStatusReg Lib "P42W32.DLL" Alias "_DRV429_WriteStatusReg@8" (ByVal value As Short, ByVal handleval As Integer)
    Public Declare Sub DRV429_WriteW Lib "P42W32.DLL" Alias "_DRV429_WriteW@12" (ByVal addrval As Integer, ByVal handleval As Integer, ByVal value As Short)
    Public Declare Sub DRV429_WrOpt Lib "P42W32.DLL" Alias "_DRV429_WrOpt@8" (ByVal optionval As Integer, ByVal handleval As Integer)
    Public Declare Sub DRV429_WrSeq Lib "P42W32.DLL" Alias "_DRV429_WrSeq@20" (ByVal handleval As Integer, ByVal bottom As Short, ByVal top As Short, ByVal tail As Short, ByVal head As Short)

    '**
    '*
    '*  Constants
    '*
    '**

    Public Const CH0 As Integer = &H1                    'Channel 0
    Public Const CH1 As Integer = &H2                    'Channel 1
    Public Const CH2 As Integer = &H4                    'Channel 2
    Public Const CH3 As Integer = &H8                    'Channel 3
    Public Const CH4 As Integer = &H10                   'Channel 4
    Public Const CH5 As Integer = &H20                   'Channel 5
    Public Const CH6 As Integer = &H40                   'Channel 6
    Public Const CH7 As Integer = &H80                   'Channel 7
    Public Const CHNONE As Integer = &H0                 'Channel none

    Public Const GAPNOWRD As Integer = &H8000           'Gap NOWRD bit
    Public Const GAPSYNC As Integer = &H4000            'Gap SYNC  bit
    Public Const GAPLOG As Integer = &H2000             'Gap LOG   bit
    Public Const GAPERWRD As Integer = &H1000           'Gap ERWRD bit

    '**
    '*
    '*  The following three constants are for compatibility with earlier
    '*  versions of the Driver.  They can only be used with software
    '*  operating the PC429-1.
    '*
    '**

    Public Const SEQRECCHXMIT As Integer = &H2           'Selects transmit channel
    Public Const SEQRECCHRCV As Integer = &H1            'Selects receive channel
    Public Const SEQRECCHXMITRCV As Integer = &H3        'Selects transmit and receive channel

    Public Const SEQRECMODENORMAL As Integer = &H0       'Enables interval mode
    Public Const SEQRECMODEDELTA As Integer = &H1        'Enables delta mode
    Public Const SEQRECMODEINTRVL As Integer = &H2       'Enables interval mode
    Public Const SEQRECMODEDELTINT As Integer = &H3      'Enables delta and interval mode
    Public Const SEQRECMODEMON As Integer = &H4          'Enables monitor mode

    Public Const SPEEDCLKHIGH As Integer = &H0           'Clock resolution .1 msec
    Public Const SPEEDCLKMED As Integer = &H1            'Clock resolution  1 msec
    Public Const SPEEDCLKLOW As Integer = &H2            'Clock resolution 10 msec

    Public Const SDI00 As Integer = &H1                  'SDI filter 00
    Public Const SDI01 As Integer = &H2                  'SDI filter 01
    Public Const SDI10 As Integer = &H4                  'SDI filter 10
    Public Const SDI11 As Integer = &H8                  'SDI filter 11

End Module
