Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI1553 DRIVER VB.NET BTI1553 EXAMPLE 10  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
    '  NAME:   EXAMP10 -- Polling the Event Log List
	'
	'  This example configures Card Number 0 as a bus controller
	'  to transmit a schedule of three messages.  The schedule is
	'  created in such a way that the messages are transmitted at
	'  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
	'  and 40ms, respectively).
	'
	'  The schedule is also configured to generate an Event Log List
	'  entry after each 10ms frame.  When an entry is read from the list,
	'  the data words associated with the 0843H BC-RT message is updated.
	'
	
	
	' Constants
    Const CARDNUM As Integer = 0
	Const MAX_CORES As Integer = 4
	Const MAX_CHANNELS As Integer = 16
	Const CMD0 As Short = &H843s
	Const CMD1 As Short = &H821s
	Const RCV_CMD2 As Short = &H821s
	Const XMT_CMD2 As Short = &H1C21s
	Const frametime As Integer = 10000
	
	' Card specific
    Dim hCard As UInteger
    Dim hCore As UInteger
	Dim corenum As Integer
	Dim channum As Integer
	Dim bSkipRun As Boolean
	Dim bCardRunning As Boolean
    Dim errval As Integer
	Dim errstr As String
	
	' Program specific
    Dim BCMsgs(2) As UInteger
    Dim Data(2) As UShort
    Dim msgtype As UShort
    Dim info As UInteger
	
	Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdExit.Click
		If (hCard >= 0) Then
            errval = BTICard_CardClose(hCard)
        End If

        ' End Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click

        If bSkipRun Then
            Exit Sub
        End If

        BTICard_CardReset((hCore))

        'Configure the channel for bus controller mode.
        errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while while configuring for bus controller mode")
            Exit Sub
        End If

        '  Create the message records for each of the three messages.
        Data(0) = 0
        Data(1) = 0
        Data(2) = 0

        BCMsgs(0) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, CMD0, 0, Data(0), hCore)
        BCMsgs(1) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, CMD1, 0, 0, hCore)
        BCMsgs(2) = BTI1553_BCCreateMsg(MSGCRT1553_RTRT, RCV_CMD2, XMT_CMD2, 0, hCore)

        '  Schedule the messages to create the desired bus controller
        '  schedule.  Also schedule an Event Log after each frame.
        '  Note the unique tag value associated with each Event Log
        '  that could be used to distinguish unique Events.
        Call BTI1553_BCSchedFrame(frametime, channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(2), channum, hCore)
        Call BTI1553_BCSchedLog(COND1553_ALWAYS, &H1111S, channum, hCore)

        Call BTI1553_BCSchedFrame(frametime, channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
        Call BTI1553_BCSchedLog(COND1553_ALWAYS, &H2222S, channum, hCore)

        Call BTI1553_BCSchedFrame(frametime, channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)
        Call BTI1553_BCSchedLog(COND1553_ALWAYS, &H3333S, channum, hCore)

        Call BTI1553_BCSchedFrame(frametime, channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
        Call BTI1553_BCSchedLog(COND1553_ALWAYS, &H4444S, channum, hCore)

        '  Configure the Event Log list.
        errval = BTICard_EventLogConfig(LOGCFG_ENABLE, 1024, hCore)
        If CBool(errval) Then
            errstr = "Error: An error was encountered while configuring the event log list."
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
        CmdStart.Enabled = False
        CmdStop.Enabled = True
        Result1.Text = ""

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
        Result1.Text = "Card Stopped"
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
        Result1.Text = "Card Stopped"

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If CBool(errval) Then
            errstr = "Error: Unable to open card number " & CARDNUM
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first 1553 core and channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For channum = 0 To MAX_CHANNELS - 1
                    If CBool(BTI1553_ChIs1553(channum, hCore)) Then
                        Exit For
                    End If
                Next
                If channum < MAX_CHANNELS Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (channum >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible MIL-STD-1553 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Channel.Text = "Using 1553 channel #" & channum

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
		
        If CBool(BTICard_EventLogRd(msgtype, info, msgChan, hCore)) Then
            Data(0) = CUShort(Data(0) + 2)
            Data(1) = CUShort(Data(1) + 4)
            Data(2) = CUShort(Data(2) + 6)

            Call BTI1553_MsgDataWr(Data(0), 3, BCMsgs(0), hCore)

            Result1.Text = "Transmitting data {" & Hex(Data(0)) & ", " & Hex(Data(1)) & ", " & Hex(Data(2)) & "}"
        End If
		
	End Sub
End Class