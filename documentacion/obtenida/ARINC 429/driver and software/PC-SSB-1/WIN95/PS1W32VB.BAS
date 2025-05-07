'**
'*
'*  PS-SSB-1 WIN32 DRIVER  Version 1.0  (12/31/1999)
'*  Copyright (c) 1999
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   PS1W32VB.BAS -- Visual Basic
'*                          PS-SSB-1 Driver Header File.
'*
'**

'**
'*
'*  This file defines the functions and subroutines provided
'*  by the 32-bit Driver Library for the PS-SSB-1.  Visual Basic
'*  applications using the PC-SSB-1 Driver Library must
'*  incorporate this text file into the Visual Basic project.
'*
'**

'**
'*
'*  PC-SSB-1 Driver functions.
'*
'**

Public Declare Function SSBT_CardClose Lib "PS1W32.DLL" Alias "_SSBT_CardClose@4" (ByVal handleval As Long) As Long
Public Declare Function SSBT_CardOpen Lib "PS1W32.DLL" Alias "_SSBT_CardOpen@12" (ByVal memval As Long, ByVal ioval As Long, ByVal irqval As Long) As Long
Public Declare Function SSBT_AsciiCat Lib "PS1W32.DLL" Alias "_SSBT_AsciiCat@8" (ByVal strdest As String, ByVal strsrc As String) As String
Public Declare Function SSBT_AsciiCmpi Lib "PS1W32.DLL" Alias "_SSBT_AsciiCmpi@8" (ByVal str1 As String, ByVal str2 As String) As Long
Public Declare Function SSBT_AsciiCpy Lib "PS1W32.DLL" Alias "_SSBT_AsciiCpy@8" (ByVal strdest As String, ByVal strsrc As String) As String
Public Declare Function SSBT_AsciiFromNibble Lib "PS1W32.DLL" Alias "_SSBT_AsciiFromNibble@4" (ByVal ch As Byte) As Long
Public Declare Function SSBT_AsciiFromVal Lib "PS1W32.DLL" Alias "_SSBT_AsciiFromVal@16" (ByVal value As Long, ByVal asciistr As String, ByVal numbits As Long, ByVal radixval As Long) As String
Public Declare Function SSBT_AsciiInc Lib "PS1W32.DLL" Alias "_SSBT_AsciiInc@4" (ByVal asciistr As String) As String
Public Declare Function SSBT_AsciiIncc Lib "PS1W32.DLL" Alias "_SSBT_AsciiIncc@4" (ByVal asciistr As String) As String
Public Declare Function SSBT_AsciiIsLower Lib "PS1W32.DLL" Alias "_SSBT_AsciiIsLower@4" (ByVal value As Long) As Long
Public Declare Function SSBT_AsciiIsRadix Lib "PS1W32.DLL" Alias "_SSBT_AsciiIsRadix@8" (ByVal asciistr As String, ByVal radixval As Long) As Long
Public Declare Function SSBT_AsciiLenVal Lib "PS1W32.DLL" Alias "_SSBT_AsciiLenVal@8" (ByVal numbits As Long, ByVal radixval As Long) As Long
Public Declare Function SSBT_AsciiToUpper Lib "PS1W32.DLL" Alias "_SSBT_AsciiToUpper@4" (ByVal value As Long) As Long
Public Declare Function SSBT_AsciiToVal Lib "PS1W32.DLL" Alias "_SSBT_AsciiToVal@8" (ByVal asciistr As String, ByVal radixval As Long) As Long
Public Declare Sub SSBT_AsciiTrimLead Lib "PS1W32.DLL" Alias "_SSBT_AsciiTrimLead@4" (ByVal buf As String)
Public Declare Sub SSBT_AsciiTrimTrail Lib "PS1W32.DLL" Alias "_SSBT_AsciiTrimTrail@4" (ByVal buf As String)
Public Declare Sub SSBT_AsciiTrimZero Lib "PS1W32.DLL" Alias "_SSBT_AsciiTrimZero@4" (ByVal buf As String)
Public Declare Function SSBT_CardCloseAll Lib "PS1W32.DLL" Alias "_SSBT_CardCloseAll@0" () As Long
Public Declare Function SSBT_CardGetParam Lib "PS1W32.DLL" Alias "_SSBT_CardGetParam@20" (ByVal cardstr As String, ByRef memval As Integer, ByRef ioval As Integer, ByRef irqval As Integer, ByVal handleval As Long) As Long
Public Declare Sub SSBT_CardInit Lib "PS1W32.DLL" Alias "_SSBT_CardInit@0" ()
Public Declare Function SSBT_CardOpenEx Lib "PS1W32.DLL" Alias "_SSBT_CardOpenEx@16" (ByVal cardname As String, ByVal memval As Long, ByVal ioval As Long, ByVal irqval As Long) As Long
Public Declare Function SSBT_CardOpenExx Lib "PS1W32.DLL" Alias "_SSBT_CardOpenExx@24" (ByVal cardname As String, ByVal memval As Long, ByVal ioval As Long, ByVal irqval As Long, ByRef hAppWnd As Long, ByVal uiRemovalMsg As Integer) As Long
Public Declare Function SSBT_Check Lib "PS1W32.DLL" Alias "_SSBT_Check@4" (ByVal handleval As Long) As Long
Public Declare Sub SSBT_ClrInt Lib "PS1W32.DLL" Alias "_SSBT_ClrInt@4" (ByVal handleval As Long)
Public Declare Function SSBT_Config Lib "PS1W32.DLL" Alias "_SSBT_Config@8" (ByVal regval As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_ConfigInt Lib "PS1W32.DLL" Alias "_SSBT_ConfigInt@12" (ByVal regval As Long, ByRef newhandler As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_Div Lib "PS1W32.DLL" Alias "_SSBT_Div@8" (ByVal diva As Long, ByVal divb As Long) As Long
Public Declare Function SSBT_ErrDesc Lib "PS1W32.DLL" Alias "_SSBT_ErrDesc@4" (ByVal errval As Long) As String
Public Declare Function SSBT_ErrDescStr Lib "PS1W32.DLL" Alias "_SSBT_ErrDescStr@4" (ByVal errval As Long) As String
Public Declare Function SSBT_ErrName Lib "PS1W32.DLL" Alias "_SSBT_ErrName@4" (ByVal errval As Long) As String
Public Declare Function SSBT_GetHigh Lib "PS1W32.DLL" Alias "_SSBT_GetHigh@4" (ByVal val As Long) As Integer
Public Declare Function SSBT_GetLow Lib "PS1W32.DLL" Alias "_SSBT_GetLow@4" (ByVal val As Long) As Integer
Public Declare Function SSBT_GetOff Lib "PS1W32.DLL" Alias "_SSBT_GetOff@4" (ByRef valptr As Long) As Integer
Public Declare Function SSBT_GetSeg Lib "PS1W32.DLL" Alias "_SSBT_GetSeg@4" (ByRef valptr As Long) As Integer
Public Declare Function SSBT_HandleClose Lib "PS1W32.DLL" Alias "_SSBT_HandleClose@4" (ByVal handleval As Long) As Long
Public Declare Function SSBT_HandleDel Lib "PS1W32.DLL" Alias "_SSBT_HandleDel@4" (ByVal handleval As Long) As Long
Public Declare Function SSBT_HandleIns Lib "PS1W32.DLL" Alias "_SSBT_HandleIns@24" (ByVal cardname As String, ByVal memval As Long, ByVal ioval As Long, ByVal irqval As Long, ByRef hAppWnd As Long, ByVal uiRemovalMsg As Integer) As Long
Public Declare Function SSBT_HandleOkay Lib "PS1W32.DLL" Alias "_SSBT_HandleOkay@4" (ByVal handleval As Long) As Long
Public Declare Function SSBT_HandleOpen Lib "PS1W32.DLL" Alias "_SSBT_HandleOpen@20" (ByVal cardname As String, ByVal memval As Long, ByVal ioval As Long, ByVal irqval As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_HandleVer Lib "PS1W32.DLL" Alias "_SSBT_HandleVer@4" (ByVal handleval As Long) As Long
Public Declare Function SSBT_IntInstall Lib "PS1W32.DLL" Alias "_SSBT_IntInstall@8" (ByRef hEvent As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_IntUninstall Lib "PS1W32.DLL" Alias "_SSBT_IntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function SSBT_KernBegin Lib "PS1W32.DLL" Alias "_SSBT_KernBegin@24" (ByVal vxdptr As Long, ByVal cardstr As String, ByVal memval As Long, ByVal ioval As Long, ByVal irqval As Long, ByVal cardname As String) As Long
Public Declare Function SSBT_KernEnd Lib "PS1W32.DLL" Alias "_SSBT_KernEnd@4" (ByRef vxdptr As Long) As Long
Public Declare Function SSBT_KernIntClear Lib "PS1W32.DLL" Alias "_SSBT_KernIntClear@4" (ByVal handleval As Long) As Long
Public Declare Function SSBT_KernIntInstall Lib "PS1W32.DLL" Alias "_SSBT_KernIntInstall@8" (ByRef hEvent As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernIntParam Lib "PS1W32.DLL" Alias "_SSBT_KernIntParam@32" (ByVal clraddr As Long, ByVal clrwidth As Long, ByVal clrvalue As Long, ByVal stataddr As Long, ByVal statwidth As Long, ByVal statvalue As Long, ByVal statmask As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernIntStatus Lib "PS1W32.DLL" Alias "_SSBT_KernIntStatus@8" (ByRef valueptr As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernIntUninstall Lib "PS1W32.DLL" Alias "_SSBT_KernIntUninstall@4" (ByVal handleval As Long) As Long
Public Declare Function SSBT_KernIORdB Lib "PS1W32.DLL" Alias "_SSBT_KernIORdB@12" (ByRef valueptr As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernIOWrB Lib "PS1W32.DLL" Alias "_SSBT_KernIOWrB@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMCopyB Lib "PS1W32.DLL" Alias "_SSBT_KernMEMCopyB@12" (ByRef destptr As Long, ByRef srcptr As Long, ByVal countval As Integer) As Long
Public Declare Function SSBT_KernMEMFillW Lib "PS1W32.DLL" Alias "_SSBT_KernMEMFillW@20" (ByVal value As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMRdB Lib "PS1W32.DLL" Alias "_SSBT_KernMEMRdB@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMRdL Lib "PS1W32.DLL" Alias "_SSBT_KernMEMRdL@16" (ByRef valueptr As Long, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMRdsB Lib "PS1W32.DLL" Alias "_SSBT_KernMEMRdsB@20" (ByRef bufptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMRdsL Lib "PS1W32.DLL" Alias "_SSBT_KernMEMRdsL@20" (ByRef bufptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMRdsW Lib "PS1W32.DLL" Alias "_SSBT_KernMEMRdsW@20" (ByRef bufptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMRdW Lib "PS1W32.DLL" Alias "_SSBT_KernMEMRdW@16" (ByRef valueptr As Integer, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMWrB Lib "PS1W32.DLL" Alias "_SSBT_KernMEMWrB@16" (ByVal value As Long, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMWrL Lib "PS1W32.DLL" Alias "_SSBT_KernMEMWrL@16" (ByVal value As Long, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMWrsB Lib "PS1W32.DLL" Alias "_SSBT_KernMEMWrsB@20" (ByRef bufptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMWrsL Lib "PS1W32.DLL" Alias "_SSBT_KernMEMWrsL@20" (ByRef bufptr As Long, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMWrsW Lib "PS1W32.DLL" Alias "_SSBT_KernMEMWrsW@20" (ByRef bufptr As Integer, ByVal addrval As Long, ByVal countval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernMEMWrW Lib "PS1W32.DLL" Alias "_SSBT_KernMEMWrW@16" (ByVal value As Integer, ByVal addrval As Long, ByVal bustype As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_KernStatus Lib "PS1W32.DLL" Alias "_SSBT_KernStatus@16" (ByRef valueptr As Long, ByVal typeval As Long, ByVal index As Long, ByVal handleval As Long) As Long
Public Declare Function SSBT_MakeLong Lib "PS1W32.DLL" Alias "_SSBT_MakeLong@8" (ByVal valh As Integer, ByVal vall As Integer) As Long
Public Declare Function SSBT_MakePtr Lib "PS1W32.DLL" Alias "_SSBT_MakePtr@8" (ByVal valh As Integer, ByVal vall As Integer) As Long
Public Declare Function SSBT_Mask Lib "PS1W32.DLL" Alias "_SSBT_Mask@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Sub SSBT_MemRdS Lib "PS1W32.DLL" Alias "_SSBT_MemRdS@16" (ByRef bufptr As Long, ByVal offval As Integer, ByVal cntval As Integer, ByVal handleval As Long)
Public Declare Sub SSBT_MemWrS Lib "PS1W32.DLL" Alias "_SSBT_MemWrS@16" (ByRef bufptr As Long, ByVal offval As Integer, ByVal cntval As Integer, ByVal handleval As Long)
Public Declare Function SSBT_Mod Lib "PS1W32.DLL" Alias "_SSBT_Mod@8" (ByVal moda As Long, ByVal modb As Long) As Long
Public Declare Sub SSBT_MonMemRdS Lib "PS1W32.DLL" Alias "_SSBT_MonMemRdS@16" (ByRef bufptr As Long, ByVal offval As Integer, ByVal cntval As Integer, ByVal handleval As Long)
Public Declare Sub SSBT_MonMemWrS Lib "PS1W32.DLL" Alias "_SSBT_MonMemWrS@16" (ByRef bufptr As Long, ByVal offval As Integer, ByVal cntval As Integer, ByVal handleval As Long)
Public Declare Function SSBT_MonMsg Lib "PS1W32.DLL" Alias "_SSBT_MonMsg@8" (ByRef dwdptr As Long, ByVal handleval As Long) As Integer
Public Declare Function SSBT_Mul Lib "PS1W32.DLL" Alias "_SSBT_Mul@8" (ByVal mula As Long, ByVal mulb As Long) As Long
Public Declare Function SSBT_PortRd Lib "PS1W32.DLL" Alias "_SSBT_PortRd@8" (ByVal addrval As Long, ByVal handleval As Long) As Long
Public Declare Sub SSBT_PortWr Lib "PS1W32.DLL" Alias "_SSBT_PortWr@12" (ByVal value As Long, ByVal addrval As Long, ByVal handleval As Long)
Public Declare Sub SSBT_RamRdS Lib "PS1W32.DLL" Alias "_SSBT_RamRdS@16" (ByRef bufptr As Long, ByVal offval As Integer, ByVal cntval As Integer, ByVal handleval As Long)
Public Declare Sub SSBT_RamWrS Lib "PS1W32.DLL" Alias "_SSBT_RamWrS@16" (ByRef bufptr As Long, ByVal offval As Integer, ByVal cntval As Integer, ByVal handleval As Long)
Public Declare Function SSBT_RcMsg Lib "PS1W32.DLL" Alias "_SSBT_RcMsg@20" (ByVal cmdval As Long, ByRef dwdptr As Long, ByVal wcval As Integer, ByVal blkval As Integer, ByVal handleval As Long) As Long
Public Declare Function SSBT_RdAWC Lib "PS1W32.DLL" Alias "_SSBT_RdAWC@4" (ByVal handleval As Long) As Integer
Public Declare Function SSBT_RdCwd Lib "PS1W32.DLL" Alias "_SSBT_RdCwd@8" (ByVal blkval As Integer, ByVal handleval As Long) As Long
Public Declare Sub SSBT_RdDwd Lib "PS1W32.DLL" Alias "_SSBT_RdDwd@16" (ByRef dwdptr As Long, ByVal wcval As Integer, ByVal blkval As Integer, ByVal handleval As Long)
Public Declare Function SSBT_RdMWC Lib "PS1W32.DLL" Alias "_SSBT_RdMWC@4" (ByVal handleval As Long) As Integer
Public Declare Function SSBT_RdRegAccess Lib "PS1W32.DLL" Alias "_SSBT_RdRegAccess@4" (ByVal handleval As Long) As Long
Public Declare Function SSBT_RdStatReg Lib "PS1W32.DLL" Alias "_SSBT_RdStatReg@4" (ByVal handleval As Long) As Long
Public Declare Sub SSBT_Reset Lib "PS1W32.DLL" Alias "_SSBT_Reset@4" (ByVal handleval As Long)
Public Declare Sub SSBT_ResetMon Lib "PS1W32.DLL" Alias "_SSBT_ResetMon@4" (ByVal handleval As Long)
Public Declare Sub SSBT_SelMonMem Lib "PS1W32.DLL" Alias "_SSBT_SelMonMem@8" (ByVal regval As Long, ByVal handleval As Long)
Public Declare Function SSBT_Shl Lib "PS1W32.DLL" Alias "_SSBT_Shl@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function SSBT_Shr Lib "PS1W32.DLL" Alias "_SSBT_Shr@8" (ByVal dataval As Long, ByVal cntval As Integer) As Long
Public Declare Function SSBT_Trigger Lib "PS1W32.DLL" Alias "_SSBT_Trigger@4" (ByVal handleval As Long) As Long
Public Declare Function SSBT_TxMsg Lib "PS1W32.DLL" Alias "_SSBT_TxMsg@20" (ByVal cmdval As Long, ByRef dwdptr As Long, ByVal wcval As Integer, ByVal blkval As Integer, ByVal handleval As Long) As Long
Public Declare Function SSBT_ValFromAscii Lib "PS1W32.DLL" Alias "_SSBT_ValFromAscii@8" (ByVal asciistr As String, ByVal radixval As Long) As Long
Public Declare Function SSBT_ValToAscii Lib "PS1W32.DLL" Alias "_SSBT_ValToAscii@16" (ByVal value As Long, ByVal asciistr As String, ByVal numbits As Long, ByVal radixval As Long) As String
Public Declare Sub SSBT_VerStr Lib "PS1W32.DLL" Alias "_SSBT_VerStr@8" (ByVal strptr As String, ByVal cntval As Long)
Public Declare Function SSBT_WrCtrlReg Lib "PS1W32.DLL" Alias "_SSBT_WrCtrlReg@16" (ByVal trval As Long, ByVal wcval As Integer, ByVal blkval As Integer, ByVal handleval As Long) As Long
Public Declare Sub SSBT_WrCwd Lib "PS1W32.DLL" Alias "_SSBT_WrCwd@12" (ByVal cmdval As Long, ByVal blkval As Integer, ByVal handleval As Long)
Public Declare Sub SSBT_WrDwd Lib "PS1W32.DLL" Alias "_SSBT_WrDwd@16" (ByRef dwdptr As Long, ByVal wcval As Integer, ByVal blkval As Integer, ByVal handleval As Long)
Public Declare Sub SSBT_WrRegAccess Lib "PS1W32.DLL" Alias "_SSBT_WrRegAccess@8" (ByVal regval As Long, ByVal handleval As Long)
Public Declare Sub SSBT_WrRegAddr Lib "PS1W32.DLL" Alias "_SSBT_WrRegAddr@8" (ByVal regval As Long, ByVal handleval As Long)

'**
'*
'*  PC-SSB-1 Driver predefined constants.
'*
'**

Public Const SSBT_WINDOW_SIZE As Integer = &H1000     'Size in bytes of memory window

Public Const SSBT_DFLT_ADDR As Integer = &HCC00       'Factory default segment address
Public Const SSBT_DFLT_PORT As Integer = &H2C0        'Factory default port address
Public Const SSBT_DFLT_IRQ As Integer = &H2          'Factory default interrupt request

Public Const REG_CTRL0 As Integer = &H0        'Port address offset of Control Register 0
Public Const REG_CTRL1 As Integer = &H1        'Port address offset of Control Register 1
Public Const REG_CTRL2 As Integer = &H2        'Port address offset of Control Register 2
Public Const REG_CTRL3 As Integer = &H3        'Port address offset of Control Register 3
Public Const REG_TRIG As Integer = &H4        'Port address offset of Trigger Register
Public Const REG_CLRINT As Integer = &H5        'Port address offset of Clear Interrupt Register
Public Const REG_ADDR As Integer = &H6        'Port address offset of Address Register
Public Const REG_ACCESS As Integer = &H7        'Port address offset of Access Register

Public Const REG_STAT0 As Integer = &H0         'Port address offset of Status Register 0
Public Const REG_STAT2 As Integer = &H2         'Port address offset of Status Register 2
Public Const REG_STAT3 As Integer = &H3         'Port address offset of Status Register 3
Public Const REG_STAT4 As Integer = &H4         'Port address offset of Status Register 4
Public Const REG_STAT5 As Integer = &H5         'Port address offset of Status Register 5

Public Const IREG_CTRL0 As Integer = &H0        'Address of Internal Control Register 0
Public Const IREG_CTRL1 As Integer = &H1        'Address of Internal Control Register 1
Public Const IREG_CTRL2 As Integer = &H2        'Address of Internal Control Register 2
Public Const IREG_CTRL3 As Integer = &H3        'Address of Internal Control Register 3
Public Const IREG_CTRL4 As Integer = &H4        'Address of Internal Control Register 4

'**
'*
'*  The following predefined constants identify the
'*  values of the bit positions of Control Register 0.
'*
'**

Public Const BCMODE As Integer = &H0           'Enables BC mode
Public Const RTMODE As Integer = &H10          'Enables RT mode
Public Const SIMMODE As Integer = &H20          'Enables simulate mode (BC only)
Public Const MONMODE As Integer = &H40          'Monitor mode
Public Const XTRIGEN As Integer = &H8           'Enables external trigger
Public Const INTEN As Integer = &H4           'Enables interrupt to host
Public Const RC0BUS As Integer = &H0           'Selects receive bus 0
Public Const RC1BUS As Integer = &H2           'Selects receive bus 1
Public Const TX0BUS As Integer = &H0           'Selects transmit bus 0
Public Const TX1BUS As Integer = &H1           'Selects transmit bus 1

'**
'*
'*  The following predefined constants identify the
'*  values of the bit positions of Control Register 1.
'*
'**

Public Const XMITMSG As Integer = &H80          'Transmit message
Public Const RCVMSG As Integer = &H0           'Receive message

'**
'*
'*  The following predefined constants identify the
'*  values of the bit positions of Control Register 3.
'*
'**

Public Const CTRL3_RESET As Integer = &H80    'Resets board
Public Const CTRL3_MRST As Integer = &H2     'Resets monitor
Public Const CTRL3_MONMEM As Integer = &H1     'Selects monitor memory
Public Const CTRL3_TERMMEM As Integer = &H0     'Selects terminal memory

'**
'*
'*  The following predefined constants identify the
'*  values of the bit positions of Status Register 0.
'*
'**

Public Const STAT0_INTI As Integer = &H80     'INTI bit
Public Const STAT0_MMEM As Integer = &H40     'Set if monitor memory selected
Public Const STAT0_MFULL As Integer = &H20     'Set if monitor is full
Public Const STAT0_MACT As Integer = &H10     'Set if monitor is active and not full
Public Const STAT0_NORESP As Integer = &H8      'Set if no response error
Public Const STAT0_WCERR As Integer = &H4      'Set if word count error
Public Const STAT0_ERROR As Integer = &H2      'Set if error
Public Const STAT0_DONE As Integer = &H1      'Set if done

'**
'*
'*  The following predefined constants identify the values
'*  of the bit positions of the Monitor Attribute Byte.
'*
'**

Public Const ATTR_RBUS As Integer = &H8        'Which bus received from
Public Const ATTR_PGAP As Integer = &H4        'Set if preceeding gap
Public Const ATTR_RSYNC As Integer = &H2        'Set if command sync
Public Const ATTR_WERR As Integer = &H1        'Set if word error

'**
'*
'*  The following predefined constants identify the error
'*  return values.
'*
'**

Public Const ERR_NONE As Long = 0          'No error
Public Const ERR_UNKNOWN As Long = -1         'An unexpected error occurred
Public Const ERR_CHKREG3 As Long = -2         'Did not find zeros in bits 2-7 of Status Register 3
Public Const ERR_CHKREG5 As Long = -3         'Did not find zeros in bits 2-7 of Status Register 5
Public Const ERR_CHKREG01 As Long = -4         'While toggling MMEM bit in Status Register 0, read 1, expected 0
Public Const ERR_CHKREG02 As Long = -5         'While toggling MMEM bit in Status Register 0, read 0, expected 1
Public Const ERR_CHKREG03 As Long = -6         'While toggling MMEM bit in Status Register 0, read 1, expected 0
Public Const ERR_CHKTERM As Long = -7         'Terminal memory contains unstable data
Public Const ERR_CHKMON As Long = -8         'Monitor memory contains unstable data
Public Const ERR_CHKMEMWR As Long = -9         'Cannot write to the terminal memory
Public Const ERR_CHKTERMWR As Long = -10        'Trial value written to terminal memory disappeared
Public Const ERR_CHKMONWR As Long = -11        'Trial value written to monitor memory disappeared
Public Const ERR_BADVER As Long = -20        'A bad version was encountered
Public Const ERR_BADPARAMS As Long = -21        'CardOpen() called with bad parameters
Public Const ERR_NOHANDLES As Long = -22        'CardOpen() already has allocated too many handles
Public Const ERR_NOCARD As Long = -23        'CardOpen() could not find a PS-SSB-1 card at the specified address
Public Const ERR_NOIO As Long = -24        'CardOpen() could not find the I/O ports
Public Const ERR_NOMEM As Long = -25        'CardOpen() could not find the memory
Public Const ERR_BAD16BIT As Long = -26        'Card is conflicting with another 16-bit card
Public Const ERR_NOSEL As Long = -27        'CardOpen() could not allocate a memory selector
Public Const ERR_BADHANDLE As Long = -28        'A bad handle was specified
Public Const ERR_VXD As Long = -29        'An error occurred in the VXD
