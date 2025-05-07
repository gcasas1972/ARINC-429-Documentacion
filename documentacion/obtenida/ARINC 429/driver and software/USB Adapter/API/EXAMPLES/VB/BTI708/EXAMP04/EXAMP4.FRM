VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   Caption         =   "BTI708 Example 4"
   ClientHeight    =   4365
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6960
   LinkTopic       =   "Form1"
   ScaleHeight     =   4365
   ScaleWidth      =   6960
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   3240
      Top             =   3840
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton CmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   6120
      TabIndex        =   4
      Top             =   3840
      Width           =   735
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   3
      Top             =   3840
      Width           =   735
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   960
      TabIndex        =   2
      Top             =   3840
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   10
      Left            =   2640
      Top             =   3840
   End
   Begin VB.TextBox FileName 
      Height          =   285
      Left            =   960
      TabIndex        =   1
      Text            =   "EXAMP.DAT"
      ToolTipText     =   "file name or full path"
      Top             =   3240
      Width           =   5295
   End
   Begin VB.CommandButton CmdBrouse 
      Caption         =   "..."
      Height          =   375
      Left            =   6360
      TabIndex        =   0
      Top             =   3120
      Width           =   495
   End
   Begin VB.Line Line2 
      X1              =   653
      X2              =   6293
      Y1              =   1755
      Y2              =   1755
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP4     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   1253
      TabIndex        =   15
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   1253
      TabIndex        =   14
      Top             =   960
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   1253
      TabIndex        =   13
      Top             =   1200
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   1253
      TabIndex        =   12
      Top             =   1440
      Width           =   4335
   End
   Begin VB.Line Line1 
      X1              =   653
      X2              =   6293
      Y1              =   360
      Y2              =   360
   End
   Begin VB.Label Label2 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   1253
      TabIndex        =   11
      Top             =   720
      Width           =   4335
   End
   Begin VB.Label Header1 
      Caption         =   "Record to file example"
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
      Left            =   2273
      TabIndex        =   10
      Top             =   0
      Width           =   2415
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   1373
      TabIndex        =   9
      Top             =   1920
      Width           =   4215
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   255
      Left            =   1373
      TabIndex        =   8
      Top             =   2520
      Width           =   4215
   End
   Begin VB.Label ChanLbl 
      Caption         =   "ChanLbl"
      Height          =   255
      Left            =   1373
      TabIndex        =   7
      Top             =   2160
      Width           =   4215
   End
   Begin VB.Label Label1 
      Caption         =   "File Name:"
      Height          =   255
      Left            =   120
      TabIndex        =   6
      Top             =   3360
      Width           =   855
   End
   Begin VB.Label Result2 
      Caption         =   "Result2"
      Height          =   255
      Left            =   1373
      TabIndex        =   5
      Top             =   2880
      Width           =   4215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI708 DRIVER VB_EXAMPLE 4  (06/07/2011)
'  Copyright (c) 2002-2011
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
'  An Event Log frequency of 0 is specifed, which will
'  not generate any Event Log List entries for thess channels.
'
'  The program will continue to record data to the file
'  until the stop button is pressed.
'
'  Note: Running this program for a long time could cause the file
'  being written to become very large.  Please be cautious while
'  running this example.
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
Dim rcvchan As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean

Dim fileNum As Integer
Dim cursor As Integer

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
    
    BTICard_CardReset (hCore)
     
    ' Configure receive channel.
    ERRVAL = BTI708_ChConfig(CHCFG708_SEQALL, rcvchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Build the receive channel messages.
    ERRVAL = BTI708_RcvBuild(MSGCRT708_DEFAULT, 0, 1, rcvchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while building" & vbNewLine
        errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    'Configure the Sequential Monitor.
    ERRVAL = BTICard_SeqConfig(SEQCFG_DEFAULT, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "the sequential monitor on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Attempt to open the user specified file
    If Len(FileName.Text) Then
        fileNum = FreeFile()
        Open FileName.Text For Binary Access Write As #fileNum
    Else
        MsgBox "Error:  No File Name was given"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while starting core #" & corenum
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    CmdStart.Enabled = False
    CmdStop.Enabled = True
    Result1.Caption = "Card Running"
    cursor = 0
    
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
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: Unable to open card number " & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
        ' Find the first ARINC 708 core with a receive channel
    For corenum = 0 To MAX_CORES - 1
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For rcvchan = 0 To MAX_CHANNELS - 1
                If BTI708_ChIsRcv(rcvchan, hCore) Then
                   Exit For
                End If
            Next
            If rcvchan < MAX_CHANNELS Then
                Exit For
            End If
        End If
    Next
    
    If (ERRVAL <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible ARINC 708 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    ChanLbl.Caption = "Using ARINC 708 receive channel #" & rcvchan
    
    'Set flag so we run hardware
    bSkipRun = False
    
    CmdStart.Enabled = True
    CmdStop.Enabled = False
    Exit Sub
ErrHandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub



Private Sub Timer1_Timer()
    Dim str As String
    Dim seqbuf(2048) As Integer
    Dim seqcount As Long
    Dim blkcnt As Long
    Dim rec708 As SEQRECORD708
    Dim sfinfo As SEQFINDINFO
    
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
    
    ERRVAL = BTICard_SeqFindInit(seqbuf(0), seqcount, sfinfo)
    If (0 > ERRVAL) Then
        MsgBox "Error: SeqFindInit failed"
        bSkipRun = True
        Exit Sub
    End If
    
    While (0 <= BTICard_SeqFindNext708Ex(rec708, LenB(rec708), sfinfo))
        If cursor = 1 Then
            str = "Writing... b|"
        ElseIf cursor = 2 Then
            str = "Writing... b/"
        ElseIf cursor = 3 Then
            str = "Writing... b-"
        Else
            str = "Writing... b\"
            cursor = 0
        End If
        Result2.Caption = str
        cursor = cursor + 1
        
        Put fileNum, , rec708.Data()    'Write data to file
    Wend
    
End Sub

