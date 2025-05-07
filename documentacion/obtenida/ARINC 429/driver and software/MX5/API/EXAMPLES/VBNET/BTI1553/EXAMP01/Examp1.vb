Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI1553 DRIVER VB.NET BTI1553 EXAMPLE 1  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP1 -- Simulating the BC - Unscheduled Messages
	'
	'  This example configures Card Number 0 as a BC to transmit
	'  the receive command 0843(Hex) with data words 1234(Hex), 5678(Hex),
	'  and 9ABC(Hex).  If the message is completed successfully, it
	'  displays the responding RT's status word.  Otherwise it
	'  displays the value of any errors.
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
	'UPGRADE_WARNING: Arrays in structure Msg may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Dim Msg As XMITFIELDS1553
	Dim infoval As Integer
	
	Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdExit.Click
		If (hCore >= 0) Then
            errval = BTICard_CardClose(hCore)
        End If

        ' End Program
        End

    End Sub

    Private Sub CmdSend_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdSend.Click

        If bSkipRun Then
            Exit Sub
        End If

        BTICard_CardReset((hCore))

        'Configure the channel for bus controller mode.
        errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while while configuring for bus controller mode")
            Exit Sub
        End If

        '  Create an empty frame in the BC Schedule.
        '
        '  BTI1553_BCTransmitMsg uses an asynchronous Message Record
        '  that is transmitted at the end of every frame.  Therefore,
        '  even though we aren't scheduling messages, we must still
        '  schedule a frame.

        Call BTI1553_BCSchedFrame(1000, channum, hCore)

        CmdSend.Enabled = False

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting the card")
            bSkipRun = True
            Exit Sub
        End If

        '  Initialize the message command and data words, and select
        '  a BC-RT transfer.

        Msg.ctrlflags = MSGCRT1553_BCRT ' Selects BC->RT transfer
        Msg.cwd1 = BTI1553_ValPackCWD(1, 0, 2, 3) ' Receive command word
        Msg.data = New UShort(31) {}
        Msg.data(0) = &H1234S ' Data word 0
        Msg.data(1) = &H5678S ' Data word 1
        Msg.data(2) = CUShort(&H9ABC) ' Data word

        '   Transmit the message
        errval = BTI1553_BCTransmitMsg(Msg, channum, hCore)

        '  Test for any error results.
        '
        '  Note the distinction between card errors and bus errors.
        '  The returned value of BTI1553_BCTransmitMsg is a card error
        '  (if any occurred).  Errors related to the RT's response are
        '  returned in the (errflags) member of the message
        '  structure.

        If errval < 0 Then
            Result1.Text = "Error: An error was encountered " & errval & " while transmitting the message."
        End If

        If CBool((Msg.errflags And MSGERR1553_NORESP)) Then ' Was there a response?
            Result1.Text = "Warning:  No response was received from the RT. Refer to the documentation for a description of the error flags (" & Hex(Msg.errflags) & ")"
        ElseIf CBool((Msg.errflags And MSGERR1553_ANYERR)) Then  ' Was there an error?
            Result1.Text = "Warning:  An error occurred while receiving the response from the RT. Refer to the documentation for a description of the error flags (" & Hex(Msg.errflags) & ")"
        Else ' There were no errors
            Result1.Text = "Success!  The message was completed successfully. The RT returned the status word " & Hex(Msg.swd1)
        End If

        ' Stop the card
        BTICard_CardStop(hCore)
        CmdSend.Enabled = True

    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Errhandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        bSkipRun = False
        bCardRunning = False
        CmdSend.Enabled = False

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

        CmdSend.Enabled = True

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
End Class