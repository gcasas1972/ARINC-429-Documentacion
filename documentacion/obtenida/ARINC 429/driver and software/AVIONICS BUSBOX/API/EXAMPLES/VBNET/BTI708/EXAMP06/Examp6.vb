Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI708 DRIVER VB_EXAMPLE 6  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP6 -- Header extraction example
	'
	'  This program opens Card Number 0, and configures the
	'  first compatible core to receive messages in a single
	'  message record.  This message is automatically assigned
	'  to message number 0.
	'
    '  An Event Log frequency of 0 is specified, which will
	'  not generate any Event Log List entries for this channel.
	'
    '  The program will display the ARINC 708 header information
	'  from the message record, until the stop button is pressed.
	'
	
	
	' Constants
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    ' Card specific
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim rcvchan As Integer
    Dim bSkipRun As Boolean
    Dim bCardRunning As Boolean

    Dim Data(99) As UShort

    Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdExit.Click
        If (hCard >= 0) Then
            errval = BTICard_CardClose(hCard)
        End If

        ' End Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click

        If bSkipRun Then
            Exit Sub
        End If

        BTICard_CardReset((hCore))

        ' Configure receive channel.
        errval = BTI708_ChConfig(CHCFG708_DEFAULT, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Build the receive channel messages.
        errval = BTI708_RcvBuild(MSGCRT708_DEFAULT, 0, 1, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while building" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while starting core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        bCardRunning = True
        CmdStart.Enabled = False
        CmdStop.Enabled = True
        Result1.Text = "Card Running"

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
        On Error GoTo ErrHandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        CmdStart.Enabled = False
        CmdStop.Enabled = False
        bSkipRun = False
        bCardRunning = False
        Result1.Text = "Card Stopped"
        label_hex.Text = ""
        label_oct.Text = ""
        controlaccept.Text = ""
        bits16to11.Text = ""
        bits26to17.Text = ""
        mode.Text = ""
        tilt_hex.Text = ""
        tilt_dec.Text = ""
        gain.Text = ""
        range.Text = ""
        bit49.Text = ""
        dataaccept.Text = ""
        scanangle_hex.Text = ""
        scanangle_dec.Text = ""
        bit64.Text = ""

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            errstr = "Error: Unable to open card number " & CARDNUM
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first ARINC 708 core with a receive channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If CBool(BTI708_ChIsRcv(rcvchan, hCore)) Then
                        Exit For
                    End If
                Next
                If rcvchan < MAX_CHANNELS Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 708 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        ChanLbl.Text = "Using ARINC 708 receive channel #" & rcvchan

        'Set flag so we run hardware
        bSkipRun = False

        CmdStart.Enabled = True
        CmdStop.Enabled = False
        Exit Sub
ErrHandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		'UPGRADE_NOTE: str was upgraded to str_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim str_Renamed As String
		
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		Call BTI708_MsgDataRd(Data(0), 0, rcvchan, hCore)
		
		label_hex.Text = Hex(BTI708_FieldGetLabel(Data(0))) & " (Hex)"
		label_oct.Text = Oct(BTI708_FieldGetLabel(Data(0))) & " (Oct)"
		controlaccept.Text = Hex(BTI708_FieldGetControlAccept(Data(0))) & " (Hex)"
        bits16to11.Text = Hex(CSByte(Data(0) / 1024) And &H3FS) & " (Hex)"
		bits26to17.Text = Hex(Data(1) And &H3FFs) & " (Hex)"
		mode.Text = Hex(BTI708_FieldGetMode(Data(0))) & " (Hex)"
		tilt_hex.Text = Hex(BTI708_FieldGetTilt(Data(0))) & " (Hex)"
		tilt_dec.Text = BTI708_FieldGetTilt(Data(0)) & " (Dec)"
		gain.Text = BTI708_FieldGetGain(Data(0)) & " (Dec)"
		range.Text = BTI708_FieldGetRange(Data(0)) & " (Dec)"
		bit49.Text = Hex(Data(4) And &H1s) & " (Hex)"
		dataaccept.Text = Hex(BTI708_FieldGetDataAccept(Data(0))) & " (Hex)"
		scanangle_hex.Text = Hex(BTI708_FieldGetAngle(Data(0))) & " (Hex)"
		scanangle_dec.Text = BTI708_FieldGetAngle(Data(0)) & " (Dec)"
        bit64.Text = Hex(CSByte(Data(4) / 32768) And &H1S) & " (Hex)"
		
	End Sub
End Class