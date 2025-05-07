Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI429 DRIVER VB_EXAMPLE 13  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP3 -- Monitor DMA Example
	'
	'  This program opens Card Number 0, finds the first
	'  compatible core, builds a transmit schedule using
	'  transmit interval information, and creates filters
	'  for two receive messages.  It also enables the
	'  sequential monitor to record transmitted and
	'  received messages using DMA mode.
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
    Dim msgdefault As BTI429VB.MSGSTRUCT429
    Dim latitude As BTI429VB.MSGSTRUCT429
    Dim longitude As BTI429VB.MSGSTRUCT429
    Dim comp_airspeed As BTI429VB.MSGSTRUCT429
    Dim tot_air_temp As BTI429VB.MSGSTRUCT429
    Dim altitude_rate As BTI429VB.MSGSTRUCT429
    Dim msgaddr(2) As UInteger
    Dim min_intrvls(2) As Integer
    Dim max_intrvls(2) As Integer
    Dim seqbuf(2047) As UShort
    Dim seqcount As UInteger
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

        ' Configure rcvchan for auto speed detection.
        ' Configure xmtchan to transmit at low speed.

        ' Record all of xmtchan data in sequential record
        BTICard_CardReset((hCore))

        'Configure channel
        errval = BTI429_ChConfig(CHCFG429_AUTOSPEED, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        'Configure channel
        errval = BTI429_ChConfig(CHCFG429_SEQALL, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring " & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Create a message for each of the labels we are transmitting.
        comp_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
        tot_air_temp.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
        altitude_rate.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)

        ' Setup the arrays of message addresses, and intervals
        ' needed to build the schedule.  Note that the nth element
        ' in each array correspond to each other.
        msgaddr(0) = comp_airspeed.addr
        min_intrvls(0) = 250
        max_intrvls(0) = 500

        msgaddr(1) = tot_air_temp.addr
        min_intrvls(1) = 250
        max_intrvls(1) = 500

        msgaddr(2) = altitude_rate.addr
        min_intrvls(2) = 100
        max_intrvls(2) = 200

        ' Next, build a schedule using the minimum and maximum
        ' transmit intervals.
        errval = BTI429_SchedBuild(3, msgaddr(0), min_intrvls(0), max_intrvls(0), xmtchan, hCore)
        If (errval < 0) Then
            MsgBox("Error:  BTI429_SchedBuild failed on core #" & corenum & ".")
            bSkipRun = True
            Exit Sub
        End If

        ' Initialize the three Message Records.
        comp_airspeed.data = BTI429_FldPutLabel(0, &O206S) '/*Init label field*/
        tot_air_temp.data = BTI429_FldPutLabel(0, &O211S)
        altitude_rate.data = BTI429_FldPutLabel(0, &O212S)

        comp_airspeed.data = BTI429_BNRPutMant(comp_airspeed.data, 0, 14, 0) '/*Init BNR data*/
        tot_air_temp.data = BTI429_BNRPutMant(tot_air_temp.data, 0, 11, 0)
        altitude_rate.data = BTI429_BNRPutMant(altitude_rate.data, 0, 16, 0)

        Call BTI429_MsgDataWr(comp_airspeed.data, comp_airspeed.addr, hCore)
        Call BTI429_MsgDataWr(tot_air_temp.data, tot_air_temp.addr, hCore)
        Call BTI429_MsgDataWr(altitude_rate.data, altitude_rate.addr, hCore)

        ' Before any messages can be received, filters must be set
        ' for the receive channel.  First, the default filter is
        ' created.  Then, two filters are set for the two messages
        ' of interest.

        ' Record the two filtered messages.
        msgdefault.addr = BTI429_FilterDefault(MSGCRT429_DEFAULT, rcvchan, hCore)
        latitude.addr = BTI429_FilterSet(MSGCRT429_SEQ, &O310S, SDIALL, rcvchan, hCore)
        longitude.addr = BTI429_FilterSet(MSGCRT429_SEQ, &O311S, SDIALL, rcvchan, hCore)

        ' Configure the sequential record for continuous DMA mode.
        errval = BTICard_SeqConfig(SEQCFG_DEFAULT Or SEQCFG_DMA, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the sequential record on core #" & corenum & vbNewLine
            errstr = errstr & "(" & errval & ")"
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while starting core #" & corenum & vbNewLine
            errstr = errstr & "(" & errval & ")"
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        bCardRunning = True
        cmdStart.Enabled = False
        cmdStop.Enabled = True
        List1.Items.Clear()

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

        ' Find the first ARINC 429 core with both a receive and a transmit channel.
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If CBool(BTI429_ChIsRcv(rcvchan, hCore)) Then
                        For xmtchan = 0 To MAX_CHANNELS - 1
                            If CBool(BTI429_ChIsXmt(xmtchan, hCore)) Then
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
        List1.Items.Clear()

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub

    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick

        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        ' Display data on the screen.
        'seqcount = BTICard_SeqRd(seqbuf(0), hCore)
        seqcount = BTICard_SeqDMARd(seqbuf(0), 2048, hCore)
        If (0 = seqcount) Then
            Exit Sub
        End If

        errval = BTICard_SeqFindInit(seqbuf(0), CUInt(seqcount), sfinfo)
        If (0 > errval) Then
            MsgBox("Error: SeqFindInit failed")
            bSkipRun = True
            Exit Sub
        End If

        ' Add each 429Record in SeqBuf to List1
        'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
        While (0 <= BTICard_SeqFindNext429Ex(pRec429, CUShort(Len(pRec429)), sfinfo))
            List1.Items.Add("Data: " & Hex(pRec429.data) & " (Hex)     TimeTag: " & Hex(pRec429.timestamp) & " (Hex)")
        End While

    End Sub
End Class