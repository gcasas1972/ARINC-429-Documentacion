VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI708 Example 1"
   ClientHeight    =   4215
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4695
   LinkTopic       =   "Form1"
   ScaleHeight     =   4215
   ScaleWidth      =   4695
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton CmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   2
      Top             =   3720
      Width           =   735
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   1
      Top             =   3720
      Width           =   735
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   960
      TabIndex        =   0
      Top             =   3720
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   1
      Left            =   2760
      Top             =   3720
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   120
      TabIndex        =   12
      Top             =   1800
      Width           =   4215
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1755
      Y2              =   1755
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP1     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   11
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   10
      Top             =   960
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   9
      Top             =   1200
      Width           =   4335
   End
   Begin VB.Label Header6 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   8
      Top             =   1440
      Width           =   4335
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   4560
      Y1              =   360
      Y2              =   360
   End
   Begin VB.Label Header3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   7
      Top             =   720
      Width           =   4335
   End
   Begin VB.Label Header1 
      Caption         =   "Transmitter Example"
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
      Left            =   1260
      TabIndex        =   6
      Top             =   0
      Width           =   2175
   End
   Begin VB.Label ChanLbl 
      Caption         =   "ChanLbl"
      Height          =   255
      Left            =   120
      TabIndex        =   5
      Top             =   2040
      Width           =   4215
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   375
      Left            =   240
      TabIndex        =   4
      Top             =   2400
      Width           =   4215
   End
   Begin VB.Label Result2 
      Caption         =   "Result2"
      Height          =   495
      Left            =   240
      TabIndex        =   3
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
'  BTI708 DRIVER VB_EXAMPLE 1  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP1 -- Transmitter example
'
'  This program opens Card Number 0, and configures the
'  first transmit channel to transmit a sequence of 32
'  messages at a rate of 200Hz.  The messages are
'  automatically assigned the numbers 0 through 31.
'
'  An Event Log frequency of 16 is specifed, which will
'  cause the channel to issue an Event Log List entry
'  every 16th message (message numbers 15, and 31).
'  The program uses these events to update the data for
'  the half of messages that were just transmitted.
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Const FRAMEFREQ As Integer = 200        ' Frame frequency of 200Hz
Const logfreq As Integer = 16           ' Generate a Log Event after every 16th message
Const FRAMECOUNT As Integer = 32        ' Transmit a total of 32 messages


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
Dim Data(0 To 99) As Integer
Dim txCount As Integer
Dim j As Integer
Dim jj As Integer

Private Sub CmdExit_Click()
    If (hCard >= 0) Then
        ERRVAL = BTICard_CardClose(hCard)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub CmdStart_Click()

    If bSkipRun Then
        Exit Sub
    End If
    
    ' Configure transmit channel.
    BTICard_CardReset (hCore)
    ERRVAL = BTI708_ChConfig(CHCFG708_DEFAULT, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Build the transmit channel messages.
    ERRVAL = BTI708_XmtBuild(MSGCRT708_DEFAULT, FRAMEFREQ, logfreq, FRAMECOUNT, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while building" & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Create and write the data for the messages.
    For j = 0 To (FRAMECOUNT - 1) Step 1                ' Loop through all the messages
        For jj = 0 To 99 Step 1
            Data(jj) = j + (txCount * FRAMECOUNT)
        Next
        Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore)   ' Write data to the Device
    Next
    txCount = txCount + 1
    
    ' Configure the Event Log list.
    ERRVAL = BTICard_EventLogConfig(LOGCFG_ENABLE, 1024, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configureing" & vbNewLine
        errstr = errstr & "the event log list on core #" & corenum
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
    Result1.Caption = "Transmitting data"
    
End Sub

Private Sub CmdStop_Click()
    'Clear state of bRunning before card is stopped (so timer event is not processed)
    Dim bTemp As Boolean
    bTemp = bCardRunning
    bCardRunning = False
        
    If (bTemp = True) Then
        BTICard_CardStop (hCore)
    End If
    
    CmdStart.Enabled = True
    CmdStop.Enabled = False
    Result1.Caption = "Card Stopped"
    Result2.Caption = ""
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
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
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub Timer1_Timer()
    Dim eventType As Integer
    Dim info As Long
    Dim logchan As Long
    Dim framenum As Integer
    Dim j As Long
    Dim jj As Long
    
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
            For j = 0 To ((FRAMECOUNT / 2) - 1) Step 1
                For jj = 0 To 99 Step 1
                    Data(jj) = j + (txCount * FRAMECOUNT)
                Next
                Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore)
            Next
        ElseIf framenum = (FRAMECOUNT - 1) Then                     'Second half transmitted
            Result2.Caption = "Updating frames " & (FRAMECOUNT / 2) & " - " & framenum
            For j = (FRAMECOUNT / 2) To framenum Step 1
                For jj = 0 To 99 Step 1
                    Data(jj) = j + (txCount * FRAMECOUNT)
                Next
                Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore)
            Next
            txCount = txCount + 1
        End If
    End If
    
End Sub

