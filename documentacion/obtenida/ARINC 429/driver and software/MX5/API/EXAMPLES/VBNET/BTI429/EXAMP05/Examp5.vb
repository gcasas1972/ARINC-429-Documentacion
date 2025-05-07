Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI429 DRIVER VB_EXAMPLE 5  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP5 -- Transmit and Receive List buffer example
	'
	'  This program opens the Card Number 0, finds the first
	'  compatible core, and configures transmit and receive
	'  list buffers.  The program transmits one message filled
	'  with ramping data in the associated list buffer.  The
	'  receive list buffer is read and displays the data to the
	'  screen.
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
    Dim j As Integer
    Dim xmt_airspeed As BTI429VB.MSGSTRUCT429
    Dim rcv_airspeed As BTI429VB.MSGSTRUCT429
    Dim xmtlistaddr As UInteger
    Dim rcvlistaddr As UInteger

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

        ' Configure rcvchan for auto speed detection.
        ' Configure xmtchan to transmit at low speed with
        ' the selftest wrap-around enabled.

        BTICard_CardReset((hCore))

        'Configure channel
        errval = BTI429_ChConfig(CHCFG429_AUTOSPEED Or CHCFG429_SELFTEST, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        'Configure channel
        errval = BTI429_ChConfig(CHCFG429_SELFTEST, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring " & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Before any messages can be received, filters must be set
        ' for the receive channel.

        rcv_airspeed.addr = BTI429_FilterSet(MSGCRT429_DEFAULT, &O206S, SDIALL, rcvchan, hCore)

        ' Create a message for each of the labels we are transmitting.

        xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)

        ' Next, a schedule is built by creating explicit message timing.

        Call BTI429_SchedMsg(xmt_airspeed.addr, xmtchan, hCore)
        Call BTI429_SchedGap(1218, xmtchan, hCore)

        ' Create the transmit and receive list buffers.
        '
        ' The transmit list buffer will be a circular buffer,
        ' which means it should be pre-loaded with data, and
        ' it will continuously transmit that data.
        '
        ' The receive list buffer will be a FIFO, which we will
        ' read out of and display to the screen.

        xmtlistaddr = BTI429_ListXmtCreate(LISTCRT429_CIRCULAR, 256, xmt_airspeed.addr, hCore)
        rcvlistaddr = BTI429_ListRcvCreate(LISTCRT429_FIFO, 16, rcv_airspeed.addr, hCore)

        ' Initialize the transmit list buffer.

        For j = &H0S To &H1000000 Step &H10000
            Call BTI429_ListDataWr(CUInt(&H86S Or j), xmtlistaddr, hCore)
        Next

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting core #" & corenum)
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
            MsgBox("Error: Unable to open card number " & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first 429 core with both a receive and a transmit channel.
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If 0 <> BTI429_ChIsRcv(rcvchan, hCore) Then
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
		
		' Display data on the screen.
		rcv_airspeed.Data = BTI429_ListDataRd(rcvlistaddr, hCore)
		
        If 0 <> rcv_airspeed.data Then
            Label1.Text = "AirSpeed = " & Hex(rcv_airspeed.data) & " (Hex)"
        End If
		
	End Sub
End Class