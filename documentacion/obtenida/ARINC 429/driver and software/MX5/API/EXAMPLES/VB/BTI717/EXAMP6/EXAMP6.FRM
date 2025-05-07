VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI717 Example 6"
   ClientHeight    =   5325
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5460
   LinkTopic       =   "Form1"
   ScaleHeight     =   5325
   ScaleWidth      =   5460
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox List1 
      Height          =   2400
      Left            =   120
      TabIndex        =   9
      Top             =   2280
      Width           =   5175
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   4845
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   1
      Top             =   4845
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   4560
      TabIndex        =   0
      Top             =   4800
      Width           =   735
   End
   Begin VB.Line Line2 
      Index           =   1
      X1              =   503
      X2              =   4943
      Y1              =   1800
      Y2              =   1800
   End
   Begin VB.Line Line1 
      Index           =   0
      X1              =   503
      X2              =   4943
      Y1              =   480
      Y2              =   480
   End
   Begin VB.Label Status 
      Caption         =   "Status"
      Height          =   255
      Left            =   120
      TabIndex        =   10
      Top             =   1920
      Width           =   5175
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP6     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   503
      TabIndex        =   8
      Top             =   585
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   503
      TabIndex        =   7
      Top             =   1065
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   503
      TabIndex        =   6
      Top             =   1305
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   503
      TabIndex        =   5
      Top             =   1560
      Width           =   4335
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   503
      TabIndex        =   4
      Top             =   825
      Width           =   4335
   End
   Begin VB.Label Header1 
      Caption         =   "Multiple Core Example"
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
      Left            =   1463
      TabIndex        =   3
      Top             =   120
      Width           =   2895
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI717 DRIVER VB_EXAMPLE 6  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP6 -- Multiple Core Example
'
'  This program opens Card Number 0 and configures all
'  ARINC 717 cores to receive on all BiPhase channels.
'  Program reports when each BiPhase channel is in sync.
'

' Force explicit declaration of all variables
Option Explicit

Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Dim bCardRunning As Boolean
Dim bSkipRun As Boolean
Dim hCard As Long
Dim hCores(MAX_CORES - 1) As Long
Dim bCores(MAX_CORES - 1) As Boolean
Dim ERRVAL As Long
Dim errstr As String
Dim corecount As Long
Dim corenum As Long
Dim chan As Long

Private Sub cmdExit_Click()
    If (hCard >= 0) Then
        ERRVAL = BTICard_CardClose(hCard)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub cmdStart_Click()
    Dim output As String
    
    If (bSkipRun = True) Then
        Exit Sub
    End If
    
    '  Clear list
    List1.Clear
    Status.Caption = ""
    
    '
    '  Configure all receive channels  for auto speed detection.
    '
    
    For corenum = 0 To (MAX_CORES - 1)
        If bCores(corenum) Then
            BTICard_CardReset (hCores(corenum))
            
            For chan = 0 To (MAX_CHANNELS - 1)
                If BTI717_ChIsType(CHCFG717_BIPHASERCV, chan, hCores(corenum)) Then
                    ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASERCV Or CHCFG717_AUTOSPEED, chan, hCores(corenum))
                    If (ERRVAL < 0) Then
                        errstr = "Error:  An error was encounted while configuring" & vbNewLine
                        errstr = errstr & "channel #" & chan & " on core #" & corenum
                        MsgBox errstr
                        bSkipRun = True
                        Exit Sub
                    End If
                End If
            Next
            
        End If
    Next
    
    '
    ' Start operation of the card.
    '
    
    For corenum = 0 To (MAX_CORES - 1)
        If bCores(corenum) Then
            BTICard_CardStart (hCores(corenum))
        End If
    Next
     
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    
    '
    ' Sync all channels on all cores
    '
    
    For corenum = 0 To (MAX_CORES - 1)
        If bCores(corenum) Then
            For chan = 0 To (MAX_CHANNELS - 1)
                If BTI717_ChIsType(CHCFG717_BIPHASERCV, chan, hCores(corenum)) Then
                    Status.Caption = "Synchronizing channel " & chan & " on core " & corenum & " to bit stream...."
                    While 0 = BTI717_SyncTest(chan, hCores(corenum))
                    Wend
                    List1.AddItem CStr("Channel " & chan & " on core " & corenum & "now In Sync!")
                End If
            Next
        End If
    Next
    
End Sub

Private Sub cmdStop_Click()
    bCardRunning = False
        
    For corenum = 0 To (MAX_CORES - 1)
        BTICard_CardStart (hCores(corenum))
    Next
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    Status.Caption = ""
    
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    bSkipRun = False
    bCardRunning = False
    cmdStart.Enabled = False
    cmdStop.Enabled = False
    Status.Caption = ""
    
    For corenum = 0 To (MAX_CORES - 1)
        hCores(corenum) = -1
        bCores(corenum) = False
    Next
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find all ARINC 717 cores on the board
    corecount = 0
    For corenum = 0 To (MAX_CORES - 1)
        ERRVAL = BTICard_CoreOpen(hCores(corenum), corenum, hCard)
        If ERRVAL = 0 Then
            For chan = 0 To (MAX_CHANNELS - 1)
                If BTI717_ChIsType(CHCFG717_BIPHASERCV, chan, hCores(corenum)) Then
                    bCores(corenum) = True
                    corecount = corecount + 1
                    Exit For
                End If
            Next
        End If
    Next
    
    If corecount = 0 Then
        MsgBox "Error:    Unable to find any ARINC 717 cores on card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    ' Init output list 1
    List1.Clear
    
    'Set flag so we run hardware
    bSkipRun = False
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub


