Option Strict On
Option Explicit On

Friend Class Form1
    Inherits System.Windows.Forms.Form

    '
    '  BTI708 DRIVER VB_EXAMPLE 1  (06/07/2011)
    '  Copyright (c) 2009-2011
    '  Ballard Technology, Inc.
    '  www.ballardtech.com
    '  support@ballardtech.com
    '  ALL RIGHTS RESERVED
    '
    '  NAME:   EXAMP1 -- Transmitter example
    '
    '  This program opens Card Number 0, and configures the
    '  first transmit channel to transmit a sequence of 32
    '  messages at a rate of 200Hz.  The messages are
    '  automatically assigned the numbers 0 through 31.
    '
    '  An Event Log frequency of 16 is specified, which will
    '  cause the channel to issue an Event Log List entry
    '  every 16th message (message numbers 15, and 31).
    '  The program uses these events to update the data for
    '  the half of messages that were just transmitted.
    '

    ' Constants
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16
    Const FRAMEFREQ As Short = 200 ' Frame frequency of 200Hz
    Const LOGFREQ As Short = 16 ' Generate a Log Event after every 16th message
    Const FRAMECOUNT As UShort = 32 ' Transmit a total of 32 messages

    ' Card specific
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim bCardRunning As Boolean
    Dim bSkipRun As Boolean

    ' Program specific
    Dim xmtchan As Integer
    Dim Data(99) As UShort
    Dim txCount As UShort
    Dim j As UShort
    Dim jj As Short

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

        ' Configure transmit channel.
        BTICard_CardReset((hCore))
        errval = BTI708_ChConfig(CHCFG708_DEFAULT, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Build the transmit channel messages.
        errval = BTI708_XmtBuild(MSGCRT708_DEFAULT, FRAMEFREQ, LOGFREQ, FRAMECOUNT, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while building" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Create and write the data for the messages.
        For j = 0 To (FRAMECOUNT - 1) Step 1 ' Loop through all the messages
            For jj = 0 To 99 Step 1
                Data(jj) = j + (txCount * FRAMECOUNT)
            Next
            Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) ' Write data to the Device
        Next
        txCount = CUShort(txCount + 1)

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
        Result1.Text = "Transmitting data"

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
        Result2.Text = ""
    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Errhandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        CmdStart.Enabled = False
        CmdStop.Enabled = False
        bSkipRun = False
        bCardRunning = False
        Result1.Text = "Card Stopped"
        Result2.Text = ""

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            errstr = "Error: Unable to open card number " & CARDNUM
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first ARINC 708 core with a transmit channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For xmtchan = 0 To MAX_CHANNELS - 1
                    If 0 <> BTI708_ChIsXmt(xmtchan, hCore) Then
                        Exit For
                    End If
                Next
                If xmtchan < MAX_CHANNELS Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (xmtchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 708 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        ChanLbl.Text = "Using ARINC 708 transmit channel #" & xmtchan

        'Set flag so we run hardware
        bSkipRun = False

        CmdStart.Enabled = True
        CmdStop.Enabled = False
        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub

    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Dim eventType As UShort
        Dim info As UInteger
        Dim logchan As Integer
        Dim framenum As UInteger
        Dim j As UShort
        Dim jj As Integer

        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        '
        ' Read entry from Event Log list
        '

        If 0 <> BTICard_EventLogRd(eventType, info, logchan, hCore) Then
            framenum = info

            If framenum = ((FRAMECOUNT / 2) - 1) Then 'First half transmitted
                Result2.Text = "Updating frames 0 - " & framenum
                For j = 0 To CInt(((FRAMECOUNT / 2) - 1)) Step 1
                    For jj = 0 To 99 Step 1
                        Data(jj) = j + (txCount * FRAMECOUNT)
                    Next
                    Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore)
                Next
            ElseIf framenum = (FRAMECOUNT - 1) Then  'Second half transmitted
                Result2.Text = "Updating frames " & (FRAMECOUNT / 2) & " - " & framenum
                For j = CUShort((FRAMECOUNT / 2)) To CUShort(framenum) Step 1
                    For jj = 0 To 99 Step 1
                        Data(jj) = j + (txCount * FRAMECOUNT)
                    Next
                    Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore)
                Next
                txCount = CUShort(txCount + 1)
            End If
        End If

    End Sub
End Class