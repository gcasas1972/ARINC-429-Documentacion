Option Strict Off
Option Explicit On

Module UtilVB
	'/**
	'*
    '*  BTICard WIN32 DRIVER  (06/07/2011)
    '*  Copyright (c) 2009-2011
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
	Public Function ShiftRight(ByVal Value As Integer, ByVal ShiftCount As Integer) As Integer
		Const conMaxLong As Integer = &HFFFFFFFF
		Dim lngPower2 As Integer
		Select Case ShiftCount
			Case 0
				ShiftRight = Value
			Case 1 To 30
				lngPower2 = 2 ^ ShiftCount
				ShiftRight = (Value And conMaxLong - lngPower2 + 1) \ lngPower2
			Case 31
				ShiftRight = CBool(Value And &H80000000)
			Case Else
				ShiftRight = 0
		End Select
	End Function
	
	'
	' Performs a Bitwise Left Shift on Value
	'
	Public Function ShiftLeft(ByRef Value As Integer, ByVal ShiftCount As Integer) As Integer
		Dim mask As Integer
		
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
	Public Function Pow2(ByVal Exponent As Integer) As Integer
		Static alPow2(31) As Integer
		Static i As Integer
		
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
End Module