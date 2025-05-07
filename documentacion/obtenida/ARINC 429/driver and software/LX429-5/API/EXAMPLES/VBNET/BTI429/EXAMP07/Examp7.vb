Option Strict On
Option Explicit On

Friend Class Form1
	Inherits System.Windows.Forms.Form
	'
    '  BTI429 DRIVER VB_EXAMPLE 7  (06/07/2011)
    '  Copyright (c) 2009-2011
	'  Ballard Technology, Inc.
	'  www.ballardtech.com
	'  support@ballardtech.com
	'  ALL RIGHTS RESERVED
	'
	'  NAME:   EXAMP7 -- File transfer example
	'
	'  This program opens Card Number 0, finds the first
	'  compatible core, and configures an asynchronous transmit
	'  list buffer.  The program reads a data file and transmits
	'  that data with a user specified label.  If no data file
    '  or label is specified by the user the default values are
	'  examp7.dat, and label 0172.
	'
	
	
    Const CARDNUM As Integer = 0
    Const MAX_CORES As Integer = 4
    Const MAX_CHANNELS As Integer = 16

    Dim bCardRunning As Boolean
    Dim bSkipRun As Boolean
    Dim hCard As UInteger
    Dim hCore As UInteger
    Dim corenum As Integer
    Dim errval As Integer
    Dim errstr As String
    Dim xmtchan As Integer
    Dim fileNum As Integer
    Dim asynclistaddr As UInteger
    Dim Data As Integer

    Private Sub CmdBrouse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdBrouse.Click
        On Error GoTo ErrHandler

        'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        CommonDialog1Open.Filter = "Data Files (*.DAT)|*.DAT" ' Set Filters
        CommonDialog1Open.FilterIndex = 1 ' Specify default filter
        CommonDialog1Open.InitialDirectory = My.Application.Info.DirectoryPath ' Specify initial path
        CommonDialog1Open.ShowDialog() ' Display the Open dialog box

        ' Update fileName text
        fileName.Text = CommonDialog1Open.FileName

        Exit Sub
ErrHandler:
        ' User pressed Cancel button
        Exit Sub
    End Sub

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click
        If (hCard >= 0) Then
            errval = BTICard_CardClose(hCard)
        End If

        ' Close I/O file
        FileClose(fileNum)

        ' End Program
        End

    End Sub

    Private Sub cmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStart.Click
        On Error GoTo ErrHandler

        If (bSkipRun = True) Then
            Exit Sub
        End If

        ' Attempt to open the user specified file
        fileNum = FreeFile()
        Dim Result As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object Result. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Result = GetAttr(fileName.Text)
        FileOpen(fileNum, fileName.Text, OpenMode.Binary, OpenAccess.Read)

        ' Read in labelNum and test
        Dim lblNum As Short
        lblNum = CShort(Val("&O" & labelNum.Text.Trim()))

        If (lblNum < 0) Or (lblNum > 255) Then
            ' Use default lable number
            MsgBox("Error: Using label 0172. User label out of range: " & Oct(lblNum))
            lblNum = &O172S
        End If

        ' Updata the status text
        status1.Text = "Status: Initializing the card"
        status2.Text = ""

        ' Configure xmtchan to transmit at low speed.
        BTICard_CardReset((hCore))
        errval = BTI429_ChConfig(CHCFG429_DEFAULT, xmtchan, hCore)
        If (errval < 0) Then
            errstr = "Error:  An error was encountered while configuring " & vbNewLine
            errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        ' Create the asynchronous list buffer
        asynclistaddr = BTI429_ListAsyncCreate(LISTCRT429_FIFO, 8192, xmtchan, hCore)
        If (asynclistaddr = 0) Then
            errstr = "Error:  An error was encountered while configuring" & vbNewLine
            errstr = errstr & "the list buffer on core #" & corenum
            MsgBox(errstr)
            bSkipRun = True
            Exit Sub
        End If

        '  Next, a schedule is built by creating explicit message timing.
        '  While creating a schedule we can still use the SchedGap() funciton
        '  to create our gap times.  This function will determine that an
        '  asynchronous list buffer has been created for the channel, and will
        '  internally call the SchedGapList() function with appropriate parameters.
        '  Alternatively, we could use the SchedGapList() function directly
        '  and specify the address value ourselves. This method is usefull if
        '  more than one asynchronoous list buffer is desired per channel.

        Call BTI429_SchedGap(1024, xmtchan, hCore)

        ' Start operation of the card.
        errval = BTICard_CardStart(hCore)
        If (errval < 0) Then
            MsgBox("Error:  An error was encountered while starting core #" & corenum)
            bSkipRun = True
            Exit Sub
        End If

        bCardRunning = True
        cmdStart.Enabled = False
        cmdStop.Enabled = True

        ' Updata the status text
        status1.Text = "Status: Loading data on to the card."
        status2.Text = ""

        ' Read data from file and transmit unill end of file or the stop is pressed
        Dim bSuccess As Boolean
        Dim mask As Short

        Do While Not EOF(fileNum)
            ' Read from file
            'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(1, Data)
            ' Mask value
            mask = lblNum And &HFFS
            'data = data And &HFFFFFF00
            Data = CInt(CUInt(Data Or mask))
            ' Write to card
            bSuccess = False
            While (False = bSuccess)
                bSuccess = CBool(BTI429_ListDataWr(CUInt(Data), asynclistaddr, hCore))
            End While
        Loop

        ' Update the status text
        status1.Text = "Status: Finished loading data on to the card."
        status2.Text = "Card may still be transmitting."

        ' Close I/O file
        FileClose(fileNum)

        Exit Sub
ErrHandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub


    Private Sub cmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStop.Click
        'Clear state of bRunning before card is stopped (so timer event is not processed)
        Dim bTemp As Boolean
        bTemp = bCardRunning
        bCardRunning = False

        If (bTemp = True) Then
            BTICard_CardStop(hCore)
        End If

        ' Close I/O file
        FileClose(fileNum)

        ' Update the status text
        status1.Text = "Status: Card stopped."
        status2.Text = ""

        cmdStart.Enabled = True
        cmdStop.Enabled = False

    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrHandler

        'Initialize handle to error condition and bSkipRun
        hCard = 0
        hCore = 0
        bSkipRun = False
        bCardRunning = False
        cmdStart.Enabled = False
        cmdStop.Enabled = False

        ' Open handle to card with specified card number
        errval = BTICard_CardOpen(hCard, CARDNUM)
        If (0 <> errval) Then
            MsgBox("Error: Unable to open card number " & CStr(CARDNUM))
            bSkipRun = True
            Exit Sub
        End If

        ' Find the first 429 core with a transmit channel
        For corenum = 0 To MAX_CORES - 1
            errval = BTICard_CoreOpen(hCore, corenum, hCard)
            If errval = 0 Then
                For xmtchan = 0 To MAX_CHANNELS - 1
                    If 0 <> BTI429_ChIsXmt(xmtchan, hCore) Then
                        Exit For
                    End If
                Next
                If xmtchan < MAX_CHANNELS Then
                    Exit For
                End If
            End If
        Next

        If (errval <> 0) Or (corenum >= MAX_CORES) Or (xmtchan >= MAX_CHANNELS) Then
            MsgBox("Error:  No compatible ARINC 429 core present in card #" & CARDNUM)
            bSkipRun = True
            Exit Sub
        End If

        Core.Text = "Using core #" & corenum
        Transmit.Text = "Using transmit channel #" & xmtchan

        'Set flag so we run hardware
        bSkipRun = False

        cmdStart.Enabled = True
        cmdStop.Enabled = False

        ' Update the status text
        status1.Text = "Status: Card stopped."
        status2.Text = ""

        ' Set the default name in fileName and set to ReadOnly
        fileName.Text = My.Application.Info.DirectoryPath & "\EXAMP7.DAT"
        fileName.ReadOnly = True

        Exit Sub
ErrHandler:
        MsgBox("An Error Has Occured:  " & Err.Description)

    End Sub
	
	Private Sub labelNum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles labelNum.KeyPress
        Dim KeyAscii As Integer = Asc(eventArgs.KeyChar)
		' Only accept octal digits and the backspace characters
		If KeyAscii = 8 Then ' Backspace character
			GoTo EventExitSub
		End If
		If KeyAscii < Asc("0") Or KeyAscii > Asc("7") Then
			KeyAscii = 0 ' Cancel the character
			Beep() ' Sound error signal
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class