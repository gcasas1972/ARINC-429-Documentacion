Option Strict Off
Option Explicit On

Imports System.Runtime.InteropServices

Friend Class Form1
    Inherits System.Windows.Forms.Form
    '
    '  BTI1553 DRIVER VB.NET EXAMPLE 5  (06/07/2011)
    '  Copyright (c) 2009-2011
    '  Ballard Technology, Inc.
    '  www.ballardtech.com
    '  support@ballardtech.com
    '  ALL RIGHTS RESERVED
    '
    '  NAME:   EXAMP5 -- Simultaneous BC, RT, and monitor simulation
    '
    '  This example requires a Ballard 1553 C version Device or higher.
    '  This program opens Card Number 0, finds the first
    '  compatible core, configures a BC, an RT, and a Bus Monitor.
    '  The BC transmits one BC-RT message (command word 0843H).
    '  The RT is configured with terminal address 1, so the
    '  simulated RT receives the simulated BC's transmissions.
    '  The data word transmitted by the RT are incremented and
    '  displayed.  The data words received by the RT are read and
    '  also displayed.
    '

    ' Constants
    Const CARDNUM As Integer = 0
    Const FRAMETIME As UInteger = 10000

    ' Card specific
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim bSkipRun As Boolean
    Dim bCardRunning As Boolean
    Dim errval As Integer
    Dim channum As Integer
    Dim corenum As Integer

    ' Program specific
    Dim BCMsg As UInteger
    Dim RTMsg As UInteger
    Dim BCData(2) As UShort
    Dim RTData(2) As UShort

    Dim pRec1553 As BTICARDVB.SEQRECORD1553
    Dim seqbuf(2047) As UShort
    Dim seqcount As Integer
    Dim sfinfo As BTICARDVB.SEQFINDINFO
    Dim moncount As Short

    Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdExit.Click
        If (hCard >= 0) Then
            BTICard_CardStop(hCard)
            errval = BTICard_CardClose(hCard)
        End If

        ' End The Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click

        If bSkipRun Then
            Exit Sub
        End If

        ' Configure the channel for bus controller mode
        BTICard_CardReset(hCard)
        errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while while configuring for bus controller mode")
            bSkipRun = True
            Exit Sub
        End If

        '  Create a bus controller message and insert into the bus
        '  controller schedule.
        BCMsg = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, &H843S, 0, BCData(0), hCore)

        Call BTI1553_BCSchedFrame(FRAMETIME, channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsg, channum, hCore)

        '  Configure the channel for remote terminal mode as shown in Example 3.
        errval = BTI1553_RTConfig(RTCFG1553_DEFAULT, 1, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while while configuring for remote terminal mode")
            bSkipRun = True
            Exit Sub
        End If

        ' Get the message address for a receive subaddress.
        RTMsg = BTI1553_RTGetMsg(SUBADDRESS, 1, RCV, 2, channum, hCore)

        'Monitor RT address 1 only
        Call BTI1553_MonFilterTA(2, channum, hCore)

        ' Configure the channel for monitor mode as shown in Example 4.
        errval = BTI1553_MonConfig(MONCFG1553_DEFAULT, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while while configuring for monitor mode")
            bSkipRun = True
            Exit Sub
        End If

        ' Configure the sequential record.
        errval = BTICard_SeqConfig(SEQCFG_DEFAULT, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while while configuring the sequential record")
            bSkipRun = True
            Exit Sub
        End If

        ListBox1.Items.Clear()
        moncount = 0

        ' Initialize the data arrays
        BCData(0) = 0
        BCData(1) = 0
        BCData(2) = 0
        RTData(0) = 0
        RTData(1) = 0
        RTData(2) = 0

        ' Start operation of the card.
        errval = BTICard_CardStart(hCard)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting the card")
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
            BTICard_CardStop(hCard)
        End If

        CmdStart.Enabled = True
        CmdStop.Enabled = False
        Result1.Text = "Card Stopped"
        Result2.Text = "Ready..."
    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim rcvchan As Integer
        On Error GoTo Errhandler

        CoreLbl.Text = "Core:"
        ChanLbl.Text = "Channel:"

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        CmdStart.Enabled = False
        CmdStop.Enabled = False
        CmdAssync.Enabled = False
        bSkipRun = False
        bCardRunning = False
        Result1.Text = "Card Stopped"
        Result2.Text = ""

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            MsgBox("Unable to open card number " & CStr(CARDNUM), MsgBoxStyle.Exclamation, "Error")
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first MIL-STD-1553 core and C or D version channel.

        For corenum = 0 To 4 Step 1
            ' Open a handle to the core
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If (0 <> errval) Then
                ChanLbl.Text = "No 1553 C or D version channels found."
                bSkipRun = True
                Exit Sub
            End If

            ' Find the first 1553 C or D version channel.
            For channum = 0 To 8 Step 1
                If 0 <> BTI1553_ChIs1553(channum, hCore) Then
                    Exit For
                End If
            Next

            If 0 <> BTI1553_ChIsC(channum, hCore) Then
                ChanLbl.Text = "Using 1553 C version channel #" & CStr(channum)
                CoreLbl.Text = "Using Core number #" & CStr(corenum)
                Exit For
            ElseIf 0 <> BTI1553_ChIsD(channum, hCore) Then
                ChanLbl.Text = "Using 1553 D version channel #" & CStr(channum)
                CoreLbl.Text = "Using Core number #" & CStr(corenum)
                Exit For
            Else
                ChanLbl.Text = "No 1553 C or D version channels found."
                MsgBox("Error:  Example required a 1553 C or D version channel")
                bSkipRun = True
                Exit Sub
            End If
        Next

        'Set flag so we run hardware
        bSkipRun = False

        Result2.Text = "Ready..."

        CmdStart.Enabled = True
        CmdStop.Enabled = False
        CmdAssync.Enabled = True
        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub

    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        ' Update the data that the BC is transmitting
        BCData(0) = BCData(0) + CType(2, UShort)
        BCData(1) = BCData(1) + CType(4, UShort)
        BCData(2) = BCData(2) + CType(6, UShort)

        ' Update the output fields for user
        Result1.Text = "Transmitting data {" & Hex(BCData(0)) & ", " & Hex(BCData(1)) & ", " & Hex(BCData(2)) & "}"

        ' Write new data to the message buffer
        Call BTI1553_MsgDataWr(BCData(0), 3, BCMsg, hCard)

        ' Read the data received by the RT
        Call BTI1553_MsgDataRd(RTData(0), 3, RTMsg, hCard)

        ' Update the output fields for user
        Result2.Text = "Received data {" & Hex(RTData(0)) & ", " & Hex(RTData(1)) & ", " & Hex(RTData(2)) & "}"

        '
        ' Monitor Dump
        '

        ' Display data on the screen.
        seqcount = BTICard_SeqRd(seqbuf(0), hCard)
        If (0 = seqcount) Then
            Exit Sub
        End If

        errval = BTICard_SeqFindInit(seqbuf(0), seqcount, sfinfo)
        If (0 > errval) Then
            MsgBox("Error: SeqFindInit failed")
            bSkipRun = True
            Exit Sub
        End If

        ' Add each 1553Record in SeqBuf to ListBox1
        While (0 <= BTICard_SeqFindNext1553Ex(pRec1553, CUShort(Marshal.SizeOf(pRec1553)), sfinfo))
            Dim str As String
            Dim recChanNum As Integer = 0

            'Inc the record number
            moncount = moncount + CType(1, Short)

            'Calc the Chan number
            recChanNum = CType(pRec1553.activity, Integer) And CType(MSGACT1553_CHMASK, Integer)
            recChanNum = ShiftRight(recChanNum, MSGACT1553_CHSHIFT)

            ' Format the output string
            str = "Rec:" & CStr(moncount)
            'str = str & "  Ch:" & CStr(recChanNum)
            str = str & "  Time:" & CStr(pRec1553.timestamp) & " (Hex)"

            If (0 <> (pRec1553.activity And MSGACT1553_RCVCWD1)) Or (0 <> (pRec1553.activity And MSGACT1553_XMTCWD1)) Then
                str = str & "  Cwd1:" & Hex(pRec1553.cwd1)
            End If
            If (0 <> (pRec1553.activity And MSGACT1553_RCVCWD2)) Or (0 <> (pRec1553.activity And MSGACT1553_XMTCWD2)) Then
                str = str & "  Cwd2:" & Hex(pRec1553.cwd2)
            End If
            If (0 <> (pRec1553.activity And MSGACT1553_RCVSWD1)) Or (0 <> (pRec1553.activity And MSGACT1553_XMTSWD1)) Then
                str = str & "  Swd1:" & Hex(pRec1553.swd1)
            End If
            If (0 <> (pRec1553.activity And MSGACT1553_RCVSWD2)) Or (0 <> (pRec1553.activity And MSGACT1553_XMTSWD2)) Then
                str = str & "  Swd2:" & Hex(pRec1553.swd2)
            End If
            If (0 <> (pRec1553.errorval And MSGERR1553_NORESP)) Then
                str = str & "  No response!"
            End If
            If (0 <> (pRec1553.errorval And MSGERR1553_ANYERR)) Then
                str = str & "  Error!"
            End If

            ' Output the result
            ListBox1.Items.Add(str)

        End While

    End Sub

    Private Sub CmdAssync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAssync.Click
        Const WORDCOUNT As Integer = 3
        Dim Msg As BTI1553VB.XMITFIELDS1553 = New BTI1553VB.XMITFIELDS1553

        Msg.ctrlflags = MSGCRT1553_BCRT
        Msg.cwd1 = BTI1553_ValPackCWD(1, 0, 3, WORDCOUNT)

        'Both of the following work the same
        'ReDim Msg.data(0 To 31)
        Msg.data = New UShort(31) {}

        For i As UShort = 0 To (WORDCOUNT - 1)
            Msg.data(i) = i
        Next

        If bCardRunning Then
            '  Card is already running so just send the message
            BTI1553_BCTransmitMsg(Msg, channum, hCard)
        Else
            '  When not running create an empty frame in the BC Schedule.
            '
            '  BTI1553_BCTransmitMsg uses an asynchronous Message Record
            '  that is transmitted at the end of every frame.  Therefore,
            '  even though we aren't scheduling messages, we must still
            '  schedule a frame.

            BTICard_CardReset(hCard)
            BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
            BTI1553_BCSchedFrame(1000, channum, hCore)

            '  Temporarily start the card for the BCTransmitMsg
            BTICard_CardStart(hCard)

            '  Send the message
            errval = BTI1553_BCTransmitMsg(Msg, channum, hCard)
            If (errval < 0) Then
                MsgBox("Error:  An error was encountered while calling BTI1553_BCTransmitMsg(...)")
            End If

            '  Stop the card
            BTICard_CardStop(hCard)
        End If
    End Sub
End Class