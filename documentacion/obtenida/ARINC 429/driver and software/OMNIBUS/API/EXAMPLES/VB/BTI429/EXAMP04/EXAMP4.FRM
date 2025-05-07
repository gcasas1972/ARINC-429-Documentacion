VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI429 Example 4"
   ClientHeight    =   4260
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   4260
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   3780
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   1
      Top             =   3780
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   0
      Top             =   3780
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   1920
      Top             =   3780
   End
   Begin VB.Label Label3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Left            =   120
      TabIndex        =   13
      Top             =   1095
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP4  (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   12
      Top             =   600
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   11
      Top             =   855
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   10
      Top             =   1320
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   9
      Top             =   1560
      Width           =   4335
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   720
      TabIndex        =   8
      Top             =   2040
      Width           =   2895
   End
   Begin VB.Label Header1 
      Caption         =   "Explicit Message Timing Example"
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
      Left            =   533
      TabIndex        =   7
      Top             =   120
      Width           =   3615
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   4560
      Y1              =   480
      Y2              =   480
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1920
      Y2              =   1920
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit:"
      Height          =   255
      Left            =   720
      TabIndex        =   6
      Top             =   2595
      Width           =   2895
   End
   Begin VB.Label Receive 
      Caption         =   "Receive:"
      Height          =   255
      Left            =   720
      TabIndex        =   5
      Top             =   2310
      Width           =   2895
   End
   Begin VB.Label Label1 
      Caption         =   "Airspeed:"
      Height          =   255
      Left            =   360
      TabIndex        =   4
      Top             =   3000
      Width           =   3735
   End
   Begin VB.Label Label2 
      Caption         =   "Altitude:"
      Height          =   255
      Left            =   360
      TabIndex        =   3
      Top             =   3360
      Width           =   3735
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI429 DRIVER VB_EXAMPLE 4  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP4 -- Explicit message timing
'
'  This program opens Card Number 0, finds the first
'  compatible core, and builds a transmit schedule
'  using explicit message timing. The selftest
'  wrap-around is enabled and filters are set to
'  receive the messages.  The minimum and maximum elapsed
'  time for each message is displayed.
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
Dim rcvchan As Long
Dim xmtchan As Long
Dim xmt_airspeed As MSGSTRUCT429
Dim xmt_altitude As MSGSTRUCT429
Dim rcv_airspeed As MSGSTRUCT429
Dim rcv_altitude As MSGSTRUCT429
Dim airspeed_record As MSGFIELDS429
Dim altitude_record As MSGFIELDS429

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
    
    ' Configure rcvchan to receive at low speed with the
    ' Min/Max Elapse Time option also enabled.
    '
    ' Configure xmtchan to transmit at low speed.
    ' Note that the selftest wrap-around is also enabled.
    ' The external line drivers are disabled, and xmtchan is
    ' connected internally to all the receive channels.

    BTICard_CardReset (hCore)
    
    'Configure channel
    ERRVAL = BTI429_ChConfig(CHCFG429_MAXMIN Or CHCFG429_SELFTEST, rcvchan, hCore)
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
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Before any messages can be received, filters must be set
    ' for the receive channel.  Two filters are set for the
    ' two messages of interest.
    
    rcv_airspeed.addr = BTI429_FilterSet(MSGCRT429_DEFAULT, &O206, SDIALL, rcvchan, hCore)
    rcv_altitude.addr = BTI429_FilterSet(MSGCRT429_DEFAULT, &O212, SDIALL, rcvchan, hCore)

    ' Create a message for each of the labels we are transmitting.
    xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
    xmt_altitude.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
    
    ' Next, a schedule is built by creating explicit message timing.
    Call BTI429_SchedMsg(xmt_altitude.addr, xmtchan, hCore)
    Call BTI429_SchedMsg(xmt_airspeed.addr, xmtchan, hCore)
    Call BTI429_SchedGap(495, xmtchan, hCore)
    Call BTI429_SchedMsg(xmt_altitude.addr, xmtchan, hCore)
    Call BTI429_SchedGap(531, xmtchan, hCore)
    
    ' Those messages that are to be transmitted are initialized.
    Call BTI429_MsgDataWr(&H8A, xmt_altitude.addr, hCore)
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
    Call BTI429_MsgBlockRd(airspeed_record, rcv_airspeed.addr, hCore)
    Call BTI429_MsgBlockRd(altitude_record, rcv_altitude.addr, hCore)

    Label1.Caption = "AirSpeed: min/max=" & CStr(airspeed_record.mintime / 1000) & "ms/" & CStr(airspeed_record.maxtime_elapsetime / 1000) & "ms"
    Label2.Caption = "Altitude: min/max=" & CStr(altitude_record.mintime / 1000) & "ms/" & CStr(altitude_record.maxtime_elapsetime / 1000) & "ms"
    
End Sub


