Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI708 DRIVER VB_EXAMPLE 3  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP3 -- Sequential Monitor example
	'
	'  This program opens Card Number 0, find the first copatible
	'  core and configures the first receive channel and the
	'  first transmit channel to operate on the self-test bus.
    '  The transmitter is configured with 128 messages that are
	'  initialized with incrementing data.  The receive channel
	'  is configured to record it's data to the Sequential Monitor.
	'
    '  An Event Log frequency of 0 is specified, which will
    '  not generate any Event Log List entries for these channels.
	'
	'  The program will display the data from the Sequential Record,
	'  until a Stop button is pressed.
	'
	
	
	' Constants
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Const FRAMEFREQ As Short = 200 ' Frame frequency of 200Hz
    Const LOGFREQ As Short = 16 ' Generate a Log Event after every 16th message
    Const FRAMECOUNT As Short = 32 ' Transmit a total of 32 messages


    ' Card specific
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim corenum As Integer
    Dim errval As Integer
    Dim errstr As String
    Dim rcvchan As Integer
    Dim xmtchan As Integer
    Dim bSkipRun As Boolean
    Dim bCardRunning As Boolean

    ' Program specific
    Dim data(99) As UShort
    Dim j As UShort
    Dim jj As UShort

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

        ' Clear all contents from the list control
        List1.Items.Clear()

        BTICard_CardReset((hCore))

        ' Configure receive channel.
        errval = BTI708_ChConfig(CHCFG708_SEQALL Or CHCFG708_SELFTEST, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        'Configure transmit channel.
        errval = BTI708_ChConfig(CHCFG708_SELFTEST, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Build the receive channel messages.
        errval = BTI708_RcvBuild(MSGCRT708_DEFAULT, 0, 1, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while building" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        'Build the transmit messages
        errval = BTI708_XmtBuild(MSGCRT708_DEFAULT, 200, 0, 128, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while building" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        'Create and write the data for the messages.
        For j = 0 To 127
            For jj = 0 To 99
                data(jj) = CUShort((j * 256) + jj)
            Next
            Call BTI708_MsgDataWr(data(0), j, xmtchan, hCore)
        Next

        'Configure the Sequential Monitor.
        errval = BTICard_SeqConfig(SEQCFG_DEFAULT, hCore)
        If (errval < 0) Then
            errstr = "Error: An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the Sequential Monitor on core #" & corenum & " on card #" & CARDNUM
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
        CmdStart.Enabled = False
        CmdStop.Enabled = False
        bSkipRun = False
        bCardRunning = False
        Result1.Text = "Card Stopped"

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            MsgBox("Error: Unable to open card number " & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first ARINC 708 core with both a receive and a transmit channel.
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If CBool(BTI708_ChIsRcv(rcvchan, hCore)) Then
                        For xmtchan = 0 To MAX_CHANNELS - 1
                            If CBool(BTI708_ChIsXmt(xmtchan, hCore)) Then
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

        CmdStart.Enabled = True
        CmdStop.Enabled = False
        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		Dim tempstr As String
		'UPGRADE_NOTE: str was upgraded to str_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim str_Renamed As String
        Dim seqbuf(2048) As UShort
        Dim seqcount As UInteger
        Dim blkcnt As UInteger
		'UPGRADE_WARNING: Arrays in structure rec708 may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim rec708 As BTICARDVB.SEQRECORD708
        Dim sfinfo As BTICARDVB.SEQFINDINFO
		
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		'
		' Loop until Stop button is hit.
		'
		
		seqcount = BTICard_SeqBlkRd(seqbuf(0), 2048, blkcnt, hCore)
        Call BTICard_SeqFindInit(seqbuf(0), CUInt(seqcount), sfinfo)
		
        While 0 = BTICard_SeqFindNext708Ex(rec708, CUShort(Len(rec708)), sfinfo)
            List1.Items.Clear()

            str_Renamed = "Time Stamp: " & Hex(rec708.timestamp)
            List1.Items.Add((str_Renamed))
            str_Renamed = "Activity: " & Hex(rec708.activity)
            List1.Items.Add((str_Renamed))

            ' Display extended header data if it exists
            If CBool(BTICard_SeqFindCheckVersion(rec708.typeval, SEQVER_1)) Then
                str_Renamed = "Bitcount: " & Hex(rec708.bitcount)
                List1.Items.Add((str_Renamed))
            End If

            For j = 0 To 9
                str_Renamed = j & " "
                For jj = 0 To 9
                    tempstr = CStr(Hex(rec708.data((j * 10) + jj)))
                    While Len(tempstr) < 4
                        tempstr = "0" & tempstr
                    End While
                    str_Renamed = str_Renamed & " " & tempstr
                Next
                List1.Items.Add((str_Renamed))
            Next

        End While
		
	End Sub
End Class