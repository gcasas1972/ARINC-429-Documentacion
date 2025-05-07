Option Strict On
Option Explicit On

Imports System.Runtime.InteropServices

Friend Class Form1
    Inherits System.Windows.Forms.Form
    '
    '  BTI1553 DRIVER VB.NET BTI1553 EXAMPLE 14  (06/07/2011)
    '  Copyright (c) 2009-2011
    '  Ballard Technology, Inc.
    '  www.ballardtech.com
    '  support@ballardtech.com
    '  ALL RIGHTS RESERVED
    '
    '  NAME:   EXAMP14 -- Multi Core - Monitor all busses (channels) on all cores
    '


    ' Constants
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    ' Card/Program specific
    Dim hCard As UInteger
    Dim hCores(MAX_CORES - 1) As UInteger
    Dim bCores(MAX_CORES - 1) As Boolean
    Dim bSkipRun As Boolean
    Dim bCardRunning As Boolean
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim chan As Integer
    Dim corecount As Short
    Dim seqbuf(2047) As UShort
    Dim seqcount As UInteger
    Dim blkcnt As UInteger
    'UPGRADE_WARNING: Arrays in structure pRec1553 may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Dim pRec1553 As SEQRECORD1553
    Dim sfinfo As SEQFINDINFO
    Dim recstr As String

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
        '  Configure the sequential record on each 1553 core
        '  Configure all 1553 channels for monitor mode.
        '

        For corenum = 0 To (MAX_CORES - 1)
            If bCores(corenum) Then
                BTICard_CardReset((hCores(corenum)))

                ' Configure the sequential record on each core for fill and halt mode (default).
                errval = BTICard_SeqConfig(SEQCFG_DEFAULT, hCores(corenum))
                If (errval < 0) Then
                    errstr = "Error:  An error was encounted while configuring" & vbNewLine
                    errstr = errstr & "the sequential record on core #" & corenum
                    MsgBox(errstr)
                    bSkipRun = True
                    Exit Sub
                End If

                ' Configure each MIL-STD-1553 channel to monitor
                For chan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI1553_ChIs1553(chan, hCores(corenum))) Then
                        errval = BTI1553_MonConfig(MONCFG1553_DEFAULT, chan, hCores(corenum)) ' Configure channel
                        If (errval < 0) Then
                            errstr = "Error:  An error was encountered while configuring" & vbNewLine
                            errstr = errstr & "channel #" & chan & " on core #" & corenum
                            MsgBox(errstr)
                            bSkipRun = True
                            Exit Sub
                        End If
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

        ' Initialize handle to error condition and bSkipRun
        hCard = 0
        bSkipRun = False
        bCardRunning = False
        cmdStart.Enabled = False
        cmdStop.Enabled = False

        ' Initialize the core handles and flags
        For corenum = 0 To (MAX_CORES - 1)
            hCores(corenum) = 0
            bCores(corenum) = False
        Next

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If CBool(errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find all MIL-STD-1553 cores on the board
        corecount = 0
        For corenum = 0 To (MAX_CORES - 1)
            errval = BTICard_CoreOpen(hCores(corenum), corenum, hCard)
            If errval = 0 Then
                For chan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI1553_ChIs1553(chan, hCores(corenum))) Then
                        Exit For
                    End If
                Next
                If (chan <> MAX_CHANNELS) Then
                    bCores(corenum) = True
                    corecount = CShort(corecount + 1)
                End If
            End If
        Next

        If corecount = 0 Then
            MsgBox("Error:    Unable to find any MIL-STD-1553 cores on card #" & CStr(CARDNUM))
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

                    ' Add each 1553Record in SeqBuf to List
                    While (0 <= BTICard_SeqFindNext1553Ex(pRec1553, CUShort(Marshal.SizeOf(pRec1553)), sfinfo))

                        ' Format the output string
                        recstr = "Ch:" & CStr(ShiftRight(CInt(pRec1553.activity And MSGACT1553_CHMASK), MSGACT1553_CHSHIFT))
                        recstr = recstr & " Time:" & CStr(pRec1553.timestamp)
                        If CBool(pRec1553.activity And MSGACT1553_RCVCWD1) Then
                            recstr = recstr & " Cwd1:" & CStr(pRec1553.cwd1)
                        End If
                        If CBool(pRec1553.activity And MSGACT1553_RCVCWD2) Then
                            recstr = recstr & " Cwd2:" & CStr(pRec1553.cwd2)
                        End If
                        If CBool(pRec1553.activity And MSGACT1553_RCVSWD1) Then
                            recstr = recstr & " Swd1:" & CStr(pRec1553.swd1)
                        End If
                        If CBool(pRec1553.activity And MSGACT1553_RCVSWD2) Then
                            recstr = recstr & " Swd2:" & CStr(pRec1553.swd2)
                        End If
                        If CBool(pRec1553.errorval And MSGERR1553_NORESP) Then
                            recstr = recstr & " No response!"
                        End If
                        If CBool(pRec1553.errorval And MSGERR1553_ANYERR) Then
                            recstr = recstr & " Error!"
                        End If

                        ' Print output in correct core list
                        If corenum = 0 Then
                            List1.Items.Add(recstr)
                        ElseIf corenum = 1 Then
                            List2.Items.Add(recstr)
                        ElseIf corenum = 2 Then
                            List3.Items.Add(recstr)
                        ElseIf corenum = 3 Then
                            List4.Items.Add(recstr)
                        End If
                    End While
                End If

            End If
        Next

    End Sub
End Class