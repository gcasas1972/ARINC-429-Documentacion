VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI429 Example 12"
   ClientHeight    =   5115
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4695
   LinkTopic       =   "Form1"
   ScaleHeight     =   5115
   ScaleWidth      =   4695
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   1920
      Top             =   4620
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   2
      Top             =   4620
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   1
      Top             =   4620
      Width           =   735
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   4620
      Width           =   735
   End
   Begin VB.Label max_time 
      Caption         =   "MAX = "
      Height          =   255
      Left            =   480
      TabIndex        =   15
      Top             =   3960
      Width           =   3975
   End
   Begin VB.Label min_time 
      Caption         =   "MIN = "
      Height          =   255
      Left            =   480
      TabIndex        =   14
      Top             =   3660
      Width           =   3975
   End
   Begin VB.Line Line3 
      X1              =   240
      X2              =   4320
      Y1              =   3240
      Y2              =   3240
   End
   Begin VB.Label TimeTag 
      Caption         =   "TIME TAG = "
      Height          =   255
      Left            =   480
      TabIndex        =   13
      Top             =   3360
      Width           =   3975
   End
   Begin VB.Label Label2 
      Caption         =   "AIR SPEED"
      Height          =   255
      Left            =   240
      TabIndex        =   12
      Top             =   3000
      Width           =   3975
   End
   Begin VB.Label Header1 
      Caption         =   "IRIG Timer Example"
      Height          =   255
      Index           =   1
      Left            =   1320
      TabIndex        =   11
      Top             =   0
      Width           =   2055
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1740
      Y2              =   1740
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit:"
      Height          =   255
      Left            =   960
      TabIndex        =   10
      Top             =   2340
      Width           =   2895
   End
   Begin VB.Label Receive 
      Caption         =   "Receive:"
      Height          =   255
      Left            =   960
      TabIndex        =   9
      Top             =   2055
      Width           =   2895
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP12     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   8
      Top             =   465
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   7
      Top             =   945
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   6
      Top             =   1185
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   5
      Top             =   1425
      Width           =   4335
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   4560
      Y1              =   360
      Y2              =   360
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   960
      TabIndex        =   4
      Top             =   1785
      Width           =   2895
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   3
      Top             =   705
      Width           =   4335
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI429 DRIVER VB_EXAMPLE 12  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP12 -- IRIG Timer example.
'
'  This program opens Card Number 0, finds the first
'  compatible core, and enable the IRIG timer. A transmit
'  schedule is built using explicit message timing. The
'  selftest wrap-around is enabled and filters are set to
'  receive the messages. A timetag, minimum and maximum elapsed
'  time for each message is converted from the IRIG time and
'  displayed.
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
Dim rightnow As Date

Dim xmt_airspeed As MSGSTRUCT429
Dim rcv_airspeed As MSGSTRUCT429
Dim airspeed_record As MSGFIELDS429
Dim irigtime As BTIIRIGTIME

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
    
'  Configure rcvchan to receive at low speed with the
'  Min/Max Elapse Time option also enabled.
'  Note that the selftest wrap-around is also enabled.
'
'  Configure xmtchan to transmit at low speed.
'  Note that the selftest wrap-around is also enabled.
'  The external line drivers are disabled, and xmtchan is
'  connected internally to all the receive channels.
'

    BTICard_CardReset (hCore)
    
    'Configure receive channel
    ERRVAL = BTI429_ChConfig(CHCFG429_MAXMIN Or CHCFG429_SELFTEST, rcvchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    'Configure transmit channel
    ERRVAL = BTI429_ChConfig(CHCFG429_SELFTEST, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring " & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
'   Before any messages can be received, filters must be set
'   for the receive channel.

    rcv_airspeed.addr = BTI429_FilterSet(MSGCRT429_DEFAULT, &O206, SDIALL, rcvchan, hCore)

'   Create a message for each of the labels we are transmitting.

    xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)

'   Next, a schedule is built by creating explicit message timing.

    Call BTI429_SchedMsg(xmt_airspeed.addr, xmtchan, hCore)
    Call BTI429_SchedGap(1100, xmtchan, hCore)

'   Those messages that are to be transmitted are initialized.

    Call BTI429_MsgDataWr(&H86, xmt_airspeed.addr, hCore)

'   Configure the IRIG timer. (DEFAULT -> bit rate = IRIGB, internal, slave/reciever)
'   Sequential monitor will store IRIG time in sequetial records

    ERRVAL = BTICard_IRIGConfig(IRIGCFG_DEFAULT, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring " & vbNewLine
        errstr = errstr & "the IRIG timer on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If

'   Synchronize the on core IRIG timer with the computer local time

    rightnow = Now              ' Now returns the current date/time.
    irigtime.days = DateDiff("d", DateSerial(Year(rightnow), 1, 1), rightnow) + 1
    irigtime.hours = Hour(rightnow)
    irigtime.min = Minute(rightnow)
    irigtime.sec = Second(rightnow)
    irigtime.msec = 0          ' The Date structure does not include milliseconds.
    irigtime.usec = 0          ' The Date structure does not include microseconds.

    ERRVAL = BTICard_IRIGWr(irigtime, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while writting" & vbNewLine
        errstr = errstr & "the IRIG time on core #" & corenum
        MsgBox errstr
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
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first ARINC 429 core with both a receive and a transmit channel.
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
    
    ' Read the message record from the core
    Call BTI429_MsgBlockRd(airspeed_record, rcv_airspeed.addr, hCore)
    
    Dim tempstr As String
    
    ' Format the time stamp
    tempstr = "TIME TAG ="
    tempstr = tempstr & " " & BTICard_IRIGFieldGetHours(airspeed_record.timetagh, airspeed_record.timetag_hitcount)
    tempstr = tempstr & ":" & BTICard_IRIGFieldGetMin(airspeed_record.timetagh, airspeed_record.timetag_hitcount)
    tempstr = tempstr & " " & BTICard_IRIGFieldGetSec(airspeed_record.timetagh, airspeed_record.timetag_hitcount)
    tempstr = tempstr & "." & BTICard_IRIGFieldGetMillisec(airspeed_record.timetagh, airspeed_record.timetag_hitcount)
    tempstr = tempstr & "." & BTICard_IRIGFieldGetMicrosec(airspeed_record.timetagh, airspeed_record.timetag_hitcount)
    TimeTag.Caption = tempstr
    
    ' Format the MIN time
    tempstr = "MIN ="
    tempstr = tempstr & " " & BTICard_IRIGFieldGetMillisec(0, airspeed_record.mintime)
    tempstr = tempstr & "ms"
    min_time.Caption = tempstr
    
    ' Format the MAX time
    tempstr = "Max ="
    tempstr = tempstr & " " & BTICard_IRIGFieldGetMillisec(0, airspeed_record.maxtime_elapsetime)
    tempstr = tempstr & "ms"
    max_time.Caption = tempstr
    
End Sub


