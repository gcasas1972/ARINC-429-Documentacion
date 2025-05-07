VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI708 Example 8"
   ClientHeight    =   4395
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4695
   LinkTopic       =   "Form1"
   ScaleHeight     =   4395
   ScaleWidth      =   4695
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   3900
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   1
      Top             =   3900
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   0
      Top             =   3900
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   1920
      Top             =   3900
   End
   Begin VB.Label ElapaseTime 
      Caption         =   "Elapse Time:"
      Height          =   375
      Left            =   480
      TabIndex        =   13
      Top             =   3240
      Width           =   3975
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   12
      Top             =   825
      Width           =   4335
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   960
      TabIndex        =   11
      Top             =   1905
      Width           =   2895
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   4560
      Y1              =   480
      Y2              =   480
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   10
      Top             =   1545
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   9
      Top             =   1305
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   8
      Top             =   1065
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP8     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   7
      Top             =   585
      Width           =   4335
   End
   Begin VB.Label Receive 
      Caption         =   "Receive:"
      Height          =   255
      Left            =   960
      TabIndex        =   6
      Top             =   2175
      Width           =   2895
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit:"
      Height          =   255
      Left            =   960
      TabIndex        =   5
      Top             =   2460
      Width           =   2895
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1860
      Y2              =   1860
   End
   Begin VB.Label Header1 
      Caption         =   "IRIG Timer Example"
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
      TabIndex        =   4
      Top             =   120
      Width           =   2175
   End
   Begin VB.Label TimeTag 
      Caption         =   "TIME TAG = "
      Height          =   255
      Left            =   480
      TabIndex        =   3
      Top             =   2880
      Width           =   3975
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI429 DRIVER VB_EXAMPLE 8  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP8 -- IRIG Timer example.
'
'  This program opens Card Number 0, and configures the
'  first compatible core to configure the first receive
'  channel and the first transmit channel to operate on
'  the self-test bus.  The tranmsitter is configured
'  with 128 messages that are initialized with
'  incrementing data.  The receive channel is configured
'  to record it's data to the Sequential Monitor.
'
'  An Event Log frequency of 0 is specifed, which will
'  not generate any Event Log List entries for thess channels.
'
'  The program will display the IRIG time and elapsed time from
'  receive message structure 0.
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
Dim timetagIsBCD As Boolean
Dim temp As Long
Dim Data(99) As Integer
Dim rightnow As Date
Dim irigtime As BTIIRIGTIME
Dim msgfields As MSGFIELDS708
Dim j As Integer
Dim jj As Integer

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
    
    BTICard_CardReset (hCore)
    
    'Configure receive channel
    ERRVAL = BTI708_ChConfig(CHCFG708_ELAPSE Or CHCFG708_SELFTEST, rcvchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    'Configure transmit channel
    ERRVAL = BTI708_ChConfig(CHCFG708_SELFTEST, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring " & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    'Build the receive channel messages.
    ERRVAL = BTI708_RcvBuild(MSGCRT708_DEFAULT, 0, 1, rcvchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while building" & vbNewLine
        errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If

    'Build the transmit channel messages.
    ERRVAL = BTI708_XmtBuild(MSGCRT708_DEFAULT, 200, 0, 128, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while building" & vbNewLine
        errstr = errstr & "transmit channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If


    'Create and write the data for the messages.

    For j = 0 To 127                 'Loop through all the messages
        For jj = 0 To 99
            Data(jj) = (j * 256) + jj
        Next
        Call BTI708_MsgDataWr(Data(0), j, xmtchan, hCore) 'Write data to the Device
    Next

'   Configure the IRIG timer. (DEFAULT -> bit rate = IRIGB, internal, slave/reciever)
'   Sequential monitor will store IRIG time in sequetial records

    ERRVAL = BTICard_IRIGConfig(IRIGCFG_DEFAULT, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring " & vbNewLine
        errstr = errstr & "the IRIG timer on channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If

    If (TIMETAG_FORMAT_BCD = BTICard_TimerStatus(hCore)) Then
        timetagIsBCD = True
    Else
        timetagIsBCD = False
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
        MsgBox(errstr)
        bSkipRun = True
        Exit Sub
    End If

    ' Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        MsgBox("Error:  An error was encountered while starting the card")
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
    
    ' Find the first ARINC 708 core with both a receive and a transmit channel.
    For corenum = 0 To MAX_CORES
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For rcvchan = 0 To MAX_CHANNELS - 1
                If BTI708_ChIsRcv(rcvchan, hCore) Then
                    For xmtchan = 0 To MAX_CHANNELS - 1
                        If BTI708_ChIsXmt(xmtchan, hCore) Then
                            Exit For
                        End If
                    Next
                    If xmtchan <> MAX_CHANNELS - 1 Then
                        Exit For
                    End If
                End If
            Next
            If (rcvchan <> MAX_CHANNELS - 1) And (xmtchan <> MAX_CHANNELS - 1) Then
                Exit For
            End If
        End If
    Next
    
    If (hCore = 0) Or (corenum = MAX_CORES - 1) Or (rcvchan = MAX_CHANNELS - 1) Or (xmtchan = MAX_CHANNELS - 1) Then
        MsgBox "Error:  No compatible ARINC 708 core present in card #" & cardnum
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
    Call BTI708_MsgBlockRd(msgfields, 0, rcvchan, hCore)

    If (False = timetagIsBCD) Then
        'Convert binary timetag to BCD
        BTICard_IRIGTimeBinToBCD(msgfields.timetagh, msgfields.timetag_hitcount, msgfields.timetagh, msgfields.timetag_hitcount);
        'Convert binary elapsetime to BCD
        BTICard_IRIGTimeBinToBCD(temp, msgfields.elapsetime_maxtime_mintime, temp, msgfields.elapsetime_maxtime_mintime);
    End If

    Dim tempstr As String

    ' Format the time stamp
    tempstr = "TIME TAG: "
    tempstr = tempstr & " " & BTICard_IRIGFieldGetHours(msgfields.timetagh, msgfields.timetag_hitcount)
    tempstr = tempstr & ":" & BTICard_IRIGFieldGetMin(msgfields.timetagh, msgfields.timetag_hitcount)
    tempstr = tempstr & " " & BTICard_IRIGFieldGetSec(msgfields.timetagh, msgfields.timetag_hitcount)
    tempstr = tempstr & "." & BTICard_IRIGFieldGetMillisec(msgfields.timetagh, msgfields.timetag_hitcount)
    tempstr = tempstr & "." & BTICard_IRIGFieldGetMicrosec(msgfields.timetagh, msgfields.timetag_hitcount)
    TimeTag.Caption = tempstr

    ' Format the ELAPSE time
    tempstr = "ELAPSE TIME: "
    tempstr = tempstr & " " & BTICard_IRIGFieldGetMillisec(0, msgfields.max_min_elspasetime)
    tempstr = tempstr & "ms"
    ElapaseTime.Caption = tempstr

End Sub



