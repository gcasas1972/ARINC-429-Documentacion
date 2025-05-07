VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 10"
   ClientHeight    =   3615
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4935
   LinkTopic       =   "Form1"
   ScaleHeight     =   3615
   ScaleWidth      =   4935
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   3480
      Top             =   3120
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   60
      TabIndex        =   2
      Top             =   3120
      Width           =   735
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   1020
      TabIndex        =   1
      Top             =   3120
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   4140
      TabIndex        =   0
      Top             =   3120
      Width           =   735
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   900
      TabIndex        =   11
      Top             =   1920
      Width           =   3135
   End
   Begin VB.Label Channel 
      Caption         =   "Channel"
      Height          =   255
      Left            =   900
      TabIndex        =   10
      Top             =   2160
      Width           =   3135
   End
   Begin VB.Label Header1 
      Alignment       =   2  'Center
      Caption         =   "Polling the Event Log List"
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
      Left            =   0
      TabIndex        =   9
      Top             =   0
      Width           =   4935
   End
   Begin VB.Label Label1 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Left            =   248
      TabIndex        =   8
      Top             =   975
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP10  (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   248
      TabIndex        =   7
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Index           =   1
      Left            =   248
      TabIndex        =   6
      Top             =   735
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   248
      TabIndex        =   5
      Top             =   1200
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   248
      TabIndex        =   4
      Top             =   1440
      Width           =   4335
   End
   Begin VB.Line Line4 
      X1              =   248
      X2              =   4688
      Y1              =   1800
      Y2              =   1800
   End
   Begin VB.Line Line5 
      X1              =   248
      X2              =   4688
      Y1              =   360
      Y2              =   360
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   375
      Left            =   375
      TabIndex        =   3
      Top             =   2640
      Width           =   4215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI1553 DRIVER VB_EXAMPLE 10  (06/07/2011)
'  Copyright (c) 2001-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP10 -- Polling the Event Log List
'
'  This example configures Card Number 0 as a bus controller
'  to transmit a schedule of three messages.  The schedule is
'  created in such a way that the messages are transmitted at
'  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
'  and 40ms, respectively).
'
'  The schedule is also configured to generate an Event Log List
'  entry after each 10ms frame.  When an entry is read from the list,
'  the data words associated with the 0843H BC-RT message is updated.
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16
Const CMD0 As Integer = &H843
Const CMD1 As Integer = &H821
Const RCV_CMD2 As Integer = &H821
Const XMT_CMD2 As Integer = &H1C21
Const frametime As Long = 10000

' Card specific
Dim hCard As Long
Dim hCore As Long
Dim corenum As Long
Dim channum As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean
Dim errval As Long
Dim errstr As String

' Program specific
Dim BCMsgs(2) As Long
Dim data(2) As Integer
Dim msgtype As Integer
Dim info As Long

Private Sub CmdExit_Click()
    If (hCard >= 0) Then
        errval = BTICard_CardClose(hCard)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub CmdStart_Click()

    If bSkipRun Then
        Exit Sub
    End If
    
    BTICard_CardReset (hCore)
    
    'Configure the channel for bus controller mode.
    errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while while configuring for bus controller mode"
        Exit Sub
    End If

    '  Create the message records for each of the three messages.
    data(0) = 0
    data(1) = 0
    data(2) = 0

    BCMsgs(0) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, CMD0, 0, data(0), hCore)
    BCMsgs(1) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, CMD1, 0, 0, hCore)
    BCMsgs(2) = BTI1553_BCCreateMsg(MSGCRT1553_RTRT, RCV_CMD2, XMT_CMD2, 0, hCore)

    '  Schedule the messages to create the desired bus controller
    '  schedule.  Also schedule an Event Log after each frame.
    '  Note the unique tag value associated with each Event Log
    '  that could be used to distinguish unique Events.
    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(2), channum, hCore)
    Call BTI1553_BCSchedLog(COND1553_ALWAYS, &H1111, channum, hCore)

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
    Call BTI1553_BCSchedLog(COND1553_ALWAYS, &H2222, channum, hCore)

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)
    Call BTI1553_BCSchedLog(COND1553_ALWAYS, &H3333, channum, hCore)

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
    Call BTI1553_BCSchedLog(COND1553_ALWAYS, &H4444, channum, hCore)

    '  Configure the Event Log list.
    errval = BTICard_EventLogConfig(LOGCFG_ENABLE, 1024, hCore)
    If (errval) Then
        errstr = "Error: An error was encountered while configuring the event log list."
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If

     ' Start operation of the card.
    errval = BTICard_CardStart(hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    CmdStart.Enabled = False
    CmdStop.Enabled = True
    Result1.Caption = ""

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
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    bSkipRun = False
    bCardRunning = False
    CmdStart.Enabled = False
    CmdStop.Enabled = False
    Result1.Caption = "Card Stopped"
    
    ' Open handle to card with specified card number
    errval = BTICard_CardOpen(hCard, cardnum)
    If (errval) Then
        errstr = "Error: Unable to open card number " & cardnum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first 1553 core and channel
    For corenum = 0 To MAX_CORES - 1
        errval = BTICard_CoreOpen(hCore, corenum, hCard)
        If errval = 0 Then
            For channum = 0 To MAX_CHANNELS - 1
                If BTI1553_ChIs1553(channum, hCore) Then
                   Exit For
                End If
            Next
            If channum < MAX_CHANNELS Then
                Exit For
            End If
        End If
    Next
    
    If (errval <> 0) Or (corenum >= MAX_CORES) Or (channum >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible MIL-STD-1553 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    channel.Caption = "Using 1553 channel #" & channum
    
    'Set flag so we run hardware
    bSkipRun = False
    
    CmdStart.Enabled = True
    CmdStop.Enabled = False
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub Timer1_Timer()
    
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Read data from card
    Dim msgChan As Long
    
    If BTICard_EventLogRd(msgtype, info, msgChan, hCore) Then
        data(0) = data(0) + 2
        data(1) = data(1) + 4
        data(2) = data(2) + 6
        
        Call BTI1553_MsgDataWr(data(0), 3, BCMsgs(0), hCore)
        
        Result1.Caption = "Transmitting data {" & Hex(data(0)) & ", " & Hex(data(1)) & ", " & Hex(data(2)) & "}"
    End If
    
End Sub
