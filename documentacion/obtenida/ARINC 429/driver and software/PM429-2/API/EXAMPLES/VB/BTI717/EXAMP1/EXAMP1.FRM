VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI717 Example 1"
   ClientHeight    =   4230
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4800
   LinkTopic       =   "Form1"
   ScaleHeight     =   4230
   ScaleWidth      =   4800
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   1920
      Top             =   3720
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3960
      TabIndex        =   11
      Top             =   3765
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   10
      Top             =   3765
      Width           =   735
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   9
      Top             =   3765
      Width           =   735
   End
   Begin VB.Label Result2 
      Caption         =   "Result2"
      Height          =   495
      Left            =   120
      TabIndex        =   12
      Top             =   3120
      Width           =   4215
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   495
      Left            =   120
      TabIndex        =   8
      Top             =   2520
      Width           =   4215
   End
   Begin VB.Label Header1 
      Alignment       =   2  'Center
      Caption         =   "Receiver Example"
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
      TabIndex        =   7
      Top             =   120
      Width           =   4695
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   6
      Top             =   945
      Width           =   4335
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   960
      TabIndex        =   5
      Top             =   2025
      Width           =   2895
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   4560
      Y1              =   600
      Y2              =   600
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   4
      Top             =   1665
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   3
      Top             =   1425
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   2
      Top             =   1185
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP1     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   1
      Top             =   705
      Width           =   4335
   End
   Begin VB.Label Channel 
      Caption         =   "Channel:"
      Height          =   255
      Left            =   960
      TabIndex        =   0
      Top             =   2280
      Width           =   2895
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1980
      Y2              =   1980
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI717 DRIVER VB_EXAMPLE 1  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP1 -- Receiver example
'
'  This program opens Card Number 0, and configures the
'  first BiPhase channel as a receiver.  After the
'  channel gets in sync, the program displays the first
'  word of each subframe (sync words).
'

' Force explicit declaration of all variables
Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

' Card specific
Dim hCard As Long
Dim hCore As Long
Dim corenum As Long
Dim ERRVAL As Long
Dim rcvchan As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean

' Program specific
Dim syncword1 As Integer
Dim syncword2 As Integer
Dim syncword3 As Integer
Dim syncword4 As Integer

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
        
    ' Configure channel for auto speed detection.
    BTICard_CardReset (hCore)
    ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASERCV Or CHCFG717_AUTOSPEED, rcvchan, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while configuring channel" & rcvchan
        bSkipRun = True
        Exit Sub
    End If
     
    ' Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    Result1.Caption = "Synchronizing to bit stream...."
    
End Sub

Private Sub CmdStop_Click()
    'Clear state of bRunning before card is stopped (so timer event is not processed)
    Dim bTemp As Boolean
    bTemp = bCardRunning
    bCardRunning = False
        
    If (bTemp = True) Then
        BTICard_CardStop (hCore)
    End If
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    Result1.Caption = "Card Stopped"
    Result2.Caption = ""
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    cmdStart.Enabled = False
    cmdStop.Enabled = False
    bSkipRun = False
    bCardRunning = False
    Result1.Caption = "Card Stopped"
    Result2.Caption = ""
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first 717 core with a BiPhase receive channel
    For corenum = 0 To MAX_CORES - 1
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For rcvchan = 0 To MAX_CHANNELS - 1
                If BTI717_ChIsType(CHCFG717_BIPHASERCV, rcvchan, hCore) Then
                    Exit For
                End If
            Next
            If rcvchan < MAX_CHANNELS Then
                Exit For
            End If
        End If
    Next
    
    If (ERRVAL <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible ARINC 717 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    Channel.Caption = "Using 717 BiPhase channel #" & rcvchan
    
    'Set flag so we run hardware
    bSkipRun = False
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub Timer1_Timer()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    '
    ' Test and Display data on the screen
    '
    
    If BTI717_SyncTest(rcvchan, hCore) Then
        Result1.Caption = "In Sync!"
        Call BTI717_SubFrmWordRd(syncword1, 1, 1, rcvchan, hCore)
        Call BTI717_SubFrmWordRd(syncword2, 2, 1, rcvchan, hCore)
        Call BTI717_SubFrmWordRd(syncword3, 3, 1, rcvchan, hCore)
        Call BTI717_SubFrmWordRd(syncword4, 4, 1, rcvchan, hCore)
        Result2.Caption = "Sync1=" & Oct(syncword1) & "  Sync2=" & Oct(syncword2) & "  Sync3=" & Oct(syncword3) & "  Sync4=" & Oct(syncword4)
    End If
    
End Sub

