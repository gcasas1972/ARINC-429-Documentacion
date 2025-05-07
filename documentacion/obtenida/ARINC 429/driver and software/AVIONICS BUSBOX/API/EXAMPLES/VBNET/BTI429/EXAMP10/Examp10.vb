Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI429 DRIVER VB_EXAMPLE 10  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP10 -- Multiple Core Example
	'
	'  This program opens Card Number 0 and configures all
	'  ARINC 429 cores to transmit, receive, and monitor.
	'  All transmit channels and all receive channels are
	'  used.It also enables the sequential monitor to record
	'  transmitted and received messages.
	'
	
	
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Dim bCardRunning As Boolean
    Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCores(MAX_CORES - 1) As UInteger
    Dim bCores(MAX_CORES - 1) As Boolean
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim chan As Integer
    Dim corecount As Short
    Dim seqbuf(2047) As UShort
    Dim seqcount As UInteger
    Dim blkcnt As UInteger
    Dim pRec429 As BTICARDVB.SEQRECORD429
    Dim sfinfo As BTICARDVB.SEQFINDINFO

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

        '  Clear all lists
        List1.Items.Clear()
        List2.Items.Clear()
        List3.Items.Clear()
        List4.Items.Clear()

        '
        '  Configure all transmit channels on all cores to transmit at low speed.
        '  Configure all receive channels on all cores for auto speed detection.
        '  Configure each cores sequential record.
        '

        Dim xmt_airspeed As BTI429VB.MSGSTRUCT429
        For corenum = 0 To (MAX_CORES - 1)
            If bCores(corenum) Then
                BTICard_CardReset((hCores(corenum)))

                For chan = 0 To (MAX_CHANNELS - 1)
                    If 0 <> BTI429_ChIsXmt(chan, hCores(corenum)) Then
                        errval = BTI429_ChConfig(CHCFG429_SEQALL, chan, hCores(corenum)) ' Configure channel
                        If (errval < 0) Then
                            errstr = "Error:  An error was encountered while configuring" & vbNewLine
                            errstr = errstr & "transmit channel #" & chan & " on core #" & corenum
                            MsgBox(errstr)
                            bSkipRun = True
                            Exit Sub
                        End If


                        ' Create a message for each of the synchronous labels we are transmitting.
                        xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCores(corenum))

                        ' Schedule the message
                        Call BTI429_SchedMsg(xmt_airspeed.addr, chan, hCores(corenum))
                        Call BTI429_SchedGap(1218, chan, hCores(corenum))

                        ' Initialize the Message Record.
                        xmt_airspeed.data = BTI429_FldPutLabel(0, &O206S) ' Init label field
                        Call BTI429_MsgDataWr(xmt_airspeed.data, xmt_airspeed.addr, hCores(corenum))

                    ElseIf 0 <> BTI429_ChIsRcv(chan, hCores(corenum)) Then
                        errval = BTI429_ChConfig(CHCFG429_AUTOSPEED, chan, hCores(corenum)) ' Configure channel
                        If (errval < 0) Then
                            errstr = "Error:  An error was encountered while configuring" & vbNewLine
                            errstr = errstr & "receive channel #" & chan & " on core #" & corenum
                            MsgBox(errstr)
                            bSkipRun = True
                            Exit Sub
                        End If

                        ' Create a default filter
                        Call BTI429_FilterDefault(MSGCRT429_DEFAULT, chan, hCores(corenum))

                    End If

                Next

                '
                ' Configure the sequential record on each core for fill and halt mode (default).
                '

                errval = BTICard_SeqConfig(SEQCFG_DEFAULT, hCores(corenum))
                If (errval < 0) Then
                    errstr = "Error:  An error was encounted while configuring" & vbNewLine
                    errstr = errstr & "the sequential record on core #" & corenum
                    MsgBox(errstr)
                    bSkipRun = True
                    Exit Sub
                End If

            End If
        Next

        '
        ' Start operation of the card.
        '

        For corenum = 0 To (MAX_CORES - 1)
            If bCores(corenum) Then
                BTICard_CardStart(hCores(corenum))
            End If
        Next

        bCardRunning = True
        cmdStart.Enabled = False
        cmdStop.Enabled = True

    End Sub

    Private Sub cmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStop.Click
        bCardRunning = False

        For corenum = 0 To (MAX_CORES - 1)
            BTICard_CardStart(hCores(corenum))
        Next

        cmdStart.Enabled = True
        cmdStop.Enabled = False

    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Errhandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        bSkipRun = False
        bCardRunning = False
        cmdStart.Enabled = False
        cmdStop.Enabled = False

        For corenum = 0 To (MAX_CORES - 1)
            hCores(corenum) = 0
            bCores(corenum) = False
        Next

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find all ARINC 429 cores on the board
        corecount = 0
        Dim hCore As UInteger
        Dim chan As Integer
        For corenum = 0 To (MAX_CORES - 1)
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For chan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI429_ChIsXmt(chan, hCore)) Or CBool(BTI429_ChIsRcv(chan, hCore)) Then
                        Exit For
                    End If
                Next
                If (chan <> MAX_CHANNELS) Then
                    hCores(corenum) = hCore
                    bCores(corenum) = True
                    corecount = CShort(corecount + 1)
                End If
            End If
        Next

        If corecount = 0 Then
            MsgBox("Error:    Unable to find any ARINC 429 cores on card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        ' Init output list 1
        List1.Items.Clear()
        If bCores(0) Then
            List1.BackColor = System.Drawing.ColorTranslator.FromOle(&H80000005)
        End If

        ' Init output list 2
        List2.Items.Clear()
        If bCores(1) Then
            List2.BackColor = System.Drawing.ColorTranslator.FromOle(&H80000005)
        End If

        ' Init output list 3
        List3.Items.Clear()
        If bCores(2) Then
            List3.BackColor = System.Drawing.ColorTranslator.FromOle(&H80000005)
        End If

        ' Init output list 4
        List4.Items.Clear()
        If bCores(3) Then
            List4.BackColor = System.Drawing.ColorTranslator.FromOle(&H80000005)
        End If

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
        ' Write data to lists
        '

        For corenum = 0 To (MAX_CORES - 1)
            If bCores(corenum) Then
                seqcount = BTICard_SeqBlkRd(seqbuf(0), 2047, blkcnt, hCores(corenum))

                If (seqcount > 0) Then
                    errval = BTICard_SeqFindInit(seqbuf(0), CUInt(seqcount), sfinfo)
                    If (0 > errval) Then
                        MsgBox("Error: SeqFindInit failed")
                        bSkipRun = True
                        Exit Sub
                    End If

                    ' Add each 429Record in SeqBuf to List
                    While (0 <= BTICard_SeqFindNext429Ex(pRec429, CUShort(Len(pRec429)), sfinfo))
                        If corenum = 0 Then
                            List1.Items.Add("Data: " & Hex(pRec429.data) & "     TimeTag: " & Hex(pRec429.timestamp))
                        ElseIf corenum = 1 Then
                            List2.Items.Add("Data: " & Hex(pRec429.data) & "     TimeTag: " & Hex(pRec429.timestamp))
                        ElseIf corenum = 2 Then
                            List3.Items.Add("Data: " & Hex(pRec429.data) & "     TimeTag: " & Hex(pRec429.timestamp))
                        ElseIf corenum = 3 Then
                            List4.Items.Add("Data: " & Hex(pRec429.data) & "     TimeTag: " & Hex(pRec429.timestamp))
                        End If
                    End While
                End If

            End If
        Next

    End Sub
End Class