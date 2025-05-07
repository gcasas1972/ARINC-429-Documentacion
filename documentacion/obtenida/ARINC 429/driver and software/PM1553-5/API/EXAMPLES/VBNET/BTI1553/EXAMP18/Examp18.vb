Option Strict On
Option Explicit On

Imports System.Runtime.InteropServices

Friend Class Form1
    Inherits System.Windows.Forms.Form
    '
    '  BTI1553 DRIVER VB.NET BTI1553 EXAMPLE 18  (06/07/2011)
    '  Copyright (c) 2009-2011
    '  Ballard Technology, Inc.
    '  www.ballardtech.com
    '  support@ballardtech.com
    '  ALL RIGHTS RESERVED
    '
    '  NAME:   EXAMP18 -- Engineering Unit Example
    '
    '  This example configures Card Number 0 as a Bus Monitor
    '  terminal.  A terminal address filter is applied to only
    '  record messages for TA #1. It prints the time-tag,
    '  command words (if any), and status words (if any) for
    '  each monitor record. An engineering unit conversion is
    '  applied to the first data word in messages with Cwd1=0x0843.
    '  This program can be used to monitor data from example 2 or
    '  example 5.
    '
    '  The engineering unit conversion scales the unsigned field by the
    '  resolution then adds the offset (i.e., unsigned BNR).
    '

    ' Constants
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

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
    'UPGRADE_WARNING: Arrays in structure pRec1553 may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Dim pRec1553 As SEQRECORD1553
    Dim seqbuf(2047) As UShort
    Dim seqcount As UInteger
    Dim sfinfo As SEQFINDINFO
    Dim moncount As UShort

    Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        If (hCore >= 0) Then
            errval = BTICard_CardClose(hCore)
        End If

        ' End Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click
        ' Clear the list control contents and counter
        List1.Items.Clear()
        moncount = 0

        If bSkipRun Then
            Exit Sub
        End If

        ' Configure the channel for monitor mode.
        BTICard_CardReset((hCore))

        errval = BTI1553_MonConfig(MONCFG1553_DEFAULT, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while while configuring for monitor mode")
            bSkipRun = True
            Exit Sub
        End If

        ' Configure the sequential record
        errval = BTICard_SeqConfig(SEQCFG_DEFAULT, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while configuring sequential record")
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
        Result1.Text = "Card Running"

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
        List1.Items.Clear()

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

        'Init resolution
        Resolution.Text = "1"

        'Init offset
        Offset.Text = "0"

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

        ' Display data on the screen.
        seqcount = BTICard_SeqRd(seqbuf(0), hCore)
        If (0 = seqcount) Then
            Exit Sub
        End If

        errval = BTICard_SeqFindInit(seqbuf(0), CUInt(seqcount), sfinfo)
        If (0 > errval) Then
            MsgBox("Error: SeqFindInit failed")
            bSkipRun = True
            Exit Sub
        End If

        ' Add each 1553Record in SeqBuf to List1
        Dim recChanNum As Integer
        Dim str_Renamed As String
        While (0 <= BTICard_SeqFindNext1553Ex(pRec1553, CUShort(Marshal.SizeOf(pRec1553)), sfinfo))

            'Inc the record number
            moncount = CUShort(moncount + 1)

            'Calc the Chan number
            recChanNum = CInt(pRec1553.activity And MSGACT1553_CHMASK)
            recChanNum = ShiftRight(recChanNum, MSGACT1553_CHSHIFT)

            ' Format the output string
            str_Renamed = "Rec:" & CStr(moncount)
            str_Renamed = str_Renamed & "  Ch:" & CStr(recChanNum)
            str_Renamed = str_Renamed & "  Time:" & CStr(pRec1553.timestamp)

            If CBool(pRec1553.activity And MSGACT1553_RCVCWD1) Then
                str_Renamed = str_Renamed & "  Cwd1:" & Hex(pRec1553.cwd1)
            End If
            If CBool(pRec1553.activity And MSGACT1553_RCVCWD2) Then
                str_Renamed = str_Renamed & "  Cwd2:" & Hex(pRec1553.cwd2)
            End If
            If CBool(pRec1553.activity And MSGACT1553_RCVSWD1) Then
                str_Renamed = str_Renamed & "  Swd1:" & Hex(pRec1553.swd1)
            End If
            If CBool(pRec1553.activity And MSGACT1553_RCVSWD2) Then
                str_Renamed = str_Renamed & "  Swd2:" & Hex(pRec1553.swd2)
            End If

            If CBool(pRec1553.errorval And MSGERR1553_NORESP) Then ' No Response
                str_Renamed = str_Renamed & "  No response!"
            ElseIf CBool(pRec1553.errorval And MSGERR1553_ANYERR) Then  ' Error
                str_Renamed = str_Renamed & "  Error!"
            ElseIf pRec1553.cwd1 = &H843S Then  ' Success!
                str_Renamed = str_Renamed & " Field:"
                str_Renamed = str_Renamed & CStr((BTICard_ValGetBits(pRec1553.data(0), 0, 7) * CDbl(Resolution.Text)) + CDbl(Offset.Text))
            End If

            ' Output the result
            List1.Items.Add(str_Renamed)

        End While

    End Sub
End Class