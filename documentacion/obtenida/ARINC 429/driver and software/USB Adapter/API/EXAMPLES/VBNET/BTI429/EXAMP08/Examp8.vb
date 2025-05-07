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
	'  NAME:   EXAMP8 -- Polling the Event Log List
	'
	'  This program opens Card Number 0, finds the first
	'  compatible core, and configures the first receive
	'  channel to receive 2 GPS messages into separate
	'  Message Records, and receive all other messages
	'  into a default Message Record.
	'
	'  Each of the messages is also configured to generate an
	'  Event Log List entry.  When an entry is read from the list,
	'  the associated data is read.
	'
	
	
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim corenum As Integer
    Dim bSkipRun As Boolean
    Dim bCardRunning As Boolean
    Dim errval As Integer
    Dim errstr As String
    Dim rcvchan As Integer
    Dim msgType As UShort
    Dim msgInfo As UInteger
    Dim msgaddr As UInteger
    Dim msgdefault As BTI429VB.MSGSTRUCT429
    Dim Latitude As BTI429VB.MSGSTRUCT429
    Dim Longitude As BTI429VB.MSGSTRUCT429

    Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        If (hCard >= 0) Then
            errval = BTICard_CardClose(hCard)
        End If

        ' End Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click

        If (bSkipRun = True) Then
            Exit Sub
        End If

        'Configure receiver channel for auto speed detection.
        BTICard_CardReset((hCore))
        errval = BTI429_ChConfig(CHCFG429_AUTOSPEED, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Before any messages can be received, filters must be set
        ' for the receive channel.  First, the default filter is
        ' created.  Then, two filters are set for the two messages
        ' of interest.
        '
        ' Each message is configured to create Event Log list entries.
        '

        msgdefault.addr = BTI429_FilterDefault(MSGCRT429_LOG, rcvchan, hCore)
        Latitude.addr = BTI429_FilterSet(MSGCRT429_LOG, &O310S, SDIALL, rcvchan, hCore)
        Longitude.addr = BTI429_FilterSet(MSGCRT429_LOG, &O311S, SDIALL, rcvchan, hCore)

        ' Init data values to zero.
        msgdefault.data = 0
        Latitude.data = 0
        Longitude.data = 0

        ' Configure the Event Log list.
        errval = BTICard_EventLogConfig(LOGCFG_ENABLE, 1024, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the event log list on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

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

    Private Sub CmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStop.Click
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

        ' Find the first 429 core with a receive channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If 0 <> BTI429_ChIsRcv(rcvchan, hCore) Then
                        Exit For
                    End If
                Next
                If rcvchan < MAX_CHANNELS Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 429 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Receive.Text = "Using receive channel #" & rcvchan

        'Set flag so we run hardware
        bSkipRun = False

        CmdStart.Enabled = True
        CmdStop.Enabled = False

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		' Read data from card
		Dim msgChan As Integer
		
        If 0 <> BTICard_EventLogRd(msgType, msgInfo, msgChan, hCore) Then
            msgaddr = msgInfo

            If msgaddr = msgdefault.addr Then
                msgdefault.data = BTI429_MsgDataRd(msgaddr, hCore)
            ElseIf msgaddr = Latitude.addr Then
                Latitude.data = BTI429_MsgDataRd(msgaddr, hCore)
            ElseIf msgaddr = Longitude.addr Then
                Longitude.data = BTI429_MsgDataRd(msgaddr, hCore)
            End If

            ' Write data to form
            Line1.Text = "Default= " & Hex(msgdefault.data) & " (Hex)"
            Line2.Text = "Latitude= " & Hex(Latitude.data) & " (Hex)"
            Line3.Text = "Longitude= " & Hex(Longitude.data) & " (Hex)"

        End If
		
	End Sub
End Class