VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI429 Example 2"
   ClientHeight    =   4545
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4695
   LinkTopic       =   "Form1"
   ScaleHeight     =   4545
   ScaleWidth      =   4695
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   2
      Top             =   4080
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   3240
      Top             =   4080
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   1080
      TabIndex        =   1
      Top             =   4080
      Width           =   735
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   4080
      Width           =   735
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit:"
      Height          =   255
      Left            =   1080
      TabIndex        =   13
      Top             =   2160
      Width           =   2895
   End
   Begin VB.Label airspeed 
      Caption         =   "comp_airspeed"
      Height          =   255
      Left            =   840
      TabIndex        =   12
      Top             =   2760
      Width           =   2775
   End
   Begin VB.Label temp 
      Caption         =   "tot_air_temp"
      Height          =   255
      Left            =   840
      TabIndex        =   11
      Top             =   3180
      Width           =   2775
   End
   Begin VB.Label altitude 
      Caption         =   "altitude_rate"
      Height          =   255
      Left            =   840
      TabIndex        =   10
      Top             =   3600
      Width           =   2775
   End
   Begin VB.Line Line5 
      X1              =   120
      X2              =   4560
      Y1              =   360
      Y2              =   360
   End
   Begin VB.Line Line4 
      X1              =   120
      X2              =   4560
      Y1              =   1800
      Y2              =   1800
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
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   8
      Top             =   1200
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   7
      Top             =   735
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP2  (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   6
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Header1 
      Caption         =   "Transmit Example"
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
      TabIndex        =   5
      Top             =   0
      Width           =   1935
   End
   Begin VB.Label Label1 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Left            =   120
      TabIndex        =   4
      Top             =   975
      Width           =   4335
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   1080
      TabIndex        =   3
      Top             =   1920
      Width           =   2895
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI429 DRIVER VB_EXAMPLE 2  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP2 -- Transmitter example
'
'  This program opens Card Number 0, and configures the
'  first compatible core to build a transmit schedule
'  using transmit interval information, and then transmit
'  the messages with changing data.
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
Dim comp_airspeed As MSGSTRUCT429
Dim tot_air_temp As MSGSTRUCT429
Dim altitude_rate As MSGSTRUCT429
Dim msgaddr(2) As Long
Dim min_intrvls(2) As Long
Dim max_intrvls(2) As Long
Dim bnr_data(2) As Long

Private Sub cmdExit_Click()
    If (hCard >= 0) Then
        ERRVAL = BTICard_CardClose(hCard)
    End If
      
    ' End Program
    End
    
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
    
    ' Find the first ARINC 429 core with a transmit channel
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
    airspeed.Caption = "comp_airspeed = "
    temp.Caption = "tot_air_temp  = "
    altitude.Caption = "altitude_rate = "

    'Set flag so we run hardware
    bSkipRun = False
    
    CmdStart.Enabled = True
    CmdStop.Enabled = False
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub cmdStop_Click()
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

Private Sub cmdStart_Click()
    
    If (bSkipRun = True) Then
        Exit Sub
    End If
    
    ' Configure xmtchan to transmit at high speed.
    BTICard_CardReset (hCore)
    ERRVAL = BTI429_ChConfig(CHCFG429_HIGHSPEED, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Create a message for each of the labels we are transmitting.
    comp_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
    tot_air_temp.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
    altitude_rate.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
    
    ' Setup the arrays of message addresses, and intervals
    ' needed to build the schedule.  Note that the nth element
    ' in each array correspond to eachother.
    msgaddr(0) = comp_airspeed.addr
    min_intrvls(0) = 250
    max_intrvls(0) = 500
    
    msgaddr(1) = tot_air_temp.addr
    min_intrvls(1) = 250
    max_intrvls(1) = 500
    
    msgaddr(2) = altitude_rate.addr
    min_intrvls(2) = 100
    max_intrvls(2) = 200
    
    ' Next, build a schedule using the minimum and maximum
    ' transmit intervals.
    ERRVAL = BTI429_SchedBuild(3, msgaddr(0), min_intrvls(0), max_intrvls(0), xmtchan, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  BTI429_SchedBuild failed."
        bSkipRun = True
        Exit Sub
    End If
    
    ' Initialize the three Message Records.
    comp_airspeed.Data = BTI429_FldPutLabel(0, &O206)    '/*Init label field*/
    tot_air_temp.Data = BTI429_FldPutLabel(0, &O211)
    altitude_rate.Data = BTI429_FldPutLabel(0, &O212)
    
    comp_airspeed.Data = BTI429_BNRPutMant(comp_airspeed.Data, 0, 14, 0) '/*Init BNR data*/
    tot_air_temp.Data = BTI429_BNRPutMant(tot_air_temp.Data, 0, 11, 0)
    altitude_rate.Data = BTI429_BNRPutMant(altitude_rate.Data, 0, 16, 0)
    
    Call BTI429_MsgDataWr(comp_airspeed.Data, comp_airspeed.addr, hCore)
    Call BTI429_MsgDataWr(tot_air_temp.Data, tot_air_temp.addr, hCore)
    Call BTI429_MsgDataWr(altitude_rate.Data, altitude_rate.addr, hCore)
    
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

Private Sub Timer1_Timer()

    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    '
    ' Change data
    '
    
    ' Read messages back
    comp_airspeed.Data = BTI429_MsgDataRd(comp_airspeed.addr, hCore)
    tot_air_temp.Data = BTI429_MsgDataRd(tot_air_temp.addr, hCore)
    altitude_rate.Data = BTI429_MsgDataRd(altitude_rate.addr, hCore)

    ' Extract BNR data
    bnr_data(0) = BTI429_BNRGetMant(comp_airspeed.Data, 14)
    bnr_data(1) = BTI429_BNRGetMant(tot_air_temp.Data, 11)
    bnr_data(2) = BTI429_BNRGetMant(altitude_rate.Data, 16)

    ' Change BNR data
    bnr_data(0) = bnr_data(0) + 1
    bnr_data(1) = bnr_data(1) + 1
    bnr_data(2) = bnr_data(2) + 1

    ' Put BNR data back into messages
    comp_airspeed.Data = BTI429_BNRPutMant(comp_airspeed.Data, bnr_data(0), 14, 0)
    tot_air_temp.Data = BTI429_BNRPutMant(tot_air_temp.Data, bnr_data(1), 11, 0)
    altitude_rate.Data = BTI429_BNRPutMant(altitude_rate.Data, bnr_data(2), 16, 0)

    ' Write new message values
    Call BTI429_MsgDataWr(comp_airspeed.Data, comp_airspeed.addr, hCore)
    Call BTI429_MsgDataWr(tot_air_temp.Data, tot_air_temp.addr, hCore)
    Call BTI429_MsgDataWr(altitude_rate.Data, altitude_rate.addr, hCore)
    
    ' Display new values on form
    airspeed.Caption = "comp_airspeed = " & Hex(comp_airspeed.Data) & " (Hex)"
    temp.Caption = "tot_air_temp  = " & Hex(tot_air_temp.Data) & " (Hex)"
    altitude.Caption = "altitude_rate = " & Hex(altitude_rate.Data) & " (Hex)"

End Sub

