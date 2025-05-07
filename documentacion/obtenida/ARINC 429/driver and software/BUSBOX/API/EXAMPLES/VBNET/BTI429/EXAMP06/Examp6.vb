Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI429 DRIVER VB_EXAMPLE 6  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP6 -- Asynchronous List Buffer Example
	'
	'  This program opens the Card Number 0, finds the first
	'  compatible core, and configures an asynchronous transmit
	'  list buffer. The program transmits one label synchronoulsy
	'  in a schedule, and transmits another label each time the
	'  transmit button is hit by the user.
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
    Dim xmtstat As Boolean
    Dim xmtcount As Integer
    Dim xmt_airspeed As BTI429VB.MSGSTRUCT429
    Dim asynclistaddr As UInteger

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

        ' Reset counter

        xmtcount = 0

        ' Configure xmtchan to transmit at low speed.

        BTICard_CardReset((hCore))
        errval = BTI429_ChConfig(CHCFG429_DEFAULT, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Create a message for each the synchronous label we are transmitting.
        xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)

        ' Create the asynchronous list buffer.
        asynclistaddr = BTI429_ListAsyncCreate(LISTCRT429_FIFO, 16, xmtchan, hCore)

        '  Next, a schedule is built by creating explicit message timing.
        '  While creating a schedule we can still use the SchedGap() funciton
        '  to create our gap times.  This function will determine that an
        '  asynchronous list buffer has been created for the channel, and will
        '  internally call the SchedGapList() function with appropriate parameters.
        '  Alternatively, we could use the SchedGapList() function directly
        '  and specify the address value ourselves. This method is usefull if
        '  more than one asynchronoous list buffer is desired per channel.
        Call BTI429_SchedMsg(xmt_airspeed.addr, xmtchan, hCore)
        Call BTI429_SchedGap(1218, xmtchan, hCore)

        ' The synchronous message needs to be initialized.
        Call BTI429_MsgDataWr(&H86S, xmt_airspeed.addr, hCore)

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while starting core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        bCardRunning = True
        cmdStart.Enabled = False
        cmdStop.Enabled = True
        CmdTx.Enabled = True

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
        CmdTx.Enabled = False

    End Sub

    Private Sub CmdTx_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdTx.Click
        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        xmtstat = CBool(BTI429_ListDataWr(&H8AS, asynclistaddr, hCore))

        If xmtstat Then
            xmtcount = xmtcount + 1
        End If

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
        CmdTx.Enabled = False

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            errstr = "Error: Unable to open card number " & CARDNUM
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first 429 core with a transmit channel
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

        'Set flag so we run hardware
        bSkipRun = False

        cmdStart.Enabled = True
        cmdStop.Enabled = False
        CmdTx.Enabled = False

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		' Display data on the screen.
		Label1.Text = "Asynchronous transmission count: " & xmtcount
		
	End Sub
End Class