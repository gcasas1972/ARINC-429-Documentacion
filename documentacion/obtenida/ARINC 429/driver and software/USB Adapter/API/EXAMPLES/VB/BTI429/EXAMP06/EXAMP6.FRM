VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI429 Example 6"
   ClientHeight    =   3645
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4695
   LinkTopic       =   "Form1"
   ScaleHeight     =   3645
   ScaleWidth      =   4695
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   3
      Top             =   3180
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   2
      Top             =   3180
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   1
      Top             =   3180
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   3360
      Top             =   3120
   End
   Begin VB.CommandButton CmdTx 
      Caption         =   "Transmit"
      Height          =   375
      Left            =   1800
      TabIndex        =   0
      Top             =   3180
      Width           =   855
   End
   Begin VB.Label Label3 
      Caption         =   "Press Transmit to send the asynchronous message."
      Height          =   255
      Left            =   480
      TabIndex        =   13
      Top             =   2880
      Width           =   3735
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   1080
      TabIndex        =   12
      Top             =   1920
      Width           =   3015
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP6     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   11
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   10
      Top             =   960
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   9
      Top             =   1200
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   8
      Top             =   1440
      Width           =   4335
   End
   Begin VB.Label Label2 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   7
      Top             =   720
      Width           =   4335
   End
   Begin VB.Label Label1 
      Caption         =   "Asynchronous transmission count:"
      Height          =   255
      Left            =   1080
      TabIndex        =   6
      Top             =   2400
      Width           =   3015
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit:"
      Height          =   255
      Left            =   1080
      TabIndex        =   5
      Top             =   2160
      Width           =   3015
   End
   Begin VB.Label Header1 
      Caption         =   "Asynchronous List Buffer Example"
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
      Left            =   540
      TabIndex        =   4
      Top             =   0
      Width           =   3615
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   4440
      Y1              =   360
      Y2              =   360
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4440
      Y1              =   1800
      Y2              =   1800
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI429 DRIVER VB_EXAMPLE 6  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP6 -- Asynchronous List Buffer Example
'
'  This program opens the Card Number 0, finds the first
'  compatible core, and configures an asynchronous transmit
'  list buffer. The program transmits one label synchronoulsy
'  in a schedule, and transmits another label each time the
'  transmit button is hit by the user.
'

Option Explicit

Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Dim bCardRunning As Boolean
Dim bSkipRun As Boolean
Dim hCard As Long
Dim hCore As Long
Dim corenum As Long
Dim errstr As String
Dim ERRVAL As Long
Dim xmtchan As Long
Dim xmtstat As Boolean
Dim xmtcount As Long
Dim xmt_airspeed As MSGSTRUCT429
Dim asynclistaddr As Long

Private Sub cmdExit_Click()
    If (hCard >= 0) Then
        ERRVAL = BTICard_CardClose(hCard)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub cmdStart_Click()
    
    If (bSkipRun = True) Then
        Exit Sub
    End If
    
    ' Reset counter
    
    xmtcount = 0
    
    ' Configure xmtchan to transmit at low speed.
    
    BTICard_CardReset (hCore)
    ERRVAL = BTI429_ChConfig(CHCFG429_DEFAULT, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Create a message for each the synchronous label we are transmitting.
    xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
    
    ' Create the asynchronous list buffer.
    asynclistaddr = BTI429_ListAsyncCreate(LISTCRT429_FIFO, 16, xmtchan, hCore)
    
    '  Next, a schedule is built by creating explicit message timing.
    '  While creating a schedule we can still use the SchedGap() funciton
    '  to create our gap times.  This function will determine that an
    '  asynchronous list buffer has been created for the channel, and will
    '  internally call the SchedGapList() function with appropriate parameters.
    '  Alternatively, we could use the SchedGapList() function directly
    '  and specify the address value ourselves. This method is usefull if
    '  more than one asynchronoous list buffer is desired per channel.
    Call BTI429_SchedMsg(xmt_airspeed.addr, xmtchan, hCore)
    Call BTI429_SchedGap(1218, xmtchan, hCore)
    
    ' The synchronous message needs to be initialized.
    Call BTI429_MsgDataWr(&H86, xmt_airspeed.addr, hCore)
    
    ' Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while starting core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    CmdTx.Enabled = True
    
End Sub

Private Sub cmdStop_Click()
    'Clear state of bRunning before card is stopped (so timer event is not processed)
    Dim bTemp As Boolean
    bTemp = bCardRunning
    bCardRunning = False
        
    If (bTemp = True) Then
        BTICard_CardStop (hCore)
    End If
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    CmdTx.Enabled = False
    
End Sub

Private Sub CmdTx_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    xmtstat = BTI429_ListDataWr(&H8A, asynclistaddr, hCore)
    
    If xmtstat Then
        xmtcount = xmtcount + 1
    End If
    
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    bSkipRun = False
    bCardRunning = False
    cmdStart.Enabled = False
    cmdStop.Enabled = False
    CmdTx.Enabled = False
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        errstr = "Error: Unable to open card number " & cardnum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first 429 core with a transmit channel
    For corenum = 0 To MAX_CORES - 1
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For xmtchan = 0 To MAX_CHANNELS - 1
                If BTI429_ChIsXmt(xmtchan, hCore) Then
                   Exit For
                End If
            Next
            If xmtchan < MAX_CHANNELS Then
                Exit For
            End If
        End If
    Next
    
    If (ERRVAL <> 0) Or (corenum >= MAX_CORES) Or (xmtchan >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible ARINC 429 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    Transmit.Caption = "Using transmit channel #" & xmtchan
    
    'Set flag so we run hardware
    bSkipRun = False
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    CmdTx.Enabled = False
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub Timer1_Timer()

    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Display data on the screen.
    Label1.Caption = "Asynchronous transmission count: " & xmtcount
    
End Sub



