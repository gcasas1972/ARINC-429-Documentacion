Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI708 DRIVER VB_EXAMPLE 11  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP11 -- Variable Bit Length Example
	'
	'  This program opens Card Number 0, and configures the
	'  first transmit channel on the first 708 Core to transmit
	'  a sequence of 32 messages at a rate of 200Hz. The messages
	'  are automatically assigned the numbers 0 through 31.
	'
	'  The user can then control the bit length using the LEFT and
	'  RIGHT arrow buttons.
	'
	
	
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Const FRAMEFREQ As Short = 200 'Frame frequency of 200Hz
    Const LOGFREQ As Short = 16 'Generate a Log Event after every 16th message
    Const FRAMECOUNT As UShort = 32 'Transmit a total of 32 messages

    Const BIT_HIGH As Short = &H740S
    Const BIT_LOW As Short = &H1S

    Dim bCardRunning As Boolean
    Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim xmtchan As Integer
    Dim Data(115) As UShort
    Dim offset As UShort
    Dim bitlength As UShort
    Dim j As UShort
    Dim jj As UShort

    Private Sub CmdLeft_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdLeft.Click
        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        ' Decrement dacval
        bitlength = CUShort(bitlength - 16)
        If (bitlength < BIT_LOW) Then
            bitlength = BIT_LOW
        End If

        ' Update the bitlength on the messages
        If (bitlength > BIT_HIGH) Then
            bitlength = BIT_HIGH
        ElseIf (bitlength < BIT_LOW) Then
            bitlength = BIT_LOW
        End If

        For j = 0 To FRAMECOUNT - 1 'Loop through all the messages
            For jj = 0 To CUShort((bitlength / 16) + 1)
                If (jj < 116) Then Data(jj) = j + (offset * FRAMECOUNT)
            Next

            Call BTI708_MsgVarDataWr(Data(0), bitlength, j, xmtchan, hCore) 'Write data to the Device
        Next
        offset = CUShort(offset + 1)

        ' Update text
        Length.Text = "Length = " & bitlength

    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        If (hCard >= 0) Then
            errval = BTICard_CardClose(hCard)
        End If

        ' End Program
        End

    End Sub

    Private Sub cmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStart.Click

        If (bSkipRun = True) Then
            Exit Sub
        End If

        '
        ' Configure xmtchan to transmit at high speed.
        '

        BTICard_CardReset((hCore))

        'Configure channel
        errval = BTI708_ChConfig(CHCFG708_DEFAULT, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        '
        '  Build the transmit channel messages.
        '

        errval = BTI708_XmtBuild(MSGCRT708_DEFAULT, FRAMEFREQ, LOGFREQ, FRAMECOUNT, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while building" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        '
        '  Create and write the data for the messages.
        '

        If (bitlength > BIT_HIGH) Then
            bitlength = BIT_HIGH
        ElseIf (bitlength < BIT_LOW) Then
            bitlength = BIT_LOW
        End If

        For j = 0 To FRAMECOUNT - 1 'Loop through all the messages
            For jj = 0 To CUShort((bitlength / 16) + 1)
                If (jj < 116) Then Data(jj) = j + (offset * FRAMECOUNT)
            Next

            Call BTI708_MsgVarDataWr(Data(0), bitlength, j, xmtchan, hCore) 'Write data to the Device
        Next
        offset = CUShort(offset + 1)

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting the card")
            bSkipRun = True
            Exit Sub
        End If

        ' Update text
        Length.Text = "Length = " & bitlength

        bCardRunning = True
        cmdStart.Enabled = False
        cmdStop.Enabled = True
        CmdLeft.Enabled = True
        CmdRight.Enabled = True

    End Sub

    Private Sub cmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStop.Click
        'Clear state of bRunning before card is stopped (so timer event is not processed)
        Dim bTemp As Boolean
        bTemp = bCardRunning
        bCardRunning = False

        If (bTemp = True) Then
            BTICard_CardStop(hCore)
        End If

        cmdStart.Enabled = True
        cmdStop.Enabled = False
        CmdLeft.Enabled = False
        CmdRight.Enabled = False

    End Sub

    Private Sub CmdRight_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdRight.Click
        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        ' Increment bitlength
        bitlength = CUShort(bitlength + 16)
        If (bitlength > BIT_HIGH) Then
            bitlength = BIT_HIGH
        End If

        ' Update the amplitude on the core
        If (bitlength > BIT_HIGH) Then
            bitlength = BIT_HIGH
        ElseIf (bitlength < BIT_LOW) Then
            bitlength = BIT_LOW
        End If

        For j = 0 To FRAMECOUNT - 1 'Loop through all the messages
            For jj = 0 To CUShort((bitlength / 16) + 1)
                If (jj < 116) Then Data(jj) = j + (offset * FRAMECOUNT)
            Next

            Call BTI708_MsgVarDataWr(Data(0), bitlength, j, xmtchan, hCore) 'Write data to the Device
        Next
        offset = CUShort(offset + 1)

        ' Update text
        Length.Text = "Length = " & bitlength

    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Errhandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        offset = 0
        bitlength = 1600
        bSkipRun = False
        bCardRunning = False
        cmdStart.Enabled = False
        cmdStop.Enabled = False
        CmdLeft.Enabled = False
        CmdRight.Enabled = False

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first ARINC 708 core with a transmit channel that variable bitlength
        For corenum = 0 To (MAX_CORES - 1)
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For xmtchan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI708_ChIsXmt(xmtchan, hCore)) Then
                        If (BTI708_ChGetInfo(INFO708_VARBIT, xmtchan, hCore) > 0) Then
                            Exit For
                        End If
                    End If
                Next
                If (corenum < MAX_CORES) And (xmtchan < MAX_CHANNELS) Then
                    Exit For
                End If
            End If
        Next

        If (hCore = 0) Or (corenum = MAX_CORES) Or (xmtchan = MAX_CHANNELS) Then
            MsgBox("Error:  No variable bit length ARINC 708 core present in card #" & cardnum)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Transmit.Text = "Using transmit channel #" & xmtchan

        'Set flag so we run hardware
        bSkipRun = False

        cmdStart.Enabled = True
        cmdStop.Enabled = False

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
End Class