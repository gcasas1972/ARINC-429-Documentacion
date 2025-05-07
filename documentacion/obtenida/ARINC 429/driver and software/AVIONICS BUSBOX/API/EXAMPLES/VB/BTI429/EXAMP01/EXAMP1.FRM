VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI429 Example 1"
   ClientHeight    =   4575
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4695
   LinkTopic       =   "Form1"
   ScaleHeight     =   4575
   ScaleWidth      =   4695
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   4080
      Width           =   735
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   1080
      TabIndex        =   1
      Top             =   4080
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   3240
      Top             =   4080
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   0
      Top             =   4080
      Width           =   735
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   1200
      TabIndex        =   13
      Top             =   1920
      Width           =   3135
   End
   Begin VB.Label Label1 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Left            =   120
      TabIndex        =   12
      Top             =   969
      Width           =   4335
   End
   Begin VB.Label Receive 
      Caption         =   "Receive"
      Height          =   255
      Left            =   1200
      TabIndex        =   11
      Top             =   2160
      Width           =   3135
   End
   Begin VB.Label Line1 
      Caption         =   "Default"
      Height          =   255
      Left            =   720
      TabIndex        =   10
      Top             =   2760
      Width           =   2895
   End
   Begin VB.Label Line2 
      Caption         =   "Latitude"
      Height          =   255
      Left            =   720
      TabIndex        =   9
      Top             =   3120
      Width           =   2895
   End
   Begin VB.Label Line3 
      Caption         =   "Longitude"
      Height          =   255
      Left            =   720
      TabIndex        =   8
      Top             =   3480
      Width           =   2895
   End
   Begin VB.Label Header1 
      Caption         =   "Receive Example"
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
      Left            =   1380
      TabIndex        =   7
      Top             =   0
      Width           =   1935
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP1  (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   6
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   5
      Top             =   732
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   4
      Top             =   1206
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   3
      Top             =   1440
      Width           =   4335
   End
   Begin VB.Line Line4 
      X1              =   120
      X2              =   4560
      Y1              =   1800
      Y2              =   1800
   End
   Begin VB.Line Line5 
      X1              =   120
      X2              =   4560
      Y1              =   360
      Y2              =   360
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI429 DRIVER VB_EXAMPLE 1  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP1 -- Receiver example
'
'  This program opens Card Number 0, and configures the
'  first compatible core to receive 2 GPS messages into
'  separate Message Records, and receive all other
'  messages into a default Message Record.
'

Option Explicit

Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Dim hCard As Long
Dim hCore As Long
Dim corenum As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean
Dim ERRVAL As Long
Dim errstr As String
Dim rcvchan As Long
Dim msgdefault As MSGSTRUCT429
Dim Latitude As MSGSTRUCT429
Dim Longitude As MSGSTRUCT429

Private Sub CmdExit_Click()
    If (hCard >= 0) Then
        ERRVAL = BTICard_CardClose(hCard)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub CmdStart_Click()

    If (bSkipRun = True) Then
        Exit Sub
    End If
    
    'Configure receiver channel for auto speed detection.
    BTICard_CardReset (hCore)
    ERRVAL = BTI429_ChConfig(CHCFG429_AUTOSPEED, rcvchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Before any messages can be received, filters must be set
    ' for the receive channel.  First, the default filter is
    ' created.  Then, two filters are set for the two messages
    ' of interest.
    
    msgdefault.addr = BTI429_FilterDefault(MSGCRT429_DEFAULT, rcvchan, hCore)
    Latitude.addr = BTI429_FilterSet(MSGCRT429_DEFAULT, &O310, SDIALL, rcvchan, hCore)
    Longitude.addr = BTI429_FilterSet(MSGCRT429_DEFAULT, &O311, SDIALL, rcvchan, hCore)

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
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        errstr = "Error: Unable to open card number " & cardnum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first 429 core with a receive channel
    For corenum = 0 To MAX_CORES - 1
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For rcvchan = 0 To MAX_CHANNELS - 1
                If BTI429_ChIsRcv(rcvchan, hCore) Then
                   Exit For
                End If
            Next
            If rcvchan < MAX_CHANNELS Then
                Exit For
            End If
        End If
    Next
    
    If (ERRVAL <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible ARINC 429 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    Receive.Caption = "Using receive channel #" & rcvchan
    
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
    msgdefault.Data = BTI429_MsgDataRd(msgdefault.addr, hCore)
    Latitude.Data = BTI429_MsgDataRd(Latitude.addr, hCore)
    Longitude.Data = BTI429_MsgDataRd(Longitude.addr, hCore)

    ' Write data to form
    Line1.Caption = "Default = " & Hex(msgdefault.Data) & " (Hex)"
    Line2.Caption = "Latitude = " & Hex(Latitude.Data) & " (Hex)"
    Line3.Caption = "Longitude = " & Hex(Longitude.Data) & " (Hex)"
    
End Sub

