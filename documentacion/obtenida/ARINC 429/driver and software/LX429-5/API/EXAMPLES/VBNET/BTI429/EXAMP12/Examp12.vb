Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI429 DRIVER VB_EXAMPLE 12  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP12 -- IRIG Timer example.
	'
	'  This program opens Card Number 0, finds the first
	'  compatible core, and enable the IRIG timer. A transmit
	'  schedule is built using explicit message timing. The
	'  selftest wrap-around is enabled and filters are set to
	'  receive the messages. A timetag, minimum and maximum elapsed
	'  time for each message is converted from the IRIG time and
	'  displayed.
	'
	
	
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Dim bCardRunning As Boolean
    Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim rcvchan As Integer
    Dim xmtchan As Integer
    Dim rightnow As Date

    Dim xmt_airspeed As BTI429VB.MSGSTRUCT429
    Dim rcv_airspeed As BTI429VB.MSGSTRUCT429
    Dim airspeed_record As BTI429VB.MSGFIELDS429
    Dim irigtime As BTIIRIGTIME

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

        '  Configure rcvchan to receive at low speed with the
        '  Min/Max Elapse Time option also enabled.
        '  Note that the selftest wrap-around is also enabled.
        '
        '  Configure xmtchan to transmit at low speed.
        '  Note that the selftest wrap-around is also enabled.
        '  The external line drivers are disabled, and xmtchan is
        '  connected internally to all the receive channels.
        '

        BTICard_CardReset((hCore))

        'Configure receive channel
        errval = BTI429_ChConfig(CHCFG429_MAXMIN Or CHCFG429_SELFTEST, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        'Configure transmit channel
        errval = BTI429_ChConfig(CHCFG429_SELFTEST, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring " & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        '   Before any messages can be received, filters must be set
        '   for the receive channel.

        rcv_airspeed.addr = BTI429_FilterSet(MSGCRT429_DEFAULT, &O206S, SDIALL, rcvchan, hCore)

        '   Create a message for each of the labels we are transmitting.

        xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)

        '   Next, a schedule is built by creating explicit message timing.

        Call BTI429_SchedMsg(xmt_airspeed.addr, xmtchan, hCore)
        Call BTI429_SchedGap(1100, xmtchan, hCore)

        '   Those messages that are to be transmitted are initialized.

        Call BTI429_MsgDataWr(&H86S, xmt_airspeed.addr, hCore)

        '   Configure the IRIG timer. (DEFAULT -> bit rate = IRIGB, internal, slave/reciever)
        '   Sequential monitor will store IRIG time in sequential records

        errval = BTICard_IRIGConfig(IRIGCFG_DEFAULT, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring " & vbNewLine
            errstr = errstr & "the IRIG timer on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        '   Synchronize the on core IRIG timer with the computer local time

        rightnow = Now ' Now returns the current date/time.
        'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
        irigtime.days = CUShort(DateDiff(Microsoft.VisualBasic.DateInterval.Day, DateSerial(Year(rightnow), 1, 1), rightnow) + 1)
        irigtime.hours = CUShort(Hour(rightnow))
        irigtime.min = CUShort(Minute(rightnow))
        irigtime.sec = CUShort(Second(rightnow))
        irigtime.msec = 0 ' The Date structure does not include milliseconds.
        irigtime.usec = 0 ' The Date structure does not include microseconds.

        errval = BTICard_IRIGWr(irigtime, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while writing" & vbNewLine
            errstr = errstr & "the IRIG time on core #" & corenum
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

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first ARINC 429 core with both a receive and a transmit channel.
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If CBool(BTI429_ChIsRcv(rcvchan, hCore)) Then
                        For xmtchan = 0 To MAX_CHANNELS - 1
                            If CBool(BTI429_ChIsXmt(xmtchan, hCore)) Then
                                Exit For
                            End If
                        Next
                        If xmtchan < MAX_CHANNELS Then
                            Exit For
                        End If
                    End If
                Next
                If (rcvchan < MAX_CHANNELS) And (xmtchan < MAX_CHANNELS) Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Or (xmtchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 429 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If
        Core.Text = "Using core #" & corenum
        Receive.Text = "Using receive channel #" & rcvchan
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
		
		' Read the message record from the core
		Call BTI429_MsgBlockRd(airspeed_record, rcv_airspeed.addr, hCore)
		
		Dim tempstr As String
		
		' Format the time stamp
		tempstr = "TIME TAG ="
		tempstr = tempstr & " " & BTICard_IRIGFieldGetHours(airspeed_record.timetagh, airspeed_record.timetag_hitcount)
		tempstr = tempstr & ":" & BTICard_IRIGFieldGetMin(airspeed_record.timetagh, airspeed_record.timetag_hitcount)
		tempstr = tempstr & " " & BTICard_IRIGFieldGetSec(airspeed_record.timetagh, airspeed_record.timetag_hitcount)
		tempstr = tempstr & "." & BTICard_IRIGFieldGetMillisec(airspeed_record.timetagh, airspeed_record.timetag_hitcount)
		tempstr = tempstr & "." & BTICard_IRIGFieldGetMicrosec(airspeed_record.timetagh, airspeed_record.timetag_hitcount)
		TimeTag.Text = tempstr
		
		' Format the MIN time
		tempstr = "MIN ="
		tempstr = tempstr & " " & BTICard_IRIGFieldGetMillisec(0, airspeed_record.mintime)
		tempstr = tempstr & "ms"
		min_time.Text = tempstr
		
		' Format the MAX time
		tempstr = "Max ="
        tempstr = tempstr & " " & BTICard_IRIGFieldGetMillisec(0, airspeed_record.maxtime_elapsetime)
		tempstr = tempstr & "ms"
		max_time.Text = tempstr
		
	End Sub
End Class