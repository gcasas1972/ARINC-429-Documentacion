Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI429 DRIVER VB_EXAMPLE 2  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP2 -- Transmitter example
	'
	'  This program opens Card Number 0, and configures the
	'  first compatible core to build a transmit schedule
	'  using transmit interval information, and then transmit
	'  the messages with changing data.
	'
	
	
    Const CARDNUM As Integer = 0
	Const MAX_CORES As Integer = 4
	Const MAX_CHANNELS As Integer = 16
	
	Dim bCardRunning As Boolean
	Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCore As UInteger
	Dim corenum As Integer
	Dim errstr As String
    Dim errval As Integer
    Dim xmtchan As Integer
    Dim comp_airspeed As BTI429VB.MSGSTRUCT429
    Dim tot_air_temp As BTI429VB.MSGSTRUCT429
    Dim altitude_rate As BTI429VB.MSGSTRUCT429
    Dim msgaddr(2) As UInteger
    Dim min_intrvls(2) As Integer
    Dim max_intrvls(2) As Integer
    Dim bnr_data(2) As UInteger

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        If (hCard >= 0) Then
            errval = BTICard_CardClose(hCard)
        End If

        ' End Program
        End

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

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            errstr = "Error: Unable to open card number " & CARDNUM
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first ARINC 429 core with a transmit channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For xmtchan = 0 To MAX_CHANNELS - 1
                    If 0 <> BTI429_ChIsXmt(xmtchan, hCore) Then
                        Exit For
                    End If
                Next
                If xmtchan < MAX_CHANNELS Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (xmtchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 429 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Transmit.Text = "Using transmit channel #" & xmtchan
        airspeed.Text = "comp_airspeed = "
        temp.Text = "tot_air_temp  = "
        altitude.Text = "altitude_rate = "

        'Set flag so we run hardware
        bSkipRun = False

        CmdStart.Enabled = True
        CmdStop.Enabled = False

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub

    Private Sub cmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStop.Click
        'Clear state of bRunning before card is stopped (so timer event is not processed)
        Dim bTemp As Boolean
        bTemp = bCardRunning
        bCardRunning = False

        If (bTemp = True) Then
            BTICard_CardStop(hCore)
        End If

        CmdStart.Enabled = True
        CmdStop.Enabled = False

    End Sub

    Private Sub cmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click

        If (bSkipRun = True) Then
            Exit Sub
        End If

        ' Configure xmtchan to transmit at high speed.
        BTICard_CardReset((hCore))
        errval = BTI429_ChConfig(CHCFG429_HIGHSPEED, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
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
            MsgBox("Error:  BTI429_SchedBuild failed.")
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
            errstr = "Error:  An error was encountered while starting core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        bCardRunning = True
        CmdStart.Enabled = False
        CmdStop.Enabled = True

    End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		'
		' Change data
		'
		
		' Read messages back
		comp_airspeed.Data = BTI429_MsgDataRd(comp_airspeed.addr, hCore)
		tot_air_temp.Data = BTI429_MsgDataRd(tot_air_temp.addr, hCore)
		altitude_rate.Data = BTI429_MsgDataRd(altitude_rate.addr, hCore)
		
		' Extract BNR data
		bnr_data(0) = BTI429_BNRGetMant(comp_airspeed.Data, 14)
		bnr_data(1) = BTI429_BNRGetMant(tot_air_temp.Data, 11)
		bnr_data(2) = BTI429_BNRGetMant(altitude_rate.Data, 16)
		
		' Change BNR data
        bnr_data(0) = CUInt(bnr_data(0) + 1)
        bnr_data(1) = CUInt(bnr_data(1) + 1)
        bnr_data(2) = CUInt(bnr_data(2) + 1)
		
		' Put BNR data back into messages
		comp_airspeed.Data = BTI429_BNRPutMant(comp_airspeed.Data, bnr_data(0), 14, 0)
		tot_air_temp.Data = BTI429_BNRPutMant(tot_air_temp.Data, bnr_data(1), 11, 0)
		altitude_rate.Data = BTI429_BNRPutMant(altitude_rate.Data, bnr_data(2), 16, 0)
		
		' Write new message values
		Call BTI429_MsgDataWr(comp_airspeed.Data, comp_airspeed.addr, hCore)
		Call BTI429_MsgDataWr(tot_air_temp.Data, tot_air_temp.addr, hCore)
		Call BTI429_MsgDataWr(altitude_rate.Data, altitude_rate.addr, hCore)
		
		' Display new values on form
		airspeed.Text = "comp_airspeed = " & Hex(comp_airspeed.Data) & " (Hex)"
		temp.Text = "tot_air_temp  = " & Hex(tot_air_temp.Data) & " (Hex)"
		altitude.Text = "altitude_rate = " & Hex(altitude_rate.Data) & " (Hex)"
		
	End Sub
End Class