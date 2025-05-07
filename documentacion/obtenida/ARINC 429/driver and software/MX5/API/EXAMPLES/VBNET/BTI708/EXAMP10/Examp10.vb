Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI708 DRIVER VB_EXAMPLE 10  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP10 -- Parametrics example
	'
	'  This program opens Card Number 0, and configures the
	'  first transmit channel on the first 708 Core to transmit
	'  a sequence of 32 messages at a rate of 200Hz. The messages
	'  are automatically assigned the numbers 0 through 31.
	'
	'  The user can then control the amplitude using the UP and
	'  DOWN arrow buttons.
	'
	
	
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Const FRAMEFREQ As Short = 200 'Frame frequency of 200Hz
    Const LOGFREQ As Short = 16 'Generate a Log Event after every 16th message
    Const FRAMECOUNT As UShort = 32 'Transmit a total of 32 messages

    Const DAC_HIGH As Short = &HFFFS
    Const DAC_LOW As Short = &H599S

    Dim bCardRunning As Boolean
    Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim xmtchan As Integer
    Dim Data(99) As UShort
    Dim offset As UShort
    Dim dacval As UShort
    Dim j As UShort
    Dim jj As UShort

    Private Sub CmdDown_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdDown.Click
        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        ' Decrement dacval
        dacval = CUShort(dacval - 16)
        If (dacval < DAC_LOW) Then
            dacval = DAC_LOW
        End If

        ' Temporaraly Stop the transmit channel
        Call BTI708_ChStop(xmtchan, hCore)

        ' Update the amplitude on the core
        errval = BTI708_ParamAmplitudeConfig(PARAMCFG708_DEFAULT, dacval, xmtchan, hCore)
        If (errval < 0) Then
            MsgBox("Error: can not update amplitude on core number #" & corenum)
            bSkipRun = True
            BTICard_CardStop(hCore)
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI708_ChStart(xmtchan, hCore)

        ' Update text
        DacText.Text = "Dac = " & dacval

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

        For j = 0 To FRAMECOUNT - 1 'Loop through all the messages
            For jj = 0 To 99
                Data(jj) = CUShort(j + (offset * FRAMECOUNT))
            Next

            Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write data to the Device
        Next
        offset = CUShort(offset + 1)

        '
        '  Configure Parametrics on xmtchan
        '

        If (dacval > DAC_HIGH) Then
            dacval = DAC_HIGH
        ElseIf (dacval < DAC_LOW) Then
            dacval = DAC_LOW
        End If

        errval = BTI708_ParamAmplitudeConfig(PARAMCFG708_DEFAULT, dacval, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the amplitude on channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
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

        ' Update text
        DacText.Text = "Dac = " & dacval

        bCardRunning = True
        cmdStart.Enabled = False
        cmdStop.Enabled = True

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
        CmdUp.Enabled = False
        CmdDown.Enabled = False

    End Sub

    Private Sub CmdUp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdUp.Click
        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        ' Increment dacval
        dacval = CUShort(dacval + 16)
        If (dacval > DAC_HIGH) Then
            dacval = DAC_HIGH
        End If

        ' Temporaraly Stop the transmit channel
        Call BTI708_ChStop(xmtchan, hCore)

        ' Update the amplitude on the core
        errval = BTI708_ParamAmplitudeConfig(PARAMCFG708_DEFAULT, dacval, xmtchan, hCore)
        If (errval < 0) Then
            MsgBox("Error: can not update amplitude on core number #" & corenum)
            bSkipRun = True
            BTICard_CardStop(hCore)
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI708_ChStart(xmtchan, hCore)

        ' Update text
        DacText.Text = "Dac = " & dacval

    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Errhandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        offset = 0
        bSkipRun = False
        bCardRunning = False
        cmdStart.Enabled = False
        cmdStop.Enabled = False
        CmdUp.Enabled = False
        CmdDown.Enabled = False

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first ARINC 708 core with a transmit channel that supports parametrics.
        For corenum = 0 To (MAX_CORES - 1)
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For xmtchan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI708_ChIsXmt(xmtchan, hCore)) Then
                        If (BTI708_ChGetInfo(INFO708_PARAM, xmtchan, hCore) > 0) Then
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
            MsgBox("Error:  No parametric ARINC 708 core present in card #" & cardnum)
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