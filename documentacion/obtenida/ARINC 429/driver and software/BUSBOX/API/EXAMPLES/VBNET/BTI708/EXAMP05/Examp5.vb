Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI708 DRIVER VB_EXAMPLE 5  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP5 -- Transmitter file playback example
	'
	'  This program opens Card Number 0, and configures the
	'  first compatible core to transmit a sequence of 64
	'  messages at a rate of 200Hz.  The messages are
	'  automatically assigned the numbers 0 through 63.
	'
	'  A data file is used to source the data to transmit
	'  on the bus.
	'
    '  An Event Log frequency of 32 is specified, which will
	'  cause the channel to issue an Event Log List entry
	'  every 32nd message (message numbers 31, and 63).
	'  The program uses these events to update the data for
	'  the half of messages that were just transmitted.
	'
	'  Data from the data file are read until the end of the file
	'  is reached.  Once reached, the program will seek to the
	'  start of the file and transmit the file again.
	'
	'  The program continues in this manner until the stop button
	'  is pressed.
	'
	
	
	' Constants
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    ' Card specific
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim errval As Integer
    Dim errstr As String
    Dim corenum As Integer
    Dim xmtchan As Integer
    Dim bSkipRun As Boolean
    Dim bCardRunning As Boolean

    ' Program specific
    Dim framecount As Short
    Dim fs As IO.FileStream
    Dim j As UShort
    Dim jj As UShort

    Private Sub CmdBrouse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdBrouse.Click
        On Error GoTo ErrHandler

        'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        CommonDialog1Open.Filter = "Data Files (*.DAT)|*.DAT" ' Set Filters
        CommonDialog1Open.FilterIndex = 1 ' Specify default filter
        CommonDialog1Open.InitialDirectory = My.Application.Info.DirectoryPath ' Specify initial path
        CommonDialog1Open.ShowDialog() ' Display the Open dialog box

        ' Update fileName text
        FileName.Text = CommonDialog1Open.FileName

        Exit Sub
ErrHandler:
        ' User pressed Cancel button
        Exit Sub
    End Sub

    Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdExit.Click
        If (hCard >= 0) Then
            errval = BTICard_CardClose(hCard)
        End If

        ' Close I/O file
        fs.Close()

        ' End Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click

        If bSkipRun Then
            Exit Sub
        End If

        ' Calculate the framecount from the blocksize
        If CBool(Len(blocksize.Text)) Then
            framecount = CShort(CShort(blocksize.Text) * 2)
        Else
            MsgBox("Enter a block size (default=32)")
            Exit Sub
        End If

        BTICard_CardReset((hCore))

        ' Configure transmit channel.
        errval = BTI708_ChConfig(CHCFG708_DEFAULT, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Build the transmit channel messages.
        errval = BTI708_XmtBuild(MSGCRT708_DEFAULT, CUShort(frequency.Text), CInt(blocksize.Text), framecount, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while building" & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Attempt to open the user specified file
        If CBool(Len(FileName.Text)) Then
            fs.Close()
            fs = New IO.FileStream(FileName.Text, IO.FileMode.Open, IO.FileAccess.Read)
        Else
            MsgBox("Error:  No File Name was given")
            bSkipRun = True
            Exit Sub
        End If

        ' Preload two blocks of data from the file to the card.
        Dim Data(99) As UShort
        Dim breader As New IO.BinaryReader(fs)

        For j = 0 To CUShort((framecount - 1))
            'Fill the array
            For jj = 0 To 99
                'Reset the file pointer to first record
                If (fs.Position >= fs.Length) Then
                    fs.Seek(0, IO.SeekOrigin.Begin) 'Reset file pointer to first record
                End If

                Data(jj) = breader.ReadUInt16()
            Next
            'Write the data for frame
            Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write the data for frame
        Next

        ' Configure the Event Log list.
        errval = BTICard_EventLogConfig(LOGCFG_ENABLE, 1024, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the event log on core #" & corenum
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

        ' Close I/O file
        fs.Close()

        CmdStart.Enabled = True
        CmdStop.Enabled = False
        Result1.Text = "Card Stopped"
        Result2.Text = ""
    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrHandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        CmdStart.Enabled = False
        CmdStop.Enabled = False
        bSkipRun = False
        bCardRunning = False
        Result1.Text = "Card Stopped"
        Result2.Text = ""
        frequency.Text = "200"
        blocksize.Text = "32"

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            errstr = "Error: Unable to open card number " & CARDNUM
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first ARINC 708 core with a transmit channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
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

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (xmtchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 708 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        ChanLbl.Text = "Using ARINC 708 transmit channel #" & xmtchan

        'Set flag so we run hardware
        bSkipRun = False

        CmdStart.Enabled = True
        CmdStop.Enabled = False
        Exit Sub
ErrHandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Dim eventType As UShort
        Dim info As UInteger
		Dim logchan As Integer
        Dim framenum As UShort
        Dim j As UShort
        Dim jj As UShort
        Dim Data(99) As UShort
        Dim breader As New IO.BinaryReader(fs)
		
		If (bSkipRun = True) Or (bCardRunning = False) Then
			Exit Sub
		End If
		
		'
		' Read entry from Event Log list
		'
		
        If CBool(BTICard_EventLogRd(eventType, info, logchan, hCore)) Then
            framenum = CUShort(info)

            If framenum = ((framecount / 2) - 1) Then 'First half transmitted
                Result2.Text = "Updating frames 0 - " & framenum
                For j = 0 To framenum
                    'Fill the array
                    For jj = 0 To 99
                        'Reset the file pointer to first record
                        If (fs.Position >= fs.Length) Then
                            fs.Seek(0, IO.SeekOrigin.Begin) 'Reset file pointer to first record
                        End If

                        Data(jj) = breader.ReadUInt16()
                    Next
                    'Write the data for frame
                    Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write the data for frame
                Next
            ElseIf framenum = (framecount - 1) Then  'Second half transmitted
                Result2.Text = "Updating frames " & (framecount / 2) & " - " & framenum
                For j = CUShort((framecount / 2)) To framenum
                    'Fill the array
                    For jj = 0 To 99
                        'Reset the file pointer to first record
                        If (fs.Position >= fs.Length) Then
                            fs.Seek(0, IO.SeekOrigin.Begin) 'Reset file pointer to first record
                        End If

                        Data(jj) = breader.ReadUInt16()
                    Next
                    'Write the data for frame
                    Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write the data for frame
                Next
            End If
        End If
		
	End Sub
End Class