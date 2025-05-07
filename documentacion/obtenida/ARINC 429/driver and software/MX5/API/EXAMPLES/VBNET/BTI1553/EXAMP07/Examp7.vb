Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI1553 DRIVER VB.NET BTI1553 EXAMPLE 7  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP7 -- Errors in BC Transmissions - Scheduled Messages
	'
	'  This example requires a Ballard 1553 C version Device or higher.
	'  It configures Card Number 0 as a BC and creates a schedule
	'  containing a receive command each for terminal address 1
	'  and terminal address 2.  Both receive commands send 2 data
	'  words to the remote terminal.  The example then alternates
	'  a bit count error between the first data word of both
	'  commands.
	'
	
	
	' Constants
    Const CARDNUM As Integer = 0
	Const MAX_CORES As Integer = 4
	Const MAX_CHANNELS As Integer = 16
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
    Dim BCMsgs(1) As UInteger
    Dim ErrorCount As Integer
    Dim InitialData1 As UShort
    Dim InitialData2 As UShort
	
	Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdExit.Click
		If (hCore >= 0) Then
            errval = BTICard_CardClose(hCore)
        End If

        ' End Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click
        ErrorCount = 0

        If bSkipRun Then
            Exit Sub
        End If

        BTICard_CardReset((hCore))

        errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while while configuring for bus controller mode")
            bSkipRun = True
            Exit Sub
        End If

        ' Create the message records
        BCMsgs(0) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, &H842S, 0, InitialData1, hCore)
        BCMsgs(1) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, &H1042S, 0, InitialData2, hCore)

        '  Schedule the messages to create the desired bus controller schedule.
        Call BTI1553_BCSchedFrame(frametime, channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
        Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)

        '  Define the type of error generation.  One of the bus
        '  controller messages is tagged to generate errors once.
        Call BTI1553_ErrorDefine(ERRDEF1553_CNTBIT, 3, 2, 0, 0, channum, hCore)
        Call BTI1553_ErrorTagBC(1, BCMsgs(0), channum, hCore)
        Call BTI1553_ErrorCtrl(ERRCTRL1553_ONCE Or ERRCTRL1553_TAGMSG, channum, hCore)

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
        CmdStart.Enabled = False
        CmdStop.Enabled = False
        bSkipRun = False
        bCardRunning = False
        Result1.Text = ""

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If CBool(errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

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

        If CBool(BTI1553_ChIsC(channum, hCore)) Then
            Channel.Text = "Using 1553 version C channel #" & CStr(channum)
        ElseIf CBool(BTI1553_ChIsD(channum, hCore)) Then
            Channel.Text = "Using 1553 version D channel #" & CStr(channum)
        Else
            MsgBox("Error:  Example required a 1553 C or D version channel")
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum

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
		
		'  When the error is generated once, tag another message for
		'  error generation and enable another single error.
		
        If CBool(BTI1553_ErrorSent(channum, hCore)) Then
            ErrorCount = ErrorCount + 1 ' Inc the ErrorCount
            If CBool(ErrorCount And 1) Then
                Call BTI1553_ErrorTagBC(0, BCMsgs(0), channum, hCore)
                Call BTI1553_ErrorTagBC(1, BCMsgs(1), channum, hCore)
            Else
                Call BTI1553_ErrorTagBC(1, BCMsgs(0), channum, hCore)
                Call BTI1553_ErrorTagBC(0, BCMsgs(1), channum, hCore)
            End If

            Call BTI1553_ErrorCtrl(ERRCTRL1553_ONCE Or ERRCTRL1553_TAGMSG, channum, hCore)

            ' Update the display
            Result1.Text = "Error Count = " & CStr(ErrorCount)
        End If
		
	End Sub
End Class