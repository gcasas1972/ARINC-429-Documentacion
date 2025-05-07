Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI708 DRIVER VB_EXAMPLE 9  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP9 -- Multiple Core Example
	'
	'  This program opens Card Number 0 and configures all
	'  ARINC 708 cores to transmit, receive, and monitor.
	'  All transmit channels and all receive channels are
	'  used. It also enables the sequential monitor to record
	'  transmitted and received messages.
	'
	
	
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Const FRAMEFREQ As Short = 200
    Const LOGFREQ As Short = 16
    Const FRAMECOUNT As Short = 32

    Dim bCardRunning As Boolean
    Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCores(MAX_CORES - 1) As UInteger
    Dim bCores(MAX_CORES - 1) As Boolean
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim corecount As Short
    Dim chan As Integer
    Dim Data(99) As UShort
    Dim seqbuf(2047) As UShort
    Dim seqcount As UInteger
    Dim blkcnt As UInteger
    Dim blockcount As UShort
    'UPGRADE_WARNING: Arrays in structure pRec708 may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Dim pRec708 As SEQRECORD708
    Dim sfinfo As SEQFINDINFO
    Dim j As Short
    Dim jj As Short

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
        '  Configure all transmit channels on all cores to send 32 messages at 200Hz
        '  Configure all receive channels on all cores to receive messages in a single message record per core.
        '  Configure each cores sequential record.
        '
        blockcount = 0
        For corenum = 0 To (MAX_CORES - 1)
            If bCores(corenum) Then
                BTICard_CardReset((hCores(corenum)))

                For chan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI708_ChIsXmt(chan, hCores(corenum))) Then
                        errval = BTI708_ChConfig(CHCFG708_SEQALL, chan, hCores(corenum)) ' Configure channel
                        If (errval < 0) Then
                            errstr = "Error:  An error was encountered while configuring" & vbNewLine
                            errstr = errstr & "transmit channel #" & chan & " on core #" & corenum
                            MsgBox(errstr)
                            bSkipRun = True
                            Exit Sub
                        End If

                        errval = BTI708_XmtBuild(MSGCRT708_DEFAULT, FRAMEFREQ, LOGFREQ, FRAMECOUNT, chan, hCores(corenum))
                        If (errval < 0) Then
                            errstr = "Error:  An error was encountered while building" & vbNewLine
                            errstr = errstr & "transmit channel #" & chan & " on core #" & corenum
                            MsgBox(errstr)
                            bSkipRun = True
                            Exit Sub
                        End If

                        For j = 0 To (FRAMECOUNT - 1) ' Loop through all the messages
                            For jj = 0 To 99
                                Data(jj) = CUShort(j + (blockcount * FRAMECOUNT))
                            Next
                            Call BTI708_MsgDataWr(Data(0), j, chan, hCores(corenum)) ' Write data to the Device
                        Next
                        blockcount = CUShort(blockcount + 1)
                    ElseIf CBool(BTI708_ChIsRcv(chan, hCores(corenum))) Then
                        errval = BTI708_ChConfig(CHCFG708_DEFAULT, chan, hCores(corenum)) ' Configure channel
                        If (errval < 0) Then
                            errstr = "Error:  An error was encountered while configuring" & vbNewLine
                            errstr = errstr & "receive channel #" & chan & " on core #" & corenum
                            MsgBox(errstr)
                            bSkipRun = True
                            Exit Sub
                        End If

                        errval = BTI708_RcvBuild(MSGCRT708_DEFAULT, 0, 1, chan, hCores(corenum))
                        If (errval < 0) Then
                            errstr = "Error:  An error was encountered while building" & vbNewLine
                            errstr = errstr & "receive channel #" & chan & " on core #" & corenum
                            MsgBox(errstr)
                            bSkipRun = True
                            Exit Sub
                        End If

                    End If

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

                Next
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

        ' Find all ARINC 708 cores on the board
        corecount = 0
        Dim hCore As UInteger
        Dim chan As Short
        For corenum = 0 To (MAX_CORES - 1)
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For chan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI708_ChIsXmt(chan, hCore)) Or CBool(BTI708_ChIsRcv(chan, hCore)) Then
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
            MsgBox("Error:    Unable to find any ARINC 708 cores on card #" & CARDNUM)
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

                    ' Add each 708-Record in SeqBuf to the Lists
                    While (0 <= BTICard_SeqFindNext708Ex(pRec708, CUShort(Len(pRec708)), sfinfo))
                        If corenum = 0 Then
                            List1.Items.Add("TimeTag: " & Hex(pRec708.timestamp) & " (Hex)")
                        ElseIf corenum = 1 Then
                            List2.Items.Add("TimeTag: " & Hex(pRec708.timestamp) & " (Hex)")
                        ElseIf corenum = 2 Then
                            List3.Items.Add("TimeTag: " & Hex(pRec708.timestamp) & " (Hex)")
                        ElseIf corenum = 3 Then
                            List4.Items.Add("TimeTag: " & Hex(pRec708.timestamp) & " (Hex)")
                        End If
                    End While
                End If

            End If
        Next

    End Sub
End Class