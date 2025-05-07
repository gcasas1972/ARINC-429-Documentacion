VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   Caption         =   "BTI708 Example 5"
   ClientHeight    =   5040
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6975
   LinkTopic       =   "Form1"
   ScaleHeight     =   5040
   ScaleWidth      =   6975
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   3360
      Top             =   4560
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton CmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   6120
      TabIndex        =   6
      Top             =   4560
      Width           =   735
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   5
      Top             =   4560
      Width           =   735
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   960
      TabIndex        =   4
      Top             =   4560
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   10
      Left            =   2760
      Top             =   4560
   End
   Begin VB.TextBox FileName 
      Height          =   405
      Left            =   960
      TabIndex        =   3
      Text            =   "EXAMP5.DAT"
      ToolTipText     =   "file name or full path"
      Top             =   3840
      Width           =   5295
   End
   Begin VB.CommandButton CmdBrouse 
      Caption         =   "..."
      Height          =   375
      Left            =   6360
      TabIndex        =   2
      Top             =   3840
      Width           =   495
   End
   Begin VB.TextBox frequency 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   1033
         SubFormatType   =   1
      EndProperty
      Height          =   375
      Left            =   1560
      TabIndex        =   1
      Text            =   "Text1"
      Top             =   3240
      Width           =   735
   End
   Begin VB.TextBox blocksize 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   1033
         SubFormatType   =   1
      EndProperty
      Height          =   375
      Left            =   4080
      TabIndex        =   0
      Text            =   "Text2"
      Top             =   3240
      Width           =   1095
   End
   Begin VB.Line Line2 
      X1              =   1260
      X2              =   5700
      Y1              =   1755
      Y2              =   1755
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP5    (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   1260
      TabIndex        =   21
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   1260
      TabIndex        =   20
      Top             =   960
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   1260
      TabIndex        =   19
      Top             =   1200
      Width           =   4335
   End
   Begin VB.Label Header6 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   1260
      TabIndex        =   18
      Top             =   1440
      Width           =   4335
   End
   Begin VB.Line Line1 
      X1              =   1260
      X2              =   5700
      Y1              =   360
      Y2              =   360
   End
   Begin VB.Label Header3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   1260
      TabIndex        =   17
      Top             =   720
      Width           =   4335
   End
   Begin VB.Label Header1 
      Caption         =   "Transmitter file playback example"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   1
      Left            =   1680
      TabIndex        =   16
      Top             =   0
      Width           =   3615
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   1380
      TabIndex        =   15
      Top             =   1800
      Width           =   4215
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   255
      Left            =   1380
      TabIndex        =   14
      Top             =   2400
      Width           =   4215
   End
   Begin VB.Label ChanLbl 
      Caption         =   "ChanLbl"
      Height          =   255
      Left            =   1380
      TabIndex        =   13
      Top             =   2040
      Width           =   4215
   End
   Begin VB.Label Label1 
      Caption         =   "File Name:"
      Height          =   255
      Left            =   120
      TabIndex        =   12
      Top             =   3960
      Width           =   855
   End
   Begin VB.Label Result2 
      Caption         =   "Result2"
      Height          =   255
      Left            =   1380
      TabIndex        =   11
      Top             =   2760
      Width           =   4215
   End
   Begin VB.Label Label2 
      Caption         =   "Frequency"
      Height          =   375
      Left            =   720
      TabIndex        =   10
      Top             =   3240
      Width           =   855
   End
   Begin VB.Label Label3 
      Caption         =   "Block Size"
      Height          =   255
      Left            =   3240
      TabIndex        =   9
      Top             =   3240
      Width           =   855
   End
   Begin VB.Label Label4 
      Caption         =   "Hz"
      Height          =   255
      Left            =   2400
      TabIndex        =   8
      Top             =   3240
      Width           =   615
   End
   Begin VB.Label Label5 
      Caption         =   "frames"
      Height          =   255
      Left            =   5280
      TabIndex        =   7
      Top             =   3240
      Width           =   855
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI708 DRIVER VB_EXAMPLE 5  (06/07/2011)
'  Copyright (c) 2002-2011
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
'  An Event Log frequency of 32 is specifed, which will
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

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

' Card specific
Dim hCard As Long
Dim hCore As Long
Dim ERRVAL As Long
Dim errstr As String
Dim corenum As Long
Dim xmtchan As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean

' Program specific
Dim FRAMECOUNT As Integer
Dim fileNum As Integer
Dim Result As Integer
Dim j As Integer
Dim jj As Integer

Private Sub CmdBrouse_Click()
    On Error GoTo ErrHandler
    
    CommonDialog1.Filter = "Data Files (*.DAT)|*.DAT"   ' Set Filters
    CommonDialog1.FilterIndex = 1                       ' Specify default filter
    CommonDialog1.InitDir = App.Path                    ' Specify initial path
    CommonDialog1.ShowOpen                              ' Display the Open dialog box
    
    ' Update fileName text
    FileName.Text = CommonDialog1.FileName
    
    Exit Sub
ErrHandler:
    ' User pressed Cancel button
    Exit Sub
End Sub

Private Sub CmdExit_Click()
    If (hCard >= 0) Then
        ERRVAL = BTICard_CardClose(hCard)
    End If
    
    ' Close I/O file
    Close #fileNum
      
    ' End Program
    End
    
End Sub

Private Sub CmdStart_Click()

    If bSkipRun Then
        Exit Sub
    End If
    
    ' Calculate the framecount from the blocksize
    If Len(blocksize.Text) Then
        FRAMECOUNT = CLng(blocksize.Text) * 2
    Else
        MsgBox "Enter a block size (default=32)"
        Exit Sub
    End If
    
    BTICard_CardReset (hCore)
     
    ' Configure transmit channel.
    ERRVAL = BTI708_ChConfig(CHCFG708_DEFAULT, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Build the transmit channel messages.
    ERRVAL = BTI708_XmtBuild(MSGCRT708_DEFAULT, CLng(frequency.Text), CLng(blocksize.Text), FRAMECOUNT, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while building" & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Attempt to open the user specified file
    If Len(FileName.Text) Then
        fileNum = FreeFile()
        Result = GetAttr(FileName.Text)
        Open FileName.Text For Binary Access Read As #fileNum
    Else
        MsgBox "Error:  No File Name was given"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Preload two blocks of data from the file to the card.
    Dim Data(99) As Integer
    For j = 0 To (FRAMECOUNT - 1)
        If EOF(fileNum) Then
            Get fileNum, 1, Data    'Reset file pointer to first record
            Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write the data for frame
        Else
            Get fileNum, , Data
            Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write the data for frame
        End If
    Next
    
    ' Configure the Event Log list.
    ERRVAL = BTICard_EventLogConfig(LOGCFG_ENABLE, 1024, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "the event log on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while starting core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    CmdStart.Enabled = False
    CmdStop.Enabled = True
    Result1.Caption = "Card Running"
    
End Sub

Private Sub CmdStop_Click()
    'Clear state of bRunning before card is stopped (so timer event is not processed)
    Dim bTemp As Boolean
    bTemp = bCardRunning
    bCardRunning = False
        
    If (bTemp = True) Then
        BTICard_CardStop (hCore)
    End If
    
    ' Close I/O file
    Close #fileNum
    
    CmdStart.Enabled = True
    CmdStop.Enabled = False
    Result1.Caption = "Card Stopped"
    Result2.Caption = ""
End Sub

Private Sub Form_Load()
    On Error GoTo ErrHandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    CmdStart.Enabled = False
    CmdStop.Enabled = False
    bSkipRun = False
    bCardRunning = False
    Result1.Caption = "Card Stopped"
    Result2.Caption = ""
    frequency.Text = "200"
    blocksize.Text = "32"
    
   ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        errstr = "Error: Unable to open card number " & cardnum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first ARINC 708 core with a transmit channel
    For corenum = 0 To MAX_CORES - 1
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For xmtchan = 0 To MAX_CHANNELS - 1
                If BTI708_ChIsXmt(xmtchan, hCore) Then
                   Exit For
                End If
            Next
            If xmtchan < MAX_CHANNELS Then
                Exit For
            End If
        End If
    Next
    
    If (ERRVAL <> 0) Or (corenum >= MAX_CORES) Or (xmtchan >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible ARINC 708 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    ChanLbl.Caption = "Using ARINC 708 transmit channel #" & xmtchan
    
    'Set flag so we run hardware
    bSkipRun = False
    
    CmdStart.Enabled = True
    CmdStop.Enabled = False
    Exit Sub
ErrHandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub Timer1_Timer()
    Dim eventType As Integer
    Dim info As Long
    Dim logchan As Long
    Dim framenum As Integer
    Dim j As Long
    Dim jj As Long
    Dim Data(99) As Integer
    
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If

    '
    ' Read entry from Event Log list
    '
    
    If BTICard_EventLogRd(eventType, info, logchan, hCore) Then
        framenum = info
        
        If framenum = ((FRAMECOUNT / 2) - 1) Then                   'First half transmitted
            Result2.Caption = "Updating frames 0 - " & framenum
            For j = 0 To framenum
                If EOF(fileNum) Then
                    Get fileNum, 1, Data    'Reset file pointer to first record
                    Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write the data for frame
                Else
                    Get fileNum, , Data
                    Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write the data for frame
                End If
            Next
        ElseIf framenum = (FRAMECOUNT - 1) Then                     'Second half transmitted
            Result2.Caption = "Updating frames " & (FRAMECOUNT / 2) & " - " & framenum
            For j = (FRAMECOUNT / 2) To framenum
                If EOF(fileNum) Then
                    Get fileNum, 1, Data    'Reset file pointer to first record
                    Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write the data for frame
                Else
                    Get fileNum, , Data
                    Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write the data for frame
                End If
            Next
        End If
    End If

End Sub

