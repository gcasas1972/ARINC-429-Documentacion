Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI1553 DRIVER VB.NET BTI1553 EXAMPLE 3  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP3 -- Simulating an RT
	'
	'  This example configures Card Number 0 as an RT to receive
	'  the BC-RT data transmitted by the bus controller in
	'  Example 2.
	'
	'  It continuously receives and displays the data words.
	'
	
	
	' Constants
    Const CARDNUM As Integer = 0
	Const MAX_CORES As Integer = 4
	Const MAX_CHANNELS As Integer = 16
	
	' Card specific
    Dim hCard As UInteger
    Dim hCore As UInteger
	Dim corenum As Integer
	Dim channum As Integer
	Dim bSkipRun As Boolean
	Dim bCardRunning As Boolean
    Dim errval As Integer
	Dim errstr As String
	
	' Program specific
    Dim RTMsg As UInteger
    Dim Data(31) As UShort
	
	Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdExit.Click
		If (hCore >= 0) Then
            errval = BTICard_CardClose(hCore)
        End If

        ' End Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click

        If bSkipRun Then
            Exit Sub
        End If

        ' Configure the channel for remote terminal mode.
        BTICard_CardReset((hCore))
        errval = BTI1553_RTConfig(RTCFG1553_DEFAULT, 1, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while while configuring for remote terminal mode")
            bSkipRun = True
            Exit Sub
        End If

        ' Get the message address for the receive subaddress.
        RTMsg = BTI1553_RTGetMsg(SUBADDRESS, 1, RCV, 2, channum, hCore)

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting the card")
            bSkipRun = True
            Exit Sub
        End If

        bCardRunning = True
        CmdStart.Enabled = False
        CmdStop.Enabled = True

    End Sub

    Private Sub CmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStop.Click
        'Clear state of bRunning before card is stopped (so timer event is not processed)
        Dim bTemp As Boolean
        bTemp = bCardRunning
        bCardRunning = False

        If (bTemp = True) Then
            BTICard_CardStop(hCore)
        End If

        CmdStart.Enabled = True
        CmdStop.Enabled = False
        Result1.Text = "Card Stopped"
    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Errhandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        bSkipRun = False
        bCardRunning = False
        CmdStart.Enabled = False
        CmdStop.Enabled = False
        Result1.Text = "Card Stopped"

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If CBool(errval) Then
            errstr = "Error: Unable to open card number " & CARDNUM
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first 1553 core and channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For channum = 0 To MAX_CHANNELS - 1
                    If CBool(BTI1553_ChIs1553(channum, hCore)) Then
                        Exit For
                    End If
                Next
                If channum < MAX_CHANNELS Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (channum >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible MIL-STD-1553 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Channel.Text = "Using 1553 channel #" & channum

        'Set flag so we run hardware
        bSkipRun = False

        CmdStart.Enabled = True
        CmdStop.Enabled = False

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		' Read data received from the BC
		Call BTI1553_MsgDataRd(Data(0), 3, RTMsg, hCore)
		Result1.Text = "Received data {" & Hex(Data(0)) & ", " & Hex(Data(1)) & ", " & Hex(Data(2)) & "}"
		
	End Sub
End Class