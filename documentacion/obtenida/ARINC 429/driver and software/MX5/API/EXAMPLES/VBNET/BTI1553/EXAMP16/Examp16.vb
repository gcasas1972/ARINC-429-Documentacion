Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI1553 DRIVER VB.NET BTI1553 EXAMPLE 16  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
    '  NAME:   EXAMP16 -- RT Response Time
	'
	'  This example configures Card Number 0 as an RT to receive
	'  the BC-RT data transmitted by the bus controller in
	'  Example 2. The programmable RT response time is set and then
	'  controlled by the up and down arrow buttons.
	'
	
	
	' Constants
    Const CARDNUM As Integer = 0
	Const MAX_CORES As Integer = 4
	Const MAX_CHANNELS As Integer = 16
	Const MAX_RESPTIME As Short = 255
	Const MIN_RESPTIME As Short = 77
	
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
	Dim resptime As Short
	
	Private Sub CmdDown_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdDown.Click
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		' Increment dacval
        resptime = CShort(resptime - 10)
		If (resptime < MIN_RESPTIME) Then
			resptime = MIN_RESPTIME
		End If
		
		' Temporaraly Stop the channel
		Call BTI1553_ChStop(channum, hCore)
		
		' Update the response time on the core
        errval = BTI1553_RTResponseTimeSet(resptime, 1, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while setting the RT response time")
            bSkipRun = True
            Exit Sub
        End If

        ' Start the channel
        Call BTI1553_ChStart(channum, hCore)

        ' Update text
        TimeText.Text = "resptime = " & Hex(resptime) & "H"

    End Sub

    Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        If (hCard >= 0) Then
            errval = BTICard_CardClose(hCard)
        End If

        ' End Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStart.Click

        If bSkipRun Then
            Exit Sub
        End If

        BTICard_CardReset((hCore))

        ' Configure the core for remote terminal mode.
        errval = BTI1553_RTConfig(RTCFG1553_DEFAULT, 1, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while configuring the RT")
            bSkipRun = True
            Exit Sub
        End If

        ' Set the RT Response Time
        resptime = 80
        errval = BTI1553_RTResponseTimeSet(resptime, 1, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while setting the RT response time")
            bSkipRun = True
            Exit Sub
        End If

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting the card")
            bSkipRun = True
            Exit Sub
        End If

        bCardRunning = True
        cmdStart.Enabled = False
        cmdStop.Enabled = True
        CmdDown.Enabled = True
        CmdUp.Enabled = True
        TimeText.Text = "resptime = " & Hex(resptime) & "H"

    End Sub

    Private Sub CmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStop.Click
        'Clear state of bRunning before card is stopped (so timer event is not processed)
        Dim bTemp As Boolean
        bTemp = bCardRunning
        bCardRunning = False

        If (bTemp = True) Then
            BTICard_CardStop(hCore)
        End If

        cmdStart.Enabled = True
        cmdStop.Enabled = False
        CmdDown.Enabled = False
        CmdUp.Enabled = False

    End Sub

    Private Sub CmdUp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdUp.Click
        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        ' Increment dacval
        resptime = CShort(resptime + 10)
        If (resptime > MAX_RESPTIME) Then
            resptime = MAX_RESPTIME
        End If

        ' Temporaraly Stop the channel
        Call BTI1553_ChStop(channum, hCore)

        ' Update the response time on the core
        errval = BTI1553_RTResponseTimeSet(resptime, 1, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while setting the RT response time")
            bSkipRun = True
            Exit Sub
        End If

        ' Start the channel
        Call BTI1553_ChStart(channum, hCore)

        ' Update text
        TimeText.Text = "resptime = " & Hex(resptime) & "H"

    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Errhandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        bSkipRun = False
        bCardRunning = False
        cmdStart.Enabled = False
        cmdStop.Enabled = False
        CmdDown.Enabled = False
        CmdUp.Enabled = False

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If CBool(errval) Then
            errstr = "Error: Unable to open card number " & CARDNUM
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first 1553 core and channel capable of programable RT response time
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For channum = 0 To MAX_CHANNELS - 1
                    If CBool(BTI1553_ChIs1553(channum, hCore)) Then
                        If CBool(BTI1553_ChGetInfo(INFO1553_RTRESPTIME, channum, hCore)) Then
                            Exit For
                        End If
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
        Channel.Text = "Using programmable RT response time 1553 channel #" & channum

        'Set flag so we run hardware
        bSkipRun = False

        cmdStart.Enabled = True
        cmdStop.Enabled = False

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
End Class