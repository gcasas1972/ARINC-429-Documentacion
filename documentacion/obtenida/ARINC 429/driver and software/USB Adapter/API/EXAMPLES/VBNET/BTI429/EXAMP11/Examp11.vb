Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI429 DRIVER VB_EXAMPLE 11  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP11 -- Parametrics example
	'
	'  This program opens Card Number 0, and configures the
	'  first transmit channel on the first 429 Core to build
	'  a transmit schedule using transmit interval information.
	'  The user can then control the amplitude using the UP and
	'  DOWN arrow buttons and the frequency using the LEFT and RIGHT
	'  arrow buttons.
	'
	
	
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Const DAC_HIGH As Short = &HFFFS
    Const DAC_LOW As Short = &H599S
    Const DIV_HIGH As Short = &HFFS
    Const DIV_LOW As Short = &H0S

    Dim bCardRunning As Boolean
    Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim xmtchan As Integer
    Dim comp_airspeed As BTI429VB.MSGSTRUCT429
    Dim tot_air_temp As BTI429VB.MSGSTRUCT429
    Dim altitude_rate As BTI429VB.MSGSTRUCT429
    Dim msgaddr(2) As UInteger
    Dim min_intrvls(2) As Integer
    Dim max_intrvls(2) As Integer
    Dim bnr_data(2) As UInteger
    Dim dacval As UShort
    Dim divval As UShort

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
        Call BTI429_ChStop(xmtchan, hCore)

        ' Update the amplitude on the core
        errval = BTI429_ParamAmplitudeConfig(PARAMCFG429_DEFAULT, dacval, xmtchan, hCore)
        If (errval < 0) Then
            MsgBox("Error: can not update amplitude on core number #" & corenum)
            bSkipRun = True
            BTICard_CardStop(hCore)
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI429_ChStart(xmtchan, hCore)

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
        divval = CUShort(divval - 1)
        If (divval < DIV_LOW) Then
            divval = DIV_LOW
        End If

        ' Temporaraly Stop the transmit channel
        Call BTI429_ChStop(xmtchan, hCore)

        ' Update the frequency on the core
        errval = BTI429_ParamBitRateConfig(PARAMCFG429_DEFAULT, divval, xmtchan, hCore)
        If (errval < 0) Then
            MsgBox("Error: can not update frequency on core number #" & corenum)
            bSkipRun = True
            BTICard_CardStop(hCore)
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI429_ChStart(xmtchan, hCore)

        ' Update text
        DivText.Text = "Div = " & divval

    End Sub

    Private Sub CmdRight_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdRight.Click
        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        ' Increment bitrate
        divval = CUShort(divval + 1)
        If (divval > DIV_HIGH) Then
            divval = DIV_HIGH
        End If

        ' Temporaraly Stop the transmit channel
        Call BTI429_ChStop(xmtchan, hCore)

        ' Update the frequency on the core
        errval = BTI429_ParamBitRateConfig(PARAMCFG429_DEFAULT, divval, xmtchan, hCore)
        If (errval < 0) Then
            MsgBox("Error: can not update frequency on core number #" & corenum)
            bSkipRun = True
            BTICard_CardStop(hCore)
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI429_ChStart(xmtchan, hCore)

        ' Update text
        DivText.Text = "Div = " & divval

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
        errval = BTI429_ChConfig(CHCFG429_HIGHSPEED, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        '
        '  Configure Parametrics on xmtchan
        '

        If (dacval > DAC_HIGH) Then
            dacval = DAC_HIGH
        ElseIf (dacval < DAC_LOW) Then
            dacval = DAC_LOW
        End If

        errval = BTI429_ParamAmplitudeConfig(PARAMCFG429_DEFAULT, dacval, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the amplitude on channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        If (divval > DIV_HIGH) Then
            divval = DIV_HIGH
        ElseIf (divval < DIV_LOW) Then
            divval = DIV_LOW
        End If

        ' TODO: check with Jon about this configval??????!
        errval = BTI429_ParamBitRateConfig(PARAMCFG429_DEFAULT, divval, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the bit rate on channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Create a message for each of the labels we are transmitting.
        comp_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
        tot_air_temp.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
        altitude_rate.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)

        ' Setup the arrays of message addresses, and intervals
        ' needed to build the schedule.  Note that the nth element
        ' in each array correspond to eachother.
        msgaddr(0) = comp_airspeed.addr
        min_intrvls(0) = 250
        max_intrvls(0) = 500

        msgaddr(1) = tot_air_temp.addr
        min_intrvls(1) = 250
        max_intrvls(1) = 500

        msgaddr(2) = altitude_rate.addr
        min_intrvls(2) = 100
        max_intrvls(2) = 200

        ' Next, build a schedule using the minimum and maximum
        ' transmit intervals.
        errval = BTI429_SchedBuild(3, msgaddr(0), min_intrvls(0), max_intrvls(0), xmtchan, hCore)
        If (errval < 0) Then
            MsgBox("Error:  BTI429_SchedBuild failed on channel #" & xmtchan & "on core #" & corenum & ".")
            bSkipRun = True
            Exit Sub
        End If

        ' Initialize the three Message Records.
        comp_airspeed.data = BTI429_FldPutLabel(0, &O206S) '/*Init label field*/
        tot_air_temp.data = BTI429_FldPutLabel(0, &O211S)
        altitude_rate.data = BTI429_FldPutLabel(0, &O212S)

        comp_airspeed.data = BTI429_BNRPutMant(comp_airspeed.data, 0, 14, 0) '/*Init BNR data*/
        tot_air_temp.data = BTI429_BNRPutMant(tot_air_temp.data, 0, 11, 0)
        altitude_rate.data = BTI429_BNRPutMant(altitude_rate.data, 0, 16, 0)

        Call BTI429_MsgDataWr(comp_airspeed.data, comp_airspeed.addr, hCore)
        Call BTI429_MsgDataWr(tot_air_temp.data, tot_air_temp.addr, hCore)
        Call BTI429_MsgDataWr(altitude_rate.data, altitude_rate.addr, hCore)

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting the card")
            bSkipRun = True
            Exit Sub
        End If

        ' Update text
        DacText.Text = "Dac = " & dacval
        DivText.Text = "Div = " & divval

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
        Call BTI429_ChStop(xmtchan, hCore)

        ' Update the amplitude on the core
        errval = BTI429_ParamAmplitudeConfig(PARAMCFG429_DEFAULT, dacval, xmtchan, hCore)
        If (errval < 0) Then
            MsgBox("Error: can not update amplitude on core number #" & corenum)
            bSkipRun = True
            BTICard_CardStop(hCore)
            Exit Sub
        End If

        ' Start the transmit channel
        Call BTI429_ChStart(xmtchan, hCore)

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
        If (0 <> errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first 429 core with a transmit channel that supports parametrics.
        For corenum = 0 To (MAX_CORES - 1)
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For xmtchan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI429_ChIsXmt(xmtchan, hCore)) Then
                        If (BTI429_ChGetInfo(INFO429_PARAM, xmtchan, hCore) > 0) Then
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
            MsgBox("Error:  No compatible ARINC 429 core present in card #" & CARDNUM)
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
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		'
		' Update values in messages
		'
		
		comp_airspeed.Data = BTI429_MsgDataRd(comp_airspeed.addr, hCore) ' Read messages back
		tot_air_temp.Data = BTI429_MsgDataRd(tot_air_temp.addr, hCore)
		altitude_rate.Data = BTI429_MsgDataRd(altitude_rate.addr, hCore)
		
		bnr_data(0) = BTI429_BNRGetMant(comp_airspeed.Data, 14) 'Extract BNR data
		bnr_data(1) = BTI429_BNRGetMant(tot_air_temp.Data, 11)
		bnr_data(2) = BTI429_BNRGetMant(altitude_rate.Data, 16)
		
        bnr_data(0) = CUInt(bnr_data(0) + 1) ' Change BNR data
        bnr_data(1) = CUInt(bnr_data(1) + 1)
        bnr_data(2) = CUInt(bnr_data(2) + 1)
		
		comp_airspeed.Data = BTI429_BNRPutMant(comp_airspeed.Data, bnr_data(0), 14, 0) ' Put BNR data
		tot_air_temp.Data = BTI429_BNRPutMant(tot_air_temp.Data, bnr_data(1), 11, 0) ' back into
		altitude_rate.Data = BTI429_BNRPutMant(altitude_rate.Data, bnr_data(2), 16, 0) ' messages
		
		Call BTI429_MsgDataWr(comp_airspeed.Data, comp_airspeed.addr, hCore) ' Write new message values
		Call BTI429_MsgDataWr(tot_air_temp.Data, tot_air_temp.addr, hCore)
		Call BTI429_MsgDataWr(altitude_rate.Data, altitude_rate.addr, hCore)
		
	End Sub
End Class