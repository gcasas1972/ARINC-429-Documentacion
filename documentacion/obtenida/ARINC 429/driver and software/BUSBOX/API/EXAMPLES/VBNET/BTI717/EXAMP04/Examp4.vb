Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI717 DRIVER VB_EXAMPLE 4  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP4 -- Polling the Event Log List
	'
	'  This program opens Card Number 0, and configures the
	'  first BiPhase channel as a transmitter.  The channel
	'  is loaded with initial data.  An Event Log List is
	'  configured and the last word in each SF is tagged to
	'  generate an Event Log List entry.  The program polls
	'  for these events and updates the data in the SF that
	'  caused the event.
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
    Dim xmtchan As Integer
    Dim bSkipRun As Boolean
    Dim bCardRunning As Boolean

    ' Program specific
    Dim wps As UShort
    Dim sfblock(8199) As UShort
    Dim frameCount As Short
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

        frameCount = 0

        '  Configure transmitter channel at specified words per second.
        '  Use the internal wrap around.
        BTICard_CardReset((hCore))

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

        '  Configure the Event Log list.
        errval = BTICard_EventLogConfig(LOGCFG_ENABLE, 1024, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while configuring the event log list")
            bSkipRun = True
            Exit Sub
        End If

        '  Configure word options. (Mark last word of SFs 1, 2, 3, and 4 for Event Logging)
        Call BTI717_SubFrmWordConfig(WRDCFG717_SFLOG, 1, wps, xmtchan, hCore)
        Call BTI717_SubFrmWordConfig(WRDCFG717_SFLOG, 2, wps, xmtchan, hCore)
        Call BTI717_SubFrmWordConfig(WRDCFG717_SFLOG, 3, wps, xmtchan, hCore)
        Call BTI717_SubFrmWordConfig(WRDCFG717_SFLOG, 4, wps, xmtchan, hCore)

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
        Result1.Text = "Card Running"

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
        bSkipRun = True
        bCardRunning = False
        Result1.Text = "Card Stopped"
        Result2.Text = ""

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If CBool(errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first 717 core with a BiPhase transmit channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For xmtchan = 0 To MAX_CHANNELS - 1
                    If CBool(BTI717_ChIsType(CHCFG717_BIPHASEXMT, xmtchan, hCore)) Then
                        Exit For
                    End If
                Next
                If xmtchan < MAX_CHANNELS Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (xmtchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 717 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Channel.Text = "Using 717 BiPhase channel #" & xmtchan

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
        Dim eventType As UShort
        Dim info As UInteger
        Dim sfnum As UShort
        Dim Channel As Integer
        Dim jj As UShort

        If (bSkipRun = True) Or (bCardRunning = False) Then
            Exit Sub
        End If

        '
        ' Read entry from Event Log list
        '

        If CBool(BTICard_EventLogRd(eventType, info, Channel, hCore)) Then 'Read entry from Event Log list
            sfnum = CUShort(info)

            Call BTI717_SubFrmBlkRd(sfblock(0), sfnum, xmtchan, hCore)

            For jj = 2 To wps
                sfblock(jj + 7) = CUShort(sfblock(jj + 7) And CShort(&HF000S)) 'Keep option bits, clear data
                sfblock(jj + 7) = CUShort(sfblock(jj + 7) Or ((frameCount * wps) + jj) And &HFFFS) 'Set new data
            Next

            Call BTI717_SubFrmBlkWr(sfblock(0), sfnum, xmtchan, hCore)

            Result2.Text = "Updated data for SF:" & sfnum

            If sfnum = 4 Then
                frameCount = CShort(frameCount + 1)
            End If
        End If

    End Sub
End Class