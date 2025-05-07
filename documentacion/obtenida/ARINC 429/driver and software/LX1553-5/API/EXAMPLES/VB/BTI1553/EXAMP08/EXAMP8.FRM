VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 8"
   ClientHeight    =   3630
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5040
   LinkTopic       =   "Form1"
   ScaleHeight     =   3630
   ScaleWidth      =   5040
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
      Left            =   4200
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
      Caption         =   "Errors in RT Transmissions"
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
      Caption         =   "VB_EXAMP8  (06/07/2011)"
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
      Left            =   240
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
'  BTI1553 DRIVER VB_EXAMPLE 8  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP8 -- Errors in RT Transmissions
'
'  This example requires a Ballard 1553 C version Device or higher.
'  It configures Card Number 0 as an RT and configures a response
'  time error for transmit commands for subaddress 2.  Each
'  time the subaddress is accessed, the response time is
'  incremented by .1us.
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

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
Dim GapLength As Integer

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
    
    errval = BTI1553_RTConfig(RTCFG1553_DEFAULT, 1, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while while configuring for terminal address mode"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Define the type and location of the gap error.
    GapLength = 120   'Set initial gap length to 12us (Each GapLength=0.1 microseconds)
    Call BTI1553_ErrorDefine(ERRDEF1553_GAP, GapLength, 0, ERRDEF1553_SWD1, 0, channum, hCore)   'Define the error wanted
    Call BTI1553_ErrorTagRT(True, SUBADDRESS, 1, XMT, 2, channum, hCore)                         'Tag the RT to inject errors
    Call BTI1553_ErrorCtrl((ERRCTRL1553_ONCE Or ERRCTRL1553_TAGMSG), channum, hCore)             'Apply the error to the RT one time
    
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
    Result1.Caption = "No errors detected."
    
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
    Result1.Caption = "Card stopped."
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
    Result1.Caption = "Card stopped."
    
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
    
    If BTI1553_ChIsC(channum, hCore) Then
        channel.Caption = "Using 1553 version C channel #" & CStr(channum)
    ElseIf BTI1553_ChIsD(channum, hCore) Then
        channel.Caption = "Using 1553 version D channel #" & CStr(channum)
    Else
        MsgBox "Error:  Example required a 1553 C or D version channel"
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    
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
    
    '  When the error is generated once, tag another message for
    '  error generation and enable another single error.
    
    If BTI1553_ErrorSent(channum, hCore) Then
        ' Inc the GapLength
        GapLength = GapLength + 1
        ' Load gap error on card
        Call BTI1553_ErrorDefine(ERRDEF1553_GAP, GapLength, 0, ERRDEF1553_SWD1, 0, channum, hCore)
        Call BTI1553_ErrorCtrl((ERRCTRL1553_ONCE Or ERRCTRL1553_TAGMSG), channum, hCore)
        ' Update the display
        Result1.Caption = "Gap Length = " & CStr(GapLength)
    End If
    
End Sub





