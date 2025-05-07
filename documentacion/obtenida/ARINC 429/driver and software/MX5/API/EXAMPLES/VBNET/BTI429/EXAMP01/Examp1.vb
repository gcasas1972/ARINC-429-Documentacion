Option Strict On
Option Explicit On

Friend Class Form1
    Inherits System.Windows.Forms.Form

	'
    '  BTI429 DRIVER VB_EXAMPLE 1  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP1 -- Receiver example
	'
	'  This program opens Card Number 0, and configures the
	'  first compatible core to receive 2 GPS messages into
	'  separate Message Records, and receive all other
	'  messages into a default Message Record.
	'
	
	
    Const CARDNUM As Integer = 0
	Const MAX_CORES As Integer = 4
	Const MAX_CHANNELS As Integer = 16
	
    Dim hCard As UInteger
    Dim hCore As UInteger
	Dim corenum As Integer
	Dim bSkipRun As Boolean
	Dim bCardRunning As Boolean
    Dim errval As Integer
    Dim errstr As String

	Dim rcvchan As Integer
    Dim msgdefault As BTI429VB.MSGSTRUCT429
    Dim Latitude As BTI429VB.MSGSTRUCT429
    Dim Longitude As BTI429VB.MSGSTRUCT429
	
	Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdExit.Click
		If (hCard >= 0) Then
            errval = BTICard_CardClose(hCard)
		End If
		
		' End Program
		End
		
	End Sub
	
	Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click
		
		If (bSkipRun = True) Then
			Exit Sub
		End If
		
		'Configure receiver channel for auto speed detection.
		BTICard_CardReset((hCore))
        errval = BTI429_ChConfig(CHCFG429_AUTOSPEED, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If
		
		' Before any messages can be received, filters must be set
		' for the receive channel.  First, the default filter is
		' created.  Then, two filters are set for the two messages
		' of interest.
		
		msgdefault.addr = BTI429_FilterDefault(MSGCRT429_DEFAULT, rcvchan, hCore)
		Latitude.addr = BTI429_FilterSet(MSGCRT429_DEFAULT, &O310s, SDIALL, rcvchan, hCore)
		Longitude.addr = BTI429_FilterSet(MSGCRT429_DEFAULT, &O311s, SDIALL, rcvchan, hCore)
		
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
		
		' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            errstr = "Error: Unable to open card number " & CARDNUM
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If
		
		' Find the first 429 core with a receive channel
		For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If 0 <> BTI429_ChIsRcv(rcvchan, hCore) Then
                        Exit For
                    End If
                Next
                If rcvchan < MAX_CHANNELS Then
                    Exit For
                End If
            End If
		Next 
		
        If (errval <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 429 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If
		
		Core.Text = "Using core #" & corenum
		Receive.Text = "Using receive channel #" & rcvchan
		
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
		
		' Read data from card
		msgdefault.Data = BTI429_MsgDataRd(msgdefault.addr, hCore)
		Latitude.Data = BTI429_MsgDataRd(Latitude.addr, hCore)
		Longitude.Data = BTI429_MsgDataRd(Longitude.addr, hCore)
		
		' Write data to form
		Line1.Text = "Default = " & Hex(msgdefault.Data) & " (Hex)"
		Line2.Text = "Latitude = " & Hex(Latitude.Data) & " (Hex)"
		Line3.Text = "Longitude = " & Hex(Longitude.Data) & " (Hex)"
		
	End Sub
End Class