
'/**
'*
'*  BTICard WIN32 DRIVER  (06/07/2011)
'*  Copyright (c) 2003-2010
'*  Ballard Technology, Inc.
'*  www.ballardtech.com
'*  support@ballardtech.com
'*  ALL RIGHTS RESERVED
'*
'*  NAME:   UtilVB.TXT -- Visual Basic
'*                           Helper Function Header File.
'*
'**

'/**
'*
'*  This file provides helper functions used in the BTI Example programs.
'*
'**/

'
' Performs a Bitwise Right Shift on Value
'
Public Function ShiftRight(ByVal Value As Long, ByVal ShiftCount As Long) As Long
  Const conMaxLong As Long = &HFFFFFFFF
  Dim lngPower2 As Long
  Select Case ShiftCount
  Case 0
    ShiftRight = Value
  Case 1 To 30
    lngPower2 = 2 ^ ShiftCount
    ShiftRight = (Value And conMaxLong - lngPower2& + 1&) \ lngPower2&
  Case 31
    ShiftRight = CBool(Value And &H80000000)
  Case Else
    ShiftRight = 0
  End Select
End Function

'
' Performs a Bitwise Left Shift on Value
'
Public Function ShiftLeft(Value As Long, ByVal ShiftCount As Long) As Long
  Dim mask As Long
  
  Select Case ShiftCount
  Case 1 To 31
    ' mask out bits that are pushed over the edge anyway
    mask = Pow2(31 - ShiftCount)
    ShiftLeft = Value And (mask - 1)
    ' shift
    ShiftLeft = ShiftLeft * Pow2(ShiftCount)
    ' set sign bit
    If Value And mask Then
      ShiftLeft = ShiftLeft Or &H80000000
    End If
  Case 0
    ' ret unchanged
    ShiftLeft = Value
  Case Else
    ShiftLeft = 0
  End Select
  
End Function

'
' Raise 2 to a power. The exponent must be in the range [0,31].
'
Public Static Function Pow2(ByVal Exponent As Long) As Long
  Dim alPow2(0 To 31) As Long
  Dim i As Long
  
  Select Case Exponent
  Case 0 To 31
    ' initialize lookup table
    If alPow2(0) = 0 Then
      alPow2(0) = 1
      For i = 1 To 30
        alPow2(i) = alPow2(i - 1) * 2
      Next
      alPow2(31) = &H80000000
    End If
    ' return
    Pow2 = alPow2(Exponent)
  End Select
  
End Function
