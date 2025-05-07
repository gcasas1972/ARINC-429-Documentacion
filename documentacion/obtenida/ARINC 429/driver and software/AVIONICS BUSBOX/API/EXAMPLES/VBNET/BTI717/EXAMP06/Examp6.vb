Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI717 DRIVER VB_EXAMPLE 6  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP6 -- Multiple Core Example
	'
	'  This program opens Card Number 0 and configures all
	'  ARINC 717 cores to receive on all BiPhase channels.
	'  Program reports when each BiPhase channel is in sync.
	'
	
	' Force explicit declaration of all variables
	
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Dim bCardRunning As Boolean
    Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCores(MAX_CORES - 1) As UInteger
    Dim bCores(MAX_CORES - 1) As Boolean
    Dim errval As Integer
    Dim errstr As String
    Dim corecount As Integer
    Dim corenum As Integer
    Dim chan As Integer

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

        '  Clear list
        List1.Items.Clear()
        Status.Text = ""

        '
        '  Configure all receive channels  for auto speed detection.
        '

        For corenum = 0 To (MAX_CORES - 1)
            If bCores(corenum) Then
                BTICard_CardReset((hCores(corenum)))

                For chan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI717_ChIsType(CHCFG717_BIPHASERCV, chan, hCores(corenum))) Then
                        errval = BTI717_ChConfig(CHCFG717_BIPHASERCV Or CHCFG717_AUTOSPEED, chan, hCores(corenum))
                        If (errval < 0) Then
                            errstr = "Error:  An error was encounted while configuring" & vbNewLine
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

        '
        ' Sync all channels on all cores
        '

        For corenum = 0 To (MAX_CORES - 1)
            If bCores(corenum) Then
                For chan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI717_ChIsType(CHCFG717_BIPHASERCV, chan, hCores(corenum))) Then
                        Status.Text = "Synchronizing channel " & chan & " on core " & corenum & " to bit stream...."
                        While 0 = BTI717_SyncTest(chan, hCores(corenum))
                        End While
                        List1.Items.Add(CStr("Channel " & chan & " on core " & corenum & "now In Sync!"))
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub cmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStop.Click
        bCardRunning = False

        For corenum = 0 To (MAX_CORES - 1)
            BTICard_CardStart(hCores(corenum))
        Next

        cmdStart.Enabled = True
        cmdStop.Enabled = False
        Status.Text = ""

    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Errhandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        bSkipRun = False
        bCardRunning = False
        cmdStart.Enabled = False
        cmdStop.Enabled = False
        Status.Text = ""

        For corenum = 0 To (MAX_CORES - 1)
            hCores(corenum) = 0
            bCores(corenum) = False
        Next

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, cardnum)
        If CBool(errval) Then
            MsgBox("Error: can not open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find all ARINC 717 cores on the board
        corecount = 0
        For corenum = 0 To (MAX_CORES - 1)
            errval = BTICard_CoreOpen(hCores(corenum), corenum, hCard)
            If errval = 0 Then
                For chan = 0 To (MAX_CHANNELS - 1)
                    If CBool(BTI717_ChIsType(CHCFG717_BIPHASERCV, chan, hCores(corenum))) Then
                        bCores(corenum) = True
                        corecount = corecount + 1
                        Exit For
                    End If
                Next
            End If
        Next

        If corecount = 0 Then
            MsgBox("Error:    Unable to find any ARINC 717 cores on card #" & cardnum)
            bSkipRun = True
            Exit Sub
        End If

        ' Init output list 1
        List1.Items.Clear()

        'Set flag so we run hardware
        bSkipRun = False

        cmdStart.Enabled = True
        cmdStop.Enabled = False

        Exit Sub
Errhandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
End Class