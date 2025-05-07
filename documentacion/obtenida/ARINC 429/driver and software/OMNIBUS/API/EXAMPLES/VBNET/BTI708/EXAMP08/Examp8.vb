Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI429 DRIVER VB_EXAMPLE 8  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP8 -- IRIG Timer example.
	'
	'  This program opens Card Number 0, and configures the
	'  first compatible core to configure the first receive
	'  channel and the first transmit channel to operate on
    '  the self-test bus.  The transmitter is configured
	'  with 128 messages that are initialized with
	'  incrementing data.  The receive channel is configured
	'  to record it's data to the Sequential Monitor.
	'
    '  An Event Log frequency of 0 is specified, which will
    '  not generate any Event Log List entries for these channels.
	'
	'  The program will display the IRIG time and elapsed time from
	'  receive message structure 0.
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
    Dim timetagIsBCD As Boolean
    Dim temp As UInteger
    Dim Data(99) As UShort
    Dim rightnow As Date
    Dim irigtime As BTIIRIGTIME
    Dim msgfields As MSGFIELDS708
    Dim j As UShort
    Dim jj As UShort

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

        BTICard_CardReset((hCore))

        'Configure receive channel
        errval = BTI708_ChConfig(CHCFG708_ELAPSE Or CHCFG708_SELFTEST, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        'Configure transmit channel
        errval = BTI708_ChConfig(CHCFG708_SELFTEST, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring " & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        'Build the receive channel messages.
        errval = BTI708_RcvBuild(MSGCRT708_DEFAULT, 0, 1, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while building" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        'Build the transmit channel messages.
        errval = BTI708_XmtBuild(MSGCRT708_DEFAULT, 200, 0, 128, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while building" & vbNewLine
            errstr = errstr & "transmit channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If


        'Create and write the data for the messages.

        For j = 0 To 127 'Loop through all the messages
            For jj = 0 To 99
                Data(jj) = CUShort((j * 256) + jj)
            Next
            Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write data to the Device
        Next

        '   Configure the IRIG timer. (DEFAULT -> bit rate = IRIGB, internal, slave/reciever)
        '   Sequential monitor will store IRIG time in sequential records

        errval = BTICard_IRIGConfig(IRIGCFG_DEFAULT, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring " & vbNewLine
            errstr = errstr & "the IRIG timer on channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        If (TIMETAG_FORMAT_BCD = BTICard_TimerStatus(hCore)) Then
            timetagIsBCD = True
        Else
            timetagIsBCD = False
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

        'Initialize the msgfields structure
        For j = 0 To CUShort(msgfields.data.GetUpperBound(1))
            msgfields.data(j) = New UShort
        Next

        For j = 0 To CUShort(msgfields.extra.GetUpperBound(1))
            msgfields.extra(j) = New UShort
        Next

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first ARINC 708 core with both a receive and a transmit channel.
        For corenum = 0 To MAX_CORES
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If CBool(BTI708_ChIsRcv(rcvchan, hCore)) Then
                        For xmtchan = 0 To MAX_CHANNELS - 1
                            If CBool(BTI708_ChIsXmt(xmtchan, hCore)) Then
                                Exit For
                            End If
                        Next
                        If xmtchan <> MAX_CHANNELS - 1 Then
                            Exit For
                        End If
                    End If
                Next
                If (rcvchan <> MAX_CHANNELS - 1) And (xmtchan <> MAX_CHANNELS - 1) Then
                    Exit For
                End If
            End If
        Next

        If (hCore = 0) Or (corenum = MAX_CORES - 1) Or (rcvchan = MAX_CHANNELS - 1) Or (xmtchan = MAX_CHANNELS - 1) Then
            MsgBox("Error:  No compatible ARINC 708 core present in card #" & CARDNUM)
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
        Call BTI708_MsgBlockRd(msgfields, 0, rcvchan, hCore)

        If (False = timetagIsBCD) Then
            'Convert binary timetag to BCD
            BTICard_IRIGTimeBinToBCD(msgfields.timetagh, msgfields.timetag_hitcount, msgfields.timetagh, msgfields.timetag_hitcount)
            'Convert binary elapsetime to BCD
            BTICard_IRIGTimeBinToBCD(temp, msgfields.elapsetime_maxtime_mintime, temp, msgfields.elapsetime_maxtime_mintime)
        End If

        Dim tempstr As String

        ' Format the time stamp
        tempstr = "TIME TAG: "
        tempstr = tempstr & " " & BTICard_IRIGFieldGetHours(msgfields.timetagh, msgfields.timetag_hitcount)
        tempstr = tempstr & ":" & BTICard_IRIGFieldGetMin(msgfields.timetagh, msgfields.timetag_hitcount)
        tempstr = tempstr & " " & BTICard_IRIGFieldGetSec(msgfields.timetagh, msgfields.timetag_hitcount)
        tempstr = tempstr & "." & BTICard_IRIGFieldGetMillisec(msgfields.timetagh, msgfields.timetag_hitcount)
        tempstr = tempstr & "." & BTICard_IRIGFieldGetMicrosec(msgfields.timetagh, msgfields.timetag_hitcount)
        TimeTag.Text = tempstr

        ' Format the ELAPSE time
        tempstr = "ELAPSE TIME: "
        tempstr = tempstr & " " & BTICard_IRIGFieldGetMillisec(0, msgfields.elapsetime_maxtime_mintime)
        tempstr = tempstr & "ms"
        ElapaseTime.Text = tempstr

    End Sub
End Class