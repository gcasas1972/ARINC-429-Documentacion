Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI1553 DRIVER VB.NET BTI1553 EXAMPLE 17  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP17 -- Parametrics example
	'
	'  This example configures Card Number 0 as a bus controller
	'  to transmit a schedule of three messages.  The schedule is
	'  created in such a way that the messages are transmitted at
	'  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
	'  and 40ms, respectively).
	'
	'  The program uses the up and down arrow buttons to control the
	'  frequency output on the bus. The left and right arrow buttons
	'  are used to control the offset associated with the mid-bit
	'  crossing.
	'
	
	
    Const CARDNUM As Integer = 0
	Const MAX_CORES As Integer = 4
	Const MAX_CHANNELS As Integer = 16
	
	Const CMD0 As Short = &H843s
	Const CMD1 As Short = &H821s
	Const RCV_CMD2 As Short = &H821s
	Const XMT_CMD2 As Short = &H1C21s
	
	Const frametime As Integer = 10000
	
	Const DAC_HIGH As Short = &HFFFs
	Const DAC_LOW As Short = &H599s
	Const OFFSET_HIGH As Short = &H64s
	Const OFFSET_LOW As Short = &H0s
	
	Dim bCardRunning As Boolean
	Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim errval As Integer
	Dim errstr As String
	Dim corenum As Integer
	Dim channum As Integer
	
    Dim dacval As UShort
	Dim offset As Short
    Dim BCMsgs(2) As UInteger
    Dim Data(2) As UShort
	
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
		Call BTI1553_ChStop(channum, hCore)
		
		' Update the amplitude on the core
        errval = BTI1553_ParamAmplitudeConfig(PARAMCFG1553_DEFAULT, dacval, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error: can not update amplitude on core number #" & corenum)
            bSkipRun = True
            BTICard_CardStop(hCore)
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI1553_ChStart(channum, hCore)

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

    Private Sub CmdLeft_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdLeft.Click
        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        ' Decrement bitrate
        offset = CShort(offset - 1)
        If (offset < OFFSET_LOW) Then
            offset = OFFSET_LOW
        End If

        ' Temporaraly Stop the transmit channel
        Call BTI1553_ChStop(channum, hCore)

        ' Update the error on the bus
        errval = BTI1553_ErrorDefine(ERRDEF1553_ZEROX2, 0, offset, 0, 0, channum, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while defining" & vbNewLine
            errstr = errstr & "the error on channel #" & channum & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI1553_ChStart(channum, hCore)

        ' Update text
        OffsetText.Text = "Offset = " & offset

    End Sub

    Private Sub CmdRight_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdRight.Click
        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        ' Increment bitrate
        offset = CShort(offset + 1)
        If (offset > OFFSET_HIGH) Then
            offset = OFFSET_HIGH
        End If

        ' Temporaraly Stop the transmit channel
        Call BTI1553_ChStop(channum, hCore)

        ' Update the error on the bus
        errval = BTI1553_ErrorDefine(ERRDEF1553_ZEROX2, 0, offset, 0, 0, channum, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while defining" & vbNewLine
            errstr = errstr & "the error on channel #" & channum & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI1553_ChStart(channum, hCore)

        ' Update text
        OffsetText.Text = "Offset = " & offset

    End Sub

    Private Sub cmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStart.Click

        If (bSkipRun = True) Then
            Exit Sub
        End If

        BTICard_CardReset((hCore))

        ' Configure the channel for bus controller mode.
        errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the BC on channel #" & channum & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Create the message records for each of the three messages.
        Data(0) = 0
        Data(1) = 0
        Data(2) = 0

        BCMsgs(0) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, CMD0, 0, Data(0), hCore)
        BCMsgs(1) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, CMD1, 0, 0, hCore)
        BCMsgs(2) = BTI1553_BCCreateMsg(MSGCRT1553_RTRT, RCV_CMD2, XMT_CMD2, 0, hCore)


        '  Schedule the messages to create the desired bus controller schedule.

        Call BTI1553_BCSchedFrame(frametime, channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(2), channum, hCore)

        Call BTI1553_BCSchedFrame(frametime, channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)

        Call BTI1553_BCSchedFrame(frametime, channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)

        Call BTI1553_BCSchedFrame(frametime, channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)

        '  Configure Parametrics on channum
        If (dacval > DAC_HIGH) Then
            dacval = DAC_HIGH
        ElseIf (dacval < DAC_LOW) Then
            dacval = DAC_LOW
        End If

        errval = BTI1553_ParamAmplitudeConfig(PARAMCFG1553_DEFAULT, dacval, channum, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the amplitude on channel #" & channum & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        '  Define the type of error generation.  One of the bus
        '  controller messages is tagged to generate errors.

        If (offset > OFFSET_HIGH) Then
            offset = OFFSET_HIGH
        ElseIf (offset < OFFSET_LOW) Then
            offset = OFFSET_LOW
        End If

        errval = BTI1553_ErrorDefine(ERRDEF1553_ZEROX2, 0, offset, 0, 0, channum, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while defining" & vbNewLine
            errstr = errstr & "the error on channel #" & channum & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        Call BTI1553_ErrorTagBC(1, BCMsgs(0), channum, hCore)
        Call BTI1553_ErrorCtrl(ERRCTRL1553_ON Or ERRCTRL1553_TAGMSG, channum, hCore)

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting the card")
            bSkipRun = True
            Exit Sub
        End If

        ' Update text
        DacText.Text = "Dac = " & dacval
        OffsetText.Text = "Offset = " & offset

        bCardRunning = True
        cmdStart.Enabled = False
        cmdStop.Enabled = True
        CmdUp.Enabled = True
        CmdDown.Enabled = True
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
        CmdUp.Enabled = False
        CmdDown.Enabled = False
        CmdLeft.Enabled = False
        CmdRight.Enabled = False

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
        Call BTI1553_ChStop(channum, hCore)

        ' Update the amplitude on the core
        errval = BTI1553_ParamAmplitudeConfig(PARAMCFG1553_DEFAULT, dacval, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error: can not update amplitude on core number #" & corenum)
            bSkipRun = True
            BTICard_CardStop(hCore)
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI1553_ChStart(channum, hCore)

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
        CmdLeft.Enabled = False
        CmdRight.Enabled = False

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If CBool(errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first 1553 channel that supports parametrics.
        For corenum = 0 To (MAX_CORES - 1)
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For channum = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI1553_ChIs1553(channum, hCore)) Then
                        If CBool(BTI1553_ChGetInfo(INFO1553_PARAM, channum, hCore)) Then
                            If CBool(BTI1553_ChGetInfo(INFO1553_ERRORGEN, channum, hCore)) Then
                                Exit For
                            End If
                        End If
                    End If
                Next
                If (corenum < MAX_CORES) And (channum < MAX_CHANNELS) Then
                    Exit For
                End If
            End If
        Next

        If (hCore = 0) Or (corenum = MAX_CORES) Or (channum = MAX_CHANNELS) Then
            MsgBox("Error:  No compatible MIL-STD-1553 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Channel.Text = "Using parametric channel #" & channum

        'Set flag so we run hardware
        bSkipRun = False

        cmdStart.Enabled = True
        cmdStop.Enabled = False

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
End Class