VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI429 Example 5"
   ClientHeight    =   4050
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4695
   LinkTopic       =   "Form1"
   ScaleHeight     =   4050
   ScaleWidth      =   4695
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   1920
      Top             =   3540
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   2
      Top             =   3540
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   1
      Top             =   3540
      Width           =   735
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   3540
      Width           =   735
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP5     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   12
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   11
      Top             =   960
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   10
      Top             =   1200
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   9
      Top             =   1440
      Width           =   4335
   End
   Begin VB.Label Label2 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   8
      Top             =   720
      Width           =   4335
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   1080
      TabIndex        =   7
      Top             =   1920
      Width           =   2895
   End
   Begin VB.Label Header1 
      Caption         =   "Transmit and Receive List Buffer Example"
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
      Left            =   180
      TabIndex        =   6
      Top             =   0
      Width           =   4335
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit:"
      Height          =   255
      Left            =   1080
      TabIndex        =   5
      Top             =   2460
      Width           =   2895
   End
   Begin VB.Label Receive 
      Caption         =   "Receive:"
      Height          =   255
      Left            =   1080
      TabIndex        =   4
      Top             =   2190
      Width           =   2895
   End
   Begin VB.Label Label1 
      Caption         =   "Air Speed:"
      Height          =   255
      Left            =   1080
      TabIndex        =   3
      Top             =   3000
      Width           =   2535
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
'  BTI429 DRIVER VB_EXAMPLE 5  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP5 -- Transmit and Receive List buffer example
'
'  This program opens the Card Number 0, finds the first
'  compatible core, and configures transmit and receive
'  list buffers.  The program transmits one message filled
'  with ramping data in the associated list buffer.  The
'  receive list buffer is read and displays the data to the
'  screen.
'

Option Explicit

Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Dim bCardRunning As Boolean
Dim bSkipRun As Boolean
Dim hCard As Long
Dim hCore As Long
Dim ERRVAL As Long
Dim errstr As String
Dim corenum As Long
Dim rcvchan As Long
Dim xmtchan As Long
Dim j As Long
Dim xmt_airspeed As MSGSTRUCT429
Dim rcv_airspeed As MSGSTRUCT429
Dim xmtlistaddr As Long
Dim rcvlistaddr As Long

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
    
    ' Configure rcvchan for auto speed detection.
    ' Configure xmtchan to transmit at low speed with
    ' the selftest wrap-around enabled.
    
    BTICard_CardReset (hCore)
    
    'Configure channel
    ERRVAL = BTI429_ChConfig(CHCFG429_AUTOSPEED Or CHCFG429_SELFTEST, rcvchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    'Configure channel
    ERRVAL = BTI429_ChConfig(CHCFG429_SELFTEST, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring " & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Before any messages can be received, filters must be set
    ' for the receive channel.

    rcv_airspeed.addr = BTI429_FilterSet(MSGCRT429_DEFAULT, &O206, SDIALL, rcvchan, hCore)
    
    ' Create a message for each of the labels we are transmitting.
    
    xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
    
    ' Next, a schedule is built by creating explicit message timing.
    
    Call BTI429_SchedMsg(xmt_airspeed.addr, xmtchan, hCore)
    Call BTI429_SchedGap(1218, xmtchan, hCore)
    
    ' Create the transmit and receive list buffers.
    '
    ' The transmit list buffer will be a circular buffer,
    ' which means it should be pre-loaded with data, and
    ' it will continuously transmit that data.
    '
    ' The receive list buffer will be a FIFO, which we will
    ' read out of and display to the screen.

    xmtlistaddr = BTI429_ListXmtCreate(LISTCRT429_CIRCULAR, 256, xmt_airspeed.addr, hCore)
    rcvlistaddr = BTI429_ListRcvCreate(LISTCRT429_FIFO, 16, rcv_airspeed.addr, hCore)
    
    ' Initialize the transmit list buffer.
    
    For j = &H0 To &H1000000 Step &H10000
        Call BTI429_ListDataWr((&H86 Or j), xmtlistaddr, hCore)
    Next
    
    ' Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while starting core #" & corenum
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    
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
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: Unable to open card number " & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first 429 core with both a receive and a transmit channel.
    For corenum = 0 To MAX_CORES - 1
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For rcvchan = 0 To MAX_CHANNELS - 1
                If BTI429_ChIsRcv(rcvchan, hCore) Then
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
            If (rcvchan < MAX_CHANNELS) And (xmtchan < MAX_CHANNELS) Then
                Exit For
            End If
        End If
    Next
    
    If (ERRVAL <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Or (xmtchan >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible ARINC 429 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If

    Core.Caption = "Using core #" & corenum
    Receive.Caption = "Using receive channel #" & rcvchan
    Transmit.Caption = "Using transmit channel #" & xmtchan
    
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
    
    ' Display data on the screen.
    rcv_airspeed.Data = BTI429_ListDataRd(rcvlistaddr, hCore)
    
    If rcv_airspeed.Data Then
        Label1.Caption = "AirSpeed = " & Hex(rcv_airspeed.Data) & " (Hex)"
    End If
    
End Sub


