Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI717 DRIVER VB_EXAMPLE 1  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP1 -- Receiver example
	'
	'  This program opens Card Number 0, and configures the
	'  first BiPhase channel as a receiver.  After the
	'  channel gets in sync, the program displays the first
	'  word of each subframe (sync words).
	'
	
	' Force explicit declaration of all variables
	
	' Constants
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    ' Card specific
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim corenum As Integer
    Dim errval As Integer
    Dim rcvchan As Integer
    Dim bSkipRun As Boolean
    Dim bCardRunning As Boolean

    ' Program specific
    Dim syncword1 As UShort
    Dim syncword2 As UShort
    Dim syncword3 As UShort
    Dim syncword4 As UShort

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

        ' Configure channel for auto speed detection.
        BTICard_CardReset((hCore))
        errval = BTI717_ChConfig(CHCFG717_BIPHASERCV Or CHCFG717_AUTOSPEED, rcvchan, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while configuring channel" & rcvchan)
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
        Result1.Text = "Synchronizing to bit stream...."

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
        Result1.Text = "Card Stopped"
        Result2.Text = ""
    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Errhandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        cmdStart.Enabled = False
        cmdStop.Enabled = False
        bSkipRun = False
        bCardRunning = False
        Result1.Text = "Card Stopped"
        Result2.Text = ""

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, cardnum)
        If CBool(errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first 717 core with a BiPhase receive channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If CBool(BTI717_ChIsType(CHCFG717_BIPHASERCV, rcvchan, hCore)) Then
                        Exit For
                    End If
                Next
                If rcvchan < MAX_CHANNELS Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 717 core present in card #" & cardnum)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Channel.Text = "Using 717 BiPhase channel #" & rcvchan

        'Set flag so we run hardware
        bSkipRun = False

        cmdStart.Enabled = True
        cmdStop.Enabled = False
        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		'
		' Test and Display data on the screen
		'
		
        If CBool(BTI717_SyncTest(rcvchan, hCore)) Then
            Result1.Text = "In Sync!"
            Call BTI717_SubFrmWordRd(syncword1, 1, 1, rcvchan, hCore)
            Call BTI717_SubFrmWordRd(syncword2, 2, 1, rcvchan, hCore)
            Call BTI717_SubFrmWordRd(syncword3, 3, 1, rcvchan, hCore)
            Call BTI717_SubFrmWordRd(syncword4, 4, 1, rcvchan, hCore)
            Result2.Text = "Sync1=" & Oct(syncword1) & "  Sync2=" & Oct(syncword2) & "  Sync3=" & Oct(syncword3) & "  Sync4=" & Oct(syncword4)
        End If
		
	End Sub
End Class