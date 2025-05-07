Option Strict Off
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI717 DRIVER VB_EXAMPLE 3  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP3 -- Sequential Monitor example
	'
	'  This program opens Card Number 0, and configures the
	'  first BiPhase channel as a receiver.  The second
	'  BiPhase channel is configured as a transmitter.  Both
	'  channels operate on the self-test bus to electrically connect
	'  them. The transmit channel is loaded with incrementing data,
	'  and various words are configured for entry into the
	'  Sequential Monitor.  The program will read out of the
	'  Sequential Record and display the data to the screen.
	'
	
	' Force explicit declaration of all variables
	
	' Constants
	Const cardnum As Integer = 0
	Const MAX_CORES As Integer = 4
	Const MAX_CHANNELS As Integer = 16
	
	' Card specific
	Dim hCard As Integer
	Dim hCore As Integer
	Dim corenum As Integer
	Dim ERRVAL As Integer
	Dim rcvchan As Integer
	Dim xmtchan As Integer
	Dim bSkipRun As Boolean
	Dim bCardRunning As Boolean
	
	' Program specific
	Dim wps As Short
	Dim superfrmaddr As Integer
	Dim sfblock(8199) As Short
	Dim j As Object
	Dim jj As Short
	
	Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdExit.Click
		If (hCard >= 0) Then
			ERRVAL = BTICard_CardClose(hCard)
		End If
		
		' End Program
		End
		
	End Sub
	
	Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click
		If bSkipRun Then
			Exit Sub
		End If
		
		List2.Items.Clear()
		
		'  Configure receiver channel for auto speed detection.
		'  Use the internal wrap around.
		BTICard_CardReset((hCore))
		ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASERCV Or CHCFG717_AUTOSPEED Or CHCFG717_SELFTEST, rcvchan, hCore)
		If (ERRVAL < 0) Then
			MsgBox("Error:  An error was encountered while configuring channel" & rcvchan)
			bSkipRun = True
			Exit Sub
		End If
		
		'  Configure transmitter channel at specified words per second.
		'  Use the internal wrap around.
		If List1.Text = "64" Then
			wps = 64
			ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_64WPS, xmtchan, hCore)
		ElseIf List1.Text = "128" Then 
			wps = 128
			ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_128WPS, xmtchan, hCore)
		ElseIf List1.Text = "256" Then 
			wps = 256
			ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_256WPS, xmtchan, hCore)
		ElseIf List1.Text = "512" Then 
			wps = 512
			ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_512WPS, xmtchan, hCore)
		ElseIf List1.Text = "1024" Then 
			wps = 1024
			ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_1024WPS, xmtchan, hCore)
		ElseIf List1.Text = "2048" Then 
			wps = 2048
			ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_2048WPS, xmtchan, hCore)
		ElseIf List1.Text = "4096" Then 
			wps = 4096
			ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_4096WPS, xmtchan, hCore)
		ElseIf List1.Text = "8192" Then 
			wps = 8192
			ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_8192WPS, xmtchan, hCore)
		Else
			MsgBox("Error:  An error was encountered while reading words per second")
			bSkipRun = True
			Exit Sub
		End If
		If (ERRVAL < 0) Then
			MsgBox("Error:  An error was encountered while configruing channel " & xmtchan)
			bSkipRun = True
			Exit Sub
		End If
		
		'  Init subframe data.
		For j = 1 To 4
            Call BTI717_SubFrmBlkRd(sfblock(0), j, xmtchan, hCore)
			For jj = 2 To wps
                sfblock(jj + 7) &= &HF000S  'Keep option bist, clear data
                sfblock(jj + 7) = sfblock(jj + 7) Or (((&H100S * j) + jj) And &HFFFS)
			Next 
            Call BTI717_SubFrmBlkWr(sfblock(0), j, xmtchan, hCore)
		Next 
		
		'  Create some SuperFrame structures.
		Call BTI717_SuperFrmConfig(10, 16, xmtchan, hCore)
		
		'  Define SF2, W10 to be SuperFrame Data. Init superframe data.
		superfrmaddr = BTI717_SuperFrmDefine(2, 10, xmtchan, hCore)
		For j = 1 To 16
            Call BTI717_SuperFrmWordWr(&H500S + j, j, superfrmaddr, xmtchan, hCore)
		Next 
		
		'  Set superframe counter position.
		Call BTI717_SuperFrmCounterPos(1, wps, rcvchan, hCore)
		Call BTI717_SuperFrmCounterPos(1, wps, xmtchan, hCore)
		
		'  Configure the Sequential Monitor.
		ERRVAL = BTICard_SeqConfig(SEQCFG_DEFAULT, hCore)
		If (ERRVAL < 0) Then
			MsgBox("Error:  An error was encountered while configuring the Sequential Monitor")
			bSkipRun = True
			Exit Sub
		End If
		
		'  Configure word options. (Mark word 1 of SFs 1, 2, 3, and 4 for the Sequential Monitor)
		Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 1, 1, rcvchan, hCore)
		Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 2, 1, rcvchan, hCore)
		Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 3, 1, rcvchan, hCore)
		Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 4, 1, rcvchan, hCore)
		
		Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 1, 1, xmtchan, hCore)
		Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 2, 1, xmtchan, hCore)
		Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 3, 1, xmtchan, hCore)
		Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 4, 1, xmtchan, hCore)
		
		'  (Mark the word at SPF 4 of our superframe word (word 10, SF 2) for the Sequential Monitor)
		Call BTI717_SuperFrmWordConfig(WRDCFG717_SEQ, 4, superfrmaddr, xmtchan, hCore)
		
		'  Start operation of the card.
		ERRVAL = BTICard_CardStart(hCore)
		If (ERRVAL < 0) Then
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
		hCard = -1
		hCore = -1
		CmdStart.Enabled = False
		CmdStop.Enabled = False
		bSkipRun = False
		bCardRunning = False
		Result1.Text = "Card Stopped"
		
		' Open handle to card with specified card number
		ERRVAL = BTICard_CardOpen(hCard, cardnum)
		If (ERRVAL) Then
			MsgBox("Error: can not open card number " & CStr(cardnum))
			bSkipRun = True
			Exit Sub
		End If
		
		'
		' Find the first ARINC 717 core with both BiPhase receive and transmit channels.
		'
		
		For corenum = 0 To MAX_CORES - 1
			ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
			If ERRVAL = 0 Then
				'Search for receive
				For rcvchan = 0 To MAX_CHANNELS - 1
					If BTI717_ChIsType(CHCFG717_BIPHASERCV, rcvchan, hCore) Then
						Exit For
					End If
				Next 
				'Search for transmit
				For xmtchan = 0 To MAX_CHANNELS - 1
					If xmtchan <> rcvchan Then
						If BTI717_ChIsType(CHCFG717_BIPHASEXMT, xmtchan, hCore) Then
							Exit For
						End If
					End If
				Next 
				
				If (rcvchan < MAX_CHANNELS) And (xmtchan < MAX_CHANNELS) Then
					Exit For
				End If
			End If
		Next 
		
		If (ERRVAL <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Or (xmtchan >= MAX_CHANNELS) Then
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
		
		CmdStart.Enabled = True
		CmdStop.Enabled = False
		Exit Sub
Errhandler: 
		MsgBox("An Error Has Occured:  " & Err.Description)
		
	End Sub
	
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		Dim seqbuf(2047) As Short
		Dim seqcount As Short
		Dim rec717 As SEQRECORD717
		Dim sfinfo As SEQFINDINFO
		Dim myStr As String
		
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		'
        ' Read the Sequential Record and display to screen.
		'
		
		seqcount = BTICard_SeqRd(seqbuf(0), hCore)
		
		ERRVAL = BTICard_SeqFindInit(seqbuf(0), seqcount, sfinfo)
		If (0 > ERRVAL) Then
			MsgBox("Error: SeqFindInit failed")
			bSkipRun = True
			Exit Sub
		End If
		
		' Add each 717Record in SeqBuf to List2
        While (0 <= BTICard_SeqFindNext717Ex(rec717, Len(rec717), sfinfo))
            'Create list item to add
            myStr = "Ch:" & ShiftRight(rec717.activity And MSGACT717_CHMASK, MSGACT717_CHSHIFT)
            myStr = myStr & "   Word:" & rec717.wordnum
            myStr = myStr & "   SF:" & rec717.subframe
            myStr = myStr & "   SPF:" & ((rec717.superframe Mod 16) + 1)
            myStr = myStr & "   Value:" & Oct(rec717.data) & " (Octal)"
            myStr = myStr & "   TimeStamp:"

            'Display timestamph value if supported
            If BTICard_SeqFindCheckVersion(rec717.typeval, SEQVER_1) Then
                myStr = myStr & Hex(rec717.timestamph) & " "
            End If

            'Always display timestamp value
            myStr = myStr & Hex(rec717.timestamp)

            'Add item to List2
            List2.Items.Add((myStr))
        End While
		
	End Sub
End Class