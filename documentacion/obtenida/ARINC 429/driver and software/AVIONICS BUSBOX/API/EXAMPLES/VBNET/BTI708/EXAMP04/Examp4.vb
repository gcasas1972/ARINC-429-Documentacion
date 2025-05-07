Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI708 DRIVER VB_EXAMPLE 4  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP4 -- Record to file example
	'
	'  This program opens Card Number 0, and configures the
	'  first compatible core to record it's receive data to the
	'  Sequential Monitor.  The program then writes the data
	'  to a file (EXAMP4.DAT).
	'
    '  An Event Log frequency of 0 is specified, which will
    '  not generate any Event Log List entries for these channels.
	'
	'  The program will continue to record data to the file
	'  until the stop button is pressed.
	'
	'  Note: Running this program for a long time could cause the file
	'  being written to become very large.  Please be cautious while
	'  running this example.
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
    Dim rcvchan As Integer
    Dim bSkipRun As Boolean
    Dim bCardRunning As Boolean

    Dim fileNum As Integer
    Dim cursor_Renamed As Short

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
        FileClose(fileNum)

        ' End Program
        End

    End Sub

    Private Sub CmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdStart.Click

        If bSkipRun Then
            Exit Sub
        End If

        BTICard_CardReset((hCore))

        ' Configure receive channel.
        errval = BTI708_ChConfig(CHCFG708_SEQALL, rcvchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
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

        'Configure the Sequential Monitor.
        errval = BTICard_SeqConfig(SEQCFG_DEFAULT, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the sequential monitor on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Attempt to open the user specified file
        If CBool(Len(FileName.Text)) Then
            fileNum = FreeFile()
            FileOpen(fileNum, FileName.Text, OpenMode.Binary, OpenAccess.Write)
        Else
            MsgBox("Error:  No File Name was given")
            bSkipRun = True
            Exit Sub
        End If

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting core #" & corenum)
            bSkipRun = True
            Exit Sub
        End If

        bCardRunning = True
        CmdStart.Enabled = False
        CmdStop.Enabled = True
        Result1.Text = "Card Running"
        cursor_Renamed = 0

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
        FileClose(fileNum)

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

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            MsgBox("Error: Unable to open card number " & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first ARINC 708 core with a receive channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For rcvchan = 0 To MAX_CHANNELS - 1
                    If CBool(BTI708_ChIsRcv(rcvchan, hCore)) Then
                        Exit For
                    End If
                Next
                If rcvchan < MAX_CHANNELS Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 708 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        ChanLbl.Text = "Using ARINC 708 receive channel #" & rcvchan

        'Set flag so we run hardware
        bSkipRun = False

        CmdStart.Enabled = True
        CmdStop.Enabled = False
        Exit Sub
ErrHandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub



    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
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
        If (0 = seqcount) Then
            Exit Sub
        End If

        errval = BTICard_SeqFindInit(seqbuf(0), CUInt(seqcount), sfinfo)
        If (0 > errval) Then
            MsgBox("Error: SeqFindInit failed")
            bSkipRun = True
            Exit Sub
        End If

        While (0 <= BTICard_SeqFindNext708Ex(rec708, CUShort(Len(rec708)), sfinfo))
            If cursor_Renamed = 1 Then
                str_Renamed = "Writing... b|"
            ElseIf cursor_Renamed = 2 Then
                str_Renamed = "Writing... b/"
            ElseIf cursor_Renamed = 3 Then
                str_Renamed = "Writing... b-"
            Else
                str_Renamed = "Writing... b\"
                cursor_Renamed = 0
            End If
            Result2.Text = str_Renamed
            cursor_Renamed = CShort(cursor_Renamed + 1)

            'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(fileNum, rec708.data) 'Write data to file
        End While

    End Sub
End Class