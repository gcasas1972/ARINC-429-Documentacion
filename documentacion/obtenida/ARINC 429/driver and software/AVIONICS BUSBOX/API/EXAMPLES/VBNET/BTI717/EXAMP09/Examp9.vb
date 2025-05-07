Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI717 DRIVER VB_EXAMPLE 9  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP9 -- Transmitter with SuperFrame data example
	'
	'  NOTE: This example was previously released as EXAMP2
	'
	'  This program opens Card Number 0, and configures the
	'  first BiPhase channel as a receiver.  The second
	'  BiPhase channel is configured as a transmitter.  Both
	'  channels operate on the self-test bus to electrically connect
	'  them. The transmit channel is loaded with incrementing data,
	'  and SubFrame 2, Word 10, is defined as SuperFrame data.
	'  The SuperFrame data is loaded with incrementing data as well.
	'  For this example, the receive channel does not define any
	'  words as SuperFrame data.  The program will display what is
	'  received in SubFrame 2, Word 10.
	'
	
	' Force explicit declaration of all variables
	
	' Constants
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    ' Card specific
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim corenum As Integer
    Dim errval As Integer
    Dim rcvchan As Integer
    Dim xmtchan As Integer
    Dim bSkipRun As Boolean
    Dim bCardRunning As Boolean

    ' Program specific
    Dim wps As UShort
    Dim superfrmaddr As UInteger
    Dim sfblock(8199) As UShort
    Dim data As UShort
    Dim j As UShort
    Dim jj As UShort

    Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        If (hCard >= 0) Then
            errval = BTICard_CardClose(hCard)
        End If

        ' End Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStart.Click
        If bSkipRun Then
            Exit Sub
        End If

        '  Configure receiver channel for auto speed detection.
        '  Use the internal wrap around.
        BTICard_CardReset((hCore))
        errval = BTI717_ChConfig(CHCFG717_BIPHASERCV Or CHCFG717_AUTOSPEED Or CHCFG717_SELFTEST, rcvchan, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while configuring channel" & rcvchan)
            bSkipRun = True
            Exit Sub
        End If

        '  Configure transmitter channel at specified words per second.
        '  Use the internal wrap around.
        If List1.Text = "64" Then
            wps = 64
            errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_64WPS, xmtchan, hCore)
        ElseIf List1.Text = "128" Then
            wps = 128
            errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_128WPS, xmtchan, hCore)
        ElseIf List1.Text = "256" Then
            wps = 256
            errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_256WPS, xmtchan, hCore)
        ElseIf List1.Text = "512" Then
            wps = 512
            errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_512WPS, xmtchan, hCore)
        ElseIf List1.Text = "1024" Then
            wps = 1024
            errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_1024WPS, xmtchan, hCore)
        ElseIf List1.Text = "2048" Then
            wps = 2048
            errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_2048WPS, xmtchan, hCore)
        ElseIf List1.Text = "4096" Then
            wps = 4096
            errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_4096WPS, xmtchan, hCore)
        ElseIf List1.Text = "8192" Then
            wps = 8192
            errval = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_8192WPS, xmtchan, hCore)
        Else
            MsgBox("Error:  An error was encountered while reading words per second")
            bSkipRun = True
            Exit Sub
        End If
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while configruing channel " & xmtchan)
            bSkipRun = True
            Exit Sub
        End If

        '  Init subframe data.
        For j = 1 To 4
            Call BTI717_SubFrmBlkRd(sfblock(0), j, xmtchan, hCore)
            For jj = 2 To wps
                sfblock(jj + 7) = CUShort(((&H100S * j) + jj) And &HFFFS)
            Next
            Call BTI717_SubFrmBlkWr(sfblock(0), j, xmtchan, hCore)
        Next

        '  Create some SuperFrame structures.
        Call BTI717_SuperFrmConfig(10, 16, xmtchan, hCore)

        '  Define SF2, W10 to be SuperFrame Data. Init superframe data.
        superfrmaddr = BTI717_SuperFrmDefine(2, 10, xmtchan, hCore)
        For j = 1 To 16
            Call BTI717_SuperFrmWordWr(CUShort(&H500S + j), j, superfrmaddr, xmtchan, hCore)
        Next

        '  Set superframe counter position.
        Call BTI717_SuperFrmCounterPos(1, wps, xmtchan, hCore)

        '  Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting the card")
            bSkipRun = True
            Exit Sub
        End If

        bCardRunning = True
        cmdStart.Enabled = False
        cmdStop.Enabled = True
        Result1.Text = "Synchronizing to bit stream...."

    End Sub

    Private Sub CmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStop.Click
        'Clear state of bRunning before card is stopped (so timer event is not processed)
        Dim bTemp As Boolean
        bTemp = bCardRunning
        bCardRunning = False

        If (bTemp = True) Then
            BTICard_CardStop(hCore)
        End If

        cmdStart.Enabled = True
        cmdStop.Enabled = False
        Result1.Text = "Card Stopped"
        Result2.Text = ""
    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Errhandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        cmdStart.Enabled = False
        cmdStop.Enabled = False
        bSkipRun = False
        bCardRunning = False
        Result1.Text = "Card Stopped"
        Result2.Text = ""

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, cardnum)
        If CBool(errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        '
        ' Find the first ARINC 717 core with both BiPhase receive and transmit channels.
        '

        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                'Search for receive
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If CBool(BTI717_ChIsType(CHCFG717_BIPHASERCV, rcvchan, hCore)) Then
                        Exit For
                    End If
                Next
                'Search for transmit
                For xmtchan = 0 To MAX_CHANNELS - 1
                    If xmtchan <> rcvchan Then
                        If CBool(BTI717_ChIsType(CHCFG717_BIPHASEXMT, xmtchan, hCore)) Then
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
            MsgBox("Error:  No compatible ARINC 717 core present in card #" & cardnum)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Channel.Text = "Using 717 BiPhase channel " & rcvchan & " and " & xmtchan

        ' Init the list box
        List1.Items.Clear()
        List1.Items.Add(CStr(64))
        List1.Items.Add(CStr(128))
        List1.Items.Add(CStr(256))
        List1.Items.Add(CStr(512))
        List1.Items.Add(CStr(1024))
        List1.Items.Add(CStr(2048))
        List1.Items.Add(CStr(4096))
        List1.Items.Add(CStr(8192))
        List1.SelectedIndex = 3

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
		' Display SF2, W10 on screen.
		'
		
        If CBool(BTI717_SyncTest(rcvchan, hCore)) Then
            Result1.Text = "In Sync!"
            Call BTI717_SubFrmWordRd(data, 2, 10, rcvchan, hCore)
            Result2.Text = "Channel " & xmtchan & " (" & wps & ") - SuperFrame Data: " & Hex(data) & " (Hex)"
        End If
		
	End Sub
End Class