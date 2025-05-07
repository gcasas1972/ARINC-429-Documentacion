Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI1553 DRIVER VB.NET BTI1553 EXAMPLE 12  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
    '  NAME:   EXAMP12 -- BC Transmission of Ramping Data Using a FIFO
	'
	'  This example configures Card Number 0 as a bus controller
	'  to transmit a schedule of one message.  The message is
	'  transmitted at a frequency of 10Hz (or every 100ms).
	'
	'  A FIFO of 100 entries is configured for the message.
	'  Before staring the card, the FIFO is filled with unique
	'  sets of data words.  After the card is started, the
	'  program continually pushes new sets of data into the FIFO
	'  until the program stops.
	'
	
	
	' Constants
    Const CARDNUM As Integer = 0
	Const MAX_CORES As Integer = 4
	Const MAX_CHANNELS As Integer = 16
	Const CMD As Short = &H820s 'Command word for message
	Const frametime As Integer = 100000 'Frame time in microseconds
	
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
    Dim BCList As UInteger
    Dim Data(31) As UShort
    Dim Result As Integer
	Dim j As Short
	
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

        List1.Items.Clear()

        BTICard_CardReset((hCore))

        'Configure the channel for bus controller mode.
        errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while while configuring for bus controller mode")
            Exit Sub
        End If

        '  Create the FIFO List Buffer.
        BCList = BTI1553_BCCreateList(LISTCRT1553_FIFO, 100, MSGCRT1553_DEFAULT, CMD, 0, 0, hCore)
        If (BCList = 0) Then
            MsgBox("Error:  An error was encountered while while creating the list buffer")
            Exit Sub
        End If

        '  Schedule the messages to create the desired bus controller schedule.
        Call BTI1553_BCSchedFrame(frametime, channum, hCore)
        Call BTI1553_BCSchedMsg(BCList, channum, hCore)

        '  Initialize the list with data words to ramp through.
        For j = 0 To 31
            Data(j) = 0
        Next

        Do
            List1.Items.Add(CStr("Wrote data value " & Hex(Data(0)) & "H"))
            Result = BTI1553_ListDataWr(Data(0), 32, BCList, hCore)
            Data(0) = CUShort(Data(0) + 1)
        Loop Until Result = 0

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
		
		Do 
			Result = BTI1553_ListDataWr(Data(0), 32, BCList, hCore)
		Loop Until Result <> 0
		
		List1.Items.Add(CStr("Wrote data value " & Hex(Data(0)) & "H"))
		
        Data(0) = CUShort(Data(0) + 1)
		
	End Sub
End Class