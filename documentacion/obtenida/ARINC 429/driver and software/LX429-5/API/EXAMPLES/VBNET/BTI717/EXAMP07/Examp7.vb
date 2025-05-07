Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI717 DRIVER VB_EXAMPLE 7  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP7 -- Parametrics example
	'
	'  The user can then control the amplitude using the UP and
	'  DOWN arrow keys and the frequency using the LEFT and RIGHT
	'  arrow keys.
	'
	
	' Force explicit declaration of all variables
	
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Const DAC_HIGH As Short = &HFF0S
    Const DAC_LOW As Short = &H600S

    Dim bCardRunning As Boolean
    Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim xmtchan As Integer

    ' Program specific
    Dim wps As UShort
    Dim superfrmaddr As UInteger
    Dim sfblock(8199) As UShort
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
        Call BTI717_ChStop(xmtchan, hCore)

        ' Update the amplitude on the core
        errval = BTI717_ParamAmplitudeConfig(PARAMCFG717_DEFAULT, dacval, xmtchan, hCore)
        If (errval < 0) Then
            MsgBox("Error: can not update amplitude on core number #" & corenum)
            bSkipRun = True
            BTICard_CardStop(hCore)
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI717_ChStart(xmtchan, hCore)

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

        '  Init subframe data.
        For j = 1 To 4
            Call BTI717_SubFrmBlkRd(sfblock(0), j, xmtchan, hCore)
            For jj = 2 To wps
                sfblock(jj + 7) = CUShort(((&H100S * j) + jj) And &HFFFS)
            Next
            Call BTI717_SubFrmBlkWr(sfblock(0), j, xmtchan, hCore)
        Next

        '  Create some SuperFrame structures.
        Call BTI717_SuperFrmConfig(10, 16, xmtchan, hCore)

        '  Define SF2, W10 to be SuperFrame Data. Init superframe data.
        superfrmaddr = BTI717_SuperFrmDefine(2, 10, xmtchan, hCore)
        For j = 1 To 16
            'UPGRADE_WARNING: Couldn't resolve default property of object j. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call BTI717_SuperFrmWordWr(CUShort(&H500S + j), j, superfrmaddr, xmtchan, hCore)
        Next

        '  Set superframe counter position.
        Call BTI717_SuperFrmCounterPos(1, wps, xmtchan, hCore)

        '  Configure word options. (Mark word 1 of SFs 1, 2, 3, and 4 for the Sequential Monitor)
        Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 1, 1, xmtchan, hCore)
        Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 2, 1, xmtchan, hCore)
        Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 3, 1, xmtchan, hCore)
        Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 4, 1, xmtchan, hCore)

        '  (Mark the word at SPF 4 of our superframe word (word 10, SF 2) for the Sequential Monitor)
        Call BTI717_SuperFrmWordConfig(WRDCFG717_SEQ, 4, superfrmaddr, xmtchan, hCore)

        '
        '  Configure Parametrics on xmtchan
        '

        If (dacval > DAC_HIGH) Then
            dacval = DAC_HIGH
        ElseIf (dacval < DAC_LOW) Then
            dacval = DAC_LOW
        End If

        errval = BTI717_ParamAmplitudeConfig(PARAMCFG717_DEFAULT, dacval, xmtchan, hCore)
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
        CmdUp.Enabled = True
        CmdDown.Enabled = True

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
        Call BTI717_ChStop(xmtchan, hCore)

        ' Update the amplitude on the core
        errval = BTI717_ParamAmplitudeConfig(PARAMCFG717_DEFAULT, dacval, xmtchan, hCore)
        If (errval < 0) Then
            MsgBox("Error: can not update amplitude on core number #" & corenum)
            bSkipRun = True
            BTICard_CardStop(hCore)
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI717_ChStart(xmtchan, hCore)

        ' Update text
        DacText.Text = "Dac = " & dacval

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
        CmdUp.Enabled = False
        CmdDown.Enabled = False

        ' Init the words-per-second
        wps = 128

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, cardnum)
        If CBool(errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        '  Find the first ARINC 717 core with a BiPhase transmit channel that supports parametrics.
        For corenum = 0 To (MAX_CORES - 1)
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For xmtchan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI717_ChIsType(CHCFG717_BIPHASEXMT, xmtchan, hCore)) Then
                        If CBool(BTI717_ChGetInfo(INFO717_PARAM, xmtchan, hCore)) Then
                            Exit For
                        End If
                    End If
                Next

                If (corenum < MAX_CORES) And (xmtchan < MAX_CHANNELS) Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (xmtchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 717 core present in card #" & cardnum)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Transmit.Text = "Using BiPhase parametric transmit channel #" & xmtchan

        'Set flag so we run hardware
        bSkipRun = False

        cmdStart.Enabled = True
        cmdStop.Enabled = False

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
End Class